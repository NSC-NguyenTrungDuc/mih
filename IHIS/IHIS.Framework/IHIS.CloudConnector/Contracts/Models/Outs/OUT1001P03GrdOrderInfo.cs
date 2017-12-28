using System;

namespace IHIS.CloudConnector.Contracts.Models.Outs
{
    [Serializable]
    public class OUT1001P03GrdOrderInfo
    {
        private String _pkocskey;
        private String _orderGubun;
        private String _orderGubunName;
        private String _hangmogCode;
        private String _hangmogName;
        private String _suryang;
        private String _ordDanui;
        private String _nalsu;

        public String Pkocskey
        {
            get { return this._pkocskey; }
            set { this._pkocskey = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
        }

        public String OrderGubunName
        {
            get { return this._orderGubunName; }
            set { this._orderGubunName = value; }
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

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public OUT1001P03GrdOrderInfo() { }

        public OUT1001P03GrdOrderInfo(String pkocskey, String orderGubun, String orderGubunName, String hangmogCode, String hangmogName, String suryang, String ordDanui, String nalsu)
        {
            this._pkocskey = pkocskey;
            this._orderGubun = orderGubun;
            this._orderGubunName = orderGubunName;
            this._hangmogCode = hangmogCode;
            this._hangmogName = hangmogName;
            this._suryang = suryang;
            this._ordDanui = ordDanui;
            this._nalsu = nalsu;
        }

    }
}