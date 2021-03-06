using System;
using System.Collections.Generic;
using System.Text;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Clis;
using IHIS.CloudConnector.Contracts.Results.Clis;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Clis;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using GhostscriptSharp;
using System.Diagnostics;
using IHIS.CLIS.Properties;
using IHIS.CloudConnector.Utility;

namespace IHIS.CLIS
{
    public class CLIS2015U02 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel5;
        private IHIS.Framework.XTextBox txtProtocolCode;
        private IHIS.Framework.XTextBox txtProtocolName;
        private IHIS.Framework.XButton btnSearch;
        private IHIS.Framework.XDatePicker dtpFromDate;
        private IHIS.Framework.XDatePicker dtpToDate;
        private IHIS.Framework.XEditGrid grdProtocol;
        private IHIS.Framework.XEditGrid grdStatus;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XButton btnBrowse;
        private IHIS.Framework.XPictureBox xPictureBox1;
        private IHIS.Framework.XButton btnPatientList;
        private IHIS.Framework.XButtonList xButtonList1;
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
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XPanel xPanel1;

        private string mBunho = "";
        private string mHospcode = "";
        private XDictComboBox cboStatus;
        private XEditGridCell xEditGridCell13;
        private string mModuleType = "";
        private XEditGridCell xEditGridCell14;
        private int mAutoInsertCnt = 0;
        private string mFileName = "";
        private string mNewName = "";
        private string mFilePath = Application.StartupPath + "\\" + "REHA" + "Images" + "\\" + "REHA";
        private XEditGrid grdTrialDrg;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private SplitContainer containerParent;
        private XButton btnDown;
        private XButton btnUp;
        private SplitContainer containerLeft;
        private bool imageChanged = false;

        public CLIS2015U02()
        {
            InitializeComponent();

            //Set ParamList for controls
            grdProtocol.ParamList = new List<string>(new String[] { "f_protocol_code", "f_protocol_name", "f_from_date", "f_to_date", "f_protocol_status", "f_patient_code" });
            grdStatus.ParamList = new List<string>(new String[] { "f_protocol_id" });
            grdTrialDrg.ParamList = new List<string>(new String[] { "f_protocol_id", "f_page_number" });

            //Set ExecuteQuery for controls
            this.grdProtocol.ExecuteQuery = LoadDataGrdProtocol;
            this.grdStatus.ExecuteQuery = LoadDataGrdStatus;
            this.grdTrialDrg.ExecuteQuery = LoadDataGrdTrialDrg;
            this.cboStatus.ExecuteQuery = LoadDataCboStatus;
            this.cboStatus.SetDictDDLB();
            //Open popup from OCSEMR disable control
            if (OpenParam != null)
            {
                HideControl(this);
            }
            
        }
        private void HideControl(Control item)
        {
           
                foreach (Control c in item.Controls)
                {
                    c.Enabled = false;
                }
            
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIS2015U02));
            this.containerParent = new System.Windows.Forms.SplitContainer();
            this.containerLeft = new System.Windows.Forms.SplitContainer();
            this.grdProtocol = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.grdTrialDrg = new IHIS.Framework.XEditGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.btnDown = new IHIS.Framework.XButton();
            this.btnUp = new IHIS.Framework.XButton();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.btnBrowse = new IHIS.Framework.XButton();
            this.xPictureBox1 = new IHIS.Framework.XPictureBox();
            this.grdStatus = new IHIS.Framework.XEditGrid();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.cboStatus = new IHIS.Framework.XDictComboBox();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.btnSearch = new IHIS.Framework.XButton();
            this.txtProtocolName = new IHIS.Framework.XTextBox();
            this.txtProtocolCode = new IHIS.Framework.XTextBox();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.btnPatientList = new IHIS.Framework.XButton();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.containerParent.Panel1.SuspendLayout();
            this.containerParent.Panel2.SuspendLayout();
            this.containerParent.SuspendLayout();
            this.containerLeft.Panel1.SuspendLayout();
            this.containerLeft.Panel2.SuspendLayout();
            this.containerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrialDrg)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).BeginInit();
            this.xPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // containerParent
            // 
            this.containerParent.AccessibleDescription = null;
            this.containerParent.AccessibleName = null;
            resources.ApplyResources(this.containerParent, "containerParent");
            this.containerParent.BackgroundImage = null;
            this.containerParent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.containerParent.Font = null;
            this.containerParent.Name = "containerParent";
            // 
            // containerParent.Panel1
            // 
            this.containerParent.Panel1.AccessibleDescription = null;
            this.containerParent.Panel1.AccessibleName = null;
            resources.ApplyResources(this.containerParent.Panel1, "containerParent.Panel1");
            this.containerParent.Panel1.BackgroundImage = null;
            this.containerParent.Panel1.Controls.Add(this.containerLeft);
            this.containerParent.Panel1.Font = null;
            // 
            // containerParent.Panel2
            // 
            this.containerParent.Panel2.AccessibleDescription = null;
            this.containerParent.Panel2.AccessibleName = null;
            resources.ApplyResources(this.containerParent.Panel2, "containerParent.Panel2");
            this.containerParent.Panel2.BackgroundImage = null;
            this.containerParent.Panel2.Controls.Add(this.btnDown);
            this.containerParent.Panel2.Controls.Add(this.btnUp);
            this.containerParent.Panel2.Controls.Add(this.xPanel2);
            this.containerParent.Panel2.Controls.Add(this.grdStatus);
            this.containerParent.Panel2.Font = null;
            // 
            // containerLeft
            // 
            this.containerLeft.AccessibleDescription = null;
            this.containerLeft.AccessibleName = null;
            resources.ApplyResources(this.containerLeft, "containerLeft");
            this.containerLeft.BackgroundImage = null;
            this.containerLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.containerLeft.Font = null;
            this.containerLeft.Name = "containerLeft";
            // 
            // containerLeft.Panel1
            // 
            this.containerLeft.Panel1.AccessibleDescription = null;
            this.containerLeft.Panel1.AccessibleName = null;
            resources.ApplyResources(this.containerLeft.Panel1, "containerLeft.Panel1");
            this.containerLeft.Panel1.BackgroundImage = null;
            this.containerLeft.Panel1.Controls.Add(this.grdProtocol);
            this.containerLeft.Panel1.Font = null;
            // 
            // containerLeft.Panel2
            // 
            this.containerLeft.Panel2.AccessibleDescription = null;
            this.containerLeft.Panel2.AccessibleName = null;
            resources.ApplyResources(this.containerLeft.Panel2, "containerLeft.Panel2");
            this.containerLeft.Panel2.BackgroundImage = null;
            this.containerLeft.Panel2.Controls.Add(this.grdTrialDrg);
            this.containerLeft.Panel2.Font = null;
            // 
            // grdProtocol
            // 
            resources.ApplyResources(this.grdProtocol, "grdProtocol");
            this.grdProtocol.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell13});
            this.grdProtocol.ColPerLine = 6;
            this.grdProtocol.Cols = 7;
            this.grdProtocol.ExecuteQuery = null;
            this.grdProtocol.FixedCols = 1;
            this.grdProtocol.FixedRows = 1;
            this.grdProtocol.HeaderHeights.Add(21);
            this.grdProtocol.Name = "grdProtocol";
            this.grdProtocol.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdProtocol.ParamList")));
            this.grdProtocol.RowHeaderVisible = true;
            this.grdProtocol.Rows = 2;
            this.grdProtocol.ToolTipActive = true;
            this.grdProtocol.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdProtocol_GridColumnChanged);
            this.grdProtocol.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdProtocol_RowFocusChanged);
            this.grdProtocol.PreEndInitializing += new System.EventHandler(this.grdProtocol_PreEndInitializing);
            this.grdProtocol.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdProtocol_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "protocol_id";
            this.xEditGridCell1.Col = -1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsVisible = false;
            this.xEditGridCell1.Row = -1;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "protocol_code";
            this.xEditGridCell2.CellWidth = 92;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "protocol_name";
            this.xEditGridCell3.CellWidth = 128;
            this.xEditGridCell3.Col = 2;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "from_date";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell4.CellWidth = 125;
            this.xEditGridCell4.Col = 3;
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "to_date";
            this.xEditGridCell5.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell5.CellWidth = 119;
            this.xEditGridCell5.Col = 4;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "protocol_status";
            this.xEditGridCell6.CellWidth = 111;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 255;
            this.xEditGridCell7.CellName = "description";
            this.xEditGridCell7.CellWidth = 108;
            this.xEditGridCell7.Col = 6;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "resource";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            // 
            // grdTrialDrg
            // 
            resources.ApplyResources(this.grdTrialDrg, "grdTrialDrg");
            this.grdTrialDrg.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell16});
            this.grdTrialDrg.ColPerLine = 2;
            this.grdTrialDrg.Cols = 3;
            this.grdTrialDrg.ExecuteQuery = null;
            this.grdTrialDrg.FixedCols = 1;
            this.grdTrialDrg.FixedRows = 1;
            this.grdTrialDrg.HeaderHeights.Add(21);
            this.grdTrialDrg.Name = "grdTrialDrg";
            this.grdTrialDrg.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdTrialDrg.ParamList")));
            this.grdTrialDrg.RowHeaderVisible = true;
            this.grdTrialDrg.Rows = 2;
            this.grdTrialDrg.ToolTipActive = true;
            this.grdTrialDrg.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdTrialDrg_QueryStarting);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.CellName = "drug_code";
            this.xEditGridCell15.CellWidth = 138;
            this.xEditGridCell15.Col = 1;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsUpdatable = false;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "drug_name";
            this.xEditGridCell16.CellWidth = 140;
            this.xEditGridCell16.Col = 2;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            // 
            // btnDown
            // 
            this.btnDown.AccessibleDescription = null;
            this.btnDown.AccessibleName = null;
            resources.ApplyResources(this.btnDown, "btnDown");
            this.btnDown.BackgroundImage = null;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Name = "btnDown";
            // 
            // btnUp
            // 
            this.btnUp.AccessibleDescription = null;
            this.btnUp.AccessibleName = null;
            resources.ApplyResources(this.btnUp, "btnUp");
            this.btnUp.BackgroundImage = null;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.Name = "btnUp";
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.btnBrowse);
            this.xPanel2.Controls.Add(this.xPictureBox1);
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // btnBrowse
            // 
            this.btnBrowse.AccessibleDescription = null;
            this.btnBrowse.AccessibleName = null;
            resources.ApplyResources(this.btnBrowse, "btnBrowse");
            this.btnBrowse.BackgroundImage = null;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // xPictureBox1
            // 
            this.xPictureBox1.AccessibleDescription = null;
            this.xPictureBox1.AccessibleName = null;
            resources.ApplyResources(this.xPictureBox1, "xPictureBox1");
            this.xPictureBox1.BackColor = IHIS.Framework.XColor.XMonthCalendarBackColor;
            this.xPictureBox1.BackgroundImage = null;
            this.xPictureBox1.Font = null;
            this.xPictureBox1.ImageLocation = null;
            this.xPictureBox1.Name = "xPictureBox1";
            this.xPictureBox1.Protect = false;
            this.xPictureBox1.TabStop = false;
            this.xPictureBox1.DoubleClick += new System.EventHandler(this.xPictureBox1_DoubleClick);
            // 
            // grdStatus
            // 
            resources.ApplyResources(this.grdStatus, "grdStatus");
            this.grdStatus.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell14,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12});
            this.grdStatus.ColPerLine = 2;
            this.grdStatus.Cols = 3;
            this.grdStatus.ExecuteQuery = null;
            this.grdStatus.FixedCols = 1;
            this.grdStatus.FixedRows = 1;
            this.grdStatus.HeaderHeights.Add(46);
            this.grdStatus.Name = "grdStatus";
            this.grdStatus.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdStatus.ParamList")));
            this.grdStatus.RowHeaderVisible = true;
            this.grdStatus.Rows = 2;
            this.grdStatus.ToolTipActive = true;
            this.grdStatus.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdStatus_QueryStarting);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "protocol_id";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "status_id";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "status_code";
            this.xEditGridCell14.Col = -1;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsVisible = false;
            this.xEditGridCell14.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "status_name";
            this.xEditGridCell10.CellWidth = 182;
            this.xEditGridCell10.Col = 1;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdatable = false;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "sort_no";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "display_flg";
            this.xEditGridCell12.CellWidth = 108;
            this.xEditGridCell12.Col = 2;
            this.xEditGridCell12.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.cboStatus);
            this.xPanel1.Controls.Add(this.dtpToDate);
            this.xPanel1.Controls.Add(this.dtpFromDate);
            this.xPanel1.Controls.Add(this.btnSearch);
            this.xPanel1.Controls.Add(this.txtProtocolName);
            this.xPanel1.Controls.Add(this.txtProtocolCode);
            this.xPanel1.Controls.Add(this.xLabel5);
            this.xPanel1.Controls.Add(this.xLabel4);
            this.xPanel1.Controls.Add(this.xLabel3);
            this.xPanel1.Controls.Add(this.xLabel2);
            this.xPanel1.Controls.Add(this.xLabel1);
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // cboStatus
            // 
            this.cboStatus.AccessibleDescription = null;
            this.cboStatus.AccessibleName = null;
            resources.ApplyResources(this.cboStatus, "cboStatus");
            this.cboStatus.BackgroundImage = null;
            this.cboStatus.ExecuteQuery = null;
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboStatus.ParamList")));
            this.cboStatus.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // dtpToDate
            // 
            this.dtpToDate.AccessibleDescription = null;
            this.dtpToDate.AccessibleName = null;
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.BackgroundImage = null;
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpToDate_DataValidating);
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
            // btnSearch
            // 
            this.btnSearch.AccessibleDescription = null;
            this.btnSearch.AccessibleName = null;
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.BackgroundImage = null;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtProtocolName
            // 
            this.txtProtocolName.AccessibleDescription = null;
            this.txtProtocolName.AccessibleName = null;
            resources.ApplyResources(this.txtProtocolName, "txtProtocolName");
            this.txtProtocolName.BackgroundImage = null;
            this.txtProtocolName.Name = "txtProtocolName";
            // 
            // txtProtocolCode
            // 
            this.txtProtocolCode.AccessibleDescription = null;
            this.txtProtocolCode.AccessibleName = null;
            resources.ApplyResources(this.txtProtocolCode, "txtProtocolCode");
            this.txtProtocolCode.BackgroundImage = null;
            this.txtProtocolCode.Name = "txtProtocolCode";
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
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // btnPatientList
            // 
            this.btnPatientList.AccessibleDescription = null;
            this.btnPatientList.AccessibleName = null;
            resources.ApplyResources(this.btnPatientList, "btnPatientList");
            this.btnPatientList.BackgroundImage = null;
            this.btnPatientList.Name = "btnPatientList";
            this.btnPatientList.Click += new System.EventHandler(this.btnPatientList_Click);
            // 
            // xButtonList1
            // 
            this.xButtonList1.AccessibleDescription = null;
            this.xButtonList1.AccessibleName = null;
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.BackgroundImage = null;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.PostButtonClick += new IHIS.Framework.PostButtonClickEventHandler(this.xButtonList1_PostButtonClick);
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // CLIS2015U02
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.containerParent);
            this.Controls.Add(this.xButtonList1);
            this.Controls.Add(this.btnPatientList);
            this.Controls.Add(this.xPanel1);
            this.Name = "CLIS2015U02";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CLIS2015U02_Closing);
            this.ScreenOpen += new IHIS.Framework.XScreenOpenEventHandler(this.CLIS2015U02_ScreenOpen);
            this.containerParent.Panel1.ResumeLayout(false);
            this.containerParent.Panel2.ResumeLayout(false);
            this.containerParent.ResumeLayout(false);
            this.containerLeft.Panel1.ResumeLayout(false);
            this.containerLeft.Panel2.ResumeLayout(false);
            this.containerLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProtocol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTrialDrg)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStatus)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Screen Open
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CLIS2015U02_ScreenOpen(object sender, IHIS.Framework.XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null && this.OpenParam.Contains("f_bunho"))
            {
                this.mBunho = this.OpenParam["f_bunho"].ToString();
            }
            this.mHospcode = UserInfo.HospCode;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdProtocol.QueryLayout(true);
        }

        #region CloudService

        /// <summary>
        /// get data for grdProtocol
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdProtocol(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U02GrdProtocolArgs args = new CLIS2015U02GrdProtocolArgs();
            args.ProtocolCode = bc["f_protocol_code"] != null ? bc["f_protocol_code"].VarValue : "";
            args.ProtocolName = bc["f_protocol_name"] != null ? bc["f_protocol_name"].VarValue : "";
            args.FromDate = bc["f_from_date"] != null ? bc["f_from_date"].VarValue : "";
            args.ToDate = bc["f_to_date"] != null ? bc["f_to_date"].VarValue : "";
            args.ProtocolStatus = bc["f_protocol_status"] != null ? bc["f_protocol_status"].VarValue : "";
            args.PatientCode = bc["f_patient_code"] != null ? bc["f_patient_code"].VarValue : "";
            CLIS2015U02GrdProtocolResult result = CloudService.Instance.Submit<CLIS2015U02GrdProtocolResult, CLIS2015U02GrdProtocolArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U02GrdProtocolInfo item in result.GrdProtocolList)
                {
                    object[] objects = 
				    { 
					    item.ProtocolId, 
					    item.ProtocolCode, 
					    item.ProtocolName, 
					    item.FromDate, 
					    item.ToDate, 
					    item.ProtocolStatus, 
					    item.Description,
                        item.Resource
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for grdStatus
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdStatus(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U02GrdStatusArgs args = new CLIS2015U02GrdStatusArgs();
            args.ProtocolId = bc["f_protocol_id"] != null ? bc["f_protocol_id"].VarValue : "";
            CLIS2015U02GrdStatusResult result = CloudService.Instance.Submit<CLIS2015U02GrdStatusResult, CLIS2015U02GrdStatusArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CLIS2015U02GrdStatusInfo item in result.GrdStatusList)
                {
                    object[] objects = 
				    { 
					    item.ProtocolId, 
					    item.StatusId, 
                        item.StatusCode,
					    item.StatusName, 
					    item.SortNo, 
					    item.DisplayFlg
				    };
                        res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for grdTrialDrg
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdTrialDrg(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U02GrdTrialDrgArgs args = new CLIS2015U02GrdTrialDrgArgs();
            args.ProtocolId = bc["f_protocol_id"] != null ? bc["f_protocol_id"].VarValue : "";
            args.PageNumber = bc["f_page_number"] != null ? bc["f_page_number"].VarValue : "";
            args.Offset = "200";
            CLIS2015U02GrdTrialDrgResult result = CloudService.Instance.Submit<CLIS2015U02GrdTrialDrgResult, CLIS2015U02GrdTrialDrgArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.GrdList)
                {
                    object[] objects = 
				    { 
					    item.Code, 
					    item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for cboStatus
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataCboStatus(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U02CboStatusArgs args = new CLIS2015U02CboStatusArgs();
            args.IsAll = true;
            ComboResult result = CloudService.Instance.Submit<ComboResult, CLIS2015U02CboStatusArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				    { 
					    item.Code,
                        item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// get data for XEditGridCell6
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataXEditGridCell6(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CLIS2015U02CboStatusArgs args = new CLIS2015U02CboStatusArgs();
            args.IsAll = false;
            ComboResult result = CloudService.Instance.Submit<ComboResult, CLIS2015U02CboStatusArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.ComboItem)
                {
                    object[] objects = 
				    { 
					    item.Code,
                        item.CodeName
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        /// <summary>
        /// turn datarow of grdStatus to a list of object
        /// </summary>
        /// <returns>List<CLIS2015U02GrdStatusInfo></returns>
        private List<CLIS2015U02GrdStatusInfo> GetListStatus()
        {
            List<CLIS2015U02GrdStatusInfo> inputList = new List<CLIS2015U02GrdStatusInfo>();
            for (int i = 0; i < grdStatus.RowCount; i++)
            {
                if (grdStatus.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                CLIS2015U02GrdStatusInfo info = new CLIS2015U02GrdStatusInfo();
                info.ProtocolId = grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id");
                info.StatusId = grdStatus.GetItemString(i, "status_id");
                info.StatusCode = grdStatus.GetItemString(i, "status_code");
                info.StatusName = grdStatus.GetItemString(i, "status_name");
                info.SortNo = grdStatus.GetItemString(i, "sort_no");
                //info.SortNo = "1";
                info.DisplayFlg = grdStatus.GetItemString(i, "display_flg");
                info.RowState = grdStatus.GetRowState(i).ToString();

                inputList.Add(info);
            }

            return inputList;
        }

        /// <summary>
        /// turn datarow of grdProtocol to an object
        /// </summary>
        /// <returns>CLIS2015U02GrdProtocolInfo</returns>
        private CLIS2015U02GrdProtocolInfo GetListProtocol()
        {
            CLIS2015U02GrdProtocolInfo info = new CLIS2015U02GrdProtocolInfo();
            for (int i = 0; i < grdProtocol.RowCount; i++)
            {
                if (grdProtocol.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                info.ProtocolId = grdProtocol.GetItemString(i, "protocol_id");
                info.ProtocolCode = grdProtocol.GetItemString(i, "protocol_code");
                info.ProtocolName = grdProtocol.GetItemString(i, "protocol_name");
                info.FromDate = grdProtocol.GetItemString(i, "from_date");
                info.ToDate = grdProtocol.GetItemString(i, "to_date");
                info.ProtocolStatus = grdProtocol.GetItemString(i, "protocol_status");
                info.Description = grdProtocol.GetItemString(i, "description");
                info.Resource = grdProtocol.GetItemString(i, "resource");
                info.RowState = grdProtocol.GetRowState(i).ToString();
                break;
            }
            if (grdProtocol.DeletedRowCount > 0)
            {
                info.ProtocolId = grdProtocol.DeletedRowTable.Rows[0]["protocol_id"].ToString();
                info.ProtocolCode = grdProtocol.DeletedRowTable.Rows[0]["protocol_code"].ToString();
                info.RowState = DataRowState.Deleted.ToString();
            }
            return info;
        }

        #endregion

        /// <summary>
        /// Pre-End initializing of grdProtocol
        /// set executeQuery for xEditGridCell6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProtocol_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell6.ExecuteQuery = LoadDataXEditGridCell6;
        }

        /// <summary>
        /// grdProtocol_QueryStarting
        /// set param value for grdProtocol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProtocol_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdProtocol.SetBindVarValue("f_protocol_code", !String.IsNullOrEmpty(txtProtocolCode.Text) ? txtProtocolCode.Text : "");
            grdProtocol.SetBindVarValue("f_protocol_name", !String.IsNullOrEmpty(txtProtocolName.Text) ? txtProtocolName.Text : "");
            grdProtocol.SetBindVarValue("f_from_date", dtpFromDate.GetDataValue());
            grdProtocol.SetBindVarValue("f_to_date", dtpToDate.GetDataValue());
            //grdProtocol.SetBindVarValue("f_protocol_status", !String.IsNullOrEmpty(cboStatus.SelectedValue.ToString()) ? cboStatus.SelectedValue.ToString() : "");
            grdProtocol.SetBindVarValue("f_patient_code", !String.IsNullOrEmpty(mBunho) ? mBunho : "");
            if (null != cboStatus.SelectedValue)
            {
                grdProtocol.SetBindVarValue("f_protocol_status", cboStatus.SelectedValue.ToString());
            }
        }

        /// <summary>
        /// grdStatus_QueryStarting
        /// set param value for grdStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdStatus_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdStatus.SetBindVarValue("f_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));
        }

        /// <summary>
        /// grdProtocol_RowFocusChanged
        /// Get data for grdStatus
        /// Download image from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProtocol_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            try
            {
                if (grdProtocol.GetRowState(grdProtocol.CurrentRowNumber) != DataRowState.Added)
                {
                    grdStatus.QueryLayout(true);
                    grdTrialDrg.QueryLayout(false);

                    //download from server
                    mFileName = grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "resource");
                    if (!String.IsNullOrEmpty(mFileName))
                    {
                        string downLoadFilePath = IHIS.Framework.Utilities.ConvertToLocalPath(mFilePath + "\\" + mFileName);
                        if (File.Exists(downLoadFilePath))
                        {
                            this.PreviewPicture(downLoadFilePath);
                        }
                        else 
                        {
                            int type = (int)Utilities.TransferType.ProtocolImage;
                            Utilities.DownloadFile(downLoadFilePath, mHospcode, grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"),
                                type.ToString());
                            if (File.Exists(downLoadFilePath))
                            {
                                this.PreviewPicture(downLoadFilePath);
                            }
                            else
                            {
                                this.xPictureBox1.ResetData();
                                this.mFileName = String.Empty;
                            }
                        }
                    }
                    else
                    {
                        this.xPictureBox1.ResetData();
                        this.mFileName = String.Empty;
                    }
                }
                else
                {
                    AutoGenerateGrdStatus();
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CLIS_MSG001, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.xButtonList1.PerformClick(FunctionType.Query);
        }

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    this.grdProtocol.QueryLayout(true);
                    break;
                case FunctionType.Delete:
                    
                    break;
                case FunctionType.Reset:
                    e.IsBaseCall = false;
                    this.Reset();
                    break;
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = false;
                    String msg = ValidateGrdProtocol();
                    if (msg != "")
                    {
                        XMessageBox.Show(msg, Resources.CLIS_MSG001, System.Windows.Forms.MessageBoxIcon.Error);
                        break;
                    }
                    this.ReMakeSortNo();
                    CLIS2015U02SaveLayoutArgs args = new CLIS2015U02SaveLayoutArgs();
                    args.GrdProtocolList = GetListProtocol();
                    args.GrdStatusList = GetListStatus();
                    if (String.IsNullOrEmpty(args.GrdProtocolList.ProtocolCode) && args.GrdStatusList.Count == 0)
                    {
                        e.IsSuccess = true;
                        break;
                    }
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, CLIS2015U02SaveLayoutArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result == true)
                    {
                        if (imageChanged)
                        {
                            e.IsSuccess = UploadData();
                            if(!e.IsSuccess)
                                XMessageBox.Show(Resources.CLIS_MSG017, Resources.CLIS_MSG001, System.Windows.Forms.MessageBoxIcon.Error);
                        }
                        else
                        {
                            e.IsSuccess = true;
                        }
                    }
                    else
                    {
                        e.IsSuccess = false;
                        if(result.Msg == "CMO_M002")
                            XMessageBox.Show(Resources.CLIS_MSG018, Resources.CLIS_MSG001, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    break;
                case FunctionType.Insert:
                    this.mFileName = String.Empty;
                    this.xPictureBox1.ResetData();
                    break;

            }
        }

        /// <summary>
        /// Save file to disk and upload to server
        /// </summary>
        /// <returns></returns>
        private bool UploadData()
        {
            try
            {
                if (mFileName != "")
                {
                    //save file
                    File.Copy(Path.GetFullPath(mFileName), Utilities.ConvertToLocalPath(mFilePath + "\\" + mFileName));
                    //rename
                    File.Move(Utilities.ConvertToLocalPath(mFilePath + "\\" + mFileName), Utilities.ConvertToLocalPath(mFilePath + "\\" + mNewName));
                    mFileName = mNewName;
                    //upLoad
                    string fileName = mFilePath + "\\" + mFileName;

                    // MED-10181
                    //string uploadAddress = IHIS.Framework.Utilities.GetFileConfig("UploadBaseUri");
                    string uploadAddress = Utility.GetConfig("UploadBaseUri", UserInfo.VpnYn);

                    string uploadToken = IHIS.Framework.Utilities.GetFileConfig("UploadToken");
                    Uri address = new Uri(uploadAddress);
                    int type = (int)Utilities.TransferType.ProtocolImage;
                    IHIS.Framework.Utilities.UploadFile(address, fileName, uploadToken, mHospcode, grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"),
                        type.ToString());
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CLIS_MSG001, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// remake sort number for grdStatus
        /// </summary>
        private void ReMakeSortNo()
        {
            for (int i = 0; i < this.grdStatus.RowCount; i++)
            {
                if (this.grdStatus.GetItemString(i, "sort_no") != (i + 1).ToString() ||
                    this.grdStatus.GetItemString(i, "sort_no") == "")
                {
                    this.grdStatus.SetItemValue(i, "sort_no", i + 1);
                }
            }
        }


        /// <summary>
        /// ValidateGrdProtocol
        /// Check mandatory fields.
        /// Check if user insert/update/delete more than one row -> throw error message.
        /// Check from date > todate -> throw error message.
        /// </summary>
        /// <returns></returns>
        private string ValidateGrdProtocol()
        {
            String msg = "";
            String mandatoryField = "";
            bool isCompleted = true;
            int updCnt = grdProtocol.DeletedRowCount;
            if (updCnt > 1)
            {
                msg = Resources.CLIS_MSG002;
                return msg;
            }

            for (int i = 0; i < grdProtocol.RowCount; i++)
            {
                if (grdProtocol.GetRowState(i) != DataRowState.Unchanged)
                {
                    updCnt++;
                    if (updCnt > 1)
                    {
                        msg = Resources.CLIS_MSG002;
                        return msg;
                    }
                    if (String.IsNullOrEmpty(grdProtocol.GetItemString(i, "protocol_code")))
                    {
                        isCompleted = false;
                        mandatoryField += " [" + Resources.CLIS_MSG003 + "]" + Environment.NewLine;
                    }
                    if (String.IsNullOrEmpty(grdProtocol.GetItemString(i, "protocol_name")))
                    {
                        isCompleted = false;
                        mandatoryField += " [" + Resources.CLIS_MSG004 + "]" + Environment.NewLine;
                    }
                    if (String.IsNullOrEmpty(grdProtocol.GetItemString(i, "from_date")))
                    {
                        isCompleted = false;
                        mandatoryField += " [" + Resources.CLIS_MSG005 + "]" + Environment.NewLine;
                    }
                    if (String.IsNullOrEmpty(grdProtocol.GetItemString(i, "to_date")))
                    {
                        isCompleted = false;
                        mandatoryField += " [" + Resources.CLIS_MSG006 + "]" + Environment.NewLine;
                    }
                    if (String.IsNullOrEmpty(grdProtocol.GetItemString(i, "protocol_status")))
                    {
                        isCompleted = false;
                        mandatoryField += " [" + Resources.CLIS_MSG007 + "]" + Environment.NewLine;
                    }
                }
            }
            if (isCompleted == false)
            {
                msg += Resources.CLIS_MSG008 + Environment.NewLine;
                msg += mandatoryField;
            }

            return msg;
        }
        /// <summary>
        /// dtpToDate_DataValidating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (String.IsNullOrEmpty(dtpFromDate.GetDataValue()))
            {
                XMessageBox.Show(Resources.CLIS_MSG009);
                dtpFromDate.Focus();
                return;
            }
            DateTime fromDate = Convert.ToDateTime(dtpFromDate.GetDataValue());
            DateTime toDate = Convert.ToDateTime(dtpToDate.GetDataValue());
            if (DateTime.Compare(fromDate, toDate) > 0)
            {
                XMessageBox.Show(Resources.CLIS_MSG010);
                dtpFromDate.Focus();
                
            }
        }

        /// <summary>
        /// xButtonList1_PostButtonClick
        /// Disable delete grdStatus.
        /// Disable function insert when input grdProtocol more than 1 row.
        /// Disable function manual insert of grdStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xButtonList1_PostButtonClick(object sender, PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Cancel:
                    break;
                case FunctionType.Close:
                    break;
                case FunctionType.Delete:
                    //grdStatus can not be deleted,
                    //when grdProtocol is deleted, grdStatus must be affected
                    if (grdProtocol.RowCount == 0)
                    {
                        this.grdTrialDrg.Reset();
                        this.grdStatus.Reset();
                        this.xPictureBox1.ResetData();
                        break;
                    }
                    
                    grdStatus.QueryLayout(true);
                    this.xPictureBox1.ResetData();
                    break;
                case FunctionType.Insert:
                    //validate grdProtocol
                    int cntProtocol = 0;
                    for (int i = 0; i < grdProtocol.RowCount; i++)
                    {
                        if (grdProtocol.GetRowState(i) == DataRowState.Added)
                        {
                            cntProtocol++;
                        }
                        if (cntProtocol > 1)
                        {
                            XMessageBox.Show(Resources.CLIS_MSG011, Resources.CLIS_MSG012, System.Windows.Forms.MessageBoxIcon.Warning);
                            grdProtocol.DeleteRow(i);
                            break;
                        }
                    }

                    //validate grdStatus
                    //if (!mAutoInsert)
                    //{
                    //    XMessageBox.Show("You can not manually insert status for protocol!", "Warning", System.Windows.Forms.MessageBoxIcon.Warning);
                    //    AutoGenerateGrdStatus();
                    //}
                    int cntStatus = 0;
                    for (int i = 0; i < grdStatus.RowCount; i++)
                    {
                        if (grdStatus.GetRowState(i) == DataRowState.Added)
                        {
                            cntStatus++;
                        }
                    }
                    if (mAutoInsertCnt < cntStatus)
                    {
                        XMessageBox.Show(Resources.CLIS_MSG013, Resources.CLIS_MSG012, System.Windows.Forms.MessageBoxIcon.Warning);
                        if (grdProtocol.GetRowState(grdProtocol.CurrentRowNumber) == DataRowState.Added)
                        {
                            AutoGenerateGrdStatus();
                        }
                        else 
                        {
                            grdStatus.DeleteRow(grdStatus.CurrentRowNumber);
                        }
                    }
                    break;
                case FunctionType.Preview:
                    break;
                case FunctionType.Print:
                    break;
                case FunctionType.Process:
                    break;
                case FunctionType.Query:
                    break;
                case FunctionType.Reset:
                    break;
                case FunctionType.Update:
                    if (e.IsSuccess)
                    {
                        this.imageChanged = false;
                        XMessageBox.Show(Resources.CLIS_MSG014, Resources.CLIS_MSG015, System.Windows.Forms.MessageBoxIcon.Information);
                        xButtonList1.PerformClick(FunctionType.Query);
                    }
                    else 
                    {
                        XMessageBox.Show(Resources.CLIS_MSG016, Resources.CLIS_MSG001, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Automatic generate new rows for grdStatus when insert grdProtocol
        /// </summary>
        private void AutoGenerateGrdStatus()
        {
            CLIS2015U02GrdStatusArgs args = new CLIS2015U02GrdStatusArgs();
            CLIS2015U02GrdStatusResult result = CloudService.Instance.Submit<CLIS2015U02GrdStatusResult, CLIS2015U02GrdStatusArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                this.mAutoInsertCnt = result.GrdStatusList.Count;
                this.grdStatus.Reset();

                //for (int i = 0; i < result.GrdStatusList.Count; i++)
                //{
                //    grdStatus.InsertRow();

                //}
                foreach (CLIS2015U02GrdStatusInfo info in result.GrdStatusList)
                {
                    grdStatus.InsertRow();
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "protocol_id", info.ProtocolId);
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "status_id", info.StatusId);
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "status_code", info.StatusCode);
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "status_name", info.StatusName);
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "sort_no", info.SortNo);
                    grdStatus.SetItemValue(grdStatus.CurrentRowNumber, "display_flg", info.DisplayFlg);
                }
            }
        }

        #region sorting row
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (this.grdStatus.RowCount == 0 ||
                this.grdStatus.CurrentRowNumber == 0 ||
                this.grdStatus.CurrentRowNumber < 0) return;

            this.ChangeGridRow(this.grdStatus.CurrentRowNumber, this.grdStatus.CurrentRowNumber - 1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.grdStatus.RowCount == 0 ||
                this.grdStatus.CurrentRowNumber == this.grdStatus.RowCount - 1 ||
                this.grdStatus.CurrentRowNumber < 0)
            {
                return;
            }

            this.ChangeGridRow(this.grdStatus.CurrentRowNumber, this.grdStatus.CurrentRowNumber + 1);
        }

        /// <summary>
        /// ChangeGridRow
        /// swap 2 rows in grdStatus
        /// </summary>
        /// <param name="aFromRow"></param>
        /// <param name="aToRow"></param>
        private void ChangeGridRow(int aFromRow, int aToRow)
        {

            MultiLayout tempLay = this.grdStatus.CloneToLayout();
            foreach (DataRow dr in this.grdStatus.LayoutTable.Rows)
            {
                tempLay.LayoutTable.ImportRow(dr);
            }

            this.grdStatus.LayoutTable.Rows.Clear();

            int currentColNum = (this.grdStatus.CurrentColNumber < 0 ? 0 : this.grdStatus.CurrentColNumber);


            for (int i = 0; i < tempLay.LayoutTable.Rows.Count; i++)
            {
                if (aFromRow == i) continue;

                if (aToRow == i)
                {
                    // 위로 올릴때
                    if (aFromRow > aToRow)
                    {
                        this.grdStatus.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                        this.grdStatus.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                    }
                    // 밑으로 내릴때
                    else
                    {
                        this.grdStatus.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aToRow]);
                        this.grdStatus.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[aFromRow]);
                    }
                }
                else
                {
                    this.grdStatus.LayoutTable.ImportRow(tempLay.LayoutTable.Rows[i]);
                }
            }

            this.grdStatus.DisplayData();
            this.grdStatus.SetFocusToItem(aToRow, currentColNum, false);
        }
        #endregion

        /// <summary>
        /// grdProtocol_GridColumnChanged
        /// validate from_date and to_date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grdProtocol_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            try
            {
                switch (e.ColName)
                {
                    case "from_date":
                        if (!String.IsNullOrEmpty(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "from_date")) 
                            && !String.IsNullOrEmpty(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "to_date")))
                        {
                            DateTime fromDate = Convert.ToDateTime(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "from_date"));
                            DateTime toDate = Convert.ToDateTime(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "to_date"));
                            if (DateTime.Compare(fromDate, toDate) > 0)
                            {
                                XMessageBox.Show(Resources.CLIS_MSG010);
                                this.grdProtocol.SetFocusToItem(this.grdProtocol.CurrentRowNumber, "from_date");
                            }
                        }
                        break;
                    case "to_date":
                        if (!String.IsNullOrEmpty(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "from_date"))
                            && !String.IsNullOrEmpty(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "to_date")))
                        {
                            DateTime fromDate = Convert.ToDateTime(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "from_date"));
                            DateTime toDate = Convert.ToDateTime(grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "to_date"));
                            if (DateTime.Compare(fromDate, toDate) > 0)
                            {
                                XMessageBox.Show(Resources.CLIS_MSG010);
                                this.grdProtocol.SetFocusToItem(this.grdProtocol.CurrentRowNumber, "to_date");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CLIS_MSG001, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|Pdf Files|*.Pdf";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.mFileName = dialog.FileName;
                this.imageChanged = true;
                //update resource
                string ext = Path.GetExtension(mFileName);
                mNewName = grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id") + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffffff") + ext;
                grdProtocol.SetItemValue(grdProtocol.CurrentRowNumber, "resource", Utilities.ConvertToLocalPath(mFilePath + "\\" + mNewName));
                
                PreviewPicture(this.mFileName);
            }
        }

        private void PreviewPicture(string fileName)
        {
            try
            {
                string ext = Path.GetExtension(fileName);
                if (ext != ".pdf")
                {
                    xPictureBox1.Image = Image.FromFile(fileName);
                    xPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    xPictureBox1.ResetData();
                    string randomFile = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + ".jpg";
                    GhostscriptWrapper.GeneratePageThumb(Path.GetFullPath(fileName), this.mFilePath + "\\"+ randomFile, 1, 24, 24);
                    xPictureBox1.Image = Image.FromFile(this.mFilePath + "\\" + randomFile);
                }
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CLIS_MSG001, MessageBoxIcon.Error);
            }
        }

        private void xPictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(mFileName))
                {
                    return;
                }
                Process.Start(Path.GetFullPath(mFileName));
            }
            catch (Exception ex)
            {
				//https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show(ex.Message, Resources.CLIS_MSG001, MessageBoxIcon.Error);
            }
        }

        //private void grdProtocol_DoubleClick(object sender, EventArgs e)
        //{
        //    CommonItemCollection param = new CommonItemCollection();
        //    param.Add("clis_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));

        //    XScreen.OpenScreenWithParam(this, "CLIS", "CLIS2015U13", ScreenOpenStyle.ResponseFixed, param);
        //}

        /// <summary>
        /// btnPatientList_Click
        /// Open screen CLIS2015U04
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPatientList_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            // 2015.10.09 AnhNV fixes bug https://nextop-asia.atlassian.net/browse/MED-4595
            param.Add("f_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));
            XScreen.OpenScreenWithParam(this, "CLIS", "CLIS2015U04", ScreenOpenStyle.ResponseFixed, param);
        }

        private void grdTrialDrg_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdTrialDrg.SetBindVarValue("f_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));
        }

        private void CLIS2015U02_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CheckSave();
        }

        private void CheckSave()
        {
            // Has deleted rows?
            if (null != grdProtocol.DeletedRowTable && grdProtocol.DeletedRowTable.Rows.Count > 0)
            {
                if (XMessageBox.Show(Resources.MSG_012, Resources.CAP_001, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    xButtonList1.PerformClick(FunctionType.Update);
                    return;
                }
            }

            for (int i = 0; i < grdProtocol.RowCount; i++)
            {
                if (grdProtocol.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG_012, Resources.CAP_001, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        xButtonList1.PerformClick(FunctionType.Update);
                        return;
                    }

                    return;
                }
            }

            for (int i = 0; i < grdStatus.RowCount; i++)
            {
                if (grdStatus.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG_012, Resources.CAP_001, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        xButtonList1.PerformClick(FunctionType.Update);
                        return;
                    }

                    return;
                }
            }
        }

        //private void grdProtocol_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left && e.Clicks == 2)
        //    {
        //        CommonItemCollection param = new CommonItemCollection();
        //        param.Add("clis_protocol_id", grdProtocol.GetItemString(grdProtocol.CurrentRowNumber, "protocol_id"));

        //        XScreen.OpenScreenWithParam(this, "CLIS", "CLIS2015U13", ScreenOpenStyle.ResponseFixed, param);
        //    }
        //}
    }
}
