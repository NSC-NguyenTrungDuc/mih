using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using IHIS.CloudConnector;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using System.Globalization;

namespace IHIS.OCSO
{
    public partial class OCS2015U02 : UserControl
    {
        private readonly OCS2015U00 _mainScreen;

        private int ClickCounter = 0;

        private OCS2015U03 ctlOCS2015U03;
        public OCS2015U02()
        {
            InitializeComponent();
            //this._mainScreen = mainScreen;
            InitExaminationCalendar();
            if (NetInfo.Language != LangMode.Jr)
            {
                calSchedule.IsJapanYearType = false;
                xPreMonthCalendar.IsJapanYearType = false;
            }
            
        }

        public void SetSizeAndLocationForControl()
        {
            this.CalenderLeftPnl.Location = new Point(0, 0);
            this.CalenderLeftPnl.Size = new System.Drawing.Size(187, 160);

            this.CalenderRightPnl.Location = new Point(187, 0);
            this.CalenderRightPnl.Size = new Size(190, 160);
        }

        public List<NuroPatientReceptionHistoryListItemInfo> ReceptHisList
        {
            get { return receptHisList; }
        }

        public void SetExaminedDates(OCS2015U03 pCtlOCS2015U03)
        {
            this.ctlOCS2015U03 = pCtlOCS2015U03;
            SetExaminedDates();
        }

        private void SetupDoubleClickEvent()
        {
            //ClickTimer = new System.Timers.Timer(200);
            //ClickTimer.Elapsed += new ElapsedEventHandler(EvaluateClicks);
        }

        private void SetExaminedDates()
        {
            //this.cldCurMonth.BoldedDates = new DateTime[] { DateTime.Today.AddDays(-2), DateTime.Today.AddDays(-6), DateTime.Today.AddDays(-15) };
            //this.cldPreMonth.BoldedDates = new DateTime[] { DateTime.Today.AddDays(-2).AddMonths(-1), DateTime.Today.AddDays(-6).AddMonths(-1), DateTime.Today.AddDays(-15).AddMonths(-1) };

            //System.Collections.Generic.List<NuroPatientReceptionHistoryListItemInfo> items = this.ctlOCS2015U03.ReceptHisResult.PatientReceptionHistoryListItem;
            //if (items.Count > 0)
            //{
            //    DateTime[] examDateList = new DateTime[items.Count];
            //    for (int i = 0; i < items.Count; i++)
            //    {
            //        DateTime date = DateTime.ParseExact(items[i].ExamDate, "yyyy-MM-dd HH:mm:ss.f", null);
            //        examDateList[i] = date;
            //    }
            //    this.cldCurMonth.BoldedDates = examDateList;
            //    this.cldPreMonth.BoldedDates = examDateList;
            //}
        }

        private void OCS2015U02_CalendarDoubleClick(OCS2015U02 sender, SelectedDateEventArgs e)
        {
            MessageBox.Show(e.SelectedDate.ToString() + " clicked.");
        }

        private void cldMonth_DateSelected(object sender, DateRangeEventArgs e)
        {
            //MessageBox.Show(((MonthCalendar)sender).Name + e.Start.Date.ToString() + " clicked.");
        }

        private void cldMonth_MouseDown(object sender, MouseEventArgs e)
        {
            //ClickTimer.Stop();
            //ClickCounter++;
            //ClickTimer.Start();

            MonthCalendar.HitTestInfo hit = ((MonthCalendar)sender).HitTest(e.Location);
            if (hit.HitArea == MonthCalendar.HitArea.Date)
            {
                selectedDateEventArg._selectedDate = hit.Time;
            }
        }

        private void EvaluateClicks(object source, ElapsedEventArgs e)
        {
            //ClickTimer.Stop();
            // Evaluate ClickCounter here
            if (ClickCounter == 2)
            {
                if (CalendarDoubleClick != null)
                {
                    this.CalendarDoubleClick(this, selectedDateEventArg);
                }
            }
            ClickCounter = 0;
        }
        //public System.Timers.Timer ClickTimer { get; set; }

        public delegate void DoubleClickHandler(OCS2015U02 sender, SelectedDateEventArgs e);
        public event DoubleClickHandler CalendarDoubleClick;
        private SelectedDateEventArgs selectedDateEventArg = new SelectedDateEventArgs();

        public class SelectedDateEventArgs : EventArgs
        {
            internal DateTime _selectedDate;
            public DateTime SelectedDate
            {
                get
                {
                    return this._selectedDate;
                }
            }
        }

        #region Common calendar - HungNV added

        private string mBunho = "";
        private string mGwa = "";
        private string mDoctor = "";
        private string mCurrentDate = "";
        private string mHospCode = "";

        NuroPatientReceptionHistoryListResult receptHisResult;
        List<DateTime> HisExaminationLst = new List<DateTime>();
        internal void InitExaminationCalendar()
        {
            DateTime prevDate = DateTime.Now.AddMonths(-1);
            xPreMonthCalendar.EnableMultiSelection = true;
            calSchedule.EnableMultiSelection = true;
            LoadCurrentMonthData();
            LoadPreviousMonthData(true);
        }

        private List<NuroPatientReceptionHistoryListItemInfo> receptHisList = new List<NuroPatientReceptionHistoryListItemInfo>();

        internal void LoadHisExam(string bunho)
        {
            ReceptHisList.Clear();
            HisExaminationLst.Clear();
            NuroPatientReceptionHistoryListArgs receptHisArg = new NuroPatientReceptionHistoryListArgs();
            receptHisArg.PatientCode = bunho;
            receptHisResult = CloudService.Instance.Submit<NuroPatientReceptionHistoryListResult, NuroPatientReceptionHistoryListArgs>(receptHisArg);

            if (receptHisResult.ExecutionStatus == ExecutionStatus.Success
                && receptHisResult.PatientReceptionHistoryListItem.Count > 0)
            {
                foreach (NuroPatientReceptionHistoryListItemInfo item in receptHisResult.PatientReceptionHistoryListItem)
                {
                    HisExaminationLst.Add(DateTime.Parse(item.ExamDate.Split(new char[] { ' ' })[0].ToString()));
                }

                receptHisList = receptHisResult.PatientReceptionHistoryListItem;
            }
        }
        internal void LoadCurrentMonthData()
        {
            calSchedule.UnSelectAll();
            DateTime calendarDate = calSchedule.GetCalendarDateTime();
            if (HisExaminationLst.Count <= 0) return; 
            List<DateTime> hisExamLst = new List<DateTime>();
            foreach (DateTime e in HisExaminationLst)
            {
                if (e.Year == calendarDate.Year && e.Month == calendarDate.Month)
                {
                    hisExamLst.Add(e);
                }
            }            
            if (hisExamLst.Count <= 0) return;
            foreach(DateTime item in hisExamLst)
            {
                calSchedule.SelectDate(item);
            }
        }

        internal void LoadPreviousMonthData(bool isInit)
        {
            if (isInit)
            {
                DateTime prevDate = DateTime.Now.AddMonths(-1);
                xPreMonthCalendar.SetActiveMonth(prevDate.Year, prevDate.Month);
            }
            xPreMonthCalendar.UnSelectAll();
            DateTime calendarDate = xPreMonthCalendar.GetCalendarDateTime();
            if (HisExaminationLst.Count <= 0) return;
            List<DateTime> hisExamLst = new List<DateTime>();
            foreach (DateTime e in HisExaminationLst)
            {
                if (e.Year == calendarDate.Year && e.Month == calendarDate.Month)
                {
                    hisExamLst.Add(e);
                }
            }
            if (hisExamLst.Count <= 0) return;
            foreach (DateTime item in hisExamLst)
            {
                xPreMonthCalendar.SelectDate(item);
            }
        }
        //Current month
        internal void calSchedule_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
            this.mCurrentDate = e.DateItems[0].Date.ToString("yyyy/MM/dd").Trim();
        }

        internal void calSchedule_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        {
            LoadCurrentMonthData();
        }

        internal void calSchedule_MonthChanged(object sender, IHIS.Framework.XCalendarMonthChangedEventArgs e)
        {
            DateTime date = calSchedule.GetCalendarDateTime();
            LoadCurrentMonthData();
        }

        //Previous month
        internal void Previous_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {

        }

        internal void Previous_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        {
            this.mCurrentDate = e.DateItem.Date.ToString("yyyy/MM/dd").Trim();
            LoadPreviousMonthData(false);
        }

        internal void Previous_MonthChanged(object sender, IHIS.Framework.XCalendarMonthChangedEventArgs e)
        {
            LoadPreviousMonthData(false);
        }

        internal void ResetCalendar()
        {
            HisExaminationLst.Clear();
            xPreMonthCalendar.UnSelectAll();
            calSchedule.UnSelectAll();
        }
        #endregion
    }
}
