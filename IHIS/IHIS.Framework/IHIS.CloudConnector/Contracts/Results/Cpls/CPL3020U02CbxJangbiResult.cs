using System;
using IHIS.CloudConnector.Contracts.Models.System;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.Cpls
{
    [Serializable]
    public class CPL3020U02CbxJangbiResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cbxJangbiItem = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CbxJangbiItem
        {
            get { return this._cbxJangbiItem; }
            set { this._cbxJangbiItem = value; }
        }

        public CPL3020U02CbxJangbiResult() { }

    }
}