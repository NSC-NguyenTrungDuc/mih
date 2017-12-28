using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Adma;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM106UMakeQueryListItemResult : AbstractContractResult
    {
        private List<ADM106UMakeQueryListItemInfo> _listInfo = new List<ADM106UMakeQueryListItemInfo>();

        public List<ADM106UMakeQueryListItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public ADM106UMakeQueryListItemResult() { }

    }
}