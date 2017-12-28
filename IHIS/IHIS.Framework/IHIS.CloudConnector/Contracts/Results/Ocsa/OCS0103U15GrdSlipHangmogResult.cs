using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U15GrdSlipHangmogResult : AbstractContractResult
    {
        private List<OCS0103U15GrdSlipHangmogInfo> _listItem = new List<OCS0103U15GrdSlipHangmogInfo>();

        public List<OCS0103U15GrdSlipHangmogInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public OCS0103U15GrdSlipHangmogResult() { }

    }
}