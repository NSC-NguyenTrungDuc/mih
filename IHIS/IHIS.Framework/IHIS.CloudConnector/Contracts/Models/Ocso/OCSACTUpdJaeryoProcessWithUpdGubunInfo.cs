using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACTUpdJaeryoProcessWithUpdGubunInfo
    {
        private String _pkinv1001;
        private String _iudGubun;
        private String _inputId;
        private String _fkocsXrt;
        private String _fkocsInv;
        private String _hangmogCode;
        private String _suryang;
        private String _nalsu;
        private String _ordDanui;
        private String _pkocs1003;

        public String Pkinv1001
        {
            get { return this._pkinv1001; }
            set { this._pkinv1001 = value; }
        }

        public String IudGubun
        {
            get { return this._iudGubun; }
            set { this._iudGubun = value; }
        }

        public String InputId
        {
            get { return this._inputId; }
            set { this._inputId = value; }
        }

        public String FkocsXrt
        {
            get { return this._fkocsXrt; }
            set { this._fkocsXrt = value; }
        }

        public String FkocsInv
        {
            get { return this._fkocsInv; }
            set { this._fkocsInv = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String Nalsu
        {
            get { return this._nalsu; }
            set { this._nalsu = value; }
        }

        public String OrdDanui
        {
            get { return this._ordDanui; }
            set { this._ordDanui = value; }
        }

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public OCSACTUpdJaeryoProcessWithUpdGubunInfo() { }

        public OCSACTUpdJaeryoProcessWithUpdGubunInfo(String pkinv1001, String iudGubun, String inputId, String fkocsXrt, String fkocsInv, String hangmogCode, String suryang, String nalsu, String ordDanui, String pkocs1003)
        {
            this._pkinv1001 = pkinv1001;
            this._iudGubun = iudGubun;
            this._inputId = inputId;
            this._fkocsXrt = fkocsXrt;
            this._fkocsInv = fkocsInv;
            this._hangmogCode = hangmogCode;
            this._suryang = suryang;
            this._nalsu = nalsu;
            this._ordDanui = ordDanui;
            this._pkocs1003 = pkocs1003;
        }

    }
}