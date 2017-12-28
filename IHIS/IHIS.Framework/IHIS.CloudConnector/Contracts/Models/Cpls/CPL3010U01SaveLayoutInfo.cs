using System;

namespace IHIS.CloudConnector.Contracts.Models.Cpls
{
    [Serializable]
    public class CPL3010U01SaveLayoutInfo
    {
        private String _cplResult;
        private String _standardYn;
        private String _comments1;
        private String _comments2;
        private String _requestKey;
        private String _bmlCode;

        public String CplResult
        {
            get { return this._cplResult; }
            set { this._cplResult = value; }
        }

        public String StandardYn
        {
            get { return this._standardYn; }
            set { this._standardYn = value; }
        }

        public String Comments1
        {
            get { return this._comments1; }
            set { this._comments1 = value; }
        }

        public String Comments2
        {
            get { return this._comments2; }
            set { this._comments2 = value; }
        }

        public String RequestKey
        {
            get { return this._requestKey; }
            set { this._requestKey = value; }
        }

        public String BmlCode
        {
            get { return this._bmlCode; }
            set { this._bmlCode = value; }
        }

        public CPL3010U01SaveLayoutInfo() { }

        public CPL3010U01SaveLayoutInfo(String cplResult, String standardYn, String comments1, String comments2, String requestKey, String bmlCode)
        {
            this._cplResult = cplResult;
            this._standardYn = standardYn;
            this._comments1 = comments1;
            this._comments2 = comments2;
            this._requestKey = requestKey;
            this._bmlCode = bmlCode;
        }

    }
}