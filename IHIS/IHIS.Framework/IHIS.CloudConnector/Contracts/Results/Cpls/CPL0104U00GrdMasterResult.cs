using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0104U00GrdMasterResult : AbstractContractResult
    {
        private List<CPL0104U00GrdMasterListItemInfo> _masterList = new List<CPL0104U00GrdMasterListItemInfo>();

        public List<CPL0104U00GrdMasterListItemInfo> MasterList
        {
            get { return this._masterList; }
            set { this._masterList = value; }
        }

        public CPL0104U00GrdMasterResult() { }

    }
}