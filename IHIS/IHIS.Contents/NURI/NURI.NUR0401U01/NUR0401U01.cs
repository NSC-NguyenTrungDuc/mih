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
	/// NUR0401U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR0401U01 : IHIS.Framework.XScreen
	{
        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdNUR0401;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel1;
        private MultiLayout layNur_plan_bunryu;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private XEditGrid grdNUR0102;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XPanel xPanel1;
        private XEditGridCell xEditGridCell8;
        private XPanel xPanel3;
        private XButton btnDown2;
        private XButton btnUp2;
        private XButton btnDown1;
        private XButton btnUp1;
        private XEditGrid grdNUR0404;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGrid grdNUR0403;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private Splitter splitter2;
        private XTabControl tabPlan_ote;
        private IHIS.X.Magic.Controls.TabPage pageO;
        private IHIS.X.Magic.Controls.TabPage pageT;
        private IHIS.X.Magic.Controls.TabPage pageE;
        private MultiLayout layTabColor;
        private MultiLayoutItem multiLayoutItem3;
        private IHIS.X.Magic.Controls.TabPage pageP;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR0401U01()
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

		#region 디자인 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0401U01));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR0401 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnDown2 = new IHIS.Framework.XButton();
            this.btnUp2 = new IHIS.Framework.XButton();
            this.btnDown1 = new IHIS.Framework.XButton();
            this.btnUp1 = new IHIS.Framework.XButton();
            this.grdNUR0404 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.grdNUR0403 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.tabPlan_ote = new IHIS.Framework.XTabControl();
            this.pageP = new IHIS.X.Magic.Controls.TabPage();
            this.pageO = new IHIS.X.Magic.Controls.TabPage();
            this.pageT = new IHIS.X.Magic.Controls.TabPage();
            this.pageE = new IHIS.X.Magic.Controls.TabPage();
            this.grdNUR0102 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.layNur_plan_bunryu = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.layTabColor = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0401)).BeginInit();
            this.panel1.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0404)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0403)).BeginInit();
            this.tabPlan_ote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0102)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur_plan_bunryu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTabColor)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(3, "YESUP1.ICO");
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnList);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 718);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(955, 32);
            this.xPanel2.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(547, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.Size = new System.Drawing.Size(406, 30);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR0401
            // 
            this.grdNUR0401.ApplyPaintEventToAllColumn = true;
            this.grdNUR0401.CallerID = '2';
            this.grdNUR0401.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdNUR0401.ColPerLine = 4;
            this.grdNUR0401.ColResizable = true;
            this.grdNUR0401.Cols = 5;
            this.grdNUR0401.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0401.FixedCols = 1;
            this.grdNUR0401.FixedRows = 1;
            this.grdNUR0401.FocusColumnName = "nur_plan_jin_name";
            this.grdNUR0401.HeaderHeights.Add(38);
            this.grdNUR0401.Location = new System.Drawing.Point(0, 0);
            this.grdNUR0401.Name = "grdNUR0401";
            this.grdNUR0401.QuerySQL = resources.GetString("grdNUR0401.QuerySQL");
            this.grdNUR0401.RowHeaderVisible = true;
            this.grdNUR0401.Rows = 2;
            this.grdNUR0401.Size = new System.Drawing.Size(456, 718);
            this.grdNUR0401.TabIndex = 0;
            this.grdNUR0401.UseDefaultTransaction = false;
            this.grdNUR0401.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdNUR0401.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdNUR0401.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdNUR0401.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            this.grdNUR0401.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR0401_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell1.CellLen = 5;
            this.xEditGridCell1.CellName = "nur_plan_jin";
            this.xEditGridCell1.CellWidth = 45;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "診断\r\nコード";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "nur_plan_jin_name";
            this.xEditGridCell2.CellWidth = 300;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "診断コード名";
            this.xEditGridCell2.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 2;
            this.xEditGridCell3.CellName = "nur_plan_bunryu";
            this.xEditGridCell3.CellWidth = 96;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "診断分類";
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell4.CellLen = 1;
            this.xEditGridCell4.CellName = "vald";
            this.xEditGridCell4.CellWidth = 30;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell4.HeaderText = "有\r\n効";
            this.xEditGridCell4.InitValue = "Y";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell5.CellLen = 2;
            this.xEditGridCell5.CellName = "sort_key";
            this.xEditGridCell5.CellWidth = 35;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderText = "順番";
            this.xEditGridCell5.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell5.InitValue = "99";
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 718);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grdNUR0401);
            this.panel1.Controls.Add(this.xPanel1);
            this.panel1.Controls.Add(this.grdNUR0102);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 718);
            this.panel1.TabIndex = 4;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xPanel1.Location = new System.Drawing.Point(456, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(496, 718);
            this.xPanel1.TabIndex = 2;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnDown2);
            this.xPanel3.Controls.Add(this.btnUp2);
            this.xPanel3.Controls.Add(this.btnDown1);
            this.xPanel3.Controls.Add(this.btnUp1);
            this.xPanel3.Controls.Add(this.grdNUR0404);
            this.xPanel3.Controls.Add(this.splitter2);
            this.xPanel3.Controls.Add(this.grdNUR0403);
            this.xPanel3.Controls.Add(this.tabPlan_ote);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(496, 718);
            this.xPanel3.TabIndex = 8;
            // 
            // btnDown2
            // 
            this.btnDown2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown2.Image = ((System.Drawing.Image)(resources.GetObject("btnDown2.Image")));
            this.btnDown2.Location = new System.Drawing.Point(-1, 454);
            this.btnDown2.Name = "btnDown2";
            this.btnDown2.Size = new System.Drawing.Size(27, 23);
            this.btnDown2.TabIndex = 33;
            this.btnDown2.Visible = false;
            this.btnDown2.Click += new System.EventHandler(this.btnDown2_Click);
            // 
            // btnUp2
            // 
            this.btnUp2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp2.Image = ((System.Drawing.Image)(resources.GetObject("btnUp2.Image")));
            this.btnUp2.Location = new System.Drawing.Point(-1, 433);
            this.btnUp2.Name = "btnUp2";
            this.btnUp2.Size = new System.Drawing.Size(27, 23);
            this.btnUp2.TabIndex = 32;
            this.btnUp2.Visible = false;
            this.btnUp2.Click += new System.EventHandler(this.btnUp2_Click);
            // 
            // btnDown1
            // 
            this.btnDown1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown1.Image = ((System.Drawing.Image)(resources.GetObject("btnDown1.Image")));
            this.btnDown1.Location = new System.Drawing.Point(-1, 45);
            this.btnDown1.Name = "btnDown1";
            this.btnDown1.Size = new System.Drawing.Size(27, 23);
            this.btnDown1.TabIndex = 31;
            this.btnDown1.Visible = false;
            this.btnDown1.Click += new System.EventHandler(this.btnDown1_Click);
            // 
            // btnUp1
            // 
            this.btnUp1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp1.Image = ((System.Drawing.Image)(resources.GetObject("btnUp1.Image")));
            this.btnUp1.Location = new System.Drawing.Point(-1, 24);
            this.btnUp1.Name = "btnUp1";
            this.btnUp1.Size = new System.Drawing.Size(27, 23);
            this.btnUp1.TabIndex = 30;
            this.btnUp1.Visible = false;
            this.btnUp1.Click += new System.EventHandler(this.btnUp1_Click);
            // 
            // grdNUR0404
            // 
            this.grdNUR0404.ApplyPaintEventToAllColumn = true;
            this.grdNUR0404.CallerID = '5';
            this.grdNUR0404.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22});
            this.grdNUR0404.ColPerLine = 4;
            this.grdNUR0404.Cols = 5;
            this.grdNUR0404.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0404.FixedCols = 1;
            this.grdNUR0404.FixedRows = 1;
            this.grdNUR0404.FocusColumnName = "nur_plan_dename";
            this.grdNUR0404.HeaderHeights.Add(35);
            this.grdNUR0404.Location = new System.Drawing.Point(0, 433);
            this.grdNUR0404.Name = "grdNUR0404";
            this.grdNUR0404.QuerySQL = resources.GetString("grdNUR0404.QuerySQL");
            this.grdNUR0404.RowHeaderVisible = true;
            this.grdNUR0404.Rows = 2;
            this.grdNUR0404.Size = new System.Drawing.Size(496, 285);
            this.grdNUR0404.TabIndex = 4;
            this.grdNUR0404.UseDefaultTransaction = false;
            this.grdNUR0404.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdNUR0404.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdNUR0404.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0404_QueryStarting);
            this.grdNUR0404.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdNUR0404.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellLen = 5;
            this.xEditGridCell14.CellName = "nur_plan_jin";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "nur_plan_jin";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 2;
            this.xEditGridCell15.CellName = "nur_plan_pro";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "nur_plan_pro";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellLen = 2;
            this.xEditGridCell16.CellName = "nur_plan";
            this.xEditGridCell16.Col = -1;
            this.xEditGridCell16.HeaderText = "nur_plan";
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell17.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell17.CellLen = 2;
            this.xEditGridCell17.CellName = "nur_plan_detail";
            this.xEditGridCell17.CellWidth = 60;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.HeaderText = "看護計画\r\n小コード";
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "from_date";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "from_date";
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "end_date";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "end_date";
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell20.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell20.CellLen = 200;
            this.xEditGridCell20.CellName = "nur_plan_dename";
            this.xEditGridCell20.CellWidth = 325;
            this.xEditGridCell20.Col = 2;
            this.xEditGridCell20.HeaderText = "看護計画小コード名";
            this.xEditGridCell20.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell21.CellName = "sort_key";
            this.xEditGridCell21.CellWidth = 35;
            this.xEditGridCell21.Col = 4;
            this.xEditGridCell21.HeaderText = "順番";
            this.xEditGridCell21.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell21.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell22.CellName = "vald";
            this.xEditGridCell22.CellWidth = 28;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell22.HeaderText = "有\r\n効";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 430);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(496, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // grdNUR0403
            // 
            this.grdNUR0403.ApplyPaintEventToAllColumn = true;
            this.grdNUR0403.CallerID = '4';
            this.grdNUR0403.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31});
            this.grdNUR0403.ColPerLine = 4;
            this.grdNUR0403.Cols = 5;
            this.grdNUR0403.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdNUR0403.FixedCols = 1;
            this.grdNUR0403.FixedRows = 1;
            this.grdNUR0403.FocusColumnName = "nur_plan_name";
            this.grdNUR0403.HeaderHeights.Add(33);
            this.grdNUR0403.Location = new System.Drawing.Point(0, 24);
            this.grdNUR0403.Name = "grdNUR0403";
            this.grdNUR0403.QuerySQL = resources.GetString("grdNUR0403.QuerySQL");
            this.grdNUR0403.RowHeaderVisible = true;
            this.grdNUR0403.Rows = 2;
            this.grdNUR0403.Size = new System.Drawing.Size(496, 406);
            this.grdNUR0403.TabIndex = 1;
            this.grdNUR0403.UseDefaultTransaction = false;
            this.grdNUR0403.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdNUR0403.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdNUR0403.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR0403_QueryStarting);
            this.grdNUR0403.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdNUR0403.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0403_SaveEnd);
            this.grdNUR0403.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grd_GridCellPainting);
            this.grdNUR0403.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR0403_RowFocusChanged);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellLen = 5;
            this.xEditGridCell23.CellName = "nur_plan_jin";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "nur_plan_jin";
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellLen = 2;
            this.xEditGridCell24.CellName = "nur_plan_pro";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "nur_plan_pro";
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell25.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell25.CellLen = 5;
            this.xEditGridCell25.CellName = "nur_plan";
            this.xEditGridCell25.CellWidth = 60;
            this.xEditGridCell25.Col = 1;
            this.xEditGridCell25.HeaderText = "看護計画\r\nコード";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "from_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "from_date";
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "end_date";
            this.xEditGridCell27.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "end_date";
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell28.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell28.CellLen = 100;
            this.xEditGridCell28.CellName = "nur_plan_name";
            this.xEditGridCell28.CellWidth = 325;
            this.xEditGridCell28.Col = 2;
            this.xEditGridCell28.HeaderText = "看護計画コード名";
            this.xEditGridCell28.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellLen = 1;
            this.xEditGridCell29.CellName = "nur_plan_ote";
            this.xEditGridCell29.Col = -1;
            this.xEditGridCell29.HeaderText = "nur_plan_ote";
            this.xEditGridCell29.IsUpdatable = false;
            this.xEditGridCell29.IsVisible = false;
            this.xEditGridCell29.Row = -1;
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell30.CellName = "sort_key";
            this.xEditGridCell30.CellWidth = 35;
            this.xEditGridCell30.Col = 4;
            this.xEditGridCell30.HeaderText = "順番";
            this.xEditGridCell30.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell31.CellName = "vald";
            this.xEditGridCell31.CellWidth = 26;
            this.xEditGridCell31.Col = 3;
            this.xEditGridCell31.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell31.HeaderText = "有\r\n効";
            // 
            // tabPlan_ote
            // 
            this.tabPlan_ote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabPlan_ote.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabPlan_ote.IDEPixelArea = true;
            this.tabPlan_ote.IDEPixelBorder = false;
            this.tabPlan_ote.ImageList = this.ImageList;
            this.tabPlan_ote.Location = new System.Drawing.Point(0, 0);
            this.tabPlan_ote.Name = "tabPlan_ote";
            this.tabPlan_ote.SelectedIndex = 0;
            this.tabPlan_ote.SelectedTab = this.pageP;
            this.tabPlan_ote.ShowClose = false;
            this.tabPlan_ote.Size = new System.Drawing.Size(496, 24);
            this.tabPlan_ote.TabIndex = 0;
            this.tabPlan_ote.TabPages.AddRange(new IHIS.X.Magic.Controls.TabPage[] {
            this.pageP,
            this.pageO,
            this.pageT,
            this.pageE});
            this.tabPlan_ote.SelectionChanged += new System.EventHandler(this.tabPlan_ote_SelectionChanged);
            // 
            // pageP
            // 
            this.pageP.ImageIndex = 3;
            this.pageP.ImageList = this.ImageList;
            this.pageP.Location = new System.Drawing.Point(0, 25);
            this.pageP.Name = "pageP";
            this.pageP.Size = new System.Drawing.Size(496, 0);
            this.pageP.TabIndex = 7;
            this.pageP.Tag = "P";
            this.pageP.Title = "関連因子";
            // 
            // pageO
            // 
            this.pageO.BackColor = System.Drawing.Color.Transparent;
            this.pageO.ImageIndex = 2;
            this.pageO.ImageList = this.ImageList;
            this.pageO.Location = new System.Drawing.Point(0, 25);
            this.pageO.Name = "pageO";
            this.pageO.Selected = false;
            this.pageO.Size = new System.Drawing.Size(496, -1);
            this.pageO.TabIndex = 4;
            this.pageO.Tag = "O";
            this.pageO.Title = " O P - 観察";
            // 
            // pageT
            // 
            this.pageT.BackColor = System.Drawing.Color.Transparent;
            this.pageT.ImageIndex = 2;
            this.pageT.ImageList = this.ImageList;
            this.pageT.Location = new System.Drawing.Point(0, 25);
            this.pageT.Name = "pageT";
            this.pageT.Selected = false;
            this.pageT.Size = new System.Drawing.Size(496, -1);
            this.pageT.TabIndex = 5;
            this.pageT.Tag = "T";
            this.pageT.Title = " T P - ケア";
            // 
            // pageE
            // 
            this.pageE.BackColor = System.Drawing.Color.Transparent;
            this.pageE.ImageIndex = 2;
            this.pageE.ImageList = this.ImageList;
            this.pageE.Location = new System.Drawing.Point(0, 25);
            this.pageE.Name = "pageE";
            this.pageE.Selected = false;
            this.pageE.Size = new System.Drawing.Size(496, -1);
            this.pageE.TabIndex = 6;
            this.pageE.Tag = "E";
            this.pageE.Title = " E P - 教育";
            // 
            // grdNUR0102
            // 
            this.grdNUR0102.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8});
            this.grdNUR0102.ColPerLine = 3;
            this.grdNUR0102.Cols = 3;
            this.grdNUR0102.Enabled = false;
            this.grdNUR0102.FixedRows = 1;
            this.grdNUR0102.FocusColumnName = "code";
            this.grdNUR0102.HeaderHeights.Add(36);
            this.grdNUR0102.Location = new System.Drawing.Point(23, 135);
            this.grdNUR0102.Name = "grdNUR0102";
            this.grdNUR0102.QuerySQL = resources.GetString("grdNUR0102.QuerySQL");
            this.grdNUR0102.Rows = 2;
            this.grdNUR0102.Size = new System.Drawing.Size(227, 102);
            this.grdNUR0102.TabIndex = 99;
            this.grdNUR0102.TabStop = false;
            this.grdNUR0102.UseDefaultTransaction = false;
            this.grdNUR0102.Visible = false;
            this.grdNUR0102.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grd_MouseDown);
            this.grdNUR0102.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grd_MouseMove);
            this.grdNUR0102.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grd_MouseUp);
            this.grdNUR0102.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0102_GridColumnChanged);
            this.grdNUR0102.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR0102_RowFocusChanged);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 2;
            this.xEditGridCell6.CellName = "code";
            this.xEditGridCell6.CellWidth = 50;
            this.xEditGridCell6.HeaderText = "コード";
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell6.IsNotNull = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.Mask = "##";
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 100;
            this.xEditGridCell7.CellName = "code_name";
            this.xEditGridCell7.CellWidth = 136;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderText = "コード名";
            this.xEditGridCell7.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "sort_key";
            this.xEditGridCell8.CellWidth = 35;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "順番";
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // layNur_plan_bunryu
            // 
            this.layNur_plan_bunryu.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layNur_plan_bunryu.QuerySQL = "SELECT CODE      NUR_PLAN_BUNRYU,\r\n       CODE_NAME NUR_PLAN_BUNRYU_NAME\r\n  FROM " +
                "NUR0102\r\n WHERE HOSP_CODE = :f_hosp_code \r\n   AND CODE_TYPE = \'NUR_PLAN_BUNRYU\'\r" +
                "\n ORDER BY NVL(SORT_KEY, 99), CODE\r\n";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "code";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "code_name";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "CODE";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "CODE_NAME";
            // 
            // layTabColor
            // 
            this.layTabColor.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3});
            this.layTabColor.QuerySQL = "SELECT DISTINCT\r\n       NUR_PLAN_OTE\r\n  FROM NUR0403\r\n WHERE HOSP_CODE      = :f_" +
                "hosp_code                 \r\n   AND NUR_PLAN_JIN   = :f_nur_plan_jin\r\n--   AND NU" +
                "R_PLAN_PRO   = :f_nur_plan_pro";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "plan_ote";
            // 
            // NUR0401U01
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.xPanel2);
            this.Name = "NUR0401U01";
            this.Size = new System.Drawing.Size(955, 750);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR0401U01_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR0401U01_ScreenOpen);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0401)).EndInit();
            this.panel1.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0404)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0403)).EndInit();
            this.tabPlan_ote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0102)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNur_plan_bunryu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTabColor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion 


        #region [초기설정 관련 코드]

        #region OnLoad 이벤트
        private string mHospCode = "";
        private string appDate = "";
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            this.mHospCode = EnvironInfo.HospCode;
            // 그리드 SavePerformer 설정
            grdNUR0102.SavePerformer = new XSavePerformer(this);
            grdNUR0401.SavePerformer = grdNUR0102.SavePerformer;
            //grdNUR0402.SavePerformer = grdNUR0102.SavePerformer;
            grdNUR0403.SavePerformer = grdNUR0102.SavePerformer;
            grdNUR0404.SavePerformer = grdNUR0102.SavePerformer;
            //this.CurrMSLayout = this.grdNUR0102;
            this.CurrMSLayout = this.grdNUR0401;


            // 기준일자 현재일 //적용일불용일은 결국 사용도 안되고, 날짜의 의미가 없음
            appDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");
            
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad 이벤트
        private void PostLoad()
        {
            this.grdNUR0102.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR0102.QueryLayout(false);
        }
        #endregion

        #endregion

        #region [코드명 취득 코드]

        /// <summary>
        /// 해당 코드에 대한 코드명을 취득한다.
        /// </summary>
        /// <param name="codeMode">코드구분</param>
        /// <param name="code">코드Value</param>
        /// <returns>
        /// 코드명 : 해당데이타 코드명
        /// 공백   : 해당데이타 없음
        /// </returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = string.Empty;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            if (code.Trim() == "")
            {
                return codeName;
            }

            switch (codeMode)
            {
                case "nur_plan_jin":
                    cmdText = @"SELECT A.NUR_PLAN_JIN_NAME 
                                  FROM NUR0401 A 
                                 WHERE A.HOSP_CODE    = :f_hosp_code 
                                   AND A.NUR_PLAN_JIN = :f_code ";

                    bindVars.Add("f_hosp_code", this.mHospCode);
                    bindVars.Add("f_code", code);
                    
                    retVal = Service.ExecuteScalar(cmdText, bindVars);

                    if (Service.ErrCode == 0)
                    {
                        if (retVal == null || retVal.ToString().Equals(""))
                            codeName = "";
                        else
                            codeName = retVal.ToString();
                    }
                    else
                    {
                        codeName = "";
                    }
                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [데이타 체크 코드]

        #region Grid_Validating
        /// <summary>
        /// 저장 전 그리드 데이타의 유효성 검사를 실행한다.
        /// </summary>
        private ReturnClass Grid_Validating()
        {
            AcceptData();

            // null체크해서 해당컬럼넘겨줌. 아오귀찮아

            //grdNUR0102
            for (int rowIndex = 0; rowIndex < grdNUR0102.RowCount; rowIndex++)
            {
                if (grdNUR0102.GetItemString(rowIndex, "code").Trim() == "")
                {
                    XMessageBox.Show("コードを入力してください。", "コード入力", MessageBoxIcon.Information);
                    //grdNUR0102.SetFocusToItem(rowIndex, "code", true);
                    return new ReturnClass(grdNUR0102, rowIndex, "code");
                }
                if (grdNUR0102.GetItemString(rowIndex, "code_name").Trim() == "")
                {
                    XMessageBox.Show("コード名を入力してください。", "コード名入力", MessageBoxIcon.Information);
                    //grdNUR0102.SetFocusToItem(rowIndex, "code_name", true);
                    return new ReturnClass(grdNUR0102, rowIndex, "code");
                }
            }

            //grdNUR0401
            for (int rowIndex = 0; rowIndex < grdNUR0401.RowCount; rowIndex++)
            {
                if (grdNUR0401.GetItemString(rowIndex, "nur_plan_jin_name").Trim() == "")
                {
                    XMessageBox.Show("診断コード名を入力してください。", "診断コード名入力", MessageBoxIcon.Information);
                    //grdNUR0401.SetFocusToItem(rowIndex, "nur_plan_jinname", true);
                    return new ReturnClass(grdNUR0401, rowIndex, "nur_plan_jin_name");
                }
            }

            //grdNUR0402
            //for (int rowIndex = 0; rowIndex < grdNUR0402.RowCount; rowIndex++)
            //{
            //    if (grdNUR0402.GetItemString(rowIndex, "nur_plan_proname").Trim() == "")
            //    {
            //        XMessageBox.Show("問題リスト名を入力してください。", "問題リスト名入力", MessageBoxIcon.Information);
            //        //grdNUR0402.SetFocusToItem(rowIndex, "nur_plan_proname", true);
            //        return new ReturnClass(grdNUR0402, rowIndex, "nur_plan_proname");
            //    }
            //}

            //grdNUR0403
            for (int rowIndex = 0; rowIndex < grdNUR0403.RowCount; rowIndex++)
            {
                if (grdNUR0403.GetItemString(rowIndex, "nur_plan_name").Trim() == "")
                {
                    XMessageBox.Show("看護計画コード名を入力してください。", "看護計画コード名入力", MessageBoxIcon.Information);
                    //grdNUR0403.SetFocusToItem(rowIndex, "nur_plan_name", true);
                    return new ReturnClass(grdNUR0403, rowIndex, "nur_plan_name");
                }
            }

            //grdNUR0404
            for (int rowIndex = 0; rowIndex < grdNUR0404.RowCount; rowIndex++)
            {
                if (grdNUR0404.GetItemString(rowIndex, "nur_plan_dename").Trim() == "")
                {
                    XMessageBox.Show("看護計画小コード名を入力してください。", "看護計画小コード名入力", MessageBoxIcon.Information);
                    //grdNUR0401.SetFocusToItem(rowIndex, "nur_plan_dename", true);
                    return new ReturnClass(grdNUR0404, rowIndex, "nur_plan_dename");
                }
            }

            return null;
        }
        #endregion

        #region 디테일 데이타 체크
        /// <summary>
        /// 진단 데이타에 대한 디테일 데이타 여부를 체크한다.
        /// </summary>
        /// <param name="aNur_plan_jin">체크코드</param>
        /// <returns>
        /// True :디테일 데이타 유
        /// False:디테일 데이타 무
        /// </returns>
        private bool IsExistDetail(XEditGrid grd)
        {
            bool check = false;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            switch(grd.Name)
            {
                case "grdNUR0102":

                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(SELECT 'X'
                                                FROM NUR0401 A 
                                               WHERE A.HOSP_CODE       = :f_hosp_code 
                                                 AND A.NUR_PLAN_BUNRYU = :f_nur_plan_bunryu)";

                    bindVars.Add("f_nur_plan_bunryu", grd.GetItemString(grd.CurrentRowNumber, "code"));

                    break;
                case "grdNUR0401":

                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(SELECT 'X'
                                                FROM NUR0403 A 
                                               WHERE A.HOSP_CODE    = :f_hosp_code 
                                                 AND A.NUR_PLAN_JIN = :f_nur_plan_jin )";

                    bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));

                    break;

//                case "grdNUR0402":
//                    cmdText = @"SELECT 'Y' 
//                                  FROM DUAL
//                                 WHERE EXISTS(SELECT 'X'
//                                                FROM NUR0403 A 
//                                               WHERE A.HOSP_CODE    = :f_hosp_code 
//                                                 AND A.NUR_PLAN_JIN = :f_nur_plan_jin 
//                                                 AND A.NUR_PLAN_PRO = :f_nur_plan_pro )";

//                    bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));
//                    bindVars.Add("f_nur_plan_pro", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_pro"));

//                    break;
                case "grdNUR0403":
                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(SELECT 'X'
                                                FROM NUR0404 A 
                                               WHERE A.HOSP_CODE    = :f_hosp_code 
                                                 AND A.NUR_PLAN_JIN = :f_nur_plan_jin
                                                 AND A.NUR_PLAN     = :f_nur_plan    )";

                    bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));
                    bindVars.Add("f_nur_plan", grd.GetItemString(grd.CurrentRowNumber, "nur_plan"));

                    break;

                case "grdNUR0404":
                    check = false;
                    break;
            }

            if (grd.Name != "grdNUR0404")
            {
                bindVars.Add("f_hosp_code", this.mHospCode);
                retVal = Service.ExecuteScalar(cmdText, bindVars);

                if (Service.ErrCode == 0)
                {
                    if (retVal != null && retVal.ToString().Equals("Y"))
                    {
                        check = true;
                    }
                }
            }

            return check;
        }
        #endregion

        #region 그리드 필수입력필드 체크
        /// <summary>
        /// 그리드에 입력한 로우 중, 필수입력(Not Null)필드를 입력하지 않은 컬럼를 검색한다.
        /// </summary>
        /// <remarks>
        /// Grid 컬럼 속성이 Not Null과 Visible, Not ReadOnly 항목으로 체크한다.
        /// </remarks>
        /// <param name="aGrd">XEditGrid</param>
        /// <returns>
        /// 검색결과 유:해당 컬럼
        /// 검색결과 무:해당 컬럼의 RowNumber가 [0]이하로 설정 후 리턴
        /// </returns>
        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
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
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            // cell.Col은 컬럼의 위치이기 때문에 인덱스 접근을 위해 -1을 연산함.
                            celReturn.ColumnNumber = cell.Col - 1;
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

        #region 사용유무 체크
 
        private bool IsUsed(XEditGrid grd)
        {
            bool IsUsed = false;
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVars = new BindVarCollection();

            switch(grd.Name)
            {
                case "grdNUR0102":

                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(  SELECT B.NUR_PLAN_JIN
                                                  FROM NUR0401 A
                                                 WHERE A.HOSP_CODE       = :f_hosp_code
                                                   AND B.HOSP_CODE       = A.HOSP_CODE 
                                                   AND A.NUR_PLAN_BUNRYU = :f_nur_plan_bunryu
                                                   AND A.NUR_PLAN_JIN    = B.NUR_PLAN_JIN )";

                    bindVars.Add("f_nur_plan_bunryu", grd.GetItemString(grd.CurrentRowNumber, "code"));

                    break;
                case "grdNUR0401":

                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(  SELECT A.NUR_PLAN_JIN
                                                  FROM NUR4001 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND A.NUR_PLAN_JIN = :f_nur_plan_jin )";

                    bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));

                    break;

//                case "grdNUR0402":
//                    cmdText = @"SELECT 'Y' 
//                                  FROM DUAL
//                                 WHERE EXISTS(  SELECT A.NUR_PLAN_JIN
//                                                  FROM NUR4002 A
//                                                 WHERE A.HOSP_CODE    = :f_hosp_code
//                                                   AND A.NUR_PLAN_JIN = :f_nur_plan_jin 
//                                                   AND A.NUR_PLAN_PRO = :f_nur_plan_pro )";

//                    bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));
//                    bindVars.Add("f_nur_plan_pro", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_pro"));

//                    break;

                case "grdNUR0403":
                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(  SELECT A.NUR_PLAN
                                                  FROM NUR4003 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND A.NUR_PLAN     = :f_nur_plan)";

                    //bindVars.Add("f_nur_plan_jin", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_jin"));
                    //bindVars.Add("f_nur_plan_pro", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_pro"));
                    bindVars.Add("f_nur_plan", grd.GetItemString(grd.CurrentRowNumber, "nur_plan"));

                    break;

                case "grdNUR0404":

                    cmdText = @"SELECT 'Y' 
                                  FROM DUAL
                                 WHERE EXISTS(SELECT NULL
                                                FROM NUR4004 A
                                               WHERE A.HOSP_CODE = :f_hosp_code
                                                 AND A.NUR_PLAN = :f_fknur0403
                                                 AND A.NUR_PLAN_DETAIL = :f_nur_plan     )";

                    bindVars.Add("f_fknur0403", grd.GetItemString(grd.CurrentRowNumber, "nur_plan"));
                    bindVars.Add("f_nur_plan", grd.GetItemString(grd.CurrentRowNumber, "nur_plan_detail"));
                    
                    break;
            }

            bindVars.Add("f_hosp_code", this.mHospCode);
            retVal = Service.ExecuteScalar(cmdText, bindVars);

            if (Service.ErrCode == 0)
            {
                if (retVal != null && retVal.ToString().Equals("Y"))
                {
                    IsUsed = true;
                }
            }

            return IsUsed;
        
        }


        #endregion 

        #endregion

        #region [입력/삭제/저장 처리 관련 코드]

        string mbxMsg = "";
        string mbxCap = "";
        private bool mIsUpdateSuccess = true;
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            string cmdText = @"";
            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", this.mHospCode);
            ReturnClass rc = null;

            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    DataGridCell chkCell = GetEmptyNewRow(this.CurrMSLayout);

                    string temp_code = "";
                    object new_code = null;


                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = -1;

                        if (!grdFlag)
                            return;

                        if (!this.CheckUpdatedGrd((XEditGrid)this.CurrMSLayout))
                        {
                            DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            grdFlag = false;

                            if (dr == DialogResult.Yes)
                            {
                                rc = Grid_Validating();

                                if (rc != null)
                                {
                                    XEditGrid retGrd = rc.ReturnGrd;
                                    grdFlag = false;
                                    retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
                                    grdFlag = true;
                                    return;
                                }

                                if (!this.UpdateGrd())
                                {
                                    return;
                                }
                            }
                        }

                        grdFlag = true;
                        if (this.CurrMSLayout == this.grdNUR0102)
                        {
                            this.grdNUR0401.Reset();
                            //this.grdNUR0402.Reset();
                            this.grdNUR0403.Reset();
                            this.grdNUR0404.Reset();
                            currentRow = grdNUR0102.InsertRow(this.grdNUR0102.RowCount -1);                        
                        }
                        else if (this.CurrMSLayout == this.grdNUR0401)
                        {
                            if (this.grdNUR0102.CurrentRowNumber < 0)
                            {
                                return;
                            }
                            if (this.grdNUR0102.GetItemString(this.grdNUR0102.CurrentRowNumber, "code").Trim() == "")
                            {
                                XMessageBox.Show("コードを入力してください。", "コード入力", MessageBoxIcon.Information);
                                this.grdNUR0102.SetFocusToItem(this.grdNUR0102.CurrentRowNumber,"code",true);
                                return;                            
                            }

                            //그리드에서 최대값 가져온다
                            int maxVal = 0;
                            for (int i = 0; i < this.grdNUR0401.RowCount; i++)
                            { 
                                int tempVal = Convert.ToInt32(this.grdNUR0401.GetItemString(i, "nur_plan_jin").Substring(2));
                                
                                if (tempVal > maxVal)
                                    maxVal = tempVal;                                
                            }

                            temp_code = this.grdNUR0102.GetItemString(this.grdNUR0102.CurrentRowNumber, "code");
                            
                            //그리드 최대값과 DB최대값 비교하여 큰 값 가져온다.
                            cmdText = @"SELECT :f_nur_plan_bunryu || 
                                               TRIM(TO_CHAR(GREATEST(NVL(MAX(SUBSTR(NUR_PLAN_JIN,3)), 0), :f_max_val ) + 1 , '000')) NEW_CODE
                                          FROM NUR0401
                                         WHERE HOSP_CODE       = :f_hosp_code
                                           AND NUR_PLAN_BUNRYU = :f_nur_plan_bunryu";
                            bc.Add("f_nur_plan_bunryu", temp_code);
                            bc.Add("f_max_val", maxVal.ToString());


                            //this.grdNUR0401.Reset();
                            //this.grdNUR0402.Reset();
                            this.grdNUR0403.Reset();
                            this.grdNUR0404.Reset();

                            new_code = Service.ExecuteScalar(cmdText, bc);
                            currentRow = grdNUR0401.InsertRow(this.grdNUR0401.RowCount - 1);
                            grdNUR0401.SetItemValue(currentRow, "nur_plan_bunryu", temp_code);
                            grdNUR0401.SetItemValue(currentRow, "vald", "Y");
                            grdNUR0401.SetItemValue(currentRow, "nur_plan_jin", new_code.ToString());


                        }
//                        else if (this.CurrMSLayout == this.grdNUR0402)
//                        {
//                            if (this.grdNUR0401.CurrentRowNumber < 0)
//                            {
//                                return;
//                            }

//                            //그리드에서 최대값 가져온다
//                            int maxVal = 0;
//                            for (int i = 0; i < this.grdNUR0402.RowCount; i++)
//                            {
//                                int tempVal = Convert.ToInt32(this.grdNUR0402.GetItemString(i, "nur_plan_pro"));

//                                if (tempVal > maxVal)
//                                    maxVal = tempVal;
//                            }

//                            temp_code = this.grdNUR0401.GetItemString(this.grdNUR0401.CurrentRowNumber, "nur_plan_jin");

//                            //코드자동생성하기
//                            cmdText = @"SELECT TRIM(TO_CHAR(GREATEST(NVL(MAX(NUR_PLAN_PRO), 0), :f_max_val) + 1, '00')) NEW_CODE
//                                          FROM NUR0402
//                                         WHERE HOSP_CODE    = :f_hosp_code
//                                           AND NUR_PLAN_JIN = :f_nur_plan_jin";

//                            bc.Add("f_nur_plan_jin", temp_code);
//                            bc.Add("f_max_val", maxVal.ToString());

//                            new_code = Service.ExecuteScalar(cmdText, bc);


//                            //this.grdNUR0401.Reset();
//                            //this.grdNUR0402.Reset();
//                            //this.grdNUR0403.Reset();
//                            //this.grdNUR0404.Reset();
//                            currentRow = grdNUR0402.InsertRow(this.grdNUR0402.RowCount - 1);
//                            grdNUR0402.SetItemValue(currentRow, "nur_plan_jin", temp_code);
//                            grdNUR0402.SetItemValue(currentRow, "vald", "Y");
//                            grdNUR0402.SetItemValue(currentRow, "nur_plan_pro", new_code.ToString());
//                        }
                        else if (this.CurrMSLayout == this.grdNUR0403)
                        {
                            //if (this.grdNUR0402.CurrentRowNumber < 0)
                            //{
                            //    return;
                            //}                            
                                
                            //코드자동생성하기
                            cmdText = @"SELECT NUR0403_SEQ.NEXTVAL NEW_CODE FROM DUAL";

                            new_code = Service.ExecuteScalar(cmdText);

                            currentRow = grdNUR0403.InsertRow(this.grdNUR0403.RowCount - 1);
                            grdNUR0403.SetItemValue(currentRow, "nur_plan_jin", this.grdNUR0401.GetItemString(this.grdNUR0401.CurrentRowNumber, "nur_plan_jin"));
                            //grdNUR0403.SetItemValue(currentRow, "nur_plan_pro", this.grdNUR0402.GetItemString(this.grdNUR0402.CurrentRowNumber, "nur_plan_pro"));
                            grdNUR0403.SetItemValue(currentRow, "nur_plan_ote", tabPlan_ote.SelectedTab.Tag.ToString().Trim());
                            grdNUR0403.SetItemValue(currentRow, "from_date", appDate);
                            grdNUR0403.SetItemValue(currentRow, "vald", "Y");
                            grdNUR0403.SetItemValue(currentRow, "nur_plan", new_code.ToString());
                        }
                        else if (this.CurrMSLayout == this.grdNUR0404)
                        {
                            if (this.grdNUR0403.CurrentRowNumber < 0)
                            {
                                return;
                            }

                            //그리드에서 최대값 가져온다
                            int maxVal = 0;
                            for (int i = 0; i < this.grdNUR0404.RowCount; i++)
                            {
                                int tempVal = Convert.ToInt32(this.grdNUR0404.GetItemString(i, "nur_plan_detail"));

                                if (tempVal > maxVal)
                                    maxVal = tempVal;
                            }

                            //코드자동생성하기
                            cmdText = @"SELECT TRIM(TO_CHAR(GREATEST(NVL(MAX(NUR_PLAN_DETAIL), 0), :f_max_val) + 1, '00')) NEW_CODE
                                          FROM NUR0404
                                         WHERE HOSP_CODE    = :f_hosp_code
                                           AND NUR_PLAN_JIN = :f_nur_plan_jin
                                           AND NUR_PLAN     = :f_nur_plan  ";

                            bc.Add("f_nur_plan_jin", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_jin").Trim());
                            //bc.Add("f_nur_plan_pro", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_pro").Trim());
                            bc.Add("f_nur_plan", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan").Trim());
                            bc.Add("f_max_val", maxVal.ToString());

                            //this.grdNUR0401.Reset();
                            //this.grdNUR0402.Reset();
                            //this.grdNUR0403.Reset();
                            //this.grdNUR0404.Reset();
                            new_code = Service.ExecuteScalar(cmdText, bc);
                            currentRow = grdNUR0404.InsertRow(this.grdNUR0404.RowCount - 1);
                            grdNUR0404.SetItemValue(currentRow, "nur_plan_jin", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_jin").Trim());
                            //grdNUR0404.SetItemValue(currentRow, "nur_plan_pro", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_pro").Trim());
                            grdNUR0404.SetItemValue(currentRow, "nur_plan", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan").Trim());
                            grdNUR0404.SetItemValue(currentRow, "from_date", appDate);
                            grdNUR0404.SetItemValue(currentRow, "vald", "Y");
                            grdNUR0404.SetItemValue(currentRow, "nur_plan_detail", new_code.ToString());
                        }
                        SetSequence((XEditGrid)this.CurrMSLayout);
                    }
                    else
                        ((XEditGrid)this.CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);

                    break;

                case FunctionType.Delete:

                    e.IsBaseCall = false;
                    
                    if (this.CurrMSLayout.CurrentRowNumber < 0) return;
                    
                    XEditGrid grd = (XEditGrid)this.CurrMSLayout;

                    if (grd.GetRowState(grd.CurrentRowNumber) != DataRowState.Added)
                    {
                        string nur_plan_jin = grdNUR0401.GetItemString(grdNUR0401.CurrentRowNumber, "nur_plan_jin");

                        //간호계획에 등록됐는지 확인
                        if (IsUsed(grd))
                        {
                            if (this.CurrMSLayout == this.grdNUR0102)
                            {
                                DialogResult dr = XMessageBox.Show("既に看護計画で使われているので削除できません。\r\n" + 
                                                                   "詳細コードを全て無効にしますか？", "確認"
                                                      , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dr == DialogResult.Yes)
                                {
                                    // 진단코드 무효처리

                                    cmdText = @"UPDATE NUR0401
                                                   SET UPD_ID           = :f_upd_id 
                                                       UPD_DATE         = SYSDATE,
                                                       VALD             = 'N'     
                                                 WHERE HOSP_CODE        = :f_hosp_code
                                                   AND NUR_PLAN_BUNRYU  = :f_nur_plan_bunryu";
                                    bc.Add("f_upd_id", UserInfo.UserID);
                                    //bc.Add("f_hosp_code", this.mHospCode);
                                    bc.Add("f_nur_plan_bunryu", this.grdNUR0102.GetItemString(this.grdNUR0102.CurrentRowNumber, "code"));
                                    Service.ExecuteNonQuery(cmdText);
                                }

                                return;
                            }
                            else
                            {
                                string strMsg = "既に看護計画で使われているので削除できません。";

                                if (grd.GetItemString(grd.CurrentRowNumber, "vald") == "Y")
                                {
                                    strMsg += "\r\n無効にしますか？";
                                    DialogResult dr = XMessageBox.Show(strMsg, "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dr == DialogResult.Yes)
                                        grd.SetItemValue(grd.CurrentRowNumber, "vald", "N");
                                }
                                else
                                {
                                    DialogResult dr = XMessageBox.Show(strMsg, "確認", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                }
                                return;
                            }                        
                        }

                        // 마스터에 디테일 등록됐는지 확인
                        // 하위데이터도 같이 지울수 있는지 
                        if (IsExistDetail(grd))
                        {
                            if (this.CurrMSLayout == this.grdNUR0102)
                            {
                                DialogResult dr = XMessageBox.Show("既に診断コードが登録されています。\r\n" +
                                                                   "診断コードを含む詳細コードも全て削除しますか。", "確認"
                                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                               if(dr == DialogResult.No)
                                return;                                
                            }
                            else
                            {
                                DialogResult dr = XMessageBox.Show("既に詳細コードが登録されています。\r\n" + 
                                                                   "詳細コードも全て削除しますか。\r\n" + 
                                                                   " 「Yes」:全て削除　「No」:現在項目無効　「Cancel」:取消", "確認"
                                                   , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                if (dr == DialogResult.Yes)
                                {
                                }
                                else if (dr == DialogResult.No)
                                {
                                    grd.SetItemValue(grd.CurrentRowNumber, "vald", "N");
                                    return;
                                }
                                else
                                    return;
                            }
                        }
                    }

                    grd.DeleteRow(grd.CurrentRowNumber);
                    SetSequence(grd);
                    this.AcceptData();

                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;
                    mIsUpdateSuccess = true;
                    rc = Grid_Validating();

                    if (rc != null)
                    {
                        (rc.ReturnGrd).SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName);
                        return;
                    }

                    if (!UpdateGrd())
                        mIsUpdateSuccess = false;
                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdNUR0401.Reset();
                    //this.grdNUR0402.Reset();
                    this.grdNUR0403.Reset();
                    this.grdNUR0404.Reset();

                    this.grdNUR0102.QueryLayout(false);

                    break;

                default:
                    break;
            }
        }

        private bool UpdateGrd()
        {
            try
            {
                mbxMsg = "";
                mbxCap = "";

                Service.BeginTransaction();

                if (!this.grdNUR0102.SaveLayout())
                    throw new Exception();

                if (!this.grdNUR0401.SaveLayout())
                    throw new Exception();

                //if (!this.grdNUR0402.SaveLayout())
                //    throw new Exception();

                if (!this.grdNUR0403.SaveLayout())
                    throw new Exception();

                if (!this.grdNUR0404.SaveLayout())
                    throw new Exception();

                Service.CommitTransaction();
            }
            catch
            {
                Service.RollbackTransaction();
                if (this.mbxMsg != "")
                    XMessageBox.Show(this.mbxMsg, this.mbxCap, MessageBoxIcon.Warning);
                else
                    XMessageBox.Show("保存に失敗しました。\r\n" + Service.ErrFullMsg, this.mbxCap, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion


        #region [RowFocusChanged]

        private void grdNUR0102_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (!grdFlag)
                return;

            if (!this.CheckUpdatedGrd(grdNUR0102))
            {
                DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                grdFlag = false;

                if (dr == DialogResult.Yes)
                {
                    ReturnClass rc = Grid_Validating();

                    if (rc != null)
                    {
                        grdFlag = false;
                        grdNUR0102.SetFocusToItem(e.PreviousRow, "code");
                        //retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
                        grdFlag = true;
                        PostCallHelper.PostCall(FocusToCell, rc);
                        return;
                    }

                    if (!this.UpdateGrd())
                    {
                        grdFlag = false;
                        grdNUR0102.SetFocusToItem(e.PreviousRow, "code");
                        grdFlag = true;
                        return;
                    }
                }
            }
            this.grdNUR0401.Reset();
            //this.grdNUR0402.Reset();
            this.grdNUR0403.Reset();

            this.SetTabColor(true);
            
            this.grdNUR0404.Reset();

            grdNUR0401.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0401.SetBindVarValue("f_nur_plan_bunryu", this.grdNUR0102.GetItemString(e.CurrentRow, "code"));
            grdNUR0401.QueryLayout(false);
            grdFlag = true;
        }

        private void FocusToCell(object aRc)
        {
            grdFlag = false;

            ReturnClass rc = aRc as ReturnClass;
            XEditGrid retGrd = rc.ReturnGrd;

            retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
            grdFlag = true;
        
        }
        
        private void grdNUR0401_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (!grdFlag)
                return;

            if (!this.CheckUpdatedGrd(grdNUR0401))
            {
                DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                grdFlag = false;

                if (dr == DialogResult.Yes)
                {
                    ReturnClass rc = Grid_Validating();

                    if (rc != null)
                    {
                        grdFlag = false;
                        grdNUR0401.SetFocusToItem(e.PreviousRow, "nur_plan_jin_name");
                        //retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
                        grdFlag = true;
                        PostCallHelper.PostCall(FocusToCell, rc);
                        return;
                    }

                    if (!this.UpdateGrd())
                    {
                        grdFlag = false;
                        grdNUR0401.SetFocusToItem(e.PreviousRow, "nur_plan_jin_name");
                        grdFlag = true;
                        return;
                    }
                }
            }
            //grdNUR0402.Reset();
            grdNUR0403.Reset();
            grdNUR0404.Reset();

            //grdNUR0402.QueryLayout(false);
            grdNUR0403.QueryLayout(false);

            grdFlag = true;
        }

        /*
        private void grdNUR0402_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (!grdFlag)
                return;

            if (!this.CheckUpdatedGrd(grdNUR0402))
            {
                DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                grdFlag = false;

                if (dr == DialogResult.Yes)
                {
                    ReturnClass rc = Grid_Validating();

                    if (rc != null)
                    {
                        grdFlag = false;
                        grdNUR0402.SetFocusToItem(e.PreviousRow, "nur_plan_proname");
                        //retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
                        grdFlag = true;
                        PostCallHelper.PostCall(FocusToCell, rc);
                        return;
                    }

                    if (!this.UpdateGrd())
                    {
                        grdFlag = false;
                        grdNUR0402.SetFocusToItem(e.PreviousRow, "nur_plan_proname");
                        grdFlag = true;
                        return;
                    }
                }
            }

            this.grdNUR0404.Reset();
            GetNUR0403();
            grdFlag = true;
        }
        */


        private void grdNUR0403_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (!grdFlag)
                return;

            if (!this.CheckUpdatedGrd(grdNUR0403))
            {
                DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                grdFlag = false;

                if (dr == DialogResult.Yes)
                {
                    ReturnClass rc = Grid_Validating();

                    if (rc != null)
                    {
                        grdFlag = false;
                        grdNUR0403.SetFocusToItem(e.PreviousRow, "nur_plan_name");
                        //retGrd.SetFocusToItem(rc.ReturnRowNum, rc.ReturnColName, true);
                        grdFlag = true;
                        PostCallHelper.PostCall(FocusToCell, rc);
                        return;
                    }

                    if (!this.UpdateGrd())
                    {
                        grdFlag = false;
                        grdNUR0403.SetFocusToItem(e.PreviousRow, "nur_plan_name");
                        grdFlag = true;
                        return;
                    }
                }
            }

            grdNUR0404.QueryLayout(false);
            grdFlag = true;
        }

        //SetFocus시에 또 CheckUpdatedGrd타지 않도록하는 플레그
        private bool grdFlag = true;
        private bool CheckUpdatedGrd(XEditGrid grd)
        {
            //if (!grdFlag) return false;
            int callerID = Convert.ToInt32(grd.CallerID.ToString());            
            
                if (callerID < 1)
                {
                    if (this.grdNUR0102.DeletedRowCount > 0)
                        return false;

                    foreach (DataRow row in grdNUR0102.LayoutTable.Rows)
                    {
                        if (row.RowState != DataRowState.Unchanged)
                            return false;
                    }
                }

                if (callerID < 2)
                {
                    if (this.grdNUR0401.DeletedRowCount > 0)
                        return false;

                    foreach (DataRow row in grdNUR0401.LayoutTable.Rows)
                    {
                        if (row.RowState != DataRowState.Unchanged)
                            return false;
                    }
                }

                //if (callerID < 3)
                //{
                //    if (grdNUR0402.DeletedRowCount > 0)
                //        return false;

                //    foreach (DataRow row in grdNUR0402.LayoutTable.Rows)
                //    {
                //        if (row.RowState != DataRowState.Unchanged)
                //            return false;
                //    }
                //}

                if (callerID < 4)
                {
                    if (grdNUR0403.DeletedRowCount > 0)
                        return false;

                    foreach (DataRow row in grdNUR0403.LayoutTable.Rows)
                    {
                        if (row.RowState != DataRowState.Unchanged)
                            return false;
                    }
                }

                if (callerID < 5)
                {
                    if (grdNUR0404.DeletedRowCount > 0)
                        return false;

                    foreach (DataRow row in grdNUR0404.LayoutTable.Rows)
                    {
                        if (row.RowState != DataRowState.Unchanged)
                            return false;
                    }
                }
          
            return true;
        }
		#endregion        

        #region tabPlan_ote_SelectionChanged
        private void tabPlan_ote_SelectionChanged(object sender, EventArgs e)
        {
            if (!grdFlag)
                return;

            grdNUR0404.Reset();

            if (!this.CheckUpdatedGrd(grdNUR0401))
            {
                DialogResult dr = XMessageBox.Show("まだ保存していないデータがあります。保存しますか。", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                grdFlag = false;

                if (dr == DialogResult.Yes)
                {
                    ReturnClass rc = Grid_Validating();

                    if (rc != null)
                    {
                        grdFlag = false;
                        FucusToTab();                        
                        grdFlag = true;
                        PostCallHelper.PostCall(FocusToCell, rc);
                        return;
                    }

                    if (!this.UpdateGrd())
                    {
                        grdFlag = false;
                        FucusToTab();
                        grdFlag = true;
                        return;
                    }
                }
            }

            foreach (IHIS.X.Magic.Controls.TabPage page in tabPlan_ote.TabPages)
            {
                if (tabPlan_ote.SelectedTab == page)
                    page.ImageIndex = 3;
                else
                    page.ImageIndex = 2;
            }

            grdNUR0403.QueryLayout(false);
            grdFlag = true;
        }

        private void FucusToTab()
        {
            string poteGubun = "";

            if (this.grdNUR0403.RowCount > 0)
            {
                poteGubun = this.grdNUR0403.GetItemString(this.grdNUR0403.CurrentRowNumber, "nur_plan_ote");
            }
            else
            {
                if (this.grdNUR0403.DeletedRowCount > 0)
                {
                    poteGubun = this.grdNUR0403.DeletedRowTable.Rows[0]["nur_plan_ote"].ToString();
                }
            }

            switch (poteGubun)
            {
                case "P":
                    this.tabPlan_ote.SelectedTab = this.pageP;
                    break;
                case "O":
                    this.tabPlan_ote.SelectedTab = this.pageO;
                    break;
                case "T":
                    this.tabPlan_ote.SelectedTab = this.pageT;
                    break;
                case "E":
                    this.tabPlan_ote.SelectedTab = this.pageE;
                    break;
            }
        }
        #endregion

        #region GetNUR0403()
        private void GetNUR0403()
        {
            
        }
        #endregion

        #region [그리드 로우 정렬순서 설정 및 변경 코드]

        #region 그리드 로우 정렬순서 설정
        /// <summary>
        /// 그리드의 로우 정렬순서를 설정한다.
        /// </summary>
        private void SetSequence(XEditGrid Grd)
        {
            //XMessageBox.Show(Grd.Name);
            int sort_key = -1;

            for (int i = 0; i < Grd.RowCount; i++)
            {
                sort_key = i + 1;

                if (Grd.GetItemString(i, "sort_key") != sort_key.ToString())
                    Grd.SetItemValue(i, "sort_key", sort_key);
            }
        }
        #endregion

        #region 그리드 로우순서변경버튼 클릭
        private void btnUp1_Click(object sender, System.EventArgs e)
        {
            ////0 위치에서는 변경을 막는다.
            //if (grdNUR0403.RowCount > 1 && grdNUR0403.CurrentRowNumber == 0) return;

            //int fromRowNum = grdNUR0403.CurrentRowNumber;
            //int toRowNum = fromRowNum - 1;

            //AlterGridRowPosition(grdNUR0403, fromRowNum, toRowNum);
        }

        private void btnDown1_Click(object sender, System.EventArgs e)
        {
            ////마지막 위치에서는 변경을 막는다.
            //if (grdNUR0403.RowCount > 1 && grdNUR0403.CurrentRowNumber == grdNUR0403.RowCount - 1) return;

            //int fromRowNum = grdNUR0403.CurrentRowNumber;
            //int toRowNum = fromRowNum + 1;

            //AlterGridRowPosition(grdNUR0403, fromRowNum, toRowNum);
        }

        private void btnUp2_Click(object sender, System.EventArgs e)
        {
            ////0 위치에서는 변경을 막는다.
            //if (grdNUR0404.RowCount > 1 && grdNUR0404.CurrentRowNumber == 0) return;

            //int fromRowNum = grdNUR0404.CurrentRowNumber;
            //int toRowNum = fromRowNum - 1;

            //AlterGridRowPosition(grdNUR0404, fromRowNum, toRowNum);
        }

        private void btnDown2_Click(object sender, System.EventArgs e)
        {
            ////마지막 위치에서는 변경을 막는다.
            //if (grdNUR0404.RowCount > 1 && grdNUR0404.CurrentRowNumber == grdNUR0404.RowCount - 1) return;

            //int fromRowNum = grdNUR0404.CurrentRowNumber;
            //int toRowNum = fromRowNum + 1;

            //AlterGridRowPosition(grdNUR0404, fromRowNum, toRowNum);
        }
        #endregion

        #region 그리드 로우위치 변경
        /// <summary>
        /// 선택한 로우의 위치를 변경한다.
        /// </summary>
        /// <param name="grd">해당 그리드</param>
        /// <param name="fromRowNum">대상 로우위치  </param>
        /// <param name="toRowNum"  >변경할 로우위치</param>
        //private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
        //{
        //    if (fromRowNum < 0 || toRowNum < 0 || fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount) return;

        //    if (grd == grdNUR0403) grdNUR0404.MasterLayout = null;

        //    int currentColNum = grd.CurrentColNumber;

        //    if (currentColNum == -1) currentColNum = 0;

        //    MultiLayout copyLay = grd.CopyToLayout();

        //    grd.LayoutTable.Rows.Clear();

        //    for (int i = 0; i < copyLay.RowCount; i++)
        //    {
        //        if (i == fromRowNum)
        //            continue;

        //        //변경위치로 Row를 가져간다.
        //        if (i == toRowNum)
        //        {
        //            if (fromRowNum < toRowNum)
        //                grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);

        //            grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

        //            if (fromRowNum > toRowNum)
        //                grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
        //        }
        //        else
        //            grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
        //    }

        //    grd.DisplayData();
        //    grd.SetFocusToItem(toRowNum, currentColNum);
        //    grd.SelectRow(toRowNum);

        //    if (grd == grdNUR0403) grdNUR0404.MasterLayout = grdNUR0403;
        //}
        #endregion

        #endregion

        #region grd_GridCellPainting
        private void grd_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["vald"].ToString() == "N")
            {
                //e.BackColor = Color.LightGray;
                e.ForeColor = Color.Red;
            }
        }
        #endregion

        #region NUR0102 중복체크
        private bool CheckDupCode(XEditGrid grd, GridColumnChangedEventArgs e)
        { 
            //중복 Check
            for (int i = 0; i < grd.RowCount; i++)
            {
                if (i != e.RowNumber)
                {
                    if (grd.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim())
                    {
                        return false;
                    }
                }
            }

            // Delete Table Check
            // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
            bool deleted = false;

            if (grdNUR0102.DeletedRowTable != null)
            {
                foreach (DataRow row in grdNUR0102.DeletedRowTable.Rows)
                {
                    if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                    {
                        deleted = true;
                        break;
                    }
                }
            }

            if (deleted) return true;

            string checkName = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

            if (checkName != "")
            {
                return false;
            }

            return true;
        }
        #endregion 

        #region grdNUR0102_GridColumnChanged
        private void grdNUR0102_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {            
            switch (e.ColName)
            {
                case "code":
                object code = e.ChangeValue;

                if (!TypeCheck.IsNull(code))
                {
                    if (!TypeCheck.IsInt(code))
                    {
                        XMessageBox.Show("00から99までの数字を入力してください。", "コード入力エラー", MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }

                    if (!CheckDupCode(this.grdNUR0102, e))
                    {
                        XMessageBox.Show("「" + e.ChangeValue.ToString() + "」は既に登録されています。", "コード重複", MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;                    
                    }                   

                }
                break;
            }
        }
        #endregion

        #region 마우스 드래그&드롭을 이용한 정렬순서 변경

        private Rectangle dragBoxFromMouseDown;
        private Point screenOffset;
        private int mCurRowIndex;

        private void grd_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if (grd != null)
            {
                dragBoxFromMouseDown = Rectangle.Empty;

                mCurRowIndex = grd.GetHitRowNumber(e.Y);

                if (mCurRowIndex < 0) return;

                Size dragSize = SystemInformation.DragSize;
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)), dragSize);
            }
        }

        private void grd_MouseUp(object sender, MouseEventArgs e)
        {
            dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void grd_MouseMove(object sender, MouseEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;

            if (grd != null)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    if (dragBoxFromMouseDown != Rectangle.Empty &&
                        !dragBoxFromMouseDown.Contains(e.X, e.Y))
                    {
                        screenOffset = SystemInformation.WorkingArea.Location;
                        string dragInfo = "";
                        switch(grd.Name)
                        {
                            case "grdNUR0102":
                                dragInfo = "[" + grdNUR0102.GetItemString(mCurRowIndex, "code") + "]" + grdNUR0102.GetItemString(mCurRowIndex, "code_name");
                                break;
                                
                            case "grdNUR0401":
                                dragInfo = "[" + grdNUR0401.GetItemString(mCurRowIndex, "nur_plan_jin") + "]" + grdNUR0401.GetItemString(mCurRowIndex, "nur_plan_jin_name");
                                break;
                                
                            //case "grdNUR0402":
                            //    dragInfo = "[" + grdNUR0402.GetItemString(mCurRowIndex, "nur_plan_pro") + "]" + grdNUR0402.GetItemString(mCurRowIndex, "nur_plan_proname");
                            //    break;
                                
                            case "grdNUR0403":
                                dragInfo = "[" + grdNUR0403.GetItemString(mCurRowIndex, "nur_plan") + "]" + grdNUR0403.GetItemString(mCurRowIndex, "nur_plan_name");
                                break;
                                
                            case "grdNUR0404":
                                dragInfo = "[" + grdNUR0404.GetItemString(mCurRowIndex, "nur_plan_detail") + "]" + grdNUR0404.GetItemString(mCurRowIndex, "nur_plan_dename");
                                break;
                                
                        }
                        DragHelper.CreateDragCursor(grd, dragInfo, this.Font);                  
                        DragDropEffects dropEffect = grd.DoDragDrop(mCurRowIndex.ToString(), DragDropEffects.Move);
                    }
                }
            }
        }

        private void grd_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;  // Move 표시
        }

        private void grd_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;

            // Drag시에 Cursor 바꿈
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                Cursor.Current = DragHelper.DragCursor;
            }
        }

        private void grd_DragDrop(object sender, DragEventArgs e)
        {
            XEditGrid grd = sender as XEditGrid;
            if (grd == null) return;

            // Client Point
            int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
            Point clientPoint = grd.PointToClient(new Point(e.X, e.Y));

            int toRowNum = grd.GetHitRowNumber(clientPoint.Y);

            if (toRowNum == fromRowNum || toRowNum < 0)
            {
                // Edit상태로 만든다.
                grd.SetFocusToItem(toRowNum, grd.CurrentColNumber);
                return;
            }

            DataRow backRow = grd.LayoutTable.NewRow();

            foreach (DataColumn col in grd.LayoutTable.Columns)
            {
                backRow[col.ColumnName] = grd.GetItemString(toRowNum, col.ColumnName);
                grd.SetItemValue(toRowNum, col.ColumnName, grd.GetItemString(fromRowNum, col.ColumnName));
                grd.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
            }

            grd.SetFocusToItem(toRowNum, grdNUR0102.CurrentColNumber);

            SetSequence(grd);
        }

        private void grd_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            // Cancel the drag if the mouse moves off the form.
            XEditGrid grd = sender as XEditGrid;

            if (grd != null)
            {
                Form f = grd.FindForm();

                // Cancel the drag if the mouse moves off the form. The screenOffset
                // takes into account any desktop bands that may be at the top or left
                // side of the screen.
                if (((Control.MousePosition.X - screenOffset.X) < f.DesktopBounds.Left) ||
                    ((Control.MousePosition.X - screenOffset.X) > f.DesktopBounds.Right) ||
                    ((Control.MousePosition.Y - screenOffset.Y) < f.DesktopBounds.Top) ||
                    ((Control.MousePosition.Y - screenOffset.Y) > f.DesktopBounds.Bottom))
                {

                    e.Action = DragAction.Cancel;
                }
            }
        }

        #region 주석처리 삭제예정
        //#region grdNur0401
        //private void grdNUR0401_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        //{
        //    //if (grdNUR0401.GetHitRowNumber(e.Y) < 0) return;

        //    //int curRowIndex = grdNUR0401.GetHitRowNumber(e.Y);

        //    //string dragInfo = 
        //    //DragHelper.CreateDragCursor(grdNUR0401, dragInfo, this.Font);
        //    //grdNUR0401.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);
        //}

        //private void grdNUR0401_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;  // Move 표시			
        //}

        //private void grdNUR0401_GiveFeedback(object sender, System.Windows.Forms.GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;

        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}

        //private void grdNUR0401_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        //{
        //    // Client Point
        //    int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
        //    Point clientPoint = grdNUR0401.PointToClient(new Point(e.X, e.Y));

        //    int toRowNum = grdNUR0401.GetHitRowNumber(clientPoint.Y);

        //    if (toRowNum == fromRowNum || toRowNum < 0)
        //    {
        //        // Edit상태로 만든다.
        //        grdNUR0401.SetFocusToItem(toRowNum, grdNUR0401.CurrentColNumber);
        //        return;
        //    }

        //    DataRow backRow = grdNUR0401.LayoutTable.NewRow();

        //    foreach (DataColumn col in grdNUR0401.LayoutTable.Columns)
        //    {
        //        backRow[col.ColumnName] = grdNUR0401.GetItemString(toRowNum, col.ColumnName);
        //        grdNUR0401.SetItemValue(toRowNum, col.ColumnName, grdNUR0401.GetItemString(fromRowNum, col.ColumnName));
        //        grdNUR0401.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
        //    }

        //    grdNUR0401.SetFocusToItem(toRowNum, grdNUR0401.CurrentColNumber);

        //    SetSequence(grdNUR0401);
        //}
        //#endregion

        //#region grdNur0402
        //private void grdNUR0402_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (grdNUR0402.GetHitRowNumber(e.Y) < 0) return;

        //    int curRowIndex = grdNUR0402.GetHitRowNumber(e.Y);

        //    string dragInfo = "[" + grdNUR0402.GetItemString(curRowIndex, "nur_plan_pro") + "]" + grdNUR0402.GetItemString(curRowIndex, "nur_plan_proname");
        //    DragHelper.CreateDragCursor(grdNUR0402, dragInfo, this.Font);
        //    grdNUR0402.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);
        //}

        //private void grdNUR0402_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;  // Move 표시
        //}

        //private void grdNUR0402_DragDrop(object sender, DragEventArgs e)
        //{
        //    // Client Point
        //    int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
        //    Point clientPoint = grdNUR0402.PointToClient(new Point(e.X, e.Y));

        //    int toRowNum = grdNUR0402.GetHitRowNumber(clientPoint.Y);

        //    if (toRowNum == fromRowNum || toRowNum < 0)
        //    {
        //        // Edit상태로 만든다.
        //        grdNUR0402.SetFocusToItem(toRowNum, grdNUR0402.CurrentColNumber);
        //        return;
        //    }

        //    DataRow backRow = grdNUR0402.LayoutTable.NewRow();

        //    foreach (DataColumn col in grdNUR0402.LayoutTable.Columns)
        //    {
        //        backRow[col.ColumnName] = grdNUR0402.GetItemString(toRowNum, col.ColumnName);
        //        grdNUR0402.SetItemValue(toRowNum, col.ColumnName, grdNUR0402.GetItemString(fromRowNum, col.ColumnName));
        //        grdNUR0402.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
        //    }

        //    grdNUR0402.SetFocusToItem(toRowNum, grdNUR0402.CurrentColNumber);

        //    SetSequence(grdNUR0402);
        //}

        //private void grdNUR0402_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;

        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}
        //#endregion

        //#region grdNur0403
        //private void grdNUR0403_MouseDown(object sender, MouseEventArgs e)
        //{
        //    //if (grdNUR0403.GetHitRowNumber(e.Y) < 0) return;

        //    //int curRowIndex = grdNUR0403.GetHitRowNumber(e.Y);

        //    //string dragInfo = "[" + grdNUR0403.GetItemString(curRowIndex, "nur_plan") + "]" + grdNUR0403.GetItemString(curRowIndex, "nur_plan_name");
        //    //DragHelper.CreateDragCursor(grdNUR0403, dragInfo, this.Font);
        //    //grdNUR0403.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);
        //}

        //private void grdNUR0403_DragOver(object sender, DragEventArgs e)
        //{
        //    if (grdNUR0403.GetHitRowNumber(e.Y) < 0) return;

        //    int curRowIndex = grdNUR0403.GetHitRowNumber(e.Y);

        //    string dragInfo = "[" + grdNUR0403.GetItemString(curRowIndex, "nur_plan") + "]" + grdNUR0403.GetItemString(curRowIndex, "nur_plan_name");
        //    DragHelper.CreateDragCursor(grdNUR0403, dragInfo, this.Font);
        //    grdNUR0403.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);

        //}

        //private void grdNUR0403_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;  // Move 표시
        //}

        //private void grdNUR0403_DragDrop(object sender, DragEventArgs e)
        //{
        //    // Client Point
        //    int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
        //    Point clientPoint = grdNUR0403.PointToClient(new Point(e.X, e.Y));

        //    int toRowNum = grdNUR0403.GetHitRowNumber(clientPoint.Y);

        //    if (toRowNum == fromRowNum || toRowNum < 0)
        //    {
        //        // Edit상태로 만든다.
        //        grdNUR0403.SetFocusToItem(toRowNum, grdNUR0403.CurrentColNumber);
        //        return;
        //    }

        //    DataRow backRow = grdNUR0403.LayoutTable.NewRow();

        //    foreach (DataColumn col in grdNUR0403.LayoutTable.Columns)
        //    {
        //        backRow[col.ColumnName] = grdNUR0403.GetItemString(toRowNum, col.ColumnName);
        //        grdNUR0403.SetItemValue(toRowNum, col.ColumnName, grdNUR0403.GetItemString(fromRowNum, col.ColumnName));
        //        grdNUR0403.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
        //    }

        //    grdNUR0403.SetFocusToItem(toRowNum, grdNUR0403.CurrentColNumber);

        //    SetSequence(grdNUR0403);
        //}

        //private void grdNUR0403_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;

        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}
        //#endregion

        //#region grdNur0404
        //private void grdNUR0404_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (grdNUR0404.GetHitRowNumber(e.Y) < 0) return;

        //    int curRowIndex = grdNUR0404.GetHitRowNumber(e.Y);

        //    string dragInfo = "[" + grdNUR0404.GetItemString(curRowIndex, "nur_plan_detail") + "]" + grdNUR0404.GetItemString(curRowIndex, "nur_plan_dename");
        //    DragHelper.CreateDragCursor(grdNUR0404, dragInfo, this.Font);
        //    grdNUR0404.DoDragDrop(curRowIndex.ToString(), DragDropEffects.Move);

        //}

        //private void grdNUR0404_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;  // Move 표시
        //}

        //private void grdNUR0404_DragDrop(object sender, DragEventArgs e)
        //{
        //    // Client Point
        //    int fromRowNum = int.Parse(e.Data.GetData("System.String").ToString());
        //    Point clientPoint = grdNUR0404.PointToClient(new Point(e.X, e.Y));

        //    int toRowNum = grdNUR0404.GetHitRowNumber(clientPoint.Y);

        //    if (toRowNum == fromRowNum || toRowNum < 0)
        //    {
        //        // Edit상태로 만든다.
        //        grdNUR0404.SetFocusToItem(toRowNum, grdNUR0404.CurrentColNumber);
        //        return;
        //    }

        //    DataRow backRow = grdNUR0404.LayoutTable.NewRow();

        //    foreach (DataColumn col in grdNUR0404.LayoutTable.Columns)
        //    {
        //        backRow[col.ColumnName] = grdNUR0404.GetItemString(toRowNum, col.ColumnName);
        //        grdNUR0404.SetItemValue(toRowNum, col.ColumnName, grdNUR0404.GetItemString(fromRowNum, col.ColumnName));
        //        grdNUR0404.SetItemValue(fromRowNum, col.ColumnName, backRow[col.ColumnName]);
        //    }

        //    grdNUR0404.SetFocusToItem(toRowNum, grdNUR0404.CurrentColNumber);

        //    SetSequence(grdNUR0404);
        //}

        //private void grdNUR0404_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        //{
        //    e.UseDefaultCursors = false;

        //    // Drag시에 Cursor 바꿈
        //    if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
        //    {
        //        Cursor.Current = DragHelper.DragCursor;
        //    }
        //}
        //#endregion
        #endregion

        #endregion


        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR0401U01 parent = null;
            public XSavePerformer(NUR0401U01 parent)
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

                                cmdText = @"INSERT INTO NUR0102 
                                                 ( SYS_DATE     , SYS_ID
                                                 , UPD_DATE     , UPD_ID    , HOSP_CODE
                                                 , CODE_TYPE    , CODE      , CODE_NAME     , SORT_KEY  )
                                            VALUES 
                                                 ( SYSDATE      , :q_user_id
                                                 , SYSDATE      , :q_user_id, :f_hosp_code
                                                 , 'NUR_PLAN_BUNRYU' , :f_code   , :f_code_name  , :f_sort_key   )";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR0102
                                               SET UPD_ID    = :q_user_id,
                                                   UPD_DATE  = SYSDATE,
                                                   CODE_NAME = :f_code_name,
                                                   SORT_KEY  = :f_sort_key
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = 'NUR_PLAN_BUNRYU'
                                               AND CODE      = :f_code";
                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR0404 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN 
                                                                        FROM NUR0401 B 
                                                                       WHERE B.HOSP_CODE       = :f_hosp_code 
                                                                         AND B.NUR_PLAN_BUNRYU = :f_code)";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0403 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN 
                                                                        FROM NUR0401 B 
                                                                       WHERE B.HOSP_CODE       = :f_hosp_code 
                                                                         AND B.NUR_PLAN_BUNRYU = :f_code)";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0402 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN IN (SELECT B.NUR_PLAN_JIN 
                                                                        FROM NUR0401 B 
                                                                       WHERE B.HOSP_CODE       = :f_hosp_code 
                                                                         AND B.NUR_PLAN_BUNRYU = :f_code)";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0401 A
                                             WHERE A.HOSP_CODE       = :f_hosp_code
                                               AND A.NUR_PLAN_BUNRYU = :f_code";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);


                                cmdText = @"DELETE NUR0102
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND CODE_TYPE = 'NUR_PLAN_BUNRYU'
                                               AND CODE      = :f_code";
                                break;
                        }

                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS (SELECT 'X' 
                                                             FROM NUR0401 
                                                            WHERE HOSP_CODE    = :f_hosp_code
                                                              AND NUR_PLAN_JIN = :f_nur_plan_jin)";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        //parent.ShowMessage("NurPlanJinDup", item.BindVarList["f_nur_plan_jin"].VarValue);
                                        //parent.appointmentError = true;
                                        parent.mbxMsg = String.Format("既に登録されている診断コードです。[{0}]\r\nご確認ください。", item.BindVarList["f_nur_plan_jin"].VarValue);
                                        parent.mbxCap = "保存失敗";
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0401 
                                                 ( SYS_DATE             , SYS_ID            
                                                 , UPD_DATE             , UPD_ID                , HOSP_CODE
                                                 , NUR_PLAN_JIN         , NUR_PLAN_JIN_NAME      , NUR_PLAN_BUNRYU
                                                 , VALD                 , SORT_KEY              )
                                            VALUES  
                                                 ( SYSDATE              , :q_user_id            
                                                 , SYSDATE              , :q_user_id            , :f_hosp_code
                                                 , :f_nur_plan_jin      , :f_nur_plan_jin_name   , :f_nur_plan_bunryu
                                                 , 'Y'                  , :f_sort_key           )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0401
                                               SET UPD_ID           = :q_user_id,
                                                   UPD_DATE         = SYSDATE,
                                                   NUR_PLAN_JIN_NAME = :f_nur_plan_jin_name,
                                                   NUR_PLAN_BUNRYU  = :f_nur_plan_bunryu ,
                                                   VALD             = :f_vald, 
                                                   SORT_KEY         = :f_sort_key        
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND NUR_PLAN_JIN     = :f_nur_plan_jin";
                                break;

                            case DataRowState.Deleted:
//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS (SELECT 'X'
//                                                              FROM NUR0402 
//                                                             WHERE HOSP_CODE    = :f_hosp_code
//                                                               AND NUR_PLAN_JIN = :f_nur_plan_jin)";

//                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (Service.ErrCode == 0)
//                                {
//                                    if (retVal != null && retVal.ToString().Equals("Y"))
//                                    {
//                                        //parent.ShowMessage("ChildData", item.BindVarList["f_nur_plan_jin"].VarValue);
//                                        //parent.appointmentError = true;
//                                        parent.mbxMsg = String.Format("[{0}]診断コードの詳細データがあるので削除できません。\r\nご確認ください。", item.BindVarList["f_nur_plan_jin"].VarValue);
//                                        parent.mbxCap = "保存失敗";
//                                        return false;
//                                    }
//                                }
//                                else
//                                {
//                                    return false;
//                                }


                                cmdText = @"DELETE FROM NUR0404 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN = :f_nur_plan_jin";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0403 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN = :f_nur_plan_jin";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0402 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND A.NUR_PLAN_JIN = :f_nur_plan_jin";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE NUR0401 
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND NUR_PLAN_JIN = :f_nur_plan_jin";
                                break;
                        }
                        break;

                    case '3':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS (SELECT 'X' 
                                                         FROM NUR0402 
                                                        WHERE HOSP_CODE    = :f_hosp_code
                                                          AND NUR_PLAN_JIN = :f_nur_plan_jin
                                                          AND NUR_PLAN_PRO = :f_nur_plan_pro )";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        //parent.ShowMessage("NurPlanProDup", item.BindVarList["f_nur_plan_pro"].VarValue);
                                        //parent.appointmentError = true;
                                        parent.mbxMsg = String.Format("既に登録されている問題リストコードです。[{0}]\r\nご確認ください。", item.BindVarList["f_nur_plan_pro"].VarValue);
                                        parent.mbxCap = "保存失敗";
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0402 
                                             ( SYS_DATE         , SYS_ID                
                                             , UPD_DATE         , UPD_ID            , HOSP_CODE
                                             , NUR_PLAN_JIN     , NUR_PLAN_PRO      , NUR_PLAN_PRO_NAME
                                             , VALD             , SORT_KEY          )
                                        VALUES 
                                             ( SYSDATE          , :q_user_id
                                             , SYSDATE          , :q_user_id        , :f_hosp_code
                                             , :f_nur_plan_jin  , :f_nur_plan_pro   , :f_nur_plan_pro_name
                                             , 'Y'              , :f_sort_key       )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0402
                                           SET UPD_ID           = :q_user_id,
                                               UPD_DATE         = SYSDATE,
                                               NUR_PLAN_PRO_NAME = :f_nur_plan_pro_name,
                                               VALD             = :f_vald, 
                                               SORT_KEY         = :f_sort_key        
                                         WHERE HOSP_CODE        = :f_hosp_code
                                           AND NUR_PLAN_JIN     = :f_nur_plan_jin
                                           AND NUR_PLAN_PRO     = :f_nur_plan_pro";
                                break;

                            case DataRowState.Deleted:
//                                cmdText = @"SELECT 'Y'
//                                          FROM DUAL
//                                         WHERE EXISTS (SELECT 'X' 
//                                                         FROM NUR0403 
//                                                        WHERE HOSP_CODE    = :f_hosp_code
//                                                          AND NUR_PLAN_JIN = :f_nur_plan_jin
//                                                          AND NUR_PLAN_PRO = :f_nur_plan_pro  ) ";

//                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (Service.ErrCode == 0)
//                                {
//                                    if (retVal != null && retVal.ToString().Equals("Y"))
//                                    {
//                                        //parent.ShowMessage("ChildData", item.BindVarList["f_nur_plan_pro"].VarValue);
//                                        //parent.appointmentError = true;
//                                        parent.mbxMsg = String.Format("[{0}]問題リストコードの詳細データがあります。\r\nご確認ください。", item.BindVarList["f_nur_plan_pro"].VarValue);
//                                        parent.mbxCap = "保存失敗";
//                                        return false;
//                                    }
//                                }
//                                else
//                                {
//                                    return false;
//                                }

                                cmdText = @"DELETE FROM NUR0404 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND NUR_PLAN_JIN = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO = :f_nur_plan_pro";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM NUR0403 A
                                             WHERE A.HOSP_CODE    = :f_hosp_code
                                               AND NUR_PLAN_JIN = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO = :f_nur_plan_pro";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);
                                cmdText = @"DELETE NUR0402 
                                         WHERE HOSP_CODE    = :f_hosp_code
                                           AND NUR_PLAN_JIN = :f_nur_plan_jin
                                           AND NUR_PLAN_PRO = :f_nur_plan_pro";
                                break;
                        }
                        break;

                    case '4':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM  DUAL
                                             WHERE EXISTS( SELECT 'X' 
                                                             FROM NUR0403
                                                            WHERE HOSP_CODE    = :f_hosp_code
                                                              AND NUR_PLAN_JIN = :f_nur_plan_jin
                                                              --AND NUR_PLAN_PRO = :f_nur_plan_pro
                                                              AND NUR_PLAN     = :f_nur_plan     )";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        parent.mbxMsg = String.Format("保存に失敗しました。\n看護計画コード[{0}][{1}][{2}]は既に登録されています。",
                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
                                                               item.BindVarList["f_nur_plan"].VarValue);
                                        parent.mbxCap = "保存失敗";
                                        //parent.appointmentError = true;

                                        //XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0403 
                                                 ( SYS_DATE             , SYS_ID
                                                 , UPD_DATE             , UPD_ID            , HOSP_CODE
                                                 , NUR_PLAN_JIN         , NUR_PLAN_PRO      , NUR_PLAN
                                                 , NUR_PLAN_NAME        , NUR_PLAN_OTE 
                                                 , SORT_KEY             , FROM_DATE         , END_DATE          , VALD)
                                            VALUES 
                                                 ( SYSDATE              , :q_user_id
                                                 , SYSDATE              , :q_user_id        , :f_hosp_code
                                                 , :f_nur_plan_jin      , :f_nur_plan_pro   , :f_nur_plan 
                                                 , :f_nur_plan_name     , :f_nur_plan_ote
                                                 , :f_sort_key          , TRUNC(SYSDATE)    , NVL(:f_end_date,'9998/12/31')     , :f_vald  )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0403
                                               SET UPD_ID        = :q_user_id,
                                                   UPD_DATE      = SYSDATE,
                                                   NUR_PLAN_NAME = :f_nur_plan_name,
                                                   SORT_KEY      = :f_sort_key,
                                                   VALD          = :f_vald
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
                                               --AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan";
                                break;

                            case DataRowState.Deleted:
//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X' 
//                                                              FROM NUR0404
//                                                             WHERE HOSP_CODE     = :f_hosp_code
//                                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
//                                                               AND NUR_PLAN_PRO  = :f_nur_plan_pro
//                                                               AND NUR_PLAN      = :f_nur_plan   ) ";

//                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (Service.ErrCode == 0)
//                                {
//                                    if (retVal != null && retVal.ToString().Equals("Y"))
//                                    {
//                                        parent.mbxMsg = String.Format("保存に失敗しました。\n看護計画コード[{0}][{1}][{2}]は詳細コードが登録されています。",
//                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
//                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
//                                                               item.BindVarList["f_nur_plan"].VarValue);
//                                        parent.mbxCap = "削除失敗";
//                                        parent.appointmentError = true;
//                                        //XMessageBox.Show(mbxMsg, mbxCap);

//                                        return false;
//                                    }
//                                }
//                                else
//                                {
//                                    return false;
//                                }
                                cmdText = @"DELETE FROM NUR0404 A
                                             WHERE A.HOSP_CODE   = :f_hosp_code
                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
                                               --AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan";
                                
                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE NUR0403
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
                                               --AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan";
                                break;
                        }

                        break;

                    case '5':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS( SELECT 'X' 
                                                             FROM NUR0404
                                                             WHERE HOSP_CODE       = :f_hosp_code
                                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                                               --AND NUR_PLAN_PRO    = :f_nur_plan_pro
                                                               AND NUR_PLAN        = :f_nur_plan
                                                               AND NUR_PLAN_DETAIL = :f_nur_plan_detail ) ";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        parent.mbxMsg = String.Format("保存に失敗しました。\n看護計画小コード[{0}][{1}][{2}][{3}]は既に登録されています。",
                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
                                                               item.BindVarList["f_nur_plan"].VarValue,
                                                               item.BindVarList["f_nur_plan_detail"].VarValue);
                                        parent.mbxCap = "保存失敗";
                                        //XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0404 
                                                 ( SYS_DATE         , SYS_ID
                                                 , UPD_DATE         , UPD_ID            , HOSP_CODE
                                                 , NUR_PLAN_JIN     , NUR_PLAN_PRO      
                                                 , NUR_PLAN         , NUR_PLAN_DETAIL   , NUR_PLAN_DENAME
                                                 , SORT_KEY         , FROM_DATE         , END_DATE          
                                                 , VALD             )
                                            VALUES  
                                                 ( SYSDATE          , :q_user_id
                                                 , SYSDATE          , :q_user_id        , :f_hosp_code
                                                 , :f_nur_plan_jin  , :f_nur_plan_pro
                                                 , :f_nur_plan      , :f_nur_plan_detail, :f_nur_plan_dename
                                                 , :f_sort_key      , TRUNC(SYSDATE)    , NVL(:f_end_date,'9998/12/31')
                                                 , :f_vald          )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0404
                                               SET UPD_ID          = :q_user_id,
                                                   UPD_DATE        = SYSDATE,
                                                   NUR_PLAN_DENAME = :f_nur_plan_dename,
                                                   SORT_KEY        = :f_sort_key,
                                                   VALD            = :f_vald
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                               --AND NUR_PLAN_PRO    = :f_nur_plan_pro
                                               AND NUR_PLAN        = :f_nur_plan
                                               AND NUR_PLAN_DETAIL = :f_nur_plan_detail";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR0404
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                               --AND NUR_PLAN_PRO    = :f_nur_plan_pro
                                               AND NUR_PLAN        = :f_nur_plan
                                               AND NUR_PLAN_DETAIL = :f_nur_plan_detail";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion


        #region ReturnClass 널체크해서 넘겨받는 클래스
        private class ReturnClass
        {
            XEditGrid grd;
            int rowNum;
            string colName;

            public ReturnClass(XEditGrid grd, int rowNum, string colName)
            {
                this.grd = grd;
                this.rowNum = rowNum;
                this.colName = colName;
            }

            public XEditGrid ReturnGrd
            {
                get
                { 
                    return this.grd;
                }
            }

            public int ReturnRowNum
            {
                get
                {
                    return this.rowNum;
                }
            }

            public string ReturnColName
            {
                get
                {
                    return this.colName;
                }
            }
        }
        #endregion

        private void NUR0401U01_Closing(object sender, CancelEventArgs e)
        {
            if (!mIsUpdateSuccess)
                e.Cancel = true;
        }

        private void NUR0401U01_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Width, rc.Height - 105);

        }

        private void grdNUR0403_QueryStarting(object sender, CancelEventArgs e)
        {
            SetTabColor(false);

            grdNUR0403.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0403.SetBindVarValue("f_nur_plan_jin", grdNUR0401.GetItemString(grdNUR0401.CurrentRowNumber, "nur_plan_jin"));
            //grdNUR0403.SetBindVarValue("f_nur_plan_pro", grdNUR0402.GetItemValue(grdNUR0402.CurrentRowNumber, "nur_plan_pro").ToString());
            grdNUR0403.SetBindVarValue("f_nur_plan_ote", this.tabPlan_ote.SelectedTab.Tag.ToString());

            //grdNUR0403.SetBindVarValue("f_app_date", appDate);
        }

        private void SetTabColor(bool isClaer)
        {
            if (isClaer)
            {
                for (int i = 0; i < this.tabPlan_ote.TabPages.Count; i++)
                {
                    tabPlan_ote.TabPages[i].TitleTextColor = Color.Black;
                }
                return;
            }

            try
            {
                layTabColor.SetBindVarValue("f_hosp_code", this.mHospCode);
                layTabColor.SetBindVarValue("f_nur_plan_jin", grdNUR0401.GetItemValue(grdNUR0401.CurrentRowNumber, "nur_plan_jin").ToString());
                //layTabColor.SetBindVarValue("f_nur_plan_pro", grdNUR0402.GetItemValue(grdNUR0402.CurrentRowNumber, "nur_plan_pro").ToString());
                layTabColor.QueryLayout(false);

                string pote = "";
                //foreach (DataRow row in layTabColor.LayoutTable.Rows)
                //{
                //    //pote += row["plan_ote"].ToString();
                //    pote = row["plan_ote"].ToString();
                //    switch (pote)
                //    { 
                //        case "P":
                //            break;
                //    }


                //}
                foreach (DataRow row in layTabColor.LayoutTable.Rows)
                    pote += row["plan_ote"].ToString();

                //foreach (TabPage tp in this.tabPlan_ote.TabPages)
                //{
                //    if (pote.IndexOf(tp.Tag.ToString()) >= 0)
                //        tp.TitleTextColor = Color.Red;
                //    else
                //        tp.TitleTextColor = Color.Black;
                //}

                for (int i = 0; i < this.tabPlan_ote.TabPages.Count; i++)
                {
                    if (pote.IndexOf(tabPlan_ote.TabPages[i].Tag.ToString()) >= 0)
                        tabPlan_ote.TabPages[i].TitleTextColor = Color.Red;
                    else
                        tabPlan_ote.TabPages[i].TitleTextColor = Color.Black;
                }
            }
            catch
            { }
        }

        private void grdNUR0404_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR0404.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0404.SetBindVarValue("f_nur_plan_jin", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_jin"));
            grdNUR0404.SetBindVarValue("f_nur_plan", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan"));
        }

        private void grdNUR0403_SaveEnd(object sender, SaveEndEventArgs e)
        {
            SetTabColor(false);
        }

        //private void grdNUR0402_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    grdNUR0402.SetBindVarValue("f_hosp_code", this.mHospCode);
        //    grdNUR0402.SetBindVarValue("f_nur_plan_jin", this.grdNUR0401.GetItemString(grdNUR0401.CurrentRowNumber, "nur_plan_jin"));
            
        //}


    }
}