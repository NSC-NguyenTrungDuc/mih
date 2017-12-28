using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.Bass;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0101U00grdDetailResult : AbstractContractResult
    {
        private List<BAS0101U00grdDetailItemInfo> _grdDetail = new List<BAS0101U00grdDetailItemInfo>();

        public List<BAS0101U00grdDetailItemInfo> GrdDetail
        {
            get { return this._grdDetail; }
            set { this._grdDetail = value; }
        }

        public BAS0101U00grdDetailResult() { }

    }
}