using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311Q00LaySetInfo
    {
        private String _setPart;
        private String _hangmogCode;
        private String _setCode;
        private String _setCodeName;

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

        public String SetCode
        {
            get { return this._setCode; }
            set { this._setCode = value; }
        }

        public String SetCodeName
        {
            get { return this._setCodeName; }
            set { this._setCodeName = value; }
        }

        public OCS0311Q00LaySetInfo() { }

        public OCS0311Q00LaySetInfo(String setPart, String hangmogCode, String setCode, String setCodeName)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._setCode = setCode;
            this._setCodeName = setCodeName;
        }

    }
}