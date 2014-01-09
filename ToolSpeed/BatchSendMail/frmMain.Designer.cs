namespace BatchSendMail
{
    partial class frmMain
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
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblHour = new System.Windows.Forms.Label();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnStartEvent = new System.Windows.Forms.Button();
            this.lblStatusEvent = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStopEvent = new System.Windows.Forms.Button();
            this.timerEvent = new System.Windows.Forms.Timer(this.components);
            this.btnStopCheckMail = new System.Windows.Forms.Button();
            this.btnStartCheckMail = new System.Windows.Forms.Button();
            this.auto_worker = new System.ComponentModel.BackgroundWorker();
            this.event_worker = new System.ComponentModel.BackgroundWorker();
            this.check_worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "apuuoWWWHSNuSN36/LgniI8y6Ms+cqAL6dAuUMg2NNyrkn9DyllIoQ==";
            this.skinEngine1.SkinFile = null;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(113, 188);
            this.btnStart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 34);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Khởi động";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Location = new System.Drawing.Point(170, 92);
            this.lblDay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(39, 19);
            this.lblDay.TabIndex = 1;
            this.lblDay.Text = "Day";
            this.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(221, 92);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(57, 19);
            this.lblMonth.TabIndex = 1;
            this.lblMonth.Text = "Month";
            this.lblMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(288, 92);
            this.lblYear.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(42, 19);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Year";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.Location = new System.Drawing.Point(166, 122);
            this.lblHour.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(47, 19);
            this.lblHour.TabIndex = 1;
            this.lblHour.Text = "Hour";
            this.lblHour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Location = new System.Drawing.Point(214, 123);
            this.lblMinute.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(60, 19);
            this.lblMinute.TabIndex = 1;
            this.lblMinute.Text = "Minute";
            this.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(285, 122);
            this.lblSecond.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(68, 19);
            this.lblSecond.TabIndex = 1;
            this.lblSecond.Text = "Second";
            this.lblSecond.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(288, 188);
            this.btnStop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(146, 34);
            this.btnStop.TabIndex = 0;
            this.btnStop.Text = "Ngưng ";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thời gian:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(164, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "SPEED SEND EMAIL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Trạng thái gửi mail:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(243, 157);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(114, 19);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Đang chờ gửi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = ":";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 19);
            this.label8.TabIndex = 1;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(110, 382);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(10, 15);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = " ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(222, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "FASTAUTOMATICMAIL.COM";
            // 
            // btnStartEvent
            // 
            this.btnStartEvent.Location = new System.Drawing.Point(113, 272);
            this.btnStartEvent.Name = "btnStartEvent";
            this.btnStartEvent.Size = new System.Drawing.Size(146, 39);
            this.btnStartEvent.TabIndex = 7;
            this.btnStartEvent.Text = "Khởi động Event";
            this.btnStartEvent.UseVisualStyleBackColor = true;
            this.btnStartEvent.Click += new System.EventHandler(this.btnStartEvent_Click);
            // 
            // lblStatusEvent
            // 
            this.lblStatusEvent.AutoSize = true;
            this.lblStatusEvent.Location = new System.Drawing.Point(239, 238);
            this.lblStatusEvent.Name = "lblStatusEvent";
            this.lblStatusEvent.Size = new System.Drawing.Size(114, 19);
            this.lblStatusEvent.TabIndex = 9;
            this.lblStatusEvent.Text = "Đang chờ gửi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(85, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 19);
            this.label12.TabIndex = 8;
            this.label12.Text = "Trạng thái event:";
            // 
            // btnStopEvent
            // 
            this.btnStopEvent.Location = new System.Drawing.Point(288, 272);
            this.btnStopEvent.Name = "btnStopEvent";
            this.btnStopEvent.Size = new System.Drawing.Size(146, 39);
            this.btnStopEvent.TabIndex = 10;
            this.btnStopEvent.Text = "Dừng Event";
            this.btnStopEvent.UseVisualStyleBackColor = true;
            this.btnStopEvent.Click += new System.EventHandler(this.btnStopEvent_Click);
            // 
            // timerEvent
            // 
            this.timerEvent.Interval = 3600;
            this.timerEvent.Tick += new System.EventHandler(this.timerEvent_Tick);
            // 
            // btnStopCheckMail
            // 
            this.btnStopCheckMail.Location = new System.Drawing.Point(289, 342);
            this.btnStopCheckMail.Name = "btnStopCheckMail";
            this.btnStopCheckMail.Size = new System.Drawing.Size(146, 37);
            this.btnStopCheckMail.TabIndex = 14;
            this.btnStopCheckMail.Text = "Stop check mail";
            this.btnStopCheckMail.UseVisualStyleBackColor = true;
            this.btnStopCheckMail.Click += new System.EventHandler(this.btnStopCheckMail_Click);
            // 
            // btnStartCheckMail
            // 
            this.btnStartCheckMail.Location = new System.Drawing.Point(110, 342);
            this.btnStartCheckMail.Name = "btnStartCheckMail";
            this.btnStartCheckMail.Size = new System.Drawing.Size(146, 37);
            this.btnStartCheckMail.TabIndex = 13;
            this.btnStartCheckMail.Text = "Start check mail";
            this.btnStartCheckMail.UseVisualStyleBackColor = true;
            this.btnStartCheckMail.Click += new System.EventHandler(this.btnStartCheckMail_Click);
            // 
            // auto_worker
            // 
            this.auto_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.auto_worker_DoWork);
            // 
            // event_worker
            // 
            this.event_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.event_worker_DoWork);
            // 
            // check_worker
            // 
            this.check_worker.WorkerSupportsCancellation = true;
            this.check_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.check_worker_DoWork);
            this.check_worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.check_worker_ProgressChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 434);
            this.Controls.Add(this.btnStopCheckMail);
            this.Controls.Add(this.btnStartCheckMail);
            this.Controls.Add(this.btnStopEvent);
            this.Controls.Add(this.lblStatusEvent);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnStartEvent);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblMinute);
            this.Controls.Add(this.lblHour);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống FAMail";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnStartEvent;
        private System.Windows.Forms.Label lblStatusEvent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnStopEvent;
        public System.Windows.Forms.Timer timerEvent;
        private System.Windows.Forms.Button btnStopCheckMail;
        private System.Windows.Forms.Button btnStartCheckMail;
        private System.ComponentModel.BackgroundWorker auto_worker;
        private System.ComponentModel.BackgroundWorker event_worker;
        private System.ComponentModel.BackgroundWorker check_worker;

    }
}

