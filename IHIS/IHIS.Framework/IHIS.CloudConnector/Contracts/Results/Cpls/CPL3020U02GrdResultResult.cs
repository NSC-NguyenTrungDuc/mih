using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02GrdResultResult : AbstractContractResult
    {
        private List<CPL3020U00GrdResultListItemInfo> _grdResultItemInfo = new List<CPL3020U00GrdResultListItemInfo>();

        public List<CPL3020U00GrdResultListItemInfo> GrdResultItemInfo
        {
            get { return this._grdResultItemInfo; }
            set { this._grdResultItemInfo = value; }
        }

        public CPL3020U02GrdResultResult() { }

    }
}