using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT0101U01GrdDcodeResult : AbstractContractResult
    {
        private List<XRT0101U01GrdDcodeListItemInfo> _grdList = new List<XRT0101U01GrdDcodeListItemInfo>();

        public List<XRT0101U01GrdDcodeListItemInfo> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public XRT0101U01GrdDcodeResult() { }

    }
}