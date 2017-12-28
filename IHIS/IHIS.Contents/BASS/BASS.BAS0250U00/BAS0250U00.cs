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

namespace IHIS.BASS
{
	/// <summary>
	/// BAS0250U00에 대한 요약 설명입니다.
	/// </summary>BED
	[ToolboxItem(false)]
	public class BAS0250U00 : IHIS.Framework.XScreen
	{
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
		private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
		private IHIS.Framework.XEditGridCell xEditGridCell11;
		private IHIS.Framework.XEditGridCell xEditGridCell12;
		private IHIS.Framework.XEditGridCell xEditGridCell13;
		private IHIS.Framework.XEditGridCell xEditGridCell14;
		private IHIS.Framework.XEditGridCell xEditGridCell15;
		private IHIS.Framework.XEditGridCell xEditGridCell16;
		private IHIS.Framework.XEditGridCell xEditGridCell17;
		private IHIS.Framework.XEditGridCell xEditGridCell18;
		private IHIS.Framework.XEditGridCell xEditGridCell19;
		private IHIS.Framework.XEditGridCell xEditGridCell20;
		private IHIS.Framework.XEditGridCell xEditGridCell21;
        private IHIS.Framework.XEditGridCell xEditGridCell22;
		private IHIS.Framework.XEditGridCell xEditGridCell24;
		private IHIS.Framework.XPanel xPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private IHIS.Framework.XLabel xLabel2;
		private IHIS.Framework.XLabel xLabel1;
		private IHIS.Framework.XLabel xLabel3;
		private IHIS.Framework.XLabel xLabel4;
		private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel6;
		private IHIS.Framework.XLabel xLabel9;
		private IHIS.Framework.XLabel xLabel10;
		private IHIS.Framework.XLabel xLabel11;
		private IHIS.Framework.XLabel xLabel13;
		private IHIS.Framework.XLabel xLabel16;
		private IHIS.Framework.XLabel xLabel17;
		private IHIS.Framework.XLabel xLabel18;
		private IHIS.Framework.XLabel xLabel19;
		private IHIS.Framework.XLabel xLabel20;
		private IHIS.Framework.XLabel xLabel21;
		private IHIS.Framework.XEditGrid grdHoCodeList;
		private IHIS.Framework.XDatePicker dtpEndDate;
		private IHIS.Framework.XEditMask txtSexFeMail;
		private IHIS.Framework.XEditMask txtSexMail;
		private IHIS.Framework.XFindBox fbxGwa;
		private IHIS.Framework.XDisplayBox dbxHoGwaName;
		private IHIS.Framework.XFindBox fbxHoMainGwa;
		private IHIS.Framework.XDisplayBox dbxHoMainGwaName;
		private IHIS.Framework.XFindBox fbxHoGrade;
		private IHIS.Framework.XEditMask txtHoDong;
        private IHIS.Framework.XDatePicker dtpStartDate;
		private IHIS.Framework.XEditMask txtHoUsedBed;
		private IHIS.Framework.XEditMask txtHoTotalBed;
		private IHIS.Framework.XDictComboBox cboHoStatus;
		private IHIS.Framework.XEditMask txtHoCode;
		private IHIS.Framework.XDisplayBox dbxHoGradeName;
		private IHIS.Framework.XDictComboBox cboHoSpecialYN;
		private IHIS.Framework.XFindWorker fwkCommon;
		private IHIS.Framework.XDatePicker dtpJukyongDate;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
        private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XComboItem xComboItem1;
		private IHIS.Framework.XComboItem xComboItem2;
		private IHIS.Framework.XDictComboBox cboHoSex;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell25;
		private IHIS.Framework.XEditGrid grdBAS0253;
		private IHIS.Framework.XEditGridCell xEditGridCell26;
		private IHIS.Framework.XEditGridCell xEditGridCell27;
		private IHIS.Framework.XEditGridCell xEditGridCell28;
		private IHIS.Framework.XEditGridCell xEditGridCell30;
		private IHIS.Framework.SingleLayout layComm;
		private IHIS.Framework.XLabel xLabel12;
		private IHIS.Framework.XDictComboBox cboHoGubun;
		private IHIS.Framework.XEditGridCell xEditGridCell31;
        private IHIS.Framework.XEditGridCell xEditGridCell29;
		private IHIS.Framework.XEditGridCell xEditGridCell34;
		private IHIS.Framework.XEditMask txtHoSort;
		private IHIS.Framework.XEditMask txtHoCodeName;
		private IHIS.Framework.XLabel xLabel15;
		private IHIS.Framework.XLabel xLabel22;
		private IHIS.Framework.XLabel xLabel23;
		private IHIS.Framework.XLabel xLabel24;
		private IHIS.Framework.XEditGridCell xEditGridCell35;
		private IHIS.Framework.XEditGridCell xEditGridCell36;
		private IHIS.Framework.XEditGridCell xEditGridCell37;
		private IHIS.Framework.XEditGridCell xEditGridCell38;
		private IHIS.Framework.XEditMask txtReportTotalBed;
		private IHIS.Framework.XCheckBox cbxDoubleHoYn;
		private IHIS.Framework.XButton btnRowCopy;
        private XToolTip xToolTip1;
        private XEditGridCell xEditGridCell8;
        private XPanel xPanel2;
        private XBuseoCombo cboHoDong;
        private XEditGridCell xEditGridCell9;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BAS0250U00()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BAS0250U00));
            this.grdHoCodeList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.dtpStartDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.txtHoCode = new IHIS.Framework.XEditMask();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.txtHoDong = new IHIS.Framework.XEditMask();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.fbxHoGrade = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.dbxHoGradeName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.txtHoTotalBed = new IHIS.Framework.XEditMask();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.txtHoUsedBed = new IHIS.Framework.XEditMask();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.fbxHoMainGwa = new IHIS.Framework.XFindBox();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.dbxHoMainGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.fbxGwa = new IHIS.Framework.XFindBox();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.dbxHoGwaName = new IHIS.Framework.XDisplayBox();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.cboHoSex = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.txtSexMail = new IHIS.Framework.XEditMask();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.txtSexFeMail = new IHIS.Framework.XEditMask();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.cboHoSpecialYN = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.dtpEndDate = new IHIS.Framework.XDatePicker();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.cboHoStatus = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.cboHoGubun = new IHIS.Framework.XDictComboBox();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.txtHoCodeName = new IHIS.Framework.XEditMask();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.txtHoSort = new IHIS.Framework.XEditMask();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.txtReportTotalBed = new IHIS.Framework.XEditMask();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.cbxDoubleHoYn = new IHIS.Framework.XCheckBox();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.dtpJukyongDate = new IHIS.Framework.XDatePicker();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel15 = new IHIS.Framework.XLabel();
            this.xLabel22 = new IHIS.Framework.XLabel();
            this.xLabel23 = new IHIS.Framework.XLabel();
            this.xLabel24 = new IHIS.Framework.XLabel();
            this.xLabel12 = new IHIS.Framework.XLabel();
            this.xLabel13 = new IHIS.Framework.XLabel();
            this.xLabel16 = new IHIS.Framework.XLabel();
            this.xLabel17 = new IHIS.Framework.XLabel();
            this.xLabel18 = new IHIS.Framework.XLabel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.xLabel20 = new IHIS.Framework.XLabel();
            this.xLabel21 = new IHIS.Framework.XLabel();
            this.xLabel11 = new IHIS.Framework.XLabel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.xLabel10 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.grdBAS0253 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell34 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.layComm = new IHIS.Framework.SingleLayout();
            this.btnRowCopy = new IHIS.Framework.XButton();
            this.xToolTip1 = new IHIS.Framework.XToolTip();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboHoDong = new IHIS.Framework.XBuseoCombo();
            ((System.ComponentModel.ISupportInitialize)(this.grdHoCodeList)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0253)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).BeginInit();
            this.SuspendLayout();
            // 
            // grdHoCodeList
            // 
            this.grdHoCodeList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell24,
            this.xEditGridCell31,
            this.xEditGridCell25,
            this.xEditGridCell35,
            this.xEditGridCell36,
            this.xEditGridCell37,
            this.xEditGridCell38,
            this.xEditGridCell8});
            this.grdHoCodeList.ColPerLine = 1;
            this.grdHoCodeList.Cols = 1;
            this.grdHoCodeList.ControlBinding = true;
            resources.ApplyResources(this.grdHoCodeList, "grdHoCodeList");
            this.grdHoCodeList.FixedRows = 1;
            this.grdHoCodeList.HeaderHeights.Add(23);
            this.grdHoCodeList.Name = "grdHoCodeList";
            this.grdHoCodeList.QuerySQL = resources.GetString("grdHoCodeList.QuerySQL");
            this.grdHoCodeList.Rows = 2;
            this.grdHoCodeList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdHoCodeList_QueryStarting);
            this.grdHoCodeList.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdHoCodeList_GridCellPainting);
            this.grdHoCodeList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdHoCodeList_RowFocusChanged);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.BindControl = this.dtpStartDate;
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsNotNull = true;
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // dtpStartDate
            // 
            resources.ApplyResources(this.dtpStartDate, "dtpStartDate");
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpHoCodeYMD_DataValidating);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.ApplyPaintingEvent = true;
            this.xEditGridCell2.ApplySelectedBackColorOnPaint = false;
            this.xEditGridCell2.ApplySelectedForeColorOnPaint = false;
            this.xEditGridCell2.BindControl = this.txtHoCode;
            this.xEditGridCell2.CellLen = 4;
            this.xEditGridCell2.CellName = "ho_code";
            this.xEditGridCell2.CellWidth = 85;
            this.xEditGridCell2.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsNotNull = true;
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtHoCode
            // 
            this.txtHoCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtHoCode, "txtHoCode");
            this.txtHoCode.Name = "txtHoCode";
            this.txtHoCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtHoCode_DataValidating);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.BindControl = this.txtHoDong;
            this.xEditGridCell3.CellLen = 4;
            this.xEditGridCell3.CellName = "ho_dong";
            this.xEditGridCell3.Col = -1;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // txtHoDong
            // 
            this.txtHoDong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtHoDong, "txtHoDong");
            this.txtHoDong.Name = "txtHoDong";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.BindControl = this.fbxHoGrade;
            this.xEditGridCell4.CellLen = 3;
            this.xEditGridCell4.CellName = "ho_grade";
            this.xEditGridCell4.Col = -1;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsNotNull = true;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // fbxHoGrade
            // 
            this.fbxHoGrade.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHoGrade.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxHoGrade, "fbxHoGrade");
            this.fbxHoGrade.Name = "fbxHoGrade";
            this.fbxHoGrade.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHoGrade_DataValidating);
            this.fbxHoGrade.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "code";
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "code_name";
            this.findColumnInfo2.ColWidth = 293;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.BindControl = this.dbxHoGradeName;
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "ho_grade_name";
            this.xEditGridCell5.Col = -1;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdCol = false;
            this.xEditGridCell5.IsVisible = false;
            this.xEditGridCell5.Row = -1;
            // 
            // dbxHoGradeName
            // 
            resources.ApplyResources(this.dbxHoGradeName, "dbxHoGradeName");
            this.dbxHoGradeName.Name = "dbxHoGradeName";
            this.dbxHoGradeName.MouseHover += new System.EventHandler(this.dbxHoGradeName_MouseHover);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.BindControl = this.txtHoTotalBed;
            this.xEditGridCell6.CellName = "ho_total_bed";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.Col = -1;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.InitValue = "0";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // txtHoTotalBed
            // 
            this.txtHoTotalBed.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtHoTotalBed.GeneralNumberFormat = true;
            resources.ApplyResources(this.txtHoTotalBed, "txtHoTotalBed");
            this.txtHoTotalBed.Name = "txtHoTotalBed";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.BindControl = this.txtHoUsedBed;
            this.xEditGridCell7.CellName = "ho_used_bed";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell7.Col = -1;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.InitValue = "0";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // txtHoUsedBed
            // 
            this.txtHoUsedBed.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtHoUsedBed.GeneralNumberFormat = true;
            resources.ApplyResources(this.txtHoUsedBed, "txtHoUsedBed");
            this.txtHoUsedBed.Name = "txtHoUsedBed";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ho_com_bed";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell11.Col = -1;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "ho_com_used_bed";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell12.Col = -1;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.BindControl = this.fbxHoMainGwa;
            this.xEditGridCell13.CellName = "ho_main_gwa";
            this.xEditGridCell13.Col = -1;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // fbxHoMainGwa
            // 
            this.fbxHoMainGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxHoMainGwa.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxHoMainGwa, "fbxHoMainGwa");
            this.fbxHoMainGwa.Name = "fbxHoMainGwa";
            this.fbxHoMainGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHoMainGwa_DataValidating);
            this.fbxHoMainGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.BindControl = this.dbxHoMainGwaName;
            this.xEditGridCell14.CellLen = 80;
            this.xEditGridCell14.CellName = "gwa_main_name";
            this.xEditGridCell14.Col = -1;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdCol = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // dbxHoMainGwaName
            // 
            resources.ApplyResources(this.dbxHoMainGwaName, "dbxHoMainGwaName");
            this.dbxHoMainGwaName.Name = "dbxHoMainGwaName";
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.BindControl = this.fbxGwa;
            this.xEditGridCell15.CellName = "ho_gwa";
            this.xEditGridCell15.Col = -1;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // fbxGwa
            // 
            this.fbxGwa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fbxGwa.FindWorker = this.fwkCommon;
            resources.ApplyResources(this.fbxGwa, "fbxGwa");
            this.fbxGwa.Name = "fbxGwa";
            this.fbxGwa.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxGwa_DataValidating);
            this.fbxGwa.FindClick += new System.ComponentModel.CancelEventHandler(this.FindBox_FindClick);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.BindControl = this.dbxHoGwaName;
            this.xEditGridCell16.CellLen = 80;
            this.xEditGridCell16.CellName = "gwa_name";
            this.xEditGridCell16.Col = -1;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // dbxHoGwaName
            // 
            resources.ApplyResources(this.dbxHoGwaName, "dbxHoGwaName");
            this.dbxHoGwaName.Name = "dbxHoGwaName";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "ho_loc";
            this.xEditGridCell17.Col = -1;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.BindControl = this.cboHoSex;
            this.xEditGridCell18.CellName = "ho_sex";
            this.xEditGridCell18.CellWidth = 81;
            this.xEditGridCell18.Col = -1;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            // 
            // cboHoSex
            // 
            resources.ApplyResources(this.cboHoSex, "cboHoSex");
            this.cboHoSex.Name = "cboHoSex";
            this.cboHoSex.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoSex.UserSQL = "SELECT \'\', \'\' FROM DUAL\r\n UNION \r\nSELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n" +
                " WHERE HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND CODE_TYPE = \'SEX_GUBUN\'";
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.BindControl = this.txtSexMail;
            this.xEditGridCell19.CellName = "ho_sex_mail";
            this.xEditGridCell19.Col = -1;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // txtSexMail
            // 
            this.txtSexMail.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSexMail.GeneralNumberFormat = true;
            resources.ApplyResources(this.txtSexMail, "txtSexMail");
            this.txtSexMail.Name = "txtSexMail";
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.BindControl = this.txtSexFeMail;
            this.xEditGridCell20.CellName = "ho_sex_femail";
            this.xEditGridCell20.Col = -1;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsVisible = false;
            this.xEditGridCell20.Row = -1;
            // 
            // txtSexFeMail
            // 
            this.txtSexFeMail.EditMaskType = IHIS.Framework.MaskType.Number;
            this.txtSexFeMail.GeneralNumberFormat = true;
            resources.ApplyResources(this.txtSexFeMail, "txtSexFeMail");
            this.txtSexFeMail.Name = "txtSexFeMail";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.BindControl = this.cboHoSpecialYN;
            this.xEditGridCell21.CellName = "ho_special_yn";
            this.xEditGridCell21.Col = -1;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // cboHoSpecialYN
            // 
            this.cboHoSpecialYN.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            resources.ApplyResources(this.cboHoSpecialYN, "cboHoSpecialYN");
            this.cboHoSpecialYN.Name = "cboHoSpecialYN";
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "Y";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "N";
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.BindControl = this.dtpEndDate;
            this.xEditGridCell22.CellName = "end_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = -1;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // dtpEndDate
            // 
            resources.ApplyResources(this.dtpEndDate, "dtpEndDate");
            this.dtpEndDate.Name = "dtpEndDate";
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.BindControl = this.cboHoStatus;
            this.xEditGridCell24.CellName = "ho_status";
            this.xEditGridCell24.Col = -1;
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // cboHoStatus
            // 
            resources.ApplyResources(this.cboHoStatus, "cboHoStatus");
            this.cboHoStatus.Name = "cboHoStatus";
            this.cboHoStatus.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoStatus.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'HO_STATUS\'";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.BindControl = this.cboHoGubun;
            this.xEditGridCell31.CellName = "ho_gubun";
            this.xEditGridCell31.Col = -1;
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            // 
            // cboHoGubun
            // 
            resources.ApplyResources(this.cboHoGubun, "cboHoGubun");
            this.cboHoGubun.Name = "cboHoGubun";
            this.cboHoGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboHoGubun.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'HO_GUBUN\'\r\n ORDER BY CODE";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellLen = 1;
            this.xEditGridCell25.CellName = "retrieve_yn";
            this.xEditGridCell25.Col = -1;
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.BindControl = this.txtHoCodeName;
            this.xEditGridCell35.CellName = "ho_code_name";
            this.xEditGridCell35.Col = -1;
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsVisible = false;
            this.xEditGridCell35.Row = -1;
            // 
            // txtHoCodeName
            // 
            resources.ApplyResources(this.txtHoCodeName, "txtHoCodeName");
            this.txtHoCodeName.Name = "txtHoCodeName";
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.BindControl = this.txtHoSort;
            this.xEditGridCell36.CellName = "ho_sort";
            this.xEditGridCell36.Col = -1;
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsVisible = false;
            this.xEditGridCell36.Row = -1;
            // 
            // txtHoSort
            // 
            this.txtHoSort.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.txtHoSort, "txtHoSort");
            this.txtHoSort.MaxinumCipher = 3;
            this.txtHoSort.Name = "txtHoSort";
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.BindControl = this.txtReportTotalBed;
            this.xEditGridCell37.CellName = "report_total_bed";
            this.xEditGridCell37.Col = -1;
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.IsVisible = false;
            this.xEditGridCell37.Row = -1;
            // 
            // txtReportTotalBed
            // 
            this.txtReportTotalBed.EditMaskType = IHIS.Framework.MaskType.Number;
            resources.ApplyResources(this.txtReportTotalBed, "txtReportTotalBed");
            this.txtReportTotalBed.MaxinumCipher = 3;
            this.txtReportTotalBed.Name = "txtReportTotalBed";
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.BindControl = this.cbxDoubleHoYn;
            this.xEditGridCell38.CellName = "double_ho_yn";
            this.xEditGridCell38.Col = -1;
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.InitValue = "N";
            this.xEditGridCell38.IsVisible = false;
            this.xEditGridCell38.Row = -1;
            // 
            // cbxDoubleHoYn
            // 
            resources.ApplyResources(this.cbxDoubleHoYn, "cbxDoubleHoYn");
            this.cbxDoubleHoYn.Name = "cbxDoubleHoYn";
            this.cbxDoubleHoYn.UseVisualStyleBackColor = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "end_yn";
            this.xEditGridCell8.Col = -1;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // dtpJukyongDate
            // 
            resources.ApplyResources(this.dtpJukyongDate, "dtpJukyongDate");
            this.dtpJukyongDate.Name = "dtpJukyongDate";
            // 
            // xPanel1
            // 
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.cbxDoubleHoYn);
            this.xPanel1.Controls.Add(this.txtReportTotalBed);
            this.xPanel1.Controls.Add(this.txtHoSort);
            this.xPanel1.Controls.Add(this.txtHoCodeName);
            this.xPanel1.Controls.Add(this.xLabel15);
            this.xPanel1.Controls.Add(this.xLabel22);
            this.xPanel1.Controls.Add(this.xLabel23);
            this.xPanel1.Controls.Add(this.xLabel24);
            this.xPanel1.Controls.Add(this.cboHoGubun);
            this.xPanel1.Controls.Add(this.xLabel12);
            this.xPanel1.Controls.Add(this.cboHoSex);
            this.xPanel1.Controls.Add(this.cboHoSpecialYN);
            this.xPanel1.Controls.Add(this.dtpEndDate);
            this.xPanel1.Controls.Add(this.txtSexFeMail);
            this.xPanel1.Controls.Add(this.txtSexMail);
            this.xPanel1.Controls.Add(this.fbxGwa);
            this.xPanel1.Controls.Add(this.dbxHoGwaName);
            this.xPanel1.Controls.Add(this.fbxHoMainGwa);
            this.xPanel1.Controls.Add(this.dbxHoMainGwaName);
            this.xPanel1.Controls.Add(this.fbxHoGrade);
            this.xPanel1.Controls.Add(this.txtHoDong);
            this.xPanel1.Controls.Add(this.dtpStartDate);
            this.xPanel1.Controls.Add(this.txtHoUsedBed);
            this.xPanel1.Controls.Add(this.txtHoTotalBed);
            this.xPanel1.Controls.Add(this.cboHoStatus);
            this.xPanel1.Controls.Add(this.txtHoCode);
            this.xPanel1.Controls.Add(this.xLabel13);
            this.xPanel1.Controls.Add(this.xLabel16);
            this.xPanel1.Controls.Add(this.xLabel17);
            this.xPanel1.Controls.Add(this.xLabel18);
            this.xPanel1.Controls.Add(this.xLabel19);
            this.xPanel1.Controls.Add(this.xLabel20);
            this.xPanel1.Controls.Add(this.xLabel21);
            this.xPanel1.Controls.Add(this.xLabel11);
            this.xPanel1.Controls.Add(this.xLabel9);
            this.xPanel1.Controls.Add(this.xLabel10);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.xLabel6);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.dbxHoGradeName);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // xLabel15
            // 
            this.xLabel15.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel15.EdgeRounding = false;
            this.xLabel15.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel15.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel15, "xLabel15");
            this.xLabel15.Name = "xLabel15";
            // 
            // xLabel22
            // 
            this.xLabel22.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel22.EdgeRounding = false;
            this.xLabel22.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel22.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel22, "xLabel22");
            this.xLabel22.Name = "xLabel22";
            // 
            // xLabel23
            // 
            this.xLabel23.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel23.EdgeRounding = false;
            this.xLabel23.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel23.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel23, "xLabel23");
            this.xLabel23.Name = "xLabel23";
            // 
            // xLabel24
            // 
            this.xLabel24.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel24.EdgeRounding = false;
            this.xLabel24.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel24.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel24, "xLabel24");
            this.xLabel24.Name = "xLabel24";
            // 
            // xLabel12
            // 
            this.xLabel12.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel12.EdgeRounding = false;
            this.xLabel12.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel12.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel12, "xLabel12");
            this.xLabel12.Name = "xLabel12";
            // 
            // xLabel13
            // 
            this.xLabel13.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel13.EdgeRounding = false;
            this.xLabel13.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel13.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel13, "xLabel13");
            this.xLabel13.Name = "xLabel13";
            // 
            // xLabel16
            // 
            this.xLabel16.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel16.EdgeRounding = false;
            this.xLabel16.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel16.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel16, "xLabel16");
            this.xLabel16.Name = "xLabel16";
            // 
            // xLabel17
            // 
            this.xLabel17.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel17.EdgeRounding = false;
            this.xLabel17.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel17.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel17, "xLabel17");
            this.xLabel17.Name = "xLabel17";
            // 
            // xLabel18
            // 
            this.xLabel18.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel18.EdgeRounding = false;
            this.xLabel18.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel18.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel18, "xLabel18");
            this.xLabel18.Name = "xLabel18";
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel19.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel19, "xLabel19");
            this.xLabel19.Name = "xLabel19";
            // 
            // xLabel20
            // 
            this.xLabel20.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel20.EdgeRounding = false;
            this.xLabel20.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel20.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel20, "xLabel20");
            this.xLabel20.Name = "xLabel20";
            // 
            // xLabel21
            // 
            this.xLabel21.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel21.EdgeRounding = false;
            this.xLabel21.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel21.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel21, "xLabel21");
            this.xLabel21.Name = "xLabel21";
            // 
            // xLabel11
            // 
            this.xLabel11.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel11.EdgeRounding = false;
            this.xLabel11.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel11.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel11, "xLabel11");
            this.xLabel11.Name = "xLabel11";
            // 
            // xLabel9
            // 
            this.xLabel9.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel9.EdgeRounding = false;
            this.xLabel9.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel9.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Name = "xLabel9";
            // 
            // xLabel10
            // 
            this.xLabel10.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel10.EdgeRounding = false;
            this.xLabel10.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel10.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel10, "xLabel10");
            this.xLabel10.Name = "xLabel10";
            // 
            // xLabel5
            // 
            this.xLabel5.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel5.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(243)))), ((int)(((byte)(235)))));
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.ForeColor = IHIS.Framework.XColor.XDataGridLinkColor;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // grdBAS0253
            // 
            this.grdBAS0253.CallerID = '2';
            this.grdBAS0253.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell34,
            this.xEditGridCell9});
            this.grdBAS0253.ColPerLine = 5;
            this.grdBAS0253.Cols = 5;
            resources.ApplyResources(this.grdBAS0253, "grdBAS0253");
            this.grdBAS0253.FixedRows = 1;
            this.grdBAS0253.HeaderHeights.Add(17);
            this.grdBAS0253.Name = "grdBAS0253";
            this.grdBAS0253.QuerySQL = resources.GetString("grdBAS0253.QuerySQL");
            this.grdBAS0253.Rows = 2;
            this.grdBAS0253.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdBAS0253_QueryStarting);
            this.grdBAS0253.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdBAS0253_PreSaveLayout);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellLen = 4;
            this.xEditGridCell26.CellName = "ho_code";
            this.xEditGridCell26.Col = -1;
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsNotNull = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellLen = 2;
            this.xEditGridCell27.CellName = "bed_no";
            this.xEditGridCell27.CellWidth = 100;
            this.xEditGridCell27.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.ImeMode = IHIS.Framework.ColumnImeMode.Eng;
            this.xEditGridCell27.IsNotNull = true;
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "from_bed_date";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell28.CellWidth = 100;
            this.xEditGridCell28.Col = 1;
            this.xEditGridCell28.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell28.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsNotNull = true;
            this.xEditGridCell28.IsUpdatable = false;
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.CellName = "to_bed_date";
            this.xEditGridCell29.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell29.CellWidth = 130;
            this.xEditGridCell29.Col = 2;
            this.xEditGridCell29.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell29.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.CellLen = 2;
            this.xEditGridCell30.CellName = "bed_status";
            this.xEditGridCell30.CellWidth = 150;
            this.xEditGridCell30.Col = 3;
            this.xEditGridCell30.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell30.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell30.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell30.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM BAS0102 \r\n WHERE HOSP_CODE = FN_ADM_LOAD_HO" +
                "SP_CODE()\r\n   AND CODE_TYPE = \'BED_STATUS\'";
            // 
            // xEditGridCell34
            // 
            this.xEditGridCell34.CellLen = 20;
            this.xEditGridCell34.CellName = "bed_no_tel";
            this.xEditGridCell34.CellWidth = 170;
            this.xEditGridCell34.Col = 4;
            this.xEditGridCell34.HeaderGradientEnd = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            resources.ApplyResources(this.xEditGridCell34, "xEditGridCell34");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "ho_dong";
            this.xEditGridCell9.Col = -1;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsNotNull = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // btnRowCopy
            // 
            this.btnRowCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnRowCopy.Image")));
            resources.ApplyResources(this.btnRowCopy, "btnRowCopy");
            this.btnRowCopy.Name = "btnRowCopy";
            this.btnRowCopy.Scheme = IHIS.Framework.XButtonSchemes.HotPink;
            this.btnRowCopy.Click += new System.EventHandler(this.btnRowCopy_Click);
            // 
            // xToolTip1
            // 
            this.xToolTip1.AutoPopDelay = 10000;
            this.xToolTip1.InitialDelay = 200;
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.btnRowCopy);
            this.xPanel2.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // cboHoDong
            // 
            this.cboHoDong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            resources.ApplyResources(this.cboHoDong, "cboHoDong");
            this.cboHoDong.Name = "cboHoDong";
            this.cboHoDong.SelectionChangeCommitted += new System.EventHandler(this.cboHoDong_SelectionChangeCommitted);
            // 
            // BAS0250U00
            // 
            this.Controls.Add(this.cboHoDong);
            this.Controls.Add(this.grdBAS0253);
            this.Controls.Add(this.dtpJukyongDate);
            this.Controls.Add(this.xLabel1);
            this.Controls.Add(this.xLabel2);
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.grdHoCodeList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.xPanel2);
            this.Name = "BAS0250U00";
            resources.ApplyResources(this, "$this");
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.BAS0250U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdHoCodeList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBAS0253)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboHoDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Screen변수 

		private string mMsg = "";
		private string mCaption = "";
        private string mHospCode = "";

		#endregion

		#region Screen Open

		private void BAS0250U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;
            this.grdHoCodeList.SavePerformer = new XSavePeformer(this);
            this.grdBAS0253.SavePerformer = this.grdHoCodeList.SavePerformer;

            this.cboHoDong.SetDataValue("1");
			this.dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

			this.ProtectControlAll(true);

			this.CurrMSLayout = this.grdHoCodeList;

            this.grdHoCodeList.QueryLayout(false);
		}

		#endregion

		#region FindBox FindClick

		private void FindBox_FindClick(object sender, System.ComponentModel.CancelEventArgs e)
		{
			XFindBox control = (XFindBox) sender;

			switch (control.Name)
			{
				case "fbxHoDong":
                    this.fwkCommon.InputSQL = @"SELECT A.GWA
                                                     , A.GWA_NAME
                                                  FROM BAS0260 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND TO_DATE(:f_jukyong_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   AND A.BUSEO_GUBUN  = '2'
                                                   AND (  A.GWA      LIKE :f_find1 || '%'
                                                       OR A.GWA_NAME LIKE :f_find1 || '%')
                                                 ORDER BY A.GWA";

                    this.fwkCommon.FormText = Resource.TEXT1;
					this.fwkCommon.ColInfos[0].HeaderText = Resource.TEXT2;
                    this.fwkCommon.ColInfos[1].HeaderText = Resource.TEXT3;
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_jukyong_date", this.dtpJukyongDate.GetDataValue());
					break;
                case "fbxHoGrade":

                    this.fwkCommon.InputSQL = @"SELECT A.HO_GRADE
                                                     , A.HO_GRADE_NAME
                                                  FROM BAS0251 A
                                                 WHERE A.HOSP_CODE    = :f_hosp_code
                                                   AND (  A.HO_GRADE      LIKE :f_find1 || '%'
                                                       OR A.HO_GRADE_NAME LIKE :f_find1 || '%' )
                                                   AND :f_start_date BETWEEN A.START_DATE AND A.END_DATE
                                                 ORDER BY HO_GRADE";

					this.fwkCommon.FormText = Resource.TEXT4;
                    this.fwkCommon.ColInfos[0].HeaderText = Resource.TEXT5;
                    this.fwkCommon.ColInfos[1].HeaderText = Resource.TEXT6;
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_start_date", this.dtpStartDate.GetDataValue());
					break;
				case "fbxHoMainGwa":
                    this.fwkCommon.InputSQL = @"SELECT A.GWA
                                                     , A.GWA_NAME
                                                  FROM BAS0260 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND TO_DATE(:f_jukyong_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   AND A.BUSEO_GUBUN = '1'
                                                   AND (  A.GWA         LIKE :f_find1 || '%'
                                                       OR A.GWA_NAME    LIKE :f_find1 || '%')
                                                 ORDER BY A.GWA";

					this.fwkCommon.FormText = Resource.TEXT7;
					this.fwkCommon.ColInfos[0].HeaderText = Resource.TEXT8;
					this.fwkCommon.ColInfos[1].HeaderText = Resource.TEXT9;

                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_jukyong_date", this.dtpStartDate.GetDataValue());
					break;
                case "fbxGwa":
                    this.fwkCommon.InputSQL = @"SELECT A.GWA
                                                     , A.GWA_NAME
                                                  FROM BAS0260 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code 
                                                   AND TO_DATE(:f_jukyong_date, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE
                                                   AND A.BUSEO_GUBUN = '1'
                                                   AND (  A.GWA         LIKE :f_find1 || '%'
                                                       OR A.GWA_NAME    LIKE :f_find1 || '%')
                                                 ORDER BY A.GWA";

					this.fwkCommon.FormText = Resource.TEXT7;
					this.fwkCommon.ColInfos[0].HeaderText = Resource.TEXT8;
                    this.fwkCommon.ColInfos[1].HeaderText = Resource.TEXT9;
                    this.fwkCommon.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                    this.fwkCommon.SetBindVarValue("f_jukyong_date", this.dtpStartDate.GetDataValue());
					break;
			}
		}

		#endregion

		#region ButtonList

		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Delete:

					// 삭제 버튼 클릭시 
					// 실제삭제가 되는것이 아니라 불용데이트에 날자를 셋팅 해준다.
					if (this.CurrMSLayout == this.grdHoCodeList)
					{
                        if (this.grdHoCodeList.GetRowState(this.grdHoCodeList.CurrentRowNumber) != DataRowState.Added)
                        {
                            this.dtpEndDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
                            this.dtpEndDate.AcceptData();

                            for (int i = 0; i < this.grdBAS0253.RowCount; i++)
                            {
                                this.grdBAS0253.SetItemValue(i, "to_bed_date", (EnvironInfo.GetSysDate().AddDays(-1)).ToString("yyyy/MM/dd"));
                            }

                            e.IsBaseCall = false;
                        }
					}
					else
					{
                        if (this.grdBAS0253.GetRowState(this.grdBAS0253.CurrentRowNumber) != DataRowState.Added)
                        {
                            this.grdBAS0253.SetItemValue(grdBAS0253.CurrentRowNumber, "to_bed_date", (EnvironInfo.GetSysDate().AddDays(-1)).ToString("yyyy/MM/dd"));

                            e.IsBaseCall = false;
                        }
					}

					break;

				case FunctionType.Insert:

					// 입력가능한 베드수를 초과한 경우
					// 더이상 입력이 되지 않도록 한다.
					if (this.CurrMSLayout == this.grdBAS0253)
					{
						if (this.grdHoCodeList.RowCount <= 0)
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "베드를 등록할 병실이 없습니다." : "病床を登録する病室がありません。");
							this.mCaption = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

							XMessageBox.Show(this.mMsg, this.mCaption);

							e.IsBaseCall = false;
							e.IsSuccess = false;

							return;
						}

						if (this.grdHoCodeList.GetItemInt(grdHoCodeList.CurrentRowNumber, "ho_total_bed") <= this.grdBAS0253.RowCount)
						{
							this.mMsg = (NetInfo.Language == LangMode.Ko ? "등록가능한 베드수를 초과하였습니다." : "登録可能な病床数を超過しました。");
							this.mCaption = (NetInfo.Language == LangMode.Ko ? "알림" : "お知らせ");

							XMessageBox.Show(this.mMsg, this.mCaption);

							e.IsBaseCall = false;
							e.IsSuccess = false;

							return;
						}
					}
					break;
				case FunctionType.Update:

					// 업데이트 서비스 콜
                    try
                    {
                        Service.BeginTransaction();

                        if (this.grdHoCodeList.SaveLayout())
                        {
                            if (this.grdBAS0253.SaveLayout())
                            {
                                this.mMsg = (NetInfo.Language == LangMode.Ko ? "정상적으로 저장 되었습니다." : "保存が完了しました。");

                                XMessageBox.Show(this.mMsg, "保存");

                                //this.btnList.PerformClick(FunctionType.Query);
                            }
                            else
                                throw new Exception();
                        }
                        else
                            throw new Exception();
                        Service.CommitTransaction();
                    }
                    catch
                    {
                        this.mMsg ="保存に失敗しました。\r\n" + Service.ErrFullMsg;
                        XMessageBox.Show(this.mMsg, Resource.TEXT18, MessageBoxIcon.Error);
                    }

					e.IsBaseCall = false;
					break;
			}
		}

		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch (e.Func)
			{
				case FunctionType.Insert:

					// 입력후 기본값 셋팅
					if (e.IsSuccess)
					{
						if (this.CurrMSLayout == this.grdHoCodeList )
						{
							this.DefaultSetting();
							this.txtHoCode.Focus();
						}
						else
						{
                            this.grdBAS0253.SetItemValue(grdBAS0253.CurrentRowNumber, "from_bed_date", this.dtpJukyongDate.GetDataValue());
                            this.grdBAS0253.SetItemValue(grdBAS0253.CurrentRowNumber, "to_bed_date", "9998/12/31");
							this.grdBAS0253.SetItemValue(grdBAS0253.CurrentRowNumber, "bed_status", "00");
						}
					}

					break;

				case FunctionType.Reset:

					this.dtpJukyongDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
					this.dtpEndDate.AcceptData();

					this.ProtectControlAll(true);
                    this.cboHoDong.SetDataValue("1");
					break;

				case FunctionType.Update:
					break;
			}
		}

		#endregion

		#region Function

		private bool DupCheck(int rowNumber, string aHoCode, string aJukyongDate)
		{
			for (int i=0; i<grdHoCodeList.RowCount; i++)
			{
				if (grdHoCodeList.GetItemString(i, "ho_code") == aHoCode &&
					grdHoCodeList.GetItemString(i, "start_date") == aJukyongDate  && i != rowNumber)
				{
					return true;
				}
			}

			return false;
		}

		private void ProtectControl(bool aIsProtect)
		{
			// 테이블의 키값은 protect 건다.
			this.txtHoCode.Protect = aIsProtect;
			this.dtpStartDate.Protect = aIsProtect;

			// 병동코드는 무조건 Protect
			this.txtHoDong.Protect = true;
		}

		private void ProtectControlAll(bool aIsProtect)
		{
			for (int i=0; i<this.xPanel1.Controls.Count; i++)
			{
				if (this.xPanel1.Controls[i] is IDataControl)
				{
					((IDataControl) (this.xPanel1.Controls[i])).Protect = aIsProtect;
				}
			}
		}

		private void DefaultSetting()
		{
			// 초기값 
			// 날자
			this.dtpStartDate.SetEditValue(this.dtpJukyongDate.GetDataValue());
			this.dtpStartDate.AcceptData();
            //병실료
            this.fbxHoGrade.Focus();
            this.fbxHoGrade.SetEditValue("00");
            this.fbxHoGrade.AcceptData();
			// 병동
			this.txtHoDong.SetEditValue(this.cboHoDong.GetDataValue());
			this.txtHoDong.AcceptData();
			// 대표과 (내과로...)
            //this.fbxHoMainGwa.Focus();
            //this.fbxHoMainGwa.SetEditValue("01");
            //this.fbxHoMainGwa.AcceptData();
			// 해당과 (내과로...)
            //this.fbxGwa.Focus();
            //this.fbxGwa.SetEditValue("01");
            //this.fbxGwa.AcceptData();
			// 병실상태
			this.cboHoStatus.SetEditValue("1");
			this.cboHoStatus.AcceptData();
			// 특실여부
			this.cboHoSpecialYN.SetEditValue("N");
			this.cboHoSpecialYN.AcceptData();
			// 병실남여
			this.cboHoSex.SetEditValue("C");
			this.cboHoSex.AcceptData();

            this.dtpEndDate.SetEditValue("9998/12/31");
            this.dtpEndDate.AcceptData();
		}

		#endregion

		#region DataValidating

		private void txtHoCode_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string msg = "";

			if (DupCheck(this.grdHoCodeList.CurrentRowNumber, e.DataValue, this.dtpStartDate.GetDataValue()))
			{
				msg = (NetInfo.Language == LangMode.Ko ? "동일한 병실코드가 있습니다." : Resource.TEXT10);

				this.SetMsg(msg, MsgType.Error);

				e.Cancel = true;
			}
			else
			{
				this.SetMsg("");
			}
		}

		private void dtpHoCodeYMD_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			string msg = "";

			if (DupCheck(this.grdHoCodeList.CurrentRowNumber, this.txtHoCode.GetDataValue(), e.DataValue))
			{
                msg = (NetInfo.Language == LangMode.Ko ? "동일한 병실코드가 있습니다." : Resource.TEXT10);

				this.SetMsg(msg, MsgType.Error);

				e.Cancel = true;
			}
			else
			{
				this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "start_date", e.DataValue);
				this.SetMsg("");
			}
		}

		#endregion

		#region XGrid

		private void grdHoCodeList_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
		{
			if (this.grdHoCodeList.GetItemString(e.CurrentRow, "retrieve_yn") == "Y")
			{
				this.ProtectControl(true);
			}
			else
			{
				this.ProtectControl(false);
			}

			// BED정보z 서비스 콜
			this.grdBAS0253.QueryLayout(false);
		}

        private void grdBAS0253_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
             //입력된 행일경우 마스터와의 키값인 ho_code를 입력한다.
                if (e.RowState == DataRowState.Added)
                {
                    grdBAS0253.SetItemValue(e.RowNumber, "ho_dong", this.cboHoDong.GetDataValue());
                    grdBAS0253.SetItemValue(e.RowNumber, "ho_code", grdHoCodeList.GetItemString(grdHoCodeList.CurrentRowNumber, "ho_code"));
                }
        }
		#endregion


		private void fbxHoGrade_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 공백입력시
			if (e.DataValue == "")
			{
				this.dbxHoGradeName.SetDataValue("");
				this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "ho_grade_name", "");

				return;
			}

			// 벨리데이션 서비스 초기화
			this.layComm.LayoutItems.Clear();

			// WorkTp
            this.layComm.QuerySQL = @"SELECT A.HO_GRADE_NAME
                                          FROM BAS0251 A
                                         WHERE A.HOSP_CODE    = :f_hosp_code
                                           AND A.HO_GRADE     = :f_ho_grade
                                           AND :f_ho_grade_ymd BETWEEN A.START_DATE AND A.END_DATE";

            // 입력변수
            this.layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComm.SetBindVarValue("f_ho_grade", e.DataValue);
            this.layComm.SetBindVarValue("f_ho_grade_ymd", this.dtpStartDate.GetDataValue());

			// 출력변수
			this.layComm.LayoutItems.Add("ho_grade_name");
			
			// 서비스에러 체크
            if (this.layComm.QueryLayout())
			{
				if (this.layComm.GetItemValue("ho_grade_name").ToString() == "")
				{
					this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : Resource.TEXT11);

					this.SetMsg(this.mMsg, MsgType.Error);

					e.Cancel = true;
					return;
				}

                this.dbxHoGradeName.SetDataValue(this.layComm.GetItemValue("ho_grade_name"));
                this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "ho_grade_name", this.layComm.GetItemValue("ho_grade_name"));
			}
			else
			{
                this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : Resource.TEXT11);

				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;
				return;
			}

			return;		
		}

		private void fbxHoMainGwa_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
			// 공백입력시
			if (e.DataValue == "")
			{
				this.dbxHoMainGwaName.SetDataValue("");
				this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "gwa_main_name", "");

				return;
			}

			// 벨리데이션 서비스 초기화
			this.layComm.LayoutItems.Clear();

			// WorkTp
            this.layComm.QuerySQL = @"SELECT A.GWA_NAME
                                          FROM BAS0260 A
                                         WHERE A.HOSP_CODE   = :f_hosp_code
                                           AND A.BUSEO_GUBUN = '1'
                                           AND A.GWA         = :f_gwa
                                           AND TO_DATE(:f_buseo_ymd, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

            // 입력변수
            this.layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layComm.SetBindVarValue("f_gwa", e.DataValue);
            this.layComm.SetBindVarValue("f_buseo_ymd", this.dtpStartDate.GetDataValue());

			// 출력변수
			this.layComm.LayoutItems.Add("gwa_main_name");
			
            if (this.layComm.QueryLayout())
			{
				if (this.layComm.GetItemValue("gwa_main_name").ToString() == "")
				{
                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : Resource.TEXT12);

					this.SetMsg(this.mMsg, MsgType.Error);

					e.Cancel = true;
					return;
				}

                this.dbxHoMainGwaName.SetDataValue(this.layComm.GetItemValue("gwa_main_name"));
                this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "gwa_main_name", this.layComm.GetItemValue("gwa_main_name"));
			}
			else
			{
                this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : Resource.TEXT12);

				this.SetMsg(this.mMsg, MsgType.Error);

				e.Cancel = true;
				return;
			}

			return;				
		}

        //비져블 false이르모 사용안될것임.
		private void fbxGwa_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
//            // 공백입력시
//            if (e.DataValue == "")
//            {
//                this.dbxHoGwaName.SetDataValue("");
//                this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "gwa_name", "");

//                return;
//            }

//            // 벨리데이션 서비스 초기화
//            this.layComm.LayoutItems.Clear();

//            // WorkTp
//            this.layComm.QuerySQL = @"SELECT A.GWA_NAME
//                                      FROM BAS0260 A
//                                     WHERE A.HOSP_CODE   = :f_hosp_code 
//                                       AND A.BUSEO_GUBUN = '1'
//                                       AND A.GWA         = :f_gwa
//                                       AND TO_DATE(:f_buseo_ymd, 'YYYY/MM/DD') BETWEEN A.START_DATE AND A.END_DATE";

//            // 입력변수
//            this.layComm.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
//            this.layComm.SetBindVarValue("f_gwa", e.DataValue);
//            this.layComm.SetBindVarValue("f_buseo_ymd", this.dtpStartDate.GetDataValue());

//            // 출력변수
//            this.layComm.LayoutItems.Add("gwa_name");
			
//            // 서비스에러 체크
//            if (this.layComm.QueryLayout())
//            {
//                if (this.layComm.GetItemValue("gwa_name").ToString() == "")
//                {
//                    this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : "間違って入力された情報です。");

//                    this.SetMsg(this.mMsg, MsgType.Error);

//                    e.Cancel = true;
//                    return;
//                }

//                this.dbxHoGwaName.SetDataValue(this.layComm.GetItemValue("gwa_name"));
//                this.grdHoCodeList.SetItemValue(grdHoCodeList.CurrentRowNumber, "gwa_name", this.layComm.GetItemValue("gwa_name"));
//            }
//            else
//            {
//                this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : "間違って入力された情報です。");

//                this.SetMsg(this.mMsg, MsgType.Error);

//                e.Cancel = true;
//                return;
//            }

//            return;			
		}

		private void fbxWingGubun_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
		{
            //// 공백입력시
            //this.dbxWingGubun.SetDataValue("");
            //if (e.DataValue == "")
            //{
            //    return;
            //}

            //// 벨리데이션 서비스 초기화
            //this.layComm.InputLayoutItems.Clear();
            //this.layComm.LayoutItems.Clear();

            //// WorkTp
            //this.layComm.WorkTp = '2';

            //// 입력변수
            //this.layComm.InputLayoutItems.Add("code_type", DataType.String);
            //this.layComm.InputLayoutItems.Add("code", DataType.String);
            //this.layComm.SetBindVarValue("code_type", "WING_GUBUN");
            //this.layComm.SetBindVarValue("code", e.DataValue);

            //// 출력변수
            //this.layComm.LayoutItems.Add("wing_gubun_name", DataType.String);
			
            //// 서비스 콜
            //this.layComm.Call();

            //// 서비스에러 체크
            //if (this.layComm.ErrTp == "0" && this.layComm.ErrCode == "")
            //{
            //    if (this.layComm.GetOutValue("wing_gubun_name").ToString() == "")
            //    {
            //        this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : "間違って入力された情報です。");

            //        this.SetMsg(this.mMsg, MsgType.Error);

            //        e.Cancel = true;
            //        return;
            //    }

            //    this.dbxWingGubun.SetDataValue(this.layComm.GetOutValue("wing_gubun_name"));
            //}
            //else
            //{
            //    this.mMsg = (NetInfo.Language == LangMode.Ko ? "잘못 입력된 정보입니다" : "間違って入力された情報です。");

            //    this.SetMsg(this.mMsg, MsgType.Error);

            //    e.Cancel = true;
            //    return;
            //}

            //return;			
		
		}

		private void btnRowCopy_Click(object sender, System.EventArgs e)
		{
			if (this.grdHoCodeList.RowCount <= 0 ||
				this.grdHoCodeList.CurrentRowNumber < 0)
			{
				this.mMsg = NetInfo.Language == LangMode.Ko ? "복사 대상이 선택되지 않았습니다." : Resource.TEXT13;
				this.mCaption = NetInfo.Language == LangMode.Ko ? "복사" : Resource.TEXT14;

				XMessageBox.Show(this.mMsg, this.mCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);

				return ;
			}

			DataRow sourceRow = this.grdHoCodeList.LayoutTable.Rows[this.grdHoCodeList.CurrentRowNumber];

			//this.grdHoCodeList.InsertRow(this.grdHoCodeList.CurrentRowNumber);

			this.CurrMSLayout = this.grdHoCodeList;
			this.btnList.PerformClick(FunctionType.Insert);

			foreach (DataColumn column in sourceRow.Table.Columns)
			{
				if (column.ColumnName != "ho_code" &&
					column.ColumnName != "ho_code_ymd" &&
					column.ColumnName != "start_date"  )
				{
					this.grdHoCodeList.SetItemValue(this.grdHoCodeList.CurrentRowNumber, column.ColumnName, sourceRow[column.ColumnName]);

					// 바인딩된 컨트롤들에도 같은 값을 보여줘야 하기에...
					if (((XEditGridCell)this.grdHoCodeList.CellInfos[column.ColumnName]).BindControl != null )
					{
						((IDataControl)((XEditGridCell)this.grdHoCodeList.CellInfos[column.ColumnName]).BindControl).DataValue = sourceRow[column.ColumnName];
					}
				}
			}
		}

        private void grdHoCodeList_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdHoCodeList.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdHoCodeList.SetBindVarValue("f_jukyong_date", this.dtpJukyongDate.GetDataValue());
            this.grdHoCodeList.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
        }

        private void grdBAS0253_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdBAS0253.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdBAS0253.SetBindVarValue("f_jukyong_date", this.dtpJukyongDate.GetDataValue());
            this.grdBAS0253.SetBindVarValue("f_ho_dong", this.cboHoDong.GetDataValue());
            this.grdBAS0253.SetBindVarValue("f_ho_code", this.grdHoCodeList.GetItemString(this.grdHoCodeList.CurrentRowNumber, "ho_code"));
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private BAS0250U00 parent = null;

            public XSavePeformer(BAS0250U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT 'Y'
                                              FROM DUAL
                                             WHERE EXISTS ( SELECT 'X'
                                                              FROM BAS0250
                                                             WHERE HOSP_CODE  = :f_hosp_code
                                                               AND HO_CODE    = :f_ho_code
                                                               AND HO_DONG    = :f_ho_dong
                                                               AND START_DATE = :f_start_date )";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_ho_dong"].VarValue + "」"+Resource.TEXT15, Resource.TEXT16, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0250
                                               SET UPD_ID = :q_user_id
                                                 , UPD_DATE = SYSDATE
                                                 , END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND HO_CODE   = :f_ho_code
                                               AND HO_DONG   = :f_ho_dong
                                               AND END_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                               AND TO_DATE(:f_start_date, 'YYYY/MM/DD') BETWEEN START_DATE AND END_DATE";
                                Service.ExecuteScalar(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0250
                                                 ( SYS_DATE            , SYS_ID           , UPD_DATE           , UPD_ID           , HOSP_CODE
                                                 , START_DATE          , HO_CODE          , HO_DONG            , HO_GRADE         , HO_TOTAL_BED
                                                 , HO_USED_BED         --, HO_COM_BED       , HO_COM_USED_BED    
                                                 , HO_MAIN_GWA         --, HO_GWA         , HO_LOC             
                                                 , HO_SEX              , HO_SEX_MAIL        , HO_SEX_FEMAIL    , HO_SPECIAL_YN
                                                 , HO_STATUS           , END_DATE         , HO_GUBUN           , HO_CODE_NAME     , HO_SORT
                                                 , REPORT_TOTAL_BED    , DOUBLE_HO_YN    )
                                            VALUES
                                                 ( SYSDATE             , :q_user_id       , SYSDATE            , :q_user_id       , :f_hosp_code
                                                 , :f_start_date       , :f_ho_code       , :f_ho_dong         , :f_ho_grade      , :f_ho_total_bed
                                                 , :f_ho_used_bed      --, :f_ho_com_bed    , :f_ho_com_used_bed 
                                                 , :f_ho_main_gwa      --, :f_ho_gwa      , :f_ho_loc           
                                                 , :f_ho_sex        , :f_ho_sex_mail     , :f_ho_sex_femail , :f_ho_special_yn
                                                 , :f_ho_status        , :f_end_date      , :f_ho_gubun        , :f_ho_code_name  , :f_ho_sort         
                                                 , :f_report_total_bed , :f_double_ho_yn    )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE BAS0250
                                               SET UPD_DATE         = SYSDATE
                                                 , UPD_ID           = :q_user_id
                                                 , HO_GRADE         = :f_ho_grade
                                                 , HO_TOTAL_BED     = :f_ho_total_bed
                                                 , HO_USED_BED      = :f_ho_used_bed
                                                 , HO_MAIN_GWA      = :f_ho_main_gwa
                                                 , HO_SEX           = :f_ho_sex
                                                 , HO_SEX_MAIL      = :f_ho_sex_mail
                                                 , HO_SEX_FEMAIL    = :f_ho_sex_femail
                                                 , HO_SPECIAL_YN    = :f_ho_special_yn
                                                 , HO_STATUS        = :f_ho_status
                                                 , END_DATE         = :f_end_date
                                                 , HO_GUBUN         = :f_ho_gubun
                                                 , HO_CODE_NAME     = :f_ho_code_name    
                                                 , HO_SORT          = :f_ho_sort         
                                                 , REPORT_TOTAL_BED = :f_report_total_bed
                                                 , DOUBLE_HO_YN     = :f_double_ho_yn    
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND HO_CODE          = :f_ho_code
                                               AND HO_DONG          = :f_ho_dong
                                               AND START_DATE       = :f_start_date";

                                break;

                            case DataRowState.Deleted:

//                                cmdText = @"SELECT 'Y'
//                                              FROM DUAL
//                                             WHERE EXISTS ( SELECT 'X'
//                                                              FROM BAS0102
//                                                             WHERE CODE_TYPE = :f_code_type )";

//                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

//                                if (!TypeCheck.IsNull(t_chk))
//                                {
//                                    if (t_chk.ToString() == "Y")
//                                    {
//                                        XMessageBox.Show("「" + item.BindVarList["f_code_type"].VarValue + "」は詳細コードが登録されているため削除出来ません。", "注意", MessageBoxIcon.Warning);
//                                        return false;
//                                    }
//                                }


                                cmdText = @"UPDATE BAS0250
                                               SET UPD_ID = :q_user_id
                                                 , UPD_DATE = SYSDATE
                                                 , END_DATE = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND HO_CODE   = :f_ho_code
                                               AND HO_DONG   = :f_ho_dong
                                               AND END_DATE = TO_DATE(:f_start_date, 'YYYY/MM/DD') - 1";
                                Service.ExecuteScalar(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM BAS0250
                                             WHERE HOSP_CODE        = :f_hosp_code
                                               AND HO_CODE          = :f_ho_code
                                               AND HO_DONG          = :f_ho_dong
                                               AND START_DATE       = :f_start_date";

                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                if (item.BindVarList["f_ho_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_bed_no"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_from_bed_date"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT19, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"SELECT 'Y'
                                                FROM DUAL
                                               WHERE EXISTS ( SELECT 'X'
                                                                FROM BAS0253
                                                               WHERE HOSP_CODE     = :f_hosp_code
                                                                 AND HO_DONG       = :f_ho_dong 
                                                                 AND HO_CODE       = :f_ho_code
                                                                 AND BED_NO        = :f_bed_no
                                                                 AND FROM_BED_DATE = TO_DATE(:f_from_bed_date, 'YYYY/MM/DD'))";

                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (!TypeCheck.IsNull(t_chk))
                                {
                                    if (t_chk.ToString() == "Y")
                                    {
                                        XMessageBox.Show("「" + item.BindVarList["f_bed_no"].VarValue + "」" + Resource.TEXT20, Resource.TEXT16, MessageBoxIcon.Warning);
                                        return false;
                                    }
                                }

                                cmdText = @"UPDATE BAS0253
                                             SET UPD_ID      = :q_user_id
                                               , UPD_DATE    = SYSDATE
                                               , TO_BED_DATE = TO_DATE(:f_from_bed_date, 'YYYY/MM/DD') - 1
                                           WHERE HOSP_CODE   = :f_hosp_code
                                             AND HO_DONG     = :f_ho_dong                                             
                                             AND HO_CODE     = :f_ho_code
                                             AND BED_NO      = :f_bed_no
                                             AND TO_BED_DATE    = TO_DATE('9998/12/31', 'YYYY/MM/DD')
                                             AND TO_DATE(:f_from_bed_date, 'YYYY/MM/DD') BETWEEN FROM_BED_DATE AND TO_BED_DATE ";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"INSERT INTO BAS0253
                                               ( SYS_DATE         , SYS_ID          , UPD_DATE         , UPD_ID     , HOSP_CODE 
                                               , HO_CODE          , BED_NO          , FROM_BED_DATE
                                               , TO_BED_DATE      , BED_STATUS      , BED_NO_TEL       , HO_DONG      )
                                          VALUES
                                               ( SYSDATE          , :q_user_id      , SYSDATE          , :q_user_id  , :f_hosp_code
                                               , :f_ho_code       , :f_bed_no       , :f_from_bed_date
                                               , :f_to_bed_date   , :f_bed_status   , :f_bed_no_tel    , :f_ho_dong)";

                                break;

                            case DataRowState.Modified:

                                if (item.BindVarList["f_ho_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_bed_no"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_from_bed_date"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT19, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }

                                cmdText = @"UPDATE BAS0253
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , TO_BED_DATE   = :f_to_bed_date
                                                 , BED_STATUS    = :f_bed_status
                                                 , BED_NO_TEL    = :f_bed_no_tel
                                             WHERE HOSP_CODE     = :f_hosp_code
                                               AND HO_DONG       = :f_ho_dong
                                               AND HO_CODE       = :f_ho_code
                                               AND BED_NO        = :f_bed_no
                                               AND FROM_BED_DATE = :f_from_bed_date ";

                                break;

                            case DataRowState.Deleted:

                                if (item.BindVarList["f_ho_code"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_bed_no"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                else if (item.BindVarList["f_from_bed_date"].VarValue == "")
                                {
                                    XMessageBox.Show(Resource.TEXT17, Resource.TEXT18, MessageBoxIcon.Error);
                                    return false;
                                }
                                cmdText = @"UPDATE BAS0253
                                               SET UPD_ID        = :q_user_id
                                                 , UPD_DATE      = SYSDATE
                                                 , TO_BED_DATE = TO_DATE('9998/12/31', 'YYYY/MM/DD') 
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG       = :f_ho_dong
                                               AND HO_CODE     = :f_ho_code
                                               AND BED_NO      = :f_bed_no
                                               AND TO_BED_DATE = TO_DATE(:f_from_bed_date, 'YYYY/MM/DD') -1 ";

                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

                                cmdText = @"DELETE FROM BAS0253
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND HO_DONG       = :f_ho_dong
                                               AND HO_CODE       = :f_ho_code
                                               AND BED_NO        = :f_bed_no
                                               AND FROM_BED_DATE = :f_from_bed_date   ";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void dbxHoGradeName_MouseHover(object sender, EventArgs e)
        {
            xToolTip1.SetToolTip(dbxHoGradeName, dbxHoGradeName.GetDataValue());
        }

        private void grdHoCodeList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.DataRow["end_yn"].ToString() == "Y")
            {
                e.BackColor = Color.LightGray;
                e.ForeColor = Color.Red;
            }
        }

        private void cboHoDong_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // 정상종료후 베트 조회
            this.grdHoCodeList.QueryLayout(false);

            if (this.grdHoCodeList.RowCount <= 0)
            {
                this.grdBAS0253.Reset();
            }

        }
	}
}

