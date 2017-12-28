using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListSendYnResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdListSendYnInfo> _grdListSendItem = new List<ORDERTRANSGrdListSendYnInfo>();

        public List<ORDERTRANSGrdListSendYnInfo> GrdListSendItem
        {
            get { return this._grdListSendItem; }
            set { this._grdListSendItem = value; }
        }

        public ORDERTRANSGrdListSendYnResult() { }

    }
}