using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class ComBizGetFindWorkerInfo
    {
        private String _code;
        private String _codeName;
        private String _value;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public ComBizGetFindWorkerInfo() { }

        public ComBizGetFindWorkerInfo(String code, String codeName, String value)
        {
            this._code = code;
            this._codeName = codeName;
            this._value = value;
        }

    }
}