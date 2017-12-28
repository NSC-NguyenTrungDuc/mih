using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0203U00GetOCSCOMUserIDResult : AbstractContractResult
    {
        private String _result;

        public String Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public OCS0203U00GetOCSCOMUserIDResult() { }

    }
}