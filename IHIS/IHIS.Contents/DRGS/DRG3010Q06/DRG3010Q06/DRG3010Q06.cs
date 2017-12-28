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

namespace IHIS.DRGS
{
	/// <summary>
	/// DRG3010Q06에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010Q06 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGrid grdDrg3010;
		private IHIS.Framework.XPatientBox paid;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XPanel panTop;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XLabel xLabel40;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo3;
		private IHIS.Framework.FindColumnInfo findColumnInfo4;
		private IHIS.Framework.XDisplayBox dbxJaeryo;
		private IHIS.Framework.XFindBox fbxJaeryo;
		private IHIS.Framework.XDatePicker dtpOrderDateFr;
		private IHIS.Framework.XBuseoCombo cboDong;
		private IHIS.Framework.XDatePicker dtpOrderDateTo;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XRadioButton rb1;
		private IHIS.Framework.XRadioButton rb2;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XComboItem xComboItem3;
		private IHIS.Framework.XComboItem xComboItem4;
		private IHIS.Framework.XGroupBox xGroupBox1;
		private IHIS.Framework.XGroupBox xGroupBox2;
		private IHIS.Framework.XRadioButton rb3;
		private IHIS.Framework.XRadioButton rb4;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG3010Q06()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q06));
            this.paid = new IHIS.Framework.XPatientBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.grdDrg3010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.dtpOrderDateFr = new IHIS.Framework.XDatePicker();
            this.dtpOrderDateTo = new IHIS.Framework.XDatePicker();
            this.fbxJaeryo = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.cboDong = new IHIS.Framework.XBuseoCombo();
            this.panTop = new IHIS.Framework.XPanel();
            this.xGroupBox2 = new IHIS.Framework.XGroupBox();
            this.rb2 = new IHIS.Framework.XRadioButton();
            this.rb1 = new IHIS.Framework.XRadioButton();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.rb4 = new IHIS.Framework.XRadioButton();
            this.rb3 = new IHIS.Framework.XRadioButton();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.dbxJaeryo = new IHIS.Framework.XDisplayBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDong)).BeginInit();
            this.panTop.SuspendLayout();
            this.xGroupBox2.SuspendLayout();
            this.xGroupBox1.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // paid
            // 
            this.paid.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paid.Location = new System.Drawing.Point(0, 56);
            this.paid.Name = "paid";
            this.paid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paid.Size = new System.Drawing.Size(936, 29);
            this.paid.TabIndex = 24;
            // 
            // xLabel3
            // 
            this.xLabel3.Location = new System.Drawing.Point(656, 8);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(48, 21);
            this.xLabel3.TabIndex = 3;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(8, 8);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(80, 21);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "オーダー日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(776, 2);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.xButtonList1.Size = new System.Drawing.Size(163, 34);
            this.xButtonList1.TabIndex = 1;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "magam_gubun";
            this.xEditGridCell3.CellWidth = 43;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3,
            this.xComboItem4});
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell3.HeaderText = "締切\r\n区分";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "正規";
            this.xComboItem1.ValueItem = "N";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "追加";
            this.xComboItem2.ValueItem = "A";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = "退院";
            this.xComboItem3.ValueItem = "E";
            // 
            // xComboItem4
            // 
            this.xComboItem4.DisplayItem = "救急";
            this.xComboItem4.ValueItem = "T";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "order_date";
            this.xEditGridCell4.CellWidth = 82;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell4.HeaderText = "オーダー日";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jaeryo_code";
            this.xEditGridCell7.CellWidth = 71;
            this.xEditGridCell7.Col = 9;
            this.xEditGridCell7.HeaderText = "オーダコード";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "jaeryo_name";
            this.xEditGridCell8.CellWidth = 290;
            this.xEditGridCell8.Col = 10;
            this.xEditGridCell8.HeaderText = "薬品名";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "magam_ser";
            this.xEditGridCell9.CellWidth = 36;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.HeaderText = "締切\r\nNo";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdCol = false;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "divide";
            this.xEditGridCell10.CellWidth = 34;
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ord_suryang";
            this.xEditGridCell11.CellWidth = 43;
            this.xEditGridCell11.Col = 11;
            this.xEditGridCell11.HeaderText = "1回\r\n数量";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "subul_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 41;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.HeaderText = "受払\r\n数量";
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "subul_danui";
            this.xEditGridCell14.CellWidth = 48;
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "受払\r\n単位";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            this.xEditGridCell14.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell14.UserSQL = "SELECT CODE, CODE_NAME\n  FROM OCS0132  WHERE CODE_TYPE = \'ORD_DANUI\'";
            // 
            // grdDrg3010
            // 
            this.grdDrg3010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell5,
            this.xEditGridCell2,
            this.xEditGridCell21,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell11,
            this.xEditGridCell24,
            this.xEditGridCell10,
            this.xEditGridCell4,
            this.xEditGridCell6,
            this.xEditGridCell28,
            this.xEditGridCell9,
            this.xEditGridCell26,
            this.xEditGridCell3,
            this.xEditGridCell25});
            this.grdDrg3010.ColPerLine = 12;
            this.grdDrg3010.ColResizable = true;
            this.grdDrg3010.Cols = 13;
            this.grdDrg3010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrg3010.FixedCols = 1;
            this.grdDrg3010.FixedRows = 1;
            this.grdDrg3010.HeaderHeights.Add(35);
            this.grdDrg3010.Location = new System.Drawing.Point(2, 2);
            this.grdDrg3010.Name = "grdDrg3010";
            this.grdDrg3010.QuerySQL = resources.GetString("grdDrg3010.QuerySQL");
            this.grdDrg3010.RowHeaderVisible = true;
            this.grdDrg3010.Rows = 2;
            this.grdDrg3010.Size = new System.Drawing.Size(944, 443);
            this.grdDrg3010.TabIndex = 2;
            this.grdDrg3010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3010_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_dong";
            this.xEditGridCell1.CellWidth = 38;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderText = "病棟";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "buseo";
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.CellWidth = 41;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "病室";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "fkocs2003";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "bunho";
            this.xEditGridCell16.CellWidth = 76;
            this.xEditGridCell16.Col = 7;
            this.xEditGridCell16.HeaderText = "患者番号";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "suname";
            this.xEditGridCell17.CellWidth = 112;
            this.xEditGridCell17.Col = 8;
            this.xEditGridCell17.HeaderText = "患者名";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "order_danui";
            this.xEditGridCell24.CellWidth = 31;
            this.xEditGridCell24.Col = 12;
            this.xEditGridCell24.HeaderText = "単\r\n位";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "drg_bunho";
            this.xEditGridCell6.CellWidth = 38;
            this.xEditGridCell6.Col = 6;
            this.xEditGridCell6.HeaderText = "投薬\r\n番号";
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "bunryu2";
            this.xEditGridCell28.CellWidth = 40;
            this.xEditGridCell28.Col = -1;
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.IsVisible = false;
            this.xEditGridCell28.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bannab_yn";
            this.xEditGridCell26.CellWidth = 393;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "source_fkocs2003";
            this.xEditGridCell25.CellWidth = 24;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // dtpOrderDateFr
            // 
            this.dtpOrderDateFr.Location = new System.Drawing.Point(88, 8);
            this.dtpOrderDateFr.Name = "dtpOrderDateFr";
            this.dtpOrderDateFr.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderDateFr.TabIndex = 1;
            this.dtpOrderDateFr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.Location = new System.Drawing.Point(205, 8);
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpOrderDateTo.TabIndex = 39;
            this.dtpOrderDateTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fbxJaeryo
            // 
            this.fbxJaeryo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJaeryo.FindWorker = this.fwkCommon;
            this.fbxJaeryo.Location = new System.Drawing.Point(88, 32);
            this.fbxJaeryo.MaxLength = 10;
            this.fbxJaeryo.Name = "fbxJaeryo";
            this.fbxJaeryo.Size = new System.Drawing.Size(112, 20);
            this.fbxJaeryo.TabIndex = 35;
            this.fbxJaeryo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJaeryo_DataValidating);
            this.fbxJaeryo.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxJaeryo_FindSelected);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.FormText = "材料コード";
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "jaeryo_code";
            this.findColumnInfo3.ColWidth = 121;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "材料コード";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "jaeryo_name";
            this.findColumnInfo4.ColWidth = 233;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "材料コード名";
            // 
            // cboDong
            // 
            this.cboDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboDong.IsAppendAll = true;
            this.cboDong.Location = new System.Drawing.Point(704, 8);
            this.cboDong.MaxDropDownItems = 20;
            this.cboDong.Name = "cboDong";
            this.cboDong.Size = new System.Drawing.Size(168, 21);
            this.cboDong.TabIndex = 38;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.xGroupBox2);
            this.panTop.Controls.Add(this.xGroupBox1);
            this.panTop.Controls.Add(this.xLabel2);
            this.panTop.Controls.Add(this.dtpOrderDateTo);
            this.panTop.Controls.Add(this.cboDong);
            this.panTop.Controls.Add(this.fbxJaeryo);
            this.panTop.Controls.Add(this.dtpOrderDateFr);
            this.panTop.Controls.Add(this.xLabel3);
            this.panTop.Controls.Add(this.xLabel1);
            this.panTop.Controls.Add(this.paid);
            this.panTop.Controls.Add(this.xLabel40);
            this.panTop.Controls.Add(this.dbxJaeryo);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.DrawBorder = true;
            this.panTop.Location = new System.Drawing.Point(5, 5);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(950, 91);
            this.panTop.TabIndex = 3;
            // 
            // xGroupBox2
            // 
            this.xGroupBox2.Controls.Add(this.rb2);
            this.xGroupBox2.Controls.Add(this.rb1);
            this.xGroupBox2.Location = new System.Drawing.Point(496, 0);
            this.xGroupBox2.Name = "xGroupBox2";
            this.xGroupBox2.Size = new System.Drawing.Size(136, 32);
            this.xGroupBox2.TabIndex = 44;
            this.xGroupBox2.TabStop = false;
            // 
            // rb2
            // 
            this.rb2.Location = new System.Drawing.Point(56, 9);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(68, 16);
            this.rb2.TabIndex = 42;
            this.rb2.Text = "注射薬";
            this.rb2.UseVisualStyleBackColor = false;
            // 
            // rb1
            // 
            this.rb1.Checked = true;
            this.rb1.Location = new System.Drawing.Point(8, 9);
            this.rb1.Name = "rb1";
            this.rb1.Size = new System.Drawing.Size(32, 16);
            this.rb1.TabIndex = 41;
            this.rb1.TabStop = true;
            this.rb1.Text = "薬";
            this.rb1.UseVisualStyleBackColor = false;
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.Controls.Add(this.rb4);
            this.xGroupBox1.Controls.Add(this.rb3);
            this.xGroupBox1.Location = new System.Drawing.Point(320, 0);
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Size = new System.Drawing.Size(160, 32);
            this.xGroupBox1.TabIndex = 43;
            this.xGroupBox1.TabStop = false;
            // 
            // rb4
            // 
            this.rb4.CheckedValue = "N";
            this.rb4.Location = new System.Drawing.Point(72, 9);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(72, 17);
            this.rb4.TabIndex = 43;
            this.rb4.Text = "未締切";
            this.rb4.UseVisualStyleBackColor = false;
            // 
            // rb3
            // 
            this.rb3.Checked = true;
            this.rb3.Location = new System.Drawing.Point(8, 9);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(56, 17);
            this.rb3.TabIndex = 42;
            this.rb3.TabStop = true;
            this.rb3.Text = "締切";
            this.rb3.UseVisualStyleBackColor = false;
            // 
            // xLabel2
            // 
            this.xLabel2.Location = new System.Drawing.Point(189, 8);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(14, 21);
            this.xLabel2.TabIndex = 40;
            this.xLabel2.Text = "~";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel40
            // 
            this.xLabel40.Location = new System.Drawing.Point(8, 32);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(80, 20);
            this.xLabel40.TabIndex = 36;
            this.xLabel40.Text = "薬品コード";
            this.xLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxJaeryo
            // 
            this.dbxJaeryo.Location = new System.Drawing.Point(200, 32);
            this.dbxJaeryo.Name = "dbxJaeryo";
            this.dbxJaeryo.Size = new System.Drawing.Size(624, 20);
            this.dbxJaeryo.TabIndex = 37;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDrg3010);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 96);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(950, 449);
            this.xPanel1.TabIndex = 4;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 545);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(950, 40);
            this.xPanel2.TabIndex = 5;
            // 
            // DRG3010Q06
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panTop);
            this.Name = "DRG3010Q06";
            this.Padding = new System.Windows.Forms.Padding(5);
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDong)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.xGroupBox2.ResumeLayout(false);
            this.xGroupBox1.ResumeLayout(false);
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		[Browsable(false), DataBindable]
		public string Bunryu1
		{
			get {return (rb1.Checked ? "1" : "4");}
			
		}

		[Browsable(false), DataBindable]
		public string MagamGubun
		{
			get {return (rb3.Checked ? "Y" : "N");}
			
		}
		
		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpOrderDateFr.SetDataValue(EnvironInfo.GetSysDate());
			this.dtpOrderDateTo.SetDataValue(EnvironInfo.GetSysDate());
			cboDong.SelectedIndex  =0;
		}
		#endregion

		#region xButtonList1_ButtonClick
		private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Query:
					this.CurrMQLayout = this.grdDrg3010;
					break;
			}		
		}
		#endregion

		private void fbxJaeryo_FindSelected(object sender, IHIS.Framework.FindEventArgs e)
		{
			dbxJaeryo.SetDataValue(e.ReturnValues[1].ToString());
		}

        private void fbxJaeryo_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string cmdText = "SELECT JAERYO_NAME FROM INV0110 WHERE JAERYO_CODE = '" + e.DataValue + "'";

            dbxJaeryo.SetDataValue(Service.ExecuteScalar(cmdText));
        }

        private void grdDrg3010_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3010.SetBindVarValue("f_order_date_fr", dtpOrderDateFr.GetDataValue());
            grdDrg3010.SetBindVarValue("f_order_date_to", dtpOrderDateTo.GetDataValue());
            grdDrg3010.SetBindVarValue("f_jaeryo_code",   fbxJaeryo.GetDataValue());
            grdDrg3010.SetBindVarValue("f_ho_dong",       cboDong.GetDataValue());
            grdDrg3010.SetBindVarValue("f_bunho",         paid.BunHo);
            grdDrg3010.SetBindVarValue("f_bunryu1",       Bunryu1);
            grdDrg3010.SetBindVarValue("f_magam_gubun",   MagamGubun);
        }

	}
}

