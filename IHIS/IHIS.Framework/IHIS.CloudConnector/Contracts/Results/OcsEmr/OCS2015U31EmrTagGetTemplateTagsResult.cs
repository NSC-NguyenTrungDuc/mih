using System;
using IHIS.CloudConnector.Contracts.Models.OcsEmr;
using System.Collections.Generic;

namespace IHIS.CloudConnector.Contracts.Results.OcsEmr
{
    [Serializable]
    public class OCS2015U31EmrTagGetTemplateTagsResult : AbstractContractResult
    {
        private List<OCS2015U31EmrTagGetTemplateTagsInfo> _temTagItemInfo = new List<OCS2015U31EmrTagGetTemplateTagsInfo>();

        public List<OCS2015U31EmrTagGetTemplateTagsInfo> TemTagItemInfo
        {
            get { return this._temTagItemInfo; }
            set { this._temTagItemInfo = value; }
        }

        public OCS2015U31EmrTagGetTemplateTagsResult() { }

    }
}