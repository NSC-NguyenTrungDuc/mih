using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANOrderTransResult : AbstractContractResult
    {
        private List<ORDERTRANOrderTransInfo> _sangtransInfo = new List<ORDERTRANOrderTransInfo>();

        public List<ORDERTRANOrderTransInfo> SangtransInfo
        {
            get { return this._sangtransInfo; }
            set { this._sangtransInfo = value; }
        }

        public ORDERTRANOrderTransResult() { }

    }
}