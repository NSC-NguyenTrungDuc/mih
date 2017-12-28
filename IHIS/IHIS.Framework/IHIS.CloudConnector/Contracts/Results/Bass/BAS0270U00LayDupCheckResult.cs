using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00LayDupCheckResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _y = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public BAS0270U00LayDupCheckResult() { }

    }
}