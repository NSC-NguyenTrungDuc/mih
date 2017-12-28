using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.NURO.Properties;

#region 사용 NameSpace 지정

using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.NURO;
using System.Net.Sockets;
using System.Net;
using System.Text;

#endregion

/*====================================================================================================
 * 1. 20060107 수정 예정
   접수시 해당과에 예약된 건이 있는지 체크할 것(과 선택시)  => FN_OUT_LOAD_RESER_YN( Y:예약이 있다, N: 없다) 
   I_BUNHO    IN  VARCHAR2,          -- 환자번호
   I_DATE     IN  DATE,              -- 진료예정일
   I_GWA      IN  VARCHAR2           -- 진료과
 * 2. 진료과 선택시 해당과로 최근에 내원한 의사를 찾아서 의사를 setting한다. 
 * 3. NAEWON_YN에서 간호에서 내원확인을 하면 Y, 처방이 발생하면 E로 SETTING된다.
 * 4.WONYOI_ORDER_YN == "Y'로 저장(default)
 *   1)자보와 노재 
 *   2)공비의 생보
 *   3)투석환자(환자구분)는 무조건 원내로 처방전을 발행한다.
 * 5. 초재진(PR_OUT_LOAD_CHECK_CHOJAE_JPN) 체크 추후 수정(20060112)
 * 카르테1호지 출력 ===>  과초진
 * 바코드출력         ===> 신환  또는 out0101의 barcode_yn = 'N'
 * 진찰권발행         ===> 신환 또는 out0101의 card_yn = 'N'
 * 수진표출력   접수시 항상
 * 초재진 : 초진은 월별로 한번만 발생한다(타과로 예약을 하더라도 해당월에 다른과에서 초진을 한 경우라면
 *          초진이 발생할 수 없다)
 ===================================================================================================== */
namespace IHIS.NURO
{
    /// <summary>
    /// OUT1001U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class OUT1001U01 : IHIS.Framework.XScreen
    {
        #region 사용자 변수

        #endregion

        #region 자동생성

        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlSTop;
        private IHIS.Framework.XPanel pnlFill;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XEditGridCell xEditGridCell18;
        private IHIS.Framework.XEditGridCell xEditGridCell19;
        private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XEditGrid grdComment;
        private IHIS.Framework.XDisplayBox dbxChanggu;
        private IHIS.Framework.XEditGrid grdJubsuHistory;
        private IHIS.Framework.XButton btnOUT0106U00;
        private IHIS.Framework.XPanel pnlSTLeft;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XButton btnOUT1001Q01;
        private IHIS.Framework.XEditGrid grdJubsu;
        private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGridCell xEditGridCell28;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
        private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XEditGridCell xEditGridCell99;
        private IHIS.Framework.XEditGridCell xEditGridCell100;
        private IHIS.Framework.XEditGridCell xEditGridCell101;
        private IHIS.Framework.XEditGridCell xEditGridCell26;
        private IHIS.Framework.XEditGridCell xEditGridCell52;
        private IHIS.Framework.XEditGridCell xEditGridCell53;
        private IHIS.Framework.XEditGridCell xEditGridCell54;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
        private IHIS.Framework.XEditGridCell xEditGridCell56;
        private IHIS.Framework.XEditGridCell xEditGridCell59;
        private IHIS.Framework.XEditGridCell xEditGridCell60;
        private IHIS.Framework.XEditGridCell xEditGridCell64;
        private IHIS.Framework.XEditGridCell xEditGridCell65;
        private IHIS.Framework.XEditGridCell xEditGridCell66;
        private IHIS.Framework.XEditGridCell xEditGridCell67;
        private IHIS.Framework.XEditGridCell xEditGridCell34;
        private IHIS.Framework.XEditGridCell xEditGridCell38;
        private IHIS.Framework.XEditGridCell xEditGridCell68;
        private IHIS.Framework.XEditGridCell xEditGridCell69;
        private IHIS.Framework.XPanel pnlSTTop;
        private IHIS.Framework.XButton btnINP1001Q00;
        private IHIS.Framework.XEditGridCell xEditGridCell77;
        private IHIS.Framework.XEditGridCell xEditGridCell80;
        private IHIS.Framework.XButton btnOUT1001Q04;
        private IHIS.Framework.XCheckBox cbkSujin;
        private IHIS.Framework.XEditGridCell xEditGridCell94;
        private IHIS.Framework.XEditGridCell xEditGridCell96;
        private IHIS.Framework.XEditGridCell xEditGridCell98;
        private IHIS.Framework.XDisplayBox dbxJunpyoDate;
        private IHIS.Framework.XDatePicker dtpNaewonDate;
        private IHIS.Framework.XEditMask emkJubsuTime;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.MultiLayout laySujinRemark;
        private IHIS.Framework.MultiLayout laySusinPrint;
        private IHIS.Framework.MultiLayout layBarCode;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem24;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem25;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem26;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem27;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem28;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private XGridHeader xGridHeader3;
        private XPanel pnlMid;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem41;
        private MultiLayoutItem multiLayoutItem42;
        private MultiLayoutItem multiLayoutItem43;
        private MultiLayoutItem multiLayoutItem44;
        private MultiLayoutItem multiLayoutItem45;
        private MultiLayoutItem multiLayoutItem46;
        private MultiLayoutItem multiLayoutItem47;
        private MultiLayoutItem multiLayoutItem48;
        private XEditGrid grdGongBi;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell78;
        private XButton btnGongbiInput;
        private XPanel pnlGongbi;
        private XPanel pnlOUT0106;
        private XLabel xLabel4;
        private XLabel xLabel2;
        private XDatePicker dtpLastCheckDate;
        private SingleLayout layGongbiCode;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private XEditGridCell xEditGridCell7;
        private SingleLayout layLastCheckDate;
        private SingleLayoutItem singleLayoutItem5;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XTextBox txtBunho;
        private XEditGridCell xEditGridCell25;
        private XButton btnPrint;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private SingleLayout layGroupKey;
        private SingleLayoutItem singleLayoutItem6;

        //tungtx
        IList<object[]> lstComment;
        IList<object[]> lstInsurance;
        IList<object[]> lstHistory;
        IList<object[]> lstJubsu;

        private const string CACHE_OUT1001U01_GET_DEPARTMENT_KEYS = "NURO.Out1001U01.XFindWorker.Department";
        private const string CACHE_OUT1001U01_GET_GUBUN = "NURO.OUT1001U01.XFindWorker.Gubun";
        private const string CACHE_OUT1001U01_COMBO_LIST_ITEM_KEYS = "NURO.Out1001U01.CboListItem";
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell39;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        #endregion

        public OUT1001U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            layLastCheckDate.ExecuteQuery = layLastCheckDate_GetLastCheckDate;
            layGroupKey.ExecuteQuery = layGroupKey_GetGroupTypeInfo;

            this.SaveLayoutList.Add(this.laySujinRemark);
            this.laySujinRemark.SavePerformer = new XSavePerformer(this);

            // https://sofiamedix.atlassian.net/browse/MED-15048
            if (NetInfo.Language == LangMode.Jr)
            {
                this.grdJubsu.AutoSizeColumn(xGridHeader1.Col, 45);
                this.grdJubsu.AutoSizeColumn(xGridHeader1.Col, 75);
                this.grdJubsu.AutoSizeColumn(xGridHeader3.Col, 41);
                this.grdJubsu.AutoSizeColumn(xEditGridCell29.Col, 52);
                this.grdJubsu.AutoSizeColumn(xEditGridCell31.Col, 33);
                this.grdJubsu.AutoSizeColumn(xEditGridCell26.Col, 45);
                this.grdJubsu.AutoSizeColumn(xEditGridCell56.Col, 110);
                this.grdJubsu.AutoSizeColumn(xEditGridCell30.Col, 30);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OUT1001U01));
            this.grdGongBi = new IHIS.Framework.XEditGrid();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.btnOUT0106U00 = new IHIS.Framework.XButton();
            this.btnGongbiInput = new IHIS.Framework.XButton();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.dtpLastCheckDate = new IHIS.Framework.XDatePicker();
            this.dbxJunpyoDate = new IHIS.Framework.XDisplayBox();
            this.dbxChanggu = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.emkJubsuTime = new IHIS.Framework.XEditMask();
            this.dtpNaewonDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnOUT1001Q04 = new IHIS.Framework.XButton();
            this.pnlSTop = new IHIS.Framework.XPanel();
            this.pnlMid = new IHIS.Framework.XPanel();
            this.pnlOUT0106 = new IHIS.Framework.XPanel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlGongbi = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pnlSTLeft = new IHIS.Framework.XPanel();
            this.grdJubsu = new IHIS.Framework.XEditGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xGridHeader3 = new IHIS.Framework.XGridHeader();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdJubsuHistory = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnOUT1001Q01 = new IHIS.Framework.XButton();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnPrint = new IHIS.Framework.XButton();
            this.cbkSujin = new IHIS.Framework.XCheckBox();
            this.btnINP1001Q00 = new IHIS.Framework.XButton();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.pnlSTTop = new IHIS.Framework.XPanel();
            this.txtBunho = new IHIS.Framework.XTextBox();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.laySujinRemark = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.laySusinPrint = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem42 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem43 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem44 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem45 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem46 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem47 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.layBarCode = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.layGongbiCode = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layLastCheckDate = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layGroupKey = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdGongBi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlSTop.SuspendLayout();
            this.pnlMid.SuspendLayout();
            this.pnlOUT0106.SuspendLayout();
            this.pnlGongbi.SuspendLayout();
            this.pnlSTLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJubsu)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdJubsuHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.pnlSTTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySujinRemark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusinPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarCode)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "");
            this.ImageList.Images.SetKeyName(5, "");
            this.ImageList.Images.SetKeyName(6, "");
            this.ImageList.Images.SetKeyName(7, "");
            this.ImageList.Images.SetKeyName(8, "");
            this.ImageList.Images.SetKeyName(9, "");
            this.ImageList.Images.SetKeyName(10, "");
            this.ImageList.Images.SetKeyName(11, "");
            this.ImageList.Images.SetKeyName(12, "++.gif");
            this.ImageList.Images.SetKeyName(13, "인쇄.gif");
            // 
            // grdGongBi
            // 
            resources.ApplyResources(this.grdGongBi, "grdGongBi");
            this.grdGongBi.CallerID = '2';
            this.grdGongBi.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell27,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell71,
            this.xEditGridCell76,
            this.xEditGridCell74,
            this.xEditGridCell75,
            this.xEditGridCell78,
            this.xEditGridCell9});
            this.grdGongBi.ColPerLine = 5;
            this.grdGongBi.Cols = 6;
            this.grdGongBi.ExecuteQuery = null;
            this.grdGongBi.FixedCols = 1;
            this.grdGongBi.FixedRows = 1;
            this.grdGongBi.HeaderHeights.Add(21);
            this.grdGongBi.Name = "grdGongBi";
            this.grdGongBi.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdGongBi.ParamList")));
            this.grdGongBi.QuerySQL = resources.GetString("grdGongBi.QuerySQL");
            this.grdGongBi.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdGongBi.RowHeaderVisible = true;
            this.grdGongBi.Rows = 2;
            this.grdGongBi.RowStateCheckOnPaint = false;
            this.grdGongBi.ToolTipActive = true;
            this.grdGongBi.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdGongBi_GridColumnProtectModify);
            this.grdGongBi.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdGongBi_ItemValueChanging);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "check";
            this.xEditGridCell27.CellWidth = 55;
            this.xEditGridCell27.Col = 1;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsUpdCol = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "gongbi_code";
            this.xEditGridCell23.CellWidth = 79;
            this.xEditGridCell23.Col = 3;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 195;
            this.xEditGridCell24.CellName = "gongbi_name";
            this.xEditGridCell24.CellWidth = 178;
            this.xEditGridCell24.Col = 4;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "last_check_date";
            this.xEditGridCell71.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell71.CellWidth = 101;
            this.xEditGridCell71.Col = 5;
            this.xEditGridCell71.ExecuteQuery = null;
            this.xEditGridCell71.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell71.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsJapanYearType = true;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "start_date";
            this.xEditGridCell76.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            this.xEditGridCell76.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "bunho";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            this.xEditGridCell74.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "budamja_bunho";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            this.xEditGridCell75.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellLen = 1;
            this.xEditGridCell78.CellName = "gongbi_jiyeok";
            this.xEditGridCell78.Col = -1;
            this.xEditGridCell78.ExecuteQuery = null;
            this.xEditGridCell78.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            this.xEditGridCell78.IsUpdCol = false;
            this.xEditGridCell78.IsVisible = false;
            this.xEditGridCell78.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 2;
            this.xEditGridCell9.CellName = "priority";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell9.CellWidth = 47;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.MaxinumCipher = 2;
            // 
            // grdComment
            // 
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.ApplyAutoHeight = true;
            this.grdComment.CallerID = '3';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell19,
            this.xEditGridCell18,
            this.xEditGridCell20});
            this.grdComment.ColPerLine = 1;
            this.grdComment.ColResizable = true;
            this.grdComment.Cols = 2;
            this.grdComment.ExecuteQuery = null;
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Name = "grdComment";
            this.grdComment.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment.ParamList")));
            this.grdComment.QuerySQL = resources.GetString("grdComment.QuerySQL");
            this.grdComment.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.ToolTipActive = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 80;
            this.xEditGridCell19.CellName = "comment";
            this.xEditGridCell19.CellWidth = 270;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ser";
            this.xEditGridCell18.CellWidth = 31;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "bunho";
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // btnOUT0106U00
            // 
            resources.ApplyResources(this.btnOUT0106U00, "btnOUT0106U00");
            this.btnOUT0106U00.ImageIndex = 3;
            this.btnOUT0106U00.ImageList = this.ImageList;
            this.btnOUT0106U00.Name = "btnOUT0106U00";
            this.btnOUT0106U00.Click += new System.EventHandler(this.btnOUT0106U00_Click);
            // 
            // btnGongbiInput
            // 
            resources.ApplyResources(this.btnGongbiInput, "btnGongbiInput");
            this.btnGongbiInput.ImageIndex = 3;
            this.btnGongbiInput.ImageList = this.ImageList;
            this.btnGongbiInput.Name = "btnGongbiInput";
            this.btnGongbiInput.Click += new System.EventHandler(this.btnGongbiInput_Click);
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.dtpLastCheckDate);
            this.pnlTop.Controls.Add(this.dbxJunpyoDate);
            this.pnlTop.Controls.Add(this.dbxChanggu);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.emkJubsuTime);
            this.pnlTop.Controls.Add(this.dtpNaewonDate);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.btnOUT1001Q04);
            this.pnlTop.Name = "pnlTop";
            // 
            // dtpLastCheckDate
            // 
            resources.ApplyResources(this.dtpLastCheckDate, "dtpLastCheckDate");
            this.dtpLastCheckDate.IsVietnameseYearType = false;
            this.dtpLastCheckDate.Name = "dtpLastCheckDate";
            // 
            // dbxJunpyoDate
            // 
            resources.ApplyResources(this.dbxJunpyoDate, "dbxJunpyoDate");
            this.dbxJunpyoDate.Name = "dbxJunpyoDate";
            // 
            // dbxChanggu
            // 
            resources.ApplyResources(this.dbxChanggu, "dbxChanggu");
            this.dbxChanggu.Name = "dbxChanggu";
            // 
            // xLabel3
            // 
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Name = "xLabel3";
            // 
            // emkJubsuTime
            // 
            resources.ApplyResources(this.emkJubsuTime, "emkJubsuTime");
            this.emkJubsuTime.EditMaskType = IHIS.Framework.MaskType.Time;
            this.emkJubsuTime.EditVietnameseMaskType = IHIS.Framework.MaskType.Time;
            this.emkJubsuTime.IsVietnameseYearType = false;
            this.emkJubsuTime.Mask = "HH:MI";
            this.emkJubsuTime.Name = "emkJubsuTime";
            this.emkJubsuTime.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.emkJubsuTime_DataValidating);
            // 
            // dtpNaewonDate
            // 
            resources.ApplyResources(this.dtpNaewonDate, "dtpNaewonDate");
            this.dtpNaewonDate.IsVietnameseYearType = false;
            this.dtpNaewonDate.Name = "dtpNaewonDate";
            this.dtpNaewonDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNaewonDate_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Name = "xLabel1";
            // 
            // btnOUT1001Q04
            // 
            resources.ApplyResources(this.btnOUT1001Q04, "btnOUT1001Q04");
            this.btnOUT1001Q04.ImageIndex = 3;
            this.btnOUT1001Q04.ImageList = this.ImageList;
            this.btnOUT1001Q04.Name = "btnOUT1001Q04";
            this.btnOUT1001Q04.Click += new System.EventHandler(this.btnOUT1001Q04_Click);
            // 
            // pnlSTop
            // 
            resources.ApplyResources(this.pnlSTop, "pnlSTop");
            this.pnlSTop.Controls.Add(this.pnlMid);
            this.pnlSTop.Controls.Add(this.pnlSTLeft);
            this.pnlSTop.Name = "pnlSTop";
            // 
            // pnlMid
            // 
            resources.ApplyResources(this.pnlMid, "pnlMid");
            this.pnlMid.Controls.Add(this.pnlOUT0106);
            this.pnlMid.Controls.Add(this.pnlGongbi);
            this.pnlMid.Name = "pnlMid";
            // 
            // pnlOUT0106
            // 
            resources.ApplyResources(this.pnlOUT0106, "pnlOUT0106");
            this.pnlOUT0106.Controls.Add(this.btnOUT0106U00);
            this.pnlOUT0106.Controls.Add(this.grdComment);
            this.pnlOUT0106.Controls.Add(this.xLabel4);
            this.pnlOUT0106.Name = "pnlOUT0106";
            // 
            // xLabel4
            // 
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlGongbi
            // 
            resources.ApplyResources(this.pnlGongbi, "pnlGongbi");
            this.pnlGongbi.Controls.Add(this.btnGongbiInput);
            this.pnlGongbi.Controls.Add(this.grdGongBi);
            this.pnlGongbi.Controls.Add(this.xLabel2);
            this.pnlGongbi.Name = "pnlGongbi";
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // pnlSTLeft
            // 
            resources.ApplyResources(this.pnlSTLeft, "pnlSTLeft");
            this.pnlSTLeft.Controls.Add(this.grdJubsu);
            this.pnlSTLeft.Controls.Add(this.xLabel6);
            this.pnlSTLeft.Name = "pnlSTLeft";
            // 
            // grdJubsu
            // 
            this.grdJubsu.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdJubsu, "grdJubsu");
            this.grdJubsu.ApplyPaintEventToAllColumn = true;
            this.grdJubsu.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell31,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell26,
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell60,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell10,
            this.xEditGridCell14,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell25,
            this.xEditGridCell7,
            this.xEditGridCell30,
            this.xEditGridCell33,
            this.xEditGridCell32,
            this.xEditGridCell37,
            this.xEditGridCell35});
            this.grdJubsu.ColPerLine = 11;
            this.grdJubsu.Cols = 11;
            this.grdJubsu.ExecuteQuery = null;
            this.grdJubsu.FixedRows = 2;
            this.grdJubsu.HeaderHeights.Add(32);
            this.grdJubsu.HeaderHeights.Add(0);
            this.grdJubsu.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1,
            this.xGridHeader2,
            this.xGridHeader3});
            this.grdJubsu.Name = "grdJubsu";
            this.grdJubsu.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJubsu.ParamList")));
            this.grdJubsu.QuerySQL = resources.GetString("grdJubsu.QuerySQL");
            this.grdJubsu.Rows = 3;
            this.grdJubsu.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdJubsu.ToolTipActive = true;
            this.grdJubsu.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdJubsu_GridColumnProtectModify);
            this.grdJubsu.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdJubsu_GridFindSelected);
            this.grdJubsu.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdJubsu_GridFindClick);
            this.grdJubsu.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdJubsu_ItemValueChanging);
            this.grdJubsu.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdJubsu_GridButtonClick);
            this.grdJubsu.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdJubsu_RowFocusChanged);
            this.grdJubsu.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdJubsu_GridCellPainting);
            this.grdJubsu.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdJubsu_GridColumnChanged);
            this.grdJubsu.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdJubsu_QueryStarting);
            this.grdJubsu.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdJubsu_QueryEnd);
            this.grdJubsu.PreEndInitializing += new System.EventHandler(this.grdJubsu_PreEndInitializing);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AutoTabDataSelected = true;
            this.xEditGridCell15.CellName = "gwa";
            this.xEditGridCell15.CellWidth = 45;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.FindWorker = this.fwkCommon;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell15.IsNotNull = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.Row = 1;
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkCommon.ServerFilter = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "gwa_name";
            this.xEditGridCell16.CellWidth = 69;
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.Row = 1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AutoTabDataSelected = true;
            this.xEditGridCell17.CellLen = 20;
            this.xEditGridCell17.CellName = "doctor";
            this.xEditGridCell17.CellWidth = 75;
            this.xEditGridCell17.Col = 2;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.FindWorker = this.fwkCommon;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell17.IsNotNull = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.Row = 1;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "doctor_name";
            this.xEditGridCell28.Col = 3;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.Row = 1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "chojae";
            this.xEditGridCell29.CellWidth = 102;
            this.xEditGridCell29.Col = 4;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.MaxDropDownItems = 20;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellLen = 3;
            this.xEditGridCell31.CellName = "jubsu_no";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell31.CellWidth = 46;
            this.xEditGridCell31.Col = 5;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.InitValue = "0";
            this.xEditGridCell31.MaxinumCipher = 3;
            this.xEditGridCell31.RowSpan = 2;
            this.xEditGridCell31.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AutoTabDataSelected = true;
            this.xEditGridCell11.CellLen = 2;
            this.xEditGridCell11.CellName = "gubun";
            this.xEditGridCell11.CellWidth = 41;
            this.xEditGridCell11.Col = 6;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.FindWorker = this.fwkCommon;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell11.Row = 1;
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "gubun_name";
            this.xEditGridCell12.CellWidth = 75;
            this.xEditGridCell12.Col = 7;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdCol = false;
            this.xEditGridCell12.Row = 1;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.CellName = "bunho";
            this.xEditGridCell99.Col = -1;
            this.xEditGridCell99.ExecuteQuery = null;
            this.xEditGridCell99.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsVisible = false;
            this.xEditGridCell99.Row = -1;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.CellName = "naewon_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.Col = -1;
            this.xEditGridCell100.ExecuteQuery = null;
            this.xEditGridCell100.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsVisible = false;
            this.xEditGridCell100.Row = -1;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.CellName = "pkout1001";
            this.xEditGridCell101.Col = -1;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsVisible = false;
            this.xEditGridCell101.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "jubsu_time";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell26.CellWidth = 108;
            this.xEditGridCell26.Col = 8;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.Mask = "HH:MI";
            this.xEditGridCell26.RowSpan = 2;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "naewon_yn";
            this.xEditGridCell52.CellWidth = 30;
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            this.xEditGridCell52.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell52.HeaderGradientEnd = IHIS.Framework.XColor.XLabelBorderColor;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.InitValue = "N";
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "naewon_type";
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            this.xEditGridCell53.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.InitValue = "0";
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "sunnab_yn";
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            this.xEditGridCell54.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.InitValue = "N";
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "fkinp1001";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            this.xEditGridCell55.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellLen = 0;
            this.xEditGridCell56.CellName = "jubsu_gubun";
            this.xEditGridCell56.CellWidth = 100;
            this.xEditGridCell56.Col = 9;
            this.xEditGridCell56.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell56.ExecuteQuery = null;
            this.xEditGridCell56.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell56.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.MaxDropDownItems = 20;
            this.xEditGridCell56.RowSpan = 2;
            this.xEditGridCell56.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "inp_trans_yn";
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            this.xEditGridCell59.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.InitValue = "N";
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "bigo";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            this.xEditGridCell60.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellLen = 3;
            this.xEditGridCell64.CellName = "gongbi_code1";
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            this.xEditGridCell64.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellLen = 3;
            this.xEditGridCell65.CellName = "gongbi_code2";
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            this.xEditGridCell65.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellLen = 3;
            this.xEditGridCell66.CellName = "gongbi_code3";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            this.xEditGridCell66.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellLen = 4;
            this.xEditGridCell67.CellName = "gongbi_code4";
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            this.xEditGridCell67.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "priority1";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "priority2";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "priority3";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "priority4";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "sujin_no";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            this.xEditGridCell77.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "wonyoi_order_yn";
            this.xEditGridCell80.CellWidth = 30;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            this.xEditGridCell80.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell80.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "reser_yn";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.ButtonImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell7.ButtonImage")));
            this.xEditGridCell7.CellName = "button";
            this.xEditGridCell7.CellWidth = 25;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellName = "check_naewon";
            this.xEditGridCell30.CellWidth = 59;
            this.xEditGridCell30.Col = 10;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.RowSpan = 2;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.CellName = "arrive_time";
            this.xEditGridCell33.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Mask = "HH:MI";
            this.xEditGridCell33.Row = -1;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.CellName = "group_key";
            this.xEditGridCell32.Col = -1;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsVisible = false;
            this.xEditGridCell32.Row = -1;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "cont_key";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsReadOnly = true;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "sys_id";
            this.xEditGridCell35.Col = -1;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridHeader1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 45;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 2;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            this.xGridHeader2.HeaderWidth = 75;
            // 
            // xGridHeader3
            // 
            this.xGridHeader3.Col = 6;
            this.xGridHeader3.ColSpan = 2;
            this.xGridHeader3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xGridHeader3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xGridHeader3, "xGridHeader3");
            this.xGridHeader3.HeaderWidth = 41;
            // 
            // xLabel6
            // 
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Name = "xLabel6";
            // 
            // pnlFill
            // 
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Controls.Add(this.grdJubsuHistory);
            this.pnlFill.Controls.Add(this.xLabel7);
            this.pnlFill.Name = "pnlFill";
            // 
            // grdJubsuHistory
            // 
            resources.ApplyResources(this.grdJubsuHistory, "grdJubsuHistory");
            this.grdJubsuHistory.ApplyPaintEventToAllColumn = true;
            this.grdJubsuHistory.CallerID = '5';
            this.grdJubsuHistory.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell5,
            this.xEditGridCell13,
            this.xEditGridCell8,
            this.xEditGridCell34,
            this.xEditGridCell68,
            this.xEditGridCell38,
            this.xEditGridCell69,
            this.xEditGridCell96,
            this.xEditGridCell98,
            this.xEditGridCell39,
            this.xEditGridCell36});
            this.grdJubsuHistory.ColPerLine = 6;
            this.grdJubsuHistory.ColResizable = true;
            this.grdJubsuHistory.Cols = 7;
            this.grdJubsuHistory.ExecuteQuery = null;
            this.grdJubsuHistory.FixedCols = 1;
            this.grdJubsuHistory.FixedRows = 1;
            this.grdJubsuHistory.HeaderHeights.Add(21);
            this.grdJubsuHistory.Name = "grdJubsuHistory";
            this.grdJubsuHistory.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdJubsuHistory.ParamList")));
            this.grdJubsuHistory.QuerySQL = resources.GetString("grdJubsuHistory.QuerySQL");
            this.grdJubsuHistory.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdJubsuHistory.RowHeaderVisible = true;
            this.grdJubsuHistory.Rows = 2;
            this.grdJubsuHistory.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdJubsuHistory.ToolTipActive = true;
            this.grdJubsuHistory.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdJubsuHistory_GridCellPainting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 130;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "jinryo_pre_date";
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "jinryo_pre_time";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Time;
            this.xEditGridCell3.CellWidth = 111;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.Mask = "HH:MI";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gwa";
            this.xEditGridCell4.CellWidth = 70;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor_name";
            this.xEditGridCell6.CellWidth = 110;
            this.xEditGridCell6.Col = 4;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gubun_name";
            this.xEditGridCell5.CellWidth = 130;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sunnab_yn";
            this.xEditGridCell13.CellWidth = 62;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "chojae";
            this.xEditGridCell8.CellWidth = 143;
            this.xEditGridCell8.Col = 6;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.InitValue = "4";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellName = "naewon_yn";
            this.xEditGridCell34.Col = -1;
            this.xEditGridCell34.ExecuteQuery = null;
            this.xEditGridCell34.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.IsVisible = false;
            this.xEditGridCell34.Row = -1;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "bunho";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            this.xEditGridCell68.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.CellName = "jubsu_time";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "gwa_name";
            this.xEditGridCell69.CellWidth = 100;
            this.xEditGridCell69.Col = 3;
            this.xEditGridCell69.ExecuteQuery = null;
            this.xEditGridCell69.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell69.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsReadOnly = true;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "sujin_no";
            this.xEditGridCell96.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell96.CellWidth = 74;
            this.xEditGridCell96.Col = -1;
            this.xEditGridCell96.ExecuteQuery = null;
            this.xEditGridCell96.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell96.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.IsVisible = false;
            this.xEditGridCell96.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "doku_yn";
            this.xEditGridCell98.CellWidth = 77;
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            this.xEditGridCell98.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell98.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsReadOnly = true;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "cont_key";
            this.xEditGridCell39.Col = -1;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsVisible = false;
            this.xEditGridCell39.Row = -1;
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "sys_id";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xLabel7
            // 
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel7.Name = "xLabel7";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnOUT1001Q01
            // 
            resources.ApplyResources(this.btnOUT1001Q01, "btnOUT1001Q01");
            this.btnOUT1001Q01.ImageIndex = 0;
            this.btnOUT1001Q01.ImageList = this.ImageList;
            this.btnOUT1001Q01.Name = "btnOUT1001Q01";
            this.btnOUT1001Q01.Click += new System.EventHandler(this.btnOUT1001Q01_Click);
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.btnOUT1001Q01);
            this.xPanel1.Controls.Add(this.btnPrint);
            this.xPanel1.Controls.Add(this.cbkSujin);
            this.xPanel1.Controls.Add(this.btnList);
            this.xPanel1.Controls.Add(this.btnINP1001Q00);
            this.xPanel1.Name = "xPanel1";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageIndex = 13;
            this.btnPrint.ImageList = this.ImageList;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbkSujin
            // 
            resources.ApplyResources(this.cbkSujin, "cbkSujin");
            this.cbkSujin.ForeColor = IHIS.Framework.XColor.InsertedForeColor;
            this.cbkSujin.Name = "cbkSujin";
            this.cbkSujin.UseVisualStyleBackColor = false;
            // 
            // btnINP1001Q00
            // 
            resources.ApplyResources(this.btnINP1001Q00, "btnINP1001Q00");
            this.btnINP1001Q00.ImageIndex = 1;
            this.btnINP1001Q00.ImageList = this.ImageList;
            this.btnINP1001Q00.Name = "btnINP1001Q00";
            this.btnINP1001Q00.Click += new System.EventHandler(this.btnINP1001Q00_Click);
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paBox.Name = "paBox";
            this.paBox.TabStop = false;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.pnlSTop);
            this.xPanel2.Name = "xPanel2";
            // 
            // pnlSTTop
            // 
            resources.ApplyResources(this.pnlSTTop, "pnlSTTop");
            this.pnlSTTop.Controls.Add(this.txtBunho);
            this.pnlSTTop.Controls.Add(this.paBox);
            this.pnlSTTop.DrawBorder = true;
            this.pnlSTTop.Name = "pnlSTTop";
            // 
            // txtBunho
            // 
            resources.ApplyResources(this.txtBunho, "txtBunho");
            this.txtBunho.Name = "txtBunho";
            this.txtBunho.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtBunho_DataValidating);
            this.txtBunho.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBunho_KeyDown);
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.CellName = "naewon_gubun";
            this.xEditGridCell94.Col = 8;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsReadOnly = true;
            // 
            // laySujinRemark
            // 
            this.laySujinRemark.CallerID = '8';
            this.laySujinRemark.ExecuteQuery = null;
            this.laySujinRemark.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31});
            this.laySujinRemark.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySujinRemark.ParamList")));
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "bunho";
            this.multiLayoutItem29.IsUpdItem = true;
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "naewon_date";
            this.multiLayoutItem30.IsUpdItem = true;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "remark";
            this.multiLayoutItem31.IsUpdItem = true;
            // 
            // laySusinPrint
            // 
            this.laySusinPrint.CallerID = '6';
            this.laySusinPrint.ExecuteQuery = null;
            this.laySusinPrint.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem32,
            this.multiLayoutItem33,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem41,
            this.multiLayoutItem42,
            this.multiLayoutItem43,
            this.multiLayoutItem44,
            this.multiLayoutItem45,
            this.multiLayoutItem46,
            this.multiLayoutItem47,
            this.multiLayoutItem48});
            this.laySusinPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySusinPrint.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "bunho";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "suname";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "sujin_no";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "naewon_date_jp";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "gwa_name";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "doctor_name";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "gubun_name";
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "jubsu_gubun";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "cht_chojae";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "gwa_cnt";
            this.multiLayoutItem38.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "doctor_cnt";
            this.multiLayoutItem39.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "last_check";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "jinchal";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "chart_cur_name";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "chojae";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "naewon_gubun";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "naewon_type";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "reser_order_yn";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "tel_gubun_gubun_code";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "remark";
            // 
            // layBarCode
            // 
            this.layBarCode.CallerID = '7';
            this.layBarCode.ExecuteQuery = null;
            this.layBarCode.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28});
            this.layBarCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layBarCode.ParamList")));
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "bunho";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "suname";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "sex";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "birth";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "bar_code";
            // 
            // layGongbiCode
            // 
            this.layGongbiCode.ExecuteQuery = null;
            this.layGongbiCode.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4});
            this.layGongbiCode.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGongbiCode.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "gongbi_code1";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "gongbi_code2";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "gongbi_code3";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "gongbi_code4";
            // 
            // layLastCheckDate
            // 
            this.layLastCheckDate.ExecuteQuery = null;
            this.layLastCheckDate.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layLastCheckDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layLastCheckDate.ParamList")));
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.dtpLastCheckDate;
            this.singleLayoutItem5.DataName = "last_check_date";
            // 
            // layGroupKey
            // 
            this.layGroupKey.ExecuteQuery = null;
            this.layGroupKey.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem6});
            this.layGroupKey.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layGroupKey.ParamList")));
            this.layGroupKey.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGroupKey_QueryStarting);
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "group_key";
            // 
            // OUT1001U01
            // 
            resources.ApplyResources(this, "$this");
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.pnlSTTop);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.xPanel1);
            this.Name = "OUT1001U01";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.OUT1001U01_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.OUT1001U01_ScreenOpen);
            this.Load += new System.EventHandler(this.OUT1001U01_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OUT1001U01_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdGongBi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlSTop.ResumeLayout(false);
            this.pnlMid.ResumeLayout(false);
            this.pnlOUT0106.ResumeLayout(false);
            this.pnlGongbi.ResumeLayout(false);
            this.pnlSTLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJubsu)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdJubsuHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.pnlSTTop.ResumeLayout(false);
            this.pnlSTTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySujinRemark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusinPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layBarCode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Screen 변수 

        // 환자관련 Deltail 정보 변수
        //private WON.PatientInfo.LoadPatientInfo mPaInfo = new IHIS.WON.PatientInfo.LoadPatientInfo();
        private NURO.PatientInfo mPaInfo = new PatientInfo();

        // 보험관련 Detail 정보 변수
        //private WON.LoadData.LoadBoheomInfo mBoheomInfo = new IHIS.WON.LoadData.LoadBoheomInfo();

        // 수진표 비고 텍스트 표시 여부
        //private bool mIsShownBigoText = false;

        // 회계완료 색상
        private XColor mSunabBackColor = new XColor(Color.PowderBlue);

        // 수진번호 필요없는 진료과 리스트
        private Hashtable mNotNessarySujinNoGwa = new Hashtable();

        // 수진번호가 필요한 접수 구분 리스트
        private Hashtable mNessarySujinNoTelGubun = new Hashtable();

        // 현재 환자의 맥스 Jubsu번호
        private string mMaxJubsuNo = "";

        // 메세지 관련
        private string mMsg = "";
        private string mCap = "";

        // 접수마감 관련
        private string mDoctor_name = "";
        private string mMagam_time = "";
        private string mMagam_time1 = "";
        //private string mRemark      = "";
        private string mJunpyo_date = "";
        //private string mSeq         = "";
        private string mNew_pkout_1001 = "";
        private string mHospCode = "";

        #endregion

        #region Screen Load

        private void OUT1001U01_Load(object sender, System.EventArgs e)
        {
            this.mHospCode = EnvironInfo.HospCode;

            this.ParentForm.KeyPreview = true;
            this.ParentForm.KeyDown += new KeyEventHandler(OUT1001U01_KeyDown);

            // 의사 파인드 창의 데이터 선택 인덱스는 4번째 컬럼
            ((XFindBox) ((XEditGridCell) grdJubsu.CellInfos["doctor"]).CellEditor.Editor).DataIndex = 2;

            this.InitScreen();

            // 수진번호 필요없는 진료과
            //this.mNotNessarySujinNoGwa.Add("08", IHIS.NURO.Methodes.GetBuseoNameBAS0260("1", "08", this.dtpNaewonDate.GetDataValue())); // 투석과

            // 수진번호 필요한 접수구분 리스트 
            //this.mNessarySujinNoTelGubun.Add("0", IHIS.NURO.Methodes.GetCodeNameBAS0102("JUBSU_GUBUN", "0")); // 내원접수
            //this.mNessarySujinNoTelGubun.Add("1", IHIS.NURO.Methodes.GetCodeNameBAS0102("JUBSU_GUBUN", "1")); // 전화접수
            //this.mNessarySujinNoTelGubun.Add("4", IHIS.NURO.Methodes.GetCodeNameBAS0102("JUBSU_GUBUN", "4")); // 예약검사후
            //this.mNessarySujinNoTelGubun.Add("5", IHIS.NURO.Methodes.GetCodeNameBAS0102("JUBSU_GUBUN", "5")); // 긴급

            // Create param list
            this.layLastCheckDate.ParamList = layLastCheckDate_CreateParam();
            this.layGroupKey.ParamList = layGroupKey_CreateParam();
            this.layGongbiCode.ParamList = layGongbiCode_CreateParam();

        }

        #endregion

        #region Open Screen ( 기타 화면 및 폼 로드 )

        /// <summary>
        /// 접수 마감 경고 메세지 폼
        /// </summary>
        private void OpenForm_DoctorJubsuCheckForm()
        {
            DoctorJubsuCheckForm form = new DoctorJubsuCheckForm();

            form.mDoctorName = this.mDoctor_name;
            form.mMagamTime = this.mMagam_time;
            form.mMagamTime1 = this.mMagam_time1;

            form.ShowDialog();

            form.Dispose();
        }

        /// <summary>
        /// 환자 보험 등록 
        /// </summary>
        private void OpenScreen_OUT0102U00()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.paBox.BunHo);

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0102U00", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ScreenMiddleCenter, param);
        }

        /// <summary>
        /// 환자 특기사항 등록
        /// </summary>
        private void OpenScreen_OUT0106U00()
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", this.paBox.BunHo);

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ScreenMiddleCenter, openParams);
        }

        /// <summary>
        /// 과별 접수 현황
        /// </summary>
        private void OpenScreen_OUT1001Q04() //버튼 언비져블. 사용안됨
        {
            XScreen.OpenScreen(this, "OUT1001Q04", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter);
        }

        /// <summary>
        /// 입원내역 조회
        /// </summary>
        private void OpenScreen_INP1001Q02() //버튼 언비져블. 사용안됨
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", this.paBox.BunHo);

            XScreen.OpenScreenWithParam(this, "INPS", "INP1001Q02", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ScreenMiddleCenter, openParams);
        }

        // 당일 접수 현황
        private void OpenScreen_OUT1001Q01() //버튼 언비져블. 사용안됨
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
            param.Add("bunho", this.paBox.BunHo);
            param.Add("JUBSUINFO", grdJubsu);

            XScreen.OpenScreenWithParam(this, "NURO", "OUT1001Q01", ScreenOpenStyle.ResponseFixed,
                ScreenAlignment.ScreenMiddleCenter, param);

        }

        // 수진 번호 입력창
        private DialogResult OpenForm_SujinNo(ref string aSujinNo)
        {
            DialogResult returnValue;

            FormSujinNo form = new FormSujinNo(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());

            returnValue = form.ShowDialog();

            aSujinNo = form.mReturnSujinNo;

            return returnValue;
        }

        //// 당일예약검사 확인 폼. 원래부터 사용안됨
        //private void OpenForm_ReserGumsa()
        //{
        //    FormReser form = new FormReser(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());

        //    form.ShowDialog();
        //}

        // 저장후 환자 안내 폼
        private void OpenForm_FormJubsuInfo()
        {
            FormJubsuInfo form = new FormJubsuInfo(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());

            form.ShowDialog();
        }

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
            if (!TypeCheck.IsNull(this.paBox.BunHo))
            {
                return new XPatientInfo(this.paBox.BunHo, "", "", "", this.ScreenName);
            }

            return null;
        }

        #endregion

        #region Function

        #region InitScreen

        private void InitScreen()
        {
            // 날짜 셋팅
            this.SetDate();

            // 담당자 셋팅
            this.dbxChanggu.SetDataValue(UserInfo.UserName);
            this.dbxChanggu.Tag = UserInfo.UserID;

            this.grdJubsu.Reset();
            this.grdComment.Reset();
            this.grdGongBi.Reset();
            this.grdJubsuHistory.Reset();

            // 맥스번호 클리어
            this.mMaxJubsuNo = "";

            //// 보험 컨트롤 프로텍트
            //this.ProtectControlBoheom(true);

            //// 보험 탭 클리어
            //this.ClearBoehomTab();

            // 포커스는 PatientBox
            this.paBox.Focus();
            this.txtBunho.ResetData();
            this.txtBunho.Focus();

        }

        #endregion

        #region SetDate (사용날자 셋팅)

        private void SetDate()
        {
            //string naewonDate ="";
            //string time       = "";
            //string junpyoDate = "";
            //string rmsg       = "";

            //WON.BizObj.ChkGetSetDate(UserInfo.UserID, ref time, ref naewonDate, ref junpyoDate, ref rmsg);

            this.dtpNaewonDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.emkJubsuTime.SetDataValue(EnvironInfo.GetSysDateTime().ToString("HHmm"));
            //this.dtpNaewonDate.SetDataValue(naewonDate);
            //this.emkJubsuTime.SetDataValue(time);
            //this.dbxJunpyoDate.SetDataValue(junpyoDate);
        }

        #endregion

        #region Insert Data ( 데이터 입력 )

        private void InsertOUT1001()
        {
            // 접수 가능 환자 여부 체크
            if (this.paBox.BunHo == "" ||
                this.IsValidPatient() == false)
            {
                return;
            }

            this.mMsg = "";
            //string columnName = "";
            bool isFindNullColumn = false;

            for (int i = 0; i < this.grdJubsu.RowCount; i++)
            {
                if (grdJubsu.GetRowState(i) != DataRowState.Added)
                    continue;

                #region 입력안된 데이터 체크

                // 진료과 데이터 
                if (this.grdJubsu.GetItemString(i, "gwa") == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과 정보를 입력해 주세요." : Resources.OUT1001U01_TEXT001;

                    isFindNullColumn = true;

                    //columnName = "gwa";

                    break;
                }

                // 진료의
                if (this.grdJubsu.GetItemString(i, "doctor") == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료의 정보를 입력해 주세요." : Resources.OUT1001U01_TEXT002;

                    isFindNullColumn = true;

                    //columnName = "doctor";

                    break;
                }

                // 접수번호
                if (this.grdJubsu.GetItemString(i, "jubsu_no") == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "접수번호를 입력해 주세요. " : Resources.OUT1001U01_TEXT003;

                    isFindNullColumn = true;

                    //columnName = "jubsu_no";

                    break;
                }

                // 보험종별
                if (this.grdJubsu.GetItemString(i, "gubun") == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "보험종류를 입력해 주세요." : Resources.OUT1001U01_TEXT004;

                    isFindNullColumn = true;

                    //columnName = "gubun";

                    break;
                }

                // 접수시간
                if (this.grdJubsu.GetItemString(i, "jubsu_time") == "")
                {
                    this.mMsg = NetInfo.Language == LangMode.Ko ? "접수시간을 입력해 주세요." : Resources.OUT1001U01_TEXT005;

                    isFindNullColumn = true;

                    //columnName = "jubsu_time";

                    break;
                }

            }

            if (isFindNullColumn)
            {
                XMessageBox.Show(this.mMsg, Resources.OUT1001U01_TEXT006, MessageBoxIcon.Warning);
                return;
            }

            #endregion

            this.grdJubsu.InsertRow(-1);

            // 디폴트 값 셋팅
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "bunho", this.paBox.BunHo);
            //this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "junpyo_date"   , this.dbxJunpyoDate.GetDataValue());
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "naewon_date", this.dtpNaewonDate.GetDataValue());
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "jubsu_time", this.emkJubsuTime.GetDataValue());

            this.mPaInfo.GetPatientInfo(this.paBox.BunHo);

            // 진료순번
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "jubsu_no", this.LoadMaxJubsuNo() + 1);
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "check_naewon", "Y");
            //MED-9650
            InitializeComboListItemResult result = initializeComboListItem();
            IList<object[]> lstDataComboType = createListDataForCombo(result.ComboTypeItem);
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "jubsu_gubun", lstDataComboType[0][0]);            

            //group_key
            this.layGroupKey.SetBindVarValue("f_code", "01");
            this.layGroupKey.QueryLayout();
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "group_key", layGroupKey.GetItemValue("group_key"));

            // 진료과로 포커스
            this.grdJubsu.SetFocusToItem(grdJubsu.CurrentRowNumber, "gwa", true);

            // https://sofiamedix.atlassian.net/browse/MED-15749
            this.SetDefaultGubun();
        }

        #endregion


        #region 오전 오후 구분 

        /// <summary>
        /// 시간을 넘겨받아 오전인지 오후인지 체크 함
        /// </summary>
        /// <param name="aTime">시간</param>
        /// <returns>'1'오전, '2'오후</returns>
        private string GetAMPMGubun(string aTime)
        {
            int time = 0;
            string returnGubun = "";

            if (TypeCheck.IsInt(aTime))
            {
                time = int.Parse(aTime);
            }

            if (time <= 1200)
            {
                returnGubun = "1";
            }
            else
            {
                returnGubun = "2";
            }

            return returnGubun;
        }

        #endregion

        #region 접수시 각종 체크

        #region 접수 불가 체크

        /// <summary>
        /// 접수 불가 체크
        /// </summary>
        /// <returns></returns>
        private bool IsValidPatient()
        {
            this.mPaInfo.GetPatientInfo(this.paBox.BunHo);

            // 삭제 여부
            if (this.mPaInfo.DeleteYN == "Y")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "삭제된 환자번호 입니다." : Resources.OUT1001U01_TEXT007;
                this.mCap = NetInfo.Language == LangMode.Ko ? "접수불가" : Resources.OUT1001U01_TEXT008;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            // 접수 불가 환자 여부 //컬럼은 남아있지만 환자정보에서 등록할 수 없음. 라이브러리에서도 지워야할듯?
            //if (this.mPaInfo.JubsuBreak == "Y")
            //{
            //    this.mMsg  = NetInfo.Language == LangMode.Ko ? "다음의 이유로 접수가 불가능 합니다." : "次の事由で受付が制限されました。";
            //    this.mMsg += "\n=================================================\n";
            //    this.mMsg += (NetInfo.Language == LangMode.Ko ? " ▶ 사유 : " : " ▶ 事由 : ") +
            //        IHIS.NURO.Methodes.GetCodeNameBAS0102("JUBSU_BREAK_REASON", this.mPaInfo.JubsuBreakReason);
            //    this.mCap = NetInfo.Language == LangMode.Ko ? "접수불가" : "受付不可";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

            //    return false;
            //}

            // 재원 여부
            if (this.mPaInfo.JaewonPatientYN == "Y")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko
                    ? "현재 재원중인 환자입니다. 접수가 불가능 합니다"
                    : Resources.OUT1001U01_TEXT009;
                this.mCap = NetInfo.Language == LangMode.Ko ? "접수불가" : Resources.OUT1001U01_TEXT008;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

            return true;
        }

        #endregion

        #region 예약체크

        private void CheckReserData(string aBunho, string aNaewonDate, string aGwa, string aDoctor)
        {
            string jinryoPreTime = "";
            string doctorName = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "doctor_name");

            this.mMsg = "";
            this.mCap = NetInfo.Language == LangMode.Ko ? "알림" : Resources.OUT1001U01_TEXT010;

//            DataTable retTab = IHIS.NURO.Methodes.LoadTableReserYN(aBunho, aGwa, aNaewonDate, aDoctor);
            List<DataStringListItemInfo> lstDataStringListItemInfo = IHIS.NURO.Methodes.LoadTableReserYN(aBunho, aGwa, aNaewonDate, aDoctor);

            if ((lstDataStringListItemInfo == null) || (lstDataStringListItemInfo.Count < 1))
            {
            }
            else
            {
                jinryoPreTime = lstDataStringListItemInfo[0].DataValue;
                if (jinryoPreTime.Length >= 4)
                {
                    this.mMsg += jinryoPreTime.Substring(0, 2) + ":" + jinryoPreTime.Substring(2, 2);
                }

                this.mMsg += "に" + doctorName + "先生の診療予約があります。";

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 의사 스케쥴 체크

        private void CheckDoctorSchedule(string aNaewonDate, string aJubsuTime, string aGwa, string aDoctor)
        {
            // Connect cloud
            string doctorName = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "doctor_name");
            NuroOut1001U01CheckDoctorScheduleArgs args = new NuroOut1001U01CheckDoctorScheduleArgs();
            args.Type = "OUT";
            args.NaewonDate = aNaewonDate;
            args.JubsuTime = aJubsuTime;
            args.Doctor = aDoctor;
            args.Gwa = aGwa;
            NuroOut1001U01CheckDoctorScheduleResult checkDoctorScheduleResult =
                CloudService.Instance
                    .Submit<NuroOut1001U01CheckDoctorScheduleResult, NuroOut1001U01CheckDoctorScheduleArgs>(args);
            if (checkDoctorScheduleResult != null) 
            {
                if (!String.IsNullOrEmpty(checkDoctorScheduleResult.Ret) && checkDoctorScheduleResult.Ret != "0")
                {
                    string from_time = checkDoctorScheduleResult.FromTime;
                    string to_time = checkDoctorScheduleResult.ToTime;
                    string sch_flag = checkDoctorScheduleResult.SchFlag;
                    this.mMsg = doctorName + Resources.OUT1001U01_TEXT011;
                        
                    if (from_time != "" && to_time != "")
                        this.mMsg += Resources.msg_CheckDoctorSchedule + from_time.Substring(0, 2) + ":" + from_time.Substring(2, 2) +
                                     "～"
                                     + to_time.Substring(0, 2) + ":" + to_time.Substring(2, 2);
                    this.mCap = Resources.OUT1001U01_TEXT012;

                    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        #region 의사 접수 마감 체크 

        private bool CheckJubsuMagam(string aJubsuDate, string aGwa, string aDoctor, string aJubsuTime)
        {
            //string AMPMGubun = this.GetAMPMGubun(aJubsuTime);

            //string cmdText = "SELECT 'Y'"
            //                +"     , FN_BAS_LOAD_DOCTOR_NAME (DOCTOR, MAGAM_DATE)"
            //                +"     , MAGAM_TIME"
            //                +"     , MAGAM_TIME1"
            //                +"  FROM OUT5002"
            //                + " WHERE HOSP_CODE = :f_hosp_code"
            //                + "  AND MAGAM_DATE = :f_jubsu_date"
            //                +"   AND GWA        = :f_gwa"
            //                +"   AND DOCTOR     = :f_doctor"
            //                +"   AND ("
            //                +"         (:f_am_pm_gubun = '1'"
            //                +"          AND"
            //                +"          MAGAM_TIME  < :f_jubsu_time)"
            //                +"       OR"
            //                +"         (:f_am_pm_gubun = '2'"
            //                +"          AND"
            //                +"          MAGAM_TIME1 < :f_jubsu_time)"
            //                +"       )";

            //BindVarCollection bindVars = new BindVarCollection();
            //bindVars.Add("f_hosp_code"  , this.mHospCode);
            //bindVars.Add("f_jubsu_date" , aJubsuDate);
            //bindVars.Add("f_gwa"        , aGwa      );
            //bindVars.Add("f_doctor"     , aDoctor   );
            //bindVars.Add("f_jubsu_time" , aJubsuTime);
            //bindVars.Add("f_am_pm_gubun", AMPMGubun );

            //DataTable retTab = Service.ExecuteDataTable(cmdText, bindVars);
            //if((retTab == null)||(retTab.Rows.Count < 1))
            //{
            //    return false;
            //}

            //string checkYN = retTab.Rows[0][0].ToString();

            //// 전역변수 셋팅
            //mDoctor_name = retTab.Rows[0][1].ToString();
            //mMagam_time  = retTab.Rows[0][2].ToString();
            //mMagam_time1 = retTab.Rows[0][3].ToString();

            //if (checkYN == "Y")
            //{
            //    return true;
            //}

            return false;
        }

        #endregion

        #region 최종확인일 체크 

        private void CheckLastCheckDate(string aNaewonDate)
        {
            DateTime lastCheckDate;
            DateTime currentDate;
            bool isShowMsg = false;

            if (this.dtpLastCheckDate.GetDataValue() == "")
            {
                isShowMsg = true;
            }

            if (isShowMsg == false)
            {
                lastCheckDate = DateTime.Parse(this.dtpLastCheckDate.GetDataValue());
                currentDate = DateTime.Parse(aNaewonDate);

                if (lastCheckDate.Year <= currentDate.Year &&
                    lastCheckDate.Month < currentDate.Month)
                {
                    isShowMsg = true;
                }
            }

            if (isShowMsg == true)
            {
                //this.mMsg = (NetInfo.Language == LangMode.Ko ? "마지막으로 보험을 확인한 일이 1개월 이전입니다.보험정보를 확인해주세요."
                //    : "保険の最終確認日付が1ヶ月以前です。保険をご確認ください。");
                //this.mCap = (NetInfo.Language == LangMode.Ko ? "보험확인" : "保険確認");

                //XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region 공비 적용 여부 메세지(공비 적용 못하는 보험일 경우)

        private bool IsApplyNewGubun()
        {
            this.mMsg = (NetInfo.Language == LangMode.Ko
                ? "현재 보험종류는 공비를 적용하지 않습니다.\n보험종류를 변경하시겠습니까?"
                : Resources.OUT1001U01_TEXT013);
            this.mCap = (NetInfo.Language == LangMode.Ko ? "알림" : Resources.OUT1001U01_TEXT010);

            if (this.grdGongBi.RowCount <= 0)
                return false;

            if (XMessageBox.Show(mMsg, mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #endregion

        #region 원외여부 기본값 설정

        //private void DefaultSetWonyoiYN(string aBunho, string aNaewonDate, string aJubsuTime)
        //{
        //    string wonyoiYN = IHIS.NURO.Methodes.ChkGetWonyoiYn(aBunho, aNaewonDate, aJubsuTime);

        //    if (this.grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "wonyoi_order_yn") == "")
        //    {
        //        this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "wonyoi_order_yn", wonyoiYN);
        //    }
        //}

        private void DefaultSetWonyoiYN(string aGubun, string aGongbiCode1, string aGongbiCode2, string aGongbiCode3,
            string aGongbiCode4)
        {
            string aWonyoiYn1 = string.Empty;
            string aWonyoiYn2 = string.Empty;
            string aWonyoiYn3 = string.Empty;
            string aWonyoiYn4 = string.Empty;

            string wonyoiYN = IHIS.NURO.Methodes.ChkGetWonyoiYn(aGubun, aGongbiCode1, aGongbiCode2, aGongbiCode3,
                aGongbiCode4);
            //ref aWonyoiYn1, ref aWonyoiYn2, ref aWonyoiYn3, ref aWonyoiYn4);

            if (this.grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "wonyoi_order_yn") == "")
            {
                this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "wonyoi_order_yn", wonyoiYN);
            }
        }

        #endregion

        #region 디폴트 접수 번호 로드

        private int LoadMaxJubsuNo()
        {
            int curJubsuNo = -1;
            int maxJubsuNo = 0;
            int maxDbJubsuNo = 0;

            if (TypeCheck.IsInt(this.mMaxJubsuNo))
            {
                maxDbJubsuNo = int.Parse(this.mMaxJubsuNo);
            }

            for (int i = 0; i < this.grdJubsu.RowCount; i++)
            {
                curJubsuNo = int.Parse(TypeCheck.NVL(this.grdJubsu.GetItemString(i, "jubsu_no"), "0").ToString());

                if (curJubsuNo > maxJubsuNo)
                {
                    maxJubsuNo = curJubsuNo;
                }
            }

            if (maxJubsuNo > maxDbJubsuNo)
            {
                return maxJubsuNo;
            }
            else
            {
                return maxDbJubsuNo;
            }
        }

        #endregion

        #endregion

        #region DataLoad

        /// <summary>
        /// 환자별 공비정보 조회
        /// </summary>
        private void LoadOUT0105(string aBunho, string aNaewonDate)
        {
            this.grdGongBi.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdGongBi.SetBindVarValue("f_bunho", aBunho);
            this.grdGongBi.SetBindVarValue("f_naewon_date", aNaewonDate);

            //tungtx
            if (lstInsurance != null)
            {
                this.grdGongBi.setDataForGrid(lstInsurance);
            }
            for (int i = 0; i < this.grdGongBi.RowCount; i++)
            {

                IList<object[]> lstdata = new List<object[]>();
                NuroOUT1001U01LoadOUT0105Args args =
                    new NuroOUT1001U01LoadOUT0105Args(this.grdGongBi.GetItemString(i, "gongbi_code"),
                        this.grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "pkout1001"));
                NuroOUT1001U01LoadOUT0105Result loadOut0105Result =
                    CloudService.Instance.Submit<NuroOUT1001U01LoadOUT0105Result, NuroOUT1001U01LoadOUT0105Args>(args);
                if (loadOut0105Result != null)
                {
                    List<NuroOUT1001U01LoadOUT0105Info> lstItemValue = loadOut0105Result.ItemValue;
                    if (lstItemValue != null && lstItemValue.Count > 0)
                    {
                        foreach (NuroOUT1001U01LoadOUT0105Info info in lstItemValue)
                        {
                            object[] objInfo =
                            {
                                info.GongbiCode,
                                info.Priority
                            };
                            lstdata.Add(objInfo);
                        }
                    }
                }

                if (lstdata != null && lstdata.Count > 0)
                {
                    object[] objData = lstdata[0];
                    if (objData[0] != null)
                    {
                        this.grdGongBi.SetItemValue(i, "check", "Y");
                        this.grdGongBi.SetItemValue(i, "priority", objData[0].ToString());
                    }
                }
            }
            this.grdGongBi.ResetUpdate();
        }

        /// <summary>
        /// 환자별 특기사항 조회
        /// </summary>
        private void LoadOUT0106(string aBunho)
        {
            this.grdComment.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdComment.SetBindVarValue("f_bunho", aBunho);

            //tungtx
            if (lstComment != null)
            {
                this.grdComment.setDataForGrid(lstComment);
            }
           
        }

        /// <summary>
        /// 접수내역 조회
        /// </summary>
        private void LoadOUT1001(string aBunho, string aNaewonDate)
        {

        }

        #region 수진표 코맨트 로드

        private void LoadSujinRemark(string aBunho, string aNaewonDate)
        {

        }

        #endregion

        /// <summary>
        /// 접수 히스토리
        /// </summary>
        /// <param name="aBunho"></param>
        private void LoadOUT1001His(string aBunho)
        {
            this.grdJubsuHistory.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdJubsuHistory.SetBindVarValue("f_bunho", aBunho);
            //tungtx
            if (lstHistory != null)
            {
                grdJubsuHistory.setDataForGrid(lstHistory);
            }
        }

        private void LoadDbMaxJubsuNo(string aBunho, string aNaewonDate)
        {
            
            //Start Connect to cloud
            object retVal = null;
            NuroOUT1001U01GetDbMaxJubsuNoArgs args = new NuroOUT1001U01GetDbMaxJubsuNoArgs(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());
            NuroOUT1001U01GetDbMaxJubsuNoResult dbMaxJubsuNoResult =
                CloudService.Instance.Submit<NuroOUT1001U01GetDbMaxJubsuNoResult, NuroOUT1001U01GetDbMaxJubsuNoArgs>(
                    args);
            if (dbMaxJubsuNoResult != null)
            {
                retVal = dbMaxJubsuNoResult.MaxJubsuNo;
            }
            // End Connect to cloud
            if (retVal == null)
            {
                XMessageBox.Show(Service.ErrFullMsg + " : MaxJubsu_No Query Error");
                return;
            }

            this.mMaxJubsuNo = TypeCheck.NVL(retVal.ToString(), 0).ToString();
        }

        #endregion

        #region Update전 체크 사항

        private bool UpdateCheck(ref bool aIsExistModifiedRow, ref bool aIsExistAddedRow, ref string aSujinNo)
        {
            this.mCap = NetInfo.Language == LangMode.Ko ? "접수불가" : Resources.OUT1001U01_TEXT008;

            bool isExistModifiedData = false; // 변경된 데이터가 있는지 여부
            bool isDisplaySujinNoForm = false; // 수진번호 입력창을 오픈 할 건지 여부

            bool isFindNullColumn = false; // 체크 컬럼중 널값이 있는지 여부
            int problemRowNumber = -1; // 널값이 있는 로우 넘버
            string columnName = ""; // 널값이 있는 컬럼

            ArrayList gongbiNullRowNumber = new ArrayList(); // 공비가 있는데도 공비체크가 되지 않은 접수건 로우번호

            ArrayList sameGwaRowNumber = new ArrayList(); // 같은과 접수건 체크
            string sameGwaCode = "";
            int sameGwaRow = -1;


            for (int i = 0; i < this.grdJubsu.RowCount; i++)
            {
                sameGwaCode = this.grdJubsu.GetItemString(i, "gwa");
                sameGwaRow = i;

                #region 동일과 접수 체크

                for (int row = 0; row < this.grdJubsu.RowCount; row++)
                {
                    if (row != i &&
                        sameGwaCode == this.grdJubsu.GetItemString(row, "gwa"))
                    {
                        if (!sameGwaRowNumber.Contains(row))
                            sameGwaRowNumber.Add(row);
                    }
                }

                #endregion

                if (this.grdJubsu.GetRowState(i) != DataRowState.Unchanged)
                {
                    isExistModifiedData = true;
                    problemRowNumber = i;
                    aIsExistModifiedRow = true;

                    if (this.grdJubsu.GetRowState(i) == DataRowState.Added)
                    {
                        aIsExistAddedRow = true;
                    }

                    #region 입력안된 데이터 체크

                    // 진료과 데이터 
                    if (this.grdJubsu.GetItemString(i, "gwa") == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과 정보를 입력해 주세요." : Resources.OUT1001U01_TEXT001;

                        isFindNullColumn = true;

                        columnName = "gwa";

                        break;
                    }

                    // 진료의
                    if (this.grdJubsu.GetItemString(i, "doctor") == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "진료의 정보를 입력해 주세요." : Resources.OUT1001U01_TEXT002;

                        isFindNullColumn = true;

                        columnName = "doctor";

                        break;
                    }

                    // 접수번호
                    if (this.grdJubsu.GetItemString(i, "jubsu_no") == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "접수번호를 입력해 주세요. " : Resources.OUT1001U01_TEXT003;

                        isFindNullColumn = true;

                        columnName = "jubsu_no";

                        problemRowNumber = i;

                        break;
                    }

                    // 보험종별
                    //if (this.grdJubsu.GetItemString(i, "gubun") == "" && String.IsNullOrEmpty(UserInfo.MisaIp))
                    // https://sofiamedix.atlassian.net/browse/MED-10343
                    //if (this.grdJubsu.GetItemString(i, "gubun") == "" && NetInfo.Language != LangMode.Vi)
                    if (this.grdJubsu.GetItemString(i, "gubun") == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "보험종류를 입력해 주세요." : Resources.OUT1001U01_TEXT004;

                        isFindNullColumn = true;

                        columnName = "gubun";

                        break;
                    }


                    //if(this.grdJubsu.GetItemString(i, "ga_jubsu_gubun").ToString() == "")
                    //{
                    //    XMessageBox.Show("診察料を入力してください。");
                    //    return false;
                    //}

                    //접수시간
                    if (this.grdJubsu.GetItemString(i, "jubsu_time") == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "접수시간을 입력해 주세요." : Resources.OUT1001U01_TEXT005;

                        isFindNullColumn = true;

                        columnName = "jubsu_time";

                        break;
                    }

                    //// 카르테 과
                    //if (this.grdJubsu.GetItemString(i, "chart_gwa") == "")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "챠트과를 입력해 주세요." : "カルテ科を入力してください。";

                    //    isFindNullColumn = true;

                    //    columnName = "chart_gwa";

                    //    break;
                    //}

                    //// 환자구분
                    //if (this.grdJubsu.GetItemString(i, "patient_gubun") == "")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "환자구분을 입력해 주세요." : "患者区分を入力してください。";

                    //    isFindNullColumn = true;

                    //    columnName = "patient_gubun";

                    //    break;
                    //}

                    #endregion

                    #region 공비가 있는데도 공비체크 안된 접수건

                    /*
                    if (this.grdGongBi.RowCount > 0 &&
                        this.grdJubsu.GetItemString(i, "gongbi_code1") == "" &&
                        this.grdJubsu.GetItemString(i, "gongbi_code2") == "" &&
                        this.grdJubsu.GetItemString(i, "gongbi_code3") == "" &&
                        this.grdJubsu.GetItemString(i, "gongbi_code4") == "")
                    {

                        gongbiNullRowNumber.Add(i);
                    }
                    */

                    #endregion

                    #region 수진 번호 입력창 오픈 여부

                    if (isDisplaySujinNoForm == false &&
                        this.grdJubsu.GetItemString(i, "sujin_no") == "")
                    {
                        isDisplaySujinNoForm = true;
                    }

                    #endregion

                }
            }

            if (aIsExistModifiedRow == false &&
                this.grdJubsu.DeletedRowTable != null &&
                this.grdJubsu.DeletedRowTable.Rows.Count > 0)
            {
                aIsExistModifiedRow = true;
            }

            // 널값 메세지 출력
            if (isExistModifiedData == true &&
                isFindNullColumn == true)
            {
                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.grdJubsu.SetFocusToItem(problemRowNumber, columnName, true);

                return false;
            }

            //공비 메세지 출력
            /*
            if (gongbiNullRowNumber.Count > 0)
            {
                this.mMsg = "";
                for (int j=0; j<gongbiNullRowNumber.Count; j++)
                {
                    this.mMsg += this.grdJubsu.GetItemString(int.Parse(gongbiNullRowNumber[j].ToString()), "gwa_name" ) + "  " + 
                        this.grdJubsu.GetItemString(int.Parse(gongbiNullRowNumber[j].ToString()), "doctor_name") + "\n" ;
                }
                this.mMsg += "==================================================\n";
                this.mMsg += NetInfo.Language == LangMode.Ko ? "공비가 선택되지 않은 접수건이 존재 합니다. 이대로 저장하시겠습니까?" 
                    : "公費が選択されていない受付情報があります。\r\nこのまま保存しますか。" ;

                this.mCap = NetInfo.Language == LangMode.Ko ? "접수체크" : "受付確認";

                if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return false;
                }
            }
            */
            // 동일과 접수 체크
            if (sameGwaRowNumber.Count > 0)
            {
                this.mMsg = "";
                for (int k = 0; k < sameGwaRowNumber.Count; k++)
                {
                    this.mMsg += this.grdJubsu.GetItemString(int.Parse(sameGwaRowNumber[k].ToString()), "gwa_name") +
                                 "  " +
                                 this.grdJubsu.GetItemString(int.Parse(sameGwaRowNumber[k].ToString()), "doctor_name") +
                                 "\n";
                }
                this.mMsg += "==================================================\n";
                this.mMsg += NetInfo.Language == LangMode.Ko
                    ? "동일한 진료과가 존재합니다. 그래도 저장하시겠습니까?"
                    : Resources.OUT1001U01_TEXT014;

                this.mCap = NetInfo.Language == LangMode.Ko ? "접수체크" : Resources.OUT1001U01_TEXT015;

                if (XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) !=
                    DialogResult.Yes)
                {
                    return false;
                }
            }

            //수진표출력
            //// 접수체크후 수진번호 입력창 오픈
            if (isDisplaySujinNoForm == true)
            {
                //if (this.Update_SujinNo(ref aSujinNo) == false)
                //{
                //    return false;
                //}
            }
            return true;
        }

        #endregion

        #region 수진번호 입력 

        private bool Update_SujinNo(ref string aSujinNo)
        {
            if (this.OpenForm_SujinNo(ref aSujinNo) == DialogResult.OK)
            {
                for (int i = 0; i < this.grdJubsu.RowCount; i++)
                {
                    if (this.grdJubsu.GetItemString(i, "sujin_no") == "" &&
                        this.grdJubsu.GetRowState(i) != DataRowState.Unchanged)
                    {
                        this.grdJubsu.SetItemValue(i, "sujin_no", aSujinNo);
                    }
                }

                return true;
            }

            else
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "저장이 취소 되었습니다." : Resources.OUT1001U01_TEXT016;
                this.mCap = NetInfo.Language == LangMode.Ko ? "저장취소" : Resources.OUT1001U01_TEXT017;

                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }

        #endregion

        #region 보험 업데이트

        //private bool UpdateBoheom ()
        //{
        //    // 보험정보 저장			

        //    if(!this.grdBoheom.SaveLayout())
        //    {
        //        this.mMsg = NetInfo.Language == LangMode.Ko ? "보험정보저장에 실패 하였습니다." : "保険情報保存に失敗しました。";
        //        this.mMsg += "-" + Service.ErrFullMsg;

        //        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return false;
        //    }

        //    return true;
        //}

        #endregion

        #region 수진 리마크 업데이트 

        //private bool UpdateSujinRemark()
        //{
        //    //kbh1219
        //    // 변경 내역 체크
        //    if (mRemark.ToString() == this.txtBigo.GetDataValue())
        //    {
        //        return true;
        //    }

        //    // 
        //    this.laySujinRemark.Reset();

        //    if (this.txtBigo.GetDataValue() != "")
        //    {
        //        this.laySujinRemark.InsertRow(-1);

        //        this.laySujinRemark.SetItemValue(this.laySujinRemark.RowCount - 1, "bunho", this.paBox.BunHo);
        //        this.laySujinRemark.SetItemValue(this.laySujinRemark.RowCount - 1, "naewon_date", this.dtpNaewonDate.GetDataValue());
        //        this.laySujinRemark.SetItemValue(this.laySujinRemark.RowCount - 1, "remark", this.txtBigo.GetDataValue());
        //    }

        //    if (!this.laySujinRemark.SaveLayout())
        //    {
        //        this.mMsg = NetInfo.Language == LangMode.Ko ? "수진표 비고사항 저장에 실패 하였습니다." : "受診票備考事項保存に失敗しました。";
        //        this.mMsg += "-" + Service.ErrFullMsg;

        //        this.mCap = NetInfo.Language == LangMode.Ko ? "저장실패" : "保存失敗";

        //        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //        return false;
        //    }

        //    return true;
        //}

        #endregion

        #region 접수건 업데이트

        private bool UpdateJubsuData()
        {
            string t_time = string.Empty;
            string t_naewon_date = string.Empty;
            string io_err = string.Empty;
            string o_err = string.Empty;
            string i_err = string.Empty;
            string cmdText = string.Empty;
            BindVarCollection bindVars = new BindVarCollection();

            // List data for update Grid Jubsu
            List<UpdateJubsuDataInfo> lstData = new List<UpdateJubsuDataInfo>();

            if (grdJubsu.DeletedRowTable != null)
            {
                foreach (DataRow row in grdJubsu.DeletedRowTable.Rows)
                {
                    // 내원확인 체크
                    UpdateJubsuDataInfo dataInfo = new UpdateJubsuDataInfo();
                    dataInfo.PatientCode = row["bunho"].ToString();
                    dataInfo.ComingDate = row["naewon_date"].ToString();
                    dataInfo.DepartmentCode = row["gwa"].ToString();
                    dataInfo.DoctorCode = row["doctor"].ToString();
                    dataInfo.ComingType = row["naewon_type"].ToString();
                    dataInfo.ReceptionNo = row["jubsu_no"].ToString();
                    dataInfo.ExamStatus = row["chojae"].ToString();
                    dataInfo.Pkout1001 = row["pkout1001"].ToString();
                    dataInfo.DataRowState = DataRowState.Deleted.ToString();
                    lstData.Add(dataInfo);
                    
//                    // Start Connect to Cloud
//                    object retVal = null;
//                    NuroOUT1001U01CheckNaewonYnArgs args = new NuroOUT1001U01CheckNaewonYnArgs(row["bunho"].ToString(),
//                        row["naewon_date"].ToString(), row["gwa"].ToString(), row["doctor"].ToString(),
//                        row["naewon_type"].ToString(), row["jubsu_no"].ToString(), row["chojae"].ToString());
//                    NuroOUT1001U01CheckNaewonYnResult checkNaewonYnResult =
//                        CloudService.Instance.Submit<NuroOUT1001U01CheckNaewonYnResult, NuroOUT1001U01CheckNaewonYnArgs>
//                            (args);
//                    // End Connect to Cloud
//                    if (checkNaewonYnResult != null)
//                    {
//                        retVal = checkNaewonYnResult.ValueCheckNaewon;
//                    }
//                    if (retVal == null)
//                    {
//                    }
//                    else
//                    {
//                        if (retVal.ToString() == "E")
//                        {
//                            XMessageBox.Show(Resources.OUT1001U01_TEXT018, Resources.OUT1001U01_TEXT019,
//                                MessageBoxIcon.Warning);
//                            return false;
//                        }
//                    }
//
//                    ArrayList inputList = new ArrayList();
//                    ArrayList outputList = new ArrayList();
//
//                    // 전표일자 구하기
//                    inputList.Add(UserInfo.UserID);
//
//                    mJunpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
//
//                    cmdText = string.Empty;
//
//                    cmdText = @"SELECT 'Y'
//                                  FROM SYS.DUAL 
//                                 WHERE EXISTS ( SELECT NULL
//							  	                  FROM OUT1001 A
//							  	                 WHERE A.HOSP_CODE = :f_hosp_code 
//                                                   AND A.PKOUT1001 = :f_pkout1001 
//                                              )
//                               ";
//
//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", this.mHospCode);
//                    bindVars.Add("f_pkout1001", row["pkout1001"].ToString());
//
//                    object retVal1 = Service.ExecuteScalar(cmdText, bindVars);
//                    if (retVal1 == null)
//                    {
//                    }
//                    else
//                    {
//                        if (retVal1.ToString() == "Y")
//                        {
//                            
//                            cmdText = string.Empty;
//
//                            cmdText = @"DELETE 
//                                          FROM OUT1001
//									     WHERE HOSP_CODE = :f_hosp_code 
//                                           AND PKOUT1001 = :f_pkout1001
//                                       ";
//
//                            bool retTF = Service.ExecuteNonQuery(cmdText, bindVars);
//                            if (!retTF)
//                            {
//                                XMessageBox.Show(Service.ErrFullMsg + " : OUT1001 DELETE Error");
//                                return false;
//                            }
//
//                        }
//                    }
                }
            }
            
            // Connect Cloud: insert gridJubsu
            if (grdJubsu.RowCount > 0)
            {
                for (int i = 0; i < grdJubsu.RowCount; i++)
                {
                    // https://sofiamedix.atlassian.net/browse/MED-13459
                    if (grdJubsu.GetRowState(i) == DataRowState.Unchanged) continue;

                    UpdateJubsuDataInfo dataInfo = create_JubsuDataInfo(i);
                    
                    if (grdJubsu.GetRowState(i) == DataRowState.Added)
                    {
                        dataInfo.DataRowState = DataRowState.Added.ToString();
                    }
                    else if (grdJubsu.GetRowState(i) == DataRowState.Modified)
                    {
                        dataInfo.DataRowState = DataRowState.Modified.ToString();
                    }
                    lstData.Add(dataInfo);
                }
            }

            if (lstData != null && lstData.Count > 0)
            {
                UpdateJubsuDataArgs dataArgs = new UpdateJubsuDataArgs();
                dataArgs.DataInfo = lstData;
                dataArgs.IsOrca = false;
                dataArgs.OrcaGigwanCode = "";
                UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, UpdateJubsuDataArgs>(dataArgs);
                if (updateResult == null || updateResult.Result == false)
                {
                    //https://sofiamedix.atlassian.net/browse/MED-15718
                    //if (updateResult.Msg != "17" || updateResult.Msg != "00" || updateResult.Msg != "K1" || updateResult.Msg != "K2" || updateResult.Msg != "K3")
                    //{
                    //    XMessageBox.Show(Utilities.MessageOrca(updateResult.Msg), Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                    //}
                    //Message from Orca
                    if (String.IsNullOrEmpty(updateResult.Msg))
                    {
                        XMessageBox.Show(Resources.OUT1001U01_TEXT030, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                        //XMessageBox.Show(Utilities.MessageOrca(updateResult.Msg), updateResult.Msg, MessageBoxIcon.Error);
                        return false;
                    }

                    switch (updateResult.Msg)
                    {
                        case "OUT1001U01_TEXT020":
                            XMessageBox.Show(Resources.OUT1001U01_TEXT020, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;
                        case "OUT1001U01_TEXT021":
                            XMessageBox.Show(Resources.OUT1001U01_TEXT021, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;
                        case "OUT1001U01_TEXT024":
                            XMessageBox.Show(Resources.OUT1001U01_TEXT024, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;
                        case "OUT1001U01_TEXT018":
                            XMessageBox.Show(Resources.OUT1001U01_TEXT018, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;                       
                        case "17":
                            XMessageBox.Show(Resources.MSG_17, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;
                        default:
                            XMessageBox.Show(Resources.OUT1001U01_TEXT030, Resources.OUT1001U01_TEXT031, MessageBoxIcon.Error);
                            break;
                    }                 

                    

                    return false;
                }
            }

            return true;

//            for (int i = 0; i < grdJubsu.RowCount; i++)
//            {    
//                if (this.grdJubsu.GetRowState(i) == DataRowState.Added)
//                {
//                    ArrayList inputList = new ArrayList();
//                    ArrayList outputList = new ArrayList();
//
//                    // 전표일자 구하기
//                    inputList.Add(UserInfo.UserID);
//
//                    inputList.Clear();
//                    outputList.Clear();
//
//
//
//                    cmdText = @"SELECT 'Y'
//						          FROM OUT1001
//						         WHERE HOSP_CODE   = :f_hosp_code
//                                   AND BUNHO       = :f_bunho
//						           AND NAEWON_DATE = :f_naewon_date
//						           AND GWA         = :f_gwa
//						           AND DOCTOR      = :f_doctor
//						           AND NAEWON_TYPE = :f_naewon_type
//						           AND JUBSU_NO    = :f_jubsu_no     
//                               ";
//
//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", this.mHospCode);
//                    bindVars.Add("f_bunho", this.grdJubsu.GetItemString(i, "bunho"));
//                    bindVars.Add("f_naewon_date", this.grdJubsu.GetItemString(i, "naewon_date"));
//                    bindVars.Add("f_gwa", this.grdJubsu.GetItemString(i, "gwa"));
//                    bindVars.Add("f_doctor", this.grdJubsu.GetItemString(i, "doctor"));
//                    bindVars.Add("f_naewon_type", this.grdJubsu.GetItemString(i, "naewon_type"));
//                    bindVars.Add("f_jubsu_no", this.grdJubsu.GetItemString(i, "jubsu_no"));
//
//                    object retVal1 = Service.ExecuteScalar(cmdText, bindVars);
//                    if (retVal1 == null)
//                    {
//                    }
//                    else
//                    {
//                        if (retVal1.ToString() == "Y")
//                        {
//                            XMessageBox.Show(Resources.OUT1001U01_TEXT020);
//                            return false;
//                        }
//                    }
//
//                    // 접수순번 체크
//                    cmdText = string.Empty;
//
//                    cmdText = @"SELECT 'Y'
//						          FROM SYS.DUAL
//						         WHERE EXISTS (SELECT NULL
//						                         FROM OUT1001 A
//						                        WHERE A.HOSP_CODE   = :f_hosp_code
//						                          AND A.BUNHO       = :f_bunho
//						                          AND A.NAEWON_DATE = TO_DATE(:f_naewon_date, 'YYYY/MM/DD')
//						                          AND A.JUBSU_NO    = :f_jubsu_no
//                                              )
//                               ";
//
//                    bindVars.Clear();
//                    bindVars.Add("f_hosp_code", this.mHospCode);
//                    bindVars.Add("f_bunho", this.grdJubsu.GetItemString(i, "bunho"));
//                    bindVars.Add("f_naewon_date", this.grdJubsu.GetItemString(i, "naewon_date"));
//                    bindVars.Add("f_jubsu_no", this.grdJubsu.GetItemString(i, "jubsu_no"));
//
//                    object retVal2 = Service.ExecuteScalar(cmdText, bindVars);
//                    if (retVal2 == null)
//                    {
//                    }
//                    else
//                    {
//                        if (retVal2.ToString() == "Y")
//                        {
//                            XMessageBox.Show(Resources.OUT1001U01_TEXT021);
//                            return false;
//                        }
//                    }
//
//                    cmdText = @"SELECT OUT1001_SEQ.NEXTVAL FROM SYS.DUAL";
//                    object tPKOUT1001 = Service.ExecuteScalar(cmdText);
//
//                    if (!TypeCheck.IsNull(tPKOUT1001))
//                        mNew_pkout_1001 = tPKOUT1001.ToString();
//                    else
//                    {
//                        XMessageBox.Show(Resources.OUT1001U01_TEXT022, Resources.OUT1001U01_TEXT023,
//                            MessageBoxIcon.Warning);
//                        return false;
//                    }
//
//                    bindVars.Add("f_jubsu_time", this.grdJubsu.GetItemString(i, "jubsu_time"));
//                    bindVars.Add("f_arrive_time", this.grdJubsu.GetItemString(i, "arrive_time"));
//
//                    bool retTF = false;
//                    NuroOUT1001U01InsertJubsuArgs args = new NuroOUT1001U01InsertJubsuArgs();
//                    args.SysId = UserInfo.UserID;
//                    args.UpdId = UserInfo.UserID;
//                    args.Pkout1001 = mNew_pkout_1001;
//                    args.NaewonDate = grdJubsu.GetItemString(i, "naewon_date");
//                    args.Bunho = grdJubsu.GetItemString(i, "bunho");
//                    args.Gwa = grdJubsu.GetItemString(i, "gwa");
//                    args.Gubun = grdJubsu.GetItemString(i, "gubun");
//                    args.Doctor = grdJubsu.GetItemString(i, "doctor");
//                    args.Chojae = grdJubsu.GetItemString(i, "chojae");
//                    args.JubsuTime = grdJubsu.GetItemString(i, "jubsu_time");
//                    args.NaewonYn = grdJubsu.GetItemString(i, "check_naewon");
//                    args.JubsuTime = grdJubsu.GetItemString(i, "jubsu_time");
//                    args.NaewonType = grdJubsu.GetItemString(i, "naewon_type");
//                    args.SunnabYn = grdJubsu.GetItemString(i, "sunnab_yn");
//                    args.JubsuGubun = grdJubsu.GetItemString(i, "jubsu_gubun");
//                    args.InpTransYn = grdJubsu.GetItemString(i, "inp_trans_yn");
//                    // TODO remove hard code Bigo
//                    args.Bigo = "外来受付";
//                    args.JubsuNo = grdJubsu.GetItemString(i, "jubsu_no");
//                    args.SujinNo = grdJubsu.GetItemString(i, "sujin_no");
//                    args.WonyoiOrderYn = grdJubsu.GetItemString(i, "wonyoi_order_yn");
//
//                    NuroOUT1001U01InsertJubsuResult insertJubsuResult =
//                        CloudService.Instance.Submit<NuroOUT1001U01InsertJubsuResult, NuroOUT1001U01InsertJubsuArgs>(
//                            args);
//                    if (insertJubsuResult != null)
//                    {
//                        retTF = insertJubsuResult.ResultInsert;
//                    }
//
//                    if (!retTF)
//                    {
//                        XMessageBox.Show(Service.ErrFullMsg + " : OUT1001 Insert Error");
//                        return false;
//                    }
//                    // End connect cloud
//
//                    inputList.Clear();
//                    outputList.Clear();
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code1").Length != 0)
//                    {
//                        // Start connect to cloud
//                        bool retTF1 = InsertOut1002WithGongbiCode1(i);
//                        // End connect cloud
//                        if (!retTF1)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002-1 Insert Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code2").Length != 0)
//                    {
//                        // Start connect to cloud
//                        bool retTF2 = InsertOut1002WithGongbiCode2(i);
//                        
//                        // End connect cloud
//                        if (!retTF2)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002-2 Insert Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code3").Length != 0)
//                    {
//
//                        // Start connect to cloud
//                        bool retTF3 = InsertOut1002WithGongbiCode3(i);  
//                        // End connect cloud
//                        if (!retTF3)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002-3 Insert Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code4").Length != 0)
//                    {
//
//                        // Start connect to cloud
//                        bool retTF4 = InsertOut1002WithGongbiCode4(i);
//                        
//                        // End connect cloud
//                        if (!retTF4)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002-4 Insert Error");
//                            return false;
//                        }
//                    }
//
//                    inputList.Clear();
//                    outputList.Clear();
//
//                }
//                else if (this.grdJubsu.GetRowState(i) == DataRowState.Modified)
//                {
//                    // 보험정보 체크
//                    cmdText = "SELECT FN_OUT_LOAD_GUBUN_NAME_NEW(:f_gubun, :f_naewon_date, :f_bunho)"
//                              + "  FROM SYS.DUAL"
//                        ;
//
//                    bindVars.Clear();
//                    bindVars.Add("f_gubun", grdJubsu.GetItemString(i, "gubun"));
//                    bindVars.Add("f_naewon_date", grdJubsu.GetItemString(i, "naewon_date"));
//                    bindVars.Add("f_bunho", grdJubsu.GetItemString(i, "bunho"));
//
//                    object retVal = Service.ExecuteScalar(cmdText, bindVars);
//                    if (retVal == null)
//                    {
//                        XMessageBox.Show(Resources.OUT1001U01_TEXT024);
//                        return false;
//                    }
//                    else
//                    {
//                        if (retVal.ToString().Length <= 0)
//                        {
//                            XMessageBox.Show(Resources.OUT1001U01_TEXT024);
//                            return false;
//                        }
//                    }
//
//                    ArrayList inputList = new ArrayList();
//                    ArrayList outputList = new ArrayList();
//
//                    // 전표 일자 구하기
//                    inputList.Add(UserInfo.UserID);
//                    mJunpyo_date = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
//
//                    inputList.Clear();
//                    outputList.Clear();
//
//                    // linhnt Start connect to cloud    
//                    bool retTF = false;
//                    NuroOUT1001U01UpdateTableOUT1001Args args = new NuroOUT1001U01UpdateTableOUT1001Args();
//                    args.UserId = UserInfo.UserID;
//                    args.Doctor = grdJubsu.GetItemString(i, "doctor");
//                    args.Chojae = grdJubsu.GetItemString(i, "chojae");
//                    args.JubsuNo = grdJubsu.GetItemString(i, "jubsu_no");
//                    args.Gubun = grdJubsu.GetItemString(i, "bunho");
//                    args.JubsuTime = grdJubsu.GetItemValue(i, "jubsu_time").ToString();
//                    args.ArriveTime = grdJubsu.GetItemValue(i, "arrive_time").ToString();
//                    args.JubsuGubun = grdJubsu.GetItemString(i, "jubsu_gubun");
//                    args.CheckNaewon = grdJubsu.GetItemString(i, "check_naewon");
//                    args.Pkout1001 = grdJubsu.GetItemString(i, "pkout1001");
//                    NuroOUT1001U01UpdateTableOUT1001Result resultUpdate =
//                        CloudService.Instance
//                            .Submit<NuroOUT1001U01UpdateTableOUT1001Result, NuroOUT1001U01UpdateTableOUT1001Args>(args);
//                    if (resultUpdate != null)
//                    {
//                        retTF = resultUpdate.ValueUpdateOut1001;
//                    }
//                    // End connect to cloud
//
//                    if (!retTF)
//                    {
//                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + "OUT1001 UPDATE Error");
//                            return false;
//                        }
//                    }
//
//                    cmdText = string.Empty;
//
//                    cmdText = @"DELETE OUT1002
//								 WHERE HOSP_CODE = :f_hosp_code
//                                   AND FKOUT1001 = :f_pkout1001";
//
//                    bool retTF1 = Service.ExecuteNonQuery(cmdText, bindVars);
//                    if (!retTF1)
//                    {
//                        XMessageBox.Show(Service.ErrFullMsg + " : OUT1002 DELETE Error");
//                        return false;
//                    }
//
//                    // 공비 저장
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code1").Length > 0)
//                    {
//                        
//                        bool retTF2 = InsertOut1002WithGongbiCode1(i);
//                        if (!retTF2)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002 INSERT Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code2").Length > 0)
//                    {
//                        
//                        bool retTF3 = InsertOut1002WithGongbiCode2(i);
//                        if (!retTF3)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002 INSERT Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code3").Length > 0)
//                    {
//                        
//                        bool retTF4 = InsertOut1002WithGongbiCode3(i);
//                        if (!retTF4)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002 INSERT Error");
//                            return false;
//                        }
//                    }
//
//                    if (this.grdJubsu.GetItemString(i, "gongbi_code4").Length > 0)
//                    {
//                        
//                        bool retTF5 = InsertOut1002WithGongbiCode4(i);
//                        if (!retTF5)
//                        {
//                            XMessageBox.Show(Service.ErrFullMsg + " : OUT1002 INSERT Error");
//                            return false;
//                        }
//                    }
//                }
//            }
//
//            return true;
        }

        private UpdateJubsuDataInfo create_JubsuDataInfo(int i)
        {
            UpdateJubsuDataInfo dataInfo = new UpdateJubsuDataInfo();
            dataInfo.SysId = UserInfo.UserID;
            dataInfo.UpdId = UserInfo.UserID;
            dataInfo.DepartmentCode = grdJubsu.GetItemString(i, "gwa");
            dataInfo.DepartmentName = grdJubsu.GetItemString(i, "gwa_name");
            dataInfo.DoctorCode = grdJubsu.GetItemString(i, "doctor");
            dataInfo.DoctorName = grdJubsu.GetItemString(i, "doctor_name");
            dataInfo.ExamStatus = grdJubsu.GetItemString(i, "chojae");
            dataInfo.ReceptionNo = grdJubsu.GetItemString(i, "jubsu_no");
            dataInfo.InsurCode = grdJubsu.GetItemString(i, "gubun");
            dataInfo.InsurName = grdJubsu.GetItemString(i, "gubun_name");
            dataInfo.PatientCode = grdJubsu.GetItemString(i, "bunho");
            dataInfo.ComingDate = grdJubsu.GetItemString(i, "naewon_date");
            dataInfo.Pkout1001 = grdJubsu.GetItemString(i, "pkout1001");
            dataInfo.ReceptionTime = grdJubsu.GetItemString(i, "jubsu_time");
            dataInfo.ComingStatus = grdJubsu.GetItemString(i, "naewon_yn");
            dataInfo.ComingType = grdJubsu.GetItemString(i, "naewon_type");
            dataInfo.SunnabStatus = grdJubsu.GetItemString(i, "sunnab_yn");
            dataInfo.Fkinp1001 = grdJubsu.GetItemString(i, "fkinp1001");
            dataInfo.ReceptionType = grdJubsu.GetItemString(i, "jubsu_gubun");
            dataInfo.InpTransStatus = grdJubsu.GetItemString(i, "inp_trans_yn");
            dataInfo.Bigo = grdJubsu.GetItemString(i, "bigo");
            dataInfo.InsurCode1 = grdJubsu.GetItemString(i, "gongbi_code1");
            dataInfo.InsurCode2 = grdJubsu.GetItemString(i, "gongbi_code2");
            dataInfo.InsurCode3 = grdJubsu.GetItemString(i, "gongbi_code3");
            dataInfo.InsurCode4 = grdJubsu.GetItemString(i, "gongbi_code4");
            dataInfo.Priority1 = grdJubsu.GetItemString(i, "priority1");
            dataInfo.Priority2 = grdJubsu.GetItemString(i, "priority2");
            dataInfo.Priority3 = grdJubsu.GetItemString(i, "priority3");
            dataInfo.Priority4 = grdJubsu.GetItemString(i, "priority4");
            dataInfo.SujinNo = grdJubsu.GetItemString(i, "sujin_no");
            dataInfo.WonyoiOrderStatus = grdJubsu.GetItemString(i, "wonyoi_order_yn");
            dataInfo.ReserStatus = grdJubsu.GetItemString(i, "reser_yn");
            dataInfo.Button = grdJubsu.GetItemString(i, "button");
            dataInfo.CheckComing = grdJubsu.GetItemString(i, "check_naewon");
            dataInfo.ArriveTime = grdJubsu.GetItemString(i, "arrive_time");
            dataInfo.GroupKey = grdJubsu.GetItemString(i, "group_key");

            return dataInfo;
        }
       
        #endregion


        #region Update 후

        #region 수진표 출력

        //private bool SujinPrint (string aSujinNo, bool aIsSuccessBarCode, bool aIsSuccessJinchal)
        //{
//            bool isSuccessPrint = false;

//            string cmdText = @"SELECT FN_CHT_BUSEO_NAME_LOAD(DECODE(NVL(A.BANNAB_YN,'N'),'Y','EMR', NVL(A.CHART_CUR, 'EMR')), A.DAECHUL_YMD) CHART_CUR_NAME
//                                  FROM CHT1002 A
//                                 WHERE A.HOSP_CODE = :f_hosp_code
//                                   AND A.BUNHO = :f_bunho
//                                   AND A.DAECHUL_YMD = (SELECT MAX(Y.DAECHUL_YMD)
//                                                          FROM CHT1002 Y
//                                                         WHERE Y.HOSP_CODE = A.HOSP_CODE
//                                                           AND Y.BUNHO = A.BUNHO
//                                                           AND Y.DAECHUL_YMD <= TRUNC(SYSDATE))
//                                   AND A.SERIAL      = (SELECT MAX(Z.SERIAL)
//                                                          FROM CHT1002 Z
//                                                         WHERE Z.HOSP_CODE = A.HOSP_CODE
//                                                           AND Z.BUNHO        = A.BUNHO
//                                                           AND Z.DAECHUL_YMD  = A.DAECHUL_YMD )
//                                   AND ROWNUM = 1";

//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_hosp_code", this.mHospCode);
//            bindVars.Add("f_bunho", this.paBox.BunHo);
//            bindVars.Add("f_naewon_date", this.dtpNaewonDate.GetDataValue());

//            object retVal = Service.ExecuteScalar(cmdText, bindVars);
//            if(retVal == null)
//            {
//            }
//            else
//            {
//                if(retVal.ToString().Length <= 0)
//                {
//                    cmdText = string.Empty;

//                    cmdText = "SELECT FN_CHT_BUSEO_NAME_LOAD('EMR', :f_naewon_date) CHART_CUR_NAME"
//                        +"  FROM DUAL";

//                    retVal = null;
//                    retVal = Service.ExecuteScalar(cmdText, bindVars);
//                }
//            }

//            this.laySusinPrint.SetBindVarValue("f_hosp_code"     , this.mHospCode);
//            this.laySusinPrint.SetBindVarValue("f_bunho"         , this.paBox.BunHo);
//            this.laySusinPrint.SetBindVarValue("f_naewon_date"   , this.dtpNaewonDate.GetDataValue());
//            this.laySusinPrint.SetBindVarValue("f_reprint_yn"    , "N");
//            this.laySusinPrint.SetBindVarValue("f_sujin_no"      , aSujinNo);
//            if(retVal != null)
//            {
//                this.laySusinPrint.SetBindVarValue("f_chart_cur_name", retVal.ToString());
//            }

//            if(!this.laySusinPrint.QueryLayout(true))
//            {
//                XMessageBox.Show(Service.ErrFullMsg + " : laySusinPrint Query Error");
//                return false;
//            }
//            else
//            {
//                if(this.laySusinPrint.RowCount <= 0)
//                {
//                    return false;
//                }
//            }

//            if(laySusinPrint.RowCount > 0)
//            {
//                this.dsSujinPrint.Reset();
//                this.dsSujinPrint.FillData(this.laySusinPrint.LayoutTable);
//            }

//            // 다른것들 출력 여부
//            dsSujinPrint.Modify("t_bar.text = ' '");
//            if (aIsSuccessBarCode == true)
//            {
//                // 수진표에 바코드 출력여부 보여줌
//                dsSujinPrint.Modify("t_bar.text = " + (NetInfo.Language == LangMode.Ko ? "'바'" : "'バー'"));
//            }

//            dsSujinPrint.Modify("t_jin.text = ' '");
//            if (aIsSuccessJinchal == true)
//            {
//                // 수진표에 진찰권 출력여부 보여줌
//                dsSujinPrint.Modify("t_jin.text = " + (NetInfo.Language == LangMode.Ko ? "'진'" : "'診'"));
//            }

//            dsSujinPrint.Modify("t_cho.text = ' '");
//            dsSujinPrint.Modify("t_new.text = ' '");

//            try
//            {
//                this.dsSujinPrint.Print();

//                isSuccessPrint = true;    	
//            }
//            catch
//            {
//                isSuccessPrint = false;
//            }

//            return isSuccessPrint ;
        //}

        #endregion

        #region 진찰권

        private bool JinchalPrint()
        {
            return true;
        }

        #endregion

        #region 바코드 

        //private bool BarCodePrint()
        //{
        //    bool isSuccess = false;

        //    if (this.mPaInfo.BAR_CODE_YN == "Y")
        //    {
        //        return false;
        //    }

        //    this.layBarCode.SetBindVarValue("f_hosp_code", this.mHospCode);
        //    this.layBarCode.SetBindVarValue("f_bunho", this.paBox.BunHo);

        //    if(!this.layBarCode.QueryLayout(true))
        //    {
        //        XMessageBox.Show(Service.ErrFullMsg + " : layBarCode Query Error");
        //        return false;
        //    }
        //    else
        //    {
        //        if(this.layBarCode.RowCount <= 0)
        //        {
        //            return false;
        //        }
        //    }

        //    string printName   = GetCodeNameBAS0102("PRINT_NAME", "BARCODE");

        //    try
        //    {
        //        if(this.layBarCode.RowCount > 0)
        //        {
        //            this.dsBarCode.Reset();
        //            this.dsBarCode.FillData(this.layBarCode.LayoutTable);
        //        }

        //        this.dsBarCode.Print();

        //        isSuccess = true;


        //    }
        //    catch
        //    {
        //        isSuccess = false;
        //    }

        //    return isSuccess;
        //}

        #endregion

        #region 출력여부 업데이트

//        private void UpdatePrintYN (bool aIsUpdateBarCode, bool aIsUpdateJinchal)
//        {
//            string cmdText = @"UPDATE OUT0101
//								  SET BAR_CODE_YN = :f_bar_code_yn
//								  	, CARD_YN     = :f_jinchal_yn
//								  	, CARD_DATE   = TRUNC(SYSDATE)
//								WHERE HOSP_CODE   = :f_hosp_code 
//                                  AND BUNHO       = :f_bunho";

//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_hosp_code",   this.mHospCode);
//            bindVars.Add("f_bunho"      , this.paBox.BunHo);
//            bindVars.Add("f_bar_code_yn", aIsUpdateBarCode == true ? "Y" : "N");
//            bindVars.Add("f_jinchal_yn" , aIsUpdateJinchal == true ? "Y" : "N");

//            bool retTF = Service.ExecuteNonQuery(cmdText, bindVars);
//            if(!retTF)
//            {
//                XMessageBox.Show(Service.ErrFullMsg + " : BAR_CODE_YN UPDATE Error");
//            }
//        }

        #endregion

        #endregion

        #region 비고 텍스트 관련

        //private void btnBigo_Click(object sender, System.EventArgs e)
        //{
        //    //kbh1219
        //    if (this.mIsShownBigoText == true)
        //    {
        //        this.pnlBigo.Visible = false;
        //        this.mIsShownBigoText = false;
        //        this.btnBigo.ImageIndex = 6;

        //    }
        //    else
        //    {
        //        this.pnlBigo.Visible = true;
        //        this.mIsShownBigoText = true;
        //        this.btnBigo.ImageIndex = 7;

        //        this.txtBigo.Focus();
        //    }

        //    this.BigoImageChange();
        //}

        //private void BigoImageChange()
        //{
        //    if (this.txtBigo.GetDataValue() != "")
        //    {
        //        this.btnBigo.ImageIndex = 8;
        //    }
        //    else
        //    {
        //        if (this.mIsShownBigoText == true)
        //        {
        //            this.btnBigo.ImageIndex = 7;
        //        }
        //        else
        //        {
        //            this.btnBigo.ImageIndex = 6;
        //        }
        //    }
        //}

        //kbh1219
        //private void txtBigo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Enter:

        //            if (this.mIsShownBigoText == true)
        //            {
        //                this.txtBigo.AcceptData();

        //                this.btnBigo.PerformClick();
        //            }

        //            this.BigoImageChange();

        //            break;

        //        case Keys.Escape:

        //            this.txtBigo.SetEditValue("");
        //            this.txtBigo.AcceptData();

        //            this.btnBigo.PerformClick();

        //            break;
        //    }
        //}

        //kbh1219
        //private void CloseBigoText(bool aIsClearText)
        //{
        //    if (this.mIsShownBigoText == true)
        //    {
        //        if (aIsClearText == true)
        //        {
        //            this.txtBigo.SetDataValue("");
        //        }

        //        this.btnBigo.PerformClick();
        //    }
        //    else
        //    {
        //        if (aIsClearText == true)
        //        {
        //            this.txtBigo.SetDataValue("");
        //        }
        //    }

        //    this.BigoImageChange();
        //}

        #endregion

        #region XPatientBox

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            this.mPaInfo.GetPatientInfo(this.paBox.BunHo);
            this.txtBunho.Text = this.paBox.BunHo;

            // 맥스 번호 로드
            this.LoadDbMaxJubsuNo(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());

            // 접수 가능 환자인지 여부 체크
            if (this.IsValidPatient())
            {
                this.btnList.PerformClick(FunctionType.Query);
                if (this.grdJubsu.RowCount < 1)
                    this.InsertOUT1001();

                //if (this.grdJubsu.RowCount > 0)
                //{
                //    if (this.grdJubsu.CurrentRowNumber > -1)
                //        this.grdJubsu.SetFocusToItem(this.grdJubsu.CurrentRowNumber, "gwa", true);
                //    else
                //        this.grdJubsu.SetFocusToItem(this.grdJubsu.RowCount - 1, "gwa", true);
                //}
            }
            else
            {
                this.btnList.PerformClick(FunctionType.Reset);
            }
        }

        private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
        {
            this.mPaInfo.ClearPatientInfo();

            this.btnList.PerformClick(FunctionType.Reset);
        }

        #endregion

        #region DataValidating

        private bool DoctorCodeValidating(string aDoctor)
        {
            string name = "";

            if (aDoctor == "")
            {
                this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "doctor_name", "");
                this.SetMsg("");

                return true;
            }

            int rowNum = grdJubsu.CurrentRowNumber;
            name = IHIS.NURO.Methodes.GetDoctorNameBAS0270(aDoctor, grdJubsu.GetItemString(rowNum, "gwa"),
                grdJubsu.GetItemString(rowNum, "naewon_date"));

            if (name == "")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko
                    ? "의사코드가 정확하지않습니다. 확인바랍니다."
                    : Resources.OUT1001U01_TEXT025;

                //this.SetMsg(this.mMsg, MsgType.Error);

                return false;
            }

            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "doctor_name", name);

            // 예약 체크 
            this.CheckReserData(this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "bunho")
                , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date")
                , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa")
                , aDoctor);



            // 접수마감과 의사 스케쥴 체크
            // 의사 스케쥴 체크는 접수마감이 되지 않은 의사에 한해서 체크함
            //if (this.CheckJubsuMagam(this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date")
            //                       , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa")
            //                       , aDoctor
            //                       , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_time")) )
            //{
            //    PostCallHelper.PostCall(new PostMethodStr(PostDoctorValidating), "JubsuMagam");
            //}
            //else
            //{
            this.CheckDoctorSchedule(this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date")
                , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_time")
                , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa")
                , aDoctor);
            //}

            this.SetMsg("");

            return true;

        }

        private bool GubunValidating(string aGubun)
        {
            string name = "";

            if (aGubun == "")
            {
                this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun_name", "");
                this.SetMsg("");

                return true;
            }

            name = IHIS.NURO.Methodes.GetGubunName(aGubun,
                this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date"));

            if (name == "")
            {
                this.mMsg = NetInfo.Language == LangMode.Ko ? "보험정보가 유효하지 않습니다." : Resources.OUT1001U01_TEXT026;

                //this.SetMsg(this.mMsg, MsgType.Error);

                return false;
            }

            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun_name", name);

            //2. 원외여부 기본값 셋팅
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //this.DefaultSetWonyoiYN(paBox.BunHo
            //    ,this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date")
            //    ,this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_time"));

            //this.DefaultSetWonyoiYN(aGubun
            //    , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code1")
            //    , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code2")
            //    , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code3")
            //    , this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code4"));


            // 3. 공비적용가능여부 체크
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //mBoheomInfo.GetData(aGubun, EnvironInfo.GetSysDate());
            //if (this.mBoheomInfo.GONGBI_YN != "Y")

            this.mGongbiYN = NURO.Methodes.ChkGetGongbiYN(aGubun, EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            if (this.mGongbiYN != "Y")
            {
                // 현재 보험이 공비 적용이 안되니깐 
                // 적용할건지 여부를 물어봄
                if (!this.IsApplyNewGubun())
                {
                    // 공비 체크 해제
                    for (int i = 0; i < grdGongBi.RowCount; i++)
                    {
                        grdGongBi.SetItemValue(i, "check", "N");
                    }

                    grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code1", "");
                    grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code2", "");
                    grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code3", "");
                    grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code4", "");

                    // 공비 체크 해제후 공비 그리드 ReadOnly
                    this.grdGongBi.ReadOnly = true;
                }
                else
                {
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "보험종류를 다시 선택하세요." : Resources.OUT1001U01_TEXT027);
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun_name", "");
                    this.SetMsg(mMsg, MsgType.Error);

                    return false;
                }
            }
            else
            {
                this.grdGongBi.ReadOnly = false;
            }

            //// 4. 보험탭 선택
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //this.SelectCurrentBoheomTab(aGubun);

            //// 5. 최종확인일 체크
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            this.CheckLastCheckDate(this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date"));

            return true;
        }

        #endregion


        #region XButtonList

        private bool mIsSaveSuccess = true;

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    this.InitScreen();
                    break;

                case FunctionType.Query:

                    e.IsBaseCall = false;

                    #region 조회 

                    try
                    {
                        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                        string bunho = this.paBox.BunHo;
                        string naewonDate = this.dtpNaewonDate.GetDataValue();


                        //// 보험정보 로드
                        //this.LoadOUT0102(bunho, naewonDate);

                        // 접수 정보
                        //this.LoadOUT1001(bunho, naewonDate);
                        //this.grdJubsu.QueryLayout(false);

                        //tungtx
                        GetDataGridView(true);
                        if (lstJubsu != null)
                        {
                            grdJubsu.setDataForGrid(lstJubsu);

                            // https://sofiamedix.atlassian.net/browse/MED-15905
                            //this.SetDefaultGubun(); //https://sofiamedix.atlassian.net/browse/MED-16779
                        }
                        // 공비정보 로드
                        this.LoadOUT0105(bunho, naewonDate);

                        // 특기사항
                        this.LoadOUT0106(bunho);


                        // 수진표 코맨트 
                        //this.LoadSujinRemark(bunho, naewonDate);

                        // 접수 히스토리
                        this.LoadOUT1001His(bunho);

                    }
                    finally
                    {
                        Cursor.Current = System.Windows.Forms.Cursors.Default;
                    }

                    #endregion

                    break;

                case FunctionType.Insert:

                    e.IsBaseCall = false;

                    this.InsertOUT1001();

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    bool isUpdateJubsu = false;
                    bool isAddedRow = false;
                    string sujinNo = "";

                    // 업데이트 로직
                    //    1. 데이터 셋팅 및 수진번호 셋팅
                    //    2. 보험정보 저장하고
                    //    3. 수진 리마크 저장 한후
                    //    4. 실제 접수 저장

                    if (this.UpdateCheck(ref isUpdateJubsu, ref isAddedRow, ref sujinNo) == false)
                    {
                        return;
                    }
                    //HungNV added
                    if (string.IsNullOrEmpty(this.paBox.BunHo)) return;
                    mIsSaveSuccess = true;
                    try
                    {
                        // 접수 정보 저장
                        if (isUpdateJubsu == true)
                        {
                            if (this.UpdateJubsuData() == false)
                                return;
                        }

                        // 접수 정보
                        //tungtx update data for grid
//                        grdJubsu.ParamList = CreateParamList();
//                        grdJubsu.ExecuteQuery = grdJubsu_GetData;
//                        grdJubsu.QueryLayout(false);


                        // 여기 까지 내려온다면 저장은 전부 성공
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : Resources.OUT1001U01_TEXT028;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "저장완료" : Resources.OUT1001U01_TEXT029;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch 
                    {
                        mIsSaveSuccess = false;
                        this.mMsg = Resources.OUT1001U01_TEXT030;
                        this.mCap = Resources.OUT1001U01_TEXT031;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 접수 완료후 각종 출력및 로직들

                    if (isUpdateJubsu == true && isAddedRow == true)
                    {
                        // 출력대상인지 확인을 위하여 환자 정보 다시 조회
                        this.mPaInfo.ClearPatientInfo();
                        this.mPaInfo.GetPatientInfo(this.paBox.BunHo);

                        if (this.cbkSujin.Checked)
                            this.btnPrint.PerformClick();
                    }

                    // 저장 로직 끝 화면 클리어
                    this.btnList.PerformClick(FunctionType.Reset);

                    break;

                case FunctionType.Delete:

                    e.IsBaseCall = false;

                    if (grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "naewon_yn") == "E")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko
                            ? "오더가 등록되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오."
                            : Resources.OUT1001U01_TEXT032;
                        this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : Resources.OUT1001U01_TEXT033;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }

                    // TODO comment use cloud connect
//                    string cmdText = @"SELECT FN_OUT_CHECK_NAEWON_YN(:f_bunho, TO_DATE(:f_naewon_date, 'YYYY/MM/DD'),
//                                                                     :f_gwa  , :f_doctor, :f_naewon_type, :f_jubsu_no, :f_chojae) FROM SYS.DUAL
//                                      ";
//                    BindVarCollection bc = new BindVarCollection();
//                    bc.Add("f_bunho", this.paBox.BunHo);
//                    bc.Add("f_naewon_date", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date"));
//                    bc.Add("f_gwa", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa"));
//                    bc.Add("f_doctor", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "doctor"));
//                    bc.Add("f_naewon_type", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_type"));
//                    bc.Add("f_jubsu_no", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_no"));
//                    bc.Add("f_chojae", this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "chojae"));
//                    object ret = Service.ExecuteScalar(cmdText, bc);
                    
                    
                    // Connect to cloud service
                    NuroOUT1001U01CheckNaewonYnArgs args = new NuroOUT1001U01CheckNaewonYnArgs();
                    args.Bunho = this.paBox.BunHo;
                    args.NaewonDate = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date");
                    args.Gwa = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa");
                    args.Doctor = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "doctor");
                    args.NaewonType = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_type");
                    args.OldJubsuNo = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_no");
                    args.Chojae = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "chojae");

                    NuroOUT1001U01CheckNaewonYnResult checkNaewonYnResult =
                        CloudService.Instance.Submit<NuroOUT1001U01CheckNaewonYnResult, NuroOUT1001U01CheckNaewonYnArgs>
                            (args);

                    string naewonYN = "N";

                    if (checkNaewonYnResult != null && checkNaewonYnResult.ExecutionStatus == ExecutionStatus.Success)
                    {
                        naewonYN = checkNaewonYnResult.ValueCheckNaewon;
                    }

                    //if (naewonYN == "Y")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과에서 내원확인이 되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오." : "診療科で来院確認がされたので修正できません。\r\n診療科にお問合せください。";
                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : "外来受付";

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else 
                    // MED-7837
                    //if (naewonYN == "O")
                    //{
                    //    this.mMsg = NetInfo.Language == LangMode.Ko
                    //        ? "오더가 등록되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오."
                    //        : Resources.OUT1001U01_TEXT034;
                    //    this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : Resources.OUT1001U01_TEXT033;

                    //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{
                        this.grdJubsu.DeleteRow(this.grdJubsu.CurrentRowNumber);
                    //}

                    break;
            }
        }

        #endregion

        #region XEditGrid

        #region 접수 그리드

        #region 파인드 클릭

        private void grdJubsu_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
        {
            fwkCommon.ColInfos.Clear();
            fwkCommon.ServerFilter = false;

            switch (e.ColName)
            {
                case "gwa":

                    #region 진료과

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

//                    fwkCommon.InputSQL = @"SELECT A.GWA
//                                                , A.GWA_NAME
//                                                , A.BUSEO_CODE
//                                             FROM BAS0260 A
//                                            WHERE A.HOSP_CODE   = :f_hosp_code
//                                              AND A.BUSEO_GUBUN = '1'  /*진료과*/
//                                              AND :f_buseo_ymd  BETWEEN A.START_DATE AND A.END_DATE
//                                              AND(A.GWA         LIKE '%' || :f_find1 || '%'
//                                               OR A.GWA_NAME    LIKE '%' || :f_find1 || '%')
//                                            ORDER BY A.GWA
//                                          ";

                    fwkCommon.ParamList = new List<string>(new String[] { "f_buseo_ymd", "f_find1" });

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", this.mHospCode);
                    fwkCommon.BindVarList.Add("f_buseo_ymd", this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));

                    fwkCommon.ExecuteQuery = xFindWorker_GetDepartment;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gwa", Resources.OUT1001U01_TEXT035, FindColType.String, 80, 0, true,
                        FilterType.No);
                    this.fwkCommon.ColInfos.Add("gwa_name", Resources.OUT1001U01_TEXT036, FindColType.String, 200, 0,
                        true, FilterType.InitYes);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;

                case "doctor":

                    #region 진료의

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

//                    fwkCommon.InputSQL = @"SELECT A.GWA
//                                                 , A.GWA_NAME
//                                                 , A.DOCTOR
//                                                 , A.DOCTOR_NAME
//                                                 , NVL(Z.WAITING_PATIENT, 0)
//                                                 , NVL(Z.TOTAL_PATIENT, 0)
//                                             FROM
//                                                   ( SELECT A.DOCTOR
//                                                          , SUM(DECODE(A.NAEWON_YN, 'Y', 1, 'H', 1, 0)) WAITING_PATIENT
//                                                          , COUNT(1)                            TOTAL_PATIENT
//                                                          , A.HOSP_CODE                         HOSP_CODE
//                                                       FROM OUT1001 A
//                                                      WHERE A.HOSP_CODE   = :f_hosp_code 
//                                                        AND A.NAEWON_DATE = :f_naewon_date
//                                                        AND A.GWA         = :f_gwa
//                                                      GROUP BY A.GWA, A.DOCTOR, A.HOSP_CODE  
//                                                   ) Z
//                                                 , ( SELECT A.DOCTOR            DOCTOR
//                                                          , A.DOCTOR_GWA        GWA
//                                                          , FN_BAS_LOAD_DOCTOR_NAME(A.DOCTOR, :f_naewon_date)      DOCTOR_NAME
//                                                          , FN_BAS_LOAD_GWA_NAME(A.DOCTOR_GWA, A.START_DATE)                  GWA_NAME
//                                                          , A.HOSP_CODE
//                                                       FROM BAS0270 A
//                                                      WHERE A.HOSP_CODE    = :f_hosp_code
//                                                        AND A.DOCTOR_GWA   = :f_gwa
//                                                        AND :f_naewon_date BETWEEN A.START_DATE AND A.END_DATE   
//                                                   ) A
//                                             WHERE A.HOSP_CODE      = :f_hosp_code
//                                               AND A.DOCTOR_NAME    LIKE :f_find1 || '%'
//                                               AND Z.HOSP_CODE      (+)= A.HOSP_CODE
//                                               AND Z.DOCTOR         (+)= A.DOCTOR
//                                             ORDER BY A.DOCTOR                 ";

                    fwkCommon.ParamList = new List<string>(new String[] { "f_gwa", "f_naewon_date", "f_find1"});
                   
                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", this.mHospCode);
                    fwkCommon.BindVarList.Add("f_gwa", this.grdJubsu.GetItemString(e.RowNumber, "gwa"));
                    fwkCommon.BindVarList.Add("f_naewon_date", this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));
                    fwkCommon.BindVarList.Add("f_ampm",
                        this.GetAMPMGubun(this.grdJubsu.GetItemString(e.RowNumber, "jubsu_time")));

                    fwkCommon.ExecuteQuery = xFindWorker_GetDoctor;

                    this.fwkCommon.ColInfos.Clear();
                    //this.fwkCommon.ColInfos.Add("ampm_gubun"     , "午前/午後", FindColType.String, 80, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("gwa", Resources.OUT1001U01_TEXT037, FindColType.String, 50, 0, true,
                        FilterType.No);
                    this.fwkCommon.ColInfos.Add("gwa_name", Resources.OUT1001U01_TEXT038, FindColType.String, 90, 0,
                        true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("doctor", Resources.OUT1001U01_TEXT039, FindColType.String, 70, 0, true,
                        FilterType.No);
                    this.fwkCommon.ColInfos.Add("doctor_name", Resources.OUT1001U01_TEXT040, FindColType.String, 110, 0,
                        true, FilterType.InitYes);
                    this.fwkCommon.ColInfos.Add("waiting_patient", Resources.OUT1001U01_TEXT041, FindColType.Number, 70,
                        0, true, FilterType.No);
                    this.fwkCommon.ColInfos.Add("total_patient", Resources.OUT1001U01_TEXT042, FindColType.Number, 70, 0,
                        true, FilterType.No);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;
                    this.fwkCommon.ColInfos[1].ColAlign = HorizontalAlignment.Center;
                    this.fwkCommon.ColInfos[2].ColAlign = HorizontalAlignment.Left;
                    this.fwkCommon.ColInfos[3].ColAlign = HorizontalAlignment.Left;
                    this.fwkCommon.ColInfos[4].ColAlign = HorizontalAlignment.Right;
                    this.fwkCommon.ColInfos[5].ColAlign = HorizontalAlignment.Right;

                    #endregion

                    break;
                case "gubun_name":

                case "gubun":

                    #region 보험종류

                    fwkCommon.AutoQuery = true;
                    fwkCommon.ServerFilter = false;

//                    fwkCommon.InputSQL = @"SELECT A.GUBUN
//                                                , B.GUBUN_NAME
//                                                , TO_CHAR(A.LAST_CHECK_DATE, 'YYYY/MM/DD')
//                                                , NVL(B.GONGBI_YN, 'N') GONGBI_YN
//                                             FROM BAS0210 B
//                                                , OUT0102 A
//                                            WHERE A.HOSP_CODE    = :f_hosp_code
//                                              AND A.BUNHO        = :f_bunho
//                                              AND NVL(:f_naewon_date, TRUNC(SYSDATE)) BETWEEN A.START_DATE AND A.END_DATE
//                                              AND B.HOSP_CODE    = A.HOSP_CODE
//                                              AND B.GUBUN        = A.GUBUN
//                                              AND NVL(:f_naewon_date, TRUNC(SYSDATE)) BETWEEN B.START_DATE AND B.END_DATE 
//                                              AND B.GUBUN_NAME   LIKE :f_find1 || '%'
//                                              AND A.START_DATE = (
//                                                                  SELECT MAX(AA.START_DATE) START_DATE
//                                                                    FROM OUT0102 AA
//                                                                   WHERE AA.HOSP_CODE = A.HOSP_CODE
//                                                                     AND AA.GUBUN = A.GUBUN
//                                                                     AND AA.BUNHO = A.BUNHO
//                                                                  )
//                                           ORDER BY A.GUBUN DESC
//                                         ";

                    fwkCommon.ParamList = new List<string>(new String[] { "f_bunho", "f_naewon_date", "f_find1" });

                    fwkCommon.BindVarList.Clear();
                    fwkCommon.BindVarList.Add("f_hosp_code", this.mHospCode);
                    fwkCommon.BindVarList.Add("f_bunho", this.grdJubsu.GetItemString(e.RowNumber, "bunho"));
                    fwkCommon.BindVarList.Add("f_naewon_date", this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));

                    fwkCommon.ExecuteQuery = xFindWorker_GetType;

                    this.fwkCommon.ColInfos.Clear();
                    this.fwkCommon.ColInfos.Add("gubun", Resources.OUT1001U01_TEXT043, FindColType.String, 80, 0, true,
                        FilterType.No);
                    this.fwkCommon.ColInfos.Add("gubun_name", Resources.OUT1001U01_TEXT044, FindColType.String, 200, 0,
                        true, FilterType.InitYes);
                    //this.fwkCommon.ColInfos.Add("last_check_date", "最終確認日", FindColType.Date, 90, 0, true, FilterType.No);
                    //this.fwkCommon.ColInfos.Add("gongbi_yn"      , "公費適用"   , FindColType.Date, 60, 0, true, FilterType.No);
                    this.fwkCommon.ColInfos[0].ColAlign = HorizontalAlignment.Center;

                    #endregion

                    break;
            }
        }

        #endregion

        #region 컬럼 벨리데이팅

        private void grdJubsu_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            string name = "";

            switch (e.ColName)
            {
                case "gwa":

                    #region 진료과

                    // 진료과 벨리데이션 체크
                    //     1. 해당과로 최종 내원한 의사를 검색
                    //     2. 해당과로 최종 내원한 보험을 검색
                    //     3. 초재진 체크

                    if (e.ChangeValue.ToString() == "")
                    {
                        // 진료과 클리어시  
                        // 의사코드도 같이 클리어
                        this.grdJubsu.SetItemValue(e.RowNumber, "gwa_name", "");
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor", "");
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor_name", "");

                        // 챠트과도 클리어
                        //this.grdJubsu.SetItemValue(e.RowNumber, "chart_gwa"  , "");
                        //this.grdJubsu.SetItemValue(e.RowNumber, "chart_gwa_name"  , "");

                        this.SetMsg("");

                        return;
                    }

                    name = IHIS.NURO.Methodes.GetGwaNameBAS0260(e.ChangeValue.ToString(),
                        this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));

                    if (name == "")
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko
                            ? "진료과가 정확하지않습니다. 확인바랍니다."
                            : Resources.OUT1001U01_TEXT045;
                        this.SetMsg(this.mMsg, MsgType.Error);
                        this.grdJubsu.SetItemValue(e.RowNumber, "gwa", "");
                        this.grdJubsu.SetItemValue(e.RowNumber, "gwa_name", "");

                        e.Cancel = true;
                        return;
                    }

                    this.grdJubsu.SetItemValue(e.RowNumber, "gwa_name", name); // 진료과 명칭 

                    // 1.최종내원한 의사검색
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string doctor =
                        IHIS.NURO.Methodes.GetRecentlyDoctor(this.grdJubsu.GetItemString(e.RowNumber, "bunho")
                            , this.grdJubsu.GetItemString(e.RowNumber, "gwa")
                            , this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));

                    if (this.DoctorCodeValidating(doctor) == true)
                    {
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor", doctor);
                    }

                    // 2.최종내원한 보험검색
                    //     첫번째 로우인경우 즉 첫 접수인경우는 아래로직에서 셋팅하고
                    //     접수건이 있는경우는 위의 보험정보로 셋팅한다.
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (e.RowNumber == 0)
                    {
                        string gubun = IHIS.NURO.Methodes.GetLastGubun(this.grdJubsu.GetItemString(e.RowNumber, "bunho")
                            , this.grdJubsu.GetItemString(e.RowNumber, "gwa")
                            , this.grdJubsu.GetItemString(e.RowNumber, "naewon_date"));

                        GetLastCheckDate(gubun);

                        // https://sofiamedix.atlassian.net/browse/MED-15883
                        //if (this.GubunValidating(gubun) == true)
                        //{
                        //    this.grdJubsu.SetItemValue(e.RowNumber, "gubun", gubun);
                        //}
                    }
                    else
                    {
                        // https://sofiamedix.atlassian.net/browse/MED-15883
                        //if (this.GubunValidating(this.grdJubsu.GetItemString(e.RowNumber - 1, "gubun")) == true)
                        //{
                        //    this.grdJubsu.SetItemValue(e.RowNumber, "gubun",
                        //        this.grdJubsu.GetItemString(e.RowNumber - 1, "gubun"));
                        //}
                    }

                    // 3.초재진 구분 로드
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string aChojae = string.Empty;

                    // TODO comment: use connect to cloud service
//                    ArrayList inputList = new ArrayList();
//                    ArrayList outpurList = new ArrayList();
//
//                    inputList.Add(this.grdJubsu.GetItemString(e.RowNumber, "naewon_date")); //I_DATE
//                    inputList.Add(this.grdJubsu.GetItemString(e.RowNumber, "bunho")); //I_BUNHO
//                    inputList.Add(this.grdJubsu.GetItemString(e.RowNumber, "gubun")); //I_GUBUN
//                    inputList.Add(e.ChangeValue.ToString()); //I_GWA
//                    inputList.Add(this.grdJubsu.GetItemString(e.RowNumber, "jubsu_no")); //I_JUBSU_NO
//                    if (!Service.ExecuteProcedure("PR_OUT_LOAD_CHECK_CHOJAE_JPN", inputList, outpurList))

                    // Connect to cloud service
                    NuroOUT1001U01LoadCheckChojaeJpnArgs args = new NuroOUT1001U01LoadCheckChojaeJpnArgs();
                    args.NaewonDate = this.grdJubsu.GetItemString(e.RowNumber, "naewon_date");
                    args.Bunho = this.grdJubsu.GetItemString(e.RowNumber, "bunho");
                    args.Gubun = this.grdJubsu.GetItemString(e.RowNumber, "gubun");
                    args.Gwa = e.ChangeValue.ToString();
                    args.JubsuNo = this.grdJubsu.GetItemString(e.RowNumber, "jubsu_no");
                    NuroOUT1001U01LoadCheckChojaeJpnResult result =
                        CloudService.Instance
                            .Submit<NuroOUT1001U01LoadCheckChojaeJpnResult, NuroOUT1001U01LoadCheckChojaeJpnArgs>(args);
 
                    if (result == null || result.ExecutionStatus != ExecutionStatus.Success)
                    {
                        //this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과가 정확하지않습니다. 확인바랍니다." : "初再診のチェック中にエラーが発生しました。ご確認ください。";

                        //this.SetMsg(this.mMsg, MsgType.Error);
                        XMessageBox.Show(Resources.OUT1001U01_TEXT046,
                            Resources.OUT1001U01_TEXT047, MessageBoxIcon.Warning);
                        return;
                    }

//                    aChojae = outpurList[0].ToString();
                    aChojae = result.ChojaeJpnItem.Chojae;
                    this.grdJubsu.SetItemValue(e.RowNumber, "chojae", aChojae);
                    //this.grdJubsu.SetItemValue(e.RowNumber, "cht_chojae", aChtChojae);

                    //gaJubsuGubun = this.GaJubsuGubunSetting(gaJubsuGubun);

                    //this.grdJubsu.SetItemValue(e.RowNumber, "ga_jubsu_gubun", TypeCheck.NVL(gaJubsuGubun,"0").ToString());

                    // 4.디폴트 값 셋팅
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //this.grdJubsu.SetItemValue(e.RowNumber, "chart_gwa", e.ChangeValue);
                    //this.grdJubsu.SetItemValue(e.RowNumber, "chart_gwa_name", this.grdJubsu.GetItemString(e.RowNumber, "gwa_name"));

                    if (this.grdJubsu.AcceptData() == false)
                    {
                        return;
                    }

                    #endregion

                    break;

                case "doctor":

                    #region 진료의

                    if (e.ChangeValue.ToString() == "")
                    {
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor", "");
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor_name", "");

                        this.SetMsg("");

                        return;
                    }

                    // 벨리데이션
                    if (this.DoctorCodeValidating(e.ChangeValue.ToString()) == false)
                    {
                        this.grdJubsu.SetItemValue(e.RowNumber, "doctor_name", "");
                        this.mMsg = NetInfo.Language == LangMode.Ko
                            ? "의사코드가 정확하지않습니다. 확인바랍니다."
                            : Resources.OUT1001U01_TEXT025;

                        this.SetMsg(this.mMsg, MsgType.Error);
                        e.Cancel = true;
                        return;
                    }

                    //this.grdJubsu.SetFocusToItem(e.RowNumber, "doctor_name", true);

                    #endregion

                    break;

                case "gubun":

                    #region 보험

                    // 보험정보 벨리데이션
                    //    1. 유효한 보험인지 체크 out0102 기준
                    //    2. 원외여부 기본값 셋팅
                    //    3. 공비적용가능여부 체크 (메세지)
                    //    4. 보험그리드 현재 보험 선택 
                    //    5. 최종확인일 체크

                    this.grdJubsu.SetFocusToItem(e.RowNumber, "gubun_name", true);
                    GetLastCheckDate(e.ChangeValue.ToString());

                    if (this.GubunValidating(e.ChangeValue.ToString()) == false)
                    {
                        this.mMsg = NetInfo.Language == LangMode.Ko ? "보험정보가 유효하지 않습니다." : Resources.OUT1001U01_TEXT026;
                        this.SetMsg(this.mMsg, MsgType.Error);
                        e.Cancel = true;
                        return;
                    }


                    #endregion

                    break;
            }
        }

        #endregion


        #region 로우 체인지

        private void grdJubsu_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            //this.SelectCurrentBoheomTab(grd.GetItemString(e.CurrentRow, "gubun"));

            // 그리드의 로우 스테이터스가 Added상태인 경우만
            // 공비선택 가능
            if (grd.GetRowState(e.CurrentRow) == DataRowState.Added)
            {
                //IHIS.NURO.Methodes.GetGubunName(grd.GetItemString(e.CurrentRow, "gubun"),grd.GetItemString(e.CurrentRow, "naewon_date"));

                if (grd.GetItemString(e.CurrentRow, "gubun") != "" &&
                    grd.GetItemString(e.CurrentRow, "naewon_date") != "")
                {
                    this.mGongbiYN = NURO.Methodes.ChkGetGongbiYN(grd.GetItemString(e.CurrentRow, "gubun"),
                        grd.GetItemString(e.CurrentRow, "naewon_date"));

                    //if (mBoheomInfo.GONGBI_YN != "N")
                    //{
                    //    this.grdGongBi.ReadOnly = false;
                    //}
                    //else
                    //{
                    //    this.grdGongBi.ReadOnly = true;
                    //}

                    if (mGongbiYN != "N")
                    {
                        this.grdGongBi.ReadOnly = false;
                    }
                    else
                    {
                        this.grdGongBi.ReadOnly = true;
                    }
                }
            }
            this.GetLastCheckDate(this.grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "gubun"));
        }

        #endregion

        #endregion

        #region 접수이력 그리드

        #region 셀 페인팅

        private void grdJubsuHistory_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            XEditGrid control = sender as XEditGrid;

            if (e.ColName == "naewon_date")
            {
                if (control.GetItemString(e.RowNumber, "sunnab_yn") == "Y")
                {
                    e.BackColor = this.mSunabBackColor.Color;
                }
            }

            // https://sofiamedix.atlassian.net/browse/MED-14579
            if (e.DataRow["sys_id"].ToString() == "MBS")
            {
                e.BackColor = Color.LightGreen;
            }         
            // https://sofiamedix.atlassian.net/browse/MED-14492
            if (control.GetItemString(e.RowNumber, "sys_id") == "MBSO")
            {
                e.BackColor = Color.LightYellow;
            }
        }

        #endregion

        #endregion

        #endregion

        #region PostCallMethod

        private void PostDoctorValidating(string aPostCallGubun)
        {
            switch (aPostCallGubun)
            {
                case "JubsuMagam":

                    this.OpenForm_DoctorJubsuCheckForm();

                    break;
            }
        }

        #endregion

        #region XTabPage

        //private void tabOUT0102_SelectionChanged(object sender, System.EventArgs e)
        //{
        //    IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;
        //    int rowNumber = 0;

        //    foreach (IHIS.X.Magic.Controls.TabPage tpg in control.TabPages)
        //    {
        //        if (tpg == control.SelectedTab)
        //        {
        //            tpg.ImageIndex = 9;

        //            if (TypeCheck.IsInt(((Hashtable)tpg.Tag)["row_number"].ToString()))
        //            {
        //                rowNumber = int.Parse(((Hashtable)tpg.Tag)["row_number"].ToString());
        //            }
        //            else
        //            {
        //                rowNumber = 0;
        //            }

        //            //this.grdBoheom.SetFocusToItem(rowNumber, "gubun");
        //        }
        //        else
        //        {
        //            tpg.ImageIndex = 10;
        //        }
        //    }
        //}

        #endregion

        #region XButton

        //// 보험등록창 열기 버튼
        //private void btnOUT0102U00_Click(object sender, System.EventArgs e)
        //{
        //    if (this.paBox.BunHo == "")
        //    {
        //        return;
        //    }

        //    this.OpenScreen_OUT0102U00();

        //    this.LoadOUT0102(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());
        //}

        private void btnGongbiInput_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                return;
            }

            this.OpenScreen_OUT0101U02();

            this.LoadOUT0105(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());
        }

        // 특기사항 열기 버튼
        private void btnOUT0106U00_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                return;
            }

            this.OpenScreen_OUT0106U00();

            this.LoadOUT0106(this.paBox.BunHo);
        }

        // 과별접수현황
        private void btnOUT1001Q04_Click(object sender, System.EventArgs e)
        {
            this.OpenScreen_OUT1001Q04(); //버튼 언비져블처리
        }

        // 입원내역
        private void btnINP1001Q00_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                return;
            }

            this.OpenScreen_INP1001Q02(); //버튼 언비져블처리
        }

        // 당일 접수 현황
        private void btnOUT1001Q01_Click(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                return;
            }

            this.OpenScreen_OUT1001Q01(); //버튼 언비져블처리
        }

        #endregion

        #region XCheckBox

        //// 최종 확인일 체크 
        //private void cbxLastCheck_CheckedChanged(object sender, System.EventArgs e)
        //{
        //    XCheckBox chkBox = sender as XCheckBox;

        //    if (chkBox.Checked == true)
        //    {
        //        this.dtpLastCheckDate.SetEditValue(WON.BizObj.GetSysDate());
        //        this.dtpLastCheckDate.AcceptData();
        //    }
        //}

        #endregion

        #region XDatePicker

        private void dtpNaewonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            //// 보험정보 로드
            //this.LoadOUT0102(this.paBox.BunHo, e.DataValue);

            // Change data gridGongBi and gridJubsu
            GetDataGridView(false);            

            // 공비정보 로드
            this.LoadOUT0105(this.paBox.BunHo, e.DataValue);

            // 접수 정보
            //this.LoadOUT1001(this.paBox.BunHo, e.DataValue);
            //this.grdJubsu.QueryLayout(false);

            //tungtx
            this.grdJubsu.setDataForGrid(lstJubsu);

            // 수진표 코맨트 
            this.LoadSujinRemark(this.paBox.BunHo, e.DataValue);
        }

        #endregion

        private void GetLastCheckDate(string gubun)
        {
            if (gubun != "")
            {
                this.layLastCheckDate.SetBindVarValue("f_hosp_code", this.mHospCode);
                this.layLastCheckDate.SetBindVarValue("f_gubun", gubun);
                this.layLastCheckDate.SetBindVarValue("f_bunho", this.paBox.BunHo);
                this.layLastCheckDate.SetBindVarValue("f_date", this.dtpNaewonDate.GetDataValue());

                this.layLastCheckDate.QueryLayout();
            }
        }

        #region grdFind Selected

        private string mGongbiYN = "";

        private void grdJubsu_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
        {
            switch (e.ColName)
            {
                case "gubun":
                    //this.grdJubsu.SetFocusToItem(e.RowNumber, "gubun_name", true);
                    //this.dtpLastCheckDate.SetDataValue(e.ReturnValues[2].ToString());
                    //this.mGongbiYN = e.ReturnValues[3].ToString();
                    break;

                    //case "doctor":
                    //    this.grdJubsu.SetFocusToItem(e.RowNumber, "doctor", true);
                    //    this.grdJubsu.SetItemValue(e.RowNumber, "doctor", e.ReturnValues[2].ToString());
                    //    this.grdJubsu.AcceptData();
                    //    this.grdJubsu.SetFocusToItem(e.RowNumber, "gubun", true);

                    //    break;

                default:
                    break;
            }
        }

        #endregion

        #region 저장로직

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private OUT1001U01 parent = null;

            public XSavePerformer(OUT1001U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdQry = null;

                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                //item.BindVarList.Add("f_Report_date", Convert.ToDateTime(parent.grdCSC1001.GetItemString(parent.grdCSC1001.CurrentRowNumber, "report_date"))

                if (callerID == '4')
                {
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                            break;

                        case DataRowState.Modified:
//                            cmdQry = @"UPDATE OUT0102
//									      SET UPD_ID           = :f_user_id
//									        , UPD_DATE         = SYSDATE
//									        , LAST_CHECK_DATE  = :f_last_check_date
//									    WHERE HOSP_CODE        = :f_hosp_code 
//                                          AND GUBUN            = :f_gubun
//									      AND BUNHO            = :f_bunho
//									      AND FROM_JY_DATE     = :f_from_jy_date";
                            break;

                        case DataRowState.Deleted:
                            break;
                    }
                }

                if (callerID == '8')
                {
//                    switch(item.RowState)
//                    {
//                        case DataRowState.Added:

//                        case DataRowState.Modified:
//                            cmdQry = @"BEGIN 
//									        UPDATE OUT1016 A 
//									           SET A.REMARK   = :f_remark
//									             , A.USER_ID  = :f_user_id
//									             , A.UPD_DATE = SYSDATE
//									         WHERE A.HOSP_CODE   = :f_hosp_code 
//                                               AND A.BUNHO       = :f_bunho
//									           AND A.NAEWON_DATE = :f_naewon_date 
//
//									        IF SQL%NOTFOUND THEN 
//									            INSERT INTO OUT1016 
//								                     ( SYS_DATE     , SYS_ID     , UPD_DATE      , UPD_ID
//								                     , HOSP_CODE    , BUNHO      , NAEWON_DATE   , REMARK   ) 
//									            VALUES
//									                 ( SYSDATE     , :f_user_id  , SYSDATE       , :f_user_id
//									                 , :f_hosp_code, :f_bunho    , :f_naewon_date, :f_remark ) 
//									        END IF; 
//									        END; ";

//                            cmdQry = cmdQry.Replace("\r", " ");
//                            break;

//                        case DataRowState.Deleted:
//                            break;
//                    }
                }
                return Service.ExecuteNonQuery(cmdQry, item.BindVarList);
            }
        }

        #endregion

        /// <summary>
        /// 환자 정보 등록
        /// </summary>
        private void OpenScreen_OUT0101U02()
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("bunho", this.paBox.BunHo);
            param.Add("date", this.dtpNaewonDate.GetDataValue());

            XScreen.OpenScreenWithParam(this, "NURO", "OUT0101U02", ScreenOpenStyle.ResponseFixed, param);
        }

        #region 공비 그리드

        #region 컬럼 ItemValueChanging

        private void grdGongBi_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "check")
            {
                if (e.ChangeValue.ToString() == "Y")
                {
                    this.AddGongbiCode(e.RowNumber, this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));
                        // 공비 우선순위 변경
                    //this.AddGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));//접수테이블에 삽입
                }
                else
                {
                    // 공비 우선순위 변경하고 접수그리드에서 삭제
                    this.DelGongbiCode(e.RowNumber, this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));
                    //this.DeleteGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));//접수테이블에서 삭제
                }
            }
            this.grdGongBi.AcceptData();

            //if (e.ChangeValue.ToString() == "Y")
            //{
            //    this.AddGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));
            //}
            //else
            //{
            //    this.DeleteGongbi(this.grdGongBi.GetItemString(e.RowNumber, "gongbi_code"));
            //}

        }

        #endregion

        #endregion

        #region 공비선택 관련

        //private void AddGongbi(string aGongbiCode, int cnt)
        //{
        //    int i = 0;
        //    // 해당 공비가 있으면 그냥 리턴
        //    for (i = 1; i <= 4; i++)
        //    {
        //        if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i.ToString()) == aGongbiCode)
        //        {
        //            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + i.ToString(), cnt);
        //            return;
        //        }
        //    }

        //    // 빈칸에 채워 넣는다
        //    for (i = 1; i <= 4; i++)
        //    {
        //        if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i.ToString()) == "")
        //        {
        //            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code" + i.ToString(), aGongbiCode);
        //            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + i.ToString(), cnt);
        //            return;
        //        }
        //    }
        //}

        private void AddGongbiCode(int nCnt, string aGongbiCode)
        {
            DataRow[] dtRow = this.grdGongBi.LayoutTable.Select("check =" + "'Y'");

            int cnt = dtRow.Length + 1;

            this.grdGongBi.SetItemValue(nCnt, "priority", cnt);

            int i = 0;
            // 해당 공비가 있으면 그냥 리턴
            for (i = 1; i <= 4; i++)
            {
                if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i) == aGongbiCode)
                {
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + i, cnt);
                    return;
                }
            }

            // 빈칸에 채워 넣는다
            for (i = 1; i <= 4; i++)
            {
                if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i) == "")
                {
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code" + i, aGongbiCode);
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + i, cnt);
                    return;
                }
            }
        }

        private void DelGongbiCode(int nCnt, string aGongbiCode)
        {
            //if (IsCheckedGongbiCode(aGongbiCode) < 0) return;
            int cnt = nCnt + 1;
            string str = this.grdGongBi.GetItemString(nCnt, "priority");
            DataRow[] dtRow = this.grdGongBi.LayoutTable.Select("priority > " + Int32.Parse(str));
            if (dtRow.Length > 0)
            {
                for (int i = 0; i < this.grdGongBi.RowCount; i++)
                {
                    int nPrior = Int32.Parse(this.grdGongBi.GetItemString(i, "priority"));
                    if (nPrior > Int32.Parse(str))
                    {
                        int num = nPrior - 1;
                        this.grdGongBi.SetItemValue(i, "priority", num);

                        for (int j = 1; j <= 4; j++)
                        {
                            if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + j) ==
                                aGongbiCode)
                            {
                                this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + j, num);
                            }
                        }
                    }
                }
            }
            this.grdGongBi.SetItemValue(nCnt, "priority", DBNull.Value);

            // 해당 공비가 있으면 삭제
            for (int i = 1; i <= 4; i++)
            {
                if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i) == aGongbiCode)
                {
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code" + i, "");
                    this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "priority" + i, "");
                    return;
                }
            }
        }

        //private void DeleteGongbi(string aGongbiCode)
        //{
        //    // 해당 공비가 있으면 삭제
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i.ToString()) == aGongbiCode)
        //        {
        //            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gongbi_code" + i.ToString(), "");
        //            return;
        //        }
        //    }
        //}

        private void DisplayGongbi()
        {
            // 그리드 로우 체인지 시
            // 해당 접수건에 선택된 공비를 
            // 화면에 디스플레이
            this.grdGongBi.ItemValueChanging -= new ItemValueChangingEventHandler(grdGongBi_ItemValueChanging);

            bool isFind = false;

            for (int j = 0; j < this.grdGongBi.RowCount; j++)
            {
                isFind = false;
                for (int i = 1; i <= 4; i++)
                {

                    if (this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gongbi_code" + i) ==
                        this.grdGongBi.GetItemString(j, "gongbi_code"))
                    {
                        isFind = true;
                    }
                }

                if (isFind)
                {
                    this.grdGongBi.SetItemValue(j, "check", "Y");
                }
                else
                {
                    this.grdGongBi.SetItemValue(j, "check", "N");
                }
            }

            this.grdGongBi.ItemValueChanging += new ItemValueChangingEventHandler(grdGongBi_ItemValueChanging);

        }

        #endregion
        // Comment: use connect server socket
        private void grdJubsu_QueryStarting(object sender, CancelEventArgs e)
        {
//            this.grdJubsu.SetBindVarValue("f_hosp_code", this.mHospCode);
//            this.grdJubsu.SetBindVarValue("f_naewon_date", this.dtpNaewonDate.GetDataValue());
//            this.grdJubsu.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
        // Comment: Use group proto 
        private void grdJubsu_QueryEnd(object sender, QueryEndEventArgs e)
        {
//            this.layGongbiCode.SetBindVarValue("f_hosp_code", this.mHospCode);
//
//            for (int i = 0; i < this.grdJubsu.RowCount; i++)
//            {
//                this.layGongbiCode.SetBindVarValue("f_pkout1001", this.grdJubsu.GetItemString(i, "pkout1001"));
//
//                this.layGongbiCode.QueryLayout();
//
//                this.grdJubsu.SetBindVarValue("gongbi_code1", this.layGongbiCode.GetItemValue("gongbi_code1").ToString());
//                this.grdJubsu.SetBindVarValue("gongbi_code2", this.layGongbiCode.GetItemValue("gongbi_code2").ToString());
//                this.grdJubsu.SetBindVarValue("gongbi_code3", this.layGongbiCode.GetItemValue("gongbi_code3").ToString());
//                this.grdJubsu.SetBindVarValue("gongbi_code4", this.layGongbiCode.GetItemValue("gongbi_code4").ToString());
//
//            }
//            this.grdJubsu.ResetUpdate();
        }

        private void grdJubsu_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {

            if (this.paBox.BunHo == "")
            {
                return;
            }

            this.OpenScreen_OUT0101U02();

            this.LoadOUT0105(this.paBox.BunHo, this.dtpNaewonDate.GetDataValue());
        }

        private void grdJubsu_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //if (e.DataRow["naewon_yn"].ToString() == "Y" || e.DataRow["naewon_yn"].ToString() == "E")
            if (e.DataRow["naewon_yn"].ToString() == "E")
            {
                e.Protect = true;
                return;
            }


            int selectedRow = e.RowNumber;

            //등록된 오더가 있는 지 확인
//            string cmdText = @"SELECT FN_OUT_CHECK_NAEWON_YN(:f_bunho, TO_DATE(:f_naewon_date, 'YYYY/MM/DD'),
//                                                                     :f_gwa  , :f_doctor, :f_naewon_type, :f_jubsu_no, :f_chojae) FROM SYS.DUAL
//                              ";
//            BindVarCollection bc = new BindVarCollection();
//            bc.Add("f_bunho", e.DataRow["bunho"].ToString());
//            bc.Add("f_naewon_date", e.DataRow["naewon_date"].ToString());
//            bc.Add("f_gwa", e.DataRow["gwa"].ToString());
//            bc.Add("f_doctor", e.DataRow["doctor"].ToString());
//            bc.Add("f_naewon_type", e.DataRow["naewon_type"].ToString());
//            bc.Add("f_jubsu_no", e.DataRow["jubsu_no"].ToString());
//            bc.Add("f_chojae", e.DataRow["chojae"].ToString());
//            object ret = Service.ExecuteScalar(cmdText, bc);
//            string naewonYN = "N";
//
//            if (!TypeCheck.IsNull(ret))
//            {
//                naewonYN = ret.ToString();
//            }

            // Connect to cloud service
            NuroOUT1001U01CheckNaewonYnArgs args = new NuroOUT1001U01CheckNaewonYnArgs();
            args.Bunho = this.paBox.BunHo;
            args.NaewonDate = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_date");
            args.Gwa = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "gwa");
            args.Doctor = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "doctor");
            args.NaewonType = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "naewon_type");
            args.OldJubsuNo = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "jubsu_no");
            args.Chojae = this.grdJubsu.GetItemString(grdJubsu.CurrentRowNumber, "chojae");

            NuroOUT1001U01CheckNaewonYnResult checkNaewonYnResult =
                CloudService.Instance.Submit<NuroOUT1001U01CheckNaewonYnResult, NuroOUT1001U01CheckNaewonYnArgs>
                    (args);

            string naewonYN = "N";

            if (checkNaewonYnResult != null && checkNaewonYnResult.ExecutionStatus == ExecutionStatus.Success)
            {
                naewonYN = checkNaewonYnResult.ValueCheckNaewon;
            }

            
            //if (naewonYN == "Y")
            //{
            //    this.mMsg = NetInfo.Language == LangMode.Ko ? "진료과에서 내원확인이 되었으므로 수정할 수 없습니다. 진료과로 문의 하십시오." : "診療科で来院確認がされたので修正できません。\r\n診療科にお問合せください。";
            //    this.mCap = NetInfo.Language == LangMode.Ko ? "외래접수" : "外来受付";

            //    XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else 
            // comment : MED-7837
            //if (naewonYN == "O")
            //{
            //    string mMsg = Resources.OUT1001U01_TEXT048;
            //    string mCap = Resources.OUT1001U01_TEXT047;

            //    e.Protect = true;
            //    XMessageBox.Show(mMsg, mCap, MessageBoxIcon.Warning);
            //    return;
            //}


            if (e.ColName == "check_naewon")
            {
                if (e.DataRow["reser_yn"].ToString() != "Y" && e.DataRow["naewon_type"].ToString() != "1")
                {
                    if (e.DataRow.RowState != DataRowState.Added)
                    {
                        e.Protect = true;
                        XMessageBox.Show(Resources.OUT1001U01_TEXT049, Resources.OUT1001U01_TEXT050,
                            MessageBoxIcon.Information);

                    }
                }
            }
        }

        private void grdGongBi_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //if (grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "naewon_yn") == "Y" ||
            //    grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "naewon_yn") == "E")
            if (grdJubsu.GetItemString(this.grdJubsu.CurrentRowNumber, "naewon_yn") == "E")
            {
                e.Protect = true;
            }
        }

        private void txtBunho_DataValidating(object sender, DataValidatingEventArgs e)
        {
            //날짜,시간 초기화
            SetDate();

            if (e.DataValue != "")
            {
                string bunho = BizCodeHelper.GetStandardBunHo(e.DataValue);
                this.paBox.SetPatientID(bunho);
                //this.txtBunho.Text = bunho;
                this.txtBunho.Focus();
            }
            else
            {
                this.paBox.Reset();
                this.btnList.PerformClick(FunctionType.Query);
            }
        }

        private void txtBunho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyData == Keys.Tab)
            {
                if (this.grdJubsu.RowCount > 0)
                {
                    if (this.grdJubsu.CurrentRowNumber > -1)
                    {
                        this.grdJubsu.SelectRow(this.grdJubsu.CurrentRowNumber);
                        this.grdJubsu.SetFocusToItem(this.grdJubsu.CurrentRowNumber, "gwa", true);

                    }
                    else
                    {
                        this.grdJubsu.SelectRow(this.grdJubsu.RowCount - 1);
                        this.grdJubsu.SetFocusToItem(this.grdJubsu.RowCount - 1, "gwa", true);
                    }
                }
            }
        }

        private void emkJubsuTime_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "jubsu_time", this.emkJubsuTime.GetDataValue());
        }

        private void OUT1001U01_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsSaveSuccess)
            {
                e.Cancel = true;
            }
            mIsSaveSuccess = true;
        }

        private void grdJubsu_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["reser_yn"].ToString() == "Y")
            {
                // https://sofiamedix.atlassian.net/browse/MED-14579
                if (e.DataRow["sys_id"].ToString() == "MBS")
                {
                    e.BackColor = Color.LightGreen;
                }
            }
            else if (e.DataRow["naewon_type"].ToString() == "1")
            {
                e.BackColor = Color.Pink;
            }

            // https://sofiamedix.atlassian.net/browse/MED-14492
            if (e.DataRow["sys_id"].ToString() == "MBSO")
            {
                e.BackColor = Color.LightYellow;
            }

            //if (e.DataRow["naewon_yn"].ToString() == "Y" || e.DataRow["naewon_yn"].ToString() == "E")
            if (e.DataRow["naewon_yn"].ToString() == "E")
            {
                e.BackColor = Color.LightBlue;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            CommonItemCollection printOpen = new CommonItemCollection();

            if (this.grdJubsu.RowCount > 0)
            {
                if (this.grdJubsu.CurrentRowNumber >= 0)
                {
                    int ended_cnt = 0;
                    int group_key_cnt1 = 0;
                    int group_key_cnt2 = 0;
                    int naewon_cnt = 0;

                    foreach (DataRow row in this.grdJubsu.LayoutTable.Rows)
                    {
                        if (row["naewon_yn"].ToString() == "E")
                            ended_cnt++;

                        if (row["group_key"].ToString() == "1")
                            group_key_cnt1++;

                        if (row["group_key"].ToString() == "2")
                            group_key_cnt2++;

                        if (row["check_naewon"].ToString() == "Y")
                            naewon_cnt++;
                    }

                    if (ended_cnt == this.grdJubsu.RowCount)
                    {
                        XMessageBox.Show(Resources.OUT1001U01_TEXT051, Resources.OUT1001U01_TEXT019,
                            MessageBoxIcon.Warning);
                        return;
                    }
                    //if (this.grdPatientList.GetItemString(this.grdPatientList.CurrentRowNumber, "order_end_yn") == "Y")
                    //{
                    //    XMessageBox.Show("診療終了されましたので、受診票発行できません。", "診療終了", MessageBoxIcon.Warning);
                    //    return;
                    //}

                    if (naewon_cnt < 1)
                    {
                        XMessageBox.Show(Resources.OUT1001U01_TEXT052, Resources.OUT1001U01_TEXT053,
                            MessageBoxIcon.Information);
                        return;
                    }

                    //수진표 뽑을 수 있는 접수구분이 없을 때
                    if (group_key_cnt1 < 1 && group_key_cnt2 < 1)
                    {
                        XMessageBox.Show(Resources.OUT1001U01_TEXT054, Resources.OUT1001U01_TEXT055,
                            MessageBoxIcon.Information);
                        return;
                    }

                    IXScreen aScreen = XScreen.FindScreen("NURO", "OUT1001R01");
                    if (aScreen == null)
                    {
                        printOpen.Add("auto_close", true);
                    }
                    else
                    {
                        aScreen.Command("Close", new CommonItemCollection());
                        printOpen.Add("auto_close", false);
                    }

                    printOpen.Add("naewon_date", this.dtpNaewonDate.GetDataValue());
                    printOpen.Add("bunho", this.paBox.BunHo);

                    IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "OUT1001R01", ScreenOpenStyle.PopUpFixed,
                        printOpen);
                }
            }

        }

        private void OUT1001U01_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.btnPrint.PerformClick();
            }
        }

        private void grdJubsu_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            switch (e.ColName)
            {
                case "check_naewon":
                    if (e.ChangeValue.ToString() == "N")
                    {
                        this.grdJubsu.SetItemValue(e.RowNumber, "arrive_time", "");
                    }
                    else
                    {
                        this.grdJubsu.SetItemValue(e.RowNumber, "arrive_time",
                            EnvironInfo.GetSysDateTime().ToString("HHmm"));
                    }
                    break;


                case "jubsu_gubun":

                    this.layGroupKey.SetBindVarValue("f_code", e.ChangeValue.ToString());
                    this.layGroupKey.QueryLayout();
                    this.grdJubsu.SetItemValue(e.RowNumber, "group_key", layGroupKey.GetItemValue("group_key"));

                    break;

            }
        }

        private void layGroupKey_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGroupKey.SetBindVarValue("f_hosp_code", this.mHospCode);
        }
        private void OUT1001U01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (e.OpenParam != null)
            {
                if (e.OpenParam.Contains("f_bunho"))
                {
                    txtBunho.Text = e.OpenParam["f_bunho"].ToString();
                    this.paBox.SetPatientID(txtBunho.Text);
                }
            }
        }

        #region GetDataForCbo

        private IList<object[]> xEditGridCell29_GetDataForCbo(BindVarCollection bindVarCollection)
        {
            InitializeComboListItemResult result = initializeComboListItem();
            IList<object[]> lstDataChojae = createListDataForCombo(result.ComboChojaeItem);
            return lstDataChojae;
        }
        private IList<object[]> xEditGridCell56_GetDataForCbo(BindVarCollection bindVarCollection)
        {
            InitializeComboListItemResult result = initializeComboListItem();
            IList<object[]> lstDataComboType = createListDataForCombo(result.ComboTypeItem);
            //lstDataComboType.RemoveAt(0);
            return lstDataComboType;
        }
        
        private void grdJubsu_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell29.ExecuteQuery = xEditGridCell29_GetDataForCbo;
            this.xEditGridCell56.ExecuteQuery = xEditGridCell56_GetDataForCbo;
            this.xEditGridCell18.ExecuteQuery = xEditGridCell29_GetDataForCbo;
        }

        #endregion

        #region Last check date

        private List<string> layLastCheckDate_CreateParam()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_gubun");
            lstParam.Add("f_bunho");
            lstParam.Add("f_date");
            return lstParam;
        }

        private IList<object[]> layLastCheckDate_GetLastCheckDate(BindVarCollection varCollection)
        {
            IList<object[]> lstDataResult = new List<object[]>();
            NuroOUT1001U01LayLastCheckDateArgs args =
                new NuroOUT1001U01LayLastCheckDateArgs(varCollection["f_gubun"].VarValue,
                    varCollection["f_bunho"].VarValue,
                    varCollection["f_date"].VarValue);

            NuroOUT1001U01LayLastCheckDateResult checkDateResult =
                CloudService.Instance
                    .Submit<NuroOUT1001U01LayLastCheckDateResult, NuroOUT1001U01LayLastCheckDateArgs>(args);
            if (checkDateResult != null)
            {
//	            valueDate = checkDateResult.LastCheckDate;
                object[] objValueDate =
                {
                    checkDateResult.LastCheckDate
                };
                lstDataResult.Add(objValueDate);
            }
            return lstDataResult;
        }
        
        #endregion

        #region Layout Group Type

        private List<string> layGroupKey_CreateParam()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_code");
            return lstParam;
        }

        private IList<object[]> layGroupKey_GetGroupTypeInfo(BindVarCollection varCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetGroupKeyArgs args = new NuroOUT1001U01GetGroupKeyArgs("JUBSU_GUBUN", varCollection["f_code"].VarValue);
            NuroOUT1001U01GetGroupKeyResult groupKeyResult =
                CloudService.Instance.Submit<NuroOUT1001U01GetGroupKeyResult, NuroOUT1001U01GetGroupKeyArgs>(args);
            if (groupKeyResult != null)
            {
                List<NuroOUT1001U01GetGroupKeyInfo> LstGetGroupKeyItem = groupKeyResult.GetGroupKeyItem;
                if (LstGetGroupKeyItem != null && LstGetGroupKeyItem.Count > 0)
                {
                    foreach (NuroOUT1001U01GetGroupKeyInfo groupKeyInfo in LstGetGroupKeyItem)
                    {
                        object[] objGroupKeyInfo =
                        {
                            groupKeyInfo.GroupKey
                        };
                        lstResult.Add(objGroupKeyInfo);
                    }
                }
            }
            return lstResult;
        }
        #endregion

        #region Layout gongbi code

        private List<string> layGongbiCode_CreateParam()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_pkout1001");
            return lstParam;
        }

        #endregion

        #region xFindWorker

        private IList<object[]> xFindWorker_GetDepartment(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetDepartmentArgs args = new NuroOUT1001U01GetDepartmentArgs(bindVarCollection["f_buseo_ymd"].VarValue, bindVarCollection["f_find1"].VarValue, "1");
            NuroOUT1001U01GetDepartmentResult result = CacheService.Instance.Get<NuroOUT1001U01GetDepartmentArgs, NuroOUT1001U01GetDepartmentResult>(args);
            //NuroOUT1001U01GetDepartmentResult result = CloudService.Instance.Submit<NuroOUT1001U01GetDepartmentResult, NuroOUT1001U01GetDepartmentArgs>(args);
            if (result != null)
            {
                IList<NuroOUT1001U01GetDepartmentInfo> lstDepartmentInfo = result.DeptItem;
                if (lstDepartmentInfo != null && lstDepartmentInfo.Count > 0)
                {
                    foreach (NuroOUT1001U01GetDepartmentInfo deptInfo in lstDepartmentInfo)
                    {
                        object[] objDeptInfo =
                        {
                            deptInfo.Gwa,
                            deptInfo.GwaName
                        };
                        lstResult.Add(objDeptInfo);
                    }
                    
                }
            }
            return lstResult;
        }
        
        private IList<object[]> xFindWorker_GetDoctor(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetDoctorArgs args = new NuroOUT1001U01GetDoctorArgs(bindVarCollection["f_naewon_date"].VarValue, bindVarCollection["f_gwa"].VarValue, bindVarCollection["f_find1"].VarValue);
            NuroOUT1001U01GetDoctorResult result =
                CloudService.Instance.Submit<NuroOUT1001U01GetDoctorResult, NuroOUT1001U01GetDoctorArgs>(args);
            if (result != null)
            {
                IList<NuroOUT1001U01GetDoctorInfo> listDoctorInfo = result.DoctorItem;
                if (listDoctorInfo != null && listDoctorInfo.Count > 0)
                {
                    foreach (NuroOUT1001U01GetDoctorInfo doctorInfo in listDoctorInfo)
                    {
                        object[] objDoctorInfo =
                        {
                            doctorInfo.Gwa,
                            doctorInfo.GwaName,
                            doctorInfo.Doctor, 
                            doctorInfo.DoctorName,
                            doctorInfo.WaitingPatient,
                            doctorInfo.TotalPatient
                        };
                        lstResult.Add(objDoctorInfo);
                    }
                    
                }
            }
            return lstResult;
        }
        
        private IList<object[]> xFindWorker_GetType(BindVarCollection bindVarCollection)
        {
            IList<object[]> lstResult = new List<object[]>();
            NuroOUT1001U01GetTypeArgs args = new NuroOUT1001U01GetTypeArgs(bindVarCollection["f_naewon_date"].VarValue, bindVarCollection["f_bunho"].VarValue, bindVarCollection["f_find1"].VarValue);
            NuroOUT1001U01GetTypeResult result = CacheService.Instance.Get<NuroOUT1001U01GetTypeArgs, NuroOUT1001U01GetTypeResult>(args);
            //NuroOUT1001U01GetTypeResult result =
            //    CloudService.Instance.Submit<NuroOUT1001U01GetTypeResult, NuroOUT1001U01GetTypeArgs>(args);
            if (result != null)
            {
                IList<NuroOUT1001U01GetTypeInfo> listTypeInfo = result.TypeItem;
                if (listTypeInfo != null && listTypeInfo.Count > 0)
                {
                    foreach (NuroOUT1001U01GetTypeInfo type in listTypeInfo)
                    {
                        object[] objTypeInfo =
                        {
                            type.Gubun,
                            type.GubunName,
                            type.LastCheckDate,
                            type.GongbiYn
                        };
                        lstResult.Add(objTypeInfo);
                    }
                }
            }
            return lstResult;
        }
        #endregion

//        #region Create Param List
//        private List<string> CreateParamList()
//        {
//            List<string> lstParam = new List<string>();
//            lstParam.Add("f_naewon_date");
//            lstParam.Add("f_bunho");
//            return lstParam;
//        }
//        #endregion
//
        #region Connect cloud 
//        private IList<object[]> grdJubsu_GetData(BindVarCollection bindVarCollection)
//        {
//            IList<object[]> lstResult = new List<object[]>();
//
//            NuroPatientDetailListArgs detailListArgs = new NuroPatientDetailListArgs(bindVarCollection["f_bunho"].VarValue, bindVarCollection["f_naewon_date"].VarValue);
//            NuroPatientDetailListResult nuroPatientDetailListResult =
//                CloudService.Instance.Submit<NuroPatientDetailListResult, NuroPatientDetailListArgs>(
//                    detailListArgs);
//            if (nuroPatientDetailListResult != null)
//            {
//                IList<NuroPatientDetailListItemInfo> lstDetailListItemInfo =
//                    nuroPatientDetailListResult.PatientDetailListItem;
//                if (lstDetailListItemInfo != null && lstDetailListItemInfo.Count > 0)
//                {
//                    Console.WriteLine("size: " + lstDetailListItemInfo.Count);
//                    foreach (NuroPatientDetailListItemInfo detailListItemInfo in lstDetailListItemInfo)
//                    {
//                        object[] detailListItem =
//	                    {
//	                        detailListItemInfo.DepartmentCode,
//	                        detailListItemInfo.DepartmentName,
//	                        detailListItemInfo.DoctorCode,
//	                        detailListItemInfo.DoctorName,
//	                        detailListItemInfo.ExamStatus,
//	                        detailListItemInfo.ReceptionNo,
//	                        detailListItemInfo.InsurCode,
//	                        detailListItemInfo.InsurName,
//	                        detailListItemInfo.PatientCode,
//	                        detailListItemInfo.ComingDate,
//	                        detailListItemInfo.Pkout1001,
//	                        detailListItemInfo.ReceptionTime,
//	                        detailListItemInfo.ComingStatus,
//	                        detailListItemInfo.ComingType,
//	                        detailListItemInfo.SunnabStatus,
//	                        detailListItemInfo.Fkinp1001,
//	                        detailListItemInfo.ReceptionType,
//	                        detailListItemInfo.InpTransStatus,
//	                        detailListItemInfo.Bigo,
//	                        detailListItemInfo.InsurCode1,
//	                        detailListItemInfo.InsurCode2,
//	                        detailListItemInfo.InsurCode3,
//	                        detailListItemInfo.InsurCode4,
//	                        detailListItemInfo.Priority1,
//	                        detailListItemInfo.Priority2,
//	                        detailListItemInfo.Priority3,
//	                        detailListItemInfo.Priority4,
//	                        detailListItemInfo.SujinNo,
//	                        detailListItemInfo.WonyoiOrderStatus,
//	                        detailListItemInfo.ReserStatus,
//	                        detailListItemInfo.Button,
//	                        detailListItemInfo.CheckComing,
//	                        detailListItemInfo.ArriveTime,
//	                        detailListItemInfo.GroupKey,
//	                        detailListItemInfo.ContKey
//	                    };
//                        lstResult.Add(detailListItem);
//                    }
//                }
//            }
//            return lstResult;
//        }

        private InitializeComboListItemResult initializeComboListItem()
        {
            InitializeComboListItemArgs args = new InitializeComboListItemArgs();
            args.CodeType = "JUBSU_GUBUN";
            args.CodeTypeChojae = "CHOJAE";

            InitializeComboListItemResult result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args);
            return result;
        }

        private void GetDataGridView(bool ChangeComingDate)
        {
            try
            {
                NuroPatientGridViewArgs args = new NuroPatientGridViewArgs();
                args.PatientCode = this.paBox.BunHo;
                args.ComingDate = this.dtpNaewonDate.GetDataValue();
                // If ChangeComingDate = true Get all data for grid
                // Else get data for gridGongbi and gridJupsu
                args.ChangeComingDate = ChangeComingDate; 
                NuroPatientGridViewResult result =
                        CloudService.Instance.Submit<NuroPatientGridViewResult, NuroPatientGridViewArgs>(args);
                if (result != null)
                {
                    gridComment_CreateData(result.GrdCommentList);

                    lstInsurance_CreateData(result.GrdGongbiCodeList);

                    gridHistory_CreateData(result.GrdJubsuHistoryList);

                    grdJubsu_CreateData(result.GrdJubsuList);
                }
            }
            catch (Exception)
            {

                XMessageBox.Show("NuroPatientGridView:  Query Error");
                return;
            }
            

        }

        private void grdJubsu_CreateData(List<NuroPatientDetailListItemInfo> patientDetailResult)
        {

            lstJubsu = new List<object[]>();
            if (patientDetailResult != null)
            {   
                foreach (NuroPatientDetailListItemInfo detailInfo in patientDetailResult)
                {
                    object[] objDetailInfo =
                        {
                            detailInfo.DepartmentCode,
                            detailInfo.DepartmentName,
                            detailInfo.DoctorCode,
                            detailInfo.DoctorName,
                            detailInfo.ExamStatus,
                            detailInfo.ReceptionNo,
                            detailInfo.InsurCode,
                            detailInfo.InsurName,
                            detailInfo.PatientCode,
                            detailInfo.ComingDate,
                            detailInfo.Pkout1001,
                            detailInfo.ReceptionTime,
                            detailInfo.ComingStatus,
                            detailInfo.ComingType,
                            detailInfo.SunnabStatus,
                            detailInfo.Fkinp1001,
                            detailInfo.ReceptionType,
                            detailInfo.InpTransStatus,
                            detailInfo.Bigo,
                            detailInfo.InsurCode1,
                            detailInfo.InsurCode2,
                            detailInfo.InsurCode3,
                            detailInfo.InsurCode4,
                            detailInfo.Priority1,
                            detailInfo.Priority2,
                            detailInfo.Priority3,
                            detailInfo.Priority4,
                            detailInfo.SujinNo,
                            detailInfo.WonyoiOrderStatus,
                            detailInfo.ReserStatus,
                            detailInfo.Button,
                            detailInfo.CheckComing,
                            detailInfo.ArriveTime,
                            detailInfo.GroupKey,
                            detailInfo.ContKey,
                            // https://sofiamedix.atlassian.net/browse/MED-14492
                            detailInfo.SysId,
                        };
                    lstJubsu.Add(objDetailInfo);
                }

            }
        }
        private void gridHistory_CreateData(List<NuroPatientReceptionHistoryListItemInfo> historyResult)
        {
            lstHistory = new List<object[]>();
            if (historyResult != null)
            {
                foreach (NuroPatientReceptionHistoryListItemInfo historyInfo in historyResult)
                {
                    object[] objHistoryInfo =
                        {
                            historyInfo.ComingDate,
                            historyInfo.ExamDate,
                            historyInfo.ExamTime,
                            historyInfo.DepartmentCode,
                            historyInfo.Doctor,
                            historyInfo.InsurType,
                            historyInfo.SunnabStatus,
                            historyInfo.ExamStatus,
                            historyInfo.ComingStatus,
                            historyInfo.PatientCode,
                            historyInfo.ReceptionTime,
                            historyInfo.DepartmentName,
                            historyInfo.SujinNo,
                            historyInfo.DokuStatus,
                            historyInfo.ContKey,
                            // https://sofiamedix.atlassian.net/browse/MED-14492
                            historyInfo.SysId,
                        };
                    lstHistory.Add(objHistoryInfo);
                }
            }
        }
        private void lstInsurance_CreateData(List<NuroPatientInsuranceListItemInfo> insuranceResult)
        {
            lstInsurance = new List<object[]>();
            if (insuranceResult != null)
            {
                foreach (NuroPatientInsuranceListItemInfo insuranceInfo in insuranceResult)
                {
                    object[] objInsuranceInfo =
                        {
                            insuranceInfo.Status,
                            insuranceInfo.InsurCode,
                            insuranceInfo.InsurName,
                            insuranceInfo.LastCheckDate,
                            insuranceInfo.StartDate,
                            insuranceInfo.PatientCode,
                            insuranceInfo.BudamjaPatientCode,
                            insuranceInfo.InsurJiyeok
                        };
                    lstInsurance.Add(objInsuranceInfo);
                }
            }
        }
        private void gridComment_CreateData(List<NuroPatientCommentListItemInfo> patientCommentResult)
        {
            lstComment = new List<object[]>();
            if (patientCommentResult != null && patientCommentResult.Count > 0)
            {
                foreach (NuroPatientCommentListItemInfo commentInfo in patientCommentResult)
                {
                    object[] objCommentInfo =
                        {
                            commentInfo.Comment,
                            commentInfo.Ser,
                            commentInfo.PatientCode,
                            commentInfo.ContKey,
                        };
                    lstComment.Add(objCommentInfo);
                }
            }
        }

        private IList<object[]> createListDataForCombo(IList<ComboListItemInfo> lstComboDept)
        {
            IList<object[]> lstData = new List<object[]>();
            if (lstComboDept != null && lstComboDept.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }

        #endregion       

        #region https://sofiamedix.atlassian.net/browse/MED-15749

        private void SetDefaultGubun()
        {
            OUT1001U01GetGubunArgs args = new OUT1001U01GetGubunArgs();
            args.Bunho = paBox.BunHo;
            OUT1001U01GetGubunResult res = CloudService.Instance.Submit<OUT1001U01GetGubunResult, OUT1001U01GetGubunArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.GubunItem.Count == 1)
            {
                grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun", res.GubunItem[0].Gubun);
                grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun_name", res.GubunItem[0].GubunName);
            }
            else
            {
                grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun", "");
                grdJubsu.SetItemValue(grdJubsu.CurrentRowNumber, "gubun_name", "");
            }
        }

        #endregion
    }
}