using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSExecPrOutCheckOrderEndResult : AbstractContractResult
    {
        private String _outStr;

        public String OutStr
        {
            get { return this._outStr; }
            set { this._outStr = value; }
        }

        public ORDERTRANSExecPrOutCheckOrderEndResult() { }

    }
}