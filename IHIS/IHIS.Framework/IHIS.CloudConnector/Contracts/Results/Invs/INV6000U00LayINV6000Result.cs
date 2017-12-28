using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6000U00LayINV6000Result : AbstractContractResult
    {
        private List<INV6000U00LayINV6000Info> _layInv6000 = new List<INV6000U00LayINV6000Info>();

        public List<INV6000U00LayINV6000Info> LayInv6000
        {
            get { return this._layInv6000; }
            set { this._layInv6000 = value; }
        }

        public INV6000U00LayINV6000Result() { }

    }
}