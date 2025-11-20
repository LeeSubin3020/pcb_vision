using Microsoft.Data.Sqlite;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenCvSharp.XPhoto;
using PCBVison.Models;
using PCBVison.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace PCBVison.Presenters
{
    public class MainPresenter
    {
        // --- 멤버 변수 선언 ---

        private readonly IMainView _view; // View와 통신하기 위한 인터페이스. Presenter는 이것이 Form1인지 전혀 모릅니다.
        private readonly PcbModel _model;
        private readonly HashSet<string> _activeFilters = new HashSet<string>();
        private readonly string _logFilePath; //상세로그 저장 경로
        private readonly object _fileLock = new object(); // 스레드 안정성
        private readonly string _defectImagePath;  // 불량 이미지 저장 폴더
        private readonly string _dbPath;

        private VideoCapture _capture;    // OpenCV 카메라 캡처 객체
        private Mat _frame;               // 카메라로부터 한 프레임을 받아올 객체
        private Thread _cameraThread;     // 실시간 영상 처리를 위한 별도의 스레드
        private bool _isRunning;
        private int _totalCount = 0;
        private int _passCount = 0;
        private int _failCount = 0;
        private int _inspectionSeq = 1;
        private int _maxA1InFrame = 0;
        private Dictionary<string, int> partCounts = new Dictionary<string, int>();  // 카운트용
        private Dictionary<string, List<float>> _partConfidences = new Dictionary<string, List<float>>(); // Confidence 누적용
        /// <param name="view">Presenter와 연결될 View 객체 (Form1)</param>

        public MainPresenter(IMainView view, string onnxPath)
        {
            _view = view;
            _model = new PcbModel(onnxPath);

            // 로그 폴더
            string logDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PCB_Inspection_Logs");
            Directory.CreateDirectory(logDir);
            _logFilePath = Path.Combine(logDir, "Inspection_Detail_Log.txt");

            // SQLite DB 파일 경로
            _dbPath = Path.Combine(logDir, "PCB_Inspection.db");
            using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE IF NOT EXISTS InspectionResults (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Timestamp TEXT NOT NULL,
                        Seq INTEGER NOT NULL,
                        Result TEXT NOT NULL,
                        A1_Count INTEGER,
                        A1_Conf REAL,
                        A1_MaxSimultaneous INTEGER,
                        AMS1117_Count INTEGER,
                        AMS1117_Conf REAL,
                        CH340G_Count INTEGER,
                        CH340G_Conf REAL,
                        S4_Count INTEGER,
                        S4_Conf REAL,
                        Overall_Confidence REAL,
                        MissingParts TEXT,
                        DefectImagePath TEXT
                    );";
                command.ExecuteNonQuery();
            }

            // 불량 이미지 저장 폴더
            string defectDir = Path.Combine(logDir, "Defects");
            Directory.CreateDirectory(defectDir);
            _defectImagePath = defectDir;

            // 헤더 작성
            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath,
                    "시간\t순번\t결과\tA1(횟수/conf)\tAMS-1117(횟수/conf)\tCH340G(횟수/conf)\tS4(횟수/conf)\t평균 Confidence\r\n");
            }

            _view.StartStopClicked += OnStartStopClicked;
            _view.FormClosing += OnFormClosing;
        }

        public void OnFilterChanged(string? filterName, bool isChecked)
        {
            if (filterName is null) return;

            if (isChecked)
                _activeFilters.Add(filterName);
            else
                _activeFilters.Remove(filterName);
        }

        private void OnStartStopClicked(object sender, EventArgs e)
        {
            if (!_isRunning) // 카메라가 꺼져있을 경우
            {
                // 1. 카메라 장치 열기
                _capture = new VideoCapture(0, VideoCaptureAPIs.DSHOW);
                if (!_capture.IsOpened())
                {
                    // 2. 카메라 열기 실패 시, View에게 오류 메시지 표시를 지시
                    _view.ShowError("카메라를 열 수 없습니다. 장치를 확인하세요");
                    _capture?.Dispose(); // 수정: Release() 대신 Dispose() 사용
                    return;
                }

                // 3. 변수 및 스레드 초기화 후, 영상 처리 스레드 시작
                _inspectionSeq = 1;
                _view.ClearInspectionList();
                _frame = new Mat();
                _isRunning = true;
                _cameraThread = new Thread(ProcessCamera);
                _cameraThread.Start();
                _view.StartButtonText = "검사 중지";
                _view.Log("카메라 시작");
            }
            else
            {
                _isRunning = false;

                if (_cameraThread != null && _cameraThread.IsAlive)
                {
                    if (!_cameraThread.Join(1000))  // 최대 1초 대기
                    {
                        // 정상적으로 종료되지 않으면 강제 중단 (선택적)
                        _cameraThread.Interrupt();
                    }
                }
                _capture?.Release();

                // 2. View에게 버튼 텍스트 변경을 지시
                _view.StartButtonText = "검사 시작";
            }
        }

        private void ApplyFilters(Mat frame)
        {
            // 필터 적용 로직 구현
            if (_activeFilters.Contains("White Balance"))
            {
                // 1채널 이미지인 경우 3채널 BGR로 변환
                if (frame.Channels() == 1)
                {
                    Cv2.CvtColor(frame, frame, ColorConversionCodes.GRAY2BGR);
                }

                double blueGain = _view.BlueGain;
                double greenGain = _view.GreenGain;
                double redGain = _view.RedGain;
                double wbGain = _view.WbGain;

                // BGR 채널 분리
                var bgr = frame.Split();

                // 각각의 채널에 Gain 적용
                bgr[0] *= blueGain * wbGain;
                bgr[1] *= greenGain * wbGain;
                bgr[2] *= redGain * wbGain;

                // 병합해서 프레임 업데이트
                Cv2.Merge(bgr, frame);

                foreach (var c in bgr)
                    c.Dispose();

            }
            if (_activeFilters.Contains("Gaussian Filter"))
            {
                Cv2.GaussianBlur(frame, frame, new OpenCvSharp.Size(5, 5), 0);
            }

            if (_activeFilters.Contains("Median Filter"))
            {
                Cv2.MedianBlur(frame, frame, 5);
            }

            if (_activeFilters.Contains("Unsharp Mask"))
            {
                double sigma = _view.SigmaGain;
                double intensity = _view.IntensityGain;

                using (var blurred = new Mat())
                {
                    Cv2.GaussianBlur(frame, blurred, new OpenCvSharp.Size(0, 0), sigma);

                    // sharpened = original * (1 + amount) + blurred * (-amount)
                    Cv2.AddWeighted(frame, 1 + intensity, blurred, -intensity, 0, frame);
                }
            }

        }


        /// 별도의 스레드에서 실행되며, 실시간 영상 처리를 담당하는 메서드입니다.
        private void ProcessCamera()
        {
            try
            {
                while (_isRunning)
                {
                    if (!_capture.Read(_frame) || _frame.Empty())
                    {
                        Thread.Sleep(30);
                        continue;
                    }

                    using (Mat processedFrame = _frame.Clone())
                    {
                        ApplyFilters(processedFrame);

                        var initialResults = _model.Predict(processedFrame);

                        if (initialResults.Count > 0)
                        {
                            _view.Log("부품 감지됨. 5초 정밀 검사를 시작합니다...");

                            DateTime endTime = DateTime.Now.AddSeconds(5);

                            // 부품 카운트 초기화
                            partCounts.Clear();
                            _partConfidences.Clear();
                            _maxA1InFrame = 0;

                            // 5초 검사 루프
                            while (DateTime.Now < endTime && _isRunning)
                            {
                                if (!_capture.Read(_frame) || _frame.Empty())
                                {
                                    Thread.Sleep(10);
                                    continue;
                                }

                                using (Mat inspectionFrame = _frame.Clone())
                                {
                                    ApplyFilters(inspectionFrame);
                                    var currentResults = _model.Predict(inspectionFrame);

                                    // A1 카운팅 로직
                                    int a1CountInFrame = currentResults.Count(r => r.Label == "A1");
                                    _maxA1InFrame = Math.Max(_maxA1InFrame, a1CountInFrame);

                                    // 모든 부품 카운팅
                                    foreach (var r in currentResults)
                                    {
                                        string label = r.Label;

                                        // 1. 부품 카운팅
                                        if (!partCounts.ContainsKey(label))
                                            partCounts[label] = 0;
                                        partCounts[label]++;

                                        // 2. Confidence 누적 (정확도 측정용)
                                        if (!_partConfidences.ContainsKey(label))
                                            _partConfidences[label] = new List<float>();
                                        _partConfidences[label].Add(r.Confidence);

                                        // 3.화면에 박스 + 라벨 그리기
                                        Scalar boxColor = _model.Colors[r.LabelIndex % _model.Colors.Length];
                                        Cv2.Rectangle(inspectionFrame, r.Rect, boxColor, 2);
                                        Cv2.PutText(inspectionFrame, $"{r.Label} {r.Confidence:F2}",
                                            new OpenCvSharp.Point(r.Rect.X, r.Rect.Y - 5),
                                            HersheyFonts.HersheySimplex, 0.5, boxColor, 1);
                                    }

                                    using (var bitmap = BitmapConverter.ToBitmap(inspectionFrame))
                                    {
                                        _view.ImageViewerImage = (Bitmap)bitmap.Clone();
                                    }
                                }
                                Thread.Sleep(30);
                            }

                            if (!_isRunning) break;

                            // Pass/Fail 판정
                            _totalCount++;

                            var requiredParts = new List<string> { "A1", "AMS-1117", "CH340G", "S4" };
                            const int minDetections = 7;
                            var missingParts = new List<string>();

                            if (_maxA1InFrame < 2)
                            {
                                missingParts.Add("A1");
                                _view.Log($"A1 부품 개체 수 부족: {_maxA1InFrame}개 (필요 2개)");
                            }

                            // 나머지 부품들 검사
                            foreach (var part in requiredParts.Where(p => p != "A1"))
                            {
                                int count = partCounts.GetValueOrDefault(part, 0);
                                if (count < minDetections)
                                {
                                    missingParts.Add(part);
                                    _view.Log($"부품 {part} 감지 횟수: {count} (필요 {minDetections}회)");
                                }
                            }

                            bool isPass = missingParts.Count == 0;

                            // 부품별 통계 + 전체 평균 계산
                            var partStats = new List<string>();
                            double totalConfSum = 0;
                            int totalDetCount = 0;

                            foreach (var part in requiredParts)
                            {
                                int count = partCounts.GetValueOrDefault(part, 0);
                                float avgConf = _partConfidences.ContainsKey(part) && _partConfidences[part].Count > 0
                                    ? _partConfidences[part].Average()
                                    : 0f;

                                if (part == "A1")
                                {
                                    partStats.Add($"A1({count}/{avgConf:F3}) [최대 동시: {_maxA1InFrame}]");
                                }
                                else
                                {
                                    partStats.Add($"{part}({count}/{avgConf:F3})");
                                }

                                if (_partConfidences.ContainsKey(part))
                                {
                                    totalConfSum += avgConf * _partConfidences[part].Count;
                                    totalDetCount += _partConfidences[part].Count;
                                }
                            }

                            double overallAvg = totalDetCount > 0 ? totalConfSum / totalDetCount : 0.0;

                            string resultText = isPass ? "정상" : $"불량 - {string.Join(", ", missingParts)} 누락";

                            if (isPass) _passCount++; else _failCount++;

                            _view.AddInspectionResultLine($"{_inspectionSeq++,4}: {resultText}");
                            _view.Log(isPass ? "PCB 검사 결과 정상입니다." : "PCB 검사 결과 불량입니다.");
                            string fullPath = "";

                            // 불량 이미지 저장
                            if (!isPass)
                            {
                                using (var currentBitmap = _view.ImageViewerImage)
                                {
                                    if (currentBitmap != null)
                                    {
                                        try
                                        {
                                            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                                            string missingText = string.Join("_", missingParts);
                                            if (string.IsNullOrEmpty(missingText)) missingText = "기타";

                                            string fileName = $"불량_{timestamp}_{_inspectionSeq - 1:D3}_{missingText}.png";
                                            fullPath = Path.Combine(_defectImagePath, fileName);

                                            currentBitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
                                            _view.Log($"불량 이미지 저장: {fileName}");

                                            if (_failCount == 1)
                                            {
                                                System.Diagnostics.Process.Start("explorer.exe", _defectImagePath);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            _view.Log($"이미지 저장 실패: {ex.Message}");
                                        }
                                    }


                                }
                            }

                            // 상세 로그 파일 저장
                            string logLine = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\t" +
                                             $"{_inspectionSeq - 1}\t" +
                                             $"{resultText}\t" +
                                             $"{string.Join("\t", partStats)}\t" +
                                             $"{overallAvg:F3}";

                            lock (_fileLock)
                            {
                                File.AppendAllText(_logFilePath, logLine + "\r\n");
                            }

                            // SQLite DB 저장
                            try
                            {
                                using (var connection = new SqliteConnection($"Data Source={_dbPath}"))
                                {
                                    connection.Open();
                                    var command = connection.CreateCommand();
                                    command.CommandText = @"
                                        INSERT INTO InspectionResults 
                                        (Timestamp, Seq, Result, 
                                         A1_Count, A1_Conf, A1_MaxSimultaneous,
                                         AMS1117_Count, AMS1117_Conf,
                                         CH340G_Count, CH340G_Conf,
                                         S4_Count, S4_Conf,
                                         Overall_Confidence, MissingParts, DefectImagePath)
                                        VALUES 
                                        (@ts, @seq, @result,
                                         @a1c, @a1conf, @a1max,
                                         @amsc, @amsconf,
                                         @chc, @chconf,
                                         @s4c, @s4conf,
                                         @overall, @missing, @image)";

                                    command.Parameters.AddWithValue("@ts", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    command.Parameters.AddWithValue("@seq", _inspectionSeq - 1);
                                    command.Parameters.AddWithValue("@result", resultText);
                                    command.Parameters.AddWithValue("@a1c", partCounts.GetValueOrDefault("A1", 0));
                                    command.Parameters.AddWithValue("@a1conf", _partConfidences.ContainsKey("A1") ? _partConfidences["A1"].Average() : 0f);
                                    command.Parameters.AddWithValue("@a1max", _maxA1InFrame);
                                    command.Parameters.AddWithValue("@amsc", partCounts.GetValueOrDefault("AMS-1117", 0));
                                    command.Parameters.AddWithValue("@amsconf", _partConfidences.ContainsKey("AMS-1117") ? _partConfidences["AMS-1117"].Average() : 0f);
                                    command.Parameters.AddWithValue("@chc", partCounts.GetValueOrDefault("CH340G", 0));
                                    command.Parameters.AddWithValue("@chconf", _partConfidences.ContainsKey("CH340G") ? _partConfidences["CH340G"].Average() : 0f);
                                    command.Parameters.AddWithValue("@s4c", partCounts.GetValueOrDefault("S4", 0));
                                    command.Parameters.AddWithValue("@s4conf", _partConfidences.ContainsKey("S4") ? _partConfidences["S4"].Average() : 0f);
                                    command.Parameters.AddWithValue("@overall", overallAvg);
                                    command.Parameters.AddWithValue("@missing", string.Join(", ", missingParts));
                                    command.Parameters.AddWithValue("@image", !isPass ? fullPath : ""); // 불량 이미지 경로

                                    command.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                _view.Log($"DB 저장 실패: {ex.Message}");
                            }

                            _view.TotalCount = _totalCount;
                            _view.PassCount = _passCount;
                            _view.FailCount = _failCount;

                            Thread.Sleep(3000);
                        }
                        else
                        {
                            // 부품 미감지 시, 필터 적용된 프레임을 UI에 표시
                            using (var bitmap = BitmapConverter.ToBitmap(processedFrame))
                            {
                                _view.ImageViewerImage = (Bitmap)bitmap.Clone();
                            }
                        }
                    }

                    Thread.Sleep(30);
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"카메라 처리 중 오류 발생: {ex.Message}");
            }
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            _isRunning = false;
            if (_cameraThread != null && _cameraThread.IsAlive)
            {
                if (!_cameraThread.Join(1000))
                {
                    // _cameraThread.Interrupt();
                }
            }
            _capture?.Release();
        }
    }
}
