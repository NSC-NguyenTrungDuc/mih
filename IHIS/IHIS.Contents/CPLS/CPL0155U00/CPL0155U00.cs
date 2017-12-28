/*
** CPL0155U00 短答刑叙述入力
** Date		: 2007. 11. 13
** Modified	: 2007. 11. 13
**			  Park Seung Hwan
*/

#region 사용 NameSpace 지정
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CPLS.Properties;
using IHIS.Framework;
#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0155U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0155U00 : IHIS.Framework.XScreen
    {
        #region IHIS Controls
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
        private IHIS.Framework.XTextBox txtCodeTypeName;
        private IHIS.Framework.XTextBox txtCodeType;
        private IHIS.Framework.XEditGridCell xEditGridCell7;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell8;
        #endregion

        private System.ComponentModel.Container components = null;
        private XSavePerformer savePerformer = null;
        private string dupQuery = string.Empty;
        private BindVarCollection dupBindVar = null;

        #region Main, Destruction
        public CPL0155U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0155U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdDetail = new IHIS.Framework.XEditGrid();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel4 = new IHIS.Framework.XPanel();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.txtCodeTypeName = new IHIS.Framework.XTextBox();
            this.xLabel2 = new IHIS.Framework.XLabel();
            this.txtCodeType = new IHIS.Framework.XTextBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
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
            this.xEditGridCell8});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.ColResizable = true;
            this.grdDetail.Cols = 4;
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.FocusColumnName = "code";
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = resources.GetString("grdDetail.QuerySQL");
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "result_code_gubun";
            this.xEditGridCell3.Col = -1;
            this.xEditGridCell3.ExecuteQuery = null;
            this.xEditGridCell3.IsVisible = false;
            this.xEditGridCell3.Row = -1;
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 6;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.CellWidth = 85;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 100;
            this.xEditGridCell5.CellName = "code_name";
            this.xEditGridCell5.CellWidth = 212;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 2000;
            this.xEditGridCell6.CellName = "jindan_text";
            this.xEditGridCell6.CellWidth = 228;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.DisplayMemoText = true;
            this.xEditGridCell6.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellName = "seq";
            this.xEditGridCell8.Col = -1;
            this.xEditGridCell8.ExecuteQuery = null;
            this.xEditGridCell8.IsVisible = false;
            this.xEditGridCell8.Row = -1;
            // 
            // grdMaster
            // 
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell7,
            this.xEditGridCell1,
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.ColResizable = true;
            this.grdMaster.Cols = 3;
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "code";
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellName = "code_type";
            this.xEditGridCell7.Col = -1;
            this.xEditGridCell7.ExecuteQuery = null;
            this.xEditGridCell7.IsUpdatable = false;
            this.xEditGridCell7.IsVisible = false;
            this.xEditGridCell7.Row = -1;
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 75;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.ImeMode = IHIS.Framework.ColumnImeMode.EngUpper;
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 250;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
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
            this.xPanel3.Controls.Add(this.btnList);
            resources.ApplyResources(this.xPanel3, "xPanel3");
            this.xPanel3.DrawBorder = true;
            this.xPanel3.Name = "xPanel3";
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
            this.xPanel2.Controls.Add(this.txtCodeType);
            this.xPanel2.Controls.Add(this.xLabel1);
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
            // txtCodeType
            // 
            this.txtCodeType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtCodeType, "txtCodeType");
            this.txtCodeType.Name = "txtCodeType";
            this.txtCodeType.DataValidating += new IHIS.Framework.DataValidatingEventHandler(this.txtCodeType_DataValidating);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // CPL0155U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0155U00";
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
            this.grdDetail.SetRelationKey("result_code_gubun", "code");
            this.grdDetail.SetRelationTable("cpl0155");

            if (!grdMaster.QueryLayout(false))
            {
                XMessageBox.Show(Service.ErrMsg);
                return;
            }
            else
            {
                this.CurrMQLayout = this.grdMaster;
                savePerformer = new XSavePerformer(this);

                this.grdMaster.SavePerformer = savePerformer;
                this.grdDetail.SavePerformer = savePerformer;
            }
        }
        #endregion

        /********************************************************************/

        #region [ #01 grdMaster_GridColumnChanged 마스터 테이블 중복체크(입력시 code type) ]
        private void grdMaster_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                DataRowState rowState = this.grdMaster.LayoutTable.Rows[this.grdMaster.CurrentRowNumber].RowState;
                // 입력 버튼이 클릭 되었을 때만 체크
                if (rowState == DataRowState.Added)
                {
                    // 입력된 셀이 코드타입 컬럼이라면,
                    if (e.ColName == "code")
                    {
                        dupQuery = @"
									SELECT 'X'
									  FROM CPL0109
									 WHERE HOSP_CODE = :f_hosp_code
                                       AND CODE_TYPE = '27'
									   AND CODE      = :f_code";

                        dupBindVar = new BindVarCollection();
                        dupBindVar.Clear();
                        dupBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                        dupBindVar.Add("f_code", e.ChangeValue.ToString());

                        if (Service.ExecuteScalar(dupQuery, dupBindVar) != null)
                        {
                            string msg = Resources.MSG001_MSG;
                            XMessageBox.Show(this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code") +
                                msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            grdMaster.SetItemValue(e.RowNumber, "code", string.Empty);
                        }
                        else
                        {
                            this.grdMaster.SetItemValue(e.RowNumber, "code_type", "27");
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

        #region [ #02 grdDetail_GridColumnChanged 디테일 테이블 중복체크(입력시 code) ]
        private void grdDetail_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                DataRowState rowState = this.grdDetail.LayoutTable.Rows[this.grdDetail.CurrentRowNumber].RowState;
                //입력 버튼이 클릭 되었을 때만 체크
                if (rowState == DataRowState.Added)
                {
                    // 입력된 셀이 코드 컬럼이면,
                    if (e.ColName == "code")
                    {
                        dupQuery = @"
									SELECT 'X'
									  FROM CPL0155
									 WHERE HOSP_CODE         = :f_hosp_code
                                       AND RESULT_CODE_GUBUN = :f_result_code_gubun
									   AND CODE              = :f_code";

                        dupBindVar = new BindVarCollection();
                        dupBindVar.Clear();
                        dupBindVar.Add("f_hosp_code", EnvironInfo.HospCode);
                        dupBindVar.Add("f_result_code_gubun", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code"));
                        dupBindVar.Add("f_code", grdDetail.GetItemString(grdDetail.CurrentRowNumber, "code"));

                        if (Service.ExecuteScalar(dupQuery, dupBindVar) != null)
                        {
                            string msg = (Resources.MSG001_MSG);
                            XMessageBox.Show(this.grdDetail.GetItemString(this.grdDetail.CurrentRowNumber, "code") +
                                msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            grdDetail.SetItemValue(e.RowNumber, "code", string.Empty);
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

        #region [ #03 TextBox Data Input (grdMaster Output) ]
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
                //XMessageBox.Show("#03-2\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #04 Grid QueryStarting ]
        private void grdMaster_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdMaster.SetBindVarValue("f_code", txtCodeType.GetDataValue());
            grdMaster.SetBindVarValue("f_code_name", txtCodeTypeName.GetDataValue());
        }

        private void grdDetail_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdDetail.SetBindVarValue("f_result_code_gubun", grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code"));
        }
        #endregion

        #region [ #05 Button List Click Event ]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                switch (e.Func)
                {
                    case FunctionType.Update:

                        if (this.SaveValid())
                        {
                            Service.BeginTransaction();
                            if (grdMaster.SaveLayout() && grdDetail.SaveLayout())
                            {
                                Service.CommitTransaction();
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                Service.RollbackTransaction();
                //XMessageBox.Show("#05-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        /********************** CUSTOM METHOD **************************/

        #region [ C #01 Save Valid ]
        private bool SaveValid()
        {
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetItemString(i, "code").Trim().Equals(string.Empty)) return false;
            }

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetItemString(i, "code").Trim().Equals(string.Empty)) return false;
            }

            return true;
        }
        #endregion

        /****************************** XSAVE PERFORMER *********************************************/

        #region XSavePerformer 멤버
        public class XSavePerformer : ISavePerformer
        {
            private CPL0155U00 parent = null;
            bool result = true;
            string cmdText = string.Empty;

            public XSavePerformer(CPL0155U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                item.BindVarList.Add("q_user_id", UserInfo.UserID);

                if (callerID.Equals('1'))	// Master Grid
                {
                    #region Master Grid
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                            cmdText = @"
										INSERT INTO CPL0109 (
											SYS_DATE,        UPD_ID,         UPD_DATE,
											CODE_TYPE,       CODE,            CODE_NAME,
											SYSTEM_GUBUN
										) VALUES (
											SYSDATE,         :q_user_id,      SYSDATE,
											:f_code_type,    :f_code,         :f_code_name,
											'CPL')";
                            break;
                        case DataRowState.Modified:
                            cmdText = @"
										UPDATE CPL0109
										   SET UPD_ID           = :q_user_id
											 , UPD_DATE          = SYSDATE
										 	 , CODE_NAME         = :f_code_name
											 , SYSTEM_GUBUN      = 'CPL'
										 WHERE HOSP_CODE         = :f_hosp_code
                                           AND CODE_TYPE         = :f_code_type
										   AND CODE              = :f_code";
                            break;
                        case DataRowState.Deleted:
                            cmdText = @"
								DELETE CPL0109
								 WHERE HOSP_CODE = :f_hosp_code
                                   AND CODE_TYPE = :f_code_type
                                   AND CODE      = :f_code";
                            break;
                    }
                    #endregion
                }
                else if (callerID.Equals('2'))	// Detail Grid
                {
                    #region Detail Grid
                    switch (item.RowState)
                    {
                        case DataRowState.Added:
                            cmdText = @"
										INSERT INTO CPL0155 (
											SYS_DATE,        UPD_ID,         UPD_DATE,
											RESULT_CODE_GUBUN,    
											CODE             ,    
											CODE_NAME        ,
											JINDAN_TEXT          
										) VALUES (
											SYSDATE,         :q_user_id,      SYSDATE,
											:f_result_code_gubun,
											:f_code            ,
											:f_code_name       ,
											:f_jindan_text      )";
                            break;
                        case DataRowState.Modified:
                            cmdText = @"
										UPDATE CPL0155
										   SET UPD_ID            = :q_user_id
											 , UPD_DATE          = SYSDATE
											 , CODE_NAME         = :f_code_name
											 , JINDAN_TEXT       = :f_jindan_text
										 WHERE HOSP_CODE         = :f_hosp_code
                                           AND RESULT_CODE_GUBUN = :f_result_code_gubun
										   AND CODE              = :f_code";
                            break;
                        case DataRowState.Deleted:
                            cmdText = @"
								DELETE CPL0155
								 WHERE HOSP_CODE         = :f_hosp_code
                                   AND RESULT_CODE_GUBUN = :f_result_code_gubun
								   AND CODE              = :f_code";
                            break;
                    }
                    #endregion
                }
                else
                {
                    return false;
                }

                result = Service.ExecuteNonQuery(cmdText, item.BindVarList);

                return result;
            }
        }
        #endregion
    }
}

