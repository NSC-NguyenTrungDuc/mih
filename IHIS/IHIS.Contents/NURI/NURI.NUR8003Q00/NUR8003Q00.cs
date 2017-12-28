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
	/// DRG3010Q12에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR8003Q00 : IHIS.Framework.XScreen
	{
        #region 화면변수
        private int DayCounts = 0;
        #endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XButtonList btnList;
        private SingleLayout layCommon;
        private XLabel lblHo_dong;
        private XMonthBox mbxMonth;
        private XLabel xLabel2;
        private XDictComboBox cboBuseo;
        private XEditGrid grdNUR8003;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XPanel pnlFill;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XLabel lblPer;
        private XLabel lblCnt;
        private XDisplayBox dbxCntSum;
        private XDisplayBox dbxPerAvg;
        private XLabel xLabel1;
        private XDisplayBox dbxCntAvg;
        private XEditGrid grdWrited;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell21;
        private XGridHeader xGridHeader1;
        private MultiLayout layWritedHodong;
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
        private MultiLayoutItem multiLayoutItem12;
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
        private MultiLayoutItem multiLayoutItem33;
        private XEditGridCell xEditGridCell6;
		private System.ComponentModel.IContainer components;
		#endregion

		#region 생성자
		public NUR8003Q00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR8003Q00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.cboBuseo = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.mbxMonth = new IHIS.Framework.XMonthBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.dbxCntAvg = new IHIS.Framework.XDisplayBox();
            this.dbxCntSum = new IHIS.Framework.XDisplayBox();
            this.lblPer = new IHIS.Framework.XLabel();
            this.dbxPerAvg = new IHIS.Framework.XDisplayBox();
            this.lblCnt = new IHIS.Framework.XLabel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.grdNUR8003 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.grdWrited = new IHIS.Framework.XEditGrid();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.layWritedHodong = new IHIS.Framework.MultiLayout();
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
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem33 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8003)).BeginInit();
            this.pnlFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWrited)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWritedHodong)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "");
            this.ImageList.Images.SetKeyName(1, "");
            this.ImageList.Images.SetKeyName(2, "");
            this.ImageList.Images.SetKeyName(3, "");
            this.ImageList.Images.SetKeyName(4, "앞으로.gif");
            this.ImageList.Images.SetKeyName(5, "excel.ico");
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblHo_dong);
            this.pnlTop.Controls.Add(this.cboBuseo);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.mbxMonth);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1465, 40);
            this.pnlTop.TabIndex = 0;
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(3, 12);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(70, 21);
            this.lblHo_dong.TabIndex = 26;
            this.lblHo_dong.Text = "病    棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboBuseo
            // 
            this.cboBuseo.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboBuseo.Location = new System.Drawing.Point(74, 12);
            this.cboBuseo.Name = "cboBuseo";
            this.cboBuseo.Size = new System.Drawing.Size(75, 21);
            this.cboBuseo.TabIndex = 29;
            this.cboBuseo.SelectedIndexChanged += new System.EventHandler(this.cboBuseo_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "A";
            this.xComboItem1.ValueItem = "A";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "C3";
            this.xComboItem2.ValueItem = "C3";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(155, 13);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(70, 20);
            this.xLabel2.TabIndex = 28;
            this.xLabel2.Text = "照会月";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mbxMonth
            // 
            this.mbxMonth.Location = new System.Drawing.Point(231, 13);
            this.mbxMonth.Name = "mbxMonth";
            this.mbxMonth.Size = new System.Drawing.Size(122, 21);
            this.mbxMonth.TabIndex = 1;
            this.mbxMonth.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.mbxMonth_PrevButtonClick);
            this.mbxMonth.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.mbxMonth_NextButtonClick);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.xLabel1);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Controls.Add(this.dbxCntAvg);
            this.pnlBottom.Controls.Add(this.dbxCntSum);
            this.pnlBottom.Controls.Add(this.lblPer);
            this.pnlBottom.Controls.Add(this.dbxPerAvg);
            this.pnlBottom.Controls.Add(this.lblCnt);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 657);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1465, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(147, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(63, 21);
            this.xLabel1.TabIndex = 11;
            this.xLabel1.Text = "平均人数";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, "Excel", 5, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.ImageList = this.ImageList;
            this.btnList.Location = new System.Drawing.Point(1221, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(244, 35);
            this.btnList.TabIndex = 0;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // dbxCntAvg
            // 
            this.dbxCntAvg.Location = new System.Drawing.Point(214, 8);
            this.dbxCntAvg.Name = "dbxCntAvg";
            this.dbxCntAvg.Size = new System.Drawing.Size(43, 21);
            this.dbxCntAvg.TabIndex = 10;
            this.dbxCntAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxCntSum
            // 
            this.dbxCntSum.Location = new System.Drawing.Point(76, 7);
            this.dbxCntSum.Name = "dbxCntSum";
            this.dbxCntSum.Size = new System.Drawing.Size(63, 21);
            this.dbxCntSum.TabIndex = 3;
            this.dbxCntSum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPer
            // 
            this.lblPer.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblPer.EdgeRounding = false;
            this.lblPer.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPer.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblPer.Location = new System.Drawing.Point(265, 7);
            this.lblPer.Name = "lblPer";
            this.lblPer.Size = new System.Drawing.Size(63, 21);
            this.lblPer.TabIndex = 9;
            this.lblPer.Text = "％　平均";
            this.lblPer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxPerAvg
            // 
            this.dbxPerAvg.Location = new System.Drawing.Point(332, 7);
            this.dbxPerAvg.Name = "dbxPerAvg";
            this.dbxPerAvg.Size = new System.Drawing.Size(43, 21);
            this.dbxPerAvg.TabIndex = 0;
            this.dbxPerAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCnt
            // 
            this.lblCnt.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblCnt.EdgeRounding = false;
            this.lblCnt.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCnt.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblCnt.Location = new System.Drawing.Point(9, 7);
            this.lblCnt.Name = "lblCnt";
            this.lblCnt.Size = new System.Drawing.Size(63, 21);
            this.lblCnt.TabIndex = 8;
            this.lblCnt.Text = "合計";
            this.lblCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdNUR8003
            // 
            this.grdNUR8003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell2});
            this.grdNUR8003.ColPerLine = 3;
            this.grdNUR8003.Cols = 3;
            this.grdNUR8003.Dock = System.Windows.Forms.DockStyle.Right;
            this.grdNUR8003.FixedRows = 1;
            this.grdNUR8003.HeaderHeights.Add(21);
            this.grdNUR8003.Location = new System.Drawing.Point(1236, 0);
            this.grdNUR8003.Name = "grdNUR8003";
            this.grdNUR8003.QuerySQL = resources.GetString("grdNUR8003.QuerySQL");
            this.grdNUR8003.Rows = 2;
            this.grdNUR8003.Size = new System.Drawing.Size(229, 617);
            this.grdNUR8003.TabIndex = 27;
            this.grdNUR8003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR8003_QueryEnd);
            this.grdNUR8003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR8003_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "write_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 91;
            this.xEditGridCell1.HeaderText = "日付";
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "cnt";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.HeaderText = "count";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "all_cnt";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderText = "all_cnt";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "per";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 41;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.HeaderText = "％";
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "pa_cnt";
            this.xEditGridCell2.CellWidth = 77;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.HeaderText = "患者数";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdWrited);
            this.pnlFill.Controls.Add(this.grdNUR8003);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 40);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1465, 617);
            this.pnlFill.TabIndex = 28;
            // 
            // grdWrited
            // 
            this.grdWrited.AddedHeaderLine = 1;
            this.grdWrited.ApplyPaintEventToAllColumn = true;
            this.grdWrited.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell6});
            this.grdWrited.ColPerLine = 3;
            this.grdWrited.Cols = 4;
            this.grdWrited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWrited.FixedCols = 1;
            this.grdWrited.FixedRows = 2;
            this.grdWrited.HeaderHeights.Add(21);
            this.grdWrited.HeaderHeights.Add(21);
            this.grdWrited.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdWrited.Location = new System.Drawing.Point(0, 0);
            this.grdWrited.Name = "grdWrited";
            this.grdWrited.QuerySQL = resources.GetString("grdWrited.QuerySQL");
            this.grdWrited.ReadOnly = true;
            this.grdWrited.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdWrited.RowHeaderVisible = true;
            this.grdWrited.Rows = 3;
            this.grdWrited.RowStateCheckOnPaint = false;
            this.grdWrited.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdWrited.Size = new System.Drawing.Size(1236, 617);
            this.grdWrited.TabIndex = 28;
            this.grdWrited.ToolTipActive = true;
            this.grdWrited.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdWrited_QueryStarting);
            this.grdWrited.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdWrited_GridCellPainting);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bunho";
            this.xEditGridCell28.CellWidth = 70;
            this.xEditGridCell28.Col = 1;
            this.xEditGridCell28.HeaderText = "患者番号";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.RowSpan = 2;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "suname";
            this.xEditGridCell29.CellWidth = 100;
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.HeaderText = "患者名";
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.RowSpan = 2;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "01";
            this.xEditGridCell6.CellWidth = 35;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.HeaderText = "1";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.Row = 1;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.HeaderText = "a";
            this.xGridHeader1.HeaderWidth = 16;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "cont_key";
            this.xEditGridCell27.CellWidth = 14;
            this.xEditGridCell27.Col = 10;
            this.xEditGridCell27.IsReadOnly = true;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "antibiotic_yn";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.xEditGridCell25.CellName = "dv";
            this.xEditGridCell25.CellWidth = 30;
            this.xEditGridCell25.Col = 6;
            this.xEditGridCell25.HeaderText = "回数";
            this.xEditGridCell25.IsReadOnly = true;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "dv_time";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "ho_code";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "mix_group";
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "in_out";
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // layWritedHodong
            // 
            this.layWritedHodong.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
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
            this.multiLayoutItem12,
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
            this.multiLayoutItem33});
            this.layWritedHodong.QuerySQL = resources.GetString("layWritedHodong.QuerySQL");
            this.layWritedHodong.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layWritedHodong_QueryStarting);
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
            this.multiLayoutItem3.DataName = "01";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "02";
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "03";
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "04";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "05";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "06";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "07";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "08";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "09";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "10";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "11";
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "12";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "13";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "14";
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "15";
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "16";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "17";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "18";
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "19";
            // 
            // multiLayoutItem22
            // 
            this.multiLayoutItem22.DataName = "20";
            // 
            // multiLayoutItem23
            // 
            this.multiLayoutItem23.DataName = "21";
            // 
            // multiLayoutItem24
            // 
            this.multiLayoutItem24.DataName = "22";
            // 
            // multiLayoutItem25
            // 
            this.multiLayoutItem25.DataName = "23";
            // 
            // multiLayoutItem26
            // 
            this.multiLayoutItem26.DataName = "24";
            // 
            // multiLayoutItem27
            // 
            this.multiLayoutItem27.DataName = "25";
            // 
            // multiLayoutItem28
            // 
            this.multiLayoutItem28.DataName = "26";
            // 
            // multiLayoutItem29
            // 
            this.multiLayoutItem29.DataName = "27";
            // 
            // multiLayoutItem30
            // 
            this.multiLayoutItem30.DataName = "28";
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "29";
            // 
            // multiLayoutItem32
            // 
            this.multiLayoutItem32.DataName = "30";
            // 
            // multiLayoutItem33
            // 
            this.multiLayoutItem33.DataName = "31";
            // 
            // NUR8003Q00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR8003Q00";
            this.Size = new System.Drawing.Size(1465, 692);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR8003Q00_ScreenOpen);
            this.pnlTop.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8003)).EndInit();
            this.pnlFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWrited)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layWritedHodong)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #region 메세지처리 同期化完了
        /// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "user_id":
					msg = NetInfo.Language == LangMode.Ko ? "간호확인 ID가 정확하지 않습니다. 확인해 주세요."
						: "看護確認IDが正確ではありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "nurse_confirm_enable":
					msg = NetInfo.Language == LangMode.Ko ? "오더확인권한이 없습니다. 확인바랍니다."
						: "オーダ確認権限がありません。ご確認ください。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bannab_yn":
					msg = NetInfo.Language == LangMode.Ko ? "해당 오다는 반납처리를 할 수 없는 오다입니다."
						: "該当オーダは返却処理不可能なオーダです。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "確認";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存完了";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。";
					msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存失敗";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				case "bannab_true":
					msg = NetInfo.Language == LangMode.Ko ? "처리가 완료되었습니다."
						: "処理が完了しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림"
                        : "保存完了";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				default:
					break;
			}
		}
		#endregion

		#region Screen Load 同期化完了
		private void NUR8003Q00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            int width = this.Width;
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            if (rc.Width - 30 > this.Width)
            {
                width = rc.Width - 30;
            }
            this.ParentForm.Size = new System.Drawing.Size(width, rc.Height - 105);

            this.initProc();

            this.DisplayDate();

            btnList.PerformClick(FunctionType.Query);
		}
		#endregion

        #region [initProc]
        private void initProc()
        {
            this.CurrMQLayout = this.grdNUR8003;
            this.cboBuseo.SelectedIndex = 0;
            this.mbxMonth.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
        }
        #endregion

        #region 버튼리스트에서 클릭을 했을 때 同期化完了2
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
                case FunctionType.Process:
                    e.IsBaseCall = false;

                    this.grdWrited.Export(true, true);
                   
                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        grdWrited.QueryLayout(true);
                        grdNUR8003.QueryLayout(true);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Arrow;
                    }
                    break;

				default:
					break;
			}
		}
		#endregion


        #region [照会月　変更]
        private void mbxMonth_NextButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            DisplayDate();
            this.btnList.PerformClick(FunctionType.Query);
        }

        private void mbxMonth_PrevButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            DisplayDate();
            this.btnList.PerformClick(FunctionType.Query);
        }

        #endregion

        private void grdNUR8003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR8003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR8003.SetBindVarValue("f_ho_dong", cboBuseo.GetDataValue());
            this.grdNUR8003.SetBindVarValue("f_query_date", this.mbxMonth.GetDataValue().Replace("-", "").Replace("/", "") + "01");
        }

        private void cboBuseo_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnList.PerformClick(FunctionType.Query);
        }

        private void grdNUR8003_QueryEnd(object sender, QueryEndEventArgs e)
        {            
            if (grdNUR8003.RowCount > 0)
            {
                int cntSumC = 0;
                int cntSumA = 0;
                int perSum = 0;

                for (int i = 0; i < grdNUR8003.RowCount; i++)
                {
                    cntSumC += grdNUR8003.GetItemInt(i, "cnt");
                    cntSumA += grdNUR8003.GetItemInt(i, "all_cnt");
                    perSum += grdNUR8003.GetItemInt(i, "per");
                }
                                
                
                dbxCntSum.Text = cntSumC.ToString() + "/" + cntSumA.ToString();
                dbxCntAvg.Text = (Math.Round(((double)cntSumC / (double)grdNUR8003.RowCount),0)).ToString() + "/" 
                               + (Math.Round(((double)cntSumA / (double)grdNUR8003.RowCount),0)).ToString();
                dbxPerAvg.Text = (Math.Round(((double)perSum / (double)grdNUR8003.RowCount),0)).ToString() + "%";
            }
        }

        private void DisplayDate()
        {
            int num;
            for (num = this.DayCounts; num > 1; num--)
            {
                this.grdWrited.CellInfos.Remove(this.grdWrited.CellInfos[1 + num]);
                this.grdWrited.Cols--;
                this.grdWrited.ColPerLine--;
            }
            this.grdWrited.InitializeColumns();
            string str = this.mbxMonth.GetDataValue() + "01";
            DateTime time = Convert.ToDateTime(str.Substring(0, 4) + "/" + str.Substring(4, 2) + "/" + str.Substring(6, 2));
            this.DayCounts = DateTime.DaysInMonth(time.Year, time.Month);
            this.xGridHeader1.HeaderText = time.Month.ToString() + "月";
            this.xGridHeader1.ColSpan = this.DayCounts;

            for (num = 1; num < this.DayCounts; num++)
            {
                XEditGridCell cellInfo = new XEditGridCell();
                int num2 = num + 1;
                cellInfo.CellName = num2.ToString().PadLeft(2, '0');
                cellInfo.Col = 3 + num;
                cellInfo.CellWidth = 35;
                cellInfo.HeaderText = time.AddDays((double)num).Day.ToString();
                cellInfo.RowSpan = 1;
                cellInfo.Row = 1;
                cellInfo.TextAlignment = ContentAlignment.MiddleCenter;

                this.grdWrited.Cols++;
                this.grdWrited.ColPerLine++;
                this.grdWrited.CellInfos.Add(cellInfo);
            }
            
            this.grdWrited.InitializeColumns();

        }

        private void grdWrited_QueryStarting(object sender, CancelEventArgs e)
        {
            layWritedHodong.QueryLayout(true);

            grdWrited.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdWrited.SetBindVarValue("f_date", mbxMonth.GetDataValue());
            grdWrited.SetBindVarValue("f_ho_dong", cboBuseo.GetDataValue());
        }

        private void layWritedHodong_QueryStarting(object sender, CancelEventArgs e)
        {
            layWritedHodong.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layWritedHodong.SetBindVarValue("f_date", mbxMonth.GetDataValue());
            layWritedHodong.SetBindVarValue("f_ho_dong", cboBuseo.GetDataValue());
        }

        private void grdWrited_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (layWritedHodong.GetItemString(e.RowNumber, e.ColName) == cboBuseo.GetDataValue())
            {
                e.BackColor = Color.LightSkyBlue;
            }
            else if(layWritedHodong.GetItemString(e.RowNumber, e.ColName) == "C3" 
                || layWritedHodong.GetItemString(e.RowNumber, e.ColName) == "A")

            {
                e.BackColor = Color.LightPink;
                grdWrited.SetItemValue(e.RowNumber, e.ColName, "-");
            }
            else if (e.ColName != "bunho" && e.ColName != "suname")
            {
                grdWrited.SetItemValue(e.RowNumber, e.ColName, "-");
            }
        }
    }
}

