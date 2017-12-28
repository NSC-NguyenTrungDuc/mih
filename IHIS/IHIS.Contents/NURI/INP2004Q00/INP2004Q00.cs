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
	/// INP2004U01에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP2004Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel pnlTop;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell55;
		//private IHIS.Framework.DataServiceSIMO dsvINP1001;
		private IHIS.Framework.XEditGrid grdINP2004;
        //private IHIS.Framework.DataServiceSIMO dsvINP2004;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
		private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XEditGrid grdHoCodeList;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell79;
		private IHIS.Framework.XEditGridCell xEditGridCell80;
		private IHIS.Framework.XEditGridCell xEditGridCell81;
		private IHIS.Framework.XEditGridCell xEditGridCell82;
		private IHIS.Framework.XEditGridCell xEditGridCell83;
		private IHIS.Framework.XEditGridCell xEditGridCell84;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
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
        private XBuseoCombo cboHoDong;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public INP2004Q00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP2004Q00));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.grdINP2004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell79 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell80 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell81 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell82 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell55 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell83 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell84 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdHoCodeList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
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
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoCodeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.cboHoDong);
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.dtpToDate);
            this.pnlTop.Controls.Add(this.dtpFromDate);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.pictureBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(4, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(870, 36);
            this.pnlTop.TabIndex = 0;
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(444, 8);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(14, 20);
            this.xLabel3.TabIndex = 39;
            this.xLabel3.Text = "-";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.IsJapanYearType = true;
            this.dtpToDate.Location = new System.Drawing.Point(458, 8);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(110, 20);
            this.dtpToDate.TabIndex = 38;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.IsJapanYearType = true;
            this.dtpFromDate.Location = new System.Drawing.Point(334, 8);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 20);
            this.dtpFromDate.TabIndex = 37;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(248, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(86, 20);
            this.xLabel1.TabIndex = 36;
            this.xLabel1.Text = "照会期間";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(22, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(86, 21);
            this.xLabel2.TabIndex = 33;
            this.xLabel2.Text = "病棟";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(870, 38);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "ho_dong";
            this.findColumnInfo1.ColWidth = 84;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "病棟";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "ho_dong_name";
            this.findColumnInfo4.ColWidth = 286;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "病棟名";
            // 
            // grdINP2004
            // 
            this.grdINP2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell79,
            this.xEditGridCell80,
            this.xEditGridCell81,
            this.xEditGridCell82,
            this.xEditGridCell55,
            this.xEditGridCell83,
            this.xEditGridCell84,
            this.xEditGridCell6});
            this.grdINP2004.ColPerLine = 9;
            this.grdINP2004.ColResizable = true;
            this.grdINP2004.Cols = 10;
            this.grdINP2004.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP2004.FixedCols = 1;
            this.grdINP2004.FixedRows = 1;
            this.grdINP2004.HeaderHeights.Add(21);
            this.grdINP2004.Location = new System.Drawing.Point(114, 40);
            this.grdINP2004.Name = "grdINP2004";
            this.grdINP2004.QuerySQL = resources.GetString("grdINP2004.QuerySQL");
            this.grdINP2004.ReadOnly = true;
            this.grdINP2004.RowHeaderVisible = true;
            this.grdINP2004.Rows = 2;
            this.grdINP2004.Size = new System.Drawing.Size(760, 555);
            this.grdINP2004.TabIndex = 2;
            this.grdINP2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP2004_QueryStarting);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "fkinp1001";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "fkinp1001";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "bunho";
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.EnableSort = true;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "患者番号";
            // 
            // xEditGridCell79
            // 
            this.xEditGridCell79.CellName = "suname";
            this.xEditGridCell79.CellWidth = 110;
            this.xEditGridCell79.Col = 4;
            this.xEditGridCell79.EnableSort = true;
            this.xEditGridCell79.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell79.HeaderText = "患者氏名";
            // 
            // xEditGridCell80
            // 
            this.xEditGridCell80.CellName = "sex";
            this.xEditGridCell80.CellWidth = 40;
            this.xEditGridCell80.Col = 5;
            this.xEditGridCell80.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell80.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell80.EnableSort = true;
            this.xEditGridCell80.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell80.HeaderText = "性別";
            this.xEditGridCell80.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "男";
            this.xComboItem1.ValueItem = "M";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "女";
            this.xComboItem2.ValueItem = "F";
            // 
            // xEditGridCell81
            // 
            this.xEditGridCell81.CellName = "age";
            this.xEditGridCell81.CellWidth = 40;
            this.xEditGridCell81.Col = 6;
            this.xEditGridCell81.EnableSort = true;
            this.xEditGridCell81.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell81.HeaderText = "年齢";
            this.xEditGridCell81.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell82
            // 
            this.xEditGridCell82.CellName = "birth";
            this.xEditGridCell82.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell82.CellWidth = 100;
            this.xEditGridCell82.Col = 7;
            this.xEditGridCell82.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell82.EnableSort = true;
            this.xEditGridCell82.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell82.HeaderText = "生年月日";
            this.xEditGridCell82.IsJapanYearType = true;
            // 
            // xEditGridCell55
            // 
            this.xEditGridCell55.CellName = "to_bed_no";
            this.xEditGridCell55.CellWidth = 42;
            this.xEditGridCell55.Col = 2;
            this.xEditGridCell55.EnableSort = true;
            this.xEditGridCell55.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell55.HeaderText = "病床";
            this.xEditGridCell55.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell83
            // 
            this.xEditGridCell83.CellName = "ipwon_date";
            this.xEditGridCell83.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell83.CellWidth = 100;
            this.xEditGridCell83.Col = 8;
            this.xEditGridCell83.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell83.EnableSort = true;
            this.xEditGridCell83.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell83.HeaderText = "入院日付";
            this.xEditGridCell83.IsJapanYearType = true;
            // 
            // xEditGridCell84
            // 
            this.xEditGridCell84.CellName = "toiwon_date";
            this.xEditGridCell84.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell84.CellWidth = 100;
            this.xEditGridCell84.Col = 9;
            this.xEditGridCell84.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell84.EnableSort = true;
            this.xEditGridCell84.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell84.HeaderText = "退院日付";
            this.xEditGridCell84.IsJapanYearType = true;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "order_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 100;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "入室日付";
            this.xEditGridCell6.IsJapanYearType = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(4, 40);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 555);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(630, 597);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 4;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdHoCodeList
            // 
            this.grdHoCodeList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2});
            this.grdHoCodeList.ColPerLine = 1;
            this.grdHoCodeList.Cols = 1;
            this.grdHoCodeList.ControlBinding = true;
            this.grdHoCodeList.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdHoCodeList.FixedRows = 1;
            this.grdHoCodeList.HeaderHeights.Add(23);
            this.grdHoCodeList.Location = new System.Drawing.Point(7, 40);
            this.grdHoCodeList.Name = "grdHoCodeList";
            this.grdHoCodeList.QuerySQL = resources.GetString("grdHoCodeList.QuerySQL");
            this.grdHoCodeList.ReadOnly = true;
            this.grdHoCodeList.Rows = 2;
            this.grdHoCodeList.Size = new System.Drawing.Size(107, 555);
            this.grdHoCodeList.TabIndex = 5;
            this.grdHoCodeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHoCodeList_QueryStarting);
            this.grdHoCodeList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHoCodeList_RowFocusChanged);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 4;
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "病室";
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pkinp1001";
            this.multiLayoutItem1.IsUpdItem = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "bunho";
            this.multiLayoutItem2.IsUpdItem = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "suname";
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "sex";
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "age";
            this.multiLayoutItem5.IsUpdItem = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "birth";
            this.multiLayoutItem6.IsUpdItem = true;
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "red_no";
            this.multiLayoutItem7.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "ipwon_date";
            this.multiLayoutItem8.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "toiwon_date";
            this.multiLayoutItem9.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "order_date";
            this.multiLayoutItem10.DataType = IHIS.Framework.DataType.Date;
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHoDong.Location = new System.Drawing.Point(107, 8);
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(121, 21);
            this.cboHoDong.TabIndex = 40;
            this.cboHoDong.SelectionChangeCommitted += new System.EventHandler(this.cboHoDong_SelectionChangeCommitted);
            // 
            // INP2004Q00
            // 
            this.Controls.Add(this.grdINP2004);
            this.Controls.Add(this.grdHoCodeList);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlTop);
            this.Name = "INP2004Q00";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(878, 635);
            this.Load += new System.EventHandler(this.INP2004Q00_Load);
            this.UserChanged += new System.EventHandler(this.INP2004U01_UserChanged);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP2004)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoCodeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수

		private string mMsg = "";
		//private string mCaption = "";

		#endregion


		#region 환자 번호를 받아온다

        //public override void OnReceiveBunHo(XPatientInfo info)
        //{
        //    this.btnList.PerformClick(FunctionType.Reset);

        //    if (info.HoDong != "")
        //    {
        //        this.fbxHoDong.SetEditValue(info.HoDong);
        //        this.fbxHoDong.AcceptData();
        //    }

        //    base.OnReceiveBunHo(info);
        //}

		#endregion

		#region 사용자 변경

		private void INP2004U01_UserChanged(object sender, System.EventArgs e)
		{
			this.btnList.PerformClick(FunctionType.Reset);
		}

		#endregion

		#region 그리드
		private void grdHoCodeList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if ( e.CurrentRow < 0 ) 
                return;

            LoadDataINP2004();
			
		}
		#endregion

		#region LoadData
		private void LoadDataINP2004()
		{
			if (   TypeCheck.IsNull( this.cboHoDong.GetDataValue() ) 
				|| TypeCheck.IsNull( dtpFromDate.GetDataValue() )
				|| TypeCheck.IsNull( dtpToDate.GetDataValue() ) 
				|| TypeCheck.IsNull( grdHoCodeList.GetItemString(grdHoCodeList.CurrentRowNumber, "ho_code") ) )
			{
				return;
			}
            this.grdINP2004.QueryLayout(true);
		}
		
		private void LoadDataINP1001()
		{
            if (TypeCheck.IsNull(cboHoDong.GetDataValue()) 
				|| TypeCheck.IsNull( dtpFromDate.GetDataValue() )
				|| TypeCheck.IsNull( dtpToDate.GetDataValue() ) )
			{
				return;
			}
            this.grdHoCodeList.QueryLayout(true);
		}
		#endregion

		#region 버튼리스트
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;
					LoadDataINP2004();
					break;
			}
		}
		#endregion

		private void INP2004Q00_Load(object sender, System.EventArgs e)
		{
			dtpFromDate.SetDataValue( EnvironInfo.GetSysDate().ToString("yyyy/MM") + "/01" );
			dtpToDate.SetDataValue( DateTime.Parse( EnvironInfo.GetSysDate().AddMonths(1).ToString("yyyy/MM") + "/01").AddDays(-1) );

            if (UserInfo.HoDong != "")
                this.cboHoDong.SetDataValue(UserInfo.HoDong);
            else
                this.cboHoDong.SetDataValue("1");
            LoadDataINP1001();


		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if ( TypeCheck.IsNull( e.DataValue ) ) return;

			dtpToDate.SetDataValue(DateTime.Parse( DateTime.Parse(e.DataValue).AddMonths(1).ToString("yyyy/MM") + "/01").AddDays(-1) );

			LoadDataINP1001();
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			if ( TypeCheck.IsNull( e.DataValue ) ) return;

			if ( TypeCheck.IsNull( dtpFromDate.GetDataValue() ) )
			{
				mMsg = (NetInfo.Language == LangMode.Ko ? "시작일자를 입력해 주세요." : "開始日付けを入力してください。");
				XMessageBox.Show( mMsg );
				dtpFromDate.Focus();
				return;
			}

			if ( DateTime.Parse( dtpFromDate.GetDataValue() ) > DateTime.Parse( dtpToDate.GetDataValue() ) )
			{
				mMsg = (NetInfo.Language == LangMode.Ko ? "종료일자가 시작일자보다 작을 수는 없습니다." : "修了日付は開始日付以降の日付を入力してください。");
				XMessageBox.Show( mMsg );

				dtpToDate.SetDataValue(DateTime.Parse( DateTime.Parse(dtpFromDate.GetDataValue()).AddMonths(1).ToString("yyyy/MM") + "/01").AddDays(-1) );
				dtpToDate.Focus();
				return;

			}

			LoadDataINP1001();
		}

        private void grdHoCodeList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHoCodeList.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHoCodeList.SetBindVarValue("f_jukyong_date", this.dtpFromDate.GetDataValue());
            this.grdHoCodeList.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
  
        }
  
        private void grdINP2004_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP2004.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdINP2004.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
            this.grdINP2004.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
            this.grdINP2004.SetBindVarValue("f_ho_code", this.grdHoCodeList.GetItemValue(this.grdHoCodeList.CurrentRowNumber, "ho_code").ToString());
  
        }

        private void cboHoDong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadDataINP1001();

        }

	}
}

