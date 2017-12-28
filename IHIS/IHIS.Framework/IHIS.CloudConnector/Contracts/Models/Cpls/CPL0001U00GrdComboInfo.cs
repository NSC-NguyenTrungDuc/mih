using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL0001U00GrdComboInfo
    {
        private String _code;
        private String _codeNameRe;

        public String Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        public String CodeNameRe
        {
            get { return this._codeNameRe; }
            set { this._codeNameRe = value; }
        }

        public CPL0001U00GrdComboInfo() { }

        public CPL0001U00GrdComboInfo(String code, String codeNameRe)
        {
            this._code = code;
            this._codeNameRe = codeNameRe;
        }

    }
}