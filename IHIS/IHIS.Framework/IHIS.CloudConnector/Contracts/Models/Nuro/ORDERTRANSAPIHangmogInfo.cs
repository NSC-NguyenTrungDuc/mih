using System;

namespace IHIS.CloudConnector.Contracts.Models.Nuro
{
    public class ORDERTRANSAPIHangmogInfo
    {
        private String _hangmogCode;
        private String _hangmogName;
        private String _pkocs1003;

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

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public ORDERTRANSAPIHangmogInfo() { }

        public ORDERTRANSAPIHangmogInfo(String hangmogCode, String hangmogName, String pkocs1003)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._pkocs1003 = pkocs1003;
        }

    }
}