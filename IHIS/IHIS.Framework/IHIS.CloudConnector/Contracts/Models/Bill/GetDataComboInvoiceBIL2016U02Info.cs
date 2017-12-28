using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class GetDataComboInvoiceBIL2016U02Info
    {
        private String _invoiceNo;
        private String _invoiceDate;

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

        public GetDataComboInvoiceBIL2016U02Info() { }

        public GetDataComboInvoiceBIL2016U02Info(String invoiceNo, String invoiceDate)
        {
            this._invoiceNo = invoiceNo;
            this._invoiceDate = invoiceDate;
        }

    }
}