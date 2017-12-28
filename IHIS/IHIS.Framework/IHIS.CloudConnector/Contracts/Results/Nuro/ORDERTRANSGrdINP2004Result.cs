using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class ORDERTRANSGrdINP2004Result : AbstractContractResult
    {
        private List<ORDERTRANSGrdINP2004Info> _grdInp2004Item = new List<ORDERTRANSGrdINP2004Info>();

        public List<ORDERTRANSGrdINP2004Info> GrdInp2004Item
        {
            get { return this._grdInp2004Item; }
            set { this._grdInp2004Item = value; }
        }

        public ORDERTRANSGrdINP2004Result() { }

    }
}