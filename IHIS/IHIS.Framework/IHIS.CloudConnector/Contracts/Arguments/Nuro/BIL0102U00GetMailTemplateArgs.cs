using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Nuro
{
    public class BIL0102U00GetMailTemplateArgs : IContractArgs
    {
        private String _locale;
        private String _templateCode;
        private String _yoyangName;
        private String _addressHosp;
        private String _patientName;
        private String _telHosp;
        private String _emailHosp;
        private String _mailPatient;
        private String _mailTemplateIt;
        private String _subject;
        private String _content;
        private String _naewonDate;
        private String _jubsuTime;
        private String _total;
        private String _totalDiscount;
        private String _totalPaid;
        private String _totalPaying;
        private String _bankName;
        private String _bankJijum;
        private String _bankAccType;
        private String _bankNo;
        private String _bankAccName;
        private List<BIL0102OrderListInfo> _orderlist = new List<BIL0102OrderListInfo>();
        private String _bunho;
        private String _invoiceNo;
        private String _userId;
        private String _fkout1001;
        private String _discount;

        public String Locale
        {
            get { return this._locale; }
            set { this._locale = value; }
        }

        public String TemplateCode
        {
            get { return this._templateCode; }
            set { this._templateCode = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String AddressHosp
        {
            get { return this._addressHosp; }
            set { this._addressHosp = value; }
        }

        public String PatientName
        {
            get { return this._patientName; }
            set { this._patientName = value; }
        }

        public String TelHosp
        {
            get { return this._telHosp; }
            set { this._telHosp = value; }
        }

        public String EmailHosp
        {
            get { return this._emailHosp; }
            set { this._emailHosp = value; }
        }

        public String MailPatient
        {
            get { return this._mailPatient; }
            set { this._mailPatient = value; }
        }

        public String MailTemplateIt
        {
            get { return this._mailTemplateIt; }
            set { this._mailTemplateIt = value; }
        }

        public String Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }

        public String Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String JubsuTime
        {
            get { return this._jubsuTime; }
            set { this._jubsuTime = value; }
        }

        public String Total
        {
            get { return this._total; }
            set { this._total = value; }
        }

        public String TotalDiscount
        {
            get { return this._totalDiscount; }
            set { this._totalDiscount = value; }
        }

        public String TotalPaid
        {
            get { return this._totalPaid; }
            set { this._totalPaid = value; }
        }

        public String TotalPaying
        {
            get { return this._totalPaying; }
            set { this._totalPaying = value; }
        }

        public String BankName
        {
            get { return this._bankName; }
            set { this._bankName = value; }
        }

        public String BankJijum
        {
            get { return this._bankJijum; }
            set { this._bankJijum = value; }
        }

        public String BankAccType
        {
            get { return this._bankAccType; }
            set { this._bankAccType = value; }
        }

        public String BankNo
        {
            get { return this._bankNo; }
            set { this._bankNo = value; }
        }

        public String BankAccName
        {
            get { return this._bankAccName; }
            set { this._bankAccName = value; }
        }

        public List<BIL0102OrderListInfo> Orderlist
        {
            get { return this._orderlist; }
            set { this._orderlist = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public String UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
        }

        public String Discount
        {
            get { return this._discount; }
            set { this._discount = value; }
        }

        public BIL0102U00GetMailTemplateArgs() { }

        public BIL0102U00GetMailTemplateArgs(String locale, String templateCode, String yoyangName, String addressHosp, String patientName, String telHosp, String emailHosp, String mailPatient, String mailTemplateIt, String subject, String content, String naewonDate, String jubsuTime, String total, String totalDiscount, String totalPaid, String totalPaying, String bankName, String bankJijum, String bankAccType, String bankNo, String bankAccName, List<BIL0102OrderListInfo> orderlist, String bunho, String invoiceNo, String userId, String fkout1001, String discount)
        {
            this._locale = locale;
            this._templateCode = templateCode;
            this._yoyangName = yoyangName;
            this._addressHosp = addressHosp;
            this._patientName = patientName;
            this._telHosp = telHosp;
            this._emailHosp = emailHosp;
            this._mailPatient = mailPatient;
            this._mailTemplateIt = mailTemplateIt;
            this._subject = subject;
            this._content = content;
            this._naewonDate = naewonDate;
            this._jubsuTime = jubsuTime;
            this._total = total;
            this._totalDiscount = totalDiscount;
            this._totalPaid = totalPaid;
            this._totalPaying = totalPaying;
            this._bankName = bankName;
            this._bankJijum = bankJijum;
            this._bankAccType = bankAccType;
            this._bankNo = bankNo;
            this._bankAccName = bankAccName;
            this._orderlist = orderlist;
            this._bunho = bunho;
            this._invoiceNo = invoiceNo;
            this._userId = userId;
            this._fkout1001 = fkout1001;
            this._discount = discount;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.BIL0102U00GetMailTemplateRequest();
        }
    }
}