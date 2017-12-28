using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0004U01grdMasterResult : AbstractContractResult
    {
        private List<IFS0004U01grdMasterListItemInfo> _grdList = new List<IFS0004U01grdMasterListItemInfo>();

        public List<IFS0004U01grdMasterListItemInfo> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public IFS0004U01grdMasterResult() { }

    }
}