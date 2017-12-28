using System;

namespace IHIS.CloudConnector.Contracts.Models.Ocso
{
    public class OCSACTUpdJaeryoProcessInfo
    {
        private String _suryang;
        private String _dtRowFirstVal;
        private String _iudGubun;
        private String _inputId;
        private String _bomSourceKey;
        private String _pkocs2003;
        private String _hangmogCode;
        private String _orderGubun;
        private String _nalsu;
        private String _ordDanui;
        private String _divide;
        private String _dvTime;
        private String _sysId;
        private String _pkinv1001;
        private String _rowState;
        private String _fkocsXrt;
        private String _fkocsInv;
        private String _pkocs1003;

        public String Suryang
        {
            get { return this._suryang; }
            set { this._suryang = value; }
        }

        public String DtRowFirstVal
        {
            get { return this._dtRowFirstVal; }
            set { this._dtRowFirstVal = value; }
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

        public String BomSourceKey
        {
            get { return this._bomSourceKey; }
            set { this._bomSourceKey = value; }
        }

        public String Pkocs2003
        {
            get { return this._pkocs2003; }
            set { this._pkocs2003 = value; }
        }

        public String HangmogCode
        {
            get { return this._hangmogCode; }
            set { this._hangmogCode = value; }
        }

        public String OrderGubun
        {
            get { return this._orderGubun; }
            set { this._orderGubun = value; }
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

        public String Divide
        {
            get { return this._divide; }
            set { this._divide = value; }
        }

        public String DvTime
        {
            get { return this._dvTime; }
            set { this._dvTime = value; }
        }

        public String SysId
        {
            get { return this._sysId; }
            set { this._sysId = value; }
        }

        public String Pkinv1001
        {
            get { return this._pkinv1001; }
            set { this._pkinv1001 = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
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

        public String Pkocs1003
        {
            get { return this._pkocs1003; }
            set { this._pkocs1003 = value; }
        }

        public OCSACTUpdJaeryoProcessInfo() { }

        public OCSACTUpdJaeryoProcessInfo(String suryang, String dtRowFirstVal, String iudGubun, String inputId, String bomSourceKey, String pkocs2003, String hangmogCode, String orderGubun, String nalsu, String ordDanui, String divide, String dvTime, String sysId, String pkinv1001, String rowState, String fkocsXrt, String fkocsInv, String pkocs1003)
        {
            this._suryang = suryang;
            this._dtRowFirstVal = dtRowFirstVal;
            this._iudGubun = iudGubun;
            this._inputId = inputId;
            this._bomSourceKey = bomSourceKey;
            this._pkocs2003 = pkocs2003;
            this._hangmogCode = hangmogCode;
            this._orderGubun = orderGubun;
            this._nalsu = nalsu;
            this._ordDanui = ordDanui;
            this._divide = divide;
            this._dvTime = dvTime;
            this._sysId = sysId;
            this._pkinv1001 = pkinv1001;
            this._rowState = rowState;
            this._fkocsXrt = fkocsXrt;
            this._fkocsInv = fkocsInv;
            this._pkocs1003 = pkocs1003;
        }

    }
}