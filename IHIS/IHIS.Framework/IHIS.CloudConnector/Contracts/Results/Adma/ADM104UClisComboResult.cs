using System;
using IHIS.CloudConnector.Contracts.Models.Adma;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM104UClisComboResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _dt = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> Dt
        {
            get { return this._dt; }
            set { this._dt = value; }
        }

        public ADM104UClisComboResult() { }

    }
}