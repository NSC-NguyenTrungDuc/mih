using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00GrdOCS0113Result : AbstractContractResult
    {
        private List<OCS0103U00GrdOCS0113Info> _grdOcs0113Item = new List<OCS0103U00GrdOCS0113Info>();

        public List<OCS0103U00GrdOCS0113Info> GrdOcs0113Item
        {
            get { return this._grdOcs0113Item; }
            set { this._grdOcs0113Item = value; }
        }

        public OCS0103U00GrdOCS0113Result() { }

    }
}