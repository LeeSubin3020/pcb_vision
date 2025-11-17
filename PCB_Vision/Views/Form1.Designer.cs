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
            tableLayoutPanel1 = new TableLayoutPanel();
            uiLayoutPanel = new TableLayoutPanel();
            viwerLayoutPanel = new TableLayoutPanel();
            imageViewer = new PictureBox();
            terminalLog = new RichTextBox();
            terminal = new Label();
            filterLayoutPanel = new TableLayoutPanel();
            filterControllerBox = new GroupBox();
            filterController = new CheckedListBox();
            whiteBalnceGain = new GroupBox();
            wbTrackBar = new TrackBar();
            numWb = new NumericUpDown();
            lblWb = new Label();
            redTrackBar = new TrackBar();
            numRed = new NumericUpDown();
            lblWhiteRed = new Label();
            greenTrackBar = new TrackBar();
            numGreen = new NumericUpDown();
            lblWhiteGreen = new Label();
            blueTrackBar = new TrackBar();
            numBlue = new NumericUpDown();
            lblWhiteBlue = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            inspectionBox = new GroupBox();
            lblFail = new Label();
            lblPass = new Label();
            lblTotal = new Label();
            btnStartInspect = new Button();
            inspectionListBox = new GroupBox();
            listBox1 = new ListBox();
            headerLayoutPanel = new TableLayoutPanel();
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel1.SuspendLayout();
            uiLayoutPanel.SuspendLayout();
            viwerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageViewer).BeginInit();
            filterLayoutPanel.SuspendLayout();
            filterControllerBox.SuspendLayout();
            whiteBalnceGain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)wbTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)redTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)greenTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)blueTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numBlue).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            inspectionBox.SuspendLayout();
            inspectionListBox.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(uiLayoutPanel, 0, 1);
            tableLayoutPanel1.Controls.Add(headerLayoutPanel, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.555555F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.44444F));
            tableLayoutPanel1.Size = new Size(1292, 991);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // uiLayoutPanel
            // 
            uiLayoutPanel.ColumnCount = 3;
            uiLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.60911F));
            uiLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.39089F));
            uiLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 223F));
            uiLayoutPanel.Controls.Add(viwerLayoutPanel, 0, 0);
            uiLayoutPanel.Controls.Add(filterLayoutPanel, 1, 0);
            uiLayoutPanel.Controls.Add(tableLayoutPanel2, 2, 0);
            uiLayoutPanel.Dock = DockStyle.Fill;
            uiLayoutPanel.Location = new Point(3, 59);
            uiLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            uiLayoutPanel.Name = "uiLayoutPanel";
            uiLayoutPanel.RowCount = 1;
            uiLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            uiLayoutPanel.Size = new Size(1286, 928);
            uiLayoutPanel.TabIndex = 0;
            // 
            // viwerLayoutPanel
            // 
            viwerLayoutPanel.ColumnCount = 1;
            viwerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            viwerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            viwerLayoutPanel.Controls.Add(imageViewer, 0, 0);
            viwerLayoutPanel.Controls.Add(terminalLog, 0, 2);
            viwerLayoutPanel.Controls.Add(terminal, 0, 1);
            viwerLayoutPanel.Dock = DockStyle.Fill;
            viwerLayoutPanel.Location = new Point(3, 4);
            viwerLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            viwerLayoutPanel.Name = "viwerLayoutPanel";
            viwerLayoutPanel.RowCount = 3;
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 90.7455F));
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 9.254498F));
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 306F));
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            viwerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            viwerLayoutPanel.Size = new Size(818, 920);
            viwerLayoutPanel.TabIndex = 0;
            // 
            // imageViewer
            // 
            imageViewer.BackColor = SystemColors.Desktop;
            imageViewer.Dock = DockStyle.Fill;
            imageViewer.Location = new Point(3, 4);
            imageViewer.Margin = new Padding(3, 4, 3, 4);
            imageViewer.Name = "imageViewer";
            imageViewer.Size = new Size(812, 549);
            imageViewer.SizeMode = PictureBoxSizeMode.StretchImage;
            imageViewer.TabIndex = 0;
            imageViewer.TabStop = false;
            // 
            // terminalLog
            // 
            terminalLog.BackColor = SystemColors.WindowText;
            terminalLog.BorderStyle = BorderStyle.None;
            terminalLog.Dock = DockStyle.Fill;
            terminalLog.Font = new Font("굴림", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            terminalLog.ForeColor = SystemColors.Window;
            terminalLog.Location = new Point(3, 617);
            terminalLog.Margin = new Padding(3, 4, 3, 12);
            terminalLog.Name = "terminalLog";
            terminalLog.ReadOnly = true;
            terminalLog.Size = new Size(812, 291);
            terminalLog.TabIndex = 1;
            terminalLog.Text = "";
            // 
            // terminal
            // 
            terminal.AutoSize = true;
            terminal.Dock = DockStyle.Bottom;
            terminal.Font = new Font("맑은 고딕", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            terminal.Location = new Point(3, 577);
            terminal.Margin = new Padding(3, 0, 0, 6);
            terminal.Name = "terminal";
            terminal.Size = new Size(815, 30);
            terminal.TabIndex = 2;
            terminal.Text = "Terminal Log";
            // 
            // filterLayoutPanel
            // 
            filterLayoutPanel.Anchor = AnchorStyles.None;
            filterLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 285F));
            filterLayoutPanel.Controls.Add(filterControllerBox, 0, 0);
            filterLayoutPanel.Controls.Add(whiteBalnceGain, 0, 1);
            filterLayoutPanel.Location = new Point(827, 4);
            filterLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            filterLayoutPanel.Name = "filterLayoutPanel";
            filterLayoutPanel.RowCount = 2;
            filterLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 44.56693F));
            filterLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 55.43307F));
            filterLayoutPanel.Size = new Size(232, 920);
            filterLayoutPanel.TabIndex = 1;
            // 
            // filterControllerBox
            // 
            filterControllerBox.Controls.Add(filterController);
            filterControllerBox.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            filterControllerBox.Location = new Point(3, 4);
            filterControllerBox.Margin = new Padding(3, 4, 3, 4);
            filterControllerBox.Name = "filterControllerBox";
            filterControllerBox.Padding = new Padding(3, 4, 3, 4);
            filterControllerBox.Size = new Size(231, 402);
            filterControllerBox.TabIndex = 0;
            filterControllerBox.TabStop = false;
            filterControllerBox.Text = "Filter Controller";
            // 
            // filterController
            // 
            filterController.Dock = DockStyle.Fill;
            filterController.FormattingEnabled = true;
            filterController.Location = new Point(3, 26);
            filterController.Margin = new Padding(3, 4, 3, 4);
            filterController.Name = "filterController";
            filterController.Size = new Size(225, 372);
            filterController.TabIndex = 0;
            // 
            // whiteBalnceGain
            // 
            whiteBalnceGain.Anchor = AnchorStyles.None;
            whiteBalnceGain.Controls.Add(wbTrackBar);
            whiteBalnceGain.Controls.Add(numWb);
            whiteBalnceGain.Controls.Add(lblWb);
            whiteBalnceGain.Controls.Add(redTrackBar);
            whiteBalnceGain.Controls.Add(numRed);
            whiteBalnceGain.Controls.Add(lblWhiteRed);
            whiteBalnceGain.Controls.Add(greenTrackBar);
            whiteBalnceGain.Controls.Add(numGreen);
            whiteBalnceGain.Controls.Add(lblWhiteGreen);
            whiteBalnceGain.Controls.Add(blueTrackBar);
            whiteBalnceGain.Controls.Add(numBlue);
            whiteBalnceGain.Controls.Add(lblWhiteBlue);
            whiteBalnceGain.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            whiteBalnceGain.Location = new Point(3, 414);
            whiteBalnceGain.Margin = new Padding(3, 4, 3, 4);
            whiteBalnceGain.Name = "whiteBalnceGain";
            whiteBalnceGain.Padding = new Padding(3, 4, 3, 4);
            whiteBalnceGain.Size = new Size(279, 502);
            whiteBalnceGain.TabIndex = 1;
            whiteBalnceGain.TabStop = false;
            whiteBalnceGain.Text = "White Balance Gain";
            // 
            // wbTrackBar
            // 
            wbTrackBar.Location = new Point(17, 274);
            wbTrackBar.Margin = new Padding(3, 4, 3, 4);
            wbTrackBar.Name = "wbTrackBar";
            wbTrackBar.Size = new Size(125, 45);
            wbTrackBar.TabIndex = 11;
            // 
            // numWb
            // 
            numWb.Location = new Point(148, 274);
            numWb.Margin = new Padding(3, 4, 3, 4);
            numWb.Name = "numWb";
            numWb.Size = new Size(69, 29);
            numWb.TabIndex = 10;
            // 
            // lblWb
            // 
            lblWb.AutoSize = true;
            lblWb.Location = new Point(22, 247);
            lblWb.Name = "lblWb";
            lblWb.Size = new Size(95, 19);
            lblWb.TabIndex = 9;
            lblWb.Text = "WB (wb_k)";
            // 
            // redTrackBar
            // 
            redTrackBar.Location = new Point(16, 204);
            redTrackBar.Margin = new Padding(3, 4, 3, 4);
            redTrackBar.Name = "redTrackBar";
            redTrackBar.Size = new Size(125, 45);
            redTrackBar.TabIndex = 8;
            // 
            // numRed
            // 
            numRed.Location = new Point(147, 204);
            numRed.Margin = new Padding(3, 4, 3, 4);
            numRed.Name = "numRed";
            numRed.Size = new Size(69, 29);
            numRed.TabIndex = 7;
            // 
            // lblWhiteRed
            // 
            lblWhiteRed.AutoSize = true;
            lblWhiteRed.Location = new Point(27, 177);
            lblWhiteRed.Name = "lblWhiteRed";
            lblWhiteRed.Size = new Size(73, 19);
            lblWhiteRed.TabIndex = 6;
            lblWhiteRed.Text = "Red (kr)";
            // 
            // greenTrackBar
            // 
            greenTrackBar.Location = new Point(16, 134);
            greenTrackBar.Margin = new Padding(3, 4, 3, 4);
            greenTrackBar.Name = "greenTrackBar";
            greenTrackBar.Size = new Size(125, 45);
            greenTrackBar.TabIndex = 5;
            // 
            // numGreen
            // 
            numGreen.Location = new Point(147, 134);
            numGreen.Margin = new Padding(3, 4, 3, 4);
            numGreen.Name = "numGreen";
            numGreen.Size = new Size(69, 29);
            numGreen.TabIndex = 4;
            // 
            // lblWhiteGreen
            // 
            lblWhiteGreen.AutoSize = true;
            lblWhiteGreen.Location = new Point(21, 107);
            lblWhiteGreen.Name = "lblWhiteGreen";
            lblWhiteGreen.Size = new Size(94, 19);
            lblWhiteGreen.TabIndex = 3;
            lblWhiteGreen.Text = "Green (kg)";
            // 
            // blueTrackBar
            // 
            blueTrackBar.Location = new Point(16, 65);
            blueTrackBar.Margin = new Padding(3, 4, 3, 4);
            blueTrackBar.Name = "blueTrackBar";
            blueTrackBar.Size = new Size(125, 45);
            blueTrackBar.TabIndex = 2;
            // 
            // numBlue
            // 
            numBlue.Location = new Point(147, 65);
            numBlue.Margin = new Padding(3, 4, 3, 4);
            numBlue.Name = "numBlue";
            numBlue.Size = new Size(69, 29);
            numBlue.TabIndex = 1;
            // 
            // lblWhiteBlue
            // 
            lblWhiteBlue.AutoSize = true;
            lblWhiteBlue.Location = new Point(21, 37);
            lblWhiteBlue.Name = "lblWhiteBlue";
            lblWhiteBlue.Size = new Size(80, 19);
            lblWhiteBlue.TabIndex = 0;
            lblWhiteBlue.Text = "Blue (kb)";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(inspectionBox, 0, 0);
            tableLayoutPanel2.Controls.Add(inspectionListBox, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(1065, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 44.64043F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 55.35957F));
            tableLayoutPanel2.Size = new Size(218, 920);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // inspectionBox
            // 
            inspectionBox.AutoSize = true;
            inspectionBox.Controls.Add(lblFail);
            inspectionBox.Controls.Add(lblPass);
            inspectionBox.Controls.Add(lblTotal);
            inspectionBox.Controls.Add(btnStartInspect);
            inspectionBox.Dock = DockStyle.Fill;
            inspectionBox.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            inspectionBox.Location = new Point(3, 4);
            inspectionBox.Margin = new Padding(3, 4, 3, 4);
            inspectionBox.Name = "inspectionBox";
            inspectionBox.Padding = new Padding(3, 4, 3, 4);
            inspectionBox.Size = new Size(212, 402);
            inspectionBox.TabIndex = 0;
            inspectionBox.TabStop = false;
            inspectionBox.Text = "검사율";
            // 
            // lblFail
            // 
            lblFail.AutoSize = true;
            lblFail.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblFail.Location = new Point(16, 194);
            lblFail.Name = "lblFail";
            lblFail.Size = new Size(59, 21);
            lblFail.TabIndex = 3;
            lblFail.Text = "불량:";
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblPass.Location = new Point(16, 142);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(59, 21);
            lblPass.TabIndex = 2;
            lblPass.Text = "정상:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("굴림", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lblTotal.Location = new Point(16, 94);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(108, 21);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "총 검사수:";
            // 
            // btnStartInspect
            // 
            btnStartInspect.Location = new Point(28, 250);
            btnStartInspect.Margin = new Padding(30, 12, 30, 12);
            btnStartInspect.Name = "btnStartInspect";
            btnStartInspect.Size = new Size(145, 64);
            btnStartInspect.TabIndex = 0;
            btnStartInspect.Text = "검사 시작";
            btnStartInspect.UseVisualStyleBackColor = true;
            // 
            // inspectionListBox
            // 
            inspectionListBox.Controls.Add(listBox1);
            inspectionListBox.Dock = DockStyle.Fill;
            inspectionListBox.Font = new Font("굴림", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            inspectionListBox.Location = new Point(3, 414);
            inspectionListBox.Margin = new Padding(3, 4, 3, 4);
            inspectionListBox.Name = "inspectionListBox";
            inspectionListBox.Padding = new Padding(3, 4, 3, 4);
            inspectionListBox.Size = new Size(212, 502);
            inspectionListBox.TabIndex = 1;
            inspectionListBox.TabStop = false;
            inspectionListBox.Text = "검사 결과";
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Fill;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 19;
            listBox1.Location = new Point(3, 26);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(206, 472);
            listBox1.TabIndex = 0;
            // 
            // headerLayoutPanel
            // 
            headerLayoutPanel.ColumnCount = 2;
            headerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            headerLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            headerLayoutPanel.Dock = DockStyle.Fill;
            headerLayoutPanel.Location = new Point(3, 4);
            headerLayoutPanel.Margin = new Padding(3, 4, 3, 4);
            headerLayoutPanel.Name = "headerLayoutPanel";
            headerLayoutPanel.RowCount = 1;
            headerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            headerLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            headerLayoutPanel.Size = new Size(1286, 47);
            headerLayoutPanel.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDark;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("맑은 고딕", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(280, 37);
            label1.TabIndex = 0;
            label1.Text = "Filter Controller";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkedListBox1
            // 
            checkedListBox1.Dock = DockStyle.Fill;
            checkedListBox1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 129);
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "White Balance", "Gaussian Filter", "Median Filter" });
            checkedListBox1.Location = new Point(3, 40);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(280, 284);
            checkedListBox1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1292, 991);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            uiLayoutPanel.ResumeLayout(false);
            viwerLayoutPanel.ResumeLayout(false);
            viwerLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageViewer).EndInit();
            filterLayoutPanel.ResumeLayout(false);
            filterControllerBox.ResumeLayout(false);
            whiteBalnceGain.ResumeLayout(false);
            whiteBalnceGain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)wbTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWb).EndInit();
            ((System.ComponentModel.ISupportInitialize)redTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRed).EndInit();
            ((System.ComponentModel.ISupportInitialize)greenTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)blueTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)numBlue).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            inspectionBox.ResumeLayout(false);
            inspectionBox.PerformLayout();
            inspectionListBox.ResumeLayout(false);
            ResumeLayout(false);

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
        private System.Windows.Forms.CheckedListBox filterController;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TrackBar wbTrackBar;
        private System.Windows.Forms.NumericUpDown numWb;
        private System.Windows.Forms.Label lblWb;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.NumericUpDown numRed;
        private System.Windows.Forms.Label lblWhiteRed;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.NumericUpDown numGreen;
        private System.Windows.Forms.Label lblWhiteGreen;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.NumericUpDown numBlue;
        private System.Windows.Forms.Label lblWhiteBlue;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblFail;
        private System.Windows.Forms.ListBox listBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

