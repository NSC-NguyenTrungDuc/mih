using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0111U00GrdMasterResult : AbstractContractResult
    {
        private List<BAS0111U00GrdMasterItemInfo> _dt = new List<BAS0111U00GrdMasterItemInfo>();

        public List<BAS0111U00GrdMasterItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0111U00GrdMasterResult() { }

    }
}