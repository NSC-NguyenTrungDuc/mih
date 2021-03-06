using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using IHIS.Framework;
using IHIS.CloudConnector.Contracts.Results.Bill;
using IHIS.CloudConnector.Caching;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Models.System;
using IHIS.CloudConnector;
using System.Reflection;
using System.Data.SqlTypes;
using System.IO;
using IHIS.CloudConnector.Contracts.Models.Bill;
using IHIS.CloudConnector.Contracts.Results.Nuro;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Arguments.Bill;
using IHIS.CloudConnector.Contracts.Results;
using Report2005;
using System.Globalization;
using System.Threading;

namespace IHIS.NURO
{
    public partial class BIL0101U00 : IHIS.Framework.XScreen
    {
        private int i = 0;
        private LoadGridBIL2016U02Result result;
        public BIL0101U00()
        {
            InitializeComponent();

            layDoctorName.ExecuteQuery = GetDoctorNameList;
            grdPatientList.ExecuteQuery = GetPatientList;

            btnPrint.Enabled = false;

            cbxAutoQuery.Checked = false;
            timer1.Enabled = false;

            xEditGridCell25.ButtonText = Resources.BIL0101U00_BIL0101U00_View;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (grdPatientList.RowCount > 0)
            {
                CommonItemCollection paramObj = new CommonItemCollection();
                paramObj.Add("f_invoice_no", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString());
                paramObj.Add("f_invoice_date", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString());
                paramObj.Add("f_pkout1001", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "fkout").ToString());
                paramObj.Add("f_hosp_code", UserInfo.HospCode);
                paramObj.Add("f_bunho", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString());
                paramObj.Add("f_suname", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString());
                paramObj.Add("f_address1", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "address").ToString());
                paramObj.Add("f_sex", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "sex_code").ToString());
                paramObj.Add("f_birth", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "birth").ToString());
                paramObj.Add("f_naewon_date", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "comming_date").ToString());
                paramObj.Add("f_phone", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "phone").ToString());
                //paramObj.Add("f_gwa", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "gwa").ToString());
                //paramObj.Add("f_doctor", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "doctor").ToString());
                //paramObj.Add("f_gwa_name", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "gwa_name").ToString());
                //paramObj.Add("f_doctor_name", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "doctor_name").ToString());
                paramObj.Add("f_bunho_type", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type").ToString());
                paramObj.Add("f_bunho_name", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type_name").ToString());
                paramObj.Add("f_type", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type_money").ToString());
                paramObj.Add("f_pay_yn", rbtPaid.Checked ? "Y" : rbtUnPaid.Checked ? "N" : rbtCancel.Checked ? "C" : "D");
                paramObj.Add("f_parent_invoice_no", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "parent_invoice").ToString());
                paramObj.Add("f_status_flg", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "status_flg").ToString());
                paramObj.Add("f_amount_debt", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "sum_debt").ToString());
                paramObj.Add("f_amount_paid", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "sum_paided").ToString());
                paramObj.Add("f_amount", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "sum_amount").ToString());
                paramObj.Add("f_discount", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "sum_discount").ToString());
                XScreen.OpenScreenWithParam(this, "NURO", "BIL0102U00", ScreenOpenStyle.ResponseFixed, paramObj);
                QueryData();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (grdPatientList.RowCount > 0 && rbtPaid.Checked)
            {
                #region Comment by CloudServices
            //    LoadGridBIL2016U02Args args = new LoadGridBIL2016U02Args();
            //    //===========================================================
            //    args.InvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
            //    args.InvoiceDate = "";
            //    args.PatientCode = "";
            //    args.PayYn = "Y";
            //    args.Pkout1001 = "";
            //    args.BunhoType = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type").ToString();
            //    args.Type = "";
            //    args.Bunho = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString();
            //    args.PatientNm = "";
            //    args.ParentInvoiceNo = "";
            //    args.StatusFlg = "";
            //    args.AmountDebt = "";
            //    args.AmountPaid = "";
            //    args.Amount = "";
            //    args.Discount = "";
            //    //==============================================================================
            //    result = CloudService.Instance.Submit<LoadGridBIL2016U02Result, LoadGridBIL2016U02Args>(args);
            //    DataSet1 ds = new DataSet1();
            //    int i = 1;
            //    double totalAmount = 0;
            //    PrintDataComboInvoiceArgs printArgs = new PrintDataComboInvoiceArgs();
            //    printArgs.InvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
            //    printArgs.ParentInvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
            //    PrintDataComboInvoiceResult invoiceResult = CloudService.Instance.Submit<PrintDataComboInvoiceResult, PrintDataComboInvoiceArgs>(printArgs);
            //    if (invoiceResult != null && invoiceResult.ExecutionStatus == ExecutionStatus.Success)
            //    {
            //        foreach (LoadGridBIL2016U02Info info in invoiceResult.InvoiceDetail)
            //        {
            //            DataRow row = ds.DataBil.NewRow();
            //            row["number"] = i++;
            //            row["hangmog_code"] = info.HangmogCode;
            //            row["hangmog_name"] = info.HangmogName;
            //            row["unit"] = info.Unit;
            //            row["quantity"] = info.Quantity;
            //            row["price"] = TryPareFormatNum(info.Price);
            //            row["amount"] = TryPareFormatNum(info.Amount);
            //            row["insurance_pay"] = TryPareFormatNum(info.InsurancePay);
            //            double price = 0;
            //            double discount = 0;
            //            double patientPay = 0;
            //            bool Price = Double.TryParse(info.Price.ToString(), out price);
            //            bool Discount = Double.TryParse(info.Discount.ToString(), out discount);
            //            patientPay = price - discount;
            //            row["patient_pay"] = TryPareFormatNum(patientPay.ToString());
            //            row["discount"] = TryPareFormatNum(info.Discount);
            //            row["dept_req_nm"] = info.DeptReqNm;
            //            row["doctor_req_nm"] = info.DoctorReqNm;
            //            row["dept_exc_nm"] = info.DeptExcNm;
            //            row["doctor_exc_nm"] = info.DoctorExcNm;
            //            row["order_group_nm"] = info.OrderGroupNm;
            //            if (!string.IsNullOrEmpty(info.Amount))
            //            {
            //                if (info.Amount.Contains("."))
            //                    totalAmount += Convert.ToDouble(info.Amount.Substring(0, info.Amount.IndexOf('.')));
            //                else
            //                    totalAmount += Convert.ToDouble(info.Amount);
            //            }
            //            else
            //            {
            //                totalAmount = 0;
            //            }


            //            ds.DataBil.Rows.Add(row);
            //        }
            //    }
            //    //Data for patient and name hospital 
            //    DataRow rowHospital = ds.DataHospital.NewRow();
            //    rowHospital["invoice_no"] = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
            //    rowHospital["hospital_name"] = result != null ? result.YoyangName : "";
            //    rowHospital["adress"] = result != null ? result.Adress : "";
            //    rowHospital["tel"] = result != null ? result.Tel : "";
            //    rowHospital["email"] = result != null ? result.Email : "";
            //    rowHospital["website"] = result != null ? result.Website : "";
            //    rowHospital["invoice_date"] = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString();
            //    rowHospital["patient"] = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString();
            //    rowHospital["paid_name"] = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString();
            //    rowHospital["patient_code"] = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString();
            //    rowHospital["sum_amount_invoice"] = TryPareFormatNum(invoiceResult.SumAmountInvoice);
            //    rowHospital["paid_invoice"] = TryPareFormatNum(invoiceResult.PaidInvoice);
            //    rowHospital["total_paid"] = TryPareFormatNum(invoiceResult.TotalPaid);
            //    rowHospital["total_debt"] = TryPareFormatNum(invoiceResult.TotalDebt);
            //    //rowHospital["total_write"] = ReplaceSpecialWord(JoinUnit(((Int64)totalPatient).ToString())).Trim();
            //    rowHospital["total_write"] = "";
            //    string birth = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "birth").ToString();
            //    if (!string.IsNullOrEmpty(birth))
            //    {
            //        DateTime bday = DateTime.ParseExact(birth, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            //        DateTime now = DateTime.Today;
            //        int age = now.Year - bday.Year;
            //        if (bday > now.AddYears(-age)) age--;
            //        rowHospital["age"] = age;
            //    }
            //    else
            //    {
            //        rowHospital["age"] = "";
            //    }

            //    ds.DataHospital.Rows.Add(rowHospital);
            //    //Set print                
            //    if (NetInfo.Language == LangMode.Vi)
            //    {
            //        ReportBIL2016U02 xReport = new ReportBIL2016U02();
            //        xReport.DataSource = ds;
            //        xReport.Print();
            //    }
            //    else
            //    {
            //        ReportBIL2016U02JP xReport = new ReportBIL2016U02JP();
            //        xReport.DataSource = ds;
            //        xReport.Print();
            //    }
                #endregion
                DataHospital dataHospital = new DataHospital();
                LoadGridBIL2016U02Args args = new LoadGridBIL2016U02Args();
                //===========================================================
                args.InvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
                args.InvoiceDate = "";
                args.PatientCode = "";
                args.PayYn = "Y";
                args.Pkout1001 = "";
                args.BunhoType = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type").ToString();
                args.Type = "";
                args.Bunho = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString();
                args.PatientNm = "";
                args.ParentInvoiceNo = "";
                args.StatusFlg = "";
                args.AmountDebt = "";
                args.AmountPaid = "";
                args.Amount = "";
                args.Discount = "";
                //==============================================================================
                result = CloudService.Instance.Submit<LoadGridBIL2016U02Result, LoadGridBIL2016U02Args>(args);               
                int i = 1;
                double totalAmount = 0;
                BIL0102U00DataReportArgs printArgs = new BIL0102U00DataReportArgs();
                printArgs.InvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
                printArgs.ParentInvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
                BIL0102U00DataReportResult invoiceResult = CloudService.Instance.Submit<BIL0102U00DataReportResult, BIL0102U00DataReportArgs>(printArgs);
                if (invoiceResult != null && invoiceResult.ExecutionStatus == ExecutionStatus.Success)
                {
                    dataHospital.BillingData = invoiceResult.InvoiceDetail;
                }
                //Data for patient and name hospital 
                
                dataHospital.Invoice_no = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
                dataHospital.Hospital_name = result != null ? result.YoyangName : "";
                dataHospital.Adress = result != null ? result.Adress : "";
                dataHospital.Adress1 = result != null ? result.Adress1 : "";  
                dataHospital.Tel = result != null ? result.Tel : "";
                dataHospital.Email = result != null ? result.Email : "";
                dataHospital.Website = result != null ? result.Website : "";
                dataHospital.Invoice_date = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString();
                dataHospital.Patient = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString();
                dataHospital.Paid_name = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString();
                dataHospital.Patient_code = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString();
                dataHospital.Sum_amount_invoice = TryPareFormatNum(invoiceResult.SumAmountInvoice);
                dataHospital.Paid_invoice = TryPareFormatNum(invoiceResult.PaidInvoice);
                dataHospital.Total_paid = TryPareFormatNum(invoiceResult.TotalPaid);
                dataHospital.Total_debt = TryPareFormatNum(invoiceResult.TotalDebt);
                dataHospital.Total_write = "";
                dataHospital.Discount_sum = "0";
                dataHospital.User_session = UserInfo.UserName;
                dataHospital.Patient_address = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "address").ToString();
                DateTime InvoiceDay = DateTime.Now;
                if (DateTime.TryParse(grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString(),out InvoiceDay))
                {
                    dataHospital.Invoice_day = DateTime.Parse(grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString()).ToString("dd");
                    dataHospital.Invoice_month = DateTime.Parse(grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString()).ToString("MM");
                    dataHospital.Invoice_year = DateTime.Parse(grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_date").ToString()).ToString("yyyy");
                }
                else
                {
                    dataHospital.Invoice_day = InvoiceDay.ToString("dd");
                    dataHospital.Invoice_month = InvoiceDay.ToString("MM");
                    dataHospital.Invoice_year = InvoiceDay.ToString("yyyy");
                }
                string birth = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "birth").ToString();
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
            } 
                
        }
        private string TryPareFormatNum(string value)
        {
            string strValue = "";
            double dValue = 0;
            bool checkValueNum = Double.TryParse(value, out dValue);
            strValue = FormatNumber(dValue.ToString(), true);
            return strValue;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (grdPatientList.RowCount > 0 && rbtPaid.Checked)
            {
                List<ExportExcelInfo> lstExport = new List<ExportExcelInfo>();

                LoadGridBIL2016U02Args args = new LoadGridBIL2016U02Args();
                args.InvoiceNo = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString();
                args.InvoiceDate = "";
                args.PatientCode = "";
                args.PayYn = "Y";
                args.Pkout1001 = "";
                args.BunhoType = grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "type").ToString();
                LoadGridBIL2016U02Result result = CloudService.Instance.Submit<LoadGridBIL2016U02Result, LoadGridBIL2016U02Args>(args);
                if (result.ExecutionStatus == ExecutionStatus.Success)
                {
                    foreach (LoadGridBIL2016U02Info info in result.InvoiceDetail)
                    {
                        ExportExcelInfo item = new ExportExcelInfo();
                        item.HangmogCode = info.HangmogCode;
                        item.HangmogName = info.HangmogName;
                        item.Unit = info.Unit;
                        item.Price = info.Price;
                        item.Quantity = info.Quantity;
                        item.Amount = info.Amount;
                        item.Amount1 = info.Amount;
                        item.InsurancePay = info.InsurancePay;
                        item.PatientPay = info.PatientPay;
                        item.Discount = info.Discount;
                        item.DeptReqNm = info.DeptReqNm;
                        item.DoctorReqNm = info.DoctorReqNm;
                        item.DeptExcNm = info.DeptExcNm;
                        item.DoctorExcNm = info.DoctorExcNm;
                        item.OrderGroupNm = info.OrderGroupNm;

                        lstExport.Add(item);
                    }
                }


                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "csv File|*.csv";
                saveFileDialog1.Title = Resources.TEXT3;
                saveFileDialog1.ShowDialog();

                if (saveFileDialog1.FileName != "")
                {
                    List<string> headers = new List<string>();
                    headers.Add(Resources.Header1);
                    headers.Add(Resources.Header2);
                    headers.Add(Resources.Header3);
                    headers.Add(Resources.Header4);
                    headers.Add(Resources.Header5);
                    headers.Add(Resources.Header6);
                    headers.Add(Resources.Header7);
                    headers.Add(Resources.Header8);
                    headers.Add(Resources.Header9);
                    headers.Add(Resources.Header10);
                    headers.Add(Resources.Header11);
                    headers.Add(Resources.Header12);
                    headers.Add(Resources.Header13);
                    headers.Add(Resources.Header14);
                    headers.Add(Resources.Header15);

                    CsvExport<ExportExcelInfo> csv = new CsvExport<ExportExcelInfo>(lstExport, headers);
                    csv.ExportToFile(saveFileDialog1.FileName);
                }
            }
        }

        private void btnList_ButtonClick(object sender, IHIS.Framework.ButtonClickEventArgs e)
        {
            switch (e.Func)
            {
                case FunctionType.Query:
                    if (!this.AcceptData())
                    {
                        e.IsBaseCall = false;
                        e.IsSuccess = false;
                        return;
                    }

                    e.IsBaseCall = false;
                    QueryData();
                    break;

                case FunctionType.Reset:
                    e.IsBaseCall = false;

                    this.dtpFromDate.SetDataValue(EnvironInfo.GetSysDate());
                    this.dtpToDate.SetDataValue(EnvironInfo.GetSysDate());

                    this.paBox.Reset();

                    this.cbxAutoQuery.Checked = true;
                    this.cboTime.SelectedIndex = 0;

                    // Fix bug MED-11148
                    this.txtBillNumber.Text = string.Empty;

                    break;

                default:
                    break;
            }
        }

        private void dtpNaewonDate_DataValidating(object sender, IHIS.Framework.DataValidatingEventArgs e)
        {
            if (DateTime.Parse(dtpFromDate.GetDataValue()) > DateTime.Parse(dtpToDate.GetDataValue()))
            {
                dtpToDate.SetDataValue(DateTime.Parse(dtpFromDate.GetDataValue()));
                dtpToDate.AcceptData();
            }
            QueryData();

        }

        private List<string> CreateDoctorNameParamList()
        {
            List<string> lstParam = new List<string>();
            lstParam.Add("f_doctor");
            lstParam.Add("f_date");
            return lstParam;
        }

        private void cboTime_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.cboTime.GetDataValue() != "")
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.cbxAutoQuery.Checked)
            {
                QueryData();
            }
        }

        private void paBox_PatientSelected(object sender, System.EventArgs e)
        {
            QueryData();
        }

        private void paBox_Validating(object sender, CancelEventArgs e)
        {
            if (paBox.BunHo == "")
                QueryData();
        }

        private void cbxAutoQuery_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutoQuery.Checked)
            {
                this.cboTime.Enabled = true;
                this.timer1.Enabled = true;
                this.timer1.Interval = Int32.Parse(this.cboTime.GetDataValue());
            }
            else
            {
                this.timer1.Enabled = false;
                this.cboTime.Enabled = false;
            }
        }

        private void BIL2016U02_ScreenOpen(object sender, XScreenOpenEventArgs e)
        {
            InitializeComboListItem();
            this.cboTime.SelectedIndex = 0;
            this.dtpFromDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpToDate.SetEditValue(EnvironInfo.GetSysDate().ToString("yyyy/MM/dd"));
            this.dtpFromDate.AcceptData();
            this.dtpToDate.AcceptData();
            QueryData();
        }

        private InitializeComboListItemResult InitializeComboListItem()
        {
            InitializeComboListItemResult result = new InitializeComboListItemResult();
            InitializeComboListItemArgs args = new InitializeComboListItemArgs();
            args.CodeType = "JUBSU_GUBUN";
            args.ComboTimeType = "NUR2001U04_TIMER";

            result = CacheService.Instance.Get<InitializeComboListItemArgs, InitializeComboListItemResult>(args);

            if (result != null)
            {
                cboTime.SetDictDDLB(CreateListDataForCombo(result.ComboTimeItem));
            }
            return result;
        }

        private IList<object[]> CreateListDataForCombo(IList<ComboListItemInfo> lstComboDept)
        {
            IList<object[]> lstData = new List<object[]>();
            if (lstComboDept != null && lstComboDept.Count > 0)
            {
                foreach (ComboListItemInfo comboListItemInfo in lstComboDept)
                {
                    object[] obj = { comboListItemInfo.Code, comboListItemInfo.CodeName };
                    lstData.Add(obj);
                }
            }
            return lstData;
        }

        private IList<object[]> GetDoctorNameList(BindVarCollection list)
        {
            List<object[]> doctorNameList = new List<object[]>();

            NuroNUR2001U04DoctorNameArgs doctorNameArgs = new NuroNUR2001U04DoctorNameArgs();
            doctorNameArgs.DoctorCode = list["f_doctor"].VarValue;
            doctorNameArgs.Date = list["f_date"].VarValue;
            NuroNUR2001U04DoctorNameResult result =
                CloudService.Instance.Submit<NuroNUR2001U04DoctorNameResult, NuroNUR2001U04DoctorNameArgs>(
                    doctorNameArgs);

            IList<DataStringListItemInfo> doctorNameListItems = result.DoctorName;
            foreach (DataStringListItemInfo item in doctorNameListItems)
            {
                doctorNameList.Add(new object[]
                {
                    item.DataValue
                });
            }
            return doctorNameList;
        }

        //Fix bug MED-11878
        private string FormatNumber(string value, bool useSeparator)
        {
            if (string.IsNullOrEmpty(value)) return "0";

            decimal number;
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol; ;

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

        private IList<object[]> GetPatientList(BindVarCollection list)
        {
            List<object[]> lst = new List<object[]>();

            BIL2016U01LoadPatientArgs args = new BIL2016U01LoadPatientArgs();
            args.CommingDate = dtpFromDate.GetDataValue();
            args.Bunho = paBox.BunHo;
            args.BillNumber = txtBillNumber.Text;
            args.Suname = txtSuname.Text;
            args.ToDate = dtpToDate.GetDataValue();
            if (rbtUnPaid.Checked) args.Tab = "01";
            if (rbtPaid.Checked) args.Tab = "02";
            if (rbtCancel.Checked) args.Tab = "03";
            if (rbtUnfinish.Checked) args.Tab = "04";
            BIL2016U01LoadPatientResult result =
                CloudService.Instance.Submit<BIL2016U01LoadPatientResult, BIL2016U01LoadPatientArgs>(args);
            if (result.ExecutionStatus == ExecutionStatus.Success)
            {
                CultureInfo cul = CultureInfo.CurrentCulture;
                totalBill.Text = result.TotalPatient;
                totalRevenue.Text = FormatNumber(result.Revenue, true);
                foreach (BIL2016U01LoadPatientInfo item in result.Lst)
                {
                    double paid = Convert.ToDouble(!String.IsNullOrEmpty(item.SumAmount) ? item.SumAmount : "0")
                        - Convert.ToDouble(!String.IsNullOrEmpty(item.SumDiscount) ? item.SumDiscount : "0")
                        - Convert.ToDouble(!String.IsNullOrEmpty(item.SumPaid) ? item.SumPaid : "0");
                    lst.Add(new object[]
                    {
                        item.BillDate,
                        item.BillNumber,
                        item.Bunho,
                        item.Suname,
                        item.Birth,
                        item.Sex,
                        item.Sex.Equals("F")? Resources.TEXT1: Resources.TEXT2,
                        item.Address,
                        item.Phone,
                        item.CommingDate,
                        item.Type,
                        item.TypeName,                     
                        item.Fkout,
                        item.PaidName,
                        item.SumAmount,
                        item.SumDiscount,
                        args.Tab == "02" ? paid.ToString() : item.SumPaid,                        
                        item.SumDebt,
                        item.TypeMoney,
                        item.ParentInvoiceno,
                        item.StatusFlg,
                        item.RefId,
                        item.StatusId,
                        item.StatusText,
                        "",
                        item.Pkbil0103,
                        item.SysId
                    });
                }
            }
            return lst;
        }

        private void QueryData()
        {
            this.Cursor = Cursors.WaitCursor;

            this.grdPatientList.QueryLayout(true);

            this.Cursor = Cursors.Default;

        }

        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            XRadioButton rbt = sender as XRadioButton;


            if (rbt.Checked)
            {
                rbt.BackColor = new XColor(Color.LightPink);

                QueryData();

            }
            else
            {
                if (rbt.Tag.ToString() == "Jinryo")
                {
                    rbt.BackColor = new XColor(Color.PowderBlue);
                }
            }
            btnPrint.Enabled = rbtPaid.Checked;

        }

        private void grdPatientList_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                int row = grdPatientList.GetHitRowNumber(e.Y);
                
                if (row >= 0)
                    btnDetail.PerformClick();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F8:
                    btnDetail.PerformClick();
                    return true;

                case Keys.F9:
                    btnPrint.PerformClick();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        #region Convert money
        private string JoinUnit(string n)
        {
            int sokytu = n.Length;
            int sodonvi = (sokytu % 3 > 0) ? (sokytu / 3 + 1) : (sokytu / 3);
            n = n.PadLeft(sodonvi * 3, '0');
            sokytu = n.Length;
            string chuoi = "";
            int i = 1;
            while (i <= sodonvi)
            {
                if (i == sodonvi) chuoi = JoinNumber((int.Parse(n.Substring(sokytu - (i * 3), 3))).ToString()) + Unit(i) + chuoi;
                else chuoi = JoinNumber(n.Substring(sokytu - (i * 3), 3)) + Unit(i) + chuoi;
                i += 1;
            }
            return chuoi;
        }


        private string Unit(int n)
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


        private string ConvertNumber(string n)
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


        private string JoinNumber(string n)
        {
            string chuoi = "";
            int i = 1, j = n.Length;
            while (i <= j)
            {
                if (i == 1) chuoi = ConvertNumber(n.Substring(j - i, 1)) + chuoi;
                else if (i == 2) chuoi = ConvertNumber(n.Substring(j - i, 1)) + " mươi " + chuoi;
                else if (i == 3) chuoi = ConvertNumber(n.Substring(j - i, 1)) + " trăm " + chuoi;
                i += 1;
            }
            return chuoi;
        }


        private string ReplaceSpecialWord(string chuoi)
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

        private void txtBillNumber_DataValidating(object sender, DataValidatingEventArgs e)
        {
            QueryData();
        }

        private void txtSuname_DataValidating(object sender, DataValidatingEventArgs e)
        {
            QueryData();
        }

        private void btnDebt_Click(object sender, EventArgs e)
        {

        }

        private void dtpToDate_DataValidating(object sender, DataValidatingEventArgs e)
        {
            if (DateTime.Parse(dtpFromDate.GetDataValue()) > DateTime.Parse(dtpToDate.GetDataValue()))
            {
                dtpFromDate.SetDataValue(DateTime.Parse(dtpToDate.GetDataValue()));
                dtpFromDate.AcceptData();
            }
            QueryData();
        }

        private void grdPatientList_Click(object sender, EventArgs e)
        {
            //int rownumber = grdPatientList.CurrentRowNumber;
            //string columname = grdPatientList.CurrentColName;
            //DataTable dtPatient = grdPatientList.LayoutTable;
            //if (dtPatient != null && dtPatient.Rows.Count > 0 && rownumber >= 0 && !string.IsNullOrEmpty(columname) && columname == "trans_detail")
            //{
            //    if (grdPatientList.RowCount > 0)
            //    {
            //        CommonItemCollection paramObj = new CommonItemCollection();
            //        paramObj.Add("ref_id", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "ref_id").ToString());
            //        paramObj.Add("InvoiceNo", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString());
            //        paramObj.Add("bunho", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString());
            //        paramObj.Add("name", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString());
            //        paramObj.Add("first_status_id", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "status_id").ToString());
            //        XScreen.OpenScreenWithParam(this, "NURO", "BIL0103U00", ScreenOpenStyle.ResponseFixed, paramObj);
            //    }
            //}
        }

        private void grdPatientList_GridButtonClick(object sender, GridButtonClickEventArgs e)
        {
            if (e.ColName == "trans_detail")
            {
                int rownumber = grdPatientList.CurrentRowNumber;
                string columname = grdPatientList.CurrentColName;
                DataTable dtPatient = grdPatientList.LayoutTable;
                if (dtPatient != null && dtPatient.Rows.Count > 0 && rownumber >= 0 && !string.IsNullOrEmpty(columname) && columname == "trans_detail")
                {
                    if (grdPatientList.RowCount > 0)
                    {
                        CommonItemCollection paramObj = new CommonItemCollection();
                        paramObj.Add("ref_id", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "ref_id").ToString());
                        paramObj.Add("InvoiceNo", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bill_number").ToString());
                        paramObj.Add("bunho", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "bunho").ToString());
                        paramObj.Add("name", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "name").ToString());
                        paramObj.Add("first_status_id", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "status_id").ToString());
                        paramObj.Add("Pkbil0103", grdPatientList.GetItemValue(grdPatientList.CurrentRowNumber, "Pkbil0103").ToString());
                        XScreen.OpenScreenWithParam(this, "NURO", "BIL0103U00", ScreenOpenStyle.ResponseFixed, paramObj);
                        QueryData();
                    }
                }

            }
        }

        private void grdPatientList_GridCellPainting(object sender, XGridCellPaintEventArgs e)
        {
            XEditGrid grid = sender as XEditGrid;
            if (grid.GetItemString(e.RowNumber, "status_text").Length == 0 || grid.GetItemString(e.RowNumber, "status_text") == "-")
            {
                this.grdPatientList.ChangeButtonEnable("trans_detail", e.RowNumber, false);
                grid.SetItemValue(e.RowNumber,"status_text","-");
            }
            else
            {
                this.grdPatientList.ChangeButtonEnable("trans_detail", e.RowNumber, true);
            }

            if (grid.GetItemString(e.RowNumber, "sys_id") == "MBSO")
            {
                e.BackColor = Color.BlanchedAlmond;
            }
            else if (grid.GetItemString(e.RowNumber, "sys_id") == "MSS" || grid.GetItemString(e.RowNumber, "sys_id") == "MBS")
            {
                e.BackColor = Color.LightGreen;
            }
        }

    }

    public class CsvExport<T> where T : class
    {
        public List<T> Objects;

        public List<string> Headers;

        public CsvExport(List<T> objects)
        {
            Objects = objects;
        }

        public CsvExport(List<T> objects, List<string> headers)
        {
            Objects = objects;
            Headers = headers;
        }

        public string Export()
        {
            return Export(true);
        }

        public string Export(bool includeHeaderLine)
        {

            StringBuilder sb = new StringBuilder();
            //Get properties using reflection.
            IList<PropertyInfo> propertyInfos = typeof(T).GetProperties();

            if (includeHeaderLine && Headers != null)
            {
                //add header line.
                foreach (string header in Headers)
                {
                    sb.Append(header).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            //add value for each property.
            foreach (T obj in Objects)
            {
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(",");
                }
                sb.Remove(sb.Length - 1, 1).AppendLine();
            }

            return sb.ToString();
        }

        //export to a file.
        public void ExportToFile(string path)
        {
            File.WriteAllText(path, Export());
        }

        //export as binary data.
        public byte[] ExportToBytes()
        {
            return Encoding.UTF8.GetBytes(Export());
        }

        //get the csv value for field.
        private string MakeValueCsvFriendly(object value)
        {
            if (value == null) return "";
            if (value is Nullable && ((INullable)value).IsNull) return "";

            if (value is DateTime)
            {
                if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
                    return ((DateTime)value).ToString("yyyy-MM-dd");
                return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
            }
            string output = value.ToString();

            if (output.Contains(",") || output.Contains("\""))
                output = '"' + output.Replace("\"", "\"\"") + '"';

            return output;

        }
    }

    public class ExportExcelInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _unit;
        private String _price;
        private String _quantity;
        private String _amount;
        private String _amount1;
        private String _insurancePay;
        private String _patientPay;
        private String _discount;
        private String _deptReqNm;
        private String _doctorReqNm;
        private String _deptExcNm;
        private String _doctorExcNm;
        private String _orderGroupNm;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String Unit
        {
            get { return this._unit; }
            set { this._unit = value; }
        }

        public String Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        public String Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        public String Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public String Amount1
        {
            get { return this._amount1; }
            set { this._amount1 = value; }
        }

        public String InsurancePay
        {
            get { return this._insurancePay; }
            set { this._insurancePay = value; }
        }

        public String PatientPay
        {
            get { return this._patientPay; }
            set { this._patientPay = value; }
        }

        public String Discount
        {
            get { return this._discount; }
            set { this._discount = value; }
        }

        public String DeptReqNm
        {
            get { return this._deptReqNm; }
            set { this._deptReqNm = value; }
        }

        public String DoctorReqNm
        {
            get { return this._doctorReqNm; }
            set { this._doctorReqNm = value; }
        }

        public String DeptExcNm
        {
            get { return this._deptExcNm; }
            set { this._deptExcNm = value; }
        }

        public String DoctorExcNm
        {
            get { return this._doctorExcNm; }
            set { this._doctorExcNm = value; }
        }

        public String OrderGroupNm
        {
            get { return this._orderGroupNm; }
            set { this._orderGroupNm = value; }
        }

    }
}
