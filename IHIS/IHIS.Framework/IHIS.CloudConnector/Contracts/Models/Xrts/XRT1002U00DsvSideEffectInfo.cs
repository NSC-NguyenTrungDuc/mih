using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT1002U00DsvSideEffectInfo
    {
        private String _fkxrt0201;
        private String _xrayDate;
        private String _xrayName;
        private String _jaeryoName;
        private String _remark;
        private String _sideEffect1;
        private String _sideEffect2;
        private String _sideEffect3;
        private String _sideEffect4;
        private String _sideEffect5;
        private String _sideEffect6;
        private String _sideEffect7;
        private String _sideEffectText;

        public String Fkxrt0201
        {
            get { return this._fkxrt0201; }
            set { this._fkxrt0201 = value; }
        }

        public String XrayDate
        {
            get { return this._xrayDate; }
            set { this._xrayDate = value; }
        }

        public String XrayName
        {
            get { return this._xrayName; }
            set { this._xrayName = value; }
        }

        public String JaeryoName
        {
            get { return this._jaeryoName; }
            set { this._jaeryoName = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String SideEffect1
        {
            get { return this._sideEffect1; }
            set { this._sideEffect1 = value; }
        }

        public String SideEffect2
        {
            get { return this._sideEffect2; }
            set { this._sideEffect2 = value; }
        }

        public String SideEffect3
        {
            get { return this._sideEffect3; }
            set { this._sideEffect3 = value; }
        }

        public String SideEffect4
        {
            get { return this._sideEffect4; }
            set { this._sideEffect4 = value; }
        }

        public String SideEffect5
        {
            get { return this._sideEffect5; }
            set { this._sideEffect5 = value; }
        }

        public String SideEffect6
        {
            get { return this._sideEffect6; }
            set { this._sideEffect6 = value; }
        }

        public String SideEffect7
        {
            get { return this._sideEffect7; }
            set { this._sideEffect7 = value; }
        }

        public String SideEffectText
        {
            get { return this._sideEffectText; }
            set { this._sideEffectText = value; }
        }

        public XRT1002U00DsvSideEffectInfo() { }

        public XRT1002U00DsvSideEffectInfo(String fkxrt0201, String xrayDate, String xrayName, String jaeryoName, String remark, String sideEffect1, String sideEffect2, String sideEffect3, String sideEffect4, String sideEffect5, String sideEffect6, String sideEffect7, String sideEffectText)
        {
            this._fkxrt0201 = fkxrt0201;
            this._xrayDate = xrayDate;
            this._xrayName = xrayName;
            this._jaeryoName = jaeryoName;
            this._remark = remark;
            this._sideEffect1 = sideEffect1;
            this._sideEffect2 = sideEffect2;
            this._sideEffect3 = sideEffect3;
            this._sideEffect4 = sideEffect4;
            this._sideEffect5 = sideEffect5;
            this._sideEffect6 = sideEffect6;
            this._sideEffect7 = sideEffect7;
            this._sideEffectText = sideEffectText;
        }

    }
}