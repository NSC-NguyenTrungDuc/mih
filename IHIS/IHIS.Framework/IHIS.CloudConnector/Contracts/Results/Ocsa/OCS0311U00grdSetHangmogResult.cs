using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetHangmogResult : AbstractContractResult
    {
        private List<OCS0311U00grdSetHangmogListInfo> _grdSetHangmog = new List<OCS0311U00grdSetHangmogListInfo>();

        public List<OCS0311U00grdSetHangmogListInfo> GrdSetHangmog
        {
            get { return this._grdSetHangmog; }
            set { this._grdSetHangmog = value; }
        }

        public OCS0311U00grdSetHangmogResult() { }

    }
}