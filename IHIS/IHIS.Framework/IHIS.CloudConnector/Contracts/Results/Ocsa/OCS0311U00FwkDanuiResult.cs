using System;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0311U00FwkDanuiResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _fwkDanuiList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> FwkDanuiList
        {
            get { return this._fwkDanuiList; }
            set { this._fwkDanuiList = value; }
        }

        public OCS0311U00FwkDanuiResult() { }

    }
}