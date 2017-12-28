using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Ocsa;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00grdSetCodeListResult : AbstractContractResult
    {
        private List<OCS0311U00grdSetCodeListInfo> _grdSetCode = new List<OCS0311U00grdSetCodeListInfo>();

        public List<OCS0311U00grdSetCodeListInfo> GrdSetCode
        {
            get { return this._grdSetCode; }
            set { this._grdSetCode = value; }
        }

        public OCS0311U00grdSetCodeListResult() { }

    }
}