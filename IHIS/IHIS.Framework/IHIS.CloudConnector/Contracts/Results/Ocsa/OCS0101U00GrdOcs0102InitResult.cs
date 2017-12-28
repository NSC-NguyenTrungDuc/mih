using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0101U00GrdOcs0102InitResult : AbstractContractResult
    {
        private List<OCS0101U00GrdOcs0102ListItemInfo> _listGrd0cs0102Init = new List<OCS0101U00GrdOcs0102ListItemInfo>();

        public List<OCS0101U00GrdOcs0102ListItemInfo> ListGrd0cs0102Init
        {
            get { return this._listGrd0cs0102Init; }
            set { this._listGrd0cs0102Init = value; }
        }

        public OCS0101U00GrdOcs0102InitResult() { }

    }
}