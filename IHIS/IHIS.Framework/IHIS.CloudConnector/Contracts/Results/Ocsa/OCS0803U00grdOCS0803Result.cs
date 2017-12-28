using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0803U00grdOCS0803Result : AbstractContractResult
    {
        private List<OCS0803U00grdOCS0803ItemInfo> _itemInfo = new List<OCS0803U00grdOCS0803ItemInfo>();

        public List<OCS0803U00grdOCS0803ItemInfo> ItemInfo
        {
            get { return this._itemInfo; }
            set { this._itemInfo = value; }
        }

        public OCS0803U00grdOCS0803Result() { }

    }
}