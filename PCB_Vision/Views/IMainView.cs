using System;
using System.Drawing;
using System.Windows.Forms;

namespace PCBVison.Views
{
    /// View(Form1)와 Presenter(MainPresenter) 사이의 통신 규칙을 정의하는 '계약서'입니다.
    /// Presenter는 이 인터페이스에 정의된 멤버들만 보고 View를 제어할 수 있습니다.
    /// 이를 통해 Presenter는 Form1이라는 특정 기술에 종속되지 않게 됩니다.
    public interface IMainView
    {
        // --- View에서 발생하는 이벤트를 Presenter에 알리기 위한 멤버 ---

        /// 시작/중지 버튼이 클릭될 때 발생하는 이벤트입니다.
        /// View(Form1)는 버튼이 눌리면 이 이벤트를 발생시키고, Presenter(MainPresenter)는 이 이벤트를 구독하여 실제 동작을 수행합니다.
        event EventHandler? StartStopClicked;

        /// Form이 닫힐 때 발생하는 이벤트입니다.
        /// 리소스 해제 등 마무리 작업을 위해 Presenter에게 알려주는 역할을 합니다.
        event FormClosingEventHandler? FormClosing;


        // --- Presenter가 View의 상태를 제어(읽거나 변경)하기 위한 멤버 ---

        /// 카메라 영상을 표시하는 이미지 뷰어(PictureBox)를 제어하기 위한 속성입니다.
        /// Presenter가 이 속성에 새로운 이미지(Bitmap)를 전달하면, View는 화면을 갱신해야 합니다.
        Image ImageViewerImage { get; set; }

        /// 시작/중지 버튼의 텍스트(예: "검사 시작", "검사 중지")를 제어하기 위한 속성입니다.
        string StartButtonText { get; set; }


        /// 사용자에게 오류 메시지를 표시하기 위한 메서드입니다.
        /// Presenter에서 에러가 발생했을 때, 이 메서드를 호출하여 View에게 메시지 박스를 띄우도록 지시합니다.
        /// <param name="message">표시할 오류 메시지</param>
        void ShowError(string message);
        void Log(string message);

        // White Balnce Gain 속성 값
        double BlueGain { get; }
        double GreenGain { get; }
        double RedGain { get; }
        double WbGain { get; }

        // 검사율
        int TotalCount { set; }
        int PassCount { set; }
        int FailCount { set; }

    }

}



