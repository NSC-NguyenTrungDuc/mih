using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdOutSangResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdOutSangInfo> _grdOutSangItem = new List<ORDERTRANSGrdOutSangInfo>();

        public List<ORDERTRANSGrdOutSangInfo> GrdOutSangItem
        {
            get { return this._grdOutSangItem; }
            set { this._grdOutSangItem = value; }
        }

        public ORDERTRANSGrdOutSangResult() { }

    }
}