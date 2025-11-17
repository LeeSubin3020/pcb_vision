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

namespace PCBVison.Presenters
{
    /// 애플리케이션의 핵심 로직을 담당하는 Presenter (주방장) 클래스입니다.
    /// UI(View)로부터 이벤트를 받아 실제 동작을 수행하고, 그 결과를 다시 UI에 반영하도록 지시합니다.
    /// UI에 대한 직접적인 참조 없이, 오직 IMainView 인터페이스를 통해서만 View와 소통합니다.
    public class MainPresenter
    {
        // --- 멤버 변수 선언 ---

        private readonly IMainView _view; // View와 통신하기 위한 인터페이스. Presenter는 이것이 Form1인지 전혀 모릅니다.
        private readonly PcbModel _model;
        private readonly HashSet<string> _activeFilters = new HashSet<string>();
        private VideoCapture _capture;    // OpenCV 카메라 캡처 객체
        private Mat _frame;               // 카메라로부터 한 프레임을 받아올 객체
        private Thread _cameraThread;     // 실시간 영상 처리를 위한 별도의 스레드
        private bool _isRunning;          // 카메라 동작 상태 플래그
        private int _totalCount = 0;
        private int _passCount = 0;
        private int _failCount = 0;
        private const int _inspectCount = 5;


        /// <param name="view">Presenter와 연결될 View 객체 (Form1)</param>

        public MainPresenter(IMainView view, string onnxPath)
        {
            _view = view;
            _model = new PcbModel(onnxPath);

            // View에서 발생하는 이벤트를 Presenter의 메서드와 연결(이벤트 구독)
            // 이제 View에서 StartStopClicked 이벤트가 발생하면, OnStartStopClicked 메서드가 자동으로 호출됩니다.
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

                //if (!_capture.Read(_frame) || _frame.Empty())
                //{
                //    _view.ShowError("프레임 읽기 실패");
                //    _capture?.Dispose(); // 수정: Release() 대신 Dispose() 사용
                //}


                // 3. 변수 및 스레드 초기화 후, 영상 처리 스레드 시작
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
                            var partCounts = new Dictionary<string, int>();

                            // 5초 검사 루프
                            while (DateTime.Now < endTime && _isRunning)
                            {
                                // 루프 안에서 계속 새로운 프레임을 읽습니다.
                                if (!_capture.Read(_frame) || _frame.Empty())
                                {
                                    Thread.Sleep(10);
                                    continue;
                                }

                                using (Mat inspectionFrame = _frame.Clone())
                                {
                                    // 새로 읽은 프레임에 필터를 적용합니다.
                                    ApplyFilters(inspectionFrame);

                                    var currentResults = _model.Predict(inspectionFrame);

                                    // A1 카운팅 로직
                                    int a1CountInFrame = currentResults.Count(r => r.Label == "A1");
                                    if (a1CountInFrame >= 2)
                                    {
                                        if (partCounts.ContainsKey("A1"))
                                            partCounts["A1"]++;
                                        else
                                            partCounts.Add("A1", 1);
                                    }
                                    // 다른 부품 카운팅
                                    foreach (var r in currentResults.Where(res => res.Label != "A1"))
                                    {
                                        if (partCounts.ContainsKey(r.Label))
                                            partCounts[r.Label]++;
                                        else
                                            partCounts.Add(r.Label, 1);
                                    }

                                    foreach (var r in currentResults)
                                    {
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

                            bool isPass = requiredParts.All(partName =>
                                partCounts.ContainsKey(partName) && partCounts[partName] >= minDetections);

                            if (isPass)
                            {
                                _passCount++;
                                _view.Log("PCB 검사 결과 정상입니다.");

                            }
                            else
                            {
                                _failCount++;
                                _view.Log("PCB 검사 결과 불량입니다.");
                                foreach (var partName in requiredParts)
                                {
                                    if (!partCounts.ContainsKey(partName) || partCounts[partName] < minDetections)
                                    {
                                        _view.Log($" -> 부품 {partName} 누락 개수: {partCounts.GetValueOrDefault(partName, 0)}");
                                    }
                                }
                            }

                            _view.TotalCount = _totalCount;
                            _view.PassCount = _passCount;
                            _view.FailCount = _failCount;

                            Thread.Sleep(5000);
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

        /// View의 FormClosing 이벤트가 발생했을 때 호출되는 메서드입니다.
        /// 프로그램 종료 시 리소스를 안전하게 해제하는 역할을 합니다.
        private void OnFormClosing(object sender, EventArgs e)
        {
            _isRunning = false;
            // 수정: 스레드 종료 시 타임아웃을 두어 UI 멈춤 방지
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
