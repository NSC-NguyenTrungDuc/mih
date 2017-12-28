using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0106U00GridColumnChangeResult : AbstractContractResult
    {
        private List<CPL0106U00FwkGumsaListItemInfo> _resultList = new List<CPL0106U00FwkGumsaListItemInfo>();

        public List<CPL0106U00FwkGumsaListItemInfo> ResultList
        {
            get { return this._resultList; }
            set { this._resultList = value; }
        }

        public CPL0106U00GridColumnChangeResult() { }

    }
}