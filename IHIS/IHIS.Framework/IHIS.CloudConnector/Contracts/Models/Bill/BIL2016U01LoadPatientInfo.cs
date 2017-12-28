using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class BIL2016U01LoadPatientInfo
    {
        private String _billDate;
        private String _billNumber;
        private String _bunho;
        private String _suname;
        private String _birth;
        private String _sex;
        private String _address;
        private String _phone;
        private String _commingDate;
        private String _type;
        private String _typeName;
        private String _fkout;
        private String _paidName;
        private String _typeMoney;
        private String _sumAmount;
        private String _sumDiscount;
        private String _sumPaid;
        private String _sumDebt;
        private String _parentInvoiceno;
        private String _statusFlg;
        private String _refId;
        private String _statusId;
        private String _pkbil0103;
        private String _statusText;
        private String _sysId;

        public String BillDate
        {
            get { return this._billDate; }
            set { this._billDate = value; }
        }

        public String BillNumber
        {
            get { return this._billNumber; }
            set { this._billNumber = value; }
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

        public String Birth
        {
            get { return this._birth; }
            set { this._birth = value; }
        }

        public String Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        public String Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public String Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public String CommingDate
        {
            get { return this._commingDate; }
            set { this._commingDate = value; }
        }

        public String Type
        {
            get { return this._type; }
            set { this._type = value; }
        }

        public String TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        public String Fkout
        {
            get { return this._fkout; }
            set { this._fkout = value; }
        }

        public String PaidName
        {
            get { return this._paidName; }
            set { this._paidName = value; }
        }

        public String TypeMoney
        {
            get { return this._typeMoney; }
            set { this._typeMoney = value; }
        }

        public String SumAmount
        {
            get { return this._sumAmount; }
            set { this._sumAmount = value; }
        }

        public String SumDiscount
        {
            get { return this._sumDiscount; }
            set { this._sumDiscount = value; }
        }

        public String SumPaid
        {
            get { return this._sumPaid; }
            set { this._sumPaid = value; }
        }

        public String SumDebt
        {
            get { return this._sumDebt; }
            set { this._sumDebt = value; }
        }

        public String ParentInvoiceno
        {
            get { return this._parentInvoiceno; }
            set { this._parentInvoiceno = value; }
        }

        public String StatusFlg
        {
            get { return this._statusFlg; }
            set { this._statusFlg = value; }
        }

        public String RefId
        {
            get { return this._refId; }
            set { this._refId = value; }
        }

        public String StatusId
        {
            get { return this._statusId; }
            set { this._statusId = value; }
        }

        public String Pkbil0103
        {
            get { return this._pkbil0103; }
            set { this._pkbil0103 = value; }
        }

        public String StatusText
        {
            get { return this._statusText; }
            set { this._statusText = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public BIL2016U01LoadPatientInfo() { }

        public BIL2016U01LoadPatientInfo(String billDate, String billNumber, String bunho, String suname, String birth, String sex, String address, String phone, String commingDate, String type, String typeName, String fkout, String paidName, String typeMoney, String sumAmount, String sumDiscount, String sumPaid, String sumDebt, String parentInvoiceno, String statusFlg, String refId, String statusId, String pkbil0103, String statusText, String sysId)
        {
            this._billDate = billDate;
            this._billNumber = billNumber;
            this._bunho = bunho;
            this._suname = suname;
            this._birth = birth;
            this._sex = sex;
            this._address = address;
            this._phone = phone;
            this._commingDate = commingDate;
            this._type = type;
            this._typeName = typeName;
            this._fkout = fkout;
            this._paidName = paidName;
            this._typeMoney = typeMoney;
            this._sumAmount = sumAmount;
            this._sumDiscount = sumDiscount;
            this._sumPaid = sumPaid;
            this._sumDebt = sumDebt;
            this._parentInvoiceno = parentInvoiceno;
            this._statusFlg = statusFlg;
            this._refId = refId;
            this._statusId = statusId;
            this._pkbil0103 = pkbil0103;
            this._statusText = statusText;
            this._sysId = sysId;
        }

    }
}