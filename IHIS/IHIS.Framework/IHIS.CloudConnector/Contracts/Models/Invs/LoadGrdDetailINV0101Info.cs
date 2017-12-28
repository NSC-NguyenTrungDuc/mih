using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class LoadGrdDetailINV0101Info
    {
        private String _codeType;
        private String _code;
        private String _codeName;
        private String _sortKey;
        private String _code2;
        private String _code3;
        private String _remark;
        private String _rowState;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String SortKey
        {
            get { return this._sortKey; }
            set { this._sortKey = value; }
        }

        public String Code2
        {
            get { return this._code2; }
            set { this._code2 = value; }
        }

        public String Code3
        {
            get { return this._code3; }
            set { this._code3 = value; }
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

        public LoadGrdDetailINV0101Info() { }

        public LoadGrdDetailINV0101Info(String codeType, String code, String codeName, String sortKey, String code2, String code3, String remark, String rowState)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
            this._sortKey = sortKey;
            this._code2 = code2;
            this._code3 = code3;
            this._remark = remark;
            this._rowState = rowState;
        }

    }
}