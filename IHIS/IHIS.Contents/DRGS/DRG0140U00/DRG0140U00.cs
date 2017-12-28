#region 사용 NameSpace 지정
using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.DRGS.Properties;
using IHIS.Framework;
using System.Collections.Generic;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG0140U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG0140U00 : IHIS.Framework.XScreen
    {
        #region Designer variables(autogen)
        private System.Windows.Forms.Panel pnlBottom;
        private IHIS.Framework.XMstGrid grdMaster;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XMstGrid grdDetail;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XEditGridCell xEditGridCell5;
        private IHIS.Framework.XEditGridCell xEditGridCell6;
        private Splitter splitter1;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;
        #endregion

        #region Constructor
        /// <summary>
        /// DRG0140U00
        /// </summary>
        public DRG0140U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            //this.grdMaster.SavePerformer = new XSavePerformer(this);
            //this.grdDetail.SavePerformer = this.grdMaster.SavePerformer;
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdMaster);
            this.SaveLayoutList.Add(this.grdDetail);

            this.grdMaster.ParamList = new List<string>(new string[] { "f_code", "f_hosp_code", });
            this.grdMaster.ExecuteQuery = GetGrdMst;

            this.grdDetail.ParamList = new List<string>(new string[] { "f_code", "f_hosp_code", });
            this.grdDetail.ExecuteQuery = GetGrdDetail;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0140U00));
            this.grdMaster = new IHIS.Framework.XMstGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdDetail = new IHIS.Framework.XMstGrid();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell5 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell6 = new IHIS.Framework.XEditGridCell();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).BeginInit();
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
            this.xEditGridCell2});
            this.grdMaster.ColPerLine = 2;
            this.grdMaster.Cols = 3;
            this.grdMaster.ExecuteQuery = null;
            this.grdMaster.FixedCols = 1;
            this.grdMaster.FixedRows = 1;
            this.grdMaster.HeaderHeights.Add(27);
            this.grdMaster.Name = "grdMaster";
            this.grdMaster.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdMaster.ParamList")));
            this.grdMaster.RowHeaderVisible = true;
            this.grdMaster.Rows = 2;
            this.grdMaster.Click += new System.EventHandler(this.grdMaster_Click);
            this.grdMaster.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdMaster_GridColumnChanged);
            this.grdMaster.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdMaster_RowFocusChanged);
            this.grdMaster.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdMaster_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellLen = 4;
            this.xEditGridCell1.CellName = "code";
            this.xEditGridCell1.CellWidth = 83;
            this.xEditGridCell1.Col = 1;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "code_name";
            this.xEditGridCell2.CellWidth = 234;
            this.xEditGridCell2.Col = 2;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // pnlBottom
            // 
            this.pnlBottom.AccessibleDescription = null;
            this.pnlBottom.AccessibleName = null;
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.BackgroundImage = null;
            this.pnlBottom.Controls.Add(this.btnList);
            this.pnlBottom.Font = null;
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnList
            // 
            this.btnList.AccessibleDescription = null;
            this.btnList.AccessibleName = null;
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.BackgroundImage = null;
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdDetail
            // 
            resources.ApplyResources(this.grdDetail, "grdDetail");
            this.grdDetail.CallerID = '2';
            this.grdDetail.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell4,
            this.xEditGridCell5,
            this.xEditGridCell6});
            this.grdDetail.ColPerLine = 2;
            this.grdDetail.Cols = 3;
            this.grdDetail.ExecuteQuery = null;
            this.grdDetail.FixedCols = 1;
            this.grdDetail.FixedRows = 1;
            this.grdDetail.HeaderHeights.Add(27);
            this.grdDetail.MasterLayout = this.grdMaster;
            this.grdDetail.Name = "grdDetail";
            this.grdDetail.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDetail.ParamList")));
            this.grdDetail.RowHeaderVisible = true;
            this.grdDetail.Rows = 2;
            this.grdDetail.Click += new System.EventHandler(this.grdDetail_Click);
            this.grdDetail.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDetail_GridColumnChanged);
            this.grdDetail.RowFocusChanged += new IHIS.Framework.RowFocusChangedEventHandler(this.grdDetail_RowFocusChanged);
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellLen = 4;
            this.xEditGridCell4.CellName = "code";
            this.xEditGridCell4.Col = -1;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            this.xEditGridCell4.IsUpdatable = false;
            this.xEditGridCell4.IsVisible = false;
            this.xEditGridCell4.Row = -1;
            // 
            // xEditGridCell5
            // 
            this.xEditGridCell5.CellLen = 5;
            this.xEditGridCell5.CellName = "code1";
            this.xEditGridCell5.CellWidth = 83;
            this.xEditGridCell5.Col = 1;
            this.xEditGridCell5.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell5, "xEditGridCell5");
            this.xEditGridCell5.IsUpdatable = false;
            // 
            // xEditGridCell6
            // 
            this.xEditGridCell6.CellLen = 100;
            this.xEditGridCell6.CellName = "code_name1";
            this.xEditGridCell6.CellWidth = 232;
            this.xEditGridCell6.Col = 2;
            this.xEditGridCell6.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell6, "xEditGridCell6");
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
            // DRG0140U00
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.grdDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grdMaster);
            this.Controls.Add(this.pnlBottom);
            this.Name = "DRG0140U00";
            ((System.ComponentModel.ISupportInitialize)(this.grdMaster)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetail)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            grdDetail.SetRelationKey("code", "code");
            grdDetail.SetRelationTable("DRG0141");

            grdMaster.QueryLayout(false);

            base.OnLoad(e);

            //MED-7313
            if (UserInfo.HospCode != "NTA")
            {
                DisableCRUD();
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    this.CurrMQLayout = this.grdMaster;
                    break;

                case FunctionType.Update:
                    e.IsBaseCall = false;

                    for (int i = 0; i < grdMaster.RowCount; i++)
                    {
                        if (grdMaster.GetItemString(i, "code").Trim() == "")
                        {
                            XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                            grdMaster.SetFocusToItem(i, "code");
                            return;
                        }
                    }

                    for (int i = 0; i < grdDetail.RowCount; i++)
                    {
                        if (grdDetail.GetItemString(i, "code1").Trim() == "")
                        {
                            XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                            grdDetail.SetFocusToItem(i, "code1");
                            return;
                        }
                    }

                    #region deleted by Cloud
                    //try
                    //{
                    //    Service.BeginTransaction();
                    //    if (this.grdMaster.SaveLayout())
                    //    {
                    //        if (!this.grdDetail.SaveLayout())
                    //        {
                    //            throw new Exception(Service.ErrFullMsg);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        throw new Exception(Service.ErrFullMsg);
                    //    }
                    //}
                    //catch (Exception xe)
                    //{
                    //    Service.RollbackTransaction();
                    //    XMessageBox.Show(xe.Message + "\n\r" + xe.StackTrace, Resources.MSG003_CAP, MessageBoxIcon.Hand);
                    //    return;
                    //}
                    //Service.CommitTransaction();
                    #endregion

                    // Cloud updated code START
                    DRG0140U00SaveLayoutArgs args = new DRG0140U00SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = this.GetListDataForSaveLayout();
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, DRG0140U00SaveLayoutArgs>(args);

                    if (res.ExecutionStatus != ExecutionStatus.Success)
                    {
                        throw new Exception(res.Msg);
                    }
                    // Cloud updated code END

                    grdMaster.QueryLayout(false);
                    break;

                //case FunctionType.Delete:
                //    e.IsBaseCall = false;
                //    break;

                default:
                    break;
            }
        }

        private void grdMaster_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            grdDetail.SetBindVarValue("f_code", grdMaster.GetItemString(e.CurrentRow, "code"));
            grdDetail.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDetail_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
        }

        private void grdMaster_QueryStarting(object sender, CancelEventArgs e)
        {
            grdMaster.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdMaster_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName != "code") return;

            #region deleted by Cloud
//            string cmdText = @"";
//            for (int i = 0; i < grdMaster.RowCount; i++)
//            {
//                cmdText = @"SELECT CODE
//                              FROM DRG0140
//                             WHERE CODE      = :f_code
//                               AND HOSP_CODE = :f_hosp_code";
//                BindVarCollection bindVars = new BindVarCollection();
//                bindVars.Add("f_code", grdMaster.GetItemString(i, "code"));
//                bindVars.Add("f_hosp_code", EnvironInfo.HospCode);

//                object retVal = Service.ExecuteScalar(cmdText, bindVars);

//                if (!TypeCheck.IsNull(retVal))
//                {
//                    if (e.ChangeValue.Equals(retVal))
//                    {
//                        XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG001_CAP, MessageBoxIcon.Hand);
//                        e.Cancel = true;
//                        return;
//                    }
//                }
//            }
//            e.Cancel = false;
            #endregion

            // Cloud updated code START
            List<DRG0140U00GrdColumnChangedInfo> lstItem = new List<DRG0140U00GrdColumnChangedInfo>();
            for (int j = 0; j < grdMaster.RowCount; j++)
            {
                DRG0140U00GrdColumnChangedInfo item = new DRG0140U00GrdColumnChangedInfo();
                item.Code = grdMaster.GetItemString(j, "code");

                lstItem.Add(item);
            }

            DRG0140U00GrdMasterColumnChangedArgs args = new DRG0140U00GrdMasterColumnChangedArgs();
            args.ChangedValue = e.ChangeValue.ToString();
            args.GmcItem = lstItem;
            DRG0140U00GrdColumnChangedResult res = CloudService.Instance.Submit<DRG0140U00GrdColumnChangedResult,
                DRG0140U00GrdMasterColumnChangedArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                e.Cancel = res.Result;
                return;
            }

            e.Cancel = false;
            // Cloud updated code END
        }

        private void grdDetail_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName != "code1") return;

            #region deleted by Cloud
//            string cmdText = "";
//            object retVal = null;
//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//            for (int j = 0; j < grdDetail.RowCount; j++)
//            {
//                cmdText = @"SELECT CODE1
//                              FROM DRG0141
//                             WHERE CODE      = :f_code
//                               AND CODE1     = :f_code1
//                               AND HOSP_CODE = :f_hosp_code";
//                bindVars.Remove("code");
//                bindVars.Remove("code1");
//                bindVars.Add("f_code", grdDetail.GetItemString(j, "code"));
//                bindVars.Add("f_code1", grdDetail.GetItemString(j, "code1"));

//                retVal = Service.ExecuteScalar(cmdText, bindVars);

//                if (!TypeCheck.IsNull(retVal))
//                {
//                    if (e.ChangeValue.Equals(retVal))
//                    {
//                        XMessageBox.Show(Resources.MSG005_MSG, Resources.MSG001_CAP, MessageBoxIcon.Hand);
//                        e.Cancel = true;
//                        return;
//                    }
//                }
//            }
//            e.Cancel = false;
            #endregion

            // Cloud updated code START
            List<DRG0140U00GrdColumnChangedInfo> lstItem = new List<DRG0140U00GrdColumnChangedInfo>();
            for (int j = 0; j < grdDetail.RowCount; j++)
            {
                DRG0140U00GrdColumnChangedInfo item = new DRG0140U00GrdColumnChangedInfo();
                item.Code = grdDetail.GetItemString(j, "code");
                item.Code1 = grdDetail.GetItemString(j, "code1");

                lstItem.Add(item);
            }

            DRG0140U00GrdDetailColumnChangedArgs args = new DRG0140U00GrdDetailColumnChangedArgs();
            args.ChangedValue = e.ChangeValue.ToString();
            args.GdcItem = lstItem;
            DRG0140U00GrdColumnChangedResult res = CloudService.Instance.Submit<DRG0140U00GrdColumnChangedResult,
                DRG0140U00GrdDetailColumnChangedArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                e.Cancel = res.Result;
                return;
            }

            e.Cancel = false;
            // Cloud updated code END
        }

        #endregion

        #region Methods(private)

        #endregion

        /* ====================================== SAVEPERFORMER ====================================== */
        #region deleted by Cloud
        /*
        #region [ XSavePerformer                                                                                /]
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG0140U00 parent = null;
            public XSavePerformer(DRG0140U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (callerID)
                {
                    case '1':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO DRG0140 ( SYS_DATE,   SYS_ID,
                                                                  CODE,       CODE_NAME,      HOSP_CODE
                                                       ) VALUES ( SYSDATE,    :q_user_id,
                                                                  :f_code,    :f_code_name,   :f_hosp_code)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG0140
                                               SET UPD_ID    = :q_user_id
                                                 , UPD_DATE  = SYSDATE
                                                 , CODE_NAME = :f_code_name
                                             WHERE CODE      = :f_code
                                               AND HOSP_CODE = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE DRG0140
                                             WHERE CODE = :f_code
                                               AND HOSP_CODE = :f_hosp_code";
                                break;
                        }
                        break;

                    case '2':
                        switch (item.RowState)
                        {
                            case DataRowState.Added:
                                cmdText = @"INSERT INTO DRG0141 ( SYS_DATE,        SYS_ID,         CODE    ,
                                                                  CODE1,           CODE_NAME1,     HOSP_CODE
                                                       ) VALUES ( SYSDATE,         :q_user_id,     :f_code,
                                                                  :f_code1,        :f_code_name1,  :f_hosp_code)";
                                break;
                            case DataRowState.Modified:
                                cmdText = @"UPDATE DRG0141
                                               SET UPD_ID      = :q_user_id
                                                 , UPD_DATE    = SYSDATE
                                                 , CODE_NAME1  = :f_code_name1
                                             WHERE CODE        = :f_code
                                               AND CODE1       = :f_code1
                                               AND HOSP_CODE   = :f_hosp_code";
                                break;
                            case DataRowState.Deleted:
                                cmdText = @"DELETE DRG0141
                                             WHERE CODE        = :f_code
                                               AND CODE1       = :f_code1
                                               AND HOSP_CODE   = :f_hosp_code";
                                break;
                        }
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        */
        #endregion
        /* ====================================== SAVEPERFORMER ====================================== */

        #region Cloud updated code

        #region GetGrdMst
        /// <summary>
        /// GetGrdMst
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdMst(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DRG0140U00GrdMasterArgs args = new DRG0140U00GrdMasterArgs();
            args.Code = bvc["f_code"].VarValue;
            DRG0140U00GrdMasterResult res = CloudService.Instance.Submit<DRG0140U00GrdMasterResult, DRG0140U00GrdMasterArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo item in res.GrdMasterItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.CodeName,
                    });
                }
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

            DRG0140U00GrdDetailArgs args = new DRG0140U00GrdDetailArgs();
            args.Code = bvc["f_code"].VarValue;
            DRG0140U00GrdDetailResult res = CloudService.Instance.Submit<DRG0140U00GrdDetailResult, DRG0140U00GrdDetailArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (DRG0140U00GrdDetailInfo item in res.GrdDetailItem)
                {
                    lObj.Add(new object[]
                    {
                        item.Code,
                        item.Code1,
                        item.CodeName1,
                    });
                }
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<DRG0140U00SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<DRG0140U00SaveLayoutInfo> lstData = new List<DRG0140U00SaveLayoutInfo>();

            #region grdMaster

            for (int i = 0; i < grdMaster.RowCount; i++)
            {
                if (grdMaster.GetRowState(i) == DataRowState.Unchanged) continue;

                DRG0140U00SaveLayoutInfo item = new DRG0140U00SaveLayoutInfo();
                item.CallerId       = "1";
                item.Code           = grdMaster.GetItemString(i, "code");
                item.CodeName       = grdMaster.GetItemString(i, "code_name");
                item.RowState       = grdMaster.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdMaster.DeletedRowTable)
            {
                foreach (DataRow dr in grdMaster.DeletedRowTable.Rows)
                {
                    DRG0140U00SaveLayoutInfo item = new DRG0140U00SaveLayoutInfo();
                    item.CallerId = "1";
                    item.Code = Convert.ToString(dr["code"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            #endregion

            #region grdDetail

            for (int i = 0; i < grdDetail.RowCount; i++)
            {
                if (grdDetail.GetRowState(i) == DataRowState.Unchanged) continue;

                DRG0140U00SaveLayoutInfo item = new DRG0140U00SaveLayoutInfo();
                item.CallerId       = "2";
                item.Code           = grdMaster.GetItemString(grdMaster.CurrentRowNumber, "code");
                item.Code1          = grdDetail.GetItemString(i, "code1");
                item.CodeName1      = grdDetail.GetItemString(i, "code_name1");
                item.RowState       = grdDetail.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdDetail.DeletedRowTable)
            {
                foreach (DataRow dr in grdDetail.DeletedRowTable.Rows)
                {
                    DRG0140U00SaveLayoutInfo item = new DRG0140U00SaveLayoutInfo();
                    item.CallerId = "2";
                    item.Code = Convert.ToString(dr["code"]);
                    item.Code1 = Convert.ToString(dr["code1"]);
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            #endregion

            return lstData;
        }
        #endregion

        private void EnableCRUD()
        {
            this.btnList.SetEnabled(FunctionType.Insert, true);
            this.btnList.SetEnabled(FunctionType.Delete, true);
            this.btnList.SetEnabled(FunctionType.Update, true);
            this.btnList.SetEnabled(FunctionType.Reset, true);
        }

        private void DisableCRUD()
        {
            this.btnList.SetEnabled(FunctionType.Insert, false);
            this.btnList.SetEnabled(FunctionType.Delete, false);
            this.btnList.SetEnabled(FunctionType.Update, false);
            this.btnList.SetEnabled(FunctionType.Reset, false);
            this.grdMaster.ReadOnly = true;
        }

        #endregion

        private void grdMaster_Click(object sender, EventArgs e)
        {
            //MED-7313
            if (UserInfo.HospCode != "NTA")
            {
                DisableCRUD();
            }
        }

        private void grdDetail_Click(object sender, EventArgs e)
        {
            EnableCRUD();
        }
    }
}

