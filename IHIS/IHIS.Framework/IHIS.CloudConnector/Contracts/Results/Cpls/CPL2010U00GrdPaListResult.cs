using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00GrdPaListResult : AbstractContractResult
    {
        private List<CPL2010U00GrdPaListItemInfo> _grdPalistList = new List<CPL2010U00GrdPaListItemInfo>();

        public List<CPL2010U00GrdPaListItemInfo> GrdPalistList
        {
            get { return this._grdPalistList; }
            set { this._grdPalistList = value; }
        }

        public CPL2010U00GrdPaListResult() { }

    }
}