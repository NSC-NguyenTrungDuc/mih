using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0110U00GrdJohapResult : AbstractContractResult
    {
        private List<BAS0110U00GrdJohapListItemInfo> _listGrdJohap = new List<BAS0110U00GrdJohapListItemInfo>();

        public List<BAS0110U00GrdJohapListItemInfo> ListGrdJohap
        {
            get { return this._listGrdJohap; }
            set { this._listGrdJohap = value; }
        }

        public BAS0110U00GrdJohapResult() { }

    }
}