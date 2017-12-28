using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class HOTCODEMASTERGetGrdListResult : AbstractContractResult
    {
        private List<HOTCODEMASTERGetGrdListInfo> _grdListItem = new List<HOTCODEMASTERGetGrdListInfo>();

        public List<HOTCODEMASTERGetGrdListInfo> GrdListItem
        {
            get { return this._grdListItem; }
            set { this._grdListItem = value; }
        }

        public HOTCODEMASTERGetGrdListResult() { }

    }
}