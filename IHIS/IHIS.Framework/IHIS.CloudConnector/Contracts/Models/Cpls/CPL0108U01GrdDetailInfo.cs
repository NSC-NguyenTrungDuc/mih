using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0108U01GrdDetailInfo
    {
        private String _codeType;
        private String _code;
        private String _codeName;
        private String _codeNameRe;
        private String _systemGubun;
        private String _codeValue;
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

        public String CodeNameRe
        {
            get { return this._codeNameRe; }
            set { this._codeNameRe = value; }
        }

        public String SystemGubun
        {
            get { return this._systemGubun; }
            set { this._systemGubun = value; }
        }

        public String CodeValue
        {
            get { return this._codeValue; }
            set { this._codeValue = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public CPL0108U01GrdDetailInfo() { }

        public CPL0108U01GrdDetailInfo(String codeType, String code, String codeName, String codeNameRe, String systemGubun, String codeValue, String rowState)
        {
            this._codeType = codeType;
            this._code = code;
            this._codeName = codeName;
            this._codeNameRe = codeNameRe;
            this._systemGubun = systemGubun;
            this._codeValue = codeValue;
            this._rowState = rowState;
        }

    }
}