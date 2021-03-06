using System;
using System.Collections.Generic;
using System.ComponentModel;
//using DevExpress.CodeParser;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.Framework;
using Report2005;
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
    public partial class BIL0102U00 : XScreen
    {
        #region Field & Properties
        private string phone = "";
        private string cancelYN = "";
        private string bunhoTypeName = "";
        private bool isCheckSave = false;
        private string soBL = "";
        private string invoiceNo = "";
        private double totalPay;
        private double totalDiscount;
        private double totalPatient;
        private string payYN = "";
        private string pkOut1001 = "";
        private string birth = "";
        private string mBunhoType = "";
        private string yoyang_name = "";
        private string adress = "";
        private string tel = "";
        private string email = "";
        private string homepage = "";
        private string address1 = "";
        private string sex = "";
        private string naewonDate = "";
        private string gwa = "";
        private string doctor = "";
        private string gwaName = "";
        private string doctorName = "";

        private string typeCheck = "";
        private string parentInvoiceNo = "";
        private string statusFlg = "";
        private string amountDebt = "";
        private string amountPaid = "";
        private string amount = "";
        private string discount = "";
        private string revertReason = "";
        private string activeFlg = "";
        private string firstParentInvoice = "";
        private string InvoiceNo_return = "";

        private LoadGridBIL2016U02Result resultLoad;      
        #endregion

        #region Contructor
        public BIL0102U00()
        {
            InitializeComponent();
            grdBIL2016U02.ParamList = new List<string>(new String[] { "f_invoice_no", "f_invoice_date", "f_patient_code", "f_pay_yn", "f_pkout_1001", "f_bunho_type" });
            grdBIL2016U02.ExecuteQuery = GetDataBIL2016U02;
            cboPaymentType.ExecuteQuery = GetDataComboBIL2016U02;
            cboPaymentType.SetDictDDLB();
            lblUnit.Text = Resources.lblUnitText;
            grdPayHistory.ExecuteQuery = LoadGrdBIL2016U02PayHistory;
            /*if (NetInfo.Language == LangMode.Vi)
            {
                lblUnit.Text ="Đơn vị : VNĐ";
            }
            else
            {
                lblUnit.Text = "Unit : JPY";
            }*/
            //btnSendEmail.Visible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            grdBIL2016U02.QueryLayout(true);
            cbxInvoiceList.ExecuteQuery = GetDataComboInvoiceBIL2016U02;
            cbxInvoiceList.SetDictDDLB();
            cbxInvoiceList.SelectedIndex = 0;
            if (payYN == "N")
            {
                txtName.Text = dbxPatientName.Text;
                SetEnableControl(true);
                //xLabel4.Visible = false;
                //cbxCancelReason.Visible = false;
                // https://sofiamedix.atlassian.net/browse/MED-11876
                //txtCancelReason.Visible = false;
                btnButtonList.SetEnabled(FunctionType.Delete, false);
                cbxDiscount.SelectedIndex = 0;
                txtName.Text = dbxPatientName.Text;
                xEditGridCell23.IsReadOnly = true;
                cbxInvoiceList.Visible = false;
            }
            if (payYN == "Y")
            {
                txtName.Text = resultLoad.PaidName;
                SetEnableControl(false);
                cbxInvoiceList.Visible = true;
                txtPayMoney.ReadOnly = true;
                //xLabel4.Visible = true;
                //cbxCancelReason.Visible = true;                
                btnButtonList.SetEnabled(FunctionType.Update, false);
                if (resultLoad.TotalDiscount != "0")
                {
                    Int64 value;
                    if (Int64.TryParse(resultLoad.TotalDiscount, out value))
                        //dbxSumDiscount.Text = value.ToString("#,###");
                        dbxSumDiscount.Text = FormatNumber(value.ToString(), true);
                    else
                        dbxSumDiscount.Text = String.Empty;
                    this.dbxSumDiscount.TextChanged -= new System.EventHandler(this.dbxSumDiscount_TextChanged);
                }
                dbxSumDiscount.BackColor = IHIS.Framework.XColor.XDisplayBoxBackColor;
                if (!String.IsNullOrEmpty(resultLoad.DiscountType))
                {
                    cbxDiscount.SetDataValue(resultLoad.DiscountType);
                    this.cbxDiscount.SelectedValueChanged -= new System.EventHandler(this.cbxDiscount_SelectedValueChanged);
                }
                if (cbxDiscount.GetDataValue() == "2")
                {
                    txtDiscountReason.Text = resultLoad.DiscountReasonTotal;
                }

            }
            if (payYN == "C")
            {
                txtName.Text = resultLoad.PaidName;
                string fl = "";
                SetEnableControl(false);
                cbxInvoiceList.Visible = false;
                //xLabel4.Visible = false;
                //cbxCancelReason.Visible = false;
                // https://sofiamedix.atlassian.net/browse/MED-11876
                //txtCancelReason.Visible = true;
                // xLabel4.Visible = true;
                // cbxCancelReason.Visible = true;
                // cbxCancelReason.Enabled = false;
                grdBIL2016U02.ReadOnly = true;
                btnButtonList.SetEnabled(FunctionType.Print, false);
                btnButtonList.SetEnabled(FunctionType.Update, false);
                btnButtonList.SetEnabled(FunctionType.Delete, false);
                txtPayMoney.ReadOnly = true;

                if (resultLoad.TotalDiscount != "0")
                {
                    Int64 value;
                    if (Int64.TryParse(resultLoad.TotalDiscount, out value))
                        //dbxSumDiscount.Text = value.ToString("#,###");
                        dbxSumDiscount.Text = FormatNumber(value.ToString(), true);
                    else
                        dbxSumDiscount.Text = String.Empty;
                    this.dbxSumDiscount.TextChanged -= new System.EventHandler(this.dbxSumDiscount_TextChanged);
                }
                dbxSumDiscount.BackColor = IHIS.Framework.XColor.XDisplayBoxBackColor;
                if (!String.IsNullOrEmpty(resultLoad.DiscountType))
                {
                    cbxDiscount.SetDataValue(resultLoad.DiscountType);
                    this.cbxDiscount.SelectedValueChanged -= new System.EventHandler(this.cbxDiscount_SelectedValueChanged);
                }
                if (cbxDiscount.GetDataValue() == "2")
                {
                    txtDiscountReason.Text = resultLoad.DiscountReasonTotal;
                }
            }

            ResetInputValue();
            BindMoney();
            BindTotalMoney();
            CheckSecondinvoices();
            EnableInputForJp(false);
            CheckCountGrdPayHistory();
        }
        #endregion

        #region Event
        #region Event Handler
        private void btnButtonList_ButtonClick(object sender, ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Print:
                    #region Comment by ClouService
                    //#region Print case
                    ////Todo Print
                    //DataSet1 ds = new DataSet1();
                    //int i = 1;

                    //PrintDataComboInvoiceArgs printArgs = new PrintDataComboInvoiceArgs();
                    //if (payYN == "N")
                    //{
                    //    printArgs.InvoiceNo = firstParentInvoice;
                    //    printArgs.ParentInvoiceNo = firstParentInvoice;
                    //}
                    //else if (rbtPayHistory.Checked)
                    //{
                    //    printArgs.InvoiceNo = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                    //    printArgs.ParentInvoiceNo = parentInvoiceNo;
                    //}
                    //else
                    //{
                    //    printArgs.InvoiceNo = cbxInvoiceList.GetDataValue();
                    //    printArgs.ParentInvoiceNo = parentInvoiceNo;
                    //}
                    //PrintDataComboInvoiceResult invoiceResult = CloudService.Instance.Submit<PrintDataComboInvoiceResult, PrintDataComboInvoiceArgs>(printArgs);
                    //if (invoiceResult != null && invoiceResult.ExecutionStatus == ExecutionStatus.Success)
                    //{
                    //    foreach (LoadGridBIL2016U02Info info in invoiceResult.InvoiceDetail)
                    //    {
                    //        DataRow row = ds.DataBil.NewRow();
                    //        row["number"] = i++;
                    //        row["hangmog_code"] = info.HangmogCode;
                    //        row["hangmog_name"] = info.HangmogName;
                    //        row["unit"] = info.Unit;
                    //        row["quantity"] = info.Quantity;
                    //        row["price"] = TryPareFormatNum(info.Price);
                    //        row["amount"] = TryPareFormatNum(info.Amount);
                    //        row["insurance_pay"] = TryPareFormatNum(info.InsurancePay);
                    //        double quantity = 1;
                    //        bool isNumQuantity = Double.TryParse(info.Quantity, out quantity);
                    //        double price = 0;
                    //        double discount = 0;
                    //        double patientPay = 0;
                    //        bool Price = Double.TryParse(info.Price.ToString(), out price);
                    //        bool Discount = Double.TryParse(info.Discount.ToString(), out discount);
                    //        patientPay = price * quantity - discount;
                    //        row["patient_pay"] = TryPareFormatNum(patientPay.ToString());
                    //        row["discount"] = TryPareFormatNum(info.Discount);
                    //        row["dept_req_nm"] = info.DeptReqNm;
                    //        row["doctor_req_nm"] = info.DoctorReqNm;
                    //        row["dept_exc_nm"] = info.DeptExcNm;
                    //        row["doctor_exc_nm"] = info.DoctorExcNm;
                    //        row["order_group_nm"] = info.OrderGroupNm;
                    //        ds.DataBil.Rows.Add(row);
                    //    }
                    //}


                    ////Data for patient and name hospital 
                    //DataRow rowHospital = ds.DataHospital.NewRow();
                    //if (rbtPayHistory.Checked)
                    //{
                    //    rowHospital["invoice_no"] = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                    //}
                    //else
                    //{
                    //    rowHospital["invoice_no"] = cbxInvoiceList.GetDataValue();
                    //}
                    //rowHospital["hospital_name"] = resultLoad.YoyangName;
                    //rowHospital["adress"] = resultLoad.Adress;
                    //rowHospital["tel"] = resultLoad.Tel;
                    //rowHospital["email"] = resultLoad.Email;
                    //rowHospital["website"] = resultLoad.Website;
                    //rowHospital["invoice_date"] = dtInvoiceDate.GetDataValue();
                    //rowHospital["patient"] = dbxPatientName.Text;
                    //rowHospital["paid_name"] = dbxPatientName.Text;
                    //rowHospital["patient_code"] = dbxPatientCode.Text;
                    //rowHospital["sum_amount_invoice"] = TryPareFormatNum(invoiceResult.SumAmountInvoice);
                    //rowHospital["paid_invoice"] = TryPareFormatNum(invoiceResult.PaidInvoice);
                    //rowHospital["total_paid"] = TryPareFormatNum(invoiceResult.TotalPaid);
                    //rowHospital["total_debt"] = TryPareFormatNum(invoiceResult.TotalDebt);
                    //try
                    //{
                    //    rowHospital["total_write"] = replaceSpecialWord(joinUnit(totalPatient.ToString())).Trim();
                    //}
                    //catch (Exception ex)
                    //{
                    //    Service.WriteLog("BIL0102U00 : Error " + ex.Message);
                    //    rowHospital["total_write"] = dbxSum.Text.ToString();
                    //}

                    //DateTime date1 = DateTime.Now;
                    //if (!string.IsNullOrEmpty(birth))
                    //{
                    //    DateTime bday = DateTime.ParseExact(birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    //    DateTime now = DateTime.Today;
                    //    int age = now.Year - bday.Year;
                    //    if (bday > now.AddYears(-age)) age--;
                    //    rowHospital["age"] = age;
                    //}
                    //else
                    //{
                    //    rowHospital["age"] = "";
                    //}
                    //ds.DataHospital.Rows.Add(rowHospital);
                    ////Set print
                    //if (NetInfo.Language == LangMode.Vi)
                    //{
                    //    ReportBIL2016U02 xReport = new ReportBIL2016U02();
                    //    xReport.Name = String.IsNullOrEmpty(txtInvoiceNo.Text) ? dbxPatientCode.Text + "_" + txtInvoiceNo.Text : dbxPatientCode.Text;
                    //    xReport.DataSource = ds;
                    //    xReport.Print();
                    //}
                    //else
                    //{
                    //    ReportBIL2016U02JP xReport = new ReportBIL2016U02JP();
                    //    xReport.DataSource = ds;
                    //    xReport.Name = String.IsNullOrEmpty(txtInvoiceNo.Text) ? dbxPatientCode.Text + "_" + txtInvoiceNo.Text : dbxPatientCode.Text;
                    //    xReport.Print();
                    //}
                    //break;
                    //#endregion
                    #endregion
                    #region Show preview
                    DataHospital dataHospital = new DataHospital();

                    BIL0102U00DataReportArgs printArgs = new BIL0102U00DataReportArgs();
                    if (payYN == "N")
                    {
                        printArgs.InvoiceNo = firstParentInvoice;
                        printArgs.ParentInvoiceNo = firstParentInvoice;
                    }
                    else if (rbtPayHistory.Checked)
                    {
                        printArgs.InvoiceNo = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                        printArgs.ParentInvoiceNo = parentInvoiceNo;
                    }
                    else
                    {
                        printArgs.InvoiceNo = cbxInvoiceList.GetDataValue();
                        printArgs.ParentInvoiceNo = parentInvoiceNo;
                    }
                    BIL0102U00DataReportResult invoiceResult = CloudService.Instance.Submit<BIL0102U00DataReportResult, BIL0102U00DataReportArgs>(printArgs);
                    if (invoiceResult != null && invoiceResult.ExecutionStatus == ExecutionStatus.Success)
                    {
                        if (payYN != "N")
                        {
                            dataHospital.BillingData = invoiceResult.InvoiceDetail;
                        }
                        else {
                            //Group order NM
                            Dictionary<string, List<LoadGridBIL2016U02Info>> groups = new Dictionary<string, List<LoadGridBIL2016U02Info>>();
                            int i = 1;
                            foreach (LoadGridBIL2016U02Info emp in resultLoad.InvoiceDetail)
                            {
                                
                                List<LoadGridBIL2016U02Info> group;
                                if (!groups.TryGetValue(emp.OrderGroupNm, out group))
                                {
                                    group = new List<LoadGridBIL2016U02Info>();
                                    groups.Add(emp.OrderGroupNm, group);
                                }
                                group.Add(emp);
                                i++;
                            }
                            //add List BillingData
                            if (groups.Count > 0)
                            {
                                List<BIL0102U00DataReportInfo> lstInfo = new List<BIL0102U00DataReportInfo>();

                                foreach (KeyValuePair<string, List<LoadGridBIL2016U02Info>> pair in groups)
                                {
                                    BIL0102U00DataReportInfo info = new BIL0102U00DataReportInfo();                      
                                    info.Department = pair.Key;
                                    info.InvoiceDetail = pair.Value;
                                    lstInfo.Add(info);
                                }
                                dataHospital.BillingData = lstInfo;
                            }
                        }
                    }
                    //DataRow rowHospital = ds.DataHospital.NewRow();
                    if (rbtPayHistory.Checked)
                    {
                        dataHospital.Invoice_no = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                    }
                    else
                    {
                        dataHospital.Invoice_no = cbxInvoiceList.GetDataValue();
                    }
                    dataHospital.Hospital_name = resultLoad.YoyangName;
                    dataHospital.Adress = resultLoad.Adress;
                    dataHospital.Adress1 = resultLoad.Adress1;
                    dataHospital.Tel = resultLoad.Tel;
                    dataHospital.Email = resultLoad.Email;
                    dataHospital.Website = resultLoad.Website;
                    dataHospital.Invoice_date = dtInvoiceDate.GetDataValue();
                    DateTime InvoiceDay = DateTime.Now;
                    if (DateTime.TryParse(dtInvoiceDate.GetDataValue(), out InvoiceDay))
                    {
                        dataHospital.Invoice_day = DateTime.Parse(dtInvoiceDate.GetDataValue()).ToString("dd");
                        dataHospital.Invoice_month = DateTime.Parse(dtInvoiceDate.GetDataValue()).ToString("MM");
                        dataHospital.Invoice_year = DateTime.Parse(dtInvoiceDate.GetDataValue()).ToString("yyyy");
                    }
                    else
                    {
                        dataHospital.Invoice_day = InvoiceDay.ToString("dd");
                        dataHospital.Invoice_month = InvoiceDay.ToString("MM");
                        dataHospital.Invoice_year = InvoiceDay.ToString("yyyy");
                    }
                    dataHospital.Patient = dbxPatientName.Text;
                    dataHospital.Paid_name = dbxPatientName.Text;
                    dataHospital.Patient_code = dbxPatientCode.Text;
                    dataHospital.Fax = resultLoad.Fax;

                    string patient_address = "";
                    if (grdBIL2016U02 != null && grdBIL2016U02.RowCount > 0)
	                {
                		 patient_address = grdBIL2016U02.GetItemString(0, "patient_address");
	                }


                    dataHospital.Patient_address = patient_address;
                    if (payYN != "N")
                    {
                        dataHospital.Sum_amount_invoice = TryPareFormatNum(invoiceResult.SumAmountInvoice);
                    }
                    else 
                    {
                        if (resultLoad.InvoiceDetail.Count > 0)
                        {
                            int sumAmount = 0;
                            for (int i = 0; i < resultLoad.InvoiceDetail.Count; i++)
                            { 
                                int outSum = 0;
                                bool isSumAmount = int.TryParse(resultLoad.InvoiceDetail[i].Amount, out outSum);
                                sumAmount += outSum;
                            }
                            dataHospital.Sum_amount_invoice = TryPareFormatNum(sumAmount.ToString());
                        }
                    }
                    dataHospital.Paid_invoice = TryPareFormatNum(invoiceResult.PaidInvoice);
                    dataHospital.Total_paid = TryPareFormatNum(invoiceResult.TotalPaid);
                    dataHospital.Total_debt = TryPareFormatNum(invoiceResult.TotalDebt);
                    dataHospital.Discount_sum = TryPareFormatNum(resultLoad.TotalPatientDiscount);
                    dataHospital.User_session = UserInfo.UserName;
                    try
                    {
                        dataHospital.Total_write = replaceSpecialWord(joinUnit(totalPatient.ToString())).Trim();
                    }
                    catch (Exception ex)
                    {
                        Service.WriteLog("BIL0102U00 : Error " + ex.Message);
                        dataHospital.Total_write = dbxSum.Text.ToString();
                    }

                    DateTime date1 = DateTime.Now;
                    if (!string.IsNullOrEmpty(birth))
                    {
                        DateTime bday = DateTime.ParseExact(birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        DateTime now = DateTime.Today;
                        int age = now.Year - bday.Year;
                        if (bday > now.AddYears(-age)) age--;
                        dataHospital.Age = age.ToString();
                    }
                    else
                    {
                        dataHospital.Age = "";
                    }

                    
                    PrintForm showPreview = new PrintForm(dataHospital);
                    showPreview.ShowDialog();

                    break;
                    #endregion

                case FunctionType.Update:
                    #region Update case
                    isCheckSave = false;
                    if (!ValidateCaseUpdate()) return;

                    if (!SaveBill2016U02("Added"))
                    {
                        XMessageBox.Show(Resources.Msg_save_fail, Resources.Msg_save_fail_cap);
                    }
                    else
                    {
                        XMessageBox.Show(Resources.Msg_save_success, Resources.Msg_save_success_cap);
                        btnButtonList.SetEnabled(FunctionType.Update, false);
                        btnButtonList.SetEnabled(FunctionType.Delete, true);
                        //invoiceNo = txtInvoiceNo.Text;
                        isCheckSave = true;
                        grdBIL2016U02.QueryLayout(false);
                        SetEnableControl(false);
                        ResetInputValue();
                        BindTotalMoney();
                    }
                    break;
                    #endregion

                case FunctionType.Delete:
                    #region Delete case
                    //Todo Delete
                    e.IsBaseCall = false;
                    string curentInvoiceNo = "";
                    curentInvoiceNo = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                    if (grdBIL2016U02.RowCount == 0) return;
                    if (rbtPayHistory.Checked)
                    {
                        string lasteInvoicePayHistory = "";
                        CheckLasteInvoiceBIL2016U02Args args = new CheckLasteInvoiceBIL2016U02Args();
                        args.ParentInvoiceNo = parentInvoiceNo;
                        //args.ParentInvoiceNo = txtInvoiceNo.Text;
                        CheckLasteInvoiceBIL2016U02Result result = CloudService.Instance.Submit<CheckLasteInvoiceBIL2016U02Result, CheckLasteInvoiceBIL2016U02Args>(args);
                        if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
                        {
                            foreach (CheckLasteInvoiceBIL2016U02Info info in result.CheckLasteInvoice)
                            {
                                lasteInvoicePayHistory = info.LatestInvoice;
                            }
                        }
                        if (curentInvoiceNo != lasteInvoicePayHistory)
                        {
                            XMessageBox.Show(Resources.MSG009, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {
                            if (XMessageBox.Show(Resources.MSG_001, Resources.MSG001_CAP, MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                RevertReason formRevertReason = new RevertReason();
                                formRevertReason.ShowDialog();
                                if (formRevertReason.CancelDelete)
                                {
                                    XMessageBox.Show(Resources.Msg_delete_fail, Resources.Msg_delete_fail_cap);
                                    break;
                                }
                                else
                                {
                                    revertReason = formRevertReason.ReasonDelete;
                                }
                                if (!SaveBill2016U02("Deleted"))
                                {
                                    XMessageBox.Show(Resources.Msg_delete_fail, Resources.Msg_delete_fail_cap);
                                    break;
                                }
                                else
                                {
                                    XMessageBox.Show(Resources.Msg_delete_success, Resources.Msg_delete_success_cap);
                                    grdPayHistory.QueryLayout(true);
                                }
                            }
                        }
                    }
                    //if (cbxCancelReason.GetDataValue().ToString() == "")
                    //{
                    //    XMessageBox.Show(Resources.MSG002,Resources.MSG001_CAP);
                    //    cbxCancelReason.Focus();                        
                    //    return;
                    //}
                    //if (cbxCancelReason.GetDataValue().ToString() == "0" && txtCancelReason.Text == "")
                    //{
                    //    XMessageBox.Show(Resources.MSG003,Resources.MSG001_CAP);
                    //    txtCancelReason.Focus();                        
                    //    return;
                    //}                   

                    break;
                    #endregion
            }
        }

        private bool ValidateCaseUpdate()
        {
            if (GetListInfoGrd("Added").Count == 0)
            {
                XMessageBox.Show(Resources.MSG004, Resources.MSG001_CAP);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XMessageBox.Show(Resources.MSG005, Resources.MSG001_CAP);
                txtName.Focus();
                return false;
            }
            if (cbxDiscount.GetDataValue() != "0")
            {
                if (txtDiscountReason.Visible && string.IsNullOrEmpty(txtDiscountReason.Text))
                {
                    XMessageBox.Show(Resources.MSG006, Resources.MSG001_CAP);
                    txtDiscountReason.Focus();
                    return false;
                }
            }
            if (cboPaymentType.GetDataValue().ToString() == "")
            {
                XMessageBox.Show(Resources.MSG007, Resources.MSG001_CAP);
                cboPaymentType.Focus();
                return false;
            }

            double payMoney = 0;
            double sumDebt = 0;
            double sumTotal = 0;
            double sumDiscount = 0;
            bool isSumTotal = Double.TryParse(dbxSum.Text, out sumTotal);
            bool isSumDiscount = Double.TryParse(dbxSumDiscount.Text, out sumDiscount);
            bool isNumTxtPayMoney = Double.TryParse(txtPayMoney.Text, out payMoney);
            bool isNumDbxSumDebt = Double.TryParse(dbxSumDebt.Text, out sumDebt);
            if (payMoney > sumDebt || (payMoney + sumDiscount) > sumTotal)
            {
                XMessageBox.Show(Resources.MSG008, Resources.MSG001_CAP);
                txtPayMoney.Text = "0";
                txtPayMoney.Focus();
                return false;
            }         
           
            return true;
        }

        private void BIL2016U02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            if (this.OpenParam != null)
            {
                if (this.OpenParam.Contains("f_bunho"))
                {
                    dbxPatientCode.Text = this.OpenParam["f_bunho"].ToString();
                }
                if (this.OpenParam.Contains("f_pay_yn"))
                {
                    payYN = this.OpenParam["f_pay_yn"].ToString();
                }
                if (this.OpenParam.Contains("f_pkout1001"))
                {
                    pkOut1001 = this.OpenParam["f_pkout1001"].ToString();
                }
                if (this.OpenParam.Contains("f_invoice_no"))
                {
                    invoiceNo = this.OpenParam["f_invoice_no"].ToString();
                }
                if (this.OpenParam.Contains("f_invoice_date"))
                {

                    if (!string.IsNullOrEmpty(this.OpenParam["f_invoice_date"].ToString()))
                    {
                        dtInvoiceDate.SetDataValue(this.OpenParam["f_invoice_date"].ToString());
                    }
                    else
                    {
                        this.dtInvoiceDate.SetDataValue(EnvironInfo.GetSysDate());
                    }
                }
                if (this.OpenParam.Contains("f_suname"))
                {
                    dbxPatientName.Text = (this.OpenParam["f_suname"].ToString());
                }
                if (this.OpenParam.Contains("f_birth"))
                {
                    birth = (this.OpenParam["f_birth"].ToString());
                }
                if (this.OpenParam.Contains("f_bunho_type"))
                {
                    mBunhoType = (this.OpenParam["f_bunho_type"].ToString());
                }
                if (this.OpenParam.Contains("f_address1"))
                {
                    address1 = (this.OpenParam["f_address1"].ToString());
                }
                if (this.OpenParam.Contains("f_sex"))
                {
                    sex = (this.OpenParam["f_sex"].ToString());
                }
                if (this.OpenParam.Contains("f_naewon_date"))
                {
                    naewonDate = (this.OpenParam["f_naewon_date"].ToString());
                }
                if (this.OpenParam.Contains("f_gwa"))
                {
                    gwa = (this.OpenParam["f_gwa"].ToString());
                }
                if (this.OpenParam.Contains("f_doctor"))
                {
                    doctor = (this.OpenParam["f_doctor"].ToString());
                }
                if (this.OpenParam.Contains("f_gwa_name"))
                {
                    gwaName = (this.OpenParam["f_gwa_name"].ToString());
                }
                if (this.OpenParam.Contains("f_doctor_name"))
                {
                    doctorName = (this.OpenParam["f_doctor_name"].ToString());
                }
                if (this.OpenParam.Contains("f_bunho_name"))
                {
                    bunhoTypeName = (this.OpenParam["f_bunho_name"].ToString());
                }
                if (this.OpenParam.Contains("f_cancel_yn"))
                {
                    cancelYN = (this.OpenParam["f_cancel_yn"].ToString());
                }
                if (this.OpenParam.Contains("f_phone"))
                {
                    phone = (this.OpenParam["f_phone"].ToString());
                }
                if (this.OpenParam.Contains("f_type"))
                {
                    typeCheck = (this.OpenParam["f_type"].ToString());
                }
                if (this.OpenParam.Contains("f_parent_invoice_no"))
                {
                    parentInvoiceNo = (this.OpenParam["f_parent_invoice_no"].ToString());
                }
                if (this.OpenParam.Contains("f_status_flg"))
                {
                    statusFlg = (this.OpenParam["f_status_flg"].ToString());
                }
                if (this.OpenParam.Contains("f_amount_debt"))
                {
                    amountDebt = (this.OpenParam["f_amount_debt"].ToString());
                }
                if (this.OpenParam.Contains("f_amount_paid"))
                {
                    amountPaid = (this.OpenParam["f_amount_paid"].ToString());
                }
                if (this.OpenParam.Contains("f_amount"))
                {
                    amount = (this.OpenParam["f_amount"].ToString());
                }
                if (this.OpenParam.Contains("f_discount"))
                {
                    discount = (this.OpenParam["f_discount"].ToString());
                }
            }
        }


        private void grdBIL2016U02_QueryStarting(object sender, CancelEventArgs e)
        {
            grdBIL2016U02.SetBindVarValue("f_invoice_no", invoiceNo);
            grdBIL2016U02.SetBindVarValue("f_invoice_date", dtInvoiceDate.GetDataValue());
            grdBIL2016U02.SetBindVarValue("f_patient_code", dbxPatientCode.Text);
            grdBIL2016U02.SetBindVarValue("f_pay_yn", payYN);
            grdBIL2016U02.SetBindVarValue("f_pkout_1001", pkOut1001);
            grdBIL2016U02.SetBindVarValue("f_bunho_type", mBunhoType);
        }
        #endregion
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }*/

        }

        private void txtPayMoney_Leave(object sender, EventArgs e)
        {
            decimal value;
            if (decimal.TryParse(txtPayMoney.Text, out value))
                //txtDiscount.Text = value.ToString("#,###");
                txtPayMoney.Text = FormatNumber(value.ToString(), true);
            else
                txtPayMoney.Text = "0";
        }

        private void cbxCancelReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxCancelReason.GetDataValue().ToString() == "0")
            //{
            //    txtCancelReason.Visible = true;
            //}
            //else
            //{
            //    txtCancelReason.Visible = false; 
            //}
        }


        private void grdBIL2016U02_ItemValueChanging(object sender, ItemValueChangingEventArgs e)
        {
            BindMoney(e.RowNumber, e.ChangeValue.ToString());
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            /*decimal value = 0;
            if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                //value = Convert.ToUInt64(txtDiscount.Text.Replace(@".",string.Empty));
                value = Convert.ToDecimal(FormatNumber(txtDiscount.Text, false));
                grdBIL2016U02.SetItemValue(grdBIL2016U02.CurrentRowNumber, "discount", value);
            }
            else
            {
                grdBIL2016U02.SetItemValue(grdBIL2016U02.CurrentRowNumber, "discount", 0);
            }
            BindMoney();*/
            dbxSumDiscount.Text = txtDiscount.Text;
        }

        private void grdBIL2016U02_RowFocusChanged(object sender, RowFocusChangedEventArgs e)
        {
            /*if (grdBIL2016U02.GetItemString(grdBIL2016U02.CurrentRowNumber, "discount") == "0" || string.IsNullOrEmpty(grdBIL2016U02.GetItemString(grdBIL2016U02.CurrentRowNumber, "discount")))
            {
                txtDiscount.Text = "";
                txtDiscountReason.Text = "";
            }
            else
            {
                txtDiscountReason.Text = grdBIL2016U02.GetItemString(grdBIL2016U02.CurrentRowNumber, "discount_reason");
                Int64 value;
                if (Int64.TryParse(grdBIL2016U02.GetItemString(grdBIL2016U02.CurrentRowNumber, "discount"), out value))
                    // txtDiscount.Text = value.ToString("#,###");
                    txtDiscount.Text = FormatNumber(value.ToString(), true);
                else
                    txtDiscount.Text = String.Empty;

            }*/
        }
        /// <summary>
        /// Short key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F9:
                    btnButtonList.PerformClick(FunctionType.Print);
                    return true;

                case Keys.F2:
                    if (payYN == "N")
                    {
                        btnButtonList.PerformClick(FunctionType.Update);
                    }
                    return true;

                case Keys.F4:
                    btnButtonList.PerformClick(FunctionType.Close);
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void txtDiscountReason_TextChanged(object sender, EventArgs e)
        {
            /*if (cbxDiscount.GetDataValue() == "1")
            {
                grdBIL2016U02.SetItemValue(grdBIL2016U02.CurrentRowNumber, "discount_reason", txtDiscountReason.Text);
            }
            else
            {
                grdBIL2016U02.SetItemValue(grdBIL2016U02.CurrentRowNumber, "discount_reason", "");
            }*/
        }
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            Int64 value;
            if (Int64.TryParse(txtDiscount.Text, out value))
                //txtDiscount.Text = value.ToString("#,###");
                txtDiscount.Text = FormatNumber(value.ToString(), true);
            else
                txtDiscount.Text = "0";
        }


        private void cbxDiscount_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxDiscount.GetDataValue() != "1") grdBIL2016U02.QueryLayout(false);
            if (cbxDiscount.GetDataValue() == "0") //Khong mien giam
            {
                txtDiscount.Text = "0";
                txtDiscount.Visible = false;
                lblMoneyDiscount.Visible = false;
                lblDiscountReson.Visible = false;
                txtDiscountReason.Visible = false;
                SetColPaidIsReadOnly(true);
            }
            if (cbxDiscount.GetDataValue() == "1")//Giam tren tung hoa don
            {
                if (IsFirstPaid())
                {
                    SetColPaidIsReadOnly(false);
                }
                else
                {
                    SetColPaidIsReadOnly(true);
                }
                txtDiscount.Text = "0";
                txtDiscount.Visible = false;
                lblMoneyDiscount.Visible = false;
                lblDiscountReson.Visible = false;
                txtDiscountReason.Visible = false;
                if (payYN == "N")
                {
                    txtDiscount.Focus();
                }
            }
            if (cbxDiscount.GetDataValue() == "2") //Tong hoa don
            {
                SetColPaidIsReadOnly(true);
                txtDiscount.Visible = true;
                lblMoneyDiscount.Visible = true;
                lblDiscountReson.Visible = true;
                txtDiscountReason.Visible = true;
                if (payYN == "N")
                {
                    txtDiscount.Focus();
                    txtDiscount.Text = "0";
                }
            }
        }

        private void dbxSumDiscount_Leave(object sender, EventArgs e)
        {
            Int64 value;
            if (Int64.TryParse(dbxSumDiscount.Text, out value))
            {
                //dbxSumDiscount.Text = value.ToString("#,###");
                dbxSumDiscount.Text = FormatNumber(value.ToString(), true);
            }
            else
            {
                dbxSumDiscount.Text = "0";
            }
        }

        private void dbxSumDiscount_TextChanged(object sender, EventArgs e)
        {
            decimal discount;
            decimal sum;
            try
            {
                //sum = Int64.Parse(dbxSum.Text.Replace(@".", string.Empty));
                sum = decimal.Parse(FormatNumber(dbxSum.Text, false));
            }
            catch
            {
                sum = 0;
            }

            try
            {
                //discount = Int64.Parse(dbxSumDiscount.Text.Replace(@".", string.Empty));
                discount = decimal.Parse(FormatNumber(dbxSumDiscount.Text, false));
            }
            catch
            {
                discount = 0;
            }
            decimal value = sum - discount;
            //dbxSumPatientPay.Text =  value.ToString("#,###");
            dbxSumPatientPay.Text = FormatNumber(value.ToString(), true);
            txtPayMoney.Text = FormatNumber(value.ToString(), true);
        }


        private void rbtPayDetail_CheckedChanged(object sender, EventArgs e)
        {
            CheckHideTabPayHistory();
            if (payYN == "C")
            {
                btnButtonList.SetEnabled(FunctionType.Print, false);
                btnButtonList.SetEnabled(FunctionType.Update, false);
                btnButtonList.SetEnabled(FunctionType.Close, true);
                btnButtonList.SetEnabled(FunctionType.Delete, false);
            }
            CheckCountGrdPayHistory();
        }

        private void rbtPayHistory_CheckedChanged(object sender, EventArgs e)
        {
            CheckHideTabPayHistory();
            grdPayHistory.ReadOnly = true;
            if (payYN != "C")
            {
                btnButtonList.SetEnabled(FunctionType.Print, true);
            }
            btnButtonList.SetEnabled(FunctionType.Update, false);
            btnButtonList.SetEnabled(FunctionType.Close, true);
            grdPayHistory.QueryLayout(true);
            CheckCountGrdPayHistory();
        }

        #endregion

        #region Method

        private void CheckSecondinvoices()
        {
            if (!IsFirstPaid())
            {
                cbxDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtDiscountReason.Enabled = false;
            }
        }

        private void CheckCountGrdPayHistory()
        {
            if (rbtPayHistory.Checked && grdPayHistory.RowCount <= 0)
                SetEnableBtnDel(false);
            else
            {
                if ((payYN == "Y" || payYN == "D") && rbtPayHistory.Checked) SetEnableBtnDel(true);
            }
        }

        private void EnableInputForJp(bool isEnable)
        {
            if (NetInfo.Language == LangMode.Jr)
            {
                cbxDiscount.Enabled = isEnable;
                lblMoneyDiscount.Visible = isEnable;
                txtDiscount.Visible = isEnable;
                txtDiscountReason.Visible = isEnable;
                lblDiscountReson.Visible = isEnable;
            }
        }

        #region GetData
        //Get data for Grid
        private List<object[]> GetDataBIL2016U02(Framework.BindVarCollection bc)
        {
            //todo //"f_patient_code", "f_pay_yn","f_pkout_1001"
            List<object[]> res = new List<object[]>();
            LoadGridBIL2016U02Args args = new LoadGridBIL2016U02Args();
            //args.InvoiceNo = bc["f_invoice_no"] != null ? bc["f_invoice_no"].VarValue : "";            
            args.InvoiceNo = invoiceNo;
            args.InvoiceDate = bc["f_invoice_date"] != null ? bc["f_invoice_date"].VarValue : "";
            args.PatientCode = bc["f_patient_code"] != null ? bc["f_patient_code"].VarValue : "";
            if (isCheckSave)
            {
                args.PayYn = "Y";
            }
            else
            {
                args.PayYn = bc["f_pay_yn"] != null ? bc["f_pay_yn"].VarValue : "";
            }
            args.Pkout1001 = bc["f_pkout_1001"] != null ? bc["f_pkout_1001"].VarValue : "";
            args.BunhoType = mBunhoType;
            args.Type = typeCheck;
            args.Bunho = dbxPatientCode.Text != null ? dbxPatientCode.Text : "";
            args.PatientNm = dbxPatientName.Text;
            args.ParentInvoiceNo = parentInvoiceNo;
            args.StatusFlg = statusFlg;
            args.AmountDebt = amountDebt;
            args.AmountPaid = amountPaid;
            args.Amount = amount;
            args.Discount = discount;
            resultLoad = CloudService.Instance.Submit<LoadGridBIL2016U02Result, LoadGridBIL2016U02Args>(args);
            if (resultLoad.ExecutionStatus == ExecutionStatus.Success)
            {
                // https://sofiamedix.atlassian.net/browse/MED-11876
                this.SetRevertComment(resultLoad.RevertType, resultLoad.RevertComment);

                //Set invoice no
                if (!string.IsNullOrEmpty(resultLoad.InvoiceNo) && isCheckSave == false)
                {
                    txtInvoiceNo.Text = resultLoad.InvoiceNo;
                }
                else
                {
                    txtInvoiceNo.Text = invoiceNo;
                }
                foreach (LoadGridBIL2016U02Info info in resultLoad.InvoiceDetail)
                {
                    object[] objects = 
                        {
                            "Y",
                            info.HangmogCode,
                            info.HangmogName,
                            info.Unit,
                            info.Price,
                            info.Quantity,
                            info.Amount,
                            info.Amount,
                            info.InsurancePay,
                            info.PatientPay,
                            info.Discount,
                            info.DeptReqNm,
                            info.DoctorReqNm,
                            info.DeptExcNm,
                            info.DoctorExcNm,
                            info.OrderGroupNm,
                            info.DeptReqCd,
                            info.DoctorExcCd,
                            info.OrderGroupCd,
                            info.OrderDate,
                            info.ActingDate,
                            info.DoctorReqCd,
                            info.DiscountReason,
                            info.Fkocs1003,
                            info.Fkout1001,
                            info.PatientAddress
                   
                        };
                    res.Add(objects);
                }


            }
            return res;
        }
        //Load data for Grd History
        private List<object[]> LoadGrdBIL2016U02PayHistory(Framework.BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadGridPayHistoryBIL2016U02Args args = new LoadGridPayHistoryBIL2016U02Args();
            /*args.ParentInvoiceNo = invoiceNo;*/
            args.ParentInvoiceNo = parentInvoiceNo;
            LoadGridPayHistoryBIL2016U02Result result = CloudService.Instance.Submit<LoadGridPayHistoryBIL2016U02Result, LoadGridPayHistoryBIL2016U02Args>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (LoadGridPayHistoryBIL2016U02Info info in result.GrdPayHistory)
                {
                    object[] objects = 
                        {
                            info.InvoiceDate,
                            info.InvoiceNo,                            
                            info.Amount,
                            info.Discount,
                            info.AmountPaid,                                                       
                            info.AmountDebt,                            
                            ConvertToStatus(info.ActiveFlg)                            
                        };
                    res.Add(objects);
                }
                //CheckStatusInvoice();    
            }
            return res;

        }
        //Check status invoice of tab Pay History
        private string ConvertToStatus(string vlua)
        {
            string strA = "";
            if (vlua == "0")
            {
                strA = Resources.MSG010;
            }
            else if (vlua == "2")
            {
                strA = Resources.MSG011;
            }
            else if (vlua == "3")
            {
                strA = Resources.MSG012;
            }
            return strA;
        }
        //Get data for combobox Invoice Date- No
        private IList<object[]> GetDataComboInvoiceBIL2016U02(Framework.BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            GetDataComboInvoiceBIL2016U02Args args = new GetDataComboInvoiceBIL2016U02Args();
            args.ParentInvoiceNo = parentInvoiceNo;
            GetDataComboInvoiceBIL2016U02Result result = CloudService.Instance.Submit<GetDataComboInvoiceBIL2016U02Result, GetDataComboInvoiceBIL2016U02Args>(args);
            if (result != null && result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (GetDataComboInvoiceBIL2016U02Info item in result.ComboInvoice)
                {
                    object[] objects = 
                        {
                            item.InvoiceNo,
                            item.InvoiceDate + "-" + item.InvoiceNo
                        };
                    res.Add(objects);
                }
            }
            return res;
        }
        //Get data for Combo payment
        private IList<object[]> GetDataComboBIL2016U02(Framework.BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadComboBIL2016U02Args args = new LoadComboBIL2016U02Args();
            args.ComboType = "PAYMENT_TYPE"; //Paymen type
            ComboResult result = CloudService.Instance.Submit<ComboResult, LoadComboBIL2016U02Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.ComboItem)
                {
                    object[] objects = 
                        {
                            info.Code,
                            info.CodeName
                        };
                    res.Add(objects);
                }
            }
            return res;
        }
        //Get data for Combo REVERT_TYPE
        private IList<object[]> GetDataComboRevertBIL2016U02(Framework.BindVarCollection bc)
        {
            List<object[]> res = new List<object[]>();
            LoadComboBIL2016U02Args args = new LoadComboBIL2016U02Args();
            args.ComboType = "REVERT_TYPE"; //REVERT_TYPE
            ComboResult result = CloudService.Instance.Submit<ComboResult, LoadComboBIL2016U02Args>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                foreach (ComboListItemInfo info in result.ComboItem)
                {
                    object[] objects = 
                        {
                            info.Code,
                            info.CodeName
                        };
                    res.Add(objects);
                }
            }
            return res;
        }
        //Get data for Button Click
        private List<LoadGridBIL2016U02Info> GetListInfoGrd(string type)
        {
            List<LoadGridBIL2016U02Info> inputList = new List<LoadGridBIL2016U02Info>();
            if (type == "Deleted")
            {
                for (int i = 0; i < grdPayHistory.RowCount; i++)
                {
                    if (i != grdPayHistory.CurrentRowNumber) continue;
                    LoadGridBIL2016U02Info infoDel = new LoadGridBIL2016U02Info();
                    infoDel.HangmogCode = "";
                    infoDel.HangmogName = "";
                    infoDel.Unit = "";
                    infoDel.Price = "";
                    infoDel.Quantity = "";
                    infoDel.Amount = "";
                    infoDel.InsurancePay = "";
                    infoDel.PatientPay = "";
                    infoDel.Discount = "";
                    infoDel.DeptReqNm = "";
                    infoDel.DoctorReqNm = "";
                    infoDel.DeptExcNm = "";
                    infoDel.DoctorExcNm = "";
                    infoDel.OrderGroupNm = "";
                    infoDel.DeptReqCd = "";
                    infoDel.DeptExcCd = "";
                    infoDel.OrderGroupCd = "";
                    infoDel.OrderDate = "";
                    infoDel.ActingDate = "";
                    infoDel.DoctorReqCd = "";
                    infoDel.DiscountReason = "";
                    infoDel.Fkocs1003 = "";
                    infoDel.CheckYn = "";
                    infoDel.AmountDebt = "";
                    infoDel.AmountPaid = "";
                    infoDel.DoctorExcCd = "";

                    inputList.Add(infoDel);
                }
            }
            else
            {
                for (int i = 0; i < grdBIL2016U02.RowCount; i++)
                {
                    if (type == "Added" && grdBIL2016U02.GetItemString(i, "check_box") != "Y") continue;// Only check box save
                    LoadGridBIL2016U02Info info = new LoadGridBIL2016U02Info();
                    info.HangmogCode = grdBIL2016U02.GetItemString(i, "hangmog_code");
                    info.HangmogName = grdBIL2016U02.GetItemString(i, "hangmog_name");
                    info.Unit = grdBIL2016U02.GetItemString(i, "unit");
                    info.Price = grdBIL2016U02.GetItemString(i, "price");
                    info.Quantity = grdBIL2016U02.GetItemString(i, "quantity");
                    info.Amount = grdBIL2016U02.GetItemString(i, "amount");
                    info.InsurancePay = grdBIL2016U02.GetItemString(i, "insurance_pay");
                    info.PatientPay = grdBIL2016U02.GetItemString(i, "patient_pay");
                    info.Discount = grdBIL2016U02.GetItemString(i, "discount");
                    info.DeptReqNm = grdBIL2016U02.GetItemString(i, "dept_req_nm");
                    info.DoctorReqNm = grdBIL2016U02.GetItemString(i, "doctor_req_nm");
                    info.DeptExcNm = grdBIL2016U02.GetItemString(i, "dept_exc_nm");
                    info.DoctorExcNm = grdBIL2016U02.GetItemString(i, "doctor_exc_nm");
                    info.OrderGroupNm = grdBIL2016U02.GetItemString(i, "order_group_nm");
                    info.DeptReqCd = grdBIL2016U02.GetItemString(i, "dept_req_cd");
                    info.DeptExcCd = grdBIL2016U02.GetItemString(i, "dept_req_cd");
                    info.OrderGroupCd = grdBIL2016U02.GetItemString(i, "order_group_cd");
                    info.OrderDate = grdBIL2016U02.GetItemString(i, "order_date");
                    info.ActingDate = grdBIL2016U02.GetItemString(i, "acting_date");
                    info.DoctorExcCd = grdBIL2016U02.GetItemString(i, "dept_exc_cd");
                    info.DoctorReqCd = grdBIL2016U02.GetItemString(i, "doctor_req_cd");
                    info.DiscountReason = grdBIL2016U02.GetItemString(i, "discount_reason");
                    info.Fkocs1003 = grdBIL2016U02.GetItemString(i, "fkocs1003");
                    info.CheckYn = grdBIL2016U02.GetItemString(i, "check_box");

                    inputList.Add(info);
                }
            }

            return inputList;
        }

        private bool SaveBill2016U02(string type)
        {
            soBL = txtInvoiceNo.Text;
            bool isCheck = true;
            SaveBIL2016U02Args args = new SaveBIL2016U02Args();
            args.ListInfo = GetListInfoGrd(type);
            if (rbtPayHistory.Checked)
            {
                double amountPaidLaste = 0;
                double amountDebtLaste = 0;
                double totalDebt = 0;
                bool a = Double.TryParse(grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "paid_amount"), out amountPaidLaste);
                bool b = Double.TryParse(grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "debt_amount"), out amountDebtLaste);
                totalDebt = amountPaidLaste + amountDebtLaste;
                args.InvoiceNo = grdPayHistory.GetItemString(grdPayHistory.CurrentRowNumber, "invoice_no");
                args.AmountDebtLatest = totalDebt.ToString();
            }
            else
            {
                args.InvoiceNo = txtInvoiceNo.Text;
                args.AmountDebtLatest = "";
            }
            args.InvoiceDate = dtInvoiceDate.GetDataValue();
            args.PaymentCode = cboPaymentType.GetDataValue();
            args.Bunho = dbxPatientCode.Text;
            args.Suname = dbxPatientName.Text;
            args.Address = address1;
            args.Sex = sex;
            args.Birth = birth;
            args.NaewonDate = naewonDate;
            args.Gwa = gwa;
            args.Doctor = doctor;
            args.GwaName = gwaName;
            args.DoctorName = doctorName;
            args.BunhoType = mBunhoType;
            args.Fkout1001 = pkOut1001;
            args.Amount = totalPay.ToString();                  //Required sent to server.
            args.RowState = type;
            //args.RevertType = cbxCancelReason.GetDataValue();
            //args.RevertComment = txtCancelReason.Text;
            args.BunhoTypeName = bunhoTypeName;
            args.Phone = phone;

            args.DiscountType = cbxDiscount.GetDataValue(); //Hinh thuc mien giam
            args.Discount = txtDiscount.Text.Replace(".", "").Replace(",", ""); //So tien mien giam
            args.DiscountReasonTotal = txtDiscountReason.Text; //Ly do mien giam
            args.PaidName = txtName.Text; //Doi tuong thanh toan
            args.PaymentName = cboPaymentType.GetDataValue(); //Hinh t huc thanh toan
            args.PayMoney = txtPayMoney.Text.Replace(".", "").Replace(",", ""); //So tien thanh toan
            args.ParentInvoiceNo = parentInvoiceNo.Trim();
            args.Type = typeCheck;
            //args.Type = "1";

            double totalAmountDebt = 0;
            bool isNumSumDebt = Double.TryParse(dbxSumDebt.Text, out totalAmountDebt);
            if (totalAmountDebt > 0)
            {
                args.StatusFlg = "3";
            }
            else
                args.StatusFlg = "2";
            args.RevertReason = revertReason;
            //==================================
            //args.AmountDebtLatest = "";
            args.RevertComment = "";
            args.RevertType = "";
            args.StatusFlgParentNoNull = "";
            //===================================
            UpdateResult result = CloudService.Instance.Submit<UpdateResult, SaveBIL2016U02Args>(args);
            if (result.ExecutionStatus != ExecutionStatus.Success || result.Result == false)
            {
                isCheck = false;
            }
            else
            {
                isCheck = true;
                txtInvoiceNo.Text = result.Msg;
                if (payYN == "N") //tab un paid when double click
                {
                    firstParentInvoice = result.Msg;
                    invoiceNo = parentInvoiceNo = result.Msg;
                    txtPayMoney.ReadOnly = true;
                }
                CheckCountGrdPayHistory();
            }
            return isCheck;
        }

        #endregion

        private string TryPareFormatNum(string value)
        {
            string strValue = "";
            double dValue = 0;
            bool checkValueNum = Double.TryParse(value, out dValue);
            strValue = FormatNumber(dValue.ToString(), true);
            return strValue;
        }

        // Validate paid money
        #region Convert money
        private string joinUnit(string n)
        {
            int sokytu = n.Length;
            int sodonvi = (sokytu % 3 > 0) ? (sokytu / 3 + 1) : (sokytu / 3);
            n = n.PadLeft(sodonvi * 3, '0');
            sokytu = n.Length;
            string chuoi = "";
            int i = 1;
            while (i <= sodonvi)
            {
                if (i == sodonvi) chuoi = joinNumber((int.Parse(n.Substring(sokytu - (i * 3), 3))).ToString()) + unit(i) + chuoi;
                else chuoi = joinNumber(n.Substring(sokytu - (i * 3), 3)) + unit(i) + chuoi;
                i += 1;
            }
            return chuoi;
        }


        private string unit(int n)
        {
            string chuoi = "";
            if (n == 1) chuoi = " đồng ";
            else if (n == 2) chuoi = " nghìn ";
            else if (n == 3) chuoi = " triệu ";
            else if (n == 4) chuoi = " tỷ ";
            else if (n == 5) chuoi = " nghìn tỷ ";
            else if (n == 6) chuoi = " triệu tỷ ";
            else if (n == 7) chuoi = " tỷ tỷ ";
            return chuoi;
        }


        private string convertNumber(string n)
        {
            string chuoi = "";
            if (n == "0") chuoi = "không";
            else if (n == "1") chuoi = "một";
            else if (n == "2") chuoi = "hai";
            else if (n == "3") chuoi = "ba";
            else if (n == "4") chuoi = "bốn";
            else if (n == "5") chuoi = "năm";
            else if (n == "6") chuoi = "sáu";
            else if (n == "7") chuoi = "bảy";
            else if (n == "8") chuoi = "tám";
            else if (n == "9") chuoi = "chín";
            return chuoi;
        }


        private string joinNumber(string n)
        {
            string chuoi = "";
            int i = 1, j = n.Length;
            while (i <= j)
            {
                if (i == 1) chuoi = convertNumber(n.Substring(j - i, 1)) + chuoi;
                else if (i == 2) chuoi = convertNumber(n.Substring(j - i, 1)) + " mươi " + chuoi;
                else if (i == 3) chuoi = convertNumber(n.Substring(j - i, 1)) + " trăm " + chuoi;
                i += 1;
            }
            return chuoi;
        }


        private string replaceSpecialWord(string chuoi)
        {
            chuoi = chuoi.Replace("không mươi không ", "");
            chuoi = chuoi.Replace("không mươi", "lẻ");
            chuoi = chuoi.Replace("i không", "i");
            chuoi = chuoi.Replace("i năm", "i lăm");
            chuoi = chuoi.Replace("một mươi", "mười");
            chuoi = chuoi.Replace("mươi một", "mươi mốt");
            return chuoi;
        }
        #endregion



        private void SetEnableControl(bool valueTF)
        {
            dbxPatientCode.Enabled = valueTF;
            dbxPatientName.Enabled = valueTF;
            txtInvoiceNo.Enabled = valueTF;
            dtInvoiceDate.Enabled = valueTF;

            if (payYN != "D")
            {
                txtDiscount.Enabled = valueTF;
                txtDiscountReason.Enabled = valueTF;
                txtName.Enabled = valueTF;
                cboPaymentType.Enabled = valueTF;
                cbxDiscount.Enabled = valueTF;

            }

            if (payYN != "N" && payYN != "D")
            {
                //grdBIL2016U02.Enabled = valueTF;
                //https://sofiamedix.atlassian.net/browse/MED-13645 
                grdBIL2016U02.ReadOnly = valueTF;
            }
            // disnable checkbox.
            this.xEditGridCell23.IsReadOnly = !valueTF;
        }

        private void BindMoney(int rowNumber, string value)
        {
            //Set sum ini
            totalDiscount = 0;
            totalPatient = 0;
            totalPay = 0;

            for (int i = 0; i < grdBIL2016U02.RowCount; i++)
            {
                if (grdBIL2016U02.GetItemString(i, "check_box") == "Y")
                {
                    if (i == rowNumber) continue;
                    totalPay += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "amount"), false));
                    //totalDiscount += ConvertToUInt64(grdBIL2016U02.GetItemString(i, "discount"));
                    totalDiscount += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "discount"), false));
                }
            }
            if (value == "Y")
            {
                //totalPay += ConvertToUInt64(grdBIL2016U02.GetItemString(rowNumber, "amount"));
                //totalDiscount += ConvertToUInt64(grdBIL2016U02.GetItemString(rowNumber, "discount"));

                totalPay += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(rowNumber, "amount"), false));
                totalDiscount += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(rowNumber, "discount"), false));
            }

            if (resultLoad.TotalDiscount == "0")
            {
                totalPatient = totalPay - totalDiscount;
                //dbxSumDiscount.Text = totalDiscount.ToString("#,###");
                dbxSumDiscount.Text = FormatNumber(totalDiscount.ToString(), true);
            }
            else
            {
                if (!string.IsNullOrEmpty(resultLoad.TotalDiscount))
                {
                    totalPatient = totalPay - double.Parse(!string.IsNullOrEmpty(resultLoad.TotalDiscount) ? resultLoad.TotalDiscount : "0");
                }
                else
                {
                    totalPatient = totalPay;
                }
            }
            //dbxSum.Text = totalPay.ToString("#,###");
            dbxSum.Text = FormatNumber(totalPay.ToString(), true);
            //dbxSumDiscount.Text = totalDiscount.ToString("#,###");
            //dbxSumPatientPay.Text = totalPatient.ToString("#,###");
            dbxSumPatientPay.Text = FormatNumber(totalPatient.ToString(), true);
            txtName.Text = resultLoad.PaidName;
            if (!String.IsNullOrEmpty(resultLoad.PaymentCode))
            {
                cboPaymentType.SetDataValue(resultLoad.PaymentCode);
            }
            if (!String.IsNullOrEmpty(resultLoad.DiscountType))
            {
                cbxDiscount.SetDataValue(resultLoad.DiscountType);
            }
        }

        private void BindMoney()
        {
            //Set sum ini
            totalDiscount = 0;
            totalPatient = 0;
            totalPay = 0;
            //for (int i = 0; i < resultLoad.InvoiceDetail.Count; i++)   

            for (int i = 0; i < grdBIL2016U02.RowCount; i++)
            {
                if (grdBIL2016U02.GetItemString(i, "check_box") == "Y")
                {
                    //totalPay += ConvertToUInt64(grdBIL2016U02.GetItemString(i, "amount"));
                    //totalDiscount += ConvertToUInt64(grdBIL2016U02.GetItemString(i, "discount"));

                    totalPay += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "amount"), false));
                    totalDiscount += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "discount"), false));
                }
            }

            if (resultLoad.TotalDiscount == "0")
            {
                totalPatient = totalPay - totalDiscount;
                //dbxSumDiscount.Text = totalDiscount.ToString("#,###");
                dbxSumDiscount.Text = FormatNumber(totalDiscount.ToString(), true);
            }

            else
            {
                if (!string.IsNullOrEmpty(resultLoad.TotalDiscount))
                {
                    totalPatient = totalPay - double.Parse(resultLoad.TotalDiscount != "" ? resultLoad.TotalDiscount : "0");
                }
                else
                {
                    totalPatient = totalPay;
                }
            }
            dbxSum.Text = FormatNumber(totalPay.ToString(), true);
            //dbxSumPatientPay.Text = totalPatient.ToString("#,###");
            dbxSumPatientPay.Text = FormatNumber(totalPatient.ToString(), true);
            //txtName.Text = resultLoad.PaidName;
            if (!String.IsNullOrEmpty(resultLoad.PaymentCode))
            {
                cboPaymentType.SetDataValue(resultLoad.PaymentCode);
            }

        }

        private void BindTotalMoney()
        {
            if (resultLoad != null)
            {
                dbxSum.Text = FormatNumber(resultLoad.TotalAmount, true);   //Tong thanh tien
                dbxSumDiscount.Text = FormatNumber(resultLoad.TotalPatientDiscount, true);   //Tong mien giam
                dbxSumPatientPay.Text = FormatNumber(resultLoad.TotalPatientPay, true);   //Tong benh nhan tra
                dbxSumPay.Text = FormatNumber(resultLoad.TotalAmountPaid, true);   //Tong benh nhan da tra (*)
                dbxSumDebt.Text = FormatNumber(resultLoad.TotalAmountDebt, true);   //Tong benh nhan con no
                txtPayMoney.Text = FormatNumber(resultLoad.TotalAmountDebt, true);
            }
        }

        private void CalculatorMoney()
        {
            double discountEachPart = 0;
            for (int i = 0; i < grdBIL2016U02.RowCount; i++)
            {
                //totalDiscount += ConvertToUInt64(grdBIL2016U02.GetItemString(i, "discount"));
                double amountPart = Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "amount"), false));
                double discountPart = Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "discount"), false));

                if (discountPart > amountPart)
                {
                    XMessageBox.Show(Resources.BIL0102U00_CalculatorMoney_Validate, Resources.MSG001_CAP);
                    
                    grdBIL2016U02.SetItemValue(i, "discount", "0");
                    return;
                }

                discountEachPart += Convert.ToUInt64(FormatNumber(grdBIL2016U02.GetItemString(i, "discount"), false));
            }

            double discountAllPart = Convert.ToUInt64(txtDiscount.Text.Replace(".", "").Replace(",", ""));
            double sumDiscount = discountEachPart + discountAllPart;
            double sumPay = Convert.ToUInt64(dbxSumPay.Text.Replace(".", "").Replace(",", ""));
            dbxSumDiscount.Text = FormatNumber(sumDiscount.ToString(), true);

            double sumPatientPay = Convert.ToUInt64(dbxSum.Text.Replace(".", "").Replace(",", "")) - sumDiscount;
            double payMoney = Convert.ToUInt64(dbxSum.Text.Replace(".", "").Replace(",", "")) - sumDiscount - sumPay;
            dbxSumPatientPay.Text = FormatNumber(sumPatientPay.ToString(), true);
            txtPayMoney.Text = FormatNumber(payMoney.ToString(), true);
        }

        private void ResetInputValue()
        {
            cbxDiscount.SelectedIndex = 0;
            txtDiscount.Text = "0";
            if (payYN == "D")
            {
                txtName.Text = resultLoad.PaidName;
            }
            SetEnableBtnDel(false);
            txtDiscountReason.Text = string.Empty;
            cboPaymentType.SelectedIndex = 0;

            if (payYN != "C")
            {
                txtPayMoney.Text = "0";
            }
            SetColPaidIsReadOnly(true);
        }

        //private UInt64 ConvertToUInt64(string number)
        //{
        //    UInt64 outPut = 0;
        //    if (!string.IsNullOrEmpty(number))
        //    {
        //        if (number.IndexOf(".") > 0)
        //        {
        //            //outPut = Convert.ToUInt64(number.Remove(number.IndexOf(".")));
        //            outPut = Convert.ToUInt64(FormatNumber(number, false));
        //        }
        //        else
        //        {
        //            outPut = Convert.ToUInt64(number);
        //        }
        //    }
        //    return outPut;
        //}



        private bool IsFirstPaid()
        {
            return string.IsNullOrEmpty(parentInvoiceNo.Trim()) || parentInvoiceNo.Trim() == "0"; //Lan 1
        }

        private void SetColPaidIsReadOnly(bool value)
        {
            xEditGridCell10.IsReadOnly = value;
            xEditGridCell24.IsReadOnly = value;
        }


        private string FormatNumber(string value, bool useSeparator)
        {
            if (string.IsNullOrEmpty(value)) return "0";

            decimal number;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;

            if (decimal.TryParse(value, style, Thread.CurrentThread.CurrentCulture, out number))
            {
                value = useSeparator ? number.ToString("N0") : number.ToString();
            }
            else
            {
                //ctrl.Text = "";
            }

            return value;
        }

        //private Int64 ParseToInt64(string value)
        //{
        //    Int64 retVal = 0;

        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return retVal;
        //    }

        //    if (Int64.TryParse(
        //}

        private void SetRevertComment(string revertType, string revertComment)
        {
            // https://sofiamedix.atlassian.net/browse/MED-11876
            //if (this.payYN == "C")
            //{
            //    cbxCancelReason.SetEditValue(revertType);
            //    cbxCancelReason.Enabled = false;
            //    if (revertType == "0")
            //    {
            //        txtCancelReason.Visible = true;
            //        txtCancelReason.Text = revertComment;
            //        txtCancelReason.ReadOnly = true;
            //    }
            //}
        }

        private void CheckHideTabPayHistory()
        {
            if (rbtPayDetail.Checked)
            {
                xPanel51.Visible = true;
                xPanel52.Visible = false;
                if (payYN == "N" || payYN == "D")
                {
                    btnButtonList.SetEnabled(FunctionType.Update, true);
                }
                SetEnableBtnDel(false);

                if (payYN == "N" || payYN == "C")
                {
                    cbxInvoiceList.Visible = false;
                }
                else
                    cbxInvoiceList.Visible = true;

            }
            else
            {
                xPanel51.Visible = false;
                xPanel52.Visible = true;
                cbxInvoiceList.Visible = false;
            }
        }

        private void SetEnableBtnDel(bool isEnable)
        {
            btnButtonList.SetEnabled(FunctionType.Delete, isEnable);
        }

        #endregion

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
           string yoyangname = "";
            string address_hosp = "";
            string tel_hosp = "";
            string email_hosp = "";
            string locale = "";
            string email_patient = "";
            string mail_template_id = "";
            string subject = "";
            string content = "";
            string naewon_date = "";
            string jubsu_time = "";

            string bank_name = "";
            string bank_jijum = "";
            string bank_acc_type = "";
            string bank_no = "";
            string bank_acc_name = "";

           //1. Get hospital infomation
            BIL0102U00GetHospInfoArgs args_hosp_info = new BIL0102U00GetHospInfoArgs();
            args_hosp_info.HospCode = UserInfo.HospCode;
            args_hosp_info.StartDate = ""; // get from server
            BIL0102U00GetHospInfoResult res_hosp_info = CloudService.Instance.Submit<BIL0102U00GetHospInfoResult, BIL0102U00GetHospInfoArgs>(args_hosp_info);
            if (res_hosp_info.ExecutionStatus == ExecutionStatus.Success)
            {
                yoyang_name = res_hosp_info.YoyangName;
                address_hosp = res_hosp_info.Address;
                tel_hosp = res_hosp_info.Tel;
                email_hosp = res_hosp_info.Email;
                locale = res_hosp_info.Locale;
            }

            //2. Get patient email request
            BIL0102U00GetPatientEmailArgs args_get_patient_email = new BIL0102U00GetPatientEmailArgs();
            args_get_patient_email.HospCode = UserInfo.HospCode;
            args_get_patient_email.Bunho = dbxPatientCode.GetDataValue();
            BIL0102U00GetPatientEmailResult res_get_patient_email = CloudService.Instance.Submit<BIL0102U00GetPatientEmailResult, BIL0102U00GetPatientEmailArgs>(args_get_patient_email);
            if (res_get_patient_email.ExecutionStatus == ExecutionStatus.Success)
            {
                email_patient = res_get_patient_email.Email;
            }

           

            //4. get examination information
            BIL0102U00GetExaminationInfoArgs args_examination = new BIL0102U00GetExaminationInfoArgs();
            args_examination.HospCode = UserInfo.HospCode;
            args_examination.Pkout1001 = pkOut1001;
            BIL0102U00GetExaminationInfoResult res_examination = CloudService.Instance.Submit<BIL0102U00GetExaminationInfoResult, BIL0102U00GetExaminationInfoArgs>(args_examination);
            if (res_examination.ExecutionStatus == ExecutionStatus.Success)
            {
                naewon_date = res_examination.NaewonDate;
                jubsu_time = res_examination.JubsuTime;
                bank_name = res_examination.BankInfo.BankName;
                bank_jijum = res_examination.BankInfo.BankJijum;
                bank_acc_type = res_examination.BankInfo.BankAccType;
                bank_no = res_examination.BankInfo.BankNo;
                bank_acc_name = res_examination.BankInfo.BankAccName;
            }

            //3. Get mail template

            BIL0102U00GetMailTemplateOldArgs args_mailTemplate = new BIL0102U00GetMailTemplateOldArgs();
            args_mailTemplate.Locale = "";
            args_mailTemplate.TemplateCode = "SEND_PAYMEN";
            args_mailTemplate.YoyangName = yoyang_name;
            args_mailTemplate.AddressHosp = address_hosp;
            args_mailTemplate.PatientName = dbxPatientName.GetDataValue();
            args_mailTemplate.TelHosp = tel_hosp;
            args_mailTemplate.EmailHosp = email_hosp;
            args_mailTemplate.MailPatient = email_patient;
            args_mailTemplate.MailTemplateIt = mail_template_id;
            args_mailTemplate.Subject = "";
            args_mailTemplate.Content = "";
            args_mailTemplate.NaewonDate = DateTime.Parse(naewon_date.Substring(0, 10)).ToString("yyyy/MM/dd"); ;
            args_mailTemplate.JubsuTime = jubsu_time;
            args_mailTemplate.Total = dbxSum.GetDataValue();
            args_mailTemplate.TotalDiscount = dbxSumDiscount.GetDataValue();
            args_mailTemplate.TotalPaid = dbxSumPatientPay.GetDataValue();
            args_mailTemplate.TotalPaying = dbxSumDebt.GetDataValue();

            args_mailTemplate.BankName = bank_name;
            args_mailTemplate.BankJijum = bank_jijum;
            args_mailTemplate.BankAccType = bank_acc_type;
            args_mailTemplate.BankNo = bank_no;
            args_mailTemplate.BankAccName = bank_acc_name;


            BIL0102U00GetMailTemplateResult res_mailTemplate = CloudService.Instance.Submit<BIL0102U00GetMailTemplateResult, BIL0102U00GetMailTemplateOldArgs>(args_mailTemplate);
            if (res_mailTemplate.ExecutionStatus == ExecutionStatus.Success)
            {
                mail_template_id = res_mailTemplate.MailTemplateId;
                subject = res_mailTemplate.Subject;
                content = res_mailTemplate.Content;
            }
            //5. Send data to SendMail Form 
            SendBilling_old formSendBilling = new SendBilling_old(yoyang_name, address_hosp, dbxPatientName.GetDataValue(), tel_hosp, email_hosp, locale, email_patient, mail_template_id, subject, content, naewon_date, jubsu_time, dbxSum.GetDataValue(), dbxSumDiscount.GetDataValue(), dbxSumPatientPay.GetDataValue(), dbxSumDebt.GetDataValue(), bank_name, bank_jijum, bank_acc_type, bank_no, bank_acc_name);
            formSendBilling.Show();
        }

        private List<BIL0102OrderListInfo> GetListOrder()
        {
            List<BIL0102OrderListInfo> res = new List<BIL0102OrderListInfo>();
            for (int i = 0; i < grdBIL2016U02.RowCount; i++)
            {
                BIL0102OrderListInfo info = new BIL0102OrderListInfo();
                info.OrderName = grdBIL2016U02.GetItemString(i, "hangmog_name");
                info.Unit = grdBIL2016U02.GetItemString(i, "unit");
                info.Price = grdBIL2016U02.GetItemString(i, "price");
                info.Quantity = grdBIL2016U02.GetItemString(i, "quantity");
                info.Amount = grdBIL2016U02.GetItemString(i, "amount");
                info.InsurancePay = grdBIL2016U02.GetItemString(i, "insurance_pay");
                info.PatientPay = grdBIL2016U02.GetItemString(i, "patient_pay");
                info.DeptReqNm = grdBIL2016U02.GetItemString(i, "dept_req_nm");
                info.DoctorReqNm = grdBIL2016U02.GetItemString(i, "doctor_req_nm");
                info.DoctorExcNm = grdBIL2016U02.GetItemString(i, "doctor_exc_nm");
                info.OrderGrpNm = grdBIL2016U02.GetItemString(i, "order_group_nm");
                info.OrderCode = grdBIL2016U02.GetItemString(i, "hangmog_code");
                info.Fkocs1003 = grdBIL2016U02.GetItemString(i, "fkocs1003");
                res.Add(info);
            }
            return res;
        }

        private void btnSendmail_Click(object sender, EventArgs e)
        {
            string yoyangname = "";
            string address_hosp = "";
            string tel_hosp = "";
            string email_hosp = "";
            string locale = "";
            string email_patient = "";
            string mail_template_id = "";
            string subject = "";
            string content = "";
            string naewon_date = "";
            string jubsu_time = "";

            string bank_name = "";
            string bank_jijum = "";
            string bank_acc_type = "";
            string bank_no = "";
            string bank_acc_name = "";
            string fkout1001 = "";
            if (grdBIL2016U02 != null && grdBIL2016U02.RowCount > 0)
            {
                fkout1001 = grdBIL2016U02.GetItemString(0, "fkout1001");
            }
            string gmolink = "";
            


            List<BIL0102OrderListInfo> orderlist = GetListOrder();
            //1. Get hospital infomation
            BIL0102U00GetHospInfoArgs args_hosp_info = new BIL0102U00GetHospInfoArgs();
            args_hosp_info.HospCode = UserInfo.HospCode;
            args_hosp_info.StartDate = ""; // get from server
            BIL0102U00GetHospInfoResult res_hosp_info = CloudService.Instance.Submit<BIL0102U00GetHospInfoResult, BIL0102U00GetHospInfoArgs>(args_hosp_info);
            if (res_hosp_info.ExecutionStatus == ExecutionStatus.Success)
            {
                yoyang_name = res_hosp_info.YoyangName;
                address_hosp = res_hosp_info.Address;
                tel_hosp = res_hosp_info.Tel;
                email_hosp = res_hosp_info.Email;
                locale = res_hosp_info.Locale;
            }

            //2. Get patient email request
            BIL0102U00GetPatientEmailArgs args_get_patient_email = new BIL0102U00GetPatientEmailArgs();
            args_get_patient_email.HospCode = UserInfo.HospCode;
            args_get_patient_email.Bunho = dbxPatientCode.GetDataValue();
            BIL0102U00GetPatientEmailResult res_get_patient_email = CloudService.Instance.Submit<BIL0102U00GetPatientEmailResult, BIL0102U00GetPatientEmailArgs>(args_get_patient_email);
            if (res_get_patient_email.ExecutionStatus == ExecutionStatus.Success)
            {
                email_patient = res_get_patient_email.Email;
            }



            //4. get examination information
            BIL0102U00GetExaminationInfoArgs args_examination = new BIL0102U00GetExaminationInfoArgs();
            args_examination.HospCode = UserInfo.HospCode;
            args_examination.Pkout1001 = pkOut1001;
            BIL0102U00GetExaminationInfoResult res_examination = CloudService.Instance.Submit<BIL0102U00GetExaminationInfoResult, BIL0102U00GetExaminationInfoArgs>(args_examination);
            if (res_examination.ExecutionStatus == ExecutionStatus.Success)
            {
                naewon_date = res_examination.NaewonDate;
                jubsu_time = res_examination.JubsuTime;
                bank_name = res_examination.BankInfo.BankName;
                bank_jijum = res_examination.BankInfo.BankJijum;
                bank_acc_type = res_examination.BankInfo.BankAccType;
                bank_no = res_examination.BankInfo.BankNo;
                bank_acc_name = res_examination.BankInfo.BankAccName;

            }

            //3. Get mail template

            BIL0102U00GetMailTemplateArgs args_mailTemplate = new BIL0102U00GetMailTemplateArgs();
            args_mailTemplate.Locale = "";
            args_mailTemplate.TemplateCode = "REQUEST_PAYMEN";
            args_mailTemplate.YoyangName = yoyang_name;
            args_mailTemplate.AddressHosp = address_hosp;
            args_mailTemplate.PatientName = dbxPatientName.GetDataValue();
            args_mailTemplate.TelHosp = tel_hosp;
            args_mailTemplate.EmailHosp = email_hosp;
            args_mailTemplate.MailPatient = email_patient;
            args_mailTemplate.MailTemplateIt = mail_template_id;
            args_mailTemplate.Subject = "";
            args_mailTemplate.Content = "";
            int naewon_date_leagth = naewon_date.Length;
            args_mailTemplate.NaewonDate = DateTime.Parse(naewon_date.Substring(0, 10)).ToString("yyyy/MM/dd");
            args_mailTemplate.JubsuTime = jubsu_time;
            args_mailTemplate.Total = dbxSum.GetDataValue().Replace(".", "").Replace(",", "");
            args_mailTemplate.TotalDiscount = dbxSumDiscount.GetDataValue().Replace(".", "").Replace(",", "");
            args_mailTemplate.TotalPaid = dbxSumPatientPay.GetDataValue().Replace(".", "").Replace(",", "");
            args_mailTemplate.TotalPaying = dbxSumDebt.GetDataValue().Replace(".", "").Replace(",", "");
            args_mailTemplate.BankName = bank_name;
            args_mailTemplate.BankJijum = bank_jijum;
            args_mailTemplate.BankAccType = bank_acc_type;
            args_mailTemplate.BankNo = bank_no;
            args_mailTemplate.BankAccName = bank_acc_name;
            args_mailTemplate.Orderlist = orderlist;
            args_mailTemplate.Bunho = dbxPatientCode.Text;
            if (txtInvoiceNo.Text.Length == 0 || string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                args_mailTemplate.InvoiceNo = InvoiceNo_return;
            }
            else
	        {
                args_mailTemplate.InvoiceNo = txtInvoiceNo.Text;
	        }
            
            args_mailTemplate.UserId = UserInfo.UserID;
            args_mailTemplate.Fkout1001 = fkout1001;
            args_mailTemplate.Discount = txtDiscount.Text.Replace(".", "").Replace(",", "");

            
            BIL0102U00GetMailTemplateResult res_mailTemplate = CloudService.Instance.Submit<BIL0102U00GetMailTemplateResult, BIL0102U00GetMailTemplateArgs>(args_mailTemplate);
            if (res_mailTemplate.ExecutionStatus == ExecutionStatus.Success)
            {
                mail_template_id = res_mailTemplate.MailTemplateId;
                subject = res_mailTemplate.Subject;
                content = res_mailTemplate.Content;
                gmolink = res_mailTemplate.GmoLink;
                InvoiceNo_return = res_mailTemplate.InvoiceNo;
            }
            bool flag = false;
            if (!string.IsNullOrEmpty(gmolink) && gmolink.Length > 0)
            {
                try
                {
                    System.Diagnostics.Process.Start(gmolink);
                    flag = true;
                }
                catch (Exception ex)
                {
                    Service.WriteLog(ex.ToString());
                }
            }

            if (flag == true)
            {
                return;
            }
            //5. Send data to SendMail Form 
            SendBilling formSendBilling = new SendBilling(yoyang_name,
                                                        address_hosp,
                                                        dbxPatientName.GetDataValue(),
                                                        tel_hosp,
                                                        email_hosp,
                                                        locale,
                                                        email_patient,
                                                        mail_template_id,
                                                        subject,
                                                        content,
                                                        naewon_date,
                                                        jubsu_time,
                                                        dbxSum.GetDataValue(),
                                                        dbxSumDiscount.GetDataValue(),
                                                        dbxSumPatientPay.GetDataValue(),
                                                        dbxSumDebt.GetDataValue(),
                                                        bank_name,
                                                        bank_jijum,
                                                        bank_acc_type,
                                                        bank_no,
                                                        bank_acc_name,
                                                        orderlist,
                                                        fkout1001,
                                                        dbxPatientCode.Text,
                                                        txtInvoiceNo.Text,
                                                        UserInfo.UserID,
                                                        txtDiscount.Text);
            formSendBilling.ShowDialog();

        }

        private void cboPaymentType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPaymentType.GetDataValue() == "CASH" || cboPaymentType.GetDataValue() == "BANK_CARD")
            {
                btnSendmail.Enabled = false;
            }
            else if (cboPaymentType.GetDataValue() == "CREDIT_CARD")
            {
                btnSendmail.Enabled = true;
            }
        }

        private void grdBIL2016U02_GridColumnChanged(object sender, GridColumnChangedEventArgs e)
        {
            if (e.ColName.ToString() == "discount")
            {
                CalculatorMoney();
            }
        }

        private void txtPayMoney_DataValidating(object sender, DataValidatingEventArgs e)
        {
            double payMoney = Convert.ToUInt64(txtPayMoney.Text.Replace(".", "").Replace(",", ""));
            double sumPatientPay = Convert.ToUInt64(dbxSumPatientPay.Text.Replace(".", "").Replace(",", ""));
            double sumPay = Convert.ToUInt64(dbxSumPay.Text.Replace(".", "").Replace(",", ""));
            double payMoneyBinding = sumPatientPay - sumPay;
            if (payMoney > payMoneyBinding)
            {
                XMessageBox.Show(Resources.BIL0102U00_CalculatorMoney_Validate, Resources.MSG001_CAP);
                txtPayMoney.Text = FormatNumber(payMoneyBinding.ToString(), true);
                return;
            }
        }

    }
}