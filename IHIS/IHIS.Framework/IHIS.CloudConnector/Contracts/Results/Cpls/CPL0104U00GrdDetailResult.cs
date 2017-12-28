using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0104U00GrdDetailResult : AbstractContractResult
    {
        private List<CPL0104U00GrdDetailListItemInfo> _detailList = new List<CPL0104U00GrdDetailListItemInfo>();

        public List<CPL0104U00GrdDetailListItemInfo> DetailList
        {
            get { return this._detailList; }
            set { this._detailList = value; }
        }

        public CPL0104U00GrdDetailResult() { }

    }
}