using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class IFS0003U00GridFindClickResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _cboList = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> CboList
        {
            get { return this._cboList; }
            set { this._cboList = value; }
        }

        public IFS0003U00GridFindClickResult() { }

    }
}