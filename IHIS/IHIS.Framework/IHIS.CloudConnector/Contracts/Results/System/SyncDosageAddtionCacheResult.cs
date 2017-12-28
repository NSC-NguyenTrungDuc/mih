using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncDosageAddtionCacheResult : AbstractContractResult
    {
        private List<DrugDosageAddtionInfo> _dataList = new List<DrugDosageAddtionInfo>();

        public List<DrugDosageAddtionInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncDosageAddtionCacheResult() { }

    }
}