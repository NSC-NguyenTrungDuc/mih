#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using Microsoft.Win32;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Schs;
using IHIS.CloudConnector.Contracts.Models.Schs;
using IHIS.CloudConnector.Contracts.Results.Schs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Utility;
using IHIS.CloudConnector.Contracts.Models.System;
#endregion

namespace IHIS.SCHS
{
    /// <summary>
    /// SCH0109U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class SCH0109U01 : IHIS.Framework.XScreen
    {
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
        private IHIS.Framework.SingleLayout layDupM;
        private IHIS.Framework.SingleLayout layDupD;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private SingleLayoutItem singleLayoutItem1;
        private SingleLayoutItem singleLayoutItem2;
        private XEditGridCell xEditGridCell8;
        private XEditGridCell xEditGridCell9;
        private XEditGridCell xEditGridCell10;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

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

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SCH0109U01));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell9 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell10 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtCodeTypeName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtCodeType = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.layDupM = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem1 = new IHIS.Framework.SingleLayoutItem();
            this.layDupD = new IHIS.Framework.SingleLayout();
            this.singleLayoutItem2 = new IHIS.Framework.SingleLayoutItem();
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
            this.xEditGridCell7,
            this.xEditGridCell9});
            this.grdDetail.ColPerLine = 5;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 6;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
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
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 253;
            this.xEditGridCell5.Col = 3;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 40;
            this.xEditGridCell6.CellName = "code_name2";
            this.xEditGridCell6.CellWidth = 113;
            this.xEditGridCell6.Col = 5;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            this.xEditGridCell6.ImeMode = IHIS.Framework.ColumnImeMode.KatakanaHalf;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code2";
            this.xEditGridCell7.Col = 2;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xEditGridCell9
            // 
            this.xEditGridCell9.CellName = "seq";
            this.xEditGridCell9.CellWidth = 33;
            this.xEditGridCell9.Col = 4;
            this.xEditGridCell9.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell9, "xEditGridCell9");
            this.xEditGridCell9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell8,
            this.xEditGridCell10});
            this.grdMaster.ColPerLine = 4;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 5;
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
            this.xEditGridCell1.CellLen = 20;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 120;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 205;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "admin_gubun";
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            this.xEditGridCell8.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell8.UserSQL = resources.GetString("xEditGridCell8.UserSQL");
            // 
            // xEditGridCell10
            // 
            this.xEditGridCell10.CellLen = 200;
            this.xEditGridCell10.CellName = "remark";
            this.xEditGridCell10.CellWidth = 33;
            this.xEditGridCell10.Col = 4;
            this.xEditGridCell10.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell10.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell10, "xEditGridCell10");
            this.xEditGridCell10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.xPanel3.Controls.Add(this.btnList);
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Font = null;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Font = null;
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
            this.xPanel2.Controls.Add(this.txtCodeTypeName);
            this.xPanel2.Controls.Add(this.xLabel2);
            this.xPanel2.Controls.Add(this.txtCodeType);
            this.xPanel2.Controls.Add(this.xLabel1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Font = null;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtCodeTypeName
            // 
            this.txtCodeTypeName.AccessibleDescription = null;
            this.txtCodeTypeName.AccessibleName = null;
            resources.ApplyResources(this.txtCodeTypeName, "txtCodeTypeName");
            this.txtCodeTypeName.BackgroundImage = null;
            this.txtCodeTypeName.Font = null;
            this.txtCodeTypeName.Name = "txtCodeTypeName";
            this.txtCodeTypeName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeTypeName_DataValidating);
            // 
            // xLabel2
            // 
            this.xLabel2.AccessibleDescription = null;
            this.xLabel2.AccessibleName = null;
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Font = null;
            this.xLabel2.Image = null;
            this.xLabel2.Name = "xLabel2";
            // 
            // txtCodeType
            // 
            this.txtCodeType.AccessibleDescription = null;
            this.txtCodeType.AccessibleName = null;
            resources.ApplyResources(this.txtCodeType, "txtCodeType");
            this.txtCodeType.BackgroundImage = null;
            this.txtCodeType.Font = null;
            this.txtCodeType.Name = "txtCodeType";
            this.txtCodeType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeType_DataValidating);
            // 
            // xLabel1
            // 
            this.xLabel1.AccessibleDescription = null;
            this.xLabel1.AccessibleName = null;
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Font = null;
            this.xLabel1.Image = null;
            this.xLabel1.Name = "xLabel1";
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "code";
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            // 
            // layDupM
            // 
            this.layDupM.ExecuteQuery = null;
            this.layDupM.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem1});
            this.layDupM.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupM.ParamList")));
            // 
            // singleLayoutItem1
            // 
            this.singleLayoutItem1.DataName = "dup_yn";
            // 
            // layDupD
            // 
            this.layDupD.ExecuteQuery = null;
            this.layDupD.LayoutItems.AddRange(new IHIS.Framework.SingleLayoutItem[] {
            this.singleLayoutItem2});
            this.layDupD.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("layDupD.ParamList")));
            this.layDupD.QueryStarting += new System.ComponentModel.CancelEventHandler(this.layDupD_QueryStarting);
            // 
            // singleLayoutItem2
            // 
            this.singleLayoutItem2.DataName = "dup_yn";
            // 
            // SCH0109U01
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoCheckInputLayoutChanged = true;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.xPanel1);
            this.Font = null;
            this.Name = "SCH0109U01";
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
        /// SCH0109U01
        /// </summary>
        public SCH0109U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //this.grdMaster.SavePerformer = new XSavePerformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            //this.SaveLayoutList.Add(this.grdMaster);
            //this.SaveLayoutList.Add(this.grdDetail);

            // updated by Cloud
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
            base.OnLoad (e);
            this.grdDetail.SetRelationKey("code_type","code_type");
            this.grdDetail.SetRelationTable("cpl0109");
            this.CurrMQLayout = this.grdMaster;

            this.grdMaster.QueryLayout(true);
        }

        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;
            // 입력 버튼이 클릭 되었을 때만 체크
            if ( rowState == DataRowState.Added )
            {
                // 입력된 셀이 코드타입 컬럼이라면,
                if ( e.ColName == "code_type" )
                {
                    #region deleted by Cloud
                    //// 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
                    //this.layDupM.QueryLayout();
                    //if ( this.layDupM.GetItemValue("dup_yn").ToString() == "Y" )
                    //{
                    //    string msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                    //        : "はもう存在するコード類型です。");
                    //    XMessageBox.Show( this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber,"code_type")  +
                    //        msg,"確認", MessageBoxButtons.OK );
                    //    e.Cancel = true;
                    //}
                    #endregion

                    // updated by Cloud
                    SCH0109U01LayDupMArgs args = new SCH0109U01LayDupMArgs();
                    args.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                    SCH0109U01StringResult res = CloudService.Instance.Submit<SCH0109U01StringResult, SCH0109U01LayDupMArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.ResStr == "Y")
                    {
                        string msg = Properties.Resources.MSG1;
                        XMessageBox.Show(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type") +
                            msg, Properties.Resources.MSGCAP1, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;
            //입력 버튼이 클릭 되었을 때만 체크
            if ( rowState == DataRowState.Added )
            {
                // 입력된 셀이 코드 컬럼이면,
                if ( e.ColName == "code" )
                {
                    #region deleted by Cloud
                    //this.layDupD.QueryLayout();
                    //if (this.layDupD.GetItemValue("dup_yn").ToString() == "Y")
                    //{
                    //    string msg = (NetInfo.Language == LangMode.Ko ? "이미 존재하는 코드유형입니다. 다시 정의해 주세요."
                    //        : "はもう存在するコード類型です。");
                    //    XMessageBox.Show( this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber,"code") +
                    //        msg,"確認", MessageBoxButtons.OK );
                    //    e.Cancel = true;
                    //}
                    #endregion

                    // updated by Cloud
                    SCH0109U01LayDupDArgs args = new SCH0109U01LayDupDArgs();
                    args.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                    args.Code = this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code");
                    SCH0109U01StringResult res = CloudService.Instance.Submit<SCH0109U01StringResult, SCH0109U01LayDupDArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.ResStr == "Y")
                    {
                        string msg = Properties.Resources.MSG2;
                        XMessageBox.Show(this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code") +
                            msg, Properties.Resources.MSGCAP2, MessageBoxButtons.OK);
                        e.Cancel = true;
                    }
                }
            }
        }

        private void txtCodeType_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.txtCodeTypeName.SetDataValue("");
            this.grdMaster.QueryLayout(false);
        }

        private void txtCodeTypeName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            this.grdMaster.QueryLayout(false);
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_code_type", this.txtCodeType.GetDataValue());
            this.grdMaster.SetBindVarValue("f_code_type_name", this.txtCodeTypeName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private void layDupD_QueryStarting(object sender, CancelEventArgs e)
        {
            this.layDupD.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.layDupD.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
            this.layDupD.SetBindVarValue("f_code", this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code"));

        }

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    if (this.CurrMQLayout == this.grdDetail)
                    {
                        if (this.grdMaster.RowCount > 0)
                        {
                            int rowNum = this.grdDetail.InsertRow(-1);
                            this.grdDetail.SetFocusToItem(rowNum, "code");
                        }
                    }
                    else
                    {
                        int rowNum = this.grdMaster.InsertRow(-1);
                    }
                    break;

                case FunctionType.Delete:

                    if (this.CurrMQLayout != this.grdDetail)
                    {
                        e.IsBaseCall = false;
                        return;
                    }
                    break;

                // updated by Cloud
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    e.IsSuccess = false;

                    SCH0109U01SaveLayoutArgs args = new SCH0109U01SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.GrdMstItem = GetGrdMasterForSaveLayout();
                    args.GrdDetailItem = GetGrdDetailForSaveLayout();
                    // No change?
                    if (args.GrdMstItem.Count == 0 && args.GrdDetailItem.Count == 0) return;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, SCH0109U01SaveLayoutArgs>(args);

                    if (res.ExecutionStatus == ExecutionStatus.Success && res.Result)
                    {
                        e.IsSuccess = true;
                        btnList.PerformClick(FunctionType.Query);
                    }

                    break;

                default:
                    break;
            }
        }

        #endregion

        // deleted by Cloud
        #region XSavePerformer
//        private class XSavePerformer : ISavePerformer
//        {
//            private SCH0109U01 parent;

//            public XSavePerformer(SCH0109U01 parent)
//            {
//                this.parent = parent;
//            }

//            public bool Execute(char callerID, RowDataItem item)
//            {
//                string cmdText = "";

//                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
//                item.BindVarList.Add("q_user_id", UserInfo.UserID);

//                switch (callerID)
//                { 
//                    case '1':
//                        switch (item.RowState)
//                        { 
//                            case DataRowState.Added:

//                                cmdText = @"INSERT INTO SCH0108 
//                                                 ( SYS_DATE     , SYS_ID          
//                                                 , UPD_DATE     , UPD_ID           , HOSP_CODE
//                                                 , CODE_TYPE    , CODE_TYPE_NAME   , ADMIN_GUBUN
//                                                 , REMARK ) 
//                                            VALUES 
//                                                 ( SYSDATE      , :q_user_id        
//                                                 , SYSDATE      , :q_user_id        , :f_hosp_code
//                                                 , :f_code_type , :f_code_type_name , :f_admin_gubun
//                                                 , :f_remark )";
//                                break;

//                            case DataRowState.Modified:

//                                cmdText = @"UPDATE SCH0108
//                                               SET UPD_ID          = :q_user_id
//                                                 , UPD_DATE        = SYSDATE
//                                                 , CODE_TYPE_NAME  = :f_code_type_name
//                                                 , ADMIN_GUBUN     = :f_admin_gubun
//                                                 , REMARK          = :f_remark
//                                             WHERE HOSP_CODE       = :f_hosp_code
//                                               AND CODE_TYPE       = :f_code_type";

//                                break;

//                            case DataRowState.Deleted:

//                                cmdText = @"DECLARE
//                                               RESULT   VARCHAR2(1);
//                                            BEGIN
//                                               RESULT := 'N';
//                                               FOR X IN (SELECT 'X' 
//                                                           FROM SCH0109
//                                                          WHERE HOSP_CODE = :f_hosp_code
//                                                            AND CODE_TYPE = :f_code_type) LOOP
//                                                   RESULT := 'Y';
//                                               END LOOP;
//                                               
//                                               IF RESULT = 'Y' THEN
//                                                  DELETE SCH0109
//                                                   WHERE HOSP_CODE = :f_hosp_code
//                                                     AND CODE_TYPE = :f_code_type;
//                                               END IF;
//
//                                               DELETE SCH0108
//                                                WHERE HOSP_CODE = :f_hosp_code
//                                                  AND CODE_TYPE = :f_code_type;
//                                            END; ";

//                                break;
//                        }
//                        break;

//                    case '2':
//                        switch (item.RowState)
//                        {
//                            case DataRowState.Added:
//                                cmdText = @"INSERT INTO SCH0109 
//                                                 ( SYS_DATE     , SYS_ID        
//                                                 , UPD_DATE     , UPD_ID        , HOSP_CODE
//                                                 , CODE_TYPE    , CODE          , CODE_NAME
//                                                 , CODE_NAME2   , CODE2
//                                                 , SEQ                          ) 
//                                            VALUES 
//                                                 ( SYSDATE      , :q_user_id
//                                                 , SYSDATE      , :q_user_id    , :f_hosp_code
//                                                 , :f_code_type , :f_code       , :f_code_name
//                                                 , :f_code_name2, :f_code2      
//                                                 , :f_seq                          )";
//                                break;

//                            case DataRowState.Modified:
//                                cmdText = @"UPDATE SCH0109
//                                               SET SYS_ID     = :q_user_id
//                                                 , UPD_DATE   = SYSDATE
//                                                 , CODE_NAME  = :f_code_name
//                                                 , CODE_NAME2 = :f_code_name2
//                                                 , CODE2      = :f_code2
//                                                 , SEQ        = :f_seq
//                                             WHERE HOSP_CODE  = :f_hosp_code
//                                               AND CODE_TYPE  = :f_code_type
//                                               AND CODE       = :f_code";
//                                break;

//                            case DataRowState.Deleted:
//                                cmdText = @"DELETE SCH0109
//                                             WHERE HOSP_CODE = :f_hosp_code
//                                               AND CODE_TYPE = :f_code_type
//                                               AND CODE      = :f_code";

//                                break;
//                        }
//                        break;
//                }
//                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
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
            // grdMaster
            grdMaster.ParamList = new List<string>(new string[] { "f_code_type", "f_code_type_name" });
            grdMaster.ExecuteQuery = GetGrdMaster;

            // xEditGridCell8
            //xEditGridCell8.ExecuteQuery = GetCboAdmGubun;
            grdMaster.SetComboItems("admin_gubun", Utility.ConvertToDataTable(GetCboAdmGubun()), "code_name", "code");

            // grdDetail
            grdDetail.ParamList = new List<string>(new string[] { "f_code_type" });
            grdDetail.ExecuteQuery = GetGrdDetail;
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

            SCH0109U01GrdMasterArgs args = new SCH0109U01GrdMasterArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            args.CodeTypeName = bvc["f_code_type_name"].VarValue;
            SCH0109U01GrdMasterResult res = CloudService.Instance.Submit<SCH0109U01GrdMasterResult, SCH0109U01GrdMasterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdMstItem.ForEach(delegate(SCH0109U01GrdMasterInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.CodeTypeName,
                        item.AdminGubun,
                        item.Remark,
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
        /// <param name="bvc"></param>
        /// <returns></returns>
        private List<ComboListItemInfo> GetCboAdmGubun()
        {
            IList<object[]> lObj = new List<object[]>();

            ComboAdminGubunArgs args = new ComboAdminGubunArgs();
            args.CodeType = "ADMIN_GUBUN";
            ComboResult res = CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(args, delegate(ComboResult r)
                {
                    return r.ExecutionStatus == ExecutionStatus.Success && r.ComboItem.Count > 0;
                });

            return res.ComboItem;
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

            SCH0109U01GrdDetailArgs args = new SCH0109U01GrdDetailArgs();
            args.CodeType = bvc["f_code_type"].VarValue;
            SCH0109U01GrdDetailResult res = CloudService.Instance.Submit<SCH0109U01GrdDetailResult, SCH0109U01GrdDetailArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdDetailItem.ForEach(delegate(SCH0109U01GrdDetailInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.CodeType,
                        item.Code,
                        item.CodeName,
                        item.CodeName2,
                        item.Code2,
                        item.Seq,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetGrdMasterForSaveLayout
        /// <summary>
        /// GetGrdMasterForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<SCH0109U01GrdMasterInfo> GetGrdMasterForSaveLayout()
        {
            List<SCH0109U01GrdMasterInfo> lstData = new List<SCH0109U01GrdMasterInfo>();

            // for insert/update
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;

                SCH0109U01GrdMasterInfo item    = new SCH0109U01GrdMasterInfo();
                item.AdminGubun                 = grdMaster.GetItemString(i, "admin_gubun");
                item.CodeType                   = grdMaster.GetItemString(i, "code_type");
                item.CodeTypeName               = grdMaster.GetItemString(i, "code_type_name");
                item.Remark                     = grdMaster.GetItemString(i, "remark");
                item.RowState                   = grdMaster.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // for delete
            if (null != grdMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                {
                    SCH0109U01GrdMasterInfo item = new SCH0109U01GrdMasterInfo();
                    item.CodeType = Convert.ToString(dr["code_type"]);
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
        private List<SCH0109U01GrdDetailInfo> GetGrdDetailForSaveLayout()
        {
            List<SCH0109U01GrdDetailInfo> lstData = new List<SCH0109U01GrdDetailInfo>();

            // for insert/delete
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged || String.IsNullOrEmpty(grdDetail.GetItemString(i, "code"))) continue;

                SCH0109U01GrdDetailInfo item    = new SCH0109U01GrdDetailInfo();
                item.Code                       = grdDetail.GetItemString(i, "code");
                item.Code2                      = grdDetail.GetItemString(i, "code2");
                item.CodeName                   = grdDetail.GetItemString(i, "code_name");
                item.CodeName2                  = grdDetail.GetItemString(i, "code_name2");
                item.CodeType                   = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                item.Seq                        = grdDetail.GetItemString(i, "seq");
                item.RowState                   = grdDetail.GetRowState(i).ToString();

                lstData.Add(item);
            }

            // for delete
            if (null != grdDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                {
                    SCH0109U01GrdDetailInfo item    = new SCH0109U01GrdDetailInfo();
                    item.CodeType                   = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                    item.Code                       = Convert.ToString(dr["code"]);
                    item.RowState                   = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion

        #region Method
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

        private void grdDetail_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

        private void grdMaster_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            CheckUpdateMasterData();
        }
    }
}