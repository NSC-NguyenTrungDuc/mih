using System;
using IHIS.CloudConnector.Contracts.Models.Clis;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Clis
{
    [Serializable]
    public class CLIS2015U02GrdTrialDrgResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _grdList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> GrdList
        {
            get { return this._grdList; }
            set { this._grdList = value; }
        }

        public CLIS2015U02GrdTrialDrgResult() { }

    }
}