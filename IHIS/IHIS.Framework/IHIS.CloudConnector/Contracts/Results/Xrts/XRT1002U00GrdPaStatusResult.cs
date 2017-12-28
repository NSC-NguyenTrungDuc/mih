using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00GrdPaStatusResult : AbstractContractResult
    {
        private List<XRT1002U00GrdPaStatusInfo> _grdPaStatusItem = new List<XRT1002U00GrdPaStatusInfo>();

        public List<XRT1002U00GrdPaStatusInfo> GrdPaStatusItem
        {
            get { return this._grdPaStatusItem; }
            set { this._grdPaStatusItem = value; }
        }

        public XRT1002U00GrdPaStatusResult() { }

    }
}