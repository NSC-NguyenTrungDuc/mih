using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0310P01GrdGenDrgMasterResult : AbstractContractResult
    {
        private List<BAS0310P01GrdGenDrgMasterInfo> _dt = new List<BAS0310P01GrdGenDrgMasterInfo>();

        public List<BAS0310P01GrdGenDrgMasterInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0310P01GrdGenDrgMasterResult() { }

    }
}