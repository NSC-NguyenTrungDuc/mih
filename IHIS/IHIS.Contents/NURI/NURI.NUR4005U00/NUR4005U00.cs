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
	/// NUR4005U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR4005U00 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
        //private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();	
        //private IHIS.Framework.DataServiceDynMO mDsdCombo = new DataServiceDynMO();
		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		
		int    mFkinp1001 = 0;
		int    mPknur4002 = 0;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XMstGrid   grdNUR4002;
		private IHIS.Framework.XEditGrid grdNUR4005;		
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XPanel xPanel3;
        private XTreeView tvwNUR4003;
        private MultiLayout dloPlanInfo;
        private MultiLayoutItem multiLayoutItem13;
        private MultiLayoutItem multiLayoutItem14;
        private MultiLayoutItem multiLayoutItem15;
        private MultiLayoutItem multiLayoutItem16;
        private MultiLayoutItem multiLayoutItem17;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        private MultiLayoutItem multiLayoutItem21;
        private MultiLayoutItem multiLayoutItem22;
        private MultiLayoutItem multiLayoutItem25;
        private MultiLayoutItem multiLayoutItem26;
        private MultiLayoutItem multiLayoutItem27;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR4005U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4005U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdNUR4005 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.grdNUR4002 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.tvwNUR4003 = new IHIS.Framework.XTreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.dloPlanInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem22 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem25 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem26 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem27 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPlanInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "sun.gif");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(2, "YESUP1.ICO");
            // 
            // xPanel1
            // 
            this.xPanel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(0, 550);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(980, 40);
            this.xPanel1.TabIndex = 0;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(572, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 38);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.BorderColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xPanel2.CausesValidation = false;
            this.xPanel2.Controls.Add(this.xPanel3);
            this.xPanel2.Controls.Add(this.splitter1);
            this.xPanel2.Controls.Add(this.grdNUR4002);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.Location = new System.Drawing.Point(0, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(980, 550);
            this.xPanel2.TabIndex = 2;
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdNUR4005);
            this.xPanel3.Controls.Add(this.tvwNUR4003);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel3.Location = new System.Drawing.Point(425, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(555, 550);
            this.xPanel3.TabIndex = 7;
            // 
            // grdNUR4005
            // 
            this.grdNUR4005.ApplyPaintEventToAllColumn = true;
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
            this.grdNUR4005.Location = new System.Drawing.Point(0, 407);
            this.grdNUR4005.MasterLayout = this.grdNUR4002;
            this.grdNUR4005.Name = "grdNUR4005";
            this.grdNUR4005.QuerySQL = resources.GetString("grdNUR4005.QuerySQL");
            this.grdNUR4005.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4005.RowHeaderVisible = true;
            this.grdNUR4005.RowResizable = true;
            this.grdNUR4005.Rows = 2;
            this.grdNUR4005.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR4005.Size = new System.Drawing.Size(555, 143);
            this.grdNUR4005.TabIndex = 0;
            this.grdNUR4005.UseDefaultTransaction = false;
            this.grdNUR4005.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4005_QueryStarting);
            this.grdNUR4005.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdNUR4005_PreSaveLayout);
            this.grdNUR4005.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR4005_GridColumnProtectModify);
            this.grdNUR4005.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4005_GridColumnChanged);
            this.grdNUR4005.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR4005_SaveEnd);
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
            this.xEditGridCell12.CellWidth = 103;
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
            this.xEditGridCell13.CellWidth = 103;
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
            this.xEditGridCell15.CellWidth = 405;
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
            // grdNUR4002
            // 
            this.grdNUR4002.CallerID = '2';
            this.grdNUR4002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell17});
            this.grdNUR4002.ColPerLine = 2;
            this.grdNUR4002.Cols = 3;
            this.grdNUR4002.ControlBinding = true;
            this.grdNUR4002.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdNUR4002.FixedCols = 1;
            this.grdNUR4002.FixedRows = 1;
            this.grdNUR4002.FocusColumnName = "nur_plan_proname";
            this.grdNUR4002.HeaderHeights.Add(24);
            this.grdNUR4002.Location = new System.Drawing.Point(0, 0);
            this.grdNUR4002.Name = "grdNUR4002";
            this.grdNUR4002.QuerySQL = resources.GetString("grdNUR4002.QuerySQL");
            this.grdNUR4002.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4002.RowHeaderVisible = true;
            this.grdNUR4002.RowResizable = true;
            this.grdNUR4002.Rows = 2;
            this.grdNUR4002.Size = new System.Drawing.Size(420, 550);
            this.grdNUR4002.TabIndex = 5;
            this.grdNUR4002.ToolTipActive = true;
            this.grdNUR4002.UseDefaultTransaction = false;
            this.grdNUR4002.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR4002_QueryEnd);
            this.grdNUR4002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR4002_RowFocusChanged);
            this.grdNUR4002.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR4002_GridCellPainting);
            this.grdNUR4002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4002_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "pknur4002";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "pknur4002";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "bunho";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "bunho";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "fkinp1001";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderText = "fkinp1001";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "nur_plan_jin";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "nur_plan_jin";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "nur_plan_pro";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "nur_plan_pro";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdatable = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.ApplyPaintingEvent = true;
            this.xEditGridCell6.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell6.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell6.CellName = "nur_plan_proname";
            this.xEditGridCell6.CellWidth = 349;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell6.HeaderImage")));
            this.xEditGridCell6.HeaderText = "問題リスト";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.SelectedBackColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaption);
            this.xEditGridCell6.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.SystemColors.ActiveCaptionText);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "plan_user";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "plan_user";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "plan_usnm";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "plan_usnm";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "plan_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "plan_date";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell10.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell10.CellName = "vald";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.CheckedValue = "N";
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.HeaderText = "終了";
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.UnCheckedValue = "Y";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "nur0402_valid";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // tvwNUR4003
            // 
            this.tvwNUR4003.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvwNUR4003.Font = new System.Drawing.Font("MS UI Gothic", 11F);
            this.tvwNUR4003.HideSelection = false;
            this.tvwNUR4003.ImageIndex = 0;
            this.tvwNUR4003.ImageList = this.ImageList;
            this.tvwNUR4003.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwNUR4003.Location = new System.Drawing.Point(0, 0);
            this.tvwNUR4003.Name = "tvwNUR4003";
            this.tvwNUR4003.SelectedImageIndex = 0;
            this.tvwNUR4003.Size = new System.Drawing.Size(555, 407);
            this.tvwNUR4003.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter1.Location = new System.Drawing.Point(420, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 550);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // dloPlanInfo
            // 
            this.dloPlanInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem13,
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20,
            this.multiLayoutItem21,
            this.multiLayoutItem22,
            this.multiLayoutItem25,
            this.multiLayoutItem26,
            this.multiLayoutItem27});
            this.dloPlanInfo.QuerySQL = resources.GetString("dloPlanInfo.QuerySQL");
            this.dloPlanInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloPlanInfo_QueryStarting);
            this.dloPlanInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dloPlanInfo_QueryEnd);
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "fknur4002";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "pknur4003";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "nur_plan";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "nur_plan_name";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "nur4003_vald";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "pknur4004";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "nur_plan_dename";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "nur4004_vald";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "nur_plan_name_1";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "nur4003_sort";
            this.multiLayoutItem26.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "nur4004_sort";
            this.multiLayoutItem27.DataType = IHIS.Framework.DataType.Number;
            // 
            // NUR4005U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel1);
            this.Name = "NUR4005U00";
            this.Size = new System.Drawing.Size(980, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4005U00_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4005)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPlanInfo)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region [Screen Event]
	
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			PostCallHelper.PostCall(new PostMethod(PostLoad));
		}

		private void PostLoad()
		{	
			if(mFkinp1001 == 0) 
			{
				this.Close();
				return;
			}

            this.grdNUR4005.SavePerformer = new XSavePerformer(this);
            this.grdNUR4002.SavePerformer = this.grdNUR4005.SavePerformer;


			this.CurrMSLayout = grdNUR4005;
			this.CurrMQLayout = grdNUR4005;

			//Set M/D Relation
			grdNUR4005.SetRelationKey("fknur4002", "pknur4002");
            grdNUR4005.SetRelationTable("NUR4005");

            //Load 해당환자 간호계획정보
            //this.grdNUR4002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
			this.grdNUR4002.QueryLayout(true);	
			
		}

		private void NUR4005U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("fkinp1001"))
					{
						if(!TypeCheck.IsInt(OpenParam["fkinp1001"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が有効ではありません。ご確認ください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
							return;
						}
						else
							mFkinp1001 = int.Parse(OpenParam["fkinp1001"].ToString().Trim());
					}
					else
					{
						mbxMsg = NetInfo.Language == LangMode.Jr ? "入院情報が有効ではありません。ご確認ください。" : "입원정보가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);	
						return;
					}
					
					if(OpenParam.Contains("pknur4002"))
					{
						if(TypeCheck.IsInt(OpenParam["pknur4002"].ToString()))
							mPknur4002 = int.Parse(OpenParam["pknur4002"].ToString());
					}

				}
				catch (Exception ex)
				{
					//https://sofiamedix.atlassian.net/browse/MED-10610
					//XMessageBox.Show(ex.Message, "");	
				}
			}
			else
			{
				mFkinp1001 = 38084;				
				mPknur4002 = 11;				
			}	
		
		}

		#endregion

		#region [DataService Event]

        private void grdNUR4002_QueryEnd(object sender, QueryEndEventArgs e)
        {
//            string cmdText = "";
//            BindVarCollection bc = new BindVarCollection();

//            for (int i = 0; i < grdNUR4002.RowCount; i++)
//            {
//                ///////////////////////////////////////////////////////////////////

//                cmdText = @"SELECT 'N'FROM DUAL
//                             WHERE EXISTS (SELECT 'X'
//                                             FROM NUR4005
//                                            WHERE FKNUR4002 = :f_pknur4002)";

//                object retVal = Service.ExecuteScalar(cmdText, bc);

//                if (!TypeCheck.IsNull(retVal) && retVal.ToString().Equals("N"))
//                    this.grdNUR4002.SetItemValue(i, "modify_yn", "N");
//                else
//                    this.grdNUR4002.SetItemValue(i, "modify_yn", "");
//                ///////////////////////////////////////////////////////////////////
//            }

            for (int i = 0; i < grdNUR4002.RowCount; i++)
            {
                if (grdNUR4002.GetItemInt(i, "pknur4002") == mPknur4002)
                {
                    grdNUR4002.SetFocusToItem(i, 0);
                    mPknur4002 = 0;
                    break;
                }
            }	
        }


        private void grdNUR4005_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            //grdNUR4005
            //for (int rowIndex = 0; rowIndex < grdNUR4005.RowCount; rowIndex++)
            //{
            //    if (grdNUR4005.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
            //    {
            //        //Key값이 없으면 삭제처리
            //        if (grdNUR4005.GetItemString(rowIndex, "reser_date").Trim() == "")
            //        {
            //            grdNUR4005.DeleteRow(rowIndex);
            //            rowIndex = rowIndex - 1;
            //            continue;
            //        }
            //    }
            //}
        }
		
		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
			switch (e.Func)
			{
				case FunctionType.Insert:

                    e.IsBaseCall = false;

                    if (this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") != "Y")
                    {
                        e.IsSuccess = false;
                        return;
                    }                

					this.CurrMSLayout = this.grdNUR4005;
                    
					if(this.CurrMSLayout == grdNUR4002) break;
					
					//비어있는 insert된 row가 있는지 check한다. 
					DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);

					if(chkCell.RowNumber >= 0)
					{
						((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
					}
					else
					{
						int fknur4002 = grdNUR4002.GetItemInt(grdNUR4002.CurrentRowNumber, "pknur4002");
						int insertRow = grdNUR4005.InsertRow();
						grdNUR4005.SetItemValue(insertRow, "fknur4002", fknur4002);
					}

					break;

				case FunctionType.Update:
                    
                    e.IsBaseCall = false;

                    for (int i = 0; i < this.grdNUR4005.RowCount; i++)
                    {
                        if (this.grdNUR4005.GetItemString(i, "value_date") == "")
                        {
                            e.IsSuccess = false;
                            XMessageBox.Show("評価日付を入力してください。", "評価日付未入力", MessageBoxIcon.Information);
                            this.grdNUR4005.SetFocusToItem(i, "value_date");
                            return;
                        }
                    }

                    try
                    {
                        Service.BeginTransaction();

                        if (!this.grdNUR4002.SaveLayout())
                            throw new Exception();

                        if (!this.grdNUR4005.SaveLayout())
                            throw new Exception();

                        Service.CommitTransaction();
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                        SetMsg(mbxMsg);
                        this.Close();
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다.";
                        mbxMsg = mbxMsg + Service.ErrMsg;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "保存失敗" : "Error";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                    
                    }

					break;

                case FunctionType.Delete:

                    if (this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") != "Y")
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    break;

				default:

					break;
			}			
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
					for( int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
					{
						if(grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
						{	
							//Row header가 보여주고 있는지 check
							if(grdChk.RowHeaderVisible)
                                celReturn.ColumnNumber = cell.Col - 1;
							else
								celReturn.ColumnNumber = cell.Col;

							celReturn.RowNumber   = rowIndex;
							break;
						}
					}

					if(celReturn.RowNumber < 0) 
						continue;
					else
						break;
				}

			}

			return celReturn;
		}


		#endregion

		#region [grdNUR4005 Event]

		private void grdNUR4005_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
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

        private void grdNUR4005_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR4005.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR4005.SetBindVarValue("f_pknur4002", this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "pknur4002"));
        }

		#endregion

		#region 평가일이 지난 데이터를 색깔로 표시
		private void grdNUR4005_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if(!TypeCheck.IsNull(e.DataRow["value_date"].ToString()))
			{
				if(int.Parse(DateTime.Parse(e.DataRow["value_date"].ToString()).ToString("yyyyMMdd")) < int.Parse(EnvironInfo.GetSysDate().ToString("yyyyMMdd")))
				{
                    e.BackColor = Color.LightGray;
				}
			}
		}
		#endregion

		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "保存";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "注意";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region 저장 후 메세지
        
        private void grdNUR4005_SaveEnd(object sender, SaveEndEventArgs e)
        {
            //if (e.IsSuccess)
            //{
            //    this.GetMessage("save_true");
            //    return;
            //}
            //else
            //{
            //    this.GetMessage("save_false");
            //    return;
            //}

        }
        
		#endregion

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        { 
            NUR4005U00 parent;

            public XSavePerformer(NUR4005U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch(callerID)
                {
                    case '1':
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

                            t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

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

                    case '2':
                        switch (item.RowState)
                        {

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR4002
		                                   SET UPD_DATE          = SYSDATE
                                             , UPD_ID            = :q_user_id
                                             --, PLAN_DATE         = :f_plan_date
		                                     , NUR_PLAN_PRO_NAME = :f_nur_plan_proname
		                                     , VALD              = NVL(:f_vald, 'N')
		                                 WHERE HOSP_CODE         = :f_hosp_code 
                                           AND PKNUR4002         = :f_pknur4002";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdNUR4002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR4002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());
        }

        private void grdNUR4002_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["nur0402_valid"].ToString() == "N")
            {
                e.BackColor = Color.LightGray;
                e.ForeColor = Color.Red;
            }

            if (e.DataRow["vald"].ToString() == "N")
            {
                e.BackColor = Color.LightGreen;
            }
        }

        private void grdNUR4005_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") != "Y")
            {
                e.Protect = true;
            }
            else
            {
                e.Protect = false;
            }
        }

        private void grdNUR4002_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (e.CurrentRow >= 0) this.dloPlanInfo.QueryLayout(true);	
        }

        private void dloPlanInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            int rowNum = this.grdNUR4002.CurrentRowNumber;

            this.dloPlanInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.dloPlanInfo.SetBindVarValue("f_pknur4002", this.grdNUR4002.GetItemString(rowNum, "pknur4002"));
            this.dloPlanInfo.SetBindVarValue("f_nur_plan_jin", this.grdNUR4002.GetItemString(rowNum, "nur_plan_jin"));
            this.dloPlanInfo.SetBindVarValue("f_nur_plan_pro", this.grdNUR4002.GetItemString(rowNum, "nur_plan_pro"));
        }

        private void dloPlanInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            int o_seq = 0;
            int t_seq = 0;
            int e_seq = 0;
            string nur_plan_ote = "";
            string nur_plan_name = "";
            //string t_nur_plan_jin = "";
            //string t_nur_plan_pro = "";

            for (int i = 0; i < this.dloPlanInfo.RowCount; i++)
            {
                nur_plan_ote = this.dloPlanInfo.GetItemString(i, "nur_plan_ote");
                nur_plan_name = this.dloPlanInfo.GetItemString(i, "nur_plan_name_1");

                switch (nur_plan_ote)
                {
                    case "O":
                        o_seq++;
                        //this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_ote + "-" + o_seq.ToString() + " " + nur_plan_name);
                        this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_name);
                        break;

                    case "T":
                        t_seq++;
                        //this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_ote + "-" + t_seq.ToString() + " " + nur_plan_name);
                        this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_name);
                        break;

                    case "E":
                        e_seq++;
                        //this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_ote + "-" + e_seq.ToString() + " " + nur_plan_name);
                        this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_name);
                        break;

                    case "P":
                        this.dloPlanInfo.SetItemValue(i, "nur_plan_name", nur_plan_name);
                        break;
                }

                //if (this.dloPlanInfo.GetItemString(i, "nur_plan_jin").Equals(t_nur_plan_jin) || this.dloPlanInfo.GetItemString(i, "nur_plan_pro").Equals(t_nur_plan_pro))
                //{
                //    o_seq = 0;
                //    t_seq = 0;
                //    e_seq = 0;
                //}

                //t_nur_plan_jin = this.layNUR4002.GetItemString(i, "nur_plan_jin");
                //t_nur_plan_pro = this.layNUR4002.GetItemString(i, "nur_plan_pro");
            }

            string pknur4002 = grdNUR4002.GetItemString(grdNUR4002.CurrentRowNumber, "pknur4002");

            if (pknur4002 == "") return;

            this.ShowOCS4002();
        }
        #region [해당환자의 간호계획내역]

        private void ShowOCS4002()
        {
            this.tvwNUR4003.BeforeSelect -= new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
            tvwNUR4003.Nodes.Clear();
            if (dloPlanInfo.RowCount < 1) return;

            //Node 단계 check변수
            string nur_plan_ote = "";
            string nur_plan = "";
            TreeNode node;

            foreach (DataRow row in dloPlanInfo.LayoutTable.Rows)
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

                    node.Tag = row["nur_plan_ote"].ToString();
                    node.SelectedImageIndex = 0;
                    node.ImageIndex = 0;

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes.Add(node);
                    nur_plan_ote = row["nur_plan_ote"].ToString();
                    nur_plan = "";
                }

                if (nur_plan != row["nur_plan"].ToString())
                {
                    node = new TreeNode(row["nur_plan_name"].ToString());
                    node.Tag = row["pknur4003"].ToString() + "|" + row["nur_plan"].ToString();
                    if (row["nur4003_vald"].ToString() == "Y")
                    {
                        node.SelectedImageIndex = 2;
                        node.ImageIndex = 2;
                    }
                    else
                    {
                        node.SelectedImageIndex = 1;
                        node.ImageIndex = 1;
                    }

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].Nodes.Add(node);
                    nur_plan = row["nur_plan"].ToString();
                }


                if (row["nur_plan_detail"].ToString().Trim() != "X")
                {
                    node = new TreeNode(row["nur_plan_dename"].ToString());
                    node.Tag = row["pknur4004"].ToString() + "|" + row["nur_plan_detail"].ToString();
                    if (row["nur4004_vald"].ToString() == "Y")
                    {
                        node.SelectedImageIndex = 2;
                        node.ImageIndex = 2;
                    }
                    else
                    {
                        node.SelectedImageIndex = 1;
                        node.ImageIndex = 1;
                    }

                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count - 1].LastNode.Nodes.Add(node);
                }
            }

            tvwNUR4003.ExpandAll();
            this.tvwNUR4003.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
        }

        private void tvwNUR4003_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            if (e.Node.Parent == null)
                tvwNUR4003.LabelEdit = false;
            else
                if (tvwNUR4003.LabelEdit) tvwNUR4003.LabelEdit = true;
        }
        #endregion

	}
}
