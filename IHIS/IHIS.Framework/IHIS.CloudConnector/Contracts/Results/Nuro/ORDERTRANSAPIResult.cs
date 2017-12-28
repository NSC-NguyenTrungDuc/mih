using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class ORDERTRANSAPIResult : AbstractContractResult
    {
        private ORDERTRANSAPIMsgInfo _msgItem;

        public ORDERTRANSAPIMsgInfo MsgItem
        {
            get { return this._msgItem; }
            set { this._msgItem = value; }
        }

        public ORDERTRANSAPIResult() { }

    }
}