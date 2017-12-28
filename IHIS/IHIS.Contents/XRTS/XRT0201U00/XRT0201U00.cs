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
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Arguments.Xrts;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Results.Xrts;
using IHIS.Framework;
using IHIS.XRTS.Properties;

#endregion

namespace IHIS.XRTS
{
    /// <summary>
    /// OCSACT에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class XRT0201U00 : IHIS.Framework.XScreen
    {
        #region Init fields
        // 自動照会使用可否フラグ
        private string useTimeChkYN = "";
        private int QueryTime;
        private int TimeVal;

        // 患者有AlarmファイルPATH
        private string alarmFilePath_XRT = "";
        private string alarmFilePath_XRT_EM = "";
        private string useAlarmChkYN = "";

        private MultiLayout layCombo = new MultiLayout();

        // モダリティに電文ファイル送信可否
        private string useMwmYn = "";
        // 被爆量管理可否
        private string useRadioYn = "";

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
        private XRadioButton rbxJubsu;
        private XRadioButton rbxActEnd;
        private XRadioButton rbxAll;
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
        private XButton btnExpand;
        private XEditGridCell xEditGridCell2;
        private ToolTip toolTip;
        private XRadioButton rbxTodayOut;
        private XLabel xLabel3;
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
        private XEditGridCell xEditGridCell51;
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
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell78;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
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
        private XRadioButton rbxAct;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell92;
        private XButton btnExpandOrdgrid;
        private XTextBox txtTimeInterval;
        private XTextBox tbxTimer;
        private XDictComboBox cboTime;
        private XLabel xLabel12;
        private XLabel lbTime;
        private Timer timer1;
        private XButton btnUseTimeChk;
        private MultiLayout mlayConstantInfo;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem6;
        private XEditGridCell xEditGridCell93;
        private XButton btnUseAlarmChk;
        private MultiLayout mlayGrdJaeryo;
        private XLabel xLabel17;
        private XDictComboBox cbxActor;
        private XButton btnRadioData;
        private XEditGridCell xEditGridCell94;
        private XDisplayBox dbxInputDoctorName;
        private XEditGridCell xEditGridCell95;
        private IContainer components;
        #endregion

        #region updated
        private XRT0201U00LoadScreenResult loadScreenResult;
        private XRT0201U00GrdOrderRowFocusChangedResult grdOrderRowFocusChangedResult;
        private XRT0201U00LayPacsResult layPacsResult;
        private XRT0201U00LayConstantResult layConstantResult;
        private String CACHE_NUR0102_CBOTIME = "CPL2010U00.NUR0102.cboTime";
        private String CACHE_OCSACT_CBO_SYSTEM = "Ocsact.Cbo.System";
        private XEditGridCell xEditGridCell96;
        private XDisplayBox dbxUserName;
        private XDisplayBox dbxUserId;
        private XLabel xLabel16;
        private XButton btnFindUser;
        private String CACHE_OCSACT_CBO_IO_GUBUN = "Ocsact.Cbo.Io.Gubun";
        #endregion
        public XRT0201U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            SetGridColumnWidth();
            cboTime.ExecuteQuery = LoadDataCboTime;
            cboTime.SetDictDDLB();
            cboPart.ExecuteQuery = LoadDataCboPart;
            grdOrder.ParamList = CreateGrdOrderParamList();
            grdOrder.ExecuteQuery = LoadGrdOrder;
            grdPaList.ParamList = CreateGrdPaListParamList();
            grdSangByung.ExecuteQuery = LoadGrdSangByung;
            defaultJearyo.ExecuteQuery = LoadDefaultJearyo;
            fwkActor.ExecuteQuery = LoadFwkActor;
            //xLabel12.Size = new Size(32, 18);
            //xLabel12.Location = new Point(76, 4);
            //lbTime.Size = new Size(68, 20);
            //lbTime.Location = new Point(2,5);
            //cboTime.Size = new Size(59, 21);
            //cboTime.Location = new Point(114, 4);

            //TODO disable IN Hospital Tab MED-5790
            rbxInp.Visible = false;
        }

        private void SetGridColumnWidth()
        {
            if (NetInfo.Language == LangMode.Vi)
            {
                ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).BeginInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();

                xEditGridCell1.CellWidth = 56;
                xEditGridCell96.CellWidth = 56;

                xEditGridCell7.CellWidth = 34;
                xEditGridCell89.CellWidth = 56;
                xEditGridCell83.CellWidth = 56;

                ((System.ComponentModel.ISupportInitialize)(this.grdPaList)).EndInit();
                ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XRT0201U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.btnExpandOrdgrid = new IHIS.Framework.XButton();
            this.grdOrder = new IHIS.Framework.XEditGrid();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.dbxInputDoctorName = new IHIS.Framework.XDisplayBox();
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
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.tabPaInfo = new IHIS.X.Magic.Controls.TabPage();
            this.btnFindUser = new IHIS.Framework.XButton();
            this.dbxUserName = new IHIS.Framework.XDisplayBox();
            this.dbxUserId = new IHIS.Framework.XDisplayBox();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.btnRadioData = new IHIS.Framework.XButton();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.btnExpand = new IHIS.Framework.XButton();
            this.grdPaList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.rbxAct = new IHIS.Framework.XRadioButton();
            this.rbxJubsu = new IHIS.Framework.XRadioButton();
            this.rbxActEnd = new IHIS.Framework.XRadioButton();
            this.rbxAll = new IHIS.Framework.XRadioButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.cboTime = new IHIS.Framework.XDictComboBox();
            this.txtTimeInterval = new IHIS.Framework.XTextBox();
            this.tbxTimer = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.lbTime = new IHIS.Framework.XLabel();
            this.lbSuname = new System.Windows.Forms.Label();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cboPart = new IHIS.Framework.XDictComboBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbxTodayOut = new IHIS.Framework.XRadioButton();
            this.rbxOut = new IHIS.Framework.XRadioButton();
            this.rbxInp = new IHIS.Framework.XRadioButton();
            this.rbxIOAll = new IHIS.Framework.XRadioButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnUseAlarmChk = new IHIS.Framework.XButton();
            this.btnUseTimeChk = new IHIS.Framework.XButton();
            this.btnPacsViewer = new IHIS.Framework.XButton();
            this.btnReserViewer = new IHIS.Framework.XButton();
            this.btnReSendIF = new IHIS.Framework.XButton();
            this.btnRequest = new IHIS.Framework.XButton();
            this.btnJaeryo = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnEMR = new IHIS.Framework.XButton();
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
            this.mlayGrdJaeryo = new IHIS.Framework.MultiLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.mlayGrdJaeryo)).BeginInit();
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
            this.ImageList.Images.SetKeyName(18, "13.gif");
            this.ImageList.Images.SetKeyName(19, "12.gif");
            this.ImageList.Images.SetKeyName(20, "OCSI.ico");
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
            this.xPanel10.Controls.Add(this.btnExpandOrdgrid);
            this.xPanel10.Controls.Add(this.grdOrder);
            this.xPanel10.DrawBorder = true;
            this.xPanel10.Font = null;
            this.xPanel10.Name = "xPanel10";
            this.toolTip.SetToolTip(this.xPanel10, resources.GetString("xPanel10.ToolTip"));
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
            this.xEditGridCell95,
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
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell82,
            this.xEditGridCell89,
            this.xEditGridCell91,
            this.xEditGridCell90,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell94});
            this.grdOrder.ColPerLine = 16;
            this.grdOrder.Cols = 17;
            this.grdOrder.ControlBinding = true;
            this.grdOrder.ExecuteQuery = null;
            this.grdOrder.FixedCols = 1;
            this.grdOrder.FixedRows = 2;
            this.grdOrder.HeaderHeights.Add(33);
            this.grdOrder.HeaderHeights.Add(21);
            this.grdOrder.LinePerRow = 2;
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOrder.ParamList")));
            this.grdOrder.QuerySQL = resources.GetString("grdOrder.QuerySQL");
            this.grdOrder.RowHeaderVisible = true;
            this.grdOrder.RowResizable = true;
            this.grdOrder.Rows = 4;
            this.grdOrder.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOrder.SelectionModeChangeable = true;
            this.grdOrder.SortMode = IHIS.Framework.XGridSortMode.SingleClick;
            this.toolTip.SetToolTip(this.grdOrder, resources.GetString("grdOrder.ToolTip"));
            this.grdOrder.ToolTipActive = true;
            this.grdOrder.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdOrder_GridFindSelected);
            this.grdOrder.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOrder_GridColumnChanged);
            this.grdOrder.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOrder_QueryEnd);
            this.grdOrder.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdOrder_GridFindClick);
            this.grdOrder.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grd_RowFocusChanged);
            this.grdOrder.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdOrder_RowFocusChanging);
            this.grdOrder.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOrder_GridCellPainting);
            this.grdOrder.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdOrder_ItemValueChanging);
            this.grdOrder.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOrder_GridColumnProtectModify);
            this.grdOrder.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.CellName = "in_out_gubun";
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
            this.xEditGridCell7.CellName = "jubsu_yn";
            this.xEditGridCell7.CellWidth = 23;
            this.xEditGridCell7.Col = 12;
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
            this.xEditGridCell16.CellWidth = 93;
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
            this.xEditGridCell18.CellWidth = 227;
            this.xEditGridCell18.Col = 2;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "jubsu_date";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "jubsu_time";
            this.xEditGridCell9.CellWidth = 37;
            this.xEditGridCell9.Col = 8;
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
            this.xEditGridCell20.Col = 5;
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
            this.xEditGridCell21.CellWidth = 37;
            this.xEditGridCell21.Col = 6;
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
            this.xEditGridCell70.Col = 11;
            this.xEditGridCell70.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
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
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell95.BindControl = this.dbxInputDoctorName;
            this.xEditGridCell95.CellName = "input_doctor";
            this.xEditGridCell95.Col = -1;
            this.xEditGridCell95.ExecuteQuery = null;
            this.xEditGridCell95.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.IsVisible = false;
            this.xEditGridCell95.Row = -1;
            this.xEditGridCell95.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // dbxInputDoctorName
            // 
            this.dbxInputDoctorName.AccessibleDescription = null;
            this.dbxInputDoctorName.AccessibleName = null;
            resources.ApplyResources(this.dbxInputDoctorName, "dbxInputDoctorName");
            this.dbxInputDoctorName.Image = null;
            this.dbxInputDoctorName.Name = "dbxInputDoctorName";
            this.toolTip.SetToolTip(this.dbxInputDoctorName, resources.GetString("dbxInputDoctorName.ToolTip"));
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell61.AppendReservedMemoText = true;
            this.xEditGridCell61.BindControl = this.txtOrderRemark;
            this.xEditGridCell61.CellLen = 2000;
            this.xEditGridCell61.CellName = "order_remark";
            this.xEditGridCell61.CellWidth = 93;
            this.xEditGridCell61.Col = 1;
            this.xEditGridCell61.ColSpan = 16;
            this.xEditGridCell61.DisplayMemoText = true;
            this.xEditGridCell61.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell61.ExecuteQuery = null;
            this.xEditGridCell61.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell61.ReservedMemoClassName = "IHIS.OCSA.OCS0223Q01";
            this.xEditGridCell61.ReservedMemoFileName = "C:\\IHIS\\OCSA\\OCS.Lib.OCS0223Q01.dll";
            this.xEditGridCell61.Row = 1;
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
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
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
            // xEditGridCell83
            // 
            this.xEditGridCell83.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell83.CellName = "sunab_suryang";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell83.CellWidth = 33;
            this.xEditGridCell83.Col = 16;
            this.xEditGridCell83.ExecuteQuery = null;
            this.xEditGridCell83.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsReadOnly = true;
            this.xEditGridCell83.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            this.xEditGridCell82.CellLen = 1;
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
            this.xEditGridCell89.CellLen = 1;
            this.xEditGridCell89.CellName = "xrt_dr_yn";
            this.xEditGridCell89.CellWidth = 31;
            this.xEditGridCell89.Col = 14;
            this.xEditGridCell89.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell89.ExecuteQuery = null;
            this.xEditGridCell89.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell89.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.CellLen = 1;
            this.xEditGridCell91.CellName = "act_yn";
            this.xEditGridCell91.CellWidth = 23;
            this.xEditGridCell91.Col = 13;
            this.xEditGridCell91.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell91.ExecuteQuery = null;
            this.xEditGridCell91.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell91.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell90.CellName = "acting_date";
            this.xEditGridCell90.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell90.CellWidth = 90;
            this.xEditGridCell90.Col = 9;
            this.xEditGridCell90.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell90.ExecuteQuery = null;
            this.xEditGridCell90.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.CellName = "acting_time";
            this.xEditGridCell92.CellWidth = 37;
            this.xEditGridCell92.Col = 10;
            this.xEditGridCell92.ExecuteQuery = null;
            this.xEditGridCell92.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.Mask = "##:##";
            this.xEditGridCell92.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell92.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell93.CellLen = 1;
            this.xEditGridCell93.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            this.xEditGridCell93.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            this.xEditGridCell93.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.CellLen = 1;
            this.xEditGridCell94.CellName = "portable_yn";
            this.xEditGridCell94.CellWidth = 31;
            this.xEditGridCell94.Col = 15;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell94.ExecuteQuery = null;
            this.xEditGridCell94.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            this.xEditGridCell94.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell94.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tabPaInfo.Controls.Add(this.btnFindUser);
            this.tabPaInfo.Controls.Add(this.dbxUserName);
            this.tabPaInfo.Controls.Add(this.dbxUserId);
            this.tabPaInfo.Controls.Add(this.xLabel16);
            this.tabPaInfo.Controls.Add(this.dbxInputDoctorName);
            this.tabPaInfo.Controls.Add(this.btnRadioData);
            this.tabPaInfo.Controls.Add(this.cbxActor);
            this.tabPaInfo.Controls.Add(this.xLabel17);
            this.tabPaInfo.Controls.Add(this.dbxUnusualInfo);
            this.tabPaInfo.Controls.Add(this.xLabel15);
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
            // btnFindUser
            // 
            this.btnFindUser.AccessibleDescription = null;
            this.btnFindUser.AccessibleName = null;
            resources.ApplyResources(this.btnFindUser, "btnFindUser");
            this.btnFindUser.BackgroundImage = null;
            this.btnFindUser.Name = "btnFindUser";
            this.toolTip.SetToolTip(this.btnFindUser, resources.GetString("btnFindUser.ToolTip"));
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // dbxUserName
            // 
            this.dbxUserName.AccessibleDescription = null;
            this.dbxUserName.AccessibleName = null;
            resources.ApplyResources(this.dbxUserName, "dbxUserName");
            this.dbxUserName.Image = null;
            this.dbxUserName.Name = "dbxUserName";
            this.toolTip.SetToolTip(this.dbxUserName, resources.GetString("dbxUserName.ToolTip"));
            // 
            // dbxUserId
            // 
            this.dbxUserId.AccessibleDescription = null;
            this.dbxUserId.AccessibleName = null;
            resources.ApplyResources(this.dbxUserId, "dbxUserId");
            this.dbxUserId.Image = null;
            this.dbxUserId.Name = "dbxUserId";
            this.toolTip.SetToolTip(this.dbxUserId, resources.GetString("dbxUserId.ToolTip"));
            // 
            // xLabel16
            // 
            this.xLabel16.AccessibleDescription = null;
            this.xLabel16.AccessibleName = null;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel16.Image = null;
            this.xLabel16.Name = "xLabel16";
            this.toolTip.SetToolTip(this.xLabel16, resources.GetString("xLabel16.ToolTip"));
            // 
            // btnRadioData
            // 
            this.btnRadioData.AccessibleDescription = null;
            this.btnRadioData.AccessibleName = null;
            resources.ApplyResources(this.btnRadioData, "btnRadioData");
            this.btnRadioData.BackgroundImage = null;
            this.btnRadioData.Image = ((System.Drawing.Image)(resources.GetObject("btnRadioData.Image")));
            this.btnRadioData.Name = "btnRadioData";
            this.toolTip.SetToolTip(this.btnRadioData, resources.GetString("btnRadioData.ToolTip"));
            this.btnRadioData.Click += new System.EventHandler(this.btnRadioData_Click);
            // 
            // cbxActor
            // 
            this.cbxActor.AccessibleDescription = null;
            this.cbxActor.AccessibleName = null;
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.BackgroundImage = null;
            this.cbxActor.ExecuteQuery = null;
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.toolTip.SetToolTip(this.cbxActor, resources.GetString("cbxActor.ToolTip"));
            this.cbxActor.SelectionChangeCommitted += new System.EventHandler(this.cbxActor_SelectionChangeCommitted);
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
            this.xEditGridCell51});
            this.grdJaeryo.ColPerLine = 4;
            this.grdJaeryo.ColResizable = true;
            this.grdJaeryo.Cols = 5;
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
            this.grdJaeryo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdJaeryo_QueryEnd);
            this.grdJaeryo.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdJaeryo_GridFindClick);
            this.grdJaeryo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "hangmog_code";
            this.xEditGridCell11.CellWidth = 130;
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
            this.xEditGridCell12.CellWidth = 568;
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
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell13.CellWidth = 126;
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
            this.xEditGridCell45.CellWidth = 120;
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
            this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell51.CellWidth = 87;
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            this.xEditGridCell51.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            this.xEditGridCell51.RowFont = new System.Drawing.Font("Arial", 8.75F);
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
            this.xEditGridCell96,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell88,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell78,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell85,
            this.xEditGridCell86,
            this.xEditGridCell87});
            this.grdPaList.ColPerLine = 7;
            this.grdPaList.ColResizable = true;
            this.grdPaList.Cols = 8;
            this.grdPaList.EnableMultiSelection = true;
            this.grdPaList.ExecuteQuery = null;
            this.grdPaList.FixedCols = 1;
            this.grdPaList.FixedRows = 1;
            this.grdPaList.HeaderHeights.Add(32);
            this.grdPaList.ImageList = this.ImageList;
            this.grdPaList.Name = "grdPaList";
            this.grdPaList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaList.ParamList")));
            this.grdPaList.QuerySQL = resources.GetString("grdPaList.QuerySQL");
            this.grdPaList.ReadOnly = true;
            this.grdPaList.RowHeaderVisible = true;
            this.grdPaList.RowResizable = true;
            this.grdPaList.Rows = 2;
            this.grdPaList.SelectionModeChangeable = true;
            this.toolTip.SetToolTip(this.grdPaList, resources.GetString("grdPaList.ToolTip"));
            this.grdPaList.ToolTipActive = true;
            this.grdPaList.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaList_QueryEnd);
            this.grdPaList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grd_RowFocusChanged);
            this.grdPaList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPaList_GridCellPainting);
            this.grdPaList.PreEndInitializing += new System.EventHandler(this.grdPaList_PreEndInitializing);
            this.grdPaList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grd_QueryStarting);
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.CellName = "trial_patient";
            this.xEditGridCell96.CellWidth = 37;
            this.xEditGridCell96.Col = 4;
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "in_out_gubun";
            this.xEditGridCell1.CellWidth = 34;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'I_O_GUBUN\'\r\n       \r\n  ";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "order_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell88.CellName = "order_time";
            this.xEditGridCell88.CellWidth = 37;
            this.xEditGridCell88.Col = 3;
            this.xEditGridCell88.ExecuteQuery = null;
            this.xEditGridCell88.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.CellWidth = 93;
            this.xEditGridCell3.Col = 5;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.CellWidth = 99;
            this.xEditGridCell4.Col = 6;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "suname2";
            this.xEditGridCell5.CellWidth = 112;
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
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            this.xEditGridCell79.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
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
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            this.xEditGridCell81.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            this.xEditGridCell81.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell76.CellName = "reser_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            this.xEditGridCell76.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell77.CellName = "emergency";
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
            this.xEditGridCell85.CellName = "naewon_key";
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
            this.xEditGridCell86.CellName = "jundal_table";
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
            this.xEditGridCell87.CellName = "jundal_part";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            this.xEditGridCell87.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            this.xEditGridCell87.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel7
            // 
            this.xPanel7.AccessibleDescription = null;
            this.xPanel7.AccessibleName = null;
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.BackgroundImage = null;
            this.xPanel7.Controls.Add(this.rbxAct);
            this.xPanel7.Controls.Add(this.rbxJubsu);
            this.xPanel7.Controls.Add(this.rbxActEnd);
            this.xPanel7.Controls.Add(this.rbxAll);
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Font = null;
            this.xPanel7.Name = "xPanel7";
            this.toolTip.SetToolTip(this.xPanel7, resources.GetString("xPanel7.ToolTip"));
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
            // rbxJubsu
            // 
            this.rbxJubsu.AccessibleDescription = null;
            this.rbxJubsu.AccessibleName = null;
            resources.ApplyResources(this.rbxJubsu, "rbxJubsu");
            this.rbxJubsu.BackColor = IHIS.Framework.XColor.DockingGradientEndColor;
            this.rbxJubsu.BackgroundImage = null;
            this.rbxJubsu.Checked = true;
            this.rbxJubsu.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.rbxJubsu.ImageList = this.ImageList;
            this.rbxJubsu.Name = "rbxJubsu";
            this.rbxJubsu.TabStop = true;
            this.toolTip.SetToolTip(this.rbxJubsu, resources.GetString("rbxJubsu.ToolTip"));
            this.rbxJubsu.UseVisualStyleBackColor = false;
            // 
            // rbxActEnd
            // 
            this.rbxActEnd.AccessibleDescription = null;
            this.rbxActEnd.AccessibleName = null;
            resources.ApplyResources(this.rbxActEnd, "rbxActEnd");
            this.rbxActEnd.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxActEnd.BackgroundImage = null;
            this.rbxActEnd.ImageList = this.ImageList;
            this.rbxActEnd.Name = "rbxActEnd";
            this.toolTip.SetToolTip(this.rbxActEnd, resources.GetString("rbxActEnd.ToolTip"));
            this.rbxActEnd.UseVisualStyleBackColor = false;
            // 
            // rbxAll
            // 
            this.rbxAll.AccessibleDescription = null;
            this.rbxAll.AccessibleName = null;
            resources.ApplyResources(this.rbxAll, "rbxAll");
            this.rbxAll.BackColor = IHIS.Framework.XColor.DockingGradientStartColor;
            this.rbxAll.BackgroundImage = null;
            this.rbxAll.ImageList = this.ImageList;
            this.rbxAll.Name = "rbxAll";
            this.toolTip.SetToolTip(this.rbxAll, resources.GetString("rbxAll.ToolTip"));
            this.rbxAll.UseVisualStyleBackColor = false;
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
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
            this.xPanel8.Controls.Add(this.xLabel3);
            this.xPanel8.Controls.Add(this.xLabel2);
            this.xPanel8.Controls.Add(this.dtpToDate);
            this.xPanel8.Controls.Add(this.label1);
            this.xPanel8.Controls.Add(this.dtpFromDate);
            this.xPanel8.Controls.Add(this.xLabel1);
            this.xPanel8.Controls.Add(this.cboPart);
            this.xPanel8.Controls.Add(this.paBox);
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
            this.cboTime.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ")\r\n   AND CODE_TYPE = \'NUR2001U04_TIMER\'\r\n ORDER BY TO_NUMBER(CODE)";
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
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackColor = IHIS.Framework.XColor.XListViewBackColor;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            this.toolTip.SetToolTip(this.xLabel3, resources.GetString("xLabel3.ToolTip"));
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
            // label1
            // 
            this.label1.AccessibleDescription = null;
            this.label1.AccessibleName = null;
            resources.ApplyResources(this.label1, "label1");
            this.label1.Font = null;
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
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
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.rbxTodayOut);
            this.xPanel6.Controls.Add(this.rbxOut);
            this.xPanel6.Controls.Add(this.rbxInp);
            this.xPanel6.Controls.Add(this.rbxIOAll);
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
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnUseAlarmChk);
            this.xPanel3.Controls.Add(this.btnUseTimeChk);
            this.xPanel3.Controls.Add(this.btnPacsViewer);
            this.xPanel3.Controls.Add(this.btnReserViewer);
            this.xPanel3.Controls.Add(this.btnReSendIF);
            this.xPanel3.Controls.Add(this.btnRequest);
            this.xPanel3.Controls.Add(this.btnJaeryo);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Controls.Add(this.btnEMR);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            this.toolTip.SetToolTip(this.xPanel3, resources.GetString("xPanel3.ToolTip"));
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
            this.btnPacsViewer.Click += new System.EventHandler(this.btnPacsViewer_Click);
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
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.toolTip.SetToolTip(this.btnList, resources.GetString("btnList.ToolTip"));
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
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
            // fwkActor
            // 
            this.fwkActor.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkActor.ExecuteQuery = null;
            this.fwkActor.FormText = "実施者照会";
            this.fwkActor.InputSQL = "SELECT USER_ID\r\n     , USER_NM\r\n  FROM ADM3200\r\n WHERE HOSP_CODE   = :f_hosp_code" +
                "\r\n   AND USER_GROUP  = \'XRT\'";
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
            this.defaultJearyo.QuerySQL = resources.GetString("defaultJearyo.QuerySQL");
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
            // mlayGrdJaeryo
            // 
            this.mlayGrdJaeryo.ExecuteQuery = null;
            this.mlayGrdJaeryo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("mlayGrdJaeryo.ParamList")));
            // 
            // XRT0201U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackGroundColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "XRT0201U00";
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
            ((System.ComponentModel.ISupportInitialize)(this.mlayGrdJaeryo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region 오픈스크린 이벤트
        private void OCSACT_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // cloud service
            /*dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
            dtpToDate.SetDataValue(EnvironInfo.GetSysDate());*/
            DateTime sysDate = EnvironInfo.GetSysDate();
            dtpFromDate.SetDataValue(sysDate);
            dtpToDate.SetDataValue(sysDate);

            // https://sofiamedix.atlassian.net/browse/MED-14587
            this.dbxUserId.SetDataValue(UserInfo.UserID);
            this.dbxUserName.SetDataValue(UserInfo.UserName);

            // cloud service
            loadScreenResult = GetLoadScreenData();
            this.SetComboBox(this.cbxActor);

            //// 実施者選択可否コントロール
            //this.actorControler();

            // ORDER GRID IsReadOnly 設定
            this.controlGrdReadonly();

            // ボタンの活性/非活性化設定
            this.controlBtnVisible();

            // cloud service
            cboPart.ResetData();
            /*cboPart.UserSQL = @"SELECT '%' CODE
                                     , '全体' CODE_NAME
                                  FROM DUAL
                                UNION
                                SELECT A.CODE
                                     , A.CODE_NAME
                                     FROM (
                                              SELECT CODE
                                                   , CODE_NAME
                                                FROM OCS0132
                                               WHERE CODE_TYPE = 'OCS_ACT_PART_01' 
                                                 AND HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                               ORDER BY SORT_KEY 
                                            ) A ";*/
            cboPart.SetDictDDLB();
            // set selected item
            cboPart.SelectedIndex = 0;
            grdPaList.ExecuteQuery = LoadGrdPaListCombined;
            grdPaList.QueryLayout(false);

            PostCallHelper.PostCall(new PostMethod(postopen));
        }

        private void postopen()
        {
            this.tabControl.SelectedTab = this.tabControl.TabPages[0];

            //            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region OnLoad 이벤트
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.CurrMQLayout = this.grdPaList;

            //this.grdOrder.SavePerformer = new XSavePerformer(this);

            //this.SaveLayoutList.Add(grdOrder);

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 130);

            string tipText = XMsg.GetField("F002"); // 오더일보기
            this.toolTip.SetToolTip((Control)btnExpand, tipText);
            this.toolTip.SetToolTip((Control)btnExpandOrdgrid, tipText);

            this.rbxOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxInp.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxIOAll.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);
            this.rbxTodayOut.CheckedChanged += new System.EventHandler(this.rbxIOAll_CheckedChanged);

            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            this.rbxJubsu.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            this.rbxAct.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);
            this.rbxActEnd.CheckedChanged += new System.EventHandler(this.rbxActAll_CheckedChanged);

            //// タイマー設定
            this.setTimer();

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad
        private void PostLoad()
        {
            string btn_autoQuery_yn = String.Empty;
            string btn_autoAlarm_yn = String.Empty;


            // 注射画面コントロールデータ照会

            // cloud service
            layConstantResult = GetLayConstantData();
            mlayConstantInfo.ExecuteQuery = LoadLayConstantInfo;
            /*this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                 FROM XRT0102
                                                WHERE HOSP_CODE = :f_hosp_code
                                                  AND CODE_TYPE = 'XRT_CONSTANT'
                                                ORDER BY CODE";

            this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);*/

            if (this.mlayConstantInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoQuery_yn")) btn_autoQuery_yn = this.mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("mwm_yn")) useMwmYn = this.mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("radio_yn")) useRadioYn = this.mlayConstantInfo.GetItemString(i, "code_value");

                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = this.mlayConstantInfo.GetItemString(i, "code_value");
                        this.alarmFilePath_XRT = layConstantResult.AlarmFilePathXrt;
                        this.alarmFilePath_XRT_EM = layConstantResult.AlarmFilePathXrtEm;
                    }
                }

                // cloud service
                /*for (int i = 0; i < this.mlayConstantInfo.RowCount; i++)
                {
                    if (this.mlayConstantInfo.GetItemString(i, "code_name").Equals("btn_autoAlarm_yn"))
                    {
                        btn_autoAlarm_yn = mlayConstantInfo.GetItemString(i, "code_value");

                        // AlarmファイルPATH取得
                        this.mlayConstantInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
                                                 FROM XRT0102
                                                WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                                  AND CODE_TYPE = 'XRT_ALARM'
                                                ORDER BY CODE";

                        this.mlayConstantInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);

                        if (this.mlayConstantInfo.QueryLayout(true))
                        {
                            for (int k = 0; k < this.mlayConstantInfo.RowCount; k++)
                            {
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("XRT")) this.alarmFilePath_XRT = this.mlayConstantInfo.GetItemString(k, "code_value");
                                if (this.mlayConstantInfo.GetItemString(k, "code").Equals("XRT_EM")) this.alarmFilePath_XRT_EM = this.mlayConstantInfo.GetItemString(k, "code_value");
                            }
                        }
                    }
                }*/
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

            // 被爆量管理可否確認 及び ボタン設定
            //XMessageBox.Show(this.useRadioYn);
            if (!this.useRadioYn.Equals("Y")) this.btnRadioData.Enabled = false;

            //// 実施者に 現在ログインしている IDを セットする｡
            //this.cbxActor.SetDataValue(UserInfo.UserID);
        }
        #endregion

        #region [btnUseAlarmChk_Click]
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
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            // I/F転送可否取得
            string if_data_send_yn = this.chkIfSendYN(this.grdOrder.CurrentRowNumber);

            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    if (this.tabControl.SelectedIndex == 3) //paComment 탭이 선택되었는지 확인 (3)
                    {
                        if (this.CurrMQLayout != this.grdJaeryo) // 현재 선택된 탭이 재료탭인지 확인
                        {
                            if (this.paComment.BunHo != "")
                            {
                                this.paComment.InsertRow();
                            }
                        }
                        else
                        {
                            // 実施TAB、完了TABのみ可能
                            if ((this.rbxAct.Checked || this.rbxActEnd.Checked) && this.grdOrder.RowCount > 0)
                            {
                                this.grdJaeryo.InsertRow();
                            }
                        }
                    }
                    else // 특이사항 이외의 탭.
                    {
                        // 実施TAB、完了TABのみ可能
                        if ((this.rbxAct.Checked || this.rbxActEnd.Checked) && this.grdOrder.RowCount > 0)
                        // 오더가 있는지 확인후 재료 추가
                        {
                            this.grdJaeryo.InsertRow();
                        }
                    }

                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (this.rbxAll.Checked) return;

                    // 診療終了可否チェック
                    if (this.rbxJubsu.Checked &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun").Equals("O") &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn").Equals("Y") &&
                        this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_doctor") != ""
                        )
                    {
                        if (!this.checkNaewonYn())
                            XMessageBox.Show(Resources.XMessageBox1, Resources.XMessageBox_Caption1,
                                MessageBoxIcon.Information);
                    }

                    Hashtable inputList = new Hashtable();
                    Hashtable outputList = new Hashtable();

                    ArrayList sendIFList = new ArrayList();

                    //MED-11162
                    if (!Utilities.CheckInventory(grdJaeryo.LayoutTable))
                    {
                        return;
                    }

                    // cloud service

                    XRT0201U00SaveLayoutArgs args = new XRT0201U00SaveLayoutArgs();
                    args.GrdOrderItemInfo = GetListGrdOrderForSaveLayout();
                    args.GrdJaeryoItemInfo = GetListGrdJaeryoForSaveLayout();
                    args.GrdPaListCurrentRow = GetGrdPaItemForSaveLayout();
                    args.GrdOrderCurrentRow = GetGrdOrderItemForSaveLayout();
                    args.UseRadioYn = this.useRadioYn;
                    args.RbxJubsu = this.rbxJubsu.Checked;
                    args.RbxAct = this.rbxAct.Checked;
                    args.RbxActEnd = this.rbxActEnd.Checked;
                    args.RbxActUpdJaeryoYn = false;
                    args.RbxActEndUpdJaeryoYn = false;
                    args.UserId = UserInfo.UserID;

                    #region cloud

                    foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                    {
                        if (dtRow.RowState == DataRowState.Modified)
                        {
                            // 会計未処理のみ
                            if (!if_data_send_yn.Equals("Y"))
                            {
                                #region [受付TAB] ①受付実施処理　②PACS電文送信「登録」

                                if (this.rbxJubsu.Checked)
                                {
                                    // 実施チェック可否
                                    if (dtRow["jubsu_yn"].ToString().Equals("Y") &&
                                        dtRow["act_doctor"].ToString().Equals(""))
                                    {
                                        XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_caption3,
                                            MessageBoxIcon.Information);
                                        return;
                                    }
                                }

                                #endregion

                                #region [実施TAB] ①受付取消処理　②PACS電文送信「削除」　③実施処理

                                if (this.rbxAct.Checked)
                                {
                                    if (dtRow["jubsu_yn"].ToString() == "N" && dtRow["act_yn"].ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_caption4,
                                            MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                                #endregion
                            }
                            else
                            {
                                //Update logic VN Hospital
                                if (NetInfo.Language == LangMode.Jr)
                                {
                                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2,
                                        MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }

                    #region [材料GRID 変更事項チェック & 登録、修正、削除処理]

                    // 実施TABで、受付済の場合
                    if (this.rbxAct.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (
                                    XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox5_Caption,
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    // cloud service
                                    args.RbxActUpdJaeryoYn = true;

                                    if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn")
                                        .Equals("N"))
                                    {
                                        XMessageBox.Show(Resources.XMessageBox6, Resources.XMessageBox_caption6,
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    else
                                    {
                                        // cloud service
                                        // for updJaeryoProcess method
                                        foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                                        {
                                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
                                            {
                                                Service.RollbackTransaction();
                                                XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
                                                return;
                                            }
                                            if (dtRow["suryang"].ToString() == "")
                                            {
                                                string mMsg = NetInfo.Language == LangMode.Ko
                                                    ? Resources.XMessageBox7_Ko
                                                    : Resources.XMessageBox7_JP;
                                                string mCap = NetInfo.Language == LangMode.Ko
                                                    ? Resources.XMessageBox_Caption7
                                                    : Resources.XMessageBox_caption2;
                                                XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK,
                                                    MessageBoxIcon.Warning);
                                                return;
                                            }
                                            switch (dtRow.RowState)
                                            {
                                                case DataRowState.Modified:
                                                    XMessageBox.Show(Resources.XMessageBox8,
                                                        Resources.XMessageBox_caption2, MessageBoxIcon.Warning);
                                                    return;
                                            }
                                        }
                                        // 一括処理
                                        /*this.updJaeryoProcess();*/
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

                    // 完了TABで、受付済、実施済の場合
                    if (this.rbxActEnd.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn").Equals("Y") &&
                            this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (
                                    XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox5_Caption,
                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    // cloud service
                                    args.RbxActEndUpdJaeryoYn = true;
                                    // for updJaeryoProcess method
                                    foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                                    {
                                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
                                            return;
                                        }
                                        if (dtRow["suryang"].ToString() == "")
                                        {
                                            string mMsg = NetInfo.Language == LangMode.Ko
                                                ? Resources.XMessageBox7_Ko
                                                : Resources.XMessageBox7_JP;
                                            string mCap = NetInfo.Language == LangMode.Ko
                                                ? Resources.XMessageBox_Caption7
                                                : Resources.XMessageBox_caption2;
                                            XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            return;
                                        }
                                        switch (dtRow.RowState)
                                        {
                                            case DataRowState.Modified:
                                                XMessageBox.Show(Resources.XMessageBox8, Resources.XMessageBox_caption2,
                                                    MessageBoxIcon.Warning);
                                                return;
                                        }
                                    }
                                    // 一括処理
                                    /*this.updJaeryoProcess();*/
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

                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, XRT0201U00SaveLayoutArgs>(args);
                    if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                    {
                        XMessageBox.Show(Resources.XMessageBox13, Resources.XMessageBox13_caption, MessageBoxIcon.Error);
                        return;
                    }

                    #endregion

                    #region comment
                    /*Service.BeginTransaction();

                    foreach (DataRow dtRow in grdOrder.LayoutTable.Rows)
                    {
                        if (dtRow.RowState == DataRowState.Modified)
                        {
                            // 会計未処理のみ
                            if (!if_data_send_yn.Equals("Y"))
                            {
                                #region [受付TAB] ①受付実施処理　②PACS電文送信「登録」

                                if(this.rbxJubsu.Checked)
                                {
                                    // 実施チェック可否
                                    if (dtRow["jubsu_yn"].ToString().Equals("Y") && dtRow["act_doctor"].ToString().Equals(""))
                                    {
                                        XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_caption3, MessageBoxIcon.Information);
                                        return;
                                    }

                                    inputList.Clear();
                                    outputList.Clear();

                                    inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                                    inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());

                                    // 放射線の受付日付更新
                                    if (dtRow["jubsu_yn"].ToString() == "Y")
                                    {
                                        inputList.Add("I_USER_ID", dtRow["act_doctor"].ToString());
                                        inputList.Add("I_JUBSU_DATE", dtRow["jubsu_date"].ToString());
                                        inputList.Add("I_JUBSU_TIME", dtRow["jubsu_time"].ToString());
                                        inputList.Add("I_ACT_DOCTOR", dtRow["act_doctor"].ToString());

                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_XRT_JUBSU", inputList, outputList))
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                        else
                                        {
                                            //////////////////////////////////
                                            // PACSオーダ電文パラメータセット
                                            sendIFinfo ifinfo = new sendIFinfo();

                                            ifinfo.pkOcs = dtRow["pkocs"].ToString();
                                            ifinfo.inOutGubun = dtRow["in_out_gubun"].ToString();
                                            ifinfo.ifSysGubun = "PACS";
                                            ifinfo.ifCmdGubun = "INSERT";
                                            ifinfo.userID = dtRow["act_doctor"].ToString();

                                            sendIFList.Add(ifinfo);
                                            ////////////////////////////////////
                                            ////////////////////////////////////

                                            // 被爆管理可否確認
                                            if (this.useRadioYn.Equals("Y"))
                                            {
                                                // 患者別被爆量データ登録（XRT0002　→　XRT0202）
                                                inputList.Clear();
                                                outputList.Clear();

                                                inputList.Add("I_DATA   _GUBUN", "I");
                                                inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                                                inputList.Add("I_USER_ID", dtRow["act_doctor"].ToString());
                                                inputList.Add("I_IN_OUT_GUBUN", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "in_out_gubun"));

                                                if (!Service.ExecuteProcedure("PR_XRT_MANAGEMENT_XRT0202", inputList, outputList))
                                                {
                                                    Service.RollbackTransaction();
                                                    XMessageBox.Show(Service.ErrFullMsg);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion                              

                                #region [実施TAB] ①受付取消処理　②PACS電文送信「削除」　③実施処理

                                if (this.rbxAct.Checked)
                                {
                                    inputList.Clear();
                                    outputList.Clear();

                                    inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                                    inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());

                                    // ①受付取消処理
                                    if (dtRow["jubsu_yn"].ToString() == "N" && dtRow["act_yn"].ToString() == "N")
                                    {
                                        inputList.Add("I_USER_ID", UserInfo.UserID);
                                        inputList.Add("I_JUBSU_DATE", null);
                                        inputList.Add("I_JUBSU_TIME", null);
                                        inputList.Add("I_ACT_DOCTOR", null);

                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_XRT_JUBSU", inputList, outputList))
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                        else
                                        {
                                            //////////////////////////////////
                                            // PACSオーダ電文パラメータセット
                                            sendIFinfo ifinfo = new sendIFinfo();

                                            ifinfo.pkOcs = dtRow["pkocs"].ToString();
                                            ifinfo.inOutGubun = dtRow["in_out_gubun"].ToString();
                                            ifinfo.ifSysGubun = "PACS";
                                            ifinfo.ifCmdGubun = "DELETE";
                                            ifinfo.userID = dtRow["act_doctor"].ToString();

                                            sendIFList.Add(ifinfo);
                                            ////////////////////////////////////
                                            ////////////////////////////////////

                                            // 被爆管理可否確認
                                            if (this.useRadioYn.Equals("Y"))
                                            {
                                                // 患者別被爆量データ削除（XRT0202）
                                                inputList.Clear();
                                                outputList.Clear();

                                                inputList.Add("I_DATA_GUBUN", "D");
                                                inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                                                inputList.Add("I_USER_ID", "");
                                                inputList.Add("I_IN_OUT_GUBUN", this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "in_out_gubun"));
                                                if (!Service.ExecuteProcedure("PR_XRT_MANAGEMENT_XRT0202", inputList, outputList))
                                                {
                                                    Service.RollbackTransaction();
                                                    XMessageBox.Show(Service.ErrFullMsg);
                                                    return;
                                                }
                                            }
                                        }
                                    }

                                    // ②実施処理
                                    if (dtRow["jubsu_yn"].ToString() == "Y" && dtRow["act_yn"].ToString() == "Y")
                                    {
                                        inputList.Add("I_USER_ID", dtRow["act_doctor"].ToString());
                                        inputList.Add("I_RESULT_DATE", dtRow["acting_date"].ToString());
                                        // X線透視の場合、透視実施可否を設定
                                        inputList.Add("I_XRT_DR_YN", dtRow["xrt_dr_yn"].ToString());
                                        inputList.Add("I_ACT_BUSEO", dtRow["jundal_part"]);
                                        inputList.Add("I_ACTING_DATE", dtRow["acting_date"].ToString());
                                        inputList.Add("I_ACTING_TIME", dtRow["acting_time"].ToString());

                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_XRT_ACTING", inputList, outputList))
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                        else
                                        {
                                            // 予約情報の実施日付更新
                                            inputList.Clear();
                                            outputList.Clear();

                                            inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                                            inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                                            inputList.Add("I_ACTING_DATE", dtRow["acting_date"].ToString());

                                            if (!Service.ExecuteProcedure("PR_SCH_UPDATE_ACTING", inputList, outputList))
                                            {
                                                Service.RollbackTransaction();
                                                XMessageBox.Show(Service.ErrFullMsg);
                                                return;
                                            }
                                        }
                                    }

                                    if (dtRow["jubsu_yn"].ToString() == "N" && dtRow["act_yn"].ToString() == "Y")
                                    {
                                        XMessageBox.Show(Resources.XMessageBox4, Resources.XMessageBox_caption4, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                #endregion

                                #region [完了TAB] ①実施取消処理 ②材料削除処理

                                if (this.rbxActEnd.Checked)
                                {
                                    // UPDATE OCS1003, OCS2003
                                    inputList.Clear();
                                    outputList.Clear();

                                    inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                                    inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());

                                    // 放射線の実施日付、結果日付の更新（取消）
                                    if (dtRow["jubsu_yn"].ToString() == "Y" && dtRow["act_yn"].ToString() == "N")
                                    {
                                        inputList.Add("I_USER_ID", UserInfo.UserID);
                                        inputList.Add("I_RESULT_DATE", null);
                                        inputList.Add("I_XRT_DR_YN", null);
                                        inputList.Add("I_ACT_BUSEO", null);
                                        inputList.Add("I_ACTING_DATE", null);
                                        inputList.Add("I_ACTING_TIME", null);

                                        if (!Service.ExecuteProcedure("PR_OCS_UPDATE_XRT_ACTING", inputList, outputList))
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                        else
                                        {
                                            // 予約情報の実施日付更新（取消）
                                            inputList.Clear();
                                            outputList.Clear();

                                            inputList.Add("I_IN_OUT_GUBUN", dtRow["in_out_gubun"].ToString());
                                            inputList.Add("I_FKOCS", dtRow["pkocs"].ToString());
                                            inputList.Add("I_ACTING_DATE", null);

                                            if (!Service.ExecuteProcedure("PR_SCH_UPDATE_ACTING", inputList, outputList))
                                            {
                                                Service.RollbackTransaction();
                                                XMessageBox.Show(Service.ErrFullMsg);
                                                return;
                                            }

                                            // 材料取消処理
                                            this.updJaeryoProcess("D");
                                        }
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                XMessageBox.Show(Resources.XMessageBox2,Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }

                    #region [材料GRID 変更事項チェック & 登録、修正、削除処理]

                    // 実施TABで、受付済の場合
                    if (this.rbxAct.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox5_Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    if(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("N"))
                                        XMessageBox.Show(Resources.XMessageBox6, Resources.XMessageBox_caption6, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    else
                                    // 一括処理
                                    this.updJaeryoProcess();
                                }
                                else
                                {
                                    this.grdJaeryo.QueryLayout(false);
                                    return;
                                }
                            }
                        }
                    }

                    // 完了TABで、受付済、実施済の場合
                    if (this.rbxActEnd.Checked)
                    {
                        if (this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn").Equals("Y") && this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_yn").Equals("Y"))
                        {
                            DataRowState drState = DataRowState.Unchanged;

                            for (int i = 0; i < this.grdJaeryo.RowCount; i++)
                            {
                                if (grdJaeryo.GetRowState(i) != DataRowState.Unchanged)
                                {
                                    drState = this.grdJaeryo.GetRowState(i);
                                    break;
                                }
                            }

                            // 材料GRIDに変更事項がある場合
                            if ((drState != DataRowState.Unchanged) || (this.grdJaeryo.DeletedRowCount > 0))
                            {
                                if (XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox5_Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    // 一括処理
                                    this.updJaeryoProcess();
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

                    Service.CommitTransaction();*/
                    #endregion

                    // [受付待]は登録電文を、[結果待]は削除電文を　転送する。
                    if (this.rbxJubsu.Checked || this.rbxAct.Checked)
                    {
                        // PACS電文データFILEのFILE名に連番をつける。
                        int seq = 1;

                        foreach (sendIFinfo ifinfo in sendIFList)
                        {
                            // 電文ファイル送信可否確認
                            if (this.useMwmYn.Equals("Y")) SendIF(ifinfo.ifSysGubun, ifinfo.ifCmdGubun, ifinfo.inOutGubun, ifinfo.pkOcs, ifinfo.userID, seq.ToString());

                            seq = seq + 1;
                        }
                    }

                    grdPaList.ExecuteQuery = LoadGrdPaList;
                    this.grdPaList.QueryLayout(false);

                    break;
                case FunctionType.Delete:
                    e.IsBaseCall = false;
                    if (paComment.BunHo != "")
                    {
                        if (this.CurrMQLayout != this.grdJaeryo && tabControl.SelectedIndex == 3) //paComment 탭이 선택되었는지 확인 (3) 
                        {
                            paComment.deleteRow();
                        }
                        // 実施TAB、完了TABのみ可能
                        else if ((this.rbxAct.Checked || this.rbxActEnd.Checked) && this.CurrMQLayout == this.grdJaeryo)
                        {
                            this.grdJaeryo.DeleteRow();
                        }
                    }
                    break;
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    grdPaList.ExecuteQuery = LoadGrdPaList;
                    this.grdPaList.QueryLayout(false);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region updJaeryoProcess(string updGubun) [登録、修正、削除区分別処理]
        private void updJaeryoProcess(string updGubun)
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();
            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            string subul_danui = "";
            string subul_suryang = "";


            #region [updGubun.Equals("I")] 材料登録処理
            if (updGubun.Equals("I"))
            {
                foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                {
                    if (dtRow["suryang"].ToString() == "")
                    {
                        Service.RollbackTransaction();
                        string mMsg = NetInfo.Language == LangMode.Ko ?
                                 Resources.XMessageBox7_Ko :
                                 Resources.XMessageBox7_JP;
                        string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox_Caption7 : Resources.XMessageBox_caption2;
                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    switch (dtRow.RowState)
                    {
                        case DataRowState.Added:
                            // ocs update
                            inputList.Clear();
                            outputList.Clear();

                            string pkocs_inv = "";

                            if (dtRow.ItemArray.GetValue(0).ToString() == "") break;
                            //입원 재료 입력 프로세스
                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                            {
                                inputList.Add("I_IUD_GUBUN", "I");
                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
                                inputList.Add("I_PKOCS2003", 0);
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["IO_ERR"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                        return;
                                    }

                                    //insert ocskey
                                    pkocs_inv = outputList["IO_PKOCS2003"].ToString();

                                    //수불 수량 단위 가져오기
                                    inputList.Clear();
                                    outputList.Clear();
                                    subul_danui = "";
                                    subul_suryang = "";

                                    inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                    inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                    inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                                    inputList.Add("I_DIVIDE", "1");
                                    inputList.Add("I_DV_TIME", "*");
                                    inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                                    inputList.Add("I_NALSU", "1");
                                    inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                                    if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }
                                    else
                                    {
                                        if (outputList["O_FLAG"].ToString() != "0")
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }

                                        // inv1001 save

                                        subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                                        subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
                                        //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
                                        if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                                        if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";


                                        cmdText = @"SELECT INV1001_SEQ.NEXTVAL
                                                  FROM DUAL";

                                        object pkinv1001 = Service.ExecuteScalar(cmdText);

                                        if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
                                        {
                                            bindVars.Clear();
                                            bindVars.Add("f_sys_id", UserInfo.UserID);
                                            bindVars.Add("f_pkinv1001", pkinv1001.ToString());
                                            bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                                            bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                            bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                            bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                                            bindVars.Add("f_subul_suryang", subul_suryang);
                                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
                                            bindVars.Add("f_subul_danui", subul_danui);
                                            bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                            bindVars.Add("f_fkocs_inv", pkocs_inv);
                                            bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                                            cmdText = @"INSERT INTO INV1001 (
                                                        SYS_DATE,        SYS_ID,             UPD_DATE,
                                                        PKINV1001,       BUNHO,              ORDER_DATE,
                                                        IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
                                                        JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
                                                        DV_TIME,         DV,                 NALSU,
                                                        ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
                                                        FKOCS2003,       BOM_SOURCE_KEY,     HOSP_CODE
                                                    ) VALUES (
                                                        SYSDATE,           :f_sys_id,             SYSDATE,
                                                        :f_pkinv1001,      :f_bunho,              :f_order_date,
                                                        :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
                                                        :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
                                                        '*',               '1',                   NVL(:f_nalsu,1),
                                                        :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
                                                        :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

                                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                                            {
                                                Service.RollbackTransaction();
                                                XMessageBox.Show(Service.ErrFullMsg);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }

                                    }
                                }
                            }
                            //외래 재료 입력 프로세스
                            else
                            {
                                inputList.Add("I_IUD_GUBUN", "I");
                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
                                inputList.Add("I_PKOCS1003", 0);
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["IO_ERR"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                        return;
                                    }

                                    //insert ocskey
                                    pkocs_inv = outputList["IO_PKOCS1003"].ToString();

                                    //수불 수량 단위 가져오기
                                    inputList.Clear();
                                    outputList.Clear();

                                    inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                    inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                    inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                                    inputList.Add("I_DIVIDE", "1");
                                    inputList.Add("I_DV_TIME", "*");
                                    inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                                    inputList.Add("I_NALSU", "1");
                                    inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                                    if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }
                                    else
                                    {
                                        if (outputList["O_FLAG"].ToString() != "0")
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }

                                        // inv1001 save

                                        subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                                        subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
                                        //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
                                        if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                                        if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

                                        cmdText = @"SELECT INV1001_SEQ.NEXTVAL
                                                  FROM DUAL";

                                        object pkinv1001 = Service.ExecuteScalar(cmdText);

                                        if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
                                        {
                                            bindVars.Clear();
                                            bindVars.Add("f_sys_id", UserInfo.UserID);
                                            bindVars.Add("f_pkinv1001", pkinv1001.ToString());
                                            bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                                            bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                            bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                            bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                                            bindVars.Add("f_subul_suryang", subul_suryang);
                                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
                                            bindVars.Add("f_subul_danui", subul_danui);
                                            bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                            bindVars.Add("f_fkocs_inv", pkocs_inv);
                                            bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                                            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                                            cmdText = @"INSERT INTO INV1001 (
                                                        SYS_DATE,        SYS_ID,             UPD_DATE,
                                                        PKINV1001,       BUNHO,              ORDER_DATE,
                                                        IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
                                                        JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
                                                        DV_TIME,         DV,                 NALSU,
                                                        ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
                                                        FKOCS1003,       BOM_SOURCE_KEY,     HOSP_CODE
                                                    ) VALUES (
                                                        SYSDATE,           :f_sys_id,             SYSDATE,
                                                        :f_pkinv1001,      :f_bunho,              :f_order_date,
                                                        :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
                                                        :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
                                                        '*',               '1',                   NVL(:f_nalsu,1),
                                                        :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
                                                        :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

                                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                                            {
                                                Service.RollbackTransaction();
                                                XMessageBox.Show(Service.ErrFullMsg);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region [updGubun.Equals("U")] 材料修正処理
            if (updGubun.Equals("U"))
            {
                foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                {
                    if (dtRow["suryang"].ToString() == "")
                    {
                        Service.RollbackTransaction();
                        string mMsg = NetInfo.Language == LangMode.Ko ?
                                 Resources.XMessageBox7_Ko :
                                 Resources.XMessageBox7_JP;
                        string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox_Caption7 : Resources.XMessageBox_caption2;
                        XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    switch (dtRow.RowState)
                    {
                        case DataRowState.Modified:
                            //수불 수량 단위 가져오기
                            inputList.Clear();
                            outputList.Clear();

                            subul_danui = "";
                            subul_suryang = "";

                            inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                            inputList.Add("I_DIVIDE", "1");
                            inputList.Add("I_DV_TIME", "*");
                            inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                            inputList.Add("I_NALSU", "1");
                            inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                            if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["O_FLAG"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }

                                subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                                subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();

                                if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                                if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

                            }

                            // update inv1001
                            bindVars.Clear();
                            bindVars.Add("f_upd_id", UserInfo.UserID);
                            bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());
                            bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                            bindVars.Add("f_subul_suryang", subul_suryang);
                            bindVars.Add("f_subul_danui", subul_danui);
                            bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());

                            cmdText = @"UPDATE INV1001
                                       SET UPD_ID          = :f_upd_id
                                         , UPD_DATE        = SYSDATE
                                         , JAERYO_CODE     = :f_jaeryo_code
                                         , SURYANG         = :f_subul_suryang
                                         , ORD_DANUI       = :f_subul_danui
                                         , NALSU           = NVL(:f_nalsu,1)
                                     WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001       = :f_pkinv1001";

                            if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }

                            inputList.Clear();
                            outputList.Clear();
                            //재료 입원 수정
                            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                            {
                                inputList.Add("I_IUD_GUBUN", "U");
                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                                inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                                inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["IO_ERR"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                        return;
                                    }
                                }
                            }
                            //재료 외래 수정
                            else
                            {
                                inputList.Add("I_IUD_GUBUN", "U");
                                inputList.Add("I_INPUT_ID", UserInfo.UserID);
                                inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                inputList.Add("I_BOM_SOURCE_KEY", int.Parse(dtRow["fkocs_xrt"].ToString()));
                                inputList.Add("I_PKOCS1003", int.Parse(dtRow["fkocs_inv"].ToString()));
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                                inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                                inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                                inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                                inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                                inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                                if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["IO_ERR"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                        return;
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region [updGubun.Equals("D")] 材料削除処理
            if (updGubun.Equals("D"))
            {
                try
                {
                    //foreach (DataRow dtRow in grdJaeryo.DeletedRowTable.Rows)
                    foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
                    {
                        // delete inv1001
                        bindVars.Clear();
                        bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());

                        cmdText = @"DELETE INV1001
                                     WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001    = :f_pkinv1001";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }

                        inputList.Clear();
                        outputList.Clear();
                        //재료 입원 삭제
                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                        {
                            inputList.Add("I_IUD_GUBUN", "D");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                            inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                            inputList.Add("I_ACTING_DATE", DBNull.Value);
                            inputList.Add("I_ACTING_TIME", DBNull.Value);
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }
                            }
                        }
                        //재료 외래 삭제
                        else
                        {
                            inputList.Add("I_IUD_GUBUN", "D");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                            inputList.Add("I_PKOCS1003", dtRow["fkocs_inv"].ToString());
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                            inputList.Add("I_ACTING_DATE", DBNull.Value);
                            inputList.Add("I_ACTING_TIME", DBNull.Value);
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            #endregion
        }
        #endregion

        #region updJaeryoProcess() [登録、修正、削除　一括処理]
        private void updJaeryoProcess()
        {
            Hashtable inputList = new Hashtable();
            Hashtable outputList = new Hashtable();
            string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            string subul_danui = "";
            string subul_suryang = "";

            foreach (DataRow dtRow in grdJaeryo.LayoutTable.Rows)
            {
                if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "act_yn") != "Y")
                {
                    Service.RollbackTransaction();
                    XMessageBox.Show(XMsg.GetMsg("M004"), XMsg.GetField("F001"));
                    return;
                }
                if (dtRow["suryang"].ToString() == "")
                {
                    Service.RollbackTransaction();
                    string mMsg = NetInfo.Language == LangMode.Ko ?
                             Resources.XMessageBox7_Ko :
                             Resources.XMessageBox7_JP;
                    string mCap = NetInfo.Language == LangMode.Ko ? Resources.XMessageBox_Caption7 : Resources.XMessageBox_caption2;
                    XMessageBox.Show(mMsg, mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                switch (dtRow.RowState)
                {
                    case DataRowState.Added:

                        // ocs update
                        inputList.Clear();
                        outputList.Clear();

                        string pkocs_inv = "";

                        if (dtRow.ItemArray.GetValue(0).ToString() == "") break;
                        //입원 재료 입력 프로세스
                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                        {
                            inputList.Add("I_IUD_GUBUN", "I");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                            inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
                            inputList.Add("I_PKOCS2003", 0);
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }

                                //insert ocskey
                                pkocs_inv = outputList["IO_PKOCS2003"].ToString();

                                //수불 수량 단위 가져오기
                                inputList.Clear();
                                outputList.Clear();
                                subul_danui = "";
                                subul_suryang = "";

                                inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                                inputList.Add("I_DIVIDE", "1");
                                inputList.Add("I_DV_TIME", "*");
                                inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                                inputList.Add("I_NALSU", "1");
                                inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                                if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["O_FLAG"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }

                                    // inv1001 save

                                    subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                                    subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
                                    //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
                                    if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                                    if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";


                                    cmdText = @"SELECT INV1001_SEQ.NEXTVAL
                                                          FROM DUAL";

                                    object pkinv1001 = Service.ExecuteScalar(cmdText);

                                    if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
                                    {
                                        bindVars.Clear();
                                        bindVars.Add("f_sys_id", UserInfo.UserID);
                                        bindVars.Add("f_pkinv1001", pkinv1001.ToString());
                                        bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                                        bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                        bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                        bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                                        bindVars.Add("f_subul_suryang", subul_suryang);
                                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
                                        bindVars.Add("f_subul_danui", subul_danui);
                                        bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                        bindVars.Add("f_fkocs_inv", pkocs_inv);
                                        bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                                        cmdText = @"INSERT INTO INV1001 (
                                                                SYS_DATE,        SYS_ID,             UPD_DATE,
                                                                PKINV1001,       BUNHO,              ORDER_DATE,
                                                                IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
                                                                JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
                                                                DV_TIME,         DV,                 NALSU,
                                                                ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
                                                                FKOCS2003,       BOM_SOURCE_KEY,     HOSP_CODE
                                                            ) VALUES (
                                                                SYSDATE,           :f_sys_id,             SYSDATE,
                                                                :f_pkinv1001,      :f_bunho,              :f_order_date,
                                                                :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
                                                                :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
                                                                '*',               '1',                   NVL(:f_nalsu,1),
                                                                :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
                                                                :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

                                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }

                                }
                            }
                        }
                        //외래 재료 입력 프로세스
                        else
                        {
                            inputList.Add("I_IUD_GUBUN", "I");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_BOM_SOURCE_KEY", grdOrder.GetItemInt(grdOrder.CurrentRowNumber, "pkocs"));
                            inputList.Add("I_PKOCS1003", 0);
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }

                                //insert ocskey
                                pkocs_inv = outputList["IO_PKOCS1003"].ToString();

                                //수불 수량 단위 가져오기
                                inputList.Clear();
                                outputList.Clear();

                                inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                                inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                                inputList.Add("I_DIVIDE", "1");
                                inputList.Add("I_DV_TIME", "*");
                                inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                                inputList.Add("I_NALSU", "1");
                                inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                                if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return;
                                }
                                else
                                {
                                    if (outputList["O_FLAG"].ToString() != "0")
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }

                                    // inv1001 save

                                    subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                                    subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();
                                    //string subul_qty = outputList["O_SUBUL_QTY"].ToString();
                                    if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                                    if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

                                    cmdText = @"SELECT INV1001_SEQ.NEXTVAL
                                                          FROM DUAL";

                                    object pkinv1001 = Service.ExecuteScalar(cmdText);

                                    if (Service.ErrCode == 0 && !TypeCheck.IsNull(pkinv1001))
                                    {
                                        bindVars.Clear();
                                        bindVars.Add("f_sys_id", UserInfo.UserID);
                                        bindVars.Add("f_pkinv1001", pkinv1001.ToString());
                                        bindVars.Add("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                                        bindVars.Add("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                                        bindVars.Add("f_in_out_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                                        bindVars.Add("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                                        bindVars.Add("f_subul_suryang", subul_suryang);
                                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());
                                        bindVars.Add("f_subul_danui", subul_danui);
                                        bindVars.Add("f_act_buseo", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                                        bindVars.Add("f_fkocs_inv", pkocs_inv);
                                        bindVars.Add("f_fkocs_xrt", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                                        bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

                                        cmdText = @"INSERT INTO INV1001 (
                                                                SYS_DATE,        SYS_ID,             UPD_DATE,
                                                                PKINV1001,       BUNHO,              ORDER_DATE,
                                                                IN_OUT_GUBUN,    INPUT_PART,         HANGMOG_CODE,
                                                                JAERYO_CODE,     SUBUL_BUSEO,        SURYANG,
                                                                DV_TIME,         DV,                 NALSU,
                                                                ORD_DANUI,       ACTING_DATE,        ACT_BUSEO,
                                                                FKOCS1003,       BOM_SOURCE_KEY,     HOSP_CODE
                                                            ) VALUES (
                                                                SYSDATE,           :f_sys_id,             SYSDATE,
                                                                :f_pkinv1001,      :f_bunho,              :f_order_date,
                                                                :f_in_out_gubun,   :f_jundal_part,        :f_jaeryo_code,
                                                                :f_jaeryo_code,    :f_jundal_part,        :f_subul_suryang,
                                                                '*',               '1',                   NVL(:f_nalsu,1),
                                                                :f_subul_danui,    TRUNC(SYSDATE),        :f_act_buseo,
                                                                :f_fkocs_inv,      :f_fkocs_xrt,          :f_hosp_code)";

                                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                                        {
                                            Service.RollbackTransaction();
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        Service.RollbackTransaction();
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return;
                                    }

                                }
                            }
                        }
                        break;
                    case DataRowState.Modified:

                        //this.grdJaeryo.

                        XMessageBox.Show(Resources.XMessageBox8, Resources.XMessageBox_caption2, MessageBoxIcon.Warning);
                        return;

                        //수불 수량 단위 가져오기
                        inputList.Clear();
                        outputList.Clear();

                        subul_danui = "";
                        subul_suryang = "";

                        inputList.Add("I_GUBUN", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                        inputList.Add("I_ORDER_DANUI", dtRow["ord_danui"].ToString());
                        inputList.Add("I_DIVIDE", "1");
                        inputList.Add("I_DV_TIME", "*");
                        inputList.Add("I_ORDER_SURYANG", dtRow["suryang"].ToString());
                        inputList.Add("I_NALSU", "1");
                        inputList.Add("I_APP_DATE", EnvironInfo.GetSysDate());

                        if (!Service.ExecuteProcedure("PR_OCS_LOAD_SUBUL_SURYANG", inputList, outputList))
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
                        else
                        {
                            if (outputList["O_FLAG"].ToString() != "0")
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }

                            subul_danui = outputList["O_SUBUL_DANUI"].ToString();
                            subul_suryang = outputList["O_SUBUL_SURYANG"].ToString();

                            if (TypeCheck.IsNull(subul_danui)) subul_danui = dtRow["ord_danui"].ToString();
                            if (TypeCheck.IsNull(subul_suryang)) subul_suryang = "1";

                        }

                        // update inv1001
                        bindVars.Clear();
                        bindVars.Add("f_upd_id", UserInfo.UserID);
                        bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());
                        bindVars.Add("f_jaeryo_code", dtRow["hangmog_code"].ToString());
                        bindVars.Add("f_subul_suryang", subul_suryang);
                        bindVars.Add("f_subul_danui", subul_danui);
                        bindVars.Add("f_nalsu", dtRow["nalsu"].ToString());

                        cmdText = @"UPDATE INV1001
                                               SET UPD_ID          = :f_upd_id
                                                 , UPD_DATE        = SYSDATE
                                                 , JAERYO_CODE     = :f_jaeryo_code
                                                 , SURYANG         = :f_subul_suryang
                                                 , ORD_DANUI       = :f_subul_danui
                                                 , NALSU           = NVL(:f_nalsu,1)
                                             WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001       = :f_pkinv1001";

                        if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }

                        inputList.Clear();
                        outputList.Clear();
                        //재료 입원 수정
                        if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                        {
                            inputList.Add("I_IUD_GUBUN", "U");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                            inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                            inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }
                            }
                        }
                        //재료 외래 수정
                        else
                        {
                            inputList.Add("I_IUD_GUBUN", "U");
                            inputList.Add("I_INPUT_ID", UserInfo.UserID);
                            inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                            inputList.Add("I_BOM_SOURCE_KEY", int.Parse(dtRow["fkocs_xrt"].ToString()));
                            inputList.Add("I_PKOCS1003", int.Parse(dtRow["fkocs_inv"].ToString()));
                            inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                            inputList.Add("I_SURYANG", int.Parse(dtRow["suryang"].ToString()));
                            inputList.Add("I_ACTING_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_date"));
                            inputList.Add("I_ACTING_TIME", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "acting_time"));
                            inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                            inputList.Add("I_NALSU", (TypeCheck.IsNull(dtRow["nalsu"].ToString()) ? "1" : dtRow["nalsu"].ToString()));
                            inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                            if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(Service.ErrFullMsg);
                                return;
                            }
                            else
                            {
                                if (outputList["IO_ERR"].ToString() != "0")
                                {
                                    Service.RollbackTransaction();
                                    XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                    return;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            //DELETE 재료 
            try
            {
                foreach (DataRow dtRow in grdJaeryo.DeletedRowTable.Rows)
                {
                    // delete inv1001
                    bindVars.Clear();
                    bindVars.Add("f_pkinv1001", dtRow["pkinv1001"].ToString());

                    cmdText = @"DELETE INV1001
                                             WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKINV1001    = :f_pkinv1001";

                    if (!Service.ExecuteNonQuery(cmdText, bindVars))// throw new Exception(Service.ErrFullMsg);
                    {
                        Service.RollbackTransaction();
                        XMessageBox.Show(Service.ErrFullMsg);
                        return;
                    }

                    inputList.Clear();
                    outputList.Clear();
                    //재료 입원 삭제
                    if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun") == "I")
                    {
                        inputList.Add("I_IUD_GUBUN", "D");
                        inputList.Add("I_INPUT_ID", UserInfo.UserID);
                        inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                        inputList.Add("I_ORDER_DATE", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                        inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                        inputList.Add("I_PKOCS2003", dtRow["fkocs_inv"].ToString());
                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                        inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                        inputList.Add("I_ACTING_DATE", DBNull.Value);
                        inputList.Add("I_ACTING_TIME", DBNull.Value);
                        inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                        inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                        inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                        if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_INP_ORDER_ACT", inputList, outputList))
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
                        else
                        {
                            if (outputList["IO_ERR"].ToString() != "0")
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                return;
                            }
                        }
                    }
                    //재료 외래 삭제
                    else
                    {
                        inputList.Add("I_IUD_GUBUN", "D");
                        inputList.Add("I_INPUT_ID", UserInfo.UserID);
                        inputList.Add("I_INPUT_PART", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                        inputList.Add("I_BOM_SOURCE_KEY", dtRow["fkocs_xrt"].ToString());
                        inputList.Add("I_PKOCS1003", dtRow["fkocs_inv"].ToString());
                        inputList.Add("I_HANGMOG_CODE", dtRow["hangmog_code"].ToString());
                        inputList.Add("I_SURYANG", dtRow["suryang"].ToString());
                        inputList.Add("I_ACTING_DATE", DBNull.Value);
                        inputList.Add("I_ACTING_TIME", DBNull.Value);
                        inputList.Add("I_ORDER_GUBUN", DBNull.Value);
                        inputList.Add("I_NALSU", dtRow["nalsu"].ToString());
                        inputList.Add("I_ORD_DANUI", dtRow["ord_danui"].ToString());

                        if (!Service.ExecuteProcedure("PR_OCS_IUD_BOM_OUT_ORDER_ACT", inputList, outputList))
                        {
                            Service.RollbackTransaction();
                            XMessageBox.Show(Service.ErrFullMsg);
                            return;
                        }
                        else
                        {
                            if (outputList["IO_ERR"].ToString() != "0")
                            {
                                Service.RollbackTransaction();
                                XMessageBox.Show(outputList["IO_ERR_MSG"].ToString());
                                return;
                            }
                        }
                    }

                }
            }
            catch
            {
            }
        }
        #endregion


        #region 라디오 버튼 체크 체인지 이벤트(이미지등 처리)
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
            grdPaList.ExecuteQuery = LoadGrdPaList;
            grdPaList.QueryLayout(false);
        }

        private void rbxActAll_CheckedChanged(object sender, EventArgs e)
        {

            XRadioButton aRbx = (XRadioButton)sender;

            this.rbxAll.ImageIndex = 0;
            this.rbxJubsu.ImageIndex = 0;
            this.rbxAct.ImageIndex = 0;
            this.rbxActEnd.ImageIndex = 0;

            this.rbxAll.BackColor = XColor.DockingGradientStartColor;
            this.rbxJubsu.BackColor = XColor.DockingGradientStartColor;
            this.rbxAct.BackColor = XColor.DockingGradientStartColor;
            this.rbxActEnd.BackColor = XColor.DockingGradientStartColor;

            this.rbxAll.ForeColor = XColor.NormalForeColor;
            this.rbxJubsu.ForeColor = XColor.NormalForeColor;
            this.rbxAct.ForeColor = XColor.NormalForeColor;
            this.rbxActEnd.ForeColor = XColor.NormalForeColor;

            if (!aRbx.Checked)
            {
                return;
            }

            switch (aRbx.Name)
            {
                case "rbxAll":
                    this.rbxAll.ImageIndex = 1;
                    this.rbxAll.BackColor = XColor.DockingGradientEndColor;
                    this.rbxAll.ForeColor = XColor.InsertedForeColor;
                    break;
                case "rbxJubsu":
                    this.rbxJubsu.ImageIndex = 1;
                    this.rbxJubsu.BackColor = XColor.DockingGradientEndColor;
                    this.rbxJubsu.ForeColor = XColor.InsertedForeColor;
                    break;
                case "rbxAct":
                    this.rbxAct.ImageIndex = 1;
                    this.rbxAct.BackColor = XColor.DockingGradientEndColor;
                    this.rbxAct.ForeColor = XColor.InsertedForeColor;
                    break;
                case "rbxActEnd":
                    this.rbxActEnd.ImageIndex = 1;
                    this.rbxActEnd.BackColor = XColor.DockingGradientEndColor;
                    this.rbxActEnd.ForeColor = XColor.InsertedForeColor;
                    break;
            }
            grdPaList.ExecuteQuery = LoadGrdPaList;
            this.grdPaList.QueryLayout(false);

            // ORDER GRID IsReadOnly 設定
            this.controlGrdReadonly();

            // ボタンの活性/非活性化設定
            this.controlBtnVisible();
        }
        #endregion

        #region controlGrdReadonly [ORDER GRID IsReadOnly 設定]
        private void controlGrdReadonly()
        {
            // 全体TAB
            if (this.rbxAll.Checked)
            {
                this.xEditGridCell8.IsReadOnly = true;  // jubsu_date
                this.xEditGridCell9.IsReadOnly = true;  // jubsu_time
                this.xEditGridCell90.IsReadOnly = true; // acting_date
                this.xEditGridCell92.IsReadOnly = true; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = true; // jubsu_yn
                this.xEditGridCell91.IsReadOnly = true;  // act_yn
                this.xEditGridCell89.IsReadOnly = true; // xrt_dr_yn

                this.cbxActor.Enabled = false; // 実施者一括適用Combo

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = false;

                this.grdJaeryo.ReadOnly = true;  // 材料GRID
            }

            // 受付待TAB
            if (this.rbxJubsu.Checked)
            {
                this.xEditGridCell8.IsReadOnly = false;  // jubsu_date
                this.xEditGridCell9.IsReadOnly = false;  // jubsu_time
                this.xEditGridCell90.IsReadOnly = true; // acting_date
                this.xEditGridCell92.IsReadOnly = true; // acting_time
                this.xEditGridCell70.IsReadOnly = false; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = false; // jubsu_yn
                this.xEditGridCell91.IsReadOnly = true;  // act_yn
                this.xEditGridCell89.IsReadOnly = true; // xrt_dr_yn

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = true;

                this.cbxActor.Enabled = true; // 実施者一括適用Combo
                //// 実施者に 現在ログインしている IDを セットする｡
                //this.cbxActor.SetDataValue(UserInfo.UserID);
                //this.cbxActor.SetDataValue(UserInfo.UserID);
                this.cbxActor.SetDataValue("");

                this.grdJaeryo.ReadOnly = true;  // 材料GRID
            }

            // 結果待TAB
            if (this.rbxAct.Checked)
            {
                this.xEditGridCell8.IsReadOnly = true;  // jubsu_date
                this.xEditGridCell9.IsReadOnly = true;  // jubsu_time
                this.xEditGridCell90.IsReadOnly = false; // acting_date
                this.xEditGridCell92.IsReadOnly = false; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = false; // jubsu_yn
                this.xEditGridCell91.IsReadOnly = false;  // act_yn
                this.xEditGridCell89.IsReadOnly = false; // xrt_dr_yn

                this.cbxActor.Enabled = false; // 実施者一括適用Combo

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = false;

                this.grdJaeryo.ReadOnly = false;  // 材料GRID
            }

            // 完了TAB
            if (this.rbxActEnd.Checked)
            {
                this.xEditGridCell8.IsReadOnly = true;  // jubsu_date
                this.xEditGridCell9.IsReadOnly = true;  // jubsu_time
                this.xEditGridCell90.IsReadOnly = true; // acting_date
                this.xEditGridCell92.IsReadOnly = true; // acting_time
                this.xEditGridCell70.IsReadOnly = true; // act_doctor_name
                this.xEditGridCell7.IsReadOnly = true; // jubsu_yn
                this.xEditGridCell91.IsReadOnly = false;  // act_yn
                this.xEditGridCell89.IsReadOnly = true; // xrt_dr_yn

                this.cbxActor.Enabled = false; // 実施者一括適用Combo

                // https://sofiamedix.atlassian.net/browse/MED-14735
                this.btnFindUser.Enabled = false;

                this.grdJaeryo.ReadOnly = false;  // 材料GRID
            }
        }
        #endregion

        #region controlBtnVisible() [ボタンの活性/非活性化設定]
        private void controlBtnVisible()
        {
            // 全体TAB
            if (this.rbxAll.Checked)
            {
                this.btnReSendIF.Visible = false; // I/F再転送ボタン
                this.btnJaeryo.Visible = false; // 材料登録ボタン
            }

            // 受付待TAB
            if (this.rbxJubsu.Checked)
            {
                this.btnReSendIF.Visible = false; // I/F再転送ボタン
                this.btnJaeryo.Visible = false; // 材料登録ボタン
            }

            // 結果待TAB
            if (this.rbxAct.Checked)
            {
                this.btnReSendIF.Visible = true; // I/F再転送ボタン
                this.btnJaeryo.Visible = true; // 材料登録ボタン
            }

            // 完了TAB
            if (this.rbxActEnd.Checked)
            {
                this.btnReSendIF.Visible = true; // I/F再転送ボタン
                this.btnJaeryo.Visible = true; // 材料登録ボタン
            }
        }
        #endregion

        #region 환자리스트 그리드 확장/축소
        private void btnExpand_Click(object sender, EventArgs e)
        {
            string tipText = "";
            if (this.grdPaList.CellInfos["order_date"].CellWidth > 1)
            {
                this.grdPaList.CellInfos["order_date"].CellWidth = 1;
                this.grdPaList.CellInfos["order_time"].CellWidth = 1;
                this.grdPaList.AutoSizeColumn(2, 1);
                this.grdPaList.AutoSizeColumn(3, 1);
                this.btnExpand.ImageIndex = 3;
                tipText = XMsg.GetField("F002"); // 오더일보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                this.grdPaList.Refresh();
            }
            else
            {
                this.grdPaList.CellInfos["order_date"].CellWidth = 80;
                this.grdPaList.CellInfos["order_time"].CellWidth = 40;
                this.grdPaList.AutoSizeColumn(2, 80);
                this.grdPaList.AutoSizeColumn(3, 40);

                this.btnExpand.ImageIndex = 2;
                tipText = XMsg.GetField("F003"); // 오더일안보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                this.grdPaList.Refresh();
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
                this.grdOrder.CellInfos["order_time"].CellWidth = 40;
                this.grdOrder.AutoSizeColumn(3, 80);
                this.grdOrder.AutoSizeColumn(4, 40);

                this.btnExpandOrdgrid.ImageIndex = 2;
                tipText = XMsg.GetField("F003"); // 오더일안보기
                this.toolTip.SetToolTip((Control)sender, tipText);
                this.grdOrder.Refresh();
            }
        }
        #endregion

        #region 그리드 조회 전 인변수 셋팅
        private void grd_QueryStarting(object sender, CancelEventArgs e)
        {
            string io_gubun = "1";//all = 1, out = 2, inp = 3, todayOut = 4

            if (rbxIOAll.Checked) io_gubun = "1";
            else if (rbxOut.Checked) io_gubun = "2";
            else if (rbxInp.Checked) io_gubun = "3";
            else io_gubun = "4";

            string act_gubun = "1";//all = 1, no act = 2, act = 3
            if (rbxAll.Checked) act_gubun = "1";
            else if (rbxJubsu.Checked) act_gubun = "2";
            else if (rbxAct.Checked) act_gubun = "3";
            else act_gubun = "4";

            XGrid aGrd = (XGrid)sender;
            switch (aGrd.Name)
            {
                case "grdPaList":
                    grdOrder.Reset();
                    grdJaeryo.Reset();

                    aGrd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    aGrd.SetBindVarValue("f_io_gubun", io_gubun);
                    aGrd.SetBindVarValue("f_act_gubun", act_gubun);
                    aGrd.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
                    aGrd.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
                    aGrd.SetBindVarValue("f_jundal_table_code", "OCS_ACT_PART_01");
                    aGrd.SetBindVarValue("f_jundal_part", cboPart.GetDataValue());
                    aGrd.SetBindVarValue("f_bunho", paBox.BunHo);
                    break;
                case "grdOrder":
                    grdJaeryo.Reset();

                    aGrd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    aGrd.SetBindVarValue("f_order_date", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "order_date"));
                    aGrd.SetBindVarValue("f_io_gubun", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "in_out_gubun"));
                    aGrd.SetBindVarValue("f_reser_yn", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "reser_yn"));
                    aGrd.SetBindVarValue("f_act_gubun", act_gubun);
                    aGrd.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
                    aGrd.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
                    aGrd.SetBindVarValue("f_jundal_table_code", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "jundal_table"));
                    aGrd.SetBindVarValue("f_jundal_part", cboPart.GetDataValue());
                    aGrd.SetBindVarValue("f_bunho", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho"));
                    aGrd.SetBindVarValue("f_naewon_key", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "naewon_key"));
                    aGrd.SetBindVarValue("f_emergency", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "emergency"));
                    aGrd.SetBindVarValue("f_doctor", grdPaList.GetItemString(grdPaList.CurrentRowNumber, "doctor"));
                    break;
                case "grdJaeryo":
                    aGrd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    aGrd.SetBindVarValue("f_io_gubun", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"));
                    aGrd.SetBindVarValue("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                    aGrd.SetBindVarValue("f_fkocs", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"));
                    aGrd.SetBindVarValue("f_jundal_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
                    aGrd.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                    break;
                case "grdSangByung":
                    aGrd.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    aGrd.SetBindVarValue("f_bunho", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho"));
                    aGrd.SetBindVarValue("f_order_date", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date"));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 그리드 포커스 체인지 이벤트 처리(디테일 그리드 조회)
        private void grd_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            XEditGrid aGrd = (XEditGrid)sender;
            switch (aGrd.Name)
            {
                case "grdPaList":
                    grdOrder.QueryLayout(false);
                    break;
                case "grdOrder":
                    if (aGrd.GetItemString(aGrd.CurrentRowNumber, "pace_maker_yn") == "Y")
                    {
                        lbPaceMaker.ImageIndex = 14;
                        lbPaceMaker.Text = Resources.lbPaceMaker;
                    }
                    else
                    {
                        lbPaceMaker.ImageIndex = -1;
                        lbPaceMaker.Text = "";
                    }
                    // cloud service
                    grdOrderRowFocusChangedResult = GetGrdOrderRowFocusChanged(e);
                    grdJaeryo.ExecuteQuery = LoadGrdJaeryoCombined;

                    paComment.SetCommentInfo(grdOrder.GetItemString(e.CurrentRow, "bunho")
                                            , "O"
                                            , grdOrder.GetItemString(e.CurrentRow, "jundal_table")
                                            , grdOrder.GetItemString(e.CurrentRow, "jundal_part")
                                            , grdOrder.GetItemString(e.CurrentRow, "pkocs")
                                            , grdOrder.GetItemString(e.CurrentRow, "in_out_gubun")
                                            , grdOrder.GetItemString(e.CurrentRow, "hangmog_code"));
                    paComment.TabCreate();
                    grdJaeryo.QueryLayout(false);
                    grdSangByung.QueryLayout(false);

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
                                grdJaeryo.SetFocusToItem(grdJaeryo.CurrentRowNumber, "hangmog_code");
                                grdJaeryo.SetEditorValue(defaultJearyo.GetItemString(i, "hangmog_code"));

                                grdJaeryo.SetItemValue(grdJaeryo.CurrentRowNumber, "suryang", defaultJearyo.GetItemString(i, "suryang"));

                                grdJaeryo.AcceptData();
                            }
                        }
                    }

                    if (this.rbxAct.Checked || this.rbxActEnd.Checked)
                        // 実施者をセットする。
                        this.cbxActor.Text = this.grdOrder.GetItemString(e.CurrentRow, "act_doctor_name");

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 전달파트 선택시 재조회
        private void cboPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdPaList.ExecuteQuery = LoadGrdPaList;
            grdPaList.QueryLayout(false);
        }
        #endregion

        #region btnPacsViewer_Click [팍스영상 조회]
        private void btnPacsViewer_Click(object sender, EventArgs e)
        {
            this.viewPacsInfo();
            if (grdPaList.RowCount == 0) return;
            string link = "";
            XRT0201U00LoadLinkArgs args = new XRT0201U00LoadLinkArgs();
            args.Bunho = grdPaList.GetItemString(grdPaList.CurrentRowNumber, "bunho");
            args.Date = DateTime.Parse(grdPaList.GetItemString(grdPaList.CurrentRowNumber, "order_date")).ToString("yyyyMMdd");
            args.Client = System.Environment.MachineName;
            XRT0201U00LoadLinkResult result = CloudService.Instance.Submit<XRT0201U00LoadLinkResult, XRT0201U00LoadLinkArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                link = result.Link;
                //open link
                if (!string.IsNullOrEmpty(link) && link.Length > 0)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(link);
                    }
                    catch (Exception ex)
                    {
                        Service.WriteLog(ex.ToString());
                    }
                    
                }

            }      
        }


        private void viewPacsInfo()
        {
            // 検索結果（患者、オーダ）が無いと、リターンする。
            if (this.grdPaList.RowCount < 1 || this.grdOrder.RowCount < 1)
                return;

            string viewer_ip = null;
            string vw_fd_nm = null;
            string vw_exe_nm = null;
            string param_app = null;
            string param_uname = null;
            string param_pass = null;
            string param_pid = null;
            string param_acceptno = null;
            string param_stdate = null;
            string param_stdatefrom = null;
            string param_stdateto = null;
            string param_modality = null;
            string param_oprt = null;

            // PACS_VIEWER情報取得
            //            this.layPacsInfo.QuerySQL = @"SELECT CODE, CODE_NAME, CODE_VALUE
            //                                            FROM XRT0102
            //                                           WHERE HOSP_CODE = :f_hosp_code
            //                                             AND CODE_TYPE = 'PACS_INFO'
            //                                        ORDER BY SEQ";

            this.layPacsInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            // cloud service
            layPacsResult = GetLayPacsData();
            layPacsInfo.ExecuteQuery = LoadLayPacsInfo;
            if (this.layPacsInfo.QueryLayout(true))
            {
                for (int i = 0; i < this.layPacsInfo.RowCount; i++)
                {
                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VIEWER_IP")) viewer_ip = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VW_FD_NM")) vw_fd_nm = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("VW_EXE_NM")) vw_exe_nm = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_APP")) param_app = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_UNAME")) param_uname = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PASS")) param_pass = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_PID")) param_pid = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_ACCEPTNO")) param_acceptno = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATE")) param_stdate = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATEFROM")) param_stdatefrom = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_STDATETO")) param_stdateto = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_MODALITY")) param_modality = layPacsInfo.GetItemString(i, "code_value");

                    if (this.layPacsInfo.GetItemString(i, "code_name").Equals("PARAM_OPRT")) param_oprt = layPacsInfo.GetItemString(i, "code_value");
                }
            }

            string pid = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho");

            // acceptno　は　MWMとの連携後、使用する。
            //string acceptno = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs");

            string userid = UserInfo.UserID;
            string stdate = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "acting_date").Replace("/", "");
            //string stdatefrom = null;
            //string stdateto = null;

            // cloud service
            /*string modality = this.getModalityCode(this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_code"));*/
            string modality = layPacsResult.Modality;

            //string oprt = null;

            string targetUrl = "";

            try
            {
                if (this.rbxActEnd.Checked)
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass + param_pid + pid + param_stdate + stdate + param_modality + modality;
                else
                    targetUrl = viewer_ip + vw_fd_nm + vw_exe_nm + param_app + param_uname + userid + param_pass + param_pid + pid;

                //XMessageBox.Show(targetUrl);

                System.Diagnostics.Process.Start(targetUrl);
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("[" + targetUrl + "] browser msg : " + noBrowser.Message);
            }
            catch (System.Exception other)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //MessageBox.Show("[" + targetUrl + "] other msg : " + other.Message);
            }
        }
        #endregion

        #region [getModalityCode] 撮影コードに該当するモダリティコードを取得する。
        private string getModalityCode(string xCode)
        {
            string rtnVal = "";

            string strCmd = "";
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_hangmog_code", xCode);

            strCmd = @"SELECT MODALITY
                         FROM XRT0001
                        WHERE HOSP_CODE = :f_hosp_code
                          AND XRAY_CODE = :f_hangmog_code";

            object result = Service.ExecuteScalar(strCmd, bindVar);

            rtnVal = result.ToString();

            return rtnVal;
        }
        #endregion

        #region [cbxActor_SelectionChangeCommitted] 実施担当技師を一括適用
        private void cbxActor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdOrder.RowCount; i++)
            {
                this.grdOrder.SetItemValue(i, "act_doctor", this.cbxActor.GetDataValue());
                this.grdOrder.SetItemValue(i, "act_doctor_name", this.cbxActor.Text);
            }
        }
        #endregion

        #region 受付チェックの項目セット
        private void grdOrder_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            //if (e.ColName == "act_doctor_name")
            //{
            //    string userID = e.ChangeValue.ToString();

            //    this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", userID);
            //}

            if (e.ColName == "jubsu_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    if (this.rbxJubsu.Checked) //受付画面のみ設定
                    {
                        //if (this.cbxActor.GetDataValue().Equals(""))
                        //{
                        //    XMessageBox.Show("担当技師を選択してください。", "担当技師確認", MessageBoxIcon.Information);
                        //    this.grdOrder.SetItemValue(e.RowNumber, "jubsu_yn", "N");
                        //    return;
                        //}

                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_date", EnvironInfo.GetSysDate());
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));

                        //this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", this.cbxActor.GetDataValue());
                        //this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", this.cbxActor.Text);
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "jubsu_yn", e.ChangeValue.ToString());
                }
                else
                {
                    if (this.rbxJubsu.Checked) //受付TABのみ設定
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_date", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "jubsu_time", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", "");
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "jubsu_yn", e.ChangeValue.ToString());

                    //実施TAB
                    if (this.rbxAct.Checked)
                    {
                        // 完了TABで、一行ずつのみ処理　→　現在行以外に実施チェックが外れていたらリターンする。
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (i != e.RowNumber && this.grdOrder.GetItemString(i, "jubsu_yn").Equals("N"))
                            {
                                string code = this.grdOrder.GetItemString(i, "hangmog_code");

                                XMessageBox.Show(Resources.XMessageBox9 + code + Resources.XMessageBox10, Resources.XMessageBox9_caption, MessageBoxIcon.Information);
                                this.grdOrder.SetItemValue(e.RowNumber, "jubsu_yn", "Y");
                                return;
                            }
                        }
                    }
                }
            }

            if (e.ColName == "act_yn")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    //実施TABのみ設定
                    if (this.rbxAct.Checked)
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_date", EnvironInfo.GetSysDate());
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_time", EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());
                }
                else
                {
                    //実施TABのみ設定
                    if (this.rbxAct.Checked)
                    {
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_date", "");
                        this.grdOrder.SetItemValue(e.RowNumber, "acting_time", "");
                    }

                    this.grdOrder.SetItemValue(e.RowNumber, "act_yn", e.ChangeValue.ToString());

                    // I/F転送可否取得
                    string if_data_send_yn = this.chkIfSendYN(this.grdOrder.CurrentRowNumber);

                    //完了TABのみ設定
                    if (this.rbxActEnd.Checked && !if_data_send_yn.Equals("Y"))
                    {
                        // 完了TABで、一行ずつのみ処理　→　現在行以外に実施チェックが外れていたらリターンする。
                        for (int i = 0; i < this.grdOrder.RowCount; i++)
                        {
                            if (i != e.RowNumber && this.grdOrder.GetItemString(i, "act_yn").Equals("N"))
                            {
                                string code = this.grdOrder.GetItemString(i, "hangmog_code");

                                XMessageBox.Show(Resources.XMessageBox11 + code + Resources.XMessageBox10, Resources.XMessageBox_Caption11, MessageBoxIcon.Information);
                                this.grdOrder.SetItemValue(e.RowNumber, "act_yn", "Y");
                                return;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region [btnJaeryo_Click] 재료등록ボタン
        private void btnJaeryo_Click(object sender, EventArgs e)
        {
            // 実施待　画面のみ　材料登録する。
            if (this.rbxAll.Checked || this.rbxJubsu.Checked) return;

            if (this.grdOrder.RowCount == 0) return;

            // I/F転送可否取得
            if (this.chkIfSendYN(this.grdOrder.CurrentRowNumber) == "Y" && NetInfo.Language == LangMode.Jr) // Update VN Hospital Logic
            {
                XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                return;
            }

            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("set_table", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_table"));
            openParams.Add("set_part", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part"));
            openParams.Add("hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));

            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0311Q00", ScreenOpenStyle.PopupSingleFixed, openParams);
        }
        #endregion

        #region Command 재료 받기

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OCS0311Q00": /* 세트 재료 */

                    if (commandParam.Contains("jaeryo_list"))
                    {
                        MultiLayout JaeryoList = commandParam["jaeryo_list"] as MultiLayout;

                        int set_row = -1;

                        if (this.grdJaeryo.CurrentRowNumber >= 0 && TypeCheck.IsNull(this.grdJaeryo.GetItemString(grdJaeryo.CurrentRowNumber, "hangmog_name")))
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
                            foreach (DataRow dtrow in grdJaeryo.LayoutTable.Rows)
                            {
                                if (dtrow["hangmog_code"].ToString() == hangmog_code)
                                {
                                    exist_yn = true;
                                    break;
                                }
                            }

                            if (exist_yn) continue;

                            if (cnt != 0 || set_row == -1)
                            {
                                set_row = grdJaeryo.InsertRow();
                            }

                            this.grdJaeryo.SetItemValue(set_row, "suryang", suryang);
                            this.grdJaeryo.SetItemValue(set_row, "ord_danui", danui);
                            this.grdJaeryo.SetItemValue(set_row, "ord_danui_name", danui_name);
                            this.grdJaeryo.SetItemValue(set_row, "hangmog_name", hangmog_name);

                            this.grdJaeryo.SetFocusToItem(set_row, "hangmog_code");
                            this.grdJaeryo.SetEditorValue(hangmog_code);
                            //this.grdJaeryo.SetItemValue(set_row, "hangmog_code", hangmog_code);

                            cnt++;
                        }

                        grdJaeryo.AcceptData();
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

                            cnt++;
                        }

                        grdJaeryo.AcceptData();
                    }

                    break;
                    #endregion

                case "ADM104Q":

                    #region https://sofiamedix.atlassian.net/browse/MED-14587

                    string userId = "";
                    string userName = "";

                    if (commandParam != null && commandParam.Contains("user_id"))
                    {
                        userId = commandParam["user_id"].ToString();
                        this.dbxUserId.SetDataValue(userId);
                    }

                    if (commandParam != null && commandParam.Contains("user_name"))
                    {
                        userName = commandParam["user_name"].ToString();
                        this.dbxUserName.SetDataValue(userName);
                    }

                    for (int i = 0; i < this.grdOrder.RowCount; i++)
                    {
                        this.grdOrder.SetItemValue(i, "act_doctor", userId);
                        this.grdOrder.SetItemValue(i, "act_doctor_name", userName);
                    }
                    break;

                    #endregion

                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        #endregion

        #region 재료 파인드 셋팅(오더단위)
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
            fdwCommon.ParamList = CreateFwkOrdDanuiParamList();
            switch (aColName)
            {
                case "ord_danui":

                    //        this.fwkTest.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
                    //this.findColumnInfo1,
                    //this.findColumnInfo2});

                    fdwCommon.AutoQuery = true;
                    fdwCommon.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
                    // cloud service
                    fdwCommon.SetBindVarValue("f_hangmog_code", aArgu1);
                    fdwCommon.ExecuteQuery = LoadFwkOrdDanui;
                    /*fdwCommon.InputSQL =
                        " SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI), A.SEQ "
                        + "   FROM OCS0108 A "
                        + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                        + "   AND A.HANGMOG_CODE = '" + aArgu1 + "' "
                        + "  ORDER BY 3, 1, 2 ";*/
                    fdwCommon.ColInfos.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.ord_danui, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.ord_danui_name, FindColType.String, 400, 0, true, FilterType.Yes)});
                    fdwCommon.ColAppearance.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.ord_danui, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.ord_danui_name, FindColType.String, 400, 0, true, FilterType.Yes)});

                    //fdwCommon.ColInfos.Add("ord_danui", "オーダ単位", FindColType.String, 100, 0, true, FilterType.Yes);
                    //fdwCommon.ColInfos.Add("ord_danui_name", "オーダ単位名", FindColType.String, 400, 0, true, FilterType.Yes);

                    break;

                case "ord_danui_name":

                    fdwCommon.AutoQuery = true;
                    fdwCommon.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
                    // cloud service
                    fdwCommon.SetBindVarValue("f_hangmog_code", aArgu1);
                    fdwCommon.ExecuteQuery = LoadFwkOrdDanuiName;
                    /*fdwCommon.InputSQL =
                        " SELECT A.ORD_DANUI, FN_OCS_LOAD_CODE_NAME('ORD_DANUI', A.ORD_DANUI) , A.SEQ "
                        + "   FROM OCS0108 A "
                        + "       ,OCS0103 B "
                        + "  WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() "
                        + "    AND A.HANGMOG_CODE = '" + aArgu1 + "' "
                        + "    AND B.HOSP_CODE = A.HOSP_CODE "
                        + "    AND B.HANGMOG_CODE = A.HANGMOG_CODE "
                        + "    AND TRUNC(SYSDATE) BETWEEN B.START_DATE AND B.END_DATE "
                        + "    AND A.HANGMOG_START_DATE = B.START_DATE "
                        + "  ORDER BY 3, 1, 2 ";*/

                    fdwCommon.ColInfos.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.ord_danui, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.ord_danui_name, FindColType.String, 200, 0, true, FilterType.Yes)});
                    fdwCommon.ColAppearance.AddRange(new FindColumnInfo[] {
                        new FindColumnInfo("ord_danui", Resources.ord_danui, FindColType.String, 100, 0, true, FilterType.Yes),
                        new FindColumnInfo("ord_danui_name", Resources.ord_danui_name, FindColType.String, 200, 0, true, FilterType.Yes)});

                    //fdwCommon.ColInfos.Add("ord_danui_name", "オーダ単位名", FindColType.String, 400, 0, true, FilterType.Yes);
                    //fdwCommon.ColInfos.Add("ord_danui", "オーダ単位", FindColType.String, 100, 0, false, FilterType.No);

                    break;

                default:

                    XMessageBox.Show("Unmatch Column Error!!!", "", MessageBoxIcon.Exclamation);
                    break;
            }

            return fdwCommon;
        }
        #endregion

        #region 재료그리드 파인드 클릭 처리
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
        #endregion

        #region 재료그리드 파인드(오더단위) 선택 후 처리
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
        #endregion

        #region EMR 열기
        private void btnEMR_Click(object sender, EventArgs e)
        {
            string naewonKey = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkout1001");
            string naewonDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            // cloud service
            XRT0201U00NaewonDateArgs args = new XRT0201U00NaewonDateArgs();
            args.NaewonKey = naewonKey;
            XRT0201U00NaewonDateResult result =
                CloudService.Instance.Submit<XRT0201U00NaewonDateResult, XRT0201U00NaewonDateArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success && !("").Equals(result.NaewonDate))
            {
                naewonDate = result.NaewonDate;
            }
            /*string cmdText = @"SELECT TO_CHAR(NAEWON_DATE,'YYYY/MM/DD') FROM OUT1001 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND PKOUT1001 = '" + naewonKey + "'";

            object retVal = Service.ExecuteScalar(cmdText);
            if (!TypeCheck.IsNull(retVal))
            {
                naewonDate = retVal.ToString();
            }*/

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
        #endregion

        #region 의뢰서 팝업
        private void btnRequest_Click(object sender, EventArgs e)
        {
            if (grdOrder.RowCount == 0) return;
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

            XScreen.OpenScreenWithParam(this, "XRTS", "XRT1002U00", ScreenOpenStyle.ResponseFixed, openParams);
        }
        #endregion

        #region [I/F転送関連]

        #region btnReSendIF_Click [I/F再転送]
        private void btnReSendIF_Click(object sender, EventArgs e)
        {
            // 実施タブではない場合、リターンする。
            if (!this.rbxActEnd.Checked) return;

            if (this.grdOrder.RowCount < 1) return;

            string jubsuYN = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jubsu_yn");
            string userID = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "act_doctor");

            // 受付チェック、又は実施者がないとリターンする。
            if (jubsuYN.Equals("N") || userID.Equals(""))
            {
                XMessageBox.Show(Resources.XMessageBox3, Resources.XMessageBox_caption3, MessageBoxIcon.Information);
                return;
            }

            string code = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_code");
            string name = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_name");

            if (XMessageBox.Show("[" + code + "] : " + name + " " + Resources.XMessageBox12, Resources.XMessageBox_caption12, MessageBoxButtons.YesNo) == DialogResult.Yes) this.reSendIF(userID);
            else return;

        }
        #endregion

        #region system 구분별 인터페이스 전송로직
        private void reSendIF(string userid)
        {
            string ifCmdType = "INSERT";
            if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jubsu_yn") == "Y")
            {
                ifCmdType = "INSERT";
            }
            else
            {
                ifCmdType = "DELETE";
            }


            int cntGrid = this.grdOrder.CurrentRowNumber + 1;

            SendIF("PACS", ifCmdType, grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun"), grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs"), userid, cntGrid.ToString());
        }
        #endregion

        #region iud 구분별 인터페이스 전송로직
        //INPUT = IFSysType + IFCmdType + InOutGubun + Pkocs + UserId;
        private void SendIF(string ifSysType, string ifCmdType, string inOutGubun, string pkOcs, string userid, string seq)
        {
            IHIS.Framework.tcpHelper sendIFsocket = new tcpHelper();

            string strCmd = ifSysType + "\t" + ifCmdType + "\t" + inOutGubun + "\t" + pkOcs + "\t" + userid + "\t" + seq;

            sendIFsocket.Send(EnvironInfo.GetInterfaceIP(), EnvironInfo.GetInterfacePort(), strCmd);
        }
        #endregion

        #endregion

        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            loadScreenResult = GetLoadScreenData();
            grdPaList.ExecuteQuery = LoadGrdPaListCombined;
            grdPaList.QueryLayout(false);

            //this.SetComboBox(this.cbxActor);

        }

        public void SetComboBox(XComboBox cbo)
        {


            layCombo.Reset();
            layCombo.LayoutItems.Clear();
            layCombo.LayoutItems.Add("user", DataType.String);
            layCombo.LayoutItems.Add("user_name", DataType.String);
            layCombo.InitializeLayoutTable();

            /*layCombo.QuerySQL = @"  SELECT '' USER_ID
                                         , '' USER_NM
                                      FROM SYS.DUAL
                                    UNION
                                    SELECT A.USER_ID
                                         , A.USER_NM
                                      FROM ADM3200 A
                                     WHERE A.HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()
                                       AND A.USER_GROUP  = 'XRT'
                                       AND A.USER_GUBUN  = '3'
                                       AND NVL(A.USER_END_YMD, '9998/12/31') >= :f_query_date
                                    ORDER BY 1 NULLS FIRST";*/

            layCombo.SetBindVarValue("f_query_date", this.dtpToDate.GetDataValue());
            layCombo.ExecuteQuery = LoadLayCombo;
            layCombo.QueryLayout(true);

            if (layCombo.RowCount > 0)
            {
                cbo.SetComboItems(layCombo.LayoutTable, "user_name", "user");
                this.grdOrder.SetComboItems("act_doctor_name", layCombo.LayoutTable, "user_name", "user");
            }
        }

        #region 예약리스트화면 오픈
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
                // cloud service
                XRT0201U00MentArgs args = new XRT0201U00MentArgs();
                XRT0201U00MentResult result =
                    CloudService.Instance.Submit<XRT0201U00MentResult, XRT0201U00MentArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && !("").Equals(result.Ment))
                {
                    openParams.Add("jundal_table", result.Ment);
                }
                /*string cmdStr = @"SELECT MENT FROM OCS0132 WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() AND CODE_TYPE = 'OCS_ACT_SYSTEM' AND CODE = 'OCS_ACT_PART_01'";

                object retVal = Service.ExecuteScalar(cmdStr);

                if (!TypeCheck.IsNull(retVal))
                {
                    openParams.Add("jundal_table", retVal.ToString());
                }*/
            }

            XScreen.OpenScreenWithParam(this, "SCHS", "SCH0201Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }
        #endregion

        #region 재료 그리드 컬럼 체인지 벨리데이팅 처리
        private void grdJaeryo_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "hangmog_code")
            {
                // cloud service
                XRT0201U00GrdJaeryoColumnChangedArgs args = new XRT0201U00GrdJaeryoColumnChangedArgs();
                args.HangmogCode = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code");
                args.SHangmogCode = e.ChangeValue.ToString();
                XRT0201U00GrdJaeryoColumnChangedResult result =
                    CloudService.Instance
                        .Submit<XRT0201U00GrdJaeryoColumnChangedResult, XRT0201U00GrdJaeryoColumnChangedArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success && result.GrdJaeryoItemInfo.Count > 0)
                {
                    grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", result.GrdJaeryoItemInfo[0].HangmogName);
                    grdJaeryo.SetItemValue(e.RowNumber, "suryang", result.GrdJaeryoItemInfo[0].Suryang);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", result.GrdJaeryoItemInfo[0].Danui);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", result.GrdJaeryoItemInfo[0].DanuiName);
                }
                else
                {
                    grdJaeryo.SetItemValue(e.RowNumber, "hangmog_code", DBNull.Value);
                    grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", DBNull.Value);
                    grdJaeryo.SetItemValue(e.RowNumber, "suryang", DBNull.Value);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", DBNull.Value);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", DBNull.Value);
                    grdJaeryo.SetItemValue(e.RowNumber, "nalsu", DBNull.Value);
                    SetMsg(XMsg.GetMsg("M005") + "[" + e.ChangeValue + "]", MsgType.Error);
                }

                /*string cmdStr = @"SELECT B.HANGMOG_NAME
                                       , A.SURYANG
                                       , NVL(A.DANUI,B.ORD_DANUI) DANUI
                                       , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',NVL(A.DANUI,B.ORD_DANUI))         DANUI_NAME
                                    FROM OCS0313 A
                                       , OCS0103 B
                                   WHERE A.HOSP_CODE = :f_hosp_code
                                     AND A.HANGMOG_CODE = :f_hangmog_code
                                     AND A.SET_HANGMOG_CODE = :f_set_hangmog_code
                                     AND B.HOSP_CODE = A.HOSP_CODE
                                     AND B.HANGMOG_CODE = A.SET_HANGMOG_CODE
                                     AND SYSDATE BETWEEN B.START_DATE AND B.END_DATE ";

                BindVarCollection bindVar = new BindVarCollection();
                bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                bindVar.Add("f_hangmog_code", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"));
                bindVar.Add("f_set_hangmog_code", e.ChangeValue.ToString());
                
                

                DataTable dtTable = Service.ExecuteDataTable(cmdStr, bindVar);

                if (!TypeCheck.IsNull(dtTable) && dtTable.Rows.Count > 0)
                {
                    grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", dtTable.Rows[0]["hangmog_name"]);
                    grdJaeryo.SetItemValue(e.RowNumber, "suryang", dtTable.Rows[0]["suryang"]);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", dtTable.Rows[0]["danui"]);
                    grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", dtTable.Rows[0]["danui_name"]);
                }
                else
                {
                    cmdStr = @"SELECT HANGMOG_NAME 
                                    , '1'          SURYANG
                                    , ORD_DANUI    DANUI
                                    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI',ORD_DANUI)   DANUI_NAME
                                 FROM OCS0103
                                WHERE HOSP_CODE = :f_hosp_code
                                  AND HANGMOG_CODE      = :f_hangmog_code
                                  AND IF_INPUT_CONTROL <> 'P'
                                  AND SYSDATE BETWEEN START_DATE AND END_DATE ";

                    bindVar.Clear();
                    bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVar.Add("f_hangmog_code", e.ChangeValue.ToString());

                    dtTable.Reset();

                    dtTable = Service.ExecuteDataTable(cmdStr, bindVar);

                    if (!TypeCheck.IsNull(dtTable) && dtTable.Rows.Count > 0)
                    {
                        grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", dtTable.Rows[0]["hangmog_name"]);
                        grdJaeryo.SetItemValue(e.RowNumber, "suryang", dtTable.Rows[0]["suryang"]);
                        grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", dtTable.Rows[0]["danui"]);
                        grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", dtTable.Rows[0]["danui_name"]);
                    }
                    else
                    {
                        grdJaeryo.SetItemValue(e.RowNumber, "hangmog_code", DBNull.Value);
                        grdJaeryo.SetItemValue(e.RowNumber, "hangmog_name", DBNull.Value);
                        grdJaeryo.SetItemValue(e.RowNumber, "suryang", DBNull.Value);
                        grdJaeryo.SetItemValue(e.RowNumber, "ord_danui", DBNull.Value);
                        grdJaeryo.SetItemValue(e.RowNumber, "ord_danui_name", DBNull.Value);
                        grdJaeryo.SetItemValue(e.RowNumber, "nalsu", DBNull.Value);
                        SetMsg(XMsg.GetMsg("M005") + "[" + e.ChangeValue + "]", MsgType.Error);
                    }*/
            }

        }
        #endregion

        #region 환자 그리드 이미지 셋팅
        private void SetGrdHeaderImage(XEditGrid grid)
        {
            for (int i = 0; i < grid.RowCount; i++)
            {
                // 입원 예약환자.
                if (grid.Name == "grdPaList" && grid.GetItemString(i, "reser_yn") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[16];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "予約患者";
                }

                // 緊急オーダ
                if (grid.Name == "grdPaList" && grid.GetItemString(i, "emergency") == "Y")
                {
                    grid[i + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[18];
                    grid[i + grid.HeaderHeights.Count, 0].ToolTipText = grid[i + grid.HeaderHeights.Count, 0].ToolTipText + "緊急処方";
                }

                /*
                 GRIDのHEADを2行にした場合、ROWのイメージは　「＊２」にセットする。　                 
                 */

                // 至急オーダ
                if (grid.Name == "grdOrder" && grid.GetItemString(i, "dangil_gumsa_result_yn") == "Y")
                {
                    grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[19];
                    grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText = grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText + "至急処方";
                }

                // PORTABLEオーダ
                if (grid.Name == "grdOrder" && grid.GetItemString(i, "portable_yn") == "Y")
                {
                    grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].Image = this.ImageList.Images[20];
                    grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText = grid[(i * grid.HeaderHeights.Count) + grid.HeaderHeights.Count, 0].ToolTipText + "移動撮影";
                }

                // https://sofiamedix.atlassian.net/browse/MED-14587
                if (grid.Name == "grdOrder")
                {
                    this.grdOrder.SetItemValue(i, "act_doctor", dbxUserId.GetDataValue());
                    this.grdOrder.SetItemValue(i, "act_doctor_name", dbxUserName.GetDataValue());
                }
            }
        }
        #endregion

        #region 환자리스트그리드 이미지 처리
        private void grdPaList_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SetGrdHeaderImage(grdPaList);

            this.QueryTime = TimeVal;

            // 画面のALARMが活性の場合
            if (this.rbxJubsu.Checked && this.useAlarmChkYN.Equals("Y"))
            {
                if (this.grdPaList.RowCount > 0)
                {
                    for (int i = 0; i < grdPaList.RowCount; i++)
                    {
                        // 予約患者の場合は音無
                        if (this.grdPaList.GetItemString(i, "reser_yn").Equals("N"))
                        {
                            // 一般、緊急の音をセットする。
                            if (this.grdPaList.GetItemString(i, "emergency").Equals("Y")) this.playAlarm("XRT_EM");
                            else this.playAlarm("XRT");
                        }
                    }
                }
            }
        }
        #endregion

        #region [playAlarm] 撮影区分別にAlarmを設定
        private void playAlarm(string part)
        {
            try
            {
                if (part.Equals("XRT"))
                    //XMessageBox.Show(this.alarmFilePath_XRT);
                    Kernel32.PlaySound(this.alarmFilePath_XRT, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else if (part.Equals("XRT_EM"))
                    //XMessageBox.Show(this.alarmFilePath_XRT_EM);
                    Kernel32.PlaySound(this.alarmFilePath_XRT_EM, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
                else
                    IHIS.Framework.Kernel32.Nofify();
                //Kernel32.PlaySound(this.alarmFilePath_XRT, IntPtr.Zero, Win32.SoundFlags.SND_FILENAME | Win32.SoundFlags.SND_ASYNC);
            }
            catch { }
        }
        #endregion

        #region grid backColor setting
        private void SetGrdBackColor(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            if (grid.Name == "grdPaList")
            {
                if (grid.GetItemString(e.RowNumber, "reser_yn") == "Y")
                {
                    e.BackColor = (XColor.XMatrixColHeaderBackColor).Color;
                }

                // 緊急オーダは「Color.Pink」セット
                if (grid.GetItemString(e.RowNumber, "emergency") == "Y")
                {
                    e.BackColor = Color.Pink;
                }
            }

            if (grid.Name == "grdOrder")
            {
                // 緊急オーダは「Color.Pink」セット
                if (grid.GetItemString(e.RowNumber, "emergency") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    e.BackColor = Color.Pink;
                }

                // 至急オーダは「Color.MistyRose」セット
                if (grid.GetItemString(e.RowNumber, "dangil_gumsa_result_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    e.BackColor = Color.MistyRose;
                }

                // 受付処理オーダの項目文字色セット
                if (grid.GetItemString(e.RowNumber, "jubsu_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    e.ForeColor = Color.ForestGreen;
                }

                // 実施処理オーダの項目文字色セット
                if (grid.GetItemString(e.RowNumber, "act_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    e.ForeColor = Color.Blue;
                }

                // I/F転送可否取得後、項目文字色セット
                //string if_data_send_yn = this.chkIfSendYN(this.grdOrder.CurrentRowNumber);
               
                if (grid.GetItemString(e.RowNumber, "if_data_send_yn") == "Y" && (e.ColName == "hangmog_name" || e.ColName == "hangmog_code"))
                {
                    e.ForeColor = Color.Red;
                }
               
            }
        }
        #endregion

        #region 그리드 셀패인팅 이벤트
        private void grdPaList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
            if (e.DataRow["trial_patient"].ToString() == "Y")
            {
                grdPaList[e.RowNumber + 1, 4].ToolTipText = Resources.SMS_TRIAL;
            }
            if (e.DataRow["trial_patient"].ToString() == "N")
            {
                grdPaList[e.RowNumber + 1, 4].ToolTipText = " ";
            }
        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            SetGrdBackColor(sender, e);
        }
        #endregion

        #region 오더 그리드 이미지 셋팅
        private void grdOrder_QueryEnd(object sender, QueryEndEventArgs e)
        {
            SetGrdHeaderImage(grdOrder);
        }
        #endregion

        #region grdOrder_GridColumnProtectModify　「実施チェックコントロール」
        private void grdOrder_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName == "order_remark" && e.DataRow["old_act_yn"].ToString() == "Y")
                e.Protect = true;

            // X線透視「DR」ではない場合、非活性化する。
            if (e.ColName == "xrt_dr_yn" && e.DataRow["jundal_part"].ToString() != "DR")
                e.Protect = true;

            // 現在ROW取得
            string result = this.chkIfSendYN(this.grdOrder.CurrentRowNumber);
            //Update logic VN Hospital
            if(NetInfo.Language == LangMode.Jr)
            {
                // 実施チェックの制御
                if (e.ColName.Equals("jubsu_yn") && result.ToString() == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    e.Protect = true;
                }

                // 透視チェックの制御
                if (e.ColName.Equals("act_yn") && result.ToString() == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    e.Protect = true;
                }

                // 透視チェックの制御
                if (e.ColName.Equals("xrt_dr_yn") && result.ToString() == "Y")
                {
                    XMessageBox.Show(Resources.XMessageBox2, Resources.XMessageBox_caption2, MessageBoxIcon.Information);
                    e.Protect = true;
                }
            }

        }
        #endregion

        #region [chkIfSendYN(int row)] 現在ROWのI/F転送可否取得
        private string chkIfSendYN(int row)
        {
            // cloud service
            string rtnVal = "N";
            XRT0201U00DataSendYnArgs args = new XRT0201U00DataSendYnArgs();
            args.InOutGubun = this.grdOrder.GetItemString(row, "in_out_gubun");
            args.Pkocs = this.grdOrder.GetItemString(row, "pkocs");
            XRT0201U00DataSendYnResult result =
                CloudService.Instance.Submit<XRT0201U00DataSendYnResult, XRT0201U00DataSendYnArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                rtnVal = result.Result;
            }
            /*
            string rtnVal = "";
            string strCmd = "";
            BindVarCollection bindVar = new BindVarCollection();

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_pkocs", this.grdOrder.GetItemString(row, "pkocs"));

            if (this.grdOrder.GetItemString(row, "in_out_gubun") == "O") //외래
            {
                strCmd = @"SELECT A.IF_DATA_SEND_YN 
                             FROM OCS1003 A 
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.PKOCS1003 = :f_pkocs";
            }
            else
            {
                strCmd = @"SELECT A.IF_DATA_SEND_YN 
                             FROM OCS2003 A 
                            WHERE A.HOSP_CODE = :f_hosp_code
                              AND A.PKOCS2003 = :f_pkocs";
            }
            object result = Service.ExecuteScalar(strCmd, bindVar);

            if (TypeCheck.IsNull(result)) rtnVal = "N";
            else rtnVal = result.ToString();*/

            return rtnVal;
        }
        #endregion

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

        private void grdOrder_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            // I/F転送可否取得
            string if_data_send_yn = this.chkIfSendYN(e.CurrentRow);

            // 完了TABで、会計転送未処理の場合
            if (this.rbxActEnd.Checked && !if_data_send_yn.Equals("Y"))
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

                // 材料に変更がある場合
                if (this.grdOrder.GetItemString(e.CurrentRow, "jubsu_yn").Equals("Y") && this.grdOrder.GetItemString(e.CurrentRow, "act_yn").Equals("Y"))
                {
                    if ((drState != DataRowState.Unchanged) || (grdJaeryo.DeletedRowCount > 0))
                    {
                        if (XMessageBox.Show(Resources.XMessageBox5, Resources.XMessageBox5_Caption, MessageBoxButtons.YesNo) == DialogResult.Yes) this.updJaeryoProcess();
                        else return;
                    }
                }
            }
        }

        private void paBox_Validated(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
            lbSuname.Text = paBox.SuName;
        }

        #region grdOrder_GridFindClick, grdOrder_GridFindSelected [GRID FIND関連イベント]
        private void grdOrder_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            switch (e.ColName)
            {
                case "act_doctor_name":
                    this.fwkActor.FormText = Resources.fwkActorFormText2;
                    this.fwkActor.ColInfos[0].HeaderText = Resources.fwkActorHeader2;
                    this.fwkActor.ColInfos[0].ColWidth = 80;
                    this.fwkActor.ColInfos[1].HeaderText = Resources.fwkActorHeader3;
                    this.fwkActor.ColInfos[1].ColWidth = 150;

                    this.fwkActor.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    break;
            }
        }

        private void grdOrder_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            string userID = e.ReturnValues[0].ToString();
            string userNM = e.ReturnValues[1].ToString();

            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor", userID);
            this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", userNM);
        }

        private void grdOrder_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            string input_id = this.grdOrder.GetItemString(e.RowNumber, "act_doctor_name");

            switch (e.ColName)
            {
                case "act_doctor_name":
                    SingleLayout ocsCommon = new SingleLayout();
                    /*ocsCommon.QuerySQL = @"SELECT USER_NM
                                             FROM ADM3200
                                            WHERE HOSP_CODE   = :f_hosp_code
                                              AND USER_GROUP  = 'XRT'
                                              AND USER_ID     = :f_user_id";*/
                    // cloud service
                    ocsCommon.ParamList = CreateOcsCommonParamList();
                    ocsCommon.ExecuteQuery = LoadOcsCommon;

                    ocsCommon.LayoutItems.Add("user_nm");
                    ocsCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    ocsCommon.SetBindVarValue("f_user_id", input_id);

                    if (ocsCommon.QueryLayout())
                    {
                        if (ocsCommon.GetItemValue("user_nm").ToString() != "")
                        {
                            //this.grdOrder.SetItemValue(e.RowNumber, "act_doctor_name", ocsCommon.GetItemValue("user_nm").ToString());
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
                    break;
            }
        }
        #endregion

        #region [checkNaewonYn] 診療終了可否チェック
        private bool checkNaewonYn()
        {
            bool rtnVal = false;

            string pkout1001 = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "naewon_key");

            // cloud service
            XRT0201U00CheckNaewonYnArgs args = new XRT0201U00CheckNaewonYnArgs();
            args.Pkout1001 = pkout1001;
            XRT0201U00CheckNaewonYnResult result =
                CloudService.Instance.Submit<XRT0201U00CheckNaewonYnResult, XRT0201U00CheckNaewonYnArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                rtnVal = result.Result.Equals("Y");
            }
            /*string cmdText = @"SELECT DECODE(A.NAEWON_YN, 'E', 'Y', 'N')  END_YN
                                 FROM OUT1001 A
                                WHERE A.HOSP_CODE = FN_ADM_LOAD_HOSP_CODE() 
                                  AND A.PKOUT1001 = '" + pkout1001 + "'";

            object retVal = Service.ExecuteScalar(cmdText);

            if (!TypeCheck.IsNull(retVal))
            {
                rtnVal = retVal.ToString().Equals("Y")? true : false;
            }*/

            return rtnVal;
        }
        #endregion

        #region 타이머 관련
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lbTime.Text = (this.QueryTime / 1000).ToString();
            this.QueryTime = this.QueryTime - 1000;

            if (QueryTime == 0)
            {
                // 受付TABの場合、再照会
                if (this.rbxJubsu.Checked) this.btnList.PerformClick(FunctionType.Query);
                else
                    // 受付TABが選択される。
                    this.rbxJubsu.Checked = true;

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

        private void PostTimerValidating()
        {
            this.txtTimeInterval.SetDataValue(this.TimeVal.ToString());
        }

        private void cboTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.timer1.Stop();

            this.tbxTimer.SetDataValue("Y");
            this.txtTimeInterval.SetEditValue(this.cboTime.GetDataValue());
            this.txtTimeInterval.AcceptData();

            this.timer1.Start();
        }
        #endregion

        #region [grdJaeryo_QueryEnd]
        private void grdJaeryo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.mlayGrdJaeryo = this.grdJaeryo.CloneToLayout();
        }
        #endregion

        private void btnRadioData_Click(object sender, EventArgs e)
        {
            string bunho = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "bunho");
            string suname = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "suname");
            string suname2 = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "suname2");
            string birth = this.dbxBirth.Text;
            string sexAge = this.dbxSexAge.Text;

            string orderDate = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "order_date");

            string in_out_gubun = this.grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "in_out_gubun");

            ManagementRADIOLEVEL dlg = new ManagementRADIOLEVEL(bunho, suname, suname2, birth, sexAge, orderDate, in_out_gubun);

            dlg.ShowDialog();
        }

        #region cloud service

        private IList<object[]> LoadDataCboTime(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            ComboNUR0102CboTimeArgs args = new ComboNUR0102CboTimeArgs();
            ComboResult result = CacheService.Instance.Get<ComboNUR0102CboTimeArgs, ComboResult>(args, delegate(ComboResult cboResult)
                {
                    return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
                           cboResult.ComboItem.Count > 0;
                });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
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

        private IList<object[]> LoadDataCboPart(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            OCSACTCboSystemArgs args = new OCSACTCboSystemArgs();
            ComboResult result = CacheService.Instance.Get<OCSACTCboSystemArgs, ComboResult>(args, delegate(ComboResult cboResult)
                {
                    return cboResult.ExecutionStatus == ExecutionStatus.Success && cboResult.ComboItem != null &&
                           cboResult.ComboItem.Count > 0;
                });
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
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

        private XRT0201U00LoadScreenResult GetLoadScreenData()
        {
            string io_gubun = "1";//all = 1, out = 2, inp = 3, todayOut = 4

            if (rbxIOAll.Checked) io_gubun = "1";
            else if (rbxOut.Checked) io_gubun = "2";
            else if (rbxInp.Checked) io_gubun = "3";
            else io_gubun = "4";

            string act_gubun = "1";//all = 1, no act = 2, act = 3

            if (rbxAll.Checked) act_gubun = "1";
            else if (rbxJubsu.Checked) act_gubun = "2";
            else if (rbxAct.Checked) act_gubun = "3";
            else act_gubun = "4";

            XRT0201U00LoadScreenArgs args = new XRT0201U00LoadScreenArgs();
            args.QueryDate = this.dtpToDate.GetDataValue();
            args.IoGubun = io_gubun;
            args.ActGubun = act_gubun;
            args.JundalTableCode = "OCS_ACT_PART_01";
            args.JundalPart = cboPart.GetDataValue();
            args.Bunho = paBox.BunHo;
            args.FromDate = dtpFromDate.GetDataValue();
            args.ToDate = dtpToDate.GetDataValue();
            return CloudService.Instance.Submit<XRT0201U00LoadScreenResult, XRT0201U00LoadScreenArgs>(args);
        }

        private IList<object[]> LoadLayCombo(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (loadScreenResult.ExecutionStatus == ExecutionStatus.Success)
            {
                List<XRT0201U00CbxActorItemInfo> cbxList = loadScreenResult.CbxActorItemInfo;
                foreach (XRT0201U00CbxActorItemInfo info in cbxList)
                {
                    dataList.Add(new object[]
	                {
	                    info.UserId,
	                    info.UserName
	                });
                }
            }

            return dataList;
        }

        private IList<object[]> LoadGrdPaListCombined(BindVarCollection varlist)
        {
            IList<object[]> dataList = new List<object[]>();
            if (loadScreenResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00GrdPaListItemInfo item in loadScreenResult.GrdPaListItemInfo)
                {
                    object[] objects = 
				    { 
                        item.TrialPatient,
                        item.InOutGubun,
					    item.OrderDate, 
					    item.OrderTime, 
					    item.Bunho, 
					    item.Suname, 
					    item.Suname2, 
					    item.Gwa, 
					    item.GwaName, 
					    item.Doctor, 
					    item.DoctorName, 
					    item.ReserYn, 
					    item.Emergency, 
					    item.NaewonKey, 
					    item.JundalTable
				    };
                    dataList.Add(objects);
                }
            }

            return dataList;
        }

        private List<string> CreateGrdPaListParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_io_gubun");
            paramList.Add("f_act_gubun");
            paramList.Add("f_jundal_table_code");
            paramList.Add("f_jundal_part");
            paramList.Add("f_bunho");
            paramList.Add("f_from_date");
            paramList.Add("f_to_date");
            return paramList;
        }

        private IList<object[]> LoadGrdPaList(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00GrdPaListArgs args = new XRT0201U00GrdPaListArgs();
            args.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            args.ActGubun = bc["f_act_gubun"] != null ? bc["f_act_gubun"].VarValue : "";
            args.JundalTableCode = bc["f_jundal_table_code"] != null ? bc["f_jundal_table_code"].VarValue : "";
            args.JundalPart = bc["f_jundal_part"] != null ? bc["f_jundal_part"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            XRT0201U00GrdPaListResult result = CloudService.Instance.Submit<XRT0201U00GrdPaListResult, XRT0201U00GrdPaListArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00GrdPaListItemInfo item in result.GrdPaListItemInfo)
                {
                    object[] objects = 
				{ 
                    item.TrialPatient,
					item.InOutGubun, 
					item.OrderDate, 
					item.OrderTime, 
					item.Bunho, 
					item.Suname, 
					item.Suname2, 
					item.Gwa, 
					item.GwaName, 
					item.Doctor, 
					item.DoctorName, 
					item.ReserYn, 
					item.Emergency, 
					item.NaewonKey, 
					item.JundalTable
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateGrdOrderParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_io_gubun");
            paramList.Add("f_act_gubun");
            paramList.Add("f_reser_yn");
            paramList.Add("f_order_date");
            paramList.Add("f_from_date");
            paramList.Add("f_to_date");
            paramList.Add("f_naewon_key");
            paramList.Add("f_emergency");
            paramList.Add("f_jundal_table_code");
            paramList.Add("f_jundal_part");
            paramList.Add("f_bunho");
            paramList.Add("f_doctor");
            return paramList;
        }

        private List<object[]> LoadGrdOrder(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00GrdOrderArgs args = new XRT0201U00GrdOrderArgs();
            args.IoGubun = bc["f_io_gubun"] != null ? bc["f_io_gubun"].VarValue : "";
            args.ActGubun = bc["f_act_gubun"] != null ? bc["f_act_gubun"].VarValue : "";
            args.ReserYn = bc["f_reser_yn"] != null ? bc["f_reser_yn"].VarValue : "";
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.NaewonKey = bc["f_naewon_key"] != null ? bc["f_naewon_key"].VarValue : "";
            args.Emergency = bc["f_emergency"] != null ? bc["f_emergency"].VarValue : "";
            args.JundalTableCode = bc["f_jundal_table_code"] != null ? bc["f_jundal_table_code"].VarValue : "";
            args.JundalPart = bc["f_jundal_part"] != null ? bc["f_jundal_part"].VarValue : "";
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.Doctor = bc["f_doctor"] != null ? bc["f_doctor"].VarValue : "";
            XRT0201U00GrdOrderResult result = CloudService.Instance.Submit<XRT0201U00GrdOrderResult, XRT0201U00GrdOrderArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00GrdOrderItemInfo item in result.GrdOrderItemInfo)
                {
                    object[] objects = 
				{ 
					item.InOutGubun, 
					item.Pkocs, 
					item.JubsuYn, 
					item.HangmogCode, 
					item.HangmogName, 
					item.JubsuDate, 
					item.JubsuTime, 
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
					item.InputDoctor, 
					item.OrderRemark, 
					item.Birth, 
					item.SexAge, 
					item.WeightHeight, 
					item.InOutGubunName, 
					item.PaceMakerYn, 
					item.HodongHocode, 
					item.LastGumsaDate, 
					item.UnusualInfo, 
					item.JundalTable, 
					item.JundalPart, 
					item.Fkout1001, 
					item.ReserYn, 
					item.Emergency, 
					item.SunabSuryang, 
					item.OldActYn, 
					item.IfDataSendYn, 
					item.XrtDrYn, 
					item.ActYn, 
					item.ActingDate, 
					item.ActingTime, 
					item.DangilGumsaResultYn, 
					item.PortableYn, 
					item.DataRowState
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private XRT0201U00GrdOrderRowFocusChangedResult GetGrdOrderRowFocusChanged(RowFocusChangedEventArgs e)
        {
            XRT0201U00GrdOrderRowFocusChangedArgs args = new XRT0201U00GrdOrderRowFocusChangedArgs();
            args.IoGubun = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "in_out_gubun");
            args.OrderDate = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "order_date");
            args.Fkocs = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkocs");
            args.JundalPart = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "jundal_part");
            args.Bunho = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "bunho");
            args.HangmogCode = grdOrder.GetItemString(e.CurrentRow, "hangmog_code");
            args.GrdOrderRowCount = grdOrder.RowCount.ToString();
            return CloudService.Instance.Submit<XRT0201U00GrdOrderRowFocusChangedResult, XRT0201U00GrdOrderRowFocusChangedArgs>(args);
        }

        private List<object[]> LoadGrdJaeryoCombined(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (grdOrderRowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00GrdJaeryoItemInfo item in grdOrderRowFocusChangedResult.GrdJaeryoItemInfo)
                {
                    object[] objects = 
						{ 
                        item.JaeryoCode, 
                        item.JaeryoName, 
                        item.Suryang, 
                        item.OrdDanui, 
                        item.Pkinv1001, 
                        item.Bunho, 
                        item.OrderDate, 
                        item.InOutGubun, 
                        item.ActingDate, 
                        item.ActingBuseo, 
                        item.FkocsInv, 
                        item.FkocsXrt, 
                        item.DanuiName, 
                        item.Bunryu2, 
                        item.JaeryoGubun, 
                        item.JaeryoYn, 
                        item.InputControl, 
                        item.BunCode, 
                        item.Nalsu, 
                        item.DataRowState
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadGrdSangByung(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (grdOrderRowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in grdOrderRowFocusChangedResult.SangName)
                {
                    object[] objects = 
						{ 
                        item.DataValue
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadDefaultJearyo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            if (grdOrderRowFocusChangedResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00DefaultJearyoItemInfo item in grdOrderRowFocusChangedResult.DefaultJearyoItemInfo)
                {
                    object[] objects = 
						{ 
                        item.SetHangmogCode, 
                        item.Suryang, 
                        item.Danui, 
                        item.DanuiName
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private XRT0201U00LayPacsResult GetLayPacsData()
        {
            XRT0201U00LayPacsArgs args = new XRT0201U00LayPacsArgs();
            args.HangmogCode = this.grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "hangmog_code");
            XRT0201U00LayPacsResult result =
                CloudService.Instance.Submit<XRT0201U00LayPacsResult, XRT0201U00LayPacsArgs>(args);
            return result;
        }

        private List<object[]> LoadLayPacsInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00LayPacsResult result = layPacsResult;
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0000Q00LayPacsInfoListItemInfo item in result.LayPacsItemInfo)
                {
                    object[] objects = 
						{ 
                        item.Code, 
                        item.CodeName, 
                        item.CodeValue
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateFwkOrdDanuiParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_hangmog_code");
            return paramList;
        }

        private List<object[]> LoadFwkOrdDanui(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00FwkOrdDanuiArgs args = new XRT0201U00FwkOrdDanuiArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            XRT0201U00FwkOrdDanuiResult result = CloudService.Instance.Submit<XRT0201U00FwkOrdDanuiResult, XRT0201U00FwkOrdDanuiArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00FwkOrdDanuiItemInfo item in result.FwkOrdDanuiItemInfo)
                {
                    object[] objects = 
				{ 
					item.OrdDanui, 
					item.OrdDanuiName, 
					item.Seq
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadFwkOrdDanuiName(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00FwkOrdDanuiNameArgs args = new XRT0201U00FwkOrdDanuiNameArgs();
            args.HangmogCode = bc["f_hangmog_code"] != null ? bc["f_hangmog_code"].VarValue : "";
            XRT0201U00FwkOrdDanuiResult result = CloudService.Instance.Submit<XRT0201U00FwkOrdDanuiResult, XRT0201U00FwkOrdDanuiNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0201U00FwkOrdDanuiItemInfo item in result.FwkOrdDanuiItemInfo)
                {
                    object[] objects = 
				{ 
					item.OrdDanui, 
					item.OrdDanuiName, 
					item.Seq
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<object[]> LoadFwkActor(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00FwkActorArgs args = new XRT0201U00FwkActorArgs();
            XRT0201U00FwkActorResult result = CloudService.Instance.Submit<XRT0201U00FwkActorResult, XRT0201U00FwkActorArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.UserItemInfo)
                {
                    object[] objects = 
				{ 
					item.Code, 
					item.CodeName
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateOcsCommonParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_user_id");
            return paramList;
        }

        private List<object[]> LoadOcsCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00OcsCommonArgs args = new XRT0201U00OcsCommonArgs();
            args.UserId = bc["f_user_id"] != null ? bc["f_user_id"].VarValue : "";
            XRT0201U00OcsCommonResult result = CloudService.Instance.Submit<XRT0201U00OcsCommonResult, XRT0201U00OcsCommonArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DataStringListItemInfo item in result.UserNameItemInfo)
                {
                    object[] objects = 
				{ 
					item.DataValue
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private XRT0201U00LayConstantResult GetLayConstantData()
        {
            XRT0201U00LayConstantArgs args = new XRT0201U00LayConstantArgs();
            XRT0201U00LayConstantResult result = CloudService.Instance.Submit<XRT0201U00LayConstantResult, XRT0201U00LayConstantArgs>(args);
            return result;
        }

        private List<object[]> LoadLayConstantInfo(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            XRT0201U00LayConstantResult result = layConstantResult;
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (XRT0000Q00LayPacsInfoListItemInfo item in result.LayConstantItemInfo)
                {
                    object[] objects = 
						{ 
                        item.Code, 
                        item.CodeName, 
                        item.CodeValue
						};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<XRT0201U00GrdOrderItemInfo> GetListGrdOrderForSaveLayout()
        {
            List<XRT0201U00GrdOrderItemInfo> lstResult = new List<XRT0201U00GrdOrderItemInfo>();

            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                if (grdOrder.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0201U00GrdOrderItemInfo item = new XRT0201U00GrdOrderItemInfo();
                item.InOutGubun = grdOrder.GetItemString(i, "in_out_gubun");
                item.Pkocs = grdOrder.GetItemString(i, "pkocs");
                item.JubsuYn = grdOrder.GetItemString(i, "jubsu_yn");
                item.HangmogCode = grdOrder.GetItemString(i, "hangmog_code");
                item.HangmogName = grdOrder.GetItemString(i, "hangmog_name");
                item.JubsuDate = grdOrder.GetItemString(i, "jubsu_date");
                item.JubsuTime = grdOrder.GetItemString(i, "jubsu_time");
                item.OrderDate = grdOrder.GetItemString(i, "order_date");
                item.OrderTime = grdOrder.GetItemString(i, "order_time");
                item.ReserDate = grdOrder.GetItemString(i, "reser_date");
                item.ReserTime = grdOrder.GetItemString(i, "reser_time");
                item.ActDoctor = grdOrder.GetItemString(i, "act_doctor");
                item.ActDoctorName = grdOrder.GetItemString(i, "act_doctor_name");
                item.ActBuseo = grdOrder.GetItemString(i, "act_buseo");
                item.ActGwa = grdOrder.GetItemString(i, "act_gwa");
                item.Bunho = grdOrder.GetItemString(i, "bunho");
                item.Suname = grdOrder.GetItemString(i, "suname");
                item.Suname2 = grdOrder.GetItemString(i, "suname2");
                item.Gwa = grdOrder.GetItemString(i, "gwa");
                item.GwaName = grdOrder.GetItemString(i, "gwa_name");
                item.Doctor = grdOrder.GetItemString(i, "doctor");
                item.DoctorName = grdOrder.GetItemString(i, "doctor_name");
                item.InputDoctor = grdOrder.GetItemString(i, "input_doctor");
                item.OrderRemark = grdOrder.GetItemString(i, "order_remark");
                item.Birth = grdOrder.GetItemString(i, "birth");
                item.SexAge = grdOrder.GetItemString(i, "sex_age");
                item.WeightHeight = grdOrder.GetItemString(i, "height_weight");
                item.InOutGubunName = grdOrder.GetItemString(i, "in_out_gubun_name");
                item.PaceMakerYn = grdOrder.GetItemString(i, "pace_maker_yn");
                item.HodongHocode = grdOrder.GetItemString(i, "hodong_hocode");
                item.LastGumsaDate = grdOrder.GetItemString(i, "last_gumsa_date");
                item.UnusualInfo = grdOrder.GetItemString(i, "unusual_info");
                item.JundalTable = grdOrder.GetItemString(i, "jundal_table");
                item.JundalPart = grdOrder.GetItemString(i, "jundal_part");
                item.Fkout1001 = grdOrder.GetItemString(i, "fkout1001");
                item.ReserYn = grdOrder.GetItemString(i, "reser_yn");
                item.Emergency = grdOrder.GetItemString(i, "emergency");
                item.SunabSuryang = grdOrder.GetItemString(i, "sunab_suryang");
                item.OldActYn = grdOrder.GetItemString(i, "old_act_yn");
                item.IfDataSendYn = grdOrder.GetItemString(i, "if_data_send_yn");
                item.XrtDrYn = grdOrder.GetItemString(i, "xrt_dr_yn");
                item.ActYn = grdOrder.GetItemString(i, "act_yn");
                item.ActingDate = grdOrder.GetItemString(i, "acting_date");
                item.ActingTime = grdOrder.GetItemString(i, "acting_time");
                item.DangilGumsaResultYn = grdOrder.GetItemString(i, "dangil_gumsa_result_yn");
                item.PortableYn = grdOrder.GetItemString(i, "portable_yn");

                item.DataRowState = grdOrder.GetRowState(i).ToString();
                lstResult.Add(item);
            }
            return lstResult;
        }

        private List<XRT0201U00GrdJaeryoItemInfo> GetListGrdJaeryoForSaveLayout()
        {
            List<XRT0201U00GrdJaeryoItemInfo> lstResult = new List<XRT0201U00GrdJaeryoItemInfo>();

            for (int i = 0; i < grdJaeryo.RowCount; i++)
            {
                if (grdJaeryo.GetRowState(i) == DataRowState.Unchanged) continue;

                XRT0201U00GrdJaeryoItemInfo item = new XRT0201U00GrdJaeryoItemInfo();
                item.JaeryoCode = grdJaeryo.GetItemString(i, "hangmog_code");
                item.JaeryoName = grdJaeryo.GetItemString(i, "hangmog_name");
                item.Suryang = grdJaeryo.GetItemString(i, "suryang");
                item.OrdDanui = grdJaeryo.GetItemString(i, "ord_danui");
                item.Pkinv1001 = grdJaeryo.GetItemString(i, "pkinv1001");
                item.Bunho = grdJaeryo.GetItemString(i, "bunho");
                item.OrderDate = grdJaeryo.GetItemString(i, "order_date");
                item.InOutGubun = grdJaeryo.GetItemString(i, "in_out_gubun");
                item.ActingDate = grdJaeryo.GetItemString(i, "acting_date");
                item.ActingBuseo = grdJaeryo.GetItemString(i, "acting_buseo");
                item.FkocsInv = grdJaeryo.GetItemString(i, "fkocs_inv");
                item.FkocsXrt = grdJaeryo.GetItemString(i, "fkocs_xrt");
                item.DanuiName = grdJaeryo.GetItemString(i, "ord_danui_name");
                item.Bunryu2 = grdJaeryo.GetItemString(i, "bunryu2");
                item.JaeryoGubun = grdJaeryo.GetItemString(i, "jaeryo_gubun");
                item.JaeryoYn = grdJaeryo.GetItemString(i, "jaeryo_yn");
                item.InputControl = grdJaeryo.GetItemString(i, "input_control");
                item.BunCode = grdJaeryo.GetItemString(i, "bun_code");
                item.Nalsu = grdJaeryo.GetItemString(i, "nalsu");

                item.DataRowState = grdJaeryo.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdJaeryo.DeletedRowTable)
            {
                foreach (DataRow dr in grdJaeryo.DeletedRowTable.Rows)
                {
                    XRT0201U00GrdJaeryoItemInfo item = new XRT0201U00GrdJaeryoItemInfo();
                    item.JaeryoCode = Convert.ToString(dr["hangmog_code"]);
                    item.JaeryoName = Convert.ToString(dr["hangmog_name"]);
                    item.Suryang = Convert.ToString(dr["suryang"]);
                    item.OrdDanui = Convert.ToString(dr["ord_danui"]);
                    item.Pkinv1001 = Convert.ToString(dr["pkinv1001"]);
                    item.Bunho = Convert.ToString(dr["bunho"]);
                    item.OrderDate = Convert.ToString(dr["order_date"]);
                    item.InOutGubun = Convert.ToString(dr["in_out_gubun"]);
                    item.ActingDate = Convert.ToString(dr["acting_date"]);
                    item.ActingBuseo = Convert.ToString(dr["acting_buseo"]);
                    item.FkocsInv = Convert.ToString(dr["fkocs_inv"]);
                    item.FkocsXrt = Convert.ToString(dr["fkocs_xrt"]);
                    item.DanuiName = Convert.ToString(dr["ord_danui_name"]);
                    item.Bunryu2 = Convert.ToString(dr["bunryu2"]);
                    item.JaeryoGubun = Convert.ToString(dr["jaeryo_gubun"]);
                    item.JaeryoYn = Convert.ToString(dr["jaeryo_yn"]);
                    item.InputControl = Convert.ToString(dr["input_control"]);
                    item.BunCode = Convert.ToString(dr["bun_code"]);
                    item.Nalsu = Convert.ToString(dr["nalsu"]);
                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private XRT0201U00GrdPaListItemInfo GetGrdPaItemForSaveLayout()
        {
            XRT0201U00GrdPaListItemInfo item = new XRT0201U00GrdPaListItemInfo();
            item.InOutGubun = grdPaList.GetItemString(this.grdPaList.CurrentRowNumber, "in_out_gubun");
            return item;
        }

        private XRT0201U00GrdOrderItemInfo GetGrdOrderItemForSaveLayout()
        {
            int currentRowNumber = this.grdOrder.CurrentRowNumber;
            XRT0201U00GrdOrderItemInfo item = new XRT0201U00GrdOrderItemInfo();
            item.JubsuYn = grdOrder.GetItemString(currentRowNumber, "jubsu_yn");
            item.ActYn = grdOrder.GetItemString(currentRowNumber, "act_yn");
            item.OrderDate = grdOrder.GetItemString(currentRowNumber, "order_date");
            item.InOutGubun = grdOrder.GetItemString(currentRowNumber, "in_out_gubun");
            item.JundalPart = grdOrder.GetItemString(currentRowNumber, "jundal_part");
            item.Pkocs = grdOrder.GetItemString(currentRowNumber, "pkocs");

            // 2015.08.01 AnhNV Added START
            item.Pkocs = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "pkocs");
            item.OrderDate = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "order_date");
            item.JundalPart = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "jundal_part");
            item.ActingDate = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "acting_date");
            item.InOutGubun = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "in_out_gubun");
            item.Bunho = grdOrder.GetItemString(this.grdOrder.CurrentRowNumber, "bunho");
            // 2015.08.01 AnhNV Added END
            return item;
        }

        private List<object[]> LoadDataXEditGridCell(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            OCSACTCboIoGubunArgs args = new OCSACTCboIoGubunArgs();
            ComboResult result =
                CacheService.Instance.Get<OCSACTCboIoGubunArgs, ComboResult>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                List<ComboListItemInfo> cboList = result.ComboItem;
                foreach (ComboListItemInfo info in cboList)
                {
                    res.Add(new object[]
	                {
	                    info.Code,
	                    info.CodeName
	                });
                }
            }
            return res;
        }
        #endregion

        private void grdPaList_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell1.ExecuteQuery = LoadDataXEditGridCell;
        }

        #region https://sofiamedix.atlassian.net/browse/MED-14587

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-14587
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFindUser_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxUserId.GetDataValue());
            param.Add("user_name", dbxUserName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        #endregion
    }

    internal class sendIFinfo
    {
        public string pkOcs = "";
        public string inOutGubun = "";
        public string ifSysGubun = "";
        public string ifCmdGubun = "";
        public string userID = "";
        public string seq = "";
    }
}
