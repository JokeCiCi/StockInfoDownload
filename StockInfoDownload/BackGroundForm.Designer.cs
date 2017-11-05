namespace StockInfoDownload
{
    partial class BackGroundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bk_GetStockInfoSZ = new System.ComponentModel.BackgroundWorker();
            this.SZSum = new System.Windows.Forms.Label();
            this.DownStockInfo = new System.Windows.Forms.Button();
            this.bk_GetStockInfoSH = new System.ComponentModel.BackgroundWorker();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBarSZ = new System.Windows.Forms.ProgressBar();
            this.progressBarSH = new System.Windows.Forms.ProgressBar();
            this.SHSum = new System.Windows.Forms.Label();
            this.DownStock5MinInfo = new System.Windows.Forms.Button();
            this.bk_GetStock5MinInfoSZ = new System.ComponentModel.BackgroundWorker();
            this.Get5MinTimer = new System.Windows.Forms.Timer(this.components);
            this.bk_GetStock5MinInfoSH = new System.ComponentModel.BackgroundWorker();
            this.bk_FinanceInfo = new System.ComponentModel.BackgroundWorker();
            this.DownFinanceInfo = new System.Windows.Forms.Button();
            this.lblFinance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bk_GetStockInfoSZ
            // 
            this.bk_GetStockInfoSZ.WorkerReportsProgress = true;
            this.bk_GetStockInfoSZ.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetStockMinInfoSZ_DoWork);
            this.bk_GetStockInfoSZ.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bk_GetStockMinInfoSZ_ProgressChanged);
            // 
            // SZSum
            // 
            this.SZSum.AutoSize = true;
            this.SZSum.Location = new System.Drawing.Point(12, 38);
            this.SZSum.Name = "SZSum";
            this.SZSum.Size = new System.Drawing.Size(23, 12);
            this.SZSum.TabIndex = 2;
            this.SZSum.Text = "SZ:";
            // 
            // DownStockInfo
            // 
            this.DownStockInfo.Location = new System.Drawing.Point(12, 128);
            this.DownStockInfo.Name = "DownStockInfo";
            this.DownStockInfo.Size = new System.Drawing.Size(75, 23);
            this.DownStockInfo.TabIndex = 3;
            this.DownStockInfo.Text = "导入市场内所有股票信息";
            this.DownStockInfo.UseVisualStyleBackColor = true;
            this.DownStockInfo.Click += new System.EventHandler(this.button2_Click);
            // 
            // bk_GetStockInfoSH
            // 
            this.bk_GetStockInfoSH.WorkerReportsProgress = true;
            this.bk_GetStockInfoSH.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_GetStockMinInfoSH_DoWork);
            this.bk_GetStockInfoSH.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bk_GetStockMinInfoSH_ProgressChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "关闭连接";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // progressBarSZ
            // 
            this.progressBarSZ.Location = new System.Drawing.Point(12, 56);
            this.progressBarSZ.Name = "progressBarSZ";
            this.progressBarSZ.Size = new System.Drawing.Size(260, 23);
            this.progressBarSZ.TabIndex = 6;
            // 
            // progressBarSH
            // 
            this.progressBarSH.Location = new System.Drawing.Point(12, 97);
            this.progressBarSH.Name = "progressBarSH";
            this.progressBarSH.Size = new System.Drawing.Size(260, 23);
            this.progressBarSH.TabIndex = 7;
            // 
            // SHSum
            // 
            this.SHSum.AutoSize = true;
            this.SHSum.Location = new System.Drawing.Point(12, 82);
            this.SHSum.Name = "SHSum";
            this.SHSum.Size = new System.Drawing.Size(23, 12);
            this.SHSum.TabIndex = 8;
            this.SHSum.Text = "SH:";
            // 
            // DownStock5MinInfo
            // 
            this.DownStock5MinInfo.Location = new System.Drawing.Point(90, 12);
            this.DownStock5MinInfo.Name = "DownStock5MinInfo";
            this.DownStock5MinInfo.Size = new System.Drawing.Size(75, 23);
            this.DownStock5MinInfo.TabIndex = 9;
            this.DownStock5MinInfo.Text = "下载5分钟数据";
            this.DownStock5MinInfo.UseVisualStyleBackColor = true;
            this.DownStock5MinInfo.Click += new System.EventHandler(this.DownStock5MinInfo_Click);
            // 
            // bk_GetStock5MinInfoSZ
            // 
            this.bk_GetStock5MinInfoSZ.WorkerReportsProgress = true;
            this.bk_GetStock5MinInfoSZ.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_GetStock5MinInfoSZ_DoWork);
            this.bk_GetStock5MinInfoSZ.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bk_GetStock5MinInfoSZ_ProgressChanged);
            // 
            // Get5MinTimer
            // 
            this.Get5MinTimer.Interval = 300000;
            this.Get5MinTimer.Tick += new System.EventHandler(this.Get5MinTimer_Tick);
            // 
            // bk_GetStock5MinInfoSH
            // 
            this.bk_GetStock5MinInfoSH.WorkerReportsProgress = true;
            this.bk_GetStock5MinInfoSH.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_GetStock5MinInfoSH_DoWork);
            this.bk_GetStock5MinInfoSH.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bk_GetStock5MinInfoSH_ProgressChanged);
            // 
            // bk_FinanceInfo
            // 
            this.bk_FinanceInfo.WorkerReportsProgress = true;
            this.bk_FinanceInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bk_FinanceInfo_DoWork);
            this.bk_FinanceInfo.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bk_FinanceInfo_ProgressChanged);
            // 
            // DownFinanceInfo
            // 
            this.DownFinanceInfo.Location = new System.Drawing.Point(12, 157);
            this.DownFinanceInfo.Name = "DownFinanceInfo";
            this.DownFinanceInfo.Size = new System.Drawing.Size(75, 23);
            this.DownFinanceInfo.TabIndex = 10;
            this.DownFinanceInfo.Text = "下载财务数据";
            this.DownFinanceInfo.UseVisualStyleBackColor = true;
            this.DownFinanceInfo.Click += new System.EventHandler(this.DownFinanceInfo_Click);
            // 
            // lblFinance
            // 
            this.lblFinance.AutoSize = true;
            this.lblFinance.Location = new System.Drawing.Point(12, 194);
            this.lblFinance.Name = "lblFinance";
            this.lblFinance.Size = new System.Drawing.Size(41, 12);
            this.lblFinance.TabIndex = 11;
            this.lblFinance.Text = "label1";
            // 
            // BackGroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblFinance);
            this.Controls.Add(this.DownFinanceInfo);
            this.Controls.Add(this.DownStock5MinInfo);
            this.Controls.Add(this.SHSum);
            this.Controls.Add(this.progressBarSH);
            this.Controls.Add(this.progressBarSZ);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DownStockInfo);
            this.Controls.Add(this.SZSum);
            this.Name = "BackGroundForm";
            this.Text = "BackGroundForm";
            this.Load += new System.EventHandler(this.BackGroundForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bk_GetStockInfoSZ;
        private System.Windows.Forms.Label SZSum;
        private System.Windows.Forms.Button DownStockInfo;
        private System.ComponentModel.BackgroundWorker bk_GetStockInfoSH;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ProgressBar progressBarSZ;
        private System.Windows.Forms.ProgressBar progressBarSH;
        private System.Windows.Forms.Label SHSum;
        private System.Windows.Forms.Button DownStock5MinInfo;
        private System.ComponentModel.BackgroundWorker bk_GetStock5MinInfoSZ;
        private System.Windows.Forms.Timer Get5MinTimer;
        private System.ComponentModel.BackgroundWorker bk_GetStock5MinInfoSH;
        private System.ComponentModel.BackgroundWorker bk_FinanceInfo;
        private System.Windows.Forms.Button DownFinanceInfo;
        private System.Windows.Forms.Label lblFinance;
    }
}