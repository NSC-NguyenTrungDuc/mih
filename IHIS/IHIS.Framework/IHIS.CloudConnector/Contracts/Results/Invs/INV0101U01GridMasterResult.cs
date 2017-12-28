using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV0101U01GridMasterResult : AbstractContractResult
    {
        private List<INV0101U01GridMasterInfo> _grdMasterInfo = new List<INV0101U01GridMasterInfo>();

        public List<INV0101U01GridMasterInfo> GrdMasterInfo
        {
            get { return this._grdMasterInfo; }
            set { this._grdMasterInfo = value; }
        }

        public INV0101U01GridMasterResult() { }

    }
}