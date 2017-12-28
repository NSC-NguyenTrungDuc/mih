using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U00GridColumnChangeResult : AbstractContractResult
    {
        private String _result;

        public String Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public IFS0003U00GridColumnChangeResult() { }

    }
}