using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0103Result : AbstractContractResult
    {
        private List<OCS0103U00GrdOCS0103Info> _grdOcs0103Item = new List<OCS0103U00GrdOCS0103Info>();

        public List<OCS0103U00GrdOCS0103Info> GrdOcs0103Item
        {
            get { return this._grdOcs0103Item; }
            set { this._grdOcs0103Item = value; }
        }

        public OCS0103U00GrdOCS0103Result() { }

    }
}