#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
    /// <summary>
    /// NUR1020Q00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR1020Q00 : IHIS.Framework.XScreen
    {
        #region 추가사항
        private string sysid = string.Empty;
        private string screen = string.Empty;
        private int fkinp1001 = 0;
        private int paListRownum = 0;
        private string jaewon_yn = "Y";
        #endregion

        #region 자동생성
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlFill;
        private IHIS.NURI.GraphControl graphCont;
        private IHIS.Framework.XMatrix matrix;
        private IHIS.Framework.XLabel lblYmd;
        private IHIS.Framework.XDatePicker dtpYmd;
        private System.Windows.Forms.Panel pnlTopLeft;
        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.MultiLayout layIO;
        private IHIS.Framework.MultiLayout layNut;
        private IHIS.Framework.MultiLayout layGraph;
        private IHIS.Framework.XButton btnRecord7;
        private IHIS.Framework.XButton btnRecord6;
        private IHIS.Framework.XButton btnRecord5;
        private IHIS.Framework.XButton btnRecord4;
        private IHIS.Framework.XButton btnRecord3;
        private IHIS.Framework.XButton btnRecord2;
        private IHIS.Framework.XButton btnRecord1;
        private IHIS.Framework.XButton btnBeforeWeek;
        private IHIS.Framework.XButton btnPrev;
        private IHIS.Framework.XButton btnAfterWeek;
        private IHIS.Framework.XButton btnNext;
        private IHIS.Framework.XButton btnDisplay;
        private IHIS.Framework.XButton btnCall;
        private IHIS.Framework.XPanel pnlNut1_1;
        private IHIS.Framework.XPanel pnlNut1_2;
        private IHIS.Framework.XPanel pnlNut1_3;
        private IHIS.Framework.XPanel pnlNut2_1;
        private IHIS.Framework.XPanel pnlNut2_2;
        private IHIS.Framework.XPanel pnlNut2_3;
        private IHIS.Framework.XPanel pnlNut3_1;
        private IHIS.Framework.XPanel pnlNut3_2;
        private IHIS.Framework.XPanel pnlNut3_3;
        private IHIS.Framework.XPanel pnlNut4_1;
        private IHIS.Framework.XPanel pnlNut4_2;
        private IHIS.Framework.XPanel pnlNut4_3;
        private IHIS.Framework.XPanel pnlNut5_1;
        private IHIS.Framework.XPanel pnlNut5_2;
        private IHIS.Framework.XPanel pnlNut5_3;
        private IHIS.Framework.XPanel pnlNut6_1;
        private IHIS.Framework.XPanel pnlNut6_2;
        private IHIS.Framework.XPanel pnlNut6_3;
        private IHIS.Framework.XPanel pnlNut7_1;
        private IHIS.Framework.XPanel pnlNut7_2;
        private IHIS.Framework.XPanel pnlNut7_3;
        private IHIS.Framework.XButton btnPrint;
        private IHIS.Framework.MultiLayout laySusulInfo;
        private IHIS.Framework.MultiLayout layInOutTotal;
        private IHIS.Framework.XLabel lbJaewonil;
        private IHIS.Framework.XButton btnJuengsang1;
        private IHIS.Framework.XButton btnJuengsang2;
        private IHIS.Framework.XButton btnJuengsang3;
        private IHIS.Framework.XButton btnJuengsang4;
        private IHIS.Framework.XButton btnJuengsang5;
        private IHIS.Framework.XButton btnJuengsang6;
        private IHIS.Framework.XButton btnJuengsang7;
        private IHIS.Framework.MultiLayout layFlagQuery;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem12;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private SingleLayout layIpwonInfo;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayout laySiksaNote;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayout layQueryRemark;
        private SingleLayoutItem singleLayoutItem5;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayout layNUR1122;
        private MultiLayout layNUR1122List;
        private XButton btnKeika;
        private XButton btnKango;
        private XButton btnChiryo;
        private XButton btnTento;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayout layNUR7002;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem34;
        private XBuseoCombo cboHo_dong;
        private XLabel lblHo_dong;
        private XPanel pnlLeft;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell41;
        private XLabel xLabel6;
        private XCheckBox cbxD;
        private XCheckBox cbxC;
        private XCheckBox cbxB;
        private XCheckBox cbxA;
        private XButton btnNextPatient;
        private XPanel pnlSession;
        #endregion
        private XToolTip ToolTip;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private XPanel pnlComment;
        private XTextBox txtComment;
        private XButton btnComment;
        private XPanel xPanel3;
        private XButton btnSaveComment;
        private MultiLayout layConment;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem33;
        private MultiLayoutItem multiLayoutItem41;
        private XLabel lblHistory;
        private SingleLayoutItem singleLayoutItem6;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem36;
        private MultiLayoutItem multiLayoutItem37;
        private MultiLayoutItem multiLayoutItem38;
        private MultiLayoutItem multiLayoutItem39;
        private MultiLayoutItem multiLayoutItem40;
        private MultiLayoutItem multiLayoutItem48;
        private MultiLayoutItem multiLayoutItem49;

        private IContainer components;

        #region 생성자
        public NUR1020Q00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1020Q00));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlTopLeft = new System.Windows.Forms.Panel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.lbJaewonil = new IHIS.Framework.XLabel();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.lblYmd = new IHIS.Framework.XLabel();
            this.dtpYmd = new IHIS.Framework.XDatePicker();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnComment = new IHIS.Framework.XButton();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.btnTento = new IHIS.Framework.XButton();
            this.btnKango = new IHIS.Framework.XButton();
            this.btnChiryo = new IHIS.Framework.XButton();
            this.btnKeika = new IHIS.Framework.XButton();
            this.btnPrint = new IHIS.Framework.XButton();
            this.btnCall = new IHIS.Framework.XButton();
            this.btnDisplay = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.graphCont = new IHIS.NURI.GraphControl();
            this.pnlComment = new IHIS.Framework.XPanel();
            this.txtComment = new IHIS.Framework.XTextBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnSaveComment = new IHIS.Framework.XButton();
            this.matrix = new IHIS.Framework.XMatrix();
            this.btnJuengsang7 = new IHIS.Framework.XButton();
            this.btnJuengsang6 = new IHIS.Framework.XButton();
            this.btnJuengsang5 = new IHIS.Framework.XButton();
            this.btnJuengsang4 = new IHIS.Framework.XButton();
            this.btnJuengsang3 = new IHIS.Framework.XButton();
            this.btnJuengsang2 = new IHIS.Framework.XButton();
            this.btnJuengsang1 = new IHIS.Framework.XButton();
            this.pnlNut7_3 = new IHIS.Framework.XPanel();
            this.pnlNut7_2 = new IHIS.Framework.XPanel();
            this.pnlNut7_1 = new IHIS.Framework.XPanel();
            this.pnlNut6_3 = new IHIS.Framework.XPanel();
            this.pnlNut6_2 = new IHIS.Framework.XPanel();
            this.pnlNut6_1 = new IHIS.Framework.XPanel();
            this.pnlNut5_3 = new IHIS.Framework.XPanel();
            this.pnlNut5_2 = new IHIS.Framework.XPanel();
            this.pnlNut5_1 = new IHIS.Framework.XPanel();
            this.pnlNut4_3 = new IHIS.Framework.XPanel();
            this.pnlNut4_2 = new IHIS.Framework.XPanel();
            this.pnlNut4_1 = new IHIS.Framework.XPanel();
            this.pnlNut3_3 = new IHIS.Framework.XPanel();
            this.pnlNut3_2 = new IHIS.Framework.XPanel();
            this.pnlNut3_1 = new IHIS.Framework.XPanel();
            this.pnlNut2_3 = new IHIS.Framework.XPanel();
            this.pnlNut2_2 = new IHIS.Framework.XPanel();
            this.pnlNut2_1 = new IHIS.Framework.XPanel();
            this.pnlNut1_3 = new IHIS.Framework.XPanel();
            this.pnlNut1_2 = new IHIS.Framework.XPanel();
            this.btnAfterWeek = new IHIS.Framework.XButton();
            this.btnNext = new IHIS.Framework.XButton();
            this.btnBeforeWeek = new IHIS.Framework.XButton();
            this.btnPrev = new IHIS.Framework.XButton();
            this.btnRecord7 = new IHIS.Framework.XButton();
            this.btnRecord6 = new IHIS.Framework.XButton();
            this.btnRecord5 = new IHIS.Framework.XButton();
            this.btnRecord4 = new IHIS.Framework.XButton();
            this.btnRecord3 = new IHIS.Framework.XButton();
            this.btnRecord2 = new IHIS.Framework.XButton();
            this.btnRecord1 = new IHIS.Framework.XButton();
            this.pnlNut1_1 = new IHIS.Framework.XPanel();
            this.layIO = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.layNut = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem36 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem37 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem38 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem39 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem40 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem48 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.layGraph = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.laySusulInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.layInOutTotal = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.layFlagQuery = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.layIpwonInfo = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.laySiksaNote = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.layQueryRemark = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.layNUR1122 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.layNUR1122List = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.layNUR7002 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.lblHistory = new IHIS.Framework.XLabel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.ToolTip = new IHIS.Framework.XToolTip();
            this.layConment = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem41 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlTopLeft.SuspendLayout();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCont)).BeginInit();
            this.graphCont.SuspendLayout();
            this.pnlComment.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusulInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layInOutTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layFlagQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR1122)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR1122List)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR7002)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layConment)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "팝업창.gif");
            this.ImageList.Images.SetKeyName(1, "조회.gif");
            this.ImageList.Images.SetKeyName(2, "왼쪽_회색.gif");
            this.ImageList.Images.SetKeyName(3, "오른쪽_회색.gif");
            this.ImageList.Images.SetKeyName(4, "왼쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(5, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(6, "경고.gif");
            this.ImageList.Images.SetKeyName(7, "진료요약정보.gif");
            this.ImageList.Images.SetKeyName(8, "Flow chart.gif");
            this.ImageList.Images.SetKeyName(9, "건진운영관리.ico");
            this.ImageList.Images.SetKeyName(10, "시험연~1.ICO");
            this.ImageList.Images.SetKeyName(11, "RR722.ico");
            this.ImageList.Images.SetKeyName(12, "앞으로.gif");
            this.ImageList.Images.SetKeyName(13, "작성.gif");
            this.ImageList.Images.SetKeyName(14, "차트관리.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlTopLeft);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.pnlTop.Size = new System.Drawing.Size(1495, 57);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlTopLeft
            // 
            this.pnlTopLeft.Controls.Add(this.pnlSession);
            this.pnlTopLeft.Controls.Add(this.paBox);
            this.pnlTopLeft.Controls.Add(this.lbJaewonil);
            this.pnlTopLeft.Controls.Add(this.cboHo_dong);
            this.pnlTopLeft.Controls.Add(this.lblHo_dong);
            this.pnlTopLeft.Controls.Add(this.lblYmd);
            this.pnlTopLeft.Controls.Add(this.dtpYmd);
            this.pnlTopLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLeft.Name = "pnlTopLeft";
            this.pnlTopLeft.Size = new System.Drawing.Size(1494, 57);
            this.pnlTopLeft.TabIndex = 10;
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(3, 29);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(236, 22);
            this.pnlSession.TabIndex = 21;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(1, 1);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(63, 21);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "チーム";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(74, 3);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(31, 17);
            this.cbxA.TabIndex = 14;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(116, 3);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(31, 17);
            this.cbxB.TabIndex = 15;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(158, 3);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 17);
            this.cbxC.TabIndex = 16;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(201, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(362, 27);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(1108, 28);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // lbJaewonil
            // 
            this.lbJaewonil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbJaewonil.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.lbJaewonil.Location = new System.Drawing.Point(1199, 0);
            this.lbJaewonil.Name = "lbJaewonil";
            this.lbJaewonil.Size = new System.Drawing.Size(270, 24);
            this.lbJaewonil.TabIndex = 11;
            this.lbJaewonil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(72, 3);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(81, 21);
            this.cboHo_dong.TabIndex = 10;
            this.cboHo_dong.SelectedIndexChanged += new System.EventHandler(this.cboHo_dong_SelectedIndexChanged);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(3, 3);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(63, 21);
            this.lblHo_dong.TabIndex = 11;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYmd
            // 
            this.lblYmd.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblYmd.EdgeRounding = false;
            this.lblYmd.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYmd.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblYmd.Location = new System.Drawing.Point(158, 4);
            this.lblYmd.Name = "lblYmd";
            this.lblYmd.Size = new System.Drawing.Size(71, 20);
            this.lblYmd.TabIndex = 8;
            this.lblYmd.Text = "照会日付";
            this.lblYmd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpYmd
            // 
            this.dtpYmd.IsJapanYearType = true;
            this.dtpYmd.Location = new System.Drawing.Point(232, 5);
            this.dtpYmd.Name = "dtpYmd";
            this.dtpYmd.Size = new System.Drawing.Size(129, 20);
            this.dtpYmd.TabIndex = 9;
            this.dtpYmd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpYmd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpYmd_DataValidating);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnComment);
            this.pnlBottom.Controls.Add(this.btnNextPatient);
            this.pnlBottom.Controls.Add(this.btnTento);
            this.pnlBottom.Controls.Add(this.btnKango);
            this.pnlBottom.Controls.Add(this.btnChiryo);
            this.pnlBottom.Controls.Add(this.btnKeika);
            this.pnlBottom.Controls.Add(this.btnPrint);
            this.pnlBottom.Controls.Add(this.btnCall);
            this.pnlBottom.Controls.Add(this.btnDisplay);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 668);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1495, 34);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnComment
            // 
            this.btnComment.ImageIndex = 14;
            this.btnComment.ImageList = this.ImageList;
            this.btnComment.Location = new System.Drawing.Point(124, 4);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(82, 28);
            this.btnComment.TabIndex = 12;
            this.btnComment.Text = "特記事項";
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 12;
            this.btnNextPatient.ImageList = this.ImageList;
            this.btnNextPatient.Location = new System.Drawing.Point(1196, 2);
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Size = new System.Drawing.Size(124, 30);
            this.btnNextPatient.TabIndex = 0;
            this.btnNextPatient.Text = "次の患者さんへ";
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // btnTento
            // 
            this.btnTento.ImageIndex = 11;
            this.btnTento.ImageList = this.ImageList;
            this.btnTento.Location = new System.Drawing.Point(671, 4);
            this.btnTento.Name = "btnTento";
            this.btnTento.Size = new System.Drawing.Size(143, 28);
            this.btnTento.TabIndex = 11;
            this.btnTento.Text = "転倒転落アセスメント";
            this.btnTento.Visible = false;
            this.btnTento.Click += new System.EventHandler(this.btnTento_Click);
            // 
            // btnKango
            // 
            this.btnKango.ImageIndex = 9;
            this.btnKango.ImageList = this.ImageList;
            this.btnKango.Location = new System.Drawing.Point(521, 4);
            this.btnKango.Name = "btnKango";
            this.btnKango.Size = new System.Drawing.Size(94, 28);
            this.btnKango.TabIndex = 10;
            this.btnKango.Text = "看護計画";
            this.btnKango.Click += new System.EventHandler(this.btnKango_Click);
            // 
            // btnChiryo
            // 
            this.btnChiryo.ImageIndex = 10;
            this.btnChiryo.ImageList = this.ImageList;
            this.btnChiryo.Location = new System.Drawing.Point(421, 4);
            this.btnChiryo.Name = "btnChiryo";
            this.btnChiryo.Size = new System.Drawing.Size(94, 28);
            this.btnChiryo.TabIndex = 9;
            this.btnChiryo.Text = "治療計画";
            this.btnChiryo.Click += new System.EventHandler(this.btnChiryo_Click);
            // 
            // btnKeika
            // 
            this.btnKeika.ImageIndex = 8;
            this.btnKeika.ImageList = this.ImageList;
            this.btnKeika.Location = new System.Drawing.Point(913, 3);
            this.btnKeika.Name = "btnKeika";
            this.btnKeika.Size = new System.Drawing.Size(128, 28);
            this.btnKeika.TabIndex = 8;
            this.btnKeika.Text = "抑制経過観察";
            this.btnKeika.Visible = false;
            this.btnKeika.Click += new System.EventHandler(this.btnKeika_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(208, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "印 刷";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCall.ImageIndex = 0;
            this.btnCall.ImageList = this.ImageList;
            this.btnCall.Location = new System.Drawing.Point(290, 4);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(128, 28);
            this.btnCall.TabIndex = 5;
            this.btnCall.Text = "温度板入力";
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDisplay.ImageIndex = 1;
            this.btnDisplay.ImageList = this.ImageList;
            this.btnDisplay.Location = new System.Drawing.Point(4, 4);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(118, 28);
            this.btnDisplay.TabIndex = 4;
            this.btnDisplay.Text = "詳細数値転換";
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(1327, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.AutoScroll = true;
            this.pnlFill.AutoSize = true;
            this.pnlFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.pnlFill.Controls.Add(this.graphCont);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFill.Location = new System.Drawing.Point(361, 57);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1134, 611);
            this.pnlFill.TabIndex = 2;
            // 
            // graphCont
            // 
            this.graphCont.AutoScroll = true;
            this.graphCont.AutoSize = true;
            this.graphCont.BackColor = System.Drawing.Color.White;
            this.graphCont.Controls.Add(this.pnlComment);
            this.graphCont.Controls.Add(this.matrix);
            this.graphCont.Controls.Add(this.btnJuengsang7);
            this.graphCont.Controls.Add(this.btnJuengsang6);
            this.graphCont.Controls.Add(this.btnJuengsang5);
            this.graphCont.Controls.Add(this.btnJuengsang4);
            this.graphCont.Controls.Add(this.btnJuengsang3);
            this.graphCont.Controls.Add(this.btnJuengsang2);
            this.graphCont.Controls.Add(this.btnJuengsang1);
            this.graphCont.Controls.Add(this.pnlNut7_3);
            this.graphCont.Controls.Add(this.pnlNut7_2);
            this.graphCont.Controls.Add(this.pnlNut7_1);
            this.graphCont.Controls.Add(this.pnlNut6_3);
            this.graphCont.Controls.Add(this.pnlNut6_2);
            this.graphCont.Controls.Add(this.pnlNut6_1);
            this.graphCont.Controls.Add(this.pnlNut5_3);
            this.graphCont.Controls.Add(this.pnlNut5_2);
            this.graphCont.Controls.Add(this.pnlNut5_1);
            this.graphCont.Controls.Add(this.pnlNut4_3);
            this.graphCont.Controls.Add(this.pnlNut4_2);
            this.graphCont.Controls.Add(this.pnlNut4_1);
            this.graphCont.Controls.Add(this.pnlNut3_3);
            this.graphCont.Controls.Add(this.pnlNut3_2);
            this.graphCont.Controls.Add(this.pnlNut3_1);
            this.graphCont.Controls.Add(this.pnlNut2_3);
            this.graphCont.Controls.Add(this.pnlNut2_2);
            this.graphCont.Controls.Add(this.pnlNut2_1);
            this.graphCont.Controls.Add(this.pnlNut1_3);
            this.graphCont.Controls.Add(this.pnlNut1_2);
            this.graphCont.Controls.Add(this.btnAfterWeek);
            this.graphCont.Controls.Add(this.btnNext);
            this.graphCont.Controls.Add(this.btnBeforeWeek);
            this.graphCont.Controls.Add(this.btnPrev);
            this.graphCont.Controls.Add(this.btnRecord7);
            this.graphCont.Controls.Add(this.btnRecord6);
            this.graphCont.Controls.Add(this.btnRecord5);
            this.graphCont.Controls.Add(this.btnRecord4);
            this.graphCont.Controls.Add(this.btnRecord3);
            this.graphCont.Controls.Add(this.btnRecord2);
            this.graphCont.Controls.Add(this.btnRecord1);
            this.graphCont.Controls.Add(this.pnlNut1_1);
            this.graphCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphCont.Location = new System.Drawing.Point(0, 0);
            this.graphCont.Name = "graphCont";
            this.graphCont.ReDraw = true;
            this.graphCont.Size = new System.Drawing.Size(1134, 611);
            this.graphCont.TabIndex = 0;
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.txtComment);
            this.pnlComment.Controls.Add(this.xPanel3);
            this.pnlComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComment.Location = new System.Drawing.Point(0, 401);
            this.pnlComment.Name = "pnlComment";
            this.pnlComment.Size = new System.Drawing.Size(1117, 141);
            this.pnlComment.TabIndex = 1;
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Location = new System.Drawing.Point(0, 0);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(1019, 141);
            this.txtComment.TabIndex = 0;
            this.txtComment.TabStop = false;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnSaveComment);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel3.Location = new System.Drawing.Point(1019, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(98, 141);
            this.xPanel3.TabIndex = 1;
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.ImageIndex = 13;
            this.btnSaveComment.ImageList = this.ImageList;
            this.btnSaveComment.Location = new System.Drawing.Point(3, 113);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(95, 28);
            this.btnSaveComment.TabIndex = 11;
            this.btnSaveComment.Text = "特記事項";
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // matrix
            // 
            this.matrix.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.matrix.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.matrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.matrix.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.matrix.Location = new System.Drawing.Point(0, 542);
            this.matrix.Name = "matrix";
            this.matrix.Size = new System.Drawing.Size(1117, 240);
            this.matrix.TabIndex = 1;
            this.matrix.Visible = false;
            // 
            // btnJuengsang7
            // 
            this.btnJuengsang7.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang7.ImageIndex = 7;
            this.btnJuengsang7.ImageList = this.ImageList;
            this.btnJuengsang7.Location = new System.Drawing.Point(1035, 38);
            this.btnJuengsang7.Name = "btnJuengsang7";
            this.btnJuengsang7.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang7.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang7.TabIndex = 558;
            this.btnJuengsang7.Tag = "6";
            this.btnJuengsang7.Text = "経過";
            this.btnJuengsang7.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang7.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang7.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang6
            // 
            this.btnJuengsang6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang6.ImageIndex = 7;
            this.btnJuengsang6.ImageList = this.ImageList;
            this.btnJuengsang6.Location = new System.Drawing.Point(897, 38);
            this.btnJuengsang6.Name = "btnJuengsang6";
            this.btnJuengsang6.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang6.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang6.TabIndex = 557;
            this.btnJuengsang6.Tag = "5";
            this.btnJuengsang6.Text = "経過";
            this.btnJuengsang6.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang6.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang6.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang5
            // 
            this.btnJuengsang5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang5.ImageIndex = 7;
            this.btnJuengsang5.ImageList = this.ImageList;
            this.btnJuengsang5.Location = new System.Drawing.Point(759, 38);
            this.btnJuengsang5.Name = "btnJuengsang5";
            this.btnJuengsang5.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang5.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang5.TabIndex = 556;
            this.btnJuengsang5.Tag = "4";
            this.btnJuengsang5.Text = "経過";
            this.btnJuengsang5.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang5.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang5.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang4
            // 
            this.btnJuengsang4.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang4.ImageIndex = 7;
            this.btnJuengsang4.ImageList = this.ImageList;
            this.btnJuengsang4.Location = new System.Drawing.Point(621, 38);
            this.btnJuengsang4.Name = "btnJuengsang4";
            this.btnJuengsang4.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang4.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang4.TabIndex = 555;
            this.btnJuengsang4.Tag = "3";
            this.btnJuengsang4.Text = "経過";
            this.btnJuengsang4.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang4.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang4.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang3
            // 
            this.btnJuengsang3.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang3.ImageIndex = 7;
            this.btnJuengsang3.ImageList = this.ImageList;
            this.btnJuengsang3.Location = new System.Drawing.Point(483, 38);
            this.btnJuengsang3.Name = "btnJuengsang3";
            this.btnJuengsang3.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang3.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang3.TabIndex = 554;
            this.btnJuengsang3.Tag = "2";
            this.btnJuengsang3.Text = "経過";
            this.btnJuengsang3.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang3.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang3.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang2
            // 
            this.btnJuengsang2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang2.ImageIndex = 7;
            this.btnJuengsang2.ImageList = this.ImageList;
            this.btnJuengsang2.Location = new System.Drawing.Point(345, 38);
            this.btnJuengsang2.Name = "btnJuengsang2";
            this.btnJuengsang2.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang2.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang2.TabIndex = 553;
            this.btnJuengsang2.Tag = "1";
            this.btnJuengsang2.Text = "経過";
            this.btnJuengsang2.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang2.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang2.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // btnJuengsang1
            // 
            this.btnJuengsang1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJuengsang1.ImageIndex = 7;
            this.btnJuengsang1.ImageList = this.ImageList;
            this.btnJuengsang1.Location = new System.Drawing.Point(207, 38);
            this.btnJuengsang1.Name = "btnJuengsang1";
            this.btnJuengsang1.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnJuengsang1.Size = new System.Drawing.Size(70, 22);
            this.btnJuengsang1.TabIndex = 552;
            this.btnJuengsang1.Tag = "0";
            this.btnJuengsang1.Text = "経過";
            this.btnJuengsang1.MouseLeave += new System.EventHandler(this.btnJuengsang2_MouseLeave);
            this.btnJuengsang1.Click += new System.EventHandler(this.btnJuengsang6_Click);
            this.btnJuengsang1.MouseEnter += new System.EventHandler(this.btnJuengsang_MouseEnter);
            // 
            // pnlNut7_3
            // 
            this.pnlNut7_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut7_3.Location = new System.Drawing.Point(920, 360);
            this.pnlNut7_3.Name = "pnlNut7_3";
            this.pnlNut7_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut7_3.TabIndex = 551;
            this.pnlNut7_3.Tag = "63";
            this.pnlNut7_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut7_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut7_2
            // 
            this.pnlNut7_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut7_2.Location = new System.Drawing.Point(880, 360);
            this.pnlNut7_2.Name = "pnlNut7_2";
            this.pnlNut7_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut7_2.TabIndex = 550;
            this.pnlNut7_2.Tag = "62";
            this.pnlNut7_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut7_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut7_1
            // 
            this.pnlNut7_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut7_1.Location = new System.Drawing.Point(840, 360);
            this.pnlNut7_1.Name = "pnlNut7_1";
            this.pnlNut7_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut7_1.TabIndex = 549;
            this.pnlNut7_1.Tag = "61";
            this.pnlNut7_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut7_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut6_3
            // 
            this.pnlNut6_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut6_3.Location = new System.Drawing.Point(800, 360);
            this.pnlNut6_3.Name = "pnlNut6_3";
            this.pnlNut6_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut6_3.TabIndex = 548;
            this.pnlNut6_3.Tag = "53";
            this.pnlNut6_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut6_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut6_2
            // 
            this.pnlNut6_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut6_2.Location = new System.Drawing.Point(760, 360);
            this.pnlNut6_2.Name = "pnlNut6_2";
            this.pnlNut6_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut6_2.TabIndex = 547;
            this.pnlNut6_2.Tag = "52";
            this.pnlNut6_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut6_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut6_1
            // 
            this.pnlNut6_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut6_1.Location = new System.Drawing.Point(720, 360);
            this.pnlNut6_1.Name = "pnlNut6_1";
            this.pnlNut6_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut6_1.TabIndex = 546;
            this.pnlNut6_1.Tag = "51";
            this.pnlNut6_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut6_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut5_3
            // 
            this.pnlNut5_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut5_3.Location = new System.Drawing.Point(680, 360);
            this.pnlNut5_3.Name = "pnlNut5_3";
            this.pnlNut5_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut5_3.TabIndex = 545;
            this.pnlNut5_3.Tag = "43";
            this.pnlNut5_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut5_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut5_2
            // 
            this.pnlNut5_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut5_2.Location = new System.Drawing.Point(640, 360);
            this.pnlNut5_2.Name = "pnlNut5_2";
            this.pnlNut5_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut5_2.TabIndex = 544;
            this.pnlNut5_2.Tag = "42";
            this.pnlNut5_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut5_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut5_1
            // 
            this.pnlNut5_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut5_1.Location = new System.Drawing.Point(600, 360);
            this.pnlNut5_1.Name = "pnlNut5_1";
            this.pnlNut5_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut5_1.TabIndex = 543;
            this.pnlNut5_1.Tag = "41";
            this.pnlNut5_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut5_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut4_3
            // 
            this.pnlNut4_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut4_3.Location = new System.Drawing.Point(560, 360);
            this.pnlNut4_3.Name = "pnlNut4_3";
            this.pnlNut4_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut4_3.TabIndex = 542;
            this.pnlNut4_3.Tag = "33";
            this.pnlNut4_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut4_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut4_2
            // 
            this.pnlNut4_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut4_2.Location = new System.Drawing.Point(520, 360);
            this.pnlNut4_2.Name = "pnlNut4_2";
            this.pnlNut4_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut4_2.TabIndex = 541;
            this.pnlNut4_2.Tag = "32";
            this.pnlNut4_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut4_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut4_1
            // 
            this.pnlNut4_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut4_1.Location = new System.Drawing.Point(480, 360);
            this.pnlNut4_1.Name = "pnlNut4_1";
            this.pnlNut4_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut4_1.TabIndex = 540;
            this.pnlNut4_1.Tag = "31";
            this.pnlNut4_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut4_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut3_3
            // 
            this.pnlNut3_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut3_3.Location = new System.Drawing.Point(440, 360);
            this.pnlNut3_3.Name = "pnlNut3_3";
            this.pnlNut3_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut3_3.TabIndex = 539;
            this.pnlNut3_3.Tag = "23";
            this.pnlNut3_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut3_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut3_2
            // 
            this.pnlNut3_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut3_2.Location = new System.Drawing.Point(400, 360);
            this.pnlNut3_2.Name = "pnlNut3_2";
            this.pnlNut3_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut3_2.TabIndex = 538;
            this.pnlNut3_2.Tag = "22";
            this.pnlNut3_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut3_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut3_1
            // 
            this.pnlNut3_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut3_1.Location = new System.Drawing.Point(360, 360);
            this.pnlNut3_1.Name = "pnlNut3_1";
            this.pnlNut3_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut3_1.TabIndex = 537;
            this.pnlNut3_1.Tag = "21";
            this.pnlNut3_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut3_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut2_3
            // 
            this.pnlNut2_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut2_3.Location = new System.Drawing.Point(320, 360);
            this.pnlNut2_3.Name = "pnlNut2_3";
            this.pnlNut2_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut2_3.TabIndex = 536;
            this.pnlNut2_3.Tag = "13";
            this.pnlNut2_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut2_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut2_2
            // 
            this.pnlNut2_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut2_2.Location = new System.Drawing.Point(280, 360);
            this.pnlNut2_2.Name = "pnlNut2_2";
            this.pnlNut2_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut2_2.TabIndex = 535;
            this.pnlNut2_2.Tag = "12";
            this.pnlNut2_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut2_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut2_1
            // 
            this.pnlNut2_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut2_1.Location = new System.Drawing.Point(240, 360);
            this.pnlNut2_1.Name = "pnlNut2_1";
            this.pnlNut2_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut2_1.TabIndex = 534;
            this.pnlNut2_1.Tag = "11";
            this.pnlNut2_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut2_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut1_3
            // 
            this.pnlNut1_3.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut1_3.Location = new System.Drawing.Point(200, 360);
            this.pnlNut1_3.Name = "pnlNut1_3";
            this.pnlNut1_3.Size = new System.Drawing.Size(41, 41);
            this.pnlNut1_3.TabIndex = 533;
            this.pnlNut1_3.Tag = "03";
            this.pnlNut1_3.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut1_3.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // pnlNut1_2
            // 
            this.pnlNut1_2.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut1_2.Location = new System.Drawing.Point(160, 360);
            this.pnlNut1_2.Name = "pnlNut1_2";
            this.pnlNut1_2.Size = new System.Drawing.Size(41, 41);
            this.pnlNut1_2.TabIndex = 532;
            this.pnlNut1_2.Tag = "02";
            this.pnlNut1_2.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut1_2.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // btnAfterWeek
            // 
            this.btnAfterWeek.Enabled = false;
            this.btnAfterWeek.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfterWeek.ImageIndex = 5;
            this.btnAfterWeek.ImageList = this.ImageList;
            this.btnAfterWeek.Location = new System.Drawing.Point(112, 1);
            this.btnAfterWeek.Name = "btnAfterWeek";
            this.btnAfterWeek.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnAfterWeek.Size = new System.Drawing.Size(26, 24);
            this.btnAfterWeek.TabIndex = 530;
            this.btnAfterWeek.Click += new System.EventHandler(this.btnAfterWeek_Click);
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ImageIndex = 3;
            this.btnNext.ImageList = this.ImageList;
            this.btnNext.Location = new System.Drawing.Point(87, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnNext.Size = new System.Drawing.Size(26, 24);
            this.btnNext.TabIndex = 529;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBeforeWeek
            // 
            this.btnBeforeWeek.Enabled = false;
            this.btnBeforeWeek.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBeforeWeek.ImageIndex = 4;
            this.btnBeforeWeek.ImageList = this.ImageList;
            this.btnBeforeWeek.Location = new System.Drawing.Point(1, 1);
            this.btnBeforeWeek.Name = "btnBeforeWeek";
            this.btnBeforeWeek.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnBeforeWeek.Size = new System.Drawing.Size(26, 24);
            this.btnBeforeWeek.TabIndex = 527;
            this.btnBeforeWeek.Click += new System.EventHandler(this.btnBeforeWeek_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Enabled = false;
            this.btnPrev.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ImageIndex = 2;
            this.btnPrev.ImageList = this.ImageList;
            this.btnPrev.Location = new System.Drawing.Point(26, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Scheme = IHIS.Framework.XButtonSchemes.OliveGreen;
            this.btnPrev.Size = new System.Drawing.Size(26, 24);
            this.btnPrev.TabIndex = 528;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnRecord7
            // 
            this.btnRecord7.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord7.Image")));
            this.btnRecord7.Location = new System.Drawing.Point(966, 38);
            this.btnRecord7.Name = "btnRecord7";
            this.btnRecord7.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord7.Size = new System.Drawing.Size(70, 22);
            this.btnRecord7.TabIndex = 526;
            this.btnRecord7.Tag = "6";
            this.btnRecord7.Text = "記録";
            this.btnRecord7.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord6
            // 
            this.btnRecord6.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord6.Image")));
            this.btnRecord6.Location = new System.Drawing.Point(828, 38);
            this.btnRecord6.Name = "btnRecord6";
            this.btnRecord6.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord6.Size = new System.Drawing.Size(70, 22);
            this.btnRecord6.TabIndex = 525;
            this.btnRecord6.Tag = "5";
            this.btnRecord6.Text = "記録";
            this.btnRecord6.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord5
            // 
            this.btnRecord5.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord5.Image")));
            this.btnRecord5.Location = new System.Drawing.Point(690, 38);
            this.btnRecord5.Name = "btnRecord5";
            this.btnRecord5.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord5.Size = new System.Drawing.Size(70, 22);
            this.btnRecord5.TabIndex = 524;
            this.btnRecord5.Tag = "4";
            this.btnRecord5.Text = "記録";
            this.btnRecord5.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord4
            // 
            this.btnRecord4.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord4.Image")));
            this.btnRecord4.Location = new System.Drawing.Point(552, 38);
            this.btnRecord4.Name = "btnRecord4";
            this.btnRecord4.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord4.Size = new System.Drawing.Size(70, 22);
            this.btnRecord4.TabIndex = 523;
            this.btnRecord4.Tag = "3";
            this.btnRecord4.Text = "記録";
            this.btnRecord4.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord3
            // 
            this.btnRecord3.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord3.Image")));
            this.btnRecord3.Location = new System.Drawing.Point(414, 38);
            this.btnRecord3.Name = "btnRecord3";
            this.btnRecord3.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord3.Size = new System.Drawing.Size(70, 22);
            this.btnRecord3.TabIndex = 522;
            this.btnRecord3.Tag = "2";
            this.btnRecord3.Text = "記録";
            this.btnRecord3.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord2
            // 
            this.btnRecord2.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord2.Image")));
            this.btnRecord2.Location = new System.Drawing.Point(276, 38);
            this.btnRecord2.Name = "btnRecord2";
            this.btnRecord2.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord2.Size = new System.Drawing.Size(70, 22);
            this.btnRecord2.TabIndex = 521;
            this.btnRecord2.Tag = "1";
            this.btnRecord2.Text = "記録";
            this.btnRecord2.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // btnRecord1
            // 
            this.btnRecord1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecord1.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord1.Image")));
            this.btnRecord1.Location = new System.Drawing.Point(138, 38);
            this.btnRecord1.Name = "btnRecord1";
            this.btnRecord1.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRecord1.Size = new System.Drawing.Size(70, 22);
            this.btnRecord1.TabIndex = 520;
            this.btnRecord1.Tag = "0";
            this.btnRecord1.Text = "記録";
            this.btnRecord1.Click += new System.EventHandler(this.btnRecord1_Click);
            // 
            // pnlNut1_1
            // 
            this.pnlNut1_1.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.pnlNut1_1.Location = new System.Drawing.Point(120, 360);
            this.pnlNut1_1.Name = "pnlNut1_1";
            this.pnlNut1_1.Size = new System.Drawing.Size(41, 41);
            this.pnlNut1_1.TabIndex = 531;
            this.pnlNut1_1.Tag = "01";
            this.pnlNut1_1.MouseLeave += new System.EventHandler(this.pnlNut4_3_MouseLeave);
            this.pnlNut1_1.MouseEnter += new System.EventHandler(this.pnlNut4_3_MouseEnter);
            // 
            // layIO
            // 
            this.layIO.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13,
            this.multiLayoutItem14});
            this.layIO.QuerySQL = resources.GetString("layIO.QuerySQL");
            this.layIO.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layIO_QueryStarting);
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "ymd";
            this.multiLayoutItem11.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "io_type";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "io_gubun";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "io_value";
            this.multiLayoutItem14.DataType = IHIS.Framework.DataType.Number;
            // 
            // layNut
            // 
            this.layNut.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem35,
            this.multiLayoutItem36,
            this.multiLayoutItem37,
            this.multiLayoutItem38,
            this.multiLayoutItem39,
            this.multiLayoutItem40,
            this.multiLayoutItem48,
            this.multiLayoutItem49});
            this.layNut.QuerySQL = resources.GetString("layNut.QuerySQL");
            this.layNut.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNut_QueryStarting);
            this.layNut.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNut_QueryEnd);
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "ymd";
            this.multiLayoutItem35.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "nut_gubun";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "nut_value";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "nut_value2";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "sik_gubun";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "sik_jong";
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "sik_jusik";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "sik_busik";
            // 
            // layGraph
            // 
            this.layGraph.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layGraph.QuerySQL = resources.GetString("layGraph.QuerySQL");
            this.layGraph.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layGraph_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "ymd";
            this.multiLayoutItem1.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "time_gubun";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "pr_gubun";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pr_value";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "ymd_date";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Date;
            // 
            // laySusulInfo
            // 
            this.laySusulInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem15,
            this.multiLayoutItem16});
            this.laySusulInfo.QuerySQL = resources.GetString("laySusulInfo.QuerySQL");
            this.laySusulInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySusulInfo_QueryStarting);
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "op_reser_date";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "susul_name";
            // 
            // layInOutTotal
            // 
            this.layInOutTotal.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layInOutTotal.QuerySQL = resources.GetString("layInOutTotal.QuerySQL");
            this.layInOutTotal.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layInOutTotal_QueryStarting);
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "ymd";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "in_total";
            this.multiLayoutItem18.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "out_total";
            this.multiLayoutItem19.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "inout_minus";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Number;
            // 
            // layFlagQuery
            // 
            this.layFlagQuery.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21});
            this.layFlagQuery.QuerySQL = resources.GetString("layFlagQuery.QuerySQL");
            this.layFlagQuery.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFlagQuery_QueryStarting);
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "num";
            // 
            // layIpwonInfo
            // 
            this.layIpwonInfo.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem6});
            this.layIpwonInfo.QuerySQL = resources.GetString("layIpwonInfo.QuerySQL");
            this.layIpwonInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layIpwonInfo_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "fkinp1001";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "ipwon_date";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.DataName = "jaewonilsu";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.DataName = "ho_dong";
            // 
            // laySiksaNote
            // 
            this.laySiksaNote.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem4});
            this.laySiksaNote.QuerySQL = resources.GetString("laySiksaNote.QuerySQL");
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.DataName = "siksa_note";
            // 
            // layQueryRemark
            // 
            this.layQueryRemark.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem5});
            this.layQueryRemark.QuerySQL = resources.GetString("layQueryRemark.QuerySQL");
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.DataName = "remark";
            // 
            // layNUR1122
            // 
            this.layNUR1122.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem22,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem30,
            this.multiLayoutItem31});
            this.layNUR1122.QuerySQL = resources.GetString("layNUR1122.QuerySQL");
            this.layNUR1122.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR1122_QueryStarting);
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "ymd";
            this.multiLayoutItem22.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "hangmog_code";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "hangmog_value1";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "hangmog_value2";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "hangmog_value3";
            // 
            // layNUR1122List
            // 
            this.layNUR1122List.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layNUR1122List.QuerySQL = resources.GetString("layNUR1122List.QuerySQL");
            this.layNUR1122List.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR1122List_QueryStarting);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "hangmog_name";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "hangmog_code";
            // 
            // layNUR7002
            // 
            this.layNUR7002.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem32,
            this.multiLayoutItem34});
            this.layNUR7002.QuerySQL = resources.GetString("layNUR7002.QuerySQL");
            this.layNUR7002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR7002_QueryStarting);
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "fkinp1001";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "diff";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "hangmog_gubun";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "hangmog_seq";
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "hangmog_value";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblHistory);
            this.pnlLeft.Controls.Add(this.grdPalist);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 57);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(361, 611);
            this.pnlLeft.TabIndex = 3;
            // 
            // lblHistory
            // 
            this.lblHistory.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Chocolate);
            this.lblHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHistory.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHistory.Location = new System.Drawing.Point(0, 0);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(361, 611);
            this.lblHistory.TabIndex = 1;
            this.lblHistory.Text = "履\r\n歴\r\n照\r\n会\r\n中\r\nで\r\nす\r\n。";
            this.lblHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHistory.Visible = false;
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
            this.xEditGridCell41});
            this.grdPalist.ColPerLine = 6;
            this.grdPalist.Cols = 6;
            this.grdPalist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Location = new System.Drawing.Point(0, 0);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.Size = new System.Drawing.Size(361, 611);
            this.grdPalist.TabIndex = 0;
            this.grdPalist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPalist_QueryEnd);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.Click += new System.EventHandler(this.grdPalist_Click);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "ho_code";
            this.xEditGridCell1.CellWidth = 40;
            this.xEditGridCell1.HeaderText = "病室";
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 9;
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.CellWidth = 75;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "患者番号";
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 30;
            this.xEditGridCell3.CellName = "su_name";
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "患者氏名";
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
            this.xEditGridCell6.CellWidth = 40;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "年/性";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "ipwon_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 90;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderText = "入院日付";
            this.xEditGridCell7.IsJapanYearType = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "doctor_name";
            this.xEditGridCell41.CellWidth = 100;
            this.xEditGridCell41.Col = 5;
            this.xEditGridCell41.HeaderText = "主治医";
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 10000;
            this.ToolTip.InitialDelay = 100;
            this.ToolTip.MaxinumWidth = 500;
            // 
            // layConment
            // 
            this.layConment.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem10,
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem33,
            this.multiLayoutItem41});
            this.layConment.QuerySQL = "SELECT A.BUNHO,\r\n       A.SER,\r\n       A.COMMENTS,\r\n       A.DISPLAY_YN,\r\n       " +
                "A.HOSP_CODE\r\n  FROM OUT0106 A\r\n WHERE A.HOSP_CODE = :f_hosp_code\r\n   AND A.BUNHO" +
                "     = :f_bunho\r\n ORDER BY SER DESC";
            this.layConment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layConment_QueryStarting);
            this.layConment.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layConment_QueryEnd);
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "bunho";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "ser";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "comment";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "display_yn";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "hosp_code";
            // 
            // NUR1020Q00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR1020Q00";
            this.Size = new System.Drawing.Size(1495, 702);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1020Q00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlTopLeft.ResumeLayout(false);
            this.pnlTopLeft.PerformLayout();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphCont)).EndInit();
            this.graphCont.ResumeLayout(false);
            this.pnlComment.ResumeLayout(false);
            this.pnlComment.PerformLayout();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySusulInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layInOutTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layFlagQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR1122)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR1122List)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR7002)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layConment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region SetGraph
        private void SetGraph()
        {
            if (this.paBox.BunHo == "")
                return;

            if (this.dtpYmd.GetDataValue() == "")
                return;

            //증상경과기록 버튼 이미지를 기본으로 설정
            this.btnJuengsang1.ImageIndex = 7;
            this.btnJuengsang2.ImageIndex = 7;
            this.btnJuengsang3.ImageIndex = 7;
            this.btnJuengsang4.ImageIndex = 7;
            this.btnJuengsang5.ImageIndex = 7;
            this.btnJuengsang6.ImageIndex = 7;
            this.btnJuengsang7.ImageIndex = 7;

            //환자의 증상경과기록 내용이 있는지 조회를 한다.
            if (this.layFlagQuery.QueryLayout(true))
            {
                if (this.layFlagQuery.RowCount > 0)
                {
                    for (int i = 0; i < this.layFlagQuery.RowCount; i++)
                    {
                        int num = int.Parse(this.layFlagQuery.GetItemValue(i, "num").ToString());
                        switch (num)
                        {
                            case 0:
                                this.btnJuengsang7.ImageIndex = 6;
                                break;
                            case -1:
                                this.btnJuengsang6.ImageIndex = 6;
                                break;
                            case -2:
                                this.btnJuengsang5.ImageIndex = 6;
                                break;
                            case -3:
                                this.btnJuengsang4.ImageIndex = 6;
                                break;
                            case -4:
                                this.btnJuengsang3.ImageIndex = 6;
                                break;
                            case -5:
                                this.btnJuengsang2.ImageIndex = 6;
                                break;
                            case -6:
                                this.btnJuengsang1.ImageIndex = 6;
                                break;
                        }
                    }
                }
            }

            //그리기     중지
            this.graphCont.ReDraw = false;

            
            //그래프 초기화
            this.graphCont.InitGraph();
            
            //모든 레이아웃 쿼리
            QueryAll();

            SetGraphData();

            this.graphCont.ReDraw = true;
        }

        private void QueryAll()
        {
            if (this.layGraph.QueryLayout(true))
            {
                this.btnPrev.Enabled = true;
                this.btnNext.Enabled = true;
                this.btnBeforeWeek.Enabled = true;
                this.btnAfterWeek.Enabled = true;
            }
            else
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            if (!this.layNut.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            //if (!this.layIO.QueryLayout(true))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg.ToString());
            //    return;
            //}

            if (!this.laySusulInfo.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg.ToString());
                return;
            }

            //if (!this.layInOutTotal.QueryLayout(true))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg.ToString());
            //    return;
            //}
            //2012.01.25
            if (!this.layNUR1122List.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            //2012.01.20 woo
            if (!this.layNUR1122.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            if (!this.layNUR7002.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
            if (!this.layConment.QueryLayout(true))
            {
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            }
        }

        private void SetGraphData()
        {
            //this.graphCont.DrawNUR1122Line(this.layNUR1122List.RowCount);
            //바이탈사인 세팅
            this.graphCont.SetDateHeader(Convert.ToDateTime(this.dtpYmd.GetDataValue()), laySusulInfo);
            this.graphCont.SetGraphData(this.layGraph.LayoutTable, DateTime.Parse(this.dtpYmd.GetDataValue()));

            //산소, spo2, 처치 세팅
            this.graphCont.SetEtc1Layout(maxLine(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('SYO')")));
            this.graphCont.SetEtc1Data(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('O2', 'SPO2', 'SYO', 'BS')"));

            //관찰항목 세팅
            this.graphCont.SetNUR1122Layout(this.layNUR1122List.LayoutTable);
            this.graphCont.SetNUR1122Data(this.layNUR1122.LayoutTable, DateTime.Parse(this.dtpYmd.GetDataValue()));
            this.graphCont.SetNURName(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('WRITER')"));

            //변, 뇨, 신장 체중 세팅
            this.graphCont.SetEtc2Layout();
            this.graphCont.SetEtc2Data(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('AS', 'AX', 'UX', 'UT', 'HEIGHT', 'WEIGHT')"));
            //this.graphCont.SetEtc2Data();
            
            ////In Out 세팅
            //this.graphCont.SetInOutData(this.layIO.LayoutTable, DateTime.Parse(this.dtpYmd.GetDataValue()));
            //this.graphCont.SetInOutTotalData(this.layInOutTotal.LayoutTable, DateTime.Parse(this.dtpYmd.GetDataValue()));
                        
            //식사 세팅
            //헤더는 DoLayout에서
            this.graphCont.SetFoodLayout();
            this.graphCont.SetFoodData(this.layNut.LayoutTable, DateTime.Parse(this.dtpYmd.GetDataValue()));
            
            this.graphCont.SetEtc3Layout(maxLine(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('CARE')")));
            this.graphCont.SetEtc3Data(this.layNUR7002.LayoutTable.Select("hangmog_gubun in ('CARE')"));
            //this.graphCont.SetEtc3Data();

            //Matrix Set
            this.SetMatrix(this.layGraph.LayoutTable);
        }
        
        private int maxLine(DataRow[] dTable)
        {
            int rowNum = 1;

            string[] stringSeperator = new string[] { "\r\n" };
            foreach (DataRow dtRow in dTable)
            {
                string[] temp = (dtRow["hangmog_value"].ToString()).Split(stringSeperator, StringSplitOptions.None);

                if (rowNum < temp.Length)
                    rowNum = temp.Length;
            }
            return rowNum;
        }

        #endregion

        #region NUR1020Q00_ScreenOpen
        private void NUR1020Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            //if (this.OpenStyle == ScreenOpenStyle.PopUpFixed || this.OpenStyle == ScreenOpenStyle.PopUpSizable)
            //{
            //Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            //this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 130);
            this.OpenParam = e.OpenParam;


            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);
            //}
            
            //Graph Cont의 Size Set
            //this.graphCont.Size = new Size(960, 835);
            
            try
            {
                if (((XScreen)Opener).ScreenID == "NUR1020U00")
                    this.btnCall.Visible = false;
                else
                    if (UserInfo.UserGubun == UserType.Nurse)
                        this.btnCall.Visible = true;
                    else
                        this.btnCall.Visible = false;

            }
            catch
            {
                if (UserInfo.UserGubun == UserType.Nurse)
                    this.btnCall.Visible = true;
                else
                    this.btnCall.Visible = false;
            }
            finally
            { }

            string sysDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            if (e.OpenParam != null)
            {
                if (OpenParam["sysid"].ToString() != "")
                    this.sysid = OpenParam["sysid"].ToString();
                if (OpenParam["screen"].ToString() != "")
                    this.screen = OpenParam["screen"].ToString();

                if (OpenParam["jaewon_yn"].ToString() != "")
                {
                    jaewon_yn = OpenParam["jaewon_yn"].ToString();

                    if (jaewon_yn == "N")
                    {
                        lblHistory.Visible = true;  
                        cboHo_dong.Enabled = false;
                        pnlSession.Enabled = false;
                        paBox.Enabled = false;
                        this.btnCall.Enabled = false;
                        pnlComment.Visible = false;

                        if (OpenParam["fkinp1001"].ToString() != "")
                        {
                            fkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString());
                        }
                    }
                    else
                    {
                        lblHistory.Visible = false;
                        cboHo_dong.Enabled = true;
                        pnlSession.Enabled = true;
                        paBox.Enabled = true;
                        btnCall.Enabled = true;
                        pnlComment.Visible = true;
                    }

                }

                dtpYmd.DataValidating -= new IHIS.Framework.DataValidatingEventHandler(this.dtpYmd_DataValidating);
                if (e.OpenParam["date"].ToString() != "")
                {
                    this.dtpYmd.SetEditValue(e.OpenParam["date"].ToString());
                    this.dtpYmd.AcceptData();
                }
                else
                {
                    this.dtpYmd.SetEditValue(sysDate);
                    this.dtpYmd.AcceptData();
                }
                dtpYmd.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpYmd_DataValidating);


                if (e.OpenParam["bunho"].ToString() != "")
                {
                    this.paBox.SetPatientID(e.OpenParam["bunho"].ToString());
                }

                if (e.OpenParam["hodong"].ToString() != "")
                {
                    this.cboHo_dong.SetEditValue(e.OpenParam["hodong"].ToString());
                }
                else
                {
                    string strCmd = "SELECT HO_DONG1 FROM VW_OCS_INP1001_01 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho";
                    BindVarCollection bindVar = new BindVarCollection();

                    bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                    bindVar.Add("f_bunho", paBox.BunHo);

                    object retVal = Service.ExecuteScalar(strCmd, bindVar);

                    if (retVal != null)
                    {
                        this.cboHo_dong.SetEditValue(retVal.ToString());
                    }
                }
            } 
            else
            {
                this.dtpYmd.SetEditValue(sysDate);
                this.dtpYmd.AcceptData();
                
                //현재스크린 환자번호   
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    jaewon_yn = "Y";

                    //this.paBox.PatientSelected -= new EventHandler(this.paBox_PatientSelected);
                    this.paBox.SetPatientID(patientInfo.BunHo);
                    //this.paBox.PatientSelected += new EventHandler(this.paBox_PatientSelected);
                }
            }
            if (jaewon_yn == "Y")
            {
                grdPalist.QueryLayout(true);
            }
            else
            {
                SetGraph();
                btnChiryo.Visible = false;
            }
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

        #region Matrix 구성
        const int MATRIX_ITEM_WIDTH = 40;  //Matrix에서의 한 ITem의 너비
        private DateItemCollection dateList = new DateItemCollection();  //일자별,시간별 P,BPH,BPL,T 값 관리하는 DataItem 리스트
        private void SetMatrix(DataTable dTable)
        {

            //데이타 Clear
            dateList.Clear();

            //Matrix Clear
            //this.matrix.ReDraw = false; //ReDraw 속성추가후 코멘트풀기
            this.matrix.ColItems.Clear();
            this.matrix.RowItems.Clear();
            this.matrix.Items.Clear();

            //하루에 측정된 시간과 건수를 담아두어야 함
            //dTable은 Date + Time + DataType(P,BPH,BPL,T) + Data 로 구성됨
            string date = "", time = "", dataType = "", data = "";
            TimeItem timeItem = null;
            DateItem dateItem = null;
            foreach (DataRow dtRow in dTable.Rows)
            {
                date = dtRow["ymd"].ToString();
                time = dtRow["time_gubun"].ToString();
                time = time.Insert(2, ":");
                dataType = dtRow["pr_gubun"].ToString();
                data = dtRow["pr_value"].ToString();
                if (dateList.Contains(date))
                {
                    //timeItemList에 해당 time이 있으면
                    if (dateList[date].TimeItemList.Contains(time))
                    {
                        timeItem = dateList[date].TimeItemList[time];
                        //Value Set
                        SetDataItemValue(timeItem, dataType, data);
                    }
                    else  //없으면
                    {
                        timeItem = new TimeItem(time);
                        //Value Set
                        SetDataItemValue(timeItem, dataType, data);
                        //TimeItemList 에 TimeItem Add
                        dateList[date].TimeItemList.Add(timeItem);
                    }
                }
                else
                {
                    dateItem = new DateItem(date);
                    timeItem = new TimeItem(time);
                    //Value Set
                    SetDataItemValue(timeItem, dataType, data);
                    dateItem.TimeItemList.Add(timeItem);
                    dateList.Add(dateItem);
                }
            }

            //Matrix 구성
            XColMatrixItem colItem = null;
            XMatrixItem matrixItem = null;
            XRowMatrixItem rowItem = null;
            int timeCount = 0;

            //row는 총 10줄(일자,시간,T, P, R, BPH, BPL, O2, SPO2, BS)
            this.matrix.RowItems.Add("日付", 0);
            this.matrix.RowItems.Add("時刻", 1);
            rowItem = this.matrix.RowItems.Add("体温", 1);
            rowItem.TextColor = this.graphCont.TPen.Color;
            rowItem = this.matrix.RowItems.Add("脈拍", 1);
            rowItem.TextColor = this.graphCont.PPen.Color;
            rowItem = this.matrix.RowItems.Add("呼吸", 1);
            rowItem.TextColor = this.graphCont.RPen.Color;
            rowItem = this.matrix.RowItems.Add("血圧H", 1);
            rowItem.TextColor = this.graphCont.BPHPen.Color;
            rowItem = this.matrix.RowItems.Add("血圧L", 1);
            rowItem.TextColor = this.graphCont.BPLPen.Color;
            rowItem = this.matrix.RowItems.Add("酸素", 1);
            rowItem.TextColor = this.graphCont.Spo2Pen.Color;
            rowItem = this.matrix.RowItems.Add("SPO2", 1);
            rowItem.TextColor = this.graphCont.Spo2Pen.Color;
            // 20110412 - Add Start
            rowItem = this.matrix.RowItems.Add("BS", 1);
            rowItem.TextColor = this.graphCont.BSPen.Color;
            // 20110412 - Add End

            TimeItemCollection timeItemList = null;
            foreach (DateItem dItem in dateList)
            {
                timeItemList = dItem.TimeItemList;
                //측정시간의 갯수계산
                timeCount = timeItemList.Count;
                //날짜의 너비는 측정시간의 갯수 * 단위너비, Key는 일자로 설정
                colItem = matrix.ColItems.Add(dItem.Date, dItem.Date, MATRIX_ITEM_WIDTH * timeCount);
                foreach (TimeItem tItem in timeItemList)
                {
                    //각 날짜별로 Time Child Add
                    colItem.Childs.Add(dItem.Date + tItem.Time, tItem.Time, MATRIX_ITEM_WIDTH);

                    //Items Set (T-> P-> R -> BPH -> BPL -> SPO2 ->BS 순으로 SET)

                    matrixItem = matrix.Items.Add(2, dItem.Date + tItem.Time, tItem.TValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.TPen.Color;  //Color 설정 (TPen)

                    matrixItem = matrix.Items.Add(3, dItem.Date + tItem.Time, tItem.PValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.PPen.Color;  //Color 설정 (PPen)

                    // 20070412 - Add Start
                    matrixItem = matrix.Items.Add(4, dItem.Date + tItem.Time, tItem.RValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.RPen.Color;	  //Color 설정 (RPen)
                    // 20070412 - Add End	


                    matrixItem = matrix.Items.Add(5, dItem.Date + tItem.Time, tItem.BPHValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.BPHPen.Color;  //Color 설정 (BPHPen)

                    matrixItem = matrix.Items.Add(6, dItem.Date + tItem.Time, tItem.BPLValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.BPLPen.Color;  //Color 설정 (BPLPen)

                    matrixItem = matrix.Items.Add(7, dItem.Date + tItem.Time, tItem.O2Value);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.Spo2Pen.Color;  //Color 설정 (O2Pen)

                    matrixItem = matrix.Items.Add(8, dItem.Date + tItem.Time, tItem.SPO2Value);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.Spo2Pen.Color;  //Color 설정 (SPO2Pen)

                    // 20110412 - Add Start
                    matrixItem = matrix.Items.Add(9, dItem.Date + tItem.Time, tItem.BSValue);
                    matrixItem.TextAlign = ContentAlignment.MiddleCenter;
                    matrixItem.TextColor = this.graphCont.BSPen.Color;	  //Color 설정 (BSPen)
                    // 20110412 - Add End	
                }

            }

            this.matrix.Setup();

            //this.matrix.ReDraw = true; //ReDraw 속성추가후 코멘트풀기
            //this.matrix.Invalidate(true);  //ReDraw 속성추가후는 코멘트 처리하기
        }
        private void SetDataItemValue(TimeItem item, string dataType, string data)
        {
            switch (dataType)
            {
                case "P":
                    item.PValue = data;
                    break;
                case "BPH":
                    item.BPHValue = data;
                    break;
                case "BPL":
                    item.BPLValue = data;
                    break;
                case "T":
                    item.TValue = data;
                    break;
                case "SPO2":
                    if (data == "1")
                        item.SPO2Value = "-";
                    else
                        item.SPO2Value = data;
                    break;
                case "R":
                    item.RValue = data;
                    break;
                case "O2":
                    item.O2Value = data;
                    break;
                case "BS":
                    if (data == "999")
                        item.BSValue = "Hi";
                    else if (data == "1")
                        item.BSValue = "Lo";
                    else
                        item.BSValue = data;
                    break;
            }
        }
        #endregion

        #region TimeItem (일자별 시간별 PR,BPH,BPL,T 데이타 관리 class)
        private class TimeItem
        {
            public string Time = "";
            public string PValue = "";
            public string BPHValue = "";
            public string BPLValue = "";
            public string TValue = "";
            public string SPO2Value = "";
            public string O2Value = "";
            public string RValue = "";
            public string BSValue = "";

            public TimeItem(string time)
            {
                this.Time = time;
            }
        }

        private class TimeItemCollection : System.Collections.CollectionBase
        {
            public TimeItem this[string time]
            {
                get
                {
                    if (time == "") return null;
                    foreach (TimeItem item in this)
                    {
                        if (item.Time == time) return item;
                    }
                    return null;
                }
            }
            public bool Contains(string time)
            {
                foreach (TimeItem item in List)
                    if (item.Time == time)
                        return true;
                return false;
            }
            public void Add(TimeItem timeItem)
            {
                List.Add(timeItem);
            }
        }
        private class DateItem
        {
            //Date별로 TimeDataList를 관리하는 객체
            public string Date = "";
            public TimeItemCollection TimeItemList = new TimeItemCollection();
            public DateItem(string date)
            {
                this.Date = date;
            }
        }
        private class DateItemCollection : System.Collections.CollectionBase
        {
            public DateItem this[string date]
            {
                get
                {
                    if (date == "") return null;
                    foreach (DateItem item in this)
                    {
                        if (item.Date == date) return item;
                    }
                    return null;
                }
            }
            public bool Contains(string date)
            {
                foreach (DateItem item in List)
                    if (item.Date == date)
                        return true;
                return false;
            }
            public void Add(DateItem dateItem)
            {
                List.Add(dateItem);
            }
        }
        #endregion

        #region 버튼리스트에서 버튼을 클릭을 했을 때의 이벤트
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    //if (!this.AcceptData())
                    //{
                    //    e.IsBaseCall = false;
                    //    e.IsSuccess = false;
                    //}

                    //e.IsBaseCall = false;

                    ////조회
                    //this.SetGraph();
                    e.IsBaseCall = false;
                    this.grdPalist.QueryLayout(true);

                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 경과기록 오픈
        private void btnRecord1_Click(object sender, System.EventArgs e)
        {
            if (!TypeCheck.IsNull(((IHIS.Framework.XButton)sender).Tag))
            {
                int day = int.Parse(((IHIS.Framework.XButton)sender).Tag.ToString()) - 6;
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.paBox.BunHo);
                cic.Add("record_date", DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(day));

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR9001U00", ScreenOpenStyle.PopUpFixed, cic);
            }
        }
        #endregion

        #region 좌우이동버튼을 클릭을 했을 때
        //과거 하루전
        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            this.dtpYmd.SetEditValue(DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(-1));
            this.dtpYmd.AcceptData();
        }

        //과거 일주일전
        private void btnBeforeWeek_Click(object sender, System.EventArgs e)
        {
            this.dtpYmd.SetEditValue(DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(-6));
            this.dtpYmd.AcceptData();
        }

        //하루후
        private void btnNext_Click(object sender, System.EventArgs e)
        {
            this.dtpYmd.SetEditValue(DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(1));
            this.dtpYmd.AcceptData();
        }

        //일주일후
        private void btnAfterWeek_Click(object sender, System.EventArgs e)
        {
            this.dtpYmd.SetEditValue(DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(6));
            this.dtpYmd.AcceptData();
        }
        #endregion

        #region 조회 날짜가 변경이 됐을 때
        private void dtpYmd_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (this.dtpYmd.GetDataValue().ToString() != "")
            {
                //조회
                this.SetGraph();
            }
        }
        #endregion

        private void btnDisplay_Click(object sender, System.EventArgs e)
        {
            this.matrix.Visible = !this.matrix.Visible;
        }

        private void btnCall_Click(object sender, System.EventArgs e)
        {
            //체온표 입력화면 Call
            //1.환자번호 입력여부 확인
            if (this.paBox.BunHo.ToString() == "")
            {
                XMessageBox.Show("患者番号を入力してください。", "お知らせ", MessageBoxIcon.Information);
                paBox.Focus();
                return;
            }
            else
            {
                IHIS.Framework.IXScreen aScreen;
                aScreen = XScreen.FindScreen("NURI", "NUR1020U00");

                if (aScreen == null)
                {
                    CommonItemCollection openParams = new CommonItemCollection();
                    openParams.Add("sysid", "NURI");
                    openParams.Add("screen", this.ScreenID.ToString());
                    //openParams.Add( "ho_dong", this.paBox.ToString());
                    openParams.Add("bunho", this.paBox.BunHo.ToString());
                    openParams.Add("date", this.dtpYmd.GetDataValue());

                    XScreen.OpenScreenWithParam(this, "NURI", "NUR1020U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopLeft, openParams);

                    //재조회처리
                    this.SetGraph();
                }
                else
                {
                    ((XScreen)aScreen).Activate();
                }
            }
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            //환자번호 입력여부 확인
            if (this.paBox.BunHo == "") return;

            //Graph Header Text Set -> Print
            //Header Text Set
            string text = this.paBox.BunHo + "  " + this.paBox.SuName + "  " + this.paBox.SuName2 + "  " + this.paBox.Sex + " / " + this.paBox.YearAge.ToString();
            this.graphCont.SetHeaderText(text);
            this.graphCont.Print();
            this.btnList.PerformClick(FunctionType.Query);
        }

        #region 환자번호를 입력을 했을 때
        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            //this.fkinp1001 = 0;
            /* 환자의 입원키를 조회한다. */
            //if(this.DataServiceCall(this.dsvFkinp1001))
            if (jaewon_yn == "Y")   
            {
                if (this.layIpwonInfo.QueryLayout())
                {
                    if (!TypeCheck.IsNull(this.layIpwonInfo.GetItemValue("fkinp1001")))
                    {
                        this.fkinp1001 = int.Parse(this.layIpwonInfo.GetItemValue("fkinp1001").ToString());
                        string ipwonDate = this.layIpwonInfo.GetItemValue("ipwon_date").ToString();

                        if (ipwonDate.Length > 10)
                            ipwonDate = ipwonDate.Substring(0, 10);

                        this.lbJaewonil.Text = "入院日付：" + ipwonDate
                                             + " 在院日数：" + this.layIpwonInfo.GetItemValue("jaewonilsu").ToString() + "日";

                        //조회
                        this.SetGraph();
                        if (cboHo_dong.GetDataValue() != layIpwonInfo.GetItemValue("ho_dong").ToString())
                        {
                            cboHo_dong.SetDataValue(layIpwonInfo.GetItemValue("ho_dong").ToString());
                        }
                    }

                    Set_grdPalist_Position(paBox.BunHo);

                    btnNextPatient.Focus();
                }                
                else
                {
                    XMessageBox.Show("入院患者ではありません。");
                    return;
                }

            }
        }
        #endregion

        #region 식사 상세내역 툴팁 보여주기
        private void pnlNut4_3_MouseEnter(object sender, System.EventArgs e)
        {
            // 사용안함.20110412 
            //if (this.fkinp1001.ToString() != "" && this.fkinp1001 != 0)
            //{
            //    int day = int.Parse(((IHIS.Framework.XPanel)sender).Tag.ToString().Substring(0, 1)) - 6;

            //    this.laySiksaNote.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //    this.laySiksaNote.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
            //    this.laySiksaNote.SetBindVarValue("f_bunho", this.paBox.BunHo.ToString());
            //    this.laySiksaNote.SetBindVarValue("f_order_date", DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(day).ToShortDateString());
            //    this.laySiksaNote.SetBindVarValue("f_ki_gubun", ((IHIS.Framework.XPanel)sender).Tag.ToString().Substring(1, 1));

            //    if (this.laySiksaNote.QueryLayout())
            //    {
            //        if (!TypeCheck.IsNull(this.laySiksaNote.GetItemValue("siksa_note")))
            //        {
            //            this.ToolTip.SetToolTip(((IHIS.Framework.XPanel)sender), this.laySiksaNote.GetItemValue("siksa_note").ToString());
            //            this.ToolTip.Active = true;
            //        }
            //        else
            //        {
            //            this.ToolTip.Active = false;
            //        }
            //    }
            //    else
            //    {
            //        if(Service.ErrFullMsg != "")
            //            XMessageBox.Show(Service.ErrFullMsg);
            //        return;
            //    }
            //}
        }

        private void pnlNut4_3_MouseLeave(object sender, System.EventArgs e)
        {
            //this.ToolTip.Active = false;
        }
        #endregion


        #region 증상경과기록 화면 오픈
        private void btnJuengsang6_Click(object sender, System.EventArgs e)
        {
            if (!TypeCheck.IsNull(((IHIS.Framework.XButton)sender).Tag))
            {
                int day = int.Parse(((IHIS.Framework.XButton)sender).Tag.ToString()) - 6;
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.paBox.BunHo);
                //cic.Add("record_date",DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(day));

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR9002U00", ScreenOpenStyle.ResponseFixed, cic);

                //재조회처리
                this.SetGraph();
            }
        }
        #endregion

        #region 증상경과기록내용 툴팁으로 보여주기
        private void btnJuengsang_MouseEnter(object sender, System.EventArgs e)
        {
            if (this.paBox.BunHo.ToString() != "")
            {
                int day = int.Parse(((IHIS.Framework.XButton)sender).Tag.ToString().Substring(0, 1)) - 6;

                this.layQueryRemark.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.layQueryRemark.SetBindVarValue("f_bunho", this.paBox.BunHo);
                this.layQueryRemark.SetBindVarValue("f_input_date", DateTime.Parse(this.dtpYmd.GetDataValue()).AddDays(day).ToShortDateString());
                
                if (this.layQueryRemark.QueryLayout())
                {
                    if (!TypeCheck.IsNull(this.layQueryRemark.GetItemValue("remark")))
                    {                        
                        this.ToolTip.SetToolTip(((IHIS.Framework.XButton)sender), this.layQueryRemark.GetItemValue("remark").ToString());
                        this.ToolTip.Active = true;
                    }
                    else
                    {
                        this.ToolTip.Active = false;                        
                    }
                }
                else
                {
                    if (Service.ErrFullMsg != "")
                        XMessageBox.Show(Service.ErrFullMsg);
                    return;
                }
            }
        }

        private void btnJuengsang2_MouseLeave(object sender, System.EventArgs e)
        {
            this.ToolTip.Active = false;
        }
        #endregion

        #region QueryStarting
        private void layFlagQuery_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layFlagQuery.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layFlagQuery.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layFlagQuery.SetBindVarValue("f_start_date", this.dtpYmd.GetDataValue());
        }

        private void layGraph_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layGraph.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layGraph.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layGraph.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
            this.layGraph.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
        }

        private void layNut_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNut.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNut.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layNut.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
            this.layNut.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
        }

        private void layIO_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layIO.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layIO.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layIO.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
            this.layIO.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
        }

        private void layIpwonInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layIpwonInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layIpwonInfo.SetBindVarValue("f_bunho", this.paBox.BunHo);
        }
        #endregion

        private void btnKeika_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("date", dtpYmd.GetDataValue());
            param.Add("bunho", this.paBox.BunHo);
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1035U00", ScreenOpenStyle.PopupSingleFixed, param);
        }

        private void btnKango_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                XMessageBox.Show("患者番号を入力してください。");
                paBox.Focus();
                return;
            }

            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("bunho", this.paBox.BunHo);
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR4001U00", ScreenOpenStyle.PopUpFixed, cic);
        }

        private void btnChiryo_Click(object sender, EventArgs e)
        {
            if (this.paBox.BunHo == "")
            {
                XMessageBox.Show("患者番号を入力してください。");
                paBox.Focus();
                return;
            }
            //CommonItemCollection cic = new CommonItemCollection();
            //cic.Add("bunho",this.selectedBedBox.Bunho);
            //cic.Add("fkinp1001",this.selectedBedBox.Pkinp1001);

            //IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpSizable, cic);


            IXScreen screen = XScreen.FindScreen("OCSI", "OCS6010U10");

            if (screen == null)
            {
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.paBox.BunHo);
                //cic.Add("fkinp1001", this.layIpwonInfo.GetItemValue("fkinp1001").ToString());
                cic.Add("fkinp1001", this.fkinp1001);

                if (jaewon_yn == "N")
                {
                    cic.Add("jaewon_yn", jaewon_yn);
                    cic.Add("query_date", OpenParam["date"].ToString());
                }

                IHIS.Framework.XScreen.OpenScreenWithParam(this, "OCSI", "OCS6010U10", ScreenOpenStyle.PopUpSizable, cic);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(this.paBox.BunHo, "", "", "", this.layIpwonInfo.GetItemValue("fkinp1001").ToString(), PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }
        }

        private void btnTento_Click(object sender, EventArgs e)
        {
            IXScreen screen = XScreen.FindScreen("DOCS", "DOC2001U00");

            if (screen == null)
            {
                CommonItemCollection cic = new CommonItemCollection();
                cic.Add("bunho", this.paBox.BunHo);
                cic.Add("acting_date", this.dtpYmd.GetDataValue());
                cic.Add("cert_jncd", "009");
                IHIS.Framework.XScreen.OpenScreenWithParam(this, "DOCS", "DOC2001U00", ScreenOpenStyle.PopUpFixed, cic);
            }
            else
            {
                screen.Activate();
                XPatientInfo pInfo = new XPatientInfo(this.paBox.BunHo, "", "", "", this.layIpwonInfo.GetItemValue("fkinp1001").ToString(), PatientPKGubun.In, this.ScreenID);
                XScreen.SendPatientInfo(pInfo);
            }
        }

        private void laySusulInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            this.laySusulInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.laySusulInfo.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.laySusulInfo.SetBindVarValue("f_from_op_date", Convert.ToDateTime(this.dtpYmd.GetDataValue()).AddDays(-6).ToString("yyyy/MM/dd"));
            this.laySusulInfo.SetBindVarValue("f_to_op_date", this.dtpYmd.GetDataValue());
            this.laySusulInfo.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
        }

        private void layInOutTotal_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layInOutTotal.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layInOutTotal.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layInOutTotal.SetBindVarValue("f_from_op_date", Convert.ToDateTime(this.dtpYmd.GetDataValue()).AddDays(-7).ToString("yyyy/MM/dd"));
            this.layInOutTotal.SetBindVarValue("f_to_op_date", this.dtpYmd.GetDataValue());
            this.layInOutTotal.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
        }

        private void layNUR1122_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR1122.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNUR1122.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layNUR1122.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
            this.layNUR1122.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
        }

        private void layNUR1122List_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR1122List.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNUR1122List.SetBindVarValue("f_bunho", this.paBox.BunHo);
            this.layNUR1122List.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
            this.layNUR1122List.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
        }

        private void layNUR7002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR7002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNUR7002.SetBindVarValue("f_fkinp1001", this.fkinp1001.ToString());
            this.layNUR7002.SetBindVarValue("f_ymd", this.dtpYmd.GetDataValue());
        }

        private void layNut_QueryEnd(object sender, QueryEndEventArgs e)
        {
            int org_jong = 0;
            int org_jusik = 0;
            int org_busik = 0;

            for (int i = 1; i < layNut.RowCount; i++)
            {
                if (layNut.GetItemString(org_jong, "sik_jong").Equals(layNut.GetItemString(i, "sik_jong")))
                {
                    layNut.SetItemValue(i, "sik_jong", "→");
                }
                else
                {
                    org_jong = i;
                }
                if (layNut.GetItemString(org_jusik, "sik_jusik").Equals(layNut.GetItemString(i, "sik_jusik")))
                {
                    layNut.SetItemValue(i, "sik_jusik", "→");
                }
                else
                {
                    org_jusik = i;
                }
                if (layNut.GetItemString(org_busik, "sik_busik").Equals(layNut.GetItemString(i, "sik_busik")))
                {
                    layNut.SetItemValue(i, "sik_busik", "→");
                }
                else
                {
                    org_busik = i;
                }
            }
        }

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPalist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdPalist.SetBindVarValue("f_date", dtpYmd.GetDataValue());
            grdPalist.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void grdPalist_Click(object sender, EventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
                //this.paListRownum = grdPalist.CurrentRowNumber;
            }
        }

        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum, "bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");

            btnNextPatient.Focus();
        }

        private void grdPalist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (grdPalist.RowCount == 0 || this.jaewon_yn == "N")
                return;

            Set_grdPalist_Position(paBox.BunHo);
        }

        private void Set_grdPalist_Position(string i_bunho)
        {
            this.grdPalist.UnSelectAll();
            for (int i = 0; i < this.grdPalist.RowCount; i++)
            {
                if (this.grdPalist.GetItemString(i, "bunho") == i_bunho)
                {
                    this.grdPalist.SelectRow(i);
                    grdPalist.SetFocusToItem(i, "bunho");
                    paListRownum = i;
                    break;
                }
            }
            grdPalist.SelectRow(paListRownum);
            grdPalist.SetFocusToItem(paListRownum, "bunho");
        }

        private void cboHo_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            paListRownum = 0;
            grdPalist.QueryLayout(true);

            //paBox.SetPatientID(grdPalist.GetItemString(paListRownum, "bunho"));
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            pnlComment.Visible = !pnlComment.Visible;
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();

            openParams.Add("bunho", paBox.BunHo);
            XScreen.OpenScreenWithParam(this, "NURO", "OUT0106U00", IHIS.Framework.ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentMiddleCenter, openParams);

            layConment.QueryLayout(true);

        }

        private void layConment_QueryStarting(object sender, CancelEventArgs e)
        {
            layConment.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layConment.SetBindVarValue("f_bunho", paBox.BunHo);
        }

        private void layConment_QueryEnd(object sender, QueryEndEventArgs e)
        {
            txtComment.Clear();
            for (int i = 0; i < layConment.RowCount; i++)
            {
                txtComment.Text += layConment.GetItemString(i, "comment") + "\r\n";
            }
        }

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }
    }
}

