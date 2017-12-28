using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTagGetTagResult : AbstractContractResult
    {
        private List<OCS2015U31EmrTagGetTagInfo> _gridTagItemInfo = new List<OCS2015U31EmrTagGetTagInfo>();

        public List<OCS2015U31EmrTagGetTagInfo> GridTagItemInfo
        {
            get { return this._gridTagItemInfo; }
            set { this._gridTagItemInfo = value; }
        }

        public OCS2015U31EmrTagGetTagResult() { }

    }
}