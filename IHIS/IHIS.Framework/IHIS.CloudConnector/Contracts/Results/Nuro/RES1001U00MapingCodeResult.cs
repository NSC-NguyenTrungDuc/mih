using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class RES1001U00MapingCodeResult : AbstractContractResult
    {
        private List<RES1001U00MapingCodeInfo> _listItem = new List<RES1001U00MapingCodeInfo>();

        public List<RES1001U00MapingCodeInfo> ListItem
        {
            get { return this._listItem; }
            set { this._listItem = value; }
        }

        public RES1001U00MapingCodeResult() { }

    }
}