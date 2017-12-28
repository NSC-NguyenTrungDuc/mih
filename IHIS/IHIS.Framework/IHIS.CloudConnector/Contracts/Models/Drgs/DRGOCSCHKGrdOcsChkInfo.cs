using System;

namespace IHIS.CloudConnector.Contracts.Models.Drgs
{
    [Serializable]
    public class DRGOCSCHKGrdOcsChkInfo
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public DRGOCSCHKGrdOcsChkInfo() { }

        public DRGOCSCHKGrdOcsChkInfo(String jaeryoCode, String jaeryoName, String drgPackYn, String phamarcyYn, String powerYn, String hubalChangeYn, String mayakYn, String smallCode, String smallCodeName, String cautionCode, String cautionName, String rowState)
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
            this._rowState = rowState;
        }

    }
}