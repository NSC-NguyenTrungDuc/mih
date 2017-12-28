using System;
using IHIS.CloudConnector.Contracts.Models.Bass;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.Bass
{
    [Serializable]
    public class ComBizLoadComboDataSourceResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _listInfo = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> ListInfo
        {
            get { return this._listInfo; }
            set { this._listInfo = value; }
        }

        public ComBizLoadComboDataSourceResult() { }

    }
}