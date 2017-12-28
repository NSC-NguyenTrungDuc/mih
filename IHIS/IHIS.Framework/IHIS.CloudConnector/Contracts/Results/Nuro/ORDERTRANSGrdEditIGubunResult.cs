using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdEditIGubunResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdEditIGubunInfo> _grdEditIgubunItem = new List<ORDERTRANSGrdEditIGubunInfo>();

        public List<ORDERTRANSGrdEditIGubunInfo> GrdEditIgubunItem
        {
            get { return this._grdEditIgubunItem; }
            set { this._grdEditIgubunItem = value; }
        }

        public ORDERTRANSGrdEditIGubunResult() { }

    }
}