using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0101U01GrdMcodeListItemInfo
    {
        private String _codeType;
        private String _codeTypeName;
        private String _adminGubun;
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public XRT0101U01GrdMcodeListItemInfo() { }

        public XRT0101U01GrdMcodeListItemInfo(String codeType, String codeTypeName, String adminGubun, String rowState)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
            this._adminGubun = adminGubun;
            this._rowState = rowState;
        }

    }
}