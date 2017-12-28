using System;
using IHIS.CloudConnector.Contracts.Models.Orca;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Orca
{
    [Serializable]
    public class ORCALibGetClaimPatientResult : AbstractContractResult
    {
        private List<ORCALibGetClaimPatientInfo> _patItem = new List<ORCALibGetClaimPatientInfo>();

        public List<ORCALibGetClaimPatientInfo> PatItem
        {
            get { return this._patItem; }
            set { this._patItem = value; }
        }

        public ORCALibGetClaimPatientResult() { }

    }
}