using System;
using System.Drawing;
using System.Windows.Forms;
using PCBVison.Presenters;
using PCBVison.Views;

namespace PCBVison
{
    /// UI를 담당하는 View (서빙 직원) 클래스입니다.
    /// IMainView 인터페이스(계약서)를 구현하며, 실제 로직은 모두 Presenter에게 위임합니다.
    public partial class Form1 : Form, IMainView
    {
        private readonly MainPresenter _presenter; // 실제 동작을 담당할 Presenter 객체

        // IMainView 인터페이스에 정의된 이벤트들을 선언합니다.
        // 이 이벤트들은 Presenter가 구독하게 됩니다.
        public event EventHandler StartStopClicked;
        // new 키워드를 추가하여 부모 클래스의 FormClosing 이벤트를 의도적으로 숨긴다는 것을 명시합니다.
        public new event FormClosingEventHandler FormClosing;

        public Form1()
        {
            InitializeComponent();


            // 1. 자신의 파트너인 MainPresenter를 생성합니다. 
            //    이때, this(Form1 자기 자신)를 넘겨주어 Presenter가 자신을 제어할 수 있도록 합니다.
            string onnxPath = @"C:\Users\subin\Documents\GitHub\pcb_vision\PCBVison\best.onnx";
            _presenter = new MainPresenter(this, onnxPath);

            // 2. UI 컨트롤(startbt)의 클릭 이벤트를 IMainView의 이벤트에 연결합니다.
            //    이제 startbt 버튼이 클릭되면, StartStopClicked 이벤트가 발생하여 Presenter에게 알려줍니다.
            this.btnStartInspect.Click += (sender, e) => StartStopClicked?.Invoke(sender, e);

            // 3. Form의 Closing 이벤트를 IMainView의 이벤트에 연결합니다.
            base.FormClosing += (sender, e) => FormClosing?.Invoke(sender, e);

            this.Load += Form1_Fillter;
        }

        /// <summary>
        /// Presenter가 전달해준 이미지를 화면에 표시하는 속성입니다.
        /// </summary>
        public Image ImageViewerImage
        {
            get { return imageViewer.Image; }
            set
            {
                // Presenter의 ProcessCamera 스레드가 이 속성을 직접 호출하므로,
                // UI 컨트롤을 안전하게 업데이트하기 위해 Invoke가 필요합니다.
                if (imageViewer.InvokeRequired)
                {
                    imageViewer.Invoke(new Action(() => {
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

        private void Form1_Fillter(object sender, EventArgs e)
        {
            filterController.Items.Add("White Balance");
            filterController.Items.Add("Gaussian Filter");
            filterController.Items.Add("Median Filter");

            // 체크 상태 변경 시 Presenter로 전달
            filterController.ItemCheck += (s, ev) =>
            {
                _presenter.OnFilterChanged(
                    filterController.Items[ev.Index].ToString(),
                    ev.NewValue == CheckState.Checked
                );
            };
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

    }
}
