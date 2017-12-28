using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetHangmogGridFindResult : AbstractContractResult
    {
        private List<OCS0311U00grdSetHangmogGridFindListInfo> _grdSetHangmog = new List<OCS0311U00grdSetHangmogGridFindListInfo>();

        public List<OCS0311U00grdSetHangmogGridFindListInfo> GrdSetHangmog
        {
            get { return this._grdSetHangmog; }
            set { this._grdSetHangmog = value; }
        }

        public OCS0311U00grdSetHangmogGridFindResult() { }

    }
}