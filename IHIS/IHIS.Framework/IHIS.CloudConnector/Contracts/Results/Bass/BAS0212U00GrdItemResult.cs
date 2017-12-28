using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0212U00GrdItemResult : AbstractContractResult
    {
        private List<BAS0212U00GrdItemInfo> _grdInit = new List<BAS0212U00GrdItemInfo>();

        public List<BAS0212U00GrdItemInfo> GrdInit
        {
            get { return this._grdInit; }
            set { this._grdInit = value; }
        }

        public BAS0212U00GrdItemResult() { }

    }
}