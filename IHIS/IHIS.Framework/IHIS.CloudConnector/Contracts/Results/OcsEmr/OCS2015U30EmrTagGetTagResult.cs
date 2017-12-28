using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U30EmrTagGetTagResult : AbstractContractResult
    {
        private List<OCS2015U30EmrTagGetTagInfo> _gridTagItemInfo = new List<OCS2015U30EmrTagGetTagInfo>();

        public List<OCS2015U30EmrTagGetTagInfo> GridTagItemInfo
        {
            get { return this._gridTagItemInfo; }
            set { this._gridTagItemInfo = value; }
        }

        public OCS2015U30EmrTagGetTagResult() { }

    }
}