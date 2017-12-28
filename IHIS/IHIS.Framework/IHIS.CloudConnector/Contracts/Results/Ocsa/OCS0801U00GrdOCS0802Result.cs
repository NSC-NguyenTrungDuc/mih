using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0801U00GrdOCS0802Result : AbstractContractResult
    {
        private List<OCS0801U00GrdOCS0802ListItemInfo> _listInfo = new List<OCS0801U00GrdOCS0802ListItemInfo>();

        public List<OCS0801U00GrdOCS0802ListItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public OCS0801U00GrdOCS0802Result() { }

    }
}