using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3020U02ResultMapGrdRsltInfo
    {
        private String _resultCode;
        private String _hangmogCode;
        private String _gumsaName;
        private String _resultVal;

        public String ResultCode
        {
            get { return this._resultCode; }
            set { this._resultCode = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String GumsaName
        {
            get { return this._gumsaName; }
            set { this._gumsaName = value; }
        }

        public String ResultVal
        {
            get { return this._resultVal; }
            set { this._resultVal = value; }
        }

        public CPL3020U02ResultMapGrdRsltInfo() { }

        public CPL3020U02ResultMapGrdRsltInfo(String resultCode, String hangmogCode, String gumsaName, String resultVal)
        {
            this._resultCode = resultCode;
            this._hangmogCode = hangmogCode;
            this._gumsaName = gumsaName;
            this._resultVal = resultVal;
        }

    }
}