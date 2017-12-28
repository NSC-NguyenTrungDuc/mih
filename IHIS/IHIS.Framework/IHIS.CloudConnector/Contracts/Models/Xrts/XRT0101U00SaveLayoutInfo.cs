using System;

namespace IHIS.CloudConnector.Contracts.Models.Xrts
{
    [Serializable]
    public class XRT0101U00SaveLayoutInfo
    {
        private String _codeType;
        private String _codeTypeName;
        private String _code;
        private String _codeName;
        private String _code2;
        private String _seq;
        private String _codeValue;
        private String _rowState;
        private String _callerId;

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

        public String Code2
        {
            get { return this._code2; }
            set { this._code2 = value; }
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

        public String RowState
        {
            get { return this._rowState; }
            set { this._rowState = value; }
        }

        public String CallerId
        {
            get { return this._callerId; }
            set { this._callerId = value; }
        }

        public XRT0101U00SaveLayoutInfo() { }

        public XRT0101U00SaveLayoutInfo(String codeType, String codeTypeName, String code, String codeName, String code2, String seq, String codeValue, String rowState, String callerId)
        {
            this._codeType = codeType;
            this._codeTypeName = codeTypeName;
            this._code = code;
            this._codeName = codeName;
            this._code2 = code2;
            this._seq = seq;
            this._codeValue = codeValue;
            this._rowState = rowState;
            this._callerId = callerId;
        }

    }
}