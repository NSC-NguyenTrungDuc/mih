using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01GrdPaResult : AbstractContractResult
    {
        private List<CPL3010U01GrdPaInfo> _grdPaLst = new List<CPL3010U01GrdPaInfo>();

        public List<CPL3010U01GrdPaInfo> GrdPaLst
        {
            get { return this._grdPaLst; }
            set { this._grdPaLst = value; }
        }

        public CPL3010U01GrdPaResult() { }

    }
}