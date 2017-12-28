using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0101U00grdMasterResult : AbstractContractResult
    {
        private List<BAS0101U00GrdMasterItemInfo> _grdMaster = new List<BAS0101U00GrdMasterItemInfo>();

        public List<BAS0101U00GrdMasterItemInfo> GrdMaster
        {
            get { return this._grdMaster; }
            set { this._grdMaster = value; }
        }

        public BAS0101U00grdMasterResult() { }

    }
}