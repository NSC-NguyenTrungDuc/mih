using System;

namespace IHIS.CloudConnector.Contracts.Models.Invs
{
    public class INV0101U01GridDetailInfo
    {
        private String _codeType;
        private String _code;
        private String _codeName;
        private String _sortKey;
        private String _key;
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

        public String Key
        {
            get { return this._key; }
            set { this._key = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public INV0101U01GridDetailInfo() { }

        public INV0101U01GridDetailInfo(String codeType, String code, String codeName, String sortKey, String key, String rowState)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
            this._sortKey = sortKey;
            this._key = key;
            this._rowState = rowState;
        }

    }
}