using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0212U00CListItemResult : AbstractContractResult
    {
        private List<BAS0212U00ListItemRequestInfo> _comboName = new List<BAS0212U00ListItemRequestInfo>();

        public List<BAS0212U00ListItemRequestInfo> ComboName
        {
            get { return this._comboName; }
            set { this._comboName = value; }
        }

        public BAS0212U00CListItemResult() { }

    }
}