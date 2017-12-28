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
using IHIS.CloudConnector.Contracts.Models.Ocs.Lib;

namespace IHIS.OCSO
{
    /// <summary>
    /// OCSACT에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class OCSACT : IHIS.Framework.XScreen
    {
        #region Auto-gen code

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
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private ToolTip toolTip;
        private XRadioButton rbxTodayOut;
        private XPanel xPanel9;
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
        private XPanel xPanel10;
        private XEditGrid grdOrder;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private Splitter splitter2;
        private XEditGrid grdJaeryo;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
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
        private XButton btnJaeryo;
        private XButton btnReSendIF;
        private XButton btnRequest;
        private XButton btnReserViewer;
        private Label lbSuname;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
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
        private XEditGridCell xEditGridCell70;
        private XRichTextBox txtOrderRemark;
        private XButton btnPacsViewer;
        private XButton btnReportViewer;
        private XButton btnEMR;
        private XPaComment paComment;
        private IHIS.X.Magic.Controls.TabPage tabPaComment;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XGrid grdSangByung;
        private XGridCell xGridCell1;
        private MultiLayout defaultJearyo;
        private XEditGridCell xEditGridCell73;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell82;
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
        private XEditGridCell xEditGridCell89;
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
        private XButton btnUseAlarmChk;
        private XButton btnUseTimeChk;
        private XLabel xLabel17;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XButton btnExpandOrdgrid;
        private MultiLayoutItem multiLayoutItem10;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell51;
        private XButton btnExpand;
        private XButton btnIfEkg;
        private XCheckBox cbxEkgIFYN;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XDisplayBox dbxDocName;
        private XDisplayBox dbxDocCode;
        private XButton btnChange;
        private IContainer components;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCSACT));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel10 = new IHIS.Framework.XPanel();
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
            this.dbxBunho = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.dbxSuname2 = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.dbxGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.dbxDoctorName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.txtOrderRemark = new IHIS.Framework.XRichTextBox();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.dbxBirth = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.dbxSexAge = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.dbxHeightWeight = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.dbxInOutGubunName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.dbxPaceMaker = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.dbxHodongHocode = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.dbxActLastDate = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.dbxUnusualInfo = new IHIS.Framework.XDisplayBox();
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
            this.btnExpandOrdgrid = new IHIS.Framework.XButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPaInfo = new IHIS.X.Magic.Controls.TabPage();
            this.btnChange = new IHIS.Framework.XButton();
            this.dbxDocName = new IHIS.Framework.XDisplayBox();
            this.dbxDocCode = new IHIS.Framework.XDisplayBox();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.btnIfEkg = new IHIS.Framework.XButton();
            this.cbxEkgIFYN = new IHIS.Framework.XCheckBox();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xPaInfoBox1 = new IHIS.Framework.XPaInfoBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.lbPaceMaker = new IHIS.Framework.XLabel();
            this.tabSangByung = new IHIS.X.Magic.Controls.TabPage();
            this.grdSangByung = new IHIS.Framework.XGrid();
            this.xGridCell1 = new IHIS.Framework.XGridCell();
            this.tabOrdRemark = new IHIS.X.Magic.Controls.TabPage();
            this.tabPaComment = new IHIS.X.Magic.Controls.TabPage();
            this.paComment = new IHIS.Framework.XPaComment();
            this.xPanel9 = new IHIS.Framework.XPanel();
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnExpand = new IHIS.Framework.XButton();
            this.grdPaList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.rbxNonAct = new IHIS.Framework.XRadioButton();
            this.rbxAct = new IHIS.Framework.XRadioButton();
            this.rbxActAll = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.lbSuname = new System.Windows.Forms.Label();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.cboSystem = new IHIS.Framework.XDictComboBox();
            this.lbPart = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbxTodayOut = new IHIS.Framework.XRadioButton();
            this.rbxOut = new IHIS.Framework.XRadioButton();
            this.rbxIOAll = new IHIS.Framework.XRadioButton();
            this.rbxInp = new IHIS.Framework.XRadioButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnReSendIF = new IHIS.Framework.XButton();
            this.btnReserViewer = new IHIS.Framework.XButton();
            this.btnPacsViewer = new IHIS.Framework.XButton();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
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
            this.xPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPaInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).BeginInit();
            this.tabSangByung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangByung)).BeginInit();
            this.tabOrdRemark.SuspendLayout();
            this.tabPaComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paComment)).BeginInit();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJaeryo)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel6.SuspendLayout();
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
            resources.ApplyResources(this.ImageList, "ImageList");
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
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            this.toolTip.SetToolTip(this.xPanel1, resources.GetString("xPanel1.ToolTip"));
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.xPanel10);
            this.xPanel5.Controls.Add(this.splitter2);
            this.xPanel5.Controls.Add(this.tabControl);
            this.xPanel5.Controls.Add(this.xPanel9);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            this.toolTip.SetToolTip(this.xPanel5, resources.GetString("xPanel5.ToolTip"));
            // 
            // xPanel10
            // 
            this.xPanel10.AccessibleDescription = null;
            this.xPanel10.AccessibleName = null;
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel10.BackgroundImage = null;
            this.xPanel10.Controls.Add(this.grdOrder);
            this.xPanel10.Controls.Add(this.btnExpandOrdgrid);
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Font = null;
            this.xPanel10.Name = "xPanel10";
            this.toolTip.SetToolTip(this.xPanel10, resources.GetString("xPanel10.ToolTip"));
            // 
            // grdOrder
            // 
            resources.ApplyResources(this.grdOrder, "grdOrder");
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
            this.toolTip.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
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
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellName = "in_out_gubun";
            this.xEditGridCell52.CellWidth = 35;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            this.xEditGridCell52.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "pkocs";
            this.xEditGridCell6.CellWidth = 36;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "act_yn";
            this.xEditGridCell7.CellWidth = 112;
            this.xEditGridCell7.Col = 14;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "hangmog_code";
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "hangmog_name";
            this.xEditGridCell18.CellWidth = 247;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellName = "jubsu_date";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell90.CellWidth = 208;
            this.xEditGridCell90.Col = 9;
            this.xEditGridCell90.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellName = "jubsu_time";
            this.xEditGridCell91.CellWidth = 37;
            this.xEditGridCell91.Col = 10;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.Mask = "##:##";
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "acting_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "acting_time";
            this.xEditGridCell9.CellWidth = 49;
            this.xEditGridCell9.Col = 12;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.Mask = "##:##";
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "order_date";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell10.CellWidth = 1;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "order_time";
            this.xEditGridCell19.CellWidth = 1;
            this.xEditGridCell19.Col = 4;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdCol = false;
            this.xEditGridCell19.Mask = "##:##";
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "reser_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.CellWidth = 123;
            this.xEditGridCell20.Col = 7;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "reser_time";
            this.xEditGridCell21.CellWidth = 45;
            this.xEditGridCell21.Col = 8;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.Mask = "##:##";
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellName = "act_doctor";
            this.xEditGridCell22.CellWidth = 92;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.CellName = "act_doctor_name";
            this.xEditGridCell70.CellWidth = 85;
            this.xEditGridCell70.Col = 13;
            this.xEditGridCell70.ExecuteQuery = null;
            this.xEditGridCell70.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell70.IsReadOnly = true;
            this.xEditGridCell70.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell70.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellName = "act_buseo";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "act_gwa";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell54.BindControl = this.dbxBunho;
            this.xEditGridCell54.CellName = "bunho";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            this.xEditGridCell54.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxBunho
            // 
            this.dbxBunho.AccessibleDescription = null;
            this.dbxBunho.AccessibleName = null;
            resources.ApplyResources(this.dbxBunho, "dbxBunho");
            this.dbxBunho.Image = null;
            this.dbxBunho.Name = "dbxBunho";
            this.toolTip.SetToolTip(this.dbxBunho, resources.GetString("dbxBunho.ToolTip"));
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell55.BindControl = this.dbxSuname;
            this.xEditGridCell55.CellName = "suname";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            this.xEditGridCell55.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxSuname
            // 
            this.dbxSuname.AccessibleDescription = null;
            this.dbxSuname.AccessibleName = null;
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Image = null;
            this.dbxSuname.Name = "dbxSuname";
            this.toolTip.SetToolTip(this.dbxSuname, resources.GetString("dbxSuname.ToolTip"));
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.BindControl = this.dbxSuname2;
            this.xEditGridCell56.CellName = "suname2";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            this.xEditGridCell56.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxSuname2
            // 
            this.dbxSuname2.AccessibleDescription = null;
            this.dbxSuname2.AccessibleName = null;
            resources.ApplyResources(this.dbxSuname2, "dbxSuname2");
            this.dbxSuname2.Image = null;
            this.dbxSuname2.Name = "dbxSuname2";
            this.toolTip.SetToolTip(this.dbxSuname2, resources.GetString("dbxSuname2.ToolTip"));
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell57.CellName = "gwa";
            this.xEditGridCell57.Col = -1;
            this.xEditGridCell57.ExecuteQuery = null;
            this.xEditGridCell57.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.IsVisible = false;
            this.xEditGridCell57.Row = -1;
            this.xEditGridCell57.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell58.BindControl = this.dbxGwaName;
            this.xEditGridCell58.CellName = "gwa_name";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            this.xEditGridCell58.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            this.xEditGridCell58.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxGwaName
            // 
            this.dbxGwaName.AccessibleDescription = null;
            this.dbxGwaName.AccessibleName = null;
            resources.ApplyResources(this.dbxGwaName, "dbxGwaName");
            this.dbxGwaName.Image = null;
            this.dbxGwaName.Name = "dbxGwaName";
            this.toolTip.SetToolTip(this.dbxGwaName, resources.GetString("dbxGwaName.ToolTip"));
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell59.CellName = "doctor";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            this.xEditGridCell59.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell60.BindControl = this.dbxDoctorName;
            this.xEditGridCell60.CellName = "doctor_name";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            this.xEditGridCell60.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxDoctorName
            // 
            this.dbxDoctorName.AccessibleDescription = null;
            this.dbxDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxDoctorName, "dbxDoctorName");
            this.dbxDoctorName.Image = null;
            this.dbxDoctorName.Name = "dbxDoctorName";
            this.toolTip.SetToolTip(this.dbxDoctorName, resources.GetString("dbxDoctorName.ToolTip"));
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
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
            this.xEditGridCell61.ReservedMemoFileName = "C:\\IHIS\\OCSA\\OCS.Lib.OCS0223Q01.dll";
            this.xEditGridCell61.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.ShowReservedMemoButton = true;
            this.xEditGridCell61.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOrderRemark
            // 
            this.txtOrderRemark.AccessibleDescription = null;
            this.txtOrderRemark.AccessibleName = null;
            resources.ApplyResources(this.txtOrderRemark, "txtOrderRemark");
            this.txtOrderRemark.BackgroundImage = null;
            this.txtOrderRemark.Name = "txtOrderRemark";
            this.txtOrderRemark.Protect = true;
            this.txtOrderRemark.ReadOnly = true;
            this.toolTip.SetToolTip(this.txtOrderRemark, resources.GetString("txtOrderRemark.ToolTip"));
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell62.BindControl = this.dbxBirth;
            this.xEditGridCell62.CellName = "birth";
            this.xEditGridCell62.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            this.xEditGridCell62.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            this.xEditGridCell62.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxBirth
            // 
            this.dbxBirth.AccessibleDescription = null;
            this.dbxBirth.AccessibleName = null;
            resources.ApplyResources(this.dbxBirth, "dbxBirth");
            this.dbxBirth.Image = null;
            this.dbxBirth.Name = "dbxBirth";
            this.toolTip.SetToolTip(this.dbxBirth, resources.GetString("dbxBirth.ToolTip"));
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell63.BindControl = this.dbxSexAge;
            this.xEditGridCell63.CellName = "sex_age";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            this.xEditGridCell63.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            this.xEditGridCell63.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxSexAge
            // 
            this.dbxSexAge.AccessibleDescription = null;
            this.dbxSexAge.AccessibleName = null;
            resources.ApplyResources(this.dbxSexAge, "dbxSexAge");
            this.dbxSexAge.Image = null;
            this.dbxSexAge.Name = "dbxSexAge";
            this.toolTip.SetToolTip(this.dbxSexAge, resources.GetString("dbxSexAge.ToolTip"));
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell64.BindControl = this.dbxHeightWeight;
            this.xEditGridCell64.CellName = "height_weight";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            this.xEditGridCell64.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxHeightWeight
            // 
            this.dbxHeightWeight.AccessibleDescription = null;
            this.dbxHeightWeight.AccessibleName = null;
            resources.ApplyResources(this.dbxHeightWeight, "dbxHeightWeight");
            this.dbxHeightWeight.Image = null;
            this.dbxHeightWeight.Name = "dbxHeightWeight";
            this.toolTip.SetToolTip(this.dbxHeightWeight, resources.GetString("dbxHeightWeight.ToolTip"));
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell65.BindControl = this.dbxInOutGubunName;
            this.xEditGridCell65.CellName = "in_out_gubun_name";
            this.xEditGridCell65.CellWidth = 102;
            this.xEditGridCell65.Col = 16;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxInOutGubunName
            // 
            this.dbxInOutGubunName.AccessibleDescription = null;
            this.dbxInOutGubunName.AccessibleName = null;
            resources.ApplyResources(this.dbxInOutGubunName, "dbxInOutGubunName");
            this.dbxInOutGubunName.Image = null;
            this.dbxInOutGubunName.Name = "dbxInOutGubunName";
            this.toolTip.SetToolTip(this.dbxInOutGubunName, resources.GetString("dbxInOutGubunName.ToolTip"));
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell66.BindControl = this.dbxPaceMaker;
            this.xEditGridCell66.CellName = "pace_maker_yn";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            this.xEditGridCell66.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxPaceMaker
            // 
            this.dbxPaceMaker.AccessibleDescription = null;
            this.dbxPaceMaker.AccessibleName = null;
            resources.ApplyResources(this.dbxPaceMaker, "dbxPaceMaker");
            this.dbxPaceMaker.Image = null;
            this.dbxPaceMaker.Name = "dbxPaceMaker";
            this.toolTip.SetToolTip(this.dbxPaceMaker, resources.GetString("dbxPaceMaker.ToolTip"));
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell67.BindControl = this.dbxHodongHocode;
            this.xEditGridCell67.CellName = "hodong_hocode";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            this.xEditGridCell67.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxHodongHocode
            // 
            this.dbxHodongHocode.AccessibleDescription = null;
            this.dbxHodongHocode.AccessibleName = null;
            resources.ApplyResources(this.dbxHodongHocode, "dbxHodongHocode");
            this.dbxHodongHocode.Image = null;
            this.dbxHodongHocode.Name = "dbxHodongHocode";
            this.toolTip.SetToolTip(this.dbxHodongHocode, resources.GetString("dbxHodongHocode.ToolTip"));
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell68.BindControl = this.dbxActLastDate;
            this.xEditGridCell68.CellName = "last_gumsa_date";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            this.xEditGridCell68.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxActLastDate
            // 
            this.dbxActLastDate.AccessibleDescription = null;
            this.dbxActLastDate.AccessibleName = null;
            resources.ApplyResources(this.dbxActLastDate, "dbxActLastDate");
            this.dbxActLastDate.Image = null;
            this.dbxActLastDate.Name = "dbxActLastDate";
            this.toolTip.SetToolTip(this.dbxActLastDate, resources.GetString("dbxActLastDate.ToolTip"));
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.BindControl = this.dbxUnusualInfo;
            this.xEditGridCell69.CellName = "unusual_info";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            this.xEditGridCell69.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxUnusualInfo
            // 
            this.dbxUnusualInfo.AccessibleDescription = null;
            this.dbxUnusualInfo.AccessibleName = null;
            resources.ApplyResources(this.dbxUnusualInfo, "dbxUnusualInfo");
            this.dbxUnusualInfo.Image = null;
            this.dbxUnusualInfo.Name = "dbxUnusualInfo";
            this.toolTip.SetToolTip(this.dbxUnusualInfo, resources.GetString("dbxUnusualInfo.ToolTip"));
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.CellName = "jundal_table";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            this.xEditGridCell71.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell72.CellName = "jundal_part";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            this.xEditGridCell72.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            this.xEditGridCell72.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell73.CellName = "fkout1001";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            this.xEditGridCell73.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            this.xEditGridCell73.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell74.CellName = "reser_yn";
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
            this.xEditGridCell75.CellName = "emergency";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            this.xEditGridCell75.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell84.CellName = "old_act_yn";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            this.xEditGridCell84.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsUpdCol = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            this.xEditGridCell84.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell82.CellName = "if_data_send_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            this.xEditGridCell82.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsReadOnly = true;
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsUpdCol = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            this.xEditGridCell82.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.CellName = "specific_comment";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsReadOnly = true;
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsUpdCol = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell83.CellName = "sort_fkocskey";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            this.xEditGridCell83.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellName = "input_control";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            this.xEditGridCell77.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell85.CellName = "bun_code";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            this.xEditGridCell85.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            this.xEditGridCell85.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.CellName = "suryang";
            this.xEditGridCell87.Col = 5;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell87.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellName = "nalsu";
            this.xEditGridCell88.CellWidth = 113;
            this.xEditGridCell88.Col = 6;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnExpandOrdgrid
            // 
            this.btnExpandOrdgrid.AccessibleDescription = null;
            this.btnExpandOrdgrid.AccessibleName = null;
            resources.ApplyResources(this.btnExpandOrdgrid, "btnExpandOrdgrid");
            this.btnExpandOrdgrid.BackgroundImage = null;
            this.btnExpandOrdgrid.ImageIndex = 3;
            this.btnExpandOrdgrid.ImageList = this.ImageList;
            this.btnExpandOrdgrid.Name = "btnExpandOrdgrid";
            this.btnExpandOrdgrid.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnExpandOrdgrid, resources.GetString("btnExpandOrdgrid.ToolTip"));
            this.btnExpandOrdgrid.Click += new System.EventHandler(this.btnExpandOrdgrid_Click);
            // 
            // splitter2
            // 
            this.splitter2.AccessibleDescription = null;
            this.splitter2.AccessibleName = null;
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.BackgroundImage = null;
            this.splitter2.Font = null;
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            this.toolTip.SetToolTip(this.splitter2, resources.GetString("splitter2.ToolTip"));
            // 
            // tabControl
            // 
            this.tabControl.AccessibleDescription = null;
            this.tabControl.AccessibleName = null;
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.BackgroundImage = null;
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
            this.toolTip.SetToolTip(this.tabControl, resources.GetString("tabControl.ToolTip"));
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // tabPaInfo
            // 
            this.tabPaInfo.AccessibleDescription = null;
            this.tabPaInfo.AccessibleName = null;
            resources.ApplyResources(this.tabPaInfo, "tabPaInfo");
            this.tabPaInfo.BackgroundImage = null;
            this.tabPaInfo.Controls.Add(this.btnChange);
            this.tabPaInfo.Controls.Add(this.dbxDocName);
            this.tabPaInfo.Controls.Add(this.dbxDocCode);
            this.tabPaInfo.Controls.Add(this.xLabel15);
            this.tabPaInfo.Controls.Add(this.btnIfEkg);
            this.tabPaInfo.Controls.Add(this.cbxEkgIFYN);
            this.tabPaInfo.Controls.Add(this.xLabel17);
            this.tabPaInfo.Controls.Add(this.dbxUnusualInfo);
            this.tabPaInfo.Controls.Add(this.dbxSexAge);
            this.tabPaInfo.Controls.Add(this.xLabel5);
            this.tabPaInfo.Controls.Add(this.dbxGwaName);
            this.tabPaInfo.Controls.Add(this.xLabel14);
            this.tabPaInfo.Controls.Add(this.dbxDoctorName);
            this.tabPaInfo.Controls.Add(this.xLabel13);
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
            this.tabPaInfo.Controls.Add(this.dbxPaceMaker);
            this.tabPaInfo.Font = null;
            this.tabPaInfo.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tabPaInfo.ImageIndex = 4;
            this.tabPaInfo.ImageList = this.ImageList;
            this.tabPaInfo.Name = "tabPaInfo";
            this.tabPaInfo.TitleTextColor = System.Drawing.Color.Maroon;
            this.toolTip.SetToolTip(this.tabPaInfo, resources.GetString("tabPaInfo.ToolTip"));
            // 
            // btnChange
            // 
            this.btnChange.AccessibleDescription = null;
            this.btnChange.AccessibleName = null;
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.BackgroundImage = null;
            this.btnChange.Name = "btnChange";
            this.toolTip.SetToolTip(this.btnChange, resources.GetString("btnChange.ToolTip"));
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dbxDocName
            // 
            this.dbxDocName.AccessibleDescription = null;
            this.dbxDocName.AccessibleName = null;
            resources.ApplyResources(this.dbxDocName, "dbxDocName");
            this.dbxDocName.Image = null;
            this.dbxDocName.Name = "dbxDocName";
            this.toolTip.SetToolTip(this.dbxDocName, resources.GetString("dbxDocName.ToolTip"));
            // 
            // dbxDocCode
            // 
            this.dbxDocCode.AccessibleDescription = null;
            this.dbxDocCode.AccessibleName = null;
            resources.ApplyResources(this.dbxDocCode, "dbxDocCode");
            this.dbxDocCode.Image = null;
            this.dbxDocCode.Name = "dbxDocCode";
            this.toolTip.SetToolTip(this.dbxDocCode, resources.GetString("dbxDocCode.ToolTip"));
            // 
            // xLabel15
            // 
            this.xLabel15.AccessibleDescription = null;
            this.xLabel15.AccessibleName = null;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel15.Image = null;
            this.xLabel15.Name = "xLabel15";
            this.toolTip.SetToolTip(this.xLabel15, resources.GetString("xLabel15.ToolTip"));
            // 
            // btnIfEkg
            // 
            this.btnIfEkg.AccessibleDescription = null;
            this.btnIfEkg.AccessibleName = null;
            resources.ApplyResources(this.btnIfEkg, "btnIfEkg");
            this.btnIfEkg.BackgroundImage = null;
            this.btnIfEkg.ImageIndex = 9;
            this.btnIfEkg.ImageList = this.ImageList;
            this.btnIfEkg.Name = "btnIfEkg";
            this.toolTip.SetToolTip(this.btnIfEkg, resources.GetString("btnIfEkg.ToolTip"));
            this.btnIfEkg.Click += new System.EventHandler(this.btnIfEkg_Click);
            // 
            // cbxEkgIFYN
            // 
            this.cbxEkgIFYN.AccessibleDescription = null;
            this.cbxEkgIFYN.AccessibleName = null;
            resources.ApplyResources(this.cbxEkgIFYN, "cbxEkgIFYN");
            this.cbxEkgIFYN.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.cbxEkgIFYN.BackgroundImage = null;
            this.cbxEkgIFYN.CheckedText = global::IHIS.OCSO.Properties.Resources.cbxEkgIFON;
            this.cbxEkgIFYN.Name = "cbxEkgIFYN";
            this.toolTip.SetToolTip(this.cbxEkgIFYN, resources.GetString("cbxEkgIFYN.ToolTip"));
            this.cbxEkgIFYN.UnCheckedText = global::IHIS.OCSO.Properties.Resources.cbxEkgIFOFF;
            this.cbxEkgIFYN.UseVisualStyleBackColor = false;
            // 
            // xLabel17
            // 
            this.xLabel17.AccessibleDescription = null;
            this.xLabel17.AccessibleName = null;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel17.Image = null;
            this.xLabel17.Name = "xLabel17";
            this.toolTip.SetToolTip(this.xLabel17, resources.GetString("xLabel17.ToolTip"));
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            this.toolTip.SetToolTip(this.xLabel5, resources.GetString("xLabel5.ToolTip"));
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            this.toolTip.SetToolTip(this.xLabel14, resources.GetString("xLabel14.ToolTip"));
            // 
            // xLabel13
            // 
            this.xLabel13.AccessibleDescription = null;
            this.xLabel13.AccessibleName = null;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel13.Image = null;
            this.xLabel13.Name = "xLabel13";
            this.toolTip.SetToolTip(this.xLabel13, resources.GetString("xLabel13.ToolTip"));
            // 
            // xPaInfoBox1
            // 
            this.xPaInfoBox1.AccessibleDescription = null;
            this.xPaInfoBox1.AccessibleName = null;
            resources.ApplyResources(this.xPaInfoBox1, "xPaInfoBox1");
            this.xPaInfoBox1.BackgroundImage = null;
            this.xPaInfoBox1.Font = null;
            this.xPaInfoBox1.Name = "xPaInfoBox1";
            this.toolTip.SetToolTip(this.xPaInfoBox1, resources.GetString("xPaInfoBox1.ToolTip"));
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            this.toolTip.SetToolTip(this.xLabel7, resources.GetString("xLabel7.ToolTip"));
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            this.toolTip.SetToolTip(this.xLabel6, resources.GetString("xLabel6.ToolTip"));
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            this.toolTip.SetToolTip(this.xLabel4, resources.GetString("xLabel4.ToolTip"));
            // 
            // xLabel11
            // 
            this.xLabel11.AccessibleDescription = null;
            this.xLabel11.AccessibleName = null;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel11.Image = null;
            this.xLabel11.Name = "xLabel11";
            this.toolTip.SetToolTip(this.xLabel11, resources.GetString("xLabel11.ToolTip"));
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            this.toolTip.SetToolTip(this.xLabel8, resources.GetString("xLabel8.ToolTip"));
            // 
            // xLabel10
            // 
            this.xLabel10.AccessibleDescription = null;
            this.xLabel10.AccessibleName = null;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel10.Image = null;
            this.xLabel10.Name = "xLabel10";
            this.toolTip.SetToolTip(this.xLabel10, resources.GetString("xLabel10.ToolTip"));
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            this.toolTip.SetToolTip(this.xLabel9, resources.GetString("xLabel9.ToolTip"));
            // 
            // lbPaceMaker
            // 
            this.lbPaceMaker.AccessibleDescription = null;
            this.lbPaceMaker.AccessibleName = null;
            resources.ApplyResources(this.lbPaceMaker, "lbPaceMaker");
            this.lbPaceMaker.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.lbPaceMaker.ImageList = this.ImageList;
            this.lbPaceMaker.Name = "lbPaceMaker";
            this.toolTip.SetToolTip(this.lbPaceMaker, resources.GetString("lbPaceMaker.ToolTip"));
            // 
            // tabSangByung
            // 
            this.tabSangByung.AccessibleDescription = null;
            this.tabSangByung.AccessibleName = null;
            resources.ApplyResources(this.tabSangByung, "tabSangByung");
            this.tabSangByung.BackgroundImage = null;
            this.tabSangByung.Controls.Add(this.grdSangByung);
            this.tabSangByung.Font = null;
            this.tabSangByung.ImageIndex = 5;
            this.tabSangByung.ImageList = this.ImageList;
            this.tabSangByung.Name = "tabSangByung";
            this.tabSangByung.Selected = false;
            this.toolTip.SetToolTip(this.tabSangByung, resources.GetString("tabSangByung.ToolTip"));
            // 
            // grdSangByung
            // 
            resources.ApplyResources(this.grdSangByung, "grdSangByung");
            this.grdSangByung.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xGridCell1});
            this.grdSangByung.ColPerLine = 1;
            this.grdSangByung.Cols = 2;
            this.grdSangByung.ExecuteQuery = null;
            this.grdSangByung.FixedCols = 1;
            this.grdSangByung.FixedRows = 1;
            this.grdSangByung.HeaderHeights.Add(0);
            this.grdSangByung.Name = "grdSangByung";
            this.grdSangByung.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangByung.ParamList")));
            this.grdSangByung.QuerySQL = resources.GetString("grdSangByung.QuerySQL");
            this.grdSangByung.RowHeaderVisible = true;
            this.grdSangByung.Rows = 2;
            this.toolTip.SetToolTip(this.grdSangByung, resources.GetString("grdSangByung.ToolTip"));
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
            this.tabOrdRemark.AccessibleDescription = null;
            this.tabOrdRemark.AccessibleName = null;
            resources.ApplyResources(this.tabOrdRemark, "tabOrdRemark");
            this.tabOrdRemark.BackgroundImage = null;
            this.tabOrdRemark.Controls.Add(this.txtOrderRemark);
            this.tabOrdRemark.Font = null;
            this.tabOrdRemark.ImageIndex = 6;
            this.tabOrdRemark.ImageList = this.ImageList;
            this.tabOrdRemark.Name = "tabOrdRemark";
            this.tabOrdRemark.Selected = false;
            this.toolTip.SetToolTip(this.tabOrdRemark, resources.GetString("tabOrdRemark.ToolTip"));
            // 
            // tabPaComment
            // 
            this.tabPaComment.AccessibleDescription = null;
            this.tabPaComment.AccessibleName = null;
            resources.ApplyResources(this.tabPaComment, "tabPaComment");
            this.tabPaComment.BackgroundImage = null;
            this.tabPaComment.Controls.Add(this.paComment);
            this.tabPaComment.Font = null;
            this.tabPaComment.ImageIndex = 15;
            this.tabPaComment.ImageList = this.ImageList;
            this.tabPaComment.Name = "tabPaComment";
            this.tabPaComment.Selected = false;
            this.tabPaComment.Tag = "paCmmt";
            this.toolTip.SetToolTip(this.tabPaComment, resources.GetString("tabPaComment.ToolTip"));
            // 
            // paComment
            // 
            this.paComment.AccessibleDescription = null;
            this.paComment.AccessibleName = null;
            resources.ApplyResources(this.paComment, "paComment");
            this.paComment.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.paComment.BackgroundImage = null;
            this.paComment.Name = "paComment";
            this.toolTip.SetToolTip(this.paComment, resources.GetString("paComment.ToolTip"));
            // 
            // xPanel9
            // 
            this.xPanel9.AccessibleDescription = null;
            this.xPanel9.AccessibleName = null;
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel9.BackgroundImage = null;
            this.xPanel9.Controls.Add(this.grdJaeryo);
            this.xPanel9.DrawBorder = true;
            this.xPanel9.Font = null;
            this.xPanel9.Name = "xPanel9";
            this.toolTip.SetToolTip(this.xPanel9, resources.GetString("xPanel9.ToolTip"));
            // 
            // grdJaeryo
            // 
            resources.ApplyResources(this.grdJaeryo, "grdJaeryo");
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
            this.toolTip.SetToolTip(this.grdJaeryo, resources.GetString("grdJaeryo.ToolTip"));
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
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 116;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "hangmog_name";
            this.xEditGridCell12.CellWidth = 488;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "suryang";
            this.xEditGridCell13.CellWidth = 105;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "ord_danui";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "pkinv1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellName = "bunho";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "order_date";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell40.CellName = "in_out_gubun";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            this.xEditGridCell40.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            this.xEditGridCell40.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell41.CellName = "acting_date";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            this.xEditGridCell41.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            this.xEditGridCell41.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell42.CellName = "acting_buseo";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            this.xEditGridCell42.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            this.xEditGridCell42.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell43.CellName = "fkocs_inv";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            this.xEditGridCell43.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            this.xEditGridCell43.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell44.CellName = "fkocs_xrt";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            this.xEditGridCell44.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            this.xEditGridCell44.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell45.CellName = "ord_danui_name";
            this.xEditGridCell45.CellWidth = 98;
            this.xEditGridCell45.Col = 4;
            this.xEditGridCell45.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell45.ExecuteQuery = null;
            this.xEditGridCell45.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdCol = false;
            this.xEditGridCell45.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell46.CellName = "bunryu2";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            this.xEditGridCell46.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdCol = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            this.xEditGridCell46.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell47.CellName = "jaeryo_gubun";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            this.xEditGridCell47.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdCol = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            this.xEditGridCell47.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell48.CellName = "jaeryo_yn";
            this.xEditGridCell48.Col = -1;
            this.xEditGridCell48.ExecuteQuery = null;
            this.xEditGridCell48.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdCol = false;
            this.xEditGridCell48.IsVisible = false;
            this.xEditGridCell48.Row = -1;
            this.xEditGridCell48.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell49.CellName = "input_control";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            this.xEditGridCell49.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdCol = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            this.xEditGridCell49.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell50.CellName = "bun_code";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            this.xEditGridCell50.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdCol = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            this.xEditGridCell50.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell51.CellName = "nalsu";
            this.xEditGridCell51.CellWidth = 64;
            this.xEditGridCell51.Col = 5;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "pkocs";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsReadOnly = true;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.toolTip.SetToolTip(this.splitter1, resources.GetString("splitter1.ToolTip"));
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.btnExpand);
            this.xPanel4.Controls.Add(this.grdPaList);
            this.xPanel4.Controls.Add(this.xPanel7);
            this.xPanel4.Controls.Add(this.xPanel2);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            this.toolTip.SetToolTip(this.xPanel4, resources.GetString("xPanel4.ToolTip"));
            // 
            // btnExpand
            // 
            this.btnExpand.AccessibleDescription = null;
            this.btnExpand.AccessibleName = null;
            resources.ApplyResources(this.btnExpand, "btnExpand");
            this.btnExpand.BackgroundImage = null;
            this.btnExpand.ImageIndex = 3;
            this.btnExpand.ImageList = this.ImageList;
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.toolTip.SetToolTip(this.btnExpand, resources.GetString("btnExpand.ToolTip"));
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // grdPaList
            // 
            resources.ApplyResources(this.grdPaList, "grdPaList");
            this.grdPaList.ApplyAutoHeight = true;
            this.grdPaList.ApplyPaintEventToAllColumn = true;
            this.grdPaList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell86,
            this.xEditGridCell2,
            this.xEditGridCell76,
            this.xEditGridCell93});
            this.grdPaList.ColPerLine = 7;
            this.grdPaList.ColResizable = true;
            this.grdPaList.Cols = 8;
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
            this.grdPaList.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdPaList.SelectionModeChangeable = true;
            this.toolTip.SetToolTip(this.grdPaList, resources.GetString("grdPaList.ToolTip"));
            this.grdPaList.ToolTipActive = true;
            this.grdPaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaList_QueryEnd);
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grd_RowFocusChanged);
            this.grdPaList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaList_GridCellPainting);
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "in_out_gubun";
            this.xEditGridCell1.CellWidth = 124;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 93;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 102;
            this.xEditGridCell4.Col = 2;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "suname2";
            this.xEditGridCell5.CellWidth = 135;
            this.xEditGridCell5.Col = 7;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell78.CellName = "gwa";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            this.xEditGridCell78.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell79.CellName = "gwa_name";
            this.xEditGridCell79.CellWidth = 1;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.CellName = "doctor";
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell81.CellName = "doctor_name";
            this.xEditGridCell81.CellWidth = 95;
            this.xEditGridCell81.Col = 5;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell86.CellName = "jundal_table";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            this.xEditGridCell86.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            this.xEditGridCell86.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "reser_yn";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellName = "emergency";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellName = "trial";
            this.xEditGridCell93.CellWidth = 132;
            this.xEditGridCell93.Col = 6;
            this.xEditGridCell93.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.rbxNonAct);
            this.xPanel7.Controls.Add(this.rbxAct);
            this.xPanel7.Controls.Add(this.rbxActAll);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            this.toolTip.SetToolTip(this.xPanel7, resources.GetString("xPanel7.ToolTip"));
            // 
            // rbxNonAct
            // 
            this.rbxNonAct.AccessibleDescription = null;
            this.rbxNonAct.AccessibleName = null;
            resources.ApplyResources(this.rbxNonAct, "rbxNonAct");
            this.rbxNonAct.BackColor = IHIS.Framework.XColor.DockingGradientEndColor;
            this.rbxNonAct.BackgroundImage = null;
            this.rbxNonAct.Checked = true;
            this.rbxNonAct.ImageList = this.ImageList;
            this.rbxNonAct.Name = "rbxNonAct";
            this.rbxNonAct.TabStop = true;
            this.toolTip.SetToolTip(this.rbxNonAct, resources.GetString("rbxNonAct.ToolTip"));
            this.rbxNonAct.UseVisualStyleBackColor = false;
            // 
            // rbxAct
            // 
            this.rbxAct.AccessibleDescription = null;
            this.rbxAct.AccessibleName = null;
            resources.ApplyResources(this.rbxAct, "rbxAct");
            this.rbxAct.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxAct.BackgroundImage = null;
            this.rbxAct.ImageList = this.ImageList;
            this.rbxAct.Name = "rbxAct";
            this.toolTip.SetToolTip(this.rbxAct, resources.GetString("rbxAct.ToolTip"));
            this.rbxAct.UseVisualStyleBackColor = false;
            // 
            // rbxActAll
            // 
            this.rbxActAll.AccessibleDescription = null;
            this.rbxActAll.AccessibleName = null;
            resources.ApplyResources(this.rbxActAll, "rbxActAll");
            this.rbxActAll.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxActAll.BackgroundImage = null;
            this.rbxActAll.ImageList = this.ImageList;
            this.rbxActAll.Name = "rbxActAll";
            this.toolTip.SetToolTip(this.rbxActAll, resources.GetString("rbxActAll.ToolTip"));
            this.rbxActAll.UseVisualStyleBackColor = false;
            this.rbxActAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.xPanel8);
            this.xPanel2.Controls.Add(this.xPanel6);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            this.toolTip.SetToolTip(this.xPanel2, resources.GetString("xPanel2.ToolTip"));
            // 
            // xPanel8
            // 
            this.xPanel8.AccessibleDescription = null;
            this.xPanel8.AccessibleName = null;
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.xPanel8.BackgroundImage = null;
            this.xPanel8.Controls.Add(this.cboTime);
            this.xPanel8.Controls.Add(this.txtTimeInterval);
            this.xPanel8.Controls.Add(this.tbxTimer);
            this.xPanel8.Controls.Add(this.xLabel12);
            this.xPanel8.Controls.Add(this.lbTime);
            this.xPanel8.Controls.Add(this.lbSuname);
            this.xPanel8.Controls.Add(this.xLabel2);
            this.xPanel8.Controls.Add(this.dtpToDate);
            this.xPanel8.Controls.Add(this.dtpFromDate);
            this.xPanel8.Controls.Add(this.xLabel1);
            this.xPanel8.Controls.Add(this.cboPart);
            this.xPanel8.Controls.Add(this.cboSystem);
            this.xPanel8.Controls.Add(this.lbPart);
            this.xPanel8.Controls.Add(this.paBox);
            this.xPanel8.Controls.Add(this.label1);
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = null;
            this.xPanel8.Name = "xPanel8";
            this.toolTip.SetToolTip(this.xPanel8, resources.GetString("xPanel8.ToolTip"));
            // 
            // cboTime
            // 
            this.cboTime.AccessibleDescription = null;
            this.cboTime.AccessibleName = null;
            resources.ApplyResources(this.cboTime, "cboTime");
            this.cboTime.BackgroundImage = null;
            this.cboTime.ExecuteQuery = null;
            this.cboTime.Name = "cboTime";
            this.cboTime.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboTime.ParamList")));
            this.cboTime.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboTime, resources.GetString("cboTime.ToolTip"));
            this.cboTime.SelectionChangeCommitted += new System.EventHandler(this.cboTime_SelectionChangeCommitted);
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.AccessibleDescription = null;
            this.txtTimeInterval.AccessibleName = null;
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.BackgroundImage = null;
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.toolTip.SetToolTip(this.txtTimeInterval, resources.GetString("txtTimeInterval.ToolTip"));
            this.txtTimeInterval.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtTimeInterval_DataValidating);
            // 
            // tbxTimer
            // 
            this.tbxTimer.AccessibleDescription = null;
            this.tbxTimer.AccessibleName = null;
            resources.ApplyResources(this.tbxTimer, "tbxTimer");
            this.tbxTimer.BackgroundImage = null;
            this.tbxTimer.Name = "tbxTimer";
            this.toolTip.SetToolTip(this.tbxTimer, resources.GetString("tbxTimer.ToolTip"));
            // 
            // xLabel12
            // 
            this.xLabel12.AccessibleDescription = null;
            this.xLabel12.AccessibleName = null;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.xLabel12.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel12.Image = null;
            this.xLabel12.Name = "xLabel12";
            this.toolTip.SetToolTip(this.xLabel12, resources.GetString("xLabel12.ToolTip"));
            // 
            // lbTime
            // 
            this.lbTime.AccessibleDescription = null;
            this.lbTime.AccessibleName = null;
            resources.ApplyResources(this.lbTime, "lbTime");
            this.lbTime.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lbTime.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbTime.ForeColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.lbTime.Image = null;
            this.lbTime.Name = "lbTime";
            this.toolTip.SetToolTip(this.lbTime, resources.GetString("lbTime.ToolTip"));
            // 
            // lbSuname
            // 
            this.lbSuname.AccessibleDescription = null;
            this.lbSuname.AccessibleName = null;
            resources.ApplyResources(this.lbSuname, "lbSuname");
            this.lbSuname.Font = null;
            this.lbSuname.Name = "lbSuname";
            this.toolTip.SetToolTip(this.lbSuname, resources.GetString("lbSuname.ToolTip"));
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            this.toolTip.SetToolTip(this.xLabel2, resources.GetString("xLabel2.ToolTip"));
            // 
            // dtpToDate
            // 
            this.dtpToDate.AccessibleDescription = null;
            this.dtpToDate.AccessibleName = null;
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.BackgroundImage = null;
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.toolTip.SetToolTip(this.dtpToDate, resources.GetString("dtpToDate.ToolTip"));
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AccessibleDescription = null;
            this.dtpFromDate.AccessibleName = null;
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.BackgroundImage = null;
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.toolTip.SetToolTip(this.dtpFromDate, resources.GetString("dtpFromDate.ToolTip"));
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            this.toolTip.SetToolTip(this.xLabel1, resources.GetString("xLabel1.ToolTip"));
            // 
            // cboPart
            // 
            this.cboPart.AccessibleDescription = null;
            this.cboPart.AccessibleName = null;
            resources.ApplyResources(this.cboPart, "cboPart");
            this.cboPart.BackgroundImage = null;
            this.cboPart.ExecuteQuery = null;
            this.cboPart.Name = "cboPart";
            this.cboPart.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPart.ParamList")));
            this.cboPart.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cboPart, resources.GetString("cboPart.ToolTip"));
            this.cboPart.SelectionChangeCommitted += new System.EventHandler(this.cboPart_SelectedIndexChanged);
            // 
            // cboSystem
            // 
            this.cboSystem.AccessibleDescription = null;
            this.cboSystem.AccessibleName = null;
            resources.ApplyResources(this.cboSystem, "cboSystem");
            this.cboSystem.BackgroundImage = null;
            this.cboSystem.ExecuteQuery = null;
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboSystem.ParamList")));
            this.cboSystem.Protect = true;
            this.cboSystem.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboSystem.TabStop = false;
            this.toolTip.SetToolTip(this.cboSystem, resources.GetString("cboSystem.ToolTip"));
            this.cboSystem.SelectedIndexChanged += new System.EventHandler(this.cboSystem_SelectedIndexChanged);
            // 
            // lbPart
            // 
            this.lbPart.AccessibleDescription = null;
            this.lbPart.AccessibleName = null;
            resources.ApplyResources(this.lbPart, "lbPart");
            this.lbPart.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.lbPart.Image = null;
            this.lbPart.Name = "lbPart";
            this.toolTip.SetToolTip(this.lbPart, resources.GetString("lbPart.ToolTip"));
            // 
            // paBox
            // 
            this.paBox.AccessibleDescription = null;
            this.paBox.AccessibleName = null;
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(235)))), ((int)(((byte)(249))))));
            this.paBox.BackgroundImage = null;
            this.paBox.Name = "paBox";
            this.toolTip.SetToolTip(this.paBox, resources.GetString("paBox.ToolTip"));
            this.paBox.Validated += new System.EventHandler(this.paBox_Validated);
            // 
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.rbxTodayOut);
            this.xPanel6.Controls.Add(this.rbxOut);
            this.xPanel6.Controls.Add(this.rbxIOAll);
            this.xPanel6.Controls.Add(this.rbxInp);
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
            this.toolTip.SetToolTip(this.xPanel6, resources.GetString("xPanel6.ToolTip"));
            // 
            // rbxTodayOut
            // 
            this.rbxTodayOut.AccessibleDescription = null;
            this.rbxTodayOut.AccessibleName = null;
            resources.ApplyResources(this.rbxTodayOut, "rbxTodayOut");
            this.rbxTodayOut.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxTodayOut.BackgroundImage = null;
            this.rbxTodayOut.ImageList = this.ImageList;
            this.rbxTodayOut.Name = "rbxTodayOut";
            this.toolTip.SetToolTip(this.rbxTodayOut, resources.GetString("rbxTodayOut.ToolTip"));
            this.rbxTodayOut.UseVisualStyleBackColor = false;
            // 
            // rbxOut
            // 
            this.rbxOut.AccessibleDescription = null;
            this.rbxOut.AccessibleName = null;
            resources.ApplyResources(this.rbxOut, "rbxOut");
            this.rbxOut.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxOut.BackgroundImage = null;
            this.rbxOut.ImageList = this.ImageList;
            this.rbxOut.Name = "rbxOut";
            this.toolTip.SetToolTip(this.rbxOut, resources.GetString("rbxOut.ToolTip"));
            this.rbxOut.UseVisualStyleBackColor = false;
            // 
            // rbxIOAll
            // 
            this.rbxIOAll.AccessibleDescription = null;
            this.rbxIOAll.AccessibleName = null;
            resources.ApplyResources(this.rbxIOAll, "rbxIOAll");
            this.rbxIOAll.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxIOAll.BackgroundImage = null;
            this.rbxIOAll.Checked = true;
            this.rbxIOAll.ImageList = this.ImageList;
            this.rbxIOAll.Name = "rbxIOAll";
            this.rbxIOAll.TabStop = true;
            this.toolTip.SetToolTip(this.rbxIOAll, resources.GetString("rbxIOAll.ToolTip"));
            this.rbxIOAll.UseVisualStyleBackColor = false;
            this.rbxIOAll.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            // 
            // rbxInp
            // 
            this.rbxInp.AccessibleDescription = null;
            this.rbxInp.AccessibleName = null;
            resources.ApplyResources(this.rbxInp, "rbxInp");
            this.rbxInp.BackColor = IHIS.Framework.XColor.XMatrixRowHeaderBackColor;
            this.rbxInp.BackgroundImage = null;
            this.rbxInp.ImageList = this.ImageList;
            this.rbxInp.Name = "rbxInp";
            this.toolTip.SetToolTip(this.rbxInp, resources.GetString("rbxInp.ToolTip"));
            this.rbxInp.UseVisualStyleBackColor = false;
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnReSendIF);
            this.xPanel3.Controls.Add(this.btnReserViewer);
            this.xPanel3.Controls.Add(this.btnPacsViewer);
            this.xPanel3.Controls.Add(this.btnUseAlarmChk);
            this.xPanel3.Controls.Add(this.btnUseTimeChk);
            this.xPanel3.Controls.Add(this.btnEMR);
            this.xPanel3.Controls.Add(this.btnReportViewer);
            this.xPanel3.Controls.Add(this.btnRequest);
            this.xPanel3.Controls.Add(this.btnJaeryo);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
            // 
            // btnReSendIF
            // 
            this.btnReSendIF.AccessibleDescription = null;
            this.btnReSendIF.AccessibleName = null;
            resources.ApplyResources(this.btnReSendIF, "btnReSendIF");
            this.btnReSendIF.BackgroundImage = null;
            this.btnReSendIF.ImageIndex = 9;
            this.btnReSendIF.ImageList = this.ImageList;
            this.btnReSendIF.Name = "btnReSendIF";
            this.toolTip.SetToolTip(this.btnReSendIF, resources.GetString("btnReSendIF.ToolTip"));
            this.btnReSendIF.Click += new System.EventHandler(this.btnReSendIF_Click);
            // 
            // btnReserViewer
            // 
            this.btnReserViewer.AccessibleDescription = null;
            this.btnReserViewer.AccessibleName = null;
            resources.ApplyResources(this.btnReserViewer, "btnReserViewer");
            this.btnReserViewer.BackgroundImage = null;
            this.btnReserViewer.ImageIndex = 10;
            this.btnReserViewer.ImageList = this.ImageList;
            this.btnReserViewer.Name = "btnReserViewer";
            this.toolTip.SetToolTip(this.btnReserViewer, resources.GetString("btnReserViewer.ToolTip"));
            this.btnReserViewer.Click += new System.EventHandler(this.btnReserViewer_Click);
            // 
            // btnPacsViewer
            // 
            this.btnPacsViewer.AccessibleDescription = null;
            this.btnPacsViewer.AccessibleName = null;
            resources.ApplyResources(this.btnPacsViewer, "btnPacsViewer");
            this.btnPacsViewer.BackgroundImage = null;
            this.btnPacsViewer.ImageIndex = 11;
            this.btnPacsViewer.ImageList = this.ImageList;
            this.btnPacsViewer.Name = "btnPacsViewer";
            this.toolTip.SetToolTip(this.btnPacsViewer, resources.GetString("btnPacsViewer.ToolTip"));
            // 
            // btnUseAlarmChk
            // 
            this.btnUseAlarmChk.AccessibleDescription = null;
            this.btnUseAlarmChk.AccessibleName = null;
            resources.ApplyResources(this.btnUseAlarmChk, "btnUseAlarmChk");
            this.btnUseAlarmChk.BackgroundImage = null;
            this.btnUseAlarmChk.ImageIndex = 0;
            this.btnUseAlarmChk.ImageList = this.ImageList;
            this.btnUseAlarmChk.Name = "btnUseAlarmChk";
            this.toolTip.SetToolTip(this.btnUseAlarmChk, resources.GetString("btnUseAlarmChk.ToolTip"));
            this.btnUseAlarmChk.Click += new System.EventHandler(this.btnUseAlarmChk_Click);
            // 
            // btnUseTimeChk
            // 
            this.btnUseTimeChk.AccessibleDescription = null;
            this.btnUseTimeChk.AccessibleName = null;
            resources.ApplyResources(this.btnUseTimeChk, "btnUseTimeChk");
            this.btnUseTimeChk.BackgroundImage = null;
            this.btnUseTimeChk.ImageIndex = 0;
            this.btnUseTimeChk.ImageList = this.ImageList;
            this.btnUseTimeChk.Name = "btnUseTimeChk";
            this.toolTip.SetToolTip(this.btnUseTimeChk, resources.GetString("btnUseTimeChk.ToolTip"));
            this.btnUseTimeChk.Click += new System.EventHandler(this.btnUseTimeChk_Click);
            // 
            // btnEMR
            // 
            this.btnEMR.AccessibleDescription = null;
            this.btnEMR.AccessibleName = null;
            resources.ApplyResources(this.btnEMR, "btnEMR");
            this.btnEMR.BackgroundImage = null;
            this.btnEMR.ImageIndex = 13;
            this.btnEMR.ImageList = this.ImageList;
            this.btnEMR.Name = "btnEMR";
            this.toolTip.SetToolTip(this.btnEMR, resources.GetString("btnEMR.ToolTip"));
            this.btnEMR.Click += new System.EventHandler(this.btnEMR_Click);
            // 
            // btnReportViewer
            // 
            this.btnReportViewer.AccessibleDescription = null;
            this.btnReportViewer.AccessibleName = null;
            resources.ApplyResources(this.btnReportViewer, "btnReportViewer");
            this.btnReportViewer.BackgroundImage = null;
            this.btnReportViewer.ImageIndex = 12;
            this.btnReportViewer.ImageList = this.ImageList;
            this.btnReportViewer.Name = "btnReportViewer";
            this.toolTip.SetToolTip(this.btnReportViewer, resources.GetString("btnReportViewer.ToolTip"));
            this.btnReportViewer.Click += new System.EventHandler(this.btnReportViewer_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.AccessibleDescription = null;
            this.btnRequest.AccessibleName = null;
            resources.ApplyResources(this.btnRequest, "btnRequest");
            this.btnRequest.BackgroundImage = null;
            this.btnRequest.ImageIndex = 8;
            this.btnRequest.ImageList = this.ImageList;
            this.btnRequest.Name = "btnRequest";
            this.toolTip.SetToolTip(this.btnRequest, resources.GetString("btnRequest.ToolTip"));
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnJaeryo
            // 
            this.btnJaeryo.AccessibleDescription = null;
            this.btnJaeryo.AccessibleName = null;
            resources.ApplyResources(this.btnJaeryo, "btnJaeryo");
            this.btnJaeryo.BackgroundImage = null;
            this.btnJaeryo.ImageIndex = 7;
            this.btnJaeryo.ImageList = this.ImageList;
            this.btnJaeryo.Name = "btnJaeryo";
            this.toolTip.SetToolTip(this.btnJaeryo, resources.GetString("btnJaeryo.ToolTip"));
            this.btnJaeryo.Click += new System.EventHandler(this.btnJaeryo_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
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
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "group_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellName = "bunho2";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "in_out_gubun";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellName = "acting_date";
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellName = "acting_buseo";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellName = "fkocs_inv";
            this.xEditGridCell30.Col = -1;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellName = "fkocs_xrt";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellName = "ord_danui_name";
            this.xEditGridCell32.CellWidth = 40;
            this.xEditGridCell32.Col = 4;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdCol = false;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.CellName = "bunryu2";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdCol = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell34.CellName = "jaeryo_gubun";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsUpdCol = false;
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            this.xEditGridCell34.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "jaeryo_yn";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsUpdCol = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "input_control";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdCol = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "bun_code";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdCol = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell53.CellName = "act_doctor";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            this.xEditGridCell53.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            // OCSACT
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackGroundColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "OCSACT";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OCSACT_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            this.xPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPaInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPaInfoBox1)).EndInit();
            this.tabSangByung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSangByung)).EndInit();
            this.tabOrdRemark.ResumeLayout(false);
            this.tabPaComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paComment)).EndInit();
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJaeryo)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            this.xPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel6.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultJearyo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layPacsInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayConstantInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mlayPart)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

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

        // Updated by Cloud
        OCSACTCboSystemSelectedIndexChangedResult _cboRes;
        OCSACTGrdRowFocusChangedResult _grdRes;
        private DateTime mSysDate;
        OCSACTCboTimeAndSystemResult mCboSysTime;
        private bool isFirstLoad = true;
        OCSACTGroupedPatientAndOrderResult mGroupedResult;
        #endregion

        #region Constructor
        /// <summary>
        /// OCSACT
        /// </summary>
        public OCSACT()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // updated by Cloud
            InitializeCloud();

            //TODO disable IN Hospital Tab MED-5790
            rbxInp.Visible = false;
            if (NetInfo.Language == LangMode.Jr)
            {
                SetSizeForColumn();
            }
        }

        private void SetSizeForColumn()
        {
            grdPaList.AutoSizeColumn(xEditGridCell1.Col, 34);
            grdPaList.AutoSizeColumn(xEditGridCell4.Col, 102);
            grdPaList.AutoSizeColumn(xEditGridCell5.Col, 112);
            grdPaList.AutoSizeColumn(xEditGridCell3.Col, 93);
            
            grdOrder.AutoSizeColumn(xEditGridCell16.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell18.Col, 247);
            grdOrder.AutoSizeColumn(xEditGridCell87.Col, 30);
            grdOrder.AutoSizeColumn(xEditGridCell88.Col, 30);
            grdOrder.AutoSizeColumn(xEditGridCell20.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell21.Col, 35);
            grdOrder.AutoSizeColumn(xEditGridCell90.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell91.Col, 35);
            grdOrder.AutoSizeColumn(xEditGridCell8.Col, 80);
            grdOrder.AutoSizeColumn(xEditGridCell9.Col, 35);
            grdOrder.AutoSizeColumn(xEditGridCell70.Col, 85);
            grdOrder.AutoSizeColumn(xEditGridCell7.Col, 23);
            grdOrder.AutoSizeColumn(xEditGridCell61.Col, 25);
            grdOrder.AutoSizeColumn(xEditGridCell65.Col, 45);
           
             grdJaeryo.AutoSizeColumn(xEditGridCell11.Col, 116);
            grdJaeryo.AutoSizeColumn(xEditGridCell12.Col, 488);
            grdJaeryo.AutoSizeColumn(xEditGridCell13.Col, 60);
            grdJaeryo.AutoSizeColumn(xEditGridCell45.Col, 69);
             grdJaeryo.AutoSizeColumn(xEditGridCell51.Col, 47);
        }
        #endregion

        #region Events

        private void OCSACT_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.mLayInputTime = new MultiLayout();
            this.mLayInputTime.LayoutItems.Add("hangmog_code", DataType.String, false, true);
            this.mLayInputTime.LayoutItems.Add("hangmog_name", DataType.String, false, true);
            this.mLayInputTime.LayoutItems.Add("minute_suryang", DataType.Number, false, true);
            this.mLayInputTime.LayoutItems.Add("hour", DataType.Number, false, true);
            this.mLayInputTime.LayoutItems.Add("minute", DataType.Number, false, true);

            this.mLayInputTime.InitializeLayoutTable();

            this.mHangmogInfo = new IHIS.OCS.HangmogInfo(this.Name);
            mSysDate = EnvironInfo.GetSysDate();
            this.dtpFromDate.SetDataValue(mSysDate);
            this.dtpToDate.SetDataValue(mSysDate);

            if (this.OpenParam == null)
            {
                //초기 화면 오픈시 시스템 설정
                switch (EnvironInfo.CurrSystemID)
                {
                    case "PFES":
                        this.cboSystem.SetEditValue("OCS_ACT_PART_02");
                        this.cboPart.SetEditValue("%");
                        break;

                    case "NUTS":
                        this.cboSystem.SetEditValue("OCS_ACT_PART_06");
                        this.cboPart.SetEditValue("%");
                        this.grdOrder.AutoSizeColumn(6, 0);
                        this.grdOrder.AutoSizeColumn(5, 0);
                        break;

                    case "CPLS":
                        this.cboSystem.SetEditValue("OCS_ACT_PART_02");
                        this.cboPart.SetEditValue("%");
                        this.cbxEkgIFYN.Visible = true;
                        this.btnIfEkg.Visible = true;
                        // 2015.07.29 AnhNV updated START
                        //this.btnRequest.Visible = false;
                        //this.btnJaeryo.Location = new Point(239, 4);
                        // 2015.07.29 AnhNV updated END
                        this.grdOrder.AutoSizeColumn(6, 0);
                        this.grdOrder.AutoSizeColumn(5, 0);
                        break;

                    case "ENDO":
                        this.cboSystem.SetEditValue("OCS_ACT_PART_02");
                        this.cboPart.SetEditValue("%");
                        this.grdOrder.AutoSizeColumn(6, 0);
                        this.grdOrder.AutoSizeColumn(5, 0);
                        break;

                    case "OPRS":
                        this.cboSystem.SetEditValue("OCS_ACT_PART_05");
                        this.cboPart.SetEditValue("%");
                        this.grdOrder.AutoSizeColumn(6, 0);
                        this.grdOrder.AutoSizeColumn(5, 0);
                        break;

                    case "TSTS":
                        this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
                        this.cboSystem.SetEditValue("OCS_ACT_PART_08");
                        this.cboPart.SetEditValue("%");
                        break;
                    case "NURO":
                        this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
                        this.rbxOut.PerformClick();
                        this.rbxOut.ImageIndex = 1;
                        this.cboSystem.SetEditValue("OCS_ACT_PART_08");
                        this.cboPart.SetEditValue("%");
                        break;
                    case "NURI":
                        this.Size = new System.Drawing.Size(this.Width + 60, this.Height);
                        this.rbxInp.PerformClick();
                        this.rbxInp.ImageIndex = 1;
                        this.cboSystem.SetEditValue("OCS_ACT_PART_08");
                        this.cboPart.SetEditValue("%");
                        break;
                    default:
                        break;
                }
            }
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

            //MED-6128
            if (NetInfo.Language == LangMode.Vi)
            {
                this.lbSuname.Location = new Point(240, 74);
            }

            this.CurrMQLayout = this.grdPaList;

            //this.grdOrder.SavePerformer = new XSavePerformer(this);

            //this.SaveLayoutList.Add(grdOrder);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 130);

            string tipTextGrdPalist = Resources.tipTextGrdPalist;
            string tipTextGrdOrder = XMsg.GetField("F002"); // 오더일보기
            this.toolTip.SetToolTip((Control)btnExpand, tipTextGrdPalist);
            this.toolTip.SetToolTip((Control)btnExpandOrdgrid, tipTextGrdOrder);

            this.rbxOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxInp.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxIOAll.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxTodayOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);

            this.rbxAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            this.rbxActAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            this.rbxNonAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);

            // タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
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
                    break;
                case "rbxNonAct":
                    this.rbxNonAct.ImageIndex = 1;
                    this.rbxNonAct.BackColor = XColor.DockingGradientEndColor;
                    this.rbxNonAct.ForeColor = XColor.InsertedForeColor;
                    btnJaeryo.Enabled = true;
                    // 実施者に 現在ログインしている IDを セットする｡
                    this.dbxDocCode.SetDataValue(UserInfo.UserID);
                    this.dbxDocName.SetDataValue(UserInfo.UserName);

                    break;
                case "rbxAct":
                    this.rbxAct.ImageIndex = 1;
                    this.rbxAct.BackColor = XColor.DockingGradientEndColor;
                    this.rbxAct.ForeColor = XColor.InsertedForeColor;
                    btnJaeryo.Enabled = true;
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
            this.cboPart.ResetData();

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
            GetListCboPartAndActor();

            cboPart.ExecuteQuery = GetCboPart;
            cboPart.SetDictDDLB();
            //cbxActor.ExecuteQuery = GetCboActor;
            //cbxActor.SetDictDDLB();
            #endregion

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

                    if (!string.IsNullOrEmpty(res.Msg))
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

            return Utilities.CheckInventory(inputList);
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
            string io_gubun = "1";//all = 1, out = 2, inp = 3, todayout = 4
            if (rbxIOAll.Checked) io_gubun = "1";
            else if (rbxOut.Checked) io_gubun = "2";
            else if (rbxInp.Checked) io_gubun = "3";
            else io_gubun = "4";

            string act_gubun = "1";//all = 1, no act = 2, act = 3
            if (rbxActAll.Checked) act_gubun = "1";
            else if (rbxNonAct.Checked) act_gubun = "2";
            else act_gubun = "3";

            // deleted by Cloud
            //string jundal_part_param = this.setPartParam(this.cboPart.GetDataValue());

            grdOrder.Reset();
            grdJaeryo.Reset();

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
            this.grdPaList.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdPaList.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdPaList.SetBindVarValue("f_act_gubun", act_gubun);
            this.grdPaList.SetBindVarValue("f_jundal_table_code", cboSystem.GetDataValue());
            this.grdPaList.SetBindVarValue("f_io_gubun", io_gubun);
            this.grdPaList.SetBindVarValue("f_cbo_part", cboPart.GetDataValue());
            this.grdPaList.SetBindVarValue("f_cbo_system", cboSystem.GetDataValue());
            this.grdPaList.SetBindVarValue("f_cbo_val", cboPart.GetDataValue());
            this.grdPaList.SetBindVarValue("f_system_id", EnvironInfo.CurrSystemID);
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

            this.grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdOrder.SetBindVarValue("f_io_gubun", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "in_out_gubun"));
            this.grdOrder.SetBindVarValue("f_act_gubun", act_gubun);
            this.grdOrder.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdOrder.SetBindVarValue("f_jundal_table_code", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table"));
            this.grdOrder.SetBindVarValue("f_jundal_part", cboPart.GetDataValue());
            this.grdOrder.SetBindVarValue("f_bunho", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
            this.grdOrder.SetBindVarValue("f_gwa", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "gwa"));
            this.grdOrder.SetBindVarValue("f_doctor", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "doctor"));

            // updated by Cloud
            this.grdOrder.SetBindVarValue("f_cbo_system", cboSystem.GetDataValue());
            this.grdOrder.SetBindVarValue("f_cbo_val", cboPart.GetDataValue());
            this.grdOrder.SetBindVarValue("f_cbo_part", cboPart.GetDataValue());
            this.grdOrder.SetBindVarValue("f_system_id", EnvironInfo.CurrSystemID);
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

            switch (aGrd.Name)
            {
                case "grdPaList":
                    this.grdOrder.QueryLayout(false);
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
                    this.grdSangByung.QueryLayout(false);
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
                        this.dbxDocName.Text = this.grdOrder.GetItemString(e.CurrentRow, "act_doctor_name");
                        this.dbxDocCode.Text = this.grdOrder.GetItemString(e.CurrentRow, "act_doctor");
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
                        this.grdJaeryo.SetItemValue(e.RowNumber, "nalsu", "1");
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
                            this.grdJaeryo.SetItemValue(e.RowNumber, "nalsu", "1");
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
                    //MessageBox.Show(loadParams["jundal_part"].ToString() + "    OCSACT ");
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
            this.tabControl.SelectedTab = this.tabControl.TabPages[0];

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

                this.btnChange.Enabled = false; // 実施者一括適用Combo

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

                this.btnChange.Enabled = false; // 実施者一括適用Combo

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
            openParams.Add("nutritionist", dbxDocCode.Text);
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
            grdSangByung.ParamList = new List<string>(new string[]
                {
                    "f_bunho",
                    "f_order_date",
                });
            grdSangByung.ExecuteQuery = GetGrdSangByung;

            // grdPaList
            grdPaList.ParamList = new List<string>(new string[]
                {
                    "f_act_gubun",
                    "f_bunho",
                    "f_cbo_part",
                    "f_cbo_system",
                    "f_cbo_val",
                    "f_from_date",
                    "f_io_gubun",
                    "f_jundal_table_code",
                    "f_system_id",
                    "f_to_date",
                });
            grdPaList.ExecuteQuery = GetGrdPaList;

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
            rbxIOAll.CheckedChanged -= new EventHandler(rbxIOAll_CheckedChanged);

            // Load combo data
            LoadComboSystemAndTime();
            cboSystem.ExecuteQuery = GetCboSystem;
            cboTime.ExecuteQuery = GetCboTime;
            cboSystem.SetDictDDLB();
            cboTime.SetDictDDLB();

            // Re-register events
            cboSystem.SelectedIndexChanged += new EventHandler(cboSystem_SelectedIndexChanged);
            rbxIOAll.CheckedChanged += new EventHandler(rbxIOAll_CheckedChanged);
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
                    if (item.Code != "%")
                    {
                        lObj.Add(new object[] { item.Code, item.CodeName });
                    }
                });
            }

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
                xEditGridCell1.ExecuteQuery = GetCboIoGubun;
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
            args.CodeType = cboSystem.GetDataValue();
            args.SystemId = EnvironInfo.CurrSystemID;
            args.HoDong = UserInfo.HoDong;
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

            if (null != _cboRes)
            {
                _cboRes.CboPartItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
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

            if (null != _cboRes)
            {
                _cboRes.CbxActorItem.ForEach(delegate(ComboListItemInfo item)
                {
                    lObj.Add(new object[] { item.Code, item.CodeName });
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
                args.IoGubun = ioGubun;

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

            //MED-11182
            updJaeryoItem.Pkocs1003 = dtRow["in_out_gubun"].ToString();

            updJaeryoItem.RowState = dtRow.RowState.ToString();

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

        private void btnChange_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxDocCode.GetDataValue());
            param.Add("user_name", dbxDocName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
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
