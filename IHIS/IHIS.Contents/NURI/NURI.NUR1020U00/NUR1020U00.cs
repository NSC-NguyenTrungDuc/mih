#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.NURI.Properties;

#endregion

namespace IHIS.NURI
{
    /// <summary>
    /// NUR1020U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR1020U00 : IHIS.Framework.XScreen
    {
        #region 추가사항
        private string sysid = string.Empty;
        private string screen = string.Empty;
        //private string flag = "Y";	//flag가 N일때는 날짜 변경으로 인한 조회를 하지 않는다.
        private object currCtl = null; //현재 선택 된 컨트롤

        int paListRownum = 0; //현재 선택된 환자의 grid넘버

        //private string DeleteYn = "N";	//삭제여부
        //ArrayList mDeleteTime = new ArrayList(); //추가 2011.12.29 woo

        #endregion

        #region 자동생성

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlLeft;
        private IHIS.Framework.XPanel pnlRight;
        private IHIS.Framework.XDatePicker dtpYmd;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGrid grdPalist;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnGraph;
        private IHIS.Framework.XButton btnCopy;
        private IHIS.Framework.XPanel pnlTopFill;
        private IHIS.Framework.XLabel lblHo_dong;
        private IHIS.Framework.XLabel lblYmd1;
        private IHIS.Framework.XLabel lblMorning;
        private IHIS.Framework.XEditMask emkSikT1;
        private IHIS.Framework.XLabel lblNoon;
        private IHIS.Framework.XEditMask emkSikT2;
        private IHIS.Framework.XLabel lblNight;
        private IHIS.Framework.XEditMask emkSikT3;
        private IHIS.Framework.XButton btnTenDown;
        private IHIS.Framework.XButton btnOneDown;
        private IHIS.Framework.XButton btnOneUp;
        private IHIS.Framework.XButton btnTenUp;
        private IHIS.Framework.XBuseoCombo cboHo_dong;
        private IHIS.Framework.XTextBox txtFkinp1001;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGrid grdData;
        private IHIS.Framework.XEditGridCell xEditGridCell14;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdNUR1020;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
        private IHIS.Framework.XEditGridCell xEditGridCell23;
        private IHIS.Framework.XPanel pnlVspatn_gubun;
        private IHIS.Framework.XLabel lblVspatn_gubun;
        private IHIS.Framework.XBuseoCombo cboVspatn_gubun;
        private IHIS.Framework.MultiLayout layCombo;
        private IHIS.Framework.XButton btnInsert;
        private IHIS.Framework.XEditGridCell xEditGridCell24;
        private IHIS.Framework.XEditGridCell xEditGridCell25;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell27;
        private IHIS.Framework.XEditGrid grdNUR1023;
        private IHIS.Framework.XButton btnDelete;
        private IHIS.Framework.XEditGrid grdNUR1022_IN;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell30;
        private IHIS.Framework.XEditGridCell xEditGridCell32;
        private IHIS.Framework.XEditGridCell xEditGridCell33;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XGridHeader xGridHeader1;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XPanel pnln;
        private IHIS.Framework.XPanel pnlOut;
        private IHIS.Framework.XEditGrid grdNUR1022_OUT;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell35;
        private IHIS.Framework.XEditGridCell xEditGridCell36;
        private IHIS.Framework.XEditGridCell xEditGridCell37;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell39;
        private IHIS.Framework.XEditGridCell xEditGridCell40;
        private IHIS.Framework.XGridHeader xGridHeader2;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell41;
        private IHIS.Framework.XEditGridCell xEditGridCell42;
        private IHIS.Framework.XEditGridCell xEditGridCell43;
        private IHIS.Framework.XEditGridCell xEditGridCell44;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XLabel xLabel1;
        private XPanel xPanel4;
        private XLabel xLabel3;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell45;
        private XButton btnTimeApply;
        private XEditGrid grdDelete;
        private XEditGridCell xEditGridCell46;
        private XEditGridCell xEditGridCell47;
        private XEditGridCell xEditGridCell48;
        private XEditGridCell xEditGridCell49;
        private XPanel pnlNUR1122;
        private XEditGrid grdNUR1122;
        private XEditGridCell xEditGridCell50;
        private XEditGridCell xEditGridCell51;
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private MultiLayout layHangmog;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private XPanel pnlNUR1122btn;
        private XButton btnNUR1122Insert;
        private XButton btnNUR1122Delete;
        private XGridHeader xGridHeader3;
        private XEditGrid grdWatchTemplate;
        private XPanel pnlVital;
        private XPanel pnlFood;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XButton btnNUR0101U00;
        private XButton btnGwa;
        private XLabel xLabel8;
        private XLabel xLabel7;
        private XEditMask emkSikT5;
        private XEditMask emkSikT6;
        private XEditMask emkSikT7;
        private SingleLayout laySiksa;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private SingleLayoutItem singleLayoutItem6;
        private SingleLayoutItem singleLayoutItem7;
        private SingleLayoutItem singleLayoutItem8;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell60;
        private XPanel pnlPad;
        private XButton btnKeypaddel;
        private XButton btnKeypad0;
        private XButton btnKeypaddot;
        private XButton btnKeypad9;
        private XButton btnKeypad8;
        private XButton btnKeypad7;
        private XButton btnKeypad6;
        private XButton btnKeypad5;
        private XButton btnKeypad4;
        private XButton btnKeypad3;
        private XButton btnKeypad2;
        private XButton btnKeypad1;
        private XImageButton xImageButton1;
        private XPanel xPanel7;
        private XButton btnKeyPad;
        private XTextBox txtPadValue;
        private XPanel xPanel3;
        private XButton btnSetValue;
        private XLabel lblPadTitle;
        private XPanel xPanel6;
        private XLabel xLabel4;
        private XPanel xPanel2;
        private XLabel xLabel9;
        private XEditMask emkHeight;
        private XEditMask emkWeight;
        private XLabel xLabel10;
        private XEditMask emkUrineQuantity;
        private XLabel xLabel11;
        private XEditMask emkUrineCnt;
        private XEditMask emkDungCnt;
        private XLabel xLabel12;
        private XPanel pnlCare;
        private XTextBox txtCare;
        private XDictComboBox cboDungsyochi;
        private SingleLayout layNUR7002;
        private SingleLayoutItem singleLayoutItem15;
        private SingleLayoutItem singleLayoutItem16;
        private SingleLayoutItem singleLayoutItem17;
        private SingleLayoutItem singleLayoutItem18;
        private SingleLayoutItem singleLayoutItem19;
        private SingleLayoutItem singleLayoutItem20;
        private SingleLayoutItem singleLayoutItem21;
        private SingleLayoutItem singleLayoutItem22;
        private XLabel xLabel16;
        private XLabel xLabel15;
        private XLabel xLabel14;
        private XLabel xLabel13;
        private XLabel xLabel17;
        private XEditGrid grdCare;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XButton btnSetCare;
        private XEditGridCell xEditGridCell64;
        private XFindBox fbxWriter3;
        private XFindBox fbxWriter2;
        private XFindBox fbxWriter1;
        private XFindWorker fwkWriter;
        private XLabel xLabel5;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XPanel xPanel8;
        private XDisplayBox dbxWriter3;
        private XDisplayBox dbxWriter2;
        private XDisplayBox dbxWriter1;
        private XButton btnNextPatient;
        private MultiLayout layNURList;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private SingleLayoutItem singleLayoutItem9;
        private SingleLayoutItem singleLayoutItem10;
        private SingleLayoutItem singleLayoutItem11;
        private SingleLayoutItem singleLayoutItem12;
        private SingleLayoutItem singleLayoutItem13;
        private SingleLayoutItem singleLayoutItem14;
        private XTextBox txtChuchi;
        private XLabel xLabel18;
        private MultiLayout layWriterBA;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private XEditGridCell xEditGridCell61;
        private XGridHeader xGridHeader4;
        private XGridHeader xGridHeader5;
        private XDictComboBox cboWatchTemplate;
        private XButton btnPreChuchi;
        private XButton btnChiryo;
        private XEditGridCell xEditGridCell65;
        private XPanel pnlHelp;
        private XButton btnHelp;
        private XEditGridCell xEditGridCell66;
        private XPanel pnlSession;
        private XLabel xLabel6;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
        private XLabel xLabel19;
        private XLabel xLabel20;
        private XImageButton xImageButton2;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public NUR1020U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            this.grdData.SavePerformer = new XSavePerformer(this);
            this.grdNUR1020.SavePerformer = this.grdData.SavePerformer;
            this.grdNUR1023.SavePerformer = this.grdData.SavePerformer;
            this.grdDelete.SavePerformer = this.grdData.SavePerformer;  //추가 2012.01.04 woo
            this.grdNUR1122.SavePerformer = this.grdData.SavePerformer; //추가 2012.01.05 woo

            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdData);
            this.SaveLayoutList.Add(this.grdNUR1020);
            this.SaveLayoutList.Add(this.grdNUR1023);

        }
        #endregion

        #region 소멸자
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1020U00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.pnlTopFill = new IHIS.Framework.XPanel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblYmd1 = new IHIS.Framework.XLabel();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.dtpYmd = new IHIS.Framework.XDatePicker();
            this.grdDelete = new IHIS.Framework.XEditGrid();
            this.xEditGridCell46 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell47 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell48 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell49 = new IHIS.Framework.XEditGridCell();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnChiryo = new IHIS.Framework.XButton();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.btnCopy = new IHIS.Framework.XButton();
            this.btnGraph = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdData = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.grdNUR1023 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.btnSetCare = new IHIS.Framework.XButton();
            this.btnHelp = new IHIS.Framework.XButton();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.pnlCare = new IHIS.Framework.XPanel();
            this.pnlHelp = new IHIS.Framework.XPanel();
            this.xImageButton2 = new IHIS.Framework.XImageButton();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.grdCare = new IHIS.Framework.XEditGrid();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.txtCare = new IHIS.Framework.XTextBox();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.cboDungsyochi = new IHIS.Framework.XDictComboBox();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.emkHeight = new IHIS.Framework.XEditMask();
            this.emkWeight = new IHIS.Framework.XEditMask();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.emkUrineQuantity = new IHIS.Framework.XEditMask();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.emkUrineCnt = new IHIS.Framework.XEditMask();
            this.emkDungCnt = new IHIS.Framework.XEditMask();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.btnPreChuchi = new IHIS.Framework.XButton();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.txtChuchi = new IHIS.Framework.XTextBox();
            this.dbxWriter3 = new IHIS.Framework.XDisplayBox();
            this.dbxWriter2 = new IHIS.Framework.XDisplayBox();
            this.dbxWriter1 = new IHIS.Framework.XDisplayBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.fbxWriter3 = new IHIS.Framework.XFindBox();
            this.fwkWriter = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.fbxWriter2 = new IHIS.Framework.XFindBox();
            this.fbxWriter1 = new IHIS.Framework.XFindBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlVital = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnInsert = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.grdNUR1020 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell42 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell44 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell45 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.pnlVspatn_gubun = new IHIS.Framework.XPanel();
            this.btnKeyPad = new IHIS.Framework.XButton();
            this.btnTimeApply = new IHIS.Framework.XButton();
            this.cboVspatn_gubun = new IHIS.Framework.XBuseoCombo();
            this.lblVspatn_gubun = new IHIS.Framework.XLabel();
            this.btnTenDown = new IHIS.Framework.XButton();
            this.btnOneDown = new IHIS.Framework.XButton();
            this.btnOneUp = new IHIS.Framework.XButton();
            this.btnTenUp = new IHIS.Framework.XButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.pnlNUR1122 = new IHIS.Framework.XPanel();
            this.cboWatchTemplate = new IHIS.Framework.XDictComboBox();
            this.pnlNUR1122btn = new IHIS.Framework.XPanel();
            this.btnGwa = new IHIS.Framework.XButton();
            this.btnNUR1122Insert = new IHIS.Framework.XButton();
            this.btnNUR0101U00 = new IHIS.Framework.XButton();
            this.btnNUR1122Delete = new IHIS.Framework.XButton();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.grdNUR1122 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell50 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell51 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.grdWatchTemplate = new IHIS.Framework.XEditGrid();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.pnlFood = new IHIS.Framework.XPanel();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.emkSikT5 = new IHIS.Framework.XEditMask();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.emkSikT6 = new IHIS.Framework.XEditMask();
            this.emkSikT7 = new IHIS.Framework.XEditMask();
            this.lblMorning = new IHIS.Framework.XLabel();
            this.emkSikT1 = new IHIS.Framework.XEditMask();
            this.lblNoon = new IHIS.Framework.XLabel();
            this.lblNight = new IHIS.Framework.XLabel();
            this.emkSikT2 = new IHIS.Framework.XEditMask();
            this.emkSikT3 = new IHIS.Framework.XEditMask();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.pnlOut = new IHIS.Framework.XPanel();
            this.grdNUR1022_OUT = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.pnln = new IHIS.Framework.XPanel();
            this.grdNUR1022_IN = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.layCombo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.xEditGridCell43 = new IHIS.Framework.XEditGridCell();
            this.layHangmog = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.laySiksa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem7 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem8 = new IHIS.Framework.SingleLayoutItem();
            this.pnlPad = new IHIS.Framework.XPanel();
            this.btnSetValue = new IHIS.Framework.XButton();
            this.txtPadValue = new IHIS.Framework.XTextBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnKeypad1 = new IHIS.Framework.XButton();
            this.btnKeypad2 = new IHIS.Framework.XButton();
            this.btnKeypaddel = new IHIS.Framework.XButton();
            this.btnKeypad3 = new IHIS.Framework.XButton();
            this.btnKeypad0 = new IHIS.Framework.XButton();
            this.btnKeypad4 = new IHIS.Framework.XButton();
            this.btnKeypaddot = new IHIS.Framework.XButton();
            this.btnKeypad5 = new IHIS.Framework.XButton();
            this.btnKeypad9 = new IHIS.Framework.XButton();
            this.btnKeypad6 = new IHIS.Framework.XButton();
            this.btnKeypad8 = new IHIS.Framework.XButton();
            this.btnKeypad7 = new IHIS.Framework.XButton();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.lblPadTitle = new IHIS.Framework.XLabel();
            this.xImageButton1 = new IHIS.Framework.XImageButton();
            this.layNUR7002 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem15 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem16 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem17 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem18 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem19 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem20 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem21 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem22 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem9 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem10 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem11 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem12 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem13 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem14 = new IHIS.Framework.SingleLayoutItem();
            this.layNURList = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.layWriterBA = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.xGridHeader4 = new IHIS.Framework.XGridHeader();
            this.xGridHeader5 = new IHIS.Framework.XGridHeader();
            this.pnlTop.SuspendLayout();
            this.pnlTopFill.SuspendLayout();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1023)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlCare.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCare)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.pnlVital.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1020)).BeginInit();
            this.pnlVspatn_gubun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboVspatn_gubun)).BeginInit();
            this.pnlNUR1122.SuspendLayout();
            this.pnlNUR1122btn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWatchTemplate)).BeginInit();
            this.pnlFood.SuspendLayout();
            this.xPanel4.SuspendLayout();
            this.pnlOut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1022_OUT)).BeginInit();
            this.pnln.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1022_IN)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHangmog)).BeginInit();
            this.pnlPad.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.xPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNURList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWriterBA)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "작성.gif");
            this.ImageList.Images.SetKeyName(5, "number.ico");
            this.ImageList.Images.SetKeyName(6, "앞으로.gif");
            this.ImageList.Images.SetKeyName(7, "시험연~1.ICO");
            this.ImageList.Images.SetKeyName(8, "12.gif");
            this.ImageList.Images.SetKeyName(9, "19.gif");
            this.ImageList.Images.SetKeyName(10, "삭제.gif");
            this.ImageList.Images.SetKeyName(11, "1406559805_27854.ico");
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.pnlTopFill);
            this.pnlTop.Controls.Add(this.grdDelete);
            this.pnlTop.Name = "pnlTop";
            // 
            // pnlTopFill
            // 
            this.pnlTopFill.Controls.Add(this.pnlSession);
            this.pnlTopFill.Controls.Add(this.cboHo_dong);
            this.pnlTopFill.Controls.Add(this.lblYmd1);
            this.pnlTopFill.Controls.Add(this.lblHo_dong);
            this.pnlTopFill.Controls.Add(this.dtpYmd);
            resources.ApplyResources(this.pnlTopFill, "pnlTopFill");
            this.pnlTopFill.Name = "pnlTopFill";
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            resources.ApplyResources(this.pnlSession, "pnlSession");
            this.pnlSession.Name = "pnlSession";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Name = "xLabel6";
            // 
            // cbxA
            // 
            resources.ApplyResources(this.cbxA, "cbxA");
            this.cbxA.Name = "cbxA";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxB
            // 
            resources.ApplyResources(this.cbxB, "cbxB");
            this.cbxB.Name = "cbxB";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxC
            // 
            resources.ApplyResources(this.cbxC, "cbxC");
            this.cbxC.Name = "cbxC";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxD
            // 
            resources.ApplyResources(this.cbxD, "cbxD");
            this.cbxD.Name = "cbxD";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            resources.ApplyResources(this.cboHo_dong, "cboHo_dong");
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.SelectedIndexChanged += new System.EventHandler(this.cboHo_dong_SelectedIndexChanged);
            this.cboHo_dong.SelectedValueChanged += new System.EventHandler(this.cboHo_dong_SelectedValueChanged);
            // 
            // lblYmd1
            // 
            this.lblYmd1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblYmd1.EdgeRounding = false;
            resources.ApplyResources(this.lblYmd1, "lblYmd1");
            this.lblYmd1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblYmd1.Name = "lblYmd1";
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            resources.ApplyResources(this.lblHo_dong, "lblHo_dong");
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Name = "lblHo_dong";
            // 
            // dtpYmd
            // 
            this.dtpYmd.IsJapanYearType = true;
            resources.ApplyResources(this.dtpYmd, "dtpYmd");
            this.dtpYmd.Name = "dtpYmd";
            this.dtpYmd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpYmd_DataValidating);
            // 
            // grdDelete
            // 
            this.grdDelete.CallerID = '4';
            this.grdDelete.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell46,
            this.xEditGridCell47,
            this.xEditGridCell48,
            this.xEditGridCell49});
            this.grdDelete.ColPerLine = 4;
            this.grdDelete.Cols = 4;
            this.grdDelete.FixedRows = 1;
            this.grdDelete.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdDelete, "grdDelete");
            this.grdDelete.Name = "grdDelete";
            this.grdDelete.Rows = 2;
            this.grdDelete.TabStop = false;
            this.grdDelete.UseDefaultTransaction = false;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "bunho";
            this.xEditGridCell46.CellWidth = 84;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "ymd";
            this.xEditGridCell47.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell47.Col = 1;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.CellName = "fkinp1001";
            this.xEditGridCell48.Col = 2;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "time";
            this.xEditGridCell49.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell49.Col = 3;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnChiryo);
            this.pnlBottom.Controls.Add(this.txtFkinp1001);
            this.pnlBottom.Controls.Add(this.btnCopy);
            this.pnlBottom.Controls.Add(this.btnGraph);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.grdData);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnChiryo
            // 
            this.btnChiryo.ImageIndex = 7;
            this.btnChiryo.ImageList = this.ImageList;
            resources.ApplyResources(this.btnChiryo, "btnChiryo");
            this.btnChiryo.Name = "btnChiryo";
            this.btnChiryo.Click += new System.EventHandler(this.btnChiryo_Click);
            // 
            // txtFkinp1001
            // 
            resources.ApplyResources(this.txtFkinp1001, "txtFkinp1001");
            this.txtFkinp1001.Name = "txtFkinp1001";
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnGraph
            // 
            resources.ApplyResources(this.btnGraph, "btnGraph");
            this.btnGraph.Image = ((System.Drawing.Image)(resources.GetObject("btnGraph.Image")));
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdData
            // 
            this.grdData.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell14,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell57,
            this.xEditGridCell58});
            this.grdData.ColPerLine = 9;
            this.grdData.Cols = 9;
            this.grdData.FixedRows = 1;
            this.grdData.HeaderHeights.Add(19);
            resources.ApplyResources(this.grdData, "grdData");
            this.grdData.Name = "grdData";
            this.grdData.Rows = 2;
            this.grdData.UseDefaultTransaction = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "bunho";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "fkinp1001";
            this.xEditGridCell14.Col = 6;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "order_date";
            this.xEditGridCell9.Col = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gubun1";
            this.xEditGridCell10.Col = 2;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gubun2";
            this.xEditGridCell11.Col = 3;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "gubun3";
            this.xEditGridCell12.Col = 4;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "value";
            this.xEditGridCell13.Col = 5;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.CellName = "nut_gubn2";
            this.xEditGridCell57.Col = 7;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "nut_value2";
            this.xEditGridCell58.Col = 8;
            // 
            // grdNUR1023
            // 
            this.grdNUR1023.CallerID = '2';
            this.grdNUR1023.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27});
            this.grdNUR1023.ColPerLine = 4;
            this.grdNUR1023.Cols = 4;
            this.grdNUR1023.FixedRows = 1;
            this.grdNUR1023.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdNUR1023, "grdNUR1023");
            this.grdNUR1023.Name = "grdNUR1023";
            this.grdNUR1023.Rows = 2;
            this.grdNUR1023.UseDefaultTransaction = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "fkinp1001";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Number;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "bunho";
            this.xEditGridCell25.Col = 1;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "order_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = 2;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "vspatn_gubun";
            this.xEditGridCell27.Col = 3;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPalist);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // grdPalist
            // 
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell41,
            this.xEditGridCell66});
            this.grdPalist.ColPerLine = 6;
            this.grdPalist.Cols = 6;
            resources.ApplyResources(this.grdPalist, "grdPalist");
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.DoubleClick += new System.EventHandler(this.grdPalist_DoubleClick);
            this.grdPalist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdPalist_MouseClick);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPalist_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplyPaintingEvent = true;
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "ho_code";
            this.xEditGridCell1.CellWidth = 40;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 75;
            this.xEditGridCell2.Col = 1;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "su_name";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 2;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pkinp1001";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 20;
            this.xEditGridCell6.CellName = "age_sex";
            this.xEditGridCell6.Col = 3;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ipwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 90;
            this.xEditGridCell7.Col = 4;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsJapanYearType = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "doctor_name";
            this.xEditGridCell41.CellWidth = 100;
            this.xEditGridCell41.Col = 5;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "cycle_order_group";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.btnSetCare);
            this.pnlRight.Controls.Add(this.btnHelp);
            this.pnlRight.Controls.Add(this.btnNextPatient);
            this.pnlRight.Controls.Add(this.pnlCare);
            this.pnlRight.Controls.Add(this.xPanel2);
            this.pnlRight.Controls.Add(this.xPanel6);
            this.pnlRight.Controls.Add(this.pnlVital);
            this.pnlRight.Controls.Add(this.pnlNUR1122);
            this.pnlRight.Controls.Add(this.pnlFood);
            this.pnlRight.Controls.Add(this.xPanel4);
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.Name = "pnlRight";
            // 
            // btnSetCare
            // 
            this.btnSetCare.ImageIndex = 2;
            this.btnSetCare.ImageList = this.ImageList;
            resources.ApplyResources(this.btnSetCare, "btnSetCare");
            this.btnSetCare.Name = "btnSetCare";
            this.btnSetCare.Click += new System.EventHandler(this.btnSetCare_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ImageIndex = 11;
            this.btnHelp.ImageList = this.ImageList;
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 6;
            this.btnNextPatient.ImageList = this.ImageList;
            resources.ApplyResources(this.btnNextPatient, "btnNextPatient");
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // pnlCare
            // 
            this.pnlCare.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCare.Controls.Add(this.pnlHelp);
            this.pnlCare.Controls.Add(this.grdCare);
            this.pnlCare.Controls.Add(this.txtCare);
            this.pnlCare.Controls.Add(this.xLabel12);
            resources.ApplyResources(this.pnlCare, "pnlCare");
            this.pnlCare.Name = "pnlCare";
            // 
            // pnlHelp
            // 
            this.pnlHelp.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            this.pnlHelp.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Fuchsia);
            this.pnlHelp.Controls.Add(this.xImageButton2);
            this.pnlHelp.Controls.Add(this.xLabel20);
            this.pnlHelp.Controls.Add(this.xLabel19);
            resources.ApplyResources(this.pnlHelp, "pnlHelp");
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Click += new System.EventHandler(this.pnlHelp_Click);
            // 
            // xImageButton2
            // 
            this.xImageButton2.HoveredImage = global::IHIS.NURI.Properties.Resources._1406559805_27854;
            resources.ApplyResources(this.xImageButton2, "xImageButton2");
            this.xImageButton2.Name = "xImageButton2";
            this.xImageButton2.NormalImage = global::IHIS.NURI.Properties.Resources._1406559805_27854;
            this.xImageButton2.PushedImage = global::IHIS.NURI.Properties.Resources._1406559805_27854;
            this.xImageButton2.Click += new System.EventHandler(this.pnlHelp_Click);
            // 
            // xLabel20
            // 
            this.xLabel20.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.Name = "xLabel20";
            this.xLabel20.Click += new System.EventHandler(this.pnlHelp_Click);
            // 
            // xLabel19
            // 
            this.xLabel19.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Plum);
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Click += new System.EventHandler(this.pnlHelp_Click);
            // 
            // grdCare
            // 
            this.grdCare.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell63,
            this.xEditGridCell62});
            this.grdCare.ColPerLine = 1;
            this.grdCare.Cols = 1;
            this.grdCare.FixedRows = 1;
            this.grdCare.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdCare, "grdCare");
            this.grdCare.Name = "grdCare";
            this.grdCare.QuerySQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A\r\n WHERE A.HOSP_CODE = FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'CARE_LIST\'\r\n ORDER BY A.SORT_KEY, A.CODE" +
                "";
            this.grdCare.Rows = 2;
            this.grdCare.TabStop = false;
            this.grdCare.DoubleClick += new System.EventHandler(this.grdCare_DoubleClick);
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "code";
            this.xEditGridCell63.Col = -1;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsReadOnly = true;
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsUpdCol = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "care_string";
            this.xEditGridCell62.CellWidth = 144;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsReadOnly = true;
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsUpdCol = false;
            // 
            // txtCare
            // 
            resources.ApplyResources(this.txtCare, "txtCare");
            this.txtCare.Name = "txtCare";
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.ImageList = this.ImageList;
            this.xLabel12.Name = "xLabel12";
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.xPanel2.Controls.Add(this.xLabel17);
            this.xPanel2.Controls.Add(this.xLabel16);
            this.xPanel2.Controls.Add(this.xLabel15);
            this.xPanel2.Controls.Add(this.xLabel14);
            this.xPanel2.Controls.Add(this.xLabel13);
            this.xPanel2.Controls.Add(this.cboDungsyochi);
            this.xPanel2.Controls.Add(this.xLabel9);
            this.xPanel2.Controls.Add(this.emkHeight);
            this.xPanel2.Controls.Add(this.emkWeight);
            this.xPanel2.Controls.Add(this.xLabel10);
            this.xPanel2.Controls.Add(this.emkUrineQuantity);
            this.xPanel2.Controls.Add(this.xLabel11);
            this.xPanel2.Controls.Add(this.emkUrineCnt);
            this.xPanel2.Controls.Add(this.emkDungCnt);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // xLabel17
            // 
            this.xLabel17.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.Name = "xLabel17";
            // 
            // xLabel16
            // 
            this.xLabel16.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel15
            // 
            this.xLabel15.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.Name = "xLabel15";
            // 
            // xLabel14
            // 
            this.xLabel14.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.Name = "xLabel14";
            // 
            // xLabel13
            // 
            this.xLabel13.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // cboDungsyochi
            // 
            resources.ApplyResources(this.cboDungsyochi, "cboDungsyochi");
            this.cboDungsyochi.Name = "cboDungsyochi";
            this.cboDungsyochi.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDungsyochi.UserSQL = resources.GetString("cboDungsyochi.UserSQL");
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // emkHeight
            // 
            this.emkHeight.DecimalDigits = 1;
            this.emkHeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            resources.ApplyResources(this.emkHeight, "emkHeight");
            this.emkHeight.Name = "emkHeight";
            this.emkHeight.Tag = "";
            // 
            // emkWeight
            // 
            this.emkWeight.DecimalDigits = 1;
            this.emkWeight.EditMaskType = IHIS.Framework.MaskType.Decimal;
            resources.ApplyResources(this.emkWeight, "emkWeight");
            this.emkWeight.Name = "emkWeight";
            this.emkWeight.Tag = "";
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // emkUrineQuantity
            // 
            this.emkUrineQuantity.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkUrineQuantity, "emkUrineQuantity");
            this.emkUrineQuantity.Name = "emkUrineQuantity";
            this.emkUrineQuantity.Tag = "";
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // emkUrineCnt
            // 
            this.emkUrineCnt.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkUrineCnt, "emkUrineCnt");
            this.emkUrineCnt.Name = "emkUrineCnt";
            this.emkUrineCnt.Tag = "";
            // 
            // emkDungCnt
            // 
            this.emkDungCnt.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkDungCnt, "emkDungCnt");
            this.emkDungCnt.Name = "emkDungCnt";
            this.emkDungCnt.Tag = "";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.btnPreChuchi);
            this.xPanel6.Controls.Add(this.xLabel18);
            this.xPanel6.Controls.Add(this.txtChuchi);
            this.xPanel6.Controls.Add(this.dbxWriter3);
            this.xPanel6.Controls.Add(this.dbxWriter2);
            this.xPanel6.Controls.Add(this.dbxWriter1);
            this.xPanel6.Controls.Add(this.xLabel5);
            this.xPanel6.Controls.Add(this.fbxWriter3);
            this.xPanel6.Controls.Add(this.fbxWriter2);
            this.xPanel6.Controls.Add(this.fbxWriter1);
            this.xPanel6.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // btnPreChuchi
            // 
            resources.ApplyResources(this.btnPreChuchi, "btnPreChuchi");
            this.btnPreChuchi.Name = "btnPreChuchi";
            this.btnPreChuchi.Click += new System.EventHandler(this.btnPreChuchi_Click);
            // 
            // xLabel18
            // 
            this.xLabel18.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel18.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.Name = "xLabel18";
            // 
            // txtChuchi
            // 
            this.txtChuchi.AcceptsReturn = true;
            resources.ApplyResources(this.txtChuchi, "txtChuchi");
            this.txtChuchi.Name = "txtChuchi";
            // 
            // dbxWriter3
            // 
            resources.ApplyResources(this.dbxWriter3, "dbxWriter3");
            this.dbxWriter3.Name = "dbxWriter3";
            // 
            // dbxWriter2
            // 
            resources.ApplyResources(this.dbxWriter2, "dbxWriter2");
            this.dbxWriter2.Name = "dbxWriter2";
            // 
            // dbxWriter1
            // 
            resources.ApplyResources(this.dbxWriter1, "dbxWriter1");
            this.dbxWriter1.Name = "dbxWriter1";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.ImageList = this.ImageList;
            this.xLabel5.Name = "xLabel5";
            // 
            // fbxWriter3
            // 
            this.fbxWriter3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxWriter3.FindWorker = this.fwkWriter;
            resources.ApplyResources(this.fbxWriter3, "fbxWriter3");
            this.fbxWriter3.Name = "fbxWriter3";
            this.fbxWriter3.Tag = "3";
            this.fbxWriter3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxWriter_DataValidating);
            // 
            // fwkWriter
            // 
            this.fwkWriter.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkWriter.FormText = Resources.NUR1020U00_LCYT;
            this.fwkWriter.InputSQL = resources.GetString("fwkWriter.InputSQL");
            this.fwkWriter.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkWriter.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkWriter_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "id";
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "name";
            this.findColumnInfo2.ColWidth = 120;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // fbxWriter2
            // 
            this.fbxWriter2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxWriter2.FindWorker = this.fwkWriter;
            resources.ApplyResources(this.fbxWriter2, "fbxWriter2");
            this.fbxWriter2.Name = "fbxWriter2";
            this.fbxWriter2.Tag = "2";
            this.fbxWriter2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxWriter_DataValidating);
            // 
            // fbxWriter1
            // 
            this.fbxWriter1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxWriter1.FindWorker = this.fwkWriter;
            resources.ApplyResources(this.fbxWriter1, "fbxWriter1");
            this.fbxWriter1.Name = "fbxWriter1";
            this.fbxWriter1.Tag = "1";
            this.fbxWriter1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxWriter_DataValidating);
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.ImageList = this.ImageList;
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlVital
            // 
            this.pnlVital.Controls.Add(this.xPanel8);
            this.pnlVital.Controls.Add(this.grdNUR1020);
            this.pnlVital.Controls.Add(this.pnlVspatn_gubun);
            this.pnlVital.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.pnlVital, "pnlVital");
            this.pnlVital.Name = "pnlVital";
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnInsert);
            this.xPanel8.Controls.Add(this.btnDelete);
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Name = "xPanel8";
            // 
            // btnInsert
            // 
            this.btnInsert.ImageIndex = 2;
            this.btnInsert.ImageList = this.ImageList;
            resources.ApplyResources(this.btnInsert, "btnInsert");
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.ImageList = this.ImageList;
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grdNUR1020
            // 
            this.grdNUR1020.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell42,
            this.xEditGridCell44,
            this.xEditGridCell45,
            this.xEditGridCell64});
            this.grdNUR1020.ColPerLine = 9;
            this.grdNUR1020.Cols = 9;
            this.grdNUR1020.FixedRows = 1;
            this.grdNUR1020.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdNUR1020, "grdNUR1020");
            this.grdNUR1020.Name = "grdNUR1020";
            this.grdNUR1020.QuerySQL = resources.GetString("grdNUR1020.QuerySQL");
            this.grdNUR1020.Rows = 2;
            this.grdNUR1020.RowStateCheckOnPaint = false;
            this.grdNUR1020.ToolTipActive = true;
            this.grdNUR1020.ToolTipType = IHIS.Framework.XGridToolTipType.ColumnDesc;
            this.grdNUR1020.UseDefaultTransaction = false;
            this.grdNUR1020.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR1020_QueryEnd);
            this.grdNUR1020.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1020_QueryStarting);
            this.grdNUR1020.Click += new System.EventHandler(this.SetFocus);
            this.grdNUR1020.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR1020_GridColumnChanged);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "bunho";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "fkinp1001";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "ymd";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "vspatn_gubun";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.IsUpdCol = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "vspatn_time";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell16.CellWidth = 60;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.Mask = "HH:MI";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "pr_gubun1";
            this.xEditGridCell17.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell17.CellWidth = 48;
            this.xEditGridCell17.Col = 2;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell17.MaxinumCipher = 4;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "pr_gubun2";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.CellWidth = 60;
            this.xEditGridCell18.Col = 4;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell18.MaxinumCipher = 5;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "pr_gubun3";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell19.CellWidth = 65;
            this.xEditGridCell19.Col = 3;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell19.MaxinumCipher = 5;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 3;
            this.xEditGridCell20.CellName = "pr_gubun4";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell20.CellWidth = 100;
            this.xEditGridCell20.Col = 1;
            this.xEditGridCell20.DecimalDigits = 1;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell20.ShowZeroDecimal = true;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "pr_gubun5";
            this.xEditGridCell42.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell42.CellWidth = 33;
            this.xEditGridCell42.Col = 7;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell42.MaxinumCipher = 5;
            this.xEditGridCell42.ToolTipText = "1 = 測定不可";
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "pr_gubun6";
            this.xEditGridCell44.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell44.CellWidth = 65;
            this.xEditGridCell44.Col = 5;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell44.MaxinumCipher = 5;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "pr_gubun7";
            this.xEditGridCell45.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell45.CellWidth = 33;
            this.xEditGridCell45.Col = 8;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell45.MaxinumCipher = 5;
            this.xEditGridCell45.ToolTipText = "1=Lo ,　999=Hi";
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "pr_gubun8";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell64.CellWidth = 39;
            this.xEditGridCell64.Col = 6;
            this.xEditGridCell64.DecimalDigits = 2;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            // 
            // pnlVspatn_gubun
            // 
            this.pnlVspatn_gubun.Controls.Add(this.btnKeyPad);
            this.pnlVspatn_gubun.Controls.Add(this.btnTimeApply);
            this.pnlVspatn_gubun.Controls.Add(this.cboVspatn_gubun);
            this.pnlVspatn_gubun.Controls.Add(this.lblVspatn_gubun);
            this.pnlVspatn_gubun.Controls.Add(this.btnTenDown);
            this.pnlVspatn_gubun.Controls.Add(this.btnOneDown);
            this.pnlVspatn_gubun.Controls.Add(this.btnOneUp);
            this.pnlVspatn_gubun.Controls.Add(this.btnTenUp);
            resources.ApplyResources(this.pnlVspatn_gubun, "pnlVspatn_gubun");
            this.pnlVspatn_gubun.Name = "pnlVspatn_gubun";
            // 
            // btnKeyPad
            // 
            this.btnKeyPad.ImageIndex = 5;
            this.btnKeyPad.ImageList = this.ImageList;
            resources.ApplyResources(this.btnKeyPad, "btnKeyPad");
            this.btnKeyPad.Name = "btnKeyPad";
            this.btnKeyPad.Click += new System.EventHandler(this.btnKeyPad_Click);
            // 
            // btnTimeApply
            // 
            resources.ApplyResources(this.btnTimeApply, "btnTimeApply");
            this.btnTimeApply.Name = "btnTimeApply";
            this.btnTimeApply.Click += new System.EventHandler(this.btnTimeApply_Click);
            // 
            // cboVspatn_gubun
            // 
            this.cboVspatn_gubun.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            resources.ApplyResources(this.cboVspatn_gubun, "cboVspatn_gubun");
            this.cboVspatn_gubun.Name = "cboVspatn_gubun";
            this.cboVspatn_gubun.SelectionChangeCommitted += new System.EventHandler(this.cboVspatn_gubun_SelectionChangeCommitted);
            this.cboVspatn_gubun.SelectedValueChanged += new System.EventHandler(this.cboVspatn_gubun_SelectedValueChanged);
            // 
            // lblVspatn_gubun
            // 
            this.lblVspatn_gubun.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lblVspatn_gubun.EdgeRounding = false;
            resources.ApplyResources(this.lblVspatn_gubun, "lblVspatn_gubun");
            this.lblVspatn_gubun.Name = "lblVspatn_gubun";
            // 
            // btnTenDown
            // 
            resources.ApplyResources(this.btnTenDown, "btnTenDown");
            this.btnTenDown.Name = "btnTenDown";
            this.btnTenDown.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnTenDown.Click += new System.EventHandler(this.btnTenDown_Click);
            // 
            // btnOneDown
            // 
            resources.ApplyResources(this.btnOneDown, "btnOneDown");
            this.btnOneDown.Name = "btnOneDown";
            this.btnOneDown.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnOneDown.Click += new System.EventHandler(this.btnOneDown_Click);
            // 
            // btnOneUp
            // 
            resources.ApplyResources(this.btnOneUp, "btnOneUp");
            this.btnOneUp.Name = "btnOneUp";
            this.btnOneUp.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnOneUp.Click += new System.EventHandler(this.btnOneUp_Click);
            // 
            // btnTenUp
            // 
            resources.ApplyResources(this.btnTenUp, "btnTenUp");
            this.btnTenUp.Name = "btnTenUp";
            this.btnTenUp.Scheme = IHIS.Framework.XButtonSchemes.SkyBlue;
            this.btnTenUp.Click += new System.EventHandler(this.btnTenUp_Click);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.ImageList = this.ImageList;
            this.xLabel1.Name = "xLabel1";
            // 
            // pnlNUR1122
            // 
            this.pnlNUR1122.BorderColor = IHIS.Framework.XColor.ErrMsgForeColor;
            this.pnlNUR1122.Controls.Add(this.cboWatchTemplate);
            this.pnlNUR1122.Controls.Add(this.pnlNUR1122btn);
            this.pnlNUR1122.Controls.Add(this.xLabel3);
            this.pnlNUR1122.Controls.Add(this.grdNUR1122);
            this.pnlNUR1122.Controls.Add(this.grdWatchTemplate);
            this.pnlNUR1122.Controls.Add(this.grdNUR1023);
            resources.ApplyResources(this.pnlNUR1122, "pnlNUR1122");
            this.pnlNUR1122.Name = "pnlNUR1122";
            // 
            // cboWatchTemplate
            // 
            resources.ApplyResources(this.cboWatchTemplate, "cboWatchTemplate");
            this.cboWatchTemplate.Name = "cboWatchTemplate";
            this.cboWatchTemplate.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboWatchTemplate.UserSQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR0102 A\r\n WHERE A.HOSP_CODE = FN_ADM_" +
                "LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'WATCH_TEMPLATE\'";
            this.cboWatchTemplate.SelectedIndexChanged += new System.EventHandler(this.cboWatchTemplate_SelectedIndexChanged);
            // 
            // pnlNUR1122btn
            // 
            this.pnlNUR1122btn.Controls.Add(this.btnGwa);
            this.pnlNUR1122btn.Controls.Add(this.btnNUR1122Insert);
            this.pnlNUR1122btn.Controls.Add(this.btnNUR0101U00);
            this.pnlNUR1122btn.Controls.Add(this.btnNUR1122Delete);
            resources.ApplyResources(this.pnlNUR1122btn, "pnlNUR1122btn");
            this.pnlNUR1122btn.Name = "pnlNUR1122btn";
            // 
            // btnGwa
            // 
            resources.ApplyResources(this.btnGwa, "btnGwa");
            this.btnGwa.Name = "btnGwa";
            this.btnGwa.Click += new System.EventHandler(this.btnGwa_Click);
            // 
            // btnNUR1122Insert
            // 
            this.btnNUR1122Insert.ImageIndex = 2;
            this.btnNUR1122Insert.ImageList = this.ImageList;
            resources.ApplyResources(this.btnNUR1122Insert, "btnNUR1122Insert");
            this.btnNUR1122Insert.Name = "btnNUR1122Insert";
            this.btnNUR1122Insert.Click += new System.EventHandler(this.btnNUR1122Insert_Click);
            // 
            // btnNUR0101U00
            // 
            resources.ApplyResources(this.btnNUR0101U00, "btnNUR0101U00");
            this.btnNUR0101U00.Name = "btnNUR0101U00";
            this.btnNUR0101U00.Click += new System.EventHandler(this.btnNUR0101U00_Click);
            // 
            // btnNUR1122Delete
            // 
            this.btnNUR1122Delete.ImageIndex = 3;
            this.btnNUR1122Delete.ImageList = this.ImageList;
            resources.ApplyResources(this.btnNUR1122Delete, "btnNUR1122Delete");
            this.btnNUR1122Delete.Name = "btnNUR1122Delete";
            this.btnNUR1122Delete.Click += new System.EventHandler(this.btnNUR1122Delete_Click);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.ImageList = this.ImageList;
            this.xLabel3.Name = "xLabel3";
            // 
            // grdNUR1122
            // 
            this.grdNUR1122.CallerID = '3';
            this.grdNUR1122.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell50,
            this.xEditGridCell51,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell65});
            this.grdNUR1122.ColPerLine = 4;
            this.grdNUR1122.Cols = 4;
            this.grdNUR1122.FixedRows = 1;
            this.grdNUR1122.HeaderHeights.Add(21);
            this.grdNUR1122.IncludeUnChangedRowAtSaving = true;
            resources.ApplyResources(this.grdNUR1122, "grdNUR1122");
            this.grdNUR1122.Name = "grdNUR1122";
            this.grdNUR1122.QuerySQL = resources.GetString("grdNUR1122.QuerySQL");
            this.grdNUR1122.Rows = 2;
            this.grdNUR1122.UseDefaultTransaction = false;
            this.grdNUR1122.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1122_QueryStarting);
            this.grdNUR1122.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR1122_GridColumnChanged);
            this.grdNUR1122.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR1122_SaveEnd);
            this.grdNUR1122.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR1122_GridCellPainting);
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "bunho";
            this.xEditGridCell50.Col = -1;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsReadOnly = true;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "fkinp1001";
            this.xEditGridCell51.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell51.Col = -1;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsReadOnly = true;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "ymd";
            this.xEditGridCell52.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell52.Col = -1;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "hangmog_code";
            this.xEditGridCell53.CellWidth = 125;
            this.xEditGridCell53.Col = -1;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellLen = 25;
            this.xEditGridCell54.CellName = "hangmog_value1";
            this.xEditGridCell54.CellWidth = 48;
            this.xEditGridCell54.Col = 1;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellLen = 32;
            this.xEditGridCell59.CellName = "hangmog_value2";
            this.xEditGridCell59.CellWidth = 60;
            this.xEditGridCell59.Col = 2;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellLen = 25;
            this.xEditGridCell60.CellName = "hangmog_value3";
            this.xEditGridCell60.CellWidth = 60;
            this.xEditGridCell60.Col = 3;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.ApplyPaintingEvent = true;
            this.xEditGridCell61.CellLen = 20;
            this.xEditGridCell61.CellName = "hangmog_name";
            this.xEditGridCell61.CellWidth = 127;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "end_yn";
            this.xEditGridCell65.Col = -1;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsReadOnly = true;
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsUpdCol = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // grdWatchTemplate
            // 
            this.grdWatchTemplate.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell55,
            this.xEditGridCell56});
            this.grdWatchTemplate.ColPerLine = 1;
            this.grdWatchTemplate.Cols = 1;
            this.grdWatchTemplate.FixedRows = 1;
            this.grdWatchTemplate.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdWatchTemplate, "grdWatchTemplate");
            this.grdWatchTemplate.Name = "grdWatchTemplate";
            this.grdWatchTemplate.QuerySQL = "SELECT A.CODE\r\n     , A.CODE_NAME\r\n  FROM NUR1123 A\r\n WHERE A.HOSP_CODE = :f_hosp" +
                "_code\r\n   AND A.CODE_TYPE = :f_code_type\r\nORDER BY A.SORT_KEY";
            this.grdWatchTemplate.Rows = 2;
            this.grdWatchTemplate.DoubleClick += new System.EventHandler(this.grdHangmog_Comment_DoubleClick);
            this.grdWatchTemplate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_Comment_QueryStarting);
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "code";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.IsReadOnly = true;
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "code_name";
            this.xEditGridCell56.CellWidth = 72;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsReadOnly = true;
            this.xEditGridCell56.IsUpdatable = false;
            // 
            // pnlFood
            // 
            this.pnlFood.Controls.Add(this.xLabel8);
            this.pnlFood.Controls.Add(this.xLabel7);
            this.pnlFood.Controls.Add(this.emkSikT5);
            this.pnlFood.Controls.Add(this.xLabel2);
            this.pnlFood.Controls.Add(this.emkSikT6);
            this.pnlFood.Controls.Add(this.emkSikT7);
            this.pnlFood.Controls.Add(this.lblMorning);
            this.pnlFood.Controls.Add(this.emkSikT1);
            this.pnlFood.Controls.Add(this.lblNoon);
            this.pnlFood.Controls.Add(this.lblNight);
            this.pnlFood.Controls.Add(this.emkSikT2);
            this.pnlFood.Controls.Add(this.emkSikT3);
            resources.ApplyResources(this.pnlFood, "pnlFood");
            this.pnlFood.Name = "pnlFood";
            // 
            // xLabel8
            // 
            this.xLabel8.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel8.EdgeRounding = false;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.Name = "xLabel8";
            // 
            // xLabel7
            // 
            this.xLabel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.MistyRose);
            this.xLabel7.EdgeRounding = false;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.Name = "xLabel7";
            // 
            // emkSikT5
            // 
            this.emkSikT5.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT5, "emkSikT5");
            this.emkSikT5.GeneralNumberFormat = true;
            this.emkSikT5.MaxinumCipher = 2;
            this.emkSikT5.Name = "emkSikT5";
            this.emkSikT5.Tag = Resources.NUR1020U00_BFS;
            this.emkSikT5.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT5.Click += new System.EventHandler(this.SetFocus);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ImageList = this.ImageList;
            this.xLabel2.Name = "xLabel2";
            // 
            // emkSikT6
            // 
            this.emkSikT6.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT6, "emkSikT6");
            this.emkSikT6.GeneralNumberFormat = true;
            this.emkSikT6.MaxinumCipher = 2;
            this.emkSikT6.Name = "emkSikT6";
            this.emkSikT6.Tag = Resources.NUR1020U00_BFT;
            this.emkSikT6.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT6.Click += new System.EventHandler(this.SetFocus);
            // 
            // emkSikT7
            // 
            this.emkSikT7.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT7, "emkSikT7");
            this.emkSikT7.GeneralNumberFormat = true;
            this.emkSikT7.MaxinumCipher = 2;
            this.emkSikT7.Name = "emkSikT7";
            this.emkSikT7.Tag = Resources.NUR1020U00_BFTT;
            this.emkSikT7.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT7.Click += new System.EventHandler(this.SetFocus);
            // 
            // lblMorning
            // 
            this.lblMorning.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lblMorning.EdgeRounding = false;
            resources.ApplyResources(this.lblMorning, "lblMorning");
            this.lblMorning.Name = "lblMorning";
            // 
            // emkSikT1
            // 
            this.emkSikT1.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT1, "emkSikT1");
            this.emkSikT1.GeneralNumberFormat = true;
            this.emkSikT1.MaxinumCipher = 2;
            this.emkSikT1.Name = "emkSikT1";
            this.emkSikT1.Tag = Resources.NUR1020U00_BCS;
            this.emkSikT1.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT1.Click += new System.EventHandler(this.SetFocus);
            // 
            // lblNoon
            // 
            this.lblNoon.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lblNoon.EdgeRounding = false;
            resources.ApplyResources(this.lblNoon, "lblNoon");
            this.lblNoon.Name = "lblNoon";
            // 
            // lblNight
            // 
            this.lblNight.BackColor = IHIS.Framework.XColor.XTabControlBackColor;
            this.lblNight.EdgeRounding = false;
            resources.ApplyResources(this.lblNight, "lblNight");
            this.lblNight.Name = "lblNight";
            // 
            // emkSikT2
            // 
            this.emkSikT2.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT2, "emkSikT2");
            this.emkSikT2.GeneralNumberFormat = true;
            this.emkSikT2.MaxinumCipher = 2;
            this.emkSikT2.Name = "emkSikT2";
            this.emkSikT2.Tag = Resources.NUR1020U00_BCT;
            this.emkSikT2.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT2.Click += new System.EventHandler(this.SetFocus);
            // 
            // emkSikT3
            // 
            this.emkSikT3.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.emkSikT3, "emkSikT3");
            this.emkSikT3.GeneralNumberFormat = true;
            this.emkSikT3.MaxinumCipher = 2;
            this.emkSikT3.Name = "emkSikT3";
            this.emkSikT3.Tag = Resources.NUR1020U00_BCTT;
            this.emkSikT3.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkSik_DataValidating);
            this.emkSikT3.Click += new System.EventHandler(this.SetFocus);
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.pnlOut);
            this.xPanel4.Controls.Add(this.pnln);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // pnlOut
            // 
            this.pnlOut.Controls.Add(this.grdNUR1022_OUT);
            this.pnlOut.DrawBorder = true;
            resources.ApplyResources(this.pnlOut, "pnlOut");
            this.pnlOut.Name = "pnlOut";
            // 
            // grdNUR1022_OUT
            // 
            this.grdNUR1022_OUT.AddedHeaderLine = 1;
            this.grdNUR1022_OUT.ApplyPaintEventToAllColumn = true;
            this.grdNUR1022_OUT.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell39,
            this.xEditGridCell40});
            this.grdNUR1022_OUT.ColPerLine = 3;
            this.grdNUR1022_OUT.Cols = 4;
            this.grdNUR1022_OUT.FixedCols = 1;
            this.grdNUR1022_OUT.FixedRows = 2;
            this.grdNUR1022_OUT.FocusColumnName = "io_value_2";
            this.grdNUR1022_OUT.HeaderHeights.Add(21);
            this.grdNUR1022_OUT.HeaderHeights.Add(0);
            this.grdNUR1022_OUT.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            resources.ApplyResources(this.grdNUR1022_OUT, "grdNUR1022_OUT");
            this.grdNUR1022_OUT.Name = "grdNUR1022_OUT";
            this.grdNUR1022_OUT.QuerySQL = resources.GetString("grdNUR1022_OUT.QuerySQL");
            this.grdNUR1022_OUT.RowHeaderVisible = true;
            this.grdNUR1022_OUT.Rows = 3;
            this.grdNUR1022_OUT.RowStateCheckOnPaint = false;
            this.grdNUR1022_OUT.UseDefaultTransaction = false;
            this.grdNUR1022_OUT.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR1022_OUT_GridColumnProtectModify);
            this.grdNUR1022_OUT.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR1022_OUT_GridColumnChanged);
            this.grdNUR1022_OUT.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR1022_OUT_GridCellPainting);
            this.grdNUR1022_OUT.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR1022_OUT_RowFocusChanged);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "bunho_2";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.CellName = "fkinp1001_2";
            this.xEditGridCell35.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.CellName = "ymd_2";
            this.xEditGridCell36.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "io_type_2";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "io_type_name_2";
            this.xEditGridCell38.CellWidth = 66;
            this.xEditGridCell38.Col = 1;
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsUpdCol = false;
            this.xEditGridCell38.Row = 1;
            this.xEditGridCell38.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "io_gubun_2";
            this.xEditGridCell39.CellWidth = 0;
            this.xEditGridCell39.Col = 3;
            this.xEditGridCell39.RowSpan = 2;
            this.xEditGridCell39.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "io_value_2";
            this.xEditGridCell40.CellWidth = 33;
            this.xEditGridCell40.Col = 2;
            this.xEditGridCell40.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell40.Row = 1;
            this.xEditGridCell40.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 1;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 66;
            // 
            // pnln
            // 
            this.pnln.Controls.Add(this.grdNUR1022_IN);
            this.pnln.DrawBorder = true;
            resources.ApplyResources(this.pnln, "pnln");
            this.pnln.Name = "pnln";
            // 
            // grdNUR1022_IN
            // 
            this.grdNUR1022_IN.AddedHeaderLine = 1;
            this.grdNUR1022_IN.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell32,
            this.xEditGridCell31,
            this.xEditGridCell33,
            this.xEditGridCell34});
            this.grdNUR1022_IN.ColPerLine = 3;
            this.grdNUR1022_IN.Cols = 4;
            this.grdNUR1022_IN.FixedCols = 1;
            this.grdNUR1022_IN.FixedRows = 2;
            this.grdNUR1022_IN.FocusColumnName = "io_value_1";
            this.grdNUR1022_IN.HeaderHeights.Add(21);
            this.grdNUR1022_IN.HeaderHeights.Add(0);
            this.grdNUR1022_IN.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            resources.ApplyResources(this.grdNUR1022_IN, "grdNUR1022_IN");
            this.grdNUR1022_IN.Name = "grdNUR1022_IN";
            this.grdNUR1022_IN.QuerySQL = resources.GetString("grdNUR1022_IN.QuerySQL");
            this.grdNUR1022_IN.RowHeaderVisible = true;
            this.grdNUR1022_IN.Rows = 3;
            this.grdNUR1022_IN.RowStateCheckOnPaint = false;
            this.grdNUR1022_IN.UseDefaultTransaction = false;
            this.grdNUR1022_IN.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR1022_IN_RowFocusChanged);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bunho_1";
            this.xEditGridCell28.Col = -1;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "fkinp1001_1";
            this.xEditGridCell29.Col = -1;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "ymd_1";
            this.xEditGridCell30.Col = -1;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.IsVisible = false;
            this.xEditGridCell30.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "io_type_1";
            this.xEditGridCell32.Col = -1;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "io_type_name_1";
            this.xEditGridCell31.CellWidth = 66;
            this.xEditGridCell31.Col = 1;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.Row = 1;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "io_gubun_1";
            this.xEditGridCell33.CellWidth = 0;
            this.xEditGridCell33.Col = 3;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.Row = 2;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "io_value_1";
            this.xEditGridCell34.CellWidth = 37;
            this.xEditGridCell34.Col = 2;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell34.Row = 1;
            this.xEditGridCell34.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 1;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 66;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 1;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 48;
            this.xGridHeader3.Row = 1;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.paBox);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // layCombo
            // 
            this.layCombo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layCombo.QuerySQL = "SELECT CODE      CODE,\r\n       CODE_NAME CODE_NAME,\r\n       SORT_KEY\r\n  FROM NUR0" +
                "102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = :f_code_type\r\n ORDER BY" +
                " 1, 3";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "pr_gubun5";
            this.xEditGridCell43.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell43.Col = 6;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            // 
            // layHangmog
            // 
            this.layHangmog.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layHangmog.QuerySQL = resources.GetString("layHangmog.QuerySQL");
            this.layHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layHangmog_QueryStarting);
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code_name";
            // 
            // laySiksa
            // 
            this.laySiksa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6,
            this.singleLayoutItem7,
            this.singleLayoutItem8});
            this.laySiksa.QuerySQL = resources.GetString("laySiksa.QuerySQL");
            this.laySiksa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySiksa_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.emkSikT1;
            this.singleLayoutItem1.DataName = "t1";
            this.singleLayoutItem1.IsUpdItem = true;
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.emkSikT2;
            this.singleLayoutItem2.DataName = "t2";
            this.singleLayoutItem2.IsUpdItem = true;
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.emkSikT3;
            this.singleLayoutItem3.DataName = "t3";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "t4";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.emkSikT5;
            this.singleLayoutItem5.DataName = "t5";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.BindControl = this.emkSikT6;
            this.singleLayoutItem6.DataName = "t6";
            // 
            // singleLayoutItem7
            // 
            this.singleLayoutItem7.BindControl = this.emkSikT7;
            this.singleLayoutItem7.DataName = "t7";
            // 
            // singleLayoutItem8
            // 
            this.singleLayoutItem8.DataName = "t8";
            // 
            // pnlPad
            // 
            this.pnlPad.BackColor = IHIS.Framework.XColor.NormalForeColor;
            this.pnlPad.Controls.Add(this.btnSetValue);
            this.pnlPad.Controls.Add(this.txtPadValue);
            this.pnlPad.Controls.Add(this.xPanel3);
            this.pnlPad.Controls.Add(this.xPanel7);
            this.pnlPad.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.pnlPad, "pnlPad");
            this.pnlPad.Name = "pnlPad";
            // 
            // btnSetValue
            // 
            resources.ApplyResources(this.btnSetValue, "btnSetValue");
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Click += new System.EventHandler(this.btnSetValue_Click);
            // 
            // txtPadValue
            // 
            resources.ApplyResources(this.txtPadValue, "txtPadValue");
            this.txtPadValue.Name = "txtPadValue";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnKeypad1);
            this.xPanel3.Controls.Add(this.btnKeypad2);
            this.xPanel3.Controls.Add(this.btnKeypaddel);
            this.xPanel3.Controls.Add(this.btnKeypad3);
            this.xPanel3.Controls.Add(this.btnKeypad0);
            this.xPanel3.Controls.Add(this.btnKeypad4);
            this.xPanel3.Controls.Add(this.btnKeypaddot);
            this.xPanel3.Controls.Add(this.btnKeypad5);
            this.xPanel3.Controls.Add(this.btnKeypad9);
            this.xPanel3.Controls.Add(this.btnKeypad6);
            this.xPanel3.Controls.Add(this.btnKeypad8);
            this.xPanel3.Controls.Add(this.btnKeypad7);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnKeypad1
            // 
            resources.ApplyResources(this.btnKeypad1, "btnKeypad1");
            this.btnKeypad1.Name = "btnKeypad1";
            this.btnKeypad1.Tag = "1";
            this.btnKeypad1.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad2
            // 
            resources.ApplyResources(this.btnKeypad2, "btnKeypad2");
            this.btnKeypad2.Name = "btnKeypad2";
            this.btnKeypad2.Tag = "2";
            this.btnKeypad2.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypaddel
            // 
            resources.ApplyResources(this.btnKeypaddel, "btnKeypaddel");
            this.btnKeypaddel.Name = "btnKeypaddel";
            this.btnKeypaddel.Tag = "B";
            this.btnKeypaddel.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad3
            // 
            resources.ApplyResources(this.btnKeypad3, "btnKeypad3");
            this.btnKeypad3.Name = "btnKeypad3";
            this.btnKeypad3.Tag = "3";
            this.btnKeypad3.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad0
            // 
            resources.ApplyResources(this.btnKeypad0, "btnKeypad0");
            this.btnKeypad0.Name = "btnKeypad0";
            this.btnKeypad0.Tag = "0";
            this.btnKeypad0.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad4
            // 
            resources.ApplyResources(this.btnKeypad4, "btnKeypad4");
            this.btnKeypad4.Name = "btnKeypad4";
            this.btnKeypad4.Tag = "4";
            this.btnKeypad4.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypaddot
            // 
            resources.ApplyResources(this.btnKeypaddot, "btnKeypaddot");
            this.btnKeypaddot.Name = "btnKeypaddot";
            this.btnKeypaddot.Tag = ".";
            this.btnKeypaddot.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad5
            // 
            resources.ApplyResources(this.btnKeypad5, "btnKeypad5");
            this.btnKeypad5.Name = "btnKeypad5";
            this.btnKeypad5.Tag = "5";
            this.btnKeypad5.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad9
            // 
            resources.ApplyResources(this.btnKeypad9, "btnKeypad9");
            this.btnKeypad9.Name = "btnKeypad9";
            this.btnKeypad9.Tag = "9";
            this.btnKeypad9.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad6
            // 
            resources.ApplyResources(this.btnKeypad6, "btnKeypad6");
            this.btnKeypad6.Name = "btnKeypad6";
            this.btnKeypad6.Tag = "6";
            this.btnKeypad6.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad8
            // 
            resources.ApplyResources(this.btnKeypad8, "btnKeypad8");
            this.btnKeypad8.Name = "btnKeypad8";
            this.btnKeypad8.Tag = "8";
            this.btnKeypad8.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // btnKeypad7
            // 
            resources.ApplyResources(this.btnKeypad7, "btnKeypad7");
            this.btnKeypad7.Name = "btnKeypad7";
            this.btnKeypad7.Tag = "7";
            this.btnKeypad7.Click += new System.EventHandler(this.btnKeypad_Click);
            // 
            // xPanel7
            // 
            this.xPanel7.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.YellowGreen);
            this.xPanel7.Controls.Add(this.lblPadTitle);
            this.xPanel7.Controls.Add(this.xImageButton1);
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.Name = "xPanel7";
            // 
            // lblPadTitle
            // 
            this.lblPadTitle.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.YellowGreen);
            this.lblPadTitle.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.YellowGreen);
            resources.ApplyResources(this.lblPadTitle, "lblPadTitle");
            this.lblPadTitle.Name = "lblPadTitle";
            // 
            // xImageButton1
            // 
            resources.ApplyResources(this.xImageButton1, "xImageButton1");
            this.xImageButton1.Name = "xImageButton1";
            this.xImageButton1.NormalImage = global::IHIS.NURI.Properties.Resources.취소;
            this.xImageButton1.Click += new System.EventHandler(this.btnKeyPad_Click);
            // 
            // layNUR7002
            // 
            this.layNUR7002.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem15,
            this.singleLayoutItem16,
            this.singleLayoutItem17,
            this.singleLayoutItem18,
            this.singleLayoutItem19,
            this.singleLayoutItem20,
            this.singleLayoutItem21,
            this.singleLayoutItem22,
            this.singleLayoutItem9,
            this.singleLayoutItem10,
            this.singleLayoutItem11,
            this.singleLayoutItem12,
            this.singleLayoutItem13,
            this.singleLayoutItem14});
            this.layNUR7002.QuerySQL = resources.GetString("layNUR7002.QuerySQL");
            this.layNUR7002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR7002_QueryStarting);
            // 
            // singleLayoutItem15
            // 
            this.singleLayoutItem15.BindControl = this.txtChuchi;
            this.singleLayoutItem15.DataName = "chuchi";
            // 
            // singleLayoutItem16
            // 
            this.singleLayoutItem16.BindControl = this.cboDungsyochi;
            this.singleLayoutItem16.DataName = "dungsyochi";
            // 
            // singleLayoutItem17
            // 
            this.singleLayoutItem17.BindControl = this.emkDungCnt;
            this.singleLayoutItem17.DataName = "dungcnt";
            // 
            // singleLayoutItem18
            // 
            this.singleLayoutItem18.BindControl = this.emkUrineQuantity;
            this.singleLayoutItem18.DataName = "urinequantity";
            // 
            // singleLayoutItem19
            // 
            this.singleLayoutItem19.BindControl = this.emkUrineCnt;
            this.singleLayoutItem19.DataName = "urinecnt";
            // 
            // singleLayoutItem20
            // 
            this.singleLayoutItem20.BindControl = this.emkHeight;
            this.singleLayoutItem20.DataName = "height";
            // 
            // singleLayoutItem21
            // 
            this.singleLayoutItem21.BindControl = this.emkWeight;
            this.singleLayoutItem21.DataName = "weight";
            // 
            // singleLayoutItem22
            // 
            this.singleLayoutItem22.BindControl = this.txtCare;
            this.singleLayoutItem22.DataName = "care";
            // 
            // singleLayoutItem9
            // 
            this.singleLayoutItem9.BindControl = this.fbxWriter1;
            this.singleLayoutItem9.DataName = "writer_1";
            // 
            // singleLayoutItem10
            // 
            this.singleLayoutItem10.BindControl = this.dbxWriter1;
            this.singleLayoutItem10.DataName = "writer_nm_1";
            // 
            // singleLayoutItem11
            // 
            this.singleLayoutItem11.BindControl = this.fbxWriter2;
            this.singleLayoutItem11.DataName = "writer_2";
            // 
            // singleLayoutItem12
            // 
            this.singleLayoutItem12.BindControl = this.dbxWriter2;
            this.singleLayoutItem12.DataName = "writer_nm_2";
            // 
            // singleLayoutItem13
            // 
            this.singleLayoutItem13.BindControl = this.fbxWriter3;
            this.singleLayoutItem13.DataName = "writer_3";
            // 
            // singleLayoutItem14
            // 
            this.singleLayoutItem14.BindControl = this.dbxWriter3;
            this.singleLayoutItem14.DataName = "writer_nm_3";
            // 
            // layNURList
            // 
            this.layNURList.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layNURList.QuerySQL = resources.GetString("layNURList.QuerySQL");
            this.layNURList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNURList_QueryStarting);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "user_id";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "user_name";
            // 
            // layWriterBA
            // 
            this.layWriterBA.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11});
            this.layWriterBA.QuerySQL = resources.GetString("layWriterBA.QuerySQL");
            this.layWriterBA.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layWriterBA_QueryStarting);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "fkinp1001";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "ymd";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "hangmog_gubun";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "hangmog_seq";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "hangmog_value";
            // 
            // xGridHeader4
            // 
            resources.ApplyResources(this.xGridHeader4, "xGridHeader4");
            // 
            // xGridHeader5
            // 
            resources.ApplyResources(this.xGridHeader5, "xGridHeader5");
            // 
            // NUR1020U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlPad);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1020U00";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1020U00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopFill.ResumeLayout(false);
            this.pnlTopFill.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1023)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlCare.ResumeLayout(false);
            this.pnlCare.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCare)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            this.pnlVital.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1020)).EndInit();
            this.pnlVspatn_gubun.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboVspatn_gubun)).EndInit();
            this.pnlNUR1122.ResumeLayout(false);
            this.pnlNUR1122btn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWatchTemplate)).EndInit();
            this.pnlFood.ResumeLayout(false);
            this.pnlFood.PerformLayout();
            this.xPanel4.ResumeLayout(false);
            this.pnlOut.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1022_OUT)).EndInit();
            this.pnln.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1022_IN)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layCombo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layHangmog)).EndInit();
            this.pnlPad.ResumeLayout(false);
            this.pnlPad.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            this.xPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNURList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWriterBA)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 메세지 일괄 처리
        /// </summary>
        /// <param name="aMesgGubun">
        /// 메세지 구분
        /// </param>
        #region 메세지처리
        private void GetMessage(string aMesgGubun)
        {
            string msg = string.Empty;
            string caption = string.Empty;

            switch (aMesgGubun)
            {
                case "jeawonYn":
                    msg = (NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT1
                        : "在院中の患者ではありません。患者番号を確認してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT2
                        : Resources.NUR1020U00_TEXT_TB);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "bunho":
                    msg = (NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT3
                        : Resources.NUR1020U00_btnChiryo_Click_);
                    caption = (NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT4
                        : Resources.NUR1020U00_TEXT_TB);
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "save_true":
                    msg = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT5
                        : Resources.NUR1020U00_TEXT_DL;
                    caption = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT4
                        : Resources.NUR1020U00_TEXT_TB;
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
                case "save_false":
                    msg = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT6
                        : "保存に失敗しました。ご確認ください。";
                    caption = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT7
                        : "エラー";
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
                case "null":
                    msg = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT8
                        : "データがないか、照会条件が合いません。";
                    caption = NetInfo.Language == LangMode.Ko ? Resources.NUR1020U00_TEXT7
                        : "エラー";
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 화면을 클리어 한다.
        /// </summary>
        /// <param name="aScreenYn">
        /// 화면 잠금여부
        /// </param>
        #region 화면 클리어
        private void ResetControl(Control parent)
        {
            //this.grdInp1001.Reset();
            foreach (Control cont in parent.Controls)
            {
                if (cont is IDataControl)
                {
                    ((IDataControl)cont).ResetData();
                }
                else if (cont is XRadioButton)
                {
                    ((XRadioButton)cont).Checked = false;
                }
                else if ((cont.Controls != null) && (cont.Controls.Count > 0))
                    ResetControl(cont);
            }
            this.grdNUR1020.Reset();
            this.grdNUR1022_IN.Reset();
            this.grdNUR1022_OUT.Reset();
        }
        #endregion


        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();
        private void CreatePopUpMenu()
        {
            popMenu.MenuCommands.Clear();

            IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("赤", ImageList.Images[8], new EventHandler(SetCycleOrderGroup));
            menuCmd.Tag = "1";

            popMenu.MenuCommands.Add(menuCmd);

            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("緑", ImageList.Images[9], new EventHandler(SetCycleOrderGroup));
            menuCmd.Tag = "2";

            popMenu.MenuCommands.Add(menuCmd);

            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("クリア", ImageList.Images[10], new EventHandler(SetCycleOrderGroup));
            menuCmd.Tag = "3";

            popMenu.MenuCommands.Add(menuCmd);
        }


        #region 데이터 조회
        private void Query()
        {
            //string cmdText = "";
            BindVarCollection bindVars = new BindVarCollection();
            DataTable resTbl = new DataTable();
            object retVal = null;

            this.grdCare.QueryLayout(true);
            this.cboVspatn_gubun.SetDataValue("99");

            this.grdNUR1020.Reset();

            SetVspatn_time();

            bindVars.Add("f_hosp_code", this.mHospCode);
            bindVars.Add("f_bunho", paBox.BunHo);
            bindVars.Add("f_ymd", this.dtpYmd.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
            bindVars.Add("f_fkinp1001", this.txtFkinp1001.GetDataValue());


            
            //전일카피버튼 클릭시
            if (ms_PrevQryFlag.Equals("Y"))
            {
                
//                retVal = Service.ExecuteScalar(@"   SELECT NVL(MAX(YMD), TO_DATE(:f_date, 'YYYYMMDD')) YMD
//                                                      FROM NUR1022
//                                                     WHERE HOSP_CODE = :f_hosp_code
//                                                       AND BUNHO     = :f_bunho
//                                                       AND YMD       < :f_ymd
//                                                    ", bindVars);
//                bindVars.Remove("f_ymd");
//                bindVars.Add("f_ymd", retVal.ToString().Replace("-", "").Replace("/", "").Substring(0, 8));
            
                /* 바이탈사인의 전일자 데이타가 있는 내역 조회, NUR1022에서 데이타가 있는 MAX YMD Get 2012.02.01*/
                retVal = Service.ExecuteScalar(@"   SELECT NVL(MAX(YMD), TO_DATE(:f_ymd,'YYYY/MM/DD')) YMD
                                                      FROM NUR1020
                                                     WHERE HOSP_CODE = :f_hosp_code
                                                       AND BUNHO     = :f_bunho
                                                       AND YMD       < :f_ymd", bindVars);
                if (!TypeCheck.IsNull(retVal))
                {
                    bindVars.Remove("f_ymd");
                    bindVars.Add("f_ymd", retVal.ToString().Replace("-", "").Replace("/", "").Substring(0, 8));
                }
            }

            grdNUR1022_IN.SetBindVarValue("f_order_date", bindVars["f_ymd"].VarValue);
            grdNUR1022_IN.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR1022_IN.SetBindVarValue("f_bunho", paBox.BunHo);
            grdNUR1022_IN.SetBindVarValue("f_fkinp1001", txtFkinp1001.GetDataValue().Trim());
            grdNUR1022_IN.SetBindVarValue("f_gubn", "I");
            grdNUR1022_IN.SetBindVarValue("f_gubn_type", "VSPATN_IN");
            grdNUR1022_IN.SetBindVarValue("f_prevqryflag", ms_PrevQryFlag);

            /** dsvNUR1022_IN Service 변환 2010.05. 河中 **/
            if(!grdNUR1022_IN.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            
            grdNUR1022_OUT.SetBindVarValue("f_order_date", bindVars["f_ymd"].VarValue);
            grdNUR1022_OUT.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR1022_OUT.SetBindVarValue("f_bunho", paBox.BunHo);
            grdNUR1022_OUT.SetBindVarValue("f_fkinp1001", txtFkinp1001.GetDataValue().Trim());
            grdNUR1022_OUT.SetBindVarValue("f_gubn", "O");
            grdNUR1022_OUT.SetBindVarValue("f_gubn_type", "VSPATN_OUT");
            grdNUR1022_OUT.SetBindVarValue("f_prevqryflag", ms_PrevQryFlag);

            if (!grdNUR1022_OUT.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }

            if (ms_PrevQryFlag.Equals("Y"))
            {
                /* 환자별 관리 항목 NUR1122 의 전일자 데이타가 있는 내역 조회, NUR1122에서 데이타가 있는 MAX YMD Get 2012.01.26*/
                bindVars.Remove("f_ymd");
                bindVars.Add("f_ymd", this.dtpYmd.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
                retVal = Service.ExecuteScalar(@"   SELECT NVL(MAX(YMD), TO_DATE(:f_date, 'YYYYMMDD')) YMD
                                                      FROM NUR1122
                                                     WHERE HOSP_CODE = :f_hosp_code
                                                       AND BUNHO     = :f_bunho
                                                       AND YMD       < :f_ymd
                                                    ", bindVars);
                if (!TypeCheck.IsNull(retVal))
                {
                    bindVars.Remove("f_ymd");
                    bindVars.Add("f_ymd", retVal.ToString().Replace("-", "").Replace("/", "").Substring(0, 8));
                }
            }

            //grdNUR1122추가 2012.01.05 woo
            this.grdNUR1122.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR1122.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdNUR1122.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
            this.grdNUR1122.SetBindVarValue("f_ymd", bindVars["f_ymd"].VarValue);
            this.grdNUR1122.SetBindVarValue("f_prevqryflag", ms_PrevQryFlag);
            
            if (!this.grdNUR1122.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            if (!this.grdWatchTemplate.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            //입력날짜를 현재 조회중인 날짜로 바꿔주기.
            for (int i = 0; i < this.grdNUR1122.RowCount; i++)
            {
                this.grdNUR1122.SetItemValue(i, "ymd", this.dtpYmd.GetDataValue());
            }
            this.grdNUR1122.ResetUpdate();

            cboWatchTemplate.SelectedIndex = 0;

            laySiksa.QueryLayout();

            layNUR7002.QueryLayout();
        }
        #endregion

        #region OnLoad
        private ArrayList EditMaskList = new ArrayList();  //Input용 EditMask Control의 List 저장
        public string ms_PrevQryFlag = "N";  //전일자 내역 조회여부 Flag, 당일조회시는 N, 전일 내역 Copy 시는 Y
        string mHospCode = "";
        #endregion

        #region [환자정보 Reques/Receive Event]
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
        #endregion

        #region 환자를 입력을 했을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            GetFkinp1001();

            this.InputLock();
        }
        #endregion

        #region GetFkinp1001()  // fkinp1001을 받아와 txtFkinp1001에 설정 2010.05. 河中
        private void GetFkinp1001()
        {
            string cmdText = "";
            object retVal = null;
            cmdText = "SELECT PKINP1001"
                    + "  FROM VW_OCS_INP1001_01"
                    + " WHERE HOSP_CODE          = '" + this.mHospCode + "'"
                    + "   AND NVL(CANCEL_YN,'N') = 'N'"
                    + "   AND NVL(JAEWON_FLAG,'N') = 'Y'"
                    + "   AND BUNHO = '" + paBox.BunHo.Trim() + "'";

            if (this.paBox.BunHo.ToString() != "")
            {
                retVal = Service.ExecuteScalar(cmdText);
                if (TypeCheck.IsNull(retVal))
                {
                    this.pnlRight.Enabled = false;
                    this.ResetControl(this.pnlRight);
                    this.GetMessage("jeawonYn");
                    return;
                }
                else
                {
                    txtFkinp1001.SetEditValue(retVal.ToString());
                    this.pnlRight.Enabled = true;
                    this.ResetControl(this.pnlRight);
                    //전일자 조회 Flag N로 설정
                    this.ms_PrevQryFlag = "N";
                    this.Query();
                }
            }
            else
            {
                //GetMessage("null");
                return;
            }
        }
        #endregion

        #region 병동 콤보박스를 선택을 했을 때
        private void cboHo_dong_SelectedValueChanged(object sender, System.EventArgs e)
        {
            this.GetPatientList();
        }

        private void GetPatientList()
        {
            //this.ResetControl(this.pnlRight);

            if (this.dtpYmd.GetDataValue().ToString() != "")
            {
                if(!grdPalist.QueryLayout(false))
                {
                    XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
            }
        }
        #endregion

        #region 조회날짜를 선택을 했을 때
        private void dtpYmd_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.GetPatientList();

            // fkinp1001
            this.GetFkinp1001();

            this.InputLock();
           
        }
        #endregion

        private void InputLock()
        {
            // 입력 화면 lock

            string cmdText = @"SELECT CODE_NAME AS LIMIT_YN
                                    , SORT_KEY  AS LIMIT
                                 FROM NUR0102 
                                WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()
                                  AND CODE_TYPE = 'NUR1020_MODIFY_LIMIT'
                                  AND CODE = '01'";

            DataTable dt = Service.ExecuteDataTable(cmdText);

            if (dt.Rows.Count > 0)
            {
                try
                {
                    string limit_yn = dt.Rows[0]["limit_yn"].ToString();
                    int limit = int.Parse(dt.Rows[0]["limit"].ToString()) * -1;

                    if (limit_yn == "Y")
                    {
                        if (DateTime.Parse(dtpYmd.GetDataValue()) <= EnvironInfo.GetSysDate().AddDays(limit))
                        {
                            pnlRight.Enabled = false;
                        }
                        else
                        {
                            pnlRight.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message);
                }

            }
        }


        #region SetDataValue
        private void SetDataValue()
        {

            this.grdData.Reset();
            //Validation Check
            if (!CheckValidation()) return;

            int rowNumber = 0;

            this.grdNUR1020.AcceptData();
            this.grdNUR1020.ResetUpdate();
            //혈압, 맥박, 체온정보 저장
            for (int i = 0; i < this.grdNUR1020.RowCount; i++)
            {
                for (int j = 0; j < this.grdNUR1020.Cols; j++)
                {
                    if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun1") //脈拍
                    {
                        ////공백이면 삭제한다
                        //if (this.grdNUR1020.GetItemValue(i, "pr_gubun1").ToString() != "")
                        //{

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "P");
                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun1").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun1"));
                        //}
                    }

                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun2") //血圧L
                    {
                        ////공백이면 삭제한다
                        //if (this.grdNUR1020.GetItemValue(i, "pr_gubun2").ToString() != "")
                        //{

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "BPL");
                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun2").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun2"));
                        //}
                    }

                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun3") //血圧H
                    {
                        ////공백이면 삭제한다
                        //if (this.grdNUR1020.GetItemValue(i, "pr_gubun3").ToString() != "")
                        //{

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "BPH");
                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun3").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun3"));
                        //}
                    }

                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun4") //体温
                    {
                        //공백이면 삭제한다

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "T");

                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString() == "")
                        {//여기선 Null체크를 안하면 double형으로 바꾸는 부분에서 에러 남.
                            grdData.SetItemValue(rowNumber, "value", "");
                        }
                        else
                        {
                            if (double.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString()) == 0.0)
                                grdData.SetItemValue(rowNumber, "value", "");
                            else
                                grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun4"));
                        }
                    }

                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun5") //spo2
                    {

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "SPO2");

                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun5").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun5"));

                    }

                    // 20070412 - Add Start 
                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun6") //呼吸数
                    {


                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "R");

                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun6").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun6"));

                    }
                    // 20070412 - Add End

                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun7") //血糖
                    {
                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "BS");

                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun7").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun7"));

                    }


                    else if (this.grdNUR1020[i, j].CellName.ToString() == "pr_gubun8") //酸素
                    {
                        ////공백이면 삭제한다

                        rowNumber = this.grdData.InsertRow(-1);
                        grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                        grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                        grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                        grdData.SetItemValue(rowNumber, "gubun1", "A");
                        grdData.SetItemValue(rowNumber, "gubun2", this.grdNUR1020.GetItemValue(i, "vspatn_time").ToString());
                        grdData.SetItemValue(rowNumber, "gubun3", "O2");

                        if (this.grdNUR1020.GetItemValue(i, "pr_gubun8").ToString() == "0")
                            grdData.SetItemValue(rowNumber, "value", "");
                        else
                            grdData.SetItemValue(rowNumber, "value", this.grdNUR1020.GetItemValue(i, "pr_gubun8"));

                    }
                }
            }

            //主食

            //조식

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "B");
            grdData.SetItemValue(rowNumber, "gubun3", "T1");
            grdData.SetItemValue(rowNumber, "value", this.emkSikT1.GetDataValue());  // 주식 식사량
            grdData.SetItemValue(rowNumber, "gubun2", this.emkSikT5.GetDataValue()); // 부식 식사량 

            //중식

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "B");
            grdData.SetItemValue(rowNumber, "gubun3", "T2");
            grdData.SetItemValue(rowNumber, "value", this.emkSikT2.GetDataValue());  // 주식 식사량
            grdData.SetItemValue(rowNumber, "gubun2", this.emkSikT6.GetDataValue()); // 부식 식사량

            //석식

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "B");
            grdData.SetItemValue(rowNumber, "gubun3", "T3");
            grdData.SetItemValue(rowNumber, "value", this.emkSikT3.GetDataValue());  // 주식 식사량
            grdData.SetItemValue(rowNumber, "gubun2", this.emkSikT7.GetDataValue()); // 부식 식사량


            //Dung, Urine
            //DUNG 분류 AS

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "C");
            grdData.SetItemValue(rowNumber, "gubun2", "O");
            grdData.SetItemValue(rowNumber, "gubun3", "AS");
            grdData.SetItemValue(rowNumber, "value", this.cboDungsyochi.GetDataValue());

            //DUNG 횟수 AX

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "C");
            grdData.SetItemValue(rowNumber, "gubun2", "O");
            grdData.SetItemValue(rowNumber, "gubun3", "AX");
            grdData.SetItemValue(rowNumber, "value", this.emkDungCnt.GetDataValue());

            //URINE 량 UT

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "C");
            grdData.SetItemValue(rowNumber, "gubun2", "O");
            grdData.SetItemValue(rowNumber, "gubun3", "UT");
            grdData.SetItemValue(rowNumber, "value", this.emkUrineQuantity.GetDataValue());

            //URINE 횟수 UX

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "C");
            grdData.SetItemValue(rowNumber, "gubun2", "O");
            grdData.SetItemValue(rowNumber, "gubun3", "UX");
            grdData.SetItemValue(rowNumber, "value", this.emkUrineCnt.GetDataValue());

            //記録者

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "WRITER"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
            grdData.SetItemValue(rowNumber, "value", this.fbxWriter1.GetDataValue());

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "WRITER"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "2"); //seq
            grdData.SetItemValue(rowNumber, "value", this.fbxWriter2.GetDataValue());

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "WRITER"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "3"); //seq
            grdData.SetItemValue(rowNumber, "value", this.fbxWriter3.GetDataValue());

            Add_Writer_Before_After();

            //処置

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "SYO"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
            grdData.SetItemValue(rowNumber, "value", this.txtChuchi.GetDataValue());

            //HEIGHT

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "HEIGHT"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
            grdData.SetItemValue(rowNumber, "value", this.emkHeight.GetDataValue() == "0" ? "" : this.emkHeight.GetDataValue());

            //WEIGHT

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "WEIGHT"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
            grdData.SetItemValue(rowNumber, "value", this.emkWeight.GetDataValue() == "0" ? "" : this.emkWeight.GetDataValue());

            //CARE

            rowNumber = this.grdData.InsertRow(-1);
            grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
            grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
            grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
            grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
            grdData.SetItemValue(rowNumber, "gubun2", "CARE"); // gubun
            grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
            grdData.SetItemValue(rowNumber, "value", this.txtCare.GetDataValue());
            /*

            for (int k = 0; k < this.grdNUR1022_IN.RowCount; k++)
            {
                //if(this.grdNUR1022_IN.GetItemValue(k, "io_value_1").ToString() != "")
                {
                    
                    rowNumber = this.grdData.InsertRow(-1);
                    grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                    grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                    grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                    grdData.SetItemValue(rowNumber, "gubun1", "C");
                    grdData.SetItemValue(rowNumber, "gubun2", "I");
                    grdData.SetItemValue(rowNumber, "gubun3", this.grdNUR1022_IN.GetItemString(k, "io_type_1").ToString());
                    grdData.SetItemValue(rowNumber, "value", this.grdNUR1022_IN.GetItemValue(k, "io_value_1"));
                }
            }

            for (int l = 0; l < this.grdNUR1022_OUT.RowCount; l++)
            {
                //if(this.grdNUR1022_OUT.GetItemValue(l, "io_value_2").ToString() != "")
                {
                    
                    rowNumber = this.grdData.InsertRow(-1);
                    grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                    grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                    grdData.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                    grdData.SetItemValue(rowNumber, "gubun1", "C");
                    grdData.SetItemValue(rowNumber, "gubun2", "O");
                    grdData.SetItemValue(rowNumber, "gubun3", this.grdNUR1022_OUT.GetItemString(l, "io_type_2").ToString());
                    grdData.SetItemValue(rowNumber, "value", this.grdNUR1022_OUT.GetItemValue(l, "io_value_2"));
                }
            }
                      
            */


            //환자의 바이탈사인패턴정보 저장
            if (this.cboVspatn_gubun.GetDataValue().ToString() != "")
            {
                this.grdNUR1023.Reset();

                rowNumber = this.grdNUR1023.InsertRow(-1);
                this.grdNUR1023.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                this.grdNUR1023.SetItemValue(rowNumber, "bunho", this.paBox.BunHo.ToString());
                this.grdNUR1023.SetItemValue(rowNumber, "order_date", this.dtpYmd.GetDataValue());
                this.grdNUR1023.SetItemValue(rowNumber, "vspatn_gubun", this.cboVspatn_gubun.GetDataValue().ToString());
            }
        }

        private void Add_Writer_Before_After()
        {
            layWriterBA.QueryLayout(true);

            int rowNumber = 0;

            //오늘 날짜의 첫번째 기록자의 이름이 있을 때,
            if (fbxWriter1.GetDataValue() != "")
            {
                //어제 날짜의 세번째 기록자의 이름이 없을 경우 추가
                if(layWriterBA.LayoutTable.Select("hangmog_seq = '3'").Length == 0 || layWriterBA.LayoutTable.Select("hangmog_seq = '3'")[0]["hangmog_value"].ToString() == "")
                {
                    rowNumber = grdData.InsertRow(-1);
                    grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                    grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                    grdData.SetItemValue(rowNumber, "order_date", DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(-1).ToString("yyyy/MM/dd") );
                    grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
                    grdData.SetItemValue(rowNumber, "gubun2", "WRITER"); // gubun
                    grdData.SetItemValue(rowNumber, "gubun3", "3"); //seq
                    grdData.SetItemValue(rowNumber, "value", this.fbxWriter1.GetDataValue());
                }
            }

            //오늘 날짜의 세번째 기록자의 이름이 있을 때,
            if (fbxWriter3.GetDataValue() != "")
            {
                //내일 날짜의 첫번째 기록자의 이름이 없을 경우 추가
                if (layWriterBA.LayoutTable.Select("hangmog_seq = '1'").Length == 0 || layWriterBA.LayoutTable.Select("hangmog_seq = '1'")[0]["hangmog_value"].ToString() == "")
                {
                    rowNumber = grdData.InsertRow(-1);
                    grdData.SetItemValue(rowNumber, "bunho", this.paBox.BunHo);
                    grdData.SetItemValue(rowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                    grdData.SetItemValue(rowNumber, "order_date", DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(1).ToString("yyyy/MM/dd"));
                    grdData.SetItemValue(rowNumber, "gubun1", "D"); // 입력 테이블
                    grdData.SetItemValue(rowNumber, "gubun2", "WRITER"); // gubun
                    grdData.SetItemValue(rowNumber, "gubun3", "1"); //seq
                    grdData.SetItemValue(rowNumber, "value", this.fbxWriter3.GetDataValue());
                }
            }
        }
        #endregion





        #region +10, 1, -1, -10 Button Click
        private enum UpDownType
        {
            TenDown,
            OneDown,
            OneUp,
            TenUp
        }
        private void UpDownDataValue(UpDownType udType)
        {
            if (this.grdNUR1020.CurrentColNumber > 0 && this.grdNUR1020.CurrentColName != "vspatn_time" && this.grdNUR1020.CurrentRowNumber >= 0)
            {
                double dataValue = 0;
                double updownValue = 0;

                switch (udType)
                {
                    case UpDownType.TenDown:
                        if (this.grdNUR1020.CurrentColName.ToString() == "pr_gubun4")
                            updownValue = -1.0;
                        else
                            updownValue = -10.0;
                        break;
                    case UpDownType.OneDown:
                        if (this.grdNUR1020.CurrentColName.ToString() == "pr_gubun4")
                            updownValue = -0.1;
                        else
                            updownValue = -1.0;
                        break;
                    case UpDownType.OneUp:
                        if (this.grdNUR1020.CurrentColName.ToString() == "pr_gubun4")
                            updownValue = 0.1;
                        else
                            updownValue = 1.0;
                        break;
                    case UpDownType.TenUp:
                        if (this.grdNUR1020.CurrentColName.ToString() == "pr_gubun4")
                            updownValue = 1.0;
                        else
                            updownValue = 10.0;
                        break;
                    default:
                        break;
                }
                dataValue = (this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, this.grdNUR1020.CurrentColName.ToString()).ToString() == "" ? 0.0 : double.Parse(this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, this.grdNUR1020.CurrentColName.ToString()).ToString()));
                dataValue = Math.Max(0.0, dataValue + updownValue);
                this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, this.grdNUR1020.CurrentColName.ToString(), dataValue.ToString());
            }
        }
        private void btnTenDown_Click(object sender, System.EventArgs e)
        {
            UpDownDataValue(UpDownType.TenDown);
        }
        private void btnOneDown_Click(object sender, System.EventArgs e)
        {
            UpDownDataValue(UpDownType.OneDown);
        }

        private void btnOneUp_Click(object sender, System.EventArgs e)
        {
            UpDownDataValue(UpDownType.OneUp);
        }

        private void btnTenUp_Click(object sender, System.EventArgs e)
        {
            UpDownDataValue(UpDownType.TenUp);
        }
        #endregion

        #region GubunItemCollection
        internal class GubunItem
        {
            private string gubun1 = ""; //A.혈압,맥박,온도.. B.식사 C.IN/OUT
            private string gubun2 = ""; //A이면 T1.00, T2.06, T3.12, T4.18, B.이면 없음 C이면 I.IN, O.OUT
            private string gubun3 = ""; //A이면 PR, BPL, BPH, T, B이면 T1.조식,T2.중식,T3.석식, C이면 A1,A2,A3, A4
            private string dataValue = "";  //각 구분별 값
            public string Gubun1
            {
                get { return gubun1; }
            }
            public string Gubun2
            {
                get { return gubun2; }
            }
            public string Gubun3
            {
                get { return gubun3; }
            }
            public string DataValue
            {
                get { return dataValue; }
                set { dataValue = value; }
            }
            public GubunItem(string gubun1, string gubun2, string gubun3)
                : this(gubun1, gubun2, gubun3, "") { }
            public GubunItem(string gubun1, string gubun2, string gubun3, string dataValue)
            {
                this.gubun1 = gubun1;
                this.gubun2 = gubun2;
                this.gubun3 = gubun3;
                this.dataValue = dataValue;

            }
        }
        #endregion

        #region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
        private string mErrMsg = "";
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    e.IsSuccess = false;
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    if (this.paBox.BunHo.ToString() != "")
                    {
                        //전일자 조회 Flag N로 설정
                        this.ms_PrevQryFlag = "N";
                        this.Query();
                    }   
                    else
                    {
                        e.IsBaseCall = false;
                    }
                    break;

                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                    }

                    e.IsBaseCall = false;

                    if (this.paBox.BunHo.ToString() == "")
                    {
                        this.GetMessage("bunho");
                        return;
                    }

                    SetDataValue();
                    
                    mErrMsg = "";                    

                    try
                    {
                        Service.BeginTransaction();
                        if (!this.grdDelete.SaveLayout())   //삭제 할 바이탈 데이터 부분 추가 2012.01.04 woo 
                        {
                            throw new Exception();
                        }
                        //저장할 데이타가 있으면
                        if (grdData.RowCount > 0)
                        {
                            if (!grdData.SaveLayout())
                            {
                                throw new Exception();
                            }
                            if (!grdNUR1023.SaveLayout())
                            {
                                throw new Exception();
                            }
                        }

                        for (int i = 0; i < grdNUR1122.RowCount; i++)
                        {
                            if (grdNUR1122.GetItemValue(i, "hangmog_name").ToString().Equals(""))
                                grdNUR1122.DeleteRow(i);
                        }
                        if (!this.grdNUR1122.SaveLayout())   //환자 별 측정 항목 추가 2012.01.05 woo 
                        {
                            throw new Exception();
                        }
                        Service.CommitTransaction();
                        XMessageBox.Show(Resources.NUR1020U00_TEXT_DL, Resources.NUR1020U00_TEXT_TB, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        XMessageBox.Show(Service.ErrFullMsg, Resources.NUR1020U00_TEXT_LTB, MessageBoxIcon.Error);
                        return;
                    }
                    //this.btnList.PerformClick(FunctionType.Query);

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 버튼리스트에서 버튼 클릭 후 이벤트
        private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    this.pnlRight.Enabled = false;
                    this.cboHo_dong.SetEditValue("");
                    this.cboHo_dong.AcceptData();
                    this.dtpYmd.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                    this.dtpYmd.AcceptData();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 전일카피 버튼을 클릭을 했을 때
        private void btnCopy_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo.ToString() != "")
            {
                //전일자 조회 Flag Y로 설정
                this.ms_PrevQryFlag = "Y";
                this.Query();
            }
        }
        #endregion

        #region MakeInputData, CheckValidation
        private bool CheckValidation()
        {
            // 32 < T.체온 < 42, 20 < BPL.BPL < 120, 100 < BPH.BPH < 220, 20 < PR.PR < 220
            // 0 <= EAT.식사 <= 100, 그외 입력기준은 추후 확인하여 추가
            //Tag에서 Flag 가져옴
            //GubunItem gubunItem = null;
            for (int i = 0; i < this.grdNUR1020.RowCount; i++)
            {
                if ((this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString() != "")
                    && ((double.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString())!=0.0)&&((double.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString()) < 23.0)
                        || (double.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun4").ToString()) > 44.0))))
                {
                    XMessageBox.Show(Resources.NUR1020U00_Text_Validation_Temperature, Resources.NUR1020U00_TEXT_CY, MessageBoxIcon.Information);
                    this.grdNUR1020.SetFocusToItem(i, "pr_gubun4");
                    return false;
                }

                /* 원문 주석 2010.05 河中
                //				if (grdNUR1020[i, 2].CellName.ToString() == "pr_gubun2")
                //				{
                //					if ((this.grdNUR1020.GetItemValue(i, "pr_gubun2").ToString() != "") 
                //						&& ((int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun2").ToString()) < 20) 
                //						|| (int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun2").ToString()) > 120)))
                //					{
                //						XMessageBox.Show("血圧Lを過ち入力なさいました.有効範囲[20 ~ 120]", "注意", MessageBoxIcon.Information);
                //						this.grdNUR1020.SetFocusToItem(i, 2);
                //						return false;
                //					}
                //				}
                //				
                //				if (grdNUR1020[i, 3].CellName.ToString() == "pr_gubun3")
                //				{
                //					if ((this.grdNUR1020.GetItemValue(i, "pr_gubun3").ToString() != "") 
                //						&& ((int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun3").ToString()) < 100) 
                //						|| (int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun3").ToString()) > 220)))
                //					{
                //						XMessageBox.Show("血圧Hを過ち入力なさいました.有効範囲[100 ~ 220]", "注意", MessageBoxIcon.Information);
                //						this.grdNUR1020.SetFocusToItem(i, 3);
                //						return false;
                //					}
                //				}
                //				
                //				if (grdNUR1020[i, 1].CellName.ToString() == "pr_gubun1")
                //				{
                //					if ((this.grdNUR1020.GetItemValue(i, "pr_gubun1").ToString() != "") 
                //						&& ((int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun1").ToString()) < 20) 
                //						|| (int.Parse(this.grdNUR1020.GetItemValue(i, "pr_gubun1").ToString()) > 220)))
                //					{
                //						XMessageBox.Show("脈拍を過ち入力なさいました.有効範囲[20 ~ 220]", "注意", MessageBoxIcon.Information);
                //						this.grdNUR1020.SetFocusToItem(i, 1);
                //						return false;
                //					}
                //				}
                 */ 
            }

            if ((this.emkSikT1.GetDataValue().ToString() != "")
                && ((int.Parse(this.emkSikT1.GetDataValue().ToString()) < 0)
                || (int.Parse(this.emkSikT1.GetDataValue().ToString()) > 100))
                || (this.emkSikT2.GetDataValue().ToString() != "")
                && ((int.Parse(this.emkSikT2.GetDataValue().ToString()) < 0)
                || (int.Parse(this.emkSikT2.GetDataValue().ToString()) > 100))
                || (this.emkSikT3.GetDataValue().ToString() != "")
                && ((int.Parse(this.emkSikT3.GetDataValue().ToString()) < 0)
                || (int.Parse(this.emkSikT3.GetDataValue().ToString()) > 100)))
            {
                XMessageBox.Show(Resources.NUR1020U00_TEXXT_CDAU, Resources.NUR1020U00_TEXT_CY, MessageBoxIcon.Information);
                if ((this.emkSikT1.GetDataValue().ToString() != "")
                && ((int.Parse(this.emkSikT1.GetDataValue().ToString()) < 0)
                || (int.Parse(this.emkSikT1.GetDataValue().ToString()) > 100)))
                    this.emkSikT1.Focus();

                else if ((this.emkSikT2.GetDataValue().ToString() != "")
                    && ((int.Parse(this.emkSikT2.GetDataValue().ToString()) < 0)
                    || (int.Parse(this.emkSikT2.GetDataValue().ToString()) > 100)))
                    this.emkSikT2.Focus();

                else if ((this.emkSikT3.GetDataValue().ToString() != "")
                    && ((int.Parse(this.emkSikT3.GetDataValue().ToString()) < 0)
                    || (int.Parse(this.emkSikT3.GetDataValue().ToString()) > 100)))
                    this.emkSikT3.Focus();

                return false;
            }

            //혈압상은 혈압하보다 작을 수 없음
            int BPLValue = 0, BPHValue = 0;
            BPLValue = this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, "pr_gubun2").ToString() == "" ? 0 : int.Parse(this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, "pr_gubun2").ToString());
            BPHValue = this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, "pr_gubun3").ToString() == "" ? 0 : int.Parse(this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, "pr_gubun3").ToString());
            if (BPLValue > BPHValue)
            {
                XMessageBox.Show(Resources.NUR1020U00_CheckValidation_, Resources.NUR1020U00_TEXT_CY, MessageBoxIcon.Information);
                this.grdNUR1020.SetFocusToItem(this.grdNUR1020.CurrentRowNumber, "pr_gubun2");
                return false;
            }
            return true;

        }
        #endregion

        #region 입력 TextBox 입력값 통제, KeyPress, KeyDown 통제
        private void SetEventHandlerToTextBox()
        {
            /* 원본 주석 2010.05. 河中
            //textBoxList에 TextBox Control 저장
            //Tag에는 GubunItem을 생성하여 SET

            //			this.EditMaskList.Add(emkSikT1);
            //			this.EditMaskList.Add(emkSikT2);
            //			this.EditMaskList.Add(emkSikT3);
            //			emkSikT1.Tag = new GubunItem("B","","T1");
            //			emkSikT2.Tag = new GubunItem("B","","T2");
            //			emkSikT3.Tag = new GubunItem("B","","T3");
            //
            //			//GotFocus
            //			foreach (TextBox cont in EditMaskList)
            //			{
            //				//cont.GotFocus += new EventHandler(this.TextBox_GotFocus);
            //				cont.KeyPress += new KeyPressEventHandler(this.TextBox_KeyPress);
            //				cont.KeyDown  += new KeyEventHandler(this.TextBox_KeyDown);
            //			}
             */
        }
        private bool IsCorrectChar(char ch, string flag)
        {
            bool ret = false;
            //TextBox Tag에 Flag 저장
            //T.체온은 2자리.소수1자리만 입력가능, 그외는 MaxLength까지 입력가능
            //D.IN,OUT (숫자만 입력가능, 0 - 4자리)
            switch (flag)
            {
                case "T":
                    ret = Char.IsDigit(ch) || (ch == 8) || (ch == 46);  // 숫자, BackSpace, .
                    break;
                default:
                    ret = Char.IsDigit(ch) || (ch == 8);  // 숫자, BackSpace
                    break;
            }
            return ret;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox cont = (TextBox)sender;
            //Tag에 GubunItem 저장
            string flag = ((GubunItem)cont.Tag).Gubun3; //구분 3에 T, PR,BPH,BPL등이 있음
            if (e.KeyChar != (char)13)  // Enter시 Tab Key 발생
            {
                if (IsCorrectChar(e.KeyChar, flag))
                {
                    if (Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;

                        // 전체선택이면 NullText Set
                        if (cont.SelectedText == cont.Text)
                        {
                            //첫번째자리에 0입력불가
                            if (e.KeyChar.ToString() == "0") return;

                            cont.Text = e.KeyChar.ToString();
                            cont.SelectionStart = 1;
                        }
                        else if (cont.SelectionLength == 0)
                        {
                            //최대값 도달시 입력불가
                            if (cont.MaxLength <= cont.Text.Length) return;

                            //첫번째자리에 0입력불가
                            if ((cont.Text.Length == 0) && (e.KeyChar.ToString() == "0")) return;

                            if (flag == "T") //소수점 파악, 소수점이하자리는 1자리만 입력가능, 앞에는 두자리
                            {
                                int index = cont.Text.IndexOf(".");
                                if (index >= 0)
                                {
                                    //이미 12.3을 입력했으면 입력불가
                                    if (cont.Text.Length - index > 1) return;
                                }
                                else
                                {
                                    //이미 12를 입력했으면 입력불가
                                    if (cont.Text.Length == 4) return;
                                }
                            }
                            cont.Text += e.KeyChar.ToString();
                            cont.SelectionStart = cont.Text.Length;
                        }
                    }
                    else if (e.KeyChar == 8) //BackSpace
                    {
                        e.Handled = false;
                    }
                    else if (e.KeyChar == 46) //.
                    {
                        e.Handled = true;
                        //체온 37.5형식에서 .은 2자리 입력후만 가능
                        if (cont.Text.Length == 4)
                        {
                            cont.Text += e.KeyChar;
                            cont.SelectionStart = cont.Text.Length;
                        }
                    }
                }
                else
                    e.Handled = true; //그외 Key는 모두 입력불가
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox cont = (TextBox)sender;
            //Tag에 GubunItem 저장
            string flag = ((GubunItem)cont.Tag).Gubun3; //구분 3에 T, PR,BPH,BPL등이 있음

        }
        #endregion

        #region 환자리스트 그리드에서 두번 클릭을 했을 때의 이벤트
        private void grdPalist_DoubleClick(object sender, System.EventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
                this.txtFkinp1001.SetEditValue(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "pkinp1001").ToString());

                this.paListRownum = grdPalist.CurrentRowNumber;                
            }
        }
        #endregion

        #region 바이탈사인버튼을 클릭을 했을 때
        private void btnGraph_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo.ToString() == "")
            {
                this.GetMessage("bunho");
                return;
            }
            else
            {
                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("sysid", "NURI");
                openParams.Add("screen", this.ScreenID.ToString());
                openParams.Add("bunho", this.paBox.BunHo);
                openParams.Add("date", this.dtpYmd.GetDataValue());
                openParams.Add("hodong", this.cboHo_dong.GetDataValue());
                XScreen.OpenScreenWithParam(this, "NURI", "NUR1020Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, openParams);
            }
        }
        #endregion

        #region 팝업으로 오픈시 발생
        private void NUR1020U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);

            CreatePopUpMenu();

            string mBunho = "";
            this.mHospCode = EnvironInfo.HospCode;

            //시간패턴콤보박스를 셋팅한다.
            this.SetVspatn_gubun();

            //등록번호를 입력하기 전에 화면의 입력을 막는다.
            this.pnlRight.Enabled = false;

            //입력용 TextBox에 GotFocus, KeyPress, KeyDown Event 연결
            SetEventHandlerToTextBox();

            if (this.OpenParam != null)
            {
                this.sysid = OpenParam["sysid"].ToString();
                this.screen = OpenParam["screen"].ToString();

                //병동은 해당유저의 병동으로 환자리스트를 조회처리
                //if (UserInfo.HoDong != "")
                //{
                //    this.cboHo_dong.SetDataValue(UserInfo.HoDong);
                //    layNURList.QueryLayout(true);
                //}
                //else
                //    this.cboHo_dong.SetDataValue("1");

                //this.flag = "N";
                this.dtpYmd.SetEditValue(this.OpenParam["date"].ToString());
                this.dtpYmd.AcceptData();

                //해당환자의 바이탈사인 입력처리
                mBunho = this.OpenParam["bunho"].ToString();
                this.paBox.SetPatientID(mBunho);
                //this.flag = "Y";
            }
            else
            {
                // 조회일자를 디폴트로 현재일자를 셋팅
                this.dtpYmd.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpYmd.AcceptData();

                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    mBunho = patientInfo.BunHo;
                    this.paBox.SetPatientID(mBunho);
                    this.btnList.Focus();                    
                }
            }

            string sqlcmd = "SELECT HO_DONG1 FROM VW_OCS_INP1001_01 WHERE HOSP_CODE='" + EnvironInfo.HospCode + "' AND BUNHO = '" + paBox.BunHo + "'";

            object result = Service.ExecuteScalar(sqlcmd);

            if (result != null)
            {
                this.cboHo_dong.SetEditValue(result.ToString());
            }
            
            layNURList.QueryLayout(true);


            //환자번호를 환자 리스트에 표시
            this.grdPalist.UnSelectAll();
            for (int i = 0; i < this.grdPalist.RowCount; i++)
            {
                if (this.grdPalist.GetItemString(i, "bunho") == mBunho)
                {
                    this.grdPalist.SelectRow(i);
                    grdPalist.SetFocusToItem(i, "bunho");
                    paListRownum = i;
                    break;
                }
            }

            try
            {
                if (((XScreen)Opener).ScreenID == "NUR1020Q00")
                    btnGraph.Visible = false;
                else
                    btnGraph.Visible = true;
            }
            catch
            {
                btnGraph.Visible = true;
            }
            finally
            { }
        }
        #endregion

        #region 시간패턴콤보박스 셋팅
        private void SetVspatn_gubun()
        {
            this.layCombo.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layCombo.SetBindVarValue("f_code_type", "VSPATN_GUBUN");

            if (this.layCombo.QueryLayout(false))
            {
                if (this.layCombo.RowCount > 0)
                {
                    this.cboVspatn_gubun.SetComboItems(this.layCombo.LayoutTable, "code_name", "code");
                }
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }
        #endregion

        #region 시간패턴을 변경을 했을 때
        private void cboVspatn_gubun_SelectedValueChanged(object sender, System.EventArgs e)
        {
            //if (this.cboVspatn_gubun.GetDataValue().ToString() != "")
            //{
            //    this.SetVspatn_time();
            //}
        }
        /* 위의 이벤트에서 아래의 이벤트로 변경. 
         * 변경 이유는 위의 이벤트일 경우엔 스크린이 오픈되고 로직으로인해 콤보박스의 시간이 선택되면서
         * cboVspatn_gubun_SelectedValueChanged 이벤트를 타고 SetVspatn_time()
         * 메소드를 돌기 때문이다. 콤보박스의 시간을 선택해 준 후에도 SetVspatn_time()메소드는
         * 타기때문에 굳이 거기서 돌릴 필요가없다.
         * 그래서 사용자가 직업 콤보박스에서 선택을 했을때만 발생되는
         * SelectionChangeCommitted 이벤트로 바꿔 줬다. 2011.12.29 woo */
        private void cboVspatn_gubun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.SetVspatn_time();
        }
        #endregion

        #region 시간패턴콤보박스를 변경을 했을 때 시간조회
        private void SetVspatn_time()
        {
            this.txtFkinp1001.AcceptData();

            /*----- dsvNUR1023QUERY Service 변환 2010.05. 河中 -----*/
            string cmdText = string.Empty; DataTable resTbl = new DataTable(); object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            bindVars.Add("f_hosp_code", this.mHospCode);
            bindVars.Add("f_bunho", this.paBox.BunHo);
            bindVars.Add("f_date", this.dtpYmd.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
            bindVars.Add("f_fkinp1001", Convert.ToInt64(this.txtFkinp1001.GetDataValue()).ToString());

            //↓날짜 조건 적용 2012.01.04 woo
            this.grdNUR1020.SetBindVarValue("f_date", this.dtpYmd.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));

            if (ms_PrevQryFlag.Equals("Y"))
            {
                retVal = Service.ExecuteScalar(@"SELECT NVL(MAX(YMD), TO_DATE(:f_date,'YYYYMMDD')) YMD
                                                   FROM NUR1020
                                                  WHERE HOSP_CODE = :f_hosp_code
                                                    AND BUNHO     = :f_bunho
                                                    AND YMD       < :f_date", bindVars);
                bindVars.Remove("f_date");
                bindVars.Add("f_date", retVal.ToString().Replace("-", "").Replace("/", "").Substring(0, 8));

                //↓전날 데이터 갖고올 경우 날짜 조건 적용 2012.01.04 woo
                this.grdNUR1020.SetBindVarValue("f_date", retVal.ToString().Replace("-", "").Replace("/", "").Substring(0, 8));
            }


            if (!grdNUR1020.QueryLayout(false))
            {
                XMessageBox.Show("Error", Resources.NUR1020U00_TEXT_LTKTG, MessageBoxIcon.Hand);
                return;
            }
        }
        #endregion

        #region 추가버튼을 클릭을 했을 때
        private void btnInsert_Click(object sender, System.EventArgs e)
        {

            string vspatn_time = EnvironInfo.GetSysDateTime().ToString("HHmm");

            this.grdNUR1020.InsertRow();
            this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "bunho", this.paBox.BunHo.ToString());
            this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "fkinp1001", Convert.ToInt64(this.txtFkinp1001.GetDataValue()));
            this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "ymd", this.dtpYmd.GetDataValue());
            this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "vspatn_gubun", this.cboVspatn_gubun.GetDataValue());
            this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "vspatn_time", vspatn_time);
            this.grdNUR1020.Sort("vspatn_time desc"); //시간순으로 내림차순 정렬 한 후

            for (int i = 0; i < grdNUR1020.RowCount; i++)
            {
                if (grdNUR1020.GetItemString(i, "vspatn_time") == vspatn_time)
                {
                    this.grdNUR1020.SetFocusToItem(i, "vspatn_time", true);
                }
            }
            
            //this.grdNUR1020.SetFocusToItem(0, "vspatn_time", true);   //포커스를 시간으로 주자.
        }
        #endregion

        #region 시간패턴 선택하고 적용 버튼 누를 때
        private void btnTimeApply_Click(object sender, EventArgs e)
        {
            this.grdNUR1020.Reset();
            DataTable tmpTable = new DataTable();
            string cmdText = @" SELECT VSPATN_TIME
                                  FROM NUR0105
                                 WHERE HOSP_CODE        = FN_ADM_LOAD_HOSP_CODE()
                                   AND VSPATN_GUBUN     = '" + this.cboVspatn_gubun.GetDataValue()+"' ORDER BY 1 DESC";
            tmpTable = Service.ExecuteDataTable(cmdText);
            for (int i = 0; i < tmpTable.Rows.Count; i++)
            {
                this.grdNUR1020.InsertRow();
                this.grdNUR1020.SetItemValue(this.grdNUR1020.CurrentRowNumber, "vspatn_time", tmpTable.Rows[i]["vspatn_time"].ToString());
            }

        }
        #endregion

        private void grdNUR1020_Click(object sender, System.EventArgs e)
        {
            //Tag에 저장된 구분에 따라 +10,+1 버튼 활성화 비활성과 Text Set
            //Tag의 구분1이 A이고 구분 3이 T.체온이면 1, + 0.1, 로 설정
            //GubunItem gItem = (GubunItem) focusEditBox.Tag;
            if (this.grdNUR1020.CurrentColNumber > 0 && this.grdNUR1020.CurrentColName != "vspatn_time" && this.grdNUR1020.CurrentRowNumber >= 0)//(gItem.ToString == "A")
            {
                this.btnOneDown.Enabled = true;
                this.btnTenDown.Enabled = true;
                this.btnOneUp.Enabled = true;
                this.btnTenUp.Enabled = true;
                if (this.grdNUR1020.CurrentColName.ToString() == "pr_gubun4")
                {
                    this.btnTenDown.Text = "- 1";
                    this.btnOneDown.Text = "- 0.1";
                    this.btnOneUp.Text = "+ 0.1";
                    this.btnTenUp.Text = "+ 1";
                }
                else
                {
                    this.btnTenDown.Text = "- 10";
                    this.btnOneDown.Text = "- 1";
                    this.btnOneUp.Text = "+ 1";
                    this.btnTenUp.Text = "+ 10";
                }
            }
            else
            {
                this.btnOneDown.Enabled = false;
                this.btnTenDown.Enabled = false;
                this.btnOneUp.Enabled = false;
                this.btnTenUp.Enabled = false;
            }
        }

        #region 현재ROW를 삭제한다.
        /// <summary>
        /// 행삭제 버튼을 누르면 Delete할 데이터의 키 값들만 Delete용 Grid에 넣는다.
        /// 현재Grid(grdNUR1020)에서는 행 삭제를 시킨다.
        /// 나중에 저장 버튼을 눌렀을 때 CallerID가 4 인 grdDelete의 SavePerformer 내용은
        /// 키 값들을 가지고 해당 키 값의 내용을 삭제시킨다.
        /// 2012.01.04 Happy New Yaer~ woo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (this.grdNUR1020.CurrentRowNumber > -1)
            {

                //2012.01.24 행 삭제 시 NUR1022_OUT테이블에서 뇨총량과 횟수가 줄어들게 하기.
                //if (this.grdNUR1020.GetItemString(this.grdNUR1020.CurrentRowNumber, "pr_gubun6") != "")
                //{
                //    for (int i = 0; i < this.grdNUR1022_OUT.RowCount; i++)
                //    {
                //        if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "UT")
                //        {
                //            string beforeUT = this.grdNUR1022_OUT.GetItemString(i, "io_value_2");
                //            int afterUT = Int32.Parse(beforeUT) - this.grdNUR1020.GetItemInt(this.grdNUR1020.CurrentRowNumber, "pr_gubun6");
                //            this.grdNUR1022_OUT.SetItemValue(i, "io_value_2", afterUT.ToString());

                //        }
                //        else if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "UX")
                //        {
                //            string beforeUC = this.grdNUR1022_OUT.GetItemString(i, "io_value_2");
                //            int afterUC = Int32.Parse(beforeUC) - 1;
                //            this.grdNUR1022_OUT.SetItemValue(i, "io_value_2", afterUC.ToString());
                //        }
                //    }
                //}

                this.grdDelete.InsertRow();
                this.grdDelete.SetItemValue(this.grdDelete.CurrentRowNumber, "bunho", this.paBox.BunHo);
                this.grdDelete.SetItemValue(this.grdDelete.CurrentRowNumber, "ymd", this.dtpYmd.GetDataValue());
                this.grdDelete.SetItemValue(this.grdDelete.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
                this.grdDelete.SetItemValue(this.grdDelete.CurrentRowNumber, "time", this.grdNUR1020.GetItemValue(this.grdNUR1020.CurrentRowNumber, "vspatn_time"));
                this.grdNUR1020.DeleteRow(this.grdNUR1020.CurrentRowNumber);
            }
        }
        #endregion

        #region [=============================---============ Custom Methods ============---=============================]

        #region GrdNur1020Delete() / dsvNur1020Delete -  저장처리 2010.05. 河中
//        private bool GrdNur1020Delete()
//        {
//            string cmdText = string.Empty;
//            BindVarCollection bindVars = new BindVarCollection();
//            object retVal = null;

//            Service.BeginTransaction();

//            /* 기존 삭제로직 주석처리하고 새로운 삭제로직 작성. 2011.12.29 woo*/
//            for (int i = 0; i < mDeleteTime.Count; i++)
//            {
//                cmdText = @"DELETE NUR1020
//                                 WHERE HOSP_CODE  = :f_hosp_code 
//                                   AND BUNHO      = :f_bunho
//                                   AND FKINP1001  = :f_fkinp1001
//                                   AND YMD        = TO_DATE(:f_ymd, 'YYYY/MM/DD')
//                                   AND TIME_GUBUN = :f_time";
//                bindVars.Clear();
//                bindVars.Add("f_hosp_code", this.mHospCode);
//                bindVars.Add("f_bunho", paBox.BunHo);
//                bindVars.Add("f_fkinp1001", this.txtFkinp1001.GetDataValue());
//                bindVars.Add("f_ymd", dtpYmd.GetDataValue().ToString().Replace("/", "").Replace("-", "").Substring(0, 8));
//                bindVars.Add("f_time", mDeleteTime[i].ToString());
//                try
//                {
//                    Service.ExecuteNonQuery(cmdText, bindVars);
//                }
//                catch (Exception e)
//                {
//                    Service.RollbackTransaction();
//                    XMessageBox.Show(e.Message);
//                    return false;
//                }
//            }

//            /* 기존의 삭제로직은 삭제한 행을 삭제하는게 아니라 남아있는 행을 삭제하고있다. */
//            /*for (int i = 0; i < grdNUR1020.RowCount; i++)
//            {
//                cmdText = "";
//                cmdText = @"SELECT 'X'
//                              FROM NUR1020
//                             WHERE HOSP_CODE  = :f_hosp_code 
//                               AND BUNHO      = :f_bunho
//                               AND FKINP1001  = :f_fkinp1001
//                               AND YMD        = TO_DATE(:f_ymd, 'YYYY/MM/DD')
//                               AND TIME_GUBUN = :f_time";
//                bindVars.Clear();
//                bindVars.Add("f_hosp_code", this.mHospCode);
//                bindVars.Add("f_bunho", grdNUR1020.GetItemString(i, "bunho"));
//                bindVars.Add("f_fkinp1001", grdNUR1020.GetItemString(i, "fkinp1001"));
//                bindVars.Add("f_ymd", grdNUR1020.GetItemString(i, "ymd").Replace("/", "").Replace("-", "").Substring(0, 8));
//                bindVars.Add("f_time", grdNUR1020.GetItemString(i, "vspatn_time"));

//                retVal = Service.ExecuteScalar(cmdText, bindVars);

//                if (!TypeCheck.IsNull(retVal))
//                {
//                    cmdText = "";
//                    cmdText = @"DELETE NUR1020
//                                 WHERE HOSP_CODE  = :f_hosp_code 
//                                   AND BUNHO      = :f_bunho
//                                   AND FKINP1001  = :f_fkinp1001
//                                   AND YMD        = TO_DATE(:f_ymd, 'YYYY/MM/DD')
//                                   AND TIME_GUBUN = :f_time";
//                    try
//                    {
//                        Service.ExecuteNonQuery(cmdText, bindVars);
//                    }
//                    catch (Exception xe)
//                    {
//                        Service.RollbackTransaction();
//                        XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace);
//                        return false;
//                    }
//                }
//                else if (TypeCheck.IsNull(null)) break;
//            }
//             */
//            Service.CommitTransaction();
//            this.mDeleteTime.Clear();
//            DeleteYn = "N";
//            return true;
//        }
        #endregion
        #endregion

        #region grdNUR1020 바인드 변수 설정
        private void grdNUR1020_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDelete.Reset();
            grdNUR1020.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR1020.SetBindVarValue("f_bunho", this.paBox.BunHo);
            grdNUR1020.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
            grdNUR1020.SetBindVarValue("f_vspatn_gubun", this.cboVspatn_gubun.GetDataValue());
        }
        #endregion

        private void grdNUR1022_OUT_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //string temp = e.DataRow["io_type_2"].ToString();
            //if (temp == "UT" || temp == "UX")
            //    e.Protect = true;
            //else
            //    e.Protect = false;
        }

        private void grdNUR1022_OUT_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            //string temp = e.DataRow["io_type_2"].ToString();
            //if (temp == "UT"||temp == "UX")
            //    e.ForeColor = Color.SteelBlue;
        }

        private void grdNUR1022_OUT_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            int val_u1 = 0;
            int val_u2 = 0;
            int val_u3 = 0;
            int rowNum_ut = -1;
            string t_val = "";

            if (e.DataRow["io_type_2"].ToString() == "U1" ||
                e.DataRow["io_type_2"].ToString() == "U2" ||
                e.DataRow["io_type_2"].ToString() == "U3")
            {
                for (int i = 0; i < this.grdNUR1022_OUT.RowCount; i++)
                {
                    if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "U1")
                    {
                         t_val = this.grdNUR1022_OUT.GetItemString(i, "io_value_2").Trim();
                         if (t_val != "")
                             val_u1 = Convert.ToInt32(t_val);
                     } 
                    if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "U2")
                     {
                         t_val = this.grdNUR1022_OUT.GetItemString(i, "io_value_2").Trim();
                         if (t_val != "")
                             val_u2 = Convert.ToInt32(t_val);
                     } 
                    if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "U3")
                     {
                         t_val = this.grdNUR1022_OUT.GetItemString(i, "io_value_2").Trim();
                         if (t_val != "")
                             val_u3 = Convert.ToInt32(t_val);
                     }

                    if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "UT")
                        rowNum_ut = i;

                }
                int total_val = val_u1 + val_u2 + val_u3;
                this.grdNUR1022_OUT.SetItemValue(rowNum_ut, "io_value_2", total_val);
            }
        }

        //소변양 입력 시 하루 소변양과 횟수를 계산해서 아래 grdNUR1022_OUT에 표시 2012.01.23
        private void grdNUR1020_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //int u_total = 0;
            //int u_count = 0;

            //if (e.ColName == "pr_gubun6")   //변경된 컬럼이 소변컬럼일 때~
            //{
            //    for (int i = 0; i < this.grdNUR1020.RowCount; i++)    //그리드를 한줄한줄 읽으며~
            //    {
            //        string u = this.grdNUR1020.GetItemString(i, "pr_gubun6");
            //        if ((!(TypeCheck.IsNull(u)))&&u!="0")
            //        {
            //            u_total += Int32.Parse(u);
            //            u_count++;
            //        }
            //    }
            //    for (int i = 0; i < this.grdNUR1022_OUT.RowCount; i++)
            //    {
            //        if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "UT")
            //        {
            //            this.grdNUR1022_OUT.SetItemValue(i, "io_value_2", u_total.ToString());
            //        }
            //        else if (this.grdNUR1022_OUT.GetItemString(i, "io_type_2") == "UX")
            //        {
            //            this.grdNUR1022_OUT.SetItemValue(i, "io_value_2", u_count.ToString());
            //        }
            //    }
            //}


        }

        #region NUR1122 관련
        private void layHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layHangmog.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layHangmog.SetBindVarValue("f_code_type", "WATCH_HANGMOG");
            this.layHangmog.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.Text);
            this.layHangmog.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void SetHangmogCode()
        {
            layHangmog.Reset();
            if (this.layHangmog.QueryLayout(true))
            {
                this.grdNUR1122.SetComboItems("hangmog_code", this.layHangmog.LayoutTable, "code_name", "code");                    
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg);
            }
        }

        private void btnNUR1122Insert_Click(object sender, EventArgs e)
        {
            this.grdNUR1122.InsertRow(-1);
            int rowNum = this.grdNUR1122.CurrentRowNumber;
            this.grdNUR1122.SetItemValue(rowNum, "bunho", this.paBox.BunHo);
            this.grdNUR1122.SetItemValue(rowNum, "fkinp1001", this.txtFkinp1001.GetDataValue());
            this.grdNUR1122.SetItemValue(rowNum, "ymd", this.dtpYmd.GetDataValue());
        }

        private void btnNUR1122Delete_Click(object sender, EventArgs e)
        {
            if (this.grdNUR1122.CurrentRowNumber > -1)
            {
                this.grdNUR1122.DeleteRow(this.grdNUR1122.CurrentRowNumber);
            }
        }

        private void grdNUR1122_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "hangmog_code")
            {
                for (int i = 0; i < e.RowNumber - 1; i++)
                {
                    if (this.grdNUR1122.GetItemString(i, "hangmog_code").Equals(this.grdNUR1122.GetItemString(e.RowNumber, "hangmog_code")))
                    {
                        XMessageBox.Show(Resources.NUR1020U00_TEXT_VALIDATE_RULE, Resources.NUR1020U00_TEXT_TRL, MessageBoxIcon.Error);
                        grdNUR1122.SetItemValue(grdNUR1122.CurrentRowNumber, "hanmog_code", "");
                        //e.Cancel = true;
                        return;
                    }
                }
            }
        }


        #endregion


        #region 관리항목 정형문관련 2012.01.26
        private void grdHangmog_Comment_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdWatchTemplate.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdWatchTemplate.SetBindVarValue("f_code_type", cboWatchTemplate.GetDataValue());
        }

        private void grdHangmog_Comment_DoubleClick(object sender, EventArgs e)
        {
            int commentRow = this.grdWatchTemplate.CurrentRowNumber;
            int nur1122Row = this.grdNUR1122.CurrentRowNumber;
            string nur1122Col = this.grdNUR1122.CurrentColName;
            if (commentRow < 0)
                return;
            if (nur1122Row < 0)
                return;
            if (this.grdNUR1122.CurrentColNumber < 1)
                return;

            string comment = this.grdWatchTemplate.GetItemString(commentRow, "code_name");
            this.grdNUR1122.SetItemValue(nur1122Row, nur1122Col, comment);
        }

        //정형문 관리 버튼 눌렀을 시.
        private void btnNUR0101U00_Click(object sender, EventArgs e)
        {
            CommonItemCollection openPrams = new CommonItemCollection();
            openPrams.Add("code_type", cboWatchTemplate.GetDataValue());
            XScreen.OpenScreenWithParam(this, "NURI", "NUR1123U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, openPrams);
            this.grdWatchTemplate.QueryLayout(false);
        }

        #endregion

        #region XSavePerformer
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR1020U00 parent = null;

            public XSavePerformer(NUR1020U00 parent)
            {
                this.parent = parent;
            }
            //Execute 구현
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_ymd", parent.dtpYmd.GetDataValue());

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                
                                ArrayList inputList = new ArrayList();
                                ArrayList outputList = new ArrayList();

                                inputList.Add(UserInfo.UserID);
                                inputList.Add(parent.mHospCode);
                                inputList.Add(parent.paBox.BunHo);
                                inputList.Add(parent.txtFkinp1001.GetDataValue());
                                inputList.Add(item.BindVarList["f_order_date"].VarValue);
                                inputList.Add(item.BindVarList["f_gubun1"].VarValue);
                                inputList.Add(item.BindVarList["f_gubun2"].VarValue);
                                inputList.Add(item.BindVarList["f_gubun3"].VarValue);
                                inputList.Add(item.BindVarList["f_value"].VarValue);

                                if(!Service.ExecuteProcedure("PR_NUR_INPUT_VITAL_VALUE", inputList, outputList))
                                {
                                    parent.mErrMsg = Service.ErrFullMsg;
                                    return false;
                                }

                                if (item.BindVarList["f_gubun1"].VarValue.Equals("C") &&
                                    item.BindVarList["f_gubun2"].VarValue.Equals("O") &&
                                    item.BindVarList["f_gubun3"].VarValue.Equals("UT") && //뇨 총량
                                    !item.BindVarList["f_value"].VarValue.Equals("0") &&
                                    !item.BindVarList["f_value"].VarValue.Equals(""))
                                {
                                    inputList.Clear();
                                    inputList.Add(item.BindVarList["f_order_date"].VarValue);
                                    inputList.Add(item.BindVarList["f_bunho"].VarValue);
                                    inputList.Add(item.BindVarList["f_fkinp1001"].VarValue);

                                    if (!Service.ExecuteProcedure("PR_CPL_INSERT_URINE", inputList, outputList))
                                    {

                                        parent.mErrMsg = "ERROR CODE : " + outputList[1].ToString() + "\n\r" +
                                            "ERROR MESSEAGE : " + outputList[0].ToString();
                                        //XMessageBox.Show("ERROR CODE : " + outputList[1].ToString() + "\n\r" +
                                        //    "ERROR MESSEAGE : " + outputList[0].ToString(), "Procedure Error");
                                        return false;
                                    }

                                    if (outputList[1].ToString() != "0")
                                    {
                                        parent.mErrMsg = "ERROR CODE : " + outputList[1].ToString() + "\n\r" +
                                            "ERROR MESSEAGE : " + outputList[0].ToString();
                                        //XMessageBox.Show("ERROR CODE : " + outputList[1].ToString() + "\n\r" +
                                        //    "ERROR MESSEAGE : " + outputList[0].ToString(), "Procedure Error");
                                        return false;
                                    }
                                }
                                return true;

                            //case DataRowState.Modified:
                            //    cmdText = @"";
                            //    break;

                            //case DataRowState.Deleted:
                            //    cmdText = @"";
                            //    break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'X'
                                              FROM NUR1023
                                             WHERE HOSP_CODE  = :f_hosp_code 
                                               AND FKINP1001  = :f_fkinp1001
                                               AND BUNHO      = :f_bunho
                                               AND ORDER_DATE = :f_order_date";
                                if (!TypeCheck.IsNull(Service.ExecuteScalar(cmdText, item.BindVarList)))
                                {
                                    cmdText = "";
                                    cmdText = @"UPDATE NUR1023
                                                   SET UPD_ID       = :q_user_id
                                                     , UPD_DATE     = SYSDATE 
                                                     , VSPATN_GUBUN = :f_vspatn_gubun
                                                 WHERE HOSP_CODE    = :f_hosp_code 
                                                   AND FKINP1001    = :f_fkinp1001
                                                   AND BUNHO        = :f_bunho
                                                   AND ORDER_DATE   = :f_order_date";
                                }
                                else
                                {
                                    cmdText = "";
                                    cmdText = @"INSERT INTO NUR1023
                                                     ( SYS_DATE          , SYS_ID          , UPD_DATE        , UPD_ID      ,
                                                       HOSP_CODE         , FKINP1001       , BUNHO           , ORDER_DATE  ,
                                                       VSPATN_GUBUN      )
                                                VALUES  
                                                     ( SYSDATE           , :q_user_id      , SYSDATE         , :q_user_id    ,
                                                       :f_hosp_code      , :f_fkinp1001    , :f_bunho        , :f_order_date ,
                                                       :f_vspatn_gubun   )";
                                }
                                break;

                            //case DataRowState.Modified:
                            //    cmdText = @"";
                            //    break;

                            //case DataRowState.Deleted:
                            //    cmdText = @"";
                            //    break;
                        }
                        break;
                    case '3':   //환자 별 항목 측정 2012.01.05 woo
                        /* Grid 의 IncludeUnChangedRowAtSaving (default = false) 속성을 true로 하면 
                         * 수정된 항목이 없더라도 SavePerformer 안으로 들어오게 된다. 
                         * 이렇게 하는 이유는 전일내역복사로 바로 저장 할 경우 바뀐 항목이 없더라도 
                         * SavePerformer를 태워 저장을 해 주기 위해서이다.(전일내역복사는 조회로 불러오기 때문)
                         * 2012.01.05 woo*/
                        switch (item.RowState)
                        {                            
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                cmdText = string.Empty;
                                cmdText = @"BEGIN

                                            INSERT INTO NUR1122
                                                   (SYS_DATE, SYS_ID, UPD_DATE, UPD_ID, BUNHO,
                                                    FKINP1001, YMD, HANGMOG_CODE, HANGMOG_VALUE1, 
                                                    HANGMOG_VALUE2, HANGMOG_VALUE3, HOSP_CODE, HANGMOG_NAME)
                                            VALUES (SYSDATE, :q_user_id, SYSDATE, :q_user_id, :f_bunho,
                                                    :f_fkinp1001, :f_ymd, NVL(:f_hangmog_code, '999'), :f_hangmog_value1,
                                                    :f_hangmog_value2, :f_hangmog_value3, :f_hosp_code, :f_hangmog_name);                                           

                                         EXCEPTION WHEN DUP_VAL_ON_INDEX THEN

                                            UPDATE  NUR1122
                                               SET  UPD_DATE = SYSDATE
                                                  , UPD_ID   = :q_user_id
                                                  , HANGMOG_VALUE1 = :f_hangmog_value1
                                                  , HANGMOG_VALUE2 = :f_hangmog_value2
                                                  , HANGMOG_VALUE3 = :f_hangmog_value3
                                             WHERE  HOSP_CODE     = :f_hosp_code
                                               AND  BUNHO         = :f_bunho
                                               AND  FKINP1001     = :f_fkinp1001
                                               AND  YMD           = :f_ymd
                                               AND  HANGMOG_NAME  = :f_hangmog_name; 



                                            END;";
                                break;

                            case DataRowState.Deleted:
                                cmdText = string.Empty;
                                cmdText = @"DELETE  NUR1122
                                             WHERE  HOSP_CODE = :f_hosp_code
                                               AND  BUNHO     = :f_bunho
                                               AND  FKINP1001 = :f_fkinp1001
                                               AND  YMD       = :f_ymd
                                               AND  HANGMOG_NAME = :f_hangmog_name";
                                break;

                            case DataRowState.Unchanged:
//                                cmdText = @"DELETE  NUR1122_TEST
//                                             WHERE  HOSP_CODE = :f_hosp_code
//                                               AND  BUNHO     = :f_bunho
//                                               AND  FKINP1001 = :f_fkinp1001
//                                               AND  YMD       = :f_ymd
//                                               AND  HANGMOG_NAME = :f_hangmog_name";
//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);
//                                cmdText = string.Empty;
//                                cmdText = @"INSERT INTO NUR1122_TEST
//                                                   (SYS_DATE, SYS_ID, UPD_DATE, UPD_ID, BUNHO,
//                                                    FKINP1001, YMD, HANGMOG_CODE, HANGMOG_VALUE1, 
//                                                    HANGMOG_VALUE2, HANGMOG_VALUE3, HOSP_CODE, HANGMOG_NAME)
//                                            VALUES (SYSDATE, :q_user_id, SYSDATE, :q_user_id, :f_bunho,
//                                                    :f_fkinp1001, :f_ymd, :f_hangmog_code, :f_hangmog_value1,
//                                                    :f_hangmog_value2, :f_hangmog_value3, :f_hosp_code, :f_hangmog_name)";

                                cmdText = @"BEGIN
                                                IF :f_hangmog_value1 IS NULL AND :f_hangmog_value2 IS NULL AND :f_hangmog_value3 IS NULL THEN
                                                    DELETE  NUR1122
                                                     WHERE  HOSP_CODE = :f_hosp_code
                                                       AND  BUNHO     = :f_bunho
                                                       AND  FKINP1001 = :f_fkinp1001
                                                       AND  YMD       = :f_ymd
                                                       AND  HANGMOG_CODE = :f_hangmog_code;
                                                END IF; 
                                            END;";
                                break;
                        }
                        break;
                    case '4':   //바이탈사인 삭제목록 2012.01.04 woo
                        cmdText = string.Empty;
                        cmdText = @"DELETE NUR1020
                                     WHERE HOSP_CODE  = :f_hosp_code 
                                       AND BUNHO      = :f_bunho
                                       AND FKINP1001  = :f_fkinp1001
                                       AND YMD        = TO_DATE(:f_ymd, 'YYYY/MM/DD')
                                       AND TIME_GUBUN = :f_time";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdNUR1022_IN_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdNUR1022_IN.SetFocusToItem(e.CurrentRow, "io_value_1");
        }

        private void grdNUR1022_OUT_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdNUR1022_OUT.SetFocusToItem(e.CurrentRow, "io_value_2");
        }

        private void btnGwa_Click(object sender, EventArgs e)
        {
            CommonItemCollection openPrams = new CommonItemCollection();

            openPrams.Add("bunho", paBox.BunHo);
            openPrams.Add("fkinp1001", txtFkinp1001.Text);
            XScreen.OpenScreenWithParam(this, "NURI", "NUR1120U00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, openPrams);

            // SetHangmogCode();

        }

        private void grdNUR1122_QueryStarting(object sender, CancelEventArgs e)
        {
            //환자측정항목코드 콤보박스 셋팅
            //this.SetHangmogCode();
        }

        private void laySiksa_QueryStarting(object sender, CancelEventArgs e)
        {
            laySiksa.SetBindVarValue("f_hosp_code", this.mHospCode);
            laySiksa.SetBindVarValue("f_bunho", paBox.BunHo);
            laySiksa.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue().Replace("-", "").Replace("/", "").Substring(0, 8));
            laySiksa.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
        }

        private void btnKeyPad_Click(object sender, EventArgs e)
        {
            pnlPad.Visible = !pnlPad.Visible;
            if (currCtl == null)
            {
                currCtl = grdNUR1020;
            }
        }

        private void btnKeypad_Click(object sender, EventArgs e)
        {
            XButton btn = sender as XButton;

            switch (btn.Tag.ToString())
            {
                case "B":
                    if (txtPadValue.Text.Length > 1)
                    {
                        txtPadValue.Text = txtPadValue.Text.Substring(0, txtPadValue.Text.Length - 1);
                    }
                    break;

                default:
                    txtPadValue.Text = txtPadValue.Text + btn.Tag.ToString();
                    break;
            }                  
        }

        private void SetFocus(object sender, EventArgs e)
        {
            XEditGrid grid;
            XEditMask mask;            
            Type type = sender.GetType();

                currCtl = sender; //현재의 컨트롤 저장

            try
            {
                //컨트롤에서 값 읽어와서 txtbox에 셋팅
                switch (type.Name)
                {
                    case "XEditGrid":
                        grid = sender as XEditGrid;
                        //lblPadTitle.Text = grid.HeaderInfos[grid.CurrentColNumber].HeaderText;

                        if (grid.CurrentRowNumber > -1)
                        {
                            txtPadValue.Text = grid.GetItemString(grid.CurrentRowNumber, grid.CurrentColName);
                        }
                        break;

                    case "XEditMask":
                        mask = sender as XEditMask;
                        txtPadValue.Text = mask.Text;
                        //lblPadTitle.Text = mask.Tag.ToString();
                        break;
                }
            }
            catch(Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message);
            }
        }

        private void btnSetValue_Click(object sender, EventArgs e)
        {
            XEditGrid grid;
            XEditMask mask;
            Type type;

            type = currCtl.GetType();

            try
            {
                switch (type.Name)
                {
                    case "XEditGrid":
                        grid = currCtl as XEditGrid;
                        if (grid.CurrentRowNumber > -1)
                        {
                            grid.SetItemValue(grid.CurrentRowNumber, grid.CurrentColName, txtPadValue.Text);
                        }
                        break;

                    case "XEditMask":
                        mask = currCtl as XEditMask;
                        mask.Text = txtPadValue.Text;
                        break;
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message);
            }

        }

        private void layNUR7002_QueryStarting(object sender, CancelEventArgs e)
        {
            layNUR7002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNUR7002.SetBindVarValue("f_ymd", dtpYmd.GetDataValue());
            layNUR7002.SetBindVarValue("f_bunho", paBox.BunHo);
            layNUR7002.SetBindVarValue("f_fkinp1001", this.txtFkinp1001.GetDataValue());
        }

        private void btnSetCare_Click(object sender, EventArgs e)
        {
            string strCare = "";

            for (int i = 0; i < grdCare.RowCount; i++)
            {
                if (grdCare.GetItemString(i, "code").Substring(0, 1) != "0" && grdCare.GetItemString(i, "code").Substring(1, 1) == "1")
                    strCare += "\r\n";
                if(grdCare.GetItemString(i, "select") == "Y")
                {                    
                    strCare += grdCare.GetItemString(i, "care_string") + " ";
                }
            }

            txtCare.Text = strCare;
        }

        private void fwkWriter_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkWriter.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkWriter.SetBindVarValue("f_buseo_name", cboHo_dong.GetDataValue());
        }

        private void fbxWriter_DataValidating(object sender, DataValidatingEventArgs e)
        {
            DataRow[] dr = null;
            XFindBox fb = (XFindBox)sender;
            XDisplayBox dbx = null;
            
            switch (fb.Tag.ToString())
            {
                case "1":
                    dbx = dbxWriter1;
                    break;

                case "2":
                    dbx = dbxWriter2;
                    break;

                case "3":
                    dbx = dbxWriter3;
                    break;
            }
            dr = layNURList.LayoutTable.Select("user_id = '" + fb.GetDataValue() + "'");

            if (dr.Length > 0)
            {
                dbx.Text = dr[0]["user_name"].ToString();
            }
            else
            {
                XMessageBox.Show(Resources.NUR1020U00_fbxWriter_DataValidating_);
                dbx.Text = "";
                fb.Clear();
                fb.Focus();
            }
        }

        private void cboHo_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            layNURList.QueryLayout(true);
        }

        private void layNURList_QueryStarting(object sender, CancelEventArgs e)
        {
            layNURList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNURList.SetBindVarValue("f_buseo_name", cboHo_dong.GetDataValue());
        }

        private void emkSik_DataValidating(object sender, DataValidatingEventArgs e)
        {            
            try
            {
                XEditMask emk = (XEditMask)(sender);

                if (int.Parse(emk.GetDataValue()) >= 0 && int.Parse(emk.GetDataValue()) <= 10)
                {
                }
                else if (int.Parse(emk.GetDataValue()) == 99)
                {
                    //XMessageBox.Show("少量と表示されます。");
                }
                else
                {
                    XMessageBox.Show(Resources.NUR1020U00_emkSik_DataValidating_);
                    emk.Clear();
                    emk.Focus();
                }
            }
            catch(Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message);
            }
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Update);

            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum,"bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");
        }

        private void grdPalist_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            this.CanClose();
        }

        private void grdCare_DoubleClick(object sender, EventArgs e)
        {
            txtCare.Text += grdCare.GetItemString(grdCare.CurrentRowNumber, "care_string");
        }

        private void layWriterBA_QueryStarting(object sender, CancelEventArgs e)
        {
            layWriterBA.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layWriterBA.SetBindVarValue("f_fkinp1001", txtFkinp1001.Text);
            layWriterBA.SetBindVarValue("f_bunho", paBox.BunHo);
            layWriterBA.SetBindVarValue("f_ymd", dtpYmd.GetDataValue());
        }

        private void cboWatchTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdWatchTemplate.QueryLayout(true);
        }

        private void grdNUR1122_SaveEnd(object sender, SaveEndEventArgs e)
        {
            grdNUR1122.QueryLayout(true);
        }

        private void grdNUR1020_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdNUR1020.RowCount > 0)
            {
                cboVspatn_gubun.SetDataValue(grdNUR1020.GetItemValue(0, "vspatn_gubun"));
            }
        }

        private void btnPreChuchi_Click(object sender, EventArgs e)
        {
            string strSql = @"SELECT HANGMOG_VALUE 
                                FROM NUR7002 
                               WHERE HOSP_CODE = :f_hosp_code 
                                 AND FKINP1001 = :f_fkinp1001 
                                 AND BUNHO = :f_bunho 
                                 AND HANGMOG_GUBUN = 'SYO' 
                                 AND YMD = TO_DATE(:f_date)-1";

            BindVarCollection bindVal = new BindVarCollection();

            bindVal.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVal.Add("f_fkinp1001", this.txtFkinp1001.Text);
            bindVal.Add("f_bunho", paBox.BunHo);
            bindVal.Add("f_date", this.dtpYmd.GetDataValue());

            object retVal = Service.ExecuteScalar(strSql, bindVal);

            if (!TypeCheck.IsNull(retVal))
            {
                if (XMessageBox.Show(Resources.NUR1020U00_btnPreChuchi_Click_, Resources.NUR1020U00_btnPreChuchi_Click_XN, MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    txtChuchi.Text = txtChuchi.Text + retVal.ToString();
                }
            }
            else
            {
                XMessageBox.Show(Resources.NUR1020U00_btnPreChuchi_Click_kcnd, Resources.NUR1020U00_btnPreChuchi_Click_XN, MessageBoxButtons.OK);
            }
        }

        private void btnChiryo_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                XMessageBox.Show(Resources.NUR1020U00_btnChiryo_Click_);
                paBox.Focus();
                return;
            }

            IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");

            if (screen == null)
            {
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.paBox.BunHo);
                cic.Add("fkinp1001", this.txtFkinp1001.Text);
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpSizable, cic);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(this.paBox.BunHo, "", "", "", this.txtFkinp1001.Text, PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }
        }

        private void grdNUR1122_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["end_yn"].ToString() == "Y")
            {
                e.ForeColor = Color.Red;
            }
        }

        private void grdPalist_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "ho_code")
            {
                if(grdPalist.GetItemString(e.RowNumber, "cycle_order_group") == "P")
                {
                    e.BackColor = Color.Pink;
                }
                else if (grdPalist.GetItemString(e.RowNumber, "cycle_order_group") == "G")
                {
                    e.BackColor = Color.LightGreen;
                }
            }
        }



        private void SetCycleOrderGroup(object sender, EventArgs e)
        {
            IHIS.X.Magic.Menus.MenuCommand menuCmd = sender as IHIS.X.Magic.Menus.MenuCommand;


            string sqlCmd = string.Empty;

            BindVarCollection bindVar = new BindVarCollection();

            switch (menuCmd.Tag.ToString())
            {
                case "1":
                    sqlCmd = "UPDATE INP1001 SET CYCLE_ORDER_GROUP = 'P' WHERE HOSP_CODE = :f_hosp_code AND PKINP1001 = :f_pkinp1001";
                    break;

                case "2":
                    sqlCmd = "UPDATE INP1001 SET CYCLE_ORDER_GROUP = 'G' WHERE HOSP_CODE = :f_hosp_code AND PKINP1001 = :f_pkinp1001";
                    break;
                
                case "3":
                    sqlCmd = "UPDATE INP1001 SET CYCLE_ORDER_GROUP = NULL WHERE HOSP_CODE = :f_hosp_code AND PKINP1001 = :f_pkinp1001";
                    break;
            }

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_pkinp1001", grdPalist.GetItemString(grdPalist.CurrentRowNumber, "pkinp1001"));

            Service.ExecuteNonQuery(sqlCmd, bindVar);
        }

        private void grdPalist_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                grdPalist.UnSelectAll();
                grdPalist.SelectRow(grdPalist.GetHitRowNumber(e.Y));
                popMenu.TrackPopup(grdPalist.PointToScreen(e.Location));

                grdPalist.QueryLayout(true);
            }

        }

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPalist.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdPalist.SetBindVarValue("f_date", dtpYmd.GetDataValue());
            grdPalist.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void pnlHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = false;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            pnlHelp.Visible = !pnlHelp.Visible;
        }
      
    }
}