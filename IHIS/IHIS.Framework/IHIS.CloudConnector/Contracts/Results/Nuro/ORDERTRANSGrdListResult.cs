using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdListInfo> _grdItem = new List<ORDERTRANSGrdListInfo>();

        public List<ORDERTRANSGrdListInfo> GrdItem
        {
            get { return this._grdItem; }
            set { this._grdItem = value; }
        }

        public ORDERTRANSGrdListResult() { }

    }
}