using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0001U00GrdDetailResult : AbstractContractResult
    {
        private List<IFS0001U00GrdDetailInfo> _grdDetailItem = new List<IFS0001U00GrdDetailInfo>();

        public List<IFS0001U00GrdDetailInfo> GrdDetailItem
        {
            get { return this._grdDetailItem; }
            set { this._grdDetailItem = value; }
        }

        public IFS0001U00GrdDetailResult() { }

    }
}