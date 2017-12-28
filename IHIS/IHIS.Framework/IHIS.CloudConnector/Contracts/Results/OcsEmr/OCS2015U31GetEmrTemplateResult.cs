using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31GetEmrTemplateResult : AbstractContractResult
    {
        private List<OCS2015U31GetEmrTemplateInfo> _gridTemplateItemInfo = new List<OCS2015U31GetEmrTemplateInfo>();

        public List<OCS2015U31GetEmrTemplateInfo> GridTemplateItemInfo
        {
            get { return this._gridTemplateItemInfo; }
            set { this._gridTemplateItemInfo = value; }
        }

        public OCS2015U31GetEmrTemplateResult() { }

    }
}