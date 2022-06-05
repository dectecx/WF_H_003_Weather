namespace WF_H_003_Weather
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.StartDtp = new System.Windows.Forms.DateTimePicker();
            this.EndDtp = new System.Windows.Forms.DateTimePicker();
            this.QueryBtn = new System.Windows.Forms.Button();
            this.ResultGv = new System.Windows.Forms.DataGridView();
            this.DtpLbl = new System.Windows.Forms.Label();
            this.Lbl = new System.Windows.Forms.Label();
            this.ObservatoryLbl = new System.Windows.Forms.Label();
            this.LocationCb = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.QueryTypeCb = new System.Windows.Forms.ComboBox();
            this.ModeGp = new System.Windows.Forms.GroupBox();
            this.ModeOrigRb = new System.Windows.Forms.RadioButton();
            this.ModeSlimRb = new System.Windows.Forms.RadioButton();
            this.StartCb = new System.Windows.Forms.ComboBox();
            this.EndCb = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGv)).BeginInit();
            this.ModeGp.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDtp
            // 
            this.StartDtp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartDtp.Location = new System.Drawing.Point(71, 3);
            this.StartDtp.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.StartDtp.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.StartDtp.Name = "StartDtp";
            this.StartDtp.Size = new System.Drawing.Size(200, 29);
            this.StartDtp.TabIndex = 0;
            // 
            // EndDtp
            // 
            this.EndDtp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EndDtp.Location = new System.Drawing.Point(304, 3);
            this.EndDtp.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.EndDtp.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.EndDtp.Name = "EndDtp";
            this.EndDtp.Size = new System.Drawing.Size(200, 29);
            this.EndDtp.TabIndex = 1;
            // 
            // QueryBtn
            // 
            this.QueryBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryBtn.Location = new System.Drawing.Point(712, 2);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(177, 68);
            this.QueryBtn.TabIndex = 2;
            this.QueryBtn.Text = "查詢";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // ResultGv
            // 
            this.ResultGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGv.Location = new System.Drawing.Point(12, 110);
            this.ResultGv.Name = "ResultGv";
            this.ResultGv.RowTemplate.Height = 24;
            this.ResultGv.Size = new System.Drawing.Size(1060, 439);
            this.ResultGv.TabIndex = 3;
            // 
            // DtpLbl
            // 
            this.DtpLbl.AutoSize = true;
            this.DtpLbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DtpLbl.Location = new System.Drawing.Point(24, 9);
            this.DtpLbl.Name = "DtpLbl";
            this.DtpLbl.Size = new System.Drawing.Size(41, 20);
            this.DtpLbl.TabIndex = 4;
            this.DtpLbl.Text = "起訖";
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Lbl.Location = new System.Drawing.Point(277, 9);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(21, 20);
            this.Lbl.TabIndex = 5;
            this.Lbl.Text = "~";
            // 
            // ObservatoryLbl
            // 
            this.ObservatoryLbl.AutoSize = true;
            this.ObservatoryLbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ObservatoryLbl.Location = new System.Drawing.Point(8, 42);
            this.ObservatoryLbl.Name = "ObservatoryLbl";
            this.ObservatoryLbl.Size = new System.Drawing.Size(57, 20);
            this.ObservatoryLbl.TabIndex = 6;
            this.ObservatoryLbl.Text = "觀測站";
            // 
            // LocationCb
            // 
            this.LocationCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LocationCb.FormattingEnabled = true;
            this.LocationCb.Location = new System.Drawing.Point(71, 42);
            this.LocationCb.Name = "LocationCb";
            this.LocationCb.Size = new System.Drawing.Size(200, 28);
            this.LocationCb.TabIndex = 7;
            this.LocationCb.Text = "請選擇觀測站";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ClearBtn.Location = new System.Drawing.Point(895, 2);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(177, 68);
            this.ClearBtn.TabIndex = 8;
            this.ClearBtn.Text = "清除";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // QueryTypeCb
            // 
            this.QueryTypeCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryTypeCb.FormattingEnabled = true;
            this.QueryTypeCb.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.QueryTypeCb.Location = new System.Drawing.Point(304, 42);
            this.QueryTypeCb.Name = "QueryTypeCb";
            this.QueryTypeCb.Size = new System.Drawing.Size(200, 28);
            this.QueryTypeCb.TabIndex = 9;
            this.QueryTypeCb.Text = "請選擇查詢種類";
            this.QueryTypeCb.SelectedIndexChanged += new System.EventHandler(this.QueryTypeCb_SelectedIndexChanged);
            // 
            // ModeGp
            // 
            this.ModeGp.Controls.Add(this.ModeOrigRb);
            this.ModeGp.Controls.Add(this.ModeSlimRb);
            this.ModeGp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ModeGp.Location = new System.Drawing.Point(576, 3);
            this.ModeGp.Name = "ModeGp";
            this.ModeGp.Size = new System.Drawing.Size(130, 67);
            this.ModeGp.TabIndex = 10;
            this.ModeGp.TabStop = false;
            this.ModeGp.Text = "模式";
            // 
            // ModeOrigRb
            // 
            this.ModeOrigRb.AutoSize = true;
            this.ModeOrigRb.Location = new System.Drawing.Point(6, 37);
            this.ModeOrigRb.Name = "ModeOrigRb";
            this.ModeOrigRb.Size = new System.Drawing.Size(123, 24);
            this.ModeOrigRb.TabIndex = 1;
            this.ModeOrigRb.Text = "原始完整資料";
            this.ModeOrigRb.UseVisualStyleBackColor = true;
            // 
            // ModeSlimRb
            // 
            this.ModeSlimRb.AutoSize = true;
            this.ModeSlimRb.Checked = true;
            this.ModeSlimRb.Location = new System.Drawing.Point(6, 16);
            this.ModeSlimRb.Name = "ModeSlimRb";
            this.ModeSlimRb.Size = new System.Drawing.Size(107, 24);
            this.ModeSlimRb.TabIndex = 0;
            this.ModeSlimRb.TabStop = true;
            this.ModeSlimRb.Text = "刪減過資料";
            this.ModeSlimRb.UseVisualStyleBackColor = true;
            // 
            // StartCb
            // 
            this.StartCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartCb.FormattingEnabled = true;
            this.StartCb.Location = new System.Drawing.Point(71, 4);
            this.StartCb.Name = "StartCb";
            this.StartCb.Size = new System.Drawing.Size(200, 28);
            this.StartCb.TabIndex = 11;
            this.StartCb.Text = "請選擇起始時間";
            // 
            // EndCb
            // 
            this.EndCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EndCb.FormattingEnabled = true;
            this.EndCb.Location = new System.Drawing.Point(304, 4);
            this.EndCb.Name = "EndCb";
            this.EndCb.Size = new System.Drawing.Size(200, 28);
            this.EndCb.TabIndex = 12;
            this.EndCb.Text = "請選擇結束時間";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.EndCb);
            this.Controls.Add(this.StartCb);
            this.Controls.Add(this.ModeGp);
            this.Controls.Add(this.QueryTypeCb);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.LocationCb);
            this.Controls.Add(this.ObservatoryLbl);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.DtpLbl);
            this.Controls.Add(this.ResultGv);
            this.Controls.Add(this.QueryBtn);
            this.Controls.Add(this.EndDtp);
            this.Controls.Add(this.StartDtp);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ResultGv)).EndInit();
            this.ModeGp.ResumeLayout(false);
            this.ModeGp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDtp;
        private System.Windows.Forms.DateTimePicker EndDtp;
        private System.Windows.Forms.Button QueryBtn;
        private System.Windows.Forms.DataGridView ResultGv;
        private System.Windows.Forms.Label DtpLbl;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Label ObservatoryLbl;
        private System.Windows.Forms.ComboBox LocationCb;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ComboBox QueryTypeCb;
        private System.Windows.Forms.GroupBox ModeGp;
        private System.Windows.Forms.RadioButton ModeOrigRb;
        private System.Windows.Forms.RadioButton ModeSlimRb;
        private System.Windows.Forms.ComboBox StartCb;
        private System.Windows.Forms.ComboBox EndCb;
    }
}

