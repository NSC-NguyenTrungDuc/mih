using System;

namespace IHIS.CloudConnector.Contracts.Models.Schs
{
    [Serializable]
    public class SCH0109U01GrdMasterInfo
    {
        private String _codeType;
        private String _codeTypeName;
        private String _adminGubun;
        private String _remark;
        private String _rowState;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String CodeTypeName
        {
            get { return this._codeTypeName; }
            set { this._codeTypeName = value; }
        }

        public String AdminGubun
        {
            get { return this._adminGubun; }
            set { this._adminGubun = value; }
        }

        public String Remark
        {
            get { return this._remark; }
            set { this._remark = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public SCH0109U01GrdMasterInfo() { }

        public SCH0109U01GrdMasterInfo(String codeType, String codeTypeName, String adminGubun, String remark, String rowState)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
            this._adminGubun = adminGubun;
            this._remark = remark;
            this._rowState = rowState;
        }

    }
}