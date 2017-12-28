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
	/// NUR0403U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR0403U00 : IHIS.Framework.XScreen
	{
		#region [메세지 처리 변수]

        //Message처리
        string mbxMsg = "";
        string mbxCap = "";
        string appDate = "";

        #endregion

        #region [자동 생성 코드]

        #region 컨트롤 변수
        private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XButtonList xButtonList1;
        private System.Windows.Forms.Splitter slpMid;
		private System.Windows.Forms.Splitter splitter1;
		private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XTreeView tvwNur_plan_bunryu;
		private IHIS.Framework.XTabControl tabPlan_ote;
		private IHIS.X.Magic.Controls.TabPage pageP;
		private IHIS.X.Magic.Controls.TabPage pageO;
		private IHIS.X.Magic.Controls.TabPage pageT;
		private IHIS.X.Magic.Controls.TabPage pageE;
		private IHIS.Framework.XMstGrid grdNUR0403;
		private System.Windows.Forms.Splitter splitter2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGrid grdNUR0404;
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
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
        private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XButton btnDown1;
		private IHIS.Framework.XButton btnUp1;
		private IHIS.Framework.XButton btnDown2;
		private IHIS.Framework.XButton btnUp2;
        private MultiLayout layNUR0402;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private MultiLayoutItem multiLayoutItem6;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR0403U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR0403U00));
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.slpMid = new System.Windows.Forms.Splitter();
            this.grdNUR0403 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.grdNUR0404 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.tvwNur_plan_bunryu = new IHIS.Framework.XTreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnDown2 = new IHIS.Framework.XButton();
            this.btnUp2 = new IHIS.Framework.XButton();
            this.btnDown1 = new IHIS.Framework.XButton();
            this.btnUp1 = new IHIS.Framework.XButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabPlan_ote = new IHIS.Framework.XTabControl();
            this.pageP = new IHIS.X.Magic.Controls.TabPage();
            this.pageO = new IHIS.X.Magic.Controls.TabPage();
            this.pageT = new IHIS.X.Magic.Controls.TabPage();
            this.pageE = new IHIS.X.Magic.Controls.TabPage();
            this.layNUR0402 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0403)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0404)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.tabPlan_ote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0402)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(0, 550);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(997, 40);
            this.xPanel2.TabIndex = 1;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(582, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.Size = new System.Drawing.Size(406, 34);
            this.xButtonList1.TabIndex = 0;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // slpMid
            // 
            this.slpMid.Location = new System.Drawing.Point(0, 0);
            this.slpMid.Name = "slpMid";
            this.slpMid.Size = new System.Drawing.Size(3, 550);
            this.slpMid.TabIndex = 3;
            this.slpMid.TabStop = false;
            // 
            // grdNUR0403
            // 
            this.grdNUR0403.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell18});
            this.grdNUR0403.ColPerLine = 4;
            this.grdNUR0403.Cols = 5;
            this.grdNUR0403.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdNUR0403.FixedCols = 1;
            this.grdNUR0403.FixedRows = 1;
            this.grdNUR0403.FocusColumnName = "nur_plan_name";
            this.grdNUR0403.HeaderHeights.Add(19);
            this.grdNUR0403.Location = new System.Drawing.Point(0, 24);
            this.grdNUR0403.Name = "grdNUR0403";
            this.grdNUR0403.QuerySQL = resources.GetString("grdNUR0403.QuerySQL");
            this.grdNUR0403.RowHeaderVisible = true;
            this.grdNUR0403.Rows = 2;
            this.grdNUR0403.Size = new System.Drawing.Size(644, 274);
            this.grdNUR0403.TabIndex = 1;
            this.grdNUR0403.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0403_GridColumnChanged);
            this.grdNUR0403.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR0403_RowFocusChanged);
            this.grdNUR0403.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0_SaveEnd);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "nur_plan_jin";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.HeaderText = "nur_plan_jin";
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "nur_plan_pro";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "nur_plan_pro";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell3.CellLen = 5;
            this.xEditGridCell3.CellName = "nur_plan";
            this.xEditGridCell3.CellWidth = 96;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "看護計画コード";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "from_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "from_date";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "end_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "end_date";
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell6.CellLen = 200;
            this.xEditGridCell6.CellName = "nur_plan_name";
            this.xEditGridCell6.CellWidth = 438;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "看護計画コード名";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 1;
            this.xEditGridCell7.CellName = "nur_plan_ote";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "nur_plan_ote";
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "sort_key";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 40;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "順番";
            this.xEditGridCell8.MaxinumCipher = 3;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "vald";
            this.xEditGridCell18.CellWidth = 26;
            this.xEditGridCell18.Col = 3;
            this.xEditGridCell18.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell18.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell18.HeaderText = "有効";
            // 
            // grdNUR0404
            // 
            this.grdNUR0404.CallerID = '2';
            this.grdNUR0404.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17});
            this.grdNUR0404.ColPerLine = 4;
            this.grdNUR0404.Cols = 5;
            this.grdNUR0404.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR0404.FixedCols = 1;
            this.grdNUR0404.FixedRows = 1;
            this.grdNUR0404.FocusColumnName = "nur_plan_detail";
            this.grdNUR0404.HeaderHeights.Add(21);
            this.grdNUR0404.Location = new System.Drawing.Point(0, 326);
            this.grdNUR0404.MasterLayout = this.grdNUR0403;
            this.grdNUR0404.Name = "grdNUR0404";
            this.grdNUR0404.QuerySQL = resources.GetString("grdNUR0404.QuerySQL");
            this.grdNUR0404.RowHeaderVisible = true;
            this.grdNUR0404.Rows = 2;
            this.grdNUR0404.Size = new System.Drawing.Size(644, 224);
            this.grdNUR0404.TabIndex = 4;
            this.grdNUR0404.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR0404_GridColumnChanged);
            this.grdNUR0404.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR0_SaveEnd);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "nur_plan_jin";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "nur_plan_jin";
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "nur_plan_pro";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "nur_plan_pro";
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "nur_plan";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "nur_plan";
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell12.CellLen = 2;
            this.xEditGridCell12.CellName = "nur_plan_detail";
            this.xEditGridCell12.CellWidth = 105;
            this.xEditGridCell12.Col = 1;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "看護計画小コード";
            this.xEditGridCell12.IsUpdatable = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "from_date";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "from_date";
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "end_date";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "end_date";
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell15.CellLen = 200;
            this.xEditGridCell15.CellName = "nur_plan_dename";
            this.xEditGridCell15.CellWidth = 427;
            this.xEditGridCell15.Col = 2;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "看護計画小コード名";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "sort_key";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell16.CellWidth = 40;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "順番";
            this.xEditGridCell16.MaxinumCipher = 3;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "vald";
            this.xEditGridCell17.CellWidth = 28;
            this.xEditGridCell17.Col = 3;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "有効";
            // 
            // tvwNur_plan_bunryu
            // 
            this.tvwNur_plan_bunryu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwNur_plan_bunryu.HideSelection = false;
            this.tvwNur_plan_bunryu.ImageIndex = 0;
            this.tvwNur_plan_bunryu.ImageList = this.ImageList;
            this.tvwNur_plan_bunryu.Location = new System.Drawing.Point(3, 0);
            this.tvwNur_plan_bunryu.Name = "tvwNur_plan_bunryu";
            this.tvwNur_plan_bunryu.SelectedImageIndex = 1;
            this.tvwNur_plan_bunryu.Size = new System.Drawing.Size(347, 550);
            this.tvwNur_plan_bunryu.TabIndex = 5;
            this.tvwNur_plan_bunryu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwNur_plan_bunryu_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(350, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 550);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnDown2);
            this.xPanel1.Controls.Add(this.btnUp2);
            this.xPanel1.Controls.Add(this.btnDown1);
            this.xPanel1.Controls.Add(this.btnUp1);
            this.xPanel1.Controls.Add(this.grdNUR0404);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Controls.Add(this.splitter2);
            this.xPanel1.Controls.Add(this.grdNUR0403);
            this.xPanel1.Controls.Add(this.tabPlan_ote);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.Location = new System.Drawing.Point(353, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(644, 550);
            this.xPanel1.TabIndex = 7;
            // 
            // btnDown2
            // 
            this.btnDown2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown2.Image = ((System.Drawing.Image)(resources.GetObject("btnDown2.Image")));
            this.btnDown2.Location = new System.Drawing.Point(-1, 347);
            this.btnDown2.Name = "btnDown2";
            this.btnDown2.Size = new System.Drawing.Size(27, 23);
            this.btnDown2.TabIndex = 33;
            this.btnDown2.Click += new System.EventHandler(this.btnDown2_Click);
            // 
            // btnUp2
            // 
            this.btnUp2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp2.Image = ((System.Drawing.Image)(resources.GetObject("btnUp2.Image")));
            this.btnUp2.Location = new System.Drawing.Point(-1, 325);
            this.btnUp2.Name = "btnUp2";
            this.btnUp2.Size = new System.Drawing.Size(27, 23);
            this.btnUp2.TabIndex = 32;
            this.btnUp2.Click += new System.EventHandler(this.btnUp2_Click);
            // 
            // btnDown1
            // 
            this.btnDown1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown1.Image = ((System.Drawing.Image)(resources.GetObject("btnDown1.Image")));
            this.btnDown1.Location = new System.Drawing.Point(-1, 44);
            this.btnDown1.Name = "btnDown1";
            this.btnDown1.Size = new System.Drawing.Size(27, 23);
            this.btnDown1.TabIndex = 31;
            this.btnDown1.Click += new System.EventHandler(this.btnDown1_Click);
            // 
            // btnUp1
            // 
            this.btnUp1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUp1.Image = ((System.Drawing.Image)(resources.GetObject("btnUp1.Image")));
            this.btnUp1.Location = new System.Drawing.Point(-1, 22);
            this.btnUp1.Name = "btnUp1";
            this.btnUp1.Size = new System.Drawing.Size(27, 23);
            this.btnUp1.TabIndex = 30;
            this.btnUp1.Click += new System.EventHandler(this.btnUp1_Click);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = new IHIS.Framework.XColor(System.Drawing.Color.Silver);
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.Location = new System.Drawing.Point(0, 301);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(644, 25);
            this.xLabel1.TabIndex = 3;
            this.xLabel1.Text = " 看護計画小項目";
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 298);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(644, 3);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
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
            this.tabPlan_ote.Size = new System.Drawing.Size(644, 24);
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
            this.pageP.BackColor = System.Drawing.Color.Transparent;
            this.pageP.ImageIndex = 3;
            this.pageP.ImageList = this.ImageList;
            this.pageP.Location = new System.Drawing.Point(0, 25);
            this.pageP.Name = "pageP";
            this.pageP.Size = new System.Drawing.Size(644, 0);
            this.pageP.TabIndex = 3;
            this.pageP.Tag = "P";
            this.pageP.Title = " P-目標  ";
            // 
            // pageO
            // 
            this.pageO.BackColor = System.Drawing.Color.Transparent;
            this.pageO.ImageIndex = 2;
            this.pageO.ImageList = this.ImageList;
            this.pageO.Location = new System.Drawing.Point(0, 25);
            this.pageO.Name = "pageO";
            this.pageO.Selected = false;
            this.pageO.Size = new System.Drawing.Size(644, -1);
            this.pageO.TabIndex = 4;
            this.pageO.Tag = "O";
            this.pageO.Title = " O-観察";
            // 
            // pageT
            // 
            this.pageT.BackColor = System.Drawing.Color.Transparent;
            this.pageT.ImageIndex = 2;
            this.pageT.ImageList = this.ImageList;
            this.pageT.Location = new System.Drawing.Point(0, 25);
            this.pageT.Name = "pageT";
            this.pageT.Selected = false;
            this.pageT.Size = new System.Drawing.Size(644, -1);
            this.pageT.TabIndex = 5;
            this.pageT.Tag = "T";
            this.pageT.Title = " T-ケア";
            // 
            // pageE
            // 
            this.pageE.BackColor = System.Drawing.Color.Transparent;
            this.pageE.ImageIndex = 2;
            this.pageE.ImageList = this.ImageList;
            this.pageE.Location = new System.Drawing.Point(0, 25);
            this.pageE.Name = "pageE";
            this.pageE.Selected = false;
            this.pageE.Size = new System.Drawing.Size(644, 0);
            this.pageE.TabIndex = 6;
            this.pageE.Tag = "E";
            this.pageE.Title = " E-指導 ";
            // 
            // layNUR0402
            // 
            this.layNUR0402.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6});
            this.layNUR0402.QuerySQL = resources.GetString("layNUR0402.QuerySQL");
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "nur_plan_bunryu";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "nur_plan_bunryu_name";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "nur_plan_jin";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "nur_plan_jinname";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "nur_plan_pro";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "nur_plan_proname";
            // 
            // NUR0403U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.tvwNur_plan_bunryu);
            this.Controls.Add(this.slpMid);
            this.Controls.Add(this.xPanel2);
            this.Name = "NUR0403U00";
            this.Size = new System.Drawing.Size(997, 590);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0403)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR0404)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.tabPlan_ote.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNUR0402)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion 


        #region [APL 초기설정 관련 코드]

        #region OnLoad 이벤트

        private string mHospCode = "";
        protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
            mHospCode = EnvironInfo.HospCode;
			//panel 경계부분 splitter가 있는 경우 경계부분 panel bordColor처리
			slpMid.BackColor = XColor.XDisplayBoxGradientEndColor.Color;

			PostCallHelper.PostCall(new PostMethod(PostLoad));
        }
        #endregion

        #region PostLoad 이벤트
        private void PostLoad()
		{
            // RelationKey 설정
            grdNUR0404.SetRelationKey("nur_plan_jin", "nur_plan_jin");
            grdNUR0404.SetRelationKey("nur_plan_pro", "nur_plan_pro");
            grdNUR0404.SetRelationKey("nur_plan", "nur_plan");

            this.CurrMSLayout = this.grdNUR0403;
            this.CurrMQLayout = this.grdNUR0403;
			
            // 기준일자 현재일 //적용일불용일은 결국 사용도 안되고, 날짜의 의미가 없음
			appDate = EnvironInfo.GetSysDate().ToString("yyyy/MM/dd");

            // SavePerfomer 설정
            grdNUR0403.SavePerformer = new XSavePerformer(this);
            grdNUR0404.SavePerformer = grdNUR0403.SavePerformer;

            layNUR0402.SetBindVarValue("f_hosp_code", this.mHospCode);
            layNUR0402.QueryLayout(false);

			ShowNur_plan_bunryu();
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
        /// 코드명:해당데이타 코드명
        /// 공백  :해당데이타 없음
        /// </returns>
        private string GetCodeName(string codeMode, string code)
        {
            string codeName = "";
            string cmdText = string.Empty;
            object retVal = null;
            BindVarCollection bindVals = new BindVarCollection();

            if (code.Trim() == "") return codeName;

            switch (codeMode)
            {
                case "nur_plan":
                    cmdText = @"SELECT A.NUR_PLAN_NAME
						          FROM NUR0403 A
						         WHERE A.HOSP_CODE = :f_hosp_code
                                   AND A.NUR_PLAN = :f_code";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_code", code);

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (retVal == null || retVal.ToString().Equals(""))
                        codeName = "";
                    else
                        codeName = retVal.ToString();
                    break;

                case "nur_plan_pro":
                    string nur_plan = grdNUR0404.GetItemString(grdNUR0404.CurrentRowNumber, "nur_plan");

                    cmdText = @"SELECT A.NUR_PLAN_DENAME
						          FROM NUR0404 A
						         WHERE A.HOSP_CODE       = :f_hosp_code 
						           AND A.NUR_PLAN        = :f_nur_plan 
						           AND A.NUR_PLAN_DETAIL = :f_code";

                    bindVals.Add("f_hosp_code", this.mHospCode);
                    bindVals.Add("f_nur_plan", nur_plan);
                    bindVals.Add("f_code", code);

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (retVal == null || retVal.ToString().Equals(""))
                        codeName = "";
                    else
                        codeName = retVal.ToString();
                    break;

                default:
                    break;
            }

            return codeName;
        }

        #endregion

        #region [입력/삭제/저장 처리 관련 코드]

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    if (tvwNur_plan_bunryu.SelectedNode.Nodes.Count > 0) return;

                    DataGridCell chkCell = GetEmptyNewRow(this.CurrMSLayout);

                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = -1;

                        if (this.CurrMSLayout == grdNUR0403)
                        {
                            currentRow = grdNUR0403.InsertRow();

                            grdNUR0403.SetItemValue(currentRow, "nur_plan_jin", this.tvwNur_plan_bunryu.SelectedNode.Parent.Tag.ToString());
                            grdNUR0403.SetItemValue(currentRow, "nur_plan_pro", this.tvwNur_plan_bunryu.SelectedNode.Tag.ToString());
                            grdNUR0403.SetItemValue(currentRow, "nur_plan_ote", tabPlan_ote.SelectedTab.Tag.ToString().Trim());
                            grdNUR0403.SetItemValue(currentRow, "from_date", appDate);
                            grdNUR0403.SetItemValue(currentRow, "vald", "Y");                            
                        }
                        else
                        {
                            currentRow = grdNUR0404.InsertRow();

                            grdNUR0404.SetItemValue(currentRow, "nur_plan_jin", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_jin").Trim());
                            grdNUR0404.SetItemValue(currentRow, "nur_plan_pro", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan_pro").Trim());
                            grdNUR0404.SetItemValue(currentRow, "nur_plan", grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan").Trim());
                            grdNUR0404.SetItemValue(currentRow, "from_date", appDate);
                            grdNUR0404.SetItemValue(currentRow, "vald", "Y");
                        }

                    }
                    else
                        ((XEditGrid)this.CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    break;

                case FunctionType.Delete:
                    if (this.CurrMSLayout == grdNUR0403)
                    {
                        if (grdNUR0403.CurrentRowNumber < 0) return;

                        e.IsBaseCall = false;

                        grdNUR0403.DeleteRow(grdNUR0403.CurrentRowNumber);
                    }
                    else
                    {
                        if (grdNUR0404.CurrentRowNumber < 0) return;

                        e.IsBaseCall = false;

                        grdNUR0404.DeleteRow(grdNUR0404.CurrentRowNumber);
                    }
                    break;

                case FunctionType.Update:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    e.IsBaseCall = false;

                    if (Grid_Validating())
                    {
                        grdNUR0403.SaveLayout();
                        grdNUR0404.SaveLayout();
                    }
                    break;

                default:
                    break;
            }
        }

        #endregion

        #region [간호계획분류 데이타 취득 및 설정 코드]

        /// <summary>
        /// 간호계획분류 데이타 취득 후 트리뷰에 설정한다.
        /// </summary>
        private void ShowNur_plan_bunryu()
        {
            tvwNur_plan_bunryu.Nodes.Clear();

			if(layNUR0402.RowCount < 1) return;
            
			string nur_plan_bunryu = String.Empty;
			string nur_plan_jin    = String.Empty;
			
            TreeNode node;

			foreach(DataRow row in layNUR0402.LayoutTable.Rows)
			{
				if(nur_plan_bunryu != row["nur_plan_bunryu"].ToString())
				{
					node = new TreeNode(row["nur_plan_bunryu_name"].ToString());
					node.Tag = row["nur_plan_bunryu"].ToString();
					tvwNur_plan_bunryu.Nodes.Add(node);
					nur_plan_bunryu = row["nur_plan_bunryu"].ToString();
				}

				if(nur_plan_jin != row["nur_plan_jin"].ToString())
				{
					node = new TreeNode(row["nur_plan_jinname"].ToString());
					node.Tag = row["nur_plan_jin"].ToString();
					tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].Nodes.Add(node);
					nur_plan_jin = row["nur_plan_jin"].ToString();
				}

				node = new TreeNode(row["nur_plan_proname"].ToString());
				node.Tag = row["nur_plan_pro"].ToString();
				tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].Nodes[tvwNur_plan_bunryu.Nodes[tvwNur_plan_bunryu.Nodes.Count -1].Nodes.Count -1].Nodes.Add(node);				
			}

			tvwNur_plan_bunryu.SelectedNode = tvwNur_plan_bunryu.Nodes[0].Nodes[0].Nodes[0];
        }

        #endregion

        #region [간호계획분류에 따른 문제리스트(마스터) 데이타 취득 및 설정 코드]

        /// <summary>
        /// 간호계획분류에 해당하는 문제리스트(마스터) 데이타를 취득 후 그리드에 설정한다.
        /// </summary>
		private void GetNUR0403()
		{
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                if (!TypeCheck.IsNull(tvwNur_plan_bunryu.SelectedNode))
                {
                    string nur_plan_jin = tvwNur_plan_bunryu.SelectedNode.Parent.Tag.ToString();
                    string nur_plan_pro = tvwNur_plan_bunryu.SelectedNode.Tag.ToString();

                    grdNUR0403.SetBindVarValue("f_hosp_code", this.mHospCode);
                    grdNUR0403.SetBindVarValue("f_nur_plan_jin", nur_plan_jin);
                    grdNUR0403.SetBindVarValue("f_nur_plan_pro", nur_plan_pro);
                    grdNUR0403.SetBindVarValue("f_nur_plan_ote", this.tabPlan_ote.SelectedTab.Tag.ToString());
                    grdNUR0403.SetBindVarValue("f_app_date", appDate);

                    grdNUR0403.QueryLayout(false);
                }
            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }

        private void tvwNur_plan_bunryu_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (tvwNur_plan_bunryu.SelectedNode.Nodes.Count > 0) 
                return;

            GetNUR0403();
        }

        #endregion

        #region [탭에 따른 이미지 설정 및 문제리스트(마스터) 설정]

        private void tabPlan_ote_SelectionChanged(object sender, System.EventArgs e)
        {
            foreach (IHIS.X.Magic.Controls.TabPage page in tabPlan_ote.TabPages)
            {
                if (tabPlan_ote.SelectedTab == page)
                    page.ImageIndex = 3;
                else
                    page.ImageIndex = 2;
            }

            GetNUR0403();
        }

        #endregion

        #region [문제리스트(마스터)에 따른 문제리스트(디테일) 데이타 취득 및 설정 코드]

        /// <summary>
        /// 문제리스트(마스터)에 해당하는 문제리스트(디테일) 데이타를 취득 후 그리드에 설정한다.
        /// </summary>
        private void grdNUR0403_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            int rowNum = grdNUR0403.CurrentRowNumber;

            grdNUR0404.SetBindVarValue("f_hosp_code", this.mHospCode);
            grdNUR0404.SetBindVarValue("f_nur_plan_jin", grdNUR0403.GetItemValue(rowNum, "nur_plan_jin").ToString());
            grdNUR0404.SetBindVarValue("f_nur_plan_pro", grdNUR0403.GetItemValue(rowNum, "nur_plan_pro").ToString());
            grdNUR0404.SetBindVarValue("f_nur_plan", grdNUR0403.GetItemValue(rowNum, "nur_plan").ToString());
            grdNUR0404.SetBindVarValue("f_app_date", appDate);

            grdNUR0404.QueryLayout(false);
        }

        #endregion

        #region [문제리스트 데이타 체크 코드]

        #region 문제리스트(마스터/디테일) 유효성 검사
        /// <summary>
        /// 저장 전 문제리스트(마스터/디테일)의 유효성 검사를 실행한다.
        /// </summary>
        private bool Grid_Validating()
        {
            AcceptData();

            //grdNUR0403
            for (int rowIndex = 0; rowIndex < grdNUR0403.RowCount; rowIndex++)
            {
                if (grdNUR0403.GetItemString(rowIndex, "nur_plan_name").Trim() == "")
                {
                    mbxMsg = "看護計画コード名を入力してください。";
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);

                    grdNUR0403.SetFocusToItem(rowIndex, "nur_plan_name");

                    return false;
                }
            }

            //grdNUR0404
            for (int rowIndex = 0; rowIndex < grdNUR0404.RowCount; rowIndex++)
            {
                if (grdNUR0404.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    string nur_plan = grdNUR0403.GetItemString(grdNUR0403.CurrentRowNumber, "nur_plan").Trim();
                    grdNUR0404.SetItemValue(rowIndex, "nur_plan", nur_plan);
                }

                if (grdNUR0404.GetItemString(rowIndex, "nur_plan_dename").Trim() == "")
                {
                    mbxMsg = "看護計画小コード名を入力してください。";
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap);

                    grdNUR0404.SetFocusToItem(rowIndex, "nur_plan_dename");

                    return false;
                }
            }

            SetSequence();

            return true;
        }
        #endregion

        #region 문제리스트(마스터) 데이타 중복 체크
        private void grdNUR0403_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "nur_plan":
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					//중복 Check
					for(int i = 0; i < grdNUR0403.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdNUR0403.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = "既に登録されている看護計画コードです。ご確認ください。";
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);

								e.Cancel= true;								
								break;			
							}
						}
					} 

					if(e.Cancel) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;

					if(grdNUR0403.DeletedRowTable != null)
					{
						foreach(DataRow row in grdNUR0403.DeletedRowTable.Rows)
						{
							if(row[e.ColName].ToString() == e.ChangeValue.ToString())
							{
								deleted = true;
								break;
							}
						}
					}

					if(deleted) break;

					string checkName = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if(checkName != "")
					{
						mbxMsg = "既に登録されている看護計画コードです。ご確認ください。";
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);

						e.Cancel= true;				
					}

					break;

				default:
					break;
			}
		
		}
		#endregion

		#region 문제리스트(디테일) 데이타 중복 체크
		private void grdNUR0404_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
		{
			e.Cancel = false;

			switch (e.ColName)
			{
				case "nur_plan_detail":
					if(e.ChangeValue.ToString().Trim() == "" ) break;
                    
					//중복 Check
					for(int i = 0; i < grdNUR0404.RowCount; i++)
					{
						if(i != e.RowNumber)
						{
							if( grdNUR0404.GetItemString(i, e.ColName).Trim() == e.ChangeValue.ToString().Trim() )
							{
								mbxMsg = "既に登録されている看護計画小コードです。ご確認ください。";
								mbxCap = "";
								XMessageBox.Show(mbxMsg, mbxCap);

								e.Cancel= true;								
								break;			
							}
						}
					} 

					if(e.Cancel) break;

					// Delete Table Check
					// 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
					bool deleted = false;

					if(grdNUR0404.DeletedRowTable != null)
					{
						foreach(DataRow row in grdNUR0404.DeletedRowTable.Rows)
						{
							if(row[e.ColName].ToString() == e.ChangeValue.ToString())
							{
								deleted = true;
								break;
							}
						}
					}

					if(deleted) break;

					string checkName = this.GetCodeName(e.ColName, e.ChangeValue.ToString());

					if(checkName != "")
					{
						mbxMsg = "既に登録されている看護計画小コードです。ご確認ください。";
						mbxCap = "";
						XMessageBox.Show(mbxMsg, mbxCap);

						e.Cancel= true;				
					}

					break;

				default:
					break;
			}		
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
                            celReturn.ColumnNumber = cell.Col-1;
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

        #endregion

		#region [디테일 데이타 존재여부 체크] ==> X 

		/// <summary>
		/// 디테일 데이타 존재여부를 체크한다.
		/// </summary>
		private bool CheckDetailData(object aGrd)
		{
			bool returnValue = false;

			if (aGrd == null) return returnValue;

			XMstGrid mstGrid = null;
            
			try
			{
				mstGrid = (XMstGrid)aGrd;
			}
			catch
			{
				return returnValue;
			}

			int chk = 0;

			try
			{
				foreach( object obj in this.Controls )
				{
					if( obj.GetType().Name.ToString().IndexOf("Panel") >= 0 )
					{
						foreach( object panObj in ((Panel)obj).Controls )
						{
							if( panObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)panObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)panObj).RowCount;						
							}
							else if( panObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)panObj).DeletedRowCount;

							}
							else if( panObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)panObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)panObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)panObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("GroupBox") >= 0 )
					{
						foreach( object gbxObj in ((GroupBox)obj).Controls )
						{						
							if( gbxObj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)gbxObj).MasterLayout == mstGrid)
							{	
								chk = chk + ((XGrid)gbxObj).RowCount;						
							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XEditGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XEditGrid)gbxObj).DeletedRowCount;

							}
							else if( gbxObj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)gbxObj).MasterLayout == mstGrid )
							{
								foreach( DataRow row in ((XMstGrid)gbxObj).LayoutTable.Rows )
									if(row.RowState != DataRowState.Added) chk = chk + 1;

								chk = chk + ((XMstGrid)gbxObj).DeletedRowCount;
							}
						}
					}
					else if( obj.GetType().Name.ToString().IndexOf("XGrid") >= 0 && ((XGrid)obj).MasterLayout == mstGrid)
					{	
						chk = chk + ((XGrid)obj).RowCount;						
					}
					else if( obj.GetType().Name.ToString().IndexOf("XEditGrid") >= 0 && ((XEditGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XEditGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XEditGrid)obj).DeletedRowCount;

					}
					else if( obj.GetType().Name.ToString().IndexOf("XMstGrid") >= 0 && ((XMstGrid)obj).MasterLayout == mstGrid )
					{
						foreach( DataRow row in ((XMstGrid)obj).LayoutTable.Rows )
							if(row.RowState != DataRowState.Added) chk = chk + 1;

						chk = chk + ((XMstGrid)obj).DeletedRowCount;
					}
				}
			}
			catch {}

			if(chk > 0)							
				returnValue = true;

			return returnValue;
		}

		#endregion

        #region [그리드 로우 정렬순서 설정 및 변경 코드]

        #region 그리드 로우 정렬순서 설정
        /// <summary>
        /// 마스터의 로우 정렬순서를 설정한다.
        /// </summary>
        private void SetSequence()
        {
            int sort_key = -1;

            for (int i = 0; i < grdNUR0403.RowCount; i++)
            {
                sort_key = i + 1;

                if (grdNUR0403.GetItemString(i, "sort_key") != sort_key.ToString())
                    grdNUR0403.SetItemValue(i, "sort_key", sort_key);
            }

            sort_key = -1;
            for (int i = 0; i < grdNUR0404.RowCount; i++)
            {
                sort_key = i + 1;
                if (grdNUR0404.GetItemString(i, "sort_key") != sort_key.ToString())
                    grdNUR0404.SetItemValue(i, "sort_key", sort_key);
            }
        }
        #endregion

        #region 그리드 로우위치 한계치(상/하) 체크
        private void btnUp1_Click(object sender, System.EventArgs e)
        {
            //0 위치에서는 변경을 막는다.
            if (grdNUR0403.RowCount > 1 && grdNUR0403.CurrentRowNumber == 0) return;

            int fromRowNum = grdNUR0403.CurrentRowNumber;
            int toRowNum = fromRowNum - 1;

            AlterGridRowPosition(grdNUR0403, fromRowNum, toRowNum);
        }

        private void btnDown1_Click(object sender, System.EventArgs e)
        {
            //마지막 위치에서는 변경을 막는다.
            if (grdNUR0403.RowCount > 1 && grdNUR0403.CurrentRowNumber == grdNUR0403.RowCount - 1) return;

            int fromRowNum = grdNUR0403.CurrentRowNumber;
            int toRowNum = fromRowNum + 1;

            AlterGridRowPosition(grdNUR0403, fromRowNum, toRowNum);
        }

        private void btnUp2_Click(object sender, System.EventArgs e)
        {
            //0 위치에서는 변경을 막는다.
            if (grdNUR0404.RowCount > 1 && grdNUR0404.CurrentRowNumber == 0) return;

            int fromRowNum = grdNUR0404.CurrentRowNumber;
            int toRowNum = fromRowNum - 1;

            AlterGridRowPosition(grdNUR0404, fromRowNum, toRowNum);
        }

        private void btnDown2_Click(object sender, System.EventArgs e)
        {
            //마지막 위치에서는 변경을 막는다.
            if (grdNUR0404.RowCount > 1 && grdNUR0404.CurrentRowNumber == grdNUR0404.RowCount - 1) return;

            int fromRowNum = grdNUR0404.CurrentRowNumber;
            int toRowNum = fromRowNum + 1;

            AlterGridRowPosition(grdNUR0404, fromRowNum, toRowNum);
        }
        #endregion

        #region 그리드 로우위치 변경
        /// <summary>
		/// 선택한 로우의 위치를 변경한다.
		/// </summary>
		/// <param name="grd">해당 그리드</param>
		/// <param name="fromRowNum">대상 로우위치  </param>
		/// <param name="toRowNum"  >변경할 로우위치</param>
		private void AlterGridRowPosition(XEditGrid grd, int fromRowNum, int toRowNum)
		{
			if( fromRowNum < 0 || toRowNum < 0 || fromRowNum >= grd.RowCount || toRowNum >= grd.RowCount ) return;

			if(grd == grdNUR0403) grdNUR0404.MasterLayout = null;
			
			int currentColNum = grd.CurrentColNumber;

			if(currentColNum == -1) currentColNum = 0;

			MultiLayout copyLay = grd.CopyToLayout();

			grd.LayoutTable.Rows.Clear();

			for(int i = 0; i < copyLay.RowCount; i++ )
			{
				if( i == fromRowNum )
					continue;

				//변경위치로 Row를 가져간다.
				if( i == toRowNum )
				{
					if( fromRowNum < toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
					
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[fromRowNum]);

					if( fromRowNum > toRowNum )
						grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
				}
				else
					grd.LayoutTable.ImportRow(copyLay.LayoutTable.Rows[i]);
			}

			grd.DisplayData();
			grd.SetFocusToItem(toRowNum, currentColNum);	
			grd.SelectRow(toRowNum);

			if(grd == grdNUR0403) grdNUR0404.MasterLayout = grdNUR0403;
        }
        #endregion

        #endregion

        #region [데이타 저장 완료 메시지 설정 코드]

        // 지정 에러메세지 인지 확인하는 플레그
        private bool appointmentError = false;

        /// <summary>
        /// 그리드의 데이타 저장 완료 후, 메세지를 표시한다.
        /// </summary>
        private void grdNUR0_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                mbxMsg = "保存が完了しました。";
                SetMsg(mbxMsg);
            }
            else
            {
                if (!appointmentError)
                {
                    mbxMsg = "保存に失敗しました。";
                    mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = "Save Error";

                    XMessageBox.Show(mbxMsg, mbxCap);
                }
                appointmentError = false;
            }
        }

        #endregion


        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR0403U00 parent = null;
            
            public XSavePerformer(NUR0403U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string mbxMsg = string.Empty;
                string mbxCap = string.Empty;
                string cmdText = string.Empty;
                object retVal = null;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM NUR0403
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND NUR_PLAN_JIN = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO = :f_nur_plan_pro
                                               AND NUR_PLAN     = :f_nur_plan
                                               AND ROWNUM = 1";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        mbxMsg = String.Format("保存に失敗しました。\nコード[{0}][{1}][{2}]は既に登録されています。",
                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
                                                               item.BindVarList["f_nur_plan"].VarValue);
                                        mbxCap = "Save Error";
                                        parent.appointmentError = true;
                                        XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0403 (SYS_DATE,           SYS_ID,                         UPD_DATE,       UPD_ID,   HOSP_CODE,
                                                                 NUR_PLAN_JIN,       NUR_PLAN_PRO,                   NUR_PLAN, 
                                                                 FROM_DATE,          NUR_PLAN_NAME,                  NUR_PLAN_OTE, 
                                                                 SORT_KEY,           END_DATE,                       VALD)
                                                         VALUES ( 
                                                                 SYSDATE,            :q_user_id,                     SYSDATE,       :q_user_id,   :f_hosp_code,
                                                                 :f_nur_plan_jin,    :f_nur_plan_pro,                NUR0403_SEQ.NEXTVAL, 
                                                                 TRUNC(SYSDATE),     :f_nur_plan_name,               :f_nur_plan_ote, 
                                                                 :f_sort_key,        NVL(:f_end_date,'9998/12/31'),  :f_vald             )";
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
                                               AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"SELECT 'Y'
                                              FROM NUR0404
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan
                                               AND ROWNUM = 1";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        mbxMsg = String.Format("保存に失敗しました。\nコード[{0}][{1}][{2}]は詳細コードが登録されています。",
                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
                                                               item.BindVarList["f_nur_plan"].VarValue);
                                        mbxCap = "Delete Error";
                                        parent.appointmentError = true;
                                        XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"DELETE NUR0403
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND NUR_PLAN_JIN  = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO  = :f_nur_plan_pro
                                               AND NUR_PLAN      = :f_nur_plan";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"SELECT 'Y'
                                              FROM NUR0404
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO    = :f_nur_plan_pro
                                               AND NUR_PLAN        = :f_nur_plan
                                               AND NUR_PLAN_DETAIL = :f_nur_plan_detail
                                               AND ROWNUM = 1";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (Service.ErrCode == 0)
                                {
                                    if (retVal != null && retVal.ToString().Equals("Y"))
                                    {
                                        mbxMsg = String.Format("保存に失敗しました。\nコード[{0}][{1}][{2}][{3}]は既に登録されています。",
                                                               item.BindVarList["f_nur_plan_jin"].VarValue,
                                                               item.BindVarList["f_nur_plan_pro"].VarValue,
                                                               item.BindVarList["f_nur_plan"].VarValue,
                                                               item.BindVarList["f_nur_plan_detail"].VarValue);
                                        mbxCap = "Save Error";
                                        XMessageBox.Show(mbxMsg, mbxCap);

                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR0404 (SYS_DATE,              SYS_ID,                          UPD_DATE,          UPD_ID,   HOSP_CODE,
                                                                 NUR_PLAN_JIN,          NUR_PLAN_PRO,                    NUR_PLAN,
                                                                 NUR_PLAN_DETAIL,       FROM_DATE,                       NUR_PLAN_DENAME,
                                                                 SORT_KEY,              END_DATE,                        VALD)
                                                        VALUES  (SYSDATE,               :q_user_id,                      SYSDATE,          :q_user_id, :f_hosp_code,
                                                                 :f_nur_plan_jin,       :f_nur_plan_pro,                 :f_nur_plan,
                                                                 :f_nur_plan_detail,    TRUNC(SYSDATE) ,                 :f_nur_plan_dename, 
                                                                 :f_sort_key,           NVL(:f_end_date,'9998/12/31'),   :f_vald)";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR0404
                                               SET USER_ID         = :q_user_id,
                                                   UPD_DATE        = SYSDATE,
                                                   NUR_PLAN_DENAME = :f_nur_plan_dename,
                                                   SORT_KEY        = :f_sort_key,
                                                   VALD            = :f_vald
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO    = :f_nur_plan_pro
                                               AND NUR_PLAN        = :f_nur_plan
                                               AND NUR_PLAN_DETAIL = :f_nur_plan_detail";
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR0404
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND NUR_PLAN_JIN    = :f_nur_plan_jin
                                               AND NUR_PLAN_PRO    = :f_nur_plan_pro
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

	}
}
