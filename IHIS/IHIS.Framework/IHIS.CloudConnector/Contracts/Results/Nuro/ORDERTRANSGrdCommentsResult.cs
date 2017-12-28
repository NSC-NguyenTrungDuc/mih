using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdCommentsResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdCommentsInfo> _grdCommentsItem = new List<ORDERTRANSGrdCommentsInfo>();

        public List<ORDERTRANSGrdCommentsInfo> GrdCommentsItem
        {
            get { return this._grdCommentsItem; }
            set { this._grdCommentsItem = value; }
        }

        public ORDERTRANSGrdCommentsResult() { }

    }
}