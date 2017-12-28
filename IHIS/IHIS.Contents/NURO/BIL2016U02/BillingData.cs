using System;
using System.Collections.Generic;
using System.Text;
using IHIS.CloudConnector.Contracts.Models.Bill;
using IHIS.CloudConnector.Contracts.Models.Nuro;

namespace IHIS.NURO
{
    public class BillingData
    {

    }
    public class DataHospital
    {
        #region Set Properties
        private List<BIL0102U00DataReportInfo> billingData;        
        private string hospital_name;
        private string total_debt;
        private string total_paid;
        private string paid_invoice;
        private string sum_amount_invoice;
        private string paid_name;
        private string patient_code;
        private string total_write;
        private string age;
        private string patient;
        private string invoice_date;
        private string invoice_no;
        private string website;
        private string email;
        private string tel;
        private string adress;
        private string adress1;
        private string discount_sum;
        private string user_session;
        private string fax;
        private string patient_address;
        private string invoice_day;
        private string invoice_month;
        private string invoice_year;

        public string Adress1
        {
            get
            {
                return adress1;
            }
            set
            {
                adress1 = value;
            }
        }


        public List<LoadGridBIL2016U02Info> OrderItems
        {
            get
            {
                List<LoadGridBIL2016U02Info> r = new List<LoadGridBIL2016U02Info>();
                if (billingData != null)
                {
                    foreach (BIL0102U00DataReportInfo info in billingData)
                    {
                        foreach (LoadGridBIL2016U02Info d in info.InvoiceDetail)
                        {
                            r.Add(d);
                        }
                    }
                }
                return r;
            }
        }

        public string Fax
        {
            get 
            {
                return fax;    
            }
            set 
            {
                fax = value;
            }
        }
        public string Discount_sum
        {
            get
            {
                return discount_sum;
            }
            set
            {
                discount_sum = value;
            }
        }
        public string User_session
        {
            get
            {
                return user_session;
            }
            set
            {
                user_session = value;
            }
        }
        public string Adress
        {
            get
            {
                return adress;
            }
            set
            {
                adress = value;
            }
        }
        public string Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Hospital_name
        {
            get
            {
                return hospital_name;
            }
            set
            {
                hospital_name = value;
            }
        }
        public string Invoice_date
        {
            get
            {
                return invoice_date;
            }
            set
            {
                invoice_date = value;
            }
        }
        public string Invoice_no
        {
            get
            {
                return invoice_no;
            }
            set
            {
                invoice_no = value;
            }
        }
        public string Paid_invoice
        {
            get
            {
                return paid_invoice;
            }
            set
            {
                paid_invoice = value;
            }
        }
        public string Paid_name
        {
            get
            {
                return paid_name;
            }
            set
            {
                paid_name = value;
            }
        }
        public string Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }
        public string Patient_code
        {
            get
            {
                return patient_code;
            }
            set
            {
                patient_code = value;
            }
        }
        public string Sum_amount_invoice
        {
            get
            {
                return sum_amount_invoice;
            }
            set
            {
                sum_amount_invoice = value;
            }
        }
        public string Tel
        {
            get
            {
                return tel;
            }
            set
            {
                tel = value;
            }
        }
        public string Total_debt
        {
            get
            {
                return total_debt;
            }
            set
            {
                total_debt = value;
            }
        }
        public string Total_paid
        {
            get
            {
                return total_paid;
            }
            set
            {
                total_paid = value;
            }
        }
        public string Total_write
        {
            get
            {
                return total_write;
            }
            set
            {
                total_write = value;
            }
        }
        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                website = value;
            }
        }
        public string Patient_address
        {
            get
            {
                return patient_address;
            }
            set
            {
                patient_address = value;
            }
        }
        public string Invoice_day
        {
            get
            {
                return invoice_day;
            }
            set
            {
                invoice_day = value;
            }
        }
        public string Invoice_month
        {
            get
            {
                return invoice_month;
            }
            set
            {
                invoice_month = value;
            }
        }
        public string Invoice_year
        {
            get
            {
                return invoice_year;
            }
            set
            {
                invoice_year = value;
            }
        }
        public List<BIL0102U00DataReportInfo> BillingData
        {
            get
            {
                return billingData;
            }
            set
            {
                billingData = value;
            }
        }
        #endregion
    }

}
