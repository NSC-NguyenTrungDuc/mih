using System;

namespace IHIS.CloudConnector.Contracts.Models.Bass
{
    [Serializable]
    public class IFS0001U00GrdDetailInfo
    {
        private String _codeType;
        private String _acctType;
        private String _code;
        private String _codeName;
        private String _remark;
        private String _rowState;

        public String CodeType
        {
            get { return this._codeType; }
            set { this._codeType = value; }
        }

        public String AcctType
        {
            get { return this._acctType; }
            set { this._acctType = value; }
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

        public IFS0001U00GrdDetailInfo() { }

        public IFS0001U00GrdDetailInfo(String codeType, String acctType, String code, String codeName, String remark, String rowState)
        {
            this._codeType = codeType;
            this._acctType = acctType;
            this._code = code;
            this._codeName = codeName;
            this._remark = remark;
            this._rowState = rowState;
        }

    }
}