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
using System.Collections.Specialized;
using IHIS.Framework;
using IHIS.NURO.Properties;

#endregion

namespace IHIS.NURO
{
	/// <summary>
	/// NUR1018R03에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR1018R03 : IHIS.Framework.XScreen
	{
		#region user generated value

		#endregion

        string[] weeks = new string[] { Resources.text_sun, Resources.text_Mo, Resources.text_Tu, Resources.text_we, Resources.text_Th, Resources.text_Fr, Resources.text_Sat };

		#region 자동 생성 멤버 변수

		private IHIS.Framework.XPanel pnlTop;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlFill;
		private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpNurWrdt;
        private IHIS.Framework.XDataWindow dwNUR1018R03_1;

		#endregion

        private XPanel pnlGwaCnt;
        private XLabel xLabel1;
        private XEditGrid grdGwaCnt;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XPanel pnlNurse;
        private XLabel xLabel3;
        private XPanel pnlGrid;
        private XEditGrid grdNurse;
        private XPanel pnlComment;
        private XLabel xLabel4;
        private XEditGrid grdComment;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XFindWorker fwkNurse;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XEditGridCell xEditGridCell15;
        private MultiLayout layTotalCnt;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
        private MultiLayoutItem multiLayoutItem5;
        private XCheckBox cbxConfirm_yn;
        private SingleLayout layConfirm_yn;
        private SingleLayoutItem singleLayoutItem1;
        private XButton btnPList;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XGridHeader xGridHeader1;
        private XGridHeader xGridHeader2;
        private MultiLayout layTimeGubun;
        private MultiLayoutItem multiLayoutItem6;
        private MultiLayoutItem multiLayoutItem7;
        private MultiLayoutItem multiLayoutItem8;


        /// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NUR1018R03()
		{
            try
            {
                // 이 호출은 Windows Form 디자이너에 필요합니다.
                InitializeComponent();

                this.grdNurse.SavePerformer = new XSavePerformer(this);
                this.grdComment.SavePerformer = this.grdNurse.SavePerformer;
            }
            catch(Exception x)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.StackTrace);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR1018R03));
            this.pnlTop = new IHIS.Framework.XPanel();
            this.cbxConfirm_yn = new IHIS.Framework.XCheckBox();
            this.dwNUR1018R03_1 = new IHIS.Framework.XDataWindow();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpNurWrdt = new IHIS.Framework.XDatePicker();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnPList = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlNurse = new IHIS.Framework.XPanel();
            this.pnlGrid = new IHIS.Framework.XPanel();
            this.grdNurse = new IHIS.Framework.XEditGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader2 = new IHIS.Framework.XGridHeader();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.pnlComment = new IHIS.Framework.XPanel();
            this.grdComment = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.pnlGwaCnt = new IHIS.Framework.XPanel();
            this.grdGwaCnt = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.layTotalCnt = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.layConfirm_yn = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layTimeGubun = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlFill.SuspendLayout();
            this.pnlNurse.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNurse)).BeginInit();
            this.pnlComment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).BeginInit();
            this.pnlGwaCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGwaCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTotalCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeGubun)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "TopBackground.GIF");
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::IHIS.NURO.Properties.Resources.TopBackground;
            this.pnlTop.Controls.Add(this.cbxConfirm_yn);
            this.pnlTop.Controls.Add(this.dwNUR1018R03_1);
            this.pnlTop.Controls.Add(this.xLabel2);
            this.pnlTop.Controls.Add(this.dtpNurWrdt);
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Name = "pnlTop";
            // 
            // cbxConfirm_yn
            // 
            resources.ApplyResources(this.cbxConfirm_yn, "cbxConfirm_yn");
            this.cbxConfirm_yn.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.cbxConfirm_yn.ForeColor = IHIS.Framework.XColor.ShadowForeColor;
            this.cbxConfirm_yn.Name = "cbxConfirm_yn";
            this.cbxConfirm_yn.UseVisualStyleBackColor = false;
            this.cbxConfirm_yn.CheckedChanged += new System.EventHandler(this.cbxConfirm_yn_CheckedChanged);
            // 
            // dwNUR1018R03_1
            // 
            this.dwNUR1018R03_1.DataWindowObject = "d_nur1018r03_1";
            this.dwNUR1018R03_1.LibraryList = "..\\NURO\\nuro.nur1018r03.pbd";
            resources.ApplyResources(this.dwNUR1018R03_1, "dwNUR1018R03_1");
            this.dwNUR1018R03_1.Name = "dwNUR1018R03_1";
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpNurWrdt
            // 
            this.dtpNurWrdt.ApplyLayoutContainerReset = false;
            resources.ApplyResources(this.dtpNurWrdt, "dtpNurWrdt");
            this.dtpNurWrdt.Name = "dtpNurWrdt";
            this.dtpNurWrdt.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpNurWrdt_DataValidating);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPList);
            this.pnlBottom.Controls.Add(this.btnList);
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnPList
            // 
            resources.ApplyResources(this.btnPList, "btnPList");
            this.btnPList.Name = "btnPList";
            this.btnPList.Click += new System.EventHandler(this.btnPList_Click);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.F5, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Print, System.Windows.Forms.Shortcut.F12, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Insert, System.Windows.Forms.Shortcut.F7, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Delete, System.Windows.Forms.Shortcut.F9, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.F2, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlNurse);
            this.pnlFill.Controls.Add(this.pnlGwaCnt);
            resources.ApplyResources(this.pnlFill, "pnlFill");
            this.pnlFill.Name = "pnlFill";
            // 
            // pnlNurse
            // 
            this.pnlNurse.Controls.Add(this.pnlGrid);
            this.pnlNurse.Controls.Add(this.xLabel3);
            this.pnlNurse.Controls.Add(this.pnlComment);
            resources.ApplyResources(this.pnlNurse, "pnlNurse");
            this.pnlNurse.Name = "pnlNurse";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.grdNurse);
            resources.ApplyResources(this.pnlGrid, "pnlGrid");
            this.pnlGrid.Name = "pnlGrid";
            // 
            // grdNurse
            // 
            this.grdNurse.AddedHeaderLine = 1;
            this.grdNurse.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell16,
            this.xEditGridCell17,
            this.xEditGridCell18});
            this.grdNurse.ColPerLine = 5;
            this.grdNurse.Cols = 6;
            resources.ApplyResources(this.grdNurse, "grdNurse");
            this.grdNurse.FixedCols = 1;
            this.grdNurse.FixedRows = 2;
            this.grdNurse.HeaderHeights.Add(21);
            this.grdNurse.HeaderHeights.Add(0);
            this.grdNurse.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader2});
            this.grdNurse.Name = "grdNurse";
            this.grdNurse.QuerySQL = resources.GetString("grdNurse.QuerySQL");
            this.grdNurse.RowHeaderVisible = true;
            this.grdNurse.Rows = 3;
            this.grdNurse.ToolTipActive = true;
            this.grdNurse.UseDefaultTransaction = false;
            this.grdNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNurse_QueryStarting);
            this.grdNurse.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNurse_GridColumnChanged);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "nurse_grade";
            this.xEditGridCell7.CellWidth = 92;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsNotNull = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowSpan = 2;
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell7.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'NURSE_GRADE\'\r\n   AND CODE      <> \'03\' --NOT 補助者";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AutoTabDataSelected = true;
            this.xEditGridCell8.CellName = "nurse_id";
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell8.FindWorker = this.fwkNurse;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsNotNull = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.Row = 1;
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            this.fwkNurse.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkNurse.ServerFilter = true;
            this.fwkNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkNurse_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "nurse_id";
            this.findColumnInfo1.ColWidth = 106;
            resources.ApplyResources(this.findColumnInfo1, "findColumnInfo1");
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo2.ColName = "nurse_name";
            this.findColumnInfo2.ColWidth = 149;
            resources.ApplyResources(this.findColumnInfo2, "findColumnInfo2");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 30;
            this.xEditGridCell9.CellName = "nurse_name";
            this.xEditGridCell9.CellWidth = 174;
            this.xEditGridCell9.Col = 4;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.Row = 1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "work_type";
            this.xEditGridCell10.CellWidth = 105;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsNotNull = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowSpan = 2;
            this.xEditGridCell10.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.xEditGridCell10.UserSQL = "SELECT CODE\r\n     , CODE_NAME\r\n  FROM NUR0102\r\n WHERE HOSP_CODE = FN_ADM_LOAD_HOS" +
                "P_CODE()\r\n   AND CODE_TYPE = \'WORK_TYPE_OUT\'";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "nur_wrdt";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "nurse_grade_name";
            this.xEditGridCell16.Col = -1;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.IsUpdCol = false;
            this.xEditGridCell16.IsVisible = false;
            this.xEditGridCell16.Row = -1;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "work_type_name";
            this.xEditGridCell17.Col = -1;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "work_time";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell18.CellWidth = 114;
            this.xEditGridCell18.Col = 5;
            this.xEditGridCell18.DecimalDigits = 1;
            this.xEditGridCell18.DecimalPlaces = 1;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.MaxinumCipher = 2;
            this.xEditGridCell18.RowSpan = 2;
            // 
            // xGridHeader2
            // 
            this.xGridHeader2.Col = 3;
            this.xGridHeader2.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader2, "xGridHeader2");
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // pnlComment
            // 
            this.pnlComment.Controls.Add(this.grdComment);
            this.pnlComment.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.pnlComment, "pnlComment");
            this.pnlComment.Name = "pnlComment";
            // 
            // grdComment
            // 
            this.grdComment.CallerID = '2';
            this.grdComment.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14});
            this.grdComment.ColPerLine = 1;
            this.grdComment.Cols = 2;
            resources.ApplyResources(this.grdComment, "grdComment");
            this.grdComment.FixedCols = 1;
            this.grdComment.FixedRows = 1;
            this.grdComment.HeaderHeights.Add(21);
            this.grdComment.Name = "grdComment";
            this.grdComment.QuerySQL = "SELECT COMMENT_DATE\r\n     , REMARK\r\n     , SEQ\r\n  FROM NUR5012\r\n WHERE HOSP_CODE " +
                "   = :f_hosp_code\r\n   AND COMMENT_DATE = :f_nur_wrdt\r\n ORDER BY SEQ ";
            this.grdComment.RowHeaderVisible = true;
            this.grdComment.Rows = 2;
            this.grdComment.ToolTipActive = true;
            this.grdComment.UseDefaultTransaction = false;
            this.grdComment.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment_QueryStarting);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "comment_date";
            this.xEditGridCell12.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell12.CellWidth = 486;
            this.xEditGridCell12.Col = 1;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsJapanYearType = true;
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.SuppressRepeating = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 86;
            this.xEditGridCell13.CellName = "comment";
            this.xEditGridCell13.CellWidth = 486;
            this.xEditGridCell13.Col = 1;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            this.xEditGridCell13.IsNotNull = true;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "seq";
            this.xEditGridCell14.CellWidth = 30;
            this.xEditGridCell14.Col = 3;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xLabel4
            // 
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // pnlGwaCnt
            // 
            this.pnlGwaCnt.Controls.Add(this.grdGwaCnt);
            this.pnlGwaCnt.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.pnlGwaCnt, "pnlGwaCnt");
            this.pnlGwaCnt.Name = "pnlGwaCnt";
            // 
            // grdGwaCnt
            // 
            this.grdGwaCnt.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell15,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdGwaCnt.ColPerLine = 6;
            this.grdGwaCnt.Cols = 7;
            resources.ApplyResources(this.grdGwaCnt, "grdGwaCnt");
            this.grdGwaCnt.FixedCols = 1;
            this.grdGwaCnt.FixedRows = 1;
            this.grdGwaCnt.HeaderHeights.Add(21);
            this.grdGwaCnt.Name = "grdGwaCnt";
            this.grdGwaCnt.QuerySQL = resources.GetString("grdGwaCnt.QuerySQL");
            this.grdGwaCnt.ReadOnly = true;
            this.grdGwaCnt.RowHeaderVisible = true;
            this.grdGwaCnt.Rows = 2;
            this.grdGwaCnt.ToolTipActive = true;
            this.grdGwaCnt.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdGwaCnt_QueryEnd);
            this.grdGwaCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdGwaCnt_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "gwa";
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = -1;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gwa_name";
            this.xEditGridCell15.CellWidth = 117;
            this.xEditGridCell15.Col = 1;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "new_coming_cnt";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.CellWidth = 136;
            this.xEditGridCell2.Col = 2;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "re_coming_cnt";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 137;
            this.xEditGridCell3.Col = 3;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "total_coming_cnt";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = 4;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "over_time_cnt";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell5.CellWidth = 98;
            this.xEditGridCell5.Col = 5;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "er_cnt";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell6.CellWidth = 112;
            this.xEditGridCell6.Col = 6;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.xLabel1.Name = "xLabel1";
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 3;
            this.xGridHeader1.ColSpan = 2;
            resources.ApplyResources(this.xGridHeader1, "xGridHeader1");
            // 
            // layTotalCnt
            // 
            this.layTotalCnt.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5});
            this.layTotalCnt.QuerySQL = resources.GetString("layTotalCnt.QuerySQL");
            this.layTotalCnt.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTotalCnt_QueryStarting);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "nurse_grade_name";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "day_cnt";
            this.multiLayoutItem2.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "half_cnt";
            this.multiLayoutItem3.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "holy_cnt";
            this.multiLayoutItem4.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "vac_cnt";
            this.multiLayoutItem5.DataType = IHIS.Framework.DataType.Number;
            // 
            // layConfirm_yn
            // 
            this.layConfirm_yn.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layConfirm_yn.QuerySQL = resources.GetString("layConfirm_yn.QuerySQL");
            this.layConfirm_yn.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layConfirm_yn_QueryStarting);
            this.layConfirm_yn.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layConfirm_yn_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "confirm_yn";
            // 
            // layTimeGubun
            // 
            this.layTimeGubun.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem6,
            this.multiLayoutItem7,
            this.multiLayoutItem8});
            this.layTimeGubun.QuerySQL = resources.GetString("layTimeGubun.QuerySQL");
            this.layTimeGubun.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layTimeGubun_QueryStarting);
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "symya_gubun";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "from_time";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "to_time";
            // 
            // NUR1018R03
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            resources.ApplyResources(this, "$this");
            this.Name = "NUR1018R03";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR1018R03_Closing);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlFill.ResumeLayout(false);
            this.pnlNurse.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNurse)).EndInit();
            this.pnlComment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment)).EndInit();
            this.pnlGwaCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGwaCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTotalCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layTimeGubun)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private string mHospCode = "";
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad (e);

            mHospCode = EnvironInfo.HospCode;

			// 작성일자 현재 일자 셋팅
            this.dtpNurWrdt.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            QueryAll();
		}

		#region 타Screen에서 Open (Command)	
		public override object Command(string command, CommonItemCollection commandParam)
		{
			if (commandParam.Contains("PATIENT") && (MultiLayout)commandParam["PATIENT"] != null && 
				((MultiLayout)commandParam["PATIENT"]).RowCount > 0)
			{
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "bunho"    , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"bunho"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "suname"   , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"suname"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "ho_dong"  , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"ho_dong"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "age"      , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"age"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "sang_name", ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"sang_name"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "resident" , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"doctor"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "resident_name" , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"doctor_name"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "gwa"      , ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"gwa"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "old_bunho", ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"bunho"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "old_bunho", ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"bunho"));
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "ho_dong1", ((MultiLayout)commandParam["PATIENT"]).GetItemString(0,"ho_dong"));
			}

			if (command == "OCS0270Q00")
			{
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "resident"      , commandParam["doctor"].ToString());
				CurrMSLayout.SetItemValue(CurrMSLayout.CurrentRowNumber, "resident_name" , commandParam["doctor_name"].ToString());
			}
			return base.Command(command, commandParam);
		}
		#endregion		        

        #region grdGwaCnt_Query
        private void grdGwaCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdGwaCnt.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdGwaCnt.SetBindVarValue("f_naewon_date", this.dtpNurWrdt.GetDataValue());
        }

        private void grdGwaCnt_QueryEnd(object sender, QueryEndEventArgs e)
        {
            string cmdText = "";
            object retVal = null;

            BindVarCollection bc = new BindVarCollection();
            bc.Add("f_hosp_code", mHospCode);
            bc.Add("f_naewon_date", this.dtpNurWrdt.GetDataValue());

            for (int i = 0; i < grdGwaCnt.RowCount; i++)
            {
                bc.Add("f_gwa", this.grdGwaCnt.GetItemString(i, "gwa"));

                cmdText = @"SELECT COUNT(1)         OVER_TIME  
                              FROM NUR5010 
                             WHERE HOSP_CODE   = :f_hosp_code
                               AND NAEWON_DATE = :f_naewon_date 
                               AND GWA         = :f_gwa 
                               ";

                if (this.layTimeGubun.RowCount > 0)
                {
                    string temp_query = @"AND ";
                    string over_query = @"";

                    bool isDayAdded = false;
                    int rowCnt = 0;

                    DataRow[] rows = layTimeGubun.LayoutTable.Select(" symya_gubun = '0'"); //시간내
                    foreach (DataRow row in rows)
                    {
                        if (!isDayAdded)
                            over_query += " ( ";

                        isDayAdded = true;

                        //두번째부터 OR 넣어줌
                        if (rowCnt != 0)
                            over_query += " AND \r\n";

                        over_query += "JUBSU_TIME NOT BETWEEN '" + row["from_time"] + "' AND '" + row["to_time"] + "' ";

                        //마지막 데이타일 때
                        rowCnt++;

                    }
                    temp_query += over_query + " )";

                    cmdText += temp_query;

                }

                cmdText += "\r\n GROUP BY GWA";

                retVal = null;
                retVal =Service.ExecuteScalar(cmdText, bc);
                if (!TypeCheck.IsNull(retVal))
                    this.grdGwaCnt.SetItemValue(i, "over_time_cnt", retVal.ToString());
                else
                    this.grdGwaCnt.SetItemValue(i, "over_time_cnt", "0");


                cmdText = @"SELECT COUNT(1)         IPWON_CNT  
                              FROM NUR5010 
                             WHERE HOSP_CODE   = :f_hosp_code
                               AND NAEWON_DATE = :f_naewon_date 
                               AND GWA         = :f_gwa
                               AND HO_CODE IS NOT NULL
                             GROUP BY GWA";

                retVal = null;
                retVal = Service.ExecuteScalar(cmdText, bc);
                if (!TypeCheck.IsNull(retVal))
                    this.grdGwaCnt.SetItemValue(i, "er_cnt", retVal.ToString());
                else
                    this.grdGwaCnt.SetItemValue(i, "er_cnt", "0");

            }
            this.grdGwaCnt.ResetUpdate();
        }
        #endregion

        #region QueryAll

        private void QueryAll()
        {
            this.layTimeGubun.QueryLayout(false);
            this.layConfirm_yn.QueryLayout();
            DataTable dt = new DataTable("temp_table");

            try
            {
                string[] dateString = dtpNurWrdt.GetDataValue().Split('/');
                DateTime date = new DateTime(int.Parse(dateString[0]), int.Parse(dateString[1])
                    , int.Parse(dateString[2]));
                int week = (int)date.DayOfWeek;
                string t_weeks = weeks[week];

                this.dwNUR1018R03_1.Reset();

                this.grdGwaCnt.QueryLayout(true);

                if (this.grdGwaCnt.RowCount > 0)
                {
                    this.dwNUR1018R03_1.FillChildData("dw_1", this.grdGwaCnt.LayoutTable);

                    Sybase.DataWindow.DataWindowChild dwNUR1018R03Child1 = dwNUR1018R03_1.GetChild("dw_1");
                    dwNUR1018R03Child1.Modify("t_nur_wrdt.Text = '" + dateString[0] + " 年 " + dateString[1]
                        + " 月 " + dateString[2] + " 日'");
                    dwNUR1018R03Child1.Modify("t_weeks.Text = '" + t_weeks + "'");
                    dwNUR1018R03_1.AcceptText();
                }
                else
                    return;

                this.grdNurse.QueryLayout(true);
                if (this.grdNurse.RowCount > 0)
                {
                    this.dwNUR1018R03_1.FillChildData("dw_2", this.grdNurse.LayoutTable);
                }
                else
                {
                    dt.Columns.Clear();
                    dt.Rows.Clear();

                    dt.Columns.Add("nurse_name");
                    dt.Rows.Add("");
                    this.dwNUR1018R03_1.FillChildData("dw_2", dt);
                }

                this.layTotalCnt.QueryLayout(true);

                if (this.layTotalCnt.RowCount > 0)
                    this.dwNUR1018R03_1.FillChildData("dw_6", this.layTotalCnt.LayoutTable);
                else
                {
                    dt.Columns.Clear();
                    dt.Rows.Clear();

                    dt.Columns.Add("day_cnt");
                    dt.Columns.Add("half_cnt");
                    dt.Columns.Add("holy_cnt");
                    dt.Columns.Add("vac_cnt");
                    dt.Rows.Add(0, 0, 0, 0);

                    this.dwNUR1018R03_1.FillChildData("dw_6", dt);
                }

                this.grdComment.QueryLayout(true);
                if (this.grdComment.RowCount > 0)   
                {
                    this.dwNUR1018R03_1.FillChildData("dw_5", this.grdComment.LayoutTable);
                }
                else
                {
                    dt.Columns.Clear();
                    dt.Rows.Clear();

                    dt.Columns.Add("comment");
                    dt.Rows.Add(Resources.comment);
                    this.dwNUR1018R03_1.FillChildData("dw_5", dt);
                }
            }
            catch (Exception x)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(x.Message);
            }
        }

        #endregion

        #region btnList_ButtonClick
        private bool mIsSaveSuccess = true;
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            { 
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    QueryAll();

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;
                    mIsSaveSuccess = true;
                    //if (this.cbxConfirm_yn.GetDataValue() == "Y")
                    //    return;

                    string cmdText = "";

                    try
                    {
                        Service.BeginTransaction();

                        cmdText = @"SELECT A.CONFIRM_YN, A.SEQ
                                      FROM NUR5100 A
                                     WHERE A.HOSP_CODE = :f_hosp_code
                                       AND NUR_WRDT    = :f_nur_wrdt
                                       AND A.SEQ       = (SELECT MAX(Z.SEQ)
                                                              FROM NUR5100 Z
                                                             WHERE Z.HOSP_CODE = A.HOSP_CODE
                                                               AND Z.NUR_WRDT  = A.NUR_WRDT  )";
//                        cmdText = @"SELECT CONFIRM_YN, SEQ
//                                      FROM NUR5100
//                                     WHERE HOSP_CODE = :f_hosp_code
//                                       AND NUR_WRDT  = :f_nur_wrdt
//                                       AND ROWNUM    = 1
//                                     ORDER BY SEQ DESC";

                        BindVarCollection bc = new BindVarCollection();
                        bc.Add("f_hosp_code", mHospCode);
                        bc.Add("f_nur_wrdt", this.dtpNurWrdt.GetDataValue());

                        DataTable dt = Service.ExecuteDataTable(cmdText, bc);

                        cmdText = @"INSERT INTO NUR5100
                                         ( SYS_DATE         , SYS_ID
                                         , UPD_DATE         , UPD_ID        , HOSP_CODE
                                         , NUR_WRDT         , CONFIRM_YN    , SEQ       )
                                    VALUES 
                                         ( SYSDATE          , :q_user_id
                                         , SYSDATE          , :q_user_id    , :f_hosp_code
                                         , :f_nur_wrdt      , :f_confirm_yn , :f_seq      )";

                        bc.Add("q_user_id", UserInfo.UserID);
                        bc.Add("f_confirm_yn", this.cbxConfirm_yn.Checked ? "Y" : "N");
                        bc.Add("f_seq","1");

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["confirm_yn"].ToString() == "N")
                            {
                                cmdText = @"UPDATE NUR5100
                                               SET UPD_DATE   = SYSDATE
                                                 , UPD_ID     = :q_user_id
                                                 , CONFIRM_YN = :f_confirm_yn
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND NUR_WRDT   = :f_nur_wrdt
                                               AND SEQ        = :f_seq         ";
                                bc.Add("f_seq", dt.Rows[0]["seq"].ToString());
                            }
                            else
                            {
                                int t_seq = Convert.ToInt32(dt.Rows[0]["seq"]) + 1;
                                bc.Add("f_seq", t_seq.ToString());
                            }
                        }

                        if (!Service.ExecuteNonQuery(cmdText, bc))
                            throw new Exception();

                        if (!this.grdNurse.SaveLayout())
                            throw new Exception();

                        if (!this.grdComment.SaveLayout())
                            throw new Exception();

                        Service.CommitTransaction();

                        QueryAll();
                        XMessageBox.Show(Resources.XMessageBox1, Resources.Caption1, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        mIsSaveSuccess = false;
                        XMessageBox.Show(Resources.XMessageBox2 + Service.ErrFullMsg, Resources.Caption2, MessageBoxIcon.Error); 
                    }


                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.cbxConfirm_yn.GetDataValue() == "Y")
                        return;

                    int insertedRowNum = -1;

                    if (this.CurrMSLayout == this.grdNurse)
                    {
                        insertedRowNum = this.grdNurse.InsertRow();
                        this.grdNurse.SetItemValue(insertedRowNum, "nur_wrdt", this.dtpNurWrdt.GetDataValue());
                    }
                    else if (this.CurrMSLayout == this.grdComment)
                    {
                        insertedRowNum = this.grdComment.InsertRow();
                        this.grdComment.SetItemValue(insertedRowNum, "comment_date", this.dtpNurWrdt.GetDataValue());
                    }

                    break;

                case FunctionType.Delete:

                    if (this.cbxConfirm_yn.GetDataValue() == "Y")
                    {
                        e.IsBaseCall = false;
                        return;
                    }

                    break;

                case FunctionType.Print:
                    e.IsBaseCall = false;

                    if(this.dwNUR1018R03_1.RowCount > 0)
                        this.dwNUR1018R03_1.Print();

                    break;
            }
        }
        #endregion

        #region QueryStartin
        private void grdNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNurse.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdNurse.SetBindVarValue("f_nur_wrdt", this.dtpNurWrdt.GetDataValue());
        }

        private void grdComment_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment.SetBindVarValue("f_hosp_code", mHospCode);
            this.grdComment.SetBindVarValue("f_nur_wrdt", this.dtpNurWrdt.GetDataValue());
        }

        private void fwkNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            this.fwkNurse.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void layTotalCnt_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTotalCnt.SetBindVarValue("f_hosp_code", mHospCode);
            this.layTotalCnt.SetBindVarValue("f_nur_wrdt", this.dtpNurWrdt.GetDataValue());
        }
        #endregion

        #region dtpNurWrdt_DataValidating
        private void dtpNurWrdt_DataValidating(object sender, DataValidatingEventArgs e)
        {
            QueryAll();
        }
        #endregion 

        #region layConfirm_yn_Query
        private void layConfirm_yn_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layConfirm_yn.SetBindVarValue("f_hosp_code", mHospCode);
            this.layConfirm_yn.SetBindVarValue("f_date", this.dtpNurWrdt.GetDataValue());
        }

        private void layConfirm_yn_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (this.layConfirm_yn.GetItemValue("confirm_yn").ToString() == "Y")
            {
                this.cbxConfirm_yn.Checked = true;
                this.grdNurse.ReadOnly = true;
                this.grdComment.ReadOnly = true;
            }
            else
            {
                this.cbxConfirm_yn.Checked = false;
                this.grdNurse.ReadOnly = false;
                this.grdComment.ReadOnly = false;
            }
        }
        #endregion

        #region cbxConfirm_yn_CheckedChanged
        private void cbxConfirm_yn_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbxConfirm_yn.Checked)
            {
                this.grdNurse.ReadOnly = true;
                this.grdComment.ReadOnly = true;
            }
            else
            {
                this.grdNurse.ReadOnly = false;
                this.grdComment.ReadOnly = false;
            }
        }
        #endregion

        #region btnPList_Click
        private void btnPList_Click(object sender, EventArgs e)
        {
            CommonItemCollection bodyOpen = new CommonItemCollection();

            bodyOpen.Add("nur_wrdt", this.dtpNurWrdt.GetDataValue());
            IHIS.Framework.XScreen.OpenScreenWithParam(this, "NURO", "NUR5010U00", ScreenOpenStyle.ResponseFixed, bodyOpen);
        }
        #endregion

        #region grdNurse_GridColumnChanged
        private void grdNurse_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            SetMsg("");
            if (e.ChangeValue.ToString() == "")
                return;

            if (e.ColName == "nurse_id")
            {
                string cmdText = @"SELECT B.USER_NM
                                      FROM ADM3200 B
                                     WHERE HOSP_CODE = :f_hosp_code
                                       AND (B.USER_END_YMD IS NULL
                                        OR SYSDATE < B.USER_END_YMD)
                                       AND B.USER_ID = :f_nurse_id
                                       AND B.USER_GUBUN = '2'
                                       --AND B.DEPT_CODE = :f_buseo_code
                                       AND B.USER_GROUP LIKE 'NUR%'";
                BindVarCollection bc = new BindVarCollection();
                bc.Add("f_hosp_code", mHospCode);
                bc.Add("f_nurse_id", e.ChangeValue.ToString());

                object nurse_name = Service.ExecuteScalar(cmdText, bc);

                if (TypeCheck.IsNull(nurse_name))
                {
                    SetMsg(Resources.XMessageBox4, MsgType.Error);
                    e.Cancel = true;
                    return;
                }
                else
                {
                    this.grdNurse.SetItemValue(e.RowNumber, "nurse_name", nurse_name);
                }
            }

            if (!CheckDup(e.DataRow, e.RowNumber))
            {
                SetMsg(Resources.XMessageBox5, MsgType.Error);
                e.Cancel = true;
                return;
            }
        }
        #endregion

        #region CheckDup

        private bool CheckDup(DataRow p_row, int rowNum)
        {
            int cnt = 0;
            int minusCnt = 0;
            for (int i = 0; i < this.grdNurse.RowCount; i++)
            {
                if (rowNum == i)
                    continue;

                DataRow row = this.grdNurse.LayoutTable.Rows[i];

                cnt = 0;
                minusCnt = 0;
                for (int j = 0; j < p_row.ItemArray.Length; j++)
                {
                    if (p_row.Table.Columns[j].ColumnName.IndexOf("name") >= 0)
                    {
                        minusCnt++; //_name 컬럼은 제외시킴
                        continue;
                    }

                    if (p_row.Table.Columns[j].ColumnName.IndexOf("work_time") >= 0)
                    {
                        minusCnt++;
                        continue;
                    }


                    //if (row.ItemArray.GetValue(j) != null)
                    //{
                    if (p_row.ItemArray.GetValue(j).Equals(row.ItemArray.GetValue(j)))
                        cnt++;
                    //}
                }

                if (cnt == p_row.ItemArray.Length - minusCnt) //제외된만큼 빼고 
                {
                    return false;
                }
            }
            return true;
        }
        #endregion 

        #region XSavePerformer
        private class XSavePerformer : ISavePerformer
        {
            private NUR1018R03 parent;

            public XSavePerformer(NUR1018R03 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

                switch (callerID)
                {
                    case '1':

                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO NUR5011
                                                 ( SYS_DATE             , SYS_ID
                                                 , UPD_DATE             , UPD_ID            , HOSP_CODE
                                                 , NUR_WRDT             , NURSE_GRADE       
                                                 , NURSE_ID             , WORK_TYPE         , WORK_TIME)
                                            VALUES 
                                                 ( SYSDATE              , :q_user_id
                                                 , SYSDATE              , :q_user_id        , :f_hosp_code
                                                 , :f_nur_wrdt          , :f_nurse_grade    
                                                 , :f_nurse_id          , :f_work_type      , :f_work_time) ";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR5011
                                               SET UPD_DATE    = SYSDATE
                                                 , UPD_ID      = :q_user_id
                                                 , NURSE_GRADE = :f_nurse_grade
                                                 --, WORK_TYPE   = :f_work_type
                                                 , WORK_TIME   = :f_work_time
                                             WHERE HOSP_CODE   = :f_hosp_code
                                               AND NUR_WRDT    = :f_nur_wrdt
                                               AND NURSE_ID   = :f_nurse_id
                                               AND WORK_TYPE   = :f_work_type";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR5011
                                             WHERE HOSP_CODE  = :f_hosp_code
                                               AND NUR_WRDT   = :f_nur_wrdt
                                               AND NURSE_ID   = :f_nurse_id 
                                               AND WORK_TYPE   = :f_work_type ";
                                break;
                        }

                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"SELECT NVL(MAX(SEQ), 0) + 1
                                              FROM NUR5012
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND COMMENT_DATE = :f_comment_date";
                                object t_seq = Service.ExecuteScalar(cmdText, item.BindVarList);

                                item.BindVarList.Remove("t_seq");

                                if (!TypeCheck.IsNull(t_seq))
                                    item.BindVarList.Add("t_seq", t_seq.ToString());

                                cmdText = @"INSERT INTO NUR5012
                                                 ( SYS_DATE             , SYS_ID
                                                 , UPD_DATE             , UPD_ID            , HOSP_CODE
                                                 , COMMENT_DATE         , REMARK            , SEQ        )
                                            VALUES 
                                                 ( SYSDATE              , :q_user_id
                                                 , SYSDATE              , :q_user_id        , :f_hosp_code
                                                 , :f_comment_date      , :f_comment         , :t_seq     ) ";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE NUR5012
                                               SET UPD_DATE     = SYSDATE
                                                 , UPD_ID       = :q_user_id
                                                 , REMARK       = :f_comment
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND COMMENT_DATE = :f_comment_date
                                               AND SEQ          = :f_seq     ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE FROM NUR5012
                                             WHERE HOSP_CODE    = :f_hosp_code
                                               AND COMMENT_DATE = :f_comment_date
                                               AND SEQ          = :f_seq     ";
                                break;
                        }


                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void layTimeGubun_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layTimeGubun.SetBindVarValue("f_hosp_code", mHospCode);
            this.layTimeGubun.SetBindVarValue("f_date", this.dtpNurWrdt.GetDataValue());

        }

        private void NUR1018R03_Closing(object sender, CancelEventArgs e)
        {
            if (!this.mIsSaveSuccess)
            {
                e.Cancel = true;
            }
        }
    }
}