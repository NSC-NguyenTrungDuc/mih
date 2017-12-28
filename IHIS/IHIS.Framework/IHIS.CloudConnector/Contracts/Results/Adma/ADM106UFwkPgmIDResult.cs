using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Adma
{
    [Serializable]
    public class ADM106UFwkPgmIDResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _fwkList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> FwkList
        {
            get { return this._fwkList; }
            set { this._fwkList = value; }
        }

        public ADM106UFwkPgmIDResult() { }

    }
}