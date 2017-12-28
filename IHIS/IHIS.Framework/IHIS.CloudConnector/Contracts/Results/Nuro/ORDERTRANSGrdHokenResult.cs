using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdHokenResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdHokenInfo> _grdHokenItem = new List<ORDERTRANSGrdHokenInfo>();

        public List<ORDERTRANSGrdHokenInfo> GrdHokenItem
        {
            get { return this._grdHokenItem; }
            set { this._grdHokenItem = value; }
        }

        public ORDERTRANSGrdHokenResult() { }

    }
}