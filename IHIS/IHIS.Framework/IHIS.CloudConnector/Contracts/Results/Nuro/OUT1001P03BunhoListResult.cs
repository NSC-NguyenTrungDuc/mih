using System;
using IHIS.CloudConnector.Contracts.Models.Nuro;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Nuro
{
    [Serializable]
    public class OUT1001P03BunhoListResult : AbstractContractResult
    {
        private List<OUT1001P03BunhoListItemInfo> _bunhoList = new List<OUT1001P03BunhoListItemInfo>();

        public List<OUT1001P03BunhoListItemInfo> BunhoList
        {
            get { return this._bunhoList; }
            set { this._bunhoList = value; }
        }

        public OUT1001P03BunhoListResult() { }

    }
}