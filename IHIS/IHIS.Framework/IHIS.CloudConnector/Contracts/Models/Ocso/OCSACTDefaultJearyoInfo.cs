using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCSACTDefaultJearyoInfo
    {
        private String _setHangmogCode;
        private String _suryang;
        private String _danui;
        private String _danuiName;

        public String SetHangmogCode
        {
            get { return this._setHangmogCode; }
            set { this._setHangmogCode = value; }
        }

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String Danui
        {
            get { return this._danui; }
            set { this._danui = value; }
        }

        public String DanuiName
        {
            get { return this._danuiName; }
            set { this._danuiName = value; }
        }

        public OCSACTDefaultJearyoInfo() { }

        public OCSACTDefaultJearyoInfo(String setHangmogCode, String suryang, String danui, String danuiName)
        {
            this._setHangmogCode = setHangmogCode;
            this._suryang = suryang;
            this._danui = danui;
            this._danuiName = danuiName;
        }

    }
}