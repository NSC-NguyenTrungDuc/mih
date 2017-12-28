using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCSO.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using EmrDocker.Models;
using EmrDocker.Types;
using EmrDocker.Glossary;
using IHIS.CloudConnector.Contracts.Models.Outs;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Arguments.Nuri;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using MedicalInterfaceTest;

namespace IHIS.OCSO
{
    /// <summary>
    /// OCSACT2에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class OCSACT2 : IHIS.Framework.XScreen
    {
        #region Fields
        // 服薬指導せんのグロバール変数
        private string i_pkocs = null;
        private string i_order_date = null;
        private string i_bunho = null;
        private string i_fkout1001 = null;

        private MultiLayout mLayInputTime = null;             // 시간,분 입력을 담는 Layout
        private IHIS.OCS.HangmogInfo mHangmogInfo = null;

        // 自動照会使用可否フラグ
        private string useTimeChkYN = "";
        private int QueryTime;
        private int TimeVal;

        // 患者有AlarmファイルPATH
        private string alarmFilePath_PFE = "";
        private string alarmFilePath_PFE_EM = "";
        private string useAlarmChkYN = "";

        private string newOcsKey = "";
        string jundalTb = "";

        private string bunho_first = "";

        // Updated by Cloud
        private string jundalTable = "";
        private OCSACTCboSystemSelectedIndexChangedResult _cboRes;
        private OCSACTGrdRowFocusChangedResult _grdRes;
        private DateTime mSysDate;
        private OCSACTCboTimeAndSystemResult mCboSysTime;
        private bool isFirstLoad = true;
        private OCSACTGroupedPatientAndOrderResult mGroupedResult;
        private UCBtnList ucBtn;
        private List<EmrDocker.Models.TagInfo> lstTagInfos = new List<EmrDocker.Models.TagInfo>();
        private List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();
        private List<OUT0106U00GridItemInfo> listSpecialNode = new List<OUT0106U00GridItemInfo>();
        
        #endregion

        #region Constructor
        /// <summary>
        /// OCSACT2
        /// </summary>
        public OCSACT2()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //hoangvv
            mSysDate = EnvironInfo.GetSysDate();
            LoadCompositeInitialize();
            LoadCompositeSecondInitialize();

            // updated by Cloud
            InitializeCloud();

            //TODO disable IN Hospital Tab MED-5790
            rbxInp.Visible = false;

            this.ApplyMultiResolution();
        }

        private void LoadCompositeInitialize()
        {
           
            OCSACT2CompositeArgs compositeArgs = new OCSACT2CompositeArgs();
            //init default param for ...OCSACTCboTimeAndSystemArgs
            OCSACTCboTimeAndSystemArgs cboSystemArgs = new OCSACTCboTimeAndSystemArgs();
            compositeArgs.CboTimeAndSys = cboSystemArgs;
            //init default param for OCSACT2GetComboUserArgs
            OCSACT2GetComboUserArgs cboUser = new OCSACT2GetComboUserArgs();
            cboUser.HospCode = UserInfo.HospCode;
            cboUser.JundalTable = "%";
            compositeArgs.CboUser = cboUser;
            //init default param for ...OCSACT2GetGrdPaListArgs
            OCSACT2GetGrdPaListArgs grdPaListArgs = new OCSACT2GetGrdPaListArgs();
            grdPaListArgs.ActingFlg = "1";
            grdPaListArgs.Bunho = "";
            grdPaListArgs.Gwa = "";
            grdPaListArgs.HospCode = UserInfo.HospCode;
            grdPaListArgs.JundalTable = "%";
            grdPaListArgs.OrderDateFrom = mSysDate.ToString("yyyy/MM/dd");
            grdPaListArgs.OrderDateTo = mSysDate.ToString("yyyy/MM/dd");
            compositeArgs.GrdPaList = grdPaListArgs;
            //init default param for ...OCSACTCboSystemSelectedIndexChangedArgs
            OCSACTCboSystemSelectedIndexChangedArgs systemSelected = new OCSACTCboSystemSelectedIndexChangedArgs();
            systemSelected.CodeType = "";
            systemSelected.SystemId = "%";
            systemSelected.HoDong = "";
            compositeArgs.CboSelectedIndexChange = systemSelected;
            //init default param for ...OCSACTLayconstantConstArgs
            OCSACTLayconstantConstArgs layConst = new OCSACTLayconstantConstArgs();
            compositeArgs.LayConstantCons = layConst;
            //init default param for ...OCSACTLayconstantAlarmArgs
            OCSACTLayconstantAlarmArgs layAlarm = new OCSACTLayconstantAlarmArgs();
            compositeArgs.LayConstantAlarm = layAlarm;

            OCSACT2CompositeResult compositeResult = CloudService.Instance.Submit<OCSACT2CompositeResult, OCSACT2CompositeArgs>(compositeArgs, true, CallbackOCSACT2Composite);

            if (compositeResult.ExecutionStatus == ExecutionStatus.Success && compositeResult.GrdPaListRes != null
                && compositeResult.GrdPaListRes.PaItem.Count > 0)
            {
                bunho_first = compositeResult.GrdPaListRes.PaItem[0].Bunho;
            }
        }
        private void LoadCompositeSecondInitialize() {
            OCSACT2CompositeSecondArgs compositeSecondArgs = new OCSACT2CompositeSecondArgs();

            //init default param for ...OCS2015U00GetPatientInfoRequest
            OCS2015U00GetPatientInfoArgs getPatientInfo = new OCS2015U00GetPatientInfoArgs();
            getPatientInfo.Bunho = bunho_first;
            compositeSecondArgs.GetPatientInfo = getPatientInfo;

            //init default param for ...NUR1016U00GrdNUR1016Request
            NUR1016U00GrdNUR1016Args grdNur1016 = new NUR1016U00GrdNUR1016Args();
            grdNur1016.Bunho = bunho_first;
            compositeSecondArgs.GrdNur1016 = grdNur1016;

            //init default param for ...NUR1017U00GrdNUR1017Request
            NUR1017U00GrdNUR1017Args grdNur1017 = new NUR1017U00GrdNUR1017Args();
            grdNur1017.Bunho = bunho_first;
            compositeSecondArgs.GrdNur1017 = grdNur1017;

            //init default param for ...OUT0106U00GridListRequest
            OUT0106U00GridListArgs grdOut0106U00 = new OUT0106U00GridListArgs();
            grdOut0106U00.Bunho = bunho_first;
            grdOut0106U00.NaewonDate = mSysDate.ToString();
            compositeSecondArgs.GrdListOut0106u00 = grdOut0106U00;

            //init default param for ...GetPatientByCodeRequest
            GetPatientByCodeArgs getPatientByCode = new GetPatientByCodeArgs();
            getPatientByCode.HospCode = "";
            getPatientByCode.PatientCode = bunho_first;
            compositeSecondArgs.GetPatientBycode = getPatientByCode;

            //init default param for ...OcsLoadInputAndVisibleControlRequest
            OcsLoadInputAndVisibleControlArgs inputVisible = new OcsLoadInputAndVisibleControlArgs();
            inputVisible.InputControl = "%";
            inputVisible.InputTab = "%";
            compositeSecondArgs.InputVisible = inputVisible;

            //init default param for ...OcsLoadInputTabRequest
            OcsLoadInputTabArgs inputTab = new OcsLoadInputTabArgs();
            inputTab.InputTab = "%";
            compositeSecondArgs.InputTab = inputTab;

            ////init default param for ...InjsINJ1001U01DetailListRequest
            InjsINJ1001U01DetailListArgs detail_list = new InjsINJ1001U01DetailListArgs();
            detail_list.ActingDate = "";
            detail_list.ActingFlag = "";
            detail_list.Bunho = bunho_first;
            detail_list.Doctor = UserInfo.DoctorID;
            detail_list.Gwa = UserInfo.Gwa;
            detail_list.ReserDate = mSysDate.ToString();
            compositeSecondArgs.DetailList = detail_list;

            //init default param for ...CPL2010U00CheckInjCplOrderRequest
            CPL2010U00CheckInjCplOrderArgs check_inj = new CPL2010U00CheckInjCplOrderArgs();
            check_inj.Bunho = bunho_first;
            check_inj.IoGubun = "O";
            check_inj.OrderDate = mSysDate.ToString("yyyy/MM/dd");
            compositeSecondArgs.CheckInj = check_inj;
            //====================

            OCSACT2CompositeSecondResult compositeSecondResult = CloudService.Instance.Submit<OCSACT2CompositeSecondResult, OCSACT2CompositeSecondArgs>(compositeSecondArgs, true, CallbackOCSACT2SecondComposite);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackOCSACT2Composite(OCSACT2CompositeArgs args, OCSACT2CompositeResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.CboTimeAndSys, new KeyValuePair<int, object>(1, result.CboTimeAndSysRes));
            cacheSession.Add(args.CboUser, new KeyValuePair<int, object>(1, result.CboUserRes));
            cacheSession.Add(args.GrdPaList, new KeyValuePair<int, object>(1, result.GrdPaListRes));
            cacheSession.Add(args.CboSelectedIndexChange, new KeyValuePair<int, object>(1, result.CboSelectedIndexChangeRes));
            cacheSession.Add(args.LayConstantCons, new KeyValuePair<int, object>(1, result.LayConstantConsRes));
            cacheSession.Add(args.LayConstantAlarm, new KeyValuePair<int, object>(1, result.LayConstantRes));

            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        }
        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackOCSACT2SecondComposite(OCSACT2CompositeSecondArgs args, OCSACT2CompositeSecondResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.GetPatientInfo, new KeyValuePair<int, object>(1, result.GetPatientInfoRes));
            cacheSession.Add(args.GrdNur1016, new KeyValuePair<int, object>(1, result.GrdNur1016Res));
            cacheSession.Add(args.GrdNur1017, new KeyValuePair<int, object>(1, result.GrdNur1017Res));
            cacheSession.Add(args.GrdListOut0106u00, new KeyValuePair<int, object>(1, result.GrdListOut0106u00Res));
            cacheSession.Add(args.GetPatientBycode, new KeyValuePair<int, object>(1, result.GetPatientBycodeRes));
            cacheSession.Add(args.InputVisible, new KeyValuePair<int, object>(1, result.InputVisibleRes));
            cacheSession.Add(args.InputTab, new KeyValuePair<int, object>(1, result.InputTabRes));
            cacheSession.Add(args.DetailList, new KeyValuePair<int, object>(1, result.DetailListRes));
            cacheSession.Add(args.CheckInj, new KeyValuePair<int, object>(1, result.CheckInjRes));

            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        }

        #endregion

        #region Events

        private void OCSACT_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            InitSimpleLayout();

            this.mLayInputTime = new MultiLayout();
            this.mLayInputTime.LayoutItems.Add("hangmog_code", DataType.String, false, true);
            this.mLayInputTime.LayoutItems.Add("hangmog_name", DataType.String, false, true);
            this.mLayInputTime.LayoutItems.Add("minute_suryang", DataType.Number, false, true);
            this.mLayInputTime.LayoutItems.Add("hour", DataType.Number, false, true);
            this.mLayInputTime.LayoutItems.Add("minute", DataType.Number, false, true);

            this.mLayInputTime.InitializeLayoutTable();

            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.Name);
            this.dtpFromDate.SetDataValue(mSysDate);
            this.dtpToDate.SetDataValue(mSysDate);

            //if (this.OpenParam == null)
            //{
            //    //초기 화면 오픈시 시스템 설정
            //    switch (EnvironInfo.CurrSystemID)
            //    {
            //        case "PFES":
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_02");
            //            this.cboPart.SetEditValue("%");
            //            break;

            //        case "NUTS":
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_06");
            //            this.cboPart.SetEditValue("%");
            //            this.grdOrder.AutoSizeColumn(6, 0);
            //            this.grdOrder.AutoSizeColumn(5, 0);
            //            break;

            //        case "CPLS":
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_02");
            //            this.cboPart.SetEditValue("%");
            //            this.cbxEkgIFYN.Visible = true;
            //            this.btnIfEkg.Visible = true;
            //            // 2015.07.29 AnhNV updated START
            //            //this.btnRequest.Visible = false;
            //            //this.btnJaeryo.Location = new Point(239, 4);
            //            // 2015.07.29 AnhNV updated END
            //            this.grdOrder.AutoSizeColumn(6, 0);
            //            this.grdOrder.AutoSizeColumn(5, 0);
            //            break;

            //        case "ENDO":
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_02");
            //            this.cboPart.SetEditValue("%");
            //            this.grdOrder.AutoSizeColumn(6, 0);
            //            this.grdOrder.AutoSizeColumn(5, 0);
            //            break;

            //        case "OPRS":
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_05");
            //            this.cboPart.SetEditValue("%");
            //            this.grdOrder.AutoSizeColumn(6, 0);
            //            this.grdOrder.AutoSizeColumn(5, 0);
            //            break;

            //        case "TSTS":
            //            this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_08");
            //            this.cboPart.SetEditValue("%");
            //            break;
            //        case "NURO":
            //            this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
            //            this.rbxOut.PerformClick();
            //            this.rbxOut.ImageIndex = 1;
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_08");
            //            this.cboPart.SetEditValue("%");
            //            break;
            //        case "NURI":
            //            this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
            //            this.rbxInp.PerformClick();
            //            this.rbxInp.ImageIndex = 1;
            //            this.cboSystem.SetEditValue("OCS_ACT_PART_08");
            //            this.cboPart.SetEditValue("%");
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //else
            //{
            //    if (OpenParam.Contains("jundal_table"))
            //    {
            //        string jundal_table = "";
            //        jundal_table = OpenParam["jundal_table"].ToString();

            //        if (jundal_table == "PFES")
            //        {
            //            this.cboSystem.SetDataValue("OCS_ACT_PART_02");
            //            this.cboPart.SetDataValue("%");
            //        }

            //        if (jundal_table == "NUTS")
            //        {
            //            this.cboSystem.SetDataValue("OCS_ACT_PART_06");
            //            this.cboPart.SetDataValue("%");
            //        }
            //    }
            //    if (OpenParam.Contains("bunho"))
            //    {
            //        paBox.SetPatientID(OpenParam["bunho"].ToString());
            //    }
            //    if (OpenParam.Contains("naewon_date"))
            //    {
            //        dtpFromDate.SetDataValue(OpenParam["naewon_date"].ToString());
            //        dtpToDate.SetDataValue(OpenParam["naewon_date"].ToString());
            //    }
            //}
            PostCallHelper.PostCall(new PostMethod(postopen));
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            this.CurrMQLayout = this.grdPaList;

            //this.grdOrder.SavePerformer = new XSavePerformer(this);

            //this.SaveLayoutList.Add(grdOrder);

            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 130);

            string tipTextGrdPalist = Resources.tipTextGrdPalist;
            string tipTextGrdOrder = XMsg.GetField("F002"); // 오더일보기
            this.toolTip.SetToolTip((Control)btnExpand, tipTextGrdPalist);
            this.toolTip.SetToolTip((Control)btnExpandOrdgrid, tipTextGrdOrder);

            //this.rbxOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            //this.rbxInp.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            //this.rbxIOAll.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            //this.rbxTodayOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);

            //this.rbxAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            //this.rbxActAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            //this.rbxNonAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);

            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
            SetEventRowFocus();
        }

        private void btnUseAlarmChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useAlarmChkYN.Equals("N"))
            {
                this.btnUseAlarmChk.ImageIndex = 1;
                this.useAlarmChkYN = "Y";
            }
            else
            {
                this.btnUseAlarmChk.ImageIndex = 0;
                this.useAlarmChkYN = "N";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                // 未実施TABの場合、再照会
                if (this.rbxNonAct.Checked) this.btnList.PerformClick(FunctionType.Query);
                else
                    // 未実施TABが選択される。
                    this.rbxNonAct.Checked = true;

                this.timer1.Stop();

                this.timer1.Start();

                this.QueryTime = TimeVal;
            }
        }

        private void btnUseTimeChk_Click(object sender, EventArgs e)
        {
            // 自動照会使用可否 useTimeChkYN 

            if (this.useTimeChkYN.Equals("N"))
            {
                this.btnUseTimeChk.ImageIndex = 1;
                this.useTimeChkYN = "Y";

                this.timer1.Start();
                this.cboTime.Enabled = true;
                this.tbxTimer.SetDataValue("Y");
                this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
                this.txtTimeInterval.AcceptData();
            }
            else
            {
                this.btnUseTimeChk.ImageIndex = 0;
                this.useTimeChkYN = "N";

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }
        }

        private void txtTimeInterval_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsInt(e.DataValue))
            {
                this.QueryTime = int.Parse(e.DataValue);
                this.TimeVal = int.Parse(e.DataValue);


                this.lbTime.Text = (this.QueryTime / 1000).ToString();

                if (this.tbxTimer.GetDataValue() == "Y")
                {
                    this.timer1.Stop();
                    this.timer1.Start();
                }
            }
            else
            {
                PostCallHelper.PostCall(new PostMethod(PostTimerValidating));
            }
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            this.timer1.Start();
        }

        private void rbxIOAll_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton aRbx = (XRadioButton)sender;

            rbxIOAll.ImageIndex = 0;
            rbxOut.ImageIndex = 0;
            rbxInp.ImageIndex = 0;
            rbxTodayOut.ImageIndex = 0;

            if (!aRbx.Checked)
            {
                return;
            }

            switch (aRbx.Name)
            {
                case "rbxIOAll":
                    rbxIOAll.ImageIndex = 1;
                    break;
                case "rbxOut":
                    rbxOut.ImageIndex = 1;
                    break;
                case "rbxInp":
                    rbxInp.ImageIndex = 1;
                    break;
                case "rbxTodayOut":
                    rbxTodayOut.ImageIndex = 1;
                    break;
            }

            grdPaList.QueryLayout(false);
        }

        private void rbxActAll_CheckedChanged(object sender, EventArgs e)
        {
            this.paBox.Reset();

            XRadioButton aRbx = (XRadioButton)sender;

            this.rbxActAll.ImageIndex = 0;
            this.rbxNonAct.ImageIndex = 0;
            this.rbxAct.ImageIndex = 0;

            this.rbxActAll.BackColor = XColor.DockingGradientStartColor;
            this.rbxNonAct.BackColor = XColor.DockingGradientStartColor;
            this.rbxAct.BackColor = XColor.DockingGradientStartColor;

            this.rbxActAll.ForeColor = XColor.NormalForeColor;
            this.rbxNonAct.ForeColor = XColor.NormalForeColor;
            this.rbxAct.ForeColor = XColor.NormalForeColor;

            if (!aRbx.Checked)
            {
                return;
            }

            switch (aRbx.Name)
            {
                case "rbxActAll":
                    this.rbxActAll.ImageIndex = 1;
                    this.rbxActAll.BackColor = XColor.DockingGradientEndColor;
                    this.rbxActAll.ForeColor = XColor.InsertedForeColor;
                    //MED-9992
                    //MED-14584
                    this.btnChange.Enabled = false;
                    break;
                case "rbxNonAct":
                    this.rbxNonAct.ImageIndex = 1;
                    this.rbxNonAct.BackColor = XColor.DockingGradientEndColor;
                    this.rbxNonAct.ForeColor = XColor.InsertedForeColor;
                    btnJaeryo.Enabled = true;
                    // 実施者に 現在ログインしている IDを セットする｡
                    //MED-14584
                    this.dbxDocCode.SetDataValue(UserInfo.UserID);
                    this.dbxDocName.SetDataValue(UserInfo.UserName);
                    this.btnChange.Enabled = true;                    
                    break;
                case "rbxAct":
                    this.rbxAct.ImageIndex = 1;
                    this.rbxAct.BackColor = XColor.DockingGradientEndColor;
                    this.rbxAct.ForeColor = XColor.InsertedForeColor;
                    btnJaeryo.Enabled = true;
                    // https://sofiamedix.atlassian.net/browse/MED-14767
                    //this.btnChange.Enabled = true;
                    //MED-14584
                    this.btnChange.Enabled = false;

                    break;
            }

            this.grdPaList.QueryLayout(false);

            // ORDER GRID IsReadOnly 設定
            this.controlGrdReadonly();

            // 実施者の初期化
            //this.cbxActor.ResetData();
        }

        private void cboSystem_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.cboPart.ResetData();

            #region deleted by Cloud
            //            // 基準情報（OCS0132）のグループ区分を参考
            //            if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURI" || EnvironInfo.CurrSystemID == "TSTS")
            //            {
            //                this.cboPart.UserSQL = @"SELECT '%' CODE
            //                                              , '全体' CODE_NAME
            //                                           FROM DUAL
            //                                          UNION
            //                                         SELECT A.CODE
            //                                              , A.CODE_NAME
            //                                           FROM (
            //                                                  SELECT CODE
            //                                                       , CODE_NAME
            //                                                    FROM OCS0132
            //                                                   WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
            //                                                     AND CODE_TYPE = '" + this.cboSystem.GetDataValue() + @"'
            //                                                     AND GROUP_KEY = 'NUR'
            //                                                   ORDER BY SORT_KEY 
            //                                                    ) A ";
            //            }
            //            else
            //            {
            //                this.cboPart.UserSQL = @"SELECT '%' CODE
            //                                              , '全体' CODE_NAME
            //                                           FROM DUAL
            //                                          UNION
            //                                         SELECT A.CODE
            //                                              , A.CODE_NAME
            //                                           FROM (
            //                                                  SELECT CODE
            //                                                       , CODE_NAME
            //                                                    FROM OCS0132
            //                                                   WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
            //                                                     AND CODE_TYPE = '" + this.cboSystem.GetDataValue() + @"'
            //                                                     AND GROUP_KEY = '" + EnvironInfo.CurrSystemID + @"'
            //                                                   ORDER BY SORT_KEY 
            //                                                    ) A ";
            //            }
            //            this.cboPart.SetDictDDLB();

            //            // 実施者のSQLをセット
            //            this.setCbxActorSql();
            #endregion

            #region updated by Cloud
            //this.cbxActor.ResetData();

            //MED-9279 gathering request to improve performance (1st)
            LoadDataOpenScreenFirst();

            // Get list combo data
            //GetListCboPartAndActor();

            //cboPart.ExecuteQuery = GetCboPart;
            //cboPart.SetDictDDLB();
            //MED-9984
            jundalTable = "";
            //cbxActor.ExecuteQuery = GetCboActor;
            //cbxActor.SetDictDDLB();
            #endregion

            // Simple version
            //switch (cboSystem.GetDataValue())
            //{
            //    case CPL:
            //        rbxCPL.Checked = true;
            //        SelectTabCpls(rbxCPL);
            //        break;
            //    case TST:
            //        rbxTST.Checked = true;
            //        SelectTabOCSACT(rbxTST);
            //        break;
            //    case PFE:
            //        rbxPFE.Checked = true;
            //        SelectTabOCSACT(rbxPFE);
            //        break;
            //    case INJ: // Default check on INJ tab
            //    default:
            //        rbxINJ.Checked = true;
            //        SelectTabInjs(rbxINJ);
            //        break;
            //}

            //skip this query because it was called in postopen()
            if (!isFirstLoad)
                this.grdPaList.QueryLayout(false);
        }

        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdPaList.QueryLayout(false);
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            // Case OCSACT
            switch (e.Func)
            {
                #region [FunctionType.Insert]
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    if (tabControl.SelectedIndex == 3) //paComment 탭이 선택되었는지 확인 (3)
                    {
                        if (this.CurrMQLayout != this.grdJaeryo) // 현재 선택된 탭이 재료탭인지 확인
                        {
                            if (paComment.BunHo != "")
                            {
                                paComment.InsertRow();
                            }
                        }
                        else
                        {
                            // 未実施TAB、実施済TABのみ可能
                            if (this.rbxAct.Checked && this.grdOrder.RowCount > 0)
                            {
                                this.grdJaeryo.InsertRow();
                            }
                        }
                    }
                    else // 특이사항 이외의 탭.
                    {
                        // 未実施TAB、実施済TABのみ可能
                        if ((this.rbxNonAct.Checked || this.rbxAct.Checked) && this.grdOrder.RowCount > 0)
                        {
                            this.grdJaeryo.InsertRow();
                        }
                    }

                    break;
                #endregion

                #region [FunctionType.Update]
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (this.rbxActAll.Checked || !ExcuteOrderValidating()) return;
                    // 診療終了可否チェック
                    if (this.rbxNonAct.Checked &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun").Equals("O") &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y") &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_doctor") != ""
                       )
                    {
                        if (!this.checkNaewonYn())
                            XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_Caption1, MessageBoxIcon.Information);
                    }

                    #region deleted by Cloud

                    //                    Hashtable inputList = new Hashtable();
                    //                    Hashtable outputList = new Hashtable();

                    //                    BindVarCollection bindVars = new BindVarCollection();
                    //                    ArrayList sendIFList = new ArrayList();
                    //                    {
                    //                        Service.BeginTransaction();

                    //                        #region [foreach grdOrder.LayoutTable]
                    //                        foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                    //                        {
                    //                            if (dtRow.RowState == DataRowState.Modified)
                    //                            {
                    //                                // 会計未処理のみ
                    //                                if (dtRow["if_data_send_yn"].ToString() == "Y")
                    //                                {
                    //                                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    //                                    return;
                    //                                }

                    //                                #region [未実施TAB]
                    //                                if (this.rbxNonAct.Checked)
                    //                                {
                    //                                    if (dtRow["act_yn"].ToString().Equals("Y") && dtRow["act_doctor"].ToString().Equals(""))
                    //                                    {
                    //                                        XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_Caption3, MessageBoxIcon.Information);
                    //                                        return;
                    //                                    }

                    //                                    inputList.Clear();
                    //                                    outputList.Clear();

                    //                                    if (dtRow["act_yn"].ToString() == "Y")
                    //                                    {
                    //                                        //string tempOrder = this.isTempOrder(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_code"));
                    //                                        string tempOrder = this.isTempOrder(dtRow["hangmog_code"].ToString());

                    //                                        ChangeOrderCode dlg = new ChangeOrderCode(tempOrder);

                    //                                        // 仮オーダチェック
                    //                                        if (tempOrder != "")
                    //                                        {
                    //                                            string ocsKey = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs");

                    //                                            dlg.ShowDialog();

                    //                                            if (dlg.selectedOrder == null)
                    //                                            {
                    //                                                Service.RollbackTransaction();
                    //                                                return;
                    //                                            }
                    //                                            else
                    //                                            {
                    //                                                string cmdText = "";

                    //                                                // 仮オーダのORDER_REMARK　の　更新処理
                    //                                                bindVars.Clear();
                    //                                                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                                                bindVars.Add("f_remark", dlg.selectedOrderName);
                    //                                                bindVars.Add("f_pkocs", dtRow["pkocs"].ToString());

                    //                                                if (dtRow["in_out_gubun"].ToString().Equals("O"))
                    //                                                {
                    //                                                    cmdText = @"UPDATE OCS1003
                    //                                                           SET NURSE_REMARK  = :f_remark
                    //                                                              ,UPD_ID        = 'UPD_REC_'  
                    //                                                         WHERE HOSP_CODE     = :f_hosp_code
                    //                                                           AND PKOCS1003     = :f_pkocs";
                    //                                                }

                    //                                                if (dtRow["in_out_gubun"].ToString().Equals("I"))
                    //                                                {

                    //                                                    cmdText = @"UPDATE OCS2003
                    //                                                           SET NURSE_REMARK  = :f_remark
                    //                                                              ,UPD_ID        = 'UPD_REC_'  
                    //                                                         WHERE HOSP_CODE     = :f_hosp_code
                    //                                                           AND PKOCS2003     = :f_pkocs";
                    //                                                }

                    //                                                if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    //                                                {
                    //                                                    Service.RollbackTransaction();
                    //                                                    XMessageBox.Show(Service.ErrFullMsg);
                    //                                                    return;
                    //                                                }
                    //                                            }
                    //                                        }

                    //                                        inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                    //                                        inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                    //                                        inputList.Add("I_ACT_BUSEO", dtRow["jundal_part"]);
                    //                                        inputList.Add("I_JUBSU_DATE", dtRow["jubsu_date"].ToString());
                    //                                        inputList.Add("I_JUBSU_TIME", dtRow["jubsu_time"].ToString());
                    //                                        inputList.Add("I_ACTING_DATE", dtRow["acting_date"].ToString());
                    //                                        inputList.Add("I_ACTING_TIME", dtRow["acting_time"].ToString());
                    //                                        inputList.Add("I_ACT_DOCTOR", dtRow["act_doctor"].ToString());

                    //                                        if (dtRow["input_control"].ToString() == "3")
                    //                                        {
                    //                                            string cmd = "";
                    //                                            BindVarCollection bind = new BindVarCollection();

                    //                                            bind.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                                            bind.Add("f_suryang", dtRow["suryang"].ToString());
                    //                                            bind.Add("f_nalsu", dtRow["nalsu"].ToString());
                    //                                            bind.Add("f_pkocskey", dtRow["pkocs"].ToString());

                    //                                            if (dtRow["in_out_gubun"].ToString() == "O")
                    //                                            {
                    //                                                cmd = @"UPDATE OCS1003 A
                    //                                                   SET A.SURYANG = :f_suryang
                    //                                                     , A.NALSU   = :f_nalsu
                    //                                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                                   AND A.PKOCS1003 = :f_pkocskey
                    //                                                    ";

                    //                                            }
                    //                                            else
                    //                                            {
                    //                                                cmd = @"UPDATE OCS2003 A
                    //                                                   SET A.SURYANG = :f_suryang
                    //                                                     , A.NALSU   = :f_nalsu
                    //                                                 WHERE A.HOSP_CODE = :f_hosp_code
                    //                                                   AND A.PKOCS2003 = :f_pkocskey
                    //                                                    ";

                    //                                            }

                    //                                            if (!Service.ExecuteNonQuery(cmd, bind))
                    //                                            {
                    //                                                Service.RollbackTransaction();
                    //                                                XMessageBox.Show(Service.ErrFullMsg);
                    //                                                return;
                    //                                            }
                    //                                        }

                    //                                        // 心電図のグロバール変数セット----------------------------------------------------------------
                    //                                        if (dtRow["jundal_part"].ToString() == "EKG")
                    //                                        {
                    //                                            this.i_pkocs = dtRow["pkocs"].ToString();
                    //                                            this.i_order_date = dtRow["order_date"].ToString();
                    //                                            this.i_bunho = dtRow["bunho"].ToString();
                    //                                            this.i_fkout1001 = dtRow["fkout1001"].ToString();
                    //                                        }
                    //                                        //---------------------------------------------------------------------------------------------

                    //                                        // [PR_OCS_UPDATE_ACTING 処理]
                    //                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_ACTING", inputList, outputList))
                    //                                        {
                    //                                            Service.RollbackTransaction();
                    //                                            XMessageBox.Show(Service.ErrFullMsg);
                    //                                            return;
                    //                                        }
                    //                                        else
                    //                                        {
                    //                                            if (dtRow["jundal_part"].ToString() == "ENDO")
                    //                                            {
                    //                                                sendIFinfo ifinfo = new sendIFinfo();

                    //                                                ifinfo.pkOcs = dtRow["pkocs"].ToString();
                    //                                                ifinfo.inOutGubun = dtRow["in_out_gubun"].ToString();
                    //                                                ifinfo.ifSysGubun = "MX";
                    //                                                ifinfo.ifCmdGubun = "INSERT";
                    //                                                ifinfo.userID = dtRow["act_doctor"].ToString();

                    //                                                sendIFList.Add(ifinfo);
                    //                                            }
                    //                                            else if (dtRow["jundal_part"].ToString() == "EKG")
                    //                                            {
                    //                                                //sendIFinfo ifinfo = new sendIFinfo();

                    //                                                //ifinfo.pkOcs = dtRow["pkocs"].ToString();
                    //                                                //ifinfo.inOutGubun = dtRow["in_out_gubun"].ToString();
                    //                                                //ifinfo.ifSysGubun = "EKG";
                    //                                                //ifinfo.ifCmdGubun = "INSERT";

                    //                                                //ifinfo.userID = dtRow["act_doctor"].ToString();

                    //                                                //sendIFList.Add(ifinfo);

                    //                                                if (this.cbxEkgIFYN.Checked)
                    //                                                {
                    //                                                    // 心電図のグロバール変数セット
                    //                                                    this.i_pkocs = dtRow["pkocs"].ToString();
                    //                                                    this.i_order_date = dtRow["order_date"].ToString();
                    //                                                    this.i_bunho = dtRow["bunho"].ToString();
                    //                                                    this.i_fkout1001 = dtRow["fkout1001"].ToString();
                    //                                                }
                    //                                            }

                    //                                            // [PR_SCH_UPDATE_ACTING 処理]
                    //                                            inputList.Clear();
                    //                                            outputList.Clear();

                    //                                            inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                    //                                            inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                    //                                            inputList.Add("I_ACTING_DATE", dtRow["acting_date"].ToString());

                    //                                            if (!Service.ExecuteProcedure("PR_SCH_UPDATE_ACTING", inputList, outputList))
                    //                                            {
                    //                                                Service.RollbackTransaction();
                    //                                                XMessageBox.Show(Service.ErrFullMsg);
                    //                                                return;
                    //                                            }

                    //                                            // 仮オーダチェック
                    //                                            if (tempOrder != "")
                    //                                            {
                    //                                                inputList.Clear();
                    //                                                outputList.Clear();

                    //                                                inputList.Add("I_IO_GUBUN", dtRow["in_out_gubun"].ToString());
                    //                                                inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
                    //                                                inputList.Add("I_SRC_FKOCS", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs"));
                    //                                                //inputList.Add("I_USER_ID", UserInfo.UserID);
                    //                                                inputList.Add("I_USER_ID", dtRow["act_doctor"].ToString());
                    //                                                inputList.Add("I_INPUT_GUBUN", UserInfo.InputGubun);
                    //                                                inputList.Add("I_HANGMOG_CODE", dlg.selectedOrder);

                    //                                                // [PR_OCS_REAL_ORDER_FROM_DUMMY 処理]
                    //                                                if (!Service.ExecuteProcedure("PR_OCS_REAL_ORDER_FROM_DUMMY", inputList, outputList))
                    //                                                {
                    //                                                    Service.RollbackTransaction();
                    //                                                    XMessageBox.Show(Service.ErrFullMsg);
                    //                                                    return;
                    //                                                }
                    //                                                else
                    //                                                {
                    //                                                    // 仮オーダ
                    //                                                    this.newOcsKey = outputList["O_NEW_PKOCS"].ToString();
                    //                                                }
                    //                                            }
                    //                                            else
                    //                                            {
                    //                                                // 一般オーダ
                    //                                                this.newOcsKey = dtRow["pkocs"].ToString();
                    //                                            }
                    //                                        }
                    //                                    }
                    //                                }
                    //                                #endregion

                    //                                #region [実施済TAB]
                    //                                if (this.rbxAct.Checked)
                    //                                {
                    //                                    if (dtRow["act_yn"].ToString() == "N")
                    //                                    {
                    //                                        inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                    //                                        if (dtRow["sort_fkocskey"].ToString() == "") inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                    //                                        else inputList.Add("I_FKOCS", dtRow["sort_fkocskey"].ToString());
                    //                                        inputList.Add("I_ACT_BUSEO", null);
                    //                                        inputList.Add("I_JUBSU_DATE", null);
                    //                                        inputList.Add("I_JUBSU_TIME", null);
                    //                                        inputList.Add("I_ACTING_DATE", null);
                    //                                        inputList.Add("I_ACTING_TIME", null);
                    //                                        inputList.Add("I_ACT_DOCTOR", null);

                    //                                        // PR_OCS_UPDATE_ACTING
                    //                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_ACTING", inputList, outputList))
                    //                                        {
                    //                                            Service.RollbackTransaction();
                    //                                            XMessageBox.Show(Service.ErrFullMsg);
                    //                                            return;
                    //                                        }
                    //                                        else
                    //                                        {
                    //                                            if (dtRow["jundal_part"].ToString() == "ENDO")
                    //                                            {
                    //                                                sendIFinfo ifinfo = new sendIFinfo();

                    //                                                if (dtRow["sort_fkocskey"].ToString() == "") ifinfo.pkOcs = dtRow["pkocs"].ToString();
                    //                                                else ifinfo.pkOcs = dtRow["sort_fkocskey"].ToString();
                    //                                                ifinfo.inOutGubun = dtRow["in_out_gubun"].ToString();
                    //                                                ifinfo.ifSysGubun = "MX";
                    //                                                ifinfo.ifCmdGubun = "DELETE";
                    //                                                ifinfo.userID = dtRow["act_doctor"].ToString();

                    //                                                sendIFList.Add(ifinfo);
                    //                                            }

                    //                                            // PR_SCH_UPDATE_ACTING
                    //                                            inputList.Clear();
                    //                                            outputList.Clear();

                    //                                            inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                    //                                            if (dtRow["sort_fkocskey"].ToString() == "") inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                    //                                            else inputList.Add("I_FKOCS", dtRow["sort_fkocskey"].ToString());
                    //                                            inputList.Add("I_ACTING_DATE", null);

                    //                                            if (!Service.ExecuteProcedure("PR_SCH_UPDATE_ACTING", inputList, outputList))
                    //                                            {
                    //                                                Service.RollbackTransaction();
                    //                                                XMessageBox.Show(Service.ErrFullMsg);
                    //                                                return;
                    //                                            }

                    //                                            // 材料取消処理
                    //                                            this.updJaeryoProcess("D");
                    //                                        }
                    //                                    }
                    //                                }
                    //                                #endregion
                    //                            }
                    //                        }
                    //                        #endregion

                    //                        #region [材料GRID 変更事項チェック & 登録、修正、削除処理]

                    //                        // 未実施TABで　実施チェックの場合
                    //                        if (this.rbxNonAct.Checked)
                    //                        {
                    //                            if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                    //                            {
                    //                                DataRowState drState = DataRowState.Unchanged;

                    //                                for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                    //                                {
                    //                                    if (this.grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                    //                                    {
                    //                                        drState = this.grdJaeryo.GetRowState(i);
                    //                                        break;
                    //                                    }
                    //                                }

                    //                                // 材料GRIDに変更事項がある場合
                    //                                if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                    //                                {
                    //                                    if (XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_Caption4, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //                                    {
                    //                                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                    //                                            XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox_Caption5, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                                        else
                    //                                            // 一括処理
                    //                                            this.updJaeryoProcess();
                    //                                    }
                    //                                    else
                    //                                    {
                    //                                        this.grdJaeryo.QueryLayout(false);
                    //                                        return;
                    //                                    }
                    //                                }
                    //                            }
                    //                        }

                    //                        // 実施済TABで、実施済の場合
                    //                        if (this.rbxAct.Checked)
                    //                        {
                    //                            if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                    //                            {
                    //                                DataRowState drState = DataRowState.Unchanged;

                    //                                for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                    //                                {
                    //                                    if (this.grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                    //                                    {
                    //                                        drState = this.grdJaeryo.GetRowState(i);
                    //                                        break;
                    //                                    }
                    //                                }

                    //                                // 材料GRIDに変更事項がある場合
                    //                                if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                    //                                {
                    //                                    if (XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_Caption4, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //                                    {
                    //                                        // 一括処理
                    //                                        this.updJaeryoProcess();
                    //                                    }
                    //                                    else
                    //                                    {
                    //                                        this.grdJaeryo.QueryLayout(false);
                    //                                        return;
                    //                                    }
                    //                                }
                    //                            }
                    //                        }
                    //                        #endregion

                    //                        //////////////////////////////////////////////////////////////////////////////////////////
                    //                        #region [実施済TABで、実施済の場合、仮オーダの下の実オーダの場合、物理的にUPDATE, DELETE 処理を行う。]
                    //                        // 実施済TABで、実施済の場合
                    //                        if (this.rbxAct.Checked && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                    //                        {
                    //                            // 入外区分
                    //                            string ioGubun = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun");

                    //                            if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "sort_fkocskey") != "")
                    //                            {
                    //                                string cmdText = "";

                    //                                // 仮オーダのORDER_REMARK　の　更新処理
                    //                                bindVars.Clear();
                    //                                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
                    //                                bindVars.Add("f_pkocs", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "sort_fkocskey"));

                    //                                if (ioGubun.Equals("O"))
                    //                                {
                    //                                    cmdText = @"UPDATE OCS1003
                    //                                               SET NURSE_REMARK  = null
                    //                                                  ,UPD_ID        = 'UPD_REC_'  
                    //                                             WHERE HOSP_CODE     = :f_hosp_code
                    //                                               AND PKOCS1003     = :f_pkocs";
                    //                                }

                    //                                if (ioGubun.Equals("I"))
                    //                                {
                    //                                    cmdText = @"UPDATE OCS2003
                    //                                               SET NURSE_REMARK  = NULL
                    //                                                  ,FKOCS1003     = NULL
                    //                                                  ,UPD_ID        = 'UPD_REC_'  
                    //                                             WHERE HOSP_CODE     = :f_hosp_code
                    //                                               AND PKOCS2003     = :f_pkocs";
                    //                                }

                    //                                if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    //                                {
                    //                                    Service.RollbackTransaction();
                    //                                    XMessageBox.Show(Service.ErrFullMsg);
                    //                                    return;
                    //                                }
                    //                                else
                    //                                {
                    //                                    bindVars.Clear();
                    //                                    bindVars.Add("f_pkocs", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs"));

                    //                                    if (ioGubun.Equals("O"))
                    //                                    {
                    //                                        cmdText = @"UPDATE OCS1003
                    //                                               SET JUBSU_DATE      = null
                    //                                                 , ACTING_DATE     = null
                    //                                             WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE() 
                    //                                               AND PKOCS1003  = :f_pkocs";
                    //                                    }

                    //                                    if (ioGubun.Equals("I"))
                    //                                    {
                    //                                        cmdText = @"UPDATE OCS2003
                    //                                               SET JUBSU_DATE      = null
                    //                                                 , ACTING_DATE     = null
                    //                                             WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE() 
                    //                                               AND PKOCS2003  = :f_pkocs";
                    //                                    }

                    //                                    if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    //                                    {
                    //                                        Service.RollbackTransaction();
                    //                                        XMessageBox.Show(Service.ErrFullMsg);
                    //                                        return;
                    //                                    }
                    //                                    else
                    //                                    {
                    //                                        if (ioGubun.Equals("O"))
                    //                                        {
                    //                                            cmdText = @"DELETE OCS1003
                    //                                                     WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE() 
                    //                                                       AND PKOCS1003  = :f_pkocs";
                    //                                        }

                    //                                        if (ioGubun.Equals("I"))
                    //                                        {
                    //                                            cmdText = @"DELETE OCS2003
                    //                                                     WHERE HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE() 
                    //                                                       AND PKOCS2003  = :f_pkocs";
                    //                                        }

                    //                                        if (!Service.ExecuteNonQuery(cmdText, bindVars))
                    //                                        {
                    //                                            Service.RollbackTransaction();
                    //                                            XMessageBox.Show(Service.ErrFullMsg);
                    //                                            return;
                    //                                        }
                    //                                    }
                    //                                }
                    //                            }
                    //                        }
                    //                        #endregion
                    //                        ///////////////////////////////////////////////////////////////////////////////////////////

                    //                        Service.CommitTransaction();
                    //                    }
                    #endregion

                    #region Updated by Cloud

                    bool isGetGrdJaeryo = false;
                    bool isUpdateJaeryoProc = false;
                    List<OCSACTUpdateGrdOrderInfo> grdOrderInfo = new List<OCSACTUpdateGrdOrderInfo>();
                    List<OCSACTUpdJaeryoProcessWithUpdGubunInfo> updGubunInfo = new List<OCSACTUpdJaeryoProcessWithUpdGubunInfo>();
                    List<OCSACTUpdJaeryoProcessInfo> updJaeryoInfo = new List<OCSACTUpdJaeryoProcessInfo>();
                    List<OCSACTDeleteJaeryoInfo> delJaeryoInfo = new List<OCSACTDeleteJaeryoInfo>();

                    #region Update #1

                    foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                    {
                        // Skip un-modified rows
                        if (dtRow.RowState != DataRowState.Modified) continue;

                        // 会計未処理のみ
                        if (dtRow["if_data_send_yn"].ToString() == "Y" && NetInfo.Language == LangMode.Jr) // Update Lgic VN Hospital
                        {
                            XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                            return;
                        }

                        #region 未実施TAB

                        if (rbxNonAct.Checked)
                        {
                            if (dtRow["act_yn"].ToString().Equals("Y") && dtRow["act_doctor"].ToString().Equals(""))
                            {
                                XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_Caption3, MessageBoxIcon.Information);
                                return;
                            }

                            if (dtRow["act_yn"].ToString() == "Y")
                            {
                                string tempOrder = this.isTempOrder(dtRow["hangmog_code"].ToString());

                                ChangeOrderCode dlg = new ChangeOrderCode(tempOrder);

                                if (tempOrder != "")
                                {
                                    //string ocsKey = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs");

                                    dlg.ShowDialog();

                                    if (dlg.selectedOrder == null) return;
                                }

                                OCSACTUpdateGrdOrderInfo grdOrderItem = MakeGrdOrderItemForUpdate(dtRow, dlg);
                                grdOrderInfo.Add(grdOrderItem);
                            }
                        }

                        #endregion

                        #region [実施済TAB]

                        if (this.rbxAct.Checked)
                        {
                            if (dtRow["act_yn"].ToString() == "N")
                            {
                                OCSACTUpdateGrdOrderInfo grdOrderItem = MakeGrdOrderItemForUpdate(dtRow, null);
                                grdOrderInfo.Add(grdOrderItem);
                                isGetGrdJaeryo = true;
                            }
                        }

                        #endregion
                    }

                    // Get grdJaeryo for update
                    if (isGetGrdJaeryo)
                    {
                        foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                        {
                            OCSACTUpdJaeryoProcessWithUpdGubunInfo updGubunItem = new OCSACTUpdJaeryoProcessWithUpdGubunInfo();
                            updGubunItem.FkocsInv = dtRow["fkocs_inv"].ToString();
                            updGubunItem.FkocsXrt = dtRow["fkocs_xrt"].ToString();
                            updGubunItem.HangmogCode = dtRow["hangmog_code"].ToString();
                            updGubunItem.InputId = UserInfo.UserID;
                            updGubunItem.IudGubun = "D";
                            updGubunItem.Nalsu = dtRow["nalsu"].ToString();
                            updGubunItem.OrdDanui = dtRow["ord_danui"].ToString();
                            updGubunItem.Pkinv1001 = dtRow["pkinv1001"].ToString();
                            updGubunItem.Suryang = dtRow["suryang"].ToString();

                            //MED-11182
                            updGubunItem.Pkocs1003 = dtRow["in_out_gubun"].ToString();

                            updGubunInfo.Add(updGubunItem);
                        }
                    }

                    #endregion

                    #region Update #2

                    #region 未実施TABで　実施チェックの場合
                    if (rbxNonAct.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (this.grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_Caption4, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                                    {
                                        XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox_Caption5, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        // 一括処理
                                        foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                                        {
                                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
                                            {
                                                XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
                                                return;
                                            }
                                            if (dtRow["suryang"].ToString() == "")
                                            {
                                                string mMsg = NetInfo.Language == LangMode.Ko ?
                                                         Resources.XMessageBox6_Ko :
                                                         Resources.XMessageBox6_JP;
                                                string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Caption : Resources.XMessageBox_caption2;
                                                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                return;
                                            }

                                            OCSACTUpdJaeryoProcessInfo updJaeryoItem = MakeGrdJaeryoItemForUpdate(dtRow);
                                            updJaeryoInfo.Add(updJaeryoItem);
                                            isUpdateJaeryoProc = true;
                                        }
                                    }
                                }
                                else
                                {
                                    this.grdJaeryo.QueryLayout(false);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion

                    #region 実施済TABで、実施済の場合
                    if (this.rbxAct.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (this.grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_Caption4, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    // 一括処理
                                    foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                                    {
                                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
                                        {
                                            XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
                                            return;
                                        }
                                        if (dtRow["suryang"].ToString() == "")
                                        {
                                            string mMsg = NetInfo.Language == LangMode.Ko ?
                                                     Resources.XMessageBox6_Ko :
                                                     Resources.XMessageBox6_JP;
                                            string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Caption : Resources.XMessageBox_caption2;
                                            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }

                                        OCSACTUpdJaeryoProcessInfo updJaeryoItem = MakeGrdJaeryoItemForUpdate(dtRow);
                                        updJaeryoInfo.Add(updJaeryoItem);
                                        isUpdateJaeryoProc = true;
                                    }
                                }
                                else
                                {
                                    this.grdJaeryo.QueryLayout(false);
                                    return;
                                }
                            }
                        }
                    }
                    #endregion

                    #region Deleted

                    if (grdJaeryo.DeletedRowTable != null)
                    {
                        foreach (DataRow dtRow in grdJaeryo.DeletedRowTable.Rows)
                        {
                            OCSACTDeleteJaeryoInfo delJaeryoItem = new OCSACTDeleteJaeryoInfo();
                            delJaeryoItem.FkocsInv = dtRow["fkocs_inv"].ToString();
                            delJaeryoItem.FkocsXrt = dtRow["fkocs_xrt"].ToString();
                            delJaeryoItem.HangmogCode = dtRow["hangmog_code"].ToString();
                            delJaeryoItem.Nalsu = dtRow["nalsu"].ToString();
                            delJaeryoItem.OrdDanui = dtRow["ord_danui"].ToString();
                            delJaeryoItem.Pkinv1001 = dtRow["pkinv1001"].ToString();
                            delJaeryoItem.Suryang = dtRow["suryang"].ToString();

                            //MED-11182
                            delJaeryoItem.Pkocs1003 = dtRow["in_out_gubun"].ToString();

                            delJaeryoInfo.Add(delJaeryoItem);
                        }
                    }

                    #endregion

                    #endregion

                    if (grdOrderInfo.Count == 0
                        && updGubunInfo.Count == 0
                        && updJaeryoInfo.Count == 0
                        && delJaeryoInfo.Count == 0)
                    {
                        return;
                    }

                    //MED-11182
                    if (!CheckInventory())
                    {
                        return;
                    }

                    OCSACTUpdateArgs args = new OCSACTUpdateArgs();
                    args.RbtNonAct = rbxNonAct.Checked;
                    args.RbtAct = rbxAct.Checked;
                    args.IsUpdJaeryoProcess = isUpdateJaeryoProc;
                    args.ActYn = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn");
                    args.InOutGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
                    args.SortFkocskey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "sort_fkocskey");
                    args.Pkocs = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs");
                    args.ActingDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date");
                    args.ActingTime = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time");
                    args.NewOcsKey = this.newOcsKey;
                    args.JundalPart = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part");
                    args.OrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
                    args.UserId = UserInfo.UserID;
                    args.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
                    args.UpdateGrdOrderItem = grdOrderInfo;
                    args.JaeryoWithUpdItem = updGubunInfo;
                    args.JaeryoItem = updJaeryoInfo;
                    args.DeleteJaeryoItem = delJaeryoInfo;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCSACTUpdateArgs>(args);

                    if (res.Msg != "")
                    {
                        XMessageBox.Show(res.Msg);
                        return;
                    }

                    #endregion

                    // 心電図検査の場合、連携電文を生成する。
                    if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jundal_part") == "EKG")
                    {
                        if (this.rbxNonAct.Checked && this.cbxEkgIFYN.Checked)
                        {
                            // 心電図連携ボタン実行
                            this.btnIfEkg.PerformClick();
                        }
                    }

                    this.grdPaList.QueryLayout(false);

                    break;
                #endregion

                #region [FunctionType.Delete]
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    if (paComment.BunHo != "")
                    {
                        if (this.CurrMQLayout != this.grdJaeryo && tabControl.SelectedIndex == 3) //paComment 탭이 선택되었는지 확인 (3) 
                        {
                            //paComment.SaveComment();

                            paComment.deleteRow();
                        }
                        else if ((this.rbxNonAct.Checked || this.rbxAct.Checked) && this.CurrMQLayout == this.grdJaeryo)
                        {
                            this.grdJaeryo.DeleteRow();
                        }
                    }
                    break;
                #endregion

                #region [FunctionType.Query]
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdPaList.QueryLayout(false);
                    btnJaeryo.Enabled = true;
                    break;
                #endregion
                default:
                    break;
            }
        }

        private bool CheckInventory()
        {
            List<OBCheckInventoryParamInfo> inputList = new List<OBCheckInventoryParamInfo>();
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                OBCheckInventoryParamInfo info = new OBCheckInventoryParamInfo();
                info.Dv = "1";
                info.HangmogCode = grdOrder.GetItemString(i, "hangmog_code");
                info.HangmogName = grdOrder.GetItemString(i, "hangmog_name");
                info.Suryang = grdOrder.GetItemString(i, "suryang");
                info.Nalsu = grdOrder.GetItemString(i, "nalsu");

                inputList.Add(info);
            }

            for (int i = 0; i < grdJaeryo.RowCount; i++)
            {
                OBCheckInventoryParamInfo info = new OBCheckInventoryParamInfo();
                info.Dv = "1";
                info.HangmogCode = grdJaeryo.GetItemString(i, "hangmog_code");
                info.HangmogName = grdJaeryo.GetItemString(i, "hangmog_name");
                info.Suryang = grdJaeryo.GetItemString(i, "suryang");
                info.Nalsu = grdJaeryo.GetItemString(i, "nalsu");

                inputList.Add(info);
            }

            return IHIS.Framework.Utilities.CheckInventory(inputList);
        }

        private bool ExcuteOrderValidating()
        {
            if (rbxNonAct.Checked)
            {
                if (string.IsNullOrEmpty(dbxDocCode.GetDataValue()))
                {
                    XMessageBox.Show(Resources.MSG_REQ_DOCTOR, Resources.CAP_REQ_DOCTOR, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1,
                        MessageBoxIcon.Warning);
                    return false;
                }

                if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                {
                    XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox_Caption5, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1,
                        MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (grdPaList.CellInfos["gwa_name"].CellWidth > 1)
            {
                grdPaList.CellInfos["gwa_name"].CellWidth = 1;
                grdPaList.CellInfos["doctor_name"].CellWidth = 1;
                grdPaList.AutoSizeColumn(4, 1);
                grdPaList.AutoSizeColumn(5, 1);
                btnExpand.ImageIndex = 3;
                tipText = Resources.tipTextGrdPalist;
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdPaList.Refresh();
            }
            else
            {
                grdPaList.CellInfos["gwa_name"].CellWidth = 60;
                grdPaList.CellInfos["doctor_name"].CellWidth = 80;
                grdPaList.AutoSizeColumn(4, 60);
                grdPaList.AutoSizeColumn(5, 80);

                btnExpand.ImageIndex = 2;
                tipText = Resources.tipText;
                this.toolTip.SetToolTip((Control)sender, tipText);
                grdPaList.Refresh();
            }
        }

        private void btnExpandOrdgrid_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (this.grdOrder.CellInfos["order_date"].CellWidth > 1)
            {
                this.grdOrder.CellInfos["order_date"].CellWidth = 1;
                this.grdOrder.CellInfos["order_time"].CellWidth = 1;
                this.grdOrder.AutoSizeColumn(3, 1);
                this.grdOrder.AutoSizeColumn(4, 1);
                this.btnExpandOrdgrid.ImageIndex = 3;
                tipText = XMsg.GetField("F002"); // 오더일보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                this.grdOrder.Refresh();
            }
            else
            {
                this.grdOrder.CellInfos["order_date"].CellWidth = 80;
                this.grdOrder.CellInfos["order_time"].CellWidth = 30;
                this.grdOrder.AutoSizeColumn(3, 80);
                this.grdOrder.AutoSizeColumn(4, 30);

                this.btnExpandOrdgrid.ImageIndex = 2;
                tipText = XMsg.GetField("F003"); // 오더일안보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                this.grdOrder.Refresh();
            }
        }

        private void grdPaList_QueryStarting(object sender, CancelEventArgs e)
        {
            //string io_gubun = "1";//all = 1, out = 2, inp = 3, todayout = 4
            //if (rbxIOAll.Checked) io_gubun = "1";
            //else if (rbxOut.Checked) io_gubun = "2";
            //else if (rbxInp.Checked) io_gubun = "3";
            //else io_gubun = "4";

            //string act_gubun = "1";//all = 1, no act = 2, act = 3
            //if (rbxActAll.Checked) act_gubun = "1";
            //else if (rbxNonAct.Checked) act_gubun = "2";
            //else act_gubun = "3";

            //// deleted by Cloud
            ////string jundal_part_param = this.setPartParam(this.cboPart.GetDataValue());

            //grdOrder.Reset();
            //grdJaeryo.Reset();

            #region deleted by Cloud
            //            this.grdPaList.QuerySQL = @"SELECT DISTINCT 
            //                                               'O'                                                IN_OUT_GUBUN
            //                                              --, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) GUMSA_DATE
            //                                              , A.BUNHO                                           BUNHO
            //                                              , B.SUNAME                                          SUNAME
            //                                              , B.SUNAME2                                         SUNAME2
            //                                              , A.GWA                                             GWA
            //                                              , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE)           GWA_NAME
            //                                              , A.DOCTOR                                          DOCTOR
            //                                              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)     DOCTOR_NAME
            //                                              , A.JUNDAL_TABLE                                    JUNDAL_TABLE
            //                                              , DECODE(A.RESER_DATE,NULL,'N','Y')                 RESER_YN
            //                                              , A.EMERGENCY
            //                                           FROM OUT0101 B
            //                                              , OCS1003 A
            //                                          WHERE A.HOSP_CODE = :f_hosp_code
            //                                                AND ((:f_bunho IS NULL AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date) 
            //                                                 OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                                AND ( ( :f_act_gubun = '1' )
            //                                                 OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )
            //                                                 OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )
            //                                                AND A.JUNDAL_TABLE   = (SELECT X.MENT 
            //                                                                          FROM OCS0132 X 
            //                                                                         WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                           AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                           AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                                AND A.JUNDAL_PART    IN (" + jundal_part_param + @")
            //                                                AND :f_io_gubun      IN ('1','2','4')
            //                                                AND ( (:f_io_gubun   = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = TRUNC(SYSDATE) AND X.BUNHO = A.BUNHO))
            //                                                 OR :f_io_gubun   <> '4' )
            //                                                AND A.DC_YN          = 'N' 
            //                                                AND A.NALSU          > 0
            //                                                AND B.HOSP_CODE      = A.HOSP_CODE
            //                                                AND B.BUNHO          = A.BUNHO
            //                                        UNION
            //                                        SELECT DISTINCT 
            //                                               'I'                                                IN_OUT_GUBUN
            //                                              --, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE)) GUMSA_DATE
            //                                              , A.BUNHO                                           BUNHO
            //                                              , C.SUNAME                                          SUNAME
            //                                              , C.SUNAME2                                         SUNAME2
            //                                              , B.GWA                                             GWA
            //                                              , FN_BAS_LOAD_GWA_NAME(B.GWA, A.SYS_DATE)           GWA_NAME
            //                                              , A.DOCTOR                                          DOCTOR
            //                                              , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)     DOCTOR_NAME
            //                                              , A.JUNDAL_TABLE                                    JUNDAL_TABLE
            //                                              , DECODE(A.RESER_DATE,NULL,'N','Y')                 RESER_YN
            //                                              , A.EMERGENCY
            //                                           FROM OUT0101 C
            //                                              , INP1001 B
            //                                              , OCS2003 A
            //                                          WHERE A.HOSP_CODE = :f_hosp_code
            //                                            AND ((:f_bunho IS NULL AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date) 
            //                                             OR (:f_bunho IS NOT NULL AND A.BUNHO = :f_bunho))
            //                                            AND ( ( :f_act_gubun = '1' )
            //                                             OR ( :f_act_gubun = '2' AND A.ACTING_DATE IS NULL )
            //                                             OR ( :f_act_gubun = '3' AND A.ACTING_DATE IS NOT NULL ) )
            //                                            AND A.JUNDAL_TABLE   = (SELECT X.MENT 
            //                                                                      FROM OCS0132 X 
            //                                                                     WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                       AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                       AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                            AND A.JUNDAL_PART    IN (" + jundal_part_param + @")
            //                                            AND :f_io_gubun      IN ('1','3')   
            //                                            AND ( (:f_io_gubun = '4' AND EXISTS (SELECT 'X' FROM OUT1001 X WHERE X.NAEWON_DATE = TRUNC(SYSDATE) AND X.BUNHO = A.BUNHO))
            //                                             OR :f_io_gubun <> '4' )
            //                                            AND A.DC_YN = 'N' 
            //                                            AND A.NALSU > 0
            //                                            AND B.HOSP_CODE      = A.HOSP_CODE
            //                                            AND B.PKINP1001      = A.FKINP1001
            //                                            AND C.HOSP_CODE      = A.HOSP_CODE 
            //                                            AND C.BUNHO          = A.BUNHO
            //                                          ORDER BY 1,2,3,6";
            #endregion

            //this.grdPaList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdPaList.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_bunho", paBox.BunHo);
            //this.grdPaList.SetBindVarValue("f_act_gubun", act_gubun);
            //this.grdPaList.SetBindVarValue("f_jundal_table_code", cboSystem.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_io_gubun", io_gubun);
            //this.grdPaList.SetBindVarValue("f_cbo_part", cboPart.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_cbo_system", cboSystem.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_cbo_val", cboPart.GetDataValue());
            //this.grdPaList.SetBindVarValue("f_system_id", EnvironInfo.CurrSystemID);

            // Simple version
            string jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
            string actingFlg = (rbxAct.Checked) ? "2" : (rbxNonAct.Checked ? "1" : "");

            // Reset all grid
            this.patientInfoBox.Reset();
            this.ResetGrids(jundalTable);

            // Binding parameters
            this.grdPaList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            this.grdPaList.SetBindVarValue("f_order_date_from", dtpFromDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_order_date_to", dtpToDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdPaList.SetBindVarValue("f_jundal_table", cboSystem.GetDataValue());
            this.grdPaList.SetBindVarValue("f_gwa", cboPart.GetDataValue());
            this.grdPaList.SetBindVarValue("f_acting_flg", actingFlg);
        }

        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {
            string act_gubun = "1";//all = 1, no act = 2, act = 3
            if (rbxActAll.Checked) act_gubun = "1";
            else if (rbxNonAct.Checked) act_gubun = "2";
            else act_gubun = "3";

            // deleted by Cloud
            //string jundal_part_param = this.setPartParam(this.cboPart.GetDataValue());

            this.grdJaeryo.Reset();

            #region deleted by Cloud
            //            // 未実施TAB
            //            if (this.rbxNonAct.Checked)
            //            {
            //                this.grdOrder.QuerySQL = @"SELECT /* grdOrder [未実施TAB] */
            //                                               'O'  IN_OUT_GUBUN
            //                                             , A.PKOCS1003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , A.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O')
            //                                             , B.PACE_MAKER_YN
            //                                             , ''
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , E.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS1003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code  
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) E
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //                                           AND :f_io_gubun    = 'O'
            //                                           AND A.ACTING_DATE  IS NULL
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           AND A.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND E.SG_CODE (+) = D.SG_CODE
            //                                         UNION ALL
            //                                        SELECT 'I'  IN_OUT_GUBUN
            //                                             , A.PKOCS2003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME 
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , E.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(E.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','I')
            //                                             , B.PACE_MAKER_YN
            //                                             , FN_BAS_LOAD_HO_DONG_NAME(E.HO_DONG1,A.ORDER_DATE)||'/'||FN_BAS_LOAD_HO_CODE_NAME(E.HO_DONG1,E.HO_CODE1,A.ORDER_DATE)
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKINP1001   FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , F.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM INP1001 E
            //                                             , OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS2003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code  
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) F
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.DC_YN        = 'N' -- 返却されたオーダー除外
            //                                           AND A.NALSU        > 0   -- (-)オーダー除外
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //　　　　　　　　　　　　　　　　　　　　　 AND :f_io_gubun    = 'I'
            //                                           AND A.ACTING_DATE  IS NULL
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           AND E.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           AND E.PKINP1001    = A.FKINP1001
            //                                           AND E.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND F.SG_CODE (+) = D.SG_CODE
            //                                         ORDER BY ORDER_DATE, ORDER_TIME";
            //            }
            //            else if (this.rbxAct.Checked) // 実施済TAB
            //            {
            //                this.grdOrder.QuerySQL = @"SELECT /* grdOrder [実施済TAB] */
            //                                               'O'  IN_OUT_GUBUN
            //                                             , A.PKOCS1003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , A.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O')
            //                                             , B.PACE_MAKER_YN
            //                                             , ''
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , E.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS1003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code 
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) E
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //                                           AND :f_io_gubun    = 'O'
            //                                           AND A.ACTING_DATE IS NOT NULL
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)
            //                                           AND A.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND E.SG_CODE (+) = D.SG_CODE
            //                                         UNION ALL
            //                                        SELECT 'I'  IN_OUT_GUBUN
            //                                             , A.PKOCS2003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , E.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(E.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','I')
            //                                             , B.PACE_MAKER_YN
            //                                             , FN_BAS_LOAD_HO_DONG_NAME(E.HO_DONG1,A.ORDER_DATE)||'/'||FN_BAS_LOAD_HO_CODE_NAME(E.HO_DONG1,E.HO_CODE1,A.ORDER_DATE)
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKINP1001   FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , F.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM INP1001 E
            //                                             , OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS2003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code 
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) F
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.DC_YN        = 'N' -- 返却されたオーダー除外
            //                                           AND A.NALSU        > 0   -- (-)オーダー除外
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //                                           AND :f_io_gubun    = 'I'
            //                                           AND A.ACTING_DATE IS NOT NULL
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)
            //                                           AND E.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           AND E.PKINP1001    = A.FKINP1001
            //                                           AND E.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND F.SG_CODE (+) = D.SG_CODE
            //                                         ORDER BY JUBSU_DATE DESC, JUBSU_TIME DESC";
            //            }
            //            else // 全体TAB
            //            {
            //                this.grdOrder.QuerySQL = @"SELECT /* grdOrder [全体TAB] */
            //                                               'O'  IN_OUT_GUBUN
            //                                             , A.PKOCS1003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , A.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(A.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','O')
            //                                             , B.PACE_MAKER_YN
            //                                             , ''
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , E.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS1003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) E
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //                                           AND :f_io_gubun    = 'O'
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           --AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)
            //                                           AND A.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND E.SG_CODE (+) = D.SG_CODE
            //                                         UNION ALL
            //                                        SELECT 'I'  IN_OUT_GUBUN
            //                                             , A.PKOCS2003
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  ACT_YN
            //                                             , A.HANGMOG_CODE
            //                                             , D.HANGMOG_NAME
            //                                             , A.JUBSU_DATE                        JUBSU_DATE
            //                                             , A.JUBSU_TIME                        JUBSU_TIME
            //                                             , A.ACTING_DATE                       ACTING_DATE
            //                                             , A.ACTING_TIME                       ACTING_TIME
            //                                             , A.ORDER_DATE                        ORDER_DATE
            //                                             , TO_CHAR(A.SYS_DATE,'HH24MI')        ORDER_TIME
            //                                             , NVL(A.RESER_DATE, A.HOPE_DATE)	   RESER_DATE
            //                                             , A.RESER_TIME
            //                                             , A.ACT_DOCTOR
            //                                             , FN_ADM_LOAD_USER_NAME(A.ACT_DOCTOR) ACT_DOCTOR_NAME
            //                                             , A.ACT_BUSEO
            //                                             , A.ACT_GWA
            //                                             , A.BUNHO
            //                                             , B.SUNAME
            //                                             , B.SUNAME2
            //                                             , E.GWA
            //                                             , FN_BAS_LOAD_GWA_NAME(E.GWA, A.SYS_DATE)
            //                                             , A.DOCTOR
            //                                             , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, A.SYS_DATE)
            //                                             , A.ORDER_REMARK
            //                                             , B.BIRTH
            //                                             , B.SEX||'/'||FN_BAS_LOAD_AGE(SYSDATE,B.BIRTH,NULL)
            //                                             , FN_NUR_LOAD_WEIGHT_HEIGHT('H',A.BUNHO)||'/'||FN_NUR_LOAD_WEIGHT_HEIGHT('W',A.BUNHO)
            //                                             , FN_BAS_LOAD_CODE_NAME('I_O_GUBUN','I')
            //                                             , B.PACE_MAKER_YN
            //                                             , FN_BAS_LOAD_HO_DONG_NAME(E.HO_DONG1,A.ORDER_DATE)||'/'||FN_BAS_LOAD_HO_CODE_NAME(E.HO_DONG1,E.HO_CODE1,A.ORDER_DATE)
            //                                             , FN_OCS_LAST_ACT_DATE(A.JUNDAL_TABLE,A.JUNDAL_PART,A.BUNHO)
            //                                             , FN_OCS_LOAD_PATIENT_COMMENT(A.BUNHO)
            //                                             , A.JUNDAL_TABLE
            //                                             , A.JUNDAL_PART
            //                                             , A.FKINP1001   FKOUT1001
            //                                             , DECODE(A.RESER_DATE,NULL,'N','Y') RESER_YN
            //                                             , A.EMERGENCY
            //                                             , DECODE(A.ACTING_DATE,NULL,'N','Y')  OLD_ACT_YN
            //                                             , A.IF_DATA_SEND_YN
            //                                             , D.SPECIFIC_COMMENT
            //                                             , A.SORT_FKOCSKEY
            //                                             , D.INPUT_CONTROL
            //                                             , F.BUN_CODE
            //                                             , A.SURYANG
            //                                             , A.NALSU
            //                                          FROM INP1001 E
            //                                             , OCS0103 D
            //                                             , OUT0101 B
            //                                             , OCS2003 A
            //                                             , (SELECT A.SG_CODE
            //                                                     , A.BUN_CODE
            //                                                  FROM BAS0310 A
            //                                                 WHERE A.HOSP_CODE = :f_hosp_code  
            //                                                   AND A.SG_YMD    = ( SELECT MAX(Z.SG_YMD)
            //                                                                         FROM BAS0310 Z
            //                                                                        WHERE Z.HOSP_CODE  =  A.HOSP_CODE  
            //                                                                          AND Z.SG_CODE = A.SG_CODE
            //                                                                          AND Z.SG_YMD <= TRUNC(SYSDATE) )) F
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.BUNHO        = :f_bunho
            //                                           AND A.DC_YN        = 'N' -- 返却されたオーダー除外
            //                                           AND A.NALSU        > 0   -- (-)オーダー除外
            //                                           AND A.JUNDAL_TABLE = (SELECT X.MENT 
            //                                                                         FROM OCS0132 X 
            //                                                                        WHERE X.HOSP_CODE = :f_hosp_code
            //                                                                          AND X.CODE_TYPE = 'OCS_ACT_SYSTEM'
            //                                                                          AND X.CODE      = '" + cboSystem.GetDataValue() + @"')
            //                                           AND A.JUNDAL_PART  IN (" + jundal_part_param + @")
            //                                           AND :f_io_gubun    = 'I'
            //                                           AND NVL(A.ACTING_DATE, NVL(A.RESER_DATE, NVL(A.HOPE_DATE, A.ORDER_DATE))) BETWEEN :f_from_date AND :f_to_date
            //                                           --AND A.HANGMOG_CODE NOT IN (SELECT CODE FROM VW_OCS_DUMMY_ORDER_MASTER)
            //                                           AND E.GWA          = :f_gwa
            //                                           AND A.DOCTOR       = :f_doctor
            //                                           AND B.BUNHO        = A.BUNHO
            //                                           AND B.HOSP_CODE    = A.HOSP_CODE
            //                                           AND D.HANGMOG_CODE = A.HANGMOG_CODE
            //                                           AND D.HOSP_CODE    = A.HOSP_CODE
            //                                           AND E.PKINP1001    = A.FKINP1001
            //                                           AND E.HOSP_CODE    = A.HOSP_CODE
            //                                           --
            //                                           AND F.SG_CODE (+) = D.SG_CODE
            //                                         ORDER BY ORDER_DATE, ORDER_TIME";
            //            }
            #endregion

            string cboSystemVal = "";
            string jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
            switch (jundalTable)
            {
                case INJ:
                    cboSystemVal = ""; // TODO
                    break;
                case CPL:
                    cboSystemVal = "OCS_ACT_PART_04";
                    break;
                case PFE:
                    cboSystemVal = "OCS_ACT_PART_02";
                    break;
                case TST:
                    cboSystemVal = "OCS_ACT_PART_08";
                    break;
                default:
                    break;
            }

            this.grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrder.SetBindVarValue("f_io_gubun", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "in_out_gubun"));
            this.grdOrder.SetBindVarValue("f_act_gubun", act_gubun);
            this.grdOrder.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_jundal_table_code", jundalTable);
            this.grdOrder.SetBindVarValue("f_jundal_part", cboPart.GetDataValue());
            this.grdOrder.SetBindVarValue("f_bunho", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
            this.grdOrder.SetBindVarValue("f_gwa", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "gwa"));
            this.grdOrder.SetBindVarValue("f_doctor", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "doctor"));

            // updated by Cloud
            this.grdOrder.SetBindVarValue("f_cbo_system", cboSystemVal);
            this.grdOrder.SetBindVarValue("f_cbo_val", cboSystem.GetDataValue());
            this.grdOrder.SetBindVarValue("f_cbo_part", cboSystem.GetDataValue() == "PFE" ? "ENDO" : cboSystem.GetDataValue());
            //this.grdOrder.SetBindVarValue("f_system_id", EnvironInfo.CurrSystemID);
            this.grdOrder.SetBindVarValue("f_system_id", jundalTable + "S");
        }

        private void grd_QueryStarting(object sender, CancelEventArgs e)
        {
            XGrid aGrd = (XGrid)sender;

            aGrd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            switch (aGrd.Name)
            {
                case "grdJaeryo":
                    aGrd.SetBindVarValue("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                    aGrd.SetBindVarValue("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                    aGrd.SetBindVarValue("f_fkocs", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                    aGrd.SetBindVarValue("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                    aGrd.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));

                    break;
                case "grdSangByung":
                    aGrd.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                    aGrd.SetBindVarValue("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                    break;
                default:
                    break;
            }
        }

        private void grd_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid aGrd = (XEditGrid)sender;
            int aRow = e.CurrentRow;
            Cursor.Current = Cursors.WaitCursor;
            switch (aGrd.Name)
            {
                case "grdPaList":
                    //this.rbxPFE.Checked = true;
                    //this.rbxCPL.Checked = true;
                    //this.rbxTST.Checked = true;
                    // HoangVV MED-12885
                    //flag2 = false;
                    //this.rbxINJ.Checked = true;
                    //flag2 = true;
                    //=====
                    jundalTable = aGrd.GetItemString(aRow, "jundal_table");
                    string bunho = aGrd.GetItemString(aRow, "bunho");
                    string naewonDate = aGrd.GetItemString(aRow, "order_date");
                    string gwa = aGrd.GetItemString(aRow, "gwa");

                    this.patientInfoBox.Reset();
                    this.patientInfoBox.SetPatientInfo(bunho, naewonDate);
                    this.LoadExpandPatientInfo(bunho, gwa, naewonDate);
                    this.groupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo);
                    //this.cbxActor.ExecuteQuery = GetCboActor;
                    //this.cbxActor.SetDictDDLB();
                    this.SwitchTab(jundalTable);
                    this.SetTabColor(jundalTable, bunho);
                    //XMessageBox.Show(string.Format("JundalTable: {0} - Bunho: {1}", jundalTable, bunho));
                    break;
                case "grdOrder":
                    if (aGrd.GetItemString(aGrd.CurrentRowNumber, "pace_maker_yn") == "Y")
                    {
                        lbPaceMaker.ImageIndex = 14;
                        lbPaceMaker.Text = Resources.lbPaceMakerText;
                    }
                    else
                    {
                        lbPaceMaker.ImageIndex = -1;
                        lbPaceMaker.Text = "";
                    }
                    paComment.SetCommentInfo(grdOrder.GetItemString(e.CurrentRow, "bunho")
                                            , "O"
                                            , grdOrder.GetItemString(e.CurrentRow, "jundal_table")
                                            , grdOrder.GetItemString(e.CurrentRow, "jundal_part")
                                            , grdOrder.GetItemString(e.CurrentRow, "pkocs")
                                            , grdOrder.GetItemString(e.CurrentRow, "in_out_gubun")
                                            , grdOrder.GetItemString(e.CurrentRow, "hangmog_code"));
                    paComment.TabCreate();

                    // Cloud updated code START
                    //GetGrdRowFocusChanged();

                    //this.grdJaeryo.ExecuteQuery = GetGrdJaeryoForGrdRowFocusChanged;
                    //this.grdSangByung.ExecuteQuery = GetGrdSangByungForGrdRowFocusChanged;
                    this.grdJaeryo.QueryLayout(false);
                    //this.grdSangByung.QueryLayout(false);
                    //this.grdJaeryo.ExecuteQuery = GetGrdJaeryo;
                    //this.grdSangByung.ExecuteQuery = GetGrdSangByung;
                    // Cloud updated code END

                    for (int i = 0; i < tabControl.TabPages.Count; i++)
                    {
                        tabControl.TabPages[i].TitleTextColor = SystemColors.ControlText;
                    }

                    if (grdOrder.RowCount > 0)
                    {
                        tabControl.TabPages[0].TitleTextColor = System.Drawing.Color.Maroon;
                    }
                    if (grdSangByung.RowCount > 0)
                    {
                        tabControl.TabPages[1].TitleTextColor = System.Drawing.Color.Maroon;
                    }
                    if (!TypeCheck.IsNull(grdOrder.GetItemString(e.CurrentRow, "order_remark")))
                    {
                        tabControl.TabPages[2].TitleTextColor = System.Drawing.Color.Maroon;
                    }
                    if (!TypeCheck.IsNull(grdOrder.GetItemString(e.CurrentRow, "unusual_info")))
                    {
                        tabControl.TabPages[3].TitleTextColor = System.Drawing.Color.Maroon;
                    }

                    //DEFAULT SET HANGMOG CODE INSERT
                    if (grdOrder.RowCount > 0 && grdJaeryo.RowCount == 0)
                    {
                        defaultJearyo.SetBindVarValue("f_hangmog_code", grdOrder.GetItemString(e.CurrentRow, "hangmog_code"));

                        defaultJearyo.QueryLayout(true);

                        if (defaultJearyo.RowCount > 0)
                        {
                            for (int i = 0; i < defaultJearyo.RowCount; i++)
                            {
                                grdJaeryo.InsertRow();
                                //grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "hangmog_code", defaultJearyo.GetItemString(i, "hangmog_code"));
                                grdJaeryo.SetFocusToItem(grdJaeryo.CurrentRowNumber, "hangmog_code");
                                grdJaeryo.SetEditorValue(defaultJearyo.GetItemString(i, "hangmog_code"));

                                grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "suryang", defaultJearyo.GetItemString(i, "suryang"));

                                grdJaeryo.AcceptData();
                                //grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "ord_danui", defaultJearyo.GetItemString(i, "ord_danui"));
                                //grdJaeryo.SetFocusToItem(grdJaeryo.CurrentRowNumber, "ord_danui");
                                //grdJaeryo.SetEditorValue(defaultJearyo.GetItemString(i, "ord_danui"));
                            }
                        }
                    }

                    // 実施済TABのみ
                    if (this.rbxAct.Checked)
                    {
                        // 心電図のグロバール変数セット
                        this.i_pkocs = this.grdOrder.GetItemString(e.CurrentRow, "pkocs");
                        this.i_order_date = this.grdOrder.GetItemString(e.CurrentRow, "order_date");
                        this.i_bunho = this.grdOrder.GetItemString(e.CurrentRow, "bunho");
                        this.i_fkout1001 = this.grdOrder.GetItemString(e.CurrentRow, "fkout1001");

                        // 実施者をセットする。
                        // https://sofiamedix.atlassian.net/browse/MED-14836
                        this.dbxDocCode.SetDataValue(this.grdOrder.GetItemString(e.CurrentRow, "act_doctor"));
                        this.dbxDocName.SetDataValue(this.grdOrder.GetItemString(e.CurrentRow, "act_doctor_name"));
                    }

                    //string act_doctor_name = this.grdOrder.GetItemString(e.CurrentRow, "act_doctor_name");
                    //if (act_doctor_name.Equals(""))
                    //    // 実施者に 現在ログインしている IDを セットする｡
                    //    this.cbxActor.SetDataValue(UserInfo.UserID);
                    //else
                    //    // 実施者をセットする。
                    //    this.cbxActor.Text = this.grdOrder.GetItemString(e.CurrentRow, "act_doctor_name");

                    this.newOcsKey = this.grdOrder.GetItemString(e.CurrentRow, "pkocs");

                    //if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "ENDO")
                    //{
                    //    btnReportViewer.Visible = true;
                    //    this.btnReportViewer.Location = new System.Drawing.Point(665, 4);
                    //}
                    //else if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_table") == "XRT")
                    //{
                    //    btnReportViewer.Visible = false;
                    //    this.btnReportViewer.Location = new System.Drawing.Point(665, 4);
                    //}
                    //else if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "EKG")
                    //{
                    //    btnReportViewer.Visible = true;
                    //    this.btnReportViewer.Location = new System.Drawing.Point(564, 4);
                    //}
                    //else
                    //{
                    //    btnReportViewer.Visible = false;
                    //    this.btnReportViewer.Location = new System.Drawing.Point(665, 4);
                    //}

                    break;
                default:
                    break;
            }
            Cursor.Current = Cursors.Default;
            if (aGrd == null || aGrd.CurrentRowNumber < 0 || !aGrd.CellInfos.Contains("hangmog_code")) return;

            // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
            this.mHangmogInfo.DisplaySpecialColHeader(aGrd.GetItemString(aRow, "in_out_gubun"), aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());
            
        }

        private void cboPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.grdPaList.QueryLayout(false);
        }

        private void btnReportViewer_Click(object sender, EventArgs e)
        {
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "ENDO")
            {
                string targetUrl = "";
                string serverIP = "192.168.150.114";

                #region deleted by Cloud
                //                string cmdText = @"SELECT CODE_NAME
                //                                 FROM OCS0132
                //                                WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                //                                  AND CODE_TYPE = 'SERVER_IP'
                //                                  AND CODE = '" + grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") + "'";
                //                object retVal = Service.ExecuteScalar(cmdText);
                #endregion

                string bunho = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");

                // deleted by Cloud
                //if (!TypeCheck.IsNull(retVal))
                //{
                //    serverIP = retVal.ToString();
                //}

                // Cloud updated code START
                OCSACTBtnReportViewerClickArgs args = new OCSACTBtnReportViewerClickArgs();
                args.JundalPart = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part");
                OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTBtnReportViewerClickArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    serverIP = res.ResponseStr;
                }
                // Cloud updated code END

                try
                {
                    targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + bunho + "&TYPE=1&KEY=12345";

                    System.Diagnostics.Process.Start(targetUrl);
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //MessageBox.Show("browser msg : " + noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //MessageBox.Show("other msg : " + other.Message);
                }
            }
            else if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "EKG")
            {
                string bunho = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");
                EkgCallHelper.CallViewer(bunho);
            }
        }

        private void cbxActor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (rbxINJ.Checked)
            {
                this.inj1001U01.Actor = dbxDocCode.GetDataValue();
                this.inj1001U01.ActorName = dbxDocName.Text;
                this.inj1001U01.AutoSetActor();
            }
            if (rbxCPL.Checked)
            {
                this.cpl2010U00.CbxActor.SetDataValue(dbxDocCode.GetDataValue());
            }
            //for (int i = 0; i < this.grdOrder.RowCount; i++)
            //{
            //    this.grdOrder.SetItemValue(i, "act_doctor", this.cbxActor.GetDataValue());
            //    this.grdOrder.SetItemValue(i, "act_doctor_name", this.cbxActor.Text);
            //}
        }

        private void btnJaeryo_Click(object sender, EventArgs e)
        {
            if (grdOrder.RowCount == 0) return;
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("set_table", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_table"));
            openParams.Add("set_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
            openParams.Add("hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0311Q00", ScreenOpenStyle.PopupSingleFixed, openParams);


        }

        private void grdJaeryo_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            if (sender == null || ((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

            string hangmog_code = grd.GetItemString(e.RowNumber, "hangmog_code"); // 항목코드

            switch (e.ColName)
            {
                case "hangmog_code": // 항목코드
                    e.Cancel = true;  // Find 장 안띄움

                    CommonItemCollection openParams = new CommonItemCollection();
                    //값을 넘겨서 조회하고자 한다면 hangmog_code item에 값을 넣어보낸다.
                    openParams.Add("hangmog_code", ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());
                    // Multi 선택여부 (default : MultiSelect )
                    openParams.Add("multiSelect", true);
                    // child 여부 ( default : % )
                    //openParams.Add("child_yn", "Y");
                    //항목조회화면 Open
                    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseSizable, openParams);

                    break;
                case "ord_danui":
                case "ord_danui_name":  // 처방단위(항목코드별)
                    ((XFindBox)((XEditGridCell)grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker = GetFindWorker(e.ColName, hangmog_code);

                    break;
                default:
                    break;
            }
        }

        private void grdJaeryo_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            grd.AcceptData();

            if (e.ColName == "ord_danui_name")
            {
                grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "ord_danui", e.ReturnValues[0].ToString());
                grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "ord_danui_name", e.ReturnValues[1].ToString());
            }
        }

        private void btnEMR_Click(object sender, EventArgs e)
        {
            string naewonKey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkout1001");
            string naewonDate = mSysDate.ToString("yyyy/MM/dd");
            //string cmdText = @"SELECT TO_CHAR(NAEWON_DATE,'YYYY/MM/DD') FROM OUT1001 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKOUT1001 = '" + naewonKey + "'";

            //object retVal = Service.ExecuteScalar(cmdText);
            //if (!TypeCheck.IsNull(retVal))
            //{
            //    naewonDate = retVal.ToString();
            //}

            // updated by Cloud
            OCSACTBtnEMRClickArgs args = new OCSACTBtnEMRClickArgs();
            args.NaewonKey = naewonKey;
            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTBtnEMRClickArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (!TypeCheck.IsNull(res.ResponseStr))
                {
                    naewonDate = res.ResponseStr;
                }
            }

            EMRIOTGubun IOGubun = EMRIOTGubun.OUT;

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "O")
            {
                IOGubun = EMRIOTGubun.OUT;
            }
            else
            {
                IOGubun = EMRIOTGubun.IN;
            }
            EMRHelper.ExecuteEMR(IOGubun, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"), naewonDate, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "gwa"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "doctor"), naewonKey);
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (grdOrder.RowCount == 0) return;
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "specific_comment") == "") return;
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("doctor", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "doctor"));
            openParams.Add("bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
            openParams.Add("order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
            openParams.Add("pkocskey", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
            openParams.Add("in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
            openParams.Add("hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));
            openParams.Add("isReadOnly", "Y");
            openParams.Add("gwa", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "gwa"));
            openParams.Add("naewon_key", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkout1001"));
            openParams.Add("jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "ENDO")
                XScreen.OpenScreenWithParam(this, "PFES", "END1000U02", ScreenOpenStyle.ResponseFixed, openParams);

            if (cboSystem.GetDataValue() == "OCS_ACT_PART_01")
                XScreen.OpenScreenWithParam(this, "XRTS", "XRT1002U00", ScreenOpenStyle.ResponseFixed, openParams);
            else
            {
                if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "OP")
                    XScreen.OpenScreenWithParam(this, "OPRS", "END1000U02", ScreenOpenStyle.ResponseFixed, openParams);
                if (this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "NUT")
                    this.OpenScreenNUT();
            }
        }

        private void btnReSendIF_Click(object sender, EventArgs e)
        {
            // 実施タブではない場合、リターンする。
            if (!this.rbxAct.Checked) return;

            if (this.grdOrder.RowCount < 1) return;

            string actYN = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn");
            string userID = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_doctor");

            // 実施チェック、又は実施者がないとリターンする。
            if (actYN.Equals("N") || userID.Equals(""))
            {
                XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_Caption3, MessageBoxIcon.Information);
                return;
            }

            string code = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_code");
            string name = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_name");

            if (XMessageBox.Show("[" + code + "] : " + name + " " + Resources.XMessageBox9, Resources.XMessageBox_caption2, MessageBoxButtons.YesNo) == DialogResult.Yes) this.reSendIF(userID);
            else return;
        }

        private void btnReserViewer_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            if (grdOrder.RowCount > 0)
            {
                if (!TypeCheck.IsNull(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code")))
                {
                    openParams.Add("hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));
                }
            }

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "ENDO")
                openParams.Add("jundal_table", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
            else
            {
                //string cmdStr = @"SELECT MENT FROM OCS0132 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND CODE_TYPE = 'OCS_ACT_SYSTEM' AND CODE = '" + cboSystem.GetDataValue() + "'";

                //object retVal = Service.ExecuteScalar(cmdStr);

                //if (!TypeCheck.IsNull(retVal))
                //{
                //    openParams.Add("jundal_table", retVal.ToString());
                //}

                // Updated by Cloud
                OCSACTBtnReserViewerClickArgs args = new OCSACTBtnReserViewerClickArgs();
                args.Code = cboSystem.GetDataValue();
                OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTBtnReserViewerClickArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (!TypeCheck.IsNull(res.ResponseStr))
                    {
                        openParams.Add("jundal_table", res.ResponseStr);
                    }
                }
            }

            XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void grdJaeryo_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid aGrd = sender as XEditGrid;
            int aRow = e.RowNumber;

            if (e.ColName == "hangmog_code")
            {
                #region deleted by Cloud
                //                string cmdStr = @"SELECT B.HANGMOG_NAME
                //                                       , A.SURYANG
                //                                       , NVL(A.DANUI,B.ORD_DANUI) DANUI
                //                                       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',NVL(A.DANUI,B.ORD_DANUI))         DANUI_NAME
                //                                       , D.BUN_CODE
                //                                       , B.INPUT_CONTROL
                //                                    FROM OCS0313 A
                //                                       , OCS0103 B
                //                                       , ( SELECT X.SG_CODE
                //                                                , X.SG_NAME
                //                                                , X.SG_YMD
                //                                                , X.BULYONG_YMD 
                //                                                , X.BUN_CODE
                //                                             FROM BAS0310 X
                //                                            WHERE X.HOSP_CODE = :f_hosp_code
                //                                              AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                //                                                                FROM BAS0310 Z
                //                                                               WHERE Z.HOSP_CODE = X.HOSP_CODE
                //                                                                 AND Z.SG_CODE   = X.SG_CODE 
                //                                                                 AND Z.SG_YMD   <= TRUNC(SYSDATE) )
                //                                         ) D
                //                                   WHERE A.HOSP_CODE        = :f_hosp_code
                //                                     AND A.HANGMOG_CODE     = :f_hangmog_code
                //                                     AND A.SET_HANGMOG_CODE = :f_set_hangmog_code
                //                                     AND B.HOSP_CODE        = A.HOSP_CODE
                //                                     AND B.HANGMOG_CODE     = A.SET_HANGMOG_CODE
                //                                     AND SYSDATE BETWEEN B.START_DATE 
                //                                                     AND B.END_DATE 
                //                                     --
                //                                     AND D.SG_CODE  (+) = B.SG_CODE
                //                                     
                //                                     ";

                //                BindVarCollection bindVar = new BindVarCollection();
                //                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                //                bindVar.Add("f_hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));
                //                bindVar.Add("f_set_hangmog_code", aGrd.GetItemString(aRow, "hangmog_code"));

                //                DataTable dtTable = Service.ExecuteDataTable(cmdStr, bindVar);

                //                if (!TypeCheck.IsNull(dtTable) && dtTable.Rows.Count > 0)
                //                {
                //                    this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", dtTable.Rows[0]["hangmog_name"]);

                //                    if (this.grdJaeryo.GetItemString(e.RowNumber, "input_control") != "3")
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", dtTable.Rows[0]["suryang"]);

                //                    this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", dtTable.Rows[0]["danui"]);
                //                    this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", dtTable.Rows[0]["danui_name"]);
                //                    this.grdJaeryo.SetItemValue(e.RowNumber, "input_control", dtTable.Rows[0]["input_control"].ToString());
                //                    this.grdJaeryo.SetItemValue(e.RowNumber, "bun_code", dtTable.Rows[0]["bun_code"].ToString());
                //                }
                //                else
                //                {
                //                    cmdStr = @"SELECT HANGMOG_NAME 
                //                                    , '1'          SURYANG
                //                                    , ORD_DANUI    DANUI
                //                                    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',ORD_DANUI)   DANUI_NAME
                //                                    , D.BUN_CODE
                //                                    , A.INPUT_CONTROL
                //                                 FROM OCS0103 A
                //                                    , ( SELECT X.SG_CODE
                //                                             , X.SG_NAME
                //                                             , X.SG_YMD
                //                                             , X.BULYONG_YMD 
                //                                             , X.BUN_CODE
                //                                          FROM BAS0310 X
                //                                         WHERE X.HOSP_CODE = :f_hosp_code
                //                                           AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                //                                                              FROM BAS0310 Z
                //                                                             WHERE Z.HOSP_CODE = X.HOSP_CODE
                //                                                               AND Z.SG_CODE   = X.SG_CODE 
                //                                                               AND Z.SG_YMD   <= TRUNC(SYSDATE) )
                //                                      ) D
                //                                WHERE A.HOSP_CODE        = :f_hosp_code
                //                                  AND A.HANGMOG_CODE     = :f_hangmog_code
                //                                  AND NVL(A.IF_INPUT_CONTROL, 'C') <> 'P'
                //                                  AND SYSDATE BETWEEN A.START_DATE 
                //                                                  AND A.END_DATE 
                //                                  --
                //                                  AND D.SG_CODE  (+) = A.SG_CODE
                //                                  ";

                //                    bindVar.Clear();
                //                    bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                //                    bindVar.Add("f_hangmog_code", aGrd.GetItemString(aRow, "hangmog_code"));

                //                    dtTable.Reset();

                //                    dtTable = Service.ExecuteDataTable(cmdStr, bindVar);

                //                    if (!TypeCheck.IsNull(dtTable) && dtTable.Rows.Count > 0)
                //                    {
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", dtTable.Rows[0]["hangmog_name"]);

                //                        if (this.grdJaeryo.GetItemString(e.RowNumber, "input_control") != "3")
                //                            this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", dtTable.Rows[0]["suryang"]);

                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", dtTable.Rows[0]["danui"]);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", dtTable.Rows[0]["danui_name"]);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "input_control", dtTable.Rows[0]["input_control"].ToString());
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "bun_code", dtTable.Rows[0]["bun_code"].ToString());
                //                    }
                //                    else
                //                    {
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_code", DBNull.Value);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", DBNull.Value);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", DBNull.Value);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", DBNull.Value);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", DBNull.Value);
                //                        this.grdJaeryo.SetItemValue(e.RowNumber, "nalsu", DBNull.Value);
                //                        SetMsg(XMsg.GetMsg("M005") + "[" + aGrd.GetItemString(aRow, "hangmog_code") + "]", MsgType.Error);
                //                    }

                //                }
                #endregion

                #region updated by Cloud
                OCSACTGrdJaeryoGridColumnChangedArgs args = new OCSACTGrdJaeryoGridColumnChangedArgs();
                args.HangmogCode1 = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code");
                args.HangmogCode2 = aGrd.GetItemString(aRow, "hangmog_code");
                args.SetHangmogCode = aGrd.GetItemString(aRow, "hangmog_code");
                OCSACTGrdJaeryoGridColumnChangedResult res = CloudService.Instance.Submit<OCSACTGrdJaeryoGridColumnChangedResult,
                    OCSACTGrdJaeryoGridColumnChangedArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (res.Dt1Item.Count > 0)
                    {
                        this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", res.Dt1Item[0].HangmogName);

                        if (this.grdJaeryo.GetItemString(e.RowNumber, "input_control") != "3")
                            this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", res.Dt1Item[0].Suryang);

                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", res.Dt1Item[0].Danui);
                        this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", res.Dt1Item[0].DanuiName);
                        this.grdJaeryo.SetItemValue(e.RowNumber, "input_control", res.Dt1Item[0].InputControl);
                        this.grdJaeryo.SetItemValue(e.RowNumber, "bun_code", res.Dt1Item[0].BunCode);
                    }
                    else
                    {
                        if (res.Dt2Item.Count > 0)
                        {
                            this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", res.Dt2Item[0].HangmogName);

                            if (this.grdJaeryo.GetItemString(e.RowNumber, "input_control") != "3")
                                this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", res.Dt2Item[0].Suryang);

                            this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", res.Dt2Item[0].Danui);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", res.Dt2Item[0].DanuiName);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "input_control", res.Dt2Item[0].InputControl);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "bun_code", res.Dt2Item[0].BunCode);
                        }
                        else
                        {
                            this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_code", DBNull.Value);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", DBNull.Value);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "suryang", DBNull.Value);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", DBNull.Value);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", DBNull.Value);
                            this.grdJaeryo.SetItemValue(e.RowNumber, "nalsu", DBNull.Value);
                            SetMsg(XMsg.GetMsg("M005") + "[" + aGrd.GetItemString(aRow, "hangmog_code") + "]", MsgType.Error);
                        }
                    }
                }
                #endregion

                this.GetInputTime(this, this.grdJaeryo);

                if (aGrd == null || aGrd.CurrentRowNumber < 0 || !aGrd.CellInfos.Contains("hangmog_code")) return;
                this.mHangmogInfo.DisplaySpecialColHeader(aGrd.GetItemString(aRow, "in_out_gubun"), aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());

            }

        }

        private void grdPaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            // Simple version
            this.rbxINJ.Enabled = grdPaList.RowCount > 0;
            this.rbxCPL.Enabled = grdPaList.RowCount > 0;
            this.rbxPFE.Enabled = grdPaList.RowCount > 0;
            this.rbxTST.Enabled = grdPaList.RowCount > 0;

            SetGrdHeaderImage(grdPaList);

            this.QueryTime = TimeVal;

            // 画面のALARMが活性の場合
            if (this.rbxNonAct.Checked && this.useAlarmChkYN.Equals("Y"))
            {
                if (this.grdPaList.RowCount > 0)
                {
                    for (int i = 0; i < grdPaList.RowCount; i++)
                    {
                        // 予約患者の場合は音無
                        if (this.grdPaList.GetItemString(i, "reser_yn").Equals("N"))
                        {
                            this.playAlarm("PFE");
                        }
                    }
                }
            }
        }

        private void SetGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPaList")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                {
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;
                }

                if (grid.GetItemString(e.RowNumber, "emergency") == "Y")
                {
                    e.BackColor = Color.Pink;
                }
            }

            if (grid.Name == "grdOrder")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                {
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;
                }

                if (grid.GetItemString(e.RowNumber, "emergency") == "Y")
                {
                    e.BackColor = Color.Pink;
                }

                if (grid.GetItemString(e.RowNumber, "act_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    //e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;
                    //e.BackColor = (XColor.DockingGradientStartColor).Color;
                    //e.BackColor = (XColor.XRotatorGradientStartColor).Color;
                    //e.ForeColor = (XColor.XRotatorGradientStartColor).Color;
                    e.ForeColor = Color.Blue;
                    //e.Font = new Font("MS UI Gothic", 9.75f, FontStyle.Bold);
                }

                if (grid.GetItemString(grid.CurrentRowNumber, "if_data_send_yn") == "Y")
                {
                    //string msg = (NetInfo.Language == LangMode.Ko ? "이미 회계에 전달이 되었습니다. 회계파트에 연락해 주세요"
                    //: "既に会計済みですので、会計の方に問い合わせください。");
                    //XMessageBox.Show(msg, "確認", MessageBoxIcon.Stop);
                    e.ForeColor = Color.Red;
                }

            }
        }

        private void grdPaList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
            if (e.DataRow["trial"].ToString() == "Y")
            {
                grdPaList[e.RowNumber + 1, 6].ToolTipText = Resources.MSG_001;
            }
            if (e.DataRow["trial"].ToString() == "N")
            {
                grdPaList[e.RowNumber + 1, 6].ToolTipText = " ";
            }
        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
        }

        private void tabControl_SelectionChanged(object sender, EventArgs e)
        {
            if (((XTabControl)sender).SelectedIndex != 3)
            {
                this.CurrMQLayout = this.grdJaeryo;
            }
            else
            {
                this.paComment.Focus();
            }
        }

        private void grdJaeryo_Validating(object sender, CancelEventArgs e)
        {
            XEditGrid grd = (XEditGrid)sender;
        }

        private void paBox_Validated(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
            lbSuname.Text = paBox.SuName;
        }

        private void grdOrder_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            //if (e.ColName == "act_doctor_name")
            //{
            //    string userID = e.ChangeValue.ToString();

            //    this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", userID);
            //}

            if (e.ColName == "act_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    if (this.rbxNonAct.Checked) //未実施TABのみ設定
                    {
                        if (this.dbxDocCode.GetDataValue().Equals(""))
                        {
                            XMessageBox.Show(Resources.MSG_REQ_DOCTOR, Resources.CAP_REQ_DOCTOR, MessageBoxIcon.Information);
                            this.grdOrder.SetItemValue(e.RowNumber, "act_yn", "N");
                            return;
                        }

                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (i != e.RowNumber && this.grdOrder.GetItemString(i, "act_yn").Equals("Y"))
                            {
                                string code = this.grdOrder.GetItemString(i, "hangmog_code");

                                XMessageBox.Show(Resources.XMessageBox10 + code + Resources.XMessageBox11, Resources.XMessageBox_Caption10, MessageBoxIcon.Information);
                                this.grdOrder.SetItemValue(e.RowNumber, "act_yn", "N");
                                //MED-10070
                                this.grdOrder.QueryLayout(false);

                                this.grdOrder.SetItemValue(i, "act_yn", "Y");

                                this.grdOrder.SetItemValue(i, "jubsu_date", mSysDate);
                                this.grdOrder.SetItemValue(i, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

                                this.grdOrder.SetItemValue(i, "acting_date", mSysDate);
                                this.grdOrder.SetItemValue(i, "acting_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                                this.grdOrder.SetItemValue(i, "act_yn", e.ChangeValue.ToString());

                                this.grdOrder.SetItemValue(i, "act_doctor", this.dbxDocCode.GetDataValue());
                                this.grdOrder.SetItemValue(i, "act_doctor_name", this.dbxDocName.Text);
                                return;
                            }
                        }

                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_date", mSysDate);
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

                        this.grdOrder.SetItemValue(e.RowNumber, "acting_date", mSysDate);
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                        this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());

                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", this.dbxDocCode.GetDataValue());
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", this.dbxDocName.Text);

                        if (this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "NUT")
                            this.OpenScreenNUT();

                        DataRow dtRow = this.grdOrder.LayoutTable.Rows[e.RowNumber];

                        if (dtRow["input_control"].ToString() == "3")
                        {
                            //this.GetInputTime(this, dtRow);
                            this.GetInputTime(this, this.grdOrder);
                        }
                    }
                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                    if (this.rbxAct.Checked)
                    {
                        //btnList.SetEnabled(FunctionType.Insert, true);
                        btnJaeryo.Enabled = true;
                    }
                }
                else
                {
                    if (this.rbxNonAct.Checked) //未実施TABのみ設定
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_date", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time", "");

                        this.grdOrder.SetItemValue(e.RowNumber, "acting_date", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_time", "");

                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());

                    //実施TAB
                    if (this.rbxAct.Checked)
                    {

                        //btnList.SetEnabled(FunctionType.Insert, false);
                        btnJaeryo.Enabled = false;
                        DataRowState drState = DataRowState.Unchanged;

                        for (int i = 0; i < grdJaeryo.RowCount; i++)
                        {
                            if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                            {
                                drState = grdJaeryo.GetRowState(i);
                                break;
                            }
                        }
                        // 完了TABで、一行ずつのみ処理　→　現在行以外に実施チェックが外れていたらリターンする。
                        if (drState != DataRowState.Unchanged)
                        {
                            XMessageBox.Show(Resources.XMessageBox17, "", MessageBoxIcon.Information);
                            grdJaeryo.QueryLayout(true);
                        }
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (i != e.RowNumber && this.grdOrder.GetItemString(i, "act_yn").Equals("N"))
                            {
                                string code = this.grdOrder.GetItemString(i, "hangmog_code");

                                XMessageBox.Show(Resources.XMessageBox12 + code + Resources.XMessageBox13, Resources.XMessageBox_Caption12, MessageBoxIcon.Information);
                                this.grdOrder.SetItemValue(e.RowNumber, "act_yn", "Y");
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void grdOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SetGrdHeaderImage(grdOrder);
        }

        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "order_remark" && e.DataRow["old_act_yn"].ToString() == "Y")
                e.Protect = true;

            #region deleted by Cloud
            //string strCmd = "";
            //BindVarCollection bindVar = new BindVarCollection();

            //bindVar.Add("f_pkocs", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));

            //if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "O") //외래
            //{
            //    strCmd = @"select if_data_send_yn from ocs1003 where pkocs1003 = :f_pkocs";
            //}
            //else
            //{
            //    strCmd = @"select if_data_send_yn from ocs2003 where pkocs2003 = :f_pkocs";
            //}
            //object result = Service.ExecuteScalar(strCmd, bindVar);
            #endregion

            // updated by Cloud
            string result = string.Empty;
            OCSACTGrdOrderGridColumnProtectModifyArgs args = new OCSACTGrdOrderGridColumnProtectModifyArgs();
            args.InOutGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
            args.Pkocs = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs");
            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult,
                OCSACTGrdOrderGridColumnProtectModifyArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                result = res.ResponseStr;
            }
            // Update logic VN hospital
            if (NetInfo.Language == LangMode.Jr)
            {
                // 実施チェックの制御
                if (e.ColName.Equals("act_yn") && result/*.ToString()*/ == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    e.Protect = true;
                }
            }
            if ((e.ColName == "nalsu" || e.ColName == "suryang") && !this.grdOrder.CellInfos[e.ColName].IsReadOnly)
            {
                this.GetInputTime(this, this.grdOrder);
            }
        }

        private void grdOrder_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            DataRowState drState = DataRowState.Unchanged;

            for (int i = 0; i < grdJaeryo.RowCount; i++)
            {
                if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                {
                    drState = grdJaeryo.GetRowState(i);
                    break;
                }
            }

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") == "Y")
            {
                if ((drState != DataRowState.Unchanged) || (grdJaeryo.DeletedRowCount > 0))
                {
                    string msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox13_Ko
                    : Resources.XMessageBox13_JP);
                    if (XMessageBox.Show(msg, Resources.XMessageBox_caption2, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        msg = (NetInfo.Language == LangMode.Ko ? Resources.XMessageBox14_Ko
                    : Resources.XMessageBox14_JP);
                        btnList.PerformClick(FunctionType.Update);
                    }
                }
            }
        }

        private void grdOrder_GridMemoFormShowing(object sender, GridMemoFormShowingEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            CommonItemCollection loadParams;

            switch (e.ColName)
            {
                case "order_remark":

                    loadParams = new CommonItemCollection();
                    loadParams.Add("jundal_part", cboSystem.SelectedValue); //부문별 코멘트
                    grd.SetReservedMemoControlLoadParam(e.ColName, loadParams);
                    //MessageBox.Show(loadParams["jundal_part"].ToString() + "    OCSACT2 ");
                    break;
            }
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string input_id = this.grdOrder.GetItemString(e.RowNumber, "act_doctor_name");

            switch (e.ColName)
            {
                case "act_doctor_name":

                    #region deleted by Cloud
                    //                    SingleLayout ocsCommon = new SingleLayout();
                    //                    ocsCommon.QuerySQL = @"SELECT USER_NM
                    //                                             FROM ADM3200
                    //                                            WHERE HOSP_CODE   = :f_hosp_code
                    //                                              --AND USER_GROUP  = :f_group_code
                    //                                              AND USER_ID     = :f_user_id";

                    //                    ocsCommon.LayoutItems.Add("user_nm");
                    //                    ocsCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    //                    ocsCommon.SetBindVarValue("f_user_id", input_id);

                    //                    if (ocsCommon.QueryLayout())
                    //                    {
                    //                        if (ocsCommon.GetItemValue("user_nm").ToString() != "")
                    //                        {
                    //                            //this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", ocsCommon.GetItemValue("user_nm").ToString());
                    //                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", input_id);
                    //                        }
                    //                        else
                    //                        {
                    //                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                    //                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                    //                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                    //                    }
                    #endregion

                    #region updated by Cloud
                    OCSACTGrdOrderGridColumnChangedArgs args = new OCSACTGrdOrderGridColumnChangedArgs();
                    args.UserId = input_id;
                    OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult,
                        OCSACTGrdOrderGridColumnChangedArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (!TypeCheck.IsNull(res.ResponseStr))
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", input_id);
                        }
                        else
                        {
                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                        }
                    }
                    else
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                    }
                    #endregion

                    break;
            }
        }

        private void btnIfEkg_Click(object sender, EventArgs e)
        {
            // 心電図検査の場合、連携電文を生成する。
            if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jundal_part") == "EKG")
            {
                bool value = this.procEkgInterface();

                if (value == false)
                {
                    throw new Exception();
                }
            }
            else
            {
                XMessageBox.Show(Resources.XMessageBox15, Resources.XMessageBox15_Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void grdJaeryo_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid aGrd = sender as XEditGrid;
            int aRow = e.CurrentRow;

            if (aGrd == null || aGrd.CurrentRowNumber < 0 || !aGrd.CellInfos.Contains("hangmog_code")) return;

            // 상태에 따른 필드헤더변경 (수량/날수 (마취처방코드인 경우 시간/분으로 표시), 부수술 (체감인경우 체감))
            this.mHangmogInfo.DisplaySpecialColHeader(aGrd.GetItemString(aRow, "in_out_gubun"), aGrd, aRow, aGrd.GetItemString(aRow, "hangmog_code").Trim());
        }

        private void grdJaeryo_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "nalsu")
            {
                if (e.DataRow["input_control"].ToString() != "3")
                {
                    e.Protect = true;
                }
            }

            #region deleted by Cloud
            //            string strCmd = "";
            //            BindVarCollection bindVar = new BindVarCollection();

            //            bindVar.Add("f_pkocs", grdJaeryo.GetItemString(grdJaeryo.CurrentRowNumber, "pkocs"));

            //            if (grdJaeryo.GetItemString(grdJaeryo.CurrentRowNumber, "in_out_gubun") == "O") //외래
            //            {
            //                strCmd = @"SELECT NVL(A.IF_DATA_SEND_YN , 'N') IF_DATA_SEND_YN 
            //                             FROM OCS1003 A
            //                            WHERE A.PKOCS1003 = :f_pkocs";
            //            }
            //            else
            //            {
            //                strCmd = @"SELECT NVL(A.IF_DATA_SEND_YN , 'N') IF_DATA_SEND_YN
            //                             FROM OCS2003 A
            //                            WHERE A.PKOCS2003 = :f_pkocs";
            //            }
            //            object result = Service.ExecuteScalar(strCmd, bindVar);
            #endregion

            #region updated by Cloud
            string result = string.Empty;

            OCSACTGrdJaeryoGridColumnProtectModifyArgs args = new OCSACTGrdJaeryoGridColumnProtectModifyArgs();
            args.InOutGubun = grdJaeryo.GetItemString(grdJaeryo.CurrentRowNumber, "in_out_gubun");
            args.Pkocs = grdJaeryo.GetItemString(grdJaeryo.CurrentRowNumber, "pkocs");
            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult,
                OCSACTGrdJaeryoGridColumnProtectModifyArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                result = res.ResponseStr;
            }
            #endregion


            // Update logic Vn Hospital
            if (NetInfo.Language == LangMode.Jr)
            {
                // 実施チェックの制御
                if (/*result != null &&*/ result/*.ToString()*/ == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    e.Protect = true;
                }
            }
            if ((e.ColName == "nalsu" || e.ColName == "suryang") && !this.grdJaeryo.CellInfos[e.ColName].IsReadOnly && !e.Protect)
            {
                this.GetInputTime(this, this.grdJaeryo);
            }

        }

        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {
            //XEditGrid grd = sender as XEditGrid;
            //int currRow = grd.GetHitRowNumber(e.Y);

            //switch (grd.CurrentColName)
            //{
            //    case "suryang":
            //    case "nalsu":
            //        grd.LayoutTable.Rows[currRow][grd.CurrentColName]
            //        grd
            //        break;

            //}
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {

        }

        #endregion

        #region Methods(private)

        private void postopen()
        {
            //this.tabControl.SelectedTab = this.tabControl.TabPages[0];
           
            this.btnList.PerformClick(FunctionType.Query);
            //done first load
            this.isFirstLoad = false;
        }

        private void PostLoad()
        {
            string btn_autoQuery_yn = string.Empty;
            string btn_autoAlarm_yn = string.Empty;
            string ekgIFYN = string.Empty;


            // 注射画面コントロールデータ照会
            //            this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
            //                                                 FROM PFE0102
            //                                                WHERE HOSP_CODE = :f_hosp_code
            //                                                  AND CODE_TYPE = 'PFE_CONSTANT'
            //                                                ORDER BY CODE";

            // updated by Cloud
            mlayConstantInfo.ExecuteQuery = GetMlayConstantConst;

            //this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

            if (this.mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");

                    // 心電図自動連携可否
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("ekgIFYN")) ekgIFYN = this.mlayConstantInfo.GetItemString(i, "code_value");
                }

                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        //                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                        //                                                 FROM PFE0102
                        //                                                WHERE HOSP_CODE = :f_hosp_code
                        //                                                  AND CODE_TYPE = 'PFE_ALARM'
                        //                                                ORDER BY CODE";

                        // updated by Cloud
                        this.mlayConstantInfo.ExecuteQuery = GetMlayConstantAlarm;

                        //this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("PFE")) this.alarmFilePath_PFE = this.mlayConstantInfo.GetItemString(k, "code_value");
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("PFE_EM")) this.alarmFilePath_PFE_EM = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }
            }

            // 自動照会
            if (btn_autoQuery_yn.Equals("Y"))
            {
                this.useTimeChkYN = "Y";
                this.btnUseTimeChk.ImageIndex = 1;

                this.timer1.Start();
                this.cboTime.Enabled = true;
            }
            else
            {
                this.useTimeChkYN = "N";
                this.btnUseTimeChk.ImageIndex = 0;

                this.cboTime.Enabled = false;
                this.timer1.Stop();
            }

            // 患者有Alarm
            if (btn_autoAlarm_yn.Equals("Y"))
            {
                this.useAlarmChkYN = "Y";
                this.btnUseAlarmChk.ImageIndex = 1;
            }
            else
            {
                this.useAlarmChkYN = "N";
                this.btnUseAlarmChk.ImageIndex = 0;
            }

            // 心電図自動連携可否設定
            if (ekgIFYN.Equals("Y")) this.cbxEkgIFYN.Checked = true;
            else this.cbxEkgIFYN.Checked = false;

            // 実施者に 現在ログインしている IDを セットする｡
            this.dbxDocCode.SetDataValue(UserInfo.UserID);
            this.dbxDocName.SetDataValue(UserInfo.UserName);
            this.isFirstLoad = false;
        }

        private void setTimer()
        {
            if (TypeCheck.IsInt(txtTimeInterval.Text))
            {
                this.QueryTime = int.Parse(txtTimeInterval.GetDataValue());
                this.TimeVal = int.Parse(txtTimeInterval.GetDataValue());
            }

            this.QueryTime = this.TimeVal;

            this.cboTime.SelectedIndex = 0;
            this.timer1.Start();
            this.cboTime.Enabled = true;
            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();
        }

        private void PostTimerValidating()
        {
            this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void controlGrdReadonly()
        {
            // 全体TAB
            if (this.rbxActAll.Checked)
            {
                this.xEditGridCell90.IsReadOnly = true;  // jubsu_date
                this.xEditGridCell91.IsReadOnly = true;  // jubsu_time
                this.xEditGridCell8.IsReadOnly = true; // acting_date
                this.xEditGridCell9.IsReadOnly = true; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = true; // act_yn
                this.xEditGridCell87.IsReadOnly = true; // nalsu
                this.xEditGridCell88.IsReadOnly = true; // suryang

                //this.btnChange.Enabled = false; // 実施者一括適用Combo

                this.grdJaeryo.ReadOnly = true;  // 材料GRID

                this.btnJaeryo.Visible = false;  // 材料ボタン

                this.btnIfEkg.Enabled = false;   // 心電図I/Fボタン
            }

            // 未実施TAB
            if (this.rbxNonAct.Checked)
            {
                this.xEditGridCell90.IsReadOnly = false;  // jubsu_date
                this.xEditGridCell91.IsReadOnly = false;  // jubsu_time
                this.xEditGridCell8.IsReadOnly = false; // acting_date
                this.xEditGridCell9.IsReadOnly = false; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = false; // act_yn

                this.xEditGridCell87.IsReadOnly = false; // nalsu
                this.xEditGridCell88.IsReadOnly = false; // suryang

                this.btnChange.Enabled = true; // 実施者一括適用Combo

                this.grdJaeryo.ReadOnly = false;  // 材料GRID

                this.btnJaeryo.Visible = true;    // 材料ボタン

                this.btnIfEkg.Enabled = false;    // 心電図I/Fボタン
            }

            // 実施済TAB
            if (this.rbxAct.Checked)
            {
                this.xEditGridCell90.IsReadOnly = true;  // jubsu_date
                this.xEditGridCell91.IsReadOnly = true;  // jubsu_time
                this.xEditGridCell8.IsReadOnly = true; // acting_date
                this.xEditGridCell9.IsReadOnly = true; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = false; // act_yn

                this.xEditGridCell87.IsReadOnly = true; // nalsu
                this.xEditGridCell88.IsReadOnly = true; // suryang

                //this.btnChange.Enabled = false; // 実施者一括適用Combo

                this.grdJaeryo.ReadOnly = false;  // 材料GRID

                this.btnJaeryo.Visible = true;    // 材料ボタン

                this.btnIfEkg.Enabled = true;     // 心電図I/Fボタン
            }
        }

        #region deleted by Cloud
        //        private void setCbxActorSql()
        //        {
        //            this.cbxActor.ResetData();

        //            if (EnvironInfo.CurrSystemID.Equals("NUTS"))
        //            {
        //                // 栄養室
        //                this.cbxActor.UserSQL = @"SELECT '' USER_ID
        //                                               , '' USER_NM
        //                                            FROM DUAL
        //                                          UNION
        //                                          SELECT USER_ID
        //                                               , USER_NM
        //                                            FROM ADM3200
        //                                           WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
        //                                             AND USER_GROUP  = 'NUT'
        //                                             AND USER_GUBUN  = '3'
        //                                           ORDER BY USER_ID NULLS FIRST";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("CPLS"))
        //            {
        //                // 心電図
        //                this.cbxActor.UserSQL = @"SELECT '' USER_ID
        //                                           , '' USER_NM
        //                                        FROM DUAL
        //                                      UNION
        //                                      SELECT USER_ID
        //                                           , USER_NM
        //                                        FROM ADM3200
        //                                       WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
        //                                         AND USER_GROUP  = 'CPL'
        //                                         AND USER_GUBUN  = '3'
        //                                       ORDER BY USER_ID NULLS FIRST";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("PFES"))
        //            {
        //                // 内視鏡、超音波　（30010：外来看護、30100：Ａ病棟）
        //                this.cbxActor.UserSQL = @"SELECT '' USER_ID
        //                                               , '' USER_NM
        //                                            FROM DUAL
        //                                            UNION
        //                                            SELECT USER_ID
        //                                               , USER_NM
        //                                            FROM ADM3200
        //                                           WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
        //                                             AND USER_GROUP  = 'OCS'
        //                                             AND USER_ID     IN (SELECT CODE_NAME
        //                                                                   FROM OCS0132
        //                                                                   WHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
        //                                                                   AND CODE_TYPE     = 'SUBPART_DOCTOR')
        //                                           ORDER BY USER_ID NULLS FIRST";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("OPRS"))
        //            {
        //                // 手術の場合はドクター全部乗せる
        //                this.cbxActor.UserSQL = @"  SELECT A.USER_ID
        //                                                 , A.USER_NM
        //                                              FROM ADM3200 A
        //                                             WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                               AND A.USER_GROUP = 'OCS'
        //                                               AND A.DEPT_CODE  = '10000'
        //                                               AND A.USER_GUBUN = '1'
        //                                             ORDER BY A.USER_ID";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("TSTS"))
        //            {
        //                // 手術の場合はドクター全部乗せる
        //                this.cbxActor.UserSQL = @"  SELECT A.USER_ID
        //                                                 , A.USER_NM
        //                                              FROM ADM3200 A
        //                                             WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                               AND A.USER_GROUP = 'NUR'
        //                                               AND A.DEPT_CODE  = '30010'
        //                                               AND A.USER_GUBUN = '2'
        //                                             UNION
        //                                            SELECT A.USER_ID
        //                                                 , A.USER_NM
        //                                              FROM ADM3200 A
        //                                                 , BAS0260 B
        //                                             WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                               AND A.USER_GROUP = 'NUR'
        //                                               AND A.USER_GUBUN = '2'
        //                                               --
        //                                               AND B.HOSP_CODE = A.HOSP_CODE
        //                                               AND B.BUSEO_NAME = '" + UserInfo.HoDong + @"'
        //                                               AND B.BUSEO_CODE = A.DEPT_CODE
        //                                             ORDER BY 1
        //                                             ";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("NURO"))
        //            {
        //                // 手術の場合はドクター全部乗せる
        //                this.cbxActor.UserSQL = @"  SELECT A.USER_ID
        //                                                 , A.USER_NM
        //                                              FROM ADM3200 A
        //                                             WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                               AND A.USER_GROUP = 'NUR'
        //                                               AND A.USER_GUBUN = '2'
        //                                               AND A.DEPT_CODE  = '30010'
        //                                             ORDER BY A.USER_ID
        //                                             ";
        //            }

        //            if (EnvironInfo.CurrSystemID.Equals("NURI"))
        //            {
        //                // 手術の場合はドクター全部乗せる
        //                this.cbxActor.UserSQL = @"  SELECT A.USER_ID
        //                                                 , A.USER_NM
        //                                              FROM ADM3200 A
        //                                                 , BAS0260 B
        //                                             WHERE A.HOSP_CODE  = FN_ADM_LOAD_HOSP_CODE()
        //                                               AND A.USER_GROUP = 'NUR'
        //                                               AND A.USER_GUBUN = '2'
        //                                               --
        //                                               AND B.HOSP_CODE = A.HOSP_CODE
        //                                               AND B.BUSEO_NAME = '" + UserInfo.HoDong + @"'
        //                                               AND B.BUSEO_CODE = A.DEPT_CODE
        //                                             ORDER BY A.USER_ID";
        //            }

        //            this.cbxActor.SetDictDDLB();

        //            this.grdPaList.QueryLayout(false);
        //        }
        #endregion

        #region unused code
        //        /// <summary>
        //        /// 시간을 입력받아 데이타 처리하는 항목은 시간을 입력받는다.
        //        /// </summary>
        //        /// <param name="aOpener"> object Opener </param>
        //        /// <param name="aDRow"> DataRow 항목정보 </param>
        //        /// <returns> bool : Value Setting 여부 </returns>
        //        public bool GetInputTime(object aOpener, DataRow aDRow)
        //        {
        //            bool isSuccess = false;

        //            string cmd = "";
        //            BindVarCollection bind = new BindVarCollection();

        //            if (aDRow == null) return isSuccess;

        //            // string mbxMsg = "", mbxCap = "";

        //            // 시간,분 입력 항목인지 체크
        //            if (!aDRow.Table.Columns.Contains("input_control") || aDRow["input_control"].ToString() != "3") return isSuccess;

        //            bool isOxygenCode = false; // 산소코드여부

        //            string bun_code = "", hangmog_code = "", hangmog_name = "";

        //            if (aDRow.Table.Columns.Contains("bun_code")) bun_code = aDRow["bun_code"].ToString().Trim();
        //            if (aDRow.Table.Columns.Contains("hangmog_code")) hangmog_code = aDRow["hangmog_code"].ToString().Trim();
        //            if (aDRow.Table.Columns.Contains("hangmog_name")) hangmog_name = aDRow["hangmog_name"].ToString().Trim();

        //            // 산소코드
        //            if (bun_code == "T2") isOxygenCode = true;

        //            this.mLayInputTime.Reset();

        //            int insertRow = this.mLayInputTime.InsertRow(0);

        //            this.mLayInputTime.SetItemValue(insertRow, "hangmog_code", hangmog_code); // 항목코드
        //            this.mLayInputTime.SetItemValue(insertRow, "hangmog_name", hangmog_name); // 항목명

        //            if (isOxygenCode) // 산소코드
        //            {
        //                this.mLayInputTime.SetItemValue(insertRow, "minute_suryang", TypeCheck.NVL(aDRow["suryang"], 0)); // 분당수량

        //                double tot_minute = 0;  // 총 주입시간 <= 수량필드
        //                double hour = 0;
        //                double minute = 0;

        //                tot_minute = long.Parse(TypeCheck.NVL(aDRow["nalsu"], "0").ToString());  // 총 주입시간 <= 수량필드
        //                if (tot_minute > 0)
        //                {
        //                    hour = Math.Floor(tot_minute / 60);
        //                    minute = Math.Floor(tot_minute % 60);
        //                }

        //                this.mLayInputTime.SetItemValue(insertRow, "hour", hour);     // 시간 <= 일수필드
        //                this.mLayInputTime.SetItemValue(insertRow, "minute", minute);   // 분   <= 일수필드			
        //            }
        //            else
        //            {
        //                this.mLayInputTime.SetItemValue(insertRow, "minute_suryang", 0);         // 수량 <= 안씀
        //                this.mLayInputTime.SetItemValue(insertRow, "hour", TypeCheck.NVL(aDRow["suryang"], 0)); // 시간 <= 수량필드
        //                this.mLayInputTime.SetItemValue(insertRow, "minute", TypeCheck.NVL(aDRow["nalsu"], 0));   // 분   <= 일수필드
        //            }

        //            // Defalut 값 세팅
        //            aDRow["suryang"] = 0; aDRow["nalsu"] = 0;

        //            MultiLayout layInputData = this.mLayInputTime.Copy();
        //            MultiLayout layOutputData = null;

        //            if (isOxygenCode)
        //            {
        //                FormGetInputO2 FormGetInputO2 = new FormGetInputO2(); // Form 설정

        //                try
        //                {
        //                    // Argument 전송(데이타 받을 구조를 넘긴다)
        //                    if (FormGetInputO2.GetValue(layInputData, isOxygenCode))
        //                    {
        //                        DialogResult dialogResult = FormGetInputO2.ShowDialog();// 모달로 Open 

        //                        if (FormGetInputO2 != null && dialogResult == DialogResult.OK)
        //                        {
        //                            layOutputData = (MultiLayout)FormGetInputO2.ReturnValue.Copy();

        //                            if (layOutputData.RowCount > 0)
        //                            {
        //                                // 수량 <= 분당주입량
        //                                // 날수 <= 시간 + 분
        //                                aDRow["suryang"] = TypeCheck.NVL(layOutputData.GetItemValue(0, "minute_suryang"), 0);

        //                                if (TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0).ToString() == "0") // 시간
        //                                    aDRow["nalsu"] = TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0);
        //                                else
        //                                    aDRow["nalsu"] = (int.Parse(TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0).ToString()) * 60) + int.Parse(TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0).ToString());

        //                                isSuccess = true;
        //                            }


        //                        }
        //                    }
        //                    else
        //                    {
        //                        FormGetInputO2.Close(); // .Dispose();  // 모달 폼 Close
        //                    }
        //                }
        //                finally
        //                {
        //                    if (FormGetInputO2 != null) FormGetInputO2.Close(); // .Dispose();  // 모달 폼 Close
        //                }

        //            }
        //            else
        //            {
        //                FormGetInputTime frmGetInputTime = new FormGetInputTime(); // Form 설정

        //                try
        //                {
        //                    // Argument 전송(데이타 받을 구조를 넘긴다)
        //                    if (frmGetInputTime.GetValue(layInputData, isOxygenCode))
        //                    {
        //                        DialogResult dialogResult = frmGetInputTime.ShowDialog();// 모달로 Open 

        //                        if (frmGetInputTime != null && dialogResult == DialogResult.OK)
        //                        {
        //                            layOutputData = (MultiLayout)frmGetInputTime.ReturnValue.Copy();

        //                            if (layOutputData.RowCount > 0)
        //                            {
        //                                // 수량 <= 시간
        //                                // 날수 <= 분
        //                                aDRow["suryang"] = TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0);
        //                                aDRow["nalsu"] = TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0);

        //                                isSuccess = true;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        frmGetInputTime.Close(); // .Dispose();  // 모달 폼 Close
        //                    }
        //                }
        //                finally
        //                {

        //                    bind.Add("f_hosp_code", EnvironInfo.HospCode);
        //                    bind.Add("f_suryang", aDRow["suryang"].ToString());
        //                    bind.Add("f_nalsu", aDRow["nalsu"].ToString());
        //                    bind.Add("f_pkocskey", aDRow["pkocs"].ToString());

        //                    if (aDRow["in_out_gubun"].ToString() == "O")
        //                    {
        //                        cmd = @"UPDATE OCS1003 A
        //                                   SET A.SURYANG = :f_suryang
        //                                     , A.NALSU   = :f_nalsu
        //                                 WHERE A.HOSP_CODE = :f_hosp_code
        //                                   AND A.PKOCS1003 = :f_pkocskey
        //                                    ";

        //                    }
        //                    else
        //                    {
        //                        cmd = @"UPDATE OCS2003 A
        //                                   SET A.SURYANG = :f_suryang
        //                                     , A.NALSU   = :f_nalsu
        //                                 WHERE A.HOSP_CODE = :f_hosp_code
        //                                   AND A.PKOCS2003 = :f_pkocskey
        //                                    ";

        //                    }

        //                    Service.BeginTransaction();

        //                    isSuccess = Service.ExecuteNonQuery(cmd, bind);

        //                    if (isSuccess)
        //                    {
        //                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "suryang", aDRow["suryang"].ToString());
        //                        this.grdOrder.SetItemValue(this.grdOrder.CurrentRowNumber, "nalsu", aDRow["nalsu"].ToString());
        //                    }

        //                    if (frmGetInputTime != null) frmGetInputTime.Close(); // .Dispose();  // 모달 폼 Close
        //                }

        //            }


        //            return isSuccess;

        //        }
        #endregion

        public bool GetInputTime(object aOpener, XEditGrid aGrd)
        {
            bool isSuccess = false;
            int aRow = aGrd.CurrentRowNumber;
            string cmd = "";
            BindVarCollection bind = new BindVarCollection();

            if (aGrd == null) return isSuccess;

            // string mbxMsg = "", mbxCap = "";

            // 시간,분 입력 항목인지 체크
            if (!aGrd.CellInfos.Contains("input_control") || aGrd.GetItemString(aRow, "input_control") != "3") return isSuccess;

            bool isOxygenCode = false; // 산소코드여부

            string bun_code = "", hangmog_code = "", hangmog_name = "";

            if (aGrd.CellInfos.Contains("bun_code")) bun_code = aGrd.GetItemString(aRow, "bun_code").Trim();
            if (aGrd.CellInfos.Contains("hangmog_code")) hangmog_code = aGrd.GetItemString(aRow, "hangmog_code").Trim();
            if (aGrd.CellInfos.Contains("hangmog_name")) hangmog_name = aGrd.GetItemString(aRow, "hangmog_name").Trim();

            // 산소코드
            if (bun_code == "T2") isOxygenCode = true;

            this.mLayInputTime.Reset();

            int insertRow = this.mLayInputTime.InsertRow(0);

            this.mLayInputTime.SetItemValue(insertRow, "hangmog_code", hangmog_code); // 항목코드
            this.mLayInputTime.SetItemValue(insertRow, "hangmog_name", hangmog_name); // 항목명

            if (isOxygenCode) // 산소코드
            {
                this.mLayInputTime.SetItemValue(insertRow, "minute_suryang", TypeCheck.NVL(aGrd.GetItemString(aRow, "suryang"), 0)); // 분당수량

                double tot_minute = 0;  // 총 주입시간 <= 수량필드
                double hour = 0;
                double minute = 0;

                tot_minute = long.Parse(TypeCheck.NVL(aGrd.GetItemString(aRow, "nalsu"), "0").ToString());  // 총 주입시간 <= 수량필드
                if (tot_minute > 0)
                {
                    hour = Math.Floor(tot_minute / 60);
                    minute = Math.Floor(tot_minute % 60);
                }

                this.mLayInputTime.SetItemValue(insertRow, "hour", hour);     // 시간 <= 일수필드
                this.mLayInputTime.SetItemValue(insertRow, "minute", minute);   // 분   <= 일수필드			
            }
            else
            {
                this.mLayInputTime.SetItemValue(insertRow, "minute_suryang", 0);         // 수량 <= 안씀
                this.mLayInputTime.SetItemValue(insertRow, "hour", TypeCheck.NVL(aGrd.GetItemString(aRow, "suryang"), 0)); // 시간 <= 수량필드
                this.mLayInputTime.SetItemValue(insertRow, "minute", TypeCheck.NVL(aGrd.GetItemString(aRow, "nalsu"), 0));   // 분   <= 일수필드
            }

            // Defalut 값 세팅
            //aGrd.SetItemValue(aRow, "suryang", "0");
            //aGrd.SetItemValue(aRow, "nalsu", "0");

            MultiLayout layInputData = this.mLayInputTime.Copy();
            MultiLayout layOutputData = null;

            if (isOxygenCode)
            {
                FormGetInputO2 FormGetInputO2 = new FormGetInputO2(); // Form 설정

                try
                {
                    // 基本デフォルト値を行為オーダーの時間をそのまま渡す
                    layInputData.SetItemValue(0, "minute_suryang", 1);
                    layInputData.SetItemValue(0, "hour", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "suryang"));
                    layInputData.SetItemValue(0, "minute", this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "nalsu"));

                    // Argument 전송(데이타 받을 구조를 넘긴다)
                    if (FormGetInputO2.GetValue(layInputData, isOxygenCode))
                    {
                        DialogResult dialogResult = FormGetInputO2.ShowDialog();// 모달로 Open 

                        if (FormGetInputO2 != null && dialogResult == DialogResult.OK)
                        {
                            layOutputData = (MultiLayout)FormGetInputO2.ReturnValue.Copy();

                            if (layOutputData.RowCount > 0)
                            {
                                // 수량 <= 분당주입량
                                // 날수 <= 시간 + 분
                                aGrd.SetItemValue(aRow, "suryang", TypeCheck.NVL(layOutputData.GetItemValue(0, "minute_suryang"), 0));

                                if (TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0).ToString() == "0") // 시간
                                    aGrd.SetItemValue(aRow, "nalsu", TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0));
                                else
                                    aGrd.SetItemValue(aRow, "nalsu", (int.Parse(TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0).ToString()) * 60) + int.Parse(TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0).ToString()));

                                isSuccess = true;
                            }


                        }
                    }
                    else
                    {
                        FormGetInputO2.Close(); // .Dispose();  // 모달 폼 Close
                    }
                }
                finally
                {
                    if (FormGetInputO2 != null) FormGetInputO2.Close(); // .Dispose();  // 모달 폼 Close
                }

            }
            else
            {
                FormGetInputTime frmGetInputTime = new FormGetInputTime(); // Form 설정

                try
                {
                    // Argument 전송(데이타 받을 구조를 넘긴다)
                    if (frmGetInputTime.GetValue(layInputData, isOxygenCode))
                    {
                        DialogResult dialogResult = frmGetInputTime.ShowDialog();// 모달로 Open 

                        if (frmGetInputTime != null && dialogResult == DialogResult.OK)
                        {
                            layOutputData = (MultiLayout)frmGetInputTime.ReturnValue.Copy();

                            if (layOutputData.RowCount > 0)
                            {
                                // 수량 <= 시간
                                // 날수 <= 분
                                aGrd.SetItemValue(aRow, "suryang", TypeCheck.NVL(layOutputData.GetItemValue(0, "hour"), 0));
                                aGrd.SetItemValue(aRow, "nalsu", TypeCheck.NVL(layOutputData.GetItemValue(0, "minute"), 0));

                                isSuccess = true;
                            }
                        }
                    }
                    else
                    {
                        frmGetInputTime.Close(); // .Dispose();  // 모달 폼 Close
                    }
                }
                finally
                {
                    if (frmGetInputTime != null) frmGetInputTime.Close(); // .Dispose();  // 모달 폼 Close
                }

            }


            return isSuccess;

        }

        #region deleted by Cloud
        //        private void updJaeryoProcess(string updGubun)
        //        {
        //            Hashtable inputList = new Hashtable();
        //            Hashtable outputList = new Hashtable();
        //            string cmdText = "";
        //            BindVarCollection bindVars = new BindVarCollection();
        //            string subul_danui = "";
        //            string subul_suryang = "";


        //            #region [updGubun.Equals("I")] 材料登録処理
        //            if (updGubun.Equals("I"))
        //            {
        //                foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
        //                {
        //                    if (dtRow["suryang"].ToString() == "")
        //                    {
        //                        Service.RollbackTransaction();
        //                        string mMsg = NetInfo.Language == LangMode.Ko ?
        //                                 Resources.XMessageBox6_Ko :
        //                                 Resources.XMessageBox6_JP;
        //                        string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Caption : Resources.XMessageBox_caption2;
        //                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        return;
        //                    }
        //                    switch (dtRow.RowState)
        //                    {
        //                        case DataRowState.Added:
        //                            // ocs update
        //                            inputList.Clear();
        //                            outputList.Clear();

        //                            string pkocs_inv = "";

        //                            if (dtRow.ItemArray.GetValue(0).ToString() == "") break;
        //                            //입원 재료 입력 프로세스
        //                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                            {
        //                                inputList.Add("I_IUD_GUBUN", "I");
        //                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
        //                                inputList.Add("I_PKOCS2003", 0);
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["IO_ERR"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                        return;
        //                                    }

        //                                    //insert ocskey
        //                                    pkocs_inv = outputList["IO_PKOCS2003"].ToString();

        //                                    //수불 수량 단위 가져오기
        //                                    inputList.Clear();
        //                                    outputList.Clear();
        //                                    subul_danui = "";
        //                                    subul_suryang = "";

        //                                    inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                    inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                    inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                                    inputList.Add("I_DIVIDE", "1");
        //                                    inputList.Add("I_DV_TIME", "*");
        //                                    inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                                    inputList.Add("I_NALSU", "1");
        //                                    inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                                    if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (outputList["O_FLAG"].ToString() != "0")
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }

        //                                        // inv1001 save

        //                                        subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                                        subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
        //                                        //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
        //                                        if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                                        if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";


        //                                        cmdText = @"SELECT INV1001_SEQ.NEXTVAL
        //                                                  FROM DUAL";

        //                                        object pkinv1001 = Service.ExecuteScalar(cmdText);

        //                                        if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
        //                                        {
        //                                            bindVars.Clear();
        //                                            bindVars.Add("f_sys_id", UserInfo.UserID);
        //                                            bindVars.Add("f_pkinv1001", pkinv1001.ToString());
        //                                            bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
        //                                            bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                            bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                            bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                                            bindVars.Add("f_subul_suryang", subul_suryang);
        //                                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
        //                                            bindVars.Add("f_subul_danui", subul_danui);
        //                                            bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                            bindVars.Add("f_fkocs_inv", pkocs_inv);
        //                                            bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
        //                                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

        //                                            cmdText = @"INSERT INTO INV1001 (
        //                                                        SYS_DATE,        SYS_ID,             UPD_DATE,
        //                                                        PKINV1001,       BUNHO,              ORDER_DATE,
        //                                                        IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
        //                                                        JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
        //                                                        DV_TIME,         DV,                 NALSU,
        //                                                        ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
        //                                                        FKOCS2003,       BOM_SOURCE_KEY,     HOSP_CODE
        //                                                    ) VALUES (
        //                                                        SYSDATE,           :f_sys_id,             SYSDATE,
        //                                                        :f_pkinv1001,      :f_bunho,              :f_order_date,
        //                                                        :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
        //                                                        :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
        //                                                        '*',               '1',                   NVL(:f_nalsu,1),
        //                                                        :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
        //                                                        :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

        //                                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                                            {
        //                                                Service.RollbackTransaction();
        //                                                XMessageBox.Show(Service.ErrFullMsg);
        //                                                return;
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }

        //                                    }
        //                                }
        //                            }
        //                            //외래 재료 입력 프로세스
        //                            else
        //                            {
        //                                inputList.Add("I_IUD_GUBUN", "I");
        //                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
        //                                inputList.Add("I_PKOCS1003", 0);
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["IO_ERR"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                        return;
        //                                    }

        //                                    //insert ocskey
        //                                    pkocs_inv = outputList["IO_PKOCS1003"].ToString();

        //                                    //수불 수량 단위 가져오기
        //                                    inputList.Clear();
        //                                    outputList.Clear();

        //                                    inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                    inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                    inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                                    inputList.Add("I_DIVIDE", "1");
        //                                    inputList.Add("I_DV_TIME", "*");
        //                                    inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                                    inputList.Add("I_NALSU", "1");
        //                                    inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                                    if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }
        //                                    else
        //                                    {
        //                                        if (outputList["O_FLAG"].ToString() != "0")
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }

        //                                        // inv1001 save

        //                                        subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                                        subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
        //                                        //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
        //                                        if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                                        if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

        //                                        cmdText = @"SELECT INV1001_SEQ.NEXTVAL
        //                                                  FROM DUAL";

        //                                        object pkinv1001 = Service.ExecuteScalar(cmdText);

        //                                        if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
        //                                        {
        //                                            bindVars.Clear();
        //                                            bindVars.Add("f_sys_id", UserInfo.UserID);
        //                                            bindVars.Add("f_pkinv1001", pkinv1001.ToString());
        //                                            bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
        //                                            bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                            bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                            bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                                            bindVars.Add("f_subul_suryang", subul_suryang);
        //                                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
        //                                            bindVars.Add("f_subul_danui", subul_danui);
        //                                            bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                            bindVars.Add("f_fkocs_inv", pkocs_inv);
        //                                            bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
        //                                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

        //                                            cmdText = @"INSERT INTO INV1001 (
        //                                                        SYS_DATE,        SYS_ID,             UPD_DATE,
        //                                                        PKINV1001,       BUNHO,              ORDER_DATE,
        //                                                        IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
        //                                                        JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
        //                                                        DV_TIME,         DV,                 NALSU,
        //                                                        ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
        //                                                        FKOCS1003,       BOM_SOURCE_KEY,     HOSP_CODE
        //                                                    ) VALUES (
        //                                                        SYSDATE,           :f_sys_id,             SYSDATE,
        //                                                        :f_pkinv1001,      :f_bunho,              :f_order_date,
        //                                                        :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
        //                                                        :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
        //                                                        '*',               '1',                   NVL(:f_nalsu,1),
        //                                                        :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
        //                                                        :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

        //                                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                                            {
        //                                                Service.RollbackTransaction();
        //                                                XMessageBox.Show(Service.ErrFullMsg);
        //                                                return;
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }
        //            }
        //            #endregion

        //            #region [updGubun.Equals("U")] 材料修正処理
        //            if (updGubun.Equals("U"))
        //            {
        //                foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
        //                {
        //                    if (dtRow["suryang"].ToString() == "")
        //                    {
        //                        Service.RollbackTransaction();
        //                        string mMsg = NetInfo.Language == LangMode.Ko ?
        //                                 Resources.XMessageBox6_Ko :
        //                                 Resources.XMessageBox6_JP;
        //                        string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Caption : Resources.XMessageBox_caption2;
        //                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                        return;
        //                    }
        //                    switch (dtRow.RowState)
        //                    {
        //                        case DataRowState.Modified:
        //                            //수불 수량 단위 가져오기
        //                            inputList.Clear();
        //                            outputList.Clear();

        //                            subul_danui = "";
        //                            subul_suryang = "";

        //                            inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                            inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                            inputList.Add("I_DIVIDE", "1");
        //                            inputList.Add("I_DV_TIME", "*");
        //                            inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                            inputList.Add("I_NALSU", "1");
        //                            inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                            if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                if (outputList["O_FLAG"].ToString() != "0")
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }

        //                                subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                                subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();

        //                                if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                                if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

        //                            }

        //                            // update inv1001
        //                            bindVars.Clear();
        //                            bindVars.Add("f_upd_id", UserInfo.UserID);
        //                            bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());
        //                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                            bindVars.Add("f_subul_suryang", subul_suryang);
        //                            bindVars.Add("f_subul_danui", subul_danui);
        //                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());

        //                            cmdText = @"UPDATE INV1001
        //                                       SET UPD_ID          = :f_upd_id
        //                                         , UPD_DATE        = SYSDATE
        //                                         , JAERYO_CODE     = :f_jaeryo_code
        //                                         , SURYANG         = :f_subul_suryang
        //                                         , ORD_DANUI       = :f_subul_danui
        //                                         , NALSU           = NVL(:f_nalsu,1)
        //                                     WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001       = :f_pkinv1001";

        //                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }

        //                            inputList.Clear();
        //                            outputList.Clear();
        //                            //재료 입원 수정
        //                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                            {
        //                                inputList.Add("I_IUD_GUBUN", "U");
        //                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                                inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                                inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["IO_ERR"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                        return;
        //                                    }
        //                                }
        //                            }
        //                            //재료 외래 수정
        //                            else
        //                            {
        //                                inputList.Add("I_IUD_GUBUN", "U");
        //                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                inputList.Add("I_BOM_SOURCE_KEY", int.Parse(dtRow["fkocs_xrt"].ToString()));
        //                                inputList.Add("I_PKOCS1003", int.Parse(dtRow["fkocs_inv"].ToString()));
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["IO_ERR"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                        return;
        //                                    }
        //                                }
        //                            }
        //                            break;
        //                        default:
        //                            break;
        //                    }
        //                }
        //            }
        //            #endregion

        //            #region [updGubun.Equals("D")] 材料削除処理
        //            if (updGubun.Equals("D"))
        //            {
        //                try
        //                {
        //                    //foreach (DataRow dtRow in grdJaeryo.DeletedRowTable.Rows)
        //                    foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
        //                    {
        //                        // delete inv1001
        //                        bindVars.Clear();
        //                        bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());

        //                        cmdText = @"DELETE INV1001
        //                                     WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001    = :f_pkinv1001";

        //                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                        {
        //                            Service.RollbackTransaction();
        //                            XMessageBox.Show(Service.ErrFullMsg);
        //                            return;
        //                        }

        //                        inputList.Clear();
        //                        outputList.Clear();
        //                        //재료 입원 삭제
        //                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                        {
        //                            inputList.Add("I_IUD_GUBUN", "D");
        //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                            inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
        //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                            inputList.Add("I_ACTING_DATE", DBNull.Value);
        //                            inputList.Add("I_ACTING_TIME", DBNull.Value);
        //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                if (outputList["IO_ERR"].ToString() != "0")
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                    return;
        //                                }
        //                            }
        //                        }
        //                        //재료 외래 삭제
        //                        else
        //                        {
        //                            inputList.Add("I_IUD_GUBUN", "D");
        //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                            inputList.Add("I_PKOCS1003", dtRow["fkocs_inv"].ToString());
        //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                            inputList.Add("I_ACTING_DATE", DBNull.Value);
        //                            inputList.Add("I_ACTING_TIME", DBNull.Value);
        //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                if (outputList["IO_ERR"].ToString() != "0")
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                    return;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //                catch
        //                {
        //                }
        //            }
        //            #endregion
        //        }

        //        private void updJaeryoProcess()
        //        {
        //            Hashtable inputList = new Hashtable();
        //            Hashtable outputList = new Hashtable();
        //            string cmdText = "";
        //            BindVarCollection bindVars = new BindVarCollection();
        //            string subul_danui = "";
        //            string subul_suryang = "";

        //            foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
        //            {
        //                if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
        //                {
        //                    Service.RollbackTransaction();
        //                    XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
        //                    return;
        //                }
        //                if (dtRow["suryang"].ToString() == "")
        //                {
        //                    Service.RollbackTransaction();
        //                    string mMsg = NetInfo.Language == LangMode.Ko ?
        //                             Resources.XMessageBox6_Ko :
        //                             Resources.XMessageBox6_JP;
        //                    string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox6_Caption : Resources.XMessageBox_caption2;
        //                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }
        //                switch (dtRow.RowState)
        //                {
        //                    case DataRowState.Added:

        //                        // ocs update
        //                        inputList.Clear();
        //                        outputList.Clear();

        //                        string pkocs_inv = "";

        //                        if (dtRow.ItemArray.GetValue(0).ToString() == "") break;
        //                        //입원 재료 입력 프로세스
        //                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                        {
        //                            inputList.Add("I_IUD_GUBUN", "I");
        //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                            //inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
        //                            //////  仮オーダ処理
        //                            inputList.Add("I_BOM_SOURCE_KEY", int.Parse(this.newOcsKey));
        //                            inputList.Add("I_PKOCS2003", 0);
        //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                            inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                if (outputList["IO_ERR"].ToString() != "0")
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                    return;
        //                                }

        //                                //insert ocskey
        //                                pkocs_inv = outputList["IO_PKOCS2003"].ToString();

        //                                //수불 수량 단위 가져오기
        //                                inputList.Clear();
        //                                outputList.Clear();
        //                                subul_danui = "";
        //                                subul_suryang = "";

        //                                inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                                inputList.Add("I_DIVIDE", "1");
        //                                inputList.Add("I_DV_TIME", "*");
        //                                inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                                inputList.Add("I_NALSU", "1");
        //                                inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                                if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["O_FLAG"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }

        //                                    // inv1001 save

        //                                    subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                                    subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
        //                                    //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
        //                                    if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                                    if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";


        //                                    cmdText = @"SELECT INV1001_SEQ.NEXTVAL
        //                                                          FROM DUAL";

        //                                    object pkinv1001 = Service.ExecuteScalar(cmdText);

        //                                    if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
        //                                    {
        //                                        bindVars.Clear();
        //                                        bindVars.Add("f_sys_id", UserInfo.UserID);
        //                                        bindVars.Add("f_pkinv1001", pkinv1001.ToString());
        //                                        bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
        //                                        bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                        bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                        bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                                        bindVars.Add("f_subul_suryang", subul_suryang);
        //                                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
        //                                        bindVars.Add("f_subul_danui", subul_danui);
        //                                        bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                        bindVars.Add("f_fkocs_inv", pkocs_inv);
        //                                        //bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
        //                                        bindVars.Add("f_fkocs_xrt", this.newOcsKey);
        //                                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

        //                                        cmdText = @"INSERT INTO INV1001 (
        //                                                                SYS_DATE,        SYS_ID,             UPD_DATE,
        //                                                                PKINV1001,       BUNHO,              ORDER_DATE,
        //                                                                IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
        //                                                                JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
        //                                                                DV_TIME,         DV,                 NALSU,
        //                                                                ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
        //                                                                FKOCS2003,       BOM_SOURCE_KEY,     HOSP_CODE
        //                                                            ) VALUES (
        //                                                                SYSDATE,           :f_sys_id,             SYSDATE,
        //                                                                :f_pkinv1001,      :f_bunho,              :f_order_date,
        //                                                                :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
        //                                                                :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
        //                                                                '*',               '1',                   NVL(:f_nalsu,1),
        //                                                                :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
        //                                                                :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

        //                                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }

        //                                }
        //                            }
        //                        }
        //                        //외래 재료 입력 프로세스
        //                        else
        //                        {
        //                            inputList.Add("I_IUD_GUBUN", "I");
        //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                            //inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
        //                            //////////////////////////////////////////////////////////////////////////////////////////////////
        //                            //////  仮オーダ処理
        //                            inputList.Add("I_BOM_SOURCE_KEY", int.Parse(this.newOcsKey));
        //                            //////////////////////////////////////////////////////////////////////////////////////////////////
        //                            inputList.Add("I_PKOCS1003", 0);
        //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                            inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(Service.ErrFullMsg);
        //                                return;
        //                            }
        //                            else
        //                            {
        //                                if (outputList["IO_ERR"].ToString() != "0")
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                    return;
        //                                }

        //                                //insert ocskey
        //                                pkocs_inv = outputList["IO_PKOCS1003"].ToString();

        //                                //수불 수량 단위 가져오기
        //                                inputList.Clear();
        //                                outputList.Clear();

        //                                inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                                inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                                inputList.Add("I_DIVIDE", "1");
        //                                inputList.Add("I_DV_TIME", "*");
        //                                inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                                inputList.Add("I_NALSU", "1");
        //                                inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                                if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                                {
        //                                    Service.RollbackTransaction();
        //                                    XMessageBox.Show(Service.ErrFullMsg);
        //                                    return;
        //                                }
        //                                else
        //                                {
        //                                    if (outputList["O_FLAG"].ToString() != "0")
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }

        //                                    // inv1001 save

        //                                    subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                                    subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
        //                                    //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
        //                                    if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                                    if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

        //                                    cmdText = @"SELECT INV1001_SEQ.NEXTVAL
        //                                                          FROM DUAL";

        //                                    object pkinv1001 = Service.ExecuteScalar(cmdText);

        //                                    if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
        //                                    {
        //                                        bindVars.Clear();
        //                                        bindVars.Add("f_sys_id", UserInfo.UserID);
        //                                        bindVars.Add("f_pkinv1001", pkinv1001.ToString());
        //                                        bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
        //                                        bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                                        bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                                        bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                                        bindVars.Add("f_subul_suryang", subul_suryang);
        //                                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
        //                                        bindVars.Add("f_subul_danui", subul_danui);
        //                                        bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                                        bindVars.Add("f_fkocs_inv", pkocs_inv);
        //                                        //bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
        //                                        bindVars.Add("f_fkocs_xrt", this.newOcsKey);
        //                                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

        //                                        cmdText = @"INSERT INTO INV1001 (
        //                                                                SYS_DATE,        SYS_ID,             UPD_DATE,
        //                                                                PKINV1001,       BUNHO,              ORDER_DATE,
        //                                                                IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
        //                                                                JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
        //                                                                DV_TIME,         DV,                 NALSU,
        //                                                                ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
        //                                                                FKOCS1003,       BOM_SOURCE_KEY,     HOSP_CODE
        //                                                            ) VALUES (
        //                                                                SYSDATE,           :f_sys_id,             SYSDATE,
        //                                                                :f_pkinv1001,      :f_bunho,              :f_order_date,
        //                                                                :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
        //                                                                :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
        //                                                                '*',               '1',                   NVL(:f_nalsu,1),
        //                                                                :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
        //                                                                :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

        //                                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                                        {
        //                                            Service.RollbackTransaction();
        //                                            XMessageBox.Show(Service.ErrFullMsg);
        //                                            return;
        //                                        }
        //                                    }
        //                                    else
        //                                    {
        //                                        Service.RollbackTransaction();
        //                                        XMessageBox.Show(Service.ErrFullMsg);
        //                                        return;
        //                                    }

        //                                }
        //                            }
        //                        }
        //                        break;
        //                    case DataRowState.Modified:

        //                        XMessageBox.Show(Resources.XMessageBox7, Resources.XMessageBox_caption2, MessageBoxIcon.Warning);
        //                        return;

        //                    #region unused code
        //                    //                        //수불 수량 단위 가져오기
        //                    //                        inputList.Clear();
        //                    //                        outputList.Clear();

        //                    //                        subul_danui = "";
        //                    //                        subul_suryang = "";

        //                    //                        inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
        //                    //                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                    //                        inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
        //                    //                        inputList.Add("I_DIVIDE", "1");
        //                    //                        inputList.Add("I_DV_TIME", "*");
        //                    //                        inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
        //                    //                        inputList.Add("I_NALSU", "1");
        //                    //                        inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

        //                    //                        if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
        //                    //                        {
        //                    //                            Service.RollbackTransaction();
        //                    //                            XMessageBox.Show(Service.ErrFullMsg);
        //                    //                            return;
        //                    //                        }
        //                    //                        else
        //                    //                        {
        //                    //                            if (outputList["O_FLAG"].ToString() != "0")
        //                    //                            {
        //                    //                                Service.RollbackTransaction();
        //                    //                                XMessageBox.Show(Service.ErrFullMsg);
        //                    //                                return;
        //                    //                            }

        //                    //                            subul_danui = outputList["O_SUBUL_DANUI"].ToString();
        //                    //                            subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();

        //                    //                            if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
        //                    //                            if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

        //                    //                        }

        //                    //                        // update inv1001
        //                    //                        bindVars.Clear();
        //                    //                        bindVars.Add("f_upd_id", UserInfo.UserID);
        //                    //                        bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());
        //                    //                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
        //                    //                        bindVars.Add("f_subul_suryang", subul_suryang);
        //                    //                        bindVars.Add("f_subul_danui", subul_danui);
        //                    //                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());

        //                    //                        cmdText = @"UPDATE INV1001
        //                    //                                               SET UPD_ID          = :f_upd_id
        //                    //                                                 , UPD_DATE        = SYSDATE
        //                    //                                                 , JAERYO_CODE     = :f_jaeryo_code
        //                    //                                                 , SURYANG         = :f_subul_suryang
        //                    //                                                 , ORD_DANUI       = :f_subul_danui
        //                    //                                                 , NALSU           = NVL(:f_nalsu,1)
        //                    //                                             WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001       = :f_pkinv1001";

        //                    //                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                    //                        {
        //                    //                            Service.RollbackTransaction();
        //                    //                            XMessageBox.Show(Service.ErrFullMsg);
        //                    //                            return;
        //                    //                        }

        //                    //                        inputList.Clear();
        //                    //                        outputList.Clear();
        //                    //                        //재료 입원 수정
        //                    //                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                    //                        {
        //                    //                            inputList.Add("I_IUD_GUBUN", "U");
        //                    //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                    //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                    //                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                    //                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                    //                            inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
        //                    //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                    //                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                    //                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                    //                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                    //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                    //                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                    //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                    //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                    //                            {
        //                    //                                Service.RollbackTransaction();
        //                    //                                XMessageBox.Show(Service.ErrFullMsg);
        //                    //                                return;
        //                    //                            }
        //                    //                            else
        //                    //                            {
        //                    //                                if (outputList["IO_ERR"].ToString() != "0")
        //                    //                                {
        //                    //                                    Service.RollbackTransaction();
        //                    //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                    //                                    return;
        //                    //                                }
        //                    //                            }
        //                    //                        }
        //                    //                        //재료 외래 수정
        //                    //                        else
        //                    //                        {
        //                    //                            inputList.Add("I_IUD_GUBUN", "U");
        //                    //                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                    //                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                    //                            inputList.Add("I_BOM_SOURCE_KEY", int.Parse(dtRow["fkocs_xrt"].ToString()));
        //                    //                            inputList.Add("I_PKOCS1003", int.Parse(dtRow["fkocs_inv"].ToString()));
        //                    //                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                    //                            inputList.Add("I_SURYANG", decimal.Parse(dtRow["suryang"].ToString()));
        //                    //                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
        //                    //                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
        //                    //                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                    //                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
        //                    //                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                    //                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                    //                            {
        //                    //                                Service.RollbackTransaction();
        //                    //                                XMessageBox.Show(Service.ErrFullMsg);
        //                    //                                return;
        //                    //                            }
        //                    //                            else
        //                    //                            {
        //                    //                                if (outputList["IO_ERR"].ToString() != "0")
        //                    //                                {
        //                    //                                    Service.RollbackTransaction();
        //                    //                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                    //                                    return;
        //                    //                                }
        //                    //                            }
        //                    //                        }
        //                    #endregion
        //                    //break;
        //                    default:
        //                        break;
        //                }
        //            }

        //            //DELETE 재료 
        //            try
        //            {
        //                foreach (DataRow dtRow in grdJaeryo.DeletedRowTable.Rows)
        //                {
        //                    // delete inv1001
        //                    bindVars.Clear();
        //                    bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());

        //                    cmdText = @"DELETE INV1001
        //                                             WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001    = :f_pkinv1001";

        //                    if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
        //                    {
        //                        Service.RollbackTransaction();
        //                        XMessageBox.Show(Service.ErrFullMsg);
        //                        return;
        //                    }

        //                    inputList.Clear();
        //                    outputList.Clear();
        //                    //재료 입원 삭제
        //                    if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
        //                    {
        //                        inputList.Add("I_IUD_GUBUN", "D");
        //                        inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                        inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                        inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
        //                        inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                        inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
        //                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                        inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                        inputList.Add("I_ACTING_DATE", DBNull.Value);
        //                        inputList.Add("I_ACTING_TIME", DBNull.Value);
        //                        inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                        inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                        inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                        if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
        //                        {
        //                            Service.RollbackTransaction();
        //                            XMessageBox.Show(Service.ErrFullMsg);
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            if (outputList["IO_ERR"].ToString() != "0")
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                return;
        //                            }
        //                        }
        //                    }
        //                    //재료 외래 삭제
        //                    else
        //                    {
        //                        inputList.Add("I_IUD_GUBUN", "D");
        //                        inputList.Add("I_INPUT_ID", UserInfo.UserID);
        //                        inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
        //                        inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
        //                        inputList.Add("I_PKOCS1003", dtRow["fkocs_inv"].ToString());
        //                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
        //                        inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
        //                        inputList.Add("I_ACTING_DATE", DBNull.Value);
        //                        inputList.Add("I_ACTING_TIME", DBNull.Value);
        //                        inputList.Add("I_ORDER_GUBUN", DBNull.Value);
        //                        inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
        //                        inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

        //                        if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
        //                        {
        //                            Service.RollbackTransaction();
        //                            XMessageBox.Show(Service.ErrFullMsg);
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            if (outputList["IO_ERR"].ToString() != "0")
        //                            {
        //                                Service.RollbackTransaction();
        //                                XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
        //                                return;
        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //            catch
        //            {
        //            }
        //        }
        #endregion

        private bool checkNaewonYn()
        {
            bool rtnVal = false;

            string pkout1001 = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "fkout1001");

            #region deleted by Cloud
            //            string cmdText = @"SELECT DECODE(A.NAEWON_YN, 'E', 'Y', 'N')  END_YN
            //                                 FROM OUT1001 A
            //                                WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() 
            //                                  AND A.PKOUT1001 = '" + pkout1001 + "'";
            //            object retVal = Service.ExecuteScalar(cmdText);

            //            if (!TypeCheck.IsNull(retVal))
            //            {
            //                rtnVal = retVal.ToString().Equals("Y") ? true : false;
            //}
            #endregion

            // updated by Cloud
            OCSACTCheckNaewonYnArgs args = new OCSACTCheckNaewonYnArgs();
            args.Pkout1001 = pkout1001;
            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTCheckNaewonYnArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                rtnVal = res.ResponseStr.Equals("Y") ? true : false;
            }

            return rtnVal;
        }

        #region deleted by Cloud
        //        private string setPartParam(string cboVal)
        //        {
        //            string rtnVal = "";

        //            if (cboVal == "%")
        //            {
        //                // 
        //                if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURI" || EnvironInfo.CurrSystemID == "TSTS")
        //                {
        //                    this.mlayPart.QuerySQL = @"SELECT CODE
        //                                             FROM OCS0132
        //                                            WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
        //                                              AND CODE_TYPE = '" + this.cboSystem.GetDataValue() + @"'
        //                                              AND GROUP_KEY = 'NUR'";
        //                }
        //                else
        //                {
        //                    this.mlayPart.QuerySQL = @"SELECT CODE
        //                                             FROM OCS0132
        //                                            WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
        //                                              AND CODE_TYPE = '" + this.cboSystem.GetDataValue() + @"'
        //                                              AND GROUP_KEY = '" + EnvironInfo.CurrSystemID + @"'";
        //                }

        //                if (this.mlayPart.QueryLayout(true))
        //                {
        //                    for (int i = 0; i < this.mlayPart.RowCount; i++)
        //                    {
        //                        if (i == 0) rtnVal = "'" + this.mlayPart.GetItemString(i, "code") + "'";
        //                        else rtnVal = rtnVal + "," + "'" + this.mlayPart.GetItemString(i, "code") + "'";
        //                    }
        //                }
        //            }
        //            else rtnVal = "'" + this.cboPart.GetDataValue() + "'";

        //            return rtnVal;
        //        }
        #endregion

        private void OpenScreenNUT()
        {
            int currRow = -1;
            currRow = this.grdOrder.CurrentRowNumber;
            if (currRow < 0) return;
            //RowStatus変更のために弄る。
            //this.grdOrder.SetItemValue(currRow, "nalsu", 1);
            this.OpenScreen_SpecificComment(this.grdOrder, currRow, this.grdOrder.GetItemString(currRow, "specific_comment"));
        }

        /// <summary>
        /// 의뢰서 화면 오픈
        /// </summary>
        /// <param name="aGrid"></param>
        /// <param name="aRowNumber"></param>
        private void OpenScreen_SpecificComment(XEditGrid aGrid, int aRowNumber, string aSpecific_Comment)
        {

            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aGrid.GetItemString(aRowNumber, "bunho"));
            openParams.Add("order_date", aGrid.GetItemString(aRowNumber, "order_date"));
            openParams.Add("pkocskey", aGrid.GetItemString(aRowNumber, "pkocs"));
            openParams.Add("in_out_gubun", aGrid.GetItemString(aRowNumber, "in_out_gubun"));
            openParams.Add("hangmog_code", aGrid.GetItemString(aRowNumber, "hangmog_code"));
            openParams.Add("gwa", aGrid.GetItemString(aRowNumber, "gwa"));
            openParams.Add("doctor", aGrid.GetItemString(aRowNumber, "doctor"));
            openParams.Add("caller_screen_id", this.Name);
            openParams.Add("nutritionist", dbxDocCode.GetDataValue());
            openParams.Add("nutritionist_name", dbxDocName.Text);
            openParams.Add("act_yn", this.grdOrder.GetItemString(grdOrder.CurrentRowNumber, "old_act_yn"));

            try
            {
                if (aSpecific_Comment == "21")
                    XScreen.OpenScreenWithParam(this, "NUTS", "NUT0001U00", ScreenOpenStyle.ResponseFixed, openParams);
            }
            catch
            {
                string mbxMsg = "", mbxCap = "";
                mbxMsg = NetInfo.Language == LangMode.Jr ? Resources.XMessageBox8_JP : Resources.XMessageBox9_Ko;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
            }


        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            XEditGrid aGrd = this.grdJaeryo;

            switch (command)
            {
                case "OCS0311Q00": /* 세트 재료 */

                    if (commandParam.Contains("jaeryo_list"))
                    {
                        MultiLayout JaeryoList = commandParam["jaeryo_list"] as MultiLayout;

                        int set_row = -1;

                        if (this.grdJaeryo.CurrentRowNumber >= 0 && TypeCheck.IsNull(this.grdJaeryo.GetItemString(this.grdJaeryo.CurrentRowNumber, "hangmog_name")))
                            set_row = this.grdJaeryo.CurrentRowNumber;

                        int cnt = 0;

                        foreach (DataRow row in JaeryoList.LayoutTable.Rows)
                        {
                            string hangmog_code = row["hangmog_code"].ToString();
                            string hangmog_name = row["hangmog_name"].ToString();
                            string suryang = row["suryang"].ToString();
                            string danui = row["danui"].ToString();
                            string danui_name = row["danui_name"].ToString();
                            bool exist_yn = false;

                            //재료선택창에서 선택시에는 같은 오더가 존재하면 입력막기
                            if (this.cboSystem.SelectedValue.ToString() != "OCS_ACT_PART_05"
                                && this.cboSystem.SelectedValue.ToString() != "OCS_ACT_PART_08")
                            {
                                foreach (DataRow dtrow in grdJaeryo.LayoutTable.Rows)
                                {
                                    if (dtrow["hangmog_code"].ToString() == hangmog_code)
                                    {
                                        exist_yn = true;
                                        break;
                                    }
                                }
                            }

                            if (exist_yn) continue;

                            #region deleted by Cloud
                            //                            DataTable dtTable = new DataTable();

                            //                            string cmdStr = @"SELECT HANGMOG_NAME 
                            //                                    , '1'          SURYANG
                            //                                    , ORD_DANUI    DANUI
                            //                                    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',ORD_DANUI)   DANUI_NAME
                            //                                    , D.BUN_CODE
                            //                                    , A.INPUT_CONTROL
                            //                                 FROM OCS0103 A
                            //                                    , ( SELECT X.SG_CODE
                            //                                             , X.SG_NAME
                            //                                             , X.SG_YMD
                            //                                             , X.BULYONG_YMD 
                            //                                             , X.BUN_CODE
                            //                                          FROM BAS0310 X
                            //                                         WHERE X.HOSP_CODE = :f_hosp_code
                            //                                           AND X.SG_YMD = ( SELECT MAX(Z.SG_YMD)
                            //                                                              FROM BAS0310 Z
                            //                                                             WHERE Z.HOSP_CODE = X.HOSP_CODE
                            //                                                               AND Z.SG_CODE   = X.SG_CODE 
                            //                                                               AND Z.SG_YMD   <= TRUNC(SYSDATE) )
                            //                                      ) D
                            //                                WHERE A.HOSP_CODE        = :f_hosp_code
                            //                                  AND A.HANGMOG_CODE     = :f_hangmog_code
                            //                                  AND NVL(A.IF_INPUT_CONTROL, 'C') <> 'P'
                            //                                  AND SYSDATE BETWEEN A.START_DATE 
                            //                                                  AND A.END_DATE 
                            //                                  --
                            //                                  AND D.SG_CODE  (+) = A.SG_CODE
                            //                                  ";

                            //                            BindVarCollection bindVar = new BindVarCollection();
                            //                            bindVar.Clear();
                            //                            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                            //                            bindVar.Add("f_hangmog_code", hangmog_code);

                            //                            dtTable.Reset();

                            //                            dtTable = Service.ExecuteDataTable(cmdStr, bindVar);
                            #endregion

                            #region updated by Cloud

                            int rowCnt = 0;

                            OCSACTCommandArgs args = new OCSACTCommandArgs();
                            args.HangmogCode = hangmog_code;
                            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTCommandArgs>(args);

                            if (res.ExecutionStatus == ExecutionStatus.Success)
                            {
                                if (TypeCheck.IsInt(res.ResponseStr))
                                {
                                    rowCnt = Int32.Parse(res.ResponseStr);
                                }
                            }

                            #endregion

                            if (/*!TypeCheck.IsNull(dtTable) && dtTable.Rows.Count > 0*/rowCnt > 0)
                            {
                                if (cnt != 0 || set_row == -1)
                                    set_row = grdJaeryo.InsertRow();

                                this.grdJaeryo.SetItemValue(set_row, "suryang", suryang);
                                this.grdJaeryo.SetItemValue(set_row, "ord_danui", danui);
                                this.grdJaeryo.SetItemValue(set_row, "ord_danui_name", danui_name);
                                this.grdJaeryo.SetItemValue(set_row, "hangmog_code", hangmog_code);
                                this.grdJaeryo.SetItemValue(set_row, "hangmog_name", hangmog_name);
                                this.grdJaeryo.SetItemValue(set_row, "input_control", row["input_control"].ToString());
                                this.grdJaeryo.SetItemValue(set_row, "bun_code", row["bun_code"].ToString());
                                this.grdJaeryo.SetItemValue(set_row, "nalsu", "1");

                                this.GetInputTime(this, this.grdJaeryo);

                                if (aGrd != null && set_row > -1 && aGrd.CellInfos.Contains("hangmog_code"))
                                    this.mHangmogInfo.DisplaySpecialColHeader(aGrd.GetItemString(set_row, "in_out_gubun"), aGrd, set_row, aGrd.GetItemString(set_row, "hangmog_code").Trim());

                                cnt++;

                                this.grdJaeryo.AcceptData();
                            }
                            else
                            {
                                XMessageBox.Show(XMsg.GetMsg("M005") + "[" + hangmog_code + " : " + hangmog_name + "]", Resources.XMessageBox_caption2);
                            }


                        }
                    }



                    break;

                case "OCS0103Q00": //항목검색

                    #region
                    if (commandParam.Contains("OCS0103") && (MultiLayout)commandParam["OCS0103"] != null &&
                        ((MultiLayout)commandParam["OCS0103"]).RowCount > 0)
                    {
                        int set_row = -1;

                        if (this.grdJaeryo.CurrentRowNumber >= 0)
                            set_row = this.grdJaeryo.CurrentRowNumber;

                        int cnt = 0;

                        foreach (DataRow row in ((MultiLayout)commandParam["OCS0103"]).LayoutTable.Rows)
                        {
                            string hangmog_code = row["hangmog_code"].ToString();
                            string hangmog_name = row["hangmog_name"].ToString();

                            if (cnt != 0)
                            {
                                set_row = grdJaeryo.InsertRow();
                            }

                            this.grdJaeryo.SetItemValue(set_row, "hangmog_name", hangmog_name);

                            this.grdJaeryo.SetFocusToItem(set_row, "hangmog_code");
                            this.grdJaeryo.SetEditorValue(hangmog_code);

                            this.grdJaeryo.SetItemValue(set_row, "input_control", row["input_control"].ToString());
                            this.grdJaeryo.SetItemValue(set_row, "bun_code", row["bun_code"].ToString());
                            this.grdJaeryo.SetItemValue(set_row, "nalsu", "1");

                            cnt++;
                        }
                        grdJaeryo.AcceptData();
                    }

                    break;
                    #endregion
                case "ADM104Q":
                    if (commandParam.Contains("user_id") && !String.IsNullOrEmpty(commandParam["user_id"].ToString()))
                    {
                        dbxDocCode.SetDataValue(commandParam["user_id"]);
                    }
                    if (commandParam.Contains("user_name") && !String.IsNullOrEmpty(commandParam["user_name"].ToString()))
                    {
                        dbxDocName.SetDataValue(commandParam["user_name"]);
                    }
                    //MED-14738
                    if (jundalTable == "INJ")
                    {
                        for (int i = 0; i < inj1001U01.GrdDetail.RowCount; i++)
                        {
                            if (inj1001U01.GrdDetail.GetItemValue(i, "acting_flag").ToString() != "Y")
                                continue;
                            inj1001U01.GrdDetail.SetItemValue(i, "jujongja", dbxDocCode.GetDataValue());
                            inj1001U01.GrdDetail.SetItemValue(i, "jujongja_name", dbxDocName.GetDataValue());
                        }			
                    
                    }
                    break;

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        public XFindWorker GetFindWorker(string aColName, string aArgu1)
        {
            return GetFindWorker(aColName, aArgu1, "");
        }

        public XFindWorker GetFindWorker(string aColName, string aArgu1, string aArgu2)
        {
            return GetFindWorker(aColName, aArgu1, aArgu2, "");
        }

        public XFindWorker GetFindWorker(string aColName, string aArgu1, string aArgu2, string aArgu3)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();

            // updated by Cloud
            fdwCommon.ExecuteQuery = GetFindWorker;
            fdwCommon.ParamList = new List<string>(new string[] { "f_col_name", "f_arg1" });

            switch (aColName)
            {
                case "ord_danui":

                    //        this.fwkTest.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
                    //this.findColumnInfo1,
                    //this.findColumnInfo2});

                    // update by Cloud
                    fdwCommon.SetBindVarValue("f_col_name", aColName);
                    fdwCommon.SetBindVarValue("f_arg1", aArgu1);

                    fdwCommon.AutoQuery = true;
                    fdwCommon.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
                    //fdwCommon.InputSQL =
                    //    " SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), A.SEQ "
                    //    + "   FROM OCS0108 A "
                    //    + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                    //    + "   AND A.HANGMOG_CODE = '" + aArgu1 + "' "
                    //    + "  ORDER BY 3, 1, 2 ";

                    fdwCommon.ColInfos.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FindColumnInfoHeader1, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FindColumnInfoHeader2, FindColType.String, 400, 0, true, FilterType.Yes)});
                    fdwCommon.ColAppearance.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FindColumnInfoHeader1, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FindColumnInfoHeader2, FindColType.String, 400, 0, true, FilterType.Yes)});

                    //fdwCommon.ColInfos.Add("ord_danui", "オーダ単位", FindColType.String, 100, 0, true, FilterType.Yes);
                    //fdwCommon.ColInfos.Add("ord_danui_name", "オーダ単位名", FindColType.String, 400, 0, true, FilterType.Yes);

                    break;

                case "ord_danui_name":

                    // update by Cloud
                    fdwCommon.SetBindVarValue("f_col_name", aColName);
                    fdwCommon.SetBindVarValue("f_arg1", aArgu1);

                    fdwCommon.AutoQuery = true;
                    fdwCommon.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
                    //fdwCommon.InputSQL =
                    //    " SELECT B.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI) , B.SEQ "
                    //    + " FROM OCS0108 B "
                    //    + "    , OCS0103 A "
                    //    + "WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                    //    + "  AND A.HANGMOG_CODE = '" + aArgu1 + "' "
                    //    + "  AND TRUNC(SYSDATE) BETWEEN A.START_DATE AND A.END_DATE"
                    //    + "  AND B.HOSP_CODE = A.HOSP_CODE"
                    //    + "  AND B.HANGMOG_CODE = A.HANGMOG_CODE"
                    //    + "  AND B.HANGMOG_START_DATE = A.START_DATE"
                    //    + "  ORDER BY 3, 1, 2 ";

                    fdwCommon.ColInfos.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FindColumnInfoHeader1, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FindColumnInfoHeader2, FindColType.String, 200, 0, true, FilterType.Yes)});
                    fdwCommon.ColAppearance.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.FindColumnInfoHeader1, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.FindColumnInfoHeader2, FindColType.String, 200, 0, true, FilterType.Yes)});

                    //fdwCommon.ColInfos.Add("ord_danui_name", "オーダ単位名", FindColType.String, 400, 0, true, FilterType.Yes);
                    //fdwCommon.ColInfos.Add("ord_danui", "オーダ単位", FindColType.String, 100, 0, false, FilterType.No);

                    break;

                default:

                    XMessageBox.Show("Unmatch Column Error!!!", "", MessageBoxIcon.Exclamation);
                    break;
            }

            return fdwCommon;
        }

        private void reSendIF(string userid)
        {
            string ifCmdType = "INSERT";
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") == "Y")
            {
                ifCmdType = "INSERT";
            }
            else
            {
                ifCmdType = "DELETE";
            }

            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "ENDO")
            {
                SendIF("MX", ifCmdType, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"), userid, "");
            }
            //2011.09.15追加 EKG
            else if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part") == "EKG")
            {
                SendIF("EKG", ifCmdType, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"), userid, "");
            }
        }

        private void SendIF(string ifSysType, string ifCmdType, string inOutGubun, string pkOcs, string userid, string seq)
        {
            IHIS.Framework.tcpHelper sendIFsocket = new tcpHelper();

            string strCmd = ifSysType + "\t" + ifCmdType + "\t" + inOutGubun + "\t" + pkOcs + "\t" + userid + "\t" + seq;

            sendIFsocket.Send(EnvironInfo.GetInterfaceIP(), EnvironInfo.GetInterfacePort(), strCmd);
        }

        private void SetGrdHeaderImage(XEditGrid grid)
        {
            if (grid.Name == "grdPaList")
            {
                for (int i = 0; i < grid.RowCount; i++)
                {
                    // 입원 예약환자.
                    if (grid.GetItemString(i, "reser_yn") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[16];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "予約患者";
                    }

                    // 긴급 환자
                    if (grid.GetItemString(i, "emergency") == "Y")
                    {
                        grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[17];
                        grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "緊急処方";
                    }
                }
            }
        }

        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("PFE"))
                    Kernel32.PlaySound(this.alarmFilePath_PFE, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("PFE_EM"))
                    Kernel32.PlaySound(this.alarmFilePath_PFE_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
            }
            catch { }
        }

        #region deleted by Cloud
        private string isTempOrder(string hangmog_code)
        {
            string rtnVal = "";

            //            BindVarCollection bindVar = new BindVarCollection();

            //            bindVar.Add("f_hangmog_code", hangmog_code);

            //            string strCmd = @"SELECT GROUP_KEY
            //                                FROM VW_OCS_DUMMY_ORDER_MASTER
            //                               WHERE CODE = :f_hangmog_code";

            //            object result = Service.ExecuteScalar(strCmd, bindVar);

            //            if (!TypeCheck.IsNull(result)) rtnVal = result.ToString();

            // update by Cloud
            OCSACTTempOrderArgs args = new OCSACTTempOrderArgs();
            args.HangmogCode = hangmog_code;
            OCSACTSingleStringResult res = CloudService.Instance.Submit<OCSACTSingleStringResult, OCSACTTempOrderArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                rtnVal = res.ResponseStr;
            }

            return rtnVal;
        }
        #endregion

        private bool procEkgInterface()
        {
            #region deleted by Cloud
            //            Hashtable inputList = new Hashtable();
            //            Hashtable outputList = new Hashtable();

            //            //１．中間テーブルデータ生成（PFE5010）
            //            inputList.Clear();
            //            inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);       // 病院コード
            //            inputList.Add("I_ORDER_DATE", this.i_order_date);         // オーダ日付
            //            inputList.Add("I_DATA_DUBUN", "0");                       // データ区分(登録)
            //            inputList.Add("I_IN_OUT_GUBUN", "O");                     // 入外区分
            //            inputList.Add("I_BUNHO", this.i_bunho);                   // 患者番号
            //            inputList.Add("I_FK", this.i_fkout1001);                  // FKOUT1001

            //            try
            //            {
            //                Service.BeginTransaction();

            //                // IFSテーブル作成リターン値
            //                int rtnIfsCnt = -1;
            //                string pkpfe5010 = "";

            //                bool value = Service.ExecuteProcedure("PR_PFE_EKG_PFE5010_INSERT", inputList, outputList);

            //                if (value == false || TypeCheck.IsNull(outputList["O_PK"]) || outputList["O_PK"].ToString().Equals("-1"))
            //                {
            //                    throw new Exception(Resources.Exception1);
            //                }
            //                else
            //                {
            //                    pkpfe5010 = outputList["O_PK"].ToString();

            //                    BindVarCollection item = new BindVarCollection();

            //                    //PFE0201に転送情報Update
            //                    string QuerySQL = @"UPDATE PFE0201 A
            //                                           SET A.FKPFE5010    = :f_pkpfe5010
            //                                         WHERE A.HOSP_CODE    = :f_hosp_code
            //                                           AND A.FKOCS1003    = :f_pkocs";

            //                    item.Clear();
            //                    item.Add("f_pkpfe5010", pkpfe5010);
            //                    item.Add("f_hosp_code", EnvironInfo.HospCode);
            //                    item.Add("f_pkocs", this.i_pkocs);

            //                    if (!Service.ExecuteNonQuery(QuerySQL, item))
            //                    {
            //                        throw new Exception(Resources.Exception2);
            //                    }

            //                    //２．I/Fテーブルデータ生成（IFS7601）
            //                    rtnIfsCnt = this.makeIFSTBL("O", pkpfe5010, "Y");
            //                }
            //                Service.CommitTransaction();

            //                //３．心電図にFILE転送
            //                if (rtnIfsCnt == 0)
            //                {
            //                    if (this.atcTrans(pkpfe5010))
            //                        XMessageBox.Show(Resources.XMessageBox16, Resources.XMessageBox_Caption16, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Service.RollbackTransaction();
            //                XMessageBox.Show(ex.Message, Resources.XMessageBox_Caption17, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return false;
            //            }
            #endregion

            #region updated by Cloud

            OCSACTProcEkgInterfaceArgs args = new OCSACTProcEkgInterfaceArgs();
            args.Bunho = this.i_bunho;
            args.Fkout1001 = this.i_fkout1001;
            args.IoGubun = "O";
            args.OrderDate = this.i_order_date;
            args.Pkocs = this.i_pkocs;
            args.SendYn = "Y";
            args.UserId = this.dbxDocCode.GetDataValue();
            OCSACTProcEkgInterfaceResult res = CloudService.Instance.Submit<OCSACTProcEkgInterfaceResult, OCSACTProcEkgInterfaceArgs>(args);

            if (null != res)
            {
                switch (res.ExceptionId)
                {
                    case "1":
                        throw new Exception(Resources.Exception1);
                    case "2":
                        throw new Exception(Resources.Exception2);
                    case "3":
                        throw new Exception(Resources.Exception3);
                    default:
                        break;
                }

                if (res.RtnIfsCnt == "0")
                {
                    if (this.atcTrans(res.Pkpfe5010))
                    {
                        XMessageBox.Show(Resources.XMessageBox16, Resources.XMessageBox_Caption16, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            #endregion

            return true;
        }

        #region deleted by Cloud
        //private int makeIFSTBL(string io_gubun, string pkpfe, string send_yn)
        //{
        //    Hashtable inputList = new Hashtable();
        //    Hashtable outputList = new Hashtable();

        //    int retVal = -1;

        //    inputList.Clear();
        //    outputList.Clear();

        //    inputList.Add("I_HOSP_CODE", EnvironInfo.HospCode);
        //    inputList.Add("I_IO_GUBUN", io_gubun);
        //    inputList.Add("I_FKPFE", pkpfe);
        //    inputList.Add("I_USER_ID", this.cbxActor.GetDataValue());

        //    bool ret = Service.ExecuteProcedure("PR_PFE_EKG_IFS_PROC", inputList, outputList);

        //    if (ret == false || TypeCheck.IsNull(outputList["O_ERR"]) || outputList["O_ERR"].ToString() == "1")
        //    {
        //        throw new Exception(Resources.Exception3);
        //    }
        //    else retVal = Int32.Parse(outputList["O_ERR"].ToString());

        //    return retVal;
        //}
        #endregion

        private bool atcTrans(string pkdrg)
        {
            if (TypeCheck.IsNull(pkdrg))
            {
                throw new Exception(Resources.Exception4);
            }

            IHIS.Framework.tcpHelper tcpSender = new tcpHelper();
            string msgText = null;

            msgText = "97601" + pkdrg;

            int ret = tcpSender.Send(EnvironInfo.GetKaikeiIP(), EnvironInfo.GetKaiKeiPort(), msgText);
            if (ret == -1)
            {
                throw new Exception(Resources.Exception5 + msgText);
            }
            return true;
        }

        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // defaultJearyo
            defaultJearyo.ParamList = new List<string>(new string[]
                {
                    "f_hangmog_code",
                });
            defaultJearyo.ExecuteQuery = GetDefaultJearyo;

            // grdJaeryo
            grdJaeryo.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_fkocs",
                    "f_io_gubun",
                    "f_jundal_part",
                    "f_order_date",
                });
            grdJaeryo.ExecuteQuery = GetGrdJaeryo;

            // grdSangByung
            //grdSangByung.ParamList = new List<string>(new string[]
            //    {
            //        "f_bunho",
            //        "f_order_date",
            //    });
            //grdSangByung.ExecuteQuery = GetGrdSangByung;

            // grdPaList
            //grdPaList.ParamList = new List<string>(new string[]
            //    {
            //        "f_act_gubun",
            //        "f_bunho",
            //        "f_cbo_part",
            //        "f_cbo_system",
            //        "f_cbo_val",
            //        "f_from_date",
            //        "f_io_gubun",
            //        "f_jundal_table_code",
            //        "f_system_id",
            //        "f_to_date",
            //    });
            grdPaList.ParamList = new List<string>(new string[]
                {
                    "f_acting_flg",
                    "f_bunho",
                    "f_gwa",
                    "f_hosp_code",
                    "f_jundal_table",
                    "f_order_date_from",
                    "f_order_date_to",
                });
            //grdPaList.ExecuteQuery = GetGrdPaList;
            grdPaList.ExecuteQuery = GetGrdPaList2;

            // grdOrder
            grdOrder.ParamList = new List<string>(new string[]
                {
                    "f_cbo_system",
                    "f_cbo_val",
                    "f_io_gubun",
                    "f_act_gubun",
                    "f_from_date",
                    "f_to_date",
                    "f_jundal_table_code",
                    "f_jundal_part",
                    "f_bunho",
                    "f_gwa",
                    "f_doctor",
                    "f_system_id",
                    "f_cbo_part",
                });
            grdOrder.ExecuteQuery = GetGrdOrder;

            // Prevent events fire before comboboxes is filled data
            cboSystem.SelectedIndexChanged -= new EventHandler(cboSystem_SelectedIndexChanged);
            //rbxIOAll.CheckedChanged -= new EventHandler(rbxIOAll_CheckedChanged);

            // Load combo data
            LoadComboSystemAndTime();
            cboSystem.ExecuteQuery = GetCboSystem;
            cboTime.ExecuteQuery = GetCboTime;
            cboSystem.SetDictDDLB();
            cboTime.SetDictDDLB();

            // Re-register events
            cboSystem.SelectedIndexChanged += new EventHandler(cboSystem_SelectedIndexChanged);
            //rbxIOAll.CheckedChanged += new EventHandler(rbxIOAll_CheckedChanged);
        }
        private void LoadComboSystemAndTime()
        {
            mCboSysTime = CacheService.Instance.Get<OCSACTCboTimeAndSystemArgs, OCSACTCboTimeAndSystemResult>(new OCSACTCboTimeAndSystemArgs(), delegate(OCSACTCboTimeAndSystemResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.CboSystem != null && r.CboSystem.Count > 0
                        && r.CboTime != null && r.CboTime.Count > 0;
                });

        }

        #endregion

        #region GetDefaultJearyo
        /// <summary>
        /// GetDefaultJearyo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetDefaultJearyo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            List<OCSACTDefaultJearyoInfo> lstInfo = new List<OCSACTDefaultJearyoInfo>();

            //MED-9279
            if (isFirstLoad)
            {
                if (mGroupedResult != null && mGroupedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = mGroupedResult.GrdDefaultLst;
                }
            }
            else
            {
                OCSACTDefaultJearyoArgs args = new OCSACTDefaultJearyoArgs();
                args.HangmogCode = bvc["f_hangmog_code"].VarValue;
                OCSACTDefaultJearyoResult res = CloudService.Instance.Submit<OCSACTDefaultJearyoResult, OCSACTDefaultJearyoArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = res.DefaultJearyoLst;
                }
            }

            lstInfo.ForEach(delegate(OCSACTDefaultJearyoInfo item)
                    {
                        lObj.Add(new object[]
                        {
                            item.SetHangmogCode,
                            item.Suryang,
                            item.Danui,
                            item.DanuiName,
                        });
                    });

            return lObj;
        }
        #endregion

        #region GetGrdJaeryo
        /// <summary>
        /// GetGrdJaeryo
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdJaeryo(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            List<OCSACTGrdJearyoInfo> lstInfo = new List<OCSACTGrdJearyoInfo>();

            //MED-9279
            if (isFirstLoad)
            {
                if (mGroupedResult != null && mGroupedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = mGroupedResult.GrdJearyoLst;
                }
            }
            else
            {
                OCSACTGrdJearyoArgs args = new OCSACTGrdJearyoArgs();
                args.Bunho = bvc["f_bunho"].VarValue;
                args.Fkocs = bvc["f_fkocs"].VarValue;
                args.IoGubun = bvc["f_io_gubun"].VarValue;
                args.JundalPart = bvc["f_jundal_part"].VarValue;
                args.OrderDate = bvc["f_order_date"].VarValue;
                OCSACTGrdJearyoResult res = CloudService.Instance.Submit<OCSACTGrdJearyoResult, OCSACTGrdJearyoArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = res.GrdJearyoLst;
                }
            }

            lstInfo.ForEach(delegate(OCSACTGrdJearyoInfo item)
                    {
                        lObj.Add(new object[]
                        {
                            item.JaeryoCode,
                            item.JaeryoName,
                            item.Suryang,
                            item.OrdDanui,
                            item.Pkinv1001,
                            item.Bunho,
                            item.OrderDate,
                            item.IoGubun,
                            item.ActingDate,
                            item.JundalPart,
                            item.InOutGubun,
                            item.Fkocs,
                            item.DanuiName,
                            item.Bunryu2,
                            item.JaeryoGubun,
                            item.JaeryoYn,
                            item.InputControl,
                            item.BunCode,
                            item.Nalsu,
                            item.IoGubunPkocs,
                        });
                    });

            return lObj;
        }
        #endregion

        #region GetGrdSangByung
        /// <summary>
        /// GetGrdSangByung
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSangByung(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (isFirstLoad)
            {
                if (mGroupedResult != null && mGroupedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    mGroupedResult.GrdSangLst.ForEach(delegate(OCSACTGrdSangByungInfo item)
                    {
                        lObj.Add(new object[] { item.SangName });
                    });
                }
            }
            else
            {
                OCSACTGrdSangByungArgs args = new OCSACTGrdSangByungArgs();
                args.Bunho = bvc["f_bunho"].VarValue;
                args.OrderDate = bvc["f_order_date"].VarValue;
                OCSACTGrdSangByungResult res = CloudService.Instance.Submit<OCSACTGrdSangByungResult, OCSACTGrdSangByungArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    res.GrdSangByungLst.ForEach(delegate(OCSACTGrdSangByungInfo item)
                    {
                        lObj.Add(new object[] { item.SangName });
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetCboSystem
        /// <summary>
        /// GetCboSystem
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboSystem(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //ComboResult res = CacheService.Instance.Get<OCSACTCboSystemArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_OCSACT_CBO_SYSTEM,
            //    new OCSACTCboSystemArgs(), delegate(ComboResult r)
            //    {
            //        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem != null && r.ComboItem.Count > 0;
            //    });

            if (this.mCboSysTime != null && this.mCboSysTime.ExecutionStatus == ExecutionStatus.Success)
            {
                this.mCboSysTime.CboSystem.ForEach(delegate(ComboListItemInfo item)
                {
                    if (item.Code == "%"
                        /*|| item.Code == "OCS_ACT_PART_02"
                        || item.Code == "OCS_ACT_PART_04"
                        || item.Code == "OCS_ACT_PART_08"*/)
                    {
                        lObj.Add(new object[] { item.Code, item.CodeName });
                    }
                });
            }

            //// Simple version
            lObj.Add(new object[] { "TST", Resources.TST_TXT });
            lObj.Add(new object[] { "INJ", Resources.INJ_TXT });
            lObj.Add(new object[] { "CPL", Resources.CPL_TXT });
            lObj.Add(new object[] { "PFE", Resources.PFE_TXT });

            return lObj;
        }
        #endregion

        #region GetCboIoGubun
        /// <summary>
        /// GetCboIoGubun
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboIoGubun(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            ComboResult res = CacheService.Instance.Get<OCSACTCboIoGubunArgs, ComboResult>(new OCSACTCboIoGubunArgs(), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem != null && r.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboTime
        /// <summary>
        /// GetCboTime
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboTime(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //ComboResult res = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_NUR0102_CBOTIME,
            //    new ComboNUR0102CboTimeArgs(), delegate(ComboResult r)
            //    {
            //        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem != null && r.ComboItem.Count > 0;
            //    });

            if (this.mCboSysTime != null && this.mCboSysTime.ExecutionStatus == ExecutionStatus.Success)
            {
                this.mCboSysTime.CboTime.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
                });
            }

            return lObj;
        }
        #endregion

        #region grdPaList_PreEndInitializing
        /// <summary>
        /// grdPaList_PreEndInitializing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdPaList_PreEndInitializing()
        {
            try
            {
                //xEditGridCell1.ExecuteQuery = GetCboIoGubun;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region GetListCboPartAndActor
        /// <summary>
        /// GetListCboPartAndActor
        /// </summary>
        private void GetListCboPartAndActor()
        {
            OCSACTCboSystemSelectedIndexChangedResult res = new OCSACTCboSystemSelectedIndexChangedResult();

            OCSACTCboSystemSelectedIndexChangedArgs args = new OCSACTCboSystemSelectedIndexChangedArgs();
            //args.CodeType = cboSystem.GetDataValue();
            //args.SystemId = EnvironInfo.CurrSystemID;
            //args.HoDong = UserInfo.HoDong;
            args.CodeType = "";
            args.SystemId = cboSystem.GetDataValue();
            args.HoDong = "";
            res = CloudService.Instance.Submit<OCSACTCboSystemSelectedIndexChangedResult,
                OCSACTCboSystemSelectedIndexChangedArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _cboRes = res;
            }
        }
        #endregion

        #region GetCboPart
        /// <summary>
        /// GetCboPart
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboPart(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //if (null != _cboRes)
            //{
            //    _cboRes.CboPartItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            NuroRES0102U00CboGwaArgs args = new NuroRES0102U00CboGwaArgs();
            args.HospCode = UserInfo.HospCode;
            args.AppDate = String.Format("{0:yyyy/MM/dd}", DateTime.Now);
            args.HospCodeLink = "";
            args.TabIsAll = true;
            NuroRES0102U00CboGwaResult res = CloudService.Instance.Submit<NuroRES0102U00CboGwaResult, NuroRES0102U00CboGwaArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CboItemInfo.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboActor
        /// <summary>
        /// GetCboActor
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetCboActor(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            //if (null != _cboRes)
            //{
            //    _cboRes.CbxActorItem.ForEach(delegate(ComboListItemInfo item)
            //    {
            //        lObj.Add(new object[] { item.Code, item.CodeName });
            //    });
            //}

            // Simple version
            
            if (grdPaList.RowCount == 0)
            {
                jundalTb = this.cboSystem.GetDataValue();
            }
            else
            {
                jundalTb = jundalTable;
            }
            //if (jundalTable == string.Empty)
            //{
            //    jundalTb = this.cboSystem.GetDataValue();
            //}
            //else
            //{
            //    jundalTb = jundalTable;
            //}
            OCSACT2GetComboUserArgs args = new OCSACT2GetComboUserArgs();
            args.HospCode = UserInfo.HospCode;
            args.JundalTable = jundalTb;
            
            
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCSACT2GetComboUserArgs>(args);
            
           

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ComboItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPaList
        /// <summary>
        /// GetGrdPaList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPaList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            List<OCSACTGrdPaListInfo> lstInfo = new List<OCSACTGrdPaListInfo>();

            //MED-9279
            if (isFirstLoad)
            {
                OCSACTGroupedPatientAndOrderArgs args = new OCSACTGroupedPatientAndOrderArgs();
                args.ActGubun = bvc["f_act_gubun"].VarValue;
                args.Bunho = bvc["f_bunho"].VarValue;
                args.CboPart = bvc["f_cbo_part"].VarValue;
                args.CboSystem = bvc["f_cbo_system"].VarValue;
                args.CboVal = bvc["f_cbo_val"].VarValue;
                args.FromDate = bvc["f_from_date"].VarValue;
                args.IoGubun = bvc["f_io_gubun"].VarValue;
                args.JundalTableCode = bvc["f_jundal_table_code"].VarValue;
                args.SystemId = bvc["f_system_id"].VarValue;
                args.ToDate = bvc["f_to_date"].VarValue;
                mGroupedResult = CloudService.Instance.Submit<OCSACTGroupedPatientAndOrderResult, OCSACTGroupedPatientAndOrderArgs>(args);
                if (mGroupedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = mGroupedResult.GrdPaLst;
                }
            }
            else
            {
                OCSACTGrdPaListArgs args = new OCSACTGrdPaListArgs();
                args.ActGubun = bvc["f_act_gubun"].VarValue;
                args.Bunho = bvc["f_bunho"].VarValue;
                args.CboPart = bvc["f_cbo_part"].VarValue;
                args.CboSystem = bvc["f_cbo_system"].VarValue;
                args.CboVal = bvc["f_cbo_val"].VarValue;
                args.FromDate = bvc["f_from_date"].VarValue;
                args.IoGubun = bvc["f_io_gubun"].VarValue;
                args.JundalTableCode = bvc["f_jundal_table_code"].VarValue;
                args.SystemId = bvc["f_system_id"].VarValue;
                args.ToDate = bvc["f_to_date"].VarValue;
                OCSACTGrdPaListResult res = CloudService.Instance.Submit<OCSACTGrdPaListResult, OCSACTGrdPaListArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = res.GrdPaLst;
                }
            }

            lstInfo.ForEach(delegate(OCSACTGrdPaListInfo item)
                    {
                        if (item.InOutGubun == "O")
                        {
                            item.InOutGubun = Resources.OUT_GUBUN;
                        }
                        else
                        {
                            item.InOutGubun = Resources.IN_GUBUN;
                        }
                        lObj.Add(new object[]
                        {
                            item.InOutGubun,
                            item.Bunho,
                            item.Suname,
                            item.Suname2,
                            item.Gwa,
                            item.GwaName,
                            item.Doctor,
                            item.DoctorName,
                            item.JundalTable,
                            item.ReserYn,
                            item.Emergency,
                            item.Trial,
                        });
                    });

            return lObj;
        }

        #endregion

        #region GetGrdOrder
        /// <summary>
        /// GetGrdOrder
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOrder(BindVarCollection bvc)
        {
            //MED-9279
            string ioGubun = "";
            IList<object[]> lObj = new List<object[]>();
            List<OCSACTGrdOrderInfo> lstInfo = new List<OCSACTGrdOrderInfo>();

            if (isFirstLoad && mGroupedResult != null)
            {
                if (mGroupedResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = mGroupedResult.GrdOrderLst;
                }
            }
            else
            {
                OCSACTGrdOrderArgs args = new OCSACTGrdOrderArgs();
                args.RbxNonAct = rbxNonAct.Checked;
                args.RbxAct = rbxAct.Checked;
                args.CboSystem = bvc["f_cbo_system"].VarValue;
                args.CboVal = bvc["f_cbo_val"].VarValue;
                if (bvc["f_io_gubun"].VarValue.Equals(Resources.OUT_GUBUN))
                {
                    ioGubun = "O";

                }
                else
                {
                    ioGubun = "I";
                }
                //args.IoGubun = ioGubun;
                args.IoGubun = "O";

                args.ActGubun = bvc["f_act_gubun"].VarValue;
                args.FromDate = bvc["f_from_date"].VarValue;
                args.ToDate = bvc["f_to_date"].VarValue;
                args.JundalTableCode = bvc["f_jundal_table_code"].VarValue;
                args.JundalPart = bvc["f_jundal_part"].VarValue;
                args.Bunho = bvc["f_bunho"].VarValue;
                args.Gwa = bvc["f_gwa"].VarValue;
                args.Doctor = bvc["f_doctor"].VarValue;
                args.SystemId = bvc["f_system_id"].VarValue;
                args.CboPart = bvc["f_cbo_part"].VarValue;
                OCSACTGrdOrderResult res = CloudService.Instance.Submit<OCSACTGrdOrderResult, OCSACTGrdOrderArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    lstInfo = res.GrdOrderItem;
                }
            }

            lstInfo.ForEach(delegate(OCSACTGrdOrderInfo item)
                    {

                        lObj.Add(new object[]
                        {
                            item.InOutGubun,
                            item.Pkocs1003,
                            item.ActYn,
                            item.HangmogCode,
                            item.HangmogName,
                            item.JubsuDate,
                            item.JubsuTime,
                            item.ActingDate,
                            item.ActingTime,
                            item.OrderDate,
                            item.OrderTime,
                            item.ReserDate,
                            item.ReserTime,
                            item.ActDoctor,
                            item.ActDoctorName,
                            item.ActBuseo,
                            item.ActGwa,
                            item.Bunho,
                            item.Suname,
                            item.Suname2,
                            item.Gwa,
                            item.GwaName,
                            item.Doctor,
                            item.DoctorName,
                            item.OrderRemark,
                            item.Birth,
                            item.SexAge,
                            item.WeightHeight,
                            item.CodeName,
                            item.PaceMakerYn,
                            item.EmptyString,
                            item.ActDate,
                            item.PatientComment,
                            item.JundalTable,
                            item.JundalPart,
                            item.Fkout1001,
                            item.ReserYn,
                            item.Emergency,
                            item.OldActYn,
                            item.IfDataSendYn,
                            item.SpecificComment,
                            item.SortFkocskey,
                            item.InputControl,
                            item.BunCode,
                            item.Suryang,
                            item.Nalsu,
                        });
                    });

            return lObj;
        }
        #endregion

        #region GetMlayConstantAlarm
        /// <summary>
        /// GetMlayConstantAlarm
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetMlayConstantAlarm(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            LayConstantInfoResult res = CloudService.Instance.Submit<LayConstantInfoResult, OCSACTLayconstantAlarmArgs>(new OCSACTLayconstantAlarmArgs());

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayConstantItem.ForEach(delegate(LayConstantInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName, item.CodeValue });
                });
            }

            return lObj;
        }
        #endregion

        #region GetMlayConstantConst
        /// <summary>
        /// GetMlayConstantConst
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetMlayConstantConst(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            LayConstantInfoResult res = CloudService.Instance.Submit<LayConstantInfoResult, OCSACTLayconstantConstArgs>(new OCSACTLayconstantConstArgs());

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayConstantItem.ForEach(delegate(LayConstantInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName, item.CodeValue });
                });
            }

            return lObj;
        }
        #endregion

        #region GetFindWorker
        /// <summary>
        /// GetFindWorker
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetFindWorker(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCSACTGetFindWorkerArgs args = new OCSACTGetFindWorkerArgs();
            args.ColName = bvc["f_col_name"].VarValue;
            args.Arg1 = bvc["f_arg1"].VarValue;
            OCSACTGetFindWorkerResult res = CloudService.Instance.Submit<OCSACTGetFindWorkerResult, OCSACTGetFindWorkerArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.FwItem.ForEach(delegate(OCSACTGetFindWorkerInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.OrdDanui,
                        item.CodeName,
                        item.Seq,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region MakeGrdOrderItemForUpdate
        /// <summary>
        /// MakeGrdOrderItemForUpdate
        /// </summary>
        /// <param name="dtRow"></param>
        /// <param name="dlg"></param>
        /// <returns></returns>
        private OCSACTUpdateGrdOrderInfo MakeGrdOrderItemForUpdate(DataRow dtRow, ChangeOrderCode dlg)
        {
            OCSACTUpdateGrdOrderInfo grdOrderItem = new OCSACTUpdateGrdOrderInfo();
            grdOrderItem.ActDoctor = dtRow["act_doctor"].ToString();
            grdOrderItem.Fkout1001 = dtRow["fkout1001"].ToString();
            grdOrderItem.GrdOrderActingDate = dtRow["acting_date"].ToString();
            grdOrderItem.GrdOrderActingTime = dtRow["acting_time"].ToString();
            grdOrderItem.GrdOrderActYn = dtRow["act_yn"].ToString();
            grdOrderItem.GrdOrderInOutGubun = dtRow["in_out_gubun"].ToString();
            grdOrderItem.GrdOrderSortFkocskey = dtRow["sort_fkocskey"].ToString();
            if (dlg != null)
            {
                grdOrderItem.HangmogCode = dlg.selectedOrder;
                grdOrderItem.Remark = dlg.selectedOrderName;
            }
            grdOrderItem.InputControl = dtRow["input_control"].ToString();
            grdOrderItem.InputGubun = UserInfo.InputGubun;
            grdOrderItem.JubsuDate = dtRow["jubsu_date"].ToString();
            grdOrderItem.JubsuTime = dtRow["jubsu_time"].ToString();
            grdOrderItem.JundalPart = dtRow["jundal_part"].ToString();
            grdOrderItem.Nalsu = dtRow["nalsu"].ToString();
            grdOrderItem.Pkocs = dtRow["pkocs"].ToString();
            grdOrderItem.Suryang = dtRow["suryang"].ToString();

            //MED-11182
            grdOrderItem.Pkocs1003 = dtRow["pkocs"].ToString();

            return grdOrderItem;
        }
        #endregion

        #region MakeGrdJaeryoItemForUpdate
        /// <summary>
        /// MakeGrdJaeryoItemForUpdate
        /// </summary>
        /// <param name="dtRow"></param>
        /// <returns></returns>
        private OCSACTUpdJaeryoProcessInfo MakeGrdJaeryoItemForUpdate(DataRow dtRow)
        {
            OCSACTUpdJaeryoProcessInfo updJaeryoItem = new OCSACTUpdJaeryoProcessInfo();
            updJaeryoItem.BomSourceKey = this.newOcsKey;
            updJaeryoItem.Divide = "1";
            updJaeryoItem.DtRowFirstVal = dtRow.ItemArray.GetValue(0).ToString();
            updJaeryoItem.DvTime = "*";
            updJaeryoItem.HangmogCode = dtRow["hangmog_code"].ToString();
            updJaeryoItem.InputId = UserInfo.UserID;
            updJaeryoItem.IudGubun = "N/A";
            updJaeryoItem.Nalsu = dtRow["nalsu"].ToString();
            updJaeryoItem.OrdDanui = dtRow["ord_danui"].ToString();
            updJaeryoItem.OrderGubun = "N/A";
            updJaeryoItem.Pkinv1001 = dtRow["pkinv1001"].ToString();
            updJaeryoItem.Pkocs2003 = dtRow["fkocs_inv"].ToString();
            updJaeryoItem.Suryang = dtRow["suryang"].ToString();
            updJaeryoItem.SysId = UserInfo.UserID;
            updJaeryoItem.FkocsXrt = dtRow["fkocs_xrt"].ToString();
            updJaeryoItem.FkocsInv = dtRow["fkocs_inv"].ToString();
            updJaeryoItem.RowState = dtRow.RowState.ToString();

            //MED-11182
            updJaeryoItem.Pkocs1003 = dtRow["in_out_gubun"].ToString();

            return updJaeryoItem;
        }
        #endregion

        #region GetGrdRowFocusChanged
        /// <summary>
        /// GetGrdRowFocusChanged
        /// </summary>
        private void GetGrdRowFocusChanged()
        {
            OCSACTGrdRowFocusChangedResult res = new OCSACTGrdRowFocusChangedResult();

            OCSACTGrdRowFocusChangedArgs args = new OCSACTGrdRowFocusChangedArgs();
            args.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            args.Fkocs = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs");
            args.IoGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
            args.JundalPart = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part");
            args.OrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            res = CloudService.Instance.Submit<OCSACTGrdRowFocusChangedResult, OCSACTGrdRowFocusChangedArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                this._grdRes = res;
            }
        }
        #endregion

        #region GetGrdJaeryoForGrdRowFocusChanged
        /// <summary>
        /// GetGrdJaeryoForGrdRowFocusChanged
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdJaeryoForGrdRowFocusChanged(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (null != this._grdRes)
            {
                this._grdRes.JearyoItem.ForEach(delegate(OCSACTGrdJearyoInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.Suryang,
                        item.OrdDanui,
                        item.Pkinv1001,
                        item.Bunho,
                        item.OrderDate,
                        item.IoGubun,
                        item.ActingDate,
                        item.JundalPart,
                        item.InOutGubun,
                        item.Fkocs,
                        item.DanuiName,
                        item.Bunryu2,
                        item.JaeryoGubun,
                        item.JaeryoYn,
                        item.InputControl,
                        item.BunCode,
                        item.Nalsu,
                        item.IoGubunPkocs,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdSangByungForGrdRowFocusChanged
        /// <summary>
        /// GetGrdSangByungForGrdRowFocusChanged
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdSangByungForGrdRowFocusChanged(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            if (null != this._grdRes)
            {
                this._grdRes.SangbyungItem.ForEach(delegate(OCSACTGrdSangByungInfo item)
                {
                    lObj.Add(new object[] { item.SangName });
                });
            }

            return lObj;
        }
        #endregion

        #region Caching init data
        private void LoadDataOpenScreenFirst()
        {
            OCSACTCompositeFirstArgs compositeArgs = new OCSACTCompositeFirstArgs();

            //init default param for OCSACTCboSystemSelectedIndexChangedArgs
            OCSACTCboSystemSelectedIndexChangedArgs cboSystemArgs = new OCSACTCboSystemSelectedIndexChangedArgs();
            cboSystemArgs.CodeType = cboSystem.GetDataValue();
            cboSystemArgs.SystemId = EnvironInfo.CurrSystemID;
            cboSystemArgs.HoDong = UserInfo.HoDong;
            compositeArgs.CboSystemEventParam = cboSystemArgs;

            //init default param for OCSACTLayconstantAlarmArgs
            compositeArgs.LayAlarmParam = new OCSACTLayconstantAlarmArgs();

            //init default param for OCSACTLayconstantConstArgs
            compositeArgs.LayConstParam = new OCSACTLayconstantConstArgs();

            OCSACTCompositeFirstResult compositeResult = CloudService.Instance.Submit<OCSACTCompositeFirstResult, OCSACTCompositeFirstArgs>(compositeArgs, true, CallbackOCSACTCompositeFirst);
        }

        private static Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackOCSACTCompositeFirst(OCSACTCompositeFirstArgs args, OCSACTCompositeFirstResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheSession = new Dictionary<object, KeyValuePair<int, object>>();

            cacheSession.Add(args.CboSystemEventParam, new KeyValuePair<int, object>(1, result.CboSystemEventList));
            cacheSession.Add(args.LayAlarmParam, new KeyValuePair<int, object>(1, result.LayAlarmList));
            cacheSession.Add(args.LayConstParam, new KeyValuePair<int, object>(1, result.LayConstList));

            cacheData.Add(CachePolicy.ONCE, cacheSession);

            return cacheData;
        }

        #endregion

        private void xRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Simple version

        private const string INJ = "INJ";
        private const string CPL = "CPL";
        private const string TST = "TST";
        private const string PFE = "PFE";
        private string emrRecordID = "";
        private string emrRecordMetaData = "";
        //private bool flag1 = false;
        //private bool flag2 = false;
        private void InitSimpleLayout()
        {
            this.GetListCboPartAndActor();

            //this.cboPart.ExecuteQuery = GetCboPart;
            //this.cboPart.SetDictDDLB();

            this.cboPart.DataSource = null;
            this.cboPart.ComboItems.Clear();
            this.cboPart.ComboItems.Add("", Resources.cboPartAll);

            //this.cbxActor.ExecuteQuery = GetCboActor;
            //this.cbxActor.SetDictDDLB();

            // Default checked
            //HoangVV - MED-12885
            //flag1 = false;
            this.rbxINJ.Checked = true;
            //flag1 = true;
            //========
            this.cboSystem.Enabled = true;
            this.cboSystem.SetDataValue("%");
            this.cboPart.SetDataValue("01");
        }

        private void rbxDep_CheckedChanged(object sender, EventArgs e)
        {
            //HoangVV MED-12885
            //if (flag1 == false && flag2 == false) return;
            XRadioButton rbx = sender as XRadioButton;

            if (!rbx.Checked) return;

            // Hide/unhide bottom panel
            this.ButtonVisibleControl();
          
            this.grdPaList.RowFocusChanged -= grd_RowFocusChanged;

            this.rbxINJ.BackColor = XColor.DockingGradientStartColor;
            this.rbxCPL.BackColor = XColor.DockingGradientStartColor;
            this.rbxTST.BackColor = XColor.DockingGradientStartColor;
            this.rbxPFE.BackColor = XColor.DockingGradientStartColor;

            this.rbxINJ.ForeColor = XColor.NormalForeColor;
            this.rbxCPL.ForeColor = XColor.NormalForeColor;
            this.rbxTST.ForeColor = XColor.NormalForeColor;
            this.rbxPFE.ForeColor = XColor.NormalForeColor;

            switch (rbx.Name)
            {
                case "rbxINJ":
                    this.SelectTabInjs(rbx);
                    this.FocusToOrderByJundalTable(grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"), INJ);
                    jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
                    //this.cbxActor.ExecuteQuery = GetCboActor;
                    //this.cbxActor.SetDictDDLB();
                    //this.SwitchTab(INJ);
                    //this.SetTabColor(INJ, grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
                    break;
                case "rbxCPL":
                    this.SelectTabCpls(rbx);
                    this.FocusToOrderByJundalTable(grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"), CPL);
                    jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
                    //this.cbxActor.ExecuteQuery = GetCboActor;
                    //this.cbxActor.SetDictDDLB();
                    //this.SwitchTab(CPL);
                    //this.SetTabColor(CPL, grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
                    //MED-10095
                    if (rbxAct.Checked)
                    {
                        this.ucBtn.SetVisibleBtnBarcode(true);
                    }
                    else
                    {
                        this.ucBtn.SetVisibleBtnBarcode(false);
                    }
                    break;
                case "rbxPFE":
                    this.SelectTabOCSACT(rbx);
                    this.FocusToOrderByJundalTable(grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"), PFE);
                    jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
                    //this.cbxActor.ExecuteQuery = GetCboActor;
                    //this.cbxActor.SetDictDDLB();
                    //this.SwitchTab(PFE);
                    //this.SetTabColor(PFE, grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
                    break;
                case "rbxTST":
                    this.SelectTabOCSACT(rbx);
                    this.FocusToOrderByJundalTable(grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"), TST);
                    jundalTable = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table");
                    //this.cbxActor.ExecuteQuery = GetCboActor;
                    //this.cbxActor.SetDictDDLB();
                    //this.SwitchTab(TST);
                    //this.SetTabColor(TST, grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
                    break;
                default:
                    break;
            }

            this.grdPaList.RowFocusChanged += grd_RowFocusChanged;
        }

        /// <summary>
        /// SelectTabInjs
        /// </summary>
        /// <param name="rbx"></param>
        private void SelectTabInjs(XRadioButton rbx)
        {
            // Checked on radio button
            //rbx.ImageIndex = 1;
            rbx.BackColor = XColor.DockingGradientEndColor;
            //rbx.ForeColor = XColor.ErrMsgForeColor;

            //this.xPanelControl.Visible = true;
            this.cpl2010U00.Visible = false;
            //this.cpl2010U00.Dock = DockStyle.None;
            this.inj1001U01.Visible = true;
            //this.inj1001U01.Dock = DockStyle.Fill;
            //this.inj1001U01.BringToFront();
            //this.inj1001U01.Dock = DockStyle.Fill;
            // https://sofiamedix.atlassian.net/browse/MED-14740
            this.grdOrder.Visible = false;
            this.grdJaeryo.Visible = false;
            this.btnExpandOrdgrid.Visible = false;
        }

        /// <summary>
        /// SelectTabCpls
        /// </summary>
        /// <param name="rbx">Tab CPLS</param>
        private void SelectTabCpls(XRadioButton rbx)
        {
            // Checked on radio button
            //rbx.ImageIndex = 1;
            rbx.BackColor = XColor.DockingGradientEndColor;
            //rbx.ForeColor = XColor.ErrMsgForeColor;

            //this.xPanelControl.Visible = true;
            this.inj1001U01.Visible = false;
            //this.inj1001U01.Dock = DockStyle.None;
            this.cpl2010U00.Visible = true;
            //this.cpl2010U00.BringToFront();
            //this.cpl2010U00.Dock = DockStyle.Fill;
            this.cpl2010U00.BringToFront();
            //this.cpl2010U00.Dock = DockStyle.Fill;
            // https://sofiamedix.atlassian.net/browse/MED-14740
            this.grdOrder.Visible = false;
            this.grdJaeryo.Visible = false;
            this.btnExpandOrdgrid.Visible = false;
        }

        /// <summary>
        /// SelectTabOCSACT
        /// </summary>
        /// <param name="rbx">PFE/TST</param>
        private void SelectTabOCSACT(XRadioButton rbx)
        {
            // Checked on radio button
            //rbx.ImageIndex = 1;
            rbx.BackColor = XColor.DockingGradientEndColor;
            //rbx.ForeColor = XColor.ErrMsgForeColor;

            // https://sofiamedix.atlassian.net/browse/MED-14740
            this.cpl2010U00.Visible = false;
            //this.cpl2010U00.Dock = DockStyle.None;
            this.inj1001U01.Visible = false;
            //this.inj1001U01.Dock = DockStyle.None;
            this.grdOrder.Visible = true;
            //this.grdOrder.BringToFront();
            this.grdJaeryo.Visible = true;
            this.btnExpandOrdgrid.Visible = true;
            //this.grdJaeryo.BringToFront();
        }

        private void SetDataCboPart(OCSACT2GetGrdPaListResult res,string gwa)
        {

            this.cboPart.SelectionChangeCommitted -= new System.EventHandler(this.cboPart_SelectedIndexChanged);

            this.cboPart.DataSource = null;
            this.cboPart.ComboItems.Clear();
            this.cboPart.ComboItems.Add("", Resources.cboPartAll);
            for (int i = 0; i < res.PaItem.Count; i++)
            {
                if (!CheckContainGwa(cboPart.ComboItems, res.PaItem[i].Gwa))
                {
                    string code = res.PaItem[i].Gwa;
                    string name = res.PaItem[i].GwaName;

                    this.cboPart.ComboItems.Add(code, name);
                }
            }

            this.cboPart.DataSource = this.cboPart.ComboItems;
            this.cboPart.ValueMember = "ValueItem";
            this.cboPart.DisplayMember = "DisplayItem";
            this.cboPart.SelectedValue = gwa;

            this.cboPart.SelectionChangeCommitted += new System.EventHandler(this.cboPart_SelectedIndexChanged);
        }

        private bool CheckContainGwa(XComboItemCollection xComboItemCollection, string gwa)
        {
            for (int i = 0; i < xComboItemCollection.Count; i++)
            {
                if (xComboItemCollection[i].ValueItem.Equals(gwa))
                    return true;
            }
            return false;
        }

        private List<object[]> GetGrdPaList2(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            OCSACT2GetGrdPaListArgs args = new OCSACT2GetGrdPaListArgs();
            args.ActingFlg = bc["f_acting_flg"].VarValue;
            args.Bunho = bc["f_bunho"].VarValue;
            args.Gwa = bc["f_gwa"].VarValue;
            //args.Gwa = "01";
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.JundalTable = bc["f_jundal_table"].VarValue;
            args.OrderDateFrom = bc["f_order_date_from"].VarValue;
            args.OrderDateTo = bc["f_order_date_to"].VarValue;
            OCSACT2GetGrdPaListResult res = CloudService.Instance.Submit<OCSACT2GetGrdPaListResult, OCSACT2GetGrdPaListArgs>(args);

            //Set cboPart
            SetDataCboPart(res, args.Gwa);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
               
                res.PaItem.ForEach(delegate(OCSACT2GetGrdPaListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.TrialFlg,
                        item.Suname,
                        item.JundalTable,
                        this.GetDepartmentName(item.JundalTable),
                        item.Gwa,
                        item.GwaName,
                        item.Doctor,
                        item.DoctorName,
                        item.Suname2,
                        item.Bunho,
                        item.Pkocs1003,
                        item.Fkout1001,
                        item.ReserGubun,
                        item.OrderDate,
                        item.ReserDate,
                        item.InOutGubun,
                        item.ReserYn,
                        item.KijunDate,
                        item.NaewonTime,
                        item.EmergencyYn,
                        item.ActingYn

                       
                    });
                   
                });
            }

            return lObj;
        }

        private string GetDepartmentName(string jundalTable)
        {
            string deptName = "";

            switch (jundalTable)
            {
                case TST:
                    deptName = Resources.TST_TXT;
                    break;
                case INJ:
                    deptName = Resources.INJ_TXT;
                    break;
                case CPL:
                    deptName = Resources.CPL_TXT;
                    break;
                case PFE:
                    deptName = Resources.PFE_TXT;
                    break;
                default:
                    break;
            }

            return deptName;
        }

        private void SwitchTab(string jundalTable)
        {
            switch (jundalTable)
            {
                case TST:
                    rbxTST.Checked = true;
                    this.grdOrder.QueryLayout(false);
                    break;
                case INJ:
                    this.inj1001U01.RbtWait = this.rbxNonAct;
                    this.inj1001U01.RbtDone = this.rbxAct;
                    this.inj1001U01.DtpQueryDate = this.dtpFromDate;
                    //this.inj1001U01.PatInfo = this.paBox;
                    this.inj1001U01.Bunho = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");
                    //this.inj1001U01.JubsuDate = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jubsu_date");
                    this.inj1001U01.JubsuDate = "";
                    this.inj1001U01.OrderDate = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "order_date");
                    this.inj1001U01.Gwa = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "gwa");
                    this.inj1001U01.Doctor = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "doctor");
                    this.inj1001U01.Actor = dbxDocCode.GetDataValue();
                    this.inj1001U01.ActorName = dbxDocName.Text;
                    rbxINJ.Checked = true;
                    this.inj1001U01.OpenScreen();
                    break;
                case CPL:
                    rbxCPL.Checked = true;
                    this.cpl2010U00.RbxJubsu = this.rbxAct;
                    this.cpl2010U00.RbxMijubsu = this.rbxNonAct;
                    this.cpl2010U00.DtpOrderDate = this.dtpFromDate;
                    this.cpl2010U00.DtpOrderToDate = this.dtpToDate;
                    //this.cpl2010U00.PaBox = this.paBox;
                    this.cpl2010U00.CbxActor = this.dbxDocCode;
                    this.cpl2010U00.Bunho = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");
                    this.cpl2010U00.ReserYn = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "reser_yn");
                    this.cpl2010U00.EmergencyYn = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "emergency");
                    this.cpl2010U00.Doctor = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "doctor");
                    this.cpl2010U00.OpenScreen();
                    break;
                case PFE:
                    rbxPFE.Checked = true;
                    this.grdOrder.QueryLayout(false);
                    break;
                default:
                    break;
            }
        }

        private void ResetGrids(string jundalTable)
        {
            switch (jundalTable)
            {
                case INJ:
                    this.inj1001U01.GrdDetail.Reset();
                    this.inj1001U01.GrdOCS1003.Reset();
                    break;
                case CPL:
                    this.cpl2010U00.GrdOrder.Reset();
                    this.cpl2010U00.GrdTube.Reset();
                    this.cpl2010U00.GrdSpecimen.Reset();
                    break;
                case PFE:
                case TST:
                    grdJaeryo.Reset();
                    grdOrder.Reset();
                    break;
                default:
                    break;
            }
        }

        private void LoadExpandPatientInfo(string bunho, string gwa, string naewonDate)
        {
            OCSACT2GetPatientExpandArgs args = new OCSACT2GetPatientExpandArgs();
            // OCS2015U06EmrRecordArgs
            
            args.EmrRecordItem = new IHIS.CloudConnector.Contracts.Arguments.OcsEmr.OCS2015U06EmrRecordArgs();
            args.EmrRecordItem.Bunho = bunho;
            args.EmrRecordItem.HospCode = UserInfo.HospCode;
            // OUT0106U00GridListArgs
            args.GridListItem = new IHIS.CloudConnector.Contracts.Arguments.Outs.OUT0106U00GridListArgs();
            args.GridListItem.Bunho = bunho;
            args.GridListItem.NaewonDate = naewonDate;
            // OcsoOCS1003P01GridOutSangArgs
            args.GridOutsangItem = new OcsoOCS1003P01GridOutSangArgs();
            args.GridOutsangItem.Bunho = bunho;
            args.GridOutsangItem.Gwa = gwa;
            args.GridOutsangItem.NaewonDate = naewonDate;
            OCSACT2GetPatientExpandResult res = CloudService.Instance.Submit<OCSACT2GetPatientExpandResult, OCSACT2GetPatientExpandArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                // List special note
                if (res.GridListItem != null)
                {
                    this.listSpecialNode = res.GridListItem.GridItemInfo;
                }

                // List tags info
                string mml = "";
                res.EmrRecordItem.EmrRecordList.ForEach(delegate(OCS2015U06EmrRecordInfo item)
                {
                    mml = item.Content;
                    this.emrRecordID = item.RecordId;
                    this.emrRecordMetaData = item.Metadata;
                });

                List<EmrRecordInfo> lstRecord = new List<EmrRecordInfo>();
                if (!TypeCheck.IsNull(mml))
                {
                    EmrDocker.Types.Tuple<List<EmrRecordInfo>, PatientModelInfo> lstInfo = MmlParser.Instance.ToModel(mml);
                    lstRecord = lstInfo.V1;
                }

                //MED-10058
                lstTagInfos.Clear();
                foreach (EmrRecordInfo emrRecordInfo in lstRecord)
                {
                    foreach (TagInfo tagInfo in emrRecordInfo.TagInfos)
                    {
                        if (tagInfo.Type != TypeEnum.Tag) continue;

                        if (tagInfo.TagCode.Trim().ToUpper() == "MA" || tagInfo.TagCode.Trim().ToUpper() == "MS" || tagInfo.TagCode.Trim().ToUpper() == "MI")
                        {
                            tagInfo.CreateDate = emrRecordInfo.DateTime;
                            lstTagInfos.Add(tagInfo);
                        }
                    }
                }

                //MED-10058
                lstOutSangInfo.Clear();
                // Outsang info
                res.GridOutsangItem.GridOutSangItem.ForEach(delegate(OcsoOCS1003P01GridOutSangInfo item)
                {
                    OcsoOCS1003P01GridOutSangInfo info = new OcsoOCS1003P01GridOutSangInfo();
                    info.Bunho = item.Bunho;
                    info.Gwa = item.Gwa;
                    info.GwaName = item.GwaName;
                    info.IoGubun = item.IoGubun;
                    info.PkSeq = item.PkSeq;
                    info.NaewonDate = item.NaewonDate;
                    info.JubsuNo = item.JubsuNo;
                    info.LastNaewonDate = item.LastNaewonDate;
                    info.LastDoctor = item.LastDoctor;
                    info.LastNaewonType = item.LastNaewonType;
                    info.LastJubsuNo = item.LastJubsuNo;
                    info.Fkinp1001 = item.Fkinp1001;
                    info.InputId = item.InputId;
                    info.Ser = item.Ser;
                    info.SangCode = item.SangCode;
                    info.JuSangYn = item.JuSangYn;
                    info.SangName = item.SangName;
                    info.SangStartDate = item.SangStartDate;
                    info.SangEndDate = item.SangEndDate;
                    info.SangEndSayu = item.SangEndSayu;
                    info.PreModifier1 = item.PreModifier1;
                    info.PreModifier2 = item.PreModifier2;
                    info.PreModifier3 = item.PreModifier3;
                    info.PreModifier4 = item.PreModifier4;
                    info.PreModifier5 = item.PreModifier5;
                    info.PreModifier6 = item.PreModifier6;
                    info.PreModifier7 = item.PreModifier7;
                    info.PreModifier8 = item.PreModifier8;
                    info.PreModifier8 = item.PreModifier9;
                    info.PreModifier10 = item.PreModifier10;
                    info.PostModifierName = item.PreModifierName;
                    info.PostModifier1 = item.PostModifier1;
                    info.PostModifier2 = item.PostModifier2;
                    info.PostModifier3 = item.PostModifier3;
                    info.PostModifier4 = item.PostModifier4;
                    info.PostModifier5 = item.PostModifier5;
                    info.PostModifier6 = item.PostModifier6;
                    info.PostModifier7 = item.PostModifier7;
                    info.PostModifier8 = item.PostModifier8;
                    info.PostModifier9 = item.PostModifier9;
                    info.PostModifier10 = item.PostModifier10;
                    info.PostModifierName = item.PostModifierName;
                    info.SangJindanDate = item.SangJindanDate;
                    info.Pkoutsang = item.Pkoutsang;
                    info.DataGubun = item.DataGubun;
                    info.IfDataSendYn = item.IfDataSendYn;
                    info.DataRowSate = "";
                    info.DataGubun = "";

                    this.lstOutSangInfo.Add(info);
                });
            }
        }

        private void btnViewEMR_Click(object sender, EventArgs e)
        {
            string bunho = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");
            string gwa = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "gwa");

            if (TypeCheck.IsNull(bunho))
            {
                return;
            }

            XPatientBox paBox = new XPatientBox();
            paBox.SetPatientID(bunho);

            PatientModelInfo patient = new PatientModelInfo();
            patient.PatientId = paBox.BunHo;
            patient.PatientName = paBox.SuName + " " + paBox.SuName2;
            patient.PatientBirthday = paBox.Birth;
            patient.PatientGender = paBox.Sex;
            patient.PatientAddress = paBox.Address1;
            patient.PatientZip = paBox.Zip1 + " - " + paBox.Zip2;
            patient.PatientTelephone = paBox.Tel;
            patient.Gwa = gwa;
            patient.NaewonDate = this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "order_date");

            using (EmrReferS emrRefer = new EmrReferS(UserInfo.HospCode, gwa, bunho, this.grdPaList.GetItemString(grdPaList.CurrentRowNumber, "fkout1001"), patient))
            {
                emrRefer.Text = String.Format(Resources.EMRREFER, UserInfo.HospName);
                emrRefer.ShowDialog();
            }
        }

        private void FocusToOrderByJundalTable(string bunho, string jundalTable)
        {
            try
            {
                for (int i = 0; i < grdPaList.RowCount; i++)
                {
                    string bunhoTemp = grdPaList.GetItemString(i, "bunho");
                    string jundalTableTemp = grdPaList.GetItemString(i, "jundal_table");

                    if (bunhoTemp == bunho && jundalTableTemp == jundalTable)
                    {
                        grdPaList.SetFocusToItem(i, "trial");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Service.StartWriteLog();
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
                Service.EndWriteLog();
            }
            finally { }
        }

        #region Controls visible/invisible of button on bottom panel

        private void ButtonVisibleControl()
        {
            // Case OCSACT
            if (rbxPFE.Checked || rbxTST.Checked)
            {
                this.xPanel1.SuspendLayout();
                if (this.ucBtn != null)
                {
                    this.ucBtn.Visible = false;
                    this.xPanel3.Visible = true;
                    this.xPanel3.Dock = DockStyle.Bottom;
                }
                this.xPanel1.ResumeLayout();

                return;
            }

            // Case INJ, CPL
            // Hide OCSACT buttons
            this.xPanel3.Visible = false;

            if (rbxCPL.Checked)
            {
                this.xPanel1.SuspendLayout();

                if (this.ucBtn != null) this.ucBtn.Dispose();
                this.ucBtn = new UCBtnList(ShowMode.Cpls);
                this.ucBtn.Location = new Point(0, 763);
                this.ucBtn.Dock = DockStyle.Bottom;
                this.ucBtn.Size = new Size(1426, 38);
                this.ucBtn.BtnChangeTimeCPLClick += new EventHandler(ucBtn_BtnChangeTimeClick);
                this.ucBtn.BtnPrintSetupCPLClick += new EventHandler(ucBtn_BtnPrintSetupCPLClick);
                this.ucBtn.BtnBarcodeCPLClick += new EventHandler(ucBtn_BtnBarcodeCPLClick);
                this.ucBtn.BtnOrderCancelCPLClick += new EventHandler(ucBtn_BtnOrderCancelCPLClick);
                this.ucBtn.BtnChkAllJubsuCPLClick += new EventHandler(ucBtn_BtnChkAllJubsuCPLClick);
                this.ucBtn.BtnOrderPrintCPLClick += new EventHandler(ucBtn_BtnOrderPrintCPLClick);
                this.ucBtn.BtnListCPLClick += new ButtonClickEventHandler(ucBtn_BtnListCPLClick);
                this.xPanel1.Controls.Add(ucBtn);

                this.xPanel1.ResumeLayout();

                return;
            }

            // Case INJ
            if (rbxINJ.Checked)
            {
                this.xPanel1.SuspendLayout();

                if (this.ucBtn != null) this.ucBtn.Dispose();
                this.ucBtn = new UCBtnList(ShowMode.Injs);
                this.ucBtn.Location = new Point(0, 763);
                this.ucBtn.Dock = DockStyle.Bottom;
                this.ucBtn.Size = new Size(1426, 38);
                this.ucBtn.BtnReserClick += new EventHandler(ucBtn_BtnReserClick);
                this.ucBtn.BtnPrintSetupClick += new EventHandler(ucBtn_BtnPrintSetupClick);
                this.ucBtn.BtnReInjActScripClick += new EventHandler(ucBtn_BtnReInjActScripClick);
                this.ucBtn.BtnLabelClick += new EventHandler(ucBtn_BtnLabelClick);
                this.ucBtn.BtnReLabelClick += new EventHandler(ucBtn_BtnReLabelClick);
                this.ucBtn.BtnChkAllJubsuClick += new EventHandler(ucBtn_BtnChkAllJubsuClick);
                this.ucBtn.BtnListINJButtonClick += new ButtonClickEventHandler(ucBtn_BtnListINJButtonClick);

                this.xPanel1.Controls.Add(ucBtn);

                this.xPanel1.ResumeLayout();

                return;
            }
        }

        #region CPL buttons event

        private void ucBtn_BtnChangeTimeClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnChangeTimeClick();
        }

        private void ucBtn_BtnPrintSetupCPLClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnPrintSetupClick();
        }

        private void ucBtn_BtnBarcodeCPLClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnBarcodeClick();
        }

        private void ucBtn_BtnOrderCancelCPLClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnCancelClick();
        }

        private void ucBtn_BtnChkAllJubsuCPLClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnChkAllJubsuClick();
        }

        private void ucBtn_BtnOrderPrintCPLClick(object sender, EventArgs e)
        {
            this.cpl2010U00.HandleBtnOrderPrintClick();
        }

        private void ucBtn_BtnListCPLClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Close)
            {
                this.btnList.PerformClick(FunctionType.Close);
                return;
            }

            if (e.Func == FunctionType.Query && this.grdPaList.RowCount == 0) return;

            this.cpl2010U00.HandleButtonListClick(e.Func);
            if (e.Func == FunctionType.Query || e.Func == FunctionType.Process)
            {
                this.grdPaList.QueryLayout(true);
            }
        }

        #endregion

        #region INJ buttons event

        private void ucBtn_BtnReserClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnReserClick();
            //MED-9997 update gridview when close INJ1002U01
            grdPaList.QueryLayout(false);
        }

        private void ucBtn_BtnPrintSetupClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnPrintSetupClick();
        }

        private void ucBtn_BtnReInjActScripClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnReInjActScripClick();
        }

        private void ucBtn_BtnLabelClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnLabelClick();
        }

        private void ucBtn_BtnReLabelClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnReLabelClick();
        }

        private void ucBtn_BtnChkAllJubsuClick(object sender, EventArgs e)
        {
            this.inj1001U01.HandleBtnChkAllJubsuClick();
        }

        private void ucBtn_BtnListINJButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            if (e.Func == FunctionType.Close)
            {
                this.btnList.PerformClick(FunctionType.Close);
                return;
            }

            if (e.Func == FunctionType.Query && this.grdPaList.RowCount == 0) return;
            bool reload = false;
            this.inj1001U01.HandleButtonListClick(e.Func,out reload);
            if (e.Func == FunctionType.Query || e.Func == FunctionType.Process)
            {
                if (reload)
                {
                    this.grdPaList.QueryLayout(true);
                }
            }
        }

        #endregion

        #endregion

        private void SetEventRowFocus()
        {
            this.cpl2010U00.RowFocusHandler += new RowFocusChangedEventHandler(cpl2010U00_RowFocusHandler);
            this.inj1001U01.RowFocusHandler += new RowFocusChangedEventHandler(inj1001U01_RowFocusHandler);
            this.patientInfoBox.PatientInfoChanged += new EventHandler(patientInfoBox_PatientInfoChanged);
        }

        private void patientInfoBox_PatientInfoChanged(object sender, EventArgs e)
        {
            int aRow = grdPaList.CurrentRowNumber;
            jundalTable = grdPaList.GetItemString(aRow, "jundal_table");
            string bunho = grdPaList.GetItemString(aRow, "bunho");
            string naewonDate = grdPaList.GetItemString(aRow, "order_date");
            string gwa = grdPaList.GetItemString(aRow, "gwa");

            this.patientInfoBox.Reset();
            this.patientInfoBox.SetPatientInfo(bunho, naewonDate);
            this.LoadExpandPatientInfo(bunho, gwa, naewonDate);
            this.groupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo);
        }

        private void inj1001U01_RowFocusHandler(object sender, RowFocusChangedEventArgs e)
        {
            if (this.inj1001U01 != null)
            {
                SetValueForCbx(this.inj1001U01.JujongjaCode,this.inj1001U01.JujongjaName);
            }
        }

        private void cpl2010U00_RowFocusHandler(object sender, RowFocusChangedEventArgs e)
        {
            if (this.cpl2010U00 != null)
            {
                SetValueForCbx(cpl2010U00.CbxActorCode, this.cpl2010U00.CbxActorText);
            }
        }

        public void SetValueForCbx(string doctorCode, string doctorName)
        {
            if (TypeCheck.IsNull(doctorCode) && TypeCheck.IsNull(doctorName))
            {
                //MED-14584
                this.dbxDocCode.SetDataValue(UserInfo.UserID);
                this.dbxDocName.SetDataValue(UserInfo.UserName);
            }
            else
            {
                this.dbxDocCode.Text = doctorCode;
                this.dbxDocName.Text = doctorName;
            }
        }
        //MED-14584
        private void btnChange_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxDocCode.GetDataValue());
            param.Add("user_name", dbxDocName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        private void SetTabColor(string focusedJundalTable, string focusedBunho)
        {
            rbxINJ.ForeColor = XColor.NormalForeColor;
            rbxCPL.ForeColor = XColor.NormalForeColor;
            rbxPFE.ForeColor = XColor.NormalForeColor;
            rbxTST.ForeColor = XColor.NormalForeColor;

            for (int i = 0; i < grdPaList.RowCount; i++)
            {
                if (grdPaList.GetItemString(i, "acting_yn") == "Y") continue;

                string bunho = grdPaList.GetItemString(i, "bunho");
                string jundalTable = grdPaList.GetItemString(i, "jundal_table");

                if (bunho == focusedBunho && jundalTable != focusedJundalTable)
                {
                    switch (jundalTable)
                    {
                        case INJ:
                            rbxINJ.ForeColor = XColor.ErrMsgForeColor;
                            break;
                        case CPL:
                            rbxCPL.ForeColor = XColor.ErrMsgForeColor;
                            break;
                        case PFE:
                            rbxPFE.ForeColor = XColor.ErrMsgForeColor;
                            break;
                        case TST:
                            rbxTST.ForeColor = XColor.ErrMsgForeColor;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ApplyMultiResolution()
        {
            int width = SystemInformation.VirtualScreen.Width;
            int height = SystemInformation.VirtualScreen.Height;

            // 1600x900
            if (width == 1600 && height == 900)
            {
                this.xPanelControl.Size = new Size(this.xPanelControl.Width, this.xPanelControl.Height - 48);
                this.Height -= 50;
            }

            // 1440x900
            if (width == 1440 && height == 900)
            {
                this.xPanelControl.Size = new Size(this.xPanelControl.Width, this.xPanelControl.Height - 30);
                this.Height -= 30;
                this.Width -= 10;
            }

            // 1366x768
            if (width == 1366 && height == 768)
            {
                this.xPanelControl.Size = new Size(this.xPanelControl.Width, this.xPanelControl.Height - 180);
                this.Height -= 180;
                this.Width -= 80;
            }
        }

        #endregion
    }

    #region [sendIFinfo インタフェース情報]
    internal class sendIFinfo
    {
        public string pkOcs = "";
        public string inOutGubun = "";
        public string ifSysGubun = "";
        public string ifCmdGubun = "";
        public string userID = "";
        public string seq = "";
    }
    #endregion
}