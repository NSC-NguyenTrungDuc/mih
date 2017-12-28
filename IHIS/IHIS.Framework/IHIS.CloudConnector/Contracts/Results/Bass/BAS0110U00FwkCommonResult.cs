using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0110U00FwkCommonResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _listInfo = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public BAS0110U00FwkCommonResult() { }

    }
}