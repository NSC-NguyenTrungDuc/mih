using System;
using IHIS.CloudConnector.Contracts.Models.Phys;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Phys
{
    [Serializable]
    public class PHY8002U01MultiGrdResult : AbstractContractResult
    {
        private List<PHY8002U01GrdOTListItemInfo> _grdOTList = new List<PHY8002U01GrdOTListItemInfo>();
        private List<PHY8002U01GrdOTListItemInfo> _grdPTList = new List<PHY8002U01GrdOTListItemInfo>();
        private List<PHY8002U01GrdOTListItemInfo> _grdSTList = new List<PHY8002U01GrdOTListItemInfo>();

        public List<PHY8002U01GrdOTListItemInfo> GrdOTList
        {
            get { return this._grdOTList; }
            set { this._grdOTList = value; }
        }

        public List<PHY8002U01GrdOTListItemInfo> GrdPTList
        {
            get { return this._grdPTList; }
            set { this._grdPTList = value; }
        }

        public List<PHY8002U01GrdOTListItemInfo> GrdSTList
        {
            get { return this._grdSTList; }
            set { this._grdSTList = value; }
        }

        public PHY8002U01MultiGrdResult() { }

    }
}