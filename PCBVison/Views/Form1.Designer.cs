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
            this.inspectLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startbt = new System.Windows.Forms.Button();
            this.headerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.uiLayoutPanel.SuspendLayout();
            this.viwerLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageViewer)).BeginInit();
            this.inspectLayoutPanel.SuspendLayout();
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
            this.uiLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.uiLayoutPanel.Controls.Add(this.viwerLayoutPanel, 0, 0);
            this.uiLayoutPanel.Controls.Add(this.filterLayoutPanel, 1, 0);
            this.uiLayoutPanel.Controls.Add(this.inspectLayoutPanel, 2, 0);
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
            this.viwerLayoutPanel.Size = new System.Drawing.Size(829, 737);
            this.viwerLayoutPanel.TabIndex = 0;
            // 
            // imageViewer
            // 
            this.imageViewer.BackColor = System.Drawing.SystemColors.Desktop;
            this.imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer.Location = new System.Drawing.Point(3, 3);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(823, 440);
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
            this.terminalLog.Size = new System.Drawing.Size(823, 233);
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
            this.terminal.Size = new System.Drawing.Size(826, 30);
            this.terminal.TabIndex = 2;
            this.terminal.Text = "Terminal Log";
            // 
            // filterLayoutPanel
            // 
            this.filterLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 285F));
            this.filterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterLayoutPanel.Location = new System.Drawing.Point(838, 3);
            this.filterLayoutPanel.Name = "filterLayoutPanel";
            this.filterLayoutPanel.RowCount = 2;
            this.filterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.56693F));
            this.filterLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.43307F));
            this.filterLayoutPanel.Size = new System.Drawing.Size(235, 737);
            this.filterLayoutPanel.TabIndex = 1;
            // 
            // inspectLayoutPanel
            // 
            this.inspectLayoutPanel.ColumnCount = 1;
            this.inspectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inspectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.inspectLayoutPanel.Controls.Add(this.startbt, 0, 0);
            this.inspectLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inspectLayoutPanel.Location = new System.Drawing.Point(1079, 3);
            this.inspectLayoutPanel.Name = "inspectLayoutPanel";
            this.inspectLayoutPanel.RowCount = 2;
            this.inspectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.50475F));
            this.inspectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.49525F));
            this.inspectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.inspectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.inspectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.inspectLayoutPanel.Size = new System.Drawing.Size(204, 737);
            this.inspectLayoutPanel.TabIndex = 2;
            // 
            // startbt
            // 
            this.startbt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.startbt.Location = new System.Drawing.Point(20, 267);
            this.startbt.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.startbt.Name = "startbt";
            this.startbt.Size = new System.Drawing.Size(164, 51);
            this.startbt.TabIndex = 0;
            this.startbt.Text = "검사 시작";
            this.startbt.UseVisualStyleBackColor = true;
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
            this.inspectLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel uiLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel viwerLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel filterLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel inspectLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel headerLayoutPanel;
        private System.Windows.Forms.PictureBox imageViewer;
        private System.Windows.Forms.Button startbt;
        private System.Windows.Forms.RichTextBox terminalLog;
        private System.Windows.Forms.Label terminal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}

