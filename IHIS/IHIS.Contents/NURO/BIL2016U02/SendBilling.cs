using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Net.Mail;
using IHIS.CloudConnector.Contracts.Arguments.Nuro;
using IHIS.CloudConnector.Contracts.Results.System;
using IHIS.CloudConnector;
using IHIS.NURO.Properties;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using IHIS.Framework;
namespace IHIS.NURO
{
    public partial class SendBilling : Form
    {
        private string yoyang_name1 = "";
        private string address_hosp1 = "";
        private string patient_name1 = "";
        private string tel_hosp1 = "";
        private string email_hosp1 = "";
        private string locale1 = "";
        private string mail_patient1 = "";
        private string mail_template_it1 = "";
        private string subject1 = "";
        private string content1 = "";
        private string naewon_date1 = "";
        private string jubsu_time1 = "";
        private string total1 = "";
        private string total_discount1 = "";
        private string total_paid1 = "";
        private string total_paying1 = "";

        private string bank_name1 = "";
        private string bank_jijum1 = "";
        private string bank_acc_type1 = "";
        private string bank_no1 = "";
        private string bank_acc_name1 = "";
        private string fkout10011 = "";

        private string bunho1 = "";
        private string invoiceNo1 = "";
        private string user_id1 = "";
        private string discount1 = "";


        private List<BIL0102OrderListInfo> orderlist1;

        public SendBilling(string yoyang_name, string address_hosp, string patient_name, string tel_hosp, string email_hosp, string locale, string mail_patient, string mail_template_it, string subject, string content, string naewon_date, string jubsu_time, string total, string total_discount, string total_paid, string total_paying, string bank_name, string bank_jijum, string bank_acc_type, string bank_no, string bank_acc_name, List<BIL0102OrderListInfo> orderlist, string fkout1001,string bunho,string invoiceNo,string user_id,string discount)
        {
            InitializeComponent();

            webBrowser1.DocumentText = content;

            yoyang_name1 = yoyang_name;
            address_hosp1 = address_hosp;
            patient_name1 = patient_name;
            tel_hosp1 = tel_hosp;
            email_hosp1 = email_hosp;
            locale1 = locale;
            mail_patient1 = mail_patient;
            mail_template_it1 = mail_template_it;
            subject1 = subject;
            content1 = content;
            naewon_date1 = naewon_date;
            jubsu_time1 = jubsu_time;
            total1 = total;
            total_discount1 = total_discount;
            total_paid1 = total_paid;
            total_paying1 = total_paying;
            bank_name1 = bank_name;
            bank_jijum1 = bank_jijum;
            bank_acc_type1 = bank_acc_type;
            bank_no1 = bank_no;
            bank_acc_name1 = bank_acc_name;
            orderlist1 = orderlist;
            fkout10011 = fkout1001;

            bunho1 = bunho;
            invoiceNo1 = invoiceNo;
            user_id1 = user_id;
            discount1 = discount;

            //txtEmail.Text = mail_patient + " ";
            //txtHospName1.Text = yoyang_name + " ";
            //txtHospName2.Text = yoyang_name + " ";
            //txtHospName3.Text = yoyang_name + " ";
            //txtHospname4.Text = yoyang_name + " ";
            //txtHospName5.Text = yoyang_name + " ";
            //txtPatientName.Text = patient_name;
            //DateTime exmainationDate = Convert.ToDateTime(naewon_date);
            //txtExaminationDate2.Text = exmainationDate.ToString("dd/MM/yyyy") + " ";
            // txtExaminationDate.Text = exmainationDate.ToString("dd/MM/yyyy") + " ";
            //txtExaminationTime.Text = jubsu_time.Insert(2, ":") + " ";
            //txtTotal.Text = total + " ";
            //txtTotalDiscount.Text = total_discount + " ";
            //txtTotalPaid.Text = total_paid + " ";
            //txtTotalPaying.Text = total_paying +" ";
            //DateTime expectDate_today = DateTime.Parse(naewon_date, System.Globalization.CultureInfo.CurrentCulture);
            //DateTime expectDate_7days = expectDate_today.AddDays(7);
            //txtExpectDate.Text = expectDate_7days.ToString("dd/MM/yyyy") + " ";
            //txtHospAddress.Text = address_hosp + " ";
            //txtHospTel.Text = tel_hosp + " ";
            //txtHospEmail.Text = email_hosp + " ";
           
            
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(mail_patient1))
            {
                MessageBox.Show(Resources.BIL0102_0001, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BIL0102U00SendEmailPatientArgs args = new BIL0102U00SendEmailPatientArgs();
            args.YoyangName = yoyang_name1;
            args.BankAccname = bank_acc_name1;
            args.AddressHosp = address_hosp1;
            args.PatientName = patient_name1;
            args.TelHosp = tel_hosp1;
            args.EmailHosp = email_hosp1;
            args.Locale = locale1;
            args.MailPatient = mail_patient1;
            args.MailTemplateIt = mail_template_it1;
            args.Subject = subject1;
            args.Content = content1;
            args.NaewonDate = naewon_date1;
            args.JubsuTime = jubsu_time1;
            args.Total = total1.Replace(".", "").Replace(",", "");
            args.TotalDiscount = total_discount1.Replace(".", "").Replace(",", "");
            args.TotalPaid = total_paid1.Replace(".", "").Replace(",", "");
            args.TotalPaying = total_paying1.Replace(".", "").Replace(",", "");
            args.BankName = bank_name1;
            args.BankJijum = bank_jijum1;
            args.BankAcctype = bank_acc_type1;
            args.BankNo = bank_no1;
            args.BankName = bank_acc_name1;
            args.Orderlist = orderlist1;
            args.Fkout1001 = fkout10011;

            args.Bunho = bunho1;
            args.InvoiceNo = invoiceNo1;
            args.UserId = user_id1;
            args.Discount = discount1.Replace(".", "").Replace(",", "");


            UpdateResult res = CloudService.Instance.Submit<UpdateResult, BIL0102U00SendEmailPatientArgs>(args);
            if (res.ExecutionStatus == IHIS.CloudConnector.Contracts.Results.ExecutionStatus.Success && res.Msg == "BIL0102_0002")
            {
                DialogResult result = XMessageBox.Show(Resources.BIL0102_0002, Resources.MSG001_CAP, MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (result == DialogResult.Yes) this.Close();   
            }
            else
            {
                XMessageBox.Show(Resources.BIL0102_0003, Resources.MSG001_CAP, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}