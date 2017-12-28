using System;

namespace IHIS.CloudConnector.Contracts.Models.Endo
{
    [Serializable]
    public class END1001U02StrInfo
    {
        private String _value;

        public String Value
        {
            get { return this._value; }
            set { this._value = value; }
        }

        public END1001U02StrInfo() { }

        public END1001U02StrInfo(String value)
        {
            this._value = value;
        }

    }
}