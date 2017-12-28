using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0101U00GrdOcs0101InitResult : AbstractContractResult
    {
        private List<OCS0101U00GrdOcs0101ListItemInfo> _listGrd0cs0101Init = new List<OCS0101U00GrdOcs0101ListItemInfo>();

        public List<OCS0101U00GrdOcs0101ListItemInfo> ListGrd0cs0101Init
        {
            get { return this._listGrd0cs0101Init; }
            set { this._listGrd0cs0101Init = value; }
        }

        public OCS0101U00GrdOcs0101InitResult() { }

    }
}