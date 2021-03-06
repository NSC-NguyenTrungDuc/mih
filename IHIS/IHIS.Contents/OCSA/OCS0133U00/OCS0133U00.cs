using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using IHIS.Framework;
using IHIS.OCSA.Properties;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Ocsa;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using IHIS.CloudConnector.Contracts.Results.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.System;

namespace IHIS.OCSA
{
    /// <summary>
    /// OCS0133U00에 대한 요약 설명입니다.
    /// </summary>
    [ToolboxItem(false)]
    public partial class OCS0133U00 : IHIS.Framework.XScreen
    {
        #region Fields
        //Message처리
        string mbxMsg = "", mbxCap = "";

        bool isgrdOCS0133Save = false;
        bool isSaved0133 = false;

        string mHospCode = EnvironInfo.HospCode;
        #endregion

        #region Constructor
        /// <summary>
        /// OCS0133U00
        /// </summary>
        public OCS0133U00()
        {
            // 이 호출은 Windows Form 디자이너에 필요합니다.
            InitializeComponent();

            //SaveLayoutList.Add(grdOCS0133);
            //grdOCS0133.SavePerformer = new XSavePerformer(this);

            // updated by Cloud
            InitializeCloud();

            //https://sofiamedix.atlassian.net/browse/MED-15157
            if (NetInfo.Language == LangMode.En)
            {
                SetSizeForColumn();
            }
        }

        private void SetSizeForColumn()
        {
            grdOCS0133.AutoSizeColumn(xEditGridCell3.Col, 60);
            grdOCS0133.AutoSizeColumn(xEditGridCell4.Col, 50);
            grdOCS0133.AutoSizeColumn(xEditGridCell11.Col, 85);
            grdOCS0133.AutoSizeColumn(xEditGridCell7.Col, 95);
            grdOCS0133.AutoSizeColumn(xEditGridCell8.Col, 96);
            grdOCS0133.AutoSizeColumn(xEditGridCell9.Col, 55);
           
        }
        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PostCallHelper.PostCall(new PostMethod(PostLoad));
        }

        private void xButtonList1_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            SetMsg("");
            switch (e.Func)
            {
                case FunctionType.Insert:
                    e.IsBaseCall = false;
                    DataGridCell chkCell = GetEmptyNewRow(CurrMSLayout);
                    if (chkCell.RowNumber < 0)
                    {
                        int currentRow = grdOCS0133.InsertRow();
                        grdOCS0133.SetItemValue(currentRow, "specimen_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "suryang_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "ord_danui_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "dv_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "nalsu_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "jusa_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "bogyong_code_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "toiwon_drg_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "portable_cr_yn", "N");
                        grdOCS0133.SetItemValue(currentRow, "amt_cr_yn", "N");
                    }
                    else
                    {
                        e.IsBaseCall = false;
                        ((XEditGrid)CurrMSLayout).SetFocusToItem(chkCell.RowNumber, chkCell.ColumnNumber);
                    }
                    break;
                case FunctionType.Update:
                    // Updated by Cloud
                    e.IsBaseCall = false;
                    DoUpdate();
                    break;
                default:
                    break;
            }
        }

        private void xButtonList1_PostButtonClick(object sender, IHIS.Framework.PostButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Insert:
                    break;
                case FunctionType.Update:
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0133_GridColumnChanged(object sender, IHIS.Framework.GridColumnChangedEventArgs e)
        {
            e.Cancel = false;
            switch (e.ColName)
            {
                case "input_control":
                    if (e.ChangeValue.ToString().Trim() == "") break;

                    // 조건조회로 Data를 가져오는 경우 아래경우 다 check
                    // 중복 Check
                    // 현재 화면
                    for (int i = 0; i < grdOCS0133.RowCount; i++)
                    {
                        if (i != e.RowNumber)
                        {
                            if (grdOCS0133.GetItemString(i, "input_control").Trim() == e.ChangeValue.ToString().Trim())
                            {
                                mbxMsg = Resources.MSG001_MSG;
                                mbxCap = "";
                                XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                                e.Cancel = true;
                            }
                        }
                    }

                    if (e.Cancel) break;

                    // Delete Table Check
                    // 현재 화면상에도 없으면서 DeleteTable에 존재하면 Not 중복
                    if (grdOCS0133.DeletedRowTable != null)
                    {
                        foreach (DataRow row in grdOCS0133.DeletedRowTable.Rows)
                        {
                            if (row[e.ColName].ToString() == e.ChangeValue.ToString())
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void grdOCS0133_SaveEnd(object sender, IHIS.Framework.SaveEndEventArgs e)
        {
            isgrdOCS0133Save = e.IsSuccess;
            isSaved0133 = true;

            if (isSaved0133)
            {
                if (isgrdOCS0133Save)
                {
                    mbxMsg = Resources.MSG002_MSG;
                    SetMsg(mbxMsg);
                }
                else
                {
                    mbxMsg = Resources.MSG003_MSG;
                    mbxMsg = mbxMsg + Service.ErrMsg;
                    mbxCap = "Save Error";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                }

                isgrdOCS0133Save = false;
                isSaved0133 = false;
            }
        }

        private void grdOCS0133_SaveStarting(object sender, GridRecordEventArgs e)
        {
            AcceptData();

            CancelEventArgs ca = new CancelEventArgs(true);

            //grdOCS0133
            for (int rowIndex = 0; rowIndex < grdOCS0133.RowCount; rowIndex++)
            {
                if (grdOCS0133.LayoutTable.Rows[rowIndex].RowState == DataRowState.Added)
                {
                    //Key값이 없으면 삭제처리
                    if (grdOCS0133.GetItemString(rowIndex, "input_control").Trim() == "")
                    {
                        grdOCS0133.DeleteRow(rowIndex);
                        rowIndex = rowIndex - 1;
                        continue;
                    }
                }

                if (grdOCS0133.GetItemString(rowIndex, "input_control_name").Trim() == "")
                {
                    mbxMsg = Resources.MSG004_MSG;
                    mbxCap = "";
                    XMessageBox.Show(mbxMsg, mbxCap, MessageBoxIcon.Warning);
                    grdOCS0133.SetFocusToItem(rowIndex, "input_control_name");
                    ca.Cancel = true;
                    return;
                }
            }
        }

        private void grdOCS0133_QueryStarting(object sender, CancelEventArgs e)
        {
            grdOCS0133.SetBindVarValue("f_hosp_code", mHospCode);

            // updated by Cloud
            grdOCS0133.SetBindVarValue("f_user_info", UserInfo.UserGroup.Substring(0, 3));
        }

        #endregion

        #region Methods(private)

        private void PostLoad()
        {
            //Set Current Grid
            this.CurrMSLayout = this.grdOCS0133;
            this.CurrMQLayout = this.grdOCS0133;

            #region deleted by Cloud
            //            if (UserInfo.UserGroup.Substring(0, 3) == "ADM")
            //            {
            //                grdOCS0133.QuerySQL = grdOCS0133.QuerySQL + " ORDER BY A.INPUT_CONTROL";
            //            }
            //            else
            //            {
            //                grdOCS0133.QuerySQL = grdOCS0133.QuerySQL +
            //                     @" AND A.INPUT_CONTROL NOT IN('a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z')
            //                     ORDER BY A.INPUT_CONTROL";
            //            }
            #endregion

            grdOCS0133.SetBindVarValue("f_input_control", "");
            grdOCS0133.QueryLayout(false);
        }

        private DataGridCell GetEmptyNewRow(object aGrd)
        {
            DataGridCell celReturn = new DataGridCell(-1, -1);

            if (aGrd == null) return celReturn;

            XEditGrid grdChk = null;

            try
            {
                grdChk = (XEditGrid)aGrd;
            }
            catch
            {
                return celReturn;
            }

            foreach (XEditGridCell cell in grdChk.CellInfos)
            {
                // NotNull Check
                if (cell.IsNotNull && cell.IsVisible && !cell.IsReadOnly)
                {
                    for (int rowIndex = 0; rowIndex < grdChk.RowCount; rowIndex++)
                    {
                        if (grdChk.GetRowState(rowIndex) == DataRowState.Added && TypeCheck.IsNull(grdChk.GetItemString(rowIndex, cell.CellName)))
                        {
                            celReturn.ColumnNumber = cell.Col;
                            celReturn.RowNumber = rowIndex;
                            break;
                        }
                    }

                    if (celReturn.RowNumber < 0)
                        continue;
                    else
                        break;
                }
            }
            return celReturn;
        }

        #endregion

        #region Cloud updated code

        #region InitializeCloud
        /// <summary>
        /// InitializeCloud
        /// </summary>
        private void InitializeCloud()
        {
            grdOCS0133.ParamList = new List<string>(new string[] { "f_input_control", "f_user_info", });
            grdOCS0133.ExecuteQuery = GetGrdOCS0133;
        }
        #endregion

        #region GetGrdOCS0133
        /// <summary>
        /// GetGrdOCS0133
        /// </summary>
        /// <param name="bvc"></param>
        /// <returns></returns>
        private IList<object[]> GetGrdOCS0133(BindVarCollection bvc)
        {
            IList<object[]> lObj = new List<object[]>();

            OCS0133U00grdOCS0133ItemArgs args = new OCS0133U00grdOCS0133ItemArgs();
            args.InputControl = bvc["f_input_control"].VarValue;
            args.UserInfo = bvc["f_user_info"].VarValue;
            OCS0133U00grdOCS0133ItemResult res = CloudService.Instance.Submit<OCS0133U00grdOCS0133ItemResult, OCS0133U00grdOCS0133ItemArgs>(args);

            if (res.ExecutionStatus == ExecutionStatus.Success)
            {
                res.GrdOcs0133.ForEach(delegate(OCS0133U00grdOCS0133ItemInfo item)
                {
                    lObj.Add(new object[]
                    {
                        item.InputControl,
                        item.InputControlName,
                        item.SpecimenCrYn,
                        item.SuryangCrYn,
                        item.OrdDanuiCrYn,
                        item.DvCrYn,
                        item.NalsuCrYn,
                        item.JusaCrYn,
                        item.BogyongCodeCrYn,
                        item.ToiwonDrgCrYn,
                        item.PortableCrYn,
                        item.AmtCrYn,
                        item.WonyoiOrderYnCrYn,
                        item.PowderYnCrYn,
                    });
                });
            }

            return lObj;
        }
        #endregion

        #region GetListDataForSaveLayout
        /// <summary>
        /// GetListDataForSaveLayout
        /// </summary>
        /// <returns></returns>
        private List<OCS0133U00ExecuteItemInfo> GetListDataForSaveLayout()
        {
            List<OCS0133U00ExecuteItemInfo> lstData = new List<OCS0133U00ExecuteItemInfo>();

            // For update/insert
            for (int i = 0; i < grdOCS0133.RowCount; i++)
            {
                // Skip unchanged rows
                if (grdOCS0133.GetRowState(i) == DataRowState.Unchanged) continue;

                OCS0133U00ExecuteItemInfo item = new OCS0133U00ExecuteItemInfo();

                item.UserId = UserInfo.UserID;
                item.InputControl = grdOCS0133.GetItemString(i, "input_control");
                item.InputControlName = grdOCS0133.GetItemString(i, "input_control_name");
                item.SpecimenCrYn = grdOCS0133.GetItemString(i, "specimen_cr_yn");
                item.SuryangCrYn = grdOCS0133.GetItemString(i, "suryang_cr_yn");
                item.OrdDanuiCrYn = grdOCS0133.GetItemString(i, "ord_danui_cr_yn");
                item.DvCrYn = grdOCS0133.GetItemString(i, "dv_cr_yn");
                item.NalsuCrYn = grdOCS0133.GetItemString(i, "nalsu_cr_yn");
                item.JusaCrYn = grdOCS0133.GetItemString(i, "jusa_cr_yn");
                item.BogyongCodeCrYn = grdOCS0133.GetItemString(i, "bogyong_code_cr_yn");
                item.ToiwonDrgCrYn = grdOCS0133.GetItemString(i, "toiwon_drg_cr_yn");
                item.PortableCrYn = grdOCS0133.GetItemString(i, "portable_cr_yn");
                item.AmtCrYn = grdOCS0133.GetItemString(i, "amt_cr_yn");
                item.WonyoiOrderCrYn = "";
                item.PowderCrYn = "";
                item.RowState = grdOCS0133.GetRowState(i).ToString();
                if (!string.IsNullOrEmpty(item.InputControl) && !string.IsNullOrEmpty(item.InputControlName))
                    lstData.Add(item);
            }

            // for delete
            if (null != grdOCS0133.DeletedRowTable)
            {
                foreach (DataRow dr in grdOCS0133.DeletedRowTable.Rows)
                {
                    OCS0133U00ExecuteItemInfo item = new OCS0133U00ExecuteItemInfo();

                    item.InputControl = dr["input_control"].ToString();
                    item.RowState = DataRowState.Deleted.ToString();

                    lstData.Add(item);
                }
            }

            return lstData;
        }
        #endregion

        #region DoUpdate
        /// <summary>
        /// DoUpdate
        /// </summary>
        private void DoUpdate()
        {
            try
            {
                OCS0133U00ExecuteArgs args = new OCS0133U00ExecuteArgs();
                args.ItemInfo = GetListDataForSaveLayout();
                if (args.ItemInfo.Count <= 0)
                {
                    xButtonList1.PerformClick(FunctionType.Query);
                    XMessageBox.Show(Resources.MSG003_MSG, Resources.MSG005_MSG, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } 
                UpdateResult res = CloudService.Instance.Submit<UpdateResult, OCS0133U00ExecuteArgs>(args);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #endregion

        // deleted by Cloud
        #region [XSavePerformer Class]
        //        private class XSavePerformer : IHIS.Framework.ISavePerformer
        //        {
        //            private OCS0133U00 parent = null;

        //            public XSavePerformer(OCS0133U00 parent)
        //            {
        //                this.parent = parent;
        //            }

        //            public bool Execute(char callerID, RowDataItem item)
        //            {
        //                string cmdText = "";
        //                item.BindVarList.Add("f_user_id",UserInfo.UserID);
        //                item.BindVarList.Add("f_hosp_code", parent.mHospCode);

        //                switch(item.RowState)
        //                {
        //                    case DataRowState.Added:
        //                        cmdText = @"INSERT INTO OCS0133
        //                                         ( SYS_DATE
        //                                         , SYS_ID
        //                                         , INPUT_CONTROL
        //                                         , INPUT_CONTROL_NAME
        //                                         , SPECIMEN_CR_YN
        //                                         , SURYANG_CR_YN
        //                                         , ORD_DANUI_CR_YN
        //                                         , DV_CR_YN
        //                                         , NALSU_CR_YN
        //                                         , JUSA_CR_YN
        //                                         , BOGYONG_CODE_CR_YN
        //                                         , TOIWON_DRG_CR_YN
        //                                         , PORTABLE_CR_YN
        //                                         , AMT_CR_YN
        //                                         , WONYOI_ORDER_YN_CR_YN
        //                                         , POWDER_YN_CR_YN
        //                                         , HOSP_CODE  )
        //                                    VALUES
        //                                         ( SYSDATE
        //                                         , :f_user_id
        //                                         , :f_input_control
        //                                         , :f_input_control_name
        //                                         , NVL(:f_specimen_cr_yn    , 'N')
        //                                         , NVL(:f_suryang_cr_yn     , 'N')
        //                                         , NVL(:f_ord_danui_cr_yn   , 'N')
        //                                         , NVL(:f_dv_cr_yn          , 'N')
        //                                         , NVL(:f_nalsu_cr_yn       , 'N')
        //                                         , NVL(:f_jusa_cr_yn        , 'N')
        //                                         , NVL(:f_bogyong_code_cr_yn, 'N')
        //                                         , NVL(:f_toiwon_drg_cr_yn  , 'N')
        //                                         , NVL(:f_portable_cr_yn    , 'N')
        //                                         , NVL(:f_amt_cr_yn         , 'N')
        //                                         , NVL(:f_wonyoi_order_cr_yn, 'N')
        //                                         , NVL(:f_powder_cr_yn      , 'N')
        //                                         , :f_hosp_code )";
        //                        break;
        //                    case DataRowState.Modified:
        //                        cmdText = @"UPDATE OCS0133
        //                                       SET UPD_ID                = :f_user_id               ,
        //                                           UPD_DATE              = SYSDATE                  ,
        //                                           INPUT_CONTROL_NAME    = :f_input_control_name    ,
        //                                           SPECIMEN_CR_YN        = NVL(:f_specimen_cr_yn    , 'N'),
        //                                           SURYANG_CR_YN         = NVL(:f_suryang_cr_yn     , 'N'),
        //                                           ORD_DANUI_CR_YN       = NVL(:f_ord_danui_cr_yn   , 'N'),
        //                                           DV_CR_YN              = NVL(:f_dv_cr_yn          , 'N'),
        //                                           NALSU_CR_YN           = NVL(:f_nalsu_cr_yn       , 'N'),
        //                                           JUSA_CR_YN            = NVL(:f_jusa_cr_yn        , 'N'),
        //                                           BOGYONG_CODE_CR_YN    = NVL(:f_bogyong_code_cr_yn, 'N'),
        //                                           TOIWON_DRG_CR_YN      = NVL(:f_toiwon_drg_cr_yn  , 'N'),
        //                                           PORTABLE_CR_YN        = NVL(:f_portable_cr_yn    , 'N'),
        //                                           AMT_CR_YN             = NVL(:f_amt_cr_yn         , 'N'),
        //                                           WONYOI_ORDER_YN_CR_YN = NVL(:f_wonyoi_order_cr_yn, 'N'),
        //                                           POWDER_YN_CR_YN       = NVL(:f_powder_cr_yn      , 'N') 
        //                                     WHERE HOSP_CODE             = :f_hosp_code
        //                                       AND INPUT_CONTROL         = :f_input_control";
        //                        break;
        //                    case DataRowState.Deleted:
        //                        cmdText = "DELETE OCS0133 "
        //                                + "    WHERE HOSP_CODE     = :f_hosp_code"
        //                                + "   AND INPUT_CONTROL = :f_input_control";
        //                        break;
        //                }

        //                return Service.ExecuteNonQuery(cmdText,item.BindVarList);
        //            }
        //        }
        #endregion
    }
}