using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0310P01GrdSusikMasterResult : AbstractContractResult
    {
        private List<BAS0310P01GrdSusikMasterInfo> _dt = new List<BAS0310P01GrdSusikMasterInfo>();

        public List<BAS0310P01GrdSusikMasterInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public BAS0310P01GrdSusikMasterResult() { }

    }
}