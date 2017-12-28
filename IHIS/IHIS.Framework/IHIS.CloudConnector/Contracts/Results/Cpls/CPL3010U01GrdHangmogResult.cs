using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3010U01GrdHangmogResult : AbstractContractResult
    {
        private List<CPL3010U01GrdHangmogInfo> _grdHangmogLst = new List<CPL3010U01GrdHangmogInfo>();

        public List<CPL3010U01GrdHangmogInfo> GrdHangmogLst
        {
            get { return this._grdHangmogLst; }
            set { this._grdHangmogLst = value; }
        }

        public CPL3010U01GrdHangmogResult() { }

    }
}