#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Text;
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
	/// NUR4002U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR4002U01 : IHIS.Framework.XScreen
	{
		#region [DynService Control]
        //private IHIS.Framework.ValidationServiceDyn mVsdCommon = new ValidationServiceDyn();	
        //private IHIS.Framework.DataServiceDynMO mDsdCombo = new DataServiceDynMO();
        private IHIS.Framework.SingleLayout mVsdCommon = new SingleLayout();
		
		#endregion

		#region [Instance Variable]
		//Message처리
		string mbxMsg = "", mbxCap = "";	
		
		string mBunho = "";
		int    mFkinp1001 = 0;
		int    mPknur4002 = 0;
		string mNur_plan_jin = "";
        string mNur_plan_pro = "";
		string del_flag = string.Empty;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGrid grdNUR4002;
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XFlatLabel xFlatLabel1;
        private IHIS.Framework.XFlatLabel xFlatLabel2;
		private IHIS.Framework.XDisplayBox dbxPlan_usnm;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.MultiLayout dloPlanInfo;
        //private IHIS.Framework.DataServiceSIMO dsvLDNUR4002;
        //private IHIS.Framework.DataServiceSIMO dsvLDNUR4003;
		private IHIS.Framework.XTreeView tvwNUR4003;
        //private IHIS.Framework.DataServiceMMISO dsvSave;
		private IHIS.Framework.MultiLayout dloDetailData;
		private IHIS.Framework.XDatePicker dtpPlan_date;
		private IHIS.Framework.XButton btnDelete;
        //private IHIS.Framework.DataServiceSISO dsvNUR4002DelCheck;
		private IHIS.Framework.XButton btnInsert;
        //private IHIS.Framework.DataServiceSISO dataServiceSISO1;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayout layNUR4002DelCheck;
        private MultiLayout layDeleteNUR4004;
        private MultiLayoutItem multiLayoutItem12;
        private XEditGridCell xEditGridCell12;
        private XButton btnUnselectAll;
        private XButton btnSelectAll;
        private XEditGridCell xEditGridCell13;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private MultiLayoutItem multiLayoutItem9;
        private MultiLayoutItem multiLayoutItem10;
        private MultiLayoutItem multiLayoutItem11;
        private MultiLayoutItem multiLayoutItem23;
        private MultiLayoutItem multiLayoutItem24;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR4002U01()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4002U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnInsert = new IHIS.Framework.XButton();
            this.btnDelete = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnUnselectAll = new IHIS.Framework.XButton();
            this.btnSelectAll = new IHIS.Framework.XButton();
            this.dtpPlan_date = new IHIS.Framework.XDatePicker();
            this.dbxPlan_usnm = new IHIS.Framework.XDisplayBox();
            this.xFlatLabel2 = new IHIS.Framework.XFlatLabel();
            this.xFlatLabel1 = new IHIS.Framework.XFlatLabel();
            this.tvwNUR4003 = new IHIS.Framework.XTreeView();
            this.grdNUR4002 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.dloPlanInfo = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem23 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem24 = new IHIS.Framework.MultiLayoutItem();
            this.dloDetailData = new IHIS.Framework.MultiLayout();
            this.layNUR4002DelCheck = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDeleteNUR4004 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPlanInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDetailData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeleteNUR4004)).BeginInit();
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
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnInsert);
            this.xPanel1.Controls.Add(this.btnDelete);
            this.xPanel1.Controls.Add(this.xButtonList1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel1.Location = new System.Drawing.Point(0, 548);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1038, 42);
            this.xPanel1.TabIndex = 0;
            // 
            // btnInsert
            // 
            this.btnInsert.ImageIndex = 4;
            this.btnInsert.ImageList = this.ImageList;
            this.btnInsert.Location = new System.Drawing.Point(87, 7);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(102, 28);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "直接入力";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 3;
            this.btnDelete.ImageList = this.ImageList;
            this.btnDelete.Location = new System.Drawing.Point(8, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 28);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "削除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(791, 4);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel2.Controls.Add(this.btnUnselectAll);
            this.xPanel2.Controls.Add(this.btnSelectAll);
            this.xPanel2.Controls.Add(this.dtpPlan_date);
            this.xPanel2.Controls.Add(this.dbxPlan_usnm);
            this.xPanel2.Controls.Add(this.xFlatLabel2);
            this.xPanel2.Controls.Add(this.xFlatLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel2.Location = new System.Drawing.Point(426, 0);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(612, 36);
            this.xPanel2.TabIndex = 1;
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.ImageIndex = 1;
            this.btnUnselectAll.ImageList = this.ImageList;
            this.btnUnselectAll.Location = new System.Drawing.Point(31, 5);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(26, 23);
            this.btnUnselectAll.TabIndex = 27;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.ImageIndex = 2;
            this.btnSelectAll.ImageList = this.ImageList;
            this.btnSelectAll.Location = new System.Drawing.Point(5, 5);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(26, 23);
            this.btnSelectAll.TabIndex = 26;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // dtpPlan_date
            // 
            this.dtpPlan_date.IsJapanYearType = true;
            this.dtpPlan_date.Location = new System.Drawing.Point(494, 7);
            this.dtpPlan_date.Name = "dtpPlan_date";
            this.dtpPlan_date.Size = new System.Drawing.Size(110, 20);
            this.dtpPlan_date.TabIndex = 6;
            // 
            // dbxPlan_usnm
            // 
            this.dbxPlan_usnm.EdgeRounding = false;
            this.dbxPlan_usnm.Location = new System.Drawing.Point(314, 6);
            this.dbxPlan_usnm.Name = "dbxPlan_usnm";
            this.dbxPlan_usnm.Size = new System.Drawing.Size(116, 20);
            this.dbxPlan_usnm.TabIndex = 3;
            // 
            // xFlatLabel2
            // 
            this.xFlatLabel2.Location = new System.Drawing.Point(444, 6);
            this.xFlatLabel2.Name = "xFlatLabel2";
            this.xFlatLabel2.Size = new System.Drawing.Size(72, 22);
            this.xFlatLabel2.TabIndex = 1;
            this.xFlatLabel2.Text = "作成日";
            // 
            // xFlatLabel1
            // 
            this.xFlatLabel1.Location = new System.Drawing.Point(262, 6);
            this.xFlatLabel1.Name = "xFlatLabel1";
            this.xFlatLabel1.Size = new System.Drawing.Size(88, 20);
            this.xFlatLabel1.TabIndex = 0;
            this.xFlatLabel1.Text = "作成者";
            // 
            // tvwNUR4003
            // 
            this.tvwNUR4003.CheckBoxes = true;
            this.tvwNUR4003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNUR4003.Font = new System.Drawing.Font("MS UI Gothic", 10F);
            this.tvwNUR4003.HideSelection = false;
            this.tvwNUR4003.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwNUR4003.ItemHeight = 18;
            this.tvwNUR4003.LabelEdit = true;
            this.tvwNUR4003.Location = new System.Drawing.Point(426, 36);
            this.tvwNUR4003.Name = "tvwNUR4003";
            this.tvwNUR4003.Size = new System.Drawing.Size(612, 512);
            this.tvwNUR4003.TabIndex = 3;
            this.tvwNUR4003.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
            this.tvwNUR4003.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwNUR4003_AfterLabelEdit);
            this.tvwNUR4003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvwNUR4003_MouseDown);
            this.tvwNUR4003.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwNUR4003_BeforeLabelEdit);
            this.tvwNUR4003.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
            this.tvwNUR4003.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwNUR4003_KeyDown);
            // 
            // grdNUR4002
            // 
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
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13});
            this.grdNUR4002.ColPerLine = 2;
            this.grdNUR4002.Cols = 3;
            this.grdNUR4002.ControlBinding = true;
            this.grdNUR4002.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdNUR4002.FixedCols = 1;
            this.grdNUR4002.FixedRows = 1;
            this.grdNUR4002.FocusColumnName = "nur_plan_proname";
            this.grdNUR4002.HeaderHeights.Add(26);
            this.grdNUR4002.Location = new System.Drawing.Point(0, 0);
            this.grdNUR4002.Name = "grdNUR4002";
            this.grdNUR4002.QuerySQL = resources.GetString("grdNUR4002.QuerySQL");
            this.grdNUR4002.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR4002.RowHeaderVisible = true;
            this.grdNUR4002.Rows = 2;
            this.grdNUR4002.Size = new System.Drawing.Size(426, 548);
            this.grdNUR4002.TabIndex = 4;
            this.grdNUR4002.ToolTipActive = true;
            this.grdNUR4002.UseDefaultTransaction = false;
            this.grdNUR4002.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR4002_QueryEnd);
            this.grdNUR4002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4002_QueryStarting);
            this.grdNUR4002.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR4002_GridColumnProtectModify);
            this.grdNUR4002.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR4002_GridCellPainting);
            this.grdNUR4002.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR4002_RowFocusChanged);
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
            this.xEditGridCell6.CellLen = 200;
            this.xEditGridCell6.CellName = "nur_plan_proname";
            this.xEditGridCell6.CellWidth = 349;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderImage = ((System.Drawing.Image)(resources.GetObject("xEditGridCell6.HeaderImage")));
            this.xEditGridCell6.HeaderText = "問題リスト";
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
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
            this.xEditGridCell8.BindControl = this.dbxPlan_usnm;
            this.xEditGridCell8.CellName = "plan_usnm";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "plan_usnm";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.BindControl = this.dtpPlan_date;
            this.xEditGridCell9.CellName = "plan_date";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "plan_date";
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ApplyPaintingEvent = true;
            this.xEditGridCell10.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell10.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell10.CellName = "vald";
            this.xEditGridCell10.CellWidth = 32;
            this.xEditGridCell10.CheckedValue = "N";
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell10.HeaderText = "終了";
            this.xEditGridCell10.UnCheckedValue = "Y";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "modify_yn";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "modify_yn";
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "nur0402_valid";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "nur0402_valid";
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "sort_key";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "sort_key";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // dloPlanInfo
            // 
            this.dloPlanInfo.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem23,
            this.multiLayoutItem24});
            this.dloPlanInfo.QuerySQL = resources.GetString("dloPlanInfo.QuerySQL");
            this.dloPlanInfo.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dloPlanInfo_QueryStarting);
            this.dloPlanInfo.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dloPlanInfo_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "fknur4002";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "pknur4003";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "nur_plan_ote";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "nur_plan";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "nur_plan_name";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nur4003_vald";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "pknur4004";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "nur_plan_detail";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "nur_plan_dename";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "nur4004_vald";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "nur_plan_name_1";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "nur4003_sort";
            this.multiLayoutItem23.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "nur4004_sort";
            this.multiLayoutItem24.DataType = IHIS.Framework.DataType.Number;
            // 
            // dloDetailData
            // 
            this.dloDetailData.CallerID = '2';
            this.dloDetailData.UseDefaultTransaction = false;
            // 
            // layNUR4002DelCheck
            // 
            this.layNUR4002DelCheck.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layNUR4002DelCheck.QuerySQL = "SELECT \'Y\'\r\n  FROM DUAL\r\n WHERE EXISTS (SELECT \'X\'\r\n                 FROM NUR4005" +
                "\r\n                WHERE HOSP_CODE = :f_hosp_code\r\n                  AND FKNUR400" +
                "2 = :f_pknur4002)";
            this.layNUR4002DelCheck.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNUR4002DelCheck_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "del_chk";
            // 
            // layDeleteNUR4004
            // 
            this.layDeleteNUR4004.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem12});
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "pknur4003";
            // 
            // NUR4002U01
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.tvwNUR4003);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.grdNUR4002);
            this.Controls.Add(this.xPanel1);
            this.Name = "NUR4002U01";
            this.Size = new System.Drawing.Size(1038, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4002U01_ScreenOpen);
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloPlanInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dloDetailData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layDeleteNUR4004)).EndInit();
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

			this.CurrMSLayout = grdNUR4002;
			this.CurrMQLayout = grdNUR4002;

			// Clone처리시 메모리주소 변경된다는 거 생각해야 한다.
			// IsUpdItem값은 못가져옴
			dloDetailData = dloPlanInfo.Clone();	
			foreach(MultiLayoutItem item in dloDetailData.LayoutItems)
				item.IsUpdItem = true;
            
			dloDetailData.CallerID = '2';
            dloDetailData.UseDefaultTransaction = false;
            this.grdNUR4002.SavePerformer = new XSavePerformer(this);
            this.dloDetailData.SavePerformer = this.grdNUR4002.SavePerformer;

            //Load 해당환자 간호계획정보
            this.grdNUR4002.QueryLayout(true);

            if (mPknur4002 == 0)
            {
                // 간호계획작성시에는 Insert

                bool checkExists = false;
                for (int i = 0; i < grdNUR4002.RowCount; i++)
                {
                    if (grdNUR4002.GetItemString(i, "nur_plan_jin") == mNur_plan_jin && grdNUR4002.GetItemString(i, "nur_plan_pro") == mNur_plan_pro)
                    {
                        grdNUR4002.SetFocusToItem(i, 0);
                        checkExists = true;
                        break;
                    }
                }

                if (checkExists) return;

                int insertRow = grdNUR4002.InsertRow(-1);
                grdNUR4002.SetItemValue(insertRow, "pknur4002", 0);
                grdNUR4002.SetItemValue(insertRow, "bunho", mBunho);
                grdNUR4002.SetItemValue(insertRow, "fkinp1001", mFkinp1001);
                grdNUR4002.SetItemValue(insertRow, "nur_plan_jin", mNur_plan_jin);
                grdNUR4002.SetItemValue(insertRow, "nur_plan_pro", mNur_plan_pro);

                string nur_plan_proname = GetCodeName(mNur_plan_jin, mNur_plan_pro);

                grdNUR4002.SetItemValue(insertRow, "nur_plan_proname", nur_plan_proname);
                grdNUR4002.SetItemValue(insertRow, "plan_user", UserInfo.UserID);
                grdNUR4002.SetItemValue(insertRow, "plan_usnm", UserInfo.UserName);
                this.dbxPlan_usnm.SetDataValue(UserInfo.UserName);
                grdNUR4002.SetItemValue(insertRow, "plan_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                this.dtpPlan_date.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                grdNUR4002.SetItemValue(insertRow, "vald", "Y");

                grdNUR4002.SetItemValue(insertRow, "nur0402_valid", "Y");

                grdNUR4002.AcceptData();

                this.dloPlanInfo.QueryLayout(true);
            }
            else
            {
                // 해당 간호계획이 있는 경우에는 Focus변경

                for (int i = 0; i < grdNUR4002.RowCount; i++)
                {
                    if (grdNUR4002.GetItemInt(i, "pknur4002") == mPknur4002)
                    {
                        grdNUR4002.SetFocusToItem(i, 0);
                        break;
                    }
                }
            }
		}

		private void NUR4002U01_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
			// Call된 경우
			if ( this.OpenParam != null ) 
			{
				try
				{
					if(OpenParam.Contains("bunho"))
					{
						if(TypeCheck.IsNull(OpenParam["bunho"].ToString()))
						{
							mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
							return;
						}
						else
							mBunho = OpenParam["bunho"].ToString().Trim();
							
					}
					else
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);	
						return;
					}

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

					if(OpenParam.Contains("nur_plan_jin"))
					{
						if(TypeCheck.IsNull(OpenParam["nur_plan_jin"].ToString()))
						{
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "診断情報が有効ではありません。ご確認ください。" : "간호진단정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
							return;
						}
						else
						{
							mNur_plan_jin = OpenParam["nur_plan_jin"].ToString();
						}
					}
					else
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "診断情報が有効ではありません。ご確認ください。" : "간호진단정보가 정확하지않습니다. 확인바랍니다.";
						mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
						XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);	
						return;
					}

					if(OpenParam.Contains("nur_plan_pro"))
					{
						if(TypeCheck.IsNull(OpenParam["nur_plan_pro"].ToString()))
						{
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "問題リスト情報が有効ではありません。ご確認ください。" : "문제리스트정보가 정확하지않습니다. 확인바랍니다.";
							mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
							XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
							return;
						}
						else
							mNur_plan_pro = OpenParam["nur_plan_pro"].ToString();
					}
					else
					{
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "問題リスト情報が有効ではありません。ご確認ください。" : "문제리스트정보가 정확하지않습니다. 확인바랍니다.";
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
                //mBunho = "00026351";				
                //mFkinp1001 = 38084;
                //mPknur4002 = 11;
                //mNur_plan_jin = "01";
                //mNur_plan_pro = "01";				
			}	

			//NUR4002존재여부확인
			if(mPknur4002 == 0)
				mPknur4002 = this.CheckPKNUR4002(mFkinp1001, mNur_plan_jin, mNur_plan_pro);
		
		}

		#endregion

		#region [TreeView Info]
        
		#region [해당환자의 간호계획내역]
        
		private void ShowOCS4002()
		{
            this.tvwNUR4003.BeforeSelect -= new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
            this.tvwNUR4003.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
			tvwNUR4003.Nodes.Clear();
			if(dloPlanInfo.RowCount < 1) return;
            
			//Node 단계 check변수
			string nur_plan_ote = "";
			string nur_plan     = "";
            TreeNode node;
            bool parentCheck = false;

			foreach(DataRow row in dloPlanInfo.LayoutTable.Rows)
			{				
				if(nur_plan_ote != row["nur_plan_ote"].ToString())
                {
					if( row["nur_plan_ote"].ToString() == "P" )
						node = new TreeNode( "P - 目標");
					else if( row["nur_plan_ote"].ToString() == "O" )
						node = new TreeNode( "O - 観察" );
					else if( row["nur_plan_ote"].ToString() == "T" )
						node = new TreeNode( "T - ケア" );
					else
						node = new TreeNode( "E - 指導" );

                    //node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "GP" );
                    t_tag_table.Add("nur_plan_ote", row["nur_plan_ote"].ToString());
                    t_tag_table.Add("fknur4002", row["fknur4002"].ToString());

                    node.Tag = t_tag_table;

                    node.SelectedImageIndex = 0;
					node.ImageIndex = 0;

					tvwNUR4003.Nodes.Add(node);
					nur_plan_ote = row["nur_plan_ote"].ToString();
					nur_plan     = "";
				}

				if(nur_plan != row["nur_plan"].ToString())
				{					
					node = new TreeNode( row["nur_plan_name"].ToString() );

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "P");
                    t_tag_table.Add("nur_plan_ote", nur_plan_ote);
                    t_tag_table.Add("nur_plan", row["nur_plan"].ToString());
                    t_tag_table.Add("pknur4003", row["pknur4003"].ToString());
                    t_tag_table.Add("fknur4002", row["fknur4002"].ToString());

                    node.Tag = t_tag_table;

                    if (row["nur4003_vald"].ToString() == "Y")
                    {
                        node.Checked = true;
                        parentCheck = true;
                    }
                    else
                    {
                        node.Checked = false;
                        parentCheck = false;
                    }

                    //node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count -1].Nodes.Add(node);
                    if(parentCheck)
                        node.Parent.Checked = true;

					nur_plan = row["nur_plan"].ToString();
				}

				
				if(row["nur_plan_detail"].ToString().Trim() != "X")
				{
					node = new TreeNode( row["nur_plan_dename"].ToString() );

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

					if(row["nur4004_vald"].ToString() == "Y")
                        node.Checked = true;
					else
                        node.Checked = false;

                    //node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
					tvwNUR4003.Nodes[tvwNUR4003.Nodes.Count -1].LastNode.Nodes.Add(node);
				}				
			}

            tvwNUR4003.ExpandAll();
            this.tvwNUR4003.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
            this.tvwNUR4003.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
		}

		#endregion
        
		/// <summary>
		/// Label Edit 설정 (사용안함)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwNUR4003_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{			
			if(e.Node.Parent == null) 
				tvwNUR4003.LabelEdit = false;
			else
				tvwNUR4003.LabelEdit = true;
		}
        
		/// <summary>
		/// 선택된 항목에 대해서 ImageIndex를 변경시켜 선택여부를 설정한다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tvwNUR4003_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            if (tvwNUR4003.GetNodeAt(new Point(e.X, e.Y)) == null) 
                return;
            
            tvwNUR4003.SelectedNode = tvwNUR4003.GetNodeAt(new Point(e.X, e.Y));

            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                Hashtable t_tag = (Hashtable)tvwNUR4003.SelectedNode.Tag;
                string tag_gubun = t_tag["tag_gubun"].ToString();

                //PopUp Menu생성
                CreatePopUpMenu(tag_gubun);

                //PopUp Menu Show
                popMenu.TrackPopup(tvwNUR4003.PointToScreen(new Point(e.X, e.Y)));
            }            

            if (this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") != "Y")
                return;

            //if(tvwNUR4003.GetNodeAt(new Point(e.X, e.Y)) == null || tvwNUR4003.GetNodeAt(new Point(e.X, e.Y)).Parent == null) 
            //{
            //    tvwNUR4003.LabelEdit = false;
            //    return;
            //}

            //if(e.Button == MouseButtons.Left && e.Clicks == 2)
            //{
            //    tvwNUR4003.LabelEdit = true;
            //    tvwNUR4003.SelectedNode = tvwNUR4003.GetNodeAt(new Point(e.X, e.Y));
            //    //Begin Edit상태로....				
            //    PostCallHelper.PostCall(new PostMethod(PostBeginEdit));
            //}
			
		}

		private void PostBeginEdit()
		{
			tvwNUR4003.SelectedNode.BeginEdit();
		}
		
		#endregion

		#region [grdNUR4002 Event]
	    
		private void grdNUR4002_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if(e.PreviousRow >= 0)
			{
				//이전 Data를 적용한다.
				int pknur4002 = grdNUR4002.GetItemInt(e.PreviousRow, "pknur4002");
				//mPknur4002 = grdNUR4002.GetItemInt(e.PreviousRow, "pknur4002");
				ApplyDataildata(pknur4002);
			}

            if (e.CurrentRow >= 0)
            {
                if (grdNUR4002.GetItemString(e.CurrentRow, "pknur4002") != "")
                    this.dloPlanInfo.QueryLayout(true);
            }

		}

		#endregion

		#region [DataService Event]

        private void grdNUR4002_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //직접입력 이미지 표시
            DisplayDirectImage(this.grdNUR4002);
        }

        private void dloPlanInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {  
            string pknur4002 = grdNUR4002.GetItemString(grdNUR4002.CurrentRowNumber, "pknur4002");

            if (pknur4002 == "") return;
            //편집중인 Data를 적용한다.
            foreach (DataRow row in this.dloDetailData.LayoutTable.Select(" fknur4002 = " + pknur4002 + " ", ""))
            {
                for (int i = 0; i < this.dloPlanInfo.RowCount; i++)
                {
                    if (dloPlanInfo.GetItemString(i, "nur_plan") == row["nur_plan"].ToString()
                        && dloPlanInfo.GetItemString(i, "nur_plan_detail") == row["nur_plan_detail"].ToString())
                    {
                        if (dloPlanInfo.GetItemString(i, "nur_plan_name") != row["nur_plan_name"].ToString())
                            dloPlanInfo.SetItemValue(i, "nur_plan_name", row["nur_plan_name"]);

                        if (dloPlanInfo.GetItemString(i, "nur4003_vald") != row["nur4003_vald"].ToString())
                            dloPlanInfo.SetItemValue(i, "nur4003_vald", row["nur4003_vald"]);

                        if (dloPlanInfo.GetItemString(i, "nur_plan_dename") != row["nur_plan_dename"].ToString())
                            dloPlanInfo.SetItemValue(i, "nur_plan_dename", row["nur_plan_dename"]);

                        if (dloPlanInfo.GetItemString(i, "nur4004_vald") != row["nur4004_vald"].ToString())
                            dloPlanInfo.SetItemValue(i, "nur4004_vald", row["nur4004_vald"]);
                    }
                }
            }

            //적용된 Data삭제
            for (int i = 0; i < this.dloDetailData.RowCount; i++)
            {
                if (dloDetailData.LayoutTable.Rows[i]["fknur4002"].ToString() == pknur4002)
                {
                    dloDetailData.LayoutTable.Rows.Remove(dloDetailData.LayoutTable.Rows[i]);
                    i--;
                }
            }

            this.ShowOCS4002();

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
            int    fknur4002 = 0;
            int    pknur4003 = 0;
			string nur_plan_ote    = "";
			string nur_plan        = "";
			string nur4003_vald    = "";
			int    nur4003_sort;
			int    pknur4004       = 0;			
			string nur_plan_detail = "";
			string nur4004_vald    = "";
			int    nur4004_sort;
            Hashtable t_tag;
			
			foreach(TreeNode node_ote in this.tvwNUR4003.Nodes)
			{
                t_tag = (Hashtable)node_ote.Tag;

				nur4003_sort = 0;

				foreach(TreeNode node_nur4003 in node_ote.Nodes)
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

					if(pknur4003 == 0 && nur4003_vald == "N") continue;

                    if (added_yn_4003 == "N")
                    {
                        DataRow[] t_rows = dloPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' ", "");

                        if (t_rows.Length > 0)
                        {
                            //int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount - 1);
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

                        //foreach (DataRow row_nur4003 in dloPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' ", ""))
                        //{
                        //    //Origin data와 비교해서 변경시 Origin data변경

                        //    if (row_nur4003["nur_plan_name"].ToString() != node_nur4003.Text)
                        //        row_nur4003["nur_plan_name"] = node_nur4003.Text;

                        //    if (row_nur4003["nur4003_vald"].ToString() != nur4003_vald)
                        //        row_nur4003["nur4003_vald"] = nur4003_vald;

                        //    row_nur4003["nur4003_sort"] = nur4003_sort;

                        //    row_nur4003["fknur4002"] = aPknur4002;

                        //    // 이거 안넣어주면 저장할때 nur4004까지 만들어 버림
                        //    row_nur4003["pknur4004"] = "";
                        //    row_nur4003["nur_plan_detail"] = "";

                        //    dloDetailData.LayoutTable.ImportRow(row_nur4003);
                        //}
                    }
                    else //추가항목인경우
                    {
                        //int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount - 1);
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
					if(node_nur4003.Nodes.Count > 0)
					{
						nur4004_sort = 0;

						foreach(TreeNode node_nur4004 in node_nur4003.Nodes)
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
                            							
							if(pknur4004 == 0 && nur4004_vald == "N") continue;

                            if (added_yn_4004 == "N")
                            {
                                foreach (DataRow row_nur4004 in dloPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' and nur_plan_detail = '" + nur_plan_detail + "' ", ""))
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
                                //int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount - 1);
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
					else
                    {
                        //if (added_yn_4003 == "N")
                        //{
                        //    foreach (DataRow row_nur4003 in dloPlanInfo.LayoutTable.Select(" nur_plan = '" + nur_plan + "' ", ""))
                        //    {
                        //        //Origin data와 비교해서 변경시 Origin data변경

                        //        if (row_nur4003["nur_plan_name"].ToString() != node_nur4003.Text)
                        //            row_nur4003["nur_plan_name"] = node_nur4003.Text;

                        //        if (row_nur4003["nur4003_vald"].ToString() != nur4003_vald)
                        //            row_nur4003["nur4003_vald"] = nur4003_vald;

                        //        row_nur4003["nur4003_sort"] = nur4003_sort;

                        //        row_nur4003["fknur4002"] = aPknur4002;

                        //        dloDetailData.LayoutTable.ImportRow(row_nur4003);
                        //    }
                        //}
                        //else //추가항목인경우
                        //{
                        //    int insertedRowNum = dloDetailData.InsertRow(dloDetailData.RowCount - 1);

                        //    dloDetailData.SetItemValue(insertedRowNum, "pknur4003", pknur4003);
                        //    dloDetailData.SetItemValue(insertedRowNum, "fknur4002", fknur4002);
                        //    dloDetailData.SetItemValue(insertedRowNum, "nur_plan", nur_plan);
                        //    dloDetailData.SetItemValue(insertedRowNum, "nur_plan_ote", nur_plan_ote);
                        //    dloDetailData.SetItemValue(insertedRowNum, "nur_plan_name", node_nur4003.Text);
                        //    dloDetailData.SetItemValue(insertedRowNum, "nur4003_sort", nur4003_sort);
                        //    dloDetailData.SetItemValue(insertedRowNum, "nur4003_vald", nur4003_vald);                 
                        //}
					}
				}
			}
		}

		#endregion

		#region [CheckExistsNUR4002]
        
		/// <summary>
		/// 간호계획이 이미 등록되어 있는지 여부 check시 해당 key return
		/// </summary>
		private int CheckPKNUR4002(int aFkinp1001, string aNur_plan_jin, string aNur_plan_pro)
		{
			int pknur4002 = 0;
			      
			mVsdCommon.Reset();
			mVsdCommon.QuerySQL = "" 
                + "SELECT NVL(A.PKNUR4002, 0) PKNUR4002 "				                           
				+ "  FROM NUR4002 A  " 
				+ " WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + "'"
                + "   AND A.FKINP1001    =  " + aFkinp1001.ToString() 
				+ "   AND A.NUR_PLAN_JIN = '" + aNur_plan_jin + "' " 
				+ "   AND A.NUR_PLAN_PRO = '" + aNur_plan_pro + "' "
				+ "   AND A.VALD         = '" + "Y"           + "' "
				+ "   AND ROWNUM            = 1                    ";
					
			mVsdCommon.LayoutItems.Clear();
            mVsdCommon.LayoutItems.Add("pknur4002");

            pknur4002 = 0;
            if (mVsdCommon.QueryLayout())
            {
                if (!TypeCheck.IsNull(mVsdCommon.GetItemValue("pknur4002")))
                    pknur4002 = int.Parse(mVsdCommon.GetItemValue("pknur4002").ToString());
            }
            
			return pknur4002;
			
		}

		#endregion

		#region [Get nur_plan_pro Name]
        
		/// <summary>
		/// 해당 코드에 대한 명을 가져옵니다.
		/// </summary>
		private string GetCodeName(string aNur_plan_jin, string aNur_plan_pro)
		{
			string codeName = "";
			        
			mVsdCommon.Reset();
			mVsdCommon.QuerySQL = "SELECT A.NUR_PLAN_PRONAME "   
				+ "  FROM NUR0402 A "
                + " WHERE A.HOSP_CODE    = '" + EnvironInfo.HospCode + "'"
                + "   AND A.NUR_PLAN_JIN = '" + aNur_plan_jin + "' " 
				+ "   AND A.NUR_PLAN_PRO = '" + aNur_plan_pro + "' ";
					
			mVsdCommon.LayoutItems.Clear();
            mVsdCommon.LayoutItems.Add("nur_plan_proname");
            
            codeName = "";
            if (mVsdCommon.QueryLayout())
            {
                if (!TypeCheck.IsNull(mVsdCommon.GetItemValue("nur_plan_proname")))
                    codeName = mVsdCommon.GetItemValue("nur_plan_proname").ToString();
            } 

			return codeName;
		}

		#endregion

		#region [Button List Event]

		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					
					e.IsBaseCall = false;

					dloDetailData.Reset();
                    
					this.grdNUR4002.QueryLayout(true);
					
					break;

				case FunctionType.Update:
                    
					//화면에서 수정중인 Data적용
					if(grdNUR4002.CurrentRowNumber >= 0 && this.del_flag.ToString() != "D")
					{
						int pknur4002 = grdNUR4002.GetItemInt(grdNUR4002.CurrentRowNumber, "pknur4002");
						ApplyDataildata(pknur4002);
					}

                    try
                    {
                        Service.BeginTransaction();

                        t_pknur4002 = "";
                        t_nur_plan = "";
                        t_pknur4003 = "";

                        if (!this.grdNUR4002.SaveLayout())
                            throw new Exception();

                        if (!this.dloDetailData.SaveLayout())
                            throw new Exception();

                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存が完了しました。" : "저장이 완료되었습니다.";
                        dloDetailData.Reset();
                        SetMsg(mbxMsg);

                        Service.CommitTransaction();
                        this.Close();
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "保存に失敗しました。" : "저장이 실패하였습니다.";
                        mbxMsg = mbxMsg + Service.ErrFullMsg;
                        mbxCap = NetInfo.Language == LangMode.Jr ? "保存失敗" : "Error";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
                        dloDetailData.Reset();
                    }

					break;
				
				default:

					break;
			}	
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
						: "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		#region NUR4002정보를 삭제한다.
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.del_flag = "";
			/* 삭제 가능 여부를 체크한다. */
            //if (this.layNUR4002DelCheck.QueryLayout())
            //{
            //    if (this.layNUR4002DelCheck.GetItemValue("del_chk").ToString() == "Y")
            //    {
            //        XMessageBox.Show("該当項目の評価情報があるので削除できません。", "注意", MessageBoxIcon.Warning);
            //        return;
            //    }
            //}
            if (!IsCanModify())
            {
                XMessageBox.Show("該当項目の評価情報があるので削除できません。", "注意", MessageBoxIcon.Warning);
                return;
            }

            if (this.grdNUR4002.RowCount > 0)
            {
                if (this.grdNUR4002.CurrentRowNumber >= 0)
                {
                    DialogResult dr = XMessageBox.Show("[" + this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur_plan_proname") + "]を削除しますか？",
                                       "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dr == DialogResult.Yes)
                    {
                        this.del_flag = "D";
                        this.grdNUR4002.DeleteRow(this.grdNUR4002.CurrentRowNumber);

                        if (!this.grdNUR4002.SaveLayout())
                        {
                            XMessageBox.Show("削除に失敗しました。\r\n" + Service.ErrFullMsg, "削除失敗", MessageBoxIcon.Information);
                            return;
                        }

                        tvwNUR4003.Nodes.Clear();

                        this.dloPlanInfo.QueryLayout(true);
                    }
                }
            }            
		}
		#endregion

		#region 전체 선택을 했을 경우
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SetAllPlan(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SetAllPlan(false);
        }

		#endregion

		#region 전체 계획 조회

		private void SetAllPlan(bool isAll)
        {
            this.tvwNUR4003.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);

			foreach(TreeNode tn in this.tvwNUR4003.Nodes)
			{
				if (isAll)
                {
                    tn.Checked = true;
					foreach(TreeNode node1 in tn.Nodes)
					{
                        //node1.ImageIndex = 2;
                        //node1.SelectedImageIndex = 2;
                        node1.Checked = true;

						foreach(TreeNode node2 in node1.Nodes)
						{
                            //node2.ImageIndex = 2;
                            //node2.SelectedImageIndex = 2;
                            node2.Checked = true;
						}
					}
				}
				else
                {
                    tn.Checked = false;
					foreach(TreeNode node1 in tn.Nodes)
					{
                        //node1.ImageIndex = 1;
                        //node1.SelectedImageIndex = 1;
                        node1.Checked = false;

						foreach(TreeNode node2 in node1.Nodes)
						{
                            //node2.ImageIndex = 1;
                            //node2.SelectedImageIndex = 1;
                            node2.Checked = false;
						}
					}
				}
            }
            this.tvwNUR4003.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
		}

		#endregion

		#region 직접 입력인 경우에만 문제리스트 명칭 변경 가능

		private void grdNUR4002_GridColumnProtectModify(object sender, IHIS.Framework.GridColumnProtectModifyEventArgs e)
		{
            //if (!IsCanModify())
            //{
            //    XMessageBox.Show("該当項目の評価情報があるので修正できません。", "注意", MessageBoxIcon.Warning);
            //}

            ////if (e.DataRow["nur_plan_jin"].ToString() != "999")
            ////{
            ////    e.Protect = true;
            ////}
            ////else
            ////{
            ////    e.Protect = false;
            ////}

            //if (e.DataRow["modify_yn"].ToString() == "N")
            //{
            //    //e.Protect = true;
            //}
            //else
            //{
            //    //if (e.DataRow["nur_plan_jin"].ToString() == "999")
            //    //{
            //    //    e.Protect = false;
            //    //}
            //}
		}

        private bool IsCanModify()
        {
            /* 수정 가능 여부를 체크한다. */
            this.layNUR4002DelCheck.QueryLayout();
            
            if (this.layNUR4002DelCheck.GetItemValue("del_chk").ToString() == "Y")
            {
                //XMessageBox.Show("該当項目の評価情報があるので修正できません。", "注意", MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

		#endregion

		#region 직접입력 버튼을 클릭을 했을 경우

		private void btnInsert_Click(object sender, System.EventArgs e)
		{
			if (this.grdNUR4002.RowCount == 0) return;

            for (int i = 0; i < this.grdNUR4002.RowCount; i++ )
            {
                if (this.grdNUR4002.GetRowState(i) == DataRowState.Added)
                {
                    XMessageBox.Show("保存されていない新規看護計画があります。\r\n先に保存を行ってください。","注意", MessageBoxIcon.Warning);
                    return;
                }
            }

			int aRow = this.grdNUR4002.InsertRow(-1);

			this.grdNUR4002.SetItemValue(aRow, "pknur4002"       , 0                                              );
			this.grdNUR4002.SetItemValue(aRow, "bunho"           , mBunho                                         );
			this.grdNUR4002.SetItemValue(aRow, "fkinp1001"       , mFkinp1001                                     );
			this.grdNUR4002.SetItemValue(aRow, "nur_plan_jin"    , "99003"                                          );
			this.grdNUR4002.SetItemValue(aRow, "nur_plan_pro"    , "99"                                           );
			this.grdNUR4002.SetItemValue(aRow, "nur_plan_proname", "□＃1　直接入力"                              );
			this.grdNUR4002.SetItemValue(aRow, "plan_user"       , UserInfo.UserID.ToString()                     );
			this.grdNUR4002.SetItemValue(aRow, "plan_usnm"       , UserInfo.UserName.ToString()                   );
			this.grdNUR4002.SetItemValue(aRow, "plan_date"       , EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
			this.grdNUR4002.SetItemValue(aRow, "vald"            , "Y"                                            );
			this.grdNUR4002.SetItemValue(aRow, "nur0402_valid"   , "Y"                                            );
            

			this.grdNUR4002.AcceptData();
            this.dloPlanInfo.QueryLayout(true);

			//직접입력 이미지 표시
			DisplayDirectImage(this.grdNUR4002);
		}

		#endregion

		#region 직접입력환자 이미지 표시
		private void DisplayDirectImage(XEditGrid aGrd)
		{
			if (aGrd == null) return;

			int imagColIndex = 0;
			
			try
			{
				//aGrd.Redraw = false; // Grid Display 멈춤

				for (int i = 0; i < aGrd.RowCount; i++)
				{					
					if (aGrd.GetItemValue(i, "nur_plan_jin").ToString().Trim() == "99003") // 직접입력환자
					{
						aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = this.ImageList.Images[5];
					}
	
					else
					{
						aGrd[i + aGrd.HeaderHeights.Count, imagColIndex].Image = null;					
					}				
				}
			}
			catch{}

			finally
			{
				//aGrd.Redraw = true; // Grid Display 
			}
		}
		#endregion

        #region LabelEdit
        //string temp_seq = "";
        private void tvwNUR4003_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            //temp_seq = "";
            //if (e.Label != "")
            //{
            //    temp_seq = e.Node.Text.Substring(0, 4);
            //    //temp_seq = e.Label.Substring(0, 4);
            //}
        }

        bool editFlag = true;
		private void tvwNUR4003_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
            /* 원래주석*/
//			if (GetStringByte(e.Node.Text.ToString()) > 94)
//			{
//				mbxMsg = NetInfo.Language == LangMode.Jr ? "入力の長さが超過しました。" : "입력길이를 초과하였습니다.";
//				mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
//				XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Error);
//			}
            //if (!editFlag)
            //{
            //    editFlag = true;
            //    return;
            //}

            //e.Node.EndEdit(true);
            //e.Node.BeginEdit();

            //editFlag = false;
            //e.Node.Text = "    " + e.Label;
            //e.Node.EndEdit(false);

        }

        #endregion

        #region [String]
        /// <summary>
		/// string 값의 Byte를 구한다.
		/// </summary>
		public int GetStringByte(string s)
		{   
			int returnByte = 0;
 
			if(s.Length == 0)
			{
				return returnByte;
			}

			Encoding JisEncoding = Encoding.GetEncoding("Shift_JIS");		
			returnByte = JisEncoding.GetByteCount(s);
			return returnByte;
		}
		#endregion

        #region QueryStarting
        private void dloPlanInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            int rowNum = this.grdNUR4002.CurrentRowNumber;

            this.dloPlanInfo.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.dloPlanInfo.SetBindVarValue("f_pknur4002", this.grdNUR4002.GetItemString(rowNum, "pknur4002"));
            this.dloPlanInfo.SetBindVarValue("f_nur_plan_jin", this.grdNUR4002.GetItemString(rowNum, "nur_plan_jin"));
            this.dloPlanInfo.SetBindVarValue("f_nur_plan_pro", this.grdNUR4002.GetItemString(rowNum, "nur_plan_pro"));
        }

        private void layNUR4002DelCheck_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNUR4002DelCheck.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNUR4002DelCheck.SetBindVarValue("f_pknur4002", this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "pknur4002"));

        }

        private void grdNUR4002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR4002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR4002.SetBindVarValue("f_fkinp1001", mFkinp1001.ToString());

        }
        #endregion

        #region grdNUR4002_GridCellPainting
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
        #endregion


        #region [PopUp Menu]
        IHIS.X.Magic.Menus.PopupMenu popMenu = new IHIS.X.Magic.Menus.PopupMenu();

        private void CreatePopUpMenu(string tag_gubun)
        {
            //Item Clear
            popMenu.MenuCommands.Clear();

            //PopupMenu 
            IHIS.X.Magic.Menus.MenuCommand menuCmd = null;

            menuCmd = new IHIS.X.Magic.Menus.MenuCommand("コピー", this.ImageList.Images[6], new EventHandler(OnPopMenuClick));
            menuCmd.Tag = "COPY";
            popMenu.MenuCommands.Add(menuCmd);
            

            if (tag_gubun != "C" && 
                this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "nur0402_valid") == "Y" &&
                this.grdNUR4002.GetItemString(this.grdNUR4002.CurrentRowNumber, "vald") == "Y") 
            {
                menuCmd = new IHIS.X.Magic.Menus.MenuCommand("項目追加", this.ImageList.Images[7], new EventHandler(OnPopMenuClick));
                menuCmd.Tag = "ADD";
                popMenu.MenuCommands.Add(menuCmd);
            }
        }

        private void OnPopMenuClick(object sender, EventArgs e)
        {
            string menuItemIndex = ((IHIS.X.Magic.Menus.MenuCommand)sender).Tag.ToString();

            switch (menuItemIndex)
            {   case "COPY":

                    Clipboard.SetDataObject(this.tvwNUR4003.SelectedNode.Text, true);

                    break;

                case "ADD":

                    Hashtable selectedNodeTag = (Hashtable)this.tvwNUR4003.SelectedNode.Tag;
                    Hashtable newNodeTag = new Hashtable();

                    if(selectedNodeTag["tag_gubun"].ToString() == "GP")
                    {
                        newNodeTag.Add("added_yn", "Y");
                        newNodeTag.Add("tag_gubun", "P");
                        newNodeTag.Add("fknur4002", selectedNodeTag["fknur4002"].ToString());
                        newNodeTag.Add("pknur4003", 0);
                        newNodeTag.Add("nur_plan_ote", selectedNodeTag["nur_plan_ote"].ToString());
                        newNodeTag.Add("nur_plan", "9999");
                    }
                    else if(selectedNodeTag["tag_gubun"].ToString() == "P")
                    {
                        newNodeTag.Add("added_yn", "Y");
                        newNodeTag.Add("tag_gubun", "C");
                        newNodeTag.Add("fknur4002", selectedNodeTag["fknur4002"].ToString());
                        newNodeTag.Add("pknur4003", selectedNodeTag["pknur4003"].ToString());
                        newNodeTag.Add("pknur4004", 0);
                        newNodeTag.Add("nur_plan_ote", selectedNodeTag["nur_plan_ote"].ToString());
                        newNodeTag.Add("nur_plan", selectedNodeTag["nur_plan"].ToString());
                        newNodeTag.Add("nur_plan_detail", "XX");
                    }

                    TreeNode node = new TreeNode("内容を入力してください。");
                    node.Tag = newNodeTag;

                    node.Checked = true;

                    this.tvwNUR4003.SelectedNode.Nodes.Add(node);
                    this.tvwNUR4003.SelectedNode = node;

                    //Begin Edit상태로....				
                    //PostCallHelper.PostCall(new PostMethod(PostBeginEdit));

                    break;

                default:

                    break;
            }
        }

        #endregion

        #region XSavePerformer
        string t_pknur4002 = "";
        string t_nur_plan = "";
        string t_pknur4003 = "";
        private class XSavePerformer : ISavePerformer
        {
            NUR4002U01 parent;

            public XSavePerformer(NUR4002U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch(callerID)
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

                            cmdText = @"UPDATE NUR4002
		                                   SET UPD_DATE          = SYSDATE
                                             , UPD_ID            = :q_user_id
                                             --, PLAN_DATE         = :f_plan_date
		                                     , NUR_PLAN_PRO_NAME = :f_nur_plan_proname
		                                     , VALD              = NVL(:f_vald, 'N')
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
                            
//                            cmdText = @"UPDATE NUR4002
//                                           SET UPD_ID        = :q_user_id      ,
//                                               UPD_DATE      = SYSDATE         ,
//                                               VALD          = 'N'
//                                         WHERE HOSP_CODE     = :f_hosp_code 
//                                           AND PKNUR4002     = :f_pknur4002";

                            cmdText = @"DELETE FROM NUR4002                                           
		                                 WHERE HOSP_CODE = :f_hosp_code 
                                           AND PKNUR4002 = :f_pknur4002";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }
                            }

                            cmdText = "";
//                            cmdText = @"UPDATE NUR4003
//                                           SET UPD_ID    = :q_user_id,
//                                               UPD_DATE  = SYSDATE,
//                                               VALD      = 'N'
//                                         WHERE HOSP_CODE = :f_hosp_code 
//                                           AND FKNUR4002 = :f_pknur4002";

                            cmdText = @"DELETE FROM NUR4003
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

                            for (int i = 0; i < layDeleteNUR4004.RowCount ; i++)
                            {
//                                cmdText = @"UPDATE NUR4004
//                                               SET UPD_ID    = :q_user_id,
//                                                   UPD_DATE  = SYSDATE,
//                                                   VALD      = 'N'
//                                             WHERE HOSP_CODE = :f_hosp_code 
//                                               AND FKNUR4003 = :o_pknur4003";

                                cmdText = @"DELETE FROM NUR4004
                                             WHERE HOSP_CODE = :f_hosp_code 
                                               AND FKNUR4003 = :o_pknur4003";

                                bc.Clear();
                                bc.Add("f_hosp_code", item.BindVarList["f_hosp_code"].VarValue);
                                bc.Add("q_user_id",   item.BindVarList["q_user_id"].VarValue);
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
                            Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) == 0 ) //&& parent.t_nur_plan == item.BindVarList["f_nur_plan"].VarValue)
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
                                 Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) != 0 &&
                                 item.BindVarList["f_nur_plan_detail"].VarValue == "")
                        {
                            cmdText = @"UPDATE NUR4003
                                           SET UPD_ID        = :q_user_id      ,
                                               UPD_DATE      = SYSDATE         ,
                                               NUR_PLAN_NAME = :f_nur_plan_name, 
                                               VALD          = NVL(:f_nur4003_vald, 'N')
                                         WHERE HOSP_CODE     = :f_hosp_code 
                                           AND PKNUR4003     = :f_pknur4003
                                           AND VALD         != NVL(:f_nur4003_vald, 'N')";

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

                        parent.t_nur_plan = item.BindVarList["f_nur_plan"].VarValue;

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
                                               VALD            = NVL(:f_nur4004_vald,'N')
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND PKNUR4004       = :f_pknur4004
                                           AND VALD           != NVL(:f_nur4004_vald,'N')";
                            }
                        }
                        else
                        {
                            return true;
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

        private void tvwNUR4003_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvwNUR4003.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
            TreeNode node = this.tvwNUR4003.SelectedNode;

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
                    //TreeNode parentNode2 = parentNode.Parent;

                    //if (parentNode2 != null)
                    //{
                    //    parentNode.Checked = true;
                    //}
                    
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
            this.tvwNUR4003.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwNUR4003_AfterCheck);
        }

        private void tvwNUR4003_KeyDown(object sender, KeyEventArgs e)
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
        
    }
}
