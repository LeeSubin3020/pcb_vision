using System;
using System.Drawing;

using System.Windows.Forms;
using OpenCvSharp.Internal.Vectors;
using PCBVison.Presenters;
using PCBVison.Views;

namespace PCBVison
{
    /// IMainView 인터페이스(계약서)를 구현하며, 실제 로직은 모두 Presenter에게 위임합니다.
    public partial class Form1 : Form, IMainView
    {
        private readonly MainPresenter _presenter; // 실제 동작을 담당할 Presenter 객체
        private double blueGain = 1.0;
        private double greenGain = 1.0;
        private double redGain = 1.0;
        private double wbGain = 1.0;
        private double sgGain = 1.0;
        private double intensityGain = 1.0;
       

        // IMainView 인터페이스에 정의된 이벤트들을 선언합니다.
        // 이 이벤트들은 Presenter가 구독하게 됩니다.
        public event EventHandler? StartStopClicked;
        // new 키워드를 추가하여 부모 클래스의 FormClosing 이벤트를 의도적으로 숨긴다는 것을 명시합니다.
        public new event FormClosingEventHandler? FormClosing;

        public Form1()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                string onnxPath = @"C:\Users\subin\Documents\GitHub\pcb_vision\PCB_Vision\yolo8s.onnx";
                _presenter = new MainPresenter(this, onnxPath);

                // 2. UI 컨트롤(startbt)의 클릭 이벤트를 IMainView의 이벤트에 연결합니다.
                //    이제 startbt 버튼이 클릭되면, StartStopClicked 이벤트가 발생하여 Presenter에게 알려줍니다.
                this.btnStartInspect.Click += (sender, e) => StartStopClicked?.Invoke(sender, e);

                // 3. Form의 Closing 이벤트를 IMainView의 이벤트에 연결합니다.
                base.FormClosing += (sender, e) => FormClosing?.Invoke(sender, e);

                this.Load += Form1_Fillter;
            }

            // TrackBar 범위(0.5배 ~ 3배)
            blueTrackBar.Minimum = 50;
            blueTrackBar.Maximum = 200;

            greenTrackBar.Minimum = 50;
            greenTrackBar.Maximum = 200;

            redTrackBar.Minimum = 50;
            redTrackBar.Maximum = 200;

            wbTrackBar.Minimum = 50;
            wbTrackBar.Maximum = 200;

            sigmaTrackBar.Minimum = 50;
            sigmaTrackBar.Maximum = 300;

            intensityTrackbar.Minimum = 50;
            intensityTrackbar.Maximum = 300;

            numBlue.DecimalPlaces = 2;
            numBlue.Increment = 0.01M;
            numBlue.Minimum = 0.5M;
            numBlue.Maximum = 2.0M;
            numBlue.Value = 1.0M;

            numGreen.DecimalPlaces = 2;
            numGreen.Increment = 0.01M;
            numGreen.Minimum = 0.5M;
            numGreen.Maximum = 2.0M;
            numGreen.Value = 1.0M;

            numRed.DecimalPlaces = 2;
            numRed.Increment = 0.01M;
            numRed.Minimum = 0.5M;
            numRed.Maximum = 2.0M;
            numRed.Value = 1.0M;

            numWb.DecimalPlaces = 2;
            numWb.Increment = 0.01M;
            numWb.Minimum = 0.5M;
            numWb.Maximum = 2.0M;
            numWb.Value = 1.0M;

            numSigma.DecimalPlaces = 2;
            numSigma.Increment = 0.1M;
            numSigma.Minimum = 0.5M;
            numSigma.Maximum = 3.0M;
            numSigma.Value = 1.0M;
            
            numIntensity.DecimalPlaces = 2;
            numIntensity.Increment = 0.1M;
            numIntensity.Minimum = 0.5M;
            numIntensity.Maximum = 3.0M;
            numIntensity.Value = 1.0M;


            // 초기값
            blueTrackBar.Value = greenTrackBar.Value = redTrackBar.Value = wbTrackBar.Value = 100;
            sigmaTrackBar.Value = intensityTrackbar.Value = 50;
            numBlue.Value = numGreen.Value = numRed.Value = numWb.Value = 1.0M;
            numSigma.Value = numIntensity.Value = 1.0M;

            // TrackBar <-> NumericUpDown 연동
            blueTrackBar.Scroll += (sender, e) => SyncTrackAndNum(blueTrackBar, numBlue);
            greenTrackBar.Scroll += (sender, e) => SyncTrackAndNum(greenTrackBar, numGreen);
            redTrackBar.Scroll += (sender, e) => SyncTrackAndNum(redTrackBar, numRed);
            wbTrackBar.Scroll += (sender, e) => SyncTrackAndNum(wbTrackBar, numWb);
            sigmaTrackBar.Scroll += (sender, e) => SyncTrackAndNum(sigmaTrackBar, numSigma);
            intensityTrackbar.Scroll += (sender, e) => SyncTrackAndNum(intensityTrackbar, numIntensity);

            numBlue.ValueChanged += (sender, e) => SyncNumAndTrack(numBlue, blueTrackBar);
            numGreen.ValueChanged += (sender, e) => SyncNumAndTrack(numGreen, greenTrackBar);
            numRed.ValueChanged += (sender, e) => SyncNumAndTrack(numRed, redTrackBar);
            numWb.ValueChanged += (sender, e) => SyncNumAndTrack(numWb, wbTrackBar);
            numSigma.ValueChanged += (sender, e) => SyncNumAndTrack(numSigma, sigmaTrackBar);
            numIntensity.ValueChanged += (sender, e) => SyncNumAndTrack(numIntensity, intensityTrackbar);
        }

        private void SyncTrackAndNum(TrackBar tb, NumericUpDown num)
        {
            decimal val = (decimal)tb.Value / 100M;
            if (num.Value != val)
                num.Value = val;

            UpdateColorGains();
            UnsharpMaskGains();
        }

        private void SyncNumAndTrack(NumericUpDown num, TrackBar tb)
        {
            int val = (int)(num.Value * 100);

            // TrackBar의 범위(50~200) 안으로 강제 보정
            val = Math.Max(tb.Minimum, Math.Min(tb.Maximum, val));

            if (tb.Value != val)
                tb.Value = val;

            UpdateColorGains();

        }

        private void UpdateColorGains()
        {
            blueGain = (double)numBlue.Value;
            greenGain = (double)numGreen.Value;
            redGain = (double)numRed.Value;
            wbGain = (double)numWb.Value;
        }

        private void UnsharpMaskGains()
        {
            sgGain = (double)numSigma.Value;
            intensityGain = (double)numIntensity.Value;
        }

        public double BlueGain => blueGain;
        public double GreenGain => greenGain;
        public double RedGain => redGain;
        public double WbGain => wbGain;
        public double SigmaGain => sgGain;
        
        public double IntensityGain => intensityGain;

        /// Presenter가 전달해준 이미지를 화면에 표시하는 속성입니다.
        public Image ImageViewerImage
        {
            get { return imageViewer.Image; }
            set
            {
                // Presenter의 ProcessCamera 스레드가 이 속성을 직접 호출하므로,
                // UI 컨트롤을 안전하게 업데이트하기 위해 Invoke가 필요합니다.
                if (imageViewer.InvokeRequired)
                {
                    imageViewer.Invoke(new Action(() =>
                    {
                        imageViewer.Image?.Dispose(); // 기존 이미지 리소스 해제
                        // Presenter가 복제된 이미지를 주므로, 여기서는 바로 사용합니다.
                        imageViewer.Image = value;
                    }));
                }
                else
                {
                    imageViewer.Image?.Dispose();
                    imageViewer.Image = value;
                }
            }
        }

        // 로그 메시지를 터미널(TextBox)에 표시
        public void Log(string message)
        {
            if (terminalLog.InvokeRequired) // 다른 스레드에서 호출될 경우
            {
                terminalLog.Invoke((Action)(() => Log(message)));
            }
            else
            {
                terminalLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
                terminalLog.ScrollToCaret();
            }

        }

        private void Form1_Fillter(object? sender, EventArgs e)
        {
            filterController.Items.Add("White Balance");
            filterController.Items.Add("Gaussian Filter");
            filterController.Items.Add("Median Filter");
            filterController.Items.Add("Unsharp Mask");

            // 체크 상태 변경 시 Presenter로 전달
            filterController.ItemCheck += (s, ev) =>
            {
                _presenter.OnFilterChanged(
                    filterController.Items[ev.Index].ToString(),
                    ev.NewValue == CheckState.Checked
                );
            };
        }

        //검사 결과를 ListBox에 추가 하는 메서드
        public void AddInspectionResultLine(string formattedLine)
        {
            if (inspectResultList.InvokeRequired)
            {
                inspectResultList.Invoke(new Action(() => AddInspectionResultLine(formattedLine)));
                return;
            }

            inspectResultList.Items.Add(formattedLine);
            // 최신 결과가 보이도록 자동 스크롤
            inspectResultList.TopIndex = inspectResultList.Items.Count - 1;

        }

        public void ClearInspectionList()
        {
            if (inspectResultList.InvokeRequired)
            {
                inspectResultList.Invoke(new Action(ClearInspectionList));
                return;
            }

            inspectResultList.Items.Clear();
        }

        /// Presenter의 지시에 따라 시작/중지 버튼의 텍스트를 변경하는 속성입니다.
        public string StartButtonText
        {
            get { return btnStartInspect.Text; }
            set { btnStartInspect.Text = value; }
        }

        /// Presenter의 요청에 따라 오류 메시지 박스를 띄웁니다.
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public int TotalCount
        {
            set
            {
                if (lblTotal.InvokeRequired)
                    lblTotal.Invoke(new Action(() => lblTotal.Text = $"총 검사: {value}"));
                else
                    lblTotal.Text = $"총 검사: {value}";
            }
        }

        public int PassCount
        {
            set
            {
                if (lblPass.InvokeRequired)
                    lblPass.Invoke(new Action(() => lblPass.Text = $"정상: {value}"));
                else
                    lblPass.Text = $"정상: {value}";
            }
        }

        public int FailCount
        {
            set
            {
                if (lblFail.InvokeRequired)
                    lblFail.Invoke(new Action(() => lblFail.Text = $"불량: {value}"));
                else
                    lblFail.Text = $"불량: {value}";
            }
        }
    }
}
