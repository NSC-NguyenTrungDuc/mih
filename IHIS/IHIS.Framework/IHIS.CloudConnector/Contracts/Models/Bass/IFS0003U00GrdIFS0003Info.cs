using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class IFS0003U00GrdIFS0003Info
    {
        private String _mapGubun;
        private String _mapGubunYmd;
        private String _ocsCode;
        private String _ocsCodeName;
        private String _ocsDefaultYn;
        private String _ifCode;
        private String _ifCodeName;
        private String _ifDefaultYn;
        private String _remark;
        private String _acctType;
        private String _rowState;

        public String MapGubun
        {
            get { return this._mapGubun; }
            set { this._mapGubun = value; }
        }

        public String MapGubunYmd
        {
            get { return this._mapGubunYmd; }
            set { this._mapGubunYmd = value; }
        }

        public String OcsCode
        {
            get { return this._ocsCode; }
            set { this._ocsCode = value; }
        }

        public String OcsCodeName
        {
            get { return this._ocsCodeName; }
            set { this._ocsCodeName = value; }
        }

        public String OcsDefaultYn
        {
            get { return this._ocsDefaultYn; }
            set { this._ocsDefaultYn = value; }
        }

        public String IfCode
        {
            get { return this._ifCode; }
            set { this._ifCode = value; }
        }

        public String IfCodeName
        {
            get { return this._ifCodeName; }
            set { this._ifCodeName = value; }
        }

        public String IfDefaultYn
        {
            get { return this._ifDefaultYn; }
            set { this._ifDefaultYn = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String AcctType
        {
            get { return this._acctType; }
            set { this._acctType = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public IFS0003U00GrdIFS0003Info() { }

        public IFS0003U00GrdIFS0003Info(String mapGubun, String mapGubunYmd, String ocsCode, String ocsCodeName, String ocsDefaultYn, String ifCode, String ifCodeName, String ifDefaultYn, String remark, String acctType, String rowState)
        {
            this._mapGubun = mapGubun;
            this._mapGubunYmd = mapGubunYmd;
            this._ocsCode = ocsCode;
            this._ocsCodeName = ocsCodeName;
            this._ocsDefaultYn = ocsDefaultYn;
            this._ifCode = ifCode;
            this._ifCodeName = ifCodeName;
            this._ifDefaultYn = ifDefaultYn;
            this._remark = remark;
            this._acctType = acctType;
            this._rowState = rowState;
        }

    }
}