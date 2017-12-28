using System;
using IHIS.CloudConnector.Contracts.Models.Bill;
using System.Collections.Generic;
using ProtoBuf;

namespace IHIS.CloudConnector.Contracts.Arguments.Bill
{
    public class SaveBIL2016U02Args : IContractArgs
    {
        private List<LoadGridBIL2016U02Info> _listInfo = new List<LoadGridBIL2016U02Info>();
        private String _invoiceNo;
        private String _invoiceDate;
        private String _paymentCode;
        private String _bunho;
        private String _suname;
        private String _address;
        private String _sex;
        private String _birth;
        private String _naewonDate;
        private String _gwa;
        private String _doctor;
        private String _gwaName;
        private String _doctorName;
        private String _bunhoType;
        private String _paidName;
        private String _paymentName;
        private String _fkout1001;
        private String _amount;
        private String _discount;
        private String _revertType;
        private String _revertComment;
        private String _bunhoTypeName;
        private String _phone;
        private String _discountType;
        private String _rowState;
        private String _discountReasonTotal;
        private String _parentInvoiceNo;
        private String _statusFlg;
        private String _type;
        private String _statusFlgParentNoNull;
        private String _revertReason;
        private String _amountDebtLatest;
        private String _payMoney;

        public List<LoadGridBIL2016U02Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

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

        public String PaymentCode
        {
            get { return this._paymentCode; }
            set { this._paymentCode = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String Suname
        {
            get { return this._suname; }
            set { this._suname = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String NaewonDate
        {
            get { return this._naewonDate; }
            set { this._naewonDate = value; }
        }

        public String Gwa
        {
            get { return this._gwa; }
            set { this._gwa = value; }
        }

        public String Doctor
        {
            get { return this._doctor; }
            set { this._doctor = value; }
        }

        public String GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public String DoctorName
        {
            get { return this._doctorName; }
            set { this._doctorName = value; }
        }

        public String BunhoType
        {
            get { return this._bunhoType; }
            set { this._bunhoType = value; }
        }

        public String PaidName
        {
            get { return this._paidName; }
            set { this._paidName = value; }
        }

        public String PaymentName
        {
            get { return this._paymentName; }
            set { this._paymentName = value; }
        }

        public String Fkout1001
        {
            get { return this._fkout1001; }
            set { this._fkout1001 = value; }
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

        public String BunhoTypeName
        {
            get { return this._bunhoTypeName; }
            set { this._bunhoTypeName = value; }
        }

        public String Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public String DiscountType
        {
            get { return this._discountType; }
            set { this._discountType = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public String DiscountReasonTotal
        {
            get { return this._discountReasonTotal; }
            set { this._discountReasonTotal = value; }
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

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String StatusFlgParentNoNull
        {
            get { return this._statusFlgParentNoNull; }
            set { this._statusFlgParentNoNull = value; }
        }

        public String RevertReason
        {
            get { return this._revertReason; }
            set { this._revertReason = value; }
        }

        public String AmountDebtLatest
        {
            get { return this._amountDebtLatest; }
            set { this._amountDebtLatest = value; }
        }

        public String PayMoney
        {
            get { return this._payMoney; }
            set { this._payMoney = value; }
        }

        public SaveBIL2016U02Args() { }

        public SaveBIL2016U02Args(List<LoadGridBIL2016U02Info> listInfo, String invoiceNo, String invoiceDate, String paymentCode, String bunho, String suname, String address, String sex, String birth, String naewonDate, String gwa, String doctor, String gwaName, String doctorName, String bunhoType, String paidName, String paymentName, String fkout1001, String amount, String discount, String revertType, String revertComment, String bunhoTypeName, String phone, String discountType, String rowState, String discountReasonTotal, String parentInvoiceNo, String statusFlg, String type, String statusFlgParentNoNull, String revertReason, String amountDebtLatest, String payMoney)
        {
            this._listInfo = listInfo;
            this._invoiceNo = invoiceNo;
            this._invoiceDate = invoiceDate;
            this._paymentCode = paymentCode;
            this._bunho = bunho;
            this._suname = suname;
            this._address = address;
            this._sex = sex;
            this._birth = birth;
            this._naewonDate = naewonDate;
            this._gwa = gwa;
            this._doctor = doctor;
            this._gwaName = gwaName;
            this._doctorName = doctorName;
            this._bunhoType = bunhoType;
            this._paidName = paidName;
            this._paymentName = paymentName;
            this._fkout1001 = fkout1001;
            this._amount = amount;
            this._discount = discount;
            this._revertType = revertType;
            this._revertComment = revertComment;
            this._bunhoTypeName = bunhoTypeName;
            this._phone = phone;
            this._discountType = discountType;
            this._rowState = rowState;
            this._discountReasonTotal = discountReasonTotal;
            this._parentInvoiceNo = parentInvoiceNo;
            this._statusFlg = statusFlg;
            this._type = type;
            this._statusFlgParentNoNull = statusFlgParentNoNull;
            this._revertReason = revertReason;
            this._amountDebtLatest = amountDebtLatest;
            this._payMoney = payMoney;
        }

        public IExtensible GetRequestInstance()
        {
            return new IHIS.CloudConnector.Messaging.SaveBIL2016U02Request();
        }
    }
}