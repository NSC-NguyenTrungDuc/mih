using System;
using IHIS.CloudConnector.Contracts.Models.Ocso;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocso
{
    [Serializable]
    public class OCSACTSingleStringResult : AbstractContractResult
    {
        private String _responseStr;

        public String ResponseStr
        {
            get { return this._responseStr; }
            set { this._responseStr = value; }
        }

        public OCSACTSingleStringResult() { }

    }
}