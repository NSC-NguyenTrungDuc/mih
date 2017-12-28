using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncGenericNameResult : AbstractContractResult
    {
        private List<DrugGenericNameInfo> _dataList = new List<DrugGenericNameInfo>();

        public List<DrugGenericNameInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncGenericNameResult() { }

    }
}