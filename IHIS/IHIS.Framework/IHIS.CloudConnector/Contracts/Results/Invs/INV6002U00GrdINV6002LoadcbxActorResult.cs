using System;
using IHIS.CloudConnector.Contracts.Models.INVS;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.INVS
{
    public class INV6002U00GrdINV6002LoadcbxActorResult : AbstractContractResult
    {
        private List<INV6002U00GrdINV6002LoadcbxActorInfo> _item = new List<INV6002U00GrdINV6002LoadcbxActorInfo>();

        public List<INV6002U00GrdINV6002LoadcbxActorInfo> Item
        {
            get { return this._item; }
            set { this._item = value; }
        }

        public INV6002U00GrdINV6002LoadcbxActorResult() { }

    }
}