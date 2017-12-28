using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Cpls;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0108U00GrdDetailResult : AbstractContractResult
    {
        private List<CPL0108U00InitGrdDetailListItemInfo> _grdDetail = new List<CPL0108U00InitGrdDetailListItemInfo>();

        public List<CPL0108U00InitGrdDetailListItemInfo> GrdDetail
        {
            get { return this._grdDetail; }
            set { this._grdDetail = value; }
        }

        public CPL0108U00GrdDetailResult() { }

    }
}