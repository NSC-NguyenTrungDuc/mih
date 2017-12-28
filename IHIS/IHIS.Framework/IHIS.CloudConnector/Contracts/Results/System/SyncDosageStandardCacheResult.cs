using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncDosageStandardCacheResult : AbstractContractResult
    {
        private List<DrugDosageStandardInfo> _dataList = new List<DrugDosageStandardInfo>();

        public List<DrugDosageStandardInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncDosageStandardCacheResult() { }

    }
}