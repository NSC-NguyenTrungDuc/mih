using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0212U00ComboListItemResult : AbstractContractResult
    {
        private List<BAS0212U00ComboListItemInfo> _comboItem = new List<BAS0212U00ComboListItemInfo>();

        public List<BAS0212U00ComboListItemInfo> ComboItem
        {
            get { return this._comboItem; }
            set { this._comboItem = value; }
        }

        public BAS0212U00ComboListItemResult() { }

    }
}