using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0108Result : AbstractContractResult
    {
        private List<OCS0103U00GrdOCS0108Info> _grdOcs0108Item = new List<OCS0103U00GrdOCS0108Info>();

        public List<OCS0103U00GrdOCS0108Info> GrdOcs0108Item
        {
            get { return this._grdOcs0108Item; }
            set { this._grdOcs0108Item = value; }
        }

        public OCS0103U00GrdOCS0108Result() { }

    }
}