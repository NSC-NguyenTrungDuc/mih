using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM103LayLoginSysListResult : AbstractContractResult
    {
        private List<ADM103LayLoginSysListInfo> _itemInfo = new List<ADM103LayLoginSysListInfo>();

        public List<ADM103LayLoginSysListInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public ADM103LayLoginSysListResult() { }

    }
}