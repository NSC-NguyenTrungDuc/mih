using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayRootListInfo
    {
        private String _setPart;
        private String _hangmogCode;
        private String _hangmogName;

        public String SetPart
        {
            get { return this._setPart; }
            set { this._setPart = value; }
        }

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

        public OCS0311Q00LayRootListInfo() { }

        public OCS0311Q00LayRootListInfo(String setPart, String hangmogCode, String hangmogName)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
        }

    }
}