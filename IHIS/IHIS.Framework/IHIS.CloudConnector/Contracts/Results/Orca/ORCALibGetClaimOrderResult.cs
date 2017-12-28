using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibGetClaimOrderResult : AbstractContractResult
    {
        private List<ORCALibGetClaimOrderInfo> _claimOrderItem = new List<ORCALibGetClaimOrderInfo>();

        public List<ORCALibGetClaimOrderInfo> ClaimOrderItem
        {
            get { return this._claimOrderItem; }
            set { this._claimOrderItem = value; }
        }

        public ORCALibGetClaimOrderResult() { }

    }
}