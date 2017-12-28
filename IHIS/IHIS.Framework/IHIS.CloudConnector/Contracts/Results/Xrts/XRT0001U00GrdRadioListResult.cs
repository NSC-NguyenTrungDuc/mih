using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0001U00GrdRadioListResult : AbstractContractResult
    {
        private List<XRT0001U00GrdRadioListInfo> _grdRadioItem = new List<XRT0001U00GrdRadioListInfo>();

        public List<XRT0001U00GrdRadioListInfo> GrdRadioItem
        {
            get { return this._grdRadioItem; }
            set { this._grdRadioItem = value; }
        }

        public XRT0001U00GrdRadioListResult() { }

    }
}