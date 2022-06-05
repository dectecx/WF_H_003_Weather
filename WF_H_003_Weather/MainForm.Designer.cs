namespace WF_H_003_Weather
{
    partial class MainForm
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
            this.SELbl = new System.Windows.Forms.Label();
            this.DtpLbl = new System.Windows.Forms.Label();
            this.ObservatoryLbl = new System.Windows.Forms.Label();
            this.LocationCb = new System.Windows.Forms.ComboBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.QueryTypeCb = new System.Windows.Forms.ComboBox();
            this.ModeGp = new System.Windows.Forms.GroupBox();
            this.ModeOrigRb = new System.Windows.Forms.RadioButton();
            this.ModeSlimRb = new System.Windows.Forms.RadioButton();
            this.StartCb = new System.Windows.Forms.ComboBox();
            this.EndCb = new System.Windows.Forms.ComboBox();
            this.CbLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResultGv)).BeginInit();
            this.ModeGp.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartDtp
            // 
            this.StartDtp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartDtp.Location = new System.Drawing.Point(71, 44);
            this.StartDtp.MaxDate = new System.DateTime(2022, 6, 4, 0, 0, 0, 0);
            this.StartDtp.MinDate = new System.DateTime(2022, 5, 5, 0, 0, 0, 0);
            this.StartDtp.Name = "StartDtp";
            this.StartDtp.Size = new System.Drawing.Size(200, 29);
            this.StartDtp.TabIndex = 0;
            this.StartDtp.Value = new System.DateTime(2022, 5, 5, 0, 0, 0, 0);
            // 
            // EndDtp
            // 
            this.EndDtp.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EndDtp.Location = new System.Drawing.Point(304, 44);
            this.EndDtp.MaxDate = new System.DateTime(2022, 6, 4, 0, 0, 0, 0);
            this.EndDtp.MinDate = new System.DateTime(2022, 5, 5, 0, 0, 0, 0);
            this.EndDtp.Name = "EndDtp";
            this.EndDtp.Size = new System.Drawing.Size(200, 29);
            this.EndDtp.TabIndex = 1;
            this.EndDtp.Value = new System.DateTime(2022, 6, 4, 0, 0, 0, 0);
            // 
            // QueryBtn
            // 
            this.QueryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QueryBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryBtn.Location = new System.Drawing.Point(683, 23);
            this.QueryBtn.Name = "QueryBtn";
            this.QueryBtn.Size = new System.Drawing.Size(177, 68);
            this.QueryBtn.TabIndex = 2;
            this.QueryBtn.Text = "查詢";
            this.QueryBtn.UseVisualStyleBackColor = true;
            this.QueryBtn.Click += new System.EventHandler(this.QueryBtn_Click);
            // 
            // ResultGv
            // 
            this.ResultGv.AllowUserToAddRows = false;
            this.ResultGv.AllowUserToDeleteRows = false;
            this.ResultGv.AllowUserToOrderColumns = true;
            this.ResultGv.BackgroundColor = System.Drawing.Color.SlateGray;
            this.ResultGv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultGv.Location = new System.Drawing.Point(12, 113);
            this.ResultGv.Name = "ResultGv";
            this.ResultGv.RowTemplate.Height = 24;
            this.ResultGv.Size = new System.Drawing.Size(1060, 436);
            this.ResultGv.TabIndex = 3;
            // 
            // SELbl
            // 
            this.SELbl.AutoSize = true;
            this.SELbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SELbl.Location = new System.Drawing.Point(24, 50);
            this.SELbl.Name = "SELbl";
            this.SELbl.Size = new System.Drawing.Size(41, 20);
            this.SELbl.TabIndex = 4;
            this.SELbl.Text = "起訖";
            // 
            // DtpLbl
            // 
            this.DtpLbl.AutoSize = true;
            this.DtpLbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.DtpLbl.Location = new System.Drawing.Point(277, 50);
            this.DtpLbl.Name = "DtpLbl";
            this.DtpLbl.Size = new System.Drawing.Size(21, 20);
            this.DtpLbl.TabIndex = 5;
            this.DtpLbl.Text = "~";
            // 
            // ObservatoryLbl
            // 
            this.ObservatoryLbl.AutoSize = true;
            this.ObservatoryLbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ObservatoryLbl.Location = new System.Drawing.Point(8, 12);
            this.ObservatoryLbl.Name = "ObservatoryLbl";
            this.ObservatoryLbl.Size = new System.Drawing.Size(57, 20);
            this.ObservatoryLbl.TabIndex = 6;
            this.ObservatoryLbl.Text = "觀測站";
            // 
            // LocationCb
            // 
            this.LocationCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LocationCb.FormattingEnabled = true;
            this.LocationCb.Location = new System.Drawing.Point(71, 9);
            this.LocationCb.Name = "LocationCb";
            this.LocationCb.Size = new System.Drawing.Size(200, 28);
            this.LocationCb.TabIndex = 7;
            this.LocationCb.Text = "請選擇觀測站";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearBtn.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ClearBtn.Location = new System.Drawing.Point(866, 23);
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
            this.QueryTypeCb.Location = new System.Drawing.Point(304, 9);
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
            this.ModeGp.Location = new System.Drawing.Point(535, 23);
            this.ModeGp.Name = "ModeGp";
            this.ModeGp.Size = new System.Drawing.Size(130, 67);
            this.ModeGp.TabIndex = 10;
            this.ModeGp.TabStop = false;
            this.ModeGp.Text = "資料模式";
            // 
            // ModeOrigRb
            // 
            this.ModeOrigRb.AutoSize = true;
            this.ModeOrigRb.Checked = true;
            this.ModeOrigRb.Location = new System.Drawing.Point(6, 42);
            this.ModeOrigRb.Name = "ModeOrigRb";
            this.ModeOrigRb.Size = new System.Drawing.Size(123, 24);
            this.ModeOrigRb.TabIndex = 1;
            this.ModeOrigRb.TabStop = true;
            this.ModeOrigRb.Text = "原始完整資料";
            this.ModeOrigRb.UseVisualStyleBackColor = true;
            this.ModeOrigRb.CheckedChanged += new System.EventHandler(this.ModeOrigRb_CheckedChanged);
            // 
            // ModeSlimRb
            // 
            this.ModeSlimRb.AutoSize = true;
            this.ModeSlimRb.Location = new System.Drawing.Point(6, 21);
            this.ModeSlimRb.Name = "ModeSlimRb";
            this.ModeSlimRb.Size = new System.Drawing.Size(107, 24);
            this.ModeSlimRb.TabIndex = 0;
            this.ModeSlimRb.Text = "刪減過資料";
            this.ModeSlimRb.UseVisualStyleBackColor = true;
            this.ModeSlimRb.CheckedChanged += new System.EventHandler(this.ModeSlimRb_CheckedChanged);
            // 
            // StartCb
            // 
            this.StartCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.StartCb.FormattingEnabled = true;
            this.StartCb.Location = new System.Drawing.Point(71, 79);
            this.StartCb.Name = "StartCb";
            this.StartCb.Size = new System.Drawing.Size(200, 28);
            this.StartCb.TabIndex = 11;
            this.StartCb.Text = "請選擇起始時間";
            // 
            // EndCb
            // 
            this.EndCb.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EndCb.FormattingEnabled = true;
            this.EndCb.Location = new System.Drawing.Point(304, 79);
            this.EndCb.Name = "EndCb";
            this.EndCb.Size = new System.Drawing.Size(200, 28);
            this.EndCb.TabIndex = 12;
            this.EndCb.Text = "請選擇結束時間";
            // 
            // CbLbl
            // 
            this.CbLbl.AutoSize = true;
            this.CbLbl.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CbLbl.Location = new System.Drawing.Point(277, 82);
            this.CbLbl.Name = "CbLbl";
            this.CbLbl.Size = new System.Drawing.Size(21, 20);
            this.CbLbl.TabIndex = 13;
            this.CbLbl.Text = "~";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1084, 561);
            this.Controls.Add(this.CbLbl);
            this.Controls.Add(this.EndCb);
            this.Controls.Add(this.StartCb);
            this.Controls.Add(this.ModeGp);
            this.Controls.Add(this.QueryTypeCb);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.LocationCb);
            this.Controls.Add(this.ObservatoryLbl);
            this.Controls.Add(this.DtpLbl);
            this.Controls.Add(this.SELbl);
            this.Controls.Add(this.ResultGv);
            this.Controls.Add(this.QueryBtn);
            this.Controls.Add(this.EndDtp);
            this.Controls.Add(this.StartDtp);
            this.Name = "MainForm";
            this.Text = "30天觀測資料-局屬地面測站觀測資料模型";
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
        private System.Windows.Forms.Label SELbl;
        private System.Windows.Forms.Label DtpLbl;
        private System.Windows.Forms.Label ObservatoryLbl;
        private System.Windows.Forms.ComboBox LocationCb;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.ComboBox QueryTypeCb;
        private System.Windows.Forms.GroupBox ModeGp;
        private System.Windows.Forms.RadioButton ModeOrigRb;
        private System.Windows.Forms.RadioButton ModeSlimRb;
        private System.Windows.Forms.ComboBox StartCb;
        private System.Windows.Forms.ComboBox EndCb;
        private System.Windows.Forms.Label CbLbl;
    }
}

