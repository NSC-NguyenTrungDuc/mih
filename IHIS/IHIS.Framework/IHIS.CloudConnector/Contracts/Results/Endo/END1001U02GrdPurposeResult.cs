using System;
using IHIS.CloudConnector.Contracts.Models.Endo;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Endo
{
    [Serializable]
    public class END1001U02GrdPurposeResult : AbstractContractResult
    {
        private List<END1001U02GrdPurposeInfo> _grdPurposeItem = new List<END1001U02GrdPurposeInfo>();

        public List<END1001U02GrdPurposeInfo> GrdPurposeItem
        {
            get { return this._grdPurposeItem; }
            set { this._grdPurposeItem = value; }
        }

        public END1001U02GrdPurposeResult() { }

    }
}