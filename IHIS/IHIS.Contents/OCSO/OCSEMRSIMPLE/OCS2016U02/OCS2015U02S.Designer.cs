namespace IHIS.OCSO
{
    partial class OCS2015U02S
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CalenderPnl = new System.Windows.Forms.Panel();
            this.xPreMonthCalendar = new IHIS.Framework.XCalendar();
            this.calSchedule = new IHIS.Framework.XCalendar();
            this.CalenderPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPreMonthCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // CalenderPnl
            // 
            this.CalenderPnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalenderPnl.Controls.Add(this.xPreMonthCalendar);
            this.CalenderPnl.Controls.Add(this.calSchedule);
            this.CalenderPnl.Location = new System.Drawing.Point(0, 0);
            this.CalenderPnl.Name = "CalenderPnl";
            this.CalenderPnl.Size = new System.Drawing.Size(450, 160);
            this.CalenderPnl.TabIndex = 1;
            // 
            // xPreMonthCalendar
            // 
            this.xPreMonthCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xPreMonthCalendar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.xPreMonthCalendar.EnableMultiSelection = false;
            this.xPreMonthCalendar.Footer.ShowToday = false;
            this.xPreMonthCalendar.Header.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPreMonthCalendar.IsJapanYearType = true;
            this.xPreMonthCalendar.Location = new System.Drawing.Point(0, 0);
            this.xPreMonthCalendar.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.xPreMonthCalendar.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.xPreMonthCalendar.Name = "xPreMonthCalendar";
            this.xPreMonthCalendar.ShowFooter = false;
            this.xPreMonthCalendar.Size = new System.Drawing.Size(163, 160);
            this.xPreMonthCalendar.TabIndex = 2;
            this.xPreMonthCalendar.ToggleSelection = true;
            this.xPreMonthCalendar.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.Previous_MonthChanged);
            this.xPreMonthCalendar.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.Previous_DayClick);
            // 
            // calSchedule
            // 
            this.calSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calSchedule.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.calSchedule.EnableMultiSelection = false;
            this.calSchedule.Footer.ShowToday = false;
            this.calSchedule.Header.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calSchedule.IsJapanYearType = true;
            this.calSchedule.Location = new System.Drawing.Point(163, 0);
            this.calSchedule.Margin = new System.Windows.Forms.Padding(0);
            this.calSchedule.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.calSchedule.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.ShowFooter = false;
            this.calSchedule.Size = new System.Drawing.Size(163, 160);
            this.calSchedule.TabIndex = 1;
            this.calSchedule.ToggleSelection = true;
            this.calSchedule.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calSchedule_MonthChanged);
            this.calSchedule.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calSchedule_DayClick);
            // 
            // OCS2015U02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalenderPnl);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "OCS2015U02";
            this.Size = new System.Drawing.Size(450, 160);
            this.CalenderPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPreMonthCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CalenderPnl;
        public Framework.XCalendar xPreMonthCalendar;
        public Framework.XCalendar calSchedule;

    }
}
