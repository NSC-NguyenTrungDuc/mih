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
	/// INP1003Q00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class INP1003Q00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XPanel xPanel1;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
		private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell8;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XEditGrid grdINP1003;
		//private IHIS.Framework.DataServiceSIMO dsvINP1003;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XGridHeader xGridHeader2;
		private IHIS.Framework.XDictComboBox cboReserEndType;
        private IHIS.Framework.XDatePicker dtpReserDate;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XEditGridCell xEditGridCell10;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
        private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XFindWorker fwkHoDong;
        private XBuseoCombo cboHoDong;
        private XButton btnNUR1001U00;
		//private System.Windows.Forms.ToolTip toolTip1;
		private System.ComponentModel.IContainer components = null;

		public INP1003Q00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INP1003Q00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            this.dtpReserDate = new IHIS.Framework.XDatePicker();
            this.cboReserEndType = new IHIS.Framework.XDictComboBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fwkHoDong = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.grdINP1003 = new IHIS.Framework.XEditGrid();
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
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.btnList = new IHIS.Framework.XButtonList();
            this.btnNUR1001U00 = new IHIS.Framework.XButton();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "진료안내.ico");
            // 
            // xPanel1
            // 
            this.xPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("xPanel1.BackgroundImage")));
            this.xPanel1.Controls.Add(this.cboHoDong);
            this.xPanel1.Controls.Add(this.dtpReserDate);
            this.xPanel1.Controls.Add(this.cboReserEndType);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(4, 4);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(1188, 42);
            this.xPanel1.TabIndex = 0;
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHoDong.IsAppendAll = true;
            this.cboHoDong.Location = new System.Drawing.Point(542, 12);
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.Size = new System.Drawing.Size(139, 21);
            this.cboHoDong.TabIndex = 9;
            this.cboHoDong.SelectedIndexChanged += new System.EventHandler(this.cboHoDong_SelectedIndexChanged);
            // 
            // dtpReserDate
            // 
            this.dtpReserDate.IsJapanYearType = true;
            this.dtpReserDate.Location = new System.Drawing.Point(326, 12);
            this.dtpReserDate.Name = "dtpReserDate";
            this.dtpReserDate.Size = new System.Drawing.Size(112, 20);
            this.dtpReserDate.TabIndex = 6;
            this.dtpReserDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dtpReserDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpReserDate_DataValidating);
            // 
            // cboReserEndType
            // 
            this.cboReserEndType.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboReserEndType.Location = new System.Drawing.Point(100, 12);
            this.cboReserEndType.Name = "cboReserEndType";
            this.cboReserEndType.Size = new System.Drawing.Size(121, 20);
            this.cboReserEndType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboReserEndType.TabIndex = 5;
            this.cboReserEndType.UserSQL = "SELECT \'%\', FN_ADM_MSG(221)\r\n   FROM DUAL\r\nUNION\r\nSELECT CODE, CODE_NAME\r\nFROM BA" +
                "S0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()  \r\n  AND CODE_TYPE = \'RESER_END" +
                "_TYPE\'";
            this.cboReserEndType.SelectedValueChanged += new System.EventHandler(this.cboReserEndType_SelectedValueChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Location = new System.Drawing.Point(456, 12);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(86, 21);
            this.xLabel3.TabIndex = 4;
            this.xLabel3.Text = "病棟";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(240, 12);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(86, 20);
            this.xLabel2.TabIndex = 2;
            this.xLabel2.Text = "入院予定日";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Location = new System.Drawing.Point(14, 12);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(86, 20);
            this.xLabel1.TabIndex = 0;
            this.xLabel1.Text = "予約状態";
            this.xLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkHoDong
            // 
            this.fwkHoDong.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkHoDong.FormText = "病棟照会";
            this.fwkHoDong.InputSQL = resources.GetString("fwkHoDong.InputSQL");
            this.fwkHoDong.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkHoDong.ServerFilter = true;
            this.fwkHoDong.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkHoDong_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "ho_dong";
            this.findColumnInfo1.ColWidth = 108;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "病棟コード";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "ho_dong_name";
            this.findColumnInfo2.ColWidth = 211;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "病棟名称";
            // 
            // grdINP1003
            // 
            this.grdINP1003.AddedHeaderLine = 1;
            this.grdINP1003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21});
            this.grdINP1003.ColPerLine = 15;
            this.grdINP1003.Cols = 16;
            this.grdINP1003.DefaultHeight = 26;
            this.grdINP1003.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdINP1003.FixedCols = 1;
            this.grdINP1003.FixedRows = 2;
            this.grdINP1003.HeaderHeights.Add(32);
            this.grdINP1003.HeaderHeights.Add(0);
            this.grdINP1003.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdINP1003.Location = new System.Drawing.Point(4, 46);
            this.grdINP1003.Name = "grdINP1003";
            this.grdINP1003.QuerySQL = resources.GetString("grdINP1003.QuerySQL");
            this.grdINP1003.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINP1003.RowHeaderVisible = true;
            this.grdINP1003.Rows = 3;
            this.grdINP1003.Size = new System.Drawing.Size(1188, 504);
            this.grdINP1003.TabIndex = 1;
            this.grdINP1003.ToolTipActive = true;
            this.grdINP1003.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdINP1003_MouseDown);
            this.grdINP1003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINP1003_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.CellWidth = 70;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.RowSpan = 2;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "suname";
            this.xEditGridCell2.CellWidth = 100;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell2.HeaderText = "氏名(漢字)";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowSpan = 2;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "reser_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 100;
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell3.HeaderText = "入院予定日";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "tel2";
            this.xEditGridCell4.CellWidth = 88;
            this.xEditGridCell4.Col = 11;
            this.xEditGridCell4.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell4.HeaderText = "連絡先";
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowSpan = 2;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gwa";
            this.xEditGridCell5.CellWidth = 37;
            this.xEditGridCell5.Col = -1;
            this.xEditGridCell5.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell5.HeaderText = "診療科";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "gwa_name";
            this.xEditGridCell6.CellWidth = 100;
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell6.HeaderText = "診療科名";
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "doctor";
            this.xEditGridCell7.CellWidth = 60;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell7.HeaderText = "主治医";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.Row = 1;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "doctor_name";
            this.xEditGridCell8.CellWidth = 100;
            this.xEditGridCell8.Col = 5;
            this.xEditGridCell8.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell8.HeaderText = "主治医名";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.Row = 1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "reser_end_type";
            this.xEditGridCell9.CellWidth = 70;
            this.xEditGridCell9.Col = 15;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell9.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell9.HeaderText = "状態";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowSpan = 2;
            this.xEditGridCell9.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell9.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102 \r\nWHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE(" +
                ") \r\n  AND CODE_TYPE = \'RESER_END_TYPE\'";
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "reser_fkinp1001";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.HeaderText = "reser_fkinp1001";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sang_bigo";
            this.xEditGridCell11.CellWidth = 147;
            this.xEditGridCell11.Col = 7;
            this.xEditGridCell11.DisplayMemoText = true;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell11.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell11.HeaderText = "傷病コメント";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowSpan = 2;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_dong_name";
            this.xEditGridCell12.CellWidth = 110;
            this.xEditGridCell12.Col = 6;
            this.xEditGridCell12.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell12.HeaderText = "病床";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.RowSpan = 2;
            this.xEditGridCell12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "age";
            this.xEditGridCell14.CellWidth = 35;
            this.xEditGridCell14.Col = 3;
            this.xEditGridCell14.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell14.HeaderText = "年齢";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowSpan = 2;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "ipwon_mokjuk";
            this.xEditGridCell15.CellWidth = 100;
            this.xEditGridCell15.Col = 8;
            this.xEditGridCell15.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell15.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell15.HeaderText = "入院目的";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.RowSpan = 2;
            this.xEditGridCell15.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell15.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102\r\nWHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()" +
                " \r\n  AND CODE_TYPE = \'IPWON_MOKJUK\'\r\nORDER BY CODE";
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "ipwon_rtn";
            this.xEditGridCell16.CellWidth = 92;
            this.xEditGridCell16.Col = 9;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell16.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell16.HeaderText = "入院経路";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowSpan = 2;
            this.xEditGridCell16.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell16.UserSQL = "SELECT CODE, CODE_NAME\r\nFROM BAS0102\r\nWHERE HOSP_CODE   = FN_ADM_LOAD_HOSP_CODE()" +
                " \r\n  AND CODE_TYPE = \'IPWON_RTN2\'";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "sogye_yn";
            this.xEditGridCell17.CellWidth = 35;
            this.xEditGridCell17.Col = 10;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell17.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell17.HeaderText = "紹介\r\n有無";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowSpan = 2;
            this.xEditGridCell17.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell17.UserSQL = "SELECT CODE, CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE(" +
                ") \r\n   AND CODE_TYPE =\'SOGYE_YN\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "hope_room";
            this.xEditGridCell19.Col = 12;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell19.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell19.HeaderText = "部屋の希望";
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.RowSpan = 2;
            this.xEditGridCell19.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell19.UserSQL = "SELECT \' \', FN_ADM_MSG(3395)\r\nFROM DUAL\r\nUNION ALL\r\nSELECT CODE, CODE_NAME\r\nFROM " +
                "BAS0102 \r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n  AND CODE_TYPE = \'HOPE_ROO" +
                "M\'\r\nORDER BY 1";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "remark";
            this.xEditGridCell20.CellWidth = 130;
            this.xEditGridCell20.Col = 13;
            this.xEditGridCell20.DisplayMemoText = true;
            this.xEditGridCell20.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell20.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell20.HeaderText = "備考";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.RowSpan = 2;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "user_name";
            this.xEditGridCell21.CellWidth = 100;
            this.xEditGridCell21.Col = 14;
            this.xEditGridCell21.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xEditGridCell21.HeaderText = "最終修正者";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.RowSpan = 2;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 4;
            this.xGridHeader2.ColSpan = 2;
            this.xGridHeader2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xGridHeader2.HeaderText = "主治医";
            this.xGridHeader2.HeaderWidth = 46;
            // 
            // btnList
            // 
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(948, 554);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Query;
            this.btnList.Size = new System.Drawing.Size(244, 34);
            this.btnList.TabIndex = 2;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // btnNUR1001U00
            // 
            this.btnNUR1001U00.Location = new System.Drawing.Point(7, 556);
            this.btnNUR1001U00.Name = "btnNUR1001U00";
            this.btnNUR1001U00.Size = new System.Drawing.Size(90, 28);
            this.btnNUR1001U00.TabIndex = 3;
            this.btnNUR1001U00.Text = "アナムネ作成";
            this.btnNUR1001U00.Click += new System.EventHandler(this.btnNUR1001U00_Click);
            // 
            // INP1003Q00
            // 
            this.Controls.Add(this.btnNUR1001U00);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdINP1003);
            this.Controls.Add(this.xPanel1);
            this.Name = "INP1003Q00";
            this.Padding = new System.Windows.Forms.Padding(4, 4, 4, 40);
            this.Size = new System.Drawing.Size(1196, 590);
            this.Load += new System.EventHandler(this.INP1003Q00_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINP1003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Screen 변수 

		private string mMsg = "";

		#endregion 

		#region DataLoad

		private void Load_INP1003()
		{            
            this.grdINP1003.QueryLayout(false);
            this.GridHeaderImageChange();
		}

		#endregion

		#region XButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Query:
					e.IsBaseCall = false;

					this.Load_INP1003();

					break;
			}
		}

		#endregion

		#region Screen Load

		private void INP1003Q00_Load(object sender, System.EventArgs e)
		{
			// 병동은 전체도 포함해야 하므로
            
			//this.fwkHoDong.SetBindVarValue("accept_all", "Y");

			this.grdINP1003.FixedCols = 2;

			if (this.OpenParam != null)
			{
				if (this.OpenParam.Contains("reser_end_type"))
				{
					this.cboReserEndType.SetDataValue(this.OpenParam["reser_end_type"].ToString());
				}

				if (this.OpenParam.Contains("reser_date"))
				{
					this.dtpReserDate.SetDataValue(this.OpenParam["reser_date"].ToString());
				}

				if (this.OpenParam.Contains("ho_dong"))
				{
					this.cboHoDong.SetEditValue(this.OpenParam["ho_dong"].ToString());
                    this.cboHoDong.AcceptData();
				}

			}
			else
			{
				this.cboReserEndType.SetDataValue("%"); // 전체 // 예약중
				this.dtpReserDate.SetDataValue(EnvironInfo.GetSysDate()); // 오늘날자
                this.cboHoDong.SetDataValue("%");

				//this.fbxHoDong.AcceptData();      // 전체
                MakeHodongCombo(dtpReserDate.GetDataValue());

				Load_INP1003();
			}
		}

		#endregion

        #region 병동콤보 구성

        private void MakeHodongCombo(string aGijunDate)
        {
            //string aCurrHodong = this.fbxHoDong.GetDataValue();
            
            string strSql = @"SELECT A.GWA        gwa
                                   , A.GWA_NAME   gwa_name
                                FROM BAS0260 A
                               WHERE A.HOSP_CODE  = :f_hosp_code
                                         AND A.BUSEO_GUBUN = '2'
                                         AND TO_DATE(:f_reser_date,'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                         AND A.GWA > ' ' 
                                         ORDER BY 1";

            BindVarCollection bindVars = new BindVarCollection();

            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVars.Add("f_reser_date", aGijunDate);
            DataTable dtHoCombo = Service.ExecuteDataTable(strSql, bindVars);

            this.grdINP1003.SetComboItems("ho_dong", dtHoCombo, "gwa_name", "gwa");
        }
        #endregion

		#region XFindBox


		#endregion

		#region Function

		#region GridHeaderImageChange

		private void GridHeaderImageChange()
		{
			for (int i=0; i<this.grdINP1003.RowCount; i++)
			{
				if (this.grdINP1003.GetItemString(i, "reser_fkinp1001") != "")
				{
					this.grdINP1003[i + this.grdINP1003.HeaderHeights.Count, 0].Image = ImageList.Images[0];
				}
			}
		}
        #endregion
        #endregion

        private void dtpReserDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			Load_INP1003();
		}
        private void cboReserEndType_SelectedValueChanged(object sender, System.EventArgs e)
		{
           Load_INP1003();		
		}

        private void fwkHoDong_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkHoDong.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.fwkHoDong.SetBindVarValue("f_buseo_ymd",this.dtpReserDate.GetDataValue());
        }

        private void grdINP1003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINP1003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINP1003.SetBindVarValue("f_reser_end_type",this.cboReserEndType.GetDataValue());
            this.grdINP1003.SetBindVarValue("f_reser_date", this.dtpReserDate.GetDataValue());
            this.grdINP1003.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }

        private void cboHoDong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Load_INP1003();
        }

        private void grdINP1003_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                btnNUR1001U00_Click(sender, e);
            }
        }

        private void btnNUR1001U00_Click(object sender, EventArgs e)
        {
            if (grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "reser_end_type") != "")
            {
                XMessageBox.Show("予約中の件ではありません。確認してください。");
                return;
            }


            CommonItemCollection cic = new CommonItemCollection();
            cic.Add("bunho", grdINP1003.GetItemString(grdINP1003.CurrentRowNumber, "bunho"));
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURI", "NUR1001U00", ScreenOpenStyle.ResponseFixed, cic);
        }

        
     }
}

