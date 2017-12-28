#region 사용 NameSpace 지정
using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Injs;
using IHIS.CloudConnector.Contracts.Arguments.System;
using IHIS.CloudConnector.Contracts.Models.Injs;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Injs;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector.Utility;
using IHIS.Framework;
using IHIS.INJS.Properties;

#endregion

namespace IHIS.INJS
{
    /// <summary>
    /// INJ0101U01에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class INJ0101U01 : IHIS.Framework.XScreen
    {
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XButtonList xButtonList1;
        private IHIS.Framework.XMstGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private IHIS.Framework.XPanel xPanel1;
        private IHIS.Framework.XPanel xPanel2;
        private XEditGridCell xEditGridCell3;
        private XEditGridCell xEditGridCell7;
        private XEditGridCell xEditGridCell8;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public INJ0101U01()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();
            InitializeCloud();

        }

        private void InitializeCloud()
        {
            grdMaster.ExecuteQuery = LoadGrdMaster;
            grdDetail.ParamList = CreateGrdDetailParamList();
            grdDetail.ExecuteQuery = LoadGrdDetail;
            if (!IsAdminGroup())
            {
                this.grdMaster.ReadOnly = true;
            }
        }


        #region Check Super Admin

        private bool IsAdminGroup()
        {
            if (UserInfo.AdminType == AdminType.SuperAdmin) return true;
            return false;
        }

        private void CheckUpdateMasterData()
        {
            if (!IsAdminGroup() && this.CurrMQLayout == grdMaster)
            {
                SetEnableButtonListCustomize(false);
            }
            else SetEnableButtonListCustomize(true);
        }

        private void SetEnableButtonListCustomize(bool isEnable)
        {
            this.xButtonList1.SetEnabled(FunctionType.Insert, isEnable);
            this.xButtonList1.SetEnabled(FunctionType.Delete, isEnable);
            this.xButtonList1.SetEnabled(FunctionType.Update, isEnable);
        }

        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(INJ0101U01));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell7 = new IHIS.Framework.XEditGridCell();
            this.xButtonList1 = new IHIS.Framework.XButtonList();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell8 = new IHIS.Framework.XEditGridCell();
            this.xPanel1 = new IHIS.Framework.XPanel();
            this.xPanel2 = new IHIS.Framework.XPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
            this.xPanel1.SuspendLayout();
            this.xPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList
            // 
            resources.ApplyResources(this.ImageList, "ImageList");
            // 
            // grdMaster
            // 
            resources.ApplyResources(this.grdMaster, "grdMaster");
            this.grdMaster.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell7});
            this.grdMaster.ColPerLine = 4;
            this.grdMaster.Cols = 5;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.FocusColumnName = "nut_no1";
            this.grdMaster.HeaderHeights.Add(21);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.QuerySQL = resources.GetString("grdMaster.QuerySQL");
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.ToolTipActive = true;
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            this.grdMaster.PreEndInitializing += new System.EventHandler(this.grdMaster_PreEndInitializing);
            this.grdMaster.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdMaster_MouseClick);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 30;
            this.xEditGridCell1.CellName = "code_type";
            this.xEditGridCell1.CellWidth = 119;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 30;
            this.xEditGridCell2.CellName = "code_type_name";
            this.xEditGridCell2.CellWidth = 255;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellName = "admin_gubun";
            this.xEditGridCell3.Col = 3;
            this.xEditGridCell3.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            this.xEditGridCell3.SQLType = IHIS.Framework.XComboSQLType.UserSQL;
            this.xEditGridCell3.UserSQL = resources.GetString("xEditGridCell3.UserSQL");
            // 
            // xEditGridCell7
            // 
            this.xEditGridCell7.CellLen = 500;
            this.xEditGridCell7.CellName = "remark";
            this.xEditGridCell7.CellWidth = 53;
            this.xEditGridCell7.Col = 4;
            this.xEditGridCell7.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell7.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell7, "xEditGridCell7");
            // 
            // xButtonList1
            // 
            resources.ApplyResources(this.xButtonList1, "xButtonList1");
            this.xButtonList1.IsVisibleReset = false;
            this.xButtonList1.Name = "xButtonList1";
            this.xButtonList1.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.xButtonList1.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.xButtonList1_ButtonClick);
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6,
            this.xEditGridCell8});
            this.grdDetail.ColPerLine = 3;
            this.grdDetail.Cols = 4;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(21);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.QuerySQL = "SELECT CODE_TYPE\r\n      ,CODE\r\n      ,CODE_NAME\r\n      ,REMARK\r\n  FROM INJ0102\r\n " +
    "WHERE HOSP_CODE = :f_hosp_code\r\n   AND CODE_TYPE = :f_code_type\r\n ORDER BY CODE";
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.ToolTipActive = true;
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDetail_QueryStarting);
            this.grdDetail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdDetail_MouseClick);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 30;
            this.xEditGridCell4.CellName = "code_type";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 20;
            this.xEditGridCell5.CellName = "code";
            this.xEditGridCell5.CellWidth = 98;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 50;
            this.xEditGridCell6.CellName = "code_name";
            this.xEditGridCell6.CellWidth = 295;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
            // 
            // xEditGridCell8
            // 
            this.xEditGridCell8.CellLen = 500;
            this.xEditGridCell8.CellName = "remark";
            this.xEditGridCell8.CellWidth = 53;
            this.xEditGridCell8.Col = 3;
            this.xEditGridCell8.EditorStyle = IHIS.Framework.XCellEditorStyle.MemoBox;
            this.xEditGridCell8.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell8, "xEditGridCell8");
            // 
            // xPanel1
            // 
            resources.ApplyResources(this.xPanel1, "xPanel1");
            this.xPanel1.Controls.Add(this.grdDetail);
            this.xPanel1.Controls.Add(this.grdMaster);
            this.xPanel1.DrawBorder = true;
            this.xPanel1.Name = "xPanel1";
            // 
            // xPanel2
            // 
            resources.ApplyResources(this.xPanel2, "xPanel2");
            this.xPanel2.Controls.Add(this.xButtonList1);
            this.xPanel2.DrawBorder = true;
            this.xPanel2.Name = "xPanel2";
            // 
            // INJ0101U01
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.xPanel1);
            this.Controls.Add(this.xPanel2);
            this.Name = "INJ0101U01";
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xButtonList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.xPanel1.ResumeLayout(false);
            this.xPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.grdMaster.SavePerformer = new XSavePeformer(this);
            this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;

            grdDetail.SetRelationKey("code_type", "code_type");
            grdDetail.SetRelationTable("INJ0102");

            this.grdMaster.QueryLayout(false);
        }

        private void grdDetail_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            this.grdDetail.SetBindVarValue("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
        }

        private string mMsg = "";
        private string mCap = "";
        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    e.IsBaseCall = false;
                    INJ0101U01SaveLayoutArgs args = new INJ0101U01SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.GrdMasterItemInfo = GetGrdMasterForSaveLayout();
                    args.GrdDetailItemInfo = GetGrdDetailForSaveLayout();
                    UpdateResult result = CloudService.Instance.Submit<UpdateResult, INJ0101U01SaveLayoutArgs>(args);
                    if (result.ExecutionStatus == ExecutionStatus.Success && result.Result || args.GrdMasterItemInfo.Count <= 0)
                    {
                        this.mMsg = Resources.MSG_001;

                        this.mCap = Resources.CAP_001;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.mMsg = Resources.MSG_002;

                        this.mMsg += "\r\n" + result.Msg;

                        this.mCap = Resources.CAP_002;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ResetLayout();
                    /*try
                    {
                        Service.BeginTransaction();
                        if (this.grdMaster.SaveLayout())
                        {
                            if (this.grdDetail.SaveLayout())
                            {
                                this.mMsg = Resources.MSG_001;

                                this.mCap = Resources.CAP_001;

                                XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                                throw new Exception();
                        }
                        else
                            throw new Exception();

                        Service.CommitTransaction();
                    }
                    catch
                    {
                        Service.RollbackTransaction();
                        this.mMsg = Resources.MSG_002;

                        this.mMsg += "\r\n" + Service.ErrFullMsg;

                        this.mCap = Resources.CAP_002;

                        XMessageBox.Show(this.mMsg, this.mCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }*/

                    break;
            }
        }

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            this.grdDetail.QueryLayout(false);
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            this.grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdMaster_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            /*string cmdText = @"SELECT 'Y' 
                                  FROM DUAL 
                                 WHERE EXISTS ( SELECT A.CODE_TYPE       
                                                  FROM INJ0101 A
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.CODE_TYPE = :f_code_type ) ";*/

            if (e.ChangeValue.ToString() == "")
                return;

            if (e.ColName == "code_type")
            {
                for (int i = 0; i < this.grdMaster.RowCount; i++)
                {
                    if (i == e.RowNumber)
                        continue;

                    if (this.grdMaster.GetItemString(i, e.ColName) == e.ChangeValue.ToString())
                    {
                        XMessageBox.Show(Resources.MSG_003, Resources.CAP_003, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }


                /*BindVarCollection bc = new BindVarCollection();

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_code_type", e.ChangeValue.ToString());

                object dup_yn = Service.ExecuteScalar(cmdText, bc);*/
                INJ0101U01GrdMasterCheckArgs args = new INJ0101U01GrdMasterCheckArgs();
                args.CodeType = e.ChangeValue.ToString();
                INJ0101U01GrdCheckResult result =
                    CloudService.Instance.Submit<INJ0101U01GrdCheckResult, INJ0101U01GrdMasterCheckArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result != "")
                {
                    string dup_yn = result.Result;
                    if (dup_yn == "Y")
                    {
                        bool isDup = true;
                        foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                        {
                            if (dr["code_type"].ToString() == e.ChangeValue.ToString())
                                isDup = false;
                        }

                        if (isDup)
                        {

                            XMessageBox.Show(Resources.MSG_003, Resources.CAP_003, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }

        private void grdDetail_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            /*string cmdText = @"SELECT 'Y' 
                                  FROM DUAL 
                                 WHERE EXISTS ( SELECT A.CODE       
                                                  FROM INJ0102 A 
                                                 WHERE A.HOSP_CODE = :f_hosp_code
                                                   AND A.CODE_TYPE = :f_code_type
                                                   AND A.CODE      = :f_code     ) ";*/

            if (e.ChangeValue.ToString() == "")
                return;

            if (e.ColName == "code")
            {
                for (int i = 0; i < this.grdDetail.RowCount; i++)
                {
                    if (i == e.RowNumber)
                        continue;

                    if (this.grdDetail.GetItemString(i, e.ColName) == e.ChangeValue.ToString())
                    {
                        XMessageBox.Show(Resources.MSG_003, Resources.CAP_003, MessageBoxIcon.Warning);
                        e.Cancel = true;
                        return;
                    }
                }


                /*BindVarCollection bc = new BindVarCollection();

                bc.Add("f_hosp_code", EnvironInfo.HospCode);
                bc.Add("f_code_type", this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"));
                bc.Add("f_code", e.ChangeValue.ToString());

                object dup_yn = Service.ExecuteScalar(cmdText, bc);*/
                INJ0101U01GrdDetailCheckArgs args = new INJ0101U01GrdDetailCheckArgs();
                args.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                args.Code = e.ChangeValue.ToString();
                INJ0101U01GrdCheckResult result =
                    CloudService.Instance.Submit<INJ0101U01GrdCheckResult, INJ0101U01GrdDetailCheckArgs>(args);

                if (result.ExecutionStatus == ExecutionStatus.Success && result.Result != "")
                {
                    string dup_yn = result.Result;
                    if (dup_yn == "Y")
                    {
                        bool isDup = true;
                        foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                        {
                            if (dr["code_type"].ToString() == this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type"))
                            {
                                if (dr["code"].ToString() == e.ChangeValue.ToString())
                                    isDup = false;
                            }
                        }

                        if (isDup)
                        {

                            XMessageBox.Show(Resources.MSG_003, Resources.CAP_003, MessageBoxIcon.Warning);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
        }

        #region XSavePeformer
        private class XSavePeformer : ISavePerformer
        {
            private INJ0101U01 parent = null;

            public XSavePeformer(INJ0101U01 parent)
            {
                this.parent = parent;
            }

            public bool Execute(char callerId, RowDataItem item)
            {
                string cmdText = "";
                object t_chk = "";

                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);
                switch (callerId)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO INJ0101 
                                                 ( SYS_DATE,        SYS_ID,            UPD_DATE,     UPD_ID,    HOSP_CODE ,
                                                   CODE_TYPE,       CODE_TYPE_NAME,    ADMIN_GUBUN,  REMARK   ) 
                                            VALUES 
                                                 ( SYSDATE,         :q_user_id,        SYSDATE,      :q_user_id, :f_hosp_code,
                                                   :f_code_type,    :f_code_type_name, :f_admin_gubun,    :f_remark  )";

                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE INJ0101
                                               SET UPD_ID         = :q_user_id
                                                 , UPD_DATE       = SYSDATE
                                                 , CODE_TYPE_NAME = :f_code_type_name
                                                 , ADMIN_GUBUN    = :f_admin_gubun
                                                 , REMARK         = :f_remark
                                             WHERE HOSP_CODE      = :f_hosp_code 
                                               AND CODE_TYPE      = :f_code_type";

                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE INJ0101
                                             WHERE HOSP_CODE      = :f_hosp_code 
                                               AND CODE_TYPE = :f_code_type";

                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:

                                cmdText = @"INSERT INTO INJ0102 (
                                                  SYS_DATE,        SYS_ID,       UPD_DATE,    UPD_ID,    HOSP_CODE,
                                                  CODE_TYPE,       CODE,         CODE_NAME,   REMARK
                                                ) VALUES (
                                                  SYSDATE,         :q_user_id,   SYSDATE,     :q_user_id, :f_hosp_code,
                                                  :f_code_type,    :f_code,      :f_code_name,       :f_remark)";
                                break;

                            case DataRowState.Modified:

                                cmdText = @"UPDATE INJ0102
                                               SET UPD_ID    = :q_user_id
                                                 , UPD_DATE  = SYSDATE
                                                 , CODE_NAME = :f_code_name
                                                 , REMARK    = :f_remark
                                             WHERE HOSP_CODE = :f_hosp_code 
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code";
                                break;

                            case DataRowState.Deleted:

                                cmdText = @"DELETE INJ0102
                                             WHERE HOSP_CODE = :f_hosp_code 
                                               AND CODE_TYPE = :f_code_type
                                               AND CODE      = :f_code";
                                break;
                        }
                        break;
                }
                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        #endregion

        private void grdMaster_PreEndInitializing(object sender, EventArgs e)
        {
            xEditGridCell3.ExecuteQuery = LoadDataXEditGridCell3;
        }

        #region cloud services

        private List<object[]> LoadGrdMaster(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            INJ0101U01GrdMasterArgs args = new INJ0101U01GrdMasterArgs();
            INJ0101U01GrdMasterResult result = CloudService.Instance.Submit<INJ0101U01GrdMasterResult, INJ0101U01GrdMasterArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INJ0101U01GrdMasterItemInfo item in result.GrdMasterItemInfo)
                {
                    object[] objects = 
				{ 
					item.CodeType, 
					item.CodeTypeName, 
					item.AdminGubun, 
					item.Remark
				};
                    res.Add(objects);
                }
            }
            return res;
        }

        private List<string> CreateGrdDetailParamList()
        {
            List<string> paramList = new List<string>();
            paramList.Add("f_code_type");
            return paramList;
        }

        private List<object[]> LoadGrdDetail(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            INJ0101U01GrdDetailArgs args = new INJ0101U01GrdDetailArgs();
            args.CodeType = bc["f_code_type"] != null ? bc["f_code_type"].VarValue : "";
            INJ0101U01GrdDetailResult result = CloudService.Instance.Submit<INJ0101U01GrdDetailResult, INJ0101U01GrdDetailArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (INJ0101U01GrdDetailItemInfo item in result.GrdDetailItemInfo)
                {
                    object[] objects = 
				    { 
					    item.CodeType, 
					    item.Code, 
					    item.CodeName, 
					    item.Remark
				    };
                    res.Add(objects);
                }
            }
            return res;
        }

        private IList<object[]> LoadDataXEditGridCell3(BindVarCollection var)
        {
            IList<object[]> res = new List<object[]>();
            ComboAdminGubunArgs args = new ComboAdminGubunArgs();
            args.CodeType = "ADMIN_GUBUN";
            //ComboResult comboResult =
            //    CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(Constants.CacheKeyCbo.CACHE_CBO_ADMIN_GUBUN,
            //        args, delegate(ComboResult result)
            //        {
            //            return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
            //                   result.ComboItem != null && result.ComboItem.Count > 0;
            //        });
            ComboResult comboResult = CacheService.Instance.Get<ComboAdminGubunArgs, ComboResult>(args, delegate(ComboResult result)
                    {
                        return result != null && result.ExecutionStatus == ExecutionStatus.Success &&
                               result.ComboItem != null && result.ComboItem.Count > 0;
                    });
            if (comboResult != null && comboResult.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in comboResult.ComboItem)
                {
                    res.Add(new object[] { info.Code, info.CodeName });
                }
            }
            return res;
        }

        private List<INJ0101U01GrdMasterItemInfo> GetGrdMasterForSaveLayout()
        {
            List<INJ0101U01GrdMasterItemInfo> lstResult = new List<INJ0101U01GrdMasterItemInfo>();

            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;
                INJ0101U01GrdMasterItemInfo item = new INJ0101U01GrdMasterItemInfo();
                item.CodeType = grdMaster.GetItemString(i, "code_type");
                item.CodeTypeName = grdMaster.GetItemString(i, "code_type_name");
                item.AdminGubun = grdMaster.GetItemString(i, "admin_gubun");
                item.Remark = grdMaster.GetItemString(i, "remark");

                item.DataRowState = grdMaster.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                {
                    INJ0101U01GrdMasterItemInfo item = new INJ0101U01GrdMasterItemInfo();
                    item.CodeType = Convert.ToString(dr["code_type"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private List<INJ0101U01GrdDetailItemInfo> GetGrdDetailForSaveLayout()
        {
            List<INJ0101U01GrdDetailItemInfo> lstResult = new List<INJ0101U01GrdDetailItemInfo>();

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;
                INJ0101U01GrdDetailItemInfo item = new INJ0101U01GrdDetailItemInfo();
                item.CodeType = this.grdMaster.GetItemString(this.grdMaster.CurrentRowNumber, "code_type");
                item.Code = grdDetail.GetItemString(i, "code");
                item.CodeName = grdDetail.GetItemString(i, "code_name");
                item.Remark = grdDetail.GetItemString(i, "remark");

                item.DataRowState = grdDetail.GetRowState(i).ToString();
                lstResult.Add(item);
            }

            // Delete
            if (null != grdDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                {
                    INJ0101U01GrdDetailItemInfo item = new INJ0101U01GrdDetailItemInfo();
                    item.CodeType = Convert.ToString(dr["code_type"]);
                    item.Code = Convert.ToString(dr["code"]);

                    item.DataRowState = DataRowState.Deleted.ToString();
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        private void ResetLayout()
        {
            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) != DataRowState.Unchanged)
                    grdMaster.QueryLayout(false);
            }

            if (grdMaster.DeletedRowTable != null)
            {
                grdMaster.DeletedRowTable.Clear();
            }

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) != DataRowState.Unchanged)
                    grdDetail.QueryLayout(false);
            }

            if (grdDetail.DeletedRowTable != null)
            {
                grdDetail.DeletedRowTable.Clear();
            }
        }

        #endregion

        private void grdMaster_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

        private void grdDetail_MouseClick(object sender, MouseEventArgs e)
        {
            CheckUpdateMasterData();
        }

    }
}

