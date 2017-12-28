using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using IHIS.Framework;
using IHIS.OCSA.Properties;

namespace IHIS.OCSA
{
    public partial class FrmSettingTime : Form
    {
        #region Properties
        public delegate void InvokeControl(string ruleSender, string time);
        public InvokeControl invokeControl;
        private string _rule;
        private string _bufferRule;
        private string _currentRule;
        private string _time;
        private const string DAY = "D";
        private const string WEEK = "W";
        private const string MONTH = "M";
        private const string SPACE = "  ";
        private enum Rule
        {
            Day = 0,
            Week = 1,
            Month = 2
        }
        #endregion

        #region Contractor
        public FrmSettingTime(string rule, string time)
        {
            InitializeComponent();
            spnMonth.Properties.EditMask = "N0";
            _rule = rule;
            _time = time;
            SetDefaultTimeToTimeEdit();
            LoadCboDayOfWeek();
            BindingData();
        }
        #endregion

        #region Event
        private void RdgRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckShowHideTimePanel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (invokeControl != null)
            {
                string ruleSender = "";
                string timeSender = "";

                int rule = RdgRule.SelectedIndex;
                if (rule == (int)Rule.Day)
                {
                    ruleSender = "";
                    timeSender = timeDaily.Time.ToLongTimeString();
                }
                else if (rule == (int)Rule.Week)
                {
                    ruleSender = WEEK + (cboDayOfWeek.SelectedIndex + 1);
                    timeSender = timeWeekly.Time.ToLongTimeString();
                }
                else if (rule == (int)Rule.Month)
                {
                    ruleSender = MONTH + spnMonth.Text;
                    timeSender = timeMonthly.Time.ToLongTimeString();
                }

                invokeControl(ruleSender, timeSender);
            }

            this.Close();
        }
        #endregion

        #region Method

        private void BindingData()
        {
            try
            {
                if (string.IsNullOrEmpty(_rule)) return;
                _bufferRule = string.Empty;
                _currentRule = string.Empty;

                if (_rule.Contains(DAY))
                {
                    RdgRule.SelectedIndex = 0;
                    _currentRule = DAY;
                    timeDaily.Time = Convert.ToDateTime(_time);
                }
                else
                {
                    if (_rule.Contains(WEEK))
                    {
                        RdgRule.SelectedIndex = 1;
                        _currentRule = WEEK;
                        string[] bufferRulesArr = _rule.Split(new string[] { _currentRule }, StringSplitOptions.None);
                        timeWeekly.Time = Convert.ToDateTime(_time);
                        string vlueRule = bufferRulesArr[1];
                        int iVlue = 0;
                        bool intValueRule = Int32.TryParse(vlueRule, out iVlue);
                        cboDayOfWeek.SelectedIndex = iVlue - 1;
                    }
                    else if (_rule.Contains(MONTH))
                    {
                        RdgRule.SelectedIndex = 2;
                        _currentRule = MONTH;
                        string[] bufferRulesArr = _rule.Split(new string[] { _currentRule }, StringSplitOptions.None);
                        timeMonthly.Time = Convert.ToDateTime(_time);
                        spnMonth.Text = bufferRulesArr[1];
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of Method: BindingData() " + ex.StackTrace);
            }
        }

        private void SetDefaultTimeToTimeEdit()
        {
            DateTime _sysTime = EnvironInfo.GetSysDateTime();
            timeDaily.Time = timeWeekly.Time = timeMonthly.Time = Convert.ToDateTime(_sysTime);
        }

        private DataTable CreateDayOfWeekData()
        {
            DataTable dtDi = new DataTable("DayOfWeekData");
            dtDi.Columns.Add("DisplayId", typeof(string));
            dtDi.Columns.Add("Value", typeof(int));

            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Monday, 1);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Tuesday, 2);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Wednesday, 3);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Thursday, 4);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Friday, 5);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Saturday, 6);
            dtDi.Rows.Add(Resource.FrmSettingTime_CreateDayOfWeekData_Sunday, 7);

            return dtDi;
        }

        private void LoadCboDayOfWeek()
        {
            DataTable dtDisplayTagData = CreateDayOfWeekData();
            ComboBoxItemCollection itemsCollection = cboDayOfWeek.Properties.Items;
            itemsCollection.Clear();
            itemsCollection.BeginUpdate();
            try
            {
                foreach (DataRow row in dtDisplayTagData.Rows)
                    itemsCollection.Add(row["DisplayId"]);
            }
            finally
            {
                itemsCollection.EndUpdate();
            }

            cboDayOfWeek.SelectedIndex = 0;
        }

        private void CheckShowHideTimePanel()
        {
            int rule = RdgRule.SelectedIndex;
            if (rule == (int)Rule.Day)
            {
                SetShowHidTimePanel(true, false, false);
            }
            else if (rule == (int)Rule.Week)
            {
                SetShowHidTimePanel(false, true, false);
            }
            else if (rule == (int)Rule.Month)
            {
                SetShowHidTimePanel(false, false, true);
            }
        }

        private Rule GetRuleCurrentValue()
        {
            Rule currentRule = Rule.Day;
            int rule = RdgRule.SelectedIndex;
            if (rule == (int)Rule.Day)
            {
                currentRule = Rule.Day;
            }
            else if (rule == (int)Rule.Week)
            {
                currentRule = Rule.Week;
            }
            else if (rule == (int)Rule.Month)
            {
                currentRule = Rule.Month;
            }

            return currentRule;
        }

        private void SetShowHidTimePanel(bool dayPnl, bool weekPnl, bool monthPnl)
        {
            PnlDaily.Visible = dayPnl;
            PnlWeekly.Visible = weekPnl;
            PnlMonthly.Visible = monthPnl;
        }
        #endregion

    }
}
