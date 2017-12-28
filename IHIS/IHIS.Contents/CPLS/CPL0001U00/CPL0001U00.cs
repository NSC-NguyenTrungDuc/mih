/*
** CPL0001U00 依頼指管理
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
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Messaging;
using IHIS.CPLS.Properties;
using IHIS.Framework;
using CPL0001U00GrdComboInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL0001U00GrdComboInfo;
using CPL0001U00GrdSlipInfo = IHIS.CloudConnector.Contracts.Models.Cpls.CPL0001U00GrdSlipInfo;

#endregion

namespace IHIS.CPLS
{
    /// <summary>
    /// CPL0001U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class CPL0001U00 : IHIS.Framework.XScreen
    {
        private XSavePerformer savePerformer = null;

        #region IHIS CONTROLS
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private IHIS.Framework.XPanel xPanel3;
        private IHIS.Framework.XPanel xPanel5;
        private IHIS.Framework.XButtonList btnList;
        private System.Windows.Forms.Splitter splitter1;
        private IHIS.Framework.XLabel xLabel1;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XEditGridCell xEditGridCell17;
        private IHIS.Framework.XEditGrid grdSlip;
        #endregion

        private XFindWorker fwkCPL0001;
        private FindColumnInfo findColumnInfo11;
        private FindColumnInfo findColumnInfo12;
        private XDictComboBox cboJundalGubun;

        #region Main, Destruction
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CPL0001U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            grdSlip.ParamList = new List<string>(new String[] {"f_hosp_code", "f_slip_code"});
            grdSlip.ExecuteQuery = ExecuteQueryGrdSlipListItem;

            
            cboJundalGubun.ExecuteQuery = ExecuteCboJundal;
            cboJundalGubun.SetDictDDLB();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPL0001U00));
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel5 = new IHIS.Framework.XPanel();
            this.grdSlip = new IHIS.Framework.XEditGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell17 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.xPanel3 = new IHIS.Framework.XPanel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.xPanel2 = new IHIS.Framework.XPanel();
            this.cboJundalGubun = new IHIS.Framework.XDictComboBox();
            this.xLabel1 = new IHIS.Framework.XLabel();
            this.fwkCPL0001 = new IHIS.Framework.XFindWorker();
            this.findColumnInfo11 = new IHIS.Framework.FindColumnInfo();
            this.findColumnInfo12 = new IHIS.Framework.FindColumnInfo();
            this.xPanel1.SuspendLayout();
            this.xPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSlip)).BeginInit();
            this.xPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // xPanel1
            // 
            this.xPanel1.Controls.Add(this.xPanel5);
            this.xPanel1.Controls.Add(this.splitter1);
            this.xPanel1.Controls.Add(this.xPanel3);
            this.xPanel1.Controls.Add(this.xPanel2);
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel5
            // 
            this.xPanel5.Controls.Add(this.grdSlip);
            resources.ApplyResources(this.xPanel5, "xPanel5");
            this.xPanel5.DrawBorder = true;
            this.xPanel5.Name = "xPanel5";
            // 
            // grdSlip
            // 
            this.grdSlip.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell17});
            this.grdSlip.ColPerLine = 4;
            this.grdSlip.ColResizable = true;
            this.grdSlip.Cols = 5;
            resources.ApplyResources(this.grdSlip, "grdSlip");
            this.grdSlip.ExecuteQuery = null;
            this.grdSlip.FixedCols = 1;
            this.grdSlip.FixedRows = 1;
            this.grdSlip.HeaderHeights.Add(21);
            this.grdSlip.Name = "grdSlip";
            this.grdSlip.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdSlip.ParamList")));
            this.grdSlip.QuerySQL = resources.GetString("grdSlip.QuerySQL");
            this.grdSlip.RowHeaderVisible = true;
            this.grdSlip.Rows = 2;
            this.grdSlip.ToolTipActive = true;
            this.grdSlip.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdSlip_GridColumnChanged);
            this.grdSlip.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdSlip_QueryStarting);
            this.grdSlip.PreEndInitializing += new System.EventHandler(this.grdSlip_PreEndInitializing);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "slip_code";
            this.xEditGridCell4.CellWidth = 71;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell4.IsUpdatable = false;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 80;
            this.xEditGridCell5.CellName = "slip_name";
            this.xEditGridCell5.CellWidth = 196;
            this.xEditGridCell5.Col = 2;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 40;
            this.xEditGridCell6.CellName = "slip_name_re";
            this.xEditGridCell6.CellWidth = 476;
            this.xEditGridCell6.Col = 3;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell17
            // 
            this.xEditGridCell17.CellName = "jundal_gubun";
            this.xEditGridCell17.CellWidth = 154;
            this.xEditGridCell17.Col = 4;
            this.xEditGridCell17.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell17.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell17, "xEditGridCell17");
            this.xEditGridCell17.ImeMode = IHIS.Framework.ColumnImeMode.OnlyEngUpper;
            this.xEditGridCell17.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            // 
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
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
            this.xPanel2.Controls.Add(this.cboJundalGubun);
            this.xPanel2.Controls.Add(this.xLabel1);
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // cboJundalGubun
            // 
            this.cboJundalGubun.ExecuteQuery = null;
            resources.ApplyResources(this.cboJundalGubun, "cboJundalGubun");
            this.cboJundalGubun.Name = "cboJundalGubun";
            this.cboJundalGubun.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("cboJundalGubun.ParamList")));
            this.cboJundalGubun.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.cboJundalGubun.UserSQL = resources.GetString("cboJundalGubun.UserSQL");
            this.cboJundalGubun.SelectedValueChanged += new System.EventHandler(this.cboJundalGubun_SelectedValueChanged);
            // 
            // xLabel1
            // 
            resources.ApplyResources(this.xLabel1, "xLabel1");
            this.xLabel1.Name = "xLabel1";
            // 
            // fwkCPL0001
            // 
            this.fwkCPL0001.ColInfos.AddRange(new IHIS.Framework.FindColumnInfo[] {
            this.findColumnInfo11,
            this.findColumnInfo12});
            this.fwkCPL0001.ExecuteQuery = null;
            this.fwkCPL0001.FormText = "FIND FORM";
            this.fwkCPL0001.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("fwkCPL0001.ParamList")));
            this.fwkCPL0001.SearchImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.fwkCPL0001.ServerFilter = true;
            // 
            // findColumnInfo11
            // 
            this.findColumnInfo11.ColName = "code";
            this.findColumnInfo11.ColWidth = 131;
            this.findColumnInfo11.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo11, "findColumnInfo11");
            // 
            // findColumnInfo12
            // 
            this.findColumnInfo12.ColName = "name";
            this.findColumnInfo12.ColWidth = 269;
            this.findColumnInfo12.FilterType = IHIS.Framework.FilterType.InitYes;
            resources.ApplyResources(this.findColumnInfo12, "findColumnInfo12");
            // 
            // CPL0001U00
            // 
            this.AutoCheckInputLayoutChanged = true;
            this.Controls.Add(this.xPanel1);
            this.Name = "CPL0001U00";
            resources.ApplyResources(this, "$this");
            this.xPanel1.ResumeLayout(false);
            this.xPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSlip)).EndInit();
            this.xPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CurrMQLayout = this.grdSlip;
            this.cboJundalGubun.SelectedIndex = 0;
            this.CurrMQLayout = grdSlip;
            this.CurrMSLayout = grdSlip;

            savePerformer = new XSavePerformer(this);
            grdSlip.SavePerformer = savePerformer;
        }
        #endregion

        /***********************************************************/

        #region [ #01 Slip 테이블 중복체크(입력시 slip code) ]
        private void grdSlip_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            try
            {
                string cmdText = string.Empty;
                DataRowState rowState = this.grdSlip.LayoutTable.Rows[this.grdSlip.CurrentRowNumber].RowState;

                // 입력 버튼이 클릭 되었을 때만 체크
                if (rowState == DataRowState.Added)
                {
                    // 입력된 셀이 코드타입 컬럼이라면,
                    if (e.ColName == "slip_code")
                    {
                        //string target = grdSlip.GetItemString(grdSlip.CurrentRowNumber, "slip_code");

                        // 만약 마스터테이블에 존재한다면, 'Y'를 그렇지않으면, 'N'을 리턴
//                        cmdText = @"
//					SELECT 'Y'
//					  FROM DUAL
//					 WHERE EXISTS (
//									SELECT 'X'
//									  FROM CPL0001
//									 WHERE HOSP_CODE     = :f_hosp_code
//                                       AND SLIP_CODE     = :f_slip_code)";

//                        BindVarCollection bindVar = new BindVarCollection();
//                        bindVar.Add("f_hosp_code", EnvironInfo.HospCode);
//                        bindVar.Add("f_slip_code", grdSlip.GetItemString(grdSlip.CurrentRowNumber, "slip_code"));


                        //if (Service.ExecuteScalar(cmdText, bindVar) != null)
                        //Check Cloud
                        if (CheckColumn(EnvironInfo.HospCode, grdSlip.GetItemString(grdSlip.CurrentRowNumber, "slip_code")))
                        {
                            string msg = Resources.MSG001_MSG;
                            XMessageBox.Show(this.grdSlip.GetItemString(this.grdSlip.CurrentRowNumber, "slip_code") +
                                msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                            e.Cancel = true;
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

        #region [ #02 txtSlipName_DataValidating ]
        private void txtSlipName_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            try
            {
                this.grdSlip.QueryLayout(false);
            }
            catch (Exception err)
            {
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#01-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        #region [ #03 grdSlip_QueryStarting ]
        private void grdSlip_QueryStarting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.grdSlip.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdSlip.SetBindVarValue("f_slip_code", cboJundalGubun.GetDataValue());
        }
        #endregion

        #region [ #04 Button List 이벤트 ]
        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            try
            {
                switch (e.Func)
                {

                    case FunctionType.Update:
                        e.IsBaseCall = false;

                        if (this.SaveValid())
                        {
                            //Service.BeginTransaction();
                            //if (!this.grdSlip.SaveLayout())
                            if (!GrdListSaveLayout())
                            {
                                throw new Exception();
                            }
                            else
                            {
                                //Service.CommitTransaction();
                                grdSlip.QueryLayout(true);
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
                //https://sofiamedix.atlassian.net/browse/MED-10610
                //XMessageBox.Show("#04-1\n\nService : " + Service.ErrFullMsg + "\n\nException : " + err.Message);
            }
        }
        #endregion

        /****************** CUSTOM METHOD *****************************/

        #region [ C #01 SaveValid 저장 가능 여부 확인 ]
        private bool SaveValid()
        {
            for (int i = 0; i < this.grdSlip.RowCount; i++)
            {
                if (grdSlip.GetItemString(i, "slip_code").Trim().Equals(string.Empty))
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        /****************** XSavePerformer *******************************/

        #region [ XSavePerformer ]
        public class XSavePerformer : ISavePerformer
        {
            private CPL0001U00 parent = null;
            bool result = true;
            string cmdText = string.Empty;

            public XSavePerformer(CPL0001U00 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerID, RowDataItem item)
            {
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"
							INSERT INTO CPL0001 (
					 							 SYS_DATE,        SYS_ID,       UPD_ID,            UPD_DATE
												,SLIP_CODE 
												,SLIP_NAME
												,SLIP_NAME_RE 
												,JUNDAL_GUBUN
							) VALUES (
												 SYSDATE,         :q_user_id,  :q_user_id,            SYSDATE
												,:f_slip_code    
												,:f_slip_name   
												,:f_slip_name_re
												,:f_jundal_gubun)";
                        break;
                    case DataRowState.Modified:
                        cmdText = @"
								UPDATE CPL0001
								   SET UPD_ID           = :q_user_id
									 , SYS_DATE         = SYSDATE
									 , SLIP_NAME        = :f_slip_name                              
									 , SLIP_NAME_RE     = :f_slip_name_re                        
									 , JUNDAL_GUBUN     = :f_jundal_gubun   
								 WHERE HOSP_CODE        = :f_hosp_code
                                   AND SLIP_CODE        = :f_slip_code";
                        break;
                    case DataRowState.Deleted:
                        cmdText = @"
								DELETE CPL0001
								 WHERE HOSP_CODE        = :f_hosp_code
                                   AND SLIP_CODE        = :f_slip_code";
                        break;
                }
                if (Service.ExecuteNonQuery(cmdText, item.BindVarList))
                {
                    string msg = Resources.MSG002_MSG;
                    XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    return true;
                }
                else
                {
                    string msg = Resources.MSG003_MSG;
                    XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
                    return false;
                }
            }
        }
        #endregion

        private void cboJundalGubun_SelectedValueChanged(object sender, EventArgs e)
        {
            this.grdSlip.QueryLayout(true);
        }

        #region Cloud
        private IList<object[]> ExecuteQueryGrdSlipListItem(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CPL0001U00GrdSlipArgs args = new CPL0001U00GrdSlipArgs();
            args.FHospCode = bc["f_hosp_code"] != null ? bc["f_hosp_code"].VarValue : "";
            args.FSlipCode = bc["f_slip_code"] != null ? bc["f_slip_code"].VarValue : "";
            CPL0001U00GrdSlipResult result = CloudService.Instance.Submit<CPL0001U00GrdSlipResult, CPL0001U00GrdSlipArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0001U00GrdSlipInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.SlipCode,
                        item.SlipName,
                        item.SlipNameRe,
                        item.JundalGubun
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteGrdCombo(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CPL0001U00GrdComboArgs args = new CPL0001U00GrdComboArgs();
            CPL0001U00GrdComboResult result = CloudService.Instance.Submit<CPL0001U00GrdComboResult, CPL0001U00GrdComboArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0001U00GrdComboInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeNameRe
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> ExecuteCboJundal(BindVarCollection bc)
        {
            IList<object[]> res = new List<object[]>();
            CPL0001U00CboJundalArgs args = new CPL0001U00CboJundalArgs();
            CPL0001U00CboJundalResult result = CloudService.Instance.Submit<CPL0001U00CboJundalResult, CPL0001U00CboJundalArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL0001U00GrdComboInfo item in result.Dt)
                {
                    object[] objects =
                    {
                        item.Code,
                        item.CodeNameRe
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private bool CheckColumn(string hopsCode, string slipCode)
        {
            CPL0001U00GrdChangeArgs args = new CPL0001U00GrdChangeArgs();
            args.FHospCode = hopsCode;
            args.FSlipCode = slipCode;
            CPL0001U00GrdChangeResult result = CloudService.Instance.Submit<CPL0001U00GrdChangeResult, CPL0001U00GrdChangeArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                if (result.Y == "Y")
                {
                    return true;
                }
            }

            return false;
        }

        private bool GrdListSaveLayout()
        {
            bool check = false;
            for (int i = 0; i < grdSlip.RowCount; i++)
            {
                if (grdSlip.GetRowState(i) == DataRowState.Added || grdSlip.GetRowState(i) == DataRowState.Modified || grdSlip.GetRowState(i) == DataRowState.Deleted)
                {
                    check = true;
                    break;
                }
            }

            if (check == false)
            {
                if (grdSlip.DeletedRowTable == null || grdSlip.DeletedRowCount == 0)
                {
                    return true;
                }
                
            }
            // Update data
            CPL0001U00GrdSaveArgs args = new CPL0001U00GrdSaveArgs();
            args.Dt = createGrdListItemInfo();
            args.QUserId = UserInfo.UserID;
            args.FHospCode = EnvironInfo.HospCode;
            UpdateResult updateResult = CloudService.Instance.Submit<UpdateResult, CPL0001U00GrdSaveArgs>(args);

            if (updateResult == null || updateResult.ExecutionStatus != ExecutionStatus.Success ||
                updateResult.Result == false)
            {
                string msg1 = Resources.MSG003_MSG;
                XMessageBox.Show(msg1, Resources.MSG001_CAP, MessageBoxButtons.OK);
                return false;
            }
            string msg = Resources.MSG002_MSG;
            XMessageBox.Show(msg, Resources.MSG001_CAP, MessageBoxButtons.OK);
            return true;
        }

        private List<CPL0001U00GrdSlipInfo> createGrdListItemInfo()
        {
            List<CPL0001U00GrdSlipInfo> grdListItemInfo = new List<CPL0001U00GrdSlipInfo>();
            for (int i = 0; i < grdSlip.RowCount; i++)
            {
                if (grdSlip.GetRowState(i) == DataRowState.Added || grdSlip.GetRowState(i) == DataRowState.Modified)
                {
                    CPL0001U00GrdSlipInfo info = new CPL0001U00GrdSlipInfo();
                    info.SlipCode = grdSlip.GetItemString(i, "slip_code");
                    info.SlipName = grdSlip.GetItemString(i, "slip_name");
                    info.SlipNameRe = grdSlip.GetItemString(i, "slip_name_re");
                    info.JundalGubun = grdSlip.GetItemString(i, "jundal_gubun");
                    info.RowState = grdSlip.GetRowState(i).ToString();

                    grdListItemInfo.Add(info);
                }
            }
            if (grdSlip.DeletedRowTable != null && grdSlip.DeletedRowCount > 0)
            {
                foreach (DataRow row in grdSlip.DeletedRowTable.Rows)
                {
                    CPL0001U00GrdSlipInfo info = new CPL0001U00GrdSlipInfo();
                    info.SlipCode = row["slip_code"].ToString();
                    info.SlipName = row["slip_name"].ToString();
                    info.SlipNameRe = row["slip_name_re"].ToString();
                    info.JundalGubun = row["jundal_gubun"].ToString();
                    info.RowState = DataRowState.Deleted.ToString();

                    grdListItemInfo.Add(info);
                }
            }
            return grdListItemInfo;
        }


        #endregion

        private void grdSlip_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell17.ExecuteQuery = ExecuteGrdCombo;
        }

    }
}

