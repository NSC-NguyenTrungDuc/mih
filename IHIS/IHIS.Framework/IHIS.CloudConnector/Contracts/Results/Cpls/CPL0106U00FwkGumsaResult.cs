using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0106U00FwkGumsaResult : AbstractContractResult
    {
        private List<CPL0106U00FwkGumsaListItemInfo> _fwkGumsaList = new List<CPL0106U00FwkGumsaListItemInfo>();

        public List<CPL0106U00FwkGumsaListItemInfo> FwkGumsaList
        {
            get { return this._fwkGumsaList; }
            set { this._fwkGumsaList = value; }
        }

        public CPL0106U00FwkGumsaResult() { }

    }
}