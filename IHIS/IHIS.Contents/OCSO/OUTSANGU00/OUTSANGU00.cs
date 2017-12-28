#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Ocso;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Ocso;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.OCS;
//using IHIS.OCSA;
using IHIS.OCSO.Properties;

#endregion

namespace IHIS.OCSO
{
    /// <summary>
    /// OUTSANGU00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUTSANGU00 : IHIS.Framework.XScreen
    {
        PermisionForm permissionform;
        #region [Instance Variable]		

        //Message처리
        private string mbxMsg = "", mbxCap = "";
        private string buttonTitle = "";
        //입원,외래구분
        private string mIO_gubun = "O";
        //등록번호
        private string mBunho = "";

        private string mCalledSystemID = "";

        //진료과
        private string mGwa = "";
        //기준일자
        private string mNaewon_date = "";

        private string mMsg = "";
        private string mCap = "";
        private string emrLoad = "";
        //진료과 layout
        private IHIS.Framework.MultiLayout layoutGwa = new MultiLayout();

        private OCS.OrderFunc mOrderFunc = new IHIS.OCS.OrderFunc("OUTSANGU00");
        private OCS.OrderBiz mOrderBiz = new IHIS.OCS.OrderBiz("OUTSANGU00");
        private OCS.PatientInfo mSelectedPatientInfo;

        //hospital code
        private string mHospCode = EnvironInfo.HospCode;
        List<string> permission_list;
        #endregion

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPatientBox pbxSearch;
        private IHIS.Framework.XTreeView tvwGwa;
        private IHIS.Framework.XEditGrid grdOutSang;
        private IHIS.Framework.XEditGridCell xEditGridCell379;
        private IHIS.Framework.XEditGridCell xEditGridCell380;
        private IHIS.Framework.XEditGridCell xEditGridCell381;
        private IHIS.Framework.XEditGridCell xEditGridCell385;
        private IHIS.Framework.XEditGridCell xEditGridCell384;
        private IHIS.Framework.XEditGridCell xEditGridCell93;
        private IHIS.Framework.XEditGridCell xEditGridCell82;
        private IHIS.Framework.XEditGridCell xEditGridCell383;
        private IHIS.Framework.XEditGridCell xEditGridCell382;
        private IHIS.Framework.XEditGridCell xEditGridCell374;
        private IHIS.Framework.XEditGridCell xEditGridCell373;
        private IHIS.Framework.XEditGridCell xEditGridCell375;
        private IHIS.Framework.XEditGridCell xEditGridCellsang_start_date;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGridCell xEditGridCellsang_end_sayu;
        private IHIS.Framework.XEditGridCell xEditGridCell47;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell61;
        private IHIS.Framework.XEditGridCell xEditGridCell83;
        private IHIS.Framework.XEditGridCell xEditGridCell84;
        private IHIS.Framework.XEditGridCell xEditGridCell85;
        private IHIS.Framework.XEditGridCell xEditGridCell86;
        private IHIS.Framework.XEditGridCell xEditGridCell87;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell70;
        private IHIS.Framework.XEditGridCell xEditGridCell71;
        private IHIS.Framework.XEditGridCell xEditGridCell74;
        private IHIS.Framework.XEditGridCell xEditGridCell75;
        private IHIS.Framework.XEditGridCell xEditGridCell88;
        private IHIS.Framework.XEditGridCell xEditGridCell89;
        private IHIS.Framework.XEditGridCell xEditGridCell90;
        private IHIS.Framework.XEditGridCell xEditGridCell91;
        private IHIS.Framework.XEditGridCell xEditGridCell92;
        private IHIS.Framework.XEditGridCell xEditGridCell76;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell81;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell78;
        private IHIS.Framework.XEditGridCell xEditGridCell79;
        private IHIS.Framework.XDatePicker dtpNaewon_Date;
        private IHIS.Framework.XLabel lblNaewon_DateTitle;
        private IHIS.Framework.XPanel xPanel6;
        private System.Windows.Forms.RadioButton rbtIn;
        private System.Windows.Forms.RadioButton rbtOut;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private System.Windows.Forms.CheckBox chkAll;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XButton btnOutInpCopy;
        private XPanel pnlDoctorInfo;
        private XDisplayBox dbxToDoctorName;
        private XFindBox fbxToDoctor;
        private XLabel xLabel6;
        private XDisplayBox dbxToGwaName;
        private XFindBox fbxToGwa;
        private XLabel xLabel7;
        private XFindWorker fwkCommon;
        private Timer timIcon;
        private PictureBox pbxUnderArrow;
        private XPanel pnlFill;
        private IContainer components;
        private UCOCS0301Q09 mainControl;
        private XEditGridCell xEditGridCell7;

        private string sangCode;
        
        public OUTSANGU00()
        {
            /* SavePerformer 생성 */
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //https://sofiamedix.atlassian.net/browse/MED-12178
            if (NetInfo.Language == LangMode.Vi)
            {
                grdOutSang.AutoSizeColumn(xEditGridCell78.Col, 0);
            }
            //저장 수행자 Set
            this.grdOutSang.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdOutSang);
            // grdOutSang: Create param list
            this.grdOutSang.ParamList =
                new List<string>(new String[] {"f_gwa", "f_io_gubun", "f_all_sang_yn", "f_bunho", "f_gijun_date"});
            // fwkCommon: Create param list
            this.fwkCommon.ParamList =
                new List<string>(new String[] {"f_start_date", "f_find1", "f_gwa", "f_doctor_ymd"});

            //TODO disable IN Hospital Tab MED-5790
            rbtIn.Visible = false;
            //MED14139

            this.mainControl = new UCOCS0301Q09();
            this.pnlFill.Controls.Add(this.mainControl);
            this.mainControl.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUTSANGU00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pnlDoctorInfo = new IHIS.Framework.XPanel();
            this.dbxToDoctorName = new IHIS.Framework.XDisplayBox();
            this.fbxToDoctor = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.dbxToGwaName = new IHIS.Framework.XDisplayBox();
            this.fbxToGwa = new IHIS.Framework.XFindBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dtpNaewon_Date = new IHIS.Framework.XDatePicker();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.lblNaewon_DateTitle = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnOutInpCopy = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.tvwGwa = new IHIS.Framework.XTreeView();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.rbtIn = new System.Windows.Forms.RadioButton();
            this.rbtOut = new System.Windows.Forms.RadioButton();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdOutSang = new IHIS.Framework.XEditGrid();
            this.xEditGridCell379 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell381 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell380 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell385 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell384 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell383 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell374 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell375 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell373 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellsang_start_date = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCellsang_end_sayu = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell382 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.timIcon = new System.Windows.Forms.Timer(this.components);
            this.pbxUnderArrow = new System.Windows.Forms.PictureBox();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xPanel1.SuspendLayout();
            this.pnlDoctorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "삭제.ico");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "+.gif");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.pnlDoctorInfo);
            this.xPanel1.Controls.Add(this.dtpNaewon_Date);
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.Controls.Add(this.lblNaewon_DateTitle);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // pnlDoctorInfo
            // 
            this.pnlDoctorInfo.AccessibleDescription = null;
            this.pnlDoctorInfo.AccessibleName = null;
            resources.ApplyResources(this.pnlDoctorInfo, "pnlDoctorInfo");
            this.pnlDoctorInfo.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlDoctorInfo.BackgroundImage = null;
            this.pnlDoctorInfo.Controls.Add(this.dbxToDoctorName);
            this.pnlDoctorInfo.Controls.Add(this.fbxToDoctor);
            this.pnlDoctorInfo.Controls.Add(this.xLabel6);
            this.pnlDoctorInfo.Controls.Add(this.dbxToGwaName);
            this.pnlDoctorInfo.Controls.Add(this.fbxToGwa);
            this.pnlDoctorInfo.Controls.Add(this.xLabel7);
            this.pnlDoctorInfo.Font = null;
            this.pnlDoctorInfo.Name = "pnlDoctorInfo";
            // 
            // dbxToDoctorName
            // 
            this.dbxToDoctorName.AccessibleDescription = null;
            this.dbxToDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxToDoctorName, "dbxToDoctorName");
            this.dbxToDoctorName.Image = null;
            this.dbxToDoctorName.Name = "dbxToDoctorName";
            // 
            // fbxToDoctor
            // 
            this.fbxToDoctor.AccessibleDescription = null;
            this.fbxToDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxToDoctor, "fbxToDoctor");
            this.fbxToDoctor.ApplyByteLimit = true;
            this.fbxToDoctor.AutoTabDataSelected = true;
            this.fbxToDoctor.BackgroundImage = null;
            this.fbxToDoctor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxToDoctor.FindWorker = this.fwkCommon;
            this.fbxToDoctor.Name = "fbxToDoctor";
            this.fbxToDoctor.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxToDoctor.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // dbxToGwaName
            // 
            this.dbxToGwaName.AccessibleDescription = null;
            this.dbxToGwaName.AccessibleName = null;
            resources.ApplyResources(this.dbxToGwaName, "dbxToGwaName");
            this.dbxToGwaName.Image = null;
            this.dbxToGwaName.Name = "dbxToGwaName";
            // 
            // fbxToGwa
            // 
            this.fbxToGwa.AccessibleDescription = null;
            this.fbxToGwa.AccessibleName = null;
            resources.ApplyResources(this.fbxToGwa, "fbxToGwa");
            this.fbxToGwa.ApplyByteLimit = true;
            this.fbxToGwa.AutoTabDataSelected = true;
            this.fbxToGwa.BackgroundImage = null;
            this.fbxToGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxToGwa.FindWorker = this.fwkCommon;
            this.fbxToGwa.Name = "fbxToGwa";
            this.fbxToGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.FindBox_DataValidating);
            this.fbxToGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // dtpNaewon_Date
            // 
            this.dtpNaewon_Date.AccessibleDescription = null;
            this.dtpNaewon_Date.AccessibleName = null;
            this.dtpNaewon_Date.AllowDrop = true;
            resources.ApplyResources(this.dtpNaewon_Date, "dtpNaewon_Date");
            this.dtpNaewon_Date.BackgroundImage = null;
            this.dtpNaewon_Date.IsVietnameseYearType = false;
            this.dtpNaewon_Date.Name = "dtpNaewon_Date";
            this.dtpNaewon_Date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewon_Date_DataValidating);
            // 
            // pbxSearch
            // 
            this.pbxSearch.AccessibleDescription = null;
            this.pbxSearch.AccessibleName = null;
            resources.ApplyResources(this.pbxSearch, "pbxSearch");
            this.pbxSearch.BackgroundImage = null;
            this.pbxSearch.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.PatientSelectionFailed += new System.EventHandler(this.pbxSearch_PatientSelectionFailed);
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // lblNaewon_DateTitle
            // 
            this.lblNaewon_DateTitle.AccessibleDescription = null;
            this.lblNaewon_DateTitle.AccessibleName = null;
            this.lblNaewon_DateTitle.AllowDrop = true;
            resources.ApplyResources(this.lblNaewon_DateTitle, "lblNaewon_DateTitle");
            this.lblNaewon_DateTitle.Image = null;
            this.lblNaewon_DateTitle.Name = "lblNaewon_DateTitle";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnOutInpCopy);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnOutInpCopy
            // 
            this.btnOutInpCopy.AccessibleDescription = null;
            this.btnOutInpCopy.AccessibleName = null;
            resources.ApplyResources(this.btnOutInpCopy, "btnOutInpCopy");
            this.btnOutInpCopy.BackgroundImage = null;
            this.btnOutInpCopy.Image = global::IHIS.OCSO.Properties.Resources.복사;
            this.btnOutInpCopy.Name = "btnOutInpCopy";
            this.btnOutInpCopy.Click += new System.EventHandler(this.btnOutInpCopy_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.tvwGwa);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // tvwGwa
            // 
            this.tvwGwa.AccessibleDescription = null;
            this.tvwGwa.AccessibleName = null;
            resources.ApplyResources(this.tvwGwa, "tvwGwa");
            this.tvwGwa.BackgroundImage = null;
            this.tvwGwa.ImageList = this.ImageList;
            this.tvwGwa.Name = "tvwGwa";
            this.tvwGwa.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwGwa_AfterSelect);
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.chkAll);
            this.xPanel6.Controls.Add(this.rbtIn);
            this.xPanel6.Controls.Add(this.rbtOut);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            // 
            // chkAll
            // 
            this.chkAll.AccessibleDescription = null;
            this.chkAll.AccessibleName = null;
            resources.ApplyResources(this.chkAll, "chkAll");
            this.chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkAll.BackgroundImage = null;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Font = null;
            this.chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.chkAll.ImageList = this.ImageList;
            this.chkAll.Name = "chkAll";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // rbtIn
            // 
            this.rbtIn.AccessibleDescription = null;
            this.rbtIn.AccessibleName = null;
            resources.ApplyResources(this.rbtIn, "rbtIn");
            this.rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rbtIn.BackgroundImage = null;
            this.rbtIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.rbtIn.ImageList = this.ImageList;
            this.rbtIn.Name = "rbtIn";
            this.rbtIn.UseVisualStyleBackColor = false;
            // 
            // rbtOut
            // 
            this.rbtOut.AccessibleDescription = null;
            this.rbtOut.AccessibleName = null;
            resources.ApplyResources(this.rbtOut, "rbtOut");
            this.rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.rbtOut.BackgroundImage = null;
            this.rbtOut.Checked = true;
            this.rbtOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbtOut.ImageList = this.ImageList;
            this.rbtOut.Name = "rbtOut";
            this.rbtOut.TabStop = true;
            this.rbtOut.UseVisualStyleBackColor = false;
            this.rbtOut.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            this.xPanel4.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdOutSang);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdOutSang
            // 
            resources.ApplyResources(this.grdOutSang, "grdOutSang");
            this.grdOutSang.ApplyPaintEventToAllColumn = true;
            this.grdOutSang.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell379,
            this.xEditGridCell381,
            this.xEditGridCell3,
            this.xEditGridCell1,
            this.xEditGridCell82,
            this.xEditGridCell380,
            this.xEditGridCell385,
            this.xEditGridCell384,
            this.xEditGridCell93,
            this.xEditGridCell2,
            this.xEditGridCell383,
            this.xEditGridCell374,
            this.xEditGridCell375,
            this.xEditGridCell77,
            this.xEditGridCell373,
            this.xEditGridCellsang_start_date,
            this.xEditGridCell27,
            this.xEditGridCellsang_end_sayu,
            this.xEditGridCell81,
            this.xEditGridCell382,
            this.xEditGridCell47,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell92,
            this.xEditGridCell76,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell42,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell7});
            this.grdOutSang.ColPerLine = 13;
            this.grdOutSang.ColResizable = true;
            this.grdOutSang.Cols = 14;
            this.grdOutSang.EnableMultiSelection = true;
            this.grdOutSang.ExecuteQuery = null;
            this.grdOutSang.FixedCols = 1;
            this.grdOutSang.FixedRows = 1;
            this.grdOutSang.FocusColumnName = "sang_code";
            this.grdOutSang.HeaderHeights.Add(28);
            this.grdOutSang.Name = "grdOutSang";
            this.grdOutSang.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOutSang.ParamList")));
            this.grdOutSang.QuerySQL = resources.GetString("grdOutSang.QuerySQL");
            this.grdOutSang.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOutSang.RowHeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOutSang.RowHeaderVisible = true;
            this.grdOutSang.Rows = 2;
            this.grdOutSang.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOutSang.SelectionModeChangeable = true;
            this.grdOutSang.ShowNumberAtRowHeader = false;
            this.grdOutSang.TogglingRowSelection = true;
            this.grdOutSang.ToolTipActive = true;
            this.grdOutSang.ToolTipType = IHIS.Framework.XGridToolTipType.ColumnDesc;
            this.grdOutSang.Click += new System.EventHandler(this.grdOutSang_Click);
            this.grdOutSang.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOutSang_GridFindSelected);
            this.grdOutSang.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdOutSang_GridButtonClick);
            this.grdOutSang.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOutSang_GridColumnChanged);
            this.grdOutSang.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOutSang_MouseDown);
            this.grdOutSang.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOutSang_GridFindClick);
            this.grdOutSang.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOutSang_RowFocusChanged);
            this.grdOutSang.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOutSang_GridCellPainting);
            this.grdOutSang.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOutSang_ItemValueChanging);
            this.grdOutSang.GridCellFocusChanged += new IHIS.Framework.XGridCellFocusChangedEventHandler(this.grdOutSang_GridCellFocusChanged);
            this.grdOutSang.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOutSang_GridColumnProtectModify);
            this.grdOutSang.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOutSang_QueryStarting);
            // 
            // xEditGridCell379
            // 
            this.xEditGridCell379.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell379.CellLen = 9;
            this.xEditGridCell379.CellName = "bunho";
            this.xEditGridCell379.Col = -1;
            this.xEditGridCell379.ExecuteQuery = null;
            this.xEditGridCell379.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell379.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell379, "xEditGridCell379");
            this.xEditGridCell379.IsVisible = false;
            this.xEditGridCell379.Row = -1;
            this.xEditGridCell379.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell381
            // 
            this.xEditGridCell381.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell381.CellName = "gwa";
            this.xEditGridCell381.Col = -1;
            this.xEditGridCell381.ExecuteQuery = null;
            this.xEditGridCell381.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell381.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell381, "xEditGridCell381");
            this.xEditGridCell381.IsVisible = false;
            this.xEditGridCell381.Row = -1;
            this.xEditGridCell381.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "gwa_name";
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "io_gubun";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell82.CellName = "pk_seq";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            this.xEditGridCell82.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            this.xEditGridCell82.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell380
            // 
            this.xEditGridCell380.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell380.CellName = "naewon_date";
            this.xEditGridCell380.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell380.Col = -1;
            this.xEditGridCell380.ExecuteQuery = null;
            this.xEditGridCell380.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell380.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell380, "xEditGridCell380");
            this.xEditGridCell380.IsVisible = false;
            this.xEditGridCell380.Row = -1;
            this.xEditGridCell380.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell385
            // 
            this.xEditGridCell385.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell385.CellLen = 5;
            this.xEditGridCell385.CellName = "doctor";
            this.xEditGridCell385.Col = -1;
            this.xEditGridCell385.ExecuteQuery = null;
            this.xEditGridCell385.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell385.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell385, "xEditGridCell385");
            this.xEditGridCell385.IsVisible = false;
            this.xEditGridCell385.Row = -1;
            this.xEditGridCell385.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell384
            // 
            this.xEditGridCell384.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell384.CellLen = 1;
            this.xEditGridCell384.CellName = "naewon_type";
            this.xEditGridCell384.Col = -1;
            this.xEditGridCell384.ExecuteQuery = null;
            this.xEditGridCell384.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell384.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell384, "xEditGridCell384");
            this.xEditGridCell384.IsVisible = false;
            this.xEditGridCell384.Row = -1;
            this.xEditGridCell384.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellName = "jubsu_no";
            this.xEditGridCell93.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell383
            // 
            this.xEditGridCell383.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell383.CellName = "input_id";
            this.xEditGridCell383.Col = -1;
            this.xEditGridCell383.ExecuteQuery = null;
            this.xEditGridCell383.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell383.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell383, "xEditGridCell383");
            this.xEditGridCell383.IsVisible = false;
            this.xEditGridCell383.Row = -1;
            this.xEditGridCell383.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell374
            // 
            this.xEditGridCell374.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell374.ApplyPaintingEvent = true;
            this.xEditGridCell374.CellLen = 30;
            this.xEditGridCell374.CellName = "sang_code";
            this.xEditGridCell374.Col = 3;
            this.xEditGridCell374.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell374.ExecuteQuery = null;
            this.xEditGridCell374.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell374, "xEditGridCell374");
            this.xEditGridCell374.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell374.IsNotNull = true;
            this.xEditGridCell374.IsUpdatable = false;
            this.xEditGridCell374.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell375
            // 
            this.xEditGridCell375.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell375.CellLen = 200;
            this.xEditGridCell375.CellName = "sang_name";
            this.xEditGridCell375.CellWidth = 294;
            this.xEditGridCell375.Col = -1;
            this.xEditGridCell375.ExecuteQuery = null;
            this.xEditGridCell375.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell375, "xEditGridCell375");
            this.xEditGridCell375.IsVisible = false;
            this.xEditGridCell375.Row = -1;
            this.xEditGridCell375.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellLen = 1200;
            this.xEditGridCell77.CellName = "display_sang_name";
            this.xEditGridCell77.CellWidth = 234;
            this.xEditGridCell77.Col = 6;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell373
            // 
            this.xEditGridCell373.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell373.CellLen = 1;
            this.xEditGridCell373.CellName = "ju_sang_yn";
            this.xEditGridCell373.CellWidth = 44;
            this.xEditGridCell373.Col = 1;
            this.xEditGridCell373.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell373.ExecuteQuery = null;
            this.xEditGridCell373.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell373, "xEditGridCell373");
            this.xEditGridCell373.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellsang_start_date
            // 
            this.xEditGridCellsang_start_date.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellsang_start_date.CellName = "sang_start_date";
            this.xEditGridCellsang_start_date.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCellsang_start_date.CellWidth = 148;
            this.xEditGridCellsang_start_date.Col = 8;
            this.xEditGridCellsang_start_date.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCellsang_start_date.ExecuteQuery = null;
            this.xEditGridCellsang_start_date.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellsang_start_date, "xEditGridCellsang_start_date");
            this.xEditGridCellsang_start_date.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "sang_end_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.CellWidth = 110;
            this.xEditGridCell27.Col = 10;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCellsang_end_sayu
            // 
            this.xEditGridCellsang_end_sayu.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCellsang_end_sayu.CellLen = 2;
            this.xEditGridCellsang_end_sayu.CellName = "sang_end_sayu";
            this.xEditGridCellsang_end_sayu.CellWidth = 58;
            this.xEditGridCellsang_end_sayu.Col = 11;
            this.xEditGridCellsang_end_sayu.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCellsang_end_sayu.ExecuteQuery = null;
            this.xEditGridCellsang_end_sayu.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCellsang_end_sayu, "xEditGridCellsang_end_sayu");
            this.xEditGridCellsang_end_sayu.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell81.CellLen = 80;
            this.xEditGridCell81.CellName = "sang_end_sayu_name";
            this.xEditGridCell81.CellWidth = 110;
            this.xEditGridCell81.Col = 12;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell382
            // 
            this.xEditGridCell382.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell382.CellName = "ser";
            this.xEditGridCell382.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell382.Col = -1;
            this.xEditGridCell382.ExecuteQuery = null;
            this.xEditGridCell382.HeaderDrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
            this.xEditGridCell382.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell382, "xEditGridCell382");
            this.xEditGridCell382.IsVisible = false;
            this.xEditGridCell382.Row = -1;
            this.xEditGridCell382.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellLen = 4;
            this.xEditGridCell47.CellName = "pre_modifier1";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellLen = 4;
            this.xEditGridCell53.CellName = "pre_modifier2";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.CellLen = 4;
            this.xEditGridCell54.CellName = "pre_modifier3";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.CellLen = 4;
            this.xEditGridCell60.CellName = "pre_modifier4";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.CellLen = 4;
            this.xEditGridCell61.CellName = "pre_modifier5";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell83.CellLen = 4;
            this.xEditGridCell83.CellName = "pre_modifier6";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            this.xEditGridCell83.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell84.CellLen = 4;
            this.xEditGridCell84.CellName = "pre_modifier7";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            this.xEditGridCell84.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.CellLen = 4;
            this.xEditGridCell85.CellName = "pre_modifier8";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            this.xEditGridCell85.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellLen = 4;
            this.xEditGridCell86.CellName = "pre_modifier9";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellLen = 4;
            this.xEditGridCell87.CellName = "pre_modifier10";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.CellLen = 500;
            this.xEditGridCell65.CellName = "pre_modifier_name";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.CellLen = 4;
            this.xEditGridCell66.CellName = "post_modifier1";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.CellLen = 4;
            this.xEditGridCell70.CellName = "post_modifier2";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellLen = 4;
            this.xEditGridCell71.CellName = "post_modifier3";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            this.xEditGridCell71.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.CellLen = 4;
            this.xEditGridCell74.CellName = "post_modifier4";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            this.xEditGridCell74.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell75.CellLen = 4;
            this.xEditGridCell75.CellName = "post_modifier5";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellLen = 4;
            this.xEditGridCell88.CellName = "post_modifier6";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.CellLen = 4;
            this.xEditGridCell89.CellName = "post_modifier7";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellLen = 4;
            this.xEditGridCell90.CellName = "post_modifier8";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellLen = 4;
            this.xEditGridCell91.CellName = "post_modifier9";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellLen = 4;
            this.xEditGridCell92.CellName = "post_modifier10";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellLen = 500;
            this.xEditGridCell76.CellName = "post_modifier_name";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "sang_jindan_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 110;
            this.xEditGridCell4.Col = 9;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "data_gubun";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "if_data_send_yn";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell42.ButtonImage")));
            this.xEditGridCell42.CellLen = 1;
            this.xEditGridCell42.CellName = "sang_button";
            this.xEditGridCell42.CellWidth = 23;
            this.xEditGridCell42.Col = 4;
            this.xEditGridCell42.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdCol = false;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell78.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell78.ButtonImage")));
            this.xEditGridCell78.CellName = "susik_button";
            this.xEditGridCell78.Col = 5;
            this.xEditGridCell78.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell79.ApplyPaintingEvent = true;
            this.xEditGridCell79.CellName = "doubt";
            this.xEditGridCell79.CellWidth = 64;
            this.xEditGridCell79.Col = 7;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsUpdCol = false;
            this.xEditGridCell79.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "emr_permission";
            this.xEditGridCell7.CellWidth = 102;
            this.xEditGridCell7.Col = 13;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // timIcon
            // 
            this.timIcon.Interval = 3000;
            this.timIcon.Tick += new System.EventHandler(this.timIcon_Tick);
            // 
            // pbxUnderArrow
            // 
            this.pbxUnderArrow.AccessibleDescription = null;
            this.pbxUnderArrow.AccessibleName = null;
            resources.ApplyResources(this.pbxUnderArrow, "pbxUnderArrow");
            this.pbxUnderArrow.BackgroundImage = null;
            this.pbxUnderArrow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxUnderArrow.Font = null;
            this.pbxUnderArrow.ImageLocation = null;
            this.pbxUnderArrow.Name = "pbxUnderArrow";
            this.pbxUnderArrow.TabStop = false;
            // 
            // pnlFill
            // 
            this.pnlFill.AccessibleDescription = null;
            this.pnlFill.AccessibleName = null;
            this.pnlFill.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.BackgroundImage = null;
            this.pnlFill.Font = null;
            this.pnlFill.Name = "pnlFill";
            // 
            // OUTSANGU00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pbxUnderArrow);
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUTSANGU00";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUTSANGU00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            this.pnlDoctorInfo.ResumeLayout(false);
            this.pnlDoctorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOutSang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region [Screen Event]

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        #region 타Screen에서 Open (Command)	

        public override object Command(string command, CommonItemCollection commandParam)
        {
            // Command Event Parameter : commandParam을 기억해둔다.(Command Event에서 처리못하는 케이스에서 사용됨(ScreenOpen(Response)후 바로 아래에서 로직 기술해야되는경우)
            //this.mCommand = command; this.mCommandParam = commandParam; 

            int insertRow;
            int currentRow;
            string display_sang_name;

            switch (command.Trim())
            {
                case "CHT0115Q00": // 수식어정보

                    if (commandParam.Contains("CHT0115") && (MultiLayout) commandParam["CHT0115"] != null &&
                        ((MultiLayout) commandParam["CHT0115"]).RowCount > 0)
                    {
                        if (this.grdOutSang.CurrentRowNumber >= 0)
                        {
                            this.grdOutSang.Focus();
                            this.grdOutSang.SetFocusToItem(this.grdOutSang.CurrentRowNumber, "sang_code");

                            foreach (XEditGridCell cell in grdOutSang.CellInfos)
                            {
                                if (((MultiLayout) commandParam["CHT0115"]).LayoutItems.Contains(cell.CellName))
                                    grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, cell.CellName,
                                        ((MultiLayout) commandParam["CHT0115"]).GetItemString(0, cell.CellName));
                            }

                            //display 상병명
                            display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                "pre_modifier_name")
                                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                                +
                                                grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                                    "post_modifier_name");
                            grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                            grdOutSang.Refresh();


                        }
                    }
                    break;

                case "CHT0110Q01": // 상병조회

                    if (commandParam.Contains("CHT0110") && (MultiLayout) commandParam["CHT0110"] != null &&
                        ((MultiLayout) commandParam["CHT0110"]).RowCount > 0)
                    {
                        currentRow = this.grdOutSang.CurrentRowNumber;
                        this.grdOutSang.Focus();

                        foreach (DataRow row in ((MultiLayout) commandParam["CHT0110"]).LayoutTable.Rows)
                        {
                            if (currentRow >= 0)
                            {
                                this.grdOutSang.SetItemValue(currentRow, "sang_code", row["sang_code"]);
                                this.grdOutSang.SetItemValue(currentRow, "sang_name", row["sang_name"]);

                                display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                    "pre_modifier_name")
                                                    + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                                    +
                                                    grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                                        "post_modifier_name");
                                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name",
                                    display_sang_name);

                                // 2016.01.14 https://sofiamedix.atlassian.net/browse/MED-6791 START
                                // IO_Gubun
                                if (this.rbtIn.Checked == true)
                                {
                                    this.grdOutSang.SetItemValue(currentRow, "io_gubun", "I");
                                }
                                else if (this.rbtOut.Checked == true)
                                {
                                    this.grdOutSang.SetItemValue(currentRow, "io_gubun", "O");
                                }
                                // 患者番号
                                this.grdOutSang.SetItemValue(currentRow, "bunho", pbxSearch.BunHo);
                                // Doctor 
                                this.grdOutSang.SetItemValue(currentRow, "doctor", this.fbxToDoctor.GetDataValue());
                                // input_id (登録者 ＩＤ)
                                this.grdOutSang.SetItemValue(currentRow, "input_id", UserInfo.UserID);
                                // 2016.01.14 https://sofiamedix.atlassian.net/browse/MED-6791 END

                                grdOutSang.Refresh();
                                currentRow = -1;
                            }
                            else
                            {
                                insertRow = this.grdOutSang.InsertRow(this.grdOutSang.CurrentRowNumber);
                                this.grdOutSang.SetItemValue(insertRow, "bunho", pbxSearch.BunHo);
                                this.grdOutSang.SetItemValue(insertRow, "gwa", tvwGwa.SelectedNode.Tag.ToString());
                                this.grdOutSang.SetItemValue(insertRow, "naewon_date", this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_start_date", this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_code", row["sang_code"]);
                                this.grdOutSang.SetItemValue(insertRow, "sang_name", row["sang_name"]);
                                this.grdOutSang.SetItemValue(insertRow, "display_sang_name", row["sang_name"]);
                                this.grdOutSang.SetItemValue(insertRow, "sang_jindan_date", this.dtpNaewon_Date.GetDataValue());

                                // 2016.01.14 https://sofiamedix.atlassian.net/browse/MED-6791 START
                                // IO_Gubun
                                if (this.rbtIn.Checked == true)
                                {
                                    this.grdOutSang.SetItemValue(insertRow, "io_gubun", "I");
                                }
                                else if (this.rbtOut.Checked == true)
                                {
                                    this.grdOutSang.SetItemValue(insertRow, "io_gubun", "O");
                                }
                                // 患者番号
                                this.grdOutSang.SetItemValue(insertRow, "bunho", pbxSearch.BunHo);
                                // Doctor 
                                this.grdOutSang.SetItemValue(insertRow, "doctor", this.fbxToDoctor.GetDataValue());
                                // input_id (登録者 ＩＤ)
                                this.grdOutSang.SetItemValue(insertRow, "input_id", UserInfo.UserID);
                                // 2016.01.14 https://sofiamedix.atlassian.net/browse/MED-6791 END

                                //HungNV added for issue : MED-6234
                                string gwa = tvwGwa.SelectedNode.Tag.ToString();
                                string gwa_name = this.tvwGwa.Nodes[this.tvwGwa.SelectedNode.Index].Text;
                                if (gwa == "%")
                                {
                                    gwa = UserInfo.Gwa;
                                    gwa_name = UserInfo.GwaName;
                                }
                                if (this.rbtIn.Checked == true)
                                    grdOutSang.SetItemValue(insertRow, "io_gubun", "I");
                                else if (this.rbtOut.Checked == true)
                                    grdOutSang.SetItemValue(insertRow, "io_gubun", "O");

                                this.grdOutSang.SetItemValue(insertRow, "gwa_name", gwa_name);
                                this.grdOutSang.SetItemValue(insertRow, "doctor", this.fbxToDoctor.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "input_id", UserInfo.UserID);
                                this.grdOutSang.SetItemValue(insertRow, "ju_sang_yn", "N");

                                // https://sofiamedix.atlassian.net/browse/MED-16409
                                grdOutSang.SetItemValue(insertRow, "emr_permission", Resources.PERMISION_DOCTOR + "," + Resources.PERMISION_OTHERCLINIC + "," + Resources.PERMISION_RELATED + "," + Resources.PERMISION_PATIENT);
                            }
                        }

                        this.grdOutSang.AcceptData();
                    }

                    break;

                case "OCS0204Q00": // 사용자 약속상병조회					

                    #region

                    if (commandParam.Contains("OCS0205") && (MultiLayout) commandParam["OCS0205"] != null &&
                        ((MultiLayout) commandParam["OCS0205"]).RowCount > 0)
                    {
                        currentRow = this.grdOutSang.CurrentRowNumber;
                        this.grdOutSang.Focus();

                        foreach (DataRow row in ((MultiLayout) commandParam["OCS0205"]).LayoutTable.Rows)
                        {
                            if (currentRow >= 0)
                            {
                                insertRow = currentRow;
                                currentRow = -1;
                            }
                            else
                            {
                                insertRow = this.grdOutSang.InsertRow(this.grdOutSang.CurrentRowNumber);
                                this.grdOutSang.SetItemValue(insertRow, "bunho", pbxSearch.BunHo);
                                this.grdOutSang.SetItemValue(insertRow, "gwa", tvwGwa.SelectedNode.Tag.ToString());
                                this.grdOutSang.SetItemValue(insertRow, "naewon_date",
                                    this.dtpNaewon_Date.GetDataValue());
                                this.grdOutSang.SetItemValue(insertRow, "sang_start_date",
                                    this.dtpNaewon_Date.GetDataValue());
                                //https://sofiamedix.atlassian.net/browse/MED-16798
                                this.grdOutSang.SetItemValue(insertRow, "io_gubun", "O");
                            }

                            foreach (XEditGridCell cell in grdOutSang.CellInfos)
                            {
                                if (((MultiLayout) commandParam["OCS0205"]).LayoutItems.Contains(cell.CellName))
                                    grdOutSang.SetItemValue(insertRow, cell.CellName, row[cell.CellName]);
                            }

                            //display 상병명
                            display_sang_name = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                "pre_modifier_name")
                                                + grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_name")
                                                +
                                                grdOutSang.GetItemString(grdOutSang.CurrentRowNumber,
                                                    "post_modifier_name");
                            grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "display_sang_name", display_sang_name);

                            grdOutSang.Refresh();
                        }

                        this.grdOutSang.AcceptData();
                    }

                    break;

                    #endregion


            }

            return base.Command(command, commandParam);
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnLoad(EventArgs e)
        {
            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("io_gubun"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["io_gubun"].ToString()))
                            mIO_gubun = OpenParam["io_gubun"].ToString();
                    }

                    if (OpenParam.Contains("bunho"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["bunho"].ToString()))
                            mBunho = OpenParam["bunho"].ToString();
                    }

                    if (OpenParam.Contains("gwa"))
                    {
                        if (!TypeCheck.IsNull(OpenParam["gwa"].ToString()))
                            mGwa = OpenParam["gwa"].ToString();
                    }

                    if (OpenParam.Contains("naewon_date"))
                    {
                        if (!TypeCheck.IsDateTime(OpenParam["naewon_date"].ToString()))
                            mNaewon_date = OpenParam["naewon_date"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
                    this.Close();
                }
            }

            PostCallHelper.PostCall(PostLoad);
        }

        private void PostLoad()
        {
            if (mIO_gubun == "O")
                this.rbtOut.Checked = true;
            else
                this.rbtIn.Checked = true;

            if (TypeCheck.IsNull(mGwa))
                mGwa = UserInfo.Gwa;

            if (!TypeCheck.IsDateTime(mNaewon_date))
                mNaewon_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            dtpNaewon_Date.SetDataValue(mNaewon_date);

            if (TypeCheck.IsNull(mBunho))
            {
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);

                if (patientInfo == null || (patientInfo != null && TypeCheck.IsNull(patientInfo.BunHo)))
                {
                    // 이전 스크린의 등록번호를 못가지고 온 경우, 열려있는 전체 스크린에서 등록번호를 가져온다
                    patientInfo = XScreen.GetOtherScreenBunHo(this, true);
                }

                if (patientInfo != null)
                {
                    this.pbxSearch.SetPatientID(patientInfo.BunHo);
                }

            }
            else
                this.pbxSearch.SetPatientID(mBunho);

            ShowGwa();

            this.mSelectedPatientInfo = new IHIS.OCS.PatientInfo(this.Name); // 환자정보 

            if (UserInfo.UserGubun == UserType.Doctor)
            {
                //this.pnlDoctorInfo.Visible = false;

                //this.fbxToGwa.Text = UserInfo.Gwa;
                this.fbxToGwa.SetEditValue(UserInfo.Gwa);
                this.fbxToGwa.AcceptData();
                //this.dbxToGwaName.Text = UserInfo.GwaName;
                this.fbxToDoctor.Text = UserInfo.DoctorID;
                this.fbxToDoctor.AcceptData();
                //this.dbxToDoctorName.Text 

            }

        }

        #endregion

        #region [Control]

        private void dtpNaewon_Date_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.LoadData();
        }

        private void rbtOut_CheckedChanged(object sender, System.EventArgs e)
        {
            //외래
            if (rbtOut.Checked)
            {
                rbtOut.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtOut.ImageIndex = 6;

                rbtIn.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtIn.ImageIndex = 5;

                btnOutInpCopy.Text = Resources.btnOutInpCopy_Text1;

            }
                //입원
            else
            {
                rbtIn.BackColor = System.Drawing.SystemColors.ActiveCaption;
                rbtIn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                rbtIn.ImageIndex = 6;

                rbtOut.BackColor = System.Drawing.SystemColors.InactiveCaption;
                rbtOut.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                rbtOut.ImageIndex = 5;

                btnOutInpCopy.Text = Resources.btnOutInpCopy_Text2;
            }

            LoadData();

        }

        private void chkAll_CheckedChanged(object sender, System.EventArgs e)
        {

            if (chkAll.Checked)
            {
                chkAll.BackColor = System.Drawing.SystemColors.ActiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                chkAll.ImageIndex = 6;

                dtpNaewon_Date.Enabled = false;
            }
            else
            {
                chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
                chkAll.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
                chkAll.ImageIndex = 5;

                dtpNaewon_Date.Enabled = true;
            }

            LoadData();
        }

        #endregion

        #region [ButtonList]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:

                    e.IsBaseCall = false;

                    LoadData();

                    break;

                case FunctionType.Insert:

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
                    //grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "emr_permission", "D,O,R,P");
                    grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "emr_permission", Resources.PERMISION_DOCTOR + "," + Resources.PERMISION_OTHERCLINIC + "," + Resources.PERMISION_RELATED + "," + Resources.PERMISION_PATIENT);
                    break;


                    //e.IsBaseCall = false;

                    //if( TypeCheck.IsNull(pbxSearch.BunHo) || !TypeCheck.IsDateTime(this.dtpNaewon_Date.GetDataValue()) || tvwGwa.SelectedNode == null )
                    //    return;

                    //DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

                    //if(chkCell.RowNumber < 0)
                    //{
                    //    int currentRow = -1;
                    //    currentRow = grdOutSang.InsertRow();
                    //    grdOutSang.SetItemValue(currentRow, "bunho"          , pbxSearch.BunHo                   );
                    //    grdOutSang.SetItemValue(currentRow, "gwa"            , tvwGwa.SelectedNode.Tag.ToString());
                    //    grdOutSang.SetItemValue(currentRow, "naewon_date"    , this.dtpNaewon_Date.GetDataValue());
                    //    grdOutSang.SetItemValue(currentRow, "sang_start_date", this.dtpNaewon_Date.GetDataValue());
                    //    grdOutSang.SetItemValue(currentRow, "sang_jindan_date", this.dtpNaewon_Date.GetDataValue());		

                    //    if(rbtOut.Checked)
                    //        grdOutSang.SetItemValue(currentRow, "io_gubun", "O");
                    //    else
                    //        grdOutSang.SetItemValue(currentRow, "io_gubun", "I");
                    //}
                    //else
                    //    ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);

                    //break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    if (!ValidationCheckOutSang()) return;

                    // Connect to cloud execute grdOutSang.SaveLayout
                    OUTSANGU00GridOutSangSaveLayoutArgs args = new OUTSANGU00GridOutSangSaveLayoutArgs();
                    List<OUTSANGU00InitializeListItemInfo> lstListItemInfo = CreateListGridOutSangInfo();
                    if (lstListItemInfo == null || lstListItemInfo.Count < 1)
                    {
                        this.mainControl.btnProcess_Click();
                        return;
                    }
                    args.GridOutSangInfo = lstListItemInfo;
                    args.UserId = UserInfo.UserID;
                    args.Bunho = pbxSearch.BunHo;
                    UpdateResult updateResult =
                        CloudService.Instance.Submit<UpdateResult, OUTSANGU00GridOutSangSaveLayoutArgs>(args);

                    if (updateResult != null && updateResult.ExecutionStatus == ExecutionStatus.Success && updateResult.Result)
                    {
                        // https://nextop-asia.atlassian.net/browse/MED-6154
                        //mbxMsg = Resources.grdOutSang_MSGSaveLayout;
                        //SetMsg(mbxMsg);
                        XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.XMessageBox_Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //MED-14139
                        this.mainControl.btnProcess_Click();
                        try
                        {
                            IHIS.Framework.XScreen scrOpener = (XScreen) Opener;

                            CommonItemCollection commandParams = new CommonItemCollection();
                            commandParams.Add("retrieve", "Y");
                            scrOpener.Command(this.ScreenID, commandParams);
                        }
                        catch
                        {
                        }

                        this.LoadData();
                    }
                    else
                    {
                        //mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が失敗しました。" : "저장이 실패하였습니다."; 
                        //mbxMsg = mbxMsg + Service.ErrMsg;
                        //mbxCap = NetInfo.Language == LangMode.Jr ? "Save Error" : "Save Error";
                        //XMessageBox.Show(mbxMsg, mbxCap);

                        // https://nextop-asia.atlassian.net/browse/MED-6154
                        XMessageBox.Show(Resources.MSG_SAVE_FAIL, Resources.XMessageBox_Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    if (this.grdOutSang.GetItemString(this.grdOutSang.CurrentRowNumber, "gwa") == "%")
                    {
                        mbxMsg = Resources.grdOutSang_MSGDeleteRow;
                        XMessageBox.Show(mbxMsg, Resources.XMessageBox_Caption);
                        SetMsg(mbxMsg);
                        return;
                    }
                    else
                    {
                        this.grdOutSang.DeleteRow(this.grdOutSang.CurrentRowNumber);
                    }

                    break;
                default:

                    break;
            }
        }

        #endregion

        #region 환자번호입력시

        private void pbxSearch_PatientSelected(object sender, System.EventArgs e)
        {
            ControlClear();

            if (!TypeCheck.IsNull(this.pbxSearch.BunHo.ToString()))
                LoadData();
        }

        private void pbxSearch_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            ControlClear();
        }


        #endregion

        #region [Function]

        /// <summary>
        /// Control정보 Reset
        /// </summary>
        private void ControlClear()
        {
            //this.tvwGwa.Nodes.Clear();
            this.grdOutSang.Reset();
        }

        #region [Load Code Name]

        /// <summary>
        /// 해당 코드에 대한 명을 가져옵니다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns></returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = "";
            object retValu = null;

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "sang_end_sayu":

                    if (TypeCheck.IsNull(code))
                    {
                        codeName = "";
                        break;
                    }

                    // TODO comment use connect cloud
//                    cmdText = @"SELECT A.CODE_NAME                  
//                                  FROM BAS0102 A                    
//                                 WHERE A.CODE_TYPE = 'SANG_END_SAYU'
//                                   AND A.CODE      = '" + code + @"'
//                                   AND A.HOSP_CODE = '" + mHospCode + "'";
//
//                    retValu = Service.ExecuteScalar(cmdText);
//                    if (!TypeCheck.IsNull(retValu))
//                    {
//                        codeName = retValu.ToString();
//                    }
//                    else
//                    {
//                        codeName = "";
//                    }

                    // Connect to cloud service get code name
                    OUTSANGU00getCodeNameArgs args = new OUTSANGU00getCodeNameArgs();
                    args.Code = code;
                    args.SangEndSayU = "SANG_END_SAYU";

                    OUTSANGU00getCodeNameResult getCodeNameResult =
                        CloudService.Instance.Submit<OUTSANGU00getCodeNameResult, OUTSANGU00getCodeNameArgs>(args);
                    if (getCodeNameResult == null || TypeCheck.IsNull(getCodeNameResult.CodeName))
                    {
                        codeName = "";
                    }
                    else
                    {
                        codeName = getCodeNameResult.CodeName;
                    }

                    break;


                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [GetFindWorker]

        private XFindWorker GetFindWorker(string findMode)
        {
            XFindWorker fdwCommon = new IHIS.Framework.XFindWorker();

            switch (findMode)
            {
                case "sang_end_sayu":

                    fdwCommon.AutoQuery = true;
                    // TODO comment: Use connect cloud service
//					fdwCommon.InputSQL = ""    
//						+ "SELECT A.CODE, A.CODE_NAME           "
//						+ "  FROM BAS0102 A                     "
//						+ " WHERE A.CODE_TYPE = 'SANG_END_SAYU' "
//                        + "   AND A.HOSP_CODE = '" + mHospCode + "'"
//						+ " ORDER BY A.CODE ";

                    // Connec to cloud
                    fdwCommon.ExecuteQuery = fdwCommon_ExecuteQuery;

                    fdwCommon.FormText = Resources.fdwCommon_FormText;
                    fdwCommon.ColInfos.Add("sang_code", Resources.fdwCommon_Title_Code, FindColType.String, 100, 0, true,
                        FilterType.Yes);
                    fdwCommon.ColInfos.Add("sang_name", Resources.fdwCommon_Title_Name, FindColType.String, 300, 0, true,
                        FilterType.No);

                    break;

                default:
                    break;
            }

            return fdwCommon;
        }


        #endregion

        #endregion

        #region [TreeView 진료과]

        private void CreateGwaData()
        {
            layoutGwa.Reset();
            layoutGwa.LayoutItems.Clear();
            layoutGwa.LayoutItems.Add("gwa", DataType.String);
            layoutGwa.LayoutItems.Add("gwa_name", DataType.String);
            layoutGwa.InitializeLayoutTable();

            // TODO Comment: Use connect cloud
//            layoutGwa.QuerySQL = @"SELECT A.GWA, A.BUSEO_NAME
//                                     FROM BAS0260 A
//                                    WHERE A.OUT_JUBSU_YN = 'Y'
//                                      AND A.HOSP_CODE    = '" + mHospCode + @"'
//                                      AND A.START_DATE   = (SELECT MAX(B.START_DATE)              
//                                                              FROM BAS0260 B                     
//                                                             WHERE B.BUSEO_CODE  = A.BUSEO_CODE   
//                                                               AND B.START_DATE <= TRUNC(SYSDATE)
//                                                               AND B.HOSP_CODE   = A.HOSP_CODE  )
//                                   UNION
//
//                                   SELECT '%' as GWA , '全体' as BUSEO_NAME FROM SYS.DUAL
//                                   ORDER BY GWA";

            // Connect to cloud service
            layoutGwa.ExecuteQuery = layoutGwa_ExecuteQuery;
            layoutGwa.QueryLayout(true);
        }


        private void ShowGwa()
        {
            tvwGwa.Nodes.Clear();
            //외래접수가능한 과를 기준으로 생성
            CreateGwaData();
            if (this.layoutGwa.RowCount < 1) return;

            TreeNode node;

            //insert by jc [全体追加] 2012/05/08
            //node = new TreeNode("全体");
            //node.Tag = "%";
            //tvwGwa.Nodes.Add(node);	

            foreach (DataRow row in layoutGwa.LayoutTable.Rows)
            {
                node = new TreeNode(row["gwa_name"].ToString());
                node.Tag = row["gwa"].ToString();
                tvwGwa.Nodes.Add(node);
            }

            //해당 사용자의 진료과 선택
            foreach (TreeNode nodeGwa in tvwGwa.Nodes)
            {
                if (mGwa == nodeGwa.Tag.ToString())
                {
                    tvwGwa.SelectedNode = nodeGwa;
                    break;
                }
            }

            if (tvwGwa.SelectedNode == null)
                tvwGwa.SelectedNode = tvwGwa.Nodes[0];

        }

        private void tvwGwa_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            LoadData();
        }

        #endregion

        #region [Data Load]

        private void LoadData()
        {
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;


                if (tvwGwa.SelectedNode != null)
                    this.grdOutSang.SetBindVarValue("f_gwa", tvwGwa.SelectedNode.Tag.ToString());

                if (rbtOut.Checked)
                    this.grdOutSang.SetBindVarValue("f_io_gubun", "O");
                else
                    this.grdOutSang.SetBindVarValue("f_io_gubun", "I");

                if (chkAll.Checked)
                    this.grdOutSang.SetBindVarValue("f_all_sang_yn", "Y");
                else
                    this.grdOutSang.SetBindVarValue("f_all_sang_yn", "N");

                this.grdOutSang.SetBindVarValue("f_bunho", pbxSearch.BunHo);
                this.grdOutSang.SetBindVarValue("f_gijun_date", dtpNaewon_Date.GetDataValue());
                this.grdOutSang.SetBindVarValue("f_hosp_code", mHospCode);
                // Connect to cloud
                this.grdOutSang.ExecuteQuery = grdOutSang_ExecuteQuery;
                this.grdOutSang.QueryLayout(true);

                setDataForPermission();

               
            }
            finally
            {
                SetMsg(" ");
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
            
        }

        private void setDataForPermission()
        {
            for (int i = 0; i < permission_list.Count; i++)
            {
                int data = Int32.Parse(permission_list[i]);
                grdOutSang.SetItemValue(i, "emr_permission", ConvertBinaryToStrPermission(data));
            }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////

        #region [상병입력 Grid Event]

        #region Focus 진입시 (Enter)

        /// <remarks>
        /// 빈 Grid시 New Row Insert
        /// </remarks>
        private void grdOutSang_Enter(object sender, System.EventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            //Set Current Grid
            this.CurrMSLayout = grd;
            this.CurrMQLayout = grd;


        }

        #endregion

        #region 컬럼 Focus 이동시 (GridCellFocusChanged)	

        /// <remarks>
        /// 컬럼 Focus시 디폴트 값이나, 특정 컬럼이 미리 입력이 되어 있어야 되는 경우등 처리..
        /// </remarks>
        private void grdOutSang_GridCellFocusChanged(object sender, IHIS.Framework.XGridCellFocusChangedEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            // width가 0인 컬럼은 입력통과
            if (((XEditGridCell) grd.CellInfos[e.ColName]).Col >= 0 &&
                grd.GetColWidth(((XEditGridCell) grd.CellInfos[e.ColName]).Col) == 0) SendKeys.Send("{TAB}");
        }

        #endregion

        #region Row 이동시 (RowFocusChanged)

        /// <remarks>
        /// </remarks>
        private void grdOutSang_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;
            mainControl.InitControlsToConnectCloud(grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_code"));
           // mainControl.OnLoad();
        }

        #endregion

        #region 컬럼 값 변경시 (GridColumnChanged)

        /// <remarks>
        /// Validation Check, 추가 정보 세팅..
        /// </remarks>
        private void grdOutSang_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

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
                        XMessageBox.Show(Resources.grdOutSang_GridColumnChanged_MSG1, Resources.XMessageBox_Caption);
                        return;
                    }

                    string pre_modifier_name = e.DataRow["pre_modifier_name"].ToString();
                    string post_modifier_name = e.DataRow["post_modifier_name"].ToString();

                    grdOutSang.SetItemValue(e.RowNumber, "sang_name", "");


                    if (e.ChangeValue.ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        //display상병명을 상병명으로 가져간다.
                        ClearSangName(grdOutSang, e.RowNumber);
                        grdOutSang.SetItemValue(e.RowNumber, "sang_name", e.DataRow["display_sang_name"]);
                        break;
                    }

                    grdOutSang.SetItemValue(e.RowNumber, "display_sang_name", pre_modifier_name + post_modifier_name);

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    string sang_name = GetCodeName(e.ColName, e.ChangeValue.ToString().Trim());

                    if (sang_name == "")
                    {
                        CommonItemCollection openParams = new CommonItemCollection();
                        openParams.Add("sang_inx", e.ChangeValue.ToString().Trim());
                        XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed,
                            openParams);
                        mainControl.InitControlsToConnectCloud(grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_code"));
                        break;
                    }
                    else
                        grdOutSang.SetItemValue(e.RowNumber, "sang_name", sang_name);

                    //display 상병명
                    grdOutSang.SetItemValue(e.RowNumber, "display_sang_name",
                        pre_modifier_name + sang_name + post_modifier_name);
                    

                    break;

                case "display_sang_name": // Display 상병명

                    ClearSangName(grdOutSang, e.RowNumber);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_code", OCS.OrderVariables.WORD_SANG_CODE);
                    grdOutSang.SetItemValue(e.RowNumber, "sang_name", e.ChangeValue);
                    break;

                case "sang_start_date":

                    #region 発症日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                        int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                    {
                        XMessageBox.Show(Resources.grdOutSang_GridColumnChanged_MSG2, Resources.XMessageBox_Caption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    #endregion

                    break;
                case "sang_jindan_date":

                    #region 診断日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                        int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")))
                    {
                        XMessageBox.Show(Resources.grdOutSang_GridColumnChanged_MSG3, Resources.XMessageBox_Caption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    #endregion

                    break;
                case "sang_end_date":

                    #region 終了日

                    //発症日は診断日より同じ及び過去である。
                    if (int.Parse(grd.GetItemString(e.RowNumber, "sang_start_date").Replace("/", "")) >
                        int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", ""))
                        ||
                        int.Parse(grd.GetItemString(e.RowNumber, "sang_jindan_date").Replace("/", "")) >
                        int.Parse(grd.GetItemString(e.RowNumber, "sang_end_date").Replace("/", "")))
                    {
                        XMessageBox.Show(Resources.grdOutSang_GridColumnChanged_MSG4, Resources.XMessageBox_Caption,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.mOrderFunc.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                        return;
                    }

                    if (e.ChangeValue.ToString() == "")
                    {
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu", ""); // 상병종료사유
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu_name", ""); // 상병종료사유명
                        return;
                    }

                    #endregion

                    break;


                case "sang_end_sayu": // 상병종료사유

                    #region

                    string code_name = "";

                    if (!TypeCheck.IsNull(e.ChangeValue))
                    {
                        code_name = GetCodeName("sang_end_sayu", e.ChangeValue.ToString());
                        if (TypeCheck.IsNull(code_name))
                        {
                            mbxMsg = Resources.grdOutSang_GridColumnChanged_MSG5;
                            mbxCap = "";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);

                            this.UndoPreviousValue(grd, e.RowNumber, e.ColName, previousValue);
                                // 이전값과 이전 RowState를 유지시킨다

                            return;
                        }

                        grd.SetItemValue(e.RowNumber, "sang_end_sayu_name", code_name);
                    }
                    else
                    {
                        grd.SetItemValue(e.RowNumber, "sang_end_sayu_name", "");
                    }

                    break;

                    #endregion

                default:
                    break;
            }
        }

        #endregion

        #region Combo, Check 필드 값 변경 즉시 (ItemValueChanging)

        private void grdOutSang_ItemValueChanging(object sender, IHIS.Framework.ItemValueChangingEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            //日本では複数の主傷病を持つことができる。
            //switch (e.ColName)
            //{
            //    case "ju_sang_yn": // 주상병 여부
            //        // 주상병은 한처방에 한건만 가능한다.. 주상병체크시 다른 Row의 주상병체크를 푼다
            //        if (e.ChangeValue.ToString().Trim() == "Y")
            //        {
            //            for (int i = 0; i < grd.RowCount; i++)
            //            {
            //                if (i != e.RowNumber)
            //                {
            //                    if (grd.GetItemString(i, e.ColName).Trim() == "Y") grd.SetItemValue(e.RowNumber, e.ColName, "N");
            //                }
            //            }
            //        }

            //        break;
            //    default:
            //        break;
            //}
        }

        #endregion

        #region 필드 Protect관리 Event(GridColumnProtectModify)

        /// <remarks>
        /// 로직으로 수정불가 필드 정의
        /// </remarks>
        private void grdOutSang_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;


            //診療科が％の場合はここでは修正できない。
            //if (grd.GetItemString(e.RowNumber, "gwa") == "%")
            //    e.Protect = true;

            // 상병종료일이 입력되지 않은 경우는 종료사유 입력 불가
            switch (e.ColName)
            {
                case "display_sang_name": // Display 상병명

                    if (grd.GetItemString(e.RowNumber, "gwa") == "%")
                        e.Protect = true;
                    else if (e.DataRow["sang_code"].ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE ||
                             e.DataRow["sang_code"].ToString().Trim() == "")
                        e.Protect = false;
                    else
                        e.Protect = true;
                    break;


                case "sang_end_sayu": // 상병종료사유
                    if (TypeCheck.IsNull(grd.GetItemValue(e.RowNumber, "sang_end_date"))) e.Protect = true;
                    break;

                case "doubt":
                    e.Protect = true;
                    break;

                case "susik_button":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                        e.Protect = true;
                    break;

                case "sang_button":
                    if (grd.GetItemString(e.RowNumber, "sang_code") == OCS.OrderVariables.WORD_SANG_CODE)
                        e.Protect = true;
                    break;
            }
        }

        #endregion

        #region  필드 색상/폰트 관리 Event (GridCellPainting)

        /// <remarks>
        /// 로직으로 필드 색상 변경
        /// </remarks>
        private void grdOutSang_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            // 필드속성이 수정불가인 경우 BackColor를 회색으로 바꾸어 유저한테 입력불가상태임을 알린다
            // ReadOnly인 경우 
            if (!((XEditGridCell) grd.CellInfos[e.ColName]).IsUpdatable &&
                (grd.GetRowState(e.RowNumber) == DataRowState.Unchanged ||
                 grd.GetRowState(e.RowNumber) == DataRowState.Modified) ||
                (((XEditGridCell) grd.CellInfos[e.ColName]).IsReadOnly))
            {
                //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                e.BackColor = XColor.XDisplayBoxBackColor.Color;
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
                            //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = XColor.XDisplayBoxBackColor.Color;
                                // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;						
                        }

                        break;

                    case "sang_end_sayu": // 상병종료사유
                        if (TypeCheck.IsNull(grd.GetItemValue(e.RowNumber, "sang_end_date")))
                        {
                            //e.DrawMode = IHIS.Framework.XCellDrawMode.Raised3D;
                            e.BackColor = XColor.XDisplayBoxBackColor.Color;
                                // Color.LightGray; // XColor.XGridAlterateRowBackColor.Color;
                        }
                        break;

                    case "doubt": // image처리

                        if (e.DataRow["sang_code"].ToString().Trim() == OCS.OrderVariables.WORD_SANG_CODE)
                        {
                            e.Image = this.ImageList.Images[2];
                            return;
                        }

                        if (CheckDoubt(grd, e.RowNumber))
                            e.Image = this.ImageList.Images[1];
                        else
                            e.Image = this.ImageList.Images[0];
                        break;
                }
            }

        }

        #endregion

        #region 특수Key Input시 (ProcessKeyDown)

        /// <remarks>
        /// Last Row에서 Key Down시 Insert Row처리
        /// </remarks>
        private void grdOutSang_ProcessKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            if (grd.FocusCell == null) return;

            //			switch (e.KeyCode)
            //			{
            //				case Keys.Down: // Key Down 입력시 Last Row인 경우 Insert Row를 수행함
            //					break;
            //			}
        }

        #endregion

        #region 버튼Type 필드 Click시 (GridButtonClick)
        
        private void grdOutSang_GridButtonClick(object sender, IHIS.Framework.GridButtonClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            switch (e.ColName)
            {
                case "sang_button": // 상병코드 버튼..

                    CommonItemCollection openParams = new CommonItemCollection();

                    openParams.Add("sang_code", "");
                    openParams.Add("memb", IHIS.Framework.UserInfo.UserID);

                    //사용자조회 화면 Open
                    XScreen.OpenScreenWithParam(this, "OCSA", "OCS0204Q00", ScreenOpenStyle.ResponseSizable, openParams);

                    break;

                case "susik_button":

                    ShowSusik(e.RowNumber);

                    break;
                //case "emr_permission":
                //    buttonTitle = "";
                //    permissionform = new PermisionForm(true, false, true, false);
                //    permissionform.passControl = new PermisionForm.PassControl(PassData);
                //    permissionform.StartPosition = FormStartPosition.Manual;
                //    permissionform.ShowDialog();

                    

                    break;

                default:
                    break;
            }
        }
        private void PassData(List<bool> sender)
        {
            string doctor;
            string other;
            string related;
            string patient;
            
            List<bool> result = sender;
           
            
            //doctor = (result[0] == true) ? "D" : "";
            //other = (result[1] == true) ? "O" : "";
            //related = (result[2] == true) ? "R" : "";
            //patient = (result[3] == true) ? "P" : "";

            doctor = (result[0] == true) ? Resources.PERMISION_DOCTOR : "";
            other = (result[1] == true) ? Resources.PERMISION_OTHERCLINIC : "";
            related = (result[2] == true) ? Resources.PERMISION_RELATED : "";
            patient = (result[3] == true) ? Resources.PERMISION_PATIENT : "";

            if (doctor != "") buttonTitle += doctor + ",";
            if (other != "") buttonTitle += other + ",";
            if (related != "") buttonTitle += related + ",";
            if (patient != "") buttonTitle += patient + ",";
            if (buttonTitle.Length > 1)
            {
                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "emr_permission", buttonTitle.Substring(0, buttonTitle.Length - 1));
            }
            else {
                grdOutSang.SetItemValue(grdOutSang.CurrentRowNumber, "emr_permission", "");
            }
        }

        #endregion

        #region Find SQL조건 및 필드 정의 (GridFindClick)

        private void grdOutSang_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            if (sender == null || e.RowNumber < 0) return;

            XEditGrid grd = sender as XEditGrid;

            if (sender == null ||
                ((XEditGridCell) grd.CellInfos[e.ColName]).CellEditor.EditorStyle != XCellEditorStyle.FindBox) return;

            switch (e.ColName)
            {
                case "sang_code": // 상병코드

                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("sang_inx",
                        ((XFindBox) ((XEditGridCell) grd.CellInfos[e.ColName]).CellEditor.Editor).GetDataValue());

                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseSizable, openParams);

                    e.Cancel = true; //Find창을 사용하지 않는다
                    mainControl.InitControlsToConnectCloud(grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "sang_code"));
                    break;

                case "sang_end_sayu":

                    ((XFindBox) ((XEditGridCell) grd.CellInfos[e.ColName]).CellEditor.Editor).FindWorker =
                        this.GetFindWorker(e.ColName);
                    break;

                case "emr_permission":
                    buttonTitle = "";

                    string list_permission = grdOutSang.GetItemString(grdOutSang.CurrentRowNumber, "emr_permission").ToString();
                    //bool doctor = list_permission.Contains("D");
                    //bool other = list_permission.Contains("O");
                    //bool related = list_permission.Contains("R");
                    //bool patient = list_permission.Contains("P");
                    bool doctor = list_permission.Contains(Resources.PERMISION_DOCTOR);
                    bool other = list_permission.Contains(Resources.PERMISION_OTHERCLINIC);
                    bool related = list_permission.Contains(Resources.PERMISION_RELATED);
                    bool patient = list_permission.Contains(Resources.PERMISION_PATIENT);

                    permissionform = new PermisionForm(doctor, other, related, patient);
                    permissionform.passControl = new PermisionForm.PassControl(PassData);
                    permissionform.StartPosition = FormStartPosition.Manual;
                    permissionform.Location = new Point(Cursor.Position.X - 100, Cursor.Position.Y + 10);

                    permissionform.ShowDialog(this);

                    break;

                default:

                    break;
            }
        }

        #endregion

        #region Find 데이타 선택시 Value 세팅.. (GridFindSelected)

        private void grdOutSang_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            if (sender == null) return;

            XEditGrid grd = sender as XEditGrid;

            grd.AcceptData();
            
        }

        #endregion

        #region [Mouse Down - 의증처리 ]

        private void grdOutSang_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //의증 + 접미어
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (grdOutSang.GetHitRowNumber(e.Y) < 0) return;

                int curRowIndex = grdOutSang.GetHitRowNumber(e.Y);

                if (grdOutSang.CurrentColName == "doubt")
                {
                    if (grdOutSang.GetItemString(curRowIndex, "sang_code") != OCS.OrderVariables.WORD_SANG_CODE)
                    {
                        if (CheckDoubt(grdOutSang, curRowIndex))
                        {
                            SetDoubt(false, grdOutSang, curRowIndex);
                        }
                        else
                        {
                            SetDoubt(true, grdOutSang, curRowIndex);
                        }
                    }

                    grdOutSang.Refresh();

                }
            }
        }

        #endregion

        #region [상병수식]

        private void ShowSusik(int currentRow)
        {
            IHIS.Framework.MultiLayout dloSusikInfo = new MultiLayout();
            dloSusikInfo.LayoutItems.Add("sang_name", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier1", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier2", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier3", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier4", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier5", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier6", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier7", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier8", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier9", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier10", DataType.String);
            dloSusikInfo.LayoutItems.Add("pre_modifier_name", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier1", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier2", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier3", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier4", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier5", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier6", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier7", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier8", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier9", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier10", DataType.String);
            dloSusikInfo.LayoutItems.Add("post_modifier_name", DataType.String);
            dloSusikInfo.InitializeLayoutTable();

            int insertRow = dloSusikInfo.InsertRow(-1);

            foreach (XEditGridCell cell in grdOutSang.CellInfos)
            {
                if (dloSusikInfo.LayoutItems.Contains(cell.CellName))
                    dloSusikInfo.SetItemValue(insertRow, cell.CellName,
                        grdOutSang.GetItemValue(currentRow, cell.CellName));
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("SANGINFO", dloSusikInfo);
            //서식지처방 조회 화면 Open
            XScreen.OpenScreenWithParam(this, "CHTS", "CHT0115Q00", ScreenOpenStyle.ResponseSizable, openParams);
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


        #endregion

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////////////		

        #region 상병데이타 Validation Check (ValidationCheckOutSang)

        /// <summary> 
        /// 처방저장시 상병데이타 Validation Check
        /// </summary>
        private bool ValidationCheckOutSang()
        {
            int seq = 1;

            #region [終了された傷病に必ず事由をいれる事をチェック]

            XEditGrid CurrGRD = this.grdOutSang;
            for (int i = 0; i < CurrGRD.RowCount; i++)
            {
                if (CurrGRD.GetItemString(i, "sang_end_date") != "" && CurrGRD.GetItemString(i, "sang_end_sayu") == "")
                {
                    XMessageBox.Show(Resources.ValidationCheckOutSang_MSG1, Resources.XMessageBox_Caption,
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CurrGRD.SetFocusToItem(i, "sang_end_sayu");
                    return false;
                }
            }

            #endregion

            for (int i = 0; i < grdOutSang.RowCount; i++)
            {
                if (grdOutSang.LayoutTable.Rows[i].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOutSang.GetItemString(i, "sang_name").Trim() == "")
                    {
                        grdOutSang.DeleteRow(i);
                        i = i - 1;
                        continue;
                    }
                }

                if (TypeCheck.IsNull(grdOutSang.GetItemString(i, "sang_name")))
                {
                    mbxMsg = Resources.ValidationCheckOutSang_MSG2;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                    grdOutSang.SetFocusToItem(i, "sang_name");
                    return false;
                }

                if (TypeCheck.IsNull(grdOutSang.GetItemString(i, "sang_start_date")))
                {
                    mbxMsg = Resources.ValidationCheckOutSang_MSG3;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Exclamation);
                    grdOutSang.SetFocusToItem(i, "sang_start_date");
                    return false;
                }

                seq = i + 1;

                //if(grdOutSang.GetItemString(i, "ser") != seq.ToString()) grdOutSang.SetItemValue(i, "ser", seq);	
            }


            return true;
        }

        #endregion

        #region Insert한 Row 중에 Not Null필드 미입력 Row Search (GetEmptyNewRow)

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
                grdChk = (XEditGrid) aGrd;
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

        #endregion

        #region [Grid Undo관련 ]

        #region XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option 해당 컬럼에서 포커스를 유지시킨다 (UndoPreviousValue)

        /// <summary> 
        /// XEditGrid에 값을 세팅하되 이전의 RowState를 유지하며, Option해당 컬럼에서 포커스를 유지시킨다
        /// </summary>
        /// <param name="aGrd"> XEditGrid </param>
        /// <param name="aRow"> int Row </param>
        /// <param name="aColName"> string 컬럼 </param>
        /// <param name="aPreviousValue"> object Setting할 Value </param>
        /// <param name="aIsProtecedFocus"> bool Optional 포커스이동막을지여부(Defalut : True) </param>
        /// <returns> void </returns>
        private void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue)
        {
            this.UndoPreviousValue(aGrd, aRow, aColName, aPreviousValue, true);
        }

        private void UndoPreviousValue(XEditGrid aGrd, int aRow, string aColName, object aPreviousValue,
            bool aIsProtecedFocus)
        {
            if (aGrd == null || aRow < 0 || aColName == "") return;

            // 이전 값으로 세팅한다
            // 값을 세팅하면 Row의 상태가 변화가 되므로, 해당 Row의 상태가 UnChanged인 경우는 변경후에 다시 UnChanged로 바꾸어 준다
            // 단, Added인 경우는 Detached 상태였으면, Detached로 바꾸어 줘야 하나, A___Grid는 InsertRow시 이미 Added상태이므로, 처리불가함
            DataRowState previousRowState = aGrd.GetRowState(aRow);

            if (previousRowState != DataRowState.Deleted)
                aGrd.SetItemValue(aRow, aColName, aPreviousValue); // 이전 데이타로 복귀

            // 이전 Row상태가 UnChanged인 경우 UnChanged로 Undo시킴
            if (previousRowState == DataRowState.Unchanged) aGrd.LayoutTable.Rows[aRow].AcceptChanges();

            if (aIsProtecedFocus) // 포커스이동막을지여부
            {
                Objects objects = new Objects(aGrd, aRow, aColName);
                PostCallHelper.PostCall(PostSetFocusToItem, ((object) objects));
                    // 현재 Column으로 Focus이동처리
            }
        }

        #region Objects Class(PostCall 메소드 사용용)

        // PostCall 메소드 사용시 Argument로 Object 하나만 넘길수 있다. 두개이상 Argument가 필요한 경우 아래의 구조체를 사용하자
        private class Objects
        {
            public object obj1;
            public object obj2;
            public object obj3;
            public object obj4;
            public object obj5;

            public Objects(object aObj1, object aObj2)
            {
                obj1 = aObj1;
                obj2 = aObj2;
                obj3 = null;
                obj4 = null;
                obj5 = null;
            }

            public Objects(object aObj1, object aObj2, object aObj3)
            {
                obj1 = aObj1;
                obj2 = aObj2;
                obj3 = aObj3;
                obj4 = null;
                obj5 = null;
            }

            public Objects(object aObj1, object aObj2, object aObj3, object aObj4)
            {
                obj1 = aObj1;
                obj2 = aObj2;
                obj3 = aObj3;
                obj4 = aObj4;
                obj5 = null;
            }

            public Objects(object aObj1, object aObj2, object aObj3, object aObj4, object aObj5)
            {
                obj1 = aObj1;
                obj2 = aObj2;
                obj3 = aObj3;
                obj4 = aObj4;
                obj5 = aObj5;
            }
        }

        #endregion

        private void PostSetFocusToItem(object aObjs)
        {
            try
            {
                Objects objects = (Objects) aObjs;
                ((XGrid) objects.obj1).Focus();
                ((XGrid) objects.obj1).SetFocusToItem(((int) objects.obj2), ((string) objects.obj3));
            }
            catch
            {
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// 상병입력가능여부
        /// </summary>
        /// <param name="aErrMsg">입력불가일경우의 사유</param>
        /// <returns>true, false</returns>
        private bool SangInputCheck(ref string aErrMsg)
        {
            // 상병 입력가능 여부 체크
            if (this.pbxSearch.BunHo == "")
            {
                aErrMsg = Resources.SangInputCheck_MSG; //진료대상환자를 선택해 주세요.
                return false;
            }

            return true;
        }


        private void InitializeSangGrid(XEditGrid aGrid, OCS.PatientInfo aPatientInfo, int aRow)
        {
            // 상병 그리드 new row 생성후 초기화
            // 초기화항목
            // bunho, gwa, io_gubun, naewon_date, jubsu_no, last_naewon_date, last_doctor, last_naewon_type, last_jubsu_no
            // fkinp1001, input_id, ju_sang_yn, sang_start_date

            string gwa = tvwGwa.SelectedNode.Tag.ToString();
            string gwa_name = this.tvwGwa.Nodes[this.tvwGwa.SelectedNode.Index].Text;

            if (gwa == "%")
            {
                gwa = UserInfo.Gwa;
                gwa_name = UserInfo.GwaName;
            }

            // IO_Gubun
            if (this.rbtIn.Checked == true)
                aGrid.SetItemValue(aRow, "io_gubun", "I");
            else if (this.rbtOut.Checked == true)
                aGrid.SetItemValue(aRow, "io_gubun", "O");

            // 患者番号
            aGrid.SetItemValue(aRow, "bunho", pbxSearch.BunHo);
            // 診療科
            aGrid.SetItemValue(aRow, "gwa", this.fbxToGwa.GetDataValue());
            // 診療科名
            aGrid.SetItemValue(aRow, "gwa_name", this.dbxToGwaName.Text);
            // Doctor 
            aGrid.SetItemValue(aRow, "doctor", this.fbxToDoctor.GetDataValue());
            // input_id (登録者 ＩＤ)
            aGrid.SetItemValue(aRow, "input_id", UserInfo.UserID);
            // ju_sang_yn ( 주상병)
            aGrid.SetItemValue(aRow, "ju_sang_yn", "N");
            // 상병 시작일 ( 새로 입력이므로 내원일자를 집어넣자...)
            aGrid.SetItemValue(aRow, "sang_start_date", this.dtpNaewon_Date.GetDataValue());
            //inser by jc [診断日基本SETTINGは来院日]
            aGrid.SetItemValue(aRow, "sang_jindan_date", this.dtpNaewon_Date.GetDataValue());

            //// naewon_date
            //aGrid.SetItemValue(aRow, "naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            //// jubsu_no
            //aGrid.SetItemValue(aRow, "jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            //// last_naewon_date
            //aGrid.SetItemValue(aRow, "last_naewon_date", aPatientInfo.GetPatientInfo["naewon_date"].ToString());
            //// last_doctor
            //aGrid.SetItemValue(aRow, "last_doctor", aPatientInfo.GetPatientInfo["doctor"].ToString());
            //// last_naewon_type 
            //aGrid.SetItemValue(aRow, "last_naewon_type", aPatientInfo.GetPatientInfo["naewon_type"].ToString()); ;
            //// jubsu_no
            //aGrid.SetItemValue(aRow, "last_jubsu_no", aPatientInfo.GetPatientInfo["jubsu_no"].ToString());
            //// 내원 혹은 입원 키
            //if (this.mIO_gubun == "O")
            //{
            //    aGrid.SetItemValue(aRow, "pkout1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            //}
            //else
            //{
            //    aGrid.SetItemValue(aRow, "fkinp1001", aPatientInfo.GetPatientInfo["naewon_key"].ToString());
            //}



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
                        this.btnList.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnList.PerformClick(FunctionType.Insert);
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
                        this.btnList.PerformClick(FunctionType.Insert);
                    }

                    if (aGrid.GetItemString(aGrid.CurrentRowNumber, "sang_code") != "")
                    {
                        this.btnList.PerformClick(FunctionType.Insert);
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

        #region XSavePerformer

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OUTSANGU00 parent = null;

            public XSavePerformer(OUTSANGU00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {

                //string chkDupi = "";
                //object retDupi = null;

                string cmdText = "";
                object t_chk = "";

                object reusltSang = "";
                string cmdTextsang = "";

                object val = null;

                //Grid에서 넘어온 Bind 변수에 q_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                item.BindVarList.Add("f_bunho", parent.pbxSearch.BunHo);

                switch (item.RowState)
                {
                    case DataRowState.Added:


                        cmdText = " SELECT MAX(Z.PK_SEQ)+1 PK_SEQ "
                                  + "   FROM OUTSANG Z"
                                  + "  WHERE Z.BUNHO       = '" + item.BindVarList["f_bunho"].VarValue + "' "
                                  + "    AND Z.GWA         = '" + item.BindVarList["f_gwa"].VarValue + "' "
                                  + "    AND Z.IO_GUBUN    = '" + item.BindVarList["f_io_gubun"].VarValue + "' "
                                  + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
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
                                  + "    AND Z.HOSP_CODE   = '" + EnvironInfo.HospCode + "' "
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
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue +
                                      @"'
                                                                         , '" +
                                      item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'I'
                                                                         , '" +
                                      item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                        reusltSang = Service.ExecuteScalar(cmdTextsang);
                        if (reusltSang.ToString() == "Y")
                        {
                            XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", Resources.XMessageBox_Caption);
                            return false;
                        }

                        #endregion

                        cmdText = @"INSERT INTO OUTSANG
                                           ( SYS_DATE           , SYS_ID               , BUNHO                , HOSP_CODE            ,
                                             GWA                , IO_GUBUN             , PK_SEQ               , NAEWON_DATE          ,
                                             DOCTOR             , NAEWON_TYPE          , JUBSU_NO             , LAST_NAEWON_DATE     ,
                                             LAST_DOCTOR        , LAST_NAEWON_TYPE     , LAST_JUBSU_NO        , FKINP1001            ,
                                             INPUT_ID           , SER                  , SANG_CODE            , JU_SANG_YN           ,
                                             SANG_NAME          , SANG_START_DATE      , SANG_END_DATE        , SANG_END_SAYU        ,
                                             PRE_MODIFIER1      , PRE_MODIFIER2        , PRE_MODIFIER3        , PRE_MODIFIER4        ,
                                             PRE_MODIFIER5      , PRE_MODIFIER6        , PRE_MODIFIER7        , PRE_MODIFIER8        ,
                                             PRE_MODIFIER9      , PRE_MODIFIER10       , PRE_MODIFIER_NAME    , POST_MODIFIER1       ,
                                             POST_MODIFIER2     , POST_MODIFIER3       , POST_MODIFIER4       , POST_MODIFIER5       ,
                                             POST_MODIFIER6     , POST_MODIFIER7       , POST_MODIFIER8       , POST_MODIFIER9       ,
                                             POST_MODIFIER10    , POST_MODIFIER_NAME   , SANG_JINDAN_DATE     , DATA_GUBUN)                                          
                                     VALUES
                                           ( SYSDATE            , :q_user_id           , :f_bunho             , :f_hosp_code         ,
                                             :f_gwa             , :f_io_gubun          , :f_pk_seq            , :f_naewon_date       ,
                                             :f_doctor          , :f_naewon_type       , :f_jubsu_no          , :f_naewon_date       ,
                                             :f_doctor          , :f_naewon_type       , :f_jubsu_no          , :f_fkinp1001         ,
                                             :q_user_id         , :f_ser               , :f_sang_code         , :f_ju_sang_yn        ,
                                             :f_sang_name       , :f_sang_start_date   , :f_sang_end_date     , :f_sang_end_sayu     ,
                                             :f_pre_modifier1   , :f_pre_modifier2     , :f_pre_modifier3     , :f_pre_modifier4     ,
                                             :f_pre_modifier5   , :f_pre_modifier6     , :f_pre_modifier7     , :f_pre_modifier8     ,
                                             :f_pre_modifier9   , :f_pre_modifier10    , :f_pre_modifier_name , :f_post_modifier1    ,
                                             :f_post_modifier2  , :f_post_modifier3    , :f_post_modifier4    , :f_post_modifier5    ,
                                             :f_post_modifier6  , :f_post_modifier7    , :f_post_modifier8    , :f_post_modifier9    ,
                                             :f_post_modifier10 , :f_post_modifier_name, :f_sang_jindan_date  , 'I')";
                        break;
                    case DataRowState.Modified:

                        #region [傷病重複チェック[重複あり：ＴＲＵＥ、重複なし：ＦＡＬＳＥ]] 2012/09/10

                        cmdTextsang = @"SELECT FN_OCS_SANG_DUP_CHK('" + item.BindVarList["f_hosp_code"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_io_gubun"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_gwa"].VarValue + @"'
                                                                         , '" + item.BindVarList["f_bunho"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_fkinp1001"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_sang_code"].VarValue +
                                      @"'
                                                                         , '" + item.BindVarList["f_sang_name"].VarValue +
                                      @"'
                                                                         , '" +
                                      item.BindVarList["f_post_modifier_name"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_pre_modifier_name"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_start_date"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_end_date"].VarValue + @"'
                                                                         , '" +
                                      item.BindVarList["f_sang_jindan_date"].VarValue + @"'
                                                                         , 'U'
                                                                         , '" +
                                      item.BindVarList["f_ju_sang_yn"].VarValue + @"') FROM SYS.DUAL";
                        reusltSang = Service.ExecuteScalar(cmdTextsang);
                        if (reusltSang.ToString() == "Y")
                        {
                            XMessageBox.Show("傷病が重複しています。もう一度確認してから登録してください。", Resources.XMessageBox_Caption);
                            return false;
                        }

                        #endregion

                        cmdText = @"UPDATE OUTSANG
                                       SET UPD_ID             = :q_user_id           ,
                                           UPD_DATE           = SYSDATE              ,
                                           SER                = :f_ser               ,
                                           SANG_NAME          = :f_sang_name         ,
                                           SANG_START_DATE    = :f_sang_start_date   ,
                                           SANG_END_DATE      = :f_sang_end_date     ,
                                           SANG_END_SAYU      = :f_sang_end_sayu     ,
                                           JU_SANG_YN         = :f_ju_sang_yn        ,
                                           PRE_MODIFIER1      = :f_pre_modifier1     ,
                                           PRE_MODIFIER2      = :f_pre_modifier2     ,
                                           PRE_MODIFIER3      = :f_pre_modifier3     ,
                                           PRE_MODIFIER4      = :f_pre_modifier4     ,
                                           PRE_MODIFIER5      = :f_pre_modifier5     ,
                                           PRE_MODIFIER6      = :f_pre_modifier6     ,
                                           PRE_MODIFIER7      = :f_pre_modifier7     ,
                                           PRE_MODIFIER8      = :f_pre_modifier8     ,
                                           PRE_MODIFIER9      = :f_pre_modifier9     ,
                                           PRE_MODIFIER10     = :f_pre_modifier10    ,
                                           PRE_MODIFIER_NAME  = :f_pre_modifier_name ,
                                           POST_MODIFIER1     = :f_post_modifier1    ,
                                           POST_MODIFIER2     = :f_post_modifier2    ,
                                           POST_MODIFIER3     = :f_post_modifier3    ,
                                           POST_MODIFIER4     = :f_post_modifier4    ,
                                           POST_MODIFIER5     = :f_post_modifier5    ,
                                           POST_MODIFIER6     = :f_post_modifier6    ,
                                           POST_MODIFIER7     = :f_post_modifier7    ,
                                           POST_MODIFIER8     = :f_post_modifier8    ,
                                           POST_MODIFIER9     = :f_post_modifier9    ,
                                           POST_MODIFIER10    = :f_post_modifier10   ,
                                           POST_MODIFIER_NAME = :f_post_modifier_name,
                                           SANG_JINDAN_DATE   = :f_sang_jindan_date  ,
                                           DATA_GUBUN         = 'U'
                                     WHERE BUNHO              = :f_bunho
                                       AND GWA                = :f_gwa
                                       AND IO_GUBUN           = :f_io_gubun
                                       AND PK_SEQ             = :f_pk_seq
                                       AND HOSP_CODE          = :f_hosp_code";
                        break;
                    case DataRowState.Deleted:

                        #region 削除するタイミングでif_data_send_ynを取得してチェックをする（画面上はまだ未更新の場合あるので）

                        cmdText = @"SELECT A.IF_DATA_SEND_YN
                                          FROM OUTSANG A
                                         WHERE A.HOSP_CODE = :f_hosp_code
                                           AND A.BUNHO     = :f_bunho
                                           AND A.GWA       = :f_gwa
                                           AND A.IO_GUBUN  = :f_io_gubun
                                           AND A.PK_SEQ    = :f_pk_seq";
                        val = Service.ExecuteScalar(cmdText, item.BindVarList);

                        item.BindVarList["f_if_data_send_yn"].VarValue = val.ToString();

                        #endregion

                        if (item.BindVarList["f_data_gubun"].VarValue == "I" &&
                            item.BindVarList["f_if_data_send_yn"].VarValue == "N")
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

                            cmdText = @"UPDATE OUTSANG
                                       SET UPD_ID             = :q_user_id           ,
                                           UPD_DATE           = SYSDATE              ,
                                           SER                = :f_ser               ,
                                           SANG_NAME          = :f_sang_name         ,
                                           SANG_START_DATE    = :f_sang_start_date   ,
                                           SANG_END_DATE      = :f_sang_end_date     ,
                                           SANG_END_SAYU      = :f_sang_end_sayu     ,
                                           JU_SANG_YN         = :f_ju_sang_yn        ,
                                           PRE_MODIFIER1      = :f_pre_modifier1     ,
                                           PRE_MODIFIER2      = :f_pre_modifier2     ,
                                           PRE_MODIFIER3      = :f_pre_modifier3     ,
                                           PRE_MODIFIER4      = :f_pre_modifier4     ,
                                           PRE_MODIFIER5      = :f_pre_modifier5     ,
                                           PRE_MODIFIER6      = :f_pre_modifier6     ,
                                           PRE_MODIFIER7      = :f_pre_modifier7     ,
                                           PRE_MODIFIER8      = :f_pre_modifier8     ,
                                           PRE_MODIFIER9      = :f_pre_modifier9     ,
                                           PRE_MODIFIER10     = :f_pre_modifier10    ,
                                           PRE_MODIFIER_NAME  = :f_pre_modifier_name ,
                                           POST_MODIFIER1     = :f_post_modifier1    ,
                                           POST_MODIFIER2     = :f_post_modifier2    ,
                                           POST_MODIFIER3     = :f_post_modifier3    ,
                                           POST_MODIFIER4     = :f_post_modifier4    ,
                                           POST_MODIFIER5     = :f_post_modifier5    ,
                                           POST_MODIFIER6     = :f_post_modifier6    ,
                                           POST_MODIFIER7     = :f_post_modifier7    ,
                                           POST_MODIFIER8     = :f_post_modifier8    ,
                                           POST_MODIFIER9     = :f_post_modifier9    ,
                                           POST_MODIFIER10    = :f_post_modifier10   ,
                                           POST_MODIFIER_NAME = :f_post_modifier_name,
                                           SANG_JINDAN_DATE   = :f_sang_jindan_date  ,
                                           DATA_GUBUN         = 'D'
                                     WHERE BUNHO              = :f_bunho
                                       AND GWA                = :f_gwa
                                       AND IO_GUBUN           = :f_io_gubun
                                       AND PK_SEQ             = :f_pk_seq
                                       AND HOSP_CODE          = :f_hosp_code";
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void OUTSANGU00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {

        }

        private void btnOutInpCopy_Click(object sender, EventArgs e)
        {
            string toIO_GUBUN = "";
            MultiLayout layOUTSANG = new MultiLayout();
            int currRow = -1;

            bool isSelectedRow = false;

            for (int i = 0; i < this.grdOutSang.DisplayRowCount; i++)
            {
                if (this.grdOutSang.IsSelectedRow(i) == true)
                {
                    isSelectedRow = true;
                    break;
                }
            }
            if (!isSelectedRow)
            {
                XMessageBox.Show(Resources.btnOutInpCopy_Click_MSG, Resources.XMessageBox_Caption);

                this.timIcon.Start();
                this.pbxUnderArrow.Visible = true;
                return;
            }

            foreach (XGridCell cell in this.grdOutSang.CellInfos)
                layOUTSANG.LayoutItems.Add(cell.CellName, (DataType) cell.CellType);

            layOUTSANG.InitializeLayoutTable();

            if (this.rbtOut.Checked == true)
            {
                toIO_GUBUN = "I";
                for (int i = 0; i < this.grdOutSang.RowCount; i++)
                {
                    if (this.grdOutSang.IsSelectedRow(i))
                    {
                        layOUTSANG.LayoutTable.ImportRow(this.grdOutSang.LayoutTable.Rows[i]);
                    }
                }

                this.rbtIn.PerformClick();

                for (int i = 0; i < layOUTSANG.RowCount; i++)
                {
                    layOUTSANG.SetItemValue(i, "io_gubun", toIO_GUBUN);
                    layOUTSANG.SetItemValue(i, "gwa", this.fbxToGwa.GetDataValue());
                    layOUTSANG.SetItemValue(i, "gwa_name", this.dbxToGwaName.Text);
                    layOUTSANG.SetItemValue(i, "doctor", this.fbxToDoctor.GetDataValue());

                    currRow = this.grdOutSang.InsertRow(-1);


                    foreach (XEditGridCell cell in grdOutSang.CellInfos)
                    {
                        if (layOUTSANG.LayoutItems.Contains(cell.CellName))
                            grdOutSang.SetItemValue(currRow, cell.CellName, layOUTSANG.GetItemValue(i, cell.CellName));
                    }
                }
            }
            else
            {
                toIO_GUBUN = "O";
                for (int i = 0; i < this.grdOutSang.RowCount; i++)
                {
                    if (this.grdOutSang.IsSelectedRow(i))
                    {
                        layOUTSANG.LayoutTable.ImportRow(this.grdOutSang.LayoutTable.Rows[i]);
                    }
                }

                this.rbtOut.PerformClick();

                for (int i = 0; i < layOUTSANG.RowCount; i++)
                {
                    layOUTSANG.SetItemValue(i, "io_gubun", toIO_GUBUN);
                    currRow = this.grdOutSang.InsertRow(-1);


                    foreach (XEditGridCell cell in grdOutSang.CellInfos)
                    {
                        if (layOUTSANG.LayoutItems.Contains(cell.CellName))
                            grdOutSang.SetItemValue(currRow, cell.CellName, layOUTSANG.GetItemValue(i, cell.CellName));
                    }
                }
            }
        }

        #region XFindBox

        private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            switch (control.Name)
            {
                case "fbxToGwa":

                    #region 변경후 진료과

                    // TODO comment: Use connect cloud service
//                    this.fwkCommon.InputSQL = @"SELECT A.GWA
//                                                     , A.GWA_NAME
//                                                     , A.BUSEO_CODE
//                                                  FROM BAS0260 A
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND A.BUSEO_GUBUN = '1'
//                                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
//                                                                          FROM BAS0260 B
//                                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
//                                                                           AND B.GWA         = A.GWA
//                                                                           AND B.START_DATE <= :f_start_date)
//                                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
//                                                   AND(A.GWA       LIKE '%' || :f_find1 || '%'
//                                                    OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
//                                                 ORDER BY A.GWA";

                    this.fwkCommon.SetBindVarValue("f_start_date", this.dtpNaewon_Date.GetDataValue());
                    this.fwkCommon.SetBindVarValue("f_hosp_code", mHospCode);

                    // Connect to cloud
                    this.fwkCommon.ExecuteQuery = fwkCommon_GetGwaInfo;
                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", Resources.fbxToGwa_Title_Code, FindColType.String, 80, 0, true,
                        FilterType.Yes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.fbxToGwa_Title_Name, FindColType.String, 200, 0,
                        true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;

                case "fbxToDoctor":

                    #region 변경후 진료의

                    // TODO comment: Use connect cloud service
//                    this.fwkCommon.InputSQL = @"SELECT A.DOCTOR
//                                                     , A.DOCTOR_NAME
//                                                     , A.SORT_KEY || A.DOCTOR            CONT_KEY
//                                                  FROM BAS0270 A
//                                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                                   AND DECODE(:f_gwa, '%', '%', A.DOCTOR_GWA)   = :f_gwa
//                                                   AND  (A.DOCTOR       LIKE '%' || :f_find1 || '%'
//                                                           OR A.DOCTOR_NAME  LIKE '%' || :f_find1 || '%')
//                                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
//                                                                          FROM BAS0270 B
//                                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
//                                                                           AND B.DOCTOR      = A.DOCTOR
//                                                                           AND B.START_DATE <= :f_doctor_ymd)
//                                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_doctor_ymd                                                   
//                                                 ORDER BY CONT_KEY";

                    if (fbxToGwa.GetDataValue() != "")
                        this.fwkCommon.SetBindVarValue("f_gwa", fbxToGwa.GetDataValue());
                    else
                        this.fwkCommon.SetBindVarValue("f_gwa", "%");
                    this.fwkCommon.SetBindVarValue("f_doctor_ymd", this.dtpNaewon_Date.GetDataValue());
                    this.fwkCommon.SetBindVarValue("f_hosp_code", mHospCode);

                    // Connect to cloud
                    this.fwkCommon.ExecuteQuery = fwkCommon_GetDoctorInfo;
                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("code", "ID", FindColType.String, 80, 0, true, FilterType.Yes);
                    this.fwkCommon.ColInfos.Add("code_name", Resources.FindBox_FindClick_Title, FindColType.String, 200,
                        0, true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;
            }
        }

        private void FindBox_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            XFindBox control = sender as XFindBox;

            // TODO Comment: Use connect cloud
//            object name = null;
//            string cmdText = "";
//            BindVarCollection bindVars = new BindVarCollection();

            switch (control.Name)
            {
                case "fbxToGwa":

                    if (e.DataValue == "")
                    {
                        this.dbxToGwaName.SetDataValue("");
                        this.fbxToDoctor.SetEditValue("");
                        this.fbxToDoctor.AcceptData();

                        this.SetMsg("");

                        return;
                    }

                    // TODO Comment: Use connect cloud
//                    cmdText = @"SELECT A.GWA_NAME
//                                  FROM BAS0260 A
//                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                   AND A.BUSEO_GUBUN = '1'
//                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
//                                                          FROM BAS0260 B
//                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
//                                                           AND B.GWA         = A.GWA
//                                                           AND B.START_DATE <= :f_start_date)
//                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
//                                   AND(A.GWA       LIKE '%' || :f_find1 || '%'
//                                    OR A.GWA_NAME  LIKE '%' || :f_find1 || '%')
//                                 ORDER BY A.GWA";
//                    bindVars.Add("f_start_date", dtpNaewon_Date.GetDataValue());
//                    bindVars.Add("f_find1", e.DataValue);
//                    bindVars.Add("f_hosp_code", mHospCode);
//
//                    name = Service.ExecuteScalar(cmdText, bindVars);

                    // [Start] connect to cloud service: get gwa name
                    OUTSANGU00GetGwaNameArgs vOUTSANGU00GetGwaNameArgs = new OUTSANGU00GetGwaNameArgs();
                    vOUTSANGU00GetGwaNameArgs.StartDate = dtpNaewon_Date.GetDataValue();
                    vOUTSANGU00GetGwaNameArgs.Find1 = e.DataValue;
                    OUTSANGU00GetGwaNameResult gwaNameResult =
                        CloudService.Instance.Submit<OUTSANGU00GetGwaNameResult, OUTSANGU00GetGwaNameArgs>(
                            vOUTSANGU00GetGwaNameArgs);

                    if (gwaNameResult == null || TypeCheck.IsNull(gwaNameResult.GwaName))
                    {
                        this.mMsg = Resources.FindBox_DataValidating_MSG;

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }

                    this.dbxToGwaName.SetDataValue(gwaNameResult.GwaName);

                    this.fbxToDoctor.SetEditValue("");
                    this.fbxToDoctor.AcceptData();

                    this.SetMsg("");

                    // [End] connect cloud

                    break;

                case "fbxToDoctor":

                    if (e.DataValue == "")
                    {
                        this.dbxToDoctorName.SetDataValue("");

                        this.SetMsg("");

                        return;
                    }
                    // TODO Comment: Use connect cloud

//                    cmdText = @"SELECT A.DOCTOR_NAME
//                                  FROM BAS0270 A
//                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                   AND A.DOCTOR_GWA = :f_gwa
//                                   AND A.DOCTOR     = :f_find1  
//                                   AND A.START_DATE = ( SELECT MAX(B.START_DATE)
//                                                          FROM BAS0270 B
//                                                         WHERE B.HOSP_CODE   = A.HOSP_CODE
//                                                           AND B.DOCTOR      = A.DOCTOR
//                                                           AND B.START_DATE <= :f_start_date)
//                                   AND NVL(A.END_DATE, TO_DATE('9998/12/31', 'YYYY/MM/DD')) > :f_start_date
//                                 ORDER BY SORT_KEY";
//                    bindVars.Add("f_gwa", fbxToGwa.GetDataValue());
//                    bindVars.Add("f_find1", e.DataValue);
//                    bindVars.Add("f_start_date", dtpNaewon_Date.GetDataValue());
//                    bindVars.Add("f_hosp_code", mHospCode);
//
//                    name = Service.ExecuteScalar(cmdText, bindVars);

                    // Connect to cloud
                    OUTSANGU00GetDoctorNameArgs vOUTSANGU00GetDoctorNameArgs = new OUTSANGU00GetDoctorNameArgs();
                    vOUTSANGU00GetDoctorNameArgs.Gwa = fbxToGwa.GetDataValue();
                    vOUTSANGU00GetDoctorNameArgs.Find1 = e.DataValue;
                    vOUTSANGU00GetDoctorNameArgs.StartDate = dtpNaewon_Date.GetDataValue();
                    OUTSANGU00GetDoctorNameResult doctorNameResult =
                        CloudService.Instance.Submit<OUTSANGU00GetDoctorNameResult, OUTSANGU00GetDoctorNameArgs>(
                            vOUTSANGU00GetDoctorNameArgs);

                    if (doctorNameResult == null || TypeCheck.IsNull(doctorNameResult.DoctorName))
                    {
                        this.mMsg = Resources.OUTSANGU00_FindBox_DataValidating_MSG;

                        this.SetMsg(this.mMsg, MsgType.Error);

                        e.Cancel = true;

                        return;
                    }

                    this.dbxToDoctorName.SetDataValue(doctorNameResult.DoctorName);

                    this.SetMsg("");
                    // End connect to cloud
                    break;
            }
        }

        #endregion

        private void grdOutSang_QueryStarting(object sender, CancelEventArgs e)
        {

        }

        private void timIcon_Tick(object sender, EventArgs e)
        {
            this.pbxUnderArrow.Visible = false;
            this.timIcon.Stop();
        }

        #region GridOutSang get data from cloud service 

        /// <summary>
        /// grdOutSang ExecuteQuery
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> grdOutSang_ExecuteQuery(BindVarCollection bc)
        {
            permission_list = new List<string>();
            IList<object[]> res = new List<object[]>();
            OUTSANGU00InitializeArgs vOUTSANGU00InitializeArgs = new OUTSANGU00InitializeArgs();
            vOUTSANGU00InitializeArgs.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            vOUTSANGU00InitializeArgs.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            vOUTSANGU00InitializeArgs.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            vOUTSANGU00InitializeArgs.AllSangYn = bc["f_all_sang_yn"] != null ? bc["f_all_sang_yn"].VarValue : "";
            vOUTSANGU00InitializeArgs.GijunDate = bc["f_gijun_date"] != null ? bc["f_gijun_date"].VarValue : "";
            OUTSANGU00InitializeResult result =
                CloudService.Instance.Submit<OUTSANGU00InitializeResult, OUTSANGU00InitializeArgs>(
                    vOUTSANGU00InitializeArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                
                foreach (OUTSANGU00InitializeListItemInfo item in result.InitInfo)
                {
                    object[] objects =
                    {
                        item.Bunho,
                        item.Gwa,
                        item.GwaName,
                        item.IoGubun,
                        item.PkSeq,
                        item.NaewonDate,
                        item.Doctor,
                        item.NaewonType,
                        item.JubsuNo,
                        item.Fkinp1001,
                        item.InputId,
                        item.SangCode,
                        item.SangName,
                        item.DisSangName,
                        item.JuSangYn,
                        item.SangStartDate,
                        item.SangEndDate,
                        item.SangEndSayu,
                        item.SangEndSayuName,
                        item.Ser,
                        item.PreModifier1,
                        item.PreModifier2,
                        item.PreModifier3,
                        item.PreModifier4,
                        item.PreModifier5,
                        item.PreModifier6,
                        item.PreModifier7,
                        item.PreModifier8,
                        item.PreModifier9,
                        item.PreModifier10,
                        item.PreModifierName,
                        item.PostModifier1,
                        item.PostModifier2,
                        item.PostModifier3,
                        item.PostModifier4,
                        item.PostModifier5,
                        item.PostModifier6,
                        item.PostModifier7,
                        item.PostModifier8,
                        item.PostModifier9,
                        item.PostModifier10,
                        item.PostModifierName,
                        item.SangJindanDate,
                        item.DataGubun,
                        item.IfDataSendYn,
                        item.ContKey,
                        item.EmrPermission
                    };                  
                    res.Add(objects);
                    permission_list.Add(item.EmrPermission);                 
                }
            }
            return res;
        }

        #endregion

        #region fdwCommon_ExecuteQuery

        /// <summary>
        /// fdwCommon_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> fdwCommon_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObj = new List<object[]>();
            ComboSangEndSayuArgs comboSangEndSayuArgs = new ComboSangEndSayuArgs();
            ComboResult comboResult = CacheService.Instance.Get<ComboSangEndSayuArgs, ComboResult>(comboSangEndSayuArgs);

            //ComboResult comboResult = CloudService.Instance.Submit<ComboResult, ComboSangEndSayuArgs>(comboSangEndSayuArgs);

            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstItemInfo = comboResult.ComboItem;
                if (lstItemInfo != null && lstItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstItemInfo)
                    {
                        listObj.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return listObj;
        }

        #endregion layoutGwa get data from cloud service

        #region layoutGwa_ExecuteQuery

        /// <summary>
        /// layoutGwa_ExecuteQuery
        /// </summary>
        /// <param name="varCollection"></param>
        /// <returns></returns>
        private IList<object[]> layoutGwa_ExecuteQuery(BindVarCollection varCollection)
        {
            IList<object[]> listObj = new List<object[]>();
            OUTSANGU00createGwaDataArgs args = new OUTSANGU00createGwaDataArgs();
            args.OutJubsuYn = "Y";
            ComboResult comboResult = CloudService.Instance.Submit<ComboResult, OUTSANGU00createGwaDataArgs>(args);
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> lstItemInfo = comboResult.ComboItem;
                if (lstItemInfo != null && lstItemInfo.Count > 0)
                {
                    foreach (ComboListItemInfo info in lstItemInfo)
                    {
                        listObj.Add(new object[]
                        {
                            info.Code,
                            info.CodeName
                        });
                    }
                }
            }
            return listObj;
        }

        #endregion

        #region fwkCommon_GetGwaInfo

        /// <summary>
        /// Get gwa info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> fwkCommon_GetGwaInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OUTSANGU00findBoxToGwaArgs vOUTSANGU00findBoxToGwaArgs = new OUTSANGU00findBoxToGwaArgs();
            vOUTSANGU00findBoxToGwaArgs.StartDate = bc["f_start_date"] != null ? bc["f_start_date"].VarValue : "";
            vOUTSANGU00findBoxToGwaArgs.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            OUTSANGU00findBoxToGwaResult result =
                CloudService.Instance.Submit<OUTSANGU00findBoxToGwaResult, OUTSANGU00findBoxToGwaArgs>(
                    vOUTSANGU00findBoxToGwaArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUTSANGU00findBoxToGwaInfo item in result.GwaInfo)
                {
                    object[] objects =
                    {
                        item.Gwa,
                        item.GwaName,
                        item.BuseoCode
                    };
                    res.Add(objects);
                }
            }
            return res;

        }

        #endregion

        #region fwkCommon_GetDoctorInfo

        /// <summary>
        /// Get doctor info
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private IList<object[]> fwkCommon_GetDoctorInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (TypeCheck.IsNull(bc["f_gwa"].VarValue))
            {
                return res;
            }
            OUTSANGU00findBoxToDoctorArgs vOUTSANGU00findBoxToDoctorArgs = new OUTSANGU00findBoxToDoctorArgs();
            vOUTSANGU00findBoxToDoctorArgs.Gwa = bc["f_gwa"] != null ? bc["f_gwa"].VarValue : "";
            vOUTSANGU00findBoxToDoctorArgs.Find1 = bc["f_find1"] != null ? bc["f_find1"].VarValue : "";
            vOUTSANGU00findBoxToDoctorArgs.DoctorYmd = bc["f_doctor_ymd"] != null ? bc["f_doctor_ymd"].VarValue : "";
            
            OUTSANGU00findBoxToDoctorResult result =
                CloudService.Instance.Submit<OUTSANGU00findBoxToDoctorResult, OUTSANGU00findBoxToDoctorArgs>(
                    vOUTSANGU00findBoxToDoctorArgs);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (OUTSANGU00findBoxToDoctorInfo item in result.DoctorInfo)
                {
                    object[] objects =
                    {
                        item.Doctor,
                        item.DoctorName,
                        item.ContKey
                    };
                    res.Add(objects);
                }
            }
            return res;

        }
        
        #endregion
        /// <summary>
        /// Create list GridOutSang info
        /// </summary>
        /// <returns></returns>
        private List<OUTSANGU00InitializeListItemInfo> CreateListGridOutSangInfo()
        {
           
            List<OUTSANGU00InitializeListItemInfo> lstGridOutSang = new List<OUTSANGU00InitializeListItemInfo>();
            for (int i = 0; i < grdOutSang.RowCount; i++)
            {
                string list_permission = grdOutSang.GetItemString(i, "emr_permission").ToString();
                //bool doctor = list_permission.Contains("D");
                //bool other = list_permission.Contains("O");
                //bool related = list_permission.Contains("R");
                //bool patient = list_permission.Contains("P");
                bool doctor = list_permission.Contains(Resources.PERMISION_DOCTOR);
                bool other = list_permission.Contains(Resources.PERMISION_OTHERCLINIC);
                bool related = list_permission.Contains(Resources.PERMISION_RELATED);
                bool patient = list_permission.Contains(Resources.PERMISION_PATIENT);
                if (grdOutSang.GetRowState(i).Equals(DataRowState.Added) || grdOutSang.GetRowState(i).Equals(DataRowState.Modified))
                {
                    OUTSANGU00InitializeListItemInfo itemInfo = new OUTSANGU00InitializeListItemInfo();
                    itemInfo.Bunho = grdOutSang.GetItemString(i, "bunho");
                    itemInfo.Gwa = grdOutSang.GetItemString(i, "gwa");
                    itemInfo.GwaName = grdOutSang.GetItemString(i, "gwa_name");
                    itemInfo.IoGubun = grdOutSang.GetItemString(i, "io_gubun");
                    itemInfo.PkSeq = grdOutSang.GetItemString(i, "pk_seq");
                    itemInfo.NaewonDate = grdOutSang.GetItemString(i, "naewon_date");
                    itemInfo.Doctor = grdOutSang.GetItemString(i, "doctor");
                    itemInfo.NaewonType = grdOutSang.GetItemString(i, "naewon_type");
                    itemInfo.JubsuNo = grdOutSang.GetItemString(i, "jubsu_no");
                    itemInfo.Fkinp1001 = grdOutSang.GetItemString(i, "fkinp1001");
                    itemInfo.InputId = grdOutSang.GetItemString(i, "input_id");
                    itemInfo.SangCode = grdOutSang.GetItemString(i, "sang_code");
                    itemInfo.SangName = grdOutSang.GetItemString(i, "sang_name");
                    itemInfo.JuSangYn = grdOutSang.GetItemString(i, "ju_sang_yn");
                    itemInfo.SangStartDate = grdOutSang.GetItemString(i, "sang_start_date");
                    itemInfo.SangEndDate = grdOutSang.GetItemString(i, "sang_end_date");
                    itemInfo.SangEndSayu = grdOutSang.GetItemString(i, "sang_end_sayu");
                    itemInfo.SangEndSayuName = grdOutSang.GetItemString(i, "sang_end_sayu_name");
                    itemInfo.Ser = grdOutSang.GetItemString(i, "ser");
                    itemInfo.PreModifier1 = grdOutSang.GetItemString(i, "pre_modifier1");
                    itemInfo.PreModifier2 = grdOutSang.GetItemString(i, "pre_modifier2");
                    itemInfo.PreModifier3 = grdOutSang.GetItemString(i, "pre_modifier3");
                    itemInfo.PreModifier4 = grdOutSang.GetItemString(i, "pre_modifier4");
                    itemInfo.PreModifier5 = grdOutSang.GetItemString(i, "pre_modifier5");
                    itemInfo.PreModifier6 = grdOutSang.GetItemString(i, "pre_modifier6");
                    itemInfo.PreModifier7 = grdOutSang.GetItemString(i, "pre_modifier7");
                    itemInfo.PreModifier8 = grdOutSang.GetItemString(i, "pre_modifier8");
                    itemInfo.PreModifier9 = grdOutSang.GetItemString(i, "pre_modifier9");
                    itemInfo.PreModifier10 = grdOutSang.GetItemString(i, "pre_modifier10");
                    itemInfo.PreModifierName = grdOutSang.GetItemString(i, "pre_modifier_name");
                    itemInfo.PostModifier1 = grdOutSang.GetItemString(i, "post_modifier1");
                    itemInfo.PostModifier2 = grdOutSang.GetItemString(i, "post_modifier2");
                    itemInfo.PostModifier3 = grdOutSang.GetItemString(i, "post_modifier3");
                    itemInfo.PostModifier4 = grdOutSang.GetItemString(i, "post_modifier4");
                    itemInfo.PostModifier5 = grdOutSang.GetItemString(i, "post_modifier5");
                    itemInfo.PostModifier6 = grdOutSang.GetItemString(i, "post_modifier6");
                    itemInfo.PostModifier7 = grdOutSang.GetItemString(i, "post_modifier7");
                    itemInfo.PostModifier8 = grdOutSang.GetItemString(i, "post_modifier8");
                    itemInfo.PostModifier9 = grdOutSang.GetItemString(i, "post_modifier9");
                    itemInfo.PostModifier10 = grdOutSang.GetItemString(i, "post_modifier10");
                    itemInfo.PostModifierName = grdOutSang.GetItemString(i, "post_modifier_name");
                    itemInfo.SangJindanDate = grdOutSang.GetItemString(i, "sang_jindan_date");
                    itemInfo.IfDataSendYn = grdOutSang.GetItemString(i, "if_data_send_yn");
                    //itemInfo.EmrPermission = grdOutSang.GetItemString(i, "emr_permission");
                    itemInfo.EmrPermission = ParseStringEmrPermission(doctor, other, related, patient);
                    itemInfo.DataRowState = grdOutSang.GetRowState(i).ToString();
                    if (grdOutSang.GetRowState(i).Equals(DataRowState.Added))
                    {
                        itemInfo.DataGubun = "I";
                    }
                    if (grdOutSang.GetRowState(i).Equals(DataRowState.Modified))
                    {
                        itemInfo.DataGubun = "U";
                    }
                    lstGridOutSang.Add(itemInfo);
                }
                
            }
            if (grdOutSang.DeletedRowTable != null && grdOutSang.DeletedRowTable.Rows.Count > 0)
            {
                foreach (DataRow row in grdOutSang.DeletedRowTable.Rows)
                {
                    OUTSANGU00InitializeListItemInfo itemInfo = new OUTSANGU00InitializeListItemInfo();
                    itemInfo.Bunho = row["bunho"].ToString();
                    itemInfo.Gwa = row["gwa"].ToString();
                    itemInfo.GwaName = row["gwa_name"].ToString();
                    itemInfo.IoGubun = row["io_gubun"].ToString();
                    itemInfo.PkSeq = row["pk_seq"].ToString();
                    itemInfo.NaewonDate = row["naewon_date"].ToString();
                    itemInfo.Doctor = row["doctor"].ToString();
                    itemInfo.NaewonType = row["naewon_type"].ToString();
                    itemInfo.JubsuNo = row["jubsu_no"].ToString();
                    itemInfo.Fkinp1001 = row["fkinp1001"].ToString();
                    itemInfo.InputId = row["input_id"].ToString();
                    itemInfo.SangCode = row["sang_code"].ToString();
                    itemInfo.SangName = row["sang_name"].ToString();
                    itemInfo.JuSangYn = row["ju_sang_yn"].ToString();
                    itemInfo.SangStartDate = row["sang_start_date"].ToString();
                    itemInfo.SangEndDate = row["sang_end_date"].ToString();
                    itemInfo.SangEndSayu = row["sang_end_sayu"].ToString();
                    itemInfo.SangEndSayuName = row["sang_end_sayu_name"].ToString();
                    itemInfo.Ser = row["ser"].ToString();
                    itemInfo.PreModifier1 = row["pre_modifier1"].ToString();
                    itemInfo.PreModifier2 = row["pre_modifier2"].ToString();
                    itemInfo.PreModifier3 = row["pre_modifier3"].ToString();
                    itemInfo.PreModifier4 = row["pre_modifier4"].ToString();
                    itemInfo.PreModifier5 = row["pre_modifier5"].ToString();
                    itemInfo.PreModifier6 = row["pre_modifier6"].ToString();
                    itemInfo.PreModifier7 = row["pre_modifier7"].ToString();
                    itemInfo.PreModifier8 = row["pre_modifier8"].ToString();
                    itemInfo.PreModifier9 = row["pre_modifier9"].ToString();
                    itemInfo.PreModifier10 = row["pre_modifier10"].ToString();
                    itemInfo.PreModifierName = row["pre_modifier_name"].ToString();
                    itemInfo.PostModifier1 = row["post_modifier1"].ToString();
                    itemInfo.PostModifier2 = row["post_modifier2"].ToString();
                    itemInfo.PostModifier3 = row["post_modifier3"].ToString();
                    itemInfo.PostModifier4 = row["post_modifier4"].ToString();
                    itemInfo.PostModifier5 = row["post_modifier5"].ToString();
                    itemInfo.PostModifier6 = row["post_modifier6"].ToString();
                    itemInfo.PostModifier7 = row["post_modifier7"].ToString();
                    itemInfo.PostModifier8 = row["post_modifier8"].ToString();
                    itemInfo.PostModifier9 = row["post_modifier9"].ToString();
                    itemInfo.PostModifier10 = row["post_modifier10"].ToString();
                    itemInfo.PostModifierName = row["post_modifier_name"].ToString();
                    itemInfo.SangJindanDate = row["sang_jindan_date"].ToString();
                    itemInfo.IfDataSendYn = row["if_data_send_yn"].ToString();
                    itemInfo.DataGubun = "D";
                    itemInfo.DataRowState = DataRowState.Deleted.ToString();

                    lstGridOutSang.Add(itemInfo);
                }
            }
            return lstGridOutSang;
        }

        private string ParseStringEmrPermission(bool doctor, bool other, bool related, bool patient)
        {
            int result = 0;
            if (doctor == true) result += 8;
            if (other == true) result += 4;
            if (related == true) result += 2;
            if (patient == true) result += 1;

            return result.ToString();
        }

        private void grdOutSang_Click(object sender, EventArgs e)
        {

        }
        private bool BitFlag(int value, int bitNo)
        {
            return (value >> (bitNo - 1)) % 2 == 1;
        }
        private string ConvertBinaryToStrPermission(int value)
        {
            string strPermission = "";
            if (BitFlag(value, 4))
            {
               // strPermission = "D";
                strPermission = Resources.PERMISION_DOCTOR;
            }

            if (BitFlag(value, 3))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    //strPermission = "O";
                    strPermission = Resources.PERMISION_OTHERCLINIC;
                }
                else
                {
                    //strPermission = strPermission + ", " + "O";
                    strPermission = strPermission + ", " + Resources.PERMISION_OTHERCLINIC;
                }
            }

            if (BitFlag(value, 2))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    //strPermission = "R";
                    strPermission = Resources.PERMISION_RELATED;
                }
                else
                {
                    //strPermission = strPermission + ", " + "R";
                    strPermission = strPermission + ", " + Resources.PERMISION_RELATED;
                }
            }

            if (BitFlag(value, 1))
            {
                if (string.IsNullOrEmpty(strPermission))
                {
                    //strPermission = "P";
                    strPermission = Resources.PERMISION_PATIENT;
                }
                else
                {
                    //strPermission = strPermission + ", " + "P";
                    strPermission = strPermission + ", " + Resources.PERMISION_PATIENT;
                }
            }
            return strPermission.Trim();
        }
    }
}

