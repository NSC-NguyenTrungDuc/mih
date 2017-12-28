using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetHangmogListInfo
    {
        private String _setPart;
        private String _hangCode;
        private String _setCode;
        private String _setHangmogCode;
        private String _hangmogName;
        private String _suryang;
        private String _danui;
        private String _danuiName;
        private String _bulyongYn;
        private String _rowState;

        public String SetPart
        {
            get { return this._setPart; }
            set { this._setPart = value; }
        }

        public String HangCode
        {
            get { return this._hangCode; }
            set { this._hangCode = value; }
        }

        public String SetCode
        {
            get { return this._setCode; }
            set { this._setCode = value; }
        }

        public String SetHangmogCode
        {
            get { return this._setHangmogCode; }
            set { this._setHangmogCode = value; }
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public OCS0311U00grdSetHangmogListInfo() { }

        public OCS0311U00grdSetHangmogListInfo(String setPart, String hangCode, String setCode, String setHangmogCode, String hangmogName, String suryang, String danui, String danuiName, String bulyongYn, String rowState)
        {
            this._setPart = setPart;
            this._hangCode = hangCode;
            this._setCode = setCode;
            this._setHangmogCode = setHangmogCode;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._danui = danui;
            this._danuiName = danuiName;
            this._bulyongYn = bulyongYn;
            this._rowState = rowState;
        }

    }
}