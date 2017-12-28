using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class BAS0101U00GrdMasterItemInfo
    {
        private String _codeType;
        private String _codeTypeName;
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public BAS0101U00GrdMasterItemInfo() { }

        public BAS0101U00GrdMasterItemInfo(String codeType, String codeTypeName, String rowState)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
            this._rowState = rowState;
        }

    }
}