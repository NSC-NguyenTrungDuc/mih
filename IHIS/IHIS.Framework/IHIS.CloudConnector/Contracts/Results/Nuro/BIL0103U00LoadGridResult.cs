using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    public class BIL0103U00LoadGridResult : AbstractContractResult
    {
        private List<BIL0103U00LoadGridInfo> _grdlist = new List<BIL0103U00LoadGridInfo>();

        public List<BIL0103U00LoadGridInfo> Grdlist
        {
            get { return this._grdlist; }
            set { this._grdlist = value; }
        }

        public BIL0103U00LoadGridResult() { }

    }
}