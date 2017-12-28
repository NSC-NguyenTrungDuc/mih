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
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Models.System;
using INVS.Libs;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using System.IO;
using System.Text;
#endregion

namespace IHIS.INVS
{
    /// <summary>
    /// INV6002U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INV6000U00 : IHIS.Framework.XScreen
    {
        #region Controls

        private IHIS.Framework.XButtonList btnList;
        private XPanel pnlMiddle;
        private XEditGrid grdINV6001;
        private XPanel pnlButtom;
        private XPanel pnlTop;
        private XEditGridCell xEditGridCell17;
        private XEditGridCell xEditGridCell19;
        private XEditGridCell xEditGridCell20;
        private XEditGridCell xEditGridCell22;
        private XLabel xLabel28;
        private XDatePicker dtpChuriDate;
        private XLabel xLabel14;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XLabel xLabel1;
        private XMonthBox mtbMonth;
        private XEditGridCell xEditGridCell1;
        private XEditGridCell xEditGridCell2;
        private SingleLayout layINV6000;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private SingleLayoutItem singleLayoutItem3;
        private SingleLayoutItem singleLayoutItem4;
        private SingleLayoutItem singleLayoutItem5;
        private XPanel pnlRight;
        private XPanel pnlLeft;
        private XDisplayBox dbxChuriUser;
        private XDisplayBox dbxChuriMonth;
        private XDisplayBox dbxStatus;
        private XDisplayBox dbxChuriDate;
        private XLabel xLabel2;
        private XLabel xLabel6;
        private XLabel xLabel5;
        private XLabel xLabel4;
        private XLabel xLabel3;
        private XTextBox txtRemark;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell4;
        private IHIS.Framework.MultiLayout laySummary_d;
        private IHIS.Framework.MultiLayout laySummary_m;
        private IHIS.Framework.XDataWindow dwSummary;
        private MultiLayoutItem multiLayoutItem7;
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
        private MultiLayoutItem multiLayoutItem18;
        private MultiLayoutItem multiLayoutItem19;
        private XButton btnExportExcel;
        private XLabel xLabel7;
        private XFindBox fbxInventory;
        private XEditGrid grdPrint;
        private XEditGridCell xEditGridCell5;
        private XEditGridCell xEditGridCell6;
        private XEditGridCell xEditGridCell10;
        private XEditGridCell xEditGridCell11;
        private XEditGridCell xEditGridCell12;
        private XEditGridCell xEditGridCell13;
        private XEditGridCell xEditGridCell14;
        private XEditGridCell xEditGridCell15;
        private XEditGridCell xEditGridCell16;
        private XEditGridCell xEditGridCell18;
        private XEditGridCell xEditGridCell21;
        private XDisplayBox dbxInventory;
        private XDictComboBox cbxDifference;
        private XComboItem xComboItem4;
        private XComboItem xComboItem5;
        private XComboItem xComboItem6;
        private XLabel xLabel8;
        private XLabel xLabel9;
        private XDisplayBox dbxProcessTime;
        private SingleLayoutItem singleLayoutItem6;
        private XButton btnChange;
        private XDisplayBox dbxDocName;
        private XDisplayBox dbxDocCode;
        private System.ComponentModel.Container components = null;
        #endregion

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>

        public INV6000U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.InitCloud();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INV6000U00));
            this.btnList = new IHIS.Framework.XButtonList();
            this.pnlMiddle = new IHIS.Framework.XPanel();
            this.pnlRight = new IHIS.Framework.XPanel();
            this.grdPrint = new IHIS.Framework.XEditGrid();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell14 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell15 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell16 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell18 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell21 = new IHIS.Framework.XEditGridCell();
            this.grdINV6001 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell22 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell20 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell19 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.pnlLeft = new IHIS.Framework.XPanel();
            this.xLabel9 = new IHIS.Framework.XLabel();
            this.dbxProcessTime = new IHIS.Framework.XDisplayBox();
            this.txtRemark = new IHIS.Framework.XTextBox();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxStatus = new IHIS.Framework.XDisplayBox();
            this.dbxChuriDate = new IHIS.Framework.XDisplayBox();
            this.dbxChuriUser = new IHIS.Framework.XDisplayBox();
            this.dbxChuriMonth = new IHIS.Framework.XDisplayBox();
            this.pnlButtom = new IHIS.Framework.XPanel();
            this.btnExportExcel = new IHIS.Framework.XButton();
            this.dwSummary = new IHIS.Framework.XDataWindow();
            this.pnlTop = new IHIS.Framework.XPanel();
            this.btnChange = new IHIS.Framework.XButton();
            this.dbxDocName = new IHIS.Framework.XDisplayBox();
            this.dbxDocCode = new IHIS.Framework.XDisplayBox();
            this.cbxDifference = new IHIS.Framework.XDictComboBox();
            this.xComboItem4 = new IHIS.Framework.XComboItem();
            this.xComboItem5 = new IHIS.Framework.XComboItem();
            this.xComboItem6 = new IHIS.Framework.XComboItem();
            this.xLabel8 = new IHIS.Framework.XLabel();
            this.dbxInventory = new IHIS.Framework.XDisplayBox();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.fbxInventory = new IHIS.Framework.XFindBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.mtbMonth = new IHIS.Framework.XMonthBox();
            this.xLabel28 = new IHIS.Framework.XLabel();
            this.dtpChuriDate = new IHIS.Framework.XDatePicker();
            this.xLabel14 = new IHIS.Framework.XLabel();
            this.layINV6000 = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem3 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem4 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem5 = new IHIS.Framework.SingleLayoutItem();
            this.singleLayoutItem6 = new IHIS.Framework.SingleLayoutItem();
            this.laySummary_d = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem13 = new IHIS.Framework.MultiLayoutItem();
            this.laySummary_m = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem14 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem15 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem16 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem17 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem18 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem19 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.pnlMiddle.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV6001)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.pnlButtom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySummary_d)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySummary_m)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.Images.SetKeyName(0, "YESUP1.ICO");
            this.ImageList.Images.SetKeyName(1, "YESEN1.ICO");
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, global::IHIS.INVS.Properties.Resources.TXT_QUERY, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Process, System.Windows.Forms.Shortcut.None, global::IHIS.INVS.Properties.Resources.TXT_PROCESS, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Reset, System.Windows.Forms.Shortcut.None, global::IHIS.INVS.Properties.Resources.TXT_RESET, -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, global::IHIS.INVS.Properties.Resources.TXT_CLOSE, -1, "")});
            this.btnList.IsVisibleReset = false;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.AccessibleDescription = null;
            this.pnlMiddle.AccessibleName = null;
            resources.ApplyResources(this.pnlMiddle, "pnlMiddle");
            this.pnlMiddle.BackgroundImage = null;
            this.pnlMiddle.Controls.Add(this.pnlRight);
            this.pnlMiddle.Controls.Add(this.pnlLeft);
            this.pnlMiddle.Font = null;
            this.pnlMiddle.Name = "pnlMiddle";
            // 
            // pnlRight
            // 
            this.pnlRight.AccessibleDescription = null;
            this.pnlRight.AccessibleName = null;
            resources.ApplyResources(this.pnlRight, "pnlRight");
            this.pnlRight.BackgroundImage = null;
            this.pnlRight.Controls.Add(this.grdPrint);
            this.pnlRight.Controls.Add(this.grdINV6001);
            this.pnlRight.Font = null;
            this.pnlRight.Name = "pnlRight";
            // 
            // grdPrint
            // 
            resources.ApplyResources(this.grdPrint, "grdPrint");
            this.grdPrint.CallerID = '2';
            this.grdPrint.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell10,
            this.xEditGridCell11,
            this.xEditGridCell12,
            this.xEditGridCell13,
            this.xEditGridCell14,
            this.xEditGridCell15,
            this.xEditGridCell16,
            this.xEditGridCell18,
            this.xEditGridCell21});
            this.grdPrint.ColPerLine = 11;
            this.grdPrint.Cols = 11;
            this.grdPrint.ExecuteQuery = null;
            this.grdPrint.FixedRows = 1;
            this.grdPrint.HeaderHeights.Add(21);
            this.grdPrint.Name = "grdPrint";
            this.grdPrint.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPrint.ParamList")));
            this.grdPrint.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdPrint.Rows = 2;
            this.grdPrint.ToolTipActive = true;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "seq";
            this.xEditGridCell5.CellWidth = 85;
            this.xEditGridCell5.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell5.EnableSort = true;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "jaeryo_code";
            this.xEditGridCell6.CellWidth = 310;
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.EnableSort = true;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.IsReadOnly = true;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "jaeryo_name";
            this.xEditGridCell10.CellWidth = 132;
            this.xEditGridCell10.Col = 2;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsReadOnly = true;
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "ipgo_danui_name";
            this.xEditGridCell11.CellWidth = 112;
            this.xEditGridCell11.Col = 3;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            this.xEditGridCell11.IsReadOnly = true;
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "danga";
            this.xEditGridCell12.CellWidth = 117;
            this.xEditGridCell12.Col = 4;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            this.xEditGridCell12.IsReadOnly = true;
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell13.CellName = "pre_m_jaego_qty";
            this.xEditGridCell13.CellWidth = 109;
            this.xEditGridCell13.Col = 5;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            this.xEditGridCell13.IsReadOnly = true;
            this.xEditGridCell13.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell14
            // 
            this.xEditGridCell14.CellName = "ipgo_qty";
            this.xEditGridCell14.CellWidth = 111;
            this.xEditGridCell14.Col = 6;
            this.xEditGridCell14.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell14, "xEditGridCell14");
            this.xEditGridCell14.IsReadOnly = true;
            // 
            // xEditGridCell15
            // 
            this.xEditGridCell15.ApplyPaintingEvent = true;
            this.xEditGridCell15.CellName = "chulgo_qty";
            this.xEditGridCell15.Col = 7;
            this.xEditGridCell15.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell15, "xEditGridCell15");
            this.xEditGridCell15.IsReadOnly = true;
            // 
            // xEditGridCell16
            // 
            this.xEditGridCell16.CellName = "jaego_qty";
            this.xEditGridCell16.CellWidth = 76;
            this.xEditGridCell16.Col = 8;
            this.xEditGridCell16.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell16, "xEditGridCell16");
            this.xEditGridCell16.IsReadOnly = true;
            // 
            // xEditGridCell18
            // 
            this.xEditGridCell18.CellName = "adj_amt";
            this.xEditGridCell18.CellWidth = 116;
            this.xEditGridCell18.Col = 9;
            this.xEditGridCell18.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell18, "xEditGridCell18");
            this.xEditGridCell18.IsReadOnly = true;
            // 
            // xEditGridCell21
            // 
            this.xEditGridCell21.CellName = "danga_jaego_qty";
            this.xEditGridCell21.Col = 10;
            this.xEditGridCell21.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell21, "xEditGridCell21");
            this.xEditGridCell21.IsReadOnly = true;
            // 
            // grdINV6001
            // 
            resources.ApplyResources(this.grdINV6001, "grdINV6001");
            this.grdINV6001.CallerID = '2';
            this.grdINV6001.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell17,
            this.xEditGridCell7,
            this.xEditGridCell22,
            this.xEditGridCell20,
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell8,
            this.xEditGridCell19,
            this.xEditGridCell9});
            this.grdINV6001.ColPerLine = 9;
            this.grdINV6001.Cols = 10;
            this.grdINV6001.ExecuteQuery = null;
            this.grdINV6001.FixedCols = 1;
            this.grdINV6001.FixedRows = 1;
            this.grdINV6001.HeaderHeights.Add(21);
            this.grdINV6001.Name = "grdINV6001";
            this.grdINV6001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdINV6001.ParamList")));
            this.grdINV6001.RowHeaderBackColor = IHIS.Framework.XColor.XDisplayBoxGradientEndColor;
            this.grdINV6001.RowHeaderVisible = true;
            this.grdINV6001.Rows = 2;
            this.grdINV6001.ToolTipActive = true;
            this.grdINV6001.GridCellPainting += new IHIS.Framework.XGridCellPaintEventHandler(this.layINV6001_GridCellPainting);
            this.grdINV6001.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdINV6001_QueryStarting);
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jaeryo_code";
            this.xEditGridCell17.CellWidth = 85;
            this.xEditGridCell17.Col = 1;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.FindBox;
            this.xEditGridCell17.EnableSort = true;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsReadOnly = true;
            this.xEditGridCell17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "jaeryo_name";
            this.xEditGridCell7.CellWidth = 310;
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.EnableSort = true;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            // 
            // xEditGridCell22
            // 
            this.xEditGridCell22.CellName = "pre_m_jaego_qty";
            this.xEditGridCell22.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell22.CellWidth = 132;
            this.xEditGridCell22.Col = 3;
            this.xEditGridCell22.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell22, "xEditGridCell22");
            this.xEditGridCell22.IsReadOnly = true;
            // 
            // xEditGridCell20
            // 
            this.xEditGridCell20.CellName = "ipgo_qty";
            this.xEditGridCell20.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell20.CellWidth = 112;
            this.xEditGridCell20.Col = 4;
            this.xEditGridCell20.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell20, "xEditGridCell20");
            this.xEditGridCell20.IsReadOnly = true;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "chulgo_qty";
            this.xEditGridCell1.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell1.CellWidth = 117;
            this.xEditGridCell1.Col = 5;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsReadOnly = true;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.xEditGridCell2.CellName = "jaego_qty";
            this.xEditGridCell2.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell2.CellWidth = 109;
            this.xEditGridCell2.Col = 6;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            this.xEditGridCell2.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "exist_qty";
            this.xEditGridCell3.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell3.CellWidth = 111;
            this.xEditGridCell3.Col = 7;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsReadOnly = true;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.AlterateRowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xEditGridCell4.ApplyPaintingEvent = true;
            this.xEditGridCell4.CellName = "delta_qty";
            this.xEditGridCell4.CellType = IHIS.Framework.XCellDataType.Number;
            this.xEditGridCell4.Col = 8;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsReadOnly = true;
            this.xEditGridCell4.RowFont = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "subul_danui";
            this.xEditGridCell8.CellWidth = 76;
            this.xEditGridCell8.Col = 9;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsReadOnly = true;
            // 
            // xEditGridCell19
            // 
            this.xEditGridCell19.CellName = "danga";
            this.xEditGridCell19.CellWidth = 116;
            this.xEditGridCell19.Col = -1;
            this.xEditGridCell19.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell19, "xEditGridCell19");
            this.xEditGridCell19.IsReadOnly = true;
            this.xEditGridCell19.IsVisible = false;
            this.xEditGridCell19.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "adj_amt";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsReadOnly = true;
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AccessibleDescription = null;
            this.pnlLeft.AccessibleName = null;
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.BackgroundImage = null;
            this.pnlLeft.Controls.Add(this.xLabel9);
            this.pnlLeft.Controls.Add(this.dbxProcessTime);
            this.pnlLeft.Controls.Add(this.txtRemark);
            this.pnlLeft.Controls.Add(this.xLabel6);
            this.pnlLeft.Controls.Add(this.xLabel5);
            this.pnlLeft.Controls.Add(this.xLabel4);
            this.pnlLeft.Controls.Add(this.xLabel3);
            this.pnlLeft.Controls.Add(this.xLabel2);
            this.pnlLeft.Controls.Add(this.dbxStatus);
            this.pnlLeft.Controls.Add(this.dbxChuriDate);
            this.pnlLeft.Controls.Add(this.dbxChuriUser);
            this.pnlLeft.Controls.Add(this.dbxChuriMonth);
            this.pnlLeft.Font = null;
            this.pnlLeft.Name = "pnlLeft";
            // 
            // xLabel9
            // 
            this.xLabel9.AccessibleDescription = null;
            this.xLabel9.AccessibleName = null;
            resources.ApplyResources(this.xLabel9, "xLabel9");
            this.xLabel9.Image = null;
            this.xLabel9.Name = "xLabel9";
            // 
            // dbxProcessTime
            // 
            this.dbxProcessTime.AccessibleDescription = null;
            this.dbxProcessTime.AccessibleName = null;
            resources.ApplyResources(this.dbxProcessTime, "dbxProcessTime");
            this.dbxProcessTime.Image = null;
            this.dbxProcessTime.Name = "dbxProcessTime";
            // 
            // txtRemark
            // 
            this.txtRemark.AccessibleDescription = null;
            this.txtRemark.AccessibleName = null;
            resources.ApplyResources(this.txtRemark, "txtRemark");
            this.txtRemark.ApplyByteLimit = true;
            this.txtRemark.BackgroundImage = null;
            this.txtRemark.Name = "txtRemark";
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
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // dbxStatus
            // 
            this.dbxStatus.AccessibleDescription = null;
            this.dbxStatus.AccessibleName = null;
            resources.ApplyResources(this.dbxStatus, "dbxStatus");
            this.dbxStatus.Image = null;
            this.dbxStatus.Name = "dbxStatus";
            // 
            // dbxChuriDate
            // 
            this.dbxChuriDate.AccessibleDescription = null;
            this.dbxChuriDate.AccessibleName = null;
            resources.ApplyResources(this.dbxChuriDate, "dbxChuriDate");
            this.dbxChuriDate.Image = null;
            this.dbxChuriDate.Name = "dbxChuriDate";
            // 
            // dbxChuriUser
            // 
            this.dbxChuriUser.AccessibleDescription = null;
            this.dbxChuriUser.AccessibleName = null;
            resources.ApplyResources(this.dbxChuriUser, "dbxChuriUser");
            this.dbxChuriUser.Image = null;
            this.dbxChuriUser.Name = "dbxChuriUser";
            // 
            // dbxChuriMonth
            // 
            this.dbxChuriMonth.AccessibleDescription = null;
            this.dbxChuriMonth.AccessibleName = null;
            resources.ApplyResources(this.dbxChuriMonth, "dbxChuriMonth");
            this.dbxChuriMonth.Image = null;
            this.dbxChuriMonth.Name = "dbxChuriMonth";
            // 
            // pnlButtom
            // 
            this.pnlButtom.AccessibleDescription = null;
            this.pnlButtom.AccessibleName = null;
            resources.ApplyResources(this.pnlButtom, "pnlButtom");
            this.pnlButtom.BackgroundImage = null;
            this.pnlButtom.Controls.Add(this.btnExportExcel);
            this.pnlButtom.Controls.Add(this.dwSummary);
            this.pnlButtom.Controls.Add(this.btnList);
            this.pnlButtom.Font = null;
            this.pnlButtom.Name = "pnlButtom";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AccessibleDescription = null;
            this.btnExportExcel.AccessibleName = null;
            resources.ApplyResources(this.btnExportExcel, "btnExportExcel");
            this.btnExportExcel.BackgroundImage = null;
            this.btnExportExcel.ImageIndex = 2;
            this.btnExportExcel.ImageList = this.ImageList;
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // dwSummary
            // 
            resources.ApplyResources(this.dwSummary, "dwSummary");
            this.dwSummary.DataWindowObject = "dw_summary";
            this.dwSummary.LibraryList = "INVS\\\\\\\\invs.inv6000u00.pbd";
            this.dwSummary.Name = "dwSummary";
            // 
            // pnlTop
            // 
            this.pnlTop.AccessibleDescription = null;
            this.pnlTop.AccessibleName = null;
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.BackgroundImage = null;
            this.pnlTop.Controls.Add(this.btnChange);
            this.pnlTop.Controls.Add(this.dbxDocName);
            this.pnlTop.Controls.Add(this.dbxDocCode);
            this.pnlTop.Controls.Add(this.cbxDifference);
            this.pnlTop.Controls.Add(this.xLabel8);
            this.pnlTop.Controls.Add(this.dbxInventory);
            this.pnlTop.Controls.Add(this.xLabel7);
            this.pnlTop.Controls.Add(this.fbxInventory);
            this.pnlTop.Controls.Add(this.xLabel1);
            this.pnlTop.Controls.Add(this.mtbMonth);
            this.pnlTop.Controls.Add(this.xLabel28);
            this.pnlTop.Controls.Add(this.dtpChuriDate);
            this.pnlTop.Controls.Add(this.xLabel14);
            this.pnlTop.Font = null;
            this.pnlTop.Name = "pnlTop";
            // 
            // btnChange
            // 
            this.btnChange.AccessibleDescription = null;
            this.btnChange.AccessibleName = null;
            resources.ApplyResources(this.btnChange, "btnChange");
            this.btnChange.BackgroundImage = null;
            this.btnChange.ImageIndex = 2;
            this.btnChange.ImageList = this.ImageList;
            this.btnChange.Name = "btnChange";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dbxDocName
            // 
            this.dbxDocName.AccessibleDescription = null;
            this.dbxDocName.AccessibleName = null;
            resources.ApplyResources(this.dbxDocName, "dbxDocName");
            this.dbxDocName.EdgeRounding = false;
            this.dbxDocName.Image = null;
            this.dbxDocName.Name = "dbxDocName";
            // 
            // dbxDocCode
            // 
            this.dbxDocCode.AccessibleDescription = null;
            this.dbxDocCode.AccessibleName = null;
            resources.ApplyResources(this.dbxDocCode, "dbxDocCode");
            this.dbxDocCode.EdgeRounding = false;
            this.dbxDocCode.Image = null;
            this.dbxDocCode.Name = "dbxDocCode";
            // 
            // cbxDifference
            // 
            this.cbxDifference.AccessibleDescription = null;
            this.cbxDifference.AccessibleName = null;
            resources.ApplyResources(this.cbxDifference, "cbxDifference");
            this.cbxDifference.ApplyLayoutContainerReset = false;
            this.cbxDifference.BackgroundImage = null;
            this.cbxDifference.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem4,
            this.xComboItem5,
            this.xComboItem6});
            this.cbxDifference.ExecuteQuery = null;
            this.cbxDifference.Name = "cbxDifference";
            this.cbxDifference.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cbxDifference.ParamList")));
            this.cbxDifference.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
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
            // xComboItem6
            // 
            resources.ApplyResources(this.xComboItem6, "xComboItem6");
            this.xComboItem6.ValueItem = "2";
            // 
            // xLabel8
            // 
            this.xLabel8.AccessibleDescription = null;
            this.xLabel8.AccessibleName = null;
            resources.ApplyResources(this.xLabel8, "xLabel8");
            this.xLabel8.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel8.EdgeRounding = false;
            this.xLabel8.Image = null;
            this.xLabel8.Name = "xLabel8";
            // 
            // dbxInventory
            // 
            this.dbxInventory.AccessibleDescription = null;
            this.dbxInventory.AccessibleName = null;
            resources.ApplyResources(this.dbxInventory, "dbxInventory");
            this.dbxInventory.EdgeRounding = false;
            this.dbxInventory.Image = null;
            this.dbxInventory.Name = "dbxInventory";
            // 
            // xLabel7
            // 
            this.xLabel7.AccessibleDescription = null;
            this.xLabel7.AccessibleName = null;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.Image = null;
            this.xLabel7.Name = "xLabel7";
            // 
            // fbxInventory
            // 
            this.fbxInventory.AccessibleDescription = null;
            this.fbxInventory.AccessibleName = null;
            resources.ApplyResources(this.fbxInventory, "fbxInventory");
            this.fbxInventory.BackgroundImage = null;
            this.fbxInventory.Name = "fbxInventory";
            this.fbxInventory.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxInventory_DataValidating);
            this.fbxInventory.FindClick += new System.ComponentModel.CancelEventHandler(this.fbxInventory_FindClick);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel1.EdgeRounding = false;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // mtbMonth
            // 
            this.mtbMonth.AccessibleDescription = null;
            this.mtbMonth.AccessibleName = null;
            resources.ApplyResources(this.mtbMonth, "mtbMonth");
            this.mtbMonth.ApplyLayoutContainerReset = false;
            this.mtbMonth.BackgroundImage = null;
            this.mtbMonth.IsVietnameseYearType = false;
            this.mtbMonth.MonthEditable = false;
            this.mtbMonth.Name = "mtbMonth";
            this.mtbMonth.PrevButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthbox_ButtonClick);
            this.mtbMonth.NextButtonClick += new IHIS.Framework.XMonthBoxButtonClickEventHandler(this.monthbox_ButtonClick);
            // 
            // xLabel28
            // 
            this.xLabel28.AccessibleDescription = null;
            this.xLabel28.AccessibleName = null;
            resources.ApplyResources(this.xLabel28, "xLabel28");
            this.xLabel28.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel28.EdgeRounding = false;
            this.xLabel28.Image = null;
            this.xLabel28.Name = "xLabel28";
            // 
            // dtpChuriDate
            // 
            this.dtpChuriDate.AccessibleDescription = null;
            this.dtpChuriDate.AccessibleName = null;
            resources.ApplyResources(this.dtpChuriDate, "dtpChuriDate");
            this.dtpChuriDate.ApplyLayoutContainerReset = false;
            this.dtpChuriDate.BackgroundImage = null;
            this.dtpChuriDate.IsVietnameseYearType = false;
            this.dtpChuriDate.Name = "dtpChuriDate";
            // 
            // xLabel14
            // 
            this.xLabel14.AccessibleDescription = null;
            this.xLabel14.AccessibleName = null;
            resources.ApplyResources(this.xLabel14, "xLabel14");
            this.xLabel14.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel14.EdgeRounding = false;
            this.xLabel14.Image = null;
            this.xLabel14.Name = "xLabel14";
            // 
            // layINV6000
            // 
            this.layINV6000.ExecuteQuery = null;
            this.layINV6000.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1,
            this.singleLayoutItem2,
            this.singleLayoutItem3,
            this.singleLayoutItem4,
            this.singleLayoutItem5,
            this.singleLayoutItem6});
            this.layINV6000.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layINV6000.ParamList")));
            this.layINV6000.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layINV6000_QueryStarting);
            this.layINV6000.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.layINV6000_QueryEnd);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "pkinv6000";
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.BindControl = this.dbxChuriMonth;
            this.singleLayoutItem2.DataName = "magam_month";
            // 
            // singleLayoutItem3
            // 
            this.singleLayoutItem3.BindControl = this.dbxChuriDate;
            this.singleLayoutItem3.DataName = "input_date";
            // 
            // singleLayoutItem4
            // 
            this.singleLayoutItem4.BindControl = this.dbxChuriUser;
            this.singleLayoutItem4.DataName = "input_user";
            // 
            // singleLayoutItem5
            // 
            this.singleLayoutItem5.BindControl = this.txtRemark;
            this.singleLayoutItem5.DataName = "remark";
            // 
            // singleLayoutItem6
            // 
            this.singleLayoutItem6.BindControl = this.dbxProcessTime;
            this.singleLayoutItem6.DataName = "process_time";
            // 
            // laySummary_d
            // 
            this.laySummary_d.ExecuteQuery = null;
            this.laySummary_d.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem7,
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12,
            this.multiLayoutItem13});
            this.laySummary_d.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySummary_d.ParamList")));
            this.laySummary_d.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySummary_d_QueryStarting);
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "slip_code";
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "jaeryo_code";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "jaeryo_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "subul_danga";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "danui";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "jaego_qty";
            // 
            // multiLayoutItem13
            // 
            this.multiLayoutItem13.DataName = "sougaku";
            // 
            // laySummary_m
            // 
            this.laySummary_m.ExecuteQuery = null;
            this.laySummary_m.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem14,
            this.multiLayoutItem15,
            this.multiLayoutItem16,
            this.multiLayoutItem17,
            this.multiLayoutItem18,
            this.multiLayoutItem19});
            this.laySummary_m.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("laySummary_m.ParamList")));
            this.laySummary_m.QueryStarting += new System.ComponentModel.CancelEventHandler(this.laySummary_m_QueryStarting);
            // 
            // multiLayoutItem14
            // 
            this.multiLayoutItem14.DataName = "slip_code";
            // 
            // multiLayoutItem15
            // 
            this.multiLayoutItem15.DataName = "slip_name";
            // 
            // multiLayoutItem16
            // 
            this.multiLayoutItem16.DataName = "drg_count";
            this.multiLayoutItem16.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem17
            // 
            this.multiLayoutItem17.DataName = "sougaku";
            this.multiLayoutItem17.DataType = IHIS.Framework.DataType.Number;
            // 
            // multiLayoutItem18
            // 
            this.multiLayoutItem18.DataName = "magam_date";
            // 
            // multiLayoutItem19
            // 
            this.multiLayoutItem19.DataName = "magam_month_jp";
            // 
            // INV6000U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.pnlMiddle);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlButtom);
            this.Name = "INV6000U00";
            this.Load += new System.EventHandler(this.INV4001U00_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdINV6001)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlButtom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laySummary_d)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laySummary_m)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Global


        //
        #endregion

        #region OnLoad
        private void INV4001U00_Load(object sender, EventArgs e)
        {
            this.mtbMonth.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyyMM"));
            this.dtpChuriDate.SetDataValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));

            // 実施者に 現在ログインしている IDを セットする｡
            //this.cbxActor.SetDataValue(UserInfo.UserID);

            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void PostLoad()
        {
            this.layINV6000.QueryLayout();
            this.grdINV6001.QueryLayout(false);
        }
        #endregion

        #region [検索条件]
        private void monthbox_ButtonClick(object sender, XMonthBoxButtonClickEventArgs e)
        {
            this.layINV6000.QueryLayout();
            this.grdINV6001.QueryLayout(false);
        }
        #endregion

        private bool Save_Validation_Check()
        {
            if (dbxDocCode.GetDataValue() == "")
            {
                //XMessageBox.Show("処理者を選択してください。", "確認", MessageBoxIcon.Error);
                XMessageBox.Show(Resources.MSG_001, Resources.CAP_CONFIRM, MessageBoxIcon.Error);
                //dbxDocCode.Focus();
                return false;
            }


            if (dtpChuriDate.GetDataValue() == "")
            {
                //XMessageBox.Show("処理日を選択してください。", "確認", MessageBoxIcon.Error);
                XMessageBox.Show(Resources.MSG_002, Resources.CAP_CONFIRM, MessageBoxIcon.Error);
                dtpChuriDate.Focus();
                return false;
            }
            
            //https://sofiamedix.atlassian.net/browse/MED-12551
            //if (!mtbMonth.IsVietnameseYearType)
            //{
                string currentMonth = DateTime.Now.ToString("yyyyMM");
                int currentMonthValue = 0;
                int selectedMonthValue = 0;
                bool result1 = Int32.TryParse(currentMonth, out currentMonthValue);
                bool result2 = Int32.TryParse(mtbMonth.GetDataValue(), out selectedMonthValue);
                if (result1 && result2)
                {
                    if (selectedMonthValue > currentMonthValue)
                    {
                        XMessageBox.Show(Resources.MSG_FutureError, Resources.CAP_CONFIRM, MessageBoxIcon.Error);
                        mtbMonth.Focus();
                        return false;
                    }
                }
            //}

            return true;
        }

        #region btnList_ButtonClick
        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            ArrayList InputList = new ArrayList();
            ArrayList OutputList = new ArrayList();

            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;
                    if (layINV6000.QueryLayout())
                    {
                        grdINV6001.QueryLayout(false);
                    }
                    break;
                case FunctionType.Process:
                    e.IsBaseCall = false;


                    if (!Save_Validation_Check())
                    {
                        return;
                    }

                    InputList.Add("I");
                    InputList.Add(mtbMonth.GetDataValue());
                    InputList.Add(UserInfo.UserID);
                    InputList.Add(dbxDocCode.GetDataValue());
                    InputList.Add(dtpChuriDate.GetDataValue());
                    InputList.Add(txtRemark.Text);
                    
                    //if (Service.ExecuteProcedure("PR_INV_MAKE_STOCK_COUNTS", InputList, OutputList))
                    //{
                    //    if (OutputList[0].ToString() == "Y")
                    //    {
                    //        XMessageBox.Show("締切情報が正常に生成されました。", "確認");
                    //        if (layINV6000.QueryLayout())
                    //        {
                    //            grdINV6001.QueryLayout(false);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        XMessageBox.Show(OutputList[1].ToString(), "確認", MessageBoxIcon.Error);
                    //    } 

                    //}
                    //else
                    //{
                    //    XMessageBox.Show("処理中エラーが発生しました。\n\r" + Service.ErrFullMsg, "確認", MessageBoxIcon.Error);
                    //}

                    // Updated by Cloud
                    string output = "";
                    string msg = "";
                    bool ret = this.ExecuteProcedure(InputList, out output);

                    if (ret)
                    {
                        switch (output)
                        {
                            case "Y":
                                //XMessageBox.Show("締切情報が正常に生成されました。", "確認");
                                XMessageBox.Show(Resources.MSG_003, Resources.CAP_CONFIRM);
                                if (layINV6000.QueryLayout())
                                {
                                    grdINV6001.QueryLayout(false);
                                }
                                break;
                            case "S":
                                msg = string.Format(Resources.MSG_006, mtbMonth.GetDataValue());
                                XMessageBox.Show(msg, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case "B":
                                msg = string.Format(Resources.MSG_007, mtbMonth.GetDataValue());
                                XMessageBox.Show(msg, Resources.CAP_CONFIRM, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //XMessageBox.Show("処理中エラーが発生しました。\n\r" + Service.ErrFullMsg, "確認", MessageBoxIcon.Error);
                        XMessageBox.Show(Resources.MSG_004, Resources.CAP_CONFIRM, MessageBoxIcon.Error);
                    }

                    break;


                case FunctionType.Reset:
                    InputList.Add("D");
                    InputList.Add(mtbMonth.GetDataValue());
                    InputList.Add(UserInfo.UserID);
                    InputList.Add(dbxDocCode.GetDataValue());
                    InputList.Add(dtpChuriDate.GetDataValue());
                    InputList.Add(txtRemark.Text);

                    //if (Service.ExecuteProcedure("PR_INV_MAKE_STOCK_COUNTS", InputList, OutputList))
                    //{
                    //    XMessageBox.Show("締切情報が正常に削除されました。", "確認");
                    //    layINV6000.QueryLayout();
                    //    grdINV6001.QueryLayout(false);       
                    //}

                    output = "";
                    ret = this.ExecuteProcedure(InputList, out output);

                    if (ret)
                    {
                        //XMessageBox.Show("締切情報が正常に削除されました。", "確認");
                        XMessageBox.Show(Resources.MSG_005, Resources.CAP_CONFIRM);
                        layINV6000.QueryLayout();
                        grdINV6001.QueryLayout(false);
                    }
                    break; 
                case FunctionType.Print:
                    Summary_Print();
                    break;
                default:
                    break;
            }
        }

        private bool ExecuteProcedure(ArrayList inputList, out string output)
        {
            output = "";

            INV6000U00SaveLayoutArgs args = new INV6000U00SaveLayoutArgs();
            args.Proc = inputList[0].ToString();
            args.Month = inputList[1].ToString();
            args.UserId = inputList[2].ToString();
            args.InputUser = inputList[3].ToString();
            args.InputDate = inputList[4].ToString();
            args.Remark = inputList[5].ToString();
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, INV6000U00SaveLayoutArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
            {
                output = res.Msg;
                return true;
            }

            return false;
        }

        #endregion

        #region layINV6000 EVENT
        private void layINV6000_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.layINV6000.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layINV6000.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            this.layINV6000.SetBindVarValue("f_month", this.mtbMonth.GetDataValue());
        }

        private void layINV6000_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdINV6001.QueryLayout(false);
        }
        #endregion

        #region grdINV6001 EVENT
        private void grdINV6001_QueryStarting(object sender, CancelEventArgs e)
        {
            //this.grdINV6001.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdINV6001.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            this.grdINV6001.SetBindVarValue("f_fkinv6000", layINV6000.GetItemValue("pkinv6000").ToString());
            this.grdINV6001.SetBindVarValue("f_jaeryo_code", fbxInventory.GetDataValue());
            this.grdINV6001.SetBindVarValue("f_difference", cbxDifference.GetDataValue());
        }
        #endregion

        private void layINV6000_QueryEnd(object sender, QueryEndEventArgs e)
        {
            if (TypeCheck.IsNull(layINV6000.GetItemValue("pkinv6000")))
            {
                //dbxStatus.Text = "締切　前";
                dbxStatus.Text = Resources.TXT_001;
            }
            else
            {
                //dbxStatus.Text = "締切　済";
                dbxStatus.Text = Resources.TXT_002;
            }
        }

        private void layINV6001_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (e.ColName == "delta_qty")
            {
                try
                {
                    if (int.Parse(e.DataRow["delta_qty"].ToString()) < 0)
                    {
                        e.ForeColor = Color.Red;
                        //e.BackColor = Color.Pink;
                    }
                    else if(int.Parse(e.DataRow["delta_qty"].ToString()) > 0)
                    {
                        e.ForeColor = Color.Blue;
                    }
                }
                catch
                {
                }
            }
        }

        private void laySummary_d_QueryStarting(object sender, CancelEventArgs e)
        {
            //laySummary_d.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            laySummary_d.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            laySummary_d.SetBindVarValue("f_magam_month", mtbMonth.GetDataValue());
        }

        private void Summary_Print()
        {
            dwSummary.Reset();

            //if (laySummary_d.QueryLayout(true) && laySummary_m.QueryLayout(true))
            //{
            //    dwSummary.FillChildData("dw_p01", laySummary_d.LayoutTable.Select("slip_code='P01'"));
            //    dwSummary.FillChildData("dw_p02", laySummary_d.LayoutTable.Select("slip_code='P02'"));
            //    dwSummary.FillChildData("dw_j01", laySummary_d.LayoutTable.Select("slip_code='J01'"));

            //    dwSummary.FillChildData("dw_total", laySummary_m.LayoutTable);

            //    dwSummary.Print();
            //}

            if (laySummary_d.QueryLayout(true) && laySummary_m.QueryLayout(true))
            {
                DataRow[] dataRowArray1 = laySummary_d.LayoutTable.Select("slip_code='P01'");
                DataTable table1 = new DataTable();
                foreach (DataRow row in dataRowArray1)
                {
                    table1.ImportRow(row);
                }
                DataRow[] dataRowArray2 = laySummary_d.LayoutTable.Select("slip_code='P02'");
                DataTable table2 = new DataTable();
                foreach (DataRow row in dataRowArray2)
                {
                    table2.ImportRow(row);
                }

                DataRow[] dataRowArray3 = laySummary_d.LayoutTable.Select("slip_code='J01'");
                DataTable table3 = new DataTable();
                foreach (DataRow row in dataRowArray3)
                {
                    table3.ImportRow(row);
                }
                dwSummary.FillChildData("dw_p01", table1);
                dwSummary.FillChildData("dw_p02", table2);
                dwSummary.FillChildData("dw_j01", table3);

                dwSummary.FillChildData("dw_total", laySummary_m.LayoutTable);
                dwSummary.Print();
            }
        }

        private void laySummary_m_QueryStarting(object sender, CancelEventArgs e)
        {
            //laySummary_m.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            laySummary_m.SetBindVarValue("f_hosp_code", UserInfo.HospCode);
            laySummary_m.SetBindVarValue("f_magam_month", mtbMonth.GetDataValue());
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-11446
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog svd = new SaveFileDialog())
            {
                DateTime currDate=EnvironInfo.GetSysDate();
                svd.Filter = "csv files (*.csv)|*.csv";
                //https://sofiamedix.atlassian.net/browse/MED-12485
                //svd.FileName = UserInfo.HospCode + "_INV_" + mtbMonth.GetDataValue() + "_" + currDate.ToString("yyyy/MM/dd_hh:mm");
                // https://sofiamedix.atlassian.net/browse/MED-12539
                svd.FileName = UserInfo.HospCode + "_INV_" + mtbMonth.GetDataValue() + "_" + currDate.ToString("yyyyMMdd_hhmm");
                if (svd.ShowDialog() == DialogResult.OK)
                {
                    //this.grdPrint.ParamList = new List<string>(new string[] { "f_month" });
                    //this.grdPrint.ExecuteQuery = GetGrdPrint;
                    //this.grdPrint.SetBindVarValue("f_month", this.mtbMonth.GetDataValue());
                    //this.grdPrint.QueryLayout(true);

                    //MED-12596
                    grdINV6001.QueryLayout(true);

                    // Get file name.
                    string fileName = svd.FileName;
                    //if (INVHelpers.ExportCSV(grdPrint, fileName))
                    ////MED-12596
                    if (INVHelpers.ExportCSV(grdINV6001, fileName))
                    {
                        // Export succeeded.
                    }
                }
            }
        }

        private void fbxInventory_FindClick(object sender, CancelEventArgs e)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            XScreen.OpenScreenWithParam(this, "INVS", "INV0110Q00", ScreenOpenStyle.ResponseFixed, openParams);
        }

        private void fbxInventory_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (TypeCheck.IsNull(e.DataValue))
            {
                this.dbxInventory.SetDataValue("");
                this.fbxInventory.Focus();
                return;
            }

            OCS0103U00LayCommonJaeryoCodeArgs args = new OCS0103U00LayCommonJaeryoCodeArgs();
            args.JaeryoCode = e.DataValue;
            args.HospCode = UserInfo.HospCode;
            ComboResult res = CloudService.Instance.Submit<ComboResult, OCS0103U00LayCommonJaeryoCodeArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success && res.ComboItem.Count > 0)
            {
                dbxInventory.SetDataValue(res.ComboItem[0].Code);
            }
            else
            {
                dbxInventory.SetDataValue("");
                this.fbxInventory.Focus();
            }
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command)
            {
                case "INV0110Q00":            // 항목검색

                    if (commandParam != null)
                    {
                        if (commandParam.Contains("INV0110") && ((MultiLayout)commandParam["INV0110"]).RowCount > 0)
                        {
                            string jaeryoCode = ((MultiLayout)commandParam["INV0110"]).LayoutTable.Rows[0]["jaeryo_code"].ToString();
                            string jaeryoName = ((MultiLayout)commandParam["INV0110"]).LayoutTable.Rows[0]["jaeryo_name"].ToString();
                            fbxInventory.SetDataValue(jaeryoCode);
                            dbxInventory.SetDataValue(jaeryoName);
                        }
                    }

                    break;
                case "ADM104Q":
                    if (commandParam.Contains("user_id") && !String.IsNullOrEmpty(commandParam["user_id"].ToString()))
                    {
                        dbxDocCode.SetDataValue(commandParam["user_id"]);
                    }
                    if (commandParam.Contains("user_name") && !String.IsNullOrEmpty(commandParam["user_name"].ToString()))
                    {
                        dbxDocName.SetDataValue(commandParam["user_name"]);
                    }
                    break;

            }
            return base.Command(command, commandParam);
        }

        #region Cloud

        private void InitCloud()
        {
            //this.cbxActor.ExecuteQuery = GetCbxActor;
            //this.cbxActor.SetDictDDLB();
            //this.cbxActor.SelectedIndex = 0;
            dbxDocCode.Text = UserInfo.UserID;
            dbxDocName.Text = UserInfo.UserName;
            this.cbxDifference.ExecuteQuery = GetCbxDifference;
            this.cbxDifference.SetDictDDLB();

            this.grdINV6001.ParamList = new List<string>(new string[] { "f_hosp_code", "f_fkinv6000", "f_jaeryo_code", "f_page_number", "f_difference"});
            this.grdINV6001.ExecuteQuery = GetGrdINV6001;

            this.layINV6000.ParamList = new List<string>(new string[] { "f_hosp_code", "f_month", });
            this.layINV6000.ExecuteQuery = GetLayINV6000;

            this.laySummary_d.ParamList = new List<string>(new string[] { "f_hosp_code", "f_magam_month", });
            this.laySummary_d.ExecuteQuery = GetLaySummaryDetail;

            this.laySummary_m.ParamList = new List<string>(new string[] { "f_hosp_code", "f_magam_month", });
            this.laySummary_m.ExecuteQuery = GetLaySummaryMaster;
        }

        private List<object[]> GetGrdPrint(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6000U00ExportCSVArgs args = new INV6000U00ExportCSVArgs();
            args.Month = bc["f_month"].VarValue;
            INV6000U00ExportCSVResult res = CloudService.Instance.Submit<INV6000U00ExportCSVResult, INV6000U00ExportCSVArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.CsvItem.ForEach(delegate(INV6000U00ExportCSVInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.RowNum,
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.IpgoDanuiName,
                        item.Danga,
                        item.PreMJaegoQty,
                        item.IpgoQty,
                        item.ChulgoQty,
                        item.JaegoQty,
                        item.AdjAmt,
                        item.DangaJaegoQty,
                    });
                });
            }

            return lObj;
        }

        private List<object[]> GetCbxActor(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV4001U00DrugUserResult res = CloudService.Instance.Submit<INV4001U00DrugUserResult, INV4001U00DrugUserArgs>(new INV4001U00DrugUserArgs());
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

        private IList<object[]> GetCbxDifference(BindVarCollection varlist)
        {
            List<object[]> lObj = new List<object[]>();

            lObj.Add(new object[] { "%", Resources.Msg_All });
            lObj.Add(new object[] { "1", "> 0" });
            lObj.Add(new object[] { "0", "= 0" });
            lObj.Add(new object[] { "-1", "< 0" });

            return lObj;
        }

        private List<object[]> GetGrdINV6001(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6000U00GrdINV6001Args args = new INV6000U00GrdINV6001Args();
            args.Fkinv6000 = bc["f_fkinv6000"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.JaeryoCode = bc["f_jaeryo_code"].VarValue;
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
            args.Difference = bc["f_difference"].VarValue;
            INV6000U00GrdINV6001Result res = CloudService.Instance.Submit<INV6000U00GrdINV6001Result, INV6000U00GrdINV6001Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdInv6001.ForEach(delegate(INV6000U00GrdINV6001Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.PreMJaegoQty,
                        item.IpgoQty,
                        item.ChulgoQty,
                        item.JaegoQty,
                        item.ExistCnt,
                        item.DeltaQty,
                        item.SubulDanuiName,
                        item.Danga,
                        item.AdjAmt,
                    });
                });
            }

            return lObj;
        }

        private List<object[]> GetLayINV6000(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6000U00LayINV6000Args args = new INV6000U00LayINV6000Args();
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.Month = bc["f_month"].VarValue;
            INV6000U00LayINV6000Result res = CloudService.Instance.Submit<INV6000U00LayINV6000Result, INV6000U00LayINV6000Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LayInv6000.ForEach(delegate(INV6000U00LayINV6000Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Pkinv6001,
                        this.FormatDateByLanguage(item.MagamMonth),
                        GetDateString(item.InputDate),
                        item.UserName,
                        item.Remark,
                        (item.ProcessTime.Length == 4) ? item.ProcessTime.Insert(2, ":") : "" 
                    });
                });
            }

            return lObj;
        }

        private string GetDateString(string inputDate)
        {
            if (NetInfo.Language != LangMode.Vi) return inputDate;
            string words = inputDate;
            string[] split = words.Split(new Char[] { ' ', '/', ':' });
            if (split.Length < 3) return inputDate;

            string result = string.Format("{0}/{1}/{2}", split[2], split[1], split[0]);
            return result;
        }

        private List<object[]> GetLaySummaryDetail(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6000U00LaySummaryDetailArgs args = new INV6000U00LaySummaryDetailArgs();
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.MagamMonth = bc["f_magam_month"].VarValue;
            INV6000U00LaySummaryDetailResult res = CloudService.Instance.Submit<INV6000U00LaySummaryDetailResult, INV6000U00LaySummaryDetailArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LaySummaryD.ForEach(delegate(INV6000U00LaySummaryDetailInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.JaeryoCode,
                        item.JaeryoName,
                        item.SubulDanga,
                        item.Danui,
                        item.JaegoQty,
                        item.Sougaku,
                    });
                });
            }

            return lObj;
        }

        private List<object[]> GetLaySummaryMaster(BindVarCollection bc)
        {
            List<object[]> lObj = new List<object[]>();

            INV6000U00LaySummaryMasterArgs args = new INV6000U00LaySummaryMasterArgs();
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.MagamMonth = bc["f_magam_month"].VarValue;
            INV6000U00LaySummaryMasterResult res = CloudService.Instance.Submit<INV6000U00LaySummaryMasterResult, INV6000U00LaySummaryMasterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.LaySummaryM.ForEach(delegate(INV6000U00LaySummaryMasterInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.DrgCount,
                        item.Sougaku,
                        item.MagamDate,
                        item.MagamMonthJp,
                    });
                });
            }

            return lObj;
        }

        /// <summary>
        /// https://sofiamedix.atlassian.net/browse/MED-11675
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        private string FormatDateByLanguage(string dateStr)
        {
            if (TypeCheck.IsNull(dateStr))
            {
                return dateStr;
            }

            switch (NetInfo.Language)
            {
                case LangMode.En:
                case LangMode.Vi:
                    dateStr = dateStr.Replace("年", ".").Replace("月", "");
                    string[] dateArr = dateStr.Split('.');
                    dateStr = dateArr[1] + "/" + dateArr[0];
                    break;
                default:
                    break;
            }

            return dateStr;
        }

        #endregion

        private void btnChange_Click(object sender, EventArgs e)
        {
            CommonItemCollection param = new CommonItemCollection();
            param.Add("user_id", dbxDocCode.GetDataValue());
            param.Add("user_name", dbxDocName.GetDataValue());
            XScreen.OpenScreenWithParam(this, "ADMA", "ADM104Q", ScreenOpenStyle.PopupSingleFixed, param);
        }
    }
}

