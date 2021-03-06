#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
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
	/// ORDERTRANS에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP2001U02 : IHIS.Framework.XScreen
    {
        private XPatientBox paBox;
        private XPanel xPanel1;
        private XTabControl tabDataGubun;
        private XPanel xPanel5;
        private XLabel xLabel11;
        private XLabel xLabel2;
        private XLabel xLabel10;
        private XPanel xPanel2;
        private XEditGrid grdOCS1003;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XGridHeader xGridHeader1;
        private XEditGridCell xEditGridCell10;
        private MultiLayout layNuGroup;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;
        private XEditGrid grdOCS2003;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XGridHeader xGridHeader2;
        private XLabel xLabel1;
        private MultiLayout layOrderInfo;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XButtonList btnList;
        private XEditGridCell xEditGridCell22;
        private ToolTip toolTip1;
        private XPanel pnlStatusBar;
        private Label lbHangmogName;
        private Label lbJobGubun;
        private XProgressBar pgbStatus;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XCheckBox cbxKaikei_yn;
        private XEditGridCell xEditGridCell25;
        private PictureBox pbxIsKaikeiEndOrder;
        private XPanel xPanel3;

        private IContainer components = null;

        public INP2001U02()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}

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

		#region Designer generated code
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP2001U02));
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.grdOCS1003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.tabDataGubun = new IHIS.Framework.XTabControl();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdOCS2003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layNuGroup = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderInfo = new IHIS.Framework.MultiLayout();
            this.btnList = new IHIS.Framework.XButtonList();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlStatusBar = new IHIS.Framework.XPanel();
            this.lbHangmogName = new System.Windows.Forms.Label();
            this.lbJobGubun = new System.Windows.Forms.Label();
            this.pgbStatus = new IHIS.Framework.XProgressBar();
            this.cbxKaikei_yn = new IHIS.Framework.XCheckBox();
            this.pbxIsKaikeiEndOrder = new System.Windows.Forms.PictureBox();
            this.xPanel3 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNuGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsKaikeiEndOrder)).BeginInit();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "선택.ICO");
            this.ImageList.Images.SetKeyName(1, "미선택.ICO");
            this.ImageList.Images.SetKeyName(2, "입원처방.ico");
            // 
            // paBox
            // 
            this.paBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.paBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.paBox.Location = new System.Drawing.Point(4, 4);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(977, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdOCS1003);
            this.xPanel1.Controls.Add(this.tabDataGubun);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel1.Location = new System.Drawing.Point(4, 36);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(472, 514);
            this.xPanel1.TabIndex = 1;
            // 
            // grdOCS1003
            // 
            this.grdOCS1003.AddedHeaderLine = 1;
            this.grdOCS1003.ApplyPaintEventToAllColumn = true;
            this.grdOCS1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell20,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell7,
            this.xEditGridCell5,
            this.xEditGridCell8,
            this.xEditGridCell10,
            this.xEditGridCell24,
            this.xEditGridCell25});
            this.grdOCS1003.ColPerLine = 10;
            this.grdOCS1003.Cols = 10;
            this.grdOCS1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS1003.FixedRows = 2;
            this.grdOCS1003.HeaderHeights.Add(31);
            this.grdOCS1003.HeaderHeights.Add(0);
            this.grdOCS1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdOCS1003.Location = new System.Drawing.Point(0, 25);
            this.grdOCS1003.Name = "grdOCS1003";
            this.grdOCS1003.QuerySQL = resources.GetString("grdOCS1003.QuerySQL");
            this.grdOCS1003.ReadOnly = true;
            this.grdOCS1003.Rows = 3;
            this.grdOCS1003.RowStateCheckOnPaint = false;
            this.grdOCS1003.Size = new System.Drawing.Size(472, 489);
            this.grdOCS1003.TabIndex = 10;
            this.grdOCS1003.ToolTipActive = true;
            this.grdOCS1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS1003_MouseDown);
            this.grdOCS1003.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdOCS1003_GridColumnProtectModify);
            this.grdOCS1003.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdOCS1003_GridCellPainting);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "pkout1001";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "PKOUT1001";
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "pkocs1003";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "PKOCS1003";
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "order_gubun";
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "オーダ区分";
            this.xEditGridCell1.RowSpan = 2;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "hangmog_code";
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderText = "オ―ダコード";
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "hangmog_name";
            this.xEditGridCell3.CellWidth = 150;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.HeaderText = "オ―ダ名";
            this.xEditGridCell3.RowSpan = 2;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "suryang";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell4.CellWidth = 50;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.HeaderText = "数量";
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "danui_name";
            this.xEditGridCell6.CellWidth = 50;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.HeaderText = "単位";
            this.xEditGridCell6.RowSpan = 2;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "dv_time";
            this.xEditGridCell9.CellWidth = 20;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.HeaderText = "dv_time";
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "dv";
            this.xEditGridCell7.CellWidth = 30;
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.HeaderText = "dv";
            this.xEditGridCell7.Row = 1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "nalsu";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 40;
            this.xEditGridCell5.Col = 8;
            this.xEditGridCell5.HeaderText = "日数";
            this.xEditGridCell5.RowSpan = 2;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "specimen_name";
            this.xEditGridCell8.Col = 9;
            this.xEditGridCell8.HeaderText = "検体";
            this.xEditGridCell8.RowSpan = 2;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell10.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.CellName = "select";
            this.xEditGridCell10.CellWidth = 35;
            this.xEditGridCell10.HeaderText = "選択";
            this.xEditGridCell10.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell10.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.RowImageIndex = 0;
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SelectedBackColor = IHIS.Framework.XColor.XGridRowBackColor;
            this.xEditGridCell10.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "order_gubun_bas";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "オーダ区分BAS";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "sunab_yn";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "会計済";
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 6;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "回数";
            this.xGridHeader1.HeaderWidth = 20;
            // 
            // tabDataGubun
            // 
            this.tabDataGubun.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabDataGubun.IDEPixelArea = true;
            this.tabDataGubun.IDEPixelBorder = false;
            this.tabDataGubun.Location = new System.Drawing.Point(0, 0);
            this.tabDataGubun.Name = "tabDataGubun";
            this.tabDataGubun.ShowArrows = false;
            this.tabDataGubun.ShowClose = false;
            this.tabDataGubun.Size = new System.Drawing.Size(472, 25);
            this.tabDataGubun.TabIndex = 9;
            this.tabDataGubun.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabDataGubun_MouseDown);
            // 
            // xPanel5
            // 
            this.xPanel5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel5.BackgroundImage")));
            this.xPanel5.Controls.Add(this.xLabel11);
            this.xPanel5.Controls.Add(this.xLabel2);
            this.xPanel5.Controls.Add(this.xLabel10);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.xPanel5.Location = new System.Drawing.Point(476, 36);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(42, 514);
            this.xPanel5.TabIndex = 41;
            // 
            // xLabel11
            // 
            this.xLabel11.Image = ((System.Drawing.Image)(resources.GetObject("xLabel11.Image")));
            this.xLabel11.Location = new System.Drawing.Point(10, 97);
            this.xLabel11.Name = "xLabel11";
            this.xLabel11.Size = new System.Drawing.Size(22, 24);
            this.xLabel11.TabIndex = 3;
            // 
            // xLabel2
            // 
            this.xLabel2.Image = ((System.Drawing.Image)(resources.GetObject("xLabel2.Image")));
            this.xLabel2.Location = new System.Drawing.Point(10, 387);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(22, 24);
            this.xLabel2.TabIndex = 2;
            // 
            // xLabel10
            // 
            this.xLabel10.Image = ((System.Drawing.Image)(resources.GetObject("xLabel10.Image")));
            this.xLabel10.Location = new System.Drawing.Point(10, 239);
            this.xLabel10.Name = "xLabel10";
            this.xLabel10.Size = new System.Drawing.Size(22, 24);
            this.xLabel10.TabIndex = 1;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdOCS2003);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel2.Location = new System.Drawing.Point(518, 36);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(463, 514);
            this.xPanel2.TabIndex = 42;
            // 
            // grdOCS2003
            // 
            this.grdOCS2003.AddedHeaderLine = 1;
            this.grdOCS2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell23,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell22});
            this.grdOCS2003.ColPerLine = 10;
            this.grdOCS2003.Cols = 10;
            this.grdOCS2003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOCS2003.FixedRows = 2;
            this.grdOCS2003.HeaderHeights.Add(32);
            this.grdOCS2003.HeaderHeights.Add(0);
            this.grdOCS2003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdOCS2003.Location = new System.Drawing.Point(0, 25);
            this.grdOCS2003.Name = "grdOCS2003";
            this.grdOCS2003.QuerySQL = resources.GetString("grdOCS2003.QuerySQL");
            this.grdOCS2003.ReadOnly = true;
            this.grdOCS2003.Rows = 3;
            this.grdOCS2003.RowStateCheckOnPaint = false;
            this.grdOCS2003.Size = new System.Drawing.Size(463, 489);
            this.grdOCS2003.TabIndex = 11;
            this.grdOCS2003.ToolTipActive = true;
            this.grdOCS2003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdOCS2003_MouseDown);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "pkocs2003";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "order_gubun";
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.HeaderText = "オーダ区分";
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "hangmog_code";
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.HeaderText = "オ―ダコード";
            this.xEditGridCell12.RowSpan = 2;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "hangmog_name";
            this.xEditGridCell13.CellWidth = 150;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.HeaderText = "オ―ダ名";
            this.xEditGridCell13.RowSpan = 2;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "suryang";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell14.CellWidth = 50;
            this.xEditGridCell14.Col = 4;
            this.xEditGridCell14.HeaderText = "数量";
            this.xEditGridCell14.RowSpan = 2;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "danui_name";
            this.xEditGridCell15.CellWidth = 50;
            this.xEditGridCell15.Col = 5;
            this.xEditGridCell15.HeaderText = "単位";
            this.xEditGridCell15.RowSpan = 2;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "dv_time";
            this.xEditGridCell16.CellWidth = 20;
            this.xEditGridCell16.Col = 6;
            this.xEditGridCell16.HeaderText = "dv_time";
            this.xEditGridCell16.Row = 1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "dv";
            this.xEditGridCell17.CellWidth = 30;
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.HeaderText = "dv";
            this.xEditGridCell17.Row = 1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "nalsu";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell18.CellWidth = 40;
            this.xEditGridCell18.Col = 8;
            this.xEditGridCell18.HeaderText = "日数";
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "specimen_name";
            this.xEditGridCell19.CellWidth = 35;
            this.xEditGridCell19.Col = 9;
            this.xEditGridCell19.HeaderText = "検体";
            this.xEditGridCell19.RowSpan = 2;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell22.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell22.CellName = "select_yn";
            this.xEditGridCell22.CellWidth = 35;
            this.xEditGridCell22.HeaderText = "選択";
            this.xEditGridCell22.RowForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xEditGridCell22.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell22.RowSpan = 2;
            this.xEditGridCell22.SelectedForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 6;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderText = "回数";
            this.xGridHeader2.HeaderWidth = 20;
            // 
            // xLabel1
            // 
            this.xLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.Image = ((System.Drawing.Image)(resources.GetObject("xLabel1.Image")));
            this.xLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.xLabel1.ImageIndex = 2;
            this.xLabel1.ImageList = this.ImageList;
            this.xLabel1.Location = new System.Drawing.Point(0, 0);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(463, 25);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "  入院オーダ";
            // 
            // layNuGroup
            // 
            this.layNuGroup.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layNuGroup.QuerySQL = resources.GetString("layNuGroup.QuerySQL");
            this.layNuGroup.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layNuGroup_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pkout1001";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "gwa_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "naewon_date";
            this.multiLayoutItem7.DataType = IHIS.Framework.DataType.Date;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "jubsu_gubun";
            // 
            // btnList
            // 
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.F12, "転入処理", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Cancel, System.Windows.Forms.Shortcut.F11, "転入取消", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(639, 554);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(339, 34);
            this.btnList.TabIndex = 43;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlStatusBar.BackgroundImage")));
            this.pnlStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStatusBar.Controls.Add(this.lbHangmogName);
            this.pnlStatusBar.Controls.Add(this.lbJobGubun);
            this.pnlStatusBar.Controls.Add(this.pgbStatus);
            this.pnlStatusBar.Location = new System.Drawing.Point(199, 225);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(596, 122);
            this.pnlStatusBar.TabIndex = 44;
            this.pnlStatusBar.Visible = false;
            // 
            // lbHangmogName
            // 
            this.lbHangmogName.BackColor = System.Drawing.Color.Transparent;
            this.lbHangmogName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHangmogName.Location = new System.Drawing.Point(14, 82);
            this.lbHangmogName.Name = "lbHangmogName";
            this.lbHangmogName.Size = new System.Drawing.Size(561, 35);
            this.lbHangmogName.TabIndex = 2;
            this.lbHangmogName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbJobGubun
            // 
            this.lbJobGubun.BackColor = System.Drawing.Color.Transparent;
            this.lbJobGubun.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJobGubun.ForeColor = System.Drawing.Color.Red;
            this.lbJobGubun.Location = new System.Drawing.Point(15, 11);
            this.lbJobGubun.Name = "lbJobGubun";
            this.lbJobGubun.Size = new System.Drawing.Size(561, 35);
            this.lbJobGubun.TabIndex = 1;
            this.lbJobGubun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(12, 49);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(566, 29);
            this.pgbStatus.TabIndex = 0;
            // 
            // cbxKaikei_yn
            // 
            this.cbxKaikei_yn.AutoSize = true;
            this.cbxKaikei_yn.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            this.cbxKaikei_yn.Location = new System.Drawing.Point(15, 6);
            this.cbxKaikei_yn.Name = "cbxKaikei_yn";
            this.cbxKaikei_yn.Size = new System.Drawing.Size(130, 17);
            this.cbxKaikei_yn.TabIndex = 45;
            this.cbxKaikei_yn.Text = "会計済みオーダ表示";
            this.cbxKaikei_yn.UseVisualStyleBackColor = false;
            this.cbxKaikei_yn.CheckedChanged += new System.EventHandler(this.cbxKaikei_yn_CheckedChanged);
            // 
            // pbxIsKaikeiEndOrder
            // 
            this.pbxIsKaikeiEndOrder.Image = ((System.Drawing.Image)(resources.GetObject("pbxIsKaikeiEndOrder.Image")));
            this.pbxIsKaikeiEndOrder.Location = new System.Drawing.Point(148, 6);
            this.pbxIsKaikeiEndOrder.Name = "pbxIsKaikeiEndOrder";
            this.pbxIsKaikeiEndOrder.Size = new System.Drawing.Size(16, 17);
            this.pbxIsKaikeiEndOrder.TabIndex = 105;
            this.pbxIsKaikeiEndOrder.TabStop = false;
            this.pbxIsKaikeiEndOrder.Visible = false;
            // 
            // xPanel3
            // 
            this.xPanel3.BackColor = IHIS.Framework.XColor.XProgressBarGradientStartColor;
            this.xPanel3.Controls.Add(this.cbxKaikei_yn);
            this.xPanel3.Controls.Add(this.pbxIsKaikeiEndOrder);
            this.xPanel3.Location = new System.Drawing.Point(6, 556);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(200, 28);
            this.xPanel3.TabIndex = 106;
            // 
            // INP2001U02
            // 
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.pnlStatusBar);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.paBox);
            this.Name = "INP2001U02";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(985, 590);
            this.Load += new System.EventHandler(this.INP2001U02_Load);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.INP2001U02_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS1003)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOCS2003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNuGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxIsKaikeiEndOrder)).EndInit();
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        #region Screen 변수
        private string mBunho = "";        //환자번호
        private string mPkinp1001 = "";    //PKINP1001
        private string mIpwon_date = "";   //입원일자

        private string mMsg = "";
        private string mCap = "";
        #endregion

        private void INP2001U02_Load(object sender, EventArgs e)
        {
            // 포커스 
            this.paBox.Focus();

        }
        private void INP2001U02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.layOrderInfo = this.grdOCS1003.CloneToLayout();

            if (this.OpenParam != null) {
                this.mBunho = this.OpenParam["bunho"].ToString();
                this.mPkinp1001 = this.OpenParam["pkinp1001"].ToString();
                this.mIpwon_date = this.OpenParam["ipwon_date"].ToString();
                this.paBox.SetPatientID(mBunho);
                //this.grdOCS1003.QueryLayout(false);
            }
            //탭페이지 생성
            //this.MakeDataGubunTabPages();
            //백 테이블 설정
            
        }
        #region Screen Load

        #endregion

        #region [탭페이지 동적구성]
        private void MakeDataGubunTabPages()
        {

            IHIS.X.Magic.Controls.TabPage tpg;

            this.tabDataGubun.SelectionChanged -= new EventHandler(tabDataGubun_SelectionChanged);

            try
            {
                this.tabDataGubun.TabPages.Clear();
            }
            catch
            {
                this.tabDataGubun.Refresh();
            }

            this.layOrderInfo.Reset();

            this.layNuGroup.QueryLayout(true);

            if (this.layNuGroup.RowCount <= 0) this.grdOCS1003.Reset();

  
            for (int i = 0; i < this.layNuGroup.RowCount; i++)
            {
                Hashtable tagtexts = new Hashtable();
                if (this.layNuGroup.GetItemString(i, "jubsu_gubun").ToString() == "R")
                {
                    tpg = new IHIS.X.Magic.Controls.TabPage( "予約検査" + " [" + this.layNuGroup.GetItemString(i, "gwa_name").ToString() + "]");
                    tagtexts.Add("naewon_date", this.mIpwon_date);
                }
                else
                {
                    tpg = new IHIS.X.Magic.Controls.TabPage((this.layNuGroup.GetItemString(i, "naewon_date").ToString()) + " [" + this.layNuGroup.GetItemString(i, "gwa_name").ToString() + "]");
                    tagtexts.Add("naewon_date", this.layNuGroup.GetItemString(i, "naewon_date"));
                }
                
                tagtexts.Add("jubsu_gubun", this.layNuGroup.GetItemString(i, "jubsu_gubun"));
                tagtexts.Add("pkout1001", this.layNuGroup.GetItemString(i, "pkout1001"));
                tpg.Tag = tagtexts;
                tpg.ImageList = this.ImageList;
                tpg.ImageIndex = 1;
                this.tabDataGubun.TabPages.Add(tpg);
            }
            this.tabDataGubun.SelectedTab = this.tabDataGubun.TabPages[0];
            this.tabDataGubun.SelectionChanged += new EventHandler(tabDataGubun_SelectionChanged);
            this.tabDataGubun_SelectionChanged(this.tabDataGubun, new EventArgs());

            this.setIcon();
        }
        #endregion

        private void setIcon()
        {
            if (this.tabDataGubun.SelectedTab != null)
            {
                Hashtable tagtexts = this.tabDataGubun.SelectedTab.Tag as Hashtable;

                string cmd = @"SELECT COUNT(*)
                            FROM  OUT1001 A   
                                 ,OCS1003 B
                                 ,OCS0103 C
                                 ,OCS0132 D
                                 ,OCS0116 E
                          WHERE A.HOSP_CODE        = :f_hosp_code
                            AND A.BUNHO            = :f_bunho
                            AND A.PKOUT1001        = :f_pkout1001
                            AND A.NAEWON_DATE      = :f_ipwon_date
                            AND A.HOSP_CODE        = B.HOSP_CODE
                            AND A.PKOUT1001        = B.FKOUT1001
                            AND B.ORDER_DATE       = A.NAEWON_DATE
                            AND NVL(B.DISPLAY_YN , 'Y') = 'Y'
                            AND NVL(B.DC_YN,'N')        = 'N'
                            AND NVL(B.MUHYO,'N')        = 'N'
                            AND NVL(B.IF_DATA_SEND_YN, 'N' ) = 'Y'
                            AND NVL(B.SUNAB_YN, 'N')         = 'Y'
                            AND B.NALSU            >= 0     
                            AND B.HOSP_CODE        = C.HOSP_CODE(+)             
                            AND C.HANGMOG_CODE(+)  = B.HANGMOG_CODE
                            AND B.HOSP_CODE        = D.HOSP_CODE(+)
                            AND D.CODE     (+)     = SUBSTR(B.ORDER_GUBUN, 2, 1)
                            AND D.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'     
                            AND B.HOSP_CODE        = E.HOSP_CODE(+)                               
                            AND E.SPECIMEN_CODE(+) = B.SPECIMEN_CODE
                            AND B.ORDER_DATE BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                         ORDER BY B.SEQ ";

                BindVarCollection bind = new BindVarCollection();

                bind.Add("f_hosp_code", EnvironInfo.HospCode);
                bind.Add("f_bunho", this.mBunho);
                bind.Add("f_pkout1001", tagtexts["pkout1001"].ToString());
                bind.Add("f_ipwon_date", tagtexts["naewon_date"].ToString());

                object obj = Service.ExecuteScalar(cmd, bind);

                if (obj != null && int.Parse(obj.ToString()) > 0)
                    this.pbxIsKaikeiEndOrder.Visible = true;
                else
                    this.pbxIsKaikeiEndOrder.Visible = false;

            }
            else
                this.pbxIsKaikeiEndOrder.Visible = false;
        }

        #region [ 탭 체인지 이벤트처리 ]
        private void tabDataGubun_SelectionChanged(object sender, EventArgs e)
        {
            
            IHIS.X.Magic.Controls.TabControl control = sender as IHIS.X.Magic.Controls.TabControl;

            if (this.tabDataGubun.SelectedTab == null)
            {
                return;
            }

            foreach(IHIS.X.Magic.Controls.TabPage pag in this.tabDataGubun.TabPages)
            {
                if (pag == this.tabDataGubun.SelectedTab) {
                    grdOCS1003_Load();
                    
                }
            }
        }

        #endregion

        #region [ grdOCS1003 LOAD ]
        private void grdOCS1003_Load()
        {
            Hashtable tagtexts = this.tabDataGubun.SelectedTab.Tag as Hashtable;

            if (tagtexts["jubsu_gubun"].ToString() == "R")
            {
                this.grdOCS1003.QuerySQL = @"SELECT   A.PKOUT1001                                           PKOUT1001
                                                    , B.PKOCS1003                                           PKOCS1003  
                                                    , NVL(D.CODE_NAME, 'Etc')                               ORDER_GUBUN_NAME
                                                    , B.HANGMOG_CODE                                        HANGMOG_CODE 
                                                    , C.HANGMOG_NAME                                        HANGMOG_NAME
                                                    , B.SURYANG                                             SURYANG   
                                                    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)       ORD_DANUI_NAME
                                                    , B.DV_TIME                                             DV_TIME
                                                    , B.DV                                                  DV
                                                    , B.NALSU                                               NALSU
                                                    , E.SPECIMEN_NAME                                       SPECIMEN_NAME
                                                    , 'N'                                                   SELECT_YN
                                                    , SUBSTR(B.ORDER_GUBUN, 2, 1)                           ORDER_GUBUN_BAS
                                                    , NVL(B.SUNAB_YN, 'N')                                  SUNAB_YN
                                                FROM  OUT1001 A   
                                                     ,OCS1003 B
                                                     ,OCS0103 C
                                                     ,OCS0132 D
                                                     ,OCS0116 E
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.BUNHO     = :f_bunho
                                                   AND A.PKOUT1001 = :f_pkout1001
                                                   AND A.NAEWON_DATE < TO_DATE(:f_ipwon_date) - 1
                                                   AND A.HOSP_CODE  = B.HOSP_CODE 
                                                   AND A.PKOUT1001  = B.FKOUT1001
                                                   AND B.RESER_DATE >= :f_ipwon_date
                                                   AND B.ACTING_DATE IS NULL
                                                   AND B.DC_YN ='N'
                                                   AND B.NALSU > 0 
                                                   AND B.HOSP_CODE        = C.HOSP_CODE(+)
                                                   AND C.HANGMOG_CODE(+)  = B.HANGMOG_CODE
                                                   AND B.HOSP_CODE        = D.HOSP_CODE(+)
                                                   AND D.CODE     (+)     = SUBSTR(B.ORDER_GUBUN, 2, 1)
                                                   AND D.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'    
                                                   AND B.HOSP_CODE        = E.HOSP_CODE(+)                                
                                                   AND E.SPECIMEN_CODE(+) = B.SPECIMEN_CODE
                                                   AND B.ORDER_DATE BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                                                 ORDER BY B.SEQ ";
                
            }
            else
            {
                this.grdOCS1003.QuerySQL = @"SELECT   A.PKOUT1001                                           PKOUT1001
                                                    , B.PKOCS1003                                           PKOCS1003  
                                                    , NVL(D.CODE_NAME, 'Etc')                               ORDER_GUBUN_NAME
                                                    , B.HANGMOG_CODE                                        HANGMOG_CODE 
                                                    , C.HANGMOG_NAME                                        HANGMOG_NAME
                                                    , B.SURYANG                                             SURYANG   
                                                    , FN_OCS_LOAD_CODE_NAME('ORD_DANUI', B.ORD_DANUI)       ORD_DANUI_NAME
                                                    , B.DV_TIME                                             DV_TIME
                                                    , B.DV                                                  DV
                                                    , B.NALSU                                               NALSU
                                                    , E.SPECIMEN_NAME                                       SPECIMEN_NAME
                                                    , 'N'                                                   SELECT_YN
                                                    , SUBSTR(B.ORDER_GUBUN, 2, 1)                           ORDER_GUBUN_BAS
                                                    , NVL(B.SUNAB_YN, 'N')                                  SUNAB_YN
                                                FROM  OUT1001 A   
                                                     ,OCS1003 B
                                                     ,OCS0103 C
                                                     ,OCS0132 D
                                                     ,OCS0116 E
                                              WHERE A.HOSP_CODE        = :f_hosp_code
                                                AND A.BUNHO            = :f_bunho
                                                AND A.PKOUT1001        = :f_pkout1001
                                                AND A.NAEWON_DATE      = :f_ipwon_date
                                                AND A.HOSP_CODE        = B.HOSP_CODE
                                                AND A.PKOUT1001        = B.FKOUT1001
                                                AND B.ORDER_DATE       = A.NAEWON_DATE
                                                AND NVL(B.DISPLAY_YN , 'Y') = 'Y'
                                                AND NVL(B.DC_YN,'N')        = 'N'
--                                                AND NVL(B.MUHYO,'N')        = 'N'
                                                AND (
                                                     (
                                                         NVL(B.INSTEAD_YN, 'N') = 'N'
                                                     AND NVL(B.MUHYO,'N')       = 'N'
                                                     )
                                                     OR
                                                     (
                                                         NVL(B.INSTEAD_YN, 'N') = 'Y'
                                                     )
                                                    )

                                                AND NVL(B.IF_DATA_SEND_YN, 'N' ) = :f_kaikei_yn
                                                AND NVL(B.SUNAB_YN, 'N')         = :f_kaikei_yn
                                                AND B.NALSU            >= 0     
                                                AND B.HOSP_CODE        = C.HOSP_CODE(+)             
                                                AND C.HANGMOG_CODE(+)  = B.HANGMOG_CODE
                                                AND B.HOSP_CODE        = D.HOSP_CODE(+)
                                                AND D.CODE     (+)     = SUBSTR(B.ORDER_GUBUN, 2, 1)
                                                AND D.CODE_TYPE(+)     = 'ORDER_GUBUN_BAS'     
                                                AND B.HOSP_CODE        = E.HOSP_CODE(+)                               
                                                AND E.SPECIMEN_CODE(+) = B.SPECIMEN_CODE
                                                AND B.ORDER_DATE BETWEEN C.START_DATE AND NVL(C.END_DATE, '9998/12/31')
                                             ORDER BY B.SEQ ";
            }
            grdOCS1003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOCS1003.SetBindVarValue("f_bunho", this.mBunho);
            grdOCS1003.SetBindVarValue("f_pkout1001", tagtexts["pkout1001"].ToString());
            grdOCS1003.SetBindVarValue("f_ipwon_date", tagtexts["naewon_date"].ToString());

            if(this.cbxKaikei_yn.Checked == true)
                grdOCS1003.SetBindVarValue("f_kaikei_yn", "Y");
            else
                grdOCS1003.SetBindVarValue("f_kaikei_yn", "N");

            this.grdOCS1003.QueryLayout(false);
            this.SettingDefaultImageGrid();
        }
        #endregion
        #region [ grdOCS2003 LOAD ]
        private void grdOCS2003_Load()
        {
            grdOCS2003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOCS2003.SetBindVarValue("f_bunho", this.mBunho);
            grdOCS2003.SetBindVarValue("f_ipwon_date", this.mIpwon_date);
            grdOCS2003.SetBindVarValue("f_fkinp1001", this.mPkinp1001);
            this.grdOCS2003.QueryLayout(true);

            this.SettingIpwonDefaultGridImage();
        }
        #endregion
        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);
        }
        #region [그리트디폴트이미지셋팅]
        private void SettingDefaultImageGrid()
        {

            for (int i = 0; i < grdOCS1003.RowCount; i++)
            {
                if (this.IsExistOrderBack(grdOCS1003.GetItemString(i, "pkocs1003")))
                {
                    grdOCS1003[i, "select"].Image = this.ImageList.Images[0];
                    grdOCS1003.SetItemValue(i, "select", "Y");
                }
                else
                {
                    grdOCS1003.SetItemValue(i, "select", "N");
                    grdOCS1003[i, "select"].Image = this.ImageList.Images[1];
                }
            }
        }
        #region [ 입원 그리드 디폴트 이미지 셋팅 ]

        private void SettingIpwonDefaultGridImage()
        {
            for (int i = 0; i < grdOCS2003.RowCount; i++)
            {
                if (this.grdOCS2003.GetItemString(i, "select_yn") == "Y")
                {
                    grdOCS2003[i, "select_yn"].Image = this.ImageList.Images[0];
                }
                else
                {
                    grdOCS2003[i, "select_yn"].Image = this.ImageList.Images[1];
                }
            }
        }

        #endregion
        #endregion
        #region [ 쿼리개시 ]
        private void layNuGroup_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layNuGroup.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layNuGroup.SetBindVarValue("f_bunho", this.mBunho);
            this.layNuGroup.SetBindVarValue("f_ipwon_date", this.mIpwon_date);
        }
        #endregion

        #region [ 에디터그리드마우스클릭이벤트 ]
        private void grdOCS1003_MouseDown(object sender, MouseEventArgs e)
        {
            int rowNumber = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grdOCS1003.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                if (grdOCS1003.CurrentColName == "select")
                {
                    if (this.grdOCS1003.GetItemString(rowNumber, "sunab_yn") != "Y")
                        this.ClickCurrentOrder(rowNumber);
                    else
                    {
                        XMessageBox.Show("会計済みオーダです。転入処理できません。", "確認", MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
        }
        #endregion
        #region [오더 선택 관련]
        private void ClickCurrentOrder(int aRowNumber)
        {
            if (this.grdOCS1003.GetItemString(aRowNumber, "sunab_yn") == "N")
            {
                if (this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "E" // 放射線
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "F" // 検体検査
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "N" // 生理検査
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "C" // 内服薬
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "D" // 外用薬
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "B" // 注射薬
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "H" // 処置
                    && this.grdOCS1003.GetItemString(aRowNumber, "order_gubun_bas") != "G" // 手術
                    )
                {
                    XMessageBox.Show("【" + this.grdOCS1003.GetItemString(aRowNumber, "hangmog_name") + "】" + "は転入対象オーダではありません。選択できません。", "確認");
                }
                else
                {
                    if (this.grdOCS1003.GetItemString(aRowNumber, "select") == "Y")
                    {
                        this.grdOCS1003.SetItemValue(aRowNumber, "select", "N");
                        this.grdOCS1003[aRowNumber, "select"].Image = ImageList.Images[1];

                        this.DeleteOrderBackTable(aRowNumber);
                    }
                    else
                    {
                        this.grdOCS1003.SetItemValue(aRowNumber, "select", "Y");
                        this.grdOCS1003[aRowNumber, "select"].Image = ImageList.Images[0];

                        this.AddOrderBackTable(aRowNumber);
                    }

                    DataRow[] dtRow = this.layOrderInfo.LayoutTable.Select("pkout1001=" + ((Hashtable)this.tabDataGubun.SelectedTab.Tag)["pkout1001"].ToString());

                    if (dtRow.Length > 0)
                    {
                        this.tabDataGubun.SelectedTab.ImageIndex = 0;
                    }
                    else
                    {
                        this.tabDataGubun.SelectedTab.ImageIndex = 1;
                    }
                }
            }
            else
                XMessageBox.Show("【" + this.grdOCS1003.GetItemString(aRowNumber, "hangmog_name") + "】" + "は会計済みなので転入対象オーダではありません。選択できません。", "確認");
        }
        #endregion
        #region [백테이블에 삽입, 삭제]
        private void AddOrderBackTable(int aCurrentRowNumber)
        {
            if (this.IsExistOrderBack(this.grdOCS1003.GetItemString(aCurrentRowNumber, "pkocs1003")))
            {
                return;
            }

            this.layOrderInfo.LayoutTable.ImportRow(this.grdOCS1003.LayoutTable.Rows[aCurrentRowNumber]);
        }
        private void DeleteOrderBackTable(int aCurrentRowNumber)
        {
            int existRowNumber = this.GetExistOrderBackRowNumber(this.grdOCS1003.GetItemString(aCurrentRowNumber, "pkocs1003"));

            if (existRowNumber >= 0)
            {
                this.layOrderInfo.DeleteRow(existRowNumber);
            }
        }
        #endregion
        #region [백테이블오더 체크]
        private bool IsExistOrderBack(string aPkKey)
        {
            for (int i = 0; i < this.layOrderInfo.RowCount; i++)
            {
                if (this.layOrderInfo.GetItemString(i, "pkocs1003") == aPkKey)
                {
                    return true;
                }
            }
            return false;
        }
        private int GetExistOrderBackRowNumber(string aPkKey)
        {
            for (int i = 0; i < this.layOrderInfo.RowCount; i++)
            {
                if (this.layOrderInfo.GetItemString(i, "pkocs1003") == aPkKey)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
        #region [오더 백 테이블 클리어]
        private void ClearOrderBack()
        {
            this.layOrderInfo.Reset();
        }
        #endregion

        #region Status Bar 관련

        private void InitStatusBar(int aMaxValue, bool aIsCancelMode)
        {
            this.pgbStatus.Minimum = 0;
            this.pgbStatus.Maximum = aMaxValue;
            this.pgbStatus.Value = 0;

            if (aIsCancelMode)
            {
                this.lbJobGubun.Text = "▶ 取消処理をしています｡";
            }
            else
            {
                this.lbJobGubun.Text = "▶ 転入処理をしています｡";
            }

            this.lbHangmogName.Text = "";
        }

        private void SetStatusBarVisible(bool aIsVisible)
        {
            this.pnlStatusBar.Visible = aIsVisible;
        }

        private void SetStatusValue(int aValue, string aMsg)
        {
            this.pgbStatus.Value = aValue;

            this.lbHangmogName.Text = aMsg + "( " + aValue.ToString() + "/" + this.pgbStatus.Maximum.ToString() + " )";

            this.pnlStatusBar.Refresh();
            this.pgbStatus.Refresh();
            this.lbHangmogName.Refresh();
        }

        #endregion

        #region 전입 / 전입취소 관련

        private bool ProcessJunip()
        {
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();
            string spName = "PR_OCS_TRANS_ORDER";

            this.mMsg = "転入処理をしますか?";
            this.mCap = "確認";

            if (MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            this.InitStatusBar(this.layOrderInfo.RowCount, false);
            this.SetStatusBarVisible(true);

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            Service.BeginTransaction();

            try
            {
                for (int i = 0; i < this.layOrderInfo.RowCount; i++)
                {
                    this.SetStatusValue((i + 1), this.layOrderInfo.GetItemString(i, "hangmog_name"));

                    inList.Clear();
                    inList.Add("T");
                    inList.Add(this.mPkinp1001);
                    inList.Add(this.layOrderInfo.GetItemString(i, "pkocs1003"));
                    inList.Add(UserInfo.UserID);

                    if (Service.ExecuteProcedure(spName, inList, outList) == false)
                    {
                        this.mMsg = "転入処理に失敗しました｡" + "-" + Service.ErrFullMsg;
                        this.mCap = "処理失敗";

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        Service.RollbackTransaction();

                        return false;
                    }
                    else
                    {
                        if (outList[0].ToString() != "0")
                        {
                            this.mMsg = "転入処理に失敗しました｡" + "-" + Service.ErrFullMsg;
                            this.mCap = "処理失敗";

                            MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Service.RollbackTransaction();

                            return false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();

                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;

                this.SetStatusBarVisible(false);
            }

            Service.CommitTransaction();

            return true;
        }

        private bool ProcessJunipCancel()
        {
            ArrayList inList = new ArrayList();
            ArrayList outList = new ArrayList();
            string spName = "PR_OCS_TRANS_ORDER";

            this.mMsg = "取消処理をしますか?";
            this.mCap = "確認";

            if (MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return false;

            this.InitStatusBar(this.grdOCS2003.RowCount, true);
            this.SetStatusBarVisible(true);

            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            Service.BeginTransaction();

            try
            {
                for (int i = 0; i < this.grdOCS2003.RowCount; i++)
                {
                    this.SetStatusValue((i + 1), this.layOrderInfo.GetItemString(i, "hangmog_name"));

                    if (this.grdOCS2003.GetItemString(i, "select_yn") == "Y")
                    {

                        inList.Clear();
                        inList.Add("C");
                        inList.Add(this.mPkinp1001);
                        inList.Add(this.grdOCS2003.GetItemString(i, "pkocs2003"));
                        inList.Add(UserInfo.UserID);

                        if (Service.ExecuteProcedure(spName, inList, outList) == false)
                        {
                            this.mMsg = "取消処理に失敗しました｡" + "-" + Service.ErrFullMsg;
                            this.mCap = "処理失敗";

                            MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                            Service.RollbackTransaction();

                            return false;
                        }
                        else
                        {
                            if (outList[0].ToString() != "0")
                            {
                                this.mMsg = "取消処理に失敗しました｡" + "-" + Service.ErrFullMsg;
                                this.mCap = "処理失敗";

                                MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                Service.RollbackTransaction();

                                return false;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Service.RollbackTransaction();

                return false;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;

                this.SetStatusBarVisible(false);
            }

            Service.CommitTransaction();

            return true;
        }

        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query :

                    e.IsBaseCall = false;

                    this.AcceptData();

                    this.MakeDataGubunTabPages();

                    grdOCS2003_Load();

                    break;

                case FunctionType.Process:

                    e.IsBaseCall = false;

                    this.AcceptData();

                    if (this.cbxKaikei_yn.Checked == true)
                    {
                        this.mMsg = "会計されたオーダは転入処理できません。会計転送取消しをしてからやり直してください。";
                        this.mCap = "確認";

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (this.layOrderInfo.RowCount <= 0)
                    {
                        this.mMsg = "転入処理をするデータが存在しません｡";
                        this.mCap = "確認";

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (this.ProcessJunip() == true)
                    {
                        this.btnList.PerformClick(FunctionType.Query);
                    }

                    break;

                case FunctionType.Cancel :

                    e.IsBaseCall = false;

                    this.AcceptData();

                    bool isFind = false;

                    for (int i = 0; i < this.grdOCS2003.RowCount; i++)
                    {
                        if (this.grdOCS2003.GetItemString(i, "select_yn") == "Y")
                        {
                            isFind = true;
                            break;
                        }
                    }

                    if (isFind == false)
                    {
                        this.mMsg = "取消処理をするデータが存在しません｡";
                        this.mCap = "確認";

                        MessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (this.ProcessJunipCancel() == true)
                    {
                        this.btnList.PerformClick(FunctionType.Query);
                    }

                    break;
            }
        }

        private void grdOCS2003_MouseDown(object sender, MouseEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            int rowNumber = -1;

            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                rowNumber = grid.GetHitRowNumber(e.Y);

                if (rowNumber < 0) return;

                if (grid.CurrentColName == "select_yn")
                {
                    if (grid.GetItemString(rowNumber, "select_yn") == "Y")
                    {
                        grid.SetItemValue(rowNumber, "select_yn", "N");
                        grid[rowNumber, "select_yn"].Image = this.ImageList.Images[1];
                    }
                    else
                    {
                        grid.SetItemValue(rowNumber, "select_yn", "Y");
                        grid[rowNumber, "select_yn"].Image = this.ImageList.Images[0];
                    }
                }
            }
        }

        private void tabDataGubun_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                IHIS.X.Magic.Controls.TabPage tpg = this.tabDataGubun.TabPageFromPoint(new Point(e.X, e.Y));

                if (tpg == null) return;

                if (tpg.ImageIndex == 1)
                //if (this.tabDataGubun.SelectedTab == null ) return;
                
                //if (this.tabDataGubun.SelectedTab.ImageIndex == 1)
                {
                    for (int i = 0; i < this.grdOCS1003.RowCount; i++)
                    {
                        if (this.grdOCS1003.GetItemString(i, "select") == "N")
                        {
                            this.ClickCurrentOrder(i);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < this.grdOCS1003.RowCount; i++)
                    {
                        if (this.grdOCS1003.GetItemString(i, "select") == "Y")
                        {
                            this.ClickCurrentOrder(i);
                        }
                    }
                }
            }
        }

        private void cbxKaikei_yn_CheckedChanged(object sender, EventArgs e)
        {
            if(this.tabDataGubun.SelectedTab != null)
                grdOCS1003_Load();

        }

        private void grdOCS1003_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["sunab_yn"].ToString() == "Y")
                e.BackColor = Color.LightGray;
        }

        private void grdOCS1003_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.DataRow["sunab_yn"].ToString() == "Y")
                e.Protect = true;
        }
    }
}

