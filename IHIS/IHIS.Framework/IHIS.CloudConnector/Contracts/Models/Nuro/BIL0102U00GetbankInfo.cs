using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class BIL0102U00GetbankInfo
    {
        private String _bankName;
        private String _bankJijum;
        private String _bankAccType;
        private String _bankNo;
        private String _bankAccName;

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

        public BIL0102U00GetbankInfo() { }

        public BIL0102U00GetbankInfo(String bankName, String bankJijum, String bankAccType, String bankNo, String bankAccName)
        {
            this._bankName = bankName;
            this._bankJijum = bankJijum;
            this._bankAccType = bankAccType;
            this._bankNo = bankNo;
            this._bankAccName = bankAccName;
        }

    }
}