using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class BAS0270U00LayGwaResult : AbstractContractResult
    {
        private List<DataStringListItemInfo> _gwaName = new List<DataStringListItemInfo>();

        public List<DataStringListItemInfo> GwaName
        {
            get { return this._gwaName; }
            set { this._gwaName = value; }
        }

        public BAS0270U00LayGwaResult() { }

    }
}