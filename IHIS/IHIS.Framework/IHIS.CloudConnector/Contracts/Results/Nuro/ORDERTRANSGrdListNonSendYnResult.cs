using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdListNonSendYnResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdListNonSendYnInfo> _grdListNonSendItem = new List<ORDERTRANSGrdListNonSendYnInfo>();

        public List<ORDERTRANSGrdListNonSendYnInfo> GrdListNonSendItem
        {
            get { return this._grdListNonSendItem; }
            set { this._grdListNonSendItem = value; }
        }

        public ORDERTRANSGrdListNonSendYnResult() { }

    }
}