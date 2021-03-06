using IHIS.Framework;
using System.Windows.Forms;
namespace IHIS.OCSO
{
    partial class OCS1003Q05
    {
        #region Designer generated code
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XMstGrid grdOUT1001;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XDatePicker dpkNaewon_date;
        private IHIS.Framework.MultiLayout dloSelectOCS1003;
        private IHIS.Framework.MultiLayout dloOrder_danui;
        private IHIS.Framework.XEditGridCell xEditGridCell95;
        private IHIS.Framework.XButton btnProcessD7;
        private IHIS.Framework.XEditGridCell xEditGridCell127;
        private System.Windows.Forms.CheckBox chkAll;
        private IHIS.Framework.XEditGridCell xEditGridCell129;
        private System.Windows.Forms.CheckBox chkIsNewGroup;
        private System.Windows.Forms.ImageList imageListMixGroup;
        private IHIS.Framework.XEditGridCell xEditGridCell142;
        private IHIS.Framework.XPanel xPanel6;
        private System.Windows.Forms.RadioButton rbtIn;
        private System.Windows.Forms.RadioButton rbtOut;
        private IHIS.Framework.XEditGridCell xEditGridCell146;
        private IHIS.Framework.XEditGridCell xEditGridCell147;
        private IHIS.Framework.XEditGridCell xEditGridCell149;
        private IHIS.Framework.XPanel pnlOrder;
        private IHIS.Framework.XEditGridCell xEditGridCell162;
        private IHIS.Framework.XEditGridCell xEditGridCell175;
        private IHIS.Framework.XTextBox txtDrg_info;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XTabControl tabGroup;
        private MultiLayout dloSelectOUT1001;
        private XPanel xPanel4;
        private XButton btnSelectAll;
        protected ImageList imageList1;
        private XButton btnDeleteAll;
        private XButton btnINJResult;
        private XButton btnPFEResult;
        private XButton btnCplResult;
        private XPatientBox pbxSearch;
        private XTabControl tabOrderGubun;
        private IHIS.X.Magic.Controls.TabPage tabPage4;
        private IHIS.X.Magic.Controls.TabPage tabPage1;
        private IHIS.X.Magic.Controls.TabPage tabPage2;
        private IHIS.X.Magic.Controls.TabPage tabPage3;
        private IHIS.X.Magic.Controls.TabPage tabPage5;
        private XEditGrid grdSangInfo;
        private XEditGridCell xEditGridCell34;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell39;
        private XEditGridCell xEditGridCell125;
        private XEditGridCell xEditGridCell57;
        private XEditGridCell xEditGridCell99;
        private XEditGridCell xEditGridCell100;
        private XEditGridCell xEditGridCell101;
        private XEditGridCell xEditGridCell58;
        private XEditGridCell xEditGridCell60;
        private XEditGridCell xEditGridCell61;
        private XEditGridCell xEditGridCell62;
        private XEditGridCell xEditGridCell63;
        private XEditGridCell xEditGridCell130;
        private XEditGridCell xEditGridCell74;
        private XEditGridCell xEditGridCell126;
        private XEditGridCell xEditGridCell103;
        private XEditGridCell xEditGridCell104;
        private XEditGridCell xEditGridCell105;
        private XEditGridCell xEditGridCell106;
        private XEditGridCell xEditGridCell107;
        private XEditGridCell xEditGridCell108;
        private XEditGridCell xEditGridCell109;
        private XEditGridCell xEditGridCell110;
        private XEditGridCell xEditGridCell111;
        private XEditGridCell xEditGridCell112;
        private XEditGridCell xEditGridCell113;
        private XEditGridCell xEditGridCell114;
        private XEditGridCell xEditGridCell115;
        private XEditGridCell xEditGridCell116;
        private XEditGridCell xEditGridCell117;
        private XEditGridCell xEditGridCell118;
        private XEditGridCell xEditGridCell119;
        private XEditGridCell xEditGridCell120;
        private XEditGridCell xEditGridCell121;
        private XEditGridCell xEditGridCell122;
        private XEditGridCell xEditGridCell123;
        private XEditGridCell xEditGridCell124;
        private XEditGridCell xEditGridCell98;
        private XCheckBox cbxGeneric_YN;
        private XEditGridCell xEditGridCell78;
        private XButton btnPre;
        private XButton btnHope_date;
        private XDatePicker dpkSetHopeDate;
        private XButton btnPost;
        private XButton btnProcessD0;
        private XButton btnProcessD4;
        private XComboBox cboKijunGubun;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XPanel pnlKijun;
        private XLabel lblKijun;
        private XEditGridCell xEditGridCell150;
        private XComboBox cboNalsu;
        private XButton btnNalsu;
        private XGroupBox gbxNalsu;
        private XGroupBox gbxHopeDate;
        private PictureBox pbxUnderArrow;
        private Timer timer_icon;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OCS1003Q05));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.pbxSearch = new IHIS.Framework.XPatientBox();
            this.dpkNaewon_date = new IHIS.Framework.XDatePicker();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.gbxHopeDate = new IHIS.Framework.XGroupBox();
            this.btnHope_date = new IHIS.Framework.XButton();
            this.btnPre = new IHIS.Framework.XButton();
            this.btnPost = new IHIS.Framework.XButton();
            this.dpkSetHopeDate = new IHIS.Framework.XDatePicker();
            this.gbxNalsu = new IHIS.Framework.XGroupBox();
            this.cboNalsu = new IHIS.Framework.XComboBox();
            this.btnNalsu = new IHIS.Framework.XButton();
            this.btnINJResult = new IHIS.Framework.XButton();
            this.btnPFEResult = new IHIS.Framework.XButton();
            this.btnCplResult = new IHIS.Framework.XButton();
            this.chkIsNewGroup = new System.Windows.Forms.CheckBox();
            this.btnProcessD0 = new IHIS.Framework.XButton();
            this.btnProcessD4 = new IHIS.Framework.XButton();
            this.btnProcessD7 = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdOUT1001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell127 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell146 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell147 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell129 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell142 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell162 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell149 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell175 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell150 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell95 = new IHIS.Framework.XEditGridCell();
            this.pnlKijun = new IHIS.Framework.XPanel();
            this.lblKijun = new IHIS.Framework.XLabel();
            this.cboKijunGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.tabOrderGubun = new IHIS.Framework.XTabControl();
            this.tabPage1 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage2 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage3 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage4 = new IHIS.X.Magic.Controls.TabPage();
            this.tabPage5 = new IHIS.X.Magic.Controls.TabPage();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.rbtIn = new System.Windows.Forms.RadioButton();
            this.rbtOut = new System.Windows.Forms.RadioButton();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.pnlOrder = new IHIS.Framework.XPanel();
            this.pbxUnderArrow = new System.Windows.Forms.PictureBox();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell145 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell102 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell134 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell135 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell136 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell137 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell163 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell164 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell165 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell166 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell173 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell140 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell141 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell40 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell167 = new IHIS.Framework.XEditGridCell();
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
            this.xEditGridCell52 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell53 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell54 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell56 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell59 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell64 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell65 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell67 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell139 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell94 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell68 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell153 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell154 = new IHIS.Framework.XEditGridCell();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xEditGridCell155 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell156 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell169 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell170 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell69 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell70 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell71 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell72 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell73 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell76 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell77 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell128 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell85 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell87 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell88 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell89 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell92 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell93 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell132 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell171 = new IHIS.Framework.XEditGridCell();
            this.txtDrg_info = new IHIS.Framework.XTextBox();
            this.xEditGridCell172 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell176 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell177 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell178 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell180 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell181 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell133 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell75 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell86 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell90 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell91 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell96 = new IHIS.Framework.XEditGridCell();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xEditGridCell131 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell97 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell138 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell143 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell144 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell148 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell151 = new IHIS.Framework.XEditGridCell();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.cbxGeneric_YN = new IHIS.Framework.XCheckBox();
            this.btnDeleteAll = new IHIS.Framework.XButton();
            this.btnSelectAll = new IHIS.Framework.XButton();
            this.grdSangInfo = new IHIS.Framework.XEditGrid();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell125 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell57 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell99 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell100 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell101 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell58 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell60 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell61 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell62 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell63 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell130 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell74 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell126 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell103 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell104 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell105 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell106 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell107 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell108 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell109 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell110 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell111 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell112 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell113 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell114 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell115 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell116 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell117 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell118 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell119 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell120 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell121 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell122 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell123 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell124 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell98 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell78 = new IHIS.Framework.XEditGridCell();
            this.tabGroup = new IHIS.Framework.XTabControl();
            this.dloSelectOCS1003 = new IHIS.Framework.MultiLayout();
            this.dloOrder_danui = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.imageListMixGroup = new System.Windows.Forms.ImageList(this.components);
            this.dloSelectOUT1001 = new IHIS.Framework.MultiLayout();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer_icon = new System.Windows.Forms.Timer(this.components);
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.gbxHopeDate.SuspendLayout();
            this.gbxNalsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).BeginInit();
            this.pnlKijun.SuspendLayout();
            this.tabOrderGubun.SuspendLayout();
            this.xPanel6.SuspendLayout();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).BeginInit();
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
            this.ImageList.Images.SetKeyName(4, "+.gif");
            this.ImageList.Images.SetKeyName(5, "_.gif");
            this.ImageList.Images.SetKeyName(6, "오른쪽_회색1.gif");
            this.ImageList.Images.SetKeyName(7, "RR331.ico");
            this.ImageList.Images.SetKeyName(8, "채열실.ico");
            this.ImageList.Images.SetKeyName(9, "RANG.ico");
            this.ImageList.Images.SetKeyName(10, "통계.ico");
            this.ImageList.Images.SetKeyName(11, "환경설정.gif");
            this.ImageList.Images.SetKeyName(12, "진료요약정보.ico");
            this.ImageList.Images.SetKeyName(13, "보기.ico");
            this.ImageList.Images.SetKeyName(14, "청구심사2_16.ico");
            this.ImageList.Images.SetKeyName(15, "pre.gif");
            this.ImageList.Images.SetKeyName(16, "post.gif");
            this.ImageList.Images.SetKeyName(17, "Untitled.png");
            this.ImageList.Images.SetKeyName(18, "");
            this.ImageList.Images.SetKeyName(19, "");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.pbxSearch);
            this.xPanel1.Controls.Add(this.dpkNaewon_date);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // pbxSearch
            // 
            this.pbxSearch.AccessibleDescription = null;
            this.pbxSearch.AccessibleName = null;
            resources.ApplyResources(this.pbxSearch, "pbxSearch");
            this.pbxSearch.BackgroundImage = null;
            this.pbxSearch.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxSearch.Name = "pbxSearch";
            this.pbxSearch.Validated += new System.EventHandler(this.pbxSearch_Validated);
            this.pbxSearch.PatientSelected += new System.EventHandler(this.pbxSearch_PatientSelected);
            // 
            // dpkNaewon_date
            // 
            this.dpkNaewon_date.AccessibleDescription = null;
            this.dpkNaewon_date.AccessibleName = null;
            resources.ApplyResources(this.dpkNaewon_date, "dpkNaewon_date");
            this.dpkNaewon_date.BackgroundImage = null;
            this.dpkNaewon_date.IsVietnameseYearType = false;
            this.dpkNaewon_date.Name = "dpkNaewon_date";
            this.dpkNaewon_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dpkNaewon_date_KeyDown);
            this.dpkNaewon_date.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dpkNaewon_date_DataValidating);
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.gbxHopeDate);
            this.xPanel2.Controls.Add(this.gbxNalsu);
            this.xPanel2.Controls.Add(this.btnINJResult);
            this.xPanel2.Controls.Add(this.btnPFEResult);
            this.xPanel2.Controls.Add(this.btnCplResult);
            this.xPanel2.Controls.Add(this.chkIsNewGroup);
            this.xPanel2.Controls.Add(this.btnProcessD0);
            this.xPanel2.Controls.Add(this.btnProcessD4);
            this.xPanel2.Controls.Add(this.btnProcessD7);
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // gbxHopeDate
            // 
            this.gbxHopeDate.AccessibleDescription = null;
            this.gbxHopeDate.AccessibleName = null;
            resources.ApplyResources(this.gbxHopeDate, "gbxHopeDate");
            this.gbxHopeDate.BackgroundImage = null;
            this.gbxHopeDate.Controls.Add(this.btnHope_date);
            this.gbxHopeDate.Controls.Add(this.btnPre);
            this.gbxHopeDate.Controls.Add(this.btnPost);
            this.gbxHopeDate.Controls.Add(this.dpkSetHopeDate);
            this.gbxHopeDate.Name = "gbxHopeDate";
            this.gbxHopeDate.Protect = true;
            this.gbxHopeDate.TabStop = false;
            // 
            // btnHope_date
            // 
            this.btnHope_date.AccessibleDescription = null;
            this.btnHope_date.AccessibleName = null;
            resources.ApplyResources(this.btnHope_date, "btnHope_date");
            this.btnHope_date.BackgroundImage = null;
            this.btnHope_date.ImageIndex = 8;
            this.btnHope_date.Name = "btnHope_date";
            this.btnHope_date.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnHope_date.Tag = "0";
            this.btnHope_date.Click += new System.EventHandler(this.btnHope_date_Click);
            // 
            // btnPre
            // 
            this.btnPre.AccessibleDescription = null;
            this.btnPre.AccessibleName = null;
            resources.ApplyResources(this.btnPre, "btnPre");
            this.btnPre.BackgroundImage = null;
            this.btnPre.ImageIndex = 15;
            this.btnPre.ImageList = this.ImageList;
            this.btnPre.Name = "btnPre";
            this.btnPre.Tag = "-";
            this.btnPre.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // btnPost
            // 
            this.btnPost.AccessibleDescription = null;
            this.btnPost.AccessibleName = null;
            resources.ApplyResources(this.btnPost, "btnPost");
            this.btnPost.BackgroundImage = null;
            this.btnPost.ImageIndex = 16;
            this.btnPost.ImageList = this.ImageList;
            this.btnPost.Name = "btnPost";
            this.btnPost.Tag = "+";
            this.btnPost.Click += new System.EventHandler(this.btnDatePlusMinus_Click);
            // 
            // dpkSetHopeDate
            // 
            this.dpkSetHopeDate.AccessibleDescription = null;
            this.dpkSetHopeDate.AccessibleName = null;
            resources.ApplyResources(this.dpkSetHopeDate, "dpkSetHopeDate");
            this.dpkSetHopeDate.BackgroundImage = null;
            this.dpkSetHopeDate.IsVietnameseYearType = false;
            this.dpkSetHopeDate.Name = "dpkSetHopeDate";
            this.dpkSetHopeDate.TextChanged += new System.EventHandler(this.dpkSetHopeDate_TextChanged);
            // 
            // gbxNalsu
            // 
            this.gbxNalsu.AccessibleDescription = null;
            this.gbxNalsu.AccessibleName = null;
            resources.ApplyResources(this.gbxNalsu, "gbxNalsu");
            this.gbxNalsu.BackgroundImage = null;
            this.gbxNalsu.Controls.Add(this.cboNalsu);
            this.gbxNalsu.Controls.Add(this.btnNalsu);
            this.gbxNalsu.Name = "gbxNalsu";
            this.gbxNalsu.Protect = true;
            this.gbxNalsu.TabStop = false;
            // 
            // cboNalsu
            // 
            this.cboNalsu.AccessibleDescription = null;
            this.cboNalsu.AccessibleName = null;
            resources.ApplyResources(this.cboNalsu, "cboNalsu");
            this.cboNalsu.BackgroundImage = null;
            this.cboNalsu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cboNalsu.Name = "cboNalsu";
            // 
            // btnNalsu
            // 
            this.btnNalsu.AccessibleDescription = null;
            this.btnNalsu.AccessibleName = null;
            resources.ApplyResources(this.btnNalsu, "btnNalsu");
            this.btnNalsu.BackgroundImage = null;
            this.btnNalsu.ImageIndex = 8;
            this.btnNalsu.Name = "btnNalsu";
            this.btnNalsu.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnNalsu.Tag = "0";
            this.btnNalsu.Click += new System.EventHandler(this.btnNalsu_Click);
            // 
            // btnINJResult
            // 
            this.btnINJResult.AccessibleDescription = null;
            this.btnINJResult.AccessibleName = null;
            resources.ApplyResources(this.btnINJResult, "btnINJResult");
            this.btnINJResult.BackgroundImage = null;
            this.btnINJResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnINJResult.ImageIndex = 13;
            this.btnINJResult.ImageList = this.ImageList;
            this.btnINJResult.Name = "btnINJResult";
            this.btnINJResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnINJResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnINJResult.Click += new System.EventHandler(this.btnINJResult_Click);
            // 
            // btnPFEResult
            // 
            this.btnPFEResult.AccessibleDescription = null;
            this.btnPFEResult.AccessibleName = null;
            resources.ApplyResources(this.btnPFEResult, "btnPFEResult");
            this.btnPFEResult.BackgroundImage = null;
            this.btnPFEResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPFEResult.ImageIndex = 12;
            this.btnPFEResult.ImageList = this.ImageList;
            this.btnPFEResult.Name = "btnPFEResult";
            this.btnPFEResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnPFEResult.Click += new System.EventHandler(this.btnPFEResult_Click);
            // 
            // btnCplResult
            // 
            this.btnCplResult.AccessibleDescription = null;
            this.btnCplResult.AccessibleName = null;
            resources.ApplyResources(this.btnCplResult, "btnCplResult");
            this.btnCplResult.BackgroundImage = null;
            this.btnCplResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCplResult.ImageIndex = 9;
            this.btnCplResult.ImageList = this.ImageList;
            this.btnCplResult.Name = "btnCplResult";
            this.btnCplResult.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnCplResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCplResult.Click += new System.EventHandler(this.btnCplResult_Click);
            // 
            // chkIsNewGroup
            // 
            this.chkIsNewGroup.AccessibleDescription = null;
            this.chkIsNewGroup.AccessibleName = null;
            resources.ApplyResources(this.chkIsNewGroup, "chkIsNewGroup");
            this.chkIsNewGroup.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkIsNewGroup.BackgroundImage = null;
            this.chkIsNewGroup.Checked = true;
            this.chkIsNewGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsNewGroup.Font = null;
            this.chkIsNewGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkIsNewGroup.ImageList = this.ImageList;
            this.chkIsNewGroup.Name = "chkIsNewGroup";
            this.chkIsNewGroup.UseVisualStyleBackColor = false;
            this.chkIsNewGroup.CheckedChanged += new System.EventHandler(this.chkIsNewGroup_CheckedChanged);
            // 
            // btnProcessD0
            // 
            this.btnProcessD0.AccessibleDescription = null;
            this.btnProcessD0.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD0, "btnProcessD0");
            this.btnProcessD0.BackgroundImage = null;
            this.btnProcessD0.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD0.Image")));
            this.btnProcessD0.Name = "btnProcessD0";
            this.btnProcessD0.Tag = "D0";
            this.btnProcessD0.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD4
            // 
            this.btnProcessD4.AccessibleDescription = null;
            this.btnProcessD4.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD4, "btnProcessD4");
            this.btnProcessD4.BackgroundImage = null;
            this.btnProcessD4.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD4.Image")));
            this.btnProcessD4.Name = "btnProcessD4";
            this.btnProcessD4.Tag = "D4";
            this.btnProcessD4.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnProcessD7
            // 
            this.btnProcessD7.AccessibleDescription = null;
            this.btnProcessD7.AccessibleName = null;
            resources.ApplyResources(this.btnProcessD7, "btnProcessD7");
            this.btnProcessD7.BackgroundImage = null;
            this.btnProcessD7.Image = ((System.Drawing.Image)(resources.GetObject("btnProcessD7.Image")));
            this.btnProcessD7.Name = "btnProcessD7";
            this.btnProcessD7.Tag = "D7";
            this.btnProcessD7.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            this.btnList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.xButtonList1_MouseDown);
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.grdOUT1001);
            this.xPanel3.Controls.Add(this.pnlKijun);
            this.xPanel3.Controls.Add(this.tabOrderGubun);
            this.xPanel3.Controls.Add(this.xPanel6);
            this.xPanel3.Controls.Add(this.chkAll);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdOUT1001
            // 
            resources.ApplyResources(this.grdOUT1001, "grdOUT1001");
            this.grdOUT1001.ApplyPaintEventToAllColumn = true;
            this.grdOUT1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell127,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell146,
            this.xEditGridCell147,
            this.xEditGridCell7,
            this.xEditGridCell129,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell142,
            this.xEditGridCell162,
            this.xEditGridCell149,
            this.xEditGridCell175,
            this.xEditGridCell150,
            this.xEditGridCell95});
            this.grdOUT1001.ColPerLine = 7;
            this.grdOUT1001.Cols = 8;
            this.grdOUT1001.EnableMultiSelection = true;
            this.grdOUT1001.ExecuteQuery = null;
            this.grdOUT1001.FixedCols = 1;
            this.grdOUT1001.FixedRows = 1;
            this.grdOUT1001.HeaderHeights.Add(27);
            this.grdOUT1001.ImageList = this.ImageList;
            this.grdOUT1001.Name = "grdOUT1001";
            this.grdOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOUT1001.ParamList")));
            this.grdOUT1001.QuerySQL = resources.GetString("grdOUT1001.QuerySQL");
            this.grdOUT1001.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOUT1001.RowHeaderVisible = true;
            this.grdOUT1001.Rows = 2;
            this.grdOUT1001.RowStateCheckOnPaint = false;
            this.grdOUT1001.ToolTipActive = true;
            this.grdOUT1001.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOUT1001_QueryEnd);
            this.grdOUT1001.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOUT1001_MouseDown);
            this.grdOUT1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOUT1001_RowFocusChanged);
            this.grdOUT1001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOUT1001_GridCellPainting);
            this.grdOUT1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOUT1001_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell1.CellName = "naewon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 86;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell1.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell127
            // 
            this.xEditGridCell127.CellName = "gwa";
            this.xEditGridCell127.Col = -1;
            this.xEditGridCell127.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell127, "xEditGridCell127");
            this.xEditGridCell127.IsVisible = false;
            this.xEditGridCell127.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell2.CellName = "gwa_name";
            this.xEditGridCell2.CellWidth = 67;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell2.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellName = "doctor_name";
            this.xEditGridCell3.CellWidth = 102;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell3.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.CellName = "nalsu";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.CellWidth = 40;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell4.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "bunho";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "doctor";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell146
            // 
            this.xEditGridCell146.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell146.CellName = "gubun_name";
            this.xEditGridCell146.CellWidth = 130;
            this.xEditGridCell146.Col = 5;
            this.xEditGridCell146.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell146, "xEditGridCell146");
            this.xEditGridCell146.IsUpdatable = false;
            this.xEditGridCell146.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell146.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell147
            // 
            this.xEditGridCell147.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell147.CellName = "chojae";
            this.xEditGridCell147.CellWidth = 131;
            this.xEditGridCell147.Col = 6;
            this.xEditGridCell147.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell147, "xEditGridCell147");
            this.xEditGridCell147.IsUpdatable = false;
            this.xEditGridCell147.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell147.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "naewon_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell129
            // 
            this.xEditGridCell129.CellName = "jubsu_no";
            this.xEditGridCell129.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell129.Col = -1;
            this.xEditGridCell129.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell129, "xEditGridCell129");
            this.xEditGridCell129.IsUpdatable = false;
            this.xEditGridCell129.IsVisible = false;
            this.xEditGridCell129.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "pk_order";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "input_gubun";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell142
            // 
            this.xEditGridCell142.CellName = "tel_yn";
            this.xEditGridCell142.Col = -1;
            this.xEditGridCell142.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell142, "xEditGridCell142");
            this.xEditGridCell142.IsUpdatable = false;
            this.xEditGridCell142.IsVisible = false;
            this.xEditGridCell142.Row = -1;
            // 
            // xEditGridCell162
            // 
            this.xEditGridCell162.CellName = "toiwon_drg";
            this.xEditGridCell162.Col = -1;
            this.xEditGridCell162.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell162, "xEditGridCell162");
            this.xEditGridCell162.IsUpdatable = false;
            this.xEditGridCell162.IsVisible = false;
            this.xEditGridCell162.Row = -1;
            // 
            // xEditGridCell149
            // 
            this.xEditGridCell149.CellName = "input_tab";
            this.xEditGridCell149.Col = -1;
            this.xEditGridCell149.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell149, "xEditGridCell149");
            this.xEditGridCell149.IsUpdatable = false;
            this.xEditGridCell149.IsVisible = false;
            this.xEditGridCell149.Row = -1;
            // 
            // xEditGridCell175
            // 
            this.xEditGridCell175.CellName = "io_gubun";
            this.xEditGridCell175.Col = -1;
            this.xEditGridCell175.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell175, "xEditGridCell175");
            this.xEditGridCell175.IsUpdatable = false;
            this.xEditGridCell175.IsVisible = false;
            this.xEditGridCell175.Row = -1;
            // 
            // xEditGridCell150
            // 
            this.xEditGridCell150.CellName = "Is_order_yn";
            this.xEditGridCell150.CellWidth = 100;
            this.xEditGridCell150.Col = 7;
            this.xEditGridCell150.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell150, "xEditGridCell150");
            this.xEditGridCell150.IsUpdatable = false;
            // 
            // xEditGridCell95
            // 
            this.xEditGridCell95.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell95.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.AlterateRowImageIndex = 0;
            this.xEditGridCell95.CellName = "select";
            this.xEditGridCell95.CellWidth = 63;
            this.xEditGridCell95.Col = 1;
            this.xEditGridCell95.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell95, "xEditGridCell95");
            this.xEditGridCell95.ImageList = this.ImageList;
            this.xEditGridCell95.IsUpdatable = false;
            this.xEditGridCell95.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell95.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell95.RowImageIndex = 0;
            this.xEditGridCell95.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell95.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // pnlKijun
            // 
            this.pnlKijun.AccessibleDescription = null;
            this.pnlKijun.AccessibleName = null;
            resources.ApplyResources(this.pnlKijun, "pnlKijun");
            this.pnlKijun.BackgroundImage = null;
            this.pnlKijun.Controls.Add(this.lblKijun);
            this.pnlKijun.Controls.Add(this.cboKijunGubun);
            this.pnlKijun.Font = null;
            this.pnlKijun.Name = "pnlKijun";
            // 
            // lblKijun
            // 
            this.lblKijun.AccessibleDescription = null;
            this.lblKijun.AccessibleName = null;
            resources.ApplyResources(this.lblKijun, "lblKijun");
            this.lblKijun.Image = null;
            this.lblKijun.Name = "lblKijun";
            // 
            // cboKijunGubun
            // 
            this.cboKijunGubun.AccessibleDescription = null;
            this.cboKijunGubun.AccessibleName = null;
            resources.ApplyResources(this.cboKijunGubun, "cboKijunGubun");
            this.cboKijunGubun.BackgroundImage = null;
            this.cboKijunGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboKijunGubun.Name = "cboKijunGubun";
            this.cboKijunGubun.SelectedIndexChanged += new System.EventHandler(this.cboKijunGubun_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "O";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "H";
            // 
            // tabOrderGubun
            // 
            this.tabOrderGubun.AccessibleDescription = null;
            this.tabOrderGubun.AccessibleName = null;
            resources.ApplyResources(this.tabOrderGubun, "tabOrderGubun");
            this.tabOrderGubun.BackgroundImage = null;
            this.tabOrderGubun.Font = null;
            this.tabOrderGubun.IDEPixelArea = true;
            this.tabOrderGubun.IDEPixelBorder = false;
            this.tabOrderGubun.ImageList = this.ImageList;
            this.tabOrderGubun.Name = "tabOrderGubun";
            this.tabOrderGubun.SelectedIndex = 0;
            this.tabOrderGubun.SelectedTab = this.tabPage1;
            this.tabOrderGubun.ShowClose = false;
            this.tabOrderGubun.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4,
            this.tabPage5});
            this.tabOrderGubun.SelectionChanged += new System.EventHandler(this.tabOrderGubun_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleDescription = null;
            this.tabPage1.AccessibleName = null;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackgroundImage = null;
            this.tabPage1.Font = null;
            this.tabPage1.ImageIndex = 1;
            this.tabPage1.ImageList = this.ImageList;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Tag = "%";
            // 
            // tabPage2
            // 
            this.tabPage2.AccessibleDescription = null;
            this.tabPage2.AccessibleName = null;
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackgroundImage = null;
            this.tabPage2.Font = null;
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.ImageList = this.ImageList;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Tag = "1";
            // 
            // tabPage3
            // 
            this.tabPage3.AccessibleDescription = null;
            this.tabPage3.AccessibleName = null;
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.BackgroundImage = null;
            this.tabPage3.Font = null;
            this.tabPage3.ImageIndex = 0;
            this.tabPage3.ImageList = this.ImageList;
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Tag = "2";
            // 
            // tabPage4
            // 
            this.tabPage4.AccessibleDescription = null;
            this.tabPage4.AccessibleName = null;
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.BackgroundImage = null;
            this.tabPage4.Font = null;
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.ImageList = this.ImageList;
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Tag = "3";
            // 
            // tabPage5
            // 
            this.tabPage5.AccessibleDescription = null;
            this.tabPage5.AccessibleName = null;
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.BackgroundImage = null;
            this.tabPage5.Font = null;
            this.tabPage5.ImageIndex = 0;
            this.tabPage5.ImageList = this.ImageList;
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Tag = "4";
            // 
            // xPanel6
            // 
            this.xPanel6.AccessibleDescription = null;
            this.xPanel6.AccessibleName = null;
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.BackgroundImage = null;
            this.xPanel6.Controls.Add(this.rbtIn);
            this.xPanel6.Controls.Add(this.rbtOut);
            this.xPanel6.Font = null;
            this.xPanel6.Name = "xPanel6";
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
            this.rbtIn.CheckedChanged += new System.EventHandler(this.rbtOut_CheckedChanged);
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
            // chkAll
            // 
            this.chkAll.AccessibleDescription = null;
            this.chkAll.AccessibleName = null;
            resources.ApplyResources(this.chkAll, "chkAll");
            this.chkAll.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.chkAll.BackgroundImage = null;
            this.chkAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkAll.Font = null;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkAll.ImageList = this.ImageList;
            this.chkAll.Name = "chkAll";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // pnlOrder
            // 
            this.pnlOrder.AccessibleDescription = null;
            this.pnlOrder.AccessibleName = null;
            this.pnlOrder.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            resources.ApplyResources(this.pnlOrder, "pnlOrder");
            this.pnlOrder.BackgroundImage = null;
            this.pnlOrder.Controls.Add(this.pbxUnderArrow);
            this.pnlOrder.Controls.Add(this.grdOCS1003);
            this.pnlOrder.Controls.Add(this.xPanel4);
            this.pnlOrder.Controls.Add(this.grdSangInfo);
            this.pnlOrder.Controls.Add(this.tabGroup);
            this.pnlOrder.Controls.Add(this.txtDrg_info);
            this.pnlOrder.Font = null;
            this.pnlOrder.Name = "pnlOrder";
            // 
            // pbxUnderArrow
            // 
            this.pbxUnderArrow.AccessibleDescription = null;
            this.pbxUnderArrow.AccessibleName = null;
            resources.ApplyResources(this.pbxUnderArrow, "pbxUnderArrow");
            this.pbxUnderArrow.BackgroundImage = null;
            this.pbxUnderArrow.Font = null;
            this.pbxUnderArrow.ImageLocation = null;
            this.pbxUnderArrow.Name = "pbxUnderArrow";
            this.pbxUnderArrow.TabStop = false;
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            resources.ApplyResources(this.grdOCS1003, "grdOCS1003");
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell145,
            this.xEditGridCell19,
            this.xEditGridCell102,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell134,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell135,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell136,
            this.xEditGridCell28,
            this.xEditGridCell137,
            this.xEditGridCell29,
            this.xEditGridCell163,
            this.xEditGridCell164,
            this.xEditGridCell165,
            this.xEditGridCell166,
            this.xEditGridCell173,
            this.xEditGridCell30,
            this.xEditGridCell140,
            this.xEditGridCell141,
            this.xEditGridCell32,
            this.xEditGridCell33,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell40,
            this.xEditGridCell41,
            this.xEditGridCell167,
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
            this.xEditGridCell52,
            this.xEditGridCell53,
            this.xEditGridCell54,
            this.xEditGridCell55,
            this.xEditGridCell56,
            this.xEditGridCell59,
            this.xEditGridCell64,
            this.xEditGridCell65,
            this.xEditGridCell66,
            this.xEditGridCell67,
            this.xEditGridCell139,
            this.xEditGridCell94,
            this.xEditGridCell68,
            this.xEditGridCell153,
            this.xEditGridCell154,
            this.xEditGridCell155,
            this.xEditGridCell156,
            this.xEditGridCell169,
            this.xEditGridCell170,
            this.xEditGridCell69,
            this.xEditGridCell70,
            this.xEditGridCell71,
            this.xEditGridCell72,
            this.xEditGridCell73,
            this.xEditGridCell76,
            this.xEditGridCell77,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell83,
            this.xEditGridCell128,
            this.xEditGridCell84,
            this.xEditGridCell85,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell87,
            this.xEditGridCell88,
            this.xEditGridCell89,
            this.xEditGridCell92,
            this.xEditGridCell93,
            this.xEditGridCell132,
            this.xEditGridCell171,
            this.xEditGridCell172,
            this.xEditGridCell176,
            this.xEditGridCell177,
            this.xEditGridCell178,
            this.xEditGridCell180,
            this.xEditGridCell181,
            this.xEditGridCell10,
            this.xEditGridCell133,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell31,
            this.xEditGridCell18,
            this.xEditGridCell75,
            this.xEditGridCell79,
            this.xEditGridCell86,
            this.xEditGridCell90,
            this.xEditGridCell91,
            this.xEditGridCell96,
            this.xEditGridCell131,
            this.xEditGridCell97,
            this.xEditGridCell138,
            this.xEditGridCell143,
            this.xEditGridCell144,
            this.xEditGridCell148,
            this.xEditGridCell151});
            this.grdOCS1003.ColPerLine = 34;
            this.grdOCS1003.ColResizable = true;
            this.grdOCS1003.Cols = 35;
            this.grdOCS1003.ControlBinding = true;
            this.grdOCS1003.EnableMultiSelection = true;
            this.grdOCS1003.ExecuteQuery = null;
            this.grdOCS1003.FixedCols = 1;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(32);
            this.grdOCS1003.HeaderHeights.Add(0);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdOCS1003.ParamList")));
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdOCS1003.RowHeaderVisible = true;
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdOCS1003_GridColumnChanged);
            this.grdOCS1003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdOCS1003_QueryEnd);
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
            this.grdOCS1003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdOCS1003_RowFocusChanged);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            this.grdOCS1003.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1003_GridColumnProtectModify);
            this.grdOCS1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdOCS1003_QueryStarting);
            // 
            // xEditGridCell145
            // 
            this.xEditGridCell145.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.CellName = "input_gubun_name";
            this.xEditGridCell145.CellWidth = 89;
            this.xEditGridCell145.Col = 4;
            this.xEditGridCell145.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell145, "xEditGridCell145");
            this.xEditGridCell145.IsUpdatable = false;
            this.xEditGridCell145.RowSpan = 2;
            this.xEditGridCell145.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell145.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell145.SuppressRepeating = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.CellName = "group_ser";
            this.xEditGridCell19.CellWidth = 34;
            this.xEditGridCell19.Col = 6;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell19.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell19.SuppressRepeating = true;
            // 
            // xEditGridCell102
            // 
            this.xEditGridCell102.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.CellName = "order_gubun_name";
            this.xEditGridCell102.CellWidth = 124;
            this.xEditGridCell102.Col = 5;
            this.xEditGridCell102.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell102, "xEditGridCell102");
            this.xEditGridCell102.IsUpdatable = false;
            this.xEditGridCell102.RowSpan = 2;
            this.xEditGridCell102.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell102.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell102.SuppressRepeating = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.CellName = "hangmog_code";
            this.xEditGridCell20.CellWidth = 115;
            this.xEditGridCell20.Col = 11;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowSpan = 2;
            this.xEditGridCell20.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.CellLen = 50;
            this.xEditGridCell21.CellName = "hangmog_name";
            this.xEditGridCell21.CellWidth = 196;
            this.xEditGridCell21.Col = 12;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowSpan = 2;
            this.xEditGridCell21.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell21.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell134
            // 
            this.xEditGridCell134.CellName = "specimen_code";
            this.xEditGridCell134.Col = -1;
            this.xEditGridCell134.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell134, "xEditGridCell134");
            this.xEditGridCell134.IsUpdatable = false;
            this.xEditGridCell134.IsVisible = false;
            this.xEditGridCell134.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.CellName = "specimen_name";
            this.xEditGridCell22.CellWidth = 60;
            this.xEditGridCell22.Col = 22;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell22.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.CellName = "suryang";
            this.xEditGridCell23.CellWidth = 58;
            this.xEditGridCell23.Col = 14;
            this.xEditGridCell23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell23.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell23.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.MaxDropDownItems = 9;
            this.xEditGridCell23.RowSpan = 2;
            this.xEditGridCell23.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell23.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell23.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell135
            // 
            this.xEditGridCell135.CellName = "ord_danui";
            this.xEditGridCell135.Col = -1;
            this.xEditGridCell135.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell135, "xEditGridCell135");
            this.xEditGridCell135.IsUpdatable = false;
            this.xEditGridCell135.IsVisible = false;
            this.xEditGridCell135.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.CellName = "ord_danui_name";
            this.xEditGridCell24.CellWidth = 49;
            this.xEditGridCell24.Col = 15;
            this.xEditGridCell24.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.RowSpan = 2;
            this.xEditGridCell24.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell24.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.CellName = "dv_time";
            this.xEditGridCell25.CellWidth = 21;
            this.xEditGridCell25.Col = 16;
            this.xEditGridCell25.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.Row = 1;
            this.xEditGridCell25.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.CellName = "dv";
            this.xEditGridCell26.CellWidth = 28;
            this.xEditGridCell26.Col = 17;
            this.xEditGridCell26.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell26.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell26.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.Row = 1;
            this.xEditGridCell26.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell26.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell26.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.CellName = "nalsu";
            this.xEditGridCell27.CellWidth = 51;
            this.xEditGridCell27.Col = 18;
            this.xEditGridCell27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.xEditGridCell27.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell27.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.MaxDropDownItems = 12;
            this.xEditGridCell27.RowSpan = 2;
            this.xEditGridCell27.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell27.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell27.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell136
            // 
            this.xEditGridCell136.CellName = "jusa";
            this.xEditGridCell136.Col = -1;
            this.xEditGridCell136.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell136, "xEditGridCell136");
            this.xEditGridCell136.IsUpdatable = false;
            this.xEditGridCell136.IsVisible = false;
            this.xEditGridCell136.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.CellName = "jusa_name";
            this.xEditGridCell28.CellWidth = 78;
            this.xEditGridCell28.Col = 19;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell28.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsUpdatable = false;
            this.xEditGridCell28.RowSpan = 2;
            this.xEditGridCell28.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell28.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell137
            // 
            this.xEditGridCell137.CellName = "bogyong_code";
            this.xEditGridCell137.Col = -1;
            this.xEditGridCell137.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell137, "xEditGridCell137");
            this.xEditGridCell137.IsUpdatable = false;
            this.xEditGridCell137.IsVisible = false;
            this.xEditGridCell137.Row = -1;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.CellName = "bogyong_name";
            this.xEditGridCell29.CellWidth = 77;
            this.xEditGridCell29.Col = 21;
            this.xEditGridCell29.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.RowSpan = 2;
            this.xEditGridCell29.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell29.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell29.SuppressRepeating = true;
            // 
            // xEditGridCell163
            // 
            this.xEditGridCell163.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.CellName = "jusa_spd_gubun";
            this.xEditGridCell163.CellWidth = 42;
            this.xEditGridCell163.Col = 20;
            this.xEditGridCell163.EditorStyle = IHIS.Framework.XCellEditorStyle.ListBox;
            this.xEditGridCell163.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell163, "xEditGridCell163");
            this.xEditGridCell163.IsUpdatable = false;
            this.xEditGridCell163.RowSpan = 2;
            this.xEditGridCell163.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell163.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell164
            // 
            this.xEditGridCell164.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.CellName = "hubal_change_yn";
            this.xEditGridCell164.CellWidth = 137;
            this.xEditGridCell164.Col = 31;
            this.xEditGridCell164.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell164.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell164, "xEditGridCell164");
            this.xEditGridCell164.IsUpdatable = false;
            this.xEditGridCell164.RowSpan = 2;
            this.xEditGridCell164.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell164.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell165
            // 
            this.xEditGridCell165.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.CellName = "pharmacy";
            this.xEditGridCell165.CellWidth = 55;
            this.xEditGridCell165.Col = 29;
            this.xEditGridCell165.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell165.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell165, "xEditGridCell165");
            this.xEditGridCell165.IsUpdatable = false;
            this.xEditGridCell165.RowSpan = 2;
            this.xEditGridCell165.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell165.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell166
            // 
            this.xEditGridCell166.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.CellName = "drg_pack_yn";
            this.xEditGridCell166.CellWidth = 95;
            this.xEditGridCell166.Col = 28;
            this.xEditGridCell166.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell166.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell166, "xEditGridCell166");
            this.xEditGridCell166.IsUpdatable = false;
            this.xEditGridCell166.RowSpan = 2;
            this.xEditGridCell166.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell166.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell173
            // 
            this.xEditGridCell173.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.CellName = "powder_yn";
            this.xEditGridCell173.CellWidth = 144;
            this.xEditGridCell173.Col = 30;
            this.xEditGridCell173.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell173.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell173, "xEditGridCell173");
            this.xEditGridCell173.IsUpdatable = false;
            this.xEditGridCell173.RowSpan = 2;
            this.xEditGridCell173.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell173.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.CellName = "wonyoi_order_yn";
            this.xEditGridCell30.CellWidth = 126;
            this.xEditGridCell30.Col = 26;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell30.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsUpdatable = false;
            this.xEditGridCell30.RowSpan = 2;
            this.xEditGridCell30.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell30.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell140
            // 
            this.xEditGridCell140.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.CellName = "dangil_gumsa_order_yn";
            this.xEditGridCell140.CellWidth = 118;
            this.xEditGridCell140.Col = 24;
            this.xEditGridCell140.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell140.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell140, "xEditGridCell140");
            this.xEditGridCell140.IsUpdatable = false;
            this.xEditGridCell140.RowSpan = 2;
            this.xEditGridCell140.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell140.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell141
            // 
            this.xEditGridCell141.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.CellName = "dangil_gumsa_result_yn";
            this.xEditGridCell141.CellWidth = 131;
            this.xEditGridCell141.Col = 23;
            this.xEditGridCell141.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell141.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell141, "xEditGridCell141");
            this.xEditGridCell141.IsUpdatable = false;
            this.xEditGridCell141.RowSpan = 2;
            this.xEditGridCell141.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell141.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.CellName = "emergency";
            this.xEditGridCell32.CellWidth = 86;
            this.xEditGridCell32.Col = 25;
            this.xEditGridCell32.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell32.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsUpdatable = false;
            this.xEditGridCell32.RowSpan = 2;
            this.xEditGridCell32.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell32.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.CellName = "pay";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsUpdatable = false;
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell33.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell33.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.CellName = "anti_cancer_yn";
            this.xEditGridCell36.Col = -1;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsUpdatable = false;
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            this.xEditGridCell36.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell36.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.CellName = "muhyo";
            this.xEditGridCell37.Col = -1;
            this.xEditGridCell37.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsUpdatable = false;
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.CellName = "portable_yn";
            this.xEditGridCell38.Col = -1;
            this.xEditGridCell38.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.IsUpdatable = false;
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            this.xEditGridCell38.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell38.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell40
            // 
            this.xEditGridCell40.CellName = "ocs_flag";
            this.xEditGridCell40.Col = -1;
            this.xEditGridCell40.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell40, "xEditGridCell40");
            this.xEditGridCell40.IsUpdatable = false;
            this.xEditGridCell40.IsVisible = false;
            this.xEditGridCell40.Row = -1;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellName = "order_gubun";
            this.xEditGridCell41.Col = -1;
            this.xEditGridCell41.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell41, "xEditGridCell41");
            this.xEditGridCell41.IsUpdatable = false;
            this.xEditGridCell41.IsVisible = false;
            this.xEditGridCell41.Row = -1;
            // 
            // xEditGridCell167
            // 
            this.xEditGridCell167.CellName = "input_tab";
            this.xEditGridCell167.Col = -1;
            this.xEditGridCell167.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell167, "xEditGridCell167");
            this.xEditGridCell167.IsUpdatable = false;
            this.xEditGridCell167.IsVisible = false;
            this.xEditGridCell167.Row = -1;
            // 
            // xEditGridCell42
            // 
            this.xEditGridCell42.CellName = "input_gubun";
            this.xEditGridCell42.Col = -1;
            this.xEditGridCell42.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell42, "xEditGridCell42");
            this.xEditGridCell42.IsUpdatable = false;
            this.xEditGridCell42.IsVisible = false;
            this.xEditGridCell42.Row = -1;
            // 
            // xEditGridCell43
            // 
            this.xEditGridCell43.CellName = "after_act_yn";
            this.xEditGridCell43.Col = -1;
            this.xEditGridCell43.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell43, "xEditGridCell43");
            this.xEditGridCell43.IsUpdatable = false;
            this.xEditGridCell43.IsVisible = false;
            this.xEditGridCell43.Row = -1;
            // 
            // xEditGridCell44
            // 
            this.xEditGridCell44.CellName = "jundal_table";
            this.xEditGridCell44.Col = -1;
            this.xEditGridCell44.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell44, "xEditGridCell44");
            this.xEditGridCell44.IsUpdatable = false;
            this.xEditGridCell44.IsVisible = false;
            this.xEditGridCell44.Row = -1;
            // 
            // xEditGridCell45
            // 
            this.xEditGridCell45.CellName = "jundal_part";
            this.xEditGridCell45.Col = -1;
            this.xEditGridCell45.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell45, "xEditGridCell45");
            this.xEditGridCell45.IsUpdatable = false;
            this.xEditGridCell45.IsVisible = false;
            this.xEditGridCell45.Row = -1;
            // 
            // xEditGridCell46
            // 
            this.xEditGridCell46.CellName = "move_part";
            this.xEditGridCell46.Col = -1;
            this.xEditGridCell46.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell46, "xEditGridCell46");
            this.xEditGridCell46.IsUpdatable = false;
            this.xEditGridCell46.IsVisible = false;
            this.xEditGridCell46.Row = -1;
            // 
            // xEditGridCell47
            // 
            this.xEditGridCell47.CellName = "bunho";
            this.xEditGridCell47.Col = -1;
            this.xEditGridCell47.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell47, "xEditGridCell47");
            this.xEditGridCell47.IsUpdatable = false;
            this.xEditGridCell47.IsVisible = false;
            this.xEditGridCell47.Row = -1;
            // 
            // xEditGridCell48
            // 
            this.xEditGridCell48.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.CellName = "naewon_date";
            this.xEditGridCell48.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell48.CellWidth = 83;
            this.xEditGridCell48.Col = 3;
            this.xEditGridCell48.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell48, "xEditGridCell48");
            this.xEditGridCell48.IsUpdatable = false;
            this.xEditGridCell48.RowSpan = 2;
            this.xEditGridCell48.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell48.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell49
            // 
            this.xEditGridCell49.CellName = "gwa";
            this.xEditGridCell49.Col = -1;
            this.xEditGridCell49.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell49, "xEditGridCell49");
            this.xEditGridCell49.IsUpdatable = false;
            this.xEditGridCell49.IsVisible = false;
            this.xEditGridCell49.Row = -1;
            // 
            // xEditGridCell50
            // 
            this.xEditGridCell50.CellName = "doctor";
            this.xEditGridCell50.Col = -1;
            this.xEditGridCell50.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell50, "xEditGridCell50");
            this.xEditGridCell50.IsUpdatable = false;
            this.xEditGridCell50.IsVisible = false;
            this.xEditGridCell50.Row = -1;
            // 
            // xEditGridCell51
            // 
            this.xEditGridCell51.CellName = "naewon_type";
            this.xEditGridCell51.Col = -1;
            this.xEditGridCell51.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell51, "xEditGridCell51");
            this.xEditGridCell51.IsUpdatable = false;
            this.xEditGridCell51.IsVisible = false;
            this.xEditGridCell51.Row = -1;
            // 
            // xEditGridCell52
            // 
            this.xEditGridCell52.CellName = "pk_order";
            this.xEditGridCell52.Col = -1;
            this.xEditGridCell52.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell52, "xEditGridCell52");
            this.xEditGridCell52.IsUpdatable = false;
            this.xEditGridCell52.IsVisible = false;
            this.xEditGridCell52.Row = -1;
            // 
            // xEditGridCell53
            // 
            this.xEditGridCell53.CellName = "seq";
            this.xEditGridCell53.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell53.Col = -1;
            this.xEditGridCell53.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell53, "xEditGridCell53");
            this.xEditGridCell53.IsUpdatable = false;
            this.xEditGridCell53.IsVisible = false;
            this.xEditGridCell53.Row = -1;
            // 
            // xEditGridCell54
            // 
            this.xEditGridCell54.CellName = "pkocs1003";
            this.xEditGridCell54.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell54.Col = -1;
            this.xEditGridCell54.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell54, "xEditGridCell54");
            this.xEditGridCell54.IsUpdatable = false;
            this.xEditGridCell54.IsVisible = false;
            this.xEditGridCell54.Row = -1;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "sub_susul";
            this.xEditGridCell55.Col = -1;
            this.xEditGridCell55.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell55, "xEditGridCell55");
            this.xEditGridCell55.IsUpdatable = false;
            this.xEditGridCell55.IsVisible = false;
            this.xEditGridCell55.Row = -1;
            // 
            // xEditGridCell56
            // 
            this.xEditGridCell56.CellName = "sutak_yn";
            this.xEditGridCell56.Col = -1;
            this.xEditGridCell56.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell56, "xEditGridCell56");
            this.xEditGridCell56.IsUpdatable = false;
            this.xEditGridCell56.IsVisible = false;
            this.xEditGridCell56.Row = -1;
            // 
            // xEditGridCell59
            // 
            this.xEditGridCell59.CellName = "amt";
            this.xEditGridCell59.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell59.Col = -1;
            this.xEditGridCell59.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell59, "xEditGridCell59");
            this.xEditGridCell59.IsUpdatable = false;
            this.xEditGridCell59.IsVisible = false;
            this.xEditGridCell59.Row = -1;
            // 
            // xEditGridCell64
            // 
            this.xEditGridCell64.CellName = "dv_1";
            this.xEditGridCell64.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell64.Col = -1;
            this.xEditGridCell64.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell64, "xEditGridCell64");
            this.xEditGridCell64.IsUpdatable = false;
            this.xEditGridCell64.IsVisible = false;
            this.xEditGridCell64.Row = -1;
            // 
            // xEditGridCell65
            // 
            this.xEditGridCell65.CellName = "dv_2";
            this.xEditGridCell65.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell65.Col = -1;
            this.xEditGridCell65.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell65, "xEditGridCell65");
            this.xEditGridCell65.IsUpdatable = false;
            this.xEditGridCell65.IsVisible = false;
            this.xEditGridCell65.Row = -1;
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "dv_3";
            this.xEditGridCell66.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell66, "xEditGridCell66");
            this.xEditGridCell66.IsUpdatable = false;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell67
            // 
            this.xEditGridCell67.CellName = "dv_4";
            this.xEditGridCell67.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell67.Col = -1;
            this.xEditGridCell67.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell67, "xEditGridCell67");
            this.xEditGridCell67.IsUpdatable = false;
            this.xEditGridCell67.IsVisible = false;
            this.xEditGridCell67.Row = -1;
            // 
            // xEditGridCell139
            // 
            this.xEditGridCell139.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.CellName = "hope_date";
            this.xEditGridCell139.CellWidth = 131;
            this.xEditGridCell139.Col = 8;
            this.xEditGridCell139.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell139.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell139, "xEditGridCell139");
            this.xEditGridCell139.RowSpan = 2;
            this.xEditGridCell139.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell139.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell94
            // 
            this.xEditGridCell94.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.CellName = "order_remark";
            this.xEditGridCell94.CellWidth = 126;
            this.xEditGridCell94.Col = 27;
            this.xEditGridCell94.DisplayMemoText = true;
            this.xEditGridCell94.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell94.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell94, "xEditGridCell94");
            this.xEditGridCell94.IsUpdatable = false;
            this.xEditGridCell94.RowSpan = 2;
            this.xEditGridCell94.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell94.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell68
            // 
            this.xEditGridCell68.CellName = "mix_group";
            this.xEditGridCell68.Col = -1;
            this.xEditGridCell68.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell68, "xEditGridCell68");
            this.xEditGridCell68.IsUpdatable = false;
            this.xEditGridCell68.IsVisible = false;
            this.xEditGridCell68.Row = -1;
            // 
            // xEditGridCell153
            // 
            this.xEditGridCell153.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.CellName = "home_care_yn";
            this.xEditGridCell153.CellWidth = 65;
            this.xEditGridCell153.Col = 32;
            this.xEditGridCell153.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell153.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell153, "xEditGridCell153");
            this.xEditGridCell153.IsUpdatable = false;
            this.xEditGridCell153.RowSpan = 2;
            this.xEditGridCell153.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell153.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell154
            // 
            this.xEditGridCell154.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.CellName = "regular_yn";
            this.xEditGridCell154.CellWidth = 105;
            this.xEditGridCell154.Col = 9;
            this.xEditGridCell154.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem7,
            this.xComboItem8});
            this.xEditGridCell154.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell154.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell154, "xEditGridCell154");
            this.xEditGridCell154.IsUpdatable = false;
            this.xEditGridCell154.RowSpan = 2;
            this.xEditGridCell154.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell154.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            this.xEditGridCell154.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "Y";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "N";
            // 
            // xEditGridCell155
            // 
            this.xEditGridCell155.CellName = "gongbi_code";
            this.xEditGridCell155.Col = -1;
            this.xEditGridCell155.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell155, "xEditGridCell155");
            this.xEditGridCell155.IsUpdatable = false;
            this.xEditGridCell155.IsVisible = false;
            this.xEditGridCell155.Row = -1;
            // 
            // xEditGridCell156
            // 
            this.xEditGridCell156.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.CellName = "gongbi_name";
            this.xEditGridCell156.Col = -1;
            this.xEditGridCell156.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell156, "xEditGridCell156");
            this.xEditGridCell156.IsUpdatable = false;
            this.xEditGridCell156.IsVisible = false;
            this.xEditGridCell156.Row = -1;
            this.xEditGridCell156.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell156.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell169
            // 
            this.xEditGridCell169.CellName = "donbog_yn";
            this.xEditGridCell169.Col = -1;
            this.xEditGridCell169.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell169, "xEditGridCell169");
            this.xEditGridCell169.IsUpdatable = false;
            this.xEditGridCell169.IsVisible = false;
            this.xEditGridCell169.Row = -1;
            // 
            // xEditGridCell170
            // 
            this.xEditGridCell170.CellName = "dv_name";
            this.xEditGridCell170.Col = -1;
            this.xEditGridCell170.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell170, "xEditGridCell170");
            this.xEditGridCell170.IsUpdatable = false;
            this.xEditGridCell170.IsVisible = false;
            this.xEditGridCell170.Row = -1;
            // 
            // xEditGridCell69
            // 
            this.xEditGridCell69.CellName = "slip_code";
            this.xEditGridCell69.Col = -1;
            this.xEditGridCell69.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell69, "xEditGridCell69");
            this.xEditGridCell69.IsUpdatable = false;
            this.xEditGridCell69.IsVisible = false;
            this.xEditGridCell69.Row = -1;
            // 
            // xEditGridCell70
            // 
            this.xEditGridCell70.CellName = "group_yn";
            this.xEditGridCell70.Col = -1;
            this.xEditGridCell70.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell70, "xEditGridCell70");
            this.xEditGridCell70.IsUpdatable = false;
            this.xEditGridCell70.IsVisible = false;
            this.xEditGridCell70.Row = -1;
            // 
            // xEditGridCell71
            // 
            this.xEditGridCell71.CellName = "sg_code";
            this.xEditGridCell71.Col = -1;
            this.xEditGridCell71.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell71, "xEditGridCell71");
            this.xEditGridCell71.IsUpdatable = false;
            this.xEditGridCell71.IsVisible = false;
            this.xEditGridCell71.Row = -1;
            // 
            // xEditGridCell72
            // 
            this.xEditGridCell72.CellName = "order_gubun_bas";
            this.xEditGridCell72.Col = -1;
            this.xEditGridCell72.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell72, "xEditGridCell72");
            this.xEditGridCell72.IsUpdatable = false;
            this.xEditGridCell72.IsVisible = false;
            this.xEditGridCell72.Row = -1;
            // 
            // xEditGridCell73
            // 
            this.xEditGridCell73.CellName = "input_control";
            this.xEditGridCell73.Col = -1;
            this.xEditGridCell73.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell73, "xEditGridCell73");
            this.xEditGridCell73.IsUpdatable = false;
            this.xEditGridCell73.IsVisible = false;
            this.xEditGridCell73.Row = -1;
            // 
            // xEditGridCell76
            // 
            this.xEditGridCell76.CellName = "suga_yn";
            this.xEditGridCell76.Col = -1;
            this.xEditGridCell76.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell76, "xEditGridCell76");
            this.xEditGridCell76.IsUpdatable = false;
            this.xEditGridCell76.IsVisible = false;
            this.xEditGridCell76.Row = -1;
            // 
            // xEditGridCell77
            // 
            this.xEditGridCell77.CellName = "emergency_check";
            this.xEditGridCell77.Col = -1;
            this.xEditGridCell77.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell77, "xEditGridCell77");
            this.xEditGridCell77.IsUpdatable = false;
            this.xEditGridCell77.IsVisible = false;
            this.xEditGridCell77.Row = -1;
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "limit_suryang";
            this.xEditGridCell80.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell80.Col = -1;
            this.xEditGridCell80.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell80, "xEditGridCell80");
            this.xEditGridCell80.IsUpdatable = false;
            this.xEditGridCell80.IsVisible = false;
            this.xEditGridCell80.Row = -1;
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "specimen_yn";
            this.xEditGridCell81.Col = -1;
            this.xEditGridCell81.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell81, "xEditGridCell81");
            this.xEditGridCell81.IsUpdatable = false;
            this.xEditGridCell81.IsVisible = false;
            this.xEditGridCell81.Row = -1;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "jaeryo_yn";
            this.xEditGridCell82.Col = -1;
            this.xEditGridCell82.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell82, "xEditGridCell82");
            this.xEditGridCell82.IsUpdatable = false;
            this.xEditGridCell82.IsVisible = false;
            this.xEditGridCell82.Row = -1;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ord_danui_check";
            this.xEditGridCell83.Col = -1;
            this.xEditGridCell83.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell83, "xEditGridCell83");
            this.xEditGridCell83.IsUpdatable = false;
            this.xEditGridCell83.IsVisible = false;
            this.xEditGridCell83.Row = -1;
            // 
            // xEditGridCell128
            // 
            this.xEditGridCell128.CellName = "ord_danui_bas";
            this.xEditGridCell128.Col = -1;
            this.xEditGridCell128.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell128, "xEditGridCell128");
            this.xEditGridCell128.IsUpdatable = false;
            this.xEditGridCell128.IsVisible = false;
            this.xEditGridCell128.Row = -1;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "jundal_table_out";
            this.xEditGridCell84.Col = -1;
            this.xEditGridCell84.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell84, "xEditGridCell84");
            this.xEditGridCell84.IsUpdatable = false;
            this.xEditGridCell84.IsVisible = false;
            this.xEditGridCell84.Row = -1;
            // 
            // xEditGridCell85
            // 
            this.xEditGridCell85.CellName = "jundal_part_out";
            this.xEditGridCell85.Col = -1;
            this.xEditGridCell85.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell85, "xEditGridCell85");
            this.xEditGridCell85.IsUpdatable = false;
            this.xEditGridCell85.IsVisible = false;
            this.xEditGridCell85.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "move_part_out";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "jundal_table_inp";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "jundal_part_inp";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "move_part_inp";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell87
            // 
            this.xEditGridCell87.CellName = "bulyong_check";
            this.xEditGridCell87.Col = -1;
            this.xEditGridCell87.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell87, "xEditGridCell87");
            this.xEditGridCell87.IsUpdatable = false;
            this.xEditGridCell87.IsVisible = false;
            this.xEditGridCell87.Row = -1;
            // 
            // xEditGridCell88
            // 
            this.xEditGridCell88.CellName = "wonyoi_order_cr_yn";
            this.xEditGridCell88.Col = -1;
            this.xEditGridCell88.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell88, "xEditGridCell88");
            this.xEditGridCell88.IsUpdatable = false;
            this.xEditGridCell88.IsVisible = false;
            this.xEditGridCell88.Row = -1;
            // 
            // xEditGridCell89
            // 
            this.xEditGridCell89.CellName = "default_wonyoi_order_yn";
            this.xEditGridCell89.Col = -1;
            this.xEditGridCell89.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell89, "xEditGridCell89");
            this.xEditGridCell89.IsUpdatable = false;
            this.xEditGridCell89.IsVisible = false;
            this.xEditGridCell89.Row = -1;
            // 
            // xEditGridCell92
            // 
            this.xEditGridCell92.CellName = "nday_yn";
            this.xEditGridCell92.Col = -1;
            this.xEditGridCell92.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell92, "xEditGridCell92");
            this.xEditGridCell92.IsUpdatable = false;
            this.xEditGridCell92.IsVisible = false;
            this.xEditGridCell92.Row = -1;
            // 
            // xEditGridCell93
            // 
            this.xEditGridCell93.CellName = "muhyo_yn";
            this.xEditGridCell93.Col = -1;
            this.xEditGridCell93.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell93, "xEditGridCell93");
            this.xEditGridCell93.IsUpdatable = false;
            this.xEditGridCell93.IsVisible = false;
            this.xEditGridCell93.Row = -1;
            // 
            // xEditGridCell132
            // 
            this.xEditGridCell132.CellName = "tel_yn";
            this.xEditGridCell132.Col = -1;
            this.xEditGridCell132.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell132, "xEditGridCell132");
            this.xEditGridCell132.IsUpdatable = false;
            this.xEditGridCell132.IsVisible = false;
            this.xEditGridCell132.Row = -1;
            // 
            // xEditGridCell171
            // 
            this.xEditGridCell171.BindControl = this.txtDrg_info;
            this.xEditGridCell171.CellName = "drg_info";
            this.xEditGridCell171.Col = -1;
            this.xEditGridCell171.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell171, "xEditGridCell171");
            this.xEditGridCell171.IsReadOnly = true;
            this.xEditGridCell171.IsUpdatable = false;
            this.xEditGridCell171.IsVisible = false;
            this.xEditGridCell171.Row = -1;
            // 
            // txtDrg_info
            // 
            this.txtDrg_info.AccessibleDescription = null;
            this.txtDrg_info.AccessibleName = null;
            resources.ApplyResources(this.txtDrg_info, "txtDrg_info");
            this.txtDrg_info.BackgroundImage = null;
            this.txtDrg_info.Name = "txtDrg_info";
            this.txtDrg_info.Protect = true;
            this.txtDrg_info.ReadOnly = true;
            this.txtDrg_info.TabStop = false;
            // 
            // xEditGridCell172
            // 
            this.xEditGridCell172.CellName = "drg_bunryu";
            this.xEditGridCell172.Col = -1;
            this.xEditGridCell172.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell172, "xEditGridCell172");
            this.xEditGridCell172.IsReadOnly = true;
            this.xEditGridCell172.IsUpdatable = false;
            this.xEditGridCell172.IsVisible = false;
            this.xEditGridCell172.Row = -1;
            // 
            // xEditGridCell176
            // 
            this.xEditGridCell176.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell176.CellName = "child_yn";
            this.xEditGridCell176.CellWidth = 22;
            this.xEditGridCell176.Col = 2;
            this.xEditGridCell176.ExecuteQuery = null;
            this.xEditGridCell176.HeaderForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            resources.ApplyResources(this.xEditGridCell176, "xEditGridCell176");
            this.xEditGridCell176.IsUpdatable = false;
            this.xEditGridCell176.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell176.RowSpan = 2;
            this.xEditGridCell176.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell177
            // 
            this.xEditGridCell177.CellName = "bom_source_key";
            this.xEditGridCell177.Col = -1;
            this.xEditGridCell177.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell177, "xEditGridCell177");
            this.xEditGridCell177.IsUpdatable = false;
            this.xEditGridCell177.IsVisible = false;
            this.xEditGridCell177.Row = -1;
            // 
            // xEditGridCell178
            // 
            this.xEditGridCell178.CellName = "bom_occur_yn";
            this.xEditGridCell178.Col = -1;
            this.xEditGridCell178.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell178, "xEditGridCell178");
            this.xEditGridCell178.IsUpdatable = false;
            this.xEditGridCell178.IsVisible = false;
            this.xEditGridCell178.Row = -1;
            // 
            // xEditGridCell180
            // 
            this.xEditGridCell180.CellName = "org_key";
            this.xEditGridCell180.Col = -1;
            this.xEditGridCell180.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell180, "xEditGridCell180");
            this.xEditGridCell180.IsUpdatable = false;
            this.xEditGridCell180.IsVisible = false;
            this.xEditGridCell180.Row = -1;
            // 
            // xEditGridCell181
            // 
            this.xEditGridCell181.CellName = "parent_key";
            this.xEditGridCell181.Col = -1;
            this.xEditGridCell181.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell181, "xEditGridCell181");
            this.xEditGridCell181.IsUpdatable = false;
            this.xEditGridCell181.IsVisible = false;
            this.xEditGridCell181.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "bun_code";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell133
            // 
            this.xEditGridCell133.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell133.CellName = "cont_key";
            this.xEditGridCell133.Col = -1;
            this.xEditGridCell133.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell133, "xEditGridCell133");
            this.xEditGridCell133.IsUpdatable = false;
            this.xEditGridCell133.IsVisible = false;
            this.xEditGridCell133.Row = -1;
            this.xEditGridCell133.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "fk_key1001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "wonnae_drg_yn";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dc_yn";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.CellName = "result_date";
            this.xEditGridCell31.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsUpdatable = false;
            this.xEditGridCell31.IsUpdCol = false;
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "confirm_check";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsUpdCol = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell75
            // 
            this.xEditGridCell75.CellName = "sunab_check";
            this.xEditGridCell75.Col = -1;
            this.xEditGridCell75.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell75, "xEditGridCell75");
            this.xEditGridCell75.IsUpdatable = false;
            this.xEditGridCell75.IsVisible = false;
            this.xEditGridCell75.Row = -1;
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "dv_5";
            this.xEditGridCell79.Col = -1;
            this.xEditGridCell79.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell79, "xEditGridCell79");
            this.xEditGridCell79.IsUpdatable = false;
            this.xEditGridCell79.IsVisible = false;
            this.xEditGridCell79.Row = -1;
            // 
            // xEditGridCell86
            // 
            this.xEditGridCell86.CellName = "dv_6";
            this.xEditGridCell86.Col = -1;
            this.xEditGridCell86.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell86, "xEditGridCell86");
            this.xEditGridCell86.IsUpdatable = false;
            this.xEditGridCell86.IsVisible = false;
            this.xEditGridCell86.Row = -1;
            // 
            // xEditGridCell90
            // 
            this.xEditGridCell90.CellName = "dv_7";
            this.xEditGridCell90.Col = -1;
            this.xEditGridCell90.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell90, "xEditGridCell90");
            this.xEditGridCell90.IsUpdatable = false;
            this.xEditGridCell90.IsVisible = false;
            this.xEditGridCell90.Row = -1;
            // 
            // xEditGridCell91
            // 
            this.xEditGridCell91.CellName = "dv_8";
            this.xEditGridCell91.Col = -1;
            this.xEditGridCell91.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell91, "xEditGridCell91");
            this.xEditGridCell91.IsUpdatable = false;
            this.xEditGridCell91.IsVisible = false;
            this.xEditGridCell91.Row = -1;
            // 
            // xEditGridCell96
            // 
            this.xEditGridCell96.CellName = "general_disp_yn";
            this.xEditGridCell96.CellWidth = 166;
            this.xEditGridCell96.Col = 13;
            this.xEditGridCell96.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem5,
            this.xComboItem6});
            this.xEditGridCell96.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell96.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell96, "xEditGridCell96");
            this.xEditGridCell96.IsReadOnly = true;
            this.xEditGridCell96.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "Y";
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "N";
            // 
            // xEditGridCell131
            // 
            this.xEditGridCell131.CellLen = 50;
            this.xEditGridCell131.CellName = "generic_name";
            this.xEditGridCell131.Col = -1;
            this.xEditGridCell131.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell131, "xEditGridCell131");
            this.xEditGridCell131.IsVisible = false;
            this.xEditGridCell131.Row = -1;
            // 
            // xEditGridCell97
            // 
            this.xEditGridCell97.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.AlterateRowImageIndex = 0;
            this.xEditGridCell97.CellName = "select";
            this.xEditGridCell97.CellWidth = 31;
            this.xEditGridCell97.Col = 1;
            this.xEditGridCell97.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell97, "xEditGridCell97");
            this.xEditGridCell97.ImageList = this.ImageList;
            this.xEditGridCell97.IsUpdatable = false;
            this.xEditGridCell97.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell97.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell97.RowImageIndex = 0;
            this.xEditGridCell97.RowSpan = 2;
            this.xEditGridCell97.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell97.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell138
            // 
            this.xEditGridCell138.CellName = "bogyong_code_sub";
            this.xEditGridCell138.CellWidth = 114;
            this.xEditGridCell138.Col = 33;
            this.xEditGridCell138.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell138, "xEditGridCell138");
            this.xEditGridCell138.IsReadOnly = true;
            this.xEditGridCell138.RowSpan = 2;
            // 
            // xEditGridCell143
            // 
            this.xEditGridCell143.CellName = "bogyong_name_sub";
            this.xEditGridCell143.CellWidth = 90;
            this.xEditGridCell143.Col = 34;
            this.xEditGridCell143.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell143, "xEditGridCell143");
            this.xEditGridCell143.IsReadOnly = true;
            this.xEditGridCell143.RowSpan = 2;
            // 
            // xEditGridCell144
            // 
            this.xEditGridCell144.CellName = "ori_hope_date";
            this.xEditGridCell144.CellWidth = 153;
            this.xEditGridCell144.Col = 7;
            this.xEditGridCell144.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell144, "xEditGridCell144");
            this.xEditGridCell144.IsReadOnly = true;
            this.xEditGridCell144.RowSpan = 2;
            // 
            // xEditGridCell148
            // 
            this.xEditGridCell148.CellName = "io_yn";
            this.xEditGridCell148.Col = -1;
            this.xEditGridCell148.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell148, "xEditGridCell148");
            this.xEditGridCell148.IsVisible = false;
            this.xEditGridCell148.Row = -1;
            // 
            // xEditGridCell151
            // 
            this.xEditGridCell151.CellName = "brought_drg_yn";
            this.xEditGridCell151.CellWidth = 41;
            this.xEditGridCell151.Col = 10;
            this.xEditGridCell151.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell151.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell151.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell151, "xEditGridCell151");
            this.xEditGridCell151.IsReadOnly = true;
            this.xEditGridCell151.RowSpan = 2;
            this.xEditGridCell151.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
            this.xComboItem3.ValueItem = "Y";
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "N";
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 16;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            this.xGridHeader1.HeaderWidth = 21;
            this.xGridHeader1.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xGridHeader1.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.cbxGeneric_YN);
            this.xPanel4.Controls.Add(this.btnDeleteAll);
            this.xPanel4.Controls.Add(this.btnSelectAll);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // cbxGeneric_YN
            // 
            this.cbxGeneric_YN.AccessibleDescription = null;
            this.cbxGeneric_YN.AccessibleName = null;
            resources.ApplyResources(this.cbxGeneric_YN, "cbxGeneric_YN");
            this.cbxGeneric_YN.BackgroundImage = null;
            this.cbxGeneric_YN.Name = "cbxGeneric_YN";
            this.cbxGeneric_YN.UseVisualStyleBackColor = false;
            this.cbxGeneric_YN.CheckedChanged += new System.EventHandler(this.cbxGeneric_YN_CheckedChanged);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.AccessibleDescription = null;
            this.btnDeleteAll.AccessibleName = null;
            resources.ApplyResources(this.btnDeleteAll, "btnDeleteAll");
            this.btnDeleteAll.BackgroundImage = null;
            this.btnDeleteAll.Image = global::IHIS.OCSO.Properties.Resources.YESEN1;
            this.btnDeleteAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.AccessibleDescription = null;
            this.btnSelectAll.AccessibleName = null;
            resources.ApplyResources(this.btnSelectAll, "btnSelectAll");
            this.btnSelectAll.BackgroundImage = null;
            this.btnSelectAll.Image = global::IHIS.OCSO.Properties.Resources.YESUP1;
            this.btnSelectAll.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // grdSangInfo
            // 
            resources.ApplyResources(this.grdSangInfo, "grdSangInfo");
            this.grdSangInfo.ApplyPaintEventToAllColumn = true;
            this.grdSangInfo.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell34,
            this.xEditGridCell35,
            this.xEditGridCell39,
            this.xEditGridCell125,
            this.xEditGridCell57,
            this.xEditGridCell99,
            this.xEditGridCell100,
            this.xEditGridCell101,
            this.xEditGridCell58,
            this.xEditGridCell60,
            this.xEditGridCell61,
            this.xEditGridCell62,
            this.xEditGridCell63,
            this.xEditGridCell130,
            this.xEditGridCell74,
            this.xEditGridCell126,
            this.xEditGridCell103,
            this.xEditGridCell104,
            this.xEditGridCell105,
            this.xEditGridCell106,
            this.xEditGridCell107,
            this.xEditGridCell108,
            this.xEditGridCell109,
            this.xEditGridCell110,
            this.xEditGridCell111,
            this.xEditGridCell112,
            this.xEditGridCell113,
            this.xEditGridCell114,
            this.xEditGridCell115,
            this.xEditGridCell116,
            this.xEditGridCell117,
            this.xEditGridCell118,
            this.xEditGridCell119,
            this.xEditGridCell120,
            this.xEditGridCell121,
            this.xEditGridCell122,
            this.xEditGridCell123,
            this.xEditGridCell124,
            this.xEditGridCell98,
            this.xEditGridCell78});
            this.grdSangInfo.ColPerLine = 8;
            this.grdSangInfo.Cols = 9;
            this.grdSangInfo.EnableMultiSelection = true;
            this.grdSangInfo.ExecuteQuery = null;
            this.grdSangInfo.FixedCols = 1;
            this.grdSangInfo.FixedRows = 1;
            this.grdSangInfo.HeaderHeights.Add(29);
            this.grdSangInfo.Name = "grdSangInfo";
            this.grdSangInfo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSangInfo.ParamList")));
            this.grdSangInfo.QuerySQL = resources.GetString("grdSangInfo.QuerySQL");
            this.grdSangInfo.ReadOnly = true;
            this.grdSangInfo.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdSangInfo.RowHeaderVisible = true;
            this.grdSangInfo.Rows = 2;
            this.grdSangInfo.RowStateCheckOnPaint = false;
            this.grdSangInfo.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdSangInfo.ToolTipActive = true;
            this.grdSangInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSangInfo_QueryStarting);
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.CellName = "ju_sang_yn";
            this.xEditGridCell34.CellWidth = 57;
            this.xEditGridCell34.Col = 1;
            this.xEditGridCell34.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell34.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            this.xEditGridCell34.ImageList = this.ImageList;
            this.xEditGridCell34.IsUpdatable = false;
            this.xEditGridCell34.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell34.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.CellName = "sang_code";
            this.xEditGridCell35.CellWidth = 108;
            this.xEditGridCell35.Col = 3;
            this.xEditGridCell35.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.ImageList = this.ImageList;
            this.xEditGridCell35.IsUpdatable = false;
            this.xEditGridCell35.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell35.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.CellName = "gwa_name";
            this.xEditGridCell39.Col = 2;
            this.xEditGridCell39.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.IsReadOnly = true;
            this.xEditGridCell39.IsUpdatable = false;
            this.xEditGridCell39.IsUpdCol = false;
            // 
            // xEditGridCell125
            // 
            this.xEditGridCell125.CellName = "ser";
            this.xEditGridCell125.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell125.Col = -1;
            this.xEditGridCell125.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell125, "xEditGridCell125");
            this.xEditGridCell125.IsUpdatable = false;
            this.xEditGridCell125.IsVisible = false;
            this.xEditGridCell125.Row = -1;
            // 
            // xEditGridCell57
            // 
            this.xEditGridCell57.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.CellName = "display_sang_name";
            this.xEditGridCell57.CellWidth = 376;
            this.xEditGridCell57.Col = 4;
            this.xEditGridCell57.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell57, "xEditGridCell57");
            this.xEditGridCell57.ImageList = this.ImageList;
            this.xEditGridCell57.IsUpdatable = false;
            this.xEditGridCell57.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell57.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell99
            // 
            this.xEditGridCell99.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.CellName = "sang_start_date";
            this.xEditGridCell99.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell99.CellWidth = 129;
            this.xEditGridCell99.Col = 5;
            this.xEditGridCell99.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell99, "xEditGridCell99");
            this.xEditGridCell99.IsUpdatable = false;
            this.xEditGridCell99.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell99.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell100
            // 
            this.xEditGridCell100.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.CellName = "sang_end_date";
            this.xEditGridCell100.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell100.CellWidth = 103;
            this.xEditGridCell100.Col = 8;
            this.xEditGridCell100.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell100, "xEditGridCell100");
            this.xEditGridCell100.IsUpdatable = false;
            this.xEditGridCell100.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell100.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell101
            // 
            this.xEditGridCell101.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.CellName = "sang_end_sayu";
            this.xEditGridCell101.CellWidth = 114;
            this.xEditGridCell101.Col = 7;
            this.xEditGridCell101.ExecuteQuery = null;
            this.xEditGridCell101.HeaderImageStretch = true;
            resources.ApplyResources(this.xEditGridCell101, "xEditGridCell101");
            this.xEditGridCell101.IsUpdatable = false;
            this.xEditGridCell101.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell101.SelectedForeColor = IHIS.Framework.XColor.NormalForeColor;
            // 
            // xEditGridCell58
            // 
            this.xEditGridCell58.CellName = "bunho";
            this.xEditGridCell58.Col = -1;
            this.xEditGridCell58.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell58, "xEditGridCell58");
            this.xEditGridCell58.IsUpdatable = false;
            this.xEditGridCell58.IsVisible = false;
            this.xEditGridCell58.Row = -1;
            // 
            // xEditGridCell60
            // 
            this.xEditGridCell60.CellName = "naewon_date";
            this.xEditGridCell60.Col = -1;
            this.xEditGridCell60.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell60, "xEditGridCell60");
            this.xEditGridCell60.IsUpdatable = false;
            this.xEditGridCell60.IsVisible = false;
            this.xEditGridCell60.Row = -1;
            // 
            // xEditGridCell61
            // 
            this.xEditGridCell61.CellName = "gwa";
            this.xEditGridCell61.Col = -1;
            this.xEditGridCell61.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell61, "xEditGridCell61");
            this.xEditGridCell61.IsUpdatable = false;
            this.xEditGridCell61.IsVisible = false;
            this.xEditGridCell61.Row = -1;
            // 
            // xEditGridCell62
            // 
            this.xEditGridCell62.CellName = "doctor";
            this.xEditGridCell62.Col = -1;
            this.xEditGridCell62.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell62, "xEditGridCell62");
            this.xEditGridCell62.IsUpdatable = false;
            this.xEditGridCell62.IsVisible = false;
            this.xEditGridCell62.Row = -1;
            // 
            // xEditGridCell63
            // 
            this.xEditGridCell63.CellName = "naewon_type";
            this.xEditGridCell63.Col = -1;
            this.xEditGridCell63.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell63, "xEditGridCell63");
            this.xEditGridCell63.IsUpdatable = false;
            this.xEditGridCell63.IsVisible = false;
            this.xEditGridCell63.Row = -1;
            // 
            // xEditGridCell130
            // 
            this.xEditGridCell130.CellName = "jubsu_no";
            this.xEditGridCell130.Col = -1;
            this.xEditGridCell130.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell130, "xEditGridCell130");
            this.xEditGridCell130.IsUpdatable = false;
            this.xEditGridCell130.IsVisible = false;
            this.xEditGridCell130.Row = -1;
            // 
            // xEditGridCell74
            // 
            this.xEditGridCell74.CellName = "pk_order";
            this.xEditGridCell74.Col = -1;
            this.xEditGridCell74.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell74, "xEditGridCell74");
            this.xEditGridCell74.IsUpdatable = false;
            this.xEditGridCell74.IsVisible = false;
            this.xEditGridCell74.Row = -1;
            // 
            // xEditGridCell126
            // 
            this.xEditGridCell126.CellName = "sang_name";
            this.xEditGridCell126.Col = -1;
            this.xEditGridCell126.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell126, "xEditGridCell126");
            this.xEditGridCell126.IsUpdatable = false;
            this.xEditGridCell126.IsVisible = false;
            this.xEditGridCell126.Row = -1;
            // 
            // xEditGridCell103
            // 
            this.xEditGridCell103.CellName = "pre_modifier1";
            this.xEditGridCell103.Col = -1;
            this.xEditGridCell103.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell103, "xEditGridCell103");
            this.xEditGridCell103.IsUpdatable = false;
            this.xEditGridCell103.IsVisible = false;
            this.xEditGridCell103.Row = -1;
            // 
            // xEditGridCell104
            // 
            this.xEditGridCell104.CellName = "pre_modifier2";
            this.xEditGridCell104.Col = -1;
            this.xEditGridCell104.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell104, "xEditGridCell104");
            this.xEditGridCell104.IsUpdatable = false;
            this.xEditGridCell104.IsVisible = false;
            this.xEditGridCell104.Row = -1;
            // 
            // xEditGridCell105
            // 
            this.xEditGridCell105.CellName = "pre_modifier3";
            this.xEditGridCell105.Col = -1;
            this.xEditGridCell105.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell105, "xEditGridCell105");
            this.xEditGridCell105.IsUpdatable = false;
            this.xEditGridCell105.IsVisible = false;
            this.xEditGridCell105.Row = -1;
            // 
            // xEditGridCell106
            // 
            this.xEditGridCell106.CellName = "pre_modifier4";
            this.xEditGridCell106.Col = -1;
            this.xEditGridCell106.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell106, "xEditGridCell106");
            this.xEditGridCell106.IsUpdatable = false;
            this.xEditGridCell106.IsVisible = false;
            this.xEditGridCell106.Row = -1;
            // 
            // xEditGridCell107
            // 
            this.xEditGridCell107.CellName = "pre_modifier5";
            this.xEditGridCell107.Col = -1;
            this.xEditGridCell107.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell107, "xEditGridCell107");
            this.xEditGridCell107.IsUpdatable = false;
            this.xEditGridCell107.IsVisible = false;
            this.xEditGridCell107.Row = -1;
            // 
            // xEditGridCell108
            // 
            this.xEditGridCell108.CellName = "pre_modifier6";
            this.xEditGridCell108.Col = -1;
            this.xEditGridCell108.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell108, "xEditGridCell108");
            this.xEditGridCell108.IsUpdatable = false;
            this.xEditGridCell108.IsVisible = false;
            this.xEditGridCell108.Row = -1;
            // 
            // xEditGridCell109
            // 
            this.xEditGridCell109.CellName = "pre_modifier7";
            this.xEditGridCell109.Col = -1;
            this.xEditGridCell109.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell109, "xEditGridCell109");
            this.xEditGridCell109.IsUpdatable = false;
            this.xEditGridCell109.IsVisible = false;
            this.xEditGridCell109.Row = -1;
            // 
            // xEditGridCell110
            // 
            this.xEditGridCell110.CellName = "pre_modifier8";
            this.xEditGridCell110.Col = -1;
            this.xEditGridCell110.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell110, "xEditGridCell110");
            this.xEditGridCell110.IsUpdatable = false;
            this.xEditGridCell110.IsVisible = false;
            this.xEditGridCell110.Row = -1;
            // 
            // xEditGridCell111
            // 
            this.xEditGridCell111.CellName = "pre_modifier9";
            this.xEditGridCell111.Col = -1;
            this.xEditGridCell111.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell111, "xEditGridCell111");
            this.xEditGridCell111.IsUpdatable = false;
            this.xEditGridCell111.IsVisible = false;
            this.xEditGridCell111.Row = -1;
            // 
            // xEditGridCell112
            // 
            this.xEditGridCell112.CellName = "pre_modifier10";
            this.xEditGridCell112.Col = -1;
            this.xEditGridCell112.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell112, "xEditGridCell112");
            this.xEditGridCell112.IsUpdatable = false;
            this.xEditGridCell112.IsVisible = false;
            this.xEditGridCell112.Row = -1;
            // 
            // xEditGridCell113
            // 
            this.xEditGridCell113.CellName = "pre_modifier_name";
            this.xEditGridCell113.Col = -1;
            this.xEditGridCell113.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell113, "xEditGridCell113");
            this.xEditGridCell113.IsUpdatable = false;
            this.xEditGridCell113.IsVisible = false;
            this.xEditGridCell113.Row = -1;
            // 
            // xEditGridCell114
            // 
            this.xEditGridCell114.CellName = "post_modifier1";
            this.xEditGridCell114.Col = -1;
            this.xEditGridCell114.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell114, "xEditGridCell114");
            this.xEditGridCell114.IsUpdatable = false;
            this.xEditGridCell114.IsVisible = false;
            this.xEditGridCell114.Row = -1;
            // 
            // xEditGridCell115
            // 
            this.xEditGridCell115.CellName = "post_modifier2";
            this.xEditGridCell115.Col = -1;
            this.xEditGridCell115.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell115, "xEditGridCell115");
            this.xEditGridCell115.IsUpdatable = false;
            this.xEditGridCell115.IsVisible = false;
            this.xEditGridCell115.Row = -1;
            // 
            // xEditGridCell116
            // 
            this.xEditGridCell116.CellName = "post_modifier3";
            this.xEditGridCell116.Col = -1;
            this.xEditGridCell116.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell116, "xEditGridCell116");
            this.xEditGridCell116.IsUpdatable = false;
            this.xEditGridCell116.IsVisible = false;
            this.xEditGridCell116.Row = -1;
            // 
            // xEditGridCell117
            // 
            this.xEditGridCell117.CellName = "post_modifier4";
            this.xEditGridCell117.Col = -1;
            this.xEditGridCell117.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell117, "xEditGridCell117");
            this.xEditGridCell117.IsUpdatable = false;
            this.xEditGridCell117.IsVisible = false;
            this.xEditGridCell117.Row = -1;
            // 
            // xEditGridCell118
            // 
            this.xEditGridCell118.CellName = "post_modifier5";
            this.xEditGridCell118.Col = -1;
            this.xEditGridCell118.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell118, "xEditGridCell118");
            this.xEditGridCell118.IsUpdatable = false;
            this.xEditGridCell118.IsVisible = false;
            this.xEditGridCell118.Row = -1;
            // 
            // xEditGridCell119
            // 
            this.xEditGridCell119.CellName = "post_modifier6";
            this.xEditGridCell119.Col = -1;
            this.xEditGridCell119.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell119, "xEditGridCell119");
            this.xEditGridCell119.IsUpdatable = false;
            this.xEditGridCell119.IsVisible = false;
            this.xEditGridCell119.Row = -1;
            // 
            // xEditGridCell120
            // 
            this.xEditGridCell120.CellName = "post_modifier7";
            this.xEditGridCell120.Col = -1;
            this.xEditGridCell120.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell120, "xEditGridCell120");
            this.xEditGridCell120.IsUpdatable = false;
            this.xEditGridCell120.IsVisible = false;
            this.xEditGridCell120.Row = -1;
            // 
            // xEditGridCell121
            // 
            this.xEditGridCell121.CellName = "post_modifier8";
            this.xEditGridCell121.Col = -1;
            this.xEditGridCell121.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell121, "xEditGridCell121");
            this.xEditGridCell121.IsUpdatable = false;
            this.xEditGridCell121.IsVisible = false;
            this.xEditGridCell121.Row = -1;
            // 
            // xEditGridCell122
            // 
            this.xEditGridCell122.CellName = "post_modifier9";
            this.xEditGridCell122.Col = -1;
            this.xEditGridCell122.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell122, "xEditGridCell122");
            this.xEditGridCell122.IsUpdatable = false;
            this.xEditGridCell122.IsVisible = false;
            this.xEditGridCell122.Row = -1;
            // 
            // xEditGridCell123
            // 
            this.xEditGridCell123.CellName = "post_modifier10";
            this.xEditGridCell123.Col = -1;
            this.xEditGridCell123.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell123, "xEditGridCell123");
            this.xEditGridCell123.IsUpdatable = false;
            this.xEditGridCell123.IsVisible = false;
            this.xEditGridCell123.Row = -1;
            // 
            // xEditGridCell124
            // 
            this.xEditGridCell124.CellName = "post_modifier_name";
            this.xEditGridCell124.Col = -1;
            this.xEditGridCell124.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell124, "xEditGridCell124");
            this.xEditGridCell124.IsUpdatable = false;
            this.xEditGridCell124.IsVisible = false;
            this.xEditGridCell124.Row = -1;
            // 
            // xEditGridCell98
            // 
            this.xEditGridCell98.CellName = "bulyong_check";
            this.xEditGridCell98.Col = -1;
            this.xEditGridCell98.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell98, "xEditGridCell98");
            this.xEditGridCell98.IsUpdatable = false;
            this.xEditGridCell98.IsVisible = false;
            this.xEditGridCell98.Row = -1;
            // 
            // xEditGridCell78
            // 
            this.xEditGridCell78.CellName = "sang_jindan_date";
            this.xEditGridCell78.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell78.CellWidth = 123;
            this.xEditGridCell78.Col = 6;
            this.xEditGridCell78.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell78, "xEditGridCell78");
            // 
            // tabGroup
            // 
            this.tabGroup.AccessibleDescription = null;
            this.tabGroup.AccessibleName = null;
            resources.ApplyResources(this.tabGroup, "tabGroup");
            this.tabGroup.BackgroundImage = null;
            this.tabGroup.Font = null;
            this.tabGroup.IDEPixelArea = true;
            this.tabGroup.IDEPixelBorder = false;
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectionChanged += new System.EventHandler(this.tabGroup_SelectionChanged);
            // 
            // dloSelectOCS1003
            // 
            this.dloSelectOCS1003.ExecuteQuery = null;
            this.dloSelectOCS1003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOCS1003.ParamList")));
            // 
            // dloOrder_danui
            // 
            this.dloOrder_danui.ExecuteQuery = null;
            this.dloOrder_danui.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.dloOrder_danui.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloOrder_danui.ParamList")));
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // imageListMixGroup
            // 
            this.imageListMixGroup.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMixGroup.ImageStream")));
            this.imageListMixGroup.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMixGroup.Images.SetKeyName(0, "");
            this.imageListMixGroup.Images.SetKeyName(1, "");
            this.imageListMixGroup.Images.SetKeyName(2, "");
            this.imageListMixGroup.Images.SetKeyName(3, "");
            this.imageListMixGroup.Images.SetKeyName(4, "");
            this.imageListMixGroup.Images.SetKeyName(5, "");
            this.imageListMixGroup.Images.SetKeyName(6, "");
            this.imageListMixGroup.Images.SetKeyName(7, "");
            this.imageListMixGroup.Images.SetKeyName(8, "");
            this.imageListMixGroup.Images.SetKeyName(9, "");
            this.imageListMixGroup.Images.SetKeyName(10, "");
            this.imageListMixGroup.Images.SetKeyName(11, "");
            this.imageListMixGroup.Images.SetKeyName(12, "");
            this.imageListMixGroup.Images.SetKeyName(13, "");
            this.imageListMixGroup.Images.SetKeyName(14, "");
            this.imageListMixGroup.Images.SetKeyName(15, "");
            this.imageListMixGroup.Images.SetKeyName(16, "");
            this.imageListMixGroup.Images.SetKeyName(17, "");
            this.imageListMixGroup.Images.SetKeyName(18, "");
            this.imageListMixGroup.Images.SetKeyName(19, "");
            // 
            // dloSelectOUT1001
            // 
            this.dloSelectOUT1001.ExecuteQuery = null;
            this.dloSelectOUT1001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dloSelectOUT1001.ParamList")));
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "YESEN1.ICO");
            this.imageList1.Images.SetKeyName(1, "YESUP1.ICO");
            // 
            // timer_icon
            // 
            this.timer_icon.Interval = 3000;
            this.timer_icon.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // OCS1003Q05
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "OCS1003Q05";
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSearch)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.gbxHopeDate.ResumeLayout(false);
            this.gbxHopeDate.PerformLayout();
            this.gbxNalsu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOUT1001)).EndInit();
            this.pnlKijun.ResumeLayout(false);
            this.tabOrderGubun.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            this.pnlOrder.ResumeLayout(false);
            this.pnlOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnderArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSangInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOCS1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloOrder_danui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloSelectOUT1001)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private XEditGrid grdOCS1003;

        #endregion
        private XEditGridCell xEditGridCell145;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell102;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell134;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell135;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell136;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell137;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell163;
        private XEditGridCell xEditGridCell164;
        private XEditGridCell xEditGridCell165;
        private XEditGridCell xEditGridCell166;
        private XEditGridCell xEditGridCell173;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell140;
        private XEditGridCell xEditGridCell141;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell33;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell40;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell167;
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
        private XEditGridCell xEditGridCell52;
        private XEditGridCell xEditGridCell53;
        private XEditGridCell xEditGridCell54;
        private XEditGridCell xEditGridCell55;
        private XEditGridCell xEditGridCell56;
        private XEditGridCell xEditGridCell59;
        private XEditGridCell xEditGridCell64;
        private XEditGridCell xEditGridCell65;
        private XEditGridCell xEditGridCell66;
        private XEditGridCell xEditGridCell67;
        private XEditGridCell xEditGridCell139;
        private XEditGridCell xEditGridCell94;
        private XEditGridCell xEditGridCell68;
        private XEditGridCell xEditGridCell153;
        private XEditGridCell xEditGridCell154;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XEditGridCell xEditGridCell155;
        private XEditGridCell xEditGridCell156;
        private XEditGridCell xEditGridCell169;
        private XEditGridCell xEditGridCell170;
        private XEditGridCell xEditGridCell69;
        private XEditGridCell xEditGridCell70;
        private XEditGridCell xEditGridCell71;
        private XEditGridCell xEditGridCell72;
        private XEditGridCell xEditGridCell73;
        private XEditGridCell xEditGridCell76;
        private XEditGridCell xEditGridCell77;
        private XEditGridCell xEditGridCell80;
        private XEditGridCell xEditGridCell81;
        private XEditGridCell xEditGridCell82;
        private XEditGridCell xEditGridCell83;
        private XEditGridCell xEditGridCell128;
        private XEditGridCell xEditGridCell84;
        private XEditGridCell xEditGridCell85;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell87;
        private XEditGridCell xEditGridCell88;
        private XEditGridCell xEditGridCell89;
        private XEditGridCell xEditGridCell92;
        private XEditGridCell xEditGridCell93;
        private XEditGridCell xEditGridCell132;
        private XEditGridCell xEditGridCell171;
        private XEditGridCell xEditGridCell172;
        private XEditGridCell xEditGridCell176;
        private XEditGridCell xEditGridCell177;
        private XEditGridCell xEditGridCell178;
        private XEditGridCell xEditGridCell180;
        private XEditGridCell xEditGridCell181;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell133;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell75;
        private XEditGridCell xEditGridCell79;
        private XEditGridCell xEditGridCell86;
        private XEditGridCell xEditGridCell90;
        private XEditGridCell xEditGridCell91;
        private XEditGridCell xEditGridCell96;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XEditGridCell xEditGridCell131;
        private XEditGridCell xEditGridCell97;
        private XEditGridCell xEditGridCell138;
        private XEditGridCell xEditGridCell143;
        private XEditGridCell xEditGridCell144;
        private XEditGridCell xEditGridCell148;
        private XEditGridCell xEditGridCell151;
        private XComboItem xComboItem3;
        private XComboItem xComboItem4;
        private XGridHeader xGridHeader1;
    }
}
