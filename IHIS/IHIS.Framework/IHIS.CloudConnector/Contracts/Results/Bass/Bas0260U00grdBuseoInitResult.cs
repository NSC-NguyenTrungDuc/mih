using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class Bas0260U00grdBuseoInitResult : AbstractContractResult
    {
        private List<BAS0260GrdBuseoListItemInfo> _grdInit = new List<BAS0260GrdBuseoListItemInfo>();

        public List<BAS0260GrdBuseoListItemInfo> GrdInit
        {
            get { return this._grdInit; }
            set { this._grdInit = value; }
        }

        public Bas0260U00grdBuseoInitResult() { }

    }
}