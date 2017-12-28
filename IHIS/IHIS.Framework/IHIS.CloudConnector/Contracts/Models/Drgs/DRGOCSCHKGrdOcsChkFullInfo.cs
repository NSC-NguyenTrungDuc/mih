using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    public class DRGOCSCHKGrdOcsChkFullInfo
    {
        private String _jaeryoCode;
        private String _jaeryoName;
        private String _drgPackYn;
        private String _phamarcyYn;
        private String _powerYn;
        private String _hubalChangeYn;
        private String _mayakYn;
        private String _smallCode;
        private String _smallCodeName;
        private String _cautionCode;
        private String _cautionName;
        private String _startDate;
        private String _sunabDanui;
        private String _sunabDanuiName;
        private String _subulDanui;
        private String _subulDanuiName;
        private String _stockYn;
        private String _subulDanga;
        private String _subulQcodeOut;
        private String _subulQcodeOutName;
        private String _subulQcodeInp;
        private String _subulQcodeInpName;
        private String _rowState;

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

        public String DrgPackYn
        {
            get { return this._drgPackYn; }
            set { this._drgPackYn = value; }
        }

        public String PhamarcyYn
        {
            get { return this._phamarcyYn; }
            set { this._phamarcyYn = value; }
        }

        public String PowerYn
        {
            get { return this._powerYn; }
            set { this._powerYn = value; }
        }

        public String HubalChangeYn
        {
            get { return this._hubalChangeYn; }
            set { this._hubalChangeYn = value; }
        }

        public String MayakYn
        {
            get { return this._mayakYn; }
            set { this._mayakYn = value; }
        }

        public String SmallCode
        {
            get { return this._smallCode; }
            set { this._smallCode = value; }
        }

        public String SmallCodeName
        {
            get { return this._smallCodeName; }
            set { this._smallCodeName = value; }
        }

        public String CautionCode
        {
            get { return this._cautionCode; }
            set { this._cautionCode = value; }
        }

        public String CautionName
        {
            get { return this._cautionName; }
            set { this._cautionName = value; }
        }

        public String StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        public String SunabDanui
        {
            get { return this._sunabDanui; }
            set { this._sunabDanui = value; }
        }

        public String SunabDanuiName
        {
            get { return this._sunabDanuiName; }
            set { this._sunabDanuiName = value; }
        }

        public String SubulDanui
        {
            get { return this._subulDanui; }
            set { this._subulDanui = value; }
        }

        public String SubulDanuiName
        {
            get { return this._subulDanuiName; }
            set { this._subulDanuiName = value; }
        }

        public String StockYn
        {
            get { return this._stockYn; }
            set { this._stockYn = value; }
        }

        public String SubulDanga
        {
            get { return this._subulDanga; }
            set { this._subulDanga = value; }
        }

        public String SubulQcodeOut
        {
            get { return this._subulQcodeOut; }
            set { this._subulQcodeOut = value; }
        }

        public String SubulQcodeOutName
        {
            get { return this._subulQcodeOutName; }
            set { this._subulQcodeOutName = value; }
        }

        public String SubulQcodeInp
        {
            get { return this._subulQcodeInp; }
            set { this._subulQcodeInp = value; }
        }

        public String SubulQcodeInpName
        {
            get { return this._subulQcodeInpName; }
            set { this._subulQcodeInpName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public DRGOCSCHKGrdOcsChkFullInfo() { }

        public DRGOCSCHKGrdOcsChkFullInfo(String jaeryoCode, String jaeryoName, String drgPackYn, String phamarcyYn, String powerYn, String hubalChangeYn, String mayakYn, String smallCode, String smallCodeName, String cautionCode, String cautionName, String startDate, String sunabDanui, String sunabDanuiName, String subulDanui, String subulDanuiName, String stockYn, String subulDanga, String subulQcodeOut, String subulQcodeOutName, String subulQcodeInp, String subulQcodeInpName, String rowState)
        {
            this._jaeryoCode = jaeryoCode;
            this._jaeryoName = jaeryoName;
            this._drgPackYn = drgPackYn;
            this._phamarcyYn = phamarcyYn;
            this._powerYn = powerYn;
            this._hubalChangeYn = hubalChangeYn;
            this._mayakYn = mayakYn;
            this._smallCode = smallCode;
            this._smallCodeName = smallCodeName;
            this._cautionCode = cautionCode;
            this._cautionName = cautionName;
            this._startDate = startDate;
            this._sunabDanui = sunabDanui;
            this._sunabDanuiName = sunabDanuiName;
            this._subulDanui = subulDanui;
            this._subulDanuiName = subulDanuiName;
            this._stockYn = stockYn;
            this._subulDanga = subulDanga;
            this._subulQcodeOut = subulQcodeOut;
            this._subulQcodeOutName = subulQcodeOutName;
            this._subulQcodeInp = subulQcodeInp;
            this._subulQcodeInpName = subulQcodeInpName;
            this._rowState = rowState;
        }

    }
}