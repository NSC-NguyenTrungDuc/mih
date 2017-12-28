using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV2003U00GrdINV2003Result : AbstractContractResult
    {
        private List<INV2003U00GrdINV2003Info> _listInfo = new List<INV2003U00GrdINV2003Info>();

        public List<INV2003U00GrdINV2003Info> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public INV2003U00GrdINV2003Result() { }

    }
}