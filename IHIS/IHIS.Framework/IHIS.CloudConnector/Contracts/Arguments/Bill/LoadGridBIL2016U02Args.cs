using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class LoadGridBIL2016U02Args : IContractArgs
    {
        private String _invoiceNo;
        private String _invoiceDate;
        private String _patientCode;
        private String _pkout1001;
        private String _bunhoType;
        private String _payYn;
        private String _type;
        private String _bunho;
        private String _patientNm;
        private String _parentInvoiceNo;
        private String _statusFlg;
        private String _amountDebt;
        private String _amountPaid;
        private String _amount;
        private String _discount;

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public String InvoiceDate
        {
            get { return this._invoiceDate; }
            set { this._invoiceDate = value; }
        }

        public String PatientCode
        {
            get { return this._patientCode; }
            set { this._patientCode = value; }
        }

        public String Pkout1001
        {
            get { return this._pkout1001; }
            set { this._pkout1001 = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String PayYn
        {
            get { return this._payYn; }
            set { this._payYn = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String PatientNm
        {
            get { return this._patientNm; }
            set { this._patientNm = value; }
        }

        public String ParentInvoiceNo
        {
            get { return this._parentInvoiceNo; }
            set { this._parentInvoiceNo = value; }
        }

        public String StatusFlg
        {
            get { return this._statusFlg; }
            set { this._statusFlg = value; }
        }

        public String AmountDebt
        {
            get { return this._amountDebt; }
            set { this._amountDebt = value; }
        }

        public String AmountPaid
        {
            get { return this._amountPaid; }
            set { this._amountPaid = value; }
        }

        public String Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public String Discount
        {
            get { return this._discount; }
            set { this._discount = value; }
        }

        public LoadGridBIL2016U02Args() { }

        public LoadGridBIL2016U02Args(String invoiceNo, String invoiceDate, String patientCode, String pkout1001, String bunhoType, String payYn, String type, String bunho, String patientNm, String parentInvoiceNo, String statusFlg, String amountDebt, String amountPaid, String amount, String discount)
        {
            this._invoiceNo = invoiceNo;
            this._invoiceDate = invoiceDate;
            this._patientCode = patientCode;
            this._pkout1001 = pkout1001;
            this._bunhoType = bunhoType;
            this._payYn = payYn;
            this._type = type;
            this._bunho = bunho;
            this._patientNm = patientNm;
            this._parentInvoiceNo = parentInvoiceNo;
            this._statusFlg = statusFlg;
            this._amountDebt = amountDebt;
            this._amountPaid = amountPaid;
            this._amount = amount;
            this._discount = discount;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.LoadGridBIL2016U02Request();
        }
    }
}