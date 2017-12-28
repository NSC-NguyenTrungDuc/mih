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
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Drgs;
using IHIS.CloudConnector.Contracts.Models.Drgs;
using IHIS.CloudConnector.Contracts.Results.Drgs;
using IHIS.CloudConnector.Contracts.Results.System;
using System.Collections.Generic;
#endregion

namespace IHIS.DRGS
{
    /// <summary>
    /// DRG0130U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public class DRG0130U00 : IHIS.Framework.XScreen
    {
        private System.Windows.Forms.Panel panel1;
        private IHIS.Framework.XButtonList btnList;
        private IHIS.Framework.XEditGrid grdDrg0130;
        private IHIS.Framework.XEditGridCell xEditGridCell1;
        private IHIS.Framework.XEditGridCell xEditGridCell2;
        private IHIS.Framework.XEditGridCell xEditGridCell3;
        private IHIS.Framework.XEditGridCell xEditGridCell4;
        private IHIS.Framework.XComboItem xComboItem1;
        private IHIS.Framework.XComboItem xComboItem2;
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public DRG0130U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //저장 수행자 Set
            //this.grdDrg0130.SavePerformer = new XSavePerformer(this);
            //저장 Layout List Set
            this.SaveLayoutList.Add(this.grdDrg0130);

            // Cloud updated
            grdDrg0130.ParamList = new List<string>(new string[] { "f_caution_code" });
            grdDrg0130.ExecuteQuery = GetGrdDrg0130;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DRG0130U00));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnList = new IHIS.Framework.XButtonList();
            this.grdDrg0130 = new IHIS.Framework.XEditGrid();
            this.xEditGridCell1 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell2 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell3 = new IHIS.Framework.XEditGridCell();
            this.xEditGridCell4 = new IHIS.Framework.XEditGridCell();
            this.xComboItem1 = new IHIS.Framework.XComboItem();
            this.xComboItem2 = new IHIS.Framework.XComboItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0130)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnList);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnList
            // 
            resources.ApplyResources(this.btnList, "btnList");
            this.btnList.Name = "btnList";
            this.btnList.PerformerType = IHIS.Framework.FunctionPerformerType.Entry;
            this.btnList.ButtonClick += new IHIS.Framework.ButtonClickEventHandler(this.btnList_ButtonClick);
            // 
            // grdDrg0130
            // 
            this.grdDrg0130.CellInfos.AddRange(new IHIS.Framework.XGridCell[] {
            this.xEditGridCell1,
            this.xEditGridCell2,
            this.xEditGridCell3,
            this.xEditGridCell4});
            this.grdDrg0130.ColPerLine = 4;
            this.grdDrg0130.Cols = 5;
            resources.ApplyResources(this.grdDrg0130, "grdDrg0130");
            this.grdDrg0130.ExecuteQuery = null;
            this.grdDrg0130.FixedCols = 1;
            this.grdDrg0130.FixedRows = 1;
            this.grdDrg0130.HeaderHeights.Add(28);
            this.grdDrg0130.Name = "grdDrg0130";
            this.grdDrg0130.ParamList = ((System.Collections.Generic.List<string>)(resources.GetObject("grdDrg0130.ParamList")));
            this.grdDrg0130.RowHeaderVisible = true;
            this.grdDrg0130.Rows = 2;
            this.grdDrg0130.GridColumnChanged += new IHIS.Framework.GridColumnChangedEventHandler(this.grdDrg0130_GridColumnChanged);
            this.grdDrg0130.QueryStarting += new System.ComponentModel.CancelEventHandler(this.grdDrg0130_QueryStarting);
            // 
            // xEditGridCell1
            // 
            this.xEditGridCell1.CellName = "caution_code";
            this.xEditGridCell1.CellWidth = 91;
            this.xEditGridCell1.Col = 2;
            this.xEditGridCell1.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell1, "xEditGridCell1");
            this.xEditGridCell1.IsUpdatable = false;
            // 
            // xEditGridCell2
            // 
            this.xEditGridCell2.CellLen = 100;
            this.xEditGridCell2.CellName = "caution_name";
            this.xEditGridCell2.CellWidth = 318;
            this.xEditGridCell2.Col = 3;
            this.xEditGridCell2.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell2, "xEditGridCell2");
            // 
            // xEditGridCell3
            // 
            this.xEditGridCell3.CellLen = 100;
            this.xEditGridCell3.CellName = "caution_name2";
            this.xEditGridCell3.CellWidth = 401;
            this.xEditGridCell3.Col = 4;
            this.xEditGridCell3.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell3, "xEditGridCell3");
            // 
            // xEditGridCell4
            // 
            this.xEditGridCell4.CellName = "job_type";
            this.xEditGridCell4.CellWidth = 93;
            this.xEditGridCell4.Col = 1;
            this.xEditGridCell4.ComboItems.AddRange(new IHIS.Framework.XComboItem[] {
            this.xComboItem1,
            this.xComboItem2});
            this.xEditGridCell4.EditorStyle = IHIS.Framework.XCellEditorStyle.ComboBox;
            this.xEditGridCell4.ExecuteQuery = null;
            resources.ApplyResources(this.xEditGridCell4, "xEditGridCell4");
            // 
            // xComboItem1
            // 
            resources.ApplyResources(this.xComboItem1, "xComboItem1");
            this.xComboItem1.ValueItem = "1";
            // 
            // xComboItem2
            // 
            resources.ApplyResources(this.xComboItem2, "xComboItem2");
            this.xComboItem2.ValueItem = "2";
            // 
            // DRG0130U00
            // 
            this.Controls.Add(this.grdDrg0130);
            this.Controls.Add(this.panel1);
            this.Name = "DRG0130U00";
            resources.ApplyResources(this, "$this");
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDrg0130)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void btnList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                    e.IsBaseCall = false;

                    for (int i = 0; i < grdDrg0130.RowCount; i++)
                    {
                        if (TypeCheck.IsNull(grdDrg0130.GetItemString(i, "caution_code").Trim()))
                        {
                            XMessageBox.Show(Resources.MSG001_MSG, Resources.MSG001_CAP, MessageBoxIcon.Warning);
                            grdDrg0130.SetFocusToItem(i, "caution_code");
                            return;
                        }
                    }

                    //if (!grdDrg0130.SaveLayout())
                    //{
                    //    XMessageBox.Show(Service.ErrFullMsg);
                    //    return;
                    //}

                    // Cloud updated code START
                    List<DRG0130U00SaveLayoutInfo> lstData = GetListDataForSaveLayout();
                    if (lstData.Count < 1) return;

                    DRG0130U00SaveLayoutArgs args = new DRG0130U00SaveLayoutArgs();
                    args.UserId = UserInfo.UserID;
                    args.SaveLayoutItem = lstData;
                    UpdateResult res = CloudService.Instance.Submit<UpdateResult, DRG0130U00SaveLayoutArgs>(args);

                    if (null == res || res.ExecutionStatus != IHIS.CloudConnector.Contracts.Results.ExecutionStatus.Success || !res.Result)
                    {
                        //XMessageBox.Show(Service.ErrFullMsg);
                        XMessageBox.Show(Resources.MSG004_MSG, Resources.MSG004_CAP, MessageBoxIcon.Information);
                        return;
                    }
                    // Cloud updated code END

                    XMessageBox.Show(Resources.MSG002_MSG, Resources.MSG002_CAP, MessageBoxIcon.Information);
                    grdDrg0130.QueryLayout(true);
                    break;

                default:
                    break;
            }
        }

        private void grdDrg0130_QueryStarting(object sender, CancelEventArgs e)
        {
            grdDrg0130.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
        }

        private void grdDrg0130_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName != "caution_code") return;

            #region deleted by CloudService
//            string cmdText = @"SELECT CAUTION_CODE
//                                 FROM DRG0130
//                                WHERE CAUTION_CODE  = :f_caution_code
//                                  AND HOSP_CODE     = :f_hosp_code";
//            BindVarCollection bindVars = new BindVarCollection();
//            bindVars.Add("f_caution_code", e.ChangeValue.ToString());
//            bindVars.Add("f_hosp_code", EnvironInfo.HospCode);
//            object retVal = Service.ExecuteScalar(cmdText, bindVars);

//            if (!TypeCheck.IsNull(retVal))
//            {
//                XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Hand);
//                e.Cancel = true;
//            }
//            else
//            {
//                e.Cancel = false;
//            }
            #endregion

            // Cloud updated code START
            DrgsDRG0130U00CautionCodeArgs args = new DrgsDRG0130U00CautionCodeArgs();
            args.CautionCode = e.ChangeValue.ToString();
            DrgsDRG0130U00CautionCodeResult res = CloudService.Instance.Submit<DrgsDRG0130U00CautionCodeResult,
                DrgsDRG0130U00CautionCodeArgs>(args);

            if (null != res && !TypeCheck.IsNull(res.CautionCode))
            {
                XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG003_CAP, MessageBoxIcon.Hand);
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
            // Cloud updated code END
        }

        // Deleted by CloudService
        /* ====================================== SAVEPERFORMER ====================================== */
        #region [ XSavePerformer                                                                                ]
        /*
        private class XSavePerformer : IHIS.Framework.ISavePerformer
        {
            private DRG0130U00 parent = null;
            public XSavePerformer(DRG0130U00 parent)
            {
                this.parent = parent;
            }
            public bool Execute(char callerID, RowDataItem item)
            {
                string cmdText = "";
                //Grid에서 넘어온 Bind 변수에 f_user_id SET
                item.BindVarList.Add("q_user_id", UserInfo.UserID);
                item.BindVarList.Add("f_hosp_code", EnvironInfo.HospCode);

                switch (item.RowState)
                {
                    case DataRowState.Added:
                        cmdText = @"INSERT INTO DRG0130 (
                                                         CAUTION_CODE 
                                                        ,CAUTION_NAME 
                                                        ,CAUTION_NAME2
                                                        ,JOB_TYPE
                                                        ,SYS_DATE
                                                        ,SYS_ID
                                                        ,HOSP_CODE
                                                      ) VALUES (
                                                         :f_caution_code          
                                                        ,:f_caution_name          
                                                        ,:f_caution_name2
                                                        ,:f_job_type
                                                        ,SYSDATE
                                                        ,:q_user_id
                                                        ,:f_hosp_code
                                                        )";
                        break;

                    case DataRowState.Modified:
                        cmdText = @"UPDATE DRG0130             
                                       SET CAUTION_NAME  = :f_caution_name            
                                          ,CAUTION_NAME2 = :f_caution_name2     
                                          ,JOB_TYPE      = :f_job_type
                                          ,UPD_ID        = :q_user_id
                                          ,UPD_DATE      = SYSDATE
                                     WHERE CAUTION_CODE  = :f_caution_code
                                       AND HOSP_CODE     = :f_hosp_code";
                        break;

                    case DataRowState.Deleted:
                        cmdText = @"DELETE DRG0130
                                     WHERE CAUTION_CODE = :f_caution_code
                                       AND HOSP_CODE    = :f_hosp_code";
                        break;
                }

                return Service.ExecuteNonQuery(cmdText, item.BindVarList);
            }
        }
        */
        #endregion
        /* ====================================== SAVEPERFORMER ====================================== */

        #region Cloud updated code

        #region GetGrdDrg0130
        /// <summary>
        /// GetGrdDrg0130
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdDrg0130(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            DrgsDRG0130U00GrdDrg0130Args args = new DrgsDRG0130U00GrdDrg0130Args();
            args.CautionCode = bvc["f_caution_code"].VarValue;
            DrgsDRG0130U00GrdDrg0130Result res = CloudService.Instance.Submit<DrgsDRG0130U00GrdDrg0130Result,
                DrgsDRG0130U00GrdDrg0130Args>(args);

            if (null != res)
            {
                foreach (DrgsDRG0130U00GrdDrg0130ListItemInfo item in res.GrdDrg0130List)
                {
                    lObj.Add(new object[]
                    {
                        item.CautionCode,
                        item.CautionName,
                        item.CautionName2,
                        item.JobType,
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
        private List<DRG0130U00SaveLayoutInfo> GetListDataForSaveLayout()
        {
            List<DRG0130U00SaveLayoutInfo> lstData = new List<DRG0130U00SaveLayoutInfo>();

            for (int i = 0; i < grdDrg0130.RowCount; i++)
            {
                if (grdDrg0130.GetRowState(i) == DataRowState.Unchanged) continue;

                DRG0130U00SaveLayoutInfo item = new DRG0130U00SaveLayoutInfo();

                item.CautionCode        = grdDrg0130.GetItemString(i, "caution_code");
                item.CautionName        = grdDrg0130.GetItemString(i, "caution_name");
                item.CautionName2       = grdDrg0130.GetItemString(i, "caution_name2");
                item.JobType            = grdDrg0130.GetItemString(i, "job_type");
                item.UserId             = UserInfo.UserID;
                item.RowState           = grdDrg0130.GetRowState(i).ToString();

                lstData.Add(item);
            }

            if (null != grdDrg0130.DeletedRowTable)
            {
                foreach (DataRow dr in grdDrg0130.DeletedRowTable.Rows)
                {
                    DRG0130U00SaveLayoutInfo item = new DRG0130U00SaveLayoutInfo();

                    item.CautionCode = Convert.ToString(dr["caution_code"]);
                    item.CautionName = Convert.ToString(dr["caution_name"]);
                    item.CautionName2 = Convert.ToString(dr["caution_name2"]);
                    item.JobType = Convert.ToString(dr["job_type"]);
                    item.UserId = UserInfo.UserID;
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #endregion
    }
}