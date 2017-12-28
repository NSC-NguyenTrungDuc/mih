using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6000U00GrdINV6001Result : AbstractContractResult
    {
        private List<INV6000U00GrdINV6001Info> _grdInv6001 = new List<INV6000U00GrdINV6001Info>();

        public List<INV6000U00GrdINV6001Info> GrdInv6001
        {
            get { return this._grdInv6001; }
            set { this._grdInv6001 = value; }
        }

        public INV6000U00GrdINV6001Result() { }

    }
}