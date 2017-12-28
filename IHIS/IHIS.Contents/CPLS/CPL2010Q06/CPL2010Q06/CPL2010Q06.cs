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

namespace IHIS.CPLS
{
	/// <summary>
	/// CPL2010Q06에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class CPL2010Q06 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel6;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XPanel xPanel5;
		private IHIS.Framework.XPanel xPanel8;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGrid grdHangmog;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XDatePicker dtpFromDate;
		private IHIS.Framework.XDatePicker dtpToDate;
		private System.Windows.Forms.Label label1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private System.Windows.Forms.GroupBox groupBox1;
		private IHIS.Framework.XRadioButton rbxAll;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XRadioButton rbxOut;
		private IHIS.Framework.XRadioButton rbxInp;
		private IHIS.Framework.XFindBox fbxGumsa;
		private IHIS.Framework.XDisplayBox dbxGumsaName;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.SingleLayout vsvGumsa;
		private IHIS.Framework.XFindWorker fwkGumsa;
		private IHIS.Framework.FindColumnInfo findColumnInfo9;
		private IHIS.Framework.FindColumnInfo findColumnInfo10;
		private IHIS.Framework.XBuseoCombo BuseoCombo;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XComboBox cboSex;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
        private SingleLayoutItem singleLayoutItem1;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CPL2010Q06()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL2010Q06));
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.cboSex = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.BuseoCombo = new IHIS.Framework.XBuseoCombo();
            this.fbxGumsa = new IHIS.Framework.XFindBox();
            this.fwkGumsa = new IHIS.Framework.XFindWorker();
            this.findColumnInfo9 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo10 = new IHIS.Framework.FindColumnInfo();
            this.dbxGumsaName = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbxOut = new IHIS.Framework.XRadioButton();
            this.rbxAll = new IHIS.Framework.XRadioButton();
            this.rbxInp = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdHangmog = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.vsvGumsa = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuseoCombo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).BeginInit();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
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
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.cboSex);
            this.xPanel6.Controls.Add(this.xLabel3);
            this.xPanel6.Controls.Add(this.BuseoCombo);
            this.xPanel6.Controls.Add(this.fbxGumsa);
            this.xPanel6.Controls.Add(this.dbxGumsaName);
            this.xPanel6.Controls.Add(this.xLabel2);
            this.xPanel6.Controls.Add(this.groupBox1);
            this.xPanel6.Controls.Add(this.xLabel1);
            this.xPanel6.Controls.Add(this.dtpToDate);
            this.xPanel6.Controls.Add(this.dtpFromDate);
            this.xPanel6.Controls.Add(this.xLabel9);
            this.xPanel6.Controls.Add(this.label1);
            this.xPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel6.DrawBorder = true;
            this.xPanel6.Location = new System.Drawing.Point(5, 5);
            this.xPanel6.Name = "xPanel6";
            this.xPanel6.Size = new System.Drawing.Size(950, 35);
            this.xPanel6.TabIndex = 9;
            // 
            // cboSex
            // 
            this.cboSex.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cboSex.Location = new System.Drawing.Point(738, 6);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(48, 21);
            this.cboSex.TabIndex = 37;
            this.cboSex.SelectedIndexChanged += new System.EventHandler(this.cboSex_SelectedIndexChanged);
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "全体";
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "男";
            this.xComboItem2.ValueItem = "M";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "女";
            this.xComboItem3.ValueItem = "F";
            // 
            // xLabel3
            // 
            this.xLabel3.Location = new System.Drawing.Point(702, 6);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(34, 20);
            this.xLabel3.TabIndex = 36;
            this.xLabel3.Text = "性別";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuseoCombo
            // 
            this.BuseoCombo.IsAppendAll = true;
            this.BuseoCombo.Location = new System.Drawing.Point(592, 6);
            this.BuseoCombo.Name = "BuseoCombo";
            this.BuseoCombo.Size = new System.Drawing.Size(108, 21);
            this.BuseoCombo.TabIndex = 35;
            this.BuseoCombo.SelectedIndexChanged += new System.EventHandler(this.BuseoCombo_SelectedIndexChanged);
            // 
            // fbxGumsa
            // 
            this.fbxGumsa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGumsa.FindWorker = this.fwkGumsa;
            this.fbxGumsa.Location = new System.Drawing.Point(304, 6);
            this.fbxGumsa.MaxLength = 10;
            this.fbxGumsa.Name = "fbxGumsa";
            this.fbxGumsa.Size = new System.Drawing.Size(80, 20);
            this.fbxGumsa.TabIndex = 32;
            this.fbxGumsa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGumsa_DataValidating);
            // 
            // fwkGumsa
            // 
            this.fwkGumsa.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo9,
            this.findColumnInfo10});
            this.fwkGumsa.FormText = "検査項目照会";
            this.fwkGumsa.InputSQL = resources.GetString("fwkGumsa.InputSQL");
            this.fwkGumsa.SearchImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fwkGumsa.ServerFilter = true;
            this.fwkGumsa.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkGumsa_QueryStarting);
            // 
            // findColumnInfo9
            // 
            this.findColumnInfo9.ColName = "gubun";
            this.findColumnInfo9.ColWidth = 106;
            this.findColumnInfo9.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo9.HeaderText = "検査項目コード";
            // 
            // findColumnInfo10
            // 
            this.findColumnInfo10.ColName = "gubun_name";
            this.findColumnInfo10.ColWidth = 315;
            this.findColumnInfo10.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo10.HeaderText = "検査項目名";
            // 
            // dbxGumsaName
            // 
            this.dbxGumsaName.Location = new System.Drawing.Point(386, 6);
            this.dbxGumsaName.Name = "dbxGumsaName";
            this.dbxGumsaName.Size = new System.Drawing.Size(168, 21);
            this.dbxGumsaName.TabIndex = 34;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(238, 6);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(64, 20);
            this.xLabel2.TabIndex = 33;
            this.xLabel2.Text = "検査項目";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbxOut);
            this.groupBox1.Controls.Add(this.rbxAll);
            this.groupBox1.Controls.Add(this.rbxInp);
            this.groupBox1.Location = new System.Drawing.Point(790, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 30);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            // 
            // rbxOut
            // 
            this.rbxOut.Location = new System.Drawing.Point(54, 8);
            this.rbxOut.Name = "rbxOut";
            this.rbxOut.Size = new System.Drawing.Size(50, 18);
            this.rbxOut.TabIndex = 1;
            this.rbxOut.Text = "外来";
            this.rbxOut.UseVisualStyleBackColor = false;
            this.rbxOut.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxAll
            // 
            this.rbxAll.Checked = true;
            this.rbxAll.Location = new System.Drawing.Point(4, 8);
            this.rbxAll.Name = "rbxAll";
            this.rbxAll.Size = new System.Drawing.Size(50, 18);
            this.rbxAll.TabIndex = 0;
            this.rbxAll.TabStop = true;
            this.rbxAll.Text = "全体";
            this.rbxAll.UseVisualStyleBackColor = false;
            this.rbxAll.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // rbxInp
            // 
            this.rbxInp.Location = new System.Drawing.Point(104, 8);
            this.rbxInp.Name = "rbxInp";
            this.rbxInp.Size = new System.Drawing.Size(50, 18);
            this.rbxInp.TabIndex = 2;
            this.rbxInp.Text = "入院";
            this.rbxInp.UseVisualStyleBackColor = false;
            this.rbxInp.CheckedChanged += new System.EventHandler(this.rbx_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(556, 6);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(34, 20);
            this.xLabel1.TabIndex = 24;
            this.xLabel1.Text = "科別";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(144, 6);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 20);
            this.dtpToDate.TabIndex = 21;
            this.dtpToDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(42, 6);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 20);
            this.dtpFromDate.TabIndex = 20;
            this.dtpFromDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel9
            // 
            this.xLabel9.Location = new System.Drawing.Point(4, 6);
            this.xLabel9.Name = "xLabel9";
            this.xLabel9.Size = new System.Drawing.Size(36, 20);
            this.xLabel9.TabIndex = 7;
            this.xLabel9.Text = "日付";
            this.xLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(134, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "~";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdHangmog);
            this.xPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel5.Location = new System.Drawing.Point(0, 0);
            this.xPanel5.Name = "xPanel5";
            this.xPanel5.Size = new System.Drawing.Size(948, 507);
            this.xPanel5.TabIndex = 3;
            // 
            // grdHangmog
            // 
            this.grdHangmog.ApplyPaintEventToAllColumn = true;
            this.grdHangmog.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell13,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell8,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell3,
            this.xEditGridCell7});
            this.grdHangmog.ColPerLine = 13;
            this.grdHangmog.ColResizable = true;
            this.grdHangmog.Cols = 14;
            this.grdHangmog.ControlBinding = true;
            this.grdHangmog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdHangmog.FixedCols = 1;
            this.grdHangmog.FixedRows = 1;
            this.grdHangmog.HeaderHeights.Add(21);
            this.grdHangmog.Location = new System.Drawing.Point(0, 0);
            this.grdHangmog.Name = "grdHangmog";
            this.grdHangmog.QuerySQL = resources.GetString("grdHangmog.QuerySQL");
            this.grdHangmog.RowHeaderVisible = true;
            this.grdHangmog.Rows = 2;
            this.grdHangmog.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdHangmog.Size = new System.Drawing.Size(946, 505);
            this.grdHangmog.TabIndex = 1;
            this.grdHangmog.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHangmog_QueryStarting);
            this.grdHangmog.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHangmog_GridCellPainting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "part_jubsu_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.CellWidth = 83;
            this.xEditGridCell11.Col = 1;
            this.xEditGridCell11.HeaderText = "パート受付日";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.SuppressRepeating = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "bunho";
            this.xEditGridCell13.CellWidth = 82;
            this.xEditGridCell13.Col = 2;
            this.xEditGridCell13.HeaderText = "患者番号";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.SuppressRepeating = true;
            this.xEditGridCell13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellLen = 30;
            this.xEditGridCell15.CellName = "suname";
            this.xEditGridCell15.CellWidth = 92;
            this.xEditGridCell15.Col = 3;
            this.xEditGridCell15.HeaderText = "氏名";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.SuppressRepeating = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "hangmog_code";
            this.xEditGridCell16.CellWidth = 59;
            this.xEditGridCell16.Col = 4;
            this.xEditGridCell16.HeaderText = "項目コード";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellLen = 100;
            this.xEditGridCell17.CellName = "gumsa_name";
            this.xEditGridCell17.CellWidth = 203;
            this.xEditGridCell17.Col = 5;
            this.xEditGridCell17.HeaderText = "検査名";
            this.xEditGridCell17.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell18.CellName = "order_yn";
            this.xEditGridCell18.CellWidth = 65;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.HeaderText = "未採血";
            this.xEditGridCell18.IsReadOnly = true;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell19.CellName = "chehyul_yn";
            this.xEditGridCell19.CellWidth = 65;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.HeaderText = "採血";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell21.CellName = "part_jub_yn";
            this.xEditGridCell21.CellWidth = 65;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "検査中";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell22.CellName = "result_yn";
            this.xEditGridCell22.CellWidth = 65;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "結果";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.ButtonScheme = IHIS.Framework.XButtonSchemes.Silver;
            this.xEditGridCell20.CellName = "confirm_yn";
            this.xEditGridCell20.CellWidth = 65;
            this.xEditGridCell20.Col = -1;
            this.xEditGridCell20.HeaderText = "確認";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "print_yn";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "印刷";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "cpl_result";
            this.xEditGridCell6.CellWidth = 52;
            this.xEditGridCell6.Col = 7;
            this.xEditGridCell6.HeaderText = "結果値";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "gwa_name";
            this.xEditGridCell9.CellWidth = 84;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.HeaderText = "科/病棟";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.SuppressRepeating = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.CellName = "order";
            this.xEditGridCell1.CellWidth = 41;
            this.xEditGridCell1.Col = 8;
            this.xEditGridCell1.HeaderText = "未採血";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.CellName = "chehyul";
            this.xEditGridCell2.CellWidth = 41;
            this.xEditGridCell2.Col = 9;
            this.xEditGridCell2.HeaderText = "採血";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.CellName = "part_jub";
            this.xEditGridCell4.CellWidth = 41;
            this.xEditGridCell4.Col = 10;
            this.xEditGridCell4.HeaderText = "検査中";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.CellName = "result";
            this.xEditGridCell5.CellWidth = 41;
            this.xEditGridCell5.Col = 11;
            this.xEditGridCell5.HeaderText = "結果";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.CellName = "confirm";
            this.xEditGridCell3.CellWidth = 41;
            this.xEditGridCell3.Col = 12;
            this.xEditGridCell3.HeaderText = "確認";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.CellName = "print";
            this.xEditGridCell7.CellWidth = 41;
            this.xEditGridCell7.Col = 13;
            this.xEditGridCell7.HeaderText = "印刷";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.btnList);
            this.xPanel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel8.DrawBorder = true;
            this.xPanel8.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel8.Location = new System.Drawing.Point(0, 507);
            this.xPanel8.Name = "xPanel8";
            this.xPanel8.Size = new System.Drawing.Size(948, 36);
            this.xPanel8.TabIndex = 5;
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.IsVisibleReset = false;
            this.btnList.Location = new System.Drawing.Point(778, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(163, 34);
            this.btnList.TabIndex = 0;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.xPanel8);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F);
            this.xPanel1.Location = new System.Drawing.Point(5, 40);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(950, 545);
            this.xPanel1.TabIndex = 0;
            // 
            // vsvGumsa
            // 
            this.vsvGumsa.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.vsvGumsa.QuerySQL = "SELECT GUMSA_NAME\r\n  FROM CPL0101\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND HANGMO" +
                "G_CODE = :f_code";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxGumsaName;
            this.singleLayoutItem1.DataName = "dbxGumsaName";
            // 
            // CPL2010Q06
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel6);
            this.Name = "CPL2010Q06";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.xPanel6.ResumeLayout(false);
            this.xPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuseoCombo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHangmog)).EndInit();
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
			this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());
			QryList();
		}
		#endregion

		private void grdHangmog_GridCellPainting(object sender, IHIS.Framework.XGridCellPaintEventArgs e)
		{
			if ( e.ColName == "order" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[0];
				}
      		}
			else if ( e.ColName == "chehyul" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[1];
				}
      		}
			else if ( e.ColName == "confirm" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[4];
				}
      		}
			else if ( e.ColName == "part_jub" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[2];
				}
      		}
			else if ( e.ColName == "result" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[3];
				}
      		}
			else if ( e.ColName == "print" )
			{
				//string colname = e.ColName + "_yn";
                if (e.DataRow[e.ColName + "_yn"].ToString() == "Y")
				{
					e.Image = this.ImageList.Images[5];
				}
			}
		}

		private void dtpFromDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void dtpToDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			QryList();
		}

		private void cboJundalGubun_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			QryList();
		}

		#region 미도착 리스트 조회
		private void QryList()
		{
			if ( this.rbxAll.Checked == true )
				this.grdHangmog.SetBindVarValue("f_in_out_gubun","%");
			else if ( this.rbxOut.Checked == true )
                this.grdHangmog.SetBindVarValue("f_in_out_gubun", "O"); 
			else
                this.grdHangmog.SetBindVarValue("f_in_out_gubun", "I");

            this.grdHangmog.QueryLayout(false);
		}
		#endregion

		private void rbx_CheckedChanged(object sender, System.EventArgs e)
		{
			if ( this.rbxAll.Checked == true )
				this.BuseoCombo.SetDataValue("%");
			else if ( this.rbxOut.Checked == true )
				this.BuseoCombo.BuseoGubun = BuseoType.Out;
			else
				this.BuseoCombo.BuseoGubun = BuseoType.Inp;
			QryList();
		}

		private void BuseoCombo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			QryList();
		}

		private void cboSex_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			QryList();
		}

        private void grdHangmog_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHangmog.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdHangmog.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_hangmog_code", fbxGumsa.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_gwa", BuseoCombo.GetDataValue());
            this.grdHangmog.SetBindVarValue("f_sex", cboSex.GetDataValue());
        }

        private void fwkGumsa_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkGumsa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void fbxGumsa_DataValidating(object sender, DataValidatingEventArgs e)
        {

            this.dbxGumsaName.SetDataValue("");
            
            if (e.DataValue != "")
            {
                this.vsvGumsa.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.vsvGumsa.SetBindVarValue("f_code", e.DataValue);

                this.vsvGumsa.QueryLayout();

                if (vsvGumsa.GetItemValue("dbxGumsaName").ToString() == "")
                {
                    e.Cancel = true;
                }
            }

            QryList();
        }

		

	}
}

