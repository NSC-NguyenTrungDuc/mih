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
	/// NUR4002U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR4002U00 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
        //private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();	
        //private IHIS.Framework.DataServiceDynMO mDsdCombo = new DataServiceDynMO();
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		string mBunho = "";
		int    mFkinp1001 = 0;
		#endregion

		#region 자동생성

		private IHIS.Framework.XPanel pnlButton;
        //private IHIS.Framework.DataServiceMMISO dsvSave;
        //private IHIS.Framework.DataServiceSIMO dsvLDNUR0402;
        private IHIS.Framework.XPatientBox pbxBunho;
        private System.Windows.Forms.TreeView tvwNUR4003;
		private IHIS.Framework.XButton btnCreateNurPlan;
		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPictureBox xPictureBox1;
        //private IHIS.Framework.DataServiceSIMO dsvLDNUR4002;
		private IHIS.Framework.MultiLayout layNUR4002;
		private System.Windows.Forms.ToolTip toolTip1;
		private IHIS.Framework.XButton btnModifyNurPlan;
		private IHIS.Framework.XButton btnValue;
        //private IHIS.Framework.DataServiceSISO dsvFkinp1001;
		private IHIS.Framework.XEditGrid grdInp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        //private IHIS.Framework.DataServiceSIMO dsvToiwon_List;
        private IHIS.Framework.XButtonList btnList;
        private SingleLayout layFkinp1001;
        private SingleLayoutItem singleLayoutItem1;
        private MultiLayout layNUR0402;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private XTreeView tvwNur_plan_bunryu;
        private XPanel pnlLeftFill;
        private XPanel pnlRight;
        private XEditGrid grdNUR4005;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XPanel pnlNUR4005;
        private XPanel pnlButton2;
        private XButton btnDelete;
        private XButton btnSave;
        private XButton btnAdd2;
        private XEditGrid grdNUR4002;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XTreeView tvwSelector;
        private XPanel pnlLeft;
        private MultiLayout layPlanInfo;
        private XLabel xLabel1;
        private XButton btnAdd1;
        private MultiLayout dloDetailData;
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
        private XLabel xLabel2;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
        private MultiLayoutItem multiLayoutItem28;
        private MultiLayoutItem multiLayoutItem29;
        private MultiLayoutItem multiLayoutItem30;
        private MultiLayoutItem multiLayoutItem31;
        private MultiLayoutItem multiLayoutItem32;
        private MultiLayoutItem multiLayoutItem34;
        private MultiLayoutItem multiLayoutItem35;
        private MultiLayoutItem multiLayoutItem49;
        private MultiLayoutItem multiLayoutItem50;
        private MultiLayoutItem multiLayoutItem51;
        private MultiLayoutItem multiLayoutItem52;
        private MultiLayoutItem multiLayoutItem53;
        private MultiLayoutItem multiLayoutItem54;
        private XButton btnUnCheck;
        private XButton btnCheck;
        private Splitter splitter1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private XPanel xPanel1;
        private XLabel lbSelectedPlanName;
		private System.ComponentModel.IContainer components;

		#endregion

		#region 생성자

		public NUR4002U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}

		#endregion

		#region 소멸자

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#endregion

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4002U00));
            this.pnlButton = new IHIS.Framework.XPanel();
            this.btnUnCheck = new IHIS.Framework.XButton();
            this.btnCheck = new IHIS.Framework.XButton();
            this.btnAdd1 = new IHIS.Framework.XButton();
            this.btnValue = new IHIS.Framework.XButton();
            this.btnModifyNurPlan = new IHIS.Framework.XButton();
            this.btnCreateNurPlan = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR4002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.layNUR0402 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.pbxBunho = new IHIS.Framework.XPatientBox();
            this.tvwNUR4003 = new System.Windows.Forms.TreeView();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.layNUR4002 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem28 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem29 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem30 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem32 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem34 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem35 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem49 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem50 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem51 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem52 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem53 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem54 = new IHIS.Framework.MultiLayoutItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grdInp1001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.layFkinp1001 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.tvwNur_plan_bunryu = new IHIS.Framework.XTreeView();
            this.pnlLeftFill = new IHIS.Framework.XPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvwSelector = new IHIS.Framework.XTreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pnlNUR4005 = new IHIS.Framework.XPanel();
            this.grdNUR4005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.pnlButton2 = new IHIS.Framework.XPanel();
            this.lbSelectedPlanName = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.btnSave = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.btnAdd2 = new IHIS.Framework.XButton();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.layPlanInfo = new IHIS.Framework.MultiLayout();
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
            this.dloDetailData = new IHIS.Framework.MultiLayout();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0402)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).BeginInit();
            this.pnlLeftFill.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlNUR4005.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).BeginInit();
            this.pnlButton2.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layPlanInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDetailData)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
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
            this.ImageList.Images.SetKeyName(12, "");
            this.ImageList.Images.SetKeyName(13, "");
            this.ImageList.Images.SetKeyName(14, "");
            this.ImageList.Images.SetKeyName(15, "");
            this.ImageList.Images.SetKeyName(16, "");
            this.ImageList.Images.SetKeyName(17, "");
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.btnUnCheck);
            this.pnlButton.Controls.Add(this.btnCheck);
            this.pnlButton.Controls.Add(this.btnAdd1);
            this.pnlButton.Controls.Add(this.btnValue);
            this.pnlButton.Controls.Add(this.btnModifyNurPlan);
            this.pnlButton.Controls.Add(this.btnCreateNurPlan);
            this.pnlButton.Controls.Add(this.btnList);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.DrawBorder = true;
            this.pnlButton.Location = new System.Drawing.Point(0, 556);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(1226, 34);
            this.pnlButton.TabIndex = 1;
            // 
            // btnUnCheck
            // 
            this.btnUnCheck.ImageIndex = 2;
            this.btnUnCheck.ImageList = this.ImageList;
            this.btnUnCheck.Location = new System.Drawing.Point(249, 1);
            this.btnUnCheck.Name = "btnUnCheck";
            this.btnUnCheck.Size = new System.Drawing.Size(29, 28);
            this.btnUnCheck.TabIndex = 5;
            this.btnUnCheck.Click += new System.EventHandler(this.btnUnCheck_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.ImageIndex = 3;
            this.btnCheck.ImageList = this.ImageList;
            this.btnCheck.Location = new System.Drawing.Point(219, 1);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(29, 28);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnAdd1
            // 
            this.btnAdd1.ImageIndex = 13;
            this.btnAdd1.ImageList = this.ImageList;
            this.btnAdd1.Location = new System.Drawing.Point(635, 1);
            this.btnAdd1.Name = "btnAdd1";
            this.btnAdd1.Size = new System.Drawing.Size(81, 28);
            this.btnAdd1.TabIndex = 3;
            this.btnAdd1.Text = "登 録";
            this.btnAdd1.Click += new System.EventHandler(this.btnAdd1_Click);
            // 
            // btnValue
            // 
            this.btnValue.Image = ((System.Drawing.Image)(resources.GetObject("btnValue.Image")));
            this.btnValue.Location = new System.Drawing.Point(958, 1);
            this.btnValue.Name = "btnValue";
            this.btnValue.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnValue.Size = new System.Drawing.Size(78, 28);
            this.btnValue.TabIndex = 3;
            this.btnValue.Text = "評価";
            this.btnValue.Click += new System.EventHandler(this.btnValue_Click);
            // 
            // btnModifyNurPlan
            // 
            this.btnModifyNurPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnModifyNurPlan.Image")));
            this.btnModifyNurPlan.Location = new System.Drawing.Point(877, 1);
            this.btnModifyNurPlan.Name = "btnModifyNurPlan";
            this.btnModifyNurPlan.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnModifyNurPlan.Size = new System.Drawing.Size(78, 28);
            this.btnModifyNurPlan.TabIndex = 2;
            this.btnModifyNurPlan.Text = "修正";
            this.btnModifyNurPlan.Click += new System.EventHandler(this.btnModifyNurPlan_Click);
            // 
            // btnCreateNurPlan
            // 
            this.btnCreateNurPlan.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNurPlan.Image")));
            this.btnCreateNurPlan.Location = new System.Drawing.Point(3, 1);
            this.btnCreateNurPlan.Name = "btnCreateNurPlan";
            this.btnCreateNurPlan.Scheme = IHIS.Framework.XButtonSchemes.Silver;
            this.btnCreateNurPlan.Size = new System.Drawing.Size(116, 28);
            this.btnCreateNurPlan.TabIndex = 1;
            this.btnCreateNurPlan.Text = "新規/追加作成";
            this.btnCreateNurPlan.Click += new System.EventHandler(this.btnCreateNurPlan_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(1061, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 32);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR4002
            // 
            this.grdNUR4002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell24});
            this.grdNUR4002.ColPerLine = 1;
            this.grdNUR4002.Cols = 1;
            this.grdNUR4002.ControlBinding = true;
            this.grdNUR4002.FixedRows = 1;
            this.grdNUR4002.FocusColumnName = "nur_plan_proname";
            this.grdNUR4002.HeaderHeights.Add(26);
            this.grdNUR4002.Location = new System.Drawing.Point(138, 389);
            this.grdNUR4002.Name = "grdNUR4002";
            this.grdNUR4002.QuerySQL = resources.GetString("grdNUR4002.QuerySQL");
            this.grdNUR4002.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4002.Rows = 2;
            this.grdNUR4002.Size = new System.Drawing.Size(170, 86);
            this.grdNUR4002.TabIndex = 12;
            this.grdNUR4002.ToolTipActive = true;
            this.grdNUR4002.UseDefaultTransaction = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pknur4002";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "pknur4002";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bunho";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "bunho";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "fkinp1001";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "fkinp1001";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "nur_plan_jin";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "nur_plan_jin";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "nur_plan_pro";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "nur_plan_pro";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.ApplyPaintingEvent = true;
            this.xEditGridCell17.CellLen = 200;
            this.xEditGridCell17.CellName = "nur_plan_proname";
            this.xEditGridCell17.CellWidth = 200;
            this.xEditGridCell17.HeaderImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell17.HeaderImage")));
            this.xEditGridCell17.HeaderText = "問題リスト";
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "plan_user";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "plan_user";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "plan_usnm";
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "plan_usnm";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "plan_date";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "plan_date";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "vald";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "vald";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "modify_yn";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "modify_yn";
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "nur0402_valid";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "nur0402_valid";
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "sort_key";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "sort_key";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // layNUR0402
            // 
            this.layNUR0402.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22});
            this.layNUR0402.QuerySQL = resources.GetString("layNUR0402.QuerySQL");
            this.layNUR0402.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR0402_QueryStarting);
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "nur_plan_bunryu";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nur_plan_bunryu_name";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "nur_plan_jinname";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "nur_plan_pro";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "nur_plan_proname";
            // 
            // pbxBunho
            // 
            this.pbxBunho.BoxType = IHIS.Framework.PatientBoxType.NormalMiddle;
            this.pbxBunho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbxBunho.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pbxBunho.Location = new System.Drawing.Point(0, 0);
            this.pbxBunho.Name = "pbxBunho";
            this.pbxBunho.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.pbxBunho.Size = new System.Drawing.Size(1226, 29);
            this.pbxBunho.TabIndex = 0;
            this.pbxBunho.PatientSelectionFailed += new System.EventHandler(this.pbxBunho_PatientSelectionFailed);
            this.pbxBunho.PatientSelected += new System.EventHandler(this.pbxBunho_PatientSelected);
            // 
            // tvwNUR4003
            // 
            this.tvwNUR4003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNUR4003.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.tvwNUR4003.ImageIndex = 4;
            this.tvwNUR4003.ImageList = this.ImageList;
            this.tvwNUR4003.Location = new System.Drawing.Point(0, 0);
            this.tvwNUR4003.Name = "tvwNUR4003";
            this.tvwNUR4003.SelectedImageIndex = 4;
            this.tvwNUR4003.Size = new System.Drawing.Size(509, 300);
            this.tvwNUR4003.TabIndex = 0;
            this.tvwNUR4003.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterSelect);
            this.tvwNUR4003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwNUR4003_MouseDown);
            this.tvwNUR4003.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvw_KeyDown);
            this.tvwNUR4003.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterExpand);
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlTop.BackgroundImage")));
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.pbxBunho);
            this.pnlTop.Controls.Add(this.xPictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1226, 32);
            this.pnlTop.TabIndex = 10;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Location = new System.Drawing.Point(5, 5);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(65, 20);
            this.xLabel1.TabIndex = 1;
            this.xLabel1.Text = "患者番号";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xPictureBox1.Image")));
            this.xPictureBox1.Location = new System.Drawing.Point(0, 0);
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.Size = new System.Drawing.Size(1226, 32);
            this.xPictureBox1.TabIndex = 0;
            this.xPictureBox1.TabStop = false;
            // 
            // layNUR4002
            // 
            this.layNUR4002.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem23,
            this.multiLayoutItem24,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27,
            this.multiLayoutItem28,
            this.multiLayoutItem29,
            this.multiLayoutItem30,
            this.multiLayoutItem31,
            this.multiLayoutItem32,
            this.multiLayoutItem34,
            this.multiLayoutItem35,
            this.multiLayoutItem49,
            this.multiLayoutItem50,
            this.multiLayoutItem51,
            this.multiLayoutItem52,
            this.multiLayoutItem53,
            this.multiLayoutItem54});
            this.layNUR4002.QuerySQL = resources.GetString("layNUR4002.QuerySQL");
            this.layNUR4002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR4002_QueryStarting);
            this.layNUR4002.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layNUR4002_QueryEnd);
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "pknur4002";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "bunho";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "fkinp1001";
            this.multiLayoutItem25.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "nur_plan_pro";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "nur_plan_proname";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "plan_user";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "plan_date";
            this.multiLayoutItem30.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "pknur4003";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "nur_plan";
            this.multiLayoutItem32.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem34
            // 
            this.multiLayoutItem34.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem35
            // 
            this.multiLayoutItem35.DataName = "nur_dis_plan_name";
            // 
            // multiLayoutItem49
            // 
            this.multiLayoutItem49.DataName = "pknur4004";
            this.multiLayoutItem49.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem50
            // 
            this.multiLayoutItem50.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem51
            // 
            this.multiLayoutItem51.DataName = "nur_plan_dename";
            // 
            // multiLayoutItem52
            // 
            this.multiLayoutItem52.DataName = "plan_user_name";
            // 
            // multiLayoutItem53
            // 
            this.multiLayoutItem53.DataName = "nur_plan_name";
            // 
            // multiLayoutItem54
            // 
            this.multiLayoutItem54.DataName = "nur4002_vald";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // grdInp1001
            // 
            this.grdInp1001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdInp1001.ColPerLine = 2;
            this.grdInp1001.Cols = 2;
            this.grdInp1001.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdInp1001.FixedRows = 1;
            this.grdInp1001.HeaderHeights.Add(21);
            this.grdInp1001.Location = new System.Drawing.Point(0, 0);
            this.grdInp1001.Name = "grdInp1001";
            this.grdInp1001.QuerySQL = resources.GetString("grdInp1001.QuerySQL");
            this.grdInp1001.ReadOnly = true;
            this.grdInp1001.Rows = 2;
            this.grdInp1001.Size = new System.Drawing.Size(220, 524);
            this.grdInp1001.TabIndex = 11;
            this.grdInp1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInp1001_QueryStarting);
            this.grdInp1001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdInp1001_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ipwon_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 100;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell1.HeaderText = "入院日付";
            this.xEditGridCell1.IsJapanYearType = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "toiwon_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.HeaderText = "退院日付";
            this.xEditGridCell2.IsJapanYearType = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "患者番号";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suname";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "患者氏名";
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pkinp1001";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "pkinp1001";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // layFkinp1001
            // 
            this.layFkinp1001.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layFkinp1001.QuerySQL = "SELECT PKINP1001\r\n  FROM VW_OCS_INP1001_01\r\n WHERE HOSP_CODE            = :f_hosp" +
                "_code \r\n   AND NVL(CANCEL_YN,\'N\')   = \'N\'\r\n   AND NVL(JAEWON_FLAG,\'N\') = \'Y\'\r\n  " +
                " AND BUNHO                = :f_bunho";
            this.layFkinp1001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layFkinp1001_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "fkinp1001";
            // 
            // tvwNur_plan_bunryu
            // 
            this.tvwNur_plan_bunryu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNur_plan_bunryu.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.tvwNur_plan_bunryu.HideSelection = false;
            this.tvwNur_plan_bunryu.ImageIndex = 0;
            this.tvwNur_plan_bunryu.ImageList = this.ImageList;
            this.tvwNur_plan_bunryu.ItemHeight = 19;
            this.tvwNur_plan_bunryu.Location = new System.Drawing.Point(0, 0);
            this.tvwNur_plan_bunryu.Name = "tvwNur_plan_bunryu";
            this.tvwNur_plan_bunryu.SelectedImageIndex = 0;
            this.tvwNur_plan_bunryu.Size = new System.Drawing.Size(494, 300);
            this.tvwNur_plan_bunryu.TabIndex = 4;
            this.tvwNur_plan_bunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
            this.tvwNur_plan_bunryu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwNur_plan_bunryu_MouseDown);
            this.tvwNur_plan_bunryu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvw_KeyDown);
            // 
            // pnlLeftFill
            // 
            this.pnlLeftFill.Controls.Add(this.splitContainer1);
            this.pnlLeftFill.Controls.Add(this.splitter1);
            this.pnlLeftFill.Controls.Add(this.grdNUR4002);
            this.pnlLeftFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftFill.Location = new System.Drawing.Point(220, 0);
            this.pnlLeftFill.Name = "pnlLeftFill";
            this.pnlLeftFill.Size = new System.Drawing.Size(497, 524);
            this.pnlLeftFill.TabIndex = 13;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvwNur_plan_bunryu);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tvwSelector);
            this.splitContainer1.Size = new System.Drawing.Size(494, 524);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 14;
            // 
            // tvwSelector
            // 
            this.tvwSelector.CheckBoxes = true;
            this.tvwSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwSelector.HideSelection = false;
            this.tvwSelector.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwSelector.LabelEdit = true;
            this.tvwSelector.Location = new System.Drawing.Point(0, 0);
            this.tvwSelector.Name = "tvwSelector";
            this.tvwSelector.Size = new System.Drawing.Size(494, 222);
            this.tvwSelector.TabIndex = 5;
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 524);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.splitContainer2);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(717, 32);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(509, 524);
            this.pnlRight.TabIndex = 14;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvwNUR4003);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pnlNUR4005);
            this.splitContainer2.Size = new System.Drawing.Size(509, 524);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.SplitterWidth = 2;
            this.splitContainer2.TabIndex = 3;
            // 
            // pnlNUR4005
            // 
            this.pnlNUR4005.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNUR4005.Controls.Add(this.grdNUR4005);
            this.pnlNUR4005.Controls.Add(this.pnlButton2);
            this.pnlNUR4005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNUR4005.Location = new System.Drawing.Point(0, 0);
            this.pnlNUR4005.Name = "pnlNUR4005";
            this.pnlNUR4005.Size = new System.Drawing.Size(509, 222);
            this.pnlNUR4005.TabIndex = 2;
            // 
            // grdNUR4005
            // 
            this.grdNUR4005.ApplyPaintEventToAllColumn = true;
            this.grdNUR4005.CallerID = '3';
            this.grdNUR4005.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdNUR4005.ColPerLine = 2;
            this.grdNUR4005.Cols = 3;
            this.grdNUR4005.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR4005.FixedCols = 1;
            this.grdNUR4005.FixedRows = 1;
            this.grdNUR4005.FocusColumnName = "reser_date";
            this.grdNUR4005.HeaderHeights.Add(24);
            this.grdNUR4005.Location = new System.Drawing.Point(0, 67);
            this.grdNUR4005.Name = "grdNUR4005";
            this.grdNUR4005.QuerySQL = resources.GetString("grdNUR4005.QuerySQL");
            this.grdNUR4005.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4005.RowHeaderVisible = true;
            this.grdNUR4005.RowResizable = true;
            this.grdNUR4005.Rows = 2;
            this.grdNUR4005.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR4005.Size = new System.Drawing.Size(507, 153);
            this.grdNUR4005.TabIndex = 1;
            this.grdNUR4005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4005_QueryStarting);
            this.grdNUR4005.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdNUR4005_PreSaveLayout);
            this.grdNUR4005.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR4005_GridColumnProtectModify);
            this.grdNUR4005.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4005_GridColumnChanged);
            this.grdNUR4005.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR4005_GridCellPainting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "fknur4002";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "fknur4002";
            this.xEditGridCell11.IsNotNull = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.CellName = "reser_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 79;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "予定日付";
            this.xEditGridCell12.InvalidDateIsStringEmpty = false;
            this.xEditGridCell12.IsJapanYearType = true;
            this.xEditGridCell12.IsNotNull = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell13.CellName = "value_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.CellWidth = 65;
            this.xEditGridCell13.Col = 1;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell13.HeaderText = "評価日付";
            this.xEditGridCell13.InvalidDateIsStringEmpty = false;
            this.xEditGridCell13.IsJapanYearType = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "valuer";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "valuer";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.CellLen = 4000;
            this.xEditGridCell15.CellName = "value_contents";
            this.xEditGridCell15.CellWidth = 395;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.DisplayMemoText = true;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell15.EnterKeyToTab = false;
            this.xEditGridCell15.HeaderText = "評価内容";
            this.xEditGridCell15.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell15.MemoFormSize = new System.Drawing.Size(314, 180);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "temp";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "temp";
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // pnlButton2
            // 
            this.pnlButton2.Controls.Add(this.lbSelectedPlanName);
            this.pnlButton2.Controls.Add(this.xPanel1);
            this.pnlButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButton2.Location = new System.Drawing.Point(0, 0);
            this.pnlButton2.Name = "pnlButton2";
            this.pnlButton2.Size = new System.Drawing.Size(507, 67);
            this.pnlButton2.TabIndex = 2;
            // 
            // lbSelectedPlanName
            // 
            this.lbSelectedPlanName.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lbSelectedPlanName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSelectedPlanName.EdgeRounding = false;
            this.lbSelectedPlanName.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.lbSelectedPlanName.Location = new System.Drawing.Point(0, 0);
            this.lbSelectedPlanName.Name = "lbSelectedPlanName";
            this.lbSelectedPlanName.Size = new System.Drawing.Size(507, 34);
            this.lbSelectedPlanName.TabIndex = 6;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.btnSave);
            this.xPanel1.Controls.Add(this.btnDelete);
            this.xPanel1.Controls.Add(this.btnAdd2);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 34);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(507, 33);
            this.xPanel1.TabIndex = 5;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.xLabel2.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel2.ImageIndex = 15;
            this.xLabel2.Location = new System.Drawing.Point(0, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(264, 32);
            this.xLabel2.TabIndex = 3;
            this.xLabel2.Text = "↓↓　看護計画評価登録　↓↓";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.ImageIndex = 13;
            this.btnSave.ImageList = this.ImageList;
            this.btnSave.Location = new System.Drawing.Point(264, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 33);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDelete.ImageIndex = 12;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(345, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnDelete.Size = new System.Drawing.Size(81, 33);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "行削除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd2
            // 
            this.btnAdd2.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAdd2.ImageIndex = 11;
            this.btnAdd2.ImageList = this.ImageList;
            this.btnAdd2.Location = new System.Drawing.Point(426, 0);
            this.btnAdd2.Name = "btnAdd2";
            this.btnAdd2.Size = new System.Drawing.Size(81, 33);
            this.btnAdd2.TabIndex = 2;
            this.btnAdd2.Text = "入 力";
            this.btnAdd2.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlLeftFill);
            this.pnlLeft.Controls.Add(this.grdInp1001);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 32);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(717, 524);
            this.pnlLeft.TabIndex = 15;
            // 
            // layPlanInfo
            // 
            this.layPlanInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.layPlanInfo.QuerySQL = resources.GetString("layPlanInfo.QuerySQL");
            this.layPlanInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layPlanInfo_QueryEnd);
            // 
            // multiLayoutItem36
            // 
            this.multiLayoutItem36.DataName = "fknur4002";
            // 
            // multiLayoutItem37
            // 
            this.multiLayoutItem37.DataName = "pknur4003";
            // 
            // multiLayoutItem38
            // 
            this.multiLayoutItem38.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem39
            // 
            this.multiLayoutItem39.DataName = "nur_plan";
            // 
            // multiLayoutItem40
            // 
            this.multiLayoutItem40.DataName = "nur_plan_name";
            // 
            // multiLayoutItem41
            // 
            this.multiLayoutItem41.DataName = "nur4003_vald";
            // 
            // multiLayoutItem42
            // 
            this.multiLayoutItem42.DataName = "pknur4004";
            // 
            // multiLayoutItem43
            // 
            this.multiLayoutItem43.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem44
            // 
            this.multiLayoutItem44.DataName = "nur_plan_dename";
            // 
            // multiLayoutItem45
            // 
            this.multiLayoutItem45.DataName = "nur4004_vald";
            // 
            // multiLayoutItem46
            // 
            this.multiLayoutItem46.DataName = "nur_plan_name_1";
            // 
            // multiLayoutItem47
            // 
            this.multiLayoutItem47.DataName = "nur4003_sort";
            this.multiLayoutItem47.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem48
            // 
            this.multiLayoutItem48.DataName = "nur4004_sort";
            this.multiLayoutItem48.DataType = IHIS.Framework.DataType.Number;
            // 
            // dloDetailData
            // 
            this.dloDetailData.CallerID = '2';
            this.dloDetailData.UseDefaultTransaction = false;
            // 
            // NUR4002U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlButton);
            this.Name = "NUR4002U00";
            this.Size = new System.Drawing.Size(1226, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4002U00_ScreenOpen);
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0402)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBunho)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdInp1001)).EndInit();
            this.pnlLeftFill.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.pnlNUR4005.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).EndInit();
            this.pnlButton2.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layPlanInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDetailData)).EndInit();
            this.ResumeLayout(false);

		}
        #endregion

		#region [Screen Event]
        string mHospCode = "";
        private void NUR4002U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Width, rc.Height - 105);

            // Clone처리시 메모리주소 변경된다는 거 생각해야 한다.
            // IsUpdItem값은 못가져옴
            dloDetailData = layPlanInfo.Clone();
            foreach (MultiLayoutItem item in dloDetailData.LayoutItems)
                item.IsUpdItem = true;
            dloDetailData.CallerID = '2';
            dloDetailData.UseDefaultTransaction = false;

            this.grdNUR4002.SavePerformer = new XSavePerformer(this);
            this.dloDetailData.SavePerformer = this.grdNUR4002.SavePerformer;
            this.grdNUR4005.SavePerformer = this.grdNUR4002.SavePerformer;


            this.mHospCode = EnvironInfo.HospCode;

			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);					
							return;
						}
						else
						{
							mBunho = OpenParam["bunho"].ToString().Trim();
							this.pbxBunho.SetPatientID(mBunho);
						}
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);							
						return;
					}
				}
				catch (Exception ex)
				{
					XMessageBox.Show(ex.Message, "");						
				}
			}
			else
			{
				//현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.pbxBunho.SetPatientID(patientInfo.BunHo);
                }	
			}
		
		}

		#region [환자정보 Reques/Receive Event]
		/// <summary>
		/// Docking Screen에서 환자정보 변경시 Raise
		/// </summary>
		public override void OnReceiveBunHo(XPatientInfo info)
		{
			if (info != null && !TypeCheck.IsNull(info.BunHo))
			{
				this.pbxBunho.Focus();
				this.pbxBunho.SetPatientID(info.BunHo);
			}
		}

		/// <summary>
		/// 현Screen의 등록번호를 타Screen에 넘긴다
		/// </summary>
		public override XPatientInfo OnRequestBunHo()
		{
			if (!TypeCheck.IsNull(this.pbxBunho.BunHo.ToString()))
			{
				return new XPatientInfo(this.pbxBunho.BunHo.ToString(), "", "", "", this.ScreenName);
			}

			return null;
		}
		#endregion

		#endregion

		#region [PopUp Menu]
		IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();

		private void CreatePopUpMenu(string sPopMode)
		{
			//Item Clear
			popMenu.MenuCommands.Clear();

			//PopupMenu 
			IHIS.X.Magic.Menus.MenuCommand menuCmd = null;
            
			if(sPopMode == "0") // tvwNur_plan_bunryu
			{
                ////간호계획작성
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("新規/追加作成", this.ImageList.Images[5], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 0;
                popMenu.MenuCommands.Add(menuCmd);
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = "COPY";
                popMenu.MenuCommands.Add(menuCmd);
			}
			else if(sPopMode == "1") 
			{
                //간호계획수정
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("修正", this.ImageList.Images[5], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = 1;
                popMenu.MenuCommands.Add(menuCmd);
                
                ////간호계획평가
                //menuCmd = new IHIS.X.Magic.Menus.MenuCommand("評価", this.ImageList.Images[10], new EventHandler(OnPopMenuClick));
                //menuCmd.Tag = 2;
                //popMenu.MenuCommands.Add(menuCmd);

                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = "COPY";
                popMenu.MenuCommands.Add(menuCmd);
                
                
                if (this.tvwNUR4003.SelectedNode.Parent == null)
                {
                    if (this.tvwNUR4003.SelectedNode.BackColor == Color.LightGreen)
                    {
                        menuCmd = new IHIS.X.Magic.Menus.MenuCommand("計画終了取消", this.ImageList.Images[17], new EventHandler(OnPopMenuClick));
                        menuCmd.Tag = "END_CANCEL";
                        popMenu.MenuCommands.Add(menuCmd);
                    }
                    else
                    {
                        menuCmd = new IHIS.X.Magic.Menus.MenuCommand("計画終了", this.ImageList.Images[16], new EventHandler(OnPopMenuClick));
                        menuCmd.Tag = "END";
                        popMenu.MenuCommands.Add(menuCmd);
                    }
                }
			}
            //else if(sPopMode == "2") // 종료된 계획
            //{
            //    //간호계획수정
            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("修正", this.ImageList.Images[5], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = 1;
            //    popMenu.MenuCommands.Add(menuCmd);
                
            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = "COPY";
            //    popMenu.MenuCommands.Add(menuCmd);

            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("計画終了取消", this.ImageList.Images[17], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = "END_CANCEL";
            //    popMenu.MenuCommands.Add(menuCmd);
            //}
            //else if (sPopMode == "3") // 종료된 계획
            //{
            //    //간호계획수정
            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("修正", this.ImageList.Images[5], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = 1;
            //    popMenu.MenuCommands.Add(menuCmd);

            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = "COPY";
            //    popMenu.MenuCommands.Add(menuCmd);

            //    menuCmd = new IHIS.X.Magic.Menus.MenuCommand("計画終了", this.ImageList.Images[16], new EventHandler(OnPopMenuClick));
            //    menuCmd.Tag = "END";
            //    popMenu.MenuCommands.Add(menuCmd);
            //}


			
		}

		private void OnPopMenuClick(object sender, EventArgs e)
		{
			string menuItemIndex = ((IHIS.X.Magic.Menus.MenuCommand) sender).Tag.ToString();

			switch (menuItemIndex)
			{
				case "0":
					this.btnCreateNurPlan.PerformClick();
					break;

				case "1":
					this.btnModifyNurPlan.PerformClick();
					break;

				case "2":
					this.btnValue.PerformClick();
                    break;

                case "COPY":
                    Clipboard.SetDataObject(this.tvwNUR4003.SelectedNode.Text, true);
                    break;
                case "END":
                    PlanEnd("N");
                    break;
                case "END_CANCEL":
                    PlanEnd("Y");
                    break;
				default:

					break;
			}
		}

        private void PlanEnd(string end_option)
        {
            string cmdText = @"UPDATE NUR4002
                                   SET UPD_DATE          = SYSDATE
                                     , UPD_ID            = :q_user_id
                                     , VALD              = NVL(:f_vald, 'N')
                                 WHERE HOSP_CODE         = :f_hosp_code 
                                   AND PKNUR4002         = :f_pknur4002";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", this.mHospCode);
            bc.Add("q_user_id", UserInfo.UserID);
            bc.Add("f_pknur4002", tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0]);
            bc.Add("f_vald", end_option);
            if (!Service.ExecuteNonQuery(cmdText, bc))
            {
                XMessageBox.Show("処理に失敗しました。\r\n" + Service.ErrFullMsg, "失敗", MessageBoxIcon.Information);
                return;
            }
            this.layNUR4002.QueryLayout(true);
            ShowNUR4002();
        
        }

        #endregion

		#region [TreeView Info]
        
		#region [간호계획분류]
		private void ShowNur_plan_bunryu()
        {
            if (layNUR0402.RowCount < 1) return;
            this.tvwNur_plan_bunryu.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
            
			//Node 단계 check변수
			string nur_plan_bunryu = "";
			string nur_plan_jin    = "";
			TreeNode node;
            tvwNur_plan_bunryu.Nodes.Clear();

			foreach(DataRow row in layNUR0402.LayoutTable.Rows)
			{
				if(nur_plan_bunryu != row["nur_plan_bunryu"].ToString())
				{
					node = new TreeNode( row["nur_plan_bunryu_name"].ToString() );
					node.Tag = row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString() + "|" + row["nur_plan_bunryu"].ToString();

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Bold);
					tvwNur_plan_bunryu.Nodes.Add(node);
					nur_plan_bunryu = row["nur_plan_bunryu"].ToString();
					nur_plan_jin = "";
				}

				if(nur_plan_jin != row["nur_plan_jin"].ToString())
				{
					node = new TreeNode( row["nur_plan_jinname"].ToString() );
					node.Tag = row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString();

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].Nodes.Add(node);
					nur_plan_jin = row["nur_plan_jin"].ToString();
				}
				
				node = new TreeNode( row["nur_plan_proname"].ToString() );
				node.Tag = row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString();
				node.SelectedImageIndex = 4;
                node.ImageIndex = 4;

                node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
				tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].LastNode.Nodes.Add(node);				
			}

            this.tvwNur_plan_bunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
			//tvwNur_plan_bunryu.SelectedNode = tvwNur_plan_bunryu.Nodes[0].Nodes[0].Nodes[0];

		}

		private void tvwNur_plan_bunryu_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//간호계획을 선택했을 경우에만 popup을 띄운다.
			if(tvwNur_plan_bunryu.GetNodeAt(new Point(e.X, e.Y)) == null || tvwNur_plan_bunryu.GetNodeAt(new Point(e.X, e.Y)).Nodes.Count > 0) return;

			//PopUp Menu생성
			CreatePopUpMenu("0");

			if(e.Button == MouseButtons.Right && e.Clicks == 1)
			{
				//PopUp Menu Show
				tvwNur_plan_bunryu.SelectedNode = tvwNur_plan_bunryu.GetNodeAt(new Point(e.X, e.Y));				
				popMenu.TrackPopup(tvwNur_plan_bunryu.PointToScreen(new Point(e.X, e.Y)));
				
			}
		}
		#endregion

		
		#region [해당환자의 간호계획내역]
        
		private void ShowNUR4002()
		{
            this.tvwNUR4003.Nodes.Clear();
			if(layNUR4002.RowCount < 1) return;
            
			//Node 단계 check변수
			string nur_plan_jin = "";
			string nur_plan_pro = "";
			string nur_plan_ote = "";
			string nur_plan     = "";
			string pknur4002    = "";
            string nur4002_vald = "";
			TreeNode node;

			foreach(DataRow row in layNUR4002.LayoutTable.Rows)
			{
                this.tvwNUR4003.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterSelect);

				if(pknur4002 != row["pknur4002"].ToString())// || nur_plan_jin != row["nur_plan_jin"].ToString() || nur_plan_pro != row["nur_plan_pro"].ToString())
                {
					node = new TreeNode( row["nur_plan_proname"].ToString()+"  ▶▶▶ "+row["plan_user_name"].ToString() );
					node.Tag = row["pknur4002"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString();
                    
                    nur4002_vald = row["nur4002_vald"].ToString();
                    if (nur4002_vald == "N")
                        node.BackColor = Color.LightGreen;
                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Bold);

					tvwNUR4003.Nodes.Add(node);

					pknur4002    = row["pknur4002"].ToString();
					nur_plan_jin = row["nur_plan_jin"].ToString();
					nur_plan_pro = row["nur_plan_pro"].ToString();
					nur_plan_ote = "";
					nur_plan     = "";
				}

				if(nur_plan_ote != row["nur_plan_ote"].ToString())
				{     
					if( row["nur_plan_ote"].ToString() == "P" )
						node = new TreeNode( "P - 目標" );
					else if( row["nur_plan_ote"].ToString() == "O" )
						node = new TreeNode( "O - 観察" );
					else if( row["nur_plan_ote"].ToString() == "T" )
						node = new TreeNode( "T - ケア" );
					else
						node = new TreeNode( "E - 指導" );
                    
					node.Tag = row["pknur4002"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString() + "|" + row["nur_plan_ote"].ToString();
					node.SelectedImageIndex = 7;
					node.ImageIndex = 7;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count -1].Nodes.Add(node);
					nur_plan_ote = row["nur_plan_ote"].ToString();
				}

				if(nur_plan != row["nur_plan"].ToString())
				{     
					node = new TreeNode( row["nur_plan_name"].ToString() );     
					node.Tag = row["pknur4002"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString() + "|" + row["nur_plan"].ToString();
					node.SelectedImageIndex = 8;
					node.ImageIndex = 8;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count -1].LastNode.Nodes.Add(node);    
					nur_plan = row["nur_plan"].ToString();
				}

    
				if(row["nur_plan_detail"].ToString() != "")
				{
					node = new TreeNode( row["nur_plan_dename"].ToString() );
					node.Tag = row["pknur4002"].ToString() + "|" + row["nur_plan_jin"].ToString() + "|" + row["nur_plan_pro"].ToString() + "|" + row["nur_plan_detail"].ToString();
					node.SelectedImageIndex = 9;
					node.ImageIndex = 9;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count -1].LastNode.LastNode.Nodes.Add(node);
				}
			}

            //tvwNUR4003.ExpandAll();
            this.tvwNUR4003.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterSelect);

			//if(layNUR4002.RowCount > 0) tvwNUR4003.SelectedNode = tvwNUR4003.Nodes[0];
		}

        string old_pknur4002 = "";
        string new_pknur4002 = "";
		private void tvwNUR4003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{	
            if(e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                tvwNUR4003.SelectedNode = tvwNUR4003.GetNodeAt(new Point(e.X, e.Y));

                //if (this.tvwNUR4003.SelectedNode.Parent == null)
                //{
                //    if (this.tvwNUR4003.SelectedNode.BackColor == Color.LightGreen)
                //    {
                //        //PopUp Menu생성
                //        CreatePopUpMenu("2");
                //    }
                //    else
                //    {
                //        //PopUp Menu생성
                //        CreatePopUpMenu("3");
                //    }
                //}
                //else
                //{
                //    //PopUp Menu생성
                //    CreatePopUpMenu("1");
                //}
                //PopUp Menu생성
                CreatePopUpMenu("1");  
				//PopUp Menu Show			
				popMenu.TrackPopup(tvwNUR4003.PointToScreen(new Point(e.X, e.Y)));				
			}
		}

		#endregion

		#endregion

		#region [Function]
        
		/// <summary>
		/// 간호계획 작성화면을 Show한다.
		/// </summary>
		private void ShowNUR4002U01( string aBunho, int aFkinp1001, string aNur_plan_jin, string aNur_plan_pro, int aPknur4002)
		{
			if(TypeCheck.IsNull(aBunho) || TypeCheck.IsNull(aFkinp1001) ) return;
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add( "bunho"       , aBunho);
			openParams.Add( "fkinp1001"   , aFkinp1001);
			openParams.Add( "nur_plan_jin", aNur_plan_jin);
			openParams.Add( "nur_plan_pro", aNur_plan_pro);
			openParams.Add( "pknur4002"   , aPknur4002);
			//간호계획 작성화면 Open
			XScreen.OpenScreenWithParam( this, "NURI", "NUR4002U01", ScreenOpenStyle.ResponseFixed, openParams);

			this.layNUR4002.QueryLayout(true);
			ShowNUR4002();
		}

		/// <summary>
		/// 간호계획 평가화면을 Show한다.
		/// </summary>
		private void ShowNUR4005U00( int aFkinp1001, int aPknur4002)
		{
			if(TypeCheck.IsNull(aFkinp1001) ) return;
			CommonItemCollection openParams  = new CommonItemCollection();
			openParams.Add( "fkinp1001"   , aFkinp1001);
			openParams.Add( "pknur4002"   , aPknur4002);
			//간호계획 작성화면 Open
			XScreen.OpenScreenWithParam( this, "NURI", "NUR4005U00", ScreenOpenStyle.ResponseFixed, openParams);
		}


		#endregion

		#region [Button Click]
        
		/// <summary>
		/// 간호계획 작성
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCreateNurPlan_Click(object sender, System.EventArgs e)
		{
			if( tvwNur_plan_bunryu.SelectedNode == null ) return;
			string nur_plan_jin = tvwNur_plan_bunryu.SelectedNode.Tag.ToString().Split('|')[0];
			string nur_plan_pro = tvwNur_plan_bunryu.SelectedNode.Tag.ToString().Split('|')[1];
			ShowNUR4002U01(mBunho, mFkinp1001, nur_plan_jin, nur_plan_pro, 0);
		}	

		/// <summary>
		/// 간호계획 수정
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnModifyNurPlan_Click(object sender, System.EventArgs e)
		{
			if( tvwNUR4003.SelectedNode == null ) return;
			try
			{
				int    pknur4002    = int.Parse(tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0]);
				string nur_plan_jin = tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[1];
				string nur_plan_pro = tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[2];
				ShowNUR4002U01(mBunho, mFkinp1001, nur_plan_jin, nur_plan_pro, pknur4002);
			}
			catch{}
		}
        
		/// <summary>
		/// 간호계획평가
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnValue_Click(object sender, System.EventArgs e)
		{
			if(this.layNUR4002.RowCount == 0) return;

			if( tvwNUR4003.SelectedNode != null )
			{
				try
				{
					int    pknur4002    = int.Parse(tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0]);
					ShowNUR4005U00(mFkinp1001, pknur4002);
				}
				catch{}		
			}
			else
				ShowNUR4005U00(mFkinp1001, 0);
		}

		#endregion

		#region 환자번호입력시
		private void pbxBunho_PatientSelected(object sender, System.EventArgs e)
        {
            this.tvwNUR4003.Nodes.Clear();
            
			if(!TypeCheck.IsNull(this.pbxBunho.BunHo.ToString()))
			{
				/* 환자의 입원이력을 조회한다. */
				if(!this.grdInp1001.QueryLayout(false))
				{
					XMessageBox.Show(Service.ErrFullMsg.ToString());
					return;
				}
				/* 재원환자 정보 조회 2006년 주석처리를 다시 살림(2011.11.26 woo)*/
				this.Fkinp1001();
			}
		}

        /*환자번호가 Null값이거나 잘못된 번호일 경우(2011.11.25 woo)*/
        private void pbxBunho_PatientSelectionFailed(object sender, EventArgs e)
        {
            this.grdInp1001.Reset();
            this.tvwNUR4003.Nodes.Clear();
        }

		#endregion

		/// <summary>
		/// 환자의 재원여부를 조회한다.
		/// </summary>
		#region 재원여부 조회
		private void Fkinp1001()
		{
			/* 환자의 입원이력을 조회한다. */
            if (!this.layFkinp1001.QueryLayout())
            {
                //XMessageBox.Show(Service.ErrFullMsg);
            }

            if (this.layFkinp1001.GetItemValue("fkinp1001").ToString() == "")
			{
                /* 재원중인 환자가 아니므로 메세지를 보여준다. */
                mFkinp1001 = 0;
                this.GetMessage("jeawonYn");
			}
            //else
            //{//재원 환자일 경우
            //    mFkinp1001 = int.Parse(this.layFkinp1001.GetItemValue("fkinp1001").ToString());
            //    //Load 간호계획정보]
            //    //this.DataServiceCall(dsvLDNUR0402,true);
            //    //ShowNur_plan_bunryu();

            //    //Load 해당환자 간호계획정보
            //    //this.layNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
            //}
            //mBunho = this.pbxBunho.BunHo.ToString();

            ////간호계획 조회
            //if (this.layNUR4002.QueryLayout(true)) { }
            //else
            //{
            //    XMessageBox.Show(Service.ErrFullMsg);
            //}

            ////after Service
            //ShowNUR4002();
            
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
			
			switch(aMesgGubun)
			{
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + "\n" +" 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。" + "\n" + "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nur_plan_pro":
					msg = (NetInfo.Language == LangMode.Ko ? "문제점번호를 입력해 주세요."
						: "問題点番号を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "에러" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 그리드에서 입원이력을 선택을 했을 때
		private void grdInp1001_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(this.grdInp1001.RowCount < 0) return;
			if(e.CurrentRow < 0) return;

			if(this.grdInp1001.GetItemValue(e.CurrentRow, "pkinp1001").ToString() != "")
			{
				mFkinp1001 = int.Parse(this.grdInp1001.GetItemValue(e.CurrentRow, "pkinp1001").ToString());
				mBunho     = this.pbxBunho.BunHo.ToString();

				if(mFkinp1001 != 0)
				{
					//Load 간호계획정보]
                    if (this.layNUR0402.QueryLayout(true)) { }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    ShowNur_plan_bunryu();

					//Load 해당환자 간호계획정보
					this.layNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
                    if (this.layNUR4002.QueryLayout(true)) { }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
					//after Service
					ShowNUR4002();
				}
				return;
			}
			else                                      //재원환자가 아니면(조회만 가능)
			{
				/* 재원중인 환자가 아니므로 메세지를 보여준다. */
				mFkinp1001 = 0;
				this.GetMessage("jeawonYn");
				return;
			}
		}
		#endregion

        #region layNUR4002_QueryEnd
        private void layNUR4002_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //int o_seq= 0;
            //int t_seq = 0;
            //int e_seq = 0;
            //string nur_plan_ote = "";
            //string nur_plan_name = "";
            //string t_nur_plan_jin = "";
            //string t_nur_plan_pro = "";

            //for (int i = 0; i < this.layNUR4002.RowCount; i++)
            //{
            //    nur_plan_ote = this.layNUR4002.GetItemString(i, "nur_plan_ote");
            //    nur_plan_name = this.layNUR4002.GetItemString(i, "nur_plan_name");

            //    switch (nur_plan_ote)
            //    { 
            //        case "O":
            //            o_seq++;
            //            this.layNUR4002.SetItemValue(i, "nur_dis_plan_name", nur_plan_ote + "-" + o_seq.ToString() + " " + nur_plan_name);
            //            break;

            //        case "T":
            //            t_seq++;
            //            this.layNUR4002.SetItemValue(i, "nur_dis_plan_name", nur_plan_ote + "-" + t_seq.ToString() + " " + nur_plan_name);
            //            break;

            //        case "E":
            //            e_seq++;
            //            this.layNUR4002.SetItemValue(i, "nur_dis_plan_name", nur_plan_ote + "-" + e_seq.ToString() + " " + nur_plan_name);
            //            break;

            //        case "P":
            //            this.layNUR4002.SetItemValue(i, "nur_dis_plan_name", nur_plan_name);
            //            break;
            //    }

            //    if (this.layNUR4002.GetItemString(i, "nur_plan_jin").Equals(t_nur_plan_jin) || this.layNUR4002.GetItemString(i, "nur_plan_pro").Equals(t_nur_plan_pro))
            //    {
            //        o_seq = 0;
            //        t_seq = 0;
            //        e_seq = 0;                    
            //    }

            //    t_nur_plan_jin = this.layNUR4002.GetItemString(i, "nur_plan_jin");
            //    t_nur_plan_pro = this.layNUR4002.GetItemString(i, "nur_plan_pro");
            //}
        }
        #endregion

        #region QueryStarting
        private void layNUR4002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR4002.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
        }

        private void grdInp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            /* 조회하기전에 먼저 TreeView 클리어. 이유는, 
             * 기록있는 환자 조회 후 기록없는 환자 조회 시 TreeView 기록이 남아 있었기 때문에. */
            this.grdInp1001.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdInp1001.SetBindVarValue("f_bunho", this.pbxBunho.BunHo);
        }

        private void layFkinp1001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layFkinp1001.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layFkinp1001.SetBindVarValue("f_bunho", this.pbxBunho.BunHo);
        }

        private void layNUR0402_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR0402.SetBindVarValue("f_hosp_code", this.mHospCode);
        }
        #endregion


        #region 평가일이 지난 데이터를 색깔로 표시
        private void grdNUR4005_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
        {
            if (!TypeCheck.IsNull(e.DataRow["value_date"].ToString()))
            {
                if (int.Parse(DateTime.Parse(e.DataRow["value_date"].ToString()).ToString("yyyyMMdd")) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
                {
                    e.BackColor = Color.LightGray;
                }
            }
        }
        #endregion

        private void grdNUR4005_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            //if (this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") != "Y")
            //{
            //    e.Protect = true;
            //}
            //else
            //{
            //    e.Protect = false;
            //}
        }

        private void grdNUR4005_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdNUR4005
            for (int rowIndex = 0; rowIndex < grdNUR4005.RowCount; rowIndex++)
            {
                if (grdNUR4005.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdNUR4005.GetItemString(rowIndex, "reser_date").Trim() == "")
                    {
                        grdNUR4005.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }
            }
        }

        private void grdNUR4005_QueryStarting(object sender, CancelEventArgs e)
        {
            string pknur4002 = tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0];            
            this.grdNUR4005.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR4005.SetBindVarValue("f_pknur4002", pknur4002);
        }

        private void grdNUR4005_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            e.Cancel = false;

            switch (e.ColName)
            {
                case "reser_date":

                    //if(e.ChangeValue.ToString().Trim() == "" ) break;

                    //// 중복 Check
                    //// 현재 화면에서만 check
                    //// (만약 조건 및 continue로 Grid상에 Data를 가져오는 경우 DeleteTable, 서버 모두감안해야 한다.)
                    //for(int i = 0; i < grdNUR4005.RowCount; i++)
                    //{
                    //    if(i != e.RowNumber)
                    //    {
                    //        if( grdNUR4005.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim() )
                    //        {
                    //            mbxMsg = NetInfo.Language == LangMode.Jr ? "予定日付が重なります。 ご確認ください。" : "예정일자가 중복됩니다. 확인바랍니다.";
                    //            mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                    //            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                    //            e.Cancel= true;								
                    //        }
                    //    }
                    //}
                    break;
                case "value_date":

                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 중복 Check
                    // 현재 화면에서만 check
                    // (만약 조건 및 continue로 Grid상에 Data를 가져오는 경우 DeleteTable, 서버 모두감안해야 한다.)
                    for (int i = 0; i < grdNUR4005.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdNUR4005.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = NetInfo.Language == LangMode.Jr ? "評価日付が重なります。 ご確認ください。" : "예정일자가 중복됩니다. 확인바랍니다.";
                                mbxCap = NetInfo.Language == LangMode.Jr ? "" : "";
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                                e.Cancel = true;
                                return;
                            }
                        }
                    }

                    this.grdNUR4005.SetItemValue(e.RowNumber, "reser_date", e.ChangeValue);
                    break;

                default:
                    break;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int insertedRowNum = this.grdNUR4005.InsertRow();
            string pknur4002 = tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0];
            this.grdNUR4005.SetItemValue(insertedRowNum, "fknur4002", pknur4002);
            string sysdate = EnvironInfo.GetSysDate().ToString();
            this.grdNUR4005.SetItemValue(insertedRowNum, "value_date", sysdate);
            this.grdNUR4005.SetItemValue(insertedRowNum, "reser_date", sysdate);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.grdNUR4005.RowCount < 1)
                return;

            this.grdNUR4005.DeleteRow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grdNUR4005.RowCount; i++)
            {
                if (this.grdNUR4005.GetItemString(i, "value_date") == "")
                {
                    XMessageBox.Show("評価日付を入力してください。", "評価日付未入力", MessageBoxIcon.Information);
                    this.grdNUR4005.SetFocusToItem(i, "value_date");
                    return;
                }
            }

            if (!this.grdNUR4005.SaveLayout())
            {
                XMessageBox.Show("看護計画の評価の保存に失敗しました。", "保存失敗", MessageBoxIcon.Information);

            }
        }

        private void tvwNUR4003_AfterSelect(object sender, TreeViewEventArgs e)
        {	
            new_pknur4002 = tvwNUR4003.SelectedNode.Tag.ToString().Split('|')[0];

            if (old_pknur4002 != new_pknur4002)
            {
                string [] path = this.tvwNUR4003.SelectedNode.FullPath.Split('\\');
                if (path.Length > 0)
                {
                    this.lbSelectedPlanName.Text = path[0];   
                }
                this.grdNUR4005.QueryLayout(false);
            }

            old_pknur4002 = new_pknur4002;
        }

        private void tvwNur_plan_bunryu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
                return;

            string nur_plan_jin = e.Node.Tag.ToString().Split('|')[0];
            string nur_plan_pro = e.Node.Tag.ToString().Split('|')[1];
            //string nur_plan_bunryu = e.Node.Tag.ToString().Split('|')[2];

            this.layPlanInfo.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.layPlanInfo.SetBindVarValue("f_nur_plan_jin", nur_plan_jin);
            this.layPlanInfo.SetBindVarValue("f_nur_plan_pro", nur_plan_pro);
            this.layPlanInfo.QueryLayout(true);
        }

        private void layPlanInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //this.tvwNUR4003.BeforeSelect -= new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
            this.tvwSelector.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            tvwSelector.Nodes.Clear();
            if (layPlanInfo.RowCount < 1) return;

            //Node 단계 check변수
            string nur_plan_ote = "";
            string nur_plan = "";
            TreeNode node;

            foreach (DataRow row in layPlanInfo.LayoutTable.Rows)
            {
                if (nur_plan_ote != row["nur_plan_ote"].ToString())
                {
                    if (row["nur_plan_ote"].ToString() == "P")
                        node = new TreeNode("P - 目標");
                    else if (row["nur_plan_ote"].ToString() == "O")
                        node = new TreeNode("O - 観察");
                    else if (row["nur_plan_ote"].ToString() == "T")
                        node = new TreeNode("T - ケア");
                    else
                        node = new TreeNode("E - 指導");

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "GP");
                    t_tag_table.Add("nur_plan_ote", row["nur_plan_ote"].ToString());
                    t_tag_table.Add("fknur4002", row["fknur4002"].ToString());

                    node.Tag = t_tag_table;
                    node.Checked = true;
                    node.SelectedImageIndex = 0;
                    node.ImageIndex = 0;
                    tvwSelector.Nodes.Add(node);
                    nur_plan_ote = row["nur_plan_ote"].ToString();
                    nur_plan = "";
                }

                if (nur_plan != row["nur_plan"].ToString())
                {
                    node = new TreeNode(row["nur_plan_name"].ToString());

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "P");
                    t_tag_table.Add("nur_plan_ote", nur_plan_ote);
                    t_tag_table.Add("nur_plan", row["nur_plan"].ToString());
                    t_tag_table.Add("pknur4003", row["pknur4003"].ToString());
                    t_tag_table.Add("fknur4002", row["fknur4002"].ToString());

                    node.Tag = t_tag_table;
                    node.Checked = true;

                    tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].Nodes.Add(node);
                    nur_plan = row["nur_plan"].ToString();
                }


                if (row["nur_plan_detail"].ToString().Trim() != "X")
                {
                    node = new TreeNode(row["nur_plan_dename"].ToString());

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "C");
                    t_tag_table.Add("nur_plan_ote", nur_plan_ote);
                    t_tag_table.Add("nur_plan", nur_plan);
                    t_tag_table.Add("pknur4004", row["pknur4004"].ToString());
                    t_tag_table.Add("nur_plan_detail", row["nur_plan_detail"].ToString());
                    t_tag_table.Add("pknur4003", row["pknur4003"].ToString());
                    t_tag_table.Add("fknur4002", row["fknur4002"].ToString());

                    node.Tag = t_tag_table;
                    node.Checked = true;

                    tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].LastNode.Nodes.Add(node);
                }
            }
            tvwSelector.ExpandAll();

            if (this.tvwSelector.Nodes.Count > 0)
            {
                this.tvwSelector.SelectedNode = this.tvwSelector.Nodes[0];
            }
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            //this.tvwNUR4003.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);

        }

        private void tvwSelector_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvwSelector.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            TreeNode node = e.Node;            

            if (node.Checked)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = true;

                    //자식이 있다면 자식에도 체크
                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        node2.Checked = true;
                    }
                }

                //부모가 있다면 부모도 체크
                TreeNode parentNode = node.Parent;
                if (parentNode != null)
                {
                    parentNode.Checked = true;

                    TreeNode parentNode2 = parentNode.Parent;

                    if (parentNode2 != null)
                    {
                        parentNode2.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = false;

                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        node2.Checked = false;
                    }
                }

                //부모가 있다면 부모도 체크품
                TreeNode parentNode = node.Parent;
                if (parentNode != null)
                {
                    bool childSelected = false;

                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Checked)
                            childSelected = true;
                    }

                    if (!childSelected)
                    {
                        parentNode.Checked = false;

                        TreeNode parentNode2 = parentNode.Parent;

                        if (parentNode2 != null)
                        {
                            bool parentSelected = false;

                            foreach (TreeNode parent in parentNode2.Nodes)
                            {
                                if (parent.Checked)
                                    parentSelected = true;
                            }

                            if (!parentSelected)
                            {
                                parentNode2.Checked = false;
                            }
                        }
                    }
                }
            }
            
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);

        }

        string t_pknur4002 = "";
        string t_pknur4003 = "";
        private void btnAdd1_Click(object sender, EventArgs e)
        {
            if (tvwSelector.Nodes.Count < 1)
                return;

            bool isSelected = false;
            foreach (TreeNode node in tvwSelector.Nodes)
            {
                if (node.Checked)
                {
                    isSelected = true;
                    break;
                }
            }

            if (!isSelected)
                return;
            
            string nur_plan_jin = this.tvwNur_plan_bunryu.SelectedNode.Tag.ToString().Split('|')[0];
            string nur_plan_pro = this.tvwNur_plan_bunryu.SelectedNode.Tag.ToString().Split('|')[1];
            //string nur_plan_bunryu = e.Node.Tag.ToString().Split('|')[2];


            string cmdText = @"SELECT 'Y'
                                  FROM DUAL
                                 WHERE EXISTS ( SELECT 'X' 
                                                  FROM NUR4002
                                                 WHERE HOSP_CODE    = :f_hosp_code
                                                   AND FKINP1001    = :f_fkinp1001
                                                   AND NUR_PLAN_JIN = :f_nur_plan_jin
                                                   AND NUR_PLAN_PRO = :f_nur_plan_pro
                                                   AND NVL(VALD, 'Y') = 'Y'  )";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", this.mHospCode);
            bc.Add("f_fkinp1001", this.grdInp1001.GetItemString(this.grdInp1001.CurrentRowNumber, "pkinp1001"));
            bc.Add("f_nur_plan_jin", nur_plan_jin);
            bc.Add("f_nur_plan_pro", nur_plan_pro);

            object dup_yn = Service.ExecuteScalar(cmdText, bc);

            if (!TypeCheck.IsNull(dup_yn))
            {
                if (dup_yn.ToString() == "Y")
                {
                    XMessageBox.Show("既に登録されている看護計画です。","登録失敗",MessageBoxIcon.Information);
                    return;
                }
            }

            int insertRow = grdNUR4002.InsertRow(-1);
            grdNUR4002.SetItemValue(insertRow, "pknur4002", 0);
            grdNUR4002.SetItemValue(insertRow, "bunho", mBunho);
            grdNUR4002.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
            grdNUR4002.SetItemValue(insertRow, "nur_plan_jin", nur_plan_jin);
            grdNUR4002.SetItemValue(insertRow, "nur_plan_pro", nur_plan_pro);

            string nur_plan_proname = this.tvwNur_plan_bunryu.SelectedNode.Text;

            grdNUR4002.SetItemValue(insertRow, "nur_plan_proname", nur_plan_proname);
            grdNUR4002.SetItemValue(insertRow, "plan_user", UserInfo.UserID);
            grdNUR4002.SetItemValue(insertRow, "plan_usnm", UserInfo.UserName);
            grdNUR4002.SetItemValue(insertRow, "plan_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            grdNUR4002.SetItemValue(insertRow, "vald", "Y");
            grdNUR4002.SetItemValue(insertRow, "nur0402_valid", "Y");

            grdNUR4002.AcceptData();

            try
            {
                Service.BeginTransaction();

                if (!this.grdNUR4002.SaveLayout())
                    throw new Exception();

                ApplyDataildata(0);

                if (!this.dloDetailData.SaveLayout())
                    throw new Exception();

                Service.CommitTransaction();

            }
            catch
            {
                Service.RollbackTransaction();
                XMessageBox.Show(Service.ErrFullMsg);
                return;
            
            }
            
			this.layNUR4002.QueryLayout(true);
            ShowNUR4002();

            if (this.tvwNUR4003.GetNodeCount(false) > 0)
            {
                this.tvwNUR4003.SelectedNode = this.tvwNUR4003.Nodes[this.tvwNUR4003.GetNodeCount(false) - 1];
                this.tvwNUR4003.SelectedNode.ExpandAll();
            }

        }


        /// <summary>
        /// 변경된 정보를 적용한다.
        /// 1. 선택여부            Insert or Update
        /// 2. Label Text변경여부  Update
        /// 3. Sort순서 설정       Update
        /// </summary>
        /// <param name="aPknur4002"></param>
        private void ApplyDataildata(int aPknur4002)
        {
            int fknur4002 = 0;
            int pknur4003 = 0;
            string nur_plan_ote = "";
            string nur_plan = "";
            string nur4003_vald = "";
            int nur4003_sort;
            int pknur4004 = 0;
            string nur_plan_detail = "";
            string nur4004_vald = "";
            int nur4004_sort;
            Hashtable t_tag;

            foreach (TreeNode node_ote in this.tvwSelector.Nodes)
            {
                t_tag = (Hashtable)node_ote.Tag;

                nur4003_sort = 0;

                foreach (TreeNode node_nur4003 in node_ote.Nodes)
                {
                    nur4003_sort++;

                    t_tag = (Hashtable)node_nur4003.Tag;
                    fknur4002 = int.Parse(t_tag["fknur4002"].ToString());
                    pknur4003 = int.Parse(t_tag["pknur4003"].ToString());
                    nur_plan = t_tag["nur_plan"].ToString();
                    nur_plan_ote = t_tag["nur_plan_ote"].ToString();
                    string added_yn_4003 = t_tag["added_yn"].ToString();

                    //선택여부에 따라 해당 row Valid 설정
                    if (node_nur4003.Checked)
                        nur4003_vald = "Y";
                    else
                        nur4003_vald = "N";

                    if (pknur4003 == 0 && nur4003_vald == "N") continue;

                    if (added_yn_4003 == "N")
                    {
                        DataRow[] t_rows = layPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' ", "");

                        if (t_rows.Length > 0)
                        {
                            int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount);

                            dloDetailData.SetItemValue(insertedRowNum, "fknur4002", aPknur4002);
                            dloDetailData.SetItemValue(insertedRowNum, "pknur4003", pknur4003);
                            dloDetailData.SetItemValue(insertedRowNum, "nur_plan", nur_plan);
                            dloDetailData.SetItemValue(insertedRowNum, "nur_plan_ote", nur_plan_ote);
                            dloDetailData.SetItemValue(insertedRowNum, "nur_plan_name", node_nur4003.Text);
                            dloDetailData.SetItemValue(insertedRowNum, "nur4003_sort", nur4003_sort);
                            dloDetailData.SetItemValue(insertedRowNum, "nur4003_vald", nur4003_vald);

                            // 이거 안넣어주면 저장할때 nur4004까지 만들어 버림
                            dloDetailData.SetItemValue(insertedRowNum, "pknur4004", "");
                            dloDetailData.SetItemValue(insertedRowNum, "nur_plan_detail", "");

                        }
                    }
                    else //추가항목인경우
                    {
                        int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount);

                        dloDetailData.SetItemValue(insertedRowNum, "fknur4002", fknur4002);
                        dloDetailData.SetItemValue(insertedRowNum, "pknur4003", pknur4003);
                        dloDetailData.SetItemValue(insertedRowNum, "nur_plan", nur_plan);
                        dloDetailData.SetItemValue(insertedRowNum, "nur_plan_ote", nur_plan_ote);
                        dloDetailData.SetItemValue(insertedRowNum, "nur_plan_name", node_nur4003.Text);
                        dloDetailData.SetItemValue(insertedRowNum, "nur4003_sort", nur4003_sort);
                        dloDetailData.SetItemValue(insertedRowNum, "nur4003_vald", nur4003_vald);

                        // 이거 안넣어주면 저장할때 nur4004까지 만들어 버림
                        dloDetailData.SetItemValue(insertedRowNum, "pknur4004", "");
                        dloDetailData.SetItemValue(insertedRowNum, "nur_plan_detail", "");
                    }

                    //문제항목의 Detail이 있는 경우
                    if (node_nur4003.Nodes.Count > 0)
                    {
                        nur4004_sort = 0;

                        foreach (TreeNode node_nur4004 in node_nur4003.Nodes)
                        {
                            nur4004_sort++;
                            t_tag = (Hashtable)node_nur4004.Tag;
                            pknur4004 = int.Parse(t_tag["pknur4004"].ToString());
                            nur_plan_detail = t_tag["nur_plan_detail"].ToString();
                            string added_yn_4004 = t_tag["added_yn"].ToString();

                            //선택여부에 따라 해당 row Valid 설정
                            if (node_nur4004.Checked)
                                nur4004_vald = "Y";
                            else
                                nur4004_vald = "N";

                            if (pknur4004 == 0 && nur4004_vald == "N") continue;

                            if (added_yn_4004 == "N")
                            {
                                foreach (DataRow row_nur4004 in layPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' and nur_plan_detail = '" + nur_plan_detail + "' ", ""))
                                {
                                    //Origin data와 비교해서 변경시 Origin data변경
                                    if (row_nur4004["nur_plan_name"].ToString() != node_nur4003.Text)
                                        row_nur4004["nur_plan_name"] = node_nur4003.Text;

                                    if (row_nur4004["nur4003_vald"].ToString() != nur4003_vald)
                                        row_nur4004["nur4003_vald"] = nur4003_vald;

                                    row_nur4004["nur4003_sort"] = nur4003_sort;
                                    row_nur4004["nur4004_sort"] = nur4004_sort;

                                    if (row_nur4004["nur_plan_dename"].ToString() != node_nur4004.Text)
                                        row_nur4004["nur_plan_dename"] = node_nur4004.Text;

                                    if (row_nur4004["nur4004_vald"].ToString() != nur4004_vald)
                                        row_nur4004["nur4004_vald"] = nur4004_vald;

                                    // 이거 안넣어주면 저장할때 nur4003까지 만들어 버림
                                    if (pknur4003 == 0)
                                        row_nur4004["pknur4003"] = "";

                                    //if (row_nur4004["nur4004_vald"].ToString() != nur4004_vald)
                                    dloDetailData.LayoutTable.ImportRow(row_nur4004);
                                }
                            }
                            else //추가항목인경우
                            {
                                int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount);

                                dloDetailData.SetItemValue(insertedRowNum, "pknur4004", pknur4004);
                                dloDetailData.SetItemValue(insertedRowNum, "fknur4002", fknur4002);
                                dloDetailData.SetItemValue(insertedRowNum, "pknur4003", pknur4003);
                                dloDetailData.SetItemValue(insertedRowNum, "nur_plan", nur_plan);
                                dloDetailData.SetItemValue(insertedRowNum, "nur_plan_detail", nur_plan_detail);
                                dloDetailData.SetItemValue(insertedRowNum, "nur_plan_dename", node_nur4004.Text);
                                dloDetailData.SetItemValue(insertedRowNum, "nur4004_sort", nur4004_sort);
                                dloDetailData.SetItemValue(insertedRowNum, "nur4004_vald", nur4004_vald);

                            }
                        }
                    }
                }
            }
        }


        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            NUR4002U00 parent;

            public XSavePerformer(NUR4002U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                //t_pknur4002 = "";
                                /*중복체크*/
                                cmdText = @"SELECT NUR4002_SEQ.NEXTVAL FROM DUAL";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                cmdText = "";

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    parent.t_pknur4002 = retVal.ToString();
                                }
                                else
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }

                                cmdText = @"SELECT NVL(MAX(SORT_KEY), 0) + 1    SORT_KEY
                                          FROM NUR4002
                                         WHERE HOSP_CODE = :f_hosp_code
                                           AND FKINP1001 = :f_fkinp1001
                                           --AND NVL(VALD, 'Y') = 'Y'
                                           ";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    item.BindVarList.Add("f_sort_key", retVal.ToString());
                                }
                                else
                                {
                                    item.BindVarList.Add("f_sort_key", "1");
                                }


                                item.BindVarList.Add("t_pknur4002", parent.t_pknur4002);

                                cmdText = @"INSERT INTO NUR4002
                                               ( SYS_DATE       , SYS_ID        , UPD_DATE          , UPD_ID            , HOSP_CODE    ,  
                                                 PKNUR4002      ,
                                                 BUNHO          , FKINP1001     , NUR_PLAN_JIN      , NUR_PLAN_PRO      ,
                                                 PLAN_USER      , PLAN_DATE     , VALD              , NUR_PLAN_PRO_NAME , SORT_KEY     )
                                         VALUES
                                               ( SYSDATE        , :q_user_id    , SYSDATE           , :q_user_id        , :f_hosp_code,
                                                 :t_pknur4002   ,   
                                                 :f_bunho       , :f_fkinp1001  , :f_nur_plan_jin   , :f_nur_plan_pro   ,
                                                 :f_plan_user   , :f_plan_date  , 'Y'               , :f_nur_plan_proname, :f_sort_key  )";

                                break;

                            case DataRowState.Modified:

                                /* 수정가능 여부를 체크한다. */
                                /* 평가를 한 정보를 수정 불가능 */
                                cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS (SELECT 'X'
                                                         FROM NUR4005
                                                        WHERE HOSP_CODE = :f_hosp_code 
                                                          AND FKNUR4002 = :f_pknur4002    ) ";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                cmdText = "";

                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("評価済みの看護計画情報は修正できません。", "注意", MessageBoxIcon.Warning);
                                    return false;
                                }
                                cmdText = @"UPDATE NUR4002
		                                   SET UPD_DATE          = SYSDATE
                                             , UPD_ID            = :q_user_id
                                             , PLAN_DATE         = :f_plan_date
		                                     , NUR_PLAN_PRO_NAME = :f_nur_plan_proname
		                                 WHERE HOSP_CODE         = :f_hosp_code 
                                           AND PKNUR4002         = :f_pknur4002";

                                break;

                            case DataRowState.Deleted:
                                /* 삭제가능 여부를 체크한다. */
                                /* 평가를 한 정보를 삭제 불가능 */
                                cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS (SELECT 'X'
                                                         FROM NUR4005
                                                        WHERE HOSP_CODE = :f_hosp_code 
                                                          AND FKNUR4002 = :f_pknur4002   ) ";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                cmdText = "";

                                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("該当項目の評価情報があるので削除できません。", "注意", MessageBoxIcon.Warning);
                                    return false;
                                }

                                cmdText = @"UPDATE NUR4002
                                           SET UPD_ID        = :q_user_id      ,
                                               UPD_DATE      = SYSDATE         ,
                                               VALD          = 'N'
                                         WHERE HOSP_CODE     = :f_hosp_code 
                                           AND PKNUR4002     = :f_pknur4002";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return false;
                                    }
                                }

                                cmdText = "";
                                cmdText = @"UPDATE NUR4003
                                           SET UPD_ID    = :q_user_id,
                                               UPD_DATE  = SYSDATE,
                                               VALD      = 'N'
                                         WHERE HOSP_CODE = :f_hosp_code 
                                           AND FKNUR4002 = :f_pknur4002";

                                if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                                {
                                    if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                    {
                                        XMessageBox.Show(Service.ErrFullMsg);
                                        return false;
                                    }
                                }
                                cmdText = "";

                                MultiLayout layDeleteNUR4004 = new MultiLayout();
                                layDeleteNUR4004.LayoutItems.Add("pknur4003", DataType.String);
                                layDeleteNUR4004.InitializeLayoutTable();

                                layDeleteNUR4004.QuerySQL = @"SELECT PKNUR4003
                                                              FROM NUR4003
                                                             WHERE HOSP_CODE = :f_hosp_code 
                                                               AND FKNUR4002 = :f_pknur4002";

                                layDeleteNUR4004.SetBindVarValue("f_hosp_code", item.BindVarList["f_hosp_code"].VarValue);
                                layDeleteNUR4004.SetBindVarValue("f_pknur4002", item.BindVarList["f_pknur4002"].VarValue);

                                if (!layDeleteNUR4004.QueryLayout(true))
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }

                                BindVarCollection bc = new BindVarCollection();

                                for (int i = 0; i < layDeleteNUR4004.RowCount; i++)
                                {
                                    cmdText = @"UPDATE NUR4004
                                               SET UPD_ID    = :q_user_id,
                                                   UPD_DATE  = SYSDATE,
                                                   VALD      = 'N'
                                             WHERE HOSP_CODE = :f_hosp_code 
                                               AND FKNUR4003 = :o_pknur4003";
                                    bc.Clear();
                                    bc.Add("f_hosp_code", item.BindVarList["f_hosp_code"].VarValue);
                                    bc.Add("q_user_id", item.BindVarList["q_user_id"].VarValue);
                                    bc.Add("o_pknur4003", layDeleteNUR4004.GetItemString(i, "pknur4003"));

                                    if (!Service.ExecuteNonQuery(cmdText, bc))
                                    {
                                        if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                        {
                                            XMessageBox.Show(Service.ErrFullMsg);
                                            return false;
                                        }
                                    }
                                }
                                cmdText = "";
                                return true;
                            //break;
                        }
                        break;

                    case '2':

                        /* NUR4002 신규에 대한 NUR4003건인 경우 */
                        if (Convert.ToInt32(item.BindVarList["f_fknur4002"].VarValue) == 0)
                        {
                            item.BindVarList.Remove("f_fknur4002");
                            item.BindVarList.Add("f_fknur4002", parent.t_pknur4002);
                        }

                        /* NUR4003 신규건 */
                        if (item.BindVarList["f_pknur4003"].VarValue != "" &&
                            Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) == 0) //&& parent.t_nur_plan == item.BindVarList["f_nur_plan"].VarValue)
                        {
                            cmdText = @"SELECT NUR4003_SEQ.NEXTVAL FROM DUAL";

                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                            cmdText = "";

                            if (!TypeCheck.IsNull(retVal))
                            {
                                parent.t_pknur4003 = retVal.ToString();
                                item.BindVarList.Add("f_pknur4003", parent.t_pknur4003);
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }

                            cmdText = @"INSERT INTO NUR4003
                                               ( SYS_DATE       , SYS_ID        , UPD_DATE          , UPD_ID        ,
                                                 HOSP_CODE      , PKNUR4003     ,
                                                 FKNUR4002      , NUR_PLAN      , NUR_PLAN_OTE      , NUR_PLAN_NAME,
                                                 SORT_KEY       , VALD          , INPUT_DATE        )
                                         VALUES
                                               ( SYSDATE        , :q_user_id     , SYSDATE          , :q_user_id    , 
                                                 :f_hosp_code   , :f_pknur4003    ,
                                                 :f_fknur4002   , :f_nur_plan    , :f_nur_plan_ote  , :f_nur_plan_name, 
                                                 :f_nur4003_sort, :f_nur4003_vald, TRUNC(SYSDATE))";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                            cmdText = "";
                        }
                        else if (item.BindVarList["f_pknur4003"].VarValue != "" &&
                                 Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) != 0) // && parent.t_nur_plan == item.BindVarList["f_nur_plan"].VarValue)
                        {
                            cmdText = @"UPDATE NUR4003
                                           SET UPD_ID        = :q_user_id      ,
                                               UPD_DATE      = SYSDATE         ,
                                               NUR_PLAN_NAME = :f_nur_plan_name, 
                                               VALD          = :f_nur4003_vald
                                         WHERE HOSP_CODE     = :f_hosp_code 
                                           AND PKNUR4003     = :f_pknur4003";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }
                            }
                            cmdText = "";
                        }

                        //parent.t_nur_plan = item.BindVarList["f_nur_plan"].VarValue;

                        /* NUR4003 신규건에 대한 NUR4004건인 경우*/
                        if (item.BindVarList["f_pknur4004"].VarValue != "")
                        {
                            if (Convert.ToInt32(item.BindVarList["f_pknur4004"].VarValue) == 0)//&& "X" == item.BindVarList["f_nur_plan_detail"].VarValue)
                            {
                                cmdText = @"SELECT NUR4004_SEQ.NEXTVAL FROM DUAL";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                cmdText = "";

                                if (item.BindVarList["f_pknur4003"].VarValue == "")
                                    item.BindVarList.Add("f_pknur4003", parent.t_pknur4003);

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    item.BindVarList.Remove("f_pknur4004");
                                    item.BindVarList.Add("f_pknur4004", retVal.ToString());
                                }
                                else
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR4004
                                           ( SYS_DATE       , SYS_ID         , UPD_DATE       , UPD_ID           ,
                                             HOSP_CODE      , PKNUR4004      ,
                                             FKNUR4003      , NUR_PLAN       , NUR_PLAN_DETAIL, NUR_PLAN_DENAME,
                                             SORT_KEY       , VALD           , INPUT_DATE     )
                                     VALUES
                                           ( SYSDATE        , :q_user_id     , SYSDATE          , :q_user_id     , 
                                             :f_hosp_code   , :f_pknur4004    ,
                                             :f_pknur4003   , :f_nur_plan    , :f_nur_plan_detail, :f_nur_plan_dename,
                                             :f_nur4004_sort, :f_nur4004_vald, TRUNC(SYSDATE))";
                            }
                            else //if ("X" != item.BindVarList["f_nur_plan_detail"].VarValue)
                            {
                                cmdText = @"UPDATE NUR4004
                                           SET UPD_ID          = :q_user_id        ,
                                               UPD_DATE        = SYSDATE           ,
                                               NUR_PLAN_DENAME = :f_nur_plan_dename,
                                               VALD            = :f_nur4004_vald
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND PKNUR4004       = :f_pknur4004";
                            }
                        }
                        else
                        {
                            return true;
                        }
                        break;


                    case '3':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                /*중복체크*/
                                cmdText = @"SELECT 'Y'
                                          FROM NUR4005 
                                         WHERE HOSP_CODE  = :f_hosp_code 
                                           AND FKNUR4002  = :f_fknur4002
                                           AND RESER_DATE = :f_reser_date
                                           AND ROWNUM = 1";

                                object t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk) && t_chk.ToString().Equals("Y"))
                                {
                                    XMessageBox.Show("[" + item.BindVarList["f_reser_date"].VarValue + "]日付のデータは既に存在します。ご確認ください。", "注意", MessageBoxIcon.Warning);
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR4005
                                           ( SYS_DATE       , SYS_ID        , UPD_DATE      , UPD_ID        ,
                                             HOSP_CODE      , FKNUR4002     ,
                                             RESER_DATE     , VALU_DATE     , VALUER        , VALU_CONTENTS )
                                     VALUES  
                                           ( SYSDATE        , :q_user_id    , SYSDATE       , :q_user_id    , 
                                             :f_hosp_code   , :f_fknur4002  ,
                                             :f_reser_date  , :f_value_date  , :f_valuer     , :f_value_contents )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR4005
                                           SET UPD_ID        = :q_user_id      ,
                                               UPD_DATE      = SYSDATE         ,
                                               VALU_DATE     = :f_value_date    ,
                                               VALUER        = :q_user_id      ,
                                               VALU_CONTENTS = :f_value_contents
                                         WHERE HOSP_CODE     = :f_hosp_code   
                                           AND FKNUR4002     = :f_fknur4002
                                           AND RESER_DATE    = :f_reser_date   ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE NUR4005
                                         WHERE HOSP_CODE  = :f_hosp_code   
                                           AND FKNUR4002  = :f_fknur4002
                                           AND RESER_DATE = :f_reser_date";

                                break;
                        }
                        break;

                }
                if (cmdText != "")
                    return Service.ExecuteNonQuery(cmdText, item.BindVarList);
                else
                    return true;
            }
        }
        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdInp1001.QueryLayout(false);

                    //Load 간호계획정보]
                    if (this.layNUR0402.QueryLayout(true)) { }
                    else
                    {
                        XMessageBox.Show(Service.ErrFullMsg);
                    }
                    ShowNur_plan_bunryu();
                    break;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SetAllPlan(true);

        }

        private void btnUnCheck_Click(object sender, EventArgs e)
        {
            SetAllPlan(false);

        }

        private void SetAllPlan(bool isAll)
        {
            this.tvwSelector.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);

            foreach (TreeNode tn in this.tvwSelector.Nodes)
			{
				if (isAll)
                {
                    tn.Checked = true;
					foreach(TreeNode node1 in tn.Nodes)
					{
                        node1.Checked = true;

						foreach(TreeNode node2 in node1.Nodes)
						{
                            node2.Checked = true;
						}
					}
				}
				else
                {
                    tn.Checked = false;
					foreach(TreeNode node1 in tn.Nodes)
					{
                        node1.Checked = false;

						foreach(TreeNode node2 in node1.Nodes)
						{
                            node2.Checked = false;
						}
					}
				}
            }
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
		}

        private void tvw_KeyDown(object sender, KeyEventArgs e)
        {
            TreeView treeview = sender as TreeView;

            if (treeview.SelectedNode != null)
            {
                if (e.Control && e.KeyCode == Keys.C)
                {
                    Clipboard.SetDataObject(treeview.SelectedNode.Text, true);
                }
            }
        }

        private void tvwNUR4003_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ExpandAll();
        }

    }
}

