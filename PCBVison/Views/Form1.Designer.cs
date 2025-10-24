namespace PCBVison
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.uiLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.viwerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.imageViewer = new System.Windows.Forms.PictureBox();
            this.terminalLog = new System.Windows.Forms.RichTextBox();
            this.terminal = new System.Windows.Forms.Label();
            this.filterLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filterControllerBox = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.whiteBalnceGain = new System.Windows.Forms.GroupBox();
            this.wbTrackBar = new System.Windows.Forms.TrackBar();
            this.numWb = new System.Windows.Forms.NumericUpDown();
            this.lblWb = new System.Windows.Forms.Label();
            this.RedTrackBar = new System.Windows.Forms.TrackBar();
            this.numRed = new System.Windows.Forms.NumericUpDown();
            this.lblWhiteRed = new System.Windows.Forms.Label();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.numGreen = new System.Windows.Forms.NumericUpDown();
            this.lblWhiteGreen = new System.Windows.Forms.Label();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.numBlue = new System.Windows.Forms.NumericUpDown();
            this.lblWhiteBlue = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.inspectionBox = new System.Windows.Forms.GroupBox();
            this.lblNormal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnStartInspect = new System.Windows.Forms.Button();
            this.inspectionListBox = new System.Windows.Forms.GroupBox();
            this.headerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblDefect = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiLayoutPanel.SuspendLayout();
            this.viwerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            this.filterLayoutPanel.SuspendLayout();
            this.filterControllerBox.SuspendLayout();
            this.whiteBalnceGain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.inspectionBox.SuspendLayout();
            this.inspectionListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.uiLayoutPanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.headerLayoutPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555555F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.44444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1292, 793);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // uiLayoutPanel
            // 
            this.uiLayoutPanel.ColumnCount = 3;
            this.uiLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.60911F));
            this.uiLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.39089F));
            this.uiLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 217F));
            this.uiLayoutPanel.Controls.Add(this.viwerLayoutPanel, 0, 0);
            this.uiLayoutPanel.Controls.Add(this.filterLayoutPanel, 1, 0);
            this.uiLayoutPanel.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.uiLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiLayoutPanel.Location = new System.Drawing.Point(3, 47);
            this.uiLayoutPanel.Name = "uiLayoutPanel";
            this.uiLayoutPanel.RowCount = 1;
            this.uiLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.uiLayoutPanel.Size = new System.Drawing.Size(1286, 743);
            this.uiLayoutPanel.TabIndex = 0;
            // 
            // viwerLayoutPanel
            // 
            this.viwerLayoutPanel.ColumnCount = 1;
            this.viwerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.viwerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.viwerLayoutPanel.Controls.Add(this.imageViewer, 0, 0);
            this.viwerLayoutPanel.Controls.Add(this.terminalLog, 0, 2);
            this.viwerLayoutPanel.Controls.Add(this.terminal, 0, 1);
            this.viwerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viwerLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.viwerLayoutPanel.Name = "viwerLayoutPanel";
            this.viwerLayoutPanel.RowCount = 3;
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.7455F));
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.254498F));
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 245F));
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.viwerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.viwerLayoutPanel.Size = new System.Drawing.Size(823, 737);
            this.viwerLayoutPanel.TabIndex = 0;
            // 
            // imageViewer
            // 
            this.imageViewer.BackColor = System.Drawing.SystemColors.Desktop;
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(3, 3);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(817, 440);
            this.imageViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageViewer.TabIndex = 0;
            this.imageViewer.TabStop = false;
            // 
            // terminalLog
            // 
            this.terminalLog.BackColor = System.Drawing.SystemColors.WindowText;
            this.terminalLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.terminalLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalLog.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.terminalLog.ForeColor = System.Drawing.SystemColors.Window;
            this.terminalLog.Location = new System.Drawing.Point(3, 494);
            this.terminalLog.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.terminalLog.Name = "terminalLog";
            this.terminalLog.ReadOnly = true;
            this.terminalLog.Size = new System.Drawing.Size(817, 233);
            this.terminalLog.TabIndex = 1;
            this.terminalLog.Text = "";
            // 
            // terminal
            // 
            this.terminal.AutoSize = true;
            this.terminal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.terminal.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.terminal.Location = new System.Drawing.Point(3, 456);
            this.terminal.Margin = new System.Windows.Forms.Padding(3, 0, 0, 5);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(820, 30);
            this.terminal.TabIndex = 2;
            this.terminal.Text = "Terminal Log";
            // 
            // filterLayoutPanel
            // 
            this.filterLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.filterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.filterLayoutPanel.Controls.Add(this.filterControllerBox, 0, 0);
            this.filterLayoutPanel.Controls.Add(this.whiteBalnceGain, 0, 1);
            this.filterLayoutPanel.Location = new System.Drawing.Point(832, 3);
            this.filterLayoutPanel.Name = "filterLayoutPanel";
            this.filterLayoutPanel.RowCount = 2;
            this.filterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.56693F));
            this.filterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.43307F));
            this.filterLayoutPanel.Size = new System.Drawing.Size(233, 737);
            this.filterLayoutPanel.TabIndex = 1;
            // 
            // filterControllerBox
            // 
            this.filterControllerBox.Controls.Add(this.checkedListBox2);
            this.filterControllerBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.filterControllerBox.Location = new System.Drawing.Point(3, 3);
            this.filterControllerBox.Name = "filterControllerBox";
            this.filterControllerBox.Size = new System.Drawing.Size(231, 322);
            this.filterControllerBox.TabIndex = 0;
            this.filterControllerBox.TabStop = false;
            this.filterControllerBox.Text = "Filter Controller";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Items.AddRange(new object[] {
            "White Balance",
            "Gaussain Filter",
            "Median Filter"});
            this.checkedListBox2.Location = new System.Drawing.Point(3, 25);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(225, 294);
            this.checkedListBox2.TabIndex = 0;
            // 
            // whiteBalnceGain
            // 
            this.whiteBalnceGain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.whiteBalnceGain.Controls.Add(this.wbTrackBar);
            this.whiteBalnceGain.Controls.Add(this.numWb);
            this.whiteBalnceGain.Controls.Add(this.lblWb);
            this.whiteBalnceGain.Controls.Add(this.RedTrackBar);
            this.whiteBalnceGain.Controls.Add(this.numRed);
            this.whiteBalnceGain.Controls.Add(this.lblWhiteRed);
            this.whiteBalnceGain.Controls.Add(this.greenTrackBar);
            this.whiteBalnceGain.Controls.Add(this.numGreen);
            this.whiteBalnceGain.Controls.Add(this.lblWhiteGreen);
            this.whiteBalnceGain.Controls.Add(this.blueTrackBar);
            this.whiteBalnceGain.Controls.Add(this.numBlue);
            this.whiteBalnceGain.Controls.Add(this.lblWhiteBlue);
            this.whiteBalnceGain.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.whiteBalnceGain.Location = new System.Drawing.Point(3, 331);
            this.whiteBalnceGain.Name = "whiteBalnceGain";
            this.whiteBalnceGain.Size = new System.Drawing.Size(279, 403);
            this.whiteBalnceGain.TabIndex = 1;
            this.whiteBalnceGain.TabStop = false;
            this.whiteBalnceGain.Text = "White Balance Gain";
            // 
            // wbTrackBar
            // 
            this.wbTrackBar.Location = new System.Drawing.Point(18, 290);
            this.wbTrackBar.Name = "wbTrackBar";
            this.wbTrackBar.Size = new System.Drawing.Size(125, 45);
            this.wbTrackBar.TabIndex = 11;
            // 
            // numWb
            // 
            this.numWb.Location = new System.Drawing.Point(149, 290);
            this.numWb.Name = "numWb";
            this.numWb.Size = new System.Drawing.Size(69, 29);
            this.numWb.TabIndex = 10;
            // 
            // lblWb
            // 
            this.lblWb.AutoSize = true;
            this.lblWb.Location = new System.Drawing.Point(23, 268);
            this.lblWb.Name = "lblWb";
            this.lblWb.Size = new System.Drawing.Size(95, 19);
            this.lblWb.TabIndex = 9;
            this.lblWb.Text = "WB (wb_k)";
            // 
            // RedTrackBar
            // 
            this.RedTrackBar.Location = new System.Drawing.Point(17, 220);
            this.RedTrackBar.Name = "RedTrackBar";
            this.RedTrackBar.Size = new System.Drawing.Size(125, 45);
            this.RedTrackBar.TabIndex = 8;
            // 
            // numRed
            // 
            this.numRed.Location = new System.Drawing.Point(148, 220);
            this.numRed.Name = "numRed";
            this.numRed.Size = new System.Drawing.Size(69, 29);
            this.numRed.TabIndex = 7;
            // 
            // lblWhiteRed
            // 
            this.lblWhiteRed.AutoSize = true;
            this.lblWhiteRed.Location = new System.Drawing.Point(25, 198);
            this.lblWhiteRed.Name = "lblWhiteRed";
            this.lblWhiteRed.Size = new System.Drawing.Size(73, 19);
            this.lblWhiteRed.TabIndex = 6;
            this.lblWhiteRed.Text = "Red (kr)";
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(16, 149);
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(125, 45);
            this.greenTrackBar.TabIndex = 5;
            // 
            // numGreen
            // 
            this.numGreen.Location = new System.Drawing.Point(147, 149);
            this.numGreen.Name = "numGreen";
            this.numGreen.Size = new System.Drawing.Size(69, 29);
            this.numGreen.TabIndex = 4;
            // 
            // lblWhiteGreen
            // 
            this.lblWhiteGreen.AutoSize = true;
            this.lblWhiteGreen.Location = new System.Drawing.Point(21, 127);
            this.lblWhiteGreen.Name = "lblWhiteGreen";
            this.lblWhiteGreen.Size = new System.Drawing.Size(94, 19);
            this.lblWhiteGreen.TabIndex = 3;
            this.lblWhiteGreen.Text = "Green (kg)";
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(16, 72);
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(125, 45);
            this.blueTrackBar.TabIndex = 2;
            // 
            // numBlue
            // 
            this.numBlue.Location = new System.Drawing.Point(147, 72);
            this.numBlue.Name = "numBlue";
            this.numBlue.Size = new System.Drawing.Size(69, 29);
            this.numBlue.TabIndex = 1;
            // 
            // lblWhiteBlue
            // 
            this.lblWhiteBlue.AutoSize = true;
            this.lblWhiteBlue.Location = new System.Drawing.Point(21, 50);
            this.lblWhiteBlue.Name = "lblWhiteBlue";
            this.lblWhiteBlue.Size = new System.Drawing.Size(80, 19);
            this.lblWhiteBlue.TabIndex = 0;
            this.lblWhiteBlue.Text = "Blue (kb)";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.inspectionBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.inspectionListBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1071, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.64043F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.35957F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 737);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // inspectionBox
            // 
            this.inspectionBox.AutoSize = true;
            this.inspectionBox.Controls.Add(this.lblDefect);
            this.inspectionBox.Controls.Add(this.lblNormal);
            this.inspectionBox.Controls.Add(this.lblTotal);
            this.inspectionBox.Controls.Add(this.btnStartInspect);
            this.inspectionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectionBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.inspectionBox.Location = new System.Drawing.Point(3, 3);
            this.inspectionBox.Name = "inspectionBox";
            this.inspectionBox.Size = new System.Drawing.Size(206, 322);
            this.inspectionBox.TabIndex = 0;
            this.inspectionBox.TabStop = false;
            this.inspectionBox.Text = "검사율";
            // 
            // lblNormal
            // 
            this.lblNormal.AutoSize = true;
            this.lblNormal.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNormal.Location = new System.Drawing.Point(16, 114);
            this.lblNormal.Name = "lblNormal";
            this.lblNormal.Size = new System.Drawing.Size(59, 21);
            this.lblNormal.TabIndex = 2;
            this.lblNormal.Text = "정상:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotal.Location = new System.Drawing.Point(16, 75);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(108, 21);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "총 검사수:";
            // 
            // btnStartInspect
            // 
            this.btnStartInspect.Location = new System.Drawing.Point(28, 200);
            this.btnStartInspect.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.btnStartInspect.Name = "btnStartInspect";
            this.btnStartInspect.Size = new System.Drawing.Size(145, 51);
            this.btnStartInspect.TabIndex = 0;
            this.btnStartInspect.Text = "검사 시작";
            this.btnStartInspect.UseVisualStyleBackColor = true;
            // 
            // inspectionListBox
            // 
            this.inspectionListBox.Controls.Add(this.listBox1);
            this.inspectionListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectionListBox.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.inspectionListBox.Location = new System.Drawing.Point(3, 331);
            this.inspectionListBox.Name = "inspectionListBox";
            this.inspectionListBox.Size = new System.Drawing.Size(206, 403);
            this.inspectionListBox.TabIndex = 1;
            this.inspectionListBox.TabStop = false;
            this.inspectionListBox.Text = "검사 결과";
            // 
            // headerLayoutPanel
            // 
            this.headerLayoutPanel.ColumnCount = 2;
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.headerLayoutPanel.Name = "headerLayoutPanel";
            this.headerLayoutPanel.RowCount = 1;
            this.headerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayoutPanel.Size = new System.Drawing.Size(1286, 38);
            this.headerLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter Controller";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "White Balance",
            "Gaussian Filter",
            "Median Filter"});
            this.checkedListBox1.Location = new System.Drawing.Point(3, 40);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(280, 284);
            this.checkedListBox1.TabIndex = 1;
            // 
            // lblDefect
            // 
            this.lblDefect.AutoSize = true;
            this.lblDefect.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDefect.Location = new System.Drawing.Point(16, 155);
            this.lblDefect.Name = "lblDefect";
            this.lblDefect.Size = new System.Drawing.Size(59, 21);
            this.lblDefect.TabIndex = 3;
            this.lblDefect.Text = "불량:";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 19;
            this.listBox1.Location = new System.Drawing.Point(3, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 375);
            this.listBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 793);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.uiLayoutPanel.ResumeLayout(false);
            this.viwerLayoutPanel.ResumeLayout(false);
            this.viwerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).EndInit();
            this.filterLayoutPanel.ResumeLayout(false);
            this.filterControllerBox.ResumeLayout(false);
            this.whiteBalnceGain.ResumeLayout(false);
            this.whiteBalnceGain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wbTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBlue)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.inspectionBox.ResumeLayout(false);
            this.inspectionBox.PerformLayout();
            this.inspectionListBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel uiLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel viwerLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel filterLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel headerLayoutPanel;
        private System.Windows.Forms.PictureBox imageViewer;
        private System.Windows.Forms.Button btnStartInspect;
        private System.Windows.Forms.RichTextBox terminalLog;
        private System.Windows.Forms.Label terminal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox filterControllerBox;
        private System.Windows.Forms.GroupBox whiteBalnceGain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox inspectionBox;
        private System.Windows.Forms.GroupBox inspectionListBox;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TrackBar wbTrackBar;
        private System.Windows.Forms.NumericUpDown numWb;
        private System.Windows.Forms.Label lblWb;
        private System.Windows.Forms.TrackBar RedTrackBar;
        private System.Windows.Forms.NumericUpDown numRed;
        private System.Windows.Forms.Label lblWhiteRed;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.NumericUpDown numGreen;
        private System.Windows.Forms.Label lblWhiteGreen;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.NumericUpDown numBlue;
        private System.Windows.Forms.Label lblWhiteBlue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNormal;
        private System.Windows.Forms.Label lblDefect;
        private System.Windows.Forms.ListBox listBox1;
    }
}

