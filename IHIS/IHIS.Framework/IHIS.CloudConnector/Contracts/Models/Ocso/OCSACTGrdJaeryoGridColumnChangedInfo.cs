using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCSACTGrdJaeryoGridColumnChangedInfo
    {
        private String _hangmogName;
        private String _suryang;
        private String _danui;
        private String _danuiName;
        private String _bunCode;
        private String _inputControl;

        public String HangmogName
        {
            get { return this._hangmogName; }
            set { this._hangmogName = value; }
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

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public OCSACTGrdJaeryoGridColumnChangedInfo() { }

        public OCSACTGrdJaeryoGridColumnChangedInfo(String hangmogName, String suryang, String danui, String danuiName, String bunCode, String inputControl)
        {
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._danui = danui;
            this._danuiName = danuiName;
            this._bunCode = bunCode;
            this._inputControl = inputControl;
        }

    }
}