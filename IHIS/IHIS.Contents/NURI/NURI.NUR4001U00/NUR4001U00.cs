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
    /// NUR0101U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class NUR4001U00 : IHIS.Framework.XScreen
    {
        #region [자동 생성 코드]

        #region 컨트롤 변수

        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel pnlTop;
        private IHIS.Framework.XPanel pnlBottom;
        private IHIS.Framework.XPanel pnlFill;
        private MultiLayout layComboItems;
        private MultiLayoutItem multiLayoutItem1;
        private MultiLayoutItem multiLayoutItem2;
        private XPanel pnlRight;
        private XPanel pnlJin;
        private XEditGrid grdNUR4001;
        private XPanel xPanel1;
        private XLabel xLabel19;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell11;
        private XFindWorker fwkJin;
        private FindColumnInfo findColumnInfo1;
        private FindColumnInfo findColumnInfo2;
        private XPatientBox paBox;
        private MultiLayout layNewNUR4001;
        private XTreeView tvwSelector;
        private XPanel xPanel3;
        private XLabel xLabel2;
        private MultiLayout layNUR4003;
        private XEditGridCell xEditGridCell1;
        private XLabel xLabel3;
        private XDatePicker dtpDate;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private MultiLayoutItem multiLayoutItem3;
        private MultiLayoutItem multiLayoutItem4;
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
        private MultiLayoutItem multiLayoutItem31;
        private XEditGridCell xEditGridCell10;
        private FindColumnInfo findColumnInfo6;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell12;
        private XGridHeader xGridHeader1;
        private XFindWorker fwkNurse;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XEditGridCell xEditGridCell13;
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private MultiLayoutItem multiLayoutItem20;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region 생성자
        public NUR4001U00()
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
            if (disposing)
            {
                if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR4001U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpDate = new IHIS.Framework.XDatePicker();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.pnlJin = new IHIS.Framework.XPanel();
            this.grdNUR4001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.fwkJin = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo6 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xGridHeader1 = new IHIS.Framework.XGridHeader();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xLabel19 = new IHIS.Framework.XLabel();
            this.layComboItems = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.tvwSelector = new IHIS.Framework.XTreeView();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.layNewNUR4001 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem20 = new IHIS.Framework.MultiLayoutItem();
            this.layNUR4003 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
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
            this.multiLayoutItem31 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.pnlJin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4001)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layNewNUR4001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4003)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESEN1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(2, "메모.ico");
            this.ImageList.Images.SetKeyName(3, "sun.gif");
            this.ImageList.Images.SetKeyName(4, "블루볼.gif");
            this.ImageList.Images.SetKeyName(5, "핑크볼.gif");
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
            this.btnList.Location = new System.Drawing.Point(1025, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(406, 32);
            this.btnList.TabIndex = 5;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.xLabel3);
            this.pnlTop.Controls.Add(this.dtpDate);
            this.pnlTop.Controls.Add(this.paBox);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.DrawBorder = true;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1433, 39);
            this.pnlTop.TabIndex = 7;
            // 
            // xLabel3
            // 
            this.xLabel3.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel3.Location = new System.Drawing.Point(3, 8);
            this.xLabel3.Name = "xLabel3";
            this.xLabel3.Size = new System.Drawing.Size(47, 20);
            this.xLabel3.TabIndex = 2;
            this.xLabel3.Text = "基準日";
            this.xLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(56, 8);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(98, 20);
            this.dtpDate.TabIndex = 1;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(160, 3);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.paBox.Size = new System.Drawing.Size(789, 32);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 556);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1433, 34);
            this.pnlBottom.TabIndex = 8;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.pnlJin);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 39);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(950, 517);
            this.pnlFill.TabIndex = 10;
            // 
            // pnlJin
            // 
            this.pnlJin.Controls.Add(this.grdNUR4001);
            this.pnlJin.Controls.Add(this.xPanel1);
            this.pnlJin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJin.Location = new System.Drawing.Point(0, 0);
            this.pnlJin.Name = "pnlJin";
            this.pnlJin.Size = new System.Drawing.Size(950, 517);
            this.pnlJin.TabIndex = 0;
            // 
            // grdNUR4001
            // 
            this.grdNUR4001.AddedHeaderLine = 1;
            this.grdNUR4001.ApplyPaintEventToAllColumn = true;
            this.grdNUR4001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell2,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell11,
            this.xEditGridCell1,
            this.xEditGridCell9,
            this.xEditGridCell12,
            this.xEditGridCell8,
            this.xEditGridCell13,
            this.xEditGridCell10});
            this.grdNUR4001.ColPerLine = 9;
            this.grdNUR4001.Cols = 9;
            this.grdNUR4001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR4001.FixedRows = 2;
            this.grdNUR4001.HeaderHeights.Add(21);
            this.grdNUR4001.HeaderHeights.Add(0);
            this.grdNUR4001.HeaderInfos.AddRange(new IHIS.Framework.XGridHeader[] {
            this.xGridHeader1});
            this.grdNUR4001.Location = new System.Drawing.Point(0, 26);
            this.grdNUR4001.Name = "grdNUR4001";
            this.grdNUR4001.QuerySQL = resources.GetString("grdNUR4001.QuerySQL");
            this.grdNUR4001.Rows = 3;
            this.grdNUR4001.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR4001.Size = new System.Drawing.Size(950, 491);
            this.grdNUR4001.TabIndex = 0;
            this.grdNUR4001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR4001_QueryStarting);
            this.grdNUR4001.GridColumnProtectModify += new IHIS.Framework.GridColumnProtectModifyEventHandler(this.grdNUR4001_GridColumnProtectModify);
            this.grdNUR4001.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdNUR4001_RowFocusChanging);
            this.grdNUR4001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4001_GridColumnChanged);
            this.grdNUR4001.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNUR4001_GridFindSelected);
            this.grdNUR4001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR4001_GridCellPainting);
            this.grdNUR4001.GridButtonClick += new IHIS.Framework.GridButtonClickEventHandler(this.grdNUR4001_GridButtonClick);
            this.grdNUR4001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR4001_RowFocusChanged);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "pknur4001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "pknur4001";
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "fkinp1001";
            this.xEditGridCell6.Col = -1;
            this.xEditGridCell6.HeaderText = "fkinp1001";
            this.xEditGridCell6.IsVisible = false;
            this.xEditGridCell6.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bunho";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.HeaderText = "bunho";
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "nur_plan_jin";
            this.xEditGridCell3.CellWidth = 69;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.EnableEdit = false;
            this.xEditGridCell3.FindWorker = this.fwkJin;
            this.xEditGridCell3.HeaderText = "コード";
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkJin
            // 
            this.fwkJin.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2,
            this.findColumnInfo6});
            this.fwkJin.FormText = "診断名選択";
            this.fwkJin.InputSQL = resources.GetString("fwkJin.InputSQL");
            this.fwkJin.SearchImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.fwkJin.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkJin_QueryStarting);
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColName = "nur_plan_jin";
            this.findColumnInfo1.ColWidth = 0;
            this.findColumnInfo1.HeaderText = "コード";
            this.findColumnInfo1.IsVisible = false;
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "nur_plan_jin_name";
            this.findColumnInfo2.ColWidth = 473;
            this.findColumnInfo2.HeaderText = "診断名";
            // 
            // findColumnInfo6
            // 
            this.findColumnInfo6.ColName = "sort_key";
            this.findColumnInfo6.ColWidth = 47;
            this.findColumnInfo6.HeaderText = "順番";
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 100;
            this.xEditGridCell4.CellName = "nur_plan_jin_name";
            this.xEditGridCell4.CellWidth = 342;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.HeaderText = "看護診断";
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "plan_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 77;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.HeaderText = "開始日";
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "end_date";
            this.xEditGridCell11.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.HeaderText = "終了日";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "reser_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 79;
            this.xEditGridCell1.Col = 7;
            this.xEditGridCell1.HeaderText = "評価予定日";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "plan_user";
            this.xEditGridCell9.CellWidth = 63;
            this.xEditGridCell9.Col = 5;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.FindWorker = this.fwkNurse;
            this.xEditGridCell9.HeaderText = "plan_user";
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            this.xEditGridCell9.Row = 1;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkNurse.FormText = "看護師";
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            this.fwkNurse.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkNurse_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo3.ColName = "sabun";
            this.findColumnInfo3.ColWidth = 100;
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo3.HeaderText = "職員No.";
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "sabun_name";
            this.findColumnInfo4.ColWidth = 193;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo4.HeaderText = "職員名";
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "plan_user_name";
            this.xEditGridCell12.Col = 6;
            this.xEditGridCell12.HeaderText = "plan_user_name";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.Row = 1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 2;
            this.xEditGridCell8.CellName = "sort_key";
            this.xEditGridCell8.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell8.CellWidth = 26;
            this.xEditGridCell8.Col = 2;
            this.xEditGridCell8.HeaderText = "#";
            this.xEditGridCell8.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEng;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellLen = 100;
            this.xEditGridCell13.CellName = "purpose";
            this.xEditGridCell13.CellWidth = 156;
            this.xEditGridCell13.Col = 3;
            this.xEditGridCell13.DisplayMemoText = true;
            this.xEditGridCell13.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell13.HeaderText = "目標";
            this.xEditGridCell13.ImeMode = IHIS.Framework.ColumnImeMode.Hiragana;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.ButtonText = "評価";
            this.xEditGridCell10.CellName = "button";
            this.xEditGridCell10.CellWidth = 42;
            this.xEditGridCell10.Col = 8;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.ButtonBox;
            this.xEditGridCell10.HeaderText = "評価";
            this.xEditGridCell10.RowSpan = 2;
            // 
            // xGridHeader1
            // 
            this.xGridHeader1.Col = 5;
            this.xGridHeader1.ColSpan = 2;
            this.xGridHeader1.HeaderText = "作成者";
            this.xGridHeader1.HeaderWidth = 63;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xLabel19);
            this.xPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel1.Location = new System.Drawing.Point(0, 0);
            this.xPanel1.Name = "xPanel1";
            this.xPanel1.Size = new System.Drawing.Size(950, 26);
            this.xPanel1.TabIndex = 1;
            // 
            // xLabel19
            // 
            this.xLabel19.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel19.EdgeRounding = false;
            this.xLabel19.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel19.Location = new System.Drawing.Point(0, 0);
            this.xLabel19.Name = "xLabel19";
            this.xLabel19.Size = new System.Drawing.Size(950, 26);
            this.xLabel19.TabIndex = 10;
            this.xLabel19.Text = "看護診断";
            // 
            // layComboItems
            // 
            this.layComboItems.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2});
            this.layComboItems.QuerySQL = "SELECT NVL(CODE, \' \')      CODE,\r\n       NVL(CODE_NAME, \' \') CODE_NAME\r\n  FROM NU" +
                "R0102\r\n WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = \'WATCH_TEMPLATE\'\r\n OR" +
                "DER BY SORT_KEY";
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "code_type";
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "code_type_name";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tvwSelector);
            this.pnlRight.Controls.Add(this.xPanel3);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(950, 39);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(483, 517);
            this.pnlRight.TabIndex = 11;
            // 
            // tvwSelector
            // 
            this.tvwSelector.CheckBoxes = true;
            this.tvwSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwSelector.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tvwSelector.Indent = 21;
            this.tvwSelector.LabelEdit = true;
            this.tvwSelector.Location = new System.Drawing.Point(0, 26);
            this.tvwSelector.Name = "tvwSelector";
            this.tvwSelector.Size = new System.Drawing.Size(483, 491);
            this.tvwSelector.TabIndex = 6;
            this.tvwSelector.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvwSelector_NodeMouseDoubleClick);
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            this.tvwSelector.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwSelector_AfterLabelEdit);
            this.tvwSelector.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvwSelector_BeforeLabelEdit);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.xPanel3.Location = new System.Drawing.Point(0, 0);
            this.xPanel3.Name = "xPanel3";
            this.xPanel3.Size = new System.Drawing.Size(483, 26);
            this.xPanel3.TabIndex = 4;
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel2.Location = new System.Drawing.Point(0, 0);
            this.xLabel2.Name = "xLabel2";
            this.xLabel2.Size = new System.Drawing.Size(607, 26);
            this.xLabel2.TabIndex = 10;
            this.xLabel2.Text = "看護計画";
            // 
            // layNewNUR4001
            // 
            this.layNewNUR4001.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem18,
            this.multiLayoutItem19,
            this.multiLayoutItem20});
            this.layNewNUR4001.QuerySQL = resources.GetString("layNewNUR4001.QuerySQL");
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "code";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "code_name";
            // 
            // multiLayoutItem20
            // 
            this.multiLayoutItem20.DataName = "sort_key";
            this.multiLayoutItem20.DataType = IHIS.Framework.DataType.Number;
            // 
            // layNUR4003
            // 
            this.layNUR4003.CallerID = '3';
            this.layNUR4003.IncludeUnChangedRowAtSaving = true;
            this.layNUR4003.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem3,
            this.multiLayoutItem4,
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
            this.multiLayoutItem31});
            this.layNUR4003.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.layNUR4003_SaveEnd);
            this.layNUR4003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layPlanInfo_QueryStarting);
            this.layNUR4003.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layPlanInfo_QueryEnd);
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "fknur4001";
            this.multiLayoutItem3.IsUpdItem = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "pknur4003";
            this.multiLayoutItem4.IsUpdItem = true;
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "nur_plan_ote";
            this.multiLayoutItem8.IsUpdItem = true;
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "nur_plan";
            this.multiLayoutItem9.IsUpdItem = true;
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "nur_plan_name";
            this.multiLayoutItem10.IsUpdItem = true;
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "nur4003_vald";
            this.multiLayoutItem11.IsUpdItem = true;
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "pknur4004";
            this.multiLayoutItem12.IsUpdItem = true;
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "nur_plan_detail";
            this.multiLayoutItem13.IsUpdItem = true;
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "nur_plan_dename";
            this.multiLayoutItem14.IsUpdItem = true;
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "nur4004_vald";
            this.multiLayoutItem15.IsUpdItem = true;
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "nur4001_sort";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem16.IsUpdItem = true;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "nur4003_sort";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem17.IsUpdItem = true;
            // 
            // multiLayoutItem31
            // 
            this.multiLayoutItem31.DataName = "nur4004_sort";
            this.multiLayoutItem31.DataType = IHIS.Framework.DataType.Number;
            this.multiLayoutItem31.IsUpdItem = true;
            // 
            // NUR4001U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "NUR4001U00";
            this.Size = new System.Drawing.Size(1433, 590);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NUR4001U00_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR4001U00_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.pnlJin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR4001)).EndInit();
            this.xPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layComboItems)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layNewNUR4001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layNUR4003)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        string mfkinp1001 = "";
        string mpknur4003 = "";


        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // SaveLayout 설정
            //this.SaveLayoutList.Add(grdNUR4001);
            //this.SaveLayoutList.Add(grdNUR4002);
            //this.SaveLayoutList.Add(layNUR4003);

            // 그리드 SavePerformer 설정
            this.grdNUR4001.SavePerformer = new XSavePerformer(this);
            //this.grdNUR4002.SavePerformer = this.grdNUR4001.SavePerformer;
            this.layNUR4003.SavePerformer = this.grdNUR4001.SavePerformer;

            this.dtpDate.SetDataValue(EnvironInfo.GetSysDate());

        }
        #endregion 

        private bool grdNUR4001_Validation()
        {
            for (int i = 0; i < grdNUR4001.RowCount; i++)
            {
                if (grdNUR4001.GetItemString(i, "nur_plan_jin") == "")
                {
                    XMessageBox.Show("看護診断コードを入力してください");

                    PostCallHelper.PostCall(this.SetFocusGridCell, (short)i, 0);
                    return false;
                }

                if (grdNUR4001.GetItemString(i, "plan_date") == "")
                {
                    XMessageBox.Show("開始日を入力してください");
                    //grdNUR4001.SetFocusToItem(i, "valu_date");

                    PostCallHelper.PostCall(this.SetFocusGridCell, (short)i, 4);
                    return false;
                }

                if (grdNUR4001.GetItemString(i, "plan_user") == "")
                {
                    XMessageBox.Show("作成者を入力してください");
                    //grdNUR4001.SetFocusToItem(i, "valuer");
                    PostCallHelper.PostCall(this.SetFocusGridCell, (short)i, 5);
                    return false;
                }
            }
            return true;
        }

        private bool IsExistNUR4005()
        {
            string strCmd = @"SELECT 'Y' 
                                FROM SYS.DUAL
                               WHERE EXISTS(SELECT 'X'
                                              FROM NUR4005 A 
                                             WHERE A.HOSP_CODE    = :f_hosp_code 
                                               AND A.FKNUR4001    = :f_fknur4001)";

            BindVarCollection bindVal = new BindVarCollection();

            bindVal.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVal.Add("f_fknur4001", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));

            object retval = Service.ExecuteScalar(strCmd, bindVal);

            if (retval != null && retval.ToString() == "Y")
            {
                return true;
            }

            return false;
        }


        #region [조회/입력/삭제/초기화 처리 코드]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Delete:

                    if (IsExistNUR4005())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        XMessageBox.Show("評価された看護診断は削除できません。");
                        return;
                    }
                    layNUR4003.Reset();

                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;

                    for (int i = 0; i < grdNUR4001.RowCount; i++)
                    {
                        if (grdNUR4001.GetRowState(i) == DataRowState.Added || grdNUR4001.GetRowState(i) == DataRowState.Modified)
                        {
                            XMessageBox.Show("修正された内容を保存してから追加してください。");
                            return;
                        }
                    }
                    grdNUR4001.InsertRow(-1);

                    break;

                case FunctionType.Query:
                    e.IsBaseCall = false;

                    grdNUR4001.Reset();
                    //grdNUR4002.Reset();
                    layNUR4003.Reset();
                    tvwSelector.Nodes.Clear();

                    grdNUR4001.QueryLayout(false);

                    break;

                case FunctionType.Update:

                    e.IsBaseCall = false;
                                        
                    if (!grdNUR4001_Validation())
                    {
                        e.IsSuccess = false;
                        return;
                    }

                    Service.BeginTransaction();
                    try
                    {
                        if (!grdNUR4001.SaveLayout())
                        {
                            throw new Exception("NUR4001");
                        }
                        //if (!grdNUR4002.SaveLayout())
                        //{
                        //    throw new Exception("NUR4002");
                        //}
                        if (!layNUR4003.SaveLayout())
                        {
                            throw new Exception("NUR4003");
                        }
                    }
                    catch(Exception ex)
                    {
                        switch (ex.Message)
                        {
                            case "NUR4001":
                                XMessageBox.Show("看護診断が保存できませんでした。", "エラー", MessageBoxIcon.Error);
                                break;

                            //case "NUR4002":
                            //    XMessageBox.Show("関連因子が保存できませんでした。", "エラー", MessageBoxIcon.Error);
                            //    break;

                            case "NUR4003":
                                XMessageBox.Show("看護計画が保存できませんでした。", "エラー", MessageBoxIcon.Error);
                                break;
                        }
                        Service.RollbackTransaction();
                    }
                    finally
                    {
                        Service.CommitTransaction();
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion

        private void NUR4005_ScreenOpen()
        {
            if (this.paBox.BunHo == "")
            {
                XMessageBox.Show("患者番号を確認してください");
                return;
            }

            if (grdNUR4001.CurrentRowNumber < 0)
            {
                XMessageBox.Show("評価する看護診断を選択してください。");
                return;
            }

            if (grdNUR4001.GetRowState(grdNUR4001.CurrentRowNumber) == DataRowState.Added)
            {
                XMessageBox.Show("まだ保存されていないため、評価できません。");

                return;
            }
            
            //IXScreen screen = XScreen.FindScreen("NURI", "NUR4005U01");
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("sysid", EnvironInfo.CurrSystemID);
            openParams.Add("screen", this.ScreenID.ToString());
            openParams.Add("bunho", this.paBox.BunHo);
            openParams.Add("fknur4001", this.grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));
            openParams.Add("plan_date", this.grdNUR4001.GetItemDateTime(grdNUR4001.CurrentRowNumber, "plan_date").ToShortDateString());
            openParams.Add("fkinp1001", this.mfkinp1001);

            //if (screen == null)
            //{
                XScreen.OpenScreenWithParam(this, "NURI", "NUR4005U01", ScreenOpenStyle.PopUpFixed, ScreenAlignment.ParentMiddleCenter, openParams);
                btnList.Enabled = false;
            //}
            //else
            //{

            //    screen.Activate();
            //}
        }

        #region [환자정보 Reques/Receive Event]
        /// <summary>
        /// Docking Screen에서 환자정보 변경시 Raise
        /// </summary>
        public override void OnReceiveBunHo(XPatientInfo info)
        {
            if (info != null && !TypeCheck.IsNull(info.BunHo))
            {
                this.paBox.Focus();
                this.paBox.SetPatientID(info.BunHo);
            }
        }
        /// <summary>
        /// 현Screen의 등록번호를 타Screen에 넘긴다
        /// </summary>
        public override XPatientInfo OnRequestBunHo()
        {
            if (!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
            {
                return new XPatientInfo(this.paBox.BunHo.ToString(), "", "", "", this.ScreenName);
            }

            return null;
        }
        #endregion

        private void NUR4001U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {

            string mbxMsg = "";
            string mbxCap = "";

            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(this.ParentForm.Width, rc.Height - 105);

            // Call된 경우
            if (this.OpenParam != null)
            {
                try
                {
                    if (OpenParam.Contains("bunho"))
                    {
                        if (TypeCheck.IsNull(OpenParam["bunho"].ToString().Trim()))
                        {
                            mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                            mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
                            XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            this.paBox.SetPatientID(OpenParam["bunho"].ToString().Trim());
                        }
                    }
                    else
                    {
                        mbxMsg = NetInfo.Language == LangMode.Jr ? "患者番号が有効ではありません。ご確認ください。" : "환자번호가 정확하지않습니다. 확인바랍니다.";
                        mbxCap = NetInfo.Language == LangMode.Jr ? "お知らせ" : "알림";
                        XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
					//https://sofiamedix.atlassian.net/browse/MED-10610
                    //XMessageBox.Show(ex.Message, "");
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
            }
        }

        private void grdNUR4001_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        {
            if (e.ColName == "nur_plan_jin")
            {
                layNewNUR4001.Reset();

                layNewNUR4001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layNewNUR4001.SetBindVarValue("f_nur_plan_bunryu", "00");
                layNewNUR4001.SetBindVarValue("f_nur_plan_jin", e.ReturnValues.GetValue(0).ToString());

                layNewNUR4001.QueryLayout(true);

                if (layNewNUR4001.RowCount != 0)
                {
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "nur_plan_jin_name", layNewNUR4001.GetItemString(0, "code_name"));
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "pknur4001", layNewNUR4001.GetItemString(0, "code"));
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "plan_date", dtpDate.GetDataValue());
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "fkinp1001", mfkinp1001);
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "bunho", paBox.BunHo);

                    int max = 0;
                    for (int i = 0; i < grdNUR4001.RowCount; i++)
                    {
                        if(grdNUR4001.GetItemString(i, "sort_key") != "")
                        {
                            max = max > grdNUR4001.GetItemInt(i, "sort_key") ? max : grdNUR4001.GetItemInt(i, "sort_key");
                        }
                    }
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "sort_key", max+1);
                    //grdNUR4002_NewLoad();

                    layNUR4003.QueryLayout(true);
                    
                    this.AcceptData();  
                    
                    grdNUR4001.SetFocusToItem(e.RowNumber, "nur_plan_jin_name", true);
                }
                else
                {
                    XMessageBox.Show("存在しない診断コードです。");
                    grdNUR4001.SetItemValue(e.RowNumber, "nur_plan_jin", "");
                    grdNUR4001.SetFocusToItem(e.RowNumber, "nur_plan_jin");
                }



                //grdNUR4001.SetItemValue(e.RowNumber, "nur_plan_jin_name", e.ReturnValues.GetValue(1).ToString());
                //grdNUR4001.SetItemValue(e.RowNumber, "pknur4001", GetNewPKKey("NUR4001"));
                //grdNUR4001.SetItemValue(e.RowNumber, "plan_date", dtpDate.GetDataValue());
                //grdNUR4001.SetItemValue(e.RowNumber, "fkinp1001", mfkinp1001);
                //grdNUR4001.SetItemValue(e.RowNumber, "bunho", paBox.BunHo);

                //grdNUR4002_NewLoad();
            }

            else if (e.ColName == "plan_user")
            {
                grdNUR4001.SetItemValue(e.RowNumber, "plan_user_name", e.ReturnValues[1].ToString());
            }
        }

        private void grdNUR4001_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            //grdNUR4002.Reset();
            layNUR4003.Reset();
            tvwSelector.Nodes.Clear();

            layNUR4003.QueryLayout(true);

            //if (grdNUR4001.GetRowState(e.CurrentRow) == DataRowState.Added)
            //{
            //    //grdNUR4002_NewLoad();
            //    layNUR4003.QueryLayout(false);
            //}
            //else
            //{
            //    //grdNUR4002.QueryLayout(false);
            //    layNUR4003.QueryLayout(false);
            //}
        }

        private void grdNUR4001_QueryStarting(object sender, CancelEventArgs e)
        {
            grdNUR4001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNUR4001.SetBindVarValue("f_fkinp1001", mfkinp1001);
        }

        //private void grdNUR4002_NewLoad()
        //{
        //    if (grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "nur_plan_jin") != "")
        //    {
        //        layNewItems.Reset();

        //        layNewItems.QuerySQL = GetlayNewItemsQuery("NUR4002");

        //        layNewItems.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //        layNewItems.SetBindVarValue("f_nur_plan_jin", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "nur_plan_jin"));


        //        layNewItems.QueryLayout(false);

        //        grdNUR4002.Reset();

        //        int rownum = -1;
        //        for (int i = 0; i < layNewItems.RowCount; i++)
        //        {
        //            rownum = grdNUR4002.InsertRow();

        //            grdNUR4002.SetItemValue(rownum, "fknur4001", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));
        //            grdNUR4002.SetItemValue(rownum, "nur_plan_pro", layNewItems.GetItemString(i, "code"));
        //            grdNUR4002.SetItemValue(rownum, "nur_plan_pro_name", layNewItems.GetItemString(i, "code_name"));
        //            grdNUR4002.SetItemValue(rownum, "sort_key", layNewItems.GetItemString(i, "sort_key"));
        //        }

        //    }
        //}

        //private void grdNUR4002_QueryStarting(object sender, CancelEventArgs e)
        //{
        //    grdNUR4002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        //    grdNUR4002.SetBindVarValue("f_fknur4001", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));
        //}

        private void fwkJin_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkJin.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkJin.SetBindVarValue("f_nur_plan_bunryu", "00");
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            BindVarCollection bindVar = new BindVarCollection();
            string strCmd = "SELECT PKINP1001 FROM VW_OCS_INP1001_01 WHERE HOSP_CODE = :f_hosp_code AND BUNHO = :f_bunho";

            bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
            bindVar.Add("f_bunho", paBox.BunHo);


            object retVal = Service.ExecuteScalar(strCmd, bindVar);

            if (retVal != null)
            {
                mfkinp1001 = retVal.ToString();

                btnList.PerformClick(FunctionType.Query);
            }
            else
            {
                XMessageBox.Show("入院中の患者ではありません。もう一度確認してください。");
            }
        }

        private void grdNUR4001_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            //grdNUR4002.Reset();
            this.grdNUR4001.GridColumnChanged -= new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4001_GridColumnChanged);
            if (e.ColName == "nur_plan_jin" && (grdNUR4001.GetItemString(e.RowNumber, e.ColName) != ""))
            {

                layNewNUR4001.Reset();

                layNewNUR4001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                layNewNUR4001.SetBindVarValue("f_nur_plan_bunryu", "00");
                layNewNUR4001.SetBindVarValue("f_nur_plan_jin", e.ChangeValue.ToString());

                layNewNUR4001.QueryLayout(true);
                if (layNewNUR4001.RowCount != 0)
                {
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "nur_plan_jin_name", layNewNUR4001.GetItemString(0, "code_name"));
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "pknur4001", layNewNUR4001.GetItemString(0, "code"));
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "plan_date", dtpDate.GetDataValue());
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "fkinp1001", mfkinp1001);
                    grdNUR4001.SetItemValue(grdNUR4001.CurrentRowNumber, "bunho", paBox.BunHo);

                    //grdNUR4002_NewLoad();

                    layNUR4003.QueryLayout(true);
                }
                else
                {
                    XMessageBox.Show("存在しない診断コードです。");

                    this.grdNUR4001.SetItemValue(e.RowNumber, e.ColName, "");
                    this.grdNUR4001.SetItemValue(e.RowNumber, "nur_plan_jin_name", "");

                    PostCallHelper.PostCall(SetFocusGridCell, (short)e.RowNumber, 0);       
                }
            }

            if (e.ColName == "plan_user")
            {
                BindVarCollection bindVar = new BindVarCollection();
                string strCmd = @"SELECT FN_ADM_LOAD_USER_NM(:f_plan_user, :f_date) FROM SYS.DUAL";

                bindVar.Add("f_plan_user", e.ChangeValue.ToString());
                bindVar.Add("f_date", EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

                object retVar = Service.ExecuteScalar(strCmd, bindVar);

                if (retVar.ToString() == "")
                {
                    XMessageBox.Show("ユーザを検索できませんでした。");
                    
                    grdNUR4001.SetItemValue(e.RowNumber, e.ColName, "");
                    grdNUR4001.SetItemValue(e.RowNumber, "plan_user_name", "");

                    PostCallHelper.PostCall(SetFocusGridCell, (short)e.RowNumber, 5);                    
                }
                else
                {
                    this.grdNUR4001.SetItemValue(e.RowNumber, "plan_user_name", retVar.ToString());
                }
            }
            this.grdNUR4001.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR4001_GridColumnChanged);

        }

        private void SetFocusGridCell(short rowNum, short colNum)
        {
            grdNUR4001.SetFocusToItem(rowNum, colNum);
        }

        private void layPlanInfo_QueryStarting(object sender, CancelEventArgs e)
        {
            if (grdNUR4001.GetRowState(grdNUR4001.CurrentRowNumber) == DataRowState.Added)
            {
                layNUR4003.QuerySQL = @"SELECT :f_fknur4001                               FKNUR4001,
                                               0                                          PKNUR4003,
                                               A.NUR_PLAN_OTE                             NUR_PLAN_OTE,
                                               A.NUR_PLAN                                 NUR_PLAN,
                                               A.NUR_PLAN_NAME                            NUR_PLAN_NAME,
                                               'Y'                                        NUR4003_VALD, 
                                               0                                          PKNUR4004,
                                               NVL(B.NUR_PLAN_DETAIL, 'X')                NUR_PLAN_DETAIL,
                                               B.NUR_PLAN_DENAME                          NUR_PLAN_DENAME,
                                               B.VALD                                     NUR4004_VALD,
                                               DECODE(A.NUR_PLAN_OTE, 'P', '1'
                                                                    , 'O', '2'
                                                                    , 'T', '3'
                                                                    , '4' )               NUR_SORT1,
                                               LTRIM(TO_CHAR(NVL(A.SORT_KEY, 99), '00'))  NUR_SORT2,
                                               LTRIM(TO_CHAR(NVL(B.SORT_KEY, 99), '00'))  NUR_SORT3
                                          FROM NUR0403 A,
                                               NUR0404 B
                                         WHERE A.HOSP_CODE                                       = :f_hosp_code
                                           AND B.HOSP_CODE(+)                                    = A.HOSP_CODE
                                           AND A.NUR_PLAN_JIN                                    = :f_nur_plan_jin
                                        --   AND A.NUR_PLAN_PRO                                    = :f_nur_plan_pro
                                           AND A.FROM_DATE                                      <= SYSDATE
                                           AND NVL(A.END_DATE, TO_DATE('99981231', 'YYYYMMDD')) >= SYSDATE
                                           AND B.NUR_PLAN_JIN(+)                                 = A.NUR_PLAN_JIN
                                           AND B.NUR_PLAN    (+)                                 = A.NUR_PLAN
                                           AND A.VALD          = 'Y'
                                           AND B.VALD(+)       = 'Y'     
                                         ORDER BY 11,12,13";
            }
            else
            {
                layNUR4003.QuerySQL = @"SELECT A.FKNUR4001                                FKNUR4001,
                                               A.PKNUR4003                                PKNUR4003,
                                               A.NUR_PLAN_OTE                             NUR_PLAN_OTE,
                                               A.NUR_PLAN                                 NUR_PLAN,
                                               A.NUR_PLAN_NAME                            NUR_PLAN_NAME,
                                               A.VALD                                     NUR4003_VALD, 
                                               B.PKNUR4004                                PKNUR4004,
                                               NVL(B.NUR_PLAN_DETAIL, 'X')                NUR_PLAN_DETAIL,
                                               B.NUR_PLAN_DENAME                          NUR_PLAN_DENAME,
                                               B.VALD                                     NUR4004_VALD,
                                               DECODE(A.NUR_PLAN_OTE, 'P', '1'
                                                                    , 'O', '2'
                                                                    , 'T', '3'
                                                                    , '4' )               NUR_SORT1,
                                               LTRIM(TO_CHAR(NVL(A.SORT_KEY, 99), '00'))  NUR_SORT2,
                                               LTRIM(TO_CHAR(NVL(B.SORT_KEY, 99), '00'))  NUR_SORT3
                                          FROM NUR4003 A,
                                               NUR4004 B
                                         WHERE A.HOSP_CODE                                       = :f_hosp_code
                                           AND B.HOSP_CODE(+)                                    = A.HOSP_CODE
                                           AND A.FKNUR4001                                       = :f_fknur4001
                                        --   AND A.NUR_PLAN_PRO                                    = :f_nur_plan_pro
                                           AND B.FKNUR4003(+)                                    = A.PKNUR4003
                                         ORDER BY 11,12,13";
            }


            layNUR4003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            layNUR4003.SetBindVarValue("f_nur_plan_jin", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "nur_plan_jin"));
            layNUR4003.SetBindVarValue("f_fknur4001", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));

        }

        private void layPlanInfo_QueryEnd(object sender, QueryEndEventArgs e)
        {
            //this.tvwNUR4003.BeforeSelect -= new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
            this.tvwSelector.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            tvwSelector.Nodes.Clear();
            if (layNUR4003.RowCount < 1) return;

            //Node 단계 check변수
            string nur_plan_ote = "";
            string nur_plan = "";
            TreeNode node;

            int rowcnt = 0;

            foreach (DataRow row in layNUR4003.LayoutTable.Rows)
            {
                if (nur_plan_ote != row["nur_plan_ote"].ToString())
                {
                    if (row["nur_plan_ote"].ToString() == "P")
                        node = new TreeNode("関連因子       ");
                    
                    else if (row["nur_plan_ote"].ToString() == "O")
                        node = new TreeNode("O P - 観察       ");
                    
                    else if (row["nur_plan_ote"].ToString() == "T")
                        node = new TreeNode("T P - ケア       ");
                    
                    else
                        node = new TreeNode("E P - 教育       ");

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "GP");
                    t_tag_table.Add("nur_plan_ote", row["nur_plan_ote"].ToString());
                    t_tag_table.Add("fknur4001", row["fknur4001"].ToString());

                    node.NodeFont = new Font("MS UI Gothic", 11f, FontStyle.Bold);
                    node.Tag = t_tag_table;
                    //node.Checked = true;
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 3;
                    tvwSelector.Nodes.Add(node);
                    nur_plan_ote = row["nur_plan_ote"].ToString();
                    nur_plan = "";
                }

                if (nur_plan != row["nur_plan"].ToString())
                {
                    node = new TreeNode(row["nur_plan_name"].ToString());

                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "P");
                    t_tag_table.Add("nur_plan_ote", nur_plan_ote);
                    t_tag_table.Add("nur_plan", row["nur_plan"].ToString());
                    t_tag_table.Add("pknur4003", row["pknur4003"].ToString());
                    t_tag_table.Add("fknur4001", row["fknur4001"].ToString());
                    t_tag_table.Add("row_cnt", rowcnt);

                    node.NodeFont = new Font("MS UI Gothic", 11f, FontStyle.Regular);
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 4;
                    node.Tag = t_tag_table;

                    if (row["nur4003_vald"].ToString() == "Y")
                    {
                        node.Checked = true;
                        tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].Checked = true;
                    }
                    else
                    {
                        node.Checked = false;
                    }

                    tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].Nodes.Add(node);
                    nur_plan = row["nur_plan"].ToString();
                }


                if (row["nur_plan_detail"].ToString().Trim() != "X")
                {
                    node = new TreeNode(row["nur_plan_dename"].ToString());
                    node.NodeFont = new Font("MS UI Gothic", 10f, FontStyle.Regular);
                    node.SelectedImageIndex = 2;
                    node.ImageIndex = 5;
                    Hashtable t_tag_table = new Hashtable();
                    t_tag_table.Add("added_yn", "N");
                    t_tag_table.Add("tag_gubun", "C");
                    t_tag_table.Add("nur_plan_ote", nur_plan_ote);
                    t_tag_table.Add("nur_plan", nur_plan);
                    t_tag_table.Add("pknur4004", row["pknur4004"].ToString());
                    t_tag_table.Add("nur_plan_detail", row["nur_plan_detail"].ToString());
                    t_tag_table.Add("pknur4003", row["pknur4003"].ToString());
                    t_tag_table.Add("fknur4001", row["fknur4001"].ToString());
                    t_tag_table.Add("row_cnt", rowcnt);

                    node.Tag = t_tag_table;

                    if (row["nur4004_vald"].ToString() == "Y")
                    {
                        node.Checked = true;
                        tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].LastNode.Checked = true;
                    }
                    else
                    {
                        node.Checked = false;
                    }

                    tvwSelector.Nodes[tvwSelector.Nodes.Count - 1].LastNode.Nodes.Add(node);
                }

                rowcnt++;

            }
            tvwSelector.ExpandAll();

            if (this.tvwSelector.Nodes.Count > 0)
            {
                this.tvwSelector.SelectedNode = this.tvwSelector.Nodes[0];
            }
            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            //this.tvwNUR4003.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwNUR4003_BeforeSelect);
        }


        private void ChangeCheck(Hashtable nodeInfo, bool check_yn)
        {
            switch (nodeInfo["tag_gubun"].ToString())
            {
                case "GP":
                //    for (int i = 0; i < layNUR4003.RowCount; i++)
                //    {
                //        layNUR4003.SetItemValue(i, "nur4003_vald", check_yn? "Y" : "N" );
                //    }
                    break;

                case "P":
                    //for (int i = 0; i < layNUR4003.RowCount; i++)
                    //{
                    //    if (layNUR4003.GetItemString(i, "pknur4003") == nodeInfo["pknur4003"].ToString())
                    //    {
                    //        layNUR4003.SetItemValue(i, "nur4003_vald", check_yn ? "Y" : "N");
                    //    }
                    //}

                    layNUR4003.SetItemValue((int)nodeInfo["row_cnt"], "nur4003_vald", check_yn ? "Y" : "N");

                    break;

                case "C":
                    //for (int i = 0; i < layNUR4003.RowCount; i++)
                    //{
                    //    if (layNUR4003.GetItemString(i, "pknur4004") == nodeInfo["pknur4004"].ToString())
                    //    {
                    //        layNUR4003.SetItemValue(i, "nur4004_vald", check_yn ? "Y" : "N");
                    //    }
                    //}

                    layNUR4003.SetItemValue((int)nodeInfo["row_cnt"], "nur4004_vald", check_yn ? "Y" : "N");

                    break;
            }

        }

        private void tvwSelector_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.tvwSelector.AfterCheck -= new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
            TreeNode node = e.Node;

            Hashtable nodeInfo = (Hashtable)node.Tag;

            ChangeCheck(nodeInfo, node.Checked);

            if (node.Checked)
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = true;
                    ChangeCheck((Hashtable)node1.Tag, node1.Checked);

                    //자식이 있다면 자식에도 체크
                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        node2.Checked = true;
                        ChangeCheck((Hashtable)node2.Tag, node2.Checked);
                    }
                }

                //부모가 있다면 부모도 체크
                TreeNode parentNode = node.Parent;
                if (parentNode != null)
                {
                    parentNode.Checked = true;
                    ChangeCheck((Hashtable)parentNode.Tag, parentNode.Checked);

                    TreeNode parentNode2 = parentNode.Parent;

                    if (parentNode2 != null)
                    {
                        parentNode2.Checked = true;
                        ChangeCheck((Hashtable)parentNode2.Tag, parentNode2.Checked);
                    }
                }
            }
            else
            {
                foreach (TreeNode node1 in node.Nodes)
                {
                    node1.Checked = false;
                    ChangeCheck((Hashtable)node1.Tag, node1.Checked);

                    foreach (TreeNode node2 in node1.Nodes)
                    {
                        node2.Checked = false;
                        ChangeCheck((Hashtable)node2.Tag, node2.Checked);
                    }
                }

                //부모가 있다면 부모도 체크품
                TreeNode parentNode = node.Parent;
                if (parentNode != null)
                {
                    bool childSelected = false;

                    foreach (TreeNode childNode in parentNode.Nodes)
                    {
                        if (childNode.Checked)
                            childSelected = true;
                    }

                    if (!childSelected)
                    {
                        parentNode.Checked = false;
                        ChangeCheck((Hashtable)parentNode.Tag, parentNode.Checked);

                        TreeNode parentNode2 = parentNode.Parent;

                        if (parentNode2 != null)
                        {
                            bool parentSelected = false;

                            foreach (TreeNode parent in parentNode2.Nodes)
                            {
                                if (parent.Checked)
                                    parentSelected = true;
                            }

                            if (!parentSelected)
                            {
                                parentNode2.Checked = false;
                                ChangeCheck((Hashtable)parentNode2.Tag, parentNode2.Checked);
                            }
                        }
                    }
                }
            }

            this.tvwSelector.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwSelector_AfterCheck);
        }


        private void ChangeText(Hashtable nodeInfo, string changedText)
        {
            switch (nodeInfo["tag_gubun"].ToString())
            {
                case "P":
                    //for (int i = 0; i < layNUR4003.RowCount; i++)
                    //{
                    //    if (layNUR4003.GetItemString(i, "pknur4003") == nodeInfo["pknur4003"].ToString())
                    //    {
                    //        layNUR4003.SetItemValue(i, "nur_plan_name", changedText);
                    //    }
                    //}

                    layNUR4003.SetItemValue((int)nodeInfo["row_cnt"], "nur_plan_name", changedText);

                    break;

                case "C":
                    //for (int i = 0; i < layNUR4003.RowCount; i++)
                    //{
                    //    if (layNUR4003.GetItemString(i, "pknur4004") == nodeInfo["pknur4004"].ToString())
                    //    {
                    //        layNUR4003.SetItemValue(i, "nur_plan_dename", changedText);
                    //    }
                    //}

                    layNUR4003.SetItemValue((int)nodeInfo["row_cnt"], "nur_plan_dename", changedText);
                    break;
            }

        }
        private void tvwSelector_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null)
                return;

            int maxLength = e.Label.Length;

            // 길이가 짧을 경우에는 원복 시키고, 레이아웃에도 반영하지 않는다.
            if (maxLength < 1)
            {
                e.CancelEdit = true;
                XMessageBox.Show("入力したないようが短過ぎます。[1~100]" + "[" + "現在 : " + maxLength.ToString() + "]");
                return;
            }

            //길이가 초과 할 경우 100 이하로 자르고 레이아웃에 반영한다.
            if (maxLength > 100)
            {
                XMessageBox.Show("入力可能な文字数を超えました。[1~100]" + "[" + "現在 : " + maxLength.ToString() + "]");
                maxLength = 100;
            }


            ChangeText((Hashtable)e.Node.Tag, e.Label.Substring(0, maxLength));
        }

        #region [XSavePerformer]

        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private NUR4001U00 parent = null;

            public XSavePerformer(NUR4001U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";

                object retVal;

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {

                    // 진단명
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO NUR4001
                                                 ( SYS_DATE       , SYS_ID        , UPD_DATE          , UPD_ID            , HOSP_CODE           ,  
                                                   PKNUR4001      , BUNHO         , FKINP1001         , NUR_PLAN_JIN      , NUR_PLAN_JIN_NAME   , 
                                                   PLAN_USER      , PLAN_DATE     , VALD              , SORT_KEY          , END_DATE            ,
                                                   PURPOSE        )
                                                 VALUES
                                                 ( SYSDATE        , :q_user_id    , SYSDATE           , :q_user_id        , :f_hosp_code            ,
                                                   :f_pknur4001   , :f_bunho      , :f_fkinp1001      , :f_nur_plan_jin   , :f_nur_plan_jin_name    ,
                                                   :f_plan_user   , :f_plan_date  , 'Y'               , :f_sort_key       , :f_end_date             ,
                                                   :f_purpose     )";
                                break;

                            case DataRowState.Modified:
                                cmdText = @"UPDATE NUR4001
                                               SET UPD_DATE             = SYSDATE
                                                 , UPD_ID               = :q_user_id
                                                 , NUR_PLAN_JIN         = :f_nur_plan_jin
                                                 , NUR_PLAN_JIN_NAME    = :f_nur_plan_jin_name
                                                 , PLAN_USER            = :f_plan_user
                                                 , PLAN_DATE            = :f_plan_date
                                                 , VALD                 = :f_vald
                                                 , SORT_KEY             = :f_sort_key
                                                 , END_DATE             = :f_end_date
                                                 , PURPOSE              = :f_purpose
                                             WHERE HOSP_CODE = :f_hosp_code
                                               AND PKNUR4001 = :f_pknur4001";
                                break;

                            case DataRowState.Deleted:

//                                cmdText = @"DELETE NUR4003
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND FKNUR4001 = :f_pknur4001";

//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);


//                                cmdText = @"DELETE NUR4002
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND FKNUR4001 = :f_pknur4001";

//                                Service.ExecuteNonQuery(cmdText, item.BindVarList);

//                                cmdText = @"DELETE NUR4001
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND PKNUR4001 = :f_pknur4001";

                                cmdText = @"BEGIN 
                                                    PR_NUR_NUR4001_DELETE(:f_hosp_code, :f_pknur4001);
                                            END;";

                                break;
                        }

                        break;

                    //문제점 리스트
                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO NUR4002 (   SYS_DATE,               SYS_ID,                 UPD_DATE, 
                                                                    PKNUR4002,              NUR_PLAN_PRO,           PLAN_USER, 
                                                                    PLAN_DATE,              VALD,                   NUR_PLAN_PRO_NAME, 
                                                                    HOSP_CODE,              UPD_ID,                 SORT_KEY,           FKNUR4001) 
                                                        VALUES (    SYSDATE,                :q_user_id,             SYSDATE,
                                                                    NUR4002_SEQ.NEXTVAL,    :f_nur_plan_pro,        :q_user_id,
                                                                    :f_plan_date,           'Y',                    :f_nur_plan_pro_name,
                                                                    :f_hosp_code,           :q_user_id,             :f_sort_key,        :f_fknur4001)";
                                break;

                            case DataRowState.Modified:

                                cmdText = @" UPDATE NUR4002
                                                SET    UPD_DATE          = SYSDATE,
                                                       UPD_ID            = :q_user_id,
                                                       NUR_PLAN_PRO      = :f_nur_plan_pro,
                                                       PLAN_USER         = :f_plan_user,
                                                       PLAN_DATE         = :f_plan_date,
                                                       VALD              = :f_vald,
                                                       NUR_PLAN_PRO_NAME = :f_nur_plan_pro_name,
                                                       SORT_KEY          = :f_sort_key
                                                 WHERE HOSP_CODE         = :f_hosp_code
                                                   AND PKNUR4002         = :f_pknur4002";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @" DELETE NUR4002
                                              WHERE HOSP_CODE         = :f_hosp_code
                                                AND PKNUR4002         = :f_pknur4002";
                                break;
                        }
                        break;

                    case '3':

                        ///* NUR4002 신규에 대한 NUR4003건인 경우 */
                        //if (Convert.ToInt32(item.BindVarList["f_fknur4001"].VarValue) == 0)
                        //{
                        //    item.BindVarList.Remove("f_fknur4001");
                        //    item.BindVarList.Add("f_fknur4001", parent.grdNUR4001.GetItemString(parent.grdNUR4001.CurrentRowNumber, "pknur4001"));
                        //}

                        /* NUR4003 신규건 */
                        if (item.BindVarList["f_pknur4003"].VarValue != "" &&
                            Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) == 0) //&& parent.t_nur_plan == item.BindVarList["f_nur_plan"].VarValue)
                        {
                            cmdText = @"SELECT NUR4003_SEQ.NEXTVAL FROM DUAL";

                            retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                            cmdText = "";

                            if (!TypeCheck.IsNull(retVal))
                            {
                                parent.mpknur4003 = retVal.ToString();
                                item.BindVarList.Add("f_pknur4003", parent.mpknur4003);
                            }
                            else
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }

                            cmdText = @"INSERT INTO NUR4003
                                               ( SYS_DATE       , SYS_ID        , UPD_DATE          , UPD_ID        ,
                                                 HOSP_CODE      , PKNUR4003     ,
                                                 FKNUR4001      , NUR_PLAN      , NUR_PLAN_OTE      , NUR_PLAN_NAME,
                                                 SORT_KEY       , VALD          , INPUT_DATE        )
                                         VALUES
                                               ( SYSDATE        , :q_user_id     , SYSDATE          , :q_user_id    , 
                                                 :f_hosp_code   , :f_pknur4003    ,
                                                 :f_fknur4001   , :f_nur_plan    , :f_nur_plan_ote  , :f_nur_plan_name, 
                                                 :f_nur4003_sort, :f_nur4003_vald, TRUNC(SYSDATE))";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                            cmdText = "";
                        }
                        else if (item.BindVarList["f_pknur4003"].VarValue != "" &&
                                 Convert.ToInt32(item.BindVarList["f_pknur4003"].VarValue) != 0) // && parent.t_nur_plan == item.BindVarList["f_nur_plan"].VarValue)
                        {
                            cmdText = @"UPDATE NUR4003
                                           SET UPD_ID        = :q_user_id      ,
                                               UPD_DATE      = SYSDATE         ,
                                               NUR_PLAN_NAME = :f_nur_plan_name, 
                                               VALD          = :f_nur4003_vald
                                         WHERE HOSP_CODE     = :f_hosp_code 
                                           AND PKNUR4003     = :f_pknur4003";

                            if (!Service.ExecuteNonQuery(cmdText, item.BindVarList))
                            {
                                if (Service.ErrFullMsg != "Execute Error(Data does not changed)")
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }
                            }
                            cmdText = "";
                        }

                        //parent.t_nur_plan = item.BindVarList["f_nur_plan"].VarValue;

                        /* NUR4003 신규건에 대한 NUR4004건인 경우*/
                        if (item.BindVarList["f_pknur4004"].VarValue != "")
                        {
                            if (Convert.ToInt32(item.BindVarList["f_pknur4004"].VarValue) == 0)//&& "X" == item.BindVarList["f_nur_plan_detail"].VarValue)
                            {
                                cmdText = @"SELECT NUR4004_SEQ.NEXTVAL FROM DUAL";

                                retVal = Service.ExecuteScalar(cmdText, item.BindVarList);
                                cmdText = "";

                                if (item.BindVarList["f_pknur4003"].VarValue == "")
                                    item.BindVarList.Add("f_pknur4003", parent.mpknur4003);

                                if (!TypeCheck.IsNull(retVal))
                                {
                                    item.BindVarList.Remove("f_pknur4004");
                                    item.BindVarList.Add("f_pknur4004", retVal.ToString());
                                }
                                else
                                {
                                    XMessageBox.Show(Service.ErrFullMsg);
                                    return false;
                                }

                                cmdText = @"INSERT INTO NUR4004
                                           ( SYS_DATE       , SYS_ID         , UPD_DATE       , UPD_ID           ,
                                             HOSP_CODE      , PKNUR4004      ,
                                             FKNUR4003      , NUR_PLAN       , NUR_PLAN_DETAIL, NUR_PLAN_DENAME,
                                             SORT_KEY       , VALD           , INPUT_DATE     )
                                     VALUES
                                           ( SYSDATE        , :q_user_id     , SYSDATE          , :q_user_id     , 
                                             :f_hosp_code   , :f_pknur4004    ,
                                             :f_pknur4003   , :f_nur_plan    , :f_nur_plan_detail, :f_nur_plan_dename,
                                             :f_nur4004_sort, :f_nur4004_vald, TRUNC(SYSDATE))";
                            }
                            else //if ("X" != item.BindVarList["f_nur_plan_detail"].VarValue)
                            {
                                cmdText = @"UPDATE NUR4004
                                           SET UPD_ID          = :q_user_id        ,
                                               UPD_DATE        = SYSDATE           ,
                                               NUR_PLAN_DENAME = :f_nur_plan_dename,
                                               VALD            = :f_nur4004_vald
                                         WHERE HOSP_CODE       = :f_hosp_code 
                                           AND PKNUR4004       = :f_pknur4004";
                            }
                        }
                        else
                        {
                            return true;
                        }

                        break;

                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }

        #endregion

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (grdNUR4001.RowCount == 0)
                    {
                        //grdNUR4002.Reset();
                        layNUR4003.Reset();
                        tvwSelector.Nodes.Clear();
                    }
                    break;

            }
        }

        private void fwkNurse_QueryStarting(object sender, CancelEventArgs e)
        {
            fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
        }

        //private void grdNUR4002_GridFindSelected(object sender, GridFindSelectedEventArgs e)
        //{
        //    if(grdNUR4001.RowCount > 0)
        //    {
        //        grdNUR4002.SetItemValue(grdNUR4002.CurrentRowNumber, "fknur4001", grdNUR4001.GetItemString(grdNUR4001.CurrentRowNumber, "pknur4001"));
        //        grdNUR4002.SetItemValue(grdNUR4002.CurrentRowNumber, "nur_plan_pro", e.ReturnValues.GetValue(0).ToString());
        //        grdNUR4002.SetItemValue(grdNUR4002.CurrentRowNumber, "nur_plan_pro_name", e.ReturnValues.GetValue(1).ToString());
        //        grdNUR4002.SetItemValue(grdNUR4002.CurrentRowNumber, "sort_key", e.ReturnValues.GetValue(2).ToString());

        //    }
        //}


        private void grdNUR4001_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            NUR4005_ScreenOpen();
        }

        private void grdNUR4001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            grdNUR4001.ChangeButtonText("button", e.RowNumber, "評価");

            if (grdNUR4001.GetItemString(e.RowNumber, "reser_date") != "")
            {
                if (DateTime.Parse(grdNUR4001.GetItemString(e.RowNumber, "reser_date")) == DateTime.Parse(dtpDate.GetDataValue()))
                {
                    e.BackColor = Color.LightSkyBlue;

                    grdNUR4001.ChangeButtonSheme("button", e.RowNumber, XButtonSchemes.Blue);
                }
                else if (DateTime.Parse(grdNUR4001.GetItemString(e.RowNumber, "reser_date")) < DateTime.Parse(dtpDate.GetDataValue()))
                {
                    e.BackColor = Color.LightPink;

                    grdNUR4001.ChangeButtonSheme("button", e.RowNumber, XButtonSchemes.HotPink);
                }
            }

            if (grdNUR4001.GetItemString(e.RowNumber, "end_date") != "")
            {
                if (DateTime.Parse(grdNUR4001.GetItemString(e.RowNumber, "end_date")) <= DateTime.Parse(dtpDate.GetDataValue()))
                {
                    e.BackColor = Color.LightGreen;

                    grdNUR4001.ChangeButtonSheme("button", e.RowNumber, XButtonSchemes.Silver);
                    grdNUR4001.ChangeButtonText("button", e.RowNumber, "解決");

                }
            }
        }

        private void grdNUR4001_GridColumnProtectModify(object sender, GridColumnProtectModifyEventArgs e)
        {
            if (e.ColName != "button" && e.ColName != "sort_key")
            {
                if (grdNUR4001.GetItemString(e.RowNumber, "end_date") != "")
                {
                    if (DateTime.Parse(grdNUR4001.GetItemString(e.RowNumber, "end_date")) <= DateTime.Parse(dtpDate.GetDataValue()))
                    {
                        e.Protect = true;
                    }
                    else
                    {
                        e.Protect = false;
                    }
                }
            }
        }

        //private void grdNUR4001_SaveEnd(object sender, SaveEndEventArgs e)
        //{
        //    grdNUR4001.QueryLayout(false);
        //}

        

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "NUR4005U01":
                    btnList.Enabled = true;
                    btnList.PerformClick(FunctionType.Query);
                    break;
            }
            return base.Command(command, commandParam);
        }

        private void tvwSelector_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvwSelector.SelectedNode = e.Node;
            e.Node.BeginEdit();
        }

        private void tvwSelector_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (((Hashtable)e.Node.Tag)["tag_gubun"].ToString() == "GP")
            {
                e.CancelEdit = true;
            }
        }

        private void NUR4001U00_Closing(object sender, CancelEventArgs e)
        {
            IXScreen screen = XScreen.FindScreen("NURI", "NUR4005U01");

            if (screen != null)
            {
                XMessageBox.Show("評価画面を終了してから終了してください。");
                e.Cancel = true;
            }
        }

        private void grdNUR4001_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            bool subChanged = false;

            DataTable dt = layNUR4003.LayoutTable.GetChanges();

            if(dt != null && dt.Rows.Count > 0)
            {
                subChanged = true;
            }

            for (int i = 0; i < layNUR4003.RowCount; i++)   
            {
                if (layNUR4003.GetItemString(i, "pknur4003") == "0")
                {
                    subChanged = true;
                    break;
                }
            }                    

            if (grdNUR4001.GetRowState(e.CurrentRow) == DataRowState.Added)
            {
                if (XMessageBox.Show("変更した内訳があります\n\r保存しますか？", "変更した内訳があります。", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnList.PerformClick(FunctionType.Update);
                }
                else
                {
                    grdNUR4001.RowFocusChanging -= new RowFocusChangingEventHandler(grdNUR4001_RowFocusChanging);
                    grdNUR4001.DeleteRow(e.CurrentRow);
                    grdNUR4001.RowFocusChanging += new RowFocusChangingEventHandler(grdNUR4001_RowFocusChanging);
                }
            }
            else if (grdNUR4001.GetRowState(e.CurrentRow) == DataRowState.Modified || subChanged)
            {
                if (XMessageBox.Show("変更した内訳があります\n\r保存しますか？", "変更した内訳があります。", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnList.PerformClick(FunctionType.Update);
                }
            }

        }

        private void layNUR4003_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                XMessageBox.Show("保存しました。");
            }
            btnList.PerformClick(FunctionType.Query);
        }
    }
}

