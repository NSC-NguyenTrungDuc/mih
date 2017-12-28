using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U13TrialItemListResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _trialList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> TrialList
        {
            get { return this._trialList; }
            set { this._trialList = value; }
        }

        public CLIS2015U13TrialItemListResult() { }

    }
}