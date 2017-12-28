using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT9001R01Lay9001RResult : AbstractContractResult
    {
        private List<XRT9001R01Lay9001RListItemInfo> _lay9001RList = new List<XRT9001R01Lay9001RListItemInfo>();

        public List<XRT9001R01Lay9001RListItemInfo> Lay9001RList
        {
            get { return this._lay9001RList; }
            set { this._lay9001RList = value; }
        }

        public XRT9001R01Lay9001RResult() { }

    }
}