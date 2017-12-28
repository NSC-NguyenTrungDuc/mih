using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncInteractionCacheResult : AbstractContractResult
    {
        private List<DrugInteractionInfo> _dataList = new List<DrugInteractionInfo>();

        public List<DrugInteractionInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncInteractionCacheResult() { }

    }
}