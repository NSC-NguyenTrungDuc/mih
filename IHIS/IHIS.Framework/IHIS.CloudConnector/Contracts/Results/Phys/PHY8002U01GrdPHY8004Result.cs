using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01GrdPHY8004Result : AbstractContractResult
    {
        private List<PHY8002U01GrdPHY8004LisItemInfo> _list = new List<PHY8002U01GrdPHY8004LisItemInfo>();

        public List<PHY8002U01GrdPHY8004LisItemInfo> List
        {
            get { return this._list; }
            set { this._list = value; }
        }

        public PHY8002U01GrdPHY8004Result() { }

    }
}