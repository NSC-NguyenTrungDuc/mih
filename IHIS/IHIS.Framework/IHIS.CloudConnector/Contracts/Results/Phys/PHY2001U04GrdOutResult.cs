using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdOutResult : AbstractContractResult
    {
        private List<PHY2001U04GrdOutInfo> _grdOutItem = new List<PHY2001U04GrdOutInfo>();

        public List<PHY2001U04GrdOutInfo> GrdOutItem
        {
            get { return this._grdOutItem; }
            set { this._grdOutItem = value; }
        }

        public PHY2001U04GrdOutResult() { }

    }
}