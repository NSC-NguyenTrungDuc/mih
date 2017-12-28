using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class DOC4003U00GetHospResult : AbstractContractResult
    {
        private DOC4003U00GetHospInfo _hospInfoItem;

        public DOC4003U00GetHospInfo HospInfoItem
        {
            get { return this._hospInfoItem; }
            set { this._hospInfoItem = value; }
        }

        public DOC4003U00GetHospResult() { }

    }
}