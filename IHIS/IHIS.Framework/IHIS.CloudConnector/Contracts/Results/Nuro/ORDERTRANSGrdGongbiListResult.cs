using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdGongbiListResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdGongbiListInfo> _grdGongbiItem = new List<ORDERTRANSGrdGongbiListInfo>();

        public List<ORDERTRANSGrdGongbiListInfo> GrdGongbiItem
        {
            get { return this._grdGongbiItem; }
            set { this._grdGongbiItem = value; }
        }

        public ORDERTRANSGrdGongbiListResult() { }

    }
}