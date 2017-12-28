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
	/// DRG3010Q05에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class DRG3010Q05 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XButtonList xButtonList1;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGrid grdDrg3010;
		private IHIS.Framework.XPatientBox paid;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
		private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XDatePicker dtpBanNabFr;
		private IHIS.Framework.XDatePicker dtpBanNabTo;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XPanel panTop;
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XPanel xPanel2;
		private IHIS.Framework.XComboBox cboGubun;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XDictComboBox cboDong;
		private IHIS.Framework.XDisplayBox dbxJaeryo;
		private IHIS.Framework.XFindBox fbxJaeryo;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XLabel xLabel40;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DRG3010Q05()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG3010Q05));
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpBanNabTo = new IHIS.Framework.XDatePicker();
            this.paid = new IHIS.Framework.XPatientBox();
            this.dtpBanNabFr = new IHIS.Framework.XDatePicker();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.grdDrg3010 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.cboDong = new IHIS.Framework.XDictComboBox();
            this.fbxJaeryo = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.cboGubun = new IHIS.Framework.XComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.panTop = new IHIS.Framework.XPanel();
            this.xLabel40 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dbxJaeryo = new IHIS.Framework.XDisplayBox();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.paid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).BeginInit();
            this.panTop.SuspendLayout();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xLabel2
            // 
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.Location = new System.Drawing.Point(174, 4);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(13, 24);
            this.xLabel2.TabIndex = 29;
            this.xLabel2.Text = "~";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpBanNabTo
            // 
            this.dtpBanNabTo.Location = new System.Drawing.Point(188, 4);
            this.dtpBanNabTo.Name = "dtpBanNabTo";
            this.dtpBanNabTo.Size = new System.Drawing.Size(100, 20);
            this.dtpBanNabTo.TabIndex = 28;
            this.dtpBanNabTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // paid
            // 
            this.paid.BoxType = IHIS.Framework.PatientBoxType.NormalDetail;
            this.paid.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paid.Location = new System.Drawing.Point(6, 28);
            this.paid.Name = "paid";
            this.paid.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paid.Size = new System.Drawing.Size(1196, 32);
            this.paid.TabIndex = 24;
            // 
            // dtpBanNabFr
            // 
            this.dtpBanNabFr.Location = new System.Drawing.Point(76, 4);
            this.dtpBanNabFr.Name = "dtpBanNabFr";
            this.dtpBanNabFr.Size = new System.Drawing.Size(100, 20);
            this.dtpBanNabFr.TabIndex = 1;
            this.dtpBanNabFr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // xLabel1
            // 
            this.xLabel1.Location = new System.Drawing.Point(4, 4);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(72, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "オーダ日付";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xButtonList1
            // 
            this.xButtonList1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.xButtonList1.Dock = System.Windows.Forms.DockStyle.Right;
            this.xButtonList1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Location = new System.Drawing.Point(964, 0);
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.EntryS;
            this.xButtonList1.Size = new System.Drawing.Size(244, 34);
            this.xButtonList1.TabIndex = 1;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "order_date";
            this.xEditGridCell4.CellWidth = 79;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell4.HeaderText = "オーダー日付";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdCol = false;
            this.xEditGridCell4.SuppressRepeating = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jaeryo_code";
            this.xEditGridCell7.CellWidth = 83;
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "オーダコード";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "dv";
            this.xEditGridCell8.CellWidth = 25;
            this.xEditGridCell8.Col = 11;
            this.xEditGridCell8.HeaderText = "回\r\n数";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "ord_surang";
            this.xEditGridCell10.CellWidth = 30;
            this.xEditGridCell10.Col = 15;
            this.xEditGridCell10.HeaderText = "1回\r\n数量";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdCol = false;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "subul_suryang";
            this.xEditGridCell13.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell13.CellWidth = 30;
            this.xEditGridCell13.Col = 17;
            this.xEditGridCell13.HeaderText = "受払\r\n数量";
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "subul_danui";
            this.xEditGridCell14.CellWidth = 60;
            this.xEditGridCell14.Col = 18;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell14.HeaderText = "受払\r\n単位";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell14.UserSQL = "SELECT CODE, CODE_NAME\n  FROM OCS0132  WHERE CODE_TYPE = \'ORD_DANUI\'";
            // 
            // grdDrg3010
            // 
            this.grdDrg3010.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell21,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell12,
            this.xEditGridCell15,
            this.xEditGridCell7,
            this.xEditGridCell19,
            this.xEditGridCell25,
            this.xEditGridCell28,
            this.xEditGridCell13,
            this.xEditGridCell10,
            this.xEditGridCell24,
            this.xEditGridCell14,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell22,
            this.xEditGridCell8,
            this.xEditGridCell20});
            this.grdDrg3010.ColPerLine = 18;
            this.grdDrg3010.ColResizable = true;
            this.grdDrg3010.Cols = 19;
            this.grdDrg3010.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDrg3010.FixedCols = 1;
            this.grdDrg3010.FixedRows = 1;
            this.grdDrg3010.HeaderHeights.Add(29);
            this.grdDrg3010.Location = new System.Drawing.Point(2, 2);
            this.grdDrg3010.Name = "grdDrg3010";
            this.grdDrg3010.QuerySQL = resources.GetString("grdDrg3010.QuerySQL");
            this.grdDrg3010.RowHeaderVisible = true;
            this.grdDrg3010.Rows = 2;
            this.grdDrg3010.Size = new System.Drawing.Size(1204, 663);
            this.grdDrg3010.TabIndex = 2;
            this.grdDrg3010.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg3010_QueryStarting);
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
            this.xEditGridCell16.CellWidth = 70;
            this.xEditGridCell16.Col = 5;
            this.xEditGridCell16.HeaderText = "患者番号";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.SuppressRepeating = true;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "suname";
            this.xEditGridCell17.CellWidth = 90;
            this.xEditGridCell17.Col = 6;
            this.xEditGridCell17.HeaderText = "患者名";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdCol = false;
            this.xEditGridCell17.SuppressRepeating = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "drg_bunho";
            this.xEditGridCell5.CellWidth = 42;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.HeaderText = "投薬\r\n番号";
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "ho_dong";
            this.xEditGridCell1.CellWidth = 60;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.HeaderText = "病棟";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdCol = false;
            this.xEditGridCell1.SuppressRepeating = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.CellWidth = 40;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.HeaderText = "病室";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdCol = false;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "decotr_name";
            this.xEditGridCell12.Col = 7;
            this.xEditGridCell12.HeaderText = "医師名";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gwa";
            this.xEditGridCell15.CellWidth = 35;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.HeaderText = "科";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "nalsu";
            this.xEditGridCell19.CellWidth = 30;
            this.xEditGridCell19.Col = 13;
            this.xEditGridCell19.HeaderText = "日\r\n数";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "divide";
            this.xEditGridCell25.CellWidth = 24;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "order_suryang";
            this.xEditGridCell28.CellWidth = 30;
            this.xEditGridCell28.Col = 14;
            this.xEditGridCell28.HeaderText = "1日\r\n数量";
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.IsUpdCol = false;
            this.xEditGridCell28.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "order_danui";
            this.xEditGridCell24.CellWidth = 60;
            this.xEditGridCell24.Col = 16;
            this.xEditGridCell24.HeaderText = "単\r\n位";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdCol = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "bogyong_name";
            this.xEditGridCell26.CellWidth = 150;
            this.xEditGridCell26.Col = 10;
            this.xEditGridCell26.HeaderText = "服用法";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdCol = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "dc_yn";
            this.xEditGridCell27.CellWidth = 60;
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "dv_time";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.CellWidth = 24;
            this.xEditGridCell22.Col = 12;
            this.xEditGridCell22.HeaderText = "類\r\n型";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdCol = false;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "jaeryo_name";
            this.xEditGridCell20.CellWidth = 225;
            this.xEditGridCell20.Col = 9;
            this.xEditGridCell20.HeaderText = "薬品名";
            // 
            // cboDong
            // 
            this.cboDong.ItemHeight = 13;
            this.cboDong.Location = new System.Drawing.Point(340, 4);
            this.cboDong.MaxDropDownItems = 30;
            this.cboDong.Name = "cboDong";
            this.cboDong.Size = new System.Drawing.Size(64, 21);
            this.cboDong.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboDong.TabIndex = 8;
            this.cboDong.UserSQL = resources.GetString("cboDong.UserSQL");
            // 
            // fbxJaeryo
            // 
            this.fbxJaeryo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxJaeryo.FindWorker = this.fwkCommon;
            this.fbxJaeryo.Location = new System.Drawing.Point(684, 4);
            this.fbxJaeryo.MaxLength = 10;
            this.fbxJaeryo.Name = "fbxJaeryo";
            this.fbxJaeryo.Size = new System.Drawing.Size(112, 20);
            this.fbxJaeryo.TabIndex = 32;
            this.fbxJaeryo.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxJaeryo_DataValidating);
            this.fbxJaeryo.FindSelected += new IHIS.Framework.FindEventHandler(this.fbxJaeryo_FindSelected);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.FormText = "材料コード";
            this.fwkCommon.InputSQL = "SELECT JAERYO_CODE, JAERYO_NAME\r\n  FROM INV0110\r\n WHERE (JAERYO_CODE LIKE  :f_fin" +
                "d1||\'%\'\r\n    OR JAERYO_NAME  LIKE  \'%\'||:f_find1||\'%\')\r\n   AND JAERYO_GUBUN = \'A" +
                "\'\r\n ORDER BY 2";
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "jaeryo_code";
            this.findColumnInfo1.ColWidth = 121;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "材料コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "jaeryo_name";
            this.findColumnInfo2.ColWidth = 233;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "材料コード名";
            // 
            // cboGubun
            // 
            this.cboGubun.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.cboGubun.Location = new System.Drawing.Point(484, 4);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(121, 21);
            this.cboGubun.TabIndex = 30;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = "薬局出庫件数";
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = "処方件";
            this.xComboItem2.ValueItem = "2";
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.xLabel40);
            this.panTop.Controls.Add(this.xLabel4);
            this.panTop.Controls.Add(this.cboGubun);
            this.panTop.Controls.Add(this.dtpBanNabFr);
            this.panTop.Controls.Add(this.xLabel3);
            this.panTop.Controls.Add(this.cboDong);
            this.panTop.Controls.Add(this.xLabel1);
            this.panTop.Controls.Add(this.xLabel2);
            this.panTop.Controls.Add(this.paid);
            this.panTop.Controls.Add(this.dtpBanNabTo);
            this.panTop.Controls.Add(this.dbxJaeryo);
            this.panTop.Controls.Add(this.fbxJaeryo);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.DrawBorder = true;
            this.panTop.Location = new System.Drawing.Point(5, 5);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(1210, 65);
            this.panTop.TabIndex = 3;
            // 
            // xLabel40
            // 
            this.xLabel40.Location = new System.Drawing.Point(620, 4);
            this.xLabel40.Name = "xLabel40";
            this.xLabel40.Size = new System.Drawing.Size(64, 20);
            this.xLabel40.TabIndex = 33;
            this.xLabel40.Text = "薬品コード";
            this.xLabel40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel4
            // 
            this.xLabel4.Location = new System.Drawing.Point(412, 4);
            this.xLabel4.Name = "xLabel4";
            this.xLabel4.Size = new System.Drawing.Size(72, 21);
            this.xLabel4.TabIndex = 31;
            this.xLabel4.Text = "処理区分";
            this.xLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel3
            // 
            this.xLabel3.Location = new System.Drawing.Point(300, 4);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(40, 21);
            this.xLabel3.TabIndex = 3;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dbxJaeryo
            // 
            this.dbxJaeryo.Location = new System.Drawing.Point(796, 4);
            this.dbxJaeryo.Name = "dbxJaeryo";
            this.dbxJaeryo.Size = new System.Drawing.Size(406, 20);
            this.dbxJaeryo.TabIndex = 34;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.grdDrg3010);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Location = new System.Drawing.Point(5, 70);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.xPanel1.Size = new System.Drawing.Size(1210, 669);
            this.xPanel1.TabIndex = 4;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Location = new System.Drawing.Point(5, 739);
            this.xPanel2.Name = "xPanel2";
            this.xPanel2.Size = new System.Drawing.Size(1210, 36);
            this.xPanel2.TabIndex = 5;
            // 
            // DRG3010Q05
            // 
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.panTop);
            this.Name = "DRG3010Q05";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(1220, 780);
            ((System.ComponentModel.ISupportInitialize)(this.paid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg3010)).EndInit();
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region OnLoad
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);
			this.dtpBanNabFr.SetDataValue(EnvironInfo.GetSysDate());
			this.dtpBanNabTo.SetDataValue(EnvironInfo.GetSysDate());
			cboDong.SelectedIndex  =0;
			cboGubun.SelectedIndex =0;
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

        private void grdDrg3010_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg3010.SetBindVarValue("f_bunho",           paid.BunHo);
            grdDrg3010.SetBindVarValue("f_jubsu_date",      dtpBanNabFr.GetDataValue());
            grdDrg3010.SetBindVarValue("f_jubsu_date_to",   dtpBanNabTo.GetDataValue());
            grdDrg3010.SetBindVarValue("f_ho_dong",         cboDong.GetDataValue());
            grdDrg3010.SetBindVarValue("f_jaeryo_code",     fbxJaeryo.GetDataValue());
            grdDrg3010.SetBindVarValue("f_gubun",           cboGubun.GetDataValue());
        }

        private void fbxJaeryo_DataValidating(object sender, DataValidatingEventArgs e)
        {
            string cmdText = "select JAERYO_NAME from INV0110 where JAERYO_CODE = '" + e.DataValue + "'";

            dbxJaeryo.SetEditValue(Service.ExecuteScalar(cmdText));
        }
	}
}

