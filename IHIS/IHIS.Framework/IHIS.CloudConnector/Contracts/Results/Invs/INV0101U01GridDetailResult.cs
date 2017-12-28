using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV0101U01GridDetailResult : AbstractContractResult
    {
        private List<INV0101U01GridDetailInfo> _grdDetailInfo = new List<INV0101U01GridDetailInfo>();

        public List<INV0101U01GridDetailInfo> GrdDetailInfo
        {
            get { return this._grdDetailInfo; }
            set { this._grdDetailInfo = value; }
        }

        public INV0101U01GridDetailResult() { }

    }
}