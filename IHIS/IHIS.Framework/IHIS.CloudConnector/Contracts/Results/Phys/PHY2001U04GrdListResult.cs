using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdListResult : AbstractContractResult
    {
        private List<PHY2001U04GrdListInfo> _grdListItem = new List<PHY2001U04GrdListInfo>();

        public List<PHY2001U04GrdListInfo> GrdListItem
        {
            get { return this._grdListItem; }
            set { this._grdListItem = value; }
        }

        public PHY2001U04GrdListResult() { }

    }
}