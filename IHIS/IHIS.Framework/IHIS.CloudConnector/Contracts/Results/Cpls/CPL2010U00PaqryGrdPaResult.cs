using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL2010U00PaqryGrdPaResult : AbstractContractResult
    {
        private List<CPL2010U00PaqryGrdPaListItemInfo> _grdPaList = new List<CPL2010U00PaqryGrdPaListItemInfo>();

        public List<CPL2010U00PaqryGrdPaListItemInfo> GrdPaList
        {
            get { return this._grdPaList; }
            set { this._grdPaList = value; }
        }

        public CPL2010U00PaqryGrdPaResult() { }

    }
}