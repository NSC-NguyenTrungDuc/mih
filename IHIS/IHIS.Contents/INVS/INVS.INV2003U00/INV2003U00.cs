#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.CloudConnector;
using IHIS.INVS.Properties;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.CloudConnector.Contracts.Models.Invs;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.System;
using INVS.Libs;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;
#endregion

namespace IHIS.INVS
{
    /// <summary>
    /// INV2003U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INV2003U00 : IHIS.Framework.XScreen
    {
        //private string fkinv2003 = "";
        //private string row_delete_2003 = "";
        //private string inv2004_fkinv2003 = "";
        //private string int2004_jaeryoCode = "";
        private int row_count_2003 = 0;
        private int row_current_2003 = 0;
        private const string UNDERSCORE = "_";

        #region Controls

        private IHIS.Framework.XButtonList btnList;
        private XPanel xPanel2;
        private XEditGrid grdINV2004;
        private XPanel xPanel1;
        private XPanel xPanel3;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell22;
        private XDictComboBox cbxJaeryoGubun;
        private XLabel xLabel1;
        private XDictComboBox cbxActor;
        private XComboItem xComboItem1;
        private XComboItem xComboItem2;
        private XComboItem xComboItem3;
        private XLabel xLabel28;
        private XDictComboBox cbxBuseo;
        private XComboItem xComboItem6;
        private XComboItem xComboItem7;
        private XComboItem xComboItem8;
        private XLabel xLabel56;
        private XDatePicker dtpChuriDate;
        private XLabel xLabel14;
        private XDatePicker dtpToDate;
        private XDatePicker dtpFromDate;
        private XLabel xLabel2;
        private XEditGridCell xEditGridCell10;
        private XMstGrid grdINV2003;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XButton btnExportCSV;
        private XEditGrid grdPrint;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XButton btnExportExcel;
        private XLabel xLabel3;
        private XDictComboBox cbxExportType;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem9;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XButton btnChange;
        private XDisplayBox txtUserName;
        private XDisplayBox txtUserID;
        private XEditGridCell xEditGridCell31;
        private System.ComponentModel.Container components = null;
        #endregion

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        public INV2003U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            InitializeCloud();

            //https://sofiamedix.atlassian.net/browse/MED-14594
            txtUserID.Text = UserInfo.UserID;
            txtUserName.Text = UserInfo.UserName;
        }

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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV2003U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdPrint = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.grdINV2003 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.grdINV2004 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnExportExcel = new IHIS.Framework.XButton();
            this.btnExportCSV = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnChange = new IHIS.Framework.XButton();
            this.cbxExportType = new IHIS.Framework.XDictComboBox();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem9 = new IHIS.Framework.XComboItem();
            this.txtUserName = new IHIS.Framework.XDisplayBox();
            this.txtUserID = new IHIS.Framework.XDisplayBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dtpToDate = new IHIS.Framework.XDatePicker();
            this.dtpFromDate = new IHIS.Framework.XDatePicker();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.cbxJaeryoGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.cbxActor = new IHIS.Framework.XDictComboBox();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.xComboItem3 = new IHIS.Framework.XComboItem();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.cbxBuseo = new IHIS.Framework.XDictComboBox();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xComboItem7 = new IHIS.Framework.XComboItem();
            this.xComboItem8 = new IHIS.Framework.XComboItem();
            this.xLabel56 = new IHIS.Framework.XLabel();
            this.dtpChuriDate = new IHIS.Framework.XDatePicker();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV2003)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV2004)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.grdPrint);
            this.xPanel2.Controls.Add(this.grdINV2003);
            this.xPanel2.Controls.Add(this.grdINV2004);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // grdPrint
            // 
            this.grdPrint.ApplyPaintEventToAllColumn = true;
            this.grdPrint.CallerID = '2';
            this.grdPrint.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell28,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell29,
            this.xEditGridCell30});
            this.grdPrint.ColPerLine = 11;
            this.grdPrint.Cols = 11;
            this.grdPrint.ExecuteQuery = null;
            this.grdPrint.FixedRows = 1;
            this.grdPrint.FocusColumnName = "jaeryo_code";
            this.grdPrint.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdPrint, "grdPrint");
            this.grdPrint.MasterLayout = this.grdINV2003;
            this.grdPrint.Name = "grdPrint";
            this.grdPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrint.ParamList")));
            this.grdPrint.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdPrint.Rows = 2;
            this.grdPrint.ToolTipActive = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "seq";
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "churi_date";
            this.xEditGridCell2.Col = 6;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellName = "export_time";
            this.xEditGridCell28.Col = 8;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "jaeryo_code";
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.DecimalDigits = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsNotNull = true;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "jaeryo_name";
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.IsUpdatable = false;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "chulgo_qty";
            this.xEditGridCell7.Col = 7;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellLen = 500;
            this.xEditGridCell8.CellName = "ipgo_danui_name";
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "chulgo_type";
            this.xEditGridCell3.CellWidth = 96;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell3.EnableSort = true;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell3.IsNotNull = true;
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "upd_id";
            this.xEditGridCell4.CellWidth = 330;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.EnableSort = true;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.CellName = "export_code";
            this.xEditGridCell29.Col = 9;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellName = "comment";
            this.xEditGridCell30.Col = 10;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdINV2003
            // 
            this.grdINV2003.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11,
            this.xEditGridCell14,
            this.xEditGridCell9,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell27,
            this.xEditGridCell18,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell31});
            this.grdINV2003.ColPerLine = 5;
            this.grdINV2003.Cols = 6;
            resources.ApplyResources(this.grdINV2003, "grdINV2003");
            this.grdINV2003.ExecuteQuery = null;
            this.grdINV2003.FixedCols = 1;
            this.grdINV2003.FixedRows = 1;
            this.grdINV2003.FocusColumnName = "chulgo_type";
            this.grdINV2003.HeaderHeights.Add(21);
            this.grdINV2003.Name = "grdINV2003";
            this.grdINV2003.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV2003.ParamList")));
            this.grdINV2003.RowHeaderVisible = true;
            this.grdINV2003.Rows = 2;
            this.grdINV2003.ToolTipActive = true;
            this.grdINV2003.Enter += new System.EventHandler(this.grdINV2003_Enter);
            this.grdINV2003.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINV2003_RowFocusChanged);
            this.grdINV2003.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdINV2003_RowFocusChanging);
            this.grdINV2003.PreEndInitializing += new System.EventHandler(this.grdINV2003_PreEndInitializing);
            this.grdINV2003.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV2003_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "pkinv2003";
            this.xEditGridCell11.Col = -1;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsVisible = false;
            this.xEditGridCell11.Row = -1;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell14.CellName = "churi_date";
            this.xEditGridCell14.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell14.CellWidth = 95;
            this.xEditGridCell14.Col = 1;
            this.xEditGridCell14.EditorStyle = IHIS.Framework.XCellEditorStyle.DatePicker;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsUpdatable = false;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "churi_time";
            this.xEditGridCell9.CellWidth = 95;
            this.xEditGridCell9.Col = 2;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "churi_buseo";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "chulgo_type";
            this.xEditGridCell16.CellWidth = 149;
            this.xEditGridCell16.Col = 3;
            this.xEditGridCell16.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "export_code";
            this.xEditGridCell27.Col = 4;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsReadOnly = true;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "churi_seq";
            this.xEditGridCell18.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell18.CellWidth = 124;
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsUpdatable = false;
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellName = "jaeryo_gubun";
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellLen = 500;
            this.xEditGridCell24.CellName = "remark";
            this.xEditGridCell24.CellWidth = 124;
            this.xEditGridCell24.Col = 5;
            this.xEditGridCell24.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellName = "in_out_gubun";
            this.xEditGridCell25.Col = -1;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.IsVisible = false;
            this.xEditGridCell25.Row = -1;
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellName = "ipchul_type";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // grdINV2004
            // 
            this.grdINV2004.ApplyPaintEventToAllColumn = true;
            this.grdINV2004.CallerID = '2';
            this.grdINV2004.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell17,
            this.xEditGridCell10,
            this.xEditGridCell20,
            this.xEditGridCell21,
            this.xEditGridCell19,
            this.xEditGridCell22});
            this.grdINV2004.ColPerLine = 5;
            this.grdINV2004.Cols = 6;
            resources.ApplyResources(this.grdINV2004, "grdINV2004");
            this.grdINV2004.ExecuteQuery = null;
            this.grdINV2004.FixedCols = 1;
            this.grdINV2004.FixedRows = 1;
            this.grdINV2004.FocusColumnName = "jaeryo_code";
            this.grdINV2004.HeaderHeights.Add(21);
            this.grdINV2004.MasterLayout = this.grdINV2003;
            this.grdINV2004.Name = "grdINV2004";
            this.grdINV2004.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV2004.ParamList")));
            this.grdINV2004.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINV2004.RowHeaderVisible = true;
            this.grdINV2004.Rows = 2;
            this.grdINV2004.ToolTipActive = true;
            this.grdINV2004.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdINV2004_PreSaveLayout);
            this.grdINV2004.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdINV2004_GridColumnChanged);
            this.grdINV2004.Enter += new System.EventHandler(this.grdINV2004_Enter);
            this.grdINV2004.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdINV2004_GridFindClick);
            this.grdINV2004.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV2004_QueryStarting);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "pkinv2004";
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "fkinv2003";
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsVisible = false;
            this.xEditGridCell13.Row = -1;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.CellName = "jaeryo_code";
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.ExecuteQuery = null;
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell17.IsNotNull = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "jaeryo_name";
            this.xEditGridCell10.CellWidth = 313;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.EnableSort = true;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.IsUpdatable = false;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "chulgo_qty";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell20.CellWidth = 127;
            this.xEditGridCell20.Col = 3;
            this.xEditGridCell20.DecimalDigits = 2;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.IsReadOnly = true;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "subul_danui";
            this.xEditGridCell21.Col = 4;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "ipgo_danga";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellLen = 500;
            this.xEditGridCell22.CellName = "remark";
            this.xEditGridCell22.CellWidth = 97;
            this.xEditGridCell22.Col = 5;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnExportExcel);
            this.xPanel1.Controls.Add(this.btnExportCSV);
            this.xPanel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Name = "xPanel1";
            // 
            // btnExportExcel
            // 
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.ImageIndex = 2;
            this.btnExportExcel.ImageList = this.ImageList;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnExportCSV
            // 
            resources.ApplyResources(this.btnExportCSV, "btnExportCSV");
            this.btnExportCSV.ImageIndex = 14;
            this.btnExportCSV.ImageList = this.ImageList;
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnChange);
            this.xPanel3.Controls.Add(this.cbxExportType);
            this.xPanel3.Controls.Add(this.txtUserName);
            this.xPanel3.Controls.Add(this.txtUserID);
            this.xPanel3.Controls.Add(this.xLabel3);
            this.xPanel3.Controls.Add(this.dtpToDate);
            this.xPanel3.Controls.Add(this.dtpFromDate);
            this.xPanel3.Controls.Add(this.xLabel2);
            this.xPanel3.Controls.Add(this.cbxJaeryoGubun);
            this.xPanel3.Controls.Add(this.xLabel1);
            this.xPanel3.Controls.Add(this.cbxActor);
            this.xPanel3.Controls.Add(this.xLabel28);
            this.xPanel3.Controls.Add(this.cbxBuseo);
            this.xPanel3.Controls.Add(this.xLabel56);
            this.xPanel3.Controls.Add(this.dtpChuriDate);
            this.xPanel3.Controls.Add(this.xLabel14);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.Name = "xPanel3";
            // 
            // btnChange
            // 
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.Image = ((System.Drawing.Image)(resources.GetObject("btnChange.Image")));
            this.btnChange.Name = "btnChange";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cbxExportType
            // 
            this.cbxExportType.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem9});
            this.cbxExportType.ExecuteQuery = null;
            resources.ApplyResources(this.cbxExportType, "cbxExportType");
            this.cbxExportType.Name = "cbxExportType";
            this.cbxExportType.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxExportType.ParamList")));
            this.cbxExportType.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xComboItem4
            // 
            resources.ApplyResources(this.xComboItem4, "xComboItem4");
            this.xComboItem4.ValueItem = "%";
            // 
            // xComboItem5
            // 
            resources.ApplyResources(this.xComboItem5, "xComboItem5");
            this.xComboItem5.ValueItem = "1";
            // 
            // xComboItem9
            // 
            resources.ApplyResources(this.xComboItem9, "xComboItem9");
            this.xComboItem9.ValueItem = "2";
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // xLabel3
            // 
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.Name = "xLabel3";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.IsVietnameseYearType = false;
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.IsVietnameseYearType = false;
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.dtpFromDate_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel2.EdgeRounding = false;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel2.Name = "xLabel2";
            // 
            // cbxJaeryoGubun
            // 
            this.cbxJaeryoGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cbxJaeryoGubun, "cbxJaeryoGubun");
            this.cbxJaeryoGubun.Name = "cbxJaeryoGubun";
            this.cbxJaeryoGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxJaeryoGubun.ParamList")));
            this.cbxJaeryoGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xLabel1
            // 
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // cbxActor
            // 
            this.cbxActor.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2,
            this.xComboItem3});
            this.cbxActor.ExecuteQuery = null;
            resources.ApplyResources(this.cbxActor, "cbxActor");
            this.cbxActor.Name = "cbxActor";
            this.cbxActor.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxActor.ParamList")));
            this.cbxActor.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xComboItem1
            // 
            this.xComboItem1.DisplayItem = global::IHIS.INVS.Properties.Resources.XCOMBOITEM1;
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            this.xComboItem2.DisplayItem = global::IHIS.INVS.Properties.Resources.XCOMBOITEM2;
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            this.xComboItem3.DisplayItem = global::IHIS.INVS.Properties.Resources.XCOMBOITEM3;
            this.xComboItem3.ValueItem = "2";
            // 
            // xLabel28
            // 
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.Name = "xLabel28";
            // 
            // cbxBuseo
            // 
            this.cbxBuseo.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem6,
            this.xComboItem7,
            this.xComboItem8});
            this.cbxBuseo.ExecuteQuery = null;
            resources.ApplyResources(this.cbxBuseo, "cbxBuseo");
            this.cbxBuseo.Name = "cbxBuseo";
            this.cbxBuseo.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxBuseo.ParamList")));
            this.cbxBuseo.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "%";
            // 
            // xComboItem7
            // 
            resources.ApplyResources(this.xComboItem7, "xComboItem7");
            this.xComboItem7.ValueItem = "1";
            // 
            // xComboItem8
            // 
            resources.ApplyResources(this.xComboItem8, "xComboItem8");
            this.xComboItem8.ValueItem = "2";
            // 
            // xLabel56
            // 
            this.xLabel56.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel56.EdgeRounding = false;
            resources.ApplyResources(this.xLabel56, "xLabel56");
            this.xLabel56.Name = "xLabel56";
            // 
            // dtpChuriDate
            // 
            resources.ApplyResources(this.dtpChuriDate, "dtpChuriDate");
            this.dtpChuriDate.IsVietnameseYearType = false;
            this.dtpChuriDate.Name = "dtpChuriDate";
            // 
            // xLabel14
            // 
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.ForeColor = new IHIS.Framework.XColor(System.Drawing.Color.Black);
            this.xLabel14.Name = "xLabel14";
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.BindControl = this.txtUserID;
            this.xEditGridCell31.CellLen = 20;
            this.xEditGridCell31.CellName = "input_user";
            this.xEditGridCell31.Col = -1;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsVisible = false;
            this.xEditGridCell31.Row = -1;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // INV2003U00
            // 
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "INV2003U00";
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV2003)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV2004)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Init Clound
        private void InitializeCloud()
        {
            grdINV2004.ParamList = new List<string>(new string[] { "f_fkinv2003" });

            cbxExportType.ExecuteQuery = GetCbxChulgoType; 
            cbxBuseo.ExecuteQuery = GetCbxBuseo;
            cbxActor.ExecuteQuery = GetCbxActor;
            grdINV2003.ExecuteQuery = GetDataGrdINV2003;
            grdINV2004.ExecuteQuery = GetDataGrdINV2004;
                   
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //// SaveLayout 설정
            //this.grdINV2003.SavePerformer = new XSavePerformer(this);
            //this.grdINV2004.SavePerformer = new XSavePerformer(this);

            //// 그리드 SavePerformer 설정
            //this.grdINV2003.SavePerformer = new XSavePerformer(this);
            //this.grdINV2004.SavePerformer = this.grdINV2003.SavePerformer;

            // Master-Detail 관계 설정
            this.grdINV2004.SetRelationKey("fkinv2003", "pkinv2003");
            this.grdINV2004.SetRelationTable("INV2004");

            this.CurrMSLayout = this.grdINV2003;

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            this.dtpChuriDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));


            this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));


            // 実施者に 現在ログインしている IDを セットする｡
            this.cbxActor.SetDataValue(UserInfo.UserID);

            // 部署に 固定｢薬剤科｣SET
            this.cbxBuseo.SelectedIndex = 0;

            cbxBuseo.SetDictDDLB();
            //https://sofiamedix.atlassian.net/browse/MED-14594
           // cbxActor.SetDictDDLB();
            cbxExportType.SetDictDDLB();
            cbxExportType.SetDataValue("%");

            this.btnList.PerformClick(FunctionType.Query);
        }
        #endregion

        #region [検索条件]
        private void dtpFromDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.btnList.PerformClick(FunctionType.Query);

        }
        #endregion

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {          
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    this.grdINV2003.QueryLayout(false);
                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    xEditGridCell20.IsReadOnly = false;

                    if (this.CurrMSLayout == this.grdINV2003)
                    {
                        if (this.grdINV2003.RowCount > 0)
                        {
                            for (int i = 0; i < this.grdINV2003.RowCount; i++)
                            {
                                // 마스터 그리드 2행 이상 입력 방지
                                if (this.grdINV2003.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                {
                                    this.ShowMessage("MasterInsert");
                                    return;
                                }
                            }
                        }

                        this.Insert_grdINV2003();
                        //https://sofiamedix.atlassian.net/browse/MED-14737
                        txtUserID.Text = UserInfo.UserID;
                        txtUserName.Text = UserInfo.UserName;
                    }
                    else
                    {
                        // 마스터 그리드 데이타 존재 여부 확인
                        if (this.grdINV2003.RowCount == 0)
                        {
                            this.ShowMessage("DetailInsert");
                            return;
                        }
                        else
                        {
                            this.Insert_grdINV2004();
                        }
                    }

                    break;

                case FunctionType.Delete: 
                    //row_delete_2003 = grdINV2003.GetItemString(grdINV2003.CurrentRowNumber, "pkinv2003");
                    //inv2004_fkinv2003 = grdINV2004.GetItemString(grdINV2004.CurrentRowNumber, "fkinv2003");
                    //int2004_jaeryoCode = grdINV2004.GetItemString(grdINV2004.CurrentRowNumber, "jaeryo_code");
                    break;

                case FunctionType.Update:
                    xEditGridCell20.IsReadOnly = true;
                    //if (!this.grdINV2003.SaveLayout())
                    //{
                    //    this.ShowMessage("ServiceError");
                    //    return;
                    //}

                    //if (!this.grdINV2004.SaveLayout())
                    //{
                    //    this.ShowMessage("ServiceError");
                    //    return;
                    //}


                    //this.ShowMessage("SaveSuccess");
                    //this.grdINV2003.QueryLayout(false);
                    if (grdINV2003.RowCount > 0 && (grdINV2003.GetItemString(grdINV2003.CurrentRowNumber, "chulgo_type") == ""))
                    {
                        XMessageBox.Show(Resources.MSG009_MGS, Resources.MSG_CAP);
                        return;
                    }
                    if (grdINV2004.RowCount > 0 && (grdINV2004.GetItemString(grdINV2004.CurrentRowNumber, "chulgo_qty") == ""))
                    {
                        XMessageBox.Show(Resources.MSG010_MGS, Resources.MSG_CAP);
                        return;
                    }
                    if (!SaveGridLayout())
                    {
                        this.ShowMessage("ServiceError");
                        return;
                    }
                    this.ShowMessage("SaveSuccess");
                    this.grdINV2003.QueryLayout(false);
                    this.grdINV2004.QueryLayout(false);
                    break;

                default:
                    break;
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
                    msg = Resources.MSG001_MGS;
                    cpt = Resources.MSG002_MGS;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailInsert":
                    msg = Resources.MSG003_MGS;
                    cpt = Resources.MSG004_MGS;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    msg = Resources.MSG005_MGS;
                    cpt = Resources.MSG006_MGS;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    msg = String.Format(Resources.MSG007_MGS + "：{0}", Service.ErrFullMsg);
                    cpt = "エラー";
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Insert_grdINV2003
        private void Insert_grdINV2003()
        {
            int row = this.grdINV2003.InsertRow(-1);

            this.grdINV2003.SetItemValue(row, "pkinv2003", getPkINV2003());
            this.grdINV2003.SetItemValue(row, "churi_date", this.dtpChuriDate.GetDataValue());
            this.grdINV2003.SetItemValue(row, "churi_buseo", this.cbxBuseo.GetDataValue());
            this.grdINV2003.SetItemValue(row, "ipchul_type", "O");
            this.grdINV2003.SetItemValue(row, "in_out_gubun", "N");

            // https://sofiamedix.atlassian.net/browse/MED-12360
            this.grdINV2003.SetItemValue(row, "churi_time", EnvironInfo.GetSysDateTime().ToString("HH:mm"));
        }
        #endregion

        #region [getPkINV2003]
        private string getPkINV2003()
        {
            //BindVarCollection bindVar = new BindVarCollection();

            //string cmdText = @"SELECT INV2003_SEQ.NEXTVAL FROM SYS.DUAL";

            //object retval = Service.ExecuteScalar(cmdText, bindVar);

            //return retval.ToString();

            GetPkINV2003Args args = new GetPkINV2003Args();
            GetPkINV2003Result res = CloudService.Instance.Submit<GetPkINV2003Result, GetPkINV2003Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                return res.Pkinv2003;
            }
            else
            { 
                return ""; 
            }
        }
        #endregion

        #region Insert_grdINV2004
        private void Insert_grdINV2004()
        {
            int row = this.grdINV2004.InsertRow(-1);
        }
        #endregion

        #region grdINV2003 EVENT
        private void grdINV2003_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINV2003.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINV2003.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdINV2003.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
        }

        private void grdINV2003_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            for (int i = 0; i < this.grdINV2004.RowCount; i++)
            {
                if (this.grdINV2004.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG008_MGS, Resources.MSG_CAP, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        //this.grdINV2004.SaveLayout();
                        this.btnList.PerformClick(FunctionType.Update);
                    }
                }
            }
        }

        private void grdINV2003_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            row_current_2003 = e.CurrentRow;
            this.grdINV2004.QueryLayout(false);
            //fkinv2003 = this.grdINV2003.GetItemString(e.CurrentRow, "pkinv2003");

            //https://sofiamedix.atlassian.net/browse/MED-14737
            txtUserID.Text = grdINV2003.GetItemString(grdINV2003.CurrentRowNumber, "input_user");

        }
        #endregion

        #region grdINV2004 EVENT
        private void grdINV2004_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINV2004.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINV2004.SetBindVarValue("f_fkinv2003", this.grdINV2003.GetItemString(this.grdINV2003.CurrentRowNumber, "pkinv2003"));
        }

        private void grdINV2004_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            this.grdINV2004.SetItemValue(e.RowNumber, "fkinv2003", this.grdINV2003.GetItemString(this.grdINV2003.CurrentRowNumber, "pkinv2003"));
        }

        private void grdINV2004_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (grid.Name)
            {
                case "grdINV2004":

                    if (e.ColName == "jaeryo_code")
                    {
                        this.OpenScreen_INV0110Q00(grid.GetItemString(e.RowNumber, e.ColName));
                    }

                    break;
            }
        }

        private void grdINV2004_GridFindClick(object sender, GridFindClickEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (e.ColName)
            {
                case "jaeryo_code":

                    e.Cancel = true;

                    this.OpenScreen_INV0110Q00(grid.GetItemString(e.RowNumber, e.ColName));

                    break;
            }
        }

        /// <summary>
        /// 항목코드 파인드 창 오픈
        /// </summary>
        /// <param name="aHangmogCode">검색어</param>
        private void OpenScreen_INV0110Q00(string aHangmogCode)
        {
            CommonItemCollection param = new CommonItemCollection();

            param.Add("jaeryo_code", aHangmogCode);
            param.Add("multiSelect", false);

            XScreen.OpenScreenWithParam(this, "INVS", "INV0110Q00", ScreenOpenStyle.ResponseFixed, param);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            XEditGrid grid = this.grdINV2004;

            switch (command)
            {
                case "INV0110Q00":            // 항목검색

                    #region 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("INV0110") && ((MultiLayout)commandParam["INV0110"]).RowCount > 0)
                        {
                            foreach (DataRow dr in ((MultiLayout)commandParam["INV0110"]).LayoutTable.Rows)
                            {
                                if (grid.GetItemString(grid.CurrentRowNumber, "subul_danui") != "")
                                {
                                    this.btnList.PerformClick(FunctionType.Insert);
                                }

                                grid.SetItemValue(grid.CurrentRowNumber, "jaeryo_code", dr["jaeryo_code"].ToString());
                                grid.SetItemValue(grid.CurrentRowNumber, "jaeryo_name", dr["jaeryo_name"].ToString());
                                grid.SetItemValue(grid.CurrentRowNumber, "subul_danui", dr["subul_danui_name"].ToString());
                                //grid.SetItemValue(grid.CurrentRowNumber, "ipgo_danga", dr["subul_danga"].ToString());
                            }
                        }
                    }
                    #endregion

                    break;
                //https://sofiamedix.atlassian.net/browse/MED-14594
                case "ADM104Q":
                    //XMessageBox.Show(commandParam["user_id"].ToString() + "---" + commandParam["user_name"].ToString());
                    txtUserID.SetDataValue(commandParam["user_id"]);
                    txtUserName.SetDataValue(commandParam["user_name"]);
                    break;
            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region GetData cbxBuseo
        private IList<object[]> GetCbxBuseo(BindVarCollection bvc)
        {

            IList<object[]> lObj = new List<object[]>();
            INV4001LoadBuseoArgs args = new INV4001LoadBuseoArgs();
            INV4001LoadBuseoResult res = CloudService.Instance.Submit<INV4001LoadBuseoResult, INV4001LoadBuseoArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Lst.ForEach(delegate(INV4001LoadBuseoInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.BuseoCode,
                            item.BuseoName,
                           
                        });
                });
            }
            return lObj;

        }
        #endregion

        #region GetData cbxActor
        private IList<object[]> GetCbxActor(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            INV4001U00DrugUserArgs args = new INV4001U00DrugUserArgs();
            INV4001U00DrugUserResult res = CloudService.Instance.Submit<INV4001U00DrugUserResult, INV4001U00DrugUserArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Lst.ForEach(delegate(INV4001U00DrugUserInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.UserId,
                            item.UserNm,
                           
                        });
                });
            }
            return lObj;

        }
        #endregion

        #region GetCbxChulgoType
        private IList<object[]> GetCbxChulgoType(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            INV2003U00GetCbxChulgoTypeArgs args = new INV2003U00GetCbxChulgoTypeArgs();
            args.HospCode = UserInfo.HospCode.ToString();
            args.CodeType = "CHULGO_TYPE";
            INV2003U00GetCbxChulgoTypeResult res = CloudService.Instance.Submit<INV2003U00GetCbxChulgoTypeResult, INV2003U00GetCbxChulgoTypeArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(INV2003U00GetCbxChulgoTypeInfo item)
                {
                    lObj.Add(new object[]
                        {
                            item.Code,
                            item.CodeName,
                           
                        });
                });
            }
            return lObj;
        }
        #endregion

        #region GetData INV2003
        private IList<object[]> GetDataGrdINV2003(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            INV2003U00GrdINV2003Args args = new INV2003U00GrdINV2003Args();
            args.HospCode = ""; // session
            args.FromDate = dtpFromDate.GetDataValue();
            args.ToDate = dtpToDate.GetDataValue();
            args.ChulgoType = cbxExportType.GetDataValue();

            INV2003U00GrdINV2003Result res = CloudService.Instance.Submit<INV2003U00GrdINV2003Result, INV2003U00GrdINV2003Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(INV2003U00GrdINV2003Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Pkinv2003,
                        item.ChuriDate,
                        TypeCheck.IsNull(item.ChuriTime) || item.ChuriTime.Length < 2 ? "" : item.ChuriTime.Insert(2, ":"),
                        item.ChuriBuseo,
                        item.ChulgoType,
                        item.ExportCode,
                        item.ChuriSeq,
                        item.JaeryoGubun,
                        item.Remark,
                        item.InOutGubun,
                        item.IpchulType,
                        item.InputUser
                    });
                });
            }

            row_count_2003 = lObj.Count;
            return lObj;
        }

        #endregion

        #region GetData INV2004
        private IList<object[]> GetDataGrdINV2004(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            INV2003U00GrdINV2004Args args = new INV2003U00GrdINV2004Args();
            args.HospCode = ""; // session
            args.Fkinv2003 = bvc["f_fkinv2003"].VarValue;//grdINV2003.GetItemString(grdINV2003.CurrentRowNumber, "pkinv2003");//"churi_seq");//

            INV2003U00GrdINV2004Result res = CloudService.Instance.Submit<INV2003U00GrdINV2004Result, INV2003U00GrdINV2004Args>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(INV2003U00GrdINV2004Info item)
                {
                    lObj.Add(new object[]
                        {
                            item.Pkinv2004,
                            item.Fkinv2003,
                            item.JaeryoCode,
                            item.JaeryoName,
                            item.ChulgoQty,
                            item.ChulgoDanuiName,
                            item.ChulgoDanga,
                            item.Remark
                        });
                });
            }
            return lObj;
        }

        #endregion

        /* ====================================== SAVEPERFORMER ====================================== */
        #region [ XSavePerformer]
        //private class XSavePerformer : IHIS.Framework.ISavePerformer
        //{
        //    private INV2003U00 parent = null;
        //    public XSavePerformer(INV2003U00 parent)
        //    {
        //        this.parent = parent;
        //    }
        //    public bool Execute(char callerID, RowDataItem item)
        //    {

        //        string cmdText = "";
        //        object t_chk = "";
        //        object seq = "";
        //        string msg = "";
        //        string cap = "";
        //        string data_row_state = "";

        //        //Grid에서 넘어온 Bind 변수에 f_user_id SET
        //        item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //        item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //        switch (callerID)
        //        {
        //            case '1':
        //                #region INV2003
        //                switch (item.RowState)
        //                {
        //                    //                            case DataRowState.Added:
        //                    //                                cmdText = @"INSERT INTO INV2003 (  SYS_DATE     
        //                    //                                                                 , SYS_ID
        //                    //                                                                 , UPD_DATE
        //                    //                                                                 , UPD_ID
        //                    //                                                                 , HOSP_CODE    
        //                    //                                                                 , PKINV2003
        //                    //                                                                 , CHURI_DATE   
        //                    //                                                                 , CHURI_BUSEO  
        //                    //                                                                 , CHULGO_TYPE    
        //                    //                                                                 , CHURI_SEQ    
        //                    //                                                                 , JAERYO_GUBUN 
        //                    //                                                                 , IPCHUL_TYPE  
        //                    //                                                                 , IN_OUT_GUBUN 
        //                    //                                                                 , REMARK    
        //                    //                                                      ) VALUES (   SYSDATE
        //                    //                                                                 , :q_user_id
        //                    //                                                                 , SYSDATE
        //                    //                                                                 , :q_user_id
        //                    //                                                                 , :f_hosp_code
        //                    //                                                                 , :f_pkinv2003
        //                    //                                                                 , :f_churi_date
        //                    //                                                                 , :f_churi_buseo
        //                    //                                                                 , :f_chulgo_type
        //                    //                                                                 , PKG_COM_UTIL.FN_MAXSEQ(:f_hosp_code, 'INV2003', 'SEQ', :f_churi_date||'-'||:f_churi_buseo||'-'||:f_chulgo_type)
        //                    //                                                                 , :f_jaeryo_gubun
        //                    //                                                                 , :f_ipchul_type
        //                    //                                                                 , :f_in_out_gubun
        //                    //                                                                 , :f_remark
        //                    //                                                               )";
        //                    //                                break;

        //                    //                            case DataRowState.Modified:

        //                    //                                cmdText = @" UPDATE INV2003      A
        //                    //                                                SET A.REMARK     = :f_remark
        //                    //                                              WHERE A.HOSP_CODE  = :f_hosp_code
        //                    //                                                AND A.PKINV2003  = :f_pkinv2003
        //                    //                                           ";

        //                    //                                break;

        //                    //                            case DataRowState.Deleted:
        //                    //                                cmdText = @" DELETE FROM INV2003 A
        //                    //                                              WHERE A.HOSP_CODE  = :f_hosp_code
        //                    //                                                AND A.PKINV2003  = :f_pkinv2003
        //                    //                                           ";
        //                    //                                break;

        //                    case DataRowState.Added: data_row_state = "Added"; break;
        //                    case DataRowState.Modified: data_row_state = "Modified"; break;
        //                    case DataRowState.Deleted: data_row_state = "Deleted"; break;

        //                        INV2003U00SaveINV2003Args args = new INV2003U00SaveINV2003Args();
        //                        args.SysDate = "";
        //                        args.SysId = "";
        //                        args.UpdDate = "";
        //                        args.HospCode = "";
        //                        args.Pkinv2003 = ;
        //                        args.ChuriDate = "";
        //                        args.ChuriBuseo = "";
        //                        args.ChulgoType = "";
        //                        args.ChuriSeq = "";
        //                        args.JaeryoGubun = "";
        //                        args.IpchulType = "";
        //                        args.InOutGubun = "";
        //                        args.Remark = "";
        //                        args.DataRowState = data_row_state;

        //                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV2003U00SaveINV2003Args>(args);
        //                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
        //                        {
        //                            XMessageBox.Show("Thanh cong", "Notice", MessageBoxIcon.Information);
        //                            return true;
        //                        }
        //                        else
        //                        {
        //                            XMessageBox.Show("That bai", "Notice", MessageBoxIcon.Information);
        //                            return false;
        //                        }
        //                        break;


        //                }
        //                #endregion
        //                break;

        //            case '2':
        //                #region INV2004
        //                switch (item.RowState)
        //                {
        //                    //                            case DataRowState.Added:

        //                    //                                cmdText = @" SELECT 'Y'
        //                    //                                               FROM SYS.DUAL
        //                    //                                              WHERE EXISTS ( SELECT 'X'
        //                    //                                                               FROM INV2004  A
        //                    //                                                              WHERE A.HOSP_CODE   = :f_hosp_code
        //                    //                                                                AND A.FKINV2004   = :f_fkinv2004
        //                    //                                                                AND A.JAERYO_CODE = :f_jaeryo_code
        //                    //                                          ) ";


        //                    //                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

        //                    //                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
        //                    //                                {
        //                    //                                    msg = item.BindVarList["f_jaeryo_name"].VarValue + " [" + item.BindVarList["f_jaeryo_code"].VarValue + "]は " + "既に登録されている在庫コードです。";
        //                    //                                    cap = "データ確認";

        //                    //                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

        //                    //                                    return false;
        //                    //                                }

        //                    //                                cmdText = @" INSERT INTO INV2004 ( SYS_DATE
        //                    //                                                                 , SYS_ID
        //                    //                                                                 , UPD_DATE
        //                    //                                                                 , UPD_ID
        //                    //                                                                 , HOSP_CODE
        //                    //                                                                 , PKINV2004
        //                    //                                                                 , FKINV2003
        //                    //                                                                 , JAERYO_CODE
        //                    //                                                                 , CHULGO_QTY
        //                    //                                                                 , CHULGO_DANGA
        //                    //                                                                 , REMARK
        //                    //                                                                  
        //                    //                                                        ) VALUES ( SYSDATE
        //                    //                                                                 , :q_user_id
        //                    //                                                                 , SYSDATE
        //                    //                                                                 , :q_user_id
        //                    //                                                                 , :f_hosp_code
        //                    //                                                                 , INV2004_SEQ.NEXTVAL
        //                    //                                                                 , :f_fkinv2003
        //                    //                                                                 , :f_jaeryo_code
        //                    //                                                                 , :f_chulgo_qty
        //                    //                                                                 , :f_chulgo_danga
        //                    //                                                                 , :f_remark
        //                    //                                                        ) ";

        //                    //                                break;

        //                    //                            case DataRowState.Modified:

        //                    //                                cmdText = @" UPDATE INV2004        A
        //                    //                                                SET A.CHULGO_QTY   = :f_chulgo_qty
        //                    //                                                  , A.CHULGO_DANGA = :f_chulgo_danga
        //                    //                                                  , A.REMARK       = :f_remark
        //                    //                                                  , A.UPD_DATE     = SYSDATE
        //                    //                                                  , A.UPD_ID       = :q_user_id
        //                    //                                              WHERE A.HOSP_CODE    = :f_hosp_code
        //                    //                                                AND A.FKINV2003    = :f_fkinv2003
        //                    //                                                AND A.JAERYO_CODE  = :f_jaeryo_code
        //                    //                                           ";

        //                    //                                break;

        //                    //                            case DataRowState.Deleted:

        //                    //                                cmdText = @" DELETE FROM INV2004   A
        //                    //                                              WHERE A.HOSP_CODE    = :f_hosp_code
        //                    //                                                AND A.FKINV2003    = :f_fkinv2003
        //                    //                                                AND A.JAERYO_CODE  = :f_jaeryo_code
        //                    //                                           ";

        //                    //                                break;
        //                    case DataRowState.Added: data_row_state = "Added"; break;
        //                    case DataRowState.Modified: data_row_state = "Modified"; break;
        //                    case DataRowState.Deleted: data_row_state = "Deleted"; break;
        //                        INV2003U00SaveINV2004Args args = new INV2003U00SaveINV2004Args();
        //                        args.HospCode = "";
        //                        args.Fkinv2004 = "";
        //                        args.JaeryoCode = "";
        //                        args.SysDate = "";
        //                        args.UpdDate = "";
        //                        args.UpdId = "";
        //                        args.Pkinv2004 = "";
        //                        args.Fkinv2003 = "";
        //                        args.ChulgoQty = "";
        //                        args.ChulgoDanga = "";
        //                        args.Remark = "";
        //                        args.DataRowState = data_row_state;

        //                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV2003U00SaveINV2004Args>(args);
        //                        if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
        //                        {
        //                            XMessageBox.Show("Thanh cong", "Notice", MessageBoxIcon.Information);
        //                            return true;
        //                        }
        //                        else
        //                        {
        //                            XMessageBox.Show("That bai", "Notice", MessageBoxIcon.Information);
        //                            return false;
        //                        }

        //                }
        //                #endregion
        //                break;
        //        }

        //        return true;
        //    }
        //}

        #endregion

        #region saveINV2003U00

        private bool SaveGridLayout()
        {
            INV2003U00SaveLayoutArgs args = new INV2003U00SaveLayoutArgs();
            args.Info2003 = new List<INV2003U00GrdINV2003Info>();
            args.Info2004 = new List<INV2003U00GrdINV2004Info>();

            for (int i = 0; i < grdINV2003.RowCount; i++)
            {
                //skip unchanged rows
                if (grdINV2003.GetRowState(i) == DataRowState.Unchanged) continue;

                //INV2003U00INV2003Info item = new INV2003U00INV2003Info();
                //item.SysDate = "";
                //item.SysId = "";
                //item.UpdDate = "";
                //item.UpdId = "";
                //item.HospCode = "";
                //item.Pkinv2003 = grdINV2003.GetItemString(i, "pkinv2003");
                //item.ChuriDate = grdINV2003.GetItemString(i, "churi_date");

                //// 
                ////item.Chu

                //item.ChuriBuseo = grdINV2003.GetItemString(i, "churi_buseo");
                //item.ChulgoType = grdINV2003.GetItemString(i, "chulgo_type");
                //item.ChuriSeq = grdINV2003.GetItemString(i, "churi_seq");
                //item.JaeryoGubun = grdINV2003.GetItemString(i, "jaeryo_gubun");
                //item.IpchulType = grdINV2003.GetItemString(i, "ipchul_type");
                //item.InOutGubun = grdINV2003.GetItemString(i, "in_out_gubun");
                //item.Remark = grdINV2003.GetItemString(i, "remark");
                //item.DataRowState = grdINV2003.GetRowState(i).ToString();

                INV2003U00GrdINV2003Info item = new INV2003U00GrdINV2003Info();
                item.ChulgoType = grdINV2003.GetItemString(i, "chulgo_type");
                item.ChuriBuseo = grdINV2003.GetItemString(i, "churi_buseo");
                item.ChuriDate = grdINV2003.GetItemString(i, "churi_date");
                item.ChuriSeq = grdINV2003.GetItemString(i, "churi_seq");
                item.ChuriTime = grdINV2003.GetItemString(i, "churi_time");
                item.ExportCode = grdINV2003.GetItemString(i, "export_code");
                item.InOutGubun = grdINV2003.GetItemString(i, "in_out_gubun");
                item.IpchulType = grdINV2003.GetItemString(i, "ipchul_type");
                item.JaeryoGubun = grdINV2003.GetItemString(i, "jaeryo_gubun");
                item.Pkinv2003 = grdINV2003.GetItemString(i, "pkinv2003");
                item.Remark = grdINV2003.GetItemString(i, "remark");
                item.InputUser = grdINV2003.GetItemString(i, "input_user");
                item.RowState = grdINV2003.GetRowState(i).ToString();

                args.Info2003.Add(item);
            }
            //for delete
            if (null != grdINV2003.DeletedRowTable)
            {
                foreach (DataRow dr in grdINV2003.DeletedRowTable.Rows)
                {
                    INV2003U00GrdINV2003Info item = new INV2003U00GrdINV2003Info();
                    //item.Pkinv2003 = row_delete_2003;
                    item.Pkinv2003 = dr["pkinv2003"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    args.Info2003.Add(item);
                }
            }
            // Infor2004
            for (int i = 0; i < grdINV2004.RowCount; i++)
            {
                //skip unchanged rows
                if (grdINV2004.GetRowState(i) == DataRowState.Unchanged) continue;

                //INV2003U00INV2004Info item = new INV2003U00INV2004Info();
                //item.HospCode = "";
                //item.Fkinv2004 = "";
                //item.JaeryoCode = grdINV2004.GetItemString(i, "jaeryo_code");
                //item.SysDate = "";
                //item.SysId = "";
                //item.UpdDate = "";
                //item.UpdId = "";
                //item.Pkinv2004 = ""; //INV2004_SEQ.NEXTVAL
                //item.Fkinv2003 = grdINV2003.GetItemString(this.grdINV2003.CurrentRowNumber, "pkinv2003");
                //item.ChulgoQty =  grdINV2004.GetItemString(i, "chulgo_qty");
                //item.ChulgoDanga = grdINV2004.GetItemString(i, "ipgo_danga");
                //item.Remark = grdINV2004.GetItemString(i, "remark");
                //item.DataRowState = grdINV2004.GetRowState(i).ToString();

                INV2003U00GrdINV2004Info item = new INV2003U00GrdINV2004Info();
                item.ChulgoDanga = grdINV2004.GetItemString(i, "ipgo_danga");
                //item.ChulgoDanuiName = grdINV2004.GetItemString(i, "");
                item.ChulgoQty = grdINV2004.GetItemString(i, "chulgo_qty");
                item.Fkinv2003 = grdINV2003.GetItemString(this.grdINV2003.CurrentRowNumber, "pkinv2003");
                item.JaeryoCode = grdINV2004.GetItemString(i, "jaeryo_code");
                //item.JaeryoName = grdINV2004.GetItemString(i, "");
                //item.Pkinv2004 = grdINV2004.GetItemString(i, "");
                item.Remark = grdINV2004.GetItemString(i, "remark");
                item.RowState = grdINV2004.GetRowState(i).ToString();

                args.Info2004.Add(item);
            }
            //for delete
            if (null != grdINV2004.DeletedRowTable)
            {
                foreach (DataRow dr in grdINV2004.DeletedRowTable.Rows)
                {
                    INV2003U00GrdINV2004Info item = new INV2003U00GrdINV2004Info();
                    //item.Fkinv2003 = inv2004_fkinv2003;
                    //item.JaeryoCode = int2004_jaeryoCode;
                    item.Fkinv2003 = dr["fkinv2003"].ToString();
                    item.JaeryoCode = dr["jaeryo_code"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    args.Info2004.Add(item);
                }
            }

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV2003U00SaveLayoutArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                return true;
            }

            return false;
        }


        #endregion

        private void grdINV2003_PreEndInitializing(object sender, EventArgs e)
        {
           xEditGridCell16.ExecuteQuery = GetCbxChulgoType;
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-11446
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            this.grdPrint.ParamList = new List<string>(new string[] { "f_end_date", "f_hosp_code", "f_start_date", });
            this.grdPrint.ExecuteQuery = GetGrdPrint;
            this.grdPrint.SetBindVarValue("f_start_date", this.dtpFromDate.GetDataValue());
            this.grdPrint.SetBindVarValue("f_end_date", this.dtpToDate.GetDataValue());
            this.grdPrint.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            this.grdPrint.QueryLayout(true);

            using (SaveFileDialog svd = new SaveFileDialog())
            {
                // https://sofiamedix.atlassian.net/browse/MED-12323
                // [HOSP_CODE]_[IMPORT_CODE]_[CURRENT_DATE]_[CURRENT_TIME]
                string fileName = string.Concat(UserInfo.HospCode,
                    UNDERSCORE,
                    grdINV2003.GetItemString(grdINV2003.CurrentRowNumber, "export_code"),
                    UNDERSCORE,
                    DateTime.Now.ToString("yyyyMMdd"),
                    UNDERSCORE,
                    DateTime.Now.ToString("hhmm"));
                svd.FileName = fileName;
                svd.Filter = "csv files (*.csv)|*.csv";

                if (svd.ShowDialog() == DialogResult.OK)
                {
                    // Get file name.
                    //string fileName = svd.FileName;
                    if (INVHelpers.ExportCSV(grdPrint, svd.FileName))
                    {
                        // Export succeeded.
                    }
                }
            }
            // this.grdPrint.Export(true, true);
        }

        private List<object[]> GetGrdPrint(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV2003U00ExportCSVArgs args = new INV2003U00ExportCSVArgs();
            args.EndDate = bc["f_end_date"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.StartDate = bc["f_start_date"].VarValue;
            INV2003U00ExportCSVResult res = CloudService.Instance.Submit<INV2003U00ExportCSVResult, INV2003U00ExportCSVArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.ListInfo.ForEach(delegate(INV2003U00ExportCSVInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RowNum,
                        INVHelpers.FormatDateStrByLocale(item.ChuriDate),
                        TypeCheck.IsNull(item.ExportTime) || item.ExportTime.Length < 2 ? "" : item.ExportTime.Insert(2, ":"),
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.ChulgoQty,
                        item.IpgoDanuiName,
                        item.ChulgoType,
                        //https://sofiamedix.atlassian.net/browse/MED-14729
                        txtUserID.GetDataValue(),
                        //item.UpdId,
                        item.ExportCode,
                        item.Comment,
                    });
                });
            }

            return lObj;
        }

        private void grdINV2004_Enter(object sender, EventArgs e)
        {
            if (row_current_2003 > (row_count_2003 - 1))
            {

            }
            else
            {
                //hide button
                hideButtonList(false);
            }
        }
        private void hideButtonList(bool visible)
        {
            btnList.SetEnabled(FunctionType.Update, visible);
            btnList.SetEnabled(FunctionType.Delete, visible);
            btnList.SetEnabled(FunctionType.Insert, visible);
        }

        private void grdINV2003_Enter(object sender, EventArgs e)
        {
            hideButtonList(true);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", txtUserID.Text);
            param.Add("user_name", txtUserName.Text);
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            grdINV2003.SetItemValue(grdINV2003.CurrentRowNumber, "input_user", txtUserID.GetDataValue());
            ADM104QGetPatientArgs args = new ADM104QGetPatientArgs();
            args.UserId = txtUserID.GetDataValue();

            ADM104QGetPatientResult res = CloudService.Instance.Submit<ADM104QGetPatientResult, ADM104QGetPatientArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Exist == true)
            {
                txtUserName.Text = res.UserName;
            }
        }
       
    }
}