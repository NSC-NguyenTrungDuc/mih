using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class IFS0004U01grdMasterListItemInfo
    {
        private String _nuGubun;
        private String _nuCode;
        private String _nuYmd;
        private String _nuCodeName;
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

        public String NuCodeName
        {
            get { return this._nuCodeName; }
            set { this._nuCodeName = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public IFS0004U01grdMasterListItemInfo() { }

        public IFS0004U01grdMasterListItemInfo(String nuGubun, String nuCode, String nuYmd, String nuCodeName, String rowState)
        {
            this._nuGubun = nuGubun;
            this._nuCode = nuCode;
            this._nuYmd = nuYmd;
            this._nuCodeName = nuCodeName;
            this._rowState = rowState;
        }

    }
}