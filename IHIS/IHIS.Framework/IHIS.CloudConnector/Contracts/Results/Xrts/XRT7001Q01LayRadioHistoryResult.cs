using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT7001Q01LayRadioHistoryResult : AbstractContractResult
    {
        private List<XRT7001Q01LayRadioHistoryListItemInfo> _layRadioHistoryList = new List<XRT7001Q01LayRadioHistoryListItemInfo>();

        public List<XRT7001Q01LayRadioHistoryListItemInfo> LayRadioHistoryList
        {
            get { return this._layRadioHistoryList; }
            set { this._layRadioHistoryList = value; }
        }

        public XRT7001Q01LayRadioHistoryResult() { }

    }
}