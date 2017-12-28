using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.System
{
    [Serializable]
    public class SyncKinkiMessageCacheResult : AbstractContractResult
    {
        private List<DrugKinkiMessageInfo> _dataList = new List<DrugKinkiMessageInfo>();

        public List<DrugKinkiMessageInfo> DataList
        {
            get { return this._dataList; }
            set { this._dataList = value; }
        }

        public SyncKinkiMessageCacheResult() { }

    }
}