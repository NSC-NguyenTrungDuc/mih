using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0108U00GrdMasterResult : AbstractContractResult
    {
        private List<CPL0108U00InitGrdMasterListItemInfo> _grdMaster = new List<CPL0108U00InitGrdMasterListItemInfo>();

        public List<CPL0108U00InitGrdMasterListItemInfo> GrdMaster
        {
            get { return this._grdMaster; }
            set { this._grdMaster = value; }
        }

        public CPL0108U00GrdMasterResult() { }

    }
}