using System;

namespace IHIS.CloudConnector.Contracts.Models.Bill
{
    public class BIL2016U00ServiceInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _codeName;
        private String _price1;
        private String _price2;
        private String _price3;

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String Price1
        {
            get { return this._price1; }
            set { this._price1 = value; }
        }

        public String Price2
        {
            get { return this._price2; }
            set { this._price2 = value; }
        }

        public String Price3
        {
            get { return this._price3; }
            set { this._price3 = value; }
        }

        public BIL2016U00ServiceInfo() { }

        public BIL2016U00ServiceInfo(String hangmogCode, String hangmogName, String codeName, String price1, String price2, String price3)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._codeName = codeName;
            this._price1 = price1;
            this._price2 = price2;
            this._price3 = price3;
        }

    }
}