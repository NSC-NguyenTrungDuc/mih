using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV6000U00LaySummaryDetailInfo
    {
        private String _slipCode;
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _subulDanga;
        private String _danui;
        private String _jaegoQty;
        private String _sougaku;

        public String SlipCode
        {
            get { return this._slipCode; }
            set { this._slipCode = value; }
        }

        public String JaeryoCode
        {
            get { return this._jaeryoCode; }
            set { this._jaeryoCode = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public String SubulDanga
        {
            get { return this._subulDanga; }
            set { this._subulDanga = value; }
        }

        public String Danui
        {
            get { return this._danui; }
            set { this._danui = value; }
        }

        public String JaegoQty
        {
            get { return this._jaegoQty; }
            set { this._jaegoQty = value; }
        }

        public String Sougaku
        {
            get { return this._sougaku; }
            set { this._sougaku = value; }
        }

        public INV6000U00LaySummaryDetailInfo() { }

        public INV6000U00LaySummaryDetailInfo(String slipCode, String jaeryoCode, String jaeryoName, String subulDanga, String danui, String jaegoQty, String sougaku)
        {
            this._slipCode = slipCode;
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._subulDanga = subulDanga;
            this._danui = danui;
            this._jaegoQty = jaegoQty;
            this._sougaku = sougaku;
        }

    }
}