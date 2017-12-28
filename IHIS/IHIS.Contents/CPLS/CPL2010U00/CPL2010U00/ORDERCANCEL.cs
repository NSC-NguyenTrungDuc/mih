using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Arguments.Cpls;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.CloudConnector.Contracts.Results.Cpls;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CPLS.Properties;
using IHIS.Framework;

namespace IHIS.CPLS
{
    public partial class ORDERCANCEL : XForm
    {
        public ORDERCANCEL()
        {
            InitializeComponent();

            //tungtx
            grdOrder.ParamList = new List<string>(new String[] { "f_bunho", "f_order_date" });
            grdOrder.ExecuteQuery = LoadDataGrdOrder;

            dtpOrder.SetDataValue(EnvironInfo.GetSysDate());
        }

        public ORDERCANCEL(string Bunho, string Order_date)
        {
            InitializeComponent();

            //tungtx
            grdOrder.ParamList = new List<string>(new String[] { "f_bunho", "f_order_date" });
            grdOrder.ExecuteQuery = LoadDataGrdOrder;

            paBox.SetPatientID(Bunho);
            dtpOrder.SetDataValue(Order_date);

            grdOrder.QueryLayout(false);
            
        }

        #region CloudService: get data for controls 

        private List<object[]> LoadDataGrdOrder(BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            CPL2010U00OrderCancelGrdOrderArgs args = new CPL2010U00OrderCancelGrdOrderArgs();
            args.Bunho = bc["f_bunho"] != null ? bc["f_bunho"].VarValue : "";
            args.OrderDate = bc["f_order_date"] != null ? bc["f_order_date"].VarValue : "";
            CPL2010U00OrderCancelGrdOrderResult result =
                CloudService.Instance.Submit<CPL2010U00OrderCancelGrdOrderResult, CPL2010U00OrderCancelGrdOrderArgs>(
                    args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (CPL2010U00OrderCancelGrdOrderListItemInfo item in result.GrdOrderList)
                {
                    object[] objects =
                    {
                        item.Fkocs1003,
                        item.HangmogCode,
                        item.GumsaName,
                        item.SpecimenCode,
                        item.SpecimenName,
                        item.SpecimenSer,
                        item.Pkcpl2010
                    };
                    res.Add(objects);
                }
            }
            return res;
        }

        #endregion




        private void grdOrder_QueryStarting(object sender, CancelEventArgs e)
        {

            grdOrder.SetBindVarValue("f_hosp_code", EnvironInfo.HospCode);
            grdOrder.SetBindVarValue("f_bunho", paBox.BunHo);
            grdOrder.SetBindVarValue("f_order_date", dtpOrder.GetDataValue());

            
        }

        private void xButtonList1_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Cancel:
                    e.IsBaseCall = false;

                    if (grdOrder.GetItemString(grdOrder.CurrentRowNumber, "selected") != "Y")
                    {
                        XMessageBox.Show(Resources.TEXT3);
                        return;
                    }

//                    BindVarCollection bindVar = new BindVarCollection();
//                    bindVar.Add("f_fkocs1003", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkocs1003"));
//                    bindVar.Add("f_pkcpl2010", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkcpl2010"));
//                    bindVar.Add("f_specimen_ser", grdOrder.GetItemString(grdOrder.CurrentRowNumber, "specimen_ser"));

//                    string cmd = @" SELECT NVL(IF_DATA_SEND_YN, 'N') 
//                                      FROM OCS1003
//                                     WHERE PKOCS1003 = :f_fkocs1003";

//                    object retval = Service.ExecuteScalar(cmd, bindVar);

                    CPL2010U00OrderCancelGetYNArgs argsYn =
                        new CPL2010U00OrderCancelGetYNArgs(grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkocs1003"));
                    CPL2010U00OrderCancelGetYNResult resultYn =
                        CloudService.Instance.Submit<CPL2010U00OrderCancelGetYNResult, CPL2010U00OrderCancelGetYNArgs>(
                            argsYn);

                    //if (retval.ToString() == "Y")
                    if (resultYn.ExecutionStatus != ExecutionStatus.Success || resultYn.YnValue == "Y")
                    {
                        XMessageBox.Show(Resources.TEXT4);
                        return;
                    }

                    if (XMessageBox.Show(string.Format(Resources.TEXT6, 
                        paBox.BunHo + "　" + paBox.SuName,
                        grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_code"), 
                        grdOrder.GetItemString(grdOrder.CurrentRowNumber, "hangmog_name")),
                        Resources.TEXT7, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }

//                    cmd = @"    DECLARE cnt NUMBER(2);
//
//                                        BEGIN
//
//                                            DELETE CPL3020
//                                             WHERE FKCPL2010 = :f_pkcpl2010;
//                                            
//                                            SELECT COUNT(*) INTO cnt FROM CPL3020
//                                            WHERE SPECIMEN_SER = :f_specimen_ser;
//                                             
//                                            IF cnt = 0 THEN
//                                                DELETE CPL3010
//                                                WHERE SPECIMEN_SER = :f_specimen_ser;                                                                                                  
//                                            END IF;                                                  
// 
//                                            PR_OCS_UPDATE_ACTING('O',
//                                                                 :f_fkocs1003,
//                                                                 'CPL',
//                                                                 NULL,
//                                                                 NULL,
//                                                                 NULL);
//
//                                            PR_OCS_UPDATE_JUBSU ('O',
//                                                                 :f_fkocs1003,
//                                                                 'CPL',
//                                                                 NULL,
//                                                                 NULL);
//                                                                 
//                                            PR_SCH_UPDATE_ACTING('O',
//                                                                 :f_fkocs1003,
//                                                                 NULL);
//                                        END;";

//                    Service.BeginTransaction();

//                    try
//                    {
//                        if (Service.ExecuteNonQuery(cmd, bindVar))
//                        {
//                            cmd = @"   UPDATE CPL2010
//                                      SET UPD_DATE = SYSDATE,
//                                          DUMMY           = NULL,
//                                          PART_JUBSU_DATE = NULL,
//                                          PART_JUBSU_TIME = NULL,
//                                          PART_JUBSUJA = NULL,
//                                          JUBSU_DATE = NULL,
//                                          JUBSU_TIME = NULL,
//                                          JUBSUJA = NULL,
//                                          SPECIMEN_SER = NULL          
//                                    WHERE FKOCS1003 = :f_fkocs1003";

//                            if (!Service.ExecuteNonQuery(cmd, bindVar))
//                            {
//                                throw new Exception(Service.ErrFullMsg);
//                            }
//                        }
//                        else
//                        {
//                            throw new Exception(Service.ErrFullMsg);
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        XMessageBox.Show(ex.Message);
//                        Service.RollbackTransaction();
//                    }
//                    Service.CommitTransaction();

                    CPL2010U00OrderCancelExecuteArgs args = new CPL2010U00OrderCancelExecuteArgs();
                    args.Fkocs1003 = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "fkocs1003");
                    args.Pkcpl2010 = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "pkcpl2010");
                    args.SpecimenSer = grdOrder.GetItemString(grdOrder.CurrentRowNumber, "specimen_ser");
                    UpdateResult result =
                        CloudService.Instance.Submit<UpdateResult, CPL2010U00OrderCancelExecuteArgs>(args);
                    if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
                    {
                        XMessageBox.Show(Resources.ORDERCANCEL_Execute_Fail);
                    }

                    btnList.PerformClick(FunctionType.Query);
                    break;
            }

        }

        private void grdOrder_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            if (grdOrder.GetItemString(e.RowNumber, "if_data_send_yn") == "Y")
            {
                e.BackColor = Color.MistyRose;
            }
        }

        private void paBox_PatientSelected(object sender, EventArgs e)
        {
            grdOrder.QueryLayout(false);
        }

        private void dtpOrder_DataValidating(object sender, DataValidatingEventArgs e)
        {
            grdOrder.QueryLayout(false);
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdOrder.RowCount; i++)
            {
                grdOrder.SetItemValue(i, "selected", grdOrder.CurrentRowNumber == i ? "Y" : "N");
            }
            grdOrder.ResetUpdate();
        }
    }
}