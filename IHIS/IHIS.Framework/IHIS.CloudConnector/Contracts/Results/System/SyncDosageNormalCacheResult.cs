using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncDosageNormalCacheResult : AbstractContractResult
    {
        private List<DrugDosageNormalInfo> _dataList = new List<DrugDosageNormalInfo>();

        public List<DrugDosageNormalInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncDosageNormalCacheResult() { }

    }
}