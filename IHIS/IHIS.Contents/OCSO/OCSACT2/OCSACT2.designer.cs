using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using System.Windows.Forms;
using System.ComponentModel;

namespace IHIS.OCSO
{
    public partial class OCSACT2
    {
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

        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private XPanel xPanel2;
        private XPanel xPanel6;
        private XRadioButton rbxInp;
        private XRadioButton rbxOut;
        private XRadioButton rbxIOAll;
        private XPanel xPanel8;
        private XPanel xPanel7;
        private XRadioButton rbxNonAct;
        private XRadioButton rbxAct;
        private XRadioButton rbxActAll;
        private XLabel lbPart;
        private XDictComboBox cboSystem;
        private XDictComboBox cboPart;
        private XLabel xLabel1;
        private XDatePicker dtpToDate;
        private Label label1;
        private XDatePicker dtpFromDate;
        private XLabel xLabel2;
        private XPatientBox paBox;
        private XEditGrid grdPaList;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private ToolTip toolTip;
        private XRadioButton rbxTodayOut;
        private XLabel xLabel8;
        private XLabel xLabel9;
        private XLabel xLabel10;
        private XLabel xLabel11;
        private XTabControl tabControl;
        private IHIS.X.Magic.Controls.TabPage tabPaInfo;
        private IHIS.X.Magic.Controls.TabPage tabSangByung;
        private IHIS.X.Magic.Controls.TabPage tabOrdRemark;
        private XDisplayBox dbxActLastDate;
        private XDisplayBox dbxInOutGubunName;
        private XDisplayBox dbxBirth;
        private XLabel xLabel6;
        private XLabel xLabel4;
        private XDisplayBox dbxBunho;
        private XDisplayBox dbxSuname2;
        private XDisplayBox dbxSuname;
        private XDisplayBox dbxHodongHocode;
        private XDisplayBox dbxHeightWeight;
        private XLabel xLabel7;
        private XPaInfoBox xPaInfoBox1;
        private XDisplayBox dbxDoctorName;
        private XLabel xLabel13;
        private XDisplayBox dbxPaceMaker;
        private XLabel lbPaceMaker;
        private XDisplayBox dbxSexAge;
        private XLabel xLabel5;
        private XDisplayBox dbxGwaName;
        private XLabel xLabel14;
        private XDisplayBox dbxUnusualInfo;
        private XLabel xLabel15;
        private Splitter splitter2;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XButton btnJaeryo;
        private XButton btnReSendIF;
        private XButton btnRequest;
        private XButton btnReserViewer;
        private Label lbSuname;
        private XEditGridCell xEditGridCell53;
        private XRichTextBox txtOrderRemark;
        private XButton btnPacsViewer;
        private XButton btnReportViewer;
        private XButton btnEMR;
        private XPaComment paComment;
        private IHIS.X.Magic.Controls.TabPage tabPaComment;
        private XGrid grdSangByung;
        private XGridCell xGridCell1;
        private MultiLayout defaultJearyo;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell86;
        private XFindWorker fwkActor;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private MultiLayout layPacsInfo;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private XDictComboBox cboTime;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XLabel xLabel12;
        private XLabel lbTime;
        private Timer timer1;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayout mlayPart;
        private MultiLayoutItem multiLayoutItem10;
        private XButton btnExpand;
        private XButton btnIfEkg;
        private XCheckBox cbxEkgIFYN;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell93;
        private XPanel xPanel11;
        private XPanel xPanel13;
        private XPanel xPanel12;
        private XPanel xPanel15;
        private XRadioButton rbxPFE;
        private XRadioButton rbxTST;
        private XRadioButton rbxCPL;
        private XRadioButton rbxINJ;
        private XButton btnUseAlarmChk;
        private XButton btnUseTimeChk;
        private IContainer components;
        private GroupExpandForm groupExpandForm;

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCSACT2));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel15 = new IHIS.Framework.XPanel();
            this.rbxPFE = new IHIS.Framework.XRadioButton();
            this.rbxTST = new IHIS.Framework.XRadioButton();
            this.rbxCPL = new IHIS.Framework.XRadioButton();
            this.rbxINJ = new IHIS.Framework.XRadioButton();
            this.xPanel11 = new IHIS.Framework.XPanel();
            this.xPanel14 = new IHIS.Framework.XPanel();
            this.btnChange = new IHIS.Framework.XButton();
            this.dbxDocName = new IHIS.Framework.XDisplayBox();
            this.dbxDocCode = new IHIS.Framework.XDisplayBox();
            this.btnViewEMR = new IHIS.Framework.XButton();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xPanel13 = new IHIS.Framework.XPanel();
            this.patientInfoBox = new IHIS.OCSO.PatientInfoBox();
            this.xPanel12 = new IHIS.Framework.XPanel();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPaInfo = new IHIS.X.Magic.Controls.TabPage();
            this.btnIfEkg = new IHIS.Framework.XButton();
            this.cbxEkgIFYN = new IHIS.Framework.XCheckBox();
            this.dbxUnusualInfo = new IHIS.Framework.XDisplayBox();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.dbxSexAge = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.dbxPaceMaker = new IHIS.Framework.XDisplayBox();
            this.xPaInfoBox1 = new IHIS.Framework.XPaInfoBox();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.dbxHodongHocode = new IHIS.Framework.XDisplayBox();
            this.dbxHeightWeight = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.dbxActLastDate = new IHIS.Framework.XDisplayBox();
            this.dbxInOutGubunName = new IHIS.Framework.XDisplayBox();
            this.dbxBirth = new IHIS.Framework.XDisplayBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.dbxBunho = new IHIS.Framework.XDisplayBox();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.lbPaceMaker = new IHIS.Framework.XLabel();
            this.tabSangByung = new IHIS.X.Magic.Controls.TabPage();
            this.grdSangByung = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.tabOrdRemark = new IHIS.X.Magic.Controls.TabPage();
            this.txtOrderRemark = new IHIS.Framework.XRichTextBox();
            this.tabPaComment = new IHIS.X.Magic.Controls.TabPage();
            this.paComment = new IHIS.Framework.XPaComment();
            this.groupExpandForm = new IHIS.OCSO.GroupExpandForm();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbxTodayOut = new IHIS.Framework.XRadioButton();
            this.rbxOut = new IHIS.Framework.XRadioButton();
            this.rbxInp = new IHIS.Framework.XRadioButton();
            this.rbxIOAll = new IHIS.Framework.XRadioButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xPanelControl = new IHIS.Framework.XPanel();
            this.grdJaeryo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.btnExpandOrdgrid = new IHIS.Framework.XButton();
            this.grdOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.inj1001U01 = new IHIS.OCSO.UCINJ1001U01();
            this.cpl2010U00 = new IHIS.OCSO.UCCPL2010U00();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnExpand = new IHIS.Framework.XButton();
            this.grdPaList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.rbxNonAct = new IHIS.Framework.XRadioButton();
            this.rbxAct = new IHIS.Framework.XRadioButton();
            this.rbxActAll = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSuname = new System.Windows.Forms.Label();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.cboSystem = new IHIS.Framework.XDictComboBox();
            this.lbPart = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnReSendIF = new IHIS.Framework.XButton();
            this.btnReserViewer = new IHIS.Framework.XButton();
            this.btnPacsViewer = new IHIS.Framework.XButton();
            this.btnEMR = new IHIS.Framework.XButton();
            this.btnReportViewer = new IHIS.Framework.XButton();
            this.btnRequest = new IHIS.Framework.XButton();
            this.btnJaeryo = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.fwkActor = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.defaultJearyo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layPacsInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mlayConstantInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.mlayPart = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            this.xPanel15.SuspendLayout();
            this.xPanel11.SuspendLayout();
            this.xPanel14.SuspendLayout();
            this.xPanel13.SuspendLayout();
            this.xPanel12.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPaInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).BeginInit();
            this.tabSangByung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangByung)).BeginInit();
            this.tabOrdRemark.SuspendLayout();
            this.tabPaComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paComment)).BeginInit();
            this.xPanel6.SuspendLayout();
            this.xPanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJaeryo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultJearyo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPacsInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayPart)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(2, "autoSizeHeight.gif");
            this.ImageList.Images.SetKeyName(3, "autoSizeHeight2.gif");
            this.ImageList.Images.SetKeyName(4, "환자조회.gif");
            this.ImageList.Images.SetKeyName(5, "진료의사.gif");
            this.ImageList.Images.SetKeyName(6, "진료자.gif");
            this.ImageList.Images.SetKeyName(7, "약국정보관리16.ico");
            this.ImageList.Images.SetKeyName(8, "진료안내16.ico");
            this.ImageList.Images.SetKeyName(9, "장비인터페이스16.ico");
            this.ImageList.Images.SetKeyName(10, "재진예약.ico");
            this.ImageList.Images.SetKeyName(11, "pacs view.png");
            this.ImageList.Images.SetKeyName(12, "접수.ico");
            this.ImageList.Images.SetKeyName(13, "EMR16.ico");
            this.ImageList.Images.SetKeyName(14, "장기이식센터16.ico");
            this.ImageList.Images.SetKeyName(15, "간호-부서처방2.ico");
            this.ImageList.Images.SetKeyName(16, "검사예약.gif");
            this.ImageList.Images.SetKeyName(17, "OEOD.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel5.Controls.Add(this.xPanel15);
            this.xPanel5.Controls.Add(this.xPanel11);
            this.xPanel5.Controls.Add(this.xPanel6);
            this.xPanel5.Controls.Add(this.splitter2);
            this.xPanel5.Controls.Add(this.xPanelControl);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // xPanel15
            // 
            this.xPanel15.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel15.Controls.Add(this.rbxPFE);
            this.xPanel15.Controls.Add(this.rbxTST);
            this.xPanel15.Controls.Add(this.rbxCPL);
            this.xPanel15.Controls.Add(this.rbxINJ);
            resources.ApplyResources(this.xPanel15, "xPanel15");
            this.xPanel15.DrawBorder = true;
            this.xPanel15.Name = "xPanel15";
            // 
            // rbxPFE
            // 
            resources.ApplyResources(this.rbxPFE, "rbxPFE");
            this.rbxPFE.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxPFE.Name = "rbxPFE";
            this.rbxPFE.UseVisualStyleBackColor = false;
            this.rbxPFE.CheckedChanged += new System.EventHandler(this.rbxDep_CheckedChanged);
            // 
            // rbxTST
            // 
            resources.ApplyResources(this.rbxTST, "rbxTST");
            this.rbxTST.BackColor = IHIS.Framework.XColor.DockingGradientEndColor;
            this.rbxTST.Checked = true;
            this.rbxTST.Name = "rbxTST";
            this.rbxTST.TabStop = true;
            this.rbxTST.UseVisualStyleBackColor = false;
            this.rbxTST.CheckedChanged += new System.EventHandler(this.rbxDep_CheckedChanged);
            // 
            // rbxCPL
            // 
            resources.ApplyResources(this.rbxCPL, "rbxCPL");
            this.rbxCPL.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxCPL.Name = "rbxCPL";
            this.rbxCPL.UseVisualStyleBackColor = false;
            this.rbxCPL.CheckedChanged += new System.EventHandler(this.rbxDep_CheckedChanged);
            // 
            // rbxINJ
            // 
            resources.ApplyResources(this.rbxINJ, "rbxINJ");
            this.rbxINJ.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxINJ.Name = "rbxINJ";
            this.rbxINJ.UseVisualStyleBackColor = false;
            this.rbxINJ.CheckedChanged += new System.EventHandler(this.rbxDep_CheckedChanged);
            // 
            // xPanel11
            // 
            this.xPanel11.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xPanel11, "xPanel11");
            this.xPanel11.Controls.Add(this.xPanel14);
            this.xPanel11.Controls.Add(this.xPanel13);
            this.xPanel11.Controls.Add(this.xPanel12);
            this.xPanel11.DrawBorder = true;
            this.xPanel11.Name = "xPanel11";
            // 
            // xPanel14
            // 
            this.xPanel14.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel14.Controls.Add(this.btnChange);
            this.xPanel14.Controls.Add(this.dbxDocName);
            this.xPanel14.Controls.Add(this.dbxDocCode);
            this.xPanel14.Controls.Add(this.btnViewEMR);
            this.xPanel14.Controls.Add(this.xLabel17);
            resources.ApplyResources(this.xPanel14, "xPanel14");
            this.xPanel14.DrawBorder = true;
            this.xPanel14.Name = "xPanel14";
            // 
            // btnChange
            // 
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.ImageList = this.ImageList;
            this.btnChange.Name = "btnChange";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dbxDocName
            // 
            resources.ApplyResources(this.dbxDocName, "dbxDocName");
            this.dbxDocName.Name = "dbxDocName";
            // 
            // dbxDocCode
            // 
            resources.ApplyResources(this.dbxDocCode, "dbxDocCode");
            this.dbxDocCode.Name = "dbxDocCode";
            // 
            // btnViewEMR
            // 
            resources.ApplyResources(this.btnViewEMR, "btnViewEMR");
            this.btnViewEMR.ImageIndex = 13;
            this.btnViewEMR.ImageList = this.ImageList;
            this.btnViewEMR.Name = "btnViewEMR";
            // 
            // xLabel17
            // 
            this.xLabel17.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.Name = "xLabel17";
            // 
            // xPanel13
            // 
            this.xPanel13.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xPanel13, "xPanel13");
            this.xPanel13.Controls.Add(this.patientInfoBox);
            this.xPanel13.DrawBorder = true;
            this.xPanel13.Name = "xPanel13";
            // 
            // patientInfoBox
            // 
            resources.ApplyResources(this.patientInfoBox, "patientInfoBox");
            this.patientInfoBox.Name = "patientInfoBox";
            // 
            // xPanel12
            // 
            this.xPanel12.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xPanel12, "xPanel12");
            this.xPanel12.Controls.Add(this.tabControl);
            this.xPanel12.Controls.Add(this.groupExpandForm);
            this.xPanel12.DrawBorder = true;
            this.xPanel12.Name = "xPanel12";
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SelectedTab = this.tabPaInfo;
            this.tabControl.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPaInfo,
            this.tabSangByung,
            this.tabOrdRemark,
            this.tabPaComment});
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabPaInfo
            // 
            this.tabPaInfo.Controls.Add(this.btnIfEkg);
            this.tabPaInfo.Controls.Add(this.cbxEkgIFYN);
            this.tabPaInfo.Controls.Add(this.dbxUnusualInfo);
            this.tabPaInfo.Controls.Add(this.xLabel15);
            this.tabPaInfo.Controls.Add(this.dbxSexAge);
            this.tabPaInfo.Controls.Add(this.xLabel5);
            this.tabPaInfo.Controls.Add(this.dbxGwaName);
            this.tabPaInfo.Controls.Add(this.xLabel14);
            this.tabPaInfo.Controls.Add(this.dbxDoctorName);
            this.tabPaInfo.Controls.Add(this.xLabel13);
            this.tabPaInfo.Controls.Add(this.dbxPaceMaker);
            this.tabPaInfo.Controls.Add(this.xPaInfoBox1);
            this.tabPaInfo.Controls.Add(this.dbxSuname2);
            this.tabPaInfo.Controls.Add(this.dbxSuname);
            this.tabPaInfo.Controls.Add(this.dbxHodongHocode);
            this.tabPaInfo.Controls.Add(this.dbxHeightWeight);
            this.tabPaInfo.Controls.Add(this.xLabel7);
            this.tabPaInfo.Controls.Add(this.dbxActLastDate);
            this.tabPaInfo.Controls.Add(this.dbxInOutGubunName);
            this.tabPaInfo.Controls.Add(this.dbxBirth);
            this.tabPaInfo.Controls.Add(this.xLabel6);
            this.tabPaInfo.Controls.Add(this.xLabel4);
            this.tabPaInfo.Controls.Add(this.dbxBunho);
            this.tabPaInfo.Controls.Add(this.xLabel11);
            this.tabPaInfo.Controls.Add(this.xLabel8);
            this.tabPaInfo.Controls.Add(this.xLabel10);
            this.tabPaInfo.Controls.Add(this.xLabel9);
            this.tabPaInfo.Controls.Add(this.lbPaceMaker);
            this.tabPaInfo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tabPaInfo.ImageIndex = 4;
            this.tabPaInfo.ImageList = this.ImageList;
            resources.ApplyResources(this.tabPaInfo, "tabPaInfo");
            this.tabPaInfo.Name = "tabPaInfo";
            this.tabPaInfo.TitleTextColor = System.Drawing.Color.Maroon;
            // 
            // btnIfEkg
            // 
            resources.ApplyResources(this.btnIfEkg, "btnIfEkg");
            this.btnIfEkg.ImageIndex = 9;
            this.btnIfEkg.ImageList = this.ImageList;
            this.btnIfEkg.Name = "btnIfEkg";
            this.btnIfEkg.Click += new System.EventHandler(this.btnIfEkg_Click);
            // 
            // cbxEkgIFYN
            // 
            this.cbxEkgIFYN.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.cbxEkgIFYN.CheckedText = "心電図ON";
            resources.ApplyResources(this.cbxEkgIFYN, "cbxEkgIFYN");
            this.cbxEkgIFYN.Name = "cbxEkgIFYN";
            this.cbxEkgIFYN.UnCheckedText = "心電図OFF";
            this.cbxEkgIFYN.UseVisualStyleBackColor = false;
            // 
            // dbxUnusualInfo
            // 
            resources.ApplyResources(this.dbxUnusualInfo, "dbxUnusualInfo");
            this.dbxUnusualInfo.Name = "dbxUnusualInfo";
            // 
            // xLabel15
            // 
            this.xLabel15.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.Name = "xLabel15";
            // 
            // dbxSexAge
            // 
            resources.ApplyResources(this.dbxSexAge, "dbxSexAge");
            this.dbxSexAge.Name = "dbxSexAge";
            // 
            // xLabel5
            // 
            this.xLabel5.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // dbxGwaName
            // 
            resources.ApplyResources(this.dbxGwaName, "dbxGwaName");
            this.dbxGwaName.Name = "dbxGwaName";
            // 
            // xLabel14
            // 
            this.xLabel14.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Name = "xLabel14";
            // 
            // dbxDoctorName
            // 
            resources.ApplyResources(this.dbxDoctorName, "dbxDoctorName");
            this.dbxDoctorName.Name = "dbxDoctorName";
            // 
            // xLabel13
            // 
            this.xLabel13.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // dbxPaceMaker
            // 
            resources.ApplyResources(this.dbxPaceMaker, "dbxPaceMaker");
            this.dbxPaceMaker.Name = "dbxPaceMaker";
            // 
            // xPaInfoBox1
            // 
            resources.ApplyResources(this.xPaInfoBox1, "xPaInfoBox1");
            this.xPaInfoBox1.Name = "xPaInfoBox1";
            // 
            // dbxSuname2
            // 
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.Name = "dbxSuname2";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // dbxHodongHocode
            // 
            resources.ApplyResources(this.dbxHodongHocode, "dbxHodongHocode");
            this.dbxHodongHocode.Name = "dbxHodongHocode";
            // 
            // dbxHeightWeight
            // 
            resources.ApplyResources(this.dbxHeightWeight, "dbxHeightWeight");
            this.dbxHeightWeight.Name = "dbxHeightWeight";
            // 
            // xLabel7
            // 
            this.xLabel7.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // dbxActLastDate
            // 
            resources.ApplyResources(this.dbxActLastDate, "dbxActLastDate");
            this.dbxActLastDate.Name = "dbxActLastDate";
            // 
            // dbxInOutGubunName
            // 
            resources.ApplyResources(this.dbxInOutGubunName, "dbxInOutGubunName");
            this.dbxInOutGubunName.Name = "dbxInOutGubunName";
            // 
            // dbxBirth
            // 
            resources.ApplyResources(this.dbxBirth, "dbxBirth");
            this.dbxBirth.Name = "dbxBirth";
            // 
            // xLabel6
            // 
            this.xLabel6.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel4
            // 
            this.xLabel4.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // dbxBunho
            // 
            resources.ApplyResources(this.dbxBunho, "dbxBunho");
            this.dbxBunho.Name = "dbxBunho";
            // 
            // xLabel11
            // 
            this.xLabel11.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel8
            // 
            this.xLabel8.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel10
            // 
            this.xLabel10.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel9
            // 
            this.xLabel9.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // lbPaceMaker
            // 
            this.lbPaceMaker.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.lbPaceMaker, "lbPaceMaker");
            this.lbPaceMaker.ImageList = this.ImageList;
            this.lbPaceMaker.Name = "lbPaceMaker";
            // 
            // tabSangByung
            // 
            this.tabSangByung.Controls.Add(this.grdSangByung);
            this.tabSangByung.ImageIndex = 5;
            this.tabSangByung.ImageList = this.ImageList;
            resources.ApplyResources(this.tabSangByung, "tabSangByung");
            this.tabSangByung.Name = "tabSangByung";
            this.tabSangByung.Selected = false;
            // 
            // grdSangByung
            // 
            this.grdSangByung.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1});
            this.grdSangByung.ColPerLine = 1;
            this.grdSangByung.Cols = 2;
            resources.ApplyResources(this.grdSangByung, "grdSangByung");
            this.grdSangByung.ExecuteQuery = null;
            this.grdSangByung.FixedCols = 1;
            this.grdSangByung.FixedRows = 1;
            this.grdSangByung.HeaderHeights.Add(0);
            this.grdSangByung.Name = "grdSangByung";
            this.grdSangByung.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangByung.ParamList")));
            this.grdSangByung.QuerySQL = resources.GetString("grdSangByung.QuerySQL");
            this.grdSangByung.RowHeaderVisible = true;
            this.grdSangByung.Rows = 2;
            this.grdSangByung.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xGridCell1
            // 
            this.xGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridCell1.CellName = "sang_name";
            this.xGridCell1.CellWidth = 796;
            this.xGridCell1.Col = 1;
            this.xGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xGridCell1, "xGridCell1");
            this.xGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // tabOrdRemark
            // 
            this.tabOrdRemark.Controls.Add(this.txtOrderRemark);
            this.tabOrdRemark.ImageIndex = 6;
            this.tabOrdRemark.ImageList = this.ImageList;
            resources.ApplyResources(this.tabOrdRemark, "tabOrdRemark");
            this.tabOrdRemark.Name = "tabOrdRemark";
            this.tabOrdRemark.Selected = false;
            // 
            // txtOrderRemark
            // 
            resources.ApplyResources(this.txtOrderRemark, "txtOrderRemark");
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Protect = true;
            this.txtOrderRemark.ReadOnly = true;
            // 
            // tabPaComment
            // 
            this.tabPaComment.Controls.Add(this.paComment);
            this.tabPaComment.ImageIndex = 15;
            this.tabPaComment.ImageList = this.ImageList;
            resources.ApplyResources(this.tabPaComment, "tabPaComment");
            this.tabPaComment.Name = "tabPaComment";
            this.tabPaComment.Selected = false;
            this.tabPaComment.Tag = "paCmmt";
            // 
            // paComment
            // 
            resources.ApplyResources(this.paComment, "paComment");
            this.paComment.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.paComment.Name = "paComment";
            // 
            // groupExpandForm
            // 
            resources.ApplyResources(this.groupExpandForm, "groupExpandForm");
            this.groupExpandForm.Name = "groupExpandForm";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.rbxTodayOut);
            this.xPanel6.Controls.Add(this.rbxOut);
            this.xPanel6.Controls.Add(this.rbxInp);
            this.xPanel6.Controls.Add(this.rbxIOAll);
            this.xPanel6.DrawBorder = true;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // rbxTodayOut
            // 
            resources.ApplyResources(this.rbxTodayOut, "rbxTodayOut");
            this.rbxTodayOut.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxTodayOut.ImageList = this.ImageList;
            this.rbxTodayOut.Name = "rbxTodayOut";
            this.rbxTodayOut.UseVisualStyleBackColor = false;
            // 
            // rbxOut
            // 
            resources.ApplyResources(this.rbxOut, "rbxOut");
            this.rbxOut.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxOut.ImageList = this.ImageList;
            this.rbxOut.Name = "rbxOut";
            this.rbxOut.UseVisualStyleBackColor = false;
            // 
            // rbxInp
            // 
            resources.ApplyResources(this.rbxInp, "rbxInp");
            this.rbxInp.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxInp.ImageList = this.ImageList;
            this.rbxInp.Name = "rbxInp";
            this.rbxInp.UseVisualStyleBackColor = false;
            // 
            // rbxIOAll
            // 
            resources.ApplyResources(this.rbxIOAll, "rbxIOAll");
            this.rbxIOAll.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxIOAll.Checked = true;
            this.rbxIOAll.ImageList = this.ImageList;
            this.rbxIOAll.Name = "rbxIOAll";
            this.rbxIOAll.TabStop = true;
            this.rbxIOAll.UseVisualStyleBackColor = false;
            this.rbxIOAll.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // xPanelControl
            // 
            this.xPanelControl.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xPanelControl, "xPanelControl");
            this.xPanelControl.Controls.Add(this.grdJaeryo);
            this.xPanelControl.Controls.Add(this.btnExpandOrdgrid);
            this.xPanelControl.Controls.Add(this.grdOrder);
            this.xPanelControl.Controls.Add(this.inj1001U01);
            this.xPanelControl.Controls.Add(this.cpl2010U00);
            this.xPanelControl.DrawBorder = true;
            this.xPanelControl.Name = "xPanelControl";
            // 
            // grdJaeryo
            // 
            this.grdJaeryo.ApplyAutoHeight = true;
            this.grdJaeryo.ApplyPaintEventToAllColumn = true;
            this.grdJaeryo.CallerID = '2';
            this.grdJaeryo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell42,
            this.xEditGridCell43,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49,
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell92});
            this.grdJaeryo.ColPerLine = 5;
            this.grdJaeryo.ColResizable = true;
            this.grdJaeryo.Cols = 6;
            resources.ApplyResources(this.grdJaeryo, "grdJaeryo");
            this.grdJaeryo.EnableMultiSelection = true;
            this.grdJaeryo.ExecuteQuery = null;
            this.grdJaeryo.FixedCols = 1;
            this.grdJaeryo.FixedRows = 1;
            this.grdJaeryo.HeaderHeights.Add(31);
            this.grdJaeryo.Name = "grdJaeryo";
            this.grdJaeryo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJaeryo.ParamList")));
            this.grdJaeryo.QuerySQL = resources.GetString("grdJaeryo.QuerySQL");
            this.grdJaeryo.RowHeaderVisible = true;
            this.grdJaeryo.RowResizable = true;
            this.grdJaeryo.Rows = 2;
            this.grdJaeryo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdJaeryo.SelectionModeChangeable = true;
            this.grdJaeryo.ToolTipActive = true;
            this.grdJaeryo.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdJaeryo_GridFindSelected);
            this.grdJaeryo.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdJaeryo_GridColumnChanged);
            this.grdJaeryo.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdJaeryo_GridFindClick);
            this.grdJaeryo.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdJaeryo_RowFocusChanged);
            this.grdJaeryo.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdJaeryo_GridColumnProtectModify);
            this.grdJaeryo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 116;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "hangmog_name";
            this.xEditGridCell12.CellWidth = 488;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "suryang";
            this.xEditGridCell13.CellWidth = 105;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pkinv1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "bunho";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "order_date";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "in_out_gubun";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "acting_date";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "acting_buseo";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "fkocs_inv";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "fkocs_xrt";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "ord_danui_name";
            this.xEditGridCell45.CellWidth = 98;
            this.xEditGridCell45.Col = 4;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdCol = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "bunryu2";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "jaeryo_gubun";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "jaeryo_yn";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "input_control";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "bun_code";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "nalsu";
            this.xEditGridCell51.CellWidth = 64;
            this.xEditGridCell51.Col = 5;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "pkocs";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // btnExpandOrdgrid
            // 
            resources.ApplyResources(this.btnExpandOrdgrid, "btnExpandOrdgrid");
            this.btnExpandOrdgrid.ImageIndex = 3;
            this.btnExpandOrdgrid.ImageList = this.ImageList;
            this.btnExpandOrdgrid.Name = "btnExpandOrdgrid";
            this.btnExpandOrdgrid.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            // 
            // grdOrder
            // 
            this.grdOrder.ApplyAutoHeight = true;
            this.grdOrder.ApplyPaintEventToAllColumn = true;
            this.grdOrder.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell52,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell70,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell57,
            this.xEditGridCell58,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell68,
            this.xEditGridCell69,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell84,
            this.xEditGridCell82,
            this.xEditGridCell89,
            this.xEditGridCell83,
            this.xEditGridCell77,
            this.xEditGridCell85,
            this.xEditGridCell87,
            this.xEditGridCell88});
            this.grdOrder.ColPerLine = 16;
            this.grdOrder.ColResizable = true;
            this.grdOrder.Cols = 17;
            this.grdOrder.ControlBinding = true;
            resources.ApplyResources(this.grdOrder, "grdOrder");
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 1;
            this.grdOrder.HeaderHeights.Add(29);
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.RowResizable = true;
            this.grdOrder.Rows = 2;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrder_QueryEnd);
            this.grdOrder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOrder_MouseDown);
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grd_RowFocusChanged);
            this.grdOrder.GridMemoFormShowing += new IHIS.Framework.GridMemoFormShowingEventHandler(this.grdOrder_GridMemoFormShowing);
            this.grdOrder.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdOrder_RowFocusChanging);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOrder_QueryStarting);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "in_out_gubun";
            this.xEditGridCell52.CellWidth = 35;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pkocs";
            this.xEditGridCell6.CellWidth = 36;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "act_yn";
            this.xEditGridCell7.CellWidth = 112;
            this.xEditGridCell7.Col = 14;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "hangmog_code";
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "hangmog_name";
            this.xEditGridCell18.CellWidth = 247;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "jubsu_date";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell90.CellWidth = 208;
            this.xEditGridCell90.Col = 9;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "jubsu_time";
            this.xEditGridCell91.CellWidth = 37;
            this.xEditGridCell91.Col = 10;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.Mask = "##:##";
            this.xEditGridCell91.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "acting_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "acting_time";
            this.xEditGridCell9.CellWidth = 49;
            this.xEditGridCell9.Col = 12;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.Mask = "##:##";
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "order_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 1;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "order_time";
            this.xEditGridCell19.CellWidth = 1;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.Mask = "##:##";
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "reser_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.CellWidth = 123;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "reser_time";
            this.xEditGridCell21.CellWidth = 45;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.Mask = "##:##";
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "act_doctor";
            this.xEditGridCell22.CellWidth = 92;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "act_doctor_name";
            this.xEditGridCell70.CellWidth = 85;
            this.xEditGridCell70.Col = 13;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "act_buseo";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "act_gwa";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.BindControl = this.dbxBunho;
            this.xEditGridCell54.CellName = "bunho";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.BindControl = this.dbxSuname;
            this.xEditGridCell55.CellName = "suname";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.BindControl = this.dbxSuname2;
            this.xEditGridCell56.CellName = "suname2";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "gwa";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.BindControl = this.dbxGwaName;
            this.xEditGridCell58.CellName = "gwa_name";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "doctor";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.BindControl = this.dbxDoctorName;
            this.xEditGridCell60.CellName = "doctor_name";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AppendReservedMemoText = true;
            this.xEditGridCell61.BindControl = this.txtOrderRemark;
            this.xEditGridCell61.CellLen = 2000;
            this.xEditGridCell61.CellName = "order_remark";
            this.xEditGridCell61.CellWidth = 51;
            this.xEditGridCell61.Col = 15;
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.HeaderTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xEditGridCell61.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell61.ReservedMemoClassName = "IHIS.OCSA.OCS0223Q01";
            this.xEditGridCell61.ShowReservedMemoButton = true;
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.BindControl = this.dbxBirth;
            this.xEditGridCell62.CellName = "birth";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.BindControl = this.dbxSexAge;
            this.xEditGridCell63.CellName = "sex_age";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.BindControl = this.dbxHeightWeight;
            this.xEditGridCell64.CellName = "height_weight";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.BindControl = this.dbxInOutGubunName;
            this.xEditGridCell65.CellName = "in_out_gubun_name";
            this.xEditGridCell65.CellWidth = 102;
            this.xEditGridCell65.Col = 16;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.BindControl = this.dbxPaceMaker;
            this.xEditGridCell66.CellName = "pace_maker_yn";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.BindControl = this.dbxHodongHocode;
            this.xEditGridCell67.CellName = "hodong_hocode";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.BindControl = this.dbxActLastDate;
            this.xEditGridCell68.CellName = "last_gumsa_date";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.BindControl = this.dbxUnusualInfo;
            this.xEditGridCell69.CellName = "unusual_info";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "jundal_table";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "jundal_part";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "fkout1001";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "reser_yn";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "emergency";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "old_act_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "if_data_send_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "specific_comment";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "sort_fkocskey";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "input_control";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "bun_code";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "suryang";
            this.xEditGridCell87.Col = 5;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "nalsu";
            this.xEditGridCell88.CellWidth = 113;
            this.xEditGridCell88.Col = 6;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inj1001U01
            // 
            this.inj1001U01.Actor = null;
            this.inj1001U01.ActorName = null;
            this.inj1001U01.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this.inj1001U01, "inj1001U01");
            this.inj1001U01.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            this.inj1001U01.BackGroundColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.inj1001U01.Bunho = null;
            this.inj1001U01.CausesValidation = false;
            this.inj1001U01.Doctor = null;
            this.inj1001U01.DtpQueryDate = null;
            this.inj1001U01.Gwa = null;
            this.inj1001U01.JubsuDate = null;
            this.inj1001U01.Name = "inj1001U01";
            this.inj1001U01.OrderDate = null;
            this.inj1001U01.RbtDone = null;
            this.inj1001U01.RbtWait = null;
            // 
            // cpl2010U00
            // 
            this.cpl2010U00.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249)))));
            this.cpl2010U00.BackGroundColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.cpl2010U00.Bunho = null;
            this.cpl2010U00.CausesValidation = false;
            this.cpl2010U00.CbxActor = null;
            resources.ApplyResources(this.cpl2010U00, "cpl2010U00");
            this.cpl2010U00.Doctor = null;
            this.cpl2010U00.DtpOrderDate = null;
            this.cpl2010U00.DtpOrderToDate = null;
            this.cpl2010U00.EmergencyYn = null;
            this.cpl2010U00.Name = "cpl2010U00";
            this.cpl2010U00.RbxJubsu = null;
            this.cpl2010U00.RbxMijubsu = null;
            this.cpl2010U00.ReserYn = null;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel4.Controls.Add(this.btnExpand);
            this.xPanel4.Controls.Add(this.grdPaList);
            this.xPanel4.Controls.Add(this.xPanel7);
            this.xPanel4.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // btnExpand
            // 
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.ImageIndex = 3;
            this.btnExpand.ImageList = this.ImageList;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // grdPaList
            // 
            this.grdPaList.ApplyAutoHeight = true;
            this.grdPaList.ApplyPaintEventToAllColumn = true;
            this.grdPaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell93,
            this.xEditGridCell4,
            this.xEditGridCell86,
            this.xEditGridCell94,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell95,
            this.xEditGridCell96,
            this.xEditGridCell97,
            this.xEditGridCell98,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell2,
            this.xEditGridCell101,
            this.xEditGridCell102,
            this.xEditGridCell76,
            this.xEditGridCell1});
            this.grdPaList.ColPerLine = 4;
            this.grdPaList.ColResizable = true;
            this.grdPaList.Cols = 5;
            resources.ApplyResources(this.grdPaList, "grdPaList");
            this.grdPaList.EnableMultiSelection = true;
            this.grdPaList.ExecuteQuery = null;
            this.grdPaList.FixedCols = 1;
            this.grdPaList.FixedRows = 1;
            this.grdPaList.HeaderHeights.Add(32);
            this.grdPaList.Name = "grdPaList";
            this.grdPaList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaList.ParamList")));
            this.grdPaList.ReadOnly = true;
            this.grdPaList.RowHeaderVisible = true;
            this.grdPaList.RowResizable = true;
            this.grdPaList.Rows = 2;
            this.grdPaList.SelectionModeChangeable = true;
            this.grdPaList.ToolTipActive = true;
            this.grdPaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaList_QueryEnd);
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grd_RowFocusChanged);
            this.grdPaList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaList_GridCellPainting);
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaList_QueryStarting);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "trial";
            this.xEditGridCell93.CellWidth = 43;
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsReadOnly = true;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            this.xEditGridCell93.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 119;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "jundal_table";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.IsReadOnly = true;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "jundal_table_name";
            this.xEditGridCell94.CellWidth = 127;
            this.xEditGridCell94.Col = 2;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "gwa";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.IsReadOnly = true;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "gwa_name";
            this.xEditGridCell79.CellWidth = 1;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsReadOnly = true;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "doctor";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.IsReadOnly = true;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "doctor_name";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsReadOnly = true;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "suname2";
            this.xEditGridCell5.CellWidth = 126;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 93;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.CellName = "pkocs1003";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.IsReadOnly = true;
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "fkout1001";
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.CellName = "reser_gubun";
            this.xEditGridCell97.Col = -1;
            this.xEditGridCell97.ExecuteQuery = null;
            this.xEditGridCell97.IsReadOnly = true;
            this.xEditGridCell97.IsVisible = false;
            this.xEditGridCell97.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "order_date";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "reser_date";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.IsReadOnly = true;
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "in_out_gubun";
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.IsReadOnly = true;
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "reser_yn";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "kijun_date";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.IsReadOnly = true;
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.CellName = "naewon_time";
            this.xEditGridCell102.Col = -1;
            this.xEditGridCell102.ExecuteQuery = null;
            this.xEditGridCell102.IsReadOnly = true;
            this.xEditGridCell102.IsVisible = false;
            this.xEditGridCell102.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "emergency";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.IsReadOnly = true;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "acting_yn";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.rbxNonAct);
            this.xPanel7.Controls.Add(this.rbxAct);
            this.xPanel7.Controls.Add(this.rbxActAll);
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
            // 
            // rbxNonAct
            // 
            resources.ApplyResources(this.rbxNonAct, "rbxNonAct");
            this.rbxNonAct.BackColor = IHIS.Framework.XColor.DockingGradientEndColor;
            this.rbxNonAct.Checked = true;
            this.rbxNonAct.ImageList = this.ImageList;
            this.rbxNonAct.Name = "rbxNonAct";
            this.rbxNonAct.TabStop = true;
            this.rbxNonAct.UseVisualStyleBackColor = false;
            this.rbxNonAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            // 
            // rbxAct
            // 
            resources.ApplyResources(this.rbxAct, "rbxAct");
            this.rbxAct.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxAct.ImageList = this.ImageList;
            this.rbxAct.Name = "rbxAct";
            this.rbxAct.UseVisualStyleBackColor = false;
            this.rbxAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            // 
            // rbxActAll
            // 
            resources.ApplyResources(this.rbxActAll, "rbxActAll");
            this.rbxActAll.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxActAll.ImageList = this.ImageList;
            this.rbxActAll.Name = "rbxActAll";
            this.rbxActAll.UseVisualStyleBackColor = false;
            this.rbxActAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            // 
            // xPanel2
            // 
            this.xPanel2.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.xPanel8);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // xPanel8
            // 
            this.xPanel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xPanel8.Controls.Add(this.xLabel3);
            this.xPanel8.Controls.Add(this.label2);
            this.xPanel8.Controls.Add(this.lbSuname);
            this.xPanel8.Controls.Add(this.btnUseAlarmChk);
            this.xPanel8.Controls.Add(this.btnUseTimeChk);
            this.xPanel8.Controls.Add(this.cboTime);
            this.xPanel8.Controls.Add(this.txtTimeInterval);
            this.xPanel8.Controls.Add(this.tbxTimer);
            this.xPanel8.Controls.Add(this.xLabel12);
            this.xPanel8.Controls.Add(this.lbTime);
            this.xPanel8.Controls.Add(this.xLabel2);
            this.xPanel8.Controls.Add(this.dtpToDate);
            this.xPanel8.Controls.Add(this.label1);
            this.xPanel8.Controls.Add(this.dtpFromDate);
            this.xPanel8.Controls.Add(this.xLabel1);
            this.xPanel8.Controls.Add(this.cboPart);
            this.xPanel8.Controls.Add(this.cboSystem);
            this.xPanel8.Controls.Add(this.lbPart);
            this.xPanel8.Controls.Add(this.paBox);
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Name = "xPanel8";
            // 
            // xLabel3
            // 
            this.xLabel3.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbSuname
            // 
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.Name = "lbSuname";
            // 
            // btnUseAlarmChk
            // 
            resources.ApplyResources(this.btnUseAlarmChk, "btnUseAlarmChk");
            this.btnUseAlarmChk.ImageIndex = 0;
            this.btnUseAlarmChk.ImageList = this.ImageList;
            this.btnUseAlarmChk.Name = "btnUseAlarmChk";
            this.btnUseAlarmChk.Click += new System.EventHandler(this.btnUseAlarmChk_Click);
            // 
            // btnUseTimeChk
            // 
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.ImageIndex = 0;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // cboTime
            // 
            this.cboTime.ExecuteQuery = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
            // 
            // tbxTimer
            // 
            resources.ApplyResources(this.tbxTimer, "tbxTimer");
            this.tbxTimer.Name = "tbxTimer";
            // 
            // xLabel12
            // 
            this.xLabel12.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel12.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // lbTime
            // 
            this.lbTime.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Name = "lbTime";
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cboPart
            // 
            this.cboPart.ExecuteQuery = null;
            resources.ApplyResources(this.cboPart, "cboPart");
            this.cboPart.Name = "cboPart";
            this.cboPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPart.ParamList")));
            this.cboPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboPart.SelectionChangeCommitted += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // cboSystem
            // 
            this.cboSystem.ExecuteQuery = null;
            resources.ApplyResources(this.cboSystem, "cboSystem");
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSystem.ParamList")));
            this.cboSystem.Protect = true;
            this.cboSystem.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSystem.TabStop = false;
            this.cboSystem.SelectedIndexChanged += new System.EventHandler(this.cboSystem_SelectedIndexChanged);
            // 
            // lbPart
            // 
            this.lbPart.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            resources.ApplyResources(this.lbPart, "lbPart");
            this.lbPart.Name = "lbPart";
            // 
            // paBox
            // 
            this.paBox.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.Validated += new System.EventHandler(this.paBox_Validated);
            // 
            // xPanel3
            // 
            this.xPanel3.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel3.Controls.Add(this.btnReSendIF);
            this.xPanel3.Controls.Add(this.btnReserViewer);
            this.xPanel3.Controls.Add(this.btnPacsViewer);
            this.xPanel3.Controls.Add(this.btnEMR);
            this.xPanel3.Controls.Add(this.btnReportViewer);
            this.xPanel3.Controls.Add(this.btnRequest);
            this.xPanel3.Controls.Add(this.btnJaeryo);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnReSendIF
            // 
            resources.ApplyResources(this.btnReSendIF, "btnReSendIF");
            this.btnReSendIF.ImageIndex = 9;
            this.btnReSendIF.ImageList = this.ImageList;
            this.btnReSendIF.Name = "btnReSendIF";
            this.btnReSendIF.Click += new System.EventHandler(this.btnReSendIF_Click);
            // 
            // btnReserViewer
            // 
            resources.ApplyResources(this.btnReserViewer, "btnReserViewer");
            this.btnReserViewer.ImageIndex = 10;
            this.btnReserViewer.ImageList = this.ImageList;
            this.btnReserViewer.Name = "btnReserViewer";
            this.btnReserViewer.Click += new System.EventHandler(this.btnReserViewer_Click);
            // 
            // btnPacsViewer
            // 
            resources.ApplyResources(this.btnPacsViewer, "btnPacsViewer");
            this.btnPacsViewer.ImageIndex = 11;
            this.btnPacsViewer.ImageList = this.ImageList;
            this.btnPacsViewer.Name = "btnPacsViewer";
            // 
            // btnEMR
            // 
            resources.ApplyResources(this.btnEMR, "btnEMR");
            this.btnEMR.ImageIndex = 13;
            this.btnEMR.ImageList = this.ImageList;
            this.btnEMR.Name = "btnEMR";
            this.btnEMR.Click += new System.EventHandler(this.btnEMR_Click);
            // 
            // btnReportViewer
            // 
            resources.ApplyResources(this.btnReportViewer, "btnReportViewer");
            this.btnReportViewer.ImageIndex = 12;
            this.btnReportViewer.ImageList = this.ImageList;
            this.btnReportViewer.Name = "btnReportViewer";
            this.btnReportViewer.Click += new System.EventHandler(this.btnReportViewer_Click);
            // 
            // btnRequest
            // 
            resources.ApplyResources(this.btnRequest, "btnRequest");
            this.btnRequest.ImageIndex = 8;
            this.btnRequest.ImageList = this.ImageList;
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnJaeryo
            // 
            resources.ApplyResources(this.btnJaeryo, "btnJaeryo");
            this.btnJaeryo.ImageIndex = 7;
            this.btnJaeryo.ImageList = this.ImageList;
            this.btnJaeryo.Name = "btnJaeryo";
            this.btnJaeryo.Click += new System.EventHandler(this.btnJaeryo_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // fwkActor
            // 
            this.fwkActor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkActor.ExecuteQuery = null;
            this.fwkActor.FormText = "実施者照会";
            this.fwkActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkActor.ParamList")));
            this.fwkActor.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkActor.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "user_id";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "user_name";
            this.findColumnInfo4.ColWidth = 140;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "group_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "bunho2";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "in_out_gubun";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "acting_date";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "acting_buseo";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "fkocs_inv";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "fkocs_xrt";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "ord_danui_name";
            this.xEditGridCell32.CellWidth = 40;
            this.xEditGridCell32.Col = 4;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdCol = false;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "bunryu2";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "jaeryo_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "jaeryo_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "input_control";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "bun_code";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "act_doctor";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // defaultJearyo
            // 
            this.defaultJearyo.ExecuteQuery = null;
            this.defaultJearyo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.defaultJearyo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("defaultJearyo.ParamList")));
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "hangmog_code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "suryang";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "ord_danui";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "group_key";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "ment";
            // 
            // layPacsInfo
            // 
            this.layPacsInfo.ExecuteQuery = null;
            this.layPacsInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9});
            this.layPacsInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layPacsInfo.ParamList")));
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "code_name";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "code_value";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mlayConstantInfo
            // 
            this.mlayConstantInfo.ExecuteQuery = null;
            this.mlayConstantInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem6});
            this.mlayConstantInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayConstantInfo.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code_value";
            // 
            // mlayPart
            // 
            this.mlayPart.ExecuteQuery = null;
            this.mlayPart.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10});
            this.mlayPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayPart.ParamList")));
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "code";
            // 
            // OCSACT2
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.BackGroundColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "OCSACT2";
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCSACT_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel15.ResumeLayout(false);
            this.xPanel11.ResumeLayout(false);
            this.xPanel14.ResumeLayout(false);
            this.xPanel13.ResumeLayout(false);
            this.xPanel12.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPaInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).EndInit();
            this.tabSangByung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangByung)).EndInit();
            this.tabOrdRemark.ResumeLayout(false);
            this.tabPaComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paComment)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanelControl.ResumeLayout(false);
            this.xPanelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJaeryo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultJearyo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPacsInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayPart)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell95;
        private XEditGridCell xEditGridCell96;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell98;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell102;
        private Label label2;
        private XLabel xLabel3;
        private XEditGridCell xEditGridCell1;
        private PatientInfoBox patientInfoBox;
        private XPanel xPanelControl;
        private XPanel xPanel14;
        private XButton btnChange;
        private XDisplayBox dbxDocName;
        private XDisplayBox dbxDocCode;
        private XButton btnViewEMR;
        private XLabel xLabel17;
        private UCCPL2010U00 cpl2010U00;
        private UCINJ1001U01 inj1001U01;
        private XEditGrid grdOrder;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGrid grdJaeryo;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell42;
        private XEditGridCell xEditGridCell43;
        private XEditGridCell xEditGridCell44;
        private XEditGridCell xEditGridCell45;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell92;
        private XButton btnExpandOrdgrid;
    }
}
