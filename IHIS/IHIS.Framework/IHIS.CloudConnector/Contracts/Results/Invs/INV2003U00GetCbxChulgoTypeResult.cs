using System;
using IHIS.CloudConnector.Contracts.Models.Invs;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Invs
{
    public class INV2003U00GetCbxChulgoTypeResult : AbstractContractResult
    {
        private List<INV2003U00GetCbxChulgoTypeInfo> _listInfo = new List<INV2003U00GetCbxChulgoTypeInfo>();

        public List<INV2003U00GetCbxChulgoTypeInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public INV2003U00GetCbxChulgoTypeResult() { }

    }
}