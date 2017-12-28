using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncDrugDosageCacheResult : AbstractContractResult
    {
        private List<DrugDosageInfo> _dataList = new List<DrugDosageInfo>();

        public List<DrugDosageInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncDrugDosageCacheResult() { }

    }
}