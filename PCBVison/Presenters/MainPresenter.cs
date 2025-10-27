using System;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using PCBVison.Views;
using PCBVison.Models;
using OpenCvSharp;
using OpenCvSharp.Extensions;

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

        public void OnFilterChanged(string filterName, bool isChecked)
        {
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
                _capture = new VideoCapture(0);
                if (!_capture.IsOpened())
                {
                    // 2. 카메라 열기 실패 시, View에게 오류 메시지 표시를 지시
                    _view.ShowError("카메라를 열 수 없습니다. 장치를 확인하세요");
                    _capture?.Dispose(); // 수정: Release() 대신 Dispose() 사용
                    return;
                }

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


        /// 별도의 스레드에서 실행되며, 실시간 영상 처리를 담당하는 메서드입니다.
        private void ProcessCamera()
        {
            try
            {
                while (_isRunning)
                {
                    if (_capture.Read(_frame) && !_frame.Empty())
                    {

                        Mat processedFrame = _frame.Clone();

                        // 필터 적용
                        if (_activeFilters.Contains("White Balance"))
                        {
                            var bgr = _frame.Split();
                            bgr[2] *= 1.5;

                            Cv2.Merge(bgr, _frame);

                            foreach (var c in bgr) c.Dispose();

                        }

                        if (_activeFilters.Contains("Gaussian Filter"))
                        {
                            Cv2.GaussianBlur(processedFrame, processedFrame, new OpenCvSharp.Size(5, 5), 0);
                        }

                        if (_activeFilters.Contains("Median Filter"))
                        {
                            Cv2.MedianBlur(processedFrame, processedFrame, 5);
                        }

                        // 1. 모델 추론 실행
                        var results = _model.Predict(_frame);

                        // 2. 추론 결과를 원본 프레임(_frame)에 그리기
                        foreach (var r in results)
                        {

                            // 디버깅 로그
                            _view.Log($"Found: {r.Label} at ({r.Rect.X},{r.Rect.Y},{r.Rect.Width},{r.Rect.Height}) Conf: {r.Confidence:F2}");

                            Scalar boxColor = _model.Colors[r.LabelIndex % _model.Colors.Length];

                            // 화면에 그리기
                            Cv2.Rectangle(_frame, r.Rect, boxColor, 2);
                            Cv2.PutText(_frame, $"{r.Label} {r.Confidence:F2}",
                                new OpenCvSharp.Point(r.Rect.X, r.Rect.Y - 5),
                                HersheyFonts.HersheySimplex, 0.5, boxColor, 1);
                        }

                        // 3. 결과가 그려진 프레임을 Bitmap으로 변환하여 View에 전달
                        using (var bitmap = BitmapConverter.ToBitmap(_frame))
                        {
                            // View에 이미지를 전달할 때는 복사본을 전달하여 스레드간 충돌을 방지합니다.
                            _view.ImageViewerImage = (Bitmap)bitmap.Clone();
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
