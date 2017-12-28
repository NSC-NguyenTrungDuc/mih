using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311Q00LayDownListInfo
    {
        private String _setPart;
        private String _hangmogCode;
        private String _setCode;
        private String _hangmogCodeSet;
        private String _hangmogName;
        private String _suryang;
        private String _danui;
        private String _danuiName;
        private String _bulyongYn;
        private String _slipName;
        private String _inputControl;
        private String _bunCode;

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

        public String HangmogCodeSet
        {
            get { return this._hangmogCodeSet; }
            set { this._hangmogCodeSet = value; }
        }

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

        public String BulyongYn
        {
            get { return this._bulyongYn; }
            set { this._bulyongYn = value; }
        }

        public String SlipName
        {
            get { return this._slipName; }
            set { this._slipName = value; }
        }

        public String InputControl
        {
            get { return this._inputControl; }
            set { this._inputControl = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public OCS0311Q00LayDownListInfo() { }

        public OCS0311Q00LayDownListInfo(String setPart, String hangmogCode, String setCode, String hangmogCodeSet, String hangmogName, String suryang, String danui, String danuiName, String bulyongYn, String slipName, String inputControl, String bunCode)
        {
            this._setPart = setPart;
            this._hangmogCode = hangmogCode;
            this._setCode = setCode;
            this._hangmogCodeSet = hangmogCodeSet;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._danui = danui;
            this._danuiName = danuiName;
            this._bulyongYn = bulyongYn;
            this._slipName = slipName;
            this._inputControl = inputControl;
            this._bunCode = bunCode;
        }

    }
}