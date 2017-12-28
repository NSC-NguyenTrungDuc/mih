#region 사용 NameSpace 지정
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data;
using IHIS.Framework;
#endregion

namespace IHIS.NURI
{
	/// <summary>
	/// NUR1035U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1035U00 : IHIS.Framework.XScreen
    {

        int paListRownum = 0;

        #region [자동 생성 코드]
        
        #region 컨트롤 변수
        private IHIS.Framework.XMstGrid grdNUR1035;
		private IHIS.Framework.XEditGrid grdNUR1036;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XPanel pnlCenter;
        private IHIS.Framework.XPanel pnlRight;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XPatientBox paBox;
        private XDatePicker dtpDate;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private MultiLayout layState;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XDisplayBox dbxJubsujaName;
        private XTextBox txtJubsuja;
        private XLabel lblNurseId;
        private XPanel pnlSession;
        private XLabel xLabel2;
        private XLabel xLabel6;
        private XCheckBox cbxA;
        private XCheckBox cbxB;
        private XCheckBox cbxC;
        private XCheckBox cbxD;
        private XPanel pnlLeft;
        private XEditGrid grdPalist;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell41;
        private XEditGridCell xEditGridCell66;
        private XBuseoCombo cboHo_dong;
        private XLabel lblHo_dong;
        private XButton btnNextPatient;
        private SingleLayout layModifyLimit;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private XButtonList btnList2;
        private MultiLayout layTime;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private XEditGridCell xEditGridCell24;
        private XTextBox txtFkinp1001;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR1035U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();
		}
		#endregion

		#region 소멸자
		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		#endregion

		#region 디자인 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1035U00));
            this.grdNUR1035 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.grdNUR1036 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.cboHo_dong = new IHIS.Framework.XBuseoCombo();
            this.lblHo_dong = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.pnlSession = new IHIS.Framework.XPanel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.cbxA = new IHIS.Framework.XCheckBox();
            this.cbxB = new IHIS.Framework.XCheckBox();
            this.cbxC = new IHIS.Framework.XCheckBox();
            this.cbxD = new IHIS.Framework.XCheckBox();
            this.dbxJubsujaName = new IHIS.Framework.XDisplayBox();
            this.txtJubsuja = new IHIS.Framework.XTextBox();
            this.lblNurseId = new IHIS.Framework.XLabel();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.dtpDate = new IHIS.Framework.XDatePicker();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnList2 = new IHIS.Framework.XButtonList();
            this.btnNextPatient = new IHIS.Framework.XButton();
            this.pnlCenter = new IHIS.Framework.XPanel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.layState = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.grdPalist = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell41 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell66 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.layModifyLimit = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.layTime = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1035)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1036)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).BeginInit();
            this.pnlSession.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList2)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layState)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTime)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "앞으로.gif");
            // 
            // grdNUR1035
            // 
            this.grdNUR1035.ApplyPaintEventToAllColumn = true;
            this.grdNUR1035.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell24,
            this.xEditGridCell15,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27});
            this.grdNUR1035.ColPerLine = 4;
            this.grdNUR1035.Cols = 5;
            this.grdNUR1035.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR1035.FixedCols = 1;
            this.grdNUR1035.FixedRows = 1;
            this.grdNUR1035.HeaderHeights.Add(21);
            this.grdNUR1035.Location = new System.Drawing.Point(0, 0);
            this.grdNUR1035.Name = "grdNUR1035";
            this.grdNUR1035.QuerySQL = resources.GetString("grdNUR1035.QuerySQL");
            this.grdNUR1035.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR1035.RowHeaderVisible = true;
            this.grdNUR1035.Rows = 2;
            this.grdNUR1035.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR1035.Size = new System.Drawing.Size(310, 499);
            this.grdNUR1035.TabIndex = 2;
            this.grdNUR1035.UseDefaultTransaction = false;
            this.grdNUR1035.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR1035_GridColumnChanged);
            this.grdNUR1035.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdNUR1035_RowFocusChanging);
            this.grdNUR1035.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR1035_GridCellPainting);
            this.grdNUR1035.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1035_QueryStarting);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "fkinp1001";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "fkinp1001";
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "pknur1035";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.HeaderText = "pknur1035";
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "method_code";
            this.xEditGridCell1.CellWidth = 105;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell1.EnableSort = true;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.HeaderText = "方法";
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell1.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell1.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\nWHERE HOSP_CODE = FN_ADM_LOAD_HOSP" +
                "_CODE AND CODE_TYPE = \'METHOD_CODE\'\r\nORDER BY SORT_KEY";
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.CellName = "start_date";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell2.CellWidth = 76;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell2.EnableSort = true;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell2.HeaderText = "開始日";
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "end_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.HeaderText = "終了日";
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "input_id";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "入力ID";
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "input_name";
            this.xEditGridCell26.Col = 4;
            this.xEditGridCell26.HeaderText = "入力者";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.CellName = "check_yn";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.HeaderText = "check_yn";
            this.xEditGridCell27.IsUpdatable = false;
            this.xEditGridCell27.IsUpdCol = false;
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            // 
            // grdNUR1036
            // 
            this.grdNUR1036.ApplyPaintEventToAllColumn = true;
            this.grdNUR1036.CallerID = '2';
            this.grdNUR1036.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell14,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell16,
            this.xEditGridCell5,
            this.xEditGridCell7,
            this.xEditGridCell11,
            this.xEditGridCell10,
            this.xEditGridCell17,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell8,
            this.xEditGridCell13});
            this.grdNUR1036.ColPerLine = 9;
            this.grdNUR1036.Cols = 10;
            this.grdNUR1036.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR1036.FixedCols = 1;
            this.grdNUR1036.FixedRows = 1;
            this.grdNUR1036.HeaderHeights.Add(31);
            this.grdNUR1036.Location = new System.Drawing.Point(0, 0);
            this.grdNUR1036.MasterLayout = this.grdNUR1035;
            this.grdNUR1036.Name = "grdNUR1036";
            this.grdNUR1036.QuerySQL = resources.GetString("grdNUR1036.QuerySQL");
            this.grdNUR1036.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR1036.RowHeaderVisible = true;
            this.grdNUR1036.Rows = 2;
            this.grdNUR1036.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR1036.Size = new System.Drawing.Size(797, 499);
            this.grdNUR1036.TabIndex = 3;
            this.grdNUR1036.UseDefaultTransaction = false;
            this.grdNUR1036.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdNUR1036_MouseDown);
            this.grdNUR1036.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdNUR1036_MouseClick);
            this.grdNUR1036.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR1036_QueryStarting);
            this.grdNUR1036.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR1036_GridCellPainting);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "fknur1035";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.HeaderText = "key";
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.CellName = "check_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.CellWidth = 84;
            this.xEditGridCell3.Col = 1;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.HeaderText = "日付";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell3.SuppressRepeating = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "check_time";
            this.xEditGridCell4.CellWidth = 48;
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell4.HeaderText = "時間";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "danger_act";
            this.xEditGridCell16.CellWidth = 58;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell16.HeaderText = "危険行動";
            this.xEditGridCell16.IsReadOnly = true;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell5.CellName = "changed_skin";
            this.xEditGridCell5.CellWidth = 73;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("MS UI Gothic", 10F);
            this.xEditGridCell5.HeaderText = "皮膚の変化";
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell7.CellName = "edema";
            this.xEditGridCell7.CellWidth = 50;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.HeaderText = "浮腫";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell11.CellName = "numbness";
            this.xEditGridCell11.CellWidth = 62;
            this.xEditGridCell11.Col = 5;
            this.xEditGridCell11.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell11.HeaderText = "しびれ";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell10.CellName = "scratch";
            this.xEditGridCell10.CellWidth = 61;
            this.xEditGridCell10.Col = 6;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell10.HeaderText = "擦過傷";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "tube_trouble";
            this.xEditGridCell17.CellWidth = 71;
            this.xEditGridCell17.Col = 7;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell17.HeaderText = "チューブ類\r\nトラブル";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell9.CellName = "petechia";
            this.xEditGridCell9.CellWidth = 58;
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.HeaderText = "点状出血";
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "input_id";
            this.xEditGridCell12.CellWidth = 61;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.HeaderText = "input_id";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "input_name";
            this.xEditGridCell8.CellWidth = 95;
            this.xEditGridCell8.Col = 8;
            this.xEditGridCell8.HeaderText = "看護師";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 1000;
            this.xEditGridCell13.CellName = "remark";
            this.xEditGridCell13.CellWidth = 197;
            this.xEditGridCell13.Col = 9;
            this.xEditGridCell13.DisplayMemoText = true;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell13.HeaderText = "備考欄";
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnList.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Location = new System.Drawing.Point(971, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(406, 32);
            this.btnList.TabIndex = 5;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtFkinp1001);
            this.pnlTop.Controls.Add(this.cboHo_dong);
            this.pnlTop.Controls.Add(this.lblHo_dong);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.pnlSession);
            this.pnlTop.Controls.Add(this.dbxJubsujaName);
            this.pnlTop.Controls.Add(this.txtJubsuja);
            this.pnlTop.Controls.Add(this.lblNurseId);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Controls.Add(this.dtpDate);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1379, 57);
            this.pnlTop.TabIndex = 7;
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(865, 6);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(84, 20);
            this.txtFkinp1001.TabIndex = 33;
            this.txtFkinp1001.Visible = false;
            // 
            // cboHo_dong
            // 
            this.cboHo_dong.BuseoGubun = IHIS.Framework.BuseoType.Inp;
            this.cboHo_dong.Location = new System.Drawing.Point(66, 4);
            this.cboHo_dong.MaxDropDownItems = 40;
            this.cboHo_dong.Name = "cboHo_dong";
            this.cboHo_dong.Size = new System.Drawing.Size(74, 21);
            this.cboHo_dong.TabIndex = 31;
            this.cboHo_dong.SelectedIndexChanged += new System.EventHandler(this.cboHo_dong_SelectedIndexChanged);
            // 
            // lblHo_dong
            // 
            this.lblHo_dong.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblHo_dong.EdgeRounding = false;
            this.lblHo_dong.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHo_dong.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblHo_dong.Location = new System.Drawing.Point(3, 4);
            this.lblHo_dong.Name = "lblHo_dong";
            this.lblHo_dong.Size = new System.Drawing.Size(63, 21);
            this.lblHo_dong.TabIndex = 32;
            this.lblHo_dong.Text = "病棟";
            this.lblHo_dong.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Location = new System.Drawing.Point(142, 4);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(42, 21);
            this.xLabel2.TabIndex = 21;
            this.xLabel2.Text = "日付";
            this.xLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSession
            // 
            this.pnlSession.Controls.Add(this.xLabel6);
            this.pnlSession.Controls.Add(this.cbxA);
            this.pnlSession.Controls.Add(this.cbxB);
            this.pnlSession.Controls.Add(this.cbxC);
            this.pnlSession.Controls.Add(this.cbxD);
            this.pnlSession.Location = new System.Drawing.Point(2, 28);
            this.pnlSession.Name = "pnlSession";
            this.pnlSession.Size = new System.Drawing.Size(236, 22);
            this.pnlSession.TabIndex = 23;
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xLabel6.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel6.Location = new System.Drawing.Point(1, 1);
            this.xLabel6.Name = "xLabel6";
            this.xLabel6.Size = new System.Drawing.Size(63, 21);
            this.xLabel6.TabIndex = 20;
            this.xLabel6.Text = "チーム";
            this.xLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxA
            // 
            this.cbxA.AutoSize = true;
            this.cbxA.Location = new System.Drawing.Point(71, 3);
            this.cbxA.Name = "cbxA";
            this.cbxA.Size = new System.Drawing.Size(31, 17);
            this.cbxA.TabIndex = 14;
            this.cbxA.Text = "A";
            this.cbxA.UseVisualStyleBackColor = false;
            this.cbxA.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxB
            // 
            this.cbxB.AutoSize = true;
            this.cbxB.Location = new System.Drawing.Point(113, 3);
            this.cbxB.Name = "cbxB";
            this.cbxB.Size = new System.Drawing.Size(31, 17);
            this.cbxB.TabIndex = 15;
            this.cbxB.Text = "B";
            this.cbxB.UseVisualStyleBackColor = false;
            this.cbxB.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxC
            // 
            this.cbxC.AutoSize = true;
            this.cbxC.Location = new System.Drawing.Point(155, 3);
            this.cbxC.Name = "cbxC";
            this.cbxC.Size = new System.Drawing.Size(32, 17);
            this.cbxC.TabIndex = 16;
            this.cbxC.Text = "C";
            this.cbxC.UseVisualStyleBackColor = false;
            this.cbxC.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // cbxD
            // 
            this.cbxD.AutoSize = true;
            this.cbxD.Location = new System.Drawing.Point(198, 3);
            this.cbxD.Name = "cbxD";
            this.cbxD.Size = new System.Drawing.Size(31, 17);
            this.cbxD.TabIndex = 17;
            this.cbxD.Text = "D";
            this.cbxD.UseVisualStyleBackColor = false;
            this.cbxD.CheckedChanged += new System.EventHandler(this.cbxTeam_CheckedChanged);
            // 
            // dbxJubsujaName
            // 
            this.dbxJubsujaName.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.dbxJubsujaName.Location = new System.Drawing.Point(1259, 30);
            this.dbxJubsujaName.Name = "dbxJubsujaName";
            this.dbxJubsujaName.Size = new System.Drawing.Size(94, 20);
            this.dbxJubsujaName.TabIndex = 30;
            // 
            // txtJubsuja
            // 
            this.txtJubsuja.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtJubsuja.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtJubsuja.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.txtJubsuja.Location = new System.Drawing.Point(1174, 30);
            this.txtJubsuja.MaxLength = 6;
            this.txtJubsuja.Name = "txtJubsuja";
            this.txtJubsuja.Size = new System.Drawing.Size(85, 20);
            this.txtJubsuja.TabIndex = 27;
            this.txtJubsuja.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtJubsuja_DataValidating);
            // 
            // lblNurseId
            // 
            this.lblNurseId.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.lblNurseId.EdgeRounding = false;
            this.lblNurseId.Font = new System.Drawing.Font("ＭＳ Ｐゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblNurseId.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.lblNurseId.Location = new System.Drawing.Point(1111, 30);
            this.lblNurseId.Name = "lblNurseId";
            this.lblNurseId.Size = new System.Drawing.Size(63, 20);
            this.lblNurseId.TabIndex = 29;
            this.lblNurseId.Text = "看護 I D";
            this.lblNurseId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // paBox
            // 
            this.paBox.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.paBox.Location = new System.Drawing.Point(273, 26);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(807, 30);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(184, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(93, 20);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpDate_DataValidating);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList2);
            this.pnlBottom.Controls.Add(this.btnNextPatient);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 556);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1379, 34);
            this.pnlBottom.TabIndex = 8;
            // 
            // btnList2
            // 
            this.btnList2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.btnList2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList2.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList2.Location = new System.Drawing.Point(338, -1);
            this.btnList2.Name = "btnList2";
            this.btnList2.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList2.Size = new System.Drawing.Size(244, 34);
            this.btnList2.TabIndex = 6;
            this.btnList2.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList2_ButtonClick);
            // 
            // btnNextPatient
            // 
            this.btnNextPatient.ImageIndex = 0;
            this.btnNextPatient.ImageList = this.ImageList;
            this.btnNextPatient.Location = new System.Drawing.Point(846, 1);
            this.btnNextPatient.Name = "btnNextPatient";
            this.btnNextPatient.Size = new System.Drawing.Size(124, 30);
            this.btnNextPatient.TabIndex = 1;
            this.btnNextPatient.Text = "次の患者さんへ";
            this.btnNextPatient.Visible = false;
            this.btnNextPatient.Click += new System.EventHandler(this.btnNextPatient_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.grdNUR1035);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(272, 57);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(310, 499);
            this.pnlCenter.TabIndex = 9;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.grdNUR1036);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(582, 57);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(797, 499);
            this.pnlRight.TabIndex = 10;
            // 
            // layState
            // 
            this.layState.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layState.QuerySQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'CHECK_STATE\'\r\n ORDER BY SORT_KEY";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_name";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.grdPalist);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 57);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(272, 499);
            this.pnlLeft.TabIndex = 11;
            // 
            // grdPalist
            // 
            this.grdPalist.ApplyPaintEventToAllColumn = true;
            this.grdPalist.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell19,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell22,
            this.xEditGridCell23,
            this.xEditGridCell41,
            this.xEditGridCell66,
            this.xEditGridCell28});
            this.grdPalist.ColPerLine = 7;
            this.grdPalist.Cols = 7;
            this.grdPalist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPalist.FixedRows = 1;
            this.grdPalist.HeaderHeights.Add(23);
            this.grdPalist.Location = new System.Drawing.Point(0, 0);
            this.grdPalist.Name = "grdPalist";
            this.grdPalist.QuerySQL = resources.GetString("grdPalist.QuerySQL");
            this.grdPalist.ReadOnly = true;
            this.grdPalist.Rows = 2;
            this.grdPalist.Size = new System.Drawing.Size(272, 499);
            this.grdPalist.TabIndex = 0;
            this.grdPalist.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPalist_QueryEnd);
            this.grdPalist.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPalist_QueryStarting);
            this.grdPalist.Click += new System.EventHandler(this.grdPalist_Click);
            this.grdPalist.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdPalist_GridCellPainting);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.ApplyPaintingEvent = true;
            this.xEditGridCell18.CellLen = 4;
            this.xEditGridCell18.CellName = "ho_code";
            this.xEditGridCell18.CellWidth = 40;
            this.xEditGridCell18.HeaderText = "病室";
            this.xEditGridCell18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellLen = 9;
            this.xEditGridCell19.CellName = "bunho";
            this.xEditGridCell19.CellWidth = 75;
            this.xEditGridCell19.Col = 1;
            this.xEditGridCell19.HeaderText = "患者番号";
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellLen = 30;
            this.xEditGridCell20.CellName = "su_name";
            this.xEditGridCell20.CellWidth = 100;
            this.xEditGridCell20.Col = 2;
            this.xEditGridCell20.HeaderText = "患者氏名";
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "pkinp1001";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellLen = 20;
            this.xEditGridCell22.CellName = "age_sex";
            this.xEditGridCell22.CellWidth = 40;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.HeaderText = "年/性";
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "ipwon_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.CellWidth = 90;
            this.xEditGridCell23.Col = 4;
            this.xEditGridCell23.HeaderText = "入院日付";
            this.xEditGridCell23.IsJapanYearType = true;
            // 
            // xEditGridCell41
            // 
            this.xEditGridCell41.CellLen = 30;
            this.xEditGridCell41.CellName = "doctor_name";
            this.xEditGridCell41.CellWidth = 100;
            this.xEditGridCell41.Col = 5;
            this.xEditGridCell41.HeaderText = "主治医";
            // 
            // xEditGridCell66
            // 
            this.xEditGridCell66.CellName = "cycle_order_group";
            this.xEditGridCell66.Col = -1;
            this.xEditGridCell66.IsVisible = false;
            this.xEditGridCell66.Row = -1;
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.CellName = "check_yn";
            this.xEditGridCell28.Col = 6;
            this.xEditGridCell28.HeaderText = "check_yn";
            // 
            // layModifyLimit
            // 
            this.layModifyLimit.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2});
            this.layModifyLimit.QuerySQL = "SELECT A.CODE_NAME LIMIT_YN\r\n     , A.SORT_KEY DAYS \r\n  FROM NUR0102 A\r\n WHERE A." +
                "HOSP_CODE = FN_ADM_LOAD_HOSP_CODE()\r\n   AND A.CODE_TYPE = \'NUR1035_MODIFY_LIMIT\'" +
                "";
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "limit_yn";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "limit";
            // 
            // layTime
            // 
            this.layTime.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4});
            this.layTime.QuerySQL = "SELECT CODE\r\n     , CODE_NAME \r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HO" +
                "SP_CODE()\r\n   AND CODE_TYPE = \'CHECK_TIME\'\r\n ORDER BY SORT_KEY";
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "code";
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "code_name";
            // 
            // NUR1035U00
            // 
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR1035U00";
            this.Size = new System.Drawing.Size(1379, 590);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR1035U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1035)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR1036)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboHo_dong)).EndInit();
            this.pnlSession.ResumeLayout(false);
            this.pnlSession.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList2)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layState)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPalist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTime)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        #endregion

        #region [APL 초기설정 코드]
        private string mHospCode = "";
        protected override void OnLoad(EventArgs e)
		{
            mHospCode = EnvironInfo.HospCode;
			base.OnLoad (e);

            // SaveLayout 설정
            this.SaveLayoutList.Add(this.grdNUR1035);
            this.SaveLayoutList.Add(this.grdNUR1036);

            // 그리드 SavePerformer 설정
            this.grdNUR1035.SavePerformer = new XSavePerformer(this);
            this.grdNUR1036.SavePerformer = this.grdNUR1035.SavePerformer;

            // 마스터-디테일 관계 설정
            this.grdNUR1036.SetRelationKey("fknur1035", "pknur1035");
            this.grdNUR1036.SetRelationTable("NUR1036");

            Init_GridComboItem();

            //txtJubsuja.Text = UserInfo.UserID;
            //txtJubsuja.AcceptData();

            this.CurrMSLayout = this.grdNUR1035;

            grdNUR1035.QueryLayout(false);

		}

        private void Init_GridComboItem()
        {
            //시간 테이블 쿼리
            layTime.QueryLayout(false);
            if (layTime.RowCount > 0)
            {
                grdNUR1036.SetComboItems("check_time", layTime.LayoutTable, "code_name", "code");
            }
            
            //상태 테이블 쿼리 (+,-) 등
            layState.QueryLayout(false);
            if (layState.RowCount > 0)
            {
                grdNUR1036.SetComboItems("danger_act", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("changed_skin", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("edema", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("numbness", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("scratch", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("tube_trouble", layState.LayoutTable, "code_name", "code");
                grdNUR1036.SetComboItems("petechia", layState.LayoutTable, "code_name", "code");
            }
        }

		#endregion

       

        #region [메세지 처리 코드]

        private void ShowMessage(string separation)
        {
            string msg = string.Empty;
            string cpt = string.Empty;

            switch (separation)
            {
                case "MasterInsert":
                    msg = "新たに入力された行があります。先に保存をしてください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailInsert":
                    msg = "経過を入力するには\n先に方法を入力してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "MasterDeleteGrid":
                    msg = "経過記録を持っています。\nこの項目を削除するには先に経過記録を削除及び保存してください。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    msg = "保存しました。";
                    cpt = "お知らせ";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "InsertUserError":
                    msg = "看護師名を確認してください";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Warning);
                    break;

                case "ServiceError":
                    msg = String.Format("処理中にエラーが発生しました。\n\nエラー内容：{0}", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                case "MasterInsertError":
                    msg = "保存できませんでした。\n入力した内容を確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                case "DetailInsertError":
                    msg = "保存できませんでした。\n日付または時間の入力を確認してください。";
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                case "CanNotModify":
                    msg = "修正可能な期間が過ぎました。修正できません。";
                    cpt = "確認";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Warning);
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region [조회/입력/삭제/초기화 처리 코드]

        #region 조회/입력/삭제 버튼 처리


        private void btnList2_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    
                //입력 전 상태 확인
                    if (this.dbxJubsujaName.Text == "")
                    {
                        ShowMessage("InsertUserError");
                        txtJubsuja.Focus();
                        return;
                    }
                    if (grdNUR1035.GetItemString(grdNUR1035.CurrentRowNumber, "end_date") != "")
                    {
                        if (grdNUR1035.GetItemDateTime(grdNUR1035.CurrentRowNumber, "end_date") < grdNUR1036.GetItemDateTime(0, "check_date"))
                        {
                            XMessageBox.Show("既に完了されましたので追加できません。");
                            return;
                        }
                    }

                    //if (this.grdNUR1035.RowCount > 0)
                    //{
                    //    for (int i = 0; i < this.grdNUR1035.RowCount; i++)
                    //    {
                    //        // 마스터 그리드 2행 이상 입력 방지
                    //        if (this.grdNUR1035.LayoutTable.Rows[i].RowState == DataRowState.Added)
                    //        {
                    //            ShowMessage("MasterInsert");
                    //            return;
                    //        }
                    //    }
                    //}

                    grdNUR1035.InsertRow();
                    string cmd = @"SELECT NUR1035_SEQ.NEXTVAL FROM DUAL";
                    
                    object ret = Service.ExecuteScalar(cmd);
                    if (ret != null)
                    {
                        grdNUR1035.SetItemValue(grdNUR1035.CurrentRowNumber, "pknur1035", ret.ToString());
                    }
                    else
                    {
                        ShowMessage("ServiceError");
                    }

                    if (txtFkinp1001.Text == "")
                    {
                        GetFkinp1001();
                    }
                    grdNUR1035.SetItemValue(grdNUR1035.CurrentRowNumber, "fkinp1001", txtFkinp1001.Text);
                    grdNUR1035.SetItemValue(grdNUR1035.CurrentRowNumber, "start_date", dtpDate.GetDataValue());
                    grdNUR1035.SetItemValue(grdNUR1035.CurrentRowNumber, "input_id", txtJubsuja.Text);
                    grdNUR1035.SetItemValue(grdNUR1035.CurrentRowNumber, "input_name", dbxJubsujaName.Text);

                    grdNUR1035.Sort("start_date desc");
										
					break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    if (this.CurrMSLayout == grdNUR1035)
                    {
                        // 디테일 그리드 데이타 존재 여부 확인
                        if (this.grdNUR1036.RowCount > 0)
                        {
                            ShowMessage("MasterDeleteGrid");
                            e.IsBaseCall = false;
                            return;
                        }
                        // 디테일 DB 데이타 존재 여부 확인
                        else
                        {
                            string cmdText = string.Empty;
                            object retVal = null;
                            BindVarCollection bindVals = new BindVarCollection();

                            cmdText = @"SELECT 'Y'
                                          FROM DUAL
                                         WHERE EXISTS (SELECT 'X'
                                                         FROM NUR1036
                                                        WHERE HOSP_CODE = :f_hosp_code
                                                          AND FKNUR1035 = :f_pknur1035)";

                            bindVals.Add("f_hosp_code", this.mHospCode);
                            bindVals.Add("f_pknur1035", grdNUR1035.GetItemValue(grdNUR1035.CurrentRowNumber, "pknur1035").ToString());

                            retVal = Service.ExecuteScalar(cmdText, bindVals);

                            // DB 처리 성공
                            if (Service.ErrCode == 0)
                            {
                                if (retVal != null && retVal.ToString().Equals("Y"))
                                {
                                    ShowMessage("MasterDeleteGrid");
                                    e.IsBaseCall = false;
                                }
                            }
                            // DB 처리 실패
                            else
                            {
                                ShowMessage("ServiceError");
                                e.IsBaseCall = false;
                            }
                        }
                        grdNUR1035.DeleteRow();
                    }

                    break;


                case FunctionType.Update:
                    e.IsBaseCall = false;
                    btnList.PerformClick(FunctionType.Update);
                    break;

            }

        }


        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch (e.Func)
			{
                case FunctionType.Query:
                    this.grdPalist.QueryLayout(false);
                    this.grdNUR1035.QueryLayout(false);
                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    
                // 마스터 그리드 데이타 존재 여부 확인
                    if (this.grdNUR1035.RowCount == 0)
                    {
                        btnList2.PerformClick(FunctionType.Insert);
                        return;
                    }
                    else
                    {
                        //입력 전 상태 확인
                        if (this.dbxJubsujaName.Text == "")
                        {
                            ShowMessage("InsertUserError");
                            txtJubsuja.Focus();
                            return;
                        }
                        if (grdNUR1035.GetItemString(grdNUR1035.CurrentRowNumber, "end_date") != "")
                        {
                            if (grdNUR1035.GetItemDateTime(grdNUR1035.CurrentRowNumber, "end_date") < DateTime.Parse(dtpDate.GetDataValue()))
                            {
                                XMessageBox.Show("既に完了されましたので追加できません。");
                                return;
                            }
                        }

                        grdNUR1036.InsertRow(0);

                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "fknur1035", grdNUR1035.GetItemString(grdNUR1035.CurrentRowNumber, "pknur1035"));

                        if (grdNUR1036.RowCount > 1)
                            grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "check_date", grdNUR1036.GetItemDateTime(grdNUR1036.CurrentRowNumber - 1, "check_date").AddDays(1));
                        else
                            grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "check_date", dtpDate.GetDataValue());

                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "check_time", "01");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "danger_act", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "changed_skin", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "edema", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "numbness", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "scratch", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "tube_trouble", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "petechia", "0");
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "input_id", txtJubsuja.Text);
                        grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, "input_name", dbxJubsujaName.Text);
                        
                        grdNUR1036.Sort("check_date desc, check_time desc");

                    }
					break;

                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    grdNUR1036.DeleteRow();

                    break;
				
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    if (txtJubsuja == null)
                    {
                        ShowMessage("InsertUserError");
                        return;
                    }

                    if (!ValidationNUR1035())
                    {
                        ShowMessage("MasterInsertError");
                        return;
                    }

                    if (!ValidationNUR1036())
                    {
                        ShowMessage("DetailInsertError");
                        return;
                    }

                    try
                    {
                        Service.BeginTransaction();
                        if (grdNUR1035.SaveLayout())
                        {
                            if (grdNUR1036.SaveLayout())
                            {
                                ShowMessage("SaverSuccess");
                            }
                            else
                            {
                                ShowMessage("DetailInsertError");
                                throw new Exception();
                            }
                        }
                        else
                        {
                            ShowMessage("MasterInsertError");
                            throw new Exception();
                        }
                        Service.CommitTransaction();
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                    }

                    break;

                case FunctionType.Close:
                    if (CheckGrdChanged(grdNUR1036) > 0 || (CheckGrdChanged(grdNUR1035) > 0))
                    {
                        if (XMessageBox.Show("保存されてないデータがあります。\n保存しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            btnList.PerformClick(FunctionType.Update);
                        }                        
                    }
                    break;

                default:
					break;
			}
        }
        #endregion

        private bool ValidationNUR1035()
        {
            for (int i = 0; i < grdNUR1035.RowCount; i++)
            {
                if (grdNUR1035.GetItemString(i, "method_code") == ""
                  ||grdNUR1035.GetItemString(i, "start_date") == "")
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidationNUR1036()
        {
            for (int i = 0; i < grdNUR1036.RowCount; i++)
            {
                if (grdNUR1036.GetItemString(i, "fknur1035") == ""
                  || grdNUR1036.GetItemString(i, "input_id") == "")
                {
                    return false;
                }
            }
            return true;
        }

        private int CheckGrdChanged(XEditGrid grd)
        {
            int cnt = 0;

            //if (grdNUR1036.DeletedRowCount > 0)
            //{
            //    cnt = grdNUR1036.DeletedRowCount;
            //}

            for (int i = 0; i < grd.RowCount; i++)
            {
                if (grd.GetRowState(i) == DataRowState.Added
                    || grd.GetRowState(i) == DataRowState.Modified
                    || grd.GetRowState(i) == DataRowState.Deleted)
                {
                    cnt++;
                }
            }

            return cnt;
        }
        
		#endregion

        #region [코드유형에 따른 마스터 그리드 설정 코드]

        /// <summary>
        /// 코드유형 콤보박스 아이템 선택 시, 해당하는 데이타를 마스터 그리드에 설정한다. 
        /// </summary>
        private void cboCdty_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.grdNUR1035.QueryLayout(false);
        }

        #endregion

        #region [마스터/디테일 그리드 바인드변수 설정 코드]

        #region 마스터 바인드변수 설정
        private void grdNUR1035_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1035.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR1035.SetBindVarValue("f_date", dtpDate.GetDataValue());
            //this.grdNUR1035.SetBindVarValue("f_bunho", paBox.BunHo);
            this.grdNUR1035.SetBindVarValue("f_fkinp1001", txtFkinp1001.Text);
        }
        #endregion

        #region 디테일 바인드변수 설정
        private void grdNUR1036_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR1036.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdNUR1036.SetBindVarValue("f_fknur1035", grdNUR1035.GetItemValue(grdNUR1035.CurrentRowNumber, "pknur1035").ToString());
        }
        #endregion

        #endregion
                
        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR1035U00 parent = null;

            public XSavePerformer(NUR1035U00 parent)
            {
                this.parent = parent;
            }
            /*
            private bool MasterInsertable()
            {

                return true;
                
                BindVarCollection bindVar = new BindVarCollection();

                string cmd = @"SELECT 'Y'
                                 FROM DUAL
                                WHERE EXISTS (SELECT 'X'
                                                FROM NUR1035
                                               WHERE HOSP_CODE = :f_hosp_code 
                                                 AND BUNHO  = :f_bunho
                                                 AND :f_start_date BETWEEN START_DATE AND NVL(END_DATE, '9998/12/31')
                                                 AND METHOD_CODE = :f_method_code)";

                bindVar.Add("f_hosp_code", parent.mHospCode);
                bindVar.Add("f_bunho", parent.paBox.BunHo);
                bindVar.Add("f_start_date", parent.grdNUR1035.GetItemString(parent.grdNUR1035.CurrentRowNumber, "start_date"));
                bindVar.Add("f_method_code", parent.grdNUR1035.GetItemString(parent.grdNUR1035.CurrentRowNumber, "method_code"));

                object ret = Service.ExecuteScalar(cmd, bindVar);

                if (ret == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
             */
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("f_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);
                item.BindVarList.Add("f_bunho", parent.paBox.BunHo);
                
                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                //if (MasterInsertable())
                                //{

                                    cmdText = @"INSERT INTO NUR1035
                                                      ( SYS_DATE
                                                      , SYS_ID
                                                      , UPD_DATE
                                                      , UPD_ID
                                                      , HOSP_CODE
                                                      , PKNUR1035
                                                      , FKINP1001
                                                      , BUNHO
                                                      , METHOD_CODE
                                                      , START_DATE
                                                      , END_DATE
                                                      , INPUT_ID)
                                                VALUES( SYSDATE
                                                      , :f_user_id
                                                      , SYSDATE
                                                      , :f_user_id
                                                      , :f_hosp_code
                                                      , :f_pknur1035
                                                      , :f_fkinp1001
                                                      , :f_bunho
                                                      , :f_method_code
                                                      , :f_start_date
                                                      , :f_end_date
                                                      , :f_input_id) ";
                                //}
                                //else
                                //{
                                //    return false;
                                //}
                                break;

                            case DataRowState.Modified:
                                //if (MasterInsertable())
                                //{
                                    cmdText = @"UPDATE NUR1035
                                               SET UPD_DATE        = SYSDATE
                                                 , UPD_ID          = :f_user_id
                                                 , METHOD_CODE     = :f_method_code
                                                 , START_DATE      = :f_start_date
                                                 , END_DATE        = :f_end_date
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND PKNUR1035       = :f_pknur1035";
                                //}
                                //else
                                //{
                                //    return false;
                                //}

                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR1035
                                             WHERE HOSP_CODE       = :f_hosp_code 
                                               AND PKNUR1035       = :f_pknur1035";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                                
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO NUR1036
                                                      ( SYS_DATE
                                                      , SYS_ID
                                                      , UPD_DATE
                                                      , UPD_ID
                                                      , HOSP_CODE
                                                      , FKNUR1035
                                                      , CHECK_DATE
                                                      , CHECK_TIME
                                                      , INPUT_ID
                                                      , DANGER_ACT
                                                      , CHANGED_SKIN
                                                      , EDEMA
                                                      , NUMBNESS
                                                      , SCRATCH
                                                      , TUBE_TROUBLE
                                                      , PETECHIA
                                                      , REMARK)
                                                VALUES( SYSDATE
                                                      , :f_user_id
                                                      , SYSDATE
                                                      , :f_user_id
                                                      , :f_hosp_code
                                                      , TO_NUMBER(:f_fknur1035)
                                                      , :f_check_date
                                                      , :f_check_time
                                                      , :f_input_id
                                                      , :f_danger_act
                                                      , :f_changed_skin
                                                      , :f_edema
                                                      , :f_numbness
                                                      , :f_scratch
                                                      , :f_tube_trouble
                                                      , :f_petechia
                                                      , :f_remark)";

                                item.BindVarList.Add("f_remark", parent.grdNUR1036.GetItemString(parent.grdNUR1036.CurrentRowNumber, "remark"), 1000);
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR1036
                                               SET UPD_DATE        = SYSDATE
                                                 , UPD_ID          = :f_user_id
                                                 , INPUT_ID        = :f_input_id
                                                 , DANGER_ACT      = :f_danger_act
                                                 , CHANGED_SKIN    = :f_changed_skin
                                                 , EDEMA           = :f_edema
                                                 , NUMBNESS        = :f_numbness
                                                 , SCRATCH         = :f_scratch
                                                 , TUBE_TROUBLE    = :f_tube_trouble
                                                 , PETECHIA        = :f_petechia
                                                 , REMARK          = :f_remark
                                             WHERE HOSP_CODE       = :f_hosp_code
                                               AND FKNUR1035       = TO_NUMBER(:f_fknur1035)
                                               AND CHECK_DATE      = :f_check_date
                                               AND CHECK_TIME      = :f_check_time";

                                item.BindVarList.Add("f_remark", parent.grdNUR1036.GetItemString(parent.grdNUR1036.CurrentRowNumber, "remark"), 1000);
                                break;

                            case DataRowState.Deleted:
                                cmdText = @"DELETE NUR1036
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND FKNUR1035  = TO_NUMBER(:f_fknur1035)
                                               AND CHECK_DATE = :f_check_date
                                               AND CHECK_TIME = :f_check_time";
                                break;
                        }
                        break;

                    default:
                        break;

                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void NUR1035U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            this.cboHo_dong.SetDataValue(IHIS.Framework.UserInfo.HoDong);

            if (this.OpenParam != null)
            {
                if (this.OpenParam["bunho"].ToString() != "")
                {
                    paBox.SetPatientID(this.OpenParam["bunho"].ToString());
                }
                if (this.OpenParam["date"].ToString() != "")
                {
                    dtpDate.SetDataValue(this.OpenParam["date"].ToString());
                }
            }
            else
            {               
                //현재스크린 환자번호
                XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
                if (patientInfo != null)
                {
                    this.paBox.SetPatientID(patientInfo.BunHo);
                }
                dtpDate.SetDataValue(EnvironInfo.GetSysDate());
            }

            layModifyLimit.QueryLayout();
            
            grdPalist.QueryLayout(false);

            if (paBox.BunHo == "")
            {
                paBox.SetPatientID(grdPalist.GetItemString(0, "bunho"));
            }
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            if (this.CurrMSLayout == grdNUR1035)
            {
                switch (e.Func)
                {
                    case FunctionType.Insert:
                

                        break;
                }
            }
           
        }

        private void grdNUR1036_MouseDown(object sender, MouseEventArgs e)
        {
                   
        }

        private void grdNUR1035_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "end_date")
            {
                if(grdNUR1036.RowCount > 0)
                {
                    if (DateTime.Parse(e.ChangeValue.ToString()) < grdNUR1036.GetItemDateTime(0, "check_date"))
                    {
                        XMessageBox.Show("終了日の指定が間違いました。再度確認してください");
                        e.Cancel = true;                        
                    }
                    else
                    {
                        e.Cancel = false;
                    }
                }
            }
        }

        private void grdPalist_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if(grdPalist.GetItemString(e.RowNumber, "check_yn") == "Y")
            {
                e.BackColor = Color.LightGreen;
            }
            else if (grdPalist.GetItemString(e.RowNumber, "check_yn") == "N")
            {
                e.BackColor = Color.LightPink;
            }
        
        }

        private void grdNUR1035_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (grdNUR1035.GetItemString(e.RowNumber, "check_yn") == "N")
            {
                e.BackColor = Color.LightPink;    
                try
                {
                    if (grdNUR1035.GetItemString(e.RowNumber, "end_date") != "")
                    {
                        if (DateTime.Parse(grdNUR1035.GetItemString(e.RowNumber, "end_date")) < EnvironInfo.GetSysDate())
                        {
                            e.BackColor = Color.Gray;
                        }
                    }
                }
                catch { }
            }

            
        }

        private void grdNUR1036_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            string code = grdNUR1036.GetItemString(e.RowNumber, e.ColName);

            if (e.ColName == "danger_act"
                ||e.ColName == "changed_skin"
                || e.ColName == "edema"
                || e.ColName == "numbness"
                || e.ColName == "scratch"
                || e.ColName == "tube_trouble"
                || e.ColName == "petechia")
            {
                //e.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                switch (code)
                {
                    case "0":
                        e.ForeColor = Color.Black;                        
                        break;

                    case "1":
                        e.ForeColor = Color.Blue;
                        break;

                    case "2":
                        e.ForeColor = Color.Red;
                        break;
                }   
            }

            try
            {
                DateTime date = DateTime.Parse(grdNUR1036.GetItemString(e.RowNumber, "check_date"));

                if (date.ToString() == dtpDate.GetDataValue())
                {
                    e.BackColor = Color.LightGreen;
                }
                else if (date <= EnvironInfo.GetSysDate().AddDays(int.Parse(layModifyLimit.GetItemValue("limit").ToString()) * -1))
                {
                    e.BackColor = Color.LightGray;
                }

            }
            catch
            {
                XMessageBox.Show("日付の指定に問題があります。");
            }  
        }

        private void dtpDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdPalist.QueryLayout(false);
            grdNUR1035.QueryLayout(false);
        }

        private void grdNUR1035_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            if (CheckGrdChanged(grdNUR1036) > 0)
            {
                if (XMessageBox.Show("保存されてないデータがあります。\n保存しますか？", "確認", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnList.PerformClick(FunctionType.Update);
                }   
            }
        }

        private void txtJubsuja_DataValidating(object sender, DataValidatingEventArgs e)
        {
			dbxJubsujaName.SetDataValue("");

			if( TypeCheck.IsNull(e.DataValue) )
			{
                txtJubsuja.SetDataValue("");
			}
			
			string user_nm = this.GetAdminUSER_NAME(e.DataValue);

            if (TypeCheck.IsNull(user_nm))
            {
                txtJubsuja.SetDataValue("");
                txtJubsuja.Focus();
                txtJubsuja.SelectAll();
            }
            else
            {
                this.dbxJubsujaName.SetDataValue(user_nm);
                this.grdNUR1035.Focus();
            }
        }

        #region [ユーザの名前を取得] 同期化完了
        private string GetAdminUSER_NAME(string aUser_id)
        {
            string sqlCmd = "";
            BindVarCollection bindvar = new BindVarCollection();

            sqlCmd = @"SELECT USER_NM
                         FROM ADM3200   
                        WHERE HOSP_CODE = :f_hosp_code
                          AND USER_ID   = :f_user_id";



            bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindvar.Add("f_user_id", aUser_id);

            object retVar = Service.ExecuteScalar(sqlCmd, bindvar);


            if (retVar != null)
            {
                return retVar.ToString();
            }

            return "";
        }
        #endregion

        private void grdPalist_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPalist.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdPalist.SetBindVarValue("f_date", dtpDate.GetDataValue());
            grdPalist.SetBindVarValue("f_ho_dong", cboHo_dong.GetDataValue());
            grdPalist.SetBindVarValue("f_a", cbxA.GetDataValue());
            grdPalist.SetBindVarValue("f_b", cbxB.GetDataValue());
            grdPalist.SetBindVarValue("f_c", cbxC.GetDataValue());
            grdPalist.SetBindVarValue("f_d", cbxD.GetDataValue());
        }

        private void grdPalist_Click(object sender, EventArgs e)
        {
            if (grdPalist.CurrentRowNumber >= 0)
            {
                //환자번호 Set
                this.paBox.SetPatientID(grdPalist.GetItemValue(this.grdPalist.CurrentRowNumber, "bunho").ToString());
                //this.paListRownum = grdPalist.CurrentRowNumber;
            }
        }
        private void btnNextPatient_Click(object sender, EventArgs e)
        {
            int rownum = paListRownum + 1 < grdPalist.RowCount ? paListRownum + 1 : 0;

            paBox.SetPatientID(grdPalist.GetItemString(rownum, "bunho"));

            paListRownum = rownum;

            grdPalist.UnSelectAll();
            grdPalist.SelectRow(rownum);
            grdPalist.SetFocusToItem(rownum, "bunho");

            btnNextPatient.Focus();
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            GetFkinp1001();
            Set_grdPalist_Position(paBox.BunHo);
            grdNUR1035.QueryLayout(false);
        }

        private void GetFkinp1001()
        {
            string cmdText = "";
            object retVal = null;
            BindVarCollection bindvar = new BindVarCollection();

            cmdText = "SELECT PKINP1001"
                    + "  FROM VW_OCS_INP1001_01"
                    + " WHERE HOSP_CODE          = :f_hosp_code"
                    + "   AND NVL(CANCEL_YN,'N') = 'N'"
                    + "   AND NVL(JAEWON_FLAG,'N') = 'Y'"
                    + "   AND BUNHO = :f_bunho";

            bindvar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindvar.Add("f_bunho", paBox.BunHo);

            if (this.paBox.BunHo.ToString() != "")
            {
                retVal = Service.ExecuteScalar(cmdText, bindvar);
                if (TypeCheck.IsNull(retVal))
                {
                    XMessageBox.Show("在院中の患者ではありません。");
                    return;
                }
                else
                {
                    txtFkinp1001.SetEditValue(retVal.ToString());
                }
            }
            else
            {
                return;
            }
        }


        private void Set_grdPalist_Position(string i_bunho)
        {
            this.grdPalist.UnSelectAll();
            for (int i = 0; i < this.grdPalist.RowCount; i++)
            {
                if (this.grdPalist.GetItemString(i, "bunho") == i_bunho)
                {
                    this.grdPalist.SelectRow(i);
                    grdPalist.SetFocusToItem(i, "bunho");
                    paListRownum = i;
                    break;
                }
            }
            grdPalist.SelectRow(paListRownum);
            grdPalist.SetFocusToItem(paListRownum, "bunho");
        }

        private void grdPalist_QueryEnd(object sender, QueryEndEventArgs e)
        {
            Set_grdPalist_Position(paBox.BunHo);
        }

        private void cbxTeam_CheckedChanged(object sender, EventArgs e)
        {
            grdPalist.QueryLayout(false);
        }

        private void btnClearConfirmUser_Click(object sender, EventArgs e)
        {
            txtJubsuja.SetDataValue("");
            dbxJubsujaName.SetDataValue("");
        }

        private void grdNUR1036_MouseClick(object sender, MouseEventArgs e)
        {

            int rownum = grdNUR1036.GetHitRowNumber(e.Y);

            try
            {
                if (rownum > -1 && rownum < grdNUR1036.RowCount)
                {
                    //[수정 제한 기본설정] 오늘 포함 3일에 제한.
                    int limit = 3;

                    //limit_yn 이 Y
                    if (layModifyLimit.GetItemValue("limit_yn").ToString() == "Y")
                    {
                        try
                        {
                            limit = int.Parse(layModifyLimit.GetItemValue("limit").ToString()) * -1;
                        }
                        catch
                        {
                            limit = 3;
                        }

                        if (grdNUR1036.GetItemDateTime(grdNUR1036.CurrentRowNumber, "check_date") <= EnvironInfo.GetSysDate().AddDays(limit)
                            && grdNUR1036.GetRowState(grdNUR1036.CurrentRowNumber) == DataRowState.Unchanged)
                        {
                            ShowMessage("CanNotModify");
                            return;
                        }
                    }
           
                    if ((rownum > -1) && (e.Button == MouseButtons.Left))
                    {
                        if (grdNUR1036.CurrentColName == "danger_act" ||
                            grdNUR1036.CurrentColName == "changed_skin" ||
                            grdNUR1036.CurrentColName == "edema" ||
                            grdNUR1036.CurrentColName == "petechia" ||
                            grdNUR1036.CurrentColName == "scratch" ||
                            grdNUR1036.CurrentColName == "numbness" ||
                            grdNUR1036.CurrentColName == "tube_trouble")
                        {
                            for (int i = 0; i < layState.RowCount; i++)
                            {
                                if (layState.GetItemString(i, "code") == grdNUR1036.GetItemString(grdNUR1036.CurrentRowNumber, grdNUR1036.CurrentColName))
                                {
                                    grdNUR1036.SetItemValue(grdNUR1036.CurrentRowNumber, grdNUR1036.CurrentColName, layState.GetItemString(((i + 1) % layState.RowCount), "code"));
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch
            {

            }
        }

        private void cboHo_dong_SelectedIndexChanged(object sender, EventArgs e)
        {
            paListRownum = 0;
            grdPalist.QueryLayout(true);
        }        
    }
}

