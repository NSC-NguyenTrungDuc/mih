using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02GrdPaResult : AbstractContractResult
    {
        private List<CPL3020U00GrdPaListItemInfo> _grdPaItemInfo = new List<CPL3020U00GrdPaListItemInfo>();

        public List<CPL3020U00GrdPaListItemInfo> GrdPaItemInfo
        {
            get { return this._grdPaItemInfo; }
            set { this._grdPaItemInfo = value; }
        }

        public CPL3020U02GrdPaResult() { }

    }
}