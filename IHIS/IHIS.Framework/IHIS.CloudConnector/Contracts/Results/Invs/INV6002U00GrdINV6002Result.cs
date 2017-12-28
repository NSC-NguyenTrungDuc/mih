using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV6002U00GrdINV6002Result : AbstractContractResult
    {
        private List<INV6002U00GrdINV6002Info> _grdItem = new List<INV6002U00GrdINV6002Info>();

        public List<INV6002U00GrdINV6002Info> GrdItem
        {
            get { return this._grdItem; }
            set { this._grdItem = value; }
        }

        public INV6002U00GrdINV6002Result() { }

    }
}