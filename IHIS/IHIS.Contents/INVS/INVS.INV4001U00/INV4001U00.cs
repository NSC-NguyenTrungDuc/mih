#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Arguments.Invs;
using IHIS.CloudConnector.Contracts.Results.Invs;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.Invs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.INVS.Properties;
using INVS.Libs;
using System.Globalization;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;

#endregion

namespace IHIS.INVS
{
    /// <summary>
    /// INV4001U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INV4001U00 : IHIS.Framework.XScreen
    {
        #region Constans

        private const string UNDERSCORE = "_";
        private int INV4001U00_rowcount = 0;

        #endregion

        #region Controls

        private IHIS.Framework.XButtonList btnList;
        private XPanel xPanel2;
        private XEditGrid grdINV4002;
        private XPanel xPanel1;
        private XPanel xPanel3;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
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
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XDatePicker dtpToDate;
        private XDatePicker dtpFromDate;
        private XLabel xLabel2;
        private XMstGrid grdINV4001;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell21;
        private XEditGridCell xEditGridCell23;
        private XEditGridCell xEditGridCell24;
        private XEditGridCell xEditGridCell25;
        private XEditGridCell xEditGridCell26;
        private XEditGridCell xEditGridCell27;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private XEditGridCell xEditGridCell3;
        private XButton btnExportExcel;
        private XEditGrid grdPrint;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell4;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell28;
        private XEditGridCell xEditGridCell29;
        private XEditGridCell xEditGridCell30;
        private XEditGridCell xEditGridCell31;
        private XEditGridCell xEditGridCell32;
        private XEditGridCell xEditGridCell35;
        private XEditGridCell xEditGridCell36;
        private XEditGridCell xEditGridCell37;
        private XEditGridCell xEditGridCell38;
        private XEditGridCell xEditGridCell39;
        private XButton btnChange;
        private XDisplayBox txtUserName;
        private XDisplayBox txtUserID;
        private XEditGridCell xEditGridCell33;
        private System.ComponentModel.Container components = null;
        #endregion

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>

        public INV4001U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV4001U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.grdINV4001 = new IHIS.Framework.XMstGrid();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell35 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell36 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell23 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell24 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell25 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell26 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell27 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell33 = new IHIS.Framework.XEditGridCell();
            this.txtUserID = new IHIS.Framework.XDisplayBox();
            this.grdINV4002 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.btnExportExcel = new IHIS.Framework.XButton();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnChange = new IHIS.Framework.XButton();
            this.txtUserName = new IHIS.Framework.XDisplayBox();
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
            this.grdPrint = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell37 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell28 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell29 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell30 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell31 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell32 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell38 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell39 = new IHIS.Framework.XEditGridCell();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV4001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV4002)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).BeginInit();
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
            this.xPanel2.Controls.Add(this.grdINV4001);
            this.xPanel2.Controls.Add(this.grdINV4002);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Name = "xPanel2";
            // 
            // grdINV4001
            // 
            this.grdINV4001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell35,
            this.xEditGridCell18,
            this.xEditGridCell21,
            this.xEditGridCell36,
            this.xEditGridCell23,
            this.xEditGridCell24,
            this.xEditGridCell25,
            this.xEditGridCell26,
            this.xEditGridCell27,
            this.xEditGridCell33});
            this.grdINV4001.ColPerLine = 5;
            this.grdINV4001.Cols = 6;
            resources.ApplyResources(this.grdINV4001, "grdINV4001");
            this.grdINV4001.ExecuteQuery = null;
            this.grdINV4001.FixedCols = 1;
            this.grdINV4001.FixedRows = 1;
            this.grdINV4001.HeaderHeights.Add(21);
            this.grdINV4001.Name = "grdINV4001";
            this.grdINV4001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV4001.ParamList")));
            this.grdINV4001.QuerySQL = resources.GetString("grdINV4001.QuerySQL");
            this.grdINV4001.RowHeaderVisible = true;
            this.grdINV4001.Rows = 2;
            this.grdINV4001.ToolTipActive = true;
            this.grdINV4001.Enter += new System.EventHandler(this.grdINV4001_Enter);
            this.grdINV4001.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdINV4001_RowFocusChanged);
            this.grdINV4001.RowFocusChanging += new IHIS.Framework.RowFocusChangingEventHandler(this.grdINV4001_RowFocusChanging);
            this.grdINV4001.PreEndInitializing += new System.EventHandler(this.grdINV4001_PreEndInitializing);
            this.grdINV4001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV4001_QueryStarting);
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell15.CellName = "pkinv4001";
            this.xEditGridCell15.Col = -1;
            this.xEditGridCell15.ExecuteQuery = null;
            this.xEditGridCell15.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsVisible = false;
            this.xEditGridCell15.Row = -1;
            this.xEditGridCell15.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell16.CellName = "churi_date";
            this.xEditGridCell16.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell16.Col = 1;
            this.xEditGridCell16.ExecuteQuery = null;
            this.xEditGridCell16.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsUpdatable = false;
            this.xEditGridCell16.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell35
            // 
            this.xEditGridCell35.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell35.CellName = "import_time";
            this.xEditGridCell35.CellWidth = 86;
            this.xEditGridCell35.Col = 2;
            this.xEditGridCell35.ExecuteQuery = null;
            this.xEditGridCell35.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell35, "xEditGridCell35");
            this.xEditGridCell35.IsReadOnly = true;
            this.xEditGridCell35.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell18.CellName = "churi_buseo";
            this.xEditGridCell18.Col = -1;
            this.xEditGridCell18.ExecuteQuery = null;
            this.xEditGridCell18.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsVisible = false;
            this.xEditGridCell18.Row = -1;
            this.xEditGridCell18.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.CellName = "ipgo_type";
            this.xEditGridCell21.CellWidth = 150;
            this.xEditGridCell21.Col = 3;
            this.xEditGridCell21.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell21.ExecuteQuery = null;
            this.xEditGridCell21.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsUpdatable = false;
            this.xEditGridCell21.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell21.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell21.UserSQL = resources.GetString("xEditGridCell21.UserSQL");
            // 
            // xEditGridCell36
            // 
            this.xEditGridCell36.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell36.CellName = "import_code";
            this.xEditGridCell36.Col = 4;
            this.xEditGridCell36.ExecuteQuery = null;
            this.xEditGridCell36.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell36, "xEditGridCell36");
            this.xEditGridCell36.IsReadOnly = true;
            this.xEditGridCell36.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell23
            // 
            this.xEditGridCell23.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell23.CellName = "churi_seq";
            this.xEditGridCell23.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell23.CellWidth = 34;
            this.xEditGridCell23.Col = -1;
            this.xEditGridCell23.ExecuteQuery = null;
            this.xEditGridCell23.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell23, "xEditGridCell23");
            this.xEditGridCell23.IsUpdatable = false;
            this.xEditGridCell23.IsVisible = false;
            this.xEditGridCell23.Row = -1;
            this.xEditGridCell23.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell24
            // 
            this.xEditGridCell24.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell24.CellName = "jaeryo_gubun";
            this.xEditGridCell24.Col = -1;
            this.xEditGridCell24.ExecuteQuery = null;
            this.xEditGridCell24.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell24, "xEditGridCell24");
            this.xEditGridCell24.IsVisible = false;
            this.xEditGridCell24.Row = -1;
            this.xEditGridCell24.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell25
            // 
            this.xEditGridCell25.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell25.CellLen = 500;
            this.xEditGridCell25.CellName = "remark";
            this.xEditGridCell25.CellWidth = 65;
            this.xEditGridCell25.Col = 5;
            this.xEditGridCell25.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell25.ExecuteQuery = null;
            this.xEditGridCell25.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell25, "xEditGridCell25");
            this.xEditGridCell25.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell26
            // 
            this.xEditGridCell26.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell26.CellName = "in_out_gubun";
            this.xEditGridCell26.Col = -1;
            this.xEditGridCell26.ExecuteQuery = null;
            this.xEditGridCell26.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell26, "xEditGridCell26");
            this.xEditGridCell26.IsVisible = false;
            this.xEditGridCell26.Row = -1;
            this.xEditGridCell26.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell27
            // 
            this.xEditGridCell27.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell27.CellName = "ipchul_type";
            this.xEditGridCell27.Col = -1;
            this.xEditGridCell27.ExecuteQuery = null;
            this.xEditGridCell27.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell27, "xEditGridCell27");
            this.xEditGridCell27.IsVisible = false;
            this.xEditGridCell27.Row = -1;
            this.xEditGridCell27.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell33
            // 
            this.xEditGridCell33.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell33.BindControl = this.txtUserID;
            this.xEditGridCell33.CellLen = 20;
            this.xEditGridCell33.CellName = "input_user";
            this.xEditGridCell33.Col = -1;
            this.xEditGridCell33.ExecuteQuery = null;
            this.xEditGridCell33.HeaderFont = new System.Drawing.Font("Arial", 8.75F);
            resources.ApplyResources(this.xEditGridCell33, "xEditGridCell33");
            this.xEditGridCell33.IsVisible = false;
            this.xEditGridCell33.Row = -1;
            this.xEditGridCell33.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // txtUserID
            // 
            resources.ApplyResources(this.txtUserID, "txtUserID");
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.TextChanged += new System.EventHandler(this.txtUserID_TextChanged);
            // 
            // grdINV4002
            // 
            this.grdINV4002.CallerID = '2';
            this.grdINV4002.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell17,
            this.xEditGridCell7,
            this.xEditGridCell20,
            this.xEditGridCell8,
            this.xEditGridCell19,
            this.xEditGridCell22,
            this.xEditGridCell9,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3});
            this.grdINV4002.ColPerLine = 10;
            this.grdINV4002.Cols = 11;
            resources.ApplyResources(this.grdINV4002, "grdINV4002");
            this.grdINV4002.ExecuteQuery = null;
            this.grdINV4002.FixedCols = 1;
            this.grdINV4002.FixedRows = 1;
            this.grdINV4002.HeaderHeights.Add(21);
            this.grdINV4002.MasterLayout = this.grdINV4001;
            this.grdINV4002.Name = "grdINV4002";
            this.grdINV4002.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV4002.ParamList")));
            this.grdINV4002.QuerySQL = resources.GetString("grdINV4002.QuerySQL");
            this.grdINV4002.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINV4002.RowHeaderVisible = true;
            this.grdINV4002.Rows = 2;
            this.grdINV4002.ToolTipActive = true;
            this.grdINV4002.PreSaveLayout += new IHIS.Framework.GridRecordEventHandler(this.grdINV4002_PreSaveLayout);
            this.grdINV4002.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdINV4002_GridColumnChanged);
            this.grdINV4002.Enter += new System.EventHandler(this.grdINV4002_Enter);
            this.grdINV4002.GridFindClick += new IHIS.Framework.GridFindClickEventHandler(this.grdINV4002_GridFindClick);
            this.grdINV4002.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdInv4002_QueryStarting);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell12.CellName = "pkinv4002";
            this.xEditGridCell12.CellWidth = 60;
            this.xEditGridCell12.Col = -1;
            this.xEditGridCell12.ExecuteQuery = null;
            this.xEditGridCell12.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsVisible = false;
            this.xEditGridCell12.Row = -1;
            this.xEditGridCell12.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell13.CellName = "fkinv4001";
            this.xEditGridCell13.CellWidth = 60;
            this.xEditGridCell13.Col = -1;
            this.xEditGridCell13.ExecuteQuery = null;
            this.xEditGridCell13.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
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
            this.xEditGridCell17.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.Katakana;
            this.xEditGridCell17.IsNotNull = true;
            this.xEditGridCell17.IsUpdatable = false;
            this.xEditGridCell17.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell7.CellName = "jaeryo_name";
            this.xEditGridCell7.CellWidth = 316;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell20.CellName = "ipgo_qty";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell20.Col = 6;
            this.xEditGridCell20.DecimalDigits = 2;
            this.xEditGridCell20.ExecuteQuery = null;
            this.xEditGridCell20.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsNotNull = true;
            this.xEditGridCell20.IsUpdatable = false;
            this.xEditGridCell20.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell8.CellName = "ipgo_danui";
            this.xEditGridCell8.Col = 7;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            this.xEditGridCell8.IsUpdatable = false;
            this.xEditGridCell8.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell19.CellName = "ipgo_danga";
            this.xEditGridCell19.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell19.Col = 8;
            this.xEditGridCell19.ExecuteQuery = null;
            this.xEditGridCell19.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsNotNull = true;
            this.xEditGridCell19.IsUpdatable = false;
            this.xEditGridCell19.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.CellLen = 500;
            this.xEditGridCell22.CellName = "remark";
            this.xEditGridCell22.CellWidth = 61;
            this.xEditGridCell22.Col = 9;
            this.xEditGridCell22.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell22.ExecuteQuery = null;
            this.xEditGridCell22.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsUpdatable = false;
            this.xEditGridCell22.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell22.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell9.CellName = "sum_danga";
            this.xEditGridCell9.CellType = IHIS.Framework.XCellDataType.Decimal;
            this.xEditGridCell9.CellWidth = 100;
            this.xEditGridCell9.Col = 10;
            this.xEditGridCell9.ExecuteQuery = null;
            this.xEditGridCell9.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsUpdatable = false;
            this.xEditGridCell9.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell1.CellName = "start_date";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell1.CellWidth = 94;
            this.xEditGridCell1.Col = 3;
            this.xEditGridCell1.ExecuteQuery = null;
            this.xEditGridCell1.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            this.xEditGridCell1.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell2.CellName = "lot";
            this.xEditGridCell2.CellWidth = 94;
            this.xEditGridCell2.Col = 4;
            this.xEditGridCell2.ExecuteQuery = null;
            this.xEditGridCell2.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsUpdatable = false;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell3.CellName = "end_date";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell3.Col = 5;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsUpdatable = false;
            this.xEditGridCell3.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.btnExportExcel);
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
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnChange);
            this.xPanel3.Controls.Add(this.txtUserName);
            this.xPanel3.Controls.Add(this.txtUserID);
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
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
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
            this.cbxActor.UserSQL = resources.GetString("cbxActor.UserSQL");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "%";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "1";
            // 
            // xComboItem3
            // 
            resources.ApplyResources(this.xComboItem3, "xComboItem3");
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
            this.cbxBuseo.UserSQL = "SELECT A.BUSEO_CODE\r\n     , A.BUSEO_NAME\r\n  FROM BAS0260 A\r\n WHERE A.HOSP_CODE  =" +
                " FN_ADM_LOAD_HOSP_CODE()\r\n   AND A.BUSEO_CODE = \'42100\' --薬剤科";
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
            // grdPrint
            // 
            this.grdPrint.CallerID = '2';
            this.grdPrint.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell37,
            this.xEditGridCell4,
            this.xEditGridCell14,
            this.xEditGridCell28,
            this.xEditGridCell29,
            this.xEditGridCell30,
            this.xEditGridCell31,
            this.xEditGridCell32,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell38,
            this.xEditGridCell39});
            this.grdPrint.ColPerLine = 14;
            this.grdPrint.Cols = 14;
            this.grdPrint.ExecuteQuery = null;
            this.grdPrint.FixedRows = 1;
            this.grdPrint.HeaderHeights.Add(21);
            resources.ApplyResources(this.grdPrint, "grdPrint");
            this.grdPrint.Name = "grdPrint";
            this.grdPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrint.ParamList")));
            this.grdPrint.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdPrint.Rows = 2;
            this.grdPrint.ToolTipActive = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.CellName = "seq";
            this.xEditGridCell5.CellWidth = 85;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.ExecuteQuery = null;
            this.xEditGridCell5.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.RowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell6.CellName = "churi_date";
            this.xEditGridCell6.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell6.CellWidth = 310;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            this.xEditGridCell6.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            this.xEditGridCell6.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell37
            // 
            this.xEditGridCell37.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell37.CellName = "import_time";
            this.xEditGridCell37.Col = 11;
            this.xEditGridCell37.ExecuteQuery = null;
            this.xEditGridCell37.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell37, "xEditGridCell37");
            this.xEditGridCell37.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell4.CellName = "jaeryo_code";
            this.xEditGridCell4.CellWidth = 117;
            this.xEditGridCell4.Col = 4;
            this.xEditGridCell4.ExecuteQuery = null;
            this.xEditGridCell4.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell14.CellName = "jaeryo_name";
            this.xEditGridCell14.CellWidth = 109;
            this.xEditGridCell14.Col = 5;
            this.xEditGridCell14.ExecuteQuery = null;
            this.xEditGridCell14.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            this.xEditGridCell14.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell28
            // 
            this.xEditGridCell28.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell28.CellName = "start_date";
            this.xEditGridCell28.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell28.CellWidth = 111;
            this.xEditGridCell28.Col = 6;
            this.xEditGridCell28.ExecuteQuery = null;
            this.xEditGridCell28.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell28, "xEditGridCell28");
            this.xEditGridCell28.IsReadOnly = true;
            this.xEditGridCell28.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell29
            // 
            this.xEditGridCell29.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell29.ApplyPaintingEvent = true;
            this.xEditGridCell29.CellName = "lot";
            this.xEditGridCell29.Col = 7;
            this.xEditGridCell29.ExecuteQuery = null;
            this.xEditGridCell29.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell29, "xEditGridCell29");
            this.xEditGridCell29.IsReadOnly = true;
            this.xEditGridCell29.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell30
            // 
            this.xEditGridCell30.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell30.CellName = "expired_date";
            this.xEditGridCell30.CellType = IHIS.Framework.XCellDataType.Date;
            this.xEditGridCell30.CellWidth = 76;
            this.xEditGridCell30.Col = 8;
            this.xEditGridCell30.ExecuteQuery = null;
            this.xEditGridCell30.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell30, "xEditGridCell30");
            this.xEditGridCell30.IsReadOnly = true;
            this.xEditGridCell30.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell31
            // 
            this.xEditGridCell31.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell31.CellName = "ipgo_qty";
            this.xEditGridCell31.CellWidth = 116;
            this.xEditGridCell31.Col = 9;
            this.xEditGridCell31.ExecuteQuery = null;
            this.xEditGridCell31.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell31, "xEditGridCell31");
            this.xEditGridCell31.IsReadOnly = true;
            this.xEditGridCell31.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell32
            // 
            this.xEditGridCell32.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell32.CellName = "ipgo_danui_name";
            this.xEditGridCell32.Col = 10;
            this.xEditGridCell32.ExecuteQuery = null;
            this.xEditGridCell32.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell32, "xEditGridCell32");
            this.xEditGridCell32.IsReadOnly = true;
            this.xEditGridCell32.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell10.CellName = "ipgo_type";
            this.xEditGridCell10.CellWidth = 132;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.ExecuteQuery = null;
            this.xEditGridCell10.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            this.xEditGridCell10.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell11.CellName = "upd_id";
            this.xEditGridCell11.CellWidth = 112;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            this.xEditGridCell11.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            this.xEditGridCell11.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell38
            // 
            this.xEditGridCell38.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell38.CellName = "import_code";
            this.xEditGridCell38.Col = 12;
            this.xEditGridCell38.ExecuteQuery = null;
            this.xEditGridCell38.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell38, "xEditGridCell38");
            this.xEditGridCell38.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // xEditGridCell39
            // 
            this.xEditGridCell39.AlterateRowFont = new System.Drawing.Font("Arial", 8.75F);
            this.xEditGridCell39.CellName = "comment";
            this.xEditGridCell39.Col = 13;
            this.xEditGridCell39.ExecuteQuery = null;
            this.xEditGridCell39.HeaderFont = new System.Drawing.Font("Arial", 9.25F);
            resources.ApplyResources(this.xEditGridCell39, "xEditGridCell39");
            this.xEditGridCell39.RowFont = new System.Drawing.Font("Arial", 8.75F);
            // 
            // INV4001U00
            // 
            this.Controls.Add(this.grdPrint);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel1);
            resources.ApplyResources(this, "$this");
            this.Name = "INV4001U00";
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdINV4001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV4002)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            this.xPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbxJaeryoGubun.Visible = true;
            xLabel1.Visible = true;
            // SaveLayout 설정
            //this.SaveLayoutList.Add(this.grdINV4001);
            //this.SaveLayoutList.Add(this.grdINV4002);

            // 그리드 SavePerformer 설정
            //this.grdINV4001.SavePerformer = new XSavePerformer(this);
            //this.grdINV4002.SavePerformer = this.grdINV4001.SavePerformer;

            // Master-Detail 관계 설정
            //this.grdINV4002.SetRelationKey("fkinv4001", "pkinv4001");
            //this.grdINV4002.SetRelationTable("INV4002");

            grdINV4001.ExecuteQuery = LoadGrdINV4001;
            grdINV4002.ExecuteQuery = LoadGrdINV4002;

            //cbxActor.SetDictDDLB(LoadActor());
            cbxBuseo.SetDictDDLB(LoadCombo());
            cbxJaeryoGubun.ExecuteQuery = GetCbxChulgoType;
            cbxJaeryoGubun.SetDictDDLB();
            cbxJaeryoGubun.SetDataValue("%");

            this.CurrMSLayout = this.grdINV4001;

            PostCallHelper.PostCall(new PostMethod(PostLoad));

            this.Parent.Size = new Size(1200, 580);
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

            this.btnList.PerformClick(FunctionType.Query);

            this.Parent.Size = new Size(1200, 580);
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

                    this.grdINV4001.QueryLayout(false);
                    break;

                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.CurrMSLayout == this.grdINV4001)
                    {
                        if (this.grdINV4001.RowCount > 0)
                        {
                            for (int i = 0; i < this.grdINV4001.RowCount; i++)
                            {
                                // 마스터 그리드 2행 이상 입력 방지
                                if (this.grdINV4001.LayoutTable.Rows[i].RowState == DataRowState.Added)
                                {
                                    this.ShowMessage("MasterInsert");
                                    return;
                                }
                            }
                        }

                        this.Insert_grdInv4001();

                        //https://sofiamedix.atlassian.net/browse/MED-14737
                        txtUserID.Text = UserInfo.UserID;
                        txtUserName.Text = UserInfo.UserName;
                    }
                    else
                    {
                        // 마스터 그리드 데이타 존재 여부 확인
                        if (this.grdINV4001.RowCount == 0)
                        {
                            this.ShowMessage("DetailInsert");
                            return;
                        }
                        else
                        {
                            this.Insert_grdInv4002();
                        }
                    }

                    break;

                case FunctionType.Delete:
                    if (this.CurrMSLayout == this.grdINV4001 && grdINV4001.GetRowState(grdINV4001.CurrentRowNumber)!= DataRowState.Added)
                    {
                        e.IsBaseCall = false;
                        this.ShowMessage("Revert");
                        return;
                    }
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    //if (!this.grdINV4001.SaveLayout())
                    //{
                    //    this.ShowMessage("ServiceError");
                    //    return;
                    //}
                    //else
                    //{
                    //    if (!this.grdINV4002.SaveLayout())
                    //    {
                    //        this.ShowMessage("ServiceError");
                    //        return;
                    //    }
                    //}
                    if (!ValidateData())
                    {
                        this.grdINV4001.QueryLayout(false);
                        return;
                    }
                    if (!SaveGridLayout())
                    {
                        return;
                    }
                    this.grdINV4001.QueryLayout(false);
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
                    msg = Resources.MSG_001;
                    cpt = Resources.CAP_001;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "DetailInsert":
                    msg = Resources.MSG_002;
                    cpt = Resources.CAP_002;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "SaveSuccess":
                    msg = Resources.MSG_003;
                    cpt = Resources.CAP_001;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                case "ServiceError":
                    msg = String.Format(Resources.MSG_004, Service.ErrFullMsg);
                    cpt = Resources.CAP_003;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Error);
                    break;
                case "Revert":
                    msg = Resources.MSG_011;
                    cpt = Resources.CAP_001;
                    XMessageBox.Show(msg, cpt, MessageBoxIcon.Information);
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region Insert_grdInv4001
        private void Insert_grdInv4001()
        {
            int row = this.grdINV4001.InsertRow(-1);

            this.grdINV4001.SetItemValue(row, "pkinv4001", this.getPkINV4001());
            this.grdINV4001.SetItemValue(row, "churi_date", this.dtpChuriDate.GetDataValue());
            this.grdINV4001.SetItemValue(row, "churi_buseo", this.cbxBuseo.GetDataValue());
            this.grdINV4001.SetItemValue(row, "ipchul_type", "I");
            this.grdINV4001.SetItemValue(row, "in_out_gubun", "N");

            // https://sofiamedix.atlassian.net/browse/MED-12323
            //string importCode = "";
            //// Auto-generates an import code
            //StringResult res = CloudService.Instance.Submit<StringResult, INV4001U00Grd4001GenImportCodeArgs>(new INV4001U00Grd4001GenImportCodeArgs());
            //if (res.ExecutionStatus == ExecutionStatus.Success)
            //{
            //    importCode = string.Concat(res.Result, this.cbxBuseo.GetDataValue());
            //}
            //this.grdINV4001.SetItemValue(row, "import_code", importCode);
            this.grdINV4001.SetItemValue(row, "import_time", EnvironInfo.GetSysDateTime().ToString("hh:mm"));
        }
        #endregion

        #region [getPkINV4001]
        private string getPkINV4001()
        {

            return NextSequence();
            //BindVarCollection bindVar = new BindVarCollection();

            //string cmdText = @"SELECT INV4001_SEQ.NEXTVAL FROM SYS.DUAL";

            //object retval = Service.ExecuteScalar(cmdText, bindVar);

            //return retval.ToString();
        }
        #endregion

        #region Insert_grdInv4002
        private void Insert_grdInv4002()
        {
            int row = this.grdINV4002.InsertRow(-1);
            this.grdINV4002.SetItemValue(row, "fkinv4001", grdINV4001.GetItemString(grdINV4001.CurrentRowNumber, "pkinv4001"));
        }
        #endregion

        #region grdINV4001 EVENT
        private void grdINV4001_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINV4001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            //this.grdINV4001.SetBindVarValue("f_churi_date", this.dtpChuriDate.GetDataValue());
            this.grdINV4001.SetBindVarValue("f_from_date", this.dtpFromDate.GetDataValue());
            this.grdINV4001.SetBindVarValue("f_to_date", this.dtpToDate.GetDataValue());
        }

        private void grdINV4001_RowFocusChanging(object sender, RowFocusChangingEventArgs e)
        {
            for (int i = 0; i < this.grdINV4002.RowCount; i++)
            {
                if (this.grdINV4002.GetRowState(i) != DataRowState.Unchanged)
                {
                    if (XMessageBox.Show(Resources.MSG_005, Resources.CAP_005, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        this.grdINV4002.SaveLayout();
                    }
                }
            }
        }

        private void grdINV4001_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdINV4002.QueryLayout(false);
            txtUserID.Text = grdINV4001.GetItemString(grdINV4001.CurrentRowNumber, "input_user");

        }
        #endregion

        #region grdINV4002 EVENT
        private void grdInv4002_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdINV4002.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINV4002.SetBindVarValue("f_fkinv4001", this.grdINV4001.GetItemString(this.grdINV4001.CurrentRowNumber, "pkinv4001"));
        }

        private void grdINV4002_PreSaveLayout(object sender, GridRecordEventArgs e)
        {
            this.grdINV4002.SetItemValue(e.RowNumber, "fkinv4001", this.grdINV4001.GetItemString(this.grdINV4001.CurrentRowNumber, "pkinv4001"));
        }

        private void grdINV4002_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;

            switch (grid.Name)
            {
                case "grdINV4002":

                    if (e.ColName == "jaeryo_code")
                    {
                        this.OpenScreen_INV0110Q00(grid.GetItemString(e.RowNumber, e.ColName));
                    }

                    if (e.ColName == "ipgo_qty")
                    {
                        double sum = double.Parse(e.ChangeValue.ToString()) * this.grdINV4002.GetItemDouble(e.RowNumber, "ipgo_danga");

                        this.grdINV4002.SetItemValue(e.RowNumber, "sum_danga", sum);
                    }

                    break;
            }
        }

        private void grdINV4002_GridFindClick(object sender, GridFindClickEventArgs e)
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

            int rowCtn = this.grdINV4002.CurrentRowNumber;

            XScreen.OpenScreenWithParam(this, "INVS", "INV0110Q00", ScreenOpenStyle.ResponseFixed, param);

            //this.grdINV4002.SelectRow(rowCtn);
            //this.grdINV4002.SetFocusToItem(rowCtn, "ipgo_qty", true);
        }
        
        public override object Command(string command, CommonItemCollection commandParam)
        {
            XEditGrid grid = this.grdINV4002;

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
                                if (grid.GetItemString(grid.CurrentRowNumber, "ipgo_danga") != "")
                                {
                                    this.btnList.PerformClick(FunctionType.Insert);
                                }

                                grid.SetItemValue(grid.CurrentRowNumber, "jaeryo_code", dr["jaeryo_code"].ToString());
                                grid.SetItemValue(grid.CurrentRowNumber, "jaeryo_name", dr["jaeryo_name"].ToString());
                                grid.SetItemValue(grid.CurrentRowNumber, "ipgo_danui", dr["subul_danui_name"].ToString());
                                grid.SetItemValue(grid.CurrentRowNumber, "ipgo_danga", dr["subul_danga"].ToString());
                            }
                        }
                    }
                    #endregion

                    break;
                //https://sofiamedix.atlassian.net/browse/MED-14593
                case "ADM104Q":
                    //XMessageBox.Show(commandParam["user_id"].ToString() + "---" + commandParam["user_name"].ToString());
                    txtUserID.SetDataValue(commandParam["user_id"]);
                    txtUserName.SetDataValue(commandParam["user_name"]);
                    break;

            }
            return base.Command(command, commandParam);
        }
        #endregion

        #region Cloud

        private IList<object[]> LoadGrdINV4001(BindVarCollection bc)
        {
            List<object[]> lst = new List<object[]>();

            INV4001U00Grd4001Args args = new INV4001U00Grd4001Args();
            args.FFromDate = bc["f_from_date"].VarValue;
            args.FToDate = bc["f_to_date"].VarValue;
            args.FIpgoType = cbxJaeryoGubun.GetDataValue();
            INV4001U00Grd4001Result result =
                CloudService.Instance.Submit<INV4001U00Grd4001Result, INV4001U00Grd4001Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INV4001U00Grd4001Info item in result.Lst)
                {
                    lst.Add(new object[]
                    {
                        item.Pkinv4001,
                        item.ChuriDate,
                        TypeCheck.IsNull(item.ImportTime) || item.ImportTime.Length < 2 ? "" : item.ImportTime.Insert(2, ":"),
                        item.ChuriBuseo,
                        item.IpgoType,
                        item.ImportCode,
                        item.ChuriSeq,
                        item.JaeryoGubun,
                        item.Remark,
                        item.InOutGubun,
                        item.IpchulType,
                        item.InputUser
                    });
                }
            }
            INV4001U00_rowcount = lst.Count;
            return lst;
        }

        private IList<object[]> LoadGrdINV4002(BindVarCollection bc)
        {
            List<object[]> lst = new List<object[]>();

            INV4001U00Grd4002Args args = new INV4001U00Grd4002Args();
            args.FFkinv4001 = bc["f_fkinv4001"].VarValue;
            INV4001U00Grd4002Result result =
                CloudService.Instance.Submit<INV4001U00Grd4002Result, INV4001U00Grd4002Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INV4001U00Grd4002Info item in result.Lst)
                {
                    lst.Add(new object[]
                    {
                        item.Pkinv4002,
                        item.Fkinv4001,
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.IpgoQty,
                        item.IpgoDanui,
                        item.IpgoDanga,
                        item.Remark,
                        item.SumDanga,
                        item.StartDate,
                        item.Lot,
                        item.EndDate
                    });
                }
            }
            return lst;
        }

        private IList<object[]> LoadActor()
        {
            List<object[]> lst = new List<object[]>();

            INV4001U00DrugUserArgs args = new INV4001U00DrugUserArgs();
            INV4001U00DrugUserResult result =
                CloudService.Instance.Submit<INV4001U00DrugUserResult, INV4001U00DrugUserArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INV4001U00DrugUserInfo item in result.Lst)
                {
                    lst.Add(new object[]
                    {
                        item.UserId,
                        item.UserNm
                    });
                }
            }
            return lst;
        }

        private IList<object[]> LoadCombo()
        {
            List<object[]> lst = new List<object[]>();

            INV4001LoadBuseoArgs args = new INV4001LoadBuseoArgs();
            INV4001LoadBuseoResult result =
                CloudService.Instance.Submit<INV4001LoadBuseoResult, INV4001LoadBuseoArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INV4001LoadBuseoInfo item in result.Lst)
                {
                    lst.Add(new object[]
                    {
                        item.BuseoCode,
                        item.BuseoName
                    });
                }
            }
            return lst;
        }

        private string NextSequence()
        {
            INV4001NextSeqArgs args = new INV4001NextSeqArgs();
            INV4001NextSeqResult result =
                CloudService.Instance.Submit<INV4001NextSeqResult, INV4001NextSeqArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.NextVal;
            }
            return "";
        }

        private IList<object[]> GetGridCellCombo(BindVarCollection bc)
        {
            List<object[]> lst = new List<object[]>();

            INV4001U00LoadCodeNameArgs args = new INV4001U00LoadCodeNameArgs();
            INV4001U00LoadCodeNameResult result =
                CloudService.Instance.Submit<INV4001U00LoadCodeNameResult, INV4001U00LoadCodeNameArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INV4001U00LoadCodeNameInfo item in result.Lst)
                {
                    lst.Add(new object[]
                    {
                        item.Code,
                        item.CodeName
                    });
                }
            }
            return lst;
        }

        private bool ValidateData()
        {
            //string jaeryo_code = "";
            //string jaeryo_name = "";

            // https://sofiamedix.atlassian.net/browse/MED-12664
            //if (grdINV4001.CurrentRowNumber > INV4001U00_rowcount &&  grdINV4002.RowCount <= 0);
            if (grdINV4001.CurrentRowNumber > INV4001U00_rowcount && grdINV4002.RowCount <= 0)
            {
                XMessageBox.Show(Resources.MSG_012, Resources.MSG_012_CAP, MessageBoxIcon.Information);
                return false;
            }

            for (int i = 0; i < grdINV4002.RowCount; i++)
            {
                if (grdINV4002.GetItemString(i, "jaeryo_code") == "" || grdINV4002.GetItemString(i, "jaeryo_name") == ""
                    || grdINV4002.RowCount <=0)
                {
                    XMessageBox.Show(Resources.MSG_012, Resources.MSG_012_CAP, MessageBoxIcon.Information);
                    return false;
                }
            }

            
            return true;
        
        }

        private bool SaveGridLayout()
        {
            INV4001SaveLayoutArgs args = new INV4001SaveLayoutArgs();
            args.Inv4001 = new List<INV4001U00Grd4001Info>();
            args.Inv4002 = new List<INV4001U00Grd4002Info>();

            for (int i = 0; i < grdINV4001.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdINV4001.GetRowState(i) == DataRowState.Unchanged) continue;

                INV4001U00Grd4001Info item = new INV4001U00Grd4001Info();
                item.Pkinv4001 = grdINV4001.GetItemString(i, "pkinv4001");
                item.ChuriDate = grdINV4001.GetItemString(i, "churi_date");
                item.ChuriBuseo = grdINV4001.GetItemString(i, "churi_buseo");
                item.IpgoType = grdINV4001.GetItemString(i, "ipgo_type");
                item.ChuriSeq = grdINV4001.GetItemString(i, "churi_seq");
                item.JaeryoGubun = grdINV4001.GetItemString(i, "jaeryo_gubun");
                item.Remark = grdINV4001.GetItemString(i, "remark");
                item.InOutGubun = grdINV4001.GetItemString(i, "in_out_gubun");
                item.IpchulType = grdINV4001.GetItemString(i, "ipchul_type");

                // https://sofiamedix.atlassian.net/browse/MED-12323
                item.ImportCode = grdINV4001.GetItemString(i, "import_code");
                item.ImportTime = grdINV4001.GetItemString(i, "import_time").Replace(":", "");

                //https://sofiamedix.atlassian.net/browse/MED-14737
                item.InputUser = grdINV4001.GetItemString(i, "input_user");

                item.RowState = grdINV4001.GetRowState(i).ToString();

                args.Inv4001.Add(item);

                if (string.IsNullOrEmpty(item.IpgoType))
                {
                    XMessageBox.Show(Resources.MSG_010, Resources.CAP_003, MessageBoxIcon.Error);
                    return false;
                }
            }

            // For delete
            if (null != grdINV4001.DeletedRowTable)
            {
                foreach (DataRow dr in grdINV4001.DeletedRowTable.Rows)
                {
                    INV4001U00Grd4001Info item = new INV4001U00Grd4001Info();
                    item.Pkinv4001 = dr["pkinv4001"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    args.Inv4001.Add(item);
                }
            }
            //args.Inv4001 = lst4001;
            for (int i = 0; i < grdINV4002.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdINV4002.GetRowState(i) == DataRowState.Unchanged) continue;

                INV4001U00Grd4002Info item = new INV4001U00Grd4002Info();
                item.Pkinv4002 = grdINV4002.GetItemString(i, "pkinv4002");
                item.Fkinv4001 = grdINV4002.GetItemString(i, "fkinv4001");
                item.JaeryoCode = grdINV4002.GetItemString(i, "jaeryo_code");
                item.JaeryoName = grdINV4002.GetItemString(i, "jaeryo_name");
                item.IpgoQty = grdINV4002.GetItemString(i, "ipgo_qty");
                item.IpgoDanui = grdINV4002.GetItemString(i, "ipgo_danui");
                item.IpgoDanga = grdINV4002.GetItemString(i, "ipgo_danga");
                item.Remark = grdINV4002.GetItemString(i, "remark");
                item.SumDanga = grdINV4002.GetItemString(i, "sum_danga");
                item.RowState = grdINV4002.GetRowState(i).ToString();
                item.StartDate = grdINV4002.GetItemString(i, "start_date");
                item.Lot = grdINV4002.GetItemString(i, "lot");
                item.EndDate = grdINV4002.GetItemString(i, "end_date");
                
                args.Inv4002.Add(item);
                if (string.IsNullOrEmpty(item.Lot))
                {
                    XMessageBox.Show(Resources.MSG_006, Resources.CAP_003, MessageBoxIcon.Error);
                    return false;
                }
                //if (string.IsNullOrEmpty(item.StartDate))
                //{
                //    XMessageBox.Show(Resources.MSG_007, Resources.CAP_003, MessageBoxIcon.Error);
                //    return false;
                //}
                if (string.IsNullOrEmpty(item.EndDate))
                {
                    XMessageBox.Show(Resources.MSG_008, Resources.CAP_003, MessageBoxIcon.Error);
                    return false;
                }
                if (!string.IsNullOrEmpty(item.StartDate))
                {
                    DateTime startDate = DateTime.ParseExact(item.StartDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime endDate = DateTime.ParseExact(item.EndDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    if (startDate >= endDate)
                    {
                        XMessageBox.Show(Resources.MSG_009, Resources.CAP_003, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            // For delete
            if (null != grdINV4002.DeletedRowTable)
            {
                foreach (DataRow dr in grdINV4002.DeletedRowTable.Rows)
                {
                    INV4001U00Grd4002Info item = new INV4001U00Grd4002Info();
                    item.Pkinv4002 = dr["pkinv4002"].ToString();
                    item.Fkinv4001 = dr["fkinv4001"].ToString();
                    item.JaeryoCode = dr["jaeryo_code"].ToString();
                    item.JaeryoName = dr["jaeryo_name"].ToString();
                    item.IpgoQty = dr["ipgo_qty"].ToString();
                    item.IpgoDanui = dr["ipgo_danui"].ToString();
                    item.IpgoDanga = dr["ipgo_danga"].ToString();
                    item.Remark = dr["remark"].ToString();
                    item.SumDanga = dr["sum_danga"].ToString();
                    item.StartDate = dr["start_date"].ToString();
                    item.Lot = dr["lot"].ToString();
                    item.EndDate = dr["end_date"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    args.Inv4002.Add(item);
                }
            }

            UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV4001SaveLayoutArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result == true)
            {
                this.ShowMessage("SaveSuccess");
                return true;
            }

            this.ShowMessage("ServiceError");
            return false;
        }

        #endregion
        /* ====================================== SAVEPERFORMER ====================================== */
        #region [ XSavePerformer]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private INV4001U00 parent = null;
            public XSavePerformer(INV4001U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {

                string cmdText = "";
                object t_chk = "";
                object seq = "";
                string msg = "";
                string cap = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':
                        #region INV4001
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO INV4001 (  SYS_DATE     
                                                                 , SYS_ID
                                                                 , UPD_DATE
                                                                 , UPD_ID
                                                                 , HOSP_CODE    
                                                                 , PKINV4001    
                                                                 , CHURI_DATE   
                                                                 , CHURI_BUSEO  
                                                                 , IPGO_TYPE    
                                                                 , CHURI_SEQ    
                                                                 , JAERYO_GUBUN 
                                                                 , IPCHUL_TYPE  
                                                                 , IN_OUT_GUBUN 
                                                                 , REMARK    
                                                      ) VALUES (   SYSDATE
                                                                 , :q_user_id
                                                                 , SYSDATE
                                                                 , :q_user_id
                                                                 , :f_hosp_code
                                                                 , :f_pkinv4001
                                                                 , :f_churi_date
                                                                 , :f_churi_buseo
                                                                 , :f_ipgo_type
                                                                 , PKG_COM_UTIL.FN_MAXSEQ(:f_hosp_code, 'INV4001', 'SEQ', :f_churi_date||'-'||:f_churi_buseo||'-'||:f_ipgo_type)
                                                                 , :f_jaeryo_gubun
                                                                 , :f_ipchul_type
                                                                 , :f_in_out_gubun
                                                                 , :f_remark
                                                               )";
                                break;

                            case DataRowState.Modified:

                                cmdText = @" UPDATE INV4001      A
                                                SET A.REMARK     = :f_remark
                                              WHERE A.HOSP_CODE  = :f_hosp_code
                                                AND A.PKINV4001  = :f_pkinv4001
                                           ";

                                break;

                            case DataRowState.Deleted:
                                cmdText = @" DELETE FROM INV4001 A
                                              WHERE A.HOSP_CODE  = :f_hosp_code
                                                AND A.PKINV4001  = :f_pkinv4001
                                           ";
                                break;

                        }
                        #endregion
                    break;

                    case '2':
                        #region INV4002
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @" SELECT 'Y'
                                               FROM SYS.DUAL
                                              WHERE EXISTS ( SELECT 'X'
                                                               FROM INV4002  A
                                                              WHERE A.HOSP_CODE   = :f_hosp_code
                                                                AND A.FKINV4001   = :f_fkinv4001
                                                                AND A.JAERYO_CODE = :f_jaeryo_code
                                          ) ";


                                t_chk = Service.ExecuteScalar(cmdText, item.BindVarList);

                                if (TypeCheck.NVL(t_chk, "N").ToString() == "Y")
                                {
                                    msg = item.BindVarList["f_jaeryo_name"].VarValue + " [" + item.BindVarList["f_jaeryo_code"].VarValue + "]は " + "既に登録されている在庫コードです。";
                                    cap = "データ確認";

                                    XMessageBox.Show(msg, cap, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    return false;
                                }

                                cmdText = @" INSERT INTO INV4002 ( SYS_DATE
                                                                 , SYS_ID
                                                                 , UPD_DATE
                                                                 , UPD_ID
                                                                 , HOSP_CODE
                                                                 , PKINV4002
                                                                 , FKINV4001
                                                                 , JAERYO_CODE
                                                                 , IPGO_QTY
                                                                 , IPGO_DANGA
                                                                 , REMARK
                                                                  
                                                        ) VALUES ( SYSDATE
                                                                 , :q_user_id
                                                                 , SYSDATE
                                                                 , :q_user_id
                                                                 , :f_hosp_code
                                                                 , INV4002_SEQ.NEXTVAL
                                                                 , :f_fkinv4001
                                                                 , :f_jaeryo_code
                                                                 , :f_ipgo_qty
                                                                 , :f_ipgo_danga
                                                                 , :f_remark
                                                        ) ";

                                break;

                            case DataRowState.Modified:

                                cmdText = @" UPDATE INV4002        A
                                                SET A.IPGO_QTY     = :f_ipgo_qty
                                                  , A.IPGO_DANGA   = :f_ipgo_danga
                                                  , A.REMARK       = :f_remark
                                                  , A.UPD_DATE     = SYSDATE
                                                  , A.UPD_ID       = :q_user_id
                                              WHERE A.HOSP_CODE    = :f_hosp_code
                                                AND A.FKINV4001    = :f_fkinv4001
                                                AND A.JAERYO_CODE  = :f_jaeryo_code
                                           ";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @" DELETE FROM INV4002   A
                                              WHERE A.HOSP_CODE    = :f_hosp_code
                                                AND A.FKINV4001    = :f_fkinv4001
                                                AND A.JAERYO_CODE  = :f_jaeryo_code
                                           ";

                                break;
                        }
                        #endregion
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdINV4001_PreEndInitializing(object sender, EventArgs e)
        {
            this.xEditGridCell21.ExecuteQuery = GetGridCellCombo;
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-11446
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            this.grdPrint.ParamList = new List<string>(new string[] { "f_end_date", "f_start_date", });
            this.grdPrint.ExecuteQuery = GetGrdPrint;
            this.grdPrint.SetBindVarValue("f_start_date", this.dtpFromDate.GetDataValue());
            this.grdPrint.SetBindVarValue("f_end_date", this.dtpToDate.GetDataValue());
            this.grdPrint.QueryLayout(true);
            //List<ExportExcelInfo> lstExport = GetGrdPrint(this.dtpFromDate.GetDataValue(), this.dtpToDate.GetDataValue());

            using (SaveFileDialog svd = new SaveFileDialog())
            {
                // https://sofiamedix.atlassian.net/browse/MED-12323
                // [HOSP_CODE]_[IMPORT_CODE]_[CURRENT_DATE]_[CURRENT_TIME]
                string fileName = string.Concat(UserInfo.HospCode,
                    UNDERSCORE,
                    grdINV4001.GetItemString(grdINV4001.CurrentRowNumber, "import_code"),
                    UNDERSCORE,
                    DateTime.Now.ToString("yyyyMMdd"),
                    UNDERSCORE,
                    DateTime.Now.ToString("hhmm"));
                svd.FileName = fileName;

                svd.Filter = "csv files (*.csv)|*.csv";

                if (svd.ShowDialog() == DialogResult.OK)
                {
                    //List<string> headers = new List<string>();
                    //headers.Add(Resources.Header1);
                    //headers.Add(Resources.Header2);
                    //headers.Add(Resources.Header3);
                    //headers.Add(Resources.Header4);
                    //headers.Add(Resources.Header5);
                    //headers.Add(Resources.Header6);
                    //headers.Add(Resources.Header7);
                    //headers.Add(Resources.Header8);
                    //headers.Add(Resources.Header9);
                    //headers.Add(Resources.Header10);
                    //headers.Add(Resources.Header11);
                    //headers.Add(Resources.Header12);
                    //headers.Add(Resources.Header13);

                    // https://sofiamedix.atlassian.net/browse/MED-12323
                    //headers.Add(Resources.Header1);
                    //headers.Add(Resources.Header2);
                    //headers.Add(Resources.Header14);
                    //headers.Add(Resources.Header5);
                    //headers.Add(Resources.Header6);
                    //headers.Add(Resources.Header7);
                    //headers.Add(Resources.Header8);
                    //headers.Add(Resources.Header9);
                    //headers.Add(Resources.Header10);
                    //headers.Add(Resources.Header11);
                    //headers.Add(Resources.Header3);
                    //headers.Add(Resources.Header4);
                    //headers.Add(Resources.Header15);
                    //headers.Add(Resources.Header16);

                    //CsvExport<ExportExcelInfo> csv = new CsvExport<ExportExcelInfo>(lstExport, headers);
                    //csv.ExportToFile(svd.FileName);

                    // Get file name.
                    //string fileName = svd.FileName;
                    if (INVHelpers.ExportCSV(grdPrint, svd.FileName))
                    {
                        // Export succeeded.
                    }
                }
            }
        }

        private List<object[]> GetGrdPrint(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV4001U00ExportCSVArgs args = new INV4001U00ExportCSVArgs();
            args.EndDate = bc["f_end_date"].VarValue; 
            args.StartDate = bc["f_start_date"].VarValue;
            INV4001U00ExportCSVResult res = CloudService.Instance.Submit<INV4001U00ExportCSVResult, INV4001U00ExportCSVArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CsvItem.ForEach(delegate(INV4001U00ExportCSVInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RowNum,
                        INVHelpers.FormatDateStrByLocale(item.ChuriDate),
                        item.ImportTime,
                        item.JaeryoCode,
                        item.JaeryoName,
                        INVHelpers.FormatDateStrByLocale(item.StartDate),
                        item.Lot,
                        INVHelpers.FormatDateStrByLocale(item.ExpiredDate),
                        item.IpgoQty,
                        item.IpgoDanuiName,
                        item.IpgoType,
                        //item.UpdId,
                        //https://sofiamedix.atlassian.net/browse/MED-14729
                        txtUserID.GetDataValue(),
                        //item.IpgoDanga,
                        //item.QtyIpgoDanga,
                        item.ImportCode,
                        item.Comment,
                    });
                });
            }

            return lObj;
        }

        private List<ExportExcelInfo> GetGrdPrint(string startDate, string endDate)
        {
            List<ExportExcelInfo> lObj = new List<ExportExcelInfo>();

            INV4001U00ExportCSVArgs args = new INV4001U00ExportCSVArgs();
            args.EndDate = endDate;
            args.StartDate = startDate;
            INV4001U00ExportCSVResult res = CloudService.Instance.Submit<INV4001U00ExportCSVResult, INV4001U00ExportCSVArgs>(args);
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ",";
            provider.NumberGroupSeparator = ".";
            provider.NumberGroupSizes = new int[] { 3 };

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                DateTime date = DateTime.ParseExact("1970/01/01", "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                foreach (INV4001U00ExportCSVInfo excelInfo in res.CsvItem)
                {
                    ExportExcelInfo item = new ExportExcelInfo();
                    item.RowNum = excelInfo.RowNum;
                    if (!String.IsNullOrEmpty(excelInfo.ChuriDate))
                    {
                        item.ChuriDate = DateTime.ParseExact(excelInfo.ChuriDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        item.ChuriDate = date;
                    }
                    item.IpgoType = excelInfo.IpgoType;
                    item.UpdId = excelInfo.UpdId;
                    item.JaeryoCode = excelInfo.JaeryoCode;
                    item.JaeryoName = excelInfo.JaeryoName;
                    if (!String.IsNullOrEmpty(excelInfo.StartDate))
                    {
                        item.StartDate = DateTime.ParseExact(excelInfo.StartDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        item.StartDate = date;
                    }
                    item.Lot = Convert.ToDouble(excelInfo.Lot, provider);
                    if (!String.IsNullOrEmpty(excelInfo.ExpiredDate))
                    {
                        item.ExpiredDate = DateTime.ParseExact(excelInfo.ExpiredDate, "yyyy/MM/dd", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        item.ExpiredDate = date;
                    }
                    // // https://sofiamedix.atlassian.net/browse/MED-12323
                    //if (!String.IsNullOrEmpty(excelInfo.IpgoQty))
                    //{
                    //    //item.IpgoQty = Convert.ToDouble(excelInfo.IpgoQty, provider);
                    //}
                    //else
                    //{
                    //    //item.IpgoQty = 0;
                    //}
                    item.IpgoDanuiName = excelInfo.IpgoDanuiName;
                    if (!String.IsNullOrEmpty(excelInfo.IpgoDanga))
                    {
                        item.IpgoDanga = Convert.ToDouble(excelInfo.IpgoDanga, provider);
                    }
                    else
                    {
                        //item.IpgoQty = 0;
                    }
                    //if (!String.IsNullOrEmpty(excelInfo.QtyIpgoDanga))
                    //{
                    //    //item.QtyIpgoDanga = Convert.ToDouble(excelInfo.QtyIpgoDanga, provider);
                    //}
                    //else
                    //{
                    //    //item.IpgoQty = 0;
                    //}

                    lObj.Add(item);

                }
            }

            return lObj;
        }

        private IList<object[]> GetCbxChulgoType(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();
            INV2003U00GetCbxChulgoTypeArgs args = new INV2003U00GetCbxChulgoTypeArgs();
            args.HospCode = UserInfo.HospCode.ToString();
            args.CodeType = "IPGO_TYPE";
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

        private void grdINV4002_Enter(object sender, EventArgs e)
        {
            if (grdINV4001.GetRowState(grdINV4001.CurrentRowNumber) != DataRowState.Added)
            {
                HideButtonList(false);
            }
        }

        private void HideButtonList(bool visible)
        {
            btnList.SetEnabled(FunctionType.Update, visible);
            btnList.SetEnabled(FunctionType.Delete, visible);
            btnList.SetEnabled(FunctionType.Insert, visible);
        }

        private void grdINV4001_Enter(object sender, EventArgs e)
        {
            HideButtonList(true);
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
            grdINV4001.SetItemValue(grdINV4001.CurrentRowNumber, "input_user", txtUserID.GetDataValue());

            ADM104QGetPatientArgs args = new ADM104QGetPatientArgs();
            args.UserId = txtUserID.GetDataValue();

            ADM104QGetPatientResult res = CloudService.Instance.Submit<ADM104QGetPatientResult, ADM104QGetPatientArgs>(args);
            if (res.ExecutionStatus == ExecutionStatus.Success && res.Exist == true)
            {
                txtUserName.Text = res.UserName;
            }
        }
    }

    public class ExportExcelInfo
    {
        private String _rowNum; // 1
        private DateTime _churiDate; // 2
        private String _jaeryoCode; // 5
        private String _jaeryoName; // 6
        private DateTime _startDate; // 7
        private double _lot; // 8
        private DateTime _expiredDate; // 9
        private double _ipgoDanga; // 12
        private String _ipgoDanuiName; // 11
        private String _ipgoType; // 3
        private String _updId; // 4
        //private double _ipgoQty; // 10
        //private double _qtyIpgoDanga; // 13

        public String RowNum
        {
            get { return this._rowNum; }
            set { this._rowNum = value; }
        }

        public DateTime ChuriDate
        {
            get { return this._churiDate; }
            set { this._churiDate = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public double Lot
        {
            get { return this._lot; }
            set { this._lot = value; }
        }

        public DateTime ExpiredDate
        {
            get { return this._expiredDate; }
            set { this._expiredDate = value; }
        }

        public double IpgoDanga
        {
            get { return this._ipgoDanga; }
            set { this._ipgoDanga = value; }
        }

        public String IpgoDanuiName
        {
            get { return this._ipgoDanuiName; }
            set { this._ipgoDanuiName = value; }
        }

        //public double IpgoQty
        //{
        //    get { return this._ipgoQty; }
        //    set { this._ipgoQty = value; }
        //}

        public String IpgoType
        {
            get { return this._ipgoType; }
            set { this._ipgoType = value; }
        }

        public String UpdId
        {
            get { return this._updId; }
            set { this._updId = value; }
        }

        //public double QtyIpgoDanga
        //{
        //    get { return this._qtyIpgoDanga; }
        //    set { this._qtyIpgoDanga = value; }
        //}
    }
}