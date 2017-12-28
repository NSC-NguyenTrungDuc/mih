using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdWoichulResult : AbstractContractResult
    {
        private List<ORDERTRANSGrdWoichulInfo> _grdWoiChulItem = new List<ORDERTRANSGrdWoichulInfo>();

        public List<ORDERTRANSGrdWoichulInfo> GrdWoiChulItem
        {
            get { return this._grdWoiChulItem; }
            set { this._grdWoiChulItem = value; }
        }

        public ORDERTRANSGrdWoichulResult() { }

    }
}