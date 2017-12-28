using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0001U00GrdXRTResult : AbstractContractResult
    {
        private List<XRT0001U00GrdXRTInfo> _grdXrtItem = new List<XRT0001U00GrdXRTInfo>();

        public List<XRT0001U00GrdXRTInfo> GrdXrtItem
        {
            get { return this._grdXrtItem; }
            set { this._grdXrtItem = value; }
        }

        public XRT0001U00GrdXRTResult() { }

    }
}