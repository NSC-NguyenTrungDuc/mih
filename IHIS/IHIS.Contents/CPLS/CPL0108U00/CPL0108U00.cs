/*
** CPL0108U00 各種コード管理
** Date		: 2007. 11. 05
** Modified	: 2008. 02. 15
**			  Park Seung Hwan
*/

#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CPLS.Properties;
using IHIS.Framework;
using Microsoft.Win32;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0108U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0108U00 : IHIS.Framework.XScreen
    {
        //private XSavePerformer savePerformer = null;

        #region IHIS CONTOLS
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel4;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XLabel xLabel2;
        private IHIS.Framework.XEditGrid grdDetail;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XTextBox txtCodeTypeName;
        private IHIS.Framework.XButton btnPrintName;
        #endregion
        private XEditGridCell xEditGridCell7;

        #region Main, Distruction
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPL0108U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            this.grdMaster.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type_name" });
            this.grdDetail.ParamList = new List<string>(new String[] { "f_hosp_code", "f_code_type", "f_io_gubun", "f_page_number" });

            this.grdMaster.ExecuteQuery = LoadDataGrdMaster;
            this.grdDetail.ExecuteQuery = LoadDataGrdDetail;
        }

        /// <summary>
        /// Load data grdMaster
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0108U00GrdMasterArgs args = new CPL0108U00GrdMasterArgs();
            args.CodeTypeName = bc["f_code_type_name"] != null ? bc["f_code_type_name"].VarValue : "";
            CPL0108U00GrdMasterResult result = CloudService.Instance.Submit<CPL0108U00GrdMasterResult, CPL0108U00GrdMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0108U00InitGrdMasterListItemInfo item in result.GrdMaster)
                {
                    object[] objects = 
				{ 
					item.CodeType, 
					item.CodeTypeName
				};
                    res.Add(objects);
                }
            }
            return res;
        } 

        /// <summary>
        /// Load data for grdDetail
        /// </summary>
        /// <param name="bc"></param>
        /// <returns></returns>
        private List<object[]> LoadDataGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL0108U00GrdDetailArgs args = new CPL0108U00GrdDetailArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            args.PageNumber = bc["f_page_number"].VarValue;
            args.Offset = "200";
            CPL0108U00GrdDetailResult result = CloudService.Instance.Submit<CPL0108U00GrdDetailResult, CPL0108U00GrdDetailArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0108U00InitGrdDetailListItemInfo item in result.GrdDetail)
                {
                    object[] objects = 
				{ 
					item.CodeType, 
					item.Code, 
					item.CodeName, 
					item.CodeNameRe, 
					item.SystemGubun, 
					item.CodeValue
				};
                    res.Add(objects);
                }
            }
            return res;
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
        #endregion

        #region Designer generated code
        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0108U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnPrintName = new IHIS.Framework.XButton();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtCodeTypeName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
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
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel4);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdDetail);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdDetail
            // 
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell3,
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell17,
            this.xEditGridCell7});
            this.grdDetail.ColPerLine = 4;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 5;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "code_type";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
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
            this.xEditGridCell5.CellWidth = 136;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 40;
            this.xEditGridCell6.CellName = "code_name_re";
            this.xEditGridCell6.CellWidth = 131;
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
            this.xEditGridCell17.IsVisible = false;
            this.xEditGridCell17.Row = -1;
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 50;
            this.xEditGridCell7.CellName = "code_value";
            this.xEditGridCell7.CellWidth = 203;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 3;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
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
            this.xEditGridCell2.IsReadOnly = true;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            // 
            // xPanel4
            // 
            this.xPanel4.Controls.Add(this.grdMaster);
            resources.ApplyResources(this.xPanel4, "xPanel4");
            this.xPanel4.DrawBorder = true;
            this.xPanel4.Name = "xPanel4";
            // 
            // xPanel3
            // 
            this.xPanel3.Controls.Add(this.btnPrintName);
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
            // 
            // btnPrintName
            // 
            this.btnPrintName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.btnPrintName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnPrintName.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintName.Image")));
            resources.ApplyResources(this.btnPrintName, "btnPrintName");
            this.btnPrintName.Name = "btnPrintName";
            this.btnPrintName.Click += new System.EventHandler(this.btnPrintName_Click);
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
            this.xPanel2.Controls.Add(this.txtCodeTypeName);
            this.xPanel2.Controls.Add(this.xLabel2);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // txtCodeTypeName
            // 
            resources.ApplyResources(this.txtCodeTypeName, "txtCodeTypeName");
            this.txtCodeTypeName.Name = "txtCodeTypeName";
            this.txtCodeTypeName.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeTypeName_DataValidating);
            // 
            // xLabel2
            // 
            resources.ApplyResources(this.xLabel2, "xLabel2");
            this.xLabel2.Name = "xLabel2";
            // 
            // CPL0108U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0108U00";
            resources.ApplyResources(this, "$this");
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

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.grdDetail.SetRelationKey("code_type", "code_type");
            this.grdDetail.SetRelationTable("cpl0109");
            this.CurrMQLayout = this.grdMaster;

            //savePerformer = new XSavePerformer(this);
            //this.grdMaster.SavePerformer = savePerformer;
            //this.grdDetail.SavePerformer = savePerformer;
            this.grdMaster.QueryLayout(true);
        }
        #endregion

        /****************************************************************/

        #region [ #01 마스터 테이블 중복체크(입력시 code type) ]
        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                string cmdText = string.Empty;	// 중복 체크를 위한 쿼리문
                string msg = string.Empty;	// 에러 검출시 메세지
                DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;

                if (rowState == DataRowState.Added)
                {
                    if (e.ColName == "code_type")
                    {
                        // 중복 체크및 유효성 검사를 위한 타겟
                        string target = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");

//                        cmdText = @"SELECT 'X'
//									  FROM CPL0108
//									 WHERE HOSP_CODE = :f_hosp_code
//                                       AND CODE_TYPE = :f_code_type";

//                        BindVarCollection bindVar = new BindVarCollection();
//                        bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bindVar.Add("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));

                        CPL0108U00CheckItemGrdMasterArgs args = 
                            new CPL0108U00CheckItemGrdMasterArgs(grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));

                        if (target.Trim().Length == 0)
                        {
                            msg = Resources.MSG001_MSG;
                            XMessageBox.Show(msg);
                        }
                        else
                        {
                            //if (Service.ExecuteScalar(cmdText, bindVar) != null)
                            CPL0108U00CheckItemGrdMasterResult result =
                            CloudService.Instance
                                .Submit<CPL0108U00CheckItemGrdMasterResult, CPL0108U00CheckItemGrdMasterArgs>(args);

                            if (result.ExecutionStatus == ExecutionStatus.Success && result.CheckItem != "")
                            {
                                msg = Resources.MSG002_MSG;
                                XMessageBox.Show(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type") +
                                    msg, Resources.MSG002_CAP, MessageBoxButtons.OK);
                                grdMaster.SetItemValue(e.RowNumber, "code_type", string.Empty);
                            }
                            else
                            {
                                // 유효한 값
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
        #endregion

        #region [ #02 디테일 테이블 중복체크(입력시 code) ]
        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                string cmdText = string.Empty;	// 중복 체크를 위한 쿼리문
                string msg = string.Empty;	// 에러 검출시 메세지
                DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;

                if (rowState == DataRowState.Added)
                {
                    if (e.ColName == "code")
                    {
                        // 중복 체크및 유효성 검사를 위한 타겟
                        string target = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code");

//                        cmdText = @"SELECT 'X'
//									  FROM CPL0109
//									 WHERE HOSP_CODE = :f_hosp_code
//                                       AND CODE  = :f_code
//									   AND CODE_TYPE = :f_code_type";

//                        BindVarCollection bindVar = new BindVarCollection();
//                        bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bindVar.Add("f_code", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code"));
//                        bindVar.Add("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));

                        CPL0108U00CheckItemGrdDetailArgs args = new CPL0108U00CheckItemGrdDetailArgs();
                        args.Code = grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code");
                        args.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");

                        if (target.Trim().Length == 0)
                        {
                            msg = (Resources.MSG001_MSG);
                            XMessageBox.Show(msg);
                        }
                        else
                        {
                            //if (Service.ExecuteScalar(cmdText, bindVar) != null)
                            CPL0108U00CheckItemGrdDetailResult result =
                                CloudService.Instance
                                    .Submit<CPL0108U00CheckItemGrdDetailResult, CPL0108U00CheckItemGrdDetailArgs>(args);


                            if (result.ExecutionStatus == ExecutionStatus.Success && result.CheckItem != "")
                            {
                                msg = (Resources.MSG002_MSG);
                                XMessageBox.Show(this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code") +
                                    msg, Resources.MSG002_CAP, MessageBoxButtons.OK);
                                grdDetail.SetItemValue(e.RowNumber, "code", string.Empty);
                            }
                            else
                            {
                                // 유효한 값
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
        #endregion

        #region [ #03 TextBox DataValidating ]
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
        #endregion

        #region [ #04 마스타 그리드 Row포커스 체인지 이벤트 ]
        private void grdMaster_RowFocusChanged(object sender, IHIS.Framework.RowFocusChangedEventArgs e)
        {
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
        #endregion

        #region [ #05 Print Button Event ]
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
        #endregion

        #region [ #06 Grid QueryStarting 이벤트 모음 ]
        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdMaster.SetBindVarValue("f_code_type_name", this.txtCodeTypeName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type"));
        }
        #endregion

        #region [ #07 Button List 이벤트 ]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
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
                        break;

                    case FunctionType.Delete:
                        if (this.CurrMQLayout != this.grdDetail)
                        {
                            e.IsBaseCall = false;
                            return;
                        }
                        break;

                    case FunctionType.Update:
                        e.IsBaseCall = false;

                        if (this.SaveValid())
                        {
                            //Service.BeginTransaction();
                            //if (!this.grdMaster.SaveLayout() || !this.grdDetail.SaveLayout())
                            if (!SaveGrdDetail())
                            {
                                throw new Exception();
                            }
                            else
                            {
                                //Service.CommitTransaction();
                                grdDetail.QueryLayout(true);
                            }
                        }
                        else
                        {
                            string msg = string.Empty;
                            msg = (Resources.MSG001_MSG);
                            XMessageBox.Show(msg);
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

        private bool SaveGrdDetail()
        {
            List<CPL0108U00InitGrdDetailListItemInfo> inputList = GetListFromGrdDetail();
            if (inputList.Count == 0)
            {
                return true;
            }

            CPL0108U00SaveLayoutArgs args = new CPL0108U00SaveLayoutArgs();
            args.InputList = inputList;
            args.UserId = UserInfo.UserID;

            UpdateResult result = CloudService.Instance.Submit<UpdateResult, CPL0108U00SaveLayoutArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                return result.Result;
            }
            return false;
        }

        private List<CPL0108U00InitGrdDetailListItemInfo> GetListFromGrdDetail()
        {
            List<CPL0108U00InitGrdDetailListItemInfo> dataList = new List<CPL0108U00InitGrdDetailListItemInfo>();
            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged)
                {
                    continue;
                }
                CPL0108U00InitGrdDetailListItemInfo info = new CPL0108U00InitGrdDetailListItemInfo();
                info.CodeType = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code_type");
                info.Code = grdDetail.GetItemString(i, "code");
                info.CodeName = grdDetail.GetItemString(i, "code_name");
                info.CodeNameRe = grdDetail.GetItemString(i, "code_name_re");
                info.SystemGubun = grdDetail.GetItemString(i, "system_gubun");
                info.CodeValue = grdDetail.GetItemString(i, "code_value");
                info.RowState = grdDetail.GetRowState(i).ToString();

                dataList.Add(info);
            }

            if (grdDetail.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdDetail.DeletedRowTable.Rows)
                {
                    CPL0108U00InitGrdDetailListItemInfo info = new CPL0108U00InitGrdDetailListItemInfo();
                    info.CodeType = row["code_type"].ToString();
                    info.Code = row["code"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    dataList.Add(info);
                }
            }
            return dataList;
        }

        #endregion

        /***************** CUSTOM VALLID ***********************/

        #region [ C #01 Save Valid 저장 여부 가능 확인 ]
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
        #endregion

        /***************** XSave Performer ***************************/

        #region [ XSavePerformer ]
//        public class XSavePerformer : ISavePerformer
//        {
//            CPL0108U00 parent = null;
//            bool result = true;
//            string cmdText = string.Empty;

//            public XSavePerformer(CPL0108U00 parent)
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
//									INSERT INTO CPL0108 (
//										SYS_DATE,              SYS_ID,                   UPD_DATE,              UPD_ID,
//										CODE_TYPE,             CODE_TYPE_NAME,           HOSP_CODE
//									) 
//									VALUES (
//										SYSDATE,               :q_user_id,               SYSDATE,              :q_user_id,
//										:f_code_type,          :f_code_type_name,        :f_hosp_code)";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"
//										UPDATE CPL0108
//										   SET UPD_ID          = :q_user_id
//											 , UPD_DATE        = SYSDATE
//											 , CODE_TYPE_NAME  = :f_code_type_name
//										 WHERE CODE_TYPE       = :f_code_type
//                                           AND HOSP_CODE       = :f_hosp_code";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"
//										DECLARE
//											RESULT   VARCHAR2(1);
//											BEGIN
//												RESULT := 'N';
//												FOR X IN (SELECT 'X' 
//															FROM CPL0109
//															WHERE CODE_TYPE = :f_code_type
//                                                              AND HOSP_CODE = :f_hosp_code) LOOP
//													RESULT := 'Y';
//												END LOOP;
//					                             
//											DELETE CPL0108
//										     WHERE CODE_TYPE = :f_code_type
//                                               AND HOSP_CODE = :f_hosp_code;
//											IF RESULT = 'Y' THEN
//												DELETE CPL0109
//												 WHERE CODE_TYPE = :f_code_type
//                                                   AND HOSP_CODE = :f_hosp_code;
//											END IF;
//											END;";
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
//									INSERT INTO CPL0109 (
//										SYS_DATE,        SYS_ID,          UPD_DATE,      UPD_ID,
//										CODE_TYPE,       CODE,            CODE_NAME,
//										CODE_NAME_RE,    SYSTEM_GUBUN,    HOSP_CODE,
//                                        CODE_VALUE
//									) 
//									VALUES (
//										SYSDATE,         :q_user_id,      SYSDATE,       :q_user_id,
//										:f_code_type,    :f_code,         :f_code_name,
//										:f_code_name_re, 'CPL',           :f_hosp_code,
//                                        :f_code_value)";
//                                break;
//                            case DataRowState.Modified:
//                                cmdText = @"
//										 UPDATE CPL0109
//											SET UPD_ID            = :q_user_id
//											  , UPD_DATE          = SYSDATE
//											  , CODE_NAME         = :f_code_name
//											  , CODE_NAME_RE      = :f_code_name_re
//											  , SYSTEM_GUBUN      = 'CPL'
//                                              , CODE_VALUE        = :f_code_value
//										  WHERE CODE_TYPE         = :f_code_type
//											AND CODE              = :f_code
//                                            AND HOSP_CODE         = :f_hosp_code";
//                                break;
//                            case DataRowState.Deleted:
//                                cmdText = @"
//										DELETE CPL0109
//										 WHERE CODE_TYPE = :f_code_type
//										   AND CODE      = :f_code
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
//											SET UPD_ID            = :q_user_id
//											  , UPD_DATE          = SYSDATE
//											  , SPECIMEN_NAME     = :f_code_name
//										  WHERE HOSP_CODE         = :f_hosp_code 
//                                            AND SPECIMEN_CODE     = :f_code
//											AND SPECIMEN_GUBUN    = 'CPL'             ";
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
    }
}

