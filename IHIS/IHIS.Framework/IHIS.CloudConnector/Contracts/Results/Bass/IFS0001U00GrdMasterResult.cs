using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0001U00GrdMasterResult : AbstractContractResult
    {
        private List<IFS0001U00GrdMasterInfo> _grdMstItem = new List<IFS0001U00GrdMasterInfo>();

        public List<IFS0001U00GrdMasterInfo> GrdMstItem
        {
            get { return this._grdMstItem; }
            set { this._grdMstItem = value; }
        }

        public IFS0001U00GrdMasterResult() { }

    }
}