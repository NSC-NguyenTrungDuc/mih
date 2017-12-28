namespace IHIS.OCSO
{
    partial class OCS2015U02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS2015U02));
            this.CalenderLeftPnl = new System.Windows.Forms.Panel();
            this.xPreMonthCalendar = new IHIS.Framework.XCalendar();
            this.calSchedule = new IHIS.Framework.XCalendar();
            this.CalenderRightPnl = new System.Windows.Forms.Panel();
            this.CalenderLeftPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPreMonthCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).BeginInit();
            this.CalenderRightPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalenderLeftPnl
            // 
            resources.ApplyResources(this.CalenderLeftPnl, "CalenderLeftPnl");
            this.CalenderLeftPnl.Controls.Add(this.xPreMonthCalendar);
            this.CalenderLeftPnl.Name = "CalenderLeftPnl";
            // 
            // xPreMonthCalendar
            // 
            resources.ApplyResources(this.xPreMonthCalendar, "xPreMonthCalendar");
            this.xPreMonthCalendar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.xPreMonthCalendar.EnableMultiSelection = false;
            this.xPreMonthCalendar.Footer.ShowToday = false;
            this.xPreMonthCalendar.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xPreMonthCalendar.IsJapanYearType = true;
            this.xPreMonthCalendar.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.xPreMonthCalendar.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.xPreMonthCalendar.Name = "xPreMonthCalendar";
            this.xPreMonthCalendar.ShowFooter = false;
            this.xPreMonthCalendar.ToggleSelection = true;
            this.xPreMonthCalendar.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.Previous_MonthChanged);
            this.xPreMonthCalendar.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.Previous_DayClick);
            // 
            // calSchedule
            // 
            resources.ApplyResources(this.calSchedule, "calSchedule");
            this.calSchedule.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Inset;
            this.calSchedule.EnableMultiSelection = false;
            this.calSchedule.Footer.ShowToday = false;
            this.calSchedule.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calSchedule.IsJapanYearType = true;
            this.calSchedule.MaxDate = new System.DateTime(2030, 1, 11, 0, 0, 0, 0);
            this.calSchedule.MinDate = new System.DateTime(1996, 1, 11, 0, 0, 0, 0);
            this.calSchedule.Name = "calSchedule";
            this.calSchedule.ShowFooter = false;
            this.calSchedule.ToggleSelection = true;
            this.calSchedule.MonthChanged += new IHIS.Framework.XCalendarMonthChangedEventHandler(this.calSchedule_MonthChanged);
            this.calSchedule.DayClick += new IHIS.Framework.XCalendarDayClickEventHandler(this.calSchedule_DayClick);
            // 
            // CalenderRightPnl
            // 
            resources.ApplyResources(this.CalenderRightPnl, "CalenderRightPnl");
            this.CalenderRightPnl.Controls.Add(this.calSchedule);
            this.CalenderRightPnl.Name = "CalenderRightPnl";
            // 
            // OCS2015U02
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalenderRightPnl);
            this.Controls.Add(this.CalenderLeftPnl);
            this.Name = "OCS2015U02";
            this.CalenderLeftPnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPreMonthCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calSchedule)).EndInit();
            this.CalenderRightPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel CalenderLeftPnl;
        public Framework.XCalendar xPreMonthCalendar;
        public Framework.XCalendar calSchedule;
        private System.Windows.Forms.Panel CalenderRightPnl;

    }
}
