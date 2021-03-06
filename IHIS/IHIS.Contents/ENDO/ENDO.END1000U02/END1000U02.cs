using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Arguments.Endo;
using IHIS.CloudConnector.Contracts.Models.Endo;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.PFES.Properties;
using IHIS.CloudConnector.Contracts.Results.Endo;

namespace IHIS.PFES
{
    public partial class END1000U02 : IHIS.Framework.XScreen
    {
        #region Auto-gen code

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(END1000U02));
            this.paBox = new IHIS.Framework.XPatientBox();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dbxGumsaName = new IHIS.Framework.XDisplayBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.dbxAge = new IHIS.Framework.XDisplayBox();
            this.dbxSex = new IHIS.Framework.XDisplayBox();
            this.dbxSuname = new IHIS.Framework.XDisplayBox();
            this.dbxBunho = new IHIS.Framework.XDisplayBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.grdPaStatus = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.bntlImsangResult = new IHIS.Framework.XButton();
            this.lklImsangResult = new System.Windows.Forms.LinkLabel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel6 = new IHIS.Framework.XPanel();
            this.grdPurpose = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xPanel7 = new IHIS.Framework.XPanel();
            this.xPanel8 = new IHIS.Framework.XPanel();
            this.grdComment2 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell12 = new IHIS.Framework.XEditGridCell();
            this.xLabel6 = new IHIS.Framework.XLabel();
            this.xPanel9 = new IHIS.Framework.XPanel();
            this.grdComment3 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell13 = new IHIS.Framework.XEditGridCell();
            this.tabControl = new IHIS.Framework.XTabControl();
            this.xPanel10 = new IHIS.Framework.XPanel();
            this.grdComment1 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell11 = new IHIS.Framework.XEditGridCell();
            this.xLabel7 = new IHIS.Framework.XLabel();
            this.lbXrayName = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.pnlPatStatus = new IHIS.Framework.XPanel();
            this.xLabel5 = new IHIS.Framework.XLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.cbxResidentYn = new IHIS.Framework.XCheckBox();
            this.xLabel4 = new IHIS.Framework.XLabel();
            this.txtPurposeOfLab = new IHIS.Framework.XRichTextBox();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.dsvDw = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem1 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem2 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem3 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem4 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem5 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem6 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem7 = new IHIS.Framework.MultiLayoutItem();
            this.dsvGumsaName = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.dsvLDOCS0801 = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem8 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem9 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem10 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem11 = new IHIS.Framework.MultiLayoutItem();
            this.multiLayoutItem12 = new IHIS.Framework.MultiLayoutItem();
            this.layOrderDate = new IHIS.Framework.MultiLayout();
            this.multiLayoutItem21 = new IHIS.Framework.MultiLayoutItem();
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPurpose)).BeginInit();
            this.xPanel7.SuspendLayout();
            this.xPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment2)).BeginInit();
            this.xPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment3)).BeginInit();
            this.xPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdComment1)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsvDw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvLDOCS0801)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderDate)).BeginInit();
            this.SuspendLayout();
            // 
            // paBox
            // 
            resources.ApplyResources(this.paBox, "paBox");
            this.paBox.Name = "paBox";
            // 
            // xPanel2
            // 
            this.xPanel2.Controls.Add(this.dbxGumsaName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.dbxAge);
            this.xPanel2.Controls.Add(this.dbxSex);
            this.xPanel2.Controls.Add(this.dbxSuname);
            this.xPanel2.Controls.Add(this.dbxBunho);
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // dbxGumsaName
            // 
            resources.ApplyResources(this.dbxGumsaName, "dbxGumsaName");
            this.dbxGumsaName.Name = "dbxGumsaName";
            // 
            // xLabel2
            // 
            this.xLabel2.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel2.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel2.GradientEndColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // dbxAge
            // 
            resources.ApplyResources(this.dbxAge, "dbxAge");
            this.dbxAge.Name = "dbxAge";
            // 
            // dbxSex
            // 
            resources.ApplyResources(this.dbxSex, "dbxSex");
            this.dbxSex.Name = "dbxSex";
            // 
            // dbxSuname
            // 
            resources.ApplyResources(this.dbxSuname, "dbxSuname");
            this.dbxSuname.Name = "dbxSuname";
            // 
            // dbxBunho
            // 
            resources.ApplyResources(this.dbxBunho, "dbxBunho");
            this.dbxBunho.Name = "dbxBunho";
            // 
            // xLabel1
            // 
            this.xLabel1.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel1.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            this.xLabel1.GradientEndColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.grdPaStatus);
            this.xPanel3.Controls.Add(this.bntlImsangResult);
            this.xPanel3.Controls.Add(this.lklImsangResult);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // grdPaStatus
            // 
            this.grdPaStatus.ApplyPaintEventToAllColumn = true;
            this.grdPaStatus.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell7,
            this.xEditGridCell8,
            this.xEditGridCell9,
            this.xEditGridCell10});
            this.grdPaStatus.ColPerLine = 4;
            this.grdPaStatus.Cols = 4;
            this.grdPaStatus.ExecuteQuery = null;
            this.grdPaStatus.FixedRows = 1;
            this.grdPaStatus.HeaderHeights.Add(12);
            resources.ApplyResources(this.grdPaStatus, "grdPaStatus");
            this.grdPaStatus.Name = "grdPaStatus";
            this.grdPaStatus.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPaStatus.ParamList")));
            this.grdPaStatus.QuerySQL = resources.GetString("grdPaStatus.QuerySQL");
            this.grdPaStatus.Rows = 2;
            this.grdPaStatus.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.grdPaStatus_QueryEnd);
            this.grdPaStatus.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPaStatus_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "bunho";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "pat_status";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellName = "pat_status_name";
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsReadOnly = true;
            this.xEditGridCell5.IsUpdCol = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellName = "pat_status_code";
            this.xEditGridCell6.Col = 1;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "pat_status_code_name";
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.IsReadOnly = true;
            this.xEditGridCell7.IsUpdCol = false;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "ment";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "seq";
            this.xEditGridCell9.Col = -1;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.IsVisible = false;
            this.xEditGridCell9.Row = -1;
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellName = "indispensable";
            this.xEditGridCell10.Col = 3;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.IsUpdCol = false;
            // 
            // bntlImsangResult
            // 
            resources.ApplyResources(this.bntlImsangResult, "bntlImsangResult");
            this.bntlImsangResult.Name = "bntlImsangResult";
            this.bntlImsangResult.Click += new System.EventHandler(this.bntlImsangResult_Click);
            // 
            // lklImsangResult
            // 
            this.lklImsangResult.BackColor = System.Drawing.Color.Transparent;
            this.lklImsangResult.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lklImsangResult, "lklImsangResult");
            this.lklImsangResult.Name = "lklImsangResult";
            this.lklImsangResult.TabStop = true;
            this.lklImsangResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklImsangResult_LinkClicked);
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.FunctionItems.AddRange(new IHIS.Framework.CustomFunctionItem[] {
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Query, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Update, System.Windows.Forms.Shortcut.None, "", -1, ""),
            new IHIS.Framework.CustomFunctionItem(IHIS.Framework.FunctionType.Close, System.Windows.Forms.Shortcut.None, "", -1, "")});
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Custom;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel6);
            this.xPanel1.Controls.Add(this.splitter2);
            this.xPanel1.Controls.Add(this.xPanel4);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel6
            // 
            this.xPanel6.Controls.Add(this.grdPurpose);
            this.xPanel6.Controls.Add(this.xPanel7);
            resources.ApplyResources(this.xPanel6, "xPanel6");
            this.xPanel6.Name = "xPanel6";
            // 
            // grdPurpose
            // 
            this.grdPurpose.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdPurpose.ColPerLine = 2;
            this.grdPurpose.Cols = 2;
            resources.ApplyResources(this.grdPurpose, "grdPurpose");
            this.grdPurpose.ExecuteQuery = null;
            this.grdPurpose.FixedRows = 1;
            this.grdPurpose.HeaderHeights.Add(21);
            this.grdPurpose.Name = "grdPurpose";
            this.grdPurpose.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdPurpose.ParamList")));
            this.grdPurpose.QuerySQL = resources.GetString("grdPurpose.QuerySQL");
            this.grdPurpose.Rows = 2;
            this.grdPurpose.RowStateCheckOnPaint = false;
            this.grdPurpose.ItemValueChanging += new IHIS.Framework.ItemValueChangingEventHandler(this.grdPurpose_ItemValueChanging);
            this.grdPurpose.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdPurpose_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "check";
            this.xEditGridCell1.CellWidth = 49;
            this.xEditGridCell1.EditorStyle = IHIS.Framework.XCellEditorStyle.CheckBox;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdCol = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellName = "purpose";
            this.xEditGridCell2.CellWidth = 240;
            this.xEditGridCell2.Col = 1;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // xPanel7
            // 
            this.xPanel7.Controls.Add(this.xPanel8);
            this.xPanel7.Controls.Add(this.xPanel9);
            this.xPanel7.Controls.Add(this.xPanel10);
            this.xPanel7.Controls.Add(this.lbXrayName);
            resources.ApplyResources(this.xPanel7, "xPanel7");
            this.xPanel7.DrawBorder = true;
            this.xPanel7.Name = "xPanel7";
            // 
            // xPanel8
            // 
            this.xPanel8.Controls.Add(this.grdComment2);
            this.xPanel8.Controls.Add(this.xLabel6);
            resources.ApplyResources(this.xPanel8, "xPanel8");
            this.xPanel8.Name = "xPanel8";
            // 
            // grdComment2
            // 
            this.grdComment2.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell12});
            this.grdComment2.ColHeaderVisible = false;
            this.grdComment2.ColPerLine = 1;
            this.grdComment2.Cols = 1;
            resources.ApplyResources(this.grdComment2, "grdComment2");
            this.grdComment2.ExecuteQuery = null;
            this.grdComment2.FixedRows = 1;
            this.grdComment2.HeaderHeights.Add(0);
            this.grdComment2.Name = "grdComment2";
            this.grdComment2.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment2.ParamList")));
            this.grdComment2.QuerySQL = "SELECT COMMENTS\r\n  FROM OUT0106\r\n WHERE HOSP_CODE  = :f_hosp_code \r\n   AND BUNHO " +
                "     = :f_bunho\r\n   AND CMMT_GUBUN = \'P\'\r\n   AND JUNDAL_TABLE = \'PFE\'\r\n ORDER BY" +
                " SER";
            this.grdComment2.ReadOnly = true;
            this.grdComment2.Rows = 2;
            this.grdComment2.ToolTipActive = true;
            this.grdComment2.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment2_QueryStarting);
            // 
            // xEditGridCell12
            // 
            this.xEditGridCell12.CellName = "comment";
            this.xEditGridCell12.CellWidth = 250;
            this.xEditGridCell12.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell12, "xEditGridCell12");
            // 
            // xLabel6
            // 
            this.xLabel6.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            resources.ApplyResources(this.xLabel6, "xLabel6");
            this.xLabel6.EdgeRounding = false;
            this.xLabel6.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel6.Name = "xLabel6";
            // 
            // xPanel9
            // 
            this.xPanel9.Controls.Add(this.grdComment3);
            this.xPanel9.Controls.Add(this.tabControl);
            resources.ApplyResources(this.xPanel9, "xPanel9");
            this.xPanel9.Name = "xPanel9";
            // 
            // grdComment3
            // 
            this.grdComment3.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell13});
            this.grdComment3.ColHeaderVisible = false;
            this.grdComment3.ColPerLine = 1;
            this.grdComment3.Cols = 1;
            resources.ApplyResources(this.grdComment3, "grdComment3");
            this.grdComment3.ExecuteQuery = null;
            this.grdComment3.FixedRows = 1;
            this.grdComment3.HeaderHeights.Add(0);
            this.grdComment3.Name = "grdComment3";
            this.grdComment3.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment3.ParamList")));
            this.grdComment3.QuerySQL = resources.GetString("grdComment3.QuerySQL");
            this.grdComment3.ReadOnly = true;
            this.grdComment3.Rows = 2;
            this.grdComment3.ToolTipActive = true;
            this.grdComment3.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment3_QueryStarting);
            // 
            // xEditGridCell13
            // 
            this.xEditGridCell13.CellName = "comment";
            this.xEditGridCell13.CellWidth = 250;
            this.xEditGridCell13.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell13, "xEditGridCell13");
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.IDEPixelArea = true;
            this.tabControl.IDEPixelBorder = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
            // 
            // xPanel10
            // 
            this.xPanel10.Controls.Add(this.grdComment1);
            this.xPanel10.Controls.Add(this.xLabel7);
            resources.ApplyResources(this.xPanel10, "xPanel10");
            this.xPanel10.Name = "xPanel10";
            // 
            // grdComment1
            // 
            this.grdComment1.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell11});
            this.grdComment1.ColHeaderVisible = false;
            this.grdComment1.ColPerLine = 1;
            this.grdComment1.Cols = 1;
            resources.ApplyResources(this.grdComment1, "grdComment1");
            this.grdComment1.ExecuteQuery = null;
            this.grdComment1.FixedRows = 1;
            this.grdComment1.HeaderHeights.Add(0);
            this.grdComment1.Name = "grdComment1";
            this.grdComment1.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdComment1.ParamList")));
            this.grdComment1.QuerySQL = "SELECT COMMENTS \r\n  FROM OUT0106\r\n WHERE HOSP_CODE  = :f_hosp_code \r\n   AND BUNHO" +
                "      = :f_bunho\r\n   AND CMMT_GUBUN = \'B\'\r\n ORDER BY SER";
            this.grdComment1.ReadOnly = true;
            this.grdComment1.Rows = 2;
            this.grdComment1.ToolTipActive = true;
            this.grdComment1.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdComment1_QueryStarting);
            // 
            // xEditGridCell11
            // 
            this.xEditGridCell11.CellName = "comment";
            this.xEditGridCell11.CellWidth = 250;
            this.xEditGridCell11.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell11, "xEditGridCell11");
            // 
            // xLabel7
            // 
            this.xLabel7.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            resources.ApplyResources(this.xLabel7, "xLabel7");
            this.xLabel7.EdgeRounding = false;
            this.xLabel7.ForeColor = IHIS.Framework.XColor.ActiveBorderColor;
            this.xLabel7.Name = "xLabel7";
            // 
            // lbXrayName
            // 
            resources.ApplyResources(this.lbXrayName, "lbXrayName");
            this.lbXrayName.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.lbXrayName.Name = "lbXrayName";
            // 
            // splitter2
            // 
            resources.ApplyResources(this.splitter2, "splitter2");
            this.splitter2.Name = "splitter2";
            this.splitter2.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.pnlPatStatus);
            this.xPanel4.Controls.Add(this.xLabel5);
            this.xPanel4.Controls.Add(this.splitter1);
            this.xPanel4.Controls.Add(this.xPanel5);
            this.xPanel4.Controls.Add(this.txtPurposeOfLab);
            this.xPanel4.Controls.Add(this.xLabel3);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.Name = "xPanel4";
            // 
            // pnlPatStatus
            // 
            resources.ApplyResources(this.pnlPatStatus, "pnlPatStatus");
            this.pnlPatStatus.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.GhostWhite);
            this.pnlPatStatus.Name = "pnlPatStatus";
            // 
            // xLabel5
            // 
            resources.ApplyResources(this.xLabel5, "xLabel5");
            this.xLabel5.Name = "xLabel5";
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.cbxResidentYn);
            this.xPanel5.Controls.Add(this.xLabel4);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.Name = "xPanel5";
            // 
            // cbxResidentYn
            // 
            this.cbxResidentYn.BackColor = new IHIS.Framework.XColor(System.Drawing.Color.AliceBlue);
            resources.ApplyResources(this.cbxResidentYn, "cbxResidentYn");
            this.cbxResidentYn.Name = "cbxResidentYn";
            this.cbxResidentYn.UseVisualStyleBackColor = false;
            // 
            // xLabel4
            // 
            this.xLabel4.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel4.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            resources.ApplyResources(this.xLabel4, "xLabel4");
            this.xLabel4.GradientEndColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel4.Name = "xLabel4";
            // 
            // txtPurposeOfLab
            // 
            resources.ApplyResources(this.txtPurposeOfLab, "txtPurposeOfLab");
            this.txtPurposeOfLab.EnterKeyToTab = false;
            this.txtPurposeOfLab.Name = "txtPurposeOfLab";
            // 
            // xLabel3
            // 
            this.xLabel3.BackColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.DiagonalGRAD;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.GradientEndColor = IHIS.Framework.XColor.XMatrixColHeaderBackColor;
            this.xLabel3.Name = "xLabel3";
            // 
            // dsvDw
            // 
            this.dsvDw.ExecuteQuery = null;
            this.dsvDw.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem1,
            this.multiLayoutItem2,
            this.multiLayoutItem3,
            this.multiLayoutItem4,
            this.multiLayoutItem5,
            this.multiLayoutItem6,
            this.multiLayoutItem7});
            this.dsvDw.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvDw.ParamList")));
            this.dsvDw.QuerySQL = resources.GetString("dsvDw.QuerySQL");
            this.dsvDw.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvDw_QueryStarting);
            this.dsvDw.QueryEnd += new IHIS.Framework.QueryEndEventHandler(this.dsvDw_QueryEnd);
            // 
            // multiLayoutItem1
            // 
            this.multiLayoutItem1.DataName = "pkpfe1000";
            this.multiLayoutItem1.IsNotNull = true;
            // 
            // multiLayoutItem2
            // 
            this.multiLayoutItem2.DataName = "c3";
            this.multiLayoutItem2.IsNotNull = true;
            // 
            // multiLayoutItem3
            // 
            this.multiLayoutItem3.DataName = "fkocs";
            this.multiLayoutItem3.IsNotNull = true;
            // 
            // multiLayoutItem4
            // 
            this.multiLayoutItem4.DataName = "bunho";
            this.multiLayoutItem4.IsNotNull = true;
            // 
            // multiLayoutItem5
            // 
            this.multiLayoutItem5.DataName = "hangmog_code";
            this.multiLayoutItem5.IsNotNull = true;
            // 
            // multiLayoutItem6
            // 
            this.multiLayoutItem6.DataName = "hangmog_name";
            // 
            // multiLayoutItem7
            // 
            this.multiLayoutItem7.DataName = "resident_yn";
            this.multiLayoutItem7.IsNotNull = true;
            // 
            // dsvGumsaName
            // 
            this.dsvGumsaName.ExecuteQuery = null;
            this.dsvGumsaName.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.dsvGumsaName.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvGumsaName.ParamList")));
            this.dsvGumsaName.QuerySQL = "SELECT HANGMOG_NAME\r\n  FROM OCS0103\r\n WHERE HANGMOG_CODE = :f_code\r\n   AND HOSP_C" +
                "ODE    = :f_hosp_code";
            this.dsvGumsaName.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvGumsaName_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxGumsaName;
            this.singleLayoutItem1.DataName = "dbxGumsaName";
            // 
            // dsvLDOCS0801
            // 
            this.dsvLDOCS0801.ExecuteQuery = null;
            this.dsvLDOCS0801.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem8,
            this.multiLayoutItem9,
            this.multiLayoutItem10,
            this.multiLayoutItem11,
            this.multiLayoutItem12});
            this.dsvLDOCS0801.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("dsvLDOCS0801.ParamList")));
            this.dsvLDOCS0801.QuerySQL = resources.GetString("dsvLDOCS0801.QuerySQL");
            this.dsvLDOCS0801.QueryStarting += new System.ComponentModel.CancelEventHandler(this.dsvLDOCS0801_QueryStarting);
            // 
            // multiLayoutItem8
            // 
            this.multiLayoutItem8.DataName = "pat_status";
            // 
            // multiLayoutItem9
            // 
            this.multiLayoutItem9.DataName = "pat_status_name";
            // 
            // multiLayoutItem10
            // 
            this.multiLayoutItem10.DataName = "pat_status_code";
            // 
            // multiLayoutItem11
            // 
            this.multiLayoutItem11.DataName = "pat_status_code_name";
            // 
            // multiLayoutItem12
            // 
            this.multiLayoutItem12.DataName = "indispensable_yn";
            // 
            // layOrderDate
            // 
            this.layOrderDate.ExecuteQuery = null;
            this.layOrderDate.LayoutItems.AddRange(new IHIS.Framework.MultiLayoutItem[] {
            this.multiLayoutItem21});
            this.layOrderDate.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layOrderDate.ParamList")));
            this.layOrderDate.QuerySQL = resources.GetString("layOrderDate.QuerySQL");
            this.layOrderDate.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layOrderDate_QueryStarting);
            // 
            // multiLayoutItem21
            // 
            this.multiLayoutItem21.DataName = "order_date";
            this.multiLayoutItem21.DataType = IHIS.Framework.DataType.Date;
            // 
            // END1000U02
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel3);
            this.Controls.Add(this.xPanel2);
            this.Controls.Add(this.paBox);
            this.Name = "END1000U02";
            resources.ApplyResources(this, "$this");
            this.Closing += new System.ComponentModel.CancelEventHandler(this.END1000U02_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.paBox)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPurpose)).EndInit();
            this.xPanel7.ResumeLayout(false);
            this.xPanel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment2)).EndInit();
            this.xPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment3)).EndInit();
            this.xPanel10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdComment1)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsvDw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsvLDOCS0801)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layOrderDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private IHIS.Framework.XPatientBox paBox;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private System.Windows.Forms.LinkLabel lklImsangResult;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XDisplayBox dbxAge;
        private IHIS.Framework.XDisplayBox dbxSex;
        private IHIS.Framework.XDisplayBox dbxSuname;
        private IHIS.Framework.XDisplayBox dbxBunho;
        private IHIS.Framework.XDisplayBox dbxGumsaName;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XRichTextBox txtPurposeOfLab;
        private IHIS.Framework.XLabel xLabel3;
        private IHIS.Framework.XPanel pnlPatStatus;
        private IHIS.Framework.XLabel xLabel5;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGrid grdPurpose;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private System.Windows.Forms.Splitter splitter2;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XCheckBox cbxResidentYn;
        private IHIS.Framework.XLabel xLabel4;
        private IHIS.Framework.MultiLayout dsvDw;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem1;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem2;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem3;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem4;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem5;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem6;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem7;
        private IHIS.Framework.SingleLayout dsvGumsaName;
        private IHIS.Framework.SingleLayoutItem singleLayoutItem1;
        private IHIS.Framework.MultiLayout dsvLDOCS0801;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem8;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem9;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem10;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem11;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem12;
        private IHIS.Framework.XEditGrid grdPaStatus;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        private IHIS.Framework.XEditGridCell xEditGridCell9;
        private IHIS.Framework.XEditGridCell xEditGridCell10;
        private IHIS.Framework.XPanel xPanel6;
        private IHIS.Framework.XPanel xPanel7;
        private IHIS.Framework.XPanel xPanel8;
        private IHIS.Framework.XEditGrid grdComment2;
        private IHIS.Framework.XEditGridCell xEditGridCell12;
        private IHIS.Framework.XLabel xLabel6;
        private IHIS.Framework.XPanel xPanel9;
        private IHIS.Framework.XEditGrid grdComment3;
        private IHIS.Framework.XEditGridCell xEditGridCell13;
        private IHIS.Framework.XTabControl tabControl;
        private IHIS.Framework.XPanel xPanel10;
        private IHIS.Framework.XEditGrid grdComment1;
        private IHIS.Framework.XEditGridCell xEditGridCell11;
        private IHIS.Framework.XLabel xLabel7;
        private System.Windows.Forms.Label lbXrayName;
        private IHIS.Framework.MultiLayout layOrderDate;
        private IHIS.Framework.MultiLayoutItem multiLayoutItem21;
        private IHIS.Framework.XButton bntlImsangResult;

        #endregion

        #region Constructor
        /// <summary>
        /// END1000U02
        /// </summary>
        public END1000U02()
        {
            InitializeComponent();
        }
        #endregion

        #region fields
        private string mHospCode;
        private string mBunho;
        private string mOrderDate;
        private string mInOutGubun;
        private string mFkOcs;
        private string mHangmogCode;
        private string mGwa;
        private string mDoctor;
        private string mReadOnly = "N";
        private int flag = 0;
        private string old_c3 = ""; //검사의 목적
        private string old_resident_yn = "";

        private END1001U02OnLoadResult _onloadResult;
        private END1001U02LoadCommentsResult _loadCommentResult;
        private END1001U02BtnQueryResult _btnQueryResult;

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.OpenParam != null)
            {
                this.mHospCode = EnvironInfo.HospCode;
                this.mBunho = this.OpenParam["bunho"].ToString();
                this.mOrderDate = this.OpenParam["order_date"].ToString();
                this.mFkOcs = this.OpenParam["pkocskey"].ToString();
                this.mInOutGubun = this.OpenParam["in_out_gubun"].ToString();
                this.mHangmogCode = this.OpenParam["hangmog_code"].ToString();
                this.mGwa = this.OpenParam["gwa"].ToString();
                this.mDoctor = this.OpenParam["doctor"].ToString();
                this.mReadOnly = this.OpenParam["isReadOnly"].ToString();
            }
            else
            {
                this.mHospCode = EnvironInfo.HospCode;
                this.mHangmogCode = "X00231";
                this.mFkOcs = "109277";
                this.mBunho = "000200295";
                this.mDoctor = "TEST";
            }

            this.paBox.SetPatientID(this.mBunho);
            this.dbxBunho.SetDataValue(paBox.BunHo);
            this.dbxSuname.SetDataValue(paBox.SuName);
            this.dbxSex.SetDataValue(paBox.Sex);
            this.dbxAge.SetDataValue(paBox.YearAge);

            this.dsvDw.Reset();

            //if (!this.dsvDw.QueryLayout(true))
            //{
            //    XMessageBox.Show(Service.ErrFullMsg);
            //}
            //else
            //{
            //    if (this.dsvDw.RowCount == 0)
            //    {
            //        flag = 1;
            //        this.dsvDw.InsertRow(0);
            //    }

            //    this.txtPurposeOfLab.SetDataValue(this.dsvDw.GetItemString(0, "c3"));
            //    this.cbxResidentYn.SetDataValue(this.dsvDw.GetItemString(0, "resident_yn"));

            //}

            //// 검사명 조회
            //this.dsvGumsaName.QueryLayout();

            ////검사 목적 조회
            //this.grdPurpose.QueryLayout(true);

            ////환자상태기준정보조회
            //this.dsvLDOCS0801.QueryLayout(true);

            ////환자상태 조회
            //this.grdPaStatus.QueryLayout(true);

            //is read only mode??
            //부작용 데이터 조회


            LoadAllGrd();

            // Updated by Cloud
            dsvDw.ExecuteQuery = OnloadDsvDw;

            dsvGumsaName.ExecuteQuery = OnloadDsvGumsaName;
            grdPurpose.ExecuteQuery = OnloadGrdPurpose;
            dsvLDOCS0801.ExecuteQuery = OnloadDsvLdocs0801;
            grdPaStatus.ExecuteQuery = OnloadGrdPaStatus;

            this.dsvDw.QueryLayout(true);
            this.dsvGumsaName.QueryLayout();
            this.grdPurpose.QueryLayout(true);
            this.dsvLDOCS0801.QueryLayout(true);
            this.grdPaStatus.QueryLayout(true);

            if (this.dsvDw.RowCount == 0)
            {
                flag = 1;
                this.dsvDw.InsertRow(0);
            }

            this.txtPurposeOfLab.SetDataValue(this.dsvDw.GetItemString(0, "c3"));
            this.cbxResidentYn.SetDataValue(this.dsvDw.GetItemString(0, "resident_yn"));

            SetReadOnly();
            LoadComments();
        }

        private void dsvDw_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvDw.SetBindVarValue("f_fkocs", this.mFkOcs);
            this.dsvDw.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvDw_QueryEnd(object sender, QueryEndEventArgs e)
        {
            this.dbxGumsaName.SetDataValue(this.dsvDw.GetItemString(0, "hangmog_name"));
            old_c3 = this.dsvDw.GetItemString(0, "c3");
            old_resident_yn = this.dsvDw.GetItemString(0, "resident_yn");
        }

        private void dsvGumsaName_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvGumsaName.SetBindVarValue("f_code", this.mHangmogCode);
            this.dsvGumsaName.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void grdPurpose_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPurpose.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void dsvLDOCS0801_QueryStarting(object sender, CancelEventArgs e)
        {
            this.dsvLDOCS0801.SetBindVarValue("f_hangmog_code", this.mHangmogCode);
            this.dsvLDOCS0801.SetBindVarValue("f_hosp_code", this.mHospCode);
        }

        private void grdPaStatus_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdPaStatus.SetBindVarValue("f_hosp_code", this.mHospCode);
            this.grdPaStatus.SetBindVarValue("f_hangmog_code", this.mHangmogCode);
            this.grdPaStatus.SetBindVarValue("f_bunho", this.mBunho);
        }

        private void grdPaStatus_QueryEnd(object sender, QueryEndEventArgs e)
        {
            PatStatusDisplayData();
        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    e.IsBaseCall = false;

                    END1001U02BtnQueryArgs args = new END1001U02BtnQueryArgs();
                    args.Fkocs = mFkOcs;
                    args.HospCode = mHospCode;
                    args.Bunho = mBunho;
                    args.HangmogCode = mHangmogCode;

                    END1001U02BtnQueryResult res = CloudService.Instance.Submit<END1001U02BtnQueryResult, END1001U02BtnQueryArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success)
                    {
                        _btnQueryResult = res;
                    }
                    dsvDw.ExecuteQuery = OnloadBtndsvDw;
                    grdPaStatus.ExecuteQuery = OnloadBtnGrdPaStatus;

                    this.dsvDw.QueryLayout(true);
                    this.grdPaStatus.QueryLayout(true);
                    SetReadOnly();
                    break;
                case FunctionType.Update:

                    e.IsBaseCall = false;
                    if (mReadOnly == "Y")
                        return;

                    SetMsg("");

                    try
                    {
                        #region Deleted by Cloud
                        //Service.BeginTransaction();

                        //if (!PFE1000_IU())
                        //    throw new Exception();
                        //if (!OCS1801_IU())
                        //    throw new Exception();

                        //Service.CommitTransaction();
                        #endregion

                        // Updated code
                        if (PaStatusCheck())
                        {
                            MakeUpdate();

                            if (!SaveGrid())
                            {
                                // Save fail!
                                XMessageBox.Show(Resources.MSG_SAVE_FAIL, Resources.CAP_SAVE_FAIL, MessageBoxIcon.Error);
                                return;
                            }

                            // Save successfully!
                            //SetMsg("保存が完了しました。");
                            XMessageBox.Show(Resources.MSG_SAVE_SUCCESS, Resources.CAP_SAVE_SUCCESS);
                        }
                        else
                        {
                            //        string msg = NetInfo.Language == LangMode.Ko ? "필수 항목을 입력해 주세요." :
                            //"必須項目を入力してください。";
                            //        string caption = NetInfo.Language == LangMode.Ko ? "확인" :
                            //            "確認";

                            XMessageBox.Show(Resources.MSG_CHECK_SAVE, Resources.CAP_CHECK_SAVE);
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        //XMessageBox.Show("保存に失敗しました。\r\n" + Service.ErrFullMsg, "保存失敗", MessageBoxIcon.Error);
                        XMessageBox.Show(Resources.MSG_SAVE_FAIL, Resources.CAP_SAVE_FAIL, MessageBoxIcon.Error);
                        return;
                    }
                    //
                    this.btnList.PerformClick(FunctionType.Query);
                    this.Close();

                    break;
                default:
                    break;
            }
        }

        private void lklImsangResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowReservedScreen("01");
        }

        private void bntlImsangResult_Click(object sender, EventArgs e)
        {
            if (mReadOnly != "Y")
            {
                ShowReservedScreen("01");
            }
        }

        private void grdPurpose_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            if (e.ChangeValue.ToString() == "Y")
            {
                string text = txtPurposeOfLab.GetDataValue();
                if (text.Trim().Length == 0)
                    text = e.DataRow["purpose"].ToString();
                else
                    text = text + ", " + e.DataRow["purpose"].ToString();

                txtPurposeOfLab.SetDataValue(text);
            }
        }

        private void rbt_Click(object sender, System.EventArgs e)
        {
            RadioButton rbt = sender as RadioButton;

            foreach (object obj in ((Panel)rbt.Parent).Controls)
            {
                if (obj.GetType().ToString().IndexOf("RadioButton") >= 0)
                {
                    if (((RadioButton)obj).Checked)
                    {
                        ((RadioButton)obj).ForeColor = Color.LightSalmon;
                        ((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));

                        string pat_status = ((RadioButton)obj).Tag.ToString().Split('|')[0];
                        string pat_status_code = ((RadioButton)obj).Tag.ToString().Split('|')[1];

                        for (int i = 0; i < grdPaStatus.RowCount; i++)
                        {
                            if (grdPaStatus.GetItemString(i, "pat_status") == pat_status)
                                this.grdPaStatus.SetItemValue(i, "pat_status_code", pat_status_code);
                        }

                    }
                    else
                    {
                        ((RadioButton)obj).ForeColor = Color.Black;
                        ((RadioButton)obj).Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    }
                }
            }
        }

        private void END1000U02_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            grdPaStatus.AcceptData();
            txtPurposeOfLab.AcceptData();
            DialogResult btnResult;

            if (!CheckClosing())
            {
                //DialogResult dr = XMessageBox.Show("保存されていないデータがあります。保存して次に進みますか？\r\n\r\n" +
                //                                   "「Yes」：保存する　　「No」：保存しない　　「Cancel」：取消し　", "確認", MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);
                DialogResult dr = XMessageBox.Show(Resources.MSG1, Resources.CAP_CHECK_SAVE, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        //Service.BeginTransaction();
                        if (dr == DialogResult.Yes)
                        {
                            //저장 초기화
                            MakeUpdate();
                            // 저장
                            #region Cloud delete
                            
                            //PFE1000_IU();
                            //OCS1801_IU();

                            #endregion

                            SaveGrid();
                            e.Cancel = false;
                            return;
                        }
                        else if (dr == DialogResult.No)
                        {
                            e.Cancel = false;
                            return;
                        }
                        else
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                    catch
                    {
                        //Service.RollbackTransaction();
                        XMessageBox.Show(Resources.MSG_SAVE_FAIL + Service.ErrFullMsg, Resources.CAP_SAVE_FAIL, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else if (dr == DialogResult.No)
                {

                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            //#region 필수 입력 항목 체크
            //bool inputChk = PaStatusCheck();
            ////false : 필수입력 에러
            //#endregion

            //#region 1. 입력된게 하나도 없으면
            ///// 화면닫고, 오다코드 삭제			
            //string result_chk = "N";
            //for (int i = 0; i < grdPaStatus.RowCount; i++)
            //{
            //    if (grdPaStatus.GetItemString(i, "pat_status_code_name") != "")
            //        result_chk = "Y";
            //}
            //if ((result_chk == "N") && (txtPurposeOfLab.Text == "") )
            //{
            //    e.Cancel = false;
            //    ocsOrderDelete("Y");
            //    return;
            //}
            //else
            //    e.Cancel = true;
            //#endregion

            //#region 2_1. 변경된게 하나도 없으면
            ///// 화면닫고, 오다코드 삭제			
            //result_chk = "N";
            //grdPaStatus.AcceptData();
            //txtPurposeOfLab.AcceptData();
            //for (int i = 0; i < grdPaStatus.RowCount; i++)
            //{
            //    if (grdPaStatus.GetRowState(i) == DataRowState.Modified)
            //        result_chk = "Y";
            //}
            //if ((result_chk == "N") && (txtPurposeOfLab.Text == dsvDw.GetItemString(0, "c3")))
            //{
            //    e.Cancel = false;
            //    return;
            //}
            //else
            //    e.Cancel = true;
            //#endregion

            //#region 2. 필수입력 항목 변경후 MessageBox(Y, N, C)
            /////	'Y' : 보존후 닫기, 오다는 그대로
            /////	'N' : 그냥 닫기, 오다는 그대로
            /////	'C' : 메시지 화면만 닫기
            //string update_chk = "N";
            //for (int i = 0; i < grdPaStatus.RowCount; i++)
            //{
            //    if (grdPaStatus.GetItemString(i, "indispensable") == "Y" && (grdPaStatus.GetItemString(i, "pat_status_code") != grdPaStatus.GetItemString(i, "pat_status_code_old")))
            //        update_chk = "Y";
            //}

            //if (update_chk == "Y")
            //{
            //    string msg = NetInfo.Language == LangMode.Ko ? "보존하지 않은 데이타가 존재합니다. 보존후 종료" :
            //                    "保存されていないデータがあります。保存して次に進みますか？\r\n\r\n" +
            //                    "「Yes」：保存する　　「No」：保存しない　　「Cancel」：取消し　";
            //    string caption = NetInfo.Language == LangMode.Ko ? "확인" :
            //        "確認";

            //    btnResult = XMessageBox.Show(msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);
            //    if (btnResult == DialogResult.Yes)
            //    {
            //        //저장 초기화
            //        MakeUpdate();
            //        // 저장
            //        PFE1000_IU();
            //        OCS1801_IU();
            //        e.Cancel = false;
            //        return;
            //    }
            //    else if (btnResult == DialogResult.No)
            //    {
            //        e.Cancel = false;
            //        return;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            //#endregion

            //#region 3. 검사목적은 입력하고, 필수항목이 안들어간 경우 MessageBox(Y, N)
            /////	'Y' : 무조건 종료, 오다코드 삭제
            /////	'N' : 메시지 화면만 닫기
            //if ((txtPurposeOfLab.Text != "") && (!inputChk))
            //{
            //    string msg = NetInfo.Language == LangMode.Ko ? "검사목적이 삭제 됩니다. 화면을 닫아도 되겠습니까" :
            //        "検査の目的が削除されます。" + "\r\n" + "画面を閉じてよろしいですか？";
            //    string caption = NetInfo.Language == LangMode.Ko ? "확인" :
            //        "確認";

            //    btnResult = XMessageBox.Show(msg, caption, MessageBoxButtons.YesNo);
            //    if (btnResult == DialogResult.Yes)
            //    {
            //        e.Cancel = false;
            //        ocsOrderDelete("Y");
            //        return;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            //#endregion

            //#region 4. 검사목적 및 필수항목이 정상적으로 입력된 경우 MessageBox(Y, N, C)
            /////	'Y' : 보존후 닫기, 오다는 그대로
            /////	'N' : 무조건 종료, 오다는 그대로
            /////	'C' : 메시지 화면만 닫기
            //if ((txtPurposeOfLab.Text != "") && (inputChk))
            //{
            //    string msg = NetInfo.Language == LangMode.Ko ? "보존하지 않은 데이타가 존재합니다. 보존후 종료" :
            //                    "保存されていないデータがあります。保存して次に進みますか？\r\n\r\n" +
            //                    "「Yes」：保存する　　「No」：保存しない　　「Cancel」：取消し　";
            //    string caption = NetInfo.Language == LangMode.Ko ? "확인" :
            //        "確認";

            //    btnResult = XMessageBox.Show(msg, caption, MessageBoxButtons.YesNoCancel, MessageBoxDefaultButton.Button3, MessageBoxIcon.Question);
            //    if (btnResult == DialogResult.Yes)
            //    {
            //        //저장 초기화
            //        MakeUpdate();
            //        // 저장
            //        PFE1000_IU();
            //        OCS1801_IU();
            //        e.Cancel = false;
            //        return;
            //    }
            //    else if (btnResult == DialogResult.No)
            //    {
            //        e.Cancel = false;
            //        return;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
            //#endregion

            //#region 필수입력 항목이 안들어간 경우
            //if (!inputChk)
            //{
            //    string msg = NetInfo.Language == LangMode.Ko ? "필수 항목을 입력해 주세요." :
            //        "必須項目を入力してください。";
            //    string caption = NetInfo.Language == LangMode.Ko ? "확인" :
            //        "確認";

            //    XMessageBox.Show(msg, caption);
            //    e.Cancel = true;
            //    return;
            //}
            //#endregion


            e.Cancel = false;
            return;
        }

        private void tabControl_SelectionChanged(object sender, EventArgs e)
        {
            this.grdComment3.QueryLayout(false);
        }

        private void grdComment1_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment1.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment1.SetBindVarValue("f_bunho", this.dbxBunho.GetDataValue());
        }

        private void grdComment2_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdComment2.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment2.SetBindVarValue("f_bunho", this.dbxBunho.GetDataValue());
        }

        private void grdComment3_QueryStarting(object sender, CancelEventArgs e)
        {
            string order_date = tabControl.SelectedTab.Title;
            this.grdComment3.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdComment3.SetBindVarValue("f_bunho", this.dbxBunho.GetDataValue());
            this.grdComment3.SetBindVarValue("f_order_date", order_date);
        }

        private void layOrderDate_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layOrderDate.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layOrderDate.SetBindVarValue("f_bunho", this.dbxBunho.GetDataValue());
        }

        #endregion

        #region Methods

        private void SetReadOnly()
        {
            if (mReadOnly == "Y")
            {
                foreach (Control aPnl in pnlPatStatus.Controls)
                {
                    if (aPnl is Panel)
                    {
                        foreach (Control aCtl in ((Panel)aPnl).Controls)
                        {
                            if (aCtl is RadioButton)
                            {
                                ((RadioButton)aCtl).Enabled = false;
                            }
                        }
                    }
                }

                txtPurposeOfLab.ReadOnly = true;
                cbxResidentYn.Enabled = false;
                grdPurpose.ReadOnly = true;
            }
        }

        private void MakeUpdate()
        {
            if (this.dsvDw.RowCount == 0)
            {
                this.dsvDw.InsertRow(0);
            }

            this.dsvDw.SetItemValue(0, "fkocs", this.mFkOcs);
            this.dsvDw.SetItemValue(0, "bunho", this.mBunho);
            this.dsvDw.SetItemValue(0, "hangmog_code", this.mHangmogCode);
            this.dsvDw.SetItemValue(0, "c3", this.txtPurposeOfLab.GetDataValue());
            this.dsvDw.SetItemValue(0, "resident_yn", cbxResidentYn.GetDataValue());
        }

        private void ShowReservedScreen(string aCategory)
        {
            CommonItemCollection openParams = new CommonItemCollection();
            openParams.Add("category_gubun", aCategory);
            XScreen.OpenScreenWithParam(this, "OCSA", "OCS0221Q01", ScreenOpenStyle.ResponseFixed, openParams);
        }

        public override object Command(string command, CommonItemCollection commandParam)
        {
            switch (command.Trim())
            {
                case "OCS0221Q01": //OCS 상용어

                    #region

                    if (commandParam.Contains("COMMENT"))
                    {
                        //int startIndex = 0;
                        //string setText = "";

                        //startIndex = txtPurposeOfLab.SelectionStart;

                        //setText = txtPurposeOfLab.Text.Substring(0, startIndex) + commandParam["COMMENT"].ToString()
                        //        + txtPurposeOfLab.Text.Substring(startIndex);

                        //txtPurposeOfLab.SetEditValue(setText);


                        string text = txtPurposeOfLab.GetDataValue();
                        if (text.Trim().Length == 0)
                            text = commandParam["COMMENT"].ToString();
                        else
                            text = text + ", " + commandParam["COMMENT"].ToString();

                        txtPurposeOfLab.SetDataValue(text);
                    }
                    break;

                    #endregion
            }

            return base.Command(command, commandParam);
        }

        private bool PaStatusCheck()
        {
            for (int i = 0; i < grdPaStatus.RowCount; i++)
            {
                if (grdPaStatus.GetItemString(i, "indispensable") == "Y" && TypeCheck.IsNull(grdPaStatus.GetItemString(i, "pat_status_code")))
                {
                    return false;
                }
            }
            return true;
        }

        private void ocsOrderDelete(string cancel_yn)
        {
            try
            {
                //오프너 설정이 현재 스크린으로 되어있으나
                //추후 모든 오프너에서 커맨드를 받을 수가 있다면
                //수정이 필요함
                IHIS.Framework.IXScreen aScreen;
                aScreen = (IXScreen)this.Opener;

                CommonItemCollection openParams = new CommonItemCollection();
                openParams.Add("cancel_yn", cancel_yn);
                aScreen.Command("CPL2001U00", openParams);
            }
            catch { }
        }

        private void PatStatusDisplayData()
        {
            this.pnlPatStatus.Controls.Clear();

            if (this.grdPaStatus.RowCount == 0) return;

            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // 마우스 모래시계

                pnlPatStatus.SuspendLayout();

                Panel pnlRow = new System.Windows.Forms.Panel();
                Label lblPatStatus;
                RadioButton rbtPatStatusCode;

                string oldPatStatus = "";

                int rowLocationY = 5;
                int rowIndex = 0;
                int rowWidth = 0;

                int rbtLocationX = 295;

                for (int i = 0; i < this.dsvLDOCS0801.RowCount; i++)
                {
                    if (oldPatStatus != dsvLDOCS0801.GetItemString(i, "pat_status"))
                    {
                        //Row가 바뀔때 Row Panel사이즈를 조정한다.
                        if (i != 0)
                        {
                            //pnlRow.Size = new Size( rbtLocationX, pnlRow.Size.Height);
                            if (rbtLocationX > rowWidth)
                                rowWidth = rbtLocationX;
                        }

                        //Row Container 생성
                        pnlRow = new System.Windows.Forms.Panel();
                        pnlRow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        pnlRow.BackColor = System.Drawing.Color.Honeydew;
                        pnlRow.Location = new System.Drawing.Point(10, rowLocationY);
                        pnlRow.Name = "pnl_" + i.ToString();
                        pnlRow.Size = new System.Drawing.Size(1044, 25);
                        pnlRow.TabIndex = 0;
                        pnlRow.Tag = rowIndex;

                        this.pnlPatStatus.Controls.Add(pnlRow);

                        //Pat status 명칭 Label
                        lblPatStatus = new System.Windows.Forms.Label();
                        lblPatStatus.Dock = System.Windows.Forms.DockStyle.Left;
                        lblPatStatus.Location = new System.Drawing.Point(0, 0);
                        //lblPatStatus.Location = new System.Drawing.Point(10, rowLocationY);
                        lblPatStatus.Name = "lbl_" + dsvLDOCS0801.GetItemString(i, "pat_status");
                        lblPatStatus.Size = new System.Drawing.Size(180, 25);
                        lblPatStatus.TabIndex = 0;
                        lblPatStatus.Text = "   " + dsvLDOCS0801.GetItemString(i, "pat_status_name");

                        if (dsvLDOCS0801.GetItemString(i, "indispensable_yn") == "Y")
                            lblPatStatus.ForeColor = Color.Red;
                        else
                            lblPatStatus.ForeColor = Color.MediumSlateBlue;

                        //lblPatStatus.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                        lblPatStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        lblPatStatus.Tag = dsvLDOCS0801.GetItemString(i, "pat_status");
                        pnlRow.Controls.Add(lblPatStatus);

                        //pnlPatStatus.Controls.Add(lblPatStatus);

                        //다음 Row위치 + 5
                        rowLocationY = rowLocationY + 30;
                        rowIndex++;

                        //radio item Location 초기화
                        rbtLocationX = 185;

                        oldPatStatus = dsvLDOCS0801.GetItemString(i, "pat_status");
                    }

                    rbtPatStatusCode = new System.Windows.Forms.RadioButton();
                    rbtPatStatusCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    rbtPatStatusCode.Location = new System.Drawing.Point(rbtLocationX, 0);
                    rbtPatStatusCode.Name = "rbt_" + dsvLDOCS0801.GetItemString(i, "pat_status") + dsvLDOCS0801.GetItemString(i, "pat_status_code");
                    rbtPatStatusCode.Size = new System.Drawing.Size(90, 25);
                    rbtPatStatusCode.TabIndex = 0;
                    rbtPatStatusCode.Text = dsvLDOCS0801.GetItemString(i, "pat_status_code_name");
                    rbtPatStatusCode.Tag = dsvLDOCS0801.GetItemString(i, "pat_status") + "|" + dsvLDOCS0801.GetItemString(i, "pat_status_code");
                    rbtPatStatusCode.Cursor = System.Windows.Forms.Cursors.Hand;
                    rbtPatStatusCode.Click += new System.EventHandler(this.rbt_Click);
                    if (this.grdPaStatus.LayoutTable.Select("pat_status = '" + dsvLDOCS0801.GetItemString(i, "pat_status") + "' and pat_status_code = '" + dsvLDOCS0801.GetItemString(i, "pat_status_code") + "' ", "").Length > 0)
                    {
                        rbtPatStatusCode.Checked = true;
                        rbtPatStatusCode.ForeColor = Color.LightSalmon;
                        rbtPatStatusCode.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
                    }

                    pnlRow.Controls.Add(rbtPatStatusCode);

                    rbtLocationX = rbtLocationX + 95;
                }

                if (rbtLocationX > rowWidth)
                    rowWidth = rbtLocationX;

                if (rowWidth < pnlPatStatus.Width - 30)
                    rowWidth = pnlPatStatus.Width - 30;


                //row panel을 맞춘다.
                foreach (object obj in pnlPatStatus.Controls)
                {
                    if (obj.GetType().ToString().IndexOf("Panel") >= 0)
                        ((Panel)obj).Size = new Size(rowWidth, ((Panel)obj).Size.Height);
                }

                if (this.grdPaStatus.RowCount == 0)
                    pnlPatStatus.Enabled = false;
                else
                    pnlPatStatus.Enabled = true;

                pnlPatStatus.ResumeLayout();

            }
            finally
            {
                Cursor.Current = System.Windows.Forms.Cursors.Default; // 마우스 원상복귀
            }
        }

        private bool PFE1000_IU()
        {
            if (PaStatusCheck())
            {
                MakeUpdate();

                string cmdText = string.Empty;
                object retVal = null;
                BindVarCollection bindVals = new BindVarCollection();

                cmdText = @"SELECT 'Y'
                                      FROM DUAL
                                     WHERE EXISTS ( SELECT 'X'
                                                      FROM PFE1000 A
                                                     WHERE A.FKOCS     = :f_fkocs
                                                       AND A.HOSP_CODE = :f_hosp_code)";

                bindVals.Add("f_fkocs", this.mFkOcs);
                bindVals.Add("f_hosp_code", this.mHospCode);

                retVal = Service.ExecuteScalar(cmdText, bindVals);

                if (Service.ErrCode == 0)
                {
                    if (retVal != null && retVal.ToString().Equals("Y"))
                    {
                        foreach (DataRow row in dsvDw.LayoutTable.Rows)
                        {
                            string cmdUpdate = string.Empty;
                            BindVarCollection bindValUpdate = new BindVarCollection();

                            cmdUpdate = @"UPDATE PFE1000
                                                     SET UPD_ID       = :f_upd_id
                                                       , UPD_DATE     = SYSDATE
                                                       , C3           = :f_c3
                                                       , BUNHO        = :f_bunho
                                                       , HANGMOG_CODE = :f_hangmog_code   
                                                       , RESIDENT_YN  = :f_resident_yn  
                                                   WHERE FKOCS        = :f_fkocs
                                                     AND HOSP_CODE    = :f_hosp_code";

                            bindValUpdate.Add("f_upd_id", this.mDoctor);
                            bindValUpdate.Add("f_c3", row["c3"].ToString());
                            bindValUpdate.Add("f_fkocs", row["fkocs"].ToString());
                            bindValUpdate.Add("f_bunho", row["bunho"].ToString());
                            bindValUpdate.Add("f_hangmog_code", row["hangmog_code"].ToString());
                            bindValUpdate.Add("f_resident_yn", this.cbxResidentYn.GetDataValue());
                            bindValUpdate.Add("f_hosp_code", this.mHospCode);

                            Service.ExecuteNonQuery(cmdUpdate, bindValUpdate);

                            // DB 처리 성공
                            if (Service.ErrCode == 0)
                            {

                            }
                            // DB 처리 실패
                            else
                            {
                                //Service.RollbackTransaction();
                                //XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        // 키값 생성
                        string cmdSeq = string.Empty;
                        string cmdInsert = string.Empty;
                        object retSeq = null;
                        BindVarCollection bindVal = new BindVarCollection();
                        BindVarCollection bindValInsert = new BindVarCollection();

                        cmdSeq = @"SELECT NVL(MAX(PKPFE1000),0) + 1 FROM PFE1000 WHERE HOSP_CODE = :f_hosp_code";

                        bindVal.Add("f_hosp_code", this.mHospCode);
                        retSeq = Service.ExecuteScalar(cmdSeq, bindVal);

                        // Insert
                        cmdInsert = @"INSERT INTO PFE1000 (SYS_DATE,              UPD_ID,                  UPD_DATE
                                                          ,PKPFE1000
                                                          ,C3       
                                                          ,FKOCS 
                                                          ,BUNHO
                                                          ,HANGMOG_CODE  
                                                          ,RESIDENT_YN
                                                          ,HOSP_CODE        
                                                          ) VALUES (
                                                           SYSDATE,               :f_upd_id,               SYSDATE
                                                          ,:f_pkpfe1000
                                                          ,:f_c3
                                                          ,:f_fkocs   
                                                          ,:f_bunho
                                                          ,:f_hangmog_code        
                                                          ,:f_resident_yn
                                                          ,:f_hosp_code
                                                          )";

                        bindValInsert.Add("f_upd_id", this.mDoctor);
                        bindValInsert.Add("f_pkpfe1000", retSeq.ToString());
                        bindValInsert.Add("f_c3", txtPurposeOfLab.Text);
                        bindValInsert.Add("f_fkocs", this.mFkOcs);
                        bindValInsert.Add("f_bunho", this.mBunho);
                        bindValInsert.Add("f_hangmog_code", this.mHangmogCode);
                        bindValInsert.Add("f_resident_yn", this.cbxResidentYn.GetDataValue());
                        bindValInsert.Add("f_hosp_code", this.mHospCode);

                        Service.ExecuteNonQuery(cmdInsert, bindValInsert);

                        // DB 처리 성공
                        if (Service.ErrCode == 0)
                        {

                        }
                        // DB 처리 실패
                        else
                        {
                            //Service.RollbackTransaction();
                            //XMessageBox.Show(Service.ErrFullMsg);
                            return false;
                        }
                    }
                }
                else
                {
                    //Service.RollbackTransaction();
                    //XMessageBox.Show(Service.ErrFullMsg);
                    return false;
                }
            }
            else
            {
                string msg = NetInfo.Language == LangMode.Ko ? "필수 항목을 입력해 주세요." :
                    Resources.MSG_CHECK_SAVE;
                string caption = NetInfo.Language == LangMode.Ko ? "확인" :
                    Resources.CAP_CHECK_SAVE;

                XMessageBox.Show(msg, caption);

                return false;
            }
            return true;
        }

        private bool OCS1801_IU()
        {
            foreach (DataRow row in grdPaStatus.LayoutTable.Rows)
            {
                string cmdText = string.Empty;
                object retVal = null;
                BindVarCollection bindVals = new BindVarCollection();

                if (row.RowState == DataRowState.Modified)
                {
                    cmdText = @"SELECT 'Y'
                              FROM DUAL
                             WHERE EXISTS ( SELECT 'X'
                                              FROM OCS1801 A
                                             WHERE A.BUNHO      = :f_bunho
                                               AND A.PAT_STATUS = :f_pat_status
                                               AND A.HOSP_CODE  = :f_hosp_code)";

                    bindVals.Add("f_bunho", this.mBunho);
                    //bindVals.Add("pat_status_code", row["pat_status_code"].ToString());
                    bindVals.Add("f_pat_status", row["pat_status"].ToString());
                    bindVals.Add("f_hosp_code", this.mHospCode);

                    retVal = Service.ExecuteScalar(cmdText, bindVals);

                    if (Service.ErrCode == 0)
                    {
                        if (retVal != null && retVal.ToString().Equals("Y"))
                        {
                            string cmdUpdate = string.Empty;
                            BindVarCollection bindValUpdate = new BindVarCollection();

                            cmdUpdate = @"UPDATE OCS1801
                                         SET UPD_ID           = :f_upd_id         ,
                                             UPD_DATE         = SYSDATE           ,
                                             PAT_STATUS       = :f_pat_status     ,
                                             PAT_STATUS_CODE  = :f_pat_status_code,
                                             MENT             = :f_ment           ,
                                             SEQ              = :f_seq
                                       WHERE BUNHO            = :f_bunho
                                         AND PAT_STATUS       = :f_pat_status
                                         AND HOSP_CODE        = :f_hosp_code";

                            bindValUpdate.Add("f_upd_id", this.mDoctor);
                            bindValUpdate.Add("f_pat_status", row["pat_status"].ToString());
                            bindValUpdate.Add("f_pat_status_code", row["pat_status_code"].ToString());
                            bindValUpdate.Add("f_ment", row["ment"].ToString());
                            bindValUpdate.Add("f_seq", row["seq"].ToString());
                            bindValUpdate.Add("f_bunho", this.mBunho);
                            bindValUpdate.Add("f_hosp_code", this.mHospCode);

                            Service.ExecuteNonQuery(cmdUpdate, bindValUpdate);

                            // DB 처리 성공
                            if (Service.ErrCode == 0)
                            {

                            }
                            // DB 처리 실패
                            else
                            {
                                //Service.RollbackTransaction();
                                //XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                        }
                        else
                        {
                            string cmdInsert = string.Empty;
                            BindVarCollection bindValInsert = new BindVarCollection();

                            cmdInsert = @"INSERT INTO OCS1801
                                                  ( SYS_DATE          , UPD_ID       , UPD_DATE   , BUNHO    , PAT_STATUS    ,
                                                    PAT_STATUS_CODE   , MENT         , SEQ        , HOSP_CODE )
                                            VALUES
                                                  ( SYSDATE           , :f_upd_id    , SYSDATE    , :f_bunho , :f_pat_status ,
                                                    :f_pat_status_code, :f_ment      , :f_seq     , :f_hosp_code )";

                            bindValInsert.Add("f_upd_id", this.mDoctor);
                            bindValInsert.Add("f_pat_status", row["pat_status"].ToString());
                            bindValInsert.Add("f_pat_status_code", row["pat_status_code"].ToString());
                            bindValInsert.Add("f_ment", row["ment"].ToString());
                            bindValInsert.Add("f_seq", row["seq"].ToString());
                            bindValInsert.Add("f_bunho", this.mBunho);
                            bindValInsert.Add("f_hosp_code", this.mHospCode);

                            Service.ExecuteNonQuery(cmdInsert, bindValInsert);

                            // DB 처리 성공
                            if (Service.ErrCode == 0)
                            {

                            }
                            // DB 처리 실패
                            else
                            {
                                //Service.RollbackTransaction();
                                //XMessageBox.Show(Service.ErrFullMsg);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        //Service.RollbackTransaction();
                        //XMessageBox.Show(Service.ErrFullMsg);
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckClosing()
        {
            //삭제안하므로 없겠지만 혹시 모르니까.
            if (this.grdPaStatus.DeletedRowCount > 0)
            {
                return false;
            }

            foreach (DataRow row in this.grdPaStatus.LayoutTable.Rows)
            {
                if (row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added)//Added는 없겠지만 혹시 모르니까
                {
                    return false;
                }
            }

            if ((this.cbxResidentYn.GetDataValue().ToString() != this.old_resident_yn) ||
                 (this.txtPurposeOfLab.Text != this.old_c3)
               )
            {
                return false;
            }
            return true;
        }

        private void LoadComments()
        {
            //this.grdComment1.QueryLayout(false);
            //this.grdComment2.QueryLayout(false);

            //this.layOrderDate.QueryLayout(true);
            //if (this.layOrderDate.RowCount > 0)
            //{
            //    TabCreate();
            //    this.grdComment3.QueryLayout(false);
            //}

            END1001U02LoadCommentsArgs args = new END1001U02LoadCommentsArgs();
            args.HospCode = EnvironInfo.HospCode;
            args.Bunho = dbxBunho.GetDataValue();

            END1001U02LoadCommentsResult res = CloudService.Instance.Submit<END1001U02LoadCommentsResult, END1001U02LoadCommentsArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _loadCommentResult = res;
            }

            grdComment1.ExecuteQuery = OnloadGrdComment1;
            grdComment2.ExecuteQuery = OnloadGrdComment2;
            layOrderDate.ExecuteQuery = OnloadLayOrderDate;

            this.grdComment1.QueryLayout(true);
            this.grdComment2.QueryLayout(true);
            this.layOrderDate.QueryLayout(true);

            if (this.layOrderDate.RowCount > 0)
            {
                TabCreate();

                grdComment3.ExecuteQuery = OnloadGrdComment3;
                this.grdComment3.QueryLayout(true);
            }
        }

        private void TabCreate()
        {
            //this.dsvSideEffect.QueryLayout(true);

            // 텝 페이지 생성시 첫번째 페이지가 선택된것으로 간주된다.
            // 따라서 전체조회가 되므로 잠시 이벤트를 없애놓음
            this.tabControl.SelectionChanged -= new System.EventHandler(this.tabControl_SelectionChanged);

            // 텝 페이지 생성
            for (int i = 0; i < layOrderDate.RowCount; i++)
            {
                string xray_date = layOrderDate.GetItemString(i, "order_date");

                IHIS.X.Magic.Controls.TabPage tabPage =
                    new IHIS.X.Magic.Controls.TabPage(layOrderDate.GetItemString(i, "order_date"));
                tabPage.Tag = i;
                tabControl.TabPages.Add(tabPage);
            }

            this.tabControl.SelectionChanged += new System.EventHandler(this.tabControl_SelectionChanged);
        }

        #endregion

        #region Cloud updated

        #region SaveGrid
        /// <summary>
        /// SaveGrid
        /// </summary>
        /// <returns></returns>
        private bool SaveGrid()
        {
            List<END1001U02DsvDwInfo> dsvList = new List<END1001U02DsvDwInfo>();
            List<END1001U02GrdPaStatusInfo> patList = new List<END1001U02GrdPaStatusInfo>();

            // Pre-save
            foreach (DataRow row in dsvDw.LayoutTable.Rows)
            {
                END1001U02DsvDwInfo item = new END1001U02DsvDwInfo();

                item.Bunho = row["bunho"].ToString();
                item.C3 = row["c3"].ToString();
                item.Fkocs = row["fkocs"].ToString();
                item.HangmogCode = row["hangmog_code"].ToString();

                dsvList.Add(item);
            }

            foreach (DataRow row in grdPaStatus.LayoutTable.Rows)
            {
                END1001U02GrdPaStatusInfo item = new END1001U02GrdPaStatusInfo();

                item.PatStatus = row["pat_status"].ToString();
                item.PatStatusCode = row["pat_status_code"].ToString();
                item.Ment = row["ment"].ToString();
                item.Seq = row["seq"].ToString();

                patList.Add(item);
            }

            END1001U02UpdateMerGrdArgs args = new END1001U02UpdateMerGrdArgs();
            args.HospCode = this.mHospCode;
            args.ResidentYn = this.cbxResidentYn.GetDataValue();
            args.UpdId = this.mDoctor;
            args.Bunho = this.mBunho;
            args.C3 = txtPurposeOfLab.Text;
            args.FkOcs = this.mFkOcs;
            args.HangmogCode = this.mHangmogCode;
            args.DsvdwObj = dsvList;
            args.GrdpaStatusObj = patList;
            UpdateResult res = CloudService.Instance.Submit<UpdateResult, END1001U02UpdateMerGrdArgs>(args);

            return res.ExecutionStatus == IHIS.CloudConnector.Contracts.Results.ExecutionStatus.Success && res.Result;
        }
        #endregion

        private void LoadAllGrd()
        {
            END1001U02OnLoadArgs args = new END1001U02OnLoadArgs();
            args.Fkocs = mFkOcs;
            args.HospCode = mHospCode;
            args.HangmogCode = mHangmogCode;
            args.Bunho = mBunho;
            args.Code = mHangmogCode;
            END1001U02OnLoadResult res = CloudService.Instance.Submit<END1001U02OnLoadResult, END1001U02OnLoadArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                _onloadResult = res;
            }
        }

        private IList<object[]> OnloadDsvDw(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            _onloadResult.OnloadDsvdwItem.ForEach(delegate(END1001U02DsvDwInfo item)
            {
                lObj.Add(new object[]
                {
                    item.Pkpfe1000,
                    item.C3,
                    item.Fkocs,
                    item.Bunho,
                    item.HangmogCode,
                    item.HangmogName,
                    item.ResidentYn
                });
            });

            return lObj;
        }

        private IList<object[]> OnloadDsvGumsaName(BindVarCollection bc)
        {
            IList<object[]> dsvGumsaNameObj = new List<object[]>();
            _onloadResult.OnloadDsvgumsanameItem.ForEach(delegate(END1001U02StrInfo itemEnd1001U02StrInfo)
            {
                dsvGumsaNameObj.Add(new object[]
                {
                    itemEnd1001U02StrInfo.Value
                });
            });

            return dsvGumsaNameObj;
        }

        private IList<object[]> OnloadGrdPurpose(BindVarCollection bc)
        {
            IList<object[]> grdPurObjectses = new List<object[]>();
            _onloadResult.OnloadGrdpurposeItem.ForEach(delegate(END1001U02GrdPurposeInfo itemPurposeInfo)
            {
                grdPurObjectses.Add(new object[]
                {
                    itemPurposeInfo.N,
                    itemPurposeInfo.CodeName
                });
            });
            return grdPurObjectses;
        }

        private IList<object[]> OnloadDsvLdocs0801(BindVarCollection bc)
        {
            IList<object[]> grdDsvLdocs0801Obj = new List<object[]>();
            _onloadResult.OnloadDsvldocs0801Item.ForEach(delegate(END1001U02DsvLDOCS0801Info itemDsvLdocs0801Info)
            {
                grdDsvLdocs0801Obj.Add(new object[]
                {
                    itemDsvLdocs0801Info.PatStatus,
                    itemDsvLdocs0801Info.PatStatusName,
                    itemDsvLdocs0801Info.PatStatusCode,
                    itemDsvLdocs0801Info.PatStatusCodeName,
                    itemDsvLdocs0801Info.IndispensableYn
                });
            });

            return grdDsvLdocs0801Obj;
        }

        private IList<object[]> OnloadGrdPaStatus(BindVarCollection bc)
        {
            IList<object[]> lstGrdPaStatusObjectses = new List<object[]>();
            _onloadResult.OnloadGrdpastatusItem.ForEach(delegate(END1001U02GrdPaStatusInfo itemGrdPaStatusInfo)
            {
                lstGrdPaStatusObjectses.Add(new object[]
                {
                    itemGrdPaStatusInfo.Bunho,
                    itemGrdPaStatusInfo.PatStatus,
                    itemGrdPaStatusInfo.PatStatusName,
                    itemGrdPaStatusInfo.PatStatusCode,
                    itemGrdPaStatusInfo.PatStatusCodeName,
                    itemGrdPaStatusInfo.Ment,
                    itemGrdPaStatusInfo.Seq,
                    itemGrdPaStatusInfo.IndispensableYn,
                    itemGrdPaStatusInfo.ContKey
                });
            });

            return lstGrdPaStatusObjectses;
        }

        private IList<object[]> OnloadGrdComment1(BindVarCollection bc)
        {
            IList<object[]> lstLoadGrdComment1 = new List<object[]>();
            _loadCommentResult.Grdcomment1Item.ForEach(delegate(END1001U02StrInfo itemStrInfo)
            {
                lstLoadGrdComment1.Add(new object[]
                {
                    itemStrInfo.Value
                });
            });
            return lstLoadGrdComment1;
        }

        private IList<object[]> OnloadGrdComment2(BindVarCollection bc)
        {
            IList<object[]> lstLoadGrdComment2 = new List<object[]>();
            _loadCommentResult.Grdcomment2Item.ForEach(delegate(END1001U02StrInfo itemStr2)
            {
                lstLoadGrdComment2.Add(new object[]
                {
                    itemStr2.Value
                });
            });
            return lstLoadGrdComment2;
        }

        private IList<object[]> OnloadLayOrderDate(BindVarCollection bc)
        {
            IList<object[]> lstLoadLayOrderDate = new List<object[]>();
            _loadCommentResult.LayorderdateItem.ForEach(delegate(END1001U02LayOrderDateInfo itemLayOrderDate)
            {
                lstLoadLayOrderDate.Add(new object[]
                {
                    itemLayOrderDate.OrderDate
                });
            });

            return lstLoadLayOrderDate;
        }

        private IList<object[]> OnloadGrdComment3(BindVarCollection bc)
        {
            IList<object[]> lObj = new List<object[]>();

            END1001U02GrdComment3Args args = new END1001U02GrdComment3Args();
            args.Bunho = bc["f_bunho"].VarValue;
            args.HospCode = bc["f_hosp_code"].VarValue;
            args.OrderDate = bc["f_order_date"].VarValue;
            END1001U02GrdComment3Result res = CloudService.Instance.Submit<END1001U02GrdComment3Result, END1001U02GrdComment3Args>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdComment3Item.ForEach(delegate(END1001U02GrdComment3Info item)
                {
                    lObj.Add(new object[]
                    {
                        item.Comments,
                        item.Numb,
                        item.Ser,
                    });
                });
            }

            return lObj;
        }

        private IList<object[]> OnloadBtndsvDw(BindVarCollection bc)
        {
            IList<object[]> lstOnloaddsvDw = new List<object[]>();
            _btnQueryResult.DsvdwItem.ForEach(delegate(END1001U02DsvDwInfo itemDsvDwInfo)
            {
                lstOnloaddsvDw.Add(new object[]
                {
                    itemDsvDwInfo.Pkpfe1000,
                    itemDsvDwInfo.C3,
                    itemDsvDwInfo.Fkocs,
                    itemDsvDwInfo.Bunho,
                    itemDsvDwInfo.HangmogCode,
                    itemDsvDwInfo.HangmogName,
                    itemDsvDwInfo.ResidentYn
                });
            });

            return lstOnloaddsvDw;
        }

        private IList<object[]> OnloadBtnGrdPaStatus(BindVarCollection bc)
        {
            IList<object[]> lstOnloaddsvDw = new List<object[]>();
            _btnQueryResult.PastatusItem.ForEach(delegate(END1001U02GrdPaStatusInfo itemPaStatusInfo)
            {
                lstOnloaddsvDw.Add(new object[]
                {
                    itemPaStatusInfo.Bunho,
                    itemPaStatusInfo.PatStatus,
                    itemPaStatusInfo.PatStatusName,
                    itemPaStatusInfo.PatStatusCode,
                    itemPaStatusInfo.PatStatusCodeName,
                    itemPaStatusInfo.Ment,
                    itemPaStatusInfo.Seq,
                    itemPaStatusInfo.IndispensableYn,
                    itemPaStatusInfo.ContKey
                });
            });

            return lstOnloaddsvDw;
        }

        #endregion
    }
}