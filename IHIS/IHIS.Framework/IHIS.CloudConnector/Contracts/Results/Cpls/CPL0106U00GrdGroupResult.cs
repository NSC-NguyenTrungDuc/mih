using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0106U00GrdGroupResult : AbstractContractResult
    {
        private List<CPL0106U00GrdGroupListItemInfo> _grdGroupList = new List<CPL0106U00GrdGroupListItemInfo>();

        public List<CPL0106U00GrdGroupListItemInfo> GrdGroupList
        {
            get { return this._grdGroupList; }
            set { this._grdGroupList = value; }
        }

        public CPL0106U00GrdGroupResult() { }

    }
}