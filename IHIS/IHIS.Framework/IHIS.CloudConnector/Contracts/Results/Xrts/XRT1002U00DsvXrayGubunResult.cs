using System;
using IHIS.CloudConnector.Contracts.Models.Xrts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Xrts
{
    [Serializable]
    public class XRT1002U00DsvXrayGubunResult : AbstractContractResult
    {
        private List<XRT1002U00DsvXrayGubunInfo> _xrayGubunItem = new List<XRT1002U00DsvXrayGubunInfo>();

        public List<XRT1002U00DsvXrayGubunInfo> XrayGubunItem
        {
            get { return this._xrayGubunItem; }
            set { this._xrayGubunItem = value; }
        }

        public XRT1002U00DsvXrayGubunResult() { }

    }
}