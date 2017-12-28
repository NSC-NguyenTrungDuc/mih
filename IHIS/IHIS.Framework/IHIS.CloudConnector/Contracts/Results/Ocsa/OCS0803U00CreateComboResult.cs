using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0803U00CreateComboResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _comboListItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> ComboListItem
        {
            get { return this._comboListItem; }
            set { this._comboListItem = value; }
        }

        public OCS0803U00CreateComboResult() { }

    }
}