using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0101U01GrdDcodeListItemInfo
    {
        private String _codeType;
        private String _code;
        private String _code2;
        private String _codeName;
        private String _codeName2;
        private String _seq;
        private String _codeValue;
        private String _trimValue;
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

        public String Code2
        {
            get { return this._code2; }
            set { this._code2 = value; }
        }

        public String CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public String CodeName2
        {
            get { return this._codeName2; }
            set { this._codeName2 = value; }
        }

        public String Seq
        {
            get { return this._seq; }
            set { this._seq = value; }
        }

        public String CodeValue
        {
            get { return this._codeValue; }
            set { this._codeValue = value; }
        }

        public String TrimValue
        {
            get { return this._trimValue; }
            set { this._trimValue = value; }
        }

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public XRT0101U01GrdDcodeListItemInfo() { }

        public XRT0101U01GrdDcodeListItemInfo(String codeType, String code, String code2, String codeName, String codeName2, String seq, String codeValue, String trimValue, String rowState)
        {
            this._codeType = codeType;
            this._code = code;
            this._code2 = code2;
            this._codeName = codeName;
            this._codeName2 = codeName2;
            this._seq = seq;
            this._codeValue = codeValue;
            this._trimValue = trimValue;
            this._rowState = rowState;
        }

    }
}