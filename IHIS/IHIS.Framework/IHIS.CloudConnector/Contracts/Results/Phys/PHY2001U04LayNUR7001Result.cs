using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY2001U04LayNUR7001Result : AbstractContractResult
    {
        private List<PHY2001U04LayNUR7001Info> _layNurItem = new List<PHY2001U04LayNUR7001Info>();

        public List<PHY2001U04LayNUR7001Info> LayNurItem
        {
            get { return this._layNurItem; }
            set { this._layNurItem = value; }
        }

        public PHY2001U04LayNUR7001Result() { }

    }
}