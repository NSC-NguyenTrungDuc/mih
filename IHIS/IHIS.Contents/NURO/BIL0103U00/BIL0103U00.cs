using System;
using System.Collections.Generic;
using System.ComponentModel;

using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;

using IHIS.CloudConnector;
using IHIS.CloudConnector.Contracts.Models.Bill;
using IHIS.CloudConnector.Contracts.Arguments.Bill;
using IHIS.CloudConnector.Contracts.Results.Bill;
using IHIS.CloudConnector.Contracts.Results;
using IHIS.NURO.Properties;
//using IHIS.BILL.Properties;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using IHIS.NURO;
using System.Drawing.Printing;
using System.Threading;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.CloudConnector.Contracts.Models.Nuro;
//using IHIS.CloudConnector.Messaging;

namespace IHIS.NURO
{
    public partial class BIL0103U00 : XScreen
    {
        private string ref_id = "";
        private string InvoiceNo = "";
        private bool isCheckSave = false;
        private int first_status_id = 0;
        private int Pkbil0103 = 0;
        private string TransId = "";
        private string RequestId = "";
        private enum Payment_Status
        { 
            None = 0,
            Finished,
            Fail,
            ForceFinish,
            ForceCancel,
            Requesting,
            Inprogress,
            Cancel,
            OtherError = 9,
        }

        public BIL0103U00()
        {
            InitializeComponent();
            
            grdBil0103U00.ExecuteQuery = LoadGrdBIL0103U00;            
        }

        private void BIL0103U00_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("ref_id"))
                {
                    ref_id = this.OpenParam["ref_id"].ToString();
                }
                if (this.OpenParam.Contains("InvoiceNo"))
                {
                    InvoiceNo = this.OpenParam["InvoiceNo"].ToString();
                }
                if (this.OpenParam.Contains("bunho"))
                {
                    dbxPatientCode.Text = this.OpenParam["bunho"].ToString();
                }
                if (this.OpenParam.Contains("name"))
                {
                    dbxPatientName.Text = this.OpenParam["name"].ToString();
                }
                if (this.OpenParam.Contains("first_status_id"))
                {
                    first_status_id = int.Parse(this.OpenParam["first_status_id"].ToString());
                }
                if (this.OpenParam.Contains("Pkbil0103"))
                {
                    Pkbil0103 = int.Parse(this.OpenParam["Pkbil0103"].ToString());
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            grdBil0103U00.QueryLayout(true);
            InitCboGrdTagType();
            grdBil0103U00.SetItemValue(0, "Payment_status", first_status_id);
        }

        private void InitCboGrdTagType()
        {
            DataTable _dtGrdCbo = new DataTable();
            _dtGrdCbo.Columns.Add("TypeId", typeof(int));
            _dtGrdCbo.Columns.Add("TypeName", typeof(string));

            if (first_status_id == 5)
            {
                _dtGrdCbo.Rows.Add(4, Resources.BILL0103_Status_id_4);
                _dtGrdCbo.Rows.Add(5, Resources.BILL0103_Status_id_5);
                _dtGrdCbo.Rows.Add(3, Resources.BILL0103_Status_id_3);
            }
            else if (first_status_id == 6)
            {
                _dtGrdCbo.Rows.Add(3, Resources.BILL0103_Status_id_3);
                _dtGrdCbo.Rows.Add(4, Resources.BILL0103_Status_id_4);
                _dtGrdCbo.Rows.Add(6, Resources.BILL0103_Status_id_6);
                _dtGrdCbo.Rows.Add(9, Resources.BILL0103_Status_id_9);
            }
            else if (first_status_id == 2)
            {
                _dtGrdCbo.Rows.Add(2, Resources.BILL0103_Status_id_2);
                _dtGrdCbo.Rows.Add(7, Resources.BILL0103_Status_id_7);
            }
            else
            {
                if (first_status_id == 0 || first_status_id == null)
                {
                    _dtGrdCbo.Rows.Add(0, Resources.BILL0103_Status_id_0);
                }
                else if (first_status_id == 1)
                {
                    _dtGrdCbo.Rows.Add(1, Resources.BILL0103_Status_id_1);
                }
                else if (first_status_id == 2)
                {
                    _dtGrdCbo.Rows.Add(2, Resources.BILL0103_Status_id_2);
                }
                else if (first_status_id == 3)
                {
                    _dtGrdCbo.Rows.Add(3, Resources.BILL0103_Status_id_3);
                }
                else if (first_status_id == 4)
                {
                    _dtGrdCbo.Rows.Add(4, Resources.BILL0103_Status_id_4);
                }
                else if (first_status_id == 5)
                {
                    _dtGrdCbo.Rows.Add(5, Resources.BILL0103_Status_id_5);
                }
                else if (first_status_id == 6)
                {
                    _dtGrdCbo.Rows.Add(6, Resources.BILL0103_Status_id_6);
                }
                else if (first_status_id == 7)
                {
                    _dtGrdCbo.Rows.Add(7, Resources.BILL0103_Status_id_7);
                }
                else if (first_status_id == 9)
                {
                    _dtGrdCbo.Rows.Add(9, Resources.BILL0103_Status_id_9);
                }
            }

            this.grdBil0103U00.SetComboItems("Payment_status", _dtGrdCbo, "TypeName", "TypeId");
        }

        private List<object[]> LoadGrdBIL0103U00(Framework.BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            BIL0103U00LoadGridArgs args = new BIL0103U00LoadGridArgs();
            args.Bunho = this.OpenParam["bunho"].ToString();
            args.InvoiceNo = this.OpenParam["InvoiceNo"].ToString();
            args.RefId = this.OpenParam["ref_id"].ToString();
            args.Pkbil0103 = this.OpenParam["Pkbil0103"].ToString();
            BIL0103U00LoadGridResult result = CloudService.Instance.Submit<BIL0103U00LoadGridResult, BIL0103U00LoadGridArgs>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (BIL0103U00LoadGridInfo info in result.Grdlist)
                {
                    object[] objects = 
                        {
                            info.Bunho,
                            info.Suname,                            
                            info.RefId,
                            info.VisitDate,
                            info.ExecutedDatetime,                                                       
                            info.SettleDatetime,                            
                            info.Amount,
                            info.Currency,                            
                            info.ErrorCodeName,
                            info.Comment,
                            info.TransStatus,                                                       
                            info.TransStatusName,
                            info.RequestId                            
                        };
                    res.Add(objects);
                }
                //CheckStatusInvoice();    
            }
            return res;

        }

        private void btnButtonList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Update:
                #region Update case
                isCheckSave = false;
                if (Validate())
                {
            		XMessageBox.Show(Resources.MSG_002, Resources.MSG002_CAP);
                    return;
                }

                BIL0103U00SaveGridArgs args = new BIL0103U00SaveGridArgs();
                args.Comment = grdBil0103U00.GetItemValue(0, "Comment").ToString();
                args.RefId = ref_id;
                args.TransStatus = grdBil0103U00.GetItemValue(0, "Payment_status").ToString();
                args.Pkbil0103 = Pkbil0103.ToString();
                args.Bunho = dbxPatientCode.Text;
                args.InvoiceNo = InvoiceNo;
                UpdateResult result = CloudService.Instance.Submit<UpdateResult, BIL0103U00SaveGridArgs>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success || result.Result == true)
                {
                    XMessageBox.Show(Resources.Msg_save_success, Resources.Msg_save_success_cap);
                }
                else
                {
                    XMessageBox.Show(Resources.Msg_delete_success, Resources.Msg_delete_success_cap);
                }
                break;
                #endregion
            }
        }

        private bool Validate()
        {
            string comment = grdBil0103U00.GetItemValue(0, "Comment").ToString();
            if (comment.Length <= 0)
            {
                return true;
            }
            return false;
            
        }

        private void grdBil0103U00_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            // if (e.ColName.ToString() == "Payment_status")
            //{
            //    bool flg_check = true;
            //    string id_status = grdBil0103U00.GetItemValue(e.RowNumber, "Payment_status").ToString();
            //    if (first_status_id == 5)
            //    {
            //        if (int.Parse(id_status) != 4)
            //        {
            //            flg_check = false;                        
            //        }
            //    }
            //    else if (first_status_id == 6)
            //    {
            //        if (int.Parse(id_status) == 3 || int.Parse(id_status) != 9 || int.Parse(id_status) != 4)
            //        {
            //            flg_check = true;
            //        }
            //        else
            //        {
            //            flg_check = false;
            //        }
            //    }
            //    else if (first_status_id == 2)
            //    {
            //        flg_check = false;
            //    }
            //    if (flg_check == false)
            //    {
            //         XMessageBox.Show(Resources.MSG_001, Resources.MSG001_CAP);
            //         grdBil0103U00.SetItemValue(e.RowNumber, "Payment_status", first_status_id);
            //    }
            //}
            if (grdBil0103U00.CurrentRowNumber >= 0 && (grdBil0103U00.CurrentColName == "Trans_id" || grdBil0103U00.CurrentColName == "request_id"))
            {
                grdBil0103U00.SetItemValue(grdBil0103U00.CurrentRowNumber, "Trans_id", TransId);
                grdBil0103U00.SetItemValue(grdBil0103U00.CurrentRowNumber, "request_id", RequestId);
            }
        }

        private void grdBil0103U00_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
        }

        private void grdBil0103U00_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            TransId = grdBil0103U00.GetItemString(grdBil0103U00.CurrentRowNumber, "Trans_id");
            RequestId = grdBil0103U00.GetItemString(grdBil0103U00.CurrentRowNumber, "request_id");
        }

        private void grdBil0103U00_Leave(object sender, EventArgs e)
        {
            grdBil0103U00.SetItemValue(grdBil0103U00.CurrentRowNumber, "Trans_id", TransId);
            grdBil0103U00.SetItemValue(grdBil0103U00.CurrentRowNumber, "request_id", RequestId);
        }
    }
}