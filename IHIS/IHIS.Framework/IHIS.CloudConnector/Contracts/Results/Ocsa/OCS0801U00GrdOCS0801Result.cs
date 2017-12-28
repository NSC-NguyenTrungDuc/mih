using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0801U00GrdOCS0801Result : AbstractContractResult
    {
        private List<OCS0801U00GrdOCS0801ListItemInfo> _listItemInfo = new List<OCS0801U00GrdOCS0801ListItemInfo>();

        public List<OCS0801U00GrdOCS0801ListItemInfo> ListItemInfo
        {
            get { return this._listItemInfo; }
            set { this._listItemInfo = value; }
        }

        public OCS0801U00GrdOCS0801Result() { }

    }
}