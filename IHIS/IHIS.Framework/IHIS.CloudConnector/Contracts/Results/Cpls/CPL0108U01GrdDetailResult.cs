using System;
using IHIS.CloudConnector.Contracts.Models.Cpls;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL0108U01GrdDetailResult : AbstractContractResult
    {
        private List<CPL0108U01GrdDetailInfo> _grdDetailItem = new List<CPL0108U01GrdDetailInfo>();

        public List<CPL0108U01GrdDetailInfo> GrdDetailItem
        {
            get { return this._grdDetailItem; }
            set { this._grdDetailItem = value; }
        }

        public CPL0108U01GrdDetailResult() { }

    }
}