using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01GrdPHY8002Result : AbstractContractResult
    {
        private List<PHY8002U01GrdPHY8002LisItemInfo> _list = new List<PHY8002U01GrdPHY8002LisItemInfo>();

        public List<PHY8002U01GrdPHY8002LisItemInfo> List
        {
            get { return this._list; }
            set { this._list = value; }
        }

        public PHY8002U01GrdPHY8002Result() { }

    }
}