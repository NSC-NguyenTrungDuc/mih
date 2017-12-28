using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibGetClaimInsuredResult : AbstractContractResult
    {
        private List<ORCALibGetClaimInsuredInfo> _claimInsItem = new List<ORCALibGetClaimInsuredInfo>();

        public List<ORCALibGetClaimInsuredInfo> ClaimInsItem
        {
            get { return this._claimInsItem; }
            set { this._claimInsItem = value; }
        }

        public ORCALibGetClaimInsuredResult() { }

    }
}