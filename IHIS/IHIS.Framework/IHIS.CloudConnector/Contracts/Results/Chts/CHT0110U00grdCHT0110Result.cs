using System;
using IHIS.CloudConnector.Contracts.Models.Chts;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Chts
{
    [Serializable]
    public class CHT0110U00grdCHT0110Result : AbstractContractResult
    {
        private List<CHT0110U00grdCHT0110ItemInfo> _grdItem = new List<CHT0110U00grdCHT0110ItemInfo>();

        public List<CHT0110U00grdCHT0110ItemInfo> GrdItem
        {
            get { return this._grdItem; }
            set { this._grdItem = value; }
        }

        public CHT0110U00grdCHT0110Result() { }

    }
}