using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U02GrdProtocolResult : AbstractContractResult
    {
        private List<CLIS2015U02GrdProtocolInfo> _grdProtocolList = new List<CLIS2015U02GrdProtocolInfo>();

        public List<CLIS2015U02GrdProtocolInfo> GrdProtocolList
        {
            get { return this._grdProtocolList; }
            set { this._grdProtocolList = value; }
        }

        public CLIS2015U02GrdProtocolResult() { }

    }
}