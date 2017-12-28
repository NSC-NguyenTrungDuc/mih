using System;
using IHIS.CloudConnector.Contracts.Models.Ocsa;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Ocsa
{
    [Serializable]
    public class OCS0203U00LoadGwaResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboList
        {
            get { return this._cboList; }
            set { this._cboList = value; }
        }

        public OCS0203U00LoadGwaResult() { }

    }
}