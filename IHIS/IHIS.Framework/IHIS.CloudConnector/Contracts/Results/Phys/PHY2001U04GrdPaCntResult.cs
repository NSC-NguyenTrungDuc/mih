using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdPaCntResult : AbstractContractResult
    {
        private List<PHY2001U04GrdPaCntInfo> _grdPaCntItem = new List<PHY2001U04GrdPaCntInfo>();

        public List<PHY2001U04GrdPaCntInfo> GrdPaCntItem
        {
            get { return this._grdPaCntItem; }
            set { this._grdPaCntItem = value; }
        }

        public PHY2001U04GrdPaCntResult() { }

    }
}