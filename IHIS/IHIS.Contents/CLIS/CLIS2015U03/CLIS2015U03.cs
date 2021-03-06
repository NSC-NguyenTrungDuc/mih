using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Clis;
using IHIS.CloudConnector.Contracts.Results.Clis;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Clis;
using IHIS.CloudConnector.Utility;
using System.Windows.Forms;
using IHIS.CLIS.Properties;
using System.Data;
using IHIS.CloudConnector.Contracts.Results.System;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid.FilterEditor;
using DevExpress.XtraEditors.Repository;
using IHIS.CloudConnector.Contracts.Arguments.Chts;
using IHIS.CloudConnector.Contracts.Results.Chts;
using IHIS.CloudConnector.Contracts.Models.Chts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System.Text.RegularExpressions;
using DevExpress.Data.Filtering;

namespace IHIS.CLIS
{
    /// <summary>
    /// CLIS.CLIS2015U03
    /// Created on 2015.09.01
    /// </summary>
    [ToolboxItem(false)]
    public partial class CLIS2015U03 : IHIS.Framework.XScreen
    {
        #region Auto-gen code

        private IHIS.Framework.XEditGrid grdPatientList;
        private IHIS.Framework.XGroupBox xGroupBox1;
        private IHIS.Framework.XRadioButton femaleRadioButton;
        private IHIS.Framework.XRadioButton maleRadioButton;
        private IHIS.Framework.XCheckBox clisJoiningCheckBox;
        private IHIS.Framework.XCheckBox pacerMakerCheckBox;
        private IHIS.Framework.XCheckBox dateComeCheckBox;
        private IHIS.Framework.XCheckBox ageCheckBox;
        private IHIS.Framework.XCheckBox genderCheckBox;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDatePicker dateComeToDate;
        private IHIS.Framework.XTextBox ageToTextBox;
        private IHIS.Framework.XTextBox ageFromTextBox;
        private IHIS.Framework.XDatePicker dateComeFromDate;
        private IHIS.Framework.XRadioButton notJoinedRadioButton;
        private IHIS.Framework.XRadioButton joinedRadioButton;
        private IHIS.Framework.XRadioButton notUsedRadioButton;
        private IHIS.Framework.XRadioButton usedRadioButton;
        private IHIS.Framework.XButton searchButton;
        private IHIS.Framework.XButton addPatientButton;
        private IHIS.Framework.XEditGrid grdProtocolList;
        private IHIS.Framework.XEditGrid grdPatientListJoin;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private DevExpress.XtraEditors.FilterControl orderListFilterControl;
        private DevExpress.XtraEditors.FilterControl drugListFilterControl;
        private DevExpress.XtraEditors.FilterControl diseaseListFilterControl;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XRichTextBox familyCondRichTextBox;
        private XPanel genderPanel;
        private XPanel clisJoinPanel;
        private XPanel pacermakerPanel;
        private XPanel dateComePanel;
        private XPanel agePanel;
        private XEditGridCell xEditGridCell10;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private GridColumn gridColumnSangCode;
        private GridColumn gridColumnSangStartDate;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private GridColumn gridColumnOrderHangmogCode;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private GridColumn gridColumnDrugHangmogCode;
        private XButtonList btnList;
        private GridColumn gridColumnCplResult;
        private IHIS.Framework.XGroupBox xGroupBox2;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIS2015U03));
            this.grdPatientList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xGroupBox1 = new IHIS.Framework.XGroupBox();
            this.dateComePanel = new IHIS.Framework.XPanel();
            this.dateComeToDate = new IHIS.Framework.XDatePicker();
            this.dateComeFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.agePanel = new IHIS.Framework.XPanel();
            this.ageToTextBox = new IHIS.Framework.XTextBox();
            this.ageFromTextBox = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.clisJoinPanel = new IHIS.Framework.XPanel();
            this.notJoinedRadioButton = new IHIS.Framework.XRadioButton();
            this.joinedRadioButton = new IHIS.Framework.XRadioButton();
            this.pacermakerPanel = new IHIS.Framework.XPanel();
            this.usedRadioButton = new IHIS.Framework.XRadioButton();
            this.notUsedRadioButton = new IHIS.Framework.XRadioButton();
            this.genderPanel = new IHIS.Framework.XPanel();
            this.maleRadioButton = new IHIS.Framework.XRadioButton();
            this.femaleRadioButton = new IHIS.Framework.XRadioButton();
            this.searchButton = new IHIS.Framework.XButton();
            this.clisJoiningCheckBox = new IHIS.Framework.XCheckBox();
            this.pacerMakerCheckBox = new IHIS.Framework.XCheckBox();
            this.dateComeCheckBox = new IHIS.Framework.XCheckBox();
            this.ageCheckBox = new IHIS.Framework.XCheckBox();
            this.genderCheckBox = new IHIS.Framework.XCheckBox();
            this.xGroupBox2 = new IHIS.Framework.XGroupBox();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnOrderHangmogCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCplResult = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDrugHangmogCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnSangCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSangStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.familyCondRichTextBox = new IHIS.Framework.XRichTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.orderListFilterControl = new DevExpress.XtraEditors.FilterControl();
            this.drugListFilterControl = new DevExpress.XtraEditors.FilterControl();
            this.diseaseListFilterControl = new DevExpress.XtraEditors.FilterControl();
            this.addPatientButton = new IHIS.Framework.XButton();
            this.grdProtocolList = new IHIS.Framework.XEditGrid();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.grdPatientListJoin = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.btnList = new IHIS.Framework.XButtonList();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).BeginInit();
            this.xGroupBox1.SuspendLayout();
            this.dateComePanel.SuspendLayout();
            this.agePanel.SuspendLayout();
            this.clisJoinPanel.SuspendLayout();
            this.pacermakerPanel.SuspendLayout();
            this.genderPanel.SuspendLayout();
            this.xGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocolList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientListJoin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdPatientList
            // 
            resources.ApplyResources(this.grdPatientList, "grdPatientList");
            this.grdPatientList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5});
            this.grdPatientList.ColPerLine = 5;
            this.grdPatientList.Cols = 6;
            this.grdPatientList.ExecuteQuery = null;
            this.grdPatientList.FixedCols = 1;
            this.grdPatientList.FixedRows = 1;
            this.grdPatientList.HeaderHeights.Add(21);
            this.grdPatientList.Name = "grdPatientList";
            this.grdPatientList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientList.ParamList")));
            this.grdPatientList.RowHeaderVisible = true;
            this.grdPatientList.Rows = 2;
            this.grdPatientList.ToolTipActive = true;
            this.grdPatientList.Enter += new System.EventHandler(this.grdPatientList_Enter);
            this.grdPatientList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientList_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "select";
            this.xEditGridCell1.CellWidth = 50;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "patient_code";
            this.xEditGridCell2.CellWidth = 93;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "patient_name";
            this.xEditGridCell3.CellWidth = 134;
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "age";
            this.xEditGridCell4.CellWidth = 46;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "gender";
            this.xEditGridCell5.CellWidth = 44;
            this.xEditGridCell5.Col = 5;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xGroupBox1
            // 
            this.xGroupBox1.AccessibleDescription = null;
            this.xGroupBox1.AccessibleName = null;
            resources.ApplyResources(this.xGroupBox1, "xGroupBox1");
            this.xGroupBox1.BackgroundImage = null;
            this.xGroupBox1.Controls.Add(this.dateComePanel);
            this.xGroupBox1.Controls.Add(this.agePanel);
            this.xGroupBox1.Controls.Add(this.clisJoinPanel);
            this.xGroupBox1.Controls.Add(this.pacermakerPanel);
            this.xGroupBox1.Controls.Add(this.genderPanel);
            this.xGroupBox1.Controls.Add(this.searchButton);
            this.xGroupBox1.Controls.Add(this.clisJoiningCheckBox);
            this.xGroupBox1.Controls.Add(this.pacerMakerCheckBox);
            this.xGroupBox1.Controls.Add(this.dateComeCheckBox);
            this.xGroupBox1.Controls.Add(this.ageCheckBox);
            this.xGroupBox1.Controls.Add(this.genderCheckBox);
            this.xGroupBox1.Name = "xGroupBox1";
            this.xGroupBox1.Protect = true;
            this.xGroupBox1.TabStop = false;
            // 
            // dateComePanel
            // 
            this.dateComePanel.AccessibleDescription = null;
            this.dateComePanel.AccessibleName = null;
            resources.ApplyResources(this.dateComePanel, "dateComePanel");
            this.dateComePanel.BackgroundImage = null;
            this.dateComePanel.Controls.Add(this.dateComeToDate);
            this.dateComePanel.Controls.Add(this.dateComeFromDate);
            this.dateComePanel.Controls.Add(this.xLabel2);
            this.dateComePanel.Font = null;
            this.dateComePanel.Name = "dateComePanel";
            // 
            // dateComeToDate
            // 
            this.dateComeToDate.AccessibleDescription = null;
            this.dateComeToDate.AccessibleName = null;
            resources.ApplyResources(this.dateComeToDate, "dateComeToDate");
            this.dateComeToDate.BackgroundImage = null;
            this.dateComeToDate.Name = "dateComeToDate";
            // 
            // dateComeFromDate
            // 
            this.dateComeFromDate.AccessibleDescription = null;
            this.dateComeFromDate.AccessibleName = null;
            resources.ApplyResources(this.dateComeFromDate, "dateComeFromDate");
            this.dateComeFromDate.BackgroundImage = null;
            this.dateComeFromDate.Name = "dateComeFromDate";
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // agePanel
            // 
            this.agePanel.AccessibleDescription = null;
            this.agePanel.AccessibleName = null;
            resources.ApplyResources(this.agePanel, "agePanel");
            this.agePanel.BackgroundImage = null;
            this.agePanel.Controls.Add(this.ageToTextBox);
            this.agePanel.Controls.Add(this.ageFromTextBox);
            this.agePanel.Controls.Add(this.xLabel1);
            this.agePanel.Font = null;
            this.agePanel.Name = "agePanel";
            // 
            // ageToTextBox
            // 
            this.ageToTextBox.AccessibleDescription = null;
            this.ageToTextBox.AccessibleName = null;
            resources.ApplyResources(this.ageToTextBox, "ageToTextBox");
            this.ageToTextBox.BackgroundImage = null;
            this.ageToTextBox.Name = "ageToTextBox";
            this.ageToTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageTextBox_KeyPress);
            // 
            // ageFromTextBox
            // 
            this.ageFromTextBox.AccessibleDescription = null;
            this.ageFromTextBox.AccessibleName = null;
            resources.ApplyResources(this.ageFromTextBox, "ageFromTextBox");
            this.ageFromTextBox.BackgroundImage = null;
            this.ageFromTextBox.Name = "ageFromTextBox";
            this.ageFromTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ageTextBox_KeyPress);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // clisJoinPanel
            // 
            this.clisJoinPanel.AccessibleDescription = null;
            this.clisJoinPanel.AccessibleName = null;
            resources.ApplyResources(this.clisJoinPanel, "clisJoinPanel");
            this.clisJoinPanel.BackgroundImage = null;
            this.clisJoinPanel.Controls.Add(this.notJoinedRadioButton);
            this.clisJoinPanel.Controls.Add(this.joinedRadioButton);
            this.clisJoinPanel.Font = null;
            this.clisJoinPanel.Name = "clisJoinPanel";
            // 
            // notJoinedRadioButton
            // 
            this.notJoinedRadioButton.AccessibleDescription = null;
            this.notJoinedRadioButton.AccessibleName = null;
            resources.ApplyResources(this.notJoinedRadioButton, "notJoinedRadioButton");
            this.notJoinedRadioButton.BackgroundImage = null;
            this.notJoinedRadioButton.Name = "notJoinedRadioButton";
            this.notJoinedRadioButton.TabStop = true;
            this.notJoinedRadioButton.UseVisualStyleBackColor = true;
            // 
            // joinedRadioButton
            // 
            this.joinedRadioButton.AccessibleDescription = null;
            this.joinedRadioButton.AccessibleName = null;
            resources.ApplyResources(this.joinedRadioButton, "joinedRadioButton");
            this.joinedRadioButton.BackgroundImage = null;
            this.joinedRadioButton.Name = "joinedRadioButton";
            this.joinedRadioButton.TabStop = true;
            this.joinedRadioButton.UseVisualStyleBackColor = true;
            // 
            // pacermakerPanel
            // 
            this.pacermakerPanel.AccessibleDescription = null;
            this.pacermakerPanel.AccessibleName = null;
            resources.ApplyResources(this.pacermakerPanel, "pacermakerPanel");
            this.pacermakerPanel.BackgroundImage = null;
            this.pacermakerPanel.Controls.Add(this.usedRadioButton);
            this.pacermakerPanel.Controls.Add(this.notUsedRadioButton);
            this.pacermakerPanel.Font = null;
            this.pacermakerPanel.Name = "pacermakerPanel";
            // 
            // usedRadioButton
            // 
            this.usedRadioButton.AccessibleDescription = null;
            this.usedRadioButton.AccessibleName = null;
            resources.ApplyResources(this.usedRadioButton, "usedRadioButton");
            this.usedRadioButton.BackgroundImage = null;
            this.usedRadioButton.Name = "usedRadioButton";
            this.usedRadioButton.TabStop = true;
            this.usedRadioButton.UseVisualStyleBackColor = true;
            // 
            // notUsedRadioButton
            // 
            this.notUsedRadioButton.AccessibleDescription = null;
            this.notUsedRadioButton.AccessibleName = null;
            resources.ApplyResources(this.notUsedRadioButton, "notUsedRadioButton");
            this.notUsedRadioButton.BackgroundImage = null;
            this.notUsedRadioButton.Name = "notUsedRadioButton";
            this.notUsedRadioButton.TabStop = true;
            this.notUsedRadioButton.UseVisualStyleBackColor = true;
            // 
            // genderPanel
            // 
            this.genderPanel.AccessibleDescription = null;
            this.genderPanel.AccessibleName = null;
            resources.ApplyResources(this.genderPanel, "genderPanel");
            this.genderPanel.BackgroundImage = null;
            this.genderPanel.Controls.Add(this.maleRadioButton);
            this.genderPanel.Controls.Add(this.femaleRadioButton);
            this.genderPanel.Font = null;
            this.genderPanel.Name = "genderPanel";
            // 
            // maleRadioButton
            // 
            this.maleRadioButton.AccessibleDescription = null;
            this.maleRadioButton.AccessibleName = null;
            resources.ApplyResources(this.maleRadioButton, "maleRadioButton");
            this.maleRadioButton.BackgroundImage = null;
            this.maleRadioButton.Checked = true;
            this.maleRadioButton.Name = "maleRadioButton";
            this.maleRadioButton.TabStop = true;
            this.maleRadioButton.UseVisualStyleBackColor = true;
            // 
            // femaleRadioButton
            // 
            this.femaleRadioButton.AccessibleDescription = null;
            this.femaleRadioButton.AccessibleName = null;
            resources.ApplyResources(this.femaleRadioButton, "femaleRadioButton");
            this.femaleRadioButton.BackgroundImage = null;
            this.femaleRadioButton.Name = "femaleRadioButton";
            this.femaleRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.AccessibleDescription = null;
            this.searchButton.AccessibleName = null;
            resources.ApplyResources(this.searchButton, "searchButton");
            this.searchButton.BackgroundImage = null;
            this.searchButton.Name = "searchButton";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // clisJoiningCheckBox
            // 
            this.clisJoiningCheckBox.AccessibleDescription = null;
            this.clisJoiningCheckBox.AccessibleName = null;
            resources.ApplyResources(this.clisJoiningCheckBox, "clisJoiningCheckBox");
            this.clisJoiningCheckBox.BackgroundImage = null;
            this.clisJoiningCheckBox.Name = "clisJoiningCheckBox";
            this.clisJoiningCheckBox.UseVisualStyleBackColor = false;
            this.clisJoiningCheckBox.CheckedChanged += new System.EventHandler(this.clisJoiningCheckBox_CheckedChanged);
            // 
            // pacerMakerCheckBox
            // 
            this.pacerMakerCheckBox.AccessibleDescription = null;
            this.pacerMakerCheckBox.AccessibleName = null;
            resources.ApplyResources(this.pacerMakerCheckBox, "pacerMakerCheckBox");
            this.pacerMakerCheckBox.BackgroundImage = null;
            this.pacerMakerCheckBox.Name = "pacerMakerCheckBox";
            this.pacerMakerCheckBox.UseVisualStyleBackColor = false;
            this.pacerMakerCheckBox.CheckedChanged += new System.EventHandler(this.pacerMakerCheckBox_CheckedChanged);
            // 
            // dateComeCheckBox
            // 
            this.dateComeCheckBox.AccessibleDescription = null;
            this.dateComeCheckBox.AccessibleName = null;
            resources.ApplyResources(this.dateComeCheckBox, "dateComeCheckBox");
            this.dateComeCheckBox.BackgroundImage = null;
            this.dateComeCheckBox.Name = "dateComeCheckBox";
            this.dateComeCheckBox.UseVisualStyleBackColor = false;
            this.dateComeCheckBox.CheckedChanged += new System.EventHandler(this.dateComeCheckBox_CheckedChanged);
            // 
            // ageCheckBox
            // 
            this.ageCheckBox.AccessibleDescription = null;
            this.ageCheckBox.AccessibleName = null;
            resources.ApplyResources(this.ageCheckBox, "ageCheckBox");
            this.ageCheckBox.BackgroundImage = null;
            this.ageCheckBox.Name = "ageCheckBox";
            this.ageCheckBox.UseVisualStyleBackColor = false;
            this.ageCheckBox.CheckedChanged += new System.EventHandler(this.ageCheckBox_CheckedChanged);
            // 
            // genderCheckBox
            // 
            this.genderCheckBox.AccessibleDescription = null;
            this.genderCheckBox.AccessibleName = null;
            resources.ApplyResources(this.genderCheckBox, "genderCheckBox");
            this.genderCheckBox.BackgroundImage = null;
            this.genderCheckBox.Name = "genderCheckBox";
            this.genderCheckBox.UseVisualStyleBackColor = false;
            this.genderCheckBox.CheckedChanged += new System.EventHandler(this.genderCheckBox_CheckedChanged);
            // 
            // xGroupBox2
            // 
            this.xGroupBox2.AccessibleDescription = null;
            this.xGroupBox2.AccessibleName = null;
            resources.ApplyResources(this.xGroupBox2, "xGroupBox2");
            this.xGroupBox2.BackgroundImage = null;
            this.xGroupBox2.Controls.Add(this.gridControl3);
            this.xGroupBox2.Controls.Add(this.gridControl2);
            this.xGroupBox2.Controls.Add(this.gridControl1);
            this.xGroupBox2.Controls.Add(this.familyCondRichTextBox);
            this.xGroupBox2.Controls.Add(this.xLabel6);
            this.xGroupBox2.Controls.Add(this.xLabel5);
            this.xGroupBox2.Controls.Add(this.xLabel4);
            this.xGroupBox2.Controls.Add(this.xLabel3);
            this.xGroupBox2.Controls.Add(this.orderListFilterControl);
            this.xGroupBox2.Controls.Add(this.drugListFilterControl);
            this.xGroupBox2.Controls.Add(this.diseaseListFilterControl);
            this.xGroupBox2.Name = "xGroupBox2";
            this.xGroupBox2.Protect = true;
            this.xGroupBox2.TabStop = false;
            // 
            // gridControl3
            // 
            this.gridControl3.AccessibleDescription = null;
            this.gridControl3.AccessibleName = null;
            resources.ApplyResources(this.gridControl3, "gridControl3");
            this.gridControl3.BackgroundImage = null;
            this.gridControl3.EmbeddedNavigator.AccessibleDescription = null;
            this.gridControl3.EmbeddedNavigator.AccessibleName = null;
            this.gridControl3.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl3.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl3.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl3.EmbeddedNavigator.Anchor")));
            this.gridControl3.EmbeddedNavigator.BackgroundImage = null;
            this.gridControl3.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl3.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl3.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl3.EmbeddedNavigator.ImeMode")));
            this.gridControl3.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl3.EmbeddedNavigator.TextLocation")));
            this.gridControl3.EmbeddedNavigator.ToolTip = resources.GetString("gridControl3.EmbeddedNavigator.ToolTip");
            this.gridControl3.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl3.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl3.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl3.EmbeddedNavigator.ToolTipTitle");
            this.gridControl3.Font = null;
            this.gridControl3.MainView = this.gridView3;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            resources.ApplyResources(this.gridView3, "gridView3");
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnOrderHangmogCode,
            this.gridColumnCplResult});
            this.gridView3.GridControl = this.gridControl3;
            this.gridView3.Name = "gridView3";
            // 
            // gridColumnOrderHangmogCode
            // 
            resources.ApplyResources(this.gridColumnOrderHangmogCode, "gridColumnOrderHangmogCode");
            this.gridColumnOrderHangmogCode.FieldName = "VW_CPL_TEST_RESULT.HANGMOG_CODE";
            this.gridColumnOrderHangmogCode.Name = "gridColumnOrderHangmogCode";
            this.gridColumnOrderHangmogCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumnCplResult
            // 
            resources.ApplyResources(this.gridColumnCplResult, "gridColumnCplResult");
            this.gridColumnCplResult.FieldName = "VW_CPL_TEST_RESULT.CPL_RESULT";
            this.gridColumnCplResult.Name = "gridColumnCplResult";
            this.gridColumnCplResult.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridControl2
            // 
            this.gridControl2.AccessibleDescription = null;
            this.gridControl2.AccessibleName = null;
            resources.ApplyResources(this.gridControl2, "gridControl2");
            this.gridControl2.BackgroundImage = null;
            this.gridControl2.EmbeddedNavigator.AccessibleDescription = null;
            this.gridControl2.EmbeddedNavigator.AccessibleName = null;
            this.gridControl2.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl2.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl2.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl2.EmbeddedNavigator.Anchor")));
            this.gridControl2.EmbeddedNavigator.BackgroundImage = null;
            this.gridControl2.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl2.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl2.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl2.EmbeddedNavigator.ImeMode")));
            this.gridControl2.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl2.EmbeddedNavigator.TextLocation")));
            this.gridControl2.EmbeddedNavigator.ToolTip = resources.GetString("gridControl2.EmbeddedNavigator.ToolTip");
            this.gridControl2.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl2.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl2.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl2.EmbeddedNavigator.ToolTipTitle");
            this.gridControl2.Font = null;
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            resources.ApplyResources(this.gridView2, "gridView2");
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDrugHangmogCode});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // gridColumnDrugHangmogCode
            // 
            resources.ApplyResources(this.gridColumnDrugHangmogCode, "gridColumnDrugHangmogCode");
            this.gridColumnDrugHangmogCode.FieldName = "OCS1003.HANGMOG_CODE";
            this.gridColumnDrugHangmogCode.Name = "gridColumnDrugHangmogCode";
            this.gridColumnDrugHangmogCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridControl1
            // 
            this.gridControl1.AccessibleDescription = null;
            this.gridControl1.AccessibleName = null;
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.BackgroundImage = null;
            this.gridControl1.EmbeddedNavigator.AccessibleDescription = null;
            this.gridControl1.EmbeddedNavigator.AccessibleName = null;
            this.gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gridControl1.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gridControl1.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gridControl1.EmbeddedNavigator.Anchor")));
            this.gridControl1.EmbeddedNavigator.BackgroundImage = null;
            this.gridControl1.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gridControl1.EmbeddedNavigator.BackgroundImageLayout")));
            this.gridControl1.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gridControl1.EmbeddedNavigator.ImeMode")));
            this.gridControl1.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gridControl1.EmbeddedNavigator.TextLocation")));
            this.gridControl1.EmbeddedNavigator.ToolTip = resources.GetString("gridControl1.EmbeddedNavigator.ToolTip");
            this.gridControl1.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gridControl1.EmbeddedNavigator.ToolTipIconType")));
            this.gridControl1.EmbeddedNavigator.ToolTipTitle = resources.GetString("gridControl1.EmbeddedNavigator.ToolTipTitle");
            this.gridControl1.Font = null;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            resources.ApplyResources(this.gridView1, "gridView1");
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnSangCode,
            this.gridColumnSangStartDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumnSangCode
            // 
            resources.ApplyResources(this.gridColumnSangCode, "gridColumnSangCode");
            this.gridColumnSangCode.FieldName = "OUTSANG.SANG_CODE";
            this.gridColumnSangCode.Name = "gridColumnSangCode";
            this.gridColumnSangCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // gridColumnSangStartDate
            // 
            resources.ApplyResources(this.gridColumnSangStartDate, "gridColumnSangStartDate");
            this.gridColumnSangStartDate.FieldName = "OUTSANG.SANG_START_DATE";
            this.gridColumnSangStartDate.Name = "gridColumnSangStartDate";
            this.gridColumnSangStartDate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem()});
            // 
            // familyCondRichTextBox
            // 
            this.familyCondRichTextBox.AccessibleDescription = null;
            this.familyCondRichTextBox.AccessibleName = null;
            resources.ApplyResources(this.familyCondRichTextBox, "familyCondRichTextBox");
            this.familyCondRichTextBox.BackgroundImage = null;
            this.familyCondRichTextBox.Name = "familyCondRichTextBox";
            // 
            // xLabel6
            // 
            this.xLabel6.AccessibleDescription = null;
            this.xLabel6.AccessibleName = null;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.Image = null;
            this.xLabel6.Name = "xLabel6";
            // 
            // xLabel5
            // 
            this.xLabel5.AccessibleDescription = null;
            this.xLabel5.AccessibleName = null;
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Image = null;
            this.xLabel5.Name = "xLabel5";
            // 
            // xLabel4
            // 
            this.xLabel4.AccessibleDescription = null;
            this.xLabel4.AccessibleName = null;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.Image = null;
            this.xLabel4.Name = "xLabel4";
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // orderListFilterControl
            // 
            this.orderListFilterControl.AccessibleDescription = null;
            this.orderListFilterControl.AccessibleName = null;
            resources.ApplyResources(this.orderListFilterControl, "orderListFilterControl");
            this.orderListFilterControl.BackgroundImage = null;
            this.orderListFilterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.orderListFilterControl.Name = "orderListFilterControl";
            this.orderListFilterControl.FilterChanged += new DevExpress.XtraEditors.FilterChangedEventHandler(this.orderListFilterControl_FilterChanged);
            this.orderListFilterControl.BeforeShowValueEditor += new DevExpress.XtraEditors.Filtering.ShowValueEditorEventHandler(this.orderListFilterControl_BeforeShowValueEditor);
            this.orderListFilterControl.PopupMenuShowing += new DevExpress.XtraEditors.Filtering.PopupMenuShowingEventHandler(this.FilterControl_PopupMenuShowing);
            // 
            // drugListFilterControl
            // 
            this.drugListFilterControl.AccessibleDescription = null;
            this.drugListFilterControl.AccessibleName = null;
            resources.ApplyResources(this.drugListFilterControl, "drugListFilterControl");
            this.drugListFilterControl.BackgroundImage = null;
            this.drugListFilterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.drugListFilterControl.Name = "drugListFilterControl";
            this.drugListFilterControl.FilterChanged += new DevExpress.XtraEditors.FilterChangedEventHandler(this.drugListFilterControl_FilterChanged);
            this.drugListFilterControl.BeforeShowValueEditor += new DevExpress.XtraEditors.Filtering.ShowValueEditorEventHandler(this.drugListFilterControl_BeforeShowValueEditor);
            this.drugListFilterControl.PopupMenuShowing += new DevExpress.XtraEditors.Filtering.PopupMenuShowingEventHandler(this.FilterControl_PopupMenuShowing);
            // 
            // diseaseListFilterControl
            // 
            this.diseaseListFilterControl.AccessibleDescription = null;
            this.diseaseListFilterControl.AccessibleName = null;
            resources.ApplyResources(this.diseaseListFilterControl, "diseaseListFilterControl");
            this.diseaseListFilterControl.BackgroundImage = null;
            this.diseaseListFilterControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.diseaseListFilterControl.Name = "diseaseListFilterControl";
            this.diseaseListFilterControl.FilterChanged += new DevExpress.XtraEditors.FilterChangedEventHandler(this.diseaseListFilterControl_FilterChanged);
            this.diseaseListFilterControl.BeforeShowValueEditor += new DevExpress.XtraEditors.Filtering.ShowValueEditorEventHandler(this.diseaseListFilterControl_BeforeShowValueEditor);
            this.diseaseListFilterControl.PopupMenuShowing += new DevExpress.XtraEditors.Filtering.PopupMenuShowingEventHandler(this.FilterControl_PopupMenuShowing);
            // 
            // addPatientButton
            // 
            this.addPatientButton.AccessibleDescription = null;
            this.addPatientButton.AccessibleName = null;
            resources.ApplyResources(this.addPatientButton, "addPatientButton");
            this.addPatientButton.BackgroundImage = null;
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Click += new System.EventHandler(this.addPatientButton_Click);
            // 
            // grdProtocolList
            // 
            resources.ApplyResources(this.grdProtocolList, "grdProtocolList");
            this.grdProtocolList.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell10,
            this.xEditGridCell6,
            this.xEditGridCell7});
            this.grdProtocolList.ColPerLine = 2;
            this.grdProtocolList.Cols = 3;
            this.grdProtocolList.ExecuteQuery = null;
            this.grdProtocolList.FixedCols = 1;
            this.grdProtocolList.FixedRows = 1;
            this.grdProtocolList.HeaderHeights.Add(21);
            this.grdProtocolList.Name = "grdProtocolList";
            this.grdProtocolList.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdProtocolList.ParamList")));
            this.grdProtocolList.RowHeaderVisible = true;
            this.grdProtocolList.Rows = 2;
            this.grdProtocolList.ToolTipActive = true;
            this.grdProtocolList.Enter += new System.EventHandler(this.grdProtocolList_Enter);
            this.grdProtocolList.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdProtocolList_RowFocusChanged);
            this.grdProtocolList.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdProtocolList_RowFocusChanging);
            this.grdProtocolList.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdProtocolList_QueryStarting);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "protocol_id";
            this.xEditGridCell10.Col = -1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsVisible = false;
            this.xEditGridCell10.Row = -1;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "protocol_code";
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "protocol_name";
            this.xEditGridCell7.CellWidth = 204;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // grdPatientListJoin
            // 
            resources.ApplyResources(this.grdPatientListJoin, "grdPatientListJoin");
            this.grdPatientListJoin.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell9});
            this.grdPatientListJoin.ColPerLine = 2;
            this.grdPatientListJoin.Cols = 3;
            this.grdPatientListJoin.ExecuteQuery = null;
            this.grdPatientListJoin.FixedCols = 1;
            this.grdPatientListJoin.FixedRows = 1;
            this.grdPatientListJoin.HeaderHeights.Add(21);
            this.grdPatientListJoin.Name = "grdPatientListJoin";
            this.grdPatientListJoin.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPatientListJoin.ParamList")));
            this.grdPatientListJoin.RowHeaderVisible = true;
            this.grdPatientListJoin.Rows = 2;
            this.grdPatientListJoin.ToolTipActive = true;
            this.grdPatientListJoin.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdPatientListJoin_GridColumnChanged);
            this.grdPatientListJoin.Enter += new System.EventHandler(this.grdPatientListJoin_Enter);
            this.grdPatientListJoin.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.patientListJoinGrid_GridFindClick);
            this.grdPatientListJoin.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPatientListJoin_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "patient_code";
            this.xEditGridCell8.Col = 1;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "patient_name";
            this.xEditGridCell9.CellWidth = 161;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.btnList_PostButtonClick);
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // CLIS2015U03
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.grdPatientListJoin);
            this.Controls.Add(this.grdProtocolList);
            this.Controls.Add(this.addPatientButton);
            this.Controls.Add(this.xGroupBox2);
            this.Controls.Add(this.xGroupBox1);
            this.Controls.Add(this.grdPatientList);
            this.Name = "CLIS2015U03";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CLIS2015U03_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CLIS2015U03_ScreenOpen);
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientList)).EndInit();
            this.xGroupBox1.ResumeLayout(false);
            this.xGroupBox1.PerformLayout();
            this.dateComePanel.ResumeLayout(false);
            this.dateComePanel.PerformLayout();
            this.agePanel.ResumeLayout(false);
            this.agePanel.PerformLayout();
            this.clisJoinPanel.ResumeLayout(false);
            this.clisJoinPanel.PerformLayout();
            this.pacermakerPanel.ResumeLayout(false);
            this.pacermakerPanel.PerformLayout();
            this.genderPanel.ResumeLayout(false);
            this.genderPanel.PerformLayout();
            this.xGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocolList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPatientListJoin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Fields & Properties

        private string _diseaseFilterCommand = "";
        private string _drugCommand = "";
        private string _orderListCommand = "";

        #endregion

        #region Constructor

        /// <summary>
        /// CLIS2015U03
        /// </summary>
        public CLIS2015U03()
        {
            InitializeComponent();

            //MED-12914
            ApplyMultiResolution();

            ViewFilterColumnCollection diseaseColumns = new ViewFilterColumnCollection(gridView1);
            diseaseListFilterControl.SetFilterColumnsCollection(diseaseColumns);

            ViewFilterColumnCollection drugColumns = new ViewFilterColumnCollection(gridView2);
            drugListFilterControl.SetFilterColumnsCollection(drugColumns);

            ViewFilterColumnCollection orderColumns = new ViewFilterColumnCollection(gridView3);
            orderListFilterControl.SetFilterColumnsCollection(orderColumns);

            // Set text by Language
            gridColumnSangCode.Caption = Resources.SANG_CODE_TEXT;
            gridColumnSangStartDate.Caption = Resources.SANG_START_DATE_TEXT;
            gridColumnDrugHangmogCode.Caption = Resources.COL_DRUG_CODE_TEXT;
            gridColumnOrderHangmogCode.Caption = Resources.COL_ORDER_CODE_TEXT;
        }

        private void ApplyMultiResolution()
        {
            if (SystemInformation.VirtualScreen.Width == 1366 && SystemInformation.VirtualScreen.Height == 768)
            {
                grdPatientList.Height = 182;
                addPatientButton.Height = 182;
                grdProtocolList.Height = 182;
                grdPatientListJoin.Height = 182;
                this.Height = 595;
                btnList.Location = new System.Drawing.Point(599, 558);
            }
        }

        #endregion

        #region Events

        private void CLIS2015U03_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            // Connect to Cloud
            InitCloud();

            // Default load
            this.InitializeScreen();

            // Load data to grid
            if (grdProtocolList.QueryLayout(true))
            {
                grdProtocolList.SelectRow(0);
                grdPatientListJoin.QueryLayout(true);
                grdPatientList.QueryLayout(true);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            CheckSave();
            if (!ValidateSearch()) return;
            grdPatientList.QueryLayout(true);
        }

        private void addPatientButton_Click(object sender, EventArgs e)
        {
            List<CLIS2015U03CheckPatientRequestInfo> lstCheckItem;
            List<string> lstBunho;

            // No row was found?
            if (grdPatientList.RowCount == 0 || grdProtocolList.RowCount == 0) return;

            // No patient was selected?
            if (!IsPatientSelected(out lstCheckItem, out lstBunho))
            {
                XMessageBox.Show(Resources.MSG_003, Resources.CAP_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CLIS2015U03CheckPatientArgs args = new CLIS2015U03CheckPatientArgs();
            args.CheckItem = lstCheckItem;
            args.HospCode = UserInfo.HospCode;
            CLIS2015U03CheckPatientResult res = CloudService.Instance.Submit<CLIS2015U03CheckPatientResult, CLIS2015U03CheckPatientArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                // Deleted rows storage
                DataTable deletedRowTable = new DataTable();
                deletedRowTable.Columns.Add("patient_code", typeof(string));
                deletedRowTable.Columns.Add("patient_name", typeof(string));

                // Deletes un-selected row in (44)
                int selectedRowNum = 0;
                StringBuilder errMsg = new StringBuilder();
                for (int i = 0; i < grdPatientList.RowCount; i++)
                {
                    if (grdPatientList.GetItemString(i, "select") == "N") continue;

                    if (lstBunho.Contains(grdPatientList.GetItemString(i, "patient_code")))
                    {
                        if (res.ChkResult[selectedRowNum].ChkResult == "N")
                        {
                            // Add deleted rows to a temp. table
                            deletedRowTable.Rows.Add(new object[] { grdPatientList.GetItemString(i, "patient_code"), grdPatientList.GetItemString(i, "patient_name") });
                            grdPatientList.DeleteRow(i);
                            i--;
                        }
                        else
                        {
                            errMsg.AppendLine(string.Format(Resources.MSG_005, grdPatientList.GetItemString(i, "patient_code"), grdPatientList.GetItemString(i, "patient_name")));
                            grdPatientList.SetItemValue(i, "select", "N");
                            grdPatientList.AcceptData();
                            grdPatientList.ResetUpdate();
                        }

                        selectedRowNum++;
                    }

                    // No more loop needed
                    if (selectedRowNum == res.ChkResult.Count) break;
                }

                if (!TypeCheck.IsNull(errMsg.ToString()))
                {
                    XMessageBox.Show(errMsg.ToString(), Resources.CAP_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // Moves rows from (44) to (46)
                int resIdx = 0;
                foreach (DataRow dr in deletedRowTable.Rows)
                {
                    // Add rows to (46), at the end of the list
                    //grdPatientListJoin.SetFocusToItem(grdPatientListJoin.RowCount - 1, 0); // Focus to last row
                    grdPatientListJoin.InsertRow();
                    grdPatientListJoin.SetItemValue(grdPatientListJoin.CurrentRowNumber, "patient_code", dr["patient_code"].ToString());
                    grdPatientListJoin.SetItemValue(grdPatientListJoin.CurrentRowNumber, "patient_name", dr["patient_name"].ToString());
                    resIdx++;
                }
            }
        }

        private void patientListJoinGrid_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XScreen.OpenScreen(this, "OUT0101Q01", ScreenOpenStyle.PopUpFixed);
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    //this.InitializeScreen();
                    this.grdPatientList.QueryLayout(true);
                    this.grdProtocolList.QueryLayout(true);
                    break;
                case FunctionType.Cancel:
                    e.IsBaseCall = false;
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    string errMsg;

                    CLIS2015U03SaveLayoutArgs args = new CLIS2015U03SaveLayoutArgs();
                    args.HospCode = UserInfo.HospCode;
                    args.UserId = UserInfo.UserID;
                    args.PatientListItem = GetListDataForSaveLayout(out errMsg);

                    // Empty check
                    if (!TypeCheck.IsNull(errMsg))
                    {
                        XMessageBox.Show(errMsg, Resources.CAP_003, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (args.PatientListItem.Count > 0)
                    {
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, CLIS2015U03SaveLayoutArgs>(args);
                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                        {
                            // Save successfully
                            XMessageBox.Show(Resources.MSG_013, Resources.CAP_003, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grdPatientListJoin.ResetUpdate();
                        }
                        else
                        {
                            // Save failed
                            XMessageBox.Show(Resources.MSG_014, Resources.CAP_003, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    break;
                //case FunctionType.Close:
                //    CheckSave();
                //    break;
                default:
                    break;
            }
        }

        private void genderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            genderPanel.Enabled = genderCheckBox.Checked;
        }

        private void ageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            agePanel.Enabled = ageCheckBox.Checked;
        }

        private void dateComeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            dateComePanel.Enabled = dateComeCheckBox.Checked;
        }

        private void pacerMakerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            pacermakerPanel.Enabled = pacerMakerCheckBox.Checked;
        }

        private void clisJoiningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            clisJoinPanel.Enabled = clisJoiningCheckBox.Checked;
        }

        private void grdProtocolList_QueryStarting(object sender, CancelEventArgs e)
        {
            grdProtocolList.SetBindVarValue("f_user_id", UserInfo.UserID);
            grdProtocolList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
        }

        private void grdPatientListJoin_QueryStarting(object sender, CancelEventArgs e)
        {
            grdPatientListJoin.SetBindVarValue("f_protocol_id", grdProtocolList.GetItemString(grdProtocolList.CurrentRowNumber, "protocol_id"));
        }

        private void grdPatientList_QueryStarting(object sender, CancelEventArgs e)
        {
            string sex                  = "";
            string ageFrom              = "";
            string ageTo                = "";
            string naewonDtFrom         = "";
            string naewonDtTo           = "";
            string makerYn              = "";
            string join                 = "";
            //string bunho                = "";
            string filterStrOutsang     = "";
            string filterStrOcs1003     = "";
            string filterStrView        = "";
            string filterStrEmr         = "";

            sex = genderCheckBox.Checked ? (maleRadioButton.Checked ? "M" : "F") : "";
            if (ageCheckBox.Checked)
            {
                ageFrom = ageFromTextBox.GetDataValue();
                ageTo = ageToTextBox.GetDataValue();
            }
            if (dateComeCheckBox.Checked)
            {
                naewonDtFrom = dateComeFromDate.GetDataValue();
                naewonDtTo = dateComeToDate.GetDataValue();
            }
            makerYn = pacerMakerCheckBox.Checked ? (usedRadioButton.Checked ? "Y" : "N") : "";
            join = clisJoiningCheckBox.Checked ? (joinedRadioButton.Checked ? "Y" : "N") : "";
            filterStrOutsang = CriteriaToWhereClauseHelper.GetOracleWhere(diseaseListFilterControl.FilterCriteria);
            filterStrOcs1003 = CriteriaToWhereClauseHelper.GetOracleWhere(drugListFilterControl.FilterCriteria);
            filterStrView = CriteriaToWhereClauseHelper.GetOracleWhere(orderListFilterControl.FilterCriteria);

            // TODO
            filterStrEmr = "";

            grdPatientList.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            grdPatientList.SetBindVarValue("f_sex", sex);
            grdPatientList.SetBindVarValue("f_from_age", ageFrom);
            grdPatientList.SetBindVarValue("f_to_age", ageTo);
            grdPatientList.SetBindVarValue("f_naewon_date_from", naewonDtFrom);
            grdPatientList.SetBindVarValue("f_naewon_date_to", naewonDtTo);
            grdPatientList.SetBindVarValue("f_maker_yn", makerYn);
            grdPatientList.SetBindVarValue("f_join", join);
            grdPatientList.SetBindVarValue("f_patient_code", ""); // Not use
            grdPatientList.SetBindVarValue("f_filter_string_outsang", filterStrOutsang);
            grdPatientList.SetBindVarValue("f_filter_string_ocs1003", filterStrOcs1003);
            grdPatientList.SetBindVarValue("f_filter_string_view", filterStrView);
            grdPatientList.SetBindVarValue("f_filter_string_emr", filterStrEmr);
        }

        private void btnList_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:

                    break;
                default:
                    break;
            }
        }

        private void grdProtocolList_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
        }

        private void grdProtocolList_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            CheckSave();
            grdPatientListJoin.QueryLayout(true);
        }

        private void grdProtocolList_Enter(object sender, EventArgs e)
        {
            btnList.SetEnabled(FunctionType.Insert, false);
            btnList.SetEnabled(FunctionType.Delete, false);
        }

        private void grdPatientListJoin_Enter(object sender, EventArgs e)
        {
            btnList.SetEnabled(FunctionType.Insert, true);
            btnList.SetEnabled(FunctionType.Delete, true);
        }

        private void grdPatientList_Enter(object sender, EventArgs e)
        {
            btnList.SetEnabled(FunctionType.Insert, false);
            btnList.SetEnabled(FunctionType.Delete, false);
        }

        private void ageTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void grdPatientListJoin_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (TypeCheck.IsNull(e.ChangeValue))
            {
                return;
            }

            CLIS2015U03PatientListDataValidatingArgs args = new CLIS2015U03PatientListDataValidatingArgs();
            args.Bunho = BizCodeHelper.GetStandardBunHo(e.ChangeValue.ToString());
            args.HospCode = UserInfo.HospCode;
            args.ProtocolId = grdProtocolList.GetItemString(grdProtocolList.CurrentRowNumber, "protocol_id");
            CLIS2015U03PatientListDataValidatingResult res = CloudService.Instance.Submit<CLIS2015U03PatientListDataValidatingResult, CLIS2015U03PatientListDataValidatingArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                // Patient code does not exist
                if (res.ErrMsg == "1")
                {
                    XMessageBox.Show(Resources.MSG_007, Resources.CAP_004, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }

                if (res.ErrMsg == "2") // Patient is joining in another protocol
                {
                    XMessageBox.Show(string.Format(Resources.MSG_009, res.Bunho, res.Suname + " " + res.Suname2), Resources.CAP_002, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                grdPatientListJoin.SetItemValue(e.RowNumber, "patient_code", res.Bunho);
                grdPatientListJoin.SetItemValue(e.RowNumber, "patient_name", res.Suname + " " + res.Suname2);
            }
        }

        private void CLIS2015U03_Closing(object sender, CancelEventArgs e)
        {
            CheckSave();
        }

        private void diseaseListFilterControl_BeforeShowValueEditor(object sender, ShowValueEditorEventArgs e)
        {
            switch (e.CurrentNode.FirstOperand.PropertyName)
            {
                case "OUTSANG.SANG_CODE":
                    CommonItemCollection param = new CommonItemCollection();
                    param.Add("sang_inx", "");
                    param.Add("date", "");
                    param.Add("io_gubun", "");
                    param.Add("user_id", UserInfo.UserID);
                    param.Add("multiSelect", false);
                    XScreen.OpenScreenWithParam(this, "CHTS", "CHT0110Q01", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, param);
                    break;
                case "OUTSANG.SANG_START_DATE":
                    RepositoryItemDateEdit itemDate = new RepositoryItemDateEdit();
                    itemDate.EditMask = "d";
                    e.CustomRepositoryItem = new RepositoryItemDateEdit();
                    break;
                default:
                    break;
            }
        }

        private void drugListFilterControl_BeforeShowValueEditor(object sender, ShowValueEditorEventArgs e)
        {
            if (e.CurrentNode.FirstOperand.PropertyName == "OCS1003.HANGMOG_CODE")
            {
                CommonItemCollection param = new CommonItemCollection();
                param.Add("multiSelection", false);
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, param);
            }
        }

        private void orderListFilterControl_BeforeShowValueEditor(object sender, ShowValueEditorEventArgs e)
        {
            if (e.CurrentNode.FirstOperand.PropertyName == "VW_CPL_TEST_RESULT.HANGMOG_CODE"
                || e.CurrentNode.FirstOperand.PropertyName == "VW_CPL_TEST_RESULT.CPL_RESULT")
            {
                CommonItemCollection param = new CommonItemCollection();
                param.Add("multiSelection", false);
                XScreen.OpenScreenWithParam(this, "OCSA", "OCS0103Q00", ScreenOpenStyle.ResponseFixed, ScreenAlignment.ScreenMiddleCenter, param);
            }
        }

        #region Gets logic expression on FilterControl

        private void diseaseListFilterControl_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            switch (e.CurrentNode.Text)
            {
                case "And":
                    grdPatientList.SetBindVarValue("f_filter_command_outsang", "AND");
                    break;
                case "Or":
                    grdPatientList.SetBindVarValue("f_filter_command_outsang", "OR");
                    break;
                case "NotAnd":
                    // grdPatientList.SetBindVarValue("f_filter_command_outsang", "NOT AND");
                    break;
                case "NotOr":
                    // grdPatientList.SetBindVarValue("f_filter_command_outsang", "NOT OR");
                    break;
                default:
                    break;
            }
        }

        private void drugListFilterControl_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            switch (e.CurrentNode.Text)
            {
                case "And":
                    grdPatientList.SetBindVarValue("f_filter_command_ocs1003", "AND");
                    break;
                case "Or":
                    grdPatientList.SetBindVarValue("f_filter_command_ocs1003", "OR");
                    break;
                case "NotAnd":
                    //grdPatientList.SetBindVarValue("f_filter_command_ocs1003", "NOT AND");
                    break;
                case "NotOr":
                    //grdPatientList.SetBindVarValue("f_filter_command_ocs1003", "NOT OR");
                    break;
                default:
                    break;
            }
        }

        private void orderListFilterControl_FilterChanged(object sender, FilterChangedEventArgs e)
        {
            switch (e.CurrentNode.Text)
            {
                case "And":
                    grdPatientList.SetBindVarValue("f_filter_command_view", "AND");
                    break;
                case "Or":
                    grdPatientList.SetBindVarValue("f_filter_command_view", "OR");
                    break;
                case "NotAnd":
                    // grdPatientList.SetBindVarValue("f_filter_command_view", "NOT AND");
                    break;
                case "NotOr":
                    // grdPatientList.SetBindVarValue("f_filter_command_view", "NOT OR");
                    break;
                default:
                    break;
            }
        }

        #endregion

        private void FilterControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == DevExpress.XtraEditors.Filtering.FilterControlMenuType.Group)
            {
                for (int i = e.Menu.Items.Count - 1; i >= 0; i--)
                {
                    if (e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterGroupNotAnd)
                        || e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterGroupNotOr))
                        e.Menu.Items.RemoveAt(i);
                }
            }
        }

        #endregion

        #region Methods

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "OUT0101":
                    string bunho = ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["bunho"].ToString();
                    string suname = ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["suname"].ToString();
                    string suname2 = ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["suname2"].ToString();

                    grdPatientListJoin.SetItemValue(grdPatientListJoin.CurrentRowNumber, "patient_code", bunho);
                    grdPatientListJoin.SetItemValue(grdPatientListJoin.CurrentRowNumber, "patient_name", suname + " " + suname2);
                    break;
                case "CHT0110Q01":
                    string sangCode = ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["sang_code"].ToString();
                    TextEdit sangTextEdit = diseaseListFilterControl.ActiveEditor as TextEdit;
                    sangTextEdit.EditValue = sangCode;
                    break;
                case "OCS0103Q00":
                    string hangmogCode = ((MultiLayout)commandParam[0]).LayoutTable.Rows[0]["hangmog_code"].ToString();
                    TextEdit hangmogTextEdit = drugListFilterControl.ActiveEditor as TextEdit;
                    if (null == hangmogTextEdit)
                    {
                        hangmogTextEdit = orderListFilterControl.ActiveEditor as TextEdit;
                    }
                    hangmogTextEdit.EditValue = hangmogCode;
                    break;
                default:
                    break;
            }

            return base.Command(command, commandParam);
        }

        private void InitializeScreen()
        {
            DateTime systemDt = EnvironInfo.GetSysDate();

            // (3)
            genderCheckBox.Checked = false;
            genderPanel.Enabled = false;
            // (4)
            maleRadioButton.Checked = true;
            // (10)
            ageCheckBox.Checked = false;
            agePanel.Enabled = false;
            // (11)
            ageFromTextBox.SetDataValue("");
            // (12)
            ageToTextBox.SetDataValue("");
            // (13)
            diseaseListFilterControl.FilterString = "";
            // (14)
            drugListFilterControl.FilterString = "";
            // (29)
            orderListFilterControl.FilterString = "";
            // (15)
            dateComeCheckBox.Checked = true;
            // (16)
            dateComeFromDate.SetDataValue(systemDt.AddMonths(-1));
            // (17)
            dateComeToDate.SetDataValue(systemDt);
            // (18)
            pacerMakerCheckBox.Checked = false;
            pacermakerPanel.Enabled = false;
            // (20)
            notUsedRadioButton.Checked = true;
            // (21)
            clisJoiningCheckBox.Checked = true;
            // (23)
            notJoinedRadioButton.Checked = true;
        }

        private bool ValidateSearch()
        {
            if (ageCheckBox.Checked)
            {
                if (TypeCheck.IsNull(ageFromTextBox.GetDataValue())
                    || TypeCheck.IsNull(ageToTextBox.GetDataValue()))
                {
                    XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (Int32.Parse(ageFromTextBox.GetDataValue()) > Int32.Parse(ageToTextBox.GetDataValue()))
                {
                    XMessageBox.Show(Resources.MSG_001, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (dateComeCheckBox.Checked)
            {
                if (TypeCheck.IsNull(dateComeFromDate.GetDataValue())
                    || TypeCheck.IsNull(dateComeToDate.GetDataValue()))
                {
                    XMessageBox.Show(Resources.MSG_002, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (Int32.Parse(dateComeFromDate.GetDataValue().Replace("/", "")) > Int32.Parse(dateComeToDate.GetDataValue().Replace("/", "")))
                {
                    XMessageBox.Show(Resources.MSG_002, Resources.CAP_001, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private bool IsPatientSelected(out List<CLIS2015U03CheckPatientRequestInfo> lstCheckItem, out List<string> lstBunho)
        {
            lstCheckItem = new List<CLIS2015U03CheckPatientRequestInfo>();
            lstBunho = new List<string>();

            for (int i = 0; i < grdPatientList.RowCount; i++)
            {
                if (grdPatientList.GetItemString(i, "select") == "Y")
                {
                    lstCheckItem.Add(new CLIS2015U03CheckPatientRequestInfo(grdPatientList.GetItemString(i, "patient_code")));
                    lstBunho.Add(grdPatientList.GetItemString(i, "patient_code"));
                }
            }

            return lstCheckItem.Count > 0;
        }

        private void CheckSave()
        {
            // Has deleted rows?
            if (null != grdPatientListJoin.DeletedRowTable && grdPatientListJoin.DeletedRowTable.Rows.Count > 0)
            {
                if (XMessageBox.Show(Resources.MSG_012, Resources.CAP_001, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnList.PerformClick(FunctionType.Update);
                    return;
                }
            }

            for (int i = 0; i < grdPatientListJoin.RowCount; i++)
            {
                if (grdPatientListJoin.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG_012, Resources.CAP_001, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        btnList.PerformClick(FunctionType.Update);
                        return;
                    }

                    return;
                }
            }
        }

        private List<CLIS2015U03PatientListInfo> GetListDataForSaveLayout(out string errMsg)
        {
            errMsg = "";
            List<CLIS2015U03PatientListInfo> lstData = new List<CLIS2015U03PatientListInfo>();

            // For insert/update
            for (int i = 0; i < grdPatientListJoin.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdPatientListJoin.GetRowState(i) == DataRowState.Unchanged) continue;
                // Empty 参加患者番号
                if (TypeCheck.IsNull(grdPatientListJoin.GetItemString(i, "patient_code")))
                {
                    errMsg = Resources.MSG_015;
                    return new List<CLIS2015U03PatientListInfo>();
                }

                CLIS2015U03PatientListInfo item = new CLIS2015U03PatientListInfo();
                item.Bunho = grdPatientListJoin.GetItemString(i, "patient_code");
                item.ClisProtocolId = grdProtocolList.GetItemString(grdProtocolList.CurrentRowNumber, "protocol_id");
                item.RowState = grdPatientListJoin.GetRowState(i).ToString();
                lstData.Add(item);
            }

            // For delete
            if (null != grdPatientListJoin.DeletedRowTable)
            {
                foreach (DataRow dr in grdPatientListJoin.DeletedRowTable.Rows)
                {
                    CLIS2015U03PatientListInfo item = new CLIS2015U03PatientListInfo();
                    item.Bunho = dr["patient_code"].ToString();
                    item.ClisProtocolId = grdProtocolList.GetItemString(grdProtocolList.CurrentRowNumber, "protocol_id");
                    item.RowState = DataRowState.Deleted.ToString();
                    lstData.Add(item);
                }
            }

            return lstData;
        }

        private DataTable LoadGrdCHT0110M()
        {
            DataTable lookupTbl = new DataTable();
            DataColumn sangCdCol = new DataColumn("傷病コード", typeof(string));
            DataColumn sangNmCol = new DataColumn("傷病コード名称(漢字)", typeof(string));
            DataColumn sangNmHanCol = new DataColumn("傷病コード名称(ｶﾅ)", typeof(string));
            //DataColumn sangNmSelfCol        = new DataColumn("sang_name_self", typeof(string));
            //DataColumn sangNmInxCol         = new DataColumn("sang_name_inx", typeof(string));
            DataColumn jukyongDateCol = new DataColumn("適用日付", typeof(string));
            //DataColumn bulyongYnCol         = new DataColumn("不用日付", typeof(string));
            DataColumn sugaSangCodeCol = new DataColumn("ICD10", typeof(string));
            DataColumn sugaSangNmCol = new DataColumn("ICD10名", typeof(string));
            DataColumn junyeomBunryuCol = new DataColumn("伝染病詳細分類", typeof(string));
            DataColumn junyeonKindCol = new DataColumn("伝染病申告入力書式", typeof(string));
            DataColumn samangSangGroupCol = new DataColumn("死亡グループ", typeof(string));
            DataColumn samangSangGroupNmCol = new DataColumn("死亡グループ傷病コード名称", typeof(string));
            DataColumn rankCol = new DataColumn("ﾗﾝｸ", typeof(string));
            //DataColumn selectCol            = new DataColumn("選択", typeof(string));

            lookupTbl.Columns.AddRange(new DataColumn[]
            {
                sangCdCol,
                sangNmCol,
                sangNmHanCol,
                //sangNmSelfCol,
                //sangNmInxCol,
                jukyongDateCol,
                //bulyongYnCol,
                sugaSangCodeCol,
                sugaSangNmCol,
                junyeomBunryuCol,
                junyeonKindCol,
                samangSangGroupCol,
                samangSangGroupNmCol,
                rankCol,
                //selectCol,
            });

            CHT0110Q01GrdCHT0110MListArgs args = new CHT0110Q01GrdCHT0110MListArgs();
            args.SangInx = "";
            args.Date = "";
            args.IoGubun = "";
            args.UserId = UserInfo.UserID;
            CHT0110Q01GrdCHT0110MListResult result = CloudService.Instance.Submit<CHT0110Q01GrdCHT0110MListResult, CHT0110Q01GrdCHT0110MListArgs>(args);

            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CHT0110Q01GrdCHT0110MListInfo item in result.GrdListItem)
                {
                    lookupTbl.Rows.Add(new object[]
                    {
                        item.SangCode,
                        item.SangName,
                        item.SangNameHan,
                        item.StartDate,
                        item.SugaSangCode,
                        item.SugaSangName,
                        item.JunyeomBunryu,
                        item.JunyeomKind,
                        item.SamangSangGroup,
                        item.SamangGroupName,
                        item.RankCnt,
                    });
                }
            }

            return lookupTbl;
        }

        #endregion

        #region CloudConnector

        #region InitCloud
        /// <summary>
        /// InitCloud
        /// </summary>
        private void InitCloud()
        {
            // grdProtocolList
            grdProtocolList.ParamList = new List<string>(new string[] { "f_user_id", "f_hosp_code" });
            grdProtocolList.ExecuteQuery = GetGrdProtocolList;

            // grdPatientListJoin
            grdPatientListJoin.ParamList = new List<string>(new string[] { "f_protocol_id" });
            grdPatientListJoin.ExecuteQuery = GetGrdPatientListDefault;

            // grdPatientList
            grdPatientList.ParamList = new List<string>(new string[]
                {
                    "f_hosp_code",
                    "f_sex",
                    "f_from_age",
                    "f_to_age",
                    "f_naewon_date_from",
                    "f_naewon_date_to",
                    "f_maker_yn",
                    "f_join",
                    "f_patient_code",
                    "f_filter_string_outsang",
                    "f_filter_string_ocs1003",
                    "f_filter_string_view",
                    "f_filter_string_emr",
                    "f_filter_command_outsang",
                    "f_filter_command_ocs1003",
                    "f_filter_command_view",
                });
            grdPatientList.ExecuteQuery = GetGrdPatientList;
            // Default search command: AND
            grdPatientList.SetBindVarValue("f_filter_command_outsang", "AND");
            grdPatientList.SetBindVarValue("f_filter_command_ocs1003", "AND");
            grdPatientList.SetBindVarValue("f_filter_command_view", "AND");
        }
        #endregion

        #region GetGrdPatientListDefault
        /// <summary>
        /// GetGrdPatientListDefault
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPatientListDefault(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CLIS2015U03PatientListArgs args = new CLIS2015U03PatientListArgs();
            args.ProtocolId = bvc["f_protocol_id"].VarValue;
            CLIS2015U03PatientListResult res = CloudService.Instance.Submit<CLIS2015U03PatientListResult, CLIS2015U03PatientListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.PatientListItem.ForEach(delegate(CLIS2015U03PatientListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.Bunho,
                        //item.Surname,
                        //item.Surname2,
                        item.FullName,
                        //item.Sex,
                        //item.Birth,
                        //item.ClisProtocolId,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdProtocolList
        /// <summary>
        /// GetGrdProtocolList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdProtocolList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CLIS2015U03ProtocolListArgs args = new CLIS2015U03ProtocolListArgs();
            args.HospCode = bvc["f_hosp_code"].VarValue;
            args.UserId = bvc["f_user_id"].VarValue;
            CLIS2015U03ProtocolListResult res = CloudService.Instance.Submit<CLIS2015U03ProtocolListResult, CLIS2015U03ProtocolListArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ProtocolListItem.ForEach(delegate(CLIS2015U03ProtocolListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.ClisProtocolId,
                        item.ProtocolCode,
                        item.ProtocolName,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdPatientList
        /// <summary>
        /// GetGrdPatientList
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdPatientList(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CLIS2015U03SearchPatientArgs args   = new CLIS2015U03SearchPatientArgs();
            args.HospCode                       = bvc["f_hosp_code"].VarValue;
            args.Sex                            = bvc["f_sex"].VarValue;
            args.FromAge                        = bvc["f_from_age"].VarValue;
            args.ToAge                          = bvc["f_to_age"].VarValue;
            args.NaewonDateFrom                 = bvc["f_naewon_date_from"].VarValue;
            args.NaewonDateTo                   = bvc["f_naewon_date_to"].VarValue;
            args.MakerYn                        = bvc["f_maker_yn"].VarValue;
            args.Join                           = bvc["f_join"].VarValue;
            args.PatientCode                    = bvc["f_patient_code"].VarValue;
            args.FilterStringOutsang            = bvc["f_filter_string_outsang"].VarValue;
            args.FilterStringOcs1003            = bvc["f_filter_string_ocs1003"].VarValue;
            args.FilterStringView               = bvc["f_filter_string_view"].VarValue;
            args.FilterStringEmr                = bvc["f_filter_string_emr"].VarValue;
            // updated 2015.11.09 by AnhNV
            args.FilterCommandOutsang           = bvc["f_filter_command_outsang"].VarValue;
            args.FilterCommandOcs1003           = bvc["f_filter_command_ocs1003"].VarValue;
            args.FilterCommandView              = bvc["f_filter_command_view"].VarValue;
            CLIS2015U03SearchPatientResult res = CloudService.Instance.Submit<CLIS2015U03SearchPatientResult, CLIS2015U03SearchPatientArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.PatientListItem.ForEach(delegate(CLIS2015U03PatientListInfo item)
                {
                    lObj.Add(new object[]
                    {
                        "N",
                        item.Bunho,
                        //item.Surname,
                        //item.Surname2,
                        item.FullName,
                        item.Birth,
                        item.Sex == "M" ? Resources.SEX_MALE : Resources.SEX_FEMALE,
                        item.ClisProtocolId,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #endregion
    }
}