using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00grdHangmogCodeResult : AbstractContractResult
    {
        private List<OCS0311U00grdHangmogCodeListInfo> _grdHangmog = new List<OCS0311U00grdHangmogCodeListInfo>();

        public List<OCS0311U00grdHangmogCodeListInfo> GrdHangmog
        {
            get { return this._grdHangmog; }
            set { this._grdHangmog = value; }
        }

        public OCS0311U00grdHangmogCodeResult() { }

    }
}