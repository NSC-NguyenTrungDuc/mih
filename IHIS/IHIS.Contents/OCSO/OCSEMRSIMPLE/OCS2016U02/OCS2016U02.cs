using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraTreeList.Localization;
using EmrDocker.Models;
using System.Net;
using System.Net;
using EmrDocker.Types;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Arguments.Outs;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.DRGS;
using IHIS.Framework;
using IHIS.CloudConnector.Socket;
using IHIS.OCS;
using System.Threading;
using IHIS.OCSO.Meta;
using IHIS.CloudConnector.Contracts.Arguments.OcsEmr;
using IHIS.CloudConnector.Contracts.Results.OcsEmr;
using IHIS.CloudConnector.Contracts.Results;
using Newtonsoft.Json;
using EmrDocker;
using EmrDocker.Meta;
using EmrDocker.Models;
using IHIS.OCSO.AdditionalBusiness;
using ContentAlignment = System.Drawing.ContentAlignment;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.OCSO
{
    using IHIS.CloudConnector;
    using IHIS.CloudConnector.Caching;
    using IHIS.CloudConnector.Contracts.Arguments.Ocso;
    using IHIS.CloudConnector.Contracts.Arguments.System;
    using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;
    using IHIS.CloudConnector.Contracts.Models.Ocso;
    using IHIS.CloudConnector.Contracts.Results;
    using IHIS.CloudConnector.Contracts.Results.Ocso;
    using IHIS.CloudConnector.Contracts.Results.System;
    using IHIS.CloudConnector.Contracts.Models.System;
    using IHIS.CloudConnector.Utility;
    using IHIS.OCSO.Properties;
    using IHIS.CloudConnector.Contracts.Arguments.Nuro;
    using IHIS.CloudConnector.Contracts.Results.Nuro;
    using Microsoft.Win32;
    using IHIS.CloudConnector.Contracts.Arguments.Nuri;
    using IHIS.CloudConnector.Contracts.Results.Nuri;
    using DevExpress.XtraRichEdit;

    using global::EmrDocker.Glossary;

    using IHIS.CloudConnector.Contracts.Models.OcsEmr;
    using IHIS.CloudConnector.Contracts.Models.Nuri;
    using DevExpress.XtraTreeList;
    using DevExpress.XtraTreeList.Nodes;
    using MedicalInterfaceTest;
    using IHIS.CloudConnector.Contracts.Results.Outs;
    using IHIS.CloudConnector.Contracts.Models.Outs;
    using IHIS.CloudConnector.Contracts.Results.Ocsa;
    using IHIS.CloudConnector.Contracts.Arguments.Ocsemr;
    using IHIS.CloudConnector.Contracts.Results.Ocsemr;
    using IHIS.CloudConnector.Contracts.Arguments.Ocs.Lib;
    using System.Configuration;
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    public partial class OCS2016U02 : IHIS.Framework.XScreen, IMainScreen
    {
        #region grid Properties

        /*private Framework.XEditGrid grdOrder_Drug = new IHIS.Framework.XEditGrid();
        private Framework.XEditGrid grdOrder_Jusa = new IHIS.Framework.XEditGrid();
        private Framework.XEditGrid grdOrder_Cpl = new IHIS.Framework.XEditGrid();
        private Framework.XEditGrid grdOrder_Pfe = new IHIS.Framework.XEditGrid();
        private Framework.XEditGrid grdOrder_Apl = new IHIS.Framework.XEditGrid();
        private IHIS.Framework.XEditGrid grdOrder_Xrt = new IHIS.Framework.XEditGrid();
        private IHIS.Framework.XEditGrid grdOrder_Chuchi = new IHIS.Framework.XEditGrid();
        private IHIS.Framework.XEditGrid grdOrder_Susul = new IHIS.Framework.XEditGrid();
        private Framework.XEditGrid grdOrder_Reha = new IHIS.Framework.XEditGrid();
        private IHIS.Framework.XEditGrid grdOrder_Etc = new IHIS.Framework.XEditGrid();*/

        #endregion

        #region UserOption

        /// <summary>
        /// UserOption
        /// </summary>
        public struct UserOptions
        {
            /// <summary>
            /// Opt: ALLERGY_POP_YN
            /// </summary>
            private static string _allergyPopYn = string.Empty;

            public static string AllergyPopYn
            {
                get { return _allergyPopYn; }
                set { _allergyPopYn = value; }
            }

            /// <summary>
            /// Opt: SPECIALWRITE_POP_YN
            /// </summary>
            private static string _specialwritePopYn = string.Empty;

            public static string SpecialwritePopYn
            {
                get { return _specialwritePopYn; }
                set { _specialwritePopYn = value; }
            }

            /// <summary>
            /// Opt: SAME_NAME_CHECK_YN
            /// </summary>
            private static string _sameNameCheckYn = string.Empty;

            public static string SameNameCheckYn
            {
                get { return _sameNameCheckYn; }
                set { _sameNameCheckYn = value; }
            }

            /// <summary>
            /// Opt: VITALSIGNS_POP_YN
            /// </summary>
            private static string _vitalsignsPopYn = string.Empty;

            public static string VitalsignsPopYn
            {
                get { return _vitalsignsPopYn; }
                set { _vitalsignsPopYn = value; }
            }

            /// <summary>
            /// Opt: EMR_POP_YN
            /// </summary>
            private static string _emrPopYn = string.Empty;

            public static string EmrPopYn
            {
                get { return _emrPopYn; }
                set { _emrPopYn = value; }
            }

            /// <summary>
            /// Opt: ORDER_LABEL_PRT_YN
            /// </summary>
            private static string _orderLabelPrtYn = string.Empty;

            public static string OrderLabelPrtYn
            {
                get { return _orderLabelPrtYn; }
                set { _orderLabelPrtYn = value; }
            }
            /// <summary>
            /// Opt": Drug Order
            /// </summary>
            private static string _potionDrugOrder = string.Empty;
            public static string PotionDrugOrder
            {
                get { return _potionDrugOrder; }
                set { _potionDrugOrder = value; }
            }
            /// <summary>
            /// Opt: DiseaseNameUnregistered
            /// </summary>
            private static string _diseaseNameUnregistered = string.Empty;
            public static string DiseaseNameUnregistered
            {
                get { return _diseaseNameUnregistered; }
                set { _diseaseNameUnregistered = value; }
            }
            /// <summary>
            /// Opt:Infection
            /// </summary>
            private static string _infection = string.Empty;
            public static string Infection
            {
                get { return _infection; }
                set { _infection = value; }
            }
            /// <summary>
            /// Opt:RESER_PRT_YN
            /// </summary>
            private static string _reserPrtYn = string.Empty;
            public static string ReserPrtYn
            {
                get { return _reserPrtYn; }
                set { _reserPrtYn = value; }
            }
            /// <summary>
            /// Opt:DO_ORDER_POP_YN
            /// </summary>
            private static string _doOrderPopYn = string.Empty;
            public static string DoOrderPopYn
            {
                get { return _doOrderPopYn; }
                set { _doOrderPopYn = value; }
            }

            /// <summary>
            /// Opt:EMR_Back_Rule
            /// </summary>
            private static string _emrBackRule = string.Empty;
            public static string EmrBackRule
            {
                get { return _emrBackRule; }
                set { _emrBackRule = value; }
            }
            /// <summary>
            /// Opt:EMR_Back_Time
            /// </summary>
            private static string _emrBackTime = string.Empty;
            public static string EmrBackTime
            {
                get { return _emrBackTime; }
                set { _emrBackTime = value; }
            }
        }

        #region Creat Table
        DataTable tbl_PatientInfo;
        DataTable tbl_DRG;
        DataTable tbl_INJ;
        DataTable tbl_CPL;
        DataTable tbl_PHY;
        DataTable tbl_PFE;
        DataTable tbl_PHI;
        DataTable tbl_XRT;
        DataTable tbl_TST;
        DataTable tbl_OPR;
        DataTable tbl_Other;
        #endregion

        #endregion

        #region InputTab

        /// <summary>
        /// Order screens
        /// </summary>
        public struct InputTab
        {
            /// <summary>
            /// 薬オーダ登録(OCS0103U10)
            /// </summary>
            public const string DrugOrder = "01";

            /// <summary>
            /// リハビリ依頼オーダ登録(OCS0103U11)
            /// </summary>
            public const string RehabilitationOrder = "10";

            /// <summary>
            /// 注射オーダ登録(OCS0103U12)
            /// </summary>
            public const string InjectionOrder = "03";

            /// <summary>
            /// 検体検査オーダ登録(OCS0103U13)
            /// </summary>
            public const string LabTestOrder = "04";

            /// <summary>
            /// 生理検査オーダ登録 (OCS0103U14)
            /// </summary>
            public const string PhysiologicalTestOrder = "05";

            /// <summary>
            /// 病理検査オーダ登録(OCS0103U15)
            /// </summary>
            public const string PathologicalInspectionOrder = "06";

            /// <summary>
            /// 放射線オーダ登録(OCS0103U16)
            /// </summary>
            public const string RadiationInspectionOrder = "07";

            /// <summary>
            /// 処置オーダ登録(OCS0103U17)
            /// </summary>
            public const string MinorSurgeryOrder = "08";

            /// <summary>
            /// 手術オーダ登録(OCS0103U18)
            /// </summary>
            public const string SurgeryOrder = "09";

            /// <summary>
            /// その他オーダ登録(OCS0103U19)
            /// </summary>
            public const string OtherOrder = "11";
        }

        #endregion

        internal enum EmrBackRule
        {
            D,
            W,
            M
        }
        internal enum DayOfWeek
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7
        }

        internal enum GridModule
        {
            OCS0103U10,
            OCS0103U11,
            OCS0103U12,
            OCS0103U13,
            OCS0103U14,
            OCS0103U15,
            OCS0103U16,
            OCS0103U17,
            OCS0103U18,
            OCS0103U19,
        }

        string oldMmlContent;
        private List<GridModule> loadedGridModules = new List<GridModule>();
        private MdiDialogS pendingPatient;
        private string protocolId = "";
        private OCS2015U11S _orderBox;
        private bool isFirstSetup = false;
        private bool popupGridOrderActive = false;
        // 2015.08.06 AnhNV ADDED
        private DateTime _sysDate = EnvironInfo.GetSysDate();

        public EmrDocketS ctlEmrDocker;
        //private RegistryManager _rtm;
        private EMRCacheManager _emrCacheManager;
        private String allWarning = "";

        private bool _setDefaultTemplate;
        private bool _isListTagInfoNull;

        private DataTable _grdCheckKinki = null;
        private bool _isSaved = false;
        private const string LangVI = "Vi";
        private const string B1 = "B1";
        private bool _isEnableGrd = true;
        private bool outOfHosp;
        private CommonOcsLibS _ocsLibS;
        string cacheDataDiscuss = "";
        private const string _defaultSpace = "   ";
        private bool _isShowGroupButton1 = false;
        private bool _isShowPbxNotifyON = false;
        private bool _isShowGroupButton2 = false;
        private bool _isShowBtnReha = false;
        private bool _isShowBtnAplOrder = false;
        private bool _isShowBtnXrtOrder = false;
        private bool _isShowBtnXrtOrderForVi = false;
        private bool _isShowBtnSusulOrder = false;
        private bool _isShowBtnEtcOrder = false;
        private bool _isPostLoad = false;
        private bool _enableBtnList = true;
        private bool _isCheckPandingPatient = false;
        private bool _isCheckDataExist = false;        
        private bool _isCheckFinishExame = false;
        private bool _isSignalPictureBox = false; 
        private bool _isSignalPictureBox2 = false; 
        private bool _isSignalPictureBox3 = false; 
    
        private List<OcsoOCS1003P01GridOutSangInfo> _lstOcsoOCS1003P01GridOutSangInfo = new List<OcsoOCS1003P01GridOutSangInfo>();

        /* Precsiption*/
        private string Bunho = "";
        private string PkOut = "";
        private string NaewonDate = "";
        private const string FormatType = "HTML";
        private const string TplType = "EMR";
        private const string TplTypePrecription = "PRESCRIPTION";
        private string _strHtmlTemplate = "";
        private OCS2015U00GetDataPrescriptionResult _patientPrescriptionResult;
        private string _strDataBinding = "";
        private string jSonData = "";
        private string _templateFile = "OCS2015Presciption.html";
        private string _currentUrl = "";
        private string _urlFinal = "";

        //demo        
        private DrugPrescriptionVi drugPrescriptionData = new DrugPrescriptionVi();
        /* Precsiption*/

        private List<OUT0106U00GridItemInfo> listSpecialNode = new List<OUT0106U00GridItemInfo>();
        private CheckHideButtonResult hideButtonLst = new CheckHideButtonResult();
        System.Windows.Forms.ToolTip tip1 = new System.Windows.Forms.ToolTip();
        private bool _isShowBtnEportViewer = true;

        //MED-9878
        private ToolTip toolTip;

        public CommonOcsLibS OcsLibS
        {
            get
            {
                if (_ocsLibS == null) _ocsLibS = new CommonOcsLibS();
                return _ocsLibS;
            }
        }

        public bool EnableBtnList
        {
            get { return _enableBtnList; }
            set { _enableBtnList = value; }
        }

        public bool SetDefaultTemplate
        {
            get { return _setDefaultTemplate; }
            set { _setDefaultTemplate = value; }
        }

        public OCS2015U11S OrderBox
        {
            get
            {
                if (_orderBox == null)
                {
                    _orderBox = new OCS2015U11S(this);
                }
                return _orderBox;
            }
        }

        public OCS2016U02()
        {
            try
            {
                InitializeComponent();
                this.SuspendLayout();
                ShowIcon();
                //tvBookmarkList.MainScreen = this;
                ucOCS2016U0304.ocS2015U04C1.MainScreen = this;
                _orderBox = new OCS2015U11S(this);
                _orderBox.Dock = DockStyle.Fill;                
                //_orderBox.Size = new Size(1500, _orderBox.Size.Height);                                                                                    
                _orderBox.Size = new Size(650, _orderBox.Size.Height);   
                this.pnlOrderList.Controls.Add(_orderBox);               
                this.ctlEmrDocker = new EmrDocketS(this);
                this.ctlEmrDocker.Dock = DockStyle.Fill;
                this.pnlOrderList.Controls.Add(this.ctlEmrDocker);
                pendingPatient = new MdiDialogS(this);
                //this.ctlEmrDocker.Editor.UserName = UserInfo.UserName;
                //tvExamHist.TvHisExam.MouseDoubleClick += new MouseEventHandler(TvBunho_NodeMouseDoubleClick);
                ucOCS2016U0304.ocS2015U03C1.TvHisExam.MouseDoubleClick += new MouseEventHandler(TvBunho_NodeMouseDoubleClick);
                /*cldExamDates.xPreMonthCalendar.DayDoubleClick +=
                    new IHIS.Framework.XCalendarDayClickEventHandler(xPreMonthCalendar_DayDoubleClick);
                cldExamDates.calSchedule.DayDoubleClick +=
                    new IHIS.Framework.XCalendarDayClickEventHandler(calSchedule_DayDoubleClick);*/
                //tvExamHist.ctxHisExamMenu.ItemClicked += new ToolStripItemClickedEventHandler(ctxHisExamMenu_ItemClicked);
                //this.tvBookmarkList.TvBunho.DoubleClick += TvBunho_DoubleClick;
                this.ucOCS2016U0304.ocS2015U04C1.TvBunho.DoubleClick += TvBunho_DoubleClick;
                this.ctlEmrDocker.Editor.Visible = false;
                //this.fbxBunho.OnDataChanged += FbxBunhoOnOnDataChanged;
                //tvExamHist.TvHisExam.AfterFocusNode += tvHisExam_AfterSelect;
                ucOCS2016U0304.ocS2015U03C1.TvHisExam.AfterFocusNode += tvHisExam_AfterSelect;
                //tvExamHist.TvHisExam.DoubleClick +=
                this._emrCacheManager = new EMRCacheManager();
                this.isFirstSetup = _emrCacheManager.IsFirstSetup();
                InitPatientprofile();
                UpdateGUI();
                this.SizeChanged += OCS2015U00_SizeChanged;
                btnAplOrder.Enabled = true;
                this.lbSuname.BorderStyle = BorderStyle.None;
                this.grdOutSang.ReadOnly = true;
                if (!MDoctorLogin)
                {
                    //btnJinryoReser.Enabled = false;
                    btnApprove.Enabled = false;
                    btnConsult.Enabled = false;
                }
                
                //this.btnAllergy.ImageIndex = 42;

                /*if (checkShowLayDisease())
                {
                    ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(null, null, null, true, true, true);
                }
                else
                {
                    ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(null, null, null, true, true, false);
                }*/
                //MED-10835
                //ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(null, null, null, true, true, !IsVI());
                //MED-14639
                ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(null, null, null, true, true, true);

                this.ctlEmrDocker.Viewer.EditButtonClick += Viewer_EditButtonClick;
                CheckHideButton();
                //SetOutSangForKinki();

                // 2016.01.28 AnhNV added
                // Disable IME mode to fix https://sofiamedix.atlassian.net/browse/MED-6605
                fbxBunho.ImeMode = ImeMode.Disable;
                _orderBox.SetCollapse();
                /*SetDefaultWhenLoad();*/
                this.ResumeLayout();
                CheckShowButtonPatientU21AndJinryoReser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private bool checkShowLayDisease()
        {
            OCS2016U02CheckLoadExpandArgs args = new OCS2016U02CheckLoadExpandArgs();
            args.HospCode = UserInfo.HospCode;
           // args.Language = NetInfo.Language.ToString();   
            args.Language = "";
            //OCS2016U02CheckLoadExpandResult res = CloudService.Instance.Submit<OCS2016U02CheckLoadExpandResult, OCS2016U02CheckLoadExpandArgs>(args);
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    if (res.Result == "Y")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        private void SetOutSangForKinki()
        {
            this.OrderBox.DrugControl.GrdOutSangDt = grdOutSang.LayoutTable;
            this.OrderBox.UCOCS2015U12Control.GrdOutSangDt = grdOutSang.LayoutTable;
        }

        //HungNV added
        //Checking trial patient status
        private void GetLatestWarningStatus()
        {

            bool isTrialPatient = false;
            string bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            if (!string.IsNullOrEmpty(bunho))
            {
                #region kinki check

                _isSaved = false;

                #endregion

                EMRGetLatestWarningStatusArgs args = new EMRGetLatestWarningStatusArgs();
                args.Bunho = bunho;
                EMRGetLatestWarningStatusResult result =
                    CloudService.Instance.Submit<EMRGetLatestWarningStatusResult, EMRGetLatestWarningStatusArgs>(args);
                if (result != null && result.WarningStatusInfo.ClisProtocolId != null &&
                    !string.IsNullOrEmpty(result.WarningStatusInfo.ClisProtocolId))
                {
                    isTrialPatient = true;
                    protocolId = result.WarningStatusInfo.ClisProtocolId;
                    this.btnTrialPatient.Text = result.WarningStatusInfo.CodeName;
                }
                else
                {
                    protocolId = string.Empty;
                }
            }
            else
            {
                isTrialPatient = false;
            }

            int patientDetailBoxHeight = isTrialPatient ? 100 : 125;
            this.btnTrialPatient.Visible = isTrialPatient;
            /*this.xPnlPatientDetail.Size = new Size(this.xPnlPatientDetail.Size.Width, patientDetailBoxHeight);*/
            this.xPnlPatientDetail.Size = new System.Drawing.Size(265, 118);            
        }

        private void OCS2015U00_SizeChanged(object sender, EventArgs e)
        {
            UpdateGUI();
        }
        private void OCS2016U02_SizeChanged(object sender, EventArgs e)
        {
            MakeInputTab();             
        }

        private void UpdateGUI()
        {
            /*Size mainSize = this.Size;
            this.xPanel5.Size = new System.Drawing.Size(380, mainSize.Height);
            this.tvExamHist.Size = new System.Drawing.Size(380,
                (this.xPanel5.Size.Height - this.tvExamHist.Location.Y) / 2);
            this.tvBookmarkList.Location = new System.Drawing.Point(0,
                this.tvExamHist.Location.Y + this.tvExamHist.Size.Height + 1);
            this.tvBookmarkList.Size = new System.Drawing.Size(this.tvBookmarkList.Size.Width,
                this.tvExamHist.Size.Height);
            this.pnlTop.Size = new System.Drawing.Size(ctlEmrDocker.Size.Width, 152);
            this.pnlSang.Size = new Size(this.pnlTop.Width * 2 / 10, 152);
            this.pnlTopLeft.Location = new Point(0, 0);
            this.pnlTopLeft.Size = new System.Drawing.Size(pnlTop.Size.Width - pnlSang.Size.Width, 152);
            this.pnlProblemInfo.Size = new System.Drawing.Size(this.pnlTop.Width * 2 / 10 + 5, 152);
            this.pnlProblemList.Size =
                new System.Drawing.Size(this.pnlTopLeft.Size.Width - this.pnlProblemInfo.Size.Width + 5, 152);
            this.tvExamHist.panel1.Size = new Size(380, this.tvExamHist.Size.Height - 30);*/
            
            Size mainSize = this.Size;
            this.xPanel5.Size = new System.Drawing.Size(380, mainSize.Height);
            this.ucOCS2016U0304.ocS2015U03C1.Size = new System.Drawing.Size(380,
                (this.xPanel5.Size.Height - this.ucOCS2016U0304.ocS2015U03C1.Location.Y) / 2);
            /*this.tvBookmarkList.Location = new System.Drawing.Point(0,
                this.ucOCS2016U0304.ocS2015U03C1.Location.Y + this.ucOCS2016U0304.ocS2015U03C1.Size.Height + 1);
            this.tvBookmarkList.Size = new System.Drawing.Size(this.tvBookmarkList.Size.Width,
                this.ucOCS2016U0304.ocS2015U03C1.Size.Height);*/
            this.ucOCS2016U0304.ocS2015U04C1.Location = new System.Drawing.Point(0,
                this.ucOCS2016U0304.ocS2015U03C1.Location.Y + this.ucOCS2016U0304.ocS2015U03C1.Size.Height + 1);
            this.ucOCS2016U0304.ocS2015U04C1.Size = new System.Drawing.Size(this.ucOCS2016U0304.ocS2015U04C1.Size.Width,
                this.ucOCS2016U0304.ocS2015U03C1.Size.Height);
            /*this.pnlTop.Size = new System.Drawing.Size(ctlEmrDocker.Size.Width, 152);*/
            /*this.pnlSang.Size = new Size(this.pnlTop.Width * 2 / 10, 152);*/
            this.pnlTopLeft.Location = new Point(0, 0);
            /*this.pnlTopLeft.Size = new System.Drawing.Size(pnlTop.Size.Width - pnlSang.Size.Width, 152);*/

            //Todo: check agian.
            /*this.pnlProblemInfo.Size = new System.Drawing.Size(this.pnlTop.Width * 2 / 10 + 5, 152);*/
            this.pnlProblemList.Size =
                new System.Drawing.Size(this.pnlTopLeft.Size.Width - this.pnlProblemInfo.Size.Width + 5, 152);
            this.ucOCS2016U0304.ocS2015U03C1.Size = new Size(380, this.ucOCS2016U0304.ocS2015U03C1.Size.Height - 30);
        }

        private void tvHisExam_AfterSelect(object sender, NodeEventArgs e)
        {
            //AdditionalBusiness.AdditionalBusiness.SetPkout1001WhenSelectedNodeChange(this.mSelectedPatientInfo.Parameter.Bunho, ctlEmrDocker, tvExamHist, sender, e);
            // Set pkout1001 for the viewer
            if (e.Node.GetValue("PkOut1001") != null)
            {
                /*this.ctlEmrDocker.Viewer.Pkout1001 = e.Node.GetValue("PkOut1001").ToString();
                string pkOut1001 = e.Node.GetValue("PkOut1001").ToString();
                string[] pkOut1001Arr = pkOut1001.Split(new char[] { '.' });
                //int intPkOut1001 = Int32.Parse(pkOut1001);
                ctlEmrDocker.Viewer.ucGrid1.ScrollToPkOut(pkOut1001Arr[0]);*/
            }
            this.ctlEmrDocker.Viewer.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                //process hi.Node here
            }
        }

        internal ImageList ImgLst
        {
            get { return this.ImageList; }
        }

        internal void InitSearchData()
        {
            string mBunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            string naewon_date = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            string fbxBunho = this.fbxBunho.GetDataValue().ToString();
            string mDoctor = this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
            //&& !string.IsNullOrEmpty(fbxBunho)
            if (!string.IsNullOrEmpty(mBunho) && !string.IsNullOrEmpty(naewon_date))
            {
                ctlEmrDocker.Editor.VisiableAllCtrl(true);
                DateTime dt = DateTime.Parse(naewon_date);
                if (DateTime.Compare(_sysDate, dt) > 0)
                {
                    ctlEmrDocker.Editor.ucGrid1.Enabled = false;
                    ctlEmrDocker.Editor.VisiableAllCtrl(false);
                }
                this.GetSpecialNoteList(mBunho, naewon_date);
                //this.InitHisExam(mBunho);
                //this.ResetPatientprofile();
                InitHisExamData();
                CheckDoctorCanView();
                this.LoadOcsEmrControlData(true);
                this.SetActiveEmrEditor(true);
            }

            SetDefaultTemplate = true;
            resetSignalPicture();
            resetSignalAllergyPicture2();
            resetSignalAllergyPicture3();
            ActionEPortViewer(false);
        }

        private void CheckDoctorCanView()
        {
            if (MDoctorLogin)
            {
                EnableAllControl(true);
                _isEnableGrd = true;
                //tvBookmarkList.IsEnableRightClick = true;
                ucOCS2016U0304.ocS2015U04C1.IsEnableRightClick = true;
                ctlEmrDocker.Viewer.IsEnableBtnEdit = true;
                ctlEmrDocker.Viewer.ucGrid1.IsEnableBtnDo = true;

                if (!CheckDoctorCanSearchPatient())
                {
                    EnableAllControl(false);
                    _isEnableGrd = false;
                    //tvBookmarkList.IsEnableRightClick = false;
                    ucOCS2016U0304.ocS2015U04C1.IsEnableRightClick = false;
                    ctlEmrDocker.Viewer.IsEnableBtnEdit = false;
                    ctlEmrDocker.Viewer.ucGrid1.IsEnableBtnDo = false;
                }
            }
        }

        private bool CheckDoctorCanSearchPatient()
        {
            List<OcsoOCS1003P01LayPatInfo> lstLayPat = pendingPatient.PatientBox.LstLayPatInfo;
            foreach (OcsoOCS1003P01LayPatInfo ocsoOcs1003P01LayPatInfo in lstLayPat)
            {
                //MED-10475
                /*if (ocsoOcs1003P01LayPatInfo.Doctor == UserInfo.DoctorID)
                {
                    return true;
                }*/
                string strDoctor = ocsoOcs1003P01LayPatInfo.Doctor;
                if (!string.IsNullOrEmpty(strDoctor) && !string.IsNullOrEmpty(UserInfo.UserID))
                {
                    if (strDoctor.ToUpper().EndsWith(UserInfo.UserID.ToUpper())) return true;
                }
            }

            return false;
        }

        private void EnableAllControl(bool isEnable)
        {
            btnVital.Enabled = isEnable;
            signalPictureBox.Enabled = isEnable;
            signalPictureBox2.Enabled = isEnable;
            signalPictureBox3.Enabled = isEnable;
            btnComment.Enabled = isEnable;
            btnJinryoReser.Enabled = isEnable;
            btnApprove.Enabled = isEnable;
            btnKensaReserPrint.Enabled = isEnable;
            btnKensaReser.Enabled = isEnable;
            btnOrderPrint.Enabled = isEnable;
            btnConsult.Enabled = isEnable;
            btnConsultAnswer.Enabled = isEnable;
            btnOrderGuide.Enabled = isEnable;
            btnOpenOutSang.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnDrgOrder.Enabled = isEnable;
            btnJusaOrder.Enabled = isEnable;
            btnCplOrder.Enabled = isEnable;
            btnChuchiOrder.Enabled = isEnable;
            btnSusulOrder.Enabled = isEnable;
            btnPfeOrder.Enabled = isEnable;
            btnMovieTalk.Enabled = isEnable;
            btnAplOrder.Enabled = isEnable;
            btnXrtOrder.Enabled = isEnable;
            btnXrtOrderForVi.Enabled = isEnable;
            btnEtcOrder.Enabled = isEnable;
            btnReha.Enabled = isEnable;
            btnENDOResult.Enabled = isEnable;
            btnKarteOfOrtherClinics.Enabled = isEnable;
            btnList.SetEnabled(FunctionType.Query, true);
            btnList.SetEnabled(FunctionType.Cancel, isEnable);
            btnList.SetEnabled(FunctionType.Reset, isEnable);
            btnList.SetEnabled(FunctionType.Update, isEnable);
            btnList.SetEnabled(FunctionType.Process, isEnable);
            this.ctlEmrDocker.Viewer.VisiableAllCtrl(isEnable);

            string naewon_date = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            ctlEmrDocker.Editor.VisiableAllCtrl(true);
            DateTime dt = DateTime.Parse(naewon_date);
            if (DateTime.Compare(_sysDate, dt) > 0)
            {
                ctlEmrDocker.Editor.ucGrid1.Enabled = false;
                ctlEmrDocker.Editor.VisiableAllCtrl(false);
            }
            else
            {
                this.ctlEmrDocker.Editor.VisiableAllCtrl(isEnable);
            }

        }

        internal void SetEnableBtnList(bool isEnable)
        {
            btnList.SetEnabled(FunctionType.Cancel, isEnable);
            btnList.SetEnabled(FunctionType.Reset, isEnable);
            btnList.SetEnabled(FunctionType.Update, isEnable);
            btnList.SetEnabled(FunctionType.Process, isEnable);
            foreach (Control control in OrderBox.PnlInputTab.Controls)
            {
                if (control is XRadioButton)
                {
                    ((XRadioButton)control).Enabled = isEnable;
                }
            }
            btnJinryoReser.Enabled = isEnable;
            btnApprove.Enabled = isEnable;
            btnKensaReserPrint.Enabled = isEnable;
            btnKensaReser.Enabled = isEnable;
            btnOrderPrint.Enabled = isEnable;
            btnConsult.Enabled = isEnable;
            btnConsultAnswer.Enabled = isEnable;
            btnOrderGuide.Enabled = isEnable;
            btnOpenOutSang.Enabled = isEnable;
            btnSetOrder.Enabled = isEnable;
            btnDoOrder.Enabled = isEnable;
            btnDrgOrder.Enabled = isEnable;
            btnJusaOrder.Enabled = isEnable;
            btnCplOrder.Enabled = isEnable;
            btnChuchiOrder.Enabled = isEnable;
            btnSusulOrder.Enabled = isEnable;
            btnPfeOrder.Enabled = isEnable;
            btnMovieTalk.Enabled = isEnable;
            btnAplOrder.Enabled = isEnable;
            btnXrtOrder.Enabled = isEnable;
            btnXrtOrderForVi.Enabled = isEnable;
            btnEtcOrder.Enabled = isEnable;
            btnReha.Enabled = isEnable;
            btnENDOResult.Enabled = isEnable;
            btnKarteOfOrtherClinics.Enabled = isEnable;
            btnOpenOutSang.Enabled = isEnable;
        }

        internal void ResetSearchData()
        {
            //this.cldExamDates.ResetCalendar();
            this.SetActiveEmrEditor(false);
            //this.ResetPatientprofile();
            this.ResetOcsEmrData(true);
            /*this.ctlOCS2015U05.Reset();*/
        }

        internal void SetActiveEmrEditor(bool isActive)
        {
            this.ctlEmrDocker.Editor.Visible = isActive;
        }

        internal void SetActiveEmrViewer(bool isActive)
        {
            this.ctlEmrDocker.Viewer.Visible = isActive;
        }


        //private void FbxBunhoOnOnDataChanged(object sender)
        //{
        //    ResetOcsEmrData(true);
        //}

        private void TvBunho_DoubleClick(object sender, EventArgs e)
        {
            //todo fix this!
            //TreeNode treeNode = tvBookmarkList.TvBunho.SelectedNode;
            TreeNode treeNode = ucOCS2016U0304.ocS2015U04C1.TvBunho.SelectedNode;
            if (treeNode.Level == 1)
            {
                this.ctlEmrDocker.ActiveChildControl("1");
                //ctlEmrDocker.Viewer.GotoRecord(treeNode.Text.Trim().Substring(0, 10), null);
                ctlEmrDocker.Viewer.ucGrid1.ScrollToDate(treeNode.Text.Trim(), "");
            }
            else if (treeNode.Level == 2)
            {
                CommentInfo info = (CommentInfo)treeNode.Tag;
                string bookmarkId = info == null ? "" : info.TagId;
                //todo: implement bookmark - anh.lai
                if (!string.IsNullOrEmpty(bookmarkId)) ctlEmrDocker.Viewer.ucGrid1.ScrollToTagId(bookmarkId);
            }
        }

        private void xPnlPatientDetail_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (!xPnlPatientDetail.Focused)
            //    xPnlPatientDetail.Focus();
        }

        internal void ResetPatientprofile()
        {
            string bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            if (string.IsNullOrEmpty(bunho))
            {
                this.lbSuname.Text = string.Empty;
                this.lbSuname2.Text = string.Empty;
                this.lbSexAge.Text = string.Empty;
                this.lbBirthDay.Text = string.Empty;
                this.lbWeight.Text = string.Empty;
                this.lbHeight.Text = string.Empty;
                this.lbHeightAndWeight.Text = string.Empty;
                this.lbBreathAndBodyHeatAndPulse.Text = string.Empty;
                this.lbBpFromAndToAndSpo2.Text = string.Empty;
                this.lbBloodpressureH.Text = string.Empty;
                this.lbBloodpressureL.Text = string.Empty;
                this.lbCircuit.Text = string.Empty;
                this.lbTemperature.Text = string.Empty;
                this.lbSpo2.Text = string.Empty;
                this.lbBreathingRate.Text = string.Empty;
                //this.lbSuname.Text = Resources.NAME_1 + ": ";
                //this.lbSuname2.Text = Resources.NAME_2 + ": ";
                //this.lbSexAge.Text = Resources.GENDER + GetPatientLabelOffset(Resources.GENDER.Length);
                //this.lbBirthDay.Text = Resources.BIRTHDAY + GetPatientLabelOffset(Resources.BIRTHDAY.Length);
                //this.lbWeight.Text = Resources.WEIGHT + GetPatientLabelOffset(Resources.WEIGHT.Length);
                //this.lbHeight.Text = Resources.HEIGHT + GetPatientLabelOffset(Resources.HEIGHT.Length);
                //this.lbBloodpressureH.Text = Resources.BLOOD_PH + GetPatientLabelOffset(Resources.BLOOD_PH.Length);
                //this.lbBloodpressureL.Text = Resources.BLOOD_PL + GetPatientLabelOffset(Resources.BLOOD_PL.Length);
                //this.lbCircuit.Text = Resources.PULSE + GetPatientLabelOffset(Resources.PULSE.Length);
                //this.lbTemperature.Text = Resources.TEMPERATURE + GetPatientLabelOffset(Resources.TEMPERATURE.Length);
                //this.lbSpo2.Text = Resources.SPO2 + GetPatientLabelOffset(Resources.SPO2.Length);
                //this.lbBreathingRate.Text = Resources.BREATHING_RATE + GetPatientLabelOffset(Resources.BREATHING_RATE.Length);
            }
            string patientSetingKey = this._emrCacheManager.PatientSetingKey + this._emrCacheManager.UserName;
            string data = this._emrCacheManager.Get(patientSetingKey);
            if (!string.IsNullOrEmpty(data))
            {
                this.UpDatePatientSetting(data);
            }
            else
            {
                this.HiddenPatientprofile();
            }
        }

        internal void HiddenPatientprofile()
        {
            this.lbWeight.Visible = false;
            this.lbHeight.Visible = false;
            //this.lbHeightAndWeight.Visible = false;
            //this.lbBreathAndBodyHeatAndPulse.Visible = false;
            //this.lbBpFromAndToAndSpo2.Visible = false;
            this.lbChojaeName.Visible = false;
            this.lbGubunName.Visible = false;
            this.xLabel7.Visible = false;
            this.lbSexAge.Visible = false;
            this.lbSuname2.Visible = false;
            this.lbSuname.Visible = false;
            this.lbBloodpressureH.Visible = false;
            this.lbBloodpressureL.Visible = false;
            this.lbCircuit.Visible = false;
            this.lbTemperature.Visible = false;
            this.lbSpo2.Visible = false;
            this.lbBreathingRate.Visible = false;
            this.lbBirthDay.Visible = false;

            this.lbWeightName.Visible = false;
            this.lbHeightName.Visible = false;
            this.lbChojaeName.Visible = false;
            this.lbGubunName.Visible = false;
            this.xLabel7Name.Visible = false;
            this.lbSexAgeName.Visible = false;
            this.lbSuname2Name.Visible = false;
            this.lbSunameName.Visible = false;
            this.lbBloodpressureHName.Visible = false;
            this.lbBloodpressureLName.Visible = false;
            this.lbCircuitName.Visible = false;
            this.lbTemperatureName.Visible = false;
            this.lbSpo2Name.Visible = false;
            this.lbBreathingRateName.Visible = false;
            this.lbBirthDayName.Visible = false;
        }

        internal void ShowAllPatientprofile()
        {
            this.lbWeight.Visible = true;
            this.lbHeight.Visible = true;
            this.lbHeightAndWeight.Visible = true;
            this.lbBreathAndBodyHeatAndPulse.Visible = true;
            this.lbBpFromAndToAndSpo2.Visible = true;
            this.lbChojaeName.Visible = true;
            this.lbGubunName.Visible = true;
            this.xLabel7.Visible = true;
            this.lbSexAge.Visible = true;
            this.lbSuname2.Visible = true;
            this.lbSuname.Visible = true;
            this.lbBloodpressureH.Visible = true;
            this.lbBloodpressureL.Visible = true;
            this.lbCircuit.Visible = true;
            this.lbTemperature.Visible = true;
            this.lbSpo2.Visible = true;
            this.lbBreathingRate.Visible = true;
            this.lbBirthDay.Visible = true;

            this.lbWeightName.Visible = true;
            this.lbHeightName.Visible = true;
            this.lbChojaeName.Visible = true;
            this.lbGubunName.Visible = true;
            this.xLabel7Name.Visible = true;
            this.lbSexAgeName.Visible = true;
            this.lbSuname2Name.Visible = true;
            this.lbSunameName.Visible = true;
            this.lbBloodpressureHName.Visible = true;
            this.lbBloodpressureLName.Visible = true;
            this.lbCircuitName.Visible = true;
            this.lbTemperatureName.Visible = true;
            this.lbSpo2Name.Visible = true;
            this.lbBreathingRateName.Visible = true;
            this.lbBirthDayName.Visible = true;
        }

        internal void InitPatientprofile()
        {
            this.lbSuname.Text = string.Empty;
            this.lbSuname2.Text = string.Empty;
            this.lbSexAge.Text = string.Empty;
            this.lbBirthDay.Text = string.Empty;
            this.lbWeight.Text = string.Empty;
            this.lbHeight.Text = string.Empty;
            this.lbHeightAndWeight.Text = string.Empty;
            this.lbBreathAndBodyHeatAndPulse.Text = string.Empty;
            this.lbBpFromAndToAndSpo2.Text = string.Empty;
            this.lbBloodpressureH.Text = string.Empty;
            this.lbBloodpressureL.Text = string.Empty;
            this.lbCircuit.Text = string.Empty;
            this.lbTemperature.Text = string.Empty;
            this.lbSpo2.Text = string.Empty;
            this.lbBreathingRate.Text = string.Empty;
            /*//Old code - MED-9023
            //For name label
            this.lbSunameName.Text = Resources.NAME_1;
            this.lbSuname2Name.Text = Resources.NAME_2;
            this.lbSexAgeName.Text = Resources.GENDER;
            this.lbBirthDayName.Text = Resources.BIRTHDAY;
            this.lbWeightName.Text = Resources.WEIGHT;
            this.lbHeightName.Text = Resources.HEIGHT;
            this.lbBloodpressureHName.Text = Resources.BLOOD_PH + " / " + Resources.BLOOD_PL;
            //this.lbBloodpressureLName.Text = Resources.BLOOD_PL;
            this.lbCircuitName.Text = Resources.PULSE;
            this.lbTemperatureName.Text = Resources.TEMPERATURE;
            this.lbSpo2Name.Text = Resources.SPO2;
            this.lbBreathingRateName.Text = Resources.BREATHING_RATE;*/

            string patientSetingKey = this._emrCacheManager.PatientSetingKey + this._emrCacheManager.UserName;

            string data = this._emrCacheManager.Get(patientSetingKey);
            if (!string.IsNullOrEmpty(data))
            {
                this.UpDatePatientSetting(data);
                UpdateXpanelPatientInfoSize(data.Split(new char[] { ',' }).Length);
            }
            else
            {
                this.HiddenPatientprofile();
            }
        }

        internal void UpDatePatientSetting(string data)
        {
            HiddenPatientprofile();
            if (!string.IsNullOrEmpty(data))
            {
                string[] settingDataArr = data.Split(new char[] { ',' });
                if (settingDataArr.Length <= 0) return;

                for (int i = 0; i < settingDataArr.Length; i++)
                {
                    UpdatePatientSettingItem(settingDataArr[i]);
                }
                UpdateXpanelPatientInfoSize(settingDataArr.Length);
            }
            else
            {
                this.HiddenPatientprofile();
            }
        }

        private void UpdateXpanelPatientInfoSize(int num)
        {
            //this.xPnlLogoPatient.Size = new System.Drawing.Size(90, num * 21);
            /*this.xPnlPatientDetailValue.Size = new System.Drawing.Size(250, num * 21);*/
            this.xPnlPatientDetailValue.Size = new System.Drawing.Size(250, 125);           
        }

        private void UpdatePatientSettingItem(string lbName)
        {
            switch (lbName)
            {
                case "lbSuname":
                    this.lbSuname.Visible = true;
                    //this.lbSunameName.Visible = true;
                    this.lbSunameName.Visible = false;
                    break;
                case "lbSuname2":
                    this.lbSuname2.Visible = true;
                    //this.lbSuname2Name.Visible = true;
                    this.lbSuname2Name.Visible = false;
                    break;
                case "lbBirthDay":
                    this.lbBirthDay.Visible = true;
                    //this.lbBirthDayName.Visible = true;
                    this.lbBirthDayName.Visible = false;
                    break;
                case "lbSexAge":
                    this.lbSexAge.Visible = true;
                    //this.lbSexAgeName.Visible = true;
                    this.lbSexAgeName.Visible = false;
                    break;
                case "lbHeight":
                    this.lbHeight.Visible = true;
                    //this.lbHeightName.Visible = true;
                    this.lbHeightName.Visible = false;
                    break;
                case "lbWeight":
                    this.lbWeight.Visible = true;
                    //this.lbWeightName.Visible = true;
                    this.lbWeightName.Visible = false;
                    break;
                case "lbGubunName":
                    //this.lbGubunName.Visible = true;
                    this.lbGubunName.Visible = false;
                    break;
                case "lbHeightAndWeight":
                    //this.lbGubunName.Visible = true;
                    this.lbHeightAndWeight.Visible = true;
                    break;                
                case "lbBreathAndBodyHeatAndPulse":
                    //this.lbGubunName.Visible = true;
                    this.lbBreathAndBodyHeatAndPulse.Visible = true;
                    break;
                case "lbBpFromAndToAndSpo2":
                    //this.lbGubunName.Visible = true;
                    this.lbBpFromAndToAndSpo2.Visible = true;
                    break;
                case "lbChojaeName":
                    //this.lbChojaeName.Visible = true;
                    this.lbChojaeName.Visible = false;
                    break;

                case "lbBreathingRate":
                    this.lbBreathingRate.Visible = true;
                    //this.lbBreathingRateName.Visible = true;
                    this.lbBreathingRateName.Visible = false;
                    break;

                case "lbBloodpressureH":
                    this.lbBloodpressureH.Visible = true;
                    //this.lbBloodpressureHName.Visible = true;
                    this.lbBloodpressureHName.Visible = false;
                    break;
                case "lbBloodpressureL":
                    this.lbBloodpressureL.Visible = true;
                    //this.lbBloodpressureLName.Visible = true;
                    this.lbBloodpressureLName.Visible = false;
                    break;
                case "lbCircuit":
                    this.lbCircuit.Visible = true;
                    //this.lbCircuitName.Visible = true;
                    this.lbCircuitName.Visible = false;
                    break;
                case "lbTemperature":
                    this.lbTemperature.Visible = true;
                    //this.lbTemperatureName.Visible = true;
                    this.lbTemperatureName.Visible = false;
                    break;
                case "lbSpo2":
                    this.lbSpo2.Visible = true;
                    //this.lbSpo2Name.Visible = true;
                    this.lbSpo2Name.Visible = false;
                    break;
                default:
                    break;
            }
        }
        private void ResetButton()
        {
            if (NetInfo.Language != LangMode.Jr)
            {
                this.signalPictureBox.Location = new System.Drawing.Point(53, 28);
                this.signalPictureBox2.Location = new Point(74, 28);
                this.signalPictureBox3.Location = new Point(95, 28);
            }
        }

        private void btnNUR1017U00_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;
            CommonItemCollection allergyOpen = new CommonItemCollection();
            if (!string.IsNullOrEmpty(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()))
            {
                allergyOpen.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR1017U00", ScreenOpenStyle.ResponseFixed,
                    allergyOpen);
            }
        }         
        private void btnOUT0106U00_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;
            CommonItemCollection prams = new CommonItemCollection();
            if (!string.IsNullOrEmpty(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()))
            {
                prams.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed,
                    prams);
                //HungNV added
                this.GetSpecialNoteList(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
            }
        }

        private void btnPatientSetting_Click(object sender, EventArgs e)
        {
            Form frPatientSetting = new PatientProfileSettingS(this);
            frPatientSetting.FormBorderStyle = FormBorderStyle.FixedDialog;
            // Set the MaximizeBox to false to remove the maximize box.
            frPatientSetting.MaximizeBox = false;
            // Set the MinimizeBox to false to remove the minimize box.
            frPatientSetting.MinimizeBox = false;
            // Set the start position of the form to the center of the screen.
            frPatientSetting.StartPosition = FormStartPosition.CenterScreen;
            frPatientSetting.ShowDialog();
        } 

        private void TvBunho_NodeMouseDoubleClick(object sender, MouseEventArgs e)
        {
            //todo: bookmark this
            // Ensure selected node is selected.            
            TreeList tree = sender as TreeList;
            TreeListNode node = tree.FocusedNode;
            if (node != null && node.GetValue("HospCode") != null && node.GetValue("HospName") != null)
            {
                string hospCode = node.GetValue("HospCode").ToString().Trim();
                string hospName = node.GetValue("HospName").ToString().Trim();
                string patientCode = node.GetValue("Bunho").ToString().Trim();
                EmrReferS emrRefer = new EmrReferS(hospCode, this.mSelectedPatientInfo.Parameter.Gwa, patientCode, NaewonKey, GetPatientModel());
                emrRefer.Text = String.Format(Resources.EMRREFER, hospName);
                emrRefer.ShowDialog();
                return;
            }
            if (node != null && node.GetValue("IntruduceLetter") != null)
            {
                List<EmrRecordInfo> refRecordInfos;
                if (String.IsNullOrEmpty(oldMmlContent))
                {
                    refRecordInfos = new List<EmrRecordInfo>();
                }
                else
                {
                    Triple<List<EmrRecordInfo>, PatientModelInfo, HospitalModelInfo> returnValue
                        = MmlParserIntruduceLetter.Instance.ToModel(oldMmlContent);
                    refRecordInfos = returnValue.V1;
                }

                if (refRecordInfos != null && refRecordInfos.Count > 0)
                {
                    string bunho = node.GetValue("Bunho").ToString().Trim();
                    CommonItemCollection letterOpen = new CommonItemCollection();
                    letterOpen.Add("f_bunho", bunho);
                    letterOpen.Add("f_hosp_code", UserInfo.HospCode);
                    letterOpen.Add("f_user_id", UserInfo.UserID);
                    letterOpen.Add("mOpener", "");
                    OpenScreenWithParam(this, "OCSO", "NUR2015U01", ScreenOpenStyle.ResponseFixed,
                        letterOpen);
                }
                else
                {
                    XMessageBox.Show(Resources.INTRODUCE_MSG_1, Resources.INTRODUCE_CAP_1, MessageBoxIcon.Warning);
                }
            } 
            else if (node != null && node.GetValue("NaewonDate") != null)
            {
                string naewonDate = node.GetValue("NaewonDate").ToString().Trim();
                //DateTime sysDate = EnvironInfo.GetSysDate();
                DateTime sysDate = _sysDate;
                try
                {
                    //tvExamHist.TvHisExam.BeginUpdate();
                    ucOCS2016U0304.ocS2015U03C1.TvHisExam.BeginUpdate();
                    if (node.Level == 1)
                    {
                        string pkOut1001 = node.GetValue("PkOut1001").ToString().Trim();
                        DateTime calendarDate = DateTime.Parse(naewonDate.Substring(0, 10));
                        if ((calendarDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds <
                            (sysDate - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds)
                            this.ctlEmrDocker.ActiveChildControl("1");
                        else
                            this.ctlEmrDocker.ActiveChildControl("2");
                        /*//todo: implement Feature Scroll with pkOut1001 - anh.lai
                        ctlEmrDocker.Viewer.GotoRecord(naewonDate.Substring(0, 10), pkOut1001);*/
                        ctlEmrDocker.Viewer.ucGrid1.ScrollToDate(naewonDate, pkOut1001);
                        ctlEmrDocker.Viewer.SetDateToDatePicker(naewonDate);


                        #region for tvExamHist

                        //tvExamHist.TvHisExam.Focus();
                        if (pkOut1001.Contains("."))
                        {
                            string[] pkOut1001Arr = pkOut1001.Split(new char[] { '.' });
                            ctlEmrDocker.Viewer.ucGrid1.ScrollToPkOut(pkOut1001Arr[0]);
                        }
                        else if (pkOut1001.Contains(","))
                        {
                            string[] pkOut1001Arr = pkOut1001.Split(new char[] { ',' });
                            ctlEmrDocker.Viewer.ucGrid1.ScrollToPkOut(pkOut1001Arr[0]);
                        }
                        else
                        {
                            ctlEmrDocker.Viewer.ucGrid1.ScrollToPkOut(pkOut1001);
                        }
                        //int intPkOut1001 = Int32.Parse(pkOut1001);

                        #endregion

                        // Set pkout1001 for the viewer
                        this.ctlEmrDocker.Viewer.Pkout1001 = pkOut1001;

                        this.ctlEmrDocker.Viewer.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
                        this.ctlEmrDocker.Viewer.NaewonDate = naewonDate;
                        this.ctlEmrDocker.Viewer.NaewonKey = pkOut1001;
                    }
                }
                finally
                {
                    //tvExamHist.TvHisExam.EndUpdate();
                    ucOCS2016U0304.ocS2015U03C1.TvHisExam.EndUpdate();
                }
            }
        }

        /*private void xPreMonthCalendar_DayDoubleClick(object sender, XCalendarDayClickEventArgs e)
        {
            AdditionalBusiness.AdditionalBusiness.CalendarBehavior(sender, e, this.ctlEmrDocker, this.tvExamHist,
                this.cldExamDates);
        }

        private void calSchedule_DayDoubleClick(object sender, XCalendarDayClickEventArgs e)
        {
            AdditionalBusiness.AdditionalBusiness.CalendarBehavior(sender, e, this.ctlEmrDocker, this.tvExamHist,
                this.cldExamDates);
        }*/                
        /// <summary>
        /// Prevent exception "Reset function was called when no DataWindow object was attached."
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            
            this.pnlOrderList.Controls.Remove(_orderBox);
            this.ctlEmrDocker.DockPanel3Container.Controls.Add(this._orderBox);
            this.tmrPaList.Tick += new System.EventHandler(this.tmrPaList_Tick);
            //LoadDiscussNotify();
            timer1.Start();
            // prevent timer checking before screen loaded
            ApplyMultiLanguage();

            ShowGroupButton1(true);
            Form currentForm = Parent.Parent as Form;
            if (currentForm != null)
            {
                Size size = new Size(1200, 600);
                currentForm.MinimumSize = size;
                //currentForm.Size = size;
            }
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 45, rc.Height - 110);                      
            this.SizeChanged += OCS2016U02_SizeChanged;                        
        }

        #region 각종변수들

        //Message처리
        private string mbxMsg = "", mbxCap = "";
        public string IO_Gubun = "O";
        private Hashtable groupInfo;
        private string iInputGubunName = ""; // 입력구분명 Do, Setオーダ用

        public bool mPostApproveYN = false;
        private bool mPostApprove_Visible = false;
        private bool mApprove_Force = false;

        public int mInsteadInsertedOrderCnt = 0;
        public int mInsteadUpdatedOrderCnt = 0;
        public int mInsteadDeletedOrderCnt = 0;

        //Group
        private ArrayList groupCount;

        public string mChangeBeforeGwa = "";
        private string mClickedOrderButton = "";
        // CP관련 키
        private string mMembGubun = "";
        private string mCpCode = "";
        private string mJaewonil = "";
        private string mCpPathCode = "";
        private string mCpMasterkey = "";

        //입원외래 order
        private string mPkInOutKey = "";

        // 셋트오더 관련 _ 키
        private string mMemb = "";
        private string mYaksokCode = ""; // 셋트이면 약속코드, Cp 이면 Cp Code 가 들어감.

        // 포커스를 위한 로우 번호
        private int mFocusRow = -1;

        private string mMsg = "";
        private string mCap = "";

        ///////////////////////////////////////////////////////////////////////////////////
        // 대기환자리스트 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mReserPatientColor = new XColor(Color.LightGreen);

        private XColor mKensaReserPatientColor = new XColor(Color.SkyBlue);


        ///////////////////////////////////////////////////////////////////////////////////
        // 입력구분 색관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mExistInputGubunColor = new XColor(Color.Red);
        private XColor mNormalInputGubunColor = new XColor(Color.Black);

        ///////////////////////////////////////////////////////////////////////////////////
        // 상병 확장 관련
        ///////////////////////////////////////////////////////////////////////////////////

        private const int mSizeSB = 185;

        private int mExpandedIndex = 2; //↑
        private int mUnExpandedIndex = 1; //↓

        private int mExpandedSize = mSizeSB;
        /*private int mUnExpandedSize = 0; //37*/
        //private int mUnExpandedSize = 55; //37
        private int mUnExpandedSize = 95; //37

        private bool mIsExpanded = true;

        private int mExpandedSBIndex = 1; //↑
        private int mUnExpandedSBIndex = 2; //↓

        private int mExpandedSBSize = (mSizeSB * 2);
        private int mUnExpandedSBSize = mSizeSB; //37

        private bool mIsExpandedSB = false;



        ///////////////////////////////////////////////////////////////////////////////////
        // 라디오버튼 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private XColor mSelectedBackColor = new XColor(Color.FromName("ActiveCaption"));
        private XColor mSelectedForeColor = new XColor(Color.FromName("ActiveCaptionText"));

        private XColor mUnSelectedBackColor = new XColor(Color.FromName("InactiveCaption"));
        private XColor mUnSelectedForeColor = new XColor(Color.FromName("InactiveCaptionText"));

        //change width size due to MED-5211
        //private int mInputTabDefaultWidth = 94;
        private int mInputTabDefaultWidth = 84;
        private int mInputTabDefaultHeight = 26;
        private int mInputTabDefaultYLoc = 4;
        private int mInputTabDefaultXLoc = 38;

        ///////////////////////////////////////////////////////////////////////////////////
        // 라이브러리
        ///////////////////////////////////////////////////////////////////////////////////
        private OCS.PatientInfo.clsParameter mPatientInfoParam = new IHIS.OCS.PatientInfo.clsParameter();
        private OCS.PatientInfo mSelectedPatientInfo;
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OCS2015U00");
        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OCS2015U00");
        private OCS.HangmogInfo mHangmogInfo = new HangmogInfo("OCS2015U00");
        private OCS.CommonForms mCommonForms = new CommonForms();
        private OCS.OrderInterface mInterface = new OrderInterface();


        ///////////////////////////////////////////////////////////////////////////////////
        // 로컬변수
        ///////////////////////////////////////////////////////////////////////////////////
        private string mParamNaewonKey = "";
        //private string mParamNaewonDate = "";
        private string mParamBunho = "";
        private string mParamGwa = "";
        private string mParamDoctor = "";
        private ArrayList mBunhoInfoControls = new ArrayList();

        private bool mDoctorLogin = false;
        private bool mIsOCSSystem = false;

        private bool mPatientDoubleClick = false;

        // Do, Set Order用
        private string iInputGubun = "";
        // 既存外来オーダ情報照会用
        public string mInputGubun = "";
        private string mInputGwa = "";
        //GROUP_KEY
        private string mGroup_key = "";

        private string mClickedNaewonKey = "";
        //insert by jc [選択された患者の保険を取得]
        private string mClickedGubun = "";

        private const string mInputGubunDoctor = "D%";

        //Doオーダ関連変数
        private string INPUTTAB = ""; // 내복약 (01) 
        private const string IOEGUBUN = "O"; // 입외구분(외래)

        private string mInputPart = ""; // 입력파트(01)
        //private string mCallerSysID = "";
        //private string mCallerScreenID = "";

        //공통
        private string mOrderDate = "";
        private OrderVariables.OrderMode mOrderMode = OrderVariables.OrderMode.OutOrder;

        //insert by jc[Sysdateを保存ボタンを押す時点の時間にするため]
        internal string mSave_time = "";

        // 저장용 flag 변수 
        private bool mIsUpdateSuccess = false;


        // 체크용 플레그 변수
        private bool mIsCheck = false;
        private List<OcsoOCS1003P01LayoutQueryInfo> lstOutOrderInfo;
        internal OCS1003P01GrdPatientResult grdPatientResult;
        internal OCS2015U21GrdPatientResult grdPatientResultOCS2015U21;
        // 팝업메뉴
        private IHIS.X.Magic.Menus.PopupMenu mMenuPFEResult = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuInputGubunResult = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuGroupButtonBox1 = new IHIS.X.Magic.Menus.PopupMenu();
        private IHIS.X.Magic.Menus.PopupMenu mMenuGroupButtonBox2 = new IHIS.X.Magic.Menus.PopupMenu();

        ///////////////////////////////////////////////////////////////////////////////////
        // 진료 종료 관련
        ///////////////////////////////////////////////////////////////////////////////////
        private const string JINRYO_END = "E";
        private const string JINRYO_BORYU = "H";
        private const string MI_JINRYO = "Y";

        private string mCurrentInputTab = "";

        private bool mIsCalledbyOtherScreen = false;

        // CPL 출력 리스트 관련
        private ArrayList mCplPrintList = new ArrayList();

        private const string CACHE_EMR_RECORD_SCHEMA_PATTERN = "CACHE_EMR_RECORD_SCHEMA_{0}_{1}_{2}";
        private const string CACHE_EMR_RECORD_DATA_PATTERN = "CACHE_EMR_RECORD_DATA_{0}_{1}_{2}";

        // Key for save cache master data
        private const string GET_DEPARTMENT_KEYS = "Combo.Gwa";
        private const string MAKE_INPUT_GUBUN_TAB_NR_KEY = "MakeInputGubunTab.NR";
        private const string MAKE_INPUT_GUBUN_TAB_D0_KEY = "MakeInputGubunTab.D0";

        public XFindBox FbxBunho
        {
            get { return this.fbxBunho; }
        }

        public XButtonList BtnList
        {
            get { return this.btnList; }
        }

        public XPanel PnlInputTab
        {
            get { return OrderBox.PnlInputTab; }
        }

        public XEditGrid GrdReserOrderList
        {
            get { return OrderBox.GrdReserOrderList; }
        }

        public bool MDoctorLogin
        {
            get { return this.mDoctorLogin; }
        }

        public OrderBiz MOrderBiz
        {
            get { return this.mOrderBiz; }
        }

        public string N_IO_Gubun
        {
            get { return this.IO_Gubun; }
        }

        public IHIS.OCS.PatientInfo MSelectedPatientInfo
        {
            get { return this.mSelectedPatientInfo; }
        }

        public bool MPatientDoubleClick
        {
            get { return this.mPatientDoubleClick; }
            set { this.mPatientDoubleClick = value; }
        }

        public XButton BtnApprove
        {
            get { return this.btnApprove; }
        }

        private bool _isShowBtnApprove;

        public bool IsShowBtnApprove
        {
            get { return _isShowBtnApprove; }
            set { _isShowBtnApprove = value; }
        }

        public XButton BtnDoOrder
        {
            get { return this.btnDoOrder; }
        }

        public bool MPostApproveYN
        {
            get { return this.mPostApproveYN; }
            set { this.mPostApproveYN = value; }
        }

        public bool MIsExpandedSB
        {
            get { return this.mIsExpandedSB; }
        }

        public XButton BtnExpandSB
        {
            get { return this.btnExpandSB; }
        }

        public XFlatLabel LblApproveFlag
        {
            get { return this.lblApproveFlag; }
        }

        public XFlatLabel LblApproveDoctorName
        {
            get { return this.lblApproveDoctorName; }
        }

        public XColor MSelectedBackColor
        {
            get { return this.mSelectedBackColor; }
        }

        public XColor MSelectedForeColor
        {
            get { return this.mSelectedForeColor; }
        }

        public XColor MUnSelectedBackColor
        {
            get { return this.mUnSelectedBackColor; }
        }

        public XColor MUnSelectedForeColor
        {
            get { return this.mUnSelectedForeColor; }
        }

        public string MClickedNaewonKey
        {
            get { return this.mClickedNaewonKey; }
            set { this.mClickedNaewonKey = value; }
        }

        public string MClickedGubun
        {
            get { return this.mClickedGubun; }
            set { this.mClickedGubun = value; }
        }

        public XColor MReserPatientColor
        {
            get { return this.mReserPatientColor; }
        }

        public XColor MKensaReserPatientColor
        {
            get { return this.mKensaReserPatientColor; }
        }

        public string MMsg
        {
            get { return this.mMsg; }
            set { this.mMsg = value; }
        }

        public string MCap
        {
            get { return this.mCap; }
            set { this.mCap = value; }
        }

        public OCS.PatientInfo.clsParameter MPatientInfoParam
        {
            get { return this.mPatientInfoParam; }
        }

        public string MParamNaewonKey
        {
            get { return this.mParamNaewonKey; }
            set { this.mParamNaewonKey = value; }
        }

        public string MGroup_key
        {
            get { return this.mGroup_key; }
            set { this.mGroup_key = value; }
        }

        public XPaInfoBox PaInfoBox
        {
            get { return this.paInfoBox; }
        }

        public PictureBox PbxApprove
        {
            get { return this.pbxApprove; }
            set { pbxApprove = value; }
        }

        public XButton BtnIpwonReser
        {
            get { return this.btnIpwonReser; }
        }

        public XButton BtnConsult
        {
            get { return this.btnConsult; }
        }

        private bool _isShowBtnConsult;

        public bool IsShowBtnConsult
        {
            get { return _isShowBtnConsult; }
            set { _isShowBtnConsult = value; }
        }


        public XButton BtnConsultAnswer
        {
            get { return this.btnConsultAnswer; }
        }

        private bool _isShowBtnConsultAnswer;

        public bool IsShowBtnConsultAnswer
        {
            get { return _isShowBtnConsultAnswer; }
            set { _isShowBtnConsultAnswer = value; }
        }

        public XButton BtnJinryoReser
        {
            get { return this.btnJinryoReser; }
        }

        public XButton BtnOpenOutSang
        {
            get { return this.btnOpenOutSang; }
        }
        public string MParamDoctor
        {
            get { return this.mParamDoctor; }
        }

        public string MInputGwa
        {
            get { return this.mInputGwa; }
        }

        public string MParamGwa
        {
            get { return this.mParamGwa; }
        }

        public XDatePicker DtpNaewonDate
        {
            get { return pendingPatient.PatientBox.DtpNaewonDate; }
        }

        public string MCurrentInputTab
        {
            get { return this.mCurrentInputTab; }
        }

        public int MExpandedSize
        {
            get { return this.mExpandedSize; }
        }

        public bool MIsExpanded
        {
            get { return this.mIsExpanded; }
            set { this.mIsExpanded = value; }
        }

        /*public XPanel PnlSang
        {
            get { return this.pnlSang; }
        }*/

        public int MUnExpandedSize
        {
            get { return this.mUnExpandedSize; }
        }

        public int MUnExpandedIndex
        {
            get { return this.mUnExpandedIndex; }
        }

        public int MExpandedIndex
        {
            get { return this.mExpandedIndex; }
        }

        #endregion

        #region [ Screen 이벤트 ]

        private void OCS1003P01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (EnvironInfo.CurrSystemID == "INSI" && UserInfo.Gwa != "CK")
            {
                return;
            }
            // 화면 사이즈 조정
            // 화면 크기를 화면에 맞게 최대화 시킨다 (다른 화면에서 연경우가 아닌경우)
            //if (this.Opener is IHIS.Framework.MdiForm &&
            //    (this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpSizable || this.OpenStyle == IHIS.Framework.ScreenOpenStyle.PopUpFixed))
            //{ 
            //    Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //    this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);
            //}

            // Get UserOptions - Added by AnhNV
            this.GetUserOptions();

            CheckRemindBackRuleTime();

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(rc.Width - 30, rc.Height - 110);

            // 환자번호 입력자릿수 설정
            this.fbxBunho.MaxLength = EnvironInfo.BunhoLength;

            // 환자번호 컨트롤 셋팅
            this.mBunhoInfoControls.Add(this.fbxBunho);
            this.mBunhoInfoControls.Add(this.lbSuname);
            this.mBunhoInfoControls.Add(this.lbSuname2);
            this.mBunhoInfoControls.Add(this.lbBirthDay);
            this.mBunhoInfoControls.Add(this.lbSexAge);
            this.mBunhoInfoControls.Add(this.lbWeight);
            this.mBunhoInfoControls.Add(this.lbHeight);
            this.mBunhoInfoControls.Add(this.lbHeightAndWeight);
            this.mBunhoInfoControls.Add(this.lbGubunName);
            this.mBunhoInfoControls.Add(this.lbChojaeName);

            //Added by HungNV
            this.mBunhoInfoControls.Add(this.lbCircuit);
            this.mBunhoInfoControls.Add(this.lbBreathAndBodyHeatAndPulse);
            this.mBunhoInfoControls.Add(this.lbBpFromAndToAndSpo2);
            this.mBunhoInfoControls.Add(this.lbBloodpressureH);
            this.mBunhoInfoControls.Add(this.lbBloodpressureL);
            this.mBunhoInfoControls.Add(this.lbTemperature);
            this.mBunhoInfoControls.Add(this.lbSpo2);
            this.mBunhoInfoControls.Add(this.lbBreathingRate);
            // 각종 변수 초기화
            this.mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name); // 환자정보 

            if (EnvironInfo.CurrSystemID == "OCSA" ||
                EnvironInfo.CurrSystemID == "OCSO" ||
                EnvironInfo.CurrSystemID == "OCSI")
            {
                this.mIsOCSSystem = true;
            }

            // 팝업메뉴 초기화
            // 오더 팝업메뉴
            // 처방Grid PopupMenu
            mMenuPFEResult.MenuCommands.Clear();
            //btnENDOResult.Location = new Point(3, 645);
            //btnENDOResult.Location = new Point(3, 740);
            /*btnKarteOfOrtherClinics.Location = new Point(92, 645);*/
            lblDownloadEMR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDownloadEMR.Location = new System.Drawing.Point(btnDownloadEMR.Location.X + 120 + 2, btnDownloadEMR.Location.Y + 1);
            CheckHideButtonArgs args = new CheckHideButtonArgs();
            args.CodeType = "RESULT_BUTTON_USE_YN";
            //CheckHideButtonResult result = CloudService.Instance.Submit<CheckHideButtonResult, CheckHideButtonArgs>(args);
            //Comment for not update cache when change data
            // 2015.11.30 AnhNV caching to increase load performance
            CheckHideButtonResult result = CacheService.Instance.Get<CheckHideButtonArgs, CheckHideButtonResult>(args, delegate(CheckHideButtonResult r)
            {
                return r.ExecutionStatus == ExecutionStatus.Success && r.Dt.Count > 0;
            });

            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                bool check = false;
                foreach (CheckHideButtonInfo item in result.Dt)
                {
                    if (item.CodeName.Equals("Y"))
                    {
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    CheckHideButtonInfo item;
                    IHIS.X.Magic.Menus.MenuCommand popUpMenu;
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_6,
                        (Image)this.ImageList.Images[21], new EventHandler(btnImageResult_Click));
                    popUpMenu.Tag = "1";
                    item = GetItemHideButton(result.Dt, "CPL");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_7,
                        (Image)this.ImageList.Images[19], new EventHandler(btnXRTResult_Click));
                    popUpMenu.Tag = "2";
                    item = GetItemHideButton(result.Dt, "XRT");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_9,
                        (Image)this.ImageList.Images[29], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "3";
                    item = GetItemHideButton(result.Dt, "END");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_10,
                        (Image)this.ImageList.Images[14], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "4";
                    item = GetItemHideButton(result.Dt, "ENDR");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_11,
                        (Image)this.ImageList.Images[10], new EventHandler(PopUpMenuPfeResult_Click));
                    popUpMenu.Tag = "5";
                    item = GetItemHideButton(result.Dt, "EKG");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.POP_UP_MENU_TEXT_8,
                        (Image)this.ImageList.Images[38], new EventHandler(xbtRehaActedOrder_Click));
                    popUpMenu.Tag = "6";
                    item = GetItemHideButton(result.Dt, "REH");
                    if (item != null && item.CodeName.Equals("N"))
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);

                    popUpMenu = new IHIS.X.Magic.Menus.MenuCommand(Resources.OCS2015U00_BtnEPortViewer,
                        null, new EventHandler(btnEPortViewer_Click));
                    popUpMenu.Tag = "7";
                    if (!_isShowBtnEportViewer)
                    {
                        popUpMenu.Visible = false;
                    }
                    mMenuPFEResult.MenuCommands.Add(popUpMenu);
                }
                else
                {
                    btnENDOResult.Visible = false;
                }
            }

            mMenuInputGubunResult.MenuCommands.Clear();
            IHIS.X.Magic.Menus.MenuCommand popUpMenu_InputGubun;

            popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG30_MSG,
                (Image)this.ImageList.Images[6],
                new EventHandler(PopUpMenuInputGubunResult_Click));
            popUpMenu_InputGubun.Tag = "D0";
            mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);

            popUpMenu_InputGubun = new IHIS.X.Magic.Menus.MenuCommand(Resources.MSG31_MSG,
                (Image)this.ImageList.Images[45],
                new EventHandler(PopUpMenuInputGubunResult_Click));
            popUpMenu_InputGubun.Tag = "CK";
            mMenuInputGubunResult.MenuCommands.Add(popUpMenu_InputGubun);
            
            /*CreateGroupButton1();
            CreateGroupButton2();*/

            CheckShowPbxGroupButton1();

            // SavePerformer Setting 
            this.layDeletedData.SavePerformer = new XSavePeformerS(this);
            this.laySaveLayout.SavePerformer = this.layDeletedData.SavePerformer;
            this.grdOutSang.SavePerformer = this.layDeletedData.SavePerformer;

            // User Change 이벤트 구동
            this.mIsCheck = true;
            this.OCS1003P01_UserChanged(this, new EventArgs());
            this.mIsCheck = false;

            //this.btnHelp2.Location = new Point(btnHelp2.Location.X, this.btnHelp2.Location.Y - this.pnlUser.Size.Height);
            //this.pnlHelp2.Location = new Point(pnlHelp2.Location.X, this.pnlHelp2.Location.Y - this.pnlUser.Size.Height);

            PostCallHelper.PostCall(new PostMethod(PostOpenEvent));

            this.initScreen();

        }

        private void CheckRemindBackRuleTime()
        {
            if (string.IsNullOrEmpty(UserOptions.EmrBackRule) && string.IsNullOrEmpty(UserOptions.EmrBackTime)) return;
            else
            {
                string currentDay = _sysDate.ToString("dddd");
                int iCurrentDayOfWeek = (int)_sysDate.DayOfWeek;
                int iCurrentDayOfMonth = _sysDate.Day;

                if (string.IsNullOrEmpty(UserOptions.EmrBackRule) ||
                    string.IsNullOrEmpty(UserOptions.EmrBackRule.Trim()))
                {
                    //Day
                    CheckEmrBackTime();
                }
                else
                {
                    if (UserOptions.EmrBackRule.Contains(EmrBackRule.W.ToString()))
                    {
                        //Weekly
                        if (UserOptions.EmrBackRule.EndsWith(iCurrentDayOfWeek.ToString()))
                        {
                            CheckEmrBackTime();
                        }
                    }
                    else if (UserOptions.EmrBackRule.Contains(EmrBackRule.M.ToString()))
                    {
                        //Month
                        if (UserOptions.EmrBackRule.EndsWith(iCurrentDayOfMonth.ToString()))
                        {
                            CheckEmrBackTime();
                        }
                    }
                }
            }
        }

        private void CheckEmrBackTime()
        {
            CheckCountDown();
        }

        private int tsCounter = 0;

        private void CheckCountDown()
        {
            try
            {
                DateTime emrBackTime = Convert.ToDateTime(UserOptions.EmrBackTime);
                DateTime sysDateTime = EnvironInfo.GetSysDateTime();
                tsCounter = (int)emrBackTime.Subtract(sysDateTime).TotalSeconds;
                if (tsCounter > 0)
                {
                    timerCountDown.Tick += new EventHandler(timerCountDown_Tick);
                    timerCountDown.Interval = 1000; // 1 second
                    timerCountDown.Start();
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of CheckCountDown() method: " + ex.StackTrace);
            }
        }

        private void timerCountDown_Tick(object sender, EventArgs e)
        {
            if (tsCounter > 0)
            {
                tsCounter--;
                if (tsCounter == 0)
                {
                    ShowMessageRemindBackTime();
                    timerCountDown.Stop();
                }
            }
        }

        private void ShowMessageRemindBackTime()
        {
            XMessageBox.Show(Resources.Emr_Back_Time_Msg_Remind);
        }

        private void CheckShowButtonPatientU21AndJinryoReser()
        {
            CheckHideButtonInfo item;
            item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS2015U21");
            if (item != null && item.CodeName.Equals("Y"))
            {
                btn2015U21.Visible = true;
            }
            else btn2015U21.Visible = false;
            item = GetItemHideButton(hideButtonLst.Dt, "btn_RES1001U00");
            if (item != null && item.CodeName.Equals("Y"))
            {
                btnJinryoReser.Visible = true;
            }
            else btnJinryoReser.Visible = false;
        }
        private void ShowGroupButton1(bool show)
        {
            List<Point> lstLocation = new List<Point>();
            for (int i = 0; i < 11; i++)
            {
                lstLocation.Add(new Point(20, 5 + i * 30));
                lstLocation.Add(new Point(150, 5 + i * 30));
            }
            int index = 0;
            CheckHideButtonInfo item;
            if (show)
            {
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS1003R02");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnOrderGuide.Visible = true;
                    btnOrderGuide.Location = lstLocation[index];
                    btnOrderGuide.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnOrderGuide.Visible = false;
                }
                //        this.btnOrderGuide.Location = new System.Drawing.Point(1, 440 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U10");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnDrgOrder.Visible = true;
                    btnDrgOrder.Location = lstLocation[index];
                    btnDrgOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnDrgOrder.Visible = false;
                }
                /*btnPrescriptionPrint*/
                item = GetItemHideButton(hideButtonLst.Dt, "btn_PRESCRIPTION");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnPrescriptionPrint.Visible = true;
                    btnPrescriptionPrint.Location = lstLocation[index];
                    btnPrescriptionPrint.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnPrescriptionPrint.Visible = false;
                }                
                /*btnPrescriptionPrint*/

                //        this.btnOpenOutSang.Location = new System.Drawing.Point(1, 470 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U12");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnJusaOrder.Visible = true;
                    btnJusaOrder.Location = lstLocation[index];
                    btnJusaOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnJusaOrder.Visible = false;
                }

                //        this.btnDrgOrder.Location = new System.Drawing.Point(140, 440 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OUTSANGU00");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnOpenOutSang.Visible = true;
                    btnOpenOutSang.Location = lstLocation[index];
                    btnOpenOutSang.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnOpenOutSang.Visible = false;
                }
                //        this.btnSetOrder.Location = new System.Drawing.Point(1, 500 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U13");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnCplOrder.Visible = true;
                    btnCplOrder.Location = lstLocation[index];
                    btnCplOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnCplOrder.Visible = false;
                }
                //        this.btnJusaOrder.Location = new System.Drawing.Point(140, 470 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0301Q09");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnSetOrder.Visible = true;
                    btnSetOrder.Location = lstLocation[index];
                    btnSetOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnSetOrder.Visible = false;
                }
                //        this.btnDoOrder.Location = new System.Drawing.Point(1, 530 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U17");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnChuchiOrder.Visible = true;
                    btnChuchiOrder.Location = lstLocation[index];
                    btnChuchiOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnChuchiOrder.Visible = false;
                }
                //        this.btnCplOrder.Location = new System.Drawing.Point(140, 500 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS1003Q09");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnDoOrder.Visible = true;
                    btnDoOrder.Location = lstLocation[index];
                    btnDoOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnDoOrder.Visible = false;
                }
               
                //        this.btnChuchiOrder.Location = new System.Drawing.Point(140, 530 + heigh);
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U14");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnPfeOrder.Visible = true;
                    btnPfeOrder.Location = lstLocation[index];
                    btnPfeOrder.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnPfeOrder.Visible = false;
                }
                item = GetItemHideButton(hideButtonLst.Dt, "btn_MOVIETALK");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnMovieTalk.Visible = true;
                    btnMovieTalk.Location = lstLocation[index];
                    index++;
                    btnMovieTalk.Size = new System.Drawing.Size(96, 27);
                }
                else
                {
                    btnMovieTalk.Visible = false;
                }

                /*Because Y CAO need this change so temporary we should apply change position for VN only (check locale = VI )
                other locale as JP, EN, ... no change.
                -------
                After that, create new feature to change / rearrange button by doctors. I think you should merge to Improve UX, not for next version*/
                if (IsVI())
                {
                    item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U16");
                    if (item != null && item.CodeName.Equals("Y"))
                    {
                        btnXrtOrderForVi.Visible = true;
                        btnXrtOrderForVi.Location = lstLocation[index];
                        index++;
                        btnXrtOrderForVi.Size = new System.Drawing.Size(96, 27);
                    }
                    else
                    {
                        btnXrtOrderForVi.Visible = false;
                    } 
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS1003R00");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnOrderPrint.Visible = true;
                    btnOrderPrint.Location = lstLocation[index];
                    btnOrderPrint.Size = new System.Drawing.Size(96, 27);
                    index++;
                }
                else
                {
                    btnOrderPrint.Visible = false;
                }
            }
            else
            {
                btnOrderGuide.Visible = false;
                btnDrgOrder.Visible = false;
                btnOpenOutSang.Visible = false;
                btnJusaOrder.Visible = false;
                btnSetOrder.Visible = false;
                btnCplOrder.Visible = false;
                btnDoOrder.Visible = false;
                btnChuchiOrder.Visible = false;
                btnPfeOrder.Visible = false;
                btnMovieTalk.Visible = false;
            }

        }

        private void ShowGroupButton2(bool show)
        {
            List<Point> lstLocation = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                lstLocation.Add(new Point(20, 5 + i * 30));
                lstLocation.Add(new Point(150, 5 + i * 30));
            }
            int index = 0;
            CheckHideButtonInfo item;
            if (show)
            {
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCSAPPROVE");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnApprove.Visible = true;
                    pbxApprove.Visible = true;
                    btnApprove.Location = lstLocation[index];
                    pbxApprove.Location = new Point(lstLocation[index].X + 6, lstLocation[index].Y + 6);
                    index++;
                }
                else
                {
                    btnApprove.Visible = false;
                    pbxApprove.Visible = false;
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_NUR1001R98");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnKensaReser.Visible = true;
                    btnKensaReser.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnKensaReser.Visible = false;
                }

                //item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS1003R00");
                //if (item != null && item.CodeName.Equals("Y"))
                //{
                //    btnOrderPrint.Visible = true;
                //    btnOrderPrint.Location = lstLocation[index];
                //    index++;
                //}
                //else
                //{
                //    btnOrderPrint.Visible = false;
                //}

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0503U00");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnConsult.Visible = true;
                    btnConsult.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnConsult.Visible = false;
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0503U01");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnConsultAnswer.Visible = true;
                    btnConsultAnswer.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnConsultAnswer.Visible = false;
                }
                if (NetInfo.Language == LangMode.En)
                {
                    this.btnDiscuss.Visible = false;
                }
                else
                {
                    this.btnDiscuss.Visible = true;
                    btnDiscuss.Location = lstLocation[index];
                    pbxNotifyON.Location = new Point(lstLocation[index].X + 2, lstLocation[index].Y + 6);
                    this.pbxNotifyON.Visible = _isShowPbxNotifyON && show ? true : false;
                    index++;
                }
                this.btnKarteOfOrtherClinics.Visible = show;
                btnKarteOfOrtherClinics.Location = lstLocation[index];
            }
            else
            {
                btnApprove.Visible = false;
                pbxApprove.Visible = false;
                btnKensaReser.Visible = false;
                btnOrderPrint.Visible = false;
                btnConsult.Visible = false;
                btnConsultAnswer.Visible = false;
                btnKarteOfOrtherClinics.Visible = false;
                pbxNotifyON.Visible = false;
                this.btnDiscuss.Visible = false;
            }          

        }

        private void ShowGroupButton3(bool show)
        {
            List<Point> lstLocation = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                lstLocation.Add(new Point(20, 5 + i * 30));
                lstLocation.Add(new Point(150, 5 + i * 30));
            }
            int index = 0;
            CheckHideButtonInfo item;

            if (show)
            {
                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U11");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnReha.Visible = true;
                    btnReha.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnReha.Visible = false;
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U15");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnAplOrder.Visible = true;
                    btnAplOrder.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnAplOrder.Visible = false;
                }

                if (!IsVI())
                {
                    item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U16");
                    if (item != null && item.CodeName.Equals("Y"))
                    {
                        btnXrtOrder.Visible = true;
                        btnXrtOrder.Location = lstLocation[index];
                        index++;
                    }
                    else
                    {
                        btnXrtOrder.Visible = false;
                    }
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U18");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnSusulOrder.Visible = true;
                    btnSusulOrder.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnSusulOrder.Visible = false;
                }

                item = GetItemHideButton(hideButtonLst.Dt, "btn_OCS0103U19");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    btnEtcOrder.Visible = true;
                    btnEtcOrder.Location = lstLocation[index];
                    index++;
                }
                else
                {
                    btnEtcOrder.Visible = false;
                }

            }
            else
            {
                btnReha.Visible = false;
                btnAplOrder.Visible = false;
                btnXrtOrder.Visible = false;
                btnXrtOrderForVi.Visible = false;
                btnSusulOrder.Visible = false;
                btnEtcOrder.Visible = false;
            }
        }

        private void CheckShowPbxGroupButton1()
        {
            if (pbxApprove.Visible || pbxIsNoAnwerOfConsulted.Visible || pbxNotifyON.Visible || _isShowPbxNotifyON)
            {
                pbxIsShowSignalBoxButton1.Visible = true;
            } else pbxIsShowSignalBoxButton1.Visible = false;
        }
        private void CreateGroupButton1()
        {
            IHIS.X.Magic.Menus.MenuCommand popUpMenuGroupButton1;
            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnApprove.Text"),
                (Image)this.ImageList.Images[31], new EventHandler(btnApprove_Click));
            popUpMenuGroupButton1.Tag = "1";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);

            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnKensaReser.Text"),
                (Image)this.ImageList.Images[29], new EventHandler(btnKensaReser_Click));
            popUpMenuGroupButton1.Tag = "2";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);

            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnOrderPrint.Text"),
                (Image)this.ImageList.Images[23], new EventHandler(btnOrderPrint_Click));
            popUpMenuGroupButton1.Tag = "3";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);

            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnConsult.Text"),
                (Image)this.ImageList.Images[22], new EventHandler(btnConsult_Click));
            popUpMenuGroupButton1.Tag = "4";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);

            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnConsultAnswer.Text"),
                (Image)this.ImageList.Images[22], new EventHandler(btnConsultAnswer_Click));
            popUpMenuGroupButton1.Tag = "5";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);

            //Fix bug MED-9901
            if (NetInfo.Language != IHIS.Framework.LangMode.En)
            {
                popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnDiscuss.Text"),
                (Image)this.ImageList.Images[22], new EventHandler(btnDiscuss_Click));
                popUpMenuGroupButton1.Tag = "6";
                mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);
            }           
            /*popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnKarteOfOrtherClinics.Text"),
                (Image)this.ImageList.Images[52], new EventHandler(btnKarteOfOrtherClinics_Click));*/
            Image imageDiscuss = Image.FromFile(Environment.CurrentDirectory + "\\Images\\aquapuls.gif");
            popUpMenuGroupButton1 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnKarteOfOrtherClinics.Text"),
                imageDiscuss, new EventHandler(btnKarteOfOrtherClinics_Click));
            popUpMenuGroupButton1.Tag = "7";
            mMenuGroupButtonBox1.MenuCommands.Add(popUpMenuGroupButton1);
        }

        private void CreateGroupButton2()
        {
            IHIS.X.Magic.Menus.MenuCommand popUpMenuGroupButton2;
            popUpMenuGroupButton2 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnReha.Text"),
                (Image)this.ImageList.Images[38], new EventHandler(btnReha_Click));
            popUpMenuGroupButton2.Tag = "1";
            mMenuGroupButtonBox2.MenuCommands.Add(popUpMenuGroupButton2);

            popUpMenuGroupButton2 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnAplOrder.Text"),
                (Image)this.ImageList.Images[11], new EventHandler(btnAplOrder_Click));
            popUpMenuGroupButton2.Tag = "2";
            mMenuGroupButtonBox2.MenuCommands.Add(popUpMenuGroupButton2);

            popUpMenuGroupButton2 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnXrtOrder.Text"),
                (Image)this.ImageList.Images[9], new EventHandler(btnXrtOrder_Click));
            popUpMenuGroupButton2.Tag = "3";
            mMenuGroupButtonBox2.MenuCommands.Add(popUpMenuGroupButton2);

            popUpMenuGroupButton2 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnSusulOrder.Text"),
                (Image)this.ImageList.Images[13], new EventHandler(btnSusulOrder_Click));
            popUpMenuGroupButton2.Tag = "4";
            mMenuGroupButtonBox2.MenuCommands.Add(popUpMenuGroupButton2);

            popUpMenuGroupButton2 = new IHIS.X.Magic.Menus.MenuCommand(XMsg.GetField("this.btnEtcOrder.Text"),
                (Image)this.ImageList.Images[14], new EventHandler(btnEtcOrder_Click));
            popUpMenuGroupButton2.Tag = "5";
            mMenuGroupButtonBox2.MenuCommands.Add(popUpMenuGroupButton2);
        }

        private void PopUpMenuInputGubunResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand btn = sender as IHIS.X.Magic.Menus.MenuCommand;

            if (btn != null && this.IsGrantOrderUser(btn.Tag.ToString()) == false) return;

            switch (this.mClickedOrderButton)
            {
                case "10":
                    this.OpenScreen_OCS0103U10(true, btn.Tag.ToString());
                    break;
                case "11":
                    this.OpenScreen_OCS0103U11(true, btn.Tag.ToString());
                    break;
                case "12":
                    this.OpenScreen_OCS0103U12(true, btn.Tag.ToString());
                    break;
                case "13":
                    this.OpenScreen_OCS0103U13(true, btn.Tag.ToString());
                    break;
                case "14":
                    this.OpenScreen_OCS0103U14(true, btn.Tag.ToString());
                    break;
                case "15":
                    this.OpenScreen_OCS0103U15(true, btn.Tag.ToString());
                    break;
                case "16":
                    this.OpenScreen_OCS0103U16(true, btn.Tag.ToString());
                    break;
                case "17":
                    this.OpenScreen_OCS0103U17(true, btn.Tag.ToString());
                    break;
                case "18":
                    this.OpenScreen_OCS0103U18(true, btn.Tag.ToString());
                    break;
                case "19":
                    this.OpenScreen_OCS0103U19(true, btn.Tag.ToString());
                    break;
            }

        }

        private void initScreen()
        {
            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "EMR_POP_YN", this.IO_Gubun) == "Y")
            if (UserOptions.EmrPopYn == "Y")
            {
                this.cbxOpenEmr.Checked = true;
            }

            //this.grdReserOrderList.AutoSizeColumn(1, 0); // オーダー日
            OrderBox.GrdReserOrderList.AutoSizeColumn(2, 0); // 実施予定日
            OrderBox.GrdReserOrderList.AutoSizeColumn(3, 0); // 診療科
            //OrderBox.GrdReserOrderList.AutoSizeColumn(5, 0); // 診療医
            //OrderBox.GrdReserOrderList.AutoSizeColumn(4, 0); // オーダー名
            OrderBox.GrdReserOrderList.AutoSizeColumn(6, 0); // 実施部署
            OrderBox.GrdReserOrderList.AutoSizeColumn(7, 0); // 当/予
            OrderBox.GrdReserOrderList.AutoSizeColumn(8, 0); // 予約日付
            OrderBox.GrdReserOrderList.AutoSizeColumn(9, 0); // 未/完

            this.mPostApproveYN = false;
            this.lblApproveFlag.Text = "事前";

            // 承認プロセス関連FLAG取得
            this.mOrderBiz.GetApproveFlags(ref this.mPostApprove_Visible, ref this.mApprove_Force);

            //if (!this.mPostApprove_Visible)
            //    this.lblApprove.Visible = false;　// 事後承認を見せない

            // ログインしたユーザーが代行者であれば
            if (UserInfo.Gwa == "CK")
            {
                this.cbxMsgSysYN.Visible = true;
                this.cbxMsgSysYN.Checked = true;
            }
            else
            {
                this.cbxMsgSysYN.Visible = false;
            }
        }

        private void PostOpenEvent()
        {
            // InputTab 탭 구성 -- 사이즈 계산을 제대로 못함. 여기서 해야함
            this.MakeInputTab();

            this.lblJinryoGwa.Location = new Point(this.cboOutSang.Location.X + this.cboOutSang.Size.Width + 10, 5);

            this.cboJinryoGwa.Location = new Point(this.lblJinryoGwa.Location.X + this.lblJinryoGwa.Size.Width + 5, 5);

        }

        private void OCS1003P01_UserChanged(object sender, EventArgs e)
        {
            // 일단 전체 클리어 해놓고 
            pendingPatient.PatientBox.CboQryGwa.SelectedValueChanged -=
                new EventHandler(pendingPatient.PatientBox.cboQryGwa_SelectedValueChanged);
            this.Reset();
            pendingPatient.PatientBox.CboQryGwa.SelectedValueChanged +=
                new EventHandler(pendingPatient.PatientBox.cboQryGwa_SelectedValueChanged);
            // 사용자권한체크
            IsOrderInputUserCheck(true);
            this.InitializeScreen(mIsCheck);
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 각종 오더 입력 버튼 ]

        /// <summary>
        /// 약오더 입력버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrgOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U10(true);

        }

        /// <summary>
        /// 주사오더 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJusaOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U12(true);

        }

        /// <summary>
        /// 검체검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCplOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U13(true);
        }

        /// <summary>
        /// 처치오더 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChuchiOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U17(true);
        }

        /// <summary>
        /// 수술오더 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSusulOrder_Click(object sender, EventArgs e)
        {
            /*XButton button = sender as XButton;*/

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            /*this.mClickedOrderButton = button.Tag.ToString();*/

            this.OpenScreen_OCS0103U18(true);

        }

        /// <summary>
        /// 생리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPfeOrder_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            this.mClickedOrderButton = button.Tag.ToString();

            this.OpenScreen_OCS0103U14(true);

        }
        private void btnMovieTalk_Click(object sender, EventArgs e)
        {
            string movieTalk = "";
            //string urlMss = "";
            CheckHospUseMovieTalkArgs args = new CheckHospUseMovieTalkArgs();
            CheckHospUseMovieTalkResult result =
                CloudService.Instance.Submit<CheckHospUseMovieTalkResult, CheckHospUseMovieTalkArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                movieTalk = result.CodeName;
            }
            if (movieTalk != "1")
            {
                XMessageBox.Show(Resources.MSG_MT0001, Resources.MSG001_CAP, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }           
            string urlMssMoiveTalk = ConfigurationSettings.AppSettings.Get("LinkMovieTalk") + GetToken() + "&patient_code=" + fbxBunho.GetDataValue() + "&session_id=" + WebSocketClient.SessionId + "&mode=2";
            GetDefaultBrowserPath(urlMssMoiveTalk);
        }
        //Get Token form url.
        private string GetToken()
        {
            string token = "";
            string url = ConfigurationSettings.AppSettings.Get("GetTokenMovieTalk") + UserInfo.HospCode;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = WebRequestMethods.Http.Get;
            req.Accept = "application/json";
            HttpWebResponse res = null;
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                using (StreamReader sr = new StreamReader(res.GetResponseStream()))
                {
                    string json = sr.ReadToEnd();
                    Newtonsoft.Json.Linq.JObject genJson = Newtonsoft.Json.Linq.JObject.Parse(json);
                    token = (string)genJson["data"]["descrypt_code"];
                }
            }
            catch
            {

            }
            return token;
        }
        //Get open webbrowser default.
        private static void GetDefaultBrowserPath(string url)
        {            
            string CHROME = "chrome.exe";
            string FIREFOX = "firefox.exe";
            string IEXPLORE = "iexplore.exe";
            bool isOpenChorme = false;
            bool isOpenFireFox = false;
            RegistryKey browserKey = null;
            try
            {               
                browserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
                if (browserKey == null)
                    browserKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
                string[] browserName = browserKey.GetSubKeyNames();
                foreach (string item in browserName)
                {
                    if (item.ToLower().StartsWith(("Google chrome").ToLower()))
                    {
                        isOpenChorme = true;
                        break;
                    }
                    else if (item.ToLower().StartsWith("firefox.exe"))
                    {
                        isOpenFireFox = true;
                    }
                }
                if (isOpenChorme)
                    Process.Start(CHROME, url);
                else if(isOpenFireFox)
                    Process.Start(FIREFOX, url);                
                else Process.Start(IEXPLORE, url);             
            }
            catch
            {

            }            
        }
        /// <summary>
        /// 병리검사 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAplOrder_Click(object sender, EventArgs e)
        {
            /*XButton button = sender as XButton;*/

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            /*this.mClickedOrderButton = button.Tag.ToString();*/

            this.OpenScreen_OCS0103U15(true);
        }

        /// <summary>
        /// 방사선 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnXrtOrder_Click(object sender, EventArgs e)
        {
            /*XButton button = sender as XButton;*/

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            /*this.mClickedOrderButton = button.Tag.ToString();*/

            this.OpenScreen_OCS0103U16(true);
        }

        /// <summary>
        /// 기타 오더
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEtcOrder_Click(object sender, EventArgs e)
        {
            /*XButton button = sender as XButton;*/

            if (this.IsPatientSelected() == false) return;

            //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

            /*this.mClickedOrderButton = button.Tag.ToString();*/

            this.OpenScreen_OCS0103U19(true);
        }

        /// <summary>
        /// リハビリ依頼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReha_Click(object sender, EventArgs e)
        {
            /*XButton button = sender as XButton;*/

            bool checkflg = false;
            int ChangedCnt = 0;

            if (this.IsPatientSelected() == false) return;

            // 修正されているROWがあるかチェック
            for (int i = 0; i < this.grdOutSang.RowCount; i++)
            {
                if (this.grdOutSang.GetRowState(i) != DataRowState.Unchanged)
                    ChangedCnt++;
            }

            // 修正されているROWがあればまず保存する
            if (ChangedCnt >= 0)
            {
                //tungtx
                // Save grdOutSang
                List<OcsoOCS1003P01GridOutSangInfo> grdList = LoadListFromGrdOutSang();
                OcsoOCS1003P01GrdOutSangSaveLayoutArgs args = new OcsoOCS1003P01GrdOutSangSaveLayoutArgs();
                args.GrdOutSangList = grdList;
                args.UserId = UserInfo.UserID;
                UpdateResult result =
                    CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01GrdOutSangSaveLayoutArgs>(args);

                //if (this.grdOutSang.SaveLayout() == false)
                //tungtx
                if (result == null || result.Result == false)
                {
                    this.mMsg = XMsg.GetMsg("M005") + " - " + Service.ErrFullMsg; // 저장에 실패하였습니다 + 에러메세지...

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkflg = false;
                }
            }

            // 現在傷病があるかチェックしあれば画面を開く、傷病がなければ傷病登録させる
            if (this.grdOutSang.RowCount >= 1)
                checkflg = true;
            else
                checkflg = false;

            if (checkflg)
            {
                //if (this.IsGrantOrderUser(OrderBox.TabInputGubun.SelectedTab.Tag.ToString()) == false) return;

                /*this.mClickedOrderButton = button.Tag.ToString();*/

                this.OpenScreen_OCS0103U11(true);
            }
            else
            {
                XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP);
                //MED-10016
                //this.btnListSB.PerformClick(FunctionType.Insert);
            }
        }

        #endregion

        #region [ 버튼 이벤트  ]

        #region [ 상병 확장버튼 ]

        #endregion

        private void btnPrescriptionPrint_Click(object sender, EventArgs e)
        {
            IHIS.Framework.XScreen parentScreen;
            parentScreen = XScreen.CurrentScreen;
            Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            PkOut = mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
            NaewonDate = mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            if (!this.IsPatientSelected()) return;
            _strHtmlTemplate = GetHtmlTemplate();
            GetPatientInfo();
            string curDir = Application.StartupPath.Replace("\\", @"/");
            if (NetInfo.Language != LangMode.Jr)
            {
                _currentUrl = Application.StartupPath + "/OCSO/Hospital_Prescription_VN.html";
            }
            else _currentUrl = Application.StartupPath + "/OCSO/Hospital_Prescription_JA.html";
            EOBrowser.SaveFileHtml(_currentUrl, _strHtmlTemplate);
            FormDrugPrescription drgsPrescription = new FormDrugPrescription(_currentUrl, NaewonDate, PkOut, parentScreen, _lstOcsoOCS1003P01GridOutSangInfo, _patientPrescriptionResult);
            drgsPrescription.ParentScreen = this;
            drgsPrescription.ShowDialog(this);
        }

        private string GetHtmlTemplate()
        {
            string strHtml = "";
            OCS2015U00GetHtmlContentArgs args = new OCS2015U00GetHtmlContentArgs();
            args.FormatType = FormatType;
            args.TplType = TplTypePrecription;
            OCS2015U00GetHtmlContentResult result = CloudService.Instance.Submit<OCS2015U00GetHtmlContentResult, OCS2015U00GetHtmlContentArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                strHtml = result.PrintContent;
            }
            return strHtml;
        }

        private void GetPatientInfo()
        {
            if (!String.IsNullOrEmpty(Bunho))
            {
                try
                {
                    OCS2015U00GetDataPrescriptionArgs args = new OCS2015U00GetDataPrescriptionArgs();
                    args.Bunho = Bunho;
                    args.Pkout = PkOut;
                    args.JubsuDate = NaewonDate;
                    _patientPrescriptionResult = CloudService.Instance.Submit<OCS2015U00GetDataPrescriptionResult, OCS2015U00GetDataPrescriptionArgs>(args);
                }
                catch
                {
                    XMessageBox.Show("Get patient info failed!");
                }
            }
        }   

        private void btnOpenOutSang_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;
            if (mSelectedPatientInfo != null && mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_OUTSANGU00(IO_Gubun, this.fbxBunho.GetDataValue(),
                    this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                // 환자상병조회
                this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

            }
        }

        private void btnIpwonReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser() == false) return;

            // 未承認オーダーがあれば入院時オーダー
            if (
                this.mOrderBiz.GetNotBeforeApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N",
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
            {
                XMessageBox.Show("現在の患者さんの未承認オーダーが存在します。確認ボタンを押しますと承認画面に変わります。", "確認", MessageBoxButtons.OK);
                this.btnApprove.PerformClick();
                return;
            }

            this.OpenScreen_INP1003U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , pendingPatient.PatientBox.DtpNaewonDate.GetDataValue()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            if (EnvironInfo.CurrSystemID != "INSO")
            {
                if (this.mOrderBiz.IsIpwonReserStatus(this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()) == true)
                {
                    this.pbxInpReserYN.Visible = true;

                    if (this.mOrderBiz.GetNaewonYN(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) !=
                        "E"
                        &&
                        XMessageBox.Show("入院予約されました。外来診療は終了しますか？", "確認", MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.btnList.PerformClick(FunctionType.Process);
                    }
                }
                else
                {
                    this.pbxInpReserYN.Visible = false;
                }
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            if (this.IsGrantOrderUser() == false) return;

            this.OpenScreen_OCS0503U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                //insert by jc
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            // pbxEtcJinryo is un-used in EMR
            /*if (this.mDoctorLogin)
            {
                int etcJinryoCnt = this.mOrderBiz.GetOutTaGwaJinryoCnt(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                                      , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                                      , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                if (etcJinryoCnt > 0)
                {
                    this.pbxEtcJinryo.Visible = true;

                    // 진료의뢰후 메세지 출력
                    //MessageBox.Show(XMsg.GetMsg("M011"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.pbxEtcJinryo.Visible = false;
                }
            }*/




        }

        private void btnConsultAnswer_Click(object sender, EventArgs e)
        {
            //if (!this.pbxConsultAnswer.Visible) return;
            if (this.IsPatientSelected() == false) return;

            if (this.IsGrantOrderUser() == false) return;

            this.OpenScreen_OCS0503U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

        }

        private void btnDiscuss_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cacheDataDiscuss))
            {
                CACHE_LAST_MSG_TIME = String.Format(CACHE_LAST_MSG_TIME, UserInfo.HospCode, UserInfo.UserID);
                CacheService.Instance.Set(CACHE_LAST_MSG_TIME, cacheDataDiscuss, TimeSpan.MaxValue);
            }
            this.pbxNotifyON.Visible = false;
            /*this.btnDiscuss.ImageIndex = 22;
            this.btnDiscuss.ImageList = this.ImageList;*/
            //Todo open OCS2016U00
            CommonItemCollection param = new CommonItemCollection();
            string bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            if (!string.IsNullOrEmpty(bunho))
            {
                param.Add("bunho", bunho);
            }

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS2016U00", ScreenOpenStyle.ResponseSizable, param);
        }

        private void btnOrderPrint_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            string lg = NetInfo.Language.ToString();
            if (lg.ToUpper() == LangVI.ToUpper())
            {
                PrintOrder();
            }
            else
            {
                this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                    , false);
            }
        }

        private void PrintOrder()
        {
            this.GetDataTables();
            DataSet ds = new DataSet();
            XtraRpPrintOrder rpt = new XtraRpPrintOrder();
            ds.Tables.Add(tbl_PatientInfo);

            if (tbl_DRG.Rows.Count == 0)
            {
                rpt.Drg.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_DRG);
            }

            if (tbl_INJ.Rows.Count == 0)
            {
                rpt.Inj.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_INJ);
            }
            if (tbl_CPL.Rows.Count == 0)
            {
                rpt.Cpl.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_CPL);
            }
            if (tbl_PHY.Rows.Count == 0)
            {
                rpt.Phy.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_PHY);
            }
            if (tbl_PFE.Rows.Count == 0)
            {
                rpt.Pfe.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_PFE);
            }
            if (tbl_PHI.Rows.Count == 0)
            {
                rpt.Phi.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_PHI);
            }
            if (tbl_XRT.Rows.Count == 0)
            {
                rpt.Xrt.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_XRT);
            }
            if (tbl_TST.Rows.Count == 0)
            {
                rpt.Tst.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_TST);
            }

            if (tbl_OPR.Rows.Count == 0)
            {
                rpt.Opr.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_OPR);
            }
            if (tbl_Other.Rows.Count == 0)
            {
                rpt.Other.Visible = false;
            }
            else
            {
                ds.Tables.Add(tbl_Other);
            }
            rpt.DataSource = ds;
            rpt.DataMember = "tblPatientInfo";
            //rpt.ShowPreviewDialog();
            rpt.Print();
        }

        private void GetDataTables()
        {
            tbl_PatientInfo = new DataTable("tblPatientInfo");
            tbl_DRG = new DataTable("tblDrg");
            tbl_INJ = new DataTable("tblInj");
            tbl_CPL = new DataTable("tblCpl");
            tbl_PHY = new DataTable("tblPhy");
            tbl_PFE = new DataTable("tblPfe");
            tbl_PHI = new DataTable("tblPhi");
            tbl_XRT = new DataTable("tblXrt");
            tbl_TST = new DataTable("tblTst");
            tbl_OPR = new DataTable("tblOpr");
            tbl_Other = new DataTable("tblOther");


            #region PatientInfo
            tbl_PatientInfo.Columns.Add("Hosp_name");
            tbl_PatientInfo.Columns.Add("Hosp_address");
            tbl_PatientInfo.Columns.Add("number");
            tbl_PatientInfo.Columns.Add("date");
            tbl_PatientInfo.Columns.Add("patient_code");
            tbl_PatientInfo.Columns.Add("patient_name");
            tbl_PatientInfo.Columns.Add("patient_symptom");
            tbl_PatientInfo.Columns.Add("patient_address");
            tbl_PatientInfo.Columns.Add("doctor_name");

            string hospAddress = "";
            string number = "";

            #region
            OCS2015U00GetDoctorPatientReportArgs args = new OCS2015U00GetDoctorPatientReportArgs();
            args.Doctor = UserInfo.DoctorID;
            args.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(); ;
            args.Pkout1001 = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
            OCS2015U00GetDoctorPatientReportResult result = CloudService.Instance
                .Submit<OCS2015U00GetDoctorPatientReportResult, OCS2015U00GetDoctorPatientReportArgs>(args);
            if (result != null)
            {
                List<OCS2015U00GetDoctorPatientReportInfo> ListItemItem = new List<OCS2015U00GetDoctorPatientReportInfo>();
                ListItemItem.Add(result.ListItem);
                if (ListItemItem.Count > 0)
                {
                    hospAddress = ListItemItem[0].AdressDoc; //Dia chi benh vien
                    number = "PT" + ListItemItem[0].Seqvalue + "-" + UserInfo.DoctorID; //So hoa don
                }
            }
            #endregion

            string patientBirth = "";
            string patientSymptom = "";
            string patientSex = "";
            List<TagInfo> lstTagB1 = this.ctlEmrDocker.Viewer.ucGrid1.GetListChildrenTagA("B1");
            foreach (TagInfo itemTagInfo in lstTagB1)
            {
                patientSymptom += itemTagInfo.Content;
            }
            if (this.mSelectedPatientInfo.GetPatientInfo["sex"].ToString().Equals("F"))
            {
                patientSex = "Nữ";
            }
            else
            {
                patientSex = "Nam";
            }


            string hospname = UserInfo.HospName.ToString();
            string date = EnvironInfo.GetSysDateTime().ToString("dd/MM/yyyy");
            string patientCode = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString().ToUpper();
            string patientName = this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString().ToUpper();
            string Birth = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
            if (!String.IsNullOrEmpty(Birth))
            {
                patientBirth = Birth.Substring(0, Birth.Length - 6);
            }
            string address1 = this.mSelectedPatientInfo.GetPatientInfo["address1"].ToString().ToUpper();
            string address2 = this.mSelectedPatientInfo.GetPatientInfo["address2"].ToString().ToUpper();
            string doctorName = this.mSelectedPatientInfo.GetPatientInfo["doctor_name"].ToString();

            tbl_PatientInfo.Rows.Add(hospname, hospAddress, number, date, patientCode, patientName + " " + patientBirth + ", " + patientSex.ToUpper(), patientSymptom, address1 + " " + address2, doctorName);

            #endregion
            int index = 1;
            //Thuoc
            #region DRG
            if (OrderBox.GrdOrder_Drug.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_DRG, OrderBox.GrdOrder_Drug.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_DRG, OrderBox.GrdOrder_Drug.LayoutTable, index++);
            }
            #endregion
            //Tiem
            #region INJ
            if (OrderBox.GrdOrder_Jusa.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_INJ, OrderBox.GrdOrder_Jusa.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_INJ, OrderBox.GrdOrder_Jusa.LayoutTable, index++);
            }
            #endregion
            //Xet nghiem dich the
            #region CPL
            if (OrderBox.GrdOrder_Cpl.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_CPL, OrderBox.GrdOrder_Cpl.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_CPL, OrderBox.GrdOrder_Cpl.LayoutTable, index++);
            }
            #endregion
            //Phuc hoi chuc nang
            #region PHY
            if (OrderBox.GrdOrder_Reha.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_PHY, OrderBox.GrdOrder_Reha.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_PHY, OrderBox.GrdOrder_Reha.LayoutTable, index++);
            }
            #endregion
            //Xet nghiem sinh ly
            #region PFE
            if (OrderBox.GrdOrder_Pfe.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_PFE, OrderBox.GrdOrder_Pfe.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_PFE, OrderBox.GrdOrder_Pfe.LayoutTable, index++);
            }
            #endregion
            //Xet nghiem benh ly
            #region PHI
            if (OrderBox.GrdOrder_Apl.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_PHI, OrderBox.GrdOrder_Apl.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_PHI, OrderBox.GrdOrder_Apl.LayoutTable, index++);
            }
            #endregion
            //Chup chieu
            #region XRT
            if (OrderBox.GrdOrder_Xrt.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_XRT, OrderBox.GrdOrder_Xrt.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_XRT, OrderBox.GrdOrder_Xrt.LayoutTable, index++);
            }
            #endregion
            //Tieu phieu
            #region TST
            if (OrderBox.GrdOrder_Chuchi.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_TST, OrderBox.GrdOrder_Chuchi.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_TST, OrderBox.GrdOrder_Chuchi.LayoutTable, index++);
            }
            #endregion
            //Phau thuat - gay me
            #region OPR
            if (OrderBox.GrdOrder_Susul.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_OPR, OrderBox.GrdOrder_Susul.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_OPR, OrderBox.GrdOrder_Susul.LayoutTable, index++);
            }
            #endregion

            #region Other
            if (OrderBox.GrdOrder_Etc.LayoutTable.Rows.Count == 0)
            {
                GetDataTableType(tbl_Other, OrderBox.GrdOrder_Etc.LayoutTable, index);
            }
            else
            {
                GetDataTableType(tbl_Other, OrderBox.GrdOrder_Etc.LayoutTable, index++);
            }
            #endregion
        }

        private void GetDataTableType(DataTable dtName, DataTable currentDataType, int Int)
        {
            dtName.Columns.Add("int");
            dtName.Columns.Add("order_code");
            dtName.Columns.Add("order_name");
            dtName.Columns.Add("order_unit");
            dtName.Columns.Add("quantity");

            if (currentDataType != null)
            {
                foreach (DataRow rowItem in currentDataType.Rows)
                {
                    string orderCode = rowItem["hangmog_code"].ToString();
                    string orderName = rowItem["hangmog_name"].ToString();
                    string orderUnit = rowItem["ord_danui_name"].ToString();
                    string orderQuantity = rowItem["suryang"].ToString();

                    //MED-13449
                    string quantity = GetQuantity(rowItem);

                    dtName.Rows.Add(Int, orderCode, orderName, orderUnit, quantity);
                }
            }
        }

        private string GetQuantity(DataRow dtRow)
        {
            string strQuantity = "";
            try
            {
                int dv = 0;
                int sujang = 0;
                int nalsu = 0;
                string dvTime = "";
                bool isNumDv = Int32.TryParse(dtRow["dv"].ToString(), out dv);
                bool isNumSujang = Int32.TryParse(dtRow["suryang"].ToString(), out sujang);
                bool isNumNalsu = Int32.TryParse(dtRow["nalsu"].ToString(), out nalsu);

                dvTime = dtRow["dv_time"].ToString();
                if (dvTime.Trim() == "#" || dvTime.Trim() == "/")
                {
                    dv = 1;
                }
                else if (!string.IsNullOrEmpty(dvTime) && dvTime.Trim().ToLower() == "q")
                {
                    dv = 24 / dv;
                }
                // https://sofiamedix.atlassian.net/browse/MED-14824
                else if (!string.IsNullOrEmpty(dvTime) && dvTime.Trim().ToLower() == "@")
                {
                    dv = 1;
                    nalsu = 1;
                }
                else
                {
                    dv = 1;
                }

                double quantity = nalsu * sujang * dv;
                strQuantity = quantity.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of method GetQuantity(): " + ex.StackTrace);
            }

            return strQuantity;
        }       

        private void btnOrderGuide_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003R02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                , false);
        }

        private void btnDCBANNAB_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            OpenScreen_OCS1003U01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                , this.mInputGubun);
        }

        // 오더정보조회 화면 오픈 
        private void btnQryOrderInfo_Click(object sender, EventArgs e)
        {
            //if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q05(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
        }

        private void btnEtcJinryo_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q02(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());


        }

        private void btnImageResult_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_ScanViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void btnVital_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR7001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void btnShowBrowser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false)
            {
                return;
            }
            OCS2015U00GetLinkMISArgs args = new OCS2015U00GetLinkMISArgs();
            OCS2015U00GetLinkMISResult result =
                CloudService.Instance.Submit<OCS2015U00GetLinkMISResult, OCS2015U00GetLinkMISArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                string linkMIS = ConfigurationManager.AppSettings["LinkMIS"];
                frmWebBrowser frm = new frmWebBrowser(linkMIS + "patient-survey.html?patient_code=" + this.fbxBunho.GetDataValue() + "&token=" + result.Token + "&language=" + (NetInfo.Language == LangMode.Jr ? "ja" : NetInfo.Language.ToString().ToLower()));
                frm.ShowDialog();
            }
        }

        #endregion
        private void btnDoctorView_Click(object sender, EventArgs e)
        {
            string urlMss = "";
            urlMss = ConfigurationSettings.AppSettings.Get("LinkMovieTalk") + GetToken() + "&patient_code=" + fbxBunho.GetDataValue() + "&session_id=" + WebSocketClient.SessionId + "&mode=1";                       
            GetDefaultBrowserPath(urlMss);       
        }
        #region [ 라디오 버튼 ]

        #region [ 오더구분 라디오 버튼 ]

        private void rbnOrder_CheckedChanged(object sender, EventArgs e)
        {
            OrderBox.SuspendLayout();
            XRadioButton control = sender as XRadioButton;

            if (control.Checked)
            {
                control.ImageIndex = 3;
                control.BackColor = this.mSelectedBackColor;
                control.ForeColor = this.mSelectedForeColor;

                mCurrentInputTab = control.Tag.ToString();

                if (!IsFirstLoad)
                {
                    this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab, false);
                    // Patient was selected
                    LoadOrderGrid(ConvertToGridModule(mCurrentInputTab), false);
                }
            }
            else
            {
                control.ImageIndex = 4;
                control.BackColor = this.mUnSelectedBackColor;
                control.ForeColor = this.mUnSelectedForeColor;
            }
            OrderBox.ResumeLayout();
        }

        #endregion

        #region [ 진료여부 라디오 버튼 ]

        #endregion

        #endregion

        #region [ 파인드 박스 ]

        private void fbxBunho_FindClick(object sender, CancelEventArgs e)
        {
            this.OpenScreen_OUT0101Q01();
        }

        #endregion

        #region [ 탭 페이지 ]

        #endregion

        #region [ 콤보박스 ]

        #endregion

        #region [ 버튼 리스트 ]

        /// <summary>
        /// LoadOutSang use connect cloud
        /// </summary>
        /// <param name="lstGridOutSangInfo"></param>
        /// <returns></returns>
        private int LoadOutSang(List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfo)
        {
            IList<object[]> lstObject = grdOutSang_convertListInfoToListObject(lstGridOutSangInfo);
            //MED--10157
            SetListOutSangInfos(lstGridOutSangInfo);

            grdOutSang.setDataForGrid(lstObject);

            this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

            return this.grdOutSang.RowCount;
        }


        /// <summary>
        /// MakeJinryoGwaCombo use connect cloud
        /// </summary>
        /// <param name="lstComboListItemInfo"></param>
        private void MakeJinryoGwaCombo(List<ComboListItemInfo> lstComboListItemInfo)
        {
            this.cboJinryoGwa.DataSource = null;
            this.cboJinryoGwa.ComboItems.Clear();

            foreach (ComboListItemInfo itemInfo in lstComboListItemInfo)
            {
                this.cboJinryoGwa.ComboItems.Add(itemInfo.Code, itemInfo.CodeName);
            }

            this.cboJinryoGwa.DataSource = this.cboJinryoGwa.ComboItems;
            this.cboJinryoGwa.ValueMember = "ValueItem";
            this.cboJinryoGwa.DisplayMember = "DisplayItem";
            if (this.cboJinryoGwa.ComboItems.Count > 0)
                this.cboJinryoGwa.SelectedIndex = 0;

        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            try
            {
                string bunho = mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                string naewonDate = mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                string gwa = "%";
                string fkout1001 = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                //string queryGubun = (this.mDoctorLogin == true ? "D" : "N");
                string queryGubun = "N";
                string inputGubun = mInputGubun;
                string bunho2 = this.paInfoBox.BunHo;
                string naewonDate2 = this.DtpNaewonDate.GetDataValue();

                switch (e.Func)
                {
                    case FunctionType.Query: // 조회
                        //reset kinki check
                        this.allWarning = "";

                        e.IsBaseCall = false;

                        // 변경된 데이터 체크후 저장
                        if (this.IsOrderDataModifed() == true)
                        {
                            this.btnList.PerformClick(FunctionType.Update);
                        }

                        // 조회시작
                        if (this.mSelectedPatientInfo == null ||
                            this.mSelectedPatientInfo.GetPatientInfo == null ||
                            this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != this.fbxBunho.GetDataValue())
                        {
                            return;
                        }

                        // 이전 오더 데이터 초기화
                        this.ClearOrderData();

                        // 대기환자 리스트 조회
                        this.LoadPatientList();

                        CheckRemindBackRuleTime();

                        OcsoOCS1003P01BtnListQueryResult btnListQueryResult = btnList_queryData(bunho, gwa, naewonDate,
                            fkout1001, queryGubun, inputGubun, bunho2, naewonDate2);
                        if (btnListQueryResult != null)
                        {
                            // physical patient lookup
                            this.LoadOutSang(btnListQueryResult.GridOutSangItem);

                            // Create combo box if department
                            if (this.cboOutSang.GetDataValue() != "")
                            {
                                MakeJinryoGwaCombo(btnListQueryResult.CboItem);
                            }

                            // Order inquiry
                            lstOutOrderInfo = btnListQueryResult.OutOrder;
                            if (lstOutOrderInfo.Count > 0)
                            {
                                _isCheckDataExist = true;
                            }
                            else _isCheckDataExist = false;
                            this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                , (this.mDoctorLogin == true ? "D" : "N")
                                , this.mInputGubun);

                            IList<object[]> listObject =
                                pendingPatient.PatientBox.grdReserOrderList_createData(btnListQueryResult.ReserOrder);
                            GrdReserOrderList.setDataForGrid(listObject);
                            CheckButtonAllergy();
                            CheckButtonAllergy2();
                            CheckButtonAllergy3(_isCheckFinishExame);
                        }

                        // TODO comment: use cloud
                        /*
                     *
                    // 환자상병조회
                    this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                    , "%");

                    //診療科のコンボボックス作成
                    if (this.cboOutSang.GetDataValue().ToString() != "")
                    {
                        this.MakeJinryoGwa();
                    }

                    // 오더조회
                   this.LoadOutOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                        , (this.mDoctorLogin == true ? "D" : "N")
                                        , this.mInputGubun);
                    
                   this.grdReserOrderList.QueryLayout(false);
                   */

                        //insert by jc [grdOrder_Drugに情報LOAD] START
                        //this.LoadDoOrder_Grid();
                        //insert by jc [grdOrder_Drugに情報LOAD] END
                        // 오더 조회후 화면 Display
                        if (OrderBox.TabInputGubun.SelectedTab != null)
                        {
                            this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(),
                                this.mCurrentInputTab);
                        }

                        LoadCacheEmrRecord(true, false);

                        SetPatientInfoLabel(null);

                        this.ctlEmrDocker.Editor.EditorLoadFunc(true);

                        LoadExpandedForm();                        
                        ctlEmrDocker.Viewer.ViewLoadFunc();
                        //this.ctlEmrDocker.Viewer.ReloadControls();

                        #region MED-10026
		                if (!_isPostLoad)
                        {
                            InitSearchData();
                        }
                        _isPostLoad = false; 
	                    #endregion

                        //https://sofiamedix.atlassian.net/browse/MED-16028
                        CheckNotificationSignalPiturebox();

                        break;                        

                    //case FunctionType.Insert : // 상병입력

                    //    e.IsBaseCall = false;

                    //    this.AcceptData();

                    //    if (this.SangInputCheck(ref this.mMsg) == false)
                    //    {
                    //        MessageBox.Show(this.mMsg, XMsg.GetMsg("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        return;
                    //    }

                    //    int newRow = -1;
                    //    // 상병 로우 생성 
                    //    newRow = this.grdOutSang.InsertRow(-1);

                    //    // 상병 로우의 초기화
                    //    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                    //    break;

                    case FunctionType.Update: // 저장

                        try
                        {
                            #region For save func

                            /*if (!OrderBox.DrugControl.IsUpdateCheck()) return;
                            if (!OrderBox.UCOCS2015U12Control.IsUpdateCheck()) return;*/

                            /*this.RecieveAndSetOrderInfo("OCS0103U10", this.grdOrder_Drug);
                            this.RecieveAndSetOrderInfo("OCS0103U12", this.grdOrder_Jusa);*/

                            //this.RecieveAndSetOrderInfo("OCS0103U10", this.OrderBox.DrugControl.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U11", this.OrderBox.UCOCS2015U11Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U12", this.OrderBox.UCOCS2015U12Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U13", this.OrderBox.UCOCS2015U13Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U14", this.OrderBox.UCOCS2015U14Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U15", this.OrderBox.UCOCS2015U15Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U16", this.OrderBox.UCOCS2015U16Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U17", this.OrderBox.UCOCS2015U17Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U18", this.OrderBox.UCOCS2015U18Control.GrdOrder);
                            //this.RecieveAndSetOrderInfo("OCS0103U19", this.OrderBox.UCOCS2015U19Control.GrdOrder);

                            #endregion

                            //Kinki check
                            /*this.OrderBox.DrugControl.ProcessCheckKinki();*/

                            string msgOut = "";
                            //for input excel
                            this.OrderBox.UCOCS2015U14Control.HandleBtnListButtonClick(e.Func);
                            this.OrderBox.DrugControl.HandleBtnListClick(e.Func);
                            this.OrderBox.UCOCS2015U11Control.HandleBtnListClick(e.Func);
                            this.OrderBox.UCOCS2015U12Control.HandleBtnListButtonClick(e.Func,out msgOut);
                            if (msgOut == "E1") 
                            {return;}
                            this.OrderBox.UCOCS2015U13Control.HandleBtnListClick(e.Func);
                            this.OrderBox.UCOCS2015U15Control.HandleBtnListButtonClick(e.Func);
                            this.OrderBox.UCOCS2015U16Control.HandleBtnListButtonClick(e.Func);
                            this.OrderBox.UCOCS2015U17Control.HandleBtnListButtonClick(e.Func);
                            this.OrderBox.UCOCS2015U18Control.HandleBtnListButtonClick(e.Func);
                            this.OrderBox.UCOCS2015U19Control.BtnListClick(e.Func);

                            this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(),
                                this.mCurrentInputTab);

                            e.IsBaseCall = false;

                            if (!this.IsPatientSelected()) return;

                            if (!this.AcceptData())
                            {
                                mIsUpdateSuccess = false;
                                return;
                            }

                            this.mInsteadInsertedOrderCnt = 0;
                            this.mInsteadUpdatedOrderCnt = 0;
                            this.mInsteadDeletedOrderCnt = 0;

                            // 저장시작
                            // 1. 각각의 레이아웃을 저장 레이아웃으로 merge 한다.
                            // 2. 저장전 체크 사항을 체크한다.
                            // 3. 저장시작
                            //    3-1. Delete 항목에 대하여 저장을 한다. ( 에러시 이후 진행 불가 )
                            //    3-2. Update 항목에 대하여 저장을 한다. 

                            if (this.MergeToSaveLayout() == false)
                            {
                                mIsUpdateSuccess = false;
                                return;
                            }

                            SaveEmrCompositeFirst();
                            // 登録しようとしている患者に対して自分が担当医であるのかを保存する直前にチェックする。
                            if (this.mDoctorLogin)
                            {
                                // MED-11018: Set action doctor of the patient,MED-14299
                                string actionDoctor = this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
                                if (
                                    !this.IsCanUpdateDoctor(actionDoctor,
                                        this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()))
                                {
                                    return;
                                }
                            }

                            /*if(_grdCheckKinki.Select("pkocskey==" + null).Length > 0)
                            {
                                
                            }*/

                            foreach (DataRow dr in this._grdCheckKinki.Rows)
                            {
                                if (TypeCheck.IsNull(dr["pkocskey"]) || _isSaved)
                                {
                                    //Kinki check
                                    if (!String.IsNullOrEmpty(this.allWarning))
                                    {
                                        XMessageBox.Show(allWarning, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        _isSaved = true;
                                    }

                                    break;
                                }
                            }

                            if (this.OrderValidationCheck() == false)
                            {
                                mIsUpdateSuccess = false;
                                return;
                            }

                            //20130322 MX Interface 未定

                            //this.mInterface.MakeIFDataLayout("O", this.layDeletedData.LayoutTable, true, false, true);

                            //this.mInterface.MakeIFDataLayout("O", this.laySaveLayout.LayoutTable, false, true, false);

                            //this.mInterface.MakeIFDataLayout("O", this.laySaveLayout.LayoutTable, false, false, false);

                            // 트랜잭션 시작
                            try
                            {
                                // Connect Cloud
                                /*if (this.grdOutSang.RowCount <= 0)
                            {
                                if (MessageBox.Show("現在登録されている傷病がありません。このまま保存しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                    return;
                            }*/

                                // 입력안된 뉴로우는 자동삭제 합니다.
                                this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);
                                // 삭제시에는 삭제테이블의 데이터를 건드려 줘야 함.
                                for (int i = 0; i < this.layDeletedData.RowCount; i++)
                                {
                                    // 承認したオーダーを代行者が削除できなくする。
                                    if (this.mInputGubun == "CK"
                                        && this.layDeletedData.GetItemString(i, "pkocskey") != "")
                                    {

                                        string PostApproveYN =
                                            TypeCheck.NVL(this.layDeletedData.GetItemString(i, "postapprove_yn"), "N")
                                                .ToString();

                                        PostApproveYN = PostApproveYN == "Y" ? "D0" : this.mInputGubun;

                                        if (
                                            !this.mOrderBiz.IsPossibleInsteadOrder(
                                                this.layDeletedData.GetItemString(i, "pkocskey"), PostApproveYN,
                                                this.IO_Gubun))
                                        {
                                            XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG001_CAP);
                                            return;
                                        }
                                    }

                                    this.layDeletedData.SetItemValue(i, "dummy", "mageshin");
                                }

                                //Check Inventory,MED-14641
                                if (laySaveLayout != null && laySaveLayout.LayoutTable != null)
                                    if (!Framework.Utilities.CheckInventory(laySaveLayout.LayoutTable,true)) return;

                                // Connect cloud Update data
                                //this.ctlEmrDocker.Editor

                                OCS1003P01SaveLayOutArgs saveLayoutArgs = new OCS1003P01SaveLayOutArgs();

                                List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = LoadListFromGrdOutSang();

                                /*//MED-10157
                                SetListOutSangInfos(lstOutSangInfo);*/

                                List<OCS1003P01LayDeletedDataListItemInfo> lstDeletedDataInfo =
                                    LoadListFromLayDeletedData();
                                List<OCS1003P01LaySaveLayoutListItemInfo> lstLaySaveLayoutInfo =
                                    LoadListFromLaySaveLayout();
                                string naewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                                string naewondate = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();

                                saveLayoutArgs.GrdOutSangList = lstOutSangInfo;
                                saveLayoutArgs.LayDeleteList = lstDeletedDataInfo;
                                saveLayoutArgs.LaySaveList = lstLaySaveLayoutInfo;
                                saveLayoutArgs.UserId = UserInfo.UserID;
                                saveLayoutArgs.NaewonKey = naewonKey;
                                saveLayoutArgs.NaewonDate = naewondate;
                                UpdateResult result =
                                    CloudService.Instance.Submit<UpdateResult, OCS1003P01SaveLayOutArgs>(saveLayoutArgs);
                                if (result.ExecutionStatus != ExecutionStatus.Success)
                                {
                                    this.mMsg = XMsg.GetMsg("M005");
                                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                    mIsUpdateSuccess = false;

                                    return;
                                }


                                //医師ではない人が保存ボタンを押下する場合、自動診療終了までする。
                                //this.mSubUserAutoEndFlag = "N";
                                //if (UserInfo.UserGubun != UserType.Doctor && this.mGroup_key != "1" && this.mGroup_key != "")
                                //{
                                //    mIsUpdateSuccess = true;
                                //    this.mSubUserAutoEndFlag = "Y";
                                //    this.btnList.PerformClick(FunctionType.Process);
                                //}

                                if (UserInfo.UserGubun != UserType.Doctor && this.mGroup_key == "1" &&
                                    this.mGroup_key != "")
                                {
                                    // 部門オーダ記録出力
                                    //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ORDER_LABEL_PRT_YN", this.IO_Gubun) != "N")
                                    if (UserOptions.OrderLabelPrtYn == "Y")
                                    {
                                        if (this.layDisplayLayout.RowCount > 0 && this.IsPatientSelected())
                                        {
                                            if (this.cbxIsiSijisyo.Checked == true)
                                            {
                                                //TODO
                                                //this.OpenScreen_OCS1003R00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                                //                              , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                //                              , true
                                                //                              , false);
                                            }
                                            else
                                            {
                                                if (
                                                    MessageBox.Show(Resources.MSG005_MSG, Resources.MSG001_CAP,
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                                                    DialogResult.Yes)
                                                {
                                                    this.OpenScreen_OCS1003R00(
                                                        this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                        ,
                                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString
                                                            ()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                        ,
                                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString
                                                            ()
                                                        ,
                                                        this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                                        ,
                                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                        , true
                                                        , false);
                                                }
                                            }
                                        }
                                    }
                                }

        #endregion

                            }
                            catch
                            {
                                //Service.RollbackTransaction();

                                mIsUpdateSuccess = false;

                                this.mInsteadInsertedOrderCnt = 0;
                                this.mInsteadUpdatedOrderCnt = 0;
                                this.mInsteadDeletedOrderCnt = 0;

                                return;
                            }

                            //Service.CommitTransaction();  // 커밋

                            mIsUpdateSuccess = true;

                            string MsgSysMSG = "";
                            string MsgTitle = "";

                            if (UserInfo.Gwa == "CK")
                            {
                                if (this.mInsteadInsertedOrderCnt > 0)
                                {
                                    MsgSysMSG += Resources.SYS_MSG_1 + this.mInsteadInsertedOrderCnt +
                                                 Resources.SYS_MSG_SUFFIX;
                                    MsgTitle += Resources.SYS_MSG_TITLE_1;
                                }
                                if (this.mInsteadUpdatedOrderCnt > 0)
                                {
                                    MsgSysMSG += Resources.SYS_MSG_2 + this.mInsteadUpdatedOrderCnt +
                                                 Resources.SYS_MSG_SUFFIX;
                                    MsgTitle += Resources.SYS_MSG_TITLE_2;
                                }
                                if (this.mInsteadDeletedOrderCnt > 0)
                                {
                                    MsgSysMSG += Resources.SYS_MSG_3 + this.mInsteadDeletedOrderCnt +
                                                 Resources.SYS_MSG_SUFFIX;
                                    MsgTitle += Resources.SYS_MSG_TITLE_3;
                                }

                                if (this.cbxMsgSysYN.Checked == true)
                                {
                                    if (MsgSysMSG != "")
                                    {
                                        // 承認医師へ
                                        // Approval to doctor
                                        string gwa_name = "";
                                        this.mOrderBiz.LoadColumnCodeName("gwa",
                                            this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                                            //EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"), ref gwa_name);
                                            _sysDate.ToString("yyyy/MM/dd"), ref gwa_name);

                                        this.mOrderBiz.SendMessageSystem(MsgTitle + Resources.MORDER_BIZ_TITLE_1
                                            ,
                                            Resources.MORDER_BIZ_TITLE_2 +
                                            this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                            ,
                                            Resources.MORDER_BIZ_TITLE_3 +
                                            this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString()
                                            , Resources.MORDER_BIZ_TITLE_4 + gwa_name
                                            , ""
                                            , ""
                                            , MsgSysMSG
                                            , UserInfo.UserID
                                            , "U"
                                            ,
                                            this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString()
                                                .Substring(
                                                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString()
                                                        .Length - 5)
                                            , ""
                                            );
                                    }
                                }
                            }

                            #region 방사선 조사록 출력

                            #endregion

                            #region 약 처방전 출력

                            #endregion

                            #region 검체검사 출력 리스트 작성

                            #endregion

                            #region リハビリ依頼書出力 BEAR-D

                            Hashtable printYn = new Hashtable();

                            foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
                            {
                                //inser by jc 希望日が追加された場合、再印刷されるように変更。（修正された分はPHY8002画面にて出力）
                                //if ((dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)&&
                                if ((dr.RowState == DataRowState.Added) &&
                                    (dr["jundal_part"].ToString() == "HOM" &&
                                     (dr["specific_comment"].ToString() == "18" ||
                                      dr["specific_comment"].ToString() == "19")))
                                {
                                    this.PrintRehaIraisyo(dr);
                                    printYn.Add(dr["pkocskey"].ToString(), "Y");

                                    //問診データI/F
                                    if (this.mDoctorLogin)
                                    {
                                        this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, IO_Gubun);
                                    }
                                    else if (UserInfo.Gwa == "CK" && this.mPostApproveYN)
                                    {
                                        this.mOrderBiz.procHQNInterface(mSelectedPatientInfo, IO_Gubun);
                                    }
                                }
                            }

                            #endregion

                            ctlEmrDocker.Editor.ucGrid1.IsConfirmSave = true;
                            //Fix bug https://sofiamedix.atlassian.net/browse/MED-10932 - MED-13438
                            //WHen Re-select paitent. this.ctlEmrDocker.Editor.ucGrid1.PatientModel=null.=> need init this.ctlEmrDocker.Editor.ucGrid1.PatientModel
                            if (this.ctlEmrDocker.Editor.ucGrid1.PatientModel == null)
                                this.ctlEmrDocker.Editor.ucGrid1.PatientModel = GetPatientModel();
                            //End bug https://sofiamedix.atlassian.net/browse/MED-10932 - MED-13438
                            List<CommentInfo> cmtLst = ctlEmrDocker.Editor.ucGrid1.UpdateComment(string.Empty, null, null);
                            ctlEmrDocker.Viewer.ucGrid1.UpdateComment(cmtLst);
                            //SaveEmrRecord(false);
                            CacheEmrRecord();
                            //TODO: append DO button to Viewer      
                            SaveEmrCompositeSecond();
                            this.ClearOrderData();
                            _isPostLoad = true;
                            this.btnList.PerformClick(FunctionType.Query);
                            if (this.mSelectedPatientInfo != null &&
                            this.mSelectedPatientInfo.GetPatientInfo != null &&
                            this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != this.fbxBunho.GetDataValue())
                            {
                                OcsoOCS1003P01BtnListQueryResult btnListQueryResult1 = btnList_queryData(bunho, gwa, naewonDate,
                                fkout1001, queryGubun, inputGubun, bunho2, naewonDate2);
                                if (btnListQueryResult1 != null) lstOutOrderInfo = btnListQueryResult1.OutOrder;

                                this.layQueryLayout.QueryLayout(true);

                                DoButtonBusiness.OrderData = this.layQueryLayout.LayoutTable.Copy();
                                if (this.ctlEmrDocker.Viewer.ucGrid1.PatientModel == null)
                                    this.ctlEmrDocker.Viewer.ucGrid1.PatientModel = GetPatientModel();
                            }
                            SaveEmrRecord(false);
                            LoadOrderGrid(GridModule.OCS0103U10, true);
                            ctlEmrDocker.Editor.ucGrid1.IsConfirmSave = false;
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw;
                        }

                    case FunctionType.Process: // 진료 종료

                        try
                        {
                            _isCheckFinishExame = true;
                            e.IsBaseCall = false;

                            // jubsu_gubun が　診察　AND doctor_yn =　N　であるときは終了できない。
                            if (!this.IsPatientSelected()) return;

                            if (this.mDoctorLogin == false && this.mGroup_key == "1")
                            {
                                MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F002"), MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                return;
                            }

                            mIsUpdateSuccess = false;

                            // 診療終了前に該当する患者に未承認オーダーが存在するかチェック
                            if (
                                this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N",
                                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
                            {
                                XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK);
                                this.btnApprove.PerformClick();
                                return;
                            }


                            this.btnList.PerformClick(FunctionType.Update);

                            if (!outOfHosp)
                            {
                                if (mIsUpdateSuccess)
                                {
                                    //傷病チェック
                                    if (this.grdOutSang.RowCount <= 0)
                                    {
                                        try
                                        {
                                            //if (MessageBox.Show("現在登録されている傷病がありません。傷病登録をしますか？\n登録する[はい(Y)]、登録しない[いいえ(N)]", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                            if (UserOptions.DiseaseNameUnregistered == "Y")
                                            {
                                                if (
                                                    MessageBox.Show(Resources.MSG006_MSG, Resources.MSG001_CAP,
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                                                    DialogResult.No)
                                                {
                                                    this.btnListSB.Focus();
                                                    this.btnListSB.PerformClick(FunctionType.Insert);
                                                    return;
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                    }

                                    //Save Emr Data
                                    SaveEmrRecord();

                                    //insert by jc [保存する際に医師指示書出力可否を表示] 2012/03/30
                                    //checkplz 医師指示指示書出力有無チェック追加

                                    #region [医師指示書出力]

                                    //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ORDER_LABEL_PRT_YN", this.IO_Gubun) != "N")
                                    if (UserOptions.OrderLabelPrtYn == "Y")
                                    {
                                        if (this.layDisplayLayout.RowCount > 0 && this.IsPatientSelected())
                                        {
                                            if (this.cbxIsiSijisyo.Checked == true)
                                            {
                                                this.OpenScreen_OCS1003R00(
                                                    this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                    , true
                                                    , false);
                                            }
                                            else
                                            {
                                                if (
                                                    MessageBox.Show(Resources.MSG005_MSG, Resources.MSG001_CAP,
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                                {
                                                    this.OpenScreen_OCS1003R00(
                                                        this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                                                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                                                        , true
                                                        , false);
                                                }
                                            }
                                        }
                                    }

                                    #endregion


                                    #region [検査予約票出力]

                                    Hashtable reserPrintYn = new Hashtable();
                                    foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
                                    {
                                        if ((dr["jundal_table"].ToString() == "CPL" ||
                                             dr["jundal_table"].ToString() == "PFE" ||
                                             dr["jundal_table"].ToString() == "XRT" || dr["jundal_table"].ToString() == "OP")
                                            && dr["hope_date"].ToString() != "")
                                        {
                                            if (!reserPrintYn.Contains(dr["hope_date"].ToString()))
                                                reserPrintYn.Add(dr["hope_date"].ToString(), dr["hangmog_code"].ToString());
                                        }
                                    }

                                    foreach (string reser_date in reserPrintYn.Keys)
                                    {
                                        CommonItemCollection openParams = new CommonItemCollection();

                                        openParams.Add("bunho", this.paInfoBox.BunHo);
                                        openParams.Add("auto_close", "Y");
                                        openParams.Add("reser_date", reser_date);

                                        XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98",
                                            ScreenOpenStyle.ResponseFixed,
                                            openParams);
                                    }

                                    #endregion

                                    if (this.SaveJubsuInfo(
                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(),
                                        JINRYO_END))
                                    {
                                        //pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                        //    pendingPatient.PatientBox.CboQryGwa.GetDataValue(),
                                        //    pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
                                        pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                           pendingPatient.PatientBox.CboGwa.GetDataValue(),
                                           pendingPatient.PatientBox.FbxDoctor.GetDataValue(),
                                           pendingPatient.PatientBox.PaBox.BunHo);
                                        // 진료 종료후 클리어.
                                        this.fbxBunho.SetEditValue("");
                                        this.fbxBunho.AcceptData();
                                    }
                                    //}                                    
                                }
                                // Refresh
                                this.FbxBunho.AcceptData();
                                _isPostLoad = true;
                                this.BtnList.PerformClick(FunctionType.Query);
                            }
                            //Fix bug MED 7904 
                            /*----------------------------------------*/
                            ResetStatusButton();
                            /*----------------------------------------*/
                            _isCheckFinishExame = false;
                            break;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                            throw;
                        }

                    case FunctionType.Reset: // 진료 보류

                        e.IsBaseCall = false;
                        _isCheckPandingPatient = true;
                        if (!this.IsPatientSelected()) return;

                        if (this.mDoctorLogin == false)
                        {
                            MessageBox.Show(XMsg.GetMsg("M006"), XMsg.GetField("F002"), MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }

                        mIsUpdateSuccess = false;

                        if (
                            this.mOrderBiz.GetNaewonYN(mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                                mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(),
                                mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) == "H")
                        {
                            this.btnList.PerformClick(FunctionType.Cancel);
                            pendingPatient.PatientBox.SettingVisiblebyUser();
                        }
                        else
                        {

                            this.btnList.PerformClick(FunctionType.Update);

                            if (mIsUpdateSuccess)
                            {
                                if (this.SaveJubsuInfo(
                                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(), JINRYO_BORYU))
                                {
                                    //pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                    //    pendingPatient.PatientBox.CboQryGwa.GetDataValue(),
                                    //    pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
                                    pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                           pendingPatient.PatientBox.CboGwa.GetDataValue(),
                                           pendingPatient.PatientBox.FbxDoctor.GetDataValue(),
                                           pendingPatient.PatientBox.PaBox.BunHo);
                                    // 진료 종료후 클리어.
                                    this.fbxBunho.SetEditValue("");
                                    this.fbxBunho.AcceptData();
                                }
                            }
                            //this.SettingVisiblebyUser(); //診療保留後患者番号をクリアするためボタンのリセットが要らない。
                        }

                        //MED-13425
                        ProcessKillEportViewer();
                        //=========================================
                        ResetStatusButton();                                         
                        //============================
                        break;

                    case FunctionType.Cancel: // 진료종료 취소 -- 이거는 out1001 에 naewon_yn 만 N으로 업데이트 하자
                        _isCheckFinishExame = true;
                        e.IsBaseCall = false;

                        if (this.IsPatientSelected() == false) return;
                        if (this.SaveJubsuInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(),
                                                    MI_JINRYO))
                        {
                            //pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                            //       pendingPatient.PatientBox.CboQryGwa.GetDataValue(),
                            //       pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
                            pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                           pendingPatient.PatientBox.CboGwa.GetDataValue(),
                                           pendingPatient.PatientBox.FbxDoctor.GetDataValue(),
                                           pendingPatient.PatientBox.PaBox.BunHo);
                            //MED-10776 - MED-13440
                            this.fbxBunho.SetEditValue("");
                            this.fbxBunho.AcceptData();
                            this.BtnList.PerformClick(FunctionType.Query);
                            _isCheckFinishExame = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                throw ex;
            }
        }

        private void ResetStatusButton()
        {
            resetSignalPicture();
            resetSignalAllergyPicture2();
            resetSignalAllergyPicture3(); 
        }
        //MED-10157
        private void SetListOutSangInfos(List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo)
        {
            if (_lstOcsoOCS1003P01GridOutSangInfo.Count > 0) _lstOcsoOCS1003P01GridOutSangInfo.Clear();
            _lstOcsoOCS1003P01GridOutSangInfo = lstOutSangInfo;
            ctlEmrDocker.Viewer.LstOcsoOCS1003P01GridOutSangInfo = lstOutSangInfo;
            ctlEmrDocker.Viewer.ucGrid1.LstOcsoOCS1003P01GridOutSangInfo = lstOutSangInfo;
            ctlEmrDocker.Editor.ucGrid1.LstOcsoOCS1003P01GridOutSangInfo = lstOutSangInfo;
        }

        private void LoadExpandedForm()
        {
            //New code
            List<TagInfo> lstTagInfos = this.ctlEmrDocker.Viewer.ucGrid1.GetListChildrenTagA("");
            List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = LoadListFromGrdOutSang();
            //groupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo);
            /*ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo, true, true, false);*/
            //MED-10835
            //ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo, true, true, !IsVI());
            //MED-14639
            ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(listSpecialNode, lstTagInfos, lstOutSangInfo, true, true, true);
            ResetLocationExpandForm();
        }

        private bool IsVI()
        {
            return NetInfo.Language.ToString().ToUpper() == "VI";           
        }

        private void ResetLocationExpandForm()
        {
            /*dockPanel2_Container.Controls.Add(ucEditor);
            /*ucEditor.Dock = DockStyle.Fill;#1#
            ucEditor.Dock = DockStyle.Bottom;
            ucEditor.Location = new Point(0, 212);
            ucEditor.Name = "ucEditor";
            ucEditor.Size = new Size(742, 270);*/

            ctlEmrDocker.Editor.Size = new Size(742, xPanel4.Size.Height - ctlEmrDocker.GroupExpandForm.Size.Height - _orderBox.Size.Height - 50);
        }

        private void CacheEmrRecord()
        {
            try
            {
                string naewon_key = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                string doctor = UserInfo.UserID;
                string naewonDate = this.mSelectedPatientInfo.Parameter.NaewonDate.Replace("/", "");
                string schemaKey = string.Format(CACHE_EMR_RECORD_SCHEMA_PATTERN, doctor, naewon_key, naewonDate);
                string dataKey = string.Format(CACHE_EMR_RECORD_DATA_PATTERN, doctor, naewon_key, naewonDate);
                ctlEmrDocker.Editor.ucGrid1.NaewonKey = naewon_key;
                //LoadOutOrder("", "", "", "");
                List<EmrRecordInfo> lstRecordInfos = new List<EmrRecordInfo>();

                EmrRecordInfo editorEmrRecordInfo = ctlEmrDocker.Editor.ucGrid1.GetEmrRecordFromGrid(false, doctor);

                if (editorEmrRecordInfo.TagInfos.Count == 0)
                {
                    _setDefaultTemplate = true;
                    ctlEmrDocker.Editor.IsSetTemDefault = true;
                    _isListTagInfoNull = true;
                }
                else
                {
                    _setDefaultTemplate = false;
                    ctlEmrDocker.Editor.IsSetTemDefault = false;
                    _isListTagInfoNull = false;
                }

                lstRecordInfos.Add(editorEmrRecordInfo);
                /*string mml = MmlParser.Instance.ToMmL(lstRecordInfos, GetPatientModel(), oldMmlContent);*/
                string mml = MmlParser.Instance.ToMmL(lstRecordInfos, GetPatientModel(), oldMmlContent, _lstOcsoOCS1003P01GridOutSangInfo);
                string schemaData = ctlEmrDocker.Editor.ucGrid1.GetDicCommentInfo(false);

                CacheService.Instance.Set(schemaKey, schemaData, TimeSpan.MaxValue);
                CacheService.Instance.Set(dataKey, mml, TimeSpan.MaxValue);
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.StackTrace);
            }
        }

        public PatientModelInfo GetPatientModel()
        {
            PatientModelInfo patient = new PatientModelInfo();
            patient.PatientId = mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            patient.PatientName = mSelectedPatientInfo.GetPatientInfo["suname"].ToString() + " " +
                                  mSelectedPatientInfo.GetPatientInfo["suname2"].ToString();
            patient.PatientBirthday = mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
            patient.PatientGender = mSelectedPatientInfo.GetPatientInfo["sex"].ToString();
            patient.PatientAddress = mSelectedPatientInfo.GetPatientInfo["address1"].ToString();
            patient.PatientZip = mSelectedPatientInfo.GetPatientInfo["zip_code1"].ToString() + " - " +
                                 mSelectedPatientInfo.GetPatientInfo["zip_code2"].ToString();
            patient.PatientTelephone = mSelectedPatientInfo.GetPatientInfo["tel"].ToString();
            patient.Gwa = mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
            patient.NaewonDate = mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            return patient;
        }

        private readonly string CACHE_NEW_IMAGES_LIST_PATTERN =
            "NEW_ADDED_IMAGES_FOR_HOSP_{0}_PATIENT_{1}_PKOUT1001_{2}";

        //private void AppendDoButton(DataTable dataTable, string naewonDate, string naewon_key)
        //{
        //    List<Image> doList = DoButtonBusiness.GenerateDoButtonListFromOrders(dataTable, naewonDate, naewon_key, this.ctlEmrDocker.Editor);
        //}

        private void ClearEmrCache(string doctor, string naewon_key, string naewonDate)
        {
            string schemaKey = string.Format(CACHE_EMR_RECORD_SCHEMA_PATTERN, doctor, naewon_key, naewonDate);
            string dataKey = string.Format(CACHE_EMR_RECORD_DATA_PATTERN, doctor, naewon_key, naewonDate);
            CacheService.Instance.Remove(schemaKey);
            CacheService.Instance.Remove(dataKey);
        }

        private void LoadCacheEmrRecord(bool isLoadUcEditor, bool isShowMessage)
        {
            try
            {
                string strMsgGrd = ctlEmrDocker.Editor.ucGrid1.StrMsgCheckTagCodeAndContent;
                if (!string.IsNullOrEmpty(strMsgGrd) && isShowMessage)
                {
                    XMessageBox.Show(strMsgGrd, "警告", MessageBoxIcon.Warning);
                    ctlEmrDocker.Editor.ucGrid1.StrMsgCheckTagCodeAndContent = string.Empty;
                    return;
                }
                //todo: fix this
                string naewon_key = NaewonKey;
                ctlEmrDocker.Editor.ucGrid1.NaewonKey = NaewonKey;
                string doctor = UserInfo.UserID;
                string naewonDate = this.mSelectedPatientInfo.Parameter.NaewonDate.Replace("/", "");
                string schemaKey = string.Format(CACHE_EMR_RECORD_SCHEMA_PATTERN, doctor, naewon_key, naewonDate);
                string dataKey = string.Format(CACHE_EMR_RECORD_DATA_PATTERN, doctor, naewon_key, naewonDate);
                string mml = CacheService.Instance.Get<string>(dataKey);
                string schema = CacheService.Instance.Get<string>(schemaKey);

                if (isLoadUcEditor && !ctlEmrDocker.Editor.IsEmrRecordFromGrid() && !ctlEmrDocker.Editor.IsExistOrderInfo())
                    ctlEmrDocker.Editor.ucGrid1.LoadGrid(mml, GetPatientModel(), naewon_key, schema, false, true, null, ScreenEnum.UcEditor);

                if (mml == null || this._setDefaultTemplate)
                {
                    _setDefaultTemplate = false;
                    ctlEmrDocker.Editor.IsSetTemDefault = true;
                }
                else
                {
                    ctlEmrDocker.Editor.IsSetTemDefault = false;
                }

                CacheService.Instance.Get<string>(dataKey);
                SetOutSangForKinki();
            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.StackTrace);
            }
        }

        private string NaewonKey
        {
            get { return this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(); }
        }

        private void SaveEmrRecord()
        {
            SaveEmrRecord(true);
        }

        private void SaveEmrRecord(bool terminate)
        {
            try
            {
                //MED-10925
                ctlEmrDocker.Editor.ucGrid1.SetCacheDateTimeFromServer();
                //List<CustomMarkSchema> schema = this.ctlEmrDocker.Viewer.Save(out emrXml, editorSchema, editorEmrXml);
                EmrRecordInfo lstSaveScEditor = ctlEmrDocker.Editor.ucGrid1.GetEmrRecordFromGrid(true, UserInfo.UserID, true);
                string strBookmark = string.Empty;

                /*if (lstSaveScEditor.TagInfos.Count > 0 || lstSaveScEditor.OrderInfos.Count > 0)
                {*/
                string emrMml = ctlEmrDocker.Viewer.ucGrid1.Save(lstSaveScEditor, false, ScreenEnum.UcView);

                if (lstSaveScEditor.TagInfos.Count > 0)
                    strBookmark =
                        ctlEmrDocker.Editor.ucGrid1.GetCommentJsonData(ctlEmrDocker.Viewer.ucGrid1.CommentDataDic, false);
                else
                    strBookmark = ctlEmrDocker.Viewer.ucGrid1.GetCommentJsonData(null, true);

                SaveEmrCompositeThirdResult result = SaveEmrCompositeThird(emrMml, strBookmark);

                /*OCS2015U09EmrRecordUpdateArgs arg = new OCS2015U09EmrRecordUpdateArgs();
                arg.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
                arg.Content = emrMml;

                arg.Metadata = strBookmark;
                arg.Metadata = strBookmark;
                arg.SysId = UserInfo.UserID;

                arg.RecordLog = "新規作成";

                UpdateResult result = CloudService.Instance.Submit<UpdateResult, OCS2015U09EmrRecordUpdateArgs>(arg);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (result.Result)
                    {
                    }
                }*/
                if (!terminate)
                {
                    OCS2015U06EmrRecordResult record = GetCurrentEmrRecord();
                    string recordId = record == null || record.ExecutionStatus != ExecutionStatus.Success
                                      || record.EmrRecordList == null || record.EmrRecordList.Count == 0
                        ? "0"
                        : record.EmrRecordList[0].RecordId;
                    //update DictionaryCommentInfo in two UcEditor and UcView after update grid
                    this.ctlEmrDocker.Viewer.ucGrid1.Reset();
                    //this.ctlEmrDocker.Viewer.LoadMeta(schema, emrXml, recordId);
                    ctlEmrDocker.Viewer.ucGrid1.LoadGrid(emrMml, GetPatientModel(), NaewonKey, strBookmark, true, false, null, ScreenEnum.UcView);
                    ctlEmrDocker.Editor.ucGrid1.LoadGrid(emrMml, GetPatientModel(), NaewonKey, strBookmark, false, true, null, ScreenEnum.UcEditor);
                    ctlEmrDocker.Viewer.Record_id = recordId;
                    this.ctlEmrDocker.Viewer.SetActiveEditEmrBtn();//Enable btnEdit on UcView (U44)
                    List<CommentInfo> listBookmark = new List<CommentInfo>();
                    //Before loading data, reset Viewer
                    //this.ctlEmrDocker.Viewer.Reset();

                    //foreach (OCS2015U06EmrRecordResult info in record.EmrRecordList[0].EmrRecordList)
                    //{
                    //    //update DictionaryCommentInfo in two UcEditor and UcView after update grid
                    //    UpdateDicToUcGrid(info.Metadata);

                    //    this.ctlEmrDocker.Viewer.ucGrid1.LoadGrid(info.Content, GetPatientModel(), NaewonKey);
                    //    this.ctlEmrDocker.Viewer.ucGrid1.LoadGridCombobox();
                    //    this.ctlEmrDocker.Viewer.Record_id = info.RecordId;
                    //    this.ctlOCS2015U07.TagLst = this.ctlEmrDocker.Viewer.ucGrid1.GetListChildrenTagA();

                    //    if (!string.IsNullOrEmpty(info.Metadata))
                    //        listBookmark = JsonConvert.DeserializeObject<List<CommentInfo>>(info.Metadata);
                    //}

                    if (record != null && record.EmrRecordList != null && record.EmrRecordList.Count > 0 &&
                        !string.IsNullOrEmpty(record.EmrRecordList[0].Metadata))
                        listBookmark = JsonConvert.DeserializeObject<List<CommentInfo>>(record.EmrRecordList[0].Metadata);
                    /*tvBookmarkList.DisplayBookmarkHistory(recordId, this.MSelectedPatientInfo.Parameter.Bunho,
                        listBookmark,
                        this.MSelectedPatientInfo.Parameter.Gwa, this.ctlEmrDocker, null);*/
                    ucOCS2016U0304.ocS2015U04C1.DisplayBookmarkHistory(recordId, this.MSelectedPatientInfo.Parameter.Bunho,
                        listBookmark,
                        this.MSelectedPatientInfo.Parameter.Gwa, this.ctlEmrDocker, null);
                    this.OCS2015U07Binddata();
                    if (_isListTagInfoNull)
                    {
                        _setDefaultTemplate = true;
                        _isListTagInfoNull = false;
                    }

                    if (lstSaveScEditor.TagInfos.Count > 0)
                        LoadCacheEmrRecord(true, true);
                    else
                        LoadCacheEmrRecord(false, true);
                }
                /*}*/

                if (terminate)
                {
                    ClearEmrCache(
                        UserInfo.UserID,
                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString(),
                        this.mSelectedPatientInfo.Parameter.NaewonDate.Replace("/", ""));
                    ResetOcsEmrData(true);
                    //https://sofiamedix.atlassian.net/browse/MED-15297
                    this.GetUserOptions();
                    if (UserOptions.ReserPrtYn == "Y")
                    {
                        if (this.IsPatientSelected())
                        {
                            this.OpenScreen_RES1001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                            this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(),
                            this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                            this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                        }
                    }
                }
                this.SetMsg(Resources.EMR_SAVE_RESULT, MsgType.Normal);
                OrderGridResetUpdate();
                ReLoadRegularOders();
                LoadExpandedForm();

                //MED-13425
                ProcessKillEportViewer();
            }
            catch (Exception ex)
            {
                Service.debugFileWrite(ex.Message + "\n" + ex.StackTrace);
            }
        }

        internal void ResetOcsEmrData(bool resetEditor)
        {
            //this.ctlEmrDocker.Viewer.ucGrid1.Reset();
            if (resetEditor) this.ctlEmrDocker.Editor.ucGrid1.Reset();
            this.ctlEmrDocker.Viewer.ResetEmrViewer();
            //tvBookmarkList.Reset();
            //tvExamHist.Reset();
            ucOCS2016U0304.ocS2015U04C1.Reset();
            ucOCS2016U0304.ocS2015U03C1.Reset();
            /*ctlOCS2015U05.Reset();
            ctlOCS2015U07.Reset();*/
            this.ctlEmrDocker.Editor.IsInitCtrl = true;
            grdPatientInfo.DataSource = null;
            this.SetActiveEmrEditor(false);
            this.ResetPatientprofile();
        }

        #region [ 그리드 이벤트 ]

        #region [ 상병 그리드 ]

        private void grdOutSang_Enter(object sender, EventArgs e)
        {
            // 포커스가 왔을때
            // 상병 입력이 가능한 상태이고
            // 현재 그리드에 로우가 하나도 없다면 
            // 자동으로 로우 한개 생성한다.
            if (this.SangInputCheck(ref this.mMsg) == true &&
                this.grdOutSang.RowCount == 0)
            {
                this.btnList.PerformClick(FunctionType.Insert);
            }


        }

        private void grdOutSang_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "display_sang_name": // 상병명 ( 화면 조회용 )

                    // 비코드화 상병명일때는 입력이 가능함.
                    if (this.mOrderBiz.IsDirectInputSangName(e.DataRow["sang_code"].ToString()) ||
                        e.DataRow["sang_code"].ToString().Trim() == "")
                        e.Protect = false;
                    else
                        e.Protect = true;

                    break;

                case "susik_button": // 수식어 버튼

                    // 비코드화 상병일때는 수식어가 필요없지...어차피 입력할테니...
                    if (this.mOrderBiz.IsDirectInputSangName(e.DataRow["sang_code"].ToString()))
                        e.Protect = true;
                    else
                        e.Protect = false;

                    break;

                case "sang_end_sayu": // 전귀사유

                    if (TypeCheck.IsNull(e.DataRow["sang_end_date"])) e.Protect = true;

                    break;

                case "doubt": // 의증 컬럼

                    e.Protect = true;

                    break;

                case "gwa":
                    if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%" &&
                        this.grdOutSang.GetRowState(e.RowNumber) == DataRowState.Unchanged)
                        e.Protect = true;
                    else
                        e.Protect = false;
                    break;
                case "susik":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        e.Protect = true;
                    }
                    break;
                case "user_sang":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        e.Protect = true;
                    }
                    break;

            }

            //this.mDoctorLogin == falseであれば傷病追加、修正、削除できない。
            //if (this.mDoctorLogin == false)
            //    e.Protect = true;
        }

        private void grdOutSang_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "sang_code":

                    if (this.fbxBunho.GetDataValue() == "")
                    {
                        return;
                    }

                    this.OpenScreen_CHT0110Q00("", true, grd.GetItemString(e.RowNumber, "sang_start_date"));

                    break;

                case "gwa":

                    if (this.fbxBunho.GetDataValue() == "")
                        return;
                    if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%" &&
                        this.grdOutSang.GetRowState(e.RowNumber) == DataRowState.Unchanged)
                        ((XFindBox)((XEditGridCell)grdOutSang.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            null;
                    else
                        ((XFindBox)((XEditGridCell)grdOutSang.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                            this.mOrderBiz.GetFindWorker("gwa", /*EnvironInfo.GetSysDate()*/
                                _sysDate.ToString("yyyy/MM/dd"));
                    break;
            }
        }

        private void grdOutSang_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            // 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
            // ReadOnly인 경우 
            if (!((XEditGridCell)grd.CellInfos[e.ColName]).IsUpdatable &&
                (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged ||
                 grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                (((XEditGridCell)grd.CellInfos[e.ColName]).IsReadOnly))
            {
                //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                e.BackColor = OrderVariables.DisplayFieldColor.Color;
                // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
            }
            else
            {
                // 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
                switch (e.ColName)
                {
                    case "display_sang_name": // Display 상병명
                        // 직접입력가능 상병코드인 경우는 상병명 직접입력가능(상병코드 : OCS.OrderVariables.WORD_SANG_CODE)
                        //if (!this.mOrderBiz.IsDirectInputSangName(grd.GetItemString(e.RowNumber, "sang_code")))
                        if (e.DataRow["sang_code"].ToString().Trim() != OCS.OrderVariables.WORD_SANG_CODE &&
                            e.DataRow["sang_code"].ToString().Trim() != "")
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;						
                        }

                        // 암 관련 상병명 암 표현법 (癌표시를 CA로 표시함)                             // 사용자 입력부서
                        grd[e.RowNumber, e.ColName].DisplayText = this.mOrderBiz.DisplayCancerSangName(this.mInputGwa,
                            grd[e.RowNumber, e.ColName].DisplayText);

                        break;

                    case "susik_button":
                    case "suspend_button": // 수식, ..
                        // 직접입력가능 상병코드인 경우는 수식등 선택못함 (상병코드 : OCS.OrderVariables.WORD_SANG_CODE)
                        if (this.mOrderBiz.IsDirectInputSangName(grd.GetItemString(e.RowNumber, "sang_code")))
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
                        }
                        break;

                    case "sang_end_sayu": // 상병종료사유
                        if (TypeCheck.IsNull(grd.GetItemValue(e.RowNumber, "sang_end_date")))
                        {
                            //e.DrawMode = IFC.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                            // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
                        }
                        break;

                    case "doubt": // image처리

                        if (e.DataRow["sang_code"].ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                        {
                            e.Image = this.ImageList.Images[28];
                            return;
                        }

                        if (CheckDoubt(grd, e.RowNumber))
                            e.Image = this.ImageList.Images[27];
                        else
                            e.Image = this.ImageList.Images[26];
                        break;
                    case "gwa":
                        if (this.grdOutSang.GetItemString(e.RowNumber, e.ColName) != "%")
                        {
                            e.BackColor = OrderVariables.DisplayFieldColor.Color;
                        }
                        break;
                }
            }
        }

        private void grdOutSang_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            object previousValue = grd.GetItemValue(e.RowNumber, e.ColName, DataBufferType.PreviousBuffer); // 이전 Value

            switch (e.ColName)
            {
                case "sang_code":

                    // sang_codeの修正は認めない。
                    if (previousValue.ToString() != e.ChangeValue.ToString() && previousValue.ToString() != "")
                    {
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        // 이전값과 이전 RowState를 유지시킨다
                        XMessageBox.Show(Resources.MSG007_MSG, Resources.MSG001_CAP);
                        return;
                    }

                    #region 상병코드

                    string pre_modifier_name = e.DataRow["pre_modifier_name"].ToString();
                    string post_modifier_name = e.DataRow["post_modifier_name"].ToString();

                    grd.SetItemValue(e.RowNumber, "sang_name", "");


                    if (e.ChangeValue.ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        //display상병명을 상병명으로 가져간다.
                        ClearSangName(grd, e.RowNumber);
                        grd.SetItemValue(e.RowNumber, "sang_name", e.DataRow["display_sang_name"]);
                        //grd.SetItemValue(e.RowNumber, "icd9_code", "");

                        break;
                    }

                    string display_sang_name = pre_modifier_name + post_modifier_name;

                    grd.SetItemValue(e.RowNumber, "display_sang_name", display_sang_name);

                    if (TypeCheck.IsNull(e.ChangeValue))
                    {
                        //grd.SetItemValue(e.RowNumber, "icd9_code", "");
                        break;
                    }
                    else
                    {
                        string sang_code = e.ChangeValue.ToString().TrimEnd();

                        DataRow dRow = this.mOrderBiz.LoadCht0110Info(sang_code);

                        if (dRow == null)
                        {
                            //							mbxMsg = NetInfo.Language == LangMode.Jr ? "傷病コードが正確ではないです. 確認してください." : "상병코드가 정확하지 않습니다. 확인바랍니다.";
                            //							mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                            //							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            // 이전값과 이전 RowState를 유지시킨다

                            //상병 미존재시 Find창을 띄운다.
                            this.OpenScreen_CHT0110Q00(sang_code, true,
                                grd.GetItemString(e.RowNumber, "sang_start_date"));

                            return;
                        }

                        pre_modifier_name = grd.GetItemString(e.RowNumber, "pre_modifier_name");
                        post_modifier_name = grd.GetItemString(e.RowNumber, "post_modifier_name");
                        string sang_name = dRow["sang_name"].ToString();
                        display_sang_name = this.mOrderBiz.GetDisplaySangName(pre_modifier_name, sang_name,
                            post_modifier_name);



                        // 상병별 항목별 제한사항 체크
                        if (!TypeCheck.IsNull(sang_code))
                        {
                            for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                            {
                                // break_gubun과 나이기준을 확인한다..
                                if (
                                    !this.mHangmogInfo.CheckHangSangInfo(
                                        this.layDrugOrder.GetItemString(i, "hangmog_code"),
                                        this.layDrugOrder.GetItemString(i, "hangmog_name"),
                                        sang_code, grd.GetItemString(e.RowNumber, "display_sang_name"),
                                        this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), IO_Gubun,
                                        (mSelectedPatientInfo.GetPatientInfo == null
                                            ? ""
                                            : mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()),
                                        (mSelectedPatientInfo.GetPatientInfo == null
                                            ? ""
                                            : mSelectedPatientInfo.GetPatientInfo["birth"].ToString())))
                                {
                                    this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                                    // 이전값과 이전 RowState를 유지시킨다
                                    return;
                                }
                            }
                        }

                        grd.SetItemValue(e.RowNumber, "sang_name", sang_name);
                        //grd.SetItemValue(e.RowNumber, "icd9_code", dRow["icd9_code"]);

                        //display 상병명
                        grd.SetItemValue(e.RowNumber, "display_sang_name", display_sang_name);

                        // kkb => 법정전염병 신고대상 환자입니다. 신고 하시겠습니까?

                        //MessageBox.Show("END Valid");

                    }

                    #endregion

                    break;

                case "sang_start_date":

                    #region 発症日

                    if (e.ChangeValue.ToString() != "" && grd.GetItemString(e.RowNumber, "sang_jindan_date") != "")
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                            int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG008_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }

                    #endregion

                    break;
                case "sang_jindan_date":

                    #region 診断日

                    if (e.ChangeValue.ToString() != "" && grd.GetItemString(e.RowNumber, "sang_start_date") != "")
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                            int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG009_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }

                    #endregion

                    break;
                case "sang_end_date":

                    #region 終了日

                    if (e.ChangeValue.ToString() == "")
                    {
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu", "");
                    }
                    else if (grd.GetItemString(e.RowNumber, "sang_jindan_date") == "" ||
                             grd.GetItemString(e.RowNumber, "sang_start_date") == "")
                    {
                        XMessageBox.Show(Resources.MSG010_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }
                    else
                    {
                        //発症日は診断日より同じ及び過去である。
                        if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                            int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", ""))
                            ||
                            int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")) >
                            int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", "")))
                        {
                            XMessageBox.Show(Resources.MSG011_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                            return;
                        }
                    }


                    #endregion

                    break;
                case "gwa":
                    //                    string cmd = @"SELECT FN_BAS_LOAD_GWA_NAME('" + e.ChangeValue.ToString() + "', '" + this.DtpNaewonDate.GetDataValue() + "') FROM SYS.DUAL";
                    //
                    //                    object obj = Service.ExecuteScalar(cmd);
                    //                    this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", obj.ToString());

                    // Connet to cloud service
                    OcsoOCS1003P01BasLoadGwaNameArgs args = new OcsoOCS1003P01BasLoadGwaNameArgs();
                    args.Gwa = e.ChangeValue.ToString();
                    args.BuseoYmd = this.DtpNaewonDate.GetDataValue();
                    OcsoOCS1003P01BasLoadGwaNameResult result =
                        CloudService.Instance
                            .Submit<OcsoOCS1003P01BasLoadGwaNameResult, OcsoOCS1003P01BasLoadGwaNameArgs>(args);
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", result.GwaName);
                    }

                    break;

                case "display_sang_name": // Display 상병명

                    ClearSangName(grdOutSang, e.RowNumber);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_code", OCS.OrderVariables.WORD_SANG_CODE);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_name", e.ChangeValue);
                    break;

                //if (this.grdOutSang.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                //{
                //    this.grdOutSang.SetItemValue(e.RowNumber, "sang_name", this.grdOutSang.GetItemString(e.RowNumber, "display_sang_name"));
                //}
                //break;
            }
        }

        private void grdOutSang_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            //switch (e.ColName)
            //{
            //    case "user_sang":

            //        this.OpenScreen_OCS0204Q00(UserInfo.UserID);

            //        break;

            //    case "susik":

            //        this.OpenScreen_CHT0115Q00(e.RowNumber);

            //        break;
            //}
        }

        private void grdOutSang_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            int rowNumber = grid.GetHitRowNumber(e.Y);

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (grid.CurrentColName == "doubt" && this.mDoctorLogin == true)
                {
                    if (grid.GetItemString(rowNumber, "sang_code") != OrderVariables.WORD_SANG_CODE)
                    {
                        if (CheckDoubt(grid, rowNumber))
                        {
                            SetDoubt(false, grid, rowNumber);
                        }
                        else
                        {
                            SetDoubt(true, grid, rowNumber);
                        }
                    }
                }
            }
        }

        #endregion

        #region [ 대기환자 그리드 ]

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNumber = -1;
            XEditGrid grd = sender as XEditGrid;

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                rowNumber = pendingPatient.PatientBox.GrdPatientList.GetHitRowNumber(e.Y);

                // 현재 선택된 로우의 환자번호 적용
                if (rowNumber >= 0)
                {
                    // 현재 파인드 박스의 환자번호와 선택된 번호가 
                    // 동일한경우는 스킵
                    try
                    {
                        this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                        //this.mParamNaewonKey = pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "pk_naewon");
                        this.mClickedNaewonKey = pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber,
                            "pk_naewon");
                        //insert by jc [選択された患者の保険を取得]
                        this.mClickedGubun = pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "gubun");

                        //同名二人CHECK2013/01/05
                        // TODO: No need to check for DEMO
                        /*if (IsSameNameCHK() == true)
                        {
                            if (MessageBox.Show("同じ名前の患者さんが受付されています。\n[漢字名: " + pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "suname") + "], \n[カナ名: "
                                                                                          + pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "suname2") + "], \n[年齢: "
                                                                                          + pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "age") + "]\nこの患者さんでよろしいでしょうか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                        }*/

                        //insert by jc [共通医を選択すると診療を進めるかを聞くメッセージを表示する。] 2012/03/12
                        if (
                            IsCommonDoctorJubsu(pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber,
                                "pk_naewon")) == true)
                        {
                            if (
                                MessageBox.Show("共通医受付患者です。診療を開始しますか？", "確認", MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning) == DialogResult.No)
                                return;
                            else
                            {
                                if (this.mDoctorLogin)
                                    this.ProcessCommonDoctor(
                                        pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber, "pk_naewon"));
                            }
                        }
                        this.mPatientDoubleClick = true;
                        this.fbxBunho.SetEditValue(pendingPatient.PatientBox.GrdPatientList.GetItemString(rowNumber,
                            "bunho"));
                        this.fbxBunho.AcceptData();



                    }
                    finally
                    {
                        this.Cursor = System.Windows.Forms.Cursors.Default;
                    }
                }
            }
        }

        private void grdPatientList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            // 예약환자인경우
            if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
            {
                e.BackColor = this.mReserPatientColor.Color;
            }

            // 検査予約(次回)
            if (grid.GetItemString(e.RowNumber, "kensa_yn") == "Y")
            {
                e.BackColor = this.mKensaReserPatientColor.Color;
            }

            // 진료의뢰환자의 경우 핑크
            if (grid.GetItemString(e.RowNumber, "consult_yn") == "Y")
            {
                e.BackColor = Color.LightPink;
            }

            // 공통의인경우 
            if (e.ColName == "suname")
            {
                if (grid.GetItemString(e.RowNumber, "common_doctor_yn") == "Y")
                {
                    e.BackColor = Color.Khaki;
                }
            }

            //if (grid.GetItemString(e.RowNumber, "jubsu_gubun") == "20" || grid.GetItemString(e.RowNumber, "jubsu_gubun") == "21" || grid.GetItemString(e.RowNumber, "jubsu_gubun") == "22")
            //{
            //   e.BackColor = Color.LightGreen;
            //}
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 각종 쿼리 및 데이터 로드.... ]

        private void MakeJinryoGwa()
        {
            //insert by jc [診療科のコンボボックス追加] START
            MultiLayout layJinryoGwa = new MultiLayout();

            layJinryoGwa.LayoutItems.Add("GWA", DataType.String);
            layJinryoGwa.LayoutItems.Add("GWA_NAME", DataType.String);
            layJinryoGwa.InitializeLayoutTable();

            layJinryoGwa.QuerySQL = @"SELECT A.GWA, A.GWA_NAME                                               
                                        FROM VW_BAS_GWA A                                                    
                                       WHERE A.OUT_JUBSU_YN = 'Y'                                            
                                         AND A.START_DATE = FN_BAS_LOAD_VW_BAS_GWA_YMD(A.GWA, TRUNC(SYSDATE) )
                                         AND A.HOSP_CODE  = '" + UserInfo.HospCode + @"'
                                       UNION
                                      SELECT '%' as GWA, '全体' as GWA_NAME 
                                        FROM SYS.DUAL
			                           ORDER BY GWA";

            layJinryoGwa.QueryLayout(false);

            this.MakeJinryoGwaCombo(layJinryoGwa);
            //insert by jc [診療科のコンボボックス追加] END
        }

        /// <summary>
        /// 상병로드
        /// </summary>
        /// <param name="aBunho">환자번호</param>
        /// <param name="aNaewonDate">내원일ㅈㅏ</param>
        /// <param name="aGwa">진료과</param>
        /// <returns>로우수</returns>
        internal int LoadOutSang(string aBunho, string aNaewonDate, string aGwa)
        {
            grdOutSang.ParamList = new List<string>(new string[] { "f_bunho", "f_naewon_date", "f_gwa" });

            this.grdOutSang.SetBindVarValue("f_bunho", aBunho);
            this.grdOutSang.SetBindVarValue("f_naewon_date", aNaewonDate);
            this.grdOutSang.SetBindVarValue("f_gwa", aGwa);

            this.grdOutSang.ExecuteQuery = grdOutSang_grdOutSang;
            this.grdOutSang.QueryLayout(true);

            this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

            return this.grdOutSang.RowCount;
        }

        internal void LoadOrderGrid(GridModule module, bool force)
        {
            if (force && loadedGridModules.Contains(module))
            {
                loadedGridModules.Remove(module);
            }
            if (!loadedGridModules.Contains(module))
            {
                switch (module)
                {
                    case GridModule.OCS0103U10:
                        OpenScreen_OCS0103U10(false);
                        break;
                    case GridModule.OCS0103U11:
                        OpenScreen_OCS0103U11(false);
                        break;
                    case GridModule.OCS0103U12:
                        OpenScreen_OCS0103U12(false);
                        break;
                    case GridModule.OCS0103U13:
                        OpenScreen_OCS0103U13(false);
                        break;
                    case GridModule.OCS0103U14:
                        OpenScreen_OCS0103U14(false);
                        break;
                    case GridModule.OCS0103U15:
                        OpenScreen_OCS0103U15(false);
                        break;
                    case GridModule.OCS0103U16:
                        OpenScreen_OCS0103U16(false);
                        break;
                    case GridModule.OCS0103U17:
                        OpenScreen_OCS0103U17(false);
                        break;
                    case GridModule.OCS0103U18:
                        OpenScreen_OCS0103U18(false);
                        break;
                    case GridModule.OCS0103U19:
                        OpenScreen_OCS0103U19(false);
                        break;
                }

                loadedGridModules.Add(module);
            }
        }

        internal GridModule ConvertToGridModule(string inputTab)
        {
            switch (inputTab)
            {
                case InputTab.DrugOrder:
                    return GridModule.OCS0103U10;
                case InputTab.RehabilitationOrder:
                    return GridModule.OCS0103U11;
                case InputTab.InjectionOrder:
                    return GridModule.OCS0103U12;
                case InputTab.LabTestOrder:
                    return GridModule.OCS0103U13;
                case InputTab.PhysiologicalTestOrder:
                    return GridModule.OCS0103U14;
                case InputTab.PathologicalInspectionOrder:
                    return GridModule.OCS0103U15;
                case InputTab.RadiationInspectionOrder:
                    return GridModule.OCS0103U16;
                case InputTab.MinorSurgeryOrder:
                    return GridModule.OCS0103U17;
                case InputTab.SurgeryOrder:
                    return GridModule.OCS0103U18;
                case InputTab.OtherOrder:
                    return GridModule.OCS0103U19;
                default:
                    return GridModule.OCS0103U19;
            }
        }

        // 画面がLOADされる時既存のデータを各GRIDに保存する
        private void LoadDoOrder_Grid()
        {
            /*
            //todo Performance (Save - AnhLT)
            //Old Code 
            OrderBox.GrdOrder_Drug.Reset();
            OrderBox.GrdOrder_Jusa.Reset();
            OrderBox.GrdOrder_Cpl.Reset();
            OrderBox.GrdOrder_Pfe.Reset();
            OrderBox.GrdOrder_Apl.Reset();
            OrderBox.GrdOrder_Xrt.Reset();
            OrderBox.GrdOrder_Chuchi.Reset();
            OrderBox.GrdOrder_Susul.Reset();
            OrderBox.GrdOrder_Etc.Reset();
            OrderBox.GrdOrder_Reha.Reset();*/

            if (OrderBox.GrdOrder_Drug.LayoutTable != null && OrderBox.GrdOrder_Drug.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Drug.Reset();
            if (OrderBox.GrdOrder_Jusa.LayoutTable != null && OrderBox.GrdOrder_Jusa.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Jusa.Reset();
            if (OrderBox.GrdOrder_Cpl.LayoutTable != null && OrderBox.GrdOrder_Cpl.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Cpl.Reset();
            if (OrderBox.GrdOrder_Pfe.LayoutTable != null && OrderBox.GrdOrder_Pfe.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Pfe.Reset();
            if (OrderBox.GrdOrder_Apl.LayoutTable != null && OrderBox.GrdOrder_Apl.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Apl.Reset();
            if (OrderBox.GrdOrder_Xrt.LayoutTable != null && OrderBox.GrdOrder_Xrt.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Xrt.Reset();
            if (OrderBox.GrdOrder_Chuchi.LayoutTable != null && OrderBox.GrdOrder_Chuchi.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Chuchi.Reset();
            if (OrderBox.GrdOrder_Susul.LayoutTable != null && OrderBox.GrdOrder_Susul.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Susul.Reset();
            if (OrderBox.GrdOrder_Etc.LayoutTable != null && OrderBox.GrdOrder_Etc.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Etc.Reset();
            if (OrderBox.GrdOrder_Reha.LayoutTable != null && OrderBox.GrdOrder_Reha.LayoutTable.Rows.Count > 0)
                OrderBox.GrdOrder_Reha.Reset();

            //OrderBox.DrugControl.GrdOrder.Reset();
            //OrderBox.UCOCS2015U11Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U12Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U13Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U14Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U15Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U16Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U17Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U18Control.GrdOrder.Reset();
            //OrderBox.UCOCS2015U19Control.GrdOrder.Reset();

            /*if (grdOrder_Drug != null) this.grdOrder_Drug.Reset();
            if (grdOrder_Jusa != null) this.grdOrder_Jusa.Reset();
            if (grdOrder_Cpl != null) this.grdOrder_Cpl.Reset();
            if (grdOrder_Pfe != null) this.grdOrder_Pfe.Reset();
            if (grdOrder_Apl != null) this.grdOrder_Apl.Reset();
            if (grdOrder_Xrt != null) this.grdOrder_Xrt.Reset();
            if (grdOrder_Chuchi != null) this.grdOrder_Chuchi.Reset();
            if (grdOrder_Susul != null) this.grdOrder_Susul.Reset();
            if (grdOrder_Etc != null) this.grdOrder_Etc.Reset();
            if (grdOrder_Reha != null) this.grdOrder_Reha.Reset();*/

            //for input Excell
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "")
            {
                SetDisiableAllControlOnU11();
                return;
            }

            #region 2015.12.22 AnhNV deleted

            //if (mCurrentInputTab == InputTab.DrugOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U10))
            //    {
            //        OpenScreen_OCS0103U10(false);
            //        loadedGridModules.Add(GridModule.OCS0103U10);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.RehabilitationOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U11))
            //    {
            //        OpenScreen_OCS0103U11(false);
            //        loadedGridModules.Add(GridModule.OCS0103U11);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.InjectionOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U12))
            //    {
            //        OpenScreen_OCS0103U12(false);
            //        loadedGridModules.Add(GridModule.OCS0103U12);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.LabTestOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U13))
            //    {
            //        OpenScreen_OCS0103U13(false);
            //        loadedGridModules.Add(GridModule.OCS0103U13);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.PhysiologicalTestOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U14))
            //    {
            //        OpenScreen_OCS0103U14(false);
            //        loadedGridModules.Add(GridModule.OCS0103U14);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.PathologicalInspectionOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U15))
            //    {
            //        OpenScreen_OCS0103U15(false);
            //        loadedGridModules.Add(GridModule.OCS0103U15);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.RadiationInspectionOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U16))
            //    {
            //        OpenScreen_OCS0103U16(false);
            //        loadedGridModules.Add(GridModule.OCS0103U16);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.MinorSurgeryOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U17))
            //    {
            //        OpenScreen_OCS0103U17(false);
            //        loadedGridModules.Add(GridModule.OCS0103U17);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.SurgeryOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U18))
            //    {
            //        OpenScreen_OCS0103U18(false);
            //        loadedGridModules.Add(GridModule.OCS0103U18);
            //    }
            //}

            //if (mCurrentInputTab == InputTab.OtherOrder)
            //{
            //    if (!loadedGridModules.Contains(GridModule.OCS0103U19))
            //    {
            //        OpenScreen_OCS0103U19(false);
            //        loadedGridModules.Add(GridModule.OCS0103U19);
            //    }
            //}

            ///*if (!drugInitialized)
            //{
            //    OpenScreen_OCS0103U10(false);
            //    drugInitialized = true;
            //}

            //if (!u15Initialized)
            //{
            //    OpenScreen_OCS0103U15(false);
            //    u15Initialized = true;
            //}*/

            //if (this.layDrugOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Drug.LayoutTable.ImportRow(dr);
            //        //OrderBox.DrugControl.GrdOrder.LayoutTable.ImportRow(dr);
            //        //grdOrder_Drug.LayoutTable.ImportRow(dr);
            //    }

            //    OrderBox.GrdOrder_Drug.DisplayData();
            //    //grdOrder_Drug.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Drug.Reset();
            //    //if (grdOrder_Drug != null) grdOrder_Drug.Reset();
            //}

            //if (this.layJusaOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Jusa.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Jusa.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Jusa.DisplayData();
            //    //grdOrder_Jusa.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Jusa.Reset();
            //    //grdOrder_Jusa.Reset();
            //}

            //if (this.layCplOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Cpl.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Cpl.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Cpl.DisplayData();
            //    //grdOrder_Cpl.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Cpl.Reset();
            //    //grdOrder_Cpl.Reset();
            //}

            //if (this.layPfeOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Pfe.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable.ImportRow(dr);
            //        //grdOrder_Pfe.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Pfe.DisplayData();
            //    //grdOrder_Pfe.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Pfe.Reset();
            //    //grdOrder_Pfe.Reset();
            //}

            //if (this.layAplOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Apl.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Apl.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Apl.DisplayData();
            //    //grdOrder_Apl.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Apl.Reset();
            //    //grdOrder_Apl.Reset();
            //}

            //if (this.layXrtOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Xrt.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Xrt.LayoutTable.ImportRow(dr);

            //    }
            //    OrderBox.GrdOrder_Xrt.DisplayData();
            //    //grdOrder_Xrt.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Xrt.Reset();
            //    //grdOrder_Xrt.Reset();
            //}

            //if (this.layChuchiOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Chuchi.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable.ImportRow(dr);
            //        //grdOrder_Chuchi.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Chuchi.DisplayData();
            //    //grdOrder_Chuchi.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Chuchi.Reset();
            //    //grdOrder_Chuchi.Reset();
            //}

            //if (this.laySusulOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Susul.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Susul.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Susul.DisplayData();
            //    //grdOrder_Susul.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Susul.Reset();
            //    //grdOrder_Susul.Reset();
            //}

            //// リハビリオーダ追加 2012/09/26
            //if (this.layRehaOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Reha.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Reha.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Reha.DisplayData();
            //    //grdOrder_Reha.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Reha.Reset();
            //    //grdOrder_Reha.Reset();
            //}

            //if (this.layEtcOrder.RowCount > 0)
            //{
            //    foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            //    {
            //        OrderBox.GrdOrder_Etc.LayoutTable.ImportRow(dr);
            //        //OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable.ImportRow(dr);

            //        //grdOrder_Etc.LayoutTable.ImportRow(dr);
            //    }
            //    OrderBox.GrdOrder_Etc.DisplayData();
            //    //grdOrder_Etc.DisplayData();
            //}
            //else
            //{
            //    OrderBox.GrdOrder_Etc.Reset();
            //    //grdOrder_Etc.Reset();
            //}

            #endregion

            #region 2015.12.22 AnhNV updated

            // to fix https://nextop-asia.atlassian.net/browse/MED-6286

            // U10
            if ((mCurrentInputTab == InputTab.DrugOrder || this.layDrugOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U10))
            {
                LoadOrderGrid(GridModule.OCS0103U10, true);
            }
            else
            {
                if (this.layDrugOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Drug.LayoutTable.ImportRow(dr);
                    }
                    if (OrderBox.DrugControl.ScreenActivated) OrderBox.GrdOrder_Drug.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Drug.RowCount > 0)
                        OrderBox.GrdOrder_Drug.Reset();
                }
            }

            // U11
            if ((mCurrentInputTab == InputTab.RehabilitationOrder || this.layRehaOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U11))
            {
                LoadOrderGrid(GridModule.OCS0103U11, true);
            }
            else
            {
                // リハビリオーダ追加 2012/09/26
                if (this.layRehaOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Reha.LayoutTable.ImportRow(dr);
                    }
                    if (OrderBox.UCOCS2015U11Control.ScreenActivated) OrderBox.GrdOrder_Reha.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Reha.RowCount > 0)
                        OrderBox.GrdOrder_Reha.Reset();
                }
            }

            // U12
            if ((mCurrentInputTab == InputTab.InjectionOrder || this.layJusaOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U12))
            {
                LoadOrderGrid(GridModule.OCS0103U12, true);
            }
            else
            {
                if (this.layJusaOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Jusa.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U12Control.ScreenActivated) OrderBox.GrdOrder_Jusa.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Jusa.RowCount > 0)
                        OrderBox.GrdOrder_Jusa.Reset();
                }
            }

            // U13
            if ((mCurrentInputTab == InputTab.LabTestOrder || this.layCplOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U13))
            {
                LoadOrderGrid(GridModule.OCS0103U13, true);
            }
            else
            {
                if (this.layCplOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Cpl.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U13Control.ScreenActivated) OrderBox.GrdOrder_Cpl.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Cpl.RowCount > 0)
                        OrderBox.GrdOrder_Cpl.Reset();

                }
            }

            // U14
            if ((mCurrentInputTab == InputTab.PhysiologicalTestOrder || this.layPfeOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U14))
            {
                LoadOrderGrid(GridModule.OCS0103U14, true);
            }
            else
            {
                if (this.layPfeOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Pfe.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U14Control.ScreenActivated) OrderBox.GrdOrder_Pfe.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Pfe.RowCount > 0)
                        OrderBox.GrdOrder_Pfe.Reset();
                }
            }

            // U15
            if ((mCurrentInputTab == InputTab.PathologicalInspectionOrder || this.layAplOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U15))
            {
                LoadOrderGrid(GridModule.OCS0103U15, true);
            }
            else
            {
                if (this.layAplOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Apl.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U15Control.ScreenActivated) OrderBox.GrdOrder_Apl.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Apl.RowCount > 0)
                        OrderBox.GrdOrder_Apl.Reset();
                }
            }

            // U16
            if ((mCurrentInputTab == InputTab.RadiationInspectionOrder || this.layXrtOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U16))
            {
                LoadOrderGrid(GridModule.OCS0103U16, true);
            }
            else
            {
                if (this.layXrtOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Xrt.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U16Control.ScreenActivated) OrderBox.GrdOrder_Xrt.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Xrt.RowCount > 0)
                        OrderBox.GrdOrder_Xrt.Reset();
                }
            }

            // U17
            if ((mCurrentInputTab == InputTab.MinorSurgeryOrder || this.layChuchiOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U17))
            {
                LoadOrderGrid(GridModule.OCS0103U17, true);
            }
            else
            {
                if (this.layChuchiOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Chuchi.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U17Control.ScreenActivated) OrderBox.GrdOrder_Chuchi.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Chuchi.RowCount > 0)
                        OrderBox.GrdOrder_Chuchi.Reset();
                }
            }

            // U18
            if ((mCurrentInputTab == InputTab.SurgeryOrder || this.laySusulOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U18))
            {
                LoadOrderGrid(GridModule.OCS0103U18, true);
            }
            else
            {
                if (this.laySusulOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Susul.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U18Control.ScreenActivated) OrderBox.GrdOrder_Susul.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Susul.RowCount > 0)
                        OrderBox.GrdOrder_Susul.Reset();
                }
            }

            // U19
            if ((mCurrentInputTab == InputTab.OtherOrder || this.layEtcOrder.RowCount > 0) &&
                !loadedGridModules.Contains(GridModule.OCS0103U19))
            {
                LoadOrderGrid(GridModule.OCS0103U19, true);
            }
            else
            {
                if (this.layEtcOrder.RowCount > 0)
                {
                    foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
                    {
                        OrderBox.GrdOrder_Etc.LayoutTable.ImportRow(dr);
                    }

                    if (OrderBox.UCOCS2015U19Control.ScreenActivated) OrderBox.GrdOrder_Etc.DisplayData();
                }
                else
                {
                    if (OrderBox.GrdOrder_Etc.RowCount > 0)
                        OrderBox.GrdOrder_Etc.Reset();
                }
            }

            #endregion
        }

        private bool LoadOutOrder(string aBunho, string aFkout1001, string aQueryGubun, string aInputGubun)
        {
            /*this.layQueryLayout.SetBindVarValue("f_bunho", aBunho);
            this.layQueryLayout.SetBindVarValue("f_fkout1001", aFkout1001);
            this.layQueryLayout.SetBindVarValue("f_query_gubun", aQueryGubun);
            this.layQueryLayout.SetBindVarValue("f_input_gubun", aInputGubun);*/

            this.layQueryLayout.ExecuteQuery = layQueryLayout_getData;
            this.layQueryLayout.QueryLayout(true);

            // 중간 레이아웃 초기화
            /*//todo Performance (Load Patient)
            //Old Code
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            // 2012/09/26
            this.layRehaOrder.Reset();
            this.laySusulOrder.Reset();
            this.layChuchiOrder.Reset();
            this.layEtcOrder.Reset();*/

            if (layDrugOrder.RowCount > 0) this.layDrugOrder.Reset();
            if (layJusaOrder.RowCount > 0) this.layJusaOrder.Reset();
            if (layCplOrder.RowCount > 0) this.layCplOrder.Reset();
            if (layPfeOrder.RowCount > 0) this.layPfeOrder.Reset();
            if (layAplOrder.RowCount > 0) this.layAplOrder.Reset();
            if (layXrtOrder.RowCount > 0) this.layXrtOrder.Reset();
            // 2012/09/26
            if (layRehaOrder.RowCount > 0) this.layRehaOrder.Reset();
            if (laySusulOrder.RowCount > 0) this.laySusulOrder.Reset();
            if (layChuchiOrder.RowCount > 0) this.layChuchiOrder.Reset();
            if (layEtcOrder.RowCount > 0) this.layEtcOrder.Reset();

            foreach (DataRow dr in this.layQueryLayout.LayoutTable.Rows)
            {
                this.SetInputGubunColor(dr["input_gubun"].ToString());
                switch (dr["input_tab"].ToString())
                {
                    case "01": // 내복약오더

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03": // 주사오더

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "04": // 검체검사 오더

                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "05": // 생리검사 오더

                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "06": // 병리검사 오더

                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "07": // 방사선 오더

                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "08": // 처치

                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "09": // 마취 수술

                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        break;

                    // リハビリオーダ追加 2012/09/26
                    case "10": // Reha

                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "11": // 기타 오더

                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            this.LoadDoOrder_Grid();

            //TODO: update DO grid on Editor
            DoButtonBusiness.OrderData = this.layQueryLayout.LayoutTable.Copy();

            return true;
        }

        #endregion

        #region 접수 저장 처리

        /// <summary>
        /// Save JubsuInfo
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        /// <param name="aNaewonYN"></param>
        /// <returns></returns>
        private bool SaveJubsuInfo(string aPkNaewonKey, string aNaewonYN)
        {
            /*string cmdText = " UPDATE OUT1001 A"
                           + "    SET A.NAEWON_YN = '" + aNaewonYN + "' "
                           + "  WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + "' "
                           + "    AND A.PKOUT1001 = " + aPkNaewonKey;

            if (Service.ExecuteNonQuery(cmdText) == false)*/

            // Connect cloud
            OcsoOCS1003P01UpdateJubsuArgs JubsuInfo = new OcsoOCS1003P01UpdateJubsuArgs();
            JubsuInfo.NaewonYn = aNaewonYN;
            JubsuInfo.PkNaewonKey = aPkNaewonKey;
            UpdateResult updateResult =
                CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01UpdateJubsuArgs>(JubsuInfo);
            if (updateResult == null)
            {
                return false;
            }

            return updateResult.Result;
        }

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [ 비지니스 로직들... ]

        private bool IsGrantOrderUser()
        {
            return IsGrantOrderUser("D0");
        }

        private bool IsGrantOrderUser(string aInputGubun)
        {
            string inputid = "";

            // 권한체크 
            if (this.mDoctorLogin)
            {
                inputid = UserInfo.DoctorID;
            }
            else
            {
                inputid = UserInfo.UserID;
            }

            //if (aInputGubun.Substring(0, 1) == "D")
            //{
            //    // 오더 권한 체크 
            //    if (this.mOrderBiz.IsGrantOcsInputDoctor(inputid, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue()) == false)
            //    {
            //        MessageBox.Show(XMsg.GetMsg("M002"), XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}

            return true;
        }

        /// <summary>
        /// 대기환자 그리드 필터링 셋팅
        /// </summary>        

        private bool IsOrderInputUserCheck(bool aIsCloseYN)
        {
            if (UserInfo.UserGubun == UserType.Doctor)
            {
                // 나중에 bas0270 에 ocs status 체크 하는것으로 변경 
                //if (TypeCheck.IsNull(OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["gwa"].ToString()))
                //{
                //    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                //    this.mCap = "使用権限確認";

                //    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    return false;
                //}

                this.mDoctorLogin = true;
                this.mInputGubun = TypeCheck.NVL(UserInfo.InputGubun, "D%").ToString();
                this.mInputGwa = UserInfo.Gwa;

                this.lblApprove.Visible = false;

            }
            else
            {
                if (TypeCheck.IsNull(UserInfo.InputGubun))
                {
                    this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                    this.mCap = "使用権限確認";

                    MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
                this.mDoctorLogin = false;
                this.mInputGubun = UserInfo.InputGubun;
                this.mInputGwa = UserInfo.Gwa;

                if (this.mInputGubun == "CK")
                {
                    this.lblApproveFlag.Visible = true;
                    this.lblApproveLabel.Visible = true;
                }
            }

            if (TypeCheck.IsNull(this.mInputGwa))
            {
                if (this.OpenParam != null && this.OpenParam.Contains("input_gwa"))
                {
                    this.mInputGwa = this.OpenParam["input_gwa"].ToString();
                }
                else
                {
                    //this.mInputGwa = mCommonForms.SelectGwa("1", /*EnvironInfo.GetSysDate()*/_sysDate.ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                if (TypeCheck.IsNull(this.mInputGwa))
                {
                    //this.mMsg = "該当画面に使用権限がない使用者です。ご確認下さい。";
                    //this.mCap = "使用権限確認";
                    //MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        internal void SetPatientInfoLabel(DataRow aPatientInfo)
        {
            string bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            if (string.IsNullOrEmpty(bunho)) return;
            //string UserName = this._rtm.UserName;
            //string data = this._rtm.Read(UserName);

            string patientSetingKey = this._emrCacheManager.PatientSetingKey + this._emrCacheManager.UserName;
            string data = this._emrCacheManager.Get(patientSetingKey);
            if (data != null)
            {
                this.UpDatePatientSetting(data);
            }
            // TODO MED-3368

            #region 2015.07.21 AnhNV updated

            //HungNV added
            this.GetPatientInfo(true);
            this.OCS2015U01BindData();

            //if (_patientResult != null && _patientResult.ManagePatInfo.Count > 0)
            //{
            //    // Get personal information of patient (name, sex, birthday, gender)
            //    this.lbSuname.Text = _patientResult.ManagePatInfo[0].PatientName1.ToString();
            //    this.lbSuname2.Text = _patientResult.ManagePatInfo[0].PatientName2.ToString();
            //    this.lbSexAge.Text = _patientResult.ManagePatInfo[0].Sex.ToString();
            //    this.lbBirthDay.Text = _patientResult.ManagePatInfo[0].Birth.ToString().Substring(0, 10).Trim().Replace("-", "/");

            //    // Get physical measurements of patient
            //    this.lbWeight.Text = _patientResult.PhyInfoItem[0].Weight.ToString() + " Kg";
            //    this.lbHeight.Text = _patientResult.PhyInfoItem[0].Height.ToString() + " cm";
            //    this.lbBloodpressureH.Text = _patientResult.PhyInfoItem[0].BpTo.ToString() + " / " + _patientResult.PhyInfoItem[0].BpFrom.ToString();
            //    this.lbBloodpressureL.Text = _patientResult.PhyInfoItem[0].BpFrom.ToString();
            //    this.lbCircuit.Text = _patientResult.PhyInfoItem[0].Pulse.ToString();
            //    this.lbTemperature.Text = _patientResult.PhyInfoItem[0].BodyHeat.ToString();
            //    this.lbSpo2.Text = _patientResult.PhyInfoItem[0].Spo2.ToString();
            //    this.lbBreathingRate.Text = _patientResult.PhyInfoItem[0].Breath.ToString();
            //}

            #endregion
        }

        private void ClearPatientInfoLabel()
        {
            // 환자정보 컨트롤 클리어
            for (int i = 0; i < this.mBunhoInfoControls.Count; i++)
            {
                if (((Control)mBunhoInfoControls[i]).Name == "fbxBunho") continue;

                if (((Control)mBunhoInfoControls[i]) is XLabel)
                {
                    ((XLabel)mBunhoInfoControls[i]).Text = "";
                }
                else if (((Control)mBunhoInfoControls[i]) is XTextBox)
                {
                    ((XTextBox)mBunhoInfoControls[i]).SetDataValue("");
                }
            }
        }

        /// <summary>
        /// 환자번호 입력시 각종체크들 ( 알레르기, 타과진료, 진료의뢰, 환자특기사항 )
        /// </summary>
        /// <param name="aNaewonDate">내원일자</param>
        /// <param name="aBunho">환자번호</param>
        /// <param name="aGwa">진료과</param>
        /// <param name="aDoctor">진료의</param>
        internal void CheckPatientEtcInfo(string aNaewonDate, string aBunho, string aGwa, string aDoctor)
        {

            //https://sofiamedix.atlassian.net/browse/MED-14994
            string count = "";
            CommonItemCollection prams_infection = new CommonItemCollection();
            prams_infection.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            count = this.mOrderBiz.LoadPatientInfection(aBunho, UserInfo.HospCode);
            if (UserOptions.Infection == "Y" && !String.IsNullOrEmpty(count) && count != "0")
            {
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR1017U00", ScreenOpenStyle.ResponseFixed, prams_infection);
            }
            //==========

            //https://sofiamedix.atlassian.net/browse/MED-15297
            if (UserOptions.DoOrderPopYn == "Y")
            {
                if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
                {
                    this.mOrderMode = OrderVariables.OrderMode.OutOrder;
                    this.OpenScreen_OCS1003Q09(false);
                }
            }

            bool isAllergyYn = false;
            // 알레르기 팝업
            //this.mOrderBiz.OpenAllergyInfo(this, aBunho, aNaewonDate, ref isAllergyYn);
            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "ALLERGY_POP_YN", this.IO_Gubun) != "N")
            if (UserOptions.AllergyPopYn == "Y")
            {
                this.mOrderBiz.OpenAllergyInfo(this, aBunho, aNaewonDate, ref isAllergyYn);
            }

            if (this.mDoctorLogin)
            {
                // Consult 의뢰가 있는 경우에 표시한다.
                //if (this.mOrderBiz.LoadConsultYN(aBunho, aNaewonDate, aGwa, aDoctor))
                // 確認していない依頼が存在すれば点滅させて知らせる 2012/11/22
                //if (this.mOrderBiz.IsNoConfirmConsult(aBunho, aNaewonDate, aGwa, aDoctor, IO_Gubun))
                //    this.pbxConsultAnswer.Visible = true;

                // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                //if (this.mOrderBiz.IsNoReturnConsult(aBunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(), aGwa, aDoctor, IO_Gubun))
                //    this.pbxIsNoReturnConsult.Visible = true;

                ////진료의뢰여부응답여부
                //string req_date = this.mOrderBiz.LoadConsultEndYN(aBunho, aDoctor);
                //if (req_date != "")
                //{
                //    if (!this.mIsCalledbyOtherScreen)
                //    {
                //        this.pbxConsultAnswer.Visible = true;
                //        // 진료의뢰 화면을 연다.
                //        //this.btnConsult.PerformClick();
                //    }
                //}
                string req_date = this.mOrderBiz.LoadConsultEndYN(aBunho, aDoctor);
                if (req_date != "")
                {
                    this.pbxIsNoConfirmOfReturnedConsult.Visible = true;
                    //Todo: check location
                    //this.pbxIsNoConfirmOfReturnedConsult.Location = new Point(btnConsult.Location.X + 4, btnConsult.Location.Y + 5);
                    //https://sofiamedix.atlassian.net/browse/MED-16195
                    this.pbxIsNoConfirmOfReturnedConsult.Location = new Point(tabGroupButton.Location.X + 71, tabGroupButton.Location.Y + 4);   
                    this.pbxIsNoConfirmOfReturnedConsult.BringToFront();
                }


                // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                // pbxIsNoAnwerOfConsulted is un-used in EMR
                /* if (this.mOrderBiz.IsNoConfirmConsult(aBunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString(), aGwa, aDoctor, IO_Gubun))
                    this.pbxIsNoAnwerOfConsulted.Visible = true;*/
                bool IsNoConfirmConsult = false;
                // Connect to cloud
                OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult loadResult =
                    LoadConsultEndYnAndIsNoConfirmConsult(aBunho, aDoctor, aGwa, IO_Gubun);
                if (loadResult != null && loadResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    req_date = loadResult.ReqDate;
                    IsNoConfirmConsult = loadResult.IsNoReturnConsultYn;
                }
                if (IsNoConfirmConsult)
                    this.pbxIsNoAnwerOfConsulted.Visible = true;

                // 입원예약여부-- 외래 오픈시에는 이걸뺀다
                //if (this.mOrderBiz.IsIpwonReserStatus(aDoctor, aBunho) == true)
                //{
                //    if (this.mDoctorLogin)
                //        this.pbxInpReserYN.Visible = true;
                //}
            }

            // 今日を除いて未実施状態の検査予約件があるのかチェック。
            //Đèn này ko dùng trên EMR
            //this.pbxIsKensaReser.Visible = this.mOrderBiz.IsKensaReser(aBunho, aNaewonDate);


            // 코맨트
            //string commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);
            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24

            string commemt = "";
            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
            //if(this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SPECIALWRITE_POP_YN"))
            //    commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            //if (commemt != "")
            //{
            //    this.mCap = "患者特記事項";

            //    MessageBox.Show(commemt, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    this.pbxExistBunhoComment.Visible = true;
            //}

            // insert by jc [使用者オプションによる表示・非表示] 2012/09/24

            commemt = this.mOrderBiz.LoadPatientSpecificComment(aBunho);

            //if (commemt != "" && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SPECIALWRITE_POP_YN", this.IO_Gubun) != "N")
            if (commemt != "" && UserOptions.SpecialwritePopYn == "Y")
            {
                CommonItemCollection prams = new CommonItemCollection();
                if (!string.IsNullOrEmpty(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()))
                {
                    prams.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed,
                        prams);
                }
                this.pbxExistBunhoComment.Visible = true;
            }
            else if (commemt != "")
            {
                this.pbxExistBunhoComment.Visible = true;
            }

            // pbxEtcJinryo is un-used in EMR
            /*if (this.mDoctorLogin)
            {
                int etcJinryoCnt = this.mOrderBiz.GetOutTaGwaJinryoCnt(aBunho, aNaewonDate, aGwa);

                if (etcJinryoCnt > 0)
                {
                    this.pbxEtcJinryo.Visible = true;
                }
                else
                {
                    this.pbxEtcJinryo.Visible = false;
                }
            }*/

            if (this.mDoctorLogin)
            {
                int etcJinryoCommentCnt = this.mOrderBiz.GetOutJinryoCommentCnt(aBunho, aNaewonDate, aGwa, aDoctor);

                if (etcJinryoCommentCnt > 0)
                {
                    this.pbxJinryoComment.Visible = true;
                }
                else
                {
                    this.pbxJinryoComment.Visible = false;
                }
            }

            // 오늘 측정한 바이탈 사인이 있는경우 자동 팝업
            if (this.mSelectedPatientInfo.GetPatientInfo["today_vital_yn"].ToString() == "Y")
                this.pbxVital.Visible = true;

            //アレルギー情報があるのか確認
            // pbxExistAllergy is un-used in EMR
            /*this.pbxExistAllergy.Visible = this.mOrderBiz.ExistAllergyData(aBunho);*/

            if (EnvironInfo.CurrSystemID != "INSO")
                this.pbxInpReserYN.Visible = this.mOrderBiz.IsIpwonReserStatus(aDoctor, aBunho); //入院時オーダ有無チェック

        }

        /// <summary>
        /// 변경된 데이터 체크
        /// </summary>
        /// <returns>true : 데이터가 있고 저장을 선택한 경우, false : 데이터가 없거나 저장을 선택하지 않은 경우</returns>
        internal bool IsOrderDataModifed()
        {
            bool isExistModifiedData = false;

            this.mOrderFunc.DeleteEmptyNewRow(this.grdOutSang);

            if (this.grdOutSang.GetChangedRowCount('A') > 0)
            //			    this.cbxWonyoi_Order_Yn_Wonmu.DataChanged  || this.fbxWonnae_Sayu_Code_Wonmu.DataChanged  ||
            //				this.emDrg_Nalsu.DataChanged               || this.cbxHubal_Change_Yn.DataChanged ||
            //				this.cboJinryo_Result.DataChanged          || this.cbxSoa_Nutjido_Yn.DataChanged ||
            //				this.cboAtc_Yn.DataChanged                 || this.cbxNext_jinryo_yn.DataChanged)
            {
                isExistModifiedData = true;
            }

            if (isExistModifiedData == false)
            {
                if (this.layDrugOrder.GetChangedRowCount('A') > 0 ||
                    this.layJusaOrder.GetChangedRowCount('A') > 0 ||
                    this.layCplOrder.GetChangedRowCount('A') > 0 ||
                    this.layPfeOrder.GetChangedRowCount('A') > 0 ||
                    this.layAplOrder.GetChangedRowCount('A') > 0 ||
                    this.layChuchiOrder.GetChangedRowCount('A') > 0 ||
                    this.laySusulOrder.GetChangedRowCount('A') > 0 ||
                    this.layXrtOrder.GetChangedRowCount('A') > 0 ||
                    //リハビリオーダ追加 2012/09/26
                    this.layRehaOrder.GetChangedRowCount('A') > 0 ||
                    this.layEtcOrder.GetChangedRowCount('A') > 0 ||
                    this.layDeletedData.RowCount > 0)
                {
                    isExistModifiedData = true;
                }
            }

            if (isExistModifiedData == true)
            {
                this.mMsg = "保存していないデータが存在します。変更された内容を保存しますか？";
                this.mCap = "保存可否";

                DialogResult result = MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    return true;
                }
            }

            return false;
        }

        private void MakePatientSangCombo(DataTable aDataSource)
        {
            string code = "";
            string name = "";

            this.cboOutSang.DataSource = null;
            this.cboOutSang.ComboItems.Clear();

            for (int i = 0; i < aDataSource.Rows.Count; i++)
            {
                code = aDataSource.Rows[i]["sang_code"] + "_" + i.ToString();
                if (aDataSource.Rows[i]["ju_sang_yn"].ToString() == "Y")
                {
                    name = "(主)  " + aDataSource.Rows[i]["display_sang_name"].ToString();
                    //name = "√  " + aDataSource.Rows[i]["display_sang_name"].ToString(); 
                }
                else
                {
                    name = "    " + aDataSource.Rows[i]["display_sang_name"].ToString();
                }

                this.cboOutSang.ComboItems.Add(code, name);
            }

            this.cboOutSang.DataSource = this.cboOutSang.ComboItems;
            this.cboOutSang.ValueMember = "ValueItem";
            this.cboOutSang.DisplayMember = "DisplayItem";
            if (this.cboOutSang.ComboItems.Count > 0)
                this.cboOutSang.SelectedIndex = this.cboOutSang.ComboItems.Count - 1;
        }

        //inser by jc 
        private void MakeJinryoGwaCombo(MultiLayout gwaData)
        {
            this.cboJinryoGwa.DataSource = null;
            this.cboJinryoGwa.ComboItems.Clear();

            foreach (DataRow dr in gwaData.LayoutTable.Rows)
            {
                this.cboJinryoGwa.ComboItems.Add(dr["GWA"].ToString(), dr["GWA_NAME"].ToString());

            }

            this.cboJinryoGwa.DataSource = this.cboJinryoGwa.ComboItems;
            this.cboJinryoGwa.ValueMember = "ValueItem";
            this.cboJinryoGwa.DisplayMember = "DisplayItem";
            if (this.cboJinryoGwa.ComboItems.Count > 0)
                this.cboJinryoGwa.SelectedIndex = 0;


        }

        //insert by jc
        /// <summary>[保存、診療保留、診療終了際の担当医確認]</summary>
        /// <param name ="aActionDoctor">行為をしているドクターの番号</param>
        /// <param name ="aBunho">診察中の患者番号</param>
        /// <param name ="aNaewon_key">受付番号</param>
        /// <param name ="return">保存可能：Y、保存不可能：N</param>
        private bool IsCanUpdateDoctor(string aActionDoctor, string aBunho, string aNaewon_key)
        {
            //            SingleLayout lyCheckCanUpdateDoctor = new SingleLayout();

            //            lyCheckCanUpdateDoctor.LayoutItems.Add("result");

            //            lyCheckCanUpdateDoctor.QuerySQL = @"SELECT 'X' 
            //                                                  FROM OUT1001 A 
            //                                                 WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                                   AND A.DOCTOR    = :f_actiondoctor 
            //                                                   AND A.BUNHO     = :f_bunho 
            //                                                   AND A.PKOUT1001 = :f_naewon_key";

            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_actiondoctor", aActionDoctor);
            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_bunho", aBunho);
            //            lyCheckCanUpdateDoctor.SetBindVarValue("f_naewon_key", aNaewon_key);

            //            //check
            //            if (lyCheckCanUpdateDoctor.QueryLayout() && lyCheckCanUpdateDoctor.GetItemValue("result").ToString() != "")
            //            {
            //                return true;
            //            }

            OcsoOCS1003P01CheckXArgs checkUpdateDoctorArg = new OcsoOCS1003P01CheckXArgs();
            checkUpdateDoctorArg.ActionDoctor = aActionDoctor;            
            checkUpdateDoctorArg.Bunho = aBunho;
            checkUpdateDoctorArg.NaewonKey = aNaewon_key;
            OcsoOCS1003P01CheckXResult result =
                CloudService.Instance.Submit<OcsoOCS1003P01CheckXResult, OcsoOCS1003P01CheckXArgs>(checkUpdateDoctorArg);
            if (result != null && result.XValue != "")
            {
                return true;
            }
            else
            {
                string mbxMsg = Resources.MSG017_MSG;
                string mbxCap = Resources.MSG017_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }


        #region 상병관련

        /// <summary>
        /// 상병입력가능여부
        /// </summary>
        /// <param name="aErrMsg">입력불가일경우의 사유</param>
        /// <returns>true, false</returns>
        private bool SangInputCheck(ref string aErrMsg)
        {
            // 상병 입력가능 여부 체크
            if (this.fbxBunho.GetDataValue() == "")
            {
                aErrMsg = XMsg.GetMsg("M001"); //진료대상환자를 선택해 주세요.
                return false;
            }

            return true;
        }


        /// <summary>
        /// 해당 Row에 의증이 등록되어 있는지 check한다.
        /// </summary>
        private bool CheckDoubt(XEditGrid grdObject, int currentRow)
        {
            bool returnValue = false;

            //접미어
            if (grdObject.GetItemString(currentRow, "post_modifier1").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier2").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier3").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier4").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier5").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier6").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier7").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier8").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier9").Trim() == "8002")
                returnValue = true;
            else if (grdObject.GetItemString(currentRow, "post_modifier10").Trim() == "8002")
                returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// 해당 Row에 의증을 set/Reset한다.
        /// </summary>		
        private void SetDoubt(bool addMode, XEditGrid grdObject, int currentRow)
        {
            string colName = "";
            if (addMode)
            {
                for (int i = 1; i <= 10; i++)
                {
                    colName = "post_modifier" + i.ToString();
                    if (grdObject.GetItemString(currentRow, colName).Trim() == "")
                    {
                        grdObject.SetItemValue(currentRow, colName, "8002");
                        grdObject.SetItemValue(currentRow, "post_modifier_name",
                            grdObject.GetItemString(currentRow, "post_modifier_name") + "の疑い");
                        grdObject.SetItemValue(currentRow, "display_sang_name",
                            grdObject.GetItemString(currentRow, "display_sang_name") + "の疑い");
                        break;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 10; i++)
                {
                    colName = "post_modifier" + i.ToString();
                    if (grdObject.GetItemString(currentRow, colName).Trim() == "8002")
                    {
                        grdObject.SetItemValue(currentRow, colName, "");
                        grdObject.SetItemValue(currentRow, "post_modifier_name",
                            grdObject.GetItemString(currentRow, "post_modifier_name").Replace("の疑い", ""));
                        grdObject.SetItemValue(currentRow, "display_sang_name",
                            grdObject.GetItemString(currentRow, "display_sang_name").Replace("の疑い", ""));
                        break;
                    }
                }
            }

            grdObject.Refresh();
        }

        /// <summary>
        /// 해당 Row의 수식어를 Clear한다.
        /// </summary>
        private void ClearSangName(XEditGrid grdObject, int currentRow)
        {
            string colName = "";

            for (int i = 1; i <= 10; i++)
            {
                colName = "pre_modifier" + i.ToString();
                if (grdObject.GetItemString(currentRow, colName).Trim() != "")
                    grdObject.SetItemValue(currentRow, colName, "");

                colName = "post_modifier" + i.ToString();
                if (grdObject.GetItemString(currentRow, colName).Trim() != "")
                    grdObject.SetItemValue(currentRow, colName, "");
            }

            grdObject.SetItemValue(currentRow, "pre_modifier_name", "");
            grdObject.SetItemValue(currentRow, "post_modifier_name", "");
        }

        private void ApplySangInfo(XEditGrid aGrid, MultiLayout aLayout, bool aIsUserSang)
        {
            int rowNumber = -1;
            string display_sang_name = "";

            if (!aIsUserSang)
            {
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    if (aGrid.RowCount <= 0)
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    rowNumber = aGrid.CurrentRowNumber;

                    aGrid.SetFocusToItem(rowNumber, "sang_code", true);
                    aGrid.SetEditorValue(dr["sang_code"].ToString());
                    if (aGrid.AcceptData() == false)
                    {
                        return;
                    }
                }
            }
            else
            {
                foreach (DataRow dr in aLayout.LayoutTable.Rows)
                {
                    if (aGrid.RowCount <= 0)
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnListSB.PerformClick(FunctionType.Insert);
                    }

                    rowNumber = aGrid.CurrentRowNumber;

                    foreach (XEditGridCell cell in grdOutSang.CellInfos)
                    {
                        if (aLayout.LayoutItems.Contains(cell.CellName))
                            aGrid.SetItemValue(rowNumber, cell.CellName, dr[cell.CellName]);
                    }

                    //display 상병명
                    display_sang_name =
                        this.mOrderBiz.GetDisplaySangName(aGrid.GetItemString(rowNumber, "pre_modifier_name"),
                            aGrid.GetItemString(rowNumber, "sang_name"),
                            aGrid.GetItemString(rowNumber, "post_modifier_name"));
                    aGrid.SetItemValue(rowNumber, "display_sang_name", display_sang_name);

                    aGrid.Refresh();
                }

                aGrid.AcceptData();
            }
        }

        #endregion

        #region [ 오더 관련 ]

        private Dictionary<string, string> xGridOrderDic = new Dictionary<string, string>();

        private void GridOrderDicAdd(string value)
        {
            if (!xGridOrderDic.ContainsKey(value))
                xGridOrderDic.Add(value, value);
        }

        private void RecieveAndSetOrderInfo(string aCommand, XEditGrid aGrid)
        {
            switch (aCommand)
            {
                case "OCS0103U10": // 약오더인경우 
                    if (this.layDrugOrder.RowCount > 0)
                        this.layDrugOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;
                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");
                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layDrugOrder.SetItemValue(this.layDrugOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U10");
                        }
                    }

                    break;
                case "OCS0103U11": // リハビリオーダ追加 2012/09/26

                    if (this.layRehaOrder.RowCount > 0)
                        this.layRehaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layRehaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layRehaOrder.SetItemValue(this.layRehaOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U11");
                        }
                    }

                    break;
                case "OCS0103U12": // 주사오더 

                    if (this.layJusaOrder.RowCount > 0)
                        this.layJusaOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layJusaOrder.SetItemValue(this.layJusaOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U12");
                        }
                    }

                    break;

                case "OCS0103U13": // 검체검사오더인경우 

                    if (this.layCplOrder.RowCount > 0)
                        this.layCplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layCplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layCplOrder.SetItemValue(this.layCplOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U13");
                        }
                    }

                    break;

                case "OCS0103U14": // 생리검사오더 

                    if (this.layPfeOrder.RowCount > 0)
                        this.layPfeOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layPfeOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layPfeOrder.SetItemValue(this.layPfeOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U14");
                        }
                    }

                    break;

                case "OCS0103U15": // 병리검사오더 

                    if (this.layAplOrder.RowCount > 0)
                        this.layAplOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layAplOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layAplOrder.SetItemValue(this.layAplOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U15");
                        }
                    }

                    break;

                case "OCS0103U16": // 방사선오더 

                    if (this.layXrtOrder.RowCount > 0)
                        this.layXrtOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");


                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layXrtOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layXrtOrder.SetItemValue(this.layXrtOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U16");
                        }
                    }

                    break;

                case "OCS0103U17": // 처치 

                    if (this.layChuchiOrder.RowCount > 0)
                        this.layChuchiOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layChuchiOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layChuchiOrder.SetItemValue(this.layChuchiOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U10");
                        }
                    }

                    break;

                case "OCS0103U18": // 수술 

                    if (this.laySusulOrder.RowCount > 0)
                        this.laySusulOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.laySusulOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.laySusulOrder.SetItemValue(this.laySusulOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U18");
                        }
                    }

                    break;

                case "OCS0103U19": // 기타

                    if (this.layEtcOrder.RowCount > 0)
                        this.layEtcOrder.Reset();

                    // 삭제 데이터 셋팅
                    if (aGrid.DeletedRowCount > 0 && aGrid.DeletedRowTable != null)
                    {
                        // 삭제된 로우를 셋팅한다.
                        for (int i = 0; i < aGrid.DeletedRowTable.Rows.Count; i++)
                        {
                            if (TypeCheck.IsNull(aGrid.DeletedRowTable.Rows[i]["pkocskey"]) ||
                                layDeletedData.LayoutTable.Select("pkocskey=" +
                                                                  aGrid.DeletedRowTable.Rows[i]["pkocskey"].ToString())
                                    .Length > 0) continue;

                            this.layDeletedData.LayoutTable.ImportRow(aGrid.DeletedRowTable.Rows[i]);
                            //this.layDeletedData.SetItemValue(i, "dummy", "Y");
                        }
                    }

                    aGrid.Sort("group_ser, hope_date");

                    // 현재 유효한 데이터를 셋팅한다.
                    foreach (DataRow dr in aGrid.LayoutTable.Rows)
                    {
                        this.layEtcOrder.LayoutTable.ImportRow(dr);

                        if (dr.RowState == DataRowState.Added)
                        {
                            // 접수정보 
                            this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "naewon_type",
                                this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                            this.layEtcOrder.SetItemValue(this.layEtcOrder.RowCount - 1, "jubsu_no",
                                this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString());
                            GridOrderDicAdd("OCS0103U19");
                        }
                    }

                    break;

            }
        }

        #region for input Excel

        private void SetDisiableAllControlOnU11()
        {
            //set disiable all uc here
            OrderBox.DrugControl.Visible = false;
            OrderBox.UCOCS2015U12Control.Visible = false;
            OrderBox.UCOCS2015U13Control.Visible = false;
            OrderBox.UCOCS2015U14Control.Visible = false;
            OrderBox.UCOCS2015U15Control.Visible = false;
            OrderBox.UCOCS2015U16Control.Visible = false;
            OrderBox.UCOCS2015U17Control.Visible = false;
            OrderBox.UCOCS2015U18Control.Visible = false;
            OrderBox.UCOCS2015U19Control.Visible = false;

            OrderBox.UCOCS2015U11Control.Visible = false;

            OrderBox.PnlReserOrderList.Visible = true;
        }

        private void EnableControlWhenSelectInputTab(string aInputTab)
        {
            //for input excel
            switch (aInputTab)
            {
                // 01
                case InputTab.DrugOrder:
                    OrderBox.DrugControl.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 10
                case InputTab.RehabilitationOrder:
                    OrderBox.UCOCS2015U11Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 03
                case InputTab.InjectionOrder:
                    OrderBox.UCOCS2015U12Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 04
                case InputTab.LabTestOrder:
                    OrderBox.UCOCS2015U13Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 05
                case InputTab.PhysiologicalTestOrder:
                    OrderBox.UCOCS2015U14Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 06
                case InputTab.PathologicalInspectionOrder:
                    OrderBox.UCOCS2015U15Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 07
                case InputTab.RadiationInspectionOrder:
                    OrderBox.UCOCS2015U16Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 08
                case InputTab.MinorSurgeryOrder:
                    OrderBox.UCOCS2015U17Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 09
                case InputTab.SurgeryOrder:
                    OrderBox.UCOCS2015U18Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                // 11
                case InputTab.OtherOrder:
                    OrderBox.UCOCS2015U19Control.Visible = true;
                    OrderBox.PnlReserOrderList.Visible = false;
                    break;
                default:
                    break;
            }

        }

        #endregion

        private void SetDisplayLayout(string aInputGubun, string aInputTab)
        {
            if (this.layDisplayLayout.RowCount > 0)
                this.layDisplayLayout.Reset();

            MultiLayout layTemp = this.layDisplayLayout.Clone();
            MultiLayout sourceLay = this.layQueryLayout.Clone();

            Hashtable existOrder = new Hashtable();

            #region [ 내복약 ]

            //OrderBox.DrugControl.Visible = aInputTab == "01";
            SetDisiableAllControlOnU11();
            EnableControlWhenSelectInputTab(aInputTab);

            if (aInputTab == "01" || aInputTab == "%") // 내복약
            {
                sourceLay.Reset();

                // 의사가 로그인한 경우
                if (this.mDoctorLogin)
                {
                    // 내복약 셋팅

                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layDrugOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                    //DataTable dt_tmp = layDrugOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                // 의사 이외의 사람이 로그인한 경우
                else
                {
                    // 내복약 셋팅

                    for (int i = 0; i < this.layDrugOrder.RowCount; i++)
                    {
                        if (this.layDrugOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layDrugOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layDrugOrder.LayoutTable.Rows[i]);
                        }
                    }
                    //DataTable dt_tmp = layDrugOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow drugRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(drugRow);
                    //OrderBox.GrdDebug.LayoutTable.ImportRow(drugRow);
                }

                //OrderBox.GrdDebug.DisplayData();
            }

            #endregion

            #region [ 주사약 ]

            if (aInputTab == "03" || aInputTab == "%") // 주사약
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 주사약 셋팅

                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layJusaOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layJusaOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 주사약 셋팅

                    for (int i = 0; i < this.layJusaOrder.RowCount; i++)
                    {
                        if (this.layJusaOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layJusaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layJusaOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layJusaOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow jusaRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(jusaRow);
                }
            }

            #endregion

            #region [ 검체검사 ]

            if (aInputTab == "04" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 검체검사 셋팅

                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layCplOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layCplOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 검체검사 셋팅

                    for (int i = 0; i < this.layCplOrder.RowCount; i++)
                    {
                        if (this.layCplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layCplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layCplOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layCplOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 검체검사 오더 셋팅

                foreach (DataRow cplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(cplRow);
                }
            }

            #endregion

            #region [ 생리검사 ]

            if (aInputTab == "05" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 생리검사 셋팅

                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layPfeOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layPfeOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 생리검사 셋팅

                    for (int i = 0; i < this.layPfeOrder.RowCount; i++)
                    {
                        if (this.layPfeOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layPfeOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layPfeOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layPfeOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 생리검사 오더 셋팅

                foreach (DataRow pfeRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(pfeRow);
                }
            }

            #endregion

            #region [ 병리검사 ]

            if (aInputTab == "06" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layAplOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layAplOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layAplOrder.RowCount; i++)
                    {
                        if (this.layAplOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layAplOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layAplOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layAplOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow aplRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(aplRow);
                }
            }

            #endregion

            #region [ 방사선 ]

            if (aInputTab == "07" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 방사선 셋팅

                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layXrtOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layXrtOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 병리검사 셋팅

                    for (int i = 0; i < this.layXrtOrder.RowCount; i++)
                    {
                        if (this.layXrtOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layXrtOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layXrtOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layXrtOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 병리검사 오더 셋팅

                foreach (DataRow xrtRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(xrtRow);
                }
            }

            #endregion

            #region [ 처치오더 ]

            if (aInputTab == "08" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 처치오더 셋팅

                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layChuchiOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layChuchiOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 처치오더 셋팅

                    for (int i = 0; i < this.layChuchiOrder.RowCount; i++)
                    {
                        if (this.layChuchiOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layChuchiOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layChuchiOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layChuchiOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 처치 오더 셋팅

                foreach (DataRow chuchiRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(chuchiRow);
                }
            }

            #endregion

            #region [ 수술오더 ]

            if (aInputTab == "09" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 수술오더 셋팅

                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.laySusulOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = laySusulOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 수술오더 셋팅

                    for (int i = 0; i < this.laySusulOrder.RowCount; i++)
                    {
                        if (this.laySusulOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.laySusulOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.laySusulOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = laySusulOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 수술오더  셋팅

                foreach (DataRow susulRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(susulRow);
                }
            }

            #endregion

            #region [ リハビリ ] リハビリオーダ追加 2012/09/26

            if (aInputTab == "10" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {

                    for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                    {
                        if (this.layRehaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layRehaOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layRehaOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layRehaOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {

                    for (int i = 0; i < this.layRehaOrder.RowCount; i++)
                    {
                        if (this.layRehaOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layRehaOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layRehaOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layRehaOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);

                foreach (DataRow rehaRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(rehaRow);
                }
            }

            #endregion

            #region [ 기타오더 ]

            if (aInputTab == "11" || aInputTab == "%")
            {
                sourceLay.Reset();

                if (this.mDoctorLogin)
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}

                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D"
                            || this.layEtcOrder.GetItemString(i, "input_gubun") == "NR")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layEtcOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D"
                    //        || dt_tmp.Rows[i]["input_gubun"].ToString() == "NR")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }
                else
                {
                    // 기타오더 셋팅
                    //foreach (DataRow etcFilter in this.layEtcOrder.LayoutTable.Select("input_gubun like '" + aInputGubun + "' OR input_gubun like 'D%' "))
                    //{
                    //    sourceLay.LayoutTable.ImportRow(etcFilter);
                    //}

                    for (int i = 0; i < this.layEtcOrder.RowCount; i++)
                    {
                        if (this.layEtcOrder.GetItemString(i, "input_gubun") == aInputGubun ||
                            this.layEtcOrder.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
                        {
                            sourceLay.LayoutTable.ImportRow(this.layEtcOrder.LayoutTable.Rows[i]);
                        }
                    }

                    //DataTable dt_tmp = layEtcOrder.LayoutTable;
                    //dt_tmp.DefaultView.Sort = "group_ser desc";
                    //dt_tmp = dt_tmp.DefaultView.ToTable();
                    //for (int i = 0; i < dt_tmp.Rows.Count; i++)
                    //{
                    //    if (dt_tmp.Rows[i]["input_gubun"].ToString() == aInputGubun ||
                    //        dt_tmp.Rows[i]["input_gubun"].ToString().Substring(0, 1) == "D")
                    //    {
                    //        sourceLay.LayoutTable.ImportRow(dt_tmp.Rows[i]);
                    //    }
                    //}
                }

                this.mOrderBiz.SetDisplayOrderData(sourceLay, layTemp);
                // 기타오더  셋팅

                foreach (DataRow etcRow in layTemp.LayoutTable.Rows)
                {
                    this.layDisplayLayout.LayoutTable.ImportRow(etcRow);
                }
            }

            #endregion
        }

        internal void DislplayOrderDataWindow(string aInputGubun, string aInputTab)
        {
            DislplayOrderDataWindow(aInputGubun, aInputTab, true);
        }


        internal void DislplayOrderDataWindow(string aInputGubun, string aInputTab, bool loadDoOrder)
        {
            this.SetInputTabRadioColor(aInputGubun);

            this.SetDisplayLayout(aInputGubun, aInputTab);

            // 全体Ｄｏオーダ関連
            if (loadDoOrder) this.LoadDoOrder_Grid();

            OrderBox.GrdDebug.Reset();
            foreach (DataRow dr in this.layDisplayLayout.LayoutTable.Rows)
            {
                OrderBox.GrdDebug.LayoutTable.ImportRow(dr);
            }
            OrderBox.GrdDebug.DisplayData();

            OrderBox.DwOrderInfo.Reset();

            StringBuilder sb = new StringBuilder();
            foreach (DataColumn col in this.layDisplayLayout.LayoutTable.Columns)
            {
                sb.Append(col.ColumnName + ";");
            }
            string s = sb.ToString();

            OrderBox.DwOrderInfo.FillData(this.layDisplayLayout.LayoutTable);
        }

        private void SetInputTabRadioColor(string aInputGubun)
        {
            XRadioButton allButton = null;
            XRadioButton control;
            bool isExistOrder = false;

            foreach (Control ctl in OrderBox.PnlInputTab.Controls)
            {
                if (ctl is XRadioButton)
                {
                    control = ctl as XRadioButton;
                    // control forecolor reset
                    if (control.Checked)
                    {
                        control.ForeColor = this.mSelectedForeColor;
                    }
                    else
                    {
                        control.ForeColor = this.mUnSelectedForeColor;
                    }

                    if (ctl.Tag.ToString() == "%")
                    {
                        allButton = ctl as XRadioButton;
                    }
                    else
                    {
                        //insert by jc
                        if (ctl.Tag != null)
                        {
                            switch (ctl.Tag.ToString())
                            {
                                case "01": // 약
                                    if (this.layDrugOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "03": // 주사
                                    if (this.layJusaOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "04": // 검체검사
                                    if (this.layCplOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "05": // 생리검사
                                    if (this.layPfeOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "06": // 병리검사
                                    if (this.layAplOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "07": // 방사선
                                    if (this.layXrtOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "08": // 처치
                                    if (this.layChuchiOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "09": // 마취, 수술
                                    if (this.laySusulOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                // リハビリオーダ追加 2012/09/26
                                case "10": // リハビリ
                                    if (this.layRehaOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                                case "11": // 기타
                                    if (this.layEtcOrder.RowCount > 0)
                                    {
                                        control.ForeColor = new XColor(Color.Red);
                                        isExistOrder = true;
                                    }
                                    break;
                            }
                        }
                    }
                }

                if (isExistOrder == true)
                {
                    allButton.ForeColor = new XColor(Color.Red);
                }
            }
        }

        private bool IsPatientSelected()
        {
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "")
            {
                mbxMsg = Resources.MSG029_MSG;
                mbxCap = Resources.MSG029_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ClearOrderData()
        {
            this.layDeletedData.Reset();
            this.layDisplayLayout.Reset();
            this.layDrugOrder.Reset();
            this.layJusaOrder.Reset();
            this.layCplOrder.Reset();
            this.layPfeOrder.Reset();
            this.layAplOrder.Reset();
            this.layXrtOrder.Reset();
            this.layChuchiOrder.Reset();
            this.laySusulOrder.Reset();
            // リハビリオーダ追加 2012/09/26
            this.layRehaOrder.Reset();
            this.layEtcOrder.Reset();
            this.layQueryLayout.Reset();
            this.laySaveLayout.Reset();

            return true;
        }

        private bool MergeToSaveLayout()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn col in this.laySaveLayout.LayoutTable.Columns)
            {
                sb.Append(col.ColumnName + ",");
            }
            string s = sb.ToString();

            // 약부터 시작해서 차례로 넣는다.

            this.laySaveLayout.Reset();
            _grdCheckKinki = new DataTable();
            DataTable dtCl = this.laySaveLayout.LayoutTable.Clone();

            // 내복약오더
            foreach (DataRow dr in this.layDrugOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
                dtCl.ImportRow(dr);
            }

            // 주사오더
            foreach (DataRow dr in this.layJusaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
                dtCl.ImportRow(dr);
            }

            // 검체검사오더
            foreach (DataRow dr in this.layCplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 생리검사오더
            foreach (DataRow dr in this.layPfeOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 병리검사오더
            foreach (DataRow dr in this.layAplOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 방사선 오더
            foreach (DataRow dr in this.layXrtOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 처치오더
            foreach (DataRow dr in this.layChuchiOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 수술오더
            foreach (DataRow dr in this.laySusulOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // リハビリオーダ追加 2012/09/26
            foreach (DataRow dr in this.layRehaOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }

            // 기타오더
            foreach (DataRow dr in this.layEtcOrder.LayoutTable.Rows)
            {
                this.laySaveLayout.LayoutTable.ImportRow(dr);
            }
            _grdCheckKinki = dtCl;

            return true;
        }

        private bool SplitToEachLayout(MultiLayout aQueryLayout)
        {
            // 각각의 레이아웃 Reset
            this.layDrugOrder.Reset(); // 약
            this.layJusaOrder.Reset(); // 주사


            foreach (DataRow dr in aQueryLayout.LayoutTable.Rows)
            {
                // 내복약인경우
                switch (dr["input_tab"].ToString())
                {
                    case "01": // 약인경우

                        this.layDrugOrder.LayoutTable.ImportRow(dr);

                        break;

                    case "03": // 주사

                        this.layJusaOrder.LayoutTable.ImportRow(dr);

                        break;
                }
            }

            return true;
        }

        private bool OrderValidationCheck()
        {
            int dupRow = -1;
            string inputid = "";
            //string hangmog_code = "";
            //string hangmog_name = "";
            //string hope_date = "";
            string errMsg = "";

            // 권한체크 
            if (this.mDoctorLogin)
            {
                inputid = UserInfo.DoctorID;
            }
            else
            {
                inputid = UserInfo.UserID;
            }

            #region [終了された傷病に必ず事由をいれる事をチェック]

            XEditGrid CurrGRD = this.grdOutSang;
            for (int i = 0; i < CurrGRD.RowCount; i++)
            {
                if (CurrGRD.GetItemString(i, "sang_end_date") != "" && CurrGRD.GetItemString(i, "sang_end_sayu") == "")
                {
                    XMessageBox.Show(Resources.MSG019_MSG, Resources.MSG001_CAP, MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    this.grdOutSang.SetFocusToItem(i, "sang_end_sayu");
                    return false;
                }
            }

            #endregion

            int UnchangedCNT = 0;

            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                {
                    UnchangedCNT++;
                }
                // Interface 대상이면서 Key 가 없으면 
                // 여기서 키를 딴다.
                if (this.mInterface.IsInterfaceHangmog(false, "O", this.laySaveLayout.LayoutTable.Rows[i]) &&
                    this.laySaveLayout.GetItemString(i, "pkocskey") == "")
                {
                    this.laySaveLayout.SetItemValue(i, "pkocskey",
                        this.mOrderFunc.GetOrderKey(OrderVariables.OrderMode.OutOrder));
                }

                // 承認したオーダーを代行者が修正できなくする。
                if (this.mInputGubun == "CK"
                    && this.laySaveLayout.GetItemString(i, "pkocskey") != ""
                    && this.laySaveLayout.LayoutTable.Rows[i].RowState != DataRowState.Unchanged)
                {
                    string PostApproveYN =
                        TypeCheck.NVL(this.laySaveLayout.GetItemString(i, "postapprove_yn"), "N").ToString();

                    PostApproveYN = PostApproveYN == "Y" ? "D0" : this.mInputGubun;

                    //if (!this.mOrderBiz.IsPossibleInsteadOrder(this.laySaveLayout.GetItemString(i, "pkocskey"), this.laySaveLayout.GetItemString(i, "input_gubun"), this.IO_Gubun))
                    if (
                        !this.mOrderBiz.IsPossibleInsteadOrder(this.laySaveLayout.GetItemString(i, "pkocskey"),
                            PostApproveYN, this.IO_Gubun))
                    {
                        XMessageBox.Show(Resources.MSG020_MSG, Resources.MSG001_CAP);
                        return false;
                    }
                }

                // 의뢰지 작성여부 체크 
                if (this.laySaveLayout.GetItemString(i, "specific_comment_not_null") == "Y" &&
                    this.laySaveLayout.GetItemString(i, "specific_comment") != "CM")
                {
                    if (this.mOrderBiz.IsSpeciFicCommentInputYn(this.laySaveLayout.GetItemString(i, "hangmog_code"),
                        this.laySaveLayout.GetItemString(i, "pkocskey")))
                    {
                        this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " +
                                    this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                    + "\n=================================================================\n"
                                    + XMsg.GetMsg("M003"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.
                        MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                }

                // 원외처방인 경우는 비치일수 없음.
                if (this.laySaveLayout.GetItemString(i, "wonyoi_order_yn") == "Y" &&
                    this.laySaveLayout.GetItemString(i, "bichi_yn") == "Y")
                {
                    this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " +
                                this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                + "\n=================================================================\n"
                                + XMsg.GetMsg("M004"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                // 환자상태에 따른 금지
                if (
                    this.mOrderBiz.CheckPatientStatus(this.laySaveLayout.GetItemString(i, "bunho"),
                        this.laySaveLayout.GetItemString(i, "hangmog_code"),
                        this.laySaveLayout.GetItemString(i, "hangmog_name")) == true)
                {
                    return false;
                }

                // 처치 부위 체크 
                if (this.laySaveLayout.GetItemString(i, "input_control") == "A" &&
                    this.laySaveLayout.GetItemString(i, "bogyong_code") == "")
                {
                    this.mMsg = "▶ " + "[ " + this.laySaveLayout.GetItemString(i, "hangmog_code") + " ] " +
                                this.laySaveLayout.GetItemString(i, "hangmog_name") + "\r\n"
                                + "\n=================================================================\n"
                                + XMsg.GetMsg("M007"); //반드시 의뢰지를 작성해야 하는 항목입니다. 의뢰지를 작성하십시오.

                    MessageBox.Show(this.mMsg, XMsg.GetField("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }

                //if (i != 0)
                //{
                //    string cmd = " SELECT FN_CPL_LOAD_DUP_GRD_HANGMOG('" + this.laySaveLayout.GetItemString(i, "hangmog_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i, "specimen_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i - 1, "hangmog_code") + "', '"
                //               + this.laySaveLayout.GetItemString(i - 1, "specimen_code") + "') "
                //               + "   FROM DUAL ";

                //    object check = Service.ExecuteScalar(cmd);

                //    if (TypeCheck.IsNull(check) == false)
                //    {
                //        if (check.ToString() != "0")
                //        {
                //            this.mMsg = check.ToString() + "\n" + "===================================================\n" +
                //                        "このまま保存しますか?";

                //            if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //            {
                //                return false;
                //            }
                //        }
                //    }


                //}

                //hangmog_code = this.laySaveLayout.GetItemString(i, "hangmog_code");
                //hangmog_name = this.laySaveLayout.GetItemString(i, "hangmog_name");
                //hope_date = TypeCheck.NVL(this.laySaveLayout.GetItemString(i, "hope_date"), this.DtpNaewonDate.GetDataValue()).ToString();
                //for (int j = i + 1; j < this.laySaveLayout.RowCount; j++)
                //{
                //    if (hangmog_code == this.laySaveLayout.GetItemString(j, "hangmog_code") &&
                //        hope_date == TypeCheck.NVL(this.laySaveLayout.GetItemString(j, "hope_date"), this.DtpNaewonDate.GetDataValue()).ToString())
                //    {
                //        string message = "<   項目コード   " + hangmog_code + "   " + "案内" + "  >" + "\r\n\r\n\r\n" +
                //                        "[ " + hangmog_name + " ]" + "\r\n\r\n\r\n" +
                //                        " " + "当日 重複オーダ です";

                //        this.mMsg = message + "\n" + "===================================================\n" +
                //                        "このまま保存しますか?";

                //        if (MessageBox.Show(this.mMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                //        {
                //            return false;
                //        }
                //    }
                //}


            }

            #region [処置で処置結果が入力されてないと見なされるオーダーチェック]

            /*
                             * 液体酸素・可搬式液化酸素容器（ＬＧＣ）
                             * 人工呼吸
                             * 人工呼吸（鼻マスク式人工呼吸器）
                             * 呼吸心拍監視
                             */
            bool finish_chuci = true;
            //            string cmd_chuchi = @" SELECT A.CODE, A.GROUP_KEY
            //                                     FROM OCS0132 A
            //                                    WHERE A.HOSP_CODE = :f_hosp_code
            //                                      AND A.CODE_TYPE = 'MARUME_ORDER'
            //                                      AND A.VALUE_POINT = '2'
            //                                    ";
            //            BindVarCollection bind_chuci = new BindVarCollection();
            //            bind_chuci.Add("f_hosp_code", EnvironInfo.HospCode);

            //            DataTable dt = Service.ExecuteDataTable(cmd_chuchi, bind_chuci);

            DataTable dt = null;

            // Connet to cloud service
            OcsoOCS1003P01GetChuciArgs vOcsoOCS1003P01GetChuciArgs = new OcsoOCS1003P01GetChuciArgs();
            vOcsoOCS1003P01GetChuciArgs.CodeType = "MARUME_ORDER";
            vOcsoOCS1003P01GetChuciArgs.ValuePoint = "2";
            OcsoOCS1003P01GetChuciResult chuciResult =
                CloudService.Instance.Submit<OcsoOCS1003P01GetChuciResult, OcsoOCS1003P01GetChuciArgs>(
                    vOcsoOCS1003P01GetChuciArgs);

            if (chuciResult != null && chuciResult.ExecutionStatus == ExecutionStatus.Success)
            {
                dt = Utility.ConvertToDataTable(chuciResult.ChuciItem);
            }
            // End connect to cloud
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < this.laySaveLayout.RowCount; i++)
                    {
                        if (dr["code"].ToString() == this.laySaveLayout.GetItemString(i, "hangmog_code")
                            && this.laySaveLayout.GetItemString(i, "jundal_table") == "HOM")
                        {
                            switch (dr["group_key"].ToString())
                            {
                                case "OK": // 数量(分あたり注入量(ℓ)), 日数(注入分)
                                    if (this.laySaveLayout.GetItemString(i, "nalsu") == "1")
                                        finish_chuci = false;
                                    break;

                                case "AH": // 数量(時間), 日数(分)
                                    if (this.laySaveLayout.GetItemString(i, "suryang") == "0"
                                        && this.laySaveLayout.GetItemString(i, "nalsu") == "1")
                                        finish_chuci = false;
                                    break;

                                case "MN": // 数量(分), 日数(固定)
                                    if (this.laySaveLayout.GetItemString(i, "suryang") == "1")
                                        finish_chuci = false;
                                    break;
                            }

                            DialogResult result = new DialogResult();
                            if (!finish_chuci)
                            {
                                result =
                                    XMessageBox.Show(
                                        this.laySaveLayout.GetItemString(i, "hangmog_name") + Resources.MSG021_MSG,
                                        Resources.MSG001_CAP, MessageBoxButtons.YesNoCancel,
                                        MessageBoxDefaultButton.Button1);

                                if (result != DialogResult.No)
                                    return false;
                                else
                                    return true;
                            }
                        }
                    }
                }
            }

            #endregion [処置で処置結果が入力されてないと見なされるオーダーチェック]

            // 同一グループ内頓服回数チェック
            ArrayList arrGroupSerList = new ArrayList();
            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.GetItemString(i, "input_tab") == "01"
                    && this.laySaveLayout.GetItemString(i, "donbog_yn") == "Y")
                {
                    if (!arrGroupSerList.Contains(this.laySaveLayout.GetItemString(i, "group_ser")))
                        arrGroupSerList.Add(this.laySaveLayout.GetItemString(i, "group_ser"));
                }
            }

            for (int i = 0; i < arrGroupSerList.Count; i++)
            {
                DataRow[] dr =
                    this.laySaveLayout.LayoutTable.Select("group_ser = '" + arrGroupSerList[i].ToString() + "'");

                string dv1th = dr[0]["dv"].ToString();
                string group_ser1th = dr[0]["group_ser"].ToString();
                for (int j = 0; j < dr.Length; j++)
                {
                    if (group_ser1th == dr[j]["group_ser"].ToString()
                        && dv1th != dr[j]["dv"].ToString())
                    {
                        XMessageBox.Show("[" + dr[j]["group_ser"].ToString() + Resources.MSG022_MSG,
                            Resources.MSG001_CAP);
                        return false;
                    }
                }
            }

            if (UnchangedCNT > 0 && UserInfo.Gwa == "CK")
            {
                string isInstead = "";
                isInstead =
                    this.mOrderBiz.isAbleInsteadOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                        , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

                if (isInstead != "")
                {
                    XMessageBox.Show(isInstead, Resources.MSG001_CAP, MessageBoxIcon.Stop);
                    return false;
                }
            }

            // 중복처방체크 
            if (this.mOrderBiz.IsProtecedDupInputOutOrder(this.laySaveLayout,
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString()
                , ref dupRow) == true)
            {
                return false;
            }

            // 원내원외 체크 
            if (this.mOrderBiz.CheckExistWonnaeWonyoiDrg(this.laySaveLayout.LayoutTable, ref errMsg) == true)
            {
                this.mMsg = errMsg + XMsg.GetMsg("M008");
                this.mCap = XMsg.GetField("F001");

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                outOfHosp = true;
                return false;
            }
            else
            {
                outOfHosp = false;
            }

            return true;
        }

        private void SetInputGubunColor(string aInputGubun)
        {
            this.ClearInputGubunColor();

            //foreach (IHIS.X.Magic.Controls.TabPage tpg in OrderBox.TabInputGubun.TabPages)
            //{
            //    if (this.mDoctorLogin)
            //    {
            //        if (tpg.Tag.ToString() == aInputGubun)
            //        {
            //            tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //    }
            //    else
            //    {
            //        if (tpg.Tag.ToString() == "D%")
            //        {
            //            if (tpg.Tag.ToString().Substring(0, 1) == aInputGubun.Substring(0, 1))
            //                tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //        else
            //        {
            //            if (tpg.Tag.ToString() == aInputGubun)
            //                tpg.TitleTextColor = this.mExistInputGubunColor.Color;
            //        }
            //    }
            //}

            foreach (IHIS.X.Magic.Controls.TabPage tpg in OrderBox.TabInputGubun.TabPages)
            {
                if (this.mDoctorLogin)
                {
                    if (tpg.Tag.ToString() == aInputGubun)
                    {
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                }
                else
                {
                    if (aInputGubun == tpg.Tag.ToString() ||
                        aInputGubun.Substring(0, 1) == "D")
                    //if (tpg.Tag.ToString() == "D%")
                    {
                        //if  (tpg.Tag.ToString().Substring(0, 1) == aInputGubun.Substring(0, 1))
                        //    tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    }
                    //else
                    //{
                    //    if (tpg.Tag.ToString() == aInputGubun)
                    //        tpg.TitleTextColor = this.mExistInputGubunColor.Color;
                    //}
                }
            }
        }

        #endregion

        #region [ 공통의 선택시 로직들 ]

        /// <summary>
        /// Process Common Doctor
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        internal void ProcessCommonDoctor(string aPkNaewonKey)
        {
            //            if (IsCommonDoctorJubsu(aPkNaewonKey) == true)
            //            {
            //                // 공통의 환자를 선택하는 순간 
            //                // 해당 환자는 선택한 의사의 환자가 된다.
            //                string cmd = @"UPDATE OUT1001 A
            //                                  SET A.DOCTOR    = :f_doctor
            //                                     , A.GWA      = :f_gwa
            //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                  AND A.PKOUT1001 = :f_pk_naewon";

            //                BindVarCollection bindVar = new BindVarCollection();

            //                if (this.mDoctorLogin)
            //                {
            //                    bindVar.Add("f_doctor", UserInfo.DoctorID);
            //                    bindVar.Add("f_gwa", UserInfo.Gwa);
            //                }
            //                else
            //                {
            //                    bindVar.Add("f_doctor", pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
            //                    bindVar.Add("f_gwa", pendingPatient.PatientBox.CboQryGwa.GetDataValue());
            //                }
            //                bindVar.Add("f_pk_naewon", aPkNaewonKey);

            //                Service.ExecuteNonQuery(cmd, bindVar);
            //            }

            // Connect To cloud: update doctor
            string doctor = "";
            string gwa = "";
            if (this.mDoctorLogin)
            {
                doctor = UserInfo.DoctorID;
                gwa = UserInfo.Gwa;
            }
            else
            {
                //doctor = pendingPatient.PatientBox.CboQryDoctor.GetDataValue();
                //gwa = pendingPatient.PatientBox.CboQryGwa.GetDataValue();

                doctor = pendingPatient.PatientBox.FbxDoctor.GetDataValue();
                gwa = pendingPatient.PatientBox.CboGwa.GetDataValue();
            }
            ProcessUpdateDoctor(doctor, gwa, aPkNaewonKey);
        }

        /// <summary>
        /// Check Is Common Doctor Jubsu
        /// </summary>
        /// <param name="aPkNaewonKey"></param>
        /// <returns></returns>
        internal bool IsCommonDoctorJubsu(string aPkNaewonKey)
        {
            //            string cmd = @"SELECT 'Y'
            //                             FROM DUAL
            //                            WHERE EXISTS ( SELECT 'X'
            //                                             FROM OUT1001 A
            //                                                  , BAS0270 B
            //                                            WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"'
            //                                              AND A.PKOUT1001 = :f_naewon_key
            //                                              AND B.HOSP_CODE = A.HOSP_CODE
            //                                              AND B.DOCTOR = A.DOCTOR
            //                                              AND B.DOCTOR_GWA = A.GWA
            //                                              AND A.NAEWON_DATE BETWEEN B.START_DATE
            //                                                                    AND NVL(B.END_DATE, TO_DATE('99981231', 'YYYYMMDD'))
            //                                              AND NVL(B.COMMON_DOCTOR_YN, 'N') = 'Y')";

            //            BindVarCollection bindVar = new BindVarCollection();
            //            bindVar.Add("f_naewon_key", aPkNaewonKey);

            //            object val = Service.ExecuteScalar(cmd, bindVar);

            // Connect cloud
            OcsoOCS1003P01CheckYArgs checkYArgs = new OcsoOCS1003P01CheckYArgs();
            checkYArgs.NaewonKey = aPkNaewonKey;
            OcsoOCS1003P01CheckYResult val =
                CloudService.Instance.Submit<OcsoOCS1003P01CheckYResult, OcsoOCS1003P01CheckYArgs>(checkYArgs);

            if (TypeCheck.IsNull(val) == false && "Y".Equals(val.NaewonKeyValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal bool IsSameNameCHK()
        {
            //if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "SAME_NAME_CHECK_YN", this.IO_Gubun) == "N")
            if (UserOptions.SameNameCheckYn == "N")
                return false;

            //            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN(:f_hosp_code, 
            //                                                         :f_naewon_date, 
            //                                                         :f_gwa, 
            //                                                         :f_naewon_yn, 
            //                                                         :f_reser_yn, 
            //                                                         :f_doctor_mode_yn, 
            //                                                         :f_doctor, 
            //                                                         :f_suname,
            //                                                         :f_bunho) 
            //                             FROM SYS.DUAL";

            // TODO comment: user connect cloud
            //            string cmd = @"SELECT FN_ADM_IS_SAME_NAME_YN_T(
            //                                                         :f_naewon_date, 
            //                                                         :f_gwa, 
            //                                                         :f_naewon_yn, 
            //                                                         :f_reser_yn, 
            //                                                         :f_doctor_mode_yn, 
            //                                                         :f_doctor, 
            //                                                         :f_bunho) 
            //                             FROM SYS.DUAL";

            //            BindVarCollection bindVar = new BindVarCollection();

            //            bindVar.Add("f_naewon_date", this.DtpNaewonDate.GetDataValue());
            //            bindVar.Add("f_gwa", pendingPatient.PatientBox.CboQryGwa.GetDataValue());
            //            bindVar.Add("f_doctor", TypeCheck.NVL(pendingPatient.PatientBox.CboQryDoctor.GetDataValue(), "%").ToString());
            //            bindVar.Add("f_bunho", pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "bunho"));
            //            bindVar.Add("f_reser_yn", "%");
            //            bindVar.Add("f_naewon_yn", "%");

            //            if (this.mDoctorLogin)
            //                bindVar.Add("f_doctor_mode_yn", "Y");
            //            else
            //                bindVar.Add("f_doctor_mode_yn", "N");

            //            object val = Service.ExecuteScalar(cmd, bindVar);
            //            if (TypeCheck.IsNull(val) == false && val.ToString() == "Y")
            //            {
            //                return true;
            //            }
            //            else
            //            {
            //                return false;
            //            }
            // End Comment

            // Connect to cloud service
            //OcsoOCS1003P01CheckIsSameNameYnArgs vOcsoOCS1003P01CheckIsSameNameYnArgs =
            //    new OcsoOCS1003P01CheckIsSameNameYnArgs();
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonDate = this.DtpNaewonDate.GetDataValue();
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.Gwa = pendingPatient.PatientBox.CboQryGwa.GetDataValue();
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonYn = "%";
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.ReserYn = "%";
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.Doctor =
            //    TypeCheck.NVL(pendingPatient.PatientBox.CboQryDoctor.GetDataValue(), "%").ToString();
            //vOcsoOCS1003P01CheckIsSameNameYnArgs.Bunho =
            //    pendingPatient.PatientBox.GrdPatientList.GetItemString(
            //        pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "bunho");
            //if (this.mDoctorLogin)
            //    vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "Y";
            //else
            //    vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "N";
            OcsoOCS1003P01CheckIsSameNameYnArgs vOcsoOCS1003P01CheckIsSameNameYnArgs =
                new OcsoOCS1003P01CheckIsSameNameYnArgs();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonDate = this.DtpNaewonDate.GetDataValue();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Gwa = pendingPatient.PatientBox.CboGwa.GetDataValue();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.NaewonYn = "%";
            vOcsoOCS1003P01CheckIsSameNameYnArgs.ReserYn = "%";
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Doctor =
                TypeCheck.NVL(pendingPatient.PatientBox.FbxDoctor.GetDataValue(), "%").ToString();
            vOcsoOCS1003P01CheckIsSameNameYnArgs.Bunho =
                pendingPatient.PatientBox.GrdPatientList.GetItemString(
                    pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "bunho");
            if (this.mDoctorLogin)
                vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "Y";
            else
                vOcsoOCS1003P01CheckIsSameNameYnArgs.DoctorModeYn = "N";
            OcsoOCS1003P01CheckIsSameNameYnResult result =
                CloudService.Instance.Submit<OcsoOCS1003P01CheckIsSameNameYnResult, OcsoOCS1003P01CheckIsSameNameYnArgs>
                    (vOcsoOCS1003P01CheckIsSameNameYnArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.ValueCheck == "Y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 조사록 자동출력

        private void PrintXRTJosa(DataRow aRow)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("doctor", aRow["doctor"].ToString());
            param.Add("bunho", aRow["bunho"].ToString());
            param.Add("order_date", aRow["order_date"].ToString());
            param.Add("pkocskey", aRow["pkocskey"].ToString());
            param.Add("in_out_gubun", "O");
            param.Add("hangmog_code", aRow["hangmog_code"].ToString());
            param.Add("isReadOnly", "Y");
            param.Add("print_only", "Y");
            param.Add("jundal_part", aRow["jundal_part"].ToString());
            param.Add("naewon_key", aRow["in_out_key"].ToString());

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT1002U00", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region リハビリ依頼書自動出力

        private void PrintRehaIraisyo(DataRow aRow)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aRow["bunho"].ToString());
            openParams.Add("order_date", aRow["order_date"].ToString());
            openParams.Add("pkocskey", aRow["pkocskey"].ToString());
            openParams.Add("in_out_gubun", this.IO_Gubun);
            openParams.Add("hangmog_code", aRow["hangmog_code"].ToString());
            openParams.Add("gwa", aRow["gwa"].ToString());
            openParams.Add("doctor", aRow["doctor"].ToString());
            openParams.Add("jundal_part", aRow["jundal_part"].ToString());
            openParams.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            openParams.Add("AutoCloseYN", "Y");

            if (aRow["specific_comment"].ToString() == "18")
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U00", ScreenOpenStyle.ResponseFixed, openParams);
            else
                XScreen.OpenScreenWithParam(this, "PHYS", "PHY8002U01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        #endregion

        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void SetOcsLib(CommonItemCollection param)
        {
            param.Add("mOrderBiz", OcsLibS.mOrderBiz);
            param.Add("mOrderFunc", OcsLibS.mOrderFunc);
            param.Add("mPatientInfo", OcsLibS.mPatientInfo);
            param.Add("mHangmogInfo", OcsLibS.mHangmogInfo);
            param.Add("mInputControl", OcsLibS.mInputControl);
            param.Add("mCommonForms", OcsLibS.mCommonForms);
            param.Add("mColumnControl", OcsLibS.mColumnControl);
            param.Add("mInterface", OcsLibS.mInterface);
        }

        #region [ 다른 화면 오픈 ]

        internal void OpenScreen_OUT0101Q01()
        {
            CommonItemCollection param = new CommonItemCollection();

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 내복약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U10(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U10) ? OrderBox.DrugControl.GrdOrder.LayoutTable : this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("injection_dt", loadedGridModules.Contains(GridModule.OCS0103U12) ? OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable : this.layJusaOrder.LayoutTable);
            string temp = null;
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.DrugControl.ScreenOpen(param, ref temp);
        }

        private void OpenScreen_OCS0103U10(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U10) ? OrderBox.DrugControl.GrdOrder.LayoutTable : this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("injection_dt", loadedGridModules.Contains(GridModule.OCS0103U12) ? OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable : this.layJusaOrder.LayoutTable);

            string temp = null;
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.DrugControl.ScreenOpen(param, ref temp);
        }

        internal void OpenScreen_OCS0103U10(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            //if (this.mDoctorLogin)
            //    param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            //else if (this.mInputGubun == "CK" && this.mPostApproveYN)
            //    param.Add("input_gubun", "D0");
            //else
            //    param.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layDrugOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layDrugOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("injection_dt", loadedGridModules.Contains(GridModule.OCS0103U12) ? OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable : this.layJusaOrder.LayoutTable);

            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U10", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// リハビリオーダ登録画面オープン
        /// リハビリオーダ追加 2012/09/26
        /// </summary>
        private void OpenScreen_OCS0103U11(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U11) ? OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable : this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);
            string temp = null;
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U11Control.ScreenOpen(param, ref temp);
        }

        private void OpenScreen_OCS0103U11(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U11) ? OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable : this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);
            string temp = null;
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U11Control.ScreenOpen(param, ref temp);
        }

        internal void OpenScreen_OCS0103U11(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layRehaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layRehaOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U11", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 주사약 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U12(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U12) ? OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable : this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("drug_dt", loadedGridModules.Contains(GridModule.OCS0103U10) ? OrderBox.DrugControl.GrdOrder.LayoutTable : this.layDrugOrder.LayoutTable);
            try
            {
                popupGridOrderActive = openPopup;
                if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
                else OrderBox.UCOCS2015U12Control.ScreenOpen(param);
            }
            catch (Exception xException)
            {
                MessageBox.Show(xException.StackTrace);
            }

            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);*/
        }

        private void OpenScreen_OCS0103U12(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U12) ? OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable : this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("drug_dt", loadedGridModules.Contains(GridModule.OCS0103U10) ? OrderBox.DrugControl.GrdOrder.LayoutTable : this.layDrugOrder.LayoutTable);

            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U12Control.ScreenOpen(param);
            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);*/
        }

        internal void OpenScreen_OCS0103U12(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layJusaOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            param.Add("dt_grdoutsang", grdOutSang.LayoutTable);
            param.Add("drug_dt", loadedGridModules.Contains(GridModule.OCS0103U10) ? OrderBox.DrugControl.GrdOrder.LayoutTable : this.layDrugOrder.LayoutTable);

            popupGridOrderActive = true;

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U12", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 검체검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U13(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U13) ? OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable : this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("open_popup", openPopup);
            param.Add("protocol_id", protocolId);
            popupGridOrderActive = openPopup;
            if (openPopup)
            {
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
            }
            else
            {
                string inputGubunName = null;
                OrderBox.UCOCS2015U13Control.ScreenOpen(param, ref inputGubunName);
            }
        }

        private void OpenScreen_OCS0103U13(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (this.mDoctorLogin)
                param.Add("input_gubun", aInputGubun);
            else
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", "CK");
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U13) ? OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable : this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("open_popup", openPopup);
            param.Add("protocol_id", protocolId);

            popupGridOrderActive = openPopup;
            if (openPopup)
            {
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
            }
            else
            {
                string inputGubunName = null;
                OrderBox.UCOCS2015U13Control.ScreenOpen(param, ref inputGubunName);
            }
        }

        internal void OpenScreen_OCS0103U13(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row",  this.layCplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            //insert by jc
            param.Add("in_do_data_row", this.layCplOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U13", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 생리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U14(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U14) ? OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable : this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U14Control.ScreenOpen(param);

            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);*/
        }

        private void OpenScreen_OCS0103U14(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U14) ? OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable : this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U14Control.ScreenOpen(param);

            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);*/
        }

        internal void OpenScreen_OCS0103U14(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layPfeOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layPfeOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", this.protocolId);
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U14", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 병리검사 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U15(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U15) ? OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable : this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);

            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U15Control.ScreenOpen(param);

            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);*/
        }

        private void OpenScreen_OCS0103U15(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U15) ? OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable : this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U15Control.ScreenOpen(param);

            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);*/
        }

        internal void OpenScreen_OCS0103U15(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layAplOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("in_do_data_row", this.layAplOrder_Do);
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U15", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 방사선오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U16(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U16) ? OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable : this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U16Control.ScreenOpen(param);
        }

        private void OpenScreen_OCS0103U16(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U16) ? OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable : this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U16Control.ScreenOpen(param);
        }

        internal void OpenScreen_OCS0103U16(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layXrtOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U16", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 처치오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U17(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U17) ? OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable : this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U17Control.ScreenOpen(param);
            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);*/
        }

        private void OpenScreen_OCS0103U17(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U17) ? OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable : this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = openPopup;
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U17Control.ScreenOpen(param);
            /*XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);*/
        }

        internal void OpenScreen_OCS0103U17(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layChuchiOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U17", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 수술오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U18(bool openPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U18) ? OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable : this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = openPopup;
            // XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U18Control.ScreenOpen(param);
        }

        private void OpenScreen_OCS0103U18(bool openPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U18) ? OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable : this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", protocolId);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", openPopup);
            popupGridOrderActive = openPopup;
            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            if (openPopup) XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
            else OrderBox.UCOCS2015U18Control.ScreenOpen(param);
        }

        internal void OpenScreen_OCS0103U18(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;

            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.laySusulOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U18", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 기타오더 입력화면 오픈
        /// </summary>
        private void OpenScreen_OCS0103U19(bool isOpenPopup)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }
            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U19) ? OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable : this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);

            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", isOpenPopup);
            param.Add("protocol_id", protocolId);
            popupGridOrderActive = isOpenPopup;
            if (isOpenPopup)
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
            else
            {
                OrderBox.UCOCS2015U19Control.ScreenOpen(param);
            }
            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_OCS0103U19(bool isOpenPopup, string aInputGubun)
        {
            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            param.Add("input_gubun", aInputGubun);

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", loadedGridModules.Contains(GridModule.OCS0103U19) ? OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable : this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            param.Add("protocol_id", protocolId);
            popupGridOrderActive = isOpenPopup;
            if (isOpenPopup)
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
            else
            {
                OrderBox.UCOCS2015U19Control.ScreenOpen(param);
            }

            //XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        internal void OpenScreen_OCS0103U19(XDataWindow aDw, int aCurrentRowNum, string aCurrentColName,
            int aStartRowNum)
        {
            if (!_isEnableGrd) return;

            CommonItemCollection param = new CommonItemCollection();

            SetOcsLib(param);
            param.Add("order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            param.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            param.Add("io_gubun", IO_Gubun);

            if (UserInfo.Gwa == "CK")
            {
                if (this.mPostApproveYN)
                    param.Add("input_gubun", "D0");
                else
                    param.Add("input_gubun", this.mInputGubun);
            }
            else
            {
                param.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            }

            //param.Add("input_part", OrderVariables.CommonInfo.Items[OrderVariables.OCSUSERINFO].Items["input_part"].ToString());
            param.Add("input_part", this.mInputGwa);
            param.Add("naewon_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            param.Add("patient_info", this.mSelectedPatientInfo);
            param.Add("input_gubun_name", OrderBox.TabInputGubun.SelectedTab.Title);
            param.Add("in_data_row", this.layEtcOrder.LayoutTable);
            param.Add("caller_screen_id", this.ScreenID);
            param.Add("caller_sys_id", EnvironInfo.CurrSystemID);
            param.Add("order_mode", OrderVariables.OrderMode.OutOrder);
            //insert by jc
            param.Add("currentRowNum", aCurrentRowNum);
            param.Add("currentDataWindow", aDw);
            param.Add("currentColName", aCurrentColName);
            param.Add("startRowNum", aStartRowNum);
            param.Add("is_enable_grd", _isEnableGrd);
            param.Add("isOpenPopUp", true);
            param.Add("protocol_id", protocolId);
            param.Add("postapprove_yn", mPostApproveYN == true ? "Y" : "N");
            popupGridOrderActive = true;
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103U19", ScreenOpenStyle.ResponseFixed, param);
        }

        /// <summary>
        /// 사용자별 상병입력 
        /// </summary>
        /// <param name="aMemb">사용자</param>
        private void OpenScreen_OCS0204Q00(string aMemb)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("sang_code", "");
            if (this.mDoctorLogin)
            {
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else
            {
                openParams.Add("memb", UserInfo.UserID);
            }
            openParams.Add("gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        /// <summary>
        /// 수식어 입력창 오픈
        /// </summary>
        /// <param name="aRowNumber">현재 상병 그리드의 로우번호</param>
        private void OpenScreen_CHT0115Q00(int aRowNumber)
        {
            MultiLayout laySusikInfo = new MultiLayout();
            laySusikInfo.LayoutItems.Add("sang_name", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier1", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier2", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier3", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier4", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier5", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier6", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier7", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier8", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier9", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier10", DataType.String);
            laySusikInfo.LayoutItems.Add("pre_modifier_name", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier1", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier2", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier3", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier4", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier5", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier6", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier7", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier8", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier9", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier10", DataType.String);
            laySusikInfo.LayoutItems.Add("post_modifier_name", DataType.String);
            laySusikInfo.InitializeLayoutTable();

            int insertRow = laySusikInfo.InsertRow(-1);

            foreach (XEditGridCell cell in this.grdOutSang.CellInfos)
            {
                if (laySusikInfo.LayoutItems.Contains(cell.CellName))
                    laySusikInfo.SetItemValue(insertRow, cell.CellName,
                        grdOutSang.GetItemValue(aRowNumber, cell.CellName));
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("SANGINFO", laySusikInfo);
            openParams.Add("user_id", UserInfo.UserID);
            openParams.Add("io_gubun", this.IO_Gubun);
            //서식지처방 조회 화면 Open
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0115Q00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        // 환자별 상병 입력창 오픈
        internal void OpenScreen_OUTSANGU00(string aIOGubun, string aBunho, string aGwa, string aNaewonDate)
        {
            if (aBunho != "")
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("io_gubun", aIOGubun);
                openParams.Add("bunho", aBunho);
                openParams.Add("gwa", aGwa);
                openParams.Add("naewon_date", aNaewonDate);

                XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGU00", ScreenOpenStyle.ResponseSizable, openParams);
            }
            else
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("io_gubun", aIOGubun);
                openParams.Add("bunho", aBunho);
                openParams.Add("naewon_date", aNaewonDate);
                XScreen.OpenScreenWithParam(this, "OCSO", "OUTSANGU00", ScreenOpenStyle.ResponseSizable, openParams);
            }
        }

        private void OpenScreen_CHT0110Q00(string aSangINX, bool aIsMultiSelect, string aDate)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("sang_inx", aSangINX);
            param.Add("multiSelect", "True");
            param.Add("date", aDate);
            param.Add("io_gubun", IO_Gubun);
            param.Add("user_id", UserInfo.UserID);

            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_INP1003U01(string aBunho, string aReserDate, string aGwa, string aDoctor,
            string aNaewonType, string aJubsuNo, string aFkout1001)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);

            if (int.Parse(aReserDate.ToString().Replace("/", "")) <
                int.Parse( /*EnvironInfo.GetSysDate()*/_sysDate.ToString("yyyyMMdd")))
            {
                openParams.Add("reser_date", /*EnvironInfo.GetSysDate()*/
                    _sysDate.ToString("yyyy/MM/dd").Replace("-", "/"));
            }
            else
            {
                openParams.Add("reser_date", aReserDate.Replace("-", "/"));
            }

            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            openParams.Add("fkout1001", aFkout1001);

            XScreen.OpenScreenWithParam(this, "INPS", "INP1003U01", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS2003P01(string aBunho, string aReserDate, string aPkinp1001)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_key", aPkinp1001);
            if (aReserDate != null) openParams.Add("order_date", aReserDate);

            // 입원오더 메인
            XScreen.OpenScreenWithParam(this, "OCSI", "OCS2003P01", ScreenOpenStyle.ResponseSizable,
                ScreenAlignment.ParentTopLeft, openParams);
        }

        //modify by jc
        private void OpenScreen_OCS0503U00(string aBbunho, string aReqDate, string aReqGwa, string aReqDoctor,
            string aNaewon_key)
        //private void OpenScreen_OCS0503U00(string aBbunho, string aReqDate, string aReqGwa, string aReqDoctor)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBbunho);
            openParams.Add("req_date", aReqDate);
            openParams.Add("req_gwa", aReqGwa);
            openParams.Add("req_doctor", aReqDoctor);
            //insert by jc
            openParams.Add("naewon_key", aNaewon_key);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0503U01(string aBunho, string aReqDate, string aConsultGwa, string aConsultDoctor)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("req_date", aReqDate);
            openParams.Add("consult_gwa", aConsultGwa);
            openParams.Add("consult_doctor", aConsultDoctor);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0503U01", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R00(string aBunho, string aNaewonDate, string aGwa, string aDoctor,
            string aNaewonType, string aJubsuNo, string aJubsukey, bool aAutoClose, bool abacode_flg)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            //openParams.Add("input_gubun", mInputGubun);
            openParams.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            openParams.Add("auto_close", aAutoClose); // 출력후 닫기
            openParams.Add("jubsu_key", aJubsukey);
            openParams.Add("bacode_flg", abacode_flg);


            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R00(string aBunho, string aNaewonDate, string aGwa, string aDoctor,
            string aNaewonType, string aJubsuNo, string aJubsukey, bool aAutoClose)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("jubsu_no", aJubsuNo);
            //openParams.Add("input_gubun", mInputGubun);
            openParams.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            openParams.Add("auto_close", aAutoClose); // 출력후 닫기
            openParams.Add("jubsu_key", aJubsukey);



            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R00", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003R02(string aBunho, string aNaewonDate, string aGwa, string aDoctor,
            string aNaewonType, string aJubsuNo, string aNaewonKey, bool aAutoClose)
        {
            try
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("bunho", aBunho);
                openParams.Add("naewon_date", aNaewonDate);
                openParams.Add("gwa", aGwa);
                openParams.Add("doctor", aDoctor);
                openParams.Add("naewon_type", aNaewonType);
                openParams.Add("jubsu_no", aJubsuNo);
                openParams.Add("input_gubun", mInputGubun);
                openParams.Add("auto_close", aAutoClose); // 출력후 닫기
                openParams.Add("pk_naewon", aNaewonKey);

                XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003R02", ScreenOpenStyle.ResponseSizable, openParams);
            }
            catch
            {
            }
        }

        private void OpenScreen_OCS1003U01(string aBunho, string aNaewonDate, string aGwa, string aDoctor,
            string aNaewonType, string aInputGubun)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("naewon_date", aNaewonDate);
            openParams.Add("gwa", aGwa);
            openParams.Add("doctor", aDoctor);
            openParams.Add("naewon_type", aNaewonType);
            openParams.Add("input_gubun", aInputGubun);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003U01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_OUT0123U00(string aBunho, string aGwa, string aDoctor, string aNaewonKey)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("req_gwa", aGwa);
            openParams.Add("req_doctor", aDoctor);
            openParams.Add("pkout1001", aNaewonKey);

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0123U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_NUR1001R98(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("auto_close", "N");
            openParams.Add("reser_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1001R98", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_NUR1016U00(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURO", "NUR1016U00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void OpenScreen_OUT0106U00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "OUTS", "OUT0106U00", ScreenOpenStyle.ResponseFixed, param);
        }

        public void OpenScreen_OCSAPPROVE(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", aBunho);
            openParams.Add("caller_sys_id", this.Name);
            openParams.Add("io_gubun", "O");
            openParams.Add("doctor_id", UserInfo.UserID);
            openParams.Add("fk_io_key", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "OCSA", "OCSAPPROVE", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ParentTopLeft, openParams);
        }

        //modify bu jc CPL0000Q00 -> CPL0000Q01
        private void OpenScreen_CPL0000Q01(string aBunho)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", aBunho);
            openParams.Add("send_yn", "Y");
            openParams.Add("close_yn", "Y");

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q01", ScreenOpenStyle.PopUpFixed, openParams);

            //CommonItemCollection openParam = new CommonItemCollection();

            //openParam.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_INJ0000Q00(string aBunho)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "INJS", "INJ0000Q00", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ParentTopLeft, openParam);
        }

        private void OpenScreen_OCS1003Q05(string aBunho, string aOrderDate)
        {
            //CommonItemCollection openParam = new CommonItemCollection();

            //openParam.Add("bunho", aBunho);
            //openParam.Add("order_date", aOrderDate);

            //XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.ResponseFixed, openParam);

            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            openParams.Add("gwa", mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
            openParams.Add("doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

            openParams.Add("naewon_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", false);
            openParams.Add("input_tab", "%");
            openParams.Add("io_gubun", this.IO_Gubun);

            openParams.Add("childYN", "N");

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q05", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS1003Q02(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("naewon_date", aNaewonDate);
            param.Add("doctor", aDoctor);
            param.Add("gwa", aGwa);
            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q02", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_ScanViewer(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            //XScreen.OpenScreenWithParam(this, "CPLS", "SCANVIEWER", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, param);
            XScreen.OpenScreenWithParam(this, "CPLS", "CPL0000Q00", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_XRT0000Q00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT0000Q00", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ParentTopLeft, param);
        }

        private void OpenScreen_NUR7001U00(string aBunho)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);

            XScreen.OpenScreenWithParam(this, "NURI", "NUR7001U00", ScreenOpenStyle.ResponseFixed, param);
            GetPatientInfo(true);
            OCS2015U01BindData();
        }

        private void OpenScreen_RES1001U00(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("naewon_date", aNaewonDate);

            param.Add("gwa", aGwa);
            param.Add("doctor", aDoctor);

            XScreen.OpenScreenWithParam(this, "NURO", "RES1001U00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_DRG2010R00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("pkout1001", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            XScreen.OpenScreenWithParam(this, "DRGS", "DRG2010R00", ScreenOpenStyle.ResponseFixed, param);
        }

        private void OpenScreen_CPL2010R02(string aBunho, string aOrderDate, string aInOutGubun, string aGwa,
            string aDoctor, string aSpecimen_code, string aAutoPrintYN, string aHopeDate)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", aBunho);
            param.Add("order_date", aOrderDate);
            param.Add("in_out_gubun", aInOutGubun);
            param.Add("gwa", aGwa);
            param.Add("doctor", aDoctor);
            param.Add("specimen_code", aSpecimen_code);
            param.Add("auto_print_yn", aAutoPrintYN);
            param.Add("hope_date", aHopeDate);

            XScreen.OpenScreenWithParam(this, "CPLS", "CPL2010R02", ScreenOpenStyle.ResponseFixed, param);
        }

        #endregion

        #region [ 각종 초기화 ]

        // 화면 초기화
        private void InitializeScreen(bool aIsCalledbyOpenning)
        {
            // 모드 설정 ( 의사가 로긴한건지, 의사가 아닌 다른사람들이 로긴한건지 판단 )
            //if (UserInfo.UserGubun == UserType.Doctor && 
            //    ( EnvironInfo.CurrSystemID  == "OCSO" || EnvironInfo.CurrSystemID == "OCSI") )
            //if (UserInfo.UserGubun == UserType.Doctor)
            //{
            //    this.mDoctorLogin = true;
            //}
            //else
            //{
            //    this.mDoctorLogin = false;
            //}

            // 유저의 구분에 따라 보이거나 사라져야 할 로직들...
            pendingPatient.PatientBox.SettingVisiblebyUser();


            // 다른 화면에서 오픈된경우
            if (this.OpenParam != null)
            {
                mIsCalledbyOtherScreen = true;
                // 내원 일자 
                if (this.OpenParam.Contains("naewon_date"))
                {
                    pendingPatient.PatientBox.DtpNaewonDate.SetDataValue(this.OpenParam["naewon_date"].ToString());
                }
                else
                {
                    pendingPatient.PatientBox.DtpNaewonDate.SetDataValue( /*EnvironInfo.GetSysDate()*/
                        _sysDate.ToString("yyyy/MM/dd").Replace("-", "/"));
                }

                // 환자번호
                if (this.OpenParam.Contains("bunho"))
                {
                    this.mParamBunho = this.OpenParam["bunho"].ToString();
                    // 환자번호 셋팅후
                    //this.fbxBunho.SetEditValue(this.OpenParam["bunho"].ToString());
                    //this.fbxBunho.AcceptData();
                }

                // 내원 키
                if (this.OpenParam.Contains("naewon_key"))
                {
                    this.mParamNaewonKey = this.OpenParam["naewon_key"].ToString();
                }

                // 진료과
                if (this.OpenParam.Contains("gwa"))
                {
                    this.mParamGwa = this.OpenParam["gwa"].ToString();
                }

                // 진료의
                if (this.OpenParam.Contains("doctor"))
                {
                    this.mParamDoctor = this.OpenParam["doctor"].ToString();
                }

                // 프로텍트 해야지...파라미터로 담은거니깐...
                //pendingPatient.PatientBox.DtpNaewonDate.Protect = true;
                //this.fbxBunho.Protect = true;
            }
            // 독자적 실행
            else
            {
                // 내원일자 디폴트는 오늘로
                pendingPatient.PatientBox.DtpNaewonDate.SetDataValue( /*EnvironInfo.GetSysDate()*/
                    _sysDate.ToString("yyyy/MM/dd").Replace("-", "/"));

                this.InitializeBunho(aIsCalledbyOpenning);

                // 이건 여기서 이ㅣㅂ력받을 수 있으니깐 프로텍트 하면 안되요...
                pendingPatient.PatientBox.DtpNaewonDate.Protect = false;
                this.fbxBunho.Protect = false;

            }
            try
            {
                // 진료과 콤보 구성
                pendingPatient.PatientBox.ReLoadGwaCombo(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());

                // 2015.11.30 AnhNV removes unnecessary codes to increase load performance
                // 주치의 콤보 구성
                pendingPatient.PatientBox.ReLoadDoctorCombo(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(),
                pendingPatient.PatientBox.CboQryGwa.GetDataValue());

                // 내원자 리스트 조회
                //pendingPatient.PatientBox.PatientListQuery(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(),
                //    pendingPatient.PatientBox.CboQryGwa.GetDataValue(),
                //    pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
            }
            catch
            {
            }
            finally
            {
                // InputGubun 탭 구성
                this.MakeInputGubunTab();



                // 혹시 다른 스크린에서 받아올수 있는지 판단.
                // 이전 스크린의 등록번호를 가져온다
                if (this.mParamBunho == "")
                {
                    XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                    if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                    {
                        // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                        patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                    }

                    if (patientInfo != null && !TypeCheck.IsNull(patientInfo.BunHo))
                    {
                        this.mParamBunho = patientInfo.BunHo;
                    }
                }

                // 다른화면에서 파라미터로 받던, 혹은 이전스크린에서 가져오던 
                // 환자번호를 받은경우는 적용한다.
                if (this.mParamBunho != "")
                {
                    this.fbxBunho.Focus();
                    this.fbxBunho.SetEditValue(this.mParamBunho);
                    this.fbxBunho.AcceptData();
                }
            };
        }

        private bool IsFirstLoad
        {
            get
            {
                return this.fbxBunho.GetDataValue() == "" || this.mSelectedPatientInfo == null
                       || this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "";
            }
        }

        // 환자번호 초기화시 설정파일
        internal void InitializeBunho(bool aIsCalledbyOpening)
        {
            //ClearPatientInfoLabel();
            this.InitPatientprofile();
            this.mSelectedPatientInfo.ClearPatientInfo();

            this.fbxBunho.SetDataValue("");
            //insert by jc
            this.cboOutSang.ComboItems.Clear();
            this.cboOutSang.RefreshComboItems();

            this.cboJinryoGwa.ComboItems.Clear();
            this.cboJinryoGwa.RefreshComboItems();

            this.paInfoBox.Reset();

            // 각종 YN 클리어 ( 껌뻑이는 컨트롤 )
            this.pbxIsNoAnwerOfConsulted.Visible = false;
            this.pbxExistBunhoComment.Visible = false;
            this.pbxInpReserYN.Visible = false;
            this.pbxEtcJinryo.Visible = false;
            this.pbxVital.Visible = false;
            this.pbxJinryoComment.Visible = false;
            this.pbxExistAllergy.Visible = false;
            this.pbxIsNoConfirmOfReturnedConsult.Visible = false;

            // 코맨트 창 visible flase 
            //this.pnlComment.Visible = false;

            if (!IsFirstLoad)
            {
                this.InitializeOrderInfo();
            }

            if (aIsCalledbyOpening == false)
            {
                this.mParamNaewonKey = "";
            }

            XRadioButton inputtab;
            foreach (Control ctl in OrderBox.PnlInputTab.Controls)
            {
                if (ctl is XRadioButton)
                {
                    inputtab = ctl as XRadioButton;

                    if (inputtab.Checked)
                    {
                        inputtab.ForeColor = this.mSelectedForeColor;
                    }
                    else
                    {
                        inputtab.ForeColor = this.mUnSelectedForeColor;
                    }
                }
            }
        }

        // 오더 및 상병정보 초기화
        private void InitializeOrderInfo()
        {
            //todo Performance (Load - AnhLT)
            /*//Old code
            OrderBox.GrdOrder_Drug.Reset();
            OrderBox.GrdOrder_Jusa.Reset();
            OrderBox.GrdOrder_Cpl.Reset();
            OrderBox.GrdOrder_Pfe.Reset();
            OrderBox.GrdOrder_Apl.Reset();
            OrderBox.GrdOrder_Xrt.Reset();
            OrderBox.GrdOrder_Chuchi.Reset();
            OrderBox.GrdOrder_Susul.Reset();
            OrderBox.GrdOrder_Etc.Reset();
            OrderBox.GrdOrder_Reha.Reset();*/
            // grdOrder_XXXクリア
            if (OrderBox.GrdOrder_Drug.RowCount > 0)
                OrderBox.GrdOrder_Drug.Reset();
            if (OrderBox.GrdOrder_Jusa.RowCount > 0)
                OrderBox.GrdOrder_Jusa.Reset();
            if (OrderBox.GrdOrder_Cpl.RowCount > 0)
                OrderBox.GrdOrder_Cpl.Reset();
            if (OrderBox.GrdOrder_Pfe.RowCount > 0)
                OrderBox.GrdOrder_Pfe.Reset();
            if (OrderBox.GrdOrder_Apl.RowCount > 0)
                OrderBox.GrdOrder_Apl.Reset();
            if (OrderBox.GrdOrder_Xrt.RowCount > 0)
                OrderBox.GrdOrder_Xrt.Reset();
            if (OrderBox.GrdOrder_Chuchi.RowCount > 0)
                OrderBox.GrdOrder_Chuchi.Reset();
            if (OrderBox.GrdOrder_Susul.RowCount > 0)
                OrderBox.GrdOrder_Susul.Reset();
            if (OrderBox.GrdOrder_Etc.RowCount > 0)
                OrderBox.GrdOrder_Etc.Reset();
            if (OrderBox.GrdOrder_Reha.RowCount > 0)
                OrderBox.GrdOrder_Reha.Reset();

            // 상병그리드 클리어
            if (this.grdOutSang.RowCount > 0)
                this.grdOutSang.Reset();

            // 상병 콤보박스 클리어
            this.cboOutSang.ComboItems.Clear();
            this.cboJinryoGwa.ComboItems.Clear();
            // 오더정보 클리어
            try
            {
                this.ClearOrderData();
                OrderBox.DwOrderInfo.Reset();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }

            if (this.layDeletedData.RowCount > 0)
                this.layDeletedData.Reset();

            if (this.layDisplayLayout.RowCount > 0)
                this.layDisplayLayout.Reset();

            if (this.layDrugOrder.RowCount > 0)
                this.layDrugOrder.Reset();

        }

        // 입력탭 라디오 동적 구성
        private void MakeInputTab()
        {

            float PnlInputTabWith = Size.Width - tabGroupButton.Size.Width;
             //2015.11.30 AnhNV caching to increase load performance
            //MultiLayout dtLayout = this.mOrderBiz.LoadComboDataSource("code", "INPUT_TAB");
            //OcsEMRLoadComboInputTabResult res = CacheService.Instance.Get<OcsEMRLoadComboInputTabArgs, OcsEMRLoadComboInputTabResult>(new OcsEMRLoadComboInputTabArgs(),
            //    delegate(OcsEMRLoadComboInputTabResult r)
            //    {
            //        return r.ExecutionStatus == ExecutionStatus.Success && r.CboItem.Count > 0;
            //    });
            OcsEMRLoadComboInputTabArgs args = new OcsEMRLoadComboInputTabArgs();
            OcsEMRLoadComboInputTabResult res = CloudService.Instance.Submit<OcsEMRLoadComboInputTabResult, OcsEMRLoadComboInputTabArgs>(args, true);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.CboItem.Count > 0)
            {
                XRadioButton rbnButton;

                int rowCount = 0;

                // 기존 내역삭제
                foreach (Control control in OrderBox.PnlInputTab.Controls)
                {
                    if (control is XRadioButton)
                    {
                        OrderBox.PnlInputTab.Controls.Remove(control);
                    }
                }

                int count = 0;

                //if (dtLayout.RowCount > 0)
                if (res.CboItem.Count > 0)
                {
                    //insert by jc rbnButtonを作る前にまずクリアしてから作る。 START
                    OrderBox.PnlInputTab.Controls.Clear();
                    OrderBox.PnlInputTab.Height = 35;
                    OrderBox.PnlInputTab.Controls.Add(OrderBox.BtnExpand);                    
                    //insert by jc rbnButtonを作る前にまずクリアしてから作る。 END
                    // 화면 끝 체크
                    if ((OrderBox.PnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) <
                        this.mInputTabDefaultWidth)
                    //if ((OrderBox.PnlInputTab.Size.Width - this.mInputTabDefaultXLoc - (this.mInputTabDefaultWidth * count)) <
                    //    (this.mInputTabDefaultWidth * 3 * count))
                    {
                        rowCount++;
                        OrderBox.PnlInputTab.Size = new Size(OrderBox.PnlInputTab.Size.Width,
                            OrderBox.PnlInputTab.Height + this.mInputTabDefaultHeight);
                        count = 0;
                    }

                    rbnButton = new XRadioButton();

                    rbnButton.Text = Resources.RBN_BUTTON_TEXT;
                    /*rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);*/
                    rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                    rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)),
                        this.mInputTabDefaultYLoc + (this.mInputTabDefaultHeight * rowCount));
                    rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                    //rbnButton.Font = new Font("MS UI Gothic", (float)8.75, FontStyle.Bold);
                    rbnButton.Font = new Font("Arial", (float)8.75, FontStyle.Bold);
                    rbnButton.Appearance = Appearance.Button;
                    rbnButton.ImageList = this.ImageList;
                    rbnButton.ImageIndex = 4;
                    rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                    rbnButton.BackColor = this.mUnSelectedBackColor;
                    rbnButton.ForeColor = this.mUnSelectedForeColor;
                    rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);
                    //if(rbnButton.Checked) _isCheckDataExist = true 
                    rbnButton.Tag = "%";

                    OrderBox.PnlInputTab.Controls.Add(rbnButton);

                    count++;

                }

                //foreach (DataRow dr in dtLayout.LayoutTable.Rows)
                foreach (ComboListItemInfo item in res.CboItem)
                {
                    //insert by jc
                    //if (dr["code_name"].ToString() != "複合")
                    if (item.CodeName != "複合")
                    {
                        // 화면 끝 체크
                        //if ((OrderBox.PnlInputTab.Size.Width - this.mInputTabDefaultXLoc -
                        //     (this.mInputTabDefaultWidth * count)) < this.mInputTabDefaultWidth)
                        //Parent.Size.Width
                          //if ((OrderBox.PnlInputTab.Size.Width - this.mInputTabDefaultXLoc -
                          //     (this.mInputTabDefaultWidth * count)) < (this.mInputTabDefaultWidth * 3))
                        if ((PnlInputTabWith - this.mInputTabDefaultXLoc -
                             (this.mInputTabDefaultWidth * count)) < (this.mInputTabDefaultWidth))
                        {
                            rowCount++;
                            OrderBox.PnlInputTab.Size = new Size(OrderBox.PnlInputTab.Size.Width,
                                OrderBox.PnlInputTab.Height + this.mInputTabDefaultHeight);
                            count = 0;
                        }

                        rbnButton = new XRadioButton();

                        //rbnButton.Text = dr["code_name"].ToString();
                        rbnButton.Text = item.CodeName;
                        rbnButton.Size = new Size(this.mInputTabDefaultWidth, this.mInputTabDefaultHeight);
                        rbnButton.Location = new Point((this.mInputTabDefaultXLoc + (this.mInputTabDefaultWidth * count)),
                            this.mInputTabDefaultYLoc + (this.mInputTabDefaultHeight * rowCount));
                        rbnButton.TextAlign = ContentAlignment.MiddleCenter;
                        //rbnButton.Font = new Font("MS UI Gothic", (float)8.75, FontStyle.Bold);
                        rbnButton.Font = new Font("Arial", (float)8.75, FontStyle.Bold);
                        rbnButton.Appearance = Appearance.Button;
                        rbnButton.ImageList = this.ImageList;
                        rbnButton.ImageIndex = 4;
                        rbnButton.ImageAlign = ContentAlignment.MiddleLeft;

                        rbnButton.BackColor = this.mUnSelectedBackColor;
                        rbnButton.ForeColor = this.mUnSelectedForeColor;
                        rbnButton.CheckedChanged += new EventHandler(rbnOrder_CheckedChanged);

                        //rbnButton.Tag = dr["code"].ToString();
                        rbnButton.Tag = item.Code;

                        OrderBox.PnlInputTab.Controls.Add(rbnButton);

                        count++;
                    }
                }

                // 전체를 체크해 놓는다.
                foreach (Control control in OrderBox.PnlInputTab.Controls)
                {
                    if (control is XRadioButton && control.Tag.ToString() == "%")
                    {
                        ((XRadioButton)control).Checked = true;
                    }
                }

            }
        }

        // 입력구분 탭 동적 구성 
        private void MakeInputGubunTab()
        {
            MultiLayout mInputGubun = new MultiLayout();

            mInputGubun.LayoutItems.Add("code", DataType.String);
            mInputGubun.LayoutItems.Add("code_name", DataType.String);
            mInputGubun.InitializeLayoutTable();

            // 의사가 로긴한경우
            if (this.mDoctorLogin == true)
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A "
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE 'D0' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";

                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase1;
            }
            else if (EnvironInfo.CurrSystemID == "NURO" || EnvironInfo.CurrSystemID == "NURI")
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A"
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE 'NR' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";
                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase2;
            }
            // 기타유저인경우
            else
            {
                //mInputGubun.QuerySQL = "SELECT A.CODE, A.CODE_NAME "
                //                     + "  FROM OCS0132 A"
                //                     + " WHERE A.CODE_TYPE  LIKE 'INPUT_GUBUN' "
                //                     + "   AND A.CODE       LIKE '" + this.mInputGubun + "' "
                //                     + "   AND A.HOSP_CODE  = '" + EnvironInfo.HospCode + "' "
                //                     + " ORDER BY A.SORT_KEY, A.CODE ";
                mInputGubun.ExecuteQuery = LoadDataMInputGubunCase3;
            }

            mInputGubun.QueryLayout(true);

            // 입력구분이 없는 유저가 등록된경우
            if (mInputGubun.RowCount <= 0)
            {
                this.mMsg = Resources.MSG014_MSG;
                this.mCap = Resources.MSG014_CAP;

                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (this.OpenParam != null)
                {
                    this.Close();
                    return;
                }
            }

            // 이벤트 삭제
            OrderBox.TabInputGubun.SelectionChanged -= new EventHandler(OrderBox.tabInputGubun_SelectionChanged);

            IHIS.X.Magic.Controls.TabPage tpgInputGubun;
            try
            {
                OrderBox.TabInputGubun.TabPages.Clear();
            }
            finally
            {
                OrderBox.TabInputGubun.Refresh();
            }

            foreach (DataRow dr in mInputGubun.LayoutTable.Rows)
            {
                if (this.mDoctorLogin)
                    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString());
                else
                    tpgInputGubun =
                        new IHIS.X.Magic.Controls.TabPage(dr["code_name"].ToString() + Resources.TGPINPUTGUBUN_TEXT);

                tpgInputGubun.Tag = dr["code"].ToString();
                tpgInputGubun.ImageList = this.ImageList;
                tpgInputGubun.ImageIndex = 4;

                OrderBox.TabInputGubun.TabPages.Add(tpgInputGubun);
            }

            //if (UserInfo.UserGubun != UserType.Doctor)
            //if (!this.mDoctorLogin)
            //{
            //    tpgInputGubun = new IHIS.X.Magic.Controls.TabPage("医師オーダ照会及び追加");
            //    tpgInputGubun.Tag = "D%";
            //    tpgInputGubun.ImageList = this.ImageList;
            //    tpgInputGubun.ImageIndex = 4;

            //    OrderBox.TabInputGubun.TabPages.Add(tpgInputGubun);
            //}

            OrderBox.TabInputGubun.SelectionChanged += new EventHandler(OrderBox.tabInputGubun_SelectionChanged);

            //OrderBox.tabInputGubun_SelectionChanged(OrderBox.TabInputGubun, new EventArgs());
        }

        private void InitializeSangGrid(XEditGrid aGrid, OCS.PatientInfo aPatientInfo, int aRow)
        {
            // 상병 그리드 new row 생성후 초기화
            // 초기화항목
            // bunho, gwa, io_gubun, naewon_date, jubsu_no, last_naewon_date, last_doctor, last_naewon_type, last_jubsu_no
            // fkinp1001, input_id, ju_sang_yn, sang_start_date

            //診療科名
            aGrid.SetItemValue(aRow, "gwa_name", aPatientInfo.GetPatientInfo["gwa"].ToString());
            // 환자번호
            aGrid.SetItemValue(aRow, "bunho", aPatientInfo.GetPatientInfo["bunho"].ToString());
            // 진료과
            aGrid.SetItemValue(aRow, "gwa", aPatientInfo.GetPatientInfo["gwa"].ToString());
            // IO_Gubun
            aGrid.SetItemValue(aRow, "io_gubun", this.IO_Gubun);
            // naewon_date
            aGrid.SetItemValue(aRow, "naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            // jubsu_no
            aGrid.SetItemValue(aRow, "jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            // last_naewon_date
            aGrid.SetItemValue(aRow, "last_naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            // last_doctor
            aGrid.SetItemValue(aRow, "last_doctor", aPatientInfo.GetPatientInfo["doctor"].ToString());
            // last_naewon_type 
            aGrid.SetItemValue(aRow, "last_naewon_type", aPatientInfo.GetPatientInfo["naewon_type"].ToString());
            ;
            // jubsu_no
            aGrid.SetItemValue(aRow, "last_jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            // 내원 혹은 입원 키
            if (this.IO_Gubun == "O")
            {
                aGrid.SetItemValue(aRow, "pkout1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
            else
            {
                aGrid.SetItemValue(aRow, "fkinp1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
            // input_id  (입력자 id)
            aGrid.SetItemValue(aRow, "input_id", UserInfo.UserID);
            // ju_sang_yn ( 주상병)
            aGrid.SetItemValue(aRow, "ju_sang_yn", "N");
            // 상병 시작일 ( 새로 입력이므로 내원일자를 집어넣자...)
            aGrid.SetItemValue(aRow, "sang_start_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());

            //inser by jc [診断日基本SETTINGは来院日]
            aGrid.SetItemValue(aRow, "sang_jindan_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());

        }

        private void ClearInputGubunColor()
        {
            foreach (IHIS.X.Magic.Controls.TabPage tpg in OrderBox.TabInputGubun.TabPages)
            {
                tpg.TitleTextColor = this.mNormalInputGubunColor.Color;
            }
        }

        #endregion

        #region [ 밸리데이팅 관련 ]

        //        private void Control_DataValidating(object sender, DataValidatingEventArgs e)
        //        {
        //            Control control = sender as Control;
        //            string bunho = "";
        //            object postCallArguments;

        //            switch (control.Name)
        //            {
        //                // 환자번호
        //                case "fbxBunho": // ★注意:TextBoxから直接入力される場合もあるので<< pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber >>使用禁止

        //                    // 스탠다드 번호로 변경 
        //                    bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
        //                    //bunho = e.DataValue;

        //                    #region 患者の診療科と今の診療科が違うと患者の診療科に合わせるように

        //                    string gwa = "";

        //                    // CurrentRowNumber 代わりに　DBから取得 単数・複数可能性あり
        //                    MultiLayout layPat = new MultiLayout();
        //                    layPat.LayoutItems.Add("gwa", DataType.String);
        //                    layPat.LayoutItems.Add("bunho", DataType.String);
        //                    layPat.LayoutItems.Add("doctor", DataType.String);
        //                    layPat.LayoutItems.Add("group_key", DataType.String);
        //                    layPat.LayoutItems.Add("naewon_yn", DataType.String);
        //                    layPat.LayoutItems.Add("login_doctor_yn", DataType.String);


        //                    layPat.InitializeLayoutTable();

        //                    layPat.QuerySQL = @"SELECT A.GWA, A.BUNHO, A.DOCTOR, B.GROUP_KEY, A.NAEWON_YN
        //                                          FROM OUT1001 A
        //                                              ,BAS0102 B
        //                                         WHERE A.HOSP_CODE         = :f_hosp_code
        //                                           AND SUBSTR(A.DOCTOR, 3) = SUBSTR(:f_doctor, 3)
        //                                           AND A.BUNHO             = :f_bunho
        //                                           AND A.NAEWON_DATE       = :f_naewon_date
        //                                           AND B.HOSP_CODE = A.HOSP_CODE
        //                                           AND B.CODE_TYPE = 'JUBSU_GUBUN'
        //                                           AND B.CODE      = A.JUBSU_GUBUN
        //                                           AND ((:f_login_doctor_yn = 'Y' AND B.GROUP_KEY = '1') OR (:f_login_doctor_yn = 'N'))
        //                                    ";

        //                    layPat.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //                    layPat.SetBindVarValue("f_doctor", pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
        //                    layPat.SetBindVarValue("f_bunho", bunho);
        //                    layPat.SetBindVarValue("f_naewon_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
        //                    if (this.mDoctorLogin)
        //                        layPat.SetBindVarValue("f_login_doctor_yn", "Y");
        //                    else
        //                        layPat.SetBindVarValue("f_login_doctor_yn", "N");

        //                    layPat.QueryLayout(false);

        //                    if (this.mPatientDoubleClick)
        //                    {
        //                        pendingPatient.PatientBox.CboQryGwa.SetDataValue(pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "gwa"));
        //                    }
        //                    else if (layPat.RowCount == 1)
        //                    {
        //                        gwa = layPat.GetItemString(0, "gwa");
        //                        if (gwa != pendingPatient.PatientBox.CboQryGwa.GetDataValue())
        //                            pendingPatient.PatientBox.CboQryGwa.SetDataValue(gwa);
        //                    }

        //                    //else if (layPat.RowCount > 1)
        //                    //{
        //                    //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
        //                    //    return;
        //                    //}
        //                    //else if (pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber > -1 && pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "gwa") != pendingPatient.PatientBox.CboQryGwa.GetDataValue())
        //                    //{
        //                    //    pendingPatient.PatientBox.CboQryGwa.SetDataValue(pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "gwa"));
        //                    //}

        //                    //else if (pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
        //                    //{

        //                    //}


        //                    //if (pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber > -1 && pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "gwa") != pendingPatient.PatientBox.CboQryGwa.GetDataValue())
        //                    //    pendingPatient.PatientBox.CboQryGwa.SetDataValue(pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "gwa"));

        //                    #endregion

        //                    #region 환자번호 벨리데이팅 서비스

        //                    // 내원일자 입력체크
        //                    if (pendingPatient.PatientBox.DtpNaewonDate.GetDataValue() == "")
        //                    {
        //                        this.mMsg = "先に来院日付を入力して下さい。";
        //                        this.mCap = "来院日付確認";

        //                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                        this.SetMsg(this.mMsg, MsgType.Error);

        //                        return;
        //                    }

        //                    // 이전데이터 저장여부
        //                    if (this.IsOrderDataModifed() == true)
        //                    {
        //                        // 저장안된 데이터 있다. 저장한다.
        //                        // 저장여부는 내부에서 판단.
        //                        this.btnList.PerformClick(FunctionType.Update);
        //                    }

        //                    // 번호 변경시의 초기화
        //                    this.InitializeBunho(false);

        //                    if (e.DataValue == "")
        //                    {
        //                        this.InitializeBunho(false);
        //                        this.SetMsg("");

        //                        return;
        //                    }



        //                    // 각종체크 들어가 주시고....
        //                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //                    // 환자정보 로드해 봅시다....
        //                    // 파라미터 셋팅
        //                    this.mPatientInfoParam.NaewonDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
        //                    this.mPatientInfoParam.NaewonKey = TypeCheck.NVL(this.mClickedNaewonKey, this.mParamNaewonKey).ToString();
        //                    // 최초 로그인시 의사이ㅣㄴ경우 doctor combo 구성후 해당 의사로 셋팅해 놓고 안보이게 함.
        //                    // 따라서 그 의사만 계혹 설정될꺼고
        //                    // 의사가 아니면 콤보 박스가 변경이 가능할꺼고...
        //                    this.mPatientInfoParam.InputID = pendingPatient.PatientBox.CboQryDoctor.GetDataValue();
        //                    this.mPatientInfoParam.Gwa = pendingPatient.PatientBox.CboQryGwa.GetDataValue();
        //                    this.mPatientInfoParam.Doctor = pendingPatient.PatientBox.CboQryDoctor.GetDataValue();

        //                    this.mPatientInfoParam.ApproveDoctor = pendingPatient.PatientBox.CboQryDoctor.GetDataValue();

        //                    this.mPatientInfoParam.IOEGubun = "O"; // 외래 
        //                    this.mPatientInfoParam.Bunho = bunho;
        //                    this.mPatientInfoParam.IsEnableIpwonReser = true;


        //                    this.mSelectedPatientInfo.Parameter = this.mPatientInfoParam;

        //                    //mGroup_key初期化
        //                    this.mGroup_key = "";

        //                    if (this.mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo) == false)
        //                    {
        //                        this.mMsg = "オーダ権限がありません｡";
        //                        this.mCap = "患者番号確認";

        //                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                        this.SetMsg(this.mMsg, MsgType.Error);

        //                        postCallArguments = new Hashtable();

        //                        ((Hashtable)postCallArguments).Add("success_yn", "N");
        //                        ((Hashtable)postCallArguments).Add("bunho", bunho);

        //                        PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

        //                        return;
        //                    }
        //                    else
        //                    {
        //                        if (this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString() != pendingPatient.PatientBox.CboQryGwa.GetDataValue())
        //                            pendingPatient.PatientBox.CboQryGwa.SetDataValue(this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

        //                        if (this.mPatientDoubleClick)
        //                        {
        //                            this.mGroup_key = pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "group_key");
        //                        }
        //                        else if (layPat.RowCount == 1)
        //                        {
        //                            this.mGroup_key = layPat.GetItemString(0, "group_key");
        //                        }
        //                        else if (this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() != "")
        //                        {
        //                            string cmd = @"SELECT B.GROUP_KEY
        //                                          FROM OUT1001 A
        //                                              ,BAS0102 B
        //                                         WHERE A.HOSP_CODE  = '" + EnvironInfo.HospCode + @"'
        //                                           AND A.PKOUT1001  = '" + this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString() + @"'
        //                                           AND B.HOSP_CODE  = A.HOSP_CODE
        //                                           AND B.CODE_TYPE  = 'JUBSU_GUBUN'
        //                                           AND B.CODE       = A.JUBSU_GUBUN
        //                                           
        //                                    ";
        //                            object obj = Service.ExecuteScalar(cmd);
        //                            this.mGroup_key = obj.ToString();
        //                        }
        //                        //else if (layPat.RowCount > 1)
        //                        //{
        //                        //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
        //                        //    return;
        //                        //}
        //                        //else if (pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber == -1 && e.DataValue != "")
        //                        //    this.mGroup_key = pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "group_key");
        //                    }


        //                    if (this.mClickedNaewonKey != "")
        //                    {
        //                        this.mClickedNaewonKey = "";
        //                    }

        //                    if (this.mParamNaewonKey != "")
        //                    {
        //                        this.mParamNaewonKey = "";
        //                    }

        //                    // 내원 체크 
        //                    if (this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() == "N")
        //                    {
        //                        if (MessageBox.Show(XMsg.GetMsg("M010"), XMsg.GetField("F001"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        //                        {
        //                            postCallArguments = new Hashtable();

        //                            ((Hashtable)postCallArguments).Add("success_yn", "N");
        //                            ((Hashtable)postCallArguments).Add("bunho", bunho);

        //                            PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

        //                            return;

        //                        }
        //                    }

        //                    // 재원환자 체크 
        //                    if (this.mOrderBiz.IsJaewonPatient(e.DataValue))
        //                    {
        //                        this.mMsg = "現在入院中の患者様です｡外来オーダは使用できません｡";
        //                        this.mCap = "患者番号確認";

        //                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                        this.SetMsg(this.mMsg, MsgType.Error);

        //                        postCallArguments = new Hashtable();

        //                        ((Hashtable)postCallArguments).Add("success_yn", "N");
        //                        ((Hashtable)postCallArguments).Add("bunho", bunho);

        //                        PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

        //                        return;
        //                    }

        //                    // 入院予約がある患者さんの場合、代行オーダーを入院オーダーにて登録するようにする。
        //                    if (UserInfo.Gwa == "CK")
        //                    {
        //                        string isInstead = "";
        //                        isInstead = this.mOrderBiz.isAbleInsteadOrder(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
        //                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
        //                                                            , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());

        //                        if (isInstead != "")
        //                        {
        //                            XMessageBox.Show(isInstead, "確認", MessageBoxIcon.Stop);
        //                            return;
        //                        }
        //                    }


        //                    // 기타 사항들 체크 및 visible 셋팅
        //                    this.CheckPatientEtcInfo(this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(), bunho
        //                                            , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

        //                    // 환자정보 라벨들 셋팅
        //                    this.SetPatientInfoLabel(this.mSelectedPatientInfo.GetPatientInfo);

        //                    // 환자정보 박스 기동
        //                    this.paInfoBox.SetPatientID(bunho);

        //                    #region Bind patient data to grdPatientInfo
        //                    if (this.MSelectedPatientInfo != null
        //                        && this.MSelectedPatientInfo.Parameter.Bunho != "")
        //                    {
        //                        #region Patient info
        //                        DataTable dtPatientInfo = new DataTable();
        //                        dtPatientInfo.Columns.Add("NAME", typeof(string));
        //                        dtPatientInfo.Columns.Add("VALUE", typeof(string));
        //                        if (IHIS.CloudConnector.CloudService.Instance.Connect())
        //                        {
        //                            IHIS.CloudConnector.Contracts.Arguments.Nuro.NuroManagePatientArgs paPersonInfoArgs = new CloudConnector.Contracts.Arguments.Nuro.NuroManagePatientArgs();
        //                            paPersonInfoArgs.PatientCode = this.MSelectedPatientInfo.Parameter.Bunho;
        //                            IHIS.CloudConnector.Contracts.Results.Nuro.NuroManagePatientResult paPersonInfoResult = IHIS.CloudConnector.CloudService.Instance.Submit<IHIS.CloudConnector.Contracts.Results.Nuro.NuroManagePatientResult, IHIS.CloudConnector.Contracts.Arguments.Nuro.NuroManagePatientArgs>(paPersonInfoArgs);
        //                            if (paPersonInfoResult.ExecutionStatus == CloudConnector.Contracts.Results.ExecutionStatus.Success)
        //                            {
        //                                if (paPersonInfoResult.LstManagePatientInfos.Count > 0)
        //                                {
        //                                    IHIS.CloudConnector.Contracts.Models.Nuro.NuroManagePatientInfo item = paPersonInfoResult.LstManagePatientInfos[0];
        //                                    DataRow dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Name 1";
        //                                    dr["VALUE"] = item.PatientName1;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Name 2";
        //                                    dr["VALUE"] = item.PatientName2;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Birthday";
        //                                    dr["VALUE"] = item.Birth;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Gender";
        //                                    dr["VALUE"] = item.Sex;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                }
        //                            }

        //                            IHIS.CloudConnector.Contracts.Arguments.Nuri.NuriNUR7001U00MeasurePhysicalConditionArgs paMeasureInfoArgs = new CloudConnector.Contracts.Arguments.Nuri.NuriNUR7001U00MeasurePhysicalConditionArgs();
        //                            paMeasureInfoArgs.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;
        //                            IHIS.CloudConnector.Contracts.Results.Nuri.NuriNUR7001U00MeasurePhysicalConditionResult paMeasureInfoResult = IHIS.CloudConnector.CloudService.Instance.Submit<IHIS.CloudConnector.Contracts.Results.Nuri.NuriNUR7001U00MeasurePhysicalConditionResult, IHIS.CloudConnector.Contracts.Arguments.Nuri.NuriNUR7001U00MeasurePhysicalConditionArgs>(paMeasureInfoArgs);
        //                            if (paMeasureInfoResult.ExecutionStatus == CloudConnector.Contracts.Results.ExecutionStatus.Success)
        //                            {
        //                                if (paMeasureInfoResult.MeasurePhysicalConditionListItem.Count > 0)
        //                                {
        //                                    IHIS.CloudConnector.Contracts.Models.Nuri.NuriNUR7001U00MeasurePhysicalConditionListItemInfo item = paMeasureInfoResult.MeasurePhysicalConditionListItem[0];
        //                                    DataRow dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Height";
        //                                    dr["VALUE"] = item.Height;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Weight";
        //                                    dr["VALUE"] = item.Weight;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Blood pressure H";
        //                                    dr["VALUE"] = item.BpTo;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Blood pressure L";
        //                                    dr["VALUE"] = item.BpTo;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Circuit";
        //                                    dr["VALUE"] = item.Pulse;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "SPO2";
        //                                    dr["VALUE"] = item.Spo2;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                    dr = dtPatientInfo.NewRow();
        //                                    dr["NAME"] = "Breathing rate";
        //                                    dr["VALUE"] = item.Breath;
        //                                    dtPatientInfo.Rows.Add(dr);
        //                                }
        //                            }
        //                            this.grdPatientInfo.DataSource = null;

        //                            this.grdPatientInfo.DataSource = dtPatientInfo;
        //                            this.grdPatientInfo.AutoResizeColumns();
        //                        }
        //                        #endregion

        //                        #region Examination history
        //                        this.tvExamHist.SetDataForTvExamHist(this.MSelectedPatientInfo.Parameter.Bunho, "K01", this.MSelectedPatientInfo.Parameter.Gwa);
        //                        this.cldExamDates.SetExaminedDates(tvExamHist);
        //                        this.ctlOCS2015U05.GetSpecialNoteList(this.MSelectedPatientInfo.Parameter.Bunho, this.MSelectedPatientInfo.Parameter.NaewonDate);


        //                        OCS2015U06EmrRecordArgs args = new OCS2015U06EmrRecordArgs();
        //                        args.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
        //                        args.HospCode = "K01";
        //                        if (CloudService.Instance.Connect())
        //                        {

        //                            OCS2015U06EmrRecordResult result =
        //                                CloudService.Instance.Submit<OCS2015U06EmrRecordResult, OCS2015U06EmrRecordArgs>(args);
        //                            if (result.ExecutionStatus == ExecutionStatus.Success)
        //                            {
        //                                foreach (OCS2015U06EmrRecordInfo info in result.EmrRecordList)
        //                                {
        //                                    JsonSerializerSettings settings = new JsonSerializerSettings();
        //                                    settings.TypeNameHandling = TypeNameHandling.Objects;
        //                                    List<CustomMarkSchema> emrMeta = info.Metadata == null || info.Metadata.Trim().Length == 0 ? new List<CustomMarkSchema>() :
        //                                        Newtonsoft.Json.JsonConvert.DeserializeObject<List<CustomMarkSchema>>(
        //                                            info.Metadata, settings);
        //                                    ctlEmrDocker.Viewer.LoadMeta(emrMeta, info.Content);
        //                                }
        //                            }
        //                        }

        //                        this.ctlOCS2015U07.GetProblemList(this.mSelectedPatientInfo.Parameter.Bunho);
        //                        #endregion
        //                    }
        //                    #endregion


        //                    postCallArguments = new Hashtable();
        //                    ((Hashtable)postCallArguments).Add("success_yn", "Y");
        //                    ((Hashtable)postCallArguments).Add("bunho", bunho);

        //                    PostCallHelper.PostCall(new PostMethodObject(PostBunhoValidating), postCallArguments);

        //                    #endregion

        //                    //insert by jc [患者を選択する際、InputTabの初期化（全体）するように] 2012/03/13
        //                    // 전체를 체크해 놓는다.
        //                    foreach (Control inputTabcontrol in OrderBox.PnlInputTab.Controls)
        //                    {
        //                        if (inputTabcontrol is XRadioButton && inputTabcontrol.Tag.ToString() == "%")
        //                        {
        //                            ((XRadioButton)inputTabcontrol).Checked = true;
        //                        }
        //                    }
        //                    //inser by jc [診療保留、診療保留取消の切り替えのため] 2012/09/08
        //                    pendingPatient.PatientBox.SettingVisiblebyUser();

        //                    // 未承認オーダーがあれば承認画面POPUP 無ければDOオーダーPOPUP
        //                    if (this.mDoctorLogin && this.mOrderBiz.GetNotApproveOrderCnt(IO_Gubun, UserInfo.UserID, "Y", "N", this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()) > 0)
        //                    {
        //                        this.btnApprove.PerformClick();
        //                    }
        //                    else
        //                    {
        //                        // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
        //                        if (this.mPatientDoubleClick)
        //                        {
        //                            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
        //                            && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString()) > 0
        //                            && pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "naewon_yn") != "E")
        //                            {
        //                                this.btnDoOrder.PerformClick();
        //                            }
        //                        }
        //                        else if (layPat.RowCount == 1)
        //                        {
        //                            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
        //                            && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString()) > 0
        //                            && layPat.GetItemString(0, "naewon_yn") != "E")
        //                            {
        //                                this.btnDoOrder.PerformClick();
        //                            }
        //                        }
        //                        else if (this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "")
        //                        {
        //                            if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
        //                            && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString()) > 0
        //                            && this.mSelectedPatientInfo.GetPatientInfo["naewon_yn"].ToString() != "E")
        //                            {
        //                                this.btnDoOrder.PerformClick();
        //                            }
        //                        }
        //                    }
        //                    //else if (layPat.RowCount > 1)
        //                    //{
        //                    //    XMessageBox.Show("選択した患者の複数の診療科が存在します。直接画面から患者を選んでください。", "注意");
        //                    //    return;
        //                    //}

        //                    this.mPatientDoubleClick = false;
        //                    //if (pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber > -1)
        //                    //{
        //                    //    if (this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "DO_ORDER_POP_YN", this.IO_Gubun) != "N"
        //                    //        && this.mOrderBiz.GetOrderCount(this.IO_Gubun, bunho, pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString()) > 0
        //                    //        && pendingPatient.PatientBox.GrdPatientList.GetItemString(pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "naewon_yn") != "E")
        //                    //    {
        //                    //        this.btnDoOrder.PerformClick();
        //                    //    }
        //                    //}

        //                    //患者選択時傷病リストが拡張されてる状態に見せる。2013/04/29
        //                    if (!this.mIsExpandedSB)
        //                        this.btnExpandSB.PerformClick();

        //                    OrderBox.GrdReserOrderList.QueryLayout(false);

        //                    this.mPostApproveYN = this.mOrderBiz.getEnablePostApprove("I", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());

        //                    if (this.mPostApproveYN)
        //                        this.lblApproveFlag.Text = "事後";
        //                    else
        //                        this.lblApproveFlag.Text = "事前";

        //                    break;

        //                // 내원일자
        //                case "dtpNaewonDate":

        //                    #region 내원일자 벨리데이팅

        //                    if (e.DataValue != "" && this.mDoctorLogin == false)
        //                    {
        //                        // 진료과 콤보 재조회
        //                        pendingPatient.PatientBox.ReLoadGwaCombo(e.DataValue);

        //                        // 의사 콤보 재조회
        //                        pendingPatient.PatientBox.ReLoadDoctorCombo(e.DataValue, pendingPatient.PatientBox.CboQryGwa.GetDataValue());
        //                    }

        //                    // 내원자 리스트 조회
        //                    pendingPatient.PatientBox.PatientListQuery(e.DataValue, pendingPatient.PatientBox.CboQryGwa.GetDataValue(), pendingPatient.PatientBox.CboQryDoctor.GetDataValue());

        //                    this.InitializeBunho(false);

        //                    #endregion

        //                    break;
        //            }
        //        }

        #endregion

        #region [ Post 이벤트 메소드들... ]

        /// <summary>
        /// 환자번호 벨리데이팅 후 타게되는 메소드
        /// </summary>
        /// <param name="aArguments">Hashtable : [success_yn]  벨리데이션 성공여부, [bunho] 9자리 환자번호 </param>
        internal void PostBunhoValidating(object aArguments)
        {
            try
            {
                Hashtable arguments = aArguments as Hashtable;

                if (arguments["success_yn"].ToString() != "Y")
                {

                    this.fbxBunho.SetDataValue("");

                    this.InitializeBunho(false);
                }
                else
                {
                    this.fbxBunho.SetDataValue(arguments["bunho"].ToString());

                    // EMR 기동
                    // insert by jc [使用者オプションによる表示・非表示] 2013/03/30
                    if (this.mIsCalledbyOtherScreen == false && this.cbxOpenEmr.Checked)
                        this.btnEMR.PerformClick();

                    //if (this.cbxOpenEmr.Checked && this.mIsCalledbyOtherScreen == false)
                    // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                    //if (this.cbxOpenEmr.Checked && this.mIsCalledbyOtherScreen == false && this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "EMR_POP_YN", this.IO_Gubun) != "N")
                    //{
                    //    this.btnEMR.PerformClick();
                    //}

                    // 오더정보조회 OPEN
                    //if (this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() != "E" && this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() != "H")
                    //    this.btnQryOrderInfo.PerformClick();

                    // 오늘 측정한 바이탈 정보가 있으면 창을 띄운다.
                    //if (this.pbxVital.Visible && this.mDoctorLogin && this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() == "Y")
                    // insert by jc [使用者オプションによる表示・非表示] 2012/09/24
                    if (this.pbxVital.Visible && this.mDoctorLogin &&
                        this.mSelectedPatientInfo.GetPatientInfo["real_naewon_yn"].ToString() == "Y"
                        &&
                        /*this.mOrderBiz.GetUserOption(UserInfo.UserID, UserInfo.Gwa, "VITALSIGNS_POP_YN", this.IO_Gubun) != "N"*/
                        UserOptions.VitalsignsPopYn == "Y")
                    {
                        this.btnVital.PerformClick();
                    }

                    //todo Performance (Load Patient - AnhLT)
                    ResetOrderGrid();
                    _isPostLoad = true;
                    this.btnList.PerformClick(FunctionType.Query);
                    //SetEnableBtnList(EnableBtnList);
                    //if(EnableBtnList)
                    //CheckDoctorCanView();
                    //MED-9991 + MED-10011
                    if (MDoctorLogin)
                    {
                        SetEnableBtnList(EnableBtnList);
                        if (EnableBtnList)
                        {
                            CheckDoctorCanView();
                        }
                        btnENDOResult.Enabled = true;

                    }
                    //Set reference to main screen
                    DoButtonBusiness.MainScreen = this;
                }
            }
            catch (Exception ex)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show(ex.Message);
                /*throw;*/
                Service.WriteLog("Error of PostBunhoValidating(): " + ex.StackTrace);
            }
        }

        private void ResetOrderGrid()
        {
            /*
            //todo Performance (Load patient - AnhLT)
            //Old Code
            loadedGridModules.Clear();
            OrderBox.DrugControl.GrdOrder.Reset();
            OrderBox.UCOCS2015U11Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U12Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U13Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U14Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U15Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U16Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U17Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U18Control.GrdOrder.Reset();
            OrderBox.UCOCS2015U19Control.GrdOrder.Reset();*/

            if (loadedGridModules.Count > 0) loadedGridModules.Clear();
            if (OrderBox.DrugControl.GrdOrder.LayoutTable != null && OrderBox.DrugControl.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.DrugControl.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U11Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U12Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U13Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U14Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U15Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U16Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U17Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U18Control.GrdOrder.Reset();
            if (OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U19Control.GrdOrder.Reset();
        }
        private void OrderGridResetUpdate()
        {
            /*
            //todo Performance (Save AnhLT)
            //Old Code
            OrderBox.DrugControl.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U11Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U12Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U13Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U14Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U15Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U16Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U17Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U18Control.GrdOrder.ResetUpdate();
            OrderBox.UCOCS2015U19Control.GrdOrder.ResetUpdate();*/

            if (OrderBox.DrugControl.GrdOrder.LayoutTable != null && OrderBox.DrugControl.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.DrugControl.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U11Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U11Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U12Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U12Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U13Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U13Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U14Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U14Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U15Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U15Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U16Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U16Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U17Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U17Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U18Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U18Control.GrdOrder.ResetUpdate();
            if (OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable != null && OrderBox.UCOCS2015U19Control.GrdOrder.LayoutTable.Rows.Count > 0)
                OrderBox.UCOCS2015U19Control.GrdOrder.ResetUpdate();
        }
        #endregion

        #region [ Command ]

        public override object Command(string command, CommonItemCollection commandParam)
        {

            switch (command)
            {
                case "OUT0101":

                    if (commandParam != null)
                    {
                        this.fbxBunho.Focus();
                        this.fbxBunho.SetEditValue(((MultiLayout)commandParam[0]).GetItemString(0, "bunho"));
                        this.fbxBunho.AcceptData();
                    }

                    break;

                case "CHT0110Q01": // 상병 조회

                    #region 상병조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("CHT0110"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["CHT0110"], false);
                        }
                    }

                    #endregion

                    break;

                case "OCS0204Q00": // 사용자별 상병조회

                    #region 사용자별 상병조회

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS0205"))
                        {
                            this.ApplySangInfo(this.grdOutSang, (MultiLayout)commandParam["OCS0205"], true);
                        }
                    }

                    #endregion

                    break;

                case "CHT0115Q00":

                    #region 수식어

                    string display_sang_name = "";

                    if (commandParam != null)
                    {
                        this.grdOutSang.Focus();
                        this.grdOutSang.SetFocusToItem(this.grdOutSang.CurrentRowNumber, "sang_code");

                        foreach (XEditGridCell cell in grdOutSang.CellInfos)
                        {
                            if (((MultiLayout)commandParam["CHT0115"]).LayoutItems.Contains(cell.CellName))
                                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, cell.CellName,
                                    ((MultiLayout)commandParam["CHT0115"]).GetItemString(0, cell.CellName));
                        }

                        //display 상병명
                        display_sang_name =
                            this.mOrderBiz.GetDisplaySangName(
                                grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "pre_modifier_name"),
                                grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name"),
                                grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "post_modifier_name"));
                        grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                        grdOutSang.Refresh();

                        this.MakePatientSangCombo(this.grdOutSang.LayoutTable);

                        this.grdOutSang.AcceptData();
                    }

                    #endregion

                    break;

                case "OCS0103U10": // 약오더 화면
                    #region 약 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("drug_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["drug_order"]);
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U10, true);
                            }
                        }

                        if (commandParam.Contains("allWarning") && !String.IsNullOrEmpty(commandParam["allWarning"].ToString()))
                        {
                            this.allWarning = commandParam["allWarning"].ToString();
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U11": // リハビリ

                    #region リハビリ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("reha_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["reha_order"]);
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U11, true);
                            }
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U12": // 주사오더 화면

                    #region 주사 처방

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("jusa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["jusa_order"]);
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U12, true);
                            }
                        }

                        if (commandParam.Contains("allWarning") && !String.IsNullOrEmpty(commandParam["allWarning"].ToString()))
                        {
                            this.allWarning = commandParam["allWarning"].ToString();
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U13": // 검체검사오더

                    #region 검체검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("gumsa_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["gumsa_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U13, true);
                            }
                            if (!commandParam.Contains("open_popup") || (bool)commandParam["open_popup"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                           
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U14": // 생리검사오더

                    #region 생리검사오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("pfe_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["pfe_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U14, true);
                            }
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                           
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U15": // 병리검사오더

                    #region 병리검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("apl_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["apl_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U15, true);
                            }
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U16": // 방사선오더

                    #region 방사선검사

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("xrt_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["xrt_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U16, true);
                            }
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U17": // 처치오더

                    #region 처치 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("chuchi_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["chuchi_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U17, true);
                            }                            
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                            
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U18": // 수술오더

                    #region 수술 오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("susul_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["susul_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U18, true);
                            }
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                          
                        }
                    }

                    #endregion

                    break;

                case "OCS0103U19": // 기타오더

                    #region 기타오더

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("etc_order"))
                        {
                            this.RecieveAndSetOrderInfo(command, (XEditGrid)commandParam["etc_order"]);
                            if (popupGridOrderActive)
                            {
                                LoadOrderGrid(GridModule.OCS0103U19, true);
                            }
                            if (!commandParam.Contains("isOpenPopUp") || (bool)commandParam["isOpenPopUp"])
                                this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(), this.mCurrentInputTab);
                           
                        }
                    }

                    #endregion

                    break;

                case "INP1003U01": // 입원시 오더

                    #region 입원시 오더

                    this.pbxInpReserYN.Visible = false;

                    if (commandParam.Contains("pkinp1001") && commandParam["pkinp1001"] != null &&
                        commandParam.Contains("bunho") && commandParam["bunho"] != null)
                    {
                        this.OpenScreen_OCS2003P01(commandParam["bunho"].ToString(),
                            commandParam["reser_date"].ToString(), commandParam["pkinp1001"].ToString());
                    }

                    #endregion

                    break;

                case "OCS1003U01": // 반납 취소

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("retrieve"))
                        {
                            if (commandParam["retrieve"].ToString() == "Y")
                            {
                                _isPostLoad = true;
                                this.btnList.PerformClick(FunctionType.Query);
                            }
                        }
                    }

                    break;
                //insert by jc START
                case "OCS0301Q09":
                    if (commandParam.Contains("OCS0303"))
                    {

                        MultiLayout lyOCS0303 = new MultiLayout();

                        //this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                        lyOCS0303 = (MultiLayout)commandParam["OCS0303"];
                        int cntDupleSpeciment = 0;
                        /*
                        //todo Performance (Save - AnhLT)
                        //Old code
                        this.layDrugOrder_Do.Reset();
                        this.layJusaOrder_Do.Reset();
                        this.layCplOrder_Do.Reset();
                        this.layPfeOrder_Do.Reset();
                        this.layAplOrder_Do.Reset();
                        this.layXrtOrder_Do.Reset();
                        this.layChuchiOrder_Do.Reset();
                        this.laySusulOrder_Do.Reset();
                        // リハビリオーダ追加 2012/09/26
                        this.layRehaOrder_Do.Reset();
                        this.layEtcOrder_Do.Reset();*/

                        if (layDrugOrder_Do.RowCount > 0) this.layDrugOrder_Do.Reset();
                        if (layJusaOrder_Do.RowCount > 0) this.layJusaOrder_Do.Reset();
                        if (layCplOrder_Do.RowCount > 0) this.layCplOrder_Do.Reset();
                        if (layPfeOrder_Do.RowCount > 0) this.layPfeOrder_Do.Reset();
                        if (layAplOrder_Do.RowCount > 0) this.layAplOrder_Do.Reset();
                        if (layXrtOrder_Do.RowCount > 0) this.layXrtOrder_Do.Reset();
                        if (layChuchiOrder_Do.RowCount > 0) this.layChuchiOrder_Do.Reset();
                        if (laySusulOrder_Do.RowCount > 0) this.laySusulOrder_Do.Reset();
                        // リハビリオーダ追加 2012/09/26
                        if (layRehaOrder_Do.RowCount > 0) this.layRehaOrder_Do.Reset();
                        if (layEtcOrder_Do.RowCount > 0) this.layEtcOrder_Do.Reset();

                        //this.SetVisibleStatusBar(true);
                        //this.InitStatusBar(lyOCS1003.RowCount);
                        //this.SetStatusBar(0);

                        //[各部門毎にオーダを分ける]
                        foreach (DataRow dr in lyOCS0303.LayoutTable.Rows)
                        {
                            //this.SetInputGubunColor(dr["input_gubun"].ToString());
                            switch (dr["input_tab"].ToString())
                            {
                                case "01": // 내복약오더
                                    this.layDrugOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "03": // 주사오더
                                    this.layJusaOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "04": // 검체검사 오더
                                    //重複検査して重複除去
                                    if (!IsDupleSpeciment(dr))
                                    {
                                        this.layCplOrder_Do.LayoutTable.ImportRow(dr);
                                    }
                                    else
                                        cntDupleSpeciment++;

                                    break;

                                case "05": // 생리검사 오더
                                    this.layPfeOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "06": // 병리검사 오더
                                    this.layAplOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "07": // 방사선 오더
                                    this.layXrtOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "08": // 처치
                                    this.layChuchiOrder_Do.LayoutTable.ImportRow(dr);
                                    break;

                                case "09": // 마취 수술
                                    this.laySusulOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                                // リハビリオーダ追加 2012/09/26
                                case "10": // リハビリオーダ
                                    this.layRehaOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                                case "11": // 기타 오더
                                    this.layEtcOrder_Do.LayoutTable.ImportRow(dr);
                                    break;
                            }
                        }
                        //重複された検体検査オーダがあれば何件が重複されていて登録できなかったのかMSGで知らせる
                        if (cntDupleSpeciment > 0)
                        {
                            MessageBox.Show("重複された" + cntDupleSpeciment + "件のオーダは登録対象外としました。");
                        }
                        //insert by jc [通常]

                        if (UserInfo.Gwa == "CK")
                        {
                            if (this.mPostApproveYN)
                                iInputGubun = "D0";
                            else
                                iInputGubun = this.mInputGubun;
                        }
                        else
                        {
                            iInputGubun = OrderBox.TabInputGubun.SelectedTab.Tag.ToString();
                        }

                        //if (this.mDoctorLogin)
                        //    iInputGubun = OrderBox.TabInputGubun.SelectedTab.Tag.ToString();
                        //else
                        //    iInputGubun = this.mInputGubun;

                        this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun, ref this.iInputGubunName);
                        //[分けたオーダを架空する。]



                        //[group情報生成]

                        #region 薬

                        //[group情報生成]
                        if (this.layDrugOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "01";
                            this.INPUTTAB = "01";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layDrugOrder_Do, this.layDrugOrder, OrderBox.GrdOrder_Drug, "01", "OCS0103U10", "drug");
                            this.ApplyCopyOrderInfoDrug(this.layDrugOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Drug);
                            this.RecieveAndSetOrderInfo("OCS0103U10", OrderBox.GrdOrder_Drug);
                        }

                        #endregion

                        #region 注射

                        if (this.layJusaOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "03";
                            this.INPUTTAB = "03";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layJusaOrder_Do, this.layJusaOrder, OrderBox.GrdOrder_Jusa, "03", "OCS0103U12", "jusa");
                            this.ApplyCopyOrderInfoJusa(this.layJusaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Jusa);
                            this.RecieveAndSetOrderInfo("OCS0103U12", OrderBox.GrdOrder_Jusa);
                        }
                        // ToDo Kinki checking for getting set of orders on OCS0301Q09
                        KinkiChecking(GetSetOrder(layDrugOrder_Do, layJusaOrder_Do));
                        #endregion

                        #region 検体検査

                        if (this.layCplOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "04";
                            this.INPUTTAB = "04";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                            //MakeDoOrderGrouping2(this.layCplOrder_Do, this.layCplOrder, OrderBox.GrdOrder_Cpl, "04", "OCS0103U13", "cpl");
                            this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Cpl);
                            this.RecieveAndSetOrderInfo("OCS0103U13", OrderBox.GrdOrder_Cpl);

                        }

                        #endregion

                        #region 生理検査

                        if (this.layPfeOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "05";
                            this.INPUTTAB = "05";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layPfeOrder_Do, this.layPfeOrder, OrderBox.GrdOrder_Pfe, "05", "OCS0103U14", "pfe");
                            this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Pfe);
                            this.RecieveAndSetOrderInfo("OCS0103U14", OrderBox.GrdOrder_Pfe);
                        }

                        #endregion

                        #region 病理検査

                        if (this.layAplOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "06";
                            this.INPUTTAB = "06";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layAplOrder_Do, this.layAplOrder, OrderBox.GrdOrder_Apl, "06", "OCS0103U15", "apl");
                            this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Apl);
                            this.RecieveAndSetOrderInfo("OCS0103U15", OrderBox.GrdOrder_Apl);
                        }

                        #endregion

                        #region 放射線

                        if (this.layXrtOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "07";
                            this.INPUTTAB = "07";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layXrtOrder_Do, this.layXrtOrder, OrderBox.GrdOrder_Xrt, "07", "OCS0103U16", "xrt");
                            this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Xrt);
                            this.RecieveAndSetOrderInfo("OCS0103U16", OrderBox.GrdOrder_Xrt);
                        }

                        #endregion

                        #region 処置

                        if (this.layChuchiOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "08";
                            this.INPUTTAB = "08";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layChuchiOrder_Do, this.layChuchiOrder, OrderBox.GrdOrder_Chuchi, "08", "OCS0103U17", "chuchi");
                            this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Chuchi);
                            this.RecieveAndSetOrderInfo("OCS0103U17", OrderBox.GrdOrder_Chuchi);
                        }

                        #endregion

                        #region 手術

                        if (this.laySusulOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "09";
                            this.INPUTTAB = "09";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.laySusulOrder_Do, this.laySusulOrder, OrderBox.GrdOrder_Susul, "09", "OCS0103U18", "susul");
                            this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Susul);
                            this.RecieveAndSetOrderInfo("OCS0103U18", OrderBox.GrdOrder_Susul);
                        }

                        #endregion

                        // リハビリオーダ追加 2012/09/26
                        //#region リハビリ
                        if (this.layRehaOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "10";
                            this.INPUTTAB = "10";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Reha);
                            this.RecieveAndSetOrderInfo("OCS0103U11", OrderBox.GrdOrder_Reha);
                        }

        #endregion

                        #region その他

                        if (this.layEtcOrder_Do.RowCount > 0)
                        {
                            this.mInputPart = "11";
                            this.INPUTTAB = "11";
                            this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                            //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, OrderBox.GrdOrder_Etc, "11", "OCS0103U19", "etc");
                            this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                OrderBox.GrdOrder_Etc);
                            this.RecieveAndSetOrderInfo("OCS0103U19", OrderBox.GrdOrder_Etc);
                        }

                        #endregion

                        this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(),
                            this.mCurrentInputTab);
                    }
                    break;
                //insert by jc START
                case "OCS1003Q09":

                    #region Doオーダ

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("OCS1003"))
                        {

                            MultiLayout lyOCS1003 = new MultiLayout();

                            //this.ApplyCopyOrderInfo((MultiLayout)commandParam["OCS0303"], HangmogInfo.ExecutiveMode.YaksokCopy);
                            lyOCS1003 = (MultiLayout)commandParam["OCS1003"];

                            int cntDupleSpeciment = 0;
                            this.layDrugOrder_Do.Reset();
                            this.layJusaOrder_Do.Reset();
                            this.layCplOrder_Do.Reset();
                            this.layPfeOrder_Do.Reset();
                            this.layAplOrder_Do.Reset();
                            this.layXrtOrder_Do.Reset();
                            this.layChuchiOrder_Do.Reset();
                            this.laySusulOrder_Do.Reset();
                            // リハビリオーダ追加 2012/09/26
                            this.layRehaOrder_Do.Reset();
                            this.layEtcOrder_Do.Reset();
                            //this.SetVisibleStatusBar(true);
                            //this.InitStatusBar(lyOCS1003.RowCount);
                            //this.SetStatusBar(0);

                            //[各部門毎にオーダを分ける]
                            foreach (DataRow dr in lyOCS1003.LayoutTable.Rows)
                            {
                                this.SetInputGubunColor(dr["input_gubun"].ToString());
                                switch (dr["input_tab"].ToString())
                                {
                                    case "01": // 내복약오더
                                        this.layDrugOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U10))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U10);
                                        }
                                        break;

                                    case "03": // 주사오더
                                        this.layJusaOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U12))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U12);
                                        }
                                        break;

                                    case "04": // 검체검사 오더
                                        //重複検査して重複除去
                                        if (!IsDupleSpeciment(dr))
                                        {
                                            this.layCplOrder_Do.LayoutTable.ImportRow(dr);
                                        }
                                        else
                                            cntDupleSpeciment++;

                                        break;

                                    case "05": // 생리검사 오더
                                        this.layPfeOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U14))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U14);
                                        }
                                        break;

                                    case "06": // 병리검사 오더
                                        this.layAplOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U15))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U15);
                                        }
                                        break;

                                    case "07": // 방사선 오더
                                        this.layXrtOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U16))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U16);
                                        }
                                        break;

                                    case "08": // 처치
                                        this.layChuchiOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U17))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U17);
                                        }
                                        break;

                                    case "09": // 마취 수술
                                        this.laySusulOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U18))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U18);
                                        }
                                        break;

                                    // リハビリオーダ追加 2012/09/26
                                    case "10": // リハビリ
                                        this.layRehaOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U11))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U11);
                                        }
                                        break;
                                    case "11": // 기타 오더
                                        this.layEtcOrder_Do.LayoutTable.ImportRow(dr);
                                        if (loadedGridModules.Contains(GridModule.OCS0103U19))
                                        {
                                            loadedGridModules.Remove(GridModule.OCS0103U19);
                                        }
                                        break;
                                }
                            }

                            //重複された検体検査オーダがあれば何件が重複されていて登録できなかったのかMSGで知らせる
                            if (cntDupleSpeciment > 0)
                            {
                                MessageBox.Show("重複された" + cntDupleSpeciment + "件のオーダは登録対象外としました。");
                            }
                            //insert by jc [通常]

                            if (UserInfo.Gwa == "CK")
                            {
                                if (this.mPostApproveYN)
                                    iInputGubun = "D0";
                                else
                                    iInputGubun = this.mInputGubun;
                            }
                            else
                            {
                                iInputGubun = OrderBox.TabInputGubun.SelectedTab.Tag.ToString();
                            }

                            //if (this.mDoctorLogin)
                            //    iInputGubun = OrderBox.TabInputGubun.SelectedTab.Tag.ToString();
                            //else
                            //    iInputGubun = this.mInputGubun;

                            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_GUBUN", iInputGubun,
                                ref this.iInputGubunName);


                            //[分けたオーダを架空する。]

                            #region 薬

                            //[group情報生成]
                            if (this.layDrugOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "01";
                                this.INPUTTAB = "01";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layDrugOrder_Do, this.layDrugOrder, OrderBox.GrdOrder_Drug, "01", "OCS0103U10", "drug");
                                this.ApplyCopyOrderInfoDrug(this.layDrugOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Drug);
                                this.RecieveAndSetOrderInfo("OCS0103U10", OrderBox.GrdOrder_Drug);
                            }

                            #endregion

                            #region 注射

                            if (this.layJusaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "03";
                                this.INPUTTAB = "03";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layJusaOrder_Do, this.layJusaOrder, OrderBox.GrdOrder_Jusa, "03", "OCS0103U12", "jusa");
                                this.ApplyCopyOrderInfoJusa(this.layJusaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Jusa);
                                this.RecieveAndSetOrderInfo("OCS0103U12", OrderBox.GrdOrder_Jusa);
                            }

                            #endregion

                            #region 検体検査

                            if (this.layCplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "04";
                                this.INPUTTAB = "04";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();

                                //MakeDoOrderGrouping2(this.layCplOrder_Do, this.layCplOrder, OrderBox.GrdOrder_Cpl, "04", "OCS0103U13", "cpl");
                                this.ApplyCopyOrderInfoCpl(this.layCplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Cpl);
                                this.RecieveAndSetOrderInfo("OCS0103U13", OrderBox.GrdOrder_Cpl);

                            }

                            #endregion


                            #region 生理検査

                            if (this.layPfeOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "05";
                                this.INPUTTAB = "05";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layPfeOrder_Do, this.layPfeOrder, OrderBox.GrdOrder_Pfe, "05", "OCS0103U14", "pfe");
                                this.ApplyCopyOrderInfoPfe(this.layPfeOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Pfe);
                                this.RecieveAndSetOrderInfo("OCS0103U14", OrderBox.GrdOrder_Pfe);
                            }

                            #endregion

                            #region 病理検査

                            if (this.layAplOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "06";
                                this.INPUTTAB = "06";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layAplOrder_Do, this.layAplOrder, OrderBox.GrdOrder_Apl, "06", "OCS0103U15", "apl");
                                this.ApplyCopyOrderInfoApl(this.layAplOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Apl);
                                this.RecieveAndSetOrderInfo("OCS0103U15", OrderBox.GrdOrder_Apl);
                            }

                            #endregion

                            #region 放射線

                            if (this.layXrtOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "07";
                                this.INPUTTAB = "07";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layXrtOrder_Do, this.layXrtOrder, OrderBox.GrdOrder_Xrt, "07", "OCS0103U16", "xrt");
                                this.ApplyCopyOrderInfoXrt(this.layXrtOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Xrt);
                                this.RecieveAndSetOrderInfo("OCS0103U16", OrderBox.GrdOrder_Xrt);
                            }

                            #endregion

                            #region 処置

                            if (this.layChuchiOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "08";
                                this.INPUTTAB = "08";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layChuchiOrder_Do, this.layChuchiOrder, OrderBox.GrdOrder_Chuchi, "08", "OCS0103U17", "chuchi");
                                this.ApplyCopyOrderInfoChuchi(this.layChuchiOrder_Do,
                                    HangmogInfo.ExecutiveMode.YaksokCopy, OrderBox.GrdOrder_Chuchi);
                                this.RecieveAndSetOrderInfo("OCS0103U17", OrderBox.GrdOrder_Chuchi);
                            }

                            #endregion

                            #region 手術

                            if (this.laySusulOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "09";
                                this.INPUTTAB = "09";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.laySusulOrder_Do, this.laySusulOrder, OrderBox.GrdOrder_Susul, "09", "OCS0103U18", "susul");
                                this.ApplyCopyOrderInfoSusul(this.laySusulOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Susul);
                                this.RecieveAndSetOrderInfo("OCS0103U18", OrderBox.GrdOrder_Susul);
                            }

                            #endregion

                            // リハビリオーダ追加 2012/09/26

                            #region リハビリ

                            if (this.layRehaOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "10";
                                this.INPUTTAB = "10";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                this.ApplyCopyOrderInfoReha(this.layRehaOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Reha);
                                this.RecieveAndSetOrderInfo("OCS0103U11", OrderBox.GrdOrder_Reha);
                            }

                            #endregion

                            #region その他

                            if (this.layEtcOrder_Do.RowCount > 0)
                            {
                                this.mInputPart = "11";
                                this.INPUTTAB = "11";
                                this.mOrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue();
                                //MakeDoOrderGrouping2(this.layEtcOrder_Do, this.layEtcOrder, OrderBox.GrdOrder_Etc, "11", "OCS0103U19", "etc");
                                this.ApplyCopyOrderInfoEtc(this.layEtcOrder_Do, HangmogInfo.ExecutiveMode.YaksokCopy,
                                    OrderBox.GrdOrder_Etc);
                                this.RecieveAndSetOrderInfo("OCS0103U19", OrderBox.GrdOrder_Etc);
                            }

                            #endregion

                            this.DislplayOrderDataWindow(OrderBox.TabInputGubun.SelectedTab.Tag.ToString(),
                                this.mCurrentInputTab);

                        }
                    }
                    KinkiChecking(GetSetOrder(layDrugOrder_Do, layJusaOrder_Do));
                    break;

                    #endregion

                case "OCS0503U00":
                    // insert by jc [返事がない依頼件があるか確認してあれば点滅させて知らせる] 2012/11/09
                    //if (this.mOrderBiz.IsNoReturnConsult(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                    //                                     pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(),
                    //                                     this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                    //                                     UserInfo.DoctorID,
                    //                                     IO_Gubun))
                    //{
                    //    this.pbxIsNoConfirmOfReturnedConsult.Visible = true;
                    //}
                    //else
                    //    this.pbxIsNoConfirmOfReturnedConsult.Visible = false;
                    break;

                case "OCS0503U01":
                    // insert by jc [確認していない依頼があればあれば点滅させて知らせる] 2012/11/22
                    // pbxIsNoAnwerOfConsulted is un-used in EMR
                    if (this.mOrderBiz.IsNoConfirmConsult(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                        pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(),
                        this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                        UserInfo.DoctorID,
                        IO_Gubun))
                    {
                        this.pbxIsNoAnwerOfConsulted.Visible = true;
                        pbxIsShowSignalBoxButton1.Visible = true;
                    }
                    else
                    {
                        this.pbxIsNoAnwerOfConsulted.Visible = false;
                        pbxIsShowSignalBoxButton1.Visible = false;
                    }
                    break;

                case "SCH0201Q12":
                    XMessageBox.Show("SCH0201Q12");
                    break;

            }
            popupGridOrderActive = false;
            return base.Command(command, commandParam);
        }

        public void CancelSaving(string emrRecordId, string updId)
        {
            AdditionalBusiness.AdditionalBusiness.CancelSaving(emrRecordId, updId);
        }

        #region[検体検査重複チェック]

        private bool IsDupleSpeciment(DataRow dr)
        {
            for (int i = 0; i < this.layCplOrder.RowCount; i++)
            {
                if (layCplOrder.LayoutTable.Rows[i]["hangmog_code"].ToString() == dr["hangmog_code"].ToString()
                    && layCplOrder.LayoutTable.Rows[i]["group_ser"].ToString() == dr["group_ser"].ToString()
                    && layCplOrder.LayoutTable.Rows[i]["acting_date"].ToString() == "")
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region [group_ser重複除去]

        private void SetSameOrderDateGroupSer(MultiLayout aLaySetData, MultiLayout aAddedData, string aInputTab)
        {
            bool isSameGroupSer = false;
            //[現在登録されているGROUP_SERリスト取得]

            for (int i = 0; i < aLaySetData.RowCount; i++)
            {
                isSameGroupSer = false;

                if (aAddedData.RowCount > 0)
                {
                    for (int j = 0; j < aAddedData.RowCount; j++)
                    {
                        if (aLaySetData.GetItemString(i, "group_ser") == aAddedData.GetItemString(j, "group_ser"))
                        {
                            isSameGroupSer = true;
                            break;
                        }
                    }

                    if (isSameGroupSer == true)
                    {
                        string str = aLaySetData.GetItemString(i, "group_ser");
                        int max_group_ser = (MaxGroup_ser(aInputTab, aAddedData)) + 1 >
                                            (MaxGroup_ser(aInputTab, aLaySetData)) + 1
                            ? (MaxGroup_ser(aInputTab, aAddedData)) + 1
                            : (MaxGroup_ser(aInputTab, aLaySetData)) + 1;
                        for (int k = 0; k < aAddedData.RowCount; k++)
                        {
                            if (aLaySetData.GetItemString(k, "group_ser") == str)
                            {
                                aLaySetData.SetItemValue(k, "group_ser", max_group_ser);
                                aLaySetData.AcceptData();
                            }
                        }
                    }
                }
                //else
                //{
                //    for (int j = i + 1; j < aLaySetData.RowCount; j++)
                //    {
                //        if (aLaySetData.GetItemString(i, "group_ser") == aAddedData.GetItemString(j, "group_ser"))
                //        {
                //            isSameGroupSer = true;
                //            break;
                //        }
                //    }

                //    if (isSameGroupSer == true)
                //    {
                //        string str = aLaySetData.GetItemString(i, "group_ser");
                //        int max_group_ser = (MaxGroup_ser("01", aAddedData)) + 1 > (MaxGroup_ser("01", aLaySetData)) + 1 ? (MaxGroup_ser("01", aAddedData)) + 1 : (MaxGroup_ser("01", aLaySetData)) + 1;
                //        for (int k = 0; k < aAddedData.RowCount; k++)
                //        {
                //            if (aLaySetData.GetItemString(k, "group_ser") == str)
                //            {
                //                aLaySetData.SetItemValue(k, "group_ser", max_group_ser);
                //                aLaySetData.AcceptData();
                //            }
                //        }
                //    }
                //}
            }

        }

        #endregion

        private int MaxGroup_ser(string aInput_tab, MultiLayout aLayout)
        {
            int max = 0;

            for (int i = 0; i < aLayout.RowCount; i++)
            {
                if (aInput_tab == aLayout.GetItemString(i, "input_tab") &&
                    max < int.Parse(aLayout.GetItemString(i, "group_ser")))
                {
                    max = int.Parse(aLayout.GetItemString(i, "group_ser"));
                }
            }

            return max;
        }

        #region 카피 오더의 경우 ( 카피, 셋트, Do 오더의 경우 )

        private void ApplyCopyOrderInfoDrug(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode,
            XEditGrid grdOrder)
        {
            // HangmogInfoのパラメータ情報作成。（UserID, InputPart, InputGubun, INPUTTAB, IOEGUBUN, OrderDate, WonyoiOrderYN）
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;
            this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "Y";

            ////一般名関連start
            //if (this.mGeneral_disp_yn == "Y" && this.mOrderBiz.IsGeneralYN(aHangmogCode) != "")
            //    this.mHangmogInfo.Parameter.GenericSearchYN = "Y";
            //else
            //    this.mHangmogInfo.Parameter.GenericSearchYN = this.mGenericSearchYN;

            //if (this.rbtGenericSearch.Checked == true || this.mHangmogInfo.Parameter.GenericSearchYN == "Y")
            //    this.mHangmogInfo.Parameter.Generic_name = this.mOrderBiz.IsGeneralYN(aHangmogCode);
            ////一般名end

            // OrderModeがSetOrder, CpSetOrderではない場合だけ患者情報（bunho, naewon_key, gubun, birth, gwa）をHangmogInfoにパラメータ追加する
            // SetOrder, CpSetOrderに患者情報が必要ではない理由は該当する情報が患者情報を元に作られてないので
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.fbxBunho.GetDataValue();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mClickedGubun;
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            // LoadHangmogInfoを通してHangmogInfoを取得
            if (this.mHangmogInfo.LoadHangmogInfo(aExcutiveMode, aSourceLayout) == false)
            {
                return;
            }
            // HangmogInfo格納
            MultiLayout layOrderData = this.mHangmogInfo.GetHangmogInfo;

            if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
            {
                // 현재 커런트 그룹정보와 동일하지 않은 그룹정보의 오더가 존재 한다면

                // 동일 정보에 복용코드가 틀린 오더가 여러건 존재한다면...
                // 동일 그룹으로 머지 할건지...하니면 다른 그룹으로 분리할건지 결정한다.
                // 만일 멀티가 아니면? 현재그룹으로 강제 셋팅?

                // 정시약 ㅋㅏ피인경우는 정시약 테이블에 긴급여부와 워ㅜㄴ외처방여부 컬럼이 없기에
                // 현재 기준을 따라간다.
                // Set 오더 인경우는 bogyong_code, nalsu, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "bogyong_code") == "" && groupInfo.Contains("bogyong_code"))
                        {
                            layOrderData.SetItemValue(row, "bogyong_code", groupInfo["bogyong_code"]);
                        }

                        if (layOrderData.GetItemString(row, "nalsu") == "" && groupInfo.Contains("nalsu"))
                        {
                            layOrderData.SetItemValue(row, "nalsu", groupInfo["nalsu"]);
                        }

                        if (layOrderData.GetItemString(row, "emergency") == "" && groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"]);
                        }

                        if (layOrderData.GetItemString(row, "wonyoi_order_yn") == "" &&
                            groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"]);
                        }
                    }
                }

                //if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy)
                //{
                //    for (int i = 0; i < aSourceLayout.RowCount; i++)
                //    {
                //        layOrderData.SetItemValue(i, "donbog_yn", aSourceLayout.GetItemString(i, "donbog_yn"));
                //    }
                //}

            }

            // 머지여부
            // Do, SetオーダはisMergeが基本falseである


            // 인서트 후 포커스 로우
            this.mFocusRow = grdOrder.RowCount - 1 + layOrderData.RowCount;

            //Do,Setオーダは基本isMergeがfalseであるためここの下のロジックに乗る。
            this.ApplyDivideOrderInfo(aExcutiveMode, layOrderData, grdOrder, grdOrder.CurrentRowNumber);
        }

        private void ApplyCopyOrderInfoJusa(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aExcutiveMode,
            XEditGrid grdOrder)
        {
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
                this.mHangmogInfo.Parameter.Wonyoi_Order_Yn_Wonmu = "Y";
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aExcutiveMode, aSourceLayout) == false)
            {
                return;
            }

            MultiLayout layOrderData = this.mHangmogInfo.GetHangmogInfo;

            if (aExcutiveMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy ||
                aExcutiveMode == HangmogInfo.ExecutiveMode.RegularDrugCopy)
            {
                // 현재 커런트 그룹정보와 동일하지 않은 그룹정보의 오더가 존재 한다면


                // 동일 정보에 복용코드가 틀린 오더가 여러건 존재한다면...
                // 동일 그룹으로 머지 할건지...하니면 다른 그룹으로 분리할건지 결정한다.
                // 만일 멀티가 아니면? 현재그룹으로 강제 셋팅?



                // Set 오더 인경우는 jusa, 긴급, 원외 등의 값이 없는 경우는 현재 그룹에 맞추어 간다.
                if (aExcutiveMode == HangmogInfo.ExecutiveMode.YaksokCopy)
                {
                    for (int row = 0; row < layOrderData.RowCount; row++)
                    {
                        if (layOrderData.GetItemString(row, "jusa") == "" && groupInfo.Contains("jusa"))
                        {
                            layOrderData.SetItemValue(row, "jusa", groupInfo["jusa"]);
                        }

                        if (layOrderData.GetItemString(row, "emergency") == "" && groupInfo.Contains("emergency"))
                        {
                            layOrderData.SetItemValue(row, "emergency", groupInfo["emergency"]);
                        }

                        if (layOrderData.GetItemString(row, "wonyoi_order_yn") == "" &&
                            groupInfo.Contains("wonyoi_order_yn"))
                        {
                            layOrderData.SetItemValue(row, "wonyoi_order_yn", groupInfo["wonyoi_order_yn"]);
                        }
                    }
                }
            }

            // 머지여부


            // 인서트 후 포커스 로우
            this.mFocusRow = grdOrder.RowCount - 1 + layOrderData.RowCount;

            this.ApplyDivideOrderInfoOther(layOrderData, grdOrder, grdOrder.CurrentRowNumber);

        }

        private void ApplyCopyOrderInfoCpl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "cpl");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            bool continueFlg = true;
            bool dspMsgFlg = false;

            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                //insert by jc START
                if (aMode == HangmogInfo.ExecutiveMode.BeforeOrderCopy
                    || HangmogInfo.ExecutiveMode.YaksokCopy == aMode
                    || HangmogInfo.ExecutiveMode.OrderCopy == aMode)
                {
                    for (int i = 0; i < grdOrder.RowCount; i++)
                    {
                        if (dr["hangmog_code"].ToString() == grdOrder.GetItemString(i, "hangmog_code")
                            && grdOrder.GetItemString(i, "acting_date") == ""
                            && dr["group_ser"].ToString() == grdOrder.GetItemString(i, "group_ser"))
                        {
                            continueFlg = false;
                            dspMsgFlg = true;
                        }
                    }

                }
                //insert by jc END
                if (continueFlg)
                {
                    emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                    if (emptyNewCell == null)
                    {
                        this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                        settingRow = grdOrder.CurrentRowNumber;
                    }
                    else
                    {
                        settingRow = emptyNewCell.Row;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                    {
                        break;
                    }

                    foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                    {
                        if (groupInfo.Contains(cl.ColumnName))
                        {
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                        }
                        else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            if (cl.ColumnName != "child_gubun" &&
                                cl.ColumnName != "parent_gubun")
                                grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                        }
                    }

                    // 오더 구분 관련 
                    if (dr["order_gubun"].ToString().Length < 2)
                        grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                            dr["order_gubun"].ToString();
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                            dr["order_gubun"].ToString().Substring(1, 1);

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                    else
                        grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                    if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                    {
                        grdOrder.SetItemValue(settingRow, "child_yn", "N");
                        mParentInfo = new Hashtable();
                        mParentInfo.Add("row_num", settingRow);
                        mParentInfo.Add("key", dr["org_key"].ToString());

                        mParentList.Add(mParentInfo);
                    }
                    else
                    {
                        grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                    }

                    // 추후 오더소팅과 포커스와 관련 있는 컬럼
                    grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
                    //insert by jc START
                    grdOrder.LayoutTable.Rows[settingRow]["dangil_gumsa_order_yn"] = dr["dangil_gumsa_order_yn"];
                    grdOrder.LayoutTable.Rows[settingRow]["dangil_gumsa_result_yn"] = dr["dangil_gumsa_result_yn"];
                    //insert by jc END
                }
                else
                    continueFlg = true;
            }
            //insert by jc
            if (dspMsgFlg)
                XMessageBox.Show("既に登録されているオーダは対象外として処理しました。", "お知らせ");
            if (mParentList.Count > 0)
                this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd,
                    mParentList, grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoPfe(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Pfe, "pfe");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "pfe");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;


            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));

        }

        private void ApplyCopyOrderInfoApl(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Apl, "apl");

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "apl");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }

            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoXrt(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Xrt, "xrt");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "xrt");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoChuchi(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Chuchi, "chuchi");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "chuchi");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoSusul(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }
            //groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Susul, "susul");
            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "susul");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        private void ApplyCopyOrderInfoEtc(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "etc");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        #endregion


        private void ApplyCopyOrderInfoReha(MultiLayout aSourceLayout, HangmogInfo.ExecutiveMode aMode,
            XEditGrid grdOrder)
        {
            ArrayList mParentList = new ArrayList();
            Hashtable mParentInfo;
            Hashtable groupInfo = new Hashtable();
            this.mHangmogInfo.Parameter.Clear();
            this.mHangmogInfo.Parameter.InputID = UserInfo.UserID;
            this.mHangmogInfo.Parameter.InputPart = this.mInputPart;
            this.mHangmogInfo.Parameter.InputGubun = this.iInputGubun;
            this.mHangmogInfo.Parameter.InputTab = INPUTTAB;
            this.mHangmogInfo.Parameter.IOEGubun = this.IO_Gubun;
            this.mHangmogInfo.Parameter.OrderDate = this.mOrderDate;

            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                this.mHangmogInfo.Parameter.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                this.mHangmogInfo.Parameter.NaewonKey =
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
                this.mHangmogInfo.Parameter.Gubun = this.mSelectedPatientInfo.GetPatientInfo["gubun"].ToString();
                this.mHangmogInfo.Parameter.Birth_Date = this.mSelectedPatientInfo.GetPatientInfo["birth"].ToString();
                this.mHangmogInfo.Parameter.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                this.mHangmogInfo.Parameter.ApproveDoctor =
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString();
            }

            if (this.mHangmogInfo.LoadHangmogInfo(aMode, aSourceLayout) == false)
            {
                return;
            }

            if (grdOrder.RowCount < 1)
            {
                groupInfo = MakeNewOrderGroup(grdOrder, "reha");
            }
            else
            {
                groupInfo["group_ser"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser");
                groupInfo["emergency"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "emergency");
                groupInfo["group_name"] = grdOrder.GetItemString(grdOrder.RowCount - 1, "group_ser") + " グループ";
            }
            int settingStart = -1;
            int settingEnd = -1;
            int settingRow = -1;

            // 셋팅 시작 로우

            XCell emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

            if (emptyNewCell == null)
            {
                this.OrderGridCreateNewRow(-1, grdOrder);
                settingStart = grdOrder.CurrentRowNumber;
            }
            else
            {
                settingStart = emptyNewCell.Row;
            }

            settingRow = settingStart;

            // 셋팅 끝 로우 
            settingEnd = settingStart + aSourceLayout.RowCount - 1;

            // 그룹정보
            //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            //foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            foreach (DataRow dr in this.mHangmogInfo.GetHangmogInfo.LayoutTable.Rows)
            {
                emptyNewCell = this.mOrderFunc.GetEmptyNewRow((XEditGrid)grdOrder);

                if (emptyNewCell == null)
                {
                    this.OrderGridCreateNewRow(grdOrder.CurrentRowNumber, grdOrder);
                    settingRow = grdOrder.CurrentRowNumber;
                }
                else
                {
                    settingRow = emptyNewCell.Row;
                }

                // 긴급 관련
                if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, dr) == false)
                {
                    break;
                }

                foreach (DataColumn cl in grdOrder.LayoutTable.Columns)
                {
                    if (groupInfo.Contains(cl.ColumnName))
                    {
                        grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = groupInfo[cl.ColumnName];
                    }
                    else if (this.mHangmogInfo.GetHangmogInfo.LayoutTable.Columns.Contains(cl.ColumnName))
                    {
                        if (cl.ColumnName != "child_gubun" &&
                            cl.ColumnName != "parent_gubun")
                            grdOrder.LayoutTable.Rows[settingRow][cl.ColumnName] = dr[cl.ColumnName];
                    }
                }

                // 오더 구분 관련 
                if (dr["order_gubun"].ToString().Length < 2)
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) + dr["order_gubun"].ToString();
                else
                    grdOrder.LayoutTable.Rows[settingRow]["order_gubun"] =
                        this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, grdOrder, settingRow) +
                        dr["order_gubun"].ToString().Substring(1, 1);

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_table"] = dr["jundal_table_inp"];

                // 현재 화면이 외래 모드인경우만 인서트
                if (IOEGUBUN == "O")
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_out"];
                else
                    grdOrder.LayoutTable.Rows[settingRow]["jundal_part"] = dr["jundal_part_inp"];

                if (this.mOrderFunc.IsParentCopyOrder(aSourceLayout, dr))
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "N");
                    mParentInfo = new Hashtable();
                    mParentInfo.Add("row_num", settingRow);
                    mParentInfo.Add("key", dr["org_key"].ToString());

                    mParentList.Add(mParentInfo);
                }
                else
                {
                    grdOrder.SetItemValue(settingRow, "child_yn", "Y");
                }

                grdOrder.SetItemValue(settingRow, "dummy", "mageshin");

                // 依頼書作成中保存せず閉じたとしたらPHY8002 テーブルに FK_OCS キーがないため キーがないと保存してないと見なし、オーダを生成しない。
                string pkocskey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocskey");
                //                string str = @"SELECT A.FK_OCS
                //                                 FROM PHY8002 A 
                //                                WHERE A.HOSP_CODE = '" + EnvironInfo.HospCode + @"' 
                //                                  AND A.FK_OCS = " + pkocskey;
                //                object obj = Service.ExecuteScalar(str);

                // Connect cloud
                OcsoOCS1003P01CheckFkOcsArgs args = new OcsoOCS1003P01CheckFkOcsArgs();
                args.FkOcs = pkocskey;
                OcsoOCS1003P01CheckFkOcsResult result =
                    CloudService.Instance.Submit<OcsoOCS1003P01CheckFkOcsResult, OcsoOCS1003P01CheckFkOcsArgs>(args);


                if (this.mOrderMode != OrderVariables.OrderMode.SetOrder
                    && this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                {
                    if (result != null)
                    {
                        if (result.FkOcs == null && grdOrder.GetItemString(settingRow, "specific_comment") != "")
                            grdOrder.DeleteRow(grdOrder.CurrentRowNumber);
                    }
                }
            }

            this.mOrderFunc.ChildParentOrderKeyMapping(this.mOrderMode, grdOrder, settingStart, settingEnd, mParentList,
                grdOrder.CurrentRowNumber);

            //PostCallHelper.PostCall(new PostMethod(this.PostOrderInsert));
        }

        #region 오더코드 그리드에 셋팅

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅

        private void ApplyDivideOrderInfo(HangmogInfo.ExecutiveMode aExecutiveMode, MultiLayout aSourceLayout,
            XEditGrid aDestGrid, int aRowNumber)
        {
            string ordergubunname = ""; // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            Hashtable currGroupInfo;
            int cnt = 0;

            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.

            #region

            string aCurrBogyongCode = "";
            string aCurrNalsu = "";
            string aCurrEmergency = "";
            string aCurrWonyoiOrderYn = "";
            string aCurrGroupSer = "";

            Hashtable groupInfo;
            ArrayList groupInfoList = new ArrayList();
            bool isAddGroupInfo = true;
            foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            {
                if (dr.Table.Columns.Contains("group_ser") && dr["group_ser"].ToString() != "")
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        //[groupInfoList全体をもう一度検索して同じgroupInfoがあるか確認する]
                        for (int i = 0; i < groupInfoList.Count; i++)
                        {
                            if (((Hashtable)groupInfoList[i])["group_ser"].ToString() == dr["group_ser"].ToString()
                                &&
                                ((Hashtable)groupInfoList[i])["bogyong_code"].ToString() ==
                                dr["bogyong_code"].ToString()
                                && ((Hashtable)groupInfoList[i])["nalsu"].ToString() == dr["nalsu"].ToString()
                                && ((Hashtable)groupInfoList[i])["emergency"].ToString() == dr["emergency"].ToString()
                                &&
                                ((Hashtable)groupInfoList[i])["wonyoi_order_yn"].ToString() ==
                                dr["wonyoi_order_yn"].ToString())
                            {
                                isAddGroupInfo = false;
                            }
                        }

                        if (isAddGroupInfo)
                        {
                            groupInfo = new Hashtable();

                            groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                            groupInfo.Add("nalsu", dr["nalsu"].ToString());
                            groupInfo.Add("emergency", dr["emergency"].ToString());
                            groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                            groupInfo.Add("group_ser", dr["group_ser"].ToString());
                            groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());

                            groupInfoList.Add(groupInfo);

                            aCurrBogyongCode = dr["bogyong_code"].ToString();
                            aCurrNalsu = dr["nalsu"].ToString();
                            aCurrEmergency = dr["emergency"].ToString();
                            aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                            aCurrGroupSer = dr["group_ser"].ToString();
                        }
                        isAddGroupInfo = true;
                    }
                }
                else
                {
                    if (dr["bogyong_code"].ToString() != aCurrBogyongCode ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("bogyong_code", dr["bogyong_code"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("bogyong_name", dr["bogyong_name"].ToString());

                        groupInfoList.Add(groupInfo);

                        aCurrBogyongCode = dr["bogyong_code"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();

                    }
                }
            }

            #endregion

            #region 그룹 정보를 돌면서 셋팅한다.

            int groupInfoCnt = 0;
            foreach (Hashtable info in groupInfoList)
            {
                string filter = "";
                if (info.Contains("group_ser"))
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser='" + info["group_ser"].ToString() + "'";
                }
                else
                {
                    filter = "bogyong_code='" + info["bogyong_code"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "'";
                }

                DataRow[] rows = aSourceLayout.LayoutTable.Select(filter);

                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                //if (this.fbxBogyongCode.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(aDestGrid, this.groupInfo))
                //{
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //    this.fbxBogyongCode.AcceptData();
                //}

                //if (this.IsSameCurrentGroupInfo(info["bogyong_code"].ToString(), info["nalsu"].ToString(), info["emergency"].ToString(), info["wonyoi_order_yn"].ToString()) == false)
                //{
                //    // 신규 그룹생성
                //    this.btnList.PerformClick(FunctionType.Process);
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //    this.fbxBogyongCode.AcceptData();
                //}

                //신규 그룹생성
                //this.btnList.PerformClick(FunctionType.Process);
                ////그룹정보 맞추기
                //this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //this.fbxBogyongCode.SetEditValue(info["bogyong_code"].ToString());
                //this.fbxBogyongCode.AcceptData();


                groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Drug, "drug");
                groupInfo["nalsu"] = ((Hashtable)groupInfoList[cnt])["nalsu"].ToString();
                groupInfo["emergency"] = ((Hashtable)groupInfoList[cnt])["emergency"].ToString();
                groupInfo["wonyoi_order_yn"] = ((Hashtable)groupInfoList[cnt])["wonyoi_order_yn"].ToString();
                groupInfo["bogyong_code"] = ((Hashtable)groupInfoList[cnt])["bogyong_code"].ToString();
                groupInfo["bogyong_name"] = ((Hashtable)groupInfoList[cnt++])["bogyong_name"].ToString();



                if (currRow < 0)
                {
                    this.OrderGridCreateNewRow(-1, aDestGrid);
                    currRow = aDestGrid.CurrentRowNumber;
                    startRow = aDestGrid.CurrentRowNumber;
                }
                else
                {
                    XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                    if (newCell != null)
                    {
                        currRow = newCell.Row;
                        startRow = newCell.Row;
                    }
                    else
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                        startRow = aDestGrid.CurrentRowNumber;
                    }
                }

                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                    }

                    if (
                        IsExistDifferntDrugGroup(groupInfo["group_ser"].ToString(),
                            rows[i]["order_gubun_bas"].ToString(), aDestGrid) == true)
                    {
                        //같은그룹에 외용약과 내복약은 혼재할 수 없습니다.
                        MessageBox.Show(XMsg.GetMsg("M009"), XMsg.GetField("F001"), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        aDestGrid.DeleteRow(aDestGrid.CurrentRowNumber);
                        return;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) ==
                        false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in aDestGrid.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (cl.ColumnName != "dv" && cl.ColumnName != "dv_time" && groupInfo.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = groupInfo[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
                        }
                    }

                    // 입원인경우 nday_yn 셋팅 
                    if (this.IO_Gubun == "I")
                    {
                        string nalsu = aDestGrid.LayoutTable.Rows[currRow]["nalsu"].ToString();

                        if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                        {
                            aDestGrid.LayoutTable.Rows[currRow]["nday_yn"] = "Y";
                        }
                        else
                        {
                            aDestGrid.LayoutTable.Rows[currRow]["nday_yn"] = "N";
                        }
                    }

                    // 오더 구분 관련 
                    if (rows[i]["order_gubun"].ToString().Length < 2)
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) +
                            rows[i]["order_gubun"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) +
                            rows[i]["order_gubun"].ToString().Substring(1, 1);

                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_inp"].ToString();

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_inp"].ToString();

                    //insert by jc 2013/01/11
                    // 돈복, 내용, 외용에 따른 dv_time 셋팅 이건 강제 셋팅 하자...
                    //if (aExecutiveMode != HangmogInfo.ExecutiveMode.BeforeOrderCopy &&
                    //    aExecutiveMode != HangmogInfo.ExecutiveMode.YaksokCopy &&
                    //    aExecutiveMode != HangmogInfo.ExecutiveMode.OrderCopy)
                    //{
                    //    if (aDestGrid.LayoutTable.Rows[currRow]["order_gubun"].ToString().Substring(1, 1) == "C")
                    //    {
                    //        if (this.groupInfo.Contains("donbog_yn") && this.groupInfo["donbog_yn"].ToString() == "Y")
                    //        {
                    //            aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    //        }
                    //        else
                    //        {
                    //            aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "/";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        aDestGrid.LayoutTable.Rows[currRow]["dv_time"] = "*";
                    //    }
                    //}

                    aDestGrid.DisplayData();

                    //if (this.tabGroup.SelectedTab.Tag != null)
                    //    this.ApplyGroupInfoToRow((Hashtable)this.tabGroup.SelectedTab.Tag, currRow);

                    this.mFocusRow = currRow;
                }

                this.mHangmogInfo.SetAlignMixGroup(aDestGrid, startRow, currRow);

                aDestGrid.DisplayData();

                //this.SetOrderImage(aDestGrid);

                // 외용, 내복에 따른 변경부분셋팅
                //this.SetGroupControlVisible(this.groupInfo["group_ser"].ToString());
                aDestGrid.AcceptData();
            }

            #endregion
        }

        #endregion

        #endregion

        #region 오더코드 그리드에 셋팅 주사

        #region 카피오더중 현재 그룹으로 합치지 않고 나누어 지는경우의 셋팅 注射

        private void ApplyDivideOrderInfoOther(MultiLayout aSourceLayout, XEditGrid aDestGrid, int aRowNumber)
        {
            string ordergubunname = ""; // 헤더를 붙인 오더구분을 넣는다.
            int currRow = aRowNumber;
            int startRow = aRowNumber;
            int cnt = 0;
            if (aSourceLayout.RowCount <= 0) return;

            // 먼저 넘어온 데이터에서 그룹정보만을 셋팅 한다.

            #region

            string aJusa = "";
            string aCurrNalsu = "";
            string aCurrEmergency = "";
            string aCurrWonyoiOrderYn = "";
            string aCurrGroupSer = "";

            Hashtable groupInfo;
            ArrayList groupInfoList = new ArrayList();
            bool isAddGroupInfo = true;
            foreach (DataRow dr in aSourceLayout.LayoutTable.Rows)
            {
                if (dr.Table.Columns.Contains("group_ser") && dr["group_ser"].ToString() != "")
                {
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn ||
                        dr["group_ser"].ToString() != aCurrGroupSer)
                    {
                        //[groupInfoList全体をもう一度検索して同じgroupInfoがあるか確認する]
                        for (int i = 0; i < groupInfoList.Count; i++)
                        {
                            if (((Hashtable)groupInfoList[i])["group_ser"].ToString() == dr["group_ser"].ToString()
                                && ((Hashtable)groupInfoList[i])["jusa"].ToString() == dr["jusa"].ToString()
                                && ((Hashtable)groupInfoList[i])["nalsu"].ToString() == dr["nalsu"].ToString()
                                && ((Hashtable)groupInfoList[i])["emergency"].ToString() == dr["emergency"].ToString()
                                &&
                                ((Hashtable)groupInfoList[i])["wonyoi_order_yn"].ToString() ==
                                dr["wonyoi_order_yn"].ToString())
                            {
                                isAddGroupInfo = false;
                            }
                        }

                        if (isAddGroupInfo)
                        {
                            groupInfo = new Hashtable();

                            groupInfo.Add("jusa", dr["jusa"].ToString());
                            groupInfo.Add("nalsu", dr["nalsu"].ToString());
                            groupInfo.Add("emergency", dr["emergency"].ToString());
                            groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                            groupInfo.Add("group_ser", dr["group_ser"].ToString());
                            groupInfo.Add("jusa_name", dr["jusa_name"].ToString());

                            groupInfoList.Add(groupInfo);

                            aJusa = dr["jusa"].ToString();
                            aCurrNalsu = dr["nalsu"].ToString();
                            aCurrEmergency = dr["emergency"].ToString();
                            aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                            aCurrGroupSer = dr["group_ser"].ToString();
                        }
                    }
                }
                else
                {
                    if (dr["jusa"].ToString() != aJusa ||
                        dr["nalsu"].ToString() != aCurrNalsu ||
                        dr["emergency"].ToString() != aCurrEmergency ||
                        dr["wonyoi_order_yn"].ToString() != aCurrWonyoiOrderYn)
                    {
                        groupInfo = new Hashtable();

                        groupInfo.Add("jusa", dr["jusa"].ToString());
                        groupInfo.Add("nalsu", dr["nalsu"].ToString());
                        groupInfo.Add("emergency", dr["emergency"].ToString());
                        groupInfo.Add("wonyoi_order_yn", dr["wonyoi_order_yn"].ToString());
                        groupInfo.Add("jusa_name", dr["jusa_name"].ToString());

                        groupInfoList.Add(groupInfo);

                        aJusa = dr["jusa"].ToString();
                        aCurrNalsu = dr["nalsu"].ToString();
                        aCurrEmergency = dr["emergency"].ToString();
                        aCurrWonyoiOrderYn = dr["wonyoi_order_yn"].ToString();
                    }
                }
            }

            #endregion

            #region 그룹 정보를 돌면서 셋팅한다.

            foreach (Hashtable info in groupInfoList)
            {
                string filter = "";
                if (info.Contains("group_ser"))
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "' AND " +
                             "group_ser=" + info["group_ser"].ToString();
                }
                else
                {
                    filter = "jusa='" + info["jusa"].ToString() + "' AND " +
                             "nalsu=" + info["nalsu"].ToString() + " AND " +
                             "emergency='" + info["emergency"].ToString() + "' AND " +
                             "wonyoi_order_yn='" + info["wonyoi_order_yn"].ToString() + "'";
                }

                DataRow[] rows = aSourceLayout.LayoutTable.Select(filter);

                // 커런트 그룹정보가 동일한지 여부
                //    - 커런트 그룹이 아직 복용코드 정보가 입력되지 않은 경우는 현재 그룹정보를 
                //      지금 그룹으로 변경해 버린다.
                //    - 그렇지 않은 경우는 새 그룹 생성

                //if (this.fbxJusa.GetDataValue() == "" && this.mOrderFunc.IsEmptyGroup(this.grdOrder, (((Hashtable)this.tabGroup.SelectedTab.Tag)["group_ser"]).ToString()))
                //{
                //    // 그룹정보 맞추기
                //    this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //    this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                //    this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //    this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());
                //    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                //    this.fbxJusa.AcceptData();
                //}



                // 신규 그룹생성
                //this.btnList.PerformClick(FunctionType.Process);
                //// 그룹정보 맞추기
                //this.cboNalsu.SelectedValueChanged -= new EventHandler(cboNalsu_SelectedValueChanged);
                //this.cboNalsu.SetDataValue(info["nalsu"].ToString());
                //this.cboNalsu.SelectedValueChanged += new EventHandler(cboNalsu_SelectedValueChanged);
                //this.cbxEmergency.SetDataValue(info["emergency"].ToString());
                //this.cbxWonyoiOrderYN.SetDataValue(info["wonyoi_order_yn"].ToString());

                //groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

                //if (info["jusa"].ToString() != "")
                //{
                //    this.fbxJusa.SetEditValue(info["jusa"].ToString());
                //    this.fbxJusa.AcceptData();
                //}

                groupInfo = MakeNewOrderGroup(OrderBox.GrdOrder_Jusa, "jusa");
                groupInfo["nalsu"] = ((Hashtable)groupInfoList[cnt])["nalsu"].ToString();
                groupInfo["emergency"] = ((Hashtable)groupInfoList[cnt])["emergency"].ToString();
                groupInfo["wonyoi_order_yn"] = ((Hashtable)groupInfoList[cnt])["wonyoi_order_yn"].ToString();
                groupInfo["jusa"] = ((Hashtable)groupInfoList[cnt])["jusa"].ToString();
                groupInfo["jusa_name"] = ((Hashtable)groupInfoList[cnt++])["jusa_name"].ToString();

                if (currRow < 0)
                {
                    this.OrderGridCreateNewRow(-1, aDestGrid);
                    currRow = aDestGrid.CurrentRowNumber;
                    startRow = aDestGrid.CurrentRowNumber;
                }
                else
                {
                    XCell newCell = this.mOrderFunc.GetEmptyNewRow(aDestGrid);

                    if (newCell != null)
                    {
                        currRow = newCell.Row;
                        startRow = newCell.Row;
                    }
                    else
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                        startRow = aDestGrid.CurrentRowNumber;
                    }
                }

                for (int i = 0; i < rows.Length; i++)
                {

                    if (i != 0)
                    {
                        this.OrderGridCreateNewRow(-1, aDestGrid);
                        currRow = aDestGrid.CurrentRowNumber;
                    }

                    // 긴급 관련
                    if (this.mOrderBiz.IsAbleToCurrentEmergencyGroup(groupInfo, aSourceLayout.LayoutTable.Rows[i]) ==
                        false)
                    {
                        return;
                    }

                    foreach (DataColumn cl in aDestGrid.LayoutTable.Columns)
                    {
                        // 그룹정보내의 정보이면 그룹정보에서 가져가고
                        if (groupInfo.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = groupInfo[cl.ColumnName].ToString();
                        }
                        // 아닌것들은 로우에서 가져간다.
                        else if (aSourceLayout.LayoutTable.Columns.Contains(cl.ColumnName))
                        {
                            aDestGrid.LayoutTable.Rows[currRow][cl.ColumnName] = rows[i][cl.ColumnName];
                        }
                    }

                    // 오더 구분 관련 
                    if (rows[i]["order_gubun"].ToString().Length < 2)
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) +
                            rows[i]["order_gubun"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["order_gubun"] =
                            this.mOrderBiz.GetOrderGubunHead(IOEGUBUN, aDestGrid, currRow) +
                            rows[i]["order_gubun"].ToString().Substring(1, 1);

                    // 외용이냐 내복이냐에 따라 일수표시에 대산 부분이 visible Setting 
                    // 현재 화면이 외래 모드인경우만 인서트     
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_table"] = rows[i]["jundal_table_inp"].ToString();

                    // 현재 화면이 외래 모드인경우만 인서트
                    if (IOEGUBUN == "O")
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_out"].ToString();
                    else
                        aDestGrid.LayoutTable.Rows[currRow]["jundal_part"] = rows[i]["jundal_part_inp"].ToString();

                    aDestGrid.DisplayData();


                }

                this.mHangmogInfo.SetAlignMixGroup(aDestGrid, startRow, currRow);

                aDestGrid.DisplayData();

                //this.SetOrderImage(aDestGrid);

            }

            #endregion
        }

        #endregion

        #endregion

        #region [Group情報同期化]

        private void ApplyGroupInfoToRow(Hashtable aExistGroupInfo, int aSetRowNumber, XEditGrid grdOrder)
        {
            string bogyongCode = "";
            string bogyongName = "";
            string dv = "";
            string nalsu = "";
            string emergency = "N";
            string wonyoi_order_yn = "N";
            string donbog_yn = "N";

            if (aExistGroupInfo.Contains("bogyong_code"))
            {
                bogyongCode = aExistGroupInfo["bogyong_code"].ToString();
            }
            if (aExistGroupInfo.Contains("bogyong_name"))
            {
                bogyongName = aExistGroupInfo["bogyong_name"].ToString();
            }
            if (aExistGroupInfo.Contains("dv"))
            {
                dv = aExistGroupInfo["dv"].ToString();
            }
            if (aExistGroupInfo.Contains("nalsu"))
            {
                nalsu = aExistGroupInfo["nalsu"].ToString();
            }
            if (aExistGroupInfo.Contains("emergency"))
            {
                emergency = aExistGroupInfo["emergency"].ToString();
            }
            if (aExistGroupInfo.Contains("wonyoi_order_yn"))
            {
                wonyoi_order_yn = aExistGroupInfo["wonyoi_order_yn"].ToString();
            }
            if (aExistGroupInfo.Contains("donbog_yn"))
            {
                donbog_yn = aExistGroupInfo["donbog_yn"].ToString();
            }

            // 접수하기 전의 오더만 가능
            // 주사방법을 기준으로 변경 가능한것만 그룹정보 업데이트 한다.
            if (this.mOrderMode == OrderVariables.OrderMode.SetOrder ||
                this.mOrderMode == OrderVariables.OrderMode.CpSetOrder ||
                this.mHangmogInfo.IsOrderDataChagnedEnabled(this.IO_Gubun, grdOrder, aSetRowNumber, "bogyong_code",
                    OrderVariables.CheckMode.DataUpdate, OrderVariables.ErrorDisplayMode.NoDisplay))
            {
                // 복용코드
                if (grdOrder.GetItemString(aSetRowNumber, "bogyong_code") != bogyongCode)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "bogyong_code", bogyongCode);
                }

                // 복용법 명칭
                if (grdOrder.GetItemString(aSetRowNumber, "bogyong_name") != bogyongName)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "bogyong_name", bogyongName);
                }

                // DV
                if (this.IsOutDrugGroup(aExistGroupInfo["group_ser"].ToString()) == false)
                {
                    if (dv != "" && grdOrder.GetItemString(aSetRowNumber, "dv") != dv)
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "dv", dv);
                    }
                }

                // 날수
                if (grdOrder.GetItemString(aSetRowNumber, "nalsu") != nalsu)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "nalsu", nalsu);
                }

                // 날수 셋팅에 따른 Nday_YN 설정.
                if (this.IO_Gubun == "O")
                {
                    if (TypeCheck.IsInt(nalsu) && int.Parse(nalsu) > 1)
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "Y");
                    }
                    else
                    {
                        grdOrder.SetItemValue(aSetRowNumber, "nday_yn", "N");
                    }
                }
                // 긴급
                if (grdOrder.GetItemString(aSetRowNumber, "emergency") != emergency)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "emergency", emergency);
                }

                // 원외여부
                if (grdOrder.GetItemString(aSetRowNumber, "wonyoi_order_yn") != wonyoi_order_yn)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "wonyoi_order_yn", wonyoi_order_yn);
                }

                // 돈복여부
                if (grdOrder.GetItemString(aSetRowNumber, "donbog_yn") != donbog_yn)
                {
                    grdOrder.SetItemValue(aSetRowNumber, "donbog_yn", donbog_yn);
                }
            }

            //this.MakePreviewStatus();
        }

        #endregion

        #region 외용약 내복약 같은 그룹에 혼재 방지용 체크

        private bool IsExistDifferntDrugGroup(string aGroupSer, string aOrderGubunBas, XEditGrid grdOrder)
        {
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (grdOrder.GetItemString(i, "order_gubun_bas") != "" &&
                    aOrderGubunBas != grdOrder.GetItemString(i, "order_gubun_bas") &&
                    aGroupSer == grdOrder.GetItemString(i, "group_ser"))
                {
                    if (i == grdOrder.CurrentRowNumber && grdOrder.GetItemString(i, "hangmog_code") == "")
                        continue;

                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 오더 그리드 신규 로우 생성

        private void OrderGridCreateNewRow(int aRowNumber, XEditGrid grdOrder)
        {
            grdOrder.InsertRow(aRowNumber);

            // 그룹 기준 셋팅
            this.GridInitValueSetting(grdOrder, grdOrder.CurrentRowNumber);
        }

        #endregion

        #region 그리드 신규 로우 초기값 셋팅

        private void GridInitValueSetting(XEditGrid aGrid, int aRowNumber)
        {
            string temp = "";

            //if (tabGroup.SelectedTab == null) return;

            //Hashtable groupInfo = this.tabGroup.SelectedTab.Tag as Hashtable;

            // 그룹시리얼 셋팅
            //if (groupInfo.Contains("group_ser"))
            //    aGrid.SetItemValue(aRowNumber, "group_ser", this.groupInfo["group_ser"].ToString());

            //// 복용코드
            //if (groupInfo.Contains("bogyong_code"))
            //    aGrid.SetItemValue(aRowNumber, "bogyong_code", this.groupInfo["bogyong_code"].ToString());

            //// 긴급
            //if (groupInfo.Contains("emergency"))
            //    aGrid.SetItemValue(aRowNumber, "emergency", this.groupInfo["emergency"].ToString());

            //// 원외처방
            //if (groupInfo.Contains("wonyoi_order_yn"))
            //    aGrid.SetItemValue(aRowNumber, "wonyoi_order_yn", this.groupInfo["wonyoi_order_yn"].ToString());

            // 환자정보
            if ((this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                 this.mOrderMode != OrderVariables.OrderMode.CpSetOrder) && this.mSelectedPatientInfo != null)
            {
                aGrid.SetItemValue(aRowNumber, "bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }

            // 입력탭 정보
            aGrid.SetItemValue(aRowNumber, "input_tab", INPUTTAB);
            this.mOrderBiz.LoadColumnCodeName("code", "INPUT_TAB", INPUTTAB, ref temp);
            aGrid.SetItemValue(aRowNumber, "input_tab_name", temp);


            aGrid.SetItemValue(aRowNumber, "order_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

            aGrid.SetItemValue(aRowNumber, "input_gubun", this.iInputGubun);
            aGrid.SetItemValue(aRowNumber, "input_gubun_name", this.iInputGubunName);

            // 진료정보 ( 오더일자, 진료과, 의사 )
            if (this.mOrderMode != OrderVariables.OrderMode.SetOrder &&
                this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
            {
                if (UserInfo.UserGubun == UserType.Doctor)
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                    aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                }
                else
                {
                    aGrid.SetItemValue(aRowNumber, "input_doctor",
                        this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                    aGrid.SetItemValue(aRowNumber, "input_gwa",
                        this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());

                    // 간호사인경우는 간호픽업 데이트를 자동입력한다.
                    if (UserInfo.UserGubun == UserType.Nurse)
                    {
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_user", UserInfo.UserID);
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_date", /*EnvironInfo.GetSysDate()*/
                            _sysDate.ToString("yyyy/MM/dd"));
                        aGrid.SetItemValue(aRowNumber, "nurse_pickup_time",
                            EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                }



                // 입력구분
                aGrid.SetItemValue(aRowNumber, "input_id", UserInfo.UserID);
                //aGrid.SetItemValue(aRowNumber, "input_part", this.mInputPart);

                //aGrid.SetItemValue(aRowNumber, "input_doctor", UserInfo.DoctorID);
                //aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);

                //aGrid.SetItemValue(aRowNumber, "order_date", this.dpkOrder_Date.GetDataValue());
                aGrid.SetItemValue(aRowNumber, "gwa", this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                aGrid.SetItemValue(aRowNumber, "doctor", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
                aGrid.SetItemValue(aRowNumber, "resident", this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                // 접수및 입원정보
                if (this.IO_Gubun == "O")
                {
                    aGrid.SetItemValue(aRowNumber, "naewon_type",
                        this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString());
                }

                if (this.mOrderMode == OrderVariables.OrderMode.CpOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                    aGrid.SetItemValue(aRowNumber, "in_out_key", this.mCpMasterkey);
                }
                else
                {
                    // 접수 키
                    aGrid.SetItemValue(aRowNumber, "in_out_key",
                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
                }

            }
            // 셋트오더인경우
            else
            {
                if (this.mOrderMode != OrderVariables.OrderMode.CpSetOrder)
                    aGrid.SetItemValue(aRowNumber, "in_out_key",
                        this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

                aGrid.SetItemValue(aRowNumber, "input_gwa", UserInfo.Gwa);
                aGrid.SetItemValue(aRowNumber, "memb", this.mMemb);
                aGrid.SetItemValue(aRowNumber, "yaksok_code", this.mYaksokCode);

                if (this.mOrderMode == OrderVariables.OrderMode.CpSetOrder)
                {
                    aGrid.SetItemValue(aRowNumber, "memb_gubun", this.mMembGubun);
                    aGrid.SetItemValue(aRowNumber, "cp_code", this.mCpCode);
                    aGrid.SetItemValue(aRowNumber, "cp_path_code", this.mCpPathCode);
                    aGrid.SetItemValue(aRowNumber, "jaewonil", this.mJaewonil);
                }
            }

            // nday occur yn   n데이 오더 발생여부
            if (this.mInputPart == "01" || this.mInputPart == "03")
                aGrid.SetItemValue(aRowNumber, "nday_occur_yn", "N");
        }

        #endregion

        // 新規グループ作成
        private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            string input_tab = "";
            switch (gubun)
            {
                case "drug":
                    input_tab = "01";
                    break;
                case "jusa":
                    input_tab = "03";
                    break;
                case "cpl":
                    input_tab = "04";
                    break;
                case "pfe":
                    input_tab = "05";
                    break;
                case "apl":
                    input_tab = "06";
                    break;
                case "xrt":
                    input_tab = "07";
                    break;
                case "chuchi":
                    input_tab = "08";
                    break;
                case "susul":
                    input_tab = "09";
                    break;
                case "etc":
                    input_tab = "10";
                    break;
                case "reha":
                    input_tab = "11";
                    break;
            }

            int groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(input_tab
                , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                , "OCS1003"));
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                    case "reha":
                        groupSer = 1101;
                        break;
                }

            }
            switch (gubun)
            {
                case "drug":
                    groupInfo.Add("bogyong_code", "");
                    groupInfo.Add("bogyong_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");
                    break;
                case "jusa":
                    groupInfo.Add("jusa", "");
                    groupInfo.Add("jusa_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");
                    break;
                case "cpl":
                case "pfe":
                case "apl":
                case "xrt":
                case "chuchi":
                case "susul":
                case "etc":
                case "reha":
                    break;
            }
            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("emergency", "N");


            return groupInfo;
        }

        private Hashtable MakeNewOrderGroup(XEditGrid aSourceLayout, string gubun)
        {
            Hashtable groupInfo = new Hashtable();

            //int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            string input_tab = "";
            switch (gubun)
            {
                case "drug":
                    input_tab = "01";
                    break;
                case "jusa":
                    input_tab = "03";
                    break;
                case "cpl":
                    input_tab = "04";
                    break;
                case "pfe":
                    input_tab = "05";
                    break;
                case "apl":
                    input_tab = "06";
                    break;
                case "xrt":
                    input_tab = "07";
                    break;
                case "chuchi":
                    input_tab = "08";
                    break;
                case "susul":
                    input_tab = "09";
                    break;
                case "etc":
                    input_tab = "10";
                    break;
                case "reha":
                    input_tab = "11";
                    break;

            }

            int groupSer = int.Parse(this.mHangmogInfo.GetNextGroupSer(input_tab
                , this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString()
                , "OCS1003"));
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                    case "reha":
                        groupSer = 1101;
                        break;
                }

            }
            switch (gubun)
            {
                case "drug":
                    groupInfo.Add("bogyong_code", "");
                    groupInfo.Add("bogyong_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");

                    break;
                case "jusa":
                    groupInfo.Add("jusa", "");
                    groupInfo.Add("jusa_name", "");
                    groupInfo.Add("nalsu", "0");
                    groupInfo.Add("wonyoi_order_yn", "Y");

                    break;
                case "cpl":
                case "pfe":
                case "apl":
                case "xrt":
                case "chuchi":
                case "susul":
                case "etc":
                case "reha":
                    break;
            }
            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("emergency", "N");

            return groupInfo;
        }

        /*
        private Hashtable MakeNewOrderGroup(MultiLayout aSourceLayout, string gubun, string aBogyong_code, string aBogyong_name, string aEmergency, string aNalsu, string aWonyoi_order_yn)
        {
            Hashtable groupInfo = new Hashtable();

            int groupSer = (this.mHangmogInfo.GetMaxGroupSer(aSourceLayout) + 1);
            if (groupSer == 1)
            {
                switch (gubun)
                {
                    case "drug":
                        groupSer = 101;
                        break;
                    case "jusa":
                        groupSer = 301;
                        break;
                    case "cpl":
                        groupSer = 401;
                        break;
                    case "pfe":
                        groupSer = 501;
                        break;
                    case "apl":
                        groupSer = 601;
                        break;
                    case "xrt":
                        groupSer = 701;
                        break;
                    case "chuchi":
                        groupSer = 801;
                        break;
                    case "susul":
                        groupSer = 901;
                        break;
                    case "etc":
                        groupSer = 1001;
                        break;
                }

            }

            groupInfo.Add("group_ser", groupSer);
            groupInfo.Add("group_name", groupSer.ToString() + " グループ");
            groupInfo.Add("bogyong_code", aBogyong_code);
            groupInfo.Add("bogyong_name", aBogyong_name);
            groupInfo.Add("emergency", aEmergency);
            groupInfo.Add("nalsu", aNalsu);
            groupInfo.Add("wonyoi_order_yn", aWonyoi_order_yn);

            return groupInfo;
        }
        */

        #region 현재 그룹이 내복약인지 외용약인지 여부

        private bool IsOutDrugGroup(string aGroupSer)
        {
            DataRow[] rows = OrderBox.GrdOrder_Drug.LayoutTable.Select("group_ser=" + aGroupSer);

            if (rows.Length <= 0) return false;

            foreach (DataRow dr in rows)
            {
                if (dr["order_gubun"].ToString() != "" && dr["order_gubun"].ToString().Substring(1, 1) == "D")
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        //private void SetOrderImage(XEditGrid aGrid)
        //{
        //    // 의사가 입력하는 경우는 스킵
        //    if (this.iInputGubun.Substring(0, 1) == "D") return;

        //    for (int i = 0; i < aGrid.RowCount; i++)
        //    {
        //        // 의사 오더인경우
        //        if (aGrid.GetItemString(i, "input_gubun").Substring(0, 1) == "D")
        //        {
        //            aGrid[i + aGrid.HeaderHeights.Count, 0].Image = this.ImageList.Images[8];
        //            aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText = "医師オーダ" + aGrid[i + aGrid.HeaderHeights.Count, 0].ToolTipText;
        //        }
        //    }
        //}

        private void SetVisibleStatusBar(bool aIsVisible)
        {
            OrderBox.PnlStatus.Visible = aIsVisible;
        }

        private void InitStatusBar(int aMaxValue)
        {
            OrderBox.PgbProgress.Minimum = 0;
            OrderBox.PgbProgress.Maximum = aMaxValue;
            OrderBox.LbStatus.Text = "";
        }

        private void SetStatusBar(int aCurrentValue)
        {
            OrderBox.PgbProgress.Value = aCurrentValue;
            OrderBox.PgbProgress.Refresh();
            OrderBox.LbStatus.Text = aCurrentValue.ToString() + "/" + OrderBox.PgbProgress.Maximum.ToString();
            OrderBox.LbStatus.Refresh();
        }

        #region [환자정보 Reques/Receive Event]

        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                //insert into yoonB 2012/03/03
                if (info.ScreenName == "OUT1101Q01")
                {
                    pendingPatient.PatientBox.DtpNaewonDate.SetDataValue(info.HoDong);
                }

                this.fbxBunho.Focus();
                this.fbxBunho.SetEditValue(info.BunHo);
                this.fbxBunho.AcceptData();
                this.Focus();
            }
        }

        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.fbxBunho.GetDataValue()))
            {
                return new XPatientInfo(this.fbxBunho.GetDataValue(), this.lbSuname.Text, "", "", this.ScreenName);
            }

            return null;
        }

        #endregion

        #region [ 내시경 결과 조회 ]


        // 처방행삭제
        private void PopUpMenuPfeResult_Click(object sender, System.EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menu = sender as IHIS.X.Magic.Menus.MenuCommand;

            string targetUrl = "";
            // TODO remove hardcode
            string serverIP = "192.168.150.114";
            //string serverIP = "localhost";

            //            string cmdText = @"SELECT A.CODE_NAME
            //                                 FROM OCS0132 A
            //                                WHERE A.CODE_TYPE   = 'SERVER_IP'
            //                                  AND A.CODE        = 'ENDO'
            //                                  AND A.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
            //                              ;

            //            object retVal = Service.ExecuteScalar(cmdText);

            // Connect cloud
            NuroNUR1001R98PageCountArgs args = new NuroNUR1001R98PageCountArgs();
            args.Code = "ENDO";
            args.CodeType = "SERVER_IP";
            NuroNUR1001R98PageCountResult result =
                CloudService.Instance.Submit<NuroNUR1001R98PageCountResult, NuroNUR1001R98PageCountArgs>(args);

            if (!TypeCheck.IsNull(result))
            {
                serverIP = result.Count;
            }

            switch (menu.Tag.ToString())
            {
                case "3": // 이미지 결과 조회

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=1";//&KEY=12345";
                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }

                    break;

                case "4":

                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=2";//&KEY=12345";
                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }


                    break; // 레포트 결과 조회

                case "5": // 심전도 결과 조회

                    if (this.IsPatientSelected() == true)
                    {
                        EkgCallHelper.CallViewer(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                    }
                    try
                    {
                        //targetUrl = "http://" + serverIP + "/MXFlex/MX.html?UID=MX&PW=V6A3COXDMYEGEDALXNEKKPRE&PID=" + this.fbxBunho.GetDataValue() + "&TYPE=2";//&KEY=12345";
                        //targetUrl = "http://" + serverIP + "/PFE/";//&KEY=12345";

                        //System.Diagnostics.Process.Start(targetUrl);
                    }
                    catch (System.ComponentModel.Win32Exception noBrowser)
                    {
                        MessageBox.Show("browser msg : " + noBrowser.Message);
                    }
                    catch (System.Exception other)
                    {
                        MessageBox.Show("other msg : " + other.Message);
                    }


                    break;
            }
        }

        private void btnENDOResult_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;

            if (this.IsPatientSelected())
            {
                this.mMenuPFEResult.TrackPopup(this.PointToScreen(new Point(button.Location.X, button.Location.Y)));
            }
        }

        private void IsEnableBtnLblDownload(bool isEnable)
        {
            btnDownloadEMR.Visible = isEnable;
            lblDownloadEMR.Visible = isEnable;
        }

        private void SetBtnDownloadEmr(string ulrFile)
        {
            try
            {
                if (string.IsNullOrEmpty(ulrFile))
                {
                    //disable btnDownload and lblDownloadFileName
                    IsEnableBtnLblDownload(false);
                }
                else
                {
                    IsEnableBtnLblDownload(true);
                    _urlFinal = ulrFile;
                    string pattern = "_EMR_";
                    Regex myRegex = new Regex(pattern);
                    string[] result = myRegex.Split(ulrFile);
                    string dateTime = result[1].Substring(0, result[1].Length - 4);

                    string format = "yyyyMMddHHmmss";
                    DateTime aDateTime = DateTime.ParseExact(dateTime, format, CultureInfo.InvariantCulture);
                    //set to Lable
                    lblDownloadEMR.Text = aDateTime.ToString();
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of SetBtnDownloadEmr() " + ex.StackTrace);
            }
        }

        private void btnBackupEMR_Click(object sender, EventArgs e)
        {
            BackgroundWorkerBackupEmr();
        }

        private void BackgroundWorkerBackupEmr()
        {
            try
            {
                BackgroundWorker bwDownload = new BackgroundWorker();
                bwDownload.WorkerReportsProgress = true;
                bwDownload.WorkerSupportsCancellation = true;
                bwDownload.DoWork += new DoWorkEventHandler(bwBackupEmr_DoWork);
                bwDownload.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bwBackupEmr_RunWorkerCompleted);

                if (bwDownload.IsBusy != true)
                {
                    btnBackupEMR.Enabled = false;
                    bwDownload.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("DOWNLOAD ERROR: " + ex.Message);
                Service.WriteLog("Stack trace: " + ex.StackTrace);
            }
        }

        private void bwBackupEmr_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                e.Result = null;
                /*int requestBackupEmrTimes = 2;
                bool isOk = Int32.TryParse(ConfigurationSettings.AppSettings.Get("RequestBackupEmrTimes"), out requestBackupEmrTimes);
                for (int i = 1; (i <= requestBackupEmrTimes); i++)
                {*/
                if ((worker.CancellationPending))
                {
                    e.Cancel = true;
                    /*break;*/
                }
                else
                {
                    // Perform a time consuming operation and report progress.
                    OCS2015U00EmrBackTimeRimindArgs args = new OCS2015U00EmrBackTimeRimindArgs();
                    args.IsBackup = true;

                    OCS2015U00EmrBackTimeRimindResult result =
                        CloudService.Instance.Submit<OCS2015U00EmrBackTimeRimindResult, OCS2015U00EmrBackTimeRimindArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        e.Result = result;
                        /*break;*/
                    }
                    else
                    {
                        btnBackupEMR.Enabled = true;
                        XMessageBox.Show(Resources.OCS2015U00_EmrBackTime_Msg_DownloadError, Resources.MSG001_CAP);
                        Service.WriteLog("OCS2015U00EmrBackTimeRimindResult status: " + result.ExecutionStatus);
                    }

                    /*System.Threading.Thread.Sleep(1000);
                    worker.ReportProgress((i * 10));*/
                }
                /*}*/
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of bwBackupEmr_DoWork(): " + ex.StackTrace);
            }
        }

        private void bwBackupEmr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled))
            {
                Service.WriteLog("bwBackupEmr_RunWorkerCompleted status: Canceled!");
            }

            else if (!(e.Error == null))
            {
                Service.WriteLog("bwBackupEmr_RunWorkerCompleted status: Error! " + e.Error.Message);
            }

            else
            {
                Service.WriteLog("bwBackupEmr_RunWorkerCompleted status: Done! ");
                OCS2015U00EmrBackTimeRimindResult reslResult = e.Result as OCS2015U00EmrBackTimeRimindResult;
                if (reslResult != null)
                {
                    if (reslResult.IsLock)
                    {
                        XMessageBox.Show(Resources.OCS2015U00_Msg_ServerIsBusy, Resources.MSG001_CAP);
                    }
                    else
                    {
                        string url = reslResult.UrlFile;
                        /*string url = "http://10.2.9.26/kinki/kinki.zip";*/
                        Service.WriteLog("Url File: " + url);
                        btnBackupEMR.Enabled = true;
                        SetBtnDownloadEmr(url);
                        //DownloadFile(url);
                    }
                }
                else
                {
                    btnBackupEMR.Enabled = true;
                    XMessageBox.Show(Resources.OCS2015U00_EmrBackTime_Msg_DownloadError, Resources.MSG001_CAP);
                }
            }
        }

        private void btnDownloadEMR_Click(object sender, EventArgs e)
        {
            OCS2015U00EmrDownloadFileRimindArgs args = new OCS2015U00EmrDownloadFileRimindArgs();

            OCS2015U00EmrDownloadFileRimindResult result =
                CloudService.Instance.Submit<OCS2015U00EmrDownloadFileRimindResult, OCS2015U00EmrDownloadFileRimindArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                SetBtnDownloadEmr(result.UrlFile);
                DownloadFile(result.UrlFile);
            }
        }

        private void DownloadFile(string url)
        {
            try
            {
                string downloadUri = _urlFinal;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Zip Files|*.zip;*.rar";
                dialog.FilterIndex = 2;
                dialog.RestoreDirectory = true;
                dialog.FileName = UserInfo.HospCode + "_EMR_" + EnvironInfo.GetSysDateTime().ToString("yyyyMMddHHmmss");
                if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.FileName))
                {
                    string savePath = dialog.FileName;

                    // Missing download URI?
                    if (string.IsNullOrEmpty(downloadUri)) return;

                    // Delete existing file (if any)
                    if (File.Exists(savePath))
                    {
                        File.Delete(savePath);
                    }

                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(DownloadCompleted);
                        //client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                        client.DownloadFileAsync(new Uri(downloadUri), savePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error of DownloadFile(): " + ex.StackTrace);
            }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Service.WriteLog(ex.Message);
                Service.WriteLog(ex.StackTrace);
            }
            finally
            {
            }
        }

        private void tabGroupButton_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "tab01":
                    ShowGroupButton1(true);
                    break;
                case "tab02":
                    ShowGroupButton2(true);
                    break;
                case "tab03":
                    ShowGroupButton3(true);
                    break;
            }
        }
        
        private void btnKarteOfOrtherClinics_Click(object sender, EventArgs e)
        {
            if (this.fbxBunho.GetDataValue() == "" ||
                this.mSelectedPatientInfo == null ||
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() == "")
            {
                // No patient was selected
                mbxMsg = Resources.MSG33_MSG;
                mbxCap = Resources.MSG029_CAP;
                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                OpenScreen_OUT2016U00();
            }
        }

        private void OpenScreen_OUT2016U00()
        {
            try
            {
                string bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                string patientName = this.mSelectedPatientInfo.GetPatientInfo["suname"].ToString().ToUpper();
                OUT2016U00 formOut2016U00 = new OUT2016U00(bunho, patientName);
                formOut2016U00.ShowDialog();
                OCS2015U03BindData();
            }
            catch (Exception ex)
            {
                Service.WriteLog("Error OpenScreen_OUT2016U00 method" + ex.StackTrace);
            }
        }

        #endregion

        #region [ 방사선 결과 조회 ]

        private void btnXRTResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                this.OpenScreen_XRT0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ Approve Order creating by the Clerk ]

        public void btnApprove_Click(object sender, EventArgs e)
        {
            this.OpenScreen_OCSAPPROVE(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            this.pbxApprove.Visible =
                this.mOrderBiz.GetNotApproveOrderCnt(this.IO_Gubun, UserInfo.UserID, "Y", "N", "%") > 0 ? true : false;
            this.ctlEmrDocker.Editor.IsInitCtrl = true;
            _isPostLoad = true;
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion [ Approve Order creating by the Clerk ]

        #region [ 검체검사 결과 조회 ]

        private void btnCplResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                //modify bj jc
                this.OpenScreen_CPL0000Q01(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                //this.OpenScreen_CPL0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ 주사 경과 기록 조회 ]

        private void btnJusaResult_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (this.mSelectedPatientInfo != null &&
                this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.OpenScreen_INJ0000Q00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            }
        }

        #endregion

        #region [ EMR 실행 ]

        private void btnEMR_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                IHIS.Framework.EMRHelper.ExecuteEMR(EMRIOTGubun.OUT,
                    this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                    , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            }
        }

        #endregion

        #region 환자 코맨트

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;
            //if (this.pnlComment.Visible == false)
            //{
            //    this.pacComment.SetCommentInfo(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), "B");
            //    this.pacComment.TabCreate();
            //    this.pnlComment.Visible = true;
            //}
            //else
            //{
            //    this.pnlComment.Visible = false;
            //}
            this.OpenScreen_OUT0106U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        #endregion

        private void tmrPaList_Tick(object sender, EventArgs e)
        {
            //pendingPatient.PatientBox.PatientListQuery(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(), pendingPatient.PatientBox.CboQryGwa.GetDataValue(), pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
        }

        private void OCS1003P01_MouseMove(object sender, MouseEventArgs e)
        {
            this.tmrPaList.Stop();
            this.tmrPaList.Start();
        }

        private void btnJinryoReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected())
            {
                this.OpenScreen_RES1001U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                    this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(),
                    this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                    this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            }
        }

        private void grdPatientList_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void btnDoOrder_Click(object sender, EventArgs e)
        {
            //if (this.IsPatientSelected() == false) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.OutOrder;
                this.OpenScreen_OCS1003Q09(false);
            }
        }

        private void OpenScreen_OCS1003Q09(bool aIsAutoClose)
        {
            // 처방 입력 가능 여부

            //해당 내원의 처방정보를 가져온다.
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("bunho", mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa",
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("doctor", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else
            {
                openParams.Add("gwa", mSelectedPatientInfo.GetPatientInfo["gwa"].ToString());
                openParams.Add("doctor", mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());
            }

            openParams.Add("naewon_key", mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            openParams.Add("naewon_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            //openParams.Add("tel_yn"     , "N"); // 간호 입력분은 뺀다 
            openParams.Add("tel_yn", "%"); // 약만 타러온 환자건도 있다

            openParams.Add("auto_close", aIsAutoClose);
            openParams.Add("input_tab", "%");
            openParams.Add("io_gubun", this.IO_Gubun);

            openParams.Add("childYN", "N");
            openParams.Add("patient_info", this.mSelectedPatientInfo);

            //전처방조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSO", "OCS1003Q09", ScreenOpenStyle.ResponseSizable, openParams);
        }

        private void OpenScreen_OCS0301Q09(bool aIsAutoClose)
        {

            string naewon_date =
                pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().PadRight(10).Substring(0, 10).Replace("-", "/");

            CommonItemCollection openParams = new CommonItemCollection();


            openParams.Add("input_tab", "%");
            openParams.Add("naewon_key", mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());
            if (this.mDoctorLogin)
                openParams.Add("input_gubun", OrderBox.TabInputGubun.SelectedTab.Tag.ToString());
            else
                openParams.Add("input_gubun", this.mInputGubun);

            if (UserInfo.Gwa == "CK")
            {
                openParams.Add("gwa",
                    this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString().Substring(0, 2));
                openParams.Add("memb", this.mSelectedPatientInfo.GetPatientInfo["approve_doctor"].ToString());
            }
            else if (UserInfo.UserGubun == UserType.Doctor)
            {
                openParams.Add("gwa", UserInfo.Gwa);
                openParams.Add("memb", UserInfo.DoctorID);
            }
            else if (UserInfo.UserGubun == UserType.Nurse)
            {
                openParams.Add("gwa", TypeCheck.NVL(UserInfo.HoDong, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }
            else
            {
                openParams.Add("gwa", TypeCheck.NVL(this.mInputPart, UserInfo.Gwa));
                openParams.Add("memb", UserInfo.UserID);
            }

            openParams.Add("io_gubun", "O");
            openParams.Add("patient_info", this.mSelectedPatientInfo);
            openParams.Add("protocol_id", protocolId);

            //약속코드조회 화면 Open
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0301Q09", ScreenOpenStyle.ResponseSizable, openParams);

        }

        private void cboJinryoGwa_SelectedValueChanged(object sender, EventArgs e)
        {
            // 환자상병조회
            this.LoadOutSang(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()
                , this.cboJinryoGwa.GetDataValue().ToString());
        }

        private void btnSetOrder_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            if (mSelectedPatientInfo.GetPatientInfo["bunho"].ToString() != "")
            {
                this.mOrderMode = OrderVariables.OrderMode.OutOrder;
                this.OpenScreen_OCS0301Q09(false);
            }

        }

        private void dwOrderInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnJinryoComment_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OUT0123U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString()
                , this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString());

            if (this.mDoctorLogin)
            {
                int etcJinryoCommentCnt =
                    this.mOrderBiz.GetOutJinryoCommentCnt(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                        this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString(),
                        this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString(),
                        this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString());

                if (etcJinryoCommentCnt > 0)
                {
                    this.pbxJinryoComment.Visible = true;
                }
                else
                {
                    this.pbxJinryoComment.Visible = false;
                }
            }
        }

        private void btnKensaReserPrint_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_NUR1001R98(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void btnAllergy_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_NUR1016U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
        }

        private void signalPictureBox_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            this.OpenScreen_NUR1016U00(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
            resetSignalPicture();
            CheckButtonAllergy();
/*            
            ResetButton();*/
        }       
        private void resetSignalPicture()
        {
            this.signalPictureBox.Image = global::IHIS.OCSO.Properties.Resources.btnCurrentAllagent;
            //this.signalPictureBox.Location = new System.Drawing.Point(234, 1);            
            if (NetInfo.Language != LangMode.Jr)
            {
                this.signalPictureBox.Location = new System.Drawing.Point(53, 28);
            }
            else
            {
                this.signalPictureBox.Location = new System.Drawing.Point(53, 24);
            }
            this.signalPictureBox.Location = new System.Drawing.Point(53, 24);
            this.signalPictureBox.Size = new System.Drawing.Size(18, 18);
        }

        private void signalPictureBox2_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;
            CommonItemCollection allergyOpen = new CommonItemCollection();
            if (!string.IsNullOrEmpty(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()))
            {
                allergyOpen.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR1017U00", ScreenOpenStyle.ResponseFixed,
                    allergyOpen);
                resetSignalAllergyPicture2();
                CheckButtonAllergy2();                
            }
        }

        private void resetSignalAllergyPicture2()
        {
            this.signalPictureBox2.Image = global::IHIS.OCSO.Properties.Resources.Untitled_1;
            //this.signalPictureBox2.Location = new System.Drawing.Point(257, 1);
            if (NetInfo.Language != LangMode.Jr)
            {
                this.signalPictureBox2.Location = new System.Drawing.Point(74, 28);
            }
            else
            {
                this.signalPictureBox2.Location = new System.Drawing.Point(74, 24);
            }            
            this.signalPictureBox2.Size = new System.Drawing.Size(18, 18);
        }
        private void signalPictureBox3_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;
            CommonItemCollection prams = new CommonItemCollection();
            if (!string.IsNullOrEmpty(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString()))
            {
                prams.Add("bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", ScreenOpenStyle.ResponseFixed,
                    prams);
                this.GetSpecialNoteList(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(), this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString()); 
                resetSignalAllergyPicture3();
                CheckButtonAllergy3(_isCheckFinishExame);
                //ResetButton();
            }
        }

        private void resetSignalAllergyPicture3()
        {
            this.signalPictureBox3.Image = global::IHIS.OCSO.Properties.Resources.Untitled_2;
            //this.signalPictureBox3.Location = new System.Drawing.Point(280, 1);
            if (NetInfo.Language != LangMode.Jr)
            {
                this.signalPictureBox3.Location = new System.Drawing.Point(95, 28);
            }
            else
            {
                this.signalPictureBox3.Location = new System.Drawing.Point(95, 24);
            }             
            this.signalPictureBox3.Size = new System.Drawing.Size(18, 18);
        }

        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdOutSang.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            pendingPatient.PatientBox.GrdPatientList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        private void layQueryLayout_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layQueryLayout.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        private void btnListSB_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert: // 상병입력

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.SangInputCheck(ref this.mMsg) == false)
                    {
                        MessageBox.Show(this.mMsg, XMsg.GetMsg("F001"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int newRow = -1;
                    // 상병 로우 생성 
                    newRow = this.grdOutSang.InsertRow(-1);

                    // 상병 로우의 초기화
                    this.InitializeSangGrid(this.grdOutSang, this.mSelectedPatientInfo, newRow);

                    break;

                //case FunctionType.Delete :
                //    // PHY8003で使われる傷病は削除できないようにする。
                //    e.IsBaseCall = false;

                //    if (IsUsedSangForPHY8003(this.grdOutSang.GetItemString(this.grdOutSang.CurrentRowNumber, "pkoutsang")))
                //    {
                //        XMessageBox.Show("PHY8003で使われている傷病なので削除できません。");
                //        return;
                //    }
                //    break;
            }
        }

        private bool IsUsedSangForPHY8003(string aPKOUTSANG)
        {
            string cmd = @"SELECT COUNT(*) CNT 
                             FROM PHY8003 A 
                            WHERE A.HOSP_CODE   = '" + UserInfo.HospCode + @"'
                              AND A.FKOUTSANG   = '" + aPKOUTSANG + @"'
                              AND A.DATA_KUBUN != 'D'";

            object val = Service.ExecuteScalar(cmd);

            if (int.Parse(val.ToString()) > 0)
                return true;
            else
                return false;
        }


        //insert by jc [未コード化傷病対応]
        private void grdOutSang_Validated(object sender, EventArgs e)
        {
            //XEditGrid grd = sender as XEditGrid;
            //int currentRow = grd.CurrentRowNumber;
            //if (grd.CurrentColName == "display_sang_name" && this.grdOutSang.GetItemString(currentRow, "sang_code") == NotCodeSyoubyou)
            //{
            //    this.grdOutSang.SetItemValue(currentRow, "sang_name", this.grdOutSang.GetItemString(currentRow, "display_sang_name"));
            //}
        }

        private void xbtRehaActedOrder_Click(object sender, EventArgs e)
        {
            if (!this.IsPatientSelected()) return;

            this.OpenScreen_OCS1003Q10(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
                pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());
        }

        #region For Feature E-PortViewer
        private void btnEPortViewer_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsPatientSelected()) return;

                ActionEPortViewer(true);
            }
            catch (Exception ex)
            {

            }
        }

        private OCS2015U00GetInfoEPortViewerResult GetEPortViewer()
        {
            OCS2015U00GetInfoEPortViewerArgs args = new OCS2015U00GetInfoEPortViewerArgs();
            OCS2015U00GetInfoEPortViewerResult result = CloudService.Instance.Submit<OCS2015U00GetInfoEPortViewerResult, OCS2015U00GetInfoEPortViewerArgs>(args);

            return result;
        }

        private void ActionEPortViewer(bool isOpenEPortViewer)
        {
            try
            {
                if (!_isShowBtnEportViewer) return;
                OCS2015U00GetInfoEPortViewerResult result = GetEPortViewer(); //Request get filePath
                if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                {
                    if (isOpenEPortViewer)
                    {
                        string exePath = result.ExePath;
                        OpenAppEPortViewer(exePath);
                        Thread.Sleep(2000);
                    }

                    string lineValue = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                    WriteToTextFile(lineValue, result.FolderPath, isOpenEPortViewer);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("error method ActionEPortViewer()" + ex.StackTrace);
            }
        }

        private void WriteToTextFile(string bunho, string folderPath, bool isOpenEPortViewer)
        {
            try
            {
                if (!_isShowBtnEportViewer) return;
                bunho = Regex.Replace(bunho, "^0*", "");
                EnsureFolder(folderPath, isOpenEPortViewer);
                string fileName = folderPath + "\\" + "患者番号.txt";
                if (!File.Exists(fileName))
                {
                    StreamWriter file = new StreamWriter(fileName, false);
                    file.WriteLine(bunho);
                    file.Close();
                }
                else
                {
                    /*XMessageBox.Show("Can't write to file because...", "Warning");*/
                }
            }
            catch (Exception ex)
            {
                Service.WriteLog("error method WriteToTextFile()" + ex.StackTrace);
            }
        }

        private void EnsureFolder(string path, bool isOpenEPortViewer)
        {
            try
            {
                /*string directoryName = Path.GetDirectoryName(path);
                if ((path.Length > 0) && (!Directory.Exists(path)))
                {
                    Directory.CreateDirectory(path);
                }*/
                path = path.Replace(@"\\", @"\");
                bool exists = System.IO.Directory.Exists(path);
                if (!exists)
                    System.IO.Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                if (isOpenEPortViewer) XMessageBox.Show(Resources.OCS2016U02_EnsureFolder_Don_t_exist_folder + path);
            }
        }

        private void OpenAppEPortViewer(string exePath)
        {
            try
            {
                Process ePortViewerProcess = new Process();
                /*ePortViewerProcess.StartInfo.FileName = @"C:\Scripts\XLXS-CSV.exe";*/
                ePortViewerProcess.StartInfo.FileName = @exePath;
                ePortViewerProcess.Start();
            }
            catch (Exception ex)
            {

            }
        }
        private void ProcessKillEportViewer()
        {
            string proName = "E-PortViewer";
            Process[] processes = Process.GetProcessesByName(proName);
            foreach (Process proc in processes)
            {
                proc.Kill();
            }
        }
        #endregion

        private void OpenScreen_OCS1003Q10(string aBunho, string aOrderDate)
        {
            CommonItemCollection openParam = new CommonItemCollection();

            openParam.Add("bunho", aBunho);
            openParam.Add("order_date", aOrderDate);
            openParam.Add("io_gubun", IO_Gubun);

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS3003Q10", ScreenOpenStyle.ResponseFixed, openParam);
        }

        private void grdOrder_Drug_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {

        }

        private void grdOutSang_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {

            switch (e.ColName)
            {
                case "gwa":
                    //    string cmd = @"SELECT FN_BAS_LOAD_GWA_NAME('" + e.ChangeValue.ToString() + "', '" + this.dtpNaewonDate.GetDataValue() + "') FROM SYS.DUAL";

                    //    object obj = Service.ExecuteScalar(cmd);

                    // Connect cloud

                    OcsoOCS1003P01BasLoadGwaNameArgs args = new OcsoOCS1003P01BasLoadGwaNameArgs();
                    args.Gwa = e.ChangeValue.ToString();
                    args.BuseoYmd = this.DtpNaewonDate.GetDataValue();
                    OcsoOCS1003P01BasLoadGwaNameResult result =
                        CloudService.Instance
                            .Submit<OcsoOCS1003P01BasLoadGwaNameResult, OcsoOCS1003P01BasLoadGwaNameArgs>(args);
                    if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                    {
                        this.grdOutSang.SetItemValue(e.RowNumber, "gwa_name", result.GwaName);
                    }

                    break;
            }
        }

        private void laySaveLayout_QueryStarting(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.GetItemString(i, "order_gubun") == "C"
                    || this.laySaveLayout.GetItemString(i, "order_gubun") == "D")
                {

                }
            }
        }

        private void btnExpandSB_Click(object sender, EventArgs e)
        {
            if (this.mIsExpandedSB)
            {
                /*this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mUnExpandedSBSize);*/
                this.btnExpandSB.ImageIndex = this.mExpandedSBIndex;

                this.mIsExpandedSB = false;
            }
            else
            {
                /*this.pnlSang.Size = new Size(this.pnlSang.Size.Width, this.mExpandedSBSize);*/
                this.btnExpandSB.ImageIndex = this.mUnExpandedSBIndex;

                this.mIsExpandedSB = true;
            }
            this.grdOutSang.Refresh();
        }

        private void btnKensaReser_Click(object sender, EventArgs e)
        {
            if (this.IsPatientSelected() == false) return;

            CommonItemCollection param = new CommonItemCollection();
            param.Add("bunho",
                pendingPatient.PatientBox.GrdPatientList.GetItemValue(
                    pendingPatient.PatientBox.GrdPatientList.CurrentRowNumber, "bunho").ToString());

            param.Add("initial_btn", "C"); //  /*「A」：未実施、「P」：過去、「C」：当日、「F」：未来*/
            param.Add("naewon_date", pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());

            //IHIS.Framework.XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q12", ScreenOpenStyle.ResponseFixed, param);
            this.OpenScreen_NUR1001R98(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());

            //画面が消えるときにもう一回チェック
            //Đèn này không dùng trên EMR
            //this.pbxIsKensaReser.Visible =
            //    this.mOrderBiz.IsKensaReser(this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString(),
            //        this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString());
        }

        private void pbxApprove_Click(object sender, EventArgs e)
        {

        }

        private void btn2015U21_Click(object sender, EventArgs e)
        {
            GetUserOptions();
            SetPbxApproval(false);
            MakeSureOCS2015U21Initialized();
            pendingPatient.ShowDialog(this);
            pendingPatient.Close();
            this._orderBox.btnReserListExpend_Click(this._orderBox, EventArgs.Empty);
            if (_isCheckDataExist)
            {
                this.ctlEmrDocker.dockPanel3.Size = new Size(this.ctlEmrDocker.dockPanel3.Size.Width,
                    this.MExpandedSize);
                _isCheckDataExist = false;
            }      
            ResetButton();
        }

        private void SetPbxApproval(bool aValue)
        {
            this.pbxApprove.Visible = aValue;
        }
        private void MakeSureOCS2015U21Initialized()
        {
            if (pendingPatient.IsDisposed)
            {
                pendingPatient = new MdiDialogS(this);
                pendingPatient.PatientBox.DtpNaewonDate.SetDataValue(
                    /*EnvironInfo.GetSysDate()*/_sysDate.ToString("yyyy/MM/dd").Replace("-", "/"));
                //pendingPatient.PatientBox.PnlUser.Visible = false;
                pendingPatient.PatientBox.UpdateHelpPanel();
                pendingPatient.PatientBox.ReLoadGwaCombo(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue());

                // 주치의 콤보 구성
                pendingPatient.PatientBox.ReLoadDoctorCombo(pendingPatient.PatientBox.DtpNaewonDate.GetDataValue(),
                    pendingPatient.PatientBox.CboQryGwa.GetDataValue());
            }

            if (this.mDoctorLogin == true)
            {
                pendingPatient.PatientBox.PnlUser.Visible = false;
            }
            else
            {
                pendingPatient.PatientBox.PnlUser.Visible = true;
            }
        }


        #region Connect cloud

        /// <summary>
        /// Create data for grid Patient list
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        internal IList<object[]> grdPatientList_CreateData(BindVarCollection varCollection)
        {
            return LoadDataGrdPatientList(grdPatientResult.GrdPatientList);
        }

        internal IList<object[]> grdPatientList_CreateData2015U21(BindVarCollection varCollection)
        {
            return LoadDataGrdPatientList2015U21(grdPatientResultOCS2015U21.GrdPatientList);
        }

        /// <summary>
        /// Convert to List<object[]>s
        /// </summary>
        /// <param name="grdList"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdPatientList(List<OCS1003P01GrdPatientListItemInfo> grdList)
        {
            List<object[]> dataList = new List<object[]>();
            if (grdList != null && grdList.Count > 0)
            {
                foreach (OCS1003P01GrdPatientListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.Bunho,
                        info.NaewonDate,
                        info.Gwa,
                        info.Doctor,
                        info.NaewonType,
                        info.ReserYn,
                        info.JubsuTime,
                        info.ArriveTime,
                        info.Suname,
                        info.Suname2,
                        info.Sex,
                        info.Age,
                        info.GubunName,
                        info.GwaName,
                        info.DoctorName,
                        info.ChojaeName,
                        info.JinryoEndYn,
                        info.PkNaewon,
                        info.NaewonYn,
                        info.SunnabYn,
                        info.JubsuGubun1,
                        info.OtherGwa,
                        info.ConsultYn,
                        info.JubsuGubun2,
                        info.CommonDoctorYn,
                        info.Gubun,
                        info.GroupKey,
                        info.KensaYn,
                        info.UnapproveYn,
                        info.SysId
                    });
                }
            }
            return dataList;
        }

        private List<object[]> LoadDataGrdPatientList2015U21(List<OCS2015U21GrdPatientListItemInfo> grdList)
        {
            List<object[]> dataList = new List<object[]>();
            if (grdList != null && grdList.Count > 0)
            {
                foreach (OCS2015U21GrdPatientListItemInfo info in grdList)
                {
                    dataList.Add(new object[]
                    {
                        info.Bunho,
                        info.NaewonDate,
                        info.Gwa,
                        info.Doctor,
                        info.NaewonType,
                        info.ReserYn,
                        info.JubsuTime,
                        info.ArriveTime,
                        info.Suname,
                        info.Suname2,
                        info.Sex,
                        info.Age,
                        info.GubunName,
                        info.GwaName,
                        info.DoctorName,
                        info.ChojaeName,
                        info.JinryoEndYn,
                        info.PkNaewon,
                        info.NaewonYn,
                        info.SunnabYn,
                        info.JubsuGubun1,
                        info.OtherGwa,
                        info.ConsultYn,
                        info.JubsuGubun2,
                        info.CommonDoctorYn,
                        info.Gubun,
                        info.GroupKey,
                        info.KensaYn,
                        info.UnapproveYn,
                        info.SysId,
                        info.HideYn
                    });
                }
            }
            return dataList;
        }


        private IList<object[]> LoadDataMInputGubunCase3(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
            args.Code = this.mInputGubun;
            OCS1003P01MakeInputGubunTabResult result =
                CloudService.Instance.Submit<OCS1003P01MakeInputGubunTabResult, OCS1003P01MakeInputGubunTabArgs>(args);
            if (result != null)
            {
                List<ComboListItemInfo> tablist = result.TabList;
                foreach (ComboListItemInfo info in tablist)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            return dataList;
        }

        /// <summary>
        /// Load Data Input Gubun with Code = "NR"
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataMInputGubunCase2(BindVarCollection varlist)
        {
            {
                IList<object[]> dataList = new List<object[]>();
                OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
                args.Code = "NR";
                OCS1003P01MakeInputGubunTabResult result = CacheService.Instance.Get<OCS1003P01MakeInputGubunTabArgs, OCS1003P01MakeInputGubunTabResult>(args);
                //OCS1003P01MakeInputGubunTabResult result = CloudService.Instance.Submit<OCS1003P01MakeInputGubunTabResult, OCS1003P01MakeInputGubunTabArgs>(args);
                if (result != null)
                {
                    List<ComboListItemInfo> tablist = result.TabList;
                    foreach (ComboListItemInfo info in tablist)
                    {
                        dataList.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
                return dataList;
            }
        }

        /// <summary>
        /// Load Data Input Gubun with Code = "D0"
        /// 
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        private IList<object[]> LoadDataMInputGubunCase1(BindVarCollection varlist)
        {
            {
                IList<object[]> dataList = new List<object[]>();
                OCS1003P01MakeInputGubunTabArgs args = new OCS1003P01MakeInputGubunTabArgs();
                args.Code = "D0";
                OCS1003P01MakeInputGubunTabResult result = CacheService.Instance.Get<OCS1003P01MakeInputGubunTabArgs, OCS1003P01MakeInputGubunTabResult>(args);

                //OCS1003P01MakeInputGubunTabResult result = CloudService.Instance.Submit<OCS1003P01MakeInputGubunTabResult, OCS1003P01MakeInputGubunTabArgs>(args);
                if (result != null)
                {
                    List<ComboListItemInfo> tablist = result.TabList;
                    foreach (ComboListItemInfo info in tablist)
                    {
                        dataList.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
                return dataList;
            }
        }

        /// <summary>
        /// Get data for grdPatient
        /// </summary>
        /// <param name="aNaewonDate"></param>
        /// <param name="aDoctor"></param>
        /// <returns></returns>
        internal OCS1003P01GrdPatientResult grdPatient_getData(string aNaewonDate, string aDoctor)
        {
            NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
            cntInfo.IoGubun = IO_Gubun;
            cntInfo.UserId = UserInfo.UserID;
            cntInfo.InsteadYn = "Y";
            cntInfo.ApproveYn = "N";
            cntInfo.Key = "%";

            OCS1003P01GrdPatientArgs args = new OCS1003P01GrdPatientArgs();
            args.OrderCnt = cntInfo;
            args.NaewonYn = "%";
            args.NaewonDate = aNaewonDate;
            args.ReserYn = "%";
            args.Doctor = TypeCheck.NVL(aDoctor, "%").ToString();
            if (this.mDoctorLogin)
                args.DoctorModeYn = "Y";
            else
                args.DoctorModeYn = "N";
            args.Bunho = "%";

            OCS1003P01GrdPatientResult grdPatientResult =
                CloudService.Instance.Submit<OCS1003P01GrdPatientResult, OCS1003P01GrdPatientArgs>(args);
            return grdPatientResult;
        }

        internal OCS2015U21GrdPatientResult grdPatient_getDataOCS2015U21(string aNaewonDate, string aDoctor, string PatientCode, string gwa)
        {
            NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
            cntInfo.IoGubun = IO_Gubun;
            cntInfo.UserId = UserInfo.UserID;
            cntInfo.InsteadYn = "Y";
            cntInfo.ApproveYn = "N";
            cntInfo.Key = "%";

            OCS2015U21GrdPatientArgs args = new OCS2015U21GrdPatientArgs();
            args.OrderCnt = cntInfo;
            args.NaewonYn = "%";
            args.NaewonDate = aNaewonDate;
            args.ReserYn = "%";
            args.Doctor = TypeCheck.NVL(aDoctor, "%").ToString();
            if (PatientCode.Length <= 0)
            {
                PatientCode = "%";
            }
            args.Bunho = PatientCode;
            args.Gwa = gwa;
            if (this.mDoctorLogin)
                args.DoctorModeYn = "Y";
            else
                args.DoctorModeYn = "N";
            //args.Bunho = "%";

            OCS2015U21GrdPatientResult grdPatientResult =
                CloudService.Instance.Submit<OCS2015U21GrdPatientResult, OCS2015U21GrdPatientArgs>(args);
            return grdPatientResult;
        }

        /// <summary>
        /// Get data for btnList_Query
        /// </summary>
        /// <param name="aBunho"></param>
        /// <param name="aGwa"></param>
        /// <param name="aNaewonDate"></param>
        /// <param name="aFkout1001"></param>
        /// <param name="aQueryGubun"></param>
        /// <param name="aInputGubun"></param>
        /// <param name="aBunho2"></param>
        /// <param name="aNaewonDate2"></param>
        /// <returns></returns>
        private OcsoOCS1003P01BtnListQueryResult btnList_queryData(string aBunho, string aGwa,
            string aNaewonDate,
            string aFkout1001,
            string aQueryGubun,
            string aInputGubun,
            string aBunho2,
            string aNaewonDate2)
        {
            OcsoOCS1003P01BtnListQueryArgs btnListQueryArgs = new OcsoOCS1003P01BtnListQueryArgs();
            btnListQueryArgs.Bunho = aBunho;
            btnListQueryArgs.Gwa = aGwa;
            btnListQueryArgs.NaewonDate = aNaewonDate;
            btnListQueryArgs.Fkout1001 = aFkout1001;
            btnListQueryArgs.QueryGubun = aQueryGubun;
            btnListQueryArgs.InputGubun = this.mDoctorLogin ? "NR" : aInputGubun;
            btnListQueryArgs.Bunho2 = aBunho2;
            btnListQueryArgs.NaewonDate2 = aNaewonDate2;

            OcsoOCS1003P01BtnListQueryResult listQueryResult =
                CloudService.Instance.Submit<OcsoOCS1003P01BtnListQueryResult, OcsoOCS1003P01BtnListQueryArgs>(
                    btnListQueryArgs);

            return listQueryResult;
        }

        /// <summary>
        /// get data for grdOutSang
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> grdOutSang_grdOutSang(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            string aBunho = varCollection["f_bunho"].VarValue;
            string aNaewonDate = varCollection["f_naewon_date"].VarValue;
            string aGwa = varCollection["f_gwa"].VarValue;
            if (string.IsNullOrEmpty(aBunho) || string.IsNullOrEmpty(aNaewonDate) || string.IsNullOrEmpty(aGwa))
            {
                return lstObject;
            }

            OcsoOCS1003P01GridOutSangArgs gridOutSangArgs = new OcsoOCS1003P01GridOutSangArgs();
            gridOutSangArgs.Bunho = aBunho;
            gridOutSangArgs.NaewonDate = aNaewonDate;
            gridOutSangArgs.Gwa = aGwa;

            OcsoOCS1003P01GridOutSangResult gridOutSangResult =
                CloudService.Instance.Submit<OcsoOCS1003P01GridOutSangResult, OcsoOCS1003P01GridOutSangArgs>(
                    gridOutSangArgs);
            if (gridOutSangResult != null)
            {
                List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfos = gridOutSangResult.GridOutSangItem;
                if (lstGridOutSangInfos != null && lstGridOutSangInfos.Count > 0)
                {
                    lstObject = grdOutSang_convertListInfoToListObject(lstGridOutSangInfos);
                }
            }
            return lstObject;
        }

        /// <summary>
        /// Convert list object OcsoOCS1003P01GridOutSangInfo to List object[]
        /// </summary>
        /// <param name="lstGridOutSangInfo"></param>
        /// <returns></returns>
        private IList<object[]> grdOutSang_convertListInfoToListObject(
            List<OcsoOCS1003P01GridOutSangInfo> lstGridOutSangInfo)
        {
            IList<object[]> lstObject = new List<object[]>();

            if (lstGridOutSangInfo != null && lstGridOutSangInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01GridOutSangInfo gridOutSangInfo in lstGridOutSangInfo)
                {
                    lstObject.Add(new object[]
                    {
                        gridOutSangInfo.Bunho,
                        gridOutSangInfo.Gwa,
                        gridOutSangInfo.GwaName,
                        gridOutSangInfo.IoGubun,
                        gridOutSangInfo.PkSeq,
                        gridOutSangInfo.NaewonDate,
                        gridOutSangInfo.JubsuNo,
                        gridOutSangInfo.LastNaewonDate,
                        gridOutSangInfo.LastDoctor,
                        gridOutSangInfo.LastNaewonType,
                        gridOutSangInfo.LastJubsuNo,
                        gridOutSangInfo.Fkout1001,
                        gridOutSangInfo.Fkinp1001,
                        gridOutSangInfo.InputId,
                        gridOutSangInfo.Ser,
                        gridOutSangInfo.SangCode,
                        gridOutSangInfo.JuSangYn,
                        gridOutSangInfo.SangName,
                        gridOutSangInfo.ModifierName,
                        gridOutSangInfo.SangStartDate,
                        gridOutSangInfo.SangEndDate,
                        gridOutSangInfo.SangEndSayu,
                        gridOutSangInfo.PreModifier1,
                        gridOutSangInfo.PreModifier2,
                        gridOutSangInfo.PreModifier3,
                        gridOutSangInfo.PreModifier4,
                        gridOutSangInfo.PreModifier5,
                        gridOutSangInfo.PreModifier6,
                        gridOutSangInfo.PreModifier7,
                        gridOutSangInfo.PreModifier8,
                        gridOutSangInfo.PreModifier9,
                        gridOutSangInfo.PreModifier10,
                        gridOutSangInfo.PreModifierName,
                        gridOutSangInfo.PostModifier1,
                        gridOutSangInfo.PostModifier2,
                        gridOutSangInfo.PostModifier3,
                        gridOutSangInfo.PostModifier4,
                        gridOutSangInfo.PostModifier5,
                        gridOutSangInfo.PostModifier6,
                        gridOutSangInfo.PostModifier7,
                        gridOutSangInfo.PostModifier8,
                        gridOutSangInfo.PostModifier9,
                        gridOutSangInfo.PostModifier10,
                        gridOutSangInfo.PostModifierName,
                        gridOutSangInfo.SangJindanDate,
                        gridOutSangInfo.Pkoutsang,
                        gridOutSangInfo.DataGubun,
                        gridOutSangInfo.IfDataSendYn,
                        gridOutSangInfo.OrderByKey,
                        gridOutSangInfo.NaewonType,
                        "",
                        gridOutSangInfo.SangEndSayuName
                    });
                }
            }

            return lstObject;
        }

        /// <summary>
        /// Get data for layQueryLayout
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> layQueryLayout_getData(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();

            if (lstOutOrderInfo != null && lstOutOrderInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01LayoutQueryInfo layoutQueryInfo in lstOutOrderInfo)
                {
                    lstObject.Add(new object[]
                    {
                        layoutQueryInfo.InOutKey,
                        layoutQueryInfo.Pkocskey,
                        layoutQueryInfo.Bunho,
                        layoutQueryInfo.OrderDate,
                        layoutQueryInfo.Gwa,
                        layoutQueryInfo.Doctor,
                        layoutQueryInfo.Resident,
                        layoutQueryInfo.NaewonType,
                        layoutQueryInfo.JubsuNo,
                        layoutQueryInfo.InputId,
                        layoutQueryInfo.InputPart,
                        layoutQueryInfo.InputGwa,
                        layoutQueryInfo.InputDoctor,
                        layoutQueryInfo.InputGubun,
                        layoutQueryInfo.InputGubunName,
                        layoutQueryInfo.GroupSer,
                        layoutQueryInfo.InputTab,
                        layoutQueryInfo.InputTabName,
                        layoutQueryInfo.OrderGubun,
                        layoutQueryInfo.OrderGubunName,
                        layoutQueryInfo.GroupYn,
                        layoutQueryInfo.Seq,
                        layoutQueryInfo.SlipCode,
                        layoutQueryInfo.HangmogCode,
                        layoutQueryInfo.HangmogName,
                        layoutQueryInfo.SpecimenCode,
                        layoutQueryInfo.SpecimenName,
                        layoutQueryInfo.Suryang,
                        layoutQueryInfo.SunabSuryang,
                        layoutQueryInfo.SubulSuryang,
                        layoutQueryInfo.OrdDanui,
                        layoutQueryInfo.OrdDanuiName,
                        layoutQueryInfo.DvTime,
                        layoutQueryInfo.Dv,
                        layoutQueryInfo.Dv1,
                        layoutQueryInfo.Dv2,
                        layoutQueryInfo.Dv3,
                        layoutQueryInfo.Dv4,
                        layoutQueryInfo.Nalsu,
                        layoutQueryInfo.SunabNalsu,
                        layoutQueryInfo.Jusa,
                        layoutQueryInfo.JusaName,
                        layoutQueryInfo.JusaSpdGubun,
                        layoutQueryInfo.BogyongCode,
                        layoutQueryInfo.BogyongName,
                        layoutQueryInfo.Emergency,
                        layoutQueryInfo.JaeryoJundalYn,
                        layoutQueryInfo.JundalTable,
                        layoutQueryInfo.JundalPart,
                        layoutQueryInfo.MovePart,
                        layoutQueryInfo.PortableYn,
                        layoutQueryInfo.PowderYn,
                        layoutQueryInfo.HubalChangeYn,
                        layoutQueryInfo.Pharmacy,
                        layoutQueryInfo.DrgPackYn,
                        layoutQueryInfo.Muhyo,
                        layoutQueryInfo.PrnYn,
                        layoutQueryInfo.ToiwonDrgYn,
                        layoutQueryInfo.PrnNurse,
                        layoutQueryInfo.AppendYn,
                        layoutQueryInfo.OrderRemark,
                        layoutQueryInfo.NurseRemark,
                        layoutQueryInfo.Comments,
                        layoutQueryInfo.MixGroup,
                        layoutQueryInfo.Amt,
                        layoutQueryInfo.Pay,
                        layoutQueryInfo.WonyoiOrderYn,
                        layoutQueryInfo.DangilGumsaOrderYn,
                        layoutQueryInfo.DangilGumsaResultYn,
                        layoutQueryInfo.BomOccurYn,
                        layoutQueryInfo.BomSourceKey,
                        layoutQueryInfo.DisplayYn,
                        layoutQueryInfo.SunabYn,
                        layoutQueryInfo.SunabDate,
                        layoutQueryInfo.SunabTime,
                        layoutQueryInfo.HopeDate,
                        layoutQueryInfo.HopeTime,
                        layoutQueryInfo.NurseConfirmUser,
                        layoutQueryInfo.NurseConfirmDate,
                        layoutQueryInfo.NurseConfirmTime,
                        layoutQueryInfo.NursePickupUser,
                        layoutQueryInfo.NursePickupDate,
                        layoutQueryInfo.NursePickupTime,
                        layoutQueryInfo.NurseHoldUser,
                        layoutQueryInfo.NurseHoldDate,
                        layoutQueryInfo.NurseHoldTime,
                        layoutQueryInfo.ReserDate,
                        layoutQueryInfo.ReserTime,
                        layoutQueryInfo.JubsuDate,
                        layoutQueryInfo.JubsuTime,
                        layoutQueryInfo.ActingDate,
                        layoutQueryInfo.ActingTime,
                        layoutQueryInfo.ActingDay,
                        layoutQueryInfo.ResultDate,
                        layoutQueryInfo.DcGubun,
                        layoutQueryInfo.DcYn,
                        layoutQueryInfo.BannabYn,
                        layoutQueryInfo.BannabConfirm,
                        layoutQueryInfo.SourceOrdKey,
                        layoutQueryInfo.OcsFlag,
                        layoutQueryInfo.SgCode,
                        layoutQueryInfo.SgYmd,
                        layoutQueryInfo.IoGubun,
                        layoutQueryInfo.AfterActYn,
                        layoutQueryInfo.BichiYn,
                        layoutQueryInfo.DrgBunho,
                        layoutQueryInfo.SubSusul,
                        layoutQueryInfo.PrintYn,
                        layoutQueryInfo.Chisik,
                        layoutQueryInfo.TelYn,
                        layoutQueryInfo.OrderGubunBas,
                        layoutQueryInfo.InputControl,
                        layoutQueryInfo.SugsugaYn,
                        layoutQueryInfo.JjaeryoYn,
                        layoutQueryInfo.WonyoiCheck,
                        layoutQueryInfo.EmergencyCheck,
                        layoutQueryInfo.SpecimenCheck,
                        layoutQueryInfo.PortportableCheck,
                        layoutQueryInfo.BulyongCheck,
                        layoutQueryInfo.SunabCheck,
                        layoutQueryInfo.DcCheck,
                        layoutQueryInfo.DcGubunCheck,
                        layoutQueryInfo.ConfirmCheck,
                        layoutQueryInfo.ReserYnCheck,
                        layoutQueryInfo.ChisikYn,
                        layoutQueryInfo.NdayYn,
                        layoutQueryInfo.DefaultJaeryoJundalYn,
                        layoutQueryInfo.DefaultWonyoiYn,
                        layoutQueryInfo.SpecificComment,
                        layoutQueryInfo.CommentName,
                        layoutQueryInfo.CommentSysId,
                        layoutQueryInfo.CommentPgmId,
                        layoutQueryInfo.CommentNotNull,
                        layoutQueryInfo.CommentTableId,
                        layoutQueryInfo.CommentColId,
                        layoutQueryInfo.DonbogYn,
                        layoutQueryInfo.OrderGubunBasName,
                        layoutQueryInfo.ActDoctor,
                        layoutQueryInfo.ActBuseo,
                        layoutQueryInfo.ActGwa,
                        layoutQueryInfo.HomeCareYn,
                        layoutQueryInfo.RegularYn,
                        layoutQueryInfo.SortFkocskey,
                        layoutQueryInfo.ChildYn,
                        layoutQueryInfo.IfInputControl,
                        layoutQueryInfo.SlipNslipName,
                        layoutQueryInfo.OrgKey,
                        layoutQueryInfo.ParentKey,
                        layoutQueryInfo.BunCode,
                        layoutQueryInfo.WonnaeDrgYn,
                        layoutQueryInfo.HubalChangeCheck,
                        layoutQueryInfo.DrgPackCheck,
                        layoutQueryInfo.PharmacyCheck,
                        layoutQueryInfo.PowerCheck,
                        layoutQueryInfo.ImsiDrugYn,
                        layoutQueryInfo.GeneralDispYn,
                        layoutQueryInfo.Dv5,
                        layoutQueryInfo.Dv6,
                        layoutQueryInfo.Dv7,
                        layoutQueryInfo.Dv8,
                        layoutQueryInfo.BogyongCodeSub,
                        layoutQueryInfo.BogyongNameSub,
                        layoutQueryInfo.LimitNalsu,
                        layoutQueryInfo.LimitSuryang,
                        layoutQueryInfo.GwaName,
                        layoutQueryInfo.InsteadYn,
                        layoutQueryInfo.ApproveYn,
                        layoutQueryInfo.PostapproveYn,
                        layoutQueryInfo.ActionDoYn,
                        layoutQueryInfo.OrderByKey
                    });
                }
            }
            return lstObject;
        }

        /// <summary>
        /// Get data for combo box gwa
        /// </summary>
        /// <param name="varlist"></param>
        /// <returns></returns>
        internal IList<object[]> LoadDataCboGwa(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboGwaArgs args = new ComboGwaArgs();
            GetDataForComboResult cboListItemResult = CacheService.Instance.Get<ComboGwaArgs, GetDataForComboResult>(args);
            if (cboListItemResult != null)
            {
                List<ComboListItemInfo> cboList = cboListItemResult.ComboDepartmentItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    dataList.Add(new object[]
                    {
                        info.Code,
                        info.CodeName
                    });
                }
            }
            dataList.RemoveAt(0);
            return dataList;
        }

        //tungtx
        /// <summary>
        /// Savelayout
        /// </summary>
        /// <returns></returns>
        private List<OCS1003P01LaySaveLayoutListItemInfo> LoadListFromLaySaveLayout()
        {
            List<OCS1003P01LaySaveLayoutListItemInfo> dataList = new List<OCS1003P01LaySaveLayoutListItemInfo>();
            if (laySaveLayout.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow row in laySaveLayout.LayoutTable.Rows)
                {
                    OCS1003P01LaySaveLayoutListItemInfo info = new OCS1003P01LaySaveLayoutListItemInfo();

                    string test = row["sunab_suryang"].ToString();

                    info.Pkocskey = row["pkocskey"].ToString();
                    info.NaewonType = row["naewon_type"].ToString();
                    info.HangmogCode = row["hangmog_code"].ToString();
                    info.SpecimenCode = row["specimen_code"].ToString();
                    info.Nalsu = row["nalsu"].ToString();
                    info.JundalTable = row["jundal_table"].ToString();
                    //info.AntiCancerYn = row["anti_cancer_yn"].ToString();
                    info.DcGubun = row["dc_gubun"].ToString();
                    info.ActBuseo = row["act_buseo"].ToString();
                    info.AfterActYn = row["after_act_yn"].ToString();
                    //info.SutakYn = row["sutak_yn"].ToString();
                    info.Dv2 = row["dv_2"].ToString();
                    info.NurseRemark = row["nurse_remark"].ToString();
                    info.NurseConfirmDate = row["nurse_confirm_date"].ToString();
                    info.HomeCareYn = row["home_care_yn"].ToString();
                    info.JusaSpdGubun = row["jusa_spd_gubun"].ToString();
                    info.GeneralDispYn = row["general_disp_yn"].ToString();
                    info.BogyongCodeSub = row["bogyong_code_sub"].ToString();
                    info.ApproveYn = row["approve_yn"].ToString();
                    info.Bunho = row["bunho"].ToString();
                    info.InputId = row["input_id"].ToString();
                    info.GroupSer = row["group_ser"].ToString();
                    info.Suryang = row["suryang"].ToString();
                    info.Jusa = row["jusa"].ToString();
                    info.JundalPart = row["jundal_part"].ToString();
                    info.Pay = row["pay"].ToString();
                    info.BannabYn = row["bannab_yn"].ToString();
                    info.OcsFlag = row["ocs_flag"].ToString();
                    info.BichiYn = row["bichi_yn"].ToString();
                    info.PowderYn = row["powder_yn"].ToString();
                    info.Dv3 = row["dv_3"].ToString();
                    info.BomOccurYn = row["bom_occur_yn"].ToString();
                    info.NurseConfirmTime = row["nurse_confirm_time"].ToString();
                    info.RegularYn = row["regular_yn"].ToString();
                    info.DrgPackYn = row["drg_pack_yn"].ToString();
                    info.Dv5 = row["dv_5"].ToString();
                    info.InsteadYn = row["instead_yn"].ToString();
                    info.PostapproveYn = row["postapprove_yn"].ToString();
                    info.OrderDate = row["order_date"].ToString();
                    info.InputPart = row["input_part"].ToString();
                    info.SlipCode = row["slip_code"].ToString();
                    info.OrdDanui = row["ord_danui"].ToString();
                    info.BogyongCode = row["bogyong_code"].ToString();
                    info.MovePart = row["move_part"].ToString();
                    info.ReserDate = row["reser_date"].ToString();
                    info.BannabConfirm = row["bannab_confirm"].ToString();
                    info.SgCode = row["sg_code"].ToString();
                    info.DrgBunho = row["drg_bunho"].ToString();
                    info.HopeDate = row["hope_date"].ToString();
                    info.Dv4 = row["dv_4"].ToString();
                    info.BomSourceKey = row["bom_source_key"].ToString();
                    info.TelYn = row["tel_yn"].ToString();
                    info.InputTab = row["input_tab"].ToString();
                    info.SortFkocskey = row["sort_fkocskey"].ToString();
                    info.Dv6 = row["dv_6"].ToString();
                    //info.InsteadId = row["instead_id"].ToString();
                    info.Gwa = row["gwa"].ToString();
                    info.InputGubun = row["input_gubun"].ToString();
                    info.NdayYn = row["nday_yn"].ToString();
                    info.DvTime = row["dv_time"].ToString();
                    info.Emergency = row["emergency"].ToString();
                    info.Muhyo = row["muhyo"].ToString();
                    info.ReserTime = row["reser_time"].ToString();
                    info.ActDoctor = row["act_doctor"].ToString();
                    info.SgYmd = row["sg_ymd"].ToString();
                    info.SubSusul = row["sub_susul"].ToString();
                    info.HopeTime = row["hope_time"].ToString();
                    info.MixGroup = row["mix_group"].ToString();
                    info.DisplayYn = row["display_yn"].ToString();
                    info.DangilGumsaOrderYn = row["dangil_gumsa_order_yn"].ToString();
                    info.HubalChangeYn = row["hubal_change_yn"].ToString();
                    info.InOutKey = row["in_out_key"].ToString();
                    info.Dv7 = row["dv_7"].ToString();
                    //info.InsteadDate = row["instead_date"].ToString();
                    info.Doctor = row["doctor"].ToString();
                    info.Seq = row["seq"].ToString();
                    info.OrderGubun = row["order_gubun"].ToString();
                    info.Dv = row["dv"].ToString();
                    info.JaeryoJundalYn = row["jaeryo_jundal_yn"].ToString();
                    info.PortableYn = row["portable_yn"].ToString();
                    info.DcYn = row["dc_yn"].ToString();
                    info.ActGwa = row["act_gwa"].ToString();
                    info.IoGubun = row["io_gubun"].ToString();
                    info.WonyoiOrderYn = row["wonyoi_order_yn"].ToString();
                    info.Dv1 = row["dv_1"].ToString();
                    info.OrderRemark = row["order_remark"].ToString();
                    info.NurseConfirmUser = row["nurse_confirm_user"].ToString();
                    info.DangilGumsaResultYn = row["dangil_gumsa_result_yn"].ToString();
                    info.Pharmacy = row["pharmacy"].ToString();
                    info.ImsiDrugYn = row["imsi_drug_yn"].ToString();
                    info.Dv8 = row["dv_8"].ToString();
                    //info.InsteadTime = row["instead_time"].ToString();
                    info.WonnaeDrgYn = row["wonnae_drg_yn"].ToString();
                    info.ActionDoYn = row["action_do_yn"].ToString();
                    info.RowState = row.RowState.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;


        }

        /// <summary>
        /// Create list OCS1003P01LayDeletedDataListItemInfo
        /// </summary>
        /// <returns></returns>
        private List<OCS1003P01LayDeletedDataListItemInfo> LoadListFromLayDeletedData()
        {
            List<OCS1003P01LayDeletedDataListItemInfo> dataList = new List<OCS1003P01LayDeletedDataListItemInfo>();
            for (int i = 0; i < layDeletedData.RowCount; i++)
            {
                OCS1003P01LayDeletedDataListItemInfo info = new OCS1003P01LayDeletedDataListItemInfo();
                info.Pkocskey = layDeletedData.GetItemString(i, "pkocskey");
                info.SourceOrdKey = layDeletedData.GetItemString(i, "source_ord_key");

                dataList.Add(info);
            }

            return dataList;
        }

        /// <summary>
        /// Create list OcsoOCS1003P01GridOutSangInfo
        /// </summary>
        /// <returns></returns>
        private List<OcsoOCS1003P01GridOutSangInfo> LoadListFromGrdOutSang()
        {
            List<OcsoOCS1003P01GridOutSangInfo> dataList = new List<OcsoOCS1003P01GridOutSangInfo>();
            for (int i = 0; i < grdOutSang.RowCount; i++)
            {
                OcsoOCS1003P01GridOutSangInfo info = new OcsoOCS1003P01GridOutSangInfo();
                info.Bunho = grdOutSang.GetItemString(i, "bunho");
                info.Gwa = grdOutSang.GetItemString(i, "gwa");
                info.GwaName = grdOutSang.GetItemString(i, "gwa_name");
                info.IoGubun = grdOutSang.GetItemString(i, "io_gubun");
                info.PkSeq = grdOutSang.GetItemString(i, "pk_seq");
                info.NaewonDate = grdOutSang.GetItemString(i, "naewon_date");
                info.JubsuNo = grdOutSang.GetItemString(i, "jubsu_no");
                info.LastNaewonDate = grdOutSang.GetItemString(i, "last_naewon_date");
                info.LastDoctor = grdOutSang.GetItemString(i, "last_doctor");
                info.LastNaewonType = grdOutSang.GetItemString(i, "last_naewon_type");
                info.LastJubsuNo = grdOutSang.GetItemString(i, "last_jubsu_no");
                info.Fkinp1001 = grdOutSang.GetItemString(i, "fkinp1001");
                info.InputId = grdOutSang.GetItemString(i, "input_id");
                info.Ser = grdOutSang.GetItemString(i, "ser");
                info.SangCode = grdOutSang.GetItemString(i, "sang_code");
                info.JuSangYn = grdOutSang.GetItemString(i, "ju_sang_yn");
                info.SangName = grdOutSang.GetItemString(i, "sang_name");
                info.SangStartDate = grdOutSang.GetItemString(i, "sang_start_date");
                info.SangEndDate = grdOutSang.GetItemString(i, "sang_end_date");
                info.SangEndSayu = grdOutSang.GetItemString(i, "sang_end_sayu");
                info.PreModifier1 = grdOutSang.GetItemString(i, "pre_modifier1");
                info.PreModifier2 = grdOutSang.GetItemString(i, "pre_modifier2");
                info.PreModifier3 = grdOutSang.GetItemString(i, "pre_modifier3");
                info.PreModifier4 = grdOutSang.GetItemString(i, "pre_modifier4");
                info.PreModifier5 = grdOutSang.GetItemString(i, "pre_modifier5");
                info.PreModifier6 = grdOutSang.GetItemString(i, "pre_modifier6");
                info.PreModifier7 = grdOutSang.GetItemString(i, "pre_modifier7");
                info.PreModifier8 = grdOutSang.GetItemString(i, "pre_modifier8");
                info.PreModifier8 = grdOutSang.GetItemString(i, "pre_modifier9");
                info.PreModifier10 = grdOutSang.GetItemString(i, "pre_modifier10");
                info.PreModifierName = grdOutSang.GetItemString(i, "pre_modifier_name");
                info.PostModifier1 = grdOutSang.GetItemString(i, "post_modifier1");
                info.PostModifier2 = grdOutSang.GetItemString(i, "post_modifier2");
                info.PostModifier3 = grdOutSang.GetItemString(i, "post_modifier3");
                info.PostModifier4 = grdOutSang.GetItemString(i, "post_modifier4");
                info.PostModifier5 = grdOutSang.GetItemString(i, "post_modifier5");
                info.PostModifier6 = grdOutSang.GetItemString(i, "post_modifier6");
                info.PostModifier7 = grdOutSang.GetItemString(i, "post_modifier7");
                info.PostModifier8 = grdOutSang.GetItemString(i, "post_modifier8");
                info.PostModifier9 = grdOutSang.GetItemString(i, "post_modifier9");
                info.PostModifier10 = grdOutSang.GetItemString(i, "post_modifier10");
                info.PostModifierName = grdOutSang.GetItemString(i, "post_modifier_name");
                info.SangJindanDate = grdOutSang.GetItemString(i, "sang_jindan_date");
                info.Pkoutsang = grdOutSang.GetItemString(i, "pkoutsang");
                info.DataGubun = grdOutSang.GetItemString(i, "data_gubun");
                info.IfDataSendYn = grdOutSang.GetItemString(i, "if_data_send_yn");
                //info.NaewonType = grdOutSang.GetItemString(i, "naewon_type");
                //info.Fkout1001 = grdOutSang.GetItemString(i, "fkout1001");
                info.ModifierName = grdOutSang.GetItemString(i, "display_sang_name");
                info.SangEndSayuName = grdOutSang.GetItemString(i, "sang_end_sayu_name");
                info.DataRowSate = grdOutSang.GetRowState(i).ToString();
                if (info.DataRowSate.Equals(DataRowState.Added.ToString()))
                {
                    info.DataGubun = "I";
                }
                else if (info.DataRowSate.Equals(DataRowState.Modified.ToString()))
                {
                    info.DataGubun = "U";
                }

                dataList.Add(info);
            }

            if (grdOutSang.DeletedRowTable != null && grdOutSang.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOutSang.DeletedRowTable.Rows)
                {
                    OcsoOCS1003P01GridOutSangInfo info = new OcsoOCS1003P01GridOutSangInfo();
                    info.Bunho = row["bunho"].ToString();
                    info.Gwa = row["gwa"].ToString();
                    info.GwaName = row["gwa_name"].ToString();
                    info.IoGubun = row["io_gubun"].ToString();
                    info.PkSeq = row["pk_seq"].ToString();
                    info.NaewonDate = row["naewon_date"].ToString();
                    info.JubsuNo = row["jubsu_no"].ToString();
                    info.LastNaewonDate = row["last_naewon_date"].ToString();
                    info.LastDoctor = row["last_doctor"].ToString();
                    info.LastNaewonType = row["last_naewon_type"].ToString();
                    info.LastJubsuNo = row["last_jubsu_no"].ToString();
                    info.Fkinp1001 = row["fkinp1001"].ToString();
                    info.InputId = row["input_id"].ToString();
                    info.Ser = row["ser"].ToString();
                    info.SangCode = row["sang_code"].ToString();
                    info.JuSangYn = row["ju_sang_yn"].ToString();
                    info.SangName = row["sang_name"].ToString();
                    info.SangStartDate = row["sang_start_date"].ToString();
                    info.SangEndDate = row["sang_end_date"].ToString();
                    info.SangEndSayu = row["sang_end_sayu"].ToString();
                    info.PreModifier1 = row["pre_modifier1"].ToString();
                    info.PreModifier2 = row["pre_modifier2"].ToString();
                    info.PreModifier3 = row["pre_modifier3"].ToString();
                    info.PreModifier4 = row["pre_modifier4"].ToString();
                    info.PreModifier5 = row["pre_modifier5"].ToString();
                    info.PreModifier6 = row["pre_modifier6"].ToString();
                    info.PreModifier7 = row["pre_modifier7"].ToString();
                    info.PreModifier8 = row["pre_modifier8"].ToString();
                    info.PreModifier8 = row["pre_modifier9"].ToString();
                    info.PreModifier10 = row["pre_modifier10"].ToString();
                    info.PostModifierName = row["pre_modifier_name"].ToString();
                    info.PostModifier1 = row["post_modifier1"].ToString();
                    info.PostModifier2 = row["post_modifier2"].ToString();
                    info.PostModifier3 = row["post_modifier3"].ToString();
                    info.PostModifier4 = row["post_modifier4"].ToString();
                    info.PostModifier5 = row["post_modifier5"].ToString();
                    info.PostModifier6 = row["post_modifier6"].ToString();
                    info.PostModifier7 = row["post_modifier7"].ToString();
                    info.PostModifier8 = row["post_modifier8"].ToString();
                    info.PostModifier9 = row["post_modifier9"].ToString();
                    info.PostModifier10 = row["post_modifier10"].ToString();
                    info.PostModifierName = row["post_modifier_name"].ToString();
                    info.SangJindanDate = row["sang_jindan_date"].ToString();
                    info.Pkoutsang = row["pkoutsang"].ToString();
                    info.DataGubun = row["data_gubun"].ToString();
                    info.IfDataSendYn = row["idata_send_yn"].ToString();
                    info.NaewonType = row["naewon_type"].ToString();
                    info.Fkout1001 = row["fkout1001"].ToString();
                    info.DataRowSate = DataRowState.Deleted.ToString();
                    info.DataGubun = "D";
                    info.ModifierName = row["sang_end_sayu_name"].ToString();
                    dataList.Add(info);
                }
            }
            return dataList;
        }

        /// <summary>
        /// Get data for grdReserOrderList
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        internal IList<object[]> ExecuteQueryOcsoOCS1003P01GridReserOrderListInfo(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            OcsoOCS1003P01GridReserOrderListArgs vOcsoOCS1003P01GridReserOrderListArgs =
                new OcsoOCS1003P01GridReserOrderListArgs();
            vOcsoOCS1003P01GridReserOrderListArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOcsoOCS1003P01GridReserOrderListArgs.NaewonDate = bc["f_naewon_date"] != null
                ? bc["f_naewon_date"].VarValue
                : "";
            OcsoOCS1003P01GridReserOrderListResult result =
                CloudService.Instance
                    .Submit<OcsoOCS1003P01GridReserOrderListResult, OcsoOCS1003P01GridReserOrderListArgs>(
                        vOcsoOCS1003P01GridReserOrderListArgs);
            if (result != null)
            {
                res = grdReserOrderList_createData(result.GridReserOrderList);
            }
            return res;
        }

        private IList<object[]> grdReserOrderList_createData(
            List<OcsoOCS1003P01GridReserOrderListInfo> lstGridReserOrderListInfo)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (lstGridReserOrderListInfo != null && lstGridReserOrderListInfo.Count > 0)
            {
                foreach (OcsoOCS1003P01GridReserOrderListInfo gridReserOrderListInfo in lstGridReserOrderListInfo)
                {
                    lstObject.Add(new object[]
                    {
                        gridReserOrderListInfo.KizyunDate,
                        gridReserOrderListInfo.Gwa,
                        gridReserOrderListInfo.GwaName,
                        gridReserOrderListInfo.Doctor,
                        gridReserOrderListInfo.DoctorName,
                        gridReserOrderListInfo.HangmogCode,
                        gridReserOrderListInfo.HangmogName,
                        gridReserOrderListInfo.JundalTable,
                        gridReserOrderListInfo.JundalPart,
                        gridReserOrderListInfo.JundalPartName,
                        gridReserOrderListInfo.ReserTime,
                        gridReserOrderListInfo.ReserYn,
                        gridReserOrderListInfo.ActYn,
                        gridReserOrderListInfo.OrderDate,
                        gridReserOrderListInfo.Pksch
                    });
                }
            }

            return lstObject;
        }

        /// <summary>
        /// Connect to cloud service. update doctor
        /// </summary>
        /// <param name="aDoctor"></param>
        /// <param name="aGwa"></param>
        /// <param name="aPkNaewonKey"></param>
        /// <returns></returns>
        private bool ProcessUpdateDoctor(string aDoctor, string aGwa, string aPkNaewonKey)
        {
            if (TypeCheck.IsNull(aDoctor) || TypeCheck.IsNull(aGwa) || TypeCheck.IsNull(aPkNaewonKey))
            {
                return false;
            }
            // Connect cloud
            OcsoOCS1003P01UpdateDoctorArgs args = new OcsoOCS1003P01UpdateDoctorArgs();
            args.Doctor = aDoctor;
            args.Gwa = aGwa;
            args.PkNaewon = aPkNaewonKey;

            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, OcsoOCS1003P01UpdateDoctorArgs>(args);
            if (updateResult == null)
            {
                return false;
            }
            return updateResult.Result;
        }

        /// <summary>
        /// xEditGridCell63_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell65_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboJubsuGubunArgs comboJubsuGubunArgs = new ComboJubsuGubunArgs();
            ComboResult comboResult = CacheService.Instance.Get<ComboJubsuGubunArgs, ComboResult>(comboJubsuGubunArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell20_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell20_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboSangEndSayuArgs comboSangEndSayuArgs = new ComboSangEndSayuArgs();
            ComboResult comboResult = CacheService.Instance.Get<ComboSangEndSayuArgs, ComboResult>(comboSangEndSayuArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell63_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell63_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboNaewonYnArgs comboNaewonYnArgs = new ComboNaewonYnArgs();
            ComboResult comboResult = CacheService.Instance.Get<ComboNaewonYnArgs, ComboResult>(comboNaewonYnArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }
            }
            return lstObject;
        }

        /// <summary>
        /// xEditGridCell170_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> xEditGridCell170_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> lstObject = new List<object[]>();
            ComboJusaSpdGubunArgs comboJusaSpdGubunArgs = new ComboJusaSpdGubunArgs();
            ComboResult comboResult = CacheService.Instance.Get<ComboJusaSpdGubunArgs, ComboResult>(comboJusaSpdGubunArgs);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> listItemInfo = comboResult.ComboItem;
                if (listItemInfo != null && listItemInfo.Count > 0)
                {
                    lstObject = ConvertListCombolistItemInfoToListObject(listItemInfo);
                }

            }
            return lstObject;
        }

        #endregion

        #region Convert List<ComboListItemInfo> to List<object[]>

        /// <summary>
        /// ConvertListCombolistItemInfoToListObject
        /// </summary>
        /// <param name="listItemInfos"></param>
        /// <returns></returns>
        private IList<object[]> ConvertListCombolistItemInfoToListObject(List<ComboListItemInfo> listItemInfos)
        {
            IList<object[]> lstObject = new List<object[]>();
            if (listItemInfos != null && listItemInfos.Count > 0)
            {
                foreach (ComboListItemInfo itemInfo in listItemInfos)
                {
                    lstObject.Add(new object[]
                    {
                        itemInfo.Code,
                        itemInfo.CodeName
                    });
                }
            }
            return lstObject;
        }

        #endregion

        public void grdPatientList_PreEndInitializing(object sender, EventArgs eventArgs)
        {
            try
            {
                if (pendingPatient != null)
                {
                    pendingPatient.PatientBox.XEditGridCell63.ExecuteQuery = xEditGridCell63_ExecuteQuery;
                    OrderBox.XEditGridCell170.ExecuteQuery = xEditGridCell170_ExecuteQuery;
                    this.xEditGridCell20.ExecuteQuery = xEditGridCell20_ExecuteQuery;
                }
            }
            catch (Exception e)
            {
                Service.debugFileWrite(e.Message + "\n" + e.StackTrace);
            }
        }

        private void Control_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.ctlEmrDocker.Editor.ReloadLatesTags();
            pendingPatient.PatientBox.Control_DataValidating(sender, e);
            this.GetLatestWarningStatus();
        }

        private bool isReloaded = false;

        public bool IsReloaded
        {
            get { return isReloaded; }
            set { isReloaded = value; }
        }

        private OCS2015U00GetPatientInfoResult _patientResult = null;

        /// <summary>
        /// Get patient infomation in U01
        /// HungNV added
        /// </summary>
        private void GetPatientInfo(bool isRefresh)
        {
            if (this.MSelectedPatientInfo != null && this.MSelectedPatientInfo.Parameter.Bunho != "")
            {
                //this.ctlEmrDocker.Viewer.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;
                //this.ctlEmrDocker.Editor.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;

                try
                {
                    if (isRefresh || _patientResult == null)
                    {
                        OCS2015U00GetPatientInfoArgs args = new OCS2015U00GetPatientInfoArgs();
                        args.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;
                        _patientResult =
                            CloudService.Instance.Submit<OCS2015U00GetPatientInfoResult, OCS2015U00GetPatientInfoArgs>(
                                args);
                    }
                }
                catch
                {
                    XMessageBox.Show("Get patient info failed!");
                }
            }
        }

        /// <summary>
        /// HungNV
        /// Bind data to OCS2015U01 modul
        /// </summary>
       internal void OCS2015U01BindData()
        {
            this.mSelectedPatientInfo.LoadPatientInfo(IHIS.OCS.PatientInfo.QueryMode.NawonFullInfo);

            // Get personal information of patient (name, sex, birthday, gender)
            if (_patientResult != null && _patientResult.ManagePatInfo.Count > 0)
            {
                this.lbSuname.Text = _patientResult.ManagePatInfo[0].PatientName1.ToString();
                this.lbSuname2.Text = _patientResult.ManagePatInfo[0].PatientName2.ToString();
                this.lbSexAge.Text = _patientResult.ManagePatInfo[0].Sex.ToString();
                if (!String.IsNullOrEmpty(_patientResult.ManagePatInfo[0].Birth.ToString()))
                {
                    if (String.IsNullOrEmpty(_patientResult.ManagePatInfo[0].Sex.ToString()))
                    {
                        this.lbBirthDay.Text = _patientResult.ManagePatInfo[0].Birth.ToString().Substring(0, 10).Trim().Replace("-", "/");
                    }
                    else
                    {
                        this.lbBirthDay.Text = _patientResult.ManagePatInfo[0].Sex.ToString() + _defaultSpace +
                            _patientResult.ManagePatInfo[0].Birth.ToString().Substring(0, 10).Trim().Replace("-", "/");
                    }
                }
            }

            // Get physical measurements of patient
            if (_patientResult != null && _patientResult.PhyInfoItem.Count > 0)
            {
                //this.lbWeight.Text = _patientResult.PhyInfoItem[0].Weight.ToString() + " Kg";
                //this.lbHeight.Text = _patientResult.PhyInfoItem[0].Height.ToString() + " cm";
                //this.lbCircuit.Text = _patientResult.PhyInfoItem[0].Pulse.ToString();
                //this.lbTemperature.Text = _patientResult.PhyInfoItem[0].BodyHeat.ToString();
                //this.lbSpo2.Text = _patientResult.PhyInfoItem[0].Spo2.ToString();
                //this.lbBreathingRate.Text = _patientResult.PhyInfoItem[0].Breath.ToString();
                //this.lbHeightAndWeight.Text = this.lbHeight.Text + _defaultSpace + this.lbWeight.Text;
                //this.lbBloodpressureH.Text = _patientResult.PhyInfoItem[0].BpTo.ToString() + " / " +
                //                            _patientResult.PhyInfoItem[0].BpFrom.ToString();
                //this.lbBloodpressureL.Text = _patientResult.PhyInfoItem[0].BpFrom.ToString();
                if (lbWeight.Visible == true)
                {
                    this.lbWeight.Text = _patientResult.PhyInfoItem[0].Weight.ToString() + " Kg";
                }
                else
                {
                    this.lbWeight.Text = "";
                }

                if (lbHeight.Visible == true)
                {
                    this.lbHeight.Text = _patientResult.PhyInfoItem[0].Height.ToString() + " cm";
                }
                else
                {
                    this.lbHeight.Text = "";
                }
                if (lbCircuit.Visible == true)
                {
                    this.lbCircuit.Text = _patientResult.PhyInfoItem[0].Pulse.ToString() + Resources.OCS2016U02_lbCircuitUnit;
                }
                else
                {
                    this.lbCircuit.Text = "";
                }
                if (lbTemperature.Visible == true)
                {
                    this.lbTemperature.Text = _patientResult.PhyInfoItem[0].BodyHeat.ToString() + Resources.OCS2016U02_lbTemperatureUnit;
                }
                else
                {
                    this.lbTemperature.Text = "";
                }
                if (lbSpo2.Visible == true)
                {
                    this.lbSpo2.Text = Resources.OCS2016U02_LblSpO2 + _patientResult.PhyInfoItem[0].Spo2.ToString();
                }
                else
                {
                    this.lbSpo2.Text = "";
                }
                if (lbBreathingRate.Visible == true)
                {
                    this.lbBreathingRate.Text = _patientResult.PhyInfoItem[0].Breath.ToString() + Resources.OCS2016U02_lbBreathingRate_Unit;
                }
                else
                {
                    this.lbBreathingRate.Text = "";
                }
                if (lbHeightAndWeight.Visible == true)
                {
                    this.lbHeightAndWeight.Text = this.lbHeight.Text + _defaultSpace + this.lbWeight.Text;
                }
                else
                {
                    this.lbHeightAndWeight.Text = "";
                }
                if (lbBloodpressureH.Visible == true)
                {
                    this.lbBloodpressureH.Text = Resources.OCS2016U02_LblBpFromTo + _patientResult.PhyInfoItem[0].BpTo.ToString() + " / " +
                                                 _patientResult.PhyInfoItem[0].BpFrom.ToString() + _defaultSpace;                                     
                }
                else
                {
                    this.lbBloodpressureH.Text = "";
                }
                //if (lbBloodpressureL.Visible == true)
                //{
                //    this.lbBloodpressureL.Text = _patientResult.PhyInfoItem[0].BpFrom.ToString() + " / ";
                //}
                //else
                //{
                //    this.lbBloodpressureL.Text = "";
                //}
      
                //New lable
               
                this.lbBreathAndBodyHeatAndPulse.Text = this.lbBreathingRate.Text 
                                                        + _defaultSpace + this.lbTemperature.Text 
                                                        + _defaultSpace + this.lbCircuit.Text  ;
                this.lbBpFromAndToAndSpo2.Text = this.lbBloodpressureH.Text + this.lbSpo2.Text;                                   
            }
            else
            {
                //this.lbWeight.Text = "0 Kg";
                //this.lbHeight.Text = "0 cm";
                //this.lbBloodpressureH.Text = "0/0 ";
                //this.lbBloodpressureL.Text = "0";
                //this.lbCircuit.Text = "0";
                //this.lbTemperature.Text = "0";
                //this.lbSpo2.Text = "0";
                //this.lbBreathingRate.Text = "0";

                //comment for MED-6228
                this.lbWeight.Text = "";
                this.lbHeight.Text = "";
                this.lbBloodpressureH.Text = "";
                this.lbBloodpressureL.Text = "";
                this.lbCircuit.Text = "";
                this.lbTemperature.Text = "";
                this.lbSpo2.Text = "";
                this.lbBreathingRate.Text = "";
                this.lbHeightAndWeight.Text = "";
                this.lbBreathAndBodyHeatAndPulse.Text = "";
                this.lbBpFromAndToAndSpo2.Text = "";
            }

        }

        /// <summary>
        /// HungNV added
        /// Bind data to examination history tree view (U03)
        /// </summary>
        private void OCS2015U03BindData()
        {
            /*this.tvExamHist.SetDataForTvExamHist(this.MSelectedPatientInfo.Parameter.Bunho, UserInfo.HospCode,
                this.MSelectedPatientInfo.Parameter.Gwa, true);*/
            this.ucOCS2016U0304.ocS2015U03C1.SetDataForTvExamHist(this.MSelectedPatientInfo.Parameter.Bunho, UserInfo.HospCode,
                this.MSelectedPatientInfo.Parameter.Gwa, true);
            //this.cldExamDates.SetExaminedDates(tvExamHist);
        }

        /// <summary>
        /// HungNV
        /// Bind data to bookmark tree view
        /// </summary>
        private void OCS2015U04BindData(bool isResetEditor)
        {
            OCS2015U06EmrRecordResult result = GetCurrentEmrRecord();
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success && result.EmrRecordList.Count > 0)
            {
                //tvBookmarkList.BookmarkEvent -= FunUpdatedListComment;
                ucOCS2016U0304.ocS2015U04C1.BookmarkEvent -= FunUpdatedListComment;
                List<CommentInfo> listBookmark = new List<CommentInfo>();
                foreach (OCS2015U06EmrRecordInfo info in result.EmrRecordList)
                {
                    this.oldMmlContent = info.Content;
                    //update DictionaryCommentInfo in two UcEditor and UcView after update grid
                    this.ctlEmrDocker.Viewer.Record_id = info.RecordId;
                    this.ctlEmrDocker.Viewer.ucGrid1.LoadGrid(info.Content, GetPatientModel(), NaewonKey, info.Metadata, true, false, null, ScreenEnum.UcView);
                    this.ctlEmrDocker.Editor.ucGrid1.LoadGrid(info.Content, GetPatientModel(), NaewonKey, info.Metadata, false, true, null, ScreenEnum.UcEditor);                    
                    this.ctlEmrDocker.Viewer.ucGrid1.LoadGridCombobox();
                    if (!string.IsNullOrEmpty(info.Metadata))
                    {
                        listBookmark = JsonConvert.DeserializeObject<List<CommentInfo>>(info.Metadata);
                    }
                }
                //TOdo: Implement latter (Bookmark) Rem by anh.lai
                /*tvBookmarkList.IsEnableRightClick = _isEnableGrd ? true : false;
                tvBookmarkList.DisplayBookmarkHistory(result.EmrRecordList[0].RecordId,
                    this.MSelectedPatientInfo.Parameter.Bunho, listBookmark, this.MSelectedPatientInfo.Parameter.Gwa,
                    this.ctlEmrDocker, null);
                tvBookmarkList.BookmarkEvent += FunUpdatedListComment;*/

                ucOCS2016U0304.ocS2015U04C1.IsEnableRightClick = _isEnableGrd ? true : false;
                ucOCS2016U0304.ocS2015U04C1.DisplayBookmarkHistory(result.EmrRecordList[0].RecordId,
                    this.MSelectedPatientInfo.Parameter.Bunho, listBookmark, this.MSelectedPatientInfo.Parameter.Gwa,
                    this.ctlEmrDocker, null);
                ucOCS2016U0304.ocS2015U04C1.BookmarkEvent += FunUpdatedListComment;
            }
            else
            {
                this.ctlEmrDocker.Viewer.ucGrid1.PatientModel = GetPatientModel();
                this.ctlEmrDocker.Editor.ucGrid1.CreateCurrentDataSource();
            }
            //Fix bug https://sofiamedix.atlassian.net/browse/MED-10932.
            //WHen Re-select paitent. this.ctlEmrDocker.Editor.ucGrid1.PatientModel=null.=> need init this.ctlEmrDocker.Editor.ucGrid1.PatientModel
            if (this.ctlEmrDocker.Editor.ucGrid1.PatientModel == null)
                this.ctlEmrDocker.Editor.ucGrid1.PatientModel = GetPatientModel();
            //End bug https://sofiamedix.atlassian.net/browse/MED-10932
            if (isResetEditor) this.ctlEmrDocker.Editor.EditorLoadFunc(false);
            this.ctlEmrDocker.Viewer.SetActiveEditEmrBtn();
        }

        private void SetDefaultWhenLoad()
        {
            /*this.ctlEmrDocker.dockPanel3.Size = new Size(this.ctlEmrDocker.dockPanel3.Size.Width, this.MUnExpandedSize);
            this.btnExpand.ImageIndex = this.MExpandedIndex;*/
            this.ctlEmrDocker.dockPanel3.Size = new Size(this.ctlEmrDocker.dockPanel3.Size.Width, this.MUnExpandedSize + 5);
            /*ctlEmrDocker.dockPanel3.Size = new Size(185, 55);*/
            this.MIsExpanded = false;
        }

        void Viewer_EditButtonClick(object sender, UpdateDataEmrAgrs e)
        {
            // After finish editing emr record => Reload and update Data to Emr
            // Update commentsDataDic in EmrEditor
            this.ctlEmrDocker.Editor.ucGrid1.UpdateComment(this.ctlEmrDocker.Editor.ucGrid1.Pkout, e.TagIds, e.CommentList);
            // Update comments were cached
            this.ctlEmrDocker.Editor.ucGrid1.UpdateCommentsCached(this.ctlEmrDocker.Editor.ucGrid1.Pkout);

            this.LoadOcsEmrControlData(false);
            this.SetActiveEmrEditor(true);
        }

        private void FunUpdatedListComment(object sender, BookmarkEventCArgs e)
        {
            //update only UcView
            this.ctlEmrDocker.Viewer.ucGrid1.DeleteOrUpdateDic(e.CommentInfo, e.Remove);
            this.ctlEmrDocker.Editor.ucGrid1.DeleteOrUpdateDic(e.CommentInfo, e.Remove);
        }

        public void LoadOcsEmrControlData(bool resetEditor)
        {
            if (this.MSelectedPatientInfo != null && this.MSelectedPatientInfo.Parameter.Bunho != "")
            {
                this.ResetOcsEmrData(resetEditor);
                //MED-10925
                this.ctlEmrDocker.Viewer.ucGrid1.SetCacheDateTimeFromServer();
                InitHisExamData();
                this.ctlEmrDocker.Viewer.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;
                this.ctlEmrDocker.Editor.Bunho = this.MSelectedPatientInfo.Parameter.Bunho;
                this.ctlEmrDocker.Editor.ucGrid1.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                string mBunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                string naewon_date = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                /*SetDefaultWhenLoad();*/
                _orderBox.SetCollapse();
                //HungNV added
                this.OCS2015U01BindData();
                this.OCS2015U03BindData();
                this.OCS2015U04BindData(resetEditor);
                this.OCS2015U07Binddata();
                this.GetSpecialNoteList(mBunho, naewon_date);
                this.ctlEmrDocker.Viewer.ResetControlFilter();
                this.ctlEmrDocker.Viewer.CurrentPkout = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
            }
            AdditionalBusiness.AdditionalBusiness.ReEnableEditorAndOrder(this.ctlEmrDocker.dockPanel2, this.ctlEmrDocker.dockPanel2);
        }

        private void OCS2015U07Binddata()
        {
            /*this.ctlOCS2015U07.Docker = this.ctlEmrDocker;
            this.ctlOCS2015U07.TagLst = this.ctlEmrDocker.Viewer.ucGrid1.GetListChildrenTagA("");
            this.ctlOCS2015U07.GetProblemList(this.mSelectedPatientInfo.Parameter.Bunho);*/
        }
        private OCS2015U06EmrRecordResult GetCurrentEmrRecord()
        {
            OCS2015U06EmrRecordArgs args = new OCS2015U06EmrRecordArgs();
            args.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
            args.HospCode = UserInfo.HospCode;
            if (CloudService.Instance.Connect())
            {
                return CloudService.Instance.Submit<OCS2015U06EmrRecordResult, OCS2015U06EmrRecordArgs>(args);
            }
            return null;
        }

        private void CheckButtonAllergy()
        {            
            NUR1016U00GrdNUR1016Args args = new NUR1016U00GrdNUR1016Args();
            args.Bunho = mSelectedPatientInfo.Parameter.Bunho;
            if (TypeCheck.IsNull(args.Bunho))
            {
                return;
            }
            NUR1016U00GrdNUR1016Result result =
                CloudService.Instance.Submit<NUR1016U00GrdNUR1016Result, NUR1016U00GrdNUR1016Args>(args);
            if (result != null)
            {
                List<NUR1016U00GrdNUR1016ListItemInfo> grdList = result.GrdNUR1016List;
                foreach (NUR1016U00GrdNUR1016ListItemInfo info in grdList)
                {
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox.Image = global::IHIS.OCSO.Properties.Resources.btnCurrentAllagent;
                    if (!string.IsNullOrEmpty(info.AllergyGubun))
                    {
                        //this.signalPictureBox.Location = new System.Drawing.Point(235, 1);
                        this.signalPictureBox.Location = new System.Drawing.Point(53, 24);
                        //this.signalPictureBox.Size = new System.Drawing.Size(16, 16);
                        this.signalPictureBox.Size = new System.Drawing.Size(18, 18);
                        this.signalPictureBox.Image = ((System.Drawing.Image)(global::IHIS.OCSO.Properties.Resources.grnpuls_blue));
                        _isSignalPictureBox = true;
                        break;
                    }
                }
            }
        }

        private void CheckButtonAllergy2()
        {            
            NUR1017U00GrdNUR1017Args args = new NUR1017U00GrdNUR1017Args();
            args.Bunho = mSelectedPatientInfo.Parameter.Bunho;
            if (TypeCheck.IsNull(args.Bunho))
            {
                return;
            }
            NUR1017U00GrdNUR1017Result result =
                CloudService.Instance.Submit<NUR1017U00GrdNUR1017Result, NUR1017U00GrdNUR1017Args>(args);
            if (result != null)
            {
                List<NUR1017U00GrdNUR1017ListItemInfo> grdList = result.GrdNUR1017List;
                foreach (NUR1017U00GrdNUR1017ListItemInfo info in grdList)
                {
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox2.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_red;
                    //this.signalPictureBox2.Location = new System.Drawing.Point(260, 1);
                    this.signalPictureBox2.Location = new System.Drawing.Point(74, 24);
                    this.signalPictureBox2.Size = new System.Drawing.Size(16, 16);
                    this.signalPictureBox2.Image = ((System.Drawing.Image)(global::IHIS.OCSO.Properties.Resources.grnpuls_red));
                    _isSignalPictureBox2 = true;
                    break;
                }
            }
        }

        private void CheckButtonAllergy3(bool isCheckFinishExam)
        {            
            bool isCheckDataOUT0106U00 = true;
            string naeWonDate = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            OUT0106U00GridListArgs args = new OUT0106U00GridListArgs();
            args.Bunho = mSelectedPatientInfo.Parameter.Bunho;
            args.NaewonDate = naeWonDate;
            if (TypeCheck.IsNull(args.Bunho))
            {
                return;
            }
            OUT0106U00GridListResult result =
                CloudService.Instance.Submit<OUT0106U00GridListResult, OUT0106U00GridListArgs>(args);
            if (result != null)
            {
                List<OUT0106U00GridItemInfo> grdList = result.GridItemInfo;
                List<TagInfo> lstTagInfos = this.ctlEmrDocker.Viewer.ucGrid1.GetListChildrenTagA("");
                List<OcsoOCS1003P01GridOutSangInfo> lstOutSangInfo = LoadListFromGrdOutSang();              
                        
                foreach (OUT0106U00GridItemInfo info in grdList)
                {
                    if (isCheckFinishExam) ctlEmrDocker.GroupExpandForm.NoteSpecial = "";
                    else ctlEmrDocker.GroupExpandForm.NoteSpecial = info.Comments;
                    
                    //this.btnAllergy.ImageIndex = 36;
                    this.signalPictureBox3.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_green;
                    //this.signalPictureBox3.Location = new System.Drawing.Point(285, 1);
                    this.signalPictureBox3.Location = new System.Drawing.Point(95, 24);
                    this.signalPictureBox3.Size = new System.Drawing.Size(16, 16);
                    this.signalPictureBox3.Image = ((System.Drawing.Image)(global::IHIS.OCSO.Properties.Resources.grnpuls_green));
                    isCheckDataOUT0106U00 = false;
                    _isSignalPictureBox3 = true;
                    break;
                }
                if (_isCheckPandingPatient)
                {
                    //GroupExpandForm groupExpandForm = new GroupExpandForm();
                    ctlEmrDocker.GroupExpandForm.NoteSpecial = "";
                    ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(grdList, lstTagInfos, lstOutSangInfo);
                    _isCheckPandingPatient = false;
                }
                else ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(grdList, lstTagInfos, lstOutSangInfo);      
                if (isCheckDataOUT0106U00)
                {
                    //GroupExpandForm groupExpandForm = new GroupExpandForm();
                    ctlEmrDocker.GroupExpandForm.NoteSpecial = "";
                    ctlEmrDocker.GroupExpandForm.LoadExpandedGroup(grdList, lstTagInfos, lstOutSangInfo);                    
                }
            }
        }

        internal void GetSpecialNoteList(string bunho, string naewonDate)
        {
            //DtpNaewonDate
            /*this.ctlOCS2015U05.Comments_Query(bunho, naewonDate);*/

            //New
            // set arguments
            OUT0106U00GridListArgs gridListArgs = new OUT0106U00GridListArgs();
            gridListArgs.Bunho = bunho;
            gridListArgs.NaewonDate = naewonDate;
            // get results
            OUT0106U00GridListResult result = CloudService.Instance.Submit<OUT0106U00GridListResult, OUT0106U00GridListArgs>(gridListArgs);
            if (result != null && result.GridItemInfo.Count > 0)
            {
                /*listSpecialNode.Clear();*/
                listSpecialNode = result.GridItemInfo;
            }
            else
            {
                listSpecialNode.Clear();
            }
        }

        private void InitHisExamData()
        {
            List<DateTime> HisExaminationLst = new List<DateTime>();
            NuroPatientReceptionHistoryListArgs receptHisArg = new NuroPatientReceptionHistoryListArgs();
            receptHisArg.PatientCode = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            NuroPatientReceptionHistoryListResult receptHisResult = CloudService.Instance.Submit<NuroPatientReceptionHistoryListResult, NuroPatientReceptionHistoryListArgs>(receptHisArg);

            if (receptHisResult.ExecutionStatus == ExecutionStatus.Success
                && receptHisResult.PatientReceptionHistoryListItem.Count > 0)
            {
                foreach (NuroPatientReceptionHistoryListItemInfo item in receptHisResult.PatientReceptionHistoryListItem)
                {
                    HisExaminationLst.Add(DateTime.Parse(item.ExamDate.Split(new char[] { ' ' })[0].ToString()));
                    ctlEmrDocker.Viewer.LstHisExamination = HisExaminationLst;
                }
            }
        }

        /*internal void InitHisExam(string bunho)
        {
            this.cldExamDates.LoadHisExam(bunho);
            this.cldExamDates.InitExaminationCalendar();
        }*/

        /*internal void ResetCalendar()
        {
            cldExamDates.ResetCalendar();
        }*/

        // 2015.07.21 AnhNV ADDED
        // TODO MED-3368
        private void GetUserOptions()
        {
            try
            {
                OCS2015U00GetUserOptionsArgs args = new OCS2015U00GetUserOptionsArgs();
                args.Gwa = UserInfo.Gwa;
                args.UserId = UserInfo.UserID;
                args.IoGubun = this.IO_Gubun;
                OCS2015U00GetUserOptionsResult res = CloudService.Instance.Submit<OCS2015U00GetUserOptionsResult, OCS2015U00GetUserOptionsArgs>(args);

                if (res.ExecutionStatus == ExecutionStatus.Success)
                {
                    UserOptions.AllergyPopYn = res.AllergyPopYn;
                    UserOptions.EmrPopYn = res.EmrPopYn;
                    UserOptions.OrderLabelPrtYn = res.OrderLabelPrtYn;
                    UserOptions.SameNameCheckYn = res.SameNameCheckYn;
                    UserOptions.SpecialwritePopYn = res.SpecialwritePopYn;
                    UserOptions.VitalsignsPopYn = res.VitalsignsPopYn;
                    UserOptions.PotionDrugOrder = res.PotionDrugOrder;
                    UserOptions.DiseaseNameUnregistered = res.DiseaseNameUnregistered;
                    UserOptions.Infection = res.Infection;
                    UserOptions.DoOrderPopYn = res.DoOrderPopYn;
                    UserOptions.ReserPrtYn = res.ReserPrtYn;
                    UserOptions.EmrBackRule = res.EmrBackRule;
                    UserOptions.EmrBackTime = res.EmrBackTime;
                    /*UserOptions.EmrBackRule = null;
                    UserOptions.EmrBackTime = "16:11:00";*/
                }
            }
            catch
            {
                XMessageBox.Show("GetUserOptions fail!");
            }
        }

        //HungNV added
        private OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult LoadConsultEndYnAndIsNoConfirmConsult(string aBunho, string aDoctor, string aGwa, string aIOGubun)
        {
            OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs args = new OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs();
            LoadConsultEndYNInfo consultEndYNInfo = new LoadConsultEndYNInfo();
            consultEndYNInfo.Bunho = aBunho;
            consultEndYNInfo.ReqDoctor = aDoctor;
            NoConfirmConsultInfo noConfirmConsultInfo = new NoConfirmConsultInfo();
            noConfirmConsultInfo.Bunho = aBunho;
            noConfirmConsultInfo.Naewondate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString();
            noConfirmConsultInfo.Gwa = aGwa;
            noConfirmConsultInfo.Doctor = aDoctor;
            noConfirmConsultInfo.IoGubun = aIOGubun;

            args.ItemInfo = consultEndYNInfo;
            args.ConfirmConsultInfo = noConfirmConsultInfo;
            return CloudService.Instance.Submit<OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultResult, OCS1003P01LoadConsultEndYnAndIsNoConfirmConsultArgs>(args);

        }

        private void btnTrialPatient_Click(object sender, EventArgs e)
        {
            XButton button = sender as XButton;
            CommonItemCollection param = new CommonItemCollection();
            if (this.IsPatientSelected())
            {
                param.Add("f_bunho", this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString());
                XScreen.OpenScreenWithParam(this, "CLIS", "CLIS2015U02", ScreenOpenStyle.ResponseFixed, param);
            }
        }

        internal void LoadPatientList()
        {
            pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                                        pendingPatient.PatientBox.CboQryGwa.GetDataValue(),
                                                        pendingPatient.PatientBox.CboQryDoctor.GetDataValue());
        }

        internal void LoadPatientList2015U21()
        {
            pendingPatient.PatientBox.PatientListQuery(this.DtpNaewonDate.GetDataValue(),
                                                        pendingPatient.PatientBox.CboGwa.GetDataValue(),
                                                        pendingPatient.PatientBox.FbxDoctor.GetDataValue(),
                                                        pendingPatient.PatientBox.PaBox.BunHo.ToString());
        }

        internal OCS1003P01GetUserOptionAndOrderCountResult GetUserOptionAndOrderCount(string aBunho)
        {
            OCS1003P01GetUserOptionAndOrderCountArgs args = new OCS1003P01GetUserOptionAndOrderCountArgs();
            GetUserOptionInfo userOptionInfo = new GetUserOptionInfo();
            userOptionInfo.Doctor = UserInfo.UserID;
            userOptionInfo.Gwa = UserInfo.Gwa;
            userOptionInfo.Keyword = "DO_ORDER_POP_YN";
            userOptionInfo.IoGubun = this.IO_Gubun;

            GetOrderCountInfo orderCountInfo = new GetOrderCountInfo();
            orderCountInfo.IoGubun = this.IO_Gubun;
            orderCountInfo.Bunho = aBunho;
            orderCountInfo.OrderDate = pendingPatient.PatientBox.DtpNaewonDate.GetDataValue().ToString();

            args.UserOption = userOptionInfo;
            args.OrderCount = orderCountInfo;
            return CloudService.Instance.Submit<OCS1003P01GetUserOptionAndOrderCountResult, OCS1003P01GetUserOptionAndOrderCountArgs>(args);

        }

        private void CheckHideButton()
        {
            CheckHideButtonArgs args = new CheckHideButtonArgs();
            args.CodeType = "btn_OCSEMR_YN";
            hideButtonLst = CacheService.Instance.Get<CheckHideButtonArgs, CheckHideButtonResult>(args, delegate(CheckHideButtonResult r)
            {
                return r.ExecutionStatus == ExecutionStatus.Success && r.Dt.Count > 0;
            });

            if (hideButtonLst != null && hideButtonLst.ExecutionStatus == ExecutionStatus.Success)
            {
                CheckHideButtonInfo item = GetItemHideButton(hideButtonLst.Dt, "btn_EPORTVIEWER");
                if (item != null && item.CodeName.Equals("Y"))
                {
                    _isShowBtnEportViewer = true;
                }
                else
                    _isShowBtnEportViewer = false;
            }

            CheckDiscuss(UserInfo.Gwa);
        }
        

        public void CheckDiscuss(string gwa)
        {
            SettingDiscussArgs args = new SettingDiscussArgs(gwa);
            SettingDiscussResult res = CloudService.Instance.Submit<SettingDiscussResult, SettingDiscussArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                if (res.Result != null && res.Result.Trim() == "Y")
                {
                    /*btnDiscuss.Visible = true;*/
                    LoadDiscussNotify();
                }
                else
                {
                    /*btnDiscuss.Visible = false;*/
                }

                SetBtnDownloadEmr(res.UrlFile);
            }
        }

        private CheckHideButtonInfo GetItemHideButton(List<CheckHideButtonInfo> lst, string code)
        {
            foreach (CheckHideButtonInfo item in lst)
            {
                if (item.Code.Equals(code)) return item;
            }
            return null;
        }

        #region Kinki Checking

        private void KinkiChecking(DataTable grOrder)
        {
            DataTable oldOrderDt = new DataTable();
            oldOrderDt.Columns.Add(new DataColumn("yj_code", typeof(string)));
            oldOrderDt.Columns.Add(new DataColumn("hangmog_code", typeof(string)));
            oldOrderDt.Columns.Add(new DataColumn("hangmog_name", typeof(string)));
            DataTable newOrderDt = oldOrderDt.Clone();
            DataTable allOrderDt = oldOrderDt.Clone();
            if (this.OrderBox.UCOCS2015U12Control != null && this.OrderBox.UCOCS2015U12Control.GrdOrder.RowCount > 0)
            {
                XEditGrid grdOrder = OrderBox.UCOCS2015U12Control.GrdOrder;
                for (int i = 0; i < grdOrder.RowCount; i++)
                {
                    if (grdOrder.GetItemString(i, "yj_code") == "") continue;
                    oldOrderDt.Rows.Add(new object[] { grdOrder.GetItemString(i, "yj_code"), grdOrder.GetItemString(i, "hangmog_code"), grdOrder.GetItemString(i, "hangmog_name") });
                    allOrderDt.Rows.Add(new object[] { grdOrder.GetItemString(i, "yj_code"), grdOrder.GetItemString(i, "hangmog_code"), grdOrder.GetItemString(i, "hangmog_name") });
                }
            }

            if (this.OrderBox.DrugControl != null && this.OrderBox.DrugControl.GrdOrder.RowCount > 0)
            {
                XEditGrid grdOrder = this.OrderBox.DrugControl.GrdOrder;
                for (int i = 0; i < grdOrder.RowCount; i++)
                {
                    if (grdOrder.GetItemString(i, "yj_code") == "") continue;
                    oldOrderDt.Rows.Add(new object[] { grdOrder.GetItemString(i, "yj_code"), grdOrder.GetItemString(i, "hangmog_code"), grdOrder.GetItemString(i, "hangmog_name") });
                    allOrderDt.Rows.Add(new object[] { grdOrder.GetItemString(i, "yj_code"), grdOrder.GetItemString(i, "hangmog_code"), grdOrder.GetItemString(i, "hangmog_name") });
                }
            }

            for (int i = 0; i < grOrder.Rows.Count; i++)
            {
                if (grOrder.Rows[i]["yj_code"].ToString() != "")
                {
                    if (i < grOrder.Rows.Count - 1)
                        oldOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                    else
                        newOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });

                    allOrderDt.Rows.Add(new object[] { grOrder.Rows[i]["yj_code"].ToString(), grOrder.Rows[i]["hangmog_code"].ToString(), grOrder.Rows[i]["hangmog_name"].ToString() });
                }
            }

            try
            {
                this.allWarning = HandlingData.ProcessCheck(allOrderDt, grdOutSang.LayoutTable, oldOrderDt, newOrderDt);
            }
            catch (Exception ex)
            {
                Service.WriteLog("Process check error: " + ex.StackTrace);
            }
        }
        /// <summary>
        /// Get set of orders from ocs0301Q09
        /// </summary>
        /// <param name="drugOrder"></param>
        /// <param name="injOrder"></param>
        /// <returns></returns>
        private DataTable GetSetOrder(MultiLayout drugOrder, MultiLayout injOrder)
        {
            DataTable grdOrder = new DataTable();
            grdOrder.Columns.Add(new DataColumn("yj_code", typeof(string)));
            grdOrder.Columns.Add(new DataColumn("hangmog_code", typeof(string)));
            grdOrder.Columns.Add(new DataColumn("hangmog_name", typeof(string)));


            if (drugOrder.LayoutTable != null && drugOrder.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow item in drugOrder.LayoutTable.Rows)
                {
                    if (item["yj_code"] == "") continue;
                    grdOrder.Rows.Add(new object[] { item["yj_code"], item["hangmog_code"], item["hangmog_name"] });
                }
            }

            if (injOrder.LayoutTable != null && injOrder.LayoutTable.Rows.Count > 0)
            {
                foreach (DataRow item in injOrder.LayoutTable.Rows)
                {
                    if (item["yj_code"] == "") continue;
                    grdOrder.Rows.Add(new object[] { item["yj_code"], item["hangmog_code"], item["hangmog_name"] });
                }
            }
            return grdOrder;
        }
        #endregion

        #region Reload regular Orders
        private void ReLoadRegularOders()
        {
            foreach (KeyValuePair<string, string> kvp in xGridOrderDic)
                ReLoadXeditGridRegular(kvp.Value);
            xGridOrderDic.Clear();
        }
        private void ReLoadXeditGridRegular(string grdOrderName)
        {
            switch (grdOrderName)
            {
                case "OCS0103U10":
                    OrderBox.DrugControl.ReLoadRegularOrder();
                    break;
                case "OCS0103U11":
                    OrderBox.UCOCS2015U11Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U12":
                    OrderBox.UCOCS2015U12Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U13":
                    OrderBox.UCOCS2015U13Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U14":
                    OrderBox.UCOCS2015U14Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U15":
                    OrderBox.UCOCS2015U15Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U16":
                    OrderBox.UCOCS2015U16Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U17":
                    OrderBox.UCOCS2015U17Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U18":
                    OrderBox.UCOCS2015U18Control.ReLoadRegularOrder();
                    break;
                case "OCS0103U19":
                    OrderBox.UCOCS2015U19Control.ReLoadRegularOrder();
                    break;
                default:
                    break;

            }
        }
        #endregion

        #region Apply multi language
        private void ApplyMultiLanguage()
        {
            this.xLabel8.Text = XMsg.GetField("this.xLabel8.Text");
            //this.xLabel7.Text = XMsg.GetField("this.xLabel7.Text");
            this.xLabel8Name.Text = XMsg.GetField("this.xLabel8Name.Text");
            //this.xLabel7Name.Text = XMsg.GetField("this.xLabel7Name.Text");
            this.xLabel3.Text = XMsg.GetField("this.xLabel3.Text");
            this.btnComment.Text = XMsg.GetField("this.btnComment.Text");
            this.btnKensaReser.Text = XMsg.GetField("this.btnKensaReser.Text");
            this.btnKensaReserPrint.Text = XMsg.GetField("this.btnKensaReserPrint.Text");
            this.btnJinryoReser.Text = XMsg.GetField("this.btnJinryoReser.Text");
            this.btnConsult.Text = XMsg.GetField("this.btnConsult.Text");
            this.btnEMR.Text = XMsg.GetField("this.btnEMR.Text");
            this.btnConsultAnswer.Text = XMsg.GetField("this.btnConsultAnswer.Text");
            this.xButton14.Text = XMsg.GetField("this.xButton14.Text");
            this.btnIpwonReser.Text = XMsg.GetField("this.btnIpwonReser.Text");
            this.btnPrescriptionPrint.Text = XMsg.GetField("this.btnPrescriptionPrint.Text");
            this.btnOpenOutSang.Text = XMsg.GetField("this.btnOpenOutSang.Text");
            this.btnOrderPrint.Text = XMsg.GetField("this.btnOrderPrint.Text");
            this.btnOrderGuide.Text = XMsg.GetField("this.btnOrderGuide.Text");
            this.btnJinryoComment.Text = XMsg.GetField("this.btnJinryoComment.Text");
            this.btnDCBANNAB.Text = XMsg.GetField("this.btnDCBANNAB.Text");
            this.btn2015U21.Text = XMsg.GetField("this.btn2015U21.Text");
            this.btnDoOrder.Text = XMsg.GetField("this.btnDoOrder.Text");
            this.btnSetOrder.Text = XMsg.GetField("this.btnSetOrder.Text");
            this.btnAplOrder.Text = XMsg.GetField("this.btnAplOrder.Text");
            this.btnEtcJinryo.Text = XMsg.GetField("this.btnEtcJinryo.Text");
            this.btnQryOrderInfo.Text = XMsg.GetField("this.btnQryOrderInfo.Text");
            this.btnEtcOrder.Text = XMsg.GetField("this.btnEtcOrder.Text");
            this.btnDrgOrder.Text = XMsg.GetField("this.btnDrgOrder.Text");
            this.btnSusulOrder.Text = XMsg.GetField("this.btnSusulOrder.Text");
            this.btnGroupButton3.Text = XMsg.GetField("this.btnGroupButton3.Text");
            this.btnGroupButton2.Text = XMsg.GetField("this.btnEtcOrder.Text");

            if (UserInfo.HospCode == "342")
            {
                this.btnChuchiOrder.Text = "Nha Khoa";
            }
            else
                this.btnChuchiOrder.Text = XMsg.GetField("this.btnChuchiOrder.Text");
            this.btnJusaOrder.Text = XMsg.GetField("this.btnJusaOrder.Text");
            this.btnReha.Text = XMsg.GetField("this.btnReha.Text");
            this.btnCplOrder.Text = XMsg.GetField("this.btnCplOrder.Text");
            this.btnPfeOrder.Text = XMsg.GetField("this.btnPfeOrder.Text");
            this.btnMovieTalk.Text = XMsg.GetField("this.btnMovieTalk.Text");
            this.btnXrtOrder.Text = XMsg.GetField("this.btnXrtOrder.Text");
            this.btnXrtOrderForVi.Text = XMsg.GetField("this.btnXrtOrderForVi.Text");
            this.btnTrialPatient.Text = XMsg.GetField("this.btnTrialPatient.Text");
            this.lblApproveLabel.Text = XMsg.GetField("this.lblApproveLabel.Text");
            this.lblApproveDoctorName.Text = XMsg.GetField("this.lblApproveDoctorName.Text");
            this.lblApproveFlag.Text = XMsg.GetField("this.lblApproveFlag.Text");
            this.lblJinryoGwa.Text = XMsg.GetField("this.lblJinryoGwa.Text");
            this.xLabel1.Text = XMsg.GetField("this.xLabel1.Text");
            this.btnCplResult.Text = XMsg.GetField("this.btnCplResult.Text");
            this.btnENDOResult.Text = XMsg.GetField("this.btnENDOResult.Text");
            this.btnBackupEMR.Text = XMsg.GetField("this.btnBackupEMR.Text");
            this.btnDownloadEMR.Text = XMsg.GetField("this.btnDownloadEMR.Text");
            this.btnKarteOfOrtherClinics.Text = XMsg.GetField("this.btnKarteOfOrtherClinics.Text");
            this.btnJusaResult.Text = XMsg.GetField("this.btnJusaResult.Text");
            this.cbxMsgSysYN.Text = XMsg.GetField("this.cbxMsgSysYN.Text");
            this.btnApprove.Text = XMsg.GetField("this.btnApprove.Text");
            this.btnDiscuss.Text = XMsg.GetField("this.btnDiscuss.Text");

            if (NetInfo.Language != LangMode.Jr)
            {
                this.btnENDOResult.Size = new System.Drawing.Size(150, 28);
                this.btnBackupEMR.Size = new System.Drawing.Size(120, 28);
                this.btnBackupEMR.Location = new System.Drawing.Point(155, 744);
                this.btnDownloadEMR.Size = new System.Drawing.Size(120, 28);
                this.btnDownloadEMR.Location = new System.Drawing.Point(277, 744);
                lblDownloadEMR.Size = new System.Drawing.Size(150, 23);
                lblDownloadEMR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                this.lblDownloadEMR.Location = new System.Drawing.Point(btnDownloadEMR.Location.X + 120 + 2, btnDownloadEMR.Location.Y + 2);
                /*this.btnKarteOfOrtherClinics.Size = new System.Drawing.Size(200, 28);
                this.btnKarteOfOrtherClinics.Location = new System.Drawing.Point(155, 645);*/
            }
            this.tab01.Text = XMsg.GetField("this.tab01.Text");
            this.tab02.Text = XMsg.GetField("this.tab02.Text");
            this.tab03.Text = XMsg.GetField("this.tab03.Text");
            SetTooltipForControls();
        }

        private void SetTooltipForControls()
        {
            tip1.SetToolTip(this.btnComment, this.btnComment.Text);
            tip1.SetToolTip(this.btnKensaReser, this.btnKensaReser.Text);
            tip1.SetToolTip(this.btnKensaReserPrint, this.btnKensaReserPrint.Text);
            tip1.SetToolTip(this.btnJinryoReser, this.btnJinryoReser.Text);
            tip1.SetToolTip(this.btnConsult, this.btnConsult.Text);
            tip1.SetToolTip(this.btnEMR, this.btnEMR.Text);
            tip1.SetToolTip(this.btnConsultAnswer, this.btnConsultAnswer.Text);
            tip1.SetToolTip(this.btnIpwonReser, this.btnIpwonReser.Text);
            tip1.SetToolTip(this.btnOpenOutSang, this.btnOpenOutSang.Text);
            tip1.SetToolTip(this.btnPrescriptionPrint, this.btnPrescriptionPrint.Text);
            tip1.SetToolTip(this.btnOrderPrint, this.btnOrderPrint.Text);
            tip1.SetToolTip(this.btnOrderGuide, this.btnOrderGuide.Text);
            tip1.SetToolTip(this.btnJinryoComment, this.btnJinryoComment.Text);
            tip1.SetToolTip(this.btnDCBANNAB, this.btnDCBANNAB.Text);
            tip1.SetToolTip(this.btn2015U21, this.btn2015U21.Text);
            tip1.SetToolTip(this.btnDoOrder, this.btnDoOrder.Text);
            tip1.SetToolTip(this.btnSetOrder, this.btnSetOrder.Text);
            tip1.SetToolTip(this.btnAplOrder, this.btnAplOrder.Text);
            tip1.SetToolTip(this.btnEtcJinryo, this.btnEtcJinryo.Text);
            tip1.SetToolTip(this.btnQryOrderInfo, this.btnQryOrderInfo.Text);
            tip1.SetToolTip(this.btnEtcOrder, this.btnEtcOrder.Text);
            tip1.SetToolTip(this.btnDrgOrder, this.btnDrgOrder.Text);
            tip1.SetToolTip(this.btnSusulOrder, this.btnSusulOrder.Text);
            tip1.SetToolTip(this.btnChuchiOrder, this.btnChuchiOrder.Text);
            tip1.SetToolTip(this.btnJusaOrder, this.btnJusaOrder.Text);
            tip1.SetToolTip(this.btnReha, this.btnReha.Text);
            tip1.SetToolTip(this.btnCplOrder, this.btnCplOrder.Text);
            tip1.SetToolTip(this.btnPfeOrder, this.btnPfeOrder.Text);
            tip1.SetToolTip(this.btnXrtOrder, this.btnXrtOrder.Text);
            tip1.SetToolTip(this.btnXrtOrderForVi, this.btnXrtOrderForVi.Text);
            tip1.SetToolTip(this.btnTrialPatient, this.btnTrialPatient.Text);
            tip1.SetToolTip(this.btnCplResult, this.btnCplResult.Text);
            tip1.SetToolTip(this.btnENDOResult, this.btnENDOResult.Text);
            tip1.SetToolTip(this.btnMovieTalk, this.btnMovieTalk.Text);
            tip1.SetToolTip(this.btnKarteOfOrtherClinics, this.btnKarteOfOrtherClinics.Text);
            tip1.SetToolTip(this.btnJusaResult, this.btnJusaResult.Text);
            tip1.SetToolTip(this.btnApprove, this.btnApprove.Text);
            tip1.SetToolTip(this.btnDiscuss, this.btnDiscuss.Text);
        }

        private void ApplyMultiLanguageGridOutSang()
        {
            if (NetInfo.Language == LangMode.En)
            {
                this.xEditGridCell2.CellWidth = 105;
                this.xEditGridCell90.CellWidth = 105;
                this.xEditGridCell14.CellWidth = 105;
                this.xEditGridCell15.CellWidth = 105;
                this.xEditGridCell17.CellWidth = 105;
                this.xEditGridCell18.CellWidth = 105;
                this.xEditGridCell19.CellWidth = 105;
                this.xEditGridCell20.CellWidth = 105;
                this.xEditGridCell1764.CellWidth = 105;
                this.xEditGridCell93.CellWidth = 105;
                this.xEditGridCell94.CellWidth = 105;
                this.xEditGridCell43.CellWidth = 105;
                this.xEditGridCell45.CellWidth = 105;
            }
            try
            {
                this.xEditGridCell1.HeaderText = XMsg.GetField("this.xEditGridCell1.HeaderText");
                this.xEditGridCell2.HeaderText = XMsg.GetField("this.xEditGridCell2.HeaderText");
                this.xEditGridCell90.HeaderText = XMsg.GetField("this.xEditGridCell90.HeaderText");
                this.xEditGridCell3.HeaderText = XMsg.GetField("this.xEditGridCell3.HeaderText");
                this.xEditGridCell4.HeaderText = XMsg.GetField("this.xEditGridCell4.HeaderText");
                this.xEditGridCell5.HeaderText = XMsg.GetField("this.xEditGridCell5.HeaderText");
                this.xEditGridCell6.HeaderText = XMsg.GetField("this.xEditGridCell6.HeaderText");
                this.xEditGridCell7.HeaderText = XMsg.GetField("this.xEditGridCell7.HeaderText");
                this.xEditGridCell8.HeaderText = XMsg.GetField("this.xEditGridCell8.HeaderText");
                this.xEditGridCell9.HeaderText = XMsg.GetField("this.xEditGridCell9.HeaderText");
                this.xEditGridCell10.HeaderText = XMsg.GetField("this.xEditGridCell10.HeaderText");
                this.xEditGridCell68.HeaderText = XMsg.GetField("this.xEditGridCell68.HeaderText");
                this.xEditGridCell11.HeaderText = XMsg.GetField("this.xEditGridCell11.HeaderText");
                this.xEditGridCell12.HeaderText = XMsg.GetField("this.xEditGridCell12.HeaderText");
                this.xEditGridCell13.HeaderText = XMsg.GetField("this.xEditGridCell13.HeaderText");
                this.xEditGridCell14.HeaderText = XMsg.GetField("this.xEditGridCell14.HeaderText");
                this.xEditGridCell15.HeaderText = XMsg.GetField("this.xEditGridCell15.HeaderText");
                this.xEditGridCell16.HeaderText = XMsg.GetField("this.xEditGridCell16.HeaderText");
                this.xEditGridCell17.HeaderText = XMsg.GetField("this.xEditGridCell17.HeaderText");
                this.xEditGridCell18.HeaderText = XMsg.GetField("this.xEditGridCell18.HeaderText");
                this.xEditGridCell19.HeaderText = XMsg.GetField("this.xEditGridCell19.HeaderText");
                this.xEditGridCell20.HeaderText = XMsg.GetField("this.xEditGridCell20.HeaderText");
                this.xEditGridCell21.HeaderText = XMsg.GetField("this.xEditGridCell21.HeaderText");
                this.xEditGridCell22.HeaderText = XMsg.GetField("this.xEditGridCell22.HeaderText");
                this.xEditGridCell23.HeaderText = XMsg.GetField("this.xEditGridCell23.HeaderText");
                this.xEditGridCell24.HeaderText = XMsg.GetField("this.xEditGridCell24.HeaderText");
                this.xEditGridCell25.HeaderText = XMsg.GetField("this.xEditGridCell25.HeaderText");
                this.xEditGridCell26.HeaderText = XMsg.GetField("this.xEditGridCell26.HeaderText");
                this.xEditGridCell27.HeaderText = XMsg.GetField("this.xEditGridCell27.HeaderText");
                this.xEditGridCell28.HeaderText = XMsg.GetField("this.xEditGridCell28.HeaderText");
                this.xEditGridCell29.HeaderText = XMsg.GetField("this.xEditGridCell29.HeaderText");
                this.xEditGridCell30.HeaderText = XMsg.GetField("this.xEditGridCell30.HeaderText");
                this.xEditGridCell31.HeaderText = XMsg.GetField("this.xEditGridCell31.HeaderText");
                this.xEditGridCell32.HeaderText = XMsg.GetField("this.xEditGridCell32.HeaderText");
                this.xEditGridCell33.HeaderText = XMsg.GetField("this.xEditGridCell33.HeaderText");
                this.xEditGridCell34.HeaderText = XMsg.GetField("this.xEditGridCell34.HeaderText");
                this.xEditGridCell35.HeaderText = XMsg.GetField("this.xEditGridCell35.HeaderText");
                this.xEditGridCell36.HeaderText = XMsg.GetField("this.xEditGridCell36.HeaderText");
                this.xEditGridCell37.HeaderText = XMsg.GetField("this.xEditGridCell37.HeaderText");
                this.xEditGridCell38.HeaderText = XMsg.GetField("this.xEditGridCell38.HeaderText");
                this.xEditGridCell39.HeaderText = XMsg.GetField("this.xEditGridCell39.HeaderText");
                this.xEditGridCell40.HeaderText = XMsg.GetField("this.xEditGridCell40.HeaderText");
                this.xEditGridCell41.HeaderText = XMsg.GetField("this.xEditGridCell41.HeaderText");
                this.xEditGridCell42.HeaderText = XMsg.GetField("this.xEditGridCell42.HeaderText");
                this.xEditGridCell1764.HeaderText = XMsg.GetField("this.xEditGridCell1764.HeaderText");
                this.xEditGridCell92.HeaderText = XMsg.GetField("this.xEditGridCell92.HeaderText");
                this.xEditGridCell93.HeaderText = XMsg.GetField("this.xEditGridCell93.HeaderText");
                this.xEditGridCell94.HeaderText = XMsg.GetField("this.xEditGridCell94.HeaderText");
                this.xEditGridCell43.HeaderText = XMsg.GetField("this.xEditGridCell43.HeaderText");
                this.xEditGridCell45.HeaderText = XMsg.GetField("this.xEditGridCell45.HeaderText");
                this.xEditGridCell69.HeaderText = XMsg.GetField("this.xEditGridCell69.HeaderText");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                Service.WriteLog(ex.StackTrace);
            }

        }

        #endregion

        private string CACHE_LAST_MSG_TIME = "CACHE_LAST_MSG_TIME_{0}_{1}";
        private void LoadDiscussNotify()
        {
            OCS2015U00GetDiscussNotifyArgs args = new OCS2015U00GetDiscussNotifyArgs();
            OCS2015U00GetDiscussNotifyResult result = CloudService.Instance.Submit<OCS2015U00GetDiscussNotifyResult, OCS2015U00GetDiscussNotifyArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                cacheDataDiscuss = result.Req.ToString() + "," + result.Consult.ToString();
                if (result.Req == "")
                {
                    result.Req = null;
                }
                if (result.Consult == "")
                {
                    result.Consult = null;
                }
                string a =
                    CacheService.Instance.Get<string>(String.Format(CACHE_LAST_MSG_TIME, UserInfo.HospCode,
                        UserInfo.UserID));
                string[] array_date = new string[2];
                if (a == null)
                {
                    array_date[0] = null;
                    array_date[1] = null;
                }
                else
                {
                    array_date = a.Split(',');
                    if (array_date[0] == "")
                    {
                        array_date[0] = null;
                    }
                    if (array_date[1] == "")
                    {
                        array_date[1] = null;
                    }
                }

                if ((Convert.ToDateTime(result.Req) > Convert.ToDateTime(array_date[0]) ||
                     Convert.ToDateTime(result.Consult) > Convert.ToDateTime(array_date[1])))
                {
                    /*this.btnDiscuss.ImageIndex = 0;
                this.btnDiscuss.ImageList = null;*/
                    _isShowPbxNotifyON = true;
                    pbxIsShowSignalBoxButton1.Visible = true;
                    if (_isShowGroupButton1) this.pbxNotifyON.Visible = true;
                    this.pbxNotifyON.Image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\aquapuls.gif");
                }
                else this.pbxNotifyON.Visible = false; 
            }
            else
            {
                _isShowPbxNotifyON = false;
                this.pbxNotifyON.Visible = false;
                pbxIsShowSignalBoxButton1.Visible = false;
                /*this.btnDiscuss.ImageIndex = 22;
                this.btnDiscuss.ImageList = this.ImageList;*/
                //this.pbxNotifyON.Image = Image.FromFile(Environment.CurrentDirectory + "\\Images\\aquapuls.png");
            }

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timer1.Stop();
            LoadDiscussNotify();
            timer1.Start();
        }

        #region Show Tooltip Icon
        private void ShowIcon()
        {
            toolTip = new ToolTip();
            toolTip.ShowAlways = true;
            toolTip.SetToolTip(btnPatientSetting, Resources.btnPatientSetting_Name);
            toolTip.SetToolTip(btnVital, Resources.btnVital_Name);
            toolTip.SetToolTip(signalPictureBox, Resources.signalPictureBox_Name);
            toolTip.SetToolTip(signalPictureBox2, Resources.signalPictureBox2_Name);
            toolTip.SetToolTip(signalPictureBox3, Resources.signalPictureBox3_Name);
            /*toolTip.SetToolTip(btnDoctorView, Resources.btnDoctorView);*/
            this.toolTip.SetToolTip(this.btnDoctorView, XMsg.GetField("this.btnDoctorView.Text"));
            btnPatientSetting.Size = new Size(25, 20);
            btnVital.Size = new Size(25, 20);
            btnShowBrowser.Size = new System.Drawing.Size(20, 20);
            btnDoctorView.Size = new System.Drawing.Size(20, 20);         
        }
        #endregion

        #region Check Notification Signal Picture box

        private void CheckNotificationSignalPiturebox()
        {
            if (_isSignalPictureBox)
            {
                this.signalPictureBox.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_blue;
                _isSignalPictureBox = false;
            }
            else this.signalPictureBox.Image = global::IHIS.OCSO.Properties.Resources.btnCurrentAllagent;

            if (_isSignalPictureBox2)
            {
                this.signalPictureBox2.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_red;
                _isSignalPictureBox2 = false;
            }
            else this.signalPictureBox2.Image = global::IHIS.OCSO.Properties.Resources.Untitled_1;

            if (_isSignalPictureBox3)
            {
                this.signalPictureBox3.Image = global::IHIS.OCSO.Properties.Resources.grnpuls_green;
                _isSignalPictureBox3 = false;
            }
            else this.signalPictureBox3.Image = global::IHIS.OCSO.Properties.Resources.Untitled_2;
        }
        #endregion

        private void SaveEmrCompositeFirst()
        {
            SaveEmrCompositeFirstArgs saveEmrCompositeFirst = new SaveEmrCompositeFirstArgs();

            OcsoOCS1003P01CheckXArgs ocs1003P01CheckXArgs = new OcsoOCS1003P01CheckXArgs();
            ocs1003P01CheckXArgs.ActionDoctor = UserInfo.DoctorID;
            ocs1003P01CheckXArgs.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            ocs1003P01CheckXArgs.NaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();
            saveEmrCompositeFirst.Ocs1003p01Checkx = ocs1003P01CheckXArgs;

            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                CheckPatientStatusArgs checkPatientStatusArgs = new CheckPatientStatusArgs();
                CheckPatientStatusRequestInfo info = new CheckPatientStatusRequestInfo();
                info.Bunho = this.laySaveLayout.GetItemString(i, "bunho");
                info.HangmogCode = this.laySaveLayout.GetItemString(i, "hangmog_code");
                checkPatientStatusArgs.InputInfo = info;
                saveEmrCompositeFirst.CheckPatientStatus.Add(checkPatientStatusArgs);
            }

            OcsoOCS1003P01GetChuciArgs ocsoOCS1003P01GetChuciArgs = new OcsoOCS1003P01GetChuciArgs();
            ocsoOCS1003P01GetChuciArgs.CodeType = "MARUME_ORDER";
            ocsoOCS1003P01GetChuciArgs.ValuePoint = "2";
            saveEmrCompositeFirst.Ocs1003p01GetChuci.Add(ocsoOCS1003P01GetChuciArgs);

            for (int i = 0; i < this.laySaveLayout.RowCount; i++)
            {
                if (this.laySaveLayout.LayoutTable.Rows[i].RowState == DataRowState.Added)
                {
                    DupCheckInputOutOrderInfo inputOutOrderInfo = new DupCheckInputOutOrderInfo();
                    inputOutOrderInfo.Bunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
                    inputOutOrderInfo.NaewonDate = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
                    inputOutOrderInfo.Gwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
                    inputOutOrderInfo.Doctor = this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
                    inputOutOrderInfo.NaewonType = this.mSelectedPatientInfo.GetPatientInfo["naewon_type"].ToString();
                    inputOutOrderInfo.JubsuNo = this.mSelectedPatientInfo.GetPatientInfo["jubsu_no"].ToString();
                    inputOutOrderInfo.HangmogCode = laySaveLayout.GetItemString(i, "hangmog_code");
                    inputOutOrderInfo.HopeDate = laySaveLayout.GetItemValue(i, "hope_date").ToString();
                    DupCheckInputOutOrderArgs dupCheckArgs = new DupCheckInputOutOrderArgs();
                    dupCheckArgs.OutOrderInfo = inputOutOrderInfo;

                    saveEmrCompositeFirst.DupCheckInputOutOrder.Add(dupCheckArgs);
                }
            }

            SaveEmrCompositeFirstResult saveEmrCompositeFirstResult =
                CloudService.Instance.Submit<SaveEmrCompositeFirstResult, SaveEmrCompositeFirstArgs>(
                    saveEmrCompositeFirst, false, CallbackSaveEmrCompositeFirst);
        }

        private Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackSaveEmrCompositeFirst(
            SaveEmrCompositeFirstArgs args, SaveEmrCompositeFirstResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.Ocs1003p01Checkx, new KeyValuePair<int, object>(1, result.Ocs1003p01Checkx));

            for (int i = 0; i < result.CheckPatientStatus.Count; i++)
            {
                if (!cacheOne.ContainsKey(args.CheckPatientStatus[i]))
                    cacheOne.Add(args.CheckPatientStatus[i], new KeyValuePair<int, object>(2, result.CheckPatientStatus[i]));
            }
            for (int i = 0; i < result.DupCheckInputOutOrder.Count; i++)
            {
                if (!cacheOne.ContainsKey(args.DupCheckInputOutOrder[i]))
                    cacheOne.Add(args.DupCheckInputOutOrder[i], new KeyValuePair<int, object>(1, result.DupCheckInputOutOrder[i]));
            }
            for (int i = 0; i < result.Ocs1003p01GetChuci.Count; i++)
            {
                if (!cacheOne.ContainsKey(args.Ocs1003p01GetChuci[i]))
                    cacheOne.Add(args.Ocs1003p01GetChuci[i], new KeyValuePair<int, object>(1, result.Ocs1003p01GetChuci[i]));
            }

            cacheData.Add(CachePolicy.ONCE, cacheOne);
            return cacheData;
        }

        private void SaveEmrCompositeSecond()
        {
            string aBunho = this.mSelectedPatientInfo.GetPatientInfo["bunho"].ToString();
            string aDoctor = this.mSelectedPatientInfo.GetPatientInfo["doctor"].ToString();
            string aGwa = this.mSelectedPatientInfo.GetPatientInfo["gwa"].ToString();
            string aNaewonDate = this.mSelectedPatientInfo.GetPatientInfo["naewon_date"].ToString();
            string aNaewonKey = this.mSelectedPatientInfo.GetPatientInfo["naewon_key"].ToString();

            SaveEmrCompositeSecondArgs compositeSecondArgs = new SaveEmrCompositeSecondArgs();
            OCS1003P01GrdPatientArgs grdPatientArgs = new OCS1003P01GrdPatientArgs();
            NotApproveOrderCntInfo cntInfo = new NotApproveOrderCntInfo();
            cntInfo.IoGubun = N_IO_Gubun;
            cntInfo.UserId = UserInfo.UserID;
            cntInfo.InsteadYn = "Y";
            cntInfo.ApproveYn = "N";
            cntInfo.Key = "%";
            grdPatientArgs.OrderCnt = cntInfo;
            grdPatientArgs.NaewonYn = "%";
            grdPatientArgs.NaewonDate = aNaewonDate;
            grdPatientArgs.ReserYn = "%";
            grdPatientArgs.Doctor = aDoctor;
            if (MDoctorLogin)
                grdPatientArgs.DoctorModeYn = "Y";
            else
                grdPatientArgs.DoctorModeYn = "N";
            grdPatientArgs.Bunho = "%";

            compositeSecondArgs.GrdPatient = grdPatientArgs;

            OcsoOCS1003P01BtnListQueryArgs btnListQueryArgs = new OcsoOCS1003P01BtnListQueryArgs();
            btnListQueryArgs.Bunho = aBunho;
            btnListQueryArgs.Gwa = "%";
            btnListQueryArgs.NaewonDate = aNaewonDate;
            btnListQueryArgs.Fkout1001 = aNaewonKey;
            btnListQueryArgs.QueryGubun = "N";
            btnListQueryArgs.InputGubun = mDoctorLogin ? "NR" : mInputGubun;
            btnListQueryArgs.Bunho2 = aBunho;
            btnListQueryArgs.NaewonDate2 = DtpNaewonDate.GetDataValue();
            compositeSecondArgs.BtnListQuery = btnListQueryArgs;

            NUR1016U00GrdNUR1016Args grdNur1016Args = new NUR1016U00GrdNUR1016Args();
            grdNur1016Args.Bunho = aBunho;
            compositeSecondArgs.GrdNur1016 = grdNur1016Args;

            NUR1017U00GrdNUR1017Args grdNur1017Args = new NUR1017U00GrdNUR1017Args();
            grdNur1017Args.Bunho = aBunho;
            compositeSecondArgs.GrdNur1017 = grdNur1017Args;

            OUT0106U00GridListArgs out0106U00GridListArgs = new OUT0106U00GridListArgs();
            out0106U00GridListArgs.Bunho = aBunho;
            out0106U00GridListArgs.NaewonDate = aNaewonDate;
            compositeSecondArgs.GrdListOut0106 = out0106U00GridListArgs;

            OCS2015U00GetPatientInfoArgs getPatientInfoArgs = new OCS2015U00GetPatientInfoArgs();
            getPatientInfoArgs.Bunho = aBunho;
            compositeSecondArgs.GetPatientInfo = getPatientInfoArgs;

            PatientInfoLoadPatientNaewonListArgs patientNaewonListArgs = new PatientInfoLoadPatientNaewonListArgs();
            patientNaewonListArgs.Bunho = aBunho;
            patientNaewonListArgs.NaewonDateBase = "";
            patientNaewonListArgs.ApproveDoctor = aDoctor;
            patientNaewonListArgs.DoctorModeYn = UserInfo.UserGubun == UserType.Doctor ? "Y" : "N";
            patientNaewonListArgs.IoGubun = "O";
            patientNaewonListArgs.PkKeyOut = aNaewonKey + ".0";
            patientNaewonListArgs.NaewonDate = aNaewonDate;
            patientNaewonListArgs.Gwa = aGwa;
            patientNaewonListArgs.Doctor = aDoctor;
            patientNaewonListArgs.JaewonFlag = TypeCheck.NVL(MPatientInfoParam.JaewonFlag, "Y").ToString();
            patientNaewonListArgs.PkKeyInp = "";
            patientNaewonListArgs.IsEnableIpwonReser = "Y";
            compositeSecondArgs.PatientInfoLoad = patientNaewonListArgs;

            FormEnvironInfoSysDateArgs sysDateArgs = new FormEnvironInfoSysDateArgs();
            compositeSecondArgs.EnvSysDate = sysDateArgs;

            PrOcsLoadNaewonInfoArgs niArgs = new PrOcsLoadNaewonInfoArgs();
            niArgs.NaewonKey = aNaewonKey;
            int index = niArgs.NaewonKey.IndexOf('.');
            if (index >= 0)
            {
                niArgs.NaewonKey = niArgs.NaewonKey.Substring(0, index);
            }
            compositeSecondArgs.OcsLoadNaewon = niArgs;

            OCS2015U09GetTemplateComboBoxArgs templateComboBoxArgs = new OCS2015U09GetTemplateComboBoxArgs();
            templateComboBoxArgs.UserId = UserInfo.UserID;
            compositeSecondArgs.TemplateCombo = templateComboBoxArgs;

            OCS2015U06OrderTypeComboArgs orderTypeComboArgs = new OCS2015U06OrderTypeComboArgs();
            compositeSecondArgs.OrderTypeCombo = orderTypeComboArgs;

            SaveEmrCompositeSecondResult result = CloudService.Instance.Submit<SaveEmrCompositeSecondResult, SaveEmrCompositeSecondArgs>(compositeSecondArgs, false, CallbackSaveEmrCompositeSecond);

        }

        private SaveEmrCompositeThirdResult SaveEmrCompositeThird(string content, string metaData)
        {
            SaveEmrCompositeThirdArgs compositeThirdArgs = new SaveEmrCompositeThirdArgs();
            OCS2015U09EmrRecordUpdateArgs EmrRecordUpdateArg = new OCS2015U09EmrRecordUpdateArgs();
            EmrRecordUpdateArg.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
            EmrRecordUpdateArg.Content = content;

            EmrRecordUpdateArg.Metadata = metaData;
            EmrRecordUpdateArg.Metadata = metaData;
            EmrRecordUpdateArg.SysId = UserInfo.UserID;

            EmrRecordUpdateArg.RecordLog = "新規作成";

            compositeThirdArgs.EmrRecordUpdate = EmrRecordUpdateArg;
            OCS2015U06EmrRecordArgs emrRecordArgs = new OCS2015U06EmrRecordArgs();
            emrRecordArgs.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
            emrRecordArgs.HospCode = UserInfo.HospCode;

            compositeThirdArgs.EmrRecord = emrRecordArgs;

            OCS0103U12GrdSangyongOrderArgs grdSangyongOrderArgs = new OCS0103U12GrdSangyongOrderArgs();
            grdSangyongOrderArgs.IoGubun = "O";
            grdSangyongOrderArgs.OrderDate = "";
            grdSangyongOrderArgs.OrderGubun = "";
            grdSangyongOrderArgs.SearchWord = "";
            grdSangyongOrderArgs.User = UserInfo.UserID;
            grdSangyongOrderArgs.WonnaeDrgYn = "";
            grdSangyongOrderArgs.ProtocolId = "";
            compositeThirdArgs.GrdSangyongOrder = grdSangyongOrderArgs;

            OCS0103U10FormLoadArgs formLoadArgs = new OCS0103U10FormLoadArgs();
            formLoadArgs.Bunho = this.mSelectedPatientInfo.Parameter.Bunho;
            formLoadArgs.GeneralDispYn = new GetUserOptionInfo(UserInfo.UserID, UserInfo.Gwa, "GENERAL_DISP_YN", "O");
            formLoadArgs.InputTab = "01";
            formLoadArgs.Memb = "";
            formLoadArgs.OrderMode = "2";
            string naewonKey = this.mSelectedPatientInfo.Parameter.NaewonKey;
            formLoadArgs.Pkinp1001 = naewonKey;  //mPatientInfo.GetPatientInfo == null ? string.Empty : mPatientInfo.GetPatientInfo["naewon_key"].ToString();
            if (naewonKey.Contains("."))
            {
                formLoadArgs.Pkinp1001 = naewonKey.Substring(0, naewonKey.IndexOf("."));
            }
            formLoadArgs.SentouSearchYn = new GetUserOptionInfo(UserInfo.UserID, UserInfo.Gwa, "SENTOU_SEARCH_YN", "O");
            formLoadArgs.UsedTabInfo = new LoadOftenUsedTabInfo("", "01");
            formLoadArgs.IsCheckDrgTime = true;
            formLoadArgs.CodeNameInfo = new LoadColumnCodeNameInfo("gwa_doctor", "%", "", null, null);
            formLoadArgs.GwaDoctorCodeInfo = new GetMainGwaDoctorCodeInfo("");
            compositeThirdArgs.U10FormLoad = formLoadArgs;


            SaveEmrCompositeThirdResult result = CloudService.Instance.Submit<SaveEmrCompositeThirdResult, SaveEmrCompositeThirdArgs>(compositeThirdArgs, false, CallbackSaveEmrCompositeThird);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result;
            }
            return null;

        }

        private Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackSaveEmrCompositeThird(
            SaveEmrCompositeThirdArgs args, SaveEmrCompositeThirdResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.EmrRecordUpdate, new KeyValuePair<int, object>(1, result.EmrRecordUpdate));
            cacheOne.Add(args.EmrRecord, new KeyValuePair<int, object>(1, result.EmrRecord));
            cacheOne.Add(args.GrdSangyongOrder, new KeyValuePair<int, object>(1, result.GrdSangyongOrder));
            cacheOne.Add(args.U10FormLoad, new KeyValuePair<int, object>(1, result.U10FormLoad));


            cacheData.Add(CachePolicy.ONCE, cacheOne);
            return cacheData;
        }

        private Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> CallbackSaveEmrCompositeSecond(
            SaveEmrCompositeSecondArgs args, SaveEmrCompositeSecondResult result)
        {
            Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>> cacheData = new Dictionary<CachePolicy, Dictionary<object, KeyValuePair<int, object>>>();
            Dictionary<object, KeyValuePair<int, object>> cacheOne = new Dictionary<object, KeyValuePair<int, object>>();
            cacheOne.Add(args.GrdPatient, new KeyValuePair<int, object>(1, result.GrdPatient));
            cacheOne.Add(args.BtnListQuery, new KeyValuePair<int, object>(1, result.BtnListQuery));
            cacheOne.Add(args.GrdNur1016, new KeyValuePair<int, object>(1, result.GrdNur1016));
            cacheOne.Add(args.GrdNur1017, new KeyValuePair<int, object>(1, result.GrdNur1017));
            cacheOne.Add(args.GrdListOut0106, new KeyValuePair<int, object>(1, result.GrdListOut0106));
            cacheOne.Add(args.GetPatientInfo, new KeyValuePair<int, object>(2, result.GetPatientInfo));
            cacheOne.Add(args.PatientInfoLoad, new KeyValuePair<int, object>(1, result.PatientInfoLoad));
            cacheOne.Add(args.EnvSysDate, new KeyValuePair<int, object>(1, result.EnvSysDate));
            cacheOne.Add(args.OcsLoadNaewon, new KeyValuePair<int, object>(1, result.OcsLoadNaewon));
            cacheOne.Add(args.TemplateCombo, new KeyValuePair<int, object>(1, result.TemplateCombo));
            cacheOne.Add(args.OrderTypeCombo, new KeyValuePair<int, object>(1, result.OrderTypeCombo));


            cacheData.Add(CachePolicy.ONCE, cacheOne);
            return cacheData;
        }

    }

    

    public class CommonOcsLibS
    {
        public IHIS.OCS.OrderBiz mOrderBiz = null; // OCS 그룹 Business 라이브러리
        public IHIS.OCS.OrderFunc mOrderFunc = null; // OCS 그룹 Function 라이브러리
        public IHIS.OCS.PatientInfo mPatientInfo = null; // OCS 환자정보 그룹 라이브러리 
        public IHIS.OCS.HangmogInfo mHangmogInfo = null; // OCS 항목정보 그룹 라이브러리 
        public IHIS.OCS.InputControl mInputControl = null; // 입력제어 그룹 라이브러리 
        public IHIS.OCS.CommonForms mCommonForms = null; // OCS 공통Form's 그룹 라이브러리 
        public IHIS.OCS.ColumnControl mColumnControl = null; // OCS 오더별 컬럼 컨트롤 라이브러리
        public IHIS.OCS.OrderInterface mInterface = null;

        public CommonOcsLibS()
        {
            this.mOrderBiz = new IHIS.OCS.OrderBiz("OCS2015U00");             // OCS 그룹 Business 라이브러리
            this.mOrderFunc = new IHIS.OCS.OrderFunc("OCS2015U00");            // OCS 그룹 Function 라이브러리
            this.mPatientInfo = new IHIS.OCS.PatientInfo("OCS2015U00");        // OCS 환자정보 그룹 라이브러리 
            this.mHangmogInfo = new IHIS.OCS.HangmogInfo("OCS2015U00");        // OCS 항목정보 그룹 라이브러리
            this.mInputControl = new IHIS.OCS.InputControl("OCS2015U00");      // 입력제어 그룹 라이브러리 
            this.mCommonForms = new IHIS.OCS.CommonForms();                 // OCS 공통Form's 그룹 라이브러리 
            this.mColumnControl = new ColumnControl("OCS2015U00");      // OCS 컬럼 컨트롤 그룹 라이브러리 
            this.mInterface = new IHIS.OCS.OrderInterface();
        }
    }

    #region XSavePeformerS
    public class XSavePeformerS : ISavePerformer
    {
        private OCS2016U02 parent = null;
        private IHIS.OCS.OrderBiz mOrderBiz = new OrderBiz("OCS2015U00");

        public XSavePeformerS(OCS2016U02 parent)
        {
            this.parent = parent;
        }

        public bool Execute(char callerId, RowDataItem item)
        {
            string cmdText = "";
            string sprName = "";
            object t_chk = "";
            object reusltSang = "";
            string cmdTextsang = "";
            string changeBeforePKSEQ = "";
            item.BindVarList.Add("q_user_id", UserInfo.UserID);
            item.BindVarList.Add("f_hosp_code", UserInfo.HospCode);
            switch (callerId)
            {
                case '1':   // 상병입력 

                    #region 상병입력

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            ////insert by jc [未コード化傷病コードの場合直接sang_nameにinsertする。] 2012/10/26
                            //if (item.BindVarList["f_sang_code"].VarValue == "0000999")
                            //    item.BindVarList["f_sang_name"].VarValue = item.BindVarList["f_display_sang_name"].VarValue;

                            cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                    + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                    ;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                t_chk = "1";
                            }

                            if (item.BindVarList.Contains("f_pk_seq"))
                                item.BindVarList.Remove("f_pk_seq");
                            item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                            cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                    ;

                            t_chk = Service.ExecuteScalar(cmdText);

                            if (TypeCheck.IsNull(t_chk) == true ||
                                t_chk.ToString() == "")
                            {
                                t_chk = "1";
                            }

                            if (item.BindVarList.Contains("f_ser"))
                                item.BindVarList.Remove("f_ser");
                            item.BindVarList.Add("f_ser", t_chk.ToString());



                            #region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10

                            cmdTextsang = @"SELECT FN_OCS_SANG_DUP_CHK('" + item.BindVarList["f_hosp_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'I'
                                                                         , '" + item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                            reusltSang = Service.ExecuteScalar(cmdTextsang);
                            if (reusltSang.ToString() == "Y")
                            {
                                XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", "確認");
                                return false;
                            }

                            #endregion

                            //#region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10
                            //if (this.mOrderBiz.IsDupSangCheck(item.BindVarList["f_bunho"].VarValue,
                            //                                  item.BindVarList["f_io_gubun"].VarValue,
                            //                                  item.BindVarList["f_gwa"].VarValue,
                            //                                  item.BindVarList["f_sang_code"].VarValue,
                            //                                  item.BindVarList["f_pre_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_post_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_sang_start_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_sayu"].VarValue,
                            //                                  item.BindVarList["f_ju_sang_yn"].VarValue,
                            //                                  item.BindVarList["f_pk_seq"].VarValue,
                            //                                  DataRowState.Modified)
                            //                                 )
                            //{
                            //    XMessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"));
                            //    return true;
                            //}
                            //#endregion

                            cmdText = @"INSERT INTO OUTSANG
                                             ( SYS_DATE       , SYS_ID            , UPD_DATE         , BUNHO           ,
                                               GWA            , IO_GUBUN          , PK_SEQ           , NAEWON_DATE     ,
                                               DOCTOR         , NAEWON_TYPE       , JUBSU_NO         , LAST_NAEWON_DATE,
                                               LAST_DOCTOR    , LAST_NAEWON_TYPE  , LAST_JUBSU_NO    , FKINP1001       ,
                                               INPUT_ID       , SER               , SANG_CODE        , JU_SANG_YN      ,
                                               SANG_NAME      , SANG_START_DATE   , SANG_END_DATE    , SANG_END_SAYU   ,
                                               PRE_MODIFIER1  , PRE_MODIFIER2     , PRE_MODIFIER3    , PRE_MODIFIER4   ,
                                               PRE_MODIFIER5  , PRE_MODIFIER6     , PRE_MODIFIER7    , PRE_MODIFIER8   ,
                                               PRE_MODIFIER9  , PRE_MODIFIER10    , PRE_MODIFIER_NAME, POST_MODIFIER1  ,
                                               POST_MODIFIER2 , POST_MODIFIER3    , POST_MODIFIER4   , POST_MODIFIER5  ,
                                               POST_MODIFIER6 , POST_MODIFIER7    , POST_MODIFIER8   , POST_MODIFIER9  ,
                                               POST_MODIFIER10, POST_MODIFIER_NAME, HOSP_CODE        , UPD_ID          ,
                                               FKOUT1001      , SANG_JINDAN_DATE  , DATA_GUBUN)
                                        VALUES 
                                             ( SYSDATE           , :q_user_id           , SYSDATE             , :f_bunho           ,
                                               :f_gwa            , :f_io_gubun          , :f_pk_seq           , :f_naewon_date     ,
                                               :f_last_doctor    , :f_naewon_type       , :f_jubsu_no         , :f_last_naewon_date,
                                               :f_last_doctor    , :f_last_naewon_type  , :f_last_jubsu_no    , :f_fkinp1001       ,
                                               :f_input_id       , :f_ser               , :f_sang_code        , :f_ju_sang_yn      ,
                                               :f_sang_name      , :f_sang_start_date   , :f_sang_end_date    , :f_sang_end_sayu   ,
                                               :f_pre_modifier1  , :f_pre_modifier2     , :f_pre_modifier3    , :f_pre_modifier4   ,
                                               :f_pre_modifier5  , :f_pre_modifier6     , :f_pre_modifier7    , :f_pre_modifier8   ,
                                               :f_pre_modifier9  , :f_pre_modifier10    , :f_pre_modifier_name, :f_post_modifier1  ,
                                               :f_post_modifier2 , :f_post_modifier3    , :f_post_modifier4   , :f_post_modifier5  ,
                                               :f_post_modifier6 , :f_post_modifier7    , :f_post_modifier8   , :f_post_modifier9  ,
                                               :f_post_modifier10, :f_post_modifier_name, :f_hosp_code        , :q_user_id         ,
                                               :f_fkout1001      , :f_sang_jindan_date  , 'I')       ";

                            break;

                        case DataRowState.Modified:


                            #region [診療科が%の際更新したドクターの診療科に変わる]
                            if (item.BindVarList["f_gwa"].VarValue == "%")
                                item.BindVarList["f_gwa"].VarValue = UserInfo.Gwa;
                            #endregion

                            string cmd = @"select a.gwa 
                                             from outsang a 
                                            where a.hosp_code = fn_adm_load_hosp_code() 
                                              and a.pkoutsang = " + item.BindVarList["f_pkoutsang"].VarValue;
                            object val = Service.ExecuteScalar(cmd);

                            parent.mChangeBeforeGwa = val.ToString();

                            changeBeforePKSEQ = item.BindVarList["f_pk_seq"].VarValue;

                            //移行科のみSEQを再取得する。
                            if (parent.mChangeBeforeGwa == "%")
                            {


                                cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                    + "   FROM OUTSANG Z"
                                    + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                    + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                    + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                    + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                    ;

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) == true ||
                                    t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                if (item.BindVarList.Contains("f_pk_seq"))
                                    item.BindVarList.Remove("f_pk_seq");
                                item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                                cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                        + "   FROM OUTSANG Z"
                                        + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                        ;

                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) == true ||
                                    t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                if (item.BindVarList.Contains("f_ser"))
                                    item.BindVarList.Remove("f_ser");
                                item.BindVarList.Add("f_ser", t_chk.ToString());
                            }

                            #region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10

                            cmdTextsang = @"SELECT FN_OCS_SANG_DUP_CHK('" + item.BindVarList["f_hosp_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'U'
                                                                         , '" + item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                            reusltSang = Service.ExecuteScalar(cmdTextsang);
                            if (reusltSang.ToString() == "Y")
                            {
                                XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", "確認");
                                return false;
                            }

                            #endregion

                            //#region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10
                            //if (this.mOrderBiz.IsDupSangCheck(item.BindVarList["f_bunho"].VarValue,
                            //                                  item.BindVarList["f_io_gubun"].VarValue,
                            //                                  item.BindVarList["f_gwa"].VarValue,
                            //                                  item.BindVarList["f_sang_code"].VarValue,
                            //                                  item.BindVarList["f_pre_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_post_modifier_name"].VarValue,
                            //                                  item.BindVarList["f_sang_start_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_date"].VarValue,
                            //                                  item.BindVarList["f_sang_end_sayu"].VarValue,
                            //                                  item.BindVarList["f_ju_sang_yn"].VarValue,
                            //                                  item.BindVarList["f_pk_seq"].VarValue,
                            //                                  DataRowState.Modified)
                            //                                 )
                            //{
                            //    XMessageBox.Show(XMsg.GetMsg("M012"), XMsg.GetField("F001"));
                            //    return true;
                            //}
                            //#endregion

                            cmdText = @"UPDATE OUTSANG
                                           SET JU_SANG_YN         = :f_ju_sang_yn        
                                             , SANG_NAME          = :f_sang_name         
                                             --, SANG_CODE          = :f_sang_code
                                             , SANG_START_DATE    = :f_sang_start_date   
                                             , SANG_END_DATE      = :f_sang_end_date     
                                             , SANG_END_SAYU      = :f_sang_end_sayu     
                                             , PRE_MODIFIER1      = :f_pre_modifier1     
                                             , PRE_MODIFIER2      = :f_pre_modifier2     
                                             , PRE_MODIFIER3      = :f_pre_modifier3     
                                             , PRE_MODIFIER4      = :f_pre_modifier4     
                                             , PRE_MODIFIER5      = :f_pre_modifier5     
                                             , PRE_MODIFIER6      = :f_pre_modifier6     
                                             , PRE_MODIFIER7      = :f_pre_modifier7     
                                             , PRE_MODIFIER8      = :f_pre_modifier8     
                                             , PRE_MODIFIER9      = :f_pre_modifier9     
                                             , PRE_MODIFIER10     = :f_pre_modifier10    
                                             , PRE_MODIFIER_NAME  = :f_pre_modifier_name 
                                             , POST_MODIFIER1     = :f_post_modifier1    
                                             , POST_MODIFIER2     = :f_post_modifier2    
                                             , POST_MODIFIER3     = :f_post_modifier3    
                                             , POST_MODIFIER4     = :f_post_modifier4    
                                             , POST_MODIFIER5     = :f_post_modifier5    
                                             , POST_MODIFIER6     = :f_post_modifier6    
                                             , POST_MODIFIER7     = :f_post_modifier7    
                                             , POST_MODIFIER8     = :f_post_modifier8    
                                             , POST_MODIFIER9     = :f_post_modifier9    
                                             , POST_MODIFIER10    = :f_post_modifier10   
                                             , POST_MODIFIER_NAME = :f_post_modifier_name 
                                             , UPD_ID             = :q_user_id
                                             , UPD_DATE           = SYSDATE
                                             , SANG_JINDAN_DATE   = :f_sang_jindan_date 
                                             , GWA                = :f_gwa
                                             , DATA_GUBUN         = 'U'
                                             , PK_SEQ             = :f_pk_seq
                                             , SER                = :f_ser

                                         WHERE BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'     
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'  
                                           AND HOSP_CODE          = :f_hosp_code";

                            break;

                        case DataRowState.Deleted:

                            //削除するタイミングでif_data_send_ynを取得してチェックをする（画面上はまだ未更新の場合あるので）
                            cmdText = @"SELECT A.IF_DATA_SEND_YN
                                          FROM OUTSANG A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.BUNHO     = :f_bunho
                                           AND A.GWA       = :f_gwa
                                           AND A.IO_GUBUN  = :f_io_gubun
                                           AND A.PK_SEQ    = :f_pk_seq";
                            val = Service.ExecuteScalar(cmdText, item.BindVarList);

                            item.BindVarList["f_if_data_send_yn"].VarValue = val.ToString();

                            if (item.BindVarList["f_data_gubun"].VarValue == "I" && item.BindVarList["f_if_data_send_yn"].VarValue == "N")
                            {
                                cmdText = " DELETE FROM OUTSANG A                "
                                        + "  WHERE A.BUNHO        = :f_bunho     "
                                        + "    AND A.GWA          = :f_gwa       "
                                        + "    AND A.IO_GUBUN     = :f_io_gubun  "
                                        + "    AND A.PK_SEQ       = :f_pk_seq    "
                                        + "    AND A.HOSP_CODE    = :f_hosp_code "
                                        ;
                            }
                            else
                            {
                                #region [診療科が%の際更新したドクターの診療科に変わる]
                                if (item.BindVarList["f_gwa"].VarValue == "%")
                                    item.BindVarList["f_gwa"].VarValue = UserInfo.Gwa;
                                #endregion

                                cmd = @"select a.gwa 
                                                 from outsang a 
                                                where a.hosp_code = fn_adm_load_hosp_code() 
                                                  and a.pkoutsang = " + item.BindVarList["f_pkoutsang"].VarValue;
                                val = Service.ExecuteScalar(cmd);

                                changeBeforePKSEQ = item.BindVarList["f_pk_seq"].VarValue;

                                parent.mChangeBeforeGwa = val.ToString();

                                //移行科のみSEQを再取得する。
                                if (parent.mChangeBeforeGwa == "%")
                                {
                                    cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                        + "   FROM OUTSANG Z"
                                        + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                        + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                        + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                        + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                        ;

                                    t_chk = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(t_chk) == true ||
                                        t_chk.ToString() == "")
                                    {
                                        t_chk = "1";
                                    }

                                    if (item.BindVarList.Contains("f_pk_seq"))
                                        item.BindVarList.Remove("f_pk_seq");
                                    item.BindVarList.Add("f_pk_seq", t_chk.ToString());

                                    cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                            + "   FROM OUTSANG Z"
                                            + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                            + "    AND Z.HOSP_CODE   = '" + UserInfo.HospCode + "' "
                                            ;

                                    t_chk = Service.ExecuteScalar(cmdText);

                                    if (TypeCheck.IsNull(t_chk) == true ||
                                        t_chk.ToString() == "")
                                    {
                                        t_chk = "1";
                                    }

                                    if (item.BindVarList.Contains("f_ser"))
                                        item.BindVarList.Remove("f_ser");
                                    item.BindVarList.Add("f_ser", t_chk.ToString());
                                }

                                cmdText = @"UPDATE OUTSANG
                                           SET JU_SANG_YN         = :f_ju_sang_yn        
                                             , SANG_NAME          = :f_sang_name         
                                             , SANG_START_DATE    = :f_sang_start_date   
                                             , SANG_END_DATE      = :f_sang_end_date     
                                             , SANG_END_SAYU      = :f_sang_end_sayu     
                                             , PRE_MODIFIER1      = :f_pre_modifier1     
                                             , PRE_MODIFIER2      = :f_pre_modifier2     
                                             , PRE_MODIFIER3      = :f_pre_modifier3     
                                             , PRE_MODIFIER4      = :f_pre_modifier4     
                                             , PRE_MODIFIER5      = :f_pre_modifier5     
                                             , PRE_MODIFIER6      = :f_pre_modifier6     
                                             , PRE_MODIFIER7      = :f_pre_modifier7     
                                             , PRE_MODIFIER8      = :f_pre_modifier8     
                                             , PRE_MODIFIER9      = :f_pre_modifier9     
                                             , PRE_MODIFIER10     = :f_pre_modifier10    
                                             , PRE_MODIFIER_NAME  = :f_pre_modifier_name 
                                             , POST_MODIFIER1     = :f_post_modifier1    
                                             , POST_MODIFIER2     = :f_post_modifier2    
                                             , POST_MODIFIER3     = :f_post_modifier3    
                                             , POST_MODIFIER4     = :f_post_modifier4    
                                             , POST_MODIFIER5     = :f_post_modifier5    
                                             , POST_MODIFIER6     = :f_post_modifier6    
                                             , POST_MODIFIER7     = :f_post_modifier7    
                                             , POST_MODIFIER8     = :f_post_modifier8    
                                             , POST_MODIFIER9     = :f_post_modifier9    
                                             , POST_MODIFIER10    = :f_post_modifier10   
                                             , POST_MODIFIER_NAME = :f_post_modifier_name 
                                             , UPD_ID             = :q_user_id
                                             , UPD_DATE           = SYSDATE
                                             , SANG_JINDAN_DATE   = :f_sang_jindan_date 
                                             , GWA                = :f_gwa
                                             , DATA_GUBUN         = 'D'
                                             , PK_SEQ             = :f_pk_seq
                                             , SER                = :f_ser

                                         WHERE BUNHO              = :f_bunho   
                                           AND GWA                = '" + parent.mChangeBeforeGwa + @"'    
                                           AND IO_GUBUN           = :f_io_gubun
                                           AND PK_SEQ             = '" + changeBeforePKSEQ + @"'
                                           AND HOSP_CODE          = :f_hosp_code";
                            }
                            break;
                    }

                    #endregion

                    break;

                case '2':    // 삭제로직...

                    #region 오더 삭제

                    // 인터페이스 용 임시테이블에 인서트
                    if (item.BindVarList["f_source_ord_key"].VarValue != "")
                    {
                        // 삭제시 DC 반납 원오더 원래대로 위치
                        ArrayList inList = new ArrayList();
                        ArrayList outList = new ArrayList();

                        inList.Add("O");
                        inList.Add(item.BindVarList["f_source_ord_key"].VarValue);

                        sprName = "PR_OCS_UPDATE_DC_YN";

                        if (Service.ExecuteProcedure(sprName, inList, outList) == false)
                        {
                            MessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    cmdText = " DELETE FROM OCS1003 "
                            + "  WHERE HOSP_CODE = :f_hosp_code "
                            + "    AND PKOCS1003 = :f_pkocskey ";

                    if (item.BindVarList["f_instead_yn"].VarValue == "Y")
                    {
                        parent.mInsteadDeletedOrderCnt++;
                    }

                    #endregion

                    break;

                case '3':    // 인서트 & 업데이트 

                    #region 오더 입력

                    switch (item.RowState)
                    {
                        case DataRowState.Added:

                            // 키가 입력되지 않은경우 키를 따야함..
                            if (item.BindVarList["f_pkocskey"].VarValue == "")
                            {
                                cmdText = " SELECT OCSKEY_SEQ.NEXTVAL "
                                        + "   FROM SYS.DUAL ";

                                t_chk = Service.ExecuteScalar(cmdText);

                                item.BindVarList.Remove("f_pkocskey");
                                item.BindVarList.Add("f_pkocskey", t_chk.ToString());
                            }

                            // 시퀀스 가져오기
                            if (item.BindVarList["f_seq"].VarValue == "")
                            {
                                cmdText = " SELECT MAX(SEQ)+1 SEQ "
                                        + "   FROM OCS1003 "
                                        + "  WHERE FKOUT1001 = " + item.BindVarList["f_in_out_key"].VarValue
                                        + "    AND HOSP_CODE = '" + UserInfo.HospCode + "' ";
                                t_chk = Service.ExecuteScalar(cmdText);

                                if (TypeCheck.IsNull(t_chk) || t_chk.ToString() == "")
                                {
                                    t_chk = "1";
                                }

                                item.BindVarList.Remove("f_seq");
                                item.BindVarList.Add("f_seq", t_chk.ToString());
                            }

                            if (item.BindVarList["f_general_disp_yn"].VarValue == "")
                                item.BindVarList["f_general_disp_yn"].VarValue = "N";

                            if (parent.mInputGubun == "CK")
                            {
                                item.BindVarList.Add("f_instead_yn", "Y");
                                item.BindVarList.Add("f_instead_id", UserInfo.UserID);
                                item.BindVarList.Add("f_instead_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                                item.BindVarList.Add("f_instead_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                            }

                            item.BindVarList.Add("f_approve_yn", "N");

                            // dv_1.. dv_8 まで 0 -> null
                            if (item.BindVarList["f_dv_1"].VarValue == "0") item.BindVarList["f_dv_1"].VarValue = "";
                            if (item.BindVarList["f_dv_2"].VarValue == "0") item.BindVarList["f_dv_2"].VarValue = "";
                            if (item.BindVarList["f_dv_3"].VarValue == "0") item.BindVarList["f_dv_3"].VarValue = "";
                            if (item.BindVarList["f_dv_4"].VarValue == "0") item.BindVarList["f_dv_4"].VarValue = "";
                            if (item.BindVarList["f_dv_5"].VarValue == "0") item.BindVarList["f_dv_5"].VarValue = "";
                            if (item.BindVarList["f_dv_6"].VarValue == "0") item.BindVarList["f_dv_6"].VarValue = "";
                            if (item.BindVarList["f_dv_7"].VarValue == "0") item.BindVarList["f_dv_7"].VarValue = "";
                            if (item.BindVarList["f_dv_8"].VarValue == "0") item.BindVarList["f_dv_8"].VarValue = "";

                            if (parent.mPostApproveYN)
                                item.BindVarList.Add("f_postapprove_yn", "Y");
                            else
                                item.BindVarList.Add("f_postapprove_yn", "N");

                            cmdText = " INSERT INTO OCS1003 "
                                    + "      ( SYS_DATE             , SYS_ID               , UPD_DATE          , UPD_ID                  , HOSP_CODE             , "
                                    + "        PKOCS1003            , BUNHO                , ORDER_DATE        , GWA                     , DOCTOR                , "
                                    + "        NAEWON_TYPE          , INPUT_ID             , INPUT_PART        , INPUT_GUBUN             , SEQ                   , "
                                    + "        HANGMOG_CODE         , GROUP_SER            , SLIP_CODE         , NDAY_YN                 , ORDER_GUBUN           , "
                                    + "        SPECIMEN_CODE        , SURYANG              , ORD_DANUI         , DV_TIME                 , DV                    , "
                                    + "        NALSU                , JUSA                 , BOGYONG_CODE      , EMERGENCY               , JAERYO_JUNDAL_YN      , "
                                    + "        JUNDAL_TABLE         , JUNDAL_PART          , MOVE_PART         , MUHYO                   , PORTABLE_YN           , "
                                    + "        ANTI_CANCER_YN       , PAY                  , RESER_DATE        , RESER_TIME              , DC_YN                 , "
                                    + "        DC_GUBUN             , BANNAB_YN            , BANNAB_CONFIRM    , ACT_DOCTOR              , ACT_GWA               , "
                                    + "        ACT_BUSEO            , OCS_FLAG             , SG_CODE           , SG_YMD                  , IO_GUBUN              , "
                                    + "        AFTER_ACT_YN         , BICHI_YN             , DRG_BUNHO         , SUB_SUSUL               , WONYOI_ORDER_YN       , "
                                    + "        SUTAK_YN             , POWDER_YN            , HOPE_DATE         , HOPE_TIME               , DV_1                  , "
                                    + "        DV_2                 , DV_3                 , DV_4              , MIX_GROUP               , ORDER_REMARK          , "
                                    + "        NURSE_REMARK         , BOM_OCCUR_YN         , BOM_SOURCE_KEY    , DISPLAY_YN              , NURSE_CONFIRM_USER    , "
                                    + "        NURSE_CONFIRM_DATE   , NURSE_CONFIRM_TIME   , TEL_YN            , DANGIL_GUMSA_ORDER_YN   , DANGIL_GUMSA_RESULT_YN, "
                                    + "        HOME_CARE_YN         , REGULAR_YN           , INPUT_TAB         , HUBAL_CHANGE_YN         , PHARMACY              , "
                                    + "        JUSA_SPD_GUBUN       , DRG_PACK_YN          , SORT_FKOCSKEY     , FKOUT1001               , IMSI_DRUG_YN          , "
                                    + "        GENERAL_DISP_YN      , DV_5                 , DV_6              , DV_7                    , DV_8                  , "
                                    + "        BOGYONG_CODE_SUB     , INSTEAD_YN           , INSTEAD_ID        , INSTEAD_DATE            , INSTEAD_TIME          , "
                                    + "        APPROVE_YN           , POSTAPPROVE_YN) "
                                    + " VALUES "
                                //modify by jc SYSDATE -> parent.mSave_time
                                    + "      ( TO_DATE('" + parent.mSave_time + "', 'YYYY/MM/DD HH24:MI:SS')   , :q_user_id           , SYSDATE           , :q_user_id              , :f_hosp_code             , "
                                    + "        :f_pkocskey          , :f_bunho             , :f_order_date     , :f_gwa                  , :f_doctor                , "
                                    + "        :f_naewon_type       , :f_input_id          , :f_input_part     , :f_input_gubun          , :f_seq                   , "
                                    + "        :f_hangmog_code      , :f_group_ser         , :f_slip_code      , :f_nday_yn              , :f_order_gubun           , "
                                    + "        :f_specimen_code     , :f_suryang           , :f_ord_danui      , :f_dv_time              , :f_dv                    , "
                                    + "        :f_nalsu             , :f_jusa              , :f_bogyong_code   , :f_emergency            , :f_jaeryo_jundal_yn      , "
                                    + "        :f_jundal_table      , :f_jundal_part       , :f_move_part      , :f_muhyo                , :f_portable_yn           , "
                                    + "        'N'                  , :f_pay               , :f_reser_date     , :f_reser_time           , :f_dc_yn                 , "
                                    + "        :f_dc_gubun          , :f_bannab_yn         , :f_bannab_confirm , :f_act_doctor           , :f_act_gwa               , "
                                    + "        :f_act_buseo         , :f_ocs_flag          , :f_sg_code        , :f_sg_ymd               , :f_io_gubun              , "
                                    + "        :f_after_act_yn      , :f_bichi_yn          , :f_drg_bunho      , :f_sub_susul            , :f_wonyoi_order_yn       , "
                                    + "        'N'                  , :f_powder_yn         , :f_hope_date      , :f_hope_time            , :f_dv_1                  , "
                                    + "        :f_dv_2              , :f_dv_3              , :f_dv_4           , :f_mix_group            , :f_order_remark          , "
                                    + "        :f_nurse_remark      , :f_bom_occur_yn      , :f_bom_source_key , :f_display_yn           , :f_nurse_confirm_user    , "
                                    + "        :f_nurse_confirm_date, :f_nurse_confirm_time, :f_tel_yn         , :f_dangil_gumsa_order_yn, :f_dangil_gumsa_result_yn, "
                                    + "        :f_home_care_yn      , :f_regular_yn        , :f_input_tab      , :f_hubal_change_yn      , :f_pharmacy              , "
                                    + "        :f_jusa_spd_gubun    , :f_drg_pack_yn       , :f_sort_fkocskey  , :f_in_out_key           , :f_imsi_drug_yn          , "
                                    + "        :f_general_disp_yn   , :f_dv_5              , :f_dv_6           , :f_dv_7                 , :f_dv_8                  , "
                                    + "        :f_bogyong_code_sub  , :f_instead_yn        , :f_instead_id     , :f_instead_date         , :f_instead_time          , "
                                    + "        :f_approve_yn        , :f_postapprove_yn) ";


                            if (item.BindVarList["f_instead_yn"] != null && item.BindVarList["f_instead_yn"].VarValue == "Y")
                            {
                                parent.mInsteadInsertedOrderCnt++;
                            }

                            break;

                        case DataRowState.Modified:

                            //薬以外はgeneral_disp_yn値がないからデフォルトで「N」を入れる。
                            //general_disp_ynに値がないとdisplay時オーダ名が表示されないから
                            if (item.BindVarList["f_general_disp_yn"].VarValue == "")
                                item.BindVarList["f_general_disp_yn"].VarValue = "N";

                            // dv_1.. dv_8 まで 0 -> null
                            if (item.BindVarList["f_dv_1"].VarValue == "0") item.BindVarList["f_dv_1"].VarValue = "";
                            if (item.BindVarList["f_dv_2"].VarValue == "0") item.BindVarList["f_dv_2"].VarValue = "";
                            if (item.BindVarList["f_dv_3"].VarValue == "0") item.BindVarList["f_dv_3"].VarValue = "";
                            if (item.BindVarList["f_dv_4"].VarValue == "0") item.BindVarList["f_dv_4"].VarValue = "";
                            if (item.BindVarList["f_dv_5"].VarValue == "0") item.BindVarList["f_dv_5"].VarValue = "";
                            if (item.BindVarList["f_dv_6"].VarValue == "0") item.BindVarList["f_dv_6"].VarValue = "";
                            if (item.BindVarList["f_dv_7"].VarValue == "0") item.BindVarList["f_dv_7"].VarValue = "";
                            if (item.BindVarList["f_dv_8"].VarValue == "0") item.BindVarList["f_dv_8"].VarValue = "";

                            cmdText = " UPDATE OCS1003 "
                                    + "    SET UPD_DATE         = SYSDATE "
                                    + "      , UPD_ID           = :q_user_id "
                                    + "      , ORDER_GUBUN      = :f_order_gubun "
                                    + "      , SURYANG          = :f_suryang "
                                    + "      , ORD_DANUI        = :f_ord_danui "
                                    + "      , DV_TIME          = :f_dv_time "
                                    + "      , DV               = :f_dv "
                                    + "      , NALSU            = :f_nalsu "
                                    + "      , JUSA             = :f_jusa  "
                                    + "      , BOGYONG_CODE     = :f_bogyong_code "
                                    + "      , EMERGENCY        = :f_emergency "
                                    + "      , JAERYO_JUNDAL_YN = :f_jaeryo_jundal_yn "
                                    + "      , JUNDAL_TABLE     = :f_jundal_table "
                                    + "      , JUNDAL_PART      = :f_jundal_part "
                                    + "      , MOVE_PART        = :f_move_part "
                                    + "      , MUHYO            = :f_muhyo "
                                    + "      , PORTABLE_YN      = :f_portable_yn "
                                    + "      , ANTI_CANCER_YN   = :f_anti_cancer_yn "
                                    + "      , DC_YN            = :f_dc_yn "
                                    + "      , DC_GUBUN         = :f_dc_gubun "
                                    + "      , BANNAB_YN        = :f_bannab_yn "
                                    + "      , BANNAB_CONFIRM   = :f_bannab_confirm "
                                    + "      , SUTAK_YN         = :f_sutak_yn "
                                    + "      , POWDER_YN        = :f_powder_yn "
                                    + "      , HOPE_DATE        = :f_hope_date "
                                    + "      , HOPE_TIME        = :f_hope_time "
                                    + "      , DV_1             = :f_dv_1 "
                                    + "      , DV_2             = :f_dv_2 "
                                    + "      , DV_3             = :f_dv_3 "
                                    + "      , DV_4             = :f_dv_4 "
                                    + "      , DV_5             = :f_dv_5 "
                                    + "      , DV_6             = :f_dv_6 "
                                    + "      , DV_7             = :f_dv_7 "
                                    + "      , DV_8             = :f_dv_8 "
                                    + "      , MIX_GROUP        = :f_mix_group "
                                    + "      , ORDER_REMARK     = :f_order_remark "
                                    + "      , NURSE_REMARK     = :f_nurse_remark "
                                    + "      , BOM_OCCUR_YN     = :f_bom_occur_yn "
                                    + "      , BOM_SOURCE_KEY   = :f_bom_source_key "
                                    + "      , NURSE_CONFIRM_USER = :f_nurse_confirm_user "
                                    + "      , NURSE_CONFIRM_DATE = :f_nurse_confirm_date "
                                    + "      , NURSE_CONFIRM_TIME = :f_nurse_confirm_time "
                                    + "      , DANGIL_GUMSA_ORDER_YN = :f_dangil_gumsa_order_yn "
                                    + "      , DANGIL_GUMSA_RESULT_YN = :f_dangil_gumsa_result_yn "
                                    + "      , HOME_CARE_YN     = :f_home_care_yn "
                                    + "      , REGULAR_YN       = :f_regular_yn "
                                    + "      , HUBAL_CHANGE_YN  = :f_hubal_change_yn "
                                    + "      , PHARMACY         = :f_pharmacy "
                                    + "      , JUSA_SPD_GUBUN   = :f_jusa_spd_gubun "
                                    + "      , DRG_PACK_YN      = :f_drg_pack_yn "
                                    + "      , SORT_FKOCSKEY    = :f_sort_fkocskey "
                                    + "      , WONYOI_ORDER_YN  = :f_wonyoi_order_yn "
                                    + "      , IMSI_DRUG_YN     = :f_imsi_drug_yn "
                                    + "      , SPECIMEN_CODE    = :f_specimen_code "
                                    + "      , GENERAL_DISP_YN  = :f_general_disp_yn "
                                    + "      , BOGYONG_CODE_SUB = :f_bogyong_code_sub "
                                    + "      , GROUP_SER        = :f_group_ser "
                                    + "  WHERE PKOCS1003 = :f_pkocskey "
                                    + "    AND HOSP_CODE = :f_hosp_code "
                                    ;

                            if (item.BindVarList["f_instead_yn"] != null && item.BindVarList["f_instead_yn"].VarValue == "Y")
                            {
                                parent.mInsteadUpdatedOrderCnt++;
                            }

                            break;

                    }

                    #endregion

                    break;
            }

            bool isSuccess = Service.ExecuteNonQuery(cmdText, item.BindVarList);

            // 오더 업데이트의 경우는 정시약도 같이 업데이트 되어야 함.
            if (callerId == '3' && isSuccess)
            {
                if (this.mOrderBiz.SaveRegularOrder("1", item.BindVarList["f_pkocskey"].VarValue) == false)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
    }
    #endregion
}