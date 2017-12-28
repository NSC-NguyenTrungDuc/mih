using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04GrdOut1001Result : AbstractContractResult
    {
        private List<PHY2001U04GrdOut1001Info> _grdOut1001Item = new List<PHY2001U04GrdOut1001Info>();

        public List<PHY2001U04GrdOut1001Info> GrdOut1001Item
        {
            get { return this._grdOut1001Item; }
            set { this._grdOut1001Item = value; }
        }

        public PHY2001U04GrdOut1001Result() { }

    }
}