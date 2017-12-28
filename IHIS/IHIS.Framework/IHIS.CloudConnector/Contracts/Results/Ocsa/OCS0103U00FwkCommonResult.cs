using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0103U00FwkCommonResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _comboItem = new List<ComboListItemInfo>();
        private List<OCS0103U00FwkCommonInfo> _fwkItem = new List<OCS0103U00FwkCommonInfo>();

        public List<ComboListItemInfo> ComboItem
        {
            get { return this._comboItem; }
            set { this._comboItem = value; }
        }

        public List<OCS0103U00FwkCommonInfo> FwkItem
        {
            get { return this._fwkItem; }
            set { this._fwkItem = value; }
        }

        public OCS0103U00FwkCommonResult() { }

    }
}