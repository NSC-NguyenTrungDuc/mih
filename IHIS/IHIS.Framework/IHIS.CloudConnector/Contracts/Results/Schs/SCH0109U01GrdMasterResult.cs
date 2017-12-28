using System;
using IHIS.CloudConnector.Contracts.Models.Schs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Schs
{
    [Serializable]
    public class SCH0109U01GrdMasterResult : AbstractContractResult
    {
        private List<SCH0109U01GrdMasterInfo> _grdMstItem = new List<SCH0109U01GrdMasterInfo>();

        public List<SCH0109U01GrdMasterInfo> GrdMstItem
        {
            get { return this._grdMstItem; }
            set { this._grdMstItem = value; }
        }

        public SCH0109U01GrdMasterResult() { }

    }
}