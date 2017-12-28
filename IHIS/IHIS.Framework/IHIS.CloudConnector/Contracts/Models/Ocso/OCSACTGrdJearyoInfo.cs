using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    [Serializable]
    public class OCSACTGrdJearyoInfo
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _suryang;
        private String _ordDanui;
        private String _pkinv1001;
        private String _bunho;
        private String _orderDate;
        private String _ioGubun;
        private String _actingDate;
        private String _jundalPart;
        private String _inOutGubun;
        private String _fkocs;
        private String _danuiName;
        private String _bunryu2;
        private String _jaeryoGubun;
        private String _jaeryoYn;
        private String _inputControl;
        private String _bunCode;
        private String _nalsu;
        private String _ioGubunPkocs;

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

        public String Pkinv1001
        {
            get { return this._pkinv1001; }
            set { this._pkinv1001 = value; }
        }

        public String Bunho
        {
            get { return this._bunho; }
            set { this._bunho = value; }
        }

        public String OrderDate
        {
            get { return this._orderDate; }
            set { this._orderDate = value; }
        }

        public String IoGubun
        {
            get { return this._ioGubun; }
            set { this._ioGubun = value; }
        }

        public String ActingDate
        {
            get { return this._actingDate; }
            set { this._actingDate = value; }
        }

        public String JundalPart
        {
            get { return this._jundalPart; }
            set { this._jundalPart = value; }
        }

        public String InOutGubun
        {
            get { return this._inOutGubun; }
            set { this._inOutGubun = value; }
        }

        public String Fkocs
        {
            get { return this._fkocs; }
            set { this._fkocs = value; }
        }

        public String DanuiName
        {
            get { return this._danuiName; }
            set { this._danuiName = value; }
        }

        public String Bunryu2
        {
            get { return this._bunryu2; }
            set { this._bunryu2 = value; }
        }

        public String JaeryoGubun
        {
            get { return this._jaeryoGubun; }
            set { this._jaeryoGubun = value; }
        }

        public String JaeryoYn
        {
            get { return this._jaeryoYn; }
            set { this._jaeryoYn = value; }
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

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String IoGubunPkocs
        {
            get { return this._ioGubunPkocs; }
            set { this._ioGubunPkocs = value; }
        }

        public OCSACTGrdJearyoInfo() { }

        public OCSACTGrdJearyoInfo(String jaeryoCode, String jaeryoName, String suryang, String ordDanui, String pkinv1001, String bunho, String orderDate, String ioGubun, String actingDate, String jundalPart, String inOutGubun, String fkocs, String danuiName, String bunryu2, String jaeryoGubun, String jaeryoYn, String inputControl, String bunCode, String nalsu, String ioGubunPkocs)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._suryang = suryang;
            this._ordDanui = ordDanui;
            this._pkinv1001 = pkinv1001;
            this._bunho = bunho;
            this._orderDate = orderDate;
            this._ioGubun = ioGubun;
            this._actingDate = actingDate;
            this._jundalPart = jundalPart;
            this._inOutGubun = inOutGubun;
            this._fkocs = fkocs;
            this._danuiName = danuiName;
            this._bunryu2 = bunryu2;
            this._jaeryoGubun = jaeryoGubun;
            this._jaeryoYn = jaeryoYn;
            this._inputControl = inputControl;
            this._bunCode = bunCode;
            this._nalsu = nalsu;
            this._ioGubunPkocs = ioGubunPkocs;
        }

    }
}