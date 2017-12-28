using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;
using IHIS.CloudConnector.Contracts.Models.System;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    public class OCS2015U31LoadComboDepartResult : AbstractContractResult
    {
        private List<ComboListItemInfo> _departInfo = new List<ComboListItemInfo>();

        public List<ComboListItemInfo> DepartInfo
        {
            get { return this._departInfo; }
            set { this._departInfo = value; }
        }

        public OCS2015U31LoadComboDepartResult() { }

    }
}