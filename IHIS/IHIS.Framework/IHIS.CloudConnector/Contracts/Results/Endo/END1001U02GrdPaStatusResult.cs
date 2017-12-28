using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02GrdPaStatusResult : AbstractContractResult
    {
        private List<END1001U02GrdPaStatusInfo> _grdPastatusItem = new List<END1001U02GrdPaStatusInfo>();

        public List<END1001U02GrdPaStatusInfo> GrdPastatusItem
        {
            get { return this._grdPastatusItem; }
            set { this._grdPastatusItem = value; }
        }

        public END1001U02GrdPaStatusResult() { }

    }
}