using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSangTransResult : AbstractContractResult
    {
        private List<ORDERTRANSangTransInfo> _sangtransInfo = new List<ORDERTRANSangTransInfo>();

        public List<ORDERTRANSangTransInfo> SangtransInfo
        {
            get { return this._sangtransInfo; }
            set { this._sangtransInfo = value; }
        }

        public ORDERTRANSangTransResult() { }

    }
}