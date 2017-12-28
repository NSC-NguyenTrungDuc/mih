using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00laySetHangmogResult : AbstractContractResult
    {
        private List<OCS0311U00laySetHangmogListInfo> _laySetHangmog = new List<OCS0311U00laySetHangmogListInfo>();

        public List<OCS0311U00laySetHangmogListInfo> LaySetHangmog
        {
            get { return this._laySetHangmog; }
            set { this._laySetHangmog = value; }
        }

        public OCS0311U00laySetHangmogResult() { }

    }
}