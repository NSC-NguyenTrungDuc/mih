using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT9001R03Lay9003RResult : AbstractContractResult
    {
        private List<XRT9001R03Lay9003RListItemInfo> _lay9003RList = new List<XRT9001R03Lay9003RListItemInfo>();

        public List<XRT9001R03Lay9003RListItemInfo> Lay9003RList
        {
            get { return this._lay9003RList; }
            set { this._lay9003RList = value; }
        }

        public XRT9001R03Lay9003RResult() { }

    }
}