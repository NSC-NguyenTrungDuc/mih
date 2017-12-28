#region 사용 NameSpace 지정
using System;
using System.Configuration;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using IHIS.NURO.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
//using IHIS.ORCA;
using ORCA;
//using ORCA.ORCASERVICE;
using ORCA;
using IHIS.NURO.Reports;

#endregion

namespace IHIS.NURO
{
    /// <summary>
    /// RES1001U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class RES1001U00 : IHIS.Framework.XScreen
    {
        #region [Instance Variable]

        private bool flag = true;
        private bool checkDoctor = true;
        //Message처리
        private string mbxMsg = "", mbxCap = "";
       
        //등록번호
        private string mBunho = "";
        private string mGwaMap = "";
        private string mDoctorMap = "";
        //진료과
        private string mGwa = "";
        //의사
        private string mDoctor = "";
        //내원일자
        private string mNaewon_date = "";
        //입력구분
        private string mInput_gubun = "";

        //창구
        private string mChanggu = "OCSO";

        private int AM_START_TIME = 800;
        //private int AM_END_TIME = 1200;
        //private int PM_START_TIME = 1400;
        private int AM_END_TIME = 1300;
        private int PM_START_TIME = 1300;
        private int PM_END_TIME = 1700;

        //현재 선택되 있는 날짜
        private string mCurrentDate = "";

        private string mHospCode = "";
        private string mCallerName = "";
        private bool checkInsertSS;
        private string preTimeGrid = "";

        //MED-7450: private field for 3 new tabs
        private string mHospCodeLink = "";
        private bool tabIsAll = false;

        //MED-7450: bunho link map with bunho
        private string mBunhoLink = "";

        private int curPreRowIndex = -1;
        private int curPreX = -1;

        private string dragFrom = "";

        private ToolTip toolTip1;

        private RES1001U01BookingClinicReferResult bookingRefer = new RES1001U01BookingClinicReferResult();

        private string mPreTime = "";

        private string[] msgOrca = { "00", "K3", "K4", "K5" };

        #endregion

        public RES1001U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            toolTip1 = new ToolTip();
            //this.SaveLayoutList.Add(grdDeleteOUT1001);
            //this.SaveLayoutList.Add(grdOUT1001_AM);
            //this.SaveLayoutList.Add(grdOUT1001_PM);

            //grdDeleteOUT1001.SavePerformer = new XSavePerformer(this);
            //grdOUT1001_AM.SavePerformer = grdDeleteOUT1001.SavePerformer;
            //grdOUT1001_PM.SavePerformer = grdDeleteOUT1001.SavePerformer;

            //MED-13194
            if (NetInfo.Language != LangMode.Jr)
            {
                grdOUT1001_AM.AutoSizeColumn(xEditGridCell16.Col, 0);
                grdOUT1001_PM.AutoSizeColumn(xEditGridCell4.Col, 0);
            }

            layOCS0105.ParamList = GongbiParamList();
            layOCS0105.ExecuteQuery = GridGongbiList;

            layReseredData.ParamList = LayReseredDataParamList();
            layReseredData.ExecuteQuery = LayReseredData;

            layReserList.ParamList = LayReserParamList();
            layReserList.ExecuteQuery = LayReser;

            xGrid1.ParamList = GongbiParamList();
            xGrid1.ExecuteQuery = GridDoctorReser;

            layUserName.ParamList = LayUserNameParamList();
            layUserName.ExecuteQuery = LayUserName; 

            // AnhNV hot fixed
            this.layOCS0105.ParamList = new List<string>(new string[]
                                                         {
                                                             "f_doctor",
                                                             "f_start_date",
                                                             "f_end_date",
                                                         });
            ;

            fwkLinkHospCode.ExecuteQuery = LoadDataLinkHospCode;
           
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            if (command == "OCS0270Q00")
            {
                this.cboGwa.SetDataValue(commandParam["gwa"].ToString());
                this.fbxDoctor.SetEditValue(commandParam["doctor"].ToString());
                this.fbxDoctor.AcceptData();
                this.fbxDoctor.Focus();
                this.fbxDoctor.SelectAll();
            }

            return base.Command(command, commandParam);
        }
        

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            mHospCode = EnvironInfo.HospCode;

            this.CurrMSLayout = grdOUT1001_AM;
            this.CurrMQLayout = grdOUT1001_AM;

            XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
            //MED-10588
            if (patientInfo != null && String.IsNullOrEmpty(mBunho))
            {
                mBunho = patientInfo.BunHo;
            }

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void RES1001U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {

             mHospCode = EnvironInfo.HospCode;
            CreateCombo();
         
            //화면 사이즈 조정
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;

            // Call된 경우
            if (this.OpenParam != null)
            {
                //화면 사이즈 조정
                this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 250);

                try
                {
                    // 등록번호
                    if (OpenParam.Contains("bunho"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
                            mBunho = OpenParam["bunho"].ToString().Trim();
                    }

                    // 진료과, 진료의사
                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString().Trim()))
                        {
                            mGwa = OpenParam["gwa"].ToString().Trim();

                            if (OpenParam.Contains("doctor"))
                            {
                                if (!TypeCheck.IsNull(OpenParam["doctor"].ToString().Trim()))
                                {
                                    mDoctor = OpenParam["doctor"].ToString().Trim();
                                }
                            }
                        }
                    }

                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }

                    if (OpenParam.Contains("caller_name"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["caller_name"].ToString().Trim()))
                        {
                            mCallerName = OpenParam["caller_name"].ToString().Trim();
                        }
                    }
                    //XScreen screen = (XScreen)Opener;
                    //mCallerName = screen.Name;
                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }
            else
            {

                //화면 사이즈 조정
                //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 110);
                this.ParentForm.Size = new System.Drawing.Size(1200, rc.Height - 110);

                // 혹시 다른 스크린에서 받아올수 있는지 판단.
                // 이전 스크린의 등록번호를 가져온다
                if (this.paBox.BunHo == "")
                {
                    XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                    if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                    {
                        // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                        patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                    }

                    if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                    {
                        this.paBox.SetPatientID(patientInfo.BunHo);
                    }
                }
            }
          
        }

        /// <summary>
        /// Load시 별도 Design할 부분이 있는 경우 여기서 Coding처리
        /// </summary>        
        private const int PNLDOCTORHEIGHT = 30;

        private const int PNLPATIENTHEIGHT = 38;

        private void InitialDesign()
        {
            //calSchedule.Dates.Clear();

            if (mInput_gubun == "D")
            {
                //pnlPatient.SetBounds(pnlPatient.Location.X, pnlPatient.Location.Y, pnlPatient.Size.Width, PNLPATIENTHEIGHT);
                //pnlDoctor.SetBounds(pnlDoctor.Location.X, pnlDoctor.Location.Y, pnlDoctor.Size.Width, 0);
                //cboGwa.Enabled = false;
            }
            else
            {
                //pnlPatient.SetBounds(pnlPatient.Location.X, pnlPatient.Location.Y, pnlPatient.Size.Width, 0);
                //pnlDoctor.SetBounds(pnlDoctor.Location.X, pnlDoctor.Location.Y, pnlDoctor.Size.Width, PNLDOCTORHEIGHT);
                //cboGwa.Enabled = true;
            }
        }

        private bool mCalledByPostLoad = false;

        private void PostLoad()
        {
            //CreateCombo();

            //현재 년,월로 Active
            calSchedule.SetActiveMonth(int.Parse(EnvironInfo.GetSysDate().ToString("yyyy")),
                int.Parse(EnvironInfo.GetSysDate().ToString("MM")));

            //현재 일자 select
            calSchedule.DaySelected -= new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calSchedule_DaySelected);
            if (this.mNaewon_date != "")
                calSchedule.SelectDate(Convert.ToDateTime(this.mNaewon_date));
            else
                calSchedule.SelectDate(EnvironInfo.GetSysDate());
            calSchedule.DaySelected += new IHIS.Framework.XCalendarDaySelectedEventHandler(this.calSchedule_DaySelected);

            if (calSchedule.SelectedDays.Count > 0)
            {
                mCurrentDate = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd").Trim();
            }

            // 사용자 변경 Event Call /////////////////////////////////////////////////////////////////////////////////////////////
            mCalledByPostLoad = true;
            if (!TypeCheck.IsNull(mBunho))
                this.paBox.SetPatientID(mBunho);
            this.RES1001U00_UserChanged(this, new System.EventArgs());
            mCalledByPostLoad = false;
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (UserInfo.UserGubun != UserType.Doctor)
            {
                if (!TypeCheck.IsNull(mGwa))
                {
                    this.cboGwa.SetEditValue(mGwa);

                    if (!TypeCheck.IsNull(mDoctor))
                    {
                        SetDataDoctorSchedule(mDoctor, EnvironInfo.GetSysDate().ToString("yyyyMM"));
                        this.fbxDoctor.SetEditValue(mDoctor);

                        this.fbxDoctor.AcceptData();
                        //this.fbxDoctor.Focus();
                        //this.fbxDoctor.SelectAll();
                    }
                }
            }

            //else if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    this.cboGwa.SetEditValue(UserInfo.Gwa);
            //    SetDataDoctorSchedule(UserInfo.DoctorID, EnvironInfo.GetSysDate().ToString("yyyyMM"));
            //    this.fbxDoctor.SetEditValue(UserInfo.DoctorID);
            //}

            // 등록번호
            

            //if(UserInfo.UserGubun != UserType.Doctor)
            //{
            //    XMessageBox.Show("入力されている予約者IDと自分のIDが違う場合には予約者IDに自分のIDを入力してください。", "予約者ID確認", MessageBoxIcon.Information);
            //    this.txtUser.Focus();
            //    this.txtUser.SelectAll();
            //}
        }

        private void RES1001U00_UserChanged(object sender, System.EventArgs e)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                mInput_gubun = "D";
                //포스트로드에서 불릴 경우 오픈파람을 그대로 사용함
                if (!mCalledByPostLoad)
                {
                    mDoctor = UserInfo.DoctorID;
                    mGwa = UserInfo.Gwa;
                }

                if (mDoctor == "")
                    mDoctor = UserInfo.DoctorID;

                if (mGwa == "")
                    //mGwa = UserInfo.Gwa;
                    mGwa = cboGwa.GetDataValue();

                //mChanggu = "OCSO";
                mChanggu = UserInfo.UserID;

                this.cboGwa.SetEditValue(mGwa);
                this.txtUser.SetEditValue(UserInfo.UserID);
                this.txtUser.AcceptData();

                this.fbxDoctor.SetEditValue(mDoctor);
                this.fbxDoctor.AcceptData();
                this.fbxDoctor.Focus();
                this.fbxDoctor.SelectAll();

            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                mInput_gubun = "N";
                //mChanggu = "NURO";
                mChanggu = UserInfo.UserID;
                mGwa = this.cboGwa.GetDataValue();
                this.txtUser.SetEditValue(UserInfo.UserID);
                this.txtUser.AcceptData();
            }
            else
            {
                mInput_gubun = "E";
                //mChanggu = "OUTO";
                mChanggu = UserInfo.UserID;
                mGwa = this.cboGwa.GetDataValue();
                this.txtUser.SetEditValue(UserInfo.UserID);
                this.txtUser.AcceptData();
            }
        }

        private const string CACHE_COMBOCHOJAE_KEYS = "Nuro.RES1001U00.CmbChoJae";
        private const string CACHE_COMBOGWA_KEYS = "Nuro.RES1001U00.CmbGwa";

        private void CreateCombo()
        {
            IHIS.Framework.MultiLayout layoutCombo = new MultiLayout();

            //초재구분
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("code", DataType.String);
            layoutCombo.LayoutItems.Add("code_name", DataType.String);
            layoutCombo.InitializeLayoutTable();


            layoutCombo.ExecuteQuery = ComboChoJae;

            if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            {
                grdOUT1001_AM.SetComboItems("chojae", layoutCombo.LayoutTable, "code_name", "code");
                grdOUT1001_PM.SetComboItems("chojae", layoutCombo.LayoutTable, "code_name", "code");
            }

            //if(mInput_gubun != "D") return;

            //진료과
            layoutCombo.Reset();
            layoutCombo.LayoutItems.Clear();
            layoutCombo.LayoutItems.Add("gwa", DataType.String);
            layoutCombo.LayoutItems.Add("gwa_name", DataType.String);
            layoutCombo.InitializeLayoutTable();

            layoutCombo.ExecuteQuery = ComboGwa;

            layoutCombo.ParamList = new List<string>(new String[] { "f_hosp_code" });
            layoutCombo.SetBindVarValue("f_hosp_code", this.mHospCode);
            if (layoutCombo.QueryLayout(true) && layoutCombo.RowCount > 0)
            {
                this.cboGwa.SelectedIndexChanged -= new System.EventHandler(this.cboGwa_SelectedIndexChanged);
                cboGwa.SetComboItems(layoutCombo.LayoutTable, "gwa_name", "gwa");
                cboGwa.SelectedIndex = 0;
                this.cboGwa.SelectedIndexChanged += new System.EventHandler(this.cboGwa_SelectedIndexChanged);
            }
        }

        //Load Data into Combo
        private IList<object[]> ComboChoJae(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            ComboListByCodeTypeArgs argsCombo = new ComboListByCodeTypeArgs();
            argsCombo.CodeType = "CHOJAE";
            argsCombo.IsAll = false;
            argsCombo.HospCodeLink = this.mHospCodeLink;
            argsCombo.TabIsAll = this.tabIsAll;


            ComboListItemResult result =
                CacheService.Instance.Get<ComboListByCodeTypeArgs, ComboListItemResult>(argsCombo);

            if (result != null && result.ListItemInfos.Count > 0)
            {
                foreach (ComboListItemInfo item in result.ListItemInfos)
                {
                    data.Add(new object[]
                             {
                                 item.Code,
                                 item.CodeName
                             });
                }
            }

            return data;
        }

        //Load Data Into CboGwa
        private IList<object[]> ComboGwa(BindVarCollection bc)
        {
            IList<object[]> lstResult = new List<object[]>();

            NuroRES0102U00CboGwaArgs argsCboGwa = new NuroRES0102U00CboGwaArgs();
            argsCboGwa.HospCode = bc["f_hosp_code"].VarValue;
            argsCboGwa.AppDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            argsCboGwa.HospCodeLink = mHospCodeLink;
            argsCboGwa.TabIsAll = tabIsAll;

            NuroRES0102U00CboGwaResult result =
                CloudService.Instance
                    .Submit<NuroRES0102U00CboGwaResult, NuroRES0102U00CboGwaArgs>(argsCboGwa);

            if (result != null)
            {
                IList<ComboListItemInfo> listItem = result.CboItemInfo;

                foreach (ComboListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.Code,
                        item.CodeName
                    };
                    lstResult.Add(objects);
                }
            }
            return lstResult;
        }
        //Load Mapping code
        private bool LoadMappingCode()
        {
            IList<object[]> lstResult = new List<object[]>();
            RES1001U00MapingCodeArgs args = new RES1001U00MapingCodeArgs();
            args.Gwa = mGwa;
            //args.Doctor = mDoctor.Remove(0, 2);

            // fix med-8039 by HoangVV
            if (mDoctor == "")
            {
                XMessageBox.Show(Resources.MSG025_MSG, Resources.MSG025_CAP, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                args.Doctor = mDoctor.Remove(0, 2);
            }
            //end fix
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;
            RES1001U00MapingCodeResult result = CloudService.Instance.Submit<RES1001U00MapingCodeResult, RES1001U00MapingCodeArgs>(args);
            if (result != null && result.ListItem.Count > 0)
            {
                foreach (RES1001U00MapingCodeInfo item in result.ListItem)
                {
                    object[] objects =
                    {
                        item.Gwa,
                        item.Doctor
                    };
                    lstResult.Add(objects);
                }
                mGwaMap = lstResult[0][0].ToString();
                mDoctorMap = lstResult[0][1].ToString();
            }
            else
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 해당의사의 Schedule정보를 달력에 표시한다.
        /// </summary>
        /// <param name="aDoctor"></param>
        /// <param name="aYYYYMM"></param>
        private void SetDataDoctorSchedule(string aDoctor, string aYYYYMM)
        {
            bool flag = false;
            if (this.fbxDoctor.GetDataValue() == "")
                return;

            calSchedule.SuspendLayout();
            //Calendar Clear
            calSchedule.Dates.Clear();

            //ArrayList input = new ArrayList();
            //input.Add(aDoctor);
            //input.Add(aYYYYMM);

            NuroRES1001U00PRDoctorScheduleNewArgs args = new NuroRES1001U00PRDoctorScheduleNewArgs();
            args.IDoctor = aDoctor;
            args.IYymm = aYYYYMM;
            args.HospCodeLink = mHospCodeLink;
            args.TabIsAll = tabIsAll;

            StoredProcedureResult result =
                CloudService.Instance.Submit<StoredProcedureResult, NuroRES1001U00PRDoctorScheduleNewArgs>(args);

            if (result != null)
            {
                flag = result.Result;
            }

            if (!flag)
            //if (!Service.ExecuteProcedure("PR_RES_DOCTOR_SCHEDULE_NEW", "D1004", aYYYYMM))
            {
                XMessageBox.Show(Resources.MSG001_MSG + Service.ErrFullMsg);
                return;
            }

            //this.layOCS0105.SetBindVarValue("f_doctor", "D1004");
            this.layOCS0105.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layOCS0105.SetBindVarValue("f_doctor", aDoctor);
            this.layOCS0105.SetBindVarValue("f_yyyymm", aYYYYMM);
            this.layOCS0105.SetBindVarValue("f_start_date", calSchedule.DisplayStartDate.ToString("yyyy/MM/dd").Replace("-", "/"));
            this.layOCS0105.SetBindVarValue("f_end_date", calSchedule.DisplayEndDate.ToString("yyyy/MM/dd").Replace("-", "/"));
            //using mBunho to switch bunho between 2 tabs
            //this.layOCS0105.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layOCS0105.SetBindVarValue("f_bunho", mBunho);
            this.layOCS0105.QueryLayout(true);

            IHIS.Framework.XCalendarDate dateItem;

            foreach (DataRow row in layOCS0105.LayoutTable.Rows)
            {
                dateItem = new XCalendarDate(DateTime.Parse(row["res_date"].ToString()));
                dateItem.Tag = row["res_flag"].ToString();
                //dateItem.ContentText = row["res_inwon"].ToString();

                //String[] allContent = null;
                //if (row["res_inwon"].ToString() != "") allContent = row["res_inwon"].ToString().Split('/');
                //if (allContent != null && allContent.Length > 0)
                //{
                //MED - 8090
                    dateItem.ContentTextColor = XColor.FromDefinedColor(XDefinedColor.XCalendarDisabledDateTextColor);
                    //dateItem.ContentText = Resources.StringMyHosp + "  " + allContent[0] + Environment.NewLine + Resources.StringLinkHosp + "  " + allContent[1];
                    dateItem.ContentText = row["res_inwon"].ToString() + Environment.NewLine + row["res_outwon"].ToString();
                    dateItem.ContentMultiLine = true;
                    dateItem.ContentTextColorMultiLine = XColor.UpdatedForeColor;
                //}

                switch (row["res_flag"].ToString())
                {
                    //예약불가
                    case "0":
                    case "H":

                        dateItem.ImageIndex = 2;
                        //dateItem.ImageIndex = 0;

                        break;

                    default:

                        break;
                }

                calSchedule.Dates.Add(dateItem);
            }

            calSchedule.ResumeLayout();
            calSchedule.Refresh();
            this.grdOUT1001_AM.Reset();
            this.grdOUT1001_PM.Reset();

        }

        private void calSchedule_DayClick(object sender, IHIS.Framework.XCalendarDayClickEventArgs e)
        {
            //this.grdDeleteOUT1001.Reset();

            //this.mCurrentDate = e.DateItem.Date.ToString("yyyy/MM/dd").Trim();
            grdOUT1001_AM.QueryLayout(true);
            grdOUT1001_PM.QueryLayout(true);
            LoadBookingClinicRefer();
            //grdOUT1001_AM.Reset();
            //grdOUT1001_PM.Reset();  
        }

        private void calSchedule_MonthChanged(object sender, IHIS.Framework.XCalendarMonthChangedEventArgs e)
        {
            if (mDoctor == "")
            {
                XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG002_CAP, MessageBoxIcon.Information);
                return;
            }

            SetDataDoctorSchedule(mDoctor, e.Year.ToString() + e.Month.ToString("00"));
            //e.DisplayStartDate.ToString("yyyyMM"));
        }

        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }

        private void grdRES1001_AM_GridColumnProtectModify(object sender,
            IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["naewon_yn"].ToString() == "N")
            {
                if (e.ColName == "modify" && e.DataRow["newrow"].ToString() == "Y")
                    e.Protect = true;
                else
                    e.Protect = false;
            }
            else
            {
                if (e.ColName != "reser_comment")
                    e.Protect = true;
            }
            if (e.DataRow["clinic_name"].ToString() != "" && e.DataRow["clinic_name"].ToString() != UserInfo.HospName)
            {
                e.Protect = true;

            }
            else
            {
                e.Protect = false;
            }
        }

        private void grdRES1001_AM_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            if (e.ColName == "modify")
            {
                frmModifyReser frm = new frmModifyReser(this.mHospCodeLink, this.tabIsAll);
                frm.rowModify = e.DataRow;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    //다시 조회
                    string jinryo_pre_date = "";
                    if (this.calSchedule.SelectedDays.Count > 0)
                        jinryo_pre_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                    this.SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));
                    this.grdOUT1001_AM.QueryLayout(true);
                    this.grdOUT1001_PM.QueryLayout(true);
                    LoadBookingClinicRefer();
                }
            }
            else if (e.ColName == "comment_button")
            {
                if (e.DataRow["bunho"].ToString() == "")
                    return;

                Hashtable ht = new Hashtable();
                ht.Add("open_mode", "MODIFY");
                ht.Add("bunho", e.DataRow["bunho"].ToString());
                ht.Add("pkout1001", e.DataRow["pkout1001"].ToString());
                ht.Add("gwa", this.cboGwa.GetDataValue());
                ht.Add("doctor", this.fbxDoctor.GetDataValue());
                ht.Add("reser_comment", e.DataRow["reser_comment"].ToString());
                ht.Add("reser_gubun", e.DataRow["reser_gubun"].ToString());
                ht.Add("jinryo_pre_date", e.DataRow["jinryo_pre_date"].ToString());
                ht.Add("jinryo_pre_time", e.DataRow["jinryo_pre_time"].ToString());

                ReserCommentForm rcf = new ReserCommentForm(ht, this.mHospCodeLink, this.tabIsAll);
                rcf.ShowDialog(this);
                grdOUT1001_AM.QueryLayout(true);
                //grdOUT1001_PM.QueryLayout(true); 
                LoadBookingClinicRefer();
            }
        }

        private void grdRES1001_PM_GridColumnProtectModify(object sender,
            IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["naewon_yn"].ToString() == "N")
            {
                if (e.ColName == "modify" && e.DataRow["newrow"].ToString() == "Y")
                    e.Protect = true;
                else
                    e.Protect = false;
            }
            else
            {
                if (e.ColName != "reser_comment")
                    e.Protect = true;
            }
            if (e.DataRow["clinic_name"].ToString() != "" && e.DataRow["clinic_name"].ToString() != UserInfo.HospName)
            {
                e.Protect = true;

            }
            else
            {
                e.Protect = false;
            }
        }

        private void grdRES1001_PM_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            if (e.ColName == "modify")
            {
                frmModifyReser frm = new frmModifyReser(e.DataRow, this.mHospCodeLink, this.tabIsAll);
                //frm.rowModify = e.DataRow;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    //다시 조회
                    string jinryo_pre_date = "";
                    if (this.calSchedule.SelectedDays.Count > 0)
                        jinryo_pre_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                    this.SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));
                    this.grdOUT1001_AM.QueryLayout(true);
                    this.grdOUT1001_PM.QueryLayout(true);
                    LoadBookingClinicRefer();
                }
            }
            else if (e.ColName == "comment_button")
            {
                if (e.DataRow["bunho"].ToString() == "")
                    return;

                Hashtable ht = new Hashtable();
                ht.Add("open_mode", "MODIFY");
                ht.Add("bunho", e.DataRow["bunho"].ToString());
                ht.Add("pkout1001", e.DataRow["pkout1001"].ToString());
                ht.Add("gwa", this.cboGwa.GetDataValue());
                ht.Add("doctor", this.fbxDoctor.GetDataValue());
                ht.Add("reser_comment", e.DataRow["reser_comment"].ToString());
                ht.Add("reser_gubun", e.DataRow["reser_gubun"].ToString());
                ht.Add("jinryo_pre_date", e.DataRow["jinryo_pre_date"].ToString());
                ht.Add("jinryo_pre_time", e.DataRow["jinryo_pre_time"].ToString());

                ReserCommentForm rcf = new ReserCommentForm(ht, this.mHospCodeLink, this.tabIsAll);
                rcf.ShowDialog(this);
                //grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                LoadBookingClinicRefer();
            }
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                //case FunctionType.Update:
                //    if (SaveGrids())
                //    {
                //        string jinryo_pre_date = "";
                //        if (this.calSchedule.SelectedDays.Count > 0)
                //            jinryo_pre_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                //        if (mDoctor != "")
                //        {
                //            this.SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));

                //            this.grdOUT1001_AM.QueryLayout(true);
                //            this.grdOUT1001_PM.QueryLayout(true);
                //        }

                //    }
                //    else
                //    {
                //        mbxMsg = "保存に失敗しました。" : "저장이 실패하였습니다.";
                //        mbxMsg = mbxMsg + Service.ErrFullMsg;
                //        mbxCap = "保存失敗" : "Save Error";
                //        XMessageBox.Show(mbxMsg, mbxCap);                    
                //    }

                //    break;

                //case FunctionType.Delete:

                //    break;

                case FunctionType.Query:
                    xGrid1.QueryLayout(true);
                    mDoctor = this.fbxDoctor.GetDataValue().Trim();

                    if (mDoctor == "")
                        return;

                    SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));

                    this.grdDeleteOUT1001.Reset();

                    if (calSchedule.SelectedDays.Count < 1) return;

                    //원래 주석
                    //if (!TypeCheck.IsNull(mCurrentDate))
                    //{
                    grdOUT1001_AM.QueryLayout(true);
                    grdOUT1001_PM.QueryLayout(true);
                    //}
                    LoadBookingClinicRefer();
                    break;
                default:

                    break;
            }
        }
        /// <summary>
        /// Insert한 Row 중에 Not Null필드 미입력 Row Search
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다..
        /// </remarks>
        /// <param name="aGrd"> XEditGrid  </param>
        /// <returns> celReturn.RowNumber < 0 미입력데이타 없음 </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added &&
                            TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }

            }

            return celReturn;
        }

        public bool Send_IF(XEditGrid grd, int rowIndex, string proc_gubun)
        {
            #region deleted by Cloud

            // Nextop Demo のため修正 20141006
            return true;

            //ArrayList inputList = new ArrayList();
            //ArrayList outputList = new ArrayList();

            ///*
            //    I_HOSP_CODE         IN          VARCHAR2
            //  , I_PKOUT1001         IN          VARCHAR2
            //  , I_PROC_GUBUN        IN          VARCHAR2
            //  , I_YOYAKU_GUBUN      IN          VARCHAR2
            //  , I_IO_GUBUN          IN          VARCHAR2
            //  , I_USER_ID           IN          VARCHAR2
            //  , I_BUNHO             IN          VARCHAR2
            //  , I_GWA               IN          VARCHAR2
            //  , I_DOCTOR            IN          VARCHAR2
            //  , I_NAEWON_DATE       IN          VARCHAR2             
            //  , I_JUBSU_TIME        IN          VARCHAR2
            //*/

            //inputList.Add(EnvironInfo.HospCode);
            //inputList.Add(grd.GetItemString(rowIndex, "pkout1001"));
            //inputList.Add(proc_gubun);
            //inputList.Add("1");
            //inputList.Add("O");
            //inputList.Add(UserInfo.UserID);
            //inputList.Add(mBunho);
            //inputList.Add(mGwa);
            //inputList.Add(mDoctor);
            //inputList.Add(grd.GetItemDateTime(rowIndex, "jinryo_pre_date").ToString("yyyyMMdd"));
            //inputList.Add(grd.GetItemString(rowIndex, "jinryo_pre_time"));


            //if (!Service.ExecuteProcedure("PR_IFS_MAKE_YOYAKU", inputList, outputList))
            //{
            //    XMessageBox.Show("IFS1002 Make error" + Service.ErrFullMsg);
            //    return false;
            //}

            //if (TypeCheck.IsNull(outputList[0]))
            //{
            //    return false;
            //}

            //else
            //{
            //    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            //    string msgText = "";

            //    msgText = "10111" + outputList[0].ToString();

            //    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            //    if (ret == -1)
            //    {
            //        XMessageBox.Show("Reser data Send Error：" + msgText);
            //        return false;
            //    }
            //    return true;
            //}

            #endregion

            // updated by Cloud
            //RES1001U00PrIFSMakeYoyakuArgs args = new RES1001U00PrIFSMakeYoyakuArgs();
            //args.HospCode            = UserInfo.HospCode;
            //args.Pkout1001           = grd.GetItemString(rowIndex, "pkout1001");
            //args.ProcGubun           = proc_gubun;
            //args.YoyakuGubun         = "1";
            //args.IoGubun             = "O";
            //args.UserId              = UserInfo.UserID;
            //args.Bunho               = mBunho;
            //args.Gwa                 = mGwa;
            //args.Doctor              = mDoctor;
            //args.NaewonDate          = grd.GetItemDateTime(rowIndex, "jinryo_pre_date").ToString("yyyyMMdd");
            //args.JubsuTime           = grd.GetItemString(rowIndex, "jinryo_pre_time");
            //RES1001U00PrIFSMakeYoyakuResult res = CloudService.Instance.Submit<RES1001U00PrIFSMakeYoyakuResult, RES1001U00PrIFSMakeYoyakuArgs>(args);

            //if (!TypeCheck.IsNull(res.ErrMsg))
            //{
            //    XMessageBox.Show(res.ErrMsg);
            //    return false;
            //}

            //if (TypeCheck.IsNull(res.Pkifs1002))
            //{
            //    return false;
            //}

            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            //    string msgText = "";

            //    msgText = "10111" + res.Pkifs1002;

            //    int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            //    if (ret == -1)
            //    {
            //        XMessageBox.Show("Reser data Send Error：" + msgText);
            //        return false;
            //    }
            //    return true;
            //}
        }

        private void InsertReserData(XEditGrid grd, int rowIndex)
        {
            //현재 등록이 되어 있는지 check한다.
            checkInsertSS = false;

            if (TypeCheck.IsNull(mBunho)) return;

            if (rowIndex < 0) return;

            if (grd.GetItemString(rowIndex, "bunho") != "") return;

            if (DoubleReser(grdOUT1001_AM, mBunho))
                return;

            if (DoubleReser(grdOUT1001_PM, mBunho))
                return;

            if (TypeCheck.IsNull(mGwa)) return;
            if (TypeCheck.IsNull(mDoctor)) return;

            if (grd.CurrentRowNumber < 0 || calSchedule.SelectedDays.Count < 1)
            {
                mbxMsg = Resources.MSG003_MSG;
                mbxCap = Resources.MSG003_CAP;
                XMessageBox.Show(mbxMsg, mbxCap);
                return;
            }

            if (UserInfo.UserGubun != UserType.Doctor)
            {
                if (this.txtUser.Text == "")
                {
                    //XMessageBox.Show("予約者IDを登録してください。", "予約者ID", MessageBoxIcon.Information);
                    //this.txtUser.Focus();
                    //return;
                }
            }

            string jinryo_pre_date = this.calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");


            if (
                !CheckCanReser(this.calSchedule.SelectedDays[0].Date.ToString("yyyyMMdd"),
                    grd.GetItemString(rowIndex, "jinryo_pre_time"), mDoctor, mGwa))
                return;

            grd.SetItemValue(rowIndex, "res_gubun", "2"); //3티어 소스에 하드코딩
            grd.SetItemValue(rowIndex, "changgu", mChanggu); // 3티어 소스에 OCSO로하드코딩
            grd.SetItemValue(rowIndex, "gwa", mGwa);
            grd.SetItemValue(rowIndex, "doctor", mDoctor);
            grd.SetItemValue(rowIndex, "bunho", mBunho);
            grd.SetItemValue(rowIndex, "suname", paBox.SuName);
            grd.SetItemValue(rowIndex, "suname2", paBox.SuName2);
            grd.SetItemValue(rowIndex, "gubun", paBox.Gubun);
            grd.SetItemValue(rowIndex, "input_gubun", mInput_gubun);
            grd.SetItemValue(rowIndex, "reser_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            grd.SetItemValue(rowIndex, "chojae", "4");

            //string cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM DUAL";
            //object t_pkout1001 = Service.ExecuteScalar(cmdText);

            NuroOUT1001U01GetOut1001SeqArgs args = new NuroOUT1001U01GetOut1001SeqArgs();
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;
            NuroOUT1001U01GetOut1001SeqResult result = CloudService.Instance
                .Submit<NuroOUT1001U01GetOut1001SeqResult, NuroOUT1001U01GetOut1001SeqArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                checkInsertSS = true;
            }
            object t_pkout1001 = null;
            if (result != null)
            {
                t_pkout1001 = result.Out1001SeqValue;
            }

            if (TypeCheck.IsNull(t_pkout1001)) return;

            grd.SetItemValue(rowIndex, "pkout1001", t_pkout1001.ToString());

            //if(mInput_gubun == "D")
            //    grd.SetItemValue(rowIndex, "chojae", "4");                
            //else
            //    grd.SetItemValue(rowIndex, "chojae", "4");

            if (!Send_IF(grd, rowIndex, "I"))
            {
                ResetColumnValue(grd, rowIndex);
            }


            /*
             * 예약 코멘트 로직추가
             * 여기서 받아뒀다가 저장끝나면 예약 코멘트 테이블에 인서트
             * 무조건팝업아니라 과를 봐서 팝업시킴
             */
            //Hashtable ht = new Hashtable();
            //ht.Add("open_mode", "NEW");
            //ht.Add("bunho", mBunho);
            //ht.Add("pkout1001", "");
            //ht.Add("gwa", mGwa);
            //ht.Add("doctor", mDoctor);
            //ht.Add("reser_comment", "");
            //ht.Add("reser_gubun", "");
            //ht.Add("jinryo_pre_date", "");
            //ht.Add("jinryo_pre_time", "");
            //ReserCommentForm rcf = new ReserCommentForm(ht);
            //rcf.ShowDialog(this);

            //if(rcf.ReserComment != "")
            //    grd.SetItemValue(rowIndex, "reser_comment", rcf.ReserComment);

            //if (rcf.ReserGubun != "")
            //    grd.SetItemValue(rowIndex, "reser_gubun", rcf.ReserGubun);


            /////////////////////////////////////////////////

            if (!SaveReserInfo("0")) // 0 Insert Booking
                ResetColumnValue(grd, rowIndex);

        }

        private bool CheckCanReser(string aJinryo_pre_date, string aJinryo_pre_time, string doctor, string gwa)
        {
            bool chkCan = false;

            this.layCommon.Reset();
            //this.layCommon.QuerySQL = @"SELECT FN_OUT_CHECK_DOCTOR_JINRYO('RES', TO_DATE(:f_Jinryo_pre_date, 'YYYYMMDD'), :f_Jinryo_pre_time , :f_doctor) FROM DUAL ";

            List<string> param = new List<string>();
            param.Add("f_Jinryo_pre_date");
            param.Add("f_Jinryo_pre_time");
            param.Add("f_doctor");

            layCommon.ParamList = param;
            layCommon.ExecuteQuery = LayCheckCanReser;

            this.layCommon.LayoutItems.Clear();
            this.layCommon.LayoutItems.Add("can");

            this.layCommon.SetBindVarValue("f_Jinryo_pre_date", aJinryo_pre_date);
            this.layCommon.SetBindVarValue("f_Jinryo_pre_time", aJinryo_pre_time);
            this.layCommon.SetBindVarValue("f_doctor", doctor);
            this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);

            if (this.layCommon.QueryLayout())
            {
                if (!TypeCheck.IsNull(this.layCommon.GetItemValue("can")))
                {
                    if (layCommon.GetItemValue("can").ToString() == "0")
                        chkCan = true;
                    else if (layCommon.GetItemValue("can").ToString() == "9")
                        chkCan = false;
                    else if (layCommon.GetItemValue("can").ToString() == "8")
                    {
                        JubsuCheckForm checkForm = new JubsuCheckForm(aJinryo_pre_date, doctor, gwa);

                        if (checkForm.ShowDialog() == DialogResult.Yes)
                            chkCan = true;
                        else
                            chkCan = false;
                    }
                    else
                        chkCan = false;
                }
            }
            else
                chkCan = false;

            return chkCan;
        }

        private IList<object[]> LayCheckCanReser(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            NuroRES1001U00DoctorExamStatusArgs args = new NuroRES1001U00DoctorExamStatusArgs();

            args.Type = "RES";
            args.DoctorCode = list["f_doctor"].VarValue;
            args.ExamPreDate = list["f_Jinryo_pre_date"].VarValue;
            args.ExamPreTime = list["f_Jinryo_pre_time"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00DoctorExamStatusResult result =
                CloudService.Instance.Submit<NuroRES1001U00DoctorExamStatusResult, NuroRES1001U00DoctorExamStatusArgs>(
                    args);

            if (result != null)
            {
                object[] objects = { result.DoctorExamStatus };
                data.Add(objects);
            }
            return data;
        }

        private void DeleteReserData(XEditGrid grd, int rowIndex)
        {
            if (rowIndex < 0) return;

            if (grd.GetItemString(rowIndex, "bunho") == "" && mBunho == string.Empty) return;
            string preTime1 = (grd.GetItemString(rowIndex, "jinryo_pre_time") + ":00").Insert(2, ":");

            if (grd.GetItemString(rowIndex, "naewon_yn") != "N")
            {
                XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                return;
            }

            mbxMsg = Resources.MSG005_MSG;
            mbxCap = Resources.MSG005_CAP;
            //if (msgOutput != null && msgOutput.Length > 1 && Array.IndexOf(msgOrca, msgOutput.Substring(0, 2)) > -1)
            //{
                if (XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
                //if (!checkBookingDel(preTime1)) return;
            //}

            //삭제건은 Delete Table로 넘긴다.
            if (grd.GetItemString(rowIndex, "newrow") == "N")
            {
                if (grdDeleteOUT1001.DeletedRowTable != null
                    &&
                    grdDeleteOUT1001.DeletedRowTable.Select(
                        " pkout1001 = '" + grd.GetItemString(rowIndex, "pkout1001") + "' ", "").Length == 0)
                {
                    grdDeleteOUT1001.LayoutTable.ImportRow(grd.LayoutTable.Rows[rowIndex]);
                    grdDeleteOUT1001.DisplayData();
                    grdDeleteOUT1001.DeleteRow(0);
                }
                else if (grdDeleteOUT1001.DeletedRowTable == null)
                {
                    grdDeleteOUT1001.LayoutTable.ImportRow(grd.LayoutTable.Rows[rowIndex]);
                    grdDeleteOUT1001.DisplayData();
                    grdDeleteOUT1001.DeleteRow(0);
                }
            }
            //isReseveDeleted = true;

            if (!Send_IF(grd, rowIndex, "D"))
            {
                ResetColumnValue(grd, rowIndex);
            }

            grd.SetItemValue(rowIndex, "res_gubun", "");
            grd.SetItemValue(rowIndex, "changgu", "");
            grd.SetItemValue(rowIndex, "bunho", "");
            grd.SetItemValue(rowIndex, "suname", "");
            grd.SetItemValue(rowIndex, "suname2", "");
            grd.SetItemValue(rowIndex, "gubun", "");
            grd.SetItemValue(rowIndex, "reser_date", "");
            grd.SetItemValue(rowIndex, "chojae", "");
            grd.SetItemValue(rowIndex, "input_gubun", "Z");
            grd.SetItemValue(rowIndex, "newrow", "Y");
            grd.SetItemValue(rowIndex, "reser_comment", "");
            grd.SetItemValue(rowIndex, "reser_gubun", "");

            if (!SaveReserInfo("3")) //3 Delete Booking
            {
                grd.SetItemValue(rowIndex, "res_gubun", grdDeleteOUT1001.GetItemString(0, "res_gubun"));
                grd.SetItemValue(rowIndex, "changgu", grdDeleteOUT1001.GetItemString(0, "changgu"));
                grd.SetItemValue(rowIndex, "bunho", grdDeleteOUT1001.GetItemString(0, "bunho"));
                grd.SetItemValue(rowIndex, "suname", grdDeleteOUT1001.GetItemString(0, "suname"));
                grd.SetItemValue(rowIndex, "suname2", grdDeleteOUT1001.GetItemString(0, "suname2"));
                grd.SetItemValue(rowIndex, "gubun", grdDeleteOUT1001.GetItemString(0, "gubun"));
                grd.SetItemValue(rowIndex, "reser_date", grdDeleteOUT1001.GetItemString(0, "reser_date"));
                grd.SetItemValue(rowIndex, "chojae", grdDeleteOUT1001.GetItemString(0, "chojae"));
                grd.SetItemValue(rowIndex, "input_gubun", grdDeleteOUT1001.GetItemString(0, "input_gubun"));
                grd.SetItemValue(rowIndex, "newrow", grdDeleteOUT1001.GetItemString(0, "newrow"));
                grd.SetItemValue(rowIndex, "reser_comment", grdDeleteOUT1001.GetItemString(0, "reser_comment"));
                grd.SetItemValue(rowIndex, "reser_gubun", grdDeleteOUT1001.GetItemString(0, "reser_gubun"));
                grd.ResetUpdate();

                grdDeleteOUT1001.Reset();
            }
        }

        private void ResetColumnValue(XEditGrid grd, int rowIndex)
        {
            grd.SetItemValue(rowIndex, "res_gubun", "");
            grd.SetItemValue(rowIndex, "changgu", "");
            grd.SetItemValue(rowIndex, "bunho", "");
            grd.SetItemValue(rowIndex, "suname", "");
            grd.SetItemValue(rowIndex, "suname2", "");
            grd.SetItemValue(rowIndex, "gubun", "");
            grd.SetItemValue(rowIndex, "reser_date", "");
            grd.SetItemValue(rowIndex, "chojae", "");
            grd.SetItemValue(rowIndex, "input_gubun", "Z");
            grd.SetItemValue(rowIndex, "newrow", "Y");
            grd.SetItemValue(rowIndex, "reser_comment", "");
            grd.SetItemValue(rowIndex, "reser_gubun", "");
            grd.SetItemValue(rowIndex, "pkout1001", "");

            DisplayResGubun(grd, rowIndex);
        }

        private bool DoubleReser(XEditGrid grd, string aBunho)
        {
            bool ReturnValue = false;

            // 조건조회로 Data를 가져오는 경우 아래경우 다 check
            // 중복 Check
            // 현재 화면
            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetItemString(i, "bunho").Trim() == aBunho)
                {
                    mbxMsg = Resources.MSG006_MSG;
                    mbxCap = Resources.MSG006_CAP;
                    XMessageBox.Show(mbxMsg, mbxCap);
                    ReturnValue = true;
                }
            }
            return ReturnValue;
        }

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            mBunho = paBox.BunHo;

            //clear bunho link if change patient
            mBunhoLink = "";
            btnClear.PerformClick();
            this.fbxLinkHospCode.Clear();
            this.dbxLinkHospName.Text = "";
            this.mHospCodeLink = "";

            //using mBunho to switch bunho between 2 tabs
            this.rbtMyClinic.Checked = true;

            this.xGrid1.QueryLayout(true);

        }

        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            mBunho = "";

            //clear bunho link if change patient
            mBunhoLink = "";
            btnClear.PerformClick();

            //using mBunho to switch bunho between 2 tabs
            this.rbtMyClinic.Checked = true;

            this.xGrid1.QueryLayout(true);
        }

        private void cboGwa_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //ClearControl();
            mGwa = cboGwa.SelectedValue.ToString();
            this.fbxDoctor.SetEditValue("");
            this.fbxDoctor.AcceptData();
            this.fbxDoctor.Focus();
            this.fbxDoctor.SelectAll();
        }
        
        private void fbxDoctor_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {

         
            if (TypeCheck.IsNull(this.cboGwa.GetDataValue().Trim()))
            {
                dbxDoctor_name.SetEditValue("");
                return;
            }
            if (TypeCheck.IsNull(e.DataValue.ToString().Trim()))
            {
                dbxDoctor_name.SetEditValue("");
                return;
            }
            //Check Origin Data
            string codeName = this.GetCodeName("doctor_name", e.DataValue.ToString());

            if (TypeCheck.IsNull(codeName))
            {
                mbxMsg = Resources.MSG007_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;

            }
            else if (codeName == "XXX")
            {
                mbxMsg = Resources.MSG007_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;
            }
            else if (codeName == "NO_RESER")
            {
                mbxMsg = Resources.MSG008_MSG;
                mbxCap = "";
                XMessageBox.Show(mbxMsg, mbxCap);
                e.Cancel = true;
            }
            else
            {
                dbxDoctor_name.SetEditValue(codeName);

                mDoctor = e.DataValue.ToString().Trim();
                SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));
               this.grdDeleteOUT1001.Reset();

                if (calSchedule.SelectedDays.Count < 1) return;

                //원래 주석
                //if (!TypeCheck.IsNull(mCurrentDate))
                //{
                grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                LoadBookingClinicRefer();
                //}               
            }          
        }
   
        private const string CACHE_COMBODOCTOR_KEYS = "Nuro.RES1001U00.CmbDoctor";

        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "doctor_name":

                    string gwa = cboGwa.GetDataValue();

                    if (TypeCheck.IsNull(gwa))
                    {
                        codeName = "XXX";
                        break;
                    }

                    // BAS0270에서 RESER_YN = Y 인 의사만 가능하도록
                    this.layCommon.Reset();

                    //                    this.layCommon.QuerySQL = @"SELECT A.DOCTOR_NAME   
                    //                                                     , NVL(A.RESER_YN, 'N')    RESER_YN                                       
                    //                                                 FROM BAS0270 A                                                       
                    //                                                WHERE A.HOSP_CODE  = :f_hosp_code
                    //                                                  AND A.DOCTOR     = :f_doctor
                    //                                                  AND A.DOCTOR_GWA = :f_gwa
                    //                                                  --AND NVL(A.RESER_YN, 'N') = 'Y'
                    //                                                  AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE ";
                    List<string> param = new List<string>();
                    param.Add("f_doctor");
                    param.Add("f_gwa");


                    layCommon.ParamList = param;
                    layCommon.ExecuteQuery = LoadDoctor;

                    this.layCommon.LayoutItems.Clear();
                    this.layCommon.LayoutItems.Add("doctor_name");
                    this.layCommon.LayoutItems.Add("reser_yn");

                    this.layCommon.SetBindVarValue("f_hosp_code", this.mHospCode);
                    this.layCommon.SetBindVarValue("f_doctor", code);
                    this.layCommon.SetBindVarValue("f_gwa", gwa);

                    this.layCommon.QueryLayout();

                    codeName = "";

                    if (this.layCommon.GetItemValue("reser_yn").ToString() != "Y")
                    {
                        codeName = "NO_RESER";
                        return codeName;
                    }

                    if (!TypeCheck.IsNull(this.layCommon.GetItemValue("doctor_name")))
                        codeName = layCommon.GetItemValue("doctor_name").ToString();

                    break;

                default:
                    break;
            }

            return codeName;
        }

        private IList<object[]> LoadDoctor(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            NuroRES1001U00DoctorReservationStatusListArgs args = new NuroRES1001U00DoctorReservationStatusListArgs();
            args.DepartmentCode = list["f_gwa"].VarValue;
            args.DoctorCode = list["f_doctor"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00DoctorReservationStatusListResult result = CloudService.Instance
                .Submit<NuroRES1001U00DoctorReservationStatusListResult, NuroRES1001U00DoctorReservationStatusListArgs>(
                    args);

            if (result != null)
            {
                foreach (NuroRES1001U00DoctorReservationStatusListItemInfo items in result.DoctorResStatusListItem)
                {
                    object[] objects =
                    {
                        items.DoctorName,
                        items.ReservationStatus
                    };

                    data.Add(objects);
                }
            }
            return data;
        }

        private void ClearControl()
        {
            calSchedule.SuspendLayout();
            //Calendar Clear
            calSchedule.Dates.Clear();
            calSchedule.ResumeLayout();

            layOCS0105.Reset();
            grdDeleteOUT1001.Reset();
            grdOUT1001_AM.Reset();
            grdOUT1001_PM.Reset();

        }

        private void grdRES1001_AM_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            //e.Cancel = false;

            //string chktime = "";

            //switch (e.ColName)
            //{
            //    case "jinryo_pre_time":

            //        if (e.ChangeValue.ToString().Length != 4)
            //        {
            //            mbxMsg = "時間を確認してください。(午前)" : "시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }

            //        chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

            //        if (!TypeCheck.IsDateTime("2006/04/01 " + chktime))
            //        {
            //            mbxMsg = "時間を確認してください。(午前)" : "시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }

            //        if (int.Parse(e.ChangeValue.ToString()) < this.AM_START_TIME || int.Parse(e.ChangeValue.ToString()) > AM_END_TIME)
            //        {
            //            mbxMsg = "時間を確認してください。(午前)" : "오전시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }

            //        break;

            //    default:
            //        break;
            //}        
        }

        private void grdRES1001_PM_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            //e.Cancel = false;

            //string chktime = "";

            //switch (e.ColName)
            //{
            //    case "jinryo_pre_time":

            //        if(e.ChangeValue.ToString() == "") return;

            //        if(e.ChangeValue.ToString().Length != 4)
            //        {
            //            mbxMsg = "時間を確認してください。(午後)" : "시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }

            //        chktime = e.ChangeValue.ToString().Substring(0, 2) + ":" + e.ChangeValue.ToString().Substring(2, 2);

            //        if(!TypeCheck.IsDateTime("2006/04/01 " + chktime))
            //        {
            //            mbxMsg = "時間を確認してください。(午後)" : "시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }                    

            //        if( int.Parse(e.ChangeValue.ToString()) < this.PM_START_TIME || int.Parse(e.ChangeValue.ToString()) > PM_END_TIME )
            //        {
            //            mbxMsg = "時間を確認してください。(午後)" : "오후시간을 확인하세요.";
            //            mbxCap = "" : "";
            //            XMessageBox.Show(mbxMsg, mbxCap);
            //            e.Cancel = true;
            //            break;
            //        }

            //        break;

            //    default:
            //        break;
            //}        
        }

        //private void grdRES1001_AM_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //XEditGrid grd = sender as XEditGrid;

        //int curRowIndex = -1;
        //curRowIndex = grd.GetHitRowNumber(e.Y);
        //if( curRowIndex < 0 ) return;

        //// 진료의뢰에서 저장된 예약건이거나 현재 진료의로에서 오픈중인경우에는 별도 로직
        //if ((this.grdOUT1001_AM.GetItemString(curRowIndex, "jinryo_irai_yn") != "Y") && (this.mCallerName != "OCS0503U00"))
        //{
        //    if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        if (grd.GetItemString(curRowIndex, "bunho") != "")
        //            DeleteReserData(grd, curRowIndex);
        //        else
        //        {
        //            if (grd.GetItemString(curRowIndex, "jinryo_yn") == "Y")
        //                InsertReserData(grd, curRowIndex);
        //            else
        //            {
        //                mbxMsg = "選択している日付は休診登録されているので予約出来ません。診療スケジュールを確認してください。" : "선택한 시간은 휴진입니다. 진료스케쥴을 확인하세요.";
        //                mbxCap = "" : "";
        //                XMessageBox.Show(mbxMsg, mbxCap);
        //            }
        //        }

        //    }
        //    else if (e.Button == MouseButtons.Left && e.Clicks == 1)
        //    {
        //        if (grd.GetItemString(curRowIndex, "bunho") == "") return;

        //        if (grd.CurrentColName != "modify")
        //        {
        //            string dragInfo = "[" + grd.GetItemString(curRowIndex, "bunho") + "]" + grd.GetItemString(curRowIndex, "suname");
        //            DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
        //            grd.DoDragDrop("AM" + "|" + curRowIndex.ToString(), DragDropEffects.Move);
        //        }
        //    }
        //}
        //else
        //{
        //    if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        string p_bunho = grd.GetItemString(curRowIndex, "bunho");
        //        string p_gwa = grd.GetItemString(curRowIndex, "gwa");
        //        string p_doctor = grd.GetItemString(curRowIndex, "doctor");
        //        string p_reser_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");
        //        string p_reser_time = grd.GetItemString(curRowIndex, "jinryo_pre_time");
        //        string p_irai_date = grd.GetItemString(curRowIndex, "reser_date");
        //        string p_fkout1001 = grd.GetItemString(curRowIndex, "pkres1001");

        //        //예약중인 경우 진료의뢰 화면 오픈 
        //        if (grd.GetItemString(curRowIndex, "bunho") != "")
        //        {
        //            IHIS.Framework.IXScreen aScreen;

        //            aScreen = XScreen.FindScreen("OCSA", "OCS0503U00");

        //            if (aScreen == null)
        //            {              
        //                CommonItemCollection openParams  = new CommonItemCollection();
        //                openParams.Add("bunho", p_bunho);
        //                openParams.Add("req_gwa", p_gwa);
        //                openParams.Add("req_doctor", p_doctor);
        //                openParams.Add("naewon_date", p_reser_date);
        //                openParams.Add("reser_time", p_reser_time);
        //                openParams.Add("req_date", p_irai_date);
        //                openParams.Add("naewon_key", p_fkout1001);

        //                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
        //            }
        //            else
        //            {
        //                ((XScreen)aScreen).Activate();
        //            }
        //            this.Close();

        //        }
        //        else// 예약중이 아님 == 진료의뢰에서 들어온 것임
        //        {

        //            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

        //            CommonItemCollection commandParams = new CommonItemCollection();
        //            commandParams.Add("bunho", p_bunho);
        //            commandParams.Add("gwa", p_gwa);
        //            commandParams.Add("doctor", p_doctor);
        //            commandParams.Add("naewon_date", p_reser_date);
        //            commandParams.Add("reser_time", p_reser_time);

        //            scrOpener.Command(ScreenID, commandParams);

        //            this.Close();
        //        }
        //    }
        //}
        //}

        private void grdRES1001_AM_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Client Point
            string fromPosition = e.Data.GetData("System.String").ToString().Split('|')[0];
            int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);

            //disable editing if user editing row from outside hospital
            XEditGrid grd = sender as XEditGrid;
            if (!String.IsNullOrEmpty(grd.GetItemString(fromRowNum, "clinic_name")) && grd.GetItemString(fromRowNum, "clinic_name") != UserInfo.HospName) return;

            Point clientPoint = grdOUT1001_AM.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grdOUT1001_AM.GetHitRowNumber(clientPoint.Y);
            string ToTime = "";
            string FromTime = "";
            if (fromPosition == "AM")
            {
                //같은 grid내에서는 위치바꿈

                if (toRowNum == fromRowNum || toRowNum < 0)
                {
                    //Edit상태로 만든다.
                    grdOUT1001_AM.SetFocusToItem(toRowNum, grdOUT1001_AM.CurrentColNumber);
                    return;
                }

                //이미 등록된 건이 있는 경우에는 return
                if (grdOUT1001_AM.GetItemString(toRowNum, "bunho") != "") return;

                //같은 시간인 경우 return;
                if (grdOUT1001_AM.GetItemString(toRowNum, "jinryo_pre_time") ==
                    grdOUT1001_AM.GetItemString(fromRowNum, "jinryo_pre_time")) return;

                //휴진인 경우 return;
                if (grdOUT1001_AM.GetItemString(toRowNum, "jinryo_yn") == "N")
                {
                    mbxMsg = Resources.MSG009_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    return;
                }

                if (!Send_IF(grdOUT1001_AM, fromRowNum, "D"))
                {
                    XMessageBox.Show(Resources.MSG010_MSG);
                    grdOUT1001_AM.QueryLayout(true);
                    grdOUT1001_PM.QueryLayout(true);
                    LoadBookingClinicRefer();
                    xGrid1.QueryLayout(true);
                    return;
                }

                foreach (DataColumn col in grdOUT1001_AM.LayoutTable.Columns)
                {
                    //시간은 그대로 둔다.
                    if (col.ColumnName == "jinryo_pre_time") continue;

                    grdOUT1001_AM.SetItemValue(toRowNum, col.ColumnName,
                        grdOUT1001_AM.GetItemValue(fromRowNum, col.ColumnName));
                }

                ResetColumnValue(grdOUT1001_AM, fromRowNum);

                mBunho = grdOUT1001_AM.GetItemString(toRowNum, "bunho");
                //FromTime = (grdOUT1001_AM.GetItemString(fromRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
                //ToTime = (grdOUT1001_AM.GetItemString(toRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
                //if (!CheckDragDropOrca(FromTime, ToTime))
                //{
                //    return;
                //}

            }
            else
            {

                //grid가 다른 경우에는 Row trans
                //position 변경
                //이미 등록된 건이 있는 경우에는 return
                if (grdOUT1001_AM.GetItemString(toRowNum, "bunho") != "") return;

                //휴진인 경우 return;
                if (grdOUT1001_AM.GetItemString(toRowNum, "jinryo_yn") == "N")
                {
                    mbxMsg = Resources.MSG009_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    return;
                }

                if (!Send_IF(grdOUT1001_PM, fromRowNum, "D"))
                {
                    XMessageBox.Show(Resources.MSG010_MSG);
                    grdOUT1001_AM.QueryLayout(true);
                    grdOUT1001_PM.QueryLayout(true);
                    LoadBookingClinicRefer();
                    xGrid1.QueryLayout(true);
                    return;
                }

                foreach (DataColumn col in grdOUT1001_AM.LayoutTable.Columns)
                {
                    //시간은 그대로 둔다.
                    if (col.ColumnName == "jinryo_pre_time") continue;

                    grdOUT1001_AM.SetItemValue(toRowNum, col.ColumnName,
                        grdOUT1001_PM.GetItemValue(fromRowNum, col.ColumnName));
                }

                ResetColumnValue(grdOUT1001_PM, fromRowNum);

                mBunho = grdOUT1001_AM.GetItemString(toRowNum, "bunho");

                grdOUT1001_AM.SetFocusToItem(toRowNum, 0);

            }
            //ToTime = (grdOUT1001_AM.GetItemString(toRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
            //FromTime = (grdOUT1001_PM.GetItemString(fromRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
            //if (!CheckDragDropOrca(FromTime, ToTime))
            //{
            //    return;
            //}
            if (!Send_IF(grdOUT1001_AM, toRowNum, "I"))
            {
                XMessageBox.Show(Resources.MSG011_MSG);
                grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                LoadBookingClinicRefer();
                xGrid1.QueryLayout(true);
                return;
            }

            if (!SaveReserInfo("1")) //2 Change Booking
            {
                grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                LoadBookingClinicRefer();
                xGrid1.QueryLayout(true);
            }


        }

        private void grdRES1001_AM_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (dragFrom == "")
            {
                dragFrom = "AM";
                int curRowIndex = -1;
                Point clientPoint = grdOUT1001_AM.PointToClient(new Point(e.X, e.Y));
                curRowIndex = grdOUT1001_AM.GetHitRowNumber(clientPoint.Y);
                if (grdOUT1001_AM.GetItemString(curRowIndex, "clinic_name") == UserInfo.HospName)
                {
                    e.Effect = DragDropEffects.Move; // Move í‘œì‹œ   
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
                //int curRowIndex = -1;
                //curRowIndex = grdOUT1001_AM.GetHitRowNumber(e.Y);
                //if (grdOUT1001_AM.GetItemString(curRowIndex, "clinic_name") == UserInfo.HospName)
                //{
                //    e.Effect = DragDropEffects.Move; // Move 표시   
                //}
                //else
                //{
                //    e.Effect = DragDropEffects.None;
                //}
            
        }

        private void grdRES1001_AM_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        #region [grdRES1001_PM_MouseDown 주석처리]

        //private void grdRES1001_PM_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //XEditGrid grd = sender as XEditGrid;

        //int curRowIndex = -1;
        //curRowIndex = grd.GetHitRowNumber(e.Y);
        //if (curRowIndex < 0) return;

        //// 진료의뢰에서 저장된 예약건이거나 현재 진료의로에서 오픈중인경우에는 별도 로직
        //if ((this.grdOUT1001_PM.GetItemString(curRowIndex, "jinryo_irai_yn") != "Y") && (this.mCallerName != "OCS0503U00"))
        //{
        //    if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        if (grd.GetItemString(curRowIndex, "bunho") != "")
        //            DeleteReserData(grd, curRowIndex);
        //        else
        //        {
        //            if (grd.GetItemString(curRowIndex, "jinryo_yn") == "Y")
        //                InsertReserData(grd, curRowIndex);
        //            else
        //            {
        //                mbxMsg = "選択している日付は休診登録されているので予約出来ません。診療スケジュールを確認してください。" : "선택한 시간은 휴진입니다. 진료스케쥴을 확인하세요.";
        //                mbxCap = "" : "";
        //                XMessageBox.Show(mbxMsg, mbxCap);
        //            }
        //        }

        //    }
        //    else if (e.Button == MouseButtons.Left && e.Clicks == 1)
        //    {
        //        if (grd.GetItemString(curRowIndex, "bunho") == "") return;

        //        if (grd.CurrentColName != "modify")//예약변경클릭시 안먹는 경우가 있어서 추가
        //        {
        //            string dragInfo = "[" + grd.GetItemString(curRowIndex, "bunho") + "]" + grd.GetItemString(curRowIndex, "suname");
        //            DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
        //            grd.DoDragDrop("PM" + "|" + curRowIndex.ToString(), DragDropEffects.Move);
        //        }
        //    }
        //}
        //else// 진료의뢰에서 저장된 예약건이거나 현재 진료의로에서 오픈중인경우 로직
        //{
        //    if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        string p_bunho = grd.GetItemString(curRowIndex, "bunho");
        //        string p_gwa = grd.GetItemString(curRowIndex, "gwa");
        //        string p_doctor = grd.GetItemString(curRowIndex, "doctor");
        //        string p_reser_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");
        //        string p_reser_time = grd.GetItemString(curRowIndex, "jinryo_pre_time");
        //        string p_irai_date = grd.GetItemString(curRowIndex, "reser_date");
        //        string p_fkout1001 = grd.GetItemString(curRowIndex, "pkres1001");

        //        //예약중이면 화면오픈
        //        if (grd.GetItemString(curRowIndex, "bunho") != "")
        //        {
        //            IHIS.Framework.IXScreen aScreen;

        //            aScreen = XScreen.FindScreen("OCSA", "OCS0503U00");

        //            if (aScreen == null)
        //            {
        //                CommonItemCollection openParams = new CommonItemCollection();
        //                openParams.Add("bunho", p_bunho);
        //                openParams.Add("req_gwa", p_gwa);
        //                openParams.Add("req_doctor", p_doctor);
        //                openParams.Add("naewon_date", p_reser_date);
        //                openParams.Add("reser_time", p_reser_time);
        //                openParams.Add("req_date", p_irai_date);
        //                openParams.Add("naewon_key", p_fkout1001);

        //                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ScreenMiddleCenter, openParams);
        //            }
        //            else
        //            {   
        //                ((XScreen)aScreen).Activate();
        //            }
        //            this.Close();

        //        }
        //        else // 예약중이 아님 == 진료의뢰에서 들어온 것임
        //        {
        //            IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

        //            CommonItemCollection commandParams = new CommonItemCollection();
        //            commandParams.Add("bunho", p_bunho);
        //            commandParams.Add("gwa", p_gwa);
        //            commandParams.Add("doctor", p_doctor);
        //            commandParams.Add("naewon_date", p_reser_date);
        //            commandParams.Add("reser_time", p_reser_time);

        //            scrOpener.Command(ScreenID, commandParams);

        //            this.Close();
        //        }
        //    }
        //}
        //}

        #endregion

        private void grdRES1001_PM_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Client Point
            string fromPosition = e.Data.GetData("System.String").ToString().Split('|')[0];
            int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString().Split('|')[1]);

            //disable editing if user editing row from outside hospital
            XEditGrid grd = sender as XEditGrid;
            if (!String.IsNullOrEmpty(grd.GetItemString(fromRowNum, "clinic_name")) && grd.GetItemString(fromRowNum, "clinic_name") != UserInfo.HospName) return;

            Point clientPoint = grdOUT1001_PM.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grdOUT1001_PM.GetHitRowNumber(clientPoint.Y);
            string ToTime = "";
            string FromTime = "";
            if (fromPosition == "PM")
            {
                //같은 grid내에서는 위치바꿈

                if (toRowNum == fromRowNum || toRowNum < 0)
                {
                    //Edit상태로 만든다.
                    grdOUT1001_PM.SetFocusToItem(toRowNum, grdOUT1001_AM.CurrentColNumber);
                    return;
                }

                //이미 등록된 건이 있는 경우에는 return
                if (grdOUT1001_PM.GetItemString(toRowNum, "bunho") != "") return;

                //같은 시간인 경우 return;
                if (grdOUT1001_PM.GetItemString(toRowNum, "jinryo_pre_time") ==
                    grdOUT1001_PM.GetItemString(fromRowNum, "jinryo_pre_time")) return;

                //휴진인 경우 return;
                if (grdOUT1001_PM.GetItemString(toRowNum, "jinryo_yn") == "N")
                {
                    mbxMsg = Resources.MSG009_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    return;
                }

                if (!Send_IF(grdOUT1001_PM, fromRowNum, "D"))
                {
                    XMessageBox.Show(Resources.MSG010_MSG);
                    grdOUT1001_AM.QueryLayout(true);
                    grdOUT1001_PM.QueryLayout(true);
                    xGrid1.QueryLayout(true);
                    LoadBookingClinicRefer();
                    return;
                }

                foreach (DataColumn col in grdOUT1001_PM.LayoutTable.Columns)
                {
                    //시간은 그대로 둔다.
                    if (col.ColumnName == "jinryo_pre_time") continue;

                    grdOUT1001_PM.SetItemValue(toRowNum, col.ColumnName,
                        grdOUT1001_PM.GetItemValue(fromRowNum, col.ColumnName));
                }

                ResetColumnValue(grdOUT1001_PM, fromRowNum);
                grdOUT1001_PM.SetFocusToItem(toRowNum, 0);

                //FromTime = (grdOUT1001_PM.GetItemString(fromRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
                //ToTime = (grdOUT1001_PM.GetItemString(toRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
                //if (!CheckDragDropOrca(FromTime, ToTime))
                //{
                //    return;
                //}
            }
            else
            {
                //grid가 다른 경우에는 Row trans
                //position 변경
                //이미 등록된 건이 있는 경우에는 return
                if (grdOUT1001_PM.GetItemString(toRowNum, "bunho") != "") return;

                //휴진인 경우 return;
                if (grdOUT1001_PM.GetItemString(toRowNum, "jinryo_yn") == "N")
                {
                    mbxMsg = Resources.MSG009_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);
                    return;
                }

                if (!Send_IF(grdOUT1001_AM, fromRowNum, "D"))
                {
                    XMessageBox.Show(Resources.MSG010_MSG);
                    grdOUT1001_AM.QueryLayout(true);
                    grdOUT1001_PM.QueryLayout(true);
                    xGrid1.QueryLayout(true);
                    LoadBookingClinicRefer();
                    return;
                }

                foreach (DataColumn col in grdOUT1001_PM.LayoutTable.Columns)
                {
                    //시간은 그대로 둔다.
                    if (col.ColumnName == "jinryo_pre_time") continue;

                    grdOUT1001_PM.SetItemValue(toRowNum, col.ColumnName,
                        grdOUT1001_AM.GetItemValue(fromRowNum, col.ColumnName));
                }

                ResetColumnValue(grdOUT1001_AM, fromRowNum);
                grdOUT1001_PM.SetFocusToItem(toRowNum, 0);
            }
            //ToTime = (grdOUT1001_PM.GetItemString(toRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
            //FromTime = (grdOUT1001_AM.GetItemString(fromRowNum, "jinryo_pre_time") + ":00").Insert(2, ":");
            //if (!CheckDragDropOrca(FromTime, ToTime))
            //{
            //    return;
            //}
            if (!Send_IF(grdOUT1001_PM, toRowNum, "I"))
            {
                XMessageBox.Show(Resources.MSG011_MSG);
                grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                xGrid1.QueryLayout(true);
                LoadBookingClinicRefer();
                return;
            }

            if (!SaveReserInfo("1")) //2 Change Booking
            {
                grdOUT1001_AM.QueryLayout(true);
                grdOUT1001_PM.QueryLayout(true);
                xGrid1.QueryLayout(true);
                LoadBookingClinicRefer();
            }

        }

        private void grdRES1001_PM_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (dragFrom == "")
            {
                dragFrom = "PM";
                int curRowIndex = -1;
                Point clientPoint = grdOUT1001_PM.PointToClient(new Point(e.X, e.Y));
                curRowIndex = grdOUT1001_PM.GetHitRowNumber(clientPoint.Y);
                if (grdOUT1001_PM.GetItemString(curRowIndex, "clinic_name") == UserInfo.HospName)
                {
                    e.Effect = DragDropEffects.Move; // Move í‘œì‹œ   
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }


                //int curRowIndex = -1;
                //curRowIndex = grdOUT1001_PM.GetHitRowNumber(e.Y);
                //if (grdOUT1001_PM.GetItemString(curRowIndex, "clinic_name") == UserInfo.HospName)
                //{
                //    e.Effect = DragDropEffects.Move; // Move 표시   
                //}
                //else
                //{
                //    e.Effect = DragDropEffects.None;
                //}
            
        }

        private void grdRES1001_PM_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void layReserList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //layReserList.LayoutTable.TableName = "reslist";
            ////grdReserList.DataSource = this.layReserList.LayoutTable;
            //grdReserList.Focus();

        }

        /// <summary>
        /// 예약자구분 Image Display
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <returns> void  </returns>
        private void DisplayResGubun(XEditGrid aGrd)
        {
            if (aGrd == null) return;

            try
            {
                //for (int i = 0; i < aGrd.RowCount; i++) 
                //    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;

                for (int i = 0; i < aGrd.RowCount; i++)
                {
                    aGrd[i + aGrd.HeaderHeights.Count, 0].Image = null;
                    //aGrd[i, "ipwon_image"].Image = null;

                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "input_gubun")) &&
                        aGrd[i + aGrd.HeaderHeights.Count, 0].Image == null)
                    {
                        //의사
                        if (aGrd.GetItemString(i, "input_gubun") == "D")
                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                        //간호사
                        else if (aGrd.GetItemString(i, "input_gubun") == "N")
                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                        //기타
                        else if (aGrd.GetItemString(i, "input_gubun") == "E")
                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[5];
                    }

                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "jinryo_irai_yn")))
                    {
                        if (aGrd.GetItemValue(i, "jinryo_irai_yn").ToString() == "Y")
                        {
                            aGrd[i + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[11];

                        }
                    }

                    if (!TypeCheck.IsNull(aGrd.GetItemValue(i, "ipwon_yn")))
                    {
                        if (aGrd.GetItemValue(i, "ipwon_yn").ToString() == "Y")
                        {
                            //aGrd[i, "ipwon_image"].Image = this.ImageList.Images[12];
                        }

                    }
                }
            }
            catch (Exception xe)
            {
                //XMessageBox.Show(xe.Data.ToString());
            }
        }

        private void DisplayResGubun(XEditGrid aGrd, int rowIndex)
        {
            if (aGrd == null || rowIndex < 0) return;

            try
            {
                aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = null;

                if (TypeCheck.IsNull(aGrd.GetItemString(rowIndex, "input_gubun"))) return;

                //의사
                if (aGrd.GetItemString(rowIndex, "input_gubun") == "D")
                    aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[3];
                //간호사
                else if (aGrd.GetItemString(rowIndex, "input_gubun") == "N")
                    aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[4];
                //기타
                else if (aGrd.GetItemString(rowIndex, "input_gubun") == "E")
                    aGrd[rowIndex + aGrd.HeaderHeights.Count, 0].Image = this.ImageList.Images[5];

            }
            catch
            {
            }
        }

        private bool SaveReserInfo(string bookingType)
        {
            bool returnValue = true;
            bool reserCancel = false;
            if (this.grdDeleteOUT1001.DeletedRowCount > 0)
                reserCancel = true;

            if (SaveGrids(bookingType))
            {
                //예약표 출력
                if (!reserCancel)
                {
                    mbxMsg = Resources.MSG012_MSG;
                    mbxCap = Resources.MSG012_CAP;
                    DialogResult dialogResult = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);


                    if (dialogResult == DialogResult.Yes)
                    {
                        if (NetInfo.Language != LangMode.Jr || !rbtLinkClinic.Checked)
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("auto_close", "Y");
                            openParams.Add("total_query_yn", "N");
                            //using mBunho to switch bunho between 2 tabs
                            //openParams.Add("bunho", this.paBox.BunHo);
                            openParams.Add("bunho", this.mBunho);
                            openParams.Add("reser_date", calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"));
                            openParams.Add("gwa", this.cboGwa.GetDataValue().ToString());

                            //XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R99", ScreenOpenStyle.ResponseSizable, openParams);
                            XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseSizable,
                                openParams);
                        }
                        else
                        {
                            //using mBunho to switch bunho between 2 tabs
                            //PrintBookingTicket(this.paBox.BunHo, this.cboGwa.GetDataValue().ToString());
                            PrintBookingTicket(mBunho, this.cboGwa.GetDataValue().ToString(), calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"), this.mPreTime);
                        }

                    }
                }

                //다시 조회
                int curRowAM = this.grdOUT1001_AM.CurrentRowNumber;
                int curColAM = this.grdOUT1001_AM.CurrentColNumber;
                int curRowPM = this.grdOUT1001_PM.CurrentRowNumber;
                int curColPM = this.grdOUT1001_PM.CurrentColNumber;

                string jinryo_pre_date = "";
                if (this.calSchedule.SelectedDays.Count > 0)
                    jinryo_pre_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");

                if (mDoctor != "")
                {
                    this.SetDataDoctorSchedule(mDoctor, this.calSchedule.CurrentMonth.Replace("/", ""));
                    this.grdOUT1001_AM.QueryLayout(true);
                    this.grdOUT1001_PM.QueryLayout(true);
                    LoadBookingClinicRefer();
                }

                this.xGrid1.SetBindVarValue("f_hosp_code", this.mHospCode);
                //using mBunho to switch bunho between 2 tabs
                //this.xGrid1.SetBindVarValue("f_bunho", this.paBox.BunHo);
                this.xGrid1.SetBindVarValue("f_bunho", this.mBunho);
                this.xGrid1.QueryLayout(true);


                //저장후 현재로우 focus
                this.grdOUT1001_AM.SetFocusToItem(curRowAM, curColAM);
                this.grdOUT1001_PM.SetFocusToItem(curRowPM, curColPM);
            }
            else
            {
                returnValue = false;
            }
           
            return returnValue;
        }


        private void fbxDoctor_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("gwa", this.cboGwa.GetDataValue().ToString());
            openParams.Add("word", "");
            openParams.Add("all_gubun", "N");
            openParams.Add("query_gubun", "%");
            openParams.Add("hosp_code", (String.IsNullOrEmpty(this.mHospCodeLink)) ? UserInfo.HospCode : this.mHospCodeLink);
            if (rbtLinkClinic.Checked)
            {
                //just load doctors who have setting for out-clinic 
                openParams.Add("reser_out_yn", true);
            }

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0270Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void btnNUR1001R09_Click(object sender, System.EventArgs e)
        {
            //testing print
            //PrintBookingTicket("", "", "", "");
            //return;

            //if( layReserList.RowCount <= 0 ) return;    

            //if( grdReserList1.CurrentCell.RowNumber < 0 ) return;

            //int currentRow = grdReserList1.CurrentCell.RowNumber;

            //MED-12245
            if (this.xGrid1.RowCount <= 0) 
            {
                XMessageBox.Show(Resources.MSG024_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                return;
            }

            if (NetInfo.Language != LangMode.Jr || !rbtLinkClinic.Checked)
            {
                int currentRow = xGrid1.CurrentRowNumber;

                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("auto_close", "Y");
                openParams.Add("total_query_yn", "N");
                //using mBunho to switch bunho between 2 tabs
                //openParams.Add("bunho", this.paBox.BunHo.ToString());
                openParams.Add("bunho", this.mBunho);

                openParams.Add("reser_date", this.xGrid1.GetItemString(currentRow, "jinryo_pre_date"));
                openParams.Add("gwa", this.xGrid1.GetItemString(currentRow, "gwa"));
                //openParams.Add("reser_date", this.grdReserList1.GetItemString(currentRow, "jinryo_pre_date"));
                //openParams.Add("gwa", this.grdReserList1.GetItemString(currentRow, "gwa"));

                //XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R99", ScreenOpenStyle.ResponseSizable, openParams);
                XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseSizable, openParams);
            }
            else
            {
                int currentRow = xGrid1.CurrentRowNumber;
                //using mBunho to switch bunho between 2 tabs
                //PrintBookingTicket(this.paBox.BunHo.ToString(), this.xGrid1.GetItemString(currentRow, "gwa"));
                string jinryoPreTime = this.xGrid1.GetItemString(currentRow, "jinryo_pre_time");
                string[] splitResult = jinryoPreTime.Split(':');
                if (splitResult.Length == 2) jinryoPreTime = splitResult[0] + splitResult[1];
                PrintBookingTicket(this.mBunho, this.xGrid1.GetItemString(currentRow, "gwa"), this.xGrid1.GetItemString(currentRow, "jinryo_pre_date"), jinryoPreTime);
            }
        }

        private void grdRES1001_AM_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (e.DataRow["jinryo_irai_yn"].ToString() == "Y")
                e.BackColor = System.Drawing.Color.LightPink;


            if (e.DataRow["jinryo_yn"].ToString() == "N")
                e.BackColor = System.Drawing.Color.Blue;

            //change color to yellow if order from outside hospital
            if (e.DataRow["clinic_name"].ToString() != "" && e.DataRow["clinic_name"].ToString() != UserInfo.HospName)
                e.BackColor = System.Drawing.Color.Yellow;
            grdOUT1001_AM[e.RowNumber, e.ColName].ToolTipText = " ";

        }

        private void grdRES1001_PM_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {

            if (e.DataRow["jinryo_irai_yn"].ToString() == "Y")
                e.BackColor = System.Drawing.Color.LightPink;


            if (e.DataRow["jinryo_yn"].ToString() == "N")
                e.BackColor = System.Drawing.Color.Blue;

            //change color to yellow if order from outside hospital
            if (e.DataRow["clinic_name"].ToString() != "" && e.DataRow["clinic_name"].ToString() != UserInfo.HospName)
                e.BackColor = System.Drawing.Color.Yellow;

            grdOUT1001_PM[e.RowNumber, e.ColName].ToolTipText = " ";
        }

        private string mLimtCnt = "";
        private bool mContinueFlag = true;

        private void grdRES1001_AMPM_QueryStarting(object sender, CancelEventArgs e)
        {
            if (!mContinueFlag)
            {
                e.Cancel = true;
                mContinueFlag = true;
                return;
            }

            XEditGrid grd = sender as XEditGrid;
            string from_time;
            string to_time;
            string cmdText = "";
            string f_from_time, f_to_time;
            string o_reser_from_time, o_reser_to_time;
            string t_am_start_hhmm, t_am_end_hhmm, t_pm_start_hhmm, t_pm_end_hhmm;
            string t_avg_time, t_limt_cnt;

            DataTable dtSchedule = new DataTable();

            dtSchedule.Columns.Add("AmStartTime", typeof(string));
            dtSchedule.Columns.Add("AmEndTime", typeof(string));
            dtSchedule.Columns.Add("PmStartTime", typeof(string));
            dtSchedule.Columns.Add("PmEndTime", typeof(string));

            DataTable dtAverageTime = new DataTable();

            dtAverageTime.Columns.Add("AvgTime", typeof(String));
            dtAverageTime.Columns.Add("DocResLimit", typeof(string));

            int count = 0;

            BindVarCollection bc = new BindVarCollection();

            if (grd.Name == "grdOUT1001_AM")
            {
                from_time = AM_START_TIME.ToString().PadLeft(4, '0');
                to_time = AM_END_TIME.ToString().PadLeft(4, '0');
            }
            else
            {
                from_time = PM_START_TIME.ToString().PadLeft(4, '0');
                to_time = PM_START_TIME.ToString().PadLeft(4, '0');
            }

            /*************************************************************************************/
            /* 진료가 가능하지 않은 미래일자로 예약된 환자를 조회할 경우를 위해 input되는        */
            /* i_from_time과 i_to_time을 i_reser_from_time과 i_reser_to_time에 복사해 놓는다.    */
            /*************************************************************************************/
            o_reser_from_time = from_time;
            o_reser_to_time = to_time;

            //Remove
            //            cmdText = @"SELECT A.RES_AM_START_HHMM  AM_START_HHMM,
            //                               A.RES_AM_END_HHMM    AM_END_HHMM,
            //                               A.RES_PM_START_HHMM  PM_START_HHMM,
            //                               A.RES_PM_END_HHMM    PM_END_HHMM
            //                          FROM RES0103 A
            //                         WHERE A.HOSP_CODE        = :f_hosp_code
            //                           AND A.DOCTOR           = :f_doctor
            //                           AND A.JINRYO_PRE_DATE  = :f_jinryo_pre_date
            //                           AND A.AM_START_HHMM    IS NULL
            //                           AND A.AM_END_HHMM      IS NULL
            //                           AND A.PM_START_HHMM    IS NULL
            //                           AND A.PM_END_HHMM      IS NULL
            //                         ORDER BY A.JINRYO_PRE_DATE";

            NuroRES1001U00ReservationScheduleCondition1ListArgs args =
                new NuroRES1001U00ReservationScheduleCondition1ListArgs();
            args.DoctorCode = mDoctor;
            args.ExamPreDate = mCurrentDate;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00ReservationScheduleConditionListResult result = CloudService.Instance
                .Submit
                <NuroRES1001U00ReservationScheduleConditionListResult,
                    NuroRES1001U00ReservationScheduleCondition1ListArgs>(args);

            if (result != null)
            {
                count = result.ResScheduleListItem.Count;
                foreach (NuroRES1001U00ReservationScheduleConditionListItemInfo items in result.ResScheduleListItem)
                {
                    object[] objects =
                    {
                        items.AmStartTime,
                        items.AmEndTime,
                        items.PmStartTime,
                        items.PmEndTime
                    };

                    dtSchedule.Rows.Add(objects);
                }
            }

            bc.Add("f_hosp_code", this.mHospCode);
            bc.Add("f_doctor", mDoctor);
            bc.Add("f_jinryo_pre_date", mCurrentDate);

            //dt = Service.ExecuteDataTable(cmdText, bc);

            if (count < 1)
            {
                //                //Remove
                //                cmdText = @"SELECT A.AM_START_HHMM,
                //                               A.AM_END_HHMM  ,
                //                               A.PM_START_HHMM,
                //                               A.PM_END_HHMM
                //                          FROM ( SELECT NVL(DECODE(TO_CHAR( TO_DATE(:f_jinryo_pre_date, 'YYYY/MM/DD'), 'D')      ,
                //                                                   '1', DECODE( A.RES_AM_START_HHMM1, NULL, NULL, A.RES_AM_START_HHMM1 ),
                //                                                   '2', DECODE( A.RES_AM_START_HHMM2, NULL, NULL, A.RES_AM_START_HHMM2 ),
                //                                                   '3', DECODE( A.RES_AM_START_HHMM3, NULL, NULL, A.RES_AM_START_HHMM3 ),
                //                                                   '4', DECODE( A.RES_AM_START_HHMM4, NULL, NULL, A.RES_AM_START_HHMM4 ),
                //                                                   '5', DECODE( A.RES_AM_START_HHMM5, NULL, NULL, A.RES_AM_START_HHMM5 ),
                //                                                   '6', DECODE( A.RES_AM_START_HHMM6, NULL, NULL, A.RES_AM_START_HHMM6 ),
                //                                                   '7', DECODE( A.RES_AM_START_HHMM7, NULL, NULL, A.RES_AM_START_HHMM7 ),
                //                                                   NULL ), '0000') AM_START_HHMM,
                //                                        NVL(DECODE(TO_CHAR( TO_DATE(:f_jinryo_pre_date, 'YYYY/MM/DD'), 'D')      ,
                //                                                   '1', DECODE( A.RES_AM_END_HHMM1, NULL, NULL, A.RES_AM_END_HHMM1 ),
                //                                                   '2', DECODE( A.RES_AM_END_HHMM2, NULL, NULL, A.RES_AM_END_HHMM2 ),
                //                                                   '3', DECODE( A.RES_AM_END_HHMM3, NULL, NULL, A.RES_AM_END_HHMM3 ),
                //                                                   '4', DECODE( A.RES_AM_END_HHMM4, NULL, NULL, A.RES_AM_END_HHMM4 ),
                //                                                   '5', DECODE( A.RES_AM_END_HHMM5, NULL, NULL, A.RES_AM_END_HHMM5 ),
                //                                                   '6', DECODE( A.RES_AM_END_HHMM6, NULL, NULL, A.RES_AM_END_HHMM6 ),
                //                                                   '7', DECODE( A.RES_AM_END_HHMM7, NULL, NULL, A.RES_AM_END_HHMM7 ),
                //                                                   NULL ), '0000') AM_END_HHMM,
                //                                        NVL(DECODE(TO_CHAR( TO_DATE(:f_jinryo_pre_date, 'YYYY/MM/DD'), 'D')      ,
                //                                                   '1', DECODE( A.RES_PM_START_HHMM1, NULL, NULL, A.RES_PM_START_HHMM1 ),
                //                                                   '2', DECODE( A.RES_PM_START_HHMM2, NULL, NULL, A.RES_PM_START_HHMM2 ),
                //                                                   '3', DECODE( A.RES_PM_START_HHMM3, NULL, NULL, A.RES_PM_START_HHMM3 ),
                //                                                   '4', DECODE( A.RES_PM_START_HHMM4, NULL, NULL, A.RES_PM_START_HHMM4 ),
                //                                                   '5', DECODE( A.RES_PM_START_HHMM5, NULL, NULL, A.RES_PM_START_HHMM5 ),
                //                                                   '6', DECODE( A.RES_PM_START_HHMM6, NULL, NULL, A.RES_PM_START_HHMM6 ),
                //                                                   '7', DECODE( A.RES_PM_START_HHMM7, NULL, NULL, A.RES_PM_START_HHMM7 ),
                //                                                   NULL ), '0000') PM_START_HHMM,
                //                                        NVL(DECODE(TO_CHAR( TO_DATE(:f_jinryo_pre_date, 'YYYY/MM/DD'), 'D')      ,
                //                                                   '1', DECODE( A.RES_PM_END_HHMM1, NULL, NULL, A.RES_PM_END_HHMM1 ),
                //                                                   '2', DECODE( A.RES_PM_END_HHMM2, NULL, NULL, A.RES_PM_END_HHMM2 ),
                //                                                   '3', DECODE( A.RES_PM_END_HHMM3, NULL, NULL, A.RES_PM_END_HHMM3 ),
                //                                                   '4', DECODE( A.RES_PM_END_HHMM4, NULL, NULL, A.RES_PM_END_HHMM4 ),
                //                                                   '5', DECODE( A.RES_PM_END_HHMM5, NULL, NULL, A.RES_PM_END_HHMM5 ),
                //                                                   '6', DECODE( A.RES_PM_END_HHMM6, NULL, NULL, A.RES_PM_END_HHMM6 ),
                //                                                   '7', DECODE( A.RES_PM_END_HHMM7, NULL, NULL, A.RES_PM_END_HHMM7 ),
                //                                                   NULL ), '0000') PM_END_HHMM
                //                                   FROM RES0102 A
                //                                  WHERE A.HOSP_CODE  = :f_hosp_code 
                //                                    AND NVL(A.JINRYO_BREAK_YN, 'N') = 'N'
                //                                    AND A.DOCTOR     = :f_doctor
                //                                    AND TO_DATE(:f_jinryo_pre_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE 
                //                                    ) A
                //                         WHERE ROWNUM = 1";

                NuroRES1001U00ReservationScheduleCondition2ListArgs argsSchedule =
                    new NuroRES1001U00ReservationScheduleCondition2ListArgs();

                argsSchedule.DoctorCode = mDoctor;
                argsSchedule.ExamPreDate = mCurrentDate;
                argsSchedule.HospCodeLink = this.mHospCodeLink;
                argsSchedule.TabIsAll = this.tabIsAll;

                NuroRES1001U00ReservationScheduleConditionListResult resultSchedule = CloudService.Instance
                    .Submit
                    <NuroRES1001U00ReservationScheduleConditionListResult,
                        NuroRES1001U00ReservationScheduleCondition2ListArgs>(argsSchedule);

                if (resultSchedule != null)
                {
                    count = resultSchedule.ResScheduleListItem.Count;
                    foreach (
                        NuroRES1001U00ReservationScheduleConditionListItemInfo items in
                            resultSchedule.ResScheduleListItem)
                    {
                        object[] objects =
                        {
                            items.AmStartTime,
                            items.AmEndTime,
                            items.PmStartTime,
                            items.PmEndTime
                        };

                        dtSchedule.Rows.Add(objects);
                    }
                }

                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_doctor", mDoctor);
                bc.Add("f_jinryo_pre_date", mCurrentDate);

                // dt = Service.ExecuteDataTable(cmdText, bc);

            }

            if (count < 1)
            //if(!this.layCommon.QueryLayout())
            {
                //XMessageBox.Show("該当ドクターの [ " + mCurrentDate + " ] の診療スケジュールが存在しません。", "注意", MessageBoxIcon.Warning);
                e.Cancel = true;

                //TODO
                //grd.QuerySQL = @"select '' from dual where 1 = 0 ";

                mContinueFlag = false;
                return;
            }

            t_am_start_hhmm = dtSchedule.Rows[0]["AmStartTime"].ToString();
            t_am_end_hhmm = dtSchedule.Rows[0]["AmEndTime"].ToString();
            t_pm_start_hhmm = dtSchedule.Rows[0]["PmStartTime"].ToString();
            t_pm_end_hhmm = dtSchedule.Rows[0]["PmEndTime"].ToString();

            //t_am_start_hhmm = this.layCommon.GetItemValue("am_start_hhmm").ToString();
            //t_am_end_hhmm = this.layCommon.GetItemValue("am_end_hhmm").ToString();
            //t_pm_start_hhmm = this.layCommon.GetItemValue("pm_start_hhmm").ToString();
            //t_pm_end_hhmm = this.layCommon.GetItemValue("pm_end_hhmm").ToString();

            /* 오전 */
            if (from_time == "0800")
            {
                f_from_time = t_am_start_hhmm;
                f_to_time = t_am_end_hhmm;
            }
            else
            {
                f_from_time = t_pm_start_hhmm;
                f_to_time = t_pm_end_hhmm;
            }

            /* 의사 예약가능수를 전체인원수로 가져간다. */
            //            //Remove
            //            cmdText = @"SELECT NVL(A.AVG_TIME, 10) avg_time,
            //                               NVL(A.DOC_RES_LIMIT, 1) doc_res_limit
            //                          FROM RES0102 A
            //                         WHERE A.HOSP_CODE  = :f_hosp_code
            //                           AND A.DOCTOR     = :f_doctor
            //                           AND NVL(A.JINRYO_BREAK_YN, 'N') = 'N'
            //                           AND :f_jinryo_pre_date BETWEEN A.START_DATE AND A.END_DATE 
            //                           ";

            NuroRES1001U00AverageTimeListArgs argsAverageTime = new NuroRES1001U00AverageTimeListArgs();
            argsAverageTime.DoctorCode = mDoctor;
            argsAverageTime.ExamPreDate = mCurrentDate;
            argsAverageTime.HospCodeLink = this.mHospCodeLink;
            argsAverageTime.TabIsAll = this.tabIsAll;

            NuroRES1001U00AverageTimeListResult resultAverageTime = CloudService.Instance
                .Submit<NuroRES1001U00AverageTimeListResult, NuroRES1001U00AverageTimeListArgs>(argsAverageTime);

            if (resultAverageTime != null)
            {
                foreach (NuroRES1001U00AverageTimeListItemInfo items in resultAverageTime.AvgTimeListItem)
                {
                    object[] objects =
                    {
                        items.AvgTime,
                        items.DocResLimit
                    };

                    dtAverageTime.Rows.Add(objects);
                }
            }

            //dt.Clear();
            bc.Clear();
            bc.Add("f_hosp_code", this.mHospCode);
            bc.Add("f_doctor", mDoctor);
            bc.Add("f_jinryo_pre_date", mCurrentDate);

            //dt = Service.ExecuteDataTable(cmdText, bc);

            t_avg_time = dtAverageTime.Rows[0]["AvgTime"].ToString();
            t_limt_cnt = dtAverageTime.Rows[0]["DocResLimit"].ToString();

            //TODO
            mLimtCnt = t_limt_cnt;

            //            grd.QuerySQL = @"SELECT A.TIME                  JINRYO_PRE_TIME,
            //                                   ''                       BUNHO,
            //                                   ''                       SUNAME,
            //                                   ''                       SUNAME2,
            //                                   ''                       CHOJAE,
            //                                   ''                       RESER_DATE,
            //                                   ''                       PKOUT1001,
            //                                   :f_jinryo_pre_date       JINRYO_PRE_DATE,
            //                                   :f_gwa                   GWA,
            //                                   ''                       JUBSU_NO,
            //                                   ''                       gubun,
            //                                   :f_doctor                DOCTOR,
            //                                   ''                       RES_GUBUN             ,
            //                                   ''                       RES_CHANGGU           ,
            //                                   'Z'                      RES_INPUT_GUBUN       ,
            //                                   'N'                      NAEWON_YN      ,
            //                                   'Y'                      NEWROW         ,
            //                                   FN_RES_LOAD_JINRYO_TIME_YN( :f_doctor,
            //                                                               :f_jinryo_pre_date,
            //                                                               A.TIME              ) JINRYO_YN
            //                              FROM RES0106 A
            //                             WHERE A.HOSP_CODE          = :f_hosp_code
            //                               AND A.TIME_TERM          = '1'
            //                               AND A.TIME              >= :f_from_time
            //                               AND A.TIME              <= :f_to_time
            //                               AND MOD(ROUND((TO_DATE('20000101'||A.TIME, 'YYYYMMDDHH24MI') - TO_DATE('20000101'||:f_from_time, 'YYYYMMDDHH24MI'))*24*60), 
            //                                              TO_NUMBER(TRIM(:t_avg_time))) = 0                            
            //                             ORDER BY 1, 15";

            List<string> param = new List<string>();

            param.Add("f_hosp_code");
            param.Add("f_from_time");
            param.Add("f_to_time");
            param.Add("f_gwa");
            param.Add("f_doctor");
            param.Add("f_jinryo_pre_date");
            param.Add("o_reser_from_time");
            param.Add("o_reser_to_time");
            param.Add("t_avg_time");

            grd.ParamList = param;
            grd.ExecuteQuery = GrdReservationSchedule;

            grd.SetBindVarValue("f_hosp_code", this.mHospCode);
            grd.SetBindVarValue("f_from_time", f_from_time);
            grd.SetBindVarValue("f_to_time", f_to_time);
            grd.SetBindVarValue("f_gwa", mGwa);
            grd.SetBindVarValue("f_doctor", mDoctor);
            grd.SetBindVarValue("f_jinryo_pre_date", mCurrentDate);
            grd.SetBindVarValue("o_reser_from_time", o_reser_from_time);
            grd.SetBindVarValue("o_reser_to_time", o_reser_to_time);
            grd.SetBindVarValue("t_avg_time", t_avg_time);

            layReseredData.SetBindVarValue("f_hosp_code", this.mHospCode);
            layReseredData.SetBindVarValue("f_from_time", f_from_time);
            layReseredData.SetBindVarValue("f_to_time", f_to_time);
            layReseredData.SetBindVarValue("f_gwa", mGwa);
            layReseredData.SetBindVarValue("f_doctor", mDoctor);
            layReseredData.SetBindVarValue("f_jinryo_pre_date", mCurrentDate);
            layReseredData.SetBindVarValue("o_reser_from_time", o_reser_from_time);
            layReseredData.SetBindVarValue("o_reser_to_time", o_reser_to_time);
            layReseredData.SetBindVarValue("t_avg_time", t_avg_time);
            this.layReseredData.QueryLayout(true);

            mContinueFlag = true;
        }

        //NuroRES1001U00ReservationScheduleListRequest 
        private IList<object[]> GrdReservationSchedule(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();

            NuroRES1001U00ReservationScheduleListArgs args = new NuroRES1001U00ReservationScheduleListArgs();
            args.AvgTime = list["t_avg_time"].VarValue;
            args.DepartmentCode = list["f_gwa"].VarValue;
            args.DoctorCode = list["f_doctor"].VarValue;
            args.ExamPreDate = list["f_jinryo_pre_date"].VarValue;
            args.FromTime = list["f_from_time"].VarValue;
            args.ToTime = list["f_to_time"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00ReservationScheduleListResult result =
                CloudService.Instance
                    .Submit<NuroRES1001U00ReservationScheduleListResult, NuroRES1001U00ReservationScheduleListArgs>(args);

            if (result != null)
            {
                foreach (NuroRES1001U00ReservationScheduleListItemInfo items in result.ResScheduleListItem)
                {
                    object[] objects =
                    {
                        items.ExamPreTime,
                        items.PatientCode,
                        items.PatientName1,
                        items.PatientName2,
                        items.ExamStatus,
                        items.ReserDate,
                        items.Pkout1001,
                        items.ExamPreDate,
                        items.DepartmentCode,
                        items.ReceptionNo,
                        items.Type,
                        items.DoctorCode,
                        items.ResType,
                        items.ResChanggu,
                        items.ResInputType,
                        items.ComingStatus,
                        items.NewRow,
                        items.ExamState
                    };
                    data.Add(objects);
                }
            }

            return data;
        }

        private void grdRES1001_AMPM_QueryEnd(object sender, QueryEndEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            MultiLayout tempLayout = grd.CloneToLayout();

            string t_jinryo_pre_time = "XXXX";
            string t_jinryo_yn = "";
            string o_jinryo_pre_time = "";
            int t_cnt = 0;
            int rowCnt = 0;
            int addedRowCnt = 0;

            ///////////////////////////////////////////////////////////////////////////

            /* 예정시간이 다른 경우 이전 예정시간에 빈 row 생성 */

            rowCnt = grd.RowCount;

            int baseRowNum = 0;
            int insertedRowNum = 0;
            int insertRowNum = 0;
            int timeGubun = 0;

            for (int i = 0; i < rowCnt; i++)
            {
                //o_jinryo_pre_time = tempLayout.GetItemString(i, "jinryo_pre_time");
                o_jinryo_pre_time = grd.GetItemString(addedRowCnt, "jinryo_pre_time");

                if (t_jinryo_pre_time != "XXXX" && t_jinryo_pre_time != o_jinryo_pre_time)
                {
                    for (int k = t_cnt + 1; k <= Convert.ToInt32(mLimtCnt); k++)
                    {
                        insertRowNum = addedRowCnt - 1;
                        insertedRowNum = grd.InsertRow(insertRowNum);
                        addedRowCnt++; //추가된 행수를 증가

                        grd.SetItemValue(insertedRowNum, "jinryo_pre_time", t_jinryo_pre_time);
                        grd.SetItemValue(insertedRowNum, "jinryo_pre_date", mCurrentDate);
                        grd.SetItemValue(insertedRowNum, "gwa", mGwa);
                        grd.SetItemValue(insertedRowNum, "doctor", mDoctor);
                        grd.SetItemValue(insertedRowNum, "res_gubun", "2");
                        grd.SetItemValue(insertedRowNum, "naewon_yn", "N");
                        grd.SetItemValue(insertedRowNum, "newrow", "Y");
                        grd.SetItemValue(insertedRowNum, "jinryo_yn", t_jinryo_yn);
                        grd.SetItemValue(insertedRowNum, "input_gubun", "Z");
                    }
                    timeGubun++;
                    t_cnt = 0;
                }

                t_cnt++;

                baseRowNum = timeGubun * Convert.ToInt32(mLimtCnt);

                //if (t_jinryo_pre_time == o_jinryo_pre_time)
                //    t_jinryo_pre_time = grd.GetItemString(baseRowNum + 1, "jinryo_pre_time");
                //else
                t_jinryo_pre_time = grd.GetItemString(baseRowNum, "jinryo_pre_time");

                //t_jinryo_pre_time = tempLayout.GetItemString(i, "jinryo_pre_time");
                t_jinryo_yn = grd.GetItemString(baseRowNum, "jinryo_yn");
                //t_jinryo_yn = tempLayout.GetItemString(baseRowNum, "jinryo_yn");

                addedRowCnt++;
            }

            if (t_jinryo_pre_time != "XXXX")
            {
                for (int k = t_cnt + 1; k <= Convert.ToInt32(mLimtCnt); k++)
                {
                    insertedRowNum = grd.InsertRow(addedRowCnt - 1);
                    addedRowCnt++; //추가된 행수를 증가

                    grd.SetItemValue(insertedRowNum, "jinryo_pre_time", t_jinryo_pre_time);
                    grd.SetItemValue(insertedRowNum, "jinryo_pre_date", mCurrentDate);
                    grd.SetItemValue(insertedRowNum, "gwa", mGwa);
                    grd.SetItemValue(insertedRowNum, "doctor", mDoctor);
                    grd.SetItemValue(insertedRowNum, "res_gubun", "2");
                    grd.SetItemValue(insertedRowNum, "naewon_yn", "N");
                    grd.SetItemValue(insertedRowNum, "newrow", "Y");
                    grd.SetItemValue(insertedRowNum, "jinryo_yn", t_jinryo_yn);
                    grd.SetItemValue(insertedRowNum, "input_gubun", "Z");
                }
            }

            foreach (DataRow row in this.layReseredData.LayoutTable.Rows)
            {
                //DataRow[] rows = grd.LayoutTable.Select("jinryo_pre_time = '" + row["jinryo_pre_time"].ToString() + "'");

                //if (rows.Length > 0)
                //{
                for (int i = 0; i < grd.RowCount; i++)
                {
                    if (grd.GetItemString(i, "jinryo_pre_time") == row["jinryo_pre_time"].ToString())
                    {
                        if (grd.GetItemString(i, "bunho") == "")
                        {
                            grd.DeleteRow(i);
                            break;
                        }
                    }
                }
                //}

                grd.LayoutTable.ImportRow(row);
            }

            grd.Sort("jinryo_pre_time ASC, input_gubun ASC");
            grd.ResetUpdate(); //iud를 초기화
            ///////////////////////////////////////////////////////////////////////////

            DisplayResGubun(grd);

            if (grd.RowCount > 0)
                grd.SetTopRow(0);
        }

        private bool SaveGrids( string bookingType)
        {
            checkDoctor = true;
            for (int i = 0; i < grdOUT1001_AM.RowCount; i++)
            {
                if (grdOUT1001_AM.GetItemString(i, "bunho") == "")
                    grdOUT1001_AM.LayoutTable.Rows[i].AcceptChanges();
            }

            for (int i = 0; i < grdOUT1001_PM.RowCount; i++)
            {
                if (grdOUT1001_PM.GetItemString(i, "bunho") == "")
                    grdOUT1001_PM.LayoutTable.Rows[i].AcceptChanges();
            }

            #region deleted by Cloud

            //try
            //{
            //    Service.BeginTransaction();

            //    if (this.grdDeleteOUT1001.SaveLayout())
            //    {
            //        if (this.grdOUT1001_AM.SaveLayout())
            //        {                        
            //        }
            //        else
            //            throw new Exception();

            //        if (this.grdOUT1001_PM.SaveLayout())
            //        {
            //        }
            //        else
            //            throw new Exception();
            //    }
            //    else
            //        throw new Exception();

            //    Service.CommitTransaction();
            //}
            //catch
            //{
            //    Service.RollbackTransaction();
            //    return false;
            //}

            #endregion

            // cloud updated
            List<RES1001U00SaveLayoutItemInfo> lstData = GetListDataForSaveLayout();

            if (lstData.Count > 0)
            {
                //Request using for Orca server
                //RES1001U00SaveLayoutItemArgs args = new RES1001U00SaveLayoutItemArgs();
                RES1001U00SaveLayoutArgs args = new RES1001U00SaveLayoutArgs();
                args.UserId = UserInfo.UserID;
                args.LayoutItem = lstData;
                args.HospCodeLink = this.mHospCodeLink;                
                args.BunhoLink = mBunhoLink;
                args.BookingType = bookingType;
                RES1001U00SaveLayoutItemResult res = CloudService.Instance.Submit<RES1001U00SaveLayoutItemResult,
                    RES1001U00SaveLayoutArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (!String.IsNullOrEmpty(res.ErrCode))
                    {
                        switch (res.ErrCode)
                        {
                            case "1":
                                //XMessageBox.Show("予約時間[" + res.DoctorName + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                //XMessageBox.Show(string.Format(Resources.MSG_ERR_01, res.DoctorName), Resources.MSG004_CAP,
                                //    MessageBoxIcon.Warning);

                                //MED-10364
                                StringBuilder sb = new StringBuilder();
                                sb.AppendLine(Resources.MSG026_MSG);
                                sb.AppendLine(String.Format("{0}  {1}  {2}  {3}", lstData[0].JinryoPreDate, lstData[0].JinryoPreTime.Insert(2, ":"), lstData[0].Gwa, res.DoctorName));
                                sb.AppendLine(Resources.MSG027_MSG);
                                XMessageBox.Show(sb.ToString(), Resources.MSG004_CAP, MessageBoxIcon.Warning);

                                return false;
                            case "2":
                                //XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                XMessageBox.Show(Resources.MSG_ERR_02, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            case "3":
                                //XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。\r\n" +
                                //                         "（枠が空いてる場合にはユーザ区分別の予約可能人数を超えた事になります。）", Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                XMessageBox.Show(Resources.MSG_ERR_03, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                checkDoctor = false;
                                return false;
                            case "4":
                                XMessageBox.Show(Resources.MSG_ERR_04, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            case "5":
                                XMessageBox.Show(Resources.MSG_ERR_05, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            case "6":
                                XMessageBox.Show(Resources.MSG_ERR_06, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            case "7":
                                XMessageBox.Show(Resources.MSG_ERR_07, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            case "8":
                                XMessageBox.Show(Resources.MSG_ERR_08, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                                return false;
                            default:
                                break;
                        }
                        //get booking time
                        if (Array.IndexOf(msgOrca, res.ErrCode) < 0)
                        {
                            XMessageBox.Show(Utilities.MessageOrca(res.ErrCode), res.ErrCode, MessageBoxIcon.Warning);
                            return false;
                        }
                        this.mPreTime = args.LayoutItem[0].JinryoPreTime;
                    }
                }
                else
                {
                    return false;
                }
                
            }

            return true;
        }

        #region XSavePerformer

        // deleted by Cloud
        //        private class XSavePerformer : ISavePerformer
        //        {
        //            private RES1001U00 parent;

        //            //ArrayList input;
        //            //ArrayList output;

        //            public XSavePerformer(RES1001U00 parent)
        //            {
        //                this.parent = parent;
        //            }


        //            //public bool Send_IF_Proc(string pkout1001, string proc_gubun)
        //            //{
        //            //    if (proc_gubun == "U")
        //            //    {
        //            //        if (Send_IF(pkout1001, "D"))
        //            //        {
        //            //            return Send_IF(pkout1001, "I");
        //            //        }
        //            //        return false;
        //            //    }
        //            //    else
        //            //    {
        //            //        return Send_IF(pkout1001, proc_gubun);
        //            //    }             
        //            //}

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                object t_gubun = null;
        //                object doctor_name = null;
        //                object t_chk = null;
        //                object t_jubsu_no = null;
        //                bool flag = false;


        //                if(UserInfo.UserGubun == UserType.Doctor)
        //                    item.BindVarList.Add("q_user_id", UserInfo.DoctorID);
        //                else
        //                    item.BindVarList.Add("q_user_id", UserInfo.UserID);

        //                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        ////                /* 보험 종별 */
        ////                cmdText = @"SELECT Z.GUBUN
        ////                              FROM ( SELECT A.GUBUN
        ////                                       FROM OUT1001 A
        ////                                      WHERE A.HOSP_CODE = :f_hosp_code
        ////                                        AND A.BUNHO     = :f_bunho
        ////                                        AND A.GWA       = :f_gwa
        ////                                        AND A.NAEWON_DATE = ( SELECT MAX(B.NAEWON_DATE)
        ////                                                                FROM OUT1001 B
        ////                                                               WHERE B.HOSP_CODE = A.HOSP_CODE
        ////                                                                 AND B.BUNHO     = A.BUNHO
        ////                                                                 AND B.GWA       = A.GWA ) )Z
        ////                             WHERE ROWNUM = 1";

        //                NuroRES1001U00TypeArgs argsType = new NuroRES1001U00TypeArgs();
        //                argsType.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                argsType.PatientCode = item.BindVarList["f_bunho"].VarValue;

        //                NuroRES1001U00TypeResult resultType = CloudService .Instance 
        //                    .Submit<NuroRES1001U00TypeResult, NuroRES1001U00TypeArgs>(argsType);

        //                t_gubun = resultType.Type;

        //                //t_gubun = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                if (!TypeCheck.IsNull(t_gubun))
        //                    item.BindVarList["f_gubun"].VarValue = t_gubun.ToString();
        //                else
        //                    item.BindVarList["f_gubun"].VarValue = "G1";

        //                switch (item.RowState)
        //                { 
        ////                    case DataRowState.Added:

        ////                        /* 예약정보 취소후 세이브퍼포머를 타는 걸 막는 플러그*/
        ////                        //if (parent.isReseveDeleted)
        ////                        //    return true;

        ////                        if (item.BindVarList["f_bunho"].VarValue == "")
        ////                            return true;

        ////                        /* 예약중복여부 */
        ////                        cmdText = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE) DOCTOR_NAME
        ////                                      FROM OUT1001 A
        ////                                     WHERE A.HOSP_CODE    = :f_hosp_code
        ////                                       AND A.RESER_YN     = 'Y'
        ////                                       AND A.BUNHO        = :f_bunho
        ////                                       AND A.GWA          = :f_gwa
        ////                                       AND A.NAEWON_DATE  = :f_jinryo_pre_date
        ////                                       AND A.JUBSU_TIME   = :f_jinryo_pre_time
        ////                                       AND ROWNUM         = 1";

        ////                        doctor_name = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (!TypeCheck.IsNull(doctor_name))
        ////                        {
        ////                            XMessageBox.Show("予約時間[" + doctor_name.ToString() + "]が重なっています。ご確認ください。", "注意", MessageBoxIcon.Warning);
        ////                            return false;
        ////                        }

        ////                        /* 예약가능여부를 check한다. */
        ////                        cmdText = @"SELECT FN_RES_CHECK_RESER_POSSIBLE(:f_doctor, :f_jinryo_pre_date, :f_jinryo_pre_time, :f_input_gubun) 
        ////                                      FROM DUAL";

        ////                        t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (!TypeCheck.IsNull(t_chk))
        ////                        {
        ////                            if (t_chk.ToString().Equals("1"))
        ////                            {
        ////                                XMessageBox.Show("該当医師の診療スケジュールがありません。ご確認ください。", "注意", MessageBoxIcon.Warning);
        ////                                return false;
        ////                            }
        ////                            else if (t_chk.ToString().Equals("2"))
        ////                            {
        ////                                XMessageBox.Show("該当日付の予約時間の予約可能人数を超えました。ご確認ください。\r\n" + 
        ////                                                 "（枠が空いてる場合にはユーザ区分別の予約可能人数を超えた事になります。）", "注意", MessageBoxIcon.Warning);
        ////                                return false;
        ////                            }
        ////                        }

        ////                        cmdText = @"SELECT NVL(MAX(A.JUBSU_NO), 0) + 1 JUBSU_NO
        ////                                               FROM OUT1001 A
        ////                                              WHERE A.HOSP_CODE       = :f_hosp_code
        ////                                                AND A.BUNHO           = :f_bunho
        ////                                                AND A.NAEWON_DATE     = :f_jinryo_pre_date";

        ////                        t_jubsu_no = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (TypeCheck.IsNull(t_jubsu_no))
        ////                        {
        ////                            XMessageBox.Show("受付番号の生成に失敗しました。", "注意", MessageBoxIcon.Warning);
        ////                            return false;
        ////                        }

        ////                        item.BindVarList.Add("t_jubsu_no", t_jubsu_no.ToString());

        ////                        /* 예약key 생성 */
        ////                        input = new ArrayList();
        ////                        output = new ArrayList();

        ////                        input.Add(item.BindVarList["f_jinryo_pre_date"].VarValue);
        ////                        input.Add(item.BindVarList["f_bunho"].VarValue);
        ////                        input.Add(item.BindVarList["f_gwa"].VarValue);
        ////                        input.Add(t_jubsu_no.ToString());

        ////                        cmdText = @"SELECT MAX(NVL(V.SEQ,0))        SEQ
        ////                                     FROM ( SELECT MAX(NVL(A.JUBSU_NO,0)) SEQ
        ////                                              FROM OUT1001 A
        ////                                             WHERE A.HOSP_CODE   = :f_hosp_code
        ////                                               AND A.BUNHO       = :f_bunho
        ////                                               AND A.NAEWON_DATE = :f_naewon_date
        ////                                               AND A.GWA         = :f_gwa
        ////                                            UNION
        ////                                            SELECT MAX(NVL(B.JUBSU_NO,0)) SEQ
        ////                                              FROM OUT1011 B
        ////                                             WHERE B.HOSP_CODE   = :f_hosp_code
        ////                                               AND B.BUNHO       = :f_bunho
        ////                                               AND B.NAEWON_DATE = :f_naewon_date
        ////                                               AND B.GWA         = :f_gwa ) ";

        ////                        object seq = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (!TypeCheck.IsNull(seq))
        ////                        {
        ////                            item.BindVarList.Add("t_seq", seq.ToString());                        
        ////                        }

        ////                        cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM DUAL";

        ////                        object t_out1001_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (!TypeCheck.IsNull(t_out1001_seq))
        ////                        {
        ////                            item.BindVarList.Add("t_pkres1001", t_out1001_seq.ToString());
        ////                        }

        ////                        if(item.BindVarList["f_reser_comment"].VarValue != "")
        ////                        {
        ////                            cmdText = @"INSERT INTO OUT0123 
        ////                                             ( SYS_DATE         , SYS_ID        , UPD_DATE          , UPD_ID        
        ////                                             , HOSP_CODE        , BUNHO         , SEQ           
        ////                                             , REQ_DATE         , REQ_TIME      , REQ_GWA           , REQ_DOCTOR 
        ////                                             , ANSWER_DATE      , ANSWER_TIME   , ANSWER_GWA        , ANSWER_DOCTOR
        ////                                             , ANSWER_END_YN    , IN_OUT_GUBUN  , COMMENTS          
        ////                                             , FKOUT1001        , FKINP1001     , COMMENT_TYPE  )
        ////                                        VALUES 
        ////                                             ( SYSDATE          , :q_user_id    , SYSDATE           , :q_user_id
        ////                                             , :f_hosp_code     , :f_bunho      , :f_seq            
        ////                                             , SYSDATE          , TO_CHAR(SYSDATE, 'HH24:MI'), :f_gwa, :f_doctor
        ////                                             , SYSDATE          , TO_CHAR(SYSDATE, 'HH24:MI'), '%'   , '%'
        ////                                             , 'N'              , 'O'            , ;f_comment
        ////                                             , :t_pkres1001     , ''             , '1' ) ";

        ////                            if(!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        ////                            {
        ////                                XMessageBox.Show("予約コメントの保存に失敗しました。", "注意", MessageBoxIcon.Warning);
        ////                                return false;                            
        ////                            }
        ////                        }

        ////                        cmdText = @"INSERT INTO OUT1001
        ////                                             ( SYS_DATE            , SYS_ID             , UPD_DATE       , UPD_ID         ,
        ////                                               HOSP_CODE           , PKOUT1001          , RESER_YN       ,
        ////                                               NAEWON_DATE         , BUNHO              , GWA            , 
        ////                                               GUBUN               , DOCTOR             , RES_CHANGGU    ,                                              
        ////                                               JUBSU_TIME          , CHOJAE             , RES_GUBUN      , NAEWON_TYPE    ,
        ////                                               JUBSU_NO            , RES_INPUT_GUBUN    , NAEWON_YN      , JUBSU_GUBUN      )
        ////                                        VALUES
        ////                                             ( SYSDATE             , :q_user_id         , SYSDATE        , :q_user_id   , 
        ////                                               :f_hosp_code        , :t_pkres1001       , 'Y'            ,  
        ////                                               :f_jinryo_pre_date  , :f_bunho           , :f_gwa         , 
        ////                                               NVL(:f_gubun, 'G1') , :f_doctor          , :f_changgu     ,
        ////                                               :f_jinryo_pre_time  , :f_chojae          , :f_res_gubun   , '0'          ,
        ////                                               :t_jubsu_no         , :f_input_gubun     , 'N'            , '01'          )";    
        ////                        break;

        //                    case DataRowState.Modified:

        //                        /* 예약정보 취소후 세이브퍼포머를 타는 걸 막는 플러그*/
        //                        //if (parent.isReseveDeleted)
        //                        //    return true;

        //                        if (item.BindVarList["f_bunho"].VarValue == "")
        //                            return true;

        ////                        /* 예약중복여부 */
        ////                        cmdText = @"SELECT FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.NAEWON_DATE) DOCTOR_NAME
        ////                                      FROM OUT1001 A
        ////                                     WHERE A.HOSP_CODE   = :f_hosp_code
        ////                                       AND A.RESER_YN    = 'Y'
        ////                                       AND A.BUNHO       = :f_bunho
        ////                                       AND A.GWA         = :f_gwa
        ////                                       AND A.NAEWON_DATE = :f_jinryo_pre_date
        ////                                       AND A.JUBSU_TIME  = :f_jinryo_pre_time
        ////                                       AND ROWNUM        = 1 ";


        //                        NuroRES1001U00DoctorNameArgs argsDoctorName = new NuroRES1001U00DoctorNameArgs();
        //                        argsDoctorName.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                        argsDoctorName.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                        argsDoctorName.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        argsDoctorName.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;

        //                        NuroRES1001U00DoctorNameResult resultDoctorName = CloudService.Instance
        //                            .Submit<NuroRES1001U00DoctorNameResult, NuroRES1001U00DoctorNameArgs>(argsDoctorName);

        //                        doctor_name = resultDoctorName.DoctorName;

        //                        //doctor_name = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                        if (!TypeCheck.IsNull(doctor_name))
        //                        {
        //                            XMessageBox.Show(Resources.MSG013_MSG_1 + doctor_name.ToString() + Resources.MSG013_MSG_2, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                            return false;
        //                        }

        ////                        /* 예약가능여부를 check한다. */
        ////                        cmdText = @"SELECT FN_RES_CHECK_RESER_POSSIBLE(:f_doctor, :f_jinryo_pre_date, :f_jinryo_pre_time, :f_input_gubun) 
        ////                                      FROM DUAL";


        //                        NuroRES1001U00CheckingReservationArgs argsCheckReservation =
        //                            new NuroRES1001U00CheckingReservationArgs();

        //                        argsCheckReservation.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                        argsCheckReservation.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        argsCheckReservation.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;
        //                        argsCheckReservation.InputType = item.BindVarList["f_input_gubun"].VarValue;


        //                        NuroRES1001U00CheckingReservationResult resultCheckingReservation = CloudService.Instance
        //                            .Submit<NuroRES1001U00CheckingReservationResult, NuroRES1001U00CheckingReservationArgs>(
        //                                argsCheckReservation);

        //                        t_chk = resultCheckingReservation.Result;

        //                        //t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                        if (!TypeCheck.IsNull(t_chk))
        //                        {
        //                            if (t_chk.ToString().Equals("1"))
        //                            {
        //                                XMessageBox.Show(Resources.MSG014_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                return false;
        //                            }
        //                            else if (t_chk.ToString().Equals("2"))
        //                            {
        //                                XMessageBox.Show(Resources.MSG015_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                return false;
        //                            }
        //                        }

        ////                        //Remove
        ////                        cmdText = @"SELECT NVL(MAX(A.JUBSU_NO), 0) + 1 JUBSU_NO
        ////                                               FROM OUT1001 A
        ////                                              WHERE A.HOSP_CODE   = :f_hosp_code
        ////                                                AND A.BUNHO       = :f_bunho
        ////                                                AND A.NAEWON_DATE = :f_jinryo_pre_date";



        //                        NuroRES1001U00ReceptionNumberArgs argsReceptionNumber = new NuroRES1001U00ReceptionNumberArgs();
        //                        argsReceptionNumber.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        argsReceptionNumber.PatientCode = item.BindVarList["f_bunho"].VarValue;


        //                        NuroRES1001U00ReceptionNumberResult resultReceptionNumber = CloudService.Instance
        //                            .Submit<NuroRES1001U00ReceptionNumberResult, NuroRES1001U00ReceptionNumberArgs>(
        //                                argsReceptionNumber);


        //                        t_jubsu_no = resultReceptionNumber.ReceptionNo;
        //                        //t_jubsu_no = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                        if (TypeCheck.IsNull(t_jubsu_no))
        //                        {
        //                            XMessageBox.Show(Resources.MSG016_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                            return false;
        //                        }

        //                        item.BindVarList.Add("t_jubsu_no", t_jubsu_no.ToString());

        //                        ///* 예약key 생성 */
        //                        //input = new ArrayList();
        //                        //output = new ArrayList();

        //                        //input.Add(item.BindVarList["f_jinryo_pre_date"].VarValue);
        //                        //input.Add(item.BindVarList["f_bunho"].VarValue);
        //                        //input.Add(item.BindVarList["f_gwa"].VarValue);
        //                        //input.Add(t_jubsu_no.ToString());

        ////                        cmdText = @"SELECT MAX(NVL(V.SEQ,0))        SEQ
        ////                                         FROM ( SELECT MAX(NVL(A.JUBSU_NO,0)) SEQ
        ////                                                  FROM OUT1001 A
        ////                                                 WHERE A.HOSP_CODE   = :f_hosp_code
        ////                                                   AND A.BUNHO       = :f_bunho
        ////                                                   AND A.NAEWON_DATE = :f_naewon_date
        ////                                                   AND A.GWA         = :f_gwa
        ////                                                UNION
        ////                                                SELECT MAX(NVL(B.JUBSU_NO,0)) SEQ
        ////                                                  FROM OUT1011 B
        ////                                                 WHERE B.HOSP_CODE   = :f_hosp_code
        ////                                                   AND B.BUNHO       = :f_bunho
        ////                                                   AND B.NAEWON_DATE = :f_naewon_date
        ////                                                   AND B.GWA         = :f_gwa )";

        ////                        seq = Service.ExecuteScalar(cmdText, item.BindVarList);

        ////                        if (!TypeCheck.IsNull(seq))
        ////                        {
        ////                            item.BindVarList.Add("t_seq", seq.ToString());
        ////                        }

        //                        if (item.BindVarList["f_newrow"].VarValue.Equals("Y"))
        //                        {
        //                            //cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM DUAL";

        //                            //object t_out1001_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                            //if (!TypeCheck.IsNull(t_out1001_seq))
        //                            //{
        //                            //    item.BindVarList.Add("t_pkres1001", t_out1001_seq.ToString());
        //                            //}


        //                            //Remove
        ////                            cmdText = @"SELECT 'Y'
        ////                                              FROM DUAL
        ////                                             WHERE EXISTS ( SELECT BUNHO
        ////                                                              FROM OUT0123
        ////                                                             WHERE HOSP_CODE    = :f_hosp_code
        ////                                                               AND BUNHO        = :f_bunho
        ////                                                               AND FKOUT1001    = :f_pkout1001
        ////                                                               AND COMMENT_TYPE = '1' )";


        //                            NuroRES1001U00CheckingPatientExistenceArgs arsCheck =
        //                                new NuroRES1001U00CheckingPatientExistenceArgs();

        //                            arsCheck.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                            arsCheck.PatientCode = item.BindVarList["f_bunho"].VarValue;


        //                            NuroRES1001U00CheckingPatientExistenceResult resultCheck = CloudService.Instance
        //                                .Submit
        //                                <NuroRES1001U00CheckingPatientExistenceResult,
        //                                    NuroRES1001U00CheckingPatientExistenceArgs>(arsCheck);

        //                            object retVal = resultCheck.Result;

        //                            //object retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                            if (!TypeCheck.IsNull(retVal))
        //                            {
        //                                if (retVal.ToString() == "Y")
        //                                {

        //                                    //Remove
        ////                                    cmdText = @"UPDATE OUT0123
        ////                                                   SET UPD_DATE     = SYSDATE
        ////                                                     , UPD_ID       = :q_user_id
        ////                                                     --, FKOUT1001    = :f_pkout1001
        ////                                                     , COMMENTS     = :f_reser_comment
        ////                                                     , RESER_GUBUN  = :f_reser_gubun
        ////　　　　　　　　　　　　　　　　　　　　　　　　　　 , REQ_DATE     = TRUNC(SYSDATE) 
        ////                                                 WHERE HOSP_CODE    = :f_hosp_code
        ////                                                   AND BUNHO        = :f_bunho
        ////                                                   AND FKOUT1001    = :f_pkout1001
        ////                                                   AND COMMENT_TYPE = '1'";


        //                                    NuroRES1001U00ReservationOut0123UpdateArgs argsUpdate =
        //                                        new NuroRES1001U00ReservationOut0123UpdateArgs();

        //                                    argsUpdate.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                                    argsUpdate.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                                    argsUpdate.ReserComment = item.BindVarList["f_reser_comment"].VarValue;
        //                                    argsUpdate.ReserType = item.BindVarList["f_reser_gubun"].VarValue;
        //                                    argsUpdate.UserId = item.BindVarList["q_user_id"].VarValue;


        //                                    UpdateResult resultUpdate = CloudService.Instance
        //                                        .Submit<UpdateResult, NuroRES1001U00ReservationOut0123UpdateArgs>(argsUpdate);

        //                                    flag = resultUpdate.Result;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (item.BindVarList["f_reser_comment"].VarValue != "" || item.BindVarList["f_reser_gubun"].VarValue != "")
        //                                {

        //                                    //Remove
        ////                                    cmdText = @"INSERT INTO OUT0123 
        ////                                                     ( SYS_DATE             , SYS_ID                    , UPD_DATE          , UPD_ID        
        ////                                                     , HOSP_CODE            , BUNHO                     , SEQ           
        ////                                                     , REQ_DATE             , REQ_TIME                  , REQ_GWA           , REQ_DOCTOR 
        ////                                                     , ANSWER_DATE          , ANSWER_TIME               , ANSWER_GWA        , ANSWER_DOCTOR
        ////                                                     , ANSWER_END_YN        , IN_OUT_GUBUN              , COMMENTS          
        ////                                                     , FKOUT1001            , FKINP1001                 , COMMENT_TYPE      , RESER_GUBUN)
        ////                                                VALUES 
        ////                                                     ( SYSDATE              , :q_user_id                , SYSDATE           , :q_user_id
        ////                                                     , :f_hosp_code         , :f_bunho                  , '1'            
        ////                                                     , TRUNC(SYSDATE)       , TO_CHAR(SYSDATE, 'HH24MI'), :f_gwa            , :f_doctor
        ////                                                     , :f_jinryo_pre_date   , :f_jinryo_pre_time        , '%'               , '%'
        ////                                                     , 'Y'                  , 'O'                       , :f_reser_comment
        ////                                                     , :f_pkout1001         , ''                        , '1'               , :f_reser_gubun ) ";


        //                                    NuroRES1001U00ReservationOut0123InsertArgs argsInsert =
        //                                        new NuroRES1001U00ReservationOut0123InsertArgs();

        //                                    argsInsert.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                                    argsInsert.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                                    argsInsert.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                                    argsInsert.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;
        //                                    argsInsert.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                                    argsInsert.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                                    argsInsert.ReserComment = item.BindVarList["f_reser_comment"].VarValue;
        //                                    argsInsert.ReserType = item.BindVarList["f_reser_gubun"].VarValue;
        //                                    argsInsert.UserId = item.BindVarList["q_user_id"].VarValue;


        //                                    UpdateResult resultUpdate = CloudService.Instance
        //                                        .Submit<UpdateResult, NuroRES1001U00ReservationOut0123InsertArgs>(argsInsert);

        //                                    flag = resultUpdate.Result;

        //                                }

        //                            }

        //                            if (flag)
        //                            {
        //                                XMessageBox.Show(Resources.MSG017_MSG + Service.ErrFullMsg, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                return false;
        //                            }


        //                            //if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
        //                            //{
        //                            //    XMessageBox.Show(Resources.MSG017_MSG + Service.ErrFullMsg, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                            //    return false;
        //                            //}

        //                        //if (item.BindVarList["f_newrow"].VarValue.Equals("Y"))
        //                        //{

        ////                            //Remove
        ////                            cmdText = @"INSERT INTO OUT1001
        ////                                             ( SYS_DATE            , SYS_ID             , UPD_DATE       , UPD_ID         ,      
        ////                                               HOSP_CODE           , PKOUT1001          , RESER_YN       ,
        ////                                               NAEWON_DATE         , BUNHO              , GWA            ,
        ////                                               GUBUN               , DOCTOR             , RES_CHANGGU    ,                                               
        ////                                               JUBSU_TIME          , CHOJAE             , RES_GUBUN      , NAEWON_TYPE    ,
        ////                                               JUBSU_NO            , RES_INPUT_GUBUN    , NAEWON_YN      , JUBSU_GUBUN      )
        ////                                        VALUES
        ////                                             ( SYSDATE             , :q_user_id         , SYSDATE        , :q_user_id   , 
        ////                                               :f_hosp_code        , :f_pkout1001       , 'Y'            ,
        ////                                               :f_jinryo_pre_date  , :f_bunho           , :f_gwa         , 
        ////                                               NVL(:f_gubun, 'G1') , :f_doctor          , :f_changgu     ,
        ////                                               :f_jinryo_pre_time  , :f_chojae          , :f_res_gubun   , '0'          ,
        ////                                               :t_jubsu_no         , :f_input_gubun     , 'N'            , '01'          )";


        //                            NuroRES1001U00ReservationOut1001InsertArgs argsReservationOut =
        //                                new NuroRES1001U00ReservationOut1001InsertArgs();

        //                            argsReservationOut.Changgu = item.BindVarList["f_changgu"].VarValue;
        //                            argsReservationOut.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                            argsReservationOut.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                            argsReservationOut.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                            argsReservationOut.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;
        //                            argsReservationOut.ExamStatus = item.BindVarList["f_chojae"].VarValue;
        //                            argsReservationOut.InputType = item.BindVarList["f_input_gubun"].VarValue;
        //                            argsReservationOut.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                            argsReservationOut.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                            argsReservationOut.ReceptionNo = item.BindVarList["t_jubsu_no"].VarValue;
        //                            argsReservationOut.ReserType = item.BindVarList["f_res_gubun"].VarValue;
        //                            argsReservationOut.Type = item.BindVarList["f_gubun"].VarValue;
        //                            argsReservationOut.UserId = item.BindVarList["q_user_id"].VarValue;

        //                            UpdateResult resultInsertReservation = CloudService.Instance
        //                                .Submit<UpdateResult, NuroRES1001U00ReservationOut1001InsertArgs>(argsReservationOut);

        //                            flag = resultInsertReservation.Result;


        //                        }
        //                        else
        //                        {

        //                            /* 처방존재여부 */
        //                            t_chk = null;

        ////                            //Remove
        ////                            cmdText = @"SELECT DECODE(SIGN(COUNT(HANGMOG_CODE)), 1, 'Y', 'N')
        ////                                          FROM OCS1003
        ////                                         WHERE HOSP_CODE   = :f_hosp_code
        ////                                           AND BUNHO       = :f_bunho
        ////                                           AND ORDER_DATE  = :f_jinryo_pre_date
        ////                                           AND GWA         = :f_gwa
        ////                                           AND DOCTOR      = :f_doctor
        ////                                           AND NAEWON_TYPE = '0'";


        //                            NuroRES1001U00CheckingHangmogCodeArgs argsCheckingHangmogCode =
        //                                new NuroRES1001U00CheckingHangmogCodeArgs();

        //                            argsCheckingHangmogCode.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                            argsCheckingHangmogCode.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                            argsCheckingHangmogCode.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                            argsCheckingHangmogCode.PatientCode = item.BindVarList["f_bunho"].VarValue;

        //                            NuroRES1001U00CheckingHangmogCodeResult resultCheckingHangmogCode = CloudService.Instance
        //                                .Submit<NuroRES1001U00CheckingHangmogCodeResult, NuroRES1001U00CheckingHangmogCodeArgs>(
        //                                    argsCheckingHangmogCode);


        //                            t_chk = resultCheckingHangmogCode.Result;

        //                            //t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                            if (!TypeCheck.IsNull(t_chk))
        //                            {
        //                                if (!t_chk.ToString().Equals("N"))
        //                                {
        //                                    XMessageBox.Show(Resources.MSG018_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                    return false;
        //                                }
        //                            }
        ////                            //Remove
        ////                            cmdText = @"SELECT 'Y'
        ////                                              FROM DUAL
        ////                                             WHERE EXISTS ( SELECT BUNHO
        ////                                                              FROM OUT0123
        ////                                                             WHERE HOSP_CODE    = :f_hosp_code
        ////                                                               AND BUNHO        = :f_bunho
        ////                                                               AND FKOUT1001    = :f_pkout1001
        ////                                                               AND COMMENT_TYPE = '1' )";

        //                            NuroRES1001U00CheckingPatientExistenceArgs arsCheck =
        //                                new NuroRES1001U00CheckingPatientExistenceArgs();

        //                            arsCheck.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                            arsCheck.PatientCode = item.BindVarList["f_bunho"].VarValue;


        //                            NuroRES1001U00CheckingPatientExistenceResult resultCheck = CloudService.Instance
        //                                .Submit
        //                                <NuroRES1001U00CheckingPatientExistenceResult,
        //                                    NuroRES1001U00CheckingPatientExistenceArgs>(arsCheck);



        //                            object retVal = resultCheck.Result;

        //                            if (!TypeCheck.IsNull(retVal))
        //                            {
        //                                if (retVal.ToString() == "Y")
        //                                {
        ////                                    //Remove
        ////                                    cmdText = @"UPDATE OUT0123
        ////                                                   SET UPD_DATE     = SYSDATE
        ////                                                     , UPD_ID       = :q_user_id
        ////                                                     --, FKOUT1001    = :f_pkout1001
        ////                                                     , COMMENTS     = :f_reser_comment
        ////                                                     , RESER_GUBUN  = :f_reser_gubun 
        ////　　　　　　　　　　　　　　　　　　　　　　　　　　 , REQ_DATE     = TRUNC(SYSDATE)
        ////                                                 WHERE HOSP_CODE    = :f_hosp_code
        ////                                                   AND BUNHO        = :f_bunho
        ////                                                   AND FKOUT1001    = :f_pkout1001
        ////                                                   AND COMMENT_TYPE = '1'";


        //                                    NuroRES1001U00ReservationOut0123UpdateArgs argsUpdate =
        //                                        new NuroRES1001U00ReservationOut0123UpdateArgs();

        //                                    argsUpdate.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                                    argsUpdate.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                                    argsUpdate.ReserComment = item.BindVarList["f_reser_comment"].VarValue;
        //                                    argsUpdate.ReserType = item.BindVarList["f_reser_gubun"].VarValue;
        //                                    argsUpdate.UserId = item.BindVarList["q_user_id"].VarValue;


        //                                    UpdateResult resultUpdate = CloudService.Instance
        //                                        .Submit<UpdateResult, NuroRES1001U00ReservationOut0123UpdateArgs>(argsUpdate);
        //                                    flag = resultUpdate.Result;

        //                                }
        //                            }
        //                            else
        //                            {


        //                                if (item.BindVarList["f_reser_comment"].VarValue != "" || item.BindVarList["f_reser_gubun"].VarValue != "")
        //                                {
        ////                                    //Remove
        ////                                    cmdText = @"INSERT INTO OUT0123 
        ////                                                     ( SYS_DATE             , SYS_ID                    , UPD_DATE          , UPD_ID        
        ////                                                     , HOSP_CODE            , BUNHO                     , SEQ           
        ////                                                     , REQ_DATE             , REQ_TIME                  , REQ_GWA           , REQ_DOCTOR 
        ////                                                     , ANSWER_DATE          , ANSWER_TIME               , ANSWER_GWA        , ANSWER_DOCTOR
        ////                                                     , ANSWER_END_YN        , IN_OUT_GUBUN              , COMMENTS          
        ////                                                     , FKOUT1001            , FKINP1001                 , COMMENT_TYPE      , RESER_GUBUN)
        ////                                                VALUES 
        ////                                                     ( SYSDATE              , :q_user_id                , SYSDATE           , :q_user_id
        ////                                                     , :f_hosp_code         , :f_bunho                  , '1'            
        ////                                                     , TRUNC(SYSDATE)       , TO_CHAR(SYSDATE, 'HH24MI'), :f_gwa            , :f_doctor
        ////                                                     , :f_jinryo_pre_date   , :f_jinryo_pre_time        , '%'               , '%'
        ////                                                     , 'Y'                  , 'O'                       , :f_reser_comment
        ////                                                     , :f_pkout1001         , ''                        , '1'               , :f_reser_gubun ) ";



        //                                    NuroRES1001U00ReservationOut0123InsertArgs argsReservationOut0123 =
        //                                        new NuroRES1001U00ReservationOut0123InsertArgs();

        //                                    argsReservationOut0123.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                                    argsReservationOut0123.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                                    argsReservationOut0123.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                                    argsReservationOut0123.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;
        //                                    argsReservationOut0123.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                                    argsReservationOut0123.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                                    argsReservationOut0123.ReserComment = item.BindVarList["f_reser_comment"].VarValue;
        //                                    argsReservationOut0123.ReserType = item.BindVarList["f_reser_gubun"].VarValue;
        //                                    argsReservationOut0123.UserId = item.BindVarList["q_user_id"].VarValue;


        //                                    UpdateResult resultInsertReservation0123 = CloudService.Instance
        //                                        .Submit<UpdateResult, NuroRES1001U00ReservationOut0123InsertArgs>(
        //                                            argsReservationOut0123);

        //                                    flag = resultInsertReservation0123.Result;

        //                                }
        //                            }

        //                            if (!flag)
        //                            {
        //                                XMessageBox.Show(Resources.MSG017_MSG + Service.ErrFullMsg, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                return false;
        //                            }

        //                            //Remove
        ////                            cmdText = @"UPDATE OUT1001
        ////                                           SET UPD_ID       = :q_user_id        ,
        ////                                               UPD_DATE     = SYSDATE           ,
        ////                                               --PKOUT1001    = :t_pkres1001      ,
        ////                                               NAEWON_DATE  = :f_jinryo_pre_date,
        ////                                               JUBSU_TIME   = :f_jinryo_pre_time,
        ////                                               JUBSU_NO     = :t_jubsu_no
        ////                                         WHERE HOSP_CODE    = :f_hosp_code
        ////                                           AND PKOUT1001    = :f_pkout1001";

        //                            NuroRES1001U00ReservationOut1001UpdateArgs argsUpdateReservation1001 =
        //                                new NuroRES1001U00ReservationOut1001UpdateArgs();

        //                            argsUpdateReservation1001.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                            argsUpdateReservation1001.ExamPreTime = item.BindVarList["f_jinryo_pre_time"].VarValue;
        //                            argsUpdateReservation1001.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;
        //                            argsUpdateReservation1001.ReceptionNo = item.BindVarList["t_jubsu_no"].VarValue;
        //                            argsUpdateReservation1001.UserId = item.BindVarList["q_user_id"].VarValue;

        //                            UpdateResult resultUpdateReservation1001 = CloudService.Instance
        //                                .Submit<UpdateResult, NuroRES1001U00ReservationOut1001UpdateArgs>(
        //                                    argsUpdateReservation1001);

        //                            flag = resultUpdateReservation1001.Result;

        //                        }
        //                        break;

        //                    case DataRowState.Deleted:

        //                        /* 처방존재여부 */
        //                        t_chk = null;

        ////                        //Remove
        ////                        cmdText = @"SELECT DECODE(SIGN(COUNT(HANGMOG_CODE)), 1, 'Y', 'N')
        ////                                          FROM OCS1003
        ////                                         WHERE HOSP_CODE   = :f_hosp_code
        ////                                           AND BUNHO       = :f_bunho
        ////                                           AND ORDER_DATE  = :f_jinryo_pre_date
        ////                                           AND GWA         = :f_gwa
        ////                                           AND DOCTOR      = :f_doctor
        ////                                           AND NAEWON_TYPE = '0'";

        //                        NuroRES1001U00CheckingHangmogCodeArgs argsCheckingHangmogCodeDelete =
        //                                new NuroRES1001U00CheckingHangmogCodeArgs();

        //                        argsCheckingHangmogCodeDelete.DepartmentCode = item.BindVarList["f_gwa"].VarValue;
        //                        argsCheckingHangmogCodeDelete.DoctorCode = item.BindVarList["f_doctor"].VarValue;
        //                        argsCheckingHangmogCodeDelete.ExamPreDate = item.BindVarList["f_jinryo_pre_date"].VarValue;
        //                        argsCheckingHangmogCodeDelete.PatientCode = item.BindVarList["f_bunho"].VarValue;

        //                        NuroRES1001U00CheckingHangmogCodeResult resultCheckingHangmogCodeDelete = CloudService.Instance
        //                            .Submit<NuroRES1001U00CheckingHangmogCodeResult, NuroRES1001U00CheckingHangmogCodeArgs>(
        //                                argsCheckingHangmogCodeDelete);


        //                        t_chk = resultCheckingHangmogCodeDelete.Result;


        //                        //t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                        if (!TypeCheck.IsNull(t_chk))
        //                        {
        //                            if (!t_chk.ToString().Equals("N"))
        //                            {
        //                                XMessageBox.Show(Resources.MSG018_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
        //                                return false;
        //                            }
        //                        }

        ////                        //Remove
        ////                        cmdText = @"DELETE FROM OUT0123
        ////                                     WHERE HOSP_CODE    = :f_hosp_code
        ////                                       AND BUNHO        = :f_bunho
        ////                                       AND FKOUT1001    = :f_pkout1001
        ////                                       AND COMMENT_TYPE = '1'";


        //                        NuroRES1001U00ReservationOut0123DeleteArgs argsDeleteReservation =
        //                            new NuroRES1001U00ReservationOut0123DeleteArgs();

        //                        argsDeleteReservation.PatientCode = item.BindVarList["f_bunho"].VarValue;
        //                        argsDeleteReservation.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;

        //                        UpdateResult resultDeleteReservation = CloudService.Instance
        //                            .Submit<UpdateResult, NuroRES1001U00ReservationOut0123DeleteArgs>(argsDeleteReservation);


        //                        if (!resultDeleteReservation.Result)
        //                        {

        //                        }

        //                        //Remove
        ////                        cmdText = @"DELETE FROM OUT1001
        ////                                     WHERE HOSP_CODE   = :f_hosp_code
        ////                                       AND PKOUT1001   = :f_pkout1001";


        //                        NuroRES1001U00ReservationOut1001DeleteArgs argsDeleteReservationOut1001 =
        //                            new NuroRES1001U00ReservationOut1001DeleteArgs();

        //                        argsDeleteReservationOut1001.Pkout1001 = item.BindVarList["f_pkout1001"].VarValue;

        //                        UpdateResult resultDeleteReservationOut1001 = CloudService.Instance
        //                            .Submit<UpdateResult, NuroRES1001U00ReservationOut1001DeleteArgs>(argsDeleteReservationOut1001);

        //                        flag = resultDeleteReservationOut1001.Result;

        //                        break;
        //                }

        //                //return Service.ExecuteNonQuery(cmdText, item.BindVarList);

        //                return flag;
        //            }
        //        }

        #endregion

        private void layReserList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layReserList.SetBindVarValue("f_hosp_code", this.mHospCode);
            //using mBunho to switch bunho between 2 tabs
            //this.layReserList.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layReserList.SetBindVarValue("f_bunho", this.mBunho);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.fbxDoctor.Clear();
            this.dbxDoctor_name.Text = "";
            this.mDoctor = "";
        }

        private void xGrid1_QueryStarting(object sender, CancelEventArgs e)
        {
            this.xGrid1.SetBindVarValue("f_hosp_code", this.mHospCode);
            //using mBunho to switch bunho between 2 tabs
            //this.xGrid1.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.xGrid1.SetBindVarValue("f_bunho", this.mBunho);

        }

        private void btnReserOrder_Click(object sender, EventArgs e)
        {
            IHIS.Framework.IXScreen aScreen;

            //using mBunho to switch bunho between 2 tabs
            //string bunho = this.paBox.BunHo;
            string bunho = this.mBunho;

            aScreen = XScreen.FindScreen("SCHS", "SCH0201U10");

            if (aScreen == null)
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", bunho);

                XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201U10", ScreenOpenStyle.ResponseFixed,
                    ScreenAlignment.ScreenMiddleCenter, openParams);
            }
            else
            {
                ((XScreen)aScreen).Activate();
            }
        }

        private void txtUser_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (e.DataValue == "")
            {
                dbxUserName.ResetData();
                return;
            }

            this.layUserName.SetBindVarValue("f_user", e.DataValue);
            this.layUserName.QueryLayout();

            if (this.layUserName.GetItemValue("user_name").ToString() == "")
            {
                XMessageBox.Show(Resources.MSG019_MSG, Resources.MSG019_CAP, MessageBoxIcon.Warning);
                this.txtUser.Focus();
                this.txtUser.SelectAll();
                e.Cancel = true;

            }
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            this.dbxUserName.ResetData();
            this.txtUser.ResetData();
            this.txtUser.Focus();
        }

        //그리드에서 직접 삭제시 사용
        private void DeleteReser(int rowNum)
        {
            int curRowIndex = rowNum;

            if (curRowIndex < 0) return;

            if (xGrid1.GetItemString(curRowIndex, "naewon_yn") != "N")
            {
                XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                return;
            }

            mbxMsg = Resources.MSG005_MSG;
            mbxCap = Resources.MSG005_CAP;
            DialogResult dialogResult = XMessageBox.Show(mbxMsg, mbxCap, MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
                return;

            //삭제건은 Delete Table로 넘긴다.
            if (grdDeleteOUT1001.DeletedRowTable != null
                &&
                grdDeleteOUT1001.DeletedRowTable.Select(
                    " pkout1001 = '" + xGrid1.GetItemString(curRowIndex, "pkout1001") + "' ", "").Length == 0)
            {
                grdDeleteOUT1001.LayoutTable.ImportRow(xGrid1.LayoutTable.Rows[curRowIndex]);
                grdDeleteOUT1001.DisplayData();
                grdDeleteOUT1001.DeleteRow(0);
                //if (!checkBookingDel(preTimeGrid))
                //{
                //    grdDeleteOUT1001.Reset();
                //    return;
                //}

            }
            else if (grdDeleteOUT1001.DeletedRowTable == null)
            {
                grdDeleteOUT1001.LayoutTable.ImportRow(xGrid1.LayoutTable.Rows[curRowIndex]);
                grdDeleteOUT1001.DisplayData();
                grdDeleteOUT1001.DeleteRow(0);
                //if (!checkBookingDel(preTimeGrid))
                //{
                //    grdDeleteOUT1001.Reset();
                //    return;
                //}

            }

            if (!SaveReserInfo("3")) // 3 DeleteBooking
            {
                grdDeleteOUT1001.Reset();

            }

        }
        private bool checkBookingDel(string preTimeGrid)
        {
            string preTime = "";
            if (!LoadMappingCode())
            {
                XMessageBox.Show(Resources.MSG023_MSG, Resources.MSG022_CAP, MessageBoxIcon.Error);
                return false;
            }
            if (preTimeGrid == string.Empty)
            {
                DataRowCollection Dr = grdDeleteOUT1001.DeletedRowTable.Rows;
                preTime = Dr[0]["jinryo_pre_time"].ToString() + ":00";
            }
            else
            {
                preTime = preTimeGrid;
            }
            //string doctorCode = mDoctor.Remove(0, 2);

            //OrcaHelper(mBunho, paBox.SuName, paBox.SuName2, this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", mGwa, doctorCode, mGwa, "02", "");
            BookingInfo bk = new BookingInfo(mBunho, paBox.SuName, paBox.SuName2,
                this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", mGwaMap, mDoctorMap, "",
                "02", "");

            if (rbtLinkClinic.Checked && mBunhoLink != "")
            {
                bk = new BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2,
                this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", mGwaMap, mDoctorMap, "",
                "02", "");
            }

            ORCA.ORCAServices sentBk = new ORCA.ORCAServices(bk);
            msgOutput = null;
            try
            {
                RES1001U00CheckUsingOrcaArgs args = new RES1001U00CheckUsingOrcaArgs();
                RES1001U00CheckUsingOrcaResult result = new RES1001U00CheckUsingOrcaResult();
                if (rbtMyClinic.Checked)
                {
                    args.HospCodeLink = UserInfo.HospCode;
                    result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                    {
                        sentBk.SentBooking(out msgOutput);
                    }
                }
                else if (rbtLinkClinic.Checked)
                {
                    args.HospCodeLink = this.mHospCodeLink;
                    result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                    {
                        sentBk.SentBooking(out msgOutput, result.OrcaIp, result.OrcaUser, result.OrcaPassword);
                    }
                }

            }

            catch
            {
                XMessageBox.Show(Resources.MSG021_MSG, Resources.MSG021_CAP, MessageBoxIcon.Warning);
            }
            if (!TypeCheck.IsNull(msgOutput) && checkDoctor ==true)
            {
                XMessageBox.Show(msgOutput);
                if (Array.IndexOf(msgOrca, msgOutput.Substring(0, 2)) < 0)
                {
                    return false;
                }

            }


            return true;
        }
        private void xGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                //disable editing if user editing row from outside hospital
                if (!String.IsNullOrEmpty(xGrid1.GetItemString(xGrid1.CurrentRowNumber, "clinic_name")) && xGrid1.GetItemString(xGrid1.CurrentRowNumber, "clinic_name") != UserInfo.HospName) return;

                int rowNum = this.xGrid1.GetHitRowNumber(e.Y);

                if (this.xGrid1.GetItemString(rowNum, "jinryo_irai_yn") != "Y")
                {
                    DeleteReser(rowNum);
                }
                else
                {

                    if (UserInfo.UserGubun == UserType.Doctor)
                    {
                        if (xGrid1.GetItemString(rowNum, "res_user") != UserInfo.UserID)
                        {
                            XMessageBox.Show(Resources.MSG020_MSG, Resources.MSG020_CAP, MessageBoxIcon.Information);
                            return;
                        }
                    }

                    IHIS.Framework.IXScreen aScreen;

                    aScreen = XScreen.FindScreen("OCSO", "OCS0503U00");

                    if (aScreen == null)
                    {
                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", xGrid1.GetItemString(rowNum, "bunho"));
                        openParams.Add("req_gwa", xGrid1.GetItemString(rowNum, "gwa"));
                        openParams.Add("req_doctor", xGrid1.GetItemString(rowNum, "doctor"));
                        openParams.Add("naewon_date", xGrid1.GetItemString(rowNum, "jinryo_pre_date"));
                        openParams.Add("reser_time", xGrid1.GetItemString(rowNum, "jinryo_pre_time"));
                        openParams.Add("req_date", xGrid1.GetItemString(rowNum, "irai_date"));
                        openParams.Add("naewon_key", xGrid1.GetItemString(rowNum, "pkout1001"));

                        XScreen.OpenScreenWithParam(this, "OCSO", "OCS0503U00", ScreenOpenStyle.PopUpFixed,
                            ScreenAlignment.ScreenMiddleCenter, openParams);
                    }
                    else
                    {
                        ((XScreen)aScreen).Activate();
                    }
                    this.Close();

                }

            }

        }

        private void xGrid1_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            //disable editing if user editing row from outside hospital
            //MED-9466 if didnot select a day, show message
            if (this.calSchedule.SelectedDays.Count < 1)
            {
                XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrEmpty(xGrid1.GetItemString(xGrid1.CurrentRowNumber, "clinic_name")) && xGrid1.GetItemString(xGrid1.CurrentRowNumber, "clinic_name") != UserInfo.HospName) return;

            if (e.ColName == "button")
            {
                if (this.xGrid1.GetItemString(e.RowNumber, "jinryo_irai_yn") != "Y")
                {
                    DeleteReser(e.RowNumber);
                }
                else
                {
                    IHIS.Framework.IXScreen aScreen;

                    aScreen = XScreen.FindScreen("OCSO", "OCS0503U00");

                    if (aScreen == null)
                    {
                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("bunho", xGrid1.GetItemString(e.RowNumber, "bunho"));
                        openParams.Add("req_gwa", xGrid1.GetItemString(e.RowNumber, "gwa"));
                        openParams.Add("req_doctor", xGrid1.GetItemString(e.RowNumber, "doctor"));
                        openParams.Add("naewon_date", xGrid1.GetItemString(e.RowNumber, "jinryo_pre_date"));
                        openParams.Add("reser_time", xGrid1.GetItemString(e.RowNumber, "jinryo_pre_time"));
                        openParams.Add("req_date", xGrid1.GetItemString(e.RowNumber, "irai_date"));
                        openParams.Add("naewon_key", xGrid1.GetItemString(e.RowNumber, "pkout1001"));

                        XScreen.OpenScreenWithParam(this, "OCSO", "OCS0503U00", ScreenOpenStyle.PopUpFixed,
                            ScreenAlignment.ScreenMiddleCenter, openParams);
                    }
                    else
                    {
                        ((XScreen)aScreen).Activate();
                    }
                    this.Close();
                }
            }
            else if (e.ColName == "reser_button")
            {
                Hashtable ht = new Hashtable();
                ht.Add("open_mode", "MODIFY");
                ht.Add("bunho", e.DataRow["bunho"].ToString());
                ht.Add("pkout1001", e.DataRow["pkout1001"].ToString());
                ht.Add("gwa", e.DataRow["gwa"].ToString());
                ht.Add("doctor", e.DataRow["doctor"].ToString());
                ht.Add("reser_comment", e.DataRow["reser_comment"].ToString());
                ht.Add("reser_gubun", e.DataRow["reser_gubun"].ToString());
                ht.Add("jinryo_pre_date", e.DataRow["jinryo_pre_date"].ToString());
                ht.Add("jinryo_pre_time", e.DataRow["jinryo_pre_time"].ToString());

                ReserCommentForm rcf = new ReserCommentForm(ht, this.mHospCodeLink, this.tabIsAll);
                rcf.ShowDialog(this);
                xGrid1.QueryLayout(true);
                //grdOUT1001_AM.QueryLayout(true);
                //grdOUT1001_PM.QueryLayout(true);             

            }
        }

        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;
        private int mCurRowIndex;
        private string msgOutput;
        private void grd_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //validating
            if (String.IsNullOrEmpty(this.paBox.BunHo))
            {
                XMessageBox.Show(Resources.MSG024_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                paBox.Focus();
                return;
            }

            XEditGrid grd = sender as XEditGrid;

            int curRowIndex = -1;
            curRowIndex = grd.GetHitRowNumber(e.Y);
            if (curRowIndex < 0) return;

            //using mBunho to switch bunho between 2 tabs
            //this.mBunho = this.paBox.BunHo;

            // 진료의뢰에서 저장된 예약건이거나 현재 진료의로에서 오픈중인경우에는 별도 로직
            if ((grd.GetItemString(curRowIndex, "jinryo_irai_yn") == "Y") || (this.mCallerName == "OCS0503U00"))
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    //MED-10647
                    if (this.calSchedule.SelectedDays.Count < 1) 
                    {
                        XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Warning);
                        return;
                    }

                    //MED-12239
                    if (this.fbxDoctor.GetDataValue().Trim() == "")
                    {
                        XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG002_CAP, MessageBoxIcon.Warning);
                        return;
                    }

                    //disable editing if user editing row from outside hospital
                    if (!String.IsNullOrEmpty(grd.GetItemString(curRowIndex, "clinic_name")) && grd.GetItemString(curRowIndex, "clinic_name") != UserInfo.HospName) return;

                    if (calSchedule.SelectedDays.Count < 1)
                    {
                        mbxMsg = Resources.MSG003_MSG;
                        mbxCap = Resources.MSG003_CAP;
                        XMessageBox.Show(mbxMsg, mbxCap);
                        return;
                    }

                    string p_bunho = grd.GetItemString(curRowIndex, "bunho");
                    //string p_bunho = paBox.BunHo;
                    string p_gwa = grd.GetItemString(curRowIndex, "gwa");
                    string p_doctor = grd.GetItemString(curRowIndex, "doctor");
                    string p_reser_date = calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd");
                    string p_reser_time = grd.GetItemString(curRowIndex, "jinryo_pre_time");
                    string p_irai_date = grd.GetItemString(curRowIndex, "reser_date");
                    string p_fkout1001 = grd.GetItemString(curRowIndex, "pkout1001");

                    //예약중이면 화면오픈
                    if (grd.GetItemString(curRowIndex, "bunho") != "")
                    {
                        //using mBunho to switch bunho between 2 tabs
                        //if (p_bunho != this.paBox.BunHo)
                        if (p_bunho != this.mBunho)
                        {
                            XMessageBox.Show(Resources.MSG021_MSG, Resources.MSG021_CAP, MessageBoxIcon.Information);
                            return;
                        }


                        if (UserInfo.UserGubun == UserType.Doctor)
                        {
                            if (grd.GetItemString(curRowIndex, "res_user") != UserInfo.UserID)
                            {
                                XMessageBox.Show(Resources.MSG020_MSG, Resources.MSG020_CAP, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        IHIS.Framework.IXScreen aScreen;

                        aScreen = XScreen.FindScreen("OCSA", "OCS0503U00");

                        if (aScreen == null)
                        {
                            CommonItemCollection openParams = new CommonItemCollection();
                            openParams.Add("bunho", p_bunho);
                            openParams.Add("req_gwa", p_gwa);
                            openParams.Add("req_doctor", p_doctor);
                            openParams.Add("naewon_date", p_reser_date);
                            openParams.Add("reser_time", p_reser_time);
                            openParams.Add("req_date", p_irai_date);
                            openParams.Add("naewon_key", p_fkout1001);

                            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.PopUpFixed,
                                ScreenAlignment.ScreenMiddleCenter, openParams);
                        }
                        else
                        {
                            ((XScreen)aScreen).Activate();
                        }
                        this.Close();

                    }
                    else // 예약중이 아님 == 진료의뢰에서 들어온 것임
                    {
                        IHIS.Framework.XScreen scrOpener = (XScreen)Opener;

                        CommonItemCollection commandParams = new CommonItemCollection();
                        //commandParams.Add("bunho", p_bunho);
                        //using mBunho to switch bunho between 2 tabs
                        //commandParams.Add("bunho", paBox.BunHo);
                        commandParams.Add("bunho", this.mBunho);
                        commandParams.Add("gwa", p_gwa);
                        commandParams.Add("doctor", p_doctor);
                        commandParams.Add("naewon_date", p_reser_date);
                        commandParams.Add("reser_time", p_reser_time);

                        scrOpener.Command(ScreenID, commandParams);
                        //MED-10364
                        if (CheckDuplicate()) return;
                        InsertReserData(grd, curRowIndex);
                        this.Close();
                    }
                }

            }
            else
            {
                if (e.Button == MouseButtons.Left && e.Clicks == 2)
                {
                    //MED-10945
                    //if (!SaveGrids()) return;
                    //MED-10647
                    if (this.calSchedule.SelectedDays.Count < 1)
                    {
                        XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Warning);
                        return;
                    }

                    //MED-12239
                    if (this.fbxDoctor.GetDataValue().Trim() == "")
                    {
                        XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG002_CAP, MessageBoxIcon.Warning);
                        return;
                    }

                    //disable editing if user editing row from outside hospital
                    if (!String.IsNullOrEmpty(grd.GetItemString(curRowIndex, "clinic_name")) && grd.GetItemString(curRowIndex, "clinic_name") != UserInfo.HospName) return;

                    if (grd.GetItemString(curRowIndex, "bunho") != "")
                        DeleteReserData(grd, curRowIndex);
                    else
                    {
                        // Check doubleReser not tranfer Orca
                        if (DoubleReser(grdOUT1001_AM, mBunho))
                            return;

                        if (DoubleReser(grdOUT1001_PM, mBunho))
                            return;
                        //if (!LoadMappingCode())
                        //{
                        //    XMessageBox.Show(Resources.MSG023_MSG, Resources.MSG022_CAP, MessageBoxIcon.Error);
                        //}
                        //else
                        //{
                            //MED-10364
                            if (CheckDuplicate(mBunho, cboGwa.GetDataValue(), this.calSchedule.SelectedDays[0].Date.ToString("yyyy/MM/dd"),
                                grd.GetItemString(curRowIndex, "jinryo_pre_time"))) return;

                            if (grd.GetItemString(curRowIndex, "jinryo_yn") == "Y" )
                            {
                                #region Comment by Update Tranfer Orca
                                //    string preTime = (grd.GetItemString(curRowIndex, "jinryo_pre_time") + ":00").Insert(2,
                                //    ":");
                                ////string doctorCode = mDoctor.Remove(0, 2);
                                //BookingInfo bk = new BookingInfo(mBunho, paBox.SuName, paBox.SuName2,
                                //    this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", mGwaMap,
                                //    mDoctorMap, "", "01","");


                                ////check link clinic or not
                                //if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                                //{
                                //    bk = new BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2,
                                //    this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), preTime, "", mGwaMap,
                                //    mDoctorMap, "", "01", "");
                                //}

                                //ORCAServices sentBk = new ORCAServices(bk);
                                //msgOutput = null;
                                //try
                                //{
                                //    //sentBk.SentBooking(out msgOutput);

                                //    //check whether if Hospital using Orca or not
                                //    RES1001U00CheckUsingOrcaArgs args = new RES1001U00CheckUsingOrcaArgs();
                                //    RES1001U00CheckUsingOrcaResult result = new RES1001U00CheckUsingOrcaResult();
                                //    if (rbtMyClinic.Checked)
                                //    {
                                //        args.HospCodeLink = UserInfo.HospCode;
                                //        result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                                //        //if yes, request to ORCA
                                //        if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                                //        {
                                //            sentBk.SentBooking(out msgOutput);
                                //        }
                                //        else //else just insert to KCCK DB only
                                //        {
                                //            InsertReserData(grd, curRowIndex);                                            
                                //            return;
                                //        }
                                //    }
                                //    else if (rbtLinkClinic.Checked)
                                //    {
                                //        //check whether if Hospital using Orca or not
                                //        args.HospCodeLink = this.mHospCodeLink;
                                //        result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                                //        //if yes, request to ORCA
                                //        if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                                //        {
                                //            sentBk.SentBooking(out msgOutput, result.OrcaIp, result.OrcaUser, result.OrcaPassword);                                            
                                //        }
                                //        else //else just insert to KCCK DB only
                                //        {
                                //InsertReserData(grd, curRowIndex);                                           
                                //return;
                                //        }
                                //    }
                                //}

                                //catch
                                //{
                                //    XMessageBox.Show(Resources.MSG021_MSG, Resources.MSG021_CAP, MessageBoxIcon.Warning);
                                //}

                                //if (msgOutput != null && msgOutput.Length > 1 && Array.IndexOf(msgOrca,msgOutput.Substring(0,2)) > -1)
                                //{
                                //    InsertReserData(grd, curRowIndex);
                                //    if (!checkDoctor)
                                //    {
                                //        checkBookingDel(preTime);
                                //    }
                                //}
                                //if (msgOutput != string.Empty && checkDoctor == true)
                                //{
                                //    msgOutput = msgOutput + "-" + XMsg.GetMsg(msgOutput);
                                //    XMessageBox.Show(msgOutput);
                                //}               
                                #endregion

                                InsertReserData(grd, curRowIndex);                                         
                                                                          
                            }
                            else
                            {
                                mbxMsg = Resources.MSG009_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap);
                            }
                        //}
                    }

                }
                else if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    if (grd.GetItemString(curRowIndex, "bunho") == "")
                        return;

                    if (grd.CurrentColName != "modify") //예약변경클릭시 안먹는 경우가 있어서 추가
                    {
                        mCurRowIndex = grd.GetHitRowNumber(e.Y);

                        Size dragSize = SystemInformation.DragSize;
                        dragFrom = "";
                        dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                            e.Y - (dragSize.Height / 2)), dragSize);
                    }

                    // trường hợp một dòng của grid có dữ liệu thì phải call hàm bằng tay
                    if (grd.GetItemString(curRowIndex, "bunho") != "" && grd.CurrentColName == "comment_button")
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("bunho");
                        dt.Columns.Add("pkout1001");
                        dt.Columns.Add("reser_comment");
                        dt.Columns.Add("reser_gubun");
                        dt.Columns.Add("jinryo_pre_date");
                        dt.Columns.Add("jinryo_pre_time");
                        DataRow dr = dt.NewRow();
                        dr["bunho"] = grd.GetItemString(curRowIndex, "bunho");
                        dr["pkout1001"] = grd.GetItemString(curRowIndex, "pkout1001");
                        dr["reser_comment"] = grd.GetItemString(curRowIndex, "reser_comment");
                        dr["reser_gubun"] = grd.GetItemString(curRowIndex, "reser_gubun");
                        dr["jinryo_pre_date"] = grd.GetItemString(curRowIndex, "jinryo_pre_date");
                        dr["jinryo_pre_time"] = grd.GetItemString(curRowIndex, "jinryo_pre_time");
                        grdRES1001_AM_GridButtonClick(this.grdOUT1001_AM,
                            new GridButtonClickEventArgs(grd.CurrentColName, mCurRowIndex, dr));
                    }
                }
            }

        }

        //MED-10364
        private bool CheckDuplicate(string bunho, string gwa, string preDate, string preTime)
        {
            List<RES1001U00SaveLayoutItemInfo> lstData = new List<RES1001U00SaveLayoutItemInfo>();

            RES1001U00SaveLayoutItemInfo info = new RES1001U00SaveLayoutItemInfo();
            info.Bunho = bunho;
            info.Gwa = gwa;
            info.JinryoPreDate = preDate;
            info.JinryoPreTime = preTime;
            lstData.Add(info);

            RES1001U00CheckDuplicateArgs args = new RES1001U00CheckDuplicateArgs(lstData, mHospCodeLink);
            RES1001U00CheckDuplicateResult result = CloudService.Instance.Submit<RES1001U00CheckDuplicateResult, RES1001U00CheckDuplicateArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.DuplicateResult != "0")
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(Resources.MSG026_MSG);
                    sb.AppendLine(String.Format("{0}  {1}  {2}  {3}", lstData[0].JinryoPreDate, lstData[0].JinryoPreTime.Insert(2, ":"), result.GwaName, result.DoctorName));
                    sb.AppendLine(Resources.MSG027_MSG);
                    XMessageBox.Show(sb.ToString(), Resources.MSG004_CAP, MessageBoxIcon.Warning);
                    return true;
                }
            }
            return false;
        }

        //MED-10364
        private bool CheckDuplicate()
        {
            // cloud updated
            List<RES1001U00SaveLayoutItemInfo> lstData = GetListDataForSaveLayout();
            if (lstData.Count > 0)
            {
                RES1001U00CheckDuplicateArgs args = new RES1001U00CheckDuplicateArgs(lstData, mHospCodeLink);
                RES1001U00CheckDuplicateResult result = CloudService.Instance.Submit<RES1001U00CheckDuplicateResult, RES1001U00CheckDuplicateArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (result.DuplicateResult != "0")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(Resources.MSG026_MSG);
                        sb.AppendLine(String.Format("{0}  {1}  {2}  {3}", lstData[0].JinryoPreDate, lstData[0].JinryoPreTime.Insert(2, ":"), result.GwaName, result.DoctorName));
                        sb.AppendLine(Resources.MSG027_MSG);
                        XMessageBox.Show(sb.ToString(), Resources.MSG004_CAP, MessageBoxIcon.Warning);
                        return true;
                    }
                } 
            }
            return false;
        }

        private void grd_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void grd_MouseMove(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if (grd != null)
            {
                if (rbtMyClinic.Checked)
                {
                    int curRowIndex = -1;
                    curRowIndex = grd.GetHitRowNumber(e.Y);
                    if (curRowIndex < 0)
                    {
                        toolTip1.Active = false;
                        curPreRowIndex = -1;
                        curPreX = -1;
                    }
                    else if ((curPreRowIndex != curRowIndex || Math.Abs(e.X - curPreX) > 20) && curRowIndex >= 0)
                    {
                        string reserTime = grd.GetItemString(curRowIndex, "jinryo_pre_time");//"1554"; // 
                        string patientId = grd.GetItemString(curRowIndex, "bunho");//"000001392"; // 
                        bool hasReser = false;
                        string textTip = GetToolTipText(patientId, reserTime, out hasReser);
                        if (hasReser)
                        {
                            toolTip1.Show(textTip, grd, e.Location);
                            toolTip1.Active = true;
                            toolTip1.ShowAlways = true;
                            curPreRowIndex = curRowIndex;
                            curPreX = e.X;
                        }
                        else
                        {
                            toolTip1.Active = false;
                            curPreRowIndex = -1;
                            curPreX = -1;
                        }
                    }
                }

                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    if (dragBoxFromMouseDown != Rectangle.Empty &&
                        !dragBoxFromMouseDown.Contains(e.X, e.Y))
                    {
                        screenOffset = SystemInformation.WorkingArea.Location;
                        string dragInfo = "[" + grd.GetItemString(mCurRowIndex, "bunho") + "]" +
                                          grd.GetItemString(mCurRowIndex, "suname");
                        DragHelper.CreateDragCursor(grd, dragInfo, this.Font);
                        string am_pm = (grd.Name == "grdOUT1001_AM") ? "AM" : "PM";
                        grd.DoDragDrop(am_pm + "|" + mCurRowIndex.ToString(), DragDropEffects.Move);

                    }
                }
            }
            else
            {
                toolTip1.Active = false;
                curPreRowIndex = -1;
                curPreX = -1;
            }
        }

        private void xGrid1_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["jinryo_irai_yn"].ToString() == "Y")
                e.BackColor = System.Drawing.Color.LightPink;

            if (e.DataRow["clinic_name"].ToString() != "" && e.DataRow["clinic_name"].ToString() != UserInfo.HospName)
            {
                e.BackColor = System.Drawing.Color.Yellow;
            }
        }

        public string mReturnedBunho = "";

        private void btnPABunho_Click(object sender, EventArgs e)
        {
            mReturnedBunho = "";
            BunhoSelectForm bsf = new BunhoSelectForm();
            bsf.ShowDialog(this);
            this.mReturnedBunho = bsf.ReturnBunho;

            //XMessageBox.Show(mReturnedBunho);

            if (this.mReturnedBunho != "")
            {
                this.paBox.SetPatientID(this.mReturnedBunho);
            }

        }

        private void calSchedule_DaySelected(object sender, XCalendarDaySelectedEventArgs e)
        {
            this.grdDeleteOUT1001.Reset();

            this.mCurrentDate = e.DateItems[0].Date.ToString("yyyy/MM/dd").Trim();
            grdOUT1001_AM.QueryLayout(true);
            grdOUT1001_PM.QueryLayout(true);
            LoadBookingClinicRefer();
        }

        #region Update Code

        //lay UserName
        private IList<object[]> LayUserName(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();
            NuroRES1001U00UserNameArgs args = new NuroRES1001U00UserNameArgs();

            args.UserId = list["f_user"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00UserNameResult result = CloudService.Instance
                .Submit<NuroRES1001U00UserNameResult, NuroRES1001U00UserNameArgs>(args);

            if (result != null)
            {
                object[] objects =
                {
                    result.UserName
                };
                lstResult.Add(objects);

            }

            return lstResult;
        }

        private List<string> LayUserNameParamList()
        {
            List<string> param = new List<string>();
            param.Add("f_user");
            return param;
        }

        //layOCS0105.QuerySQL
        private IList<object[]> GridGongbiList(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            NuroRES1001U00DoctorReservationDateListArgs args = new NuroRES1001U00DoctorReservationDateListArgs();
            args.DoctorCode = list["f_doctor"].VarValue;
            args.EndDate = list["f_end_date"].VarValue;
            args.StartDate = list["f_start_date"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00DoctorReservationDateListResult result = CloudService.Instance
                .Submit<NuroRES1001U00DoctorReservationDateListResult, NuroRES1001U00DoctorReservationDateListArgs>(args);

            if (result != null)
            {
                IList<NuroRES1001U00DoctorReservationDateListItemInfo> listItem = result.DoctorResDateListItem;

                foreach (NuroRES1001U00DoctorReservationDateListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.DoctorCode,
                        item.Date,
                        item.ResDate,
                        item.ResFlag,
                        item.ResInwon,
                        item.ResOutwon
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        private IList<object[]> LoadDataLinkHospCode(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            RES1001U00FbxHospCodeLinkArgs args = new RES1001U00FbxHospCodeLinkArgs();
            args.Bunho = (String.IsNullOrEmpty(this.paBox.BunHo)) ? "" : this.paBox.BunHo;

            RES1001U00FbxHospCodeLinkResult result = CloudService.Instance
                .Submit<RES1001U00FbxHospCodeLinkResult, RES1001U00FbxHospCodeLinkArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                IList<RES1001U00FbxHospCodeLinkListItemInfo> listItem = result.FbxHospCodeList;

                foreach (RES1001U00FbxHospCodeLinkListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.HospCode,
                        item.HospName,
                        item.Address,
                        item.Telephone
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        //layReseredData.QuerySQL
        private IList<object[]> LayReseredData(BindVarCollection list)
        {

            IList<object[]> lstResult = new List<object[]>();

            NuroRES1001U00ReseredDataListArgs args = new NuroRES1001U00ReseredDataListArgs();
            args.DepartmentCode = list["f_gwa"].VarValue;
            args.DoctorCode = list["f_doctor"].VarValue;
            args.ExamPreDate = list["f_jinryo_pre_date"].VarValue;
            args.FromTime = list["f_from_time"].VarValue;
            args.ReserFromTime = list["o_reser_from_time"].VarValue;
            args.ReserToTime = list["o_reser_to_time"].VarValue;
            args.ToTime = list["f_to_time"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00ReseredDataListResult result = CloudService.Instance
                .Submit<NuroRES1001U00ReseredDataListResult, NuroRES1001U00ReseredDataListArgs>(args);

            if (result != null)
            {
                IList<NuroRES1001U00ReseredDataListItemInfo> listItem = result.ReseredDataListItem;

                foreach (NuroRES1001U00ReseredDataListItemInfo item in listItem)
                {

                    object[] objects =
                    {
                        item.ReceptionTime,
                        item.PatientCode,
                        item.PatientName1,
                        item.PatientName2,
                        item.ExamStatus,
                        item.UpdDate,
                        item.Pkout1001,
                        item.ComingDate,
                        item.DepartmentCode,
                        item.ReceptionNo,
                        item.Type,
                        item.DoctorCode,
                        item.ResType,
                        item.ResUserName,
                        item.ResInputType,
                        item.ComingStatus,
                        item.NewRow,
                        item.ExamState,
                        item.ExamIraiState,
                        item.ResUser,
                        item.IpwonStatus,
                        item.ReserComments,
                        item.ReserType,
                        item.ClinicName
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }


        //Lay Reser 
        private IList<object[]> LayReser(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();

            NuroRES1001U00ReserListArgs args = new NuroRES1001U00ReserListArgs();
            args.PatientCode = list["f_bunho"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00ReserListResult result =
                CloudService.Instance.Submit<NuroRES1001U00ReserListResult, NuroRES1001U00ReserListArgs>(args);

            if (result != null)
            {
                foreach (NuroRES1001U00ReserListItemInfo items in result.ReserListItem)
                {
                    object[] objects =
                    {
                        items.ComingDate,
                        items.ExamPreTime,
                        items.DepartmentName,
                        items.DoctorName
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }

        // Doctor Reser List Item Info
        private IList<object[]> GridDoctorReser(BindVarCollection list)
        {
            IList<object[]> lstResult = new List<object[]>();

            NuroRES1001U00DoctorReserListArgs args = new NuroRES1001U00DoctorReserListArgs();
            args.PatientCode = list["f_bunho"].VarValue;
            args.HospCodeLink = this.mHospCodeLink;
            args.TabIsAll = this.tabIsAll;

            NuroRES1001U00DoctorReserListResult result =
                CloudService.Instance.Submit<NuroRES1001U00DoctorReserListResult, NuroRES1001U00DoctorReserListArgs>(
                    args);

            if (result != null)
            {
                foreach (NuroRES1001U00DoctorReserListItemInfo items in result.DoctorReserListItem)
                {
                    object[] objects =
                    {
                        items.ComingDate,
                        items.ExamPreTime,
                        items.DepartmentName,
                        items.DoctorName,
                        items.Pkout1001,
                        items.ComingStatus,
                        items.PatientCode,
                        items.DepartmentCode,
                        items.DoctorCode,
                        items.ExamIraiStatus,
                        items.IraiDate,
                        items.ResUser,
                        items.ReserComment,
                        items.ReserType,
                        items.ClinicName
                    };
                    lstResult.Add(objects);
                }
            }

            return lstResult;
        }


        #region CreateParamList

        //Grd Boheom param list
        private List<string> GongbiParamList()
        {
            List<string> lstResult = new List<string>();
            lstResult.Add("f_bunho");

            return lstResult;
        }

        //LayReseredData
        private List<string> LayReseredDataParamList()
        {

            List<string> param = new List<string>();

            param.Add("f_gwa");
            param.Add("f_doctor");
            param.Add("f_jinryo_pre_date");
            param.Add("f_from_time");
            param.Add("o_reser_from_time");
            param.Add("o_reser_to_time");
            param.Add("f_to_time");

            return param;
        }

        //Reser
        private List<string> LayReserParamList()
        {
            List<string> param = new List<string>();
            param.Add("f_bunho");
            return param;
        }

        #endregion createParamList

        //Create key for combo in grid
        private const string CACHE_COMBOGRID_KEYS = "Nuro.Res1001U01.CmbGrid";

        private void grdOUT1001_AM_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell81.ExecuteQuery = Cmb_xEditGridCell;
        }

        #endregion

        private void xGrid1_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell85.ExecuteQuery = Cmb_xEditGridCell;
        }

        private void grdOUT1001_PM_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell82.ExecuteQuery = Cmb_xEditGridCell;
        }

        private IList<object[]> GetDataForCombo(string codeType)
        {
            IList<object[]> lstDataResult = new List<object[]>();
            ComboListByCodeTypeArgs comboListByCodeTypeArgs =
                new ComboListByCodeTypeArgs(codeType, false, mHospCodeLink, tabIsAll);
            ComboListItemResult result =
                CloudService.Instance.Submit<ComboListItemResult, ComboListByCodeTypeArgs>(
                    comboListByCodeTypeArgs);
            if (result != null)
            {
                IList<ComboListItemInfo> listItemInfos = result.ListItemInfos;
                if (listItemInfos != null)
                {
                    foreach (ComboListItemInfo comboListItemInfo in listItemInfos)
                    {
                        object[] cboItem =
                        {
                            comboListItemInfo.Code,
                            comboListItemInfo.CodeName
                        };
                        lstDataResult.Add(cboItem);
                    }
                }
            }

            return lstDataResult;
        }

        private IList<object[]> Cmb_xEditGridCell(BindVarCollection bindVarCollection)
        {
            return GetDataForCombo("RESER_GUBUN");
        }

        private void xPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dbxUserName_Click(object sender, EventArgs e)
        {

        }

        #region Grouped messages

        private RES1001U00ReservationScheduleListGroupedArgs res1001U00ReservationScheduleListGroupedArgs =
            new RES1001U00ReservationScheduleListGroupedArgs();

        private RES1001U00ReservationScheduleListGroupedResult res1001U00ReservationScheduleListGroupedResult;

        /// <summary>
        /// Grouped requests, responses from server, replacing grdRES1001_AMPM_QueryStarting callback function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdRES1001_AMPM_QueryStarting2(object sender, CancelEventArgs e)
        {
            if (!mContinueFlag)
            {
                e.Cancel = true;
                mContinueFlag = true;
                return;
            }

            XEditGrid grd = sender as XEditGrid;
            string from_time;
            string to_time;
            string cmdText = "";
            string f_from_time, f_to_time;
            string o_reser_from_time, o_reser_to_time;
            string t_am_start_hhmm, t_am_end_hhmm, t_pm_start_hhmm, t_pm_end_hhmm;
            string t_avg_time, t_limt_cnt;

            DataTable dtSchedule = new DataTable();

            dtSchedule.Columns.Add("AmStartTime", typeof(string));
            dtSchedule.Columns.Add("AmEndTime", typeof(string));
            dtSchedule.Columns.Add("PmStartTime", typeof(string));
            dtSchedule.Columns.Add("PmEndTime", typeof(string));

            DataTable dtAverageTime = new DataTable();

            dtAverageTime.Columns.Add("AvgTime", typeof(String));
            dtAverageTime.Columns.Add("DocResLimit", typeof(string));

            int count = 0;

            BindVarCollection bc = new BindVarCollection();
            // Check grid is AM or PM to assign proper binding data method.
            if (grd.Name == "grdOUT1001_AM")
            {
                from_time = AM_START_TIME.ToString().PadLeft(4, '0');
                to_time = AM_END_TIME.ToString().PadLeft(4, '0');
                grd.ExecuteQuery = GrdReservationScheduleAm;
            }
            else
            {
                from_time = PM_START_TIME.ToString().PadLeft(4, '0');
                to_time = PM_START_TIME.ToString().PadLeft(4, '0');
                grd.ExecuteQuery = GrdReservationSchedulePm;
            }

            /*************************************************************************************/
            /* 진료가 가능하지 않은 미래일자로 예약된 환자를 조회할 경우를 위해 input되는        */
            /* i_from_time과 i_to_time을 i_reser_from_time과 i_reser_to_time에 복사해 놓는다.    */
            /*************************************************************************************/
            o_reser_from_time = from_time;
            o_reser_to_time = to_time;

            // when and only when doctor code changes or exam date changes, make new request to server
            if ((fbxDoctor.Text.Trim().Length > 0) &&
                (res1001U00ReservationScheduleListGroupedArgs.DoctorCode != mDoctor ||
                 res1001U00ReservationScheduleListGroupedArgs.ExamPreDate != mCurrentDate))
            {
                res1001U00ReservationScheduleListGroupedArgs.DoctorCode = mDoctor;
                res1001U00ReservationScheduleListGroupedArgs.ExamPreDate = mCurrentDate;
                res1001U00ReservationScheduleListGroupedArgs.DepartmentCode = mGwa;

                res1001U00ReservationScheduleListGroupedArgs.HospCodeLink = this.mHospCodeLink;
                res1001U00ReservationScheduleListGroupedArgs.TabIsAll = this.tabIsAll;

                res1001U00ReservationScheduleListGroupedResult =
                    CloudService.Instance
                        .Submit
                        <RES1001U00ReservationScheduleListGroupedResult, RES1001U00ReservationScheduleListGroupedArgs>(
                            res1001U00ReservationScheduleListGroupedArgs);
            }

            if (res1001U00ReservationScheduleListGroupedResult != null)
            {
                count = res1001U00ReservationScheduleListGroupedResult.ResScheduleConditionListItem.Count;
                foreach (
                    NuroRES1001U00ReservationScheduleConditionListItemInfo items in
                        res1001U00ReservationScheduleListGroupedResult.ResScheduleConditionListItem)
                {
                    object[] objects =
                    {
                        items.AmStartTime,
                        items.AmEndTime,
                        items.PmStartTime,
                        items.PmEndTime
                    };

                    dtSchedule.Rows.Add(objects);
                }

                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_doctor", mDoctor);
                bc.Add("f_jinryo_pre_date", mCurrentDate);

                if (count < 1)
                {
                    e.Cancel = true;
                    mContinueFlag = false;
                    return;
                }

                t_am_start_hhmm = dtSchedule.Rows[0]["AmStartTime"].ToString();
                t_am_end_hhmm = dtSchedule.Rows[0]["AmEndTime"].ToString();
                t_pm_start_hhmm = dtSchedule.Rows[0]["PmStartTime"].ToString();
                t_pm_end_hhmm = dtSchedule.Rows[0]["PmEndTime"].ToString();

                /* 오전 */
                if (from_time == "0800")
                {
                    f_from_time = t_am_start_hhmm;
                    f_to_time = t_am_end_hhmm;
                }
                else
                {
                    f_from_time = t_pm_start_hhmm;
                    f_to_time = t_pm_end_hhmm;
                }

                foreach (
                    NuroRES1001U00AverageTimeListItemInfo items in
                        res1001U00ReservationScheduleListGroupedResult.AvgTimeListItem)
                {
                    object[] objects =
                    {
                        items.AvgTime,
                        items.DocResLimit
                    };

                    dtAverageTime.Rows.Add(objects);
                }

                //dt.Clear();
                bc.Clear();
                bc.Add("f_hosp_code", this.mHospCode);
                bc.Add("f_doctor", mDoctor);
                bc.Add("f_jinryo_pre_date", mCurrentDate);

                //dt = Service.ExecuteDataTable(cmdText, bc);

                t_avg_time = dtAverageTime.Rows[0]["AvgTime"].ToString();
                t_limt_cnt = dtAverageTime.Rows[0]["DocResLimit"].ToString();

                //TODO
                mLimtCnt = t_limt_cnt;

                List<string> param = new List<string>();
                param.Add("f_hosp_code");
                param.Add("f_from_time");
                param.Add("f_to_time");
                param.Add("f_gwa");
                param.Add("f_doctor");
                param.Add("f_jinryo_pre_date");
                param.Add("o_reser_from_time");
                param.Add("o_reser_to_time");
                param.Add("t_avg_time");

                grd.ParamList = param;
                //grd.ExecuteQuery = GrdReservationSchedule; 

                grd.SetBindVarValue("f_hosp_code", this.mHospCode);
                grd.SetBindVarValue("f_from_time", f_from_time);
                grd.SetBindVarValue("f_to_time", f_to_time);
                grd.SetBindVarValue("f_gwa", mGwa);
                grd.SetBindVarValue("f_doctor", mDoctor);
                grd.SetBindVarValue("f_jinryo_pre_date", mCurrentDate);
                grd.SetBindVarValue("o_reser_from_time", o_reser_from_time);
                grd.SetBindVarValue("o_reser_to_time", o_reser_to_time);
                grd.SetBindVarValue("t_avg_time", t_avg_time);

                layReseredData.SetBindVarValue("f_hosp_code", this.mHospCode);
                layReseredData.SetBindVarValue("f_from_time", f_from_time);
                layReseredData.SetBindVarValue("f_to_time", f_to_time);
                layReseredData.SetBindVarValue("f_gwa", mGwa);
                layReseredData.SetBindVarValue("f_doctor", mDoctor);
                layReseredData.SetBindVarValue("f_jinryo_pre_date", mCurrentDate);
                layReseredData.SetBindVarValue("o_reser_from_time", o_reser_from_time);
                layReseredData.SetBindVarValue("o_reser_to_time", o_reser_to_time);
                layReseredData.SetBindVarValue("t_avg_time", t_avg_time);
                this.layReseredData.QueryLayout(true);
            }

            mContinueFlag = true;
        }

        /// <summary>
        /// Return data for grdOUT1001_AM
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GrdReservationScheduleAm(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();
            if (res1001U00ReservationScheduleListGroupedResult != null)
            {
                foreach (
                    NuroRES1001U00ReservationScheduleListItemInfo items in
                        res1001U00ReservationScheduleListGroupedResult.ResScheduleAmListItem)
                {
                    object[] objects =
                    {
                        items.ExamPreTime,
                        items.PatientCode,
                        items.PatientName1,
                        items.PatientName2,
                        items.ExamStatus,
                        items.ReserDate,
                        items.Pkout1001,
                        items.ExamPreDate,
                        items.DepartmentCode,
                        items.ReceptionNo,
                        items.Type,
                        items.DoctorCode,
                        items.ResType,
                        items.ResChanggu,
                        items.ResInputType,
                        items.ComingStatus,
                        items.NewRow,
                        items.ExamState
                    };
                    data.Add(objects);
                }
            }

            return data;
        }

        /// <summary>
        /// Return data for grdOUT1001_PM
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private IList<object[]> GrdReservationSchedulePm(BindVarCollection list)
        {
            IList<object[]> data = new List<object[]>();
            if (res1001U00ReservationScheduleListGroupedResult != null)
            {
                foreach (
                    NuroRES1001U00ReservationScheduleListItemInfo items in
                        res1001U00ReservationScheduleListGroupedResult.ResSchedulePmListItem)
                {
                    object[] objects =
                    {
                        items.ExamPreTime,
                        items.PatientCode,
                        items.PatientName1,
                        items.PatientName2,
                        items.ExamStatus,
                        items.ReserDate,
                        items.Pkout1001,
                        items.ExamPreDate,
                        items.DepartmentCode,
                        items.ReceptionNo,
                        items.Type,
                        items.DoctorCode,
                        items.ResType,
                        items.ResChanggu,
                        items.ResInputType,
                        items.ComingStatus,
                        items.NewRow,
                        items.ExamState
                    };
                    data.Add(objects);
                }
            }

            return data;
        }

        #endregion

        #region Cloud updated



        #region GetListDataForSaveLayout

        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<RES1001U00SaveLayoutItemInfo> GetListDataForSaveLayout()
        {
            List<RES1001U00SaveLayoutItemInfo> lstData = new List<RES1001U00SaveLayoutItemInfo>();

            #region grdOUT1001_AM

            for (int i = 0; i < grdOUT1001_AM.RowCount; i++)
            {
                // No handle for empty bunho
                if (grdOUT1001_AM.GetItemString(i, "bunho") == "") continue;

                // Skip unchanged rows
                if (grdOUT1001_AM.GetRowState(i) == DataRowState.Unchanged) continue;

                RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                {
                    item.Bunho = this.mBunhoLink;
                }
                else
                {
                    item.Bunho = grdOUT1001_AM.GetItemString(i, "bunho");
                }
                item.Changgu = grdOUT1001_AM.GetItemString(i, "changgu");
                item.Chojae = grdOUT1001_AM.GetItemString(i, "chojae");
                item.Doctor = grdOUT1001_AM.GetItemString(i, "doctor");
                item.Gubun = grdOUT1001_AM.GetItemString(i, "gubun");
                item.Gwa = grdOUT1001_AM.GetItemString(i, "gwa");
                item.InputGubun = grdOUT1001_AM.GetItemString(i, "input_gubun");
                if (rbtLinkClinic.Checked) item.InputGubun = "O";
                item.JinryoPreDate = grdOUT1001_AM.GetItemString(i, "jinryo_pre_date");
                item.JinryoPreTime = grdOUT1001_AM.GetItemString(i, "jinryo_pre_time");
                //item.JubsuNo              = grdOUT1001_AM.GetItemString(i, "jubsu_no");
                item.Pkout1001 = grdOUT1001_AM.GetItemString(i, "pkout1001");
                item.ReserComment = grdOUT1001_AM.GetItemString(i, "reser_comment");
                item.ReserGubun = grdOUT1001_AM.GetItemString(i, "reser_gubun");
                item.ResGubun = grdOUT1001_AM.GetItemString(i, "res_gubun");
                item.Newrow = grdOUT1001_AM.GetItemString(i, "newrow");
                item.RowState = grdOUT1001_AM.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdOUT1001_AM.DeletedRowTable)
            {
                for (int i = 0; i < grdOUT1001_AM.DeletedRowTable.Rows.Count; i++)
                {
                    RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                    //item.Bunho = grdOUT1001_AM.DeletedRowTable.Rows[i]["bunho"].ToString();
                    if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                    {
                        item.Bunho = this.mBunhoLink;
                    }
                    else
                    {
                        item.Bunho = grdOUT1001_AM.DeletedRowTable.Rows[i]["bunho"].ToString();
                    }
                    item.Doctor = grdOUT1001_AM.DeletedRowTable.Rows[i]["doctor"].ToString();
                    item.Gwa = grdOUT1001_AM.DeletedRowTable.Rows[i]["gwa"].ToString();
                    item.JinryoPreDate = grdOUT1001_AM.DeletedRowTable.Rows[i]["jinryo_pre_date"].ToString();
                    item.Pkout1001 = grdOUT1001_AM.DeletedRowTable.Rows[i]["pkout1001"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            #endregion

            #region grdOUT1001_PM

            for (int i = 0; i < grdOUT1001_PM.RowCount; i++)
            {
                // No handle for empty bunho
                if (grdOUT1001_PM.GetItemString(i, "bunho") == "") continue;

                // Skip unchanged rows
                if (grdOUT1001_PM.GetRowState(i) == DataRowState.Unchanged) continue;

                RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                //item.Bunho = grdOUT1001_PM.GetItemString(i, "bunho");
                if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                {
                    item.Bunho = this.mBunhoLink;
                }
                else
                {
                    item.Bunho = grdOUT1001_PM.GetItemString(i, "bunho");
                }
                item.Changgu = grdOUT1001_PM.GetItemString(i, "changgu");
                item.Chojae = grdOUT1001_PM.GetItemString(i, "chojae");
                item.Doctor = grdOUT1001_PM.GetItemString(i, "doctor");
                item.Gubun = grdOUT1001_PM.GetItemString(i, "gubun");
                item.Gwa = grdOUT1001_PM.GetItemString(i, "gwa");
                item.InputGubun = grdOUT1001_PM.GetItemString(i, "input_gubun");
                if (rbtLinkClinic.Checked) item.InputGubun = "O";
                item.JinryoPreDate = grdOUT1001_PM.GetItemString(i, "jinryo_pre_date");
                item.JinryoPreTime = grdOUT1001_PM.GetItemString(i, "jinryo_pre_time");
                //item.JubsuNo              = grdOUT1001_PM.GetItemString(i, "jubsu_no");
                item.Pkout1001 = grdOUT1001_PM.GetItemString(i, "pkout1001");
                item.ReserComment = grdOUT1001_PM.GetItemString(i, "reser_comment");
                item.ReserGubun = grdOUT1001_PM.GetItemString(i, "reser_gubun");
                item.ResGubun = grdOUT1001_PM.GetItemString(i, "res_gubun");
                item.Newrow = grdOUT1001_PM.GetItemString(i, "newrow");
                item.RowState = grdOUT1001_PM.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdOUT1001_PM.DeletedRowTable)
            {
                for (int i = 0; i < grdOUT1001_PM.DeletedRowTable.Rows.Count; i++)
                {
                    RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                    //item.Bunho = grdOUT1001_PM.DeletedRowTable.Rows[i]["bunho"].ToString();
                    if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                    {
                        item.Bunho = this.mBunhoLink;
                    }
                    else
                    {
                        item.Bunho = grdOUT1001_PM.DeletedRowTable.Rows[i]["bunho"].ToString();
                    }
                    item.Doctor = grdOUT1001_PM.DeletedRowTable.Rows[i]["doctor"].ToString();
                    item.Gwa = grdOUT1001_PM.DeletedRowTable.Rows[i]["gwa"].ToString();
                    item.JinryoPreDate = grdOUT1001_PM.DeletedRowTable.Rows[i]["jinryo_pre_date"].ToString();
                    item.Pkout1001 = grdOUT1001_PM.DeletedRowTable.Rows[i]["pkout1001"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            #endregion

            #region grdDeleteOUT1001

            for (int i = 0; i < grdDeleteOUT1001.RowCount; i++)
            {
                // No handle for empty bunho
                if (grdDeleteOUT1001.GetItemString(i, "bunho") == "") continue;

                // Skip unchanged rows
                if (grdDeleteOUT1001.GetRowState(i) == DataRowState.Unchanged) continue;

                RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                //item.Bunho = grdDeleteOUT1001.GetItemString(i, "bunho");
                if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                {
                    item.Bunho = this.mBunhoLink;
                }
                else
                {
                    item.Bunho = grdDeleteOUT1001.GetItemString(i, "bunho");
                }
                //item.Changgu                = grdDeleteOUT1001.GetItemString(i, "changgu");
                //item.Chojae                 = grdDeleteOUT1001.GetItemString(i, "chojae");
                item.Doctor = grdDeleteOUT1001.GetItemString(i, "doctor");
                //item.Gubun                  = grdDeleteOUT1001.GetItemString(i, "gubun");
                item.Gwa = grdDeleteOUT1001.GetItemString(i, "gwa");
                //item.InputGubun             = grdDeleteOUT1001.GetItemString(i, "input_gubun");
                item.JinryoPreDate = grdDeleteOUT1001.GetItemString(i, "jinryo_pre_date");
                item.JinryoPreTime = grdDeleteOUT1001.GetItemString(i, "jinryo_pre_time");
                //item.JubsuNo              = grdDeleteOUT1001.GetItemString(i, "jubsu_no");
                item.Pkout1001 = grdDeleteOUT1001.GetItemString(i, "pkout1001");
                item.ReserComment = grdDeleteOUT1001.GetItemString(i, "reser_comment");
                item.ReserGubun = grdDeleteOUT1001.GetItemString(i, "reser_gubun");
                //item.ResGubun               = grdDeleteOUT1001.GetItemString(i, "res_gubun");
                //item.Newrow                 = grdDeleteOUT1001.GetItemString(i, "newrow");
                item.RowState = grdDeleteOUT1001.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdDeleteOUT1001.DeletedRowTable)
            {
                for (int i = 0; i < grdDeleteOUT1001.DeletedRowTable.Rows.Count; i++)
                {
                    RES1001U00SaveLayoutItemInfo item = new RES1001U00SaveLayoutItemInfo();
                    //item.Bunho = grdDeleteOUT1001.DeletedRowTable.Rows[i]["bunho"].ToString();
                    if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                    {
                        item.Bunho = this.mBunhoLink;
                    }
                    else
                    {
                        item.Bunho = grdDeleteOUT1001.DeletedRowTable.Rows[i]["bunho"].ToString();
                    }
                    item.Doctor = grdDeleteOUT1001.DeletedRowTable.Rows[i]["doctor"].ToString();
                    item.Gwa = grdDeleteOUT1001.DeletedRowTable.Rows[i]["gwa"].ToString();
                    item.JinryoPreDate = grdDeleteOUT1001.DeletedRowTable.Rows[i]["jinryo_pre_date"].ToString();
                    item.Pkout1001 = grdDeleteOUT1001.DeletedRowTable.Rows[i]["pkout1001"].ToString();
                    item.JinryoPreTime = grdDeleteOUT1001.DeletedRowTable.Rows[i]["jinryo_pre_time"].ToString();

                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            #endregion

            return lstData;
        }

        #endregion

        #endregion

        #region Orca

        //public void OrcaHelper(string patientId, string wholeName, string wholeNameInKana, string appointmentDate, string appointmentTime, string appointmentId,
        //                       string departmentCode, string physicianCode, string medicalInformation, string appointmentInformation, string appointmentNote)
        //{
        //    string HOST = EnvironInfo.ORCAserverInfo.Host;
        //    string PORT = EnvironInfo.ORCAserverInfo.BookingPort;
        //    string USER = EnvironInfo.ORCAserverInfo.User;
        //    string PASSWD = EnvironInfo.ORCAserverInfo.Password;
        //    string CONTENT_TYPE = EnvironInfo.ORCAserverInfo.ContentType;
        //    string STRINGURL = EnvironInfo.ORCAserverInfo.BookingUrl;
        //    string URL = "http://" + HOST + ":" + PORT + STRINGURL + appointmentInformation;

        //    XmlDocument xml = new XmlDocument();
        //    XmlElement data = xml.CreateElement("data");
        //    xml.AppendChild(data);
        //    XmlElement appointreq = xml.CreateElement("appointreq");
        //    appointreq.SetAttribute("type", "record");
        //    data.AppendChild(appointreq);

        //    XmlElement Patient_ID = xml.CreateElement("Patient_ID");
        //    Patient_ID.SetAttribute("type", "string");
        //    Patient_ID.InnerText = patientId;
        //    appointreq.AppendChild(Patient_ID);

        //    XmlElement WholeName = xml.CreateElement("WholeName");
        //    WholeName.SetAttribute("type", "string");
        //    WholeName.InnerText = wholeName;
        //    appointreq.AppendChild(WholeName);

        //    XmlElement WholeName_inKana = xml.CreateElement("WholeName_inKana");
        //    WholeName_inKana.SetAttribute("type", "string");
        //    WholeName_inKana.InnerText = wholeNameInKana;
        //    appointreq.AppendChild(WholeName_inKana);

        //    XmlElement Appointment_Date = xml.CreateElement("Appointment_Date");
        //    Appointment_Date.SetAttribute("type", "string");
        //    Appointment_Date.InnerText = appointmentDate;
        //    appointreq.AppendChild(Appointment_Date);

        //    XmlElement Appointment_Time = xml.CreateElement("Appointment_Time");
        //    Appointment_Time.SetAttribute("type", "string");
        //    Appointment_Time.InnerText = appointmentTime;
        //    appointreq.AppendChild(Appointment_Time);

        //    XmlElement Appointment_Id = xml.CreateElement("Appointment_Id");
        //    Appointment_Id.SetAttribute("type", "string");
        //    Appointment_Id.InnerText = appointmentId;
        //    appointreq.AppendChild(Appointment_Id);

        //    XmlElement Department_Code = xml.CreateElement("Department_Code");
        //    Department_Code.SetAttribute("type", "string");
        //    Department_Code.InnerText = departmentCode;
        //    appointreq.AppendChild(Department_Code);

        //    XmlElement Physician_Code = xml.CreateElement("Physician_Code");
        //    Physician_Code.SetAttribute("type", "string");
        //    Physician_Code.InnerText = physicianCode;
        //    appointreq.AppendChild(Physician_Code);

        //    XmlElement Medical_Information = xml.CreateElement("Medical_Information");
        //    Medical_Information.SetAttribute("type", "string");
        //    Medical_Information.InnerText = medicalInformation;
        //    appointreq.AppendChild(Medical_Information);

        //    XmlElement Appointment_Information = xml.CreateElement("Appointment_Information");
        //    Appointment_Information.SetAttribute("type", "string");
        //    Appointment_Information.InnerText = appointmentInformation;
        //    appointreq.AppendChild(Appointment_Information);

        //    XmlElement Appointment_Note = xml.CreateElement("Appointment_Note");
        //    Appointment_Note.SetAttribute("type", "string");
        //    Appointment_Note.InnerText = appointmentNote;
        //    appointreq.AppendChild(Appointment_Note);

        //    string BODY = xml.OuterXml;

        //    byte[] record_in_byte = Encoding.UTF8.GetBytes(BODY);

        //    HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(URL);

        //    req.Method = "POST";
        //    req.ContentType = CONTENT_TYPE;
        //    req.ContentLength = record_in_byte.Length;
        //    req.Credentials = new NetworkCredential(USER, PASSWD);

        //    HttpWebResponse res = null;
        //    try
        //    {
        //        Stream reqstream = req.GetRequestStream();

        //        reqstream.Write(record_in_byte, 0, record_in_byte.Length);
        //        reqstream.Close();

        //        res = (HttpWebResponse)req.GetResponse();

        //        //Console.WriteLine(res.ResponseUri);
        //        //Console.WriteLine(res.StatusDescription);
        //    }
        //    catch (WebException exc)
        //    {
        //        if (exc.Status == WebExceptionStatus.ProtocolError)
        //        {
        //            HttpWebResponse err = (HttpWebResponse)exc.Response;

        //            int errcode = (int)err.StatusCode;

        //            //Console.WriteLine(err.ResponseUri);
        //            XMessageBox.Show("{0}:{1}" + errcode + err.StatusDescription);

        //            err.Close();
        //        }
        //        else
        //        {
        //            Console.WriteLine(exc.Message);
        //        }
        //    }

        //    if (res != null)
        //    {
        //        Stream str = res.GetResponseStream();
        //        StreamReader strread = new StreamReader(str, new UTF8Encoding());

        //        string FOO = strread.ReadToEnd();
        //        string FILE_NAME = "foo.xml";
        //        File.WriteAllText(FILE_NAME, FOO);

        //        //Convert string resp to XML get value by tag name
        //        XmlDocument respXmlDocument = new XmlDocument();
        //        respXmlDocument.LoadXml(FOO);
        //        XmlElement root = respXmlDocument.DocumentElement;
        //        XmlNode nodeSelectName = root.SelectSingleNode("/xmlio2/appointres/Api_Result_Message");
        //        XmlNode nodeSelectCode = root.SelectSingleNode("/xmlio2/appointres/Api_Result");
        //        string outValueCode = nodeSelectCode.InnerText;
        //        string outValueName = nodeSelectName.InnerText;
        //        //show message 
        //        XMessageBox.Show(outValueCode + " - " + outValueName);
        //        strread.Close();
        //        str.Close();

        //        res.Close();
        //    }
        //}



        #endregion

        #region Drag Drop Orca
        private bool CheckDragDropOrca(string fromTime, string toTime)
        {
            //Sync Orca
            if (!LoadMappingCode())
            {
                XMessageBox.Show(Resources.MSG023_MSG, Resources.MSG022_CAP, MessageBoxIcon.Error);
                return false;
            }

            string doctorCode = mDoctor.Remove(0, 2);
            string msgOutputDel = "";
            string msgOutputIns = "";
            try
            {
                //Delete Orca
                BookingInfo bkIns = new BookingInfo(mBunho, paBox.SuName, paBox.SuName2, this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), toTime, "", mGwaMap, mDoctorMap, "", "01", "");
                //Insert Orca
                BookingInfo bkDel = new BookingInfo(mBunho, paBox.SuName, paBox.SuName2, this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), fromTime, "", mGwaMap, mDoctorMap, "", "02", "");

                if (rbtLinkClinic.Checked && this.mBunhoLink != "")
                {
                    //Delete Orca
                    bkIns = new BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2, this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), toTime, "", mGwaMap, mDoctorMap, "", "01", "");
                    //Insert Orca
                    bkDel = new BookingInfo(mBunhoLink, paBox.SuName, paBox.SuName2, this.calSchedule.SelectedDays[0].Date.ToString("yyyy-MM-dd"), fromTime, "", mGwaMap, mDoctorMap, "", "02", "");
                }

                ORCA.ORCAServices sentBkDel = new ORCA.ORCAServices(bkDel);
                ORCA.ORCAServices sentBkIns = new ORCA.ORCAServices(bkIns);

                //sentBkDel.SentBooking(out msgOutputDel);
                RES1001U00CheckUsingOrcaArgs args = new RES1001U00CheckUsingOrcaArgs();
                RES1001U00CheckUsingOrcaResult result = new RES1001U00CheckUsingOrcaResult();
                if (rbtMyClinic.Checked)
                {
                    args.HospCodeLink = UserInfo.HospCode;
                    result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                    {
                        sentBkDel.SentBooking(out msgOutputDel);
                        sentBkIns.SentBooking(out msgOutputIns);
                    }
                }
                else if (rbtLinkClinic.Checked)
                {
                    args.HospCodeLink = this.mHospCodeLink;
                    result = CloudService.Instance.Submit<RES1001U00CheckUsingOrcaResult, RES1001U00CheckUsingOrcaArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.AccType == "00")
                    {
                        sentBkDel.SentBooking(out msgOutputDel, result.OrcaIp, result.OrcaUser, result.OrcaPassword);
                        sentBkIns.SentBooking(out msgOutputIns, result.OrcaIp, result.OrcaUser, result.OrcaPassword);

                    }
                }

                //if (msgOutputDel.Substring(0, 2) != "00")
                //{
                //    XMessageBox.Show(msgOutputDel);
                //    return false;
                //}
                //else
                //{
                //ORCA.ORCAServices sentBkIns = new ORCA.ORCAServices(bkIns);
                //sentBkIns.SentBooking(out msgOutputIns);
                //if (msgOutputDel.Substring(0, 2) != "00")
                //{
                //    XMessageBox.Show(msgOutputIns);
                //    return false;
                //}
                //}
            }
            catch
            {
                XMessageBox.Show(Resources.MSG021_MSG, Resources.MSG021_CAP, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        private void rbtMyClinic_CheckedChanged(object sender, EventArgs e)
        {
            #region Visible changed
            if (rbtMyClinic.Checked)
            {
                rbtMyClinic.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtMyClinic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtMyClinic.ImageIndex = 15;

                rbtLinkClinic.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtLinkClinic.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtLinkClinic.ImageIndex = 14;


                xLabel4.Visible = false;
                fbxLinkHospCode.Visible = false;
                dbxLinkHospName.Visible = false;

                //this.xGrid1.Enabled = true;
                //this.grdOUT1001_AM.Enabled = true;
                //this.grdOUT1001_PM.Enabled = true;
                this.btnNUR1001R09.Enabled = false;

            #endregion

                this.mHospCodeLink = "";
                //using mBunho to switch bunho between 2 tabs
                this.mBunho = paBox.BunHo;
                calSchedule.Dates.Clear();
                calSchedule.Refresh();
                //this.tabIsAll = false;
                btnClear.PerformClick();
                xButtonList1.PerformClick(FunctionType.Query);
            }
        }

        private void rbtLinkClinic_CheckedChanged(object sender, EventArgs e)
        {
            #region Visible changed
            if (rbtLinkClinic.Checked)
            {
                rbtLinkClinic.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtLinkClinic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtLinkClinic.ImageIndex = 15;

                rbtMyClinic.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtMyClinic.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtMyClinic.ImageIndex = 14;

                xLabel4.Visible = true;
                fbxLinkHospCode.Visible = true;
                dbxLinkHospName.Visible = true;

                //this.xGrid1.Enabled = false;
                //this.grdOUT1001_AM.Enabled = true;
                //this.grdOUT1001_PM.Enabled = true;
                this.btnNUR1001R09.Enabled = true;


            #endregion

                this.fbxLinkHospCode.Clear();
                this.dbxLinkHospName.Text = "";
                this.mHospCodeLink = "";
                calSchedule.Dates.Clear();
                calSchedule.Refresh();
                //this.mHospCodeLink = (String.IsNullOrEmpty(fbxLinkHospCode.GetDataValue())) ? "" : fbxLinkHospCode.GetDataValue();
                btnClear.PerformClick();
                //this.tabIsAll = false;
                xButtonList1.PerformClick(FunctionType.Query);
            }
        }


        #region Printing booking info
        private void PrintBookingTicket(string bunho, string gwa, string naewon_date, string jubsu_time)
        {
            try
            {
                #region MyRegion
                RES1001R00PrintBookingArgs args = new RES1001R00PrintBookingArgs();
                args.Bunho = bunho;
                args.Gwa = gwa;
                args.Doctor = fbxDoctor.GetDataValue().ToString();
                args.HospCode = UserInfo.HospCode;
                args.HospCodeLink = fbxLinkHospCode.GetDataValue().ToString();
                args.NaewonDate = naewon_date;
                args.JubsuTime = jubsu_time;
                RES1001R00PrintBookingResult result = CloudService.Instance.Submit<RES1001R00PrintBookingResult, RES1001R00PrintBookingArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    DataTable dtBooking = new DataTable();
                    dtBooking.Columns.Add("yoyang_name_link");
                    dtBooking.Columns.Add("suname");
                    dtBooking.Columns.Add("birth_day");
                    dtBooking.Columns.Add("birth_month");
                    dtBooking.Columns.Add("birth_year");
                    dtBooking.Columns.Add("age");
                    dtBooking.Columns.Add("yoyang_name");
                    dtBooking.Columns.Add("bunho");
                    dtBooking.Columns.Add("bunho_link");
                    dtBooking.Columns.Add("gwa_name");
                    dtBooking.Columns.Add("doctor_name");
                    dtBooking.Columns.Add("naewon_day");
                    dtBooking.Columns.Add("naewon_month");
                    dtBooking.Columns.Add("naewon_year");
                    dtBooking.Columns.Add("jubsu_hour");
                    dtBooking.Columns.Add("jubsu_min");
                    dtBooking.Columns.Add("address");
                    dtBooking.Columns.Add("tel");

                    DataRow row = dtBooking.NewRow();
                    row["yoyang_name_link"] = result.YoyangNameLink;
                    row["suname"] = result.Suname;

                    String fullBirth = result.Birth;
                    if (fullBirth != "")
                    {
                        String[] BirthArray = fullBirth.Split('/');
                        row["birth_year"] = BirthArray[0];
                        row["birth_month"] = BirthArray[1];
                        row["birth_day"] = BirthArray[2];
                    }

                    row["age"] = result.Age;
                    row["yoyang_name"] = result.YoyangName;
                    row["bunho"] = result.Bunho;
                    row["bunho_link"] = result.BunhoLink;
                    row["gwa_name"] = result.GwaName;
                    row["doctor_name"] = result.DoctorName;

                    String fullNaewonDate = result.NaewonDate;
                    if (fullNaewonDate != "")
                    {
                        String[] NaewonArray = fullNaewonDate.Split('/');
                        row["naewon_year"] = NaewonArray[0];
                        row["naewon_month"] = NaewonArray[1];
                        row["naewon_day"] = NaewonArray[2];
                    }

                    String jubsuTime = result.JubsuTime;
                    if (jubsuTime != "")
                    {
                        row["jubsu_hour"] = jubsuTime.Substring(0, 2);
                        row["jubsu_min"] = jubsuTime.Substring(2, 2);
                    }

                    row["address"] = result.Address;
                    row["tel"] = result.Tel;

                    dtBooking.Rows.Add(row);

                    //DataSet ds = new DataSet();
                    //ds.Tables.Add(dtBooking);
                    XtraReport1 report = new XtraReport1(result.BunhoLink);
                    report.DataSource = dtBooking;
                    report.Print();
                }
                #endregion

                #region testing
                //test
                //DataTable dtBooking = new DataTable();
                //dtBooking.Columns.Add("yoyang_name_link");
                //dtBooking.Columns.Add("suname");
                //dtBooking.Columns.Add("birth_day");
                //dtBooking.Columns.Add("birth_month");
                //dtBooking.Columns.Add("birth_year");
                //dtBooking.Columns.Add("age");
                //dtBooking.Columns.Add("yoyang_name");
                //dtBooking.Columns.Add("bunho");
                //dtBooking.Columns.Add("bunho_link");
                //dtBooking.Columns.Add("gwa_name");
                //dtBooking.Columns.Add("doctor_name");
                //dtBooking.Columns.Add("naewon_day");
                //dtBooking.Columns.Add("naewon_month");
                //dtBooking.Columns.Add("naewon_year");
                //dtBooking.Columns.Add("jubsu_hour");
                //dtBooking.Columns.Add("jubsu_min");

                //DataRow row = dtBooking.NewRow();
                //row["yoyang_name_link"] = "BV Van Dien";
                //row["suname"] = "Tung tran";
                //row["birth_day"] = "21";
                //row["birth_month"] = "05";
                //row["birth_year"] = "1993";
                //row["age"] = "23";
                //row["yoyang_name"] = "BV Bach mai";
                //row["bunho"] = "210593";
                //row["bunho_link"] = "19932105";
                //row["gwa_name"] = "khoa mat";
                //row["doctor_name"] = "bac si Thao";
                //row["naewon_day"] = "21";
                //row["naewon_month"] = "02";
                //row["naewon_year"] = "2016";
                //row["jubsu_hour"] = "01";
                //row["jubsu_min"] = "33";

                //dtBooking.Rows.Add(row);

                ////DataSet ds = new DataSet();
                ////ds.Tables.Add(dtBooking);
                //XtraReport1 report = new XtraReport1("000000100");
                //report.DataSource = dtBooking;
                //report.Print(); 
                #endregion

            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.MSG022_CAP, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void fbxLinkHospCode_FindClick(object sender, CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;
        }

        private void fbxLinkHospCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            RES1001U00FbxHospCodeLinkDataValidatingArgs args = new RES1001U00FbxHospCodeLinkDataValidatingArgs();
            args.HospCode = e.DataValue;
            args.Bunho = this.paBox.BunHo;
            RES1001U00FbxHospCodeLinkDataValidatingResult result = CloudService.Instance.Submit<RES1001U00FbxHospCodeLinkDataValidatingResult, RES1001U00FbxHospCodeLinkDataValidatingArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && result.HospName != "")
            {
                this.dbxLinkHospName.SetDataValue(result.HospName);
                this.mHospCodeLink = e.DataValue;
                this.mBunhoLink = result.BunhoLink;
                //using mBunho to switch bunho between 2 tabs
                this.mBunho = this.mBunhoLink;
                CreateCombo();
                xButtonList1.PerformClick(FunctionType.Query);
            }
            else
            {
                this.dbxLinkHospName.SetDataValue("");
                this.mHospCodeLink = "";
            }
            this.btnClear.PerformClick();
        }

        private void grd_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Active = false;
            curPreRowIndex = -1;
            curPreX = -1;
        }

        private void LoadBookingClinicRefer()
        {
            if (rbtMyClinic.Checked)
            {
                RES1001U01BookingClinicReferArgs args = new RES1001U01BookingClinicReferArgs();
                args.Doctor = mDoctor;//"01K01OCS";//
                args.Gwa = mGwa;//"01";//
                args.NaewonDate = mCurrentDate;//"2015/11/18"; //

                RES1001U01BookingClinicReferResult res = CloudService.Instance.Submit<RES1001U01BookingClinicReferResult, RES1001U01BookingClinicReferArgs>(args);
                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    bookingRefer = res;
                }
            }
        }

        private string GetToolTipText(string patientId, string reserTime, out bool hasReser)
        {
            hasReser = false;
            foreach (RES1001U01BookingClinicReferInfo item in bookingRefer.Lst)
            {
                if (item.BookingTime == reserTime && item.PatientId == patientId)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(string.Format("{0}", Resources.RES1001U00_GetToolTipText_2));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_3, item.PatientId));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_4, item.PatientName));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_5, item.Birthday));
                    sb.AppendLine(string.Format("\t{0}\t\t:\t{1}", Resources.RES1001U00_GetToolTipText_6, item.Sex == "M"
                            ? Resources.RES1001U00_GetToolTipText_Male
                            : Resources.RES1001U00_GetToolTipText_Female));
                    if (UserInfo.HospCode != item.BookingClinicId.Trim())
                    {
                        sb.AppendLine(string.Format("{0}", Resources.RES1001U00_GetToolTipText_7));
                    }
                    else
                    {
                        sb.AppendLine(string.Format("{0}", Resources.RES1001U00_GetToolTipText_15));
                    }
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_8, item.BookingClinicId));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_9, item.BookingClinicName));
                    sb.AppendLine(string.Format("\t{0}\t\t:\t{1}", Resources.RES1001U00_GetToolTipText_12, item.Tel));
                    string createdBookingDate = string.Format(Resources.RES1001U00_GetToolTipText_1,
                        item.BookingDate.Substring(0, 4), item.BookingDate.Substring(5, 2),
                        item.BookingDate.Substring(8, 2), item.BookingTime.Substring(0, 2),
                        item.BookingTime.Substring(2, 2));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_13, createdBookingDate));
                    sb.AppendLine(string.Format("\t{0}\t:\t{1}", Resources.RES1001U00_GetToolTipText_14, string.IsNullOrEmpty(item.LinkEmrInformation)
                            ? Resources.RES1001U00_GetToolTipText_10
                            : Resources.RES1001U00_GetToolTipText_11));

                    hasReser = true;
                    return sb.ToString();

                }
            }

            return null;
        }

        private void xGrid1_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (xGrid1.GetItemString(xGrid1.CurrentRowNumber, "clinic_name") != UserInfo.HospName)
            {
                this.btnNUR1001R09.Enabled = false;
            }
            else
            {
                this.btnNUR1001R09.Enabled = true;
            }
        }

        private void rbtLinkClinic_MouseDown(object sender, MouseEventArgs e)
        {
            //validating
            if (String.IsNullOrEmpty(this.paBox.BunHo))
            {
                XMessageBox.Show(Resources.MSG024_MSG, Resources.MSG004_CAP, MessageBoxIcon.Warning);
                rbtMyClinic.Checked = true;
                paBox.Focus();
                return;
            }
        }       
    }
}

