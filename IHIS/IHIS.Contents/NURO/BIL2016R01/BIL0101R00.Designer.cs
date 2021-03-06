using IHIS.NURO.Properties;

namespace IHIS.NURO
{
    partial class BIL0101R00
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BIL0101R00));
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnOutput = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.grdReport = new IHIS.Framework.XEditGrid();
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
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtService = new IHIS.Framework.XTextBox();
            this.cboPerson = new IHIS.Framework.XDictComboBox();
            this.fbxExeDoctor = new IHIS.Framework.XFindBox();
            this.fbxAssignDoctor = new IHIS.Framework.XFindBox();
            this.cboAssignDept = new IHIS.Framework.XDictComboBox();
            this.cboExeDept = new IHIS.Framework.XDictComboBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.rbnExeDept = new IHIS.Framework.XRadioButton();
            this.rbnAssignDept = new IHIS.Framework.XRadioButton();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.timePickerTo = new System.Windows.Forms.DateTimePicker();
            this.timePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.numYear = new IHIS.Framework.XNumericUpDown();
            this.numQuarter = new IHIS.Framework.XNumericUpDown();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.mbToMonth = new IHIS.Framework.XMonthBox();
            this.mbFromMonth = new IHIS.Framework.XMonthBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.rbnDate = new IHIS.Framework.XRadioButton();
            this.rbnMonth = new IHIS.Framework.XRadioButton();
            this.rbnQuarter = new IHIS.Framework.XRadioButton();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).BeginInit();
            this.xPanel5.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarter)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // fwkCommon
            // 
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnOutput);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnOutput
            // 
            this.btnOutput.AccessibleDescription = null;
            this.btnOutput.AccessibleName = null;
            resources.ApplyResources(this.btnOutput, "btnOutput");
            this.btnOutput.BackgroundImage = null;
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.TxtSearch, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.NURO.Properties.Resources.BTN_QUIT, -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdReport);
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // grdReport
            // 
            resources.ApplyResources(this.grdReport, "grdReport");
            this.grdReport.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
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
            this.xEditGridCell11});
            this.grdReport.ColPerLine = 10;
            this.grdReport.Cols = 10;
            this.grdReport.ExecuteQuery = null;
            this.grdReport.FixedRows = 1;
            this.grdReport.HeaderHeights.Add(21);
            this.grdReport.Name = "grdReport";
            this.grdReport.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdReport.ParamList")));
            this.grdReport.ReadOnly = true;
            this.grdReport.Rows = 2;
            this.grdReport.ToolTipActive = true;
            this.grdReport.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdReport_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "service_id";
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "service_name";
            this.xEditGridCell2.CellWidth = 193;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "execute_dept";
            this.xEditGridCell3.CellWidth = 108;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "execute_doctor";
            this.xEditGridCell4.CellWidth = 102;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "assign_dept";
            this.xEditGridCell5.CellWidth = 113;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "assign_doctor";
            this.xEditGridCell6.CellWidth = 110;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "acting_date";
            this.xEditGridCell7.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell7.CellWidth = 109;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "quantity";
            this.xEditGridCell8.CellWidth = 50;
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "sum";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell9.CellWidth = 147;
            this.xEditGridCell9.Col = 8;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "discount";
            this.xEditGridCell10.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell10.Col = 9;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "amount_paid";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.xPanel2);
            this.xPanel5.Controls.Add(this.xPanel1);
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel2.Controls.Add(this.txtService);
            this.xPanel2.Controls.Add(this.cboPerson);
            this.xPanel2.Controls.Add(this.fbxExeDoctor);
            this.xPanel2.Controls.Add(this.fbxAssignDoctor);
            this.xPanel2.Controls.Add(this.cboAssignDept);
            this.xPanel2.Controls.Add(this.cboExeDept);
            this.xPanel2.Controls.Add(this.xLabel5);
            this.xPanel2.Controls.Add(this.xLabel4);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.rbnExeDept);
            this.xPanel2.Controls.Add(this.rbnAssignDept);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtService
            // 
            this.txtService.AccessibleDescription = null;
            this.txtService.AccessibleName = null;
            resources.ApplyResources(this.txtService, "txtService");
            this.txtService.BackgroundImage = null;
            this.txtService.Name = "txtService";
            // 
            // cboPerson
            // 
            this.cboPerson.AccessibleDescription = null;
            this.cboPerson.AccessibleName = null;
            resources.ApplyResources(this.cboPerson, "cboPerson");
            this.cboPerson.BackgroundImage = null;
            this.cboPerson.ExecuteQuery = null;
            this.cboPerson.Name = "cboPerson";
            this.cboPerson.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboPerson.ParamList")));
            this.cboPerson.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // fbxExeDoctor
            // 
            this.fbxExeDoctor.AccessibleDescription = null;
            this.fbxExeDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxExeDoctor, "fbxExeDoctor");
            this.fbxExeDoctor.BackgroundImage = null;
            this.fbxExeDoctor.FindWorker = this.fwkCommon;
            this.fbxExeDoctor.Name = "fbxExeDoctor";
            // 
            // fbxAssignDoctor
            // 
            this.fbxAssignDoctor.AccessibleDescription = null;
            this.fbxAssignDoctor.AccessibleName = null;
            resources.ApplyResources(this.fbxAssignDoctor, "fbxAssignDoctor");
            this.fbxAssignDoctor.BackgroundImage = null;
            this.fbxAssignDoctor.FindWorker = this.fwkCommon;
            this.fbxAssignDoctor.Name = "fbxAssignDoctor";
            // 
            // cboAssignDept
            // 
            this.cboAssignDept.AccessibleDescription = null;
            this.cboAssignDept.AccessibleName = null;
            resources.ApplyResources(this.cboAssignDept, "cboAssignDept");
            this.cboAssignDept.BackgroundImage = null;
            this.cboAssignDept.ExecuteQuery = null;
            this.cboAssignDept.Name = "cboAssignDept";
            this.cboAssignDept.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboAssignDept.ParamList")));
            this.cboAssignDept.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // cboExeDept
            // 
            this.cboExeDept.AccessibleDescription = null;
            this.cboExeDept.AccessibleName = null;
            resources.ApplyResources(this.cboExeDept, "cboExeDept");
            this.cboExeDept.BackgroundImage = null;
            this.cboExeDept.ExecuteQuery = null;
            this.cboExeDept.Name = "cboExeDept";
            this.cboExeDept.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboExeDept.ParamList")));
            this.cboExeDept.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel5.EdgeRounding = false;
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel4.EdgeRounding = false;
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // rbnExeDept
            // 
            this.rbnExeDept.AccessibleDescription = null;
            this.rbnExeDept.AccessibleName = null;
            resources.ApplyResources(this.rbnExeDept, "rbnExeDept");
            this.rbnExeDept.BackgroundImage = null;
            this.rbnExeDept.Name = "rbnExeDept";
            this.rbnExeDept.UseVisualStyleBackColor = true;
            this.rbnExeDept.CheckedChanged += new System.EventHandler(this.rbnDept_CheckedChanged);
            // 
            // rbnAssignDept
            // 
            this.rbnAssignDept.AccessibleDescription = null;
            this.rbnAssignDept.AccessibleName = null;
            resources.ApplyResources(this.rbnAssignDept, "rbnAssignDept");
            this.rbnAssignDept.BackgroundImage = null;
            this.rbnAssignDept.Checked = true;
            this.rbnAssignDept.Name = "rbnAssignDept";
            this.rbnAssignDept.TabStop = true;
            this.rbnAssignDept.UseVisualStyleBackColor = true;
            this.rbnAssignDept.CheckedChanged += new System.EventHandler(this.rbnDept_CheckedChanged);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.xPanel1.Controls.Add(this.timePickerTo);
            this.xPanel1.Controls.Add(this.timePickerFrom);
            this.xPanel1.Controls.Add(this.xLabel7);
            this.xPanel1.Controls.Add(this.xLabel6);
            this.xPanel1.Controls.Add(this.numYear);
            this.xPanel1.Controls.Add(this.numQuarter);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.mbToMonth);
            this.xPanel1.Controls.Add(this.mbFromMonth);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.rbnDate);
            this.xPanel1.Controls.Add(this.rbnMonth);
            this.xPanel1.Controls.Add(this.rbnQuarter);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // timePickerTo
            // 
            this.timePickerTo.AccessibleDescription = null;
            this.timePickerTo.AccessibleName = null;
            resources.ApplyResources(this.timePickerTo, "timePickerTo");
            this.timePickerTo.BackgroundImage = null;
            this.timePickerTo.CalendarFont = null;
            this.timePickerTo.CustomFormat = null;
            this.timePickerTo.Font = null;
            this.timePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerTo.Name = "timePickerTo";
            this.timePickerTo.ShowUpDown = true;
            // 
            // timePickerFrom
            // 
            this.timePickerFrom.AccessibleDescription = null;
            this.timePickerFrom.AccessibleName = null;
            resources.ApplyResources(this.timePickerFrom, "timePickerFrom");
            this.timePickerFrom.BackgroundImage = null;
            this.timePickerFrom.CalendarFont = null;
            this.timePickerFrom.CustomFormat = null;
            this.timePickerFrom.Font = null;
            this.timePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerFrom.Name = "timePickerFrom";
            this.timePickerFrom.ShowUpDown = true;
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // numYear
            // 
            this.numYear.AccessibleDescription = null;
            this.numYear.AccessibleName = null;
            resources.ApplyResources(this.numYear, "numYear");
            this.numYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numYear.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numYear.Name = "numYear";
            this.numYear.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // numQuarter
            // 
            this.numQuarter.AccessibleDescription = null;
            this.numQuarter.AccessibleName = null;
            resources.ApplyResources(this.numQuarter, "numQuarter");
            this.numQuarter.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numQuarter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuarter.Name = "numQuarter";
            this.numQuarter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.AccessibleDescription = null;
            this.dtpFromDate.AccessibleName = null;
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.BackgroundImage = null;
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            // 
            // mbToMonth
            // 
            this.mbToMonth.AccessibleDescription = null;
            this.mbToMonth.AccessibleName = null;
            resources.ApplyResources(this.mbToMonth, "mbToMonth");
            this.mbToMonth.BackgroundImage = null;
            this.mbToMonth.IsVietnameseYearType = false;
            this.mbToMonth.Name = "mbToMonth";
            // 
            // mbFromMonth
            // 
            this.mbFromMonth.AccessibleDescription = null;
            this.mbFromMonth.AccessibleName = null;
            resources.ApplyResources(this.mbFromMonth, "mbFromMonth");
            this.mbFromMonth.BackgroundImage = null;
            this.mbFromMonth.IsVietnameseYearType = false;
            this.mbFromMonth.Name = "mbFromMonth";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.BorderColor = IHIS.Framework.XColor.XLabelBackColor;
            this.xLabel2.EdgeRounding = false;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dtpToDate
            // 
            this.dtpToDate.AccessibleDescription = null;
            this.dtpToDate.AccessibleName = null;
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.BackgroundImage = null;
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            // 
            // rbnDate
            // 
            this.rbnDate.AccessibleDescription = null;
            this.rbnDate.AccessibleName = null;
            resources.ApplyResources(this.rbnDate, "rbnDate");
            this.rbnDate.BackgroundImage = null;
            this.rbnDate.Name = "rbnDate";
            this.rbnDate.UseVisualStyleBackColor = true;
            this.rbnDate.CheckedChanged += new System.EventHandler(this.rbnTime_CheckedChanged);
            // 
            // rbnMonth
            // 
            this.rbnMonth.AccessibleDescription = null;
            this.rbnMonth.AccessibleName = null;
            resources.ApplyResources(this.rbnMonth, "rbnMonth");
            this.rbnMonth.BackgroundImage = null;
            this.rbnMonth.Name = "rbnMonth";
            this.rbnMonth.UseVisualStyleBackColor = true;
            this.rbnMonth.CheckedChanged += new System.EventHandler(this.rbnTime_CheckedChanged);
            // 
            // rbnQuarter
            // 
            this.rbnQuarter.AccessibleDescription = null;
            this.rbnQuarter.AccessibleName = null;
            resources.ApplyResources(this.rbnQuarter, "rbnQuarter");
            this.rbnQuarter.BackgroundImage = null;
            this.rbnQuarter.Checked = true;
            this.rbnQuarter.Name = "rbnQuarter";
            this.rbnQuarter.TabStop = true;
            this.rbnQuarter.UseVisualStyleBackColor = true;
            this.rbnQuarter.CheckedChanged += new System.EventHandler(this.rbnTime_CheckedChanged);
            // 
            // BIL0101R00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel4);
            this.Controls.Add(this.xPanel5);
            this.Controls.Add(this.xPanel3);
            this.Name = "BIL0101R00";
            this.Load += new System.EventHandler(this.BIL2016R01_Load);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReport)).EndInit();
            this.xPanel5.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuarter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XButton btnOutput;
        private IHIS.Framework.XFindWorker fwkCommon;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XTextBox txtService;
        private IHIS.Framework.XDictComboBox cboPerson;
        private IHIS.Framework.XFindBox fbxExeDoctor;
        private IHIS.Framework.XFindBox fbxAssignDoctor;
        private IHIS.Framework.XDictComboBox cboAssignDept;
        private IHIS.Framework.XDictComboBox cboExeDept;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XRadioButton rbnExeDept;
        private IHIS.Framework.XRadioButton rbnAssignDept;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XPanel xPanel1;
        private System.Windows.Forms.DateTimePicker timePickerFrom;
        private IHIS.Framework.XLabel xLabel7;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XNumericUpDown numYear;
        private IHIS.Framework.XNumericUpDown numQuarter;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XMonthBox mbToMonth;
        private IHIS.Framework.XMonthBox mbFromMonth;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XRadioButton rbnDate;
        private IHIS.Framework.XRadioButton rbnMonth;
        private IHIS.Framework.XRadioButton rbnQuarter;
        private IHIS.Framework.XEditGrid grdReport;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private System.Windows.Forms.DateTimePicker timePickerTo;
    }
}
