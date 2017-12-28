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
	/// NUR8050U00에 대한 요약 설명입니다.
	/// </summary>
	[ToolboxItem(false)]
	public class NUR8050U00 : IHIS.Framework.XScreen
	{
		#region 추가사항
		private string sysid     = string.Empty;
		private string screen    = string.Empty;
		private string FindName = string.Empty;
        private int current_row = 0;
		#endregion

		#region 자동생성
		private IHIS.Framework.XPanel pnlBottom2;
		private IHIS.Framework.XPanel pnlBottom;
		private IHIS.Framework.XEditGridCell xEditGridCell9;
		private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XEditGrid grdNUR8050His;
		private IHIS.Framework.XEditGridCell xEditGridCell1;
		private IHIS.Framework.XEditGridCell xEditGridCell2;
		private IHIS.Framework.XFindWorker fwkNurse;
		private IHIS.Framework.FindColumnInfo findColumnInfo1;
		private IHIS.Framework.FindColumnInfo findColumnInfo2;
		private IHIS.Framework.XButtonList btnList;
		private IHIS.Framework.XEditGridCell xEditGridCell3;
		private IHIS.Framework.XTextBox txtFkinp1001;
		private IHIS.Framework.XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGrid grdNUR8050All;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell18;
        private XPanel pnlBottom1;
        private XPanel pnlFill;
        private XLabel xLabel1;
        private XDictComboBox cboGubun;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XRadioButton rbxGubun;
        private XRadioButton rbxDate;
        private XDWWorker xdwWorker1;
        private XButton btnHisPrint;
        private XButton btnAllPrint;
        private XGroupBox gbxSort;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
		/// <summary>
		/// 필수 디자이너 변수입니다.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region 생성자
		public NUR8050U00()
		{
			// 이 호출은 Windows Form 디자이너에 필요합니다.
			InitializeComponent();

			//저장 수행자 Set
			this.grdNUR8050His.SavePerformer = new XSavePerformer(this);
			//저장 Layout List Set
			this.SaveLayoutList.Add(this.grdNUR8050His);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NUR8050U00));
            this.pnlBottom2 = new IHIS.Framework.XPanel();
            this.gbxSort = new IHIS.Framework.XGroupBox();
            this.rbxDate = new IHIS.Framework.XRadioButton();
            this.rbxGubun = new IHIS.Framework.XRadioButton();
            this.cboGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.txtFkinp1001 = new IHIS.Framework.XTextBox();
            this.paBox = new IHIS.Framework.XPatientBox();
            this.pnlBottom = new IHIS.Framework.XPanel();
            this.btnAllPrint = new IHIS.Framework.XButton();
            this.btnHisPrint = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdNUR8050His = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.fwkNurse = new IHIS.Framework.XFindWorker();
            this.findColumnInfo1 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo2 = new IHIS.Framework.FindColumnInfo();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.grdNUR8050All = new IHIS.Framework.XEditGrid();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom1 = new IHIS.Framework.XPanel();
            this.pnlFill = new IHIS.Framework.XPanel();
            this.xdwWorker1 = new IHIS.Framework.XDWWorker();
            this.pnlBottom2.SuspendLayout();
            this.gbxSort.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8050His)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8050All)).BeginInit();
            this.pnlBottom1.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom2
            // 
            this.pnlBottom2.Controls.Add(this.gbxSort);
            this.pnlBottom2.Controls.Add(this.cboGubun);
            this.pnlBottom2.Controls.Add(this.xLabel1);
            this.pnlBottom2.Controls.Add(this.txtFkinp1001);
            this.pnlBottom2.Controls.Add(this.paBox);
            this.pnlBottom2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom2.DrawBorder = true;
            this.pnlBottom2.Location = new System.Drawing.Point(0, 309);
            this.pnlBottom2.Name = "pnlBottom2";
            this.pnlBottom2.Size = new System.Drawing.Size(1032, 45);
            this.pnlBottom2.TabIndex = 0;
            // 
            // gbxSort
            // 
            this.gbxSort.Controls.Add(this.rbxDate);
            this.gbxSort.Controls.Add(this.rbxGubun);
            this.gbxSort.Location = new System.Drawing.Point(826, 1);
            this.gbxSort.Name = "gbxSort";
            this.gbxSort.Size = new System.Drawing.Size(167, 30);
            this.gbxSort.TabIndex = 6;
            this.gbxSort.TabStop = false;
            // 
            // rbxDate
            // 
            this.rbxDate.AutoSize = true;
            this.rbxDate.Checked = true;
            this.rbxDate.Location = new System.Drawing.Point(11, 8);
            this.rbxDate.Name = "rbxDate";
            this.rbxDate.Size = new System.Drawing.Size(77, 17);
            this.rbxDate.TabIndex = 4;
            this.rbxDate.TabStop = true;
            this.rbxDate.Text = "作成日順";
            this.rbxDate.UseVisualStyleBackColor = true;
            this.rbxDate.CheckedChanged += new System.EventHandler(this.rbxDate_CheckedChanged);
            // 
            // rbxGubun
            // 
            this.rbxGubun.AutoSize = true;
            this.rbxGubun.CheckedValue = "N";
            this.rbxGubun.Location = new System.Drawing.Point(94, 8);
            this.rbxGubun.Name = "rbxGubun";
            this.rbxGubun.Size = new System.Drawing.Size(64, 17);
            this.rbxGubun.TabIndex = 5;
            this.rbxGubun.Text = "区分順";
            this.rbxGubun.UseVisualStyleBackColor = true;
            // 
            // cboGubun
            // 
            this.cboGubun.Location = new System.Drawing.Point(45, 11);
            this.cboGubun.Name = "cboGubun";
            this.cboGubun.Size = new System.Drawing.Size(128, 21);
            this.cboGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboGubun.TabIndex = 3;
            this.cboGubun.UserSQL = resources.GetString("cboGubun.UserSQL");
            this.cboGubun.SelectedIndexChanged += new System.EventHandler(this.cboGubun_SelectedIndexChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.BorderColor = new IHIS.Framework.XColor(System.Drawing.Color.Transparent);
            this.xLabel1.Location = new System.Drawing.Point(3, 11);
            this.xLabel1.Name = "xLabel1";
            this.xLabel1.Size = new System.Drawing.Size(36, 20);
            this.xLabel1.TabIndex = 2;
            this.xLabel1.Text = "区分";
            // 
            // txtFkinp1001
            // 
            this.txtFkinp1001.Location = new System.Drawing.Point(401, 12);
            this.txtFkinp1001.Name = "txtFkinp1001";
            this.txtFkinp1001.Size = new System.Drawing.Size(80, 20);
            this.txtFkinp1001.TabIndex = 1;
            this.txtFkinp1001.Visible = false;
            // 
            // paBox
            // 
            this.paBox.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paBox.Location = new System.Drawing.Point(179, 5);
            this.paBox.Name = "paBox";
            this.paBox.Padding = new System.Windows.Forms.Padding(0, 5, 0, 4);
            this.paBox.Size = new System.Drawing.Size(640, 29);
            this.paBox.TabIndex = 0;
            this.paBox.PatientSelectionFailed += new System.EventHandler(this.paBox_PatientSelectionFailed);
            this.paBox.PatientSelected += new System.EventHandler(this.paBox_PatientSelected);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAllPrint);
            this.pnlBottom.Controls.Add(this.btnHisPrint);
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.DrawBorder = true;
            this.pnlBottom.Location = new System.Drawing.Point(0, 606);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1032, 35);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnAllPrint
            // 
            this.btnAllPrint.Location = new System.Drawing.Point(333, 1);
            this.btnAllPrint.Name = "btnAllPrint";
            this.btnAllPrint.Size = new System.Drawing.Size(140, 30);
            this.btnAllPrint.TabIndex = 2;
            this.btnAllPrint.Text = "ADLワークシート印刷";
            this.btnAllPrint.Click += new System.EventHandler(this.btnAllPrint_Click);
            // 
            // btnHisPrint
            // 
            this.btnHisPrint.Location = new System.Drawing.Point(478, 1);
            this.btnHisPrint.Name = "btnHisPrint";
            this.btnHisPrint.Size = new System.Drawing.Size(140, 30);
            this.btnHisPrint.TabIndex = 1;
            this.btnHisPrint.Text = "患者ADL履歴印刷";
            this.btnHisPrint.Click += new System.EventHandler(this.btnHisPrint_Click);
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
            this.btnList.Location = new System.Drawing.Point(624, 0);
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.Size = new System.Drawing.Size(406, 33);
            this.btnList.TabIndex = 0;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdNUR8050His
            // 
            this.grdNUR8050His.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell17,
            this.xEditGridCell2,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell9,
            this.xEditGridCell3,
            this.xEditGridCell19,
            this.xEditGridCell20});
            this.grdNUR8050His.ColPerLine = 9;
            this.grdNUR8050His.Cols = 10;
            this.grdNUR8050His.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR8050His.FixedCols = 1;
            this.grdNUR8050His.FixedRows = 1;
            this.grdNUR8050His.FocusColumnName = "gubun";
            this.grdNUR8050His.HeaderHeights.Add(21);
            this.grdNUR8050His.Location = new System.Drawing.Point(0, 0);
            this.grdNUR8050His.Name = "grdNUR8050His";
            this.grdNUR8050His.QuerySQL = resources.GetString("grdNUR8050His.QuerySQL");
            this.grdNUR8050His.RowHeaderDrawMode = IHIS.Framework.XCellDrawMode.Vertical;
            this.grdNUR8050His.RowHeaderVisible = true;
            this.grdNUR8050His.Rows = 2;
            this.grdNUR8050His.Size = new System.Drawing.Size(1032, 252);
            this.grdNUR8050His.TabIndex = 12;
            this.grdNUR8050His.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdNUR8050His_ItemValueChanging);
            this.grdNUR8050His.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR8050His_QueryStarting);
            this.grdNUR8050His.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdNUR8050His_GridColumnChanged);
            this.grdNUR8050His.GridFindSelected += new IHIS.Framework.GridFindSelectedEventHandler(this.grdNUR8050His_GridFindSelected);
            this.grdNUR8050His.SaveEnd += new IHIS.Framework.SaveEndEventHandler(this.grdNUR8050His_SaveEnd);
            this.grdNUR8050His.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdNUR8050His_GridFindClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "bunho";
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.HeaderText = "患者番号";
            this.xEditGridCell1.IsReadOnly = true;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "suname";
            this.xEditGridCell17.CellWidth = 129;
            this.xEditGridCell17.Col = 2;
            this.xEditGridCell17.HeaderText = "患者名";
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.IsUpdCol = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "fkinp1001";
            this.xEditGridCell2.Col = -1;
            this.xEditGridCell2.HeaderText = "入院キー";
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.IsVisible = false;
            this.xEditGridCell2.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "gubun";
            this.xEditGridCell4.CellWidth = 81;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.HeaderText = "　区分";
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell4.UserSQL = "SELECT A.CODE, A.CODE_NAME\r\n  FROM NUR0102 A\r\n WHERE A.HOSP_CODE = FN_ADM_LOAD_HO" +
                "SP_CODE()\r\n   AND A.CODE_TYPE = \'ADL_WORK_GUBUN\'\r\n ORDER BY A.SORT_KEY";
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 250;
            this.xEditGridCell5.CellName = "detail";
            this.xEditGridCell5.CellWidth = 144;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.DisplayMemoText = true;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell5.HeaderText = "内容";
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "write_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 112;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell6.HeaderText = "作成日";
            this.xEditGridCell6.IsUpdatable = false;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellLen = 8;
            this.xEditGridCell9.CellName = "write_user";
            this.xEditGridCell9.CellWidth = 95;
            this.xEditGridCell9.Col = 6;
            this.xEditGridCell9.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell9.FindWorker = this.fwkNurse;
            this.xEditGridCell9.HeaderText = "作成者ID";
            this.xEditGridCell9.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkNurse
            // 
            this.fwkNurse.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo1,
            this.findColumnInfo2});
            this.fwkNurse.FormText = "看護師";
            this.fwkNurse.InputSQL = resources.GetString("fwkNurse.InputSQL");
            // 
            // findColumnInfo1
            // 
            this.findColumnInfo1.ColAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.findColumnInfo1.ColName = "sabun";
            this.findColumnInfo1.ColWidth = 100;
            this.findColumnInfo1.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo1.HeaderText = "職員No.";
            // 
            // findColumnInfo2
            // 
            this.findColumnInfo2.ColName = "sabun_name";
            this.findColumnInfo2.ColWidth = 193;
            this.findColumnInfo2.FilterType = IHIS.Framework.FilterType.InitYes;
            this.findColumnInfo2.HeaderText = "職員名";
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "write_user_name";
            this.xEditGridCell3.CellWidth = 126;
            this.xEditGridCell3.Col = 7;
            this.xEditGridCell3.HeaderText = "作成者";
            this.xEditGridCell3.IsReadOnly = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.IsUpdCol = false;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "confirm_user";
            this.xEditGridCell19.CellWidth = 95;
            this.xEditGridCell19.Col = 8;
            this.xEditGridCell19.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell19.FindWorker = this.fwkNurse;
            this.xEditGridCell19.HeaderText = "確認者ID";
            this.xEditGridCell19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "confirm_user_name";
            this.xEditGridCell20.CellWidth = 126;
            this.xEditGridCell20.Col = 9;
            this.xEditGridCell20.HeaderText = "確認者";
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.IsUpdCol = false;
            this.xEditGridCell20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdNUR8050All
            // 
            this.grdNUR8050All.ApplyAutoHeight = true;
            this.grdNUR8050All.ApplyPaintEventToAllColumn = true;
            this.grdNUR8050All.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell18,
            this.xEditGridCell7,
            this.xEditGridCell16,
            this.xEditGridCell8,
            this.xEditGridCell10,
            this.xEditGridCell21,
            this.xEditGridCell11,
            this.xEditGridCell22,
            this.xEditGridCell12,
            this.xEditGridCell23,
            this.xEditGridCell13,
            this.xEditGridCell24,
            this.xEditGridCell14,
            this.xEditGridCell25,
            this.xEditGridCell15,
            this.xEditGridCell26});
            this.grdNUR8050All.ColPerLine = 9;
            this.grdNUR8050All.Cols = 9;
            this.grdNUR8050All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNUR8050All.FixedRows = 1;
            this.grdNUR8050All.HeaderHeights.Add(21);
            this.grdNUR8050All.Location = new System.Drawing.Point(0, 0);
            this.grdNUR8050All.Name = "grdNUR8050All";
            this.grdNUR8050All.QuerySQL = resources.GetString("grdNUR8050All.QuerySQL");
            this.grdNUR8050All.ReadOnly = true;
            this.grdNUR8050All.RowResizable = true;
            this.grdNUR8050All.Rows = 2;
            this.grdNUR8050All.SelectionMode = IHIS.Framework.XGridSelectionMode.Cell;
            this.grdNUR8050All.Size = new System.Drawing.Size(1032, 309);
            this.grdNUR8050All.TabIndex = 13;
            this.grdNUR8050All.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdNUR8050All_QueryEnd);
            this.grdNUR8050All.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdNUR8050All_QueryStarting);
            this.grdNUR8050All.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.grdNUR8050All_GridCellPainting);
            this.grdNUR8050All.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdNUR8050All_RowFocusChanged);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "ho_bed";
            this.xEditGridCell18.CellWidth = 70;
            this.xEditGridCell18.HeaderText = "部屋番号";
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "bunho";
            this.xEditGridCell7.CellWidth = 77;
            this.xEditGridCell7.Col = 1;
            this.xEditGridCell7.HeaderText = "患者番号";
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "suname";
            this.xEditGridCell16.CellWidth = 100;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.HeaderText = "患者名";
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "fkinp1001";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.HeaderText = "入院キー";
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.IsUpdCol = false;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "gubun1";
            this.xEditGridCell10.CellWidth = 128;
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.HeaderText = "食事";
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "gubun1_date";
            this.xEditGridCell21.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell21.Col = -1;
            this.xEditGridCell21.HeaderText = "gubun1_date";
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.IsUpdCol = false;
            this.xEditGridCell21.IsVisible = false;
            this.xEditGridCell21.Row = -1;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "gubun2";
            this.xEditGridCell11.CellWidth = 128;
            this.xEditGridCell11.Col = 4;
            this.xEditGridCell11.HeaderText = "排泄";
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.IsUpdatable = false;
            this.xEditGridCell11.IsUpdCol = false;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "gubun2_date";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell22.Col = -1;
            this.xEditGridCell22.HeaderText = "gubun2_date";
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.IsUpdCol = false;
            this.xEditGridCell22.IsVisible = false;
            this.xEditGridCell22.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "gubun3";
            this.xEditGridCell12.CellWidth = 128;
            this.xEditGridCell12.Col = 5;
            this.xEditGridCell12.HeaderText = "清潔";
            this.xEditGridCell12.IsReadOnly = true;
            this.xEditGridCell12.IsUpdatable = false;
            this.xEditGridCell12.IsUpdCol = false;
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.CellName = "gubun3_date";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.HeaderText = "gubun3_date";
            this.xEditGridCell23.IsReadOnly = true;
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsUpdCol = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "gubun4";
            this.xEditGridCell13.CellWidth = 128;
            this.xEditGridCell13.Col = 6;
            this.xEditGridCell13.HeaderText = "移乗";
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.IsUpdatable = false;
            this.xEditGridCell13.IsUpdCol = false;
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.CellName = "gubun4_date";
            this.xEditGridCell24.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.HeaderText = "gubun4_date";
            this.xEditGridCell24.IsReadOnly = true;
            this.xEditGridCell24.IsUpdatable = false;
            this.xEditGridCell24.IsUpdCol = false;
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "gubun5";
            this.xEditGridCell14.CellWidth = 128;
            this.xEditGridCell14.Col = 7;
            this.xEditGridCell14.HeaderText = "移動";
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.IsUpdCol = false;
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.CellName = "gubun5_date";
            this.xEditGridCell25.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.HeaderText = "gubun5_date";
            this.xEditGridCell25.IsReadOnly = true;
            this.xEditGridCell25.IsUpdatable = false;
            this.xEditGridCell25.IsUpdCol = false;
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "gubun6";
            this.xEditGridCell15.CellWidth = 128;
            this.xEditGridCell15.Col = 8;
            this.xEditGridCell15.HeaderText = "その他";
            this.xEditGridCell15.IsReadOnly = true;
            this.xEditGridCell15.IsUpdatable = false;
            this.xEditGridCell15.IsUpdCol = false;
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.CellName = "gubun6_date";
            this.xEditGridCell26.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.HeaderText = "gubun6_date";
            this.xEditGridCell26.IsReadOnly = true;
            this.xEditGridCell26.IsUpdatable = false;
            this.xEditGridCell26.IsUpdCol = false;
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            // 
            // pnlBottom1
            // 
            this.pnlBottom1.Controls.Add(this.grdNUR8050His);
            this.pnlBottom1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom1.Location = new System.Drawing.Point(0, 354);
            this.pnlBottom1.Name = "pnlBottom1";
            this.pnlBottom1.Size = new System.Drawing.Size(1032, 252);
            this.pnlBottom1.TabIndex = 14;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.grdNUR8050All);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(1032, 309);
            this.pnlFill.TabIndex = 15;
            // 
            // xdwWorker1
            // 
            this.xdwWorker1.LibraryList = "";
            // 
            // NUR8050U00
            // 
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom2);
            this.Controls.Add(this.pnlBottom1);
            this.Controls.Add(this.pnlBottom);
            this.Name = "NUR8050U00";
            this.Size = new System.Drawing.Size(1032, 641);
            this.Load += new System.EventHandler(this.NUR8050U00_Load);
            this.UserChanged += new System.EventHandler(this.NUR8050U00_UserChanged);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.NUR8050U00_ScreenOpen);
            this.pnlBottom2.ResumeLayout(false);
            this.pnlBottom2.PerformLayout();
            this.gbxSort.ResumeLayout(false);
            this.gbxSort.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8050His)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNUR8050All)).EndInit();
            this.pnlBottom1.ResumeLayout(false);
            this.pnlFill.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 메세지 일괄 처리
		/// </summary>
		/// <param name="aMesgGubun">
		/// 메세지 구분
		/// </param>
		#region 메세지처리
		private void GetMessage(string aMesgGubun)
		{
			string msg = string.Empty;
			string caption = string.Empty;
			
			switch(aMesgGubun)
			{
				case "jeawonYn":
					msg = (NetInfo.Language == LangMode.Ko ? "재원중인 환자가 아닙니다." + " 환자번호를 확인해 주세요"
						: "在院中の患者ではありません。患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "bunho":
					msg = (NetInfo.Language == LangMode.Ko ? " 환자번호를 확인해 주세요"
						: "患者番号を確認してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "query":
					msg = (NetInfo.Language == LangMode.Ko ? "조회실패."
						: "照会失敗。");
					caption = (NetInfo.Language == LangMode.Ko ? "Error"
						: "エラー");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
                    break;
                case "gubun":
                    msg = (NetInfo.Language == LangMode.Ko ? "ADL 구분을 입력해 주세요"
                        : "ADLの区分を入力してください。");
                    caption = (NetInfo.Language == LangMode.Ko ? "알림"
                        : "お知らせ");
                    XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
                    break;
				case "write_user":
					msg = (NetInfo.Language == LangMode.Ko ? "작성자의 ID를 입력해 주세요."
						: "作成者のIDを入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "write_date":
					msg = (NetInfo.Language == LangMode.Ko ? "작성일을 입력해 주세요."
						: "作成日を入力してください。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "validation_chk":
					msg = (NetInfo.Language == LangMode.Ko ? "이미 같은 날짜에 같은내용이 등록 되어 있습니다."
						: "既に同じ日付に同じ内容が登録されています。");
					caption = (NetInfo.Language == LangMode.Ko ? "알림"
						: "お知らせ");
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_true":
					msg = NetInfo.Language == LangMode.Ko ? "보존했습니다."
						: "保存しました。";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "お知らせ";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Information);
					break;
				case "save_false":
					msg = NetInfo.Language == LangMode.Ko ? "저장 실패하였습니다. 확인바랍니다." 
						: "保存に失敗しました。ご確認ください。";
                    msg += "\r\n[" + Service.ErrFullMsg + "]";
					caption = NetInfo.Language == LangMode.Ko ? "알림" 
						: "エラー";
					XMessageBox.Show(msg, caption, MessageBoxIcon.Error);
					break;
				default:
					break;
			}
		}
		#endregion

		/// <summary>
		/// 환자번호로 입원키를 찾는다.
		/// </summary>
		#region 환자의 입원키를 찾는다.
		private void GetFkinp1001()
		{
			try
			{
                string cmdText = @"SELECT PKINP1001
                                     FROM VW_OCS_INP1001_01
                                    WHERE HOSP_CODE            = :f_hosp_code 
                                      AND NVL(CANCEL_YN,'N')   = 'N'
                                      AND NVL(JAEWON_FLAG,'N') = 'Y'
                                      AND BUNHO                = :f_bunho";

                BindVarCollection bindVars = new BindVarCollection();
                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
				bindVars.Add("f_bunho", paBox.BunHo.Trim());
				
                object retVal = Service.ExecuteScalar(cmdText, bindVars);

				if(TypeCheck.IsNull(retVal))
				{
					GetMessage("jeawonYn");
					grdNUR8050His.Enabled = false;
					paBox.Focus();
					return;
				}
				else
				{
					grdNUR8050His.Enabled = true;

					txtFkinp1001.SetDataValue(retVal.ToString());

					if(!grdNUR8050His.QueryLayout(false))
					{
						XMessageBox.Show(Service.ErrFullMsg + "\n\r" + Service.ErrCode);
					}
				}
			}
			catch(Exception ex)
			{
				//https://sofiamedix.atlassian.net/browse/MED-10610
				//XMessageBox.Show(ex.Message + "\n\r" + ex.StackTrace);
				return;
			}
		}
		#endregion

		#region Screen Load
		private void NUR8050U00_Load(object sender, System.EventArgs e)
		{
            //this.CurrMSLayout = this.grdNUR8050His;
            //this.CurrMQLayout = this.grdNUR8050His;

            //if (this.OpenParam != null)
            //{
            //    this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
            //}
            //else
            //{
            //    //현재스크린 환자번호
            //    XPatientInfo patientInfo = XScreen.GetPreviousScreenBunHo(true);
            //    if (patientInfo != null)
            //    {
            //        this.paBox.SetPatientID(patientInfo.BunHo);
            //    }
            //}
		}
		#endregion

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

		#region 그리드의 파인드박스에서 선택을 했을 때
		private void grdNUR8050His_GridFindSelected(object sender, IHIS.Framework.GridFindSelectedEventArgs e)
		{
            if (e.ColName == "write_user")
            {
                this.grdNUR8050His.SetItemValue(e.RowNumber, "write_user_name", e.ReturnValues[1]);
            }
            else if (e.ColName == "confirm_user")
            {
                this.grdNUR8050His.SetItemValue(e.RowNumber, "confirm_user_name", e.ReturnValues[1]);
            }
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭을 했을 때
		private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
                    e.IsBaseCall = false;

					if(!this.AcceptData())
					{
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "" || this.txtFkinp1001.GetDataValue() == "")
					{
                        e.IsSuccess = false;

						this.GetMessage("bunho");
					}

                    grdNUR8050His.InsertRow();

					
					break;
				case FunctionType.Query:
					if(!this.AcceptData())
					{
						e.IsBaseCall = false;
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						e.IsBaseCall = false;
						//this.GetMessage("bunho");
						return;
					}

                    current_row = 0;

					break;
				case FunctionType.Update:

                    e.IsBaseCall = false; 

					if(!this.AcceptData())
					{
						e.IsSuccess = false;
					}

					if(this.paBox.BunHo.ToString() == "")
					{
						this.GetMessage("bunho");
						this.paBox.Focus();
						return;
					}

					if(this.grdNUR8050His.RowCount > 0)
					{
						for(int i = 0; i < this.grdNUR8050His.RowCount; i++)
						{
                            if (this.grdNUR8050His.GetItemString(i, "gubun") == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("gubun");
                                this.grdNUR8050His.SetFocusToItem(i, "gubun");
                                return;
                            }
                            else if (this.grdNUR8050His.GetItemString(i, "write_date") == "")
                            {
                                e.IsBaseCall = false;
                                this.GetMessage("write_date");
                                this.grdNUR8050His.SetFocusToItem(i, "write_date");
                                return;
                            }
							else if(this.grdNUR8050His.GetItemString(i, "write_user") == "")
							{
                                e.IsBaseCall = false;
                                this.GetMessage("write_user");
                                this.grdNUR8050His.SetFocusToItem(i, "write_user");
								return;
							}
						}              
					}

                    current_row = grdNUR8050All.CurrentRowNumber;

                    // grdNUR8050His 저장처리 호출
                    if (!grdNUR8050His.SaveLayout())
                    {
                        XMessageBox.Show(Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        return;
                    }

                    XMessageBox.Show("保存しました。", "保存", MessageBoxIcon.Information);      
					break;
				
                case FunctionType.Delete:
                    e.IsBaseCall = false;

                    grdNUR8050His.DeleteRow();

                    break;

				default:
					break;
			}
		}
		#endregion

		#region 환자번호를 입력을 했을 때
		private void paBox_PatientSelected(object sender, System.EventArgs e)
		{
			this.grdNUR8050His.Reset();
			if(!TypeCheck.IsNull(this.paBox.BunHo.ToString()))
			{
				this.GetFkinp1001();
			}
		}
		#endregion

		#region 버튼리스트에서 버튼을 클릭 한 후의 이벤트
		private void btnList_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
		{
			switch(e.Func)
			{
				case FunctionType.Insert:
					if(this.paBox.BunHo.ToString() != "")
					{
						if(this.grdNUR8050His.RowCount > 0)
						{
							if(this.grdNUR8050His.CurrentRowNumber >= 0)
							{
								this.grdNUR8050His.SetItemValue(this.grdNUR8050His.CurrentRowNumber, "bunho", this.paBox.BunHo.Trim());
                                this.grdNUR8050His.SetItemValue(this.grdNUR8050His.CurrentRowNumber, "suname", this.paBox.SuName);
								this.grdNUR8050His.SetItemValue(this.grdNUR8050His.CurrentRowNumber, "fkinp1001", this.txtFkinp1001.GetDataValue());
								this.grdNUR8050His.SetItemValue(this.grdNUR8050His.CurrentRowNumber,"write_date",
									IHIS.Framework.EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
							}
						}
					}
					break;
				default:
					break;
			}
		}
		#endregion

//        #region 중복체크 및 간호사이름 로드
//        private void grdNUR8050His_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
//        {
            
//            DataRowState rowState = this.grdNUR8050His.LayoutTable.Rows[e.RowNumber].RowState;

//            string cmdText = @"SELECT 'Y'
//								 FROM NUR8050
//							    WHERE HOSP_CODE     = :f_hosp_code 
//                                  AND BUNHO         = :f_bunho
//								  AND FKINP1001     = :f_fkinp1001
//								  AND JUKYONG_DATE  = :f_jukyong_date";

//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_hosp_code",     EnvironInfo.HospCode);
//            bindVars.Add("f_bunho",			grdNUR8050His.GetItemString(e.RowNumber, "bunho"));
//            bindVars.Add("f_fkinp1001",		grdNUR8050His.GetItemString(e.RowNumber, "fkinp1001"));
//            bindVars.Add("f_jukyong_date",	grdNUR8050His.GetItemString(e.RowNumber, "jukyong_date"));

//            object retVal = Service.ExecuteScalar(cmdText, bindVars);

//            switch(e.ColName)
//            {
//                case "write_date":
//                case "write_user":
//                    if(rowState == DataRowState.Added)
//                    {
//                        if(!TypeCheck.IsNull(retVal))
//                        {
//                            /* 이미 입력이 되있는 컬럼이면 'Y', 아니면 'N'을 셋팅한다. */
//                            if (retVal.ToString().Equals("Y"))
//                            {
//                                if (e.ColName.Equals("jukyong_date"))
//                                {
//                                    e.Cancel = true;
//                                }
//                                GetMessage("validation_chk");
//                                return;
//                            }
//                        }
//                        else
//                        {
//                            bindVars.Clear();
//                            cmdText = "SELECT FN_ADM_LOAD_USER_NAME(:f_user_id) FROM DUAL";
//                            bindVars.Add("f_user_id", grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "damdang_nurse"));
//                            retVal = Service.ExecuteScalar(cmdText, bindVars);
//                            if (retVal.ToString()!="")
//                            {
//                                grdNUR8050His.SetItemValue(grdNUR8050His.CurrentRowNumber, "damdang_nurse_name", retVal.ToString());
//                            }
//                            else
//                            {
//                                XMessageBox.Show("入力された担当看護師の番号を見つけませんでした。");
//                                e.Cancel = true;
//                            }
//                        }
//                    }

//                    break;
//                default:
//                    break;
//            }
//        }
//        #endregion

		#region 팝업화면으로 오픈이 됐을 때
		private void NUR8050U00_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
		{
            Rectangle rc = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.ParentForm.Size = new System.Drawing.Size(ParentForm.Width, rc.Height - 105);

            if (e.OpenParam != null)
			{
				this.sysid      = OpenParam["sysid"].ToString();
				this.screen     = OpenParam["screen"].ToString();
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
			}

            cboGubun.SelectedIndex = 0;

            grdNUR8050All.QueryLayout(false);
            grdNUR8050His.QueryLayout(false);
		}
		#endregion

		#region 등록번호를 잘못 입력을 했을 때
		private void paBox_PatientSelectionFailed(object sender, System.EventArgs e)
		{
			this.grdNUR8050His.Reset();
		}
		#endregion

		#region 사용자변경이 있을 때
		private void NUR8050U00_UserChanged(object sender, System.EventArgs e)
		{
			this.grdNUR8050His.Reset();

			this.CurrMQLayout = this.grdNUR8050His;
			this.CurrMSLayout = this.grdNUR8050His;

			if (this.OpenParam != null)
			{
				this.paBox.SetPatientID(this.OpenParam["bunho"].ToString());
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
		#endregion

		#region vsvValidationChk 맵핑
		private void grdNUR8050His_QueryEnd(object sender, IHIS.Framework.QueryEndEventArgs e)
		{
			if(grdNUR8050His.RowCount > 0)
			{
				for(int i=0; i < grdNUR8050His.RowCount; i++)
				{
					string code = grdNUR8050His.GetItemString(i, "write_user");
					if(!TypeCheck.IsNull(code))
					{
						grdNUR8050His.SetItemValue(i, "write_user_name", NurseName(code));
					}
				}
			}
            grdNUR8050His.ResetUpdate();
		}

		private string NurseName(string code)
		{
			string name;

			string cmdText = @"SELECT B.USER_NM 
								 FROM ADM3200 B 
								WHERE B.HOSP_CODE = :f_hosp_code
                                  AND B.DEPT_CODE LIKE '%' 
								  AND SYSDATE <= NVL(B.USER_END_YMD, TO_DATE('99981231', 'YYYY/MM/DD')) 
								  AND B.USER_ID = :f_code 
								  AND B.USER_GUBUN = '2'";
			BindVarCollection bindVars = new BindVarCollection();
            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
			bindVars.Add("f_code", code);

			object retVal = Service.ExecuteScalar(cmdText, bindVars);

			if(!TypeCheck.IsNull(retVal))
			{
				name = Service.ExecuteScalar(cmdText, bindVars).ToString();
			}
			else
			{
				name = "";
			}

			return name;
		}
		#endregion

		#region 해당병동 간호사로드
		private void grdNUR8050His_GridFindClick(object sender, IHIS.Framework.GridFindClickEventArgs e)
		{
            if (e.ColName == "write_user")
            {
                this.fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
                this.fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
                this.fwkNurse.SetBindVarValue("f_sabun", grdNUR8050His.GetItemString(e.RowNumber, e.ColName));
            }
            else if (e.ColName == "confirm_user")
            {
                this.fwkNurse.SetBindVarValue("f_buseo_code", UserInfo.BuseoCode);
                this.fwkNurse.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            }
		}
		#endregion

		#region grdNUR8050His 바인드변수 설정
		private void grdNUR8050His_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdNUR8050His.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdNUR8050His.SetBindVarValue("f_bunho", paBox.BunHo);
			grdNUR8050His.SetBindVarValue("f_fkinp1001", txtFkinp1001.GetDataValue());
            grdNUR8050His.SetBindVarValue("f_gubun", cboGubun.GetDataValue());
		}
		#endregion     

		#region XSavePerformer
		private class XSavePerformer : IHIS.Framework.ISavePerformer
		{
			private NUR8050U00 parent = null;
			public XSavePerformer(NUR8050U00 parent)
			{
				this.parent = parent;
			}
			public bool Execute(char callerID, RowDataItem item)
			{
				string cmdText = "";

                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

				switch (item.RowState)
				{
					case DataRowState.Added:
                        cmdText
                            = @"INSERT INTO NUR8050 (SYS_DATE        , SYS_ID       , UPD_DATE       , UPD_ID      , HOSP_CODE  ,
					    							 BUNHO           , FKINP1001    , GUBUN          ,	DETAIL      , WRITE_DATE ,
                                                     WRITE_USER      , CONFIRM_USER )
							    VALUES              (SYSDATE         , :q_user_id   , SYSDATE        , :q_user_id  , :f_hosp_code, 
								    				 :f_bunho        , :f_fkinp1001 , :f_gubun       , :f_detail   , :f_write_date,
									    			 :f_write_user   , :f_confirm_user )";
						break;
					case DataRowState.Modified:
						cmdText
							= @"UPDATE NUR8050
								   SET UPD_ID        = :q_user_id
									 , UPD_DATE      = SYSDATE
									 , DETAIL        = :f_detail
                                     , WRITE_USER    = :f_write_user
                                     , CONFIRM_USER  = :f_confirm_user
								 WHERE HOSP_CODE     = :f_hosp_code 
                                   AND BUNHO         = :f_bunho
								   AND FKINP1001     = :f_fkinp1001
                                   AND GUBUN         = :f_gubun
								   AND WRITE_DATE    = :f_write_date";
						break;
					case DataRowState.Deleted:
						cmdText
							= @"DELETE NUR8050
								 WHERE HOSP_CODE     = :f_hosp_code 
                                   AND BUNHO         = :f_bunho
								   AND FKINP1001     = :f_fkinp1001
                                   AND GUBUN         = :f_gubun
								   AND WRITE_DATE    = :f_write_date";
						break;
				}

				return Service.ExecuteNonQuery(cmdText, item.BindVarList);
			}
		}
		#endregion

        private void grdNUR8050All_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdNUR8050All.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdNUR8050All.SetBindVarValue("f_date", EnvironInfo.GetSysDate().ToShortDateString());
        }

        private void grdNUR8050His_SaveEnd(object sender, SaveEndEventArgs e)
        {
            if (e.IsSuccess)
            {
                grdNUR8050All.QueryLayout(true);
            }
        }

        private void grdNUR8050His_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName == "write_user" ||
                e.ColName == "confirm_user")
            {
                string strCmd = @"SELECT FN_ADM_LOAD_USER_NM(:f_user_id, SYSDATE) FROM SYS.DUAL";
                BindVarCollection bindVar = new BindVarCollection();

                object retval = null;

                bindVar.Add("f_user_id", grdNUR8050His.GetItemString(e.RowNumber, e.ColName));

                retval = Service.ExecuteScalar(strCmd, bindVar);

                if (retval != null)
                {
                    grdNUR8050His.SetItemValue(e.RowNumber, e.ColName + "_name", retval.ToString());

                    grdNUR8050His.AcceptData();
                }
            }

            if (e.ColName == "write_date")
            {
                if (grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "gubun") != "" &&
                    grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "write_date") != "")
                {
                    Validation();
                }
            }
        }

        private bool Validation()
        {
            for (int i = 0; i < grdNUR8050His.RowCount; i++)
            {
                if (grdNUR8050His.CurrentRowNumber != i)
                {
                    if(grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "gubun") == grdNUR8050His.GetItemString(i, "gubun")&&
                       grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "write_date") == grdNUR8050His.GetItemString(i, "write_date") )
                    {
                        GetMessage("validation_chk");
                        grdNUR8050His.SetFocusToItem(grdNUR8050His.CurrentRowNumber, "gubun", true);
                        return false;
                    }
                }
            }
            return true;
        }

        private void grdNUR8050All_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            if (grdNUR8050All.CurrentRowNumber > -1)
            {
                paBox.SetPatientID(grdNUR8050All.GetItemString(e.CurrentRow, "bunho"));
            }
        }

        private void cboGubun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paBox.BunHo != "")
            {
                grdNUR8050His.QueryLayout(false);
            }
        }

        private void rbxDate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbxDate.Checked)
            {
                grdNUR8050His.Sort("write_date desc, gubun");
            }
            else
            {
                grdNUR8050His.Sort("gubun, write_date desc");
            }
        }

        private void btnHisPrint_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("gubun", cboGubun.GetDataValue());
            cic.Add("bunho", paBox.BunHo);
            cic.Add("date", EnvironInfo.GetSysDate().ToShortDateString());
            cic.Add("sort", rbxDate.Checked?"Y":"N");

            XScreen.OpenScreenWithParam(this, "NURI", "NUR8050R00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, cic);
            
        }

        private void btnAllPrint_Click(object sender, EventArgs e)
        {
            CommonItemCollection cic = new CommonItemCollection();

            cic.Add("ho_dong", "C3");

            XScreen.OpenScreenWithParam(this, "NURI", "NUR8050R01", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ParentTopCenter, cic);
        }

        private void grdNUR8050All_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if(   e.ColName == "gubun1" 
                ||e.ColName == "gubun2"
                ||e.ColName == "gubun3"
                ||e.ColName == "gubun4"
                ||e.ColName == "gubun5"
                ||e.ColName == "gubun6")
            {
                if (!TypeCheck.IsNull(e.DataRow[e.ColName + "_date"]))
                {
                    if (DateTime.Parse(e.DataRow[e.ColName + "_date"].ToString()) == EnvironInfo.GetSysDate())
                    {
                        e.ForeColor = Color.Red;
                        e.Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                    }
                    else if (DateTime.Parse(e.DataRow[e.ColName + "_date"].ToString()) >= EnvironInfo.GetSysDate().AddDays(-7))
                    {
                        e.ForeColor = Color.Blue;
                        e.Font = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Bold);
                    }
                    else
                    {
                        e.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void grdNUR8050His_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ColName == "gubun")
            {
                if (grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "write_date") != "")
                {
                    for (int i = 0; i < grdNUR8050His.RowCount; i++)
                    {
                        if (grdNUR8050His.CurrentRowNumber != i)
                        {
                            if (grdNUR8050His.GetItemString(grdNUR8050His.CurrentRowNumber, "write_date") == grdNUR8050His.GetItemString(i, "write_date") &&
                                e.ChangeValue.ToString() == grdNUR8050His.GetItemString(i, "gubun"))
                            {
                                GetMessage("validation_chk");
                                grdNUR8050His.SetFocusToItem(grdNUR8050His.CurrentRowNumber, "gubun", true);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void grdNUR8050All_QueryEnd(object sender, QueryEndEventArgs e)
        {
            grdNUR8050All.SetTopRow(current_row);
            grdNUR8050All.SelectRow(current_row);
        }
    }
}

