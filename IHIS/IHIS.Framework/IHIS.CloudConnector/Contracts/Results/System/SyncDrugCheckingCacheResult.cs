using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncDrugCheckingCacheResult : AbstractContractResult
    {
        private List<DrugCheckingInfo> _dataList = new List<DrugCheckingInfo>();

        public List<DrugCheckingInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncDrugCheckingCacheResult() { }

    }
}