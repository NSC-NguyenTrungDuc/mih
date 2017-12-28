using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class IFS0004U01grdDetailtListItemInfo
    {
        private String _nuGubun;
        private String _nuCode;
        private String _nuYmd;
        private String _bunCode;
        private String _bunName;
        private String _sgCode;
        private String _sgName;
        private String _rowState;

        public String NuGubun
        {
            get { return this._nuGubun; }
            set { this._nuGubun = value; }
        }

        public String NuCode
        {
            get { return this._nuCode; }
            set { this._nuCode = value; }
        }

        public String NuYmd
        {
            get { return this._nuYmd; }
            set { this._nuYmd = value; }
        }

        public String BunCode
        {
            get { return this._bunCode; }
            set { this._bunCode = value; }
        }

        public String BunName
        {
            get { return this._bunName; }
            set { this._bunName = value; }
        }

        public String SgCode
        {
            get { return this._sgCode; }
            set { this._sgCode = value; }
        }

        public String SgName
        {
            get { return this._sgName; }
            set { this._sgName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public IFS0004U01grdDetailtListItemInfo() { }

        public IFS0004U01grdDetailtListItemInfo(String nuGubun, String nuCode, String nuYmd, String bunCode, String bunName, String sgCode, String sgName, String rowState)
        {
            this._nuGubun = nuGubun;
            this._nuCode = nuCode;
            this._nuYmd = nuYmd;
            this._bunCode = bunCode;
            this._bunName = bunName;
            this._sgCode = sgCode;
            this._sgName = sgName;
            this._rowState = rowState;
        }

    }
}