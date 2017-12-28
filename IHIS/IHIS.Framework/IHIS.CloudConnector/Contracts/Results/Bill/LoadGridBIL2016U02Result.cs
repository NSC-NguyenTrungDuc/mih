using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bill
{
    public class LoadGridBIL2016U02Result : AbstractContractResult
    {
        private List<LoadGridBIL2016U02Info> _invoiceDetail = new List<LoadGridBIL2016U02Info>();
        private String _invoiceNo;
        private String _yoyangName;
        private String _adress;
        private String _tel;
        private String _email;
        private String _website;
        private String _paymentName;
        private String _paymentCode;
        private String _paidName;
        private String _totalDiscount;
        private String _discountType;
        private String _discountReasonTotal;
        private String _revertType;
        private String _revertComment;
        private String _totalAmount;
        private String _totalPatientDiscount;
        private String _totalPatientPay;
        private String _totalAmountPaid;
        private String _totalAmountDebt;
        private String _fax;
        private String _adress1;

        public List<LoadGridBIL2016U02Info> InvoiceDetail
        {
            get { return this._invoiceDetail; }
            set { this._invoiceDetail = value; }
        }

        public String InvoiceNo
        {
            get { return this._invoiceNo; }
            set { this._invoiceNo = value; }
        }

        public String YoyangName
        {
            get { return this._yoyangName; }
            set { this._yoyangName = value; }
        }

        public String Adress
        {
            get { return this._adress; }
            set { this._adress = value; }
        }

        public String Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        public String Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public String Website
        {
            get { return this._website; }
            set { this._website = value; }
        }

        public String PaymentName
        {
            get { return this._paymentName; }
            set { this._paymentName = value; }
        }

        public String PaymentCode
        {
            get { return this._paymentCode; }
            set { this._paymentCode = value; }
        }

        public String PaidName
        {
            get { return this._paidName; }
            set { this._paidName = value; }
        }

        public String TotalDiscount
        {
            get { return this._totalDiscount; }
            set { this._totalDiscount = value; }
        }

        public String DiscountType
        {
            get { return this._discountType; }
            set { this._discountType = value; }
        }

        public String DiscountReasonTotal
        {
            get { return this._discountReasonTotal; }
            set { this._discountReasonTotal = value; }
        }

        public String RevertType
        {
            get { return this._revertType; }
            set { this._revertType = value; }
        }

        public String RevertComment
        {
            get { return this._revertComment; }
            set { this._revertComment = value; }
        }

        public String TotalAmount
        {
            get { return this._totalAmount; }
            set { this._totalAmount = value; }
        }

        public String TotalPatientDiscount
        {
            get { return this._totalPatientDiscount; }
            set { this._totalPatientDiscount = value; }
        }

        public String TotalPatientPay
        {
            get { return this._totalPatientPay; }
            set { this._totalPatientPay = value; }
        }

        public String TotalAmountPaid
        {
            get { return this._totalAmountPaid; }
            set { this._totalAmountPaid = value; }
        }

        public String TotalAmountDebt
        {
            get { return this._totalAmountDebt; }
            set { this._totalAmountDebt = value; }
        }

        public String Fax
        {
            get { return this._fax; }
            set { this._fax = value; }
        }

        public String Adress1
        {
            get { return this._adress1; }
            set { this._adress1 = value; }
        }

        public LoadGridBIL2016U02Result() { }

    }
}