using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibGetClaimDiagnosisResult : AbstractContractResult
    {
        private List<ORCALibGetClaimDiagnosisInfo> _claimDiagnosisItem = new List<ORCALibGetClaimDiagnosisInfo>();
        private Boolean _result;

        public List<ORCALibGetClaimDiagnosisInfo> ClaimDiagnosisItem
        {
            get { return this._claimDiagnosisItem; }
            set { this._claimDiagnosisItem = value; }
        }

        public Boolean Result
        {
            get { return this._result; }
            set { this._result = value; }
        }

        public ORCALibGetClaimDiagnosisResult() { }

    }
}