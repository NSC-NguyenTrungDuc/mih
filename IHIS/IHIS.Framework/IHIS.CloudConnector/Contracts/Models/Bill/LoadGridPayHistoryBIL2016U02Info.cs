using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class LoadGridPayHistoryBIL2016U02Info
    {
        private String _invoiceNo;
        private String _invoiceDate;
        private String _amount;
        private String _discount;
        private String _amountPaid;
        private String _parentInvoiceNo;
        private String _activeFlg;
        private String _amountDebt;

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

        public String AmountPaid
        {
            get { return this._amountPaid; }
            set { this._amountPaid = value; }
        }

        public String ParentInvoiceNo
        {
            get { return this._parentInvoiceNo; }
            set { this._parentInvoiceNo = value; }
        }

        public String ActiveFlg
        {
            get { return this._activeFlg; }
            set { this._activeFlg = value; }
        }

        public String AmountDebt
        {
            get { return this._amountDebt; }
            set { this._amountDebt = value; }
        }

        public LoadGridPayHistoryBIL2016U02Info() { }

        public LoadGridPayHistoryBIL2016U02Info(String invoiceNo, String invoiceDate, String amount, String discount, String amountPaid, String parentInvoiceNo, String activeFlg, String amountDebt)
        {
            this._invoiceNo = invoiceNo;
            this._invoiceDate = invoiceDate;
            this._amount = amount;
            this._discount = discount;
            this._amountPaid = amountPaid;
            this._parentInvoiceNo = parentInvoiceNo;
            this._activeFlg = activeFlg;
            this._amountDebt = amountDebt;
        }

    }
}