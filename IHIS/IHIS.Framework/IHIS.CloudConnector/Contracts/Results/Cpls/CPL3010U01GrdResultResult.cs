using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01GrdResultResult : AbstractContractResult
    {
        private List<CPL3010U01GrdResultInfo> _grdResultLst = new List<CPL3010U01GrdResultInfo>();

        public List<CPL3010U01GrdResultInfo> GrdResultLst
        {
            get { return this._grdResultLst; }
            set { this._grdResultLst = value; }
        }

        public CPL3010U01GrdResultResult() { }

    }
}