using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class NUROAccountForcedEndResult : AbstractContractResult
    {
        private Boolean _result;
        private String _errorCode;
        private String _strOutput;

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public String ErrorCode
        {
            get { return this._errorCode; }
            set { this._errorCode = value; }
        }

        public String StrOutput
        {
            get { return this._strOutput; }
            set { this._strOutput = value; }
        }

        public NUROAccountForcedEndResult() { }

    }
}