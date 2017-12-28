using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM2016U00GrdLoadDrgResult : AbstractContractResult
    {
        private List<ADM2016U00GrdLoadDrgInfo> _itemInfo = new List<ADM2016U00GrdLoadDrgInfo>();

        public List<ADM2016U00GrdLoadDrgInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public ADM2016U00GrdLoadDrgResult() { }

    }
}