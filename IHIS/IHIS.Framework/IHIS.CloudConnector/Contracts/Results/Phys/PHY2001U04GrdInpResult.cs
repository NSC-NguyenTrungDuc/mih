using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdInpResult : AbstractContractResult
    {
        private List<PHY2001U04GrdInpInfo> _grdInpItem = new List<PHY2001U04GrdInpInfo>();

        public List<PHY2001U04GrdInpInfo> GrdInpItem
        {
            get { return this._grdInpItem; }
            set { this._grdInpItem = value; }
        }

        public PHY2001U04GrdInpResult() { }

    }
}