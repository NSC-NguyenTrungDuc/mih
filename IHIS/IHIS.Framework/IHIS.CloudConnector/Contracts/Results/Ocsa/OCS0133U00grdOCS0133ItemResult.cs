using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0133U00grdOCS0133ItemResult : AbstractContractResult
    {
        private List<OCS0133U00grdOCS0133ItemInfo> _grdOcs0133 = new List<OCS0133U00grdOCS0133ItemInfo>();

        public List<OCS0133U00grdOCS0133ItemInfo> GrdOcs0133
        {
            get { return this._grdOcs0133; }
            set { this._grdOcs0133 = value; }
        }

        public OCS0133U00grdOCS0133ItemResult() { }

    }
}