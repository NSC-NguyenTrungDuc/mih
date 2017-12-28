using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANPRMakeIFS1004Result : AbstractContractResult
    {
        private String _retVal;

        public String RetVal
        {
            get { return this._retVal; }
            set { this._retVal = value; }
        }

        public ORDERTRANPRMakeIFS1004Result() { }

    }
}