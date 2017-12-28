using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0118U00FwkOCS0103Info
    {
        private String _hangmogCode;
        private String _hangmogName;

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

        public OCS0118U00FwkOCS0103Info() { }

        public OCS0118U00FwkOCS0103Info(String hangmogCode, String hangmogName)
        {
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
        }

    }
}