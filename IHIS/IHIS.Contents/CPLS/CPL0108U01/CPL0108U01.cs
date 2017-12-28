/*
** CPL0108U01 各種コード管理
** Date        : 2007. 11. 05
** Modified    : 2008. 02. 15
**              Park Seung Hwan
*/

#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using Microsoft.Win32;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Arguments.Adma;
using IHIS.CloudConnector.Contracts.Results.Adma;
using IHIS.CloudConnector.Utility;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CPLS.Properties;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0108U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0108U01 : IHIS.Framework.XScreen
    {
        #region Fields
        //private XSavePerformer savePerformer = null;
        string mHospCode = EnvironInfo.HospCode;
        private const string LblADMIN = "ADMIN";
        #endregion

        #region Designer generated code
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XTextBox txtCodeTypeName;
        private IHIS.Framework.XTextBox txtCodeType;
        private IHIS.Framework.XButton btnPrintName;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        private XDisplayBox dbxHospName;
        private XFindBox fbxHospitalCode;
        private XFindWorker fwkCommon;
        private FindColumnInfo findColumnInfo3;
        private FindColumnInfo findColumnInfo4;
        private XLabel xLabel3;
        private SingleLayout layCommon;
        private SingleLayoutItem singleLayoutItem1;

        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0108U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnPrintName = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.dbxHospName = new IHIS.Framework.XDisplayBox();
            this.fbxHospitalCode = new IHIS.Framework.XFindBox();
            this.fwkCommon = new IHIS.Framework.XFindWorker();
            this.findColumnInfo3 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo4 = new IHIS.Framework.FindColumnInfo();
            this.xLabel3 = new IHIS.Framework.XLabel();
            this.txtCodeTypeName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtCodeType = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.layCommon = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.xPanel4.SuspendLayout();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // xPanel1
            // 
            this.xPanel1.AccessibleDescription = null;
            this.xPanel1.AccessibleName = null;
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.BackgroundImage = null;
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Font = null;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.AccessibleDescription = null;
            this.xPanel5.AccessibleName = null;
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.BackgroundImage = null;
            this.xPanel5.Controls.Add(this.grdDetail);
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Font = null;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell17,
            this.xEditGridCell8});
            this.grdDetail.ColPerLine = 4;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 5;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdDetail_MouseClick);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 54;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 140;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 40;
            this.xEditGridCell6.CellName = "code_name_re";
            this.xEditGridCell6.CellWidth = 140;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "system_gubun";
            this.xEditGridCell17.Col = -1;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 30;
            this.xEditGridCell8.CellName = "code_value";
            this.xEditGridCell8.CellWidth = 189;
            this.xEditGridCell8.Col = 4;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell7});
            this.grdMaster.ColPerLine = 3;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 4;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdMaster_MouseClick);
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 75;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 250;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "admin_gubun";
            this.xEditGridCell7.Col = 3;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            this.xEditGridCell7.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell7.UserSQL = resources.GetString("xEditGridCell7.UserSQL");
            // 
            // splitter1
            // 
            this.splitter1.AccessibleDescription = null;
            this.splitter1.AccessibleName = null;
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackgroundImage = null;
            this.splitter1.Font = null;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.AccessibleDescription = null;
            this.xPanel4.AccessibleName = null;
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.BackgroundImage = null;
            this.xPanel4.Controls.Add(this.grdMaster);
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Font = null;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            this.xPanel3.AccessibleDescription = null;
            this.xPanel3.AccessibleName = null;
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.BackgroundImage = null;
            this.xPanel3.Controls.Add(this.btnPrintName);
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnPrintName
            // 
            this.btnPrintName.AccessibleDescription = null;
            this.btnPrintName.AccessibleName = null;
            resources.ApplyResources(this.btnPrintName, "btnPrintName");
            this.btnPrintName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintName.BackgroundImage = null;
            this.btnPrintName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintName.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintName.Image")));
            this.btnPrintName.Name = "btnPrintName";
            this.btnPrintName.Click += new System.EventHandler(this.btnPrintName_Click);
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
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // xPanel2
            // 
            this.xPanel2.AccessibleDescription = null;
            this.xPanel2.AccessibleName = null;
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.BackgroundImage = null;
            this.xPanel2.Controls.Add(this.dbxHospName);
            this.xPanel2.Controls.Add(this.fbxHospitalCode);
            this.xPanel2.Controls.Add(this.xLabel3);
            this.xPanel2.Controls.Add(this.txtCodeTypeName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtCodeType);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // dbxHospName
            // 
            this.dbxHospName.AccessibleDescription = null;
            this.dbxHospName.AccessibleName = null;
            resources.ApplyResources(this.dbxHospName, "dbxHospName");
            this.dbxHospName.Image = null;
            this.dbxHospName.Name = "dbxHospName";
            // 
            // fbxHospitalCode
            // 
            this.fbxHospitalCode.AccessibleDescription = null;
            this.fbxHospitalCode.AccessibleName = null;
            resources.ApplyResources(this.fbxHospitalCode, "fbxHospitalCode");
            this.fbxHospitalCode.BackgroundImage = null;
            this.fbxHospitalCode.FindWorker = this.fwkCommon;
            this.fbxHospitalCode.Name = "fbxHospitalCode";
            this.fbxHospitalCode.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.fbxHospitalCode_DataValidating);
            // 
            // fwkCommon
            // 
            this.fwkCommon.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo3,
            this.findColumnInfo4});
            this.fwkCommon.ExecuteQuery = null;
            this.fwkCommon.FormText = "病院コード";
            this.fwkCommon.InputSQL = null;
            this.fwkCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCommon.ParamList")));
            this.fwkCommon.SearchImeMode = System.Windows.Forms.ImeMode.Inherit;
            this.fwkCommon.ServerFilter = true;
            this.fwkCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.fwkCommon_QueryStarting);
            // 
            // findColumnInfo3
            // 
            this.findColumnInfo3.ColName = "hosp";
            this.findColumnInfo3.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo3, "findColumnInfo3");
            // 
            // findColumnInfo4
            // 
            this.findColumnInfo4.ColName = "hosp_name";
            this.findColumnInfo4.ColWidth = 155;
            this.findColumnInfo4.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo4, "findColumnInfo4");
            // 
            // xLabel3
            // 
            this.xLabel3.AccessibleDescription = null;
            this.xLabel3.AccessibleName = null;
            resources.ApplyResources(this.xLabel3, "xLabel3");
            this.xLabel3.BackGroundPattern = IHIS.Framework.DrawPattern.HorizonGRAD1;
            this.xLabel3.EdgeRounding = false;
            this.xLabel3.Image = null;
            this.xLabel3.Name = "xLabel3";
            // 
            // txtCodeTypeName
            // 
            this.txtCodeTypeName.AccessibleDescription = null;
            this.txtCodeTypeName.AccessibleName = null;
            resources.ApplyResources(this.txtCodeTypeName, "txtCodeTypeName");
            this.txtCodeTypeName.BackgroundImage = null;
            this.txtCodeTypeName.Name = "txtCodeTypeName";
            this.txtCodeTypeName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeTypeName_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtCodeType
            // 
            this.txtCodeType.AccessibleDescription = null;
            this.txtCodeType.AccessibleName = null;
            resources.ApplyResources(this.txtCodeType, "txtCodeType");
            this.txtCodeType.BackgroundImage = null;
            this.txtCodeType.Name = "txtCodeType";
            this.txtCodeType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeType_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // layCommon
            // 
            this.layCommon.ExecuteQuery = null;
            this.layCommon.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layCommon.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layCommon.ParamList")));
            this.layCommon.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layCommon_QueryStarting);
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.BindControl = this.dbxHospName;
            this.singleLayoutItem1.DataName = "HospitalName";
            // 
            // CPL0108U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0108U01";
            this.Load += new System.EventHandler(this.CPL0108U01_Load);
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.xPanel4.ResumeLayout(false);
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.xPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// CPL0108U01
        /// </summary>
        public CPL0108U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            // Updated by Cloud
            InitializeCloud();

            if (!IsAdminGroup())
            {
                this.grdMaster.ReadOnly = true;
            }
        }
        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("cpl0109");
            this.CurrMQLayout = this.grdMaster;

            // deleted by Cloud
            //savePerformer = new XSavePerformer(this);
            //this.grdMaster.SavePerformer = savePerformer;
            //this.grdDetail.SavePerformer = savePerformer;

            this.grdMaster.QueryLayout(true);
        }

        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                string cmdText = string.Empty;    // 중복 체크를 위한 쿼리문
                string msg = string.Empty;    // 에러 검출시 메세지
                DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;

                if (rowState == DataRowState.Added)
                {
                    if (e.ColName == "code_type")
                    {
                        // 중복 체크및 유효성 검사를 위한 타겟
                        string target = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");

                        //                        cmdText = @"SELECT 'X'
                        //                                      FROM CPL0108
                        //                                     WHERE CODE_TYPE = :f_code_type";

                        //                        BindVarCollection bindVar = new BindVarCollection();
                        //                        bindVar.Add("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));

                        if (target.Trim().Length == 0)
                        {
                            msg = (NetInfo.Language == LangMode.Ko ? "코드를 입력해주세요." : "コードを入力してください。");
                            XMessageBox.Show(msg);
                        }
                        else
                        {
                            //if (Service.ExecuteScalar(cmdText, bindVar) != null)
                            //{
                            //    msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                            //        : "は既に登録されているコード類型です。ご確認ください。");
                            //    XMessageBox.Show(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type") +
                            //        msg, "確認", MessageBoxButtons.OK);
                            //    grdMaster.SetItemValue(e.RowNumber, "code_type", string.Empty);
                            //}
                            //else
                            //{
                            //    // 유효한 값
                            //}

                            // updated by Cloud
                            CPL0108U01LayDupMArgs args = new CPL0108U01LayDupMArgs();
                            args.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                            CPL0108U01StringResult res = CloudService.Instance.Submit<CPL0108U01StringResult, CPL0108U01LayDupMArgs>(args);

                            if (res.ExecutionStatus == ExecutionStatus.Success && res.ResStr != string.Empty)
                            {
                                msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                                    : "は既に登録されているコード類型です。ご確認ください。");
                                XMessageBox.Show(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type") +
                                    msg, "確認", MessageBoxButtons.OK);
                                grdMaster.SetItemValue(e.RowNumber, "code_type", string.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#01-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }

        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                string cmdText = string.Empty;    // 중복 체크를 위한 쿼리문
                string msg = string.Empty;    // 에러 검출시 메세지
                DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;

                if (rowState == DataRowState.Added)
                {
                    if (e.ColName == "code")
                    {
                        // 중복 체크및 유효성 검사를 위한 타겟
                        string target = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code");

                        //                        cmdText = @"SELECT 'X'
                        //                                      FROM CPL0109
                        //                                     WHERE CODE  = :f_code
                        //                                       AND CODE_TYPE = :f_code_type";

                        //                        BindVarCollection bindVar = new BindVarCollection();
                        //                        bindVar.Add("f_code", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code"));
                        //                        bindVar.Add("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));

                        if (target.Trim().Length == 0)
                        {
                            msg = (NetInfo.Language == LangMode.Ko ? "코드를 입력해주세요." : "コードを入力してください。");
                            XMessageBox.Show(msg);
                        }
                        else
                        {
                            //if (Service.ExecuteScalar(cmdText, bindVar) != null)
                            //{
                            //    msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                            //        : "は既に登録されているコード類型です。ご確認ください。");
                            //    XMessageBox.Show(this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code") +
                            //        msg, "確認", MessageBoxButtons.OK);
                            //    grdDetail.SetItemValue(e.RowNumber, "code", string.Empty);
                            //}
                            //else
                            //{
                            //    // 유효한 값
                            //}

                            // updated by Cloud
                            CPL0108U01LayDupDArgs args = new CPL0108U01LayDupDArgs();
                            args.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                            args.Code = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code");
                            CPL0108U01StringResult res = CloudService.Instance.Submit<CPL0108U01StringResult, CPL0108U01LayDupDArgs>(args);

                            if (res.ExecutionStatus == ExecutionStatus.Success && res.ResStr != string.Empty)
                            {
                                msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                                    : "は既に登録されているコード類型です。ご確認ください。");
                                XMessageBox.Show(this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code") +
                                    msg, "確認", MessageBoxButtons.OK);
                                grdDetail.SetItemValue(e.RowNumber, "code", string.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#02-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }

        private void txtCodeType_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            try
            {
                if (!this.grdMaster.QueryLayout(false)) throw new Exception();
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#03-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }

        private void txtCodeTypeName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            try
            {
                if (!this.grdMaster.QueryLayout(false)) throw new Exception();
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#03-2\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }

        private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
            CheckUpdateMasterData();
            if (this.grdMaster.GetItemString(e.CurrentRow, "code_type") == "PRINT")
            {
                this.btnPrintName.Visible = true;
            }
            else
            {
                this.btnPrintName.Visible = false;
            }

            // Insert가 아니면 Detail값에 Code_type 설정
            DataRowState rowState = grdMaster.LayoutTable.Rows[grdMaster.CurrentRowNumber].RowState;

            if (rowState != DataRowState.Added)
            {
                object objCodeType = null;
                objCodeType = grdMaster.GetItemValue(grdMaster.CurrentRowNumber, "code_type");

                if (objCodeType != null)
                {
                    grdDetail.SetItemValue(grdDetail.CurrentRowNumber, "code_type", objCodeType);
                }
            }
        }

        private void btnPrintName_Click(object sender, System.EventArgs e)
        {
            if (this.grdDetail.RowCount > 0)
            {
                string printName = String.Empty;
                try
                {
                    RegistryKey regKey = Registry.CurrentUser;
                    string detailName = "Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows";
                    RegistryKey rk = regKey.OpenSubKey(detailName, true);
                    printName = rk.GetValue("Device").ToString();
                }
                catch (Exception ex)
                {
                    Service.ErrWriteLog(string.Format("Message: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
                }
                finally
                {
                    this.grdDetail.SetItemValue(this.grdDetail.CurrentRowNumber, "code_name", printName);
                }
            }
        }

        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_code_type", this.txtCodeType.GetDataValue());
            this.grdMaster.SetBindVarValue("f_code_type_name", this.txtCodeTypeName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                switch (e.Func)
                {
                    case FunctionType.Update:
                        e.IsBaseCall = false;
                        e.IsSuccess = false;


                        #region deleted by Cloud
                        //Service.BeginTransaction();
                        //if (!this.grdMaster.SaveLayout() || !this.grdDetail.SaveLayout())
                        //{
                        //    throw new Exception();
                        //}
                        //else
                        //{
                        //    Service.CommitTransaction();
                        //}
                        #endregion

                        // updated by Cloud
                        string errMsg = string.Empty;
                        CPL0108U01SaveLayoutArgs args = new CPL0108U01SaveLayoutArgs();
                        args.UserId = UserInfo.UserID;
                        args.GrdMstItem = GetGrdMasterForSaveLayout(out errMsg);
                        args.HospCode = mHospCode;
                        if (!TypeCheck.IsNull(errMsg))
                        {
                            XMessageBox.Show(errMsg, Properties.Resources.MSG005_CAP,
                                    MessageBoxIcon.Warning);

                            return;
                        }
                        args.GrdDetailItem = GetGrdDetailForSaveLayout(out errMsg);
                        if (!TypeCheck.IsNull(errMsg))
                        {
                            XMessageBox.Show(errMsg, Properties.Resources.MSG005_CAP,
                                    MessageBoxIcon.Warning);

                            return;
                        }

                        // No change?
                        if (args.GrdMstItem.Count == 0 && args.GrdDetailItem.Count == 0) return;
                        UpdateResult res = CloudService.Instance.Submit<UpdateResult, CPL0108U01SaveLayoutArgs>(args);

                        if (res.ExecutionStatus == ExecutionStatus.Success)
                        {
                            e.IsSuccess = true;
                            XMessageBox.Show(Properties.Resources.MSG002_MSG, Properties.Resources.MSG002_CAP,
                                MessageBoxIcon.Information);
                            btnList.PerformClick(FunctionType.Query);
                        }
                        else
                        {
                            XMessageBox.Show(Resources.MSG003_MSG, Properties.Resources.MSG005_CAP,
                                MessageBoxIcon.Warning);
                        }




                        break;

                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                //Service.RollbackTransaction();
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#07-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }

        #endregion

        #region Methods(private)

        private bool SaveValid()
        {
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetItemString(i, "code_type").Trim().Equals(string.Empty))
                {
                    return false;
                }
            }

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetItemString(i, "code").Trim().Equals(string.Empty))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAdminGroup()
        {
            if (/*UserInfo.UserGroup.ToString() == LblADMIN ||*/ UserInfo.AdminType == AdminType.SuperAdmin) return true;
            return false;
        }

        private void CheckUpdateMasterData()
        {
            if (!IsAdminGroup() && this.CurrMQLayout == grdMaster) SetEnableButtonListCustomize(false);
            else SetEnableButtonListCustomize(true);
        }

        private void SetEnableButtonListCustomize(bool isEnable)
        {
            this.btnList.SetEnabled(FunctionType.Insert, isEnable);
            this.btnList.SetEnabled(FunctionType.Delete, isEnable);
            this.btnList.SetEnabled(FunctionType.Update, isEnable);
        }

        #endregion

        // deleted by Cloud
        #region [ XSavePerformer ]
        //        public class XSavePerformer : ISavePerformer
        //        {
        //            CPL0108U01 parent = null;
        //            bool result = true;
        //            string cmdText = string.Empty;

        //            public XSavePerformer(CPL0108U01 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                // TODO:  XSavePerformer.Execute 구현을 추가합니다.
        //                try
        //                {
        //                    item.BindVarList.Add("q_user_id", UserInfo.UserID);
        //                    item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

        //                    // Master Grid 저장 모듈
        //                    if (callerID.Equals('1'))
        //                    {
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"
        //                                    INSERT INTO CPL0108 (
        //                                        SYS_DATE,              SYS_ID,                   UPD_DATE,              UPD_ID,
        //                                        CODE_TYPE,             CODE_TYPE_NAME,           HOSP_CODE,             ADMIN_GUBUN
        //                                    ) 
        //                                    VALUES (
        //                                        SYSDATE,               :q_user_id,               SYSDATE,              :q_user_id,
        //                                        :f_code_type,          :f_code_type_name,        :f_hosp_code,         :f_admin_gubun )";
        //                                break;
        //                            case DataRowState.Modified:
        //                                cmdText = @"
        //                                        UPDATE CPL0108
        //                                           SET UPD_ID          = :q_user_id
        //                                             , UPD_DATE        = SYSDATE
        //                                             , CODE_TYPE_NAME  = :f_code_type_name
        //                                             , ADMIN_GUBUN     = :f_admin_gubun
        //                                         WHERE CODE_TYPE       = :f_code_type
        //                                           AND HOSP_CODE       = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted:
        //                                cmdText = @"
        //                                        DECLARE
        //                                            RESULT   VARCHAR2(1);
        //                                            BEGIN
        //                                                RESULT := 'N';
        //                                                FOR X IN (SELECT 'X' 
        //                                                            FROM CPL0109
        //                                                            WHERE CODE_TYPE = :f_code_type
        //                                                              AND HOSP_CODE = :f_hosp_code) LOOP
        //                                                    RESULT := 'Y';
        //                                                END LOOP;
        //                                                 
        //                                            DELETE CPL0108
        //                                             WHERE CODE_TYPE = :f_code_type
        //                                               AND HOSP_CODE = :f_hosp_code;
        //                                            IF RESULT = 'Y' THEN
        //                                                DELETE CPL0109
        //                                                 WHERE CODE_TYPE = :f_code_type
        //                                                   AND HOSP_CODE = :f_hosp_code;
        //                                            END IF;
        //                                            END;";
        //                                cmdText = cmdText.Replace("\r", " ");
        //                                break;
        //                        }
        //                    }
        //                    // Detail Grid 저장 모듈
        //                    else if (callerID.Equals('2'))
        //                    {
        //                        switch (item.RowState)
        //                        {
        //                            case DataRowState.Added:
        //                                cmdText = @"
        //                                    INSERT INTO CPL0109 (
        //                                        SYS_DATE,        SYS_ID,          UPD_DATE,      UPD_ID,
        //                                        CODE_TYPE,       CODE,            CODE_NAME,
        //                                        CODE_NAME_RE,    SYSTEM_GUBUN,    HOSP_CODE,
        //                                        CODE_VALUE
        //                                    ) 
        //                                    VALUES (
        //                                        SYSDATE,         :q_user_id,      SYSDATE,       :q_user_id,
        //                                        :f_code_type,    :f_code,         :f_code_name,
        //                                        :f_code_name_re, 'CPL',           :f_hosp_code,
        //                                        :f_code_value )";
        //                                break;
        //                            case DataRowState.Modified:
        //                                cmdText = @"
        //                                         UPDATE CPL0109
        //                                            SET UPD_ID            = :q_user_id
        //                                              , UPD_DATE          = SYSDATE
        //                                              , CODE_NAME         = :f_code_name
        //                                              , CODE_NAME_RE      = :f_code_name_re
        //                                              , SYSTEM_GUBUN      = 'CPL'
        //                                              , CODE_VALUE        = :f_code_value
        //                                          WHERE CODE_TYPE         = :f_code_type
        //                                            AND CODE              = :f_code
        //                                            AND HOSP_CODE         = :f_hosp_code";
        //                                break;
        //                            case DataRowState.Deleted:
        //                                cmdText = @"
        //                                        DELETE CPL0109
        //                                         WHERE CODE_TYPE = :f_code_type
        //                                           AND CODE      = :f_code
        //                                           AND HOSP_CODE = :f_hosp_code";
        //                                break;
        //                        }
        //                    }
        //                    // 뭐야 이건.
        //                    else
        //                    {
        //                        result = false;
        //                    }

        //                    result = Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //                    if (!result)
        //                        return result;

        //                    //OCS0116에 자동 반영
        //                    if (callerID == '2')
        //                    {
        //                        if (item.BindVarList["f_code_type"].VarValue == "04") //검체코드
        //                        {
        //                            cmdText = @"SELECT 'Y'
        //                                      FROM DUAL
        //                                     WHERE EXISTS ( SELECT 'X'
        //                                                      FROM OCS0116
        //                                                     WHERE HOSP_CODE     = :f_hosp_code
        //                                                       AND SPECIMEN_CODE = :f_code
        //                                                       AND SPECIMEN_GUBUN = 'CPL'            )";

        //                            object dup_yn = Service.ExecuteScalar(cmdText, item.BindVarList);


        //                            cmdText = @"INSERT INTO OCS0116 
        //                                         ( SYS_DATE         , SYS_ID        , UPD_DATE      , UPD_ID        , HOSP_CODE
        //                                         , SPECIMEN_GUBUN   , SPECIMEN_CODE , SPECIMEN_NAME )
        //                                    VALUES
        //                                         ( SYSDATE          , :q_user_id    , SYSDATE       , :q_user_id    , :f_hosp_code 
        //                                         , 'CPL'            , :f_code       , :f_code_name  )";

        //                            if (!TypeCheck.IsNull(dup_yn))
        //                            {
        //                                if (dup_yn.ToString() == "Y")
        //                                {
        //                                    cmdText = @"UPDATE OCS0116
        //                                            SET UPD_ID            = :q_user_id
        //                                              , UPD_DATE          = SYSDATE
        //                                              , SPECIMEN_NAME     = :f_code_name
        //                                          WHERE HOSP_CODE         = :f_hosp_code 
        //                                            AND SPECIMEN_CODE     = :f_code
        //                                            AND SPECIMEN_GUBUN    = 'CPL'             ";
        //                                }
        //                            }

        //                            if (item.RowState == DataRowState.Added || item.RowState == DataRowState.Modified)
        //                            {
        //                                Service.ExecuteNonQuery(cmdText, item.BindVarList);
        //                            }
        //                        }
        //                    }
        //                }
        //                catch (Exception)
        //                {
        //                    result = false;
        //                }

        //                return result;
        //            }
        //        }
        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            // grdDetail
            grdDetail.ParamList = new List<string>(new string[] { "f_code_type" });
            grdDetail.ExecuteQuery = GetGrdDetail;

            // grdMaster
            grdMaster.ParamList = new List<string>(new string[] { "f_code_type", "f_code_type_name" });
            grdMaster.ExecuteQuery = GetGrdMaster;

            // xEditGridCell7
            grdMaster.SetComboItems("admin_gubun", Utility.ConvertToDataTable(GetCboAdmGubun()), "code_name", "code");
            // HospCode
            this.layCommon.ParamList = new List<string>(new String[] { "f_hosp_code" });
            this.fwkCommon.ExecuteQuery = LoadDataFwkCommon;
            this.layCommon.ExecuteQuery = LoadDataLayCommon;
        }
        #endregion

        #region GetGrdMaster
        /// <summary>
        /// GetGrdMaster
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdMaster(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL0108U01GrdMasterArgs args = new CPL0108U01GrdMasterArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            args.CodeTypeName = bvc["f_code_type_name"].VarValue;
            args.HospCode = mHospCode;
            CPL0108U01GrdMasterResult res = CloudService.Instance.Submit<CPL0108U01GrdMasterResult, CPL0108U01GrdMasterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdMstItem.ForEach(delegate(CPL0108U01GrdMasterItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.CodeTypeName,
                        item.AdminGubun,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdDetail
        /// <summary>
        /// GetGrdDetail
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDetail(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            CPL0108U01GrdDetailArgs args = new CPL0108U01GrdDetailArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            args.HospCode = mHospCode;
            CPL0108U01GrdDetailResult res = CloudService.Instance.Submit<CPL0108U01GrdDetailResult, CPL0108U01GrdDetailArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdDetailItem.ForEach(delegate(CPL0108U01GrdDetailInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.Code,
                        item.CodeName,
                        item.CodeNameRe,
                        item.SystemGubun,
                        item.CodeValue,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetCboAdmGubun
        /// <summary>
        /// GetCboAdmGubun
        /// </summary>
        /// <returns></returns>
        private List<ComboListItemInfo> GetCboAdmGubun()
        {
            List<ComboListItemInfo> lstData = new List<ComboListItemInfo>();

            //ComboResult res = CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_CBO_ADMIN_GUBUN,
            //    new ComboAdminGubunArgs("ADMIN_GUBUN"), delegate(ComboResult r)
            //    {
            //        return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
            //    });
            ComboResult res = CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(
                new ComboAdminGubunArgs("ADMIN_GUBUN"), delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                lstData = res.ComboItem;
            }

            return lstData;
        }
        #endregion

        #region GetGrdMasterForSaveLayout

        /// <summary>
        /// GetGrdMasterForSaveLayout
        /// </summary>
        /// <returns></returns>
        //private string errMSg;
        private List<CPL0108U01GrdMasterItemInfo> GetGrdMasterForSaveLayout(out string errMsg)
        {
            errMsg = string.Empty;

            List<CPL0108U01GrdMasterItemInfo> lstData = new List<CPL0108U01GrdMasterItemInfo>();

            // for insert/update
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }

                if (TypeCheck.IsNull(grdMaster.GetItemString(i, "code_type")))
                {
                    errMsg = Properties.Resources.MSG007_MSG;
                    return lstData;
                }
                if (TypeCheck.IsNull(grdMaster.GetItemString(i, "code_type_name")))
                {
                    errMsg = Properties.Resources.MSG006_MSG;
                    return lstData;
                }

                CPL0108U01GrdMasterItemInfo item = new CPL0108U01GrdMasterItemInfo();
                item.AdminGubun = grdMaster.GetItemString(i, "admin_gubun");
                item.CodeType = grdMaster.GetItemString(i, "code_type");
                item.CodeTypeName = grdMaster.GetItemString(i, "code_type_name");
                item.RowState = grdMaster.GetRowState(i).ToString();


                lstData.Add(item);
            }

            // for delete
            if (null != grdMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                {
                    CPL0108U01GrdMasterItemInfo item = new CPL0108U01GrdMasterItemInfo();
                    item.AdminGubun = Convert.ToString(dr["admin_gubun"]);
                    item.CodeType = Convert.ToString(dr["code_type"]);
                    item.CodeTypeName = Convert.ToString(dr["code_type_name"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region GetGrdDetailForSaveLayout
        /// <summary>
        /// GetGrdDetailForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<CPL0108U01GrdDetailInfo> GetGrdDetailForSaveLayout(out string errMsg)
        {
            errMsg = "";
            List<CPL0108U01GrdDetailInfo> lstData = new List<CPL0108U01GrdDetailInfo>();

            // For insert/update
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (TypeCheck.IsNull(grdDetail.GetItemString(i, "code")))
                {
                    errMsg = Properties.Resources.MSG007_MSG;
                    return lstData;
                }
                // Skip unchanged rows
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;

                CPL0108U01GrdDetailInfo item = new CPL0108U01GrdDetailInfo();
                item.Code = grdDetail.GetItemString(i, "code");
                item.CodeName = grdDetail.GetItemString(i, "code_name");
                item.CodeNameRe = grdDetail.GetItemString(i, "code_name_re");
                item.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                item.CodeValue = grdDetail.GetItemString(i, "code_value");
                item.SystemGubun = grdDetail.GetItemString(i, "system_gubun");
                item.RowState = grdDetail.GetRowState(i).ToString();


                lstData.Add(item);
            }

            // For delete
            if (null != grdDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                {
                    CPL0108U01GrdDetailInfo item = new CPL0108U01GrdDetailInfo();
                    item.Code = Convert.ToString(dr["code"]);
                    item.CodeName = Convert.ToString(dr["code_name"]);
                    item.CodeNameRe = Convert.ToString(dr["code_name_re"]);
                    item.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                    item.CodeValue = Convert.ToString(dr["code_value"]);
                    item.SystemGubun = Convert.ToString(dr["system_gubun"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region HospCode
        private List<object[]> LoadDataLayCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UValidateFwkHospitalArgs args = new ADM103UValidateFwkHospitalArgs();
            args.HospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            ADM103UValidateFwkHospitalResult result = CloudService.Instance.Submit<ADM103UValidateFwkHospitalResult, ADM103UValidateFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                res.Add(new object[]
                {
                    result.HospName
                });
            }
            return res;
        }

        private List<object[]> LoadDataFwkCommon(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            ADM103UGetFwkHospitalArgs args = new ADM103UGetFwkHospitalArgs();
            ADM103UGetFwkHospitalResult result = CloudService.Instance.Submit<ADM103UGetFwkHospitalResult, ADM103UGetFwkHospitalArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in result.HospList)
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
        private void layCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
        }

        private void fwkCommon_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layCommon.SetBindVarValue("f_hosp_code", mHospCode);
        }
        #endregion

        private void CPL0108U01_Load(object sender, EventArgs e)
        {
            if (UserInfo.AdminType == AdminType.SuperAdmin)
            {
                this.mHospCode = fbxHospitalCode.Text;
            }
            else
            {
                this.mHospCode = UserInfo.HospCode;
                xLabel3.Visible = false;
                fbxHospitalCode.Visible = false;
                dbxHospName.Visible = false;

            }
        }

        private void fbxHospitalCode_DataValidating(object sender, DataValidatingEventArgs e)
        {
            this.mHospCode = fbxHospitalCode.Text;

            this.layCommon.QueryLayout();

            this.grdMaster.QueryLayout(true);
        }

        private void grdDetail_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

        private void grdMaster_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

        #region checkValidate


        //private bool checkValidate()
        //{
        //    Msg = "";
        //    List<CPL0108U01GrdMasterItemInfo> listInfoMaster = GetGrdMasterForSaveLayout();
        //    if (listInfoMaster.Count > 0)
        //    {
        //        foreach (CPL0108U01GrdMasterItemInfo info in listInfoMaster)
        //        {
        //            if (info.CodeType == "")
        //            {
        //                Msg = Properties.Resources.MSG007_MSG;
        //                return false;

        //            }
        //            if (info.CodeTypeName == "")
        //            {
        //                Msg = Properties.Resources.MSG006_MSG;
        //                return false;

        //            }


        //        }
        //    }

        //    List<CPL0108U01GrdDetailInfo> listInfoDetail = GetGrdDetailForSaveLayout();
        //    if (listInfoDetail.Count > 0)
        //    {
        //        foreach (CPL0108U01GrdDetailInfo info in listInfoDetail)
        //        {
        //            if (info.Code == "")
        //            {
        //                Msg = Properties.Resources.MSG008_MSG;
        //                return false;

        //            }



        //        }
        //    }




        //    return true;
        //}
        #endregion

        #endregion
    }
}

