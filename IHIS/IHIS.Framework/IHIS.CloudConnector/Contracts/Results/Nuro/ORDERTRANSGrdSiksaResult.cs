using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdSiksaResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdSiksaInfo> _grdSiksaItem = new List<ORDERTRANSGrdSiksaInfo>();

        public List<ORDERTRANSGrdSiksaInfo> GrdSiksaItem
        {
            get { return this._grdSiksaItem; }
            set { this._grdSiksaItem = value; }
        }

        public ORDERTRANSGrdSiksaResult() { }

    }
}