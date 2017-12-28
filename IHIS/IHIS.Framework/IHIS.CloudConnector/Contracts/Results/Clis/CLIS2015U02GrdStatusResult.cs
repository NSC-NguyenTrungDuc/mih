using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U02GrdStatusResult : AbstractContractResult
    {
        private List<CLIS2015U02GrdStatusInfo> _grdStatusList = new List<CLIS2015U02GrdStatusInfo>();

        public List<CLIS2015U02GrdStatusInfo> GrdStatusList
        {
            get { return this._grdStatusList; }
            set { this._grdStatusList = value; }
        }

        public CLIS2015U02GrdStatusResult() { }

    }
}