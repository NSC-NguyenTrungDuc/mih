using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncKinkiDiseaseCacheResult : AbstractContractResult
    {
        private List<DrugKinkiDiseaseInfo> _dataList = new List<DrugKinkiDiseaseInfo>();

        public List<DrugKinkiDiseaseInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncKinkiDiseaseCacheResult() { }

    }
}