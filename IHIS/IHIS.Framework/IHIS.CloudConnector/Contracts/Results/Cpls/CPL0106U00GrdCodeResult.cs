using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0106U00GrdCodeResult : AbstractContractResult
    {
        private List<CPL0106U00GrdListItemInfo> _grdCodeList = new List<CPL0106U00GrdListItemInfo>();

        public List<CPL0106U00GrdListItemInfo> GrdCodeList
        {
            get { return this._grdCodeList; }
            set { this._grdCodeList = value; }
        }

        public CPL0106U00GrdCodeResult() { }

    }
}